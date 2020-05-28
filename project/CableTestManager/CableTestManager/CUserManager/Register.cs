using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Text.RegularExpressions;
using CommonUtils.CalculateAndString;
using CableTestManager.CUserManager;
using CableTestManager.Business.Implements;
using CableTestManager.Common;

namespace CommonUtil.CUserManager
{
    public partial class Register : Telerik.WinControls.UI.RadForm
    {
        private UserHelper userHelper;

        public Register(string formText)
        {
            InitializeComponent();
            this.Text = formText;
        }

        private void Register_Load(object sender, EventArgs e)
        {
            tb_pwd.PasswordChar = '*';
            tb_repwd.PasswordChar = '*';
            userHelper = new UserHelper();
            AddUserRole();

            this.btn_cancel.Click += Btn_cancel_Click;
            this.btn_register.Click += Btn_register_Click;
        }

        private void AddUserRole()
        {
            TRoleManager roleManager = new TRoleManager();
            this.cb_userType.MultiColumnComboBoxElement.Columns.Add("NAME");
            var data = roleManager.GetDataSetByFieldsAndWhere("distinct UserRole", "where UserRole != '管理员'").Tables[0];
            if (data.Rows.Count <= 0)
                return;
            foreach (DataRow dr in data.Rows)
            {
                this.cb_userType.EditorControl.Rows.Add(dr[0].ToString());
            }
            this.cb_userType.EditorControl.ShowColumnHeaders = false;
            this.cb_userType.EditorControl.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            if (this.cb_userType.EditorControl.Rows.Count > 0)
            {
                this.cb_userType.SelectedIndex = 0;
            }
        }

        private void Btn_register_Click(object sender, EventArgs e)
        {
            RegisterUser();
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterUser()
        {
            var username = this.tb_username.Text.Trim();
            var userpwd = this.tb_pwd.Text.Trim();
            var userRpwd = this.tb_repwd.Text.Trim();
            var userType = this.cb_userType.Text.Trim();

            if (string.IsNullOrEmpty(userType.ToString()))
            {
                MessageBox.Show("用户类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("用户名不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(userpwd))
            {
                MessageBox.Show("密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(userRpwd))
            {
                MessageBox.Show("确认密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            DataSet dataSet = userHelper.GetUserInfo(username);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("用户已存在！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                tb_username.ForeColor = Color.Red;
                return;
            }
            tb_username.ForeColor = Color.Black;
            if (userpwd != userRpwd)
            {
                MessageBox.Show("两次密码不一致？","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            //校验密码复杂度
            if (!RegexHelper.IsMatchPassword(userpwd))
            {
                //密码复杂度不满足
                MessageBox.Show("密码必须包含数字、字母", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var registerResult = userHelper.Register(username,userpwd, userType);
            if (registerResult == UserHelper.RegisterResult.Successful)
            {
                //注册成功
                UserOperateRecord.UpdateOperateRecord($"新增用户-{username}");
                MessageBox.Show("注册成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            else if (registerResult == UserHelper.RegisterResult.Err_Exist_user)
            {
                MessageBox.Show("用户已存在！", "提示", MessageBoxButtons.OK);
            }
            else if (registerResult == UserHelper.RegisterResult.Fail)
            {
                MessageBox.Show("注册失败！", "提示", MessageBoxButtons.OK);
            }
        }
    }
}
