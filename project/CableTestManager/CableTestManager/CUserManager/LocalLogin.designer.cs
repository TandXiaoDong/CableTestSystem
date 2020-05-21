using System.Windows.Forms;

namespace CableTestManager.CUserManager
{
    partial class LocalLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalLogin));
            this.cb_memberpwd = new Telerik.WinControls.UI.RadCheckBox();
            this.lbx_ToFindPwd = new System.Windows.Forms.LinkLabel();
            this.btn_login = new Telerik.WinControls.UI.RadButton();
            this.lbx_register = new System.Windows.Forms.Label();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbx_username = new Telerik.WinControls.UI.RadTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbx_pwd = new Telerik.WinControls.UI.RadTextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cb_memberpwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_login)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_username)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_pwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_memberpwd
            // 
            this.cb_memberpwd.BackColor = System.Drawing.Color.Transparent;
            this.cb_memberpwd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_memberpwd.ForeColor = System.Drawing.Color.Black;
            this.cb_memberpwd.Location = new System.Drawing.Point(30, 164);
            this.cb_memberpwd.Name = "cb_memberpwd";
            this.cb_memberpwd.Size = new System.Drawing.Size(81, 19);
            this.cb_memberpwd.TabIndex = 16;
            this.cb_memberpwd.Text = "记住密码";
            this.cb_memberpwd.ThemeName = "MaterialBlueGrey";
            // 
            // lbx_ToFindPwd
            // 
            this.lbx_ToFindPwd.AutoSize = true;
            this.lbx_ToFindPwd.BackColor = System.Drawing.Color.Transparent;
            this.lbx_ToFindPwd.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbx_ToFindPwd.ForeColor = System.Drawing.Color.Black;
            this.lbx_ToFindPwd.LinkColor = System.Drawing.Color.Black;
            this.lbx_ToFindPwd.Location = new System.Drawing.Point(227, 161);
            this.lbx_ToFindPwd.Name = "lbx_ToFindPwd";
            this.lbx_ToFindPwd.Size = new System.Drawing.Size(71, 19);
            this.lbx_ToFindPwd.TabIndex = 17;
            this.lbx_ToFindPwd.TabStop = true;
            this.lbx_ToFindPwd.Text = "忘记密码?";
            this.lbx_ToFindPwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lbx_ToFindPwd_LinkClicked);
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.White;
            this.btn_login.Font = new System.Drawing.Font("Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btn_login.ForeColor = System.Drawing.Color.Black;
            this.btn_login.Location = new System.Drawing.Point(30, 205);
            this.btn_login.Name = "btn_login";
            // 
            // 
            // 
            this.btn_login.RootElement.ApplyShapeToControl = true;
            this.btn_login.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.btn_login.RootElement.CanFocus = true;
            this.btn_login.RootElement.CustomFont = "TelerikWebUI";
            this.btn_login.Size = new System.Drawing.Size(259, 38);
            this.btn_login.TabIndex = 18;
            this.btn_login.Text = "登  录";
            this.btn_login.ThemeName = "MaterialBlueGrey";
            this.btn_login.Click += new System.EventHandler(this.Btn_login_Click);
            // 
            // lbx_register
            // 
            this.lbx_register.AutoSize = true;
            this.lbx_register.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbx_register.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbx_register.Location = new System.Drawing.Point(26, 246);
            this.lbx_register.Name = "lbx_register";
            this.lbx_register.Size = new System.Drawing.Size(37, 19);
            this.lbx_register.TabIndex = 24;
            this.lbx_register.Text = "注册";
            this.lbx_register.Visible = false;
            this.lbx_register.Click += new System.EventHandler(this.Lbx_register_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbx_username);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(30, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 41);
            this.panel1.TabIndex = 28;
            // 
            // tbx_username
            // 
            this.tbx_username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_username.Location = new System.Drawing.Point(48, 0);
            this.tbx_username.Name = "tbx_username";
            this.tbx_username.Size = new System.Drawing.Size(211, 41);
            this.tbx_username.TabIndex = 30;
            this.tbx_username.ThemeName = "MaterialBlueGrey";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::CableTestManager.Properties.Resources.user__5_;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 41);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbx_pwd);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Location = new System.Drawing.Point(30, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(259, 42);
            this.panel2.TabIndex = 29;
            // 
            // tbx_pwd
            // 
            this.tbx_pwd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_pwd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_pwd.Location = new System.Drawing.Point(48, 0);
            this.tbx_pwd.Name = "tbx_pwd";
            this.tbx_pwd.Size = new System.Drawing.Size(211, 42);
            this.tbx_pwd.TabIndex = 31;
            this.tbx_pwd.ThemeName = "MaterialBlueGrey";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox3.Image = global::CableTestManager.Properties.Resources.password__3_;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 42);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 30;
            this.pictureBox3.TabStop = false;
            // 
            // LocalLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(322, 266);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbx_register);
            this.Controls.Add(this.cb_memberpwd);
            this.Controls.Add(this.lbx_ToFindPwd);
            this.Controls.Add(this.btn_login);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LocalLogin";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "登录";
            this.ThemeName = "Office2013Light";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cb_memberpwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_login)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_username)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_pwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadCheckBox cb_memberpwd;
        private LinkLabel lbx_ToFindPwd;
        private Telerik.WinControls.UI.RadButton btn_login;
        private Label lbx_register;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private Panel panel1;
        private PictureBox pictureBox2;
        private Panel panel2;
        private PictureBox pictureBox3;
        private Telerik.WinControls.UI.RadTextBox tbx_username;
        private Telerik.WinControls.UI.RadTextBox tbx_pwd;
    }
}
