/************************************************************************************
 *      Copyright (C) 2020 FigKey,All Rights Reserved
 *      File:
 *				_THistoryDataBasic_old_20200318.cs
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
    /// 实体类_THistoryDataBasic_old_20200318
    /// </summary>
    [Serializable]
    public class _THistoryDataBasic_old_20200318
    {
        #region 私有字段

        private string _testSerialNumber = String.Empty;
        private string _projectName = String.Empty;
        private string _batchNumber = String.Empty;
        private string _testCableName = String.Empty;
        private string _testDate = String.Empty;
        private string _testOperator = String.Empty;
        private string _environmentTemperature = String.Empty;
        private string _environmentAmbientHumidity = String.Empty;
        private string _deviceTypeNo = String.Empty;
        private string _deviceMeasureNumber = String.Empty;
        private string _finalTestResult = String.Empty;
        private double _conductThreshold = 0.0;
        private double _conductVoltage = 0.0;
        private double _conductElect = 0.0;
        private double _shortCircuitThreshold = 0.0;
        private double _insulateHighOrLowElect = 0.0;
        private double _insulateThreshold = 0.0;
        private double _insulateHoldTime = 0.0;
        private double _insulateVoltage = 0.0;
        private double _insulateRaiseTime = 0.0;
        private double _voltageWithStandardThreshold = 0.0;
        private double _voltageWithStandardHoldTime = 0.0;
        private double _voltageWithStandardVoltage = 0.0;
        private long _isConductTestComplete = 0;
        private long _isInsulateTestComplete = 0;
        private long _isInsulateByGroundTestComplete = 0;
        private long _isVoltageWithStandardTestComplete = 0;
        private long _isShortCircuteTestComplete = 0;
        private long _conductTestExceptCount = 0;
        private long _shortcircuitTestExceptCount = 0;
        private long _insulateTestExceptCount = 0;
        private long _voltageWithStandardTestExceptCount = 0;


        #endregion

        #region 公有属性


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


        public string BatchNumber
        {
            set { this._batchNumber = value; }
            get { return this._batchNumber; }
        }


        public string TestCableName
        {
            set { this._testCableName = value; }
            get { return this._testCableName; }
        }


        public string TestDate
        {
            set { this._testDate = value; }
            get { return this._testDate; }
        }


        public string TestOperator
        {
            set { this._testOperator = value; }
            get { return this._testOperator; }
        }


        public string EnvironmentTemperature
        {
            set { this._environmentTemperature = value; }
            get { return this._environmentTemperature; }
        }


        public string EnvironmentAmbientHumidity
        {
            set { this._environmentAmbientHumidity = value; }
            get { return this._environmentAmbientHumidity; }
        }


        public string DeviceTypeNo
        {
            set { this._deviceTypeNo = value; }
            get { return this._deviceTypeNo; }
        }


        public string DeviceMeasureNumber
        {
            set { this._deviceMeasureNumber = value; }
            get { return this._deviceMeasureNumber; }
        }


        public string FinalTestResult
        {
            set { this._finalTestResult = value; }
            get { return this._finalTestResult; }
        }


        public double ConductThreshold
        {
            set { this._conductThreshold = value; }
            get { return this._conductThreshold; }
        }


        public double ConductVoltage
        {
            set { this._conductVoltage = value; }
            get { return this._conductVoltage; }
        }


        public double ConductElect
        {
            set { this._conductElect = value; }
            get { return this._conductElect; }
        }


        public double ShortCircuitThreshold
        {
            set { this._shortCircuitThreshold = value; }
            get { return this._shortCircuitThreshold; }
        }


        public double InsulateHighOrLowElect
        {
            set { this._insulateHighOrLowElect = value; }
            get { return this._insulateHighOrLowElect; }
        }


        public double InsulateThreshold
        {
            set { this._insulateThreshold = value; }
            get { return this._insulateThreshold; }
        }


        public double InsulateHoldTime
        {
            set { this._insulateHoldTime = value; }
            get { return this._insulateHoldTime; }
        }


        public double InsulateVoltage
        {
            set { this._insulateVoltage = value; }
            get { return this._insulateVoltage; }
        }


        public double InsulateRaiseTime
        {
            set { this._insulateRaiseTime = value; }
            get { return this._insulateRaiseTime; }
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


        public long IsConductTestComplete
        {
            set { this._isConductTestComplete = value; }
            get { return this._isConductTestComplete; }
        }


        public long IsInsulateTestComplete
        {
            set { this._isInsulateTestComplete = value; }
            get { return this._isInsulateTestComplete; }
        }


        public long IsInsulateByGroundTestComplete
        {
            set { this._isInsulateByGroundTestComplete = value; }
            get { return this._isInsulateByGroundTestComplete; }
        }


        public long IsVoltageWithStandardTestComplete
        {
            set { this._isVoltageWithStandardTestComplete = value; }
            get { return this._isVoltageWithStandardTestComplete; }
        }


        public long IsShortCircuteTestComplete
        {
            set { this._isShortCircuteTestComplete = value; }
            get { return this._isShortCircuteTestComplete; }
        }


        public long ConductTestExceptCount
        {
            set { this._conductTestExceptCount = value; }
            get { return this._conductTestExceptCount; }
        }


        public long ShortcircuitTestExceptCount
        {
            set { this._shortcircuitTestExceptCount = value; }
            get { return this._shortcircuitTestExceptCount; }
        }


        public long InsulateTestExceptCount
        {
            set { this._insulateTestExceptCount = value; }
            get { return this._insulateTestExceptCount; }
        }


        public long VoltageWithStandardTestExceptCount
        {
            set { this._voltageWithStandardTestExceptCount = value; }
            get { return this._voltageWithStandardTestExceptCount; }
        }



        #endregion	
    }
}
