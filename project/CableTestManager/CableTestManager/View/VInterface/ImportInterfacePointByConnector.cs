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
using CableTestManager.Entity;

namespace CableTestManager.View.VInterface
{
    public partial class ImportInterfacePointByConnector : Telerik.WinControls.UI.RadForm
    {
        private TConnectorLibraryManager connectorLibraryManager;
        public string connectorType;
        public string testMethod;

        public ImportInterfacePointByConnector()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.ControlBox = false;
            this.MaximizeBox = false;
        }

        private void ImportInterfacePointByConnector_Load(object sender, EventArgs e)
        {
            Init();
            this.tb_connectorFilter.TextChanged += Tb_connectorFilter_TextChanged;
            this.btn_apply.Click += Btn_apply_Click;
            this.btn_cancel.Click += Btn_cancel_Click;
        }

        private void Tb_connectorFilter_TextChanged(object sender, EventArgs e)
        {
            RefreshConnectorInfo();
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_apply_Click(object sender, EventArgs e)
        {
            if (this.cb_connectorType.SelectedItem == null)
            {
                MessageBox.Show("未选择连接器型号！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            this.connectorType = this.cb_connectorType.Text;
            if (rbt_2lineMethod.IsChecked)
                this.testMethod = "二线法";
            else if (rbt_4lineMethod.IsChecked)
                this.testMethod = "四线法";
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void Init()
        {
            connectorLibraryManager = new TConnectorLibraryManager();
            this.cb_connectorType.MultiColumnComboBoxElement.Columns.Add("type");
            RefreshConnectorInfo();
            this.rbt_2lineMethod.CheckState = CheckState.Checked;
        }

        private void RefreshConnectorInfo()
        {
            var filter = this.tb_connectorFilter.Text.Trim();
            this.cb_connectorType.EditorControl.Rows.Clear();
            var selectSQL = "";
            if (filter != "")
                selectSQL = $"where ConnectorName like '%{filter}%'";
            var dt = connectorLibraryManager.GetDataSetByFieldsAndWhere("DISTINCT ConnectorName", selectSQL).Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    this.cb_connectorType.EditorControl.Rows.Add(dr["ConnectorName"].ToString());
                }
                this.cb_connectorType.EditorControl.ShowColumnHeaders = false;
                this.cb_connectorType.EditorControl.BestFitColumns();
            }
        }
    }
}
