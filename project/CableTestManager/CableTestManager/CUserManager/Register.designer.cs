namespace CommonUtil.CUserManager
{
    partial class Register
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.tb_username = new Telerik.WinControls.UI.RadTextBox();
            this.tb_pwd = new Telerik.WinControls.UI.RadTextBox();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.windows7Theme1 = new Telerik.WinControls.Themes.Windows7Theme();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.tb_repwd = new Telerik.WinControls.UI.RadTextBox();
            this.cb_userType = new Telerik.WinControls.UI.RadMultiColumnComboBox();
            this.btn_cancel = new Telerik.WinControls.UI.RadButton();
            this.btn_register = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.tb_username)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_pwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_repwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_userType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_userType.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_userType.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_register)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(119, 80);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(220, 36);
            this.tb_username.TabIndex = 3;
            this.tb_username.ThemeName = "MaterialBlueGrey";
            // 
            // tb_pwd
            // 
            this.tb_pwd.Location = new System.Drawing.Point(119, 134);
            this.tb_pwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.tb_pwd.Name = "tb_pwd";
            this.tb_pwd.Size = new System.Drawing.Size(220, 36);
            this.tb_pwd.TabIndex = 4;
            this.tb_pwd.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(25, 40);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(86, 21);
            this.radLabel3.TabIndex = 10;
            this.radLabel3.Text = "用户类型：";
            this.radLabel3.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(25, 95);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(86, 21);
            this.radLabel1.TabIndex = 11;
            this.radLabel1.Text = "用户名称：";
            this.radLabel1.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(25, 149);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(86, 21);
            this.radLabel4.TabIndex = 12;
            this.radLabel4.Text = "用户密码：";
            this.radLabel4.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(25, 204);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(86, 21);
            this.radLabel2.TabIndex = 13;
            this.radLabel2.Text = "确认密码：";
            this.radLabel2.ThemeName = "MaterialBlueGrey";
            // 
            // tb_repwd
            // 
            this.tb_repwd.Location = new System.Drawing.Point(117, 189);
            this.tb_repwd.Name = "tb_repwd";
            this.tb_repwd.Size = new System.Drawing.Size(222, 36);
            this.tb_repwd.TabIndex = 14;
            this.tb_repwd.ThemeName = "MaterialBlueGrey";
            // 
            // cb_userType
            // 
            // 
            // cb_userType.NestedRadGridView
            // 
            this.cb_userType.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.cb_userType.EditorControl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_userType.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cb_userType.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.cb_userType.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.cb_userType.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.cb_userType.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.cb_userType.EditorControl.MasterTemplate.EnableGrouping = false;
            this.cb_userType.EditorControl.MasterTemplate.ShowFilteringRow = false;
            this.cb_userType.EditorControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.cb_userType.EditorControl.Name = "NestedRadGridView";
            this.cb_userType.EditorControl.ReadOnly = true;
            this.cb_userType.EditorControl.ShowGroupPanel = false;
            this.cb_userType.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.cb_userType.EditorControl.TabIndex = 0;
            this.cb_userType.Location = new System.Drawing.Point(119, 25);
            this.cb_userType.Name = "cb_userType";
            this.cb_userType.Size = new System.Drawing.Size(220, 36);
            this.cb_userType.TabIndex = 28;
            this.cb_userType.TabStop = false;
            this.cb_userType.ThemeName = "MaterialBlueGrey";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(244, 252);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(97, 36);
            this.btn_cancel.TabIndex = 30;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.ThemeName = "MaterialBlueGrey";
            // 
            // btn_register
            // 
            this.btn_register.Location = new System.Drawing.Point(119, 252);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(94, 36);
            this.btn_register.TabIndex = 29;
            this.btn_register.Text = "确认";
            this.btn_register.ThemeName = "MaterialBlueGrey";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(378, 316);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.cb_userType);
            this.Controls.Add(this.tb_repwd);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.tb_pwd);
            this.Controls.Add(this.tb_username);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Register";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "注册新用户";
            this.ThemeName = "Office2013Light";
            this.Load += new System.EventHandler(this.Register_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tb_username)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_pwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_repwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_userType.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_userType.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_userType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_register)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadTextBox tb_username;
        private Telerik.WinControls.UI.RadTextBox tb_pwd;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private Telerik.WinControls.Themes.Windows7Theme windows7Theme1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox tb_repwd;
        private Telerik.WinControls.UI.RadMultiColumnComboBox cb_userType;
        private Telerik.WinControls.UI.RadButton btn_cancel;
        private Telerik.WinControls.UI.RadButton btn_register;
    }
}
