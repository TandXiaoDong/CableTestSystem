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

namespace CableTestManager.CUserManager
{
    public partial class EditRole : Form
    {
        public string roleName;
        public string roleRemark;

        public EditRole(string textTile,string roleName,string remark)
        {
            InitializeComponent();
            this.Text = textTile;
            if (roleName != "")
            {
                this.tb_roleName.Text = roleName;
            }
            if (remark != "")
            {
                this.tb_remark.Text = remark;
            }
        }

        private void EditRole_Load(object sender, EventArgs e)
        {
            this.btn_cancel.Click += Btn_cancel_Click;
            this.btn_ok.Click += Btn_ok_Click;
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
            if (this.tb_roleName.Text.Trim() == "")
            {
                MessageBox.Show("角色名称不能为空!","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (IsExistRole(this.tb_roleName.Text.Trim()))
            {
                MessageBox.Show("该名称已存在，请重新编辑！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            this.roleName = this.tb_roleName.Text.Trim();
            this.roleRemark = this.tb_remark.Text.Trim();
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsExistRole(string role)
        {
            TRoleManager roleManager = new TRoleManager();
            var count = roleManager.GetRowCountByWhere($"where UserRole='{role}'");
            if (count > 0)
                return true;
            return false;
        }
    }
}
