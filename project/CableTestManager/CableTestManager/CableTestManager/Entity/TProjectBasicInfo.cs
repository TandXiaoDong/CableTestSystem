/************************************************************************************
 *      Copyright (C) 2020 FigKey,All Rights Reserved
 *      File:
 *				TProjectBasicInfo.cs
 *      Description:
 *		
 *      Author:
 *				唐小东
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020年05月25日
 *      History:
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace CableTestManager.Entity
{
    /// <summary>
    /// 实体类TProjectBasicInfo
    /// </summary>
    [Serializable]
    public class TProjectBasicInfo
    {
        #region 私有字段

        private long _iD = 0;
        private string _projectName = String.Empty;
        private string _batchNumber = String.Empty;
        private long _isCommonProject = 0;
        private long _isGroupTestProject = 0;
        private string _testCableName = String.Empty;
        private long _isExistTestItem = 0;
        private long _isExistConductTest = 0;
        private long _isExistInsulateTest = 0;
        private long _isExistShortCircuitTest = 0;
        private long _isExistVoltageWithStandardTest = 0;
        private double _conductTestThreshold = 0.0;
        private double _conductTestVoltage = 0.0;
        private double _conductTestCurrentElect = 0.0;
        private double _shortCircuitTestThreshold = 0.0;
        private double _insulateHigthOrLowElect = 0.0;
        private double _insulateTestThreshold = 0.0;
        private double _insulateTestHoldTime = 0.0;
        private double _insulateTestVoltage = 0.0;
        private double _insulateTestRaiseTime = 0.0;
        private double _voltageWithStandardThreshold = 0.0;
        private double _voltageWithStandardHoldTime = 0.0;
        private double _voltageWithStandardVoltage = 0.0;
        private long _isUseSelfDefineParams = 0;
        private string _remark = String.Empty;
        private string _updateDate = String.Empty;


        #endregion

        #region 公有属性


        public long ID
        {
            set { this._iD = value; }
            get { return this._iD; }
        }


        public string ProjectName
        {
            set { this._projectName = value; }
            get { return this._projectName; }
        }


        public string BatchNumber
        {
            set { this._batchNumber = value; }
            get { return this._batchNumber; }
        }


        public long IsCommonProject
        {
            set { this._isCommonProject = value; }
            get { return this._isCommonProject; }
        }


        public long IsGroupTestProject
        {
            set { this._isGroupTestProject = value; }
            get { return this._isGroupTestProject; }
        }


        public string TestCableName
        {
            set { this._testCableName = value; }
            get { return this._testCableName; }
        }


        public long IsExistTestItem
        {
            set { this._isExistTestItem = value; }
            get { return this._isExistTestItem; }
        }


        public long IsExistConductTest
        {
            set { this._isExistConductTest = value; }
            get { return this._isExistConductTest; }
        }


        public long IsExistInsulateTest
        {
            set { this._isExistInsulateTest = value; }
            get { return this._isExistInsulateTest; }
        }


        public long IsExistShortCircuitTest
        {
            set { this._isExistShortCircuitTest = value; }
            get { return this._isExistShortCircuitTest; }
        }


        public long IsExistVoltageWithStandardTest
        {
            set { this._isExistVoltageWithStandardTest = value; }
            get { return this._isExistVoltageWithStandardTest; }
        }


        public double ConductTestThreshold
        {
            set { this._conductTestThreshold = value; }
            get { return this._conductTestThreshold; }
        }


        public double ConductTestVoltage
        {
            set { this._conductTestVoltage = value; }
            get { return this._conductTestVoltage; }
        }


        public double ConductTestCurrentElect
        {
            set { this._conductTestCurrentElect = value; }
            get { return this._conductTestCurrentElect; }
        }


        public double ShortCircuitTestThreshold
        {
            set { this._shortCircuitTestThreshold = value; }
            get { return this._shortCircuitTestThreshold; }
        }


        public double InsulateHigthOrLowElect
        {
            set { this._insulateHigthOrLowElect = value; }
            get { return this._insulateHigthOrLowElect; }
        }


        public double InsulateTestThreshold
        {
            set { this._insulateTestThreshold = value; }
            get { return this._insulateTestThreshold; }
        }


        public double InsulateTestHoldTime
        {
            set { this._insulateTestHoldTime = value; }
            get { return this._insulateTestHoldTime; }
        }


        public double InsulateTestVoltage
        {
            set { this._insulateTestVoltage = value; }
            get { return this._insulateTestVoltage; }
        }


        public double InsulateTestRaiseTime
        {
            set { this._insulateTestRaiseTime = value; }
            get { return this._insulateTestRaiseTime; }
        }


        public double VoltageWithStandardThreshold
        {
            set { this._voltageWithStandardThreshold = value; }
            get { return this._voltageWithStandardThreshold; }
        }


        public double VoltageWithStandardHoldTime
        {
            set { this._voltageWithStandardHoldTime = value; }
            get { return this._voltageWithStandardHoldTime; }
        }


        public double VoltageWithStandardVoltage
        {
            set { this._voltageWithStandardVoltage = value; }
            get { return this._voltageWithStandardVoltage; }
        }


        public long IsUseSelfDefineParams
        {
            set { this._isUseSelfDefineParams = value; }
            get { return this._isUseSelfDefineParams; }
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
