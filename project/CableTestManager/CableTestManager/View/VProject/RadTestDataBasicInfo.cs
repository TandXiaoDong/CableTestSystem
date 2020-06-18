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
        private string exportPath;

        public RadTestDataBasicInfo(string path)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.exportPath = path;
        }

        private void RadTestDataBasicInfo_Load(object sender, EventArgs e)
        {
            historyDataInfoManager = new THistoryDataBasicManager();
            historyDataDetailManager = new THistoryDataDetailManager();

            this.dateTimePicker_start.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.dateTimePicker_end.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1, false,true,this.radGridView1.ColumnCount);
            QueryHistoryBasicInfo();
            InitFuncState();

            this.tb_queryFilter.TextChanged += Tb_queryFilter_TextChanged;
            this.menu_close.Click += Menu_close_Click;
            this.menu_detail.Click += Menu_detail_Click;
            this.menu_likeQuery.Click += Menu_likeQuery_Click;
            this.menu_export.Click += Menu_export_Click;
            this.menu_deleteData.Click += Menu_deleteData_Click;
        }

        private void Tb_queryFilter_TextChanged(object sender, EventArgs e)
        {
            QueryHistoryBasicInfo();
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
                    //this.menu_eqlQuery.Visibility = ConvertDec2EleVisState(dr["HistoryTestData_query"].ToString());
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
            var b = RadGridViewProperties.IsSelectRow(this.radGridView1);
            if (!b)
            {
                MessageBox.Show("请选择要删除的测试序列！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var testNumber = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            if (MessageBox.Show($"确认要删除测试序列{testNumber}的数据？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return;
            }
            var delRow = historyDataInfoManager.DeleteByWhere($"where TestSerialNumber = '{testNumber}'");
            delRow += historyDataDetailManager.DeleteByWhere($"where TestSerialNumber = '{testNumber}'");
            if (delRow > 0)
            {
                UserOperateRecord.UpdateOperateRecord($"删除历史数据-删除测试序列{testNumber}");
                MessageBox.Show("删除数据完成！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            QueryHistoryBasicInfo();
        }

        private void Menu_export_Click(object sender, EventArgs e)
        {
            GridViewExport.ExportGridViewData(GridViewExport.ExportFormat.EXCEL,this.radGridView1);
        }

        private void Menu_likeQuery_Click(object sender, EventArgs e)
        {
            QueryHistoryBasicInfo();
        }

        private void Menu_eqlQuery_Click(object sender, EventArgs e)
        {
            QueryHistoryBasicInfo();
        }

        private void Menu_detail_Click(object sender, EventArgs e)
        {
            var b = RadGridViewProperties.IsSelectRow(this.radGridView1);
            if (!b)
            {
                MessageBox.Show("请选择要查看明细的项目！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            var testSerial = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            RadTestDataDetail testDataDetail = new RadTestDataDetail(testSerial, this.exportPath);
            testDataDetail.ShowDialog();
        }

        private void Menu_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QueryHistoryBasicInfo()
        {
            RadGridViewProperties.ClearGridView(this.radGridView1,null);
            var where = "";
            if (this.tb_queryFilter.Text.Trim() != "")
            {
                where = $"where ProjectName like '%{this.tb_queryFilter.Text}%' and TestStartDate >= '{this.dateTimePicker_start.Text}' and TestStartDate <= '{this.dateTimePicker_end.Text}'";
            }
            else
            {
                where = $"where TestStartDate >= '{this.dateTimePicker_start.Text}' and TestStartDate <= '{this.dateTimePicker_end.Text}'";
            }
            var dt = historyDataInfoManager.GetDataSetByWhere(where).Tables[0];
            if (dt.Rows.Count < 1)
                return;
            foreach (DataRow dr in dt.Rows)
            {
                var testSerial = dr["TestSerialNumber"].ToString();
                var projectName = dr["ProjectName"].ToString();
                var testCableName = dr["TestCableName"].ToString();
                var testTime = dr["TestStartDate"].ToString();
                var tester = dr["TestOperator"].ToString();
                var testResult = dr["FinalTestResult"].ToString();
                if (IsExistTestProject(testSerial))
                    continue;
                this.radGridView1.Rows.AddNew();
                var rCount = this.radGridView1.RowCount;
                this.radGridView1.Rows[rCount - 1].Cells[0].Value = rCount;
                this.radGridView1.Rows[rCount - 1].Cells[1].Value = testSerial;
                this.radGridView1.Rows[rCount - 1].Cells[2].Value = projectName;
                this.radGridView1.Rows[rCount - 1].Cells[3].Value = testCableName;
                this.radGridView1.Rows[rCount - 1].Cells[4].Value = testTime;
                this.radGridView1.Rows[rCount - 1].Cells[5].Value = tester;
                this.radGridView1.Rows[rCount - 1].Cells[6].Value = testResult;
            }
        }

        private bool IsExistTestProject(string testNumber)
        {
            if (this.radGridView1.RowCount < 1)
                return false;
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                if (rowInfo.Cells[1].Value.ToString() == testNumber)
                    return true;
            }
            return false;
        }
    }
}
