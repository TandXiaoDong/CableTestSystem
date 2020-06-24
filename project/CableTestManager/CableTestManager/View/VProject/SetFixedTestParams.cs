using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using CableTestManager.Entity;
using CableTestManager.Model;

namespace CableTestManager.View.VProject
{
    public partial class SetFixedTestParams : Telerik.WinControls.UI.RadForm
    {
        private TProjectBasicInfo projectInfo;
        private bool IsEditView;
        private DeviceConfig devConfig;
        public SetFixedTestParams(TProjectBasicInfo projectInfo,bool IsEdit, DeviceConfig config)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.projectInfo = projectInfo;
            this.IsEditView = IsEdit;
            this.devConfig = config;
        }

        private void Init()
        {
            this.dnConductionThreshold.Maximum = 1000000;
            this.dnConductionThreshold.Minimum = (decimal)0.1;
            this.dnConductionThreshold.Increment = 10;
            this.dnConductionThreshold.DecimalPlaces = 1;
            if (!this.IsEditView)
                this.dnConductionThreshold.Value = (decimal)this.devConfig.ConductThreshold;
            else
                this.dnConductionThreshold.Value = (decimal)this.projectInfo.ConductTestThreshold;

            this.dnShortCircuitthreshold.Maximum = 1000;
            this.dnShortCircuitthreshold.Minimum = (decimal)0.1;
            this.dnShortCircuitthreshold.Increment = 5;
            this.dnShortCircuitthreshold.DecimalPlaces = 1;
            if (!this.IsEditView)
                this.dnShortCircuitthreshold.Value = (decimal)this.devConfig.ShortCircuitThreshold;
            else
                this.dnShortCircuitthreshold.Value = (decimal)this.projectInfo.ShortCircuitTestThreshold;

            this.dnInsulateThreshold.Maximum = 1000;
            this.dnInsulateThreshold.Minimum = (decimal)0.1;
            this.dnInsulateThreshold.Increment = 10;
            this.dnInsulateThreshold.DecimalPlaces = 1;
            if (!this.IsEditView)
                this.dnInsulateThreshold.Value = (decimal)this.devConfig.InsulateThreshold;
            else
                this.dnInsulateThreshold.Value = (decimal)this.projectInfo.InsulateTestThreshold;

            this.dnInsulateHoldTime.Maximum = 120;
            this.dnInsulateHoldTime.Minimum = 1;
            this.dnInsulateHoldTime.Increment = 1;
            this.dnInsulateHoldTime.DecimalPlaces = 3;

            if (!this.IsEditView)
                this.dnInsulateHoldTime.Value = (decimal)this.devConfig.InsulateHoldTime;
            else
                this.dnInsulateHoldTime.Value = (decimal)this.projectInfo.InsulateTestHoldTime;

            this.dnInsulateVoltage.Maximum = 500;
            this.dnInsulateVoltage.Minimum = 10;
            this.dnInsulateVoltage.Increment = 5;
            this.dnInsulateVoltage.DecimalPlaces = 0;
            if (!this.IsEditView)
                this.dnInsulateVoltage.Value = (decimal)this.devConfig.InsulateVoltage;
            else
                this.dnInsulateVoltage.Value = (decimal)this.projectInfo.InsulateTestVoltage;
        }

        private void EventHandlers()
        {
            this.btnApply.Click += BtnApply_Click;
            this.btnClose.Click += BtnClose_Click;
        }

        private void SetFixedTestParams_Load(object sender, EventArgs e)
        {
            Init();
            EventHandlers();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            this.projectInfo.ConductTestThreshold = (double)this.dnConductionThreshold.Value;
            this.projectInfo.ShortCircuitTestThreshold = (double)this.dnShortCircuitthreshold.Value;
            this.projectInfo.InsulateTestThreshold = (double)this.dnInsulateThreshold.Value;
            this.projectInfo.InsulateTestVoltage = (double)this.dnInsulateVoltage.Value;
            this.projectInfo.InsulateTestHoldTime = (double)this.dnInsulateHoldTime.Value;

            this.devConfig.ConductThreshold = this.projectInfo.ConductTestThreshold;
            this.devConfig.ShortCircuitThreshold = this.projectInfo.ShortCircuitTestThreshold;
            this.devConfig.InsulateThreshold = this.projectInfo.InsulateTestThreshold;
            this.devConfig.InsulateVoltage = this.projectInfo.InsulateTestVoltage;
            this.devConfig.InsulateHoldTime = this.projectInfo.InsulateTestHoldTime;

            this.projectInfo.VoltageWithStandardThreshold = 0;
            this.projectInfo.VoltageWithStandardVoltage = 0;
            this.projectInfo.VoltageWithStandardHoldTime = 0;

            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
