namespace CableTestManager.View.VInterface
{
    partial class BatchAddPinPoint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchAddPinPoint));
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.cb_nameRule = new System.Windows.Forms.ComboBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tb_startPin = new Telerik.WinControls.UI.RadTextBox();
            this.btn_apply = new Telerik.WinControls.UI.RadButton();
            this.btn_cancel = new Telerik.WinControls.UI.RadButton();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_startPin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_apply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(22, 37);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(65, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "命名规则：";
            // 
            // cb_nameRule
            // 
            this.cb_nameRule.FormattingEnabled = true;
            this.cb_nameRule.Items.AddRange(new object[] {
            "1，2，3，...（数字递增）"});
            this.cb_nameRule.Location = new System.Drawing.Point(93, 37);
            this.cb_nameRule.Name = "cb_nameRule";
            this.cb_nameRule.Size = new System.Drawing.Size(224, 20);
            this.cb_nameRule.TabIndex = 1;
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(22, 87);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(65, 18);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "起始针点：";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(22, 129);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(65, 18);
            this.radLabel3.TabIndex = 3;
            this.radLabel3.Text = "操作数量：";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(93, 126);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(224, 21);
            this.numericUpDown1.TabIndex = 4;
            // 
            // tb_startPin
            // 
            this.tb_startPin.Location = new System.Drawing.Point(93, 86);
            this.tb_startPin.Name = "tb_startPin";
            this.tb_startPin.Size = new System.Drawing.Size(224, 21);
            this.tb_startPin.TabIndex = 5;
            this.tb_startPin.ThemeName = "Office2013Light";
            // 
            // btn_apply
            // 
            this.btn_apply.Location = new System.Drawing.Point(131, 170);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(70, 24);
            this.btn_apply.TabIndex = 6;
            this.btn_apply.Text = "确定";
            this.btn_apply.ThemeName = "MaterialBlueGrey";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(247, 170);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(70, 24);
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.ThemeName = "MaterialBlueGrey";
            // 
            // BatchAddPinPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(354, 210);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.tb_startPin);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.cb_nameRule);
            this.Controls.Add(this.radLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BatchAddPinPoint";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "批量添加针点";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_startPin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_apply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.ComboBox cb_nameRule;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private Telerik.WinControls.UI.RadTextBox tb_startPin;
        private Telerik.WinControls.UI.RadButton btn_apply;
        private Telerik.WinControls.UI.RadButton btn_cancel;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
    }
}
