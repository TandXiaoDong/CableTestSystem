using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace CableTestManager.View.VSelfStydy
{
    public partial class frmSefStudy : Telerik.WinControls.UI.RadForm
    {
        public int pinMin;
        public int pinMax;
        public float conductThresholdByPin;
        public StudyTypeEnum studyTypeEnum;

        public enum StudyTypeEnum
        {
            PartStudyByPin,
            AllStudyByPin,
            PartStudyByInterface,
            AllStudyByInterface,
            CancelStudy
        }

        public frmSefStudy()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void frmSefStudy_Load(object sender, EventArgs e)
        {
            this.num_min.Maximum = 1024;
            this.num_max.Maximum = 1024;
            this.num_max.Minimum = 0;
            this.num_min.Minimum = 0;
            this.conductionThresholdByPin.Maximum = 1200;
            this.conductionThresholdByPin.Minimum = 0;

            this.btn_defineStudyByPin.Click += Btn_defineStudyByPin_Click;
            this.btn_allStudyByPin.Click += Btn_allStudyByPin_Click;
            this.btn_cancelByPin.Click += Btn_cancelByPin_Click;
            this.btn_cancelByInterface.Click += Btn_cancelByInterface_Click;
            this.btn_studyAllByInterface.Click += Btn_studyAllByInterface_Click;
            this.btn_studyByInterface.Click += Btn_studyByInterface_Click;
        }

        private void Btn_studyByInterface_Click(object sender, EventArgs e)
        {
            
        }

        private void Btn_studyAllByInterface_Click(object sender, EventArgs e)
        {
            
        }

        private void Btn_cancelByInterface_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void Btn_cancelByPin_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void Btn_allStudyByPin_Click(object sender, EventArgs e)
        {
            this.pinMax = 1024;
            this.pinMin = 1;
            this.conductThresholdByPin = (float)this.conductionThresholdByPin.Value;
            this.Close();
            this.DialogResult = DialogResult.OK;
            this.studyTypeEnum = StudyTypeEnum.AllStudyByPin;

        }

        private void Btn_defineStudyByPin_Click(object sender, EventArgs e)
        {
            if (this.num_max.Value == 0)
            {
                MessageBox.Show("学习范围无效！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (this.num_min.Value > this.num_max.Value)
            {
                MessageBox.Show("指定范围无效！","提示",MessageBoxButtons.OK);
                return;
            }
            this.pinMax = (int)this.num_max.Value;
            this.pinMin = (int)this.num_min.Value;
            this.conductThresholdByPin = (float)this.conductionThresholdByPin.Value;
            this.Close();
            this.DialogResult = DialogResult.OK;
            this.studyTypeEnum = StudyTypeEnum.PartStudyByPin;
        }
    }
}
