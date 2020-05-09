namespace CableTestManager.CUserManager
{
    partial class OperatorLog
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperatorLog));
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.datePickerEndTime = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.tb_queryCondition = new Telerik.WinControls.UI.RadTextBox();
            this.dateTimePickerStartTime = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tool_query = new System.Windows.Forms.ToolStripButton();
            this.tool_likeQuery = new System.Windows.Forms.ToolStripButton();
            this.tool_deleteSignalData = new System.Windows.Forms.ToolStripButton();
            this.tool_deleteAllData = new System.Windows.Forms.ToolStripButton();
            this.tool_export = new System.Windows.Forms.ToolStripButton();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datePickerEndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_queryCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePickerStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.datePickerEndTime);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.tb_queryCondition);
            this.radGroupBox1.Controls.Add(this.dateTimePickerStartTime);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox1.HeaderText = "查询条件";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1089, 81);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "查询条件";
            this.radGroupBox1.ThemeName = "Breeze";
            // 
            // datePickerEndTime
            // 
            this.datePickerEndTime.CalendarSize = new System.Drawing.Size(290, 320);
            this.datePickerEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.datePickerEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerEndTime.Location = new System.Drawing.Point(760, 31);
            this.datePickerEndTime.Name = "datePickerEndTime";
            this.datePickerEndTime.Size = new System.Drawing.Size(221, 36);
            this.datePickerEndTime.TabIndex = 6;
            this.datePickerEndTime.TabStop = false;
            this.datePickerEndTime.Text = "2020-02-11 16:15:54";
            this.datePickerEndTime.ThemeName = "MaterialBlueGrey";
            this.datePickerEndTime.Value = new System.DateTime(2020, 2, 11, 16, 15, 54, 905);
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(668, 44);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(86, 21);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = "结束日期：";
            this.radLabel3.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(338, 46);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(86, 21);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "起始日期：";
            this.radLabel2.ThemeName = "MaterialBlueGrey";
            // 
            // tb_queryCondition
            // 
            this.tb_queryCondition.Location = new System.Drawing.Point(109, 31);
            this.tb_queryCondition.Name = "tb_queryCondition";
            this.tb_queryCondition.Size = new System.Drawing.Size(176, 36);
            this.tb_queryCondition.TabIndex = 2;
            this.tb_queryCondition.ThemeName = "MaterialBlueGrey";
            // 
            // dateTimePickerStartTime
            // 
            this.dateTimePickerStartTime.CalendarSize = new System.Drawing.Size(290, 320);
            this.dateTimePickerStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePickerStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartTime.Location = new System.Drawing.Point(430, 31);
            this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            this.dateTimePickerStartTime.Size = new System.Drawing.Size(212, 36);
            this.dateTimePickerStartTime.TabIndex = 1;
            this.dateTimePickerStartTime.TabStop = false;
            this.dateTimePickerStartTime.Text = "2020-02-11 16:15:54";
            this.dateTimePickerStartTime.ThemeName = "MaterialBlueGrey";
            this.dateTimePickerStartTime.Value = new System.DateTime(2020, 2, 11, 16, 15, 54, 905);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(28, 44);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(86, 21);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "操作用户：";
            this.radLabel1.ThemeName = "MaterialBlueGrey";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_query,
            this.tool_likeQuery,
            this.tool_deleteSignalData,
            this.tool_deleteAllData,
            this.tool_export});
            this.toolStrip1.Location = new System.Drawing.Point(0, 81);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1089, 28);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tool_query
            // 
            this.tool_query.Image = global::CableTestManager.Properties.Resources.Search_16x16;
            this.tool_query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_query.Name = "tool_query";
            this.tool_query.Size = new System.Drawing.Size(62, 25);
            this.tool_query.Text = "查询";
            // 
            // tool_likeQuery
            // 
            this.tool_likeQuery.Image = global::CableTestManager.Properties.Resources.Search_16x16;
            this.tool_likeQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_likeQuery.Name = "tool_likeQuery";
            this.tool_likeQuery.Size = new System.Drawing.Size(94, 25);
            this.tool_likeQuery.Text = "模糊查询";
            // 
            // tool_deleteSignalData
            // 
            this.tool_deleteSignalData.Image = global::CableTestManager.Properties.Resources.DeleteDataSource_16x16;
            this.tool_deleteSignalData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_deleteSignalData.Name = "tool_deleteSignalData";
            this.tool_deleteSignalData.Size = new System.Drawing.Size(142, 25);
            this.tool_deleteSignalData.Text = "删除选择行记录";
            // 
            // tool_deleteAllData
            // 
            this.tool_deleteAllData.Image = global::CableTestManager.Properties.Resources.DeleteDataSource_16x16;
            this.tool_deleteAllData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_deleteAllData.Name = "tool_deleteAllData";
            this.tool_deleteAllData.Size = new System.Drawing.Size(126, 25);
            this.tool_deleteAllData.Text = "删除所有记录";
            // 
            // tool_export
            // 
            this.tool_export.Image = global::CableTestManager.Properties.Resources.Export_16x16;
            this.tool_export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_export.Name = "tool_export";
            this.tool_export.Size = new System.Drawing.Size(94, 25);
            this.tool_export.Text = "导出数据";
            // 
            // radGridView1
            // 
            this.radGridView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.radGridView1.ForeColor = System.Drawing.Color.Black;
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(0, 109);
            // 
            // 
            // 
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "序号";
            gridViewTextBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.Width = 75;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "操作用户";
            gridViewTextBoxColumn2.Name = "column2";
            gridViewTextBoxColumn2.Width = 77;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "操作内容";
            gridViewTextBoxColumn3.Name = "column3";
            gridViewTextBoxColumn3.Width = 91;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "操作时间";
            gridViewTextBoxColumn4.Name = "column4";
            gridViewTextBoxColumn4.Width = 97;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.Size = new System.Drawing.Size(1089, 406);
            this.radGridView1.TabIndex = 3;
            this.radGridView1.ThemeName = "TelerikMetroTouch";
            // 
            // OperatorLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1089, 515);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.radGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OperatorLog";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "操作记录";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datePickerEndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_queryCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePickerStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
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
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadTextBox tb_queryCondition;
        private Telerik.WinControls.UI.RadDateTimePicker dateTimePickerStartTime;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tool_query;
        private System.Windows.Forms.ToolStripButton tool_likeQuery;
        private System.Windows.Forms.ToolStripButton tool_deleteSignalData;
        private System.Windows.Forms.ToolStripButton tool_export;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private System.Windows.Forms.ToolStripButton tool_deleteAllData;
        private Telerik.WinControls.UI.RadDateTimePicker datePickerEndTime;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
    }
}
