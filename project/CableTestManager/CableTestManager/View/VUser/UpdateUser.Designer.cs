namespace CableTestManager.View
{
    partial class UpdateUser
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
            this.label5 = new System.Windows.Forms.Label();
            this.btn_submit = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_psw = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_user = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label5.Location = new System.Drawing.Point(133, 118);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(227, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "注: 密码为6～16个字符(英文字母或数字)";
            // 
            // btn_submit
            // 
            this.btn_submit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_submit.Location = new System.Drawing.Point(133, 249);
            this.btn_submit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(75, 24);
            this.btn_submit.TabIndex = 22;
            this.btn_submit.Text = "确定";
            this.btn_submit.UseVisualStyleBackColor = true;
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Location = new System.Drawing.Point(268, 249);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 24);
            this.btnQuit.TabIndex = 23;
            this.btnQuit.Text = "取消";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_name.Location = new System.Drawing.Point(133, 152);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_name.MaxLength = 32;
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(211, 24);
            this.textBox_name.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(80, 156);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "姓名:";
            // 
            // textBox_psw
            // 
            this.textBox_psw.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_psw.Location = new System.Drawing.Point(133, 80);
            this.textBox_psw.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_psw.MaxLength = 32;
            this.textBox_psw.Name = "textBox_psw";
            this.textBox_psw.PasswordChar = '*';
            this.textBox_psw.Size = new System.Drawing.Size(211, 24);
            this.textBox_psw.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(80, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "密码:";
            // 
            // textBox_user
            // 
            this.textBox_user.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_user.Location = new System.Drawing.Point(133, 40);
            this.textBox_user.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_user.MaxLength = 32;
            this.textBox_user.Name = "textBox_user";
            this.textBox_user.ReadOnly = true;
            this.textBox_user.Size = new System.Drawing.Size(211, 24);
            this.textBox_user.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(80, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "账号:";
            // 
            // UpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_psw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_user);
            this.Controls.Add(this.label1);
            this.Name = "UpdateUser";
            this.Text = "修改用户";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_psw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_user;
        private System.Windows.Forms.Label label1;
    }
}