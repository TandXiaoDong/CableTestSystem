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
using CableTestManager.Entity;
using CableTestManager.Common;
using Telerik.WinControls.UI;

namespace CableTestManager.CUserManager
{
    public partial class LimmitManager : Form
    {
        private FuncLimitManager funLimitManager;
        private OperatLimitManager operatLimitManager;
        private TRoleManager roleManager;
        private Dictionary<string, int> dicFuncLimitPairs;
        private Dictionary<string, int> dicOperateLimitPairs;

        #region func limit const params
        private const string FUN_INTERFACE_LIB_MANAGE_NAME = "接口库管理";
        private const string FUN_CABLE_LIB_MANAGE_NAME = "线束库管理";
        //private const string FUN_CONNECTOR_LIB_MANAGE_NAME = "连接器库管理";
        //private const string FUN_SWITCH_WEAR_LIB_MANAGE_NAME = "转接工装库管理";
        //private const string FUN_SWITCH_STAND_LIB_MANAGE_NAME = "转接台阵脚映射库管理";
        private const string FUN_SELF_STUDY_NAME = "自学习";
        private const string FUN_CONDUCT_TEST_NAME = "导通测试";
        private const string FUN_INSULATE_TEST_NAME = "绝缘测试";
        private const string FUN_CIRCUIT_TEST_NAME = "短路测试";
        private const string FUN_ONE_KEY_TEST_NAME = "一键测试";
        private const string FUN_EXCUTE_REPORT_NAME = "生成报表";
        private const string FUN_PRINT_REPORT = "打印报表";
        private const string FUN_SAVE_DATA = "保存数据";
        private const string FUN_NEW_PROJECT = "新建项目";
        private const string FUN_PROJECT_MANAGE = "项目管理";
        private const string FUN_TEST_DATA = "测试数据";
        private const string FUN_OPERAT_RECORD = "操作记录";
        private const string FUN_PROBE = "探针";
        private const string FUN_START_RESISTAN_COMPENSAT = "启用电阻补偿";
        private const string FUN_RESISTAN_COMPENSAT_MANAGE = "电阻补偿管理";
        private const string FUN_REPORT_PATH_SET = "报表保存路径设置";
        private const string FUN_DEVICE_SELF_CHECK = "设备自检";
        private const string FUN_DEVICE_CALIBRATE = "设备计量";
        private const string FUN_DEVICE_DEBUG = "设备调试助手";
        //private const string FUN_FAULT_QUERY = "设备故障查询";
        private const string FUN_ENVIRONMENT_PARAMS_SET = "试验环境参数配置";
        #endregion

        #region operate limit const prams
        private const string OPERATE_QUERY_INTER_INFO = "查询接口信息";
        private const string OPERATE_ADD_INTER_INFO = "添加接口信息";
        private const string OPERATE_EDIT_INTER_INFO = "编辑接口信息";
        private const string OPERATE_DEL_INTER_INFO = "删除接口信息";
        private const string OPERATE_EXPORT_INTER_INFO = "导出接口库";
        private const string OPERATE_QUERY_CABLE_LIB = "查询线束库";
        private const string OPERATE_EDIT_CABLE_LIB = "编辑线束";
        private const string OPERATE_DEL_CABLE_LIB = "删除线束";
        private const string OPERATE_ADD_CABLE_LIB = "添加线束";
        private const string OPERATE_EXPORT_CABLE_LIB = "导出线束库";
        //private const string OPERATE_QUERY_CONNECTOR_LIB = "查询连接器库";
        //private const string OPERATE_EDIT_CONNECTOR = "编辑连接器";
        //private const string OPERATE_DEL_CONNECTOR = "删除连接器";
        //private const string OPERATE_ADD_CONNECTOR = "添加连接器";
        //private const string OPERATE_EXPORT_CONNECTOR = "导出连接器库";
        //private const string OPERATE_QUERY_SWITCH_WEAR = "查询转接工装库";
        //private const string OPERATE_ADD_SWITCH_WEAR = "添加转接工装";
        //private const string OPERATE_EDIT_SWITCH_WEAR = "编辑转接工装";
        //private const string OPERATE_DEL_SWITCH_WEAR = "删除转接工装";
        //private const string OPERATE_EXPORT_SWITCH_WEAR = "导出转接工装库";
        //private const string OPERATE_QUERY_SWITCH_STAND = "查询转接台阵脚映射库";
        //private const string OPERATE_ADD_SWITCH_STAND = "新增转接台阵脚映射";
        //private const string OPERATE_EDIT_SWITCH_STAND = "编辑转接台阵脚映射";
        //private const string OPERATE_DEL_SWITCH_STAND = "删除转接台阵脚映射";
        //private const string OPERATE_EXPORT_SWITCH_STAND = "导出转接台阵脚映射库";
        private const string OPERATE_QUERY_PROJECT = "查询项目信息";
        private const string OPERATE_ADD_PROJECT = "添加项目";
        private const string OPERATE_EDIT_PROJECT = "编辑项目";
        private const string OPERATE_DEL_PROJECT = "删除项目";
        private const string OPERATE_QUERY_TEST_DATA = "查询测试数据";
        private const string OPERATE_DEL_TEST_DATA = "删除测试数据";
        private const string OPERATE_EXPORT_TEST_DATA = "导出测试数据";
        private const string OPERATE_QUERY_OPERATE_RECORD = "查询操作记录";
        private const string OPERATE_DEL_OPERATE_RECORD = "删除操作记录";
        private const string OPERATE_EXPORT_OPERATE_RECORD = "导出操作记录";
        #endregion

        public LimmitManager()
        {
            InitializeComponent();
        }

        private void LimmitManager_Load(object sender, EventArgs e)
        {
            this.dicFuncLimitPairs = new Dictionary<string, int>();
            this.dicOperateLimitPairs = new Dictionary<string, int>();
            this.funLimitManager = new FuncLimitManager();
            this.operatLimitManager = new OperatLimitManager();
            this.roleManager = new TRoleManager();
            Init();

            this.btn_cancel.Click += Btn_cancel_Click;
            this.btn_ok.Click += Btn_ok_Click;
            this.checkAllFunc.CheckStateChanged += CheckAllFunc_CheckStateChanged;
            this.checkAllOperat.CheckStateChanged += CheckAllOperat_CheckStateChanged;
            this.cob_roleList.SelectedIndexChanged += Cob_roleList_SelectedIndexChanged;
        }

        private void Cob_roleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitCheckLimitByRole(this.cob_roleList.Text.Trim());
        }

        private void CheckAllOperat_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.checkAllOperat.Checked)
            {
                foreach (var item in this.checkListOperatLimit.Items)
                {
                    item.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                }
            }
            else
            {
                foreach (var item in this.checkListOperatLimit.Items)
                {
                    item.CheckState = Telerik.WinControls.Enumerations.ToggleState.Off;
                }
            }
        }

        private void CheckAllFunc_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.checkAllFunc.Checked)
            {
                foreach (var item in this.checkListFuncLimit.Items)
                {
                    item.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                }
            }
            else
            {
                foreach (var item in this.checkListFuncLimit.Items)
                {
                    item.CheckState = Telerik.WinControls.Enumerations.ToggleState.Off;
                }
            }
        }

        private void Btn_ok_Click(object sender, EventArgs e)
        {
            var curRole = this.cob_roleList.Text.Trim();
            if (curRole == "")
            {
                MessageBox.Show("请选择要授权的角色！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            //update diclist
            FuncLimit funcLimit = new FuncLimit();
            funcLimit.UserRole = curRole;
            OperatLimit operatLimit = new OperatLimit();
            operatLimit.UserRole = curRole;
            foreach (var item in this.checkListFuncLimit.Items)
            {
                switch (item.Text)
                {
                    case FUN_CABLE_LIB_MANAGE_NAME:
                        funcLimit.CableLib = ConvertState2Dec(item.CheckState);
                        break;
                    case FUN_CIRCUIT_TEST_NAME:
                        funcLimit.ShortCircuitTest = ConvertState2Dec(item.CheckState);
                        break;
                    case FUN_CONDUCT_TEST_NAME:
                        funcLimit.ConductTest = ConvertState2Dec(item.CheckState);
                        break;
                    //case FUN_CONNECTOR_LIB_MANAGE_NAME:
                    //    funcLimit.ConnectorLib = ConvertState2Dec(item.CheckState);
                    //    break;
                    case FUN_DEVICE_CALIBRATE:
                        funcLimit.DeviceCalibration = ConvertState2Dec(item.CheckState);
                        break;
                    case FUN_DEVICE_DEBUG:
                        funcLimit.DeviceDebug = ConvertState2Dec(item.CheckState);
                        break;
                    case FUN_DEVICE_SELF_CHECK:
                        funcLimit.DeviceSelfCheck = ConvertState2Dec(item.CheckState);
                        break;
                    case FUN_ENVIRONMENT_PARAMS_SET:
                        funcLimit.EnvironmentalParameters = ConvertState2Dec(item.CheckState);
                        break;
                    case FUN_EXCUTE_REPORT_NAME:
                        funcLimit.ExcuteReport = ConvertState2Dec(item.CheckState);
                        break;
                    //case FUN_FAULT_QUERY:
                    //    funcLimit.DeviceFaultQuery = ConvertState2Dec(item.CheckState);
                    //    break;
                    case FUN_INSULATE_TEST_NAME:
                        funcLimit.InsulateTest = ConvertState2Dec(item.CheckState);
                        break;
                    case FUN_INTERFACE_LIB_MANAGE_NAME:
                        funcLimit.InterfaceLib = ConvertState2Dec(item.CheckState);
                        break;
                    case FUN_NEW_PROJECT:
                        funcLimit.NewProject = ConvertState2Dec(item.CheckState);
                        break;
                    case FUN_ONE_KEY_TEST_NAME:
                        funcLimit.OneKeyTest = ConvertState2Dec(item.CheckState);
                        break;
                    case FUN_OPERAT_RECORD:
                        funcLimit.OperatorRecord = ConvertState2Dec(item.CheckState);
                        break;
                    case FUN_PRINT_REPORT:
                        funcLimit.PrintReport = ConvertState2Dec(item.CheckState);
                        break;
                    case FUN_PROBE:
                        funcLimit.Probe = ConvertState2Dec(item.CheckState);
                        break;
                    case FUN_PROJECT_MANAGE:
                        funcLimit.ProjectManage = ConvertState2Dec(item.CheckState);
                        break;
                    case FUN_REPORT_PATH_SET:
                        funcLimit.ReportConfigPath = ConvertState2Dec(item.CheckState);
                        break;
                    case FUN_RESISTAN_COMPENSAT_MANAGE:
                        funcLimit.ResistanceCompensationManage = ConvertState2Dec(item.CheckState);
                        break;
                    case FUN_SAVE_DATA:
                        funcLimit.SaveTestData = ConvertState2Dec(item.CheckState);
                        break;
                    case FUN_SELF_STUDY_NAME:
                        funcLimit.SelfStudy = ConvertState2Dec(item.CheckState);
                        break;
                    case FUN_START_RESISTAN_COMPENSAT:
                        funcLimit.StartResistanceCompensation = ConvertState2Dec(item.CheckState);
                        break;
                    //case FUN_SWITCH_STAND_LIB_MANAGE_NAME:
                    //    funcLimit.SwitchStandLib = ConvertState2Dec(item.CheckState);
                    //    break;
                    //case FUN_SWITCH_WEAR_LIB_MANAGE_NAME:
                    //    funcLimit.SwitchWearLib = ConvertState2Dec(item.CheckState);
                    //    break;
                    case FUN_TEST_DATA:
                        funcLimit.HistoryTestData = ConvertState2Dec(item.CheckState);
                        break;
                }
            }
            foreach (var item in this.checkListOperatLimit.Items)
            {
                switch (item.Text)
                {
                    case OPERATE_ADD_CABLE_LIB:
                        operatLimit.CableLib_add = ConvertState2Dec(item.CheckState);
                        break;
                    //case OPERATE_ADD_CONNECTOR:
                    //    operatLimit.ConnectorLib_add = ConvertState2Dec(item.CheckState);
                    //    break;
                    case OPERATE_ADD_INTER_INFO:
                        operatLimit.InterfaceLib_add = ConvertState2Dec(item.CheckState);
                        break;
                    case OPERATE_ADD_PROJECT:
                        operatLimit.Project_add = ConvertState2Dec(item.CheckState);
                        break;
                    //case OPERATE_ADD_SWITCH_STAND:
                    //    operatLimit.SwitchStandLib_add = ConvertState2Dec(item.CheckState);
                    //    break;
                    //case OPERATE_ADD_SWITCH_WEAR:
                    //    operatLimit.SwitchWearLib_add = ConvertState2Dec(item.CheckState);
                    //    break;
                    case OPERATE_DEL_CABLE_LIB:
                        operatLimit.CableLib_del = ConvertState2Dec(item.CheckState);
                        break;
                    //case OPERATE_DEL_CONNECTOR:
                    //    operatLimit.ConnectorLib_del = ConvertState2Dec(item.CheckState);
                    //    break;
                    case OPERATE_DEL_INTER_INFO:
                        operatLimit.InterfaceLib_del = ConvertState2Dec(item.CheckState);
                        break;
                    case OPERATE_DEL_OPERATE_RECORD:
                        operatLimit.OperatorRecord_del = ConvertState2Dec(item.CheckState);
                        break;
                    case OPERATE_DEL_PROJECT:
                        operatLimit.Project_del = ConvertState2Dec(item.CheckState);
                        break;
                    //case OPERATE_DEL_SWITCH_STAND:
                    //    operatLimit.SwitchStandLib_del = ConvertState2Dec(item.CheckState);
                    //    break;
                    //case OPERATE_DEL_SWITCH_WEAR:
                    //    operatLimit.SwitchWearLib_del = ConvertState2Dec(item.CheckState);
                    //    break;
                    case OPERATE_DEL_TEST_DATA:
                        operatLimit.HistoryTestData_del = ConvertState2Dec(item.CheckState);
                        break;
                    case OPERATE_EDIT_CABLE_LIB:
                        operatLimit.CableLib_edit = ConvertState2Dec(item.CheckState);
                        break;
                    //case OPERATE_EDIT_CONNECTOR:
                    //    operatLimit.ConnectorLib_edit = ConvertState2Dec(item.CheckState);
                    //    break;
                    case OPERATE_EDIT_INTER_INFO:
                        operatLimit.InterfaceLib_edit = ConvertState2Dec(item.CheckState);
                        break;
                    case OPERATE_EDIT_PROJECT:
                        operatLimit.Project_edit = ConvertState2Dec(item.CheckState);
                        break;
                    //case OPERATE_EDIT_SWITCH_STAND:
                    //    operatLimit.SwitchStandLib_edit = ConvertState2Dec(item.CheckState);
                    //    break;
                    //case OPERATE_EDIT_SWITCH_WEAR:
                    //    operatLimit.SwitchWearLib_edit = ConvertState2Dec(item.CheckState);
                    //    break;
                    //case OPERATE_EXPORT_CONNECTOR:
                    //    operatLimit.ConnectorLib_export = ConvertState2Dec(item.CheckState);
                    //    break;
                    case OPERATE_EXPORT_INTER_INFO:
                        operatLimit.InterfaceLib_export = ConvertState2Dec(item.CheckState);
                        break;
                    case OPERATE_EXPORT_OPERATE_RECORD:
                        operatLimit.OperatorRecord_export = ConvertState2Dec(item.CheckState);
                        break;
                    //case OPERATE_EXPORT_SWITCH_STAND:
                    //    operatLimit.SwitchStandLib_export = ConvertState2Dec(item.CheckState);
                    //    break;
                    //case OPERATE_EXPORT_SWITCH_WEAR:
                    //    operatLimit.SwitchWearLib_export = ConvertState2Dec(item.CheckState);
                    //    break;
                    case OPERATE_EXPORT_TEST_DATA:
                        operatLimit.HistoryTestData_export = ConvertState2Dec(item.CheckState);
                        break;
                    case OPERATE_EXPORT_CABLE_LIB:
                        operatLimit.CableLib_export = ConvertState2Dec(item.CheckState);
                        break;
                    case OPERATE_QUERY_CABLE_LIB:
                        operatLimit.CableLib_query = ConvertState2Dec(item.CheckState);
                        break;
                    //case OPERATE_QUERY_CONNECTOR_LIB:
                    //    operatLimit.ConnectorLib_query = ConvertState2Dec(item.CheckState);
                    //    break;
                    case OPERATE_QUERY_INTER_INFO:
                        operatLimit.InterfaceLib_query = ConvertState2Dec(item.CheckState);
                        break;
                    case OPERATE_QUERY_OPERATE_RECORD:
                        operatLimit.OperatorRecord_query = ConvertState2Dec(item.CheckState);
                        break;
                    case OPERATE_QUERY_PROJECT:
                        operatLimit.Project_query = ConvertState2Dec(item.CheckState);
                        break;
                    //case OPERATE_QUERY_SWITCH_STAND:
                    //    operatLimit.SwitchStandLib_query = ConvertState2Dec(item.CheckState);
                    //    break;
                    //case OPERATE_QUERY_SWITCH_WEAR:
                    //    operatLimit.SwitchWearLib_query = ConvertState2Dec(item.CheckState);
                    //    break;
                    case OPERATE_QUERY_TEST_DATA:
                        operatLimit.HistoryTestData_query = ConvertState2Dec(item.CheckState);
                        break;
                }
            }

            if (IsExistRoleFuncLimit(curRole))
            {
                funcLimit.ID = GetFuncIDByRole(curRole);
                this.funLimitManager.Update(funcLimit);
            }
            else
            {
                funcLimit.ID = TablePrimaryKey.InsertFuncLimitPID();
                this.funLimitManager.Insert(funcLimit);
            }
            if (IsExistRoleOperatLimit(curRole))
            {
                operatLimit.ID = GetOperatIDByRole(curRole);
                var ups = this.operatLimitManager.Update(operatLimit);
                if (ups > 0)
                {
                    MessageBox.Show("更新成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                operatLimit.ID = TablePrimaryKey.InsertOperateLimitPID();
                var ins = this.operatLimitManager.Insert(operatLimit);
                if (ins > 0)
                {
                    MessageBox.Show("更新成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            this.Close();
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Init()
        {
            InitCheckItems();
            this.cob_roleList.MultiColumnComboBoxElement.Columns.Add("NAME");
            var data = roleManager.GetDataSetByFieldsAndWhere("distinct UserRole", "where UserRole != '管理员'").Tables[0];
            if (data.Rows.Count <= 0)
                return;
            foreach (DataRow dr in data.Rows)
            {
                this.cob_roleList.EditorControl.Rows.Add(dr[0].ToString());
            }
            this.cob_roleList.EditorControl.ShowColumnHeaders = false;
            this.cob_roleList.EditorControl.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            if (this.cob_roleList.EditorControl.Rows.Count > 0)
            {
                this.cob_roleList.SelectedIndex = 0;
            }
            //init limit
            InitCheckLimitByRole(this.cob_roleList.Text.Trim());
        }

        private void InitCheckItems()
        {
            this.checkListFuncLimit.Items.Add(FUN_CABLE_LIB_MANAGE_NAME);
            this.checkListFuncLimit.Items.Add(FUN_CIRCUIT_TEST_NAME);
            this.checkListFuncLimit.Items.Add(FUN_CONDUCT_TEST_NAME);
            //this.checkListFuncLimit.Items.Add(FUN_CONNECTOR_LIB_MANAGE_NAME);
            this.checkListFuncLimit.Items.Add(FUN_DEVICE_CALIBRATE);
            this.checkListFuncLimit.Items.Add(FUN_DEVICE_DEBUG);
            this.checkListFuncLimit.Items.Add(FUN_DEVICE_SELF_CHECK);
            this.checkListFuncLimit.Items.Add(FUN_ENVIRONMENT_PARAMS_SET);
            this.checkListFuncLimit.Items.Add(FUN_EXCUTE_REPORT_NAME);
            //this.checkListFuncLimit.Items.Add(FUN_FAULT_QUERY);
            this.checkListFuncLimit.Items.Add(FUN_INSULATE_TEST_NAME);
            this.checkListFuncLimit.Items.Add(FUN_INTERFACE_LIB_MANAGE_NAME);
            this.checkListFuncLimit.Items.Add(FUN_NEW_PROJECT);
            this.checkListFuncLimit.Items.Add(FUN_ONE_KEY_TEST_NAME);
            this.checkListFuncLimit.Items.Add(FUN_OPERAT_RECORD); 
            this.checkListFuncLimit.Items.Add(FUN_PRINT_REPORT);
            this.checkListFuncLimit.Items.Add(FUN_PROBE);
            this.checkListFuncLimit.Items.Add(FUN_PROJECT_MANAGE);
            this.checkListFuncLimit.Items.Add(FUN_REPORT_PATH_SET);
            this.checkListFuncLimit.Items.Add(FUN_RESISTAN_COMPENSAT_MANAGE);
            this.checkListFuncLimit.Items.Add(FUN_SAVE_DATA);
            this.checkListFuncLimit.Items.Add(FUN_SELF_STUDY_NAME);
            this.checkListFuncLimit.Items.Add(FUN_START_RESISTAN_COMPENSAT);
            //this.checkListFuncLimit.Items.Add(FUN_SWITCH_STAND_LIB_MANAGE_NAME);
            //this.checkListFuncLimit.Items.Add(FUN_SWITCH_WEAR_LIB_MANAGE_NAME);
            this.checkListFuncLimit.Items.Add(FUN_TEST_DATA);

            this.checkListOperatLimit.Items.Add(OPERATE_ADD_CABLE_LIB);
            //this.checkListOperatLimit.Items.Add(OPERATE_ADD_CONNECTOR);
            this.checkListOperatLimit.Items.Add(OPERATE_ADD_INTER_INFO);
            this.checkListOperatLimit.Items.Add(OPERATE_ADD_PROJECT);
            //this.checkListOperatLimit.Items.Add(OPERATE_ADD_SWITCH_STAND);
            //this.checkListOperatLimit.Items.Add(OPERATE_ADD_SWITCH_WEAR);
            this.checkListOperatLimit.Items.Add(OPERATE_DEL_CABLE_LIB);
            //this.checkListOperatLimit.Items.Add(OPERATE_DEL_CONNECTOR);
            this.checkListOperatLimit.Items.Add(OPERATE_DEL_INTER_INFO);
            this.checkListOperatLimit.Items.Add(OPERATE_DEL_OPERATE_RECORD);
            this.checkListOperatLimit.Items.Add(OPERATE_DEL_PROJECT);
            //this.checkListOperatLimit.Items.Add(OPERATE_DEL_SWITCH_STAND);
            //this.checkListOperatLimit.Items.Add(OPERATE_DEL_SWITCH_WEAR);
            this.checkListOperatLimit.Items.Add(OPERATE_DEL_TEST_DATA);
            this.checkListOperatLimit.Items.Add(OPERATE_EDIT_CABLE_LIB);
            //this.checkListOperatLimit.Items.Add(OPERATE_EDIT_CONNECTOR);
            this.checkListOperatLimit.Items.Add(OPERATE_EDIT_INTER_INFO);
            this.checkListOperatLimit.Items.Add(OPERATE_EDIT_PROJECT);
            //this.checkListOperatLimit.Items.Add(OPERATE_EDIT_SWITCH_STAND);
            //this.checkListOperatLimit.Items.Add(OPERATE_EDIT_SWITCH_WEAR);
            this.checkListOperatLimit.Items.Add(OPERATE_EXPORT_CABLE_LIB);
            //this.checkListOperatLimit.Items.Add(OPERATE_EXPORT_CONNECTOR);
            this.checkListOperatLimit.Items.Add(OPERATE_EXPORT_INTER_INFO);
            this.checkListOperatLimit.Items.Add(OPERATE_EXPORT_OPERATE_RECORD);
            //this.checkListOperatLimit.Items.Add(OPERATE_EXPORT_SWITCH_STAND);
            //this.checkListOperatLimit.Items.Add(OPERATE_EXPORT_SWITCH_WEAR);
            this.checkListOperatLimit.Items.Add(OPERATE_EXPORT_TEST_DATA);
            this.checkListOperatLimit.Items.Add(OPERATE_QUERY_CABLE_LIB);
            //this.checkListOperatLimit.Items.Add(OPERATE_QUERY_CONNECTOR_LIB);
            this.checkListOperatLimit.Items.Add(OPERATE_QUERY_INTER_INFO);
            this.checkListOperatLimit.Items.Add(OPERATE_QUERY_OPERATE_RECORD);
            this.checkListOperatLimit.Items.Add(OPERATE_QUERY_PROJECT);
            //this.checkListOperatLimit.Items.Add(OPERATE_QUERY_SWITCH_STAND);
            //this.checkListOperatLimit.Items.Add(OPERATE_QUERY_SWITCH_WEAR);
            this.checkListOperatLimit.Items.Add(OPERATE_QUERY_TEST_DATA);
        }

        private void InitCheckLimitByRole(string role)
        {
            if (role == "")
                return;
            var data = this.funLimitManager.GetDataSetByWhere($"where UserRole='{role}'").Tables[0];
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    foreach (var item in this.checkListFuncLimit.Items)
                    {
                        switch (item.Text)
                        {
                            case FUN_CABLE_LIB_MANAGE_NAME:
                                item.CheckState = ConvertDec2State(dr["CableLib"].ToString());
                                break;
                            case FUN_CIRCUIT_TEST_NAME:
                                item.CheckState = ConvertDec2State(dr["ShortCircuitTest"].ToString());
                                break;
                            case FUN_CONDUCT_TEST_NAME:
                                item.CheckState = ConvertDec2State(dr["ConductTest"].ToString());
                                break;
                            //case FUN_CONNECTOR_LIB_MANAGE_NAME:
                            //    item.CheckState = ConvertDec2State(dr["ConnectorLib"].ToString());
                            //    break;
                            case FUN_DEVICE_CALIBRATE:
                                item.CheckState = ConvertDec2State(dr["DeviceCalibration"].ToString());
                                break;
                            case FUN_DEVICE_DEBUG:
                                item.CheckState = ConvertDec2State(dr["DeviceDebug"].ToString());
                                break;
                            case FUN_DEVICE_SELF_CHECK:
                                item.CheckState = ConvertDec2State(dr["DeviceSelfCheck"].ToString());
                                break;
                            case FUN_ENVIRONMENT_PARAMS_SET:
                                item.CheckState = ConvertDec2State(dr["EnvironmentalParameters"].ToString());
                                break;
                            case FUN_EXCUTE_REPORT_NAME:
                                item.CheckState = ConvertDec2State(dr["ExcuteReport"].ToString());
                                break;
                            //case FUN_FAULT_QUERY:
                            //    item.CheckState = ConvertDec2State(dr["DeviceFaultQuery"].ToString());
                            //    break;
                            case FUN_INSULATE_TEST_NAME:
                                item.CheckState = ConvertDec2State(dr["InsulateTest"].ToString());
                                break;
                            case FUN_INTERFACE_LIB_MANAGE_NAME:
                                item.CheckState = ConvertDec2State(dr["InterfaceLib"].ToString());
                                break;
                            case FUN_NEW_PROJECT:
                                item.CheckState = ConvertDec2State(dr["NewProject"].ToString());
                                break;
                            case FUN_ONE_KEY_TEST_NAME:
                                item.CheckState = ConvertDec2State(dr["OneKeyTest"].ToString());
                                break;
                            case FUN_OPERAT_RECORD:
                                item.CheckState = ConvertDec2State(dr["OperatorRecord"].ToString());
                                break;
                            case FUN_PRINT_REPORT:
                                item.CheckState = ConvertDec2State(dr["PrintReport"].ToString());
                                break;
                            case FUN_PROBE:
                                item.CheckState = ConvertDec2State(dr["Probe"].ToString());
                                break;
                            case FUN_PROJECT_MANAGE:
                                item.CheckState = ConvertDec2State(dr["ProjectManage"].ToString());
                                break;
                            case FUN_REPORT_PATH_SET:
                                item.CheckState = ConvertDec2State(dr["ReportConfigPath"].ToString());
                                break;
                            case FUN_RESISTAN_COMPENSAT_MANAGE:
                                item.CheckState = ConvertDec2State(dr["ResistanceCompensationManage"].ToString());
                                break;
                            case FUN_SAVE_DATA:
                                item.CheckState = ConvertDec2State(dr["SaveTestData"].ToString());
                                break;
                            case FUN_SELF_STUDY_NAME:
                                item.CheckState = ConvertDec2State(dr["SelfStudy"].ToString());
                                break;
                            case FUN_START_RESISTAN_COMPENSAT:
                                item.CheckState = ConvertDec2State(dr["StartResistanceCompensation"].ToString());
                                break;
                            //case FUN_SWITCH_STAND_LIB_MANAGE_NAME:
                            //    item.CheckState = ConvertDec2State(dr["SwitchStandLib"].ToString());
                            //    break;
                            //case FUN_SWITCH_WEAR_LIB_MANAGE_NAME:
                            //    item.CheckState = ConvertDec2State(dr["SwitchWearLib"].ToString());
                            //    break;
                            case FUN_TEST_DATA:
                                item.CheckState = ConvertDec2State(dr["HistoryTestData"].ToString());
                                break;
                        }
                    }
                }
            }
            data = this.operatLimitManager.GetDataSetByWhere($"where UserRole='{role}'").Tables[0];
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    foreach (var item in this.checkListOperatLimit.Items)
                    {
                        switch (item.Text)
                        {
                            case OPERATE_ADD_CABLE_LIB:
                                item.CheckState = ConvertDec2State(dr["CableLib_add"].ToString());
                                break;
                            //case OPERATE_ADD_CONNECTOR:
                            //    item.CheckState = ConvertDec2State(dr["ConnectorLib_add"].ToString());
                            //    break;
                            case OPERATE_ADD_INTER_INFO:
                                item.CheckState = ConvertDec2State(dr["InterfaceLib_add"].ToString());
                                break;
                            case OPERATE_ADD_PROJECT:
                                item.CheckState = ConvertDec2State(dr["Project_add"].ToString());
                                break;
                            //case OPERATE_ADD_SWITCH_STAND:
                            //    item.CheckState = ConvertDec2State(dr["SwitchStandLib_add"].ToString());
                            //    break;
                            //case OPERATE_ADD_SWITCH_WEAR:
                            //    item.CheckState = ConvertDec2State(dr["SwitchWearLib_add"].ToString());
                            //    break;
                            case OPERATE_DEL_CABLE_LIB:
                                item.CheckState = ConvertDec2State(dr["CableLib_del"].ToString());
                                break;
                            //case OPERATE_DEL_CONNECTOR:
                            //    item.CheckState = ConvertDec2State(dr["ConnectorLib_del"].ToString());
                            //    break;
                            case OPERATE_DEL_INTER_INFO:
                                item.CheckState = ConvertDec2State(dr["InterfaceLib_del"].ToString());
                                break;
                            case OPERATE_DEL_OPERATE_RECORD:
                                item.CheckState = ConvertDec2State(dr["OperatorRecord_del"].ToString());
                                break;
                            case OPERATE_DEL_PROJECT:
                                item.CheckState = ConvertDec2State(dr["Project_del"].ToString());
                                break;
                            //case OPERATE_DEL_SWITCH_STAND:
                            //    item.CheckState = ConvertDec2State(dr["SwitchStandLib_del"].ToString());
                            //    break;
                            //case OPERATE_DEL_SWITCH_WEAR:
                            //    item.CheckState = ConvertDec2State(dr["SwitchWearLib_del"].ToString());
                            //    break;
                            case OPERATE_DEL_TEST_DATA:
                                item.CheckState = ConvertDec2State(dr["HistoryTestData_del"].ToString());
                                break;
                            case OPERATE_EDIT_CABLE_LIB:
                                item.CheckState = ConvertDec2State(dr["CableLib_edit"].ToString());
                                break;
                            //case OPERATE_EDIT_CONNECTOR:
                            //    item.CheckState = ConvertDec2State(dr["ConnectorLib_edit"].ToString());
                            //    break;
                            case OPERATE_EDIT_INTER_INFO:
                                item.CheckState = ConvertDec2State(dr["InterfaceLib_edit"].ToString());
                                break;
                            case OPERATE_EDIT_PROJECT:
                                item.CheckState = ConvertDec2State(dr["project_edit"].ToString());
                                break;
                            //case OPERATE_EDIT_SWITCH_STAND:
                            //    item.CheckState = ConvertDec2State(dr["SwitchStandLib_edit"].ToString());
                            //    break;
                            //case OPERATE_EDIT_SWITCH_WEAR:
                            //    item.CheckState = ConvertDec2State(dr["SwitchWearLib_edit"].ToString());
                            //    break;
                            //case OPERATE_EXPORT_CONNECTOR:
                            //    item.CheckState = ConvertDec2State(dr["ConnectorLib_export"].ToString());
                            //    break;
                            case OPERATE_EXPORT_INTER_INFO:
                                item.CheckState = ConvertDec2State(dr["InterfaceLib_export"].ToString());
                                break;
                            case OPERATE_EXPORT_OPERATE_RECORD:
                                item.CheckState = ConvertDec2State(dr["OperatorRecord_export"].ToString());
                                break;
                            //case OPERATE_EXPORT_SWITCH_STAND:
                            //    item.CheckState = ConvertDec2State(dr["SwitchStandLib_export"].ToString());
                            //    break;
                            //case OPERATE_EXPORT_SWITCH_WEAR:
                            //    item.CheckState = ConvertDec2State(dr["SwitchWearLib_export"].ToString());
                            //    break;
                            case OPERATE_EXPORT_TEST_DATA:
                                item.CheckState = ConvertDec2State(dr["HistoryTestData_export"].ToString());
                                break;
                            case OPERATE_EXPORT_CABLE_LIB:
                                item.CheckState = ConvertDec2State(dr["CableLib_export"].ToString());
                                break;
                            case OPERATE_QUERY_CABLE_LIB:
                                item.CheckState = ConvertDec2State(dr["CableLib_query"].ToString());
                                break;
                            //case OPERATE_QUERY_CONNECTOR_LIB:
                            //    item.CheckState = ConvertDec2State(dr["ConnectorLib_query"].ToString());
                            //    break;
                            case OPERATE_QUERY_INTER_INFO:
                                item.CheckState = ConvertDec2State(dr["InterfaceLib_query"].ToString());
                                break;
                            case OPERATE_QUERY_OPERATE_RECORD:
                                item.CheckState = ConvertDec2State(dr["OperatorRecord_query"].ToString());
                                break;
                            case OPERATE_QUERY_PROJECT:
                                item.CheckState = ConvertDec2State(dr["Project_query"].ToString());
                                break;
                            //case OPERATE_QUERY_SWITCH_STAND:
                            //    item.CheckState = ConvertDec2State(dr["SwitchStandLib_query"].ToString());
                            //    break;
                            //case OPERATE_QUERY_SWITCH_WEAR:
                            //    item.CheckState = ConvertDec2State(dr["SwitchWearLib_query"].ToString());
                            //    break;
                            case OPERATE_QUERY_TEST_DATA:
                                item.CheckState = ConvertDec2State(dr["HistoryTestData_query"].ToString());
                                break;
                        }
                    }
                }
            }
        }

        private bool IsExistRoleFuncLimit(string role)
        {
            var count = this.funLimitManager.GetRowCountByWhere($"where UserRole='{role}'");
            if (count > 0)
                return true;
            return false;
        }

        private bool IsExistRoleOperatLimit(string role)
        {
            var count = this.operatLimitManager.GetRowCountByWhere($"where UserRole='{role}'");
            if (count > 0)
                return true;
            return false;
        }

        private string ConvertState2Dec(Telerik.WinControls.Enumerations.ToggleState state)
        {
            if (state == Telerik.WinControls.Enumerations.ToggleState.On)
                return "1";
            else
                return "0";
        }

        private Telerik.WinControls.Enumerations.ToggleState ConvertDec2State(string val)
        {
            if (val == "1")
                return Telerik.WinControls.Enumerations.ToggleState.On;
            else
                return Telerik.WinControls.Enumerations.ToggleState.Off;
        }

        private int GetFuncIDByRole(string role)
        {
            int id;
            var data = this.funLimitManager.GetDataSetByFieldsAndWhere("ID", $"where UserRole='{role}'").Tables[0];
            int.TryParse(data.Rows[0][0].ToString(), out id);
            return id;
        }

        private int GetOperatIDByRole(string role)
        {
            int id;
            var data = this.operatLimitManager.GetDataSetByFieldsAndWhere("ID", $"where UserRole='{role}'").Tables[0];
            int.TryParse(data.Rows[0][0].ToString(), out id);
            return id;
        }
    }
}
