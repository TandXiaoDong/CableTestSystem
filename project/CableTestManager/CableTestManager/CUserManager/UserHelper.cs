using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CableTestManager.Business;
using CableTestManager.Business.Implements;
using CableTestManager.Entity;
using System.Data;
using CommonUtils.Logger;

namespace CommonUtil.CUserManager
{
    public class UserHelper
    {
        #region 用户信息接口

        public enum LoginResult
        {
            Successful,
            Err_Password,
            Err_Username,
            Fail
        }

        public enum RegisterResult
        {
            Successful,
            Err_Exist_user,
            Fail
        }

        public enum UserRole
        {
            Admin,
            Operator
        }

        #region 用户登录

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username">用户名/手机号/邮箱</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public LoginResult Login(string username, string password)
        {
            try
            {
                DataTable dt = GetUserInfo(username).Tables[0];
                if (dt.Rows.Count < 1)
                {
                    //用户不存在
                    LogHelper.Log.Info($"用户名{username}不存在，验证失败！");
                    return LoginResult.Err_Username;
                }
                else
                {
                    //用户存在
                    //验证登录密码
                    TUserManager userManager = new TUserManager();
                    var dtRes = userManager.GetDataSetByWhere($"where UserName='{username}' and UserPassword='{password}'").Tables[0];
                    if (dtRes.Rows.Count < 1)
                    {
                        //密码验证失败
                        LogHelper.Log.Info($"用户{username}密码验证失败！");
                        return LoginResult.Err_Password;
                    }
                    else
                    {
                        //通过验证
                        LogHelper.Log.Info(username + " 登录进入 " + DateTime.Now);
                        return LoginResult.Successful;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log.Error("用户登录异常..." + ex.Message);
                return LoginResult.Fail;
            }
        }
        #endregion

        #region 查询用户信息
        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataSet GetUserInfo(string username)
        {
            TUserManager userManager = new TUserManager();
            return userManager.GetDataSetByFieldsAndWhere("UserRole,UserPassword,UserID", $"where UserName='{username}'");
        }

        public string GetUserID(string username)
        {
            TUserManager userManager = new TUserManager();
            var dt = userManager.GetDataSetByFieldsAndWhere("UserID", $"where UserName='{username}'").Tables[0];
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString();
            return "";
        }
        #endregion

        #region 查询所有用户
        /// <summary>
        /// 查询所有用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataSet GetAllUserInfo()
        {
            TUserManager userManager = new TUserManager();
            return userManager.GetAllDataSet();
        }
        #endregion

        #region 注册
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public RegisterResult Register(string username, string pwd, int userType)
        {
            try
            {
                TUserManager userManager = new TUserManager();
                TUser user = new TUser();
                DataTable dt = GetUserInfo(username).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    //用户已存在
                    return RegisterResult.Err_Exist_user;
                }
                else
                {
                    //用户不存在，可以注册
                    var dateTimeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    user.UserID = QueryPrimaryID();
                    user.UserName = username;
                    user.UserPassword = pwd;
                    user.UserRole = userType.ToString();
                    int executeResult = userManager.Insert(user);
                    if (executeResult < 1)
                    {
                        return RegisterResult.Fail;
                    }
                    return RegisterResult.Successful;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log.Error("注册失败..." + ex.Message);
                return RegisterResult.Fail;
            }
        }

        private long QueryPrimaryID()
        {
            long id = -1;
            TUserManager userManager = new TUserManager();
            var dt = userManager.GetDataSetByWhere("order by UserID DESC limit 1").Tables[0];
            if (dt.Rows.Count < 1)
                return id;
            if (long.TryParse(dt.Rows[0]["UserID"].ToString(), out id))
                return id + 1;
            return id;
        }
        #endregion

        #region 修改密码
        public int ModifyUserPassword(string username, string pwd)
        {
            TUserManager userManager = new TUserManager();
            return userManager.UpdateFields($"UserPassword = '{pwd}'", $"where UserName='{username}'");
        }
        #endregion

        #region 删除用户
        public int DeleteUser(string username)
        {
            TUserManager userManager = new TUserManager();
            return userManager.DeleteByWhere($"where UserName='{username}'");
        }
        #endregion

        #endregion
    }
}
