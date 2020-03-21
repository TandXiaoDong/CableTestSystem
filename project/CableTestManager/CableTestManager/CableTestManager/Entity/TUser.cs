/************************************************************************************
 *      Copyright (C) 2019 FigKey,All Rights Reserved
 *      File:
 *				TUser.cs
 *      Description:
 *		
 *      Author:
 *				唐小东
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020年03月18日
 *      History:
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Entity
{
    /// <summary>
    /// 实体类TUser
    /// </summary>
    [Serializable]
    public class TUser
    {
        #region 私有字段

        private long _userID = 0;
        private string _userName = String.Empty;
        private string _userPassword = String.Empty;
        private string _userRole = String.Empty;
        private string _remark = String.Empty;
        private string _status = String.Empty;
        private string _updateDate = String.Empty;


        #endregion

        #region 公有属性


        public long UserID
        {
            set { this._userID = value; }
            get { return this._userID; }
        }


        public string UserName
        {
            set { this._userName = value; }
            get { return this._userName; }
        }


        public string UserPassword
        {
            set { this._userPassword = value; }
            get { return this._userPassword; }
        }


        public string UserRole
        {
            set { this._userRole = value; }
            get { return this._userRole; }
        }


        public string Remark
        {
            set { this._remark = value; }
            get { return this._remark; }
        }


        public string Status
        {
            set { this._status = value; }
            get { return this._status; }
        }


        public string UpdateDate
        {
            set { this._updateDate = value; }
            get { return this._updateDate; }
        }



        #endregion	
    }
}
