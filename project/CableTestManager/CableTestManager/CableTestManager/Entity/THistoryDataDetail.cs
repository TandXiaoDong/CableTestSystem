/************************************************************************************
 *      Copyright (C) 2020 FigKey,All Rights Reserved
 *      File:
 *				THistoryDataDetail.cs
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
    /// 实体类THistoryDataDetail
    /// </summary>
    [Serializable]
    public class THistoryDataDetail
    {
        #region 私有字段

        private long _iD = 0;
        private string _testSerialNumber = String.Empty;
        private string _projectName = String.Empty;
        private string _startInterface = String.Empty;
        private string _startContactPoint = String.Empty;
        private string _endInterface = String.Empty;
        private string _endContactPoint = String.Empty;
        private string _conductValue = String.Empty;
        private string _conductTestResult = String.Empty;
        private string _insulateValue = String.Empty;
        private string _insulateTestResult = String.Empty;
        private string _voltageWithStandardValue = String.Empty;
        private string _voltageWithStandardTestResult = String.Empty;
        private string _shortCircuitValue = String.Empty;
        private string _shortCircuitTestResult = String.Empty;


        #endregion

        #region 公有属性


        public long ID
        {
            set { this._iD = value; }
            get { return this._iD; }
        }


        public string TestSerialNumber
        {
            set { this._testSerialNumber = value; }
            get { return this._testSerialNumber; }
        }


        public string ProjectName
        {
            set { this._projectName = value; }
            get { return this._projectName; }
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


        public string ConductValue
        {
            set { this._conductValue = value; }
            get { return this._conductValue; }
        }


        public string ConductTestResult
        {
            set { this._conductTestResult = value; }
            get { return this._conductTestResult; }
        }


        public string InsulateValue
        {
            set { this._insulateValue = value; }
            get { return this._insulateValue; }
        }


        public string InsulateTestResult
        {
            set { this._insulateTestResult = value; }
            get { return this._insulateTestResult; }
        }


        public string VoltageWithStandardValue
        {
            set { this._voltageWithStandardValue = value; }
            get { return this._voltageWithStandardValue; }
        }


        public string VoltageWithStandardTestResult
        {
            set { this._voltageWithStandardTestResult = value; }
            get { return this._voltageWithStandardTestResult; }
        }


        public string ShortCircuitValue
        {
            set { this._shortCircuitValue = value; }
            get { return this._shortCircuitValue; }
        }


        public string ShortCircuitTestResult
        {
            set { this._shortCircuitTestResult = value; }
            get { return this._shortCircuitTestResult; }
        }



        #endregion	
    }
}
