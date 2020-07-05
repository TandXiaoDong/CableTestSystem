namespace CableTestManager.View.VSelfStydy
{
    partial class ImportCableLibrary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportCableLibrary));
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.tb_cableName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.cb_measureMethod = new Telerik.WinControls.UI.RadMultiColumnComboBox();
            this.btn_ok = new Telerik.WinControls.UI.RadButton();
            this.btn_cancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_cableName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_measureMethod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_measureMethod.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_measureMethod.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 41);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(102, 21);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "线束库名称：";
            this.radLabel1.ThemeName = "MaterialBlueGrey";
            // 
            // tb_cableName
            // 
            this.tb_cableName.Location = new System.Drawing.Point(111, 26);
            this.tb_cableName.Name = "tb_cableName";
            this.tb_cableName.Size = new System.Drawing.Size(186, 36);
            this.tb_cableName.TabIndex = 1;
            this.tb_cableName.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(28, 101);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(86, 21);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "测量方法：";
            this.radLabel2.ThemeName = "MaterialBlueGrey";
            // 
            // cb_measureMethod
            // 
            // 
            // cb_measureMethod.NestedRadGridView
            // 
            this.cb_measureMethod.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.cb_measureMethod.EditorControl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_measureMethod.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cb_measureMethod.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.cb_measureMethod.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.cb_measureMethod.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.cb_measureMethod.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.cb_measureMethod.EditorControl.MasterTemplate.EnableGrouping = false;
            this.cb_measureMethod.EditorControl.MasterTemplate.ShowFilteringRow = false;
            this.cb_measureMethod.EditorControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.cb_measureMethod.EditorControl.Name = "NestedRadGridView";
            this.cb_measureMethod.EditorControl.ReadOnly = true;
            this.cb_measureMethod.EditorControl.ShowGroupPanel = false;
            this.cb_measureMethod.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.cb_measureMethod.EditorControl.TabIndex = 0;
            this.cb_measureMethod.Enabled = false;
            this.cb_measureMethod.Location = new System.Drawing.Point(111, 86);
            this.cb_measureMethod.Name = "cb_measureMethod";
            this.cb_measureMethod.Size = new System.Drawing.Size(186, 36);
            this.cb_measureMethod.TabIndex = 3;
            this.cb_measureMethod.TabStop = false;
            this.cb_measureMethod.ThemeName = "MaterialBlueGrey";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(111, 160);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(80, 32);
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "确定";
            this.btn_ok.ThemeName = "TelerikMetroTouch";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(212, 160);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(85, 32);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.ThemeName = "TelerikMetroTouch";
            // 
            // ImportCableLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 215);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.cb_measureMethod);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.tb_cableName);
            this.Controls.Add(this.radLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportCableLibrary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "导入到线束库";
            this.Load += new System.EventHandler(this.ImportCableLibrary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_cableName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_measureMethod.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_measureMethod.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_measureMethod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox tb_cableName;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadMultiColumnComboBox cb_measureMethod;
        private Telerik.WinControls.UI.RadButton btn_ok;
        private Telerik.WinControls.UI.RadButton btn_cancel;
    }
}