using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CableTestManager.Business.Implements;

namespace CableTestManager.View.VSelfStydy
{
    public partial class ImportCableLibrary : Form
    {
        public int testMethod;
        public string cableLibName;
        public ImportCableLibrary()
        {
            InitializeComponent();
        }

        private void ImportCableLibrary_Load(object sender, EventArgs e)
        {
            this.cb_measureMethod.MultiColumnComboBoxElement.Columns.Add("Name");
            this.cb_measureMethod.EditorControl.Rows.Add("二线法");
            this.cb_measureMethod.EditorControl.Rows.Add("四线法");
            this.cb_measureMethod.EditorControl.ShowColumnHeaders = false;
            this.cb_measureMethod.EditorControl.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.cb_measureMethod.SelectedIndex = 0;

            this.btn_cancel.Click += Btn_cancel_Click;
            this.btn_ok.Click += Btn_ok_Click;
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
            if (this.tb_cableName.Text.Trim() == "")
            {
                this.tb_cableName.Focus();
                MessageBox.Show("线束库名称不能为空！","提示",MessageBoxButtons.OK);
                return;
            }
            if (this.cb_measureMethod.Text.Trim() == "")
            {
                MessageBox.Show("请选择测量方法！","提示",MessageBoxButtons.OK);
                return;
            }
            this.cableLibName = this.tb_cableName.Text.Trim();
            if (this.cb_measureMethod.SelectedIndex == 0)
                this.testMethod = 2;
            else if (this.cb_measureMethod.SelectedIndex == 1)
                this.testMethod = 4;
            if (IsCableExist(this.cableLibName))
            {
                this.tb_cableName.Focus();
                MessageBox.Show("线束名称已存在，请重新编辑线束名称！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsCableExist(string cableName)
        {
            TCableTestLibraryManager cableManage = new TCableTestLibraryManager();
            var count = cableManage.GetRowCountByWhere($"where CableName = '{cableName}'");
            if (count > 0)
                return true;
            return false;
        }
    }
}
