/************************************************************************************
 *      Copyright (C) 2020 FigKey,All Rights Reserved
 *      File:
 *				TConnectorLibrary.cs
 *      Description:
 *		
 *      Author:
 *				唐小东
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020年06月01日
 *      History:
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Entity
{
    /// <summary>
    /// 实体类TConnectorLibrary
    /// </summary>
    [Serializable]
    public class TConnectorLibrary
    {
        #region 私有字段

        private long _iD = 0;
        private string _connectorName = String.Empty;
        private string _converterType = String.Empty;
        private string _remark = String.Empty;
        private string _updateDate = String.Empty;


        #endregion

        #region 公有属性


        public long ID
        {
            set { this._iD = value; }
            get { return this._iD; }
        }


        public string ConnectorName
        {
            set { this._connectorName = value; }
            get { return this._connectorName; }
        }


        public string ConverterType
        {
            set { this._converterType = value; }
            get { return this._converterType; }
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
