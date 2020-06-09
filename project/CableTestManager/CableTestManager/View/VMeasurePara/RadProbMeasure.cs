using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace CableTestManager.View
{
    public partial class RadProbMeasure : Telerik.WinControls.UI.RadForm
    {
        public int pinMin;
        public int pinMax;
        public float thresholdVal;
        public string hexMeasureMethod = "02";

        public RadProbMeasure()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void RadProbMeasure_Load(object sender, EventArgs e)
        {
            this.btn_InterStart.Click += Btn_InterStart_Click;
            this.btn_InterCancel.Click += Btn_InterCancel_Click;

            this.btn_fstartTest.Click += Btn_fstartTest_Click;
            this.btn_fcancel.Click += Btn_fcancel_Click;
        }

        private void Btn_fcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_InterCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_InterStart_Click(object sender, EventArgs e)
        {
           
        }

        private void Btn_fstartTest_Click(object sender, EventArgs e)
        {
            this.pinMax = (int)this.num_fmaxPin.Value;
            this.pinMin = (int)this.num_fminPin.Value;
            this.thresholdVal = (float)this.num_fthreshold.Value;
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
