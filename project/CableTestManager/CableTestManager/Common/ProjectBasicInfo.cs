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
    public class ProjectBasicInfo
    {
        public static TProjectBasicInfo QueryProjectInfo(string projectName)
        {
            TProjectBasicInfo projectInfo = new TProjectBasicInfo();
            if (projectName == "")
                return projectInfo;
            TProjectBasicInfoManager infoManager = new TProjectBasicInfoManager();
            var dt = infoManager.GetDataSetByWhere($"where ProjectName='{projectName}'").Tables[0];
            if (dt.Rows.Count < 1)
                return projectInfo;
            foreach (DataRow dr in dt.Rows)
            {
                projectInfo.ProjectName = projectName;
                projectInfo.TestCableName = dr["TestCableName"].ToString();
                projectInfo.ConductTestThreshold = double.Parse(dr["ConductTestThreshold"].ToString());
                projectInfo.ConductTestVoltage = double.Parse(dr["ConductTestVoltage"].ToString());
                projectInfo.ConductTestCurrentElect = double.Parse(dr["ConductTestCurrentElect"].ToString());
                projectInfo.ShortCircuitTestThreshold = double.Parse(dr["ShortCircuitTestThreshold"].ToString());
                projectInfo.InsulateTestThreshold = double.Parse(dr["InsulateTestThreshold"].ToString());
                projectInfo.InsulateTestVoltage = double.Parse(dr["InsulateTestVoltage"].ToString());
                projectInfo.InsulateTestRaiseTime = double.Parse(dr["InsulateTestRaiseTime"].ToString());
                projectInfo.InsulateTestHoldTime = double.Parse(dr["InsulateTestHoldTime"].ToString());
                projectInfo.VoltageWithStandardThreshold = double.Parse(dr["VoltageWithStandardThreshold"].ToString());
                projectInfo.VoltageWithStandardHoldTime = double.Parse(dr["VoltageWithStandardHoldTime"].ToString());
                projectInfo.VoltageWithStandardVoltage = double.Parse(dr["VoltageWithStandardVoltage"].ToString());
                projectInfo.ResistanceCompensation = double.Parse(dr["ResistanceCompensation"].ToString());
                projectInfo.InsulateVolCompensation = double.Parse(dr["InsulateVolCompensation"].ToString());
                projectInfo.InsulateResCompensation = double.Parse(dr["InsulateResCompensation"].ToString());
                projectInfo.Temperature = double.Parse(dr["Temperature"].ToString());
                if (projectInfo.Temperature == 0)
                    projectInfo.Temperature = 25;
                projectInfo.AmbientHumidity = double.Parse(dr["AmbientHumidity"].ToString());
                if (projectInfo.AmbientHumidity == 0)
                    projectInfo.AmbientHumidity = 56;
            }
            return projectInfo;
        }
    }
}
