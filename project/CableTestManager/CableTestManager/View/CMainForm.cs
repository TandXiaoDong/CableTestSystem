using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using CableTestManager.DeviceUtils;
using CableTestManager.Business.Implements;
using CableTestManager.Entity;
using CableTestManager.View.VInterface;
using CableTestManager.View.VProject;
using CableTestManager.View.VSelfStydy;
using CableTestManager.View.VEquipment;
using WindowsFormTelerik.ControlCommon;
using CableTestManager.CUserManager;
using CableTestManager.ClientSocket;
using CommonUtils.Logger;
using CommonUtil.CUserManager;
using CommonUtils.ByteHelper;
using System.IO;
using CableTestManager.Properties;
using CableTestManager.Model;
using CableTestManager.ClientSocket.AppBase;
using CableTestManager.Common;
using System.Threading.Tasks;
using System.Threading;

namespace CableTestManager.View
{
    public partial class CMainForm : Telerik.WinControls.UI.RadForm
    {
        #region 常量
        private const string PROJECT_INFO = "工程信息";
        private const string PROJECT_OPEN_TEST = "打开测试";
        private const string PROJECT_CLOSE_TEST = "关闭测试";
        private const string PROJECT_EDIT = "编辑项目";
        private const string WORK_WEAR = "查看工装";
        private const string TEST_CABLE = "被测线束";
        private const string CABLE_DETAIL = "查看线束";
        private const string DEVICE_INFO = "设备信息";
        private const string DEVICE_DETAIL = "查看设备";

        private const string headHexString = "FF FF";
        private const string conductionTestFunCode = "F2 AA";
        private const string shortCircuitTestFunCode = "F3 AA";
        private const string insulateTestFunCode = "F4 AA";
        private const string voltageWithStandardFunCode = "F5 AA";
        private const string selfStudyTestFunCode = "F1 AA";
        private const string probTestFunCode = "F6 AA";
        private const string resetDeviceFunCode = "FA AA";
        #endregion

        private TProjectBasicInfoManager projectInfoManager;
        private THistoryDataDetailManager historyDataDetailManager;
        private THistoryDataBasicManager historyDataInfoManager;
        private TCableTestLibraryManager lineStructLibraryDetailManager;
        private TProjectBasicInfo projectInfo;
        private System.Timers.Timer sysTimer;
        private System.Timers.Timer refreshDataTimer;
        private DevControlCommandTypeEnum devControlCommandType;
        private enum DevControlCommandTypeEnum
        {
            StartDevice,
            StopDevice
        }
        private bool IsConnectServer;
        
        //当前测试项目的测试项的异常数
        private int conductTestExceptCount;
        private int shortCircuitTestExceptCount;
        private int insulateTestExceptCount;
        private int voltageWithStandardTestExceptCount;

        /// <summary>
        /// 项目测试序列，每次启动测试便生成一个新序列
        /// </summary>
        private string projectTestNumber = "";
        private string testStartDate  = "";
        private string testEndDate = "";

        /// <summary>
        /// 项目测试序列长度，超过最大长度会自动延长
        /// </summary>
        private int projectTestNumberLen = 8;
        private string configPath;
        private string curLineCableName;
        private Queue<SelfStudyParams> studyParamQueue;
        private Queue<SelfStudyParams> probParamQueue = new Queue<SelfStudyParams>();
        private List<SelfStudyParams> studyParamValidList;//有效数据导入到线束库
        private Queue<CableTestParams> cableTestPramsQueue;
        private DataTable dataSourceSelfStudy,dataSourceCableTest, dataSourceInsulateTest, dataSourceProb;
        private bool IsFirstSetGridDTStyle, IsFirstSetGridUnDTStyle, IsFirstSetGridOpenCirStyle;
        private bool IsFirstSetGridDTProbStyle, IsFirstSetGridUnDTProbStyle, IsFirstSetGridOpenCirProbStyle;
        private CableTestProcess cableTestProcessOneKey;//一键测试对象
        private CableTestProcessParams cableTestProcessSig;//单项测试对象
        private Queue<CableTestProcessParams.CableTestType> cableTestProcessQueue;
        private List<string> testItemStyleList = new List<string>();
        private List<CableLibParams> cableLibParamList = new List<CableLibParams>();

        private ProbTestConfig probConfig = new ProbTestConfig();
        private SelfStudyConfig studyConfig = new SelfStudyConfig();
        private bool IsShowToolWin = true;
        private bool IsShowProStatus;
        private bool IsShowSysStatus;
        private bool IsCalTestDataCompleted;
        private DeviceConfig deviceConfig;
        //private RadGridView radGridViewSelfStudy;
        private bool IsSelfProcessReset = false;//自学习短路过多时，设备复位
        private bool IsFirstConnectDevice = true;
        private bool IsFirstInsulateTest = true;
        private List<string> curTestGridViewOrderList;

        public CMainForm()
        {
            InitializeComponent();
        }

        private void CMainForm_Load(object sender, EventArgs e)
        {
            InitUserAccess();
        }

        private void InitUserAccess()
        {
            FuncLimitManager funLimitManager = new FuncLimitManager();
            if (LocalLogin.currentUserType != "管理员")
            {
                //limit default user manage
                this.menu_userManager.Visibility = ElementVisibility.Collapsed;
                this.menu_roleManager.Visibility = ElementVisibility.Collapsed;
                this.menu_authorManager.Visibility = ElementVisibility.Collapsed;
                this.menu_operateLog.Visibility = ElementVisibility.Collapsed;
                var data = funLimitManager.GetDataSetByWhere($"where UserRole='{LocalLogin.currentUserType}'").Tables[0];
                if (data.Rows.Count > 0)
                {
                    foreach (DataRow dr in data.Rows)
                    {
                        this.tool_InterfaceLibrary.Visible = ConvertDec2State(dr["InterfaceLib"].ToString());
                        this.toolSeparatorInterLib.Visible = ConvertDec2State(dr["InterfaceLib"].ToString());
                        this.menu_interfaceLibrary.Visibility = ConvertDec2EleVisState(dr["InterfaceLib"].ToString());

                        this.tool_HarnessLibrary.Visible = ConvertDec2State(dr["CableLib"].ToString());
                        this.toolSeparatorCableLib.Visible = ConvertDec2State(dr["CableLib"].ToString());
                        this.menu_cableLibrary.Visibility = ConvertDec2EleVisState(dr["CableLib"].ToString());

                        this.menu_shortCircuitTest.Visibility = ConvertDec2EleVisState(dr["ShortCircuitTest"].ToString());
                        this.menu_ConductionTest.Visibility = ConvertDec2EleVisState(dr["ConductTest"].ToString());
                        this.menu_connectorLibrary.Visibility = ConvertDec2EleVisState(dr["ConnectorLib"].ToString());
                        this.menu_devCalibration.Visibility = ConvertDec2EleVisState(dr["DeviceCalibration"].ToString());
                        this.menu_devSelfCheck.Visibility = ConvertDec2EleVisState(dr["DeviceSelfCheck"].ToString());
                        this.menu_devDebugAssitant.Visibility = ConvertDec2EleVisState(dr["DeviceDebug"].ToString());
                        this.menu_devSelfCheck.Visibility = ConvertDec2EleVisState(dr["DeviceSelfCheck"].ToString());
                        this.tool_testEnvironment.Visibility = ConvertDec2EleVisState(dr["EnvironmentalParameters"].ToString());
                        this.menu_ExportReport.Visibility = ConvertDec2EleVisState(dr["ExcuteReport"].ToString());
                        this.menu_faultCode.Visibility = ConvertDec2EleVisState(dr["DeviceFaultQuery"].ToString());
                        this.menu_InsulationTest.Visibility = ConvertDec2EleVisState(dr["InsulateTest"].ToString());
                        
                        this.tool_NewProject.Visible = ConvertDec2State(dr["NewProject"].ToString());
                        this.toolSeparatorNewPro.Visible = ConvertDec2State(dr["NewProject"].ToString());
                        this.menu_newProject.Visibility = ConvertDec2EleVisState(dr["NewProject"].ToString());

                        this.menu_OneKeyTest.Visibility = ConvertDec2EleVisState(dr["OneKeyTest"].ToString());
                        this.menu_PrintReport.Visibility = ConvertDec2EleVisState(dr["PrintReport"].ToString());
                        
                        this.tool_Probe.Visible = ConvertDec2State(dr["Probe"].ToString());
                        this.toolSeparatorProb.Visible = ConvertDec2State(dr["Probe"].ToString());

                        this.tool_OpenProject.Visible = ConvertDec2State(dr["ProjectManage"].ToString());
                        this.toolSeparatorOpenPro.Visible = ConvertDec2State(dr["ProjectManage"].ToString());
                        if (!this.tool_OpenProject.Visible)
                        {
                            this.radTreeView1.Nodes.Clear();
                        }

                        this.tool_reportSavePath.Visibility = ConvertDec2EleVisState(dr["ReportConfigPath"].ToString());
                        this.menu_ResistanceCompensationManage.Visibility = ConvertDec2EleVisState(dr["ResistanceCompensationManage"].ToString());
                        this.menu_SaveData.Visibility = ConvertDec2EleVisState(dr["SaveTestData"].ToString());
                        this.tool_SelfStudy.Visible = ConvertDec2State(dr["SelfStudy"].ToString());
                        this.toolSeparatorSelfStudy.Visible = ConvertDec2State(dr["SelfStudy"].ToString());

                        this.menu_StartResistanceCompensation.Visibility = ConvertDec2EleVisState(dr["StartResistanceCompensation"].ToString());
                        this.menu_switchStandMapLib.Visibility = ConvertDec2EleVisState(dr["SwitchStandLib"].ToString());
                        this.menu_switchWorkWearLib.Visibility = ConvertDec2EleVisState(dr["SwitchWearLib"].ToString());
                        this.tool_HistoryData.Visible = ConvertDec2State(dr["HistoryTestData"].ToString());
                        this.toolSeparatorHisData.Visible = ConvertDec2State(dr["HistoryTestData"].ToString());

                        this.menu_historyData.Visibility = ConvertDec2EleVisState(dr["HistoryTestData"].ToString()); 
                    }
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

        private ElementVisibility ConvertDec2EleVisState(string val)
        {
            if (val == "1")
                return ElementVisibility.Visible;
            else
                return ElementVisibility.Collapsed;
        }

        public void Init()
        {
            this.lbx_curLoginUser.Text = "";
            this.lbx_conDevStatus.Text = "未连接";
            this.lbx_serviceURL.Text = "";
            this.lbx_servicePort.Text = "";
            this.lbx_monitorDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //this.StartPosition = FormStartPosition.CenterScreen;
            //this.WindowState = FormWindowState.Maximized;
            //this.radDock1.DocumentTabsVisible = false;
            this.radDock1.RemoveAllDocumentWindows();
            InitDatable(false);
            InitDatable(true);
            //this.radGridViewSelfStudy = new DoubleBufferListView();
            this.radGridViewSelfStudy.DoubleBuffered(true);
            //this.panelSelf.Controls.Add(this.radGridViewSelfStudy);
            //this.radGridViewSelfStudy.Dock = DockStyle.Fill;

            this.curTestGridViewOrderList = new List<string>();
            this.deviceConfig = new DeviceConfig();
            this.cableTestProcessOneKey = new CableTestProcess();
            this.cableTestProcessSig = new CableTestProcessParams();
            this.cableTestProcessQueue = new Queue<CableTestProcessParams.CableTestType>();
            this.studyParamQueue = new Queue<SelfStudyParams>();
            this.studyParamValidList = new List<SelfStudyParams>();
            this.cableTestPramsQueue = new Queue<CableTestParams>();
            this.projectInfoManager = new TProjectBasicInfoManager();
            this.historyDataInfoManager = new THistoryDataBasicManager();
            this.historyDataDetailManager = new THistoryDataDetailManager();
            this.lineStructLibraryDetailManager = new TCableTestLibraryManager();

            this.refreshDataTimer = new System.Timers.Timer();
            this.refreshDataTimer.Interval = 300;
            this.refreshDataTimer.AutoReset = true;
            this.refreshDataTimer.Enabled = true;

            this.projectInfo = new TProjectBasicInfo();
            this.sysTimer = new System.Timers.Timer();
            this.sysTimer.Start();

            #region update control status
            this.menu_InsulationTest.Enabled = true;
            this.menu_shortCircuitTest.Enabled = true;
            this.menu_VoltageWithStandTest.Enabled = true;
            #endregion

            this.configPath = AppDomain.CurrentDomain.BaseDirectory + "config\\";
            if (!Directory.Exists(configPath))
                Directory.CreateDirectory(configPath);
            this.lbx_curLoginUser.Text = LocalLogin.currentUserName;
            DeviceConfigParams.InitDefaultConfig(this.deviceConfig, configPath);
            if (this.deviceConfig.CompensateState == "1")
            {
                menu_StartResistanceCompensation.Image = Resources.勾选16;
            }
            else
            {
                menu_StartResistanceCompensation.Image = null;
            }
            UpdateTreeView("");
            EventHandles();
        }

        private void InitDatable(bool IsSelfStudy)
        {
            if (IsSelfStudy)
            {
                if (this.radGridViewSelfStudy.Columns.Count > 0)
                    return;
                this.dataSourceSelfStudy = new DataTable();
                this.dataSourceSelfStudy.Columns.Add("序号");
                this.dataSourceSelfStudy.Columns.Add("起点接点");
                this.dataSourceSelfStudy.Columns.Add("终点接点");
                this.dataSourceSelfStudy.Columns.Add("测量值(Ω)");
                this.dataSourceSelfStudy.Columns.Add("测量结果");
                this.radGridViewSelfStudy.DataSource = this.dataSourceSelfStudy;
                RadGridViewProperties.SetRadGridViewProperty(this.radGridViewSelfStudy,false,true,5);
            }
            else
            {
                if (this.radGridViewCableTest.Columns.Count > 0)
                    return;
                this.dataSourceCableTest = new DataTable();
                this.dataSourceCableTest.Columns.Add("序号");
                this.dataSourceCableTest.Columns.Add("起点接口");
                this.dataSourceCableTest.Columns.Add("起点接点");
                this.dataSourceCableTest.Columns.Add("终点接口");
                this.dataSourceCableTest.Columns.Add("终点接点");
                this.dataSourceCableTest.Columns.Add("导通电阻(Ω)");
                this.dataSourceCableTest.Columns.Add("导通测试结果");
                this.dataSourceCableTest.Columns.Add("短路测试(Ω)");
                this.dataSourceCableTest.Columns.Add("短路测试结果");
                this.dataSourceCableTest.Columns.Add("绝缘电阻(Ω)");
                this.dataSourceCableTest.Columns.Add("绝缘测试结果");
                this.dataSourceCableTest.Columns.Add("耐压电流(Ω)");
                this.dataSourceCableTest.Columns.Add("耐压测试结果");
                this.dataSourceCableTest.Columns.Add("testMethod");

                this.dataSourceInsulateTest = this.dataSourceCableTest.Clone();
                this.radGridViewCableTest.DataSource = this.dataSourceCableTest;
                this.radGridViewCableTest.Columns[11].IsVisible = false;
                this.radGridViewCableTest.Columns[12].IsVisible = false;
                this.radGridViewCableTest.Columns[13].IsVisible = false;
                RadGridViewProperties.SetRadGridViewProperty(this.radGridViewCableTest, false, true, 0);
                this.radGridViewCableTest.Columns[0].BestFit();
            }
        }

        private void InitProbTable()
        {
            this.dataSourceProb = new DataTable();
            this.dataSourceProb.Columns.Add("序号");
            this.dataSourceProb.Columns.Add("针脚");
            this.dataSourceProb.Columns.Add("测量值(Ω)");
            this.dataSourceProb.Columns.Add("测量结果");
            this.radGridViewProb.DataSource = this.dataSourceProb;
            RadGridViewProperties.SetRadGridViewProperty(this.radGridViewProb, false, true, 4);
        }

        private void EventHandles()
        {
            #region tool event
            this.tool_InterfaceLibrary.Click += Tool_InterfaceLibrary_Click;
            this.tool_HarnessLibrary.Click += Tool_HarnessLibrary_Click;
            this.tool_NewProject.Click += Tool_NewProject_Click;
            this.tool_OpenProject.Click += Tool_OpenProject_Click;
            this.tool_HistoryData.Click += Tool_HistoryData_Click;
            this.tool_ConnectDevice.Click += Tool_ConnectDevice_Click;
            this.tool_SelfStudy.Click += Tool_SelfStudy_Click;
            this.tool_Probe.Click += Tool_Probe_Click;
            this.tool_testEnvironment.Click += Tool_testEnvironment_Click;
            this.tool_clearSelfGrid.Click += Tool_clearSelfGrid_Click;
            this.tool_importCableLib.Click += Tool_importCableLib_Click;
            this.tool_reportSavePath.Click += Tool_reportSavePath_Click;
            this.tool_stop.Click += Tool_stop_Click;
            this.tool_reportDefaultFormat.Click += Tool_reportDefaultFormat_Click; ;
            #endregion

            #region menu event
            this.menu_abort.Click += Menu_abort_Click;
            this.menu_helper.Click += Menu_helper_Click;
            this.menu_showToolWin.Click += Menu_showToolWin_Click;
            this.menu_showSysStatus.Click += Menu_showSysStatus_Click;
            this.menu_showProStatus.Click += Menu_showProStatus_Click;
            this.menu_roleManager.Click += Menu_roleManager_Click;
            this.menu_authorManager.Click += Menu_authorManager_Click;
            this.menu_connectServer.Click += Menu_connectServer_Click;
            this.menu_disConnect.Click += Menu_disConnect_Click;
            this.menu_SaveData.Click += Menu_SaveData_Click;
            this.menu_connectorLibrary.Click += Menu_connectorLibrary_Click;
            this.menu_interfaceLibrary.Click += Menu_interfaceLibrary_Click;
            this.menu_cableLibrary.Click += Menu_cableLibrary_Click;
            this.menu_switchStandMapLib.Click += Menu_switchStandMapLib_Click;
            this.menu_switchWorkWearLib.Click += Menu_switchWorkWearLib_Click;
            this.menu_modifyPassword.Click += Menu_modifyPassword_Click;
            this.menu_operateLog.Click += Menu_operateLog_Click;
            this.menu_userManager.Click += Menu_userManager_Click;
            this.menu_connectCfg.Click += Menu_connectCfg_Click;
            this.menu_ConductionTest.Click += Menu_ConductionTest_Click;
            this.menu_shortCircuitTest.Click += Menu_shortCircuitTest_Click;
            this.menu_InsulationTest.Click += Menu_InsulationTest_Click;
            this.menu_VoltageWithStandTest.Click += Menu_VoltageWithStandTest_Click;
            this.menu_OneKeyTest.Click += Menu_OneKeyTest_Click;
            this.menu_devCalibration.Click += Menu_devCalibration_Click;
            this.menu_devDebugAssitant.Click += Menu_devDebugAssitant_Click;
            this.menu_devSelfCheck.Click += Menu_devSelfCheck_Click;
            this.menu_faultCode.Click += Menu_faultCode_Click;
            this.menu_historyData.Click += Menu_historyData_Click;
            this.menu_PrintReport.Click += Menu_PrintReport_Click;
            this.menu_ExportReport.Click += Menu_ExportReport_Click;
            this.menu_newProject.Click += Menu_newProject_Click;
            this.menu_closeProject.Click += Menu_closeProject_Click;
            this.menu_appExit.Click += Menu_appExit_Click;
            this.menu_switchUser.Click += Menu_switchUser_Click;
            this.menu_ResistanceCompensationManage.Click += Menu_ResistanceCompensationManage_Click;
            this.menu_StartResistanceCompensation.Click += Menu_StartResistanceCompensation_Click;
            #endregion

            this.FormClosed += CMainForm_FormClosed;
            this.radTreeView1.NodeMouseDoubleClick += RadTreeView1_NodeMouseDoubleClick;
            this.sysTimer.Elapsed += SysTimer_Elapsed;
            this.SizeChanged += CMainForm_SizeChanged;
            this.refreshDataTimer.Elapsed += RefreshDataTimer_Elapsed;
            this.radDock1.DockStateChanged += RadDock1_DockStateChanged;

            SuperEasyClient.NoticeConnectEvent += SuperEasyClient_NoticeConnectEvent;
            SuperEasyClient.NoticeMessageEvent += SuperEasyClient_NoticeMessageEvent;
        }

        private void Tool_reportDefaultFormat_Click(object sender, EventArgs e)
        {
            ReportFormatSet reportFormatSet = new ReportFormatSet(this.deviceConfig);
            if (reportFormatSet.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void Menu_helper_Click(object sender, EventArgs e)
        {
            var fileName = "预埋线缆综合测试仪_说明书.doc";
            var helperFile = AppDomain.CurrentDomain.BaseDirectory + $"temp\\{fileName}";
            if (File.Exists(helperFile))
            {
                System.Diagnostics.Process.Start(helperFile);
            }
            else
            {
                helperFile = AppDomain.CurrentDomain.BaseDirectory + "temp\\";
                DirectoryInfo directoryInfo = new DirectoryInfo(helperFile);
                FileInfo[] fileInfos = directoryInfo.GetFiles();
                if (fileInfos.Length > 0)
                {
                    if (File.Exists(fileInfos[0].FullName))
                    {
                        File.Move(fileInfos[0].FullName, helperFile + fileName);
                        if (File.Exists(helperFile + fileName))
                        {
                            System.Diagnostics.Process.Start(helperFile + fileName);
                        }
                    }
                }
            }
        }

        private void Menu_abort_Click(object sender, EventArgs e)
        {
            Helper helper = new Helper();
            helper.Show();
        }

        private void CMainForm_SizeChanged(object sender, EventArgs e)
        {
            this.lbx_testStatus.Location = new Point(this.panelStatus.Width / 2 - this.lbx_testStatus.Width / 2);
        }

        private void Tool_stop_Click(object sender, EventArgs e)
        {
            SendResetDeviceCommand();
        }

        private void RadDock1_DockStateChanged(object sender, Telerik.WinControls.UI.Docking.DockWindowEventArgs e)
        {
            if (toolWindow1.DockState == Telerik.WinControls.UI.Docking.DockState.Hidden)
            {
                if(this.IsShowToolWin)
                {
                    //手动关闭tool
                    this.IsShowToolWin = false;
                    this.menu_showToolWin.Image = null;
                }
            }
        }

        private void Menu_showProStatus_Click(object sender, EventArgs e)
        {
            if (!IsShowProStatus)
            {
                this.menu_showProStatus.Image = null;
                this.status_project.Visible = false;
            }
            else
            {
                this.menu_showProStatus.Image = Resources.勾选16;
                this.status_project.Visible = true;
            }
            this.IsShowProStatus = !this.IsShowProStatus;
        }

        private void Menu_showSysStatus_Click(object sender, EventArgs e)
        {
            if (!this.IsShowSysStatus)
            {
                this.menu_showSysStatus.Image = null;
                this.status_sys.Visible = false;
            }
            else
            {
                this.menu_showSysStatus.Image = Resources.勾选16;
                this.status_sys.Visible = true;
            }
            this.IsShowSysStatus = !this.IsShowSysStatus;
        }

        private void Menu_showToolWin_Click(object sender, EventArgs e)
        {
            if (IsShowToolWin)
            {
                this.menu_showToolWin.Image = null;
                this.IsShowToolWin = false;
                this.toolWindow1.Close();
            }
            else
            {
                this.menu_showToolWin.Image = Resources.勾选16;
                this.IsShowToolWin = true;
                this.toolWindow1.Show();
            }
        }

        private void Menu_StartResistanceCompensation_Click(object sender, EventArgs e)
        {
            CompensateChanged();
        }

        private void CompensateChanged()
        {
            if (this.deviceConfig.CompensateState == "1")
            {
                this.deviceConfig.CompensateState = "0";
                this.menu_StartResistanceCompensation.Image = null;
            }
            else
            {
                this.deviceConfig.CompensateState = "1";
                this.menu_StartResistanceCompensation.Image = Resources.勾选16;
            }
        }

        private void Menu_ResistanceCompensationManage_Click(object sender, EventArgs e)
        {
            ResistanceManage resistanceManage = new ResistanceManage(this.projectInfo, this.deviceConfig);
            if (resistanceManage.ShowDialog() == DialogResult.OK)
            {
                UpdateCurProjectInfo();
            }
        }

        private void UpdateCurProjectInfo()
        {
            if (String.IsNullOrEmpty(this.projectInfo.ProjectName) || this.projectInfo.ProjectName == "")
                return;
            this.projectInfo.ID = GetProjectInfoID(projectInfo.ProjectName);
            var res = this.projectInfoManager.Update(this.projectInfo);
        }

        private int GetProjectInfoID(string projectName)
        {
            var dt = projectInfoManager.GetDataSetByFieldsAndWhere("ID", $"where ProjectName='{projectName}'").Tables[0];
            if (dt.Rows.Count > 0)
                return int.Parse(dt.Rows[0][0].ToString());
            return 0;
        }

        private void Tool_reportSavePath_Click(object sender, EventArgs e)
        {
            SetDefaultSavePath setDefaultSavePath = new SetDefaultSavePath(this.deviceConfig.ReportDirectory);
            if (setDefaultSavePath.ShowDialog() == DialogResult.OK)
            {
                this.deviceConfig.ReportDirectory = setDefaultSavePath.reportDir;
            }
        }

        private void Menu_switchUser_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread.Sleep(100);
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "CableTestManager.exe");
        }

        private void Menu_appExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Menu_closeProject_Click(object sender, EventArgs e)
        {
            this.radDock1.RemoveWindow(this.documentWindow1);
            UpdateCloseProState();
        }

        private void Menu_newProject_Click(object sender, EventArgs e)
        {
            NewProject();
        }

        private void Menu_ExportReport_Click(object sender, EventArgs e)
        {
            if (this.radGridViewCableTest.RowCount <= 0)
                return;
            ExportReport();
        }

      
        private void Menu_PrintReport_Click(object sender, EventArgs e)
        {
            if (this.radGridViewCableTest.RowCount <= 0)
                return;
            PrintReport();
        }

        private async void ExportReport()
        {
            await Task.Run(() =>
            {
                SaveTestResult();
            });
            TestReportInfo.ExportReport(this.deviceConfig.ReportDirectory, this.projectTestNumber, this.deviceConfig);
        }

        private async void PrintReport()
        {
            await Task.Run(() =>
            {
                SaveTestResult();
            });
            TestReportInfo.PrintReport(this.deviceConfig.ReportDirectory, this.projectTestNumber, this.deviceConfig);
        }


        private void Menu_roleManager_Click(object sender, EventArgs e)
        {
            RoleManager roleManager = new RoleManager();
            roleManager.ShowDialog();
        }

        private void Menu_authorManager_Click(object sender, EventArgs e)
        {
            LimmitManager limmitManager = new LimmitManager();
            limmitManager.ShowDialog();
        }

        private void Tool_importCableLib_Click(object sender, EventArgs e)
        {
            if (this.radGridViewSelfStudy.RowCount < 1)
            {
                MessageBox.Show("没有可以导入的数据！","提示",MessageBoxButtons.OK);
                return;
            }
            ImportCableLibrary importCableLibrary = new ImportCableLibrary();
            if (importCableLibrary.ShowDialog() == DialogResult.OK)
            {
                List<TCableTestLibrary> cableLibList = new List<TCableTestLibrary>();
                int row = 0;
                foreach (var rowInfo in this.studyParamValidList)
                {
                    if (rowInfo.TestReulst == "不导通")
                        continue;
                    else if (rowInfo.TestReulst == "导通")
                    {
                        TCableTestLibrary cableTestLibrary = new TCableTestLibrary();
                        cableTestLibrary.ID = CableTestManager.Common.TablePrimaryKey.InsertCableLibPID() + row;
                        cableTestLibrary.CableName = importCableLibrary.cableLibName;
                        cableTestLibrary.MeasureMethod = importCableLibrary.testMethod + "";
                        int startPoint, endPoint;
                        if (!int.TryParse(rowInfo.StartPointOrder, out startPoint))
                            continue;
                        if(!int.TryParse(rowInfo.EndPointOrder, out endPoint))
                            continue;

                        cableTestLibrary.StartInterface = rowInfo.StartInterfaceName;
                        cableTestLibrary.StartContactPoint = startPoint.ToString();
                        cableTestLibrary.StartDevPoint = GetDevPointByOrderPoint(rowInfo.StartInterfaceName, startPoint.ToString());
                        cableTestLibrary.EndInterface = rowInfo.EndInterfaceName;
                        cableTestLibrary.EndDevPoint = GetDevPointByOrderPoint(rowInfo.EndInterfaceName, endPoint.ToString());
                        cableTestLibrary.EndContactPoint = endPoint.ToString();
                        cableTestLibrary.UpdateDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        cableLibList.Add(cableTestLibrary);
                        row++;
                    }
                }
                var iRow = this.lineStructLibraryDetailManager.Insert(cableLibList);
                if (iRow > 0)
                {
                    MessageBox.Show($"导入完成，总共导入{iRow}组芯线数量", "提示", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show($"没有可导入的有效接点！", "提示", MessageBoxButtons.OK);
                }
            }
        }

        private void Tool_clearSelfGrid_Click(object sender, EventArgs e)
        {
            ClearSelfGrid();
        }

        private void ClearSelfGrid()
        {
            this.dataSourceSelfStudy.Rows.Clear();
            this.radGridViewSelfStudy.DataSource = this.dataSourceSelfStudy;
            this.studyParamValidList.Clear();
            this.tb_selfStudyTip.Clear();
            this.tb_selfStudyTip.Visible = false;
        }

        private void ClearProbGrid()
        {
            this.dataSourceProb.Rows.Clear();
            this.radGridViewProb.DataSource = this.dataSourceProb;
            this.tb_probTip.Clear();
            this.tb_probTip.Visible = false;
        }

        private void RefreshDataTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdateTestSelfStudyGridView();
            UpdateProbTestGridView();
            UpdateTestResultByTestPoint();
        }

        private void Tool_testEnvironment_Click(object sender, EventArgs e)
        {
            OpenEnvironmentParamsSet();
        }

        private bool OpenEnvironmentParamsSet()
        {
            FrmEnvironmentParams environmentParaSet = new FrmEnvironmentParams(this.projectInfo, this.deviceConfig);
            if (environmentParaSet.ShowDialog() == DialogResult.OK)
            {
                //update
                UpdateCurProjectInfo();
                return true;
            }
            return false;
        }

        #region system event
        private void SysTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.lbx_monitorDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private bool IsConnectSuccess()
        {
            if (!this.IsConnectServer)
            {
                LogHelper.Log.Info("设备未连接...................");
                MessageBox.Show("设备未连接！", "提示", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void CMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeviceConfigParams.SaveDeviceConfig(this.deviceConfig);
        }

        private void SuperEasyClient_NoticeMessageEvent(ClientSocket.AppBase.MyPackageInfo packageInfo)
        {
            //LogHelper.Log.Info($"接收到消息00:"+BitConverter.ToString(packageInfo.Data));
            //测试结果根据阈值判断是否合格
            //导通测试：小于阈值为合格
            //短路测试：大于阈值为合格
            //绝缘测试：大于阈值为合格
            //耐压测试：小于阈值为合格
              
            //接收消息
            var dataLength = packageInfo.Data.Length;
            //导通测试成功后，更新UI，并开始测试下一个
            //收到f2 cc
            if (packageInfo.Header.Length < 4 || packageInfo.Data.Length < 4)
                return;
            if (packageInfo.Data[0] != 0xff || packageInfo.Data[1] != 0xff)
            {
                return;
            }
            //返回数据格式为功能码 + 方法类型 + 接点内容 + 测试结果
            if (packageInfo.Data[4] == 0xf1 && packageInfo.Data[5] == 0xbb)//自学习
            {
                SelfStudyTestProcess(packageInfo);
            }
            else if (packageInfo.Data[4] == 0xf1 && packageInfo.Data[5] == 0xcc)//自学习结束
            {
                //this.refreshDataTimer.Enabled = false;
                //var rowCount = this.radGridViewSelfStudy.RowCount;
                //if (rowCount <= 0)
                //    return;
                //this.radGridViewSelfStudy.CurrentRow = this.radGridViewSelfStudy.Rows[rowCount - 1];
                SelfStudyTextState(true, "自学习测试已完成");
            }
            else if (packageInfo.Data[4] == 0xf6 && packageInfo.Data[5] == 0xbb)//探针
            {
                ProbTestProcess(packageInfo);
            }
            else if (packageInfo.Data[4] == 0xf6 && packageInfo.Data[5] == 0xcc)//探针结束
            {
                //this.refreshDataTimer.Enabled = false;
                ProbTestTextState(true, "探针测试已完成");
            }
            else if (packageInfo.Data[4] == 0xf2 && packageInfo.Data[5] == 0xbb)//导通测试
            {
                TestItemProcess(packageInfo, 5, this.projectInfo.ConductTestThreshold, this.projectInfo.ResistanceCompensation);
            }
            else if (packageInfo.Data[4] == 0xf2 && packageInfo.Data[5] == 0xcc)//导通测试结束
            {
                //保存测试状态与结果数据
                //更新UI最终测试结果
                //检查是否进行下一项测试
                TestItemComplete(CableTestProcessParams.CableTestType.ConductTest, this.cableTestProcessSig.CableTestTypeEnum);
            }
            else if (packageInfo.Data[4] == 0xf3 && packageInfo.Data[5] == 0xbb)//短路测试测试
            {
                TestItemProcess(packageInfo, 7, this.projectInfo.ShortCircuitTestThreshold, this.projectInfo.ResistanceCompensation);
            }
            else if (packageInfo.Data[4] == 0xf3 && packageInfo.Data[5] == 0xcc)//短路测试结束
            {
                TestItemComplete(CableTestProcessParams.CableTestType.ShortCircuitTest, this.cableTestProcessSig.CableTestTypeEnum);
            }
            else if (packageInfo.Data[4] == 0xf4 && packageInfo.Data[5] == 0xbb)//绝缘测试
            {
                TestItemProcess(packageInfo, 9, this.projectInfo.InsulateTestThreshold * 1000000, this.projectInfo.InsulateResCompensation);
            }
            else if (packageInfo.Data[4] == 0xf4 && packageInfo.Data[5] == 0xcc)//绝缘测试结束
            {
                TestItemComplete(CableTestProcessParams.CableTestType.InsulateTest, this.cableTestProcessSig.CableTestTypeEnum);
            }
            else if (packageInfo.Data[4] == 0xf5 && packageInfo.Data[5] == 0xbb)//耐压测试测试
            {
                TestItemProcess(packageInfo, 11, this.projectInfo.VoltageWithStandardThreshold, this.projectInfo.ResistanceCompensation);
            }
            else if (packageInfo.Data[4] == 0xf5 && packageInfo.Data[5] == 0xcc)//耐压测试测试结束
            {
                TestItemComplete(CableTestProcessParams.CableTestType.PressureWithVoltageTest, this.cableTestProcessSig.CableTestTypeEnum);
            }
            else if (packageInfo.Data[4] == 0xfb && packageInfo.Data[5] == 0xcc)//设备自检
            {
                SelfCheckTestProcess(packageInfo);
            }
        }

        private void SelfCheckTestProcess(MyPackageInfo packageInfo)
        {
            var baseNum = DecConvert2Hex(packageInfo.Data[10]);
            var power = (int)packageInfo.Data[11];
            byte[] buffer = new byte[4];
            Array.Copy(packageInfo.Data, 12, buffer, 0, 4);
            var resistanceVal = Convert.ToUInt32(BitConverter.ToString(buffer).Replace("-", ""), 16);
            var resistance = resistanceVal / 65536.0;
            double factor = 0;
            if (baseNum == "00")
            {
                double.TryParse(Convert.ToString((int)packageInfo.Data[11], 16).Substring(0, 1), out factor);
            }
            else if (baseNum == "01")
            {
                factor = 10 * Math.Pow(10, power);
            }
            var calResult = resistance * factor;
            var devSelfCheckThreshold = SelfCheckParams.GetSelfCheckParams();
            var min = devSelfCheckThreshold - (devSelfCheckThreshold * 0.1);
            var max = devSelfCheckThreshold + (devSelfCheckThreshold * 0.1);

            if (calResult >= min && calResult <= max)
            {
                //LogHelper.Log.Info($"设备自检结果：自检结果在500正负10%范围内 val={calResult}");
            }
            else
            {
                //LogHelper.Log.Info("设备自检结果：自检结果不在500正负10%范围内");
                SendResetDeviceCommand();
            }
        }

        private void TestItemProcess(MyPackageInfo packageInfo, int startIndex,double thresholdVal, double resComVal)
        {
            //02-00-01-00-05-00-00-00-02
            var startInterPoint = DecConvert2Hex(packageInfo.Data[6]) + DecConvert2Hex(packageInfo.Data[7]);
            var endInterPoint = DecConvert2Hex(packageInfo.Data[8]) + DecConvert2Hex(packageInfo.Data[9]);
            var baseNum = DecConvert2Hex(packageInfo.Data[10]);
            var power = (int)packageInfo.Data[11];
            byte[] buffer = new byte[4];
            Array.Copy(packageInfo.Data, 12, buffer, 0, 4);
            var resistanceVal = Convert.ToUInt32(BitConverter.ToString(buffer).Replace("-", ""), 16);
            var resistance = resistanceVal / 65536.0;
            double factor = 0;
            if (baseNum == "00")
            {
                double.TryParse(Convert.ToString((int)packageInfo.Data[11], 16).Substring(0, 1), out factor);
            }
            else if (baseNum == "01")
            {
                factor = 10 * Math.Pow(10, power);
            }
            var calResult = (resistance * factor);
            if (this.deviceConfig.CompensateState == "1")
            {
                calResult += resComVal;
            }
            if (calResult < 0)
            {
                calResult = GetRanDouble();
            }
            var conductResult = "";
            if (startIndex == 7 || startIndex == 9)//短路与绝缘
            {
                if (calResult > thresholdVal)
                    conductResult = "合格";
                else
                    conductResult = "不合格";
            }
            else//导通
            {
                if (calResult < thresholdVal)
                    conductResult = "合格";
                else
                    conductResult = "不合格";
            }
            CableTestParams cableTestParams = new CableTestParams();
            cableTestParams.StartPoint = Convert.ToInt32(startInterPoint, 16).ToString();
            cableTestParams.EndPoint = Convert.ToInt32(endInterPoint, 16).ToString();
            if (startIndex == 7)
            {
                if (calResult > 10000)
                {
                    cableTestParams.TestResultVal = ">10000";
                }
                else
                {
                    cableTestParams.TestResultVal = calResult.ToString("f2");
                }
            }
            else
            {
                cableTestParams.TestResultVal = calResult.ToString("f2");
            }

            cableTestParams.TestReulst = conductResult;
            cableTestParams.StartIndex = startIndex;
            this.cableTestPramsQueue.Enqueue(cableTestParams);
        }

        private string DecConvert2Hex(byte b)
        {
            return Convert.ToString(b, 16).PadLeft(2, '0');
        }

        private void SelfStudyTestProcess(MyPackageInfo packageInfo)
        {
            //FF-FF-00-0C-F1-BB-00-01-00-02-01-01-00-00-1A-C9
            //min/max/setthreshold
            var startInterPoint = DecConvert2Hex(packageInfo.Data[6]) + DecConvert2Hex(packageInfo.Data[7]);
            var endInterPoint = DecConvert2Hex(packageInfo.Data[8]) + DecConvert2Hex(packageInfo.Data[9]);
            var baseNum = DecConvert2Hex(packageInfo.Data[10]);
            var power = (int)packageInfo.Data[11];
            byte[] buffer = new byte[4];
            Array.Copy(packageInfo.Data, 12, buffer, 0, 4);
            var resistanceVal = Convert.ToUInt32(BitConverter.ToString(buffer).Replace("-", ""), 16);
            var resistance = resistanceVal / 65536.0;
            double factor = 0;
            if (baseNum == "00")
            {
                double.TryParse(Convert.ToString((int)packageInfo.Data[11], 16).Substring(0, 1), out factor);
            }
            else if (baseNum == "01")
            {
                factor = 10 * Math.Pow(10, power);
            }
            var calResult = (resistance * factor);
            if (this.deviceConfig.CompensateState == "1")
            {
                calResult += this.projectInfo.ResistanceCompensation;
            }
            if (calResult < 0)
            {
                calResult = GetRanDouble();
            }
            var selfStudyResult = "";
            if (calResult < this.studyConfig.TestThresholdVal)
                selfStudyResult = "导通";
            else if (calResult >= this.studyConfig.TestThresholdVal)
            {
                selfStudyResult = "不导通";
                return;
            }
            if (resistanceVal == 0xffffffff)
            {
                selfStudyResult = "开路";
                return;
            }
            //只接收导通的数据
            SelfStudyParams studyParams = new SelfStudyParams();
            studyParams.DevStartPoint = Convert.ToInt32(startInterPoint, 16).ToString();
            studyParams.DevEndPoint = Convert.ToInt32(endInterPoint, 16).ToString();
            if (calResult > 10000)
            {
                studyParams.TestResultVal = ">10000";
            }
            else
            {
                studyParams.TestResultVal = calResult.ToString("f2");
            }
            studyParams.TestReulst = selfStudyResult;
            this.studyParamQueue.Enqueue(studyParams);
        }

        private void ProbTestProcess(MyPackageInfo packageInfo)
        {
            //FF-FF-00-0C-F1-BB-00-01-00-02-01-01-00-00-1A-C9
            //min/max/setthreshold
            var startInterPoint = DecConvert2Hex(packageInfo.Data[6]) + DecConvert2Hex(packageInfo.Data[7]);
            var endInterPoint = DecConvert2Hex(packageInfo.Data[8]) + DecConvert2Hex(packageInfo.Data[9]);
            var baseNum = DecConvert2Hex(packageInfo.Data[10]);
            var power = (int)packageInfo.Data[11];
            byte[] buffer = new byte[4];
            Array.Copy(packageInfo.Data, 12, buffer, 0, 4);
            var resistanceVal = Convert.ToUInt32(BitConverter.ToString(buffer).Replace("-", ""), 16);
            var resistance = resistanceVal / 65536.0;
            double factor = 0;
            if (baseNum == "00")
            {
                double.TryParse(Convert.ToString((int)packageInfo.Data[11], 16).Substring(0, 1), out factor);
            }
            else if (baseNum == "01")
            {
                factor = 10 * Math.Pow(10, power);
            }
            var calResult = (resistance * factor);
            if (this.deviceConfig.CompensateState == "1")
            {
                calResult += this.projectInfo.ResistanceCompensation;
            }
            if (calResult < 0)
            {
                calResult = GetRanDouble();
            }
            var selfStudyResult = "";
            if (calResult < this.probConfig.TestThresholdVal)
                selfStudyResult = "导通";
            else if (calResult >= this.probConfig.TestThresholdVal)
            {
                selfStudyResult = "不导通";
                return;
            }
            if (resistanceVal == 0xffffffff)
            {
                selfStudyResult = "开路";
                return;
            }
            //只接收导通的数据
            SelfStudyParams studyParams = new SelfStudyParams();
            studyParams.DevStartPoint = Convert.ToInt32(startInterPoint, 16).ToString();
            studyParams.DevEndPoint = Convert.ToInt32(endInterPoint, 16).ToString();
            studyParams.TestResultVal = calResult.ToString("f2");
            studyParams.TestReulst = selfStudyResult;
            this.probParamQueue.Enqueue(studyParams);
        }

        private double GetRanDouble()
        {
            var val = new Random().Next(0, 10);
            if (val > 5)
                return 0.01;
            return 0.02;
        }

        private void TestItemComplete(CableTestProcessParams.CableTestType cableTestType, CableTestProcessParams.CableTestType sigTestType)
        {
            //this.refreshDataTimer.Enabled = false;
            if (this.cableTestProcessOneKey.CableTestMethodEnum == CableTestProcess.CableTestMethod.OneKeyTest)
            {
                //更新状态
                this.Invoke(new Action(() =>
                {
                    switch (cableTestType)
                    {
                        case CableTestProcessParams.CableTestType.ConductTest:
                            {
                                IsCheckTestCompleted(CableTestProcessParams.CableTestType.ConductTest, CableTestProcessParams.CableTestType.None, cableTestType);
                            }
                            break;
                        case CableTestProcessParams.CableTestType.ShortCircuitTest:
                            {
                                IsCheckTestCompleted(CableTestProcessParams.CableTestType.ShortCircuitTest, CableTestProcessParams.CableTestType.None, cableTestType);
                            }
                            break;
                        case CableTestProcessParams.CableTestType.InsulateTest:
                            {
                                IsCheckTestCompleted(CableTestProcessParams.CableTestType.InsulateTest, CableTestProcessParams.CableTestType.None, cableTestType);
                            }
                            break;
                        case CableTestProcessParams.CableTestType.PressureWithVoltageTest:
                            {
                                IsCheckTestCompleted(CableTestProcessParams.CableTestType.PressureWithVoltageTest, CableTestProcessParams.CableTestType.None, cableTestType);
                            }
                            break;
                    }
                }));
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    switch (sigTestType)
                    {
                        case CableTestProcessParams.CableTestType.ConductTest:
                            {
                                IsCheckTestCompleted(CableTestProcessParams.CableTestType.None, sigTestType, CableTestProcessParams.CableTestType.None);
                            }
                            break;
                        case CableTestProcessParams.CableTestType.ShortCircuitTest:
                            {
                                IsCheckTestCompleted(CableTestProcessParams.CableTestType.None, sigTestType, CableTestProcessParams.CableTestType.None);
                            }
                            break;
                        case CableTestProcessParams.CableTestType.InsulateTest:
                            {
                                IsCheckTestCompleted(CableTestProcessParams.CableTestType.None, sigTestType, CableTestProcessParams.CableTestType.None);
                            }
                            break;
                        case CableTestProcessParams.CableTestType.PressureWithVoltageTest:
                            {
                                IsCheckTestCompleted(CableTestProcessParams.CableTestType.None, sigTestType, CableTestProcessParams.CableTestType.None);
                            }
                            break;
                    }
                }));
            }
        }

        private async void IsCheckTestCompleted(CableTestProcessParams.CableTestType oneKeyTestType, CableTestProcessParams.CableTestType sigTestType, CableTestProcessParams.CableTestType cableTestType)
        {
            await Task.Run(()=>
            {
                while (true)
                {
                    if (this.IsCalTestDataCompleted)
                    {
                        this.IsCalTestDataCompleted = false;
                        this.IsFirstInsulateTest = false;
                        LogHelper.Log.Info("等待测试完成，退出循环...");
                        break;
                    }
                    Thread.Sleep(1);
                }
            });

            if (this.cableTestProcessOneKey.CableTestMethodEnum == CableTestProcess.CableTestMethod.OneKeyTest)
            {
                switch (oneKeyTestType)
                {
                    case CableTestProcessParams.CableTestType.ConductTest:
                        {
                            if (CheckTestItemResult(6))
                            {
                                //测试完成，可以测试短路
                                this.menu_shortCircuitTest.Enabled = true;
                            }
                            else//不能继续测试短路，结束一键测试
                            {
                                this.cableTestProcessQueue.Clear();
                                this.menu_shortCircuitTest.Enabled = false;
                                this.menu_InsulationTest.Enabled = false;
                                this.menu_VoltageWithStandTest.Enabled = false;
                            }
                            this.menu_ConductionTest.Enabled = true;
                            this.menu_OneKeyTest.Enabled = true;
                            this.lbx_testStatus.Text = "导通测试已完成";
                            this.lbx_testStatus.ForeColor = Color.Red;
                            this.lbx_conductExCount.Text = CalCurExceptCount(6) + "";
                            if (this.cableTestProcessQueue.Count == 0)
                            {
                                var pasCount = CalCurPassCount(6);
                                this.lbx_conRelationCount.Text = pasCount + "";
                                this.testEndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                MessageBox.Show($"测试完成，测试合格芯线数量为{pasCount}条！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        break;
                    case CableTestProcessParams.CableTestType.ShortCircuitTest:
                        {
                            if (CheckTestItemResult(8))
                            {
                                this.menu_InsulationTest.Enabled = true;
                                this.menu_VoltageWithStandTest.Enabled = true;
                            }
                            else//结束一键测试
                            {
                                this.cableTestProcessQueue.Clear();
                                this.menu_InsulationTest.Enabled = false;
                                this.menu_VoltageWithStandTest.Enabled = false;
                            }
                            this.menu_OneKeyTest.Enabled = true;
                            this.menu_ConductionTest.Enabled = true;
                            this.menu_shortCircuitTest.Enabled = true;
                            this.lbx_testStatus.Text = "短路测试已完成";
                            this.lbx_testStatus.ForeColor = Color.Red;
                            this.lbx_shortCircuitExCount.Text = CalCurExceptCount(8) + "";
                            if (this.cableTestProcessQueue.Count == 0)
                            {
                                var pasCount = CalCurCodCircuitPassCount(6, 8);
                                this.lbx_conRelationCount.Text = pasCount + "";
                                this.testEndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                MessageBox.Show($"测试完成，测试合格芯线数量为{pasCount}条！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        break;
                    case CableTestProcessParams.CableTestType.InsulateTest:
                        {
                            this.menu_OneKeyTest.Enabled = true;
                            this.menu_ConductionTest.Enabled = true;
                            this.menu_shortCircuitTest.Enabled = true;
                            this.menu_InsulationTest.Enabled = true;
                            this.menu_VoltageWithStandTest.Enabled = true;
                            this.lbx_testStatus.Text = "绝缘测试已完成";
                            this.lbx_testStatus.ForeColor = Color.Red;
                            this.lbx_insulateExCount.Text = CalCurExceptCount(10) + "";
                            if (this.cableTestProcessQueue.Count == 0)
                            {
                                var pasCount = CalCurCodCircuitInsPassCount(6, 8, 10);
                                this.lbx_conRelationCount.Text = pasCount + "";
                                this.testEndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                MessageBox.Show($"测试完成，测试合格芯线数量为{pasCount}条！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        break;
                    case CableTestProcessParams.CableTestType.PressureWithVoltageTest:
                        {
                            if (this.cableTestProcessQueue.Count <= 0)//所有测试完成
                            {
                                this.menu_OneKeyTest.Enabled = true;
                            }
                            this.menu_ConductionTest.Enabled = true;
                            this.menu_shortCircuitTest.Enabled = true;
                            this.menu_InsulationTest.Enabled = true;
                            this.menu_VoltageWithStandTest.Enabled = true;
                            this.lbx_testStatus.Text = "耐压测试已完成";
                            this.lbx_testStatus.ForeColor = Color.Red;
                            this.menu_VoltageWithStandTest.Enabled = true;
                            this.lbx_voltageExCount.Text = CalCurExceptCount(12) + "";
                            if (this.cableTestProcessQueue.Count == 0)
                            {
                                var pasCount = CalCurCodCircuitInsVolPassCount(6, 8, 10, 12);
                                this.lbx_conRelationCount.Text = pasCount + "";
                                this.testEndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                MessageBox.Show($"测试完成，测试合格芯线数量为{pasCount}条！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        break;
                }

                LogHelper.Log.Info("当前测试项完成，开始检查下一项目....");
                //更新当前测试项完成状态
                var curTestObj = this.cableTestProcessOneKey.CableTestProcessParamsList.Find(obj => obj.CableTestTypeEnum == cableTestType);
                curTestObj.TestItemStateEnum = CableTestProcessParams.TestState.Completed;
                curTestObj.TestItemEndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                //查找下一测试项
                if (this.cableTestProcessQueue.Count == 0)//一键测试结束
                {
                    return;
                }
                CableTestProcessParams cableTestProcessParams = new CableTestProcessParams();
                cableTestProcessParams.CableTestTypeEnum = this.cableTestProcessQueue.Dequeue();
                cableTestProcessParams.TestItemStateEnum = CableTestProcessParams.TestState.Started;
                cableTestProcessParams.TestItemStartDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                this.cableTestProcessOneKey.CableTestProcessParamsList.Add(cableTestProcessParams);
                //发送测试指令
                SendOneKeyTestCommand(cableTestProcessParams.CableTestTypeEnum);
            }
            else if (this.cableTestProcessOneKey.CableTestMethodEnum == CableTestProcess.CableTestMethod.SignalTest)
            {
                switch (sigTestType)
                {
                    case CableTestProcessParams.CableTestType.ConductTest:
                            if (CheckTestItemResult(6))
                            {
                                //测试完成，可以测试短路
                                this.menu_shortCircuitTest.Enabled = true;
                            }
                            else
                            {
                                this.menu_shortCircuitTest.Enabled = false;
                                this.menu_InsulationTest.Enabled = false;
                                this.menu_VoltageWithStandTest.Enabled = false;
                            }
                            this.menu_ConductionTest.Enabled = true;
                            this.menu_OneKeyTest.Enabled = true;
                            this.lbx_testStatus.Text = "导通测试已完成";
                            this.lbx_testStatus.ForeColor = Color.Red;
                            this.lbx_conductExCount.Text = CalCurExceptCount(6) + "";
                            int pasCount = CalCurPassCount(6);
                            this.lbx_conRelationCount.Text = pasCount + "";
                        this.testEndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        MessageBox.Show($"测试完成，导通测试合格芯线数量为{pasCount}条！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case CableTestProcessParams.CableTestType.ShortCircuitTest:
                        if (CheckTestItemResult(8))
                        {
                            this.menu_InsulationTest.Enabled = true;
                            this.menu_VoltageWithStandTest.Enabled = true;
                        }
                        else
                        {
                            this.menu_InsulationTest.Enabled = false;
                            this.menu_VoltageWithStandTest.Enabled = false;
                        }
                        this.menu_ConductionTest.Enabled = true;
                        this.menu_shortCircuitTest.Enabled = true;
                        this.menu_OneKeyTest.Enabled = true;
                        this.lbx_testStatus.Text = "短路测试已完成";
                        this.lbx_testStatus.ForeColor = Color.Red;
                        this.lbx_shortCircuitExCount.Text = CalCurExceptCount(8) + "";
                        pasCount = CalCurPassCount(8);
                        this.lbx_conRelationCount.Text = pasCount + "";
                        this.testEndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        MessageBox.Show($"测试完成，短路测试合格芯线数量为{pasCount}条！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        break;
                    case CableTestProcessParams.CableTestType.InsulateTest:
                        this.menu_ConductionTest.Enabled = true;
                        this.menu_shortCircuitTest.Enabled = true;
                        this.menu_InsulationTest.Enabled = true;
                        this.menu_VoltageWithStandTest.Enabled = true;
                        this.menu_OneKeyTest.Enabled = true;
                        this.lbx_testStatus.Text = "绝缘测试已完成";
                        this.lbx_testStatus.ForeColor = Color.Red;
                        this.menu_InsulationTest.Enabled = true;
                        this.lbx_insulateExCount.Text = CalCurExceptCount(10) + "";
                        pasCount = CalCurPassCount(10);
                        this.lbx_conRelationCount.Text = pasCount + "";
                        this.testEndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        MessageBox.Show($"测试完成，绝缘测试合格芯线数量为{pasCount}条！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case CableTestProcessParams.CableTestType.PressureWithVoltageTest:
                        this.menu_ConductionTest.Enabled = true;
                        this.menu_shortCircuitTest.Enabled = true;
                        this.menu_InsulationTest.Enabled = true;
                        this.menu_VoltageWithStandTest.Enabled = true;
                        this.lbx_testStatus.Text = "耐压测试已完成";
                        this.lbx_testStatus.ForeColor = Color.Red;
                        this.menu_VoltageWithStandTest.Enabled = true;
                        this.menu_OneKeyTest.Enabled = true;
                        this.lbx_voltageExCount.Text = CalCurExceptCount(12) + "";
                        pasCount = CalCurPassCount(12);
                        this.lbx_conRelationCount.Text = pasCount + "";
                        this.testEndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        MessageBox.Show($"测试完成，耐压测试合格芯线数量为{pasCount}条！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
        }

        private void SendOneKeyTestCommand(CableTestProcessParams.CableTestType cableTestType)
        {
            if (cableTestType == CableTestProcessParams.CableTestType.ConductTest)
            {
                StartConductTest();
            }
            else if (cableTestType == CableTestProcessParams.CableTestType.ShortCircuitTest)
            {
                StartCircuitTest();
            }
            else if (cableTestType == CableTestProcessParams.CableTestType.InsulateTest)
            {
                StartInsulateTest();
            }
            else if (cableTestType == CableTestProcessParams.CableTestType.PressureWithVoltageTest)
            {
                StartVoltageWithStandardTest();
            }
        }

        private void UnEnableTestButton()
        {
            this.Invoke(new Action(() =>
            {
                this.menu_ConductionTest.Enabled = false;
                this.menu_shortCircuitTest.Enabled = false;
                this.menu_InsulationTest.Enabled = false;
                this.menu_VoltageWithStandTest.Enabled = false;
                this.menu_OneKeyTest.Enabled = false;
            }));
        }

        private void UpdateTestSelfStudyGridView()
        {
            lock (this)
            {
                if (this.studyParamQueue.Count <= 0)
                    return;
                this.Invoke(new Action(() =>
                {
                    int count = this.studyParamQueue.Count;
                    this.radGridViewSelfStudy.BeginEdit();
                    int iRow = 0;
                    for (int i = 0;i < this.studyParamQueue.Count;i++)
                    {
                        var selfParams = this.studyParamQueue.Dequeue();
                        var pointOrderA = GetOrderPointByDevPoint(selfParams.DevStartPoint, 0, selfParams).StartPointOrder;
                        var pointOrderB = GetOrderPointByDevPoint(selfParams.DevEndPoint, 1, selfParams).EndPointOrder;
                        var testResultVal = selfParams.TestResultVal;
                        var testResult = selfParams.TestReulst;
                        if (pointOrderA == "" || pointOrderB == "")
                            continue;//接口表不存在
                        if (IsSelfGridView2Exist(this.dataSourceSelfStudy, pointOrderA, pointOrderB))
                        {
                            //更新当前值
                            continue;
                        }
                        this.studyParamValidList.Add(selfParams);
                        DataRow dr = this.dataSourceSelfStudy.NewRow();
                        var rCount = this.radGridViewSelfStudy.RowCount;
                        dr[0] = rCount + 1;
                        dr[1] = pointOrderA;
                        dr[2] = pointOrderB;
                        dr[3] = testResultVal;
                        dr[4] = testResult;
                        this.dataSourceSelfStudy.Rows.Add(dr);
                        SetGridStyleByTestValue(testResult);
                        iRow++;
                    }
                    if (iRow > 0)
                    {
                        var rowCount = this.radGridViewSelfStudy.RowCount;
                        this.radGridViewSelfStudy.DataSource = this.dataSourceSelfStudy;
                        this.radGridViewSelfStudy.CurrentRow = this.radGridViewSelfStudy.Rows[this.radGridViewSelfStudy.RowCount - 1];
                        //this.studyParamQueue.RemoveRange(0, count);
                        this.radGridViewSelfStudy.EndEdit();
                        if (rowCount >= 400)
                        {
                            this.IsSelfProcessReset = true;
                            this.studyParamQueue.Clear();
                            SendResetDeviceCommand();
                            SelfStudyLog("提示：短路芯线数量过多，请检查线路后再试！");
                        }
                    }
                }));
            }
        }

        private void UpdateProbTestGridView()
        {
            lock (this)
            {
                if (this.probParamQueue.Count <= 0)
                    return;
                this.Invoke(new Action(() =>
                {
                    int count = this.probParamQueue.Count;
                    this.radGridViewProb.BeginEdit();
                    int iRow = 0;
                    for (int i = 0;i < this.probParamQueue.Count;i++)
                    {
                        var selfParams = this.probParamQueue.Dequeue();
                        //var startPoint = GetOrderPointByDevPoint(selfParams.DevStartPoint, 0, this.probParamList);//探针
                        var pointOrderB = GetOrderPointByDevPoint(selfParams.DevEndPoint, 1, selfParams).EndPointOrder;
                        if (pointOrderB == "")
                            continue;
                        var testResultVal = selfParams.TestResultVal;
                        var testResult = selfParams.TestReulst;
                        if (IsProbGridView2Exist(this.dataSourceProb, pointOrderB))
                            continue;
                        DataRow dr = this.dataSourceProb.NewRow();
                        var rCount = this.radGridViewProb.RowCount;
                        dr[0] = rCount + 1;
                        dr[1] = pointOrderB;
                        dr[2] = testResultVal;
                        dr[3] = testResult;
                        this.dataSourceProb.Rows.Add(dr);
                        SetGridStyleProbByTestValue(testResult, 3);
                        iRow++;
                    }
                    if (iRow > 0)
                    {
                        var rowCount = this.radGridViewProb.RowCount;
                        this.radGridViewProb.DataSource = this.dataSourceProb;
                        this.radGridViewProb.CurrentRow = this.radGridViewProb.Rows[rowCount - 1];
                        //this.probParamList.RemoveRange(0, count);
                        this.radGridViewProb.EndEdit();

                        if (rowCount >= 400)
                        {
                            this.IsSelfProcessReset = true;
                            this.probParamQueue.Clear();
                            SendResetDeviceCommand();
                        }
                    }
                }));
            }
        }

        private SelfStudyParams GetOrderPointByDevPoint(string did, int stype, SelfStudyParams studyParams)//stype 0 - start,1-end
        {
            //SelfStudyParams studyParams = new SelfStudyParams();
            InterfaceInfoLibraryManager infoLibraryManager = new InterfaceInfoLibraryManager();
            var data = infoLibraryManager.GetDataSetByFieldsAndWhere("ContactPoint,InterfaceNo", $"where SwitchStandStitchNo='{did}'").Tables[0];
            if (data.Rows.Count < 1)
            {
                studyParams.StartPointOrder = "";
                studyParams.EndPointOrder = "";
                return studyParams;
            }
            var interName = data.Rows[0][1].ToString();
            var pointOrder = data.Rows[0][0].ToString();
            if (stype == 0)
            {
                studyParams.StartInterfaceName = interName;
                studyParams.StartPointOrder = pointOrder;
            }
            else if (stype == 1)
            {
                studyParams.EndInterfaceName = interName;
                studyParams.EndPointOrder = pointOrder;
            }
            return studyParams;
        }

        private string GetDevPointByOrderPoint(string interName, string id)
        {
            InterfaceInfoLibraryManager infoLibraryManager = new InterfaceInfoLibraryManager();
            var data = infoLibraryManager.GetDataSetByFieldsAndWhere("SwitchStandStitchNo", $"where InterfaceNo='{interName}' and ContactPoint='{id}'").Tables[0];
            return data.Rows[0][0].ToString();
        }

        private void SetGridStyleByTestValue(string testResult)
        {
            if (!IsFirstSetGridDTStyle)
            {
                if (testResult == "导通")
                {
                    RadGridViewProperties.SetRadGridViewStyle(this.radGridViewSelfStudy, 4, RadGridViewProperties.GridViewRecordEnum.Conduction);
                    this.IsFirstSetGridDTStyle = true;
                }
            }
            if (!IsFirstSetGridUnDTStyle)
            {
                if (testResult == "不导通")
                {
                    RadGridViewProperties.SetRadGridViewStyle(this.radGridViewSelfStudy, 4, RadGridViewProperties.GridViewRecordEnum.UnConduction);
                    this.IsFirstSetGridUnDTStyle = true;
                }
            }
            if (!IsFirstSetGridOpenCirStyle)
            {
                if (testResult == "开路")
                {
                    RadGridViewProperties.SetRadGridViewStyle(this.radGridViewSelfStudy, 4, RadGridViewProperties.GridViewRecordEnum.OpenCircuit);
                    {
                        this.IsFirstSetGridOpenCirStyle = true;
                    }
                }
            }
        }

        private void SetGridStyleProbByTestValue(string testResult, int colIndex)
        {
            if (!IsFirstSetGridDTProbStyle)
            {
                if (testResult == "导通")
                {
                    RadGridViewProperties.SetRadGridViewStyle(this.radGridViewProb, colIndex, RadGridViewProperties.GridViewRecordEnum.Conduction);
                    this.IsFirstSetGridDTProbStyle = true;
                }
            }
            if (!IsFirstSetGridUnDTProbStyle)
            {
                if (testResult == "不导通")
                {
                    RadGridViewProperties.SetRadGridViewStyle(this.radGridViewProb, 4, RadGridViewProperties.GridViewRecordEnum.UnConduction);
                    this.IsFirstSetGridUnDTProbStyle = true;
                }
            }
            if (!IsFirstSetGridOpenCirProbStyle)
            {
                if (testResult == "开路")
                {
                    RadGridViewProperties.SetRadGridViewStyle(this.radGridViewProb, 4, RadGridViewProperties.GridViewRecordEnum.OpenCircuit);
                    {
                        this.IsFirstSetGridOpenCirProbStyle = true;
                    }
                }
            }
        }

        //private int curTestRowCount;
        private void UpdateTestResultByTestPoint()
        {
            if (this.cableTestPramsQueue.Count <= 0)
                return;
            this.Invoke(new Action(() =>
            {
                lock (this)
                {
                    int count = this.cableTestPramsQueue.Count;
                    int iRow = 0;//已测试的行数据
                    var pointA = "";
                    var pointB = "";
                    this.radGridViewCableTest.BeginEdit();
                    for (int i = 0; i < count; i++)
                    {
                        var cableTestParams = this.cableTestPramsQueue.Dequeue();
                        var startPoint = cableTestParams.StartPoint;
                        var endPoint = cableTestParams.EndPoint;
                        var testResultVal = cableTestParams.TestResultVal;
                        var testResult = cableTestParams.TestReulst;

                        foreach (DataRow rowInfo in this.dataSourceCableTest.Rows)
                        {
                            var orderID = rowInfo[0].ToString();
                            var startDevPoint = GetDevPointPinByContactPoint(rowInfo[1].ToString(), rowInfo[2].ToString());
                            var endDevPoint = GetDevPointPinByContactPoint(rowInfo[3].ToString(), rowInfo[4].ToString());
                            if (startDevPoint == startPoint && endDevPoint == endPoint)
                            {
                                //LogHelper.Log.Info($"startDevPoint={startDevPoint},startPoint={startPoint},endDevPoint={endDevPoint},endPoint={endPoint},testResultVal={testResultVal},testResult={testResult}");
                                //更新测试记录
                                var tVal = rowInfo[cableTestParams.StartIndex].ToString();
                                var tResult = rowInfo[cableTestParams.StartIndex + 1].ToString();
                                if (String.IsNullOrEmpty(tResult) || tResult == "--")//更新未测试的记录
                                {
                                    //update test result
                                    rowInfo[cableTestParams.StartIndex] = testResultVal;
                                    rowInfo[cableTestParams.StartIndex + 1] = testResult;

                                    SetTestGridViewStyle(testResult, cableTestParams);
                                }
                                else if (tResult == "合格")//已测试结果合格，后面测试结果覆盖前面
                                {
                                    //update tested result
                                    rowInfo[cableTestParams.StartIndex] = testResultVal;
                                    rowInfo[cableTestParams.StartIndex + 1] = testResult;

                                    SetTestGridViewStyle(testResult, cableTestParams);
                                }
                                else
                                {
                                    //已测试为不合格的情况，导通/短路更新，绝缘不更新，绝缘保存数据，打印到报表
                                    if (cableTestParams.StartIndex == 9)
                                    {
                                        if (this.IsFirstInsulateTest)
                                        {
                                            rowInfo[cableTestParams.StartIndex] = testResultVal;
                                            rowInfo[cableTestParams.StartIndex + 1] = testResult;
                                            SetTestGridViewStyle(testResult, cableTestParams);
                                            LogHelper.Log.Info($"update testResultVal={testResultVal},testResult={testResult}");
                                        }
                                        DataRow insulateRow = this.dataSourceInsulateTest.NewRow();
                                        insulateRow["起点接口"] = rowInfo[1].ToString();
                                        insulateRow["起点接点"] = rowInfo[2].ToString();
                                        insulateRow["终点接口"] = rowInfo[3].ToString();
                                        insulateRow["终点接点"] = rowInfo[4].ToString();
                                        insulateRow["绝缘电阻(Ω)"] = testResultVal;
                                        insulateRow["绝缘测试结果"] = testResult;
                                        this.dataSourceInsulateTest.Rows.Add(insulateRow);
                                    }
                                    else
                                    {
                                        rowInfo[cableTestParams.StartIndex] = testResultVal;
                                        rowInfo[cableTestParams.StartIndex + 1] = testResult;
                                        SetTestGridViewStyle(testResult, cableTestParams);
                                    }
                                }

                                if (i == count - 1)
                                {
                                    pointA = rowInfo[2].ToString();
                                    pointB = rowInfo[4].ToString();
                                }
                                iRow++;
                                //curTestRowCount++;
                                if (!this.curTestGridViewOrderList.Contains(orderID))
                                {
                                    this.curTestGridViewOrderList.Add(orderID);
                                }
                            }
                        }
                    }
                    if (iRow >= 1)//解析到新数据
                    {
                        this.radGridViewCableTest.DataSource = this.dataSourceCableTest;
                        this.radGridViewCableTest.EndEdit();
                        this.radGridViewCableTest.CurrentRow = this.radGridViewCableTest.Rows[QueryGridViewRowIndex(pointA, pointB)];//更新到实际行数
                        var testCount = this.radGridViewCableTest.RowCount;
                        if (this.curTestGridViewOrderList.Count == testCount)
                        {
                            this.IsCalTestDataCompleted = true;
                            this.curTestGridViewOrderList.Clear();
                            LogHelper.Log.Info($"测试完成.........");
                        }
                    }
                }
            }));
        }

        private int QueryGridViewRowIndex(string pointA, string pointB)
        {
            int i = 0;
            foreach (var rowInfo in this.radGridViewCableTest.Rows)
            {
                if (rowInfo.Cells[2].Value.ToString() == pointA && rowInfo.Cells[4].Value.ToString() == pointB)
                {
                    return i;
                }
                i++;
            }
            return this.radGridViewCableTest.RowCount - 1;
        }

        private void SetTestGridViewStyle(string testResult,CableTestParams cableTestParams)
        {
            //style
            if (testResult == "合格")
            {
                var val = (cableTestParams.StartIndex + 1) + "_合格";
                if (!this.testItemStyleList.Contains(val))
                {
                    this.testItemStyleList.Add(val);
                    RadGridViewProperties.SetRadGridViewStyle(this.radGridViewCableTest, cableTestParams.StartIndex + 1, RadGridViewProperties.GridViewRecordEnum.Qualification);
                }
            }
            else if (testResult == "不合格")
            {
                var val = (cableTestParams.StartIndex + 1) + "_不合格";
                if (!this.testItemStyleList.Contains(val))
                {
                    this.testItemStyleList.Add(val);
                    RadGridViewProperties.SetRadGridViewStyle(this.radGridViewCableTest, cableTestParams.StartIndex + 1, RadGridViewProperties.GridViewRecordEnum.Disqualification);
                }
            }
        }

        private int CalCurExceptCount(int colIndex)
        {
            int i = 0;
            foreach (var rowInfo in this.radGridViewCableTest.Rows)
            {
                if (rowInfo.Cells[colIndex].Value.ToString() == "不合格")
                {
                    i++;
                }
            }
            return i;
        }

        private int CalCurPassCount(int colIndex)
        {
            int i = 0;
            foreach (var rowInfo in this.radGridViewCableTest.Rows)
            {
                var result = rowInfo.Cells[colIndex].Value.ToString().Trim();
                if (result == "合格")
                {
                    i++;
                }
                else
                {
                    //LogHelper.Log.Info($"不合格,index={colIndex},result={result}");
                }
            }
            return i;
        }

        private int CalCurCodCircuitPassCount(int codIndex, int cirIndex)
        {
            int i = 0;
            foreach (var rowInfo in this.radGridViewCableTest.Rows)
            {
                if (rowInfo.Cells[codIndex].Value.ToString() == "合格" && rowInfo.Cells[cirIndex].Value.ToString() == "合格")
                {
                    i++;
                }
            }
            return i;
        }

        private int CalCurCodCircuitInsPassCount(int codIndex, int cirIndex, int insIndex)
        {
            int i = 0;
            foreach (var rowInfo in this.radGridViewCableTest.Rows)
            {
                var conductRes = rowInfo.Cells[codIndex].Value.ToString();
                var cirRes = rowInfo.Cells[cirIndex].Value.ToString();
                var insRes = rowInfo.Cells[insIndex].Value.ToString();
                if (conductRes == "合格" && cirRes == "合格" && insRes == "合格")
                {
                    i++;
                }
            }
            return i;
        }

        private int CalCurCodCircuitInsVolPassCount(int codIndex, int cirIndex, int insIndex, int volIndex)
        {
            int i = 0;
            foreach (var rowInfo in this.radGridViewCableTest.Rows)
            {
                var conductRes = rowInfo.Cells[codIndex].Value.ToString();
                var cirRes = rowInfo.Cells[cirIndex].Value.ToString();
                var insRes = rowInfo.Cells[insIndex].Value.ToString();
                var volRes = rowInfo.Cells[volIndex].Value.ToString();
                if (conductRes == "合格" && cirRes == "合格" && insRes == "合格" && volRes == "合格")
                {
                    i++;
                }
            }
            return i;
        }

        private bool CheckTestItemResult(int startIndex)
        {
            bool IsPass = true;
            foreach (DataRow dr in this.dataSourceCableTest.Rows)
            {
                var result = dr[startIndex].ToString().Trim();
                if (result != "合格")
                {
                    IsPass = false;
                }
            }
            if (IsPass)
                return true;
            return false;
        }

        private string CalTestItemResult(int startIndex)
        {
            bool IsPass = true;
            bool IsTest = true;
            foreach (DataRow dr in this.dataSourceCableTest.Rows)
            {
                var result = dr[startIndex].ToString().Trim();
                if (result != "合格")
                {
                    IsPass = false;
                    if (result == "--")
                    {
                        IsTest = false;
                    }
                }
            }
            if (IsPass)
                return "合格";
            else
            {
                if (IsTest)
                    return "不合格";
                else
                    return "未测试";
            }
        }

        private string CalFinalTestResult(string project, string cableName, string testSerial)
        {
            var where = $"where ProjectName = '{project}' and TestCableName = '{cableName}' and TestSerialNumber='{testSerial}'";
            var data = this.historyDataInfoManager.GetDataSetByWhere(where).Tables[0];
            if (data.Rows.Count <= 0)
                return "未测试";
            var conductResult = data.Rows[0]["ConductTestResult"].ToString();
            var shortCircuitResult = data.Rows[0]["ShortCircuitTestResult"].ToString();
            var insulateResult = data.Rows[0]["InsulateTestResult"].ToString();
            if (conductResult == "合格" && shortCircuitResult == "合格" && insulateResult == "合格")
            {
                return "合格";
            }
            return "不合格";
        }

        private bool IsSelfGridView2Exist(DataTable dataSource,string cpointOrderA, string cpointOrderB)
        {
            if (dataSource.Rows.Count < 1)
                return false;
            foreach (DataRow rowInfo in dataSource.Rows)
            {
                var pointA = rowInfo[1].ToString();
                var pointB = rowInfo[2].ToString();
                var testVal = rowInfo[3].ToString();
                var testResult = rowInfo[4].ToString();

                if (cpointOrderA == pointA && cpointOrderB == pointB)//界面已存在相同的记录
                {
                    return true;
                }
                else if (cpointOrderA == pointA && cpointOrderB != pointB)//第2个点不同
                {
                    //A接口的点与B接口另一个点也导通
                    SelfStudyLog($"警告：A接口的接点{pointA}已与B接口的接点{pointB}导通；A接口的接点{pointA}与B接口的接点{cpointOrderB}也导通；请检查线束关系是否异常！");
                    return false;//异常警告,界面继续显示
                }
                else if (cpointOrderA != pointA && cpointOrderB == pointB)//第1个点不同
                {
                    //B接口的点与A接口的另一个点也导通
                    SelfStudyLog($"警告：B接口的接点{pointB}已与A接口的接点{pointA}导通；B接口的接点{pointB}与A接口的接点{cpointOrderA}也导通；请检查线束关系是否异常！");
                    return false;//异常警告
                }
            }
            return false;
        }

        private bool IsProbGridView2Exist(DataTable dataSource, string cpointOrder)
        {
            if (dataSource.Rows.Count < 1)
                return false;
            foreach (DataRow rowInfo in dataSource.Rows)
            {
                var point = rowInfo[1].ToString();
                if (point == cpointOrder)
                    return true;
            }
            return false;
        }

        private void SelfStudyLogInvok(string text)
        {
            this.tb_selfStudyTip.Visible = true;
            this.Invoke(new Action(() =>
            {
                this.tb_selfStudyTip.Text = text;
            }));
        }

        private void SelfStudyLog(string text)
        {
            this.tb_selfStudyTip.ReadOnly = false;
            this.tb_selfStudyTip.Visible = true;
            this.tb_selfStudyTip.Text = text;
            this.tb_selfStudyTip.BackColor = Color.Red;
            this.tb_selfStudyTip.ReadOnly = true;
            this.tool_importCableLib.Enabled = false;
        }

        private void SuperEasyClient_NoticeConnectEvent(bool IsConnect, SuperEasyClient.ConnectStatusEnum tipMessage)
        {
            this.IsConnectServer = IsConnect;
            if (IsConnect)
            {
                //连接成功
                if (this.InvokeRequired)
                    this.Invoke(new Action(() =>
                    {
                        this.tool_ConnectDevice.Text = "断开连接";
                        this.tool_ConnectDevice.Image = Resources.server_delete;
                        this.lbx_conDevStatus.Text = "已连接";
                        this.lbx_serviceURL.Text = this.deviceConfig.ServerUrl;
                        this.lbx_servicePort.Text = this.deviceConfig.ServerPort.ToString();
                        this.menu_ConductionTest.Enabled = true;
                        this.menu_OneKeyTest.Enabled = true;
                        this.curTestGridViewOrderList.Clear();

                        if (tipMessage == SuperEasyClient.ConnectStatusEnum.ReConnected)
                        {
                            if (devControlCommandType == DevControlCommandTypeEnum.StartDevice)
                            {
                                this.tool_ConnectDevice.Image = Resources.server_delete;
                                this.IsSelfProcessReset = false;
                            }
                        }
                        else if (tipMessage == SuperEasyClient.ConnectStatusEnum.Connected)
                        {
                            if (this.IsFirstConnectDevice)//第一次连接设备开始自检
                            {
                                this.IsFirstConnectDevice = false;
                                StartSelfCheck();
                            }
                        }
                    }));
            }
            else
            {
                //断开连接/连接失败
                this.Invoke(new Action(() =>
                {
                    this.tool_ConnectDevice.Text = "连接设备";
                    this.tool_ConnectDevice.Image = Resources.server_link;
                    if (tipMessage == SuperEasyClient.ConnectStatusEnum.ConnectError)
                    {
                        if (!this.IsSelfProcessReset)
                        {
                            MessageBox.Show("连接失败！", "提示", MessageBoxButtons.OK);
                        }
                    }
                    this.lbx_conDevStatus.Text = "未连接";
                    this.lbx_serviceURL.Text = "";
                    this.lbx_servicePort.Text = "";
                }));
            }
        }

        private void ConnectService()
        {
            if (!this.IsConnectServer)
            {
                //断开连接状态，开始连接服务
                if (this.deviceConfig.ServerUrl == "" || this.deviceConfig.ServerPort == 0)
                {
                    if (MessageBox.Show("服务器参数未配置，是否立即打开配置！", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        OpenConnectConfig();
                        if (this.deviceConfig.ServerUrl == "")
                            return;
                        if (this.deviceConfig.ServerPort == 0)
                            return;
                    }
                    else
                        return;
                }
                else
                {
                    //update status
                    this.lbx_serviceURL.Text = this.deviceConfig.ServerUrl;
                    this.lbx_servicePort.Text = this.deviceConfig.ServerPort.ToString();
                }
                devControlCommandType = DevControlCommandTypeEnum.StartDevice;
                SuperEasyClient.serverUrl = this.deviceConfig.ServerUrl;
                SuperEasyClient.serverPort = this.deviceConfig.ServerPort.ToString();
                SuperEasyClient.ConnectServer();
            }
            else
            {
                //已连接服务，开始断开连接
                devControlCommandType = DevControlCommandTypeEnum.StopDevice;
                SuperEasyClient.CloseConnect();
            }
        }

        private void RadTreeView1_NodeMouseDoubleClick(object sender, RadTreeViewEventArgs e)
        {
            RadTreeNode radTreeNode = e.Node;
            var projectInfoData = projectInfoManager.GetDataSetByFieldsAndWhere("distinct ProjectName", "").Tables[0];
            if (projectInfoData.Rows.Count < 1)
                return;
            foreach (DataRow dr in projectInfoData.Rows)
            {
                var projectName = dr["ProjectName"].ToString();
                if (radTreeNode.RootNode.Text == projectName)
                {
                    switch (radTreeNode.Text)
                    {
                        case PROJECT_EDIT:
                            RadProjectCreat radProjectCreat = new RadProjectCreat("编辑项目", projectName, this.deviceConfig,true);
                            if (radProjectCreat.ShowDialog() == DialogResult.OK)
                            {
                                UpdateTreeView(radProjectCreat.projectName);
                                this.projectInfo = ProjectBasicInfo.QueryProjectInfo(projectName);
                            }
                            break;
                        case WORK_WEAR:

                            break;
                        case PROJECT_OPEN_TEST:
                            OpenCurProject(projectName);
                            UpdateTreeView(projectName);
                            break;

                        case PROJECT_CLOSE_TEST:
                            UpdateCloseProState();
                            this.radDock1.RemoveWindow(this.documentWindow1);
                            break;

                        case CABLE_DETAIL:
                            if (this.projectInfo.ProjectName == "" || this.projectInfo.ProjectName == null)
                            {
                                this.projectInfo.ProjectName = projectName;
                            }
                            FrmCableTestInfo cableTestInfo = new FrmCableTestInfo(this.projectInfo);
                            cableTestInfo.Show();
                            break;

                        case DEVICE_DETAIL:
                            break;
                    }
                }
            }
        }

        private void OpenCurProject(string projectName)
        {
            this.menu_interfaceLibrary.Enabled = false;
            this.menu_cableLibrary.Enabled = false;
            this.menu_newProject.Enabled = false;
            this.menu_connectorLibrary.Enabled = false;
            this.menu_switchStandMapLib.Enabled = false;
            this.menu_switchWorkWearLib.Enabled = false;
            this.menuItem_userManage.Visibility = ElementVisibility.Collapsed;
            this.lbx_testStatus.Text = "等待测试";

            this.tool_InterfaceLibrary.Enabled = false;
            this.tool_HarnessLibrary.Enabled = false;
            this.tool_NewProject.Enabled = false;
            this.tool_OpenProject.Enabled = false;

            this.radDock1.RemoveAllDocumentWindows();
            this.radDock1.AddDocument(this.documentWindow1);
            QueryTestInfoByProjectName(projectName);
        }

        private void UpdateCloseProState()
        {
            this.menu_interfaceLibrary.Enabled = true;
            this.menu_cableLibrary.Enabled = true;
            this.menu_newProject.Enabled = true;
            this.menu_connectorLibrary.Enabled = true;
            this.menu_switchStandMapLib.Enabled = true;
            this.menu_switchWorkWearLib.Enabled = true;
            this.menuItem_userManage.Visibility = ElementVisibility.Visible;

            this.tool_InterfaceLibrary.Enabled = true;
            this.tool_HarnessLibrary.Enabled = true;
            this.tool_NewProject.Enabled = true;
            this.tool_OpenProject.Enabled = true;

            this.menu_ConductionTest.Enabled = true;
            this.menu_OneKeyTest.Enabled = true;
        }

        #endregion

        #region menu event
        private void Menu_historyData_Click(object sender, EventArgs e)
        {
            RadTestDataBasicInfo radTestDataBasicInfo = new RadTestDataBasicInfo(this.deviceConfig.ReportDirectory, this.deviceConfig);
            radTestDataBasicInfo.ShowDialog();
        }

        private void Menu_faultCode_Click(object sender, EventArgs e)
        {
            FaultCodeInfo faultCodeInfo = new FaultCodeInfo();
            faultCodeInfo.ShowDialog();  
        }

        private void Menu_disConnect_Click(object sender, EventArgs e)
        {
            ConnectService();
        }

        private void Menu_connectServer_Click(object sender, EventArgs e)
        {
            ConnectService();
        }

        private void Menu_cableLibrary_Click(object sender, EventArgs e)
        {
            OpenHarnessLibrary();
        }

        private void Menu_interfaceLibrary_Click(object sender, EventArgs e)
        {
            OpenInterfaceLibrary();
        }

        private void Menu_connectorLibrary_Click(object sender, EventArgs e)
        {
            RadConnectorLibrary radConnectorLibrary = new RadConnectorLibrary();
            radConnectorLibrary.ShowDialog();
        }

        /// <summary>
        /// 设备自检
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_devSelfCheck_Click(object sender, EventArgs e)
        {
            FrmDevSelfCheck devSelfCheck = new FrmDevSelfCheck();
            devSelfCheck.ShowDialog();
        }

        /// <summary>
        /// 设备调试助手
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_devDebugAssitant_Click(object sender, EventArgs e)
        {
            DevDebugAssitant deviceDebugging = new DevDebugAssitant();
            deviceDebugging.ShowDialog();
        }

        /// <summary>
        /// 设备校准
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_devCalibration_Click(object sender, EventArgs e)
        {
            DevCalibration deviceCalibration = new DevCalibration(this.deviceConfig);
            deviceCalibration.ShowDialog();
        }

        private void Menu_VoltageWithStandTest_Click(object sender, EventArgs e)
        {
            this.cableTestProcessOneKey.CableTestMethodEnum = CableTestProcess.CableTestMethod.SignalTest;
            this.cableTestProcessSig.CableTestTypeEnum = CableTestProcessParams.CableTestType.PressureWithVoltageTest;
            this.cableTestProcessQueue.Clear();
            this.cableTestProcessQueue.Enqueue(CableTestProcessParams.CableTestType.PressureWithVoltageTest);
            StartVoltageWithStandardTest();
        }

        private void Menu_InsulationTest_Click(object sender, EventArgs e)
        {
            this.cableTestProcessOneKey.CableTestMethodEnum = CableTestProcess.CableTestMethod.SignalTest;
            this.cableTestProcessSig.CableTestTypeEnum = CableTestProcessParams.CableTestType.InsulateTest;
            this.cableTestProcessQueue.Clear();
            this.cableTestProcessQueue.Enqueue(CableTestProcessParams.CableTestType.InsulateTest);
            StartInsulateTest();
        }

        private void Menu_shortCircuitTest_Click(object sender, EventArgs e)
        {
            this.cableTestProcessOneKey.CableTestMethodEnum = CableTestProcess.CableTestMethod.SignalTest;
            this.cableTestProcessSig.CableTestTypeEnum = CableTestProcessParams.CableTestType.ShortCircuitTest;
            this.cableTestProcessQueue.Clear();
            this.cableTestProcessQueue.Enqueue(CableTestProcessParams.CableTestType.ShortCircuitTest);
            StartCircuitTest();
        }

        private void Menu_ConductionTest_Click(object sender, EventArgs e)
        {
            this.cableTestProcessOneKey.CableTestMethodEnum = CableTestProcess.CableTestMethod.SignalTest;
            this.cableTestProcessSig.CableTestTypeEnum = CableTestProcessParams.CableTestType.ConductTest;
            this.cableTestProcessQueue.Clear();//清除一键测试未测试的队列
            this.cableTestProcessQueue.Enqueue(CableTestProcessParams.CableTestType.ConductTest);
            this.UpdateCurrentGridView();
            StartConductTest();
        }

        private void Menu_OneKeyTest_Click(object sender, EventArgs e)
        {
            this.cableTestProcessQueue.Clear();
            OneClickTestConfig oneClickTest = new OneClickTestConfig(this.cableTestProcessQueue);
            if (oneClickTest.ShowDialog() == DialogResult.OK)
            {
                if (!this.radDock1.ActivateWindow(this.documentWindow1))
                {
                    MessageBox.Show("请打开要测试的项目！","提示",MessageBoxButtons.OK);
                    return;
                }
                if (!IsConnectSuccess())
                    return;
                if (!IsOpenTestProject())
                    return;
                if (!IsSetEnvironmentParams())
                    return;
                //清空异常数
                this.conductTestExceptCount = 0;
                this.shortCircuitTestExceptCount = 0;
                this.insulateTestExceptCount = 0;
                this.voltageWithStandardTestExceptCount = 0;

                this.menu_OneKeyTest.Enabled = false;
                this.UpdateCurrentGridView();
                //开始启动第一项测试
                if (this.cableTestProcessQueue.Count <= 0)
                {
                    this.menu_OneKeyTest.Enabled = true;
                    return;//没有选择要测试的内容
                }
                if (this.radGridViewCableTest.RowCount <= 0)
                {
                    this.menu_OneKeyTest.Enabled = true;
                    return;//测试组为空
                }
                this.cableTestProcessOneKey.CableTestProcessParamsList = new List<CableTestProcessParams>();
                this.cableTestProcessOneKey.CurrentTestProject = this.projectInfo.ProjectName;
                this.cableTestProcessOneKey.ProjectTestNumber = this.projectTestNumber;
                this.cableTestProcessOneKey.CableTestMethodEnum = CableTestProcess.CableTestMethod.OneKeyTest;

                CableTestProcessParams testProcessParams = new CableTestProcessParams();
                testProcessParams.CableTestTypeEnum = this.cableTestProcessQueue.Dequeue();
                testProcessParams.TestItemStateEnum = CableTestProcessParams.TestState.Started;
                testProcessParams.TestItemStartDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                testProcessParams.TestPassThreshold = 0;

                this.cableTestProcessOneKey.CableTestProcessParamsList.Add(testProcessParams);
                SendOneKeyTestCommand(testProcessParams.CableTestTypeEnum);
            }
        }

        private void Menu_connectCfg_Click(object sender, EventArgs e)
        {
            OpenConnectConfig();
        }

        private void OpenConnectConfig()
        {
            AddConnection addConnection = new AddConnection(this.deviceConfig.ServerUrl, this.deviceConfig.ServerPort);
            if (addConnection.ShowDialog() == DialogResult.OK)
            {
                this.deviceConfig.ServerUrl = addConnection.serverIP;
                this.deviceConfig.ServerPort = addConnection.serverPort;
            }
        }

        private void Menu_userManager_Click(object sender, EventArgs e)
        {
            UserManager userManager = new UserManager();
            userManager.ShowDialog();
        }

        private void Menu_operateLog_Click(object sender, EventArgs e)
        {
            OperatorLog operatorLog = new OperatorLog();
            operatorLog.ShowDialog();
        }

        private void Menu_modifyPassword_Click(object sender, EventArgs e)
        {
            TUserManager userManager = new TUserManager();
            var dt = userManager.GetDataSetByFieldsAndWhere("UserID", $"where UserName='{LocalLogin.currentUserName}'").Tables[0];
            if (dt.Rows.Count < 1)
                return;
            ModifyPwd modifyPwd = new ModifyPwd(dt.Rows[0][0].ToString(),LocalLogin.currentUserName);
            modifyPwd.ShowDialog();
        }

        private void Menu_switchWorkWearLib_Click(object sender, EventArgs e)
        {
            SwitchWorkWearLibrary switchWorkWearLibrary = new SwitchWorkWearLibrary();
            switchWorkWearLibrary.ShowDialog();
        }

        private void Menu_switchStandMapLib_Click(object sender, EventArgs e)
        {
            TesterSwitchMapRelation testerSwitchMapRelation = new TesterSwitchMapRelation();
            testerSwitchMapRelation.ShowDialog();
        }

        private void Menu_SaveData_Click(object sender, EventArgs e)
        {
            SaveTestResult();
        }
        #endregion

        #region tool event

        private void Tool_Probe_Click(object sender, EventArgs e)
        {
            if (!this.IsConnectServer)
            {
                if (MessageBox.Show("设备未连接，是否进入参数设置页面？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
            }
            RadProbMeasure probeMeasure = new RadProbMeasure(this.probConfig);
            if (probeMeasure.ShowDialog() == DialogResult.OK)
            {
                this.radDock1.RemoveAllDocumentWindows();
                this.radDock1.AddDocument(this.documentWindow3);
                InitProbTable();
                ClearProbGrid();
                if (this.probConfig.ProbTestType == ProbTestConfig.ProbTestTypeEnum.ProbTestByLimit)
                {
                    var selftStudyString = this.probConfig.MeasureMethod + "01" + DecConvert2ByteHexStr(this.probConfig.LimitMin) + DecConvert2ByteHexStr(this.probConfig.LimitMax);
                    SendSelfStudyOrProbCommand(selftStudyString, probTestFunCode);
                }
                else if (this.probConfig.ProbTestType == ProbTestConfig.ProbTestTypeEnum.ProbTestByInterface)
                {
                    var selftStudyString = probConfig.MeasureMethod + "02" + this.probConfig.TestInterAList;
                    SendSelfStudyOrProbCommand(selftStudyString, probTestFunCode);
                }
            }
        }

        private void Tool_SelfStudy_Click(object sender, EventArgs e)
        {
            if (!this.IsConnectServer)
            {
                if (MessageBox.Show("设备未连接，是否进入参数设置页面？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
            }
            //设备连接成功后，才能进入自学习
            frmSefStudy sefStudy = new frmSefStudy(this.studyConfig);
            if (sefStudy.ShowDialog() == DialogResult.OK)
            {
                InitSelfParams();
                SendSelfComand();
            }
        }

        private void InitSelfParams()
        {
            if (!this.IsConnectSuccess())
                return;
            this.radDock1.RemoveAllDocumentWindows();
            this.radDock1.AddDocument(this.documentWindow2);
            this.tool_importCableLib.Enabled = true;
            ClearSelfGrid();
        }

        private void SendSelfComand()
        {
            if (this.studyConfig.StudyTestType == SelfStudyConfig.SutdyTestTypeEnum.SelfTestByLimit)
            {
                var selftStudyString = this.studyConfig.MeasureMethod + "01" + DecConvert2ByteHexStr(this.studyConfig.LimitMin) + DecConvert2ByteHexStr(this.studyConfig.LimitMax);
                SelfStudyTextState(true, "自学习测试中...");
                SendSelfStudyOrProbCommand(selftStudyString, selfStudyTestFunCode);
            }
            else if (this.studyConfig.StudyTestType == SelfStudyConfig.SutdyTestTypeEnum.SelfTestByInterface)
            {
                var selftStudyString = studyConfig.MeasureMethod + "02" + this.studyConfig.TestInterAList + "0000" + this.studyConfig.TestInterBList;
                ProbTestTextState(true, "探针测试中...");
                SendSelfStudyOrProbCommand(selftStudyString, selfStudyTestFunCode);
            }
        }

        private void SelfStudyTextState(bool b, string text)
        {
            this.Invoke(new Action(()=>
            {
                this.tb_selfStudyTip.ReadOnly = false;
                this.tb_selfStudyTip.Visible = b;
                this.tb_selfStudyTip.Text = text;
                this.tb_selfStudyTip.Font = new Font("粗体", 14f);
                this.tb_selfStudyTip.TextAlign = HorizontalAlignment.Center;
                this.tb_selfStudyTip.ReadOnly = true;
                this.tb_selfStudyTip.ForeColor = Color.Red;
            }));
        }

        private void ProbTestTextState(bool b, string text)
        {
            this.Invoke(new Action(() =>
            {
                this.tb_probTip.ReadOnly = false;
                this.tb_probTip.Visible = b;
                this.tb_probTip.Text = text;
                this.tb_probTip.Font = new Font("粗体", 14f);
                this.tb_probTip.TextAlign = HorizontalAlignment.Center;
                this.tb_probTip.ReadOnly = true;
                this.tb_probTip.ForeColor = Color.Red;
            }));
        }

        private string DecConvert2ByteHexStr(int dec)
        {
            return Convert.ToString(dec, 16).PadLeft(4, '0');
        }

        private void Tool_ConnectDevice_Click(object sender, EventArgs e)
        {
            //连接通讯设备
            ConnectService();
        }

        private void Tool_HistoryData_Click(object sender, EventArgs e)
        {
            RadTestDataBasicInfo testDataBasicInfo = new RadTestDataBasicInfo(this.deviceConfig.ReportDirectory, this.deviceConfig);
            testDataBasicInfo.ShowDialog();
        }

        private void Tool_OpenProject_Click(object sender, EventArgs e)
        {
            ProjectManage projectManager = new ProjectManage(this.deviceConfig);
            if (projectManager.ShowDialog() == DialogResult.OK)
            {
                if (projectManager.operateType == ProjectManage.OperateType.OpenProject)
                {
                    OpenCurProject(projectManager.openProjectName);
                    UpdateTreeView(projectManager.openProjectName);
                }
                else if (projectManager.operateType == ProjectManage.OperateType.DeleteProject)
                {
                    //update current project info
                    UpdateTreeView("");
                    OpenCurProject(projectManager.openProjectName);
                }
            }
            else
            {
                if (projectManager.operateType == ProjectManage.OperateType.DeleteProject)
                {
                    UpdateTreeView("");
                    QueryTestInfoByProjectName(projectManager.openProjectName);
                }
            }
        }

        private void Tool_NewProject_Click(object sender, EventArgs e)
        {
            NewProject();
        }

        private void NewProject()
        {
            RadProjectCreat radProjectCreat = new RadProjectCreat("新建项目", "", this.deviceConfig, false);
            if (radProjectCreat.ShowDialog() == DialogResult.OK)
            {
                UpdateTreeView(radProjectCreat.projectName);
                OpenCurProject(radProjectCreat.projectName);
            }
        }

        /// <summary>
        /// 线束库管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tool_HarnessLibrary_Click(object sender, EventArgs e)
        {
            OpenHarnessLibrary();
        }

        /// <summary>
        /// 接口库管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tool_InterfaceLibrary_Click(object sender, EventArgs e)
        {
            OpenInterfaceLibrary();
        }
        #endregion

        #region common method
        private void OpenHarnessLibrary()
        {
            RadCableLibrary radCableLibrary = new RadCableLibrary();
            if (radCableLibrary.ShowDialog() == DialogResult.OK)
            {
                UpdateTreeView("");
            }
        }

        private void OpenInterfaceLibrary()
        {
            RadInterfaceLibrary interfaceLibrary = new RadInterfaceLibrary();
            interfaceLibrary.ShowDialog();
        }

        private void UpdateTreeView(string curProName)
        {
            //select project
            this.radTreeView1.Nodes.Clear();
            var projectInfoData = projectInfoManager.GetDataSetByFieldsAndWhere("distinct ProjectName", "").Tables[0];
            if (projectInfoData.Rows.Count < 1)
                return;
            ImageList imageList = new ImageList();
            imageList.Images.Add(Resources.打开工程);
            imageList.Images.Add(Resources.关闭);
            imageList.Images.Add(Resources.编辑);
            imageList.Images.Add(Resources.查看);
            this.radTreeView1.ImageList = imageList;
            foreach (DataRow dr in projectInfoData.Rows)
            {
                var projectName = dr["ProjectName"].ToString();
                RadTreeNode root = this.radTreeView1.Nodes.Add(projectName);
                //var projectNode = root.Nodes.Add(PROJECT_INFO);
                root.Nodes.Add(PROJECT_OPEN_TEST, 0);
                root.Nodes.Add(PROJECT_CLOSE_TEST, 1);
                root.Nodes.Add(PROJECT_EDIT, 2);
                root.Nodes.Add(CABLE_DETAIL, 3);
                //projectNode.Nodes.Add(WORK_WEAR, 1);
                //var cableNode = root.Nodes.Add(TEST_CABLE);
                //cableNode.Nodes.Add(CABLE_DETAIL);
                //var deviceNode = root.Nodes.Add(DEVICE_INFO, 1);
                //deviceNode.Nodes.Add(DEVICE_DETAIL, 1);
                if (curProName == projectName)
                {
                    root.ExpandAll();
                    root.Selected = true;
                }
                else
                {
                    root.Expanded = false;
                }
            }
        }

        private int QueryTestItemStatusValue(string testItem,string testCableName)
        {
            var dt = historyDataInfoManager.GetDataSetByWhere($"where TestCableName = '{testCableName}'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var serialNum = dr["TestSerialNumber"].ToString();
                    dt = historyDataDetailManager.GetDataSetByWhere($"where TestSerialNumber='{serialNum}'").Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in dt.Rows)
                        {
                            var conduct = dr1[testItem].ToString();
                            if (conduct != "")
                            {
                                return 1;
                            }
                        }
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// 查询当前视图是否有测试记录
        /// </summary>
        /// <returns></returns>
        private bool IsExistTestRecore()
        {
            if (this.radGridViewCableTest.Rows.Count < 1)
                return false;
            foreach (var lv in this.radGridViewCableTest.Rows)
            {
                if (lv.Cells[5].Value.ToString() != "" || lv.Cells[7].Value.ToString() != "" || lv.Cells[9].Value.ToString() != "" || lv.Cells[11].Value.ToString() != "")
                    return true;
            }
            return false;
        }

        private bool IsExistSaveTestSerialNumber()
        {
            var count = historyDataInfoManager.GetRowCountByWhere($"where TestSerialNumber = '{this.projectTestNumber}'");
            if (count < 1)
                return false;
            return true;
        }

        /// <summary>
        /// 查询最后测试的记录
        /// </summary>
        /// <param name="projectName"></param>
        private void QueryTestInfoByProjectName(string projectName)
        {
            this.testItemStyleList.Clear();
            this.dataSourceCableTest.Clear();
            this.menu_shortCircuitTest.Enabled = false;
            this.menu_InsulationTest.Enabled = false;
            this.menu_VoltageWithStandTest.Enabled = false;
            //UpdateCurrentProTestFunStatusInfo(projectName);//防止测试合格的测试项由于人为因素导致的不合格，因此不更新测试的状态，每次打开项目就重新测试
            RadGridViewProperties.ClearGridView(this.radGridViewCableTest,this.dataSourceCableTest);
            this.projectInfo = ProjectBasicInfo.QueryProjectInfo(projectName);
            this.projectInfo.Temperature = this.deviceConfig.Temperature;
            this.projectInfo.AmbientHumidity = this.deviceConfig.Humidity;
            this.projectInfo.ResistanceCompensation = this.deviceConfig.AssCompensateVal;
            this.projectInfo.InsulateVolCompensation = this.deviceConfig.InsulateVolCompensateVal;
            this.projectInfo.InsulateResCompensation = this.deviceConfig.InsulateAssCompensateVal;
            UpdateCurProjectInfo();//保存提前配置的补偿参数
            RadGridViewProperties.SetRadGridViewProperty(this.radGridViewCableTest,false,true,14);
            //this.radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.None;
            //查询项目信息-线束代号 by projectName
            var dt = projectInfoManager.GetDataSetByFieldsAndWhere("TestCableName", $"where ProjectName='{projectName}'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                this.curLineCableName = dt.Rows[0][0].ToString();
                dt = lineStructLibraryDetailManager.GetDataSetByWhere($"where CableName='{this.curLineCableName}'").Tables[0];
                int iRow = 0;
                if (dt.Rows.Count > 0)
                {
                    bool IsInterfaceNull = true;
                    foreach (DataRow dr in dt.Rows)
                    {
                        var startInterface = dr["StartInterface"].ToString();
                        var startContactPoint = dr["StartContactPoint"].ToString();
                        var startDevPoint = dr["StartDevPoint"].ToString();
                        var endInterface = dr["EndInterface"].ToString();
                        var endContactPoint = dr["EndContactPoint"].ToString();
                        var endDevPoint = dr["EndDevPoint"].ToString();
                        var IsTestConduct = dr["IsConductTest"].ToString();
                        var IsTestCircuit = dr["IsShortCircuitTest"].ToString();
                        var IsTestInsulate = dr["IsInsulateTest"].ToString();
                        var IsTestPreasureProof = dr["IsVoltageWithStandardTest"].ToString();
                        var measuringMethod = dr["MeasureMethod"].ToString();
                        InitCableParams(this.curLineCableName, startInterface, startContactPoint, startDevPoint);
                        InitCableParams(this.curLineCableName, endInterface, endContactPoint, endDevPoint);

                        if (!IsExistGridView(startInterface,startContactPoint,endInterface,endContactPoint))
                        {
                            DataRow dataRow = this.dataSourceCableTest.NewRow();
                            dataRow[0] = (iRow + 1).ToString();
                            if (IsTestConduct == "0")
                            {
                                dataRow[5] = "--";
                                dataRow[6] = "--";
                            }
                            if (IsTestCircuit == "0")
                            {
                                dataRow[7] = "--";
                                dataRow[8] = "--";
                            }
                            if (IsTestInsulate == "0")
                            {
                                dataRow[9] = "--";
                                dataRow[10] = "--";
                            }
                            if (IsTestPreasureProof == "0")
                            {
                                dataRow[11] = "--";
                                dataRow[12] = "--";
                            }
                            dataRow[1] = startInterface;
                            dataRow[2] = startContactPoint;
                            dataRow[3] = endInterface;
                            dataRow[4] = endContactPoint;
                            dataRow[13] = measuringMethod;
                            if (startInterface != "" || endInterface != "")
                            {
                                IsInterfaceNull = false;
                            }
                            this.dataSourceCableTest.Rows.Add(dataRow);
                            iRow++;
                        }
                    }
                    if (IsInterfaceNull)
                    {
                        this.radGridViewCableTest.Columns[1].IsVisible = false;
                        this.radGridViewCableTest.Columns[3].IsVisible = false;
                    }
                    else 
                    {
                        this.radGridViewCableTest.Columns[1].IsVisible = true;
                        this.radGridViewCableTest.Columns[3].IsVisible = true;
                    }
                    this.radGridViewCableTest.DataSource = this.dataSourceCableTest;
                }
            }
        }

        private void InitCableParams(string cableName, string interName, string interPoint, string devPoint)
        {
            CableLibParams libParams = new CableLibParams();
            libParams.InterfaceName = interName;
            libParams.InterContactPoint = interPoint;
            libParams.DevInterPoint = devPoint;
            libParams.CableName = cableName;
            var cabParamsObj = this.cableLibParamList.Find(obj => obj.InterfaceName == interName && obj.InterContactPoint == interPoint && obj.CableName == cableName);
            if (cabParamsObj == null)
            {
                this.cableLibParamList.Add(libParams);
            }
        }

        private void UpdateCurrentProTestFunStatusInfo(string projectName)
        {
            //更新测试项状态，查询上一次的测试项的测试结果是否合格
            this.menu_OneKeyTest.Enabled = true;
            this.menu_ConductionTest.Enabled = true;
            var data = this.historyDataInfoManager.GetDataSetByWhere($"where ProjectName = '{projectName}' order by TestSerialNumber desc limit 1").Tables[0];
            if (data.Rows.Count <= 0)
            {
                this.menu_ConductionTest.Enabled = true;
                this.menu_shortCircuitTest.Enabled = false;
                this.menu_InsulationTest.Enabled = false;
                this.menu_VoltageWithStandTest.Enabled = false;
                return;
            }
            var conductTestResult = data.Rows[0]["ConductTestResult"].ToString();
            var circuitTestResult = data.Rows[0]["ShortCircuitTestResult"].ToString();
            var insulateTestResult = data.Rows[0]["InsulateTestResult"].ToString();
            var voltageTestResult = data.Rows[0]["VoltageWithStandardTestResult"].ToString();
            this.menu_ConductionTest.Enabled = true;
            if (conductTestResult == "合格")
            {
                this.menu_shortCircuitTest.Enabled = true;
                if (circuitTestResult == "合格")
                {
                    this.menu_InsulationTest.Enabled = true;
                    this.menu_VoltageWithStandTest.Enabled = true;
                }
                else
                {
                    this.menu_InsulationTest.Enabled = false;
                    this.menu_VoltageWithStandTest.Enabled = false;
                }
            }
            else
            {
                this.menu_shortCircuitTest.Enabled = false;
                this.menu_InsulationTest.Enabled = false;
                this.menu_VoltageWithStandTest.Enabled = false;
            }
        }

        private bool IsExistGridView(string startInterface,string startContactPoint,string endInterface,string endContactPoint)
        {
            if (this.radGridViewCableTest.Rows.Count < 1)
                return false;
            foreach(var lv in this.radGridViewCableTest.Rows)
            {
                if (startInterface == lv.Cells[1].Value.ToString() && startContactPoint == lv.Cells[2].Value.ToString() && endInterface == lv.Cells[3].Value.ToString() && endContactPoint == lv.Cells[4].Value.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region device send command 

        /*
         * 导通测试与绝缘测试、耐压测试，发送的测试内容相同
         * 短路测试不能发送相同起始接点的指令
         */ 
        private void StartVoltageWithStandardTest()
        {
            if (!IsConnectSuccess())
                return;
            if (!IsOpenTestProject())
                return;
            if (!IsSetEnvironmentParams())
                return;
            this.curTestGridViewOrderList.Clear();//清除计数
            var voltageWithStandardCommand = CommonTestSendCommand(GetConductionTestInfo(CableTestProcessParams.CableTestType.PressureWithVoltageTest), voltageWithStandardFunCode);
            if (voltageWithStandardCommand.Length < 1)
                return;
            //清空耐压异常数
            this.voltageWithStandardTestExceptCount = 0;
            LogHelper.Log.Info("耐压测试开始下发指令...");
            UnEnableTestButton();
            SuperEasyClient.SendMessage(DeviceFunCodeEnum.RequestHead, voltageWithStandardCommand);
            UpdateTestStatus("耐压已开始测试，等待测试结果...");
            //MessageBox.Show("耐压测试指令已下发", "提示", MessageBoxButtons.OK);
        }

        private void StartInsulateTest()
        {
            if (!IsConnectSuccess())
                return;
            if (!IsOpenTestProject())
                return;
            if (!IsSetEnvironmentParams())
                return;
            this.curTestGridViewOrderList.Clear();//清除计数
            var insulateCommand = CommonTestSendCommand(GetConductionTestInfo(CableTestProcessParams.CableTestType.InsulateTest), insulateTestFunCode);
            if (insulateCommand.Length < 1)
                return;
            //清空绝缘异常数
            this.insulateTestExceptCount = 0;
            LogHelper.Log.Info("绝缘测试开始下发指令...");
            this.IsFirstInsulateTest = true;
            UnEnableTestButton();
            SuperEasyClient.SendMessage(DeviceFunCodeEnum.RequestHead, insulateCommand);
            UpdateTestStatus("绝缘已开始测试，等待测试结果...");
            //MessageBox.Show("绝缘测试指令已下发", "提示", MessageBoxButtons.OK);
        }

        #region 短路测试
        private void StartCircuitTest()
        {
            if (!IsConnectSuccess())
                return;
            if (!IsOpenTestProject())
                return;
            if (!IsSetEnvironmentParams())
                return;
            this.curTestGridViewOrderList.Clear();//清除计数
            var shortCircuitCommand = CommonTestSendCommand(GetShortCircuitTestInfo(), shortCircuitTestFunCode);
            if (shortCircuitCommand.Length < 1)
                return;
            //清空短路异常数
            this.shortCircuitTestExceptCount = 0;
            LogHelper.Log.Info("短路测试开始下发指令...");
            UnEnableTestButton();
            SuperEasyClient.SendMessage(DeviceFunCodeEnum.RequestHead, shortCircuitCommand);
            UpdateTestStatus("短路已开始测试，等待测试结果...");
            //MessageBox.Show("短路测试指令已下发", "提示", MessageBoxButtons.OK);
        }

        private void UpdateTestStatus(string text)
        {
            this.Invoke(new Action(()=>
            {
                this.lbx_testStatus.Text = text;
            }));
        }

        /// <summary>
        /// 短路测试发送指令区别于导通测试-不能发送相同的起始接点
        /// </summary>
        /// <returns></returns>
        private string GetShortCircuitTestInfo()
        {
            if (this.radGridViewCableTest.Rows.Count < 1)
            {
                MessageBox.Show("没有可以测试的内容！", "提示", MessageBoxButtons.OK);
                return "";
            }
            string hexString = "";
            var method = "02";
            List<string> startInterPointList = new List<string>();
            foreach(var lv in this.radGridViewCableTest.Rows)
            {
                var startInterface = lv.Cells[1].Value.ToString();
                var startPoint = lv.Cells[2].Value.ToString();
                var startDevPoint = GetDevPointPinByContactPoint(startInterface, startPoint);
                if (startInterPointList.Contains(startPoint))
                    continue;
                startInterPointList.Add(startPoint);
                var endInterface = lv.Cells[3].Value.ToString();
                var endPoint = lv.Cells[4].Value.ToString();
                var endDevPoint = GetDevPointPinByContactPoint(endInterface, endPoint);
                var conductTestResult = lv.Cells[6].Value;
                var insulateTestResult = lv.Cells[8].Value;
                var voltageTestResult = lv.Cells[10].Value;
                var measuringMethod = lv.Cells[13].Value.ToString();
                int startpoint, endpoint;
                int.TryParse(startDevPoint, out startpoint);
                int.TryParse(endDevPoint, out endpoint);
                method = measuringMethod;
                hexString += Convert.ToString(startpoint, 16).PadLeft(4, '0') + Convert.ToString(endpoint, 16).PadLeft(4, '0');
            }
            var voltage = "0000";
            var holdTime = "00";
            hexString = Convert.ToString(method).PadLeft(2, '0') + voltage + holdTime + hexString;
            //LogHelper.Log.Info("短路测试内容："+hexString);
            return hexString;
        }
        #endregion

        private void SendSelfStudyOrProbCommand(string selfStudyString, string funCode)
        {
            byte[] selfStudyCommand = new byte[2 + selfStudyString.Length / 2];
            var selfStudyData = (funCode + " " + SplitStringByEmpty(selfStudyString)).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var commandHex = ConvertByte.HexStringToByte(selfStudyCommand, selfStudyData, 0);
            SuperEasyClient.SendMessage(DeviceFunCodeEnum.RequestHead, commandHex);
            //MessageBox.Show("已发送自学习指令！", "提示", MessageBoxButtons.OK);
        }

        private void SendResetDeviceCommand()
        {
            if (!IsConnectSuccess())
                return;
            this.Invoke(new Action(()=>
            {
                this.tool_stop.Enabled = false;
            }));
            byte[] buffer = new byte[] { 0xfa,0xaa};
            for (int i = 0; i < 2; i++)
            {
                SuperEasyClient.SendMessage(DeviceFunCodeEnum.RequestHead, buffer);
            }
            this.Invoke(new Action(()=>
            {
                this.tool_stop.Enabled = true;
            }));
        }

        #region this is conduct test content
        private void StartConductTest()
        {
            if (!IsConnectSuccess())
                return;
            if (!IsOpenTestProject())
                return;
            if (!IsSetEnvironmentParams())
                return;
            this.curTestGridViewOrderList.Clear();//清除计数
            var conductionCommand = CommonTestSendCommand(GetConductionTestInfo(CableTestProcessParams.CableTestType.ConductTest), conductionTestFunCode);
            if (conductionCommand.Length < 1)
                return;
            LogHelper.Log.Info("导通测试开始下发指令...");
            UpdateCurrentTestNumber();
            this.conductTestExceptCount = 0;//清空导通异常数
            UnEnableTestButton();
            SuperEasyClient.SendMessage(DeviceFunCodeEnum.RequestHead, conductionCommand);
            UpdateTestStatus("导通已开始测试，等待测试结果...");
            this.testStartDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //MessageBox.Show("导通测试指令已下发", "提示", MessageBoxButtons.OK);
        }

        private bool IsOpenTestProject()
        {
            if (this.documentWindow1.DockState == Telerik.WinControls.UI.Docking.DockState.Hidden)
            {
                MessageBox.Show("未打开测试项目","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private string GetConductionTestInfo(CableTestProcessParams.CableTestType cableTestType)
        {
            if (this.radGridViewCableTest.Rows.Count < 1)
            {
                MessageBox.Show("没有可以测试的内容！", "提示", MessageBoxButtons.OK);
                return "";
            }
            string hexString = "";
            var method = "";
            foreach (var lv in this.radGridViewCableTest.Rows)
            {
                var startInterface = lv.Cells[1].Value.ToString();
                var startPoint = lv.Cells[2].Value.ToString();
                var startDevPoint = GetDevPointPinByContactPoint(startInterface, startPoint);
                var endInterface = lv.Cells[3].Value.ToString();
                var endPoint = lv.Cells[4].Value.ToString();
                var endDevPoint = GetDevPointPinByContactPoint(endInterface, endPoint);
                var conductTestResult = lv.Cells[6].Value;
                var insulateTestResult = lv.Cells[8].Value;
                var voltageTestResult = lv.Cells[10].Value;
                var measuringMethod = lv.Cells[13].Value.ToString();

                int startpoint, endpoint;
                int.TryParse(startDevPoint, out startpoint);
                int.TryParse(endDevPoint, out endpoint);
                method = measuringMethod;
                hexString += Convert.ToString(startpoint, 16).PadLeft(4, '0') + Convert.ToString(endpoint, 16).PadLeft(4, '0');
            }
            var voltage = "0000";
            var holdTime = "00";
            if (cableTestType == CableTestProcessParams.CableTestType.InsulateTest)
            {
                if (this.projectInfo.InsulateTestVoltage != 0)
                {
                    voltage = Convert.ToString((int)this.projectInfo.InsulateTestVoltage, 16).PadLeft(4, '0');
                    if (this.deviceConfig.CompensateState == "1")
                    {
                        voltage = Convert.ToString((int)this.projectInfo.InsulateTestVoltage + (int)this.projectInfo.InsulateVolCompensation, 16).PadLeft(4, '0');
                    }
                }
                if (this.projectInfo.InsulateTestHoldTime != 0)
                {
                    holdTime = Convert.ToString((int)this.projectInfo.InsulateTestHoldTime, 16).PadLeft(2, '0');
                }
                hexString = Convert.ToString(method).PadLeft(2, '0') + voltage + holdTime + hexString;
            }
            else
            {
                hexString = Convert.ToString(method).PadLeft(2, '0') + voltage + holdTime + hexString;
            }
            return hexString;
        }

        private string GetDevPointPinByContactPoint(string interfaceName,string point)
        {
            //CableLibParams
            var cableParamsObj = this.cableLibParamList.Find(obj => obj.InterfaceName == interfaceName && obj.InterContactPoint == point && obj.CableName == this.curLineCableName);
            if (cableParamsObj != null)
            {
                return cableParamsObj.DevInterPoint;
            }
            return "";
        }

        #endregion

        /// <summary>
        /// 测试指令
        /// </summary>
        /// <param name="testCommandString">测试接点内容</param>
        /// <param name="testFunCode">功能码</param>
        /// <param name="testMethod">二线法/四线法，02/04</param>
        /// <returns></returns>
        private byte[] CommonTestSendCommand(string testCommandString,string testFunCode)
        {
            //eg:FF FF 00 0D F2 AA 00 01 00 02 00 03 00 06 01 02 01 0A
            //explain:1-2,3-6,258-266
            if (testCommandString.Length < 1)
                return new byte[0];
            byte[] conductionByte = new byte[2 + testCommandString.Length / 2];
            var conductArray = (testFunCode + " " + SplitStringByEmpty(testCommandString)).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return ConvertByte.HexStringToByte(conductionByte, conductArray, 0);
        }

        private string SplitStringByEmpty(string hexString)
        {
            var arrayString = string.Empty;
            var conductionInfoChar = hexString.ToCharArray();
            for (int i = 0; i < conductionInfoChar.Length; i += 2)
            {
                arrayString += conductionInfoChar[i].ToString() + conductionInfoChar[i + 1].ToString() + " ";
            }
            return arrayString;
        }

        /// <summary>
        ///  保存数据时，生成测试序列
        /// </summary>
        private void UpdateCurrentTestNumber()
        {
            var historyData = historyDataInfoManager.GetDataSetByFieldsAndWhere("TestSerialNumber", "order by TestSerialNumber desc limit 1").Tables[0];
            if (historyData.Rows.Count < 1)
            {
                this.projectTestNumber = "1".PadLeft(this.projectTestNumberLen, '0');
                return;
            }
            var testNumberStr = historyData.Rows[0][0].ToString().Trim();
            var testNumber = 0;
            if (testNumberStr.Length > this.projectTestNumberLen)
                this.projectTestNumberLen = testNumberStr.Length;
            int.TryParse(testNumberStr,out testNumber);
            this.projectTestNumber = (testNumber + 1).ToString().PadLeft(this.projectTestNumberLen, '0');
        }

        private bool IsSetEnvironmentParams()
        {
            if (this.projectInfo.Temperature == 0 && this.projectInfo.AmbientHumidity == 0)
            {
                if (MessageBox.Show("环境参数未设置，是否立即设置？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (OpenEnvironmentParamsSet())
                    {
                        IsSetEnvironmentParams();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private void UpdateCurrentGridView()
        {
            //单独测试：点击导通测试时，全部重置
            //一键测试：全部重置
            foreach (var rowInfo in this.radGridViewCableTest.Rows)
            {
                rowInfo.Cells[5].Value = "--";
                rowInfo.Cells[6].Value = "--";

                rowInfo.Cells[7].Value = "--";
                rowInfo.Cells[8].Value = "--";

                rowInfo.Cells[9].Value = "--";
                rowInfo.Cells[10].Value = "--";

                rowInfo.Cells[11].Value = "--";
                rowInfo.Cells[12].Value = "--";
            }
        }

        private void UpdateCurrentGridView1()
        {
            CableTestProcessParams.CableTestType[] cableTestTypeArray = new CableTestProcessParams.CableTestType[this.cableTestProcessQueue.Count];
            this.cableTestProcessQueue.CopyTo(cableTestTypeArray, 0);
            if (this.radGridViewCableTest.RowCount < 1)
                return;
            if (cableTestTypeArray.Length <= 0)
                return;
            CableTestProcessParams.CableTestType conductCableTestType = CableTestProcessParams.CableTestType.None;
            CableTestProcessParams.CableTestType circuitCableTestType = CableTestProcessParams.CableTestType.None;
            CableTestProcessParams.CableTestType insulateCableTestType = CableTestProcessParams.CableTestType.None;
            CableTestProcessParams.CableTestType voltageCableTestType = CableTestProcessParams.CableTestType.None;

            foreach (var sectItem in cableTestTypeArray)
            {
                if (sectItem == CableTestProcessParams.CableTestType.ConductTest)
                {
                    conductCableTestType = CableTestProcessParams.CableTestType.ConductTest;
                }
                else if (sectItem == CableTestProcessParams.CableTestType.InsulateTest)
                {
                    insulateCableTestType = CableTestProcessParams.CableTestType.InsulateTest;
                }
                else if (sectItem == CableTestProcessParams.CableTestType.ShortCircuitTest)
                {
                    circuitCableTestType = CableTestProcessParams.CableTestType.ShortCircuitTest;
                }
                else if (sectItem == CableTestProcessParams.CableTestType.PressureWithVoltageTest)
                {
                    voltageCableTestType = CableTestProcessParams.CableTestType.PressureWithVoltageTest;
                }
            }

            if (this.cableTestProcessOneKey.CableTestMethodEnum == CableTestProcess.CableTestMethod.SignalTest)
            {
            }
            else if (this.cableTestProcessOneKey.CableTestMethodEnum == CableTestProcess.CableTestMethod.OneKeyTest)
            { 
            }
        }
        #endregion

        /// <summary>
        /// 保存测试记录：测试中/测试完成
        /// 多次保存的保存序列相同，每启动一次测试生成一个新测试序列
        /// </summary>
        private void SaveTestResult()
        {

            lock (this)
            {
                if (this.radGridViewCableTest.Rows.Count < 1)
                    return;
                if (!IsExistTestRecore())//没有测试记录
                    return;
                if (IsExistSaveTestSerialNumber())//已保存该测试序列
                {
                    //delete current test number ,reSave latest test data
                    var del1 = historyDataInfoManager.DeleteByWhere($"where TestSerialNumber='{this.projectTestNumber}'");
                    var del2 = historyDataDetailManager.DeleteByWhere($"where TestSerialNumber='{this.projectTestNumber}'");
                    UpdateCurrentTestNumber();
                }
                //var projectInfoData = this.projectInfoManager.GetDataSetByWhere($"where ProjectName = '{this.currentTestProject}'").Tables[0];
                var updateBasicCount = 0;
                var updateDetailCount = 0;

                if (this.projectTestNumber == "")
                    return;

                #region project test basic info
                THistoryDataBasic historyDataInfo = new THistoryDataBasic();
                historyDataInfo.ID = TablePrimaryKey.InsertHistoryBasicPID();
                historyDataInfo.TestSerialNumber = this.projectTestNumber;
                historyDataInfo.ProjectName = this.projectInfo.ProjectName;
                historyDataInfo.TestCableName = this.projectInfo.TestCableName;
                historyDataInfo.TestStartDate = this.testStartDate;
                historyDataInfo.TestEndDate = this.testEndDate;
                historyDataInfo.TestOperator = LocalLogin.currentUserName;
                historyDataInfo.EnvironmentTemperature = this.projectInfo.Temperature.ToString();
                historyDataInfo.EnvironmentAmbientHumidity = this.projectInfo.AmbientHumidity.ToString();
                // CalFinalTestResult(this.projectInfo.ProjectName, this.projectInfo.TestCableName, this.projectTestNumber);
                historyDataInfo.ConductThreshold = this.projectInfo.ConductTestThreshold;
                historyDataInfo.ConductVoltage = this.projectInfo.ConductTestVoltage;
                historyDataInfo.ConductElect = this.projectInfo.ConductTestCurrentElect;
                historyDataInfo.ShortCircuitThreshold = this.projectInfo.ShortCircuitTestThreshold;
                historyDataInfo.InsulateThreshold = this.projectInfo.InsulateTestThreshold;
                historyDataInfo.InsulateHoldTime = this.projectInfo.InsulateTestHoldTime;
                historyDataInfo.InsulateVoltage = this.projectInfo.InsulateTestVoltage;
                historyDataInfo.InsulateRaiseTime = this.projectInfo.InsulateTestRaiseTime;
                historyDataInfo.VoltageWithStandardThreshold = this.projectInfo.VoltageWithStandardThreshold;
                historyDataInfo.VoltageWithStandardHoldTime = this.projectInfo.VoltageWithStandardHoldTime;
                historyDataInfo.VoltageWithStandardVoltage = this.projectInfo.VoltageWithStandardVoltage;

                historyDataInfo.ConductTestResult = CalTestItemResult(6);
                historyDataInfo.ShortCircuitTestResult = CalTestItemResult(8);
                historyDataInfo.InsulateTestResult = CalTestItemResult(10);
                if (historyDataInfo.ConductTestResult == "未测试")
                {
                    historyDataInfo.FinalTestResult = "未测试";
                }
                else if (historyDataInfo.ConductTestResult == "合格" && historyDataInfo.ShortCircuitTestResult == "合格" && historyDataInfo.InsulateTestResult == "合格")
                {
                    historyDataInfo.FinalTestResult = "合格";
                }
                else
                {
                    historyDataInfo.FinalTestResult = "不合格";
                }

                historyDataInfo.ConductTestExceptCount = this.conductTestExceptCount;
                historyDataInfo.ShortcircuitTestExceptCount = this.shortCircuitTestExceptCount;
                historyDataInfo.InsulateTestExceptCount = this.insulateTestExceptCount;
                historyDataInfo.VoltageWithStandardTestExceptCount = this.voltageWithStandardTestExceptCount;
                updateBasicCount += historyDataInfoManager.Insert(historyDataInfo);
                #endregion

                #region project test detail info
                List<THistoryDataDetail> hisDataDetailList = new List<THistoryDataDetail>();
                int iRow = 0;
                foreach (var lv in this.radGridViewCableTest.Rows)
                {
                    THistoryDataDetail historyDataDetail = new THistoryDataDetail();
                    historyDataDetail.ID = TablePrimaryKey.InsertHistoryDetailPID() + iRow;
                    historyDataDetail.TestSerialNumber = this.projectTestNumber.ToString();
                    historyDataDetail.ProjectName = this.projectInfo.ProjectName;
                    if (lv.Cells[1].Value != null)
                        historyDataDetail.StartInterface = lv.Cells[1].Value.ToString();
                    if (lv.Cells[2].Value != null)
                        historyDataDetail.StartContactPoint = lv.Cells[2].Value.ToString();
                    if (lv.Cells[3].Value != null)
                        historyDataDetail.EndInterface = lv.Cells[3].Value.ToString();
                    if (lv.Cells[4].Value != null)
                        historyDataDetail.EndContactPoint = lv.Cells[4].Value.ToString();
                    if (lv.Cells[5].Value != null)
                        historyDataDetail.ConductValue = lv.Cells[5].Value.ToString();
                    if (lv.Cells[6].Value != null)
                        historyDataDetail.ConductTestResult = lv.Cells[6].Value.ToString();
                    if (lv.Cells[7].Value != null)
                        historyDataDetail.ShortCircuitValue = lv.Cells[7].Value.ToString();
                    if (lv.Cells[8].Value != null)
                        historyDataDetail.ShortCircuitTestResult = lv.Cells[8].Value.ToString();
                    if (lv.Cells[9].Value != null)
                        historyDataDetail.InsulateValue = lv.Cells[9].Value.ToString();
                    if (lv.Cells[10].Value != null)
                        historyDataDetail.InsulateTestResult = lv.Cells[10].Value.ToString();
                    iRow++;
                    hisDataDetailList.Add(historyDataDetail);
                }

                foreach (DataRow lv in this.dataSourceInsulateTest.Rows)
                {
                    THistoryDataDetail historyDataDetail = new THistoryDataDetail();
                    historyDataDetail.ID = TablePrimaryKey.InsertHistoryDetailPID() + iRow;
                    historyDataDetail.TestSerialNumber = this.projectTestNumber.ToString();
                    historyDataDetail.ProjectName = this.projectInfo.ProjectName;
                    historyDataDetail.StartInterface = lv[1].ToString();
                    historyDataDetail.StartContactPoint = lv[2].ToString();
                    historyDataDetail.EndInterface = lv[3].ToString();
                    historyDataDetail.EndContactPoint = lv[4].ToString();
                    historyDataDetail.ConductValue = lv[5].ToString();
                    historyDataDetail.ConductTestResult = lv[6].ToString();
                    historyDataDetail.ShortCircuitValue = lv[7].ToString();
                    historyDataDetail.ShortCircuitTestResult = lv[8].ToString();
                    historyDataDetail.InsulateValue = lv[9].ToString();
                    historyDataDetail.InsulateTestResult = lv[10].ToString();
                    hisDataDetailList.Add(historyDataDetail);
                }

                updateDetailCount += historyDataDetailManager.Insert(hisDataDetailList);
                #endregion

                if (updateBasicCount > 0)
                {
                    //success
                }
            }

        }

        private void StartSelfCheck()
        {
            var commandStr = "02";
            var conductionCommand = CommonTestSendCommand(commandStr, "FB AA");
            if (conductionCommand.Length < 1)
                return;
            LogHelper.Log.Info("设备开始自检...");
            SuperEasyClient.SendMessage(DeviceFunCodeEnum.RequestHead, conductionCommand);
        }
    }
}
