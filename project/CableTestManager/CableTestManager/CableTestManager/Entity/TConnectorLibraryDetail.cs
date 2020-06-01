/************************************************************************************
 *      Copyright (C) 2020 FigKey,All Rights Reserved
 *      File:
 *				TConnectorLibraryDetail.cs
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
    /// 实体类TConnectorLibraryDetail
    /// </summary>
    [Serializable]
    public class TConnectorLibraryDetail
    {
        #region 私有字段

        private string _connectorName = String.Empty;
        private string _interfacePointName = String.Empty;
        private string _updateDate = String.Empty;


        #endregion

        #region 公有属性


        public string ConnectorName
        {
            set { this._connectorName = value; }
            get { return this._connectorName; }
        }


        public string InterfacePointName
        {
            set { this._interfacePointName = value; }
            get { return this._interfacePointName; }
        }


        public string UpdateDate
        {
            set { this._updateDate = value; }
            get { return this._updateDate; }
        }



        #endregion	
    }
}
