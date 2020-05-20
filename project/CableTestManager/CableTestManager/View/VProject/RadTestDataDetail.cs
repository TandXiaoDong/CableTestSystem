using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using WindowsFormTelerik.ControlCommon;
using WindowsFormTelerik.GridViewExportData;
using CableTestManager.Business;
using CableTestManager.Business.Implements;

namespace CableTestManager.View.VProject
{
    public partial class RadTestDataDetail : Telerik.WinControls.UI.RadForm
    {
        private string projectName;
        private string testNumber;
        private THistoryDataBasicManager historyDataInfoManager;
        private THistoryDataDetailManager historyDataDetailManager;
        public RadTestDataDetail(string projectName,string testNumber)
        {
            InitializeComponent();
            this.projectName = projectName;
            this.testNumber = testNumber;
            if(this.projectName != "")
                this.Text += "(" + this.projectName + ")";
        }

        private void RadTestDataDetail_Load(object sender, EventArgs e)
        {
            historyDataInfoManager = new THistoryDataBasicManager();
            historyDataDetailManager = new THistoryDataDetailManager();
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,true,13);
            QueryHistoryBasicInfo(false);

            this.menu_circuitTest.Click += Menu_circuitTest_Click;
            this.menu_close.Click += Menu_close_Click;
            this.menu_exportExcel.Click += Menu_exportExcel_Click;
            this.menu_insulateByGroundTest.Click += Menu_insulateByGroundTest_Click;
            this.menu_printReport.Click += Menu_printReport_Click;
            this.menu_toReport.Click += Menu_toReport_Click;
        }

        private void Menu_toReport_Click(object sender, EventArgs e)
        {
            
        }

        private void Menu_printReport_Click(object sender, EventArgs e)
        {
            
        }

        private void Menu_insulateByGroundTest_Click(object sender, EventArgs e)
        {
            
        }

        private void Menu_exportExcel_Click(object sender, EventArgs e)
        {
            
        }

        private void Menu_close_Click(object sender, EventArgs e)
        {
            
        }

        private void Menu_circuitTest_Click(object sender, EventArgs e)
        {
            
        }

        private void QueryHistoryBasicInfo(bool IsLike)
        {
            RadGridViewProperties.ClearGridView(this.radGridView1,null);
            var dt = historyDataInfoManager.GetDataSetByWhere($"where TestSerialNumber = '{this.testNumber}'").Tables[0];
            if (dt.Rows.Count < 1)
                return;
            //更新测试结果数据
            foreach (DataRow dr in dt.Rows)
            {
                this.lbx_TestResult.Text = dr["FinalTestResult"].ToString();
                this.lbx_bcCableName.Text = dr["TestCableName"].ToString();
                this.lbx_batchNumber.Text = dr["BatchNumber"].ToString();
                this.lbx_testDate.Text = dr["TestDate"].ToString();
                this.lbx_TestNumber.Text = dr["TestSerialNumber"].ToString();
                this.lbx_OperatorName.Text = dr["TestOperator"].ToString();
                this.lbx_testDevType.Text = dr["DeviceTypeNo"].ToString();
                this.lbx_measuringNumber.Text = dr["DeviceMeasureNumber"].ToString();
                this.lbx_EnvironmentTemperature.Text = dr["EnvironmentTemperature"].ToString();
                this.lbx_AmbientHumidity.Text = dr["EnvironmentAmbientHumidity"].ToString();
            }
            //更新测试参数
            TProjectBasicInfoManager projectInfoManager = new TProjectBasicInfoManager();
            if (this.projectName != "")
            {
                dt = projectInfoManager.GetDataSetByWhere($"where ProjectName = '{this.projectName}'").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        this.lbx_conductThreshold.Text = "≤" + dr["ConductTestThreshold"].ToString() + "Ω";
                        this.lbx_shortCircuitThreshold.Text = "≥" + dr["ShortCircuitTestThreshold"].ToString() + "Ω";
                        this.lbx_insulateThreshold.Text = "≥" + dr["InsulateTestThreshold"].ToString() + "MΩ";
                        this.lbx_insulateVoltage.Text = dr["InsulateTestVoltage"].ToString() + "VDC";
                        this.lbx_insulateTime.Text = dr["InsulateTestHoldTime"].ToString() + "s";
                        this.lbx_pressureProofThreshold.Text = "≤" + dr["VoltageWithStandardThreshold"].ToString() + "mA";
                        this.lbx_pressureProofTime.Text = dr["VoltageWithStandardHoldTime"].ToString() + "s";
                        this.lbx_pressureProofVoltage.Text = dr["VoltageWithStandardVoltage"].ToString() + "VAC";
                    }
                }
            }
            //更新测试数据详情
            if (this.testNumber == "")
                return;
            dt = historyDataDetailManager.GetDataSetByWhere($"where TestSerialNumber = '{this.testNumber}'").Tables[0];
            if (dt.Rows.Count < 1)
                return;
            foreach (DataRow dr in dt.Rows)
            {
                var sInter = dr["StartInterface"].ToString();
                var sPoint = dr["StartContactPoint"].ToString();
                var eInter = dr["EndInterface"].ToString();
                var ePoint = dr["EndContactPoint"].ToString();
                var conductValue = dr["ConductValue"].ToString();
                var conductResult = dr["ConductTestResult"].ToString();
                var shortCircuitValue = dr["ShortCircuitValue"].ToString();
                var shortCircuitTestResult = dr["ShortCircuitTestResult"].ToString();
                var insulateValue = dr["InsulateValue"].ToString();
                var insulateResult = dr["InsulateTestResult"].ToString();
                var pressureElectValue = dr["VoltageWithStandardValue"].ToString();
                var pressureResult = dr["VoltageWithStandardTestResult"].ToString();
                if (IsExistTestInfo(sInter, sPoint, eInter, ePoint))
                    continue;
                this.radGridView1.Rows.AddNew();
                var rCount = this.radGridView1.RowCount;
                this.radGridView1.Rows[rCount - 1].Cells[0].Value = rCount;
                this.radGridView1.Rows[rCount - 1].Cells[1].Value = sInter;
                this.radGridView1.Rows[rCount - 1].Cells[2].Value = sPoint;
                this.radGridView1.Rows[rCount - 1].Cells[3].Value = eInter;
                this.radGridView1.Rows[rCount - 1].Cells[4].Value = ePoint;
                this.radGridView1.Rows[rCount - 1].Cells[5].Value = conductValue;
                this.radGridView1.Rows[rCount - 1].Cells[6].Value = conductResult;
                this.radGridView1.Rows[rCount - 1].Cells[7].Value = insulateValue;
                this.radGridView1.Rows[rCount - 1].Cells[8].Value = insulateResult;
                this.radGridView1.Rows[rCount - 1].Cells[9].Value = pressureElectValue;
                this.radGridView1.Rows[rCount - 1].Cells[10].Value = pressureResult;
            }
        }

        private bool IsExistTestInfo(string startInter,string startPoint,string endInter,string endPoint)
        {
            if (this.radGridView1.RowCount < 1)
                return false;
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                var sInter = rowInfo.Cells[1].Value.ToString();
                var sPoint = rowInfo.Cells[2].Value.ToString();
                var eInter = rowInfo.Cells[3].Value.ToString();
                var ePoint = rowInfo.Cells[4].Value.ToString();
                if (sInter == startInter && sPoint == startPoint && eInter == endInter && ePoint == endPoint)
                    return true;
            }
            return false;
        }
    }
}
