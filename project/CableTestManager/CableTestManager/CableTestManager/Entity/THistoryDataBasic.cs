/************************************************************************************
 *      Copyright (C) 2019 FigKey,All Rights Reserved
 *      File:
 *				THistoryDataBasic.cs
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
    /// 实体类THistoryDataBasic
    /// </summary>
    [Serializable]
    public class THistoryDataBasic
    {
        #region 私有字段

        private long _iD = 0;
        private string _testSerialNumber = String.Empty;
        private string _projectName = String.Empty;
        private string _testCableName = String.Empty;
        private string _testStartDate = String.Empty;
        private string _testEndDate = String.Empty;
        private string _testOperator = String.Empty;
        private string _environmentTemperature = String.Empty;
        private string _environmentAmbientHumidity = String.Empty;
        private string _finalTestResult = String.Empty;
        private string _conductTestResult = String.Empty;
        private double _conductThreshold = 0.0;
        private double _conductVoltage = 0.0;
        private double _conductElect = 0.0;
        private string _shortCircuitTestResult = String.Empty;
        private double _shortCircuitThreshold = 0.0;
        private string _insulateTestResult = String.Empty;
        private double _insulateThreshold = 0.0;
        private double _insulateHoldTime = 0.0;
        private double _insulateVoltage = 0.0;
        private double _insulateRaiseTime = 0.0;
        private string _voltageWithStandardTestResult = String.Empty;
        private double _voltageWithStandardThreshold = 0.0;
        private double _voltageWithStandardHoldTime = 0.0;
        private double _voltageWithStandardVoltage = 0.0;
        private long _conductTestExceptCount = 0;
        private long _shortcircuitTestExceptCount = 0;
        private long _insulateTestExceptCount = 0;
        private long _voltageWithStandardTestExceptCount = 0;


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


        public string TestCableName
        {
            set { this._testCableName = value; }
            get { return this._testCableName; }
        }


        public string TestStartDate
        {
            set { this._testStartDate = value; }
            get { return this._testStartDate; }
        }


        public string TestEndDate
        {
            set { this._testEndDate = value; }
            get { return this._testEndDate; }
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


        public string FinalTestResult
        {
            set { this._finalTestResult = value; }
            get { return this._finalTestResult; }
        }


        public string ConductTestResult
        {
            set { this._conductTestResult = value; }
            get { return this._conductTestResult; }
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


        public string ShortCircuitTestResult
        {
            set { this._shortCircuitTestResult = value; }
            get { return this._shortCircuitTestResult; }
        }


        public double ShortCircuitThreshold
        {
            set { this._shortCircuitThreshold = value; }
            get { return this._shortCircuitThreshold; }
        }


        public string InsulateTestResult
        {
            set { this._insulateTestResult = value; }
            get { return this._insulateTestResult; }
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


        public string VoltageWithStandardTestResult
        {
            set { this._voltageWithStandardTestResult = value; }
            get { return this._voltageWithStandardTestResult; }
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
