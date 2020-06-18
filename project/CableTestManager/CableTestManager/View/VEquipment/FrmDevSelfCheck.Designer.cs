namespace CableTestManager.View.VEquipment
{
    partial class FrmDevSelfCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDevSelfCheck));
            this.btn_startCheck = new Telerik.WinControls.UI.RadButton();
            this.tb_checkResult = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.lbx_checkTip = new Telerik.WinControls.UI.RadLabel();
            this.btn_exit = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btn_startCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_checkResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbx_checkTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_startCheck
            // 
            this.btn_startCheck.BackColor = System.Drawing.Color.GhostWhite;
            this.btn_startCheck.Location = new System.Drawing.Point(106, 34);
            this.btn_startCheck.Name = "btn_startCheck";
            this.btn_startCheck.Size = new System.Drawing.Size(120, 36);
            this.btn_startCheck.TabIndex = 0;
            this.btn_startCheck.Text = "开始自检";
            this.btn_startCheck.ThemeName = "MaterialBlueGrey";
            // 
            // tb_checkResult
            // 
            this.tb_checkResult.Location = new System.Drawing.Point(104, 102);
            this.tb_checkResult.Name = "tb_checkResult";
            this.tb_checkResult.Size = new System.Drawing.Size(119, 36);
            this.tb_checkResult.TabIndex = 1;
            this.tb_checkResult.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 117);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(86, 21);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "自检结果：";
            this.radLabel1.ThemeName = "MaterialBlueGrey";
            // 
            // lbx_checkTip
            // 
            this.lbx_checkTip.Location = new System.Drawing.Point(106, 145);
            this.lbx_checkTip.Name = "lbx_checkTip";
            this.lbx_checkTip.Size = new System.Drawing.Size(150, 21);
            this.lbx_checkTip.TabIndex = 3;
            this.lbx_checkTip.Text = "自检结果超出设定值";
            this.lbx_checkTip.ThemeName = "MaterialBlueGrey";
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.GhostWhite;
            this.btn_exit.Location = new System.Drawing.Point(107, 188);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(120, 36);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "退出";
            this.btn_exit.ThemeName = "MaterialBlueGrey";
            // 
            // FrmDevSelfCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(320, 262);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.lbx_checkTip);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.tb_checkResult);
            this.Controls.Add(this.btn_startCheck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDevSelfCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设备自检";
            this.Load += new System.EventHandler(this.FrmDevSelfCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_startCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_checkResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbx_checkTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_exit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btn_startCheck;
        private Telerik.WinControls.UI.RadTextBox tb_checkResult;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel lbx_checkTip;
        private Telerik.WinControls.UI.RadButton btn_exit;
    }
}