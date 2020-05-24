using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CableTestManager.Business.Implements;
using WindowsFormTelerik.ControlCommon;

namespace CableTestManager.CUserManager
{
    public partial class RoleManager : Form
    {
        private TRoleManager roleManager;
        public RoleManager()
        {
            InitializeComponent();
        }

        private void RoleManager_Load(object sender, EventArgs e)
        {
            this.roleManager = new TRoleManager();
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,true,0);
            QueryRoleInfo();

            this.menu_add.Click += Menu_add_Click;
            this.menu_commit.Click += Menu_commit_Click;
            this.menu_del.Click += Menu_del_Click;
            this.menu_refresh.Click += Menu_refresh_Click;
        }

        private void Menu_refresh_Click(object sender, EventArgs e)
        {
            QueryRoleInfo();
        }

        private void Menu_del_Click(object sender, EventArgs e)
        {
            
        }

        private void Menu_commit_Click(object sender, EventArgs e)
        {
            
        }

        private void Menu_add_Click(object sender, EventArgs e)
        {
            
        }

        private void QueryRoleInfo()
        {
            var data = this.roleManager.GetDataSetByFieldsAndWhere("distinct ID 序号, UserRole 角色名称 ,Remark 备注","").Tables[0];
            this.radGridView1.DataSource = data;
        }
    }
}
