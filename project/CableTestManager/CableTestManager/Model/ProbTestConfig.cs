using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CableTestManager.Model
{
    public class ProbTestConfig
    {
        public enum ProbTestTypeEnum
        {
            /// <summary>
            /// 范围学习
            /// </summary>
            ProbTestByLimit,

            /// <summary>
            /// 按接口学习
            /// </summary>
            ProbTestByInterface,
        }

        public ProbTestTypeEnum ProbTestType { get; set; }

        public StringBuilder TestInterAList { get; set; }

        public string testMethod = "02";

        public int LimitMin { get; set; }

        public int LimitMax { get; set; }

        public double TestThresholdVal { get; set; }

        public string MeasureMethod
        {
            get { return this.testMethod; }
            set { this.testMethod = value; }
        }
    }
}
