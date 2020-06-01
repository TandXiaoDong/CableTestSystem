/************************************************************************************
 *      Copyright (C) 2020 FigKey,All Rights Reserved
 *      File:
 *				TConnectorLibraryDetail.cs
 *      Description:
 *		
 *      Author:
 *				��С��
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020��06��01��
 *      History:
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Entity
{
    /// <summary>
    /// ʵ����TConnectorLibraryDetail
    /// </summary>
    [Serializable]
    public class TConnectorLibraryDetail
    {
        #region ˽���ֶ�

        private string _connectorName = String.Empty;
        private string _interfacePointName = String.Empty;
        private string _updateDate = String.Empty;


        #endregion

        #region ��������


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
