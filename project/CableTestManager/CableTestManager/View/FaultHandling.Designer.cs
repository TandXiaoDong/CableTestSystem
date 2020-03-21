namespace CableTestManager.View
{
    partial class FaultHandling
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
            this.label_djs = new System.Windows.Forms.Label();
            this.label_ts = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_djs
            // 
            this.label_djs.AutoSize = true;
            this.label_djs.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_djs.Location = new System.Drawing.Point(357, 251);
            this.label_djs.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_djs.Name = "label_djs";
            this.label_djs.Size = new System.Drawing.Size(91, 15);
            this.label_djs.TabIndex = 3;
            this.label_djs.Text = "倒计时 5 秒";
            // 
            // label_ts
            // 
            this.label_ts.AutoSize = true;
            this.label_ts.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ts.ForeColor = System.Drawing.Color.Red;
            this.label_ts.Location = new System.Drawing.Point(318, 185);
            this.label_ts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ts.Name = "label_ts";
            this.label_ts.Size = new System.Drawing.Size(165, 15);
            this.label_ts.TabIndex = 2;
            this.label_ts.Text = "系统出现故障即将关闭!";
            // 
            // FaultHandling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_djs);
            this.Controls.Add(this.label_ts);
            this.Name = "FaultHandling";
            this.Text = "系统故障";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_djs;
        private System.Windows.Forms.Label label_ts;
    }
}