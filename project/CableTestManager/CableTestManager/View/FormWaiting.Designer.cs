namespace CableTestManager.View
{
    partial class FormWaiting
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
            this.label_ShowStr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_ShowStr
            // 
            this.label_ShowStr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ShowStr.Font = new System.Drawing.Font("宋体", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ShowStr.Location = new System.Drawing.Point(9, 201);
            this.label_ShowStr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ShowStr.Name = "label_ShowStr";
            this.label_ShowStr.Size = new System.Drawing.Size(782, 48);
            this.label_ShowStr.TabIndex = 1;
            this.label_ShowStr.Text = "正在生成报表，请稍等..";
            this.label_ShowStr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormWaiting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_ShowStr);
            this.Name = "FormWaiting";
            this.Text = "FormWaiting";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_ShowStr;
    }
}