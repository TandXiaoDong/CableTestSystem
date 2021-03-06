﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using CommonUtil.CUserManager;

namespace CommonUtil.CUserManager
{
    public partial class GetBackPwd : Telerik.WinControls.UI.RadForm
    {
        private UserHelper userHelper;
        public GetBackPwd(string username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.tb_username.Text = username;
        }

        private void GetBackPwd_Load(object sender, EventArgs e)
        {
            this.tb_pwd.PasswordChar = '*';
            this.tb_repwd.PasswordChar = '*';
            userHelper = new UserHelper();
            this.btn_cancel.Click += Btn_cancel_Click;
            this.btn_register.Click += Btn_register_Click;
        }

        private void Btn_register_Click(object sender, EventArgs e)
        {
            GetBackPassword();
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetBackPassword()
        {
            var username = this.tb_username.Text.Trim();
            var password = this.tb_pwd.Text.Trim();
            var confirmPwd = this.tb_repwd.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("用户名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(confirmPwd))
            {
                MessageBox.Show("确认密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var dt = userHelper.GetUserInfo(username).Tables[0];
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("用户名不存在！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (password != confirmPwd)
            {
                MessageBox.Show("两次密码不一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            var userID = userHelper.GetUserID(username);
            var res = userHelper.ModifyUserPassword(username, username, confirmPwd);
            if (res == 1)
            {
                MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
