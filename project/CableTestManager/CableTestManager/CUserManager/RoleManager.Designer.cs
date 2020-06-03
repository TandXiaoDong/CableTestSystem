namespace CableTestManager.CUserManager
{
    partial class RoleManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleManager));
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.menu_add = new Telerik.WinControls.UI.RadMenuItem();
            this.menu_del = new Telerik.WinControls.UI.RadMenuItem();
            this.menu_commit = new Telerik.WinControls.UI.RadMenuItem();
            this.menu_refresh = new Telerik.WinControls.UI.RadMenuItem();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // radMenu1
            // 
            this.radMenu1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.radMenu1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menu_add,
            this.menu_del,
            this.menu_commit,
            this.menu_refresh});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.radMenu1.Size = new System.Drawing.Size(506, 31);
            this.radMenu1.TabIndex = 11;
            this.radMenu1.ThemeName = "Windows8";
            // 
            // menu_add
            // 
            this.menu_add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menu_add.Image = global::CableTestManager.Properties.Resources.添加16;
            this.menu_add.Name = "menu_add";
            this.menu_add.Text = "新增";
            this.menu_add.UseCompatibleTextRendering = false;
            // 
            // menu_del
            // 
            this.menu_del.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menu_del.Image = global::CableTestManager.Properties.Resources.delete16;
            this.menu_del.Name = "menu_del";
            this.menu_del.Shape = null;
            this.menu_del.Text = "删除";
            this.menu_del.UseCompatibleTextRendering = false;
            // 
            // menu_commit
            // 
            this.menu_commit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menu_commit.Image = global::CableTestManager.Properties.Resources.modify32;
            this.menu_commit.Name = "menu_commit";
            this.menu_commit.Text = "编辑";
            this.menu_commit.UseCompatibleTextRendering = false;
            // 
            // menu_refresh
            // 
            this.menu_refresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menu_refresh.Image = global::CableTestManager.Properties.Resources.查询;
            this.menu_refresh.Name = "menu_refresh";
            this.menu_refresh.Text = "查询";
            this.menu_refresh.UseCompatibleTextRendering = false;
            // 
            // radGridView1
            // 
            this.radGridView1.BackColor = System.Drawing.SystemColors.Control;
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("宋体", 9F);
            this.radGridView1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(0, 31);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.Size = new System.Drawing.Size(506, 251);
            this.radGridView1.TabIndex = 12;
            this.radGridView1.ThemeName = "TelerikMetroTouch";
            // 
            // RoleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 282);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radMenu1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoleManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "角色管理";
            this.Load += new System.EventHandler(this.RoleManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem menu_add;
        private Telerik.WinControls.UI.RadMenuItem menu_del;
        private Telerik.WinControls.UI.RadMenuItem menu_commit;
        private Telerik.WinControls.UI.RadMenuItem menu_refresh;
        private Telerik.WinControls.UI.RadGridView radGridView1;
    }
}