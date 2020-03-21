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
    public partial class EditSwitchWorkWear : Telerik.WinControls.UI.RadForm
    {
        public string switchWorkWearCode;
        public string switchWorkWearType;
        public string remark;

        public EditSwitchWorkWear(string switchCode,string switchType,string ramark)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.tb_switchWorkWearCode.Text = switchCode;
            this.tb_switchType.Text = switchType;
            this.tb_switchWorkWearCode.ReadOnly = true;
            this.tb_remark.Text = remark;

            this.btn_apply.Click += Btn_apply_Click;
            this.btn_cancel.Click += Btn_cancel_Click;
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_apply_Click(object sender, EventArgs e)
        {
            CommitData();
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void CommitData()
        {
            if (this.tb_switchType.Text == "")
            {
                MessageBox.Show("转接型号不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            this.switchWorkWearCode = this.tb_switchWorkWearCode.Text.Trim();
            this.switchWorkWearType = this.tb_switchType.Text.Trim();
            this.remark = this.tb_remark.Text.Trim();
        }
    }
}
