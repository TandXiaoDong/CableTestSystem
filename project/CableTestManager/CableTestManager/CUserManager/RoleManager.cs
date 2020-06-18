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
using CableTestManager.Entity;
using CableTestManager.Common;
using WindowsFormTelerik.ControlCommon;

namespace CableTestManager.CUserManager
{
    public partial class RoleManager : Form
    {
        private TRoleManager roleManager;
        private TRole roleEntity;

        public RoleManager()
        {
            InitializeComponent();
        }

        private void RoleManager_Load(object sender, EventArgs e)
        {
            this.roleManager = new TRoleManager();
            this.roleEntity = new TRole();

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
            var curIndex = this.radGridView1.CurrentRow.Index;
            if (curIndex < 0)
            {
                MessageBox.Show("未选择要删除的角色！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var roleName = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            if (roleName == "管理员")
            {
                return;//系统管理员不可删除
            }
            if (MessageBox.Show("确定要删除该角色吗？", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return;
            }
            var res = this.roleManager.DeleteByWhere($"where UserRole='{roleName}'");
            if (res > 0)
            {
                UserOperateRecord.UpdateOperateRecord($"删除角色-{roleName}");
                MessageBox.Show($"已删除角色'{roleName}'！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            QueryRoleInfo();
        }

        private void Menu_commit_Click(object sender, EventArgs e)
        {
            var curIndex = this.radGridView1.CurrentRow.Index;
            if (curIndex < 0)
            {
                MessageBox.Show("未选择要删除的角色！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var roleName = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            if (roleName == "管理员")
            {
                return;//系统管理员不可编辑修改
            }
            var remark = this.radGridView1.CurrentRow.Cells[2].Value;
            var remarkStr = "";
            if (remark != null)
                remarkStr = remark.ToString();
            var id = GetRoleID(roleName);
            EditRole editRole = new EditRole("编辑角色", roleName, remarkStr);
            if (editRole.ShowDialog() == DialogResult.OK)
            {
                var date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                this.roleManager.UpdateFields($"UserRole='{editRole.roleName}',Remark='{editRole.roleRemark}',UpdateDate='{date}'", $"where ID='{id}'");
                UserOperateRecord.UpdateOperateRecord($"修改角色-{editRole.roleName}");
                QueryRoleInfo();
            }
        }

        private void Menu_add_Click(object sender, EventArgs e)
        {
            EditRole editRole = new EditRole("新增角色", "", "");
            if (editRole.ShowDialog() == DialogResult.OK)
            {
                this.roleEntity.ID = TablePrimaryKey.InsertRolePID();
                this.roleEntity.UserRole = editRole.roleName;
                this.roleEntity.Remark = editRole.roleRemark;
                this.roleEntity.UpdateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                var cCount = roleManager.Insert(this.roleEntity);
                if (cCount > 0)
                {
                    UserOperateRecord.UpdateOperateRecord($"新增角色-{roleEntity.UserRole}");
                    QueryRoleInfo();
                }
            }
        }

        private void QueryRoleInfo()
        {
            var data = this.roleManager.GetDataSetByFieldsAndWhere("distinct ID 序号, UserRole 角色名称 ,Remark 备注", "").Tables[0];
            this.radGridView1.DataSource = data;
            int i = 0;
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                rowInfo.Cells[0].Value = i + 1;
                i++;
            }
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1, false, true, this.radGridView1.ColumnCount);
        }

        private int GetRoleID(string roleName)
        {
            var data = this.roleManager.GetDataSetByFieldsAndWhere("ID", $"where UserRole='{roleName}'").Tables[0];
            int id;
            int.TryParse(data.Rows[0][0].ToString(), out id);
            return id;
        }
    }
}
