namespace CableTestManager.View
{
    partial class SetDefaultSavePath
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnSelectSavePath = new System.Windows.Forms.Button();
            this.textBox_savePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Location = new System.Drawing.Point(441, 305);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(112, 24);
            this.btnQuit.TabIndex = 6;
            this.btnQuit.Text = "取消";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit.Location = new System.Drawing.Point(270, 305);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(112, 24);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "确定";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnSelectSavePath
            // 
            this.btnSelectSavePath.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectSavePath.Location = new System.Drawing.Point(194, 176);
            this.btnSelectSavePath.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectSavePath.Name = "btnSelectSavePath";
            this.btnSelectSavePath.Size = new System.Drawing.Size(413, 24);
            this.btnSelectSavePath.TabIndex = 8;
            this.btnSelectSavePath.Text = "选择默认保存路径";
            this.btnSelectSavePath.UseVisualStyleBackColor = true;
            // 
            // textBox_savePath
            // 
            this.textBox_savePath.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_savePath.Location = new System.Drawing.Point(270, 122);
            this.textBox_savePath.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_savePath.Name = "textBox_savePath";
            this.textBox_savePath.ReadOnly = true;
            this.textBox_savePath.Size = new System.Drawing.Size(338, 24);
            this.textBox_savePath.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(192, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "保存路径:";
            // 
            // SetDefaultSavePath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnSelectSavePath);
            this.Controls.Add(this.textBox_savePath);
            this.Controls.Add(this.label1);
            this.Name = "SetDefaultSavePath";
            this.Text = "默认路径设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnSelectSavePath;
        private System.Windows.Forms.TextBox textBox_savePath;
        private System.Windows.Forms.Label label1;
    }
}