/************************************************************************************
 *      Copyright (C) 2019 FigKey,All Rights Reserved
 *      File:
 *				Sqlite_sequence.cs
 *      Description:
 *		
 *      Author:
 *				��С��
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020��03��18��
 *      History:
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Entity
{
    /// <summary>
    /// ʵ����Sqlite_sequence
    /// </summary>
    [Serializable]
    public class Sqlite_sequence
    {
        #region ˽���ֶ�

        private object _name = null;
        private object _seq = null;


        #endregion

        #region ��������


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
