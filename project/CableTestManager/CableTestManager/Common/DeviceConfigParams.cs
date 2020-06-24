using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CommonUtils.FileHelper;
using CableTestManager.Model;

namespace CableTestManager.Common
{
    public class DeviceConfigParams
    {
        #region 常量
        public const string CableTestSystemName = "线束测试系统";

        private const string DEVICE_CONFIG_FILE_NAME = "DeviceConfig.ini";
        private const string DEVICE_CONFIG_SECTION = "SERVICE";
        private const string DEVICE_CONFIG_IS_AUTO_KEY = "IsAutoConnect";
        private const string DEVICE_CONFIG_SERVER_URL_KEY = "serviceURL";
        private const string DEVICE_CONFIG_SERVER_PORT_KEY = "servicePort";
        private const string REPORT_SECTION_PATH = "REPORT";
        private const string REPORT__KEY_FILE_DIR = "reportDir";
        private const string REPORT_KEY_REPORT_TITLE = "reportTitle";

        private const string DEVICE_CONFIG_SECTION_DEVICE = "DEVICE";
        private const string DEVICE_CONFIG_KEY_COMPENSATE = "compensateState";
        private const string DEVICE_CONFIG_KEY_ASS_COMPENSATE = "assCompensateVal";
        private const string DEVICE_CONFIG_KEY_INSULATE_VOLTAGE_COMPENSATE = "insulateVolCompensateVal";
        private const string DEVICE_CONFIG_KEY_INSULATE_ASS_COMPENSATE = "insulateAssCompensateVal";
        private const string DEVICE_CONFIG_KEY_TEMPERATURE = "temperature";
        private const string DEVICE_CONFIG_KEY_HUMIDITY = "humidity";
        #endregion

        #region INI CONFIG FILE FOR FIXED TESTER STANDARD DEFAULT PARAMS
        private const string CONFIG_DIRECTORY_NAME = "CONFIG";
        private const string CONFIG_SECTION_NAME = "FIX_STANDARD_PARAMS";
        private const string CONFIG_SECTION_TEST_NAME = "TEST_INFO";
        private const string PROJECT_TEST_NUMBER_LEN_KEY = "test_number_length";
        private const string CONFIG_KEY_CONDUCTION_THRESHOLD = "conductThreshold";
        private const string CONFIG_KEY_SHORTCIRCUIT_THRESHOLD = "shortCircuitThreshold";
        private const string CONFIG_KEY_INSULATE_THRESHOLD = "insulateThreshold";
        private const string CONFIG_KEY_INSULATE_VOLTAGE = "insulateVoltage";
        private const string CONFIG_KEY_INSULATE_HOLD_TIME = "insulateHoldTime";
        private const string CONFIG_KEY_PRESSURE_PROOF_THRESHOLD = "pressureWithVoltagethreshold";
        #endregion

        private static string curConfigPath;


        public static void InitDefaultConfig(DeviceConfig deviceConfig, string configPath)
        {
            configPath += DEVICE_CONFIG_FILE_NAME;
            curConfigPath = configPath;
            if (!File.Exists(configPath))
            {
                var defaultDir = "C:\\cableTestReport\\";
                deviceConfig.ReportDirectory = defaultDir;
                SaveDeviceConfig(deviceConfig);
            }
            else
            {
                deviceConfig.ReportDirectory = INIFile.GetValue(REPORT_SECTION_PATH, REPORT__KEY_FILE_DIR, configPath).ToString();
                deviceConfig.TestReportTitle = INIFile.GetValue(REPORT_SECTION_PATH, REPORT_KEY_REPORT_TITLE, configPath).ToString();
                deviceConfig.ServerUrl = INIFile.GetValue(DEVICE_CONFIG_SECTION, DEVICE_CONFIG_SERVER_URL_KEY, configPath).ToString();
                var portStr = INIFile.GetValue(DEVICE_CONFIG_SECTION, DEVICE_CONFIG_SERVER_PORT_KEY, configPath).ToString();
                int port = 0;
                int.TryParse(portStr, out port);
                deviceConfig.ServerPort = port;

                var testNumberLen = INIFile.GetValue(CONFIG_SECTION_TEST_NAME, PROJECT_TEST_NUMBER_LEN_KEY, configPath).ToString();
                int testnLen;
                if (testNumberLen != "")
                {
                    int.TryParse(testNumberLen, out testnLen);
                    deviceConfig.ProjectTestNumberLen = testnLen;
                }
                else
                    deviceConfig.ProjectTestNumberLen = 8;
                double conductThreshold, circuitThreshold, insulateThreshold, insulateVoltage, insulateHoldTime, pressureWithVoltageThreshold;
                double.TryParse(INIFile.GetValue(CONFIG_SECTION_NAME, CONFIG_KEY_CONDUCTION_THRESHOLD, configPath).ToString(), out conductThreshold);
                if (conductThreshold != 0)
                    deviceConfig.ConductThreshold = conductThreshold;
                double.TryParse(INIFile.GetValue(CONFIG_SECTION_NAME, CONFIG_KEY_SHORTCIRCUIT_THRESHOLD, configPath).ToString(), out circuitThreshold);
                if (circuitThreshold != 0)
                    deviceConfig.ShortCircuitThreshold = circuitThreshold;
                double.TryParse(INIFile.GetValue(CONFIG_SECTION_NAME, CONFIG_KEY_INSULATE_THRESHOLD, configPath).ToString(), out insulateThreshold);
                if (insulateThreshold != 0)
                    deviceConfig.InsulateThreshold = insulateThreshold;
                double.TryParse(INIFile.GetValue(CONFIG_SECTION_NAME, CONFIG_KEY_INSULATE_VOLTAGE, configPath).ToString(), out insulateVoltage);
                if (insulateVoltage != 0)
                    deviceConfig.InsulateVoltage = insulateVoltage;
                double.TryParse(INIFile.GetValue(CONFIG_SECTION_NAME, CONFIG_KEY_INSULATE_HOLD_TIME, configPath).ToString(), out insulateHoldTime);
                if (insulateHoldTime != 0)
                    deviceConfig.InsulateHoldTime = insulateHoldTime;
                double.TryParse(INIFile.GetValue(CONFIG_SECTION_NAME, CONFIG_KEY_PRESSURE_PROOF_THRESHOLD, configPath).ToString(), out pressureWithVoltageThreshold);
                if (pressureWithVoltageThreshold != 0)
                    deviceConfig.PressureWithVoltageThreshold = pressureWithVoltageThreshold;

                deviceConfig.CompensateState = INIFile.GetValue(DEVICE_CONFIG_SECTION_DEVICE, DEVICE_CONFIG_KEY_COMPENSATE, configPath).ToString();
                double temperature, humidity, assCompensate, insulateVolCompensate, insulateAssCompensate;
                double.TryParse(INIFile.GetValue(DEVICE_CONFIG_SECTION_DEVICE, DEVICE_CONFIG_KEY_TEMPERATURE, configPath).ToString(), out temperature);
                if (temperature != 0)
                    deviceConfig.Temperature = temperature;
                double.TryParse(INIFile.GetValue(DEVICE_CONFIG_SECTION_DEVICE, DEVICE_CONFIG_KEY_HUMIDITY, configPath).ToString(), out humidity);
                if (humidity != 0)
                    deviceConfig.Humidity = humidity;
                double.TryParse(INIFile.GetValue(DEVICE_CONFIG_SECTION_DEVICE, DEVICE_CONFIG_KEY_ASS_COMPENSATE, configPath).ToString(), out assCompensate);
                double.TryParse(INIFile.GetValue(DEVICE_CONFIG_SECTION_DEVICE, DEVICE_CONFIG_KEY_INSULATE_VOLTAGE_COMPENSATE, configPath).ToString(), out insulateVolCompensate);
                double.TryParse(INIFile.GetValue(DEVICE_CONFIG_SECTION_DEVICE, DEVICE_CONFIG_KEY_INSULATE_ASS_COMPENSATE, configPath).ToString(), out insulateAssCompensate);
                if (assCompensate != 0)
                    deviceConfig.AssCompensateVal = assCompensate;
                if (insulateVolCompensate != 0)
                    deviceConfig.InsulateVolCompensateVal = insulateVolCompensate;
                if (insulateAssCompensate != 0)
                    deviceConfig.InsulateAssCompensateVal = insulateAssCompensate;
            }
        }

        public static void SaveDeviceConfig(DeviceConfig deviceConfig)
        {
            INIFile.SetValue(REPORT_SECTION_PATH, REPORT__KEY_FILE_DIR, deviceConfig.ReportDirectory, curConfigPath);
            INIFile.SetValue(REPORT_SECTION_PATH, REPORT_KEY_REPORT_TITLE, deviceConfig.TestReportTitle, curConfigPath);
            INIFile.SetValue(CONFIG_SECTION_TEST_NAME, PROJECT_TEST_NUMBER_LEN_KEY, deviceConfig.ProjectTestNumberLen.ToString(), curConfigPath);
            INIFile.SetValue(DEVICE_CONFIG_SECTION, DEVICE_CONFIG_SERVER_URL_KEY, deviceConfig.ServerUrl, curConfigPath);
            INIFile.SetValue(DEVICE_CONFIG_SECTION, DEVICE_CONFIG_SERVER_PORT_KEY, deviceConfig.ServerPort.ToString(), curConfigPath);

            INIFile.SetValue(CONFIG_SECTION_NAME, CONFIG_KEY_CONDUCTION_THRESHOLD, deviceConfig.ConductThreshold.ToString(), curConfigPath);
            INIFile.SetValue(CONFIG_SECTION_NAME, CONFIG_KEY_SHORTCIRCUIT_THRESHOLD, deviceConfig.ShortCircuitThreshold.ToString(), curConfigPath);
            INIFile.SetValue(CONFIG_SECTION_NAME, CONFIG_KEY_INSULATE_THRESHOLD, deviceConfig.InsulateThreshold.ToString(), curConfigPath);
            INIFile.SetValue(CONFIG_SECTION_NAME, CONFIG_KEY_INSULATE_VOLTAGE, deviceConfig.InsulateVoltage.ToString(), curConfigPath);
            INIFile.SetValue(CONFIG_SECTION_NAME, CONFIG_KEY_INSULATE_HOLD_TIME, deviceConfig.InsulateHoldTime.ToString(), curConfigPath);
            INIFile.SetValue(CONFIG_SECTION_NAME, CONFIG_KEY_PRESSURE_PROOF_THRESHOLD, deviceConfig.PressureWithVoltageThreshold.ToString(), curConfigPath);

            INIFile.SetValue(DEVICE_CONFIG_SECTION_DEVICE, DEVICE_CONFIG_KEY_COMPENSATE, deviceConfig.CompensateState, curConfigPath);
            INIFile.SetValue(DEVICE_CONFIG_SECTION_DEVICE, DEVICE_CONFIG_KEY_TEMPERATURE, deviceConfig.Temperature.ToString(), curConfigPath);
            INIFile.SetValue(DEVICE_CONFIG_SECTION_DEVICE, DEVICE_CONFIG_KEY_HUMIDITY, deviceConfig.Humidity.ToString(), curConfigPath);
            INIFile.SetValue(DEVICE_CONFIG_SECTION_DEVICE, DEVICE_CONFIG_KEY_ASS_COMPENSATE, deviceConfig.AssCompensateVal.ToString(), curConfigPath);
            INIFile.SetValue(DEVICE_CONFIG_SECTION_DEVICE, DEVICE_CONFIG_KEY_INSULATE_VOLTAGE_COMPENSATE, deviceConfig.InsulateVolCompensateVal.ToString(), curConfigPath);
            INIFile.SetValue(DEVICE_CONFIG_SECTION_DEVICE, DEVICE_CONFIG_KEY_INSULATE_ASS_COMPENSATE, deviceConfig.InsulateAssCompensateVal.ToString(), curConfigPath);
        }
    }
}
