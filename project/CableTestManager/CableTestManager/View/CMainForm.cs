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
using CableTestManager.Business;
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
using CommonUtils.FileHelper;
using CommonUtil.CUserManager;
using CommonUtils.ByteHelper;
using System.IO;
using CableTestManager.Properties;
using CableTestManager.Model;
using CableTestManager.ClientSocket.AppBase;
using CableTestManager.Common;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.xmp;
using iTextSharp.awt;
using iTextSharp.testutils;
using CommonUtils.PDF;

namespace CableTestManager.View
{
    public partial class CMainForm : Telerik.WinControls.UI.RadForm
    {
        private KLineTestProcessor gLineTestProcessor;
        private TProjectBasicInfoManager projectInfoManager;
        private THistoryDataDetailManager historyDataDetailManager;
        private THistoryDataBasicManager historyDataInfoManager;
        private TCableTestLibraryManager lineStructLibraryDetailManager;
        private CableJudgeThreshold cableJudgeThreshold;
        private TProjectBasicInfo projectInfo;
        private System.Timers.Timer sysTimer;
        private System.Timers.Timer refreshDataTimer;

        private bool IsConnectServer;
        private string serviceURL = "";
        private int servicePort;
        private string currentTestProject;
        private string reportDirectory;
        
        //当前测试项目的测试项的异常数
        private int conductTestExceptCount;
        private int shortCircuitTestExceptCount;
        private int insulateTestExceptCount;
        private int voltageWithStandardTestExceptCount;
        
        //测试项阈值：判断是否合格的标准值，打开当前项目时更新测试标准
        private double conductPassThreshold;
        private double shortCircuitPassThreshold;
        private double insulatePassThreshold;
        private double voltageWithStandardPassThreshold;

        private double environmentTemperature;
        private double environmentAmbientHumidity;
        private string deviceTypeNo;
        /// <summary>
        /// 项目测试序列，每次启动测试便生成一个新序列
        /// </summary>
        private string projectTestNumber;

        /// <summary>
        /// 项目测试序列长度，超过最大长度会自动延长
        /// </summary>
        private int projectTestNumberLen = 8;
        private string startTestDate;
        private string endTestDate;
        private string curExportedReportAbsPath;

        /*
         * 导通测试完成后，开放短路测试
         * 短路测试完成后，开放绝缘测试与耐压测试
         * 一键测试：可配置一键测试的测试项
         * 
         *需要读取各项测试的测试状态：是否完成过测试
         * 每个测试序列/测试线束，每次完成测试后存储测试状态，若此测试线束发生修改后是否更新测试状态为-未测试
         * 
         */

        #region 测试项最新完成状态，每次测试有完成即更新测试状态
        private bool IsConductLatestCompleteStatus;
        private bool IsShortCircuitLatestCompleteStatus;
        private bool IsInsulateLatestCompleteStatus;
        private bool IsVoltageWithStandardLatestCompleteStatus;
        #endregion

        #region INI CONFIG FILE FOR FIXED TESTER STANDARD DEFAULT PARAMS

        private string CONDUCTION_THRESHOLD = "100";
        private string IS_CONDUCTION_JUDGE_THAN_THRESHOLD = "0";//小于或等于标准值
        
        private string INSULATE_THRESHOLD = "20";
        private string IS_INSULATE_JUDGE_THAN_THRESHOLD = "1";
        private string INSULATE_VOLTAGE = "100";
        private string INSULATE_HOLD_TIME = "1";

        private string PRESSURE_PROOF_THRESHOLD = "2";
        private string IS_PRESSURE_JUDGE_THAN_THRESHOLD = "0";
        private string PRESSURE_PROOF_VOLTAGE = "100";
        private string PRESSURE_PROOF_HOLD_TIME = "1";

        private const string CONFIG_DIRECTORY_NAME = "CONFIG";
        private const string CONFIG_SECTION_NAME = "FIX_STANDARD_PARAMS";
        private const string CONFIG_SECTION_TEST_NAME = "TEST_INFO";
        private const string PROJECT_TEST_NUMBER_LEN_KEY = "test_number_length";
        private const string CONDUCTION_THRESHOLD_KEY = "conduction_threshold";
        private const string IS_CONDUCTION_JUDGE_THAN_THRESHOLD_KEY = "conduction_judge_than_threshold";
        private const string INSULATE_THRESHOLD_KEY = "insulate_threshold";
        private const string IS_INSULATE_JUDGE_THAN_THRESHOLD_KEY = "insulate_judge_than_threshold";
        private const string INSULATE_VOLTAGE_KEY = "insulate_voltage";
        private const string INSULATE_HOLD_TIME_KEY = "insulate_hold_time";
        private const string PRESSURE_PROOF_THRESHOLD_KEY = "pressure_proof_threshold";
        private const string IS_PRESSURE_JUDGE_THAN_THRESHOLD_KEY = "is_pressure_judge_than_threshold";
        private const string PRESSURE_PROOF_VOLTAGE_KEY = "pressure_proof_voltage";
        private const string PRESSURE_PROOF_HOLD_TIME_KEY = "pressure_proof_hold_time";
        #endregion

        #region 常量
        public const string CableTestSystemName = "线束测试系统";

        private string configPath;
        private const string DEVICE_CONFIG_FILE_NAME = "DeviceConfig.ini";
        private const string DEVICE_CONFIG_SECTION = "service";
        private const string DEVICE_CONFIG_IS_AUTO_KEY = "IsAutoConnect";
        private const string DEVICE_CONFIG_SERVER_URL_KEY = "serviceURL";
        private const string DEVICE_CONFIG_SERVER_PORT_KEY = "servicePort";

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
        #endregion

        private const string REPORT_SECTION_PATH = "REPORT";
        private const string REPORT__KEY_FILE_DIR = "reportDir";

        //private DoubleBufferListView listViewSelfStudy;
        private string curLineCableName;
        private List<SelfStudyParams> studyParamList;
        private List<SelfStudyParams> probParamList = new List<SelfStudyParams>();
        private List<SelfStudyParams> studyParamValidList;
        private List<CableTestParams> cableTestPramsList;
        private DataTable dataSourceSelfStudy,dataSourceCableTest,dataSourceProb;
        private bool IsFirstSetGridDTStyle, IsFirstSetGridUnDTStyle, IsFirstSetGridOpenCirStyle;
        private bool IsFirstSetGridDTProbStyle, IsFirstSetGridUnDTProbStyle, IsFirstSetGridOpenCirProbStyle;
        private CableTestProcess cableTestProcessOneKey;//一键测试对象
        //private CableTestProcessParams.CableTestType currentCableTestType;//一键测试时使用
        private CableTestProcessParams cableTestProcessSig;//单项测试对象
        private Queue<CableTestProcessParams.CableTestType> cableTestProcessQueue;
        private List<string> testItemStyleList = new List<string>();
        private List<CableLibParams> cableLibParamList = new List<CableLibParams>();

        private ProbTestConfig probConfig = new ProbTestConfig();
        private SelfStudyConfig studyConfig = new SelfStudyConfig();

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
                var data = funLimitManager.GetDataSetByWhere($"where UserRole='{LocalLogin.currentUserType}'").Tables[0];
                if (data.Rows.Count > 0)
                {
                    foreach (DataRow dr in data.Rows)
                    {
                        this.tool_HarnessLibrary.Visible = ConvertDec2State(dr["CableLib"].ToString());
                        this.menu_shortCircuitTest.Visibility = ConvertDec2EleVisState(dr["ShortCircuitTest"].ToString());
                        this.menu_ConductionTest.Visibility = ConvertDec2EleVisState(dr["ConductTest"].ToString());
                        this.menu_connectorLibrary.Visibility = ConvertDec2EleVisState(dr["ConnectorLib"].ToString());
                        this.menu_devCalibration.Visibility = ConvertDec2EleVisState(dr["DeviceCalibration"].ToString());
                        this.menu_devDebugAssitant.Visibility = ConvertDec2EleVisState(dr["DeviceDebug"].ToString());
                        this.menu_devSelfCheck.Visibility = ConvertDec2EleVisState(dr["DeviceSelfCheck"].ToString());
                        this.tool_testEnvironment.Visibility = ConvertDec2EleVisState(dr["EnvironmentalParameters"].ToString());
                        this.menu_ExportReport.Visibility = ConvertDec2EleVisState(dr["ExcuteReport"].ToString());
                        this.menu_faultCode.Visibility = ConvertDec2EleVisState(dr["DeviceFaultQuery"].ToString());
                        this.menu_InsulationTest.Visibility = ConvertDec2EleVisState(dr["InsulateTest"].ToString());
                        this.tool_InterfaceLibrary.Visible = ConvertDec2State(dr["InterfaceLib"].ToString());
                        this.tool_NewProject.Visible = ConvertDec2State(dr["NewProject"].ToString());
                        this.menu_OneKeyTest.Visibility = ConvertDec2EleVisState(dr["OneKeyTest"].ToString());
                        this.menu_operateLog.Visibility = ConvertDec2EleVisState(dr["OperatorRecord"].ToString());
                        this.menu_PrintReport.Visibility = ConvertDec2EleVisState(dr["PrintReport"].ToString());
                        this.tool_Probe.Visible = ConvertDec2State(dr["Probe"].ToString());
                        this.tool_OpenProject.Visible = ConvertDec2State(dr["ProjectManage"].ToString());
                        this.tool_reportSavePath.Visibility = ConvertDec2EleVisState(dr["ReportConfigPath"].ToString());
                        this.menu_ResistanceCompensationManage.Visibility = ConvertDec2EleVisState(dr["ResistanceCompensationManage"].ToString());
                        this.menu_SaveData.Visibility = ConvertDec2EleVisState(dr["SaveTestData"].ToString());
                        this.tool_SelfStudy.Visible = ConvertDec2State(dr["SelfStudy"].ToString());
                        this.menu_StartResistanceCompensation.Visibility = ConvertDec2EleVisState(dr["StartResistanceCompensation"].ToString());
                        this.menu_switchStandMapLib.Visibility = ConvertDec2EleVisState(dr["SwitchStandLib"].ToString());
                        this.menu_switchWorkWearLib.Visibility = ConvertDec2EleVisState(dr["SwitchWearLib"].ToString());
                        this.tool_HistoryData.Visible = ConvertDec2State(dr["HistoryTestData"].ToString());
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

            //this.listViewSelfStudy = new DoubleBufferListView();
            //this.panelView.Controls.Add(this.listViewSelfStudy);
            //this.listViewSelfStudy.Dock = DockStyle.Fill;

            this.cableTestProcessOneKey = new CableTestProcess();
            this.cableTestProcessSig = new CableTestProcessParams();
            this.cableTestProcessQueue = new Queue<CableTestProcessParams.CableTestType>();
            this.studyParamList = new List<SelfStudyParams>();
            this.studyParamValidList = new List<SelfStudyParams>();
            this.cableTestPramsList = new List<CableTestParams>();
            this.projectInfoManager = new TProjectBasicInfoManager();
            this.historyDataInfoManager = new THistoryDataBasicManager();
            this.historyDataDetailManager = new THistoryDataDetailManager();
            lineStructLibraryDetailManager = new TCableTestLibraryManager();
            refreshDataTimer = new System.Timers.Timer();
            refreshDataTimer.Interval = 5;
            refreshDataTimer.AutoReset = true;

            projectInfo = new TProjectBasicInfo();
            sysTimer = new System.Timers.Timer();
            sysTimer.Start();

            #region update control status
            this.menu_InsulationTest.Enabled = true;
            this.menu_shortCircuitTest.Enabled = true;
            this.menu_VoltageWithStandTest.Enabled = true;
            #endregion

            configPath = AppDomain.CurrentDomain.BaseDirectory + "config\\";
            if (!Directory.Exists(configPath))
                Directory.CreateDirectory(configPath);
            this.lbx_curLoginUser.Text = LocalLogin.currentUserName;
            InitDefaultConfig();
            UpdateTreeView();
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
                RadGridViewProperties.SetRadGridViewProperty(this.radGridViewSelfStudy,false,true,0);
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
            RadGridViewProperties.SetRadGridViewProperty(this.radGridViewProb, false, true, 0);
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
            #endregion

            #region menu event
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
            #endregion

            this.FormClosed += CMainForm_FormClosed;
            this.radTreeView1.NodeMouseDoubleClick += RadTreeView1_NodeMouseDoubleClick;
            this.sysTimer.Elapsed += SysTimer_Elapsed;
            this.SizeChanged += CMainForm_SizeChanged;
            this.refreshDataTimer.Elapsed += RefreshDataTimer_Elapsed;

            SuperEasyClient.NoticeConnectEvent += SuperEasyClient_NoticeConnectEvent;
            SuperEasyClient.NoticeMessageEvent += SuperEasyClient_NoticeMessageEvent;
        }

        private void Tool_reportSavePath_Click(object sender, EventArgs e)
        {
            SetDefaultSavePath setDefaultSavePath = new SetDefaultSavePath(this.reportDirectory);
            if (setDefaultSavePath.ShowDialog() == DialogResult.OK)
            {
                this.reportDirectory = setDefaultSavePath.reportDir;
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
        }

        private void Menu_newProject_Click(object sender, EventArgs e)
        {
            NewProject();
        }

        private void Menu_ExportReport_Click(object sender, EventArgs e)
        {
            ExportReport();
            if (MessageBox.Show("是否打开报表？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (File.Exists(this.curExportedReportAbsPath))
                {
                    System.Diagnostics.Process.Start(this.curExportedReportAbsPath);
                }
            }
        }

        private void Menu_PrintReport_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.curExportedReportAbsPath))
            {
                PDFPrint.UseDefaultPrinter(this.curExportedReportAbsPath);
            }
            else
            {
                ExportReport();
                if (File.Exists(this.curExportedReportAbsPath))
                {
                    PDFPrint.UseDefaultPrinter(this.curExportedReportAbsPath);
                }
            }
        }

        private void ExportReport()
        {
            if (!Directory.Exists(this.reportDirectory))
            {
                Directory.CreateDirectory(this.reportDirectory);
            }
            this.curExportedReportAbsPath = this.reportDirectory + "线束测试报告_"+ this.projectTestNumber + ".pdf";
            ExportPDF(this.curExportedReportAbsPath);
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
                int iRow = 0;
                foreach (var rowInfo in this.studyParamValidList)
                {
                    if (rowInfo.TestReulst == "不导通")
                        continue;
                    else if (rowInfo.TestReulst == "导通")
                    {
                        TCableTestLibrary cableTestLibrary = new TCableTestLibrary();
                        cableTestLibrary.ID = CableTestManager.Common.TablePrimaryKey.InsertCableLibPID();
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
                        this.lineStructLibraryDetailManager.Insert(cableTestLibrary);
                        iRow++;
                    }
                }
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
            this.dataSourceSelfStudy.Rows.Clear();
            this.radGridViewSelfStudy.DataSource = this.dataSourceSelfStudy;
            this.studyParamValidList.Clear();
        }

        private void RefreshDataTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdateTestSelfStudyGridView();
            UpdateTestResultByTestPoint();
            UpdateProbTestGridView();
        }
       
        private void CMainForm_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void Tool_testEnvironment_Click(object sender, EventArgs e)
        {
            OpenEnvironmentParamsSet();
        }

        private bool OpenEnvironmentParamsSet()
        {
            FrmEnvironmentParams environmentParaSet = new FrmEnvironmentParams();
            if (environmentParaSet.ShowDialog() == DialogResult.OK)
            {
                this.environmentTemperature = environmentParaSet.temperature;
                this.environmentAmbientHumidity = environmentParaSet.ambientHumidity;
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
                MessageBox.Show("设备未连接！", "提示", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void CMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveDeviceConfig();
        }

        private void SuperEasyClient_NoticeMessageEvent(ClientSocket.AppBase.MyPackageInfo packageInfo)
        {
            LogHelper.Log.Info($"接收到消息：头= {BitConverter.ToString(packageInfo.Header)} 内容="+BitConverter.ToString(packageInfo.Data));
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
                this.refreshDataTimer.Enabled = false;
            }
            else if (packageInfo.Data[4] == 0xf6 && packageInfo.Data[5] == 0xbb)//探针
            {
                ProbTestProcess(packageInfo);
            }
            else if (packageInfo.Data[4] == 0xf6 && packageInfo.Data[5] == 0xcc)//探针结束
            {
                this.refreshDataTimer.Enabled = false;
            }
            else if (packageInfo.Data[4] == 0xf2 && packageInfo.Data[5] == 0xbb)//导通测试
            {
                TestItemProcess(packageInfo, 5);
            }
            else if (packageInfo.Data[4] == 0xf2 && packageInfo.Data[5] == 0xcc)//导通测试结束
            {
                this.IsConductLatestCompleteStatus = true;//更新导通测试最新测试状态
                //保存测试状态与结果数据
                //更新UI最终测试结果
                //检查是否进行下一项测试
                TestItemComplete(CableTestProcessParams.CableTestType.ConductTest, this.cableTestProcessSig.CableTestTypeEnum);
            }
            else if (packageInfo.Data[4] == 0xf3 && packageInfo.Data[5] == 0xbb)//短路测试测试
            {
                TestItemProcess(packageInfo, 7);
            }
            else if (packageInfo.Data[4] == 0xf3 && packageInfo.Data[5] == 0xcc)//短路测试结束
            {
                TestItemComplete(CableTestProcessParams.CableTestType.ShortCircuitTest, this.cableTestProcessSig.CableTestTypeEnum);
            }
            else if (packageInfo.Data[4] == 0xf4 && packageInfo.Data[5] == 0xbb)//绝缘测试
            {
                TestItemProcess(packageInfo, 9);
            }
            else if (packageInfo.Data[4] == 0xf4 && packageInfo.Data[5] == 0xcc)//绝缘测试结束
            {
                TestItemComplete(CableTestProcessParams.CableTestType.InsulateTest, this.cableTestProcessSig.CableTestTypeEnum);
            }
            else if (packageInfo.Data[4] == 0xf5 && packageInfo.Data[5] == 0xbb)//耐压测试测试
            {
                TestItemProcess(packageInfo, 11);
            }
            else if (packageInfo.Data[4] == 0xf5 && packageInfo.Data[5] == 0xcc)//耐压测试测试结束
            {
                TestItemComplete(CableTestProcessParams.CableTestType.PressureWithVoltageTest, this.cableTestProcessSig.CableTestTypeEnum);
            }
        }

        private void TestItemProcess(MyPackageInfo packageInfo, int startIndex)
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
            var calResult = resistance * factor;
            var conductResult = "";
            if (calResult <= this.conductPassThreshold)
                conductResult = "合格";
            else
                conductResult = "不合格";
            CableTestParams cableTestParams = new CableTestParams();
            cableTestParams.StartPoint = Convert.ToInt32(startInterPoint, 16).ToString();
            cableTestParams.EndPoint = Convert.ToInt32(endInterPoint, 16).ToString();
            cableTestParams.TestResultVal = calResult.ToString("f2");
            cableTestParams.TestReulst = conductResult;
            cableTestParams.StartIndex = startIndex;
            this.cableTestPramsList.Add(cableTestParams);
            this.refreshDataTimer.Enabled = true;
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
            var calResult = resistance * factor;
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
            studyParams.TestResultVal = calResult.ToString("f2");
            studyParams.TestReulst = selfStudyResult;
            this.studyParamList.Add(studyParams);
            
            this.refreshDataTimer.Enabled = true;
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
            var calResult = resistance * factor;
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
            this.probParamList.Add(studyParams);

            this.refreshDataTimer.Enabled = true;
        }

        private void TestItemComplete(CableTestProcessParams.CableTestType cableTestType, CableTestProcessParams.CableTestType sigTestType)
        {
            this.refreshDataTimer.Enabled = false;
            if (this.cableTestProcessOneKey.CableTestMethodEnum == CableTestProcess.CableTestMethod.OneKeyTest)
            {
                //更新状态
                this.Invoke(new Action(() =>
                {
                    if (cableTestType == CableTestProcessParams.CableTestType.ConductTest)
                    {
                        this.menu_ConductionTest.Enabled = true;
                        this.menu_shortCircuitTest.Enabled = true;
                        this.lbx_testStatus.Text = "导通测试已完成";
                        this.lbx_testStatus.ForeColor = Color.Red;
                        this.lbx_conductExCount.Text = FinalCalExceptCount(6) + "";
                    }
                    else if (cableTestType == CableTestProcessParams.CableTestType.ShortCircuitTest)
                    {
                        this.menu_ConductionTest.Enabled = true;
                        this.menu_shortCircuitTest.Enabled = true;
                        this.menu_InsulationTest.Enabled = true;
                        this.menu_VoltageWithStandTest.Enabled = true;
                        this.lbx_testStatus.Text = "短路测试已完成";
                        this.lbx_testStatus.ForeColor = Color.Red;
                        this.lbx_shortCircuitExCount.Text = FinalCalExceptCount(8) + "";
                    }
                    else if (cableTestType == CableTestProcessParams.CableTestType.InsulateTest)
                    {
                        this.menu_ConductionTest.Enabled = true;
                        this.menu_shortCircuitTest.Enabled = true;
                        this.menu_InsulationTest.Enabled = true;
                        this.menu_VoltageWithStandTest.Enabled = true;
                        this.lbx_testStatus.Text = "绝缘测试已完成";
                        this.lbx_testStatus.ForeColor = Color.Red;
                        this.lbx_insulateExCount.Text = FinalCalExceptCount(10) + "";
                    }
                    else if (cableTestType == CableTestProcessParams.CableTestType.PressureWithVoltageTest)
                    {
                        this.menu_ConductionTest.Enabled = true;
                        this.menu_shortCircuitTest.Enabled = true;
                        this.menu_InsulationTest.Enabled = true;
                        this.menu_VoltageWithStandTest.Enabled = true;
                        this.lbx_testStatus.Text = "耐压测试已完成";
                        this.lbx_testStatus.ForeColor = Color.Red;
                        this.menu_VoltageWithStandTest.Enabled = true;
                        this.lbx_voltageExCount.Text = FinalCalExceptCount(12) + "";
                    }
                    this.lbx_conRelationCount.Text = this.radGridViewCableTest.RowCount + "";
                }));

                //更新当前测试项完成状态
                var curTestObj = this.cableTestProcessOneKey.CableTestProcessParamsList.Find(obj => obj.CableTestTypeEnum == cableTestType);
                curTestObj.TestItemStateEnum = CableTestProcessParams.TestState.Completed;
                curTestObj.TestItemEndDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                //查找下一测试项
                if (this.cableTestProcessQueue.Count == 0)//一键测试结束
                {
                    RefreshTestItemControl();
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
            else
            {
                this.Invoke(new Action(() =>
                {
                    if (sigTestType == CableTestProcessParams.CableTestType.ConductTest)
                    {
                        this.menu_ConductionTest.Enabled = true;
                        this.menu_shortCircuitTest.Enabled = true;
                        this.lbx_testStatus.Text = "导通测试已完成";
                        this.lbx_testStatus.ForeColor = Color.Red;
                        this.lbx_conductExCount.Text = FinalCalExceptCount(6) + "";
                    }
                    else if (sigTestType == CableTestProcessParams.CableTestType.ShortCircuitTest)
                    {
                        this.menu_ConductionTest.Enabled = true;
                        this.menu_shortCircuitTest.Enabled = true;
                        this.menu_InsulationTest.Enabled = true;
                        this.menu_VoltageWithStandTest.Enabled = true;
                        this.lbx_testStatus.Text = "短路测试已完成";
                        this.lbx_testStatus.ForeColor = Color.Red;
                        this.lbx_shortCircuitExCount.Text = FinalCalExceptCount(8) + "";
                    }
                    else if (sigTestType == CableTestProcessParams.CableTestType.InsulateTest)
                    {
                        this.menu_ConductionTest.Enabled = true;
                        this.menu_shortCircuitTest.Enabled = true;
                        this.menu_InsulationTest.Enabled = true;
                        this.menu_VoltageWithStandTest.Enabled = true;
                        this.lbx_testStatus.Text = "绝缘测试已完成";
                        this.lbx_testStatus.ForeColor = Color.Red;
                        this.menu_InsulationTest.Enabled = true;
                        this.lbx_insulateExCount.Text = FinalCalExceptCount(10) + "";
                    }
                    else if (sigTestType == CableTestProcessParams.CableTestType.PressureWithVoltageTest)
                    {
                        this.menu_ConductionTest.Enabled = true;
                        this.menu_shortCircuitTest.Enabled = true;
                        this.menu_InsulationTest.Enabled = true;
                        this.menu_VoltageWithStandTest.Enabled = true;
                        this.lbx_testStatus.Text = "耐压测试已完成";
                        this.lbx_testStatus.ForeColor = Color.Red;
                        this.menu_VoltageWithStandTest.Enabled = true;
                        this.lbx_voltageExCount.Text = FinalCalExceptCount(12) + "";
                    }
                    this.lbx_conRelationCount.Text = this.radGridViewCableTest.RowCount + "";
                }));
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

        private void RefreshTestItemControl()
        {
            this.Invoke(new Action(()=>
            {
                this.menu_ConductionTest.Enabled = this.IsConductLatestCompleteStatus;
                this.menu_shortCircuitTest.Enabled = this.IsShortCircuitLatestCompleteStatus;
                this.menu_InsulationTest.Enabled = this.IsInsulateLatestCompleteStatus;
                this.menu_VoltageWithStandTest.Enabled = this.IsVoltageWithStandardLatestCompleteStatus;
            }));
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
                if (this.studyParamList.Count <= 0)
                    return;
                this.Invoke(new Action(() =>
                {
                    int count = this.studyParamList.Count;
                    this.radGridViewSelfStudy.BeginEdit();
                    foreach (var selfParams in this.studyParamList)
                    {
                        var startPoint = GetOrderPointByDevPoint(selfParams.DevStartPoint, 0, this.studyParamList);
                        var endPoint = GetOrderPointByDevPoint(selfParams.DevEndPoint, 1, this.studyParamList);
                        var testResultVal = selfParams.TestResultVal;
                        var testResult = selfParams.TestReulst;
                        if (startPoint == "" && endPoint == "")
                            continue;//接口表不存在
                        if (IsGridView2Exist(this.radGridViewSelfStudy, startPoint, endPoint, selfParams.TestResultVal, selfParams.TestReulst))
                        {
                            //更新当前值
                            continue;
                        }
                        this.studyParamValidList.Add(selfParams);
                        DataRow dr = this.dataSourceSelfStudy.NewRow();
                        var rCount = this.radGridViewSelfStudy.RowCount;
                        dr[0] = rCount + 1;
                        dr[1] = startPoint;
                        dr[2] = endPoint;
                        dr[3] = testResultVal;
                        dr[4] = testResult;
                        this.dataSourceSelfStudy.Rows.Add(dr);
                        SetGridStyleByTestValue(testResult);
                    }
                    this.radGridViewSelfStudy.DataSource = this.dataSourceSelfStudy;
                    this.radGridViewSelfStudy.CurrentRow = this.radGridViewSelfStudy.Rows[this.radGridViewSelfStudy.RowCount - 1];
                    this.studyParamList.RemoveRange(0, count);
                    this.radGridViewSelfStudy.EndEdit();
                    this.refreshDataTimer.Enabled = false;
                }));
            }
        }

        private void UpdateProbTestGridView()
        {
            lock (this)
            {
                if (this.probParamList.Count <= 0)
                    return;
                this.Invoke(new Action(() =>
                {
                    int count = this.probParamList.Count;
                    this.radGridViewProb.BeginEdit();
                    foreach (var selfParams in this.probParamList)
                    {
                        //var startPoint = GetOrderPointByDevPoint(selfParams.DevStartPoint, 0, this.probParamList);//探针
                        var endPoint = GetOrderPointByDevPoint(selfParams.DevEndPoint, 1, this.probParamList);
                        if (endPoint == "")
                            continue;
                        var testResultVal = selfParams.TestResultVal;
                        var testResult = selfParams.TestReulst;
                        if (IsGridView2Exist(this.radGridViewProb,"", endPoint, selfParams.TestResultVal, selfParams.TestReulst))
                            continue;
                        DataRow dr = this.dataSourceProb.NewRow();
                        var rCount = this.radGridViewProb.RowCount;
                        dr[0] = rCount + 1;
                        dr[1] = endPoint;
                        dr[2] = testResultVal;
                        dr[3] = testResult;
                        this.dataSourceProb.Rows.Add(dr);
                        SetGridStyleProbByTestValue(testResult, 3);
                    }
                    this.radGridViewProb.DataSource = this.dataSourceProb;
                    this.radGridViewProb.CurrentRow = this.radGridViewProb.Rows[this.radGridViewProb.RowCount - 1];
                    this.probParamList.RemoveRange(0, count);
                    this.radGridViewProb.EndEdit();
                    this.refreshDataTimer.Enabled = false;
                }));
            }
        }

        private string GetOrderPointByDevPoint(string did, int stype,List<SelfStudyParams> list)//stype 0 - start,1-end
        {
            InterfaceInfoLibraryManager infoLibraryManager = new InterfaceInfoLibraryManager();
            var data = infoLibraryManager.GetDataSetByFieldsAndWhere("ContactPoint,InterfaceNo", $"where SwitchStandStitchNo='{did}'").Tables[0];
            if (data.Rows.Count < 1)
                return "";
            var interName = data.Rows[0][1].ToString();
            var pointOrder = data.Rows[0][0].ToString();
            if (stype == 0)
            {
                var selfParams = list.Find(id => id.DevStartPoint == did);
                if (selfParams != null)
                {
                    selfParams.StartInterfaceName = interName;
                    selfParams.StartPointOrder = pointOrder;
                }
            }
            else if (stype == 1)
            {
                var selfParams = list.Find(id => id.DevEndPoint == did);
                if (selfParams != null)
                {
                    selfParams.EndInterfaceName = interName;
                    selfParams.EndPointOrder = pointOrder;
                }
            }
            return pointOrder;
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

        private void UpdateTestResultByTestPoint()
        {
            lock (this)
            {
                if (this.cableTestPramsList.Count <= 0)
                    return;
                this.Invoke(new Action(() =>
                {
                    int count = this.cableTestPramsList.Count;
                    int iRow = 0;
                    this.radGridViewCableTest.BeginEdit();
                    foreach (var cableTestParams in this.cableTestPramsList)
                    {
                        var startPoint = cableTestParams.StartPoint;
                        var endPoint = cableTestParams.EndPoint;
                        var testResultVal = cableTestParams.TestResultVal;
                        var testResult = cableTestParams.TestReulst;

                        foreach (DataRow rowInfo in this.dataSourceCableTest.Rows)
                        {
                            var startDevPoint = GetDevPointPinByContactPoint(rowInfo[1].ToString(),rowInfo[2].ToString());
                            var endDevPoint = GetDevPointPinByContactPoint(rowInfo[3].ToString(), rowInfo[4].ToString());
                            if (startDevPoint == startPoint && endDevPoint == endPoint)
                            {
                                //更新测试记录
                                rowInfo[cableTestParams.StartIndex] = testResultVal;
                                rowInfo[cableTestParams.StartIndex + 1] = testResult;

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
                                iRow++;
                            }
                        }
                    }
                    this.radGridViewCableTest.DataSource = this.dataSourceCableTest;
                    this.radGridViewCableTest.CurrentRow = this.radGridViewCableTest.Rows[iRow - 1];//更新到实际行数
                    this.cableTestPramsList.RemoveRange(0, count);
                    this.radGridViewCableTest.EndEdit();
                    this.refreshDataTimer.Enabled = false;
                }));
            }
        }

        private bool IsGridView2Exist(RadGridView gridView,string startPoint, string endPoint,string tVal, string tResult)
        {
            if (gridView.RowCount < 1)
                return false;
            foreach (var rowInfo in gridView.Rows)
            {
                var spoint = rowInfo.Cells[1].Value.ToString();
                var epoint = rowInfo.Cells[2].Value.ToString();
                var testVal = rowInfo.Cells[3].Value.ToString();
                var testResult = rowInfo.Cells[4].Value.ToString();

                if (rowInfo.Cells[1].Value != null && rowInfo.Cells[2].Value != null)
                {
                    if (startPoint == "")
                    {
                        if (rowInfo.Cells[2].Value.ToString() == endPoint)
                            return true;
                    }
                    else
                    {
                        if (spoint == startPoint && epoint == endPoint)
                        {
                            if (testResult == "导通" && tResult != "导通")
                            {
                                //rowInfo.Cells[3].Value = tVal;
                                //rowInfo.Cells[4].Value = tResult;
                                //SetGridStyleByTestValue(tResult);
                            }
                            return true;
                        }
                        else if (spoint == startPoint && epoint != endPoint)
                        {
                            //A接口的点与B接口另一个点也导通
                            if (testResult == "导通" && tResult == "导通")
                            {
                                SelfStudyLog($"警告：A接口的接点{spoint}已与B接口的接点{epoint}导通；A接口的接点{spoint}与B接口的接点{endPoint}也导通；请检查线束关系是否异常！");
                                return true;//异常警告
                            }
                        }
                        else if (spoint != startPoint && epoint == endPoint)
                        {
                            //B接口的点与A接口的另一个点也导通
                            if (testResult == "导通" && tResult == "导通")
                            {
                                SelfStudyLog($"警告：B接口的接点{epoint}已与A接口的接点{spoint}导通；B接口的接点{epoint}与A接口的接点{startPoint}也导通；请检查线束关系是否异常！");
                                return true;//异常警告
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void TextLogInvok(string text)
        {
            this.Invoke(new Action(()=>
            {
                this.tb_log.AppendText(text);
            }));
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
            this.tb_selfStudyTip.AppendText(text);
            this.tb_selfStudyTip.BackColor = Color.Red;
            this.tb_selfStudyTip.ReadOnly = true;
        }

        private void SuperEasyClient_NoticeConnectEvent(bool IsConnect, string tipMessage)
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
                        this.lbx_serviceURL.Text = this.serviceURL;
                        this.lbx_servicePort.Text = this.servicePort.ToString();
                    }));
            }
            else
            {
                //断开连接/连接失败
                this.Invoke(new Action(() =>
                {
                    this.tool_ConnectDevice.Text = "连接设备";
                    this.tool_ConnectDevice.Image = Resources.server_link;
                    if (tipMessage != "")
                        MessageBox.Show(tipMessage, "提示", MessageBoxButtons.OK);
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
                if (this.serviceURL == "" || this.servicePort == 0)
                {
                    if (MessageBox.Show("服务器参数未配置，是否立即打开配置！", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        OpenConnectConfig();
                        if (this.serviceURL == "")
                            return;
                        if (this.servicePort == 0)
                            return;
                    }
                    else
                        return;
                }
                else
                {
                    //update status
                    this.lbx_serviceURL.Text = this.serviceURL;
                    this.lbx_servicePort.Text = this.servicePort.ToString();
                }
                SuperEasyClient.serverUrl = this.serviceURL;
                SuperEasyClient.serverPort = this.servicePort.ToString();
                SuperEasyClient.ConnectServer();
            }
            else
            {
                //已连接服务，开始断开连接
                SuperEasyClient.client.Close();
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
                            RadProjectCreat radProjectCreat = new RadProjectCreat("编辑项目", projectName, cableJudgeThreshold,true);
                            radProjectCreat.ShowDialog();
                            break;
                        case WORK_WEAR:

                            break;
                        case PROJECT_OPEN_TEST:
                            this.radDock1.RemoveAllDocumentWindows();
                            this.radDock1.AddDocument(this.documentWindow1);
                            this.currentTestProject = projectName;
                            QueryTestInfoByProjectName(projectName);
                            break;

                        case PROJECT_CLOSE_TEST:
                            this.radDock1.RemoveWindow(this.documentWindow1);
                            break;

                        case CABLE_DETAIL:
                            if (string.IsNullOrEmpty(this.curLineCableName))
                                return;
                            RadUpdateCable radUpdateCable = new RadUpdateCable($"线束{this.curLineCableName}", this.curLineCableName, true);
                            radUpdateCable.Show();
                            break;

                        case DEVICE_DETAIL:
                            break;
                    }
                }
            }
        }

        #endregion

        #region menu event
        private void Menu_historyData_Click(object sender, EventArgs e)
        {
            RadTestDataBasicInfo radTestDataBasicInfo = new RadTestDataBasicInfo();
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
            DevSelfCheck devSelfCheck = new DevSelfCheck();
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
            DevCalibration deviceCalibration = new DevCalibration();
            deviceCalibration.ShowDialog();
        }

        private void Menu_VoltageWithStandTest_Click(object sender, EventArgs e)
        {
            this.startTestDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.cableTestProcessSig.CableTestTypeEnum = CableTestProcessParams.CableTestType.PressureWithVoltageTest;
            this.cableTestProcessQueue.Enqueue(CableTestProcessParams.CableTestType.PressureWithVoltageTest);
            this.UpdateCurrentGridView();
            this.UpdateCurrentTestNumber();
            StartVoltageWithStandardTest();
        }

        private void Menu_InsulationTest_Click(object sender, EventArgs e)
        {
            this.startTestDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.cableTestProcessSig.CableTestTypeEnum = CableTestProcessParams.CableTestType.InsulateTest;
            this.cableTestProcessQueue.Enqueue(CableTestProcessParams.CableTestType.InsulateTest);
            this.UpdateCurrentGridView();
            this.UpdateCurrentTestNumber();
            StartInsulateTest();
        }

        private void Menu_shortCircuitTest_Click(object sender, EventArgs e)
        {
            this.startTestDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.cableTestProcessSig.CableTestTypeEnum = CableTestProcessParams.CableTestType.ShortCircuitTest;
            this.cableTestProcessQueue.Enqueue(CableTestProcessParams.CableTestType.ShortCircuitTest);
            this.UpdateCurrentGridView();
            this.UpdateCurrentTestNumber();
            StartCircuitTest();
        }

        private void Menu_ConductionTest_Click(object sender, EventArgs e)
        {
            this.startTestDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.cableTestProcessSig.CableTestTypeEnum = CableTestProcessParams.CableTestType.ConductTest;
            this.cableTestProcessQueue.Enqueue(CableTestProcessParams.CableTestType.ConductTest);
            this.UpdateCurrentGridView();
            this.UpdateCurrentTestNumber();
            StartConductTest();
        }

        private void Menu_OneKeyTest_Click(object sender, EventArgs e)
        {
            OneClickTestConfig oneClickTest = new OneClickTestConfig(this.cableTestProcessQueue);
            if (oneClickTest.ShowDialog() == DialogResult.OK)
            {
                if (!this.radDock1.ActivateWindow(this.documentWindow1))
                {
                    MessageBox.Show("请打开要测试的项目！","提示",MessageBoxButtons.OK);
                    return;
                }
                //清空异常数
                this.conductTestExceptCount = 0;
                this.shortCircuitTestExceptCount = 0;
                this.insulateTestExceptCount = 0;
                this.voltageWithStandardTestExceptCount = 0;

                this.menu_OneKeyTest.Enabled = false;

                this.startTestDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                this.UpdateCurrentGridView();
                this.UpdateCurrentTestNumber();
                //开始启动第一项测试
                if (this.cableTestProcessQueue.Count <= 0)
                    return;//没有选择要测试的内容
                if (this.radGridViewCableTest.RowCount <= 0)
                    return;//测试组为空
                this.cableTestProcessOneKey.CableTestProcessParamsList = new List<CableTestProcessParams>();
                this.cableTestProcessOneKey.CurrentTestProject = this.currentTestProject;
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
            AddConnection addConnection = new AddConnection(this.serviceURL, this.servicePort);
            if (addConnection.ShowDialog() == DialogResult.OK)
            {
                this.serviceURL = addConnection.serverIP;
                this.servicePort = addConnection.serverPort;
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

                this.radDock1.RemoveAllDocumentWindows();
                this.radDock1.AddDocument(this.documentWindow3);
                InitProbTable();
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
                if (this.studyConfig.StudyTestType == SelfStudyConfig.SutdyTestTypeEnum.ProbTestByLimit)
                {
                    var selftStudyString = this.studyConfig.MeasureMethod + "01"+ DecConvert2ByteHexStr(this.studyConfig.LimitMin) + DecConvert2ByteHexStr(this.studyConfig.LimitMax);
                    SendSelfStudyOrProbCommand(selftStudyString, selfStudyTestFunCode);
                }
                else if (this.studyConfig.StudyTestType == SelfStudyConfig.SutdyTestTypeEnum.ProbTestByInterface)
                {
                    var selftStudyString = studyConfig.MeasureMethod + "02" + this.studyConfig.TestInterAList + "0000" + this.studyConfig.TestInterBList;
                    SendSelfStudyOrProbCommand(selftStudyString, selfStudyTestFunCode);
                }
                this.radDock1.RemoveAllDocumentWindows();
                this.radDock1.AddDocument(this.documentWindow2);
                InitDatable(true);
            }
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
            RadTestDataBasicInfo testDataBasicInfo = new RadTestDataBasicInfo();
            testDataBasicInfo.ShowDialog();
        }

        private void Tool_OpenProject_Click(object sender, EventArgs e)
        {
            ProjectManage projectManager = new ProjectManage(cableJudgeThreshold);
            if (projectManager.ShowDialog() == DialogResult.OK)
            {
                if (projectManager.operateType == ProjectManage.OperateType.OpenProject)
                {
                    this.radDock1.AddDocument(this.documentWindow1);
                    QueryTestInfoByProjectName(projectManager.openProjectName);
                }
                else if (projectManager.operateType == ProjectManage.OperateType.DeleteProject)
                {
                    //update current project info
                    UpdateTreeView();
                    QueryTestInfoByProjectName(projectManager.openProjectName);
                }
            }
            else
            {
                if (projectManager.operateType == ProjectManage.OperateType.DeleteProject)
                {
                    UpdateTreeView();
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
            RadProjectCreat radProjectCreat = new RadProjectCreat("新建项目", "", cableJudgeThreshold, false);
            if (radProjectCreat.ShowDialog() == DialogResult.OK)
            {
                UpdateTreeView();
                this.radDock1.AddDocument(this.documentWindow1);
                QueryTestInfoByProjectName(radProjectCreat.projectName);
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
                UpdateTreeView();
            }
        }

        private void OpenInterfaceLibrary()
        {
            RadInterfaceLibrary interfaceLibrary = new RadInterfaceLibrary();
            interfaceLibrary.ShowDialog();
        }

        private void DeviceConnect()
        {
            try
            {
                KLineTestProcessor this2 = this.gLineTestProcessor;
                if (this2.bEmulationMode)
                {
                    //this.toolStripStatusLabel_csyConnStatus.Text = "连接正常";
                    MessageBox.Show("设备连接成功!", "提示", MessageBoxButtons.OK);
                }
                else if (!this2.bIsConnSuccFlag && !this2.mpDevComm.InitCAN())
                {
                    //this.bIsConnSuccFlag = false;
                    this.gLineTestProcessor.bIsConnSuccFlag = false;
                    MessageBox.Show("设备连接失败，请查看接线是否正常!", "提示", MessageBoxButtons.OK);
                }
                else
                {
                    System.Threading.Thread.Sleep(100);
                    //this.SendDeviceExistCmdFeedbackFunc();
                    System.Threading.Thread.Sleep(500);
                    KLineTestProcessor sender2 = this.gLineTestProcessor;
                    if (!sender2.mpDevComm.mParseCmd.DeviceExist)
                    {
                        try
                        {
                            this.gLineTestProcessor.mpDevComm.CloseCAN();
                        }
                        catch (System.Exception ex_B6)
                        {
                        }
                        //this.bIsConnSuccFlag = false;
                        this.gLineTestProcessor.bIsConnSuccFlag = false;
                        //this.toolStripStatusLabel_csyConnStatus.Text = "未连接";
                        MessageBox.Show("设备连接失败，请查看接线是否正常!", "提示", MessageBoxButtons.OK);
                    }
                    else
                    {
                        //this.bIsConnSuccFlag = true;
                        sender2.bIsConnSuccFlag = true;
                        //this.toolStripStatusLabel_csyConnStatus.Text = "连接正常";
                        MessageBox.Show("设备连接成功!", "提示", MessageBoxButtons.OK);
                    }
                }
            }
            catch (System.Exception arg_122_0)
            {
                KLineTestProcessor.ExceptionRecordFunc(arg_122_0.StackTrace);
            }
        }

        private void UpdateTreeView()
        {
            //select project
            this.radTreeView1.Nodes.Clear();
            var projectInfoData = projectInfoManager.GetDataSetByFieldsAndWhere("distinct ProjectName", "").Tables[0];
            if (projectInfoData.Rows.Count < 1)
                return;
            foreach (DataRow dr in projectInfoData.Rows)
            {
                var projectName = dr["ProjectName"].ToString();
                RadTreeNode root = this.radTreeView1.Nodes.Add(projectName);
                var projectNode = root.Nodes.Add(PROJECT_INFO, 1);
                projectNode.Nodes.Add(PROJECT_OPEN_TEST);
                projectNode.Nodes.Add(PROJECT_CLOSE_TEST);
                projectNode.Nodes.Add(PROJECT_EDIT, 1);
                //projectNode.Nodes.Add(WORK_WEAR, 1);
                var cableNode = root.Nodes.Add(TEST_CABLE, 1);
                cableNode.Nodes.Add(CABLE_DETAIL, 1);
                //var deviceNode = root.Nodes.Add(DEVICE_INFO, 1);
                //deviceNode.Nodes.Add(DEVICE_DETAIL, 1);
            }
        }

        /// <summary>
        /// 保存测试记录：测试中/测试完成
        /// 多次保存的保存序列相同，每启动一次测试生成一个新测试序列
        /// </summary>
        private void SaveTestResult()
        {
            System.Threading.Tasks.Task task = new System.Threading.Tasks.Task(() =>
            {
                if (this.radGridViewCableTest.Rows.Count < 1)
                    return;
                if (!IsExistTestRecore())//没有测试记录
                return;
            if (IsExistSaveTestSerialNumber())//已保存该测试序列
                return;
            var projectInfoData = this.projectInfoManager.GetDataSetByWhere($"where ProjectName = '{this.currentTestProject}'").Tables[0];
            var updateBasicCount = 0;
            var updateDetailCount = 0;

            #region project test basic info
            THistoryDataBasic historyDataInfo = new THistoryDataBasic();
            historyDataInfo.ID = TablePrimaryKey.InsertHistoryBasicPID();
            historyDataInfo.TestSerialNumber = this.projectTestNumber;
            historyDataInfo.ProjectName = this.currentTestProject;
            historyDataInfo.BatchNumber = projectInfoData.Rows[0]["BatchNumber"].ToString();
            historyDataInfo.TestCableName = projectInfoData.Rows[0]["TestCableName"].ToString();
            historyDataInfo.TestDate = this.startTestDate;
            //可新增结束日期
            historyDataInfo.TestOperator = LocalLogin.currentUserName;
            historyDataInfo.EnvironmentTemperature = this.environmentTemperature.ToString();
            historyDataInfo.EnvironmentAmbientHumidity = this.environmentAmbientHumidity.ToString();
            historyDataInfo.DeviceTypeNo = this.deviceTypeNo;
            historyDataInfo.DeviceMeasureNumber = "";//测试仪计量编号，无
            historyDataInfo.FinalTestResult = CalFinalTestResult();
            historyDataInfo.ConductThreshold = this.conductPassThreshold;
            historyDataInfo.ConductVoltage = double.Parse(projectInfoData.Rows[0]["ConductTestVoltage"].ToString());
            historyDataInfo.ConductElect = double.Parse(projectInfoData.Rows[0]["ConductTestCurrentElect"].ToString());
            historyDataInfo.ShortCircuitThreshold = this.shortCircuitPassThreshold;
            historyDataInfo.InsulateHighOrLowElect = double.Parse(projectInfoData.Rows[0]["InsulateHigthOrLowElect"].ToString());
            historyDataInfo.InsulateThreshold = this.insulatePassThreshold;
            historyDataInfo.InsulateHoldTime = double.Parse(projectInfoData.Rows[0]["InsulateTestHoldTime"].ToString());
            historyDataInfo.InsulateVoltage = double.Parse(projectInfoData.Rows[0]["InsulateTestVoltage"].ToString());
            historyDataInfo.InsulateRaiseTime = double.Parse(projectInfoData.Rows[0]["InsulateTestRaiseTime"].ToString());
            historyDataInfo.VoltageWithStandardThreshold = this.voltageWithStandardPassThreshold;
            historyDataInfo.VoltageWithStandardHoldTime = double.Parse(projectInfoData.Rows[0]["VoltageWithStandardHoldTime"].ToString());
            historyDataInfo.VoltageWithStandardVoltage = double.Parse(projectInfoData.Rows[0]["VoltageWithStandardVoltage"].ToString());

            //if (this.IsPassConductionTest)
            //    historyDataInfo.IsConductTestComplete = 1;
            //else
            //    historyDataInfo.IsConductTestComplete = 0;
            //if (this.IsPassInsulateTest)
            //    historyDataInfo.IsInsulateTestComplete = 1;
            //else
            //    historyDataInfo.IsInsulateTestComplete = 0;
            //if (this.IsPassShortCircuitTest)
            //    historyDataInfo.IsShortCircuteTestComplete = 1;
            //else
            //    historyDataInfo.IsShortCircuteTestComplete = 0;
            //if (this.IsPassVoltageWithStandardTest)
            //    historyDataInfo.IsVoltageWithStandardTestComplete = 1;
            //else
            //    historyDataInfo.IsVoltageWithStandardTestComplete = 0;

            historyDataInfo.ConductTestExceptCount = this.conductTestExceptCount;
            historyDataInfo.ShortcircuitTestExceptCount = this.shortCircuitTestExceptCount;
            historyDataInfo.InsulateTestExceptCount = this.insulateTestExceptCount;
            historyDataInfo.VoltageWithStandardTestExceptCount = this.voltageWithStandardTestExceptCount;
            updateBasicCount += historyDataInfoManager.Insert(historyDataInfo);
            #endregion

            #region project test detail info
            foreach (var lv in this.radGridViewCableTest.Rows)
            {
                    THistoryDataDetail historyDataDetail = new THistoryDataDetail();
                historyDataDetail.ID = TablePrimaryKey.InsertHistoryDetailPID();
                historyDataDetail.TestSerialNumber = this.projectTestNumber.ToString();
                historyDataDetail.ProjectName = this.currentTestProject;
                if (lv.Cells[1].Value != null)
                    historyDataDetail.StartInterface = lv.Cells[1].Value.ToString();
                if (lv.Cells[2].Value != null)
                    historyDataDetail.StartContactPoint = lv.Cells[2].Value.ToString();
                if (lv.Cells[3].Value != null)
                    historyDataDetail.EndInterface = lv.Cells[3].Value.ToString();
                if (lv.Cells[4].Value != null)
                    historyDataDetail.EndContactPoint = lv.Cells[4].Value.ToString();
                if(lv.Cells[5].Value != null)
                    historyDataDetail.ConductValue = lv.Cells[5].Value.ToString();
                if(lv.Cells[6].Value != null)
                    historyDataDetail.ConductTestResult = lv.Cells[6].Value.ToString();
                if(lv.Cells[7].Value != null)
                    historyDataDetail.InsulateValue = lv.Cells[7].Value.ToString();
                if (lv.Cells[8].Value != null)
                    historyDataDetail.InsulateTestResult = lv.Cells[8].Value.ToString();
                if (lv.Cells[9].Value != null)
                    historyDataDetail.VoltageWithStandardValue = lv.Cells[9].Value.ToString();
                if (lv.Cells[10].Value != null)
                    historyDataDetail.VoltageWithStandardTestResult = lv.Cells[10].Value.ToString();

                updateDetailCount += historyDataDetailManager.Insert(historyDataDetail);
            }
            #endregion

            if (updateBasicCount > 0)
            {
                    MessageBox.Show("已保存成功!", "提示");
                    UpdateTestProjectStatus(historyDataInfo.TestCableName);
                }
            });
            task.Start();
        }

        private void UpdateTestProjectStatus(string testCableName)
        {
            try
            {
                var conductTestState = QueryTestItemStatusValue("ConductValue", testCableName);
                var shortCircuitTestState = QueryTestItemStatusValue("ShortCircuitValue", testCableName);
                var insulateTestState = QueryTestItemStatusValue("InsulateValue", testCableName);
                var voltageTestState = QueryTestItemStatusValue("VoltageWithStandardValue", testCableName);
                TProjectBasicInfo projectBasicInfo = new TProjectBasicInfo();

                var row = projectInfoManager.UpdateFields($"IsExistConductTest='{conductTestState}',IsExistShortCircuitTest='{shortCircuitTestState}'," +
                    $"IsExistInsulateTest='{insulateTestState}',IsExistVoltageWithStandardTest='{voltageTestState}'",
                    $"where TestCableName = '{testCableName}'");
                LogHelper.Log.Info($"更新测试项状态，更新记录={row}条");
            }
            catch (Exception ex)
            {
                LogHelper.Log.Error(ex.Message+ex.StackTrace);
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

        private string CalFinalTestResult()
        {
            if (this.radGridViewCableTest.Rows.Count < 1)
                return "未测试";
            foreach(var lv in this.radGridViewCableTest.Rows)
            {
                var conductResult = lv.Cells[6].Value.ToString();
                var shortCircuitResult = lv.Cells[6].Value.ToString();
                var insulateResult = lv.Cells[6].Value.ToString();
                var voltageResult = lv.Cells[6].Value.ToString();
                if (conductResult != "合格" || shortCircuitResult != "合格" || insulateResult != "合格" || voltageResult != "合格")
                {
                    return "不合格";
                }
            }
            return "合格";
        }

        private void QueryTestInfoByProjectName(string projectName)
        {
            this.testItemStyleList.Clear();
            UpdateCurrentProTestFunStatusInfo(projectName);
            RadGridViewProperties.ClearGridView(this.radGridViewCableTest,this.dataSourceCableTest);
            UpdateProjectInfo(projectName);
            //RadGridViewProperties.SetRadGridViewProperty(this.radGridView1,false,true,13);
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
                        InitCableParams(startInterface, startContactPoint, startDevPoint);
                        InitCableParams(endInterface, endContactPoint, endDevPoint);

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

        private void InitCableParams(string interName, string interPoint, string devPoint)
        {
            CableLibParams libParams = new CableLibParams();
            libParams.InterfaceName = interName;
            libParams.InterContactPoint = interPoint;
            libParams.DevInterPoint = devPoint;
            var cabParamsObj = this.cableLibParamList.Find(obj => obj.InterfaceName == interName && obj.InterContactPoint == interPoint);
            if (cabParamsObj == null)
            {
                this.cableLibParamList.Add(libParams);
            }
        }

        private void UpdateCurrentProTestFunStatusInfo(string projectName)
        {
            var dt = projectInfoManager.GetDataSetByWhere($"where ProjectName = '{projectName}'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                double.TryParse(dt.Rows[0]["ConductTestThreshold"].ToString(), out this.conductPassThreshold);
                double.TryParse(dt.Rows[0]["ShortCircuitTestThreshold"].ToString(), out this.shortCircuitPassThreshold);
                double.TryParse(dt.Rows[0]["InsulateTestThreshold"].ToString(), out this.insulatePassThreshold);
                double.TryParse(dt.Rows[0]["VoltageWithStandardThreshold"].ToString(), out this.voltageWithStandardPassThreshold);
                var IsExistConduct = dt.Rows[0]["IsExistConductTest"].ToString();
                var IsExistCircuit = dt.Rows[0]["IsExistShortCircuitTest"].ToString();
                var IsExistInsulate = dt.Rows[0]["IsExistInsulateTest"].ToString();
                var IsExistVoltage = dt.Rows[0]["IsExistVoltageWithStandardTest"].ToString();

                //根据当前项目测试序列，更新状态
                this.menu_ConductionTest.Enabled = true;
                if (IsExistConduct == "1")
                {
                    this.menu_shortCircuitTest.Enabled = true;
                    if (IsExistCircuit == "1")
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
        }

        private void UpdateProjectInfo(string projectName)
        {
            if (projectName == "")
                return;
            var dt = projectInfoManager.GetDataSetByWhere($"where ProjectName='{projectName}'").Tables[0];
            if (dt.Rows.Count < 1)
                return;
            foreach (DataRow dr in dt.Rows)
            {
                //this.rtbCurrentTestCable.Text = dr["TestCableName"].ToString();
                //this.rtbCableCondition.Text = this.rtbCurrentTestCable.Text;
                this.projectInfo.ConductTestThreshold = double.Parse(dr["ConductTestThreshold"].ToString());
                this.projectInfo.ConductTestVoltage = double.Parse(dr["ConductTestVoltage"].ToString());
                this.projectInfo.ConductTestCurrentElect = double.Parse(dr["ConductTestCurrentElect"].ToString());
                this.projectInfo.ShortCircuitTestThreshold = double.Parse(dr["ShortCircuitTestThreshold"].ToString());
                this.projectInfo.InsulateTestThreshold = double.Parse(dr["InsulateTestThreshold"].ToString());
                this.projectInfo.InsulateTestVoltage = double.Parse(dr["InsulateTestVoltage"].ToString());
                this.projectInfo.InsulateTestRaiseTime = double.Parse(dr["InsulateTestRaiseTime"].ToString());
                this.projectInfo.InsulateTestHoldTime = double.Parse(dr["InsulateTestHoldTime"].ToString());
                this.projectInfo.InsulateHigthOrLowElect = double.Parse(dr["InsulateHigthOrLowElect"].ToString());
                this.projectInfo.VoltageWithStandardThreshold = double.Parse(dr["VoltageWithStandardThreshold"].ToString());
                this.projectInfo.VoltageWithStandardHoldTime = double.Parse(dr["VoltageWithStandardHoldTime"].ToString());
                this.projectInfo.VoltageWithStandardVoltage = double.Parse(dr["VoltageWithStandardVoltage"].ToString());
            }
        }

        private void InitDefaultConfig()
        {
            configPath += DEVICE_CONFIG_FILE_NAME;
            if (!File.Exists(configPath))
            {
                var defaultDir = "C:\\cableTestReport\\";
                this.reportDirectory = defaultDir;
                INIFile.SetValue(REPORT_SECTION_PATH, REPORT__KEY_FILE_DIR, defaultDir, configPath);

                INIFile.SetValue(CONFIG_SECTION_TEST_NAME, PROJECT_TEST_NUMBER_LEN_KEY, this.projectTestNumberLen.ToString(), configPath);
                INIFile.SetValue(CONFIG_SECTION_NAME, CONDUCTION_THRESHOLD_KEY, CONDUCTION_THRESHOLD, configPath);
                INIFile.SetValue(CONFIG_SECTION_NAME, IS_CONDUCTION_JUDGE_THAN_THRESHOLD_KEY, IS_CONDUCTION_JUDGE_THAN_THRESHOLD, configPath);
                INIFile.SetValue(CONFIG_SECTION_NAME, INSULATE_THRESHOLD_KEY, INSULATE_THRESHOLD, configPath);
                INIFile.SetValue(CONFIG_SECTION_NAME, IS_INSULATE_JUDGE_THAN_THRESHOLD_KEY, IS_INSULATE_JUDGE_THAN_THRESHOLD, configPath);
                INIFile.SetValue(CONFIG_SECTION_NAME, INSULATE_VOLTAGE_KEY, INSULATE_VOLTAGE, configPath);
                INIFile.SetValue(CONFIG_SECTION_NAME, INSULATE_HOLD_TIME_KEY, INSULATE_HOLD_TIME, configPath);
                INIFile.SetValue(CONFIG_SECTION_NAME, PRESSURE_PROOF_THRESHOLD_KEY, PRESSURE_PROOF_THRESHOLD, configPath);
                INIFile.SetValue(CONFIG_SECTION_NAME, IS_PRESSURE_JUDGE_THAN_THRESHOLD_KEY, IS_PRESSURE_JUDGE_THAN_THRESHOLD, configPath);
                INIFile.SetValue(CONFIG_SECTION_NAME, PRESSURE_PROOF_VOLTAGE_KEY, PRESSURE_PROOF_VOLTAGE, configPath);
                INIFile.SetValue(CONFIG_SECTION_NAME, PRESSURE_PROOF_HOLD_TIME_KEY, PRESSURE_PROOF_HOLD_TIME, configPath);
            }
            else
            {
                this.reportDirectory = INIFile.GetValue(REPORT_SECTION_PATH, REPORT__KEY_FILE_DIR, configPath).ToString();
                this.serviceURL = INIFile.GetValue(DEVICE_CONFIG_SECTION, DEVICE_CONFIG_SERVER_URL_KEY, configPath).ToString();
                var port = INIFile.GetValue(DEVICE_CONFIG_SECTION, DEVICE_CONFIG_SERVER_PORT_KEY, configPath).ToString();
                int.TryParse(port, out this.servicePort);

                var testNumberLen = INIFile.GetValue(CONFIG_SECTION_TEST_NAME, PROJECT_TEST_NUMBER_LEN_KEY, configPath).ToString();
                int testnLen;
                if (testNumberLen != "")
                {
                    int.TryParse(testNumberLen, out testnLen);
                    this.projectTestNumberLen = testnLen;
                }
                else
                    this.projectTestNumberLen = 8;
                var conduction_threshold = INIFile.GetValue(CONFIG_SECTION_NAME, CONDUCTION_THRESHOLD_KEY, configPath);
                if (conduction_threshold != "")
                    this.CONDUCTION_THRESHOLD = conduction_threshold.ToString();
                var is_conduction_judge_than_threshold = INIFile.GetValue(CONFIG_SECTION_NAME, IS_CONDUCTION_JUDGE_THAN_THRESHOLD_KEY, configPath).ToString();
                if (is_conduction_judge_than_threshold != "")
                    this.IS_CONDUCTION_JUDGE_THAN_THRESHOLD = is_conduction_judge_than_threshold;
                var insulate_threshold = INIFile.GetValue(CONFIG_SECTION_NAME, INSULATE_THRESHOLD_KEY, configPath).ToString();
                if (insulate_threshold != "")
                    this.INSULATE_THRESHOLD = insulate_threshold;
                var is_insulate_judge_than_threshold = INIFile.GetValue(CONFIG_SECTION_NAME, IS_INSULATE_JUDGE_THAN_THRESHOLD_KEY, configPath).ToString();
                if (is_insulate_judge_than_threshold != "")
                    this.IS_INSULATE_JUDGE_THAN_THRESHOLD = is_insulate_judge_than_threshold;
                var insulate_voltage = INIFile.GetValue(CONFIG_SECTION_NAME, INSULATE_VOLTAGE_KEY, configPath).ToString();
                if (insulate_voltage != "")
                    this.INSULATE_VOLTAGE = insulate_voltage;
                var insulate_hold_time = INIFile.GetValue(CONFIG_SECTION_NAME, INSULATE_HOLD_TIME_KEY, configPath).ToString();
                if (insulate_hold_time != "")
                    this.INSULATE_HOLD_TIME = insulate_hold_time;
                var presure_proof_threshold = INIFile.GetValue(CONFIG_SECTION_NAME, PRESSURE_PROOF_THRESHOLD_KEY, configPath).ToString();
                if (presure_proof_threshold != "")
                    this.PRESSURE_PROOF_THRESHOLD = presure_proof_threshold;
                var is_pressure_judge_than_threshold = INIFile.GetValue(CONFIG_SECTION_NAME, IS_PRESSURE_JUDGE_THAN_THRESHOLD_KEY, configPath).ToString();
                if (is_pressure_judge_than_threshold != "")
                    this.IS_CONDUCTION_JUDGE_THAN_THRESHOLD = is_pressure_judge_than_threshold;
                var pressure_voltage = INIFile.GetValue(CONFIG_SECTION_NAME, PRESSURE_PROOF_VOLTAGE_KEY, configPath).ToString();
                if (pressure_voltage != "")
                    this.PRESSURE_PROOF_VOLTAGE = pressure_voltage;
                var pressure_hold_time = INIFile.GetValue(CONFIG_SECTION_NAME, PRESSURE_PROOF_HOLD_TIME_KEY, configPath).ToString();
                if (pressure_hold_time != "")
                    this.PRESSURE_PROOF_HOLD_TIME = pressure_hold_time;
            }

            cableJudgeThreshold = new CableJudgeThreshold();
            cableJudgeThreshold.ConductionThreshold = this.CONDUCTION_THRESHOLD;
            cableJudgeThreshold.IsConductionJudgeThanThreshold = this.IS_CONDUCTION_JUDGE_THAN_THRESHOLD;
            cableJudgeThreshold.InsulateThreshold = this.INSULATE_THRESHOLD;
            cableJudgeThreshold.IsInsulateJudgeThanThreshold = this.IS_INSULATE_JUDGE_THAN_THRESHOLD;
            cableJudgeThreshold.InsulateVoltage = this.INSULATE_VOLTAGE;
            cableJudgeThreshold.InsulateHoldTime = this.INSULATE_HOLD_TIME;
            cableJudgeThreshold.PressureProofThreshold = this.PRESSURE_PROOF_THRESHOLD;
            cableJudgeThreshold.IsPressureJudgeThanThreshold = this.IS_PRESSURE_JUDGE_THAN_THRESHOLD;
            cableJudgeThreshold.PressureProofVoltage = this.PRESSURE_PROOF_VOLTAGE;
            cableJudgeThreshold.PressureProofHoldTime = this.PRESSURE_PROOF_HOLD_TIME;
        }

        private void SaveDeviceConfig()
        {
            INIFile.SetValue(REPORT_SECTION_PATH, REPORT__KEY_FILE_DIR, this.reportDirectory, configPath);

            INIFile.SetValue(CONFIG_SECTION_TEST_NAME, PROJECT_TEST_NUMBER_LEN_KEY, this.projectTestNumberLen.ToString(), configPath);
            INIFile.SetValue(DEVICE_CONFIG_SECTION, DEVICE_CONFIG_SERVER_URL_KEY, this.serviceURL, configPath);
            INIFile.SetValue(DEVICE_CONFIG_SECTION, DEVICE_CONFIG_SERVER_PORT_KEY, this.servicePort.ToString(), configPath);
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

        /// <summary>
        /// 解密算法
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <returns></returns>
        public unsafe static string DecodeDisposeFunc(string sourceStr)
        {
            byte[] tempArray = null;
            string rStr = "";
            try
            {
                int iCount = 0;
                int iIndex = 0;
                tempArray = new byte[KLineTestProcessor.CHAR_MAX_LEN];
                for (int i = 0; i < KLineTestProcessor.CHAR_MAX_LEN; i++)
                {
                    tempArray[i] = 0;
                }
                while (true)
                {
                    try
                    {
                        string tempStr = sourceStr.Substring(iCount, 3);
                        if (tempStr.Length < 3)
                        {
                            break;
                        }
                        short siTemp = System.Convert.ToInt16(tempStr);
                        byte chTemp = (byte)siTemp;
                        tempArray[iIndex] = (byte)chTemp;
                        iIndex++;
                    }
                    catch (System.Exception ex_6D)
                    {
                        break;
                    }
                    iCount += 3;
                }
                rStr = System.Text.Encoding.Default.GetString(tempArray, 0, iIndex);
            }
            catch (System.Exception ex_8B)
            {
            }
            return rStr;
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
            if (!IsSetEnvironmentParams())
                return;
            var voltageWithStandardCommand = CommonTestSendCommand(GetConductionTestInfo(), voltageWithStandardFunCode);
            if (voltageWithStandardCommand.Length < 1)
                return;
            //清空耐压异常数
            this.voltageWithStandardTestExceptCount = 0;
            LogHelper.Log.Info("耐压测试开始下发指令...");
            UnEnableTestButton();
            SuperEasyClient.SendMessage(DeviceFunCodeEnum.RequestHead, voltageWithStandardCommand);
            UpdateTestStatus("耐压已开始测试，等待测试结果...");
            MessageBox.Show("耐压测试指令已下发", "提示", MessageBoxButtons.OK);
        }

        private void StartInsulateTest()
        {
            if (!IsConnectSuccess())
                return;
            if (!IsSetEnvironmentParams())
                return;
            var insulateCommand = CommonTestSendCommand(GetConductionTestInfo(), insulateTestFunCode);
            if (insulateCommand.Length < 1)
                return;
            //清空绝缘异常数
            this.insulateTestExceptCount = 0;
            LogHelper.Log.Info("绝缘测试开始下发指令...");
            UnEnableTestButton();
            SuperEasyClient.SendMessage(DeviceFunCodeEnum.RequestHead, insulateCommand);
            UpdateTestStatus("绝缘已开始测试，等待测试结果...");
            MessageBox.Show("绝缘测试指令已下发", "提示", MessageBoxButtons.OK);
        }

        #region 短路测试
        private void StartCircuitTest()
        {
            if (!IsConnectSuccess())
                return;
            if (!IsSetEnvironmentParams())
                return;
            var shortCircuitCommand = CommonTestSendCommand(GetShortCircuitTestInfo(), shortCircuitTestFunCode);
            if (shortCircuitCommand.Length < 1)
                return;
            //清空短路异常数
            this.shortCircuitTestExceptCount = 0;
            LogHelper.Log.Info("短路测试开始下发指令...");
            UnEnableTestButton();
            SuperEasyClient.SendMessage(DeviceFunCodeEnum.RequestHead, shortCircuitCommand);
            UpdateTestStatus("短路已开始测试，等待测试结果...");
            MessageBox.Show("短路测试指令已下发", "提示", MessageBoxButtons.OK);
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
            var method = "";
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
                if (conductTestResult != null)
                {
                    if (conductTestResult.ToString() == "合格")
                        continue;
                }
                int startpoint, endpoint;
                int.TryParse(startDevPoint, out startpoint);
                int.TryParse(endDevPoint, out endpoint);
                method = measuringMethod;
                hexString += Convert.ToString(startpoint, 16).PadLeft(4, '0') + Convert.ToString(endpoint, 16).PadLeft(4, '0');
            }
            hexString = Convert.ToString(method).PadLeft(2, '0') + hexString;
            LogHelper.Log.Info("短路测试内容："+hexString);
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

        #region this is conduct test content
        private void StartConductTest()
        {
            if (!IsConnectSuccess())
                return;
            if (!IsSetEnvironmentParams())
                return;
            var conductionCommand = CommonTestSendCommand(GetConductionTestInfo(), conductionTestFunCode);
            if (conductionCommand.Length < 1)
                return;
            LogHelper.Log.Info("导通测试开始下发指令...");
            this.conductTestExceptCount = 0;//清空导通异常数
            UnEnableTestButton();
            SuperEasyClient.SendMessage(DeviceFunCodeEnum.RequestHead, conductionCommand);
            UpdateTestStatus("导通已开始测试，等待测试结果...");
            MessageBox.Show("导通测试指令已下发", "提示", MessageBoxButtons.OK);
        }

        private string GetConductionTestInfo()
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
                if (conductTestResult != null)
                {
                    if (conductTestResult.ToString() == "合格")
                        continue;
                }
                int startpoint, endpoint;
                int.TryParse(startDevPoint, out startpoint);
                int.TryParse(endDevPoint, out endpoint);
                method = measuringMethod;
                hexString += Convert.ToString(startpoint, 16).PadLeft(4, '0') + Convert.ToString(endpoint, 16).PadLeft(4, '0');
            }
            var voltage = "0000";
            var holdTime = "00";
            if (this.projectInfo.InsulateTestVoltage != 0)
            {
                voltage = Convert.ToString((int)this.projectInfo.InsulateTestVoltage, 16).PadLeft(4, '0');
            }
            if (this.projectInfo.InsulateTestHoldTime != 0)
            {
                holdTime = Convert.ToString((int)this.projectInfo.InsulateTestHoldTime, 16).PadLeft(2, '0');
            }
            hexString = Convert.ToString(method).PadLeft(2, '0') + voltage + holdTime + hexString;

            return hexString;
        }

        private string GetDevPointPinByContactPoint(string interfaceName,string point)
        {
            var cableParamsObj = this.cableLibParamList.Find(obj => obj.InterfaceName == interfaceName && obj.InterContactPoint == point);
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
        /// 打开项目时，生成测试序列
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
            if (this.environmentAmbientHumidity == 0 || this.environmentTemperature == 0)
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

            foreach (var rowInfo in this.radGridViewCableTest.Rows)
            {
                //conduct
                if (conductCableTestType == CableTestProcessParams.CableTestType.ConductTest)
                {
                    if (rowInfo.Cells[5].Value.ToString() == "--" && rowInfo.Cells[6].Value.ToString() == "--")
                    {
                        rowInfo.Cells[5].Value = "";
                        rowInfo.Cells[6].Value = "";
                    }
                }
                else
                {
                    rowInfo.Cells[5].Value = "--";
                    rowInfo.Cells[6].Value = "--";
                }
                //circuit
                if (circuitCableTestType == CableTestProcessParams.CableTestType.ShortCircuitTest)
                {
                    if (rowInfo.Cells[7].Value.ToString() == "--" && rowInfo.Cells[8].Value.ToString() == "--")
                    {
                        rowInfo.Cells[7].Value = "";
                        rowInfo.Cells[8].Value = "";
                    }
                }
                else
                {
                    rowInfo.Cells[7].Value = "--";
                    rowInfo.Cells[8].Value = "--";
                }
                //insulate
                if (insulateCableTestType == CableTestProcessParams.CableTestType.InsulateTest)
                {
                    if (rowInfo.Cells[9].Value.ToString() == "--" && rowInfo.Cells[10].Value.ToString() == "--")
                    {
                        rowInfo.Cells[9].Value = "";
                        rowInfo.Cells[10].Value = "";
                    }
                }
                else
                {
                    rowInfo.Cells[9].Value = "--";
                    rowInfo.Cells[10].Value = "--";
                }
                //voltage
                if (voltageCableTestType == CableTestProcessParams.CableTestType.PressureWithVoltageTest)
                {
                    if (rowInfo.Cells[11].Value.ToString() == "--" && rowInfo.Cells[12].Value.ToString() == "--")
                    {
                        rowInfo.Cells[11].Value = "";
                        rowInfo.Cells[12].Value = "";
                    }
                }
                else
                {
                    rowInfo.Cells[11].Value = "--";
                    rowInfo.Cells[12].Value = "--";
                }
            }
        }
        #endregion

        private int FinalCalExceptCount(int colIndex)
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

        private void ExportPDF(string pdfFilePath)
        {
            using (Stream fs = new FileStream(pdfFilePath, FileMode.Create))
            {
                PDFOperation pdf = new PDFOperation();
                pdf.Open(fs);
                pdf.SetBaseFont(@"C:\Windows\Fonts\SIMHEI.TTF");
                //pdf.AddParagraph(sb.ToString(), 15, 1, 20, 0, 0);
                pdf.AddParagraph("测试报告\r\n", 20);
                pdf.AddLine(71);
                pdf.AddParagraph($"线束名称：{this.curLineCableName}     测试结果：{this.CalFinalTestResult()}", 15);
                pdf.AddParagraph($"环境湿度：{this.environmentAmbientHumidity}     测试温度：{this.environmentTemperature}\r\n", 15);
                pdf.AddParagraph($"测试人员：{LocalLogin.currentUserName}     测试日期：{this.startTestDate}\r\n", 15);
                pdf.AddLine(144);
                pdf.AddParagraph($"测试参数\r\n", 20);
                pdf.AddLine(171);
                pdf.AddParagraph($"导通测试阈值：{this.projectInfo.ConductTestThreshold}     短路测试阈值：{this.projectInfo.ShortCircuitTestThreshold}", 15);
                pdf.AddParagraph($"绝缘测试阈值：{this.projectInfo.InsulateTestThreshold}     绝缘保持时间：{this.projectInfo.InsulateTestHoldTime}", 15);
                pdf.AddParagraph($"绝缘电压：{this.projectInfo.InsulateTestVoltage}", 15);
                pdf.AddLine(241);
                pdf.AddParagraph($"异常明细\r\n\n", 20);
                pdf.AddParagraph("线束测试异常明细",GetCableTestExceptTable(), 15);
                //pdf.AddParagraph("\r\n", 15);
                pdf.AddParagraph("测试数据\r\n\r", 20);
                pdf.AddParagraph("线束测试合格明细",GetCableTestPassTable(), 15);
                pdf.Close();
            }
        }

        private DataTable GetCableTestExceptTable()
        {
            //导通测试结果//短路测试结果//绝缘测试结果//耐压测试结果
            var where = "导通测试结果 = '不合格' and 短路测试结果 = '不合格' and 绝缘测试结果 = '不合格'";
            where = "导通测试结果 = '--'";

            DataRow[] dataRow = this.dataSourceCableTest.Select(where);
            DataTable datasource = this.dataSourceCableTest.Clone();
            datasource.Columns.Remove("耐压电流(Ω)");
            datasource.Columns.Remove("耐压测试结果");
            datasource.Columns.Remove("testMethod");
            foreach (DataRow dr in dataRow)
            {
                datasource.ImportRow(dr);
            }
            return datasource;
        }

        private DataTable GetCableTestPassTable()
        {
            //导通测试结果//短路测试结果//绝缘测试结果//耐压测试结果
            var where = "导通测试结果='合格' and 短路测试结果='合格' and 绝缘测试结果='合格'";
            DataRow[] dataRow = this.dataSourceCableTest.Select(where);
            DataTable datasource = this.dataSourceCableTest.Clone();
            datasource.Columns.Remove("耐压电流(Ω)");
            datasource.Columns.Remove("耐压测试结果");
            datasource.Columns.Remove("testMethod");
            foreach (DataRow dr in dataRow)
            {
                datasource.ImportRow(dr);
            }
            return datasource;
        }
    }
}
