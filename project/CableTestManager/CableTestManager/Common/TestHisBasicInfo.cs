using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CableTestManager.Business.Implements;
using CableTestManager.Entity;
using System.Data;

namespace CableTestManager.Common
{
    public class TestHisBasicInfo
    {
        public static THistoryDataBasic QueryProTestHisBasicInfo(string testSerial)
        {
            THistoryDataBasic hisBasicInfo = new THistoryDataBasic();
            if (testSerial == "")
                return hisBasicInfo;
            THistoryDataBasicManager infoManager = new THistoryDataBasicManager();
            var dt = infoManager.GetDataSetByWhere($"where TestSerialNumber='{testSerial}'").Tables[0];
            if (dt.Rows.Count <= 0)
                return hisBasicInfo;
            foreach (DataRow dr in dt.Rows)
            {
                hisBasicInfo.TestSerialNumber = testSerial;
                hisBasicInfo.ProjectName = dr["ProjectName"].ToString();
                hisBasicInfo.TestCableName = dr["TestCableName"].ToString();
                hisBasicInfo.TestStartDate = dr["TestStartDate"].ToString();
                hisBasicInfo.TestEndDate = dr["TestEndDate"].ToString();
                hisBasicInfo.TestOperator = dr["TestOperator"].ToString();
                hisBasicInfo.EnvironmentTemperature = dr["EnvironmentTemperature"].ToString();
                hisBasicInfo.EnvironmentAmbientHumidity = dr["EnvironmentAmbientHumidity"].ToString();
                hisBasicInfo.FinalTestResult = dr["FinalTestResult"].ToString();
                hisBasicInfo.ConductTestResult = dr["ConductTestResult"].ToString();
                hisBasicInfo.ConductThreshold = double.Parse(dr["ConductThreshold"].ToString());
                hisBasicInfo.ShortCircuitTestResult = dr["ShortCircuitTestResult"].ToString();
                hisBasicInfo.ShortCircuitThreshold = double.Parse(dr["ShortCircuitThreshold"].ToString());
                hisBasicInfo.InsulateTestResult = dr["InsulateTestResult"].ToString();
                hisBasicInfo.InsulateThreshold = double.Parse(dr["InsulateThreshold"].ToString());
                hisBasicInfo.InsulateVoltage = double.Parse(dr["InsulateVoltage"].ToString());
                hisBasicInfo.InsulateHoldTime = double.Parse(dr["InsulateHoldTime"].ToString());
                hisBasicInfo.VoltageWithStandardTestResult = dr["VoltageWithStandardTestResult"].ToString();
                hisBasicInfo.VoltageWithStandardThreshold = double.Parse(dr["VoltageWithStandardThreshold"].ToString());
                hisBasicInfo.ConductTestExceptCount = int.Parse(dr["ConductTestExceptCount"].ToString());
                hisBasicInfo.ShortcircuitTestExceptCount = int.Parse(dr["ShortcircuitTestExceptCount"].ToString());
                hisBasicInfo.InsulateTestExceptCount = int.Parse(dr["InsulateTestExceptCount"].ToString());
                hisBasicInfo.VoltageWithStandardTestExceptCount = int.Parse(dr["VoltageWithStandardTestExceptCount"].ToString());
            }
            return hisBasicInfo;
        }
    }
}
