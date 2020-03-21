using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using CableTestManager.Business;
using CableTestManager.Business.Implements;

namespace CableTestManager.View.VInterface
{
    public partial class AddSwitchWorkWear : Telerik.WinControls.UI.RadForm
    {
        public string switchWorkWearCode;
        public string switchType;
        public string remark;

        public AddSwitchWorkWear()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
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
            if (this.tb_switchWorkWearCode.Text.Trim() == "")
            {
                MessageBox.Show("转接工装代号不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (this.tb_switchType.Text.Trim() == "")
            {
                MessageBox.Show("转接型号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TSwitchWorkWearLibraryManager switchWorkWearLibraryManager = new TSwitchWorkWearLibraryManager();
            var dt = switchWorkWearLibraryManager.GetDataSetByWhere($"where SwitchWorkWearCode like '%{this.tb_switchWorkWearCode.Text}%'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("转接工装代号已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.switchWorkWearCode = this.tb_switchWorkWearCode.Text.Trim();
            this.switchType = this.tb_switchType.Text.Trim();
            this.remark = this.tb_remark.Text.Trim();
        }
    }
}
