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

namespace CableTestManager.View.VSelfStydy
{
    public partial class frmSefStudy : Telerik.WinControls.UI.RadForm
    {
        public int pinMin;
        public int pinMax;
        public float conductThresholdByPin;
        public List<frmSefStudy> selfParamList;
        public StudyTypeEnum studyTypeEnum;
        private InterfaceInfoLibraryManager InterfaceInfoLibrary;
        private TCableTestLibraryManager cableTestLibraryManager = new TCableTestLibraryManager();
        public List<SelfStudyTestParams> studyTestParamsList = new List<SelfStudyTestParams>();

        public enum StudyTypeEnum
        {
            PartStudyByPin,
            AllStudyByPin,
            PartStudyByInterface,
            AllStudyByInterface,
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
            this.num_min.Minimum = 0;
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
            this.radGridView1.CellClick += RadGridView1_CellClick;
            this.radGridView1.CellValueChanged += RadGridView1_CellValueChanged;
        }

        private void RadGridView1_CellValueChanged(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2)
                return;
            var currentCell = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (currentCell == "True" || currentCell == "1")
            {
                var data = this.cableTestLibraryManager.GetAllDataSet().Tables[0];
                if (data.Rows.Count > 0)
                {
                    foreach (DataRow dr in data.Rows)
                    {
                        AddSelfStudyTestParams(dr["StartInterface"].ToString(), dr["StartContactPoint"].ToString(), dr["StartDevPoint"].ToString());
                        AddSelfStudyTestParams(dr["EndInterface"].ToString(), dr["EndContactPoint"].ToString(), dr["EndDevPoint"].ToString());
                    }
                    this.num_max.Value = this.studyTestParamsList[this.studyTestParamsList.Count - 1].StudyPoint;
                    this.num_min.Value = this.studyTestParamsList[0].StudyPoint;
                }
            }
        }

        private void RadGridView1_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                var currentCell = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (currentCell == "1" || currentCell == "True")
                {
                    this.radGridView1.Rows[e.RowIndex].Cells[2].Value = false;
                }
                else if (currentCell == "0" || currentCell == "False")
                {
                    this.radGridView1.Rows[e.RowIndex].Cells[2].Value = true;
                }
            }
        }

        private void RadGridView1_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
           
        }

        private void AddSelfStudyTestParams(string interfaceName, string contactPoint, string devPoint)
        {
            SelfStudyTestParams selfStudyTest = new SelfStudyTestParams();
            int cpoint;
            int dpoint;
            int.TryParse(contactPoint, out cpoint);
            int.TryParse(contactPoint, out dpoint);
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

        private void Btn_studyAllByInterface_Click(object sender, EventArgs e)
        {
            QueryContinuousGroupPoint(QueryInterPointByInterNo(true));
            this.Close();
            this.DialogResult = DialogResult.OK;
            this.studyTypeEnum = StudyTypeEnum.AllStudyByInterface;
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

        private void Btn_allStudyByPin_Click(object sender, EventArgs e)
        {
            this.pinMax = 1024;
            this.pinMin = 1;
            this.conductThresholdByPin = (float)this.conductionThresholdByPin.Value;
            this.Close();
            this.DialogResult = DialogResult.OK;
            this.studyTypeEnum = StudyTypeEnum.AllStudyByPin;
        }

        private void Btn_defineStudyByPin_Click(object sender, EventArgs e)
        {
            if (this.num_max.Value == 0)
            {
                MessageBox.Show("学习范围无效！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (this.num_min.Value > this.num_max.Value)
            {
                MessageBox.Show("指定范围无效！","提示",MessageBoxButtons.OK);
                return;
            }
            this.pinMax = (int)this.num_max.Value;
            this.pinMin = (int)this.num_min.Value;
            this.conductThresholdByPin = (float)this.conductionThresholdByPin.Value;
            this.Close();
            this.DialogResult = DialogResult.OK;
            this.studyTypeEnum = StudyTypeEnum.PartStudyByPin;
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
