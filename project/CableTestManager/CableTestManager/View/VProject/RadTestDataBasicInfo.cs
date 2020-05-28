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
using CableTestManager.Business.Implements;
using CableTestManager.CUserManager;
using CableTestManager.Common;

namespace CableTestManager.View.VProject
{
    public partial class RadTestDataBasicInfo : Telerik.WinControls.UI.RadForm
    {
        private THistoryDataBasicManager historyDataInfoManager;
        private THistoryDataDetailManager historyDataDetailManager;

        public RadTestDataBasicInfo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void RadTestDataBasicInfo_Load(object sender, EventArgs e)
        {
            historyDataInfoManager = new THistoryDataBasicManager();
            historyDataDetailManager = new THistoryDataDetailManager();

            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1, false,true,7);
            QueryHistoryBasicInfo(true);
            InitFuncState();

            this.menu_close.Click += Menu_close_Click;
            this.menu_detail.Click += Menu_detail_Click;
            this.menu_eqlQuery.Click += Menu_eqlQuery_Click;
            this.menu_likeQuery.Click += Menu_likeQuery_Click;
            this.menu_export.Click += Menu_export_Click;
            this.menu_deleteData.Click += Menu_deleteData_Click;
        }

        private void InitFuncState()
        {
            OperatLimitManager operatLimitManager = new OperatLimitManager();
            var data = operatLimitManager.GetDataSetByWhere($"where UserRole='{LocalLogin.currentUserType}'").Tables[0];
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    this.menu_deleteData.Visibility = ConvertDec2EleVisState(dr["Project_del"].ToString());
                    this.menu_eqlQuery.Visibility = ConvertDec2EleVisState(dr["HistoryTestData_query"].ToString());
                    this.menu_likeQuery.Visibility = ConvertDec2EleVisState(dr["HistoryTestData_query"].ToString());
                    this.menu_detail.Visibility = ConvertDec2EleVisState(dr["HistoryTestData_query"].ToString());
                    this.menu_export.Visibility = ConvertDec2EleVisState(dr["HistoryTestData_export"].ToString());
                }
            }
        }

        private ElementVisibility ConvertDec2EleVisState(string val)
        {
            if (val == "1")
                return ElementVisibility.Visible;
            else
                return ElementVisibility.Collapsed;
        }

        private void Menu_deleteData_Click(object sender, EventArgs e)
        {
            var selectProjectIndex = this.radGridView1.CurrentRow.Index;
            if (selectProjectIndex < 0)
            {
                MessageBox.Show("请选择要删除的项目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var currentProject = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            var delRow = historyDataInfoManager.DeleteByWhere($"where ProjectName = '{currentProject}'");
            delRow += historyDataDetailManager.DeleteByWhere($"where ProjectName = '{currentProject}'");
            if (delRow > 0)
            {
                UserOperateRecord.UpdateOperateRecord($"删除历史数据-删除项目{currentProject}");
                MessageBox.Show("删除数据完成！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void Menu_export_Click(object sender, EventArgs e)
        {
            GridViewExport.ExportGridViewData(GridViewExport.ExportFormat.EXCEL,this.radGridView1);
        }

        private void Menu_likeQuery_Click(object sender, EventArgs e)
        {
            QueryHistoryBasicInfo(true);
        }

        private void Menu_eqlQuery_Click(object sender, EventArgs e)
        {
            QueryHistoryBasicInfo(false);
        }

        private void Menu_detail_Click(object sender, EventArgs e)
        {
            var selectProjectIndex = this.radGridView1.CurrentRow.Index;
            if (selectProjectIndex < 0)
            {
                MessageBox.Show("请选择要查看明细的项目！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            var currentProject = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            var testTime = this.radGridView1.CurrentRow.Cells[4].Value.ToString();
            var dt = historyDataInfoManager.GetDataSetByFieldsAndWhere("TestSerialNumber", $"where ProjectName = '{currentProject}' and TestDate = '{testTime}'").Tables[0];
            if (dt.Rows.Count < 1)
                return;
            var testNumber = dt.Rows[0][0].ToString();
            RadTestDataDetail testDataDetail = new RadTestDataDetail(currentProject, testNumber);
            testDataDetail.ShowDialog();
        }

        private void Menu_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QueryHistoryBasicInfo(bool IsLike)
        {
            RadGridViewProperties.ClearGridView(this.radGridView1,null);
            var selectSQL = "";
            var fields = "ProjectName,TestCableName,BatchNumber,TestDate,TestOperator,FinalTestResult";
            if (this.tb_queryFilter.Text.Trim() != "")
            {
                if (IsLike)
                    selectSQL = $"where ProjectName like '%{this.tb_queryFilter.Text}%' and TestDate >= '{this.dateTimePicker_start.Text}' and TestDate <= '{this.dateTimePicker_end.Text}'";
                else
                    selectSQL = $"where ProjectName = '{this.tb_queryFilter.Text}' and TestDate >= '{this.dateTimePicker_start.Text}' and TestDate <= '{this.dateTimePicker_end.Text}'";
            }
            var dt = historyDataInfoManager.GetDataSetByFieldsAndWhere(fields, selectSQL).Tables[0];
            if (dt.Rows.Count < 1)
            {
                if (IsLike)
                    selectSQL = $"where TestCableName like '%{this.tb_queryFilter.Text}%' and TestDate >= '{this.dateTimePicker_start.Text}' and TestDate <= '{this.dateTimePicker_end.Text}'";
                else
                    selectSQL = $"where TestCableName = '{this.tb_queryFilter.Text}' and TestDate >= '{this.dateTimePicker_start.Text}' and TestDate <= '{this.dateTimePicker_end.Text}'";

                dt = historyDataInfoManager.GetDataSetByFieldsAndWhere(fields,selectSQL).Tables[0];
                if (dt.Rows.Count < 1)
                {
                    if(IsLike)
                        selectSQL = $"where BatchNumber like '%{this.tb_queryFilter.Text}%' and TestDate >= '{this.dateTimePicker_start.Text}' and TestDate <= '{this.dateTimePicker_end.Text}'";
                    else
                        selectSQL = $"where BatchNumber = '{this.tb_queryFilter.Text}' and TestDate >= '{this.dateTimePicker_start.Text}' and TestDate <= '{this.dateTimePicker_end.Text}'";
                    dt = historyDataInfoManager.GetDataSetByFieldsAndWhere(fields,selectSQL).Tables[0];
                }
            }
            if (dt.Rows.Count < 1)
                return;
            foreach (DataRow dr in dt.Rows)
            {
                var projectName = dr["ProjectName"].ToString();
                var testCableName = dr["TestCableName"].ToString();
                var batchNumber = dr["BatchNumber"].ToString();
                var testTime = dr["TestDate"].ToString();
                var tester = dr["TestOperator"].ToString();
                var testResult = dr["FinalTestResult"].ToString();
                if (IsExistTestProject(testTime))
                    continue;
                this.radGridView1.Rows.AddNew();
                var rCount = this.radGridView1.RowCount;
                this.radGridView1.Rows[rCount - 1].Cells[0].Value = rCount;
                this.radGridView1.Rows[rCount - 1].Cells[1].Value = projectName;
                this.radGridView1.Rows[rCount - 1].Cells[2].Value = testCableName;
                this.radGridView1.Rows[rCount - 1].Cells[3].Value = batchNumber;
                this.radGridView1.Rows[rCount - 1].Cells[4].Value = testTime;
                this.radGridView1.Rows[rCount - 1].Cells[5].Value = tester;
                this.radGridView1.Rows[rCount - 1].Cells[6].Value = testResult;
            }
        }

        private bool IsExistTestProject(string testTime)
        {
            if (this.radGridView1.RowCount < 1)
                return false;
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                if (rowInfo.Cells[4].Value.ToString() == testTime)
                    return true;
            }
            return false;
        }
    }
}
