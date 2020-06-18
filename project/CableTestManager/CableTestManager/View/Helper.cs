using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace CableTestManager
{
    public partial class Helper : Telerik.WinControls.UI.RadForm
    {
        public Helper()
        {
            InitializeComponent();
        }

        private void Helper_Load(object sender, EventArgs e)
        {
            this.btn_ok.Click += Btn_ok_Click;
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //System.Diagnostics.Process.Start("iexplore.exe", linkLabel1.Text);
        }
    }
}
