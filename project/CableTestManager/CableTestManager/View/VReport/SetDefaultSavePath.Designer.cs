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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetDefaultSavePath));
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnSelectSavePath = new System.Windows.Forms.Button();
            this.textBox_savePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_openDir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Location = new System.Drawing.Point(326, 223);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(112, 28);
            this.btnQuit.TabIndex = 6;
            this.btnQuit.Text = "取消";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit.Location = new System.Drawing.Point(101, 223);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(112, 28);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "确定";
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // btnSelectSavePath
            // 
            this.btnSelectSavePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSelectSavePath.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectSavePath.Location = new System.Drawing.Point(101, 92);
            this.btnSelectSavePath.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectSavePath.Name = "btnSelectSavePath";
            this.btnSelectSavePath.Size = new System.Drawing.Size(337, 30);
            this.btnSelectSavePath.TabIndex = 8;
            this.btnSelectSavePath.Text = "选择默认保存路径";
            this.btnSelectSavePath.UseVisualStyleBackColor = false;
            // 
            // textBox_savePath
            // 
            this.textBox_savePath.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_savePath.Location = new System.Drawing.Point(101, 38);
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
            this.label1.Location = new System.Drawing.Point(23, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "保存路径:";
            // 
            // btn_openDir
            // 
            this.btn_openDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_openDir.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_openDir.Location = new System.Drawing.Point(101, 153);
            this.btn_openDir.Margin = new System.Windows.Forms.Padding(2);
            this.btn_openDir.Name = "btn_openDir";
            this.btn_openDir.Size = new System.Drawing.Size(337, 30);
            this.btn_openDir.TabIndex = 9;
            this.btn_openDir.Text = "打开当前目录";
            this.btn_openDir.UseVisualStyleBackColor = false;
            // 
            // SetDefaultSavePath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 265);
            this.Controls.Add(this.btn_openDir);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnSelectSavePath);
            this.Controls.Add(this.textBox_savePath);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetDefaultSavePath";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "默认路径设置";
            this.Load += new System.EventHandler(this.SetDefaultSavePath_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnSelectSavePath;
        private System.Windows.Forms.TextBox textBox_savePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_openDir;
    }
}