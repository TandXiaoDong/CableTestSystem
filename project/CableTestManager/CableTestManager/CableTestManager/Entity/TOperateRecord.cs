/************************************************************************************
 *      Copyright (C) 2019 FigKey,All Rights Reserved
 *      File:
 *				TOperateRecord.cs
 *      Description:
 *		
 *      Author:
 *				��С��
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020��06��21��
 *      History:
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Entity
{
    /// <summary>
    /// ʵ����TOperateRecord
    /// </summary>
    [Serializable]
    public class TOperateRecord
    {
        #region ˽���ֶ�

        private long _iD = 0;
        private string _operateUser = String.Empty;
        private string _operateContent = String.Empty;
        private string _operateDate = String.Empty;


        #endregion

        #region ��������


        public long ID
        {
            set { this._iD = value; }
            get { return this._iD; }
        }


        public string OperateUser
        {
            set { this._operateUser = value; }
            get { return this._operateUser; }
        }


        public string OperateContent
        {
            set { this._operateContent = value; }
            get { return this._operateContent; }
        }


        public string OperateDate
        {
            set { this._operateDate = value; }
            get { return this._operateDate; }
        }



        #endregion	
    }
}
