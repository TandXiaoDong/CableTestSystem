using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using WindowsFormTelerik.ControlCommon;
using CableTestManager.Business.Implements;
using CableTestManager.Business;
using CableTestManager.Entity;
using CableTestManager.CUserManager;
using CableTestManager.View.VInterface;
using CommonUtils.FileHelper;
using CableTestManager.Model;
using CableTestManager.Common;

namespace CableTestManager.View.VAdd
{
    public partial class RadUpdateInterface : RadForm
    {
        private const string TWO_WIRE_METHOD = "二线法";
        private const string FOUR_WIRE_METHOD = "四线法";
        private string plugno;
        private InterfaceInfoLibraryManager plugLibraryDetailManager;
        private bool IsEditView;
        List<InterfaceInfoLibrary> interfaceLibaryInfos;
        private InterfaceInfoLibrary infoLibrary;
        List<InterfaceInfoLibrary> addNewRowList = new List<InterfaceInfoLibrary>();
        private DataTable dataSource;//cache edit mode to add new row

        public RadUpdateInterface(string title, string plugNo,bool IsEdit)
        {
            InitializeComponent();

            this.Text = title;
            this.plugno = plugNo;
            this.IsEditView = IsEdit;

            Init(IsEdit);
            InitDataTable();
            RefreshDataGrid();
            EventHandlers();
        }

        private enum InterfaceExTipEnum
        { 
            NONE,
            InterfacePoint_ExistAndStitchNo_NotExist,
            InterfacePoint_ExistAndStitchNo_Exist,
            InterfacePoint_NotExistAndStitch_NoExist,
            InterfacePoint_NotExistANdStitch_Exist,
            InterPointNameExist,
            DevSwitchPointExist
        }

        private const string COLUMN_ORDER = "序号";
        private const string COLUMN_INTER_NAME = "接口代号";
        private const string COLUMN_METHOD_NAME = "测量方法";
        private const string COLUMN_INTER_POINT = "接点名称";
        private const string COLUMN_DEV_POINT = "设备针脚号";
        private const string COLUMN_CONNECTOR = "连接器";
        private const string COLUMN_REMARK = "备注";
        private const string COLUMN_ADD_NEWROW = "新行";
        private const string COLUMN_KEY_ID = "ID";

        private void Init(bool IsEdit)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            plugLibraryDetailManager = new InterfaceInfoLibraryManager();
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,false,8);
            GridViewComboBoxColumn methodName = this.radGridView1.Columns["columnMethod"] as GridViewComboBoxColumn;
            methodName.DataSource = new string[] { TWO_WIRE_METHOD,FOUR_WIRE_METHOD};
            interfaceLibaryInfos = new List<InterfaceInfoLibrary>();
            this.radGridView1.Columns[5].IsVisible = false;
            this.radGridView1.Columns[7].IsVisible = false;
            if (IsEdit)
            {
                this.radGridView1.Columns[0].ReadOnly = true;
                this.radGridView1.Columns[1].ReadOnly = true;
                this.tb_interfacelNo.Text = this.plugno;
            }
            else
            {
                this.radGridView1.ReadOnly = true;
            }
        }

        private void InitDataTable()
        {
            this.dataSource = new DataTable();
            this.dataSource.Columns.Add(COLUMN_ORDER);
            this.dataSource.Columns.Add(COLUMN_INTER_NAME);
            this.dataSource.Columns.Add(COLUMN_INTER_POINT);
            this.dataSource.Columns.Add(COLUMN_METHOD_NAME);
            this.dataSource.Columns.Add(COLUMN_DEV_POINT);
            this.dataSource.Columns.Add(COLUMN_CONNECTOR);
            this.dataSource.Columns.Add(COLUMN_REMARK);
            this.dataSource.Columns.Add(COLUMN_ADD_NEWROW);
            this.dataSource.Columns.Add(COLUMN_KEY_ID);
        }

        private void EventHandlers()
        {
            this.menu_signalAddInterfacePoint.Click += Menu_signalAddInterfacePoint_Click;
            this.menu_batchAddInterfacePoint.Click += Menu_batchAddInterfacePoint_Click;
            this.menu_deleteAll.Click += Menu_deleteAll_Click;
            this.menu_deleteSelect.Click += Menu_deleteSelect_Click;
            this.btn_close.Click += Btn_close_Click;

            this.btnSubmit.Click += BtnSubmit_Click;
            this.btnClose.Click += BtnClose_Click;
            this.radGridView1.CellValueChanged += RadGridView1_CellValueChanged;
            this.radGridView1.CellBeginEdit += RadGridView1_CellBeginEdit;
            this.radGridView1.CellEndEdit += RadGridView1_CellEndEdit;
            this.FormClosed += RadUpdateInterface_FormClosed;
        }

        private void RadUpdateInterface_FormClosed(object sender, FormClosedEventArgs e)
        {
            InterfaceLibCom.data = null;
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RadGridView1_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            var cIndex = this.radGridView1.CurrentRow.Index;
            if (cIndex < 0)
                return;
            var interNo = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            var pointn = this.radGridView1.CurrentRow.Cells[2].Value.ToString();
            var method = this.radGridView1.CurrentRow.Cells[3].Value.ToString();
            var stitch = this.radGridView1.CurrentRow.Cells[4].Value.ToString();
            var rmark = this.radGridView1.CurrentRow.Cells[6].Value.ToString();
            var id = this.radGridView1.CurrentRow.Cells[8].Value.ToString();
            var obj1 = interfaceLibaryInfos.Find(obj => obj.ID == int.Parse(id));
            if (method == "二线法")
            {
                obj1.MeasureMethod = "2";
            }
            else
            {
                obj1.MeasureMethod = "4";
            }
            bool IsModify = false;
            if (pointn != obj1.ContactPointName)
            {
                obj1.ContactPointName = pointn;
                IsModify = true;
            }
            if (stitch != obj1.SwitchStandStitchNo)
            {
                obj1.SwitchStandStitchNo = stitch;
                IsModify = true;
            }
            if (obj1.Remark != rmark)
            {
                obj1.Remark = rmark;
                IsModify = true;
            }

            if(!IsModify)
            {
                interfaceLibaryInfos.Remove(obj1);
            }
        }

        private void RadGridView1_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            var cIndex = this.radGridView1.CurrentRow.Index;
            if (cIndex < 0)
                return;
            var interPointName = this.radGridView1.CurrentRow.Cells[2].Value.ToString();
            var switchStandStitch = this.radGridView1.CurrentRow.Cells[4].Value.ToString();
            var interName = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            var rmark = this.radGridView1.CurrentRow.Cells[6].Value.ToString();
            var id = this.radGridView1.CurrentRow.Cells[8].Value.ToString();
            var curObj = InterfaceBasicInfo.QueryInterfaceLibInfo(id);
            var obj1 = interfaceLibaryInfos.Find(obj => obj.ID == curObj.ID);
            if (obj1 == null)
            {
                this.infoLibrary = curObj;
                interfaceLibaryInfos.Add(this.infoLibrary);
            }
        }

        private void Menu_deleteAll_Click(object sender, EventArgs e)
        {
            if (this.radGridView1.RowCount <= 0)
                return;
            var interName = this.radGridView1.Rows[0].Cells[1].Value.ToString();
            if (IsInterUsed(interName))
            {
                MessageBox.Show($"接口{interName}已被线束库使用,删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"确认要删除设备所有接点?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.OK)
            {
                return;
            }
            int del = 0;
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                var curInterName = rowInfo.Cells[1].Value.ToString();
                var curDevPoint = rowInfo.Cells[4].Value.ToString();
                del += plugLibraryDetailManager.DeleteByWhere($"where InterfaceNo='{curInterName}'");
            }
            
            if (del > 0)
            {
                RefreshDataGrid();
                MessageBox.Show($"已删除接口{interName}的接点数{del}!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Menu_deleteSelect_Click(object sender, EventArgs e)
        {
            if (this.radGridView1.RowCount < 1)
                return;
            var currentRow = this.radGridView1.CurrentRow;
            if (currentRow == null)
                return;
            var curInterName = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            var curDevPoint = this.radGridView1.CurrentRow.Cells[4].Value.ToString();
            if (IsInterUsed(curInterName))
            {
                MessageBox.Show($"接口{curInterName}已被线束库使用,删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"确认要删除设备接点{curDevPoint}?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                var del = plugLibraryDetailManager.DeleteByWhere($"where InterfaceNo='{curInterName}' and SwitchStandStitchNo='{curDevPoint}'");
                if (del > 0)
                {
                    MessageBox.Show($"已删除设备接点{curDevPoint}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGrid();
                    UpdateCurInterPointOrder(curInterName);
                }
            }
        }

        private bool IsInterUsed(string interName)
        {
            TCableTestLibraryManager libraryManager = new TCableTestLibraryManager();
            var data = libraryManager.GetDataSetByFieldsAndWhere("DISTINCT CableName", $"where StartInterface = '{interName}' OR EndInterface = '{interName}'").Tables[0];
            if (data.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        private void Menu_importFromFile_Click(object sender, EventArgs e)
        {
            var fileObject = FileSelect.GetSelectFileContent("(*.*)|*.*","导入文件");
        }

        private void Menu_importFromConnectorType_Click(object sender, EventArgs e)
        {
            if (!IsValidInterfaceNO())
                return;
            ImportInterfacePointByConnector importConnector = new ImportInterfacePointByConnector();
            if (importConnector.ShowDialog() == DialogResult.OK)
            {
                var testMethod = importConnector.testMethod;
                var connectorType = importConnector.connectorType;
                TConnectorLibraryDetailManager connectorLibraryManager = new TConnectorLibraryDetailManager();
                var dt = connectorLibraryManager.GetDataSetByFieldsAndWhere("InterfacePointName", $"where ConnectorName='{connectorType}'").Tables[0];
                if (dt.Rows.Count < 1)
                    return;
                int iRow = 1;
                if (testMethod == "二线法")
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var interfacePointValue = dr["InterfacePointName"].ToString();
                        var switchPointNo = iRow;
                        if (IsExistSwitchPointNo(interfacePointValue, switchPointNo.ToString(),testMethod))
                        {
                            return;
                        }
                        AddGridViewRow(interfacePointValue,testMethod,switchPointNo.ToString(),connectorType);
                        iRow++;
                    }
                }
                else if (testMethod == "四线法")
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var interfacePointValue = dr["InterfacePointName"].ToString();
                        var switchPointNo = iRow + "," + (iRow + 1);
                        if (IsExistSwitchPointNo(interfacePointValue, switchPointNo.ToString(),testMethod))
                        {
                            return;
                        }
                        AddGridViewRow(interfacePointValue, testMethod, switchPointNo.ToString(), connectorType);
                        iRow += 2;
                    }
                }
            }
        }

        private void Menu_batchAddInterfacePoint_Click(object sender, EventArgs e)
        {
            if (!IsEditView)
            {
                if (!IsValidInterfaceNO())
                    return;
            }
            BatchAddInterfaceDefine batchAddInterfaceDefine = new BatchAddInterfaceDefine();
            if (batchAddInterfaceDefine.ShowDialog() == DialogResult.OK)
            {
                var nameRule = batchAddInterfaceDefine.nameRule;
                var testMethod = batchAddInterfaceDefine.testMethod;
                var startInterfacePoint = batchAddInterfaceDefine.startInterfacePoint;
                var startPin = batchAddInterfaceDefine.startPin;
                var curTotalNum = batchAddInterfaceDefine.totalNum;
                int startInterfacePointIndex,startPinIndex;
                int.TryParse(startPin,out startPinIndex);
                int.TryParse(startInterfacePoint,out startInterfacePointIndex);
                int startIndex = batchAddInterfaceDefine.startIndex;
                if (curTotalNum < 1)
                    return;
                int stitchNo = 1;
                for (int i = startIndex; i < curTotalNum + startIndex; i++)
                {
                    var interfacePointName = "";
                    var switchStandPointNo = "";
                    if (nameRule == BatchAddInterfaceDefine.NameRuleEnum.NumberRaise)
                    {
                        if (testMethod == "二线法")
                        {
                            interfacePointName = startInterfacePointIndex.ToString();
                            switchStandPointNo = batchAddInterfaceDefine._2devPointList[i].ToString();//startPinIndex.ToString();
                        }
                        else if (testMethod == "四线法")
                        {
                            interfacePointName = i.ToString();
                            switchStandPointNo = batchAddInterfaceDefine._4devPointList[i].ToString();//stitchNo + "," + (stitchNo + 1).ToString();
                            stitchNo += 2;
                        }
                    }
                    if (IsExistSwitchPointNo(interfacePointName, switchStandPointNo,testMethod))
                    {
                        return;
                    }
                    //InterfaceInfoLibrary interLib = new InterfaceInfoLibrary();
                    //interLib.InterfaceNo = this.plugno;
                    //interLib.ContactPointName = interfacePointName;
                    //interLib.SwitchStandStitchNo = switchStandPointNo;
                    
                    AddGridViewRow(interfacePointName, testMethod, switchStandPointNo, "");
                    startPinIndex++;
                    startInterfacePointIndex++;
                }
                this.radGridView1.CurrentRow = this.radGridView1.Rows[this.radGridView1.RowCount - 1];
            }
        }

        private void Menu_signalAddInterfacePoint_Click(object sender, EventArgs e)
        {
            if (!this.IsEditView)
            {
                if (!IsValidInterfaceNO())
                    return;
            }
            AddSignalInterfaceDefine addSignalInterfaceDefine = new AddSignalInterfaceDefine();
            if (addSignalInterfaceDefine.ShowDialog() == DialogResult.OK)
            {
                var interfacePointName = addSignalInterfaceDefine.interfacePointName;
                var switchStandPointNo = addSignalInterfaceDefine.switchStandPointNo;
                var testMethod = addSignalInterfaceDefine.testMethod;
                if (IsExistSwitchPointNo(interfacePointName, switchStandPointNo,testMethod))
                {
                    return;
                }
                AddGridViewRow(interfacePointName, testMethod, switchStandPointNo,"");
                this.radGridView1.CurrentRow = this.radGridView1.Rows[this.radGridView1.RowCount - 1];
            }
        }

        private void AddGridViewRow(string interfacePointName,string testMethod,string switchStandPointNo,string connectorType)
        {
            this.radGridView1.Rows.AddNew();
            var rCount = this.radGridView1.RowCount;
            this.radGridView1.Rows[rCount - 1].Cells[0].Value = rCount;
            this.radGridView1.Rows[rCount - 1].Cells[1].Value = this.tb_interfacelNo.Text.Trim();
            this.radGridView1.Rows[rCount - 1].Cells[2].Value = interfacePointName;
            this.radGridView1.Rows[rCount - 1].Cells[3].Value = testMethod;
            this.radGridView1.Rows[rCount - 1].Cells[4].Value = switchStandPointNo;
            this.radGridView1.Rows[rCount - 1].Cells[5].Value = connectorType;
            this.radGridView1.Rows[rCount - 1].Cells[6].Value = this.tb_remark.Text.Trim();
            this.radGridView1.Rows[rCount - 1].Cells[7].Value = 1;

            if (this.IsEditView)//this is edit mode to add new row
            {
                DataRow dataRow = this.dataSource.NewRow();
                dataRow[COLUMN_INTER_NAME] = this.tb_interfacelNo.Text.Trim();
                dataRow[COLUMN_INTER_POINT] = interfacePointName;
                dataRow[COLUMN_METHOD_NAME] = testMethod;
                dataRow[COLUMN_DEV_POINT] = switchStandPointNo;
                dataRow[COLUMN_CONNECTOR] = connectorType;
                dataRow[COLUMN_REMARK] = this.tb_remark.Text.Trim();
                dataRow[COLUMN_ADD_NEWROW] = 1;
                this.dataSource.Rows.Add(dataRow);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            SubmitData();
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void RadGridView1_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            //var currentMethod = this.radGridView1.CurrentRow.Cells[3].Value;
            //if (currentMethod == null)
            //    return;
            //UpdateSwitchPointValue(currentMethod.ToString());
        }

        private void UpdateSwitchPointValue(string methodName)
        {
            GridViewComboBoxColumn stitchColumn = this.radGridView1.Columns["columnStitch"] as GridViewComboBoxColumn;
            if (methodName == TWO_WIRE_METHOD)
            {
                stitchColumn.DataSource = DevPoint2Line();//TwoWireMethodStitchList();
            }
            else if (methodName == FOUR_WIRE_METHOD)
            {
                stitchColumn.DataSource = DevPoint4Line();//FourWireMethodStitchList();
            }
            else
            {
                stitchColumn.DataSource = null;
            }
        }

        private List<int> TwoWireMethodStitchList()
        {
            List<int> list = new List<int>();
            for (int i = 1; i < 385; i++)
            {
                list.Add(i);
            }
            return list;
        }

        private List<string> FourWireMethodStitchList()
        {
            List<string> list = new List<string>();
            for (int i = 1; i < 385; i += 2)
            {
                list.Add(i + "," + (i + 1));
            }
            return list;
        }

        private List<int> DevPoint2Line()
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= 384; i++)
            {
                if (!InterfaceLibCom.IsExistDevicePoint(i.ToString()))
                {
                    list.Add(i);
                }
            }
            return list;
        }

        private List<string> DevPoint4Line()
        {
            List<string> list = new List<string>();
            for (int i = 1; i <= 384; i += 2)
            {
                var curPoint = i + "," + (i + 1);
                if (!InterfaceLibCom.IsExistDevicePoint(curPoint))
                {
                    list.Add(curPoint);
                }
            }
            return list;
        }

        private void RefreshDataGrid()
        {
            RadGridViewProperties.ClearGridView(this.radGridView1, null);
            InterfaceInfoLibraryManager plugLibraryDetailManager = new InterfaceInfoLibraryManager();
            var dt = plugLibraryDetailManager.GetDataSetByWhere($"where InterfaceNo='{this.plugno}'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                int iRow = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    var interName = dr["InterfaceNo"].ToString();
                    var pointName = dr["ContactPointName"].ToString();
                    var method = dr["MeasureMethod"].ToString();
                    var devPoint = dr["SwitchStandStitchNo"].ToString();
                    var connector = dr["ConnectorName"].ToString();
                    var remark = dr["remark"].ToString();
                    var keyID = dr["ID"].ToString();

                    this.radGridView1.Rows.AddNew();
                    this.radGridView1.Rows[iRow].Cells[0].Value = iRow + 1;
                    this.radGridView1.Rows[iRow].Cells[1].Value = interName;
                    this.radGridView1.Rows[iRow].Cells[2].Value = pointName;
                    if (method == "2")
                    {
                        this.radGridView1.Rows[iRow].Cells[3].Value = TWO_WIRE_METHOD;
                        UpdateSwitchPointValue(TWO_WIRE_METHOD);
                    }
                    else if (method == "4")
                    {
                        this.radGridView1.Rows[iRow].Cells[3].Value = FOUR_WIRE_METHOD;
                        UpdateSwitchPointValue(FOUR_WIRE_METHOD);
                    }
                    this.radGridView1.Rows[iRow].Cells[4].Value = devPoint;
                    this.radGridView1.Rows[iRow].Cells[5].Value = connector;
                    this.radGridView1.Rows[iRow].Cells[6].Value = remark;
                    this.radGridView1.Rows[iRow].Cells[8].Value = keyID;
                    
                    iRow++;
                }
            }
        }

        private void UpdateCurInterPointOrder(string interName)
        {
            var data = this.plugLibraryDetailManager.GetDataSetByWhere($"where InterfaceNo='{interName}'").Tables[0];
            if (data.Rows.Count > 0)
            {
                int i = 1;
                foreach (DataRow dr in data.Rows)
                {
                    var id = int.Parse(dr["ID"].ToString());
                    this.plugLibraryDetailManager.UpdateFields($"ContactPoint = '{i}'",$"where ID='{id}'");
                    i++;
                }
            }
        }

        private void SubmitData()
        {
            lock (this)
            {
                if (this.IsEditView)
                {
                    if (UpdateInterfaceInfo() + EditAddNewInterInfo() + UpdateInterfaceName() > 0)
                    {
                        MessageBox.Show($"更新成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (AddNewInterInfo() > 0)
                    {
                        MessageBox.Show($"更新成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
        }

        private int AddNewInterInfo()
        {
            int resCount = 0;
            if (this.radGridView1.RowCount < 1)
            {
                MessageBox.Show("没有可以提交的数据!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
            if (!CheckValid())
                return 0;
            int beforeInsertCount = plugLibraryDetailManager.GetRowCount();
            int excuteCount = 0;
            //submit data
            int iRow = 1;
            int id = 0;
            List<InterfaceInfoLibrary> libList = new List<InterfaceInfoLibrary>();
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                var plugNo = rowInfo.Cells[1].Value.ToString();
                var pinName = rowInfo.Cells[2].Value.ToString();
                var testMethod = rowInfo.Cells[3].Value.ToString();
                var stitchNo = rowInfo.Cells[4].Value.ToString();
                var IsAddNewRow = rowInfo.Cells[7].Value;
                var remark = "";
                var connectorName = "";
                if (rowInfo.Cells[6].Value != null)
                    remark = rowInfo.Cells[6].Value.ToString();
                if (rowInfo.Cells[5].Value != null)
                    connectorName = rowInfo.Cells[5].Value.ToString();

                #region TPlugLibraryDetail
                InterfaceInfoLibrary plugLibraryDetail = new InterfaceInfoLibrary();
                plugLibraryDetail.ID = CableTestManager.Common.TablePrimaryKey.InsertInterfaceLibPID() + id;
                plugLibraryDetail.InterfaceNo = plugNo;
                plugLibraryDetail.ContactPointName = pinName;
                if (testMethod == TWO_WIRE_METHOD)
                    plugLibraryDetail.MeasureMethod = "2";
                else if (testMethod == FOUR_WIRE_METHOD)
                    plugLibraryDetail.MeasureMethod = "4";
                plugLibraryDetail.SwitchStandStitchNo = stitchNo;
                plugLibraryDetail.Remark = remark;
                plugLibraryDetail.Operator = LocalLogin.currentUserName;
                plugLibraryDetail.ConnectorName = connectorName;
                plugLibraryDetail.ContactPoint = iRow.ToString();
                #endregion

                //新增数据
                if (IsAddNewRow != null)
                {
                    //if (IsCanInsertOrUpdate(false, -1, plugNo, pinName, stitchNo) == InterfaceExTipEnum.InterfacePoint_NotExistAndStitch_NoExist)
                    //{
                    //plugLibraryDetailManager.Insert(plugLibraryDetail);
                    libList.Add(plugLibraryDetail);
                    iRow++;
                    id++;
                    //}
                }
            }

            resCount = plugLibraryDetailManager.Insert(libList);
            return resCount;
        }

        private int EditAddNewInterInfo()
        {
            if (this.dataSource.Rows.Count < 1)
            {
                return 0;
            }
            if (!CheckValid())
                return 0;
            //int beforeInsertCount = plugLibraryDetailManager.GetRowCount();
            //submit data
            int iRow = 1;
            int id = 0;
            List<InterfaceInfoLibrary> libList = new List<InterfaceInfoLibrary>();
            foreach (DataRow rowInfo in this.dataSource.Rows)
            {
                var plugNo = rowInfo[1].ToString();
                var pinName = rowInfo[2].ToString();
                var testMethod = rowInfo[3].ToString();
                var stitchNo = rowInfo[4].ToString();
                var IsAddNewRow = rowInfo[7].ToString();
                var remark = "";
                var connectorName = "";
                remark = rowInfo[6].ToString();
                connectorName = rowInfo[5].ToString();

                #region TPlugLibraryDetail
                InterfaceInfoLibrary plugLibraryDetail = new InterfaceInfoLibrary();
                plugLibraryDetail.ID = CableTestManager.Common.TablePrimaryKey.InsertInterfaceLibPID() + id;
                plugLibraryDetail.InterfaceNo = plugNo;
                plugLibraryDetail.ContactPointName = pinName;
                if (testMethod == TWO_WIRE_METHOD)
                    plugLibraryDetail.MeasureMethod = "2";
                else if (testMethod == FOUR_WIRE_METHOD)
                    plugLibraryDetail.MeasureMethod = "4";
                plugLibraryDetail.SwitchStandStitchNo = stitchNo;
                plugLibraryDetail.Remark = remark;
                plugLibraryDetail.Operator = LocalLogin.currentUserName;
                plugLibraryDetail.ConnectorName = connectorName;
                plugLibraryDetail.ContactPoint = iRow.ToString();
                #endregion

                //新增数据
                if (IsAddNewRow != null)
                {
                    //if (IsCanInsertOrUpdate(false, -1, plugNo, pinName, stitchNo) == InterfaceExTipEnum.InterfacePoint_NotExistAndStitch_NoExist)
                    //{
                    //plugLibraryDetailManager.Insert(plugLibraryDetail);
                    libList.Add(plugLibraryDetail);
                    iRow++;
                    id++;
                    //}
                }
            }

            var resCount = plugLibraryDetailManager.Insert(libList);
            this.dataSource.Clear();
            //int afterInsertCount = plugLibraryDetailManager.GetRowCount();
            return resCount;
        }

        private int UpdateInterfaceName()
        {
            if (this.IsEditView)
            {
                if (this.plugno.Trim() != this.tb_interfacelNo.Text.Trim())//名称已修改
                {
                    var row = this.plugLibraryDetailManager.UpdateFields($"InterfaceNo = '{this.tb_interfacelNo.Text.Trim()}'", $"where InterfaceNo = '{this.plugno}'");
                    return row;
                }
            }
            return 0;
        }

        private List<InterfaceLibCom> GetDevPointOrderID(string devPoint)//排序
        {
            int dPoint;
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                int.TryParse(rowInfo.Cells[3].Value.ToString(), out dPoint);
            }
            return new List<InterfaceLibCom>();
        }

        private bool CheckValid()
        {
            //check valid
            int i = 0;
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                var plugNo = rowInfo.Cells[1].Value;
                var contactName = rowInfo.Cells[2].Value;
                var testMethod = rowInfo.Cells[3].Value;
                var stitch = rowInfo.Cells[4].Value;

                #region 接口代号
                if (plugNo == null)
                {
                    MessageBox.Show($"第{i + 1}行接口代号不能为空!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    if (plugNo.ToString() == "")
                    {
                        MessageBox.Show($"第{i + 1}行接口代号不能为空!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                #endregion

                #region 接点名称
                if (contactName == null)
                {
                    MessageBox.Show($"第{i + 1}行接点名称不能为空!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    if (contactName.ToString() == "")
                    {
                        MessageBox.Show($"第{i + 1}行接点名称不能为空!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                #endregion

                #region 测量方法
                if (testMethod == null)
                {
                    MessageBox.Show($"第{i + 1}行测量方法不能为空!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    if (testMethod.ToString() == "")
                    {
                        MessageBox.Show($"第{i + 1}行测量方法不能为空!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false ;
                    }
                }
                #endregion

                #region 转接台针脚号
                if (stitch == null)
                {
                    MessageBox.Show($"第{i + 1}行转接台针脚号不能为空!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false ;
                }
                else
                {
                    if (stitch.ToString() == "")
                    {
                        MessageBox.Show($"第{i + 1}行转接台针脚号不能为空!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false ;
                    }
                }
                #endregion

                i++;
            }
            return true;
        }

        private bool IsExistPointPin(string pin)
        {
            return true;
        }

        private InterfaceExTipEnum IsCanInsertOrUpdate(bool IsUpdate,long ID, string interfaceNo,string interfacePName,string switchStandStitch, string remark)
        {
            //查询本地库是否已存在要更新的值，不存在时可以更新
            var where = $"where ID == '{ID}' and InterfaceNo='{interfaceNo}'";

            var interNameCount = plugLibraryDetailManager.GetRowCountByWhere(where);

            if (interNameCount > 0)
            {
                where = $"where InterfaceNo='{interfaceNo}' and ContactPointName='{interfacePName}' and SwitchStandStitchNo='{switchStandStitch}' and Remark='{remark}'";
                interNameCount = plugLibraryDetailManager.GetRowCountByWhere(where);
                if (interNameCount > 0)
                {
                    where = $"where InterfaceNo='{interfaceNo}' and ContactPointName='{interfacePName}'";
                    var whereDev = $"where InterfaceNo='{interfaceNo}' and SwitchStandStitchNo='{switchStandStitch}'";
                    interNameCount = plugLibraryDetailManager.GetRowCountByWhere(where);
                    var devCount = plugLibraryDetailManager.GetRowCountByWhere(where);
                    if (interNameCount > 0)
                    {
                        if (devCount > 0)
                        {
                            MessageBox.Show($"接点{interfacePName}已存在,针脚{switchStandStitch}已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return InterfaceExTipEnum.InterfacePoint_ExistAndStitchNo_Exist;
                        }
                        else
                        {
                            MessageBox.Show($"接点{interfacePName}已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return InterfaceExTipEnum.InterfacePoint_ExistAndStitchNo_NotExist;
                        }
                    }
                    else
                    {
                        if (devCount > 0)
                        {
                            MessageBox.Show($"针脚{switchStandStitch}已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return InterfaceExTipEnum.InterfacePoint_NotExistANdStitch_Exist;
                        }
                        else
                        {
                            return InterfaceExTipEnum.NONE;
                        }
                    }
                }
                else
                {
                    //接点或者针脚是否存在
                    var where1 = $"where ID != '{ID}' and InterfaceNo = '{interfaceNo}' and ContactPointName='{interfacePName}'";
                    var where2 = $"where ID != '{ID}' and InterfaceNo = '{interfaceNo}' and SwitchStandStitchNo='{switchStandStitch}'";
                    var cpointCount = plugLibraryDetailManager.GetRowCountByWhere(where1);
                    var dpointCount = plugLibraryDetailManager.GetRowCountByWhere(where2);
                    if (cpointCount > 0 && dpointCount <= 0)
                    {
                        MessageBox.Show($"接点{interfacePName}已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return InterfaceExTipEnum.InterfacePoint_ExistAndStitchNo_Exist;
                    }
                    else if (cpointCount <= 0 && dpointCount > 0)
                    {
                        MessageBox.Show($"针脚{switchStandStitch}已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return InterfaceExTipEnum.InterfacePoint_NotExistANdStitch_Exist;
                    }
                    else if (cpointCount > 0 && dpointCount > 0)
                    {
                        MessageBox.Show($"接点{interfacePName}已存在,针脚{switchStandStitch}已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return InterfaceExTipEnum.InterfacePoint_ExistAndStitchNo_Exist;
                    }
                    else
                    {
                        //update
                        return InterfaceExTipEnum.InterfacePoint_NotExistAndStitch_NoExist;
                    }
                }
            }
            else
            {
                //insert
                return InterfaceExTipEnum.NONE;
            }
        }

        private int UpdateInterfaceInfo()
        {
            int resCount = 0;
            if (interfaceLibaryInfos.Count < 1)
                return 0;
            if (!CheckValid())
                return 0;
            
            foreach (var infoObj in this.interfaceLibaryInfos)
            {
                infoObj.Operator = LocalLogin.currentUserName;
                infoObj.UpdateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                var result = IsCanInsertOrUpdate(true, infoObj.ID, infoObj.InterfaceNo, infoObj.ContactPointName, infoObj.SwitchStandStitchNo, infoObj.Remark);
                if (result == InterfaceExTipEnum.InterfacePoint_NotExistAndStitch_NoExist)
                {
                    resCount += plugLibraryDetailManager.Update(infoObj);
                }
                else
                {
                    continue;
                }
            }
            interfaceLibaryInfos.Clear();
            RefreshDataGrid();
            return resCount;
        }

        private bool IsNullInterfaceNo()
        {
            var interfaceNo = this.tb_interfacelNo.Text.Trim();
            if (interfaceNo == "")
            {
                MessageBox.Show("接口代号不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        private bool IsExistLocalDB()
        {
            var plugNo = this.tb_interfacelNo.Text.Trim();
            int resultCount = plugLibraryDetailManager.GetRowCountByWhere($"where InterfaceNo = '{plugNo}'");
            if (resultCount > 0)
                return true;
            return false;
        }

        private bool IsExistSwitchPointNo(string interfacePoint,string switchPointNo,string method)
        {
            if (this.radGridView1.RowCount < 1)
                return false;
            var interfaceNo = this.tb_interfacelNo.Text.Trim();
            foreach (var rowInfo in this.radGridView1.Rows)
            {
                var currentInterNo = rowInfo.Cells[1].Value.ToString();
                var interfacePointName = rowInfo.Cells[2].Value.ToString();
                var measureMethod = rowInfo.Cells[3].Value.ToString();
                var pointNo = rowInfo.Cells[4].Value.ToString();
                if (method == "二线法")
                {
                    if (interfaceNo == currentInterNo && interfacePointName == interfacePoint)
                    {
                        MessageBox.Show($"接点{interfacePointName}已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }
                    if (interfaceNo == currentInterNo && pointNo == switchPointNo)
                    {
                        MessageBox.Show($"针脚{switchPointNo}已在接点{interfacePointName}中定义！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }
                }
                else if (method == "四线法")
                {
                    if (interfaceNo == currentInterNo && interfacePointName == interfacePoint)
                    {
                        MessageBox.Show($"接点{interfacePointName}已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }
                    if (interfaceNo == currentInterNo && switchPointNo.Contains(pointNo))//判断不准确，后续优化
                    {
                        MessageBox.Show($"针脚{switchPointNo}已在接点{interfacePointName}中定义！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }
                }
            }
            return false;
        }

        private int GetPlugPrimary(string plug, string pinName, string stitchNo)
        {
            int ID;
            var dt = plugLibraryDetailManager.GetDataSetByWhere($"where InterfaceNo='{plug}' and ContactPointName='{pinName}' and SwitchStandStitchNo='{stitchNo}'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                int.TryParse(dt.Rows[0]["ID"].ToString(), out ID);
                return ID;
            }
            return 0;
        }

        private bool IsValidInterfaceNO()
        {
            if (IsNullInterfaceNo())
                return false;
            if (IsExistLocalDB())
            {
                MessageBox.Show($"接口代号{this.tb_interfacelNo.Text}已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
