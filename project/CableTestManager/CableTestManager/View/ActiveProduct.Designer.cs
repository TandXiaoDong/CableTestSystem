namespace CableTestManager.View
{
    partial class ActiveProduct
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
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnActivation = new System.Windows.Forms.Button();
            this.textBox_CDkey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Location = new System.Drawing.Point(419, 280);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(90, 24);
            this.btnQuit.TabIndex = 16;
            this.btnQuit.Text = "取消";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnActivation
            // 
            this.btnActivation.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnActivation.Location = new System.Drawing.Point(290, 280);
            this.btnActivation.Margin = new System.Windows.Forms.Padding(2);
            this.btnActivation.Name = "btnActivation";
            this.btnActivation.Size = new System.Drawing.Size(90, 24);
            this.btnActivation.TabIndex = 14;
            this.btnActivation.Text = "激活";
            this.btnActivation.UseVisualStyleBackColor = true;
            // 
            // textBox_CDkey
            // 
            this.textBox_CDkey.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_CDkey.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.textBox_CDkey.Location = new System.Drawing.Point(322, 207);
            this.textBox_CDkey.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_CDkey.MaxLength = 32;
            this.textBox_CDkey.Name = "textBox_CDkey";
            this.textBox_CDkey.Size = new System.Drawing.Size(226, 24);
            this.textBox_CDkey.TabIndex = 15;
            this.textBox_CDkey.Text = "请输入20位激活码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(252, 211);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "激活码:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(271, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "注册码已过期，请输入激活码进行激活!";
            // 
            // ActiveProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnActivation);
            this.Controls.Add(this.textBox_CDkey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ActiveProduct";
            this.Text = "产品激活窗口";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnActivation;
        private System.Windows.Forms.TextBox textBox_CDkey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}