namespace CableTestManager.View.VInterface
{
    partial class AddSwitchWorkWear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSwitchWorkWear));
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.tb_switchWorkWearCode = new Telerik.WinControls.UI.RadTextBox();
            this.tb_switchType = new Telerik.WinControls.UI.RadTextBox();
            this.tb_remark = new Telerik.WinControls.UI.RadTextBox();
            this.btn_apply = new Telerik.WinControls.UI.RadButton();
            this.btn_cancel = new Telerik.WinControls.UI.RadButton();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_switchWorkWearCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_switchType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_remark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_apply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 39);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(118, 21);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "转接工装代号：";
            this.radLabel1.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(43, 91);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(86, 21);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "转接型号：";
            this.radLabel2.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(74, 141);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(55, 21);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "备注：";
            this.radLabel3.ThemeName = "MaterialBlueGrey";
            // 
            // tb_switchWorkWearCode
            // 
            this.tb_switchWorkWearCode.Location = new System.Drawing.Point(138, 24);
            this.tb_switchWorkWearCode.Name = "tb_switchWorkWearCode";
            this.tb_switchWorkWearCode.Size = new System.Drawing.Size(241, 36);
            this.tb_switchWorkWearCode.TabIndex = 3;
            this.tb_switchWorkWearCode.ThemeName = "MaterialBlueGrey";
            // 
            // tb_switchType
            // 
            this.tb_switchType.Location = new System.Drawing.Point(138, 76);
            this.tb_switchType.Name = "tb_switchType";
            this.tb_switchType.Size = new System.Drawing.Size(241, 36);
            this.tb_switchType.TabIndex = 4;
            this.tb_switchType.ThemeName = "MaterialBlueGrey";
            // 
            // tb_remark
            // 
            this.tb_remark.Location = new System.Drawing.Point(138, 126);
            this.tb_remark.Name = "tb_remark";
            this.tb_remark.Size = new System.Drawing.Size(241, 36);
            this.tb_remark.TabIndex = 5;
            this.tb_remark.ThemeName = "MaterialBlueGrey";
            // 
            // btn_apply
            // 
            this.btn_apply.Location = new System.Drawing.Point(138, 187);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(110, 36);
            this.btn_apply.TabIndex = 6;
            this.btn_apply.Text = "确定";
            this.btn_apply.ThemeName = "MaterialBlueGrey";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(269, 187);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(110, 36);
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.ThemeName = "MaterialBlueGrey";
            // 
            // AddSwitchWorkWear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(396, 228);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.tb_remark);
            this.Controls.Add(this.tb_switchType);
            this.Controls.Add(this.tb_switchWorkWearCode);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddSwitchWorkWear";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "添加转接工装";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_switchWorkWearCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_switchType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_remark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_apply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox tb_switchWorkWearCode;
        private Telerik.WinControls.UI.RadTextBox tb_switchType;
        private Telerik.WinControls.UI.RadTextBox tb_remark;
        private Telerik.WinControls.UI.RadButton btn_apply;
        private Telerik.WinControls.UI.RadButton btn_cancel;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
    }
}
