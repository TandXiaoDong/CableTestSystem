using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using CableTestManager.Common;

namespace CommonUtil.CUserManager
{
    public partial class ModifyPwd : Telerik.WinControls.UI.RadForm
    {
        private string userName;
        private string userID;
        private UserHelper userHelper;

        public ModifyPwd(string userID,string username)
        {
            InitializeComponent();
            
            this.tb_user.Text = username;
            this.userName = username;
            this.userID = userID;
        }

        private void ModifyPwd_Load(object sender, EventArgs e)
        {
            userHelper = new UserHelper();
            this.tb_newPwd.PasswordChar = '*';
            this.tb_confirmPwd.PasswordChar = '*';
            this.btn_cancel.Click += Btn_cancel_Click;
            this.btn_modify.Click += Btn_modify_Click;
        }

        private void Btn_modify_Click(object sender, EventArgs e)
        {
            CommitUserModify();
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CommitUserModify()
        {
            var username = this.tb_user.Text.Trim();
            var oldPwd = this.tb_oldPwd.Text.Trim();
            var newPwd = this.tb_newPwd.Text.Trim();
            var confirmPwd = this.tb_confirmPwd.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("用户名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(oldPwd))
            {
                MessageBox.Show("旧密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(newPwd))
            {
                MessageBox.Show("新密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(confirmPwd))
            {
                MessageBox.Show("确认密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var dt = userHelper.GetUserInfo(username).Tables[0];
            if (dt.Rows.Count > 0)
            {
                //用户已存在
                //用户不能是已经存在的其他用户名
                if (username != userName)
                {
                    MessageBox.Show("该用户名已存在，请重新输入用户名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //验证旧密码
            var loginResult = userHelper.Login(userName , oldPwd);
            if (loginResult ==  UserHelper.LoginResult.Err_Password)
            {
                MessageBox.Show("旧密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (newPwd != confirmPwd)
            {
                MessageBox.Show("新密码与确认密码不一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var res = userHelper.ModifyUserPassword(userName, username, confirmPwd);
            if (res == 1)
            {
                UserOperateRecord.UpdateOperateRecord($"修改密码");
                MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
