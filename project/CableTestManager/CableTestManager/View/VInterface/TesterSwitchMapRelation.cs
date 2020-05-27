using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using WindowsFormTelerik.ControlCommon;
using CableTestManager.Business;
using CableTestManager.Business.Implements;
using CableTestManager.Entity;
using WindowsFormTelerik.GridViewExportData;
using CableTestManager.CUserManager;

namespace CableTestManager.View.VInterface
{
    public partial class TesterSwitchMapRelation : Telerik.WinControls.UI.RadForm
    {
        private TesterAndSwitchStandMapRelationManager switchWorkWearMapRelationManager;
             
        public TesterSwitchMapRelation()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,true,3);
            switchWorkWearMapRelationManager = new TesterAndSwitchStandMapRelationManager();
            QueryRelationInfo();
            InitFuncState();

            this.tool_query.Click += Tool_query_Click;
            this.tool_edit.Click += Tool_edit_Click;
            this.tool_delete.Click += Tool_delete_Click;
            this.tool_export.Click += Tool_export_Click;
            this.btn_apply.Click += Btn_apply_Click;
            this.btn_cancel.Click += Btn_cancel_Click;
        }

        private void InitFuncState()
        {
            OperatLimitManager operatLimitManager = new OperatLimitManager();
            var data = operatLimitManager.GetDataSetByWhere($"where UserRole='{LocalLogin.currentUserType}'").Tables[0];
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    this.tool_query.Visible = ConvertDec2State(dr["SwitchStandLib_query"].ToString());
                    this.tool_add.Visible = ConvertDec2State(dr["SwitchStandLib_add"].ToString());
                    this.tool_delete.Visible = ConvertDec2State(dr["SwitchStandLib_del"].ToString());
                    this.tool_edit.Visible = ConvertDec2State(dr["SwitchStandLib_edit"].ToString());
                    this.tool_export.Visible = ConvertDec2State(dr["SwitchStandLib_export"].ToString());
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

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_apply_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tool_export_Click(object sender, EventArgs e)
        {
            GridViewExport.ExportGridViewData(GridViewExport.ExportFormat.EXCEL, this.radGridView1);
        }

        private void Tool_delete_Click(object sender, EventArgs e)
        {
            
        }

        private void Tool_edit_Click(object sender, EventArgs e)
        {
            
        }

        private void Tool_query_Click(object sender, EventArgs e)
        {
            QueryRelationInfo();
        }

        private void QueryRelationInfo()
        {
            var dt = switchWorkWearMapRelationManager.GetAllDataSet().Tables[0];
            if (dt.Rows.Count < 1)
                return;
            foreach (DataRow dr in dt.Rows)
            {
                var testerPin = dr["TesterStitchNo"].ToString();
                var switcherPin = dr["SwitchStandStitchNo"].ToString();
                if (IsExistSwitcherPin(switcherPin))
                    continue;
                this.radGridView1.Rows.AddNew();
                var rCount = this.radGridView1.RowCount;
                this.radGridView1.Rows[rCount - 1].Cells[0].Value = rCount;
                this.radGridView1.Rows[rCount - 1].Cells[1].Value = testerPin;
                this.radGridView1.Rows[rCount - 1].Cells[2].Value = switcherPin;
            }
        }

        private bool IsExistSwitcherPin(string switchPin)
        {
            if (this.radGridView1.RowCount < 1)
                return false;
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                if (switchPin == rowInfo.Cells[2].Value.ToString())
                    return true;
            }
            return false;
        }
    }
}
