using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using WindowsFormTelerik.GridViewExportData;
using CableTestManager.Business.Implements;
using CableTestManager.Business;
using CableTestManager.Entity;
using CableTestManager.Model;
using WindowsFormTelerik.ControlCommon;

namespace CableTestManager.View.VProject
{
    public partial class GroupTestStandardParams : Telerik.WinControls.UI.RadForm
    {
        private TProjectBasicInfoManager projectInfoManager;
        private TCableTestLibraryManager lineStructLibraryDetailManager;
        private CableJudgeThreshold judgeThreshold;
        private string testLineCable;
        public GroupTestStandardParams(string lineCable,CableJudgeThreshold cableJudgeThreshold)
        {
            InitializeComponent();
            this.testLineCable = lineCable;
            this.judgeThreshold = cableJudgeThreshold;
        }

        private void GroupTestStandardParams_Load(object sender, EventArgs e)
        {
            projectInfoManager = new TProjectBasicInfoManager();
            lineStructLibraryDetailManager = new TCableTestLibraryManager();
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,true,12);
            this.radGridView1.ReadOnly = true;
            QueryLineCableInfo();

            this.btn_apply.Click += Btn_apply_Click;
            this.btn_cancel.Click += Btn_cancel_Click;
            this.btn_batchModify.Click += Btn_batchModify_Click;
            this.btn_export.Click += Btn_export_Click;
        }

        private void ClearGridView()
        {
            if (this.radGridView1.RowCount < 1)
                return;
            for (int i = this.radGridView1.RowCount - 1; i >= 0; i--)
            {
                this.radGridView1.Rows[i].Delete();
            }
        }
        private void QueryLineCableInfo()
        {
            var dt = lineStructLibraryDetailManager.GetDataSetByWhere($"where CableName='{this.testLineCable}'").Tables[0];
            if (dt.Rows.Count < 1)
                return;
            ClearGridView();
            foreach (DataRow dr in dt.Rows)
            {
                var startInterface = dr["StartInterface"].ToString();
                var endInterface = dr["EndInterface"].ToString();
                var startContactPoint = dr["StartContactPoint"].ToString();
                var endContactPoint = dr["EndContactPoint"].ToString();

                if (IsExistCableInfo(startInterface, endInterface, startContactPoint, endContactPoint))
                    continue;
                this.radGridView1.Rows.AddNew();
                var rCount = this.radGridView1.RowCount;
                this.radGridView1.Rows[rCount - 1].Cells[0].Value = rCount;
                this.radGridView1.Rows[rCount - 1].Cells[1].Value = startInterface;
                this.radGridView1.Rows[rCount - 1].Cells[2].Value = startContactPoint;
                this.radGridView1.Rows[rCount - 1].Cells[3].Value = endInterface;
                this.radGridView1.Rows[rCount - 1].Cells[4].Value = endContactPoint;
                this.radGridView1.Rows[rCount - 1].Cells[5].Value = judgeThreshold.ConductionThreshold;
                this.radGridView1.Rows[rCount - 1].Cells[6].Value = judgeThreshold.InsulateThreshold;
                this.radGridView1.Rows[rCount - 1].Cells[7].Value = judgeThreshold.InsulateHoldTime;
                this.radGridView1.Rows[rCount - 1].Cells[8].Value = judgeThreshold.InsulateVoltage;
                this.radGridView1.Rows[rCount - 1].Cells[9].Value = judgeThreshold.PressureProofThreshold;
                this.radGridView1.Rows[rCount - 1].Cells[10].Value = judgeThreshold.PressureProofHoldTime;
                this.radGridView1.Rows[rCount - 1].Cells[11].Value = judgeThreshold.PressureProofVoltage;
            }
        }

        private bool IsExistCableInfo(string startInter,string endInter,string startPoint,string endPoint)
        {
            if (this.radGridView1.RowCount < 1)
                return false;
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                var startInterface = rowInfo.Cells[1].Value.ToString();
                var endInterface = rowInfo.Cells[2].Value.ToString();
                var startInterfacePoint = rowInfo.Cells[3].Value.ToString();
                var endInterfacePoint = rowInfo.Cells[4].Value.ToString();
                if (startInter == startInterface && endInter == endInterface && startPoint == startInterfacePoint && endPoint == endInterfacePoint)
                    return true;
            }
            return false;
        }

        private void Btn_export_Click(object sender, EventArgs e)
        {
            GridViewExport.ExportGridViewData(GridViewExport.ExportFormat.EXCEL,this.radGridView1);
        }

        private void Btn_batchModify_Click(object sender, EventArgs e)
        {
            
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_apply_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
