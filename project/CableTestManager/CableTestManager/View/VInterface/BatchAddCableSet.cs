using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CableTestManager.View.VInterface
{
    public partial class BatchAddCableSet : RadForm
    {
        private int contactMax;
        private int contactMin;
        public static int currentValue;
        public BatchAddCableSet(int contactMax,int contactMin)
        {
            InitializeComponent();
            this.contactMax = contactMax;
            this.contactMin = contactMin;
            this.StartPosition = FormStartPosition.CenterParent;
            this.btnCancel.Click += BtnCancel_Click;
            this.btnApply.Click += BtnApply_Click;
            this.numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
            this.lbxLimit.Text = $"({this.contactMin}~{this.contactMax})";
            this.numericUpDown1.Value = this.contactMax;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            var value = this.numericUpDown1.Value;
            if (value > this.contactMax || value < this.contactMin)
            {
                MessageBox.Show("输入值已超过取值范围！", "提示", MessageBoxButtons.OK);
                this.numericUpDown1.Value = this.contactMax;
            }
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            currentValue = (int)this.numericUpDown1.Value;
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
