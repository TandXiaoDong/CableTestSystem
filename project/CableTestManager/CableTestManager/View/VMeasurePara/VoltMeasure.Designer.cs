namespace CableTestManager.View
{
    partial class VoltMeasure
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
            this.label_QTC = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_HVAC_RV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_HV_AC = new System.Windows.Forms.NumericUpDown();
            this.btn_HVAC_QUERY = new System.Windows.Forms.Button();
            this.btn_HVAC_OUT = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_LVDC_RV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown_LV_DC = new System.Windows.Forms.NumericUpDown();
            this.btn_LVDC_QUERY = new System.Windows.Forms.Button();
            this.btn_LVDC_OUT = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_HVDC_RV = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown_HV_DC = new System.Windows.Forms.NumericUpDown();
            this.btn_HVDC_QUERY = new System.Windows.Forms.Button();
            this.btn_HVDC_OUT = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HV_AC)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_LV_DC)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HV_DC)).BeginInit();
            this.SuspendLayout();
            // 
            // label_QTC
            // 
            this.label_QTC.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_QTC.Location = new System.Drawing.Point(332, 37);
            this.label_QTC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_QTC.Name = "label_QTC";
            this.label_QTC.Size = new System.Drawing.Size(135, 24);
            this.label_QTC.TabIndex = 13;
            this.label_QTC.Text = "查询计时: 0 秒";
            this.label_QTC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Location = new System.Drawing.Point(332, 488);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(135, 24);
            this.btnQuit.TabIndex = 12;
            this.btnQuit.Text = "关闭";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_HVAC_RV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDown_HV_AC);
            this.groupBox1.Controls.Add(this.btn_HVAC_QUERY);
            this.groupBox1.Controls.Add(this.btn_HVAC_OUT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(22, 307);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(756, 96);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HV-AC";
            // 
            // textBox_HVAC_RV
            // 
            this.textBox_HVAC_RV.Location = new System.Drawing.Point(556, 41);
            this.textBox_HVAC_RV.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_HVAC_RV.Name = "textBox_HVAC_RV";
            this.textBox_HVAC_RV.ReadOnly = true;
            this.textBox_HVAC_RV.Size = new System.Drawing.Size(114, 24);
            this.textBox_HVAC_RV.TabIndex = 7;
            this.textBox_HVAC_RV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(494, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "返回值:";
            // 
            // numericUpDown_HV_AC
            // 
            this.numericUpDown_HV_AC.Location = new System.Drawing.Point(97, 41);
            this.numericUpDown_HV_AC.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown_HV_AC.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_HV_AC.Name = "numericUpDown_HV_AC";
            this.numericUpDown_HV_AC.Size = new System.Drawing.Size(120, 24);
            this.numericUpDown_HV_AC.TabIndex = 5;
            this.numericUpDown_HV_AC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_HV_AC.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btn_HVAC_QUERY
            // 
            this.btn_HVAC_QUERY.Location = new System.Drawing.Point(310, 40);
            this.btn_HVAC_QUERY.Margin = new System.Windows.Forms.Padding(2);
            this.btn_HVAC_QUERY.Name = "btn_HVAC_QUERY";
            this.btn_HVAC_QUERY.Size = new System.Drawing.Size(135, 24);
            this.btn_HVAC_QUERY.TabIndex = 6;
            this.btn_HVAC_QUERY.Text = "输出并查询";
            this.btn_HVAC_QUERY.UseVisualStyleBackColor = true;
            // 
            // btn_HVAC_OUT
            // 
            this.btn_HVAC_OUT.Location = new System.Drawing.Point(277, 40);
            this.btn_HVAC_OUT.Margin = new System.Windows.Forms.Padding(2);
            this.btn_HVAC_OUT.Name = "btn_HVAC_OUT";
            this.btn_HVAC_OUT.Size = new System.Drawing.Size(15, 24);
            this.btn_HVAC_OUT.TabIndex = 6;
            this.btn_HVAC_OUT.Text = "输出";
            this.btn_HVAC_OUT.UseVisualStyleBackColor = true;
            this.btn_HVAC_OUT.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "测量值:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(675, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "VAC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 45);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "VAC";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_LVDC_RV);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numericUpDown_LV_DC);
            this.groupBox2.Controls.Add(this.btn_LVDC_QUERY);
            this.groupBox2.Controls.Add(this.btn_LVDC_OUT);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(22, 191);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(756, 96);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LV-DC";
            this.groupBox2.Visible = false;
            // 
            // textBox_LVDC_RV
            // 
            this.textBox_LVDC_RV.Location = new System.Drawing.Point(556, 41);
            this.textBox_LVDC_RV.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_LVDC_RV.Name = "textBox_LVDC_RV";
            this.textBox_LVDC_RV.ReadOnly = true;
            this.textBox_LVDC_RV.Size = new System.Drawing.Size(114, 24);
            this.textBox_LVDC_RV.TabIndex = 7;
            this.textBox_LVDC_RV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_LVDC_RV.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(494, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "返回值:";
            this.label5.Visible = false;
            // 
            // numericUpDown_LV_DC
            // 
            this.numericUpDown_LV_DC.DecimalPlaces = 1;
            this.numericUpDown_LV_DC.Location = new System.Drawing.Point(97, 41);
            this.numericUpDown_LV_DC.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown_LV_DC.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.numericUpDown_LV_DC.Name = "numericUpDown_LV_DC";
            this.numericUpDown_LV_DC.Size = new System.Drawing.Size(120, 24);
            this.numericUpDown_LV_DC.TabIndex = 5;
            this.numericUpDown_LV_DC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_LV_DC.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btn_LVDC_QUERY
            // 
            this.btn_LVDC_QUERY.Location = new System.Drawing.Point(450, 40);
            this.btn_LVDC_QUERY.Margin = new System.Windows.Forms.Padding(2);
            this.btn_LVDC_QUERY.Name = "btn_LVDC_QUERY";
            this.btn_LVDC_QUERY.Size = new System.Drawing.Size(21, 24);
            this.btn_LVDC_QUERY.TabIndex = 6;
            this.btn_LVDC_QUERY.Text = "输出并查询";
            this.btn_LVDC_QUERY.UseVisualStyleBackColor = true;
            this.btn_LVDC_QUERY.Visible = false;
            // 
            // btn_LVDC_OUT
            // 
            this.btn_LVDC_OUT.Location = new System.Drawing.Point(310, 40);
            this.btn_LVDC_OUT.Margin = new System.Windows.Forms.Padding(2);
            this.btn_LVDC_OUT.Name = "btn_LVDC_OUT";
            this.btn_LVDC_OUT.Size = new System.Drawing.Size(135, 24);
            this.btn_LVDC_OUT.TabIndex = 6;
            this.btn_LVDC_OUT.Text = "输出";
            this.btn_LVDC_OUT.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 45);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "测量值:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(675, 45);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "VDC";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(224, 45);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "VDC";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_HVDC_RV);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.numericUpDown_HV_DC);
            this.groupBox4.Controls.Add(this.btn_HVDC_QUERY);
            this.groupBox4.Controls.Add(this.btn_HVDC_OUT);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(22, 75);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(756, 96);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "HV-DC";
            // 
            // textBox_HVDC_RV
            // 
            this.textBox_HVDC_RV.Location = new System.Drawing.Point(556, 41);
            this.textBox_HVDC_RV.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_HVDC_RV.Name = "textBox_HVDC_RV";
            this.textBox_HVDC_RV.ReadOnly = true;
            this.textBox_HVDC_RV.Size = new System.Drawing.Size(114, 24);
            this.textBox_HVDC_RV.TabIndex = 7;
            this.textBox_HVDC_RV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(494, 45);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 15);
            this.label11.TabIndex = 3;
            this.label11.Text = "返回值:";
            // 
            // numericUpDown_HV_DC
            // 
            this.numericUpDown_HV_DC.Location = new System.Drawing.Point(97, 41);
            this.numericUpDown_HV_DC.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown_HV_DC.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.numericUpDown_HV_DC.Name = "numericUpDown_HV_DC";
            this.numericUpDown_HV_DC.Size = new System.Drawing.Size(120, 24);
            this.numericUpDown_HV_DC.TabIndex = 5;
            this.numericUpDown_HV_DC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_HV_DC.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btn_HVDC_QUERY
            // 
            this.btn_HVDC_QUERY.Location = new System.Drawing.Point(310, 40);
            this.btn_HVDC_QUERY.Margin = new System.Windows.Forms.Padding(2);
            this.btn_HVDC_QUERY.Name = "btn_HVDC_QUERY";
            this.btn_HVDC_QUERY.Size = new System.Drawing.Size(135, 24);
            this.btn_HVDC_QUERY.TabIndex = 6;
            this.btn_HVDC_QUERY.Text = "输出并查询";
            this.btn_HVDC_QUERY.UseVisualStyleBackColor = true;
            // 
            // btn_HVDC_OUT
            // 
            this.btn_HVDC_OUT.Location = new System.Drawing.Point(277, 40);
            this.btn_HVDC_OUT.Margin = new System.Windows.Forms.Padding(2);
            this.btn_HVDC_OUT.Name = "btn_HVDC_OUT";
            this.btn_HVDC_OUT.Size = new System.Drawing.Size(15, 24);
            this.btn_HVDC_OUT.TabIndex = 6;
            this.btn_HVDC_OUT.Text = "输出";
            this.btn_HVDC_OUT.UseVisualStyleBackColor = true;
            this.btn_HVDC_OUT.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 45);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "测量值:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(675, 45);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "VDC";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(224, 45);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "VDC";
            // 
            // VoltMeasure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 549);
            this.Controls.Add(this.label_QTC);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Name = "VoltMeasure";
            this.Text = "电压测量";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HV_AC)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_LV_DC)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HV_DC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_QTC;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_HVAC_RV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_HV_AC;
        private System.Windows.Forms.Button btn_HVAC_QUERY;
        private System.Windows.Forms.Button btn_HVAC_OUT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_LVDC_RV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown_LV_DC;
        private System.Windows.Forms.Button btn_LVDC_QUERY;
        private System.Windows.Forms.Button btn_LVDC_OUT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_HVDC_RV;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDown_HV_DC;
        private System.Windows.Forms.Button btn_HVDC_QUERY;
        private System.Windows.Forms.Button btn_HVDC_OUT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}