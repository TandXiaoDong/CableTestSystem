namespace CableTestManager.View
{
    partial class BarcodeScanOpenProject
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
            this.btnOpenProj = new System.Windows.Forms.Button();
            this.btnTMSM = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_tm = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOpenProj
            // 
            this.btnOpenProj.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenProj.Location = new System.Drawing.Point(275, 246);
            this.btnOpenProj.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenProj.Name = "btnOpenProj";
            this.btnOpenProj.Size = new System.Drawing.Size(322, 24);
            this.btnOpenProj.TabIndex = 27;
            this.btnOpenProj.Text = "打开项目";
            this.btnOpenProj.UseVisualStyleBackColor = true;
            // 
            // btnTMSM
            // 
            this.btnTMSM.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTMSM.Location = new System.Drawing.Point(478, 181);
            this.btnTMSM.Margin = new System.Windows.Forms.Padding(2);
            this.btnTMSM.Name = "btnTMSM";
            this.btnTMSM.Size = new System.Drawing.Size(120, 24);
            this.btnTMSM.TabIndex = 28;
            this.btnTMSM.Text = "条码扫描";
            this.btnTMSM.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(203, 186);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "项目名:";
            // 
            // textBox_tm
            // 
            this.textBox_tm.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_tm.Location = new System.Drawing.Point(275, 182);
            this.textBox_tm.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_tm.Name = "textBox_tm";
            this.textBox_tm.Size = new System.Drawing.Size(181, 24);
            this.textBox_tm.TabIndex = 25;
            // 
            // BarcodeScanOpenProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOpenProj);
            this.Controls.Add(this.btnTMSM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_tm);
            this.Name = "BarcodeScanOpenProject";
            this.Text = "扫码快速打开项目";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenProj;
        private System.Windows.Forms.Button btnTMSM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_tm;
    }
}