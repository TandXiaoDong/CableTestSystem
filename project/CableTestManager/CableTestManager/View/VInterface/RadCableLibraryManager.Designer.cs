namespace CableTestManager.View.VInterface
{
    partial class RadCableLibraryManager
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadCableLibraryManager));
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.lbx_cableName = new Telerik.WinControls.UI.RadLabel();
            this.radGridViewCable = new Telerik.WinControls.UI.RadGridView();
            this.radGridViewInter = new Telerik.WinControls.UI.RadGridView();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            this.btnAddSignal = new System.Windows.Forms.PictureBox();
            this.btnAddall = new System.Windows.Forms.PictureBox();
            this.btnDeleteSignal = new System.Windows.Forms.PictureBox();
            this.btnDeleteAll = new System.Windows.Forms.PictureBox();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.btnSubmit = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbx_cableName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewCable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewCable.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewInter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewInter.MasterTemplate)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddSignal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteSignal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 26);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(86, 21);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "线束代号：";
            this.radLabel1.ThemeName = "MaterialBlueGrey";
            // 
            // lbx_cableName
            // 
            this.lbx_cableName.Location = new System.Drawing.Point(102, 26);
            this.lbx_cableName.Name = "lbx_cableName";
            this.lbx_cableName.Size = new System.Drawing.Size(12, 18);
            this.lbx_cableName.TabIndex = 1;
            this.lbx_cableName.Text = "k";
            // 
            // radGridViewCable
            // 
            this.radGridViewCable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.radGridViewCable.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridViewCable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridViewCable.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.radGridViewCable.ForeColor = System.Drawing.Color.Black;
            this.radGridViewCable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridViewCable.Location = new System.Drawing.Point(3, 19);
            // 
            // 
            // 
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "序号";
            gridViewTextBoxColumn1.Name = "column1";
            gridViewTextBoxColumn1.Width = 81;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "接口代号";
            gridViewTextBoxColumn2.Name = "column2";
            gridViewTextBoxColumn2.Width = 109;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "接点数量";
            gridViewTextBoxColumn3.Name = "column3";
            gridViewTextBoxColumn3.Width = 102;
            this.radGridViewCable.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.radGridViewCable.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridViewCable.Name = "radGridViewCable";
            this.radGridViewCable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridViewCable.Size = new System.Drawing.Size(334, 437);
            this.radGridViewCable.TabIndex = 2;
            this.radGridViewCable.ThemeName = "TelerikMetroTouch";
            // 
            // radGridViewInter
            // 
            this.radGridViewInter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.radGridViewInter.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridViewInter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridViewInter.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.radGridViewInter.ForeColor = System.Drawing.Color.Black;
            this.radGridViewInter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridViewInter.Location = new System.Drawing.Point(3, 19);
            // 
            // 
            // 
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "序号";
            gridViewTextBoxColumn4.Name = "column1";
            gridViewTextBoxColumn4.Width = 81;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.HeaderText = "接口代号";
            gridViewTextBoxColumn5.Name = "column2";
            gridViewTextBoxColumn5.Width = 109;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.HeaderText = "接点数量";
            gridViewTextBoxColumn6.Name = "column3";
            gridViewTextBoxColumn6.Width = 102;
            this.radGridViewInter.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.radGridViewInter.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.radGridViewInter.Name = "radGridViewInter";
            this.radGridViewInter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridViewInter.Size = new System.Drawing.Size(323, 437);
            this.radGridViewInter.TabIndex = 13;
            this.radGridViewInter.ThemeName = "TelerikMetroTouch";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radGridViewCable);
            this.groupBox1.Location = new System.Drawing.Point(12, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 459);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "线束接口";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radGridViewInter);
            this.groupBox2.Location = new System.Drawing.Point(412, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 459);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接口列表";
            // 
            // btnAddSignal
            // 
            this.btnAddSignal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddSignal.Image = global::CableTestManager.Properties.Resources.单箭头左48;
            this.btnAddSignal.Location = new System.Drawing.Point(358, 170);
            this.btnAddSignal.Name = "btnAddSignal";
            this.btnAddSignal.Size = new System.Drawing.Size(33, 27);
            this.btnAddSignal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAddSignal.TabIndex = 0;
            this.btnAddSignal.TabStop = false;
            // 
            // btnAddall
            // 
            this.btnAddall.Image = global::CableTestManager.Properties.Resources.左双箭头48;
            this.btnAddall.Location = new System.Drawing.Point(358, 224);
            this.btnAddall.Name = "btnAddall";
            this.btnAddall.Size = new System.Drawing.Size(33, 23);
            this.btnAddall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAddall.TabIndex = 17;
            this.btnAddall.TabStop = false;
            // 
            // btnDeleteSignal
            // 
            this.btnDeleteSignal.Image = global::CableTestManager.Properties.Resources.单箭头右48;
            this.btnDeleteSignal.Location = new System.Drawing.Point(358, 321);
            this.btnDeleteSignal.Name = "btnDeleteSignal";
            this.btnDeleteSignal.Size = new System.Drawing.Size(33, 23);
            this.btnDeleteSignal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDeleteSignal.TabIndex = 18;
            this.btnDeleteSignal.TabStop = false;
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Image = global::CableTestManager.Properties.Resources.右双箭头48;
            this.btnDeleteAll.Location = new System.Drawing.Point(358, 366);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(33, 22);
            this.btnDeleteAll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDeleteAll.TabIndex = 19;
            this.btnDeleteAll.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(415, 548);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "取消";
            this.btnClose.ThemeName = "MaterialBlueGrey";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(229, 548);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(120, 36);
            this.btnSubmit.TabIndex = 20;
            this.btnSubmit.Text = "确定";
            this.btnSubmit.ThemeName = "MaterialBlueGrey";
            // 
            // RadCableLibraryManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(765, 596);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnDeleteSignal);
            this.Controls.Add(this.btnAddall);
            this.Controls.Add(this.btnAddSignal);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbx_cableName);
            this.Controls.Add(this.radLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RadCableLibraryManager";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "线束接口配置";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbx_cableName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewCable.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewCable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewInter.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridViewInter)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAddSignal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteSignal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel lbx_cableName;
        private Telerik.WinControls.UI.RadGridView radGridViewCable;
        private Telerik.WinControls.UI.RadGridView radGridViewInter;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
        private System.Windows.Forms.PictureBox btnAddSignal;
        private System.Windows.Forms.PictureBox btnAddall;
        private System.Windows.Forms.PictureBox btnDeleteSignal;
        private System.Windows.Forms.PictureBox btnDeleteAll;
        private Telerik.WinControls.UI.RadButton btnClose;
        private Telerik.WinControls.UI.RadButton btnSubmit;
    }
}
