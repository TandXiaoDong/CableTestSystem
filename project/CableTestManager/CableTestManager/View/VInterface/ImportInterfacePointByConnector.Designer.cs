namespace CableTestManager.View.VInterface
{
    partial class ImportInterfacePointByConnector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportInterfacePointByConnector));
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.tb_connectorFilter = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.rbt_2lineMethod = new Telerik.WinControls.UI.RadRadioButton();
            this.rbt_4lineMethod = new Telerik.WinControls.UI.RadRadioButton();
            this.cb_connectorType = new Telerik.WinControls.UI.RadMultiColumnComboBox();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.btn_apply = new Telerik.WinControls.UI.RadButton();
            this.btn_cancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_connectorFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbt_2lineMethod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbt_4lineMethod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_connectorType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_connectorType.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_connectorType.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_apply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(25, 36);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(102, 21);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "连接器筛选：";
            this.radLabel1.ThemeName = "MaterialBlueGrey";
            // 
            // tb_connectorFilter
            // 
            this.tb_connectorFilter.Location = new System.Drawing.Point(133, 21);
            this.tb_connectorFilter.Name = "tb_connectorFilter";
            this.tb_connectorFilter.Size = new System.Drawing.Size(252, 36);
            this.tb_connectorFilter.TabIndex = 1;
            this.tb_connectorFilter.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(25, 98);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(102, 21);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "连接器型号：";
            this.radLabel2.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(41, 159);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(86, 21);
            this.radLabel3.TabIndex = 3;
            this.radLabel3.Text = "测量方法：";
            this.radLabel3.ThemeName = "MaterialBlueGrey";
            // 
            // rbt_2lineMethod
            // 
            this.rbt_2lineMethod.Location = new System.Drawing.Point(133, 159);
            this.rbt_2lineMethod.Name = "rbt_2lineMethod";
            this.rbt_2lineMethod.Size = new System.Drawing.Size(74, 22);
            this.rbt_2lineMethod.TabIndex = 4;
            this.rbt_2lineMethod.Text = "二线法";
            this.rbt_2lineMethod.ThemeName = "MaterialBlueGrey";
            // 
            // rbt_4lineMethod
            // 
            this.rbt_4lineMethod.Location = new System.Drawing.Point(298, 158);
            this.rbt_4lineMethod.Name = "rbt_4lineMethod";
            this.rbt_4lineMethod.Size = new System.Drawing.Size(74, 22);
            this.rbt_4lineMethod.TabIndex = 5;
            this.rbt_4lineMethod.Text = "四线法";
            this.rbt_4lineMethod.ThemeName = "MaterialBlueGrey";
            // 
            // cb_connectorType
            // 
            // 
            // cb_connectorType.NestedRadGridView
            // 
            this.cb_connectorType.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.cb_connectorType.EditorControl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_connectorType.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cb_connectorType.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.cb_connectorType.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.cb_connectorType.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.cb_connectorType.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.cb_connectorType.EditorControl.MasterTemplate.EnableGrouping = false;
            this.cb_connectorType.EditorControl.MasterTemplate.ShowFilteringRow = false;
            this.cb_connectorType.EditorControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.cb_connectorType.EditorControl.Name = "NestedRadGridView";
            this.cb_connectorType.EditorControl.ReadOnly = true;
            this.cb_connectorType.EditorControl.ShowGroupPanel = false;
            this.cb_connectorType.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.cb_connectorType.EditorControl.TabIndex = 0;
            this.cb_connectorType.Location = new System.Drawing.Point(133, 83);
            this.cb_connectorType.Name = "cb_connectorType";
            this.cb_connectorType.Size = new System.Drawing.Size(252, 36);
            this.cb_connectorType.TabIndex = 6;
            this.cb_connectorType.TabStop = false;
            this.cb_connectorType.ThemeName = "MaterialBlueGrey";
            // 
            // btn_apply
            // 
            this.btn_apply.Location = new System.Drawing.Point(52, 229);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(120, 36);
            this.btn_apply.TabIndex = 7;
            this.btn_apply.Text = "确定";
            this.btn_apply.ThemeName = "MaterialBlueGrey";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(265, 229);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(120, 36);
            this.btn_cancel.TabIndex = 8;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.ThemeName = "MaterialBlueGrey";
            // 
            // ImportInterfacePointByConnector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(429, 300);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.cb_connectorType);
            this.Controls.Add(this.rbt_4lineMethod);
            this.Controls.Add(this.rbt_2lineMethod);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.tb_connectorFilter);
            this.Controls.Add(this.radLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportInterfacePointByConnector";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "通过连接器型号导入接点定义";
            this.ThemeName = "Office2013Light";
            this.Load += new System.EventHandler(this.ImportInterfacePointByConnector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_connectorFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbt_2lineMethod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbt_4lineMethod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_connectorType.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_connectorType.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_connectorType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_apply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox tb_connectorFilter;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadRadioButton rbt_2lineMethod;
        private Telerik.WinControls.UI.RadRadioButton rbt_4lineMethod;
        private Telerik.WinControls.UI.RadMultiColumnComboBox cb_connectorType;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private Telerik.WinControls.UI.RadButton btn_apply;
        private Telerik.WinControls.UI.RadButton btn_cancel;
    }
}
