namespace CableTestManager.View.VProject
{
    partial class ProjectManage
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectManage));
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_queryFilter = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.btn_openProject = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.btn_editProject = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.btn_copyProject = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.btn_deleteProject = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.btn_cancel = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_queryFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tb_queryFilter);
            this.panel1.Controls.Add(this.radLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 63);
            this.panel1.TabIndex = 0;
            // 
            // tb_queryFilter
            // 
            this.tb_queryFilter.Location = new System.Drawing.Point(104, 16);
            this.tb_queryFilter.Name = "tb_queryFilter";
            this.tb_queryFilter.Size = new System.Drawing.Size(463, 36);
            this.tb_queryFilter.TabIndex = 1;
            this.tb_queryFilter.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 31);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(86, 21);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "查询条件：";
            this.radLabel1.ThemeName = "MaterialBlueGrey";
            // 
            // radMenu1
            // 
            this.radMenu1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.btn_openProject,
            this.btn_editProject,
            this.btn_copyProject,
            this.btn_deleteProject,
            this.btn_cancel});
            this.radMenu1.Location = new System.Drawing.Point(0, 454);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(761, 45);
            this.radMenu1.TabIndex = 3;
            this.radMenu1.ThemeName = "MaterialBlueGrey";
            // 
            // btn_openProject
            // 
            // 
            // 
            // 
            this.btn_openProject.ButtonElement.ShowBorder = false;
            this.btn_openProject.Name = "btn_openProject";
            this.btn_openProject.Text = "打开项目";
            this.btn_openProject.UseCompatibleTextRendering = false;
            // 
            // btn_editProject
            // 
            // 
            // 
            // 
            this.btn_editProject.ButtonElement.ShowBorder = false;
            this.btn_editProject.Name = "btn_editProject";
            this.btn_editProject.Text = "编辑项目";
            // 
            // btn_copyProject
            // 
            // 
            // 
            // 
            this.btn_copyProject.ButtonElement.ShowBorder = false;
            this.btn_copyProject.Name = "btn_copyProject";
            this.btn_copyProject.Text = "复制项目";
            // 
            // btn_deleteProject
            // 
            // 
            // 
            // 
            this.btn_deleteProject.ButtonElement.ShowBorder = false;
            this.btn_deleteProject.Name = "btn_deleteProject";
            this.btn_deleteProject.Text = "删除项目";
            // 
            // btn_cancel
            // 
            // 
            // 
            // 
            this.btn_cancel.ButtonElement.ShowBorder = false;
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.StretchHorizontally = true;
            this.btn_cancel.Text = "   取消   ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(761, 391);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "项目列表（双击可打开项目）";
            // 
            // radGridView1
            // 
            this.radGridView1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radGridView1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(3, 19);
            // 
            // 
            // 
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "序号";
            gridViewTextBoxColumn1.Name = "column1";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "项目名称";
            gridViewTextBoxColumn2.Name = "column2";
            gridViewTextBoxColumn2.Width = 75;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "被测线束";
            gridViewTextBoxColumn3.Name = "column3";
            gridViewTextBoxColumn3.Width = 77;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "批次号";
            gridViewTextBoxColumn4.Name = "column4";
            gridViewTextBoxColumn4.Width = 76;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.HeaderText = "常用项目";
            gridViewTextBoxColumn5.Name = "column5";
            gridViewTextBoxColumn5.Width = 82;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.HeaderText = "备注";
            gridViewTextBoxColumn6.Name = "column6";
            gridViewTextBoxColumn6.Width = 77;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.Size = new System.Drawing.Size(755, 369);
            this.radGridView1.TabIndex = 0;
            this.radGridView1.ThemeName = "TelerikMetroTouch";
            // 
            // ProjectManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(761, 499);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radMenu1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProjectManage";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "项目管理";
            this.ThemeName = "Office2013Light";
            this.Load += new System.EventHandler(this.ProjectManage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_queryFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadTextBox tb_queryFilter;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuButtonItem btn_openProject;
        private Telerik.WinControls.UI.RadMenuButtonItem btn_editProject;
        private Telerik.WinControls.UI.RadMenuButtonItem btn_copyProject;
        private Telerik.WinControls.UI.RadMenuButtonItem btn_deleteProject;
        private Telerik.WinControls.UI.RadMenuButtonItem btn_cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
    }
}
