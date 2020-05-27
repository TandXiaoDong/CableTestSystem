using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using CableTestManager.Business;
using CableTestManager.Business.Implements;
using CableTestManager.Entity;
using WindowsFormTelerik.ControlCommon;
using WindowsFormTelerik.GridViewExportData;
using CableTestManager.CUserManager;
using CableTestManager.Common;

namespace CableTestManager.View.VInterface
{
    public partial class RadConnectorLibrary : Telerik.WinControls.UI.RadForm
    {
        private TConnectorLibraryManager connectorLibraryManager;
        private TConnectorLibraryDetailManager connectorLibraryDetailManager;
        public RadConnectorLibrary()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,true,5);
            connectorLibraryManager = new TConnectorLibraryManager();
            connectorLibraryDetailManager = new TConnectorLibraryDetailManager();
            InitFuncState();

            this.tool_add.Click += Tool_add_Click;
            this.tool_delete.Click += Tool_delete_Click;
            this.tool_query.Click += Tool_query_Click;
            this.tool_edit.Click += Tool_edit_Click;
            this.tool_export.Click += Tool_export_Click;
        }

        private void InitFuncState()
        {
            OperatLimitManager operatLimitManager = new OperatLimitManager();
            var data = operatLimitManager.GetDataSetByWhere($"where UserRole='{LocalLogin.currentUserType}'").Tables[0];
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    this.tool_query.Visible = ConvertDec2State(dr["ConnectorLib_query"].ToString());
                    this.tool_add.Visible = ConvertDec2State(dr["ConnectorLib_add"].ToString());
                    this.tool_delete.Visible = ConvertDec2State(dr["ConnectorLib_del"].ToString());
                    this.tool_edit.Visible = ConvertDec2State(dr["ConnectorLib_edit"].ToString());
                    this.tool_export.Visible = ConvertDec2State(dr["ConnectorLib_export"].ToString());
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

        private void Tool_export_Click(object sender, EventArgs e)
        {
            GridViewExport.ExportGridViewData(GridViewExport.ExportFormat.EXCEL, this.radGridView1);
        }

        private void Tool_edit_Click(object sender, EventArgs e)
        {
            int rowIndex = this.radGridView1.CurrentRow.Index;
            if (rowIndex < 0)
                return;
            var connectorType = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            var switchType = this.radGridView1.CurrentRow.Cells[2].Value.ToString();
            var remark = this.radGridView1.CurrentRow.Cells[4].Value.ToString();

            AddConnector addConnector = new AddConnector("编辑连接器",true,connectorType,switchType,remark);
            if (addConnector.ShowDialog() == DialogResult.OK)
            {
                QueryConnectorInfo();
            }
        }

        private void Tool_query_Click(object sender, EventArgs e)
        {
            QueryConnectorInfo();
        }

        private void Tool_delete_Click(object sender, EventArgs e)
        {
            int rowIndex = this.radGridView1.CurrentRow.Index;
            if (rowIndex < 0)
                return;
            var connectorType = this.radGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            var delRow = connectorLibraryManager.DeleteByWhere($"ConnectorName = '{connectorType}'");
            if (delRow > 0)
            {
                delRow = connectorLibraryDetailManager.DeleteByWhere($"ConnectorName = '{connectorType}'");
                UserOperateRecord.UpdateOperateRecord($"删除连接器库{connectorType}");
                MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                
            }
        }

        private void Tool_add_Click(object sender, EventArgs e)
        {
            AddConnector addConnector = new AddConnector("添加连接器",false,"","","");
            if (addConnector.ShowDialog() == DialogResult.OK)
            {
                QueryConnectorInfo();
                UserOperateRecord.UpdateOperateRecord($"添加连接器库");
            }
        }

        private void QueryConnectorInfo()
        {
            var dt = connectorLibraryManager.GetAllDataSet().Tables[0];
            if (dt.Rows.Count < 1)
                return;
            foreach (DataRow dr in dt.Rows)
            {
                var connectorType = dr["ConnectorName"].ToString();
                var switchType = dr["ConverterType"].ToString();
                var remark = dr["Remark"].ToString();
                if (IsExistConnector(connectorType))
                    continue;
                this.radGridView1.Rows.AddNew();
                var rowCount = this.radGridView1.RowCount;
                this.radGridView1.Rows[rowCount - 1].Cells[0].Value = rowCount;
                this.radGridView1.Rows[rowCount - 1].Cells[1].Value = connectorType;
                this.radGridView1.Rows[rowCount - 1].Cells[2].Value = switchType;
                this.radGridView1.Rows[rowCount - 1].Cells[3].Value = GetPinNum(connectorType);
                this.radGridView1.Rows[rowCount - 1].Cells[4].Value = remark;
            }
        }

        private bool IsExistConnector(string connectorType)
        {
            if (this.radGridView1.RowCount < 1)
                return false;
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                var type = rowInfo.Cells[1].Value.ToString();
                if (connectorType == type)
                    return true;
            }
            return false;
        }

        private int GetPinNum(string connectorType)
        {
            return connectorLibraryDetailManager.GetRowCountByWhere($"where ConnectorName = '{connectorType}'");
        }
    }
}
