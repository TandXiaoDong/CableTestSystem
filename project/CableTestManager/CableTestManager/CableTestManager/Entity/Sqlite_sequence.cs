/************************************************************************************
 *      Copyright (C) 2019 FigKey,All Rights Reserved
 *      File:
 *				Sqlite_sequence.cs
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
    /// 实体类Sqlite_sequence
    /// </summary>
    [Serializable]
    public class Sqlite_sequence
    {
        #region 私有字段

        private object _name = null;
        private object _seq = null;


        #endregion

        #region 公有属性


        public object Name
        {
            set { this._name = value; }
            get { return this._name; }
        }


        public object Seq
        {
            set { this._seq = value; }
            get { return this._seq; }
        }



        #endregion	
    }
}
