using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CableTestManager.Model
{
    public class CableJudgeThreshold
    {
        public string ConductionThreshold { get; set; }

        public string IsConductionJudgeThanThreshold { get; set; }

        public string InsulateThreshold { get; set; }

        public string IsInsulateJudgeThanThreshold { get; set; }

        public string InsulateVoltage { get; set; }

        public string InsulateHoldTime { get; set; }

        public string PressureProofThreshold { get; set; }

        public string IsPressureJudgeThanThreshold { get; set; }

        public string PressureProofVoltage { get; set; }

        public string PressureProofHoldTime { get; set; }

    }
}
