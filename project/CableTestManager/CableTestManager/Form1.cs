using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormTelerik.CommonUI;

namespace CableTestManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox2.Items.AddRange(new string[] { "aa", "ff" });
            this.comboBox1.Items.AddRange(new string[] { "aa", "ff" });
            this.comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            this.comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;

            this.radDock1.RemoveAllDocumentWindows();
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = this.comboBox2.Text;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = this.comboBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.radDock1.AddDocument(this.documentWindow1);
            MessageBox.Show("Mess");
        }
    }
}
