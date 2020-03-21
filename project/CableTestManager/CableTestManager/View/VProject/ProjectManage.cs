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
using WindowsFormTelerik.ControlCommon;
using CableTestManager.Model;

namespace CableTestManager.View.VProject
{
    public partial class ProjectManage : Telerik.WinControls.UI.RadForm
    {
        private TProjectBasicInfoManager projectInfoManager;
        private CableJudgeThreshold judgeThreshold;
        public string openProjectName;
        public OperateType operateType;

        public enum OperateType
        {
            OpenProject,
            DeleteProject,
            EditProject
        }

        public ProjectManage(CableJudgeThreshold cableJudgeThreshold)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.judgeThreshold = cableJudgeThreshold;
        }

        private void ProjectManage_Load(object sender, EventArgs e)
        {
            projectInfoManager = new TProjectBasicInfoManager();
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,true,6);
            this.radGridView1.ReadOnly = true;
            QueryProjectInfo();

            this.tb_queryFilter.TextChanged += Tb_queryFilter_TextChanged;
            this.radGridView1.CellDoubleClick += RadGridView1_CellDoubleClick;
            this.btn_cancel.Click += Btn_cancel_Click;
            this.btn_openProject.Click += Btn_openProject_Click;
            this.btn_copyProject.Click += Btn_copyProject_Click;
            this.btn_editProject.Click += Btn_editProject_Click;
            this.btn_deleteProject.Click += Btn_deleteProject_Click;
        }

        private void RadGridView1_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            EnterEditProject();
        }

        private void Tb_queryFilter_TextChanged(object sender, EventArgs e)
        {
            QueryProjectInfo();
        }

        private void Btn_deleteProject_Click(object sender, EventArgs e)
        {
            var currentProjectIndex = this.radGridView1.CurrentRow.Index;
            if (currentProjectIndex < 0)
            {
                MessageBox.Show("请选择要删除的项目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var selectProject = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            var delRow = projectInfoManager.DeleteByWhere($"where ProjectName = '{selectProject}'");
            if (delRow > 0)
            {
                MessageBox.Show($"已删除项目{selectProject}！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            QueryProjectInfo();
            this.DialogResult = DialogResult.OK;
            operateType = OperateType.DeleteProject;
        }

        private void Btn_editProject_Click(object sender, EventArgs e)
        {
            EnterEditProject();
        }

        private void EnterEditProject()
        {
            var currentProjectIndex = this.radGridView1.CurrentRow.Index;
            if (currentProjectIndex < 0)
            {
                MessageBox.Show("请选择要编辑的项目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var selectProject = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            RadProjectCreat radProjectCreat = new RadProjectCreat("编辑项目", selectProject, judgeThreshold, true);
            radProjectCreat.ShowDialog();
        }

        private void Btn_copyProject_Click(object sender, EventArgs e)
        {
            
        }

        private void Btn_openProject_Click(object sender, EventArgs e)
        {
            var currentProjectIndex = this.radGridView1.CurrentRow.Index;
            if (currentProjectIndex < 0)
            {
                MessageBox.Show("请选择要打开的项目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ;
            }
            openProjectName = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            this.Close();
            this.DialogResult = DialogResult.OK;
            operateType = OperateType.OpenProject;
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QueryProjectInfo()
        {
            ClearGridVIew();
            var selectSQL = "";
            if (this.tb_queryFilter.Text.Trim() != "")
                selectSQL = $"where ProjectName like '%{this.tb_queryFilter.Text.Trim()}%'";
            var dt = projectInfoManager.GetDataSetByWhere(selectSQL).Tables[0];
            if (dt.Rows.Count < 1)
                return;
            foreach (DataRow dr in dt.Rows)
            {
                var projectName = dr["ProjectName"].ToString();
                var testCableName = dr["TestCableName"].ToString();
                var batchNumber = dr["BatchNumber"].ToString();
                var IsCommonProject = dr["IsCommonProject"].ToString();
                var remark = dr["Remark"].ToString();
                if (IsExistProject(projectName))
                    continue;
                this.radGridView1.Rows.AddNew();
                var iCount = this.radGridView1.RowCount;
                this.radGridView1.Rows[iCount - 1].Cells[0].Value = iCount;
                this.radGridView1.Rows[iCount - 1].Cells[1].Value = projectName;
                this.radGridView1.Rows[iCount - 1].Cells[2].Value = testCableName;
                this.radGridView1.Rows[iCount - 1].Cells[3].Value = batchNumber;
                this.radGridView1.Rows[iCount - 1].Cells[4].Value = IsCommonProject;
                this.radGridView1.Rows[iCount - 1].Cells[5].Value = remark;
            }
        }

        private void ClearGridVIew()
        {
            if (this.radGridView1.RowCount < 1)
                return;
            for (int i = this.radGridView1.RowCount - 1; i >= 0; i--)
            {
                this.radGridView1.Rows[i].Delete();
            }
        }

        private bool IsExistProject(string project)
        {
            if (this.radGridView1.RowCount < 1)
                return false;
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                if (rowInfo.Cells[1].Value.ToString() == project)
                    return true;
            }
            return false;
        }
    }
}
