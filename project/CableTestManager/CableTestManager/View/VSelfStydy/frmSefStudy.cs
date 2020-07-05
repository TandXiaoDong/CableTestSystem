using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using CableTestManager.Business.Implements;
using CableTestManager.Business;
using WindowsFormTelerik.ControlCommon;
using CableTestManager.Common;
using Telerik.WinControls.UI;
using CableTestManager.Model;
using System.Configuration;

namespace CableTestManager.View.VSelfStydy
{
    public partial class frmSefStudy : Telerik.WinControls.UI.RadForm
    {
        private InterfaceInfoLibraryManager InterfaceInfoLibrary;
        public List<SelfStudyTestParams> studyTestParamsList;
        private SelfStudyConfig studyConfig;
        public double selfStudyTestTotalCount;
        private List<int> devPointAList;//目前六张卡，前三张卡为A,后三张为B
        private List<int> devPointBList;
        private int aListOrderMin;//A中序号的最小值
        private int aListOrderMax;//B中序号的最大值

        public frmSefStudy(SelfStudyConfig config)
        {
            InitializeComponent();
            this.studyConfig = config;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void Init()
        {
            this.conductionThresholdByPin.Maximum = 1000;
            this.conductionThresholdByPin.Minimum = 0;
            this.conductionThresholdByPin.Increment = 10;
            this.conductionThresholdByPin.Value = 1000;

            this.num_fthreshold.Maximum = 1000;
            this.num_fthreshold.Minimum = 0;
            this.num_fthreshold.Increment = 10;
            this.num_fthreshold.Value = 1000;

            this.num_fmin.Minimum = 1;
            this.num_fmin.Maximum = 384;
            this.num_fmax.Minimum = 1;
            this.num_fmax.Maximum = 384;

            this.InterfaceInfoLibrary = new InterfaceInfoLibraryManager();
            this.studyTestParamsList = new List<SelfStudyTestParams>();
        }

        private void InitDefaultDevPoint()
        {
            this.devPointAList = new List<int>();
            this.devPointBList = new List<int>();
            //add A point
            for (int i = 1; i < 49; i++)
            {
                this.devPointAList.Add(i);
            }
            for (int i = 65; i < 113; i++)
            {
                this.devPointAList.Add(i);
            }
            for (int i = 129; i < 177; i++)
            {
                this.devPointAList.Add(i);
            }
            //add B point
            for (int i = 193; i < 241; i++)
            {
                this.devPointBList.Add(i);
            }
            for (int i = 257; i < 305; i++)
            {
                this.devPointBList.Add(i);
            }
            for (int i = 321; i < 369; i++)
            {
                this.devPointBList.Add(i);
            }
        }

        private void frmSefStudy_Load(object sender, EventArgs e)
        {
            if(this.studyConfig.TestInterAList != null)
            {
                this.studyConfig.TestInterAList.Clear();
            }
            if (this.studyConfig.TestInterBList != null)
            {
                this.studyConfig.TestInterBList.Clear();
            }
            //InitDefaultDevPoint();
            this.mulInterA.MultiColumnComboBoxElement.Columns.Add("A");
            this.mulInterB.MultiColumnComboBoxElement.Columns.Add("B");
            StudyProbCom.InitMulCombox(this.mulInterA);
            StudyProbCom.InitMulCombox(this.mulInterB);
            if (this.mulInterA.EditorControl.Rows.Count >= 1)
            {
                this.mulInterA.SelectedIndex = 0;
            }
            if (this.mulInterB.EditorControl.Rows.Count >= 2)
            {
                this.mulInterB.SelectedIndex = 1;
            }
            Init();

            this.btn_defineStudyByPin.Click += Btn_defineStudyByPin_Click;
            this.btn_cancelByPin.Click += Btn_cancelByPin_Click;
            this.btn_fstart.Click += Btn_fstart_Click;
            this.btn_fcancel.Click += Btn_fcancel_Click;
        }

        private void Btn_fcancel_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void Btn_fstart_Click(object sender, EventArgs e)
        {
            //this.studyConfig.LimitMin = (int)this.num_fmin.Value;
            //this.studyConfig.LimitMax = (int)this.num_fmax.Value;
            var min = (int)this.num_fmin.Value;
            var max = (int)this.num_fmax.Value;
            if (max < min)
            {
                MessageBox.Show("最大值应大于最小值！","提示",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<string> interList = GetInterfaceInfo();
            if (interList.Count != 2)
            {
                MessageBox.Show("请检查接口库配置，接口库需正确配置两个端的接口才可使用该方法测试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var list1 = GetAllDevPointByInter(interList[0]);
            var list2 = GetAllDevPointByInter(interList[1]);
            list1.Sort();
            list2.Sort();
            var cardCountStr = ConfigurationManager.AppSettings["cardCount"].ToString();
            int cardCount;
            if (!int.TryParse(cardCountStr, out cardCount))
            {
                MessageBox.Show("请检查卡槽数配置，配置文件位于应用程序路径下的CableTestManager.exe.config文件，配置参数为cardCount！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var judgeValue = (cardCount / 2) * 64;
            if (IsCheckACard(list1, judgeValue))
            {
                this.studyConfig.TestInterAList = ConvertDevPointHex(GetPartDevPointAByLimit(min, max, list1));
                this.studyConfig.TestInterBList = ConvertDevPointHex(GetPartDevPointBByLimit(list2));
            }
            else
            {
                this.studyConfig.TestInterAList = ConvertDevPointHex(GetPartDevPointAByLimit(min, max, list2));
                this.studyConfig.TestInterBList = ConvertDevPointHex(GetPartDevPointBByLimit(list1));
            }
            //this.studyConfig.TestInterAList = ConvertDevPointHex(GetPartDevPointAByLimit(min, max , this.devPointAList));
            //this.studyConfig.TestInterBList = ConvertDevPointHex(GetPartDevPointBByLimit(this.devPointBList));
            this.studyConfig.TestThresholdVal = (float)this.num_fthreshold.Value;
            this.studyConfig.StudyTestType = SelfStudyConfig.SutdyTestTypeEnum.SelfTestByLimit;
            this.selfStudyTestTotalCount = (max - min + 1);
            
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private bool IsCheckACard(List<int> list, int judgeValue)
        {
            foreach (var val in list)
            {
                if (val > judgeValue)
                {
                    return false;
                }
            }
            return true;
        }

        private void AddSelfStudyTestParams(string interfaceName, string contactPoint, string devPoint)
        {
            SelfStudyTestParams selfStudyTest = new SelfStudyTestParams();
            int cpoint;
            int dpoint;
            int.TryParse(contactPoint, out cpoint);
            int.TryParse(devPoint, out dpoint);
            selfStudyTest.StudyInterface = interfaceName;
            selfStudyTest.StudyPoint = cpoint;
            selfStudyTest.DevicePoint = dpoint;
            var testObj = this.studyTestParamsList.Find(obj => obj.StudyInterface == interfaceName && obj.StudyPoint == cpoint);
            if (testObj == null)
            {
                this.studyTestParamsList.Add(selfStudyTest);
            }
        }

        private void QueryContinuousGroupPoint(List<int> pointList)
        {
            if (pointList.Count <= 0)
                return;
            GetContinuousPoint(pointList, 0, pointList[0]);
        }

        private void Btn_cancelByInterface_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void Btn_cancelByPin_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void Btn_defineStudyByPin_Click(object sender, EventArgs e)
        {
            CommitStudyByInterface();
        }

        private void CommitStudyByInterface()
        {
            if (this.mulInterA.Text == "")
            {
                MessageBox.Show("请选择一个A接口","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (this.mulInterB.Text == "")
            {
                MessageBox.Show("请选择一个B接口", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.studyConfig.TestInterAList = ConvertDevPointHex(GetAllDevPointByInter(this.mulInterA.Text.Trim()));
            this.studyConfig.TestInterBList = ConvertDevPointHex(GetAllDevPointByInter(this.mulInterB.Text.Trim()));
            this.studyConfig.TestThresholdVal = (float)this.conductionThresholdByPin.Value;
            this.studyConfig.StudyTestType = SelfStudyConfig.SutdyTestTypeEnum.SelfTestByInterface;
            this.selfStudyTestTotalCount = GetInterListCount(this.mulInterA.Text.Trim());
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private int GetInterListCount(string interName)
        {
            return this.InterfaceInfoLibrary.GetRowCountByWhere($"where InterfaceNo='{interName}'");
        }

        private List<string> GetInterfaceInfo()
        {
            List<string> list = new List<string>();
            var data = this.InterfaceInfoLibrary.GetDataSetByFieldsAndWhere($"distinct InterfaceNo","").Tables[0];
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    if (!list.Contains(dr[0].ToString()))
                    {
                        list.Add(dr[0].ToString());
                    }
                }
            }
            return list;
        }

        private List<int> GetAllDevPointByInter(string interName)
        {
            var data =  this.InterfaceInfoLibrary.GetDataSetByWhere($"where InterfaceNo='{interName}'").Tables[0];
            List<int> list = new List<int>();
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    int point;
                    if (int.TryParse(dr["SwitchStandStitchNo"].ToString(), out point))
                    {
                        list.Add(point);
                    }
                }
                if (list.Count <= 0)
                    return list;
                list.Sort();
                //分奇数偶数
                List<int> sigList = new List<int>();
                List<int> douList = new List<int>();
                foreach (var val in list)
                {
                    if ((val + 1) % 2 == 0)
                    {
                        sigList.Add(val);
                    }
                    else
                    {
                        douList.Add(val);
                    }
                }
                list.Clear();
                list.AddRange(sigList);
                list.AddRange(douList);
            }
            return list;
        }

        private List<int> GetPartDevPointAByLimit(int min, int max, List<int> devPointList)
        {
            List<int> list = new List<int>();
            List<int> aOrderList = new List<int>();
            int i = 0;
            foreach (var val in devPointList)
            {
                if (i >= min - 1 && i <= max -1)
                {
                    list.Add(val);
                    aOrderList.Add(i);
                }
                i++;
            }
            if (list.Count <= 0)
                return list;
            list.Sort();
            aOrderList.Sort();
            this.aListOrderMin = aOrderList[0];
            this.aListOrderMax = aOrderList[aOrderList.Count - 1];
            //分奇数偶数
            List<int> sigList = new List<int>();
            List<int> douList = new List<int>();
            foreach (var val in list)
            {
                if ((val + 1) % 2 == 0)
                {
                    sigList.Add(val);
                }
                else
                {
                    douList.Add(val);
                }
            }
            list.Clear();
            list.AddRange(sigList);
            list.AddRange(douList);

            return list;
        }

        private List<int> GetPartDevPointBByLimit(List<int> devPointList)
        {
            List<int> list = new List<int>();
            int i = 0;
            foreach (var val in devPointList)
            {
                if (i >= this.aListOrderMin && i <= this.aListOrderMax)
                {
                    list.Add(val);
                }
                i++;
            }
            if (list.Count <= 0)
                return list;
            list.Sort();
            //分奇数偶数
            List<int> sigList = new List<int>();
            List<int> douList = new List<int>();
            foreach (var val in list)
            {
                if ((val + 1) % 2 == 0)
                {
                    sigList.Add(val);
                }
                else
                {
                    douList.Add(val);
                }
            }
            list.Clear();
            list.AddRange(sigList);
            list.AddRange(douList);

            return list;
        }

        private StringBuilder ConvertDevPointHex(List<int> decList)
        {
            StringBuilder sb = new StringBuilder();
            if (decList.Count > 0)
            {
                foreach (var val in decList)
                {
                    var hexVal = DecConvert2ByteHexStr(val);
                    sb.Append(hexVal);
                }
            }
            return sb;
        }
        private string DecConvert2ByteHexStr(int dec)
        {
            return Convert.ToString(dec, 16).PadLeft(4, '0');
        }

        private int GetDevicePointByID(string interName,int id)
        {
            var data = this.InterfaceInfoLibrary.GetDataSetByFieldsAndWhere("SwitchStandStitchNo", $"where InterfaceNo='{interName}' and ContactPoint='{id}'").Tables[0];
            return int.Parse(data.Rows[0][0].ToString());
        }

        private bool IsExistRow(string InterNo, RadGridView radView)
        {
            if (radView.RowCount <= 0)
                return false;
            foreach (var rowInfo in radView.Rows)
            {
                if (rowInfo.Cells[1].Value.ToString() == InterNo)
                    return true;
            }
            return false;
        }

        private List<int> QueryInterPointByInterNo(bool IsSectAll, RadGridView radView)
        {
            List<int> pointList = new List<int>();
            if (radView.RowCount <= 0)
                return pointList;
            int count = 0;
            foreach (var rowInfo in radView.Rows)
            {
                if (!IsSectAll)
                {
                    var state = rowInfo.Cells[2].Value;
                    if (state == null)
                        continue;
                    if (state.ToString() == "0")
                        continue;
                }
                var interNo = rowInfo.Cells[1].Value.ToString().Trim();
                var data = this.InterfaceInfoLibrary.GetDataSetByFieldsAndWhere("distinct SwitchStandStitchNo", $"where InterfaceNo='{interNo}'").Tables[0];
                foreach (DataRow dr in data.Rows)
                {
                    var point = dr[0].ToString();
                    var pointVal = 0;
                    if (point.Contains(","))
                    {
                        foreach (var val in point.Split(','))
                        {
                            if (int.TryParse(val, out pointVal))
                            {
                                if (!pointList.Contains(pointVal))
                                {
                                    pointList.Add(pointVal);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (int.TryParse(point, out pointVal))
                        {
                            if (!pointList.Contains(pointVal))
                            {
                                pointList.Add(pointVal);
                            }
                        }
                    }
                }
                count++;
            }
            pointList.Sort();
            return pointList;
        }

        private void GetContinuousPoint(List<int> list, int startIndex, int startVal)
        {
            //if (startVal >= list[list.Count - 1])
            //    return;
            //int i = startVal;
            //frmSefStudy frmSef = new frmSefStudy();
            //frmSef.pinMin = startVal;
            //this.conductThresholdByPin = (float)this.conductionThresholdByPin.Value;
            //frmSef.conductThresholdByPin = this.conductThresholdByPin;
            //for (int j = startIndex;j < list.Count;j++)
            //{
            //    if (list[j] != startVal)//存在不连续的点
            //    {
            //        frmSef.pinMax = list[j - 1];
            //        this.selfParamList.Add(frmSef);
            //        GetContinuousPoint(list, j, list[j]);
            //        return;
            //    }
            //    startVal++;
            //}
            ////不存在不连续的点
            //frmSef.pinMax = startVal - 1;
            //this.selfParamList.Add(frmSef);
        }
    }
}
