namespace CommonUtil.CUserManager
{
    partial class UserManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManager));
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.menu_add = new Telerik.WinControls.UI.RadMenuItem();
            this.menu_del = new Telerik.WinControls.UI.RadMenuItem();
            this.menu_commit = new Telerik.WinControls.UI.RadMenuItem();
            this.menu_refresh = new Telerik.WinControls.UI.RadMenuItem();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // menu_add
            // 
            this.menu_add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menu_add.Image = global::CableTestManager.Properties.Resources.bullet_add;
            this.menu_add.Name = "menu_add";
            this.menu_add.Text = "新增";
            this.menu_add.UseCompatibleTextRendering = false;
            this.menu_add.Click += new System.EventHandler(this.Menu_add_Click);
            // 
            // menu_del
            // 
            this.menu_del.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menu_del.Image = ((System.Drawing.Image)(resources.GetObject("menu_del.Image")));
            this.menu_del.Name = "menu_del";
            this.menu_del.Shape = null;
            this.menu_del.Text = "删除";
            this.menu_del.UseCompatibleTextRendering = false;
            this.menu_del.Click += new System.EventHandler(this.Menu_del_Click);
            // 
            // menu_commit
            // 
            this.menu_commit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menu_commit.Image = global::CableTestManager.Properties.Resources.upload_for_cloud;
            this.menu_commit.Name = "menu_commit";
            this.menu_commit.Text = "修改";
            this.menu_commit.UseCompatibleTextRendering = false;
            this.menu_commit.Click += new System.EventHandler(this.Menu_commit_Click);
            // 
            // menu_refresh
            // 
            this.menu_refresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.menu_refresh.Image = global::CableTestManager.Properties.Resources.update;
            this.menu_refresh.Name = "menu_refresh";
            this.menu_refresh.Text = "查询";
            this.menu_refresh.UseCompatibleTextRendering = false;
            this.menu_refresh.Click += new System.EventHandler(this.Menu_refresh_Click);
            // 
            // radGridView1
            // 
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Location = new System.Drawing.Point(0, 40);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(617, 445);
            this.radGridView1.TabIndex = 11;
            this.radGridView1.ThemeName = "TelerikMetroTouch";
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
            this.radMenu1.Size = new System.Drawing.Size(617, 40);
            this.radMenu1.TabIndex = 10;
            this.radMenu1.ThemeName = "Windows8";
            // 
            // UserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(617, 485);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radMenu1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserManager";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户管理";
            this.ThemeName = "Office2013Light";
            this.Load += new System.EventHandler(this.UserManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadMenuItem menu_add;
        private Telerik.WinControls.UI.RadMenuItem menu_del;
        private Telerik.WinControls.UI.RadMenuItem menu_commit;
        private Telerik.WinControls.UI.RadMenuItem menu_refresh;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
    }
}
