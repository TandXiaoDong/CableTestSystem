namespace CableTestManager.View
{
    partial class ReportFormatSet
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_ShowFormat_Mea = new System.Windows.Forms.RadioButton();
            this.radioButton_ShowFormat_Err = new System.Windows.Forms.RadioButton();
            this.radioButton_ShowFormat_All = new System.Windows.Forms.RadioButton();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton_ShowFormat_Mea);
            this.groupBox2.Controls.Add(this.radioButton_ShowFormat_Err);
            this.groupBox2.Controls.Add(this.radioButton_ShowFormat_All);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(160, 61);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(480, 256);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "报表默认格式设置";
            // 
            // radioButton_ShowFormat_Mea
            // 
            this.radioButton_ShowFormat_Mea.AutoSize = true;
            this.radioButton_ShowFormat_Mea.Location = new System.Drawing.Point(179, 173);
            this.radioButton_ShowFormat_Mea.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_ShowFormat_Mea.Name = "radioButton_ShowFormat_Mea";
            this.radioButton_ShowFormat_Mea.Size = new System.Drawing.Size(130, 19);
            this.radioButton_ShowFormat_Mea.TabIndex = 1;
            this.radioButton_ShowFormat_Mea.Text = "仅显示测量数据";
            this.radioButton_ShowFormat_Mea.UseVisualStyleBackColor = true;
            // 
            // radioButton_ShowFormat_Err
            // 
            this.radioButton_ShowFormat_Err.AutoSize = true;
            this.radioButton_ShowFormat_Err.Location = new System.Drawing.Point(179, 119);
            this.radioButton_ShowFormat_Err.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_ShowFormat_Err.Name = "radioButton_ShowFormat_Err";
            this.radioButton_ShowFormat_Err.Size = new System.Drawing.Size(130, 19);
            this.radioButton_ShowFormat_Err.TabIndex = 1;
            this.radioButton_ShowFormat_Err.Text = "仅显示异常数据";
            this.radioButton_ShowFormat_Err.UseVisualStyleBackColor = true;
            // 
            // radioButton_ShowFormat_All
            // 
            this.radioButton_ShowFormat_All.AutoSize = true;
            this.radioButton_ShowFormat_All.Checked = true;
            this.radioButton_ShowFormat_All.Location = new System.Drawing.Point(179, 66);
            this.radioButton_ShowFormat_All.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_ShowFormat_All.Name = "radioButton_ShowFormat_All";
            this.radioButton_ShowFormat_All.Size = new System.Drawing.Size(115, 19);
            this.radioButton_ShowFormat_All.TabIndex = 1;
            this.radioButton_ShowFormat_All.TabStop = true;
            this.radioButton_ShowFormat_All.Text = "显示所有数据";
            this.radioButton_ShowFormat_All.UseVisualStyleBackColor = true;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Location = new System.Drawing.Point(424, 366);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(90, 24);
            this.btnQuit.TabIndex = 36;
            this.btnQuit.Text = "取消";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit.Location = new System.Drawing.Point(289, 366);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(90, 24);
            this.btnSubmit.TabIndex = 35;
            this.btnSubmit.Text = "确定";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // ReportFormatSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSubmit);
            this.Name = "ReportFormatSet";
            this.Text = "报表默认格式设置";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton_ShowFormat_Mea;
        private System.Windows.Forms.RadioButton radioButton_ShowFormat_Err;
        private System.Windows.Forms.RadioButton radioButton_ShowFormat_All;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnSubmit;
    }
}