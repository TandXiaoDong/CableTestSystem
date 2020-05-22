using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using WindowsFormTelerik.ControlCommon;

namespace CommonUtil.CUserManager
{
    public partial class UserManager : RadForm
    {
        private DataTable dataSource;
        private const string USER_ID = "序号";
        private const string USER_NAME = "用户名";
        private const string USER_ROLE = "用户类型";
        //private const string USER_STATUS = "状态";
        private const string UPDATE_DATE = "更新日期";
        private UserHelper userHelper;

        public UserManager()
        {
            InitializeComponent();
        }

        private void InitDataTable()
        {
            if (dataSource == null)
            {
                dataSource = new DataTable();
                dataSource.Columns.Add(USER_ID);
                dataSource.Columns.Add(USER_NAME);
                dataSource.Columns.Add(USER_ROLE);
                dataSource.Columns.Add(UPDATE_DATE);
            }
        }

        private void Menu_refresh_Click(object sender, EventArgs e)
        {
            SelectAllUser();
        }

        private void SelectAllUser()
        {
            this.dataSource.Clear();

            var dt = (userHelper.GetAllUserInfo()).Tables[0];
            if (dt.Rows.Count < 1)
                return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var username = dt.Rows[i][1].ToString();
                var userrole = dt.Rows[i][3].ToString();
                var updateDate = dt.Rows[i][6].ToString();

                if (userrole == ((int)UserHelper.UserRole.Admin).ToString())
                    userrole = "管理员";
                else if (userrole == ((int)UserHelper.UserRole.Operator).ToString())
                    userrole = "操作员";

                DataRow dr = dataSource.NewRow();
                dr[USER_ID] = i + 1;
                dr[USER_NAME] = username;
                dr[USER_ROLE] = userrole;
                dr[UPDATE_DATE] = updateDate;
                this.dataSource.Rows.Add(dr);
            }

            this.radGridView1.DataSource = this.dataSource;
        }

        private void UserManager_Load(object sender, EventArgs e)
        {
            userHelper = new UserHelper();
            InitDataTable();
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,true,0);
            SelectAllUser();
        }

        private void Menu_add_Click(object sender, EventArgs e)
        {
            Register register = new Register("添加新用户");
            if (register.ShowDialog() == DialogResult.OK)
            {
                SelectAllUser();
            }
        }

        private void Menu_del_Click(object sender, EventArgs e)
        {
            var username = this.radGridView1.CurrentRow.Cells[1].Value;
            if (username == null)
            {
                MessageBox.Show("请选择要删除的用户！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            DeleteUser(username.ToString());
        }

        private void DeleteUser(string username)
        {
            var dt = userHelper.GetUserInfo(username).Tables[0];

            if (dt.Rows.Count < 1)
                return;
            var roleID = dt.Rows[0][0].ToString();
            if (roleID == "0")//admin
                return;
            if (MessageBox.Show($"确认要删除用户【{username}】?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }
            int delV = userHelper.DeleteUser(username);
            if (delV == 1)
            {
                SelectAllUser();
                MessageBox.Show("删除成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Menu_commit_Click(object sender, EventArgs e)
        {
            var username = this.radGridView1.CurrentRow.Cells[1].Value;
            if (username == null)
            {
                MessageBox.Show("请选择要修改的用户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var userID = userHelper.GetUserID(username.ToString());
            ModifyPwd modifyPwd = new ModifyPwd(userID,username.ToString());
            modifyPwd.ShowDialog();
        }
    }
}
