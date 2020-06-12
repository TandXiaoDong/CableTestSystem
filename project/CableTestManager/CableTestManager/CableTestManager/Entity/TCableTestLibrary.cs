/************************************************************************************
 *      Copyright (C) 2019 FigKey,All Rights Reserved
 *      File:
 *				TCableTestLibrary.cs
 *      Description:
 *		
 *      Author:
 *				唐小东
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020年06月12日
 *      History:
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Entity
{
    /// <summary>
    /// 实体类TCableTestLibrary
    /// </summary>
    [Serializable]
    public class TCableTestLibrary
    {
        #region 私有字段

        private long _iD = 0;
        private string _cableName = String.Empty;
        private string _startInterface = String.Empty;
        private string _startContactPoint = String.Empty;
        private string _startDevPoint = String.Empty;
        private string _endInterface = String.Empty;
        private string _endContactPoint = String.Empty;
        private string _endDevPoint = String.Empty;
        private string _measureMethod = String.Empty;
        private long _isGroundTest = 0;
        private long _isInsulateTest = 0;
        private long _isConductTest = 0;
        private long _isVoltageWithStandardTest = 0;
        private long _isShortCircuitTest = 0;
        private string _remark = String.Empty;
        private string _updateDate = String.Empty;


        #endregion

        #region 公有属性


        public long ID
        {
            set { this._iD = value; }
            get { return this._iD; }
        }


        public string CableName
        {
            set { this._cableName = value; }
            get { return this._cableName; }
        }


        public string StartInterface
        {
            set { this._startInterface = value; }
            get { return this._startInterface; }
        }


        public string StartContactPoint
        {
            set { this._startContactPoint = value; }
            get { return this._startContactPoint; }
        }


        public string StartDevPoint
        {
            set { this._startDevPoint = value; }
            get { return this._startDevPoint; }
        }


        public string EndInterface
        {
            set { this._endInterface = value; }
            get { return this._endInterface; }
        }


        public string EndContactPoint
        {
            set { this._endContactPoint = value; }
            get { return this._endContactPoint; }
        }


        public string EndDevPoint
        {
            set { this._endDevPoint = value; }
            get { return this._endDevPoint; }
        }


        public string MeasureMethod
        {
            set { this._measureMethod = value; }
            get { return this._measureMethod; }
        }


        public long IsGroundTest
        {
            set { this._isGroundTest = value; }
            get { return this._isGroundTest; }
        }


        public long IsInsulateTest
        {
            set { this._isInsulateTest = value; }
            get { return this._isInsulateTest; }
        }


        public long IsConductTest
        {
            set { this._isConductTest = value; }
            get { return this._isConductTest; }
        }


        public long IsVoltageWithStandardTest
        {
            set { this._isVoltageWithStandardTest = value; }
            get { return this._isVoltageWithStandardTest; }
        }


        public long IsShortCircuitTest
        {
            set { this._isShortCircuitTest = value; }
            get { return this._isShortCircuitTest; }
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
