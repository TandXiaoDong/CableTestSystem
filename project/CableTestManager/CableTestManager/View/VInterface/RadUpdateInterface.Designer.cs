namespace CableTestManager.View.VAdd
{
    partial class RadUpdateInterface
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
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn1 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn2 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadUpdateInterface));
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.telerikMetroTouchTheme1 = new Telerik.WinControls.Themes.TelerikMetroTouchTheme();
            this.tb_remark = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.tb_interfacelNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menu_deleteSelect = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.menu_deleteAll = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.menu_batchAddInterfacePoint = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.menu_importFromConnectorType = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.menu_importFromFile = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.menu_signalAddInterfacePoint = new Telerik.WinControls.UI.RadMenuButtonItem();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.btnSubmit = new Telerik.WinControls.UI.RadButton();
            this.materialTheme1 = new Telerik.WinControls.Themes.MaterialTheme();
            ((System.ComponentModel.ISupportInitialize)(this.tb_remark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_interfacelNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_remark
            // 
            this.tb_remark.Location = new System.Drawing.Point(488, 17);
            this.tb_remark.Name = "tb_remark";
            this.tb_remark.Size = new System.Drawing.Size(220, 36);
            this.tb_remark.TabIndex = 16;
            this.tb_remark.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(427, 30);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(55, 21);
            this.radLabel2.TabIndex = 15;
            this.radLabel2.Text = "备注：";
            this.radLabel2.ThemeName = "MaterialBlueGrey";
            // 
            // tb_interfacelNo
            // 
            this.tb_interfacelNo.Location = new System.Drawing.Point(111, 17);
            this.tb_interfacelNo.Name = "tb_interfacelNo";
            this.tb_interfacelNo.Size = new System.Drawing.Size(220, 36);
            this.tb_interfacelNo.TabIndex = 14;
            this.tb_interfacelNo.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(19, 30);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(86, 21);
            this.radLabel4.TabIndex = 13;
            this.radLabel4.Text = "接口代号：";
            this.radLabel4.ThemeName = "MaterialBlueGrey";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radLabel4);
            this.panel1.Controls.Add(this.tb_remark);
            this.panel1.Controls.Add(this.tb_interfacelNo);
            this.panel1.Controls.Add(this.radLabel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1005, 64);
            this.panel1.TabIndex = 17;
            // 
            // menu_deleteSelect
            // 
            // 
            // 
            // 
            this.menu_deleteSelect.ButtonElement.ShowBorder = false;
            this.menu_deleteSelect.Name = "menu_deleteSelect";
            this.menu_deleteSelect.Text = "删除选中接点";
            this.menu_deleteSelect.UseCompatibleTextRendering = false;
            // 
            // menu_deleteAll
            // 
            // 
            // 
            // 
            this.menu_deleteAll.ButtonElement.ShowBorder = false;
            this.menu_deleteAll.Name = "menu_deleteAll";
            this.menu_deleteAll.Text = "删除所有接点";
            this.menu_deleteAll.UseCompatibleTextRendering = false;
            // 
            // radGridView1
            // 
            this.radGridView1.BackColor = System.Drawing.Color.Lavender;
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGridView1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.radGridView1.ForeColor = System.Drawing.Color.Black;
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(0, 113);
            // 
            // 
            // 
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "序号";
            gridViewTextBoxColumn1.Name = "columnOrder";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "接口代号";
            gridViewTextBoxColumn2.Name = "column1";
            gridViewTextBoxColumn2.Width = 73;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "接点名称";
            gridViewTextBoxColumn3.Name = "column2";
            gridViewTextBoxColumn3.Width = 129;
            gridViewComboBoxColumn1.EnableExpressionEditor = false;
            gridViewComboBoxColumn1.HeaderText = "测量方法";
            gridViewComboBoxColumn1.Name = "columnMethod";
            gridViewComboBoxColumn1.Width = 106;
            gridViewComboBoxColumn2.EnableExpressionEditor = false;
            gridViewComboBoxColumn2.HeaderText = "转接台针脚号";
            gridViewComboBoxColumn2.Name = "columnStitch";
            gridViewComboBoxColumn2.Width = 105;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.HeaderText = "连接器";
            gridViewTextBoxColumn4.Name = "columnConnector";
            gridViewTextBoxColumn4.Width = 110;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.HeaderText = "备注";
            gridViewTextBoxColumn5.Name = "columnRemark";
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.HeaderText = "IsAddNewRow";
            gridViewTextBoxColumn6.Name = "column3";
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewComboBoxColumn1,
            gridViewComboBoxColumn2,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            sortDescriptor1.PropertyName = "column4";
            this.radGridView1.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.Size = new System.Drawing.Size(1005, 412);
            this.radGridView1.TabIndex = 19;
            this.radGridView1.ThemeName = "TelerikMetroTouch";
            // 
            // menu_batchAddInterfacePoint
            // 
            // 
            // 
            // 
            this.menu_batchAddInterfacePoint.ButtonElement.ShowBorder = false;
            this.menu_batchAddInterfacePoint.Name = "menu_batchAddInterfacePoint";
            this.menu_batchAddInterfacePoint.Text = "批量添加接点";
            // 
            // menu_importFromConnectorType
            // 
            // 
            // 
            // 
            this.menu_importFromConnectorType.ButtonElement.ShowBorder = false;
            this.menu_importFromConnectorType.Name = "menu_importFromConnectorType";
            this.menu_importFromConnectorType.Text = "根据连接器型号导入";
            this.menu_importFromConnectorType.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // menu_importFromFile
            // 
            // 
            // 
            // 
            this.menu_importFromFile.ButtonElement.ShowBorder = false;
            this.menu_importFromFile.Name = "menu_importFromFile";
            this.menu_importFromFile.Text = "从文件导入";
            this.menu_importFromFile.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // menu_signalAddInterfacePoint
            // 
            // 
            // 
            // 
            this.menu_signalAddInterfacePoint.ButtonElement.ShowBorder = false;
            this.menu_signalAddInterfacePoint.Name = "menu_signalAddInterfacePoint";
            this.menu_signalAddInterfacePoint.Text = "单个添加接点";
            // 
            // radMenu1
            // 
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menu_signalAddInterfacePoint,
            this.menu_batchAddInterfacePoint,
            this.menu_importFromConnectorType,
            this.menu_importFromFile,
            this.menu_deleteSelect,
            this.menu_deleteAll});
            this.radMenu1.Location = new System.Drawing.Point(0, 64);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.radMenu1.Size = new System.Drawing.Size(1005, 49);
            this.radMenu1.TabIndex = 18;
            this.radMenu1.ThemeName = "MaterialBlueGrey";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(738, 549);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "取消";
            this.btnClose.ThemeName = "MaterialBlueGrey";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(535, 549);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(120, 36);
            this.btnSubmit.TabIndex = 21;
            this.btnSubmit.Text = "确定";
            this.btnSubmit.ThemeName = "MaterialBlueGrey";
            // 
            // RadUpdateInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1005, 597);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radMenu1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RadUpdateInterface";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "编辑接口库";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.tb_remark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_interfacelNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSubmit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.Themes.TelerikMetroTouchTheme telerikMetroTouchTheme1;
        private Telerik.WinControls.UI.RadTextBox tb_remark;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox tb_interfacelNo;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadMenuButtonItem menu_deleteSelect;
        private Telerik.WinControls.UI.RadMenuButtonItem menu_deleteAll;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadMenuButtonItem menu_batchAddInterfacePoint;
        private Telerik.WinControls.UI.RadMenuButtonItem menu_importFromConnectorType;
        private Telerik.WinControls.UI.RadMenuButtonItem menu_importFromFile;
        private Telerik.WinControls.UI.RadMenuButtonItem menu_signalAddInterfacePoint;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadButton btnClose;
        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.UI.RadButton btnSubmit;
        private Telerik.WinControls.Themes.MaterialTheme materialTheme1;
    }
}
