/************************************************************************************
 *      Copyright (C) 2019 FigKey,All Rights Reserved
 *      File:
 *				TProjectBasicInfo.cs
 *      Description:
 *		
 *      Author:
 *				唐小东
 *				1297953037@qq.com
 *				http://www.figkey.com
 *      Finish DateTime:
 *				2020年06月21日
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
        private string _testCableName = String.Empty;
        private double _conductTestThreshold = 0.0;
        private double _conductTestVoltage = 0.0;
        private double _conductTestCurrentElect = 0.0;
        private double _shortCircuitTestThreshold = 0.0;
        private double _insulateTestThreshold = 0.0;
        private double _insulateTestHoldTime = 0.0;
        private double _insulateTestVoltage = 0.0;
        private double _insulateTestRaiseTime = 0.0;
        private double _voltageWithStandardThreshold = 0.0;
        private double _voltageWithStandardHoldTime = 0.0;
        private double _voltageWithStandardVoltage = 0.0;
        private double _resistanceCompensation = 0.0;
        private double _insulateVolCompensation = 0.0;
        private double _insulateResCompensation = 0.0;
        private double _temperature = 0.0;
        private double _ambientHumidity = 0.0;
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


        public string TestCableName
        {
            set { this._testCableName = value; }
            get { return this._testCableName; }
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


        public double ResistanceCompensation
        {
            set { this._resistanceCompensation = value; }
            get { return this._resistanceCompensation; }
        }


        public double InsulateVolCompensation
        {
            set { this._insulateVolCompensation = value; }
            get { return this._insulateVolCompensation; }
        }


        public double InsulateResCompensation
        {
            set { this._insulateResCompensation = value; }
            get { return this._insulateResCompensation; }
        }


        public double Temperature
        {
            set { this._temperature = value; }
            get { return this._temperature; }
        }


        public double AmbientHumidity
        {
            set { this._ambientHumidity = value; }
            get { return this._ambientHumidity; }
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
