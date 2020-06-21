/************************************************************************************
 *      Copyright (C) 2019 FigKey,All Rights Reserved
 *      File:
 *				TSwitchWorkWearLibrary.cs
 *      Description:
 *		
 *      Author:
 *				唐小东
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020年06月21日
 *      History:
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Entity
{
    /// <summary>
    /// 实体类TSwitchWorkWearLibrary
    /// </summary>
    [Serializable]
    public class TSwitchWorkWearLibrary
    {
        #region 私有字段

        private long _iD = 0;
        private string _switchWorkWearCode = String.Empty;
        private string _switchrType = String.Empty;
        private string _remark = String.Empty;


        #endregion

        #region 公有属性


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
