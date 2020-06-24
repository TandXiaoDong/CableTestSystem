using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CableTestManager.Model;

namespace CableTestManager.View
{
    public partial class ReportFormatSet : Form
    {
        private DeviceConfig devConfig;
        public ReportFormatSet(DeviceConfig config)
        {
            InitializeComponent();
            this.devConfig = config;
            this.tb_reportTitle.Text = this.devConfig.TestReportTitle;
        }

        private void ReportFormatSet_Load(object sender, EventArgs e)
        {
            this.btn_apply.Click += Btn_apply_Click;
            this.btn_cancel.Click += Btn_cancel_Click;
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_apply_Click(object sender, EventArgs e)
        {
            if (this.tb_reportTitle.Text.Trim() == "")
            {
                MessageBox.Show("报告标题为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.devConfig.TestReportTitle = this.tb_reportTitle.Text.Trim();
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
