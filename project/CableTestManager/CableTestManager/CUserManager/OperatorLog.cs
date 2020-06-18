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
using CableTestManager.Entity;
using WindowsFormTelerik.ControlCommon;
using WindowsFormTelerik.GridViewExportData;

namespace CableTestManager.CUserManager
{
    public partial class OperatorLog : Telerik.WinControls.UI.RadForm
    {
        private TOperateRecordManager operationRecordManager;
        public OperatorLog()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

            this.dateTimePickerStartTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            this.datePickerEndTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,false,4);
            operationRecordManager = new TOperateRecordManager();
            InitFuncState();
            QueryOperateData();

            this.tool_likeQuery.Click += Tool_likeQuery_Click;
            this.tool_export.Click += Tool_export_Click;
            this.tool_deleteSignalData.Click += Tool_deleteSignalData_Click;
            this.tool_deleteAllData.Click += Tool_deleteAllData_Click;
            this.tb_queryCondition.TextChanged += Tb_queryCondition_TextChanged;
        }

        private void Tb_queryCondition_TextChanged(object sender, EventArgs e)
        {
            QueryOperateData();
        }

        private void InitFuncState()
        {
            OperatLimitManager operatLimitManager = new OperatLimitManager();
            var data = operatLimitManager.GetDataSetByWhere($"where UserRole='{LocalLogin.currentUserType}'").Tables[0];
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    this.tool_likeQuery.Visible = ConvertDec2State(dr["OperatorRecord_query"].ToString());
                    this.tool_deleteSignalData.Visible = ConvertDec2State(dr["OperatorRecord_del"].ToString());
                    this.tool_deleteAllData.Visible = ConvertDec2State(dr["OperatorRecord_del"].ToString());
                    this.tool_export.Visible = ConvertDec2State(dr["OperatorRecord_export"].ToString());
                }
            }
        }

        private bool ConvertDec2State(string val)
        {
            if (val == "1")
                return true;
            else
                return false;
        }

        private void Tool_deleteSignalData_Click(object sender, EventArgs e)
        {
            var b =RadGridViewProperties.IsSelectRow(this.radGridView1);
            if (!b)
            {
                MessageBox.Show("请选择要删除的记录！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            var operateDate = this.radGridView1.CurrentRow.Cells[3].Value;
            if (MessageBox.Show("确认要删除本条记录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }
            if (operateDate != null)
            {
                operationRecordManager.DeleteByWhere($"where OperateDate='{operateDate}'");
            }
            QueryOperateData();
        }

        private void Tool_deleteAllData_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认要删除所有记录？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                var operateDate = rowInfo.Cells[3].Value;
                if (operateDate != null)
                {
                    operationRecordManager.DeleteByWhere($"where OperateDate='{operateDate}'");
                }
            }
            QueryOperateData();
        }


        private void Tool_export_Click(object sender, EventArgs e)
        {
            GridViewExport.ExportGridViewData(GridViewExport.ExportFormat.EXCEL, this.radGridView1);
        }

        private void Tool_likeQuery_Click(object sender, EventArgs e)
        {
            QueryOperateData();
        }

        private void Tool_query_Click(object sender, EventArgs e)
        {
            QueryOperateData();
        }

        private void QueryOperateData()
        {
            var queryStr = "";
            var startTime = this.dateTimePickerStartTime.Text;
            var endTime = this.datePickerEndTime.Text;
            if (this.tb_queryCondition.Text.Trim() != "")
            {
                queryStr = $"where OperateUser like '%{this.tb_queryCondition.Text.Trim()}%' and OperateDate >= '{startTime}' and OperateDate <= '{endTime}'";
            }
            else
            {
                queryStr = $"where OperateDate >= '{startTime}' and OperateDate <= '{endTime}'";
            }
            var dt = operationRecordManager.GetDataSetByWhere(queryStr).Tables[0];
            RadGridViewProperties.ClearGridView(this.radGridView1,null);
            foreach (DataRow dr in dt.Rows)
            {
                this.radGridView1.Rows.AddNew();
                var rowCount = this.radGridView1.RowCount;
                this.radGridView1.Rows[rowCount - 1].Cells[0].Value = rowCount;
                this.radGridView1.Rows[rowCount - 1].Cells[1].Value = dr["OperateUser"].ToString();
                this.radGridView1.Rows[rowCount - 1].Cells[2].Value = dr["OperateContent"].ToString();
                this.radGridView1.Rows[rowCount - 1].Cells[3].Value = dr["OperateDate"].ToString();
            }
        }
    }
}
