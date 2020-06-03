using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using CableTestManager.Business.Implements;
using WindowsFormTelerik.ControlCommon;
using CableTestManager.Entity;
using CableTestManager.Common;

namespace CableTestManager.View.VInterface
{
    public partial class RadCableLibraryManager : RadForm
    {
        private string cableName;
        public static List<InterfaceInfoLibrary> interLibraryDetailList;

        public RadCableLibraryManager(string cableName)
        {
            InitializeComponent();
            this.cableName = cableName;
            Init();
            EventHandlers();
        }

        private void Init()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.lbx_cableName.Text = this.cableName;
            interLibraryDetailList = new List<InterfaceInfoLibrary>();
            RadGridViewProperties.SetRadGridViewProperty(this.radGridViewInter,false,true,3);
            RadGridViewProperties.SetRadGridViewProperty(this.radGridViewCable,false,true,3);
            LoadInterfaceList();
        }
        private void EventHandlers()
        {
            this.btnAddall.Click += BtnAddall_Click;
            this.btnAddSignal.Click += BtnAddSignal_Click;
            this.btnDeleteAll.Click += BtnDeleteAll_Click;
            this.btnDeleteSignal.Click += BtnDeleteSignal_Click;
            this.btnSubmit.Click += BtnSubmit_Click;
            this.btnClose.Click += BtnClose_Click;
            this.btnAddSignal.MouseMove += BtnAddSignal_MouseMove;
            this.btnAddSignal.MouseLeave += BtnAddSignal_MouseLeave;
            this.btnAddall.MouseMove += BtnAddall_MouseMove;
            this.btnAddall.MouseLeave += BtnAddall_MouseLeave;
            this.btnDeleteSignal.MouseMove += BtnDeleteSignal_MouseMove;
            this.btnDeleteSignal.MouseLeave += BtnDeleteSignal_MouseLeave;
            this.btnDeleteAll.MouseMove += BtnDeleteAll_MouseMove;
            this.btnDeleteAll.MouseLeave += BtnDeleteAll_MouseLeave;
        }

        private void BtnDeleteAll_MouseLeave(object sender, EventArgs e)
        {
            this.btnDeleteAll.BackColor = Color.Transparent;
        }

        private void BtnDeleteAll_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnDeleteAll.BackColor = Color.Gray;
        }

        private void BtnDeleteSignal_MouseLeave(object sender, EventArgs e)
        {
            this.btnDeleteSignal.BackColor = Color.Transparent;
        }

        private void BtnDeleteSignal_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnDeleteSignal.BackColor = Color.Gray;
        }

        private void BtnAddall_MouseLeave(object sender, EventArgs e)
        {
            this.btnAddall.BackColor = Color.Transparent;
        }

        private void BtnAddall_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnAddall.BackColor = Color.Gray;
        }

        private void BtnAddSignal_MouseLeave(object sender, EventArgs e)
        {
            this.btnAddSignal.BackColor = Color.Transparent;
        }

        private void BtnAddSignal_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnAddSignal.BackColor = Color.Gray;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            //提交到线束库时，不同接口之间不能有相同的针脚
            if (this.radGridViewCable.Rows.Count < 1)
                return;
            foreach (var rowInfo in this.radGridViewCable.Rows)
            {
                var interNo = rowInfo.Cells[1].Value.ToString();
                InterfaceInfoLibrary plugLibraryDetail = new InterfaceInfoLibrary();
                if (!interLibraryDetailList.Contains(plugLibraryDetail))
                {
                    plugLibraryDetail.InterfaceNo = interNo;
                    InterfaceInfoLibraryManager libraryManager = new InterfaceInfoLibraryManager();
                    var libraryData = libraryManager.GetDataSetByFieldsAndWhere("DISTINCT MeasureMethod", $"where InterfaceNo='{interNo}'").Tables[0];
                    if (libraryData.Rows.Count > 0)
                    {
                        plugLibraryDetail.MeasureMethod = libraryData.Rows[0][0].ToString();
                        interLibraryDetailList.Add(plugLibraryDetail);
                    }
                }
            }
            if (IsExistStitchRepeat())
                return;
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void BtnDeleteSignal_Click(object sender, EventArgs e)
        {
            var currentIndex = this.radGridViewCable.CurrentRow.Index;
            if (currentIndex < 0)
                return;
            this.radGridViewCable.Rows[currentIndex].Delete();
            //重新排序
            if (this.radGridViewCable.RowCount < 1)
                return;
            int iRow = 1;
            foreach (var rowInfo in this.radGridViewCable.Rows)
            {
                rowInfo.Cells[0].Value = iRow;
            }
        }

        private void BtnDeleteAll_Click(object sender, EventArgs e)
        {
            for (int i = this.radGridViewCable.RowCount - 1;i>=0; i--)
            {
                this.radGridViewCable.Rows[i].Delete();
            }
        }

        private void BtnAddSignal_Click(object sender, EventArgs e)
        {
            var plugno = this.radGridViewInter.CurrentRow.Cells[1].Value;
            var contactnum = this.radGridViewInter.CurrentRow.Cells[2].Value;
            if (plugno == null)
                return;
            //add left view
            if (this.radGridViewCable.RowCount > 0)
            {
                foreach (var rowInfo in this.radGridViewCable.Rows)
                {
                    if (plugno.ToString() == rowInfo.Cells[1].Value.ToString())
                        return;
                }
            }
            this.radGridViewCable.Rows.AddNew();
            int rowCount = this.radGridViewCable.RowCount;
            this.radGridViewCable.Rows[rowCount - 1].Cells[0].Value = rowCount;
            this.radGridViewCable.Rows[rowCount - 1].Cells[1].Value = plugno.ToString();
            this.radGridViewCable.Rows[rowCount - 1].Cells[2].Value = contactnum.ToString();
        }

        private void BtnAddall_Click(object sender, EventArgs e)
        {
            if (this.radGridViewInter.Rows.Count < 1)
                return;
            foreach (var rowInfo in this.radGridViewInter.Rows)
            {
                var plugno = rowInfo.Cells[1].Value;
                var contactnum = rowInfo.Cells[2].Value;
                if (plugno == null)
                    continue;
                if (IsExistCableInterface(plugno.ToString()))
                    continue;
                //add left view
                this.radGridViewCable.Rows.AddNew();
                int rowCount = this.radGridViewCable.RowCount;
                this.radGridViewCable.Rows[rowCount - 1].Cells[0].Value = rowCount;
                this.radGridViewCable.Rows[rowCount - 1].Cells[1].Value = plugno;
                this.radGridViewCable.Rows[rowCount - 1].Cells[2].Value = contactnum;
            }
        }

        private bool IsExistCableInterface(string plugno)
        {
            if (this.radGridViewCable.RowCount > 0)
            {
                foreach (var rowInfo in this.radGridViewCable.Rows)
                {
                    if (plugno.ToString() == rowInfo.Cells[1].Value.ToString())
                        return true;
                }
            }
            return false;
        }

        private void LoadInterfaceList()
        {
            InterfaceInfoLibraryManager plugLibraryDetailManager = new InterfaceInfoLibraryManager();
            var dt = plugLibraryDetailManager.GetAllDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                List<string> plugTemp = new List<string>();
                int iRow = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    var interNo = dr["InterfaceNo"].ToString();
                    var contactNum = plugLibraryDetailManager.GetRowCountByWhere($"where InterfaceNo='{interNo}'");
                    if (!plugTemp.Contains(interNo))
                        plugTemp.Add(interNo);
                    else
                        continue;
                    //add radgridview
                    this.radGridViewInter.Rows.AddNew();
                    this.radGridViewInter.Rows[iRow].Cells[0].Value = iRow + 1;
                    this.radGridViewInter.Rows[iRow].Cells[1].Value = interNo;
                    this.radGridViewInter.Rows[iRow].Cells[2].Value = contactNum;
                    iRow++;
                }
            }
        }

        private bool IsExistStitchRepeat()
        {
            if (interLibraryDetailList.Count < 1)
                return false;
            InterfaceInfoLibraryManager plugLibraryDetailManager = new InterfaceInfoLibraryManager();

            foreach (var plugLibrary in interLibraryDetailList) 
            {
                //查询针脚
                var plugLibraryList = plugLibraryDetailManager.GetListByWhere($"where InterfaceNo='{plugLibrary.InterfaceNo}'");
                foreach (var plugLibrary1 in plugLibraryList)
                {
                    var stitchValue = plugLibrary1.SwitchStandStitchNo;
                    foreach (var plugLibrary2 in interLibraryDetailList)
                    {
                        if (plugLibrary2.InterfaceNo == plugLibrary.InterfaceNo)
                            continue;
                        var resultList = plugLibraryDetailManager.GetListByWhere($"where InterfaceNo='{plugLibrary2.InterfaceNo}' and SwitchStandStitchNo='{stitchValue}'");
                        if (resultList.Count > 0)
                        {
                            MessageBox.Show($"接口{plugLibrary.InterfaceNo}与接口{plugLibrary2.InterfaceNo}存在相同的测试仪针脚{stitchValue}","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
