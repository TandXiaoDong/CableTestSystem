using System.Configuration;

namespace CableTestManager.Common
{
    public class SelfCheckParams
    {
        public static double GetSelfCheckParams()
        {
            double devSelfCheckThreshold;
            double.TryParse(ConfigurationManager.AppSettings["devSelfCheckThreshold"].ToString(), out devSelfCheckThreshold);
            if (devSelfCheckThreshold == 0)
                devSelfCheckThreshold = 500;
            return devSelfCheckThreshold;
        }
    }
}
