using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CableTestManager.Model
{
    public class SelfStudyConfig
    {
        public enum SutdyTestTypeEnum
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

        public SutdyTestTypeEnum StudyTestType { get; set; }

        public StringBuilder TestInterAList { get; set; }

        public StringBuilder TestInterBList { get; set; }

        private string testMethod = "02";

        public int LimitMin { get; set; }

        public int LimitMax { get; set; }

        public double TestThresholdVal { get; set; }

        public string MeasureMethod
        {
            get { return this.testMethod; }
            set { this.testMethod = value; }
        }
    }

    public class SelfStudyTestContent
    {
        /// <summary>
        /// 接口类型A/B 01/02
        /// </summary>
        public int StudyInterType { get; set; }

        /// <summary>
        /// 设备接点值
        /// </summary>
        public int StudyDevInterPoint { get; set; }
    }
}
