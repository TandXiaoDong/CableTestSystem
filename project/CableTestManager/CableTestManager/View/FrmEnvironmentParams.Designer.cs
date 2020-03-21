namespace CableTestManager.View
{
    partial class FrmEnvironmentParams
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEnvironmentParams));
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.tb_temperature = new Telerik.WinControls.UI.RadTextBox();
            this.tb_ambientHumidity = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.btn_apply = new Telerik.WinControls.UI.RadButton();
            this.btn_cancel = new Telerik.WinControls.UI.RadButton();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_temperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ambientHumidity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_apply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 48);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(86, 21);
            this.radLabel1.TabIndex = 20;
            this.radLabel1.Text = "环境温度：";
            this.radLabel1.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 97);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(86, 21);
            this.radLabel2.TabIndex = 21;
            this.radLabel2.Text = "环境湿度：";
            this.radLabel2.ThemeName = "MaterialBlueGrey";
            // 
            // tb_temperature
            // 
            this.tb_temperature.Location = new System.Drawing.Point(104, 33);
            this.tb_temperature.Name = "tb_temperature";
            this.tb_temperature.Size = new System.Drawing.Size(145, 36);
            this.tb_temperature.TabIndex = 22;
            this.tb_temperature.ThemeName = "MaterialBlueGrey";
            // 
            // tb_ambientHumidity
            // 
            this.tb_ambientHumidity.Location = new System.Drawing.Point(104, 82);
            this.tb_ambientHumidity.Name = "tb_ambientHumidity";
            this.tb_ambientHumidity.Size = new System.Drawing.Size(145, 36);
            this.tb_ambientHumidity.TabIndex = 23;
            this.tb_ambientHumidity.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(255, 48);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(121, 18);
            this.radLabel3.TabIndex = 24;
            this.radLabel3.Text = "℃ (取值范围: 0~50℃)";
            this.radLabel3.ThemeName = "ControlDefault";
            // 
            // btn_apply
            // 
            this.btn_apply.Location = new System.Drawing.Point(104, 145);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(93, 36);
            this.btn_apply.TabIndex = 26;
            this.btn_apply.Text = "确定";
            this.btn_apply.ThemeName = "MaterialBlueGrey";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(255, 145);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(92, 36);
            this.btn_cancel.TabIndex = 27;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(255, 97);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(126, 18);
            this.radLabel4.TabIndex = 28;
            this.radLabel4.Text = "%  (取值范围: 20~85 %)";
            this.radLabel4.ThemeName = "ControlDefault";
            // 
            // FrmEnvironmentParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(403, 202);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.tb_ambientHumidity);
            this.Controls.Add(this.tb_temperature);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEnvironmentParams";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "试验环境参数";
            this.ThemeName = "Office2013Light";
            this.Load += new System.EventHandler(this.FrmEnvironmentParams_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_temperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ambientHumidity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_apply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox tb_temperature;
        private Telerik.WinControls.UI.RadTextBox tb_ambientHumidity;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadButton btn_apply;
        private Telerik.WinControls.UI.RadButton btn_cancel;
        private Telerik.WinControls.UI.RadLabel radLabel4;
    }
}
