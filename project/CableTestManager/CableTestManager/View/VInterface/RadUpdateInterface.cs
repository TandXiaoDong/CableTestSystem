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
        private string interPointName;
        private string testMethod;
        private string switchStandStitch;
        private string remark;
        List<InterfaceLibaryInfo> interfaceLibaryInfos;


        public RadUpdateInterface(string title, string plugNo,bool IsEdit)
        {
            InitializeComponent();

            this.Text = title;
            this.plugno = plugNo;
            this.IsEditView = IsEdit;

            Init(IsEdit);
            RefreshDataGrid();
            EventHandlers();
        }

        private enum InterfaceExTipEnum
        { 
            NONE,
            InterfacePoint_ExistAndStitchNo_NotExist,
            InterfacePoint_ExistAndStitchNo_Exist,
            InterfacePoint_NotExistAndStitch_NoExist,
            InterfacePoint_NotExistANdStitch_Exist
        }

        private void Init(bool IsEdit)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            plugLibraryDetailManager = new InterfaceInfoLibraryManager();
            RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,false,8);
            GridViewComboBoxColumn methodName = this.radGridView1.Columns["columnMethod"] as GridViewComboBoxColumn;
            methodName.DataSource = new string[] { TWO_WIRE_METHOD,FOUR_WIRE_METHOD};
            interfaceLibaryInfos = new List<InterfaceLibaryInfo>();
            this.radGridView1.Columns[5].IsVisible = false;
            this.radGridView1.Columns[7].IsVisible = false;
            if (IsEdit)
            {
                this.radGridView1.Columns[0].ReadOnly = true;
                this.radGridView1.Columns[1].ReadOnly = true;
            }
            else
            {
                this.radGridView1.ReadOnly = true;
            }
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
            if (pointn != this.interPointName || this.testMethod != method || stitch != this.switchStandStitch || this.remark != rmark)
            {
                var obj1 = interfaceLibaryInfos.Find(obj => obj.InterfaceNO == interNo);
                obj1.InterfacePointName = pointn;
                obj1.MeasureMethod = method;
                obj1.SwitchStandStitchNo = stitch;
                obj1.Remark = rmark;
            }
        }

        private void RadGridView1_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            var cIndex = this.radGridView1.CurrentRow.Index;
            if (cIndex < 0)
                return;
            
            this.interPointName = this.radGridView1.CurrentRow.Cells[2].Value.ToString();
            this.testMethod = this.radGridView1.CurrentRow.Cells[3].Value.ToString();
            this.switchStandStitch = this.radGridView1.CurrentRow.Cells[4].Value.ToString();
            this.remark = this.radGridView1.CurrentRow.Cells[6].Value.ToString();
            InterfaceLibaryInfo interfaceLibaryInfo = new InterfaceLibaryInfo();
            interfaceLibaryInfo.InterfaceNO = this.radGridView1.CurrentRow.Cells[1].Value.ToString();
            interfaceLibaryInfo.InterfacePrimaryID = GetPlugPrimary(interfaceLibaryInfo.InterfaceNO, this.interPointName, this.switchStandStitch);
            var obj1 = interfaceLibaryInfos.Find(obj => obj.InterfaceNO == interfaceLibaryInfo.InterfaceNO);
            if (obj1 == null)
                interfaceLibaryInfos.Add(interfaceLibaryInfo);
        }

        private void Menu_deleteSelect_Click(object sender, EventArgs e)
        {
            var currentRow = this.radGridView1.CurrentRow;
            if (currentRow == null)
                return;
            this.radGridView1.CurrentRow.Delete();
        }

        private void Menu_deleteAll_Click(object sender, EventArgs e)
        {
            if (this.radGridView1.RowCount < 1)
                return;
            for (int i = this.radGridView1.RowCount - 1; i >= 0; i--)
            {
                this.radGridView1.Rows[i].Delete();
            }
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
            if (!IsValidInterfaceNO())
                return;
            BatchAddInterfaceDefine batchAddInterfaceDefine = new BatchAddInterfaceDefine();
            if (batchAddInterfaceDefine.ShowDialog() == DialogResult.OK)
            {
                var nameRule = batchAddInterfaceDefine.nameRule;
                var testMethod = batchAddInterfaceDefine.testMethod;
                var startInterfacePoint = batchAddInterfaceDefine.startInterfacePoint;
                var startPin = batchAddInterfaceDefine.startPin;
                var totalNum = batchAddInterfaceDefine.totalNum;
                int startInterfacePointIndex,startPinIndex;
                int.TryParse(startPin,out startPinIndex);
                int.TryParse(startInterfacePoint,out startInterfacePointIndex);
                if (totalNum < 1)
                    return;
                int stitchNo = 1;
                for (int i = 1; i <= totalNum; i++)
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
                    AddGridViewRow(interfacePointName, testMethod, switchStandPointNo, "");
                    startPinIndex++;
                    startInterfacePointIndex++;
                }
            }
        }

        private void Menu_signalAddInterfacePoint_Click(object sender, EventArgs e)
        {
            if (!IsValidInterfaceNO())
                return;
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
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            SubmitData();
        }

        private void RadGridView1_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            var currentMethod = this.radGridView1.CurrentRow.Cells[3].Value;
            if (currentMethod == null)
                return;
            UpdateSwitchPointValue(currentMethod.ToString());
        }

        private void UpdateSwitchPointValue(string methodName)
        {
            GridViewComboBoxColumn stitchColumn = this.radGridView1.Columns["columnStitch"] as GridViewComboBoxColumn;
            if (methodName == TWO_WIRE_METHOD)
            {
                stitchColumn.DataSource = TwoWireMethodStitchList();
            }
            else if (methodName == FOUR_WIRE_METHOD)
            {
                stitchColumn.DataSource = FourWireMethodStitchList();
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

        private void RefreshDataGrid()
        {
            InterfaceInfoLibraryManager plugLibraryDetailManager = new InterfaceInfoLibraryManager();
            var dt = plugLibraryDetailManager.GetDataSetByWhere($"where InterfaceNo='{this.plugno}'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                int iRow = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    this.radGridView1.Rows.AddNew();
                    this.radGridView1.Rows[iRow].Cells[0].Value = iRow + 1;
                    this.radGridView1.Rows[iRow].Cells[1].Value = dr["InterfaceNo"].ToString();
                    this.radGridView1.Rows[iRow].Cells[2].Value = dr["ContactPointName"].ToString();
                    if (dr["MeasureMethod"].ToString() == "2")
                    {
                        this.radGridView1.Rows[iRow].Cells[3].Value = TWO_WIRE_METHOD;
                        UpdateSwitchPointValue(TWO_WIRE_METHOD);
                    }
                    else if (dr["MeasureMethod"].ToString() == "4")
                    {
                        this.radGridView1.Rows[iRow].Cells[3].Value = FOUR_WIRE_METHOD;
                        UpdateSwitchPointValue(FOUR_WIRE_METHOD);
                    }
                    this.radGridView1.Rows[iRow].Cells[4].Value = dr["SwitchStandStitchNo"].ToString();
                    this.radGridView1.Rows[iRow].Cells[5].Value = dr["ConnectorName"].ToString();
                    this.radGridView1.Rows[iRow].Cells[6].Value = dr["remark"].ToString();
                    
                    iRow++;
                }
            }
        }

        private void SubmitData()
        {
            System.Threading.Tasks.Task.Run(()=>
            {
                lock (this)
                {
                    btnSubmit.Enabled = false;
                    if (this.IsEditView)
                    {
                        UpdateInterfaceInfo();
                        return;
                    }
                    if (this.radGridView1.RowCount < 1)
                    {
                        MessageBox.Show("没有可以提交的数据!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!CheckValid())
                        return;
                    int beforeInsertCount = plugLibraryDetailManager.GetRowCount();
                    int excuteCount = 0;
                    //submit data
                    int iRow = 1;
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
                        plugLibraryDetail.ID = CableTestManager.Common.TablePrimaryKey.InsertInterfaceLibPID();
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
                            if (IsCanInsertOrUpdate(false, -1, plugNo, pinName, stitchNo) == InterfaceExTipEnum.InterfacePoint_NotExistAndStitch_NoExist)
                            {
                                plugLibraryDetailManager.Insert(plugLibraryDetail);
                                iRow++;
                            }
                        }
                    }

                    int afterInsertCount = plugLibraryDetailManager.GetRowCount();
                    if (afterInsertCount - beforeInsertCount > 0)
                    {
                        MessageBox.Show($"已更新{afterInsertCount - beforeInsertCount}条数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (excuteCount > 0)
                    {
                        MessageBox.Show($"已更新{excuteCount}条数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"已更新{0}条数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
            });
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

        private InterfaceExTipEnum IsCanInsertOrUpdate(bool IsUpdate,long ID, string interfaceNo,string interfacePName,string switchStandStitch)
        {
            //查询本地库是否已存在要更新的值，不存在时可以更新
            var selectPointSQL = $"where InterfaceNo='{interfaceNo}' and ContactPointName='{interfacePName}'";
            var selectStitchSQL = $"where InterfaceNo='{interfaceNo}' and SwitchStandStitchNo like '%{switchStandStitch}%'";
            if (IsUpdate)
            {
                selectPointSQL = $"where ID != '{ID}' and InterfaceNo='{interfaceNo}' and ContactPointName='{interfacePName}'";
                selectStitchSQL = $"where ID != '{ID}' and InterfaceNo='{interfaceNo}' and SwitchStandStitchNo like '%{switchStandStitch}%'";
            }
            var interNameData = plugLibraryDetailManager.GetDataSetByWhere(selectPointSQL).Tables[0];
            var stitchNoData = plugLibraryDetailManager.GetDataSetByWhere(selectStitchSQL).Tables[0];
            if (interNameData.Rows.Count < 1 && stitchNoData.Rows.Count < 1)
            {
                //update
                return InterfaceExTipEnum.InterfacePoint_NotExistAndStitch_NoExist;
            }
            else if (interNameData.Rows.Count > 0 && stitchNoData.Rows.Count > 0)
            {
                MessageBox.Show($"接点{interfacePName}已存在,针脚{switchStandStitch}已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return InterfaceExTipEnum.InterfacePoint_ExistAndStitchNo_Exist;
            }
            else if (interNameData.Rows.Count > 0 && stitchNoData.Rows.Count < 1)
            {
                MessageBox.Show($"接点{interfacePName}已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return InterfaceExTipEnum.InterfacePoint_ExistAndStitchNo_NotExist;
            }
            else if (interNameData.Rows.Count < 1 && stitchNoData.Rows.Count > 0)
            {
                MessageBox.Show($"针脚{switchStandStitch}已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return InterfaceExTipEnum.InterfacePoint_NotExistANdStitch_Exist;
            }
            return InterfaceExTipEnum.NONE;
        }

        private void UpdateInterfaceInfo()
        {
            if (interfaceLibaryInfos.Count < 1)
                return;
            if (!CheckValid())
                return;
            int rowCount = 0;
            foreach (var infoObj in this.interfaceLibaryInfos)
            {
                InterfaceInfoLibrary plugLibraryDetail = new InterfaceInfoLibrary();
                plugLibraryDetail.ID = infoObj.InterfacePrimaryID;
                plugLibraryDetail.InterfaceNo = infoObj.InterfaceNO;
                plugLibraryDetail.ContactPointName = infoObj.InterfacePointName;
                plugLibraryDetail.SwitchStandStitchNo = infoObj.SwitchStandStitchNo;
                if (infoObj.MeasureMethod == TWO_WIRE_METHOD)
                    plugLibraryDetail.MeasureMethod = "2";
                else if (infoObj.MeasureMethod == FOUR_WIRE_METHOD)
                    plugLibraryDetail.MeasureMethod = "4";
                plugLibraryDetail.Remark = infoObj.Remark;
                plugLibraryDetail.Operator = LocalLogin.currentUserName;
                plugLibraryDetail.UpdateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (IsCanInsertOrUpdate(true, infoObj.InterfacePrimaryID, infoObj.InterfaceNO, infoObj.InterfacePointName, infoObj.SwitchStandStitchNo) == InterfaceExTipEnum.InterfacePoint_ExistAndStitchNo_Exist)
                    continue;
                if (IsCanInsertOrUpdate(true, infoObj.InterfacePrimaryID, infoObj.InterfaceNO, infoObj.InterfacePointName, infoObj.SwitchStandStitchNo) == InterfaceExTipEnum.NONE)
                    continue;
                rowCount += plugLibraryDetailManager.Update(plugLibraryDetail);
            }
            interfaceLibaryInfos.Clear();
            MessageBox.Show($"已更新{rowCount}条数据！","提示",MessageBoxButtons.OK);
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
                    if (interfaceNo == currentInterNo && pointNo.Contains(switchPointNo))
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
                    if (interfaceNo == currentInterNo && switchPointNo.Contains(pointNo))
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
