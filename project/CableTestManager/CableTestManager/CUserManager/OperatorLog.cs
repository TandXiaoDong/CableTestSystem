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

namespace CableTestManager.CUserManager
{
    public partial class OperatorLog : Telerik.WinControls.UI.RadForm
    {
        private TOperateRecordManager operationRecordManager;
        public OperatorLog()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

            this.dateTimePickerStartTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.datePickerEndTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,false,4);
            operationRecordManager = new TOperateRecordManager();
            InitFuncState();

            this.tool_query.Click += Tool_query_Click;
            this.tool_likeQuery.Click += Tool_likeQuery_Click;
            this.tool_export.Click += Tool_export_Click;
            this.tool_deleteSignalData.Click += Tool_deleteSignalData_Click;
            this.tool_deleteAllData.Click += Tool_deleteAllData_Click;
        }

        private void InitFuncState()
        {
            OperatLimitManager operatLimitManager = new OperatLimitManager();
            var data = operatLimitManager.GetDataSetByWhere($"where UserRole='{LocalLogin.currentUserType}'").Tables[0];
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    this.tool_query.Visible = ConvertDec2State(dr["OperatorRecord_query"].ToString());
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
        }

        private void Tool_deleteAllData_Click(object sender, EventArgs e)
        {
        }


        private void Tool_export_Click(object sender, EventArgs e)
        {
        }

        private void Tool_likeQuery_Click(object sender, EventArgs e)
        {
            QueryOperateData(true);
        }

        private void Tool_query_Click(object sender, EventArgs e)
        {
            QueryOperateData(false);
        }

        private void QueryOperateData(bool IsPartCondition)
        {
            var queryStr = "";
            var startTime = this.dateTimePickerStartTime.Text;
            var endTime = this.datePickerEndTime.Text;
            if (IsPartCondition)
                queryStr = $"where OperateUser like '%{this.tb_queryCondition.Text.Trim()}%' and OperateDate >= '{startTime}' and OperateDate <= '{endTime}'";
            else
                queryStr = $"where OperateUser = '{this.tb_queryCondition.Text.Trim()}' and OperateDate >= '{startTime}' and OperateDate <= '{endTime}'";
            var dt = operationRecordManager.GetDataSetByWhere(queryStr).Tables[0];
            RadGridViewProperties.ClearGridView(this.radGridView1,null);
            foreach (DataRow dr in dt.Rows)
            {
                this.radGridView1.Rows.AddNew();
                var rowCount = this.radGridView1.RowCount;
                this.radGridView1.Rows[rowCount - 1].Cells[0].Value = rowCount;
                this.radGridView1.Rows[rowCount - 1].Cells[1].Value = dr["OperateUser"].ToString();
                this.radGridView1.Rows[rowCount - 1].Cells[2].Value = dr["OperationContent"].ToString();
                this.radGridView1.Rows[rowCount - 1].Cells[3].Value = dr["OperateDate"].ToString();
            }
        }
    }
}
