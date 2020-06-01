/************************************************************************************
 *      Copyright (C) 2020 FigKey,All Rights Reserved
 *      File:
 *				FuncLimit.cs
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
    /// 实体类FuncLimit
    /// </summary>
    [Serializable]
    public class FuncLimit
    {
        #region 私有字段

        private long _iD = 0;
        private string _userRole = String.Empty;
        private string _interfaceLib = String.Empty;
        private string _cableLib = String.Empty;
        private string _connectorLib = String.Empty;
        private string _switchWearLib = String.Empty;
        private string _switchStandLib = String.Empty;
        private string _selfStudy = String.Empty;
        private string _conductTest = String.Empty;
        private string _shortCircuitTest = String.Empty;
        private string _insulateTest = String.Empty;
        private string _pressureWithVoltageTest = String.Empty;
        private string _oneKeyTest = String.Empty;
        private string _excuteReport = String.Empty;
        private string _printReport = String.Empty;
        private string _saveTestData = String.Empty;
        private string _newProject = String.Empty;
        private string _projectManage = String.Empty;
        private string _historyTestData = String.Empty;
        private string _operatorRecord = String.Empty;
        private string _probe = String.Empty;
        private string _startResistanceCompensation = String.Empty;
        private string _resistanceCompensationManage = String.Empty;
        private string _reportConfigPath = String.Empty;
        private string _deviceSelfCheck = String.Empty;
        private string _deviceCalibration = String.Empty;
        private string _deviceDebug = String.Empty;
        private string _deviceFaultQuery = String.Empty;
        private string _environmentalParameters = String.Empty;


        #endregion

        #region 公有属性


        public long ID
        {
            set { this._iD = value; }
            get { return this._iD; }
        }


        public string UserRole
        {
            set { this._userRole = value; }
            get { return this._userRole; }
        }


        public string InterfaceLib
        {
            set { this._interfaceLib = value; }
            get { return this._interfaceLib; }
        }


        public string CableLib
        {
            set { this._cableLib = value; }
            get { return this._cableLib; }
        }


        public string ConnectorLib
        {
            set { this._connectorLib = value; }
            get { return this._connectorLib; }
        }


        public string SwitchWearLib
        {
            set { this._switchWearLib = value; }
            get { return this._switchWearLib; }
        }


        public string SwitchStandLib
        {
            set { this._switchStandLib = value; }
            get { return this._switchStandLib; }
        }


        public string SelfStudy
        {
            set { this._selfStudy = value; }
            get { return this._selfStudy; }
        }


        public string ConductTest
        {
            set { this._conductTest = value; }
            get { return this._conductTest; }
        }


        public string ShortCircuitTest
        {
            set { this._shortCircuitTest = value; }
            get { return this._shortCircuitTest; }
        }


        public string InsulateTest
        {
            set { this._insulateTest = value; }
            get { return this._insulateTest; }
        }


        public string PressureWithVoltageTest
        {
            set { this._pressureWithVoltageTest = value; }
            get { return this._pressureWithVoltageTest; }
        }


        public string OneKeyTest
        {
            set { this._oneKeyTest = value; }
            get { return this._oneKeyTest; }
        }


        public string ExcuteReport
        {
            set { this._excuteReport = value; }
            get { return this._excuteReport; }
        }


        public string PrintReport
        {
            set { this._printReport = value; }
            get { return this._printReport; }
        }


        public string SaveTestData
        {
            set { this._saveTestData = value; }
            get { return this._saveTestData; }
        }


        public string NewProject
        {
            set { this._newProject = value; }
            get { return this._newProject; }
        }


        public string ProjectManage
        {
            set { this._projectManage = value; }
            get { return this._projectManage; }
        }


        public string HistoryTestData
        {
            set { this._historyTestData = value; }
            get { return this._historyTestData; }
        }


        public string OperatorRecord
        {
            set { this._operatorRecord = value; }
            get { return this._operatorRecord; }
        }


        public string Probe
        {
            set { this._probe = value; }
            get { return this._probe; }
        }


        public string StartResistanceCompensation
        {
            set { this._startResistanceCompensation = value; }
            get { return this._startResistanceCompensation; }
        }


        public string ResistanceCompensationManage
        {
            set { this._resistanceCompensationManage = value; }
            get { return this._resistanceCompensationManage; }
        }


        public string ReportConfigPath
        {
            set { this._reportConfigPath = value; }
            get { return this._reportConfigPath; }
        }


        public string DeviceSelfCheck
        {
            set { this._deviceSelfCheck = value; }
            get { return this._deviceSelfCheck; }
        }


        public string DeviceCalibration
        {
            set { this._deviceCalibration = value; }
            get { return this._deviceCalibration; }
        }


        public string DeviceDebug
        {
            set { this._deviceDebug = value; }
            get { return this._deviceDebug; }
        }


        public string DeviceFaultQuery
        {
            set { this._deviceFaultQuery = value; }
            get { return this._deviceFaultQuery; }
        }


        public string EnvironmentalParameters
        {
            set { this._environmentalParameters = value; }
            get { return this._environmentalParameters; }
        }



        #endregion	
    }
}
