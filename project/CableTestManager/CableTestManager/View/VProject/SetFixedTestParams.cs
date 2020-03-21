using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using CableTestManager.Entity;

namespace CableTestManager.View.VProject
{
    public partial class SetFixedTestParams : Telerik.WinControls.UI.RadForm
    {
        private TProjectBasicInfo projectInfo;
        private bool IsEditView;
        public SetFixedTestParams(TProjectBasicInfo projectInfo,bool IsEdit)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.projectInfo = projectInfo;
            this.IsEditView = IsEdit;
        }

        private void Init()
        {
            this.rdbLowVoltage.CheckState = CheckState.Checked;

            this.dnConductionThreshold.Maximum = 100000;
            this.dnConductionThreshold.Minimum = 0;
            this.dnConductionThreshold.Increment = 1;
            this.dnConductionThreshold.DecimalPlaces = 3;
            if (!this.IsEditView)
                this.dnConductionThreshold.Value = 2;
            else
                this.dnConductionThreshold.Value = (decimal)this.projectInfo.ConductTestThreshold;

            this.dnConductionVoltage.Maximum = 2000;
            this.dnConductionVoltage.Minimum = 5;
            this.dnConductionVoltage.Increment = 1;
            this.dnConductionVoltage.DecimalPlaces = 0;
            if(!this.IsEditView)
                this.dnConductionVoltage.Value = 5;
            else
                this.dnConductionVoltage.Value = (decimal)this.projectInfo.ConductTestVoltage;

            this.dnConductionCurrentElect.Maximum = 30;
            this.dnConductionCurrentElect.Minimum = 0;
            this.dnConductionCurrentElect.Increment = 1;
            this.dnConductionCurrentElect.DecimalPlaces = 2;
            if (!this.IsEditView)
                this.dnConductionCurrentElect.Value = 1;
            else
                this.dnConductionCurrentElect.Value = (decimal)this.projectInfo.ConductTestCurrentElect;

            this.dnInsulateThreshold.Maximum = 2000;
            this.dnInsulateThreshold.Minimum = 0;
            this.dnInsulateThreshold.Increment = 1;
            this.dnInsulateThreshold.DecimalPlaces = 1;
            if (!this.IsEditView)
                this.dnInsulateThreshold.Value = 20;
            else
                this.dnInsulateThreshold.Value = (decimal)this.projectInfo.InsulateTestThreshold;

            this.dnInsulateHoldTime.Maximum = 120;
            this.dnInsulateHoldTime.Minimum = 0;
            this.dnInsulateHoldTime.Increment = 1;
            this.dnInsulateHoldTime.DecimalPlaces = 3;
            if (!this.IsEditView)
                this.dnInsulateHoldTime.Value = 1;
            else
                this.dnInsulateHoldTime.Value = (decimal)this.projectInfo.InsulateTestHoldTime;

            this.dnInsulateRaiseTime.Maximum = 120;
            this.dnInsulateRaiseTime.Minimum = 0;
            this.dnInsulateRaiseTime.Increment = 1;
            this.dnInsulateRaiseTime.DecimalPlaces = 1;
            if (!this.IsEditView)
                this.dnInsulateRaiseTime.Value = 40;
            else
                this.dnInsulateRaiseTime.Value = (decimal)this.projectInfo.InsulateTestRaiseTime;

            this.dnInsulateVoltage.Maximum = 1500;
            this.dnInsulateVoltage.Minimum = 30;
            this.dnInsulateVoltage.Increment = 1;
            this.dnInsulateVoltage.DecimalPlaces = 0;
            if (!this.IsEditView)
                this.dnInsulateVoltage.Value = 100;
            else
                this.dnInsulateVoltage.Value = (decimal)this.projectInfo.InsulateTestVoltage;

            if (this.projectInfo.InsulateHigthOrLowElect == 1)
                this.rdbLowVoltage.CheckState = CheckState.Checked;
            else if (this.projectInfo.InsulateHigthOrLowElect == 2)
                this.rdbHighVoltage.CheckState = CheckState.Checked;

            this.dnPressureProofThreshold.Maximum = 3;
            this.dnPressureProofThreshold.Minimum = 0;
            this.dnPressureProofThreshold.Increment = 1;
            this.dnPressureProofThreshold.DecimalPlaces = 2;
            if (!IsEditView)
                this.dnPressureProofThreshold.Value = 2;
            else
                this.dnPressureProofThreshold.Value = (decimal)this.projectInfo.VoltageWithStandardThreshold;

            this.dnPressureProofVoltage.Maximum = 1000;
            this.dnPressureProofVoltage.Minimum = 70;
            this.dnPressureProofVoltage.Increment = 1;
            this.dnPressureProofVoltage.DecimalPlaces = 0;
            if (!IsEditView)
                this.dnPressureProofVoltage.Value = 100;
            else
                this.dnPressureProofVoltage.Value = (decimal)this.projectInfo.VoltageWithStandardVoltage;

            this.dnPressureProofHoldTime.Maximum = 120;
            this.dnPressureProofHoldTime.Minimum = 0;
            this.dnPressureProofHoldTime.Increment = 1;
            this.dnPressureProofHoldTime.DecimalPlaces = 1;
            if (!IsEditView)
                this.dnPressureProofHoldTime.Value = 1;
            else
                this.dnPressureProofHoldTime.Value = (decimal)this.projectInfo.VoltageWithStandardHoldTime;
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
            this.projectInfo.ConductTestVoltage = (double)this.dnConductionVoltage.Value;
            this.projectInfo.ConductTestCurrentElect = (double)this.dnConductionCurrentElect.Value;

            this.projectInfo.InsulateTestThreshold = (double)this.dnInsulateThreshold.Value;
            this.projectInfo.InsulateTestVoltage = (double)this.dnInsulateVoltage.Value;
            this.projectInfo.InsulateTestHoldTime = (double)this.dnInsulateHoldTime.Value;
            this.projectInfo.InsulateTestRaiseTime = (double)this.dnInsulateRaiseTime.Value;
            if (this.rdbLowVoltage.CheckState == CheckState.Checked)
                this.projectInfo.InsulateHigthOrLowElect = 1;
            else
                this.projectInfo.InsulateHigthOrLowElect = 2;

            this.projectInfo.VoltageWithStandardThreshold = (double)this.dnPressureProofThreshold.Value;
            this.projectInfo.VoltageWithStandardVoltage = (double)this.dnPressureProofVoltage.Value;
            this.projectInfo.VoltageWithStandardHoldTime = (double)this.dnPressureProofHoldTime.Value;

            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
