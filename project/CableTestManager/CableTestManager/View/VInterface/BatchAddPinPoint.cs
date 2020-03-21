using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace CableTestManager.View.VInterface
{
    public partial class BatchAddPinPoint : Telerik.WinControls.UI.RadForm
    {
        public NameRuleEnum nameRule;
        public string startPin;
        public int totalNum;

        public enum NameRuleEnum
        {
            NumberRaise,
            CapitalLetterRaise,
            SmallLetterRaise
        }
        public BatchAddPinPoint()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

            this.cb_nameRule.SelectedIndex = 0;
            this.numericUpDown1.Value = 64;
            this.tb_startPin.Text = "1";

            this.btn_apply.Click += Btn_apply_Click;
            this.btn_cancel.Click += Btn_cancel_Click;
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_apply_Click(object sender, EventArgs e)
        {
            if (this.cb_nameRule.SelectedIndex == 0)
                nameRule = NameRuleEnum.NumberRaise;
            var pin = this.tb_startPin.Text;
            var num = this.numericUpDown1.Value;
            if (pin == "")
            {
                MessageBox.Show("起始针点不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (num <= 0)
            {
                MessageBox.Show("未设置有效操作数量！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            this.startPin = pin;
            this.totalNum = (int)num;
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
