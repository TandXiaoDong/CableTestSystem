namespace CableTestManager.View
{
    partial class ReportFileTypeSelect
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
            this.btnOK = new System.Windows.Forms.Button();
            this.radioButton_Pdf = new System.Windows.Forms.RadioButton();
            this.radioButton_Word = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(351, 253);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 24);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // radioButton_Pdf
            // 
            this.radioButton_Pdf.AutoSize = true;
            this.radioButton_Pdf.Checked = true;
            this.radioButton_Pdf.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_Pdf.Location = new System.Drawing.Point(419, 174);
            this.radioButton_Pdf.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_Pdf.Name = "radioButton_Pdf";
            this.radioButton_Pdf.Size = new System.Drawing.Size(79, 19);
            this.radioButton_Pdf.TabIndex = 2;
            this.radioButton_Pdf.TabStop = true;
            this.radioButton_Pdf.Text = "PDF文档";
            this.radioButton_Pdf.UseVisualStyleBackColor = true;
            // 
            // radioButton_Word
            // 
            this.radioButton_Word.AutoSize = true;
            this.radioButton_Word.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_Word.Location = new System.Drawing.Point(302, 174);
            this.radioButton_Word.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_Word.Name = "radioButton_Word";
            this.radioButton_Word.Size = new System.Drawing.Size(87, 19);
            this.radioButton_Word.TabIndex = 3;
            this.radioButton_Word.Text = "WORD文档";
            this.radioButton_Word.UseVisualStyleBackColor = true;
            // 
            // ReportFileTypeSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.radioButton_Pdf);
            this.Controls.Add(this.radioButton_Word);
            this.Name = "ReportFileTypeSelect";
            this.Text = "报表文件类型选择";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton radioButton_Pdf;
        private System.Windows.Forms.RadioButton radioButton_Word;
    }
}