namespace CableTestManager.View
{
    partial class RadProbMeasure
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadProbMeasure));
            this.groupBox_Debugging = new System.Windows.Forms.GroupBox();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_InterCancel = new Telerik.WinControls.UI.RadButton();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.conductionThresholdByPin = new System.Windows.Forms.NumericUpDown();
            this.btn_InterStart = new Telerik.WinControls.UI.RadButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_fcancel = new Telerik.WinControls.UI.RadButton();
            this.num_fthreshold = new System.Windows.Forms.NumericUpDown();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.btn_fstartTest = new Telerik.WinControls.UI.RadButton();
            this.num_fmaxPin = new System.Windows.Forms.NumericUpDown();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.num_fminPin = new System.Windows.Forms.NumericUpDown();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.cobInter = new Telerik.WinControls.UI.RadMultiColumnComboBox();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.groupBox_Debugging.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_InterCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conductionThresholdByPin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_InterStart)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_fcancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fthreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_fstartTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fmaxPin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fminPin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobInter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobInter.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobInter.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_Debugging
            // 
            this.groupBox_Debugging.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox_Debugging.Controls.Add(this.tabControl3);
            this.groupBox_Debugging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Debugging.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox_Debugging.Location = new System.Drawing.Point(0, 0);
            this.groupBox_Debugging.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Debugging.Name = "groupBox_Debugging";
            this.groupBox_Debugging.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Debugging.Size = new System.Drawing.Size(410, 371);
            this.groupBox_Debugging.TabIndex = 8;
            this.groupBox_Debugging.TabStop = false;
            // 
            // tabControl3
            // 
            this.tabControl3.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl3.Controls.Add(this.tabPage1);
            this.tabControl3.Controls.Add(this.tabPage2);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(2, 19);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(406, 350);
            this.tabControl3.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(398, 319);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "接口方式寻址";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radLabel9);
            this.panel1.Controls.Add(this.cobInter);
            this.panel1.Controls.Add(this.btn_InterCancel);
            this.panel1.Controls.Add(this.radLabel5);
            this.panel1.Controls.Add(this.conductionThresholdByPin);
            this.panel1.Controls.Add(this.btn_InterStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 313);
            this.panel1.TabIndex = 0;
            // 
            // btn_InterCancel
            // 
            this.btn_InterCancel.BackColor = System.Drawing.Color.GhostWhite;
            this.btn_InterCancel.Location = new System.Drawing.Point(210, 214);
            this.btn_InterCancel.Name = "btn_InterCancel";
            this.btn_InterCancel.Size = new System.Drawing.Size(107, 36);
            this.btn_InterCancel.TabIndex = 27;
            this.btn_InterCancel.Text = "取消";
            this.btn_InterCancel.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(42, 138);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(94, 21);
            this.radLabel5.TabIndex = 23;
            this.radLabel5.Text = "  导通阈值：";
            this.radLabel5.ThemeName = "MaterialBlueGrey";
            // 
            // conductionThresholdByPin
            // 
            this.conductionThresholdByPin.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conductionThresholdByPin.Location = new System.Drawing.Point(138, 136);
            this.conductionThresholdByPin.Name = "conductionThresholdByPin";
            this.conductionThresholdByPin.Size = new System.Drawing.Size(179, 26);
            this.conductionThresholdByPin.TabIndex = 24;
            // 
            // btn_InterStart
            // 
            this.btn_InterStart.BackColor = System.Drawing.Color.GhostWhite;
            this.btn_InterStart.Location = new System.Drawing.Point(72, 214);
            this.btn_InterStart.Name = "btn_InterStart";
            this.btn_InterStart.Size = new System.Drawing.Size(107, 36);
            this.btn_InterStart.TabIndex = 26;
            this.btn_InterStart.Text = "启动测试";
            this.btn_InterStart.ThemeName = "MaterialBlueGrey";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(398, 319);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "范围方式寻址";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_fcancel);
            this.panel2.Controls.Add(this.num_fthreshold);
            this.panel2.Controls.Add(this.radLabel6);
            this.panel2.Controls.Add(this.btn_fstartTest);
            this.panel2.Controls.Add(this.num_fmaxPin);
            this.panel2.Controls.Add(this.radLabel2);
            this.panel2.Controls.Add(this.num_fminPin);
            this.panel2.Controls.Add(this.radLabel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 313);
            this.panel2.TabIndex = 0;
            // 
            // btn_fcancel
            // 
            this.btn_fcancel.Location = new System.Drawing.Point(224, 237);
            this.btn_fcancel.Name = "btn_fcancel";
            this.btn_fcancel.Size = new System.Drawing.Size(102, 36);
            this.btn_fcancel.TabIndex = 27;
            this.btn_fcancel.Text = "取消测试";
            this.btn_fcancel.ThemeName = "MaterialBlueGrey";
            // 
            // num_fthreshold
            // 
            this.num_fthreshold.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_fthreshold.Location = new System.Drawing.Point(169, 158);
            this.num_fthreshold.Name = "num_fthreshold";
            this.num_fthreshold.Size = new System.Drawing.Size(138, 26);
            this.num_fthreshold.TabIndex = 26;
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(69, 158);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(94, 21);
            this.radLabel6.TabIndex = 25;
            this.radLabel6.Text = "  导通阈值：";
            this.radLabel6.ThemeName = "MaterialBlueGrey";
            // 
            // btn_fstartTest
            // 
            this.btn_fstartTest.Location = new System.Drawing.Point(100, 237);
            this.btn_fstartTest.Name = "btn_fstartTest";
            this.btn_fstartTest.Size = new System.Drawing.Size(101, 36);
            this.btn_fstartTest.TabIndex = 25;
            this.btn_fstartTest.Text = "启动测试";
            this.btn_fstartTest.ThemeName = "MaterialBlueGrey";
            // 
            // num_fmaxPin
            // 
            this.num_fmaxPin.Location = new System.Drawing.Point(169, 110);
            this.num_fmaxPin.Name = "num_fmaxPin";
            this.num_fmaxPin.Size = new System.Drawing.Size(138, 24);
            this.num_fmaxPin.TabIndex = 3;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(77, 113);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(86, 21);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "终止针脚：";
            this.radLabel2.ThemeName = "MaterialBlueGrey";
            // 
            // num_fminPin
            // 
            this.num_fminPin.Location = new System.Drawing.Point(169, 59);
            this.num_fminPin.Name = "num_fminPin";
            this.num_fminPin.Size = new System.Drawing.Size(138, 24);
            this.num_fminPin.TabIndex = 1;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(77, 62);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(86, 21);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "起始针脚：";
            this.radLabel1.ThemeName = "MaterialBlueGrey";
            // 
            // cobInter
            // 
            // 
            // cobInter.NestedRadGridView
            // 
            this.cobInter.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.cobInter.EditorControl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cobInter.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cobInter.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.cobInter.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.cobInter.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.cobInter.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.cobInter.EditorControl.MasterTemplate.EnableGrouping = false;
            this.cobInter.EditorControl.MasterTemplate.ShowFilteringRow = false;
            this.cobInter.EditorControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.cobInter.EditorControl.Name = "NestedRadGridView";
            this.cobInter.EditorControl.ReadOnly = true;
            this.cobInter.EditorControl.ShowGroupPanel = false;
            this.cobInter.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.cobInter.EditorControl.TabIndex = 0;
            this.cobInter.Location = new System.Drawing.Point(138, 67);
            this.cobInter.Name = "cobInter";
            this.cobInter.Size = new System.Drawing.Size(179, 36);
            this.cobInter.TabIndex = 19;
            this.cobInter.TabStop = false;
            this.cobInter.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel9
            // 
            this.radLabel9.Location = new System.Drawing.Point(40, 79);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(96, 21);
            this.radLabel9.TabIndex = 18;
            this.radLabel9.Text = "选择接口A：";
            this.radLabel9.ThemeName = "MaterialBlueGrey";
            // 
            // RadProbMeasure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(410, 371);
            this.Controls.Add(this.groupBox_Debugging);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RadProbMeasure";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "探针";
            this.ThemeName = "Office2013Light";
            this.Load += new System.EventHandler(this.RadProbMeasure_Load);
            this.groupBox_Debugging.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_InterCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conductionThresholdByPin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_InterStart)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_fcancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fthreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_fstartTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fmaxPin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fminPin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobInter.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobInter.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobInter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox_Debugging;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private Telerik.WinControls.UI.RadButton btn_fstartTest;
        private System.Windows.Forms.NumericUpDown conductionThresholdByPin;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown num_fmaxPin;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.NumericUpDown num_fminPin;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.NumericUpDown num_fthreshold;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadButton btn_InterCancel;
        private Telerik.WinControls.UI.RadButton btn_InterStart;
        private Telerik.WinControls.UI.RadButton btn_fcancel;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadMultiColumnComboBox cobInter;
    }
}
