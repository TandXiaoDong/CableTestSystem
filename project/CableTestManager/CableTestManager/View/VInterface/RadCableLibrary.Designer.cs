namespace CableTestManager.View.VInterface
{
    partial class RadCableLibrary
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadCableLibrary));
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tool_queryFilter = new System.Windows.Forms.ToolStripTextBox();
            this.tool_query = new System.Windows.Forms.ToolStripButton();
            this.tool_add = new System.Windows.Forms.ToolStripButton();
            this.tool_edit = new System.Windows.Forms.ToolStripButton();
            this.tool_delete = new System.Windows.Forms.ToolStripButton();
            this.tool_export = new System.Windows.Forms.ToolStripButton();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            this.tool_delAll = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tool_queryFilter,
            this.tool_query,
            this.tool_add,
            this.tool_edit,
            this.tool_delete,
            this.tool_delAll,
            this.tool_export});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1014, 28);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(90, 25);
            this.toolStripLabel1.Text = "线束名称：";
            // 
            // tool_queryFilter
            // 
            this.tool_queryFilter.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tool_queryFilter.Name = "tool_queryFilter";
            this.tool_queryFilter.Size = new System.Drawing.Size(130, 28);
            // 
            // tool_query
            // 
            this.tool_query.Image = global::CableTestManager.Properties.Resources.查询;
            this.tool_query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_query.Name = "tool_query";
            this.tool_query.Size = new System.Drawing.Size(62, 25);
            this.tool_query.Text = "查询";
            // 
            // tool_add
            // 
            this.tool_add.Image = global::CableTestManager.Properties.Resources.添加16;
            this.tool_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_add.Name = "tool_add";
            this.tool_add.Size = new System.Drawing.Size(62, 25);
            this.tool_add.Text = "添加";
            // 
            // tool_edit
            // 
            this.tool_edit.Image = global::CableTestManager.Properties.Resources.WordArtEditTextClassic;
            this.tool_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_edit.Name = "tool_edit";
            this.tool_edit.Size = new System.Drawing.Size(62, 25);
            this.tool_edit.Text = "编辑";
            // 
            // tool_delete
            // 
            this.tool_delete.Image = global::CableTestManager.Properties.Resources.delete16;
            this.tool_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_delete.Name = "tool_delete";
            this.tool_delete.Size = new System.Drawing.Size(62, 25);
            this.tool_delete.Text = "删除";
            // 
            // tool_export
            // 
            this.tool_export.Image = global::CableTestManager.Properties.Resources.Export_16x16;
            this.tool_export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_export.Name = "tool_export";
            this.tool_export.Size = new System.Drawing.Size(62, 25);
            this.tool_export.Text = "导出";
            // 
            // radGridView1
            // 
            this.radGridView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radGridView1.ForeColor = System.Drawing.Color.Black;
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(0, 28);
            // 
            // 
            // 
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "序号";
            gridViewTextBoxColumn1.Name = "column1";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "线束名称";
            gridViewTextBoxColumn2.Name = "column2";
            gridViewTextBoxColumn2.Width = 93;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "接口数量";
            gridViewTextBoxColumn3.Name = "column3";
            gridViewTextBoxColumn3.Width = 90;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "接口信息";
            gridViewTextBoxColumn4.Name = "column4";
            gridViewTextBoxColumn4.Width = 88;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.HeaderText = "芯线数量";
            gridViewTextBoxColumn5.Name = "column5";
            gridViewTextBoxColumn5.Width = 93;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.HeaderText = "备注";
            gridViewTextBoxColumn6.Name = "column6";
            gridViewTextBoxColumn6.Width = 74;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.HeaderText = "操作员";
            gridViewTextBoxColumn7.Name = "column7";
            gridViewTextBoxColumn7.Width = 57;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.Size = new System.Drawing.Size(1014, 572);
            this.radGridView1.TabIndex = 3;
            this.radGridView1.ThemeName = "TelerikMetroTouch";
            // 
            // tool_delAll
            // 
            this.tool_delAll.Image = global::CableTestManager.Properties.Resources.删除16_sig;
            this.tool_delAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_delAll.Name = "tool_delAll";
            this.tool_delAll.Size = new System.Drawing.Size(94, 25);
            this.tool_delAll.Text = "删除所有";
            // 
            // RadCableLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 600);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RadCableLibrary";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "线束库管理";
            this.ThemeName = "Office2013Light";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tool_queryFilter;
        private System.Windows.Forms.ToolStripButton tool_query;
        private System.Windows.Forms.ToolStripButton tool_add;
        private System.Windows.Forms.ToolStripButton tool_edit;
        private System.Windows.Forms.ToolStripButton tool_delete;
        private System.Windows.Forms.ToolStripButton tool_export;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
        private System.Windows.Forms.ToolStripButton tool_delAll;
    }
}
