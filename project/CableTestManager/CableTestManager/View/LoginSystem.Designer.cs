namespace CableTestManager.View
{
    partial class LoginSystem
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
            this.label1 = new System.Windows.Forms.Label();
            this.label_login = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(243)))), ((int)(((byte)(242)))));
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(265, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 27);
            this.label1.TabIndex = 7;
            this.label1.Text = "线束测试系统";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_login
            // 
            this.label_login.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_login.BackColor = System.Drawing.Color.Transparent;
            this.label_login.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_login.Location = new System.Drawing.Point(267, 295);
            this.label_login.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_login.Name = "label_login";
            this.label_login.Size = new System.Drawing.Size(267, 28);
            this.label_login.TabIndex = 5;
            this.label_login.Text = "登  录";
            this.label_login.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Password
            // 
            this.textBox_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Password.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Password.Location = new System.Drawing.Point(307, 244);
            this.textBox_Password.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '*';
            this.textBox_Password.Size = new System.Drawing.Size(180, 19);
            this.textBox_Password.TabIndex = 4;
            this.textBox_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_UserName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_UserName.Location = new System.Drawing.Point(307, 187);
            this.textBox_UserName.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(180, 19);
            this.textBox_UserName.TabIndex = 6;
            this.textBox_UserName.Text = "admin";
            this.textBox_UserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoginSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_login);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_UserName);
            this.Name = "LoginSystem";
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_login;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.TextBox textBox_UserName;
    }
}