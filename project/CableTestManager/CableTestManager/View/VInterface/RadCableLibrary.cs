﻿using System;
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

namespace CableTestManager.View.VInterface
{
    public partial class RadCableLibrary : RadForm
    {
        private TCableTestLibraryManager lineStructLibraryDetailManager;
        public RadCableLibrary()
        {
            InitializeComponent();
            Init();
            EventHandlers();
        }

        private void Init()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,true,7);
            lineStructLibraryDetailManager = new TCableTestLibraryManager();
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
            GetPlugLineStruct();
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
            var cIndex = this.radGridView1.CurrentRow.Index;
            if (cIndex < 0)
                return;
            var lineCableName = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            RadUpdateCable radUpdateCable = new RadUpdateCable("编辑线束库", lineCableName,true);
            if (radUpdateCable.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void Tool_delete_Click(object sender, EventArgs e)
        {
            int rIndex = this.radGridView1.CurrentRow.Index;
            if (rIndex < 0)
            {
                MessageBox.Show("请选择要删除的线束代号！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            var LineStructName = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            var delRow = lineStructLibraryDetailManager.DeleteByWhere($"where CableName = '{LineStructName}'");
            if (delRow > 0)
            {
                MessageBox.Show("删除成功！","提示",MessageBoxButtons.OK);
                GetPlugLineStruct();
            }
        }

        private void Tool_add_Click(object sender, EventArgs e)
        {
            RadUpdateCable radUpdateCable = new RadUpdateCable("添加接口库","",false);
            if (radUpdateCable.ShowDialog() == DialogResult.OK)
            {
                
            }
        }

        private void GetPlugLineStruct()
        {
            RadGridViewProperties.ClearGridView(this.radGridView1);
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