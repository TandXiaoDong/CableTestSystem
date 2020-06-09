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

namespace CableTestManager.View.VSelfStydy
{
    public partial class frmSefStudy : Telerik.WinControls.UI.RadForm
    {
        public int pinMin = 1;
        public int pinMax = 1;
        public string curInterfaceName;
        public string hexMeasureMethod = "02";
        public float conductThresholdByPin;
        public List<frmSefStudy> selfParamList;
        public StudyTypeEnum studyTypeEnum;
        private InterfaceInfoLibraryManager InterfaceInfoLibrary;
        //private TCableTestLibraryManager cableTestLibraryManager = new TCableTestLibraryManager();
        public List<SelfStudyTestParams> studyTestParamsList = new List<SelfStudyTestParams>();
        private List<int> selectInterPointList = new List<int>();

        public enum StudyTypeEnum
        {
            /// <summary>
            /// 范围学习
            /// </summary>
            PartStudyByLimit,

            /// <summary>
            /// 按接口学习
            /// </summary>
            PartStudyByInterface,
            CancelStudy
        }

        public frmSefStudy()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void frmSefStudy_Load(object sender, EventArgs e)
        {
            this.num_min.Maximum = 383;
            this.num_min.Minimum = 1;
            this.num_min.Increment = 2;

            this.num_max.Minimum = 1;
            this.num_min.Maximum = 384;
            this.num_max.Increment = 2;

            this.conductionThresholdByPin.Maximum = 1200;
            this.conductionThresholdByPin.Minimum = 0;
            this.conductionThresholdByPin.Increment = 10;

            this.selfParamList = new List<frmSefStudy>();
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,false,0);
            this.radGridView1.Columns[0].ReadOnly = true;
            this.radGridView1.Columns[1].ReadOnly = true;
            this.InterfaceInfoLibrary = new InterfaceInfoLibraryManager();
            QueryInterfaceLibrary();

            this.btn_defineStudyByPin.Click += Btn_defineStudyByPin_Click;
            this.btn_cancelByPin.Click += Btn_cancelByPin_Click;
            this.btn_fstart.Click += Btn_fstart_Click;
            this.btn_fcancel.Click += Btn_fcancel_Click;
            this.radGridView1.ValueChanged += RadGridView1_ValueChanged;
            this.radGridView1.CellValueChanged += RadGridView1_CellValueChanged;
        }

        private void RadGridView1_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            Commit();
        }

        private void Btn_fcancel_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void Btn_fstart_Click(object sender, EventArgs e)
        {
            this.studyTypeEnum = StudyTypeEnum.PartStudyByLimit;
            this.pinMin = (int)this.num_fmin.Value;
            this.pinMax = (int)this.num_fmax.Value;
            this.conductThresholdByPin = (float)this.num_fthreshold.Value;
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void RadGridView1_ValueChanged(object sender, EventArgs e)
        {
            if (this.radGridView1.ActiveEditor is RadCheckBoxEditor)
            {
                var rowIndex = this.radGridView1.CurrentCell.RowIndex;
                var columnIndex = this.radGridView1.CurrentCell.ColumnIndex;
                var value = this.radGridView1.ActiveEditor.Value;
                var interName = this.radGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                
                //value.ToString() == "On"
                if (columnIndex == 2)
                {
                    if (value.ToString() == "On")
                    {
                        CalPointLimit(interName);
                    }
                    else
                    {
                        this.pinMax = 1;
                        this.pinMin = 1;
                    }
                }
            } 
        }

        private void CalPointLimit(string interName)
        {
            //SetCheckFalse(rowIndex);
            this.selectInterPointList.Clear();
            var data = this.InterfaceInfoLibrary.GetDataSetByFieldsAndWhere("SwitchStandStitchNo", $"where InterfaceNo='{interName}'").Tables[0];
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    //AddSelfStudyTestParams();
                    int point;
                    if (int.TryParse(dr[0].ToString(), out point))
                    {
                        selectInterPointList.Add(point);
                    }
                }
                selectInterPointList.Sort();
                var curMax = selectInterPointList[selectInterPointList.Count - 1];
                var curMin = selectInterPointList[0];
                if (this.pinMin > curMin)
                    this.pinMin = curMin;
                if (this.pinMax < curMax)
                    this.pinMax = curMax;
                this.num_min.Value = this.pinMin;
                this.num_max.Value = this.pinMax;
            }
        }

        private void SetCheckFalse(int checkColRowIndex)
        {
            for (int i = 0; i < this.radGridView1.RowCount; i++)
            {
                if (i != checkColRowIndex)
                {
                    this.radGridView1.Rows[i].Cells[2].Value = false;
                }
            }
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

        private void Btn_studyByInterface_Click(object sender, EventArgs e)
        {
            QueryContinuousGroupPoint(QueryInterPointByInterNo(false));
            if (this.selfParamList.Count == 0)
            {
                MessageBox.Show("未选择要学习的接口！","提示",MessageBoxButtons.OK);
                return;
            }
            this.Close();
            this.DialogResult = DialogResult.OK;
            this.studyTypeEnum = StudyTypeEnum.PartStudyByInterface;
        }

        private void QueryContinuousGroupPoint(List<int> pointList)
        {
            this.selfParamList.Clear();
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
            this.studyTypeEnum = StudyTypeEnum.PartStudyByInterface;
            CommitStudyByInterface();
        }

        private void Commit()
        {
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                var val = rowInfo.Cells[2].Value.ToString();
            }
        }

        private void CommitStudyByInterface()
        {
            if (this.num_max.Value == 0)
            {
                MessageBox.Show("学习范围无效！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.num_min.Value > this.num_max.Value)
            {
                MessageBox.Show("指定范围无效！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (this.curInterfaceName == "")
            {
                MessageBox.Show("请指定要学习的接口！", "提示", MessageBoxButtons.OK);
                return;
            }
            this.pinMax = GetDevicePointByID(this.curInterfaceName, (int)this.num_max.Value);
            this.pinMin = GetDevicePointByID(this.curInterfaceName, (int)this.num_min.Value);
            this.conductThresholdByPin = (float)this.conductionThresholdByPin.Value;
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private int GetDevicePointByID(string interName,int id)
        {
            var data = this.InterfaceInfoLibrary.GetDataSetByFieldsAndWhere("SwitchStandStitchNo", $"where InterfaceNo='{interName}' and ContactPoint='{id}'").Tables[0];
            return int.Parse(data.Rows[0][0].ToString());
        }

        private void QueryInterfaceLibrary()
        {
            var data = this.InterfaceInfoLibrary.GetDataSetByFieldsAndWhere("distinct InterfaceNo", "").Tables[0];
            if (data.Rows.Count <= 0)
                return;
            foreach (DataRow rowInfo in data.Rows)
            {
                if (IsExistRow(rowInfo[0].ToString()))
                    continue;
                this.radGridView1.Rows.AddNew();
                var iRow = this.radGridView1.RowCount;
                this.radGridView1.Rows[iRow - 1].Cells[0].Value = iRow;
                this.radGridView1.Rows[iRow - 1].Cells[1].Value = rowInfo[0].ToString();
                this.radGridView1.Rows[iRow - 1].Cells[2].Value = false;
            }
        }

        private bool IsExistRow(string InterNo)
        {
            if (this.radGridView1.RowCount <= 0)
                return false;
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                if (rowInfo.Cells[1].Value.ToString() == InterNo)
                    return true;
            }
            return false;
        }

        private List<int> QueryInterPointByInterNo(bool IsSectAll)
        {
            List<int> pointList = new List<int>();
            if (this.radGridView1.RowCount <= 0)
                return pointList;
            int count = 0;
            foreach (var rowInfo in this.radGridView1.Rows)
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
            if (startVal >= list[list.Count - 1])
                return;
            int i = startVal;
            frmSefStudy frmSef = new frmSefStudy();
            frmSef.pinMin = startVal;
            this.conductThresholdByPin = (float)this.conductionThresholdByPin.Value;
            frmSef.conductThresholdByPin = this.conductThresholdByPin;
            for (int j = startIndex;j < list.Count;j++)
            {
                if (list[j] != startVal)//存在不连续的点
                {
                    frmSef.pinMax = list[j - 1];
                    this.selfParamList.Add(frmSef);
                    GetContinuousPoint(list, j, list[j]);
                    return;
                }
                startVal++;
            }
            //不存在不连续的点
            frmSef.pinMax = startVal - 1;
            this.selfParamList.Add(frmSef);
        }
    }
}
