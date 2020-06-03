namespace CableTestManager.View.VInterface
{
    partial class TesterSwitchMapRelation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TesterSwitchMapRelation));
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tool_query = new System.Windows.Forms.ToolStripButton();
            this.tool_add = new System.Windows.Forms.ToolStripButton();
            this.tool_edit = new System.Windows.Forms.ToolStripButton();
            this.tool_delete = new System.Windows.Forms.ToolStripButton();
            this.tool_export = new System.Windows.Forms.ToolStripButton();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.btn_apply = new Telerik.WinControls.UI.RadButton();
            this.btn_cancel = new Telerik.WinControls.UI.RadButton();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_apply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_query,
            this.tool_add,
            this.tool_edit,
            this.tool_delete,
            this.tool_export});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(736, 27);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tool_query
            // 
            this.tool_query.Image = global::CableTestManager.Properties.Resources.查询;
            this.tool_query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_query.Name = "tool_query";
            this.tool_query.Size = new System.Drawing.Size(57, 24);
            this.tool_query.Text = "查询";
            // 
            // tool_add
            // 
            this.tool_add.Image = global::CableTestManager.Properties.Resources.添加16;
            this.tool_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_add.Name = "tool_add";
            this.tool_add.Size = new System.Drawing.Size(57, 24);
            this.tool_add.Text = "添加";
            // 
            // tool_edit
            // 
            this.tool_edit.Image = global::CableTestManager.Properties.Resources.WordArtEditTextClassic;
            this.tool_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_edit.Name = "tool_edit";
            this.tool_edit.Size = new System.Drawing.Size(85, 24);
            this.tool_edit.Text = "批量修改";
            // 
            // tool_delete
            // 
            this.tool_delete.Image = global::CableTestManager.Properties.Resources.delete16;
            this.tool_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_delete.Name = "tool_delete";
            this.tool_delete.Size = new System.Drawing.Size(57, 24);
            this.tool_delete.Text = "删除";
            // 
            // tool_export
            // 
            this.tool_export.Image = global::CableTestManager.Properties.Resources.Export_16x16;
            this.tool_export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_export.Name = "tool_export";
            this.tool_export.Size = new System.Drawing.Size(57, 24);
            this.tool_export.Text = "导出";
            // 
            // radGridView1
            // 
            this.radGridView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGridView1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.radGridView1.ForeColor = System.Drawing.Color.Black;
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(0, 27);
            // 
            // 
            // 
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "序号";
            gridViewTextBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.Width = 91;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "测试仪阵脚号";
            gridViewTextBoxColumn2.Name = "column2";
            gridViewTextBoxColumn2.Width = 122;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "转接台阵脚号";
            gridViewTextBoxColumn3.Name = "column3";
            gridViewTextBoxColumn3.Width = 152;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.Size = new System.Drawing.Size(736, 367);
            this.radGridView1.TabIndex = 10;
            this.radGridView1.ThemeName = "TelerikMetroTouch";
            // 
            // btn_apply
            // 
            this.btn_apply.Location = new System.Drawing.Point(401, 415);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(120, 36);
            this.btn_apply.TabIndex = 11;
            this.btn_apply.Text = "确定";
            this.btn_apply.ThemeName = "MaterialBlueGrey";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(562, 415);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(120, 36);
            this.btn_cancel.TabIndex = 12;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.ThemeName = "MaterialBlueGrey";
            // 
            // TesterSwitchMapRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(736, 463);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TesterSwitchMapRelation";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "测试仪与转接台阵脚映射关系表";
            this.ThemeName = "Office2013Light";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_apply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tool_query;
        private System.Windows.Forms.ToolStripButton tool_add;
        private System.Windows.Forms.ToolStripButton tool_edit;
        private System.Windows.Forms.ToolStripButton tool_delete;
        private System.Windows.Forms.ToolStripButton tool_export;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadButton btn_apply;
        private Telerik.WinControls.UI.RadButton btn_cancel;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
    }
}
