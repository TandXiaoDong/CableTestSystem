using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CableTestManager.Model
{
    public class CableTestProcess
    {
        public enum CableTestMethod
        {
            SignalTest,
            OneKeyTest
        }

        /// <summary>
        /// 一键测试或者单个测试,当点击一键测试或单项测试时更新
        /// </summary>
        public CableTestMethod CableTestMethodEnum { get; set; }

        /// <summary>
        /// 当前测试项目
        /// </summary>
        public string CurrentTestProject { get; set; }

        /// <summary>
        /// 项目测试序列
        /// </summary>
        public string ProjectTestNumber { get; set; }

        public List<CableTestProcessParams> CableTestProcessParamsList { get; set; }
    }

    public class CableTestProcessParams
    {
        public enum CableTestType
        {
            ConductTest,
            ShortCircuitTest,
            InsulateTest,
            PressureWithVoltageTest,
            SelfStudyTest,
            None
        }

        public enum TestState
        { 
            /// <summary>
            /// 未启动测试
            /// </summary>
            UnStart,
            /// <summary>
            /// 启动测试
            /// </summary>
            Started,
            /// <summary>
            /// 测试完成
            /// </summary>
            Completed
        }


        /// <summary>
        /// 测试项类别
        /// </summary>
        public CableTestType CableTestTypeEnum { get; set; }

        /// <summary>
        /// 测试项测试状态
        /// </summary>
        public TestState TestItemStateEnum { get; set; }

        /// <summary>
        /// 过去是否测试过
        /// </summary>
        public bool IsUsedTestCompled { get; set; }


        /// <summary>
        /// 当前测试项目的测试异常数统计
        /// </summary>
        public int CurrentTestExceptCount { get; set; }

        /// <summary>
        /// 测试阈值，用于当前项目的测试判定标准，打开项目时/根据项目更新
        /// </summary>
        public double TestPassThreshold { get; set; }

        /// <summary>
        /// 当前测试项的开始测试时间
        /// </summary>
        public string TestItemStartDate { get; set; }

        /// <summary>
        /// 当前测试项的结束测试时间
        /// </summary>
        public string TestItemEndDate { get; set; }
    }
}
