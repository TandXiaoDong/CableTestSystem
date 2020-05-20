using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using CableTestManager.Model;

namespace CableTestManager.View
{
    public partial class OneClickTestConfig : Telerik.WinControls.UI.RadForm
    {
        //选择的测试
        public bool IsCheckConductTest;
        public bool IsCheckCircuitTest;
        public bool IsCheckInsulateTest;
        public bool IsCheckPressureProofTest;

        //是否有完成过测试
        private bool IsConductCompletedTest;
        private bool IsShortCircuitCompletedTest;
        private bool IsInsulateCompletedTest;
        private bool IsPressureCompletedTest;

        private Queue<CableTestProcessParams.CableTestType> cableTestQueue;

        public OneClickTestConfig(Queue<CableTestProcessParams.CableTestType> cableTests)
        {
            InitializeComponent();
            this.cableTestQueue = cableTests;
        }

        private void OneClickTestConfig_Load(object sender, EventArgs e)
        {
            QueryTestRecord();
            this.btn_cancelTest.Click += Btn_cancelTest_Click;
            this.btn_oneClickTest.Click += Btn_oneClickTest_Click;
            this.cb_insulateTest.CheckStateChanged += Cb_insulateTest_CheckStateChanged;
            this.cb_pressureProofTest.CheckStateChanged += Cb_pressureProofTest_CheckStateChanged;
            this.cb_circuitTest.CheckStateChanged += Cb_circuitTest_CheckStateChanged;
            this.cb_conductTest.CheckStateChanged += Cb_conductTest_CheckStateChanged;
        }

        private void Cb_conductTest_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.cb_conductTest.CheckState == CheckState.Unchecked)
            {
                if (this.cb_circuitTest.Checked || this.cb_insulateTest.Checked || this.cb_pressureProofTest.Checked)
                {
                    this.cb_conductTest.CheckState = CheckState.Checked;
                }
            }
        }

        private void QueryTestRecord()
        { 
            //同时主程序也要更新测试状态，更新UI控件是否可操作
        }

        private void Cb_circuitTest_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.cb_circuitTest.Checked)
            {
                if (!this.IsConductCompletedTest)
                {
                    this.cb_conductTest.CheckState = CheckState.Checked;
                }
            }
            else
            {
                if (this.cb_insulateTest.Checked || this.cb_pressureProofTest.Checked)
                {
                    this.cb_circuitTest.CheckState = CheckState.Checked;
                }
            }
        }

        private void Cb_pressureProofTest_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.cb_pressureProofTest.Checked)
            {
                if (!this.IsShortCircuitCompletedTest)
                {
                    this.cb_circuitTest.CheckState = CheckState.Checked;
                }
            }
        }

        private void Cb_insulateTest_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.cb_insulateTest.Checked)
            {
                if (!this.IsShortCircuitCompletedTest)
                {
                    this.cb_circuitTest.CheckState = CheckState.Checked;
                }
            }
        }

        private void Btn_oneClickTest_Click(object sender, EventArgs e)
        {
            this.IsCheckConductTest = this.cb_conductTest.Checked;
            this.IsCheckCircuitTest = this.cb_circuitTest.Checked;
            this.IsCheckInsulateTest = this.cb_insulateTest.Checked;
            this.IsCheckPressureProofTest = this.cb_pressureProofTest.Checked;
            if (this.cb_conductTest.Checked)
            {
                this.cableTestQueue.Enqueue(CableTestProcessParams.CableTestType.ConductTest);
            }
            if (this.cb_circuitTest.Checked)
            {
                this.cableTestQueue.Enqueue(CableTestProcessParams.CableTestType.ShortCircuitTest);
            }
            if (this.cb_insulateTest.Checked)
            {
                this.cableTestQueue.Enqueue(CableTestProcessParams.CableTestType.InsulateTest);
            }
            if (this.cb_pressureProofTest.Checked)
            {
                this.cableTestQueue.Enqueue(CableTestProcessParams.CableTestType.PressureWithVoltageTest);
            }
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void Btn_cancelTest_Click(object sender, EventArgs e)
        {
            this.IsCheckConductTest = false;
            this.IsCheckCircuitTest = false;
            this.IsCheckInsulateTest = false;
            this.IsCheckPressureProofTest = false;
            this.Close();
        }
    }
}
