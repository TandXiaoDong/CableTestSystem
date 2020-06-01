namespace CableTestManager.View.VSelfStydy
{
    partial class frmSefStudy
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSefStudy));
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.conductionThresholdByPin = new System.Windows.Forms.NumericUpDown();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.num_max = new System.Windows.Forms.NumericUpDown();
            this.num_min = new System.Windows.Forms.NumericUpDown();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.btn_defineStudyByPin = new Telerik.WinControls.UI.RadButton();
            this.btn_cancelByPin = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conductionThresholdByPin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_defineStudyByPin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelByPin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(132, 12);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(45, 21);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "1-384";
            this.radLabel2.ThemeName = "MaterialBlueGrey";
            // 
            // conductionThresholdByPin
            // 
            this.conductionThresholdByPin.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conductionThresholdByPin.Location = new System.Drawing.Point(508, 236);
            this.conductionThresholdByPin.Name = "conductionThresholdByPin";
            this.conductionThresholdByPin.Size = new System.Drawing.Size(120, 26);
            this.conductionThresholdByPin.TabIndex = 7;
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(408, 236);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(94, 21);
            this.radLabel5.TabIndex = 6;
            this.radLabel5.Text = "  导通阈值：";
            this.radLabel5.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(402, 185);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(102, 21);
            this.radLabel4.TabIndex = 5;
            this.radLabel4.Text = "学习最大值：";
            this.radLabel4.ThemeName = "MaterialBlueGrey";
            // 
            // num_max
            // 
            this.num_max.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_max.Location = new System.Drawing.Point(508, 183);
            this.num_max.Name = "num_max";
            this.num_max.Size = new System.Drawing.Size(120, 26);
            this.num_max.TabIndex = 4;
            // 
            // num_min
            // 
            this.num_min.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_min.Location = new System.Drawing.Point(508, 129);
            this.num_min.Name = "num_min";
            this.num_min.Size = new System.Drawing.Size(120, 26);
            this.num_min.TabIndex = 3;
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(402, 131);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(102, 21);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "学习最小值：";
            this.radLabel3.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(109, 21);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "  全学习范围：";
            this.radLabel1.ThemeName = "MaterialBlueGrey";
            // 
            // radGridView1
            // 
            this.radGridView1.BackColor = System.Drawing.SystemColors.Control;
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.radGridView1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(5, 32);
            // 
            // 
            // 
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "序号";
            gridViewTextBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.Width = 76;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "学习接口";
            gridViewTextBoxColumn2.Name = "column2";
            gridViewTextBoxColumn2.Width = 124;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.HeaderText = "选择";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "column3";
            gridViewCheckBoxColumn1.Width = 131;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCheckBoxColumn1});
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.Size = new System.Drawing.Size(374, 367);
            this.radGridView1.TabIndex = 14;
            this.radGridView1.ThemeName = "TelerikMetroTouch";
            // 
            // btn_defineStudyByPin
            // 
            this.btn_defineStudyByPin.Location = new System.Drawing.Point(508, 325);
            this.btn_defineStudyByPin.Name = "btn_defineStudyByPin";
            this.btn_defineStudyByPin.Size = new System.Drawing.Size(120, 36);
            this.btn_defineStudyByPin.TabIndex = 15;
            this.btn_defineStudyByPin.Text = "开始学习";
            this.btn_defineStudyByPin.ThemeName = "MaterialBlueGrey";
            // 
            // btn_cancelByPin
            // 
            this.btn_cancelByPin.Location = new System.Drawing.Point(508, 396);
            this.btn_cancelByPin.Name = "btn_cancelByPin";
            this.btn_cancelByPin.Size = new System.Drawing.Size(120, 36);
            this.btn_cancelByPin.TabIndex = 16;
            this.btn_cancelByPin.Text = "取消学习";
            this.btn_cancelByPin.ThemeName = "MaterialBlueGrey";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radGridView1);
            this.radGroupBox1.HeaderText = "接口列表";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 39);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(384, 404);
            this.radGroupBox1.TabIndex = 17;
            this.radGroupBox1.Text = "接口列表";
            this.radGroupBox1.ThemeName = "Office2013Light";
            // 
            // frmSefStudy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(664, 455);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.btn_cancelByPin);
            this.Controls.Add(this.btn_defineStudyByPin);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.conductionThresholdByPin);
            this.Controls.Add(this.num_min);
            this.Controls.Add(this.num_max);
            this.Controls.Add(this.radLabel5);
            this.Controls.Add(this.radLabel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSefStudy";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "自学习";
            this.ThemeName = "Office2013Light";
            this.Load += new System.EventHandler(this.frmSefStudy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conductionThresholdByPin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_defineStudyByPin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelByPin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private System.Windows.Forms.NumericUpDown num_max;
        private System.Windows.Forms.NumericUpDown num_min;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private System.Windows.Forms.NumericUpDown conductionThresholdByPin;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadButton btn_defineStudyByPin;
        private Telerik.WinControls.UI.RadButton btn_cancelByPin;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    }
}
