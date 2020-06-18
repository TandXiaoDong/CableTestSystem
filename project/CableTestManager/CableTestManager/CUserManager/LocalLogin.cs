using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using CommonUtils.Logger;
using CommonUtils.FileHelper;
using System.Web;
using System.Net;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Telerik.WinControls.UI;
using CommonUtil.CUserManager;
using WindowsFormTelerik.CommonUI;
using CableTestManager.View;
using CableTestManager.Common;
using CableTestManager.Business.Implements;

namespace CableTestManager.CUserManager
{
    public partial class LocalLogin : RadForm
    {
        private const string USER_ADMIN = "管理员";
        private const string USER_ORDINARY = "普通用户";
        private const string INI_CONFIG_NAME = "userConfig.ini";
        private const string INI_CONFIG_SECTION = "usercfg";
        private const string INI_CONFIG_USER = "username";
        private const string INI_CONFIG_PWD = "password";
        private const string INI_CONFIG_REMBER = "remberpwd";
        private string configPath;
        private bool isFormMoving = false;
        public static string currentUserType;
        public static string currentUserName;
        public static LoginResult loginResult;
        public static bool IsCloseFormState;
        private UserHelper userHelper;

        public LocalLogin()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public enum LoginResult
        {
            STATUS_OK,
            ERROR_USER_NAME,
            ERROR_PASSWORD,
            STATUS_CANCEL_LOGIN,
            STATUS_CLOSE_FORM,
            ERROR_EXCEPT
        }

        private void DelegateAction(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void Timer()
        {
            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += (s, x) =>
            {
                DelegateAction(() =>
                {
                    //
                });
            };
            timer.Enabled = true;
            timer.Start();
        }

        public enum UserType1
        {
            /// <summary>
            /// 管理员
            /// </summary>
            USER_ADMIN,
            /// <summary>
            /// 班组长
            /// </summary>
            USER_TEAM_LEADER,
            /// <summary>
            /// 操作员
            /// </summary>
            USER_OPERATOR,
            /// <summary>
            /// 普通工人
            /// </summary>
            USER_ORIDNARY
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Init();
            this.tbx_username.Click += Tbx_username_Click;
            this.tbx_username.KeyDown += Tbx_username_KeyDown;
            this.tbx_username.MouseLeave += Tbx_username_MouseLeave;
            this.tbx_pwd.Click += Tbx_pwd_Click;
            this.tbx_pwd.MouseLeave += Tbx_pwd_MouseLeave;
        }

        private void Tbx_pwd_MouseLeave(object sender, EventArgs e)
        {
            if (this.tbx_pwd.Text.Trim() == "")
            {
                this.tbx_pwd.Text = "请输入用户密码";
                this.tbx_pwd.ForeColor = Color.LightGray;
            }
            else
            {
                this.tbx_pwd.PasswordChar = '*';
            }
        }

        private void Tbx_pwd_Click(object sender, EventArgs e)
        {
            this.tbx_pwd.PasswordChar = new char();
            if (this.tbx_pwd.Text.Trim() == "请输入用户密码")
            {
                this.tbx_pwd.Text = "";
                this.tbx_pwd.PasswordChar = '*';
                this.tbx_pwd.ForeColor = Color.Black;
            }
        }

        private void Tbx_username_Click(object sender, EventArgs e)
        {
            this.tbx_username.PasswordChar = new char();
            if (this.tbx_username.Text.Trim() == "请输入用户名")
            {
                this.tbx_username.Text = "";
                this.tbx_username.ForeColor = Color.Black;
            }
        }

        private void Tbx_username_MouseLeave(object sender, EventArgs e)
        {
            if (this.tbx_username.Text.Trim() == "")
            {
                this.tbx_username.Text = "请输入用户名";
                this.tbx_username.ForeColor = Color.LightGray;
            }
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            loginResult = LoginResult.STATUS_CLOSE_FORM;
            this.Close();
        }

        private void Tbx_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                tbx_pwd.Focus();
            }
        }

        #region 本地验证
        /// <summary>
        /// 本地验证用户角色 用户名和密码
        /// </summary>
        /// <returns></returns>
        private bool LocalValidate()
        {
            if (string.IsNullOrEmpty(tbx_username.Text))
            {
                tbx_username.ForeColor = Color.Red;
                tbx_username.Focus();
                return false;
            }
            tbx_username.ForeColor = Color.Black;
            if (string.IsNullOrEmpty(tbx_pwd.Text))
            {
                tbx_pwd.ForeColor = Color.Red;
                tbx_pwd.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region 接口验证用户名 密码
        /// <summary>
        /// 调用接口验证用户名和密码
        /// </summary>
        /// <param name="loginUser"></param>
        private void RemoteValidate()
        {
            try
            {
                var loginRes = userHelper.Login(tbx_username.Text, tbx_pwd.Text);
                //验证用户密码
                switch (loginRes)
                {
                    case UserHelper.LoginResult.Successful:
                        LogHelper.Log.Info("登录验证成功！");
                        //启动主界面
                        this.Close();
                        this.DialogResult = DialogResult.OK;
                        break;
                    case UserHelper.LoginResult.Fail:
                        LogHelper.Log.Info("登录失败!");
                        loginResult = LoginResult.ERROR_EXCEPT;
                        break;
                    case UserHelper.LoginResult.Err_Username:
                        //该用户不存在
                        tbx_username.ForeColor = Color.Red;
                        tbx_username.Focus();
                        loginResult = LoginResult.ERROR_USER_NAME;
                        break;
                    case UserHelper.LoginResult.Err_Password:
                        tbx_pwd.ForeColor = Color.Red;
                        tbx_pwd.Focus();
                        loginResult = LoginResult.ERROR_PASSWORD;
                        return;
                    default:
                        break;
                }
                tbx_pwd.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                LogHelper.Log.Error(ex.Message);
                MessageBox.Show(ex.Message,"Err");
            }
        }
        #endregion

        private void Init()
        {
            userHelper = new UserHelper();
            this.tbx_pwd.PasswordChar = '*';
            //设置单行
            //tbx_username.Multiline = false;
            tbx_pwd.Multiline = false;
            DataSet ds = userHelper.GetAllUserInfo();
            if (ds == null)
            {
                MessageBox.Show("连接数据库服务异常！","ERR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            CheckSysAdminExist();
            tbx_username.Text = "";
            configPath = AppDomain.CurrentDomain.BaseDirectory+INI_CONFIG_NAME;
            ReadLastCfg();

            //
            if (this.tbx_username.Text.Trim() == "")
            {
                this.tbx_username.Text = "请输入用户名";
                this.tbx_username.ForeColor = Color.LightGray;
            }
            if (this.tbx_pwd.Text.Trim() == "")
            {
                this.tbx_pwd.Text = "请输入用户密码";
                this.tbx_pwd.ForeColor = Color.LightGray;
            }
        }

        private void ReadLastCfg()
        {
            try
            {
                var checkState = INIFile.GetValue(INI_CONFIG_SECTION,INI_CONFIG_REMBER,configPath).ToString();
                if (!string.IsNullOrEmpty(checkState))
                {
                    var curCbxState = (CheckState)Enum.Parse(typeof(CheckState),checkState);
                    cb_memberpwd.CheckState = curCbxState;
                    if (curCbxState == CheckState.Checked)
                    {
                        tbx_username.Text = INIFile.GetValue(INI_CONFIG_SECTION, INI_CONFIG_USER, configPath).ToString();
                        tbx_pwd.Text = INIFile.GetValue(INI_CONFIG_SECTION, INI_CONFIG_PWD, configPath).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log.Error(ex.Message);
            }
        }

        private void UpdateUserCfg()
        {
            try
            {
                INIFile.SetValue(INI_CONFIG_SECTION,INI_CONFIG_REMBER,cb_memberpwd.CheckState+"",configPath);
                INIFile.SetValue(INI_CONFIG_SECTION,INI_CONFIG_USER,tbx_username.Text,configPath);
                INIFile.SetValue(INI_CONFIG_SECTION,INI_CONFIG_PWD,tbx_pwd.Text,configPath);
            }
            catch (Exception ex)
            {
                LogHelper.Log.Error(ex.Message);
            }
        }

        private void Lbx_regist_Click(object sender, EventArgs e)
        {
            //注册页面
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            if (!LocalValidate())
                return;
            RemoteValidate();
            SelectUserType();

            UpdateUserCfg();
            if (this.DialogResult == DialogResult.OK)
            {
                //登录成功
                currentUserName = tbx_username.Text;
                UserOperateRecord.UpdateOperateRecord($"登录系统");
                this.Close();
            }
        }

        private void SelectUserType()
        {
            var dt = userHelper.GetUserInfo(tbx_username.Text).Tables[0];
            if (dt.Rows.Count < 1)
                return;
            currentUserType = dt.Rows[0][0].ToString(); 
        }

        private void Lbx_ToFindPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetBackPwd getBackPwd = new GetBackPwd(this.tbx_username.Text);
            getBackPwd.ShowDialog();
        }

        private void Lbx_register_Click(object sender, EventArgs e)
        {
            Register register = new Register("注册");
            register.ShowDialog();
        }

        private void CheckSysAdminExist()
        {
            TUserManager userManager = new TUserManager();
            var count = userManager.GetRowCountByWhere($"where UserName='admin' and UserRole='管理员'");
            if (count <= 0)
            {
                //系统管理员不存在
                userHelper.Register("admin","admin123","管理员");
            }
        }
    }
}
