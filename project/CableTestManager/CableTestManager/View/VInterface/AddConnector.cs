using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using WindowsFormTelerik.ControlCommon;
using CableTestManager.View.VInterface;
using CableTestManager.Business;
using CableTestManager.Business.Implements;
using CableTestManager.Entity;

namespace CableTestManager.View.VInterface
{
    public partial class AddConnector : Telerik.WinControls.UI.RadForm
    {
        private TConnectorLibraryManager connectorLibraryManager;
        private TConnectorLibraryDetailManager connectorLibraryDetailManager;
        public AddConnector(string title,bool IsEdit,string connectorType,string switchType,string remark)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = title;

            connectorLibraryManager = new TConnectorLibraryManager();
            connectorLibraryDetailManager = new TConnectorLibraryDetailManager();
            if (IsEdit)
            {
                this.tb_connectorType.Text = connectorType;
                this.tb_switchType.Text = switchType;
                this.tb_remark.Text = remark;
                this.tb_connectorType.ReadOnly = true;
                RefreshPin(connectorType);
            }
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,true,2);
                
            this.btn_applay.Click += Btn_applay_Click;
            this.btn_cancel.Click += Btn_cancel_Click;
            this.btn_addPin.Click += Btn_addPin_Click;
            this.btn_batchAddpin.Click += Btn_batchAddpin_Click;
            this.btn_deletePin.Click += Btn_deletePin_Click;
            this.btn_deleteAllPin.Click += Btn_deleteAllPin_Click;
        }

        private void RefreshPin(string connectorType)
        {
            var dt = connectorLibraryDetailManager.GetDataSetByFieldsAndWhere("InterfacePointName", $"where ConnectorName='{connectorType}'").Tables[0];
            var rCount = this.radGridView1.RowCount;
            if (dt.Rows.Count < 1)
                return;
            //remove
            RemoveDataGrid();
            foreach (DataRow dr in dt.Rows)
            {
                var pin = dr["InterfacePointName"].ToString();
                if (IsExistPin(pin))
                    return;
                this.radGridView1.Rows.AddNew();
                var rowCount = this.radGridView1.RowCount;
                this.radGridView1.Rows[rowCount - 1].Cells[0].Value = rowCount;
                this.radGridView1.Rows[rowCount - 1].Cells[1].Value = pin;
            }
        }

        private void Btn_deleteAllPin_Click(object sender, EventArgs e)
        {
            RemoveDataGrid();
        }

        private void RemoveDataGrid()
        {
            for (int i = this.radGridView1.RowCount - 1; i >= 0; i--)
            {
                this.radGridView1.Rows[i].Delete();
            }
        }

        private void Btn_deletePin_Click(object sender, EventArgs e)
        {
            var index = this.radGridView1.CurrentRow.Index;
            if (index < 0)
                return;
            this.radGridView1.Rows[index].Delete();
        }

        private void Btn_batchAddpin_Click(object sender, EventArgs e)
        {
            BatchAddPinPoint batchAddPinPoint = new BatchAddPinPoint();
            if (batchAddPinPoint.ShowDialog() == DialogResult.OK)
            {
                var rule = batchAddPinPoint.nameRule;
                var startPin = batchAddPinPoint.startPin;
                var pinNum = batchAddPinPoint.totalNum;
                if (pinNum < 1)
                    return;
                var currentPin = 0;
                int.TryParse(startPin, out currentPin);
                for (int i = 0; i < pinNum; i++)
                {
                    if (rule == BatchAddPinPoint.NameRuleEnum.NumberRaise)
                    {
                        if (IsExistPin(currentPin.ToString()))
                            continue;
                        this.radGridView1.Rows.AddNew();
                        var rowCount = this.radGridView1.RowCount;
                        this.radGridView1.Rows[rowCount - 1].Cells[0].Value = rowCount;
                        this.radGridView1.Rows[rowCount - 1].Cells[1].Value = currentPin;
                        currentPin++;
                    }
                }
            }
        }

        private void Btn_addPin_Click(object sender, EventArgs e)
        {
            var addPinName = this.tb_pinName.Text.Trim();
            if (addPinName == "")
                return;
            if (!IsExistPin(addPinName))
            {
                this.radGridView1.Rows.AddNew();
                var rowCount = this.radGridView1.RowCount;
                this.radGridView1.Rows[rowCount - 1].Cells[0].Value = rowCount;
                this.radGridView1.Rows[rowCount - 1].Cells[1].Value = addPinName;
            }
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_applay_Click(object sender, EventArgs e)
        {
            var connectorType = this.tb_connectorType.Text;
            var switchType = this.tb_switchType.Text;
            if (connectorType == "")
            {
                MessageBox.Show("连接器型号不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (switchType == "")
            {
                MessageBox.Show("转接型号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //保存PIN数据
            if (this.radGridView1.RowCount < 1)
                return;
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                var pinPoint = rowInfo.Cells[1].Value.ToString();
                if (pinPoint == "")
                    continue;
                TConnectorLibraryDetail connectorLibraryDetail = new TConnectorLibraryDetail();
                connectorLibraryDetail.ConnectorName = connectorType;
                connectorLibraryDetail.InterfacePointName = pinPoint;
                connectorLibraryDetail.UpdateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                connectorLibraryDetailManager.Insert(connectorLibraryDetail);
            }
            //保存连接器
            TConnectorLibrary connectorLibrary = new TConnectorLibrary();
            connectorLibrary.ID = CableTestManager.Common.TablePrimaryKey.InsertConnectorLibPID();
            connectorLibrary.ConnectorName = connectorType;
            connectorLibrary.ConverterType = switchType;
            connectorLibrary.Remark = this.tb_remark.Text;
            connectorLibrary.UpdateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            connectorLibraryManager.Insert(connectorLibrary);

            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private bool IsExistPin(string pinName)
        {
            if (this.radGridView1.RowCount < 1)
                return false;
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                var pin = rowInfo.Cells[1].Value.ToString();
                if (pinName == pin)
                    return true;
            }
            return false;
        }
    }
}
