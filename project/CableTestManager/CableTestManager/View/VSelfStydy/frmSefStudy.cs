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

namespace CableTestManager.View.VSelfStydy
{
    public partial class frmSefStudy : Telerik.WinControls.UI.RadForm
    {
        private InterfaceInfoLibraryManager InterfaceInfoLibrary;
        public List<SelfStudyTestParams> studyTestParamsList;
        private SelfStudyConfig studyConfig;

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

        private void frmSefStudy_Load(object sender, EventArgs e)
        {
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
            this.studyConfig.StudyTestType = SelfStudyConfig.SutdyTestTypeEnum.SelfTestByLimit;
            this.studyConfig.LimitMin = (int)this.num_fmin.Value;
            this.studyConfig.LimitMax = (int)this.num_fmax.Value;
            this.studyConfig.TestThresholdVal = (float)this.num_fthreshold.Value;
            this.Close();
            this.DialogResult = DialogResult.OK;
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
            this.Close();
            this.DialogResult = DialogResult.OK;
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
