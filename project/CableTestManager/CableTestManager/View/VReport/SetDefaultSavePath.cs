using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonUtils.FileHelper;

namespace CableTestManager.View
{
    public partial class SetDefaultSavePath : Form
    {
        public string reportDir;
        public SetDefaultSavePath(string fReportDir)
        {
            InitializeComponent();
            this.textBox_savePath.Text = fReportDir;
        }

        private void SetDefaultSavePath_Load(object sender, EventArgs e)
        {
            this.btnQuit.Click += BtnQuit_Click;
            this.btnSubmit.Click += BtnSubmit_Click;
            this.btnSelectSavePath.Click += BtnSelectSavePath_Click;
            this.btn_openDir.Click += Btn_openDir_Click;
        }

        private void Btn_openDir_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(this.reportDir))
                return;
            System.Diagnostics.Process.Start(this.reportDir);
        }

        private void BtnSelectSavePath_Click(object sender, EventArgs e)
        {
            this.textBox_savePath.Text = FileSelect.GetDirectorPath();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (this.textBox_savePath.Text.Trim() == "")
            {
                MessageBox.Show("路径不能设置为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            this.reportDir = this.textBox_savePath.Text.Trim();
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
