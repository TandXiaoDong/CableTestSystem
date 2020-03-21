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
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        public RadForm1()
        {
            InitializeComponent();
        }

        private void RadForm1_Load(object sender, EventArgs e)
        {
            this.comboBox2.Items.AddRange(new string[] { "aa", "ff" });
            this.comboBox1.Items.AddRange(new string[] { "aa", "ff" });
            this.comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            this.comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = this.comboBox2.Text;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = this.comboBox1.Text;
        }
    }
}
