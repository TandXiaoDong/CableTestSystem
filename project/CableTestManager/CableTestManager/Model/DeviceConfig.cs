using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CableTestManager.Model
{
    /// <summary>
    /// 通用INI配置
    /// </summary>
    public class DeviceConfig
    {
        private string compensateState = "1";
        private string serverUrl = "192.168.1.30";
        private int serverPort = 8088;
        private double assCompensateVal = -2;
        private double insulateVolCompensateVal = 1;
        private double insulateAssCompensateVal = 1;
        private double temperature = 25;
        private double humidity = 54;
        private int projectTestNumberLen = 8;
        private double conductThreshold = 45;
        private double shortCircuitThreshold = 1000;
        private double insulateThreshold = 1000;
        private double insulateVoltage = 10;
        private double insulateHoldTime = 1;
        private double pressureWithVoltageThreshold = 100;
        private string testReportTitle = "线束测试报告";

        /// <summary>
        /// 补偿状态，电阻/绝缘补偿通用
        /// </summary>
        public string CompensateState
        {
            get { return this.compensateState; }
            set { this.compensateState = value; }
        }

        public string ServerUrl 
        {
            get { return this.serverUrl; }
            set { this.serverUrl = value; }
        }

        public int ServerPort
        {
            get { return this.serverPort; }
            set { this.serverPort = value; }
        }

        public string ReportDirectory { get; set; }

        public double ConductThreshold
        {
            get { return this.conductThreshold; }
            set { this.conductThreshold = value; }
        }

        public double ShortCircuitThreshold
        {
            get { return this.shortCircuitThreshold; }
            set { this.shortCircuitThreshold = value; }
        }

        public double InsulateThreshold
        {
            get { return this.insulateThreshold; }
            set { this.insulateThreshold = value; }
        }

        public double InsulateVoltage
        {
            get { return this.insulateVoltage; }
            set { this.insulateVoltage = value; }
        }

        public double InsulateHoldTime
        {
            get { return this.insulateHoldTime; }
            set { this.insulateHoldTime = value; }
        }

        public double PressureWithVoltageThreshold
        {
            get { return this.pressureWithVoltageThreshold; }
            set { this.pressureWithVoltageThreshold = value; }
        }

        public double AssCompensateVal
        {
            get { return this.assCompensateVal; }
            set { this.assCompensateVal = value; }
        }

        public double InsulateVolCompensateVal
        {
            get { return this.insulateVolCompensateVal; }
            set { this.insulateVolCompensateVal = value; }
        }

        public double InsulateAssCompensateVal
        {
            get { return this.insulateAssCompensateVal; }
            set { this.insulateAssCompensateVal = value; }
        }

        public double Temperature
        {
            get { return this.temperature; }
            set { this.temperature = value; }
        }

        public double Humidity
        {
            get { return this.humidity; }
            set { this.humidity = value; }
        }

        public int ProjectTestNumberLen
        {
            get { return this.projectTestNumberLen; }
            set { this.projectTestNumberLen = value; }
        }

        public string TestReportTitle
        {
            get { return this.testReportTitle; }
            set { this.testReportTitle = value; }
        }
    }
}
