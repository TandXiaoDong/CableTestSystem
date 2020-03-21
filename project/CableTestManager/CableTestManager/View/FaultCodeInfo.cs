using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using WindowsFormTelerik.ControlCommon;
using CableTestManager.Business;
using CableTestManager.Business.Implements;

namespace CableTestManager.View
{
    public partial class FaultCodeInfo : Telerik.WinControls.UI.RadForm
    {
        public FaultCodeInfo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void Btn_apply_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QueryFaultInfo()
        {
            DeviceFaultRecordManager equipmentFaultRecordManager = new DeviceFaultRecordManager();
            var dt = equipmentFaultRecordManager.GetAllDataSet().Tables[0];
            if (dt.Rows.Count < 1)
                return;
            foreach (DataRow dr in dt.Rows)
            {
                var faultDate = dr["DeviceFaultDate"].ToString();
                var faultContent = dr["DeviceFaultContent"].ToString();
                if (IsExistFaultRecord(faultDate, faultContent))
                    continue;
                this.radGridView1.Rows.AddNew();
                var rCount = this.radGridView1.RowCount;
                this.radGridView1.Rows[rCount - 1].Cells[0].Value = rCount;
                this.radGridView1.Rows[rCount - 1].Cells[1].Value = faultDate;
                this.radGridView1.Rows[rCount - 1].Cells[2].Value = faultContent;
            }
        }

        private bool IsExistFaultRecord(string faultDate,string  faultContent)
        {
            if (this.radGridView1.RowCount < 1)
                return false;
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                var date = rowInfo.Cells[1].Value.ToString();
                var content = rowInfo.Cells[2].Value.ToString();

                if (faultDate == date && content == faultContent)
                    return true;
            }
            return false;
        }

        private void FaultCodeInfo_Load(object sender, EventArgs e)
        {
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1, false, true, 3);
            QueryFaultInfo();
            this.btn_apply.Click += Btn_apply_Click;
        }
    }
}
