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
using WindowsFormTelerik.ControlCommon;
using CableTestManager.Entity;

namespace CableTestManager.View.VInterface
{
    public partial class FrmCableTestInfo : Form
    {
        private TProjectBasicInfo proInfo;
        public FrmCableTestInfo(TProjectBasicInfo binfo)
        {
            InitializeComponent();
            this.proInfo = binfo;
        }

        private void FrmCableTestInfo_Load(object sender, EventArgs e)
        {
            if (this.proInfo.TestCableName == "")
            {
                TProjectBasicInfoManager infoManager = new TProjectBasicInfoManager();
                var data = infoManager.GetDataSetByWhere($"where ProjectName = '{this.proInfo.ProjectName}'").Tables[0];
                if (data.Rows.Count > 0)
                {
                    this.proInfo.TestCableName = data.Rows[0]["TestCableName"].ToString();
                }
            }
            if (this.proInfo.TestCableName != "")
            {
                this.Text = this.proInfo.TestCableName;
            }
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false, true, 5);
            GetLineStructDetailData(this.proInfo.TestCableName);
        }

        private void GetLineStructDetailData(string plugCableName)
        {
            if (plugCableName == "")
                return;
            TCableTestLibraryManager lineStructManager = new TCableTestLibraryManager();
            var data = lineStructManager.GetDataSetByWhere($"where CableName = '{plugCableName}'").Tables[0];
            if (data.Rows.Count < 1)
                return;
            this.Invoke(new Action(() =>
            {
                int iRow = 0;
                foreach (DataRow dr in data.Rows)
                {
                    this.radGridView1.Rows.AddNew();
                    this.radGridView1.Rows[iRow].Cells[0].Value = iRow + 1;
                    this.radGridView1.Rows[iRow].Cells[1].Value = dr["StartInterface"].ToString();
                    this.radGridView1.Rows[iRow].Cells[2].Value = dr["StartContactPoint"].ToString();
                    this.radGridView1.Rows[iRow].Cells[3].Value = dr["EndInterface"].ToString();
                    this.radGridView1.Rows[iRow].Cells[4].Value = dr["EndContactPoint"].ToString();
                    iRow++;
                }
            }));
        }
    }
}
