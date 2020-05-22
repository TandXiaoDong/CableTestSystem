/************************************************************************************
 *      Copyright (C) 2020 FigKey,All Rights Reserved
 *      File:
 *				InterfaceInfoLibrary.cs
 *      Description:
 *		
 *      Author:
 *				��С��
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020��05��22��
 *      History:
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Entity
{
    /// <summary>
    /// ʵ����InterfaceInfoLibrary
    /// </summary>
    [Serializable]
    public class InterfaceInfoLibrary
    {
        #region ˽���ֶ�

        private long _iD = 0;
        private string _interfaceNo = String.Empty;
        private string _contactPointName = String.Empty;
        private string _switchStandStitchNo = String.Empty;
        private string _measureMethod = String.Empty;
        private string _connectorName = String.Empty;
        private string _operator = String.Empty;
        private string _remark = String.Empty;
        private string _updateDate = String.Empty;


        #endregion

        #region ��������


        public long ID
        {
            set { this._iD = value; }
            get { return this._iD; }
        }


        public string InterfaceNo
        {
            set { this._interfaceNo = value; }
            get { return this._interfaceNo; }
        }


        public string ContactPointName
        {
            set { this._contactPointName = value; }
            get { return this._contactPointName; }
        }


        public string SwitchStandStitchNo
        {
            set { this._switchStandStitchNo = value; }
            get { return this._switchStandStitchNo; }
        }


        public string MeasureMethod
        {
            set { this._measureMethod = value; }
            get { return this._measureMethod; }
        }


        public string ConnectorName
        {
            set { this._connectorName = value; }
            get { return this._connectorName; }
        }


        public string Operator
        {
            set { this._operator = value; }
            get { return this._operator; }
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
