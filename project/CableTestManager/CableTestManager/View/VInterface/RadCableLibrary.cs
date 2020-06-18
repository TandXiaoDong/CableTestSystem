using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using CableTestManager.View.VInterface;
using CableTestManager.Business;
using CableTestManager.Business.Implements;
using CableTestManager.Entity;
using WindowsFormTelerik.ControlCommon;
using WindowsFormTelerik.GridViewExportData;
using CableTestManager.CUserManager;
using CableTestManager.Common;
using WindowsFormTelerik.CommonUI;

namespace CableTestManager.View.VInterface
{
    public partial class RadCableLibrary : RadForm
    {
        private TCableTestLibraryManager lineStructLibraryDetailManager;
        public RadCableLibrary()
        {
            InitializeComponent();
            Init();
            QueryCableLibInfo();
            EventHandlers();
        }

        private void Init()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,true,7);
            lineStructLibraryDetailManager = new TCableTestLibraryManager();
            InitFuncState();
        }

        private void InitFuncState()
        {
            OperatLimitManager operatLimitManager = new OperatLimitManager();
            var data = operatLimitManager.GetDataSetByWhere($"where UserRole='{LocalLogin.currentUserType}'").Tables[0];
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    this.tool_query.Visible = ConvertDec2State(dr["CableLib_query"].ToString());
                    this.tool_add.Visible = ConvertDec2State(dr["CableLib_add"].ToString());
                    this.tool_delete.Visible = ConvertDec2State(dr["CableLib_del"].ToString());
                    this.tool_edit.Visible = ConvertDec2State(dr["CableLib_edit"].ToString());
                    this.tool_export.Visible = ConvertDec2State(dr["CableLib_export"].ToString());
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

        private void EventHandlers()
        {
            this.tool_add.Click += Tool_add_Click;
            this.tool_delete.Click += Tool_delete_Click;
            this.tool_edit.Click += Tool_edit_Click;
            this.tool_export.Click += Tool_export_Click;
            this.tool_query.Click += Tool_query_Click;
            this.radGridView1.CellDoubleClick += RadGridView1_CellDoubleClick;
        }

        private void RadGridView1_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            EditCableLibrary();
        }

        private void Tool_query_Click(object sender, EventArgs e)
        {
            QueryCableLibInfo();
        }

        private void Tool_export_Click(object sender, EventArgs e)
        {
            GridViewExport.ExportGridViewData(GridViewExport.ExportFormat.EXCEL, this.radGridView1);
        }

        private void Tool_edit_Click(object sender, EventArgs e)
        {
            EditCableLibrary();
        }

        private void EditCableLibrary()
        {
            var b = RadGridViewProperties.IsSelectRow(this.radGridView1);
            if (!b)
                return;
            var lineCableName = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            RadUpdateCable radUpdateCable = new RadUpdateCable("编辑线束库", lineCableName,true);
            if (radUpdateCable.ShowDialog() == DialogResult.OK)
            {
                QueryCableLibInfo();
            }
        }

        private void Tool_delete_Click(object sender, EventArgs e)
        {
            var b = RadGridViewProperties.IsSelectRow(this.radGridView1);
            if (!b)
            {
                MessageBox.Show("请选择要删除的线束代号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var LineStructName = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            if (MessageBox.Show($"确认要删除线束代号{LineStructName}?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) != DialogResult.OK)
            {
                return;
            }
            var delRow = lineStructLibraryDetailManager.DeleteByWhere($"where CableName = '{LineStructName}'");
            if (delRow > 0)
            {
                MessageBox.Show("删除成功！","提示",MessageBoxButtons.OK);
                UserOperateRecord.UpdateOperateRecord($"删除线束库{LineStructName}");
                QueryCableLibInfo();
            }
        }

        private void Tool_add_Click(object sender, EventArgs e)
        {
            RadUpdateCable radUpdateCable = new RadUpdateCable("添加线束库库","",false);
            if (radUpdateCable.ShowDialog() == DialogResult.OK)
            {
                UserOperateRecord.UpdateOperateRecord($"添加线束库");
                QueryCableLibInfo();
            }
        }

        private void QueryCableLibInfo()
        {
            RadGridViewProperties.ClearGridView(this.radGridView1,null);
            var data = lineStructLibraryDetailManager.GetDataSetByFieldsAndWhere("distinct CableName", "").Tables[0];
            if (data.Rows.Count < 1)
                return;
            int iRow = 0;
            foreach (DataRow dr in data.Rows)
            {
                var lineStructName = dr["CableName"].ToString();
                if (IsExistLineStruct(lineStructName))
                    continue;
                this.radGridView1.Rows.AddNew();
                var resultString = GetInterfaceInfoByCableName(lineStructName);
                this.radGridView1.Rows[iRow].Cells[0].Value = iRow + 1;
                this.radGridView1.Rows[iRow].Cells[1].Value = lineStructName;
                this.radGridView1.Rows[iRow].Cells[2].Value = resultString.Split(',').Length;
                this.radGridView1.Rows[iRow].Cells[3].Value = resultString;
                this.radGridView1.Rows[iRow].Cells[4].Value = lineStructLibraryDetailManager.GetRowCountByWhere($"where CableName='{lineStructName}'");
                iRow++;
            }
        }

        private string GetInterfaceInfoByCableName(string cableName)
        {
            var data = lineStructLibraryDetailManager.GetDataSetByFieldsAndWhere("distinct StartInterface,EndInterface", $"where CableName='{cableName}'").Tables[0];
            var resultString = "";
            foreach (DataRow dr in data.Rows)
            {

                if (!resultString.Contains(dr[0].ToString()))
                    resultString += dr[0].ToString() + ",";
                if (!resultString.Contains(dr[1].ToString()))
                    resultString += dr[1].ToString() + ",";
            }
            if (resultString == "")
                return "";
            return resultString.Substring(0,resultString.Length - 1);
        }

        private bool IsExistLineStruct(string cableName)
        {
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                if (rowInfo.Cells[1].Value != null)
                {
                    if (rowInfo.Cells[1].Value.ToString() == cableName)
                        return true;
                }
            }
            return false;
        }
    }
}
