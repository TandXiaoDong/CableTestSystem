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

namespace CableTestManager.View.VInterface
{
    public partial class SwitchWorkWearLibrary : Telerik.WinControls.UI.RadForm
    {
        private TSwitchWorkWearLibraryManager switchWorkWearLibraryManager;
        public SwitchWorkWearLibrary()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            Init();
            EventHandlers();
        }

        private void Init()
        {
            switchWorkWearLibraryManager = new TSwitchWorkWearLibraryManager();
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,true,4);
        }

        private void EventHandlers()
        {
            this.tool_add.Click += Tool_add_Click;
            this.tool_delete.Click += Tool_delete_Click;
            this.tool_edit.Click += Tool_edit_Click;
            this.tool_export.Click += Tool_export_Click;
            this.tool_query.Click += Tool_query_Click;
        }

        private void Tool_query_Click(object sender, EventArgs e)
        {
            QueryDB();
        }

        private void Tool_export_Click(object sender, EventArgs e)
        {
            GridViewExport.ExportGridViewData(GridViewExport.ExportFormat.EXCEL, this.radGridView1);
        }

        private void Tool_edit_Click(object sender, EventArgs e)
        {
            var currentIndex = this.radGridView1.CurrentRow.Index;
            if (currentIndex < 0)
                return;
            var currentSwitchCode = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            var currentSwitchType = this.radGridView1.CurrentRow.Cells[2].Value.ToString();
            var currentRemark = this.radGridView1.CurrentRow.Cells[3].Value.ToString();

            EditSwitchWorkWear editSwitchWorkWear = new EditSwitchWorkWear(currentSwitchCode,currentSwitchType,currentRemark);
            if (editSwitchWorkWear.ShowDialog() == DialogResult.OK)
            {
                this.radGridView1.CurrentRow.Cells[2].Value = editSwitchWorkWear.switchWorkWearType;
                this.radGridView1.CurrentRow.Cells[3].Value = editSwitchWorkWear.remark;
            }
        }

        private void Tool_delete_Click(object sender, EventArgs e)
        {
            var currentRowIndex = this.radGridView1.CurrentRow.Index;
            if (currentRowIndex < 0)
            {
                MessageBox.Show("请选择要删除的工装代号！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            var currentWorkWearCode = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            var dRow = switchWorkWearLibraryManager.DeleteByWhere($"where SwitchWorkWearCode='{currentWorkWearCode}'");
            if (dRow > 0)
            {
                MessageBox.Show($"已成功删除工装代号{currentWorkWearCode}！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"删除工装代号{currentWorkWearCode}失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Tool_add_Click(object sender, EventArgs e)
        {
            AddSwitchWorkWear addSwitchWorkWear = new AddSwitchWorkWear();
            if (addSwitchWorkWear.ShowDialog() == DialogResult.OK)
            {
                this.radGridView1.Rows.AddNew();
                int rCount = this.radGridView1.RowCount;
                this.radGridView1.Rows[rCount - 1].Cells[0].Value = rCount;
                this.radGridView1.Rows[rCount - 1].Cells[1].Value = addSwitchWorkWear.switchWorkWearCode;
                this.radGridView1.Rows[rCount - 1].Cells[2].Value = addSwitchWorkWear.switchType;
                this.radGridView1.Rows[rCount - 1].Cells[3].Value = addSwitchWorkWear.remark;

                //save db
                TSwitchWorkWearLibrary switchWorkWearLibrary = new TSwitchWorkWearLibrary();
                switchWorkWearLibrary.ID = CableTestManager.Common.TablePrimaryKey.InsertSwitchWorkLibPID();
                switchWorkWearLibrary.SwitchWorkWearCode = addSwitchWorkWear.switchWorkWearCode;
                switchWorkWearLibrary.SwitchrType = addSwitchWorkWear.switchType;
                switchWorkWearLibrary.Remark = addSwitchWorkWear.remark;
                switchWorkWearLibraryManager.Insert(switchWorkWearLibrary);
            }
        }

        private void QueryDB()
        {
            int i = 0;
            var dbSource = switchWorkWearLibraryManager.GetAllDataSet().Tables[0];

            foreach (DataRow dr in dbSource.Rows)
            {
                var SwitchWorkWearCode = dr["SwitchWorkWearCode"].ToString();
                if (IsExistSwitchWorkWearCode(SwitchWorkWearCode))
                    continue;
                this.radGridView1.Rows.AddNew();
                this.radGridView1.Rows[i].Cells[0].Value = i + 1;//序号
                this.radGridView1.Rows[i].Cells[1].Value = dr["SwitchWorkWearCode"].ToString();
                this.radGridView1.Rows[i].Cells[2].Value = dr["SwitchrType"].ToString();
                this.radGridView1.Rows[i].Cells[3].Value = dr["Remark"].ToString();
                i++;
            }
        }

        private bool IsExistSwitchWorkWearCode(string sCode)
        {
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                if (rowInfo.Cells[1].Value != null)
                {
                    if (rowInfo.Cells[1].Value.ToString() == sCode)
                        return true;
                }
            }
            return false;
        }
    }
}
