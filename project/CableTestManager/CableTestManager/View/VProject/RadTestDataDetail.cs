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
using CableTestManager.Common;
using CableTestManager.Model;

namespace CableTestManager.View.VProject
{
    public partial class RadTestDataDetail : Telerik.WinControls.UI.RadForm
    {
        private string testNumber;
        private string exportPath;
        private THistoryDataBasicManager historyDataInfoManager;
        private THistoryDataDetailManager historyDataDetailManager;
        private DeviceConfig dConfig;
        public RadTestDataDetail(string testNumber, string path, DeviceConfig config)
        {
            InitializeComponent();
            this.testNumber = testNumber;
            this.exportPath = path;
            this.dConfig = config;
        }

        private void RadTestDataDetail_Load(object sender, EventArgs e)
        {
            historyDataInfoManager = new THistoryDataBasicManager();
            historyDataDetailManager = new THistoryDataDetailManager();
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,true,this.radGridView1.ColumnCount);
            QueryHistoryBasicInfo(false);

            this.menu_close.Click += Menu_close_Click;
            this.menu_exportExcel.Click += Menu_exportExcel_Click;
            this.menu_printReport.Click += Menu_printReport_Click;
            this.menu_toReport.Click += Menu_toReport_Click;
        }

        private void Menu_toReport_Click(object sender, EventArgs e)
        {
            TestReportInfo.ExportReport(this.exportPath, this.testNumber, this.dConfig);
        }

        private void Menu_printReport_Click(object sender, EventArgs e)
        {
            TestReportInfo.PrintReport(this.exportPath, this.testNumber, this.dConfig);
        }

        private void Menu_insulateByGroundTest_Click(object sender, EventArgs e)
        {
            
        }

        private void Menu_exportExcel_Click(object sender, EventArgs e)
        {
            GridViewExport.ExportGridViewData(GridViewExport.ExportFormat.EXCEL, this.radGridView1);
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
            var hisBasicInfo = TestHisBasicInfo.QueryProTestHisBasicInfo(this.testNumber);
            this.lbx_TestResult.Text = hisBasicInfo.FinalTestResult;
            this.lbx_bcCableName.Text = hisBasicInfo.TestCableName;
            this.lbx_testDate.Text = hisBasicInfo.TestStartDate;
            this.lbx_TestNumber.Text = hisBasicInfo.TestSerialNumber;
            this.lbx_OperatorName.Text = hisBasicInfo.TestOperator;
            this.lbx_EnvironmentTemperature.Text = hisBasicInfo.EnvironmentTemperature;
            this.lbx_AmbientHumidity.Text = hisBasicInfo.EnvironmentAmbientHumidity;
            this.lbx_conductResult.Text = hisBasicInfo.ConductTestResult;
            this.lbx_circuitResult.Text = hisBasicInfo.ShortCircuitTestResult;
            this.lbx_insulateResult.Text = hisBasicInfo.InsulateTestResult;
            if (hisBasicInfo.ProjectName != "")
                this.Text += "(" + hisBasicInfo.ProjectName + ")";

            //更新测试参数
            this.lbx_conductThreshold.Text = "≤" + hisBasicInfo.ConductThreshold + "Ω";
            this.lbx_shortCircuitThreshold.Text = "≥" + hisBasicInfo.ShortCircuitThreshold + "Ω";
            this.lbx_insulateThreshold.Text = "≥" + hisBasicInfo.InsulateThreshold + "Ω";
            this.lbx_insulateVoltage.Text = hisBasicInfo.InsulateVoltage + "V";
            this.lbx_insulateTime.Text = hisBasicInfo.InsulateHoldTime + "s";
            //this.lbx_pressureProofThreshold.Text = "≤" + dr["VoltageWithStandardThreshold"].ToString() + "mA";
            //this.lbx_pressureProofTime.Text = dr["VoltageWithStandardHoldTime"].ToString() + "s";
            //this.lbx_pressureProofVoltage.Text = dr["VoltageWithStandardVoltage"].ToString() + "VAC";

            //更新测试数据详情
            if (this.testNumber == "")
                return;
            var dt = historyDataDetailManager.GetDataSetByWhere($"where TestSerialNumber = '{this.testNumber}'").Tables[0];
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
                this.radGridView1.Rows[rCount - 1].Cells[7].Value = shortCircuitValue;
                this.radGridView1.Rows[rCount - 1].Cells[8].Value = shortCircuitTestResult;
                this.radGridView1.Rows[rCount - 1].Cells[9].Value = insulateValue;
                this.radGridView1.Rows[rCount - 1].Cells[10].Value = insulateResult;
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
