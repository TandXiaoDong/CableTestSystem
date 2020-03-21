namespace CableTestManager.View
{
    partial class OneClickTestConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OneClickTestConfig));
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.cb_conductTest = new Telerik.WinControls.UI.RadCheckBox();
            this.cb_insulateTest = new Telerik.WinControls.UI.RadCheckBox();
            this.cb_circuitTest = new Telerik.WinControls.UI.RadCheckBox();
            this.cb_pressureProofTest = new Telerik.WinControls.UI.RadCheckBox();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btn_oneClickTest = new Telerik.WinControls.UI.RadButton();
            this.btn_cancelTest = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.cb_conductTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_insulateTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_circuitTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_pressureProofTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_oneClickTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_conductTest
            // 
            this.cb_conductTest.Location = new System.Drawing.Point(69, 47);
            this.cb_conductTest.Name = "cb_conductTest";
            this.cb_conductTest.Size = new System.Drawing.Size(89, 19);
            this.cb_conductTest.TabIndex = 0;
            this.cb_conductTest.Text = "导通测试";
            this.cb_conductTest.ThemeName = "MaterialBlueGrey";
            // 
            // cb_insulateTest
            // 
            this.cb_insulateTest.Location = new System.Drawing.Point(69, 94);
            this.cb_insulateTest.Name = "cb_insulateTest";
            this.cb_insulateTest.Size = new System.Drawing.Size(89, 19);
            this.cb_insulateTest.TabIndex = 1;
            this.cb_insulateTest.Text = "绝缘测试";
            this.cb_insulateTest.ThemeName = "MaterialBlueGrey";
            // 
            // cb_circuitTest
            // 
            this.cb_circuitTest.Location = new System.Drawing.Point(202, 47);
            this.cb_circuitTest.Name = "cb_circuitTest";
            this.cb_circuitTest.Size = new System.Drawing.Size(89, 19);
            this.cb_circuitTest.TabIndex = 1;
            this.cb_circuitTest.Text = "短路测试";
            this.cb_circuitTest.ThemeName = "MaterialBlueGrey";
            // 
            // cb_pressureProofTest
            // 
            this.cb_pressureProofTest.Location = new System.Drawing.Point(202, 94);
            this.cb_pressureProofTest.Name = "cb_pressureProofTest";
            this.cb_pressureProofTest.Size = new System.Drawing.Size(89, 19);
            this.cb_pressureProofTest.TabIndex = 1;
            this.cb_pressureProofTest.Text = "耐压测试";
            this.cb_pressureProofTest.ThemeName = "MaterialBlueGrey";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.radGroupBox1.Controls.Add(this.cb_conductTest);
            this.radGroupBox1.Controls.Add(this.cb_circuitTest);
            this.radGroupBox1.Controls.Add(this.cb_insulateTest);
            this.radGroupBox1.Controls.Add(this.cb_pressureProofTest);
            this.radGroupBox1.HeaderText = "测试项选择";
            this.radGroupBox1.Location = new System.Drawing.Point(24, 22);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(349, 142);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.Text = "测试项选择";
            this.radGroupBox1.ThemeName = "Office2013Light";
            // 
            // btn_oneClickTest
            // 
            this.btn_oneClickTest.Location = new System.Drawing.Point(52, 182);
            this.btn_oneClickTest.Name = "btn_oneClickTest";
            this.btn_oneClickTest.Size = new System.Drawing.Size(120, 36);
            this.btn_oneClickTest.TabIndex = 3;
            this.btn_oneClickTest.Text = "一键测试";
            this.btn_oneClickTest.ThemeName = "MaterialBlueGrey";
            // 
            // btn_cancelTest
            // 
            this.btn_cancelTest.Location = new System.Drawing.Point(253, 182);
            this.btn_cancelTest.Name = "btn_cancelTest";
            this.btn_cancelTest.Size = new System.Drawing.Size(120, 36);
            this.btn_cancelTest.TabIndex = 4;
            this.btn_cancelTest.Text = "取消测试";
            this.btn_cancelTest.ThemeName = "MaterialBlueGrey";
            // 
            // OneClickTestConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(417, 242);
            this.Controls.Add(this.btn_cancelTest);
            this.Controls.Add(this.btn_oneClickTest);
            this.Controls.Add(this.radGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OneClickTestConfig";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "一键测试";
            this.ThemeName = "Office2013Light";
            this.Load += new System.EventHandler(this.OneClickTestConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cb_conductTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_insulateTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_circuitTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_pressureProofTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_oneClickTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.UI.RadCheckBox cb_conductTest;
        private Telerik.WinControls.UI.RadCheckBox cb_insulateTest;
        private Telerik.WinControls.UI.RadCheckBox cb_circuitTest;
        private Telerik.WinControls.UI.RadCheckBox cb_pressureProofTest;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btn_oneClickTest;
        private Telerik.WinControls.UI.RadButton btn_cancelTest;
    }
}
