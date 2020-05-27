using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using CableTestManager.Business;
using CableTestManager.Business.Implements;
using CableTestManager.Entity;
using WindowsFormTelerik.ControlCommon;
using CableTestManager.View.VAdd;
using WindowsFormTelerik.GridViewExportData;
using CableTestManager.CUserManager;

namespace CableTestManager.View.VInterface
{
    public partial class RadInterfaceLibrary : RadForm
    {
        private InterfaceInfoLibraryManager plugLibraryDetailManager;
        public RadInterfaceLibrary()
        {
            InitializeComponent();
            Init();
            EventHandlers();
        }

        private void Init()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            plugLibraryDetailManager = new InterfaceInfoLibraryManager();
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,true,7);
            InitFuncState();
        }

        private void InitFuncState()
        {
            OperatLimitManager operatLimitManager = new OperatLimitManager();
            var data = operatLimitManager.GetDataSetByWhere($"where UserRole='{LocalLogin.currentUserType}'").Tables[0];
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    this.tool_query.Visible = ConvertDec2State(dr["InterfaceLib_query"].ToString());
                    this.tool_add.Visible = ConvertDec2State(dr["InterfaceLib_add"].ToString());
                    this.tool_delete.Visible = ConvertDec2State(dr["InterfaceLib_del"].ToString());
                    this.tool_edit.Visible = ConvertDec2State(dr["InterfaceLib_edit"].ToString());
                    this.tool_export.Visible = ConvertDec2State(dr["InterfaceLib_export"].ToString());
                }
            }
        }

        private bool ConvertDec2State(string val)
        {
            if (val == "1")
                return true;
            else
                return false;
        }

        private void EventHandlers()
        {
            this.tool_query.Click += Tool_query_Click;
            this.tool_add.Click += Tool_add_Click;
            this.tool_delete.Click += Tool_delete_Click;
            this.tool_edit.Click += Tool_edit_Click;
            this.tool_export.Click += Tool_export_Click;
            this.radGridView1.CellDoubleClick += RadGridView1_CellDoubleClick;
        }

        private void RadGridView1_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            EditInterfaceLibrary();
        }

        private void Tool_export_Click(object sender, EventArgs e)
        {
            GridViewExport.ExportGridViewData(GridViewExport.ExportFormat.EXCEL,this.radGridView1);
        }

        private void Tool_edit_Click(object sender, EventArgs e)
        {
            EditInterfaceLibrary();
        }

        private void Tool_delete_Click(object sender, EventArgs e)
        {
            var plugNoIndex = this.radGridView1.CurrentRow.Index;
            if (plugNoIndex < 0)
                return;
            var plugNo = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            if (MessageBox.Show($"确认要删除接口{plugNo}？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                plugLibraryDetailManager.DeleteByWhere($"where InterfaceNo='{plugNo}'");
                QueryDB();
            }
        }

        private void Tool_add_Click(object sender, EventArgs e)
        {
            RadUpdateInterface radUpdateInterface = new RadUpdateInterface("添加接口库","",false);
            if (radUpdateInterface.ShowDialog() == DialogResult.OK)
            {
                QueryDB();
            }
        }

        private void Tool_query_Click(object sender, EventArgs e)
        {
            QueryDB();
        }

        private void QueryDB()
        {
            int i = 0;
            ClearGridView();
            var queryFilter = this.tb_queryFilter.Text.Trim();
            var selectSQL = "";
            if (queryFilter != "")
                selectSQL = $"where InterfaceNo like '%{queryFilter}%' OR ConnectorName like '%{queryFilter}%' ";
            var dbSource = plugLibraryDetailManager.GetDataSetByWhere(selectSQL).Tables[0];
            if (dbSource.Rows.Count < 1)
                return;
            foreach (DataRow dr in dbSource.Rows)
            {
                var plugNo = dr["InterfaceNo"].ToString();
                if (IsExistPlugNo(plugNo))
                    continue;
                this.radGridView1.Rows.AddNew();
                var detailDB = plugLibraryDetailManager.GetDataSetByWhere($"where InterfaceNo='{plugNo}'").Tables[0];

                this.radGridView1.Rows[i].Cells[0].Value = i + 1;//序号
                this.radGridView1.Rows[i].Cells[1].Value = plugNo;//接口代号
                this.radGridView1.Rows[i].Cells[2].Value = detailDB.Rows.Count;//接点个数
                this.radGridView1.Rows[i].Cells[3].Value = GetStitchRange(detailDB);//针脚范围
                if (dr["ConnectorName"].ToString() == "")
                    this.radGridView1.Rows[i].Cells[4].Value = "--";//连接器型号
                else
                    this.radGridView1.Rows[i].Cells[4].Value = dr["ConnectorName"].ToString();
                this.radGridView1.Rows[i].Cells[5].Value = dr["Remark"].ToString();//备注
                this.radGridView1.Rows[i].Cells[6].Value = dr["Operator"].ToString();
                i++;
            }
        }

        private void ClearGridView()
        {
            for (int i = this.radGridView1.RowCount - 1; i >= 0; i--)
            {
                this.radGridView1.Rows[i].Delete();
            }
            this.radGridView1.Refresh();
        }

        private void EditInterfaceLibrary()
        {
            var plugNo = this.radGridView1.CurrentRow.Cells[1].Value;
            if (plugNo != null)
                plugNo = plugNo.ToString();
            else
            {
                MessageBox.Show("请选择要编辑的行！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            RadUpdateInterface radUpdateInterface = new RadUpdateInterface("编辑接口库",plugNo.ToString(),true);
            radUpdateInterface.ShowDialog();
        }

        private bool IsExistPlugNo(string plugNo)
        {
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                if (rowInfo.Cells[1].Value != null)
                {
                    if (rowInfo.Cells[1].Value.ToString() == plugNo)
                        return true;
                }
            }
            return false;
        }

        private string GetStitchRange(DataTable dt)
        {
            List<int> list = new List<int>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow rowInfo in dt.Rows)
                {
                    var stitchString = rowInfo[3].ToString();
                    var stitchValue = 0;
                    if (!stitchString.Contains(","))
                    {
                        int.TryParse(stitchString, out stitchValue);
                        list.Add(stitchValue);
                    }
                    else
                    {
                        string[] stitchArray = stitchString.Split(',');
                        int.TryParse(stitchArray[0], out stitchValue);
                        list.Add(stitchValue);
                        int.TryParse(stitchArray[1], out stitchValue);
                        list.Add(stitchValue);
                    }
                }
            }
            if (list.Count < 1)
                return "--";
            list.Sort();
            return list[0] + "~" + list[list.Count - 1];
        }
    }
}
