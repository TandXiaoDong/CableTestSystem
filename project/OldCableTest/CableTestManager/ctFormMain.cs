using Aspose.Cells;
using Aspose.Words;
using Aspose.Words.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormMain : Form
	{
		public ctFormAbout aboutForm;
		public ctFormInterfaceLibrary interfaceLibraryForm;
		public ctFormCableLibrary cableLibraryForm;
		public ctFormProjectCreate createProjectForm;
		public ctFormProjectOpen openProjectForm;
		public ctFormProjectTestDataView projectTestDataViewForm;
		public ctFormCableInfoView cableInfoViewForm;
		public ctFormProjectEdit editProjectForm;
		public ctFormSelfStudy selfStudyForm;
		public ctFormSelfTest selfTestForm;
		public ctFormDeviceDebugging deviceDebuggingForm;
		public ctFormWait waitFinishedForm;
		public ctFormErrorQuery errorQueryForm;
		public ctFormDeviceCalibration deviceCalibrationForm;
		public ctFormEnvironmentParaSet environmentParaSetForm;
		public ctFormPinPinContrast pinPinContrastForm;
		public ctFormResistanceCompensation resistanceCompensationForm;
		public ctFormDLTestResultView DLTestResultViewForm;
		public ctFormDDJYTestResultView DDjyTestResultViewForm;
		public ctFormIAndRTPinReletionManage iAndRTPinReletionManageForm;
		public ctFormConnectorLibManage connctorLibManageForm;
		public ctFormConverterLibManage converterLibManageForm;
		public ctFormConverterInfoView converterInfoViewForm;
		public ctFormSetDefaultSavePath setDefaultSavePathForm;
		public ctFormSelfStudyPinRelation selfStudyPinRelationForm;
		public ctFormDefaultTestParaSet defaultTestParaSetForm;
		public ctFormReportFormatSet reportFormatSetForm;
		public ctFormActiveProduct activeProductForm;
		public ctFormFaultHandling faultHandlingForm;
		public ctFormSD_LCRMeasure SD_LCRMeasureForm;
		public ctFormSD_WVTMeasure SD_WVTMeasureForm;
		public ctFormComponentMeasure componentMeasureForm;
		public ctFormBarcodeScanOpenProj barcodeScanOpenProjForm;
		public ctFormVoltMeasure voltMeasureForm;
		public ctFormGroupTestParaSet groupTestParaSetForm;
		public ctFormUnDefinedInterfaceMeasure unDefinedInterfaceMeasureForm;
		public ctFormProbeMeasure probeMeasureForm;
		public FormLogin loginForm;
		public FormRunningHint runningHintForm;
		public FormUpdateSecret updateSecretForm;
		public FormUserManage userManagementForm;
		public FormOperRecordManage operRecordManageForm;
		public FormEquipmentInfoManage equipmentInfoManageForm;
		public static string SOFTWARE_NAME_STR = "Cable Easy Test 1.0";
		public System.ValueType endTime;
		public System.ValueType netTime;
		public string licFilePathStr;
		public string dbpath;
		public string mddbpath;
		public bool bIsConnSuccFlag;
		public bool bExistDLFlag;
		public bool bReportSuccFlag;
		public bool bReportPrintSuccFlag;
		public bool bIsSaveDataFlag;
		public bool bIsAutoConnFlag;
		public bool bIsTestStatus;
		public bool bInquiryHintFlag;
		public bool bDeviceErrorWarnExistFlag;
		public bool bUploadErrorWarnExistFlag;
		public bool bJYTestXCDTFlag;
		public bool bNYTestXCDTFlag;
		public string exportPathStr;
		public string zRSDE_ID_Str;
		public string cRSDE_ID_Str;
		public string projectReportPathStr;
		public string[] proTreeStrArray;
		public System.Collections.Generic.List<string> commonProjStrArray;
		public static int TEST_INTERVAL_SECOND = 40;
		public static int TEST_INTE_HIGH_VOLT = 450;
		public static int SEND_STOP_CMD_NUM = 400;
		public static string NOT_DTTEST_HINT_STR = "当前未进行导通测试，可能存在故障点，您确定要继续吗?";
		public static string UN_TEST_COMM_STR = "--";
		public static string TEST_QUAL_STR = "合格";
		public static string TEST_NOT_QUAL_STR = "不合格";
		public static string PLUGPIN_UNDEFINED_STR = "未定义";
		public int iCommProjectNum;
		public int iRunProjectID;
		public int iRefreshDataCount;
		public bool bEnvironmentParaSetFlag;
		public bool bSelfStudyPinTestFlag;
		public System.Collections.Generic.List<string> ddjyTHeadNameList;
		public int iTestModel;
		public int iDTTestModel;
		public int iJYTestModel;
		public int iNYTestModel;
		public int iGroupTestFlag;
		public int iDBTypeIndex;
		public int iJYTestMethod;
		public int iNYTestMethod;
		public int iUesRelayBoard;
		public bool bCurrFastTestFlag;
		public double dDT_Threshold;
		public double dDT_DTVoltage;
		public double dDT_DTCurrent;
		public double dJY_Threshold;
		public double dJY_JYHoldTime;
		public double dJY_DCHighVolt;
		public double dJY_DCRiseTime;
		public double dDYJY_Threshold;
		public double dDYJY_JYHoldTime;
		public double dDYJY_DCHighVolt;
		public double dDYJY_DCRiseTime;
		public double dNY_Threshold;
		public double dNY_NYHoldTime;
		public double dNY_ACHighVolt;
		public string batchMumberStr;
		public string bcCableStr;
		public string ctTestNumberStr;
		public string testProjectNameStr;
		public string bcCableIDStr;
		public string bcPlugInfoStr;
		public string testResultStr;
		public int iHistoryDataInfoID;
		public int iDTTValueColNum;
		public int iJYTValueColNum;
		public int iNYTValueColNum;
		public int iDTResultColNum;
		public int iJYResultColNum;
		public int iNYResultColNum;
		public string[] studyPlugStrArray;
		public int[] iPlugStartPin;
		public int[] iPlugStopPin;
		public int iDLTestTime;
		public int iHintRecordNum;
		public int iHintDTExcNum;
		public int iHintDLExcNum;
		public int iHintJYExcNum;
		public int iHintDDJYExcNum;
		public int iHintNYExcNum;
		public int iTestTotalCount;
		public int iCurrTestIndex;
		public string strTestResult;
		public string ct_TestDateStr;
		public string ct_TestUserIDStr;
		public string ct_TestUserNameStr;
		public string ct_TestEnvironmentTempStr;
		public string ct_TestAmbientHumidityStr;
		public string ct_TestCSYTypeStr;
		public string ct_TestCSYMeasureNoStr;
		public string ct_TestPCHStr;
		public string ct_TestBCXSStr;
		public string ct_DTLimitValueStr;
		public string ct_DTVoltageStr;
		public string ct_DTCurrentStr;
		public string ct_JYLimitValueStr;
		public string ct_JYHoldTimeStr;
		public string ct_JYDCHighVoltStr;
		public string ct_JYDCRiseTimeStr;
		public string ct_NYLimitValueStr;
		public string ct_NYHoldTimeStr;
		public string ct_NYACHighVoltStr;
		public string reportDefaultSavePathStr;
		public bool bIsExistReportFlag;
		public bool bIsYJCSFlag;
		public bool bChoiceTestFlag;
		public int iDTTFFlag;
		public int iDLTFFlag;
		public int iJYTFFlag;
		public int iDDJYTFFlag;
		public int iNYTFFlag;
		public int iJYTestRelaCount;
		public int iNYTestRelaCount;
		public int iHVTWaitingTime;
		public bool bHVTWaitingFlag;
		public int iDisconnectCount;
		public int iCurrentCount;
		public int iPlugPinIndex;
		public bool bIsExistMapFlag;
		public bool bCurrDLTestFlag;
		public bool bCurrJYTestFlag;
		public bool bCurrDDJYTestFlag;
		public bool bCurrNYTestFlag;
		public bool bLoginSuccFlag;
		public bool btestDelayFlag;
		public bool bTreeViewShowFlag;
		public int iTreeViewWidth;
		public string ct_iDTTFFlagStr;
		public string ct_iDLTFFlagStr;
		public string ct_iJYTFFlagStr;
		public string ct_iDDJYTFFlagStr;
		public string ct_iNYTFFlagStr;
		public string reportBackPathStr;
		public string reportBackFNStr;
		public string noSeleHintStr;
		public string noMapZJTpinHintStr;
		public string otsShowInfoStr;
		public System.ValueType dt;
		public System.ValueType pointTVNormal;
		public System.ValueType pointTVMaximum;
		public System.ValueType sizeTVNormal;
		public System.ValueType sizeTVMaximum;
		public System.ValueType pointTSNormal;
		public System.ValueType pointTSMaximum;
		public System.ValueType sizeTSNormal;
		public System.ValueType sizeTSMaximum;
		public System.ValueType pointJDNormal;
		public System.ValueType pointJDMaximum;
		public System.ValueType sizeJDNormal;
		public System.ValueType sizeJDMaximum;
		public System.Drawing.Color otsShowInfoColor;
		public KLineTestProcessor gLineTestProcessor;
		private System.Windows.Forms.Timer timer_Delay;
		private ToolStripButton toolStripButton_ProbeMeasure;
		private ToolStripSeparator toolStripSeparator_ProbeMeasure;
		private ToolStripSeparator toolStripSeparator_UnDefinedInterfaceTest;
		private ToolStripMenuItem MenuItem_UnDefinedInterfaceTest;
		private ToolStripSeparator toolStripSeparator_VoltMeasure;
		private ToolStripMenuItem MenuItem_VoltMeasure;
		private ToolStripSeparator toolStripSeparator_AuxiliaryPowerSupply;
		private ToolStripMenuItem MenuItem_AuxiliaryPowerSupply;
		private ToolStripMenuItem MenuItem_SMOpenProject;
		private ToolStripSeparator toolStripSeparator_MenuItem_SMOpenProject;
		private ToolStripSeparator toolStripSeparator_SwitchAccount;
		private ToolStripMenuItem MenuItem_SwitchAccount;
		private ToolStripSeparator toolStripSeparator_ComponentMeasure;
		private ToolStripMenuItem MenuItem_ComponentMeasure;
		private Label label_TVYCXSSet;
		private ToolStripSeparator toolStripSeparator_SingleDevice_NYTEST;
		private ToolStripMenuItem MenuItem_SingleDevice_NYTEST;
		private ToolStripSeparator toolStripSeparator_SingleDevice_DRTEST;
		private ToolStripMenuItem MenuItem_SingleDevice_DRTEST;
		private NotifyIcon notifyIcon_ctm;
		private System.Windows.Forms.Timer timer_RefreshIndex;
		private ToolStripSeparator toolStripSeparator_EmulationMode;
		private ToolStripMenuItem MenuItem_EmulationMode;
		private ToolStripSeparator toolStripSeparator_EquipmentInfoManage;
		private ToolStripMenuItem MenuItem_EquipmentInfoManage;
		private System.Windows.Forms.Timer timer_checkLifeTime;
		private ContextMenuStrip contextMenuStrip_DataProc;
		private ToolStripMenuItem toolStripMenuItem_ExportData;
		private ToolStripSeparator toolStripSeparator_DefaultTestParaSet;
		private ToolStripMenuItem MenuItem_ReportFormatSet;
		private ToolStripMenuItem MenuItem_EnvironmentParaSet;
		private ToolStripSeparator toolStripSeparator6;
		private ToolStripMenuItem MenuItem_ReportSavePathSet;
		private ToolStripSeparator toolStripSeparator11;
		private ToolStripMenuItem MenuItem_DefaultTestParaSet;
		private ToolStripSeparator toolStripSeparator_SystemParaSet;
		private ToolStripMenuItem MenuItem_SystemParaSet;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripMenuItem MenuItem_DeviceDebugging;
		private ToolStripSeparator toolStripSeparator_CurrentDDJYTestData;
		private ToolStripMenuItem MenuItem_HistoryDataBrowse;
		private ToolStripMenuItem MenuItem_DTTEST;
		private ToolStripSeparator toolStripSeparator_DTTEST;
		private ToolStripMenuItem MenuItem_DLTEST;
		private ToolStripSeparator toolStripSeparator_DLTEST;
		private ToolStripMenuItem MenuItem_JYTEST;
		private ToolStripSeparator toolStripSeparator_JYTEST;
		private ToolStripMenuItem MenuItem_DDJYTEST;
		private ToolStripSeparator toolStripSeparator_DDJYTEST;
		private ToolStripMenuItem MenuItem_NYTEST;
		private ToolStripSeparator toolStripSeparator_NYTEST;
		private FlowLayoutPanel flowLayoutPanel1;
		private FlowLayoutPanel flowLayoutPanel2;
		private ContextMenuStrip contextMenuStrip_DTJYNY;
		private ToolStripMenuItem toolStripMenuItem_DT;
		private ToolStripSeparator toolStripSeparator_JY;
		private ToolStripMenuItem toolStripMenuItem_JY;
		private ToolStripSeparator toolStripSeparator_NY;
		private ToolStripMenuItem toolStripMenuItem_NY;
		private Button btnStartNYTest;
		private ToolStripSeparator toolStripSeparator_ErrorQuery;
		private ToolStripMenuItem MenuItem_ErrorQuery;
		private ToolStripMenuItem MenuItem_User;
		private ToolStripMenuItem MenuItem_UserManage;
		private ToolStripSeparator toolStripSeparator_UserManage;
		private ToolStripMenuItem MenuItem_SecretManage;
		private ToolStripSeparator toolStripSeparator25;
		private ToolStripMenuItem MenuItem_OperRecordManage;
		private ToolStripMenuItem MenuItem_TestData;
		private ToolStripMenuItem MenuItem_CurrentDLTestData;
		private ToolStripSeparator toolStripSeparator_CurrentDLTestData;
		private ToolStripMenuItem MenuItem_CurrentDDJYTestData;
		private DataGridViewTextBoxColumn dgvTextBoxColumn_commProject;
		private ToolStripMenuItem MenuItem_CreateProject;
		private ToolStripSeparator toolStripSeparator_MenuItem_CreateProject;
		private ToolStripMenuItem MenuItem_OpenProject;
		private ToolStripSeparator toolStripSeparator_MenuItem_OpenProject;
		private Label label_ExceptionHint;
		private ToolStripSeparator toolStripSeparator_IAndRT_PinReletion;
		private ToolStripMenuItem MenuItem_ConnectorLibManage;
		private ToolStripSeparator toolStripSeparator13;
		private ToolStripMenuItem MenuItem_IAndRT_PinReletion;
		private ToolStripSeparator toolStripSeparator_AdapterCableLibManage;
		private ToolStripMenuItem MenuItem_AdapterCableLibManage;
		private PictureBox pictureBox_warning;
		private ToolStripMenuItem MenuItem_SBJZ;
		private ToolStripSeparator toolStripSeparator12;
		private ToolStripMenuItem MenuItem_StartSelfTest;
		private GroupBox groupBox_CommProject;
		private DataGridView dataGridView_CommProject;
		private System.Windows.Forms.Timer timer_YJCS;
		private Button btnYJCS;
		private Button btnStartDDJYTest;
		private System.Windows.Forms.Timer timer_DDJYTest;
		private System.Windows.Forms.Timer timer_dlTest;
		private Button btnStartDLTest;
		private ToolStripSeparator toolStripSeparator7;
		private ToolStripMenuItem MenuItem_ResistanceCompensation;
		private ToolStripSeparator toolStripSeparator_ResistanceCompensation;
		private ToolStripMenuItem MenuItem_RCM;
		private FolderBrowserDialog folderBrowserDialog1;
		private Button btnSaveTestData;
		private Button btnStartJYTest;
		private ToolStripButton toolStripButton_SelfStudy;
		private ToolStripSeparator toolStripSeparator_SelfStudy;
		private ToolStripMenuItem MenuItem_SelfStudy;
		private ImageList imageList1;
		private System.Windows.Forms.Timer timer_ace;
		private System.Windows.Forms.Timer timer_projectTest;
		private Panel panel_projectTest;
		private Button btnPrintReport;
		private Button btnCreateReport;
		private Button btnStartDTTest;
		private ToolStripSeparator toolStripSeparator16;
		private Panel panel_projectInfo;
		private Panel panel_testData;
		private Panel panel_testNote;
		private Label label_ots;
		private Label label_progress;
		private TreeView treeView_projectInfo;
		private Panel panel_tsxx;
		private Panel panel_progress;
		private ProgressBar progressBar_test;
		private DataGridView dataGridView1;
		private DataGridViewTextBoxColumn Column_xh;
		private DataGridViewTextBoxColumn Column_startInterface;
		private DataGridViewTextBoxColumn Column_startPin;
		private DataGridViewTextBoxColumn Column_stopInterface;
		private DataGridViewTextBoxColumn Column_stopPin;
		private DataGridViewTextBoxColumn Column_dtValue;
		private DataGridViewTextBoxColumn Column_dtResult;
		private DataGridViewTextBoxColumn Column_jyValue;
		private DataGridViewTextBoxColumn Column_jyResult;
		private DataGridViewTextBoxColumn Column_nyValue;
		private DataGridViewTextBoxColumn Column_nyResult;
		private ToolStripMenuItem MenuItem_CloseProject;
		private ToolStripSeparator toolStripSeparator_MenuItem_CloseProject;
		private ToolStripMenuItem MenuItem_DisConnEquipment;
		private Button btnCloseProject;
		private ToolStripStatusLabel toolStripStatusLabel_csyConnStatus;
		private Panel panel1;
		private Label label3;
		private Label label_OpenProject;
		private PictureBox pictureBox5;
		private PictureBox pictureBox4;
		private Label label_CreateProject;
		private PictureBox pictureBox3;
		private Panel panel_note;
		private PictureBox pictureBox2;
		private RichTextBox richTextBox1;
		private PictureBox pictureBox1;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem MenuItem_File;
		private ToolStripMenuItem MenuItem_Exit;
		private ToolStripMenuItem MenuItem_LibManage;
		private ToolStripMenuItem MenuItem_InterfaceLibManage;
		private ToolStripSeparator toolStripSeparator5;
		private ToolStripMenuItem MenuItem_CableLibManage;
		private ToolStripMenuItem MenuItem_Measure;
		private ToolStripMenuItem MenuItem_Tool;
		private ToolStripMenuItem MenuItem_ConnEquipment;
		private ToolStripMenuItem MenuItem_Set;
		private ToolStripMenuItem MenuItem_Help;
		private ToolStripMenuItem MenuItem_HelpView;
		private ToolStripSeparator toolStripSeparator10;
		private ToolStripMenuItem MenuItem_About;
		private ToolStripStatusLabel toolStripStatusLabel_csy;
		private ToolStripSeparator toolStripSeparator_SBTS;
		private ToolStripMenuItem MenuItem_SBTS;
		private ToolStripMenuItem MenuItem_EquipmentAutoConn;
		private ToolStrip toolStrip1;
		private ToolStripButton toolStripButton_InterfaceLibManage;
		private ToolStripSeparator toolStripSeparator_InterfaceLibManage;
		private ToolStripButton toolStripButton_CableLibManage;
		private ToolStripSeparator toolStripSeparator_CableLibManage;
		private ToolStripButton toolStripButton_CreateProject;
		private ToolStripSeparator toolStripSeparator_CreateProject;
		private ToolStripButton toolStripButton_OpenProject;
		private ToolStripSeparator toolStripSeparator_OpenProject;
		private ToolStripButton toolStripButton_HistoryDataView;
		private ToolStripSeparator toolStripSeparator_HistoryDataView;
		private ToolStripButton toolStripButton_ConnEquipment;
		private ToolStripSeparator toolStripSeparator_ConnEquipment;
		private Panel panel_work;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel toolStripStatusLabel_currentLoginUser;
		private ToolStripStatusLabel toolStripStatusLabel_currentTime;
		private System.Windows.Forms.Timer timer_getTime;
		private IContainer components;
		public ctFormMain()
		{
			try
			{
				this.InitializeComponent();
				try
				{
					base.Visible = false;
					if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).GetUpperBound(0) <= 0)
					{
						try
						{
							this.gLineTestProcessor = new KLineTestProcessor();
							System.Threading.Thread.Sleep(200);
						}
						catch (System.Exception arg_6B_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_6B_0.StackTrace);
						}
						this.InitSysVariableFunc();
						this.GetEngineerParaFunc();
						KLineTestProcessor this2 = this.gLineTestProcessor;
						if (this2.iUIDisplayMode == 1)
						{
							this.bLoginSuccFlag = true;
							this2.bIsAdminFlag = false;
							this.gLineTestProcessor.loginUserID = "操作员";
							this.gLineTestProcessor.loginUserPsw = "123456";
							this.gLineTestProcessor.loginUserName = "操作员";
							this2 = this.gLineTestProcessor;
							this.ct_TestUserIDStr = this2.loginUserID;
							this.ct_TestUserNameStr = this2.loginUserName;
						}
						else
						{
							FormLogin formLogin = new FormLogin(this2);
							this.loginForm = formLogin;
							formLogin.Activate();
							this.loginForm.TopMost = true;
							this.loginForm.ShowDialog();
							FormLogin formLogin2 = this.loginForm;
							bool flag = formLogin2.bLoginSuccFlag;
							this.bLoginSuccFlag = flag;
							if (flag)
							{
								this.gLineTestProcessor.bIsAdminFlag = formLogin2.bIsAdminFlag;
								this.gLineTestProcessor.loginUserID = this.loginForm.loginUser;
								this.gLineTestProcessor.loginUserPsw = this.loginForm.loginSecr;
								this.gLineTestProcessor.loginUserName = this.loginForm.loginName;
								formLogin2 = this.loginForm;
								this.ct_TestUserIDStr = formLogin2.loginUser;
								this.ct_TestUserNameStr = formLogin2.loginName;
							}
						}
					}
					else
					{
						base.WindowState = FormWindowState.Minimized;
						this.bLoginSuccFlag = false;
						MessageBox.Show("程序正在运行，请不要重复操作!如果软件已关闭，请30秒后重试!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				catch (System.Exception arg_1AD_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_1AD_0.StackTrace);
					this.bLoginSuccFlag = false;
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		//private void ctFormMain()
		//{
		//	IContainer this2 = this.components;
		//	if (this2 != null)
		//	{
		//		this2.Dispose();
		//	}
		//}
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormMain));
			TreeNode treeNode = new TreeNode("编辑项目");
			TreeNode treeNode2 = new TreeNode("项目信息", new TreeNode[]
			{
				treeNode
			});
			TreeNode treeNode3 = new TreeNode("查看线束");
			TreeNode treeNode4 = new TreeNode("被测线束", new TreeNode[]
			{
				treeNode3
			});
			TreeNode treeNode5 = new TreeNode("清除数据");
			TreeNode treeNode6 = new TreeNode("测试数据", new TreeNode[]
			{
				treeNode5
			});
			TreeNode treeNode7 = new TreeNode("生成报表");
			TreeNode treeNode8 = new TreeNode("打印报表");
			TreeNode treeNode9 = new TreeNode("生成报表", new TreeNode[]
			{
				treeNode7,
				treeNode8
			});
			TreeNode treeNode10 = new TreeNode("项目名称", new TreeNode[]
			{
				treeNode2,
				treeNode4,
				treeNode6,
				treeNode9
			});
			TreeNode treeNode11 = new TreeNode("查看设备");
			TreeNode treeNode12 = new TreeNode("设备信息", new TreeNode[]
			{
				treeNode11
			});
			this.statusStrip1 = new StatusStrip();
			this.toolStripStatusLabel_currentLoginUser = new ToolStripStatusLabel();
			this.toolStripStatusLabel_currentTime = new ToolStripStatusLabel();
			this.toolStripStatusLabel_csy = new ToolStripStatusLabel();
			this.toolStripStatusLabel_csyConnStatus = new ToolStripStatusLabel();
			this.timer_getTime = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1 = new MenuStrip();
			this.MenuItem_File = new ToolStripMenuItem();
			this.MenuItem_CreateProject = new ToolStripMenuItem();
			this.toolStripSeparator_MenuItem_CreateProject = new ToolStripSeparator();
			this.MenuItem_OpenProject = new ToolStripMenuItem();
			this.toolStripSeparator_MenuItem_OpenProject = new ToolStripSeparator();
			this.MenuItem_SMOpenProject = new ToolStripMenuItem();
			this.toolStripSeparator_MenuItem_SMOpenProject = new ToolStripSeparator();
			this.MenuItem_CloseProject = new ToolStripMenuItem();
			this.toolStripSeparator_MenuItem_CloseProject = new ToolStripSeparator();
			this.MenuItem_Exit = new ToolStripMenuItem();
			this.MenuItem_User = new ToolStripMenuItem();
			this.MenuItem_UserManage = new ToolStripMenuItem();
			this.toolStripSeparator_UserManage = new ToolStripSeparator();
			this.MenuItem_SecretManage = new ToolStripMenuItem();
			this.toolStripSeparator25 = new ToolStripSeparator();
			this.MenuItem_OperRecordManage = new ToolStripMenuItem();
			this.MenuItem_LibManage = new ToolStripMenuItem();
			this.MenuItem_ConnectorLibManage = new ToolStripMenuItem();
			this.toolStripSeparator13 = new ToolStripSeparator();
			this.MenuItem_InterfaceLibManage = new ToolStripMenuItem();
			this.toolStripSeparator5 = new ToolStripSeparator();
			this.MenuItem_CableLibManage = new ToolStripMenuItem();
			this.toolStripSeparator_IAndRT_PinReletion = new ToolStripSeparator();
			this.MenuItem_IAndRT_PinReletion = new ToolStripMenuItem();
			this.toolStripSeparator_AdapterCableLibManage = new ToolStripSeparator();
			this.MenuItem_AdapterCableLibManage = new ToolStripMenuItem();
			this.MenuItem_Measure = new ToolStripMenuItem();
			this.MenuItem_SelfStudy = new ToolStripMenuItem();
			this.toolStripSeparator_DTTEST = new ToolStripSeparator();
			this.MenuItem_DTTEST = new ToolStripMenuItem();
			this.toolStripSeparator_DLTEST = new ToolStripSeparator();
			this.MenuItem_DLTEST = new ToolStripMenuItem();
			this.toolStripSeparator_JYTEST = new ToolStripSeparator();
			this.MenuItem_JYTEST = new ToolStripMenuItem();
			this.toolStripSeparator_DDJYTEST = new ToolStripSeparator();
			this.MenuItem_DDJYTEST = new ToolStripMenuItem();
			this.toolStripSeparator_NYTEST = new ToolStripSeparator();
			this.MenuItem_NYTEST = new ToolStripMenuItem();
			this.toolStripSeparator_SingleDevice_NYTEST = new ToolStripSeparator();
			this.MenuItem_SingleDevice_NYTEST = new ToolStripMenuItem();
			this.toolStripSeparator_SingleDevice_DRTEST = new ToolStripSeparator();
			this.MenuItem_SingleDevice_DRTEST = new ToolStripMenuItem();
			this.toolStripSeparator_UnDefinedInterfaceTest = new ToolStripSeparator();
			this.MenuItem_UnDefinedInterfaceTest = new ToolStripMenuItem();
			this.MenuItem_TestData = new ToolStripMenuItem();
			this.MenuItem_CurrentDLTestData = new ToolStripMenuItem();
			this.toolStripSeparator_CurrentDLTestData = new ToolStripSeparator();
			this.MenuItem_CurrentDDJYTestData = new ToolStripMenuItem();
			this.toolStripSeparator_CurrentDDJYTestData = new ToolStripSeparator();
			this.MenuItem_HistoryDataBrowse = new ToolStripMenuItem();
			this.MenuItem_Tool = new ToolStripMenuItem();
			this.MenuItem_ConnEquipment = new ToolStripMenuItem();
			this.toolStripSeparator16 = new ToolStripSeparator();
			this.MenuItem_DisConnEquipment = new ToolStripMenuItem();
			this.toolStripSeparator_ErrorQuery = new ToolStripSeparator();
			this.MenuItem_ErrorQuery = new ToolStripMenuItem();
			this.toolStripSeparator_SBTS = new ToolStripSeparator();
			this.MenuItem_SBTS = new ToolStripMenuItem();
			this.MenuItem_SBJZ = new ToolStripMenuItem();
			this.toolStripSeparator12 = new ToolStripSeparator();
			this.MenuItem_StartSelfTest = new ToolStripMenuItem();
			this.toolStripSeparator2 = new ToolStripSeparator();
			this.MenuItem_DeviceDebugging = new ToolStripMenuItem();
			this.toolStripSeparator_ComponentMeasure = new ToolStripSeparator();
			this.MenuItem_ComponentMeasure = new ToolStripMenuItem();
			this.toolStripSeparator_VoltMeasure = new ToolStripSeparator();
			this.MenuItem_VoltMeasure = new ToolStripMenuItem();
			this.MenuItem_Set = new ToolStripMenuItem();
			this.MenuItem_EquipmentAutoConn = new ToolStripMenuItem();
			this.toolStripSeparator_AuxiliaryPowerSupply = new ToolStripSeparator();
			this.MenuItem_AuxiliaryPowerSupply = new ToolStripMenuItem();
			this.toolStripSeparator_ResistanceCompensation = new ToolStripSeparator();
			this.MenuItem_ResistanceCompensation = new ToolStripMenuItem();
			this.toolStripSeparator7 = new ToolStripSeparator();
			this.MenuItem_RCM = new ToolStripMenuItem();
			this.toolStripSeparator_EquipmentInfoManage = new ToolStripSeparator();
			this.MenuItem_EquipmentInfoManage = new ToolStripMenuItem();
			this.toolStripSeparator_SystemParaSet = new ToolStripSeparator();
			this.MenuItem_SystemParaSet = new ToolStripMenuItem();
			this.MenuItem_EnvironmentParaSet = new ToolStripMenuItem();
			this.toolStripSeparator_DefaultTestParaSet = new ToolStripSeparator();
			this.MenuItem_DefaultTestParaSet = new ToolStripMenuItem();
			this.toolStripSeparator6 = new ToolStripSeparator();
			this.MenuItem_ReportSavePathSet = new ToolStripMenuItem();
			this.toolStripSeparator11 = new ToolStripSeparator();
			this.MenuItem_ReportFormatSet = new ToolStripMenuItem();
			this.toolStripSeparator_SwitchAccount = new ToolStripSeparator();
			this.MenuItem_SwitchAccount = new ToolStripMenuItem();
			this.MenuItem_Help = new ToolStripMenuItem();
			this.MenuItem_About = new ToolStripMenuItem();
			this.toolStripSeparator10 = new ToolStripSeparator();
			this.MenuItem_HelpView = new ToolStripMenuItem();
			this.toolStripSeparator_EmulationMode = new ToolStripSeparator();
			this.MenuItem_EmulationMode = new ToolStripMenuItem();
			this.toolStrip1 = new ToolStrip();
			this.toolStripButton_InterfaceLibManage = new ToolStripButton();
			this.toolStripSeparator_InterfaceLibManage = new ToolStripSeparator();
			this.toolStripButton_CableLibManage = new ToolStripButton();
			this.toolStripSeparator_CableLibManage = new ToolStripSeparator();
			this.toolStripButton_CreateProject = new ToolStripButton();
			this.toolStripSeparator_CreateProject = new ToolStripSeparator();
			this.toolStripButton_OpenProject = new ToolStripButton();
			this.toolStripSeparator_OpenProject = new ToolStripSeparator();
			this.toolStripButton_HistoryDataView = new ToolStripButton();
			this.toolStripSeparator_HistoryDataView = new ToolStripSeparator();
			this.toolStripButton_ConnEquipment = new ToolStripButton();
			this.toolStripSeparator_ConnEquipment = new ToolStripSeparator();
			this.toolStripButton_SelfStudy = new ToolStripButton();
			this.toolStripSeparator_SelfStudy = new ToolStripSeparator();
			this.toolStripButton_ProbeMeasure = new ToolStripButton();
			this.toolStripSeparator_ProbeMeasure = new ToolStripSeparator();
			this.panel_work = new Panel();
			this.panel_projectTest = new Panel();
			this.flowLayoutPanel2 = new FlowLayoutPanel();
			this.btnCreateReport = new Button();
			this.btnPrintReport = new Button();
			this.btnSaveTestData = new Button();
			this.btnCloseProject = new Button();
			this.flowLayoutPanel1 = new FlowLayoutPanel();
			this.btnStartDTTest = new Button();
			this.btnStartDLTest = new Button();
			this.btnStartJYTest = new Button();
			this.btnStartDDJYTest = new Button();
			this.btnStartNYTest = new Button();
			this.btnYJCS = new Button();
			this.panel_progress = new Panel();
			this.label_progress = new Label();
			this.progressBar_test = new ProgressBar();
			this.panel_tsxx = new Panel();
			this.label_ExceptionHint = new Label();
			this.panel_testData = new Panel();
			this.dataGridView1 = new DataGridView();
			this.Column_xh = new DataGridViewTextBoxColumn();
			this.Column_startInterface = new DataGridViewTextBoxColumn();
			this.Column_startPin = new DataGridViewTextBoxColumn();
			this.Column_stopInterface = new DataGridViewTextBoxColumn();
			this.Column_stopPin = new DataGridViewTextBoxColumn();
			this.Column_dtValue = new DataGridViewTextBoxColumn();
			this.Column_dtResult = new DataGridViewTextBoxColumn();
			this.Column_jyValue = new DataGridViewTextBoxColumn();
			this.Column_jyResult = new DataGridViewTextBoxColumn();
			this.Column_nyValue = new DataGridViewTextBoxColumn();
			this.Column_nyResult = new DataGridViewTextBoxColumn();
			this.panel_testNote = new Panel();
			this.label_ots = new Label();
			this.panel_projectInfo = new Panel();
			this.label_TVYCXSSet = new Label();
			this.pictureBox_warning = new PictureBox();
			this.treeView_projectInfo = new TreeView();
			this.imageList1 = new ImageList(this.components);
			this.panel1 = new Panel();
			this.groupBox_CommProject = new GroupBox();
			this.dataGridView_CommProject = new DataGridView();
			this.dgvTextBoxColumn_commProject = new DataGridViewTextBoxColumn();
			this.label3 = new Label();
			this.label_OpenProject = new Label();
			this.pictureBox5 = new PictureBox();
			this.pictureBox4 = new PictureBox();
			this.label_CreateProject = new Label();
			this.pictureBox3 = new PictureBox();
			this.panel_note = new Panel();
			this.richTextBox1 = new RichTextBox();
			this.pictureBox2 = new PictureBox();
			this.pictureBox1 = new PictureBox();
			this.timer_projectTest = new System.Windows.Forms.Timer(this.components);
			this.timer_ace = new System.Windows.Forms.Timer(this.components);
			this.folderBrowserDialog1 = new FolderBrowserDialog();
			this.timer_dlTest = new System.Windows.Forms.Timer(this.components);
			this.timer_DDJYTest = new System.Windows.Forms.Timer(this.components);
			this.timer_YJCS = new System.Windows.Forms.Timer(this.components);
			this.contextMenuStrip_DTJYNY = new ContextMenuStrip(this.components);
			this.toolStripMenuItem_DT = new ToolStripMenuItem();
			this.toolStripSeparator_JY = new ToolStripSeparator();
			this.toolStripMenuItem_JY = new ToolStripMenuItem();
			this.toolStripSeparator_NY = new ToolStripSeparator();
			this.toolStripMenuItem_NY = new ToolStripMenuItem();
			this.contextMenuStrip_DataProc = new ContextMenuStrip(this.components);
			this.toolStripMenuItem_ExportData = new ToolStripMenuItem();
			this.timer_checkLifeTime = new System.Windows.Forms.Timer(this.components);
			this.timer_RefreshIndex = new System.Windows.Forms.Timer(this.components);
			this.notifyIcon_ctm = new NotifyIcon(this.components);
			this.timer_Delay = new System.Windows.Forms.Timer(this.components);
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.panel_work.SuspendLayout();
			this.panel_projectTest.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.panel_progress.SuspendLayout();
			this.panel_tsxx.SuspendLayout();
			this.panel_testData.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			this.panel_testNote.SuspendLayout();
			this.panel_projectInfo.SuspendLayout();
			((ISupportInitialize)this.pictureBox_warning).BeginInit();
			this.panel1.SuspendLayout();
			this.groupBox_CommProject.SuspendLayout();
			((ISupportInitialize)this.dataGridView_CommProject).BeginInit();
			((ISupportInitialize)this.pictureBox5).BeginInit();
			((ISupportInitialize)this.pictureBox4).BeginInit();
			((ISupportInitialize)this.pictureBox3).BeginInit();
			this.panel_note.SuspendLayout();
			((ISupportInitialize)this.pictureBox2).BeginInit();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			this.contextMenuStrip_DTJYNY.SuspendLayout();
			this.contextMenuStrip_DataProc.SuspendLayout();
			base.SuspendLayout();
			this.statusStrip1.Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			ToolStripItem[] toolStripItems = new ToolStripItem[]
			{
				this.toolStripStatusLabel_currentLoginUser,
				this.toolStripStatusLabel_currentTime,
				this.toolStripStatusLabel_csy,
				this.toolStripStatusLabel_csyConnStatus
			};
			this.statusStrip1.Items.AddRange(toolStripItems);
			System.Drawing.Point location = new System.Drawing.Point(0, 639);
			this.statusStrip1.Location = location;
			this.statusStrip1.Name = "statusStrip1";
			Padding padding = new Padding(1, 0, 10, 0);
			this.statusStrip1.Padding = padding;
			System.Drawing.Size size = new System.Drawing.Size(1074, 22);
			this.statusStrip1.Size = size;
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			this.toolStripStatusLabel_currentLoginUser.Image = (System.Drawing.Image)resources.GetObject("toolStripStatusLabel_currentLoginUser.Image");
			this.toolStripStatusLabel_currentLoginUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripStatusLabel_currentLoginUser.Name = "toolStripStatusLabel_currentLoginUser";
			System.Drawing.Size size2 = new System.Drawing.Size(123, 17);
			this.toolStripStatusLabel_currentLoginUser.Size = size2;
			this.toolStripStatusLabel_currentLoginUser.Text = "当前用户：admin  ";
			this.toolStripStatusLabel_currentLoginUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripStatusLabel_currentTime.Image = (System.Drawing.Image)resources.GetObject("toolStripStatusLabel_currentTime.Image");
			this.toolStripStatusLabel_currentTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripStatusLabel_currentTime.Name = "toolStripStatusLabel_currentTime";
			System.Drawing.Size size3 = new System.Drawing.Size(195, 17);
			this.toolStripStatusLabel_currentTime.Size = size3;
			this.toolStripStatusLabel_currentTime.Text = "当前时间：2018/8/8 18:18:18  ";
			this.toolStripStatusLabel_currentTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripStatusLabel_csy.Image = (System.Drawing.Image)resources.GetObject("toolStripStatusLabel_csy.Image");
			this.toolStripStatusLabel_csy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripStatusLabel_csy.Name = "toolStripStatusLabel_csy";
			System.Drawing.Size size4 = new System.Drawing.Size(81, 17);
			this.toolStripStatusLabel_csy.Size = size4;
			this.toolStripStatusLabel_csy.Text = "连接状态：";
			this.toolStripStatusLabel_csy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripStatusLabel_csyConnStatus.Name = "toolStripStatusLabel_csyConnStatus";
			System.Drawing.Size size5 = new System.Drawing.Size(41, 17);
			this.toolStripStatusLabel_csyConnStatus.Size = size5;
			this.toolStripStatusLabel_csyConnStatus.Text = "未连接";
			this.toolStripStatusLabel_csyConnStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.timer_getTime.Enabled = true;
			this.timer_getTime.Interval = 1000;
			this.timer_getTime.Tick += new System.EventHandler(this.timer_getTime_Tick);
			System.Drawing.Color buttonFace = System.Drawing.SystemColors.ButtonFace;
			this.menuStrip1.BackColor = buttonFace;
			this.menuStrip1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			ToolStripItem[] toolStripItems2 = new ToolStripItem[]
			{
				this.MenuItem_File,
				this.MenuItem_User,
				this.MenuItem_LibManage,
				this.MenuItem_Measure,
				this.MenuItem_TestData,
				this.MenuItem_Tool,
				this.MenuItem_Set,
				this.MenuItem_Help
			};
			this.menuStrip1.Items.AddRange(toolStripItems2);
			System.Drawing.Point location2 = new System.Drawing.Point(0, 0);
			this.menuStrip1.Location = location2;
			this.menuStrip1.Name = "menuStrip1";
			Padding padding2 = new Padding(4, 2, 0, 2);
			this.menuStrip1.Padding = padding2;
			System.Drawing.Size size6 = new System.Drawing.Size(1074, 24);
			this.menuStrip1.Size = size6;
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			ToolStripItem[] toolStripItems3 = new ToolStripItem[]
			{
				this.MenuItem_CreateProject,
				this.toolStripSeparator_MenuItem_CreateProject,
				this.MenuItem_OpenProject,
				this.toolStripSeparator_MenuItem_OpenProject,
				this.MenuItem_SMOpenProject,
				this.toolStripSeparator_MenuItem_SMOpenProject,
				this.MenuItem_CloseProject,
				this.toolStripSeparator_MenuItem_CloseProject,
				this.MenuItem_Exit
			};
			this.MenuItem_File.DropDownItems.AddRange(toolStripItems3);
			this.MenuItem_File.Name = "MenuItem_File";
			System.Drawing.Size size7 = new System.Drawing.Size(73, 20);
			this.MenuItem_File.Size = size7;
			this.MenuItem_File.Text = "文件(&F)";
			this.MenuItem_CreateProject.Name = "MenuItem_CreateProject";
			System.Drawing.Size size8 = new System.Drawing.Size(188, 22);
			this.MenuItem_CreateProject.Size = size8;
			this.MenuItem_CreateProject.Text = "新建项目(&N)";
			this.MenuItem_CreateProject.Click += new System.EventHandler(this.MenuItem_CreateProject_Click);
			this.toolStripSeparator_MenuItem_CreateProject.Name = "toolStripSeparator_MenuItem_CreateProject";
			System.Drawing.Size size9 = new System.Drawing.Size(185, 6);
			this.toolStripSeparator_MenuItem_CreateProject.Size = size9;
			this.MenuItem_OpenProject.Name = "MenuItem_OpenProject";
			System.Drawing.Size size10 = new System.Drawing.Size(188, 22);
			this.MenuItem_OpenProject.Size = size10;
			this.MenuItem_OpenProject.Text = "打开项目(&O)";
			this.MenuItem_OpenProject.Click += new System.EventHandler(this.MenuItem_OpenProject_Click);
			this.toolStripSeparator_MenuItem_OpenProject.Name = "toolStripSeparator_MenuItem_OpenProject";
			System.Drawing.Size size11 = new System.Drawing.Size(185, 6);
			this.toolStripSeparator_MenuItem_OpenProject.Size = size11;
			this.MenuItem_SMOpenProject.Name = "MenuItem_SMOpenProject";
			System.Drawing.Size size12 = new System.Drawing.Size(188, 22);
			this.MenuItem_SMOpenProject.Size = size12;
			this.MenuItem_SMOpenProject.Text = "扫码打开项目(&B)";
			this.MenuItem_SMOpenProject.Click += new System.EventHandler(this.MenuItem_SMOpenProject_Click);
			this.toolStripSeparator_MenuItem_SMOpenProject.Name = "toolStripSeparator_MenuItem_SMOpenProject";
			System.Drawing.Size size13 = new System.Drawing.Size(185, 6);
			this.toolStripSeparator_MenuItem_SMOpenProject.Size = size13;
			this.MenuItem_CloseProject.Name = "MenuItem_CloseProject";
			System.Drawing.Size size14 = new System.Drawing.Size(188, 22);
			this.MenuItem_CloseProject.Size = size14;
			this.MenuItem_CloseProject.Text = "关闭项目(&C)";
			this.MenuItem_CloseProject.Click += new System.EventHandler(this.MenuItem_CloseProject_Click);
			this.toolStripSeparator_MenuItem_CloseProject.Name = "toolStripSeparator_MenuItem_CloseProject";
			System.Drawing.Size size15 = new System.Drawing.Size(185, 6);
			this.toolStripSeparator_MenuItem_CloseProject.Size = size15;
			this.MenuItem_Exit.Name = "MenuItem_Exit";
			System.Drawing.Size size16 = new System.Drawing.Size(188, 22);
			this.MenuItem_Exit.Size = size16;
			this.MenuItem_Exit.Text = "退出(&X)";
			this.MenuItem_Exit.Click += new System.EventHandler(this.MenuItem_Exit_Click);
			ToolStripItem[] toolStripItems4 = new ToolStripItem[]
			{
				this.MenuItem_UserManage,
				this.toolStripSeparator_UserManage,
				this.MenuItem_SecretManage,
				this.toolStripSeparator25,
				this.MenuItem_OperRecordManage
			};
			this.MenuItem_User.DropDownItems.AddRange(toolStripItems4);
			this.MenuItem_User.Name = "MenuItem_User";
			System.Drawing.Size size17 = new System.Drawing.Size(73, 20);
			this.MenuItem_User.Size = size17;
			this.MenuItem_User.Text = "用户(&U)";
			this.MenuItem_UserManage.Name = "MenuItem_UserManage";
			System.Drawing.Size size18 = new System.Drawing.Size(188, 22);
			this.MenuItem_UserManage.Size = size18;
			this.MenuItem_UserManage.Text = "用户管理(&A)";
			this.MenuItem_UserManage.Click += new System.EventHandler(this.MenuItem_UserManage_Click);
			this.toolStripSeparator_UserManage.Name = "toolStripSeparator_UserManage";
			System.Drawing.Size size19 = new System.Drawing.Size(185, 6);
			this.toolStripSeparator_UserManage.Size = size19;
			this.MenuItem_SecretManage.Name = "MenuItem_SecretManage";
			System.Drawing.Size size20 = new System.Drawing.Size(188, 22);
			this.MenuItem_SecretManage.Size = size20;
			this.MenuItem_SecretManage.Text = "密码修改(&S)";
			this.MenuItem_SecretManage.Click += new System.EventHandler(this.MenuItem_SecretManage_Click);
			this.toolStripSeparator25.Name = "toolStripSeparator25";
			System.Drawing.Size size21 = new System.Drawing.Size(185, 6);
			this.toolStripSeparator25.Size = size21;
			this.MenuItem_OperRecordManage.Name = "MenuItem_OperRecordManage";
			System.Drawing.Size size22 = new System.Drawing.Size(188, 22);
			this.MenuItem_OperRecordManage.Size = size22;
			this.MenuItem_OperRecordManage.Text = "操作记录浏览(&R)";
			this.MenuItem_OperRecordManage.Click += new System.EventHandler(this.MenuItem_OperRecordManage_Click);
			ToolStripItem[] toolStripItems5 = new ToolStripItem[]
			{
				this.MenuItem_ConnectorLibManage,
				this.toolStripSeparator13,
				this.MenuItem_InterfaceLibManage,
				this.toolStripSeparator5,
				this.MenuItem_CableLibManage,
				this.toolStripSeparator_IAndRT_PinReletion,
				this.MenuItem_IAndRT_PinReletion,
				this.toolStripSeparator_AdapterCableLibManage,
				this.MenuItem_AdapterCableLibManage
			};
			this.MenuItem_LibManage.DropDownItems.AddRange(toolStripItems5);
			this.MenuItem_LibManage.Name = "MenuItem_LibManage";
			System.Drawing.Size size23 = new System.Drawing.Size(88, 20);
			this.MenuItem_LibManage.Size = size23;
			this.MenuItem_LibManage.Text = "库管理(&L)";
			this.MenuItem_ConnectorLibManage.Name = "MenuItem_ConnectorLibManage";
			System.Drawing.Size size24 = new System.Drawing.Size(233, 22);
			this.MenuItem_ConnectorLibManage.Size = size24;
			this.MenuItem_ConnectorLibManage.Text = "连接器库管理(&C)";
			this.MenuItem_ConnectorLibManage.Click += new System.EventHandler(this.MenuItem_ConnectorLibManage_Click);
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			System.Drawing.Size size25 = new System.Drawing.Size(230, 6);
			this.toolStripSeparator13.Size = size25;
			this.MenuItem_InterfaceLibManage.Name = "MenuItem_InterfaceLibManage";
			System.Drawing.Size size26 = new System.Drawing.Size(233, 22);
			this.MenuItem_InterfaceLibManage.Size = size26;
			this.MenuItem_InterfaceLibManage.Text = "接口库管理(&I)";
			this.MenuItem_InterfaceLibManage.Click += new System.EventHandler(this.MenuItem_InterfaceLibManage_Click);
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			System.Drawing.Size size27 = new System.Drawing.Size(230, 6);
			this.toolStripSeparator5.Size = size27;
			this.MenuItem_CableLibManage.Name = "MenuItem_CableLibManage";
			System.Drawing.Size size28 = new System.Drawing.Size(233, 22);
			this.MenuItem_CableLibManage.Size = size28;
			this.MenuItem_CableLibManage.Text = "线束库管理(&W)";
			this.MenuItem_CableLibManage.Click += new System.EventHandler(this.MenuItem_CableLibManage_Click);
			this.toolStripSeparator_IAndRT_PinReletion.Name = "toolStripSeparator_IAndRT_PinReletion";
			System.Drawing.Size size29 = new System.Drawing.Size(230, 6);
			this.toolStripSeparator_IAndRT_PinReletion.Size = size29;
			this.MenuItem_IAndRT_PinReletion.Name = "MenuItem_IAndRT_PinReletion";
			System.Drawing.Size size30 = new System.Drawing.Size(233, 22);
			this.MenuItem_IAndRT_PinReletion.Size = size30;
			this.MenuItem_IAndRT_PinReletion.Text = "转接台针脚映射管理(&R)";
			this.MenuItem_IAndRT_PinReletion.Click += new System.EventHandler(this.MenuItem_IAndRT_PinReletion_Click);
			this.toolStripSeparator_AdapterCableLibManage.Name = "toolStripSeparator_AdapterCableLibManage";
			System.Drawing.Size size31 = new System.Drawing.Size(230, 6);
			this.toolStripSeparator_AdapterCableLibManage.Size = size31;
			this.MenuItem_AdapterCableLibManage.Name = "MenuItem_AdapterCableLibManage";
			System.Drawing.Size size32 = new System.Drawing.Size(233, 22);
			this.MenuItem_AdapterCableLibManage.Size = size32;
			this.MenuItem_AdapterCableLibManage.Text = "转接工装库管理(&A)";
			this.MenuItem_AdapterCableLibManage.Click += new System.EventHandler(this.MenuItem_AdapterCableLibManage_Click);
			ToolStripItem[] toolStripItems6 = new ToolStripItem[]
			{
				this.MenuItem_SelfStudy,
				this.toolStripSeparator_DTTEST,
				this.MenuItem_DTTEST,
				this.toolStripSeparator_DLTEST,
				this.MenuItem_DLTEST,
				this.toolStripSeparator_JYTEST,
				this.MenuItem_JYTEST,
				this.toolStripSeparator_DDJYTEST,
				this.MenuItem_DDJYTEST,
				this.toolStripSeparator_NYTEST,
				this.MenuItem_NYTEST,
				this.toolStripSeparator_SingleDevice_NYTEST,
				this.MenuItem_SingleDevice_NYTEST,
				this.toolStripSeparator_SingleDevice_DRTEST,
				this.MenuItem_SingleDevice_DRTEST,
				this.toolStripSeparator_UnDefinedInterfaceTest,
				this.MenuItem_UnDefinedInterfaceTest
			};
			this.MenuItem_Measure.DropDownItems.AddRange(toolStripItems6);
			this.MenuItem_Measure.Name = "MenuItem_Measure";
			System.Drawing.Size size33 = new System.Drawing.Size(73, 20);
			this.MenuItem_Measure.Size = size33;
			this.MenuItem_Measure.Text = "测试(&M)";
			this.MenuItem_SelfStudy.Name = "MenuItem_SelfStudy";
			System.Drawing.Size size34 = new System.Drawing.Size(211, 22);
			this.MenuItem_SelfStudy.Size = size34;
			this.MenuItem_SelfStudy.Text = "自学习(&S)";
			this.MenuItem_SelfStudy.Click += new System.EventHandler(this.MenuItem_SelfStudy_Click);
			this.toolStripSeparator_DTTEST.Name = "toolStripSeparator_DTTEST";
			System.Drawing.Size size35 = new System.Drawing.Size(208, 6);
			this.toolStripSeparator_DTTEST.Size = size35;
			this.MenuItem_DTTEST.Name = "MenuItem_DTTEST";
			System.Drawing.Size size36 = new System.Drawing.Size(211, 22);
			this.MenuItem_DTTEST.Size = size36;
			this.MenuItem_DTTEST.Text = "导通测试(&A)";
			this.MenuItem_DTTEST.Click += new System.EventHandler(this.btnStartDTTest_Click);
			this.toolStripSeparator_DLTEST.Name = "toolStripSeparator_DLTEST";
			System.Drawing.Size size37 = new System.Drawing.Size(208, 6);
			this.toolStripSeparator_DLTEST.Size = size37;
			this.MenuItem_DLTEST.Name = "MenuItem_DLTEST";
			System.Drawing.Size size38 = new System.Drawing.Size(211, 22);
			this.MenuItem_DLTEST.Size = size38;
			this.MenuItem_DLTEST.Text = "短路测试(&B)";
			this.MenuItem_DLTEST.Click += new System.EventHandler(this.btnStartDLTest_Click);
			this.toolStripSeparator_JYTEST.Name = "toolStripSeparator_JYTEST";
			System.Drawing.Size size39 = new System.Drawing.Size(208, 6);
			this.toolStripSeparator_JYTEST.Size = size39;
			this.MenuItem_JYTEST.Name = "MenuItem_JYTEST";
			System.Drawing.Size size40 = new System.Drawing.Size(211, 22);
			this.MenuItem_JYTEST.Size = size40;
			this.MenuItem_JYTEST.Text = "绝缘测试(&C)";
			this.MenuItem_JYTEST.Click += new System.EventHandler(this.btnStartJYTest_Click);
			this.toolStripSeparator_DDJYTEST.Name = "toolStripSeparator_DDJYTEST";
			System.Drawing.Size size41 = new System.Drawing.Size(208, 6);
			this.toolStripSeparator_DDJYTEST.Size = size41;
			this.MenuItem_DDJYTEST.Name = "MenuItem_DDJYTEST";
			System.Drawing.Size size42 = new System.Drawing.Size(211, 22);
			this.MenuItem_DDJYTEST.Size = size42;
			this.MenuItem_DDJYTEST.Text = "对地绝缘测试(&D)";
			this.MenuItem_DDJYTEST.Click += new System.EventHandler(this.btnStartDDJYTest_Click);
			this.toolStripSeparator_NYTEST.Name = "toolStripSeparator_NYTEST";
			System.Drawing.Size size43 = new System.Drawing.Size(208, 6);
			this.toolStripSeparator_NYTEST.Size = size43;
			this.MenuItem_NYTEST.Name = "MenuItem_NYTEST";
			System.Drawing.Size size44 = new System.Drawing.Size(211, 22);
			this.MenuItem_NYTEST.Size = size44;
			this.MenuItem_NYTEST.Text = "耐压测试(&E)";
			this.MenuItem_NYTEST.Click += new System.EventHandler(this.btnStartNYTest_Click);
			this.toolStripSeparator_SingleDevice_NYTEST.Name = "toolStripSeparator_SingleDevice_NYTEST";
			System.Drawing.Size size45 = new System.Drawing.Size(208, 6);
			this.toolStripSeparator_SingleDevice_NYTEST.Size = size45;
			this.MenuItem_SingleDevice_NYTEST.Name = "MenuItem_SingleDevice_NYTEST";
			System.Drawing.Size size46 = new System.Drawing.Size(211, 22);
			this.MenuItem_SingleDevice_NYTEST.Size = size46;
			this.MenuItem_SingleDevice_NYTEST.Text = "单设备-耐压测试(&V)";
			this.MenuItem_SingleDevice_NYTEST.Click += new System.EventHandler(this.MenuItem_SingleDevice_NYTEST_Click);
			this.toolStripSeparator_SingleDevice_DRTEST.Name = "toolStripSeparator_SingleDevice_DRTEST";
			System.Drawing.Size size47 = new System.Drawing.Size(208, 6);
			this.toolStripSeparator_SingleDevice_DRTEST.Size = size47;
			this.MenuItem_SingleDevice_DRTEST.Name = "MenuItem_SingleDevice_DRTEST";
			System.Drawing.Size size48 = new System.Drawing.Size(211, 22);
			this.MenuItem_SingleDevice_DRTEST.Size = size48;
			this.MenuItem_SingleDevice_DRTEST.Text = "单设备-电容测试(&P)";
			this.MenuItem_SingleDevice_DRTEST.Click += new System.EventHandler(this.MenuItem_SingleDevice_DRTEST_Click);
			this.toolStripSeparator_UnDefinedInterfaceTest.Name = "toolStripSeparator_UnDefinedInterfaceTest";
			System.Drawing.Size size49 = new System.Drawing.Size(208, 6);
			this.toolStripSeparator_UnDefinedInterfaceTest.Size = size49;
			this.toolStripSeparator_UnDefinedInterfaceTest.Visible = false;
			this.MenuItem_UnDefinedInterfaceTest.Name = "MenuItem_UnDefinedInterfaceTest";
			System.Drawing.Size size50 = new System.Drawing.Size(211, 22);
			this.MenuItem_UnDefinedInterfaceTest.Size = size50;
			this.MenuItem_UnDefinedInterfaceTest.Text = "未定义接口测试(&N)";
			this.MenuItem_UnDefinedInterfaceTest.Visible = false;
			this.MenuItem_UnDefinedInterfaceTest.Click += new System.EventHandler(this.MenuItem_UnDefinedInterfaceTest_Click);
			ToolStripItem[] toolStripItems7 = new ToolStripItem[]
			{
				this.MenuItem_CurrentDLTestData,
				this.toolStripSeparator_CurrentDLTestData,
				this.MenuItem_CurrentDDJYTestData,
				this.toolStripSeparator_CurrentDDJYTestData,
				this.MenuItem_HistoryDataBrowse
			};
			this.MenuItem_TestData.DropDownItems.AddRange(toolStripItems7);
			this.MenuItem_TestData.Name = "MenuItem_TestData";
			System.Drawing.Size size51 = new System.Drawing.Size(73, 20);
			this.MenuItem_TestData.Size = size51;
			this.MenuItem_TestData.Text = "数据(&D)";
			this.MenuItem_CurrentDLTestData.Name = "MenuItem_CurrentDLTestData";
			System.Drawing.Size size52 = new System.Drawing.Size(256, 22);
			this.MenuItem_CurrentDLTestData.Size = size52;
			this.MenuItem_CurrentDLTestData.Text = "当前测试数据-短路(&S)";
			this.MenuItem_CurrentDLTestData.Click += new System.EventHandler(this.MenuItem_CurrentDLTestData_Click);
			this.toolStripSeparator_CurrentDLTestData.Name = "toolStripSeparator_CurrentDLTestData";
			System.Drawing.Size size53 = new System.Drawing.Size(253, 6);
			this.toolStripSeparator_CurrentDLTestData.Size = size53;
			this.MenuItem_CurrentDDJYTestData.Name = "MenuItem_CurrentDDJYTestData";
			System.Drawing.Size size54 = new System.Drawing.Size(256, 22);
			this.MenuItem_CurrentDDJYTestData.Size = size54;
			this.MenuItem_CurrentDDJYTestData.Text = "当前测试数据-对地绝缘(&G)";
			this.MenuItem_CurrentDDJYTestData.Click += new System.EventHandler(this.MenuItem_CurrentDDJYTestData_Click);
			this.toolStripSeparator_CurrentDDJYTestData.Name = "toolStripSeparator_CurrentDDJYTestData";
			System.Drawing.Size size55 = new System.Drawing.Size(253, 6);
			this.toolStripSeparator_CurrentDDJYTestData.Size = size55;
			this.MenuItem_HistoryDataBrowse.Name = "MenuItem_HistoryDataBrowse";
			System.Drawing.Size size56 = new System.Drawing.Size(256, 22);
			this.MenuItem_HistoryDataBrowse.Size = size56;
			this.MenuItem_HistoryDataBrowse.Text = "历史测试数据浏览(&B)";
			this.MenuItem_HistoryDataBrowse.Click += new System.EventHandler(this.MenuItem_HistoryDataBrowse_Click);
			ToolStripItem[] toolStripItems8 = new ToolStripItem[]
			{
				this.MenuItem_ConnEquipment,
				this.toolStripSeparator16,
				this.MenuItem_DisConnEquipment,
				this.toolStripSeparator_ErrorQuery,
				this.MenuItem_ErrorQuery,
				this.toolStripSeparator_SBTS,
				this.MenuItem_SBTS,
				this.toolStripSeparator_ComponentMeasure,
				this.MenuItem_ComponentMeasure,
				this.toolStripSeparator_VoltMeasure,
				this.MenuItem_VoltMeasure
			};
			this.MenuItem_Tool.DropDownItems.AddRange(toolStripItems8);
			this.MenuItem_Tool.Name = "MenuItem_Tool";
			System.Drawing.Size size57 = new System.Drawing.Size(73, 20);
			this.MenuItem_Tool.Size = size57;
			this.MenuItem_Tool.Text = "工具(&T)";
			this.MenuItem_ConnEquipment.Name = "MenuItem_ConnEquipment";
			System.Drawing.Size size58 = new System.Drawing.Size(188, 22);
			this.MenuItem_ConnEquipment.Size = size58;
			this.MenuItem_ConnEquipment.Text = "连接设备(&E)";
			this.MenuItem_ConnEquipment.Click += new System.EventHandler(this.MenuItem_ConnEquipment_Click);
			this.toolStripSeparator16.Name = "toolStripSeparator16";
			System.Drawing.Size size59 = new System.Drawing.Size(185, 6);
			this.toolStripSeparator16.Size = size59;
			this.MenuItem_DisConnEquipment.Name = "MenuItem_DisConnEquipment";
			System.Drawing.Size size60 = new System.Drawing.Size(188, 22);
			this.MenuItem_DisConnEquipment.Size = size60;
			this.MenuItem_DisConnEquipment.Text = "断开连接(O)";
			this.MenuItem_DisConnEquipment.Click += new System.EventHandler(this.MenuItem_DisConnEquipment_Click);
			this.toolStripSeparator_ErrorQuery.Name = "toolStripSeparator_ErrorQuery";
			System.Drawing.Size size61 = new System.Drawing.Size(185, 6);
			this.toolStripSeparator_ErrorQuery.Size = size61;
			this.MenuItem_ErrorQuery.Name = "MenuItem_ErrorQuery";
			System.Drawing.Size size62 = new System.Drawing.Size(188, 22);
			this.MenuItem_ErrorQuery.Size = size62;
			this.MenuItem_ErrorQuery.Text = "设备故障查询(&Q)";
			this.MenuItem_ErrorQuery.Click += new System.EventHandler(this.MenuItem_ErrorQuery_Click);
			this.toolStripSeparator_SBTS.Name = "toolStripSeparator_SBTS";
			System.Drawing.Size size63 = new System.Drawing.Size(185, 6);
			this.toolStripSeparator_SBTS.Size = size63;
			ToolStripItem[] toolStripItems9 = new ToolStripItem[]
			{
				this.MenuItem_SBJZ,
				this.toolStripSeparator12,
				this.MenuItem_StartSelfTest,
				this.toolStripSeparator2,
				this.MenuItem_DeviceDebugging
			};
			this.MenuItem_SBTS.DropDownItems.AddRange(toolStripItems9);
			this.MenuItem_SBTS.Name = "MenuItem_SBTS";
			System.Drawing.Size size64 = new System.Drawing.Size(188, 22);
			this.MenuItem_SBTS.Size = size64;
			this.MenuItem_SBTS.Text = "设备调试工具(&T)";
			this.MenuItem_SBJZ.Name = "MenuItem_SBJZ";
			System.Drawing.Size size65 = new System.Drawing.Size(188, 22);
			this.MenuItem_SBJZ.Size = size65;
			this.MenuItem_SBJZ.Text = "设备校准(&C)";
			this.MenuItem_SBJZ.Click += new System.EventHandler(this.MenuItem_SBJZ_Click);
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			System.Drawing.Size size66 = new System.Drawing.Size(185, 6);
			this.toolStripSeparator12.Size = size66;
			this.MenuItem_StartSelfTest.Name = "MenuItem_StartSelfTest";
			System.Drawing.Size size67 = new System.Drawing.Size(188, 22);
			this.MenuItem_StartSelfTest.Size = size67;
			this.MenuItem_StartSelfTest.Text = "设备自检(&S)";
			this.MenuItem_StartSelfTest.Click += new System.EventHandler(this.MenuItem_StartSelfTest_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			System.Drawing.Size size68 = new System.Drawing.Size(185, 6);
			this.toolStripSeparator2.Size = size68;
			this.MenuItem_DeviceDebugging.Name = "MenuItem_DeviceDebugging";
			System.Drawing.Size size69 = new System.Drawing.Size(188, 22);
			this.MenuItem_DeviceDebugging.Size = size69;
			this.MenuItem_DeviceDebugging.Text = "设备调试助手(&D)";
			this.MenuItem_DeviceDebugging.Click += new System.EventHandler(this.MenuItem_DeviceDebugging_Click);
			this.toolStripSeparator_ComponentMeasure.Name = "toolStripSeparator_ComponentMeasure";
			System.Drawing.Size size70 = new System.Drawing.Size(185, 6);
			this.toolStripSeparator_ComponentMeasure.Size = size70;
			this.toolStripSeparator_ComponentMeasure.Visible = false;
			this.MenuItem_ComponentMeasure.Name = "MenuItem_ComponentMeasure";
			System.Drawing.Size size71 = new System.Drawing.Size(188, 22);
			this.MenuItem_ComponentMeasure.Size = size71;
			this.MenuItem_ComponentMeasure.Text = "元器件测量(&C)";
			this.MenuItem_ComponentMeasure.Visible = false;
			this.MenuItem_ComponentMeasure.Click += new System.EventHandler(this.MenuItem_ComponentMeasure_Click);
			this.toolStripSeparator_VoltMeasure.Name = "toolStripSeparator_VoltMeasure";
			System.Drawing.Size size72 = new System.Drawing.Size(185, 6);
			this.toolStripSeparator_VoltMeasure.Size = size72;
			this.toolStripSeparator_VoltMeasure.Visible = false;
			this.MenuItem_VoltMeasure.Name = "MenuItem_VoltMeasure";
			System.Drawing.Size size73 = new System.Drawing.Size(188, 22);
			this.MenuItem_VoltMeasure.Size = size73;
			this.MenuItem_VoltMeasure.Text = "电压测量(&V)";
			this.MenuItem_VoltMeasure.Visible = false;
			this.MenuItem_VoltMeasure.Click += new System.EventHandler(this.MenuItem_VoltMeasure_Click);
			ToolStripItem[] toolStripItems10 = new ToolStripItem[]
			{
				this.MenuItem_EquipmentAutoConn,
				this.toolStripSeparator_AuxiliaryPowerSupply,
				this.MenuItem_AuxiliaryPowerSupply,
				this.toolStripSeparator_ResistanceCompensation,
				this.MenuItem_ResistanceCompensation,
				this.toolStripSeparator7,
				this.MenuItem_RCM,
				this.toolStripSeparator_EquipmentInfoManage,
				this.MenuItem_EquipmentInfoManage,
				this.toolStripSeparator_SystemParaSet,
				this.MenuItem_SystemParaSet,
				this.toolStripSeparator_SwitchAccount,
				this.MenuItem_SwitchAccount
			};
			this.MenuItem_Set.DropDownItems.AddRange(toolStripItems10);
			this.MenuItem_Set.Name = "MenuItem_Set";
			System.Drawing.Size size74 = new System.Drawing.Size(73, 20);
			this.MenuItem_Set.Size = size74;
			this.MenuItem_Set.Text = "设置(&S)";
			this.MenuItem_EquipmentAutoConn.Checked = true;
			this.MenuItem_EquipmentAutoConn.CheckState = CheckState.Checked;
			this.MenuItem_EquipmentAutoConn.Name = "MenuItem_EquipmentAutoConn";
			System.Drawing.Size size75 = new System.Drawing.Size(188, 22);
			this.MenuItem_EquipmentAutoConn.Size = size75;
			this.MenuItem_EquipmentAutoConn.Text = "自动连接设备(&C)";
			this.MenuItem_EquipmentAutoConn.Click += new System.EventHandler(this.MenuItem_EquipmentAutoConn_Click);
			this.toolStripSeparator_AuxiliaryPowerSupply.Name = "toolStripSeparator_AuxiliaryPowerSupply";
			System.Drawing.Size size76 = new System.Drawing.Size(185, 6);
			this.toolStripSeparator_AuxiliaryPowerSupply.Size = size76;
			this.MenuItem_AuxiliaryPowerSupply.Name = "MenuItem_AuxiliaryPowerSupply";
			System.Drawing.Size size77 = new System.Drawing.Size(188, 22);
			this.MenuItem_AuxiliaryPowerSupply.Size = size77;
			this.MenuItem_AuxiliaryPowerSupply.Text = "启用辅助供电(&A)";
			this.MenuItem_AuxiliaryPowerSupply.Click += new System.EventHandler(this.MenuItem_AuxiliaryPowerSupply_Click);
			this.toolStripSeparator_ResistanceCompensation.Name = "toolStripSeparator_ResistanceCompensation";
			System.Drawing.Size size78 = new System.Drawing.Size(185, 6);
			this.toolStripSeparator_ResistanceCompensation.Size = size78;
			this.MenuItem_ResistanceCompensation.Checked = true;
			this.MenuItem_ResistanceCompensation.CheckState = CheckState.Checked;
			this.MenuItem_ResistanceCompensation.Name = "MenuItem_ResistanceCompensation";
			System.Drawing.Size size79 = new System.Drawing.Size(188, 22);
			this.MenuItem_ResistanceCompensation.Size = size79;
			this.MenuItem_ResistanceCompensation.Text = "启用电阻补偿(&O)";
			this.MenuItem_ResistanceCompensation.Click += new System.EventHandler(this.MenuItem_ResistanceCompensation_Click);
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			System.Drawing.Size size80 = new System.Drawing.Size(185, 6);
			this.toolStripSeparator7.Size = size80;
			this.MenuItem_RCM.Name = "MenuItem_RCM";
			System.Drawing.Size size81 = new System.Drawing.Size(188, 22);
			this.MenuItem_RCM.Size = size81;
			this.MenuItem_RCM.Text = "补偿电阻管理(&R)";
			this.MenuItem_RCM.Click += new System.EventHandler(this.MenuItem_RCM_Click);
			this.toolStripSeparator_EquipmentInfoManage.Name = "toolStripSeparator_EquipmentInfoManage";
			System.Drawing.Size size82 = new System.Drawing.Size(185, 6);
			this.toolStripSeparator_EquipmentInfoManage.Size = size82;
			this.MenuItem_EquipmentInfoManage.Name = "MenuItem_EquipmentInfoManage";
			System.Drawing.Size size83 = new System.Drawing.Size(188, 22);
			this.MenuItem_EquipmentInfoManage.Size = size83;
			this.MenuItem_EquipmentInfoManage.Text = "设备信息管理(&E)";
			this.MenuItem_EquipmentInfoManage.Click += new System.EventHandler(this.MenuItem_EquipmentInfoManage_Click);
			this.toolStripSeparator_SystemParaSet.Name = "toolStripSeparator_SystemParaSet";
			System.Drawing.Size size84 = new System.Drawing.Size(185, 6);
			this.toolStripSeparator_SystemParaSet.Size = size84;
			ToolStripItem[] toolStripItems11 = new ToolStripItem[]
			{
				this.MenuItem_EnvironmentParaSet,
				this.toolStripSeparator_DefaultTestParaSet,
				this.MenuItem_DefaultTestParaSet,
				this.toolStripSeparator6,
				this.MenuItem_ReportSavePathSet,
				this.toolStripSeparator11,
				this.MenuItem_ReportFormatSet
			};
			this.MenuItem_SystemParaSet.DropDownItems.AddRange(toolStripItems11);
			this.MenuItem_SystemParaSet.Name = "MenuItem_SystemParaSet";
			System.Drawing.Size size85 = new System.Drawing.Size(188, 22);
			this.MenuItem_SystemParaSet.Size = size85;
			this.MenuItem_SystemParaSet.Text = "系统参数设置(&P)";
			this.MenuItem_EnvironmentParaSet.Name = "MenuItem_EnvironmentParaSet";
			System.Drawing.Size size86 = new System.Drawing.Size(218, 22);
			this.MenuItem_EnvironmentParaSet.Size = size86;
			this.MenuItem_EnvironmentParaSet.Text = "试验环境参数设置(&E)";
			this.MenuItem_EnvironmentParaSet.Click += new System.EventHandler(this.MenuItem_EnvironmentParaSet_Click);
			this.toolStripSeparator_DefaultTestParaSet.Name = "toolStripSeparator_DefaultTestParaSet";
			System.Drawing.Size size87 = new System.Drawing.Size(215, 6);
			this.toolStripSeparator_DefaultTestParaSet.Size = size87;
			this.MenuItem_DefaultTestParaSet.Name = "MenuItem_DefaultTestParaSet";
			System.Drawing.Size size88 = new System.Drawing.Size(218, 22);
			this.MenuItem_DefaultTestParaSet.Size = size88;
			this.MenuItem_DefaultTestParaSet.Text = "默认试验参数设置(&M)";
			this.MenuItem_DefaultTestParaSet.Click += new System.EventHandler(this.MenuItem_DefaultTestParaSet_Click);
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			System.Drawing.Size size89 = new System.Drawing.Size(215, 6);
			this.toolStripSeparator6.Size = size89;
			this.MenuItem_ReportSavePathSet.Name = "MenuItem_ReportSavePathSet";
			System.Drawing.Size size90 = new System.Drawing.Size(218, 22);
			this.MenuItem_ReportSavePathSet.Size = size90;
			this.MenuItem_ReportSavePathSet.Text = "报表保存路径设置(&D)";
			this.MenuItem_ReportSavePathSet.Click += new System.EventHandler(this.MenuItem_ReportSavePathSet_Click);
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			System.Drawing.Size size91 = new System.Drawing.Size(215, 6);
			this.toolStripSeparator11.Size = size91;
			this.MenuItem_ReportFormatSet.Name = "MenuItem_ReportFormatSet";
			System.Drawing.Size size92 = new System.Drawing.Size(218, 22);
			this.MenuItem_ReportFormatSet.Size = size92;
			this.MenuItem_ReportFormatSet.Text = "报表默认格式设置(&R)";
			this.MenuItem_ReportFormatSet.Click += new System.EventHandler(this.MenuItem_ReportFormatSet_Click);
			this.toolStripSeparator_SwitchAccount.Name = "toolStripSeparator_SwitchAccount";
			System.Drawing.Size size93 = new System.Drawing.Size(185, 6);
			this.toolStripSeparator_SwitchAccount.Size = size93;
			this.MenuItem_SwitchAccount.Name = "MenuItem_SwitchAccount";
			System.Drawing.Size size94 = new System.Drawing.Size(188, 22);
			this.MenuItem_SwitchAccount.Size = size94;
			this.MenuItem_SwitchAccount.Text = "切换账号(&Q)";
			this.MenuItem_SwitchAccount.Click += new System.EventHandler(this.MenuItem_SwitchAccount_Click);
			ToolStripItem[] toolStripItems12 = new ToolStripItem[]
			{
				this.MenuItem_About,
				this.toolStripSeparator10,
				this.MenuItem_HelpView,
				this.toolStripSeparator_EmulationMode,
				this.MenuItem_EmulationMode
			};
			this.MenuItem_Help.DropDownItems.AddRange(toolStripItems12);
			this.MenuItem_Help.Name = "MenuItem_Help";
			System.Drawing.Size size95 = new System.Drawing.Size(73, 20);
			this.MenuItem_Help.Size = size95;
			this.MenuItem_Help.Text = "帮助(H)";
			this.MenuItem_About.Name = "MenuItem_About";
			System.Drawing.Size size96 = new System.Drawing.Size(158, 22);
			this.MenuItem_About.Size = size96;
			this.MenuItem_About.Text = "关于软件(&A)";
			this.MenuItem_About.Click += new System.EventHandler(this.MenuItem_About_Click);
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			System.Drawing.Size size97 = new System.Drawing.Size(155, 6);
			this.toolStripSeparator10.Size = size97;
			this.MenuItem_HelpView.Name = "MenuItem_HelpView";
			System.Drawing.Size size98 = new System.Drawing.Size(158, 22);
			this.MenuItem_HelpView.Size = size98;
			this.MenuItem_HelpView.Text = "查看帮助(&V)";
			this.MenuItem_HelpView.Click += new System.EventHandler(this.MenuItem_HelpView_Click);
			this.toolStripSeparator_EmulationMode.Name = "toolStripSeparator_EmulationMode";
			System.Drawing.Size size99 = new System.Drawing.Size(155, 6);
			this.toolStripSeparator_EmulationMode.Size = size99;
			this.toolStripSeparator_EmulationMode.Visible = false;
			this.MenuItem_EmulationMode.Name = "MenuItem_EmulationMode";
			System.Drawing.Size size100 = new System.Drawing.Size(158, 22);
			this.MenuItem_EmulationMode.Size = size100;
			this.MenuItem_EmulationMode.Text = "模拟运行(&E)";
			this.MenuItem_EmulationMode.Visible = false;
			this.MenuItem_EmulationMode.Click += new System.EventHandler(this.MenuItem_EmulationMode_Click);
			this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			ToolStripItem[] toolStripItems13 = new ToolStripItem[]
			{
				this.toolStripButton_InterfaceLibManage,
				this.toolStripSeparator_InterfaceLibManage,
				this.toolStripButton_CableLibManage,
				this.toolStripSeparator_CableLibManage,
				this.toolStripButton_CreateProject,
				this.toolStripSeparator_CreateProject,
				this.toolStripButton_OpenProject,
				this.toolStripSeparator_OpenProject,
				this.toolStripButton_HistoryDataView,
				this.toolStripSeparator_HistoryDataView,
				this.toolStripButton_ConnEquipment,
				this.toolStripSeparator_ConnEquipment,
				this.toolStripButton_SelfStudy,
				this.toolStripSeparator_SelfStudy,
				this.toolStripButton_ProbeMeasure,
				this.toolStripSeparator_ProbeMeasure
			};
			this.toolStrip1.Items.AddRange(toolStripItems13);
			System.Drawing.Point location3 = new System.Drawing.Point(0, 24);
			this.toolStrip1.Location = location3;
			this.toolStrip1.Name = "toolStrip1";
			System.Drawing.Size size101 = new System.Drawing.Size(1074, 70);
			this.toolStrip1.Size = size101;
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStripButton_InterfaceLibManage.Image = (System.Drawing.Image)resources.GetObject("toolStripButton_InterfaceLibManage.Image");
			this.toolStripButton_InterfaceLibManage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.toolStripButton_InterfaceLibManage.ImageScaling = ToolStripItemImageScaling.None;
			System.Drawing.Color magenta = System.Drawing.Color.Magenta;
			this.toolStripButton_InterfaceLibManage.ImageTransparentColor = magenta;
			this.toolStripButton_InterfaceLibManage.Name = "toolStripButton_InterfaceLibManage";
			System.Drawing.Size size102 = new System.Drawing.Size(56, 67);
			this.toolStripButton_InterfaceLibManage.Size = size102;
			this.toolStripButton_InterfaceLibManage.Text = "接口库";
			this.toolStripButton_InterfaceLibManage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_InterfaceLibManage.TextImageRelation = TextImageRelation.ImageAboveText;
			this.toolStripButton_InterfaceLibManage.ToolTipText = "接口库管理";
			this.toolStripButton_InterfaceLibManage.Click += new System.EventHandler(this.MenuItem_InterfaceLibManage_Click);
			this.toolStripSeparator_InterfaceLibManage.Name = "toolStripSeparator_InterfaceLibManage";
			System.Drawing.Size size103 = new System.Drawing.Size(6, 70);
			this.toolStripSeparator_InterfaceLibManage.Size = size103;
			this.toolStripButton_CableLibManage.Image = (System.Drawing.Image)resources.GetObject("toolStripButton_CableLibManage.Image");
			this.toolStripButton_CableLibManage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.toolStripButton_CableLibManage.ImageScaling = ToolStripItemImageScaling.None;
			System.Drawing.Color magenta2 = System.Drawing.Color.Magenta;
			this.toolStripButton_CableLibManage.ImageTransparentColor = magenta2;
			this.toolStripButton_CableLibManage.Name = "toolStripButton_CableLibManage";
			System.Drawing.Size size104 = new System.Drawing.Size(56, 67);
			this.toolStripButton_CableLibManage.Size = size104;
			this.toolStripButton_CableLibManage.Text = "线束库";
			this.toolStripButton_CableLibManage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_CableLibManage.TextImageRelation = TextImageRelation.ImageAboveText;
			this.toolStripButton_CableLibManage.ToolTipText = "线束库管理";
			this.toolStripButton_CableLibManage.Click += new System.EventHandler(this.MenuItem_CableLibManage_Click);
			this.toolStripSeparator_CableLibManage.Name = "toolStripSeparator_CableLibManage";
			System.Drawing.Size size105 = new System.Drawing.Size(6, 70);
			this.toolStripSeparator_CableLibManage.Size = size105;
			this.toolStripButton_CreateProject.Image = (System.Drawing.Image)resources.GetObject("toolStripButton_CreateProject.Image");
			this.toolStripButton_CreateProject.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.toolStripButton_CreateProject.ImageScaling = ToolStripItemImageScaling.None;
			System.Drawing.Color magenta3 = System.Drawing.Color.Magenta;
			this.toolStripButton_CreateProject.ImageTransparentColor = magenta3;
			this.toolStripButton_CreateProject.Name = "toolStripButton_CreateProject";
			System.Drawing.Size size106 = new System.Drawing.Size(71, 67);
			this.toolStripButton_CreateProject.Size = size106;
			this.toolStripButton_CreateProject.Text = "新建项目";
			this.toolStripButton_CreateProject.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_CreateProject.TextImageRelation = TextImageRelation.ImageAboveText;
			this.toolStripButton_CreateProject.Click += new System.EventHandler(this.MenuItem_CreateProject_Click);
			this.toolStripSeparator_CreateProject.Name = "toolStripSeparator_CreateProject";
			System.Drawing.Size size107 = new System.Drawing.Size(6, 70);
			this.toolStripSeparator_CreateProject.Size = size107;
			this.toolStripButton_OpenProject.Image = (System.Drawing.Image)resources.GetObject("toolStripButton_OpenProject.Image");
			this.toolStripButton_OpenProject.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.toolStripButton_OpenProject.ImageScaling = ToolStripItemImageScaling.None;
			System.Drawing.Color magenta4 = System.Drawing.Color.Magenta;
			this.toolStripButton_OpenProject.ImageTransparentColor = magenta4;
			this.toolStripButton_OpenProject.Name = "toolStripButton_OpenProject";
			System.Drawing.Size size108 = new System.Drawing.Size(71, 67);
			this.toolStripButton_OpenProject.Size = size108;
			this.toolStripButton_OpenProject.Text = "打开项目";
			this.toolStripButton_OpenProject.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_OpenProject.TextImageRelation = TextImageRelation.ImageAboveText;
			this.toolStripButton_OpenProject.Click += new System.EventHandler(this.MenuItem_OpenProject_Click);
			this.toolStripSeparator_OpenProject.Name = "toolStripSeparator_OpenProject";
			System.Drawing.Size size109 = new System.Drawing.Size(6, 70);
			this.toolStripSeparator_OpenProject.Size = size109;
			this.toolStripButton_HistoryDataView.Image = (System.Drawing.Image)resources.GetObject("toolStripButton_HistoryDataView.Image");
			this.toolStripButton_HistoryDataView.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.toolStripButton_HistoryDataView.ImageScaling = ToolStripItemImageScaling.None;
			System.Drawing.Color magenta5 = System.Drawing.Color.Magenta;
			this.toolStripButton_HistoryDataView.ImageTransparentColor = magenta5;
			this.toolStripButton_HistoryDataView.Name = "toolStripButton_HistoryDataView";
			System.Drawing.Size size110 = new System.Drawing.Size(71, 67);
			this.toolStripButton_HistoryDataView.Size = size110;
			this.toolStripButton_HistoryDataView.Text = "历史数据";
			this.toolStripButton_HistoryDataView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_HistoryDataView.TextImageRelation = TextImageRelation.ImageAboveText;
			this.toolStripButton_HistoryDataView.Click += new System.EventHandler(this.toolStripButton_HistoryDataView_Click);
			this.toolStripSeparator_HistoryDataView.Name = "toolStripSeparator_HistoryDataView";
			System.Drawing.Size size111 = new System.Drawing.Size(6, 70);
			this.toolStripSeparator_HistoryDataView.Size = size111;
			this.toolStripButton_ConnEquipment.Image = (System.Drawing.Image)resources.GetObject("toolStripButton_ConnEquipment.Image");
			this.toolStripButton_ConnEquipment.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.toolStripButton_ConnEquipment.ImageScaling = ToolStripItemImageScaling.None;
			System.Drawing.Color magenta6 = System.Drawing.Color.Magenta;
			this.toolStripButton_ConnEquipment.ImageTransparentColor = magenta6;
			this.toolStripButton_ConnEquipment.Name = "toolStripButton_ConnEquipment";
			System.Drawing.Size size112 = new System.Drawing.Size(71, 67);
			this.toolStripButton_ConnEquipment.Size = size112;
			this.toolStripButton_ConnEquipment.Text = "连接设备";
			this.toolStripButton_ConnEquipment.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_ConnEquipment.TextImageRelation = TextImageRelation.ImageAboveText;
			this.toolStripButton_ConnEquipment.Click += new System.EventHandler(this.MenuItem_ConnEquipment_Click);
			this.toolStripSeparator_ConnEquipment.Name = "toolStripSeparator_ConnEquipment";
			System.Drawing.Size size113 = new System.Drawing.Size(6, 70);
			this.toolStripSeparator_ConnEquipment.Size = size113;
			this.toolStripButton_SelfStudy.Image = (System.Drawing.Image)resources.GetObject("toolStripButton_SelfStudy.Image");
			this.toolStripButton_SelfStudy.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.toolStripButton_SelfStudy.ImageScaling = ToolStripItemImageScaling.None;
			System.Drawing.Color magenta7 = System.Drawing.Color.Magenta;
			this.toolStripButton_SelfStudy.ImageTransparentColor = magenta7;
			this.toolStripButton_SelfStudy.Name = "toolStripButton_SelfStudy";
			System.Drawing.Size size114 = new System.Drawing.Size(56, 67);
			this.toolStripButton_SelfStudy.Size = size114;
			this.toolStripButton_SelfStudy.Text = "自学习";
			this.toolStripButton_SelfStudy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_SelfStudy.TextImageRelation = TextImageRelation.ImageAboveText;
			this.toolStripButton_SelfStudy.Click += new System.EventHandler(this.MenuItem_SelfStudy_Click);
			this.toolStripSeparator_SelfStudy.Name = "toolStripSeparator_SelfStudy";
			System.Drawing.Size size115 = new System.Drawing.Size(6, 70);
			this.toolStripSeparator_SelfStudy.Size = size115;
			this.toolStripButton_ProbeMeasure.Image = (System.Drawing.Image)resources.GetObject("toolStripButton_ProbeMeasure.Image");
			this.toolStripButton_ProbeMeasure.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.toolStripButton_ProbeMeasure.ImageScaling = ToolStripItemImageScaling.None;
			System.Drawing.Color magenta8 = System.Drawing.Color.Magenta;
			this.toolStripButton_ProbeMeasure.ImageTransparentColor = magenta8;
			this.toolStripButton_ProbeMeasure.Name = "toolStripButton_ProbeMeasure";
			System.Drawing.Size size116 = new System.Drawing.Size(57, 67);
			this.toolStripButton_ProbeMeasure.Size = size116;
			this.toolStripButton_ProbeMeasure.Text = " 探针 ";
			this.toolStripButton_ProbeMeasure.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_ProbeMeasure.TextImageRelation = TextImageRelation.ImageAboveText;
			this.toolStripButton_ProbeMeasure.ToolTipText = "探针";
			this.toolStripButton_ProbeMeasure.Click += new System.EventHandler(this.toolStripButton_ProbeMeasure_Click);
			this.toolStripSeparator_ProbeMeasure.Name = "toolStripSeparator_ProbeMeasure";
			System.Drawing.Size size117 = new System.Drawing.Size(6, 70);
			this.toolStripSeparator_ProbeMeasure.Size = size117;
			System.Drawing.Color activeCaption = System.Drawing.SystemColors.ActiveCaption;
			this.panel_work.BackColor = activeCaption;
			this.panel_work.Controls.Add(this.panel_projectTest);
			this.panel_work.Controls.Add(this.panel1);
			this.panel_work.Controls.Add(this.panel_note);
			this.panel_work.Controls.Add(this.pictureBox1);
			this.panel_work.Dock = DockStyle.Fill;
			System.Drawing.Point location4 = new System.Drawing.Point(0, 94);
			this.panel_work.Location = location4;
			Padding margin = new Padding(2);
			this.panel_work.Margin = margin;
			this.panel_work.Name = "panel_work";
			System.Drawing.Size size118 = new System.Drawing.Size(1074, 545);
			this.panel_work.Size = size118;
			this.panel_work.TabIndex = 2;
			this.panel_projectTest.Controls.Add(this.flowLayoutPanel2);
			this.panel_projectTest.Controls.Add(this.flowLayoutPanel1);
			this.panel_projectTest.Controls.Add(this.panel_progress);
			this.panel_projectTest.Controls.Add(this.panel_tsxx);
			this.panel_projectTest.Controls.Add(this.panel_testData);
			this.panel_projectTest.Controls.Add(this.panel_testNote);
			this.panel_projectTest.Controls.Add(this.panel_projectInfo);
			this.panel_projectTest.Dock = DockStyle.Fill;
			System.Drawing.Point location5 = new System.Drawing.Point(0, 0);
			this.panel_projectTest.Location = location5;
			Padding margin2 = new Padding(2);
			this.panel_projectTest.Margin = margin2;
			this.panel_projectTest.Name = "panel_projectTest";
			System.Drawing.Size size119 = new System.Drawing.Size(1074, 545);
			this.panel_projectTest.Size = size119;
			this.panel_projectTest.TabIndex = 7;
			this.panel_projectTest.VisibleChanged += new System.EventHandler(this.panel_projectTest_VisibleChanged);
			this.flowLayoutPanel2.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.flowLayoutPanel2.AutoSize = true;
			this.flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel2.Controls.Add(this.btnCreateReport);
			this.flowLayoutPanel2.Controls.Add(this.btnPrintReport);
			this.flowLayoutPanel2.Controls.Add(this.btnSaveTestData);
			this.flowLayoutPanel2.Controls.Add(this.btnCloseProject);
			System.Drawing.Point location6 = new System.Drawing.Point(731, 6);
			this.flowLayoutPanel2.Location = location6;
			Padding margin3 = new Padding(2);
			this.flowLayoutPanel2.Margin = margin3;
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			System.Drawing.Size size120 = new System.Drawing.Size(327, 32);
			this.flowLayoutPanel2.Size = size120;
			this.flowLayoutPanel2.TabIndex = 13;
			this.btnCreateReport.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			System.Drawing.Color buttonFace2 = System.Drawing.SystemColors.ButtonFace;
			this.btnCreateReport.BackColor = buttonFace2;
			this.btnCreateReport.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(2, 2);
			this.btnCreateReport.Location = location7;
			Padding margin4 = new Padding(2);
			this.btnCreateReport.Margin = margin4;
			this.btnCreateReport.Name = "btnCreateReport";
			System.Drawing.Size size121 = new System.Drawing.Size(82, 28);
			this.btnCreateReport.Size = size121;
			this.btnCreateReport.TabIndex = 6;
			this.btnCreateReport.Text = "生成报表";
			this.btnCreateReport.UseVisualStyleBackColor = false;
			this.btnCreateReport.Click += new System.EventHandler(this.btnCreateReport_Click);
			this.btnPrintReport.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			System.Drawing.Color buttonFace3 = System.Drawing.SystemColors.ButtonFace;
			this.btnPrintReport.BackColor = buttonFace3;
			this.btnPrintReport.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(88, 2);
			this.btnPrintReport.Location = location8;
			Padding margin5 = new Padding(2);
			this.btnPrintReport.Margin = margin5;
			this.btnPrintReport.Name = "btnPrintReport";
			System.Drawing.Size size122 = new System.Drawing.Size(82, 28);
			this.btnPrintReport.Size = size122;
			this.btnPrintReport.TabIndex = 7;
			this.btnPrintReport.Text = "打印报表";
			this.btnPrintReport.UseVisualStyleBackColor = false;
			this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
			this.btnSaveTestData.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			System.Drawing.Color buttonFace4 = System.Drawing.SystemColors.ButtonFace;
			this.btnSaveTestData.BackColor = buttonFace4;
			this.btnSaveTestData.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(174, 2);
			this.btnSaveTestData.Location = location9;
			Padding margin6 = new Padding(2);
			this.btnSaveTestData.Margin = margin6;
			this.btnSaveTestData.Name = "btnSaveTestData";
			System.Drawing.Size size123 = new System.Drawing.Size(82, 28);
			this.btnSaveTestData.Size = size123;
			this.btnSaveTestData.TabIndex = 9;
			this.btnSaveTestData.Text = "保存数据";
			this.btnSaveTestData.UseVisualStyleBackColor = false;
			this.btnSaveTestData.Click += new System.EventHandler(this.btnSaveTestData_Click);
			this.btnCloseProject.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			System.Drawing.Color buttonFace5 = System.Drawing.SystemColors.ButtonFace;
			this.btnCloseProject.BackColor = buttonFace5;
			this.btnCloseProject.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location10 = new System.Drawing.Point(260, 2);
			this.btnCloseProject.Location = location10;
			Padding margin7 = new Padding(2);
			this.btnCloseProject.Margin = margin7;
			this.btnCloseProject.Name = "btnCloseProject";
			System.Drawing.Size size124 = new System.Drawing.Size(65, 28);
			this.btnCloseProject.Size = size124;
			this.btnCloseProject.TabIndex = 10;
			this.btnCloseProject.Text = "关闭";
			this.btnCloseProject.UseVisualStyleBackColor = false;
			this.btnCloseProject.Click += new System.EventHandler(this.btnCloseProject_Click);
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.btnStartDTTest);
			this.flowLayoutPanel1.Controls.Add(this.btnStartDLTest);
			this.flowLayoutPanel1.Controls.Add(this.btnStartJYTest);
			this.flowLayoutPanel1.Controls.Add(this.btnStartDDJYTest);
			this.flowLayoutPanel1.Controls.Add(this.btnStartNYTest);
			this.flowLayoutPanel1.Controls.Add(this.btnYJCS);
			System.Drawing.Point location11 = new System.Drawing.Point(15, 6);
			this.flowLayoutPanel1.Location = location11;
			Padding margin8 = new Padding(2);
			this.flowLayoutPanel1.Margin = margin8;
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			System.Drawing.Size size125 = new System.Drawing.Size(545, 32);
			this.flowLayoutPanel1.Size = size125;
			this.flowLayoutPanel1.TabIndex = 12;
			System.Drawing.Color buttonFace6 = System.Drawing.SystemColors.ButtonFace;
			this.btnStartDTTest.BackColor = buttonFace6;
			this.btnStartDTTest.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location12 = new System.Drawing.Point(2, 2);
			this.btnStartDTTest.Location = location12;
			Padding margin9 = new Padding(2);
			this.btnStartDTTest.Margin = margin9;
			this.btnStartDTTest.Name = "btnStartDTTest";
			System.Drawing.Size size126 = new System.Drawing.Size(82, 28);
			this.btnStartDTTest.Size = size126;
			this.btnStartDTTest.TabIndex = 1;
			this.btnStartDTTest.Text = "导通测试";
			this.btnStartDTTest.UseVisualStyleBackColor = false;
			this.btnStartDTTest.Click += new System.EventHandler(this.btnStartDTTest_Click);
			System.Drawing.Color buttonFace7 = System.Drawing.SystemColors.ButtonFace;
			this.btnStartDLTest.BackColor = buttonFace7;
			this.btnStartDLTest.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location13 = new System.Drawing.Point(88, 2);
			this.btnStartDLTest.Location = location13;
			Padding margin10 = new Padding(2);
			this.btnStartDLTest.Margin = margin10;
			this.btnStartDLTest.Name = "btnStartDLTest";
			System.Drawing.Size size127 = new System.Drawing.Size(82, 28);
			this.btnStartDLTest.Size = size127;
			this.btnStartDLTest.TabIndex = 0;
			this.btnStartDLTest.Text = "短路测试";
			this.btnStartDLTest.UseVisualStyleBackColor = false;
			this.btnStartDLTest.Click += new System.EventHandler(this.btnStartDLTest_Click);
			System.Drawing.Color buttonFace8 = System.Drawing.SystemColors.ButtonFace;
			this.btnStartJYTest.BackColor = buttonFace8;
			this.btnStartJYTest.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location14 = new System.Drawing.Point(174, 2);
			this.btnStartJYTest.Location = location14;
			Padding margin11 = new Padding(2);
			this.btnStartJYTest.Margin = margin11;
			this.btnStartJYTest.Name = "btnStartJYTest";
			System.Drawing.Size size128 = new System.Drawing.Size(82, 28);
			this.btnStartJYTest.Size = size128;
			this.btnStartJYTest.TabIndex = 2;
			this.btnStartJYTest.Text = "绝缘测试";
			this.btnStartJYTest.UseVisualStyleBackColor = false;
			this.btnStartJYTest.Click += new System.EventHandler(this.btnStartJYTest_Click);
			System.Drawing.Color buttonFace9 = System.Drawing.SystemColors.ButtonFace;
			this.btnStartDDJYTest.BackColor = buttonFace9;
			this.btnStartDDJYTest.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location15 = new System.Drawing.Point(260, 2);
			this.btnStartDDJYTest.Location = location15;
			Padding margin12 = new Padding(2);
			this.btnStartDDJYTest.Margin = margin12;
			this.btnStartDDJYTest.Name = "btnStartDDJYTest";
			System.Drawing.Size size129 = new System.Drawing.Size(105, 28);
			this.btnStartDDJYTest.Size = size129;
			this.btnStartDDJYTest.TabIndex = 3;
			this.btnStartDDJYTest.Text = "对地绝缘测试";
			this.btnStartDDJYTest.UseVisualStyleBackColor = false;
			this.btnStartDDJYTest.Click += new System.EventHandler(this.btnStartDDJYTest_Click);
			System.Drawing.Color buttonFace10 = System.Drawing.SystemColors.ButtonFace;
			this.btnStartNYTest.BackColor = buttonFace10;
			this.btnStartNYTest.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location16 = new System.Drawing.Point(369, 2);
			this.btnStartNYTest.Location = location16;
			Padding margin13 = new Padding(2);
			this.btnStartNYTest.Margin = margin13;
			this.btnStartNYTest.Name = "btnStartNYTest";
			System.Drawing.Size size130 = new System.Drawing.Size(82, 28);
			this.btnStartNYTest.Size = size130;
			this.btnStartNYTest.TabIndex = 11;
			this.btnStartNYTest.Text = "耐压测试";
			this.btnStartNYTest.UseVisualStyleBackColor = false;
			this.btnStartNYTest.Click += new System.EventHandler(this.btnStartNYTest_Click);
			this.btnYJCS.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			System.Drawing.Color buttonFace11 = System.Drawing.SystemColors.ButtonFace;
			this.btnYJCS.BackColor = buttonFace11;
			this.btnYJCS.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location17 = new System.Drawing.Point(461, 2);
			this.btnYJCS.Location = location17;
			Padding margin14 = new Padding(8, 2, 2, 2);
			this.btnYJCS.Margin = margin14;
			this.btnYJCS.Name = "btnYJCS";
			System.Drawing.Size size131 = new System.Drawing.Size(82, 28);
			this.btnYJCS.Size = size131;
			this.btnYJCS.TabIndex = 0;
			this.btnYJCS.Text = "一键测试";
			this.btnYJCS.UseVisualStyleBackColor = false;
			this.btnYJCS.Click += new System.EventHandler(this.btnYJCS_Click);
			this.panel_progress.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Color window = System.Drawing.SystemColors.Window;
			this.panel_progress.BackColor = window;
			this.panel_progress.Controls.Add(this.label_progress);
			this.panel_progress.Controls.Add(this.progressBar_test);
			System.Drawing.Point location18 = new System.Drawing.Point(168, 513);
			this.panel_progress.Location = location18;
			Padding margin15 = new Padding(2);
			this.panel_progress.Margin = margin15;
			this.panel_progress.Name = "panel_progress";
			System.Drawing.Size size132 = new System.Drawing.Size(898, 20);
			this.panel_progress.Size = size132;
			this.panel_progress.TabIndex = 4;
			System.Drawing.Color controlLight = System.Drawing.SystemColors.ControlLight;
			this.label_progress.BackColor = controlLight;
			this.label_progress.BorderStyle = BorderStyle.Fixed3D;
			this.label_progress.Dock = DockStyle.Right;
			System.Drawing.Point location19 = new System.Drawing.Point(857, 0);
			this.label_progress.Location = location19;
			Padding margin16 = new Padding(2, 0, 2, 0);
			this.label_progress.Margin = margin16;
			this.label_progress.Name = "label_progress";
			System.Drawing.Size size133 = new System.Drawing.Size(41, 20);
			this.label_progress.Size = size133;
			this.label_progress.TabIndex = 2;
			this.label_progress.Text = "0%";
			this.label_progress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.progressBar_test.Dock = DockStyle.Fill;
			System.Drawing.Color green = System.Drawing.Color.Green;
			this.progressBar_test.ForeColor = green;
			System.Drawing.Point location20 = new System.Drawing.Point(0, 0);
			this.progressBar_test.Location = location20;
			Padding margin17 = new Padding(2);
			this.progressBar_test.Margin = margin17;
			this.progressBar_test.Name = "progressBar_test";
			System.Drawing.Size size134 = new System.Drawing.Size(898, 20);
			this.progressBar_test.Size = size134;
			this.progressBar_test.Step = 1;
			this.progressBar_test.TabIndex = 1;
			this.panel_tsxx.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Color window2 = System.Drawing.SystemColors.Window;
			this.panel_tsxx.BackColor = window2;
			this.panel_tsxx.Controls.Add(this.label_ExceptionHint);
			System.Drawing.Point location21 = new System.Drawing.Point(168, 487);
			this.panel_tsxx.Location = location21;
			Padding margin18 = new Padding(2);
			this.panel_tsxx.Margin = margin18;
			this.panel_tsxx.Name = "panel_tsxx";
			System.Drawing.Size size135 = new System.Drawing.Size(898, 20);
			this.panel_tsxx.Size = size135;
			this.panel_tsxx.TabIndex = 4;
			this.label_ExceptionHint.Dock = DockStyle.Fill;
			this.label_ExceptionHint.Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Color controlText = System.Drawing.SystemColors.ControlText;
			this.label_ExceptionHint.ForeColor = controlText;
			System.Drawing.Point location22 = new System.Drawing.Point(0, 0);
			this.label_ExceptionHint.Location = location22;
			Padding margin19 = new Padding(2, 0, 2, 0);
			this.label_ExceptionHint.Margin = margin19;
			this.label_ExceptionHint.Name = "label_ExceptionHint";
			System.Drawing.Size size136 = new System.Drawing.Size(898, 20);
			this.label_ExceptionHint.Size = size136;
			this.label_ExceptionHint.TabIndex = 1;
			this.label_ExceptionHint.Text = " 统计: ";
			this.label_ExceptionHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.panel_testData.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Color window3 = System.Drawing.SystemColors.Window;
			this.panel_testData.BackColor = window3;
			this.panel_testData.Controls.Add(this.dataGridView1);
			this.panel_testData.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location23 = new System.Drawing.Point(168, 89);
			this.panel_testData.Location = location23;
			Padding margin20 = new Padding(2);
			this.panel_testData.Margin = margin20;
			this.panel_testData.Name = "panel_testData";
			System.Drawing.Size size137 = new System.Drawing.Size(898, 393);
			this.panel_testData.Size = size137;
			this.panel_testData.TabIndex = 3;
			this.panel_testData.SizeChanged += new System.EventHandler(this.panel_testData_SizeChanged);
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			System.Drawing.Color window4 = System.Drawing.SystemColors.Window;
			this.dataGridView1.BackgroundColor = window4;
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[]
			{
				this.Column_xh,
				this.Column_startInterface,
				this.Column_startPin,
				this.Column_stopInterface,
				this.Column_stopPin,
				this.Column_dtValue,
				this.Column_dtResult,
				this.Column_jyValue,
				this.Column_jyResult,
				this.Column_nyValue,
				this.Column_nyResult
			};
			this.dataGridView1.Columns.AddRange(dataGridViewColumns);
			this.dataGridView1.Dock = DockStyle.Fill;
			System.Drawing.Point location24 = new System.Drawing.Point(0, 0);
			this.dataGridView1.Location = location24;
			Padding margin21 = new Padding(2);
			this.dataGridView1.Margin = margin21;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size138 = new System.Drawing.Size(898, 393);
			this.dataGridView1.Size = size138;
			this.dataGridView1.TabIndex = 14;
			this.dataGridView1.CellMouseDown += new DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
			this.dataGridView1.MouseDoubleClick += new MouseEventHandler(this.dataGridView1_MouseDoubleClick);
			this.Column_xh.HeaderText = "序号";
			this.Column_xh.Name = "Column_xh";
			this.Column_xh.ReadOnly = true;
			this.Column_xh.Width = 72;
			this.Column_startInterface.HeaderText = "起点接口";
			this.Column_startInterface.Name = "Column_startInterface";
			this.Column_startInterface.ReadOnly = true;
			this.Column_startInterface.Width = 95;
			this.Column_startPin.HeaderText = "起点接点";
			this.Column_startPin.Name = "Column_startPin";
			this.Column_startPin.ReadOnly = true;
			this.Column_startPin.Width = 90;
			this.Column_stopInterface.HeaderText = "终点接口";
			this.Column_stopInterface.Name = "Column_stopInterface";
			this.Column_stopInterface.ReadOnly = true;
			this.Column_stopInterface.Width = 95;
			this.Column_stopPin.HeaderText = "终点接点";
			this.Column_stopPin.Name = "Column_stopPin";
			this.Column_stopPin.ReadOnly = true;
			this.Column_stopPin.Width = 90;
			this.Column_dtValue.HeaderText = "导通电阻";
			this.Column_dtValue.Name = "Column_dtValue";
			this.Column_dtValue.ReadOnly = true;
			this.Column_dtValue.Width = 90;
			this.Column_dtResult.HeaderText = "导通\n结论";
			this.Column_dtResult.Name = "Column_dtResult";
			this.Column_dtResult.ReadOnly = true;
			this.Column_dtResult.Width = 90;
			this.Column_jyValue.HeaderText = "绝缘电阻";
			this.Column_jyValue.Name = "Column_jyValue";
			this.Column_jyValue.ReadOnly = true;
			this.Column_jyValue.Width = 90;
			this.Column_jyResult.HeaderText = "绝缘\n结论";
			this.Column_jyResult.Name = "Column_jyResult";
			this.Column_jyResult.ReadOnly = true;
			this.Column_jyResult.Width = 90;
			this.Column_nyValue.HeaderText = "耐压电流";
			this.Column_nyValue.Name = "Column_nyValue";
			this.Column_nyValue.ReadOnly = true;
			this.Column_nyValue.Width = 90;
			this.Column_nyResult.HeaderText = "耐压\n结论";
			this.Column_nyResult.Name = "Column_nyResult";
			this.Column_nyResult.ReadOnly = true;
			this.Column_nyResult.Width = 90;
			this.panel_testNote.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Color window5 = System.Drawing.SystemColors.Window;
			this.panel_testNote.BackColor = window5;
			this.panel_testNote.Controls.Add(this.label_ots);
			System.Drawing.Point location25 = new System.Drawing.Point(168, 46);
			this.panel_testNote.Location = location25;
			Padding margin22 = new Padding(2);
			this.panel_testNote.Margin = margin22;
			this.panel_testNote.Name = "panel_testNote";
			System.Drawing.Size size139 = new System.Drawing.Size(898, 35);
			this.panel_testNote.Size = size139;
			this.panel_testNote.TabIndex = 2;
			this.label_ots.Dock = DockStyle.Fill;
			this.label_ots.Font = new System.Drawing.Font("宋体", 22f);
			System.Drawing.Color steelBlue = System.Drawing.Color.SteelBlue;
			this.label_ots.ForeColor = steelBlue;
			System.Drawing.Point location26 = new System.Drawing.Point(0, 0);
			this.label_ots.Location = location26;
			Padding margin23 = new Padding(2, 0, 2, 0);
			this.label_ots.Margin = margin23;
			this.label_ots.Name = "label_ots";
			System.Drawing.Size size140 = new System.Drawing.Size(898, 35);
			this.label_ots.Size = size140;
			this.label_ots.TabIndex = 0;
			this.label_ots.Text = "等待测试";
			this.label_ots.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.panel_projectInfo.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
			System.Drawing.Color window6 = System.Drawing.SystemColors.Window;
			this.panel_projectInfo.BackColor = window6;
			this.panel_projectInfo.Controls.Add(this.label_TVYCXSSet);
			this.panel_projectInfo.Controls.Add(this.pictureBox_warning);
			this.panel_projectInfo.Controls.Add(this.treeView_projectInfo);
			this.panel_projectInfo.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location27 = new System.Drawing.Point(8, 46);
			this.panel_projectInfo.Location = location27;
			Padding margin24 = new Padding(2);
			this.panel_projectInfo.Margin = margin24;
			this.panel_projectInfo.Name = "panel_projectInfo";
			System.Drawing.Size size141 = new System.Drawing.Size(153, 486);
			this.panel_projectInfo.Size = size141;
			this.panel_projectInfo.TabIndex = 1;
			this.label_TVYCXSSet.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Color windowText = System.Drawing.SystemColors.WindowText;
			this.label_TVYCXSSet.ForeColor = windowText;
			System.Drawing.Point location28 = new System.Drawing.Point(133, 1);
			this.label_TVYCXSSet.Location = location28;
			Padding margin25 = new Padding(2, 0, 2, 0);
			this.label_TVYCXSSet.Margin = margin25;
			this.label_TVYCXSSet.Name = "label_TVYCXSSet";
			System.Drawing.Size size142 = new System.Drawing.Size(19, 20);
			this.label_TVYCXSSet.Size = size142;
			this.label_TVYCXSSet.TabIndex = 3;
			this.label_TVYCXSSet.Text = "-";
			this.label_TVYCXSSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label_TVYCXSSet.Click += new System.EventHandler(this.label_TVYCXSSet_Click);
			this.pictureBox_warning.Dock = DockStyle.Bottom;
			this.pictureBox_warning.Image = (System.Drawing.Image)resources.GetObject("pictureBox_warning.Image");
			System.Drawing.Point location29 = new System.Drawing.Point(0, 266);
			this.pictureBox_warning.Location = location29;
			Padding margin26 = new Padding(2);
			this.pictureBox_warning.Margin = margin26;
			this.pictureBox_warning.Name = "pictureBox_warning";
			System.Drawing.Size size143 = new System.Drawing.Size(153, 220);
			this.pictureBox_warning.Size = size143;
			this.pictureBox_warning.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox_warning.TabIndex = 1;
			this.pictureBox_warning.TabStop = false;
			this.pictureBox_warning.Visible = false;
			this.treeView_projectInfo.Dock = DockStyle.Fill;
			this.treeView_projectInfo.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.treeView_projectInfo.ImageIndex = 0;
			this.treeView_projectInfo.ImageList = this.imageList1;
			this.treeView_projectInfo.ItemHeight = 24;
			System.Drawing.Point location30 = new System.Drawing.Point(0, 0);
			this.treeView_projectInfo.Location = location30;
			Padding margin27 = new Padding(2);
			this.treeView_projectInfo.Margin = margin27;
			this.treeView_projectInfo.Name = "treeView_projectInfo";
			treeNode.ImageKey = "1_0_0.png";
			treeNode.Name = "tn_PN_EditProject";
			treeNode.SelectedImageKey = "1_0_0.png";
			treeNode.Text = "编辑项目";
			treeNode2.ImageKey = "1_0.png";
			treeNode2.Name = "tn_PN_ProjectInfo";
			treeNode2.SelectedImageKey = "1_0.png";
			treeNode2.Text = "项目信息";
			treeNode3.ImageKey = "1_1_0.png";
			treeNode3.Name = "tn_PN_CableDetailView";
			treeNode3.SelectedImageKey = "1_1_0.png";
			treeNode3.Text = "查看线束";
			treeNode4.ImageKey = "1_1.png";
			treeNode4.Name = "tn_PN_BCCable";
			treeNode4.SelectedImageKey = "1_1.png";
			treeNode4.Text = "被测线束";
			treeNode5.ImageKey = "1_3_0.png";
			treeNode5.Name = "tn_PN_ClearData";
			treeNode5.SelectedImageKey = "1_3_0.png";
			treeNode5.Text = "清除数据";
			treeNode6.ImageKey = "1_3.png";
			treeNode6.Name = "tn_PN_TestData";
			treeNode6.SelectedImageKey = "1_3.png";
			treeNode6.Text = "测试数据";
			treeNode7.ImageKey = "1_4_1.png";
			treeNode7.Name = "tn_PN_CreateReport";
			treeNode7.SelectedImageKey = "1_4_1.png";
			treeNode7.Text = "生成报表";
			treeNode8.ImageKey = "1_4_2.png";
			treeNode8.Name = "tn_PN_PrintReport";
			treeNode8.SelectedImageKey = "1_4_2.png";
			treeNode8.Text = "打印报表";
			treeNode9.ImageKey = "1_4.png";
			treeNode9.Name = "tn_PN_Report";
			treeNode9.SelectedImageKey = "1_4.png";
			treeNode9.Text = "生成报表";
			treeNode10.ImageKey = "1.png";
			treeNode10.Name = "tn_PN";
			treeNode10.SelectedImageKey = "1.png";
			treeNode10.Text = "项目名称";
			treeNode11.ImageKey = "1_5_0.png";
			treeNode11.Name = "tn_EI_EquipmentView";
			treeNode11.SelectedImageKey = "1_5_0.png";
			treeNode11.Text = "查看设备";
			treeNode12.ImageKey = "1_5.png";
			treeNode12.Name = "tn_EI";
			treeNode12.SelectedImageKey = "1_5.png";
			treeNode12.Text = "设备信息";
			TreeNode[] nodes = new TreeNode[]
			{
				treeNode10,
				treeNode12
			};
			this.treeView_projectInfo.Nodes.AddRange(nodes);
			this.treeView_projectInfo.SelectedImageIndex = 0;
			System.Drawing.Size size144 = new System.Drawing.Size(153, 486);
			this.treeView_projectInfo.Size = size144;
			this.treeView_projectInfo.TabIndex = 0;
			this.treeView_projectInfo.MouseDoubleClick += new MouseEventHandler(this.treeView_projectInfo_MouseDoubleClick);
			this.imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
			System.Drawing.Color transparent = System.Drawing.Color.Transparent;
			this.imageList1.TransparentColor = transparent;
			this.imageList1.Images.SetKeyName(0, "1.png");
			this.imageList1.Images.SetKeyName(1, "1_0.png");
			this.imageList1.Images.SetKeyName(2, "1_0_0.png");
			this.imageList1.Images.SetKeyName(3, "1_0_2.png");
			this.imageList1.Images.SetKeyName(4, "1_1.png");
			this.imageList1.Images.SetKeyName(5, "1_1_0.png");
			this.imageList1.Images.SetKeyName(6, "1_2.png");
			this.imageList1.Images.SetKeyName(7, "1_2_0.png");
			this.imageList1.Images.SetKeyName(8, "1_2_1.png");
			this.imageList1.Images.SetKeyName(9, "1_3.png");
			this.imageList1.Images.SetKeyName(10, "1_3_0.png");
			this.imageList1.Images.SetKeyName(11, "1_4.png");
			this.imageList1.Images.SetKeyName(12, "1_4_0.png");
			this.imageList1.Images.SetKeyName(13, "1_4_1.png");
			this.imageList1.Images.SetKeyName(14, "1_4_2.png");
			this.imageList1.Images.SetKeyName(15, "1_5.png");
			this.imageList1.Images.SetKeyName(16, "1_5_0.png");
			this.panel1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
			System.Drawing.Color menuBar = System.Drawing.SystemColors.MenuBar;
			this.panel1.BackColor = menuBar;
			this.panel1.Controls.Add(this.groupBox_CommProject);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label_OpenProject);
			this.panel1.Controls.Add(this.pictureBox5);
			this.panel1.Controls.Add(this.pictureBox4);
			this.panel1.Controls.Add(this.label_CreateProject);
			this.panel1.Controls.Add(this.pictureBox3);
			System.Drawing.Point location31 = new System.Drawing.Point(8, 96);
			this.panel1.Location = location31;
			Padding margin28 = new Padding(2);
			this.panel1.Margin = margin28;
			this.panel1.Name = "panel1";
			System.Drawing.Size size145 = new System.Drawing.Size(191, 438);
			this.panel1.Size = size145;
			this.panel1.TabIndex = 3;
			this.groupBox_CommProject.Controls.Add(this.dataGridView_CommProject);
			this.groupBox_CommProject.Dock = DockStyle.Fill;
			this.groupBox_CommProject.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location32 = new System.Drawing.Point(0, 0);
			this.groupBox_CommProject.Location = location32;
			Padding margin29 = new Padding(2);
			this.groupBox_CommProject.Margin = margin29;
			this.groupBox_CommProject.Name = "groupBox_CommProject";
			Padding padding3 = new Padding(2);
			this.groupBox_CommProject.Padding = padding3;
			this.groupBox_CommProject.RightToLeft = RightToLeft.No;
			System.Drawing.Size size146 = new System.Drawing.Size(191, 438);
			this.groupBox_CommProject.Size = size146;
			this.groupBox_CommProject.TabIndex = 5;
			this.groupBox_CommProject.TabStop = false;
			this.dataGridView_CommProject.AllowUserToAddRows = false;
			this.dataGridView_CommProject.AllowUserToDeleteRows = false;
			this.dataGridView_CommProject.AllowUserToResizeColumns = false;
			this.dataGridView_CommProject.AllowUserToResizeRows = false;
			System.Drawing.Color menuBar2 = System.Drawing.SystemColors.MenuBar;
			this.dataGridView_CommProject.BackgroundColor = menuBar2;
			this.dataGridView_CommProject.BorderStyle = BorderStyle.None;
			this.dataGridView_CommProject.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns2 = new DataGridViewColumn[]
			{
				this.dgvTextBoxColumn_commProject
			};
			this.dataGridView_CommProject.Columns.AddRange(dataGridViewColumns2);
			this.dataGridView_CommProject.Dock = DockStyle.Fill;
			System.Drawing.Point location33 = new System.Drawing.Point(2, 19);
			this.dataGridView_CommProject.Location = location33;
			Padding margin30 = new Padding(2);
			this.dataGridView_CommProject.Margin = margin30;
			this.dataGridView_CommProject.MultiSelect = false;
			this.dataGridView_CommProject.Name = "dataGridView_CommProject";
			this.dataGridView_CommProject.ReadOnly = true;
			this.dataGridView_CommProject.RowHeadersVisible = false;
			this.dataGridView_CommProject.RowTemplate.Height = 27;
			this.dataGridView_CommProject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size147 = new System.Drawing.Size(187, 417);
			this.dataGridView_CommProject.Size = size147;
			this.dataGridView_CommProject.TabIndex = 15;
			this.dataGridView_CommProject.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dataGridView_CommProject_CellMouseDoubleClick);
			this.dgvTextBoxColumn_commProject.HeaderText = "常用项目清单";
			this.dgvTextBoxColumn_commProject.Name = "dgvTextBoxColumn_commProject";
			this.dgvTextBoxColumn_commProject.ReadOnly = true;
			this.dgvTextBoxColumn_commProject.Width = 150;
			this.label3.AutoSize = true;
			System.Drawing.Color foreColor = System.Drawing.Color.FromArgb(170, 170, 255);
			this.label3.ForeColor = foreColor;
			System.Drawing.Point location34 = new System.Drawing.Point(11, 112);
			this.label3.Location = location34;
			Padding margin31 = new Padding(2, 0, 2, 0);
			this.label3.Margin = margin31;
			this.label3.Name = "label3";
			System.Drawing.Size size148 = new System.Drawing.Size(89, 12);
			this.label3.Size = size148;
			this.label3.TabIndex = 2;
			this.label3.Text = "最近打开的项目";
			this.label3.Visible = false;
			this.label_OpenProject.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location35 = new System.Drawing.Point(64, 66);
			this.label_OpenProject.Location = location35;
			Padding margin32 = new Padding(2, 0, 2, 0);
			this.label_OpenProject.Margin = margin32;
			this.label_OpenProject.Name = "label_OpenProject";
			System.Drawing.Size size149 = new System.Drawing.Size(94, 15);
			this.label_OpenProject.Size = size149;
			this.label_OpenProject.TabIndex = 4;
			this.label_OpenProject.Text = "打开项目";
			this.label_OpenProject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label_OpenProject.Visible = false;
			this.label_OpenProject.Click += new System.EventHandler(this.MenuItem_OpenProject_Click);
			this.pictureBox5.Image = (System.Drawing.Image)resources.GetObject("pictureBox5.Image");
			System.Drawing.Point location36 = new System.Drawing.Point(100, 117);
			this.pictureBox5.Location = location36;
			Padding margin33 = new Padding(2);
			this.pictureBox5.Margin = margin33;
			this.pictureBox5.Name = "pictureBox5";
			System.Drawing.Size size150 = new System.Drawing.Size(84, 2);
			this.pictureBox5.Size = size150;
			this.pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox5.TabIndex = 0;
			this.pictureBox5.TabStop = false;
			this.pictureBox5.Visible = false;
			this.pictureBox4.Image = (System.Drawing.Image)resources.GetObject("pictureBox4.Image");
			System.Drawing.Point location37 = new System.Drawing.Point(37, 62);
			this.pictureBox4.Location = location37;
			Padding margin34 = new Padding(2);
			this.pictureBox4.Margin = margin34;
			this.pictureBox4.Name = "pictureBox4";
			System.Drawing.Size size151 = new System.Drawing.Size(22, 24);
			this.pictureBox4.Size = size151;
			this.pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox4.TabIndex = 0;
			this.pictureBox4.TabStop = false;
			this.pictureBox4.Visible = false;
			this.label_CreateProject.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location38 = new System.Drawing.Point(64, 29);
			this.label_CreateProject.Location = location38;
			Padding margin35 = new Padding(2, 0, 2, 0);
			this.label_CreateProject.Margin = margin35;
			this.label_CreateProject.Name = "label_CreateProject";
			System.Drawing.Size size152 = new System.Drawing.Size(94, 15);
			this.label_CreateProject.Size = size152;
			this.label_CreateProject.TabIndex = 3;
			this.label_CreateProject.Text = "新建项目";
			this.label_CreateProject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label_CreateProject.Visible = false;
			this.label_CreateProject.Click += new System.EventHandler(this.MenuItem_CreateProject_Click);
			this.pictureBox3.Image = (System.Drawing.Image)resources.GetObject("pictureBox3.Image");
			System.Drawing.Point location39 = new System.Drawing.Point(37, 23);
			this.pictureBox3.Location = location39;
			Padding margin36 = new Padding(2);
			this.pictureBox3.Margin = margin36;
			this.pictureBox3.Name = "pictureBox3";
			System.Drawing.Size size153 = new System.Drawing.Size(22, 24);
			this.pictureBox3.Size = size153;
			this.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox3.TabIndex = 0;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Visible = false;
			this.panel_note.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Color menuBar3 = System.Drawing.SystemColors.MenuBar;
			this.panel_note.BackColor = menuBar3;
			this.panel_note.Controls.Add(this.richTextBox1);
			this.panel_note.Controls.Add(this.pictureBox2);
			System.Drawing.Point location40 = new System.Drawing.Point(206, 96);
			this.panel_note.Location = location40;
			Padding margin37 = new Padding(2);
			this.panel_note.Margin = margin37;
			this.panel_note.Name = "panel_note";
			System.Drawing.Size size154 = new System.Drawing.Size(859, 438);
			this.panel_note.Size = size154;
			this.panel_note.TabIndex = 6;
			this.richTextBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
			System.Drawing.Color menu = System.Drawing.SystemColors.Menu;
			this.richTextBox1.BackColor = menu;
			this.richTextBox1.BorderStyle = BorderStyle.None;
			this.richTextBox1.Cursor = Cursors.Default;
			this.richTextBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Color foreColor2 = System.Drawing.Color.FromArgb(0, 85, 127);
			this.richTextBox1.ForeColor = foreColor2;
			System.Drawing.Point location41 = new System.Drawing.Point(15, 16);
			this.richTextBox1.Location = location41;
			Padding margin38 = new Padding(2);
			this.richTextBox1.Margin = margin38;
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
			System.Drawing.Size size155 = new System.Drawing.Size(315, 431);
			this.richTextBox1.Size = size155;
			this.richTextBox1.TabIndex = 5;
			this.richTextBox1.Text = "试验流程\n第一步：录入接口信息\n第二步：录入线束信息\n第三步：创建测试项目\n      （1）新建测试项目\n      （2）录入试验参数\n      （3）选择被测线束\n第四步：运行测试项目\n      （1）打开测试项目\n      （2）一键启动测试\n      （3）生成测试报告";
			this.pictureBox2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Point location42 = new System.Drawing.Point(355, 117);
			this.pictureBox2.Location = location42;
			Padding margin39 = new Padding(2);
			this.pictureBox2.Margin = margin39;
			this.pictureBox2.Name = "pictureBox2";
			System.Drawing.Size size156 = new System.Drawing.Size(482, 192);
			this.pictureBox2.Size = size156;
			this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 0;
			this.pictureBox2.TabStop = false;
			this.pictureBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Color control = System.Drawing.SystemColors.Control;
			this.pictureBox1.BackColor = control;
			this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			System.Drawing.Point location43 = new System.Drawing.Point(8, 9);
			this.pictureBox1.Location = location43;
			Padding margin40 = new Padding(2);
			this.pictureBox1.Margin = margin40;
			this.pictureBox1.Name = "pictureBox1";
			System.Drawing.Size size157 = new System.Drawing.Size(1057, 80);
			this.pictureBox1.Size = size157;
			this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.timer_projectTest.Interval = 1000;
			this.timer_projectTest.Tick += new System.EventHandler(this.timer_projectTest_Tick);
			this.timer_ace.Interval = 6000;
			this.timer_ace.Tick += new System.EventHandler(this.timer_ace_Tick);
			this.timer_dlTest.Interval = 1000;
			this.timer_dlTest.Tick += new System.EventHandler(this.timer_dlTest_Tick);
			this.timer_DDJYTest.Interval = 1000;
			this.timer_DDJYTest.Tick += new System.EventHandler(this.timer_DDJYTest_Tick);
			this.timer_YJCS.Interval = 1000;
			this.timer_YJCS.Tick += new System.EventHandler(this.timer_YJCS_Tick);
			this.contextMenuStrip_DTJYNY.Font = new System.Drawing.Font("宋体", 10.8f);
			ToolStripItem[] toolStripItems14 = new ToolStripItem[]
			{
				this.toolStripMenuItem_DT,
				this.toolStripSeparator_JY,
				this.toolStripMenuItem_JY,
				this.toolStripSeparator_NY,
				this.toolStripMenuItem_NY
			};
			this.contextMenuStrip_DTJYNY.Items.AddRange(toolStripItems14);
			this.contextMenuStrip_DTJYNY.Name = "contextMenuStrip1";
			System.Drawing.Size size158 = new System.Drawing.Size(135, 82);
			this.contextMenuStrip_DTJYNY.Size = size158;
			this.toolStripMenuItem_DT.Name = "toolStripMenuItem_DT";
			System.Drawing.Size size159 = new System.Drawing.Size(134, 22);
			this.toolStripMenuItem_DT.Size = size159;
			this.toolStripMenuItem_DT.Text = "导通测试";
			this.toolStripMenuItem_DT.Click += new System.EventHandler(this.toolStripMenuItem_DT_Click);
			this.toolStripSeparator_JY.Name = "toolStripSeparator_JY";
			System.Drawing.Size size160 = new System.Drawing.Size(131, 6);
			this.toolStripSeparator_JY.Size = size160;
			this.toolStripMenuItem_JY.Name = "toolStripMenuItem_JY";
			System.Drawing.Size size161 = new System.Drawing.Size(134, 22);
			this.toolStripMenuItem_JY.Size = size161;
			this.toolStripMenuItem_JY.Text = "绝缘测试";
			this.toolStripMenuItem_JY.Click += new System.EventHandler(this.toolStripMenuItem_JY_Click);
			this.toolStripSeparator_NY.Name = "toolStripSeparator_NY";
			System.Drawing.Size size162 = new System.Drawing.Size(131, 6);
			this.toolStripSeparator_NY.Size = size162;
			this.toolStripMenuItem_NY.Name = "toolStripMenuItem_NY";
			System.Drawing.Size size163 = new System.Drawing.Size(134, 22);
			this.toolStripMenuItem_NY.Size = size163;
			this.toolStripMenuItem_NY.Text = "耐压测试";
			this.toolStripMenuItem_NY.Click += new System.EventHandler(this.toolStripMenuItem_NY_Click);
			this.contextMenuStrip_DataProc.Font = new System.Drawing.Font("宋体", 10.8f);
			ToolStripItem[] toolStripItems15 = new ToolStripItem[]
			{
				this.toolStripMenuItem_ExportData
			};
			this.contextMenuStrip_DataProc.Items.AddRange(toolStripItems15);
			this.contextMenuStrip_DataProc.Name = "contextMenuStrip1";
			System.Drawing.Size size164 = new System.Drawing.Size(165, 26);
			this.contextMenuStrip_DataProc.Size = size164;
			this.toolStripMenuItem_ExportData.Name = "toolStripMenuItem_ExportData";
			System.Drawing.Size size165 = new System.Drawing.Size(164, 22);
			this.toolStripMenuItem_ExportData.Size = size165;
			this.toolStripMenuItem_ExportData.Text = "导出表格数据";
			this.toolStripMenuItem_ExportData.Click += new System.EventHandler(this.toolStripMenuItem_ExportData_Click);
			this.timer_checkLifeTime.Interval = 60000;
			this.timer_checkLifeTime.Tick += new System.EventHandler(this.timer_checkLifeTime_Tick);
			this.timer_RefreshIndex.Interval = 1000;
			this.timer_RefreshIndex.Tick += new System.EventHandler(this.timer_RefreshIndex_Tick);
			this.notifyIcon_ctm.Icon = (System.Drawing.Icon)resources.GetObject("notifyIcon_ctm.Icon");
			this.notifyIcon_ctm.Text = "Cable Easy Test";
			this.notifyIcon_ctm.MouseDoubleClick += new MouseEventHandler(this.notifyIcon_ctm_MouseDoubleClick);
			this.timer_Delay.Interval = 200;
			this.timer_Delay.Tick += new System.EventHandler(this.timer_Delay_Tick);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(1074, 661);
			base.ClientSize = clientSize;
			base.Controls.Add(this.panel_work);
			base.Controls.Add(this.toolStrip1);
			base.Controls.Add(this.menuStrip1);
			base.Controls.Add(this.statusStrip1);
			this.DoubleBuffered = true;
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin41 = new Padding(2);
			base.Margin = margin41;
			base.Name = "ctFormMain";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Cable Easy Test 1.0";
			base.WindowState = FormWindowState.Minimized;
			base.FormClosing += new FormClosingEventHandler(this.ctFormMain_FormClosing);
			base.Load += new System.EventHandler(this.ctFormMain_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormMain_SizeChanged);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel_work.ResumeLayout(false);
			this.panel_projectTest.ResumeLayout(false);
			this.panel_projectTest.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.panel_progress.ResumeLayout(false);
			this.panel_tsxx.ResumeLayout(false);
			this.panel_testData.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			this.panel_testNote.ResumeLayout(false);
			this.panel_projectInfo.ResumeLayout(false);
			((ISupportInitialize)this.pictureBox_warning).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox_CommProject.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView_CommProject).EndInit();
			((ISupportInitialize)this.pictureBox5).EndInit();
			((ISupportInitialize)this.pictureBox4).EndInit();
			((ISupportInitialize)this.pictureBox3).EndInit();
			this.panel_note.ResumeLayout(false);
			((ISupportInitialize)this.pictureBox2).EndInit();
			((ISupportInitialize)this.pictureBox1).EndInit();
			this.contextMenuStrip_DTJYNY.ResumeLayout(false);
			this.contextMenuStrip_DataProc.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public void ReceiveData()
		{
			try
			{
			}
			catch (System.Exception arg_02_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_02_0.StackTrace);
			}
		}
		public void ThreadChatMonitor()
		{
			try
			{
			}
			catch (System.Exception arg_02_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_02_0.StackTrace);
			}
		}
		private void InvokeFun()
		{
			if (this.otsShowInfoStr != this.label_ots.Text.ToString())
			{
				this.label_ots.Text = this.otsShowInfoStr;
			}
			System.Drawing.Color this2 = this.label_ots.ForeColor;
			if (this.otsShowInfoColor != this2)
			{
				this.label_ots.ForeColor = this.otsShowInfoColor;
			}
		}
		private void ThreadFun()
		{
			MethodInvoker mi = new MethodInvoker(this.InvokeFun);
			base.BeginInvoke(mi);
		}
		private void button1_Click(object sender, System.EventArgs e)
		{
			new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadFun)).Start();
		}
		public void RefreshOTSDisposeFunc()
		{
			try
			{
				new System.Threading.Thread(new System.Threading.ThreadStart(this.ThreadFun)).Start();
			}
			catch (System.Exception arg_18_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_18_0.StackTrace);
			}
		}
		public void SendStopCmdFeedbackFunc()
		{
			try
			{
				int iwtc = 0;
				this.gLineTestProcessor.mpDevComm.mParseCmd.bStopTestRespFlag = false;
				do
				{
					this.gLineTestProcessor.SendStopCmd();
					System.Threading.Thread.Sleep(300);
					iwtc++;
				}
				while (iwtc < 1 && !this.gLineTestProcessor.mpDevComm.mParseCmd.bStopTestRespFlag);
			}
			catch (System.Exception arg_4E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_4E_0.StackTrace);
			}
		}
		public void TestFinishedDisposeFunc()
		{
			try
			{
				this.bIsTestStatus = false;
				this.gLineTestProcessor.mbKeepRun = false;
				this.gLineTestProcessor.iTestPreValue = 100;
				this.timer_YJCS.Enabled = false;
				this.timer_YJCS.Interval = 1000;
				this.timer_dlTest.Enabled = false;
				this.timer_DDJYTest.Enabled = false;
				this.timer_projectTest.Enabled = false;
				this.btnCreateReport.Visible = true;
				this.btnPrintReport.Visible = true;
				this.btnSaveTestData.Visible = true;
				this.btnCloseProject.Visible = true;
				this.btnStartDTTest.Visible = this.gLineTestProcessor.bDTTestEnabled;
				this.btnStartDLTest.Visible = this.gLineTestProcessor.bDLTestEnabled;
				this.btnStartJYTest.Visible = this.gLineTestProcessor.bJYTestEnabled;
				this.btnStartDDJYTest.Visible = this.gLineTestProcessor.bDDJYTestEnabled;
				this.btnStartNYTest.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.btnYJCS.Visible = true;
				this.treeView_projectInfo.Enabled = true;
				this.label_TVYCXSSet.Visible = true;
				this.btnStartDTTest.Text = "导通测试";
				this.btnStartDLTest.Text = "短路测试";
				this.btnStartJYTest.Text = "绝缘测试";
				this.btnStartDDJYTest.Text = "对地绝缘测试";
				this.btnStartNYTest.Text = "耐压测试";
				this.btnYJCS.Text = "一键测试";
				this.progressBar_test.Value = 100;
				this.label_progress.Text = "100%";
				this.menuStrip1.Enabled = true;
				this.toolStrip1.Enabled = true;
				this.bIsYJCSFlag = false;
				this.bChoiceTestFlag = false;
				this.pictureBox_warning.Visible = false;
				this.otsShowInfoStr = "测试终止中..";
				System.Drawing.Color this2 = System.Drawing.Color.SteelBlue;
				this.otsShowInfoColor = this2;
				this.RefreshOTSDisposeFunc();
				if (!this.gLineTestProcessor.bIsTimeOut)
				{
					this.otsShowInfoStr = "测试结束";
				}
				else
				{
					this.otsShowInfoStr = "测试终止";
				}
				this.RefreshOTSDisposeFunc();
				this.SendStopCmdFeedbackFunc();
				this.gLineTestProcessor.gPinConnRelaInfoIndexList.Clear();
				this.gLineTestProcessor.gPinConnInfoJYTempArray.Clear();
				this.gLineTestProcessor.gPinConnInfoNYTempArray.Clear();
				System.GC.Collect();
				System.GC.WaitForPendingFinalizers();
			}
			catch (System.Exception arg_25C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_25C_0.StackTrace);
			}
		}
		public void SendDeviceExistCmdFeedbackFunc()
		{
			try
			{
				this.gLineTestProcessor.mpDevComm.mParseCmd.DeviceExist = false;
				this.gLineTestProcessor.SendDeviceExistCmd();
			}
			catch (System.Exception arg_23_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_23_0.StackTrace);
			}
		}
		public void GetEngineerParaFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				int iMaxTestCount = 1024;
				int iMaxCommonProjCount = 200;
				int iDTEnabledFlag = 1;
				int iDLEnabledFlag = 0;
				int iJYEnabledFlag = 0;
				int iDDJYEnabledFlag = 0;
				int iNYEnabledFlag = 0;
				int iSDNYEnabledFlag = 0;
				int iSDDREnabledFlag = 0;
				int iReportTemplate = 0;
				int iDTVCVisibleFlag = 0;
				int iJYHLModeVisibleFlag = 0;
				int iIOQEnabledFlag = 0;
				int iUIDisplayMode = 0;
				bool bExsitFlag = false;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "select * from TFunctionEnableTable";
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						bExsitFlag = true;
						iMaxTestCount = System.Convert.ToInt32(dataReader["iMaxTestCount"].ToString());
						iMaxCommonProjCount = System.Convert.ToInt32(dataReader["iMaxCommonProjCount"].ToString());
						iDTEnabledFlag = System.Convert.ToInt32(dataReader["iDTEnabledFlag"].ToString());
						iDLEnabledFlag = System.Convert.ToInt32(dataReader["iDLEnabledFlag"].ToString());
						iJYEnabledFlag = System.Convert.ToInt32(dataReader["iJYEnabledFlag"].ToString());
						iDDJYEnabledFlag = System.Convert.ToInt32(dataReader["iDDJYEnabledFlag"].ToString());
						iNYEnabledFlag = System.Convert.ToInt32(dataReader["iNYEnabledFlag"].ToString());
						try
						{
							iSDNYEnabledFlag = System.Convert.ToInt32(dataReader["iSDNYEnabledFlag"].ToString());
							iSDDREnabledFlag = System.Convert.ToInt32(dataReader["iSDDREnabledFlag"].ToString());
							int iOther1EnabledFlag = System.Convert.ToInt32(dataReader["iOther1EnabledFlag"].ToString());
							int iOther2EnabledFlag = System.Convert.ToInt32(dataReader["iOther2EnabledFlag"].ToString());
							int iOther3EnabledFlag = System.Convert.ToInt32(dataReader["iOther3EnabledFlag"].ToString());
						}
						catch (System.Exception arg_198_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_198_0.StackTrace);
						}
						try
						{
							this.iDBTypeIndex = System.Convert.ToInt32(dataReader["iDBTypeIndex"].ToString());
							this.iJYTestMethod = System.Convert.ToInt32(dataReader["iJYTestMethod"].ToString());
							this.iNYTestMethod = System.Convert.ToInt32(dataReader["iNYTestMethod"].ToString());
							this.iUesRelayBoard = System.Convert.ToInt32(dataReader["iUesRelayBoard"].ToString());
							iDTVCVisibleFlag = System.Convert.ToInt32(dataReader["iDTVCVisibleFlag"].ToString());
							iJYHLModeVisibleFlag = System.Convert.ToInt32(dataReader["iJYHLModeVisibleFlag"].ToString());
							iIOQEnabledFlag = System.Convert.ToInt32(dataReader["iIOQEnabledFlag"].ToString());
							iUIDisplayMode = System.Convert.ToInt32(dataReader["iUIDisplayMode"].ToString());
						}
						catch (System.Exception arg_26F_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_26F_0.StackTrace);
						}
					}
					dataReader.Close();
					dataReader = null;
					sqlcommand = "select top 1 * from TReportParaSet";
					cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						iReportTemplate = System.Convert.ToInt32(dataReader["iReportTemplateFormat"].ToString());
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_2C9_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_2C9_0.StackTrace);
					if (dataReader != null)
					{
						dataReader.Close();
						dataReader = null;
					}
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
				this.gLineTestProcessor.iReportTemplateFormat = iReportTemplate;
				if (bExsitFlag)
				{
					this.gLineTestProcessor.SELF_MAX_COUNT = iMaxTestCount;
					this.gLineTestProcessor.iMaxCommonProjectNum = iMaxCommonProjCount;
					this.gLineTestProcessor.iJYTestMethod = this.iJYTestMethod;
					this.gLineTestProcessor.iNYTestMethod = this.iNYTestMethod;
					this.gLineTestProcessor.bDTTestEnabled = true;
					if (iDTEnabledFlag != 1)
					{
						this.gLineTestProcessor.bDTTestEnabled = false;
					}
					this.gLineTestProcessor.bDLTestEnabled = true;
					if (iDLEnabledFlag != 1)
					{
						this.gLineTestProcessor.bDLTestEnabled = false;
					}
					this.gLineTestProcessor.bJYTestEnabled = true;
					if (iJYEnabledFlag != 1)
					{
						this.gLineTestProcessor.bJYTestEnabled = false;
					}
					this.gLineTestProcessor.bDDJYTestEnabled = true;
					if (iDDJYEnabledFlag != 1)
					{
						this.gLineTestProcessor.bDDJYTestEnabled = false;
					}
					this.gLineTestProcessor.bNYTestEnabled = true;
					if (iNYEnabledFlag != 1)
					{
						this.gLineTestProcessor.bNYTestEnabled = false;
					}
					this.gLineTestProcessor.bSDNYTestEnabled = true;
					if (iSDNYEnabledFlag != 1)
					{
						this.gLineTestProcessor.bSDNYTestEnabled = false;
					}
					this.gLineTestProcessor.bSDDRTestEnabled = true;
					if (iSDDREnabledFlag != 1)
					{
						this.gLineTestProcessor.bSDDRTestEnabled = false;
					}
					this.gLineTestProcessor.bUseRelayBoard = true;
					if (this.iUesRelayBoard != 1)
					{
						this.gLineTestProcessor.bUseRelayBoard = false;
					}
					this.gLineTestProcessor.bDTVoltCurrentShowFlag = true;
					if (iDTVCVisibleFlag != 1)
					{
						this.gLineTestProcessor.bDTVoltCurrentShowFlag = false;
					}
					this.gLineTestProcessor.bJYHighLowModeShowFlag = true;
					if (iJYHLModeVisibleFlag != 1)
					{
						this.gLineTestProcessor.bJYHighLowModeShowFlag = false;
					}
					this.gLineTestProcessor.bUseEnglishAlphabetsIOQFlag = false;
					if (iIOQEnabledFlag == 1)
					{
						this.gLineTestProcessor.bUseEnglishAlphabetsIOQFlag = true;
					}
					this.gLineTestProcessor.iUIDisplayMode = iUIDisplayMode;
				}
			}
			catch (System.Exception arg_48D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_48D_0.StackTrace);
			}
			this.gLineTestProcessor.InitRequiredParaFunc();
		}
		public void InitSysVariableFunc()
		{
			try
			{
				this.MenuItem_CurrentDLTestData.Visible = false;
				this.toolStripSeparator_CurrentDLTestData.Visible = false;
				this.MenuItem_CurrentDDJYTestData.Visible = false;
				this.toolStripSeparator_CurrentDDJYTestData.Visible = false;
				string spathStr = Application.StartupPath;
				this.licFilePathStr = spathStr + "\\lic.dll";
				this.dbpath = spathStr + "\\ctsdb.mdb";
				this.mddbpath = spathStr + "\\ctsmddb.mdb";
				System.ValueType valueType = default(System.DateTime);
				(System.DateTime)valueType = new System.DateTime(2028, 2, 2, 2, 2, 2);
				this.endTime = valueType;
				this.iDTTValueColNum = 5;
				this.iJYTValueColNum = 7;
				this.iNYTValueColNum = 9;
				this.iDTResultColNum = 6;
				this.iJYResultColNum = 8;
				this.iNYResultColNum = 10;
				this.iHistoryDataInfoID = 1;
				this.iGroupTestFlag = 0;
				this.iDisconnectCount = 0;
				this.iCommProjectNum = 0;
				this.iTreeViewWidth = 0;
				this.ct_iDTTFFlagStr = "0";
				this.ct_iDLTFFlagStr = "0";
				this.ct_iJYTFFlagStr = "0";
				this.ct_iDDJYTFFlagStr = "0";
				this.ct_iNYTFFlagStr = "0";
				this.noSeleHintStr = "线束连接关系中未选择该项测试!";
				this.otsShowInfoStr = "等待测试..";
				System.Drawing.Color steelBlue = System.Drawing.Color.SteelBlue;
				this.otsShowInfoColor = steelBlue;
				this.bDeviceErrorWarnExistFlag = false;
				this.bUploadErrorWarnExistFlag = false;
				this.bIsConnSuccFlag = false;
				this.bIsExistMapFlag = true;
				this.bTreeViewShowFlag = true;
				this.bEnvironmentParaSetFlag = false;
				this.bSelfStudyPinTestFlag = false;
				this.commonProjStrArray = new System.Collections.Generic.List<string>();
				System.ValueType valueType2 = System.DateTime.Now;
				this.dt = valueType2;
				System.DateTime value = ((System.DateTime)valueType2).ToLocalTime();
				this.ct_TestDateStr = System.Convert.ToString(value);
				this.iHVTWaitingTime = 1000;
				this.ctTestNumberStr = "1";
				this.bcCableIDStr = "1";
				this.strTestResult = ctFormMain.TEST_QUAL_STR;
				this.ct_TestEnvironmentTempStr = "";
				this.ct_TestAmbientHumidityStr = "";
				this.ct_TestCSYTypeStr = "";
				this.ct_TestCSYMeasureNoStr = "";
				this.bcCableStr = "";
				this.iJYTestMethod = 1;
				this.iNYTestMethod = 1;
				string[] array = new string[20];
				this.proTreeStrArray = array;
				array[0] = "项目信息";
				this.proTreeStrArray[1] = "编辑项目";
				this.proTreeStrArray[2] = "刷新项目";
				this.proTreeStrArray[3] = "查看工装";
				this.proTreeStrArray[4] = "被测线束";
				this.proTreeStrArray[5] = "查看线束";
				this.proTreeStrArray[6] = "测试流程";
				this.proTreeStrArray[7] = "导通测试";
				this.proTreeStrArray[8] = "绝缘测试";
				this.proTreeStrArray[9] = "测试数据";
				this.proTreeStrArray[10] = "保存数据";
				this.proTreeStrArray[11] = "清空数据";
				this.proTreeStrArray[12] = "生成报表";
				this.proTreeStrArray[13] = "生成报表";
				this.proTreeStrArray[14] = "打印报表";
				this.proTreeStrArray[15] = "设备信息";
				this.proTreeStrArray[16] = "查看设备";
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		public void UsersRightQureyFunc()
		{
			try
			{
				bool bEnableFlag = ((!this.gLineTestProcessor.bIsAdminFlag) ? 1 : 0) != 0;
				this.dataGridView_CommProject.Enabled = bEnableFlag;
				this.toolStripButton_InterfaceLibManage.Enabled = bEnableFlag;
				this.toolStripSeparator_InterfaceLibManage.Enabled = bEnableFlag;
				this.toolStripButton_CableLibManage.Enabled = bEnableFlag;
				this.toolStripSeparator_CableLibManage.Enabled = bEnableFlag;
				this.toolStripButton_CreateProject.Enabled = bEnableFlag;
				this.toolStripButton_OpenProject.Enabled = bEnableFlag;
				this.toolStripSeparator_CreateProject.Enabled = bEnableFlag;
				this.toolStripSeparator_OpenProject.Enabled = bEnableFlag;
				this.MenuItem_CreateProject.Visible = bEnableFlag;
				this.MenuItem_OpenProject.Visible = bEnableFlag;
				this.MenuItem_CloseProject.Visible = bEnableFlag;
				this.toolStripSeparator_MenuItem_CreateProject.Visible = bEnableFlag;
				this.toolStripSeparator_MenuItem_OpenProject.Visible = bEnableFlag;
				this.toolStripSeparator_MenuItem_CloseProject.Visible = bEnableFlag;
				this.MenuItem_LibManage.Visible = bEnableFlag;
				this.MenuItem_Tool.Visible = bEnableFlag;
				this.MenuItem_UserManage.Visible = this.gLineTestProcessor.bIsAdminFlag;
				this.toolStripSeparator_UserManage.Visible = this.gLineTestProcessor.bIsAdminFlag;
				this.MenuItem_EquipmentInfoManage.Visible = this.gLineTestProcessor.bIsAdminFlag;
				this.toolStripSeparator_EquipmentInfoManage.Visible = this.gLineTestProcessor.bIsAdminFlag;
			}
			catch (System.Exception arg_136_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_136_0.StackTrace);
			}
		}
		public void InitSysControlsFunc()
		{
			try
			{
				this.Column_dtValue.Visible = this.gLineTestProcessor.bDTTestEnabled;
				this.Column_dtResult.Visible = this.gLineTestProcessor.bDTTestEnabled;
				this.Column_jyValue.Visible = this.gLineTestProcessor.bJYTestEnabled;
				this.Column_jyResult.Visible = this.gLineTestProcessor.bJYTestEnabled;
				this.Column_nyValue.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.Column_nyResult.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.btnStartDTTest.Visible = this.gLineTestProcessor.bDTTestEnabled;
				this.MenuItem_DTTEST.Visible = this.gLineTestProcessor.bDTTestEnabled;
				this.toolStripSeparator_DTTEST.Visible = this.gLineTestProcessor.bDTTestEnabled;
				this.btnStartDLTest.Visible = this.gLineTestProcessor.bDLTestEnabled;
				this.MenuItem_DLTEST.Visible = this.gLineTestProcessor.bDLTestEnabled;
				this.toolStripSeparator_DLTEST.Visible = this.gLineTestProcessor.bDLTestEnabled;
				this.btnStartJYTest.Visible = this.gLineTestProcessor.bJYTestEnabled;
				this.MenuItem_JYTEST.Visible = this.gLineTestProcessor.bJYTestEnabled;
				this.toolStripSeparator_JYTEST.Visible = this.gLineTestProcessor.bJYTestEnabled;
				this.btnStartDDJYTest.Visible = this.gLineTestProcessor.bDDJYTestEnabled;
				this.MenuItem_DDJYTEST.Visible = this.gLineTestProcessor.bDDJYTestEnabled;
				this.toolStripSeparator_DDJYTEST.Visible = this.gLineTestProcessor.bDDJYTestEnabled;
				this.btnStartNYTest.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.MenuItem_NYTEST.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.toolStripSeparator_NYTEST.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.MenuItem_SingleDevice_NYTEST.Visible = this.gLineTestProcessor.bSDNYTestEnabled;
				this.toolStripSeparator_SingleDevice_NYTEST.Visible = this.gLineTestProcessor.bSDNYTestEnabled;
				this.MenuItem_SingleDevice_DRTEST.Visible = this.gLineTestProcessor.bSDDRTestEnabled;
				this.toolStripSeparator_SingleDevice_DRTEST.Visible = this.gLineTestProcessor.bSDDRTestEnabled;
				this.toolStripSeparator_IAndRT_PinReletion.Visible = this.gLineTestProcessor.bUseRelayBoard;
				this.MenuItem_IAndRT_PinReletion.Visible = this.gLineTestProcessor.bUseRelayBoard;
				this.toolStripSeparator_AdapterCableLibManage.Visible = this.gLineTestProcessor.bUseRelayBoard;
				this.MenuItem_AdapterCableLibManage.Visible = this.gLineTestProcessor.bUseRelayBoard;
			}
			catch (System.Exception arg_280_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_280_0.StackTrace);
			}
		}
		public void DeviceErrorWarnThreadFunc()
		{
			try
			{
				KParseRepCmd this2 = this.gLineTestProcessor.mpDevComm.mParseCmd;
				if (this2.bDeviceErrorFlag)
				{
					this2.bDeviceErrorFlag = false;
					this.bDeviceErrorWarnExistFlag = true;
					this2 = this.gLineTestProcessor.mpDevComm.mParseCmd;
					MessageBox.Show(this2.errorDateTimeStr + "  " + this2.errorContentStr, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					this.bDeviceErrorWarnExistFlag = false;
					this.gLineTestProcessor.SendQueryDeviceErrorCmd();
				}
			}
			catch (System.Exception arg_75_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_75_0.StackTrace);
			}
		}
		public void ErrorWarnThreadFunc()
		{
			try
			{
				if (this.bUploadErrorWarnExistFlag)
				{
					KParseRepCmd this2 = this.gLineTestProcessor.mpDevComm.mParseCmd;
					MessageBox.Show(this2.uploadErrorDateTimeStr + "  " + this2.uploadErrorContentStr, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (System.Exception arg_44_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_44_0.StackTrace);
			}
		}
		public void ErrorEndDisposeFunc()
		{
			try
			{
				this.otsShowInfoStr = "测试终止";
				this.RefreshOTSDisposeFunc();
				this.gLineTestProcessor.mpDevComm.mParseCmd.bStopTestRespFlag = false;
				this.gLineTestProcessor.mbKeepRun = false;
				this.timer_YJCS.Enabled = false;
				this.timer_projectTest.Enabled = false;
				this.timer_dlTest.Enabled = false;
				this.timer_DDJYTest.Enabled = false;
				this.btnCreateReport.Visible = true;
				this.btnPrintReport.Visible = true;
				this.btnSaveTestData.Visible = true;
				this.btnCloseProject.Visible = true;
				this.btnStartDTTest.Visible = this.gLineTestProcessor.bDTTestEnabled;
				this.btnStartDLTest.Visible = this.gLineTestProcessor.bDLTestEnabled;
				this.btnStartJYTest.Visible = this.gLineTestProcessor.bJYTestEnabled;
				this.btnStartDDJYTest.Visible = this.gLineTestProcessor.bDDJYTestEnabled;
				this.btnStartNYTest.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.btnYJCS.Visible = true;
				this.treeView_projectInfo.Enabled = true;
				this.btnStartDTTest.Text = "导通测试";
				this.btnStartDLTest.Text = "短路测试";
				this.btnStartJYTest.Text = "绝缘测试";
				this.btnStartDDJYTest.Text = "对地绝缘测试";
				this.btnStartNYTest.Text = "耐压测试";
				this.btnYJCS.Text = "一键测试";
				this.progressBar_test.Value = 100;
				this.label_progress.Text = "100%";
				this.menuStrip1.Enabled = true;
				this.toolStrip1.Enabled = true;
				this.bIsYJCSFlag = false;
				this.bIsTestStatus = false;
				this.bChoiceTestFlag = false;
				this.pictureBox_warning.Visible = false;
				this.gLineTestProcessor.SendStopCmd();
			}
			catch (System.Exception ex_1DC)
			{
			}
		}
		private void timer_getTime_Tick(object sender, System.EventArgs e)
		{
			try
			{
				System.ValueType e2 = System.DateTime.Now;
				this.dt = e2;
				this.toolStripStatusLabel_currentTime.Text = "当前时间: " + ((System.DateTime)e2).ToString() + "  ";
				int sender2 = this.iHVTWaitingTime;
				if (sender2 < 600)
				{
					this.iHVTWaitingTime = sender2 + 1;
				}
				KLineTestProcessor this2 = this.gLineTestProcessor;
				if (this2.bEmulationMode)
				{
					this.toolStripStatusLabel_csyConnStatus.Text = "连接正常";
				}
				else
				{
					this2.bIsConnSuccFlag = this.bIsConnSuccFlag;
					if (this.gLineTestProcessor.bIsConnSuccFlag)
					{
						this.toolStripStatusLabel_csyConnStatus.Text = "连接正常";
					}
					else
					{
						this.toolStripStatusLabel_csyConnStatus.Text = "未连接";
					}
					if (this.gLineTestProcessor.mpDevComm.mParseCmd.bDeviceErrorFlag && !this.bDeviceErrorWarnExistFlag)
					{
						new System.Threading.Thread(new System.Threading.ThreadStart(this.DeviceErrorWarnThreadFunc)).Start();
					}
					if (this.gLineTestProcessor.mpDevComm.mParseCmd.bUploadErrorFlag && !this.bUploadErrorWarnExistFlag)
					{
						this.bUploadErrorWarnExistFlag = true;
						this.ErrorEndDisposeFunc();
						new System.Threading.Thread(new System.Threading.ThreadStart(this.ErrorWarnThreadFunc)).Start();
						this.SendStopCmdFeedbackFunc();
					}
				}
			}
			catch (System.Exception arg_132_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_132_0.StackTrace);
			}
		}
		public void AutoConnDeviceFunc()
		{
			try
			{
				KLineTestProcessor this2 = this.gLineTestProcessor;
				if (!this2.bEmulationMode)
				{
					if (!this.bIsTestStatus && !this2.mbKeepRun)
					{
						if (this.bIsAutoConnFlag)
						{
							if (!this.bIsConnSuccFlag)
							{
								if (this2.mpDevComm.InitCAN())
								{
									System.Threading.Thread.Sleep(10);
									this.SendDeviceExistCmdFeedbackFunc();
									System.Threading.Thread.Sleep(400);
									if (!this.gLineTestProcessor.mpDevComm.mParseCmd.DeviceExist)
									{
										try
										{
											this.gLineTestProcessor.mpDevComm.CloseCAN();
										}
										catch (System.Exception ex_90)
										{
										}
										this.bIsConnSuccFlag = false;
									}
									else
									{
										this.bIsConnSuccFlag = true;
									}
								}
							}
							else if (!this2.mpDevComm.mParseCmd.DeviceExist)
							{
								int num = this.iDisconnectCount + 1;
								this.iDisconnectCount = num;
								if (num >= 2)
								{
									try
									{
										this.gLineTestProcessor.mpDevComm.CloseCAN();
									}
									catch (System.Exception ex_E8)
									{
									}
									this.bIsConnSuccFlag = false;
								}
								else
								{
									this.SendDeviceExistCmdFeedbackFunc();
								}
							}
							else
							{
								this.iDisconnectCount = 0;
								this.bIsConnSuccFlag = true;
								this.SendDeviceExistCmdFeedbackFunc();
							}
						}
						else if (this.bIsConnSuccFlag)
						{
							if (!this2.mpDevComm.mParseCmd.DeviceExist)
							{
								int num2 = this.iDisconnectCount + 1;
								this.iDisconnectCount = num2;
								if (num2 >= 2)
								{
									try
									{
										this.gLineTestProcessor.mpDevComm.CloseCAN();
									}
									catch (System.Exception ex_162)
									{
									}
									this.bIsConnSuccFlag = false;
								}
								else
								{
									this.SendDeviceExistCmdFeedbackFunc();
								}
							}
							else
							{
								this.iDisconnectCount = 0;
								this.bIsConnSuccFlag = true;
								this.SendDeviceExistCmdFeedbackFunc();
							}
						}
					}
					else
					{
						this.iDisconnectCount = 0;
					}
				}
			}
			catch (System.Exception arg_197_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_197_0.StackTrace);
			}
		}
		public void GetUserConfigInfoFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				bool bHaveRecordFlag = false;
				bool bBCRFlag = false;
				bool bExistFlag = false;
				int iACD = 1;
				int iRC = 1;
				string tempAPSStr = "0";
				string[] proStringArray = new string[5];
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					try
					{
						string sqlcommand = "select * from TTestEquipmentInfo";
						OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						if (dataReader.Read())
						{
							this.ct_TestCSYTypeStr = dataReader["TestEquipmentModel"].ToString();
							this.ct_TestCSYMeasureNoStr = dataReader["TestEquipmentSN"].ToString();
						}
						dataReader.Close();
						dataReader = null;
					}
					catch (System.Exception arg_9F_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_9F_0.StackTrace);
						if (dataReader != null)
						{
							dataReader.Close();
							dataReader = null;
						}
					}
					try
					{
						string sqlcommand = "select * from TUserCustomCableTestPara where LoginUser='" + this.gLineTestProcessor.loginUserID + "'";
						OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						if (dataReader.Read())
						{
							iACD = System.Convert.ToInt32(dataReader["AutoConnDevice"].ToString());
							iRC = System.Convert.ToInt32(dataReader["IsResistanceCompensation"].ToString());
							this.reportDefaultSavePathStr = dataReader["ReportDefaultSavePath"].ToString();
							tempAPSStr = dataReader["IsAuxPowerSupply"].ToString();
							bHaveRecordFlag = true;
						}
						dataReader.Close();
						dataReader = null;
					}
					catch (System.Exception arg_151_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_151_0.StackTrace);
						if (dataReader != null)
						{
							dataReader.Close();
							dataReader = null;
						}
					}
					if (!bHaveRecordFlag)
					{
						try
						{
							string str = "";
							this.reportDefaultSavePathStr = str;
							string sqlcommand = "insert into TUserCustomCableTestPara(LoginUser,AutoConnDevice,IsResistanceCompensation,ReportDefaultSavePath) values('" + this.gLineTestProcessor.loginUserID + "',1,1,'" + str + "')";
							OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
							cmd.ExecuteNonQuery();
						}
						catch (System.Exception arg_1BD_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_1BD_0.StackTrace);
						}
					}
					this.bIsAutoConnFlag = false;
					if (iACD == 1)
					{
						this.bIsAutoConnFlag = true;
					}
					this.MenuItem_EquipmentAutoConn.Checked = this.bIsAutoConnFlag;
					if (iRC == 1)
					{
						this.gLineTestProcessor.bResistanceCompFlag = true;
					}
					this.MenuItem_ResistanceCompensation.Checked = this.gLineTestProcessor.bResistanceCompFlag;
					int iAPSFlag = System.Convert.ToInt32(tempAPSStr);
					if (iAPSFlag == 1)
					{
						this.MenuItem_AuxiliaryPowerSupply.Checked = true;
					}
					else
					{
						this.MenuItem_AuxiliaryPowerSupply.Checked = false;
					}
					this.gLineTestProcessor.bAuxPowerSupplyFlag = this.MenuItem_AuxiliaryPowerSupply.Checked;
					try
					{
						string sqlcommand = "select top 1 * from TResistanceCompensation";
						OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						if (dataReader.Read())
						{
							bBCRFlag = true;
						}
						dataReader.Close();
						dataReader = null;
						if (!bBCRFlag)
						{
							for (int i = 1; i <= this.gLineTestProcessor.SELF_MAX_COUNT; i++)
							{
								sqlcommand = "insert into TResistanceCompensation(PinNum,CompensationValue) values(" + i + ",0)";
								cmd = new OleDbCommand(sqlcommand, connection);
								cmd.ExecuteNonQuery();
							}
						}
					}
					catch (System.Exception arg_2C5_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_2C5_0.StackTrace);
						if (dataReader != null)
						{
							dataReader.Close();
							dataReader = null;
						}
					}
					try
					{
						string sqlcommand = "select top 1 * from TIAndRTPinReletionData";
						OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						if (dataReader.Read())
						{
							bExistFlag = true;
						}
						dataReader.Close();
						dataReader = null;
						if (!bExistFlag)
						{
							for (int j = 1; j <= this.gLineTestProcessor.SELF_MAX_COUNT; j++)
							{
								string tempStr = System.Convert.ToString(j);
								sqlcommand = "insert into TIAndRTPinReletionData(TI_PinNum,AT_PinNum) values('" + tempStr + "','" + tempStr + "')";
								cmd = new OleDbCommand(sqlcommand, connection);
								cmd.ExecuteNonQuery();
							}
						}
					}
					catch (System.Exception arg_365_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_365_0.StackTrace);
						if (dataReader != null)
						{
							dataReader.Close();
							dataReader = null;
						}
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_386_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_386_0.StackTrace);
					if (dataReader != null)
					{
						dataReader.Close();
						dataReader = null;
					}
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
			}
			catch (System.Exception arg_3AA_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3AA_0.StackTrace);
			}
		}
		private void ctFormMain_Load(object sender, System.EventArgs e)
		{
			try
			{
				try
				{
					if (!this.bLoginSuccFlag)
					{
						base.Close();
						return;
					}
					this.UsersRightQureyFunc();
					base.Visible = true;
					base.WindowState = FormWindowState.Maximized;
					this.timer_checkLifeTime.Enabled = true;
					this.timer_ace.Enabled = true;
				}
				catch (System.Exception arg_41_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_41_0.StackTrace);
				}
				try
				{
					string path = Application.StartupPath + "\\RBF\\";
					this.reportBackPathStr = path;
					if (!System.IO.Directory.Exists(path))
					{
						System.IO.Directory.CreateDirectory(this.reportBackPathStr);
					}
					this.panel_projectTest.Visible = false;
					this.timer_projectTest.Enabled = false;
					this.toolStripStatusLabel_csyConnStatus.Visible = true;
					this.toolStripStatusLabel_currentLoginUser.Text = "当前用户: " + this.gLineTestProcessor.loginUserID + "  ";
					this.dataGridView1.Rows.Clear();
					this.dataGridView_CommProject.Rows.Clear();
					this.pictureBox_warning.Visible = false;
				}
				catch (System.Exception arg_F8_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_F8_0.StackTrace);
				}
				try
				{
					for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
					{
						this.dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
						this.dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					}
					for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
					{
						if (this.gLineTestProcessor.iUIDisplayMode == 1)
						{
							this.dataGridView1.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
						}
						else
						{
							this.dataGridView1.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
						}
					}
					for (int k = 0; k < this.dataGridView_CommProject.Columns.Count; k++)
					{
						this.dataGridView_CommProject.Columns[k].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
						this.dataGridView_CommProject.Columns[k].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					}
					for (int l = 0; l < this.dataGridView_CommProject.Columns.Count; l++)
					{
						this.dataGridView_CommProject.Columns[l].SortMode = DataGridViewColumnSortMode.NotSortable;
					}
				}
				catch (System.Exception arg_246_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_246_0.StackTrace);
				}
				this.RefreshDGVCommProjectFunc();
				this.GetUserConfigInfoFunc();
				this.ThreadChatMonitor();
			}
			catch (System.Exception arg_266_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_266_0.StackTrace);
			}
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode == 1)
				{
					this.toolStrip1.Visible = false;
					this.MenuItem_User.Visible = false;
					this.panel_projectInfo.Visible = false;
					this.toolStripSeparator_DefaultTestParaSet.Visible = false;
					this.MenuItem_DefaultTestParaSet.Visible = false;
					this.toolStripSeparator_SwitchAccount.Visible = false;
					this.MenuItem_SwitchAccount.Visible = false;
					this.MenuItem_SingleDevice_NYTEST.Visible = false;
					this.toolStripSeparator_SingleDevice_NYTEST.Visible = false;
					this.MenuItem_SingleDevice_DRTEST.Visible = false;
					this.toolStripSeparator_SingleDevice_DRTEST.Visible = false;
					this.MenuItem_AuxiliaryPowerSupply.Checked = false;
					this.MenuItem_AuxiliaryPowerSupply.Visible = false;
					this.toolStripSeparator_AuxiliaryPowerSupply.Visible = false;
					this.toolStripSeparator_ComponentMeasure.Visible = false;
					this.MenuItem_ComponentMeasure.Visible = false;
					this.toolStripSeparator_VoltMeasure.Visible = false;
					this.MenuItem_VoltMeasure.Visible = false;
					this.toolStripSeparator_IAndRT_PinReletion.Visible = false;
					this.MenuItem_IAndRT_PinReletion.Visible = false;
					this.toolStripSeparator_AdapterCableLibManage.Visible = false;
					this.MenuItem_AdapterCableLibManage.Visible = false;
					this.gLineTestProcessor.bUseRelayBoard = false;
					this.gLineTestProcessor.bNYTestEnabled = false;
					this.gLineTestProcessor.bAuxPowerSupplyFlag = false;
					this.label_TVYCXSSet_Click(null, null);
				}
				this.loginForm = null;
				System.GC.Collect();
				System.GC.WaitForPendingFinalizers();
			}
			catch (System.Exception arg_3CE_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3CE_0.StackTrace);
			}
			try
			{
				this.InitSysControlsFunc();
				this.SetTestMenuItemVisisbleFunc(true);
			}
			catch (System.Exception arg_3EA_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3EA_0.StackTrace);
			}
		}
		public void sfMemoryFunc()
		{
			try
			{
				if (this.bIsTestStatus)
				{
					this.gLineTestProcessor.SendStopCmd();
					System.Threading.Thread.Sleep(50);
				}
				if (this.gLineTestProcessor.mpDevComm.mnCommState == KTestDevComm.CAN_COMM_READY)
				{
					this.gLineTestProcessor.mpDevComm.CloseCAN();
					System.Threading.Thread.Sleep(50);
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		private void MenuItem_Exit_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.bLoginSuccFlag)
				{
					this.bInquiryHintFlag = false;
					if (this.bIsTestStatus)
					{
						if (DialogResult.OK == MessageBox.Show("正在进行测试，您确定要退出吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
						{
							this.bInquiryHintFlag = true;
							this.sfMemoryFunc();
							base.Close();
						}
					}
					else if (DialogResult.Yes == MessageBox.Show("是否退出程序?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
					{
						this.bInquiryHintFlag = true;
						this.sfMemoryFunc();
						base.Close();
					}
				}
			}
			catch (System.Exception arg_6D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_6D_0.StackTrace);
			}
		}
		private void MenuItem_About_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormAbout this2 = new ctFormAbout();
				this.aboutForm = this2;
				this2.Activate();
				this.aboutForm.ShowDialog();
				this.aboutForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_2E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2E_0.StackTrace);
			}
		}
		private void MenuItem_EquipmentErrorQuery_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormErrorQuery this2 = new ctFormErrorQuery(this.gLineTestProcessor);
				this.errorQueryForm = this2;
				this2.Activate();
				this.errorQueryForm.ShowDialog();
				this.errorQueryForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_34_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_34_0.StackTrace);
			}
		}
		private void MenuItem_EquipmentAutoConn_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			try
			{
				if (this.MenuItem_EquipmentAutoConn.Checked)
				{
					this.MenuItem_EquipmentAutoConn.Checked = false;
				}
				else
				{
					this.MenuItem_EquipmentAutoConn.Checked = true;
				}
				byte e2 = this.MenuItem_EquipmentAutoConn.Checked ? 1 : 0;
				this.bIsAutoConnFlag = (e2 != 0);
				int iACD = 0;
				if (e2 != 0)
				{
					iACD = 1;
				}
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					new OleDbCommand("update TUserCustomCableTestPara set AutoConnDevice = " + iACD + " where LoginUser='" + this.gLineTestProcessor.loginUserID + "'", connection).ExecuteNonQuery();
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_AB_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_AB_0.StackTrace);
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
			}
			catch (System.Exception arg_C4_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_C4_0.StackTrace);
			}
		}
		private void MenuItem_ConnEquipment_Click(object sender, System.EventArgs e)
		{
			try
			{
				KLineTestProcessor this2 = this.gLineTestProcessor;
				if (this2.bEmulationMode)
				{
					this.toolStripStatusLabel_csyConnStatus.Text = "连接正常";
					MessageBox.Show("设备连接成功!", "提示", MessageBoxButtons.OK);
				}
				else if (!this2.bIsConnSuccFlag && !this2.mpDevComm.InitCAN())
				{
					this.bIsConnSuccFlag = false;
					this.gLineTestProcessor.bIsConnSuccFlag = false;
					MessageBox.Show("设备连接失败，请查看接线是否正常!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					System.Threading.Thread.Sleep(100);
					this.SendDeviceExistCmdFeedbackFunc();
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
						this.bIsConnSuccFlag = false;
						this.gLineTestProcessor.bIsConnSuccFlag = false;
						this.toolStripStatusLabel_csyConnStatus.Text = "未连接";
						MessageBox.Show("设备连接失败，请查看接线是否正常!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						this.bIsConnSuccFlag = true;
						sender2.bIsConnSuccFlag = true;
						this.toolStripStatusLabel_csyConnStatus.Text = "连接正常";
						MessageBox.Show("设备连接成功!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_122_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_122_0.StackTrace);
			}
		}
		private void MenuItem_DisConnEquipment_Click(object sender, System.EventArgs e)
		{
			try
			{
				KLineTestProcessor this2 = this.gLineTestProcessor;
				if (this2.bEmulationMode)
				{
					this.toolStripStatusLabel_csyConnStatus.Text = "未连接";
					MessageBox.Show("设备连接已断开!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					if (this.bIsTestStatus)
					{
						this2.SendStopCmd();
						System.Threading.Thread.Sleep(100);
						this.gLineTestProcessor.SendStopCmd();
						System.Threading.Thread.Sleep(100);
					}
					if (!this.gLineTestProcessor.mpDevComm.CloseCAN())
					{
						MessageBox.Show("设备连接断开失败!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						this.bIsConnSuccFlag = false;
						this.gLineTestProcessor.bIsConnSuccFlag = false;
						this.toolStripStatusLabel_csyConnStatus.Text = "未连接";
						MessageBox.Show("设备连接已断开!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_B7_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_B7_0.StackTrace);
			}
		}
		private void MenuItem_InterfaceLibManage_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormInterfaceLibrary this2 = new ctFormInterfaceLibrary(this.gLineTestProcessor);
				this.interfaceLibraryForm = this2;
				this2.Activate();
				this.interfaceLibraryForm.ShowDialog();
				this.interfaceLibraryForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_34_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_34_0.StackTrace);
			}
		}
		private void MenuItem_CableLibManage_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormCableLibrary this2 = new ctFormCableLibrary(this.gLineTestProcessor);
				this.cableLibraryForm = this2;
				this2.Activate();
				this.cableLibraryForm.ShowDialog();
				this.cableLibraryForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_34_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_34_0.StackTrace);
			}
		}
		public void UpdateDVGDataDisposeFunc()
		{
			try
			{
				this.dataGridView1.Rows.Clear();
				if (!this.bSelfStudyPinTestFlag)
				{
					int iCount = this.gLineTestProcessor.gDLPinConnectInfoArray.Count;
					if (iCount > 0)
					{
						this.dataGridView1.AllowUserToAddRows = true;
						int num;
						for (int i = 0; i < iCount; i = num)
						{
							this.dataGridView1.Rows.Add(1);
							num = i + 1;
							this.dataGridView1.Rows[i].Cells[0].Value = System.Convert.ToString(num);
							this.dataGridView1.Rows[i].Cells[1].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[i].mALJQName;
							this.dataGridView1.Rows[i].Cells[2].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[i].mnALJQPinNum;
							this.dataGridView1.Rows[i].Cells[3].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[i].mBLJQName;
							this.dataGridView1.Rows[i].Cells[4].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[i].mnBLJQPinNum;
							if (this.gLineTestProcessor.gDLPinConnectInfoArray[i].iDTTestFlag != 1)
							{
								this.dataGridView1.Rows[i].Cells[this.iDTTValueColNum].Value = ctFormMain.UN_TEST_COMM_STR;
								this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value = ctFormMain.UN_TEST_COMM_STR;
							}
							else
							{
								this.dataGridView1.Rows[i].Cells[this.iDTTValueColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[i].strDTTestValue;
								this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[i].strDTTestResult;
							}
							if (this.gLineTestProcessor.gDLPinConnectInfoArray[i].iJYTestFlag != 1)
							{
								this.dataGridView1.Rows[i].Cells[this.iJYTValueColNum].Value = ctFormMain.UN_TEST_COMM_STR;
								this.dataGridView1.Rows[i].Cells[this.iJYResultColNum].Value = ctFormMain.UN_TEST_COMM_STR;
							}
							else
							{
								this.dataGridView1.Rows[i].Cells[this.iJYTValueColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[i].strJYTestValue;
								this.dataGridView1.Rows[i].Cells[this.iJYResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[i].strJYTestResult;
							}
							if (this.gLineTestProcessor.gDLPinConnectInfoArray[i].iNYTestFlag != 1)
							{
								this.dataGridView1.Rows[i].Cells[this.iNYTValueColNum].Value = ctFormMain.UN_TEST_COMM_STR;
								this.dataGridView1.Rows[i].Cells[this.iNYResultColNum].Value = ctFormMain.UN_TEST_COMM_STR;
							}
							else
							{
								this.dataGridView1.Rows[i].Cells[this.iNYTValueColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[i].strNYTestValue;
								this.dataGridView1.Rows[i].Cells[this.iNYResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[i].strNYTestResult;
							}
						}
						this.dataGridView1.AllowUserToAddRows = false;
					}
				}
				else
				{
					int iCount2 = this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count;
					if (iCount2 > 0)
					{
						this.dataGridView1.AllowUserToAddRows = true;
						int num2;
						for (int j = 0; j < iCount2; j = num2)
						{
							this.dataGridView1.Rows.Add(1);
							num2 = j + 1;
							this.dataGridView1.Rows[j].Cells[0].Value = System.Convert.ToString(num2);
							this.dataGridView1.Rows[j].Cells[1].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j].mALJQName;
							this.dataGridView1.Rows[j].Cells[2].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j].mnALJQPinNum;
							this.dataGridView1.Rows[j].Cells[3].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j].mBLJQName;
							this.dataGridView1.Rows[j].Cells[4].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j].mnBLJQPinNum;
							KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
							if (!kLineTestProcessor.bDTTestEnabled)
							{
								this.dataGridView1.Rows[j].Cells[this.iDTTValueColNum].Value = ctFormMain.UN_TEST_COMM_STR;
								this.dataGridView1.Rows[j].Cells[this.iDTResultColNum].Value = ctFormMain.UN_TEST_COMM_STR;
							}
							else
							{
								this.dataGridView1.Rows[j].Cells[this.iDTTValueColNum].Value = kLineTestProcessor.gDLPinConnectInfoSelfArray[j].strDTTestValue;
								this.dataGridView1.Rows[j].Cells[this.iDTResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j].strDTTestResult;
							}
							KLineTestProcessor kLineTestProcessor2 = this.gLineTestProcessor;
							if (!kLineTestProcessor2.bJYTestEnabled)
							{
								this.dataGridView1.Rows[j].Cells[this.iJYTValueColNum].Value = ctFormMain.UN_TEST_COMM_STR;
								this.dataGridView1.Rows[j].Cells[this.iJYResultColNum].Value = ctFormMain.UN_TEST_COMM_STR;
							}
							else
							{
								this.dataGridView1.Rows[j].Cells[this.iJYTValueColNum].Value = kLineTestProcessor2.gDLPinConnectInfoSelfArray[j].strJYTestValue;
								this.dataGridView1.Rows[j].Cells[this.iJYResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j].strJYTestResult;
							}
							KLineTestProcessor kLineTestProcessor3 = this.gLineTestProcessor;
							if (!kLineTestProcessor3.bNYTestEnabled)
							{
								this.dataGridView1.Rows[j].Cells[this.iNYTValueColNum].Value = ctFormMain.UN_TEST_COMM_STR;
								this.dataGridView1.Rows[j].Cells[this.iNYResultColNum].Value = ctFormMain.UN_TEST_COMM_STR;
							}
							else
							{
								this.dataGridView1.Rows[j].Cells[this.iNYTValueColNum].Value = kLineTestProcessor3.gDLPinConnectInfoSelfArray[j].strNYTestValue;
								this.dataGridView1.Rows[j].Cells[this.iNYResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j].strNYTestResult;
							}
						}
						this.dataGridView1.AllowUserToAddRows = false;
					}
				}
			}
			catch (System.Exception ex)
			{
				this.dataGridView1.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
			int k = 0;
			if (0 < this.dataGridView1.Rows.Count)
			{
				do
				{
					if (this.dataGridView1.Rows[k].Cells[this.iDTResultColNum].Value != null && this.dataGridView1.Rows[k].Cells[this.iDTResultColNum].Value.ToString() == ctFormMain.TEST_NOT_QUAL_STR)
					{
						System.Drawing.Color red = System.Drawing.Color.Red;
						this.dataGridView1.Rows[k].DefaultCellStyle.BackColor = red;
					}
					if (this.dataGridView1.Rows[k].Cells[this.iJYResultColNum].Value != null && this.dataGridView1.Rows[k].Cells[this.iJYResultColNum].Value.ToString() == ctFormMain.TEST_NOT_QUAL_STR)
					{
						System.Drawing.Color red2 = System.Drawing.Color.Red;
						this.dataGridView1.Rows[k].DefaultCellStyle.BackColor = red2;
					}
					if (this.dataGridView1.Rows[k].Cells[this.iNYResultColNum].Value != null && this.dataGridView1.Rows[k].Cells[this.iNYResultColNum].Value.ToString() == ctFormMain.TEST_NOT_QUAL_STR)
					{
						System.Drawing.Color red3 = System.Drawing.Color.Red;
						this.dataGridView1.Rows[k].DefaultCellStyle.BackColor = red3;
					}
					k++;
				}
				while (k < this.dataGridView1.Rows.Count);
			}
			try
			{
				this.iHintRecordNum = this.dataGridView1.Rows.Count;
				this.iHintDTExcNum = 0;
				for (int l = 0; l < this.dataGridView1.Rows.Count; l++)
				{
					if (this.dataGridView1.Rows[l].Cells[this.iDTResultColNum].Value != null)
					{
						string tempStr = this.dataGridView1.Rows[l].Cells[this.iDTResultColNum].Value.ToString();
						if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
						{
							this.iHintDTExcNum++;
						}
					}
				}
				this.iHintDLExcNum = 0;
				KLineTestProcessor kLineTestProcessor4 = this.gLineTestProcessor;
				if (kLineTestProcessor4.gDLPinConnectInfoDLResultArray != null)
				{
					this.iHintDLExcNum = kLineTestProcessor4.gDLPinConnectInfoDLResultArray.Count;
				}
				this.iHintJYExcNum = 0;
				for (int m = 0; m < this.dataGridView1.Rows.Count; m++)
				{
					if (this.dataGridView1.Rows[m].Cells[this.iJYResultColNum].Value != null)
					{
						string tempStr = this.dataGridView1.Rows[m].Cells[this.iJYResultColNum].Value.ToString();
						if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
						{
							this.iHintJYExcNum++;
						}
					}
				}
				this.iHintDDJYExcNum = 0;
				for (int n = 0; n < this.gLineTestProcessor.gDLPinConnectInfoDDJYArray.Count; n++)
				{
					if (this.gLineTestProcessor.gDLPinConnectInfoDDJYArray[n].strDDjyTestResult == ctFormMain.TEST_NOT_QUAL_STR)
					{
						this.iHintDDJYExcNum++;
					}
				}
				this.iHintNYExcNum = 0;
				for (int i2 = 0; i2 < this.dataGridView1.Rows.Count; i2++)
				{
					if (this.dataGridView1.Rows[i2].Cells[this.iNYResultColNum].Value != null)
					{
						string tempStr = this.dataGridView1.Rows[i2].Cells[this.iNYResultColNum].Value.ToString();
						if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
						{
							this.iHintNYExcNum++;
						}
					}
				}
			}
			catch (System.Exception ex2)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex2.StackTrace);
			}
			this.RefreshHintLableFunc();
		}
		public void UpdateDVGDataSelfStudyDisposeFunc()
		{
			try
			{
				this.dataGridView1.Rows.Clear();
				int iCount = this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count;
				if (iCount <= 0)
				{
					return;
				}
				this.dataGridView1.AllowUserToAddRows = true;
				int num;
				for (int i = 0; i < iCount; i = num)
				{
					this.dataGridView1.Rows.Add(1);
					num = i + 1;
					this.dataGridView1.Rows[i].Cells[0].Value = System.Convert.ToString(num);
					this.dataGridView1.Rows[i].Cells[1].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[i].mALJQName;
					this.dataGridView1.Rows[i].Cells[2].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[i].mnALJQPinNum;
					this.dataGridView1.Rows[i].Cells[3].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[i].mBLJQName;
					this.dataGridView1.Rows[i].Cells[4].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[i].mnBLJQPinNum;
					if (!this.gLineTestProcessor.bDTTestEnabled)
					{
						this.dataGridView1.Rows[i].Cells[this.iDTTValueColNum].Value = ctFormMain.UN_TEST_COMM_STR;
						this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value = ctFormMain.UN_TEST_COMM_STR;
					}
					if (!this.gLineTestProcessor.bJYTestEnabled)
					{
						this.dataGridView1.Rows[i].Cells[this.iJYTValueColNum].Value = ctFormMain.UN_TEST_COMM_STR;
						this.dataGridView1.Rows[i].Cells[this.iJYResultColNum].Value = ctFormMain.UN_TEST_COMM_STR;
					}
					if (!this.gLineTestProcessor.bNYTestEnabled)
					{
						this.dataGridView1.Rows[i].Cells[this.iNYTValueColNum].Value = ctFormMain.UN_TEST_COMM_STR;
						this.dataGridView1.Rows[i].Cells[this.iNYResultColNum].Value = ctFormMain.UN_TEST_COMM_STR;
					}
				}
				this.dataGridView1.AllowUserToAddRows = false;
			}
			catch (System.Exception ex)
			{
				this.dataGridView1.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
			this.iHintRecordNum = this.dataGridView1.Rows.Count;
			this.iHintDTExcNum = 0;
			this.iHintDLExcNum = 0;
			this.iHintJYExcNum = 0;
			this.iHintDDJYExcNum = 0;
			this.iHintNYExcNum = 0;
			this.RefreshHintLableFunc();
		}
		public void QeuryExistMapFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			OleDbConnection connection2 = null;
			OleDbDataReader dataReader2 = null;
			try
			{
				this.bIsExistMapFlag = true;
				string noMapZJTpinStr = "";
				if (this.bSelfStudyPinTestFlag)
				{
					if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count <= 0)
					{
						return;
					}
					for (int kk = 0; kk < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; kk++)
					{
						this.gLineTestProcessor.gDLPinConnectInfoSelfArray[kk].bMainPinTHFlag = false;
						this.gLineTestProcessor.gDLPinConnectInfoSelfArray[kk].bSecPinTHFlag = false;
					}
					try
					{
						string text = "";
						string temp2Str = text;
						int iTemp = 0;
						try
						{
							connection = new OleDbConnection();
							connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
							connection.Open();
							dataReader = new OleDbCommand("select * from TIAndRTPinReletionData order by ID", connection).ExecuteReader();
							while (dataReader.Read())
							{
								string temp1Str = dataReader["TI_PinNum"].ToString();
								temp2Str = dataReader["AT_PinNum"].ToString();
								try
								{
									iTemp = System.Convert.ToInt32(temp1Str);
								}
								catch (System.Exception ex_112)
								{
									continue;
								}
								for (int i = 0; i < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; i++)
								{
									if (!this.gLineTestProcessor.gDLPinConnectInfoSelfArray[i].bMainPinTHFlag && (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[i].mnMainPinNum == iTemp && !string.IsNullOrEmpty(temp2Str))
									{
										this.gLineTestProcessor.gDLPinConnectInfoSelfArray[i].bMainPinTHFlag = true;
									}
									if (!this.gLineTestProcessor.gDLPinConnectInfoSelfArray[i].bSecPinTHFlag && (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[i].mnSecPinNum == iTemp && !string.IsNullOrEmpty(temp2Str))
									{
										this.gLineTestProcessor.gDLPinConnectInfoSelfArray[i].bSecPinTHFlag = true;
									}
								}
							}
							dataReader.Close();
							dataReader = null;
							connection.Close();
							connection = null;
						}
						catch (System.Exception arg_201_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_201_0.StackTrace);
							if (dataReader != null)
							{
								dataReader.Close();
								dataReader = null;
							}
							if (connection != null)
							{
								connection.Close();
								connection = null;
							}
						}
						for (int j = 0; j < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; j++)
						{
							if (!this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j].bMainPinTHFlag)
							{
								noMapZJTpinStr = System.Convert.ToString(this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j].mnMainPinNum);
								this.bIsExistMapFlag = false;
								break;
							}
							if (!this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j].bSecPinTHFlag)
							{
								noMapZJTpinStr = System.Convert.ToString(this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j].mnSecPinNum);
								this.bIsExistMapFlag = false;
								break;
							}
						}
						goto IL_5B0;
					}
					catch (System.Exception arg_2D3_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_2D3_0.StackTrace);
						goto IL_5B0;
					}
				}
				if (this.gLineTestProcessor.gDLPinConnectInfoArray.Count <= 0)
				{
					return;
				}
				for (int kk2 = 0; kk2 < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; kk2++)
				{
					this.gLineTestProcessor.gDLPinConnectInfoArray[kk2].bMainPinTHFlag = false;
					this.gLineTestProcessor.gDLPinConnectInfoArray[kk2].bSecPinTHFlag = false;
				}
				try
				{
					int iTemp2 = 0;
					int iTemp3 = 0;
					try
					{
						connection2 = new OleDbConnection();
						connection2.ConnectionString = this.gLineTestProcessor.dbPathStr;
						connection2.Open();
						dataReader2 = new OleDbCommand("select * from TIAndRTPinReletionData order by ID", connection2).ExecuteReader();
						while (dataReader2.Read())
						{
							string temp1Str2 = dataReader2["TI_PinNum"].ToString();
							string temp2Str2 = dataReader2["AT_PinNum"].ToString();
							try
							{
								iTemp2 = System.Convert.ToInt32(temp1Str2);
								iTemp3 = System.Convert.ToInt32(temp2Str2);
							}
							catch (System.Exception ex_3D2)
							{
								continue;
							}
							for (int k = 0; k < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; k++)
							{
								if (!this.gLineTestProcessor.gDLPinConnectInfoArray[k].bMainPinTHFlag && (int)this.gLineTestProcessor.gDLPinConnectInfoArray[k].mnMainPinNum == iTemp3)
								{
									this.gLineTestProcessor.gDLPinConnectInfoArray[k].mnMainPinNum = (ushort)iTemp2;
									this.gLineTestProcessor.gDLPinConnectInfoArray[k].bMainPinTHFlag = true;
								}
								if (!this.gLineTestProcessor.gDLPinConnectInfoArray[k].bSecPinTHFlag && (int)this.gLineTestProcessor.gDLPinConnectInfoArray[k].mnSecPinNum == iTemp3)
								{
									this.gLineTestProcessor.gDLPinConnectInfoArray[k].mnSecPinNum = (ushort)iTemp2;
									this.gLineTestProcessor.gDLPinConnectInfoArray[k].bSecPinTHFlag = true;
								}
							}
						}
						dataReader2.Close();
						dataReader2 = null;
						connection2.Close();
						connection2 = null;
					}
					catch (System.Exception arg_4DB_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_4DB_0.StackTrace);
						if (dataReader2 != null)
						{
							dataReader2.Close();
							dataReader2 = null;
						}
						if (connection2 != null)
						{
							connection2.Close();
							connection2 = null;
						}
					}
					for (int l = 0; l < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; l++)
					{
						if (!this.gLineTestProcessor.gDLPinConnectInfoArray[l].bMainPinTHFlag)
						{
							noMapZJTpinStr = System.Convert.ToString(this.gLineTestProcessor.gDLPinConnectInfoArray[l].mnMainPinNum);
							this.bIsExistMapFlag = false;
							break;
						}
						if (!this.gLineTestProcessor.gDLPinConnectInfoArray[l].bSecPinTHFlag)
						{
							noMapZJTpinStr = System.Convert.ToString(this.gLineTestProcessor.gDLPinConnectInfoArray[l].mnSecPinNum);
							this.bIsExistMapFlag = false;
							break;
						}
					}
				}
				catch (System.Exception arg_5A4_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_5A4_0.StackTrace);
				}
				IL_5B0:
				this.noMapZJTpinHintStr = "测试仪针脚号 " + noMapZJTpinStr + " 未定义，请在转接台针脚映射管理中进行定义!";
			}
			catch (System.Exception arg_5CE_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5CE_0.StackTrace);
			}
		}
		public void UpdateProjectDealwithFunc(string projectStr)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			string[] plugStrArray = null;
			try
			{
				string text = "";
				string plugNameStr = text;
				this.gLineTestProcessor.gDLPinConnectInfoArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
				System.Collections.Generic.List<int> csyPinNumList = new System.Collections.Generic.List<int>();
				System.Collections.Generic.List<int> csyMeasMethodList = new System.Collections.Generic.List<int>();
				System.Collections.Generic.List<int> measMethodList = new System.Collections.Generic.List<int>();
				System.Collections.Generic.List<string> pinNumList = new System.Collections.Generic.List<string>();
				System.Collections.Generic.List<string> pinNameList = new System.Collections.Generic.List<string>();
				System.Collections.Generic.List<string> tIPinNumList = new System.Collections.Generic.List<string>();
				System.Collections.Generic.List<string> aTPinNumList = new System.Collections.Generic.List<string>();
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "select * from TProjectInfo where ProjectName = '" + projectStr + "'";
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						this.iRunProjectID = System.Convert.ToInt32(dataReader["ID"].ToString());
						this.iTestModel = System.Convert.ToInt32(dataReader["iTestModel"].ToString());
						this.iDTTestModel = System.Convert.ToInt32(dataReader["iDTTestModel"].ToString());
						this.iJYTestModel = System.Convert.ToInt32(dataReader["iJYTestModel"].ToString());
						this.iNYTestModel = System.Convert.ToInt32(dataReader["iNYTestModel"].ToString());
						this.dDT_Threshold = System.Convert.ToDouble(dataReader["dDT_Threshold"].ToString());
						this.dDT_DTVoltage = System.Convert.ToDouble(dataReader["dDT_DTVoltage"].ToString());
						this.dDT_DTCurrent = System.Convert.ToDouble(dataReader["dDT_DTCurrent"].ToString());
						this.dJY_Threshold = System.Convert.ToDouble(dataReader["dJY_Threshold"].ToString());
						this.dJY_JYHoldTime = System.Convert.ToDouble(dataReader["dJY_JYHoldTime"].ToString());
						this.dJY_DCHighVolt = System.Convert.ToDouble(dataReader["dJY_DCHighVolt"].ToString());
						this.dJY_DCRiseTime = System.Convert.ToDouble(dataReader["dJY_DCRiseTime"].ToString());
						this.dNY_Threshold = System.Convert.ToDouble(dataReader["dNY_Threshold"].ToString());
						this.dNY_NYHoldTime = System.Convert.ToDouble(dataReader["dNY_NYHoldTime"].ToString());
						this.dNY_ACHighVolt = System.Convert.ToDouble(dataReader["dNY_ACHighVolt"].ToString());
						try
						{
							this.iGroupTestFlag = System.Convert.ToInt32(dataReader["iGroupTestFlag"].ToString());
						}
						catch (System.Exception ex_292)
						{
						}
						this.batchMumberStr = dataReader["batchMumberStr"].ToString();
						this.bcCableStr = dataReader["bcCableName"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					this.gLineTestProcessor.iTwoFourWireChoice = 2;
					if (this.iDTTestModel == 4)
					{
						this.gLineTestProcessor.iTwoFourWireChoice = 4;
					}
					this.ct_DTLimitValueStr = "≤" + System.Convert.ToString(this.dDT_Threshold) + " Ω";
					this.ct_DTVoltageStr = System.Convert.ToString(this.dDT_DTVoltage) + " VDC";
					this.ct_DTCurrentStr = System.Convert.ToString(this.dDT_DTCurrent) + " mA";
					this.ct_JYLimitValueStr = "≥" + System.Convert.ToString(this.dJY_Threshold) + " MΩ";
					this.ct_JYHoldTimeStr = System.Convert.ToString(this.dJY_JYHoldTime) + " s";
					this.ct_JYDCHighVoltStr = System.Convert.ToString(this.dJY_DCHighVolt) + " VDC";
					this.ct_JYDCRiseTimeStr = System.Convert.ToString(this.dJY_DCRiseTime) + " s";
					this.ct_NYLimitValueStr = "≤" + System.Convert.ToString(this.dNY_Threshold) + " mA";
					this.ct_NYHoldTimeStr = System.Convert.ToString(this.dNY_NYHoldTime) + " s";
					this.ct_NYACHighVoltStr = System.Convert.ToString(this.dNY_ACHighVolt) + " VAC";
					sqlcommand = "select * from TLineStructLibrary where LineStructName = '" + this.bcCableStr + "'";
					cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						this.bcCableIDStr = dataReader["LID"].ToString();
						this.bcPlugInfoStr = dataReader["PlugInfo"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					sqlcommand = "select * from TLineStructLibraryDetail where LID='" + this.bcCableIDStr + "' order by LDID";
					cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					while (dataReader.Read())
					{
						SDLPinConnectInfo tempSDLPinConnectInfo = new SDLPinConnectInfo();
						tempSDLPinConnectInfo.mALJQName = dataReader["PlugName1"].ToString();
						tempSDLPinConnectInfo.mnALJQPinNum = dataReader["PinName1"].ToString();
						tempSDLPinConnectInfo.mBLJQName = dataReader["PlugName2"].ToString();
						tempSDLPinConnectInfo.mnBLJQPinNum = dataReader["PinName2"].ToString();
						int iTemp = System.Convert.ToInt32(dataReader["IsGround"].ToString());
						tempSDLPinConnectInfo.mnAPinIsGround = iTemp;
						tempSDLPinConnectInfo.mnBPinIsGround = iTemp;
						iTemp = System.Convert.ToInt32(dataReader["IsTestDT"].ToString());
						if (this.gLineTestProcessor.bDTTestEnabled && iTemp == 1)
						{
							tempSDLPinConnectInfo.iDTTestFlag = 1;
						}
						else
						{
							tempSDLPinConnectInfo.iDTTestFlag = 0;
						}
						iTemp = System.Convert.ToInt32(dataReader["IsTestDL"].ToString());
						if (this.gLineTestProcessor.bDLTestEnabled && iTemp == 1)
						{
							tempSDLPinConnectInfo.iDLTestFlag = 1;
						}
						else
						{
							tempSDLPinConnectInfo.iDLTestFlag = 0;
						}
						iTemp = System.Convert.ToInt32(dataReader["IsTestJY"].ToString());
						if (this.gLineTestProcessor.bJYTestEnabled && iTemp == 1)
						{
							tempSDLPinConnectInfo.iJYTestFlag = 1;
						}
						else
						{
							tempSDLPinConnectInfo.iJYTestFlag = 0;
						}
						iTemp = System.Convert.ToInt32(dataReader["IsTestDDJY"].ToString());
						if (this.gLineTestProcessor.bDDJYTestEnabled && iTemp == 1)
						{
							tempSDLPinConnectInfo.iDDJYTestFlag = 1;
						}
						else
						{
							tempSDLPinConnectInfo.iDDJYTestFlag = 0;
						}
						iTemp = System.Convert.ToInt32(dataReader["IsTestNY"].ToString());
						if (this.gLineTestProcessor.bNYTestEnabled && iTemp == 1)
						{
							tempSDLPinConnectInfo.iNYTestFlag = 1;
						}
						else
						{
							tempSDLPinConnectInfo.iNYTestFlag = 0;
						}
						if (this.gLineTestProcessor.bDTTestEnabled && tempSDLPinConnectInfo.iDTTestFlag == 1)
						{
							tempSDLPinConnectInfo.strDTTestValue = "";
							tempSDLPinConnectInfo.strDTTestResult = "";
						}
						else
						{
							tempSDLPinConnectInfo.strDTTestValue = ctFormMain.UN_TEST_COMM_STR;
							tempSDLPinConnectInfo.strDTTestResult = ctFormMain.UN_TEST_COMM_STR;
						}
						if (this.gLineTestProcessor.bJYTestEnabled && tempSDLPinConnectInfo.iJYTestFlag == 1)
						{
							tempSDLPinConnectInfo.strJYTestValue = "";
							tempSDLPinConnectInfo.strJYTestResult = "";
						}
						else
						{
							tempSDLPinConnectInfo.strJYTestValue = ctFormMain.UN_TEST_COMM_STR;
							tempSDLPinConnectInfo.strJYTestResult = ctFormMain.UN_TEST_COMM_STR;
						}
						if (this.gLineTestProcessor.bNYTestEnabled && tempSDLPinConnectInfo.iNYTestFlag == 1)
						{
							tempSDLPinConnectInfo.strNYTestValue = "";
							tempSDLPinConnectInfo.strNYTestResult = "";
						}
						else
						{
							tempSDLPinConnectInfo.strNYTestValue = ctFormMain.UN_TEST_COMM_STR;
							tempSDLPinConnectInfo.strNYTestResult = ctFormMain.UN_TEST_COMM_STR;
						}
						this.gLineTestProcessor.gDLPinConnectInfoArray.Add(tempSDLPinConnectInfo);
					}
					dataReader.Close();
					dataReader = null;
					if (this.gLineTestProcessor.bUseRelayBoard)
					{
						sqlcommand = "select * from TIAndRTPinReletionData order by ID";
						cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						while (dataReader.Read())
						{
							string temp1Str = dataReader["TI_PinNum"].ToString();
							string temp2Str = dataReader["AT_PinNum"].ToString();
							if (!string.IsNullOrEmpty(temp1Str) && !string.IsNullOrEmpty(temp2Str))
							{
								tIPinNumList.Add(temp1Str);
								aTPinNumList.Add(temp2Str);
							}
						}
						dataReader.Close();
						dataReader = null;
					}
					char[] separator = new char[]
					{
						','
					};
					plugStrArray = this.bcPlugInfoStr.Split(separator);
					for (int ii = 0; ii < plugStrArray.Length; ii++)
					{
						plugNameStr = plugStrArray[ii];
						if (!string.IsNullOrEmpty(plugNameStr))
						{
							string tempPIDStr = "";
							sqlcommand = "select * from TPlugLibrary where PlugNo='" + plugNameStr + "'";
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							if (dataReader.Read())
							{
								tempPIDStr = dataReader["PID"].ToString();
							}
							dataReader.Close();
							dataReader = null;
							if (!string.IsNullOrEmpty(tempPIDStr))
							{
								csyPinNumList.Clear();
								csyMeasMethodList.Clear();
								measMethodList.Clear();
								pinNumList.Clear();
								pinNameList.Clear();
								sqlcommand = "select * from TPlugLibraryDetail where PID='" + tempPIDStr + "' order by PDID";
								cmd = new OleDbCommand(sqlcommand, connection);
								dataReader = cmd.ExecuteReader();
								while (dataReader.Read())
								{
									try
									{
										string temp1Str = dataReader["PinName"].ToString();
										string temp2Str = dataReader["DevicePinNum"].ToString();
										int iTemp = System.Convert.ToInt32(dataReader["MeasuringMethod"].ToString());
										pinNameList.Add(temp1Str);
										pinNumList.Add(temp2Str);
										measMethodList.Add(iTemp);
									}
									catch (System.Exception ex)
									{
										KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
									}
								}
								dataReader.Close();
								dataReader = null;
								if (pinNameList.Count != 0 && pinNumList.Count != 0 && measMethodList.Count != 0)
								{
									if (this.gLineTestProcessor.bUseRelayBoard)
									{
										for (int i = 0; i < pinNumList.Count; i++)
										{
											char[] separator2 = new char[]
											{
												','
											};
											string[] devPinStrArray = pinNumList[i].Split(separator2);
											for (int j = 0; j < aTPinNumList.Count; j++)
											{
												if (devPinStrArray[0] == aTPinNumList[j])
												{
													csyPinNumList.Add(System.Convert.ToInt32(tIPinNumList[j]));
													csyMeasMethodList.Add(measMethodList[i]);
													break;
												}
											}
										}
										for (int jj = 0; jj < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; jj++)
										{
											for (int kk = 0; kk < pinNameList.Count; kk++)
											{
												if (plugNameStr == this.gLineTestProcessor.gDLPinConnectInfoArray[jj].mALJQName && pinNameList[kk] == this.gLineTestProcessor.gDLPinConnectInfoArray[jj].mnALJQPinNum)
												{
													ushort mnMainPinNum = (ushort)csyPinNumList[kk];
													this.gLineTestProcessor.gDLPinConnectInfoArray[jj].mnMainPinNum = mnMainPinNum;
													this.gLineTestProcessor.gDLPinConnectInfoArray[jj].iAMeasMethod = csyMeasMethodList[kk];
												}
												if (plugNameStr == this.gLineTestProcessor.gDLPinConnectInfoArray[jj].mBLJQName && pinNameList[kk] == this.gLineTestProcessor.gDLPinConnectInfoArray[jj].mnBLJQPinNum)
												{
													ushort mnSecPinNum = (ushort)csyPinNumList[kk];
													this.gLineTestProcessor.gDLPinConnectInfoArray[jj].mnSecPinNum = mnSecPinNum;
													this.gLineTestProcessor.gDLPinConnectInfoArray[jj].iBMeasMethod = csyMeasMethodList[kk];
												}
											}
										}
									}
									else
									{
										for (int jj2 = 0; jj2 < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; jj2++)
										{
											for (int kk2 = 0; kk2 < pinNameList.Count; kk2++)
											{
												if (plugNameStr == this.gLineTestProcessor.gDLPinConnectInfoArray[jj2].mALJQName && pinNameList[kk2] == this.gLineTestProcessor.gDLPinConnectInfoArray[jj2].mnALJQPinNum)
												{
													char[] separator3 = new char[]
													{
														','
													};
													string[] devPinStrArray = pinNumList[kk2].Split(separator3);
													ushort mnMainPinNum2 = (ushort)System.Convert.ToInt32(devPinStrArray[0]);
													this.gLineTestProcessor.gDLPinConnectInfoArray[jj2].mnMainPinNum = mnMainPinNum2;
													this.gLineTestProcessor.gDLPinConnectInfoArray[jj2].iAMeasMethod = measMethodList[kk2];
												}
												if (plugNameStr == this.gLineTestProcessor.gDLPinConnectInfoArray[jj2].mBLJQName && pinNameList[kk2] == this.gLineTestProcessor.gDLPinConnectInfoArray[jj2].mnBLJQPinNum)
												{
													char[] separator4 = new char[]
													{
														','
													};
													string[] devPinStrArray = pinNumList[kk2].Split(separator4);
													ushort mnSecPinNum2 = (ushort)System.Convert.ToInt32(devPinStrArray[0]);
													this.gLineTestProcessor.gDLPinConnectInfoArray[jj2].mnSecPinNum = mnSecPinNum2;
													this.gLineTestProcessor.gDLPinConnectInfoArray[jj2].iBMeasMethod = measMethodList[kk2];
												}
											}
										}
									}
								}
							}
						}
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception ex2)
				{
					KLineTestProcessor.ExceptionRecordFunc(ex2.StackTrace);
					if (dataReader != null)
					{
						dataReader.Close();
						dataReader = null;
					}
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
				csyPinNumList.Clear();
				measMethodList.Clear();
				pinNumList.Clear();
				pinNameList.Clear();
				tIPinNumList.Clear();
				aTPinNumList.Clear();
			}
			catch (System.Exception ex3)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex3.StackTrace);
			}
		}
		public void UpdateTreeViewDealwithFunc(string projectStr)
		{
			try
			{
				if (!string.IsNullOrEmpty(projectStr))
				{
					this.treeView_projectInfo.Nodes.Clear();
					TreeNode tn = new TreeNode();
					TreeNode temptn = new TreeNode();
					TreeNode temp2tn = new TreeNode();
					tn = new TreeNode(projectStr, 0, 0);
					this.treeView_projectInfo.Nodes.Add(tn);
					tn = new TreeNode(this.proTreeStrArray[0], 1, 1);
					tn.Name = "TreeNode_Index0";
					temptn = this.treeView_projectInfo.Nodes[0];
					temptn.Nodes.Add(tn);
					temp2tn = temptn.Nodes[0];
					tn = new TreeNode(this.proTreeStrArray[1], 2, 2);
					tn.Name = "TreeNode_Index0_1";
					temp2tn.Nodes.Add(tn);
					if (this.gLineTestProcessor.bUseRelayBoard)
					{
						tn = new TreeNode(this.proTreeStrArray[3], 5, 5);
						tn.Name = "TreeNode_Index0_3";
						temp2tn.Nodes.Add(tn);
					}
					tn = new TreeNode(this.proTreeStrArray[4], 4, 4);
					tn.Name = "TreeNode_Index1";
					temptn.Nodes.Add(tn);
					temp2tn = temptn.Nodes[1];
					tn = new TreeNode(this.proTreeStrArray[5], 5, 5);
					tn.Name = "TreeNode_Index1_1";
					temp2tn.Nodes.Add(tn);
					tn = new TreeNode(this.proTreeStrArray[15], 15, 15);
					tn.Name = "TreeNode_Index4";
					temptn.Nodes.Add(tn);
					temp2tn = temptn.Nodes[2];
					tn = new TreeNode(this.proTreeStrArray[16], 16, 16);
					tn.Name = "TreeNode_Index4_1";
					temp2tn.Nodes.Add(tn);
					this.treeView_projectInfo.ExpandAll();
				}
			}
			catch (System.Exception arg_1BB_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1BB_0.StackTrace);
			}
		}
		public void GetJYNYValidRelaCountFunc(System.Collections.Generic.List<SDLPinConnectInfo> gPinConnInfoArr)
		{
			this.iJYTestRelaCount = 0;
			this.iNYTestRelaCount = 0;
			this.gLineTestProcessor.mJYTestValueArray = new System.Collections.Generic.List<JYNYTestStruct>();
			this.gLineTestProcessor.mNYTestValueArray = new System.Collections.Generic.List<JYNYTestStruct>();
			if (gPinConnInfoArr != null && gPinConnInfoArr.Count > 1)
			{
				try
				{
					System.Collections.Generic.List<JYNYTestStruct> vecArray = new System.Collections.Generic.List<JYNYTestStruct>();
					System.Collections.Generic.List<JYNYTestStruct> vecArray2 = new System.Collections.Generic.List<JYNYTestStruct>();
					for (int i = 0; i < gPinConnInfoArr.Count; i++)
					{
						if (gPinConnInfoArr[i].iJYTestFlag == 1)
						{
							JYNYTestStruct vecTemp = new JYNYTestStruct();
							if (vecArray.Count <= 0)
							{
								vecTemp.mPinName = gPinConnInfoArr[i].mALJQName;
								vecTemp.mPinNumber = gPinConnInfoArr[i].mnALJQPinNum;
								vecArray.Add(vecTemp);
							}
							else
							{
								string temp1Str = gPinConnInfoArr[i].mALJQName;
								string temp2Str = gPinConnInfoArr[i].mnALJQPinNum;
								bool bExistFlag = false;
								for (int j = 0; j < vecArray.Count; j++)
								{
									if (temp1Str == vecArray[j].mPinName && temp2Str == vecArray[j].mPinNumber)
									{
										goto IL_161;
									}
								}
								if (!bExistFlag)
								{
									vecTemp.mPinName = temp1Str;
									vecTemp.mPinNumber = temp2Str;
									vecArray.Add(vecTemp);
								}
							}
						}
						IL_161:
						if (gPinConnInfoArr[i].iNYTestFlag == 1)
						{
							JYNYTestStruct vecTemp2 = new JYNYTestStruct();
							if (vecArray2.Count <= 0)
							{
								vecTemp2.mPinName = gPinConnInfoArr[i].mALJQName;
								vecTemp2.mPinNumber = gPinConnInfoArr[i].mnALJQPinNum;
								vecArray2.Add(vecTemp2);
							}
							else
							{
								string temp1Str = gPinConnInfoArr[i].mALJQName;
								string temp2Str = gPinConnInfoArr[i].mnALJQPinNum;
								bool bExistFlag = false;
								for (int k = 0; k < vecArray2.Count; k++)
								{
									if (temp1Str == vecArray2[k].mPinName && temp2Str == vecArray2[k].mPinNumber)
									{
										goto IL_238;
									}
								}
								if (!bExistFlag)
								{
									vecTemp2.mPinName = temp1Str;
									vecTemp2.mPinNumber = temp2Str;
									vecArray2.Add(vecTemp2);
								}
							}
						}
						IL_238:;
					}
					for (int j2 = 0; j2 < vecArray.Count; j2++)
					{
						string temp1Str = vecArray[j2].mPinName;
						string temp2Str = vecArray[j2].mPinNumber;
						int iNumCount = 0;
						for (int i2 = 0; i2 < gPinConnInfoArr.Count; i2++)
						{
							string temp3Str = gPinConnInfoArr[i2].mALJQName;
							string temp4Str = gPinConnInfoArr[i2].mnALJQPinNum;
							if (temp1Str == temp3Str && temp2Str == temp4Str)
							{
								iNumCount++;
							}
						}
						if (iNumCount > 1)
						{
							vecArray[j2].bExistSameFlag = true;
						}
					}
					for (int j3 = 0; j3 < vecArray.Count; j3++)
					{
						string temp1Str = vecArray[j3].mPinName;
						string temp2Str = vecArray[j3].mPinNumber;
						for (int i3 = 0; i3 < gPinConnInfoArr.Count; i3++)
						{
							string temp3Str = gPinConnInfoArr[i3].mBLJQName;
							string temp4Str = gPinConnInfoArr[i3].mnBLJQPinNum;
							if (temp1Str == temp3Str && temp2Str == temp4Str)
							{
								string temp5Str = gPinConnInfoArr[i3].mALJQName;
								string temp6Str = gPinConnInfoArr[i3].mnALJQPinNum;
								for (int k2 = j3 + 1; k2 < vecArray.Count; k2++)
								{
									temp1Str = vecArray[k2].mPinName;
									temp2Str = vecArray[k2].mPinNumber;
									if (temp1Str == temp5Str && temp2Str == temp6Str)
									{
										System.Collections.Generic.List<JYNYTestStruct> expr_3B0 = vecArray;
										expr_3B0.Remove(expr_3B0[k2]);
										break;
									}
								}
								break;
							}
						}
					}
					for (int j4 = 0; j4 < vecArray2.Count; j4++)
					{
						string temp1Str = vecArray2[j4].mPinName;
						string temp2Str = vecArray2[j4].mPinNumber;
						int iNumCount = 0;
						for (int i4 = 0; i4 < gPinConnInfoArr.Count; i4++)
						{
							string temp3Str = gPinConnInfoArr[i4].mALJQName;
							string temp4Str = gPinConnInfoArr[i4].mnALJQPinNum;
							if (temp1Str == temp3Str && temp2Str == temp4Str)
							{
								iNumCount++;
							}
						}
						if (iNumCount > 1)
						{
							vecArray2[j4].bExistSameFlag = true;
						}
					}
					for (int j5 = 0; j5 < vecArray2.Count; j5++)
					{
						string temp1Str = vecArray2[j5].mPinName;
						string temp2Str = vecArray2[j5].mPinNumber;
						for (int i5 = 0; i5 < gPinConnInfoArr.Count; i5++)
						{
							string temp3Str = gPinConnInfoArr[i5].mBLJQName;
							string temp4Str = gPinConnInfoArr[i5].mnBLJQPinNum;
							if (temp1Str == temp3Str && temp2Str == temp4Str)
							{
								string temp5Str = gPinConnInfoArr[i5].mALJQName;
								string temp6Str = gPinConnInfoArr[i5].mnALJQPinNum;
								for (int k3 = j5 + 1; k3 < vecArray2.Count; k3++)
								{
									temp1Str = vecArray2[k3].mPinName;
									temp2Str = vecArray2[k3].mPinNumber;
									if (temp1Str == temp5Str && temp2Str == temp6Str)
									{
										System.Collections.Generic.List<JYNYTestStruct> expr_54B = vecArray2;
										expr_54B.Remove(expr_54B[k3]);
										break;
									}
								}
								break;
							}
						}
					}
					this.iJYTestRelaCount = vecArray.Count;
					this.iNYTestRelaCount = vecArray2.Count;
					for (int l = 0; l < vecArray.Count; l++)
					{
						this.gLineTestProcessor.mJYTestValueArray.Add(vecArray[l]);
					}
					for (int m = 0; m < vecArray2.Count; m++)
					{
						this.gLineTestProcessor.mNYTestValueArray.Add(vecArray2[m]);
					}
					vecArray.Clear();
					vecArray2.Clear();
					System.GC.Collect();
					System.GC.WaitForPendingFinalizers();
				}
				catch (System.Exception arg_603_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_603_0.StackTrace);
				}
			}
		}
		public void QueryValidJYNYTestNumFunc()
		{
			try
			{
				this.iJYTestRelaCount = 0;
				this.iNYTestRelaCount = 0;
				if (!this.bSelfStudyPinTestFlag)
				{
					KLineTestProcessor this2 = this.gLineTestProcessor;
					if (this2.gDLPinConnectInfoArray != null)
					{
						this.GetJYNYValidRelaCountFunc(this2.gDLPinConnectInfoArray);
					}
				}
				else
				{
					KLineTestProcessor this2 = this.gLineTestProcessor;
					if (this2.gDLPinConnectInfoSelfArray != null)
					{
						this.GetJYNYValidRelaCountFunc(this2.gDLPinConnectInfoSelfArray);
					}
				}
			}
			catch (System.Exception arg_50_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_50_0.StackTrace);
			}
		}
		public void SetTestMenuItemVisisbleFunc([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool bEnbaed)
		{
			try
			{
				if (!bEnbaed)
				{
					this.InitSysControlsFunc();
					this.toolStripSeparator_UnDefinedInterfaceTest.Visible = false;
					this.MenuItem_UnDefinedInterfaceTest.Visible = false;
				}
				else
				{
					this.toolStripSeparator_DTTEST.Visible = false;
					this.MenuItem_DTTEST.Visible = false;
					this.toolStripSeparator_DLTEST.Visible = false;
					this.MenuItem_DLTEST.Visible = false;
					this.toolStripSeparator_JYTEST.Visible = false;
					this.MenuItem_JYTEST.Visible = false;
					this.toolStripSeparator_DDJYTEST.Visible = false;
					this.MenuItem_DDJYTEST.Visible = false;
					this.toolStripSeparator_NYTEST.Visible = false;
					this.MenuItem_NYTEST.Visible = false;
					this.toolStripSeparator_SingleDevice_NYTEST.Visible = false;
					this.MenuItem_SingleDevice_NYTEST.Visible = false;
					this.toolStripSeparator_SingleDevice_DRTEST.Visible = false;
					this.MenuItem_SingleDevice_DRTEST.Visible = false;
				}
			}
			catch (System.Exception arg_D0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_D0_0.StackTrace);
			}
		}
		public void SetMenuItemControlFunc([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool bEnbaed)
		{
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode != 1)
				{
					this.MenuItem_User.Visible = bEnbaed;
				}
				byte bEnbaed2 = (!bEnbaed) ? 1 : 0;
				this.MenuItem_EmulationMode.Visible = (bEnbaed2 != 0);
				byte this2 = (!bEnbaed) ? 1 : 0;
				this.toolStripSeparator_EmulationMode.Visible = (this2 != 0);
				this.SetTestMenuItemVisisbleFunc(bEnbaed);
				this.toolStripButton_InterfaceLibManage.Enabled = bEnbaed;
				this.toolStripButton_CableLibManage.Enabled = bEnbaed;
				this.MenuItem_ConnectorLibManage.Enabled = bEnbaed;
				this.MenuItem_InterfaceLibManage.Enabled = bEnbaed;
				this.MenuItem_CableLibManage.Enabled = bEnbaed;
				this.MenuItem_IAndRT_PinReletion.Enabled = bEnbaed;
				this.MenuItem_AdapterCableLibManage.Enabled = bEnbaed;
				this.MenuItem_CreateProject.Enabled = bEnbaed;
				this.toolStripSeparator_MenuItem_CreateProject.Enabled = bEnbaed;
				this.MenuItem_OpenProject.Enabled = bEnbaed;
				this.toolStripSeparator_MenuItem_OpenProject.Enabled = bEnbaed;
				this.MenuItem_SMOpenProject.Enabled = bEnbaed;
				this.toolStripSeparator_MenuItem_SMOpenProject.Enabled = bEnbaed;
				this.toolStripButton_CreateProject.Enabled = bEnbaed;
				this.toolStripButton_OpenProject.Enabled = bEnbaed;
				if (!bEnbaed)
				{
					this.MenuItem_CurrentDLTestData.Visible = this.gLineTestProcessor.bDLTestEnabled;
					this.toolStripSeparator_CurrentDLTestData.Visible = this.gLineTestProcessor.bDLTestEnabled;
					this.MenuItem_CurrentDDJYTestData.Visible = this.gLineTestProcessor.bDDJYTestEnabled;
					this.toolStripSeparator_CurrentDDJYTestData.Visible = this.gLineTestProcessor.bDDJYTestEnabled;
				}
				else
				{
					this.MenuItem_CurrentDLTestData.Visible = false;
					this.toolStripSeparator_CurrentDLTestData.Visible = false;
					this.MenuItem_CurrentDDJYTestData.Visible = false;
					this.toolStripSeparator_CurrentDDJYTestData.Visible = false;
				}
			}
			catch (System.Exception arg_186_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_186_0.StackTrace);
			}
		}
		public void SelectGroupTestParaInfoFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray = new System.Collections.Generic.List<GroupTestParaStruct>();
				int inum = 0;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					try
					{
						KGroupTestParaInfo groupTestParaInfo = this.gLineTestProcessor.groupTestParaInfo;
						dataReader = new OleDbCommand("select * from TGroupTestParaSet where PID='" + groupTestParaInfo.strPID + "' and LID='" + groupTestParaInfo.strLID + "' order by ID asc", connection).ExecuteReader();
						while (dataReader.Read())
						{
							GroupTestParaStruct gtpStruct = new GroupTestParaStruct();
							gtpStruct.PlugName1 = dataReader["PlugName1"].ToString();
							gtpStruct.PinName1 = dataReader["PinName1"].ToString();
							gtpStruct.PlugName2 = dataReader["PlugName2"].ToString();
							gtpStruct.PinName2 = dataReader["PinName2"].ToString();
							gtpStruct.DTThreshold = dataReader["DTThreshold"].ToString();
							gtpStruct.DTVoltage = dataReader["DTVoltage"].ToString();
							gtpStruct.DTCurrent = dataReader["DTCurrent"].ToString();
							gtpStruct.JYThreshold = dataReader["JYThreshold"].ToString();
							gtpStruct.JYTestTime = dataReader["JYTestTime"].ToString();
							gtpStruct.JYVoltage = dataReader["JYVoltage"].ToString();
							gtpStruct.JYUpTime = dataReader["JYUpTime"].ToString();
							gtpStruct.NYThreshold = dataReader["NYThreshold"].ToString();
							gtpStruct.NYTestTime = dataReader["NYTestTime"].ToString();
							gtpStruct.NYVoltage = dataReader["NYVoltage"].ToString();
							this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray.Add(gtpStruct);
							inum++;
						}
						dataReader.Close();
						dataReader = null;
					}
					catch (System.Exception arg_217_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_217_0.StackTrace);
						if (dataReader != null)
						{
							dataReader.Close();
							dataReader = null;
						}
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_238_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_238_0.StackTrace);
					if (dataReader != null)
					{
						dataReader.Close();
						dataReader = null;
					}
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
			}
			catch (System.Exception arg_25C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_25C_0.StackTrace);
			}
		}
		public void GetGroupTestParaDataFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.gLineTestProcessor.groupTestParaInfo.InitVariableInfoFunc();
				this.gLineTestProcessor.groupTestParaInfo.bGroupTestFlag = false;
				if (this.iGroupTestFlag != 0)
				{
					this.gLineTestProcessor.groupTestParaInfo.bGroupTestFlag = true;
					this.gLineTestProcessor.groupTestParaInfo.strPID = System.Convert.ToString(this.iRunProjectID);
					this.gLineTestProcessor.groupTestParaInfo.strProjectName = this.testProjectNameStr;
					this.gLineTestProcessor.groupTestParaInfo.strCableName = this.bcCableStr;
					int inum = 0;
					bool bExistFlag = false;
					try
					{
						connection = new OleDbConnection();
						connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
						connection.Open();
						string sqlcommand;
						OleDbCommand cmd;
						try
						{
							sqlcommand = "select top 1 * from TLineStructLibrary where LineStructName = '" + this.gLineTestProcessor.groupTestParaInfo.strCableName + "'";
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							if (dataReader.Read())
							{
								this.gLineTestProcessor.groupTestParaInfo.strLID = dataReader["LID"].ToString();
							}
							dataReader.Close();
							dataReader = null;
						}
						catch (System.Exception arg_138_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_138_0.StackTrace);
							if (dataReader != null)
							{
								dataReader.Close();
								dataReader = null;
							}
						}
						try
						{
							KGroupTestParaInfo groupTestParaInfo = this.gLineTestProcessor.groupTestParaInfo;
							sqlcommand = "select * from TGroupTestParaSet where PID='" + groupTestParaInfo.strPID + "' and LID='" + groupTestParaInfo.strLID + "' order by ID asc";
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							while (dataReader.Read())
							{
								GroupTestParaStruct gtpStruct = new GroupTestParaStruct();
								gtpStruct.PlugName1 = dataReader["PlugName1"].ToString();
								gtpStruct.PinName1 = dataReader["PinName1"].ToString();
								gtpStruct.PlugName2 = dataReader["PlugName2"].ToString();
								gtpStruct.PinName2 = dataReader["PinName2"].ToString();
								gtpStruct.DTThreshold = dataReader["DTThreshold"].ToString();
								gtpStruct.DTVoltage = dataReader["DTVoltage"].ToString();
								gtpStruct.DTCurrent = dataReader["DTCurrent"].ToString();
								gtpStruct.JYThreshold = dataReader["JYThreshold"].ToString();
								gtpStruct.JYTestTime = dataReader["JYTestTime"].ToString();
								gtpStruct.JYVoltage = dataReader["JYVoltage"].ToString();
								gtpStruct.JYUpTime = dataReader["JYUpTime"].ToString();
								gtpStruct.NYThreshold = dataReader["NYThreshold"].ToString();
								gtpStruct.NYTestTime = dataReader["NYTestTime"].ToString();
								gtpStruct.NYVoltage = dataReader["NYVoltage"].ToString();
								this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray.Add(gtpStruct);
								inum++;
							}
							dataReader.Close();
							dataReader = null;
						}
						catch (System.Exception arg_312_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_312_0.StackTrace);
							if (dataReader != null)
							{
								dataReader.Close();
								dataReader = null;
							}
						}
						if (this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray.Count != this.gLineTestProcessor.gDLPinConnectInfoArray.Count)
						{
							bExistFlag = false;
						}
						else
						{
							int jj = 0;
							IL_35B:
							while (jj < this.gLineTestProcessor.gDLPinConnectInfoArray.Count)
							{
								string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoArray[jj].mALJQName;
								string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoArray[jj].mnALJQPinNum;
								string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoArray[jj].mBLJQName;
								string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoArray[jj].mnBLJQPinNum;
								bExistFlag = false;
								for (int kk = 0; kk < this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray.Count; kk++)
								{
									string temp5Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[kk].PlugName1;
									string temp6Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[kk].PinName1;
									string temp7Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[kk].PlugName2;
									string temp8Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[kk].PinName2;
									if (temp1Str == temp5Str && temp2Str == temp6Str && temp3Str == temp7Str && temp4Str == temp8Str)
									{
										bExistFlag = true;
										IL_4B0:
										jj++;
										goto IL_35B;
									}
								}
								if (bExistFlag)
								{
									goto IL_4B0;
								}
								goto IL_4BF;
							}
							if (bExistFlag)
							{
								goto IL_526;
							}
						}
						IL_4BF:
						this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray = new System.Collections.Generic.List<GroupTestParaStruct>();
						KGroupTestParaInfo groupTestParaInfo2 = this.gLineTestProcessor.groupTestParaInfo;
						sqlcommand = "delete from TGroupTestParaSet where PID='" + groupTestParaInfo2.strPID + "' and LID='" + groupTestParaInfo2.strLID + "'";
						cmd = new OleDbCommand(sqlcommand, connection);
						cmd.ExecuteNonQuery();
						IL_526:
						connection.Close();
						connection = null;
					}
					catch (System.Exception arg_530_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_530_0.StackTrace);
						if (dataReader != null)
						{
							dataReader.Close();
							dataReader = null;
						}
						if (connection != null)
						{
							connection.Close();
							connection = null;
						}
					}
					if (!bExistFlag && this.gLineTestProcessor.gDLPinConnectInfoArray.Count > 0)
					{
						do
						{
							MessageBox.Show("被测线束关系与分组测试参数表不一致!须重新设置分组测试参数!", "提示", MessageBoxButtons.OK);
							ctFormGroupTestParaSet ctFormGroupTestParaSet = new ctFormGroupTestParaSet(this.gLineTestProcessor, this.bcCableStr, false, this.iRunProjectID);
							this.groupTestParaSetForm = ctFormGroupTestParaSet;
							ctFormGroupTestParaSet.Activate();
							this.groupTestParaSetForm.ShowDialog();
						}
						while (!this.groupTestParaSetForm.bSubmitSuccFlag);
						this.SelectGroupTestParaInfoFunc();
					}
				}
			}
			catch (System.Exception arg_5C8_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5C8_0.StackTrace);
			}
		}
		public void OpenProjectDealwithFunc()
		{
			try
			{
				this.bSelfStudyPinTestFlag = false;
				this.bIsExistReportFlag = false;
				this.bIsSaveDataFlag = false;
				this.iDTTFFlag = 0;
				this.iDLTFFlag = 0;
				this.iJYTFFlag = 0;
				this.iDDJYTFFlag = 0;
				this.iNYTFFlag = 0;
				this.TestBeforeInitFaultInfoFunc();
				this.SetMenuItemControlFunc(false);
				this.panel_projectTest.Dock = DockStyle.Fill;
				this.panel_projectTest.Visible = true;
				this.dataGridView1.Rows.Clear();
				this.otsShowInfoStr = "项目加载中..";
				System.Drawing.Color this2 = System.Drawing.Color.SteelBlue;
				this.otsShowInfoColor = this2;
				this.RefreshOTSDisposeFunc();
				this.bReportSuccFlag = false;
				this.projectReportPathStr = "";
				this.bcPlugInfoStr = "";
				this.bExistDLFlag = false;
				this.gLineTestProcessor.gDLPinConnectInfoDLResultArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
				this.gLineTestProcessor.gDLPinConnectInfoDDJYArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
				this.UpdateTreeViewDealwithFunc(this.testProjectNameStr);
				this.UpdateProjectDealwithFunc(this.testProjectNameStr);
				this.timer_Delay.Enabled = true;
				System.GC.Collect();
				System.GC.WaitForPendingFinalizers();
			}
			catch (System.Exception arg_FF_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_FF_0.StackTrace);
			}
		}
		public void RefreshDGVCommProjectFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.dataGridView_CommProject.Rows.Clear();
				this.commonProjStrArray.Clear();
				System.Threading.Thread.Sleep(100);
				this.iCommProjectNum = 0;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select * from TProjectInfo where iCommonProject = 1 order by ID", connection).ExecuteReader();
					while (dataReader.Read())
					{
						string tempStr = dataReader["ProjectName"].ToString();
						this.commonProjStrArray.Add(tempStr);
						int num = this.iCommProjectNum + 1;
						this.iCommProjectNum = num;
						if (num >= this.gLineTestProcessor.iMaxCommonProjectNum)
						{
							break;
						}
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_BE_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_BE_0.StackTrace);
					if (dataReader != null)
					{
						dataReader.Close();
						dataReader = null;
					}
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
				this.dataGridView_CommProject.AllowUserToAddRows = true;
				for (int i = 0; i < this.iCommProjectNum; i++)
				{
					this.dataGridView_CommProject.Rows.Add(1);
					this.dataGridView_CommProject.Rows[i].Cells[0].Value = this.commonProjStrArray[i];
				}
				this.dataGridView_CommProject.AllowUserToAddRows = false;
				this.dataGridView_CommProject.Refresh();
				for (int j = 0; j < this.dataGridView_CommProject.Rows.Count; j++)
				{
					this.dataGridView_CommProject.Rows[j].Selected = false;
				}
			}
			catch (System.Exception arg_193_0)
			{
				this.dataGridView_CommProject.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_193_0.StackTrace);
			}
		}
		public void FreeSystemMemoryResourcesFunc()
		{
			try
			{
				System.GC.Collect();
				System.GC.WaitForPendingFinalizers();
			}
			catch (System.Exception arg_0C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_0C_0.StackTrace);
			}
		}
		private void MenuItem_CreateProject_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormProjectCreate this2 = new ctFormProjectCreate(this.gLineTestProcessor);
				this.createProjectForm = this2;
				this2.Activate();
				this.createProjectForm.ShowDialog();
				if (!this.createProjectForm.createSuccFlag)
				{
					this.createProjectForm = null;
					this.FreeSystemMemoryResourcesFunc();
					return;
				}
				this.RefreshDGVCommProjectFunc();
				if (!string.IsNullOrEmpty(this.createProjectForm.testProjectNameStr))
				{
					this.testProjectNameStr = this.createProjectForm.testProjectNameStr;
					this.OpenProjectDealwithFunc();
				}
				this.createProjectForm = null;
			}
			catch (System.Exception arg_79_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_79_0.StackTrace);
			}
			this.FreeSystemMemoryResourcesFunc();
		}
		private void MenuItem_OpenProject_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormProjectOpen sender2 = new ctFormProjectOpen(this.gLineTestProcessor);
				this.openProjectForm = sender2;
				sender2.Activate();
				this.openProjectForm.ShowDialog();
				this.RefreshDGVCommProjectFunc();
				ctFormProjectOpen this2 = this.openProjectForm;
				if (!this2.bOpenProjectFlag || string.IsNullOrEmpty(this2.testProjectNameStr))
				{
					this.openProjectForm = null;
					this.FreeSystemMemoryResourcesFunc();
					return;
				}
				this.testProjectNameStr = this.openProjectForm.testProjectNameStr;
				this.OpenProjectDealwithFunc();
				this.openProjectForm = null;
			}
			catch (System.Exception arg_76_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_76_0.StackTrace);
			}
			this.FreeSystemMemoryResourcesFunc();
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool QureyProjectExistFunc(string proStr)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			bool bExistFlag = false;
			try
			{
				if (string.IsNullOrEmpty(proStr))
				{
					return false;
				}
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select * from TProjectInfo where ProjectName = '" + proStr + "'", connection).ExecuteReader();
					if (dataReader.Read())
					{
						bExistFlag = true;
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_70_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_70_0.StackTrace);
					if (dataReader != null)
					{
						dataReader.Close();
						dataReader = null;
					}
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
			}
			catch (System.Exception arg_94_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_94_0.StackTrace);
			}
			return bExistFlag;
		}
		private void btnCloseProject_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.panel_projectTest.Visible = false;
				this.pictureBox_warning.Visible = false;
				this.bIsYJCSFlag = false;
				this.bChoiceTestFlag = false;
				this.bIsTestStatus = false;
				this.gLineTestProcessor.mbKeepRun = false;
				this.btnStartDTTest.Text = "导通测试";
				this.btnStartDLTest.Text = "短路测试";
				this.btnStartJYTest.Text = "绝缘测试";
				this.btnStartDDJYTest.Text = "对地绝缘测试";
				this.btnStartNYTest.Text = "耐压测试";
				this.btnYJCS.Text = "一键测试";
				this.menuStrip1.Enabled = true;
				this.toolStrip1.Enabled = true;
				this.SetMenuItemControlFunc(true);
				this.RefreshDGVCommProjectFunc();
				System.GC.Collect();
				System.GC.WaitForPendingFinalizers();
			}
			catch (System.Exception arg_CA_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_CA_0.StackTrace);
			}
		}
		private void MenuItem_CloseProject_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.btnCloseProject_Click(null, null);
			}
			catch (System.Exception arg_0A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_0A_0.StackTrace);
			}
		}
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 796;
					int ic = 0;
					int iy = 0;
					int ia = 0;
					int iys = 0;
					int ih = 0;
					if (iw > 0)
					{
						try
						{
							ia = iw / this.gLineTestProcessor.iDTJYNYTestColNum;
						}
						catch (System.Exception ex_42)
						{
							ia = iw / 10;
						}
						if (ia > 10)
						{
							ia = 10;
							try
							{
								ih = (iw - this.gLineTestProcessor.iDTJYNYTestColNum * 10) / 2;
								goto IL_8E;
							}
							catch (System.Exception ex_6D)
							{
								ih = (iw - 100) / 2;
								if (ih < 0)
								{
									ih = 0;
								}
								goto IL_8E;
							}
						}
						int expr_84 = iw;
						iys = expr_84 - expr_84 / 10 * 10;
					}
					IL_8E:
					int iTWidth = 70;
					try
					{
						int iDTJYNYTestColNum = this.gLineTestProcessor.iDTJYNYTestColNum;
						iTWidth = 700 / iDTJYNYTestColNum;
						iy = 700 - iDTJYNYTestColNum * iTWidth;
					}
					catch (System.Exception ex_B5)
					{
					}
					try
					{
						ic = (this.gLineTestProcessor.iDTJYNYTestColNum - 4) * 5 / 2;
					}
					catch (System.Exception ex_D2)
					{
					}
					int iTemp = 66;
					if (base.Width > 1024)
					{
						iTemp = iy + (iys - ic) + 73;
						iTWidth--;
					}
					else if (base.WindowState == FormWindowState.Normal)
					{
						iTemp = 62;
					}
					else if (base.WindowState == FormWindowState.Maximized)
					{
						iTemp = 56;
					}
					if (this.gLineTestProcessor.iUIDisplayMode == 1)
					{
						this.dataGridView1.Columns[0].Width = iTemp + 2;
						int width = ia + (iTWidth + ih);
						this.dataGridView1.Columns[1].Width = width;
						int num = ia + iTWidth;
						this.dataGridView1.Columns[2].Width = num;
						this.dataGridView1.Columns[3].Width = width;
						this.dataGridView1.Columns[4].Width = num;
						int width2 = num + 8;
						this.dataGridView1.Columns[5].Width = width2;
						int width3 = num - 2;
						this.dataGridView1.Columns[6].Width = width3;
						this.dataGridView1.Columns[7].Width = width2;
						this.dataGridView1.Columns[8].Width = width3;
						this.dataGridView1.Columns[9].Width = width2;
						this.dataGridView1.Columns[10].Width = width3;
					}
					else if (base.WindowState == FormWindowState.Normal)
					{
						this.dataGridView1.Columns[0].Width = iTemp + 2;
						int width4 = ia + (iTWidth + ih);
						this.dataGridView1.Columns[1].Width = width4;
						int num2 = ia + iTWidth;
						this.dataGridView1.Columns[2].Width = num2;
						this.dataGridView1.Columns[3].Width = width4;
						this.dataGridView1.Columns[4].Width = num2;
						int width5 = num2 + 8;
						this.dataGridView1.Columns[5].Width = width5;
						this.dataGridView1.Columns[6].Width = num2;
						this.dataGridView1.Columns[7].Width = width5;
						this.dataGridView1.Columns[8].Width = num2;
						this.dataGridView1.Columns[9].Width = width5;
						this.dataGridView1.Columns[10].Width = num2;
					}
					else if (base.WindowState == FormWindowState.Maximized)
					{
						this.dataGridView1.Columns[0].Width = iTemp + 2;
						int width6 = ia + (iTWidth + ih) - 12;
						this.dataGridView1.Columns[1].Width = width6;
						int num3 = ia + iTWidth;
						this.dataGridView1.Columns[2].Width = num3;
						this.dataGridView1.Columns[3].Width = width6;
						this.dataGridView1.Columns[4].Width = num3;
						int width7 = num3 + 16;
						this.dataGridView1.Columns[5].Width = width7;
						this.dataGridView1.Columns[6].Width = num3;
						this.dataGridView1.Columns[7].Width = width7;
						this.dataGridView1.Columns[8].Width = num3;
						this.dataGridView1.Columns[9].Width = width7;
						this.dataGridView1.Columns[10].Width = num3;
					}
				}
			}
			catch (System.Exception arg_4A9_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_4A9_0.StackTrace);
			}
		}
		private void panel_testData_SizeChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.SetDGVWidthSizeFunc();
				this.SetTreeViewSizeFunc();
			}
			catch (System.Exception arg_0E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_0E_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool QueryUndefinedPinFunc()
		{
			bool bExistNoKnowFlag = false;
			try
			{
				for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
				{
					string tempDGVAStr = ctFormMain.PLUGPIN_UNDEFINED_STR;
					string tempDGVBStr = ctFormMain.PLUGPIN_UNDEFINED_STR;
					string tempDGVAPinStr = ctFormMain.PLUGPIN_UNDEFINED_STR;
					string tempDGVBPinStr = ctFormMain.PLUGPIN_UNDEFINED_STR;
					if (this.dataGridView1.Rows[i].Cells[1].Value != null)
					{
						tempDGVAStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
					}
					if (this.dataGridView1.Rows[i].Cells[2].Value != null)
					{
						tempDGVAPinStr = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
					}
					if (this.dataGridView1.Rows[i].Cells[3].Value != null)
					{
						tempDGVBStr = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
					}
					if (this.dataGridView1.Rows[i].Cells[4].Value != null)
					{
						tempDGVBPinStr = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
					}
					if (tempDGVAStr == ctFormMain.PLUGPIN_UNDEFINED_STR || tempDGVBStr == ctFormMain.PLUGPIN_UNDEFINED_STR || tempDGVAPinStr == ctFormMain.PLUGPIN_UNDEFINED_STR || tempDGVBPinStr == ctFormMain.PLUGPIN_UNDEFINED_STR)
					{
						bExistNoKnowFlag = true;
						break;
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
			return bExistNoKnowFlag;
		}
		public void TestBeforeInitFaultInfoFunc()
		{
			try
			{
				this.gLineTestProcessor.mpDevComm.mParseCmd.uploadErrorDateTimeStr = "";
				this.gLineTestProcessor.mpDevComm.mParseCmd.uploadErrorContentStr = "";
				this.gLineTestProcessor.mpDevComm.mParseCmd.bUploadErrorFlag = false;
				this.bUploadErrorWarnExistFlag = false;
			}
			catch (System.Exception arg_53_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_53_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool TestIntervalDisposeFunc()
		{
			return true;
		}
		public void ResetCurrentTestDataFunc(int iType)
		{
			try
			{
				if (iType == 1)
				{
					for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
					{
						if (this.dataGridView1.Rows[i].Cells[this.iDTTValueColNum].Value == null || !(ctFormMain.UN_TEST_COMM_STR == this.dataGridView1.Rows[i].Cells[this.iDTTValueColNum].Value.ToString()))
						{
							this.dataGridView1.Rows[i].Cells[this.iDTTValueColNum].Value = "";
							this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value = "";
							if (this.dataGridView1.Rows[i].Cells[this.iJYTValueColNum].Value == null)
							{
								if (this.dataGridView1.Rows[i].Cells[this.iNYResultColNum].Value == null)
								{
									System.Drawing.Color white = System.Drawing.Color.White;
									this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = white;
								}
								else
								{
									string tempStr = this.dataGridView1.Rows[i].Cells[this.iNYResultColNum].Value.ToString();
									if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
									{
										System.Drawing.Color red = System.Drawing.Color.Red;
										this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = red;
									}
									else
									{
										System.Drawing.Color white2 = System.Drawing.Color.White;
										this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = white2;
									}
								}
							}
							else
							{
								string tempStr = this.dataGridView1.Rows[i].Cells[this.iJYResultColNum].Value.ToString();
								if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
								{
									System.Drawing.Color red2 = System.Drawing.Color.Red;
									this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = red2;
								}
								else if (this.dataGridView1.Rows[i].Cells[this.iNYResultColNum].Value == null)
								{
									System.Drawing.Color white3 = System.Drawing.Color.White;
									this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = white3;
								}
								else
								{
									tempStr = this.dataGridView1.Rows[i].Cells[this.iNYResultColNum].Value.ToString();
									if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
									{
										System.Drawing.Color red3 = System.Drawing.Color.Red;
										this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = red3;
									}
									else
									{
										System.Drawing.Color white4 = System.Drawing.Color.White;
										this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = white4;
									}
								}
							}
						}
					}
				}
				else if (iType == 2)
				{
					for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
					{
						if (this.dataGridView1.Rows[j].Cells[this.iJYTValueColNum].Value == null || !(ctFormMain.UN_TEST_COMM_STR == this.dataGridView1.Rows[j].Cells[this.iJYTValueColNum].Value.ToString()))
						{
							this.dataGridView1.Rows[j].Cells[this.iJYTValueColNum].Value = "";
							this.dataGridView1.Rows[j].Cells[this.iJYResultColNum].Value = "";
							if (this.dataGridView1.Rows[j].Cells[this.iNYTValueColNum].Value == null)
							{
								if (this.dataGridView1.Rows[j].Cells[this.iDTResultColNum].Value == null)
								{
									System.Drawing.Color white5 = System.Drawing.Color.White;
									this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = white5;
								}
								else
								{
									string tempStr = this.dataGridView1.Rows[j].Cells[this.iDTResultColNum].Value.ToString();
									if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
									{
										System.Drawing.Color red4 = System.Drawing.Color.Red;
										this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = red4;
									}
									else
									{
										System.Drawing.Color white6 = System.Drawing.Color.White;
										this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = white6;
									}
								}
							}
							else
							{
								string tempStr = this.dataGridView1.Rows[j].Cells[this.iNYResultColNum].Value.ToString();
								if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
								{
									System.Drawing.Color red5 = System.Drawing.Color.Red;
									this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = red5;
								}
								else if (this.dataGridView1.Rows[j].Cells[this.iDTResultColNum].Value == null)
								{
									System.Drawing.Color white7 = System.Drawing.Color.White;
									this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = white7;
								}
								else
								{
									tempStr = this.dataGridView1.Rows[j].Cells[this.iDTResultColNum].Value.ToString();
									if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
									{
										System.Drawing.Color red6 = System.Drawing.Color.Red;
										this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = red6;
									}
									else
									{
										System.Drawing.Color white8 = System.Drawing.Color.White;
										this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = white8;
									}
								}
							}
						}
					}
				}
				else if (iType == 3)
				{
					for (int k = 0; k < this.dataGridView1.Rows.Count; k++)
					{
						if (this.dataGridView1.Rows[k].Cells[this.iNYTValueColNum].Value == null || !(ctFormMain.UN_TEST_COMM_STR == this.dataGridView1.Rows[k].Cells[this.iNYTValueColNum].Value.ToString()))
						{
							this.dataGridView1.Rows[k].Cells[this.iNYTValueColNum].Value = "";
							this.dataGridView1.Rows[k].Cells[this.iNYResultColNum].Value = "";
							if (this.dataGridView1.Rows[k].Cells[this.iJYTValueColNum].Value == null)
							{
								if (this.dataGridView1.Rows[k].Cells[this.iDTResultColNum].Value == null)
								{
									System.Drawing.Color white9 = System.Drawing.Color.White;
									this.dataGridView1.Rows[k].DefaultCellStyle.BackColor = white9;
								}
								else
								{
									string tempStr = this.dataGridView1.Rows[k].Cells[this.iDTResultColNum].Value.ToString();
									if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
									{
										System.Drawing.Color red7 = System.Drawing.Color.Red;
										this.dataGridView1.Rows[k].DefaultCellStyle.BackColor = red7;
									}
									else
									{
										System.Drawing.Color white10 = System.Drawing.Color.White;
										this.dataGridView1.Rows[k].DefaultCellStyle.BackColor = white10;
									}
								}
							}
							else
							{
								string tempStr = this.dataGridView1.Rows[k].Cells[this.iJYResultColNum].Value.ToString();
								if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
								{
									System.Drawing.Color red8 = System.Drawing.Color.Red;
									this.dataGridView1.Rows[k].DefaultCellStyle.BackColor = red8;
								}
								else if (this.dataGridView1.Rows[k].Cells[this.iDTResultColNum].Value == null)
								{
									System.Drawing.Color white11 = System.Drawing.Color.White;
									this.dataGridView1.Rows[k].DefaultCellStyle.BackColor = white11;
								}
								else
								{
									tempStr = this.dataGridView1.Rows[k].Cells[this.iDTResultColNum].Value.ToString();
									if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
									{
										System.Drawing.Color red9 = System.Drawing.Color.Red;
										this.dataGridView1.Rows[k].DefaultCellStyle.BackColor = red9;
									}
									else
									{
										System.Drawing.Color white12 = System.Drawing.Color.White;
										this.dataGridView1.Rows[k].DefaultCellStyle.BackColor = white12;
									}
								}
							}
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool GeneralTestConditionJudgmentFunc(int iType)
		{
			try
			{
				if (string.IsNullOrEmpty(this.ct_TestCSYTypeStr) || string.IsNullOrEmpty(this.ct_TestCSYMeasureNoStr))
				{
					MessageBox.Show("试验设备信息不完整，请联系管理员进行设置!", "提示", MessageBoxButtons.OK);
					byte this2 = 0;
					return this2 != 0;
				}
				if (string.IsNullOrEmpty(this.ct_TestEnvironmentTempStr) || string.IsNullOrEmpty(this.ct_TestAmbientHumidityStr))
				{
					MessageBox.Show("当前没有设置试验环境参数，必须马上设置!", "提示", MessageBoxButtons.OK);
					this.MenuItem_TestEnvironmentParameter_Click(null, null);
				}
				if (!this.bEnvironmentParaSetFlag)
				{
					if (DialogResult.Yes == MessageBox.Show("没有设置试验环境参数，是否马上进行设置?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
					{
						this.MenuItem_TestEnvironmentParameter_Click(null, null);
					}
					if (!this.bEnvironmentParaSetFlag)
					{
						byte this2 = 0;
						return this2 != 0;
					}
				}
				if (!this.bIsExistMapFlag)
				{
					MessageBox.Show(this.noMapZJTpinHintStr, "提示", MessageBoxButtons.OK);
					byte this2 = 0;
					return this2 != 0;
				}
				KLineTestProcessor iType2 = this.gLineTestProcessor;
				if (!iType2.bEmulationMode && !iType2.bIsConnSuccFlag)
				{
					MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
					byte this2 = 0;
					return this2 != 0;
				}
				this.GetCurrentTestFlagFunc();
				if (iType == 2)
				{
					if (!this.bCurrJYTestFlag)
					{
						MessageBox.Show(this.noSeleHintStr, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						byte this2 = 0;
						return this2 != 0;
					}
					this.QueryValidJYNYTestNumFunc();
					if (this.iJYTestRelaCount < 2)
					{
						MessageBox.Show("可进行测量的芯线少于2根!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						byte this2 = 0;
						return this2 != 0;
					}
				}
				else if (iType == 3)
				{
					if (!this.bCurrNYTestFlag)
					{
						MessageBox.Show(this.noSeleHintStr, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						byte this2 = 0;
						return this2 != 0;
					}
					this.QueryValidJYNYTestNumFunc();
					if (this.iNYTestRelaCount < 2)
					{
						MessageBox.Show("可进行测量的芯线少于2根!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						byte this2 = 0;
						return this2 != 0;
					}
				}
				else if (iType == 4)
				{
					if (!this.bCurrDLTestFlag)
					{
						MessageBox.Show(this.noSeleHintStr, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						byte this2 = 0;
						return this2 != 0;
					}
				}
				else if (iType == 5 && !this.bCurrDDJYTestFlag)
				{
					MessageBox.Show(this.noSeleHintStr, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					byte this2 = 0;
					return this2 != 0;
				}
				if (!this.bSelfStudyPinTestFlag)
				{
					if (this.gLineTestProcessor.gDLPinConnectInfoArray.Count <= 0)
					{
						if (DialogResult.Yes == MessageBox.Show("未加载连接关系，是否进行自学习?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
						{
							this.MenuItem_SelfStudy_Click(null, null);
						}
						byte this2 = 0;
						return this2 != 0;
					}
					if (this.dataGridView1.Rows.Count <= 0)
					{
						this.UpdateDVGDataDisposeFunc();
					}
					if (this.QueryUndefinedPinFunc())
					{
						MessageBox.Show("当前存在未定义连接关系，不能进行测试!", "提示", MessageBoxButtons.OK);
						byte this2 = 0;
						return this2 != 0;
					}
				}
				if (!this.TestIntervalDisposeFunc())
				{
					byte this2 = 0;
					return this2 != 0;
				}
			}
			catch (System.Exception arg_263_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_263_0.StackTrace);
				return false;
			}
			this.bHVTWaitingFlag = false;
			return true;
		}
		public void PictureBoxWarningVisibleSetFunc()
		{
			try
			{
				if (this.label_TVYCXSSet.Text == "-")
				{
					if (!this.pictureBox_warning.Visible)
					{
						this.pictureBox_warning.Visible = true;
					}
				}
				else if (this.pictureBox_warning.Visible)
				{
					this.pictureBox_warning.Visible = false;
				}
			}
			catch (System.Exception arg_4D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_4D_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool GeneralTestParameterSettingFunc(int iType)
		{
			try
			{
				if (!this.GeneralTestConditionJudgmentFunc(iType))
				{
					return false;
				}
				this.gLineTestProcessor.SendStopCmd();
				System.Threading.Thread.Sleep(ctFormMain.SEND_STOP_CMD_NUM);
				if (iType == 4)
				{
					System.Threading.Thread.Sleep(200);
				}
				this.ResetCurrentTestDataFunc(iType);
				this.TestBeforeInitFaultInfoFunc();
				this.btnCreateReport.Visible = false;
				this.btnPrintReport.Visible = false;
				this.btnSaveTestData.Visible = false;
				this.btnCloseProject.Visible = false;
				this.btnStartDTTest.Visible = false;
				this.btnStartDLTest.Visible = false;
				this.btnStartJYTest.Visible = false;
				this.btnStartNYTest.Visible = false;
				this.btnStartDDJYTest.Visible = false;
				this.btnYJCS.Visible = false;
				this.treeView_projectInfo.Enabled = false;
				this.bIsTestStatus = true;
				this.bIsSaveDataFlag = false;
				this.bChoiceTestFlag = false;
				this.bIsYJCSFlag = false;
				this.progressBar_test.Value = 0;
				this.label_progress.Text = "0%";
				this.menuStrip1.Enabled = false;
				this.toolStrip1.Enabled = false;
				if (iType == 1)
				{
					this.otsShowInfoStr = "正在进行导通测试..";
					System.Drawing.Color steelBlue = System.Drawing.Color.SteelBlue;
					this.otsShowInfoColor = steelBlue;
					this.btnStartDTTest.Visible = true;
					this.btnStartDTTest.Text = "停止测试";
					this.iDTTFFlag = 1;
					this.iHintDTExcNum = 0;
				}
				else if (iType == 2)
				{
					if (!this.bCurrFastTestFlag)
					{
						this.otsShowInfoStr = "正在进行绝缘详测..（高压危险，请勿触碰）";
					}
					else
					{
						this.otsShowInfoStr = "正在进行绝缘快测..（高压危险，请勿触碰）";
					}
					System.Drawing.Color red = System.Drawing.Color.Red;
					this.otsShowInfoColor = red;
					this.btnStartJYTest.Visible = true;
					this.btnStartJYTest.Text = "停止测试";
					this.iJYTFFlag = 1;
					this.iHintJYExcNum = 0;
				}
				else if (iType == 3)
				{
					if (!this.bCurrFastTestFlag)
					{
						this.otsShowInfoStr = "正在进行耐压详测..（高压危险，请勿触碰）";
					}
					else
					{
						this.otsShowInfoStr = "正在进行耐压快测..（高压危险，请勿触碰）";
					}
					System.Drawing.Color red2 = System.Drawing.Color.Red;
					this.otsShowInfoColor = red2;
					this.btnStartNYTest.Visible = true;
					this.btnStartNYTest.Text = "停止测试";
					this.iNYTFFlag = 1;
					this.iHintNYExcNum = 0;
				}
				else if (iType == 4)
				{
					this.otsShowInfoStr = "正在进行短路测试..";
					System.Drawing.Color steelBlue2 = System.Drawing.Color.SteelBlue;
					this.otsShowInfoColor = steelBlue2;
					this.btnStartDLTest.Visible = true;
					this.btnStartDLTest.Text = "停止测试";
					this.iDLTFFlag = 1;
					this.iHintDLExcNum = 0;
					this.bExistDLFlag = false;
				}
				else if (iType == 5)
				{
					this.otsShowInfoStr = "正在进行对地绝缘测试..（高压危险，请勿触碰）";
					System.Drawing.Color red3 = System.Drawing.Color.Red;
					this.otsShowInfoColor = red3;
					this.btnStartDDJYTest.Visible = true;
					this.btnStartDDJYTest.Text = "停止测试";
					this.iDDJYTFFlag = 1;
					this.iHintDDJYExcNum = 0;
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
				return false;
			}
			if (iType == 2 || iType == 3 || iType == 5)
			{
				this.PictureBoxWarningVisibleSetFunc();
				this.gLineTestProcessor.SendQueryDeviceErrorCmd();
			}
			this.RefreshOTSDisposeFunc();
			this.RefreshHintLableFunc();
			this.gLineTestProcessor.mpDevComm.ClearTestCmdBuf();
			this.gLineTestProcessor.bIsTimeOut = false;
			this.gLineTestProcessor.mpDevComm.iEMSetTestDataIndex = 0;
			return true;
		}
		public void StartDTTestFunc()
		{
			try
			{
				if (this.GeneralTestParameterSettingFunc(1))
				{
					this.gLineTestProcessor.Par = new ParStruct(this.testProjectNameStr, this.bcCableStr, 10.0, 25, this.iDTTestModel, this.iJYTestModel, this.iNYTestModel, this.dDT_Threshold, this.dDT_DTVoltage, this.dDT_DTCurrent, this.dJY_Threshold, this.dJY_JYHoldTime, this.dJY_DCHighVolt, this.dJY_DCRiseTime, this.dNY_Threshold, this.dNY_NYHoldTime, this.dNY_ACHighVolt);
					this.gLineTestProcessor.mSendTestType = 5;
					this.gLineTestProcessor.gCurTestModal = 3;
					this.iRefreshDataCount = 0;
					this.timer_projectTest.Enabled = true;
					this.label_TVYCXSSet.Visible = false;
					this.gLineTestProcessor.iTestPreValue = 0;
					if (!this.bSelfStudyPinTestFlag)
					{
						KLineTestProcessor this2 = this.gLineTestProcessor;
						KLineTestProcessor expr_D6 = this2;
						expr_D6.StartBatchTest(expr_D6.gDLPinConnectInfoArray);
					}
					else
					{
						KLineTestProcessor this2 = this.gLineTestProcessor;
						KLineTestProcessor expr_EC = this2;
						expr_EC.StartBatchTest(expr_EC.gDLPinConnectInfoSelfArray);
					}
				}
			}
			catch (System.Exception arg_FA_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_FA_0.StackTrace);
			}
		}
		private void btnStartDTTest_Click(object sender, System.EventArgs e)
		{
			try
			{
				if ("导通测试" == this.btnStartDTTest.Text)
				{
					this.bJYTestXCDTFlag = false;
					this.bNYTestXCDTFlag = false;
					this.StartDTTestFunc();
				}
				else
				{
					this.TestFinishedDisposeFunc();
				}
			}
			catch (System.Exception arg_35_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_35_0.StackTrace);
			}
		}
		public void StartJYTestFunc()
		{
			try
			{
				if (this.GeneralTestParameterSettingFunc(2))
				{
					this.gLineTestProcessor.Par = new ParStruct(this.testProjectNameStr, this.bcCableStr, 10.0, 25, this.iDTTestModel, this.iJYTestModel, this.iNYTestModel, this.dDT_Threshold, this.dDT_DTVoltage, this.dDT_DTCurrent, this.dJY_Threshold, this.dJY_JYHoldTime, this.dJY_DCHighVolt, this.dJY_DCRiseTime, this.dNY_Threshold, this.dNY_NYHoldTime, this.dNY_ACHighVolt);
					this.gLineTestProcessor.mSendTestType = 7;
					this.gLineTestProcessor.gCurTestModal = 4;
					this.timer_projectTest.Enabled = true;
					this.gLineTestProcessor.iTestPreValue = 0;
					this.label_TVYCXSSet.Visible = false;
					if (!this.bSelfStudyPinTestFlag)
					{
						KLineTestProcessor this2 = this.gLineTestProcessor;
						if (this2.iJYTestMethod == 1)
						{
							KLineTestProcessor expr_D8 = this2;
							expr_D8.StartJYTestForData(expr_D8.gDLPinConnectInfoArray);
						}
						else if (this.bCurrFastTestFlag)
						{
							KLineTestProcessor expr_EF = this2;
							expr_EF.StartJYFastTestForData(expr_EF.gDLPinConnectInfoArray);
						}
						else
						{
							KLineTestProcessor expr_FE = this2;
							expr_FE.StartJYTestForData(expr_FE.gDLPinConnectInfoArray);
						}
					}
					else
					{
						KLineTestProcessor this2 = this.gLineTestProcessor;
						if (this2.iJYTestMethod == 1)
						{
							KLineTestProcessor expr_11D = this2;
							expr_11D.StartJYTestForData(expr_11D.gDLPinConnectInfoSelfArray);
						}
						else if (this.bCurrFastTestFlag)
						{
							KLineTestProcessor expr_134 = this2;
							expr_134.StartJYFastTestForData(expr_134.gDLPinConnectInfoSelfArray);
						}
						else
						{
							KLineTestProcessor expr_143 = this2;
							expr_143.StartJYTestForData(expr_143.gDLPinConnectInfoSelfArray);
						}
					}
				}
			}
			catch (System.Exception arg_151_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_151_0.StackTrace);
			}
		}
		private void btnStartJYTest_Click(object sender, System.EventArgs e)
		{
			try
			{
				if ("绝缘测试" == this.btnStartJYTest.Text)
				{
					int e2 = this.gLineTestProcessor.iJYTestMethod;
					if (e2 == 1)
					{
						this.bCurrFastTestFlag = false;
					}
					else if (e2 == 2 || e2 == 3)
					{
						this.bCurrFastTestFlag = true;
					}
					bool bTestedFlag = true;
					for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
					{
						string tempStr = "";
						if (this.dataGridView1.Rows[i].Cells[this.iDTTValueColNum].Value != null)
						{
							tempStr = this.dataGridView1.Rows[i].Cells[this.iDTTValueColNum].Value.ToString();
						}
						if (string.IsNullOrEmpty(tempStr))
						{
							bTestedFlag = false;
							break;
						}
					}
					this.bJYTestXCDTFlag = false;
					this.bNYTestXCDTFlag = false;
					this.btestDelayFlag = false;
					if (!bTestedFlag)
					{
						if (DialogResult.OK == MessageBox.Show(ctFormMain.NOT_DTTEST_HINT_STR, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
						{
							this.bJYTestXCDTFlag = true;
							this.btestDelayFlag = true;
							this.StartDTTestFunc();
						}
					}
					else
					{
						this.StartJYTestFunc();
					}
				}
				else
				{
					this.TestFinishedDisposeFunc();
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		public void StartNYTestFunc()
		{
			try
			{
				if (this.GeneralTestParameterSettingFunc(3))
				{
					this.gLineTestProcessor.Par = new ParStruct(this.testProjectNameStr, this.bcCableStr, 10.0, 25, this.iDTTestModel, this.iJYTestModel, this.iNYTestModel, this.dDT_Threshold, this.dDT_DTVoltage, this.dDT_DTCurrent, this.dJY_Threshold, this.dJY_JYHoldTime, this.dJY_DCHighVolt, this.dJY_DCRiseTime, this.dNY_Threshold, this.dNY_NYHoldTime, this.dNY_ACHighVolt);
					this.gLineTestProcessor.mSendTestType = 9;
					this.gLineTestProcessor.gCurTestModal = 9;
					this.timer_projectTest.Enabled = true;
					this.gLineTestProcessor.iTestPreValue = 0;
					this.label_TVYCXSSet.Visible = false;
					if (!this.bSelfStudyPinTestFlag)
					{
						KLineTestProcessor this2 = this.gLineTestProcessor;
						if (this2.iNYTestMethod == 1)
						{
							KLineTestProcessor expr_DA = this2;
							expr_DA.StartNYTestForData(expr_DA.gDLPinConnectInfoArray, this2.mSendTestType);
						}
						else if (this.bCurrFastTestFlag)
						{
							KLineTestProcessor expr_FA = this2;
							expr_FA.StartNYFastTestForData(expr_FA.gDLPinConnectInfoArray, this2.mSendTestType);
						}
						else
						{
							KLineTestProcessor expr_10F = this2;
							expr_10F.StartNYTestForData(expr_10F.gDLPinConnectInfoArray, this2.mSendTestType);
						}
					}
					else
					{
						KLineTestProcessor this2 = this.gLineTestProcessor;
						if (this2.iNYTestMethod == 1)
						{
							KLineTestProcessor expr_134 = this2;
							expr_134.StartNYTestForData(expr_134.gDLPinConnectInfoSelfArray, this2.mSendTestType);
						}
						else if (this.bCurrFastTestFlag)
						{
							KLineTestProcessor expr_151 = this2;
							expr_151.StartNYFastTestForData(expr_151.gDLPinConnectInfoSelfArray, this2.mSendTestType);
						}
						else
						{
							KLineTestProcessor expr_166 = this2;
							expr_166.StartNYTestForData(expr_166.gDLPinConnectInfoSelfArray, this2.mSendTestType);
						}
					}
				}
			}
			catch (System.Exception arg_17A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_17A_0.StackTrace);
			}
		}
		private void btnStartNYTest_Click(object sender, System.EventArgs e)
		{
			try
			{
				if ("耐压测试" == this.btnStartNYTest.Text)
				{
					int e2 = this.gLineTestProcessor.iNYTestMethod;
					if (e2 == 1)
					{
						this.bCurrFastTestFlag = false;
					}
					else if (e2 == 2 || e2 == 3)
					{
						this.bCurrFastTestFlag = true;
					}
					bool bTestedFlag = true;
					for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
					{
						string tempStr = "";
						if (this.dataGridView1.Rows[i].Cells[this.iDTTValueColNum].Value != null)
						{
							tempStr = this.dataGridView1.Rows[i].Cells[this.iDTTValueColNum].Value.ToString();
						}
						if (string.IsNullOrEmpty(tempStr))
						{
							bTestedFlag = false;
							break;
						}
					}
					this.bJYTestXCDTFlag = false;
					this.bNYTestXCDTFlag = false;
					this.btestDelayFlag = false;
					if (!bTestedFlag)
					{
						if (DialogResult.OK == MessageBox.Show(ctFormMain.NOT_DTTEST_HINT_STR, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
						{
							this.bNYTestXCDTFlag = true;
							this.btestDelayFlag = true;
							this.StartDTTestFunc();
						}
					}
					else
					{
						this.StartNYTestFunc();
					}
				}
				else
				{
					this.TestFinishedDisposeFunc();
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool GetStartStopPinFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				if (this.studyPlugStrArray == null)
				{
					return false;
				}
				System.Collections.Generic.List<int> zjtPinNumList = new System.Collections.Generic.List<int>();
				System.Collections.Generic.List<int> csyPinNumList = new System.Collections.Generic.List<int>();
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					for (int i = 0; i < this.studyPlugStrArray.Length; i++)
					{
						zjtPinNumList.Clear();
						csyPinNumList.Clear();
						string tempStr = "";
						try
						{
							string sqlcommand = "select * from TPlugLibrary where PlugNo='" + this.studyPlugStrArray[i] + "'";
							OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							if (dataReader.Read())
							{
								tempStr = dataReader["PID"].ToString();
							}
							dataReader.Close();
							dataReader = null;
						}
						catch (System.Exception arg_BF_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_BF_0.StackTrace);
							if (dataReader != null)
							{
								dataReader.Close();
								dataReader = null;
							}
						}
						if (!string.IsNullOrEmpty(tempStr))
						{
							try
							{
								string sqlcommand = "select * from TPlugLibraryDetail where PID='" + tempStr + "'";
								OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
								dataReader = cmd.ExecuteReader();
								while (dataReader.Read())
								{
									string temp1Str = dataReader["DevicePinNum"].ToString();
									if (!string.IsNullOrEmpty(temp1Str))
									{
										int iTemp = System.Convert.ToInt32(temp1Str.Split(new char[]
										{
											','
										})[0]);
										zjtPinNumList.Add(iTemp);
									}
								}
								dataReader.Close();
								dataReader = null;
							}
							catch (System.Exception arg_16D_0)
							{
								KLineTestProcessor.ExceptionRecordFunc(arg_16D_0.StackTrace);
								if (dataReader != null)
								{
									dataReader.Close();
									dataReader = null;
								}
							}
							if (this.gLineTestProcessor.bUseRelayBoard)
							{
								try
								{
									string sqlcommand = "select * from TIAndRTPinReletionData";
									OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
									dataReader = cmd.ExecuteReader();
									while (dataReader.Read())
									{
										string temp1Str = dataReader["AT_PinNum"].ToString();
										string temp2Str = dataReader["TI_PinNum"].ToString();
										if (!string.IsNullOrEmpty(temp1Str) && !string.IsNullOrEmpty(temp2Str))
										{
											int iTemp = System.Convert.ToInt32(temp1Str);
											for (int j = 0; j < zjtPinNumList.Count; j++)
											{
												if (zjtPinNumList[j] == iTemp)
												{
													iTemp = System.Convert.ToInt32(temp2Str);
													csyPinNumList.Add(iTemp);
													break;
												}
											}
										}
									}
									dataReader.Close();
									dataReader = null;
								}
								catch (System.Exception arg_23C_0)
								{
									KLineTestProcessor.ExceptionRecordFunc(arg_23C_0.StackTrace);
									if (dataReader != null)
									{
										dataReader.Close();
										dataReader = null;
									}
								}
								if (csyPinNumList.Count > 0)
								{
									int iMax = csyPinNumList[0];
									int iMin = csyPinNumList[0];
									for (int k = 0; k < csyPinNumList.Count; k++)
									{
										if (csyPinNumList[k] > iMax)
										{
											iMax = csyPinNumList[k];
										}
										if (csyPinNumList[k] < iMin)
										{
											iMin = csyPinNumList[k];
										}
									}
									this.iPlugStartPin[i] = iMin;
									this.iPlugStopPin[i] = iMax;
								}
							}
							else if (zjtPinNumList.Count > 0)
							{
								int iMax = zjtPinNumList[0];
								int iMin = zjtPinNumList[0];
								for (int l = 0; l < zjtPinNumList.Count; l++)
								{
									if (zjtPinNumList[l] > iMax)
									{
										iMax = zjtPinNumList[l];
									}
									if (zjtPinNumList[l] < iMin)
									{
										iMin = zjtPinNumList[l];
									}
								}
								this.iPlugStartPin[i] = iMin;
								this.iPlugStopPin[i] = iMax;
							}
						}
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_368_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_368_0.StackTrace);
					if (dataReader != null)
					{
						dataReader.Close();
						dataReader = null;
					}
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
			}
			catch (System.Exception arg_38C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_38C_0.StackTrace);
			}
			return true;
		}
		public string GetLineStructPlugInfoFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			string tempStr = "";
			try
			{
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select * from TLineStructLibrary where LineStructName='" + this.bcCableStr + "'", connection).ExecuteReader();
					if (dataReader.Read())
					{
						tempStr = dataReader["PlugInfo"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_78_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_78_0.StackTrace);
					if (dataReader != null)
					{
						dataReader.Close();
						dataReader = null;
					}
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
			}
			catch (System.Exception arg_9C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_9C_0.StackTrace);
			}
			return tempStr;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool DLTestDealwithFunc()
		{
			try
			{
				string tempStr = this.GetLineStructPlugInfoFunc();
				int iCount = 0;
				byte result;
				if (!string.IsNullOrEmpty(tempStr))
				{
					string[] tempHeadArray = tempStr.Split(new char[]
					{
						','
					});
					for (int i = 0; i < tempHeadArray.Length; i++)
					{
						if (!string.IsNullOrEmpty(tempHeadArray[i]))
						{
							iCount++;
						}
					}
					if (iCount > 0)
					{
						this.studyPlugStrArray = new string[iCount];
						this.iPlugStartPin = new int[iCount];
						this.iPlugStopPin = new int[iCount];
						int iIndex = 0;
						for (int j = 0; j < tempHeadArray.Length; j++)
						{
							if (!string.IsNullOrEmpty(tempHeadArray[j]))
							{
								this.studyPlugStrArray[iIndex] = tempHeadArray[j];
								iIndex++;
							}
						}
						this.GetStartStopPinFunc();
						bool flag;
						try
						{
							this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyMainPinCount = 0;
							this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyPinNum = 0;
							this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyProgress = 0;
							this.gLineTestProcessor.mpDevComm.mParseCmd.iSetSelfStudyDataRespCount = 0;
							this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyCount = 800;
							this.gLineTestProcessor.iSelfStudyThreshold = System.Convert.ToInt32(this.gLineTestProcessor.dDLThresholdCoefficient * this.dDT_Threshold);
							this.gLineTestProcessor.iPlugPinStartArray = new int[iCount];
							this.gLineTestProcessor.iPlugPinStopArray = new int[iCount];
							for (int k = 0; k < iCount; k++)
							{
								this.gLineTestProcessor.iPlugPinStartArray[k] = this.iPlugStartPin[k];
								this.gLineTestProcessor.iPlugPinStopArray[k] = this.iPlugStopPin[k];
								int iTemp = System.Math.Abs(this.iPlugStopPin[k] - this.iPlugStartPin[k]) + 1;
								KParseRepCmd mParseCmd = this.gLineTestProcessor.mpDevComm.mParseCmd;
								KParseRepCmd arg_1F2_0 = mParseCmd;
								int expr_1E8 = iTemp;
								arg_1F2_0.selfStudyCount = expr_1E8 * expr_1E8 + mParseCmd.selfStudyCount;
							}
							this.gLineTestProcessor.gCurTestModal = 7;
							this.timer_dlTest.Enabled = true;
							this.gLineTestProcessor.iTestPreValue = 0;
							this.label_TVYCXSSet.Visible = false;
							this.gLineTestProcessor.StartSelfStudyPlugModelTest();
							this.iDLTestTime = 0;
							this.iPlugPinIndex = 0;
							this.iCurrentCount = 0;
						}
						catch (System.Exception arg_257_0)
						{
							this.bIsTestStatus = false;
							KLineTestProcessor.ExceptionRecordFunc(arg_257_0.StackTrace);
							flag = false;
							goto IL_268;
						}
						return true;
						IL_268:
						result = (flag ? 1 : 0);
						return result != 0;
					}
				}
				this.gLineTestProcessor.iTestPreValue = 100;
				result = 0;
				return result != 0;
			}
			catch (System.Exception arg_275_0)
			{
				this.bIsTestStatus = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_275_0.StackTrace);
				return false;
			}
			return true;
		}
		private void btnStartDLTest_Click(object sender, System.EventArgs e)
		{
			try
			{
				if ("短路测试" == this.btnStartDLTest.Text)
				{
					if (!this.GeneralTestParameterSettingFunc(4))
					{
						return;
					}
					if (!this.GetPlugArrayInfoFunc())
					{
						MessageBox.Show("获取接口接点信息失败!", "提示", MessageBoxButtons.OK);
						return;
					}
					try
					{
						int[] sender2 = this.iPlugStartPin;
						if (sender2 != null)
						{
							int[] array = this.iPlugStopPin;
							if (array != null)
							{
								if (sender2.Length > 0 && array.Length > 0)
								{
									this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyMainPinCount = 0;
									this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyPinNum = 0;
									this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyProgress = 0;
									this.gLineTestProcessor.mpDevComm.mParseCmd.iSetSelfStudyDataRespCount = 0;
									this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyCount = 800;
									this.gLineTestProcessor.iSelfStudyThreshold = System.Convert.ToInt32(this.gLineTestProcessor.dDLThresholdCoefficient * this.dDT_Threshold);
									this.gLineTestProcessor.iPlugPinStartArray = new int[this.iPlugStartPin.Length];
									this.gLineTestProcessor.iPlugPinStopArray = new int[this.iPlugStartPin.Length];
									int i = 0;
									while (true)
									{
										sender2 = this.iPlugStartPin;
										if (i >= sender2.Length)
										{
											break;
										}
										this.gLineTestProcessor.iPlugPinStartArray[i] = sender2[i];
										this.gLineTestProcessor.iPlugPinStopArray[i] = this.iPlugStopPin[i];
										int iTemp = System.Math.Abs(this.iPlugStopPin[i] - this.iPlugStartPin[i]) + 1;
										KParseRepCmd e2 = this.gLineTestProcessor.mpDevComm.mParseCmd;
										KParseRepCmd arg_1AA_0 = e2;
										int expr_1A1 = iTemp;
										arg_1AA_0.selfStudyCount = expr_1A1 * expr_1A1 + e2.selfStudyCount;
										i++;
									}
									this.iDLTestTime = 0;
									this.iPlugPinIndex = 0;
									this.iCurrentCount = 0;
									this.gLineTestProcessor.mbKeepRun = true;
									this.gLineTestProcessor.gCurTestModal = 7;
									this.gLineTestProcessor.iTestPreValue = 0;
									this.timer_dlTest.Enabled = true;
									this.label_TVYCXSSet.Visible = false;
									this.gLineTestProcessor.StartSelfStudyPlugModelTest();
									goto IL_236;
								}
								this.TestFinishedDisposeFunc();
								return;
							}
						}
						this.TestFinishedDisposeFunc();
						return;
					}
					catch (System.Exception arg_224_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_224_0.StackTrace);
						goto IL_236;
					}
				}
				this.TestFinishedDisposeFunc();
				IL_236:;
			}
			catch (System.Exception arg_238_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_238_0.StackTrace);
			}
		}
		private void btnStartDDJYTest_Click(object sender, System.EventArgs e)
		{
			try
			{
				if ("对地绝缘测试" == this.btnStartDDJYTest.Text)
				{
					if (this.GeneralTestParameterSettingFunc(5))
					{
						this.gLineTestProcessor.Par = new ParStruct(this.testProjectNameStr, this.bcCableStr, 10.0, 25, this.iDTTestModel, this.iJYTestModel, this.iNYTestModel, this.dDT_Threshold, this.dDT_DTVoltage, this.dDT_DTCurrent, this.dJY_Threshold, this.dJY_JYHoldTime, this.dJY_DCHighVolt, this.dJY_DCRiseTime, this.dNY_Threshold, this.dNY_NYHoldTime, this.dNY_ACHighVolt);
						this.gLineTestProcessor.mSendTestType = 7;
						this.gLineTestProcessor.gCurTestModal = 20;
						this.timer_DDJYTest.Enabled = true;
						this.gLineTestProcessor.iTestPreValue = 0;
						this.label_TVYCXSSet.Visible = false;
						if (!this.bSelfStudyPinTestFlag)
						{
							KLineTestProcessor expr_E8 = this.gLineTestProcessor;
							expr_E8.StartDDJYTestForData(expr_E8.gDLPinConnectInfoArray);
						}
						else
						{
							KLineTestProcessor expr_FC = this.gLineTestProcessor;
							expr_FC.StartDDJYTestForData(expr_FC.gDLPinConnectInfoSelfArray);
						}
					}
				}
				else
				{
					this.TestFinishedDisposeFunc();
				}
			}
			catch (System.Exception arg_112_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_112_0.StackTrace);
			}
		}
		private void ctFormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (this.bLoginSuccFlag)
				{
					if (!this.bInquiryHintFlag)
					{
						if (this.bIsTestStatus)
						{
							if (DialogResult.OK == MessageBox.Show("正在进行测试，您确定要退出吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
							{
								this.bInquiryHintFlag = true;
								this.sfMemoryFunc();
							}
							else
							{
								e.Cancel = true;
							}
						}
						else if (DialogResult.Yes == MessageBox.Show("是否退出程序?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
						{
							this.bInquiryHintFlag = true;
							this.sfMemoryFunc();
						}
						else
						{
							e.Cancel = true;
						}
					}
				}
			}
			catch (System.Exception arg_79_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_79_0.StackTrace);
			}
		}
		public void GetTestDataResultStrFunc()
		{
			try
			{
				string text = "";
				string tempStr = text;
				if (!this.bSelfStudyPinTestFlag)
				{
					int gCurTestModal = this.gLineTestProcessor.gCurTestModal;
					if (gCurTestModal == 3)
					{
						for (int i = 0; i < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count; i++)
						{
							int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mMainDevPinNum;
							int iSPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mSecDevPinNum;
							for (int j = 0; j < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; j++)
							{
								if ((int)this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnMainPinNum == iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnSecPinNum == iSPinNum)
								{
									if (this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mdTestResult < 0.0)
									{
										double mdTestResult = 0.0 - this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mdTestResult;
										this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mdTestResult = mdTestResult;
									}
									double dTestValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mdTestResult;
									KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
									if (kLineTestProcessor.bResistanceCompFlag)
									{
										SDLPinConnectInfo var_57_1F2_cp_0 = kLineTestProcessor.gDLPinConnectInfoArray[j];
										dTestValue -= this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnMainCompResistance + var_57_1F2_cp_0.mnSecCompResistance;
									}
									if (this.gLineTestProcessor.gDLPinConnectInfoArray[j].iAMeasMethod == 0 && this.gLineTestProcessor.gDLPinConnectInfoArray[j].iBMeasMethod == 0)
									{
										SDLPinConnectInfo var_56_25E_cp_0 = this.gLineTestProcessor.gDLPinConnectInfoArray[j];
										dTestValue -= this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnMainInternalResistance + var_56_25E_cp_0.mnSecInternalResistance;
									}
									if (dTestValue <= 0.0)
									{
										dTestValue = 0.0;
									}
									tempStr = "";
									string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j].mALJQName;
									string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnALJQPinNum;
									string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j].mBLJQName;
									string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnBLJQPinNum;
									for (int ii = 0; ii < this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray.Count; ii++)
									{
										string temp5Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].PlugName1;
										string temp6Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].PinName1;
										string temp7Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].PlugName2;
										string temp8Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].PinName2;
										if (temp1Str == temp5Str && temp2Str == temp6Str && temp3Str == temp7Str && temp4Str == temp8Str)
										{
											tempStr = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].DTThreshold;
											break;
										}
									}
									double dTempValue;
									if (this.gLineTestProcessor.groupTestParaInfo.bGroupTestFlag && !string.IsNullOrEmpty(tempStr))
									{
										dTempValue = System.Convert.ToDouble(tempStr);
									}
									else
									{
										dTempValue = this.gLineTestProcessor.Par.dtValue;
									}
									if (dTestValue >= dTempValue)
									{
										this.gLineTestProcessor.gDLPinConnectInfoArray[j].strDTTestResult = ctFormMain.TEST_NOT_QUAL_STR;
									}
									else
									{
										this.gLineTestProcessor.gDLPinConnectInfoArray[j].strDTTestResult = ctFormMain.TEST_QUAL_STR;
									}
									string valueStr;
									if (dTestValue < 1000.0)
									{
										if (dTestValue >= 0.0)
										{
											tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
											int iTemp = tempStr.LastIndexOf('.');
											if (iTemp == -1)
											{
												tempStr += ".";
												for (int k = 0; k < 3; k++)
												{
													tempStr += "0";
												}
											}
											else
											{
												while (iTemp + 4 > tempStr.Length)
												{
													tempStr += "0";
													iTemp = tempStr.LastIndexOf('.');
												}
											}
										}
										else
										{
											tempStr = "#";
										}
										valueStr = tempStr + " Ω";
									}
									else if (dTestValue >= 1000.0 && dTestValue < 1000000.0)
									{
										dTestValue /= 1000.0;
										tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
										int iTemp = tempStr.LastIndexOf('.');
										if (iTemp == -1)
										{
											tempStr += ".";
											for (int l = 0; l < 3; l++)
											{
												tempStr += "0";
											}
										}
										else
										{
											while (iTemp + 4 > tempStr.Length)
											{
												tempStr += "0";
												iTemp = tempStr.LastIndexOf('.');
											}
										}
										valueStr = tempStr + " KΩ";
									}
									else if (dTestValue >= 1000000.0 && dTestValue <= 2500000.0)
									{
										dTestValue /= 1000000.0;
										tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
										int iTemp = tempStr.LastIndexOf('.');
										if (iTemp == -1)
										{
											tempStr += ".";
											for (int m = 0; m < 3; m++)
											{
												tempStr += "0";
											}
										}
										else
										{
											while (iTemp + 4 > tempStr.Length)
											{
												tempStr += "0";
												iTemp = tempStr.LastIndexOf('.');
											}
										}
										valueStr = tempStr + " MΩ";
									}
									else
									{
										valueStr = ">2.5 MΩ";
									}
									this.gLineTestProcessor.gDLPinConnectInfoArray[j].strDTTestValue = valueStr;
								}
							}
						}
					}
					else if (gCurTestModal == 4)
					{
						for (int n = 0; n < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count; n++)
						{
							if (!this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].bRefreshFlag)
							{
								this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].bRefreshFlag = true;
								int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].mMainDevPinNum;
								for (int j2 = 0; j2 < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; j2++)
								{
									if ((int)this.gLineTestProcessor.gDLPinConnectInfoArray[j2].mnMainPinNum == iMPinNum || (int)this.gLineTestProcessor.gDLPinConnectInfoArray[j2].mnSecPinNum == iMPinNum)
									{
										if (this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].mdTestResult < 0.0)
										{
											double mdTestResult2 = 0.0 - this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].mdTestResult;
											this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].mdTestResult = mdTestResult2;
										}
										double dTestValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].mdTestResult / 1000.0;
										tempStr = "";
										string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j2].mALJQName;
										string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j2].mnALJQPinNum;
										string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j2].mBLJQName;
										string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j2].mnBLJQPinNum;
										for (int ii2 = 0; ii2 < this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray.Count; ii2++)
										{
											string temp5Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j2].PlugName1;
											string temp6Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j2].PinName1;
											string temp7Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j2].PlugName2;
											string temp8Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j2].PinName2;
											if (temp1Str == temp5Str && temp2Str == temp6Str && temp3Str == temp7Str && temp4Str == temp8Str)
											{
												tempStr = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j2].JYThreshold;
												break;
											}
										}
										double dTempValue;
										if (this.gLineTestProcessor.groupTestParaInfo.bGroupTestFlag && !string.IsNullOrEmpty(tempStr))
										{
											dTempValue = System.Convert.ToDouble(tempStr);
										}
										else
										{
											dTempValue = this.gLineTestProcessor.Par.jyValue;
										}
										int iJYTestDataShowStyle = this.gLineTestProcessor.iJYTestDataShowStyle;
										string valueStr;
										if (iJYTestDataShowStyle == 0)
										{
											if (dTestValue < dTempValue)
											{
												this.gLineTestProcessor.gDLPinConnectInfoArray[j2].strJYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
											}
											else
											{
												valueStr = ">" + System.Convert.ToString(dTempValue) + " MΩ";
												this.gLineTestProcessor.gDLPinConnectInfoArray[j2].strJYTestResult = ctFormMain.TEST_QUAL_STR;
											}
										}
										else if (iJYTestDataShowStyle == 1)
										{
											if (dTestValue < dTempValue)
											{
												valueStr = "<" + System.Convert.ToString(dTempValue) + " MΩ";
												this.gLineTestProcessor.gDLPinConnectInfoArray[j2].strJYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
											}
											else
											{
												this.gLineTestProcessor.gDLPinConnectInfoArray[j2].strJYTestResult = ctFormMain.TEST_QUAL_STR;
											}
										}
										if (dTestValue < 1000.0)
										{
											tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
											int iTemp = tempStr.LastIndexOf('.');
											if (iTemp == -1)
											{
												tempStr += ".";
												for (int i2 = 0; i2 < 3; i2++)
												{
													tempStr += "0";
												}
											}
											else
											{
												while (iTemp + 4 > tempStr.Length)
												{
													tempStr += "0";
													iTemp = tempStr.LastIndexOf('.');
												}
											}
											valueStr = tempStr + " MΩ";
										}
										else
										{
											dTestValue /= 1000.0;
											tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
											int iTemp = tempStr.LastIndexOf('.');
											if (iTemp == -1)
											{
												tempStr += ".";
												for (int i3 = 0; i3 < 3; i3++)
												{
													tempStr += "0";
												}
											}
											else
											{
												while (iTemp + 4 > tempStr.Length)
												{
													tempStr += "0";
													iTemp = tempStr.LastIndexOf('.');
												}
											}
											valueStr = tempStr + " GΩ";
										}
										this.gLineTestProcessor.gDLPinConnectInfoArray[j2].strJYTestValue = valueStr;
									}
								}
							}
						}
					}
					else if (gCurTestModal == 9)
					{
						for (int k2 = 0; k2 < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count; k2++)
						{
							if (!this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].bRefreshFlag)
							{
								this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].bRefreshFlag = true;
								int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].mMainDevPinNum;
								for (int j3 = 0; j3 < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; j3++)
								{
									if ((int)this.gLineTestProcessor.gDLPinConnectInfoArray[j3].mnMainPinNum == iMPinNum || (int)this.gLineTestProcessor.gDLPinConnectInfoArray[j3].mnSecPinNum == iMPinNum)
									{
										if (this.gLineTestProcessor.gDLPinConnectInfoArray[j3].iNYTestFlag == 1)
										{
											if (this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].mdTestResult < 0.0)
											{
												double mdTestResult3 = 0.0 - this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].mdTestResult;
												this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].mdTestResult = mdTestResult3;
											}
											double dTestValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].mdTestResult / 1000000.0;
											tempStr = "";
											string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j3].mALJQName;
											string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j3].mnALJQPinNum;
											string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j3].mBLJQName;
											string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j3].mnBLJQPinNum;
											for (int ii3 = 0; ii3 < this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray.Count; ii3++)
											{
												string temp5Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j3].PlugName1;
												string temp6Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j3].PinName1;
												string temp7Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j3].PlugName2;
												string temp8Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j3].PinName2;
												if (temp1Str == temp5Str && temp2Str == temp6Str && temp3Str == temp7Str && temp4Str == temp8Str)
												{
													tempStr = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j3].NYThreshold;
													break;
												}
											}
											double dTempValue;
											if (this.gLineTestProcessor.groupTestParaInfo.bGroupTestFlag && !string.IsNullOrEmpty(tempStr))
											{
												dTempValue = System.Convert.ToDouble(tempStr);
											}
											else
											{
												dTempValue = this.gLineTestProcessor.Par.nyValue;
											}
											int iNYTestDataShowStyle = this.gLineTestProcessor.iNYTestDataShowStyle;
											if (iNYTestDataShowStyle == 0)
											{
												if (dTestValue >= dTempValue)
												{
													this.gLineTestProcessor.gDLPinConnectInfoArray[j3].strNYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
												}
												else
												{
													this.gLineTestProcessor.gDLPinConnectInfoArray[j3].strNYTestResult = ctFormMain.TEST_QUAL_STR;
												}
												tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
												goto IL_F9E;
											}
											if (iNYTestDataShowStyle != 1)
											{
												goto IL_F9E;
											}
											if (dTestValue >= dTempValue)
											{
												this.gLineTestProcessor.gDLPinConnectInfoArray[j3].strNYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
												tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
												goto IL_F9E;
											}
											this.gLineTestProcessor.gDLPinConnectInfoArray[j3].strNYTestResult = ctFormMain.TEST_QUAL_STR;
											string valueStr = "<" + System.Convert.ToString(dTempValue) + " mA";
											IL_1001:
											this.gLineTestProcessor.gDLPinConnectInfoArray[j3].strNYTestValue = valueStr;
											goto IL_1019;
											IL_F9E:
											int iTemp = tempStr.LastIndexOf('.');
											if (iTemp == -1)
											{
												tempStr += ".";
												for (int i4 = 0; i4 < 3; i4++)
												{
													tempStr += "0";
												}
											}
											else
											{
												while (iTemp + 4 > tempStr.Length)
												{
													tempStr += "0";
													iTemp = tempStr.LastIndexOf('.');
												}
											}
											valueStr = tempStr + " mA";
											goto IL_1001;
										}
									}
									IL_1019:;
								}
							}
						}
					}
				}
				else
				{
					int gCurTestModal = this.gLineTestProcessor.gCurTestModal;
					if (gCurTestModal == 3)
					{
						for (int k3 = 0; k3 < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count; k3++)
						{
							int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k3].mMainDevPinNum;
							int iSPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k3].mSecDevPinNum;
							for (int j4 = 0; j4 < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; j4++)
							{
								if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].mnMainPinNum == iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].mnSecPinNum == iSPinNum)
								{
									if (this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k3].mdTestResult < 0.0)
									{
										double mdTestResult4 = 0.0 - this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k3].mdTestResult;
										this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k3].mdTestResult = mdTestResult4;
									}
									double dTestValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k3].mdTestResult;
									KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
									if (kLineTestProcessor.bResistanceCompFlag)
									{
										SDLPinConnectInfo var_52_11C6_cp_0 = kLineTestProcessor.gDLPinConnectInfoSelfArray[j4];
										dTestValue -= this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].mnMainCompResistance + var_52_11C6_cp_0.mnSecCompResistance;
									}
									if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].iAMeasMethod == 0 && this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].iBMeasMethod == 0)
									{
										SDLPinConnectInfo var_51_1232_cp_0 = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4];
										dTestValue -= this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].mnMainInternalResistance + var_51_1232_cp_0.mnSecInternalResistance;
									}
									if (dTestValue <= 0.0)
									{
										dTestValue = 0.0;
									}
									if (dTestValue >= this.gLineTestProcessor.Par.dtValue)
									{
										this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].strDTTestResult = ctFormMain.TEST_NOT_QUAL_STR;
									}
									else
									{
										this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].strDTTestResult = ctFormMain.TEST_QUAL_STR;
									}
									string valueStr;
									if (dTestValue < 1000.0)
									{
										if (dTestValue >= 0.0)
										{
											tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
											int iTemp = tempStr.LastIndexOf('.');
											if (iTemp == -1)
											{
												tempStr += ".";
												for (int i5 = 0; i5 < 3; i5++)
												{
													tempStr += "0";
												}
											}
											else
											{
												while (iTemp + 4 > tempStr.Length)
												{
													tempStr += "0";
													iTemp = tempStr.LastIndexOf('.');
												}
											}
										}
										else
										{
											tempStr = "#";
										}
										valueStr = tempStr + " Ω";
									}
									else if (dTestValue >= 1000.0 && dTestValue < 1000000.0)
									{
										dTestValue /= 1000.0;
										tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
										int iTemp = tempStr.LastIndexOf('.');
										if (iTemp == -1)
										{
											tempStr += ".";
											for (int i6 = 0; i6 < 3; i6++)
											{
												tempStr += "0";
											}
										}
										else
										{
											while (iTemp + 4 > tempStr.Length)
											{
												tempStr += "0";
												iTemp = tempStr.LastIndexOf('.');
											}
										}
										valueStr = tempStr + " KΩ";
									}
									else if (dTestValue >= 1000000.0 && dTestValue <= 2500000.0)
									{
										dTestValue /= 1000000.0;
										tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
										int iTemp = tempStr.LastIndexOf('.');
										if (iTemp == -1)
										{
											tempStr += ".";
											for (int i7 = 0; i7 < 3; i7++)
											{
												tempStr += "0";
											}
										}
										else
										{
											while (iTemp + 4 > tempStr.Length)
											{
												tempStr += "0";
												iTemp = tempStr.LastIndexOf('.');
											}
										}
										valueStr = tempStr + " MΩ";
									}
									else
									{
										valueStr = ">2.5 MΩ";
									}
									this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].strDTTestValue = valueStr;
								}
							}
						}
					}
					else if (gCurTestModal == 4)
					{
						for (int k4 = 0; k4 < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count; k4++)
						{
							if (!this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k4].bRefreshFlag)
							{
								this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k4].bRefreshFlag = true;
								int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k4].mMainDevPinNum;
								for (int j5 = 0; j5 < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; j5++)
								{
									if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].mnMainPinNum == iMPinNum || (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].mnSecPinNum == iMPinNum)
									{
										if (this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k4].mdTestResult < 0.0)
										{
											double mdTestResult5 = 0.0 - this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k4].mdTestResult;
											this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k4].mdTestResult = mdTestResult5;
										}
										double dTestValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k4].mdTestResult / 1000.0;
										KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
										int iJYTestDataShowStyle = kLineTestProcessor.iJYTestDataShowStyle;
										string valueStr;
										if (iJYTestDataShowStyle == 0)
										{
											if (dTestValue < kLineTestProcessor.Par.jyValue)
											{
												this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].strJYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
											}
											else
											{
												this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].strJYTestResult = ctFormMain.TEST_QUAL_STR;
												valueStr = ">" + System.Convert.ToString(this.gLineTestProcessor.Par.jyValue) + " MΩ";
											}
										}
										else if (iJYTestDataShowStyle == 1)
										{
											if (dTestValue < kLineTestProcessor.Par.jyValue)
											{
												this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].strJYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
												valueStr = "<" + System.Convert.ToString(this.gLineTestProcessor.Par.jyValue) + " MΩ";
											}
											else
											{
												this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].strJYTestResult = ctFormMain.TEST_QUAL_STR;
											}
										}
										if (dTestValue < 1000.0)
										{
											tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
											int iTemp = tempStr.LastIndexOf('.');
											if (iTemp == -1)
											{
												tempStr += ".";
												for (int i8 = 0; i8 < 3; i8++)
												{
													tempStr += "0";
												}
											}
											else
											{
												while (iTemp + 4 > tempStr.Length)
												{
													tempStr += "0";
													iTemp = tempStr.LastIndexOf('.');
												}
											}
											valueStr = tempStr + " MΩ";
										}
										else
										{
											dTestValue /= 1000.0;
											tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
											int iTemp = tempStr.LastIndexOf('.');
											if (iTemp == -1)
											{
												tempStr += ".";
												for (int i9 = 0; i9 < 3; i9++)
												{
													tempStr += "0";
												}
											}
											else
											{
												while (iTemp + 4 > tempStr.Length)
												{
													tempStr += "0";
													iTemp = tempStr.LastIndexOf('.');
												}
											}
											valueStr = tempStr + " GΩ";
										}
										this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].strJYTestValue = valueStr;
									}
								}
							}
						}
					}
					else if (gCurTestModal == 9)
					{
						for (int k5 = 0; k5 < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count; k5++)
						{
							if (!this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k5].bRefreshFlag)
							{
								this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k5].bRefreshFlag = true;
								int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k5].mMainDevPinNum;
								for (int j6 = 0; j6 < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; j6++)
								{
									if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j6].mnMainPinNum == iMPinNum || (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j6].mnSecPinNum == iMPinNum)
									{
										if (this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k5].mdTestResult < 0.0)
										{
											double mdTestResult6 = 0.0 - this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k5].mdTestResult;
											this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k5].mdTestResult = mdTestResult6;
										}
										double dTestValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k5].mdTestResult / 1000000.0;
										KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
										int iNYTestDataShowStyle = kLineTestProcessor.iNYTestDataShowStyle;
										if (iNYTestDataShowStyle == 0)
										{
											if (dTestValue >= kLineTestProcessor.Par.nyValue)
											{
												this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j6].strNYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
											}
											else
											{
												this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j6].strNYTestResult = ctFormMain.TEST_QUAL_STR;
											}
											tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
											goto IL_1B20;
										}
										if (iNYTestDataShowStyle != 1)
										{
											goto IL_1B20;
										}
										if (dTestValue >= kLineTestProcessor.Par.nyValue)
										{
											this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j6].strNYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
											tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
											goto IL_1B20;
										}
										this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j6].strNYTestResult = ctFormMain.TEST_QUAL_STR;
										string valueStr = "<" + System.Convert.ToString(this.gLineTestProcessor.Par.nyValue) + " mA";
										IL_1B83:
										this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j6].strNYTestValue = valueStr;
										goto IL_1B9B;
										IL_1B20:
										int iTemp = tempStr.LastIndexOf('.');
										if (iTemp == -1)
										{
											tempStr += ".";
											for (int i10 = 0; i10 < 3; i10++)
											{
												tempStr += "0";
											}
										}
										else
										{
											while (iTemp + 4 > tempStr.Length)
											{
												tempStr += "0";
												iTemp = tempStr.LastIndexOf('.');
											}
										}
										valueStr = tempStr + " mA";
										goto IL_1B83;
									}
									IL_1B9B:;
								}
							}
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		public void GetFastTestDataResultStrFunc()
		{
			try
			{
				string text = "";
				string tempStr = text;
				if (!this.bSelfStudyPinTestFlag)
				{
					int gCurTestModal = this.gLineTestProcessor.gCurTestModal;
					if (gCurTestModal == 3)
					{
						for (int i = 0; i < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count; i++)
						{
							int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mMainDevPinNum;
							int iSPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mSecDevPinNum;
							for (int j = 0; j < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; j++)
							{
								if ((int)this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnMainPinNum == iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnSecPinNum == iSPinNum)
								{
									if (this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mdTestResult < 0.0)
									{
										double mdTestResult = 0.0 - this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mdTestResult;
										this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mdTestResult = mdTestResult;
									}
									double dTestValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mdTestResult;
									KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
									if (kLineTestProcessor.bResistanceCompFlag)
									{
										SDLPinConnectInfo var_58_1F8_cp_0 = kLineTestProcessor.gDLPinConnectInfoArray[j];
										dTestValue -= this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnMainCompResistance + var_58_1F8_cp_0.mnSecCompResistance;
									}
									if (this.gLineTestProcessor.gDLPinConnectInfoArray[j].iAMeasMethod == 0 && this.gLineTestProcessor.gDLPinConnectInfoArray[j].iBMeasMethod == 0)
									{
										SDLPinConnectInfo var_57_264_cp_0 = this.gLineTestProcessor.gDLPinConnectInfoArray[j];
										dTestValue -= this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnMainInternalResistance + var_57_264_cp_0.mnSecInternalResistance;
									}
									if (dTestValue <= 0.0)
									{
										dTestValue = 0.0;
									}
									tempStr = "";
									string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j].mALJQName;
									string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnALJQPinNum;
									string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j].mBLJQName;
									string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnBLJQPinNum;
									for (int ii = 0; ii < this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray.Count; ii++)
									{
										string temp5Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].PlugName1;
										string temp6Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].PinName1;
										string temp7Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].PlugName2;
										string temp8Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].PinName2;
										if (temp1Str == temp5Str && temp2Str == temp6Str && temp3Str == temp7Str && temp4Str == temp8Str)
										{
											tempStr = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].DTThreshold;
											break;
										}
									}
									double dTempValue;
									if (this.gLineTestProcessor.groupTestParaInfo.bGroupTestFlag && !string.IsNullOrEmpty(tempStr))
									{
										dTempValue = System.Convert.ToDouble(tempStr);
									}
									else
									{
										dTempValue = this.gLineTestProcessor.Par.dtValue;
									}
									if (dTestValue >= dTempValue)
									{
										this.gLineTestProcessor.gDLPinConnectInfoArray[j].strDTTestResult = ctFormMain.TEST_NOT_QUAL_STR;
									}
									else
									{
										this.gLineTestProcessor.gDLPinConnectInfoArray[j].strDTTestResult = ctFormMain.TEST_QUAL_STR;
									}
									string valueStr;
									if (dTestValue < 1000.0)
									{
										if (dTestValue >= 0.0)
										{
											tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
											int iTemp = tempStr.LastIndexOf('.');
											if (iTemp == -1)
											{
												tempStr += ".";
												for (int k = 0; k < 3; k++)
												{
													tempStr += "0";
												}
											}
											else
											{
												while (iTemp + 4 > tempStr.Length)
												{
													tempStr += "0";
													iTemp = tempStr.LastIndexOf('.');
												}
											}
										}
										else
										{
											tempStr = "#";
										}
										valueStr = tempStr + " Ω";
									}
									else if (dTestValue >= 1000.0 && dTestValue < 1000000.0)
									{
										dTestValue /= 1000.0;
										tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
										int iTemp = tempStr.LastIndexOf('.');
										if (iTemp == -1)
										{
											tempStr += ".";
											for (int l = 0; l < 3; l++)
											{
												tempStr += "0";
											}
										}
										else
										{
											while (iTemp + 4 > tempStr.Length)
											{
												tempStr += "0";
												iTemp = tempStr.LastIndexOf('.');
											}
										}
										valueStr = tempStr + " KΩ";
									}
									else if (dTestValue >= 1000000.0 && dTestValue <= 2500000.0)
									{
										dTestValue /= 1000000.0;
										tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
										int iTemp = tempStr.LastIndexOf('.');
										if (iTemp == -1)
										{
											tempStr += ".";
											for (int m = 0; m < 3; m++)
											{
												tempStr += "0";
											}
										}
										else
										{
											while (iTemp + 4 > tempStr.Length)
											{
												tempStr += "0";
												iTemp = tempStr.LastIndexOf('.');
											}
										}
										valueStr = tempStr + " MΩ";
									}
									else
									{
										valueStr = ">2.5 MΩ";
									}
									this.gLineTestProcessor.gDLPinConnectInfoArray[j].strDTTestValue = valueStr;
								}
							}
						}
					}
					else if (gCurTestModal == 4)
					{
						for (int n = 0; n < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count; n++)
						{
							if (!this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].bRefreshFlag)
							{
								this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].bRefreshFlag = true;
								for (int j2 = 0; j2 < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; j2++)
								{
									if (this.gLineTestProcessor.gDLPinConnectInfoArray[j2].mALJQName == this.gLineTestProcessor.mFastTestJQNameList[n])
									{
										if (this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].mdTestResult < 0.0)
										{
											double mdTestResult2 = 0.0 - this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].mdTestResult;
											this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].mdTestResult = mdTestResult2;
										}
										double dTestValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].mdTestResult / 1000.0;
										tempStr = "";
										string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j2].mALJQName;
										string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j2].mnALJQPinNum;
										string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j2].mBLJQName;
										string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j2].mnBLJQPinNum;
										for (int ii2 = 0; ii2 < this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray.Count; ii2++)
										{
											string temp5Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j2].PlugName1;
											string temp6Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j2].PinName1;
											string temp7Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j2].PlugName2;
											string temp8Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j2].PinName2;
											if (temp1Str == temp5Str && temp2Str == temp6Str && temp3Str == temp7Str && temp4Str == temp8Str)
											{
												tempStr = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j2].JYThreshold;
												break;
											}
										}
										double dTempValue;
										if (this.gLineTestProcessor.groupTestParaInfo.bGroupTestFlag && !string.IsNullOrEmpty(tempStr))
										{
											dTempValue = System.Convert.ToDouble(tempStr);
										}
										else
										{
											dTempValue = this.gLineTestProcessor.Par.jyValue;
										}
										int iJYTestDataShowStyle = this.gLineTestProcessor.iJYTestDataShowStyle;
										string valueStr;
										if (iJYTestDataShowStyle == 0)
										{
											if (dTestValue < dTempValue)
											{
												this.gLineTestProcessor.gDLPinConnectInfoArray[j2].strJYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
											}
											else
											{
												this.gLineTestProcessor.gDLPinConnectInfoArray[j2].strJYTestResult = ctFormMain.TEST_QUAL_STR;
												valueStr = ">" + System.Convert.ToString(dTempValue) + " MΩ";
											}
										}
										else if (iJYTestDataShowStyle == 1)
										{
											if (dTestValue < dTempValue)
											{
												this.gLineTestProcessor.gDLPinConnectInfoArray[j2].strJYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
												valueStr = "<" + System.Convert.ToString(dTempValue) + " MΩ";
											}
											else
											{
												this.gLineTestProcessor.gDLPinConnectInfoArray[j2].strJYTestResult = ctFormMain.TEST_QUAL_STR;
											}
										}
										if (dTestValue < 1000.0)
										{
											tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
											int iTemp = tempStr.LastIndexOf('.');
											if (iTemp == -1)
											{
												tempStr += ".";
												for (int i2 = 0; i2 < 3; i2++)
												{
													tempStr += "0";
												}
											}
											else
											{
												while (iTemp + 4 > tempStr.Length)
												{
													tempStr += "0";
													iTemp = tempStr.LastIndexOf('.');
												}
											}
											valueStr = tempStr + " MΩ";
										}
										else
										{
											dTestValue /= 1000.0;
											tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
											int iTemp = tempStr.LastIndexOf('.');
											if (iTemp == -1)
											{
												tempStr += ".";
												for (int i3 = 0; i3 < 3; i3++)
												{
													tempStr += "0";
												}
											}
											else
											{
												while (iTemp + 4 > tempStr.Length)
												{
													tempStr += "0";
													iTemp = tempStr.LastIndexOf('.');
												}
											}
											valueStr = tempStr + " GΩ";
										}
										this.gLineTestProcessor.gDLPinConnectInfoArray[j2].strJYTestValue = valueStr;
									}
								}
							}
						}
					}
					else if (gCurTestModal == 9)
					{
						for (int k2 = 0; k2 < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count; k2++)
						{
							if (!this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].bRefreshFlag)
							{
								this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].bRefreshFlag = true;
								int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].mMainDevPinNum;
								for (int j3 = 0; j3 < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; j3++)
								{
									if ((int)this.gLineTestProcessor.gDLPinConnectInfoArray[j3].mnMainPinNum == iMPinNum || (int)this.gLineTestProcessor.gDLPinConnectInfoArray[j3].mnSecPinNum == iMPinNum)
									{
										if (this.gLineTestProcessor.gDLPinConnectInfoArray[j3].iNYTestFlag == 1)
										{
											if (this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].mdTestResult < 0.0)
											{
												double mdTestResult3 = 0.0 - this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].mdTestResult;
												this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].mdTestResult = mdTestResult3;
											}
											double dTestValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].mdTestResult / 1000000.0;
											tempStr = "";
											string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j3].mALJQName;
											string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j3].mnALJQPinNum;
											string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j3].mBLJQName;
											string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoArray[j3].mnBLJQPinNum;
											for (int ii3 = 0; ii3 < this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray.Count; ii3++)
											{
												string temp5Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j3].PlugName1;
												string temp6Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j3].PinName1;
												string temp7Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j3].PlugName2;
												string temp8Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j3].PinName2;
												if (temp1Str == temp5Str && temp2Str == temp6Str && temp3Str == temp7Str && temp4Str == temp8Str)
												{
													tempStr = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j3].NYThreshold;
													break;
												}
											}
											double dTempValue;
											if (this.gLineTestProcessor.groupTestParaInfo.bGroupTestFlag && !string.IsNullOrEmpty(tempStr))
											{
												dTempValue = System.Convert.ToDouble(tempStr);
											}
											else
											{
												dTempValue = this.gLineTestProcessor.Par.nyValue;
											}
											int iNYTestDataShowStyle = this.gLineTestProcessor.iNYTestDataShowStyle;
											if (iNYTestDataShowStyle == 0)
											{
												if (dTestValue >= dTempValue)
												{
													this.gLineTestProcessor.gDLPinConnectInfoArray[j3].strNYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
												}
												else
												{
													this.gLineTestProcessor.gDLPinConnectInfoArray[j3].strNYTestResult = ctFormMain.TEST_QUAL_STR;
												}
												tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
												goto IL_F7B;
											}
											if (iNYTestDataShowStyle != 1)
											{
												goto IL_F7B;
											}
											if (dTestValue >= dTempValue)
											{
												this.gLineTestProcessor.gDLPinConnectInfoArray[j3].strNYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
												tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
												goto IL_F7B;
											}
											this.gLineTestProcessor.gDLPinConnectInfoArray[j3].strNYTestResult = ctFormMain.TEST_QUAL_STR;
											string valueStr = "<" + System.Convert.ToString(dTempValue) + " mA";
											IL_FDE:
											this.gLineTestProcessor.gDLPinConnectInfoArray[j3].strNYTestValue = valueStr;
											goto IL_FF6;
											IL_F7B:
											int iTemp = tempStr.LastIndexOf('.');
											if (iTemp == -1)
											{
												tempStr += ".";
												for (int i4 = 0; i4 < 3; i4++)
												{
													tempStr += "0";
												}
											}
											else
											{
												while (iTemp + 4 > tempStr.Length)
												{
													tempStr += "0";
													iTemp = tempStr.LastIndexOf('.');
												}
											}
											valueStr = tempStr + " mA";
											goto IL_FDE;
										}
									}
									IL_FF6:;
								}
							}
						}
					}
				}
				else
				{
					int gCurTestModal = this.gLineTestProcessor.gCurTestModal;
					if (gCurTestModal == 3)
					{
						for (int k3 = 0; k3 < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count; k3++)
						{
							int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k3].mMainDevPinNum;
							int iSPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k3].mSecDevPinNum;
							for (int j4 = 0; j4 < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; j4++)
							{
								if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].mnMainPinNum == iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].mnSecPinNum == iSPinNum)
								{
									if (this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k3].mdTestResult < 0.0)
									{
										double mdTestResult4 = 0.0 - this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k3].mdTestResult;
										this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k3].mdTestResult = mdTestResult4;
									}
									double dTestValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k3].mdTestResult;
									KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
									if (kLineTestProcessor.bResistanceCompFlag)
									{
										SDLPinConnectInfo var_53_11A3_cp_0 = kLineTestProcessor.gDLPinConnectInfoSelfArray[j4];
										dTestValue -= this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].mnMainCompResistance + var_53_11A3_cp_0.mnSecCompResistance;
									}
									if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].iAMeasMethod == 0 && this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].iBMeasMethod == 0)
									{
										SDLPinConnectInfo var_52_120F_cp_0 = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4];
										dTestValue -= this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].mnMainInternalResistance + var_52_120F_cp_0.mnSecInternalResistance;
									}
									if (dTestValue <= 0.0)
									{
										dTestValue = 0.0;
									}
									if (dTestValue >= this.gLineTestProcessor.Par.dtValue)
									{
										this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].strDTTestResult = ctFormMain.TEST_NOT_QUAL_STR;
									}
									else
									{
										this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].strDTTestResult = ctFormMain.TEST_QUAL_STR;
									}
									string valueStr;
									if (dTestValue < 1000.0)
									{
										if (dTestValue >= 0.0)
										{
											tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
											int iTemp = tempStr.LastIndexOf('.');
											if (iTemp == -1)
											{
												tempStr += ".";
												for (int i5 = 0; i5 < 3; i5++)
												{
													tempStr += "0";
												}
											}
											else
											{
												while (iTemp + 4 > tempStr.Length)
												{
													tempStr += "0";
													iTemp = tempStr.LastIndexOf('.');
												}
											}
										}
										else
										{
											tempStr = "#";
										}
										valueStr = tempStr + " Ω";
									}
									else if (dTestValue >= 1000.0 && dTestValue < 1000000.0)
									{
										dTestValue /= 1000.0;
										tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
										int iTemp = tempStr.LastIndexOf('.');
										if (iTemp == -1)
										{
											tempStr += ".";
											for (int i6 = 0; i6 < 3; i6++)
											{
												tempStr += "0";
											}
										}
										else
										{
											while (iTemp + 4 > tempStr.Length)
											{
												tempStr += "0";
												iTemp = tempStr.LastIndexOf('.');
											}
										}
										valueStr = tempStr + " KΩ";
									}
									else if (dTestValue >= 1000000.0 && dTestValue <= 2500000.0)
									{
										dTestValue /= 1000000.0;
										tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
										int iTemp = tempStr.LastIndexOf('.');
										if (iTemp == -1)
										{
											tempStr += ".";
											for (int i7 = 0; i7 < 3; i7++)
											{
												tempStr += "0";
											}
										}
										else
										{
											while (iTemp + 4 > tempStr.Length)
											{
												tempStr += "0";
												iTemp = tempStr.LastIndexOf('.');
											}
										}
										valueStr = tempStr + " MΩ";
									}
									else
									{
										valueStr = ">2.5 MΩ";
									}
									this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].strDTTestValue = valueStr;
								}
							}
						}
					}
					else if (gCurTestModal == 4)
					{
						for (int k4 = 0; k4 < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count; k4++)
						{
							if (!this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k4].bRefreshFlag)
							{
								this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k4].bRefreshFlag = true;
								for (int j5 = 0; j5 < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; j5++)
								{
									if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].mALJQName == this.gLineTestProcessor.mFastTestJQNameList[k4])
									{
										if (this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k4].mdTestResult < 0.0)
										{
											double mdTestResult5 = 0.0 - this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k4].mdTestResult;
											this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k4].mdTestResult = mdTestResult5;
										}
										double dTestValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k4].mdTestResult / 1000.0;
										KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
										int iJYTestDataShowStyle2 = kLineTestProcessor.iJYTestDataShowStyle;
										string valueStr;
										if (iJYTestDataShowStyle2 == 0)
										{
											if (dTestValue < kLineTestProcessor.Par.jyValue)
											{
												this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].strJYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
											}
											else
											{
												this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].strJYTestResult = ctFormMain.TEST_QUAL_STR;
												valueStr = ">" + System.Convert.ToString(this.gLineTestProcessor.Par.jyValue) + " MΩ";
											}
										}
										else if (iJYTestDataShowStyle2 == 1)
										{
											if (dTestValue < kLineTestProcessor.Par.jyValue)
											{
												this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].strJYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
												valueStr = "<" + System.Convert.ToString(this.gLineTestProcessor.Par.jyValue) + " MΩ";
											}
											else
											{
												this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].strJYTestResult = ctFormMain.TEST_QUAL_STR;
											}
										}
										if (dTestValue < 1000.0)
										{
											tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
											int iTemp = tempStr.LastIndexOf('.');
											if (iTemp == -1)
											{
												tempStr += ".";
												for (int i8 = 0; i8 < 3; i8++)
												{
													tempStr += "0";
												}
											}
											else
											{
												while (iTemp + 4 > tempStr.Length)
												{
													tempStr += "0";
													iTemp = tempStr.LastIndexOf('.');
												}
											}
											valueStr = tempStr + " MΩ";
										}
										else
										{
											dTestValue /= 1000.0;
											tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
											int iTemp = tempStr.LastIndexOf('.');
											if (iTemp == -1)
											{
												tempStr += ".";
												for (int i9 = 0; i9 < 3; i9++)
												{
													tempStr += "0";
												}
											}
											else
											{
												while (iTemp + 4 > tempStr.Length)
												{
													tempStr += "0";
													iTemp = tempStr.LastIndexOf('.');
												}
											}
											valueStr = tempStr + " GΩ";
										}
										this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].strJYTestValue = valueStr;
									}
								}
							}
						}
					}
					else if (gCurTestModal == 9)
					{
						for (int k5 = 0; k5 < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count; k5++)
						{
							if (!this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k5].bRefreshFlag)
							{
								this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k5].bRefreshFlag = true;
								int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k5].mMainDevPinNum;
								for (int j6 = 0; j6 < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; j6++)
								{
									if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j6].mnMainPinNum == iMPinNum || (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j6].mnSecPinNum == iMPinNum)
									{
										if (this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k5].mdTestResult < 0.0)
										{
											double mdTestResult6 = 0.0 - this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k5].mdTestResult;
											this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k5].mdTestResult = mdTestResult6;
										}
										double dTestValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k5].mdTestResult / 1000000.0;
										KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
										int iNYTestDataShowStyle = kLineTestProcessor.iNYTestDataShowStyle;
										if (iNYTestDataShowStyle == 0)
										{
											if (dTestValue >= kLineTestProcessor.Par.nyValue)
											{
												this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j6].strNYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
											}
											else
											{
												this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j6].strNYTestResult = ctFormMain.TEST_QUAL_STR;
											}
											tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
											goto IL_1AD4;
										}
										if (iNYTestDataShowStyle != 1)
										{
											goto IL_1AD4;
										}
										if (dTestValue >= kLineTestProcessor.Par.nyValue)
										{
											this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j6].strNYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
											tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
											goto IL_1AD4;
										}
										this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j6].strNYTestResult = ctFormMain.TEST_QUAL_STR;
										string valueStr = "<" + System.Convert.ToString(this.gLineTestProcessor.Par.nyValue) + " mA";
										IL_1B37:
										this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j6].strNYTestValue = valueStr;
										goto IL_1B4F;
										IL_1AD4:
										int iTemp = tempStr.LastIndexOf('.');
										if (iTemp == -1)
										{
											tempStr += ".";
											for (int i10 = 0; i10 < 3; i10++)
											{
												tempStr += "0";
											}
										}
										else
										{
											while (iTemp + 4 > tempStr.Length)
											{
												tempStr += "0";
												iTemp = tempStr.LastIndexOf('.');
											}
										}
										valueStr = tempStr + " mA";
										goto IL_1B37;
									}
									IL_1B4F:;
								}
							}
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		public void GetChoiceTestDataResultStrFunc()
		{
			try
			{
				int gCurTestModal = this.gLineTestProcessor.gCurTestModal;
				if (gCurTestModal == 3)
				{
					for (int i = 0; i < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count; i++)
					{
						int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mMainDevPinNum;
						int iSPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mSecDevPinNum;
						for (int j = 0; j < this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count; j++)
						{
							if ((int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].mnMainPinNum == iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].mnSecPinNum == iSPinNum)
							{
								if (this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mdTestResult < 0.0)
								{
									double mdTestResult = 0.0 - this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mdTestResult;
									this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mdTestResult = mdTestResult;
								}
								double dTestValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mdTestResult;
								KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
								if (kLineTestProcessor.bResistanceCompFlag)
								{
									SDLPinConnectInfo var_40_1E3_cp_0 = kLineTestProcessor.gDLPinConnectInfoChoiceArray[j];
									dTestValue -= this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].mnMainCompResistance + var_40_1E3_cp_0.mnSecCompResistance;
								}
								if (this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].iAMeasMethod == 0 && this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].iBMeasMethod == 0)
								{
									SDLPinConnectInfo var_39_24B_cp_0 = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j];
									dTestValue -= this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].mnMainInternalResistance + var_39_24B_cp_0.mnSecInternalResistance;
								}
								if (dTestValue <= 0.0)
								{
									dTestValue = 0.0;
								}
								string tempStr = "";
								string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].mALJQName;
								string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].mnALJQPinNum;
								string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].mBLJQName;
								string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].mnBLJQPinNum;
								for (int ii = 0; ii < this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray.Count; ii++)
								{
									string temp5Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].PlugName1;
									string temp6Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].PinName1;
									string temp7Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].PlugName2;
									string temp8Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].PinName2;
									if (temp1Str == temp5Str && temp2Str == temp6Str && temp3Str == temp7Str && temp4Str == temp8Str)
									{
										tempStr = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].DTThreshold;
										break;
									}
								}
								double dTempValue;
								if (this.gLineTestProcessor.groupTestParaInfo.bGroupTestFlag && !string.IsNullOrEmpty(tempStr))
								{
									dTempValue = System.Convert.ToDouble(tempStr);
								}
								else
								{
									dTempValue = this.gLineTestProcessor.Par.dtValue;
								}
								if (dTestValue >= dTempValue)
								{
									this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].strDTTestResult = ctFormMain.TEST_NOT_QUAL_STR;
								}
								else
								{
									this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].strDTTestResult = ctFormMain.TEST_QUAL_STR;
								}
								string valueStr;
								if (dTestValue < 1000.0)
								{
									if (dTestValue >= 0.0)
									{
										tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
										int iTemp = tempStr.LastIndexOf('.');
										if (iTemp == -1)
										{
											tempStr += ".";
											for (int k = 0; k < 3; k++)
											{
												tempStr += "0";
											}
										}
										else
										{
											while (iTemp + 4 > tempStr.Length)
											{
												tempStr += "0";
												iTemp = tempStr.LastIndexOf('.');
											}
										}
									}
									else
									{
										tempStr = "#";
									}
									valueStr = tempStr + " Ω";
								}
								else if (dTestValue >= 1000.0 && dTestValue < 1000000.0)
								{
									dTestValue /= 1000.0;
									tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
									int iTemp = tempStr.LastIndexOf('.');
									if (iTemp == -1)
									{
										tempStr += ".";
										for (int l = 0; l < 3; l++)
										{
											tempStr += "0";
										}
									}
									else
									{
										while (iTemp + 4 > tempStr.Length)
										{
											tempStr += "0";
											iTemp = tempStr.LastIndexOf('.');
										}
									}
									valueStr = tempStr + " KΩ";
								}
								else if (dTestValue >= 1000000.0 && dTestValue <= 2500000.0)
								{
									dTestValue /= 1000000.0;
									tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
									int iTemp = tempStr.LastIndexOf('.');
									if (iTemp == -1)
									{
										tempStr += ".";
										for (int m = 0; m < 3; m++)
										{
											tempStr += "0";
										}
									}
									else
									{
										while (iTemp + 4 > tempStr.Length)
										{
											tempStr += "0";
											iTemp = tempStr.LastIndexOf('.');
										}
									}
									valueStr = tempStr + " MΩ";
								}
								else
								{
									valueStr = ">2.5 MΩ";
								}
								this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].strDTTestValue = valueStr;
							}
						}
					}
				}
				else if (gCurTestModal == 4)
				{
					for (int n = 0; n < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count; n++)
					{
						if (!this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].bRefreshFlag)
						{
							this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].bRefreshFlag = true;
							int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].mMainDevPinNum;
							for (int j2 = 0; j2 < this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count; j2++)
							{
								if ((int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j2].mnMainPinNum == iMPinNum || (int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j2].mnSecPinNum == iMPinNum)
								{
									if (this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].mdTestResult < 0.0)
									{
										double mdTestResult2 = 0.0 - this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].mdTestResult;
										this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].mdTestResult = mdTestResult2;
									}
									double dTestValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].mdTestResult / 1000.0;
									string tempStr = "";
									string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j2].mALJQName;
									string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j2].mnALJQPinNum;
									string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j2].mBLJQName;
									string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j2].mnBLJQPinNum;
									for (int ii2 = 0; ii2 < this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray.Count; ii2++)
									{
										string temp5Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j2].PlugName1;
										string temp6Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j2].PinName1;
										string temp7Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j2].PlugName2;
										string temp8Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j2].PinName2;
										if (temp1Str == temp5Str && temp2Str == temp6Str && temp3Str == temp7Str && temp4Str == temp8Str)
										{
											tempStr = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j2].JYThreshold;
											break;
										}
									}
									double dTempValue;
									if (this.gLineTestProcessor.groupTestParaInfo.bGroupTestFlag && !string.IsNullOrEmpty(tempStr))
									{
										dTempValue = System.Convert.ToDouble(tempStr);
									}
									else
									{
										dTempValue = this.gLineTestProcessor.Par.jyValue;
									}
									int iJYTestDataShowStyle = this.gLineTestProcessor.iJYTestDataShowStyle;
									string valueStr;
									if (iJYTestDataShowStyle == 0)
									{
										if (dTestValue < dTempValue)
										{
											this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j2].strJYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
										}
										else
										{
											this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j2].strJYTestResult = ctFormMain.TEST_QUAL_STR;
											valueStr = ">" + System.Convert.ToString(dTempValue) + " MΩ";
										}
									}
									else if (iJYTestDataShowStyle == 1)
									{
										if (dTestValue < dTempValue)
										{
											this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j2].strJYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
											valueStr = "<" + System.Convert.ToString(dTempValue) + " MΩ";
										}
										else
										{
											this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j2].strJYTestResult = ctFormMain.TEST_QUAL_STR;
										}
									}
									if (dTestValue < 1000.0)
									{
										tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
										int iTemp = tempStr.LastIndexOf('.');
										if (iTemp == -1)
										{
											tempStr += ".";
											for (int i2 = 0; i2 < 3; i2++)
											{
												tempStr += "0";
											}
										}
										else
										{
											while (iTemp + 4 > tempStr.Length)
											{
												tempStr += "0";
												iTemp = tempStr.LastIndexOf('.');
											}
										}
										valueStr = tempStr + " MΩ";
									}
									else
									{
										dTestValue /= 1000.0;
										tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
										int iTemp = tempStr.LastIndexOf('.');
										if (iTemp == -1)
										{
											tempStr += ".";
											for (int i3 = 0; i3 < 3; i3++)
											{
												tempStr += "0";
											}
										}
										else
										{
											while (iTemp + 4 > tempStr.Length)
											{
												tempStr += "0";
												iTemp = tempStr.LastIndexOf('.');
											}
										}
										valueStr = tempStr + " GΩ";
									}
									this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j2].strJYTestValue = valueStr;
								}
							}
						}
					}
				}
				else if (gCurTestModal == 9)
				{
					for (int k2 = 0; k2 < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count; k2++)
					{
						if (!this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].bRefreshFlag)
						{
							this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].bRefreshFlag = true;
							int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].mMainDevPinNum;
							for (int j3 = 0; j3 < this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count; j3++)
							{
								if ((int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j3].mnMainPinNum == iMPinNum || (int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j3].mnSecPinNum == iMPinNum)
								{
									if (this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j3].iNYTestFlag == 1)
									{
										if (this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].mdTestResult < 0.0)
										{
											double mdTestResult3 = 0.0 - this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].mdTestResult;
											this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].mdTestResult = mdTestResult3;
										}
										double dTestValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].mdTestResult / 1000000.0;
										string tempStr = "";
										string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j3].mALJQName;
										string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j3].mnALJQPinNum;
										string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j3].mBLJQName;
										string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j3].mnBLJQPinNum;
										for (int ii3 = 0; ii3 < this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray.Count; ii3++)
										{
											string temp5Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j3].PlugName1;
											string temp6Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j3].PinName1;
											string temp7Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j3].PlugName2;
											string temp8Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j3].PinName2;
											if (temp1Str == temp5Str && temp2Str == temp6Str && temp3Str == temp7Str && temp4Str == temp8Str)
											{
												tempStr = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j3].NYThreshold;
												break;
											}
										}
										double dTempValue;
										if (this.gLineTestProcessor.groupTestParaInfo.bGroupTestFlag && !string.IsNullOrEmpty(tempStr))
										{
											dTempValue = System.Convert.ToDouble(tempStr);
										}
										else
										{
											dTempValue = this.gLineTestProcessor.Par.nyValue;
										}
										KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
										int iNYTestDataShowStyle = kLineTestProcessor.iNYTestDataShowStyle;
										if (iNYTestDataShowStyle == 0)
										{
											if (dTestValue >= dTempValue)
											{
												this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j3].strNYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
											}
											else
											{
												this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j3].strNYTestResult = ctFormMain.TEST_QUAL_STR;
											}
											tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
											goto IL_FA9;
										}
										if (iNYTestDataShowStyle != 1)
										{
											goto IL_FA9;
										}
										if (dTestValue >= kLineTestProcessor.Par.nyValue)
										{
											this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j3].strNYTestResult = ctFormMain.TEST_NOT_QUAL_STR;
											tempStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
											goto IL_FA9;
										}
										this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j3].strNYTestResult = ctFormMain.TEST_QUAL_STR;
										string valueStr = "<" + System.Convert.ToString(this.gLineTestProcessor.Par.nyValue) + " mA";
										IL_100D:
										this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j3].strNYTestValue = valueStr;
										goto IL_1026;
										IL_FA9:
										int iTemp = tempStr.LastIndexOf('.');
										if (iTemp == -1)
										{
											tempStr += ".";
											for (int i4 = 0; i4 < 3; i4++)
											{
												tempStr += "0";
											}
										}
										else
										{
											while (iTemp + 4 > tempStr.Length)
											{
												tempStr += "0";
												iTemp = tempStr.LastIndexOf('.');
											}
										}
										valueStr = tempStr + " mA";
										goto IL_100D;
									}
								}
								IL_1026:;
							}
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		public int HeadAndTailPinDataFunc(int iIndex, int iSelectLastRow)
		{
			int iReturnValue = iSelectLastRow;
			try
			{
				if (iSelectLastRow == -1)
				{
					return -1;
				}
				string tempDGVAStr = this.dataGridView1.Rows[iSelectLastRow].Cells[1].Value.ToString();
				string tempDGVAPinStr = this.dataGridView1.Rows[iSelectLastRow].Cells[2].Value.ToString();
				int gCurTestModal = this.gLineTestProcessor.gCurTestModal;
				if (gCurTestModal == 4)
				{
					if (iIndex == 0)
					{
						for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
						{
							if (i != iReturnValue)
							{
								string tempDGVBStr = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
								string tempDGVBPinStr = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
								if (tempDGVAStr == tempDGVBStr && tempDGVAPinStr == tempDGVBPinStr)
								{
									this.dataGridView1.Rows[i].Cells[this.iJYTValueColNum].Value = this.dataGridView1.Rows[iReturnValue].Cells[this.iJYTValueColNum].Value.ToString();
									this.dataGridView1.Rows[i].Cells[this.iJYResultColNum].Value = this.dataGridView1.Rows[iReturnValue].Cells[this.iJYResultColNum].Value.ToString();
									System.Drawing.Color backColor = this.dataGridView1.Rows[iReturnValue].DefaultCellStyle.BackColor;
									this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = backColor;
									int num = iReturnValue + 1;
									if (i == num)
									{
										iReturnValue = num;
										break;
									}
									break;
								}
							}
						}
					}
					else
					{
						int iTemp = -1;
						for (int j = 0; j < this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count; j++)
						{
							string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].mALJQName;
							string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].mnALJQPinNum;
							if (tempDGVAStr == temp1Str && tempDGVAPinStr == temp2Str)
							{
								iTemp = j;
								break;
							}
						}
						if (iTemp >= 0)
						{
							for (int k = 0; k < this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count; k++)
							{
								if (k != iTemp)
								{
									string tempBStr = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[k].mBLJQName;
									string tempBPinStr = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[k].mnBLJQPinNum;
									if (tempDGVAStr == tempBStr && tempDGVAPinStr == tempBPinStr)
									{
										SDLPinConnectInfo var_34_340_cp_0 = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[iTemp];
										this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[k].strJYTestValue = var_34_340_cp_0.strJYTestValue;
										SDLPinConnectInfo var_33_373_cp_0 = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[iTemp];
										this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[k].strJYTestResult = var_33_373_cp_0.strJYTestResult;
										string temp1Str = this.dataGridView1.Rows[iSelectLastRow].Cells[1].Value.ToString();
										string temp2Str = this.dataGridView1.Rows[iSelectLastRow].Cells[2].Value.ToString();
										string temp3Str = this.dataGridView1.Rows[iSelectLastRow].Cells[3].Value.ToString();
										string temp4Str = this.dataGridView1.Rows[iSelectLastRow].Cells[4].Value.ToString();
										for (int l = 0; l < this.dataGridView1.Rows.Count; l++)
										{
											if (l != iSelectLastRow)
											{
												string temp5Str = this.dataGridView1.Rows[l].Cells[1].Value.ToString();
												string temp6Str = this.dataGridView1.Rows[l].Cells[2].Value.ToString();
												string temp7Str = this.dataGridView1.Rows[l].Cells[3].Value.ToString();
												string temp8Str = this.dataGridView1.Rows[l].Cells[4].Value.ToString();
												if (temp1Str == temp7Str && temp2Str == temp8Str && temp3Str == temp5Str && temp4Str == temp6Str)
												{
													this.dataGridView1.Rows[l].Cells[this.iJYTValueColNum].Value = this.dataGridView1.Rows[iSelectLastRow].Cells[this.iJYTValueColNum].Value.ToString();
													this.dataGridView1.Rows[l].Cells[this.iJYResultColNum].Value = this.dataGridView1.Rows[iSelectLastRow].Cells[this.iJYResultColNum].Value.ToString();
													System.Drawing.Color backColor2 = this.dataGridView1.Rows[iSelectLastRow].DefaultCellStyle.BackColor;
													this.dataGridView1.Rows[l].DefaultCellStyle.BackColor = backColor2;
													break;
												}
											}
										}
										break;
									}
								}
							}
						}
					}
				}
				else if (gCurTestModal == 9)
				{
					if (iIndex == 0)
					{
						for (int m = 0; m < this.dataGridView1.Rows.Count; m++)
						{
							if (m != iReturnValue)
							{
								string tempDGVBStr = this.dataGridView1.Rows[m].Cells[3].Value.ToString();
								string tempDGVBPinStr = this.dataGridView1.Rows[m].Cells[4].Value.ToString();
								if (tempDGVAStr == tempDGVBStr && tempDGVAPinStr == tempDGVBPinStr)
								{
									this.dataGridView1.Rows[m].Cells[this.iNYTValueColNum].Value = this.dataGridView1.Rows[iReturnValue].Cells[this.iNYTValueColNum].Value.ToString();
									this.dataGridView1.Rows[m].Cells[this.iNYResultColNum].Value = this.dataGridView1.Rows[iReturnValue].Cells[this.iNYResultColNum].Value.ToString();
									System.Drawing.Color backColor3 = this.dataGridView1.Rows[iReturnValue].DefaultCellStyle.BackColor;
									this.dataGridView1.Rows[m].DefaultCellStyle.BackColor = backColor3;
									int num2 = iReturnValue + 1;
									if (m == num2)
									{
										iReturnValue = num2;
										break;
									}
									break;
								}
							}
						}
					}
					else
					{
						int iTemp = -1;
						for (int n = 0; n < this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count; n++)
						{
							string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[n].mALJQName;
							string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[n].mnALJQPinNum;
							if (tempDGVAStr == temp1Str && tempDGVAPinStr == temp2Str)
							{
								iTemp = n;
								break;
							}
						}
						if (iTemp >= 0)
						{
							for (int k2 = iTemp + 1; k2 < this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count; k2++)
							{
								string tempBStr = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[k2].mBLJQName;
								string tempBPinStr = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[k2].mnBLJQPinNum;
								if (tempDGVAStr == tempBStr && tempDGVAPinStr == tempBPinStr)
								{
									SDLPinConnectInfo var_30_8C0_cp_0 = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[iTemp];
									this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[k2].strNYTestValue = var_30_8C0_cp_0.strNYTestValue;
									SDLPinConnectInfo var_29_8F3_cp_0 = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[iTemp];
									this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[k2].strNYTestResult = var_29_8F3_cp_0.strNYTestResult;
									string temp1Str = this.dataGridView1.Rows[iSelectLastRow].Cells[1].Value.ToString();
									string temp2Str = this.dataGridView1.Rows[iSelectLastRow].Cells[2].Value.ToString();
									string temp3Str = this.dataGridView1.Rows[iSelectLastRow].Cells[3].Value.ToString();
									string temp4Str = this.dataGridView1.Rows[iSelectLastRow].Cells[4].Value.ToString();
									for (int i2 = 0; i2 < this.dataGridView1.Rows.Count; i2++)
									{
										if (i2 != iSelectLastRow)
										{
											string temp5Str = this.dataGridView1.Rows[i2].Cells[1].Value.ToString();
											string temp6Str = this.dataGridView1.Rows[i2].Cells[2].Value.ToString();
											string temp7Str = this.dataGridView1.Rows[i2].Cells[3].Value.ToString();
											string temp8Str = this.dataGridView1.Rows[i2].Cells[4].Value.ToString();
											if (temp1Str == temp7Str && temp2Str == temp8Str && temp3Str == temp5Str && temp4Str == temp6Str)
											{
												this.dataGridView1.Rows[i2].Cells[this.iNYTValueColNum].Value = this.dataGridView1.Rows[iSelectLastRow].Cells[this.iNYTValueColNum].Value.ToString();
												this.dataGridView1.Rows[i2].Cells[this.iNYResultColNum].Value = this.dataGridView1.Rows[iSelectLastRow].Cells[this.iNYResultColNum].Value.ToString();
												System.Drawing.Color backColor4 = this.dataGridView1.Rows[iSelectLastRow].DefaultCellStyle.BackColor;
												this.dataGridView1.Rows[i2].DefaultCellStyle.BackColor = backColor4;
												break;
											}
										}
									}
									break;
								}
							}
						}
					}
				}
			}
			catch (System.Exception arg_B9D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_B9D_0.StackTrace);
			}
			return iReturnValue;
		}
		public void RefreshTestUIDataFunc()
		{
			int iSelectLastRow = -1;
			try
			{
				if (!this.bSelfStudyPinTestFlag)
				{
					int gCurTestModal = this.gLineTestProcessor.gCurTestModal;
					if (gCurTestModal == 3)
					{
						for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
						{
							string tempDGVAStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
							string tempDGVAPinStr = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
							string tempDGVBStr = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
							string tempDGVBPinStr = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
							for (int j = 0; j < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; j++)
							{
								if (this.gLineTestProcessor.gDLPinConnectInfoArray[j].iDTTestFlag == 1)
								{
									bool bShowRedFlag = false;
									string tempAStr = this.gLineTestProcessor.gDLPinConnectInfoArray[j].mALJQName;
									string tempAPinStr = this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnALJQPinNum;
									string tempBStr = this.gLineTestProcessor.gDLPinConnectInfoArray[j].mBLJQName;
									string tempBPinStr = this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnBLJQPinNum;
									if (tempAStr == tempDGVAStr && tempAPinStr == tempDGVAPinStr && tempBStr == tempDGVBStr && tempBPinStr == tempDGVBPinStr)
									{
										int k = 0;
										while (k < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count)
										{
											int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k].mMainDevPinNum;
											int iSPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k].mSecDevPinNum;
											if ((int)this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnMainPinNum == iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnSecPinNum == iSPinNum)
											{
												this.dataGridView1.Rows[i].Cells[this.iDTTValueColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[j].strDTTestValue;
												this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[j].strDTTestResult;
												if (this.gLineTestProcessor.gDLPinConnectInfoArray[j].strDTTestResult == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
												if (this.bIsYJCSFlag)
												{
													goto IL_47D;
												}
												string tempStr;
												if (this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value != null)
												{
													tempStr = this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value.ToString();
													if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
													{
														bShowRedFlag = true;
													}
												}
												if (this.dataGridView1.Rows[i].Cells[this.iJYResultColNum].Value != null)
												{
													tempStr = this.dataGridView1.Rows[i].Cells[this.iJYResultColNum].Value.ToString();
													if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
													{
														bShowRedFlag = true;
													}
												}
												if (this.dataGridView1.Rows[i].Cells[this.iNYResultColNum].Value == null)
												{
													goto IL_47D;
												}
												tempStr = this.dataGridView1.Rows[i].Cells[this.iNYResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													goto IL_480;
												}
												goto IL_47D;
												IL_4A4:
												iSelectLastRow = i;
												break;
												IL_480:
												System.Drawing.Color red = System.Drawing.Color.Red;
												this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = red;
												goto IL_4A4;
												IL_47D:
												if (bShowRedFlag)
												{
													goto IL_480;
												}
												goto IL_4A4;
											}
											else
											{
												k++;
											}
										}
									}
								}
							}
						}
					}
					else if (gCurTestModal == 4)
					{
						for (int l = 0; l < this.dataGridView1.Rows.Count; l++)
						{
							string tempDGVAStr = this.dataGridView1.Rows[l].Cells[1].Value.ToString();
							string tempDGVAPinStr = this.dataGridView1.Rows[l].Cells[2].Value.ToString();
							for (int m = 0; m < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; m++)
							{
								if (this.gLineTestProcessor.gDLPinConnectInfoArray[m].iJYTestFlag == 1)
								{
									bool bShowRedFlag = false;
									string tempAStr = this.gLineTestProcessor.gDLPinConnectInfoArray[m].mALJQName;
									string tempAPinStr = this.gLineTestProcessor.gDLPinConnectInfoArray[m].mnALJQPinNum;
									if (tempAStr == tempDGVAStr && tempAPinStr == tempDGVAPinStr)
									{
										int n = 0;
										while (n < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count)
										{
											int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].mMainDevPinNum;
											if ((int)this.gLineTestProcessor.gDLPinConnectInfoArray[m].mnMainPinNum != iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoArray[m].mnSecPinNum != iMPinNum)
											{
												n++;
											}
											else
											{
												this.dataGridView1.Rows[l].Cells[this.iJYTValueColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[m].strJYTestValue;
												this.dataGridView1.Rows[l].Cells[this.iJYResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[m].strJYTestResult;
												if (this.gLineTestProcessor.gDLPinConnectInfoArray[m].strJYTestResult == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
												if (this.bIsYJCSFlag)
												{
													goto IL_82A;
												}
												string tempStr;
												if (this.dataGridView1.Rows[l].Cells[this.iDTResultColNum].Value != null)
												{
													tempStr = this.dataGridView1.Rows[l].Cells[this.iDTResultColNum].Value.ToString();
													if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
													{
														bShowRedFlag = true;
													}
												}
												if (this.dataGridView1.Rows[l].Cells[this.iJYResultColNum].Value != null)
												{
													tempStr = this.dataGridView1.Rows[l].Cells[this.iJYResultColNum].Value.ToString();
													if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
													{
														bShowRedFlag = true;
													}
												}
												if (this.dataGridView1.Rows[l].Cells[this.iNYResultColNum].Value == null)
												{
													goto IL_82A;
												}
												tempStr = this.dataGridView1.Rows[l].Cells[this.iNYResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													goto IL_82D;
												}
												goto IL_82A;
												IL_852:
												iSelectLastRow = l;
												break;
												IL_82D:
												System.Drawing.Color red2 = System.Drawing.Color.Red;
												this.dataGridView1.Rows[l].DefaultCellStyle.BackColor = red2;
												goto IL_852;
												IL_82A:
												if (bShowRedFlag)
												{
													goto IL_82D;
												}
												goto IL_852;
											}
										}
									}
								}
							}
						}
					}
					else if (gCurTestModal == 9)
					{
						for (int i2 = 0; i2 < this.dataGridView1.Rows.Count; i2++)
						{
							string tempDGVAStr = this.dataGridView1.Rows[i2].Cells[1].Value.ToString();
							string tempDGVAPinStr = this.dataGridView1.Rows[i2].Cells[2].Value.ToString();
							for (int j2 = 0; j2 < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; j2++)
							{
								if (this.gLineTestProcessor.gDLPinConnectInfoArray[j2].iNYTestFlag == 1)
								{
									bool bShowRedFlag = false;
									string tempAStr = this.gLineTestProcessor.gDLPinConnectInfoArray[j2].mALJQName;
									string tempAPinStr = this.gLineTestProcessor.gDLPinConnectInfoArray[j2].mnALJQPinNum;
									if (tempAStr == tempDGVAStr && tempAPinStr == tempDGVAPinStr)
									{
										int k2 = 0;
										while (k2 < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count)
										{
											int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].mMainDevPinNum;
											if ((int)this.gLineTestProcessor.gDLPinConnectInfoArray[j2].mnMainPinNum != iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoArray[j2].mnSecPinNum != iMPinNum)
											{
												k2++;
											}
											else
											{
												this.dataGridView1.Rows[i2].Cells[this.iNYTValueColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[j2].strNYTestValue;
												this.dataGridView1.Rows[i2].Cells[this.iNYResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[j2].strNYTestResult;
												if (this.gLineTestProcessor.gDLPinConnectInfoArray[j2].strNYTestResult == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
												if (this.bIsYJCSFlag)
												{
													goto IL_BCF;
												}
												string tempStr;
												if (this.dataGridView1.Rows[i2].Cells[this.iDTResultColNum].Value != null)
												{
													tempStr = this.dataGridView1.Rows[i2].Cells[this.iDTResultColNum].Value.ToString();
													if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
													{
														bShowRedFlag = true;
													}
												}
												if (this.dataGridView1.Rows[i2].Cells[this.iJYResultColNum].Value != null)
												{
													tempStr = this.dataGridView1.Rows[i2].Cells[this.iJYResultColNum].Value.ToString();
													if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
													{
														bShowRedFlag = true;
													}
												}
												if (this.dataGridView1.Rows[i2].Cells[this.iNYResultColNum].Value == null)
												{
													goto IL_BCF;
												}
												tempStr = this.dataGridView1.Rows[i2].Cells[this.iNYResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													goto IL_BD2;
												}
												goto IL_BCF;
												IL_BF7:
												iSelectLastRow = i2;
												break;
												IL_BD2:
												System.Drawing.Color red3 = System.Drawing.Color.Red;
												this.dataGridView1.Rows[i2].DefaultCellStyle.BackColor = red3;
												goto IL_BF7;
												IL_BCF:
												if (bShowRedFlag)
												{
													goto IL_BD2;
												}
												goto IL_BF7;
											}
										}
									}
								}
							}
						}
					}
				}
				else
				{
					int gCurTestModal = this.gLineTestProcessor.gCurTestModal;
					if (gCurTestModal == 3)
					{
						for (int i3 = 0; i3 < this.dataGridView1.Rows.Count; i3++)
						{
							string tempDGVAStr = this.dataGridView1.Rows[i3].Cells[1].Value.ToString();
							string tempDGVAPinStr = this.dataGridView1.Rows[i3].Cells[2].Value.ToString();
							string tempDGVBStr = this.dataGridView1.Rows[i3].Cells[3].Value.ToString();
							string tempDGVBPinStr = this.dataGridView1.Rows[i3].Cells[4].Value.ToString();
							for (int j3 = 0; j3 < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; j3++)
							{
								bool bShowRedFlag = false;
								string tempAStr = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j3].mALJQName;
								string tempAPinStr = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j3].mnALJQPinNum;
								string tempBStr = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j3].mBLJQName;
								string tempBPinStr = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j3].mnBLJQPinNum;
								if (tempAStr == tempDGVAStr && tempAPinStr == tempDGVAPinStr && tempBStr == tempDGVBStr && tempBPinStr == tempDGVBPinStr)
								{
									int k3 = 0;
									while (k3 < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count)
									{
										int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k3].mMainDevPinNum;
										int iSPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k3].mSecDevPinNum;
										if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j3].mnMainPinNum == iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j3].mnSecPinNum == iSPinNum)
										{
											this.dataGridView1.Rows[i3].Cells[this.iDTTValueColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j3].strDTTestValue;
											this.dataGridView1.Rows[i3].Cells[this.iDTResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j3].strDTTestResult;
											if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j3].strDTTestResult == ctFormMain.TEST_NOT_QUAL_STR)
											{
												bShowRedFlag = true;
											}
											if (this.bIsYJCSFlag)
											{
												goto IL_1011;
											}
											string tempStr;
											if (this.dataGridView1.Rows[i3].Cells[this.iDTResultColNum].Value != null)
											{
												tempStr = this.dataGridView1.Rows[i3].Cells[this.iDTResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
											}
											if (this.dataGridView1.Rows[i3].Cells[this.iJYResultColNum].Value != null)
											{
												tempStr = this.dataGridView1.Rows[i3].Cells[this.iJYResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
											}
											if (this.dataGridView1.Rows[i3].Cells[this.iNYResultColNum].Value == null)
											{
												goto IL_1011;
											}
											tempStr = this.dataGridView1.Rows[i3].Cells[this.iNYResultColNum].Value.ToString();
											if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
											{
												goto IL_1014;
											}
											goto IL_1011;
											IL_1038:
											iSelectLastRow = i3;
											break;
											IL_1014:
											System.Drawing.Color red4 = System.Drawing.Color.Red;
											this.dataGridView1.Rows[i3].DefaultCellStyle.BackColor = red4;
											goto IL_1038;
											IL_1011:
											if (bShowRedFlag)
											{
												goto IL_1014;
											}
											goto IL_1038;
										}
										else
										{
											k3++;
										}
									}
								}
							}
						}
					}
					else if (gCurTestModal == 4)
					{
						for (int i4 = 0; i4 < this.dataGridView1.Rows.Count; i4++)
						{
							string tempDGVAStr = this.dataGridView1.Rows[i4].Cells[1].Value.ToString();
							string tempDGVAPinStr = this.dataGridView1.Rows[i4].Cells[2].Value.ToString();
							for (int j4 = 0; j4 < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; j4++)
							{
								bool bShowRedFlag = false;
								string tempAStr = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].mALJQName;
								string tempAPinStr = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].mnALJQPinNum;
								if (tempAStr == tempDGVAStr && tempAPinStr == tempDGVAPinStr)
								{
									int k4 = 0;
									while (k4 < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count)
									{
										int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k4].mMainDevPinNum;
										if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].mnMainPinNum != iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].mnSecPinNum != iMPinNum)
										{
											k4++;
										}
										else
										{
											this.dataGridView1.Rows[i4].Cells[this.iJYTValueColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].strJYTestValue;
											this.dataGridView1.Rows[i4].Cells[this.iJYResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].strJYTestResult;
											if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].strJYTestResult == ctFormMain.TEST_NOT_QUAL_STR)
											{
												bShowRedFlag = true;
											}
											if (this.bIsYJCSFlag)
											{
												goto IL_139F;
											}
											string tempStr;
											if (this.dataGridView1.Rows[i4].Cells[this.iDTResultColNum].Value != null)
											{
												tempStr = this.dataGridView1.Rows[i4].Cells[this.iDTResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
											}
											if (this.dataGridView1.Rows[i4].Cells[this.iJYResultColNum].Value != null)
											{
												tempStr = this.dataGridView1.Rows[i4].Cells[this.iJYResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
											}
											if (this.dataGridView1.Rows[i4].Cells[this.iNYResultColNum].Value == null)
											{
												goto IL_139F;
											}
											tempStr = this.dataGridView1.Rows[i4].Cells[this.iNYResultColNum].Value.ToString();
											if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
											{
												goto IL_13A2;
											}
											goto IL_139F;
											IL_13C7:
											iSelectLastRow = i4;
											break;
											IL_13A2:
											System.Drawing.Color red5 = System.Drawing.Color.Red;
											this.dataGridView1.Rows[i4].DefaultCellStyle.BackColor = red5;
											goto IL_13C7;
											IL_139F:
											if (bShowRedFlag)
											{
												goto IL_13A2;
											}
											goto IL_13C7;
										}
									}
								}
							}
						}
					}
					else if (gCurTestModal == 9)
					{
						for (int i5 = 0; i5 < this.dataGridView1.Rows.Count; i5++)
						{
							string tempDGVAStr = this.dataGridView1.Rows[i5].Cells[1].Value.ToString();
							string tempDGVAPinStr = this.dataGridView1.Rows[i5].Cells[2].Value.ToString();
							for (int j5 = 0; j5 < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; j5++)
							{
								bool bShowRedFlag = false;
								string tempAStr = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].mALJQName;
								string tempAPinStr = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].mnALJQPinNum;
								if (tempAStr == tempDGVAStr && tempAPinStr == tempDGVAPinStr)
								{
									int k5 = 0;
									while (k5 < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count)
									{
										int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k5].mMainDevPinNum;
										if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].mnMainPinNum != iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].mnSecPinNum != iMPinNum)
										{
											k5++;
										}
										else
										{
											this.dataGridView1.Rows[i5].Cells[this.iNYTValueColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].strNYTestValue;
											this.dataGridView1.Rows[i5].Cells[this.iNYResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].strNYTestResult;
											if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].strNYTestResult == ctFormMain.TEST_NOT_QUAL_STR)
											{
												bShowRedFlag = true;
											}
											if (this.bIsYJCSFlag)
											{
												goto IL_1725;
											}
											string tempStr;
											if (this.dataGridView1.Rows[i5].Cells[this.iDTResultColNum].Value != null)
											{
												tempStr = this.dataGridView1.Rows[i5].Cells[this.iDTResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
											}
											if (this.dataGridView1.Rows[i5].Cells[this.iJYResultColNum].Value != null)
											{
												tempStr = this.dataGridView1.Rows[i5].Cells[this.iJYResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
											}
											if (this.dataGridView1.Rows[i5].Cells[this.iNYResultColNum].Value == null)
											{
												goto IL_1725;
											}
											tempStr = this.dataGridView1.Rows[i5].Cells[this.iNYResultColNum].Value.ToString();
											if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
											{
												goto IL_1728;
											}
											goto IL_1725;
											IL_174D:
											iSelectLastRow = i5;
											break;
											IL_1728:
											System.Drawing.Color red6 = System.Drawing.Color.Red;
											this.dataGridView1.Rows[i5].DefaultCellStyle.BackColor = red6;
											goto IL_174D;
											IL_1725:
											if (bShowRedFlag)
											{
												goto IL_1728;
											}
											goto IL_174D;
										}
									}
								}
							}
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
			this.HeadAndTailPinDataFunc(0, iSelectLastRow);
			try
			{
				if (iSelectLastRow != -1)
				{
					for (int i6 = 0; i6 < this.dataGridView1.Rows.Count; i6++)
					{
						if (this.dataGridView1.Rows[i6].Selected)
						{
							this.dataGridView1.Rows[i6].Selected = false;
						}
					}
					this.dataGridView1.Rows[iSelectLastRow].Selected = true;
					if (iSelectLastRow > 16)
					{
						this.dataGridView1.FirstDisplayedScrollingRowIndex = iSelectLastRow - 15;
					}
					else
					{
						this.dataGridView1.FirstDisplayedScrollingRowIndex = 0;
					}
				}
			}
			catch (System.Exception ex2)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex2.StackTrace);
			}
		}
		public void EmulationModeSetTestDataFunc(int iTestModalIndex)
		{
			try
			{
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				if (!kLineTestProcessor.bEmulationMode)
				{
					return;
				}
				int iEMSetTestDataIndex = kLineTestProcessor.mpDevComm.iEMSetTestDataIndex;
				if (iTestModalIndex != 0)
				{
					if (iTestModalIndex != 1)
					{
						if (iTestModalIndex == 2)
						{
							if (this.bCurrFastTestFlag)
							{
								for (int i = 0; i < this.iHintRecordNum; i++)
								{
									TestCmdMap tempcmdinfo = new TestCmdMap();
									if (i == 0)
									{
										tempcmdinfo.mdTestResult = 1000000.0;
									}
									else
									{
										tempcmdinfo.mdTestResult = ((double)i * 0.1 + 1.0) * 1000.0 * 1000.0;
									}
									if (this.bSelfStudyPinTestFlag)
									{
										tempcmdinfo.mMainDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[i].mnMainPinNum;
										tempcmdinfo.mSecDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[i].mnSecPinNum;
									}
									else
									{
										tempcmdinfo.mMainDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoArray[i].mnMainPinNum;
										tempcmdinfo.mSecDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoArray[i].mnSecPinNum;
									}
									this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Add(tempcmdinfo);
								}
							}
							else
							{
								TestCmdMap tempcmdinfo = new TestCmdMap();
								if (iEMSetTestDataIndex == 0)
								{
									tempcmdinfo.mdTestResult = 1000000.0;
								}
								else
								{
									tempcmdinfo.mdTestResult = ((double)iEMSetTestDataIndex * 0.1 + 1.0) * 1000.0 * 1000.0;
								}
								if (this.bSelfStudyPinTestFlag)
								{
									if (iEMSetTestDataIndex < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count)
									{
										tempcmdinfo.mMainDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[iEMSetTestDataIndex].mnMainPinNum;
										tempcmdinfo.mSecDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[iEMSetTestDataIndex].mnSecPinNum;
										this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Add(tempcmdinfo);
									}
								}
								else if (iEMSetTestDataIndex < this.gLineTestProcessor.gDLPinConnectInfoArray.Count)
								{
									tempcmdinfo.mMainDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoArray[iEMSetTestDataIndex].mnMainPinNum;
									tempcmdinfo.mSecDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoArray[iEMSetTestDataIndex].mnSecPinNum;
									this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Add(tempcmdinfo);
								}
							}
						}
					}
					else if (this.bCurrFastTestFlag)
					{
						for (int j = 0; j < this.iHintRecordNum; j++)
						{
							TestCmdMap tempcmdinfo = new TestCmdMap();
							if (j == 0)
							{
								tempcmdinfo.mdTestResult = 18000.0;
							}
							else
							{
								tempcmdinfo.mdTestResult = (double)(j * 1000) + 19000.0;
							}
							if (this.bSelfStudyPinTestFlag)
							{
								tempcmdinfo.mMainDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j].mnMainPinNum;
								tempcmdinfo.mSecDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j].mnSecPinNum;
							}
							else
							{
								tempcmdinfo.mMainDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnMainPinNum;
								tempcmdinfo.mSecDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnSecPinNum;
							}
							this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Add(tempcmdinfo);
						}
					}
					else
					{
						TestCmdMap tempcmdinfo = new TestCmdMap();
						if (iEMSetTestDataIndex == 0)
						{
							tempcmdinfo.mdTestResult = 18000.0;
						}
						else
						{
							tempcmdinfo.mdTestResult = (double)(iEMSetTestDataIndex * 1000) + 19000.0;
						}
						if (this.bSelfStudyPinTestFlag)
						{
							if (iEMSetTestDataIndex < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count)
							{
								tempcmdinfo.mMainDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[iEMSetTestDataIndex].mnMainPinNum;
								tempcmdinfo.mSecDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[iEMSetTestDataIndex].mnSecPinNum;
								this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Add(tempcmdinfo);
							}
						}
						else if (iEMSetTestDataIndex < this.gLineTestProcessor.gDLPinConnectInfoArray.Count)
						{
							tempcmdinfo.mMainDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoArray[iEMSetTestDataIndex].mnMainPinNum;
							tempcmdinfo.mSecDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoArray[iEMSetTestDataIndex].mnSecPinNum;
							this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Add(tempcmdinfo);
						}
					}
				}
				else if (this.bSelfStudyPinTestFlag)
				{
					for (int k = 0; k < this.iHintRecordNum; k++)
					{
						TestCmdMap tempcmdinfo = new TestCmdMap();
						tempcmdinfo.mdTestResult = (double)k * 0.01 + 1.0;
						tempcmdinfo.mMainDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[k].mnMainPinNum;
						tempcmdinfo.mSecDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[k].mnSecPinNum;
						this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Add(tempcmdinfo);
					}
				}
				else
				{
					for (int l = 0; l < this.iHintRecordNum; l++)
					{
						TestCmdMap tempcmdinfo = new TestCmdMap();
						tempcmdinfo.mdTestResult = (double)l * 0.01 + 1.0;
						tempcmdinfo.mMainDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoArray[l].mnMainPinNum;
						tempcmdinfo.mSecDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoArray[l].mnSecPinNum;
						this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Add(tempcmdinfo);
					}
				}
			}
			catch (System.Exception arg_5AA_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5AA_0.StackTrace);
			}
			this.gLineTestProcessor.mpDevComm.iEMSetTestDataIndex = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count;
			try
			{
				KLineTestProcessor kLineTestProcessor2 = this.gLineTestProcessor;
				int iEMSetTestDataIndex2 = kLineTestProcessor2.mpDevComm.iEMSetTestDataIndex;
				int num = this.iHintRecordNum;
				int iTemp = iEMSetTestDataIndex2 * 100 / num;
				if (iTemp <= 0)
				{
					iTemp++;
				}
				if (iTemp >= 100)
				{
					iTemp = ((iEMSetTestDataIndex2 == num) ? 100 : 99);
				}
				kLineTestProcessor2.iTestPreValue = iTemp;
			}
			catch (System.Exception arg_632_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_632_0.StackTrace);
			}
		}
		public void TestDataShowUIFunc()
		{
			try
			{
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				if (kLineTestProcessor.bEmulationMode)
				{
					int gCurTestModal = kLineTestProcessor.gCurTestModal;
					if (gCurTestModal == 3)
					{
						this.EmulationModeSetTestDataFunc(0);
					}
					else if (gCurTestModal == 4)
					{
						this.EmulationModeSetTestDataFunc(1);
					}
					else if (gCurTestModal == 9)
					{
						this.EmulationModeSetTestDataFunc(2);
					}
				}
				if (this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count <= 0)
				{
					return;
				}
				this.GetTestDataResultStrFunc();
				this.RefreshTestUIDataFunc();
			}
			catch (System.Exception arg_6C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_6C_0.StackTrace);
			}
			try
			{
				KLineTestProcessor this2 = this.gLineTestProcessor;
				if (this2.bEmulationMode)
				{
					int gCurTestModal2 = this2.gCurTestModal;
					if (gCurTestModal2 == 3)
					{
						this2.mpDevComm.mParseCmd.mUpdataCmdArray.Clear();
					}
					else if (gCurTestModal2 == 4)
					{
						if (this2.mpDevComm.mParseCmd.mUpdataCmdArray.Count == this.iHintRecordNum)
						{
							this.gLineTestProcessor.iTestPreValue = 100;
							this.gLineTestProcessor.mhCurThreadFlagJY = false;
							this.gLineTestProcessor.mbKeepRun = false;
							this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Clear();
						}
					}
					else if (gCurTestModal2 == 9 && this2.mpDevComm.mParseCmd.mUpdataCmdArray.Count == this.iHintRecordNum)
					{
						this.gLineTestProcessor.iTestPreValue = 100;
						this.gLineTestProcessor.mbKeepRun = false;
						this.gLineTestProcessor.mhCurThreadFlagNY = false;
						this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Clear();
					}
				}
			}
			catch (System.Exception arg_178_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_178_0.StackTrace);
			}
		}
		public void RefreshFastTestUIDataFunc()
		{
			int iSelectLastRow = -1;
			try
			{
				if (!this.bSelfStudyPinTestFlag)
				{
					int gCurTestModal = this.gLineTestProcessor.gCurTestModal;
					if (gCurTestModal == 3)
					{
						for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
						{
							string tempDGVAStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
							string tempDGVAPinStr = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
							string tempDGVBStr = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
							string tempDGVBPinStr = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
							for (int j = 0; j < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; j++)
							{
								if (this.gLineTestProcessor.gDLPinConnectInfoArray[j].iDTTestFlag == 1)
								{
									bool bShowRedFlag = false;
									string tempAStr = this.gLineTestProcessor.gDLPinConnectInfoArray[j].mALJQName;
									string tempAPinStr = this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnALJQPinNum;
									string tempBStr = this.gLineTestProcessor.gDLPinConnectInfoArray[j].mBLJQName;
									string tempBPinStr = this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnBLJQPinNum;
									if (tempAStr == tempDGVAStr && tempAPinStr == tempDGVAPinStr && tempBStr == tempDGVBStr && tempBPinStr == tempDGVBPinStr)
									{
										int k = 0;
										while (k < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count)
										{
											int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k].mMainDevPinNum;
											int iSPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k].mSecDevPinNum;
											if ((int)this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnMainPinNum == iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoArray[j].mnSecPinNum == iSPinNum)
											{
												this.dataGridView1.Rows[i].Cells[this.iDTTValueColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[j].strDTTestValue;
												this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[j].strDTTestResult;
												if (this.gLineTestProcessor.gDLPinConnectInfoArray[j].strDTTestResult == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
												if (this.bIsYJCSFlag)
												{
													goto IL_47D;
												}
												string tempStr;
												if (this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value != null)
												{
													tempStr = this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value.ToString();
													if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
													{
														bShowRedFlag = true;
													}
												}
												if (this.dataGridView1.Rows[i].Cells[this.iJYResultColNum].Value != null)
												{
													tempStr = this.dataGridView1.Rows[i].Cells[this.iJYResultColNum].Value.ToString();
													if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
													{
														bShowRedFlag = true;
													}
												}
												if (this.dataGridView1.Rows[i].Cells[this.iNYResultColNum].Value == null)
												{
													goto IL_47D;
												}
												tempStr = this.dataGridView1.Rows[i].Cells[this.iNYResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													goto IL_480;
												}
												goto IL_47D;
												IL_4A4:
												iSelectLastRow = i;
												break;
												IL_480:
												System.Drawing.Color red = System.Drawing.Color.Red;
												this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = red;
												goto IL_4A4;
												IL_47D:
												if (bShowRedFlag)
												{
													goto IL_480;
												}
												goto IL_4A4;
											}
											else
											{
												k++;
											}
										}
									}
								}
							}
						}
					}
					else if (gCurTestModal == 4)
					{
						for (int l = 0; l < this.dataGridView1.Rows.Count; l++)
						{
							string tempDGVAStr = this.dataGridView1.Rows[l].Cells[1].Value.ToString();
							for (int m = 0; m < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; m++)
							{
								if (this.gLineTestProcessor.gDLPinConnectInfoArray[m].iJYTestFlag == 1)
								{
									bool bShowRedFlag = false;
									if (this.gLineTestProcessor.gDLPinConnectInfoArray[m].mALJQName == tempDGVAStr)
									{
										int n = 0;
										while (n < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count)
										{
											int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].mMainDevPinNum;
											if ((int)this.gLineTestProcessor.gDLPinConnectInfoArray[m].mnMainPinNum != iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoArray[m].mnSecPinNum != iMPinNum)
											{
												n++;
											}
											else
											{
												this.dataGridView1.Rows[l].Cells[this.iJYTValueColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[m].strJYTestValue;
												this.dataGridView1.Rows[l].Cells[this.iJYResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[m].strJYTestResult;
												if (this.gLineTestProcessor.gDLPinConnectInfoArray[m].strJYTestResult == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
												if (this.bIsYJCSFlag)
												{
													goto IL_7D6;
												}
												string tempStr;
												if (this.dataGridView1.Rows[l].Cells[this.iDTResultColNum].Value != null)
												{
													tempStr = this.dataGridView1.Rows[l].Cells[this.iDTResultColNum].Value.ToString();
													if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
													{
														bShowRedFlag = true;
													}
												}
												if (this.dataGridView1.Rows[l].Cells[this.iJYResultColNum].Value != null)
												{
													tempStr = this.dataGridView1.Rows[l].Cells[this.iJYResultColNum].Value.ToString();
													if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
													{
														bShowRedFlag = true;
													}
												}
												if (this.dataGridView1.Rows[l].Cells[this.iNYResultColNum].Value == null)
												{
													goto IL_7D6;
												}
												tempStr = this.dataGridView1.Rows[l].Cells[this.iNYResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													goto IL_7D9;
												}
												goto IL_7D6;
												IL_7FE:
												iSelectLastRow = l;
												break;
												IL_7D9:
												System.Drawing.Color red2 = System.Drawing.Color.Red;
												this.dataGridView1.Rows[l].DefaultCellStyle.BackColor = red2;
												goto IL_7FE;
												IL_7D6:
												if (bShowRedFlag)
												{
													goto IL_7D9;
												}
												goto IL_7FE;
											}
										}
									}
								}
							}
						}
					}
					else if (gCurTestModal == 9)
					{
						for (int i2 = 0; i2 < this.dataGridView1.Rows.Count; i2++)
						{
							string tempDGVAStr = this.dataGridView1.Rows[i2].Cells[1].Value.ToString();
							string tempDGVAPinStr = this.dataGridView1.Rows[i2].Cells[2].Value.ToString();
							for (int j2 = 0; j2 < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; j2++)
							{
								if (this.gLineTestProcessor.gDLPinConnectInfoArray[j2].iNYTestFlag == 1)
								{
									bool bShowRedFlag = false;
									string tempAStr = this.gLineTestProcessor.gDLPinConnectInfoArray[j2].mALJQName;
									string tempAPinStr = this.gLineTestProcessor.gDLPinConnectInfoArray[j2].mnALJQPinNum;
									if (tempAStr == tempDGVAStr && tempAPinStr == tempDGVAPinStr)
									{
										int k2 = 0;
										while (k2 < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count)
										{
											int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].mMainDevPinNum;
											if ((int)this.gLineTestProcessor.gDLPinConnectInfoArray[j2].mnMainPinNum != iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoArray[j2].mnSecPinNum != iMPinNum)
											{
												k2++;
											}
											else
											{
												this.dataGridView1.Rows[i2].Cells[this.iNYTValueColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[j2].strNYTestValue;
												this.dataGridView1.Rows[i2].Cells[this.iNYResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoArray[j2].strNYTestResult;
												if (this.gLineTestProcessor.gDLPinConnectInfoArray[j2].strNYTestResult == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
												if (this.bIsYJCSFlag)
												{
													goto IL_B7B;
												}
												string tempStr;
												if (this.dataGridView1.Rows[i2].Cells[this.iDTResultColNum].Value != null)
												{
													tempStr = this.dataGridView1.Rows[i2].Cells[this.iDTResultColNum].Value.ToString();
													if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
													{
														bShowRedFlag = true;
													}
												}
												if (this.dataGridView1.Rows[i2].Cells[this.iJYResultColNum].Value != null)
												{
													tempStr = this.dataGridView1.Rows[i2].Cells[this.iJYResultColNum].Value.ToString();
													if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
													{
														bShowRedFlag = true;
													}
												}
												if (this.dataGridView1.Rows[i2].Cells[this.iNYResultColNum].Value == null)
												{
													goto IL_B7B;
												}
												tempStr = this.dataGridView1.Rows[i2].Cells[this.iNYResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													goto IL_B7E;
												}
												goto IL_B7B;
												IL_BA3:
												iSelectLastRow = i2;
												break;
												IL_B7E:
												System.Drawing.Color red3 = System.Drawing.Color.Red;
												this.dataGridView1.Rows[i2].DefaultCellStyle.BackColor = red3;
												goto IL_BA3;
												IL_B7B:
												if (bShowRedFlag)
												{
													goto IL_B7E;
												}
												goto IL_BA3;
											}
										}
									}
								}
							}
						}
					}
				}
				else
				{
					int gCurTestModal = this.gLineTestProcessor.gCurTestModal;
					if (gCurTestModal == 3)
					{
						for (int i3 = 0; i3 < this.dataGridView1.Rows.Count; i3++)
						{
							string tempDGVAStr = this.dataGridView1.Rows[i3].Cells[1].Value.ToString();
							string tempDGVAPinStr = this.dataGridView1.Rows[i3].Cells[2].Value.ToString();
							string tempDGVBStr = this.dataGridView1.Rows[i3].Cells[3].Value.ToString();
							string tempDGVBPinStr = this.dataGridView1.Rows[i3].Cells[4].Value.ToString();
							for (int j3 = 0; j3 < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; j3++)
							{
								bool bShowRedFlag = false;
								string tempAStr = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j3].mALJQName;
								string tempAPinStr = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j3].mnALJQPinNum;
								string tempBStr = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j3].mBLJQName;
								string tempBPinStr = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j3].mnBLJQPinNum;
								if (tempAStr == tempDGVAStr && tempAPinStr == tempDGVAPinStr && tempBStr == tempDGVBStr && tempBPinStr == tempDGVBPinStr)
								{
									int k3 = 0;
									while (k3 < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count)
									{
										int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k3].mMainDevPinNum;
										int iSPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k3].mSecDevPinNum;
										if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j3].mnMainPinNum == iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j3].mnSecPinNum == iSPinNum)
										{
											this.dataGridView1.Rows[i3].Cells[this.iDTTValueColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j3].strDTTestValue;
											this.dataGridView1.Rows[i3].Cells[this.iDTResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j3].strDTTestResult;
											if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j3].strDTTestResult == ctFormMain.TEST_NOT_QUAL_STR)
											{
												bShowRedFlag = true;
											}
											if (this.bIsYJCSFlag)
											{
												goto IL_FBD;
											}
											string tempStr;
											if (this.dataGridView1.Rows[i3].Cells[this.iDTResultColNum].Value != null)
											{
												tempStr = this.dataGridView1.Rows[i3].Cells[this.iDTResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
											}
											if (this.dataGridView1.Rows[i3].Cells[this.iJYResultColNum].Value != null)
											{
												tempStr = this.dataGridView1.Rows[i3].Cells[this.iJYResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
											}
											if (this.dataGridView1.Rows[i3].Cells[this.iNYResultColNum].Value == null)
											{
												goto IL_FBD;
											}
											tempStr = this.dataGridView1.Rows[i3].Cells[this.iNYResultColNum].Value.ToString();
											if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
											{
												goto IL_FC0;
											}
											goto IL_FBD;
											IL_FE4:
											iSelectLastRow = i3;
											break;
											IL_FC0:
											System.Drawing.Color red4 = System.Drawing.Color.Red;
											this.dataGridView1.Rows[i3].DefaultCellStyle.BackColor = red4;
											goto IL_FE4;
											IL_FBD:
											if (bShowRedFlag)
											{
												goto IL_FC0;
											}
											goto IL_FE4;
										}
										else
										{
											k3++;
										}
									}
								}
							}
						}
					}
					else if (gCurTestModal == 4)
					{
						for (int i4 = 0; i4 < this.dataGridView1.Rows.Count; i4++)
						{
							string tempDGVAStr = this.dataGridView1.Rows[i4].Cells[1].Value.ToString();
							for (int j4 = 0; j4 < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; j4++)
							{
								bool bShowRedFlag = false;
								if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].mALJQName == tempDGVAStr)
								{
									int k4 = 0;
									while (k4 < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count)
									{
										int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k4].mMainDevPinNum;
										if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].mnMainPinNum != iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].mnSecPinNum != iMPinNum)
										{
											k4++;
										}
										else
										{
											this.dataGridView1.Rows[i4].Cells[this.iJYTValueColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].strJYTestValue;
											this.dataGridView1.Rows[i4].Cells[this.iJYResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].strJYTestResult;
											if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j4].strJYTestResult == ctFormMain.TEST_NOT_QUAL_STR)
											{
												bShowRedFlag = true;
											}
											if (this.bIsYJCSFlag)
											{
												goto IL_12F7;
											}
											string tempStr;
											if (this.dataGridView1.Rows[i4].Cells[this.iDTResultColNum].Value != null)
											{
												tempStr = this.dataGridView1.Rows[i4].Cells[this.iDTResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
											}
											if (this.dataGridView1.Rows[i4].Cells[this.iJYResultColNum].Value != null)
											{
												tempStr = this.dataGridView1.Rows[i4].Cells[this.iJYResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
											}
											if (this.dataGridView1.Rows[i4].Cells[this.iNYResultColNum].Value == null)
											{
												goto IL_12F7;
											}
											tempStr = this.dataGridView1.Rows[i4].Cells[this.iNYResultColNum].Value.ToString();
											if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
											{
												goto IL_12FA;
											}
											goto IL_12F7;
											IL_131F:
											iSelectLastRow = i4;
											break;
											IL_12FA:
											System.Drawing.Color red5 = System.Drawing.Color.Red;
											this.dataGridView1.Rows[i4].DefaultCellStyle.BackColor = red5;
											goto IL_131F;
											IL_12F7:
											if (bShowRedFlag)
											{
												goto IL_12FA;
											}
											goto IL_131F;
										}
									}
								}
							}
						}
					}
					else if (gCurTestModal == 9)
					{
						for (int i5 = 0; i5 < this.dataGridView1.Rows.Count; i5++)
						{
							string tempDGVAStr = this.dataGridView1.Rows[i5].Cells[1].Value.ToString();
							string tempDGVAPinStr = this.dataGridView1.Rows[i5].Cells[2].Value.ToString();
							for (int j5 = 0; j5 < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; j5++)
							{
								bool bShowRedFlag = false;
								string tempAStr = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].mALJQName;
								string tempAPinStr = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].mnALJQPinNum;
								if (tempAStr == tempDGVAStr && tempAPinStr == tempDGVAPinStr)
								{
									int k5 = 0;
									while (k5 < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count)
									{
										int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k5].mMainDevPinNum;
										if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].mnMainPinNum != iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].mnSecPinNum != iMPinNum)
										{
											k5++;
										}
										else
										{
											this.dataGridView1.Rows[i5].Cells[this.iNYTValueColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].strNYTestValue;
											this.dataGridView1.Rows[i5].Cells[this.iNYResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].strNYTestResult;
											if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j5].strNYTestResult == ctFormMain.TEST_NOT_QUAL_STR)
											{
												bShowRedFlag = true;
											}
											if (this.bIsYJCSFlag)
											{
												goto IL_167D;
											}
											string tempStr;
											if (this.dataGridView1.Rows[i5].Cells[this.iDTResultColNum].Value != null)
											{
												tempStr = this.dataGridView1.Rows[i5].Cells[this.iDTResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
											}
											if (this.dataGridView1.Rows[i5].Cells[this.iJYResultColNum].Value != null)
											{
												tempStr = this.dataGridView1.Rows[i5].Cells[this.iJYResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
											}
											if (this.dataGridView1.Rows[i5].Cells[this.iNYResultColNum].Value == null)
											{
												goto IL_167D;
											}
											tempStr = this.dataGridView1.Rows[i5].Cells[this.iNYResultColNum].Value.ToString();
											if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
											{
												goto IL_1680;
											}
											goto IL_167D;
											IL_16A5:
											iSelectLastRow = i5;
											break;
											IL_1680:
											System.Drawing.Color red6 = System.Drawing.Color.Red;
											this.dataGridView1.Rows[i5].DefaultCellStyle.BackColor = red6;
											goto IL_16A5;
											IL_167D:
											if (bShowRedFlag)
											{
												goto IL_1680;
											}
											goto IL_16A5;
										}
									}
								}
							}
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
			this.HeadAndTailPinDataFunc(0, iSelectLastRow);
			try
			{
				if (iSelectLastRow != -1)
				{
					for (int i6 = 0; i6 < this.dataGridView1.Rows.Count; i6++)
					{
						if (this.dataGridView1.Rows[i6].Selected)
						{
							this.dataGridView1.Rows[i6].Selected = false;
						}
					}
					this.dataGridView1.Rows[iSelectLastRow].Selected = true;
					if (iSelectLastRow > 16)
					{
						this.dataGridView1.FirstDisplayedScrollingRowIndex = iSelectLastRow - 15;
					}
					else
					{
						this.dataGridView1.FirstDisplayedScrollingRowIndex = 0;
					}
				}
			}
			catch (System.Exception ex2)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex2.StackTrace);
			}
		}
		public void FastTestDataShowUIFunc()
		{
			try
			{
				if (this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count > 0)
				{
					this.GetFastTestDataResultStrFunc();
					this.RefreshFastTestUIDataFunc();
				}
			}
			catch (System.Exception arg_2D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2D_0.StackTrace);
			}
		}
		public void RefreshChoiceTestUIDataFunc()
		{
			int iSelectLastRow = -1;
			try
			{
				int gCurTestModal = this.gLineTestProcessor.gCurTestModal;
				if (gCurTestModal == 3)
				{
					for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
					{
						string tempDGVAStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
						string tempDGVAPinStr = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
						string tempDGVBStr = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
						string tempDGVBPinStr = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
						for (int j = 0; j < this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count; j++)
						{
							if (this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].iDTTestFlag == 1)
							{
								bool bShowRedFlag = false;
								string tempAStr = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].mALJQName;
								string tempAPinStr = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].mnALJQPinNum;
								string tempBStr = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].mBLJQName;
								string tempBPinStr = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].mnBLJQPinNum;
								if (tempAStr == tempDGVAStr && tempAPinStr == tempDGVAPinStr && tempBStr == tempDGVBStr && tempBPinStr == tempDGVBPinStr)
								{
									int k = 0;
									while (k < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count)
									{
										int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k].mMainDevPinNum;
										int iSPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k].mSecDevPinNum;
										if ((int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].mnMainPinNum == iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].mnSecPinNum == iSPinNum)
										{
											this.dataGridView1.Rows[i].Cells[this.iDTTValueColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].strDTTestValue;
											this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].strDTTestResult;
											if (this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].strDTTestResult == ctFormMain.TEST_NOT_QUAL_STR)
											{
												bShowRedFlag = true;
											}
											if (this.bIsYJCSFlag)
											{
												goto IL_472;
											}
											string tempStr;
											if (this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value != null)
											{
												tempStr = this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
											}
											if (this.dataGridView1.Rows[i].Cells[this.iJYResultColNum].Value != null)
											{
												tempStr = this.dataGridView1.Rows[i].Cells[this.iJYResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
											}
											if (this.dataGridView1.Rows[i].Cells[this.iNYResultColNum].Value == null)
											{
												goto IL_472;
											}
											tempStr = this.dataGridView1.Rows[i].Cells[this.iNYResultColNum].Value.ToString();
											if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
											{
												goto IL_475;
											}
											goto IL_472;
											IL_499:
											iSelectLastRow = i;
											break;
											IL_475:
											System.Drawing.Color red = System.Drawing.Color.Red;
											this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = red;
											goto IL_499;
											IL_472:
											if (bShowRedFlag)
											{
												goto IL_475;
											}
											goto IL_499;
										}
										else
										{
											k++;
										}
									}
								}
							}
						}
					}
				}
				else if (gCurTestModal == 4)
				{
					for (int l = 0; l < this.dataGridView1.Rows.Count; l++)
					{
						string tempDGVAStr = this.dataGridView1.Rows[l].Cells[1].Value.ToString();
						string tempDGVAPinStr = this.dataGridView1.Rows[l].Cells[2].Value.ToString();
						for (int m = 0; m < this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count; m++)
						{
							if (this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[m].iJYTestFlag == 1)
							{
								bool bShowRedFlag = false;
								string tempAStr = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[m].mALJQName;
								string tempAPinStr = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[m].mnALJQPinNum;
								if (tempAStr == tempDGVAStr && tempAPinStr == tempDGVAPinStr)
								{
									int n = 0;
									while (n < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count)
									{
										int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[n].mMainDevPinNum;
										if ((int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[m].mnMainPinNum != iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[m].mnSecPinNum != iMPinNum)
										{
											n++;
										}
										else
										{
											this.dataGridView1.Rows[l].Cells[this.iJYTValueColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[m].strJYTestValue;
											this.dataGridView1.Rows[l].Cells[this.iJYResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[m].strJYTestResult;
											if (this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[m].strJYTestResult == ctFormMain.TEST_NOT_QUAL_STR)
											{
												bShowRedFlag = true;
											}
											if (this.bIsYJCSFlag)
											{
												goto IL_81F;
											}
											string tempStr;
											if (this.dataGridView1.Rows[l].Cells[this.iDTResultColNum].Value != null)
											{
												tempStr = this.dataGridView1.Rows[l].Cells[this.iDTResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
											}
											if (this.dataGridView1.Rows[l].Cells[this.iJYResultColNum].Value != null)
											{
												tempStr = this.dataGridView1.Rows[l].Cells[this.iJYResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
											}
											if (this.dataGridView1.Rows[l].Cells[this.iNYResultColNum].Value == null)
											{
												goto IL_81F;
											}
											tempStr = this.dataGridView1.Rows[l].Cells[this.iNYResultColNum].Value.ToString();
											if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
											{
												goto IL_822;
											}
											goto IL_81F;
											IL_847:
											iSelectLastRow = l;
											break;
											IL_822:
											System.Drawing.Color red2 = System.Drawing.Color.Red;
											this.dataGridView1.Rows[l].DefaultCellStyle.BackColor = red2;
											goto IL_847;
											IL_81F:
											if (bShowRedFlag)
											{
												goto IL_822;
											}
											goto IL_847;
										}
									}
								}
							}
						}
					}
				}
				else if (gCurTestModal == 9)
				{
					for (int i2 = 0; i2 < this.dataGridView1.Rows.Count; i2++)
					{
						string tempDGVAStr = this.dataGridView1.Rows[i2].Cells[1].Value.ToString();
						string tempDGVAPinStr = this.dataGridView1.Rows[i2].Cells[2].Value.ToString();
						for (int j2 = 0; j2 < this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count; j2++)
						{
							if (this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j2].iNYTestFlag == 1)
							{
								bool bShowRedFlag = false;
								string tempAStr = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j2].mALJQName;
								string tempAPinStr = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j2].mnALJQPinNum;
								if (tempAStr == tempDGVAStr && tempAPinStr == tempDGVAPinStr)
								{
									int k2 = 0;
									while (k2 < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count)
									{
										int iMPinNum = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k2].mMainDevPinNum;
										if ((int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j2].mnMainPinNum != iMPinNum && (int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j2].mnSecPinNum != iMPinNum)
										{
											k2++;
										}
										else
										{
											this.dataGridView1.Rows[i2].Cells[this.iNYTValueColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j2].strNYTestValue;
											this.dataGridView1.Rows[i2].Cells[this.iNYResultColNum].Value = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j2].strNYTestResult;
											if (this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j2].strNYTestResult == ctFormMain.TEST_NOT_QUAL_STR)
											{
												bShowRedFlag = true;
											}
											if (this.bIsYJCSFlag)
											{
												goto IL_BB8;
											}
											string tempStr;
											if (this.dataGridView1.Rows[i2].Cells[this.iDTResultColNum].Value != null)
											{
												tempStr = this.dataGridView1.Rows[i2].Cells[this.iDTResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
											}
											if (this.dataGridView1.Rows[i2].Cells[this.iJYResultColNum].Value != null)
											{
												tempStr = this.dataGridView1.Rows[i2].Cells[this.iJYResultColNum].Value.ToString();
												if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
												{
													bShowRedFlag = true;
												}
											}
											if (this.dataGridView1.Rows[i2].Cells[this.iNYResultColNum].Value == null)
											{
												goto IL_BB8;
											}
											tempStr = this.dataGridView1.Rows[i2].Cells[this.iNYResultColNum].Value.ToString();
											if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
											{
												goto IL_BBB;
											}
											goto IL_BB8;
											IL_BDF:
											iSelectLastRow = i2;
											break;
											IL_BBB:
											System.Drawing.Color red3 = System.Drawing.Color.Red;
											this.dataGridView1.Rows[i2].DefaultCellStyle.BackColor = red3;
											goto IL_BDF;
											IL_BB8:
											if (bShowRedFlag)
											{
												goto IL_BBB;
											}
											goto IL_BDF;
										}
									}
								}
							}
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
			this.HeadAndTailPinDataFunc(2, iSelectLastRow);
			try
			{
				if (iSelectLastRow != -1)
				{
					for (int i3 = 0; i3 < this.dataGridView1.Rows.Count; i3++)
					{
						if (this.dataGridView1.Rows[i3].Selected)
						{
							this.dataGridView1.Rows[i3].Selected = false;
						}
					}
					this.dataGridView1.Rows[iSelectLastRow].Selected = true;
					if (iSelectLastRow > 16)
					{
						this.dataGridView1.FirstDisplayedScrollingRowIndex = iSelectLastRow - 15;
					}
					else
					{
						this.dataGridView1.FirstDisplayedScrollingRowIndex = 0;
					}
				}
			}
			catch (System.Exception ex2)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex2.StackTrace);
			}
		}
		public void EmulationModeSetTestData_ChoiceTestFunc(int iTestModalIndex)
		{
			try
			{
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				if (!kLineTestProcessor.bEmulationMode)
				{
					return;
				}
				int iEMSetTestDataIndex = kLineTestProcessor.mpDevComm.iEMSetTestDataIndex;
				if (iTestModalIndex != 0)
				{
					if (iTestModalIndex != 1)
					{
						if (iTestModalIndex == 2)
						{
							if (this.bCurrFastTestFlag)
							{
								for (int i = 0; i < this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count; i++)
								{
									TestCmdMap tempcmdinfo = new TestCmdMap();
									if (i == 0)
									{
										tempcmdinfo.mdTestResult = 1000000.0;
									}
									else
									{
										tempcmdinfo.mdTestResult = ((double)iEMSetTestDataIndex * 0.1 + 1.0) * 1000.0 * 1000.0;
									}
									tempcmdinfo.mMainDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[i].mnMainPinNum;
									tempcmdinfo.mSecDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[i].mnSecPinNum;
									this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Add(tempcmdinfo);
								}
							}
							else
							{
								TestCmdMap tempcmdinfo = new TestCmdMap();
								kLineTestProcessor = this.gLineTestProcessor;
								if (kLineTestProcessor.mpDevComm.iEMSetTestDataIndex == 0)
								{
									tempcmdinfo.mdTestResult = 1000000.0;
								}
								else
								{
									tempcmdinfo.mdTestResult = ((double)iEMSetTestDataIndex * 0.1 + 1.0) * 1000.0 * 1000.0;
								}
								if (iEMSetTestDataIndex < kLineTestProcessor.gDLPinConnectInfoChoiceArray.Count)
								{
									tempcmdinfo.mMainDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[iEMSetTestDataIndex].mnMainPinNum;
									tempcmdinfo.mSecDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[iEMSetTestDataIndex].mnSecPinNum;
									this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Add(tempcmdinfo);
								}
							}
						}
					}
					else if (this.bCurrFastTestFlag)
					{
						for (int j = 0; j < this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count; j++)
						{
							TestCmdMap tempcmdinfo = new TestCmdMap();
							if (j == 0)
							{
								tempcmdinfo.mdTestResult = 18000.0;
							}
							else
							{
								tempcmdinfo.mdTestResult = (double)(j * 1000) + 19000.0;
							}
							tempcmdinfo.mMainDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].mnMainPinNum;
							tempcmdinfo.mSecDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[j].mnSecPinNum;
							this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Add(tempcmdinfo);
						}
					}
					else
					{
						TestCmdMap tempcmdinfo = new TestCmdMap();
						kLineTestProcessor = this.gLineTestProcessor;
						int iEMSetTestDataIndex2 = kLineTestProcessor.mpDevComm.iEMSetTestDataIndex;
						if (iEMSetTestDataIndex2 == 0)
						{
							tempcmdinfo.mdTestResult = 18000.0;
						}
						else
						{
							tempcmdinfo.mdTestResult = (double)(iEMSetTestDataIndex2 * 1000) + 19000.0;
						}
						if (iEMSetTestDataIndex < kLineTestProcessor.gDLPinConnectInfoChoiceArray.Count)
						{
							tempcmdinfo.mMainDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[iEMSetTestDataIndex].mnMainPinNum;
							tempcmdinfo.mSecDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[iEMSetTestDataIndex].mnSecPinNum;
							this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Add(tempcmdinfo);
						}
					}
				}
				else
				{
					for (int k = 0; k < this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count; k++)
					{
						TestCmdMap tempcmdinfo = new TestCmdMap();
						tempcmdinfo.mdTestResult = (double)k * 0.01 + 1.0;
						tempcmdinfo.mMainDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[k].mnMainPinNum;
						tempcmdinfo.mSecDevPinNum = (int)this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[k].mnSecPinNum;
						this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Add(tempcmdinfo);
					}
				}
			}
			catch (System.Exception arg_3DB_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3DB_0.StackTrace);
			}
			this.gLineTestProcessor.mpDevComm.iEMSetTestDataIndex = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count;
			try
			{
				KLineTestProcessor kLineTestProcessor2 = this.gLineTestProcessor;
				int iTemp = kLineTestProcessor2.mpDevComm.iEMSetTestDataIndex * 100 / this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count;
				if (iTemp <= 0)
				{
					iTemp++;
				}
				if (iTemp >= 100)
				{
					kLineTestProcessor2 = this.gLineTestProcessor;
					iTemp = ((kLineTestProcessor2.mpDevComm.iEMSetTestDataIndex == kLineTestProcessor2.gDLPinConnectInfoChoiceArray.Count) ? 100 : 99);
				}
				kLineTestProcessor2.iTestPreValue = iTemp;
			}
			catch (System.Exception arg_481_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_481_0.StackTrace);
			}
		}
		public void ChoiceTestDataShowUIFunc()
		{
			try
			{
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				if (kLineTestProcessor.bEmulationMode)
				{
					int gCurTestModal = kLineTestProcessor.gCurTestModal;
					if (gCurTestModal == 3)
					{
						this.EmulationModeSetTestData_ChoiceTestFunc(0);
					}
					else if (gCurTestModal == 4)
					{
						this.EmulationModeSetTestData_ChoiceTestFunc(1);
					}
					else if (gCurTestModal == 9)
					{
						this.EmulationModeSetTestData_ChoiceTestFunc(2);
					}
				}
				if (this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count <= 0)
				{
					return;
				}
				this.GetChoiceTestDataResultStrFunc();
				this.RefreshChoiceTestUIDataFunc();
			}
			catch (System.Exception arg_6C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_6C_0.StackTrace);
			}
			try
			{
				KLineTestProcessor this2 = this.gLineTestProcessor;
				if (this2.bEmulationMode)
				{
					int gCurTestModal2 = this2.gCurTestModal;
					if (gCurTestModal2 == 3)
					{
						this2.mpDevComm.mParseCmd.mUpdataCmdArray.Clear();
					}
					else if (gCurTestModal2 == 4)
					{
						if (this2.mpDevComm.mParseCmd.mUpdataCmdArray.Count == this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count)
						{
							this.gLineTestProcessor.iTestPreValue = 100;
							this.gLineTestProcessor.mhCurThreadFlagJY = false;
							this.gLineTestProcessor.mbKeepRun = false;
							this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Clear();
						}
					}
					else if (gCurTestModal2 == 9 && this2.mpDevComm.mParseCmd.mUpdataCmdArray.Count == this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count)
					{
						this.gLineTestProcessor.iTestPreValue = 100;
						this.gLineTestProcessor.mbKeepRun = false;
						this.gLineTestProcessor.mhCurThreadFlagNY = false;
						this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Clear();
					}
				}
			}
			catch (System.Exception arg_18C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_18C_0.StackTrace);
			}
		}
		public void CalcFailCountAndRefreshUIFunc()
		{
			try
			{
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				int gCurTestModal = kLineTestProcessor.gCurTestModal;
				if (gCurTestModal == 3)
				{
					this.iHintDTExcNum = 0;
					for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
					{
						if (this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value != null)
						{
							string tempStr = this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value.ToString();
							if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
							{
								this.iHintDTExcNum++;
							}
						}
					}
				}
				else if (gCurTestModal == 7)
				{
					this.iHintDLExcNum = 0;
					if (kLineTestProcessor.gDLPinConnectInfoDLResultArray != null)
					{
						this.iHintDLExcNum = kLineTestProcessor.gDLPinConnectInfoDLResultArray.Count;
					}
				}
				else if (gCurTestModal == 4)
				{
					this.iHintJYExcNum = 0;
					for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
					{
						if (this.dataGridView1.Rows[j].Cells[this.iJYResultColNum].Value != null)
						{
							string tempStr = this.dataGridView1.Rows[j].Cells[this.iJYResultColNum].Value.ToString();
							if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
							{
								this.iHintJYExcNum++;
							}
						}
					}
				}
				else if (gCurTestModal == 20)
				{
					this.iHintDDJYExcNum = 0;
					if (kLineTestProcessor.gDLPinConnectInfoDDJYArray != null)
					{
						for (int k = 0; k < this.gLineTestProcessor.gDLPinConnectInfoDDJYArray.Count; k++)
						{
							if (this.gLineTestProcessor.gDLPinConnectInfoDDJYArray[k].strDDjyTestResult == ctFormMain.TEST_NOT_QUAL_STR)
							{
								this.iHintDDJYExcNum++;
							}
						}
					}
				}
				else if (gCurTestModal == 9)
				{
					this.iHintNYExcNum = 0;
					for (int l = 0; l < this.dataGridView1.Rows.Count; l++)
					{
						if (this.dataGridView1.Rows[l].Cells[this.iNYResultColNum].Value != null)
						{
							string tempStr = this.dataGridView1.Rows[l].Cells[this.iNYResultColNum].Value.ToString();
							if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
							{
								this.iHintNYExcNum++;
							}
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
			this.RefreshHintLableFunc();
		}
		public void CalcFastTestFailCountFunc()
		{
			try
			{
				if (this.bCurrFastTestFlag)
				{
					KLineTestProcessor this2 = this.gLineTestProcessor;
					int gCurTestModal = this2.gCurTestModal;
					if (gCurTestModal == 4)
					{
						this2.iJYKTFailNum = 0;
						for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
						{
							if (this.dataGridView1.Rows[i].Cells[this.iJYResultColNum].Value != null)
							{
								string tempStr = this.dataGridView1.Rows[i].Cells[this.iJYResultColNum].Value.ToString();
								if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
								{
									this2 = this.gLineTestProcessor;
									this2.iJYKTFailNum++;
								}
							}
						}
					}
					else if (gCurTestModal == 9)
					{
						this2.iNYKTFailNum = 0;
						for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
						{
							if (this.dataGridView1.Rows[j].Cells[this.iNYResultColNum].Value != null)
							{
								string tempStr = this.dataGridView1.Rows[j].Cells[this.iNYResultColNum].Value.ToString();
								if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
								{
									this2 = this.gLineTestProcessor;
									this2.iNYKTFailNum++;
								}
							}
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		public void ResetHVTWaitingTimeFunc()
		{
			try
			{
				if (this.dJY_DCHighVolt > (double)ctFormMain.TEST_INTE_HIGH_VOLT || this.dNY_ACHighVolt > (double)ctFormMain.TEST_INTE_HIGH_VOLT)
				{
					this.iHVTWaitingTime = 0;
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		public void GetTestPreValueFunc()
		{
			try
			{
				if (this.gLineTestProcessor.iTestPreValue > 3)
				{
					int iCount = 0;
					if (this.bChoiceTestFlag)
					{
						int i = 0;
						while (i < this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count)
						{
							KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
							int gCurTestModal = kLineTestProcessor.gCurTestModal;
							if (gCurTestModal == 3)
							{
								if (kLineTestProcessor.gDLPinConnectInfoChoiceArray[i].iDTTestFlag == 1)
								{
									goto IL_DD;
								}
								iCount++;
							}
							else if (gCurTestModal == 4)
							{
								if (kLineTestProcessor.gDLPinConnectInfoChoiceArray[i].iJYTestFlag == 1)
								{
									goto IL_DD;
								}
								iCount++;
							}
							else
							{
								if (gCurTestModal != 9 || kLineTestProcessor.gDLPinConnectInfoChoiceArray[i].iNYTestFlag == 1)
								{
									goto IL_DD;
								}
								iCount++;
							}
							IL_388:
							i++;
							continue;
							IL_DD:
							string tempAStr = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[i].mALJQName;
							string tempAPinStr = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[i].mnALJQPinNum;
							string tempBStr = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[i].mBLJQName;
							string tempBPinStr = this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[i].mnBLJQPinNum;
							int j = 0;
							while (j < this.dataGridView1.Rows.Count)
							{
								string tempDGVAStr = this.dataGridView1.Rows[j].Cells[1].Value.ToString();
								string tempDGVAPinStr = this.dataGridView1.Rows[j].Cells[2].Value.ToString();
								string tempDGVBStr = this.dataGridView1.Rows[j].Cells[3].Value.ToString();
								string tempDGVBPinStr = this.dataGridView1.Rows[j].Cells[4].Value.ToString();
								if (tempAStr == tempDGVAStr && tempAPinStr == tempDGVAPinStr && tempBStr == tempDGVBStr && tempBPinStr == tempDGVBPinStr)
								{
									gCurTestModal = this.gLineTestProcessor.gCurTestModal;
									if (gCurTestModal == 3)
									{
										if (this.dataGridView1.Rows[j].Cells[this.iDTTValueColNum].Value == null)
										{
											break;
										}
										string strTemp = this.dataGridView1.Rows[j].Cells[this.iDTTValueColNum].Value.ToString();
										if (!string.IsNullOrEmpty(strTemp))
										{
											iCount++;
											break;
										}
										break;
									}
									else if (gCurTestModal == 4)
									{
										if (this.dataGridView1.Rows[j].Cells[this.iJYTValueColNum].Value == null)
										{
											break;
										}
										string strTemp = this.dataGridView1.Rows[j].Cells[this.iJYTValueColNum].Value.ToString();
										if (!string.IsNullOrEmpty(strTemp))
										{
											iCount++;
											break;
										}
										break;
									}
									else
									{
										if (gCurTestModal != 9 || this.dataGridView1.Rows[j].Cells[this.iNYTValueColNum].Value == null)
										{
											break;
										}
										string strTemp = this.dataGridView1.Rows[j].Cells[this.iNYTValueColNum].Value.ToString();
										if (!string.IsNullOrEmpty(strTemp))
										{
											iCount++;
											break;
										}
										break;
									}
								}
								else
								{
									j++;
								}
							}
							goto IL_388;
						}
						if (iCount == this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count)
						{
							this.gLineTestProcessor.iTestPreValue = 100;
							this.gLineTestProcessor.bIsTimeOut = true;
							this.gLineTestProcessor.mbKeepRun = false;
						}
					}
					else
					{
						for (int k = 0; k < this.dataGridView1.Rows.Count; k++)
						{
							int gCurTestModal2 = this.gLineTestProcessor.gCurTestModal;
							if (gCurTestModal2 == 3)
							{
								if (this.dataGridView1.Rows[k].Cells[this.iDTTValueColNum].Value != null)
								{
									string strTemp = this.dataGridView1.Rows[k].Cells[this.iDTTValueColNum].Value.ToString();
									if (!string.IsNullOrEmpty(strTemp))
									{
										iCount++;
									}
								}
							}
							else if (gCurTestModal2 == 4)
							{
								if (this.dataGridView1.Rows[k].Cells[this.iJYTValueColNum].Value != null)
								{
									string strTemp = this.dataGridView1.Rows[k].Cells[this.iJYTValueColNum].Value.ToString();
									if (!string.IsNullOrEmpty(strTemp))
									{
										iCount++;
									}
								}
							}
							else if (gCurTestModal2 == 9 && this.dataGridView1.Rows[k].Cells[this.iNYTValueColNum].Value != null)
							{
								string strTemp = this.dataGridView1.Rows[k].Cells[this.iNYTValueColNum].Value.ToString();
								if (!string.IsNullOrEmpty(strTemp))
								{
									iCount++;
								}
							}
						}
						if (iCount == this.dataGridView1.Rows.Count)
						{
							this.gLineTestProcessor.iTestPreValue = 100;
							this.gLineTestProcessor.bIsTimeOut = true;
							this.gLineTestProcessor.mbKeepRun = false;
						}
					}
				}
			}
			catch (System.Exception arg_583_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_583_0.StackTrace);
			}
		}
		private void timer_projectTest_Tick(object sender, System.EventArgs e)
		{
			try
			{
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				if (kLineTestProcessor.mbKeepRun)
				{
					int gCurTestModal = kLineTestProcessor.gCurTestModal;
					if (gCurTestModal == 4 || gCurTestModal == 9)
					{
						if (this.bChoiceTestFlag)
						{
							this.ChoiceTestDataShowUIFunc();
						}
						else
						{
							this.TestDataShowUIFunc();
						}
						this.GetTestPreValueFunc();
					}
					KLineTestProcessor kLineTestProcessor2 = this.gLineTestProcessor;
					int iTestPreValue = kLineTestProcessor2.iTestPreValue;
					if (iTestPreValue >= 100)
					{
						kLineTestProcessor2.iTestPreValue = 100;
					}
					else if (iTestPreValue < 1)
					{
						kLineTestProcessor2.iTestPreValue = iTestPreValue + 1;
					}
					this.progressBar_test.Value = this.gLineTestProcessor.iTestPreValue;
					this.label_progress.Text = System.Convert.ToString(this.gLineTestProcessor.iTestPreValue) + "%";
				}
				else if (kLineTestProcessor.iTestPreValue >= 100)
				{
					this.timer_projectTest.Enabled = false;
					if (this.bChoiceTestFlag)
					{
						this.ChoiceTestDataShowUIFunc();
					}
					else
					{
						this.TestDataShowUIFunc();
					}
					this.CalcFailCountAndRefreshUIFunc();
					KLineTestProcessor e2 = this.gLineTestProcessor;
					if (e2.gCurTestModal == 4 && this.iHintJYExcNum > 0 && e2.iJYTestMethod == 3 && this.bCurrFastTestFlag && !this.bChoiceTestFlag)
					{
						e2.SendStopCmd();
						this.ResetHVTWaitingTimeFunc();
						this.bHVTWaitingFlag = true;
						if (DialogResult.Yes == MessageBox.Show("绝缘测试存在异常!是否进行详细测试?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
						{
							this.bHVTWaitingFlag = false;
							this.bCurrFastTestFlag = false;
							this.StartJYTestFunc();
							return;
						}
					}
					KLineTestProcessor sender2 = this.gLineTestProcessor;
					if (sender2.gCurTestModal == 9 && this.iHintNYExcNum > 0 && sender2.iNYTestMethod == 3 && this.bCurrFastTestFlag && !this.bChoiceTestFlag)
					{
						sender2.SendStopCmd();
						this.ResetHVTWaitingTimeFunc();
						this.bHVTWaitingFlag = true;
						if (DialogResult.Yes == MessageBox.Show("耐压测试存在异常!是否进行详细测试?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
						{
							this.bHVTWaitingFlag = false;
							this.bCurrFastTestFlag = false;
							this.StartNYTestFunc();
							return;
						}
					}
					if (this.gLineTestProcessor.gCurTestModal == 3 && !this.bChoiceTestFlag)
					{
						if (this.bJYTestXCDTFlag)
						{
							if (this.iHintDTExcNum > 0)
							{
								if (DialogResult.OK != MessageBox.Show("导通测试存在异常!您确定要进行绝缘测试吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
								{
									goto IL_3C8;
								}
							}
							else
							{
								if (this.btestDelayFlag)
								{
									this.TestFinishedDisposeFunc();
									KLineTestProcessor kLineTestProcessor3 = this.gLineTestProcessor;
									if (!kLineTestProcessor3.bIsTimeOut)
									{
										this.otsShowInfoStr = "导通测试完成";
									}
									else
									{
										this.otsShowInfoStr = "导通测试终止";
									}
									if (kLineTestProcessor3.bEmulationMode)
									{
										this.otsShowInfoStr = "导通测试完成";
									}
									System.Drawing.Color steelBlue = System.Drawing.Color.SteelBlue;
									this.otsShowInfoColor = steelBlue;
									this.RefreshOTSDisposeFunc();
									this.gLineTestProcessor.SendStopCmd();
									this.btestDelayFlag = false;
									this.timer_projectTest.Interval = 2000;
									this.timer_projectTest.Enabled = true;
									return;
								}
								this.timer_projectTest.Interval = 1000;
							}
							this.StartJYTestFunc();
							return;
						}
						if (this.bNYTestXCDTFlag)
						{
							if (this.iHintDTExcNum > 0)
							{
								if (DialogResult.OK != MessageBox.Show("导通测试存在异常!您确定要进行耐压测试吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
								{
									goto IL_3C8;
								}
							}
							else
							{
								if (this.btestDelayFlag)
								{
									this.TestFinishedDisposeFunc();
									KLineTestProcessor kLineTestProcessor4 = this.gLineTestProcessor;
									if (!kLineTestProcessor4.bIsTimeOut)
									{
										this.otsShowInfoStr = "导通测试完成";
									}
									else
									{
										this.otsShowInfoStr = "导通测试终止";
									}
									if (kLineTestProcessor4.bEmulationMode)
									{
										this.otsShowInfoStr = "导通测试完成";
									}
									System.Drawing.Color steelBlue2 = System.Drawing.Color.SteelBlue;
									this.otsShowInfoColor = steelBlue2;
									this.RefreshOTSDisposeFunc();
									this.gLineTestProcessor.SendStopCmd();
									System.Threading.Thread.Sleep(ctFormMain.SEND_STOP_CMD_NUM);
									this.btestDelayFlag = false;
									this.timer_projectTest.Interval = 2000;
									this.timer_projectTest.Enabled = true;
									return;
								}
								this.timer_projectTest.Interval = 1000;
							}
							this.StartNYTestFunc();
							return;
						}
					}
					IL_3C8:
					this.TestFinishedDisposeFunc();
					KLineTestProcessor kLineTestProcessor5 = this.gLineTestProcessor;
					if (!kLineTestProcessor5.bIsTimeOut)
					{
						this.otsShowInfoStr = "测试完成";
					}
					else
					{
						this.otsShowInfoStr = "测试终止";
					}
					if (kLineTestProcessor5.bEmulationMode)
					{
						this.otsShowInfoStr = "测试完成";
					}
					System.Drawing.Color steelBlue3 = System.Drawing.Color.SteelBlue;
					this.otsShowInfoColor = steelBlue3;
					this.RefreshOTSDisposeFunc();
					if (this.gLineTestProcessor.gCurTestModal != 3 && !this.bHVTWaitingFlag)
					{
						this.ResetHVTWaitingTimeFunc();
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		private void MenuItem_SBJZ_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormDeviceCalibration this2 = new ctFormDeviceCalibration(this.gLineTestProcessor);
				this.deviceCalibrationForm = this2;
				this2.Activate();
				this.deviceCalibrationForm.ShowDialog();
				this.deviceCalibrationForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_34_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_34_0.StackTrace);
			}
		}
		private void MenuItem_StartSelfTest_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormSelfTest this2 = new ctFormSelfTest(this.gLineTestProcessor);
				this.selfTestForm = this2;
				this2.Activate();
				this.selfTestForm.ShowDialog();
				this.selfTestForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_34_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_34_0.StackTrace);
			}
		}
		private void MenuItem_DeviceDebugging_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormDeviceDebugging this2 = this.deviceDebuggingForm;
				if (this2 == null)
				{
					ctFormDeviceDebugging e2 = new ctFormDeviceDebugging(this.gLineTestProcessor);
					this.deviceDebuggingForm = e2;
					e2.Activate();
					this.deviceDebuggingForm.Show();
				}
				else if (this2.bCloseFlag)
				{
					this.deviceDebuggingForm = null;
					this.FreeSystemMemoryResourcesFunc();
					System.Threading.Thread.Sleep(100);
					ctFormDeviceDebugging sender2 = new ctFormDeviceDebugging(this.gLineTestProcessor);
					this.deviceDebuggingForm = sender2;
					sender2.Activate();
					this.deviceDebuggingForm.Show();
				}
				else
				{
					this2.Activate();
				}
			}
			catch (System.Exception arg_7A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_7A_0.StackTrace);
			}
		}
		private void btnClearData_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.bIsTestStatus)
				{
					this.TestBeforeInitFaultInfoFunc();
					for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
					{
						System.Drawing.Color white = System.Drawing.Color.White;
						this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = white;
						this.dataGridView1.Rows[i].Cells[this.iDTTValueColNum].Value = "";
						this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value = "";
						if (this.dataGridView1.Rows[i].Cells[this.iJYTValueColNum].Value != null)
						{
							string tStr = this.dataGridView1.Rows[i].Cells[this.iJYTValueColNum].Value.ToString();
							if (tStr != ctFormMain.UN_TEST_COMM_STR)
							{
								this.dataGridView1.Rows[i].Cells[this.iJYTValueColNum].Value = "";
								this.dataGridView1.Rows[i].Cells[this.iJYResultColNum].Value = "";
							}
						}
						else
						{
							this.dataGridView1.Rows[i].Cells[this.iJYTValueColNum].Value = "";
							this.dataGridView1.Rows[i].Cells[this.iJYResultColNum].Value = "";
						}
						if (this.dataGridView1.Rows[i].Cells[this.iNYTValueColNum].Value != null)
						{
							string tStr = this.dataGridView1.Rows[i].Cells[this.iNYTValueColNum].Value.ToString();
							if (tStr != ctFormMain.UN_TEST_COMM_STR)
							{
								this.dataGridView1.Rows[i].Cells[this.iNYTValueColNum].Value = "";
								this.dataGridView1.Rows[i].Cells[this.iNYResultColNum].Value = "";
							}
						}
						else
						{
							this.dataGridView1.Rows[i].Cells[this.iNYTValueColNum].Value = "";
							this.dataGridView1.Rows[i].Cells[this.iNYResultColNum].Value = "";
						}
					}
					if (!this.bSelfStudyPinTestFlag)
					{
						for (int j = 0; j < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; j++)
						{
							if (this.gLineTestProcessor.gDLPinConnectInfoArray[j].iDTTestFlag != 1)
							{
								this.gLineTestProcessor.gDLPinConnectInfoArray[j].strDTTestValue = ctFormMain.UN_TEST_COMM_STR;
								this.gLineTestProcessor.gDLPinConnectInfoArray[j].strDTTestResult = ctFormMain.UN_TEST_COMM_STR;
							}
							else
							{
								string strDTTestValue = "";
								this.gLineTestProcessor.gDLPinConnectInfoArray[j].strDTTestValue = strDTTestValue;
								string strDTTestResult = "";
								this.gLineTestProcessor.gDLPinConnectInfoArray[j].strDTTestResult = strDTTestResult;
							}
							if (this.gLineTestProcessor.gDLPinConnectInfoArray[j].iJYTestFlag != 1)
							{
								this.gLineTestProcessor.gDLPinConnectInfoArray[j].strJYTestValue = ctFormMain.UN_TEST_COMM_STR;
								this.gLineTestProcessor.gDLPinConnectInfoArray[j].strJYTestResult = ctFormMain.UN_TEST_COMM_STR;
							}
							else
							{
								string strJYTestValue = "";
								this.gLineTestProcessor.gDLPinConnectInfoArray[j].strJYTestValue = strJYTestValue;
								string strJYTestResult = "";
								this.gLineTestProcessor.gDLPinConnectInfoArray[j].strJYTestResult = strJYTestResult;
							}
							if (this.gLineTestProcessor.gDLPinConnectInfoArray[j].iNYTestFlag != 1)
							{
								this.gLineTestProcessor.gDLPinConnectInfoArray[j].strNYTestValue = ctFormMain.UN_TEST_COMM_STR;
								this.gLineTestProcessor.gDLPinConnectInfoArray[j].strNYTestResult = ctFormMain.UN_TEST_COMM_STR;
							}
							else
							{
								string strNYTestValue = "";
								this.gLineTestProcessor.gDLPinConnectInfoArray[j].strNYTestValue = strNYTestValue;
								string strNYTestResult = "";
								this.gLineTestProcessor.gDLPinConnectInfoArray[j].strNYTestResult = strNYTestResult;
							}
						}
					}
					else
					{
						for (int k = 0; k < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; k++)
						{
							KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
							if (!kLineTestProcessor.bDTTestEnabled)
							{
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[k].strDTTestValue = ctFormMain.UN_TEST_COMM_STR;
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[k].strDTTestResult = ctFormMain.UN_TEST_COMM_STR;
							}
							else
							{
								string strDTTestValue2 = "";
								kLineTestProcessor.gDLPinConnectInfoSelfArray[k].strDTTestValue = strDTTestValue2;
								string strDTTestResult2 = "";
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[k].strDTTestResult = strDTTestResult2;
							}
							KLineTestProcessor kLineTestProcessor2 = this.gLineTestProcessor;
							if (!kLineTestProcessor2.bJYTestEnabled)
							{
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[k].strJYTestValue = ctFormMain.UN_TEST_COMM_STR;
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[k].strJYTestResult = ctFormMain.UN_TEST_COMM_STR;
							}
							else
							{
								string strJYTestValue2 = "";
								kLineTestProcessor2.gDLPinConnectInfoSelfArray[k].strJYTestValue = strJYTestValue2;
								string strJYTestResult2 = "";
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[k].strJYTestResult = strJYTestResult2;
							}
							KLineTestProcessor kLineTestProcessor3 = this.gLineTestProcessor;
							if (!kLineTestProcessor3.bNYTestEnabled)
							{
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[k].strNYTestValue = ctFormMain.UN_TEST_COMM_STR;
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[k].strNYTestResult = ctFormMain.UN_TEST_COMM_STR;
							}
							else
							{
								string strNYTestValue2 = "";
								kLineTestProcessor3.gDLPinConnectInfoSelfArray[k].strNYTestValue = strNYTestValue2;
								string strNYTestResult2 = "";
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[k].strNYTestResult = strNYTestResult2;
							}
						}
					}
					this.gLineTestProcessor.gDLPinConnectInfoDLResultArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
					this.gLineTestProcessor.gDLPinConnectInfoDDJYArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
					this.bExistDLFlag = false;
					this.bIsExistReportFlag = false;
					this.bIsSaveDataFlag = false;
					this.iDTTFFlag = 0;
					this.iDLTFFlag = 0;
					this.iJYTFFlag = 0;
					this.iDDJYTFFlag = 0;
					this.iNYTFFlag = 0;
					this.iHintRecordNum = this.dataGridView1.Rows.Count;
					this.iHintDTExcNum = 0;
					this.iHintDLExcNum = 0;
					this.iHintJYExcNum = 0;
					this.iHintDDJYExcNum = 0;
					this.iHintNYExcNum = 0;
					this.RefreshHintLableFunc();
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		public void GetDDJYPinNameListFunc()
		{
			try
			{
				this.ddjyTHeadNameList = new System.Collections.Generic.List<string>();
				if (!this.bSelfStudyPinTestFlag)
				{
					if (this.gLineTestProcessor.gDLPinConnectInfoArray.Count > 0)
					{
						this.ddjyTHeadNameList.Add(this.gLineTestProcessor.gDLPinConnectInfoArray[0].mALJQName);
						int i = 0;
						IL_5F:
						while (i < this.gLineTestProcessor.gDLPinConnectInfoArray.Count)
						{
							string tempStr = this.gLineTestProcessor.gDLPinConnectInfoArray[i].mALJQName;
							string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoArray[i].mBLJQName;
							bool bExistFlag = false;
							int j = 0;
							while (j < this.ddjyTHeadNameList.Count)
							{
								if (tempStr == this.ddjyTHeadNameList[j])
								{
									IL_EA:
									bExistFlag = false;
									for (int k = 0; k < this.ddjyTHeadNameList.Count; k++)
									{
										if (temp2Str == this.ddjyTHeadNameList[k])
										{
											IL_12E:
											i++;
											goto IL_5F;
										}
									}
									if (!bExistFlag)
									{
										this.ddjyTHeadNameList.Add(temp2Str);
										goto IL_12E;
									}
									goto IL_12E;
								}
								else
								{
									j++;
								}
							}
							if (!bExistFlag)
							{
								this.ddjyTHeadNameList.Add(tempStr);
								goto IL_EA;
							}
							goto IL_EA;
						}
					}
				}
				else if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count > 0)
				{
					this.ddjyTHeadNameList.Add(this.gLineTestProcessor.gDLPinConnectInfoSelfArray[0].mALJQName);
					int l = 0;
					IL_172:
					while (l < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count)
					{
						string tempStr = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[l].mALJQName;
						string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[l].mBLJQName;
						bool bExistFlag = false;
						int m = 0;
						while (m < this.ddjyTHeadNameList.Count)
						{
							if (tempStr == this.ddjyTHeadNameList[m])
							{
								IL_1FA:
								bExistFlag = false;
								for (int n = 0; n < this.ddjyTHeadNameList.Count; n++)
								{
									if (temp2Str == this.ddjyTHeadNameList[n])
									{
										IL_23E:
										l++;
										goto IL_172;
									}
								}
								if (!bExistFlag)
								{
									this.ddjyTHeadNameList.Add(temp2Str);
									goto IL_23E;
								}
								goto IL_23E;
							}
							else
							{
								m++;
							}
						}
						if (!bExistFlag)
						{
							this.ddjyTHeadNameList.Add(tempStr);
							goto IL_1FA;
						}
						goto IL_1FA;
					}
				}
			}
			catch (System.Exception arg_249_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_249_0.StackTrace);
			}
		}
		public string GreateReportFNFunc(string orfn)
		{
			string fn = orfn + "\\";
			try
			{
				System.ValueType dt = System.DateTime.Now;
				string tempMonthStr;
				if (((System.DateTime)dt).Month < 10)
				{
					tempMonthStr = "0" + System.Convert.ToString(((System.DateTime)dt).Month);
				}
				else
				{
					tempMonthStr = System.Convert.ToString(((System.DateTime)dt).Month);
				}
				string tempDayStr;
				if (((System.DateTime)dt).Day < 10)
				{
					tempDayStr = "0" + System.Convert.ToString(((System.DateTime)dt).Day);
				}
				else
				{
					tempDayStr = System.Convert.ToString(((System.DateTime)dt).Day);
				}
				string tempHourStr;
				if (((System.DateTime)dt).Hour < 10)
				{
					tempHourStr = "0" + System.Convert.ToString(((System.DateTime)dt).Hour);
				}
				else
				{
					tempHourStr = System.Convert.ToString(((System.DateTime)dt).Hour);
				}
				string tempMinuteStr;
				if (((System.DateTime)dt).Minute < 10)
				{
					tempMinuteStr = "0" + System.Convert.ToString(((System.DateTime)dt).Minute);
				}
				else
				{
					tempMinuteStr = System.Convert.ToString(((System.DateTime)dt).Minute);
				}
				string tempSecondStr;
				if (((System.DateTime)dt).Second < 10)
				{
					tempSecondStr = "0" + System.Convert.ToString(((System.DateTime)dt).Second);
				}
				else
				{
					tempSecondStr = System.Convert.ToString(((System.DateTime)dt).Second);
				}
				string tt = System.Convert.ToString(((System.DateTime)dt).Year) + tempMonthStr + tempDayStr;
				string ttms = tempHourStr + tempMinuteStr + tempSecondStr;
				string str = "_";
				string tempfnStr = "线束测试报告_" + this.bcCableStr + str + this.batchMumberStr + str + tt + str + ttms + ".pdf";
				fn += tempfnStr;
				this.reportBackFNStr = this.reportBackPathStr + tempfnStr;
			}
			catch (System.Exception arg_204_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_204_0.StackTrace);
				if (-1 == fn.LastIndexOf(".pdf"))
				{
					fn = orfn + "\\线束测试报告.pdf";
					this.reportBackFNStr = this.reportBackPathStr + "\\线束测试报告.pdf";
				}
			}
			return fn;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool GetReportInfoFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			bool bFlag = true;
			try
			{
				System.ValueType valueType = System.DateTime.Now;
				this.dt = valueType;
				System.DateTime value = ((System.DateTime)valueType).ToLocalTime();
				this.ct_TestDateStr = System.Convert.ToString(value);
				this.ct_TestEnvironmentTempStr = "";
				this.ct_TestAmbientHumidityStr = "";
				this.strTestResult = ctFormMain.TEST_QUAL_STR;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.mddbPathStr;
					connection.Open();
					string sqlcommand = "select * from THistoryDataInfo where ID=" + this.iHistoryDataInfoID;
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						this.ct_TestPCHStr = dataReader["batchMumberStr"].ToString();
						this.ct_TestBCXSStr = dataReader["bcCableName"].ToString();
						this.ct_TestDateStr = dataReader["TestTime"].ToString();
						this.ct_TestEnvironmentTempStr = dataReader["EnvironmentTemperature"].ToString();
						this.ct_TestAmbientHumidityStr = dataReader["AmbientHumidity"].ToString();
						this.strTestResult = dataReader["TestResult"].ToString();
						this.ct_DTLimitValueStr = dataReader["DTRange"].ToString();
						this.ct_DTVoltageStr = dataReader["DTVoltage"].ToString();
						this.ct_DTCurrentStr = dataReader["DTCurrent"].ToString();
						this.ct_JYLimitValueStr = dataReader["JYRange"].ToString();
						this.ct_JYHoldTimeStr = dataReader["JYTime"].ToString();
						this.ct_JYDCHighVoltStr = dataReader["JYVolt"].ToString();
						this.ct_JYDCRiseTimeStr = dataReader["JYUPTime"].ToString();
						this.ct_NYLimitValueStr = dataReader["NYRange"].ToString();
						this.ct_NYHoldTimeStr = dataReader["NYTime"].ToString();
						this.ct_NYACHighVoltStr = dataReader["NYVolt"].ToString();
						this.ct_iDTTFFlagStr = dataReader["DTTFFlag"].ToString();
						this.ct_iDLTFFlagStr = dataReader["DLTFFlag"].ToString();
						this.ct_iJYTFFlagStr = dataReader["JYTFFlag"].ToString();
						this.ct_iDDJYTFFlagStr = dataReader["DDJYTFFlag"].ToString();
						this.ct_iNYTFFlagStr = dataReader["NYTFFlag"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception ex)
				{
					KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
					if (dataReader != null)
					{
						dataReader.Close();
						dataReader = null;
					}
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
			}
			catch (System.Exception ex2)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex2.StackTrace);
			}
			return bFlag;
		}
		public void SataRecordDataToPDFFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			OleDbConnection connection2 = null;
			OleDbDataReader dataReader2 = null;
			OleDbConnection connection3 = null;
			OleDbDataReader dataReader3 = null;
			OleDbConnection connection4 = null;
			OleDbDataReader dataReader4 = null;
			OleDbConnection connection5 = null;
			OleDbDataReader dataReader5 = null;
			OleDbConnection connection6 = null;
			OleDbDataReader dataReader6 = null;
			OleDbConnection connection7 = null;
			OleDbDataReader dataReader7 = null;
			OleDbConnection connection8 = null;
			OleDbDataReader dataReader8 = null;
			OleDbConnection connection9 = null;
			OleDbDataReader dataReader9 = null;
			try
			{
				string savefn = Application.StartupPath + "\\Template";
				int iReportTemplateFormat = this.gLineTestProcessor.iReportTemplateFormat;
				if (iReportTemplateFormat == 0)
				{
					savefn += "\\ctTemplate.docx";
				}
				else if (iReportTemplateFormat == 1)
				{
					savefn += "\\ctTemplateE.docx";
				}
				else if (iReportTemplateFormat == 2)
				{
					savefn += "\\ctTemplateM.docx";
				}
				Document doc = new Document(savefn);
				DocumentBuilder builder = new DocumentBuilder(doc);
				builder.MoveToBookmark("ct_TestResult");
				builder.Write(this.strTestResult);
				builder.MoveToBookmark("ct_CableName");
				builder.Write("线束代号: " + this.ct_TestBCXSStr);
				builder.Write("\n批 次 号: " + this.ct_TestPCHStr);
				builder.MoveToBookmark("ct_TesterEnvironment");
				builder.Write("环境温度: " + this.ct_TestEnvironmentTempStr);
				builder.Write("\n环境湿度: " + this.ct_TestAmbientHumidityStr);
				builder.Write("\n测试人员: " + this.ct_TestUserNameStr);
				builder.Write("\n测试时间: " + this.ct_TestDateStr);
				builder.MoveToBookmark("ct_DTTestPara");
				builder.Write("导通阈值: " + this.ct_DTLimitValueStr);
				if (this.gLineTestProcessor.bJYTestEnabled)
				{
					builder.MoveToBookmark("ct_JYTestPara");
					builder.Write("绝缘阈值: " + this.ct_JYLimitValueStr);
					builder.Write("\n绝缘电压: " + this.ct_JYDCHighVoltStr);
					builder.Write("\n绝缘保持时间: " + this.ct_JYHoldTimeStr);
				}
				if (this.gLineTestProcessor.bNYTestEnabled)
				{
					builder.MoveToBookmark("ct_NYTestPara");
					builder.Write("耐压阈值: " + this.ct_NYLimitValueStr);
					builder.Write("\n耐压电压: " + this.ct_NYACHighVoltStr);
					builder.Write("\n耐压保持时间: " + this.ct_NYHoldTimeStr);
				}
				int iErrIndex = 1;
				int iReportTemplateFormat2 = this.gLineTestProcessor.iReportTemplateFormat;
				if (iReportTemplateFormat2 == 0 || iReportTemplateFormat2 == 1)
				{
					if (this.strTestResult == ctFormMain.TEST_QUAL_STR)
					{
						builder.MoveToBookmark("ct_ErrorDetail");
						builder.Write("\n    无异常。\n");
					}
					int num = this.iHintDDJYExcNum;
					if (num > 0)
					{
						iErrIndex = 2;
					}
					if (this.iHintDLExcNum > 0)
					{
						iErrIndex++;
					}
					if (this.iHintDTExcNum > 0)
					{
						iErrIndex++;
					}
					if (this.iHintJYExcNum > 0)
					{
						iErrIndex++;
					}
					if (this.iHintNYExcNum > 0)
					{
						iErrIndex++;
					}
					if (num > 0)
					{
						builder.MoveToBookmark("ct_ErrorDetail");
						iErrIndex--;
						builder.Bold = true;
						string tempStr = "\n" + System.Convert.ToString(iErrIndex) + "、对地绝缘测试异常明细\n\r";
						builder.Write(tempStr);
						try
						{
							builder.StartTable();
							builder.CellFormat.Borders.LineStyle = LineStyle.Single;
							System.Drawing.Color black = System.Drawing.Color.Black;
							builder.CellFormat.Borders.Color = black;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.CellFormat.HorizontalMerge = CellMerge.None;
							builder.CellFormat.VerticalMerge = CellMerge.None;
							builder.Bold = false;
							builder.InsertCell();
							builder.CellFormat.Width = 80.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("序号");
							builder.InsertCell();
							builder.CellFormat.Width = 210.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("起点");
							builder.InsertCell();
							builder.CellFormat.Width = 100.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("终点");
							builder.InsertCell();
							builder.CellFormat.Width = 210.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("对地绝缘测试值");
							builder.InsertCell();
							builder.CellFormat.Width = 160.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("测试结论");
							builder.EndRow();
							try
							{
								int iIndex = 0;
								try
								{
									connection = new OleDbConnection();
									connection.ConnectionString = this.gLineTestProcessor.mddbPathStr;
									connection.Open();
									string sqlcommand = "select * from THistoryDDJYDataDetail where HID=" + this.iHistoryDataInfoID + " and TestResult='" + ctFormMain.TEST_NOT_QUAL_STR + "' order by ID";
									OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
									dataReader = cmd.ExecuteReader();
									while (dataReader.Read())
									{
										int num2 = iIndex + 1;
										string indexStr = System.Convert.ToString(num2);
										string startJKstr = dataReader["PlugName1"].ToString();
										string stopJKstr = dataReader["PlugName2"].ToString();
										string ddjyTestValuestr = dataReader["TestValue"].ToString();
										string ddjyTestResultstr = dataReader["TestResult"].ToString();
										builder.InsertCell();
										builder.CellFormat.Width = 80.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(indexStr);
										builder.InsertCell();
										builder.CellFormat.Width = 210.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(startJKstr);
										builder.InsertCell();
										builder.CellFormat.Width = 100.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(stopJKstr);
										builder.InsertCell();
										builder.CellFormat.Width = 210.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(ddjyTestValuestr);
										builder.InsertCell();
										builder.CellFormat.Width = 160.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(ddjyTestResultstr);
										builder.EndRow();
										iIndex = num2;
									}
									dataReader.Close();
									dataReader = null;
									connection.Close();
									connection = null;
								}
								catch (System.Exception ex)
								{
									builder.EndRow();
									KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
									if (dataReader != null)
									{
										dataReader.Close();
										dataReader = null;
									}
									if (connection != null)
									{
										connection.Close();
										connection = null;
									}
								}
							}
							catch (System.Exception ex2)
							{
								KLineTestProcessor.ExceptionRecordFunc(ex2.StackTrace);
							}
							builder.EndTable();
						}
						catch (System.Exception ex_7E5)
						{
						}
					}
					if (this.iHintDLExcNum > 0)
					{
						builder.MoveToBookmark("ct_ErrorDetail");
						iErrIndex--;
						builder.Bold = true;
						string tempStr = "\n" + System.Convert.ToString(iErrIndex) + "、短路测试异常明细\n\r";
						builder.Write(tempStr);
						try
						{
							builder.StartTable();
							builder.CellFormat.Borders.LineStyle = LineStyle.Single;
							System.Drawing.Color black2 = System.Drawing.Color.Black;
							builder.CellFormat.Borders.Color = black2;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.CellFormat.HorizontalMerge = CellMerge.None;
							builder.CellFormat.VerticalMerge = CellMerge.None;
							builder.Bold = false;
							builder.InsertCell();
							builder.CellFormat.Width = 80.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("序号");
							builder.InsertCell();
							builder.CellFormat.Width = 220.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("起点接口");
							builder.InsertCell();
							builder.CellFormat.Width = 120.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("起点接点");
							builder.InsertCell();
							builder.CellFormat.Width = 220.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("终点接口");
							builder.InsertCell();
							builder.CellFormat.Width = 120.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("终点接点");
							builder.EndRow();
							try
							{
								int iIndex = 0;
								try
								{
									connection2 = new OleDbConnection();
									connection2.ConnectionString = this.gLineTestProcessor.mddbPathStr;
									connection2.Open();
									string sqlcommand2 = "select * from THistoryDLDataDetail where HID=" + this.iHistoryDataInfoID + " order by ID";
									OleDbCommand cmd2 = new OleDbCommand(sqlcommand2, connection2);
									dataReader2 = cmd2.ExecuteReader();
									while (dataReader2.Read())
									{
										int num3 = iIndex + 1;
										string indexStr = System.Convert.ToString(num3);
										string startJKstr = dataReader2["PlugName1"].ToString();
										string startJDstr = dataReader2["Pin1"].ToString();
										string stopJKstr = dataReader2["PlugName2"].ToString();
										string stopJDstr = dataReader2["Pin2"].ToString();
										builder.InsertCell();
										builder.CellFormat.Width = 80.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(indexStr);
										builder.InsertCell();
										builder.CellFormat.Width = 220.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(startJKstr);
										builder.InsertCell();
										builder.CellFormat.Width = 120.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(startJDstr);
										builder.InsertCell();
										builder.CellFormat.Width = 220.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(stopJKstr);
										builder.InsertCell();
										builder.CellFormat.Width = 120.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(stopJDstr);
										builder.EndRow();
										iIndex = num3;
									}
									dataReader2.Close();
									dataReader2 = null;
									connection2.Close();
									connection2 = null;
								}
								catch (System.Exception ex3)
								{
									builder.EndRow();
									KLineTestProcessor.ExceptionRecordFunc(ex3.StackTrace);
									if (dataReader2 != null)
									{
										dataReader2.Close();
										dataReader2 = null;
									}
									if (connection2 != null)
									{
										connection2.Close();
										connection2 = null;
									}
								}
							}
							catch (System.Exception ex4)
							{
								KLineTestProcessor.ExceptionRecordFunc(ex4.StackTrace);
							}
							builder.EndTable();
						}
						catch (System.Exception ex_C24)
						{
						}
					}
					if (this.iHintNYExcNum > 0)
					{
						builder.MoveToBookmark("ct_ErrorDetail");
						iErrIndex--;
						builder.Bold = true;
						string tempStr = "\n" + System.Convert.ToString(iErrIndex) + "、耐压测试异常明细\n\r";
						builder.Write(tempStr);
						try
						{
							builder.StartTable();
							builder.CellFormat.Borders.LineStyle = LineStyle.Single;
							System.Drawing.Color black3 = System.Drawing.Color.Black;
							builder.CellFormat.Borders.Color = black3;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.CellFormat.HorizontalMerge = CellMerge.None;
							builder.CellFormat.VerticalMerge = CellMerge.None;
							builder.Bold = false;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.InsertCell();
							builder.CellFormat.Width = 75.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("序号");
							builder.InsertCell();
							builder.CellFormat.Width = 160.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("起点接口");
							builder.InsertCell();
							builder.CellFormat.Width = 75.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("起点\n接点");
							builder.InsertCell();
							builder.CellFormat.Width = 160.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("终点接口");
							builder.InsertCell();
							builder.CellFormat.Width = 75.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("终点\n接点");
							builder.InsertCell();
							builder.CellFormat.Width = 130.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("耐压电流");
							builder.InsertCell();
							builder.CellFormat.Width = 90.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("耐压结论");
							builder.EndRow();
							try
							{
								int iIndex = 0;
								try
								{
									connection3 = new OleDbConnection();
									connection3.ConnectionString = this.gLineTestProcessor.mddbPathStr;
									connection3.Open();
									string sqlcommand3 = "select * from THistoryDataDetail where HID=" + this.iHistoryDataInfoID + " and nyTestResult='" + ctFormMain.TEST_NOT_QUAL_STR + "' order by ID";
									OleDbCommand cmd3 = new OleDbCommand(sqlcommand3, connection3);
									dataReader3 = cmd3.ExecuteReader();
									while (dataReader3.Read())
									{
										int num4 = iIndex + 1;
										string indexStr = System.Convert.ToString(num4);
										string startJKstr = dataReader3["PlugName1"].ToString();
										string startJDstr = dataReader3["Pin1"].ToString();
										string stopJKstr = dataReader3["PlugName2"].ToString();
										string stopJDstr = dataReader3["Pin2"].ToString();
										string nyTestValuestr = dataReader3["NYValue"].ToString();
										string nyTestResultstr = dataReader3["nyTestResult"].ToString();
										builder.InsertCell();
										builder.CellFormat.Width = 75.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(indexStr);
										builder.InsertCell();
										builder.CellFormat.Width = 160.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(startJKstr);
										builder.InsertCell();
										builder.CellFormat.Width = 75.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(startJDstr);
										builder.InsertCell();
										builder.CellFormat.Width = 160.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(stopJKstr);
										builder.InsertCell();
										builder.CellFormat.Width = 75.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(stopJDstr);
										builder.InsertCell();
										builder.CellFormat.Width = 130.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(nyTestValuestr);
										builder.InsertCell();
										builder.CellFormat.Width = 90.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(nyTestResultstr);
										builder.EndRow();
										iIndex = num4;
									}
									dataReader3.Close();
									dataReader3 = null;
									connection3.Close();
									connection3 = null;
								}
								catch (System.Exception ex5)
								{
									builder.EndRow();
									KLineTestProcessor.ExceptionRecordFunc(ex5.StackTrace);
									if (dataReader3 != null)
									{
										dataReader3.Close();
										dataReader3 = null;
									}
									if (connection3 != null)
									{
										connection3.Close();
										connection3 = null;
									}
								}
							}
							catch (System.Exception ex6)
							{
								KLineTestProcessor.ExceptionRecordFunc(ex6.StackTrace);
							}
							builder.EndTable();
						}
						catch (System.Exception ex_119B)
						{
						}
					}
					if (this.iHintJYExcNum > 0)
					{
						builder.MoveToBookmark("ct_ErrorDetail");
						iErrIndex--;
						builder.Bold = true;
						string tempStr = "\n" + System.Convert.ToString(iErrIndex) + "、绝缘测试异常明细\n\r";
						builder.Write(tempStr);
						try
						{
							builder.StartTable();
							builder.CellFormat.Borders.LineStyle = LineStyle.Single;
							System.Drawing.Color black4 = System.Drawing.Color.Black;
							builder.CellFormat.Borders.Color = black4;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.CellFormat.HorizontalMerge = CellMerge.None;
							builder.CellFormat.VerticalMerge = CellMerge.None;
							builder.Bold = false;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.InsertCell();
							builder.CellFormat.Width = 75.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("序号");
							builder.InsertCell();
							builder.CellFormat.Width = 160.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("起点接口");
							builder.InsertCell();
							builder.CellFormat.Width = 75.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("起点\n接点");
							builder.InsertCell();
							builder.CellFormat.Width = 160.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("终点接口");
							builder.InsertCell();
							builder.CellFormat.Width = 75.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("终点\n接点");
							builder.InsertCell();
							builder.CellFormat.Width = 130.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("绝缘电阻");
							builder.InsertCell();
							builder.CellFormat.Width = 90.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("绝缘结论");
							builder.EndRow();
							try
							{
								int iIndex = 0;
								try
								{
									connection4 = new OleDbConnection();
									connection4.ConnectionString = this.gLineTestProcessor.mddbPathStr;
									connection4.Open();
									string sqlcommand4 = "select * from THistoryDataDetail where HID=" + this.iHistoryDataInfoID + " and jyTestResult='" + ctFormMain.TEST_NOT_QUAL_STR + "' order by ID";
									OleDbCommand cmd4 = new OleDbCommand(sqlcommand4, connection4);
									dataReader4 = cmd4.ExecuteReader();
									while (dataReader4.Read())
									{
										int num5 = iIndex + 1;
										string indexStr = System.Convert.ToString(num5);
										string startJKstr = dataReader4["PlugName1"].ToString();
										string startJDstr = dataReader4["Pin1"].ToString();
										string stopJKstr = dataReader4["PlugName2"].ToString();
										string stopJDstr = dataReader4["Pin2"].ToString();
										string jyTestValuestr = dataReader4["JYValue"].ToString();
										string jyTestResultstr = dataReader4["jyTestResult"].ToString();
										builder.InsertCell();
										builder.CellFormat.Width = 75.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(indexStr);
										builder.InsertCell();
										builder.CellFormat.Width = 160.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(startJKstr);
										builder.InsertCell();
										builder.CellFormat.Width = 75.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(startJDstr);
										builder.InsertCell();
										builder.CellFormat.Width = 160.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(stopJKstr);
										builder.InsertCell();
										builder.CellFormat.Width = 75.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(stopJDstr);
										builder.InsertCell();
										builder.CellFormat.Width = 130.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(jyTestValuestr);
										builder.InsertCell();
										builder.CellFormat.Width = 90.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(jyTestResultstr);
										builder.EndRow();
										iIndex = num5;
									}
									dataReader4.Close();
									dataReader4 = null;
									connection4.Close();
									connection4 = null;
								}
								catch (System.Exception ex7)
								{
									builder.EndRow();
									KLineTestProcessor.ExceptionRecordFunc(ex7.StackTrace);
									if (dataReader4 != null)
									{
										dataReader4.Close();
										dataReader4 = null;
									}
									if (connection4 != null)
									{
										connection4.Close();
										connection4 = null;
									}
								}
							}
							catch (System.Exception ex8)
							{
								KLineTestProcessor.ExceptionRecordFunc(ex8.StackTrace);
							}
							builder.EndTable();
						}
						catch (System.Exception ex_1712)
						{
						}
					}
					if (this.iHintDTExcNum > 0)
					{
						builder.MoveToBookmark("ct_ErrorDetail");
						iErrIndex--;
						builder.Bold = true;
						string tempStr = "\n" + System.Convert.ToString(iErrIndex) + "、导通测试异常明细\n\r";
						builder.Write(tempStr);
						try
						{
							builder.StartTable();
							builder.CellFormat.Borders.LineStyle = LineStyle.Single;
							System.Drawing.Color black5 = System.Drawing.Color.Black;
							builder.CellFormat.Borders.Color = black5;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.CellFormat.HorizontalMerge = CellMerge.None;
							builder.CellFormat.VerticalMerge = CellMerge.None;
							builder.Bold = false;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.InsertCell();
							builder.CellFormat.Width = 75.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("序号");
							builder.InsertCell();
							builder.CellFormat.Width = 160.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("起点接口");
							builder.InsertCell();
							builder.CellFormat.Width = 75.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("起点\n接点");
							builder.InsertCell();
							builder.CellFormat.Width = 160.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("终点接口");
							builder.InsertCell();
							builder.CellFormat.Width = 75.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("终点\n接点");
							builder.InsertCell();
							builder.CellFormat.Width = 130.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("导通电阻");
							builder.InsertCell();
							builder.CellFormat.Width = 90.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("导通结论");
							builder.EndRow();
							try
							{
								int iIndex = 0;
								try
								{
									connection5 = new OleDbConnection();
									connection5.ConnectionString = this.gLineTestProcessor.mddbPathStr;
									connection5.Open();
									string sqlcommand5 = "select * from THistoryDataDetail where HID=" + this.iHistoryDataInfoID + " and dtTestResult='" + ctFormMain.TEST_NOT_QUAL_STR + "' order by ID";
									OleDbCommand cmd5 = new OleDbCommand(sqlcommand5, connection5);
									dataReader5 = cmd5.ExecuteReader();
									while (dataReader5.Read())
									{
										int num6 = iIndex + 1;
										string indexStr = System.Convert.ToString(num6);
										string startJKstr = dataReader5["PlugName1"].ToString();
										string startJDstr = dataReader5["Pin1"].ToString();
										string stopJKstr = dataReader5["PlugName2"].ToString();
										string stopJDstr = dataReader5["Pin2"].ToString();
										string dtTestValuestr = dataReader5["DTValue"].ToString();
										string dtTestResultstr = dataReader5["dtTestResult"].ToString();
										builder.InsertCell();
										builder.CellFormat.Width = 75.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(indexStr);
										builder.InsertCell();
										builder.CellFormat.Width = 160.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(startJKstr);
										builder.InsertCell();
										builder.CellFormat.Width = 75.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(startJDstr);
										builder.InsertCell();
										builder.CellFormat.Width = 160.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(stopJKstr);
										builder.InsertCell();
										builder.CellFormat.Width = 75.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(stopJDstr);
										builder.InsertCell();
										builder.CellFormat.Width = 130.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(dtTestValuestr);
										builder.InsertCell();
										builder.CellFormat.Width = 90.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(dtTestResultstr);
										builder.EndRow();
										iIndex = num6;
									}
									dataReader5.Close();
									dataReader5 = null;
									connection5.Close();
									connection5 = null;
								}
								catch (System.Exception ex9)
								{
									builder.EndRow();
									KLineTestProcessor.ExceptionRecordFunc(ex9.StackTrace);
									if (dataReader5 != null)
									{
										dataReader5.Close();
										dataReader5 = null;
									}
									if (connection5 != null)
									{
										connection5.Close();
										connection5 = null;
									}
								}
							}
							catch (System.Exception ex10)
							{
								KLineTestProcessor.ExceptionRecordFunc(ex10.StackTrace);
							}
							builder.EndTable();
						}
						catch (System.Exception ex_1C89)
						{
						}
					}
				}
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				if (kLineTestProcessor.iReportTemplateFormat != 1)
				{
					int iTitleIndex = 1;
					string tempStr;
					if (kLineTestProcessor.bDLTestEnabled)
					{
						builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
						builder.Bold = true;
						tempStr = "ct_TestItemTitle" + System.Convert.ToString(1);
						builder.MoveToBookmark(tempStr);
						tempStr = System.Convert.ToString(1) + "、短路测试数据";
						builder.Write(tempStr);
						builder.Bold = false;
						tempStr = "ct_TestItemData" + System.Convert.ToString(1);
						builder.MoveToBookmark(tempStr);
						iTitleIndex = 2;
						if (this.ct_iDLTFFlagStr != "1")
						{
							builder.Write("    未测。\n");
						}
						else
						{
							bool bExistRecordFlag = false;
							try
							{
								connection6 = new OleDbConnection();
								connection6.ConnectionString = this.gLineTestProcessor.mddbPathStr;
								connection6.Open();
								string sqlcommand6 = "select top 1 * from THistoryDLDataDetail where HID=" + this.iHistoryDataInfoID;
								OleDbCommand cmd6 = new OleDbCommand(sqlcommand6, connection6);
								dataReader6 = cmd6.ExecuteReader();
								while (dataReader6.Read())
								{
									bExistRecordFlag = true;
								}
								dataReader6.Close();
								dataReader6 = null;
								connection6.Close();
								connection6 = null;
							}
							catch (System.Exception ex11)
							{
								KLineTestProcessor.ExceptionRecordFunc(ex11.StackTrace);
								if (dataReader6 != null)
								{
									dataReader6.Close();
									dataReader6 = null;
								}
								if (connection6 != null)
								{
									connection6.Close();
									connection6 = null;
								}
							}
							if (!bExistRecordFlag)
							{
								builder.Write("    无短路。\n");
							}
							else
							{
								try
								{
									builder.StartTable();
									builder.CellFormat.Borders.LineStyle = LineStyle.Single;
									System.Drawing.Color black6 = System.Drawing.Color.Black;
									builder.CellFormat.Borders.Color = black6;
									builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
									builder.CellFormat.HorizontalMerge = CellMerge.None;
									builder.CellFormat.VerticalMerge = CellMerge.None;
									builder.Bold = false;
									builder.InsertCell();
									builder.CellFormat.Width = 80.0;
									builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
									builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
									builder.Write("序号");
									builder.InsertCell();
									builder.CellFormat.Width = 220.0;
									builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
									builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
									builder.Write("起点接口");
									builder.InsertCell();
									builder.CellFormat.Width = 120.0;
									builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
									builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
									builder.Write("起点接点");
									builder.InsertCell();
									builder.CellFormat.Width = 220.0;
									builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
									builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
									builder.Write("终点接口");
									builder.InsertCell();
									builder.CellFormat.Width = 120.0;
									builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
									builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
									builder.Write("终点接点");
									builder.EndRow();
									try
									{
										int iIndex = 0;
										try
										{
											connection7 = new OleDbConnection();
											connection7.ConnectionString = this.gLineTestProcessor.mddbPathStr;
											connection7.Open();
											string sqlcommand7 = "select * from THistoryDLDataDetail where HID=" + this.iHistoryDataInfoID + " order by ID";
											OleDbCommand cmd7 = new OleDbCommand(sqlcommand7, connection7);
											dataReader7 = cmd7.ExecuteReader();
											while (dataReader7.Read())
											{
												int num7 = iIndex + 1;
												string indexStr = System.Convert.ToString(num7);
												string startJKstr = dataReader7["PlugName1"].ToString();
												string startJDstr = dataReader7["Pin1"].ToString();
												string stopJKstr = dataReader7["PlugName2"].ToString();
												string stopJDstr = dataReader7["Pin2"].ToString();
												builder.InsertCell();
												builder.CellFormat.Width = 80.0;
												builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
												builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
												builder.Write(indexStr);
												builder.InsertCell();
												builder.CellFormat.Width = 220.0;
												builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
												builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
												builder.Write(startJKstr);
												builder.InsertCell();
												builder.CellFormat.Width = 120.0;
												builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
												builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
												builder.Write(startJDstr);
												builder.InsertCell();
												builder.CellFormat.Width = 220.0;
												builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
												builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
												builder.Write(stopJKstr);
												builder.InsertCell();
												builder.CellFormat.Width = 120.0;
												builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
												builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
												builder.Write(stopJDstr);
												builder.EndRow();
												iIndex = num7;
											}
											dataReader7.Close();
											dataReader7 = null;
											connection7.Close();
											connection7 = null;
										}
										catch (System.Exception ex12)
										{
											builder.EndRow();
											KLineTestProcessor.ExceptionRecordFunc(ex12.StackTrace);
											if (dataReader7 != null)
											{
												dataReader7.Close();
												dataReader7 = null;
											}
											if (connection7 != null)
											{
												connection7.Close();
												connection7 = null;
											}
										}
									}
									catch (System.Exception ex13)
									{
										KLineTestProcessor.ExceptionRecordFunc(ex13.StackTrace);
									}
									builder.EndTable();
								}
								catch (System.Exception ex_21E3)
								{
								}
							}
						}
					}
					if (this.gLineTestProcessor.bDDJYTestEnabled)
					{
						builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
						builder.Bold = true;
						tempStr = "ct_TestItemTitle" + System.Convert.ToString(iTitleIndex);
						builder.MoveToBookmark(tempStr);
						tempStr = System.Convert.ToString(iTitleIndex) + "、对地绝缘测试数据";
						builder.Write(tempStr);
						builder.Bold = false;
						tempStr = "ct_TestItemData" + System.Convert.ToString(iTitleIndex);
						builder.MoveToBookmark(tempStr);
						iTitleIndex++;
						if (this.ct_iDDJYTFFlagStr != "1")
						{
							builder.Write("    未测。\n");
						}
						else
						{
							try
							{
								builder.StartTable();
								builder.CellFormat.Borders.LineStyle = LineStyle.Single;
								System.Drawing.Color black7 = System.Drawing.Color.Black;
								builder.CellFormat.Borders.Color = black7;
								builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
								builder.CellFormat.HorizontalMerge = CellMerge.None;
								builder.CellFormat.VerticalMerge = CellMerge.None;
								builder.Bold = false;
								builder.InsertCell();
								builder.CellFormat.Width = 80.0;
								builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
								builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
								builder.Write("序号");
								builder.InsertCell();
								builder.CellFormat.Width = 210.0;
								builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
								builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
								builder.Write("起点");
								builder.InsertCell();
								builder.CellFormat.Width = 100.0;
								builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
								builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
								builder.Write("终点");
								builder.InsertCell();
								builder.CellFormat.Width = 210.0;
								builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
								builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
								builder.Write("对地绝缘测试值");
								builder.InsertCell();
								builder.CellFormat.Width = 160.0;
								builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
								builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
								builder.Write("测试结论");
								builder.EndRow();
								try
								{
									int iIndex = 0;
									try
									{
										connection8 = new OleDbConnection();
										connection8.ConnectionString = this.gLineTestProcessor.mddbPathStr;
										connection8.Open();
										string sqlcommand8 = "select * from THistoryDDJYDataDetail where HID=" + this.iHistoryDataInfoID + " order by ID";
										OleDbCommand cmd8 = new OleDbCommand(sqlcommand8, connection8);
										dataReader8 = cmd8.ExecuteReader();
										while (dataReader8.Read())
										{
											int num8 = iIndex + 1;
											string indexStr = System.Convert.ToString(num8);
											string startJKstr = dataReader8["PlugName1"].ToString();
											string stopJKstr = dataReader8["PlugName2"].ToString();
											string ddjyTestValuestr = dataReader8["TestValue"].ToString();
											string ddjyTestResultstr = dataReader8["TestResult"].ToString();
											builder.InsertCell();
											builder.CellFormat.Width = 80.0;
											builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
											builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
											builder.Write(indexStr);
											builder.InsertCell();
											builder.CellFormat.Width = 210.0;
											builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
											builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
											builder.Write(startJKstr);
											builder.InsertCell();
											builder.CellFormat.Width = 100.0;
											builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
											builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
											builder.Write(stopJKstr);
											builder.InsertCell();
											builder.CellFormat.Width = 210.0;
											builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
											builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
											builder.Write(ddjyTestValuestr);
											builder.InsertCell();
											builder.CellFormat.Width = 160.0;
											builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
											builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
											builder.Write(ddjyTestResultstr);
											builder.EndRow();
											iIndex = num8;
										}
										dataReader8.Close();
										dataReader8 = null;
										connection8.Close();
										connection8 = null;
									}
									catch (System.Exception ex14)
									{
										builder.EndRow();
										KLineTestProcessor.ExceptionRecordFunc(ex14.StackTrace);
										if (dataReader8 != null)
										{
											dataReader8.Close();
											dataReader8 = null;
										}
										if (connection8 != null)
										{
											connection8.Close();
											connection8 = null;
										}
									}
								}
								catch (System.Exception ex15)
								{
									KLineTestProcessor.ExceptionRecordFunc(ex15.StackTrace);
								}
								builder.EndTable();
							}
							catch (System.Exception ex_268F)
							{
							}
						}
					}
					builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
					builder.Bold = true;
					tempStr = "ct_TestItemTitle" + System.Convert.ToString(iTitleIndex);
					builder.MoveToBookmark(tempStr);
					kLineTestProcessor = this.gLineTestProcessor;
					bool bJYTestEnabled = kLineTestProcessor.bJYTestEnabled;
					if (bJYTestEnabled && kLineTestProcessor.bNYTestEnabled)
					{
						tempStr = System.Convert.ToString(iTitleIndex) + "、导通绝缘耐压测试数据";
					}
					else if (bJYTestEnabled && !kLineTestProcessor.bNYTestEnabled)
					{
						tempStr = System.Convert.ToString(iTitleIndex) + "、导通绝缘测试数据";
					}
					else if (!bJYTestEnabled && kLineTestProcessor.bNYTestEnabled)
					{
						tempStr = System.Convert.ToString(iTitleIndex) + "、导通耐压测试数据";
					}
					else if (!bJYTestEnabled && !kLineTestProcessor.bNYTestEnabled)
					{
						tempStr = System.Convert.ToString(iTitleIndex) + "、导通测试数据";
					}
					builder.Write(tempStr);
					builder.Bold = false;
					tempStr = "ct_TestItemData" + System.Convert.ToString(iTitleIndex);
					builder.MoveToBookmark(tempStr);
					iTitleIndex++;
					if (this.ct_iDTTFFlagStr != "1" && this.ct_iJYTFFlagStr != "1" && this.ct_iNYTFFlagStr != "1")
					{
						builder.Write("    未测。\n");
					}
					else
					{
						try
						{
							builder.StartTable();
							builder.CellFormat.Borders.LineStyle = LineStyle.Single;
							System.Drawing.Color black8 = System.Drawing.Color.Black;
							builder.CellFormat.Borders.Color = black8;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.CellFormat.HorizontalMerge = CellMerge.None;
							builder.CellFormat.VerticalMerge = CellMerge.None;
							builder.Bold = false;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.InsertCell();
							builder.CellFormat.Width = 75.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("序号");
							builder.InsertCell();
							builder.CellFormat.Width = 160.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("起点接口");
							builder.InsertCell();
							builder.CellFormat.Width = 75.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("起点\n接点");
							builder.InsertCell();
							builder.CellFormat.Width = 160.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("终点接口");
							builder.InsertCell();
							builder.CellFormat.Width = 75.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("终点\n接点");
							builder.InsertCell();
							builder.CellFormat.Width = 130.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("导通电阻");
							builder.InsertCell();
							builder.CellFormat.Width = 90.0;
							builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
							builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
							builder.Write("导通结论");
							if (this.gLineTestProcessor.bJYTestEnabled)
							{
								builder.InsertCell();
								builder.CellFormat.Width = 130.0;
								builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
								builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
								builder.Write("绝缘电阻");
								builder.InsertCell();
								builder.CellFormat.Width = 90.0;
								builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
								builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
								builder.Write("绝缘结论");
							}
							if (this.gLineTestProcessor.bNYTestEnabled)
							{
								builder.InsertCell();
								builder.CellFormat.Width = 130.0;
								builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
								builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
								builder.Write("耐压电流");
								builder.InsertCell();
								builder.CellFormat.Width = 90.0;
								builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
								builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
								builder.Write("耐压结论");
							}
							builder.EndRow();
							try
							{
								int iIndex = 0;
								try
								{
									connection9 = new OleDbConnection();
									connection9.ConnectionString = this.gLineTestProcessor.mddbPathStr;
									connection9.Open();
									string sqlcommand9 = "select * from THistoryDataDetail where HID=" + this.iHistoryDataInfoID + " order by ID";
									OleDbCommand cmd9 = new OleDbCommand(sqlcommand9, connection9);
									dataReader9 = cmd9.ExecuteReader();
									while (dataReader9.Read())
									{
										int num9 = iIndex + 1;
										string indexStr = System.Convert.ToString(num9);
										string startJKstr = dataReader9["PlugName1"].ToString();
										string startJDstr = dataReader9["Pin1"].ToString();
										string stopJKstr = dataReader9["PlugName2"].ToString();
										string stopJDstr = dataReader9["Pin2"].ToString();
										string dtTestValuestr = dataReader9["DTValue"].ToString();
										string dtTestResultstr = dataReader9["dtTestResult"].ToString();
										string jyTestValuestr = dataReader9["JYValue"].ToString();
										string jyTestResultstr = dataReader9["jyTestResult"].ToString();
										string nyTestValuestr = dataReader9["NYValue"].ToString();
										string nyTestResultstr = dataReader9["nyTestResult"].ToString();
										builder.InsertCell();
										builder.CellFormat.Width = 75.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(indexStr);
										builder.InsertCell();
										builder.CellFormat.Width = 160.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(startJKstr);
										builder.InsertCell();
										builder.CellFormat.Width = 75.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(startJDstr);
										builder.InsertCell();
										builder.CellFormat.Width = 160.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(stopJKstr);
										builder.InsertCell();
										builder.CellFormat.Width = 75.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(stopJDstr);
										builder.InsertCell();
										builder.CellFormat.Width = 130.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(dtTestValuestr);
										builder.InsertCell();
										builder.CellFormat.Width = 90.0;
										builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
										builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
										builder.Write(dtTestResultstr);
										if (this.gLineTestProcessor.bJYTestEnabled)
										{
											builder.InsertCell();
											builder.CellFormat.Width = 130.0;
											builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
											builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
											builder.Write(jyTestValuestr);
											builder.InsertCell();
											builder.CellFormat.Width = 90.0;
											builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
											builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
											builder.Write(jyTestResultstr);
										}
										if (this.gLineTestProcessor.bNYTestEnabled)
										{
											builder.InsertCell();
											builder.CellFormat.Width = 130.0;
											builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
											builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
											builder.Write(nyTestValuestr);
											builder.InsertCell();
											builder.CellFormat.Width = 90.0;
											builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
											builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
											builder.Write(nyTestResultstr);
										}
										builder.EndRow();
										iIndex = num9;
									}
									dataReader9.Close();
									dataReader9 = null;
									connection9.Close();
									connection9 = null;
								}
								catch (System.Exception ex16)
								{
									builder.EndRow();
									KLineTestProcessor.ExceptionRecordFunc(ex16.StackTrace);
									if (dataReader9 != null)
									{
										dataReader9.Close();
										dataReader9 = null;
									}
									if (connection9 != null)
									{
										connection9.Close();
										connection9 = null;
									}
								}
							}
							catch (System.Exception ex17)
							{
								KLineTestProcessor.ExceptionRecordFunc(ex17.StackTrace);
							}
							builder.EndTable();
						}
						catch (System.Exception ex_2F52)
						{
						}
					}
				}
				doc.Save(this.projectReportPathStr, Aspose.Words.SaveFormat.Pdf);
				doc.Save(this.reportBackFNStr, Aspose.Words.SaveFormat.Pdf);
				doc = null;
				this.bReportSuccFlag = true;
			}
			catch (System.Exception ex18)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex18.StackTrace);
				this.bReportSuccFlag = false;
			}
		}
		private void btnCreateReport_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.bIsTestStatus)
				{
					return;
				}
				try
				{
					if (string.IsNullOrEmpty(this.reportDefaultSavePathStr))
					{
						MessageBox.Show("未设置报表默认保存路径!", "提示", MessageBoxButtons.OK);
						this.MenuItem_ReportSavePathSet_Click(null, null);
						if (string.IsNullOrEmpty(this.reportDefaultSavePathStr))
						{
							MessageBox.Show("未设置报表默认保存路径，报表生成失败!", "提示", MessageBoxButtons.OK);
							return;
						}
					}
					if (!System.IO.Directory.Exists(this.reportDefaultSavePathStr))
					{
						System.IO.Directory.CreateDirectory(this.reportDefaultSavePathStr);
						System.Threading.Thread.Sleep(100);
					}
				}
				catch (System.Exception arg_79_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_79_0.StackTrace);
				}
				if (!System.IO.Directory.Exists(this.reportDefaultSavePathStr))
				{
					MessageBox.Show("无效的报表保存路径!", "提示", MessageBoxButtons.OK);
					return;
				}
				if (this.iDTTFFlag != 1 && this.iDLTFFlag != 1 && this.iJYTFFlag != 1 && this.iDDJYTFFlag != 1 && this.iNYTFFlag != 1)
				{
					MessageBox.Show("无测试数据!", "提示", MessageBoxButtons.OK);
					return;
				}
				ctFormWait e2 = new ctFormWait(1);
				this.waitFinishedForm = e2;
				e2.TopMost = true;
				this.waitFinishedForm.Activate();
				this.waitFinishedForm.Focus();
				this.waitFinishedForm.Show();
				if (!this.bIsSaveDataFlag)
				{
					this.SaveTestDataToDBFunc();
				}
				this.projectReportPathStr = this.GreateReportFNFunc(this.reportDefaultSavePathStr);
				this.GetReportInfoFunc();
				this.bReportSuccFlag = false;
				System.Threading.Thread oThread = new System.Threading.Thread(new System.Threading.ThreadStart(this.SataRecordDataToPDFFunc));
				oThread.Start();
				oThread.Join();
				this.waitFinishedForm.bCloseFlag = true;
				this.waitFinishedForm.bSuccFlag = this.bReportSuccFlag;
				Process.Start(this.projectReportPathStr);
			}
			catch (System.Exception arg_19A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_19A_0.StackTrace);
			}
			try
			{
				ctFormWait this2 = this.waitFinishedForm;
				if (this2 != null)
				{
					this2.bCloseFlag = true;
				}
				this.waitFinishedForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_1C7_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1C7_0.StackTrace);
			}
		}
		public void pdfPrint()
		{
			try
			{
				try
				{
					Process myPro = new Process();
					Process[] proc = Process.GetProcesses();
					for (int i = 0; i < proc.Length; i++)
					{
						myPro = proc[i];
						string proName = myPro.ProcessName.ToString().ToUpper();
						if (proName == "ACRORD32")
						{
							myPro.Kill();
							break;
						}
					}
					System.Threading.Thread.Sleep(300);
					System.GC.Collect();
					System.GC.WaitForPendingFinalizers();
				}
				catch (System.Exception ex_65)
				{
				}
				System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
				Process p = new Process();
				ProcessStartInfo startInfo = new ProcessStartInfo();
				startInfo.CreateNoWindow = true;
				startInfo.WindowStyle = ProcessWindowStyle.Hidden;
				startInfo.UseShellExecute = true;
				startInfo.FileName = this.projectReportPathStr;
				startInfo.Verb = "print";
				startInfo.Arguments = "/p /h \"" + startInfo.FileName + "\"\"" + pd.PrinterSettings.PrinterName.ToString() + "\"";
				p.StartInfo = startInfo;
				p.Start();
				System.Threading.Thread.Sleep(3000);
				p.Close();
				this.bReportPrintSuccFlag = true;
			}
			catch (System.Exception ex_114)
			{
				this.bReportPrintSuccFlag = false;
			}
		}
		private void btnPrintReport_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.bIsTestStatus)
				{
					return;
				}
				if (!this.bReportSuccFlag)
				{
					MessageBox.Show("无可打印的报表，请先生成报表!", "提示", MessageBoxButtons.OK);
					return;
				}
				this.bReportPrintSuccFlag = false;
				ctFormWait e2 = new ctFormWait(2);
				this.waitFinishedForm = e2;
				e2.TopMost = true;
				this.waitFinishedForm.Activate();
				this.waitFinishedForm.Focus();
				this.waitFinishedForm.Show();
				System.Threading.Thread oThread = new System.Threading.Thread(new System.Threading.ThreadStart(this.pdfPrint));
				oThread.Start();
				oThread.Join();
				this.waitFinishedForm.bCloseFlag = true;
				this.waitFinishedForm.bSuccFlag = this.bReportPrintSuccFlag;
			}
			catch (System.Exception arg_A6_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_A6_0.StackTrace);
			}
			try
			{
				ctFormWait this2 = this.waitFinishedForm;
				if (this2 != null)
				{
					this2.bCloseFlag = true;
				}
				this.waitFinishedForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_D3_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_D3_0.StackTrace);
			}
		}
		private void treeView_projectInfo_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			try
			{
				if (!this.bIsTestStatus)
				{
					if (this.treeView_projectInfo.SelectedNode != null)
					{
						string tnName = this.treeView_projectInfo.SelectedNode.Name.ToString();
						if (tnName == "TreeNode_Index0_1")
						{
							ctFormProjectEdit ctFormProjectEdit = new ctFormProjectEdit(this.gLineTestProcessor, this.iRunProjectID);
							this.editProjectForm = ctFormProjectEdit;
							ctFormProjectEdit.Activate();
							this.editProjectForm.ShowDialog();
							ctFormProjectEdit ctFormProjectEdit2 = this.editProjectForm;
							if (!ctFormProjectEdit2.bQuitFlag || ctFormProjectEdit2.bChangedFlag)
							{
								this.bSelfStudyPinTestFlag = false;
								this.OpenProjectDealwithFunc();
							}
						}
						else if (tnName == "TreeNode_Index0_2")
						{
							this.UpdateDVGDataDisposeFunc();
						}
						else if (tnName == "TreeNode_Index0_3")
						{
							int iID = System.Convert.ToInt32(this.bcCableIDStr);
							ctFormConverterInfoView ctFormConverterInfoView = new ctFormConverterInfoView(this.gLineTestProcessor, iID, this.testProjectNameStr, this.bcCableStr);
							this.converterInfoViewForm = ctFormConverterInfoView;
							ctFormConverterInfoView.Activate();
							this.converterInfoViewForm.ShowDialog();
						}
						else if (tnName == "TreeNode_Index1_1")
						{
							int iID2 = System.Convert.ToInt32(this.bcCableIDStr);
							ctFormCableInfoView e2 = new ctFormCableInfoView(this.gLineTestProcessor, iID2, this.bcCableStr);
							this.cableInfoViewForm = e2;
							e2.Activate();
							this.cableInfoViewForm.ShowDialog();
						}
						else if (tnName == "TreeNode_Index2_1")
						{
							this.btnSaveTestData_Click(null, null);
						}
						else if (tnName == "TreeNode_Index2_2")
						{
							this.btnClearData_Click(null, null);
						}
						else if (tnName == "TreeNode_Index3_1")
						{
							this.btnCreateReport_Click(null, null);
						}
						else if (tnName == "TreeNode_Index3_2")
						{
							this.btnPrintReport_Click(null, null);
						}
						else if (tnName == "TreeNode_Index4_1")
						{
							FormEquipmentInfoManage sender2 = new FormEquipmentInfoManage(this.gLineTestProcessor, false);
							this.equipmentInfoManageForm = sender2;
							sender2.Activate();
							this.equipmentInfoManageForm.ShowDialog();
						}
					}
				}
			}
			catch (System.Exception arg_1EB_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1EB_0.StackTrace);
			}
		}
		private void timer_ace_Tick(object sender, System.EventArgs e)
		{
			try
			{
				new System.Threading.Thread(new System.Threading.ThreadStart(this.AutoConnDeviceFunc)).Start();
			}
			catch (System.Exception arg_18_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_18_0.StackTrace);
			}
		}
		public void SelfStudyLoadCableDealFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				int iTemp = 0;
				string text = "";
				string temp1Str = text;
				string temp2Str = text;
				string tempPIDStr = text;
				string plugNameStr = text;
				System.Collections.Generic.List<int> csyPinNumList = new System.Collections.Generic.List<int>();
				System.Collections.Generic.List<int> csyMeasMethodList = new System.Collections.Generic.List<int>();
				System.Collections.Generic.List<int> measMethodList = new System.Collections.Generic.List<int>();
				System.Collections.Generic.List<string> pinNumList = new System.Collections.Generic.List<string>();
				System.Collections.Generic.List<string> pinNameList = new System.Collections.Generic.List<string>();
				System.Collections.Generic.List<string> tIPinNumList = new System.Collections.Generic.List<string>();
				System.Collections.Generic.List<string> aTPinNumList = new System.Collections.Generic.List<string>();
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					try
					{
						if (this.gLineTestProcessor.bUseRelayBoard)
						{
							string sqlcommand = "select * from TIAndRTPinReletionData order by ID";
							OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							while (dataReader.Read())
							{
								temp1Str = dataReader["TI_PinNum"].ToString();
								temp2Str = dataReader["AT_PinNum"].ToString();
								if (!string.IsNullOrEmpty(temp1Str) && !string.IsNullOrEmpty(temp2Str))
								{
									tIPinNumList.Add(temp1Str);
									aTPinNumList.Add(temp2Str);
								}
							}
							dataReader.Close();
							dataReader = null;
						}
					}
					catch (System.Exception ex)
					{
						KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
						if (dataReader != null)
						{
							dataReader.Close();
							dataReader = null;
						}
					}
					char[] separator = new char[]
					{
						','
					};
					string[] plugStrArray = this.bcPlugInfoStr.Split(separator);
					for (int ii = 0; ii < plugStrArray.Length; ii++)
					{
						plugNameStr = plugStrArray[ii];
						if (!string.IsNullOrEmpty(plugNameStr))
						{
							tempPIDStr = "";
							try
							{
								string sqlcommand = "select top 1 * from TPlugLibrary where PlugNo='" + plugNameStr + "'";
								OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
								dataReader = cmd.ExecuteReader();
								if (dataReader.Read())
								{
									tempPIDStr = dataReader["PID"].ToString();
								}
								dataReader.Close();
								dataReader = null;
							}
							catch (System.Exception ex2)
							{
								KLineTestProcessor.ExceptionRecordFunc(ex2.StackTrace);
								if (dataReader != null)
								{
									dataReader.Close();
									dataReader = null;
								}
							}
							if (!string.IsNullOrEmpty(tempPIDStr))
							{
								csyPinNumList.Clear();
								csyMeasMethodList.Clear();
								measMethodList.Clear();
								pinNumList.Clear();
								pinNameList.Clear();
								try
								{
									string sqlcommand = "select * from TPlugLibraryDetail where PID='" + tempPIDStr + "' order by PDID";
									OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
									dataReader = cmd.ExecuteReader();
									while (dataReader.Read())
									{
										try
										{
											temp1Str = dataReader["PinName"].ToString();
											temp2Str = dataReader["DevicePinNum"].ToString();
											iTemp = System.Convert.ToInt32(dataReader["MeasuringMethod"].ToString());
										}
										catch (System.Exception ex_2A3)
										{
											continue;
										}
										pinNameList.Add(temp1Str);
										pinNumList.Add(temp2Str);
										measMethodList.Add(iTemp);
									}
									dataReader.Close();
									dataReader = null;
								}
								catch (System.Exception ex3)
								{
									KLineTestProcessor.ExceptionRecordFunc(ex3.StackTrace);
									if (dataReader != null)
									{
										dataReader.Close();
										dataReader = null;
									}
								}
								if (this.gLineTestProcessor.bUseRelayBoard)
								{
									for (int i = 0; i < pinNumList.Count; i++)
									{
										char[] separator2 = new char[]
										{
											','
										};
										string[] devPinStrArray = pinNumList[i].Split(separator2);
										for (int j = 0; j < aTPinNumList.Count; j++)
										{
											if (devPinStrArray[0] == aTPinNumList[j])
											{
												csyPinNumList.Add(System.Convert.ToInt32(tIPinNumList[j]));
												csyMeasMethodList.Add(measMethodList[i]);
											}
										}
									}
									for (int jj = 0; jj < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; jj++)
									{
										for (int k = 0; k < csyPinNumList.Count; k++)
										{
											if (csyMeasMethodList[k] == 0)
											{
												if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnMainPinNum == csyPinNumList[k])
												{
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnALJQPinNum = pinNameList[k];
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mALJQName = plugNameStr;
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].iAMeasMethod = csyMeasMethodList[k];
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnAPinIsGround = 0;
												}
												if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnSecPinNum == csyPinNumList[k])
												{
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnBLJQPinNum = pinNameList[k];
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mBLJQName = plugNameStr;
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].iBMeasMethod = csyMeasMethodList[k];
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnBPinIsGround = 0;
												}
											}
											else
											{
												if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnMainPinNum == csyPinNumList[k] || (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnMainPinNum == csyPinNumList[k] + 1)
												{
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnALJQPinNum = pinNameList[k];
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mALJQName = plugNameStr;
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].iAMeasMethod = csyMeasMethodList[k];
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnAPinIsGround = 0;
												}
												if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnSecPinNum == csyPinNumList[k] || (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnSecPinNum == csyPinNumList[k] + 1)
												{
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnBLJQPinNum = pinNameList[k];
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mBLJQName = plugNameStr;
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].iBMeasMethod = csyMeasMethodList[k];
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnBPinIsGround = 0;
												}
											}
										}
									}
								}
								else
								{
									for (int jj2 = 0; jj2 < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; jj2++)
									{
										for (int l = 0; l < pinNumList.Count; l++)
										{
											char[] separator3 = new char[]
											{
												','
											};
											string[] devPinStrArray = pinNumList[l].Split(separator3);
											iTemp = System.Convert.ToInt32(devPinStrArray[0]);
											if (measMethodList[l] == 0)
											{
												if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mnMainPinNum == iTemp)
												{
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mnALJQPinNum = pinNameList[l];
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mALJQName = plugNameStr;
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].iAMeasMethod = measMethodList[l];
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mnAPinIsGround = 0;
												}
												if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mnSecPinNum == iTemp)
												{
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mnBLJQPinNum = pinNameList[l];
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mBLJQName = plugNameStr;
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].iBMeasMethod = measMethodList[l];
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mnBPinIsGround = 0;
												}
											}
											else
											{
												if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mnMainPinNum == iTemp || (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mnMainPinNum == iTemp + 1)
												{
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mnALJQPinNum = pinNameList[l];
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mALJQName = plugNameStr;
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].iAMeasMethod = measMethodList[l];
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mnAPinIsGround = 0;
												}
												if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mnSecPinNum == iTemp || (int)this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mnSecPinNum == iTemp + 1)
												{
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mnBLJQPinNum = pinNameList[l];
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mBLJQName = plugNameStr;
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].iBMeasMethod = measMethodList[l];
													this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mnBPinIsGround = 0;
												}
											}
										}
									}
								}
							}
						}
					}
					connection.Close();
					connection = null;
					for (int aa = this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count - 1; aa >= 0; aa--)
					{
						temp1Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[aa].mnALJQPinNum;
						temp2Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[aa].mALJQName;
						string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[aa].mnBLJQPinNum;
						string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[aa].mBLJQName;
						if (!(temp1Str == ctFormMain.PLUGPIN_UNDEFINED_STR) && !(temp2Str == ctFormMain.PLUGPIN_UNDEFINED_STR) && !(temp3Str == ctFormMain.PLUGPIN_UNDEFINED_STR) && !(temp4Str == ctFormMain.PLUGPIN_UNDEFINED_STR))
						{
							if (temp1Str == temp3Str && temp2Str == temp4Str)
							{
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Remove(this.gLineTestProcessor.gDLPinConnectInfoSelfArray[aa]);
							}
						}
					}
					for (int nn = 0; nn < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; nn++)
					{
						temp1Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[nn].mnALJQPinNum;
						temp2Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[nn].mALJQName;
						string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[nn].mnBLJQPinNum;
						string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[nn].mBLJQName;
						if (!(temp1Str == ctFormMain.PLUGPIN_UNDEFINED_STR) && !(temp2Str == ctFormMain.PLUGPIN_UNDEFINED_STR) && !(temp3Str == ctFormMain.PLUGPIN_UNDEFINED_STR) && !(temp4Str == ctFormMain.PLUGPIN_UNDEFINED_STR))
						{
							for (int mm = this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count - 1; mm > nn; mm--)
							{
								string temp5Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[mm].mnALJQPinNum;
								string temp6Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[mm].mALJQName;
								string temp7Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[mm].mnBLJQPinNum;
								string temp8Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[mm].mBLJQName;
								if ((temp1Str == temp5Str && temp2Str == temp6Str && temp3Str == temp7Str && temp4Str == temp8Str) || (temp1Str == temp7Str && temp2Str == temp8Str && temp3Str == temp5Str && temp4Str == temp6Str))
								{
									this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Remove(this.gLineTestProcessor.gDLPinConnectInfoSelfArray[mm]);
								}
							}
						}
					}
					if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count > 0)
					{
						for (int ik = this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count - 1; ik >= 0; ik--)
						{
							if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray[ik].mALJQName == ctFormMain.PLUGPIN_UNDEFINED_STR || this.gLineTestProcessor.gDLPinConnectInfoSelfArray[ik].mnALJQPinNum == ctFormMain.PLUGPIN_UNDEFINED_STR || this.gLineTestProcessor.gDLPinConnectInfoSelfArray[ik].mBLJQName == ctFormMain.PLUGPIN_UNDEFINED_STR || this.gLineTestProcessor.gDLPinConnectInfoSelfArray[ik].mnBLJQPinNum == ctFormMain.PLUGPIN_UNDEFINED_STR)
							{
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Remove(this.gLineTestProcessor.gDLPinConnectInfoSelfArray[ik]);
							}
						}
						for (int m = 0; m < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; m++)
						{
							this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].mnAPinIsGround = 0;
							this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].mnBPinIsGround = 0;
							this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].iDLTestFlag = 0;
							this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].iDTTestFlag = 0;
							this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].iJYTestFlag = 0;
							this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].iDDJYTestFlag = 0;
							this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].iNYTestFlag = 0;
							KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
							if (kLineTestProcessor.bDLTestEnabled)
							{
								kLineTestProcessor.gDLPinConnectInfoSelfArray[m].iDLTestFlag = 1;
							}
							KLineTestProcessor kLineTestProcessor2 = this.gLineTestProcessor;
							if (kLineTestProcessor2.bDTTestEnabled)
							{
								kLineTestProcessor2.gDLPinConnectInfoSelfArray[m].iDTTestFlag = 1;
							}
							KLineTestProcessor kLineTestProcessor3 = this.gLineTestProcessor;
							if (kLineTestProcessor3.bJYTestEnabled)
							{
								kLineTestProcessor3.gDLPinConnectInfoSelfArray[m].iJYTestFlag = 1;
							}
							KLineTestProcessor kLineTestProcessor4 = this.gLineTestProcessor;
							if (kLineTestProcessor4.bDDJYTestEnabled)
							{
								kLineTestProcessor4.gDLPinConnectInfoSelfArray[m].iDDJYTestFlag = 1;
							}
							KLineTestProcessor kLineTestProcessor5 = this.gLineTestProcessor;
							if (kLineTestProcessor5.bNYTestEnabled)
							{
								kLineTestProcessor5.gDLPinConnectInfoSelfArray[m].iNYTestFlag = 1;
							}
							if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].iDTTestFlag != 1)
							{
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].strDTTestValue = ctFormMain.UN_TEST_COMM_STR;
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].strDTTestResult = ctFormMain.UN_TEST_COMM_STR;
							}
							else
							{
								string strDTTestValue = "";
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].strDTTestValue = strDTTestValue;
								string strDTTestResult = "";
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].strDTTestResult = strDTTestResult;
							}
							if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].iJYTestFlag != 1)
							{
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].strJYTestValue = ctFormMain.UN_TEST_COMM_STR;
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].strJYTestResult = ctFormMain.UN_TEST_COMM_STR;
							}
							else
							{
								string strJYTestValue = "";
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].strJYTestValue = strJYTestValue;
								string strJYTestResult = "";
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].strJYTestResult = strJYTestResult;
							}
							if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].iNYTestFlag != 1)
							{
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].strNYTestValue = ctFormMain.UN_TEST_COMM_STR;
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].strNYTestResult = ctFormMain.UN_TEST_COMM_STR;
							}
							else
							{
								string strNYTestValue = "";
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].strNYTestValue = strNYTestValue;
								string strNYTestResult = "";
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].strNYTestResult = strNYTestResult;
							}
						}
					}
				}
				catch (System.Exception ex4)
				{
					KLineTestProcessor.ExceptionRecordFunc(ex4.StackTrace);
					if (dataReader != null)
					{
						dataReader.Close();
						dataReader = null;
					}
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
				csyPinNumList.Clear();
				measMethodList.Clear();
				pinNumList.Clear();
				pinNameList.Clear();
				tIPinNumList.Clear();
				aTPinNumList.Clear();
			}
			catch (System.Exception ex5)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex5.StackTrace);
			}
		}
		public void SelfStudyLoadCable_DLDealFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				System.Collections.Generic.List<string> pinNameList = new System.Collections.Generic.List<string>();
				System.Collections.Generic.List<int> devPinNumList = new System.Collections.Generic.List<int>();
				System.Collections.Generic.List<int> csyPinNumList = new System.Collections.Generic.List<int>();
				System.Collections.Generic.List<string> tIPinNumList = new System.Collections.Generic.List<string>();
				System.Collections.Generic.List<string> aTPinNumList = new System.Collections.Generic.List<string>();
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					if (this.gLineTestProcessor.bUseRelayBoard)
					{
						string sqlcommand = "select * from TIAndRTPinReletionData order by ID";
						OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						while (dataReader.Read())
						{
							string temp1Str = dataReader["TI_PinNum"].ToString();
							string temp2Str = dataReader["AT_PinNum"].ToString();
							if (!string.IsNullOrEmpty(temp1Str) && !string.IsNullOrEmpty(temp2Str))
							{
								tIPinNumList.Add(temp1Str);
								aTPinNumList.Add(temp2Str);
							}
						}
						dataReader.Close();
						dataReader = null;
					}
					string text = "";
					string tempPIDStr = text;
					char[] separator = new char[]
					{
						','
					};
					string[] plugStrArray = this.bcPlugInfoStr.Split(separator);
					for (int ii = 0; ii < plugStrArray.Length; ii++)
					{
						if (!string.IsNullOrEmpty(plugStrArray[ii]))
						{
							tempPIDStr = "";
							string sqlcommand = "select top 1 * from TPlugLibrary where PlugNo='" + plugStrArray[ii] + "'";
							OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							if (dataReader.Read())
							{
								tempPIDStr = dataReader["PID"].ToString();
							}
							dataReader.Close();
							dataReader = null;
							try
							{
								if (pinNameList == null)
								{
									pinNameList = new System.Collections.Generic.List<string>();
								}
								else
								{
									pinNameList.Clear();
								}
								if (devPinNumList == null)
								{
									devPinNumList = new System.Collections.Generic.List<int>();
								}
								else
								{
									devPinNumList.Clear();
								}
								if (csyPinNumList == null)
								{
									csyPinNumList = new System.Collections.Generic.List<int>();
								}
								else
								{
									csyPinNumList.Clear();
								}
							}
							catch (System.Exception ex)
							{
								KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
							}
							if (!string.IsNullOrEmpty(tempPIDStr))
							{
								sqlcommand = "select * from TPlugLibraryDetail where PID='" + tempPIDStr + "'";
								cmd = new OleDbCommand(sqlcommand, connection);
								dataReader = cmd.ExecuteReader();
								while (dataReader.Read())
								{
									try
									{
										string temp1Str = dataReader["PinName"].ToString();
										string temp2Str = dataReader["DevicePinNum"].ToString();
										char[] separator2 = new char[]
										{
											','
										};
										string[] devPinStrArray = temp2Str.Trim().Split(separator2);
										int iTemp = System.Convert.ToInt32(devPinStrArray[0]);
										pinNameList.Add(temp1Str);
										devPinNumList.Add(iTemp);
										if (devPinStrArray.Length == 2)
										{
											iTemp = System.Convert.ToInt32(devPinStrArray[1]);
											pinNameList.Add(temp1Str);
											devPinNumList.Add(iTemp);
										}
									}
									catch (System.Exception ex2)
									{
										KLineTestProcessor.ExceptionRecordFunc(ex2.StackTrace);
									}
								}
								dataReader.Close();
								dataReader = null;
								if (this.gLineTestProcessor.bUseRelayBoard)
								{
									for (int i = 0; i < devPinNumList.Count; i++)
									{
										for (int mn = 0; mn < aTPinNumList.Count; mn++)
										{
											if (devPinNumList[i] == System.Convert.ToInt32(aTPinNumList[mn]))
											{
												csyPinNumList.Add(System.Convert.ToInt32(tIPinNumList[mn]));
												break;
											}
										}
									}
									for (int j = 0; j < csyPinNumList.Count; j++)
									{
										for (int jj = 0; jj < this.gLineTestProcessor.gDLPinConnectInfoDLArray.Count; jj++)
										{
											if ((int)this.gLineTestProcessor.gDLPinConnectInfoDLArray[jj].mnMainPinNum == csyPinNumList[j])
											{
												this.gLineTestProcessor.gDLPinConnectInfoDLArray[jj].mnALJQPinNum = pinNameList[j];
												this.gLineTestProcessor.gDLPinConnectInfoDLArray[jj].mALJQName = plugStrArray[ii];
											}
											if ((int)this.gLineTestProcessor.gDLPinConnectInfoDLArray[jj].mnSecPinNum == csyPinNumList[j])
											{
												this.gLineTestProcessor.gDLPinConnectInfoDLArray[jj].mnBLJQPinNum = pinNameList[j];
												this.gLineTestProcessor.gDLPinConnectInfoDLArray[jj].mBLJQName = plugStrArray[ii];
											}
										}
									}
								}
								else
								{
									for (int k = 0; k < devPinNumList.Count; k++)
									{
										for (int jj2 = 0; jj2 < this.gLineTestProcessor.gDLPinConnectInfoDLArray.Count; jj2++)
										{
											if ((int)this.gLineTestProcessor.gDLPinConnectInfoDLArray[jj2].mnMainPinNum == devPinNumList[k])
											{
												this.gLineTestProcessor.gDLPinConnectInfoDLArray[jj2].mnALJQPinNum = pinNameList[k];
												this.gLineTestProcessor.gDLPinConnectInfoDLArray[jj2].mALJQName = plugStrArray[ii];
											}
											if ((int)this.gLineTestProcessor.gDLPinConnectInfoDLArray[jj2].mnSecPinNum == devPinNumList[k])
											{
												this.gLineTestProcessor.gDLPinConnectInfoDLArray[jj2].mnBLJQPinNum = pinNameList[k];
												this.gLineTestProcessor.gDLPinConnectInfoDLArray[jj2].mBLJQName = plugStrArray[ii];
											}
										}
									}
								}
								for (int aa = this.gLineTestProcessor.gDLPinConnectInfoDLArray.Count - 1; aa >= 0; aa--)
								{
									string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[aa].mnALJQPinNum;
									string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[aa].mALJQName;
									string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[aa].mnBLJQPinNum;
									string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[aa].mBLJQName;
									if (!(temp1Str == ctFormMain.PLUGPIN_UNDEFINED_STR) && !(temp2Str == ctFormMain.PLUGPIN_UNDEFINED_STR) && !(temp3Str == ctFormMain.PLUGPIN_UNDEFINED_STR) && !(temp4Str == ctFormMain.PLUGPIN_UNDEFINED_STR))
									{
										if (temp1Str == temp3Str && temp2Str == temp4Str)
										{
											this.gLineTestProcessor.gDLPinConnectInfoDLArray.Remove(this.gLineTestProcessor.gDLPinConnectInfoDLArray[aa]);
										}
									}
								}
								for (int nn = 0; nn < this.gLineTestProcessor.gDLPinConnectInfoDLArray.Count; nn++)
								{
									string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[nn].mnALJQPinNum;
									string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[nn].mALJQName;
									string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[nn].mnBLJQPinNum;
									string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[nn].mBLJQName;
									if (!(temp1Str == ctFormMain.PLUGPIN_UNDEFINED_STR) && !(temp2Str == ctFormMain.PLUGPIN_UNDEFINED_STR) && !(temp3Str == ctFormMain.PLUGPIN_UNDEFINED_STR) && !(temp4Str == ctFormMain.PLUGPIN_UNDEFINED_STR))
									{
										for (int mm = this.gLineTestProcessor.gDLPinConnectInfoDLArray.Count - 1; mm > nn; mm--)
										{
											string temp5Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[mm].mnALJQPinNum;
											string temp6Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[mm].mALJQName;
											string temp7Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[mm].mnBLJQPinNum;
											string temp8Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[mm].mBLJQName;
											if ((temp1Str == temp5Str && temp2Str == temp6Str && temp3Str == temp7Str && temp4Str == temp8Str) || (temp1Str == temp7Str && temp2Str == temp8Str && temp3Str == temp5Str && temp4Str == temp6Str))
											{
												this.gLineTestProcessor.gDLPinConnectInfoDLArray.Remove(this.gLineTestProcessor.gDLPinConnectInfoDLArray[mm]);
											}
										}
									}
								}
								pinNameList.Clear();
								pinNameList = null;
								devPinNumList.Clear();
								devPinNumList = null;
							}
						}
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception ex3)
				{
					KLineTestProcessor.ExceptionRecordFunc(ex3.StackTrace);
					if (dataReader != null)
					{
						dataReader.Close();
						dataReader = null;
					}
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
			}
			catch (System.Exception ex4)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex4.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool SaveCablePinRelationFunc()
		{
			OleDbConnection connection = null;
			bool bSaveSuccFlag = false;
			try
			{
				string tempLIDStr = "";
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "select * from TLineStructLibrary where LineStructName='" + this.bcCableStr + "'";
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					OleDbDataReader dataReader = cmd.ExecuteReader();
					while (dataReader.Read())
					{
						tempLIDStr = dataReader["LID"].ToString();
					}
					dataReader.Close();
					if (!string.IsNullOrEmpty(tempLIDStr))
					{
						sqlcommand = "delete from TLineStructLibraryDetail where LID='" + tempLIDStr + "'";
						cmd = new OleDbCommand(sqlcommand, connection);
						cmd.ExecuteNonQuery();
						System.Threading.Thread.Sleep(50);
						int iNum = this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count;
						for (int jj = 0; jj < iNum; jj++)
						{
							string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mALJQName;
							string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnALJQPinNum;
							string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mBLJQName;
							string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnBLJQPinNum;
							int iIsTestDT = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].iDTTestFlag;
							int iIsTestDL = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].iDLTestFlag;
							int iIsTestJY = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].iJYTestFlag;
							int iIsTestDDJY = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].iDDJYTestFlag;
							int iIsTestNY = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].iNYTestFlag;
							string str = ",";
							string str2 = "','";
							sqlcommand = "insert into TLineStructLibraryDetail(LID,PlugName1,PinName1,PlugName2,PinName2,IsGround,IsTestDT,IsTestDL,IsTestJY,IsTestDDJY,IsTestNY) values('" + tempLIDStr + str2 + temp1Str + str2 + temp2Str + str2 + temp3Str + str2 + temp4Str + "', 0," + iIsTestDT + str + iIsTestDL + str + iIsTestJY + str + iIsTestDDJY + str + iIsTestNY + ")";
							cmd = new OleDbCommand(sqlcommand, connection);
							cmd.ExecuteNonQuery();
						}
						sqlcommand = "update TLineStructLibrary set LinePinNum = " + iNum + " where LID = " + System.Convert.ToInt32(tempLIDStr) + "";
						cmd = new OleDbCommand(sqlcommand, connection);
						cmd.ExecuteNonQuery();
					}
					connection.Close();
					connection = null;
					bSaveSuccFlag = true;
				}
				catch (System.Exception arg_2E2_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_2E2_0.StackTrace);
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
			}
			catch (System.Exception arg_2FB_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2FB_0.StackTrace);
			}
			return bSaveSuccFlag;
		}
		public void SelfStudyPinRelaReviseFunc()
		{
			try
			{
				for (int i = 0; i < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; i++)
				{
					for (int j = 0; j < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; j++)
					{
						SDLPinConnectInfo var_5_46_cp_0 = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j];
						if (this.gLineTestProcessor.gDLPinConnectInfoArray[i].mnMainPinNum == var_5_46_cp_0.mnSecPinNum)
						{
							SDLPinConnectInfo var_4_7C_cp_0 = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j];
							if (this.gLineTestProcessor.gDLPinConnectInfoArray[i].mnSecPinNum == var_4_7C_cp_0.mnMainPinNum)
							{
								SDLPinConnectInfo var_3_AF_cp_0 = this.gLineTestProcessor.gDLPinConnectInfoArray[i];
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j].mnMainPinNum = var_3_AF_cp_0.mnMainPinNum;
								SDLPinConnectInfo var_2_DF_cp_0 = this.gLineTestProcessor.gDLPinConnectInfoArray[i];
								this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j].mnSecPinNum = var_2_DF_cp_0.mnSecPinNum;
								break;
							}
						}
					}
				}
			}
			catch (System.Exception arg_10F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_10F_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool PinRelationFitFunc()
		{
			bool fitFlag = true;
			try
			{
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				if (kLineTestProcessor.gDLPinConnectInfoArray != null && kLineTestProcessor.gDLPinConnectInfoSelfArray != null)
				{
					if (this.gLineTestProcessor.gDLPinConnectInfoArray.Count != kLineTestProcessor.gDLPinConnectInfoSelfArray.Count)
					{
						fitFlag = false;
					}
					else
					{
						int i = 0;
						IL_49:
						while (i < this.gLineTestProcessor.gDLPinConnectInfoArray.Count)
						{
							bool findFlag = false;
							int j = 0;
							while (j < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count)
							{
								SDLPinConnectInfo var_8_8F_cp_0 = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j];
								if (this.gLineTestProcessor.gDLPinConnectInfoArray[i].mnMainPinNum == var_8_8F_cp_0.mnMainPinNum)
								{
									SDLPinConnectInfo var_7_C2_cp_0 = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j];
									if (this.gLineTestProcessor.gDLPinConnectInfoArray[i].mnSecPinNum == var_7_C2_cp_0.mnSecPinNum)
									{
										goto IL_145;
									}
								}
								SDLPinConnectInfo var_6_F5_cp_0 = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j];
								if (this.gLineTestProcessor.gDLPinConnectInfoArray[i].mnMainPinNum == var_6_F5_cp_0.mnSecPinNum)
								{
									SDLPinConnectInfo var_5_128_cp_0 = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j];
									if (this.gLineTestProcessor.gDLPinConnectInfoArray[i].mnSecPinNum == var_5_128_cp_0.mnMainPinNum)
									{
										goto IL_145;
									}
								}
								j++;
								continue;
								IL_145:
								IL_155:
								i++;
								goto IL_49;
							}
							if (findFlag)
							{
								goto IL_155;
							}
							fitFlag = false;
							break;
						}
					}
				}
			}
			catch (System.Exception arg_163_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_163_0.StackTrace);
			}
			return fitFlag;
		}
		public void EmulationModeSelfStudyFunc()
		{
			try
			{
				ctFormSelfStudy ctFormSelfStudy = new ctFormSelfStudy(this.gLineTestProcessor, this.bcCableStr);
				this.selfStudyForm = ctFormSelfStudy;
				ctFormSelfStudy.Activate();
				this.selfStudyForm.ShowDialog();
				if (!this.selfStudyForm.bImportFlag)
				{
					this.selfStudyForm = null;
					this.FreeSystemMemoryResourcesFunc();
				}
				else
				{
					this.SelfStudyLoadCableDealFunc();
					if (!this.PinRelationFitFunc())
					{
						MessageBox.Show("已定义连接关系与自学习芯线关系不一致!", "提示", MessageBoxButtons.OK);
						ctFormPinPinContrast ctFormPinPinContrast = new ctFormPinPinContrast(this.gLineTestProcessor);
						this.pinPinContrastForm = ctFormPinPinContrast;
						ctFormPinPinContrast.Activate();
						this.pinPinContrastForm.ShowDialog();
						if (DialogResult.Yes != MessageBox.Show("是否将自学习芯线关系导入到当前项目?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
						{
							this.pinPinContrastForm = null;
							this.FreeSystemMemoryResourcesFunc();
							return;
						}
						this.bSelfStudyPinTestFlag = true;
						this.QeuryExistMapFunc();
						if (!this.bIsExistMapFlag)
						{
							this.bSelfStudyPinTestFlag = false;
							MessageBox.Show(this.noMapZJTpinHintStr, "提示", MessageBoxButtons.OK);
							return;
						}
						this.UpdateDVGDataSelfStudyDisposeFunc();
						this.QueryValidJYNYTestNumFunc();
						if (DialogResult.Yes == MessageBox.Show("是否更新数据库中线束连接关系，这将替换已定义连接关系?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
						{
							if (this.SaveCablePinRelationFunc())
							{
								MessageBox.Show("线束连接关系更新成功!", "提示", MessageBoxButtons.OK);
								KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
								if (kLineTestProcessor.gDLPinConnectInfoArray != null)
								{
									kLineTestProcessor.gDLPinConnectInfoArray.Clear();
									for (int i = 0; i < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; i++)
									{
										this.gLineTestProcessor.gDLPinConnectInfoArray.Add(this.gLineTestProcessor.gDLPinConnectInfoSelfArray[i]);
									}
								}
							}
							else
							{
								MessageBox.Show("线束连接关系更新失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}
						}
					}
					else
					{
						MessageBox.Show("已定义连接关系与自学习芯线关系相同!", "提示", MessageBoxButtons.OK);
					}
					System.GC.Collect();
					System.GC.WaitForPendingFinalizers();
				}
			}
			catch (System.Exception arg_1B0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1B0_0.StackTrace);
			}
		}
		private void MenuItem_SelfStudy_Click(object sender, System.EventArgs e)
		{
			try
			{
				KLineTestProcessor this2 = this.gLineTestProcessor;
				if (this2.bEmulationMode)
				{
					this.EmulationModeSelfStudyFunc();
				}
				else if (!this2.bIsConnSuccFlag)
				{
					MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
				}
				else if (!this2.bOpenProjectFlag)
				{
					ctFormSelfStudy ctFormSelfStudy = new ctFormSelfStudy(this2, "");
					this.selfStudyForm = ctFormSelfStudy;
					ctFormSelfStudy.Activate();
					this.selfStudyForm.ShowDialog();
					this.selfStudyForm = null;
					this.FreeSystemMemoryResourcesFunc();
				}
				else
				{
					ctFormSelfStudy ctFormSelfStudy2 = new ctFormSelfStudy(this2, this.bcCableStr);
					this.selfStudyForm = ctFormSelfStudy2;
					ctFormSelfStudy2.Activate();
					this.selfStudyForm.ShowDialog();
					if (!this.selfStudyForm.bImportFlag)
					{
						this.selfStudyForm = null;
						this.FreeSystemMemoryResourcesFunc();
					}
					else
					{
						this.SelfStudyPinRelaReviseFunc();
						this.SelfStudyLoadCableDealFunc();
						if (!this.PinRelationFitFunc())
						{
							if (DialogResult.Yes == MessageBox.Show("已定义连接关系与自学习芯线关系不一致!是否查看明细?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
							{
								ctFormPinPinContrast e2 = new ctFormPinPinContrast(this.gLineTestProcessor);
								this.pinPinContrastForm = e2;
								e2.Activate();
								this.pinPinContrastForm.ShowDialog();
								this.pinPinContrastForm = null;
								this.FreeSystemMemoryResourcesFunc();
							}
							this.bSelfStudyPinTestFlag = true;
							this.QeuryExistMapFunc();
							if (!this.bIsExistMapFlag)
							{
								this.bSelfStudyPinTestFlag = false;
								MessageBox.Show(this.noMapZJTpinHintStr, "提示", MessageBoxButtons.OK);
								return;
							}
							this.gLineTestProcessor.groupTestParaInfo.bGroupTestFlag = false;
							this.UpdateDVGDataSelfStudyDisposeFunc();
							this.QueryValidJYNYTestNumFunc();
							if (DialogResult.Yes == MessageBox.Show("是否更新线束连接关系，这将替换已定义连接关系?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
							{
								if (this.SaveCablePinRelationFunc())
								{
									this.gLineTestProcessor.gDLPinConnectInfoArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
									for (int i = 0; i < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; i++)
									{
										this.gLineTestProcessor.gDLPinConnectInfoArray.Add(this.gLineTestProcessor.gDLPinConnectInfoSelfArray[i]);
									}
									MessageBox.Show("线束连接关系更新成功!", "提示", MessageBoxButtons.OK);
									this.GetGroupTestParaDataFunc();
								}
								else
								{
									MessageBox.Show("线束连接关系更新失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								}
							}
						}
						else
						{
							MessageBox.Show("已定义连接关系与自学习芯线关系相同!", "提示", MessageBoxButtons.OK);
						}
						System.GC.Collect();
						System.GC.WaitForPendingFinalizers();
					}
				}
			}
			catch (System.Exception arg_224_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_224_0.StackTrace);
			}
		}
		private void panel_projectTest_VisibleChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.gLineTestProcessor.bOpenProjectFlag = this.panel_projectTest.Visible;
			}
			catch (System.Exception arg_18_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_18_0.StackTrace);
			}
		}
		private void MenuItem_ErrorQuery_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormErrorQuery this2 = new ctFormErrorQuery(this.gLineTestProcessor);
				this.errorQueryForm = this2;
				this2.Activate();
				this.errorQueryForm.ShowDialog();
				this.errorQueryForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_34_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_34_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool QueryExistTestDataFunc()
		{
			bool bEmptyFlag = true;
			try
			{
				for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
				{
					if (this.dataGridView1.Rows[i].Cells[this.iDTTValueColNum].Value != null)
					{
						string tempStr = this.dataGridView1.Rows[i].Cells[this.iDTTValueColNum].Value.ToString();
						if (tempStr != ctFormMain.UN_TEST_COMM_STR)
						{
							bEmptyFlag = false;
							break;
						}
					}
					if (this.dataGridView1.Rows[i].Cells[this.iJYTValueColNum].Value != null)
					{
						string tempStr = this.dataGridView1.Rows[i].Cells[this.iJYTValueColNum].Value.ToString();
						if (tempStr != ctFormMain.UN_TEST_COMM_STR)
						{
							bEmptyFlag = false;
							break;
						}
					}
					if (this.dataGridView1.Rows[i].Cells[this.iNYTValueColNum].Value != null)
					{
						string tempStr = this.dataGridView1.Rows[i].Cells[this.iNYTValueColNum].Value.ToString();
						if (tempStr != ctFormMain.UN_TEST_COMM_STR)
						{
							bEmptyFlag = false;
							break;
						}
					}
				}
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				if (kLineTestProcessor.gDLPinConnectInfoDLResultArray != null && kLineTestProcessor.gDLPinConnectInfoDLResultArray.Count > 0)
				{
					bEmptyFlag = false;
				}
				KLineTestProcessor kLineTestProcessor2 = this.gLineTestProcessor;
				if (kLineTestProcessor2.gDLPinConnectInfoDDJYArray != null && kLineTestProcessor2.gDLPinConnectInfoDDJYArray.Count > 0)
				{
					bEmptyFlag = false;
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
			return bEmptyFlag;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool SaveTestDataToDBFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				byte result;
				if (this.bIsSaveDataFlag)
				{
					MessageBox.Show("数据已保存，请勿重复操作!", "提示", MessageBoxButtons.OK);
					result = 0;
					return result != 0;
				}
				this.TestResultQureyFunc();
				System.DateTime now = System.DateTime.Now;
				this.dt = now;
				string text = "";
				string dtValueStr = text;
				string jyValueStr = text;
				string nyValueStr = text;
				string dtTestResultStr = text;
				string jyTestResultStr = text;
				string nyTestResultStr = text;
				string tempIDStr = text;
				string tempStr = text;
				int iTemp = 1;
				bool flag;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.mddbPathStr;
					connection.Open();
					string sqlcommand;
					OleDbCommand cmd;
					try
					{
						sqlcommand = "select * from TTestNumber";
						cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						if (dataReader.Read())
						{
							tempStr = dataReader["CTestNumber"].ToString();
						}
						dataReader.Close();
						dataReader = null;
					}
					catch (System.Exception arg_BF_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_BF_0.StackTrace);
						if (dataReader != null)
						{
							dataReader.Close();
							dataReader = null;
						}
					}
					try
					{
						iTemp = System.Convert.ToInt32(tempStr);
					}
					catch (System.Exception ex_E2)
					{
					}
					this.ctTestNumberStr = System.Convert.ToString(iTemp);
					try
					{
						string str = ",";
						string str2 = "','";
						sqlcommand = "insert into THistoryDataInfo(TestNumber,ProjectName,batchMumberStr,bcCableName,TestTime,Tester,Operator,EnvironmentTemperature,AmbientHumidity,CSYType,CSYMeasuringNumber,TestResult," + "DTRange,DTVoltage,DTCurrent,JYRange,JYTime,JYVolt,JYUPTime,NYRange,NYTime,NYVolt,DTTFFlag,DLTFFlag,JYTFFlag,DDJYTFFlag,NYTFFlag,iHintDTExcNum,iHintDLExcNum,iHintJYExcNum,iHintDDJYExcNum,iHintNYExcNum) " +
							"values('" + this.ctTestNumberStr + str2 + this.testProjectNameStr + str2 + this.batchMumberStr + str2 + this.bcCableStr + "',#" + this.dt + "#,'" + this.gLineTestProcessor.loginUserID + str2 + this.ct_TestUserNameStr + str2 + this.ct_TestEnvironmentTempStr + str2 + this.ct_TestAmbientHumidityStr + str2 + this.ct_TestCSYTypeStr + str2 + this.ct_TestCSYMeasureNoStr + str2 + this.testResultStr + str2 + 
							this.ct_DTLimitValueStr + str2 + this.ct_DTVoltageStr + str2 + this.ct_DTCurrentStr + str2 + this.ct_JYLimitValueStr + str2 + this.ct_JYHoldTimeStr + str2 + this.ct_JYDCHighVoltStr + str2 + this.ct_JYDCRiseTimeStr + str2 + this.ct_NYLimitValueStr + str2 + this.ct_NYHoldTimeStr + str2 + this.ct_NYACHighVoltStr + "'," + this.iDTTFFlag + str + this.iDLTFFlag + str + this.iJYTFFlag + str + this.iDDJYTFFlag + 
							str + this.iNYTFFlag + str + this.iHintDTExcNum + str + this.iHintDLExcNum + str + this.iHintJYExcNum + str + this.iHintDDJYExcNum + str + this.iHintNYExcNum + ")";
						cmd = new OleDbCommand(sqlcommand, connection);
						cmd.ExecuteNonQuery();
					}
					catch (System.Exception arg_399_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_399_0.StackTrace);
					}
					System.Threading.Thread.Sleep(50);
					try
					{
						sqlcommand = "select top 1 * from THistoryDataInfo order by ID desc";
						cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						if (dataReader.Read())
						{
							tempIDStr = dataReader["ID"].ToString();
						}
						dataReader.Close();
						dataReader = null;
					}
					catch (System.Exception arg_3EA_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_3EA_0.StackTrace);
						if (dataReader != null)
						{
							dataReader.Close();
							dataReader = null;
						}
					}
					if (string.IsNullOrEmpty(tempIDStr))
					{
						connection.Close();
						connection = null;
						result = 0;
						return result != 0;
					}
					this.iHistoryDataInfoID = System.Convert.ToInt32(tempIDStr);
					for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
					{
						text = "";
						dtValueStr = text;
						jyValueStr = text;
						nyValueStr = text;
						dtTestResultStr = text;
						jyTestResultStr = text;
						nyTestResultStr = text;
						string temp1Str = text;
						string temp2Str = text;
						string temp3Str = text;
						string temp4Str = text;
						try
						{
							if (this.dataGridView1.Rows[i].Cells[this.iDTTValueColNum].Value != null)
							{
								dtValueStr = this.dataGridView1.Rows[i].Cells[this.iDTTValueColNum].Value.ToString();
							}
							if (this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value != null)
							{
								dtTestResultStr = this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value.ToString();
							}
							if (this.dataGridView1.Rows[i].Cells[this.iJYTValueColNum].Value != null)
							{
								jyValueStr = this.dataGridView1.Rows[i].Cells[this.iJYTValueColNum].Value.ToString();
							}
							if (this.dataGridView1.Rows[i].Cells[this.iJYResultColNum].Value != null)
							{
								jyTestResultStr = this.dataGridView1.Rows[i].Cells[this.iJYResultColNum].Value.ToString();
							}
							if (this.dataGridView1.Rows[i].Cells[this.iNYTValueColNum].Value != null)
							{
								nyValueStr = this.dataGridView1.Rows[i].Cells[this.iNYTValueColNum].Value.ToString();
							}
							if (this.dataGridView1.Rows[i].Cells[this.iNYResultColNum].Value != null)
							{
								nyTestResultStr = this.dataGridView1.Rows[i].Cells[this.iNYResultColNum].Value.ToString();
							}
							if (this.dataGridView1.Rows[i].Cells[1].Value != null)
							{
								temp1Str = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
							}
							if (this.dataGridView1.Rows[i].Cells[2].Value != null)
							{
								temp2Str = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
							}
							if (this.dataGridView1.Rows[i].Cells[3].Value != null)
							{
								temp3Str = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
							}
							if (this.dataGridView1.Rows[i].Cells[4].Value != null)
							{
								temp4Str = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
							}
						}
						catch (System.Exception arg_791_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_791_0.StackTrace);
						}
						string str3 = "','";
						sqlcommand = "insert into THistoryDataDetail(HID,PlugName1,Pin1,PlugName2,Pin2,DTValue,dtTestResult,JYValue,jyTestResult,NYValue,nyTestResult) values(" + this.iHistoryDataInfoID + ",'" + temp1Str + str3 + temp2Str + str3 + temp3Str + str3 + temp4Str + str3 + dtValueStr + str3 + dtTestResultStr + str3 + jyValueStr + str3 + jyTestResultStr + str3 + nyValueStr + str3 + nyTestResultStr + "')";
						cmd = new OleDbCommand(sqlcommand, connection);
						cmd.ExecuteNonQuery();
					}
					System.Threading.Thread.Sleep(10);
					if (this.gLineTestProcessor.gDLPinConnectInfoDLResultArray != null)
					{
						for (int j = 0; j < this.gLineTestProcessor.gDLPinConnectInfoDLResultArray.Count; j++)
						{
							string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoDLResultArray[j].mALJQName;
							string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoDLResultArray[j].mnALJQPinNum;
							string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoDLResultArray[j].mBLJQName;
							string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoDLResultArray[j].mnBLJQPinNum;
							string str4 = "','";
							sqlcommand = "insert into THistoryDLDataDetail(HID,PlugName1,Pin1,PlugName2,Pin2,DTValue,dtTestResult) values(" + this.iHistoryDataInfoID + ",'" + temp1Str + str4 + temp2Str + str4 + temp3Str + str4 + temp4Str + "','','')";
							cmd = new OleDbCommand(sqlcommand, connection);
							cmd.ExecuteNonQuery();
						}
						System.Threading.Thread.Sleep(10);
					}
					KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
					if (kLineTestProcessor.gDLPinConnectInfoDDJYArray != null)
					{
						if (kLineTestProcessor.gDLPinConnectInfoDDJYArray.Count <= 0)
						{
							this.GetDDJYPinNameListFunc();
							for (int k = 0; k < this.ddjyTHeadNameList.Count; k++)
							{
								string temp1Str = this.ddjyTHeadNameList[k];
								string temp2Str = "地";
								text = "";
								string temp3Str = text;
								string temp4Str = text;
								string str5 = "','','";
								sqlcommand = "insert into THistoryDDJYDataDetail(HID,PlugName1,Pin1,PlugName2,Pin2,TestValue,TestResult) values(" + this.iHistoryDataInfoID + ",'" + temp1Str + str5 + temp2Str + str5 + temp3Str + "','" + temp4Str + "')";
								cmd = new OleDbCommand(sqlcommand, connection);
								cmd.ExecuteNonQuery();
							}
						}
						else
						{
							for (int l = 0; l < this.gLineTestProcessor.gDLPinConnectInfoDDJYArray.Count; l++)
							{
								string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoDDJYArray[l].mALJQName;
								string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoDDJYArray[l].mBLJQName;
								string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoDDJYArray[l].strDDJYTestValue;
								string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoDDJYArray[l].strDDjyTestResult;
								string str6 = "','','";
								sqlcommand = "insert into THistoryDDJYDataDetail(HID,PlugName1,Pin1,PlugName2,Pin2,TestValue,TestResult) values(" + this.iHistoryDataInfoID + ",'" + temp1Str + str6 + temp2Str + str6 + temp3Str + "','" + temp4Str + "')";
								cmd = new OleDbCommand(sqlcommand, connection);
								cmd.ExecuteNonQuery();
							}
						}
					}
					System.Threading.Thread.Sleep(10);
					sqlcommand = "update TTestNumber set CTestNumber = " + (System.Convert.ToInt32(this.ctTestNumberStr) + 1);
					cmd = new OleDbCommand(sqlcommand, connection);
					cmd.ExecuteNonQuery();
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_BBA_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_BBA_0.StackTrace);
					if (dataReader != null)
					{
						dataReader.Close();
						dataReader = null;
					}
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
					MessageBox.Show("数据库操作异常!", "提示", MessageBoxButtons.OK);
					flag = false;
					goto IL_C04;
				}
				if (!this.bIsSaveDataFlag)
				{
					this.bIsSaveDataFlag = true;
				}
				return true;
				IL_C04:
				result = (flag ? 1 : 0);
				return result != 0;
			}
			catch (System.Exception arg_C0A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_C0A_0.StackTrace);
			}
			return true;
		}
		private void btnSaveTestData_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.bIsTestStatus)
				{
					if (this.QueryExistTestDataFunc())
					{
						MessageBox.Show("无测试数据可保存!", "提示", MessageBoxButtons.OK);
					}
					else if (this.SaveTestDataToDBFunc())
					{
						MessageBox.Show("保存成功!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_40_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_40_0.StackTrace);
			}
		}
		private void MenuItem_TestEnvironmentParameter_Click(object sender, System.EventArgs e)
		{
			try
			{
				KLineTestProcessor expr_06 = this.gLineTestProcessor;
				ctFormEnvironmentParaSet sender2 = new ctFormEnvironmentParaSet(expr_06, expr_06.loginUserID);
				this.environmentParaSetForm = sender2;
				sender2.Activate();
				this.environmentParaSetForm.ShowDialog();
				ctFormEnvironmentParaSet this2 = this.environmentParaSetForm;
				if (this2.bTJFlag)
				{
					this.bEnvironmentParaSetFlag = true;
					this.ct_TestEnvironmentTempStr = this2.hjwdStr;
					this.ct_TestAmbientHumidityStr = this2.hjsdStr;
				}
				this.environmentParaSetForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_68_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_68_0.StackTrace);
			}
		}
		private void MenuItem_ResistanceCompensation_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			try
			{
				if (this.MenuItem_ResistanceCompensation.Checked)
				{
					this.MenuItem_ResistanceCompensation.Checked = false;
				}
				else
				{
					this.MenuItem_ResistanceCompensation.Checked = true;
				}
				this.gLineTestProcessor.bResistanceCompFlag = this.MenuItem_ResistanceCompensation.Checked;
				int irc = 0;
				if (this.gLineTestProcessor.bResistanceCompFlag)
				{
					irc = 1;
				}
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					new OleDbCommand("update TUserCustomCableTestPara set IsResistanceCompensation = " + irc + " where LoginUser='" + this.gLineTestProcessor.loginUserID + "'", connection).ExecuteNonQuery();
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_B8_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_B8_0.StackTrace);
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
				KLineTestProcessor sender2 = this.gLineTestProcessor;
				if (sender2.bResistanceCompFlag)
				{
					if (sender2.gDLPinConnectInfoSelfArray != null && sender2.gDLPinConnectInfoSelfArray.Count > 0)
					{
						this.gLineTestProcessor.LoadAPinBuChangDataSelfStudy();
					}
					sender2 = this.gLineTestProcessor;
					if (sender2.gDLPinConnectInfoArray != null && sender2.gDLPinConnectInfoArray.Count > 0)
					{
						this.gLineTestProcessor.LoadAPinBuChangData();
					}
				}
			}
			catch (System.Exception arg_129_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_129_0.StackTrace);
			}
		}
		private void MenuItem_RCM_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormResistanceCompensation e2 = new ctFormResistanceCompensation(this.gLineTestProcessor);
				this.resistanceCompensationForm = e2;
				e2.Activate();
				this.resistanceCompensationForm.ShowDialog();
				if (!this.resistanceCompensationForm.bUpdateFlag)
				{
					this.resistanceCompensationForm = null;
					this.FreeSystemMemoryResourcesFunc();
				}
				else
				{
					KLineTestProcessor sender2 = this.gLineTestProcessor;
					if (sender2.gDLPinConnectInfoSelfArray != null && sender2.gDLPinConnectInfoSelfArray.Count > 0)
					{
						this.gLineTestProcessor.LoadAPinBuChangDataSelfStudy();
					}
					KLineTestProcessor this2 = this.gLineTestProcessor;
					if (this2.gDLPinConnectInfoArray != null && this2.gDLPinConnectInfoArray.Count > 0)
					{
						this.gLineTestProcessor.LoadAPinBuChangData();
					}
					this.resistanceCompensationForm = null;
					this.FreeSystemMemoryResourcesFunc();
				}
			}
			catch (System.Exception arg_A0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_A0_0.StackTrace);
			}
		}
		public void QureyDLDealwithFunc()
		{
			KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
			if (kLineTestProcessor.gDLPinConnectInfoDLTempArray == null)
			{
				this.gLineTestProcessor.gDLPinConnectInfoDLTempArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
			}
			else
			{
				kLineTestProcessor.gDLPinConnectInfoDLTempArray.Clear();
			}
			KLineTestProcessor kLineTestProcessor2 = this.gLineTestProcessor;
			if (kLineTestProcessor2.gDLPinConnectInfoDLArray != null && kLineTestProcessor2.gDLPinConnectInfoDLArray.Count > 0)
			{
				new System.Collections.Generic.List<string>();
				new System.Collections.Generic.List<string>();
				new System.Collections.Generic.List<string>();
				new System.Collections.Generic.List<string>();
				if (!this.bSelfStudyPinTestFlag)
				{
					try
					{
						int ii = 0;
						IL_7B:
						while (ii < this.gLineTestProcessor.gDLPinConnectInfoDLArray.Count)
						{
							bool bExistFlag = false;
							string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[ii].mALJQName;
							string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[ii].mnALJQPinNum;
							string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[ii].mBLJQName;
							string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[ii].mnBLJQPinNum;
							for (int jj = 0; jj < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; jj++)
							{
								string temp5Str = this.gLineTestProcessor.gDLPinConnectInfoArray[jj].mALJQName;
								string temp6Str = this.gLineTestProcessor.gDLPinConnectInfoArray[jj].mnALJQPinNum;
								string temp7Str = this.gLineTestProcessor.gDLPinConnectInfoArray[jj].mBLJQName;
								string temp8Str = this.gLineTestProcessor.gDLPinConnectInfoArray[jj].mnBLJQPinNum;
								if ((0 == temp1Str.CompareTo(temp5Str) && 0 == temp2Str.CompareTo(temp6Str) && 0 == temp3Str.CompareTo(temp7Str) && 0 == temp4Str.CompareTo(temp8Str)) || (0 == temp3Str.CompareTo(temp5Str) && 0 == temp4Str.CompareTo(temp6Str) && 0 == temp1Str.CompareTo(temp7Str) && 0 == temp2Str.CompareTo(temp8Str)))
								{
									IL_1E0:
									IL_22D:
									ii++;
									goto IL_7B;
								}
							}
							if (bExistFlag)
							{
								goto IL_1E0;
							}
							if (!this.bExistDLFlag)
							{
								this.bExistDLFlag = true;
							}
							SDLPinConnectInfo SDLPinConnectInfoTemp = new SDLPinConnectInfo();
							SDLPinConnectInfoTemp.mALJQName = temp1Str;
							SDLPinConnectInfoTemp.mnALJQPinNum = temp2Str;
							SDLPinConnectInfoTemp.mBLJQName = temp3Str;
							SDLPinConnectInfoTemp.mnBLJQPinNum = temp4Str;
							this.gLineTestProcessor.gDLPinConnectInfoDLTempArray.Add(SDLPinConnectInfoTemp);
							goto IL_22D;
						}
						return;
					}
					catch (System.Exception arg_23D_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_23D_0.StackTrace);
						return;
					}
				}
				try
				{
					int ii2 = 0;
					IL_24F:
					while (ii2 < this.gLineTestProcessor.gDLPinConnectInfoDLArray.Count)
					{
						bool bExistFlag = false;
						string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[ii2].mALJQName;
						string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[ii2].mnALJQPinNum;
						string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[ii2].mBLJQName;
						string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoDLArray[ii2].mnBLJQPinNum;
						for (int jj2 = 0; jj2 < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; jj2++)
						{
							string temp5Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mALJQName;
							string temp6Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mnALJQPinNum;
							string temp7Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mBLJQName;
							string temp8Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj2].mnBLJQPinNum;
							if ((0 == temp1Str.CompareTo(temp5Str) && 0 == temp2Str.CompareTo(temp6Str) && 0 == temp3Str.CompareTo(temp7Str) && 0 == temp4Str.CompareTo(temp8Str)) || (0 == temp3Str.CompareTo(temp5Str) && 0 == temp4Str.CompareTo(temp6Str) && 0 == temp1Str.CompareTo(temp7Str) && 0 == temp2Str.CompareTo(temp8Str)))
							{
								IL_3AF:
								IL_3FC:
								ii2++;
								goto IL_24F;
							}
						}
						if (bExistFlag)
						{
							goto IL_3AF;
						}
						if (!this.bExistDLFlag)
						{
							this.bExistDLFlag = true;
						}
						SDLPinConnectInfo SDLPinConnectInfoTemp2 = new SDLPinConnectInfo();
						SDLPinConnectInfoTemp2.mALJQName = temp1Str;
						SDLPinConnectInfoTemp2.mnALJQPinNum = temp2Str;
						SDLPinConnectInfoTemp2.mBLJQName = temp3Str;
						SDLPinConnectInfoTemp2.mnBLJQPinNum = temp4Str;
						this.gLineTestProcessor.gDLPinConnectInfoDLTempArray.Add(SDLPinConnectInfoTemp2);
						goto IL_3FC;
					}
				}
				catch (System.Exception arg_407_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_407_0.StackTrace);
				}
			}
		}
		public void GetDLTestPinRelationFunc()
		{
			try
			{
				this.gLineTestProcessor.gDLPinConnectInfoDLResultArray.Clear();
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				if (kLineTestProcessor.gDLPinConnectInfoDLTempArray != null)
				{
					if (kLineTestProcessor.gDLPinConnectInfoDLTempArray.Count > 0)
					{
						for (int i = 0; i < this.gLineTestProcessor.gDLPinConnectInfoDLTempArray.Count; i++)
						{
							this.gLineTestProcessor.gDLPinConnectInfoDLResultArray.Add(this.gLineTestProcessor.gDLPinConnectInfoDLTempArray[i]);
						}
					}
				}
			}
			catch (System.Exception arg_6F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_6F_0.StackTrace);
			}
		}
		public void TestResultQureyFunc()
		{
			try
			{
				this.testResultStr = ctFormMain.TEST_QUAL_STR;
				for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
				{
					if (this.iDTTFFlag == 1 && this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value != null)
					{
						string tempStr = this.dataGridView1.Rows[i].Cells[this.iDTResultColNum].Value.ToString();
						if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
						{
							this.testResultStr = ctFormMain.TEST_NOT_QUAL_STR;
							break;
						}
					}
					if (this.iJYTFFlag == 1 && this.dataGridView1.Rows[i].Cells[this.iJYResultColNum].Value != null)
					{
						string tempStr = this.dataGridView1.Rows[i].Cells[this.iJYResultColNum].Value.ToString();
						if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
						{
							this.testResultStr = ctFormMain.TEST_NOT_QUAL_STR;
							break;
						}
					}
					if (this.iNYTFFlag == 1 && this.dataGridView1.Rows[i].Cells[this.iNYResultColNum].Value != null)
					{
						string tempStr = this.dataGridView1.Rows[i].Cells[this.iNYResultColNum].Value.ToString();
						if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
						{
							this.testResultStr = ctFormMain.TEST_NOT_QUAL_STR;
							break;
						}
					}
				}
				if (this.iDLTFFlag == 1)
				{
					KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
					if (kLineTestProcessor.gDLPinConnectInfoDLResultArray != null && kLineTestProcessor.gDLPinConnectInfoDLResultArray.Count > 0)
					{
						this.testResultStr = ctFormMain.TEST_NOT_QUAL_STR;
					}
				}
				if (this.iDDJYTFFlag == 1 && this.gLineTestProcessor.gDLPinConnectInfoDDJYArray != null)
				{
					for (int j = 0; j < this.gLineTestProcessor.gDLPinConnectInfoDDJYArray.Count; j++)
					{
						string tempStr = this.gLineTestProcessor.gDLPinConnectInfoDDJYArray[j].strDDjyTestResult;
						if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
						{
							this.testResultStr = ctFormMain.TEST_NOT_QUAL_STR;
							break;
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		public void EmulationModeSetTestData_DLFunc()
		{
			try
			{
				KLineTestProcessor this2 = this.gLineTestProcessor;
				if (!this2.bEmulationMode)
				{
					return;
				}
				int[] iPlugPinStartArray = this2.iPlugPinStartArray;
				int num = this.iPlugPinIndex;
				if (num < iPlugPinStartArray.Length)
				{
					this.iCurrentCount = iPlugPinStartArray[num];
					int num2 = this2.iPlugPinStopArray[num];
					if (num2 > 4)
					{
						for (int i = 0; i < num2; i++)
						{
							KParseRepCmd mParseCmd = this2.mpDevComm.mParseCmd;
							mParseCmd.firstPinArray[mParseCmd.selfStudyPinNum] = this.iCurrentCount;
							int num3 = this.iCurrentCount + 1;
							this.iCurrentCount = num3;
							int num4 = num3 + 1;
							this.iCurrentCount = num4;
							KParseRepCmd mParseCmd2 = this.gLineTestProcessor.mpDevComm.mParseCmd;
							mParseCmd2.secondPinArray[mParseCmd2.selfStudyPinNum] = num4;
							int num5 = this.iCurrentCount + 1;
							this.iCurrentCount = num5;
							this.iCurrentCount = num5 + 1;
							this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyPinNum++;
							this2 = this.gLineTestProcessor;
							num2 = this2.iPlugPinStopArray[this.iPlugPinIndex];
							if (num2 < this.iCurrentCount + 3)
							{
								break;
							}
						}
					}
					else
					{
						for (int j = 0; j < num2; j++)
						{
							KParseRepCmd mParseCmd3 = this2.mpDevComm.mParseCmd;
							mParseCmd3.firstPinArray[mParseCmd3.selfStudyPinNum] = this.iCurrentCount;
							int num6 = this.iCurrentCount + 1;
							this.iCurrentCount = num6;
							KParseRepCmd mParseCmd4 = this.gLineTestProcessor.mpDevComm.mParseCmd;
							mParseCmd4.secondPinArray[mParseCmd4.selfStudyPinNum] = num6;
							this.iCurrentCount++;
							this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyPinNum++;
							this2 = this.gLineTestProcessor;
							num2 = this2.iPlugPinStopArray[this.iPlugPinIndex];
							if (num2 < this.iCurrentCount + 1)
							{
								break;
							}
						}
					}
					this.iCurrentCount = 0;
					this.iPlugPinIndex++;
				}
			}
			catch (System.Exception arg_1FC_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1FC_0.StackTrace);
			}
			try
			{
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				if (this.iPlugPinIndex >= kLineTestProcessor.iPlugPinStartArray.Length)
				{
					kLineTestProcessor.mpDevComm.mParseCmd.selfStudyProgress = 100;
				}
			}
			catch (System.Exception arg_236_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_236_0.StackTrace);
			}
		}
		private void timer_dlTest_Tick(object sender, System.EventArgs e)
		{
			try
			{
				this.iDLTestTime++;
				KLineTestProcessor sender2 = this.gLineTestProcessor;
				if (sender2.iTestPreValue != 100)
				{
					if (sender2.mpDevComm.mParseCmd.selfStudyProgress != 100)
					{
						this.EmulationModeSetTestData_DLFunc();
						int iProc = System.Convert.ToInt32((double)this.iDLTestTime * 100.0 / ((double)this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyCount / 60.0));
						if (iProc < 99)
						{
							iProc++;
						}
						sender2 = this.gLineTestProcessor;
						if (!sender2.bEmulationMode && iProc >= 100)
						{
							iProc = 99;
						}
						sender2.iTestPreValue = iProc;
					}
					else
					{
						sender2.iTestPreValue = 100;
					}
					this.progressBar_test.Value = this.gLineTestProcessor.iTestPreValue;
					this.label_progress.Text = System.Convert.ToString(this.gLineTestProcessor.iTestPreValue) + "%";
				}
				else
				{
					this.TestFinishedDisposeFunc();
					this.otsShowInfoStr = "测试完成";
					System.Drawing.Color steelBlue = System.Drawing.Color.SteelBlue;
					this.otsShowInfoColor = steelBlue;
					this.RefreshOTSDisposeFunc();
					System.Threading.Thread.Sleep(50);
					this.gLineTestProcessor.ExportSELFTestDL();
					System.Threading.Thread.Sleep(50);
					this.SelfStudyLoadCable_DLDealFunc();
					this.QureyDLDealwithFunc();
					this.GetDLTestPinRelationFunc();
					this.CalcFailCountAndRefreshUIFunc();
					this.gLineTestProcessor.SendStopCmd();
					if (!this.bExistDLFlag)
					{
						MessageBox.Show("测试结束，无短路!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						MessageBox.Show("测试结束，存在短路情况!", "提示", MessageBoxButtons.OK);
						ctFormDLTestResultView e2 = new ctFormDLTestResultView(this.gLineTestProcessor, false, 0);
						this.DLTestResultViewForm = e2;
						e2.Activate();
						this.DLTestResultViewForm.ShowDialog();
					}
				}
			}
			catch (System.Exception arg_19A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_19A_0.StackTrace);
			}
		}
		public void GetDDJYTestDataFunc()
		{
			try
			{
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				if (kLineTestProcessor.ddjyTHeadNameList != null)
				{
					kLineTestProcessor.gDLPinConnectInfoDDJYArray.Clear();
					this.gLineTestProcessor.gDLPinConnectInfoDDJYArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
					string valueStr = "";
					int i = 0;
					while (i < this.gLineTestProcessor.ddjyTHeadNameList.Count && i < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count)
					{
						SDLPinConnectInfo SDLPinConnectInfoTemp = new SDLPinConnectInfo();
						SDLPinConnectInfoTemp.mALJQName = this.gLineTestProcessor.ddjyTHeadNameList[i];
						SDLPinConnectInfoTemp.mBLJQName = "地";
						double dTestValue = System.Math.Abs(this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mdTestResult) / 1000.0;
						int iIndexNum = 0;
						kLineTestProcessor = this.gLineTestProcessor;
						int iJYTestDataShowStyle = kLineTestProcessor.iJYTestDataShowStyle;
						if (iJYTestDataShowStyle == 0)
						{
							if (dTestValue < kLineTestProcessor.Par.jyValue)
							{
								SDLPinConnectInfoTemp.strDDjyTestResult = ctFormMain.TEST_NOT_QUAL_STR;
								if (dTestValue < 1000.0)
								{
									valueStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
								}
								else
								{
									iIndexNum = 1;
									valueStr = System.Convert.ToString(System.Math.Round(dTestValue / 1000.0, 3));
								}
								goto IL_221;
							}
							SDLPinConnectInfoTemp.strDDjyTestResult = ctFormMain.TEST_QUAL_STR;
							valueStr = ">" + System.Convert.ToString(this.gLineTestProcessor.Par.jyValue) + " MΩ";
						}
						else if (iJYTestDataShowStyle == 1)
						{
							if (dTestValue >= kLineTestProcessor.Par.jyValue)
							{
								SDLPinConnectInfoTemp.strDDjyTestResult = ctFormMain.TEST_QUAL_STR;
								if (dTestValue < 1000.0)
								{
									valueStr = System.Convert.ToString(System.Math.Round(dTestValue, 3));
								}
								else
								{
									iIndexNum = 1;
									valueStr = System.Convert.ToString(System.Math.Round(dTestValue / 1000.0, 3));
								}
								goto IL_221;
							}
							SDLPinConnectInfoTemp.strDDjyTestResult = ctFormMain.TEST_NOT_QUAL_STR;
							valueStr = "<" + System.Convert.ToString(this.gLineTestProcessor.Par.jyValue) + " MΩ";
						}
						IL_29B:
						SDLPinConnectInfoTemp.strDDJYTestValue = valueStr;
						this.gLineTestProcessor.gDLPinConnectInfoDDJYArray.Add(SDLPinConnectInfoTemp);
						i++;
						continue;
						IL_221:
						int iTemp = valueStr.LastIndexOf('.');
						if (iTemp == -1)
						{
							valueStr += ".";
							for (int j = 0; j < 3; j++)
							{
								valueStr += "0";
							}
						}
						else
						{
							while (iTemp + 4 > valueStr.Length)
							{
								valueStr += "0";
								iTemp = valueStr.LastIndexOf('.');
							}
						}
						if (iIndexNum != 1)
						{
							valueStr += " MΩ";
							goto IL_29B;
						}
						valueStr += " GΩ";
						goto IL_29B;
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		public void EmulationModeSetTestData_DDJYFunc()
		{
			try
			{
				if (!this.gLineTestProcessor.bEmulationMode)
				{
					return;
				}
				TestCmdMap tempcmdinfo = new TestCmdMap();
				tempcmdinfo.mdTestResult = (double)(this.gLineTestProcessor.mpDevComm.iEMSetTestDataIndex * 1000) + 20000.0;
				tempcmdinfo.mMainDevPinNum = 1;
				tempcmdinfo.mSecDevPinNum = 2;
				this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Add(tempcmdinfo);
			}
			catch (System.Exception arg_6A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_6A_0.StackTrace);
			}
			this.gLineTestProcessor.mpDevComm.iEMSetTestDataIndex++;
			try
			{
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				int iTemp = kLineTestProcessor.mpDevComm.iEMSetTestDataIndex * 100 / this.gLineTestProcessor.vecInt3.Count;
				if (iTemp == 0)
				{
					iTemp = 1;
				}
				else if (iTemp >= 100)
				{
					kLineTestProcessor = this.gLineTestProcessor;
					iTemp = ((kLineTestProcessor.mpDevComm.iEMSetTestDataIndex == kLineTestProcessor.vecInt3.Count) ? 100 : 99);
				}
				kLineTestProcessor.iTestPreValue = iTemp;
			}
			catch (System.Exception arg_F0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_F0_0.StackTrace);
			}
			try
			{
				KLineTestProcessor kLineTestProcessor2 = this.gLineTestProcessor;
				if (kLineTestProcessor2.iTestPreValue == 100)
				{
					kLineTestProcessor2.mhCurThreadFlagDDJY = false;
					this.gLineTestProcessor.mbKeepRun = false;
				}
			}
			catch (System.Exception arg_123_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_123_0.StackTrace);
			}
		}
		private void timer_DDJYTest_Tick(object sender, System.EventArgs e)
		{
			try
			{
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				if (kLineTestProcessor.mbKeepRun)
				{
					this.EmulationModeSetTestData_DDJYFunc();
					KLineTestProcessor sender2 = this.gLineTestProcessor;
					int this2 = sender2.iTestPreValue;
					if (this2 >= 100)
					{
						sender2.iTestPreValue = 100;
					}
					else if (this2 < 1)
					{
						sender2.iTestPreValue = this2 + 1;
					}
					this.progressBar_test.Value = this.gLineTestProcessor.iTestPreValue;
					this.label_progress.Text = System.Convert.ToString(this.gLineTestProcessor.iTestPreValue) + "%";
				}
				else if (kLineTestProcessor.iTestPreValue >= 100)
				{
					this.GetDDJYTestDataFunc();
					this.TestFinishedDisposeFunc();
					if (!this.gLineTestProcessor.bIsTimeOut)
					{
						this.otsShowInfoStr = "测试完成";
					}
					else
					{
						this.otsShowInfoStr = "测试终止";
					}
					System.Drawing.Color steelBlue = System.Drawing.Color.SteelBlue;
					this.otsShowInfoColor = steelBlue;
					this.RefreshOTSDisposeFunc();
					this.CalcFailCountAndRefreshUIFunc();
					this.ResetHVTWaitingTimeFunc();
					this.gLineTestProcessor.SendStopCmd();
					MessageBox.Show("测试结束，点击‘确定’按钮进行查看!", "提示", MessageBoxButtons.OK);
					ctFormDDJYTestResultView e2 = new ctFormDDJYTestResultView(this.gLineTestProcessor, false, 0);
					this.DDjyTestResultViewForm = e2;
					e2.Activate();
					this.DDjyTestResultViewForm.TopMost = true;
					this.DDjyTestResultViewForm.ShowDialog();
				}
			}
			catch (System.Exception arg_131_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_131_0.StackTrace);
			}
		}
		private void MenuItem_CurrentDLTestDataView_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.iDLTFFlag != 1)
				{
					MessageBox.Show("未测!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					KLineTestProcessor sender2 = this.gLineTestProcessor;
					if (sender2.gDLPinConnectInfoDLTempArray == null)
					{
						MessageBox.Show("无短路!", "提示", MessageBoxButtons.OK);
					}
					else if (sender2.gDLPinConnectInfoDLTempArray.Count > 0 && this.bExistDLFlag)
					{
						ctFormDLTestResultView this2 = new ctFormDLTestResultView(this.gLineTestProcessor, false, 0);
						this.DLTestResultViewForm = this2;
						this2.Activate();
						this.DLTestResultViewForm.ShowDialog();
					}
					else
					{
						MessageBox.Show("无短路!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_93_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_93_0.StackTrace);
			}
		}
		private void MenuItem_CurrentDDJYTestDataView_Click(object sender, System.EventArgs e)
		{
			try
			{
				KLineTestProcessor sender2 = this.gLineTestProcessor;
				if (sender2.gDLPinConnectInfoDDJYArray == null)
				{
					MessageBox.Show("未测!", "提示", MessageBoxButtons.OK);
				}
				else if (sender2.gDLPinConnectInfoDDJYArray.Count <= 0)
				{
					MessageBox.Show("未测!", "提示", MessageBoxButtons.OK);
				}
				else if (this.iDDJYTFFlag != 1)
				{
					MessageBox.Show("未测!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					ctFormDDJYTestResultView this2 = new ctFormDDJYTestResultView(this.gLineTestProcessor, false, 0);
					this.DDjyTestResultViewForm = this2;
					this2.Activate();
					this.DDjyTestResultViewForm.ShowDialog();
				}
			}
			catch (System.Exception arg_88_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_88_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool GetPlugArrayInfoFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			bool result2;
			try
			{
				string tempStr = "";
				bool flag;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select * from TLineStructLibrary where LineStructName='" + this.bcCableStr + "'", connection).ExecuteReader();
					if (dataReader.Read())
					{
						tempStr = dataReader["PlugInfo"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_7A_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_7A_0.StackTrace);
					if (dataReader != null)
					{
						dataReader.Close();
						dataReader = null;
					}
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
					flag = false;
					goto IL_18A;
				}
				int iCount = 0;
				byte result;
				if (!string.IsNullOrEmpty(tempStr))
				{
					string[] tempHeadArray = tempStr.Split(new char[]
					{
						','
					});
					for (int i = 0; i < tempHeadArray.Length; i++)
					{
						if (!string.IsNullOrEmpty(tempHeadArray[i]))
						{
							iCount++;
						}
					}
					if (iCount > 0)
					{
						this.studyPlugStrArray = new string[iCount];
						this.iPlugStartPin = new int[iCount];
						this.iPlugStopPin = new int[iCount];
						int iIndex = 0;
						for (int j = 0; j < tempHeadArray.Length; j++)
						{
							if (!string.IsNullOrEmpty(tempHeadArray[j]))
							{
								this.studyPlugStrArray[iIndex] = tempHeadArray[j];
								iIndex++;
							}
						}
						if (!this.GetStartStopPinFunc())
						{
							this.studyPlugStrArray = null;
							this.iPlugStartPin = null;
							this.iPlugStopPin = null;
							result = 0;
							return result != 0;
						}
						result = 1;
						return result != 0;
					}
				}
				this.studyPlugStrArray = null;
				this.iPlugStartPin = null;
				this.iPlugStopPin = null;
				result = 0;
				return result != 0;
				IL_18A:
				result = (flag ? 1 : 0);
				return result != 0;
			}
			catch (System.Exception arg_190_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_190_0.StackTrace);
				result2 = false;
			}
			return result2;
		}
		public void GetCurrentTestFlagFunc()
		{
			try
			{
				this.bCurrDLTestFlag = false;
				this.bCurrJYTestFlag = false;
				this.bCurrDDJYTestFlag = false;
				this.bCurrNYTestFlag = false;
				try
				{
					int iCount = 0;
					if (!this.bSelfStudyPinTestFlag)
					{
						for (int i = 0; i < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; i++)
						{
							if (this.gLineTestProcessor.gDLPinConnectInfoArray[i].iDLTestFlag == 1)
							{
								iCount++;
							}
						}
						if (iCount > 0)
						{
							this.bCurrDLTestFlag = true;
						}
						iCount = 0;
						for (int j = 0; j < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; j++)
						{
							if (this.gLineTestProcessor.gDLPinConnectInfoArray[j].iJYTestFlag == 1)
							{
								iCount++;
							}
						}
						if (iCount > 1)
						{
							this.bCurrJYTestFlag = true;
						}
						iCount = 0;
						for (int k = 0; k < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; k++)
						{
							if (this.gLineTestProcessor.gDLPinConnectInfoArray[k].iDDJYTestFlag == 1)
							{
								iCount++;
							}
						}
						if (iCount > 0)
						{
							this.bCurrDDJYTestFlag = true;
						}
						iCount = 0;
						for (int l = 0; l < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; l++)
						{
							if (this.gLineTestProcessor.gDLPinConnectInfoArray[l].iNYTestFlag == 1)
							{
								iCount++;
							}
						}
						if (iCount > 1)
						{
							this.bCurrNYTestFlag = true;
						}
					}
					else
					{
						for (int m = 0; m < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; m++)
						{
							if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray[m].iDLTestFlag == 1)
							{
								iCount++;
							}
						}
						if (iCount > 0)
						{
							this.bCurrDLTestFlag = true;
						}
						iCount = 0;
						for (int n = 0; n < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; n++)
						{
							if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray[n].iJYTestFlag == 1)
							{
								iCount++;
							}
						}
						if (iCount > 1)
						{
							this.bCurrJYTestFlag = true;
						}
						iCount = 0;
						for (int i2 = 0; i2 < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; i2++)
						{
							if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray[i2].iDDJYTestFlag == 1)
							{
								iCount++;
							}
						}
						if (iCount > 0)
						{
							this.bCurrDDJYTestFlag = true;
						}
						iCount = 0;
						for (int i3 = 0; i3 < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; i3++)
						{
							if (this.gLineTestProcessor.gDLPinConnectInfoSelfArray[i3].iNYTestFlag == 1)
							{
								iCount++;
							}
						}
						if (iCount > 1)
						{
							this.bCurrNYTestFlag = true;
						}
					}
				}
				catch (System.Exception arg_280_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_280_0.StackTrace);
				}
				this.iTestTotalCount = 1;
				if (this.bCurrDLTestFlag && this.gLineTestProcessor.bDLTestEnabled)
				{
					this.iTestTotalCount = 2;
				}
				if (this.bCurrDDJYTestFlag && this.gLineTestProcessor.bDDJYTestEnabled)
				{
					this.iTestTotalCount++;
				}
				if (this.bCurrJYTestFlag && this.gLineTestProcessor.bJYTestEnabled && this.iJYTestRelaCount >= 2)
				{
					this.iTestTotalCount++;
				}
				if (this.bCurrNYTestFlag && this.gLineTestProcessor.bNYTestEnabled && this.iJYTestRelaCount >= 2)
				{
					this.iTestTotalCount++;
				}
			}
			catch (System.Exception arg_32C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_32C_0.StackTrace);
			}
		}
		private void btnYJCS_Click(object sender, System.EventArgs e)
		{
			try
			{
				if ("一键测试" == this.btnYJCS.Text)
				{
					if (this.GeneralTestConditionJudgmentFunc(100))
					{
						if (!this.GetPlugArrayInfoFunc())
						{
							MessageBox.Show("获取接口接点信息失败!", "提示", MessageBoxButtons.OK);
						}
						else
						{
							this.gLineTestProcessor.SendQueryDeviceErrorCmd();
							this.otsShowInfoStr = "正在进行导通测试..";
							System.Drawing.Color sender2 = System.Drawing.Color.SteelBlue;
							this.otsShowInfoColor = sender2;
							this.RefreshOTSDisposeFunc();
							this.gLineTestProcessor.SendStopCmd();
							System.Threading.Thread.Sleep(ctFormMain.SEND_STOP_CMD_NUM);
							this.btnClearData_Click(null, null);
							this.TestBeforeInitFaultInfoFunc();
							this.iHintDTExcNum = 0;
							this.iHintDLExcNum = 0;
							this.iHintJYExcNum = 0;
							this.iHintDDJYExcNum = 0;
							this.iHintNYExcNum = 0;
							this.RefreshHintLableFunc();
							this.btnCreateReport.Visible = false;
							this.btnPrintReport.Visible = false;
							this.btnSaveTestData.Visible = false;
							this.btnCloseProject.Visible = false;
							this.btnStartDTTest.Visible = false;
							this.btnStartDLTest.Visible = false;
							this.btnStartJYTest.Visible = false;
							this.btnStartDDJYTest.Visible = false;
							this.btnStartNYTest.Visible = false;
							this.btnYJCS.Visible = true;
							this.treeView_projectInfo.Enabled = false;
							this.label_TVYCXSSet.Visible = false;
							this.timer_YJCS.Enabled = false;
							this.menuStrip1.Enabled = false;
							this.toolStrip1.Enabled = false;
							this.bIsTestStatus = true;
							this.bIsSaveDataFlag = false;
							this.bChoiceTestFlag = false;
							this.bExistDLFlag = false;
							this.bIsYJCSFlag = true;
							this.btestDelayFlag = true;
							this.progressBar_test.Value = 0;
							this.label_progress.Text = "0%";
							this.btnYJCS.Text = "停止测试";
							this.iDTTFFlag = 1;
							this.iCurrTestIndex = 0;
							this.gLineTestProcessor.Par = new ParStruct(this.testProjectNameStr, this.bcCableStr, 10.0, 25, this.iDTTestModel, this.iJYTestModel, this.iNYTestModel, this.dDT_Threshold, this.dDT_DTVoltage, this.dDT_DTCurrent, this.dJY_Threshold, this.dJY_JYHoldTime, this.dJY_DCHighVolt, this.dJY_DCRiseTime, this.dNY_Threshold, this.dNY_NYHoldTime, this.dNY_ACHighVolt);
							this.gLineTestProcessor.gCurTestModal = 3;
							this.RunTestDealwithFunc();
						}
					}
				}
				else
				{
					this.TestFinishedDisposeFunc();
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		public void RefreshHintLableFunc()
		{
			try
			{
				string showTempStr = " 统计: 连接关系总数: " + System.Convert.ToString(this.iHintRecordNum) + " 条;";
				if (this.gLineTestProcessor.bDTTestEnabled)
				{
					showTempStr += "导通异常: " + System.Convert.ToString(this.iHintDTExcNum) + " 条;";
				}
				if (this.gLineTestProcessor.bDLTestEnabled)
				{
					showTempStr += "短路异常: " + System.Convert.ToString(this.iHintDLExcNum) + " 条;";
				}
				if (this.gLineTestProcessor.bJYTestEnabled)
				{
					showTempStr += "绝缘异常: " + System.Convert.ToString(this.iHintJYExcNum) + " 条;";
				}
				if (this.gLineTestProcessor.bDDJYTestEnabled)
				{
					showTempStr += "对地绝缘异常: " + System.Convert.ToString(this.iHintDDJYExcNum) + " 条;";
				}
				if (this.gLineTestProcessor.bNYTestEnabled)
				{
					showTempStr += "耐压异常: " + System.Convert.ToString(this.iHintNYExcNum) + " 条;";
				}
				this.label_ExceptionHint.Text = showTempStr;
			}
			catch (System.Exception arg_12D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_12D_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool YJTestExceptionJudgeProcFunc()
		{
			bool bReturnFlag = false;
			try
			{
				this.TestResultQureyFunc();
				if (this.iCurrTestIndex < this.iTestTotalCount && this.testResultStr != ctFormMain.TEST_QUAL_STR && DialogResult.OK == MessageBox.Show("存在不合格项，您确定要继续测试吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
				{
					return true;
				}
				this.TestFinishedDisposeFunc();
				this.gLineTestProcessor.SendStopCmd();
				if (!this.gLineTestProcessor.bIsTimeOut)
				{
					this.otsShowInfoStr = "测试完成";
				}
				else
				{
					this.otsShowInfoStr = "测试终止";
				}
				System.Drawing.Color steelBlue = System.Drawing.Color.SteelBlue;
				this.otsShowInfoColor = steelBlue;
				this.RefreshOTSDisposeFunc();
				if (this.testResultStr != ctFormMain.TEST_QUAL_STR)
				{
					MessageBox.Show("测试结束，存在不合格项!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("测试结束，全部合格!", "提示", MessageBoxButtons.OK);
				}
				if (this.bExistDLFlag)
				{
					ctFormDLTestResultView ctFormDLTestResultView = new ctFormDLTestResultView(this.gLineTestProcessor, false, 0);
					this.DLTestResultViewForm = ctFormDLTestResultView;
					ctFormDLTestResultView.Activate();
					this.DLTestResultViewForm.ShowDialog();
				}
				if (this.iDDJYTFFlag == 1)
				{
					ctFormDDJYTestResultView this2 = new ctFormDDJYTestResultView(this.gLineTestProcessor, false, 0);
					this.DDjyTestResultViewForm = this2;
					this2.Activate();
					this.DDjyTestResultViewForm.ShowDialog();
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
			return bReturnFlag;
		}
		public void YJTestStopDealwithFunc()
		{
			try
			{
				this.TestFinishedDisposeFunc();
				this.TestResultQureyFunc();
				this.bIsSaveDataFlag = false;
				this.SaveTestDataToDBFunc();
				this.btnCreateReport_Click(null, null);
			}
			catch (System.Exception arg_24_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_24_0.StackTrace);
			}
		}
		public void RunTestDealwithFunc()
		{
			try
			{
				KLineTestProcessor this2 = this.gLineTestProcessor;
				int gCurTestModal = this2.gCurTestModal;
				if (gCurTestModal == 3 && this2.bDTTestEnabled)
				{
					this2.mSendTestType = 5;
					this.iRefreshDataCount = 0;
					this.timer_YJCS.Enabled = true;
					this.gLineTestProcessor.iTestPreValue = 0;
					if (!this.bSelfStudyPinTestFlag)
					{
						this2 = this.gLineTestProcessor;
						KLineTestProcessor expr_50 = this2;
						expr_50.StartYJBatchTest(expr_50.gDLPinConnectInfoArray);
					}
					else
					{
						this2 = this.gLineTestProcessor;
						KLineTestProcessor expr_69 = this2;
						expr_69.StartYJBatchTest(expr_69.gDLPinConnectInfoSelfArray);
					}
				}
				else if (gCurTestModal == 7 && this2.bDLTestEnabled)
				{
					if (!this.bCurrDLTestFlag)
					{
						this2.iTestPreValue = 100;
					}
					else
					{
						this2.mpDevComm.mParseCmd.selfStudyMainPinCount = 0;
						this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyPinNum = 0;
						this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyProgress = 0;
						this.gLineTestProcessor.mpDevComm.mParseCmd.iSetSelfStudyDataRespCount = 0;
						this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyCount = 800;
						this.gLineTestProcessor.iSelfStudyThreshold = System.Convert.ToInt32(this.gLineTestProcessor.dDLThresholdCoefficient * this.dDT_Threshold);
						int[] array = this.iPlugStartPin;
						if (array != null && this.iPlugStopPin != null)
						{
							int iLen = array.Length;
							this.gLineTestProcessor.iPlugPinStartArray = new int[iLen];
							this.gLineTestProcessor.iPlugPinStopArray = new int[iLen];
							for (int i = 0; i < iLen; i++)
							{
								this.gLineTestProcessor.iPlugPinStartArray[i] = this.iPlugStartPin[i];
								this.gLineTestProcessor.iPlugPinStopArray[i] = this.iPlugStopPin[i];
								int iTemp = System.Math.Abs(this.iPlugStopPin[i] - this.iPlugStartPin[i]) + 1;
								KParseRepCmd mParseCmd = this.gLineTestProcessor.mpDevComm.mParseCmd;
								KParseRepCmd arg_1EA_0 = mParseCmd;
								int expr_1E0 = iTemp;
								arg_1EA_0.selfStudyCount = expr_1E0 * expr_1E0 + mParseCmd.selfStudyCount;
							}
							this.timer_YJCS.Enabled = true;
							this.gLineTestProcessor.iTestPreValue = 0;
							this.gLineTestProcessor.StartSelfStudyPlugModelTest();
							this.iDLTestTime = 0;
						}
						else
						{
							this.gLineTestProcessor.iPlugPinStartArray = null;
							this.gLineTestProcessor.iPlugPinStopArray = null;
							this.gLineTestProcessor.iTestPreValue = 100;
						}
					}
				}
				else if (gCurTestModal == 4 && this2.bJYTestEnabled)
				{
					if (!this.bCurrJYTestFlag)
					{
						this2.iTestPreValue = 100;
					}
					else
					{
						this2.mSendTestType = 7;
						this.gLineTestProcessor.iTestPreValue = 0;
						this.gLineTestProcessor.mpDevComm.iEMSetTestDataIndex = 0;
						this.timer_YJCS.Enabled = true;
						if (!this.bSelfStudyPinTestFlag)
						{
							this2 = this.gLineTestProcessor;
							if (this2.iJYTestMethod == 1)
							{
								KLineTestProcessor expr_2BF = this2;
								expr_2BF.StartJYTestForData(expr_2BF.gDLPinConnectInfoArray);
							}
							else if (this.bCurrFastTestFlag)
							{
								KLineTestProcessor expr_2D9 = this2;
								expr_2D9.StartJYFastTestForData(expr_2D9.gDLPinConnectInfoArray);
							}
							else
							{
								KLineTestProcessor expr_2EB = this2;
								expr_2EB.StartJYTestForData(expr_2EB.gDLPinConnectInfoArray);
							}
						}
						else
						{
							this2 = this.gLineTestProcessor;
							if (this2.iJYTestMethod == 1)
							{
								KLineTestProcessor expr_30D = this2;
								expr_30D.StartJYTestForData(expr_30D.gDLPinConnectInfoSelfArray);
							}
							else if (this.bCurrFastTestFlag)
							{
								KLineTestProcessor expr_327 = this2;
								expr_327.StartJYFastTestForData(expr_327.gDLPinConnectInfoSelfArray);
							}
							else
							{
								KLineTestProcessor expr_339 = this2;
								expr_339.StartJYTestForData(expr_339.gDLPinConnectInfoSelfArray);
							}
						}
					}
				}
				else if (gCurTestModal == 20 && this2.bDDJYTestEnabled)
				{
					if (!this.bCurrDDJYTestFlag)
					{
						this2.iTestPreValue = 100;
					}
					else
					{
						this2.mSendTestType = 7;
						this.gLineTestProcessor.iTestPreValue = 0;
						this.gLineTestProcessor.mpDevComm.iEMSetTestDataIndex = 0;
						this.timer_YJCS.Enabled = true;
						if (!this.bSelfStudyPinTestFlag)
						{
							this2 = this.gLineTestProcessor;
							KLineTestProcessor expr_3B2 = this2;
							expr_3B2.StartDDJYTestForData(expr_3B2.gDLPinConnectInfoArray);
						}
						else
						{
							this2 = this.gLineTestProcessor;
							KLineTestProcessor expr_3CB = this2;
							expr_3CB.StartDDJYTestForData(expr_3CB.gDLPinConnectInfoSelfArray);
						}
					}
				}
				else if (gCurTestModal == 9 && this2.bNYTestEnabled)
				{
					if (!this.bCurrNYTestFlag)
					{
						this2.iTestPreValue = 100;
					}
					else
					{
						this2.mSendTestType = 9;
						this.gLineTestProcessor.iTestPreValue = 0;
						this.gLineTestProcessor.mpDevComm.iEMSetTestDataIndex = 0;
						this.timer_YJCS.Enabled = true;
						if (!this.bSelfStudyPinTestFlag)
						{
							this2 = this.gLineTestProcessor;
							if (this2.iNYTestMethod == 1)
							{
								KLineTestProcessor expr_452 = this2;
								expr_452.StartNYTestForData(expr_452.gDLPinConnectInfoArray, 9);
							}
							else if (this.bCurrFastTestFlag)
							{
								KLineTestProcessor expr_46E = this2;
								expr_46E.StartNYFastTestForData(expr_46E.gDLPinConnectInfoArray, 9);
							}
							else
							{
								KLineTestProcessor expr_47F = this2;
								expr_47F.StartNYTestForData(expr_47F.gDLPinConnectInfoArray, 9);
							}
						}
						else
						{
							this2 = this.gLineTestProcessor;
							if (this2.iNYTestMethod == 1)
							{
								KLineTestProcessor expr_4A0 = this2;
								expr_4A0.StartNYTestForData(expr_4A0.gDLPinConnectInfoSelfArray, 9);
							}
							else if (this.bCurrFastTestFlag)
							{
								KLineTestProcessor expr_4B9 = this2;
								expr_4B9.StartNYFastTestForData(expr_4B9.gDLPinConnectInfoSelfArray, 9);
							}
							else
							{
								KLineTestProcessor expr_4CA = this2;
								expr_4CA.StartNYTestForData(expr_4CA.gDLPinConnectInfoSelfArray, 9);
							}
						}
					}
				}
				else
				{
					this2.iTestPreValue = 100;
				}
			}
			catch (System.Exception arg_4E4_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_4E4_0.StackTrace);
			}
		}
		public void ResetTestProgressValueFunc()
		{
			try
			{
				this.gLineTestProcessor.iTestPreValue = 0;
				this.progressBar_test.Value = 0;
				this.label_progress.Text = System.Convert.ToString(this.gLineTestProcessor.iTestPreValue) + "%";
			}
			catch (System.Exception arg_3F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3F_0.StackTrace);
			}
		}
		private void timer_YJCS_Tick(object sender, System.EventArgs e)
		{
			try
			{
				KLineTestProcessor e2 = this.gLineTestProcessor;
				if (e2.iTestPreValue != 100)
				{
					int gCurTestModal = e2.gCurTestModal;
					if (gCurTestModal == 3)
					{
						this.GetTestPreValueFunc();
					}
					else if (gCurTestModal != 4 && gCurTestModal != 9)
					{
						if (gCurTestModal == 20)
						{
							this.EmulationModeSetTestData_DDJYFunc();
						}
						else if (gCurTestModal == 7)
						{
							this.EmulationModeSetTestData_DLFunc();
							int num = this.iDLTestTime + 1;
							this.iDLTestTime = num;
							e2 = this.gLineTestProcessor;
							KParseRepCmd mParseCmd = e2.mpDevComm.mParseCmd;
							if (mParseCmd.selfStudyProgress != 100)
							{
								int iProc = System.Convert.ToInt32((double)num * 100.0 / ((double)mParseCmd.selfStudyCount / 60.0));
								if (iProc < 99)
								{
									iProc++;
								}
								e2 = this.gLineTestProcessor;
								if (!e2.bEmulationMode && iProc >= 100)
								{
									iProc = 99;
								}
								e2.iTestPreValue = iProc;
							}
							else
							{
								e2.iTestPreValue = 100;
							}
						}
					}
					else
					{
						this.TestDataShowUIFunc();
						this.GetTestPreValueFunc();
					}
					KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
					int iTestPreValue = kLineTestProcessor.iTestPreValue;
					if (iTestPreValue >= 100)
					{
						kLineTestProcessor.iTestPreValue = 100;
					}
					else if (iTestPreValue < 1)
					{
						kLineTestProcessor.iTestPreValue = iTestPreValue + 1;
					}
					this.progressBar_test.Value = this.gLineTestProcessor.iTestPreValue;
					this.label_progress.Text = System.Convert.ToString(this.gLineTestProcessor.iTestPreValue) + "%";
				}
				else
				{
					int gCurTestModal2 = e2.gCurTestModal;
					if (gCurTestModal2 == 4 || gCurTestModal2 == 9)
					{
						this.TestDataShowUIFunc();
					}
					KLineTestProcessor kLineTestProcessor2 = this.gLineTestProcessor;
					if (!kLineTestProcessor2.mbKeepRun)
					{
						this.progressBar_test.Value = kLineTestProcessor2.iTestPreValue;
						this.label_progress.Text = System.Convert.ToString(this.gLineTestProcessor.iTestPreValue) + "%";
						this.timer_YJCS.Enabled = false;
						KLineTestProcessor this2 = this.gLineTestProcessor;
						int gCurTestModal3 = this2.gCurTestModal;
						if (gCurTestModal3 == 3 && this2.bDTTestEnabled)
						{
							if (this.btestDelayFlag)
							{
								this.otsShowInfoStr = "导通测试完成";
								System.Drawing.Color steelBlue = System.Drawing.Color.SteelBlue;
								this.otsShowInfoColor = steelBlue;
								this.RefreshOTSDisposeFunc();
								this.TestDataShowUIFunc();
								this.gLineTestProcessor.SendStopCmd();
								this.btestDelayFlag = false;
								this.timer_YJCS.Interval = 2000;
								this.timer_YJCS.Enabled = true;
								return;
							}
							this.timer_YJCS.Interval = 1000;
							this.btestDelayFlag = true;
							this.iCurrTestIndex++;
							this.CalcFailCountAndRefreshUIFunc();
							if (this.iHintDTExcNum > 0 && !this.YJTestExceptionJudgeProcFunc())
							{
								return;
							}
							if (this.bCurrDLTestFlag)
							{
								this2 = this.gLineTestProcessor;
								if (this2.bDLTestEnabled)
								{
									this2.gCurTestModal = 7;
									this.gLineTestProcessor.bIsTimeOut = false;
									this.timer_YJCS.Enabled = true;
									this.iDLTFFlag = 1;
									this.otsShowInfoStr = "正在进行短路测试..";
									System.Drawing.Color steelBlue2 = System.Drawing.Color.SteelBlue;
									this.otsShowInfoColor = steelBlue2;
									this.RefreshOTSDisposeFunc();
									this.ResetTestProgressValueFunc();
									goto IL_50A;
								}
							}
							this.iDLTFFlag = 0;
							if (this.bCurrJYTestFlag)
							{
								this2 = this.gLineTestProcessor;
								if (this2.bJYTestEnabled && this.iJYTestRelaCount >= 2)
								{
									this2.gCurTestModal = 4;
									this.gLineTestProcessor.bIsTimeOut = false;
									this.timer_YJCS.Enabled = true;
									this.iJYTFFlag = 1;
									int num2 = this.gLineTestProcessor.iJYTestMethod;
									if (num2 == 1)
									{
										this.bCurrFastTestFlag = false;
										this.otsShowInfoStr = "正在进行绝缘详测..（高压危险，请勿触碰）";
									}
									else if (num2 == 2 || num2 == 3)
									{
										this.bCurrFastTestFlag = true;
										this.otsShowInfoStr = "正在进行绝缘快测..（高压危险，请勿触碰）";
									}
									System.Drawing.Color red = System.Drawing.Color.Red;
									this.otsShowInfoColor = red;
									this.RefreshOTSDisposeFunc();
									this.ResetTestProgressValueFunc();
									this.PictureBoxWarningVisibleSetFunc();
									goto IL_50A;
								}
							}
							this.iJYTFFlag = 0;
							if (this.bCurrDDJYTestFlag)
							{
								this2 = this.gLineTestProcessor;
								if (this2.bDDJYTestEnabled)
								{
									this2.gCurTestModal = 20;
									this.gLineTestProcessor.bIsTimeOut = false;
									this.timer_YJCS.Enabled = true;
									this.iDDJYTFFlag = 1;
									this.otsShowInfoStr = "正在进行对地绝缘测试..（高压危险，请勿触碰）";
									System.Drawing.Color red2 = System.Drawing.Color.Red;
									this.otsShowInfoColor = red2;
									this.RefreshOTSDisposeFunc();
									this.ResetTestProgressValueFunc();
									this.PictureBoxWarningVisibleSetFunc();
									goto IL_50A;
								}
							}
							this.iDDJYTFFlag = 0;
							if (this.bCurrNYTestFlag)
							{
								this2 = this.gLineTestProcessor;
								if (this2.bNYTestEnabled && this.iNYTestRelaCount >= 2)
								{
									this2.gCurTestModal = 9;
									this.gLineTestProcessor.bIsTimeOut = false;
									this.timer_YJCS.Enabled = true;
									this.iNYTFFlag = 1;
									int sender2 = this.gLineTestProcessor.iNYTestMethod;
									if (sender2 == 1)
									{
										this.bCurrFastTestFlag = false;
										this.otsShowInfoStr = "正在进行耐压详测..（高压危险，请勿触碰）";
									}
									else if (sender2 == 2 || sender2 == 3)
									{
										this.bCurrFastTestFlag = true;
										this.otsShowInfoStr = "正在进行耐压快测..（高压危险，请勿触碰）";
									}
									System.Drawing.Color red3 = System.Drawing.Color.Red;
									this.otsShowInfoColor = red3;
									this.RefreshOTSDisposeFunc();
									this.ResetTestProgressValueFunc();
									this.PictureBoxWarningVisibleSetFunc();
									goto IL_50A;
								}
							}
							this.iNYTFFlag = 0;
							goto IL_D7F;
							IL_50A:
							this.RunTestDealwithFunc();
							return;
						}
						else if (gCurTestModal3 == 7 && this2.bDLTestEnabled)
						{
							if (this.btestDelayFlag)
							{
								if (this.bCurrDLTestFlag)
								{
									this.otsShowInfoStr = "短路测试完成";
									System.Drawing.Color steelBlue3 = System.Drawing.Color.SteelBlue;
									this.otsShowInfoColor = steelBlue3;
									this.RefreshOTSDisposeFunc();
								}
								this.gLineTestProcessor.ExportSELFTestDL();
								this.SelfStudyLoadCable_DLDealFunc();
								this.QureyDLDealwithFunc();
								this.GetDLTestPinRelationFunc();
								this.gLineTestProcessor.SendStopCmd();
								this.btestDelayFlag = false;
								this.timer_YJCS.Interval = 2000;
								this.timer_YJCS.Enabled = true;
								return;
							}
							this.timer_YJCS.Interval = 1000;
							this.btestDelayFlag = true;
							this.iCurrTestIndex++;
							this.CalcFailCountAndRefreshUIFunc();
							if (this.iHintDLExcNum > 0 && !this.YJTestExceptionJudgeProcFunc())
							{
								return;
							}
							if (this.bCurrJYTestFlag)
							{
								this2 = this.gLineTestProcessor;
								if (this2.bJYTestEnabled && this.iJYTestRelaCount >= 2)
								{
									this2.gCurTestModal = 4;
									this.gLineTestProcessor.bIsTimeOut = false;
									this.timer_YJCS.Enabled = true;
									this.iJYTFFlag = 1;
									int num3 = this.gLineTestProcessor.iJYTestMethod;
									if (num3 == 1)
									{
										this.bCurrFastTestFlag = false;
										this.otsShowInfoStr = "正在进行绝缘详测..（高压危险，请勿触碰）";
									}
									else if (num3 == 2 || num3 == 3)
									{
										this.bCurrFastTestFlag = true;
										this.otsShowInfoStr = "正在进行绝缘快测..（高压危险，请勿触碰）";
									}
									System.Drawing.Color red4 = System.Drawing.Color.Red;
									this.otsShowInfoColor = red4;
									this.RefreshOTSDisposeFunc();
									this.ResetTestProgressValueFunc();
									this.PictureBoxWarningVisibleSetFunc();
									goto IL_7E0;
								}
							}
							this.iJYTFFlag = 0;
							if (this.bCurrDDJYTestFlag)
							{
								this2 = this.gLineTestProcessor;
								if (this2.bDDJYTestEnabled)
								{
									this2.gCurTestModal = 20;
									this.gLineTestProcessor.bIsTimeOut = false;
									this.timer_YJCS.Enabled = true;
									this.iDDJYTFFlag = 1;
									this.otsShowInfoStr = "正在进行对地绝缘测试..（高压危险，请勿触碰）";
									System.Drawing.Color red5 = System.Drawing.Color.Red;
									this.otsShowInfoColor = red5;
									this.RefreshOTSDisposeFunc();
									this.ResetTestProgressValueFunc();
									this.PictureBoxWarningVisibleSetFunc();
									goto IL_7E0;
								}
							}
							this.iDDJYTFFlag = 0;
							if (this.bCurrNYTestFlag)
							{
								this2 = this.gLineTestProcessor;
								if (this2.bNYTestEnabled && this.iNYTestRelaCount >= 2)
								{
									this2.gCurTestModal = 9;
									this.gLineTestProcessor.bIsTimeOut = false;
									this.timer_YJCS.Enabled = true;
									this.iNYTFFlag = 1;
									int sender2 = this.gLineTestProcessor.iNYTestMethod;
									if (sender2 == 1)
									{
										this.bCurrFastTestFlag = false;
										this.otsShowInfoStr = "正在进行耐压详测..（高压危险，请勿触碰）";
									}
									else if (sender2 == 2 || sender2 == 3)
									{
										this.bCurrFastTestFlag = true;
										this.otsShowInfoStr = "正在进行耐压快测..（高压危险，请勿触碰）";
									}
									System.Drawing.Color red6 = System.Drawing.Color.Red;
									this.otsShowInfoColor = red6;
									this.RefreshOTSDisposeFunc();
									this.ResetTestProgressValueFunc();
									this.PictureBoxWarningVisibleSetFunc();
									goto IL_7E0;
								}
							}
							this.iNYTFFlag = 0;
							goto IL_D7F;
							IL_7E0:
							this.RunTestDealwithFunc();
							return;
						}
						else if (gCurTestModal3 == 4 && this2.bJYTestEnabled)
						{
							if (this.btestDelayFlag)
							{
								this.TestDataShowUIFunc();
								this.CalcFailCountAndRefreshUIFunc();
								if (this.bCurrFastTestFlag && this.iHintJYExcNum > 0 && this.gLineTestProcessor.iJYTestMethod == 3)
								{
									this.timer_YJCS.Enabled = false;
									this.ResetHVTWaitingTimeFunc();
									this.bHVTWaitingFlag = true;
									this.gLineTestProcessor.SendStopCmd();
									System.Threading.Thread.Sleep(ctFormMain.SEND_STOP_CMD_NUM);
									if (DialogResult.Yes == MessageBox.Show("绝缘测试存在异常!是否进行详细测试?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
									{
										this.bHVTWaitingFlag = false;
										this.bCurrFastTestFlag = false;
										this.ResetCurrentTestDataFunc(2);
										this.CalcFailCountAndRefreshUIFunc();
										this.gLineTestProcessor.gCurTestModal = 4;
										this.gLineTestProcessor.bIsTimeOut = false;
										this.timer_YJCS.Enabled = true;
										this.iJYTFFlag = 1;
										this.otsShowInfoStr = "正在进行绝缘详测..（高压危险，请勿触碰）";
										System.Drawing.Color red7 = System.Drawing.Color.Red;
										this.otsShowInfoColor = red7;
										this.RefreshOTSDisposeFunc();
										this.ResetTestProgressValueFunc();
										this.PictureBoxWarningVisibleSetFunc();
										this.RunTestDealwithFunc();
										return;
									}
								}
								if (this.bCurrJYTestFlag && this.iJYTestRelaCount >= 2)
								{
									this.otsShowInfoStr = "绝缘测试完成";
									System.Drawing.Color steelBlue4 = System.Drawing.Color.SteelBlue;
									this.otsShowInfoColor = steelBlue4;
									this.RefreshOTSDisposeFunc();
								}
								this.gLineTestProcessor.SendStopCmd();
								this.btestDelayFlag = false;
								this.timer_YJCS.Interval = 2000;
								this.timer_YJCS.Enabled = true;
								return;
							}
							this.timer_YJCS.Interval = 1000;
							this.btestDelayFlag = true;
							this.iCurrTestIndex++;
							if (this.iHintJYExcNum > 0 && !this.YJTestExceptionJudgeProcFunc())
							{
								return;
							}
							if (this.bCurrDDJYTestFlag)
							{
								this2 = this.gLineTestProcessor;
								if (this2.bDDJYTestEnabled)
								{
									this2.gCurTestModal = 20;
									this.gLineTestProcessor.bIsTimeOut = false;
									this.timer_YJCS.Enabled = true;
									this.iDDJYTFFlag = 1;
									this.otsShowInfoStr = "正在进行对地绝缘测试..（高压危险，请勿触碰）";
									System.Drawing.Color red8 = System.Drawing.Color.Red;
									this.otsShowInfoColor = red8;
									this.RefreshOTSDisposeFunc();
									this.ResetTestProgressValueFunc();
									this.PictureBoxWarningVisibleSetFunc();
									goto IL_AD5;
								}
							}
							this.iDDJYTFFlag = 0;
							if (this.bCurrNYTestFlag)
							{
								this2 = this.gLineTestProcessor;
								if (this2.bNYTestEnabled && this.iNYTestRelaCount >= 2)
								{
									this2.gCurTestModal = 9;
									this.gLineTestProcessor.bIsTimeOut = false;
									this.timer_YJCS.Enabled = true;
									this.iNYTFFlag = 1;
									int sender2 = this.gLineTestProcessor.iNYTestMethod;
									if (sender2 == 1)
									{
										this.bCurrFastTestFlag = false;
										this.otsShowInfoStr = "正在进行耐压详测..（高压危险，请勿触碰）";
									}
									else if (sender2 == 2 || sender2 == 3)
									{
										this.bCurrFastTestFlag = true;
										this.otsShowInfoStr = "正在进行耐压快测..（高压危险，请勿触碰）";
									}
									System.Drawing.Color red9 = System.Drawing.Color.Red;
									this.otsShowInfoColor = red9;
									this.RefreshOTSDisposeFunc();
									this.ResetTestProgressValueFunc();
									this.PictureBoxWarningVisibleSetFunc();
									goto IL_AD5;
								}
							}
							this.iNYTFFlag = 0;
							goto IL_D7F;
							IL_AD5:
							this.RunTestDealwithFunc();
							return;
						}
						else if (gCurTestModal3 == 20 && this2.bDDJYTestEnabled)
						{
							if (this.btestDelayFlag)
							{
								if (this.bCurrDDJYTestFlag)
								{
									this.otsShowInfoStr = "对地绝缘测试完成";
									System.Drawing.Color steelBlue5 = System.Drawing.Color.SteelBlue;
									this.otsShowInfoColor = steelBlue5;
									this.RefreshOTSDisposeFunc();
								}
								this.GetDDJYTestDataFunc();
								this.ResetHVTWaitingTimeFunc();
								this.bHVTWaitingFlag = true;
								this.gLineTestProcessor.SendStopCmd();
								this.btestDelayFlag = false;
								this.timer_YJCS.Interval = 2000;
								this.timer_YJCS.Enabled = true;
								return;
							}
							this.timer_YJCS.Interval = 1000;
							this.btestDelayFlag = true;
							this.iCurrTestIndex++;
							this.CalcFailCountAndRefreshUIFunc();
							if (this.iHintDDJYExcNum > 0 && !this.YJTestExceptionJudgeProcFunc())
							{
								return;
							}
							if (this.bCurrNYTestFlag)
							{
								this2 = this.gLineTestProcessor;
								if (this2.bNYTestEnabled && this.iNYTestRelaCount >= 2)
								{
									this2.gCurTestModal = 9;
									this.gLineTestProcessor.bIsTimeOut = false;
									this.timer_YJCS.Enabled = true;
									this.iNYTFFlag = 1;
									int sender2 = this.gLineTestProcessor.iNYTestMethod;
									if (sender2 == 1)
									{
										this.bCurrFastTestFlag = false;
										this.otsShowInfoStr = "正在进行耐压详测..（高压危险，请勿触碰）";
									}
									else if (sender2 == 2 || sender2 == 3)
									{
										this.bCurrFastTestFlag = true;
										this.otsShowInfoStr = "正在进行耐压快测..（高压危险，请勿触碰）";
									}
									System.Drawing.Color red10 = System.Drawing.Color.Red;
									this.otsShowInfoColor = red10;
									this.RefreshOTSDisposeFunc();
									this.ResetTestProgressValueFunc();
									this.PictureBoxWarningVisibleSetFunc();
									this.RunTestDealwithFunc();
									return;
								}
							}
							this.iNYTFFlag = 0;
						}
						else if (gCurTestModal3 == 9 && this2.bNYTestEnabled)
						{
							this.TestDataShowUIFunc();
							this.CalcFailCountAndRefreshUIFunc();
							if (this.bCurrFastTestFlag && this.iHintNYExcNum > 0 && this.gLineTestProcessor.iNYTestMethod == 3)
							{
								this.timer_YJCS.Enabled = false;
								this.ResetHVTWaitingTimeFunc();
								this.bHVTWaitingFlag = true;
								this.gLineTestProcessor.SendStopCmd();
								System.Threading.Thread.Sleep(ctFormMain.SEND_STOP_CMD_NUM);
								if (DialogResult.Yes == MessageBox.Show("耐压测试存在异常!是否进行详细测试?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
								{
									this.bHVTWaitingFlag = false;
									this.bCurrFastTestFlag = false;
									this.ResetCurrentTestDataFunc(3);
									this.CalcFailCountAndRefreshUIFunc();
									this.gLineTestProcessor.gCurTestModal = 9;
									this.gLineTestProcessor.bIsTimeOut = false;
									this.timer_YJCS.Enabled = true;
									this.iNYTFFlag = 1;
									this.otsShowInfoStr = "正在进行耐压详测..（高压危险，请勿触碰）";
									System.Drawing.Color red11 = System.Drawing.Color.Red;
									this.otsShowInfoColor = red11;
									this.RefreshOTSDisposeFunc();
									this.ResetTestProgressValueFunc();
									this.PictureBoxWarningVisibleSetFunc();
									this.RunTestDealwithFunc();
									return;
								}
							}
						}
						IL_D7F:
						if ((this.iJYTFFlag == 1 || this.iDDJYTFFlag == 1 || this.iNYTFFlag == 1) && !this.bHVTWaitingFlag)
						{
							this.ResetHVTWaitingTimeFunc();
						}
						this.YJTestStopDealwithFunc();
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		public void SetTreeViewSizeFunc()
		{
			try
			{
				if (this.bTreeViewShowFlag)
				{
					this.iTreeViewWidth = this.panel_projectInfo.Width;
					int itdw = this.panel_projectTest.Size.Height - 58;
					System.Drawing.Size this2 = new System.Drawing.Size(this.iTreeViewWidth, itdw);
					this.panel_projectInfo.Size = this2;
					this.panel_projectInfo.Refresh();
				}
			}
			catch (System.Exception arg_57_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_57_0.StackTrace);
			}
		}
		private void ctFormMain_SizeChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView_CommProject.Width - 4;
					if (this.dataGridView_CommProject.Rows.Count > 10)
					{
						iw -= 22;
					}
					this.dataGridView_CommProject.Columns[0].Width = iw;
				}
			}
			catch (System.Exception arg_49_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_49_0.StackTrace);
			}
		}
		private void dataGridView_CommProject_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{
				if (this.dataGridView_CommProject.SelectedRows.Count > 0 && this.dataGridView_CommProject.Rows.Count > 0)
				{
					string pnStr = "";
					if (this.dataGridView_CommProject.SelectedCells[0].Value != null)
					{
						pnStr = this.dataGridView_CommProject.SelectedCells[0].Value.ToString();
					}
					if (!string.IsNullOrEmpty(pnStr))
					{
						if (!this.QureyProjectExistFunc(pnStr))
						{
							MessageBox.Show("访问数据库异常!请联系技术人员进行处理!", "提示", MessageBoxButtons.OK);
						}
						else
						{
							this.testProjectNameStr = pnStr;
							this.OpenProjectDealwithFunc();
						}
					}
				}
			}
			catch (System.Exception arg_9A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_9A_0.StackTrace);
			}
		}
		private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{
				if (e.ColumnIndex != -1 && e.RowIndex != -1)
				{
					if (e.Button == MouseButtons.Right)
					{
						for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
						{
							if (!this.dataGridView1.Rows[e.RowIndex].Selected)
							{
								return;
							}
						}
						this.iJYTestRelaCount = 0;
						this.iNYTestRelaCount = 0;
						bool bJYNYEnabledFlag = true;
						this.gLineTestProcessor.gDLPinConnectInfoChoiceArray = new System.Collections.Generic.List<SDLPinConnectInfo>();
						this.gLineTestProcessor.gDLPinConnectInfoChoiceIndexList = new System.Collections.Generic.List<int>();
						for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
						{
							if (this.dataGridView1.Rows[j].Selected)
							{
								string temp1Str = this.dataGridView1.Rows[j].Cells[1].Value.ToString();
								string temp2Str = this.dataGridView1.Rows[j].Cells[2].Value.ToString();
								string temp3Str = this.dataGridView1.Rows[j].Cells[3].Value.ToString();
								string temp4Str = this.dataGridView1.Rows[j].Cells[4].Value.ToString();
								if (!this.bSelfStudyPinTestFlag)
								{
									for (int k = 0; k < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; k++)
									{
										string temp5Str = this.gLineTestProcessor.gDLPinConnectInfoArray[k].mALJQName;
										string temp6Str = this.gLineTestProcessor.gDLPinConnectInfoArray[k].mnALJQPinNum;
										string temp7Str = this.gLineTestProcessor.gDLPinConnectInfoArray[k].mBLJQName;
										string temp8Str = this.gLineTestProcessor.gDLPinConnectInfoArray[k].mnBLJQPinNum;
										if (temp1Str == temp5Str && temp2Str == temp6Str && temp3Str == temp7Str && temp4Str == temp8Str)
										{
											this.gLineTestProcessor.gDLPinConnectInfoChoiceIndexList.Add(k);
											this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Add(this.gLineTestProcessor.gDLPinConnectInfoArray[k]);
											break;
										}
									}
								}
								else
								{
									for (int l = 0; l < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; l++)
									{
										string temp5Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[l].mALJQName;
										string temp6Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[l].mnALJQPinNum;
										string temp7Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[l].mBLJQName;
										string temp8Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[l].mnBLJQPinNum;
										if (temp1Str == temp5Str && temp2Str == temp6Str && temp3Str == temp7Str && temp4Str == temp8Str)
										{
											this.gLineTestProcessor.gDLPinConnectInfoChoiceIndexList.Add(l);
											this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Add(this.gLineTestProcessor.gDLPinConnectInfoSelfArray[l]);
											break;
										}
									}
								}
							}
						}
						if (this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count > 1)
						{
							this.GetJYNYValidRelaCountFunc(this.gLineTestProcessor.gDLPinConnectInfoChoiceArray);
							if (bJYNYEnabledFlag)
							{
								if (this.gLineTestProcessor.bJYTestEnabled && this.iJYTestRelaCount > 1)
								{
									this.toolStripSeparator_JY.Visible = true;
									this.toolStripMenuItem_JY.Visible = true;
								}
								else
								{
									this.toolStripSeparator_JY.Visible = false;
									this.toolStripMenuItem_JY.Visible = false;
								}
								if (this.gLineTestProcessor.bNYTestEnabled && this.iNYTestRelaCount > 1)
								{
									this.toolStripSeparator_NY.Visible = true;
									this.toolStripMenuItem_NY.Visible = true;
									goto IL_45B;
								}
								this.toolStripSeparator_NY.Visible = false;
								this.toolStripMenuItem_NY.Visible = false;
								goto IL_45B;
							}
						}
						this.toolStripSeparator_JY.Visible = false;
						this.toolStripMenuItem_JY.Visible = false;
						this.toolStripSeparator_NY.Visible = false;
						this.toolStripMenuItem_NY.Visible = false;
						IL_45B:
						System.Drawing.Point mousePosition = Control.MousePosition;
						System.Drawing.Point mousePosition2 = Control.MousePosition;
						this.contextMenuStrip_DTJYNY.Show(mousePosition2.X, mousePosition.Y);
					}
				}
				else if (e.RowIndex == -1)
				{
					this.timer_RefreshIndex.Enabled = true;
				}
			}
			catch (System.Exception arg_49B_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_49B_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool XCConditionQueryFunc(int iXCTypeIndex)
		{
			try
			{
				if (string.IsNullOrEmpty(this.ct_TestCSYTypeStr) || string.IsNullOrEmpty(this.ct_TestCSYMeasureNoStr))
				{
					MessageBox.Show("试验设备信息不完整，请联系管理员进行设置!", "提示", MessageBoxButtons.OK);
					byte iXCTypeIndex2 = 0;
					return iXCTypeIndex2 != 0;
				}
				if (string.IsNullOrEmpty(this.ct_TestEnvironmentTempStr) || string.IsNullOrEmpty(this.ct_TestAmbientHumidityStr))
				{
					MessageBox.Show("当前没有设置试验环境参数，必须马上设置!", "提示", MessageBoxButtons.OK);
					this.MenuItem_TestEnvironmentParameter_Click(null, null);
				}
				if (!this.bEnvironmentParaSetFlag)
				{
					if (DialogResult.Yes == MessageBox.Show("没有设置试验环境参数，是否马上进行设置?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
					{
						this.MenuItem_TestEnvironmentParameter_Click(null, null);
					}
					if (!this.bEnvironmentParaSetFlag)
					{
						byte iXCTypeIndex2 = 0;
						return iXCTypeIndex2 != 0;
					}
				}
				if (this.bIsTestStatus)
				{
					MessageBox.Show("测试中，请稍等!", "提示", MessageBoxButtons.OK);
					byte iXCTypeIndex2 = 0;
					return iXCTypeIndex2 != 0;
				}
				if (!this.bIsExistMapFlag)
				{
					MessageBox.Show(this.noMapZJTpinHintStr, "提示", MessageBoxButtons.OK);
					byte iXCTypeIndex2 = 0;
					return iXCTypeIndex2 != 0;
				}
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				if (!kLineTestProcessor.bEmulationMode && !kLineTestProcessor.bIsConnSuccFlag)
				{
					MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
					byte iXCTypeIndex2 = 0;
					return iXCTypeIndex2 != 0;
				}
				if (!this.TestIntervalDisposeFunc())
				{
					byte iXCTypeIndex2 = 0;
					return iXCTypeIndex2 != 0;
				}
				if (!this.bSelfStudyPinTestFlag && iXCTypeIndex != 1)
				{
					bool bTheSameFlag = true;
					bool bInitFlag = true;
					string text = "";
					string tTimeStr = text;
					string tVoltStr = text;
					if (this.gLineTestProcessor.groupTestParaInfo.bGroupTestFlag)
					{
						for (int i2 = 0; i2 < this.gLineTestProcessor.gDLPinConnectInfoChoiceIndexList.Count; i2++)
						{
							int iTempIndex = this.gLineTestProcessor.gDLPinConnectInfoChoiceIndexList[i2];
							if (this.gLineTestProcessor.gDLPinConnectInfoArray[iTempIndex].iJYTestFlag == 1)
							{
								if (iXCTypeIndex == 2)
								{
									if (bInitFlag)
									{
										bInitFlag = false;
										tTimeStr = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[iTempIndex].JYTestTime;
										tVoltStr = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[iTempIndex].JYVoltage;
										goto IL_2DC;
									}
									string tTime2Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[iTempIndex].JYTestTime;
									string tVolt2Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[iTempIndex].JYVoltage;
									if (!(tTimeStr != tTime2Str) && !(tVoltStr != tVolt2Str))
									{
										goto IL_2DC;
									}
								}
								else
								{
									if (iXCTypeIndex != 3)
									{
										goto IL_2DC;
									}
									if (bInitFlag)
									{
										bInitFlag = false;
										tTimeStr = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[iTempIndex].NYTestTime;
										tVoltStr = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[iTempIndex].NYVoltage;
										goto IL_2DC;
									}
									string tTime2Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[iTempIndex].NYTestTime;
									string tVolt2Str = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[iTempIndex].NYVoltage;
									if (!(tTimeStr != tTime2Str) && !(tVoltStr != tVolt2Str))
									{
										goto IL_2DC;
									}
								}
								IL_2E9:
								MessageBox.Show("试验参数不一致，无法测试!", "提示", MessageBoxButtons.OK);
								byte iXCTypeIndex2 = 0;
								return iXCTypeIndex2 != 0;
							}
							IL_2DC:;
						}
						if (!bTheSameFlag)
						{
							goto IL_2E9;
						}
					}
				}
			}
			catch (System.Exception arg_315_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_315_0.StackTrace);
			}
			return true;
		}
		public void ResetChoiceRowsTestDataFunc(int iType)
		{
			try
			{
				if (iType == 1)
				{
					for (int i = 0; i < this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count; i++)
					{
						string strDTTestValue = "";
						this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[i].strDTTestValue = strDTTestValue;
						string strDTTestResult = "";
						this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[i].strDTTestResult = strDTTestResult;
					}
					for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
					{
						if (this.dataGridView1.Rows[j].Selected)
						{
							this.dataGridView1.Rows[j].Cells[this.iDTTValueColNum].Value = "";
							this.dataGridView1.Rows[j].Cells[this.iDTResultColNum].Value = "";
							if (this.dataGridView1.Rows[j].Cells[this.iJYResultColNum].Value != null)
							{
								string tempStr = this.dataGridView1.Rows[j].Cells[this.iJYResultColNum].Value.ToString();
								if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
								{
									System.Drawing.Color red = System.Drawing.Color.Red;
									this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = red;
								}
								else
								{
									if (this.dataGridView1.Rows[j].Cells[this.iNYResultColNum].Value != null)
									{
										tempStr = this.dataGridView1.Rows[j].Cells[this.iNYResultColNum].Value.ToString();
										if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
										{
											System.Drawing.Color red2 = System.Drawing.Color.Red;
											this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = red2;
											goto IL_2E3;
										}
									}
									System.Drawing.Color white = System.Drawing.Color.White;
									this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = white;
								}
							}
							else
							{
								if (this.dataGridView1.Rows[j].Cells[this.iNYResultColNum].Value != null)
								{
									string tempStr = this.dataGridView1.Rows[j].Cells[this.iNYResultColNum].Value.ToString();
									if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
									{
										System.Drawing.Color red3 = System.Drawing.Color.Red;
										this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = red3;
										goto IL_2E3;
									}
								}
								System.Drawing.Color white2 = System.Drawing.Color.White;
								this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = white2;
							}
						}
						IL_2E3:;
					}
				}
				else if (iType == 2)
				{
					for (int k = 0; k < this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count; k++)
					{
						string strJYTestValue = "";
						this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[k].strJYTestValue = strJYTestValue;
						string strJYTestResult = "";
						this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[k].strJYTestResult = strJYTestResult;
					}
					for (int l = 0; l < this.dataGridView1.Rows.Count; l++)
					{
						if (this.dataGridView1.Rows[l].Selected)
						{
							if (this.dataGridView1.Rows[l].Cells[this.iJYTValueColNum].Value != null)
							{
								string tempStr = this.dataGridView1.Rows[l].Cells[this.iJYTValueColNum].Value.ToString();
								if (tempStr == ctFormMain.UN_TEST_COMM_STR)
								{
									goto IL_62C;
								}
							}
							this.dataGridView1.Rows[l].Cells[this.iJYTValueColNum].Value = "";
							this.dataGridView1.Rows[l].Cells[this.iJYResultColNum].Value = "";
							if (this.dataGridView1.Rows[l].Cells[this.iDTResultColNum].Value != null)
							{
								string tempStr = this.dataGridView1.Rows[l].Cells[this.iDTResultColNum].Value.ToString();
								if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
								{
									System.Drawing.Color red4 = System.Drawing.Color.Red;
									this.dataGridView1.Rows[l].DefaultCellStyle.BackColor = red4;
								}
								else
								{
									if (this.dataGridView1.Rows[l].Cells[this.iNYResultColNum].Value != null)
									{
										tempStr = this.dataGridView1.Rows[l].Cells[this.iNYResultColNum].Value.ToString();
										if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
										{
											System.Drawing.Color red5 = System.Drawing.Color.Red;
											this.dataGridView1.Rows[l].DefaultCellStyle.BackColor = red5;
											goto IL_62C;
										}
									}
									System.Drawing.Color white3 = System.Drawing.Color.White;
									this.dataGridView1.Rows[l].DefaultCellStyle.BackColor = white3;
								}
							}
							else
							{
								if (this.dataGridView1.Rows[l].Cells[this.iNYResultColNum].Value != null)
								{
									string tempStr = this.dataGridView1.Rows[l].Cells[this.iNYResultColNum].Value.ToString();
									if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
									{
										System.Drawing.Color red6 = System.Drawing.Color.Red;
										this.dataGridView1.Rows[l].DefaultCellStyle.BackColor = red6;
										goto IL_62C;
									}
								}
								System.Drawing.Color white4 = System.Drawing.Color.White;
								this.dataGridView1.Rows[l].DefaultCellStyle.BackColor = white4;
							}
						}
						IL_62C:;
					}
				}
				else if (iType == 3)
				{
					for (int m = 0; m < this.gLineTestProcessor.gDLPinConnectInfoChoiceArray.Count; m++)
					{
						string strNYTestValue = "";
						this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[m].strNYTestValue = strNYTestValue;
						string strNYTestResult = "";
						this.gLineTestProcessor.gDLPinConnectInfoChoiceArray[m].strNYTestResult = strNYTestResult;
					}
					for (int n = 0; n < this.dataGridView1.Rows.Count; n++)
					{
						if (this.dataGridView1.Rows[n].Selected)
						{
							if (this.dataGridView1.Rows[n].Cells[this.iNYTValueColNum].Value != null)
							{
								string tempStr = this.dataGridView1.Rows[n].Cells[this.iNYTValueColNum].Value.ToString();
								if (tempStr == ctFormMain.UN_TEST_COMM_STR)
								{
									goto IL_975;
								}
							}
							this.dataGridView1.Rows[n].Cells[this.iNYTValueColNum].Value = "";
							this.dataGridView1.Rows[n].Cells[this.iNYResultColNum].Value = "";
							if (this.dataGridView1.Rows[n].Cells[this.iDTResultColNum].Value != null)
							{
								string tempStr = this.dataGridView1.Rows[n].Cells[this.iDTResultColNum].Value.ToString();
								if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
								{
									System.Drawing.Color red7 = System.Drawing.Color.Red;
									this.dataGridView1.Rows[n].DefaultCellStyle.BackColor = red7;
								}
								else
								{
									if (this.dataGridView1.Rows[n].Cells[this.iJYResultColNum].Value != null)
									{
										tempStr = this.dataGridView1.Rows[n].Cells[this.iJYResultColNum].Value.ToString();
										if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
										{
											System.Drawing.Color red8 = System.Drawing.Color.Red;
											this.dataGridView1.Rows[n].DefaultCellStyle.BackColor = red8;
											goto IL_975;
										}
									}
									System.Drawing.Color white5 = System.Drawing.Color.White;
									this.dataGridView1.Rows[n].DefaultCellStyle.BackColor = white5;
								}
							}
							else
							{
								if (this.dataGridView1.Rows[n].Cells[this.iJYResultColNum].Value != null)
								{
									string tempStr = this.dataGridView1.Rows[n].Cells[this.iJYResultColNum].Value.ToString();
									if (tempStr == ctFormMain.TEST_NOT_QUAL_STR)
									{
										System.Drawing.Color red9 = System.Drawing.Color.Red;
										this.dataGridView1.Rows[n].DefaultCellStyle.BackColor = red9;
										goto IL_975;
									}
								}
								System.Drawing.Color white6 = System.Drawing.Color.White;
								this.dataGridView1.Rows[n].DefaultCellStyle.BackColor = white6;
							}
						}
						IL_975:;
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		private void toolStripMenuItem_DT_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.XCConditionQueryFunc(1))
				{
					this.ResetChoiceRowsTestDataFunc(1);
					this.otsShowInfoStr = "正在进行导通测试..";
					System.Drawing.Color sender2 = System.Drawing.Color.SteelBlue;
					this.otsShowInfoColor = sender2;
					this.RefreshOTSDisposeFunc();
					this.gLineTestProcessor.SendStopCmd();
					System.Threading.Thread.Sleep(ctFormMain.SEND_STOP_CMD_NUM);
					this.TestBeforeInitFaultInfoFunc();
					this.gLineTestProcessor.mpDevComm.ClearTestCmdBuf();
					this.btnCreateReport.Visible = false;
					this.btnPrintReport.Visible = false;
					this.btnCloseProject.Visible = false;
					this.btnStartDTTest.Visible = true;
					this.btnStartDLTest.Visible = false;
					this.btnStartJYTest.Visible = false;
					this.btnStartNYTest.Visible = false;
					this.btnStartDDJYTest.Visible = false;
					this.btnYJCS.Visible = false;
					this.treeView_projectInfo.Enabled = false;
					this.iDTTFFlag = 1;
					this.label_TVYCXSSet.Visible = false;
					this.btnStartDTTest.Text = "停止测试";
					this.bIsTestStatus = true;
					this.bIsSaveDataFlag = false;
					this.bChoiceTestFlag = true;
					this.bIsYJCSFlag = false;
					this.progressBar_test.Value = 0;
					this.label_progress.Text = "0%";
					this.menuStrip1.Enabled = false;
					this.toolStrip1.Enabled = false;
					this.gLineTestProcessor.Par = new ParStruct(this.testProjectNameStr, this.bcCableStr, 10.0, 25, this.iDTTestModel, this.iJYTestModel, this.iNYTestModel, this.dDT_Threshold, this.dDT_DTVoltage, this.dDT_DTCurrent, this.dJY_Threshold, this.dJY_JYHoldTime, this.dJY_DCHighVolt, this.dJY_DCRiseTime, this.dNY_Threshold, this.dNY_NYHoldTime, this.dNY_ACHighVolt);
					this.gLineTestProcessor.mSendTestType = 5;
					this.gLineTestProcessor.gCurTestModal = 3;
					this.iRefreshDataCount = 0;
					this.timer_projectTest.Enabled = true;
					this.gLineTestProcessor.iTestPreValue = 0;
					KLineTestProcessor expr_1FD = this.gLineTestProcessor;
					expr_1FD.StartBatchTest(expr_1FD.gDLPinConnectInfoChoiceArray);
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		private void toolStripMenuItem_JY_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.XCConditionQueryFunc(2))
				{
					this.ResetChoiceRowsTestDataFunc(2);
					this.otsShowInfoStr = "正在进行绝缘测试...（高压危险，请勿触碰）";
					System.Drawing.Color sender2 = System.Drawing.Color.Red;
					this.otsShowInfoColor = sender2;
					this.RefreshOTSDisposeFunc();
					this.gLineTestProcessor.SendStopCmd();
					System.Threading.Thread.Sleep(ctFormMain.SEND_STOP_CMD_NUM);
					this.TestBeforeInitFaultInfoFunc();
					this.gLineTestProcessor.mpDevComm.ClearTestCmdBuf();
					this.btnCreateReport.Visible = false;
					this.btnPrintReport.Visible = false;
					this.btnCloseProject.Visible = false;
					this.btnStartDTTest.Visible = false;
					this.btnStartDLTest.Visible = false;
					this.btnStartJYTest.Visible = true;
					this.btnStartNYTest.Visible = false;
					this.btnStartDDJYTest.Visible = false;
					this.btnYJCS.Visible = false;
					this.treeView_projectInfo.Enabled = false;
					this.iJYTFFlag = 1;
					this.label_TVYCXSSet.Visible = false;
					this.btnStartJYTest.Text = "停止测试";
					this.bIsTestStatus = true;
					this.bIsSaveDataFlag = false;
					this.bChoiceTestFlag = true;
					this.bIsYJCSFlag = false;
					this.progressBar_test.Value = 0;
					this.label_progress.Text = "0%";
					this.menuStrip1.Enabled = false;
					this.toolStrip1.Enabled = false;
					this.PictureBoxWarningVisibleSetFunc();
					this.gLineTestProcessor.Par = new ParStruct(this.testProjectNameStr, this.bcCableStr, 10.0, 25, this.iDTTestModel, this.iJYTestModel, this.iNYTestModel, this.dDT_Threshold, this.dDT_DTVoltage, this.dDT_DTCurrent, this.dJY_Threshold, this.dJY_JYHoldTime, this.dJY_DCHighVolt, this.dJY_DCRiseTime, this.dNY_Threshold, this.dNY_NYHoldTime, this.dNY_ACHighVolt);
					this.gLineTestProcessor.mSendTestType = 7;
					this.gLineTestProcessor.gCurTestModal = 4;
					this.timer_projectTest.Enabled = true;
					this.gLineTestProcessor.iTestPreValue = 0;
					KLineTestProcessor expr_1FC = this.gLineTestProcessor;
					expr_1FC.StartJYChoiceTestForData(expr_1FC.gDLPinConnectInfoChoiceArray);
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		private void toolStripMenuItem_NY_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.XCConditionQueryFunc(3))
				{
					this.ResetChoiceRowsTestDataFunc(3);
					this.otsShowInfoStr = "正在进行耐压测试...（高压危险，请勿触碰）";
					System.Drawing.Color sender2 = System.Drawing.Color.Red;
					this.otsShowInfoColor = sender2;
					this.RefreshOTSDisposeFunc();
					this.gLineTestProcessor.SendStopCmd();
					System.Threading.Thread.Sleep(ctFormMain.SEND_STOP_CMD_NUM);
					this.TestBeforeInitFaultInfoFunc();
					this.gLineTestProcessor.mpDevComm.ClearTestCmdBuf();
					this.iHintNYExcNum = 0;
					this.RefreshHintLableFunc();
					this.btnCreateReport.Visible = false;
					this.btnPrintReport.Visible = false;
					this.btnCloseProject.Visible = false;
					this.btnStartDTTest.Visible = false;
					this.btnStartDLTest.Visible = false;
					this.btnStartJYTest.Visible = false;
					this.btnStartNYTest.Visible = true;
					this.btnStartDDJYTest.Visible = false;
					this.btnYJCS.Visible = false;
					this.treeView_projectInfo.Enabled = false;
					this.iNYTFFlag = 1;
					this.label_TVYCXSSet.Visible = false;
					this.btnStartNYTest.Text = "停止测试";
					this.bIsTestStatus = true;
					this.bIsSaveDataFlag = false;
					this.bChoiceTestFlag = true;
					this.bIsYJCSFlag = false;
					this.progressBar_test.Value = 0;
					this.label_progress.Text = "0%";
					this.menuStrip1.Enabled = false;
					this.toolStrip1.Enabled = false;
					this.PictureBoxWarningVisibleSetFunc();
					this.gLineTestProcessor.Par = new ParStruct(this.testProjectNameStr, this.bcCableStr, 10.0, 25, this.iDTTestModel, this.iJYTestModel, this.iNYTestModel, this.dDT_Threshold, this.dDT_DTVoltage, this.dDT_DTCurrent, this.dJY_Threshold, this.dJY_JYHoldTime, this.dJY_DCHighVolt, this.dJY_DCRiseTime, this.dNY_Threshold, this.dNY_NYHoldTime, this.dNY_ACHighVolt);
					this.gLineTestProcessor.mSendTestType = 9;
					this.gLineTestProcessor.gCurTestModal = 9;
					this.timer_projectTest.Enabled = true;
					this.gLineTestProcessor.iTestPreValue = 0;
					KLineTestProcessor expr_20E = this.gLineTestProcessor;
					expr_20E.StartNYChoiceTestForData(expr_20E.gDLPinConnectInfoChoiceArray, 9);
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		private void MenuItem_ConnectorLibManage_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormConnectorLibManage this2 = new ctFormConnectorLibManage(this.gLineTestProcessor);
				this.connctorLibManageForm = this2;
				this2.Activate();
				this.connctorLibManageForm.ShowDialog();
				this.connctorLibManageForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_34_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_34_0.StackTrace);
			}
		}
		private void MenuItem_IAndRT_PinReletion_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormIAndRTPinReletionManage this2 = new ctFormIAndRTPinReletionManage(this.gLineTestProcessor);
				this.iAndRTPinReletionManageForm = this2;
				this2.Activate();
				this.iAndRTPinReletionManageForm.ShowDialog();
				this.iAndRTPinReletionManageForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_34_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_34_0.StackTrace);
			}
		}
		private void MenuItem_AdapterCableLibManage_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormConverterLibManage this2 = new ctFormConverterLibManage(this.gLineTestProcessor);
				this.converterLibManageForm = this2;
				this2.Activate();
				this.converterLibManageForm.ShowDialog();
				this.converterLibManageForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_34_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_34_0.StackTrace);
			}
		}
		private void MenuItem_HelpView_Click(object sender, System.EventArgs e)
		{
			try
			{
				string fn = Application.StartupPath + "\\help.pdf";
				if (!System.IO.File.Exists(fn))
				{
					MessageBox.Show("无帮助文档!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					Process.Start(fn);
				}
			}
			catch (System.Exception arg_34_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_34_0.StackTrace);
			}
		}
		private void MenuItem_CurrentDLTestData_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.iDLTFFlag != 1)
				{
					MessageBox.Show("未测!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					KLineTestProcessor sender2 = this.gLineTestProcessor;
					if (sender2.gDLPinConnectInfoDLTempArray == null)
					{
						MessageBox.Show("无短路!", "提示", MessageBoxButtons.OK);
					}
					else if (sender2.gDLPinConnectInfoDLTempArray.Count > 0 && this.bExistDLFlag)
					{
						ctFormDLTestResultView this2 = new ctFormDLTestResultView(this.gLineTestProcessor, false, 0);
						this.DLTestResultViewForm = this2;
						this2.Activate();
						this.DLTestResultViewForm.TopMost = true;
						this.DLTestResultViewForm.ShowDialog();
						this.DLTestResultViewForm = null;
						this.FreeSystemMemoryResourcesFunc();
					}
					else
					{
						MessageBox.Show("无短路!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_AF_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_AF_0.StackTrace);
			}
		}
		private void MenuItem_CurrentDDJYTestData_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.iDDJYTFFlag != 1)
				{
					MessageBox.Show("未测!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					ctFormDDJYTestResultView this2 = new ctFormDDJYTestResultView(this.gLineTestProcessor, false, 0);
					this.DDjyTestResultViewForm = this2;
					this2.Activate();
					this.DDjyTestResultViewForm.TopMost = true;
					this.DDjyTestResultViewForm.ShowDialog();
					this.DDjyTestResultViewForm = null;
					this.FreeSystemMemoryResourcesFunc();
				}
			}
			catch (System.Exception arg_5E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5E_0.StackTrace);
			}
		}
		private void MenuItem_HistoryDataBrowse_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormProjectTestDataView this2 = new ctFormProjectTestDataView(this.gLineTestProcessor);
				this.projectTestDataViewForm = this2;
				this2.Activate();
				this.projectTestDataViewForm.ShowDialog();
				this.projectTestDataViewForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_34_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_34_0.StackTrace);
			}
		}
		private void toolStripButton_HistoryDataView_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.MenuItem_HistoryDataBrowse_Click(null, null);
			}
			catch (System.Exception arg_0A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_0A_0.StackTrace);
			}
		}
		private void MenuItem_UserManage_Click(object sender, System.EventArgs e)
		{
			try
			{
				FormUserManage this2 = new FormUserManage(this.gLineTestProcessor);
				this.userManagementForm = this2;
				this2.Activate();
				this.userManagementForm.ShowDialog();
				this.userManagementForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_34_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_34_0.StackTrace);
			}
		}
		private void MenuItem_SecretManage_Click(object sender, System.EventArgs e)
		{
			try
			{
				FormUpdateSecret sender2 = new FormUpdateSecret(this.gLineTestProcessor);
				this.updateSecretForm = sender2;
				sender2.Activate();
				this.updateSecretForm.ShowDialog();
				FormUpdateSecret this2 = this.updateSecretForm;
				if (this2.updateSuccFlag)
				{
					this.gLineTestProcessor.loginUserPsw = this2.loginSecr;
				}
				this.updateSecretForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_54_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_54_0.StackTrace);
			}
		}
		private void MenuItem_OperRecordManage_Click(object sender, System.EventArgs e)
		{
			try
			{
				FormOperRecordManage this2 = new FormOperRecordManage(this.gLineTestProcessor);
				this.operRecordManageForm = this2;
				this2.Activate();
				this.operRecordManageForm.ShowDialog();
				this.operRecordManageForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_34_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_34_0.StackTrace);
			}
		}
		private void MenuItem_EnvironmentParaSet_Click(object sender, System.EventArgs e)
		{
			try
			{
				KLineTestProcessor expr_06 = this.gLineTestProcessor;
				ctFormEnvironmentParaSet sender2 = new ctFormEnvironmentParaSet(expr_06, expr_06.loginUserID);
				this.environmentParaSetForm = sender2;
				sender2.Activate();
				this.environmentParaSetForm.ShowDialog();
				ctFormEnvironmentParaSet this2 = this.environmentParaSetForm;
				if (this2.bTJFlag)
				{
					this.bEnvironmentParaSetFlag = true;
					this.ct_TestEnvironmentTempStr = this2.hjwdStr;
					this.ct_TestAmbientHumidityStr = this2.hjsdStr;
				}
				this.environmentParaSetForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_68_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_68_0.StackTrace);
			}
		}
		private void MenuItem_ReportSavePathSet_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			try
			{
				ctFormSetDefaultSavePath e2 = new ctFormSetDefaultSavePath(this.reportDefaultSavePathStr);
				this.setDefaultSavePathForm = e2;
				e2.Activate();
				this.setDefaultSavePathForm.ShowDialog();
				ctFormSetDefaultSavePath sender2 = this.setDefaultSavePathForm;
				if (!sender2.bSubmitFlag)
				{
					this.setDefaultSavePathForm = null;
					this.FreeSystemMemoryResourcesFunc();
				}
				else
				{
					this.reportDefaultSavePathStr = sender2.reportDefaultSavePathStr;
					try
					{
						connection = new OleDbConnection();
						connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
						connection.Open();
						new OleDbCommand("update TUserCustomCableTestPara set ReportDefaultSavePath = '" + this.reportDefaultSavePathStr + "' where LoginUser='" + this.gLineTestProcessor.loginUserID + "'", connection).ExecuteNonQuery();
						connection.Close();
						connection = null;
					}
					catch (System.Exception arg_BB_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_BB_0.StackTrace);
						if (connection != null)
						{
							connection.Close();
							connection = null;
						}
					}
					this.setDefaultSavePathForm = null;
					this.FreeSystemMemoryResourcesFunc();
				}
			}
			catch (System.Exception arg_E1_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_E1_0.StackTrace);
			}
		}
		private void MenuItem_DefaultTestParaSet_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormDefaultTestParaSet this2 = new ctFormDefaultTestParaSet(this.gLineTestProcessor);
				this.defaultTestParaSetForm = this2;
				this2.Activate();
				this.defaultTestParaSetForm.ShowDialog();
				this.defaultTestParaSetForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_34_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_34_0.StackTrace);
			}
		}
		private void MenuItem_ReportFormatSet_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				ctFormReportFormatSet e2 = new ctFormReportFormatSet(this.gLineTestProcessor);
				this.reportFormatSetForm = e2;
				e2.Activate();
				this.reportFormatSetForm.ShowDialog();
				try
				{
					try
					{
						connection = new OleDbConnection();
						connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
						connection.Open();
						dataReader = new OleDbCommand("select * from TReportParaSet", connection).ExecuteReader();
						if (dataReader.Read())
						{
							this.gLineTestProcessor.iReportTemplateFormat = System.Convert.ToInt32(dataReader["iReportTemplateFormat"].ToString());
						}
						dataReader.Close();
						dataReader = null;
						connection.Close();
						connection = null;
					}
					catch (System.Exception arg_91_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_91_0.StackTrace);
						if (dataReader != null)
						{
							dataReader.Close();
							dataReader = null;
						}
						if (connection != null)
						{
							connection.Close();
							connection = null;
						}
					}
				}
				catch (System.Exception arg_B5_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_B5_0.StackTrace);
				}
				this.reportFormatSetForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_D0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_D0_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool SaveToExcelFileFunc(string xlsxFile, string csvFile, string cableStr, string bzStr)
		{
			bool bSuccFlag = true;
			try
			{
				if (string.IsNullOrEmpty(xlsxFile) || string.IsNullOrEmpty(csvFile))
				{
					return false;
				}
				Workbook wb = new Workbook();
				Cells cells = wb.Worksheets[0].Cells;
				Aspose.Cells.Style st = wb.Styles[wb.Styles.Add()];
				st.HorizontalAlignment = TextAlignmentType.Center;
				st.VerticalAlignment = TextAlignmentType.Center;
				st.Font.Name = "宋体";
				st.Font.Size = 11;
				int iRow = 0;
				int iCol = 0;
				for (int i = 1; i < 5; i++)
				{
					cells.SetColumnWidth(i, 24.0);
				}
				cells.Merge(0, 2, 1, 6);
				cells.Merge(1, 2, 1, 6);
				int column = iCol + 1;
				this.putValue(cells, "线束代号", iRow, column, st);
				int column2 = iCol + 2;
				this.putValue(cells, cableStr, iRow, column2, st);
				iRow++;
				this.putValue(cells, "备注", iRow, column, st);
				this.putValue(cells, bzStr, iRow, column2, st);
				iRow++;
				this.putValue(cells, "序号", iRow, iCol, st);
				this.putValue(cells, "起点接口", iRow, column, st);
				this.putValue(cells, "起点接点", iRow, column2, st);
				int column3 = iCol + 3;
				this.putValue(cells, "终点接口", iRow, column3, st);
				int column4 = iCol + 4;
				this.putValue(cells, "终点接点", iRow, column4, st);
				int column5 = iCol + 5;
				this.putValue(cells, "导通电阻", iRow, column5, st);
				int column6 = iCol + 6;
				this.putValue(cells, "导通结论", iRow, column6, st);
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				if (kLineTestProcessor.bJYTestEnabled)
				{
					this.putValue(cells, "绝缘电阻", iRow, iCol + 7, st);
					this.putValue(cells, "绝缘结论", iRow, iCol + 8, st);
					if (this.gLineTestProcessor.bNYTestEnabled)
					{
						this.putValue(cells, "耐压电流", iRow, iCol + 9, st);
						this.putValue(cells, "耐压结论", iRow, iCol + 10, st);
					}
				}
				else if (kLineTestProcessor.bNYTestEnabled)
				{
					this.putValue(cells, "耐压电流", iRow, iCol + 7, st);
					this.putValue(cells, "耐压结论", iRow, iCol + 8, st);
				}
				iRow++;
				try
				{
					for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
					{
						string bzStr2 = "";
						string temp0Str = bzStr2;
						string temp1Str = bzStr2;
						string temp2Str = bzStr2;
						string temp3Str = bzStr2;
						string temp4Str = bzStr2;
						string temp5Str = bzStr2;
						string temp6Str = bzStr2;
						string temp7Str = bzStr2;
						string temp8Str = bzStr2;
						string temp9Str = bzStr2;
						string temp10Str = bzStr2;
						if (this.dataGridView1.Rows[j].Cells[0].Value != null)
						{
							temp0Str = this.dataGridView1.Rows[j].Cells[0].Value.ToString();
						}
						if (this.dataGridView1.Rows[j].Cells[1].Value != null)
						{
							temp1Str = this.dataGridView1.Rows[j].Cells[1].Value.ToString();
						}
						if (this.dataGridView1.Rows[j].Cells[2].Value != null)
						{
							temp2Str = this.dataGridView1.Rows[j].Cells[2].Value.ToString();
						}
						if (this.dataGridView1.Rows[j].Cells[3].Value != null)
						{
							temp3Str = this.dataGridView1.Rows[j].Cells[3].Value.ToString();
						}
						if (this.dataGridView1.Rows[j].Cells[4].Value != null)
						{
							temp4Str = this.dataGridView1.Rows[j].Cells[4].Value.ToString();
						}
						if (this.dataGridView1.Rows[j].Cells[5].Value != null)
						{
							temp5Str = this.dataGridView1.Rows[j].Cells[5].Value.ToString();
						}
						if (this.dataGridView1.Rows[j].Cells[6].Value != null)
						{
							temp6Str = this.dataGridView1.Rows[j].Cells[6].Value.ToString();
						}
						if (this.dataGridView1.Rows[j].Cells[7].Value != null)
						{
							temp7Str = this.dataGridView1.Rows[j].Cells[7].Value.ToString();
						}
						if (this.dataGridView1.Rows[j].Cells[8].Value != null)
						{
							temp8Str = this.dataGridView1.Rows[j].Cells[8].Value.ToString();
						}
						if (this.dataGridView1.Rows[j].Cells[9].Value != null)
						{
							temp9Str = this.dataGridView1.Rows[j].Cells[9].Value.ToString();
						}
						if (this.dataGridView1.Rows[j].Cells[10].Value != null)
						{
							temp10Str = this.dataGridView1.Rows[j].Cells[10].Value.ToString();
						}
						this.putValue(cells, temp0Str, iRow, iCol, st);
						this.putValue(cells, temp1Str, iRow, column, st);
						this.putValue(cells, temp2Str, iRow, column2, st);
						this.putValue(cells, temp3Str, iRow, column3, st);
						this.putValue(cells, temp4Str, iRow, column4, st);
						this.putValue(cells, temp5Str, iRow, column5, st);
						this.putValue(cells, temp6Str, iRow, column6, st);
						kLineTestProcessor = this.gLineTestProcessor;
						if (kLineTestProcessor.bJYTestEnabled)
						{
							this.putValue(cells, temp7Str, iRow, iCol + 7, st);
							this.putValue(cells, temp8Str, iRow, iCol + 8, st);
							if (this.gLineTestProcessor.bNYTestEnabled)
							{
								this.putValue(cells, temp9Str, iRow, iCol + 9, st);
								this.putValue(cells, temp10Str, iRow, iCol + 10, st);
							}
						}
						else if (kLineTestProcessor.bNYTestEnabled)
						{
							this.putValue(cells, temp9Str, iRow, iCol + 7, st);
							this.putValue(cells, temp10Str, iRow, iCol + 8, st);
						}
						iRow++;
					}
				}
				catch (System.Exception arg_6CE_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_6CE_0.StackTrace);
				}
				wb.Save(xlsxFile, Aspose.Cells.SaveFormat.Xlsx);
				wb = null;
			}
			catch (System.Exception arg_6ED_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_6ED_0.StackTrace);
				bSuccFlag = false;
			}
			return bSuccFlag;
		}
		public void putValue(Cells cell, object tempValue, int row, int column, Aspose.Cells.Style st)
		{
			try
			{
				cell[row, column].PutValue(tempValue);
				cell[row, column].SetStyle(st);
			}
			catch (System.Exception arg_21_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_21_0.StackTrace);
			}
		}
		private void toolStripMenuItem_ExportData_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dataGridView1.Rows.Count <= 0)
				{
					MessageBox.Show("表格数据为空!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					string orfn = Application.StartupPath;
					FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
					this.folderBrowserDialog1 = folderBrowserDialog;
					folderBrowserDialog.Description = "目录选择";
					if (!string.IsNullOrEmpty(this.exportPathStr))
					{
						this.folderBrowserDialog1.SelectedPath = this.exportPathStr;
					}
					if (DialogResult.OK == this.folderBrowserDialog1.ShowDialog())
					{
						orfn = this.folderBrowserDialog1.SelectedPath;
						this.exportPathStr = this.folderBrowserDialog1.SelectedPath;
						System.ValueType dt = System.DateTime.Now;
						string tt = System.Convert.ToString(((System.DateTime)dt).Year) + System.Convert.ToString(((System.DateTime)dt).Month) + System.Convert.ToString(((System.DateTime)dt).Day);
						string ttms = System.Convert.ToString(((System.DateTime)dt).Hour) + System.Convert.ToString(((System.DateTime)dt).Minute) + System.Convert.ToString(((System.DateTime)dt).Second);
						string str = "_";
						string tempStr = this.bcCableStr + str + tt + str + ttms;
						string xlsxFn = orfn + "\\测试数据_" + tempStr + ".xlsx";
						string csvFn = orfn + "\\测试数据_" + tempStr + ".csv";
						if (this.SaveToExcelFileFunc(xlsxFn, csvFn, this.bcCableStr, ""))
						{
							MessageBox.Show("导出成功!", "提示", MessageBoxButtons.OK);
						}
						else
						{
							MessageBox.Show("导出失败!", "提示", MessageBoxButtons.OK);
						}
					}
				}
			}
			catch (System.Exception arg_1B9_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1B9_0.StackTrace);
			}
		}
		private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			try
			{
				if (e.Button == MouseButtons.Left)
				{
					System.Drawing.Point sender2 = Control.MousePosition;
					System.Drawing.Point this2 = Control.MousePosition;
					this.contextMenuStrip_DataProc.Show(this2.X, sender2.Y);
				}
			}
			catch (System.Exception arg_36_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_36_0.StackTrace);
			}
		}
		private void timer_checkLifeTime_Tick(object sender, System.EventArgs e)
		{
			try
			{
				System.ValueType sender2 = System.DateTime.Now;
				this.netTime = sender2;
				if (((System.DateTime)sender2).CompareTo(this.endTime) > 0)
				{
					this.timer_checkLifeTime.Enabled = false;
					int iNetDay = ((System.DateTime)this.netTime).Day;
					int arg_4D_0 = 1;
					int expr_47 = iNetDay;
					if (arg_4D_0 == expr_47 - expr_47 / 6 * 6)
					{
						ctFormFaultHandling this2 = new ctFormFaultHandling();
						this.faultHandlingForm = this2;
						this2.Activate();
						this.faultHandlingForm.TopMost = true;
						this.faultHandlingForm.ShowDialog();
						this.bInquiryHintFlag = true;
						base.Close();
					}
				}
			}
			catch (System.Exception arg_8B_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_8B_0.StackTrace);
			}
		}
		private void MenuItem_EquipmentInfoManage_Click(object sender, System.EventArgs e)
		{
			try
			{
				FormEquipmentInfoManage this2 = new FormEquipmentInfoManage(this.gLineTestProcessor, true);
				this.equipmentInfoManageForm = this2;
				this2.Activate();
				this.equipmentInfoManageForm.ShowDialog();
				this.equipmentInfoManageForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_35_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_35_0.StackTrace);
			}
		}
		private void MenuItem_EmulationMode_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.MenuItem_EmulationMode.Checked)
				{
					this.MenuItem_EmulationMode.Checked = false;
				}
				else
				{
					this.MenuItem_EmulationMode.Checked = true;
				}
				this.gLineTestProcessor.bEmulationMode = this.MenuItem_EmulationMode.Checked;
				KLineTestProcessor this2 = this.gLineTestProcessor;
				if (this2.bEmulationMode)
				{
					this.Text = ctFormMain.SOFTWARE_NAME_STR + "（模拟运行中）";
					this.toolStripStatusLabel_csyConnStatus.Text = "连接正常";
					this.toolStripSeparator_SBTS.Visible = false;
					this.MenuItem_SBTS.Visible = false;
					this.toolStripSeparator_ComponentMeasure.Visible = false;
					this.MenuItem_ComponentMeasure.Visible = false;
					this.toolStripSeparator_VoltMeasure.Visible = false;
					this.MenuItem_VoltMeasure.Visible = false;
				}
				else
				{
					if (!this2.bIsConnSuccFlag)
					{
						this.toolStripStatusLabel_csyConnStatus.Text = "未连接";
					}
					this.Text = ctFormMain.SOFTWARE_NAME_STR;
					if (this.gLineTestProcessor.iUIDisplayMode != 1)
					{
						this.toolStripSeparator_SBTS.Visible = true;
						this.MenuItem_SBTS.Visible = true;
						this.toolStripSeparator_ComponentMeasure.Visible = true;
						this.MenuItem_ComponentMeasure.Visible = true;
						this.toolStripSeparator_VoltMeasure.Visible = true;
						this.MenuItem_VoltMeasure.Visible = true;
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		public void CheckTableNumberAndRearrangeFunc()
		{
			try
			{
				int num;
				for (int i = 0; i < this.dataGridView1.Rows.Count; i = num)
				{
					num = i + 1;
					this.dataGridView1.Rows[i].Cells[0].Value = System.Convert.ToString(num);
				}
				this.dataGridView1.Refresh();
			}
			catch (System.Exception arg_51_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_51_0.StackTrace);
			}
		}
		private void timer_RefreshIndex_Tick(object sender, System.EventArgs e)
		{
			try
			{
				if (this.timer_RefreshIndex.Enabled)
				{
					this.timer_RefreshIndex.Enabled = false;
					this.CheckTableNumberAndRearrangeFunc();
				}
			}
			catch (System.Exception arg_21_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_21_0.StackTrace);
			}
		}
		private void notifyIcon_ctm_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			try
			{
				if (base.WindowState == FormWindowState.Minimized)
				{
					base.WindowState = FormWindowState.Normal;
					base.Activate();
					base.ShowInTaskbar = true;
					this.notifyIcon_ctm.Visible = true;
				}
			}
			catch (System.Exception arg_2B_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2B_0.StackTrace);
			}
		}
		private void MenuItem_SingleDevice_NYTEST_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormSD_WVTMeasure this2 = new ctFormSD_WVTMeasure(this.gLineTestProcessor, this.bcPlugInfoStr);
				this.SD_WVTMeasureForm = this2;
				this2.Activate();
				this.SD_WVTMeasureForm.ShowDialog();
				this.SD_WVTMeasureForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_3A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3A_0.StackTrace);
			}
		}
		private void MenuItem_SingleDevice_DRTEST_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormSD_LCRMeasure this2 = new ctFormSD_LCRMeasure(this.gLineTestProcessor, this.bcPlugInfoStr);
				this.SD_LCRMeasureForm = this2;
				this2.Activate();
				this.SD_LCRMeasureForm.ShowDialog();
				this.SD_LCRMeasureForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_3A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3A_0.StackTrace);
			}
		}
		private void label_TVYCXSSet_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.bTreeViewShowFlag)
				{
					System.Drawing.Point location = this.panel_tsxx.Location;
					this.pointTSNormal = location;
					System.Drawing.Size size = this.panel_tsxx.Size;
					this.sizeTSNormal = size;
					System.Drawing.Point location2 = this.panel_progress.Location;
					this.pointJDNormal = location2;
					System.Drawing.Size size2 = this.panel_progress.Size;
					this.sizeJDNormal = size2;
					System.Drawing.Size size3 = this.panel_testData.Size;
					this.sizeTVNormal = size3;
					System.Drawing.Point location3 = this.panel_testData.Location;
					this.pointTVNormal = location3;
					this.label_TVYCXSSet.Text = "+";
					this.bTreeViewShowFlag = false;
					if (this.iTreeViewWidth <= 0)
					{
						this.iTreeViewWidth = this.panel_projectInfo.Width;
					}
					System.Drawing.Point location4 = this.panel_testNote.Location;
					System.Drawing.Point location5 = this.panel_projectInfo.Location;
					int num = ((System.Drawing.Size)this.sizeTVNormal).Width - location5.X;
					int iWidth = location4.X + num;
					System.Drawing.Size size4 = new System.Drawing.Size(this.iTreeViewWidth, this.panel_testNote.Height);
					this.panel_projectInfo.Size = size4;
					System.Drawing.Size size5 = new System.Drawing.Size(iWidth, ((System.Drawing.Size)this.sizeTVNormal).Height);
					this.panel_testData.Size = size5;
					System.Drawing.Size size6 = new System.Drawing.Size(iWidth, ((System.Drawing.Size)this.sizeTSNormal).Height);
					this.panel_tsxx.Size = size6;
					System.Drawing.Size size7 = new System.Drawing.Size(iWidth, ((System.Drawing.Size)this.sizeJDNormal).Height);
					this.panel_progress.Size = size7;
					int iUIDisplayMode = this.gLineTestProcessor.iUIDisplayMode;
					if (iUIDisplayMode == 1)
					{
						System.ValueType sizeTemp = this.panel_testNote.Size;
						System.Drawing.Size size8 = new System.Drawing.Size(iWidth, ((System.Drawing.Size)sizeTemp).Height);
						this.panel_testNote.Size = size8;
					}
					else if (iUIDisplayMode == 0)
					{
						this.label_TVYCXSSet.Dock = DockStyle.Fill;
					}
				}
				else
				{
					System.Drawing.Point location6 = this.panel_tsxx.Location;
					this.pointTSMaximum = location6;
					System.Drawing.Size size9 = this.panel_tsxx.Size;
					this.sizeTSMaximum = size9;
					System.Drawing.Point location7 = this.panel_progress.Location;
					this.pointJDMaximum = location7;
					System.Drawing.Size size10 = this.panel_progress.Size;
					this.sizeJDMaximum = size10;
					System.Drawing.Size size11 = this.panel_testData.Size;
					this.sizeTVMaximum = size11;
					System.Drawing.Point location8 = this.panel_testData.Location;
					this.pointTVMaximum = location8;
					this.label_TVYCXSSet.Text = "-";
					this.bTreeViewShowFlag = true;
					System.Drawing.Point location9 = this.panel_progress.Location;
					System.Drawing.Size size12 = this.panel_progress.Size;
					System.Drawing.Point location10 = this.panel_testNote.Location;
					int num2 = location9.Y - location10.Y;
					int itdw = size12.Height + num2;
					int iWidth2 = this.panel_testNote.Size.Width;
					System.Drawing.Size size13 = new System.Drawing.Size(this.iTreeViewWidth, itdw);
					this.panel_projectInfo.Size = size13;
					System.Drawing.Size size14 = new System.Drawing.Size(iWidth2, ((System.Drawing.Size)this.sizeTVMaximum).Height);
					this.panel_testData.Size = size14;
					System.Drawing.Size size15 = new System.Drawing.Size(iWidth2, ((System.Drawing.Size)this.sizeTSMaximum).Height);
					this.panel_tsxx.Size = size15;
					System.Drawing.Size size16 = new System.Drawing.Size(iWidth2, ((System.Drawing.Size)this.sizeJDMaximum).Height);
					this.panel_progress.Size = size16;
				}
				int iLocationSX = this.panel_testNote.Location.X;
				int iLocationX = this.panel_projectInfo.Location.X;
				if (this.bTreeViewShowFlag)
				{
					this.label_TVYCXSSet.Dock = DockStyle.None;
					System.Drawing.Size size17 = new System.Drawing.Size(27, 27);
					this.label_TVYCXSSet.Size = size17;
					System.Drawing.Point location11 = new System.Drawing.Point(this.panel_projectInfo.Size.Width - 28, 1);
					this.label_TVYCXSSet.Location = location11;
					System.Drawing.Point location12 = new System.Drawing.Point(iLocationSX, this.panel_testData.Location.Y);
					this.panel_testData.Location = location12;
					System.Drawing.Point location13 = new System.Drawing.Point(iLocationSX, this.panel_tsxx.Location.Y);
					this.panel_tsxx.Location = location13;
					System.Drawing.Point location14 = new System.Drawing.Point(iLocationSX, this.panel_progress.Location.Y);
					this.panel_progress.Location = location14;
				}
				else
				{
					if (this.gLineTestProcessor.iUIDisplayMode == 1)
					{
						System.Drawing.Point location15 = new System.Drawing.Point(iLocationX, this.panel_testNote.Location.Y);
						this.panel_testNote.Location = location15;
					}
					System.Drawing.Point location16 = new System.Drawing.Point(iLocationX, this.panel_testData.Location.Y);
					this.panel_testData.Location = location16;
					System.Drawing.Point location17 = new System.Drawing.Point(iLocationX, this.panel_tsxx.Location.Y);
					this.panel_tsxx.Location = location17;
					System.Drawing.Point location18 = new System.Drawing.Point(iLocationX, this.panel_progress.Location.Y);
					this.panel_progress.Location = location18;
				}
				this.panel_testNote.Refresh();
				this.panel_testData.Refresh();
				this.panel_tsxx.Refresh();
				this.panel_progress.Refresh();
			}
			catch (System.Exception arg_58D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_58D_0.StackTrace);
			}
		}
		private void MenuItem_ComponentMeasure_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormComponentMeasure this2 = new ctFormComponentMeasure(this.gLineTestProcessor);
				this.componentMeasureForm = this2;
				this2.Activate();
				this.componentMeasureForm.ShowDialog();
				this.componentMeasureForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_34_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_34_0.StackTrace);
			}
		}
		private void MenuItem_SwitchAccount_Click(object sender, System.EventArgs e)
		{
			try
			{
				FormLogin sender2 = new FormLogin(this.gLineTestProcessor);
				this.loginForm = sender2;
				sender2.Activate();
				this.loginForm.TopMost = true;
				this.loginForm.ShowDialog();
				FormLogin this2 = this.loginForm;
				if (this2.bLoginSuccFlag)
				{
					this.gLineTestProcessor.bIsAdminFlag = this2.bIsAdminFlag;
					this.gLineTestProcessor.loginUserID = this.loginForm.loginUser;
					this.gLineTestProcessor.loginUserPsw = this.loginForm.loginSecr;
					this.gLineTestProcessor.loginUserName = this.loginForm.loginName;
					this2 = this.loginForm;
					this.ct_TestUserIDStr = this2.loginUser;
					this.ct_TestUserNameStr = this2.loginName;
					this.UsersRightQureyFunc();
					this.GetUserConfigInfoFunc();
				}
				this.loginForm = null;
			}
			catch (System.Exception arg_CA_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_CA_0.StackTrace);
			}
			this.FreeSystemMemoryResourcesFunc();
		}
		private void MenuItem_SMOpenProject_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormBarcodeScanOpenProj sender2 = new ctFormBarcodeScanOpenProj(this.gLineTestProcessor);
				this.barcodeScanOpenProjForm = sender2;
				sender2.Activate();
				this.barcodeScanOpenProjForm.ShowDialog();
				ctFormBarcodeScanOpenProj this2 = this.barcodeScanOpenProjForm;
				if (!this2.bOpenProjectFlag || string.IsNullOrEmpty(this2.testProjectNameStr))
				{
					this.barcodeScanOpenProjForm = null;
					this.FreeSystemMemoryResourcesFunc();
					return;
				}
				this.testProjectNameStr = this.barcodeScanOpenProjForm.testProjectNameStr;
				this.OpenProjectDealwithFunc();
				this.barcodeScanOpenProjForm = null;
			}
			catch (System.Exception arg_70_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_70_0.StackTrace);
			}
			this.FreeSystemMemoryResourcesFunc();
		}
		private void MenuItem_AuxiliaryPowerSupply_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			try
			{
				if (this.MenuItem_AuxiliaryPowerSupply.Checked)
				{
					this.MenuItem_AuxiliaryPowerSupply.Checked = false;
				}
				else
				{
					this.MenuItem_AuxiliaryPowerSupply.Checked = true;
				}
				this.gLineTestProcessor.bAuxPowerSupplyFlag = this.MenuItem_AuxiliaryPowerSupply.Checked;
				int iAPSFlag = 0;
				KLineTestProcessor e2 = this.gLineTestProcessor;
				bool sender2 = e2.bAuxPowerSupplyFlag;
				if (sender2)
				{
					iAPSFlag = 1;
				}
				e2.SetAuxPowerSupply(sender2);
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					new OleDbCommand("update TUserCustomCableTestPara set IsAuxPowerSupply = " + iAPSFlag + " where LoginUser='" + this.gLineTestProcessor.loginUserID + "'", connection).ExecuteNonQuery();
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_C2_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_C2_0.StackTrace);
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
			}
			catch (System.Exception arg_DB_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_DB_0.StackTrace);
			}
		}
		private void MenuItem_VoltMeasure_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormVoltMeasure this2 = new ctFormVoltMeasure(this.gLineTestProcessor);
				this.voltMeasureForm = this2;
				this2.Activate();
				this.voltMeasureForm.ShowDialog();
				this.voltMeasureForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_34_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_34_0.StackTrace);
			}
		}
		private void timer_Delay_Tick(object sender, System.EventArgs e)
		{
			try
			{
				this.timer_Delay.Enabled = false;
				this.UpdateDVGDataDisposeFunc();
				this.QueryValidJYNYTestNumFunc();
				this.QeuryExistMapFunc();
				this.gLineTestProcessor.LoadAPinBuChangData();
				this.GetGroupTestParaDataFunc();
				this.otsShowInfoStr = "等待测试..";
				System.Drawing.Color this2 = System.Drawing.Color.SteelBlue;
				this.otsShowInfoColor = this2;
				this.RefreshOTSDisposeFunc();
				System.GC.Collect();
				System.GC.WaitForPendingFinalizers();
			}
			catch (System.Exception arg_59_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_59_0.StackTrace);
			}
		}
		private void MenuItem_UnDefinedInterfaceTest_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormUnDefinedInterfaceMeasure this2 = new ctFormUnDefinedInterfaceMeasure(this.gLineTestProcessor);
				this.unDefinedInterfaceMeasureForm = this2;
				this2.Activate();
				this.unDefinedInterfaceMeasureForm.ShowDialog();
				this.unDefinedInterfaceMeasureForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_34_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_34_0.StackTrace);
			}
		}
		private void toolStripButton_ProbeMeasure_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormProbeMeasure this2 = new ctFormProbeMeasure(this.gLineTestProcessor);
				this.probeMeasureForm = this2;
				this2.Activate();
				this.probeMeasureForm.ShowDialog();
				this.probeMeasureForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_34_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_34_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormMain();
					return;
				}
				finally
				{
					base.Dispose(true);
				}
			}
			base.Dispose(false);
		}
	}
}
