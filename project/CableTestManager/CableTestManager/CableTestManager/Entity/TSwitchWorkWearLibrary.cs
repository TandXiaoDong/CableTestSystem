/************************************************************************************
 *      Copyright (C) 2019 FigKey,All Rights Reserved
 *      File:
 *				TSwitchWorkWearLibrary.cs
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
    /// ʵ����TSwitchWorkWearLibrary
    /// </summary>
    [Serializable]
    public class TSwitchWorkWearLibrary
    {
        #region ˽���ֶ�

        private long _iD = 0;
        private string _switchWorkWearCode = String.Empty;
        private string _switchrType = String.Empty;
        private string _remark = String.Empty;


        #endregion

        #region ��������


        public long ID
        {
            set { this._iD = value; }
            get { return this._iD; }
        }


        public string SwitchWorkWearCode
        {
            set { this._switchWorkWearCode = value; }
            get { return this._switchWorkWearCode; }
        }


        public string SwitchrType
        {
            set { this._switchrType = value; }
            get { return this._switchrType; }
        }


        public string Remark
        {
            set { this._remark = value; }
            get { return this._remark; }
        }



        #endregion	
    }
}
