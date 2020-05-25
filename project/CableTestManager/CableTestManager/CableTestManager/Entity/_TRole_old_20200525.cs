/************************************************************************************
 *      Copyright (C) 2020 FigKey,All Rights Reserved
 *      File:
 *				_TRole_old_20200525.cs
 *      Description:
 *		
 *      Author:
 *				��С��
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020��05��25��
 *      History:
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Entity
{
    /// <summary>
    /// ʵ����_TRole_old_20200525
    /// </summary>
    [Serializable]
    public class _TRole_old_20200525
    {
        #region ˽���ֶ�

        private long _iD = 0;
        private string _userRole = String.Empty;
        private string _remark = String.Empty;
        private string _updateDate = String.Empty;


        #endregion

        #region ��������


        public long ID
        {
            set { this._iD = value; }
            get { return this._iD; }
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


        public string UpdateDate
        {
            set { this._updateDate = value; }
            get { return this._updateDate; }
        }



        #endregion	
    }
}
