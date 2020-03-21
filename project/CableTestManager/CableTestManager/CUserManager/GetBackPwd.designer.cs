namespace CommonUtil.CUserManager
{
    partial class GetBackPwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetBackPwd));
            this.tb_pwd = new Telerik.WinControls.UI.RadTextBox();
            this.tb_username = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.tb_repwd = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.btn_cancel = new Telerik.WinControls.UI.RadButton();
            this.btn_register = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.tb_pwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_username)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_repwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_register)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_pwd
            // 
            this.tb_pwd.Location = new System.Drawing.Point(98, 97);
            this.tb_pwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.tb_pwd.Name = "tb_pwd";
            this.tb_pwd.Size = new System.Drawing.Size(200, 36);
            this.tb_pwd.TabIndex = 14;
            this.tb_pwd.ThemeName = "MaterialBlueGrey";
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(98, 40);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(200, 36);
            this.tb_username.TabIndex = 13;
            this.tb_username.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel2
            // 
            this.radLabel2.ForeColor = System.Drawing.Color.Black;
            this.radLabel2.Location = new System.Drawing.Point(21, 112);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(71, 21);
            this.radLabel2.TabIndex = 11;
            this.radLabel2.Text = "新密码：";
            this.radLabel2.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel1
            // 
            this.radLabel1.ForeColor = System.Drawing.Color.Black;
            this.radLabel1.Location = new System.Drawing.Point(6, 48);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(86, 21);
            this.radLabel1.TabIndex = 10;
            this.radLabel1.Text = "用户名称：";
            this.radLabel1.ThemeName = "MaterialBlueGrey";
            // 
            // tb_repwd
            // 
            this.tb_repwd.Location = new System.Drawing.Point(97, 160);
            this.tb_repwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.tb_repwd.Name = "tb_repwd";
            this.tb_repwd.Size = new System.Drawing.Size(201, 36);
            this.tb_repwd.TabIndex = 18;
            this.tb_repwd.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel3
            // 
            this.radLabel3.ForeColor = System.Drawing.Color.Black;
            this.radLabel3.Location = new System.Drawing.Point(6, 175);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(86, 21);
            this.radLabel3.TabIndex = 19;
            this.radLabel3.Text = "确认密码：";
            this.radLabel3.ThemeName = "MaterialBlueGrey";
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.White;
            this.btn_cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_cancel.Location = new System.Drawing.Point(209, 231);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(90, 36);
            this.btn_cancel.TabIndex = 21;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.ThemeName = "MaterialBlueGrey";
            // 
            // btn_register
            // 
            this.btn_register.BackColor = System.Drawing.Color.White;
            this.btn_register.ForeColor = System.Drawing.Color.Black;
            this.btn_register.Location = new System.Drawing.Point(98, 231);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(86, 36);
            this.btn_register.TabIndex = 20;
            this.btn_register.Text = "确定";
            this.btn_register.ThemeName = "MaterialBlueGrey";
            // 
            // GetBackPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(327, 279);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.tb_repwd);
            this.Controls.Add(this.tb_pwd);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GetBackPwd";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "找回密码";
            this.ThemeName = "Office2013Light";
            this.Load += new System.EventHandler(this.GetBackPwd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tb_pwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_username)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_repwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_register)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadTextBox tb_pwd;
        private Telerik.WinControls.UI.RadTextBox tb_username;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private Telerik.WinControls.UI.RadTextBox tb_repwd;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadButton btn_cancel;
        private Telerik.WinControls.UI.RadButton btn_register;
    }
}
