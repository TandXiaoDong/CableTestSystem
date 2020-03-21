using Aspose.Cells;
using Aspose.Words;
using Aspose.Words.Tables;
using System;
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
	public class ctFormProjectTestDataDetail : Form
	{
		public ctFormDLTestResultView DLTestResultViewForm;
		public ctFormDDJYTestResultView DDjyTestResultViewForm;
		public ctFormSetDefaultSavePath setDefaultSavePathForm;
		public ctFormReportFileTypeChoice reportFileTypeChoiceForm;
		public ctFormWait waitFinishedForm;
		public string dbpath;
		public string mddbpath;
		public string loginUser;
		public int iHistoryDataInfoID;
		public string projectReportPathStr;
		public string exportPathStr;
		public bool bReportSuccFlag;
		public bool bExistDLFlag;
		public bool bReportPrintSuccFlag;
		public int iHintRecordNum;
		public int iHintDTExcNum;
		public int iHintDLExcNum;
		public int iHintJYExcNum;
		public int iHintDDJYExcNum;
		public int iHintNYExcNum;
		public static string UN_TEST_COMM_STR = "--";
		public static string TEST_QUAL_STR = "合格";
		public static string TEST_NOT_QUAL_STR = "不合格";
		public string ctTestNumberStr;
		public string ct_TestDateStr;
		public string ct_TestUserIDStr;
		public string ct_TestUserNameStr;
		public string ct_TestEnvironmentTempStr;
		public string ct_TestAmbientHumidityStr;
		public string ct_TestCSYTypeStr;
		public string ct_TestCSYMeasureNoStr;
		public string strTestResult;
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
		public string ct_iDTTFFlagStr;
		public string ct_iDLTFFlagStr;
		public string ct_iJYTFFlagStr;
		public string ct_iDDJYTFFlagStr;
		public string ct_iNYTFFlagStr;
		public string reportDefaultSavePathStr;
		public string reportBackPathStr;
		public string reportBackFNStr;
		public KLineTestProcessor gLineTestProcessor;
		public int iFileType;
		private Label label_TestPCHStr;
		private Label label2;
		private GroupBox groupBox3;
		private Label label4;
		private Label label_JYRiseTime;
		private Label label_DTV;
		private Label label_DTVoltage;
		private Label label_DTC;
		private Label label_DTCurrent;
		private ContextMenuStrip contextMenuStrip_DataProc;
		private ToolStripMenuItem toolStripMenuItem_ExportData;
		private Button btnDDJYTestView;
		private Button btnDLTestView;
		private FolderBrowserDialog folderBrowserDialog1;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
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
		private Label label_bcCableName;
		private Label label3;
		private Label label_TestResult;
		private Label label1;
		private Label label_DTRange;
		private Label label_DTR;
		private Label label_JYTime;
		private Label label_JYRange;
		private Label label_JYT;
		private Label label_JYVolt;
		private Label label_JYR;
		private Label label_JYV;
		private Button btnCreateReport;
		private Button btnQuit;
		private Button btnPrintReport;
		private Label label_NYTime;
		private Label label_NYRange;
		private Label label_NYT;
		private Label label_NYVolt;
		private Label label_NYR;
		private Label label_NYV;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private PrintDialog printDialog1;
		private PrintPreviewDialog printPreviewDialog1;
		private Label label_testDate;
		private Label label14;
		private Label label_TestNumber;
		private Label label17;
		private Label label_OperatorName;
		private Label label18;
		private Label label_CSYType;
		private Label label_CSYMeasuringNumber;
		private Label label20;
		private Label label19;
		private Label label_EnvironmentTemperature;
		private Label label_AmbientHumidity;
		private Label label22;
		private Label label21;
		private IContainer components;
		public ctFormProjectTestDataDetail(string lUser, KLineTestProcessor gltProcessor, int iPid)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.mddbpath = Application.StartupPath + "\\ctsmddb.mdb";
					this.exportPathStr = "";
					this.loginUser = lUser;
					this.iHistoryDataInfoID = iPid;
					this.gLineTestProcessor = gltProcessor;
					this.ctTestNumberStr = "1";
					this.ct_TestDateStr = "";
					this.ct_TestUserIDStr = "";
					this.ct_TestUserNameStr = "";
					this.ct_TestEnvironmentTempStr = "";
					this.ct_TestAmbientHumidityStr = "";
					this.ct_TestCSYTypeStr = "";
					this.ct_TestCSYMeasureNoStr = "";
					this.ct_TestBCXSStr = "";
					this.strTestResult = "合格";
					this.ct_iDTTFFlagStr = "0";
					this.ct_iDLTFFlagStr = "0";
					this.ct_iJYTFFlagStr = "0";
					this.ct_iDDJYTFFlagStr = "0";
					this.ct_iNYTFFlagStr = "0";
					this.iHintDTExcNum = 0;
					this.iHintDLExcNum = 0;
					this.iHintJYExcNum = 0;
					this.iHintDDJYExcNum = 0;
					this.iHintNYExcNum = 0;
					this.iFileType = 1;
				}
				catch (System.Exception ex_127)
				{
				}
				this.InitSysControlsFunc();
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormProjectTestDataDetail()
		{
			IContainer this2 = this.components;
			if (this2 != null)
			{
				this2.Dispose();
			}
		}
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormProjectTestDataDetail));
			this.groupBox1 = new GroupBox();
			this.label_EnvironmentTemperature = new Label();
			this.label_CSYType = new Label();
			this.label_OperatorName = new Label();
			this.label_AmbientHumidity = new Label();
			this.label_CSYMeasuringNumber = new Label();
			this.label_TestPCHStr = new Label();
			this.label_TestNumber = new Label();
			this.label_testDate = new Label();
			this.label2 = new Label();
			this.label_bcCableName = new Label();
			this.label17 = new Label();
			this.label22 = new Label();
			this.label20 = new Label();
			this.label18 = new Label();
			this.label21 = new Label();
			this.label19 = new Label();
			this.label14 = new Label();
			this.label3 = new Label();
			this.label_TestResult = new Label();
			this.label1 = new Label();
			this.label_NYTime = new Label();
			this.label_JYTime = new Label();
			this.label_NYRange = new Label();
			this.label_JYRange = new Label();
			this.label_NYT = new Label();
			this.label_JYT = new Label();
			this.label_NYVolt = new Label();
			this.label_NYR = new Label();
			this.label_JYVolt = new Label();
			this.label_NYV = new Label();
			this.label_JYR = new Label();
			this.label_JYV = new Label();
			this.label_DTRange = new Label();
			this.label_DTR = new Label();
			this.groupBox2 = new GroupBox();
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
			this.btnCreateReport = new Button();
			this.btnQuit = new Button();
			this.btnPrintReport = new Button();
			this.folderBrowserDialog1 = new FolderBrowserDialog();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.printDialog1 = new PrintDialog();
			this.printPreviewDialog1 = new PrintPreviewDialog();
			this.btnDLTestView = new Button();
			this.btnDDJYTestView = new Button();
			this.contextMenuStrip_DataProc = new ContextMenuStrip(this.components);
			this.toolStripMenuItem_ExportData = new ToolStripMenuItem();
			this.groupBox3 = new GroupBox();
			this.label4 = new Label();
			this.label_DTV = new Label();
			this.label_JYRiseTime = new Label();
			this.label_DTVoltage = new Label();
			this.label_DTC = new Label();
			this.label_DTCurrent = new Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			this.contextMenuStrip_DataProc.SuspendLayout();
			this.groupBox3.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.label_EnvironmentTemperature);
			this.groupBox1.Controls.Add(this.label_CSYType);
			this.groupBox1.Controls.Add(this.label_OperatorName);
			this.groupBox1.Controls.Add(this.label_AmbientHumidity);
			this.groupBox1.Controls.Add(this.label_CSYMeasuringNumber);
			this.groupBox1.Controls.Add(this.label_TestPCHStr);
			this.groupBox1.Controls.Add(this.label_TestNumber);
			this.groupBox1.Controls.Add(this.label_testDate);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label_bcCableName);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.label22);
			this.groupBox1.Controls.Add(this.label20);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.label21);
			this.groupBox1.Controls.Add(this.label19);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label_TestResult);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(11, 10);
			this.groupBox1.Location = location;
			Padding margin = new Padding(2, 2, 2, 2);
			this.groupBox1.Margin = margin;
			this.groupBox1.Name = "groupBox1";
			Padding padding = new Padding(2, 2, 2, 2);
			this.groupBox1.Padding = padding;
			System.Drawing.Size size = new System.Drawing.Size(765, 112);
			this.groupBox1.Size = size;
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "测试结果";
			this.label_EnvironmentTemperature.AutoSize = true;
			System.Drawing.Point location2 = new System.Drawing.Point(674, 56);
			this.label_EnvironmentTemperature.Location = location2;
			Padding margin2 = new Padding(2, 0, 2, 0);
			this.label_EnvironmentTemperature.Margin = margin2;
			this.label_EnvironmentTemperature.Name = "label_EnvironmentTemperature";
			System.Drawing.Size size2 = new System.Drawing.Size(23, 15);
			this.label_EnvironmentTemperature.Size = size2;
			this.label_EnvironmentTemperature.TabIndex = 2;
			this.label_EnvironmentTemperature.Text = "18";
			this.label_CSYType.AutoSize = true;
			System.Drawing.Point location3 = new System.Drawing.Point(485, 56);
			this.label_CSYType.Location = location3;
			Padding margin3 = new Padding(2, 0, 2, 0);
			this.label_CSYType.Margin = margin3;
			this.label_CSYType.Name = "label_CSYType";
			System.Drawing.Size size3 = new System.Drawing.Size(47, 15);
			this.label_CSYType.Size = size3;
			this.label_CSYType.TabIndex = 2;
			this.label_CSYType.Text = "10011";
			this.label_OperatorName.AutoSize = true;
			System.Drawing.Point location4 = new System.Drawing.Point(302, 88);
			this.label_OperatorName.Location = location4;
			Padding margin4 = new Padding(2, 0, 2, 0);
			this.label_OperatorName.Margin = margin4;
			this.label_OperatorName.Name = "label_OperatorName";
			System.Drawing.Size size4 = new System.Drawing.Size(52, 15);
			this.label_OperatorName.Size = size4;
			this.label_OperatorName.TabIndex = 2;
			this.label_OperatorName.Text = "试验员";
			this.label_AmbientHumidity.AutoSize = true;
			System.Drawing.Point location5 = new System.Drawing.Point(674, 88);
			this.label_AmbientHumidity.Location = location5;
			Padding margin5 = new Padding(2, 0, 2, 0);
			this.label_AmbientHumidity.Margin = margin5;
			this.label_AmbientHumidity.Name = "label_AmbientHumidity";
			System.Drawing.Size size5 = new System.Drawing.Size(23, 15);
			this.label_AmbientHumidity.Size = size5;
			this.label_AmbientHumidity.TabIndex = 2;
			this.label_AmbientHumidity.Text = "88";
			this.label_CSYMeasuringNumber.AutoSize = true;
			System.Drawing.Point location6 = new System.Drawing.Point(485, 88);
			this.label_CSYMeasuringNumber.Location = location6;
			Padding margin6 = new Padding(2, 0, 2, 0);
			this.label_CSYMeasuringNumber.Margin = margin6;
			this.label_CSYMeasuringNumber.Name = "label_CSYMeasuringNumber";
			System.Drawing.Size size6 = new System.Drawing.Size(39, 15);
			this.label_CSYMeasuringNumber.Size = size6;
			this.label_CSYMeasuringNumber.TabIndex = 2;
			this.label_CSYMeasuringNumber.Text = "1001";
			this.label_TestPCHStr.AutoSize = true;
			System.Drawing.Point location7 = new System.Drawing.Point(111, 88);
			this.label_TestPCHStr.Location = location7;
			Padding margin7 = new Padding(2, 0, 2, 0);
			this.label_TestPCHStr.Margin = margin7;
			this.label_TestPCHStr.Name = "label_TestPCHStr";
			System.Drawing.Size size7 = new System.Drawing.Size(55, 15);
			this.label_TestPCHStr.Size = size7;
			this.label_TestPCHStr.TabIndex = 2;
			this.label_TestPCHStr.Text = "888888";
			this.label_TestNumber.AutoSize = true;
			System.Drawing.Point location8 = new System.Drawing.Point(302, 56);
			this.label_TestNumber.Location = location8;
			Padding margin8 = new Padding(2, 0, 2, 0);
			this.label_TestNumber.Margin = margin8;
			this.label_TestNumber.Name = "label_TestNumber";
			System.Drawing.Size size8 = new System.Drawing.Size(55, 15);
			this.label_TestNumber.Size = size8;
			this.label_TestNumber.TabIndex = 2;
			this.label_TestNumber.Text = "888888";
			this.label_testDate.AutoSize = true;
			System.Drawing.Point location9 = new System.Drawing.Point(302, 24);
			this.label_testDate.Location = location9;
			Padding margin9 = new Padding(2, 0, 2, 0);
			this.label_testDate.Margin = margin9;
			this.label_testDate.Name = "label_testDate";
			System.Drawing.Size size9 = new System.Drawing.Size(71, 15);
			this.label_testDate.Size = size9;
			this.label_testDate.TabIndex = 2;
			this.label_testDate.Text = "2017-1-1";
			this.label2.AutoSize = true;
			System.Drawing.Point location10 = new System.Drawing.Point(28, 88);
			this.label2.Location = location10;
			Padding margin10 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin10;
			this.label2.Name = "label2";
			System.Drawing.Size size10 = new System.Drawing.Size(76, 15);
			this.label2.Size = size10;
			this.label2.TabIndex = 0;
			this.label2.Text = "批 次 号:";
			this.label_bcCableName.AutoSize = true;
			System.Drawing.Point location11 = new System.Drawing.Point(111, 56);
			this.label_bcCableName.Location = location11;
			Padding margin11 = new Padding(2, 0, 2, 0);
			this.label_bcCableName.Margin = margin11;
			this.label_bcCableName.Name = "label_bcCableName";
			System.Drawing.Size size11 = new System.Drawing.Size(39, 15);
			this.label_bcCableName.Size = size11;
			this.label_bcCableName.TabIndex = 2;
			this.label_bcCableName.Text = "L1-1";
			this.label17.AutoSize = true;
			System.Drawing.Point location12 = new System.Drawing.Point(215, 56);
			this.label17.Location = location12;
			Padding margin12 = new Padding(2, 0, 2, 0);
			this.label17.Margin = margin12;
			this.label17.Name = "label17";
			System.Drawing.Size size12 = new System.Drawing.Size(75, 15);
			this.label17.Size = size12;
			this.label17.TabIndex = 0;
			this.label17.Text = "试验编号:";
			this.label22.AutoSize = true;
			System.Drawing.Point location13 = new System.Drawing.Point(590, 56);
			this.label22.Location = location13;
			Padding margin13 = new Padding(2, 0, 2, 0);
			this.label22.Margin = margin13;
			this.label22.Name = "label22";
			System.Drawing.Size size13 = new System.Drawing.Size(75, 15);
			this.label22.Size = size13;
			this.label22.TabIndex = 0;
			this.label22.Text = "环境温度:";
			this.label20.AutoSize = true;
			System.Drawing.Point location14 = new System.Drawing.Point(403, 56);
			this.label20.Location = location14;
			Padding margin14 = new Padding(2, 0, 2, 0);
			this.label20.Margin = margin14;
			this.label20.Name = "label20";
			System.Drawing.Size size14 = new System.Drawing.Size(75, 15);
			this.label20.Size = size14;
			this.label20.TabIndex = 0;
			this.label20.Text = "仪器型号:";
			this.label18.AutoSize = true;
			System.Drawing.Point location15 = new System.Drawing.Point(215, 88);
			this.label18.Location = location15;
			Padding margin15 = new Padding(2, 0, 2, 0);
			this.label18.Margin = margin15;
			this.label18.Name = "label18";
			System.Drawing.Size size15 = new System.Drawing.Size(75, 15);
			this.label18.Size = size15;
			this.label18.TabIndex = 0;
			this.label18.Text = "测试人员:";
			this.label21.AutoSize = true;
			System.Drawing.Point location16 = new System.Drawing.Point(590, 88);
			this.label21.Location = location16;
			Padding margin16 = new Padding(2, 0, 2, 0);
			this.label21.Margin = margin16;
			this.label21.Name = "label21";
			System.Drawing.Size size16 = new System.Drawing.Size(75, 15);
			this.label21.Size = size16;
			this.label21.TabIndex = 0;
			this.label21.Text = "环境湿度:";
			this.label19.AutoSize = true;
			System.Drawing.Point location17 = new System.Drawing.Point(403, 88);
			this.label19.Location = location17;
			Padding margin17 = new Padding(2, 0, 2, 0);
			this.label19.Margin = margin17;
			this.label19.Name = "label19";
			System.Drawing.Size size17 = new System.Drawing.Size(75, 15);
			this.label19.Size = size17;
			this.label19.TabIndex = 0;
			this.label19.Text = "计量编号:";
			this.label14.AutoSize = true;
			System.Drawing.Point location18 = new System.Drawing.Point(215, 24);
			this.label14.Location = location18;
			Padding margin18 = new Padding(2, 0, 2, 0);
			this.label14.Margin = margin18;
			this.label14.Name = "label14";
			System.Drawing.Size size18 = new System.Drawing.Size(75, 15);
			this.label14.Size = size18;
			this.label14.TabIndex = 0;
			this.label14.Text = "试验日期:";
			this.label3.AutoSize = true;
			System.Drawing.Point location19 = new System.Drawing.Point(28, 56);
			this.label3.Location = location19;
			Padding margin19 = new Padding(2, 0, 2, 0);
			this.label3.Margin = margin19;
			this.label3.Name = "label3";
			System.Drawing.Size size19 = new System.Drawing.Size(75, 15);
			this.label3.Size = size19;
			this.label3.TabIndex = 0;
			this.label3.Text = "线束代号:";
			this.label_TestResult.AutoSize = true;
			this.label_TestResult.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location20 = new System.Drawing.Point(111, 24);
			this.label_TestResult.Location = location20;
			Padding margin20 = new Padding(2, 0, 2, 0);
			this.label_TestResult.Margin = margin20;
			this.label_TestResult.Name = "label_TestResult";
			System.Drawing.Size size20 = new System.Drawing.Size(39, 15);
			this.label_TestResult.Size = size20;
			this.label_TestResult.TabIndex = 1;
			this.label_TestResult.Text = "合格";
			this.label1.AutoSize = true;
			System.Drawing.Point location21 = new System.Drawing.Point(28, 24);
			this.label1.Location = location21;
			Padding margin21 = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin21;
			this.label1.Name = "label1";
			System.Drawing.Size size21 = new System.Drawing.Size(75, 15);
			this.label1.Size = size21;
			this.label1.TabIndex = 0;
			this.label1.Text = "测试结果:";
			this.label_NYTime.AutoSize = true;
			System.Drawing.Point location22 = new System.Drawing.Point(302, 90);
			this.label_NYTime.Location = location22;
			Padding margin22 = new Padding(2, 0, 2, 0);
			this.label_NYTime.Margin = margin22;
			this.label_NYTime.Name = "label_NYTime";
			System.Drawing.Size size22 = new System.Drawing.Size(47, 15);
			this.label_NYTime.Size = size22;
			this.label_NYTime.TabIndex = 6;
			this.label_NYTime.Text = "1.0 s";
			this.label_NYTime.Visible = false;
			this.label_JYTime.AutoSize = true;
			System.Drawing.Point location23 = new System.Drawing.Point(302, 60);
			this.label_JYTime.Location = location23;
			Padding margin23 = new Padding(2, 0, 2, 0);
			this.label_JYTime.Margin = margin23;
			this.label_JYTime.Name = "label_JYTime";
			System.Drawing.Size size23 = new System.Drawing.Size(47, 15);
			this.label_JYTime.Size = size23;
			this.label_JYTime.TabIndex = 6;
			this.label_JYTime.Text = "1.0 s";
			this.label_NYRange.AutoSize = true;
			System.Drawing.Point location24 = new System.Drawing.Point(111, 90);
			this.label_NYRange.Location = location24;
			Padding margin24 = new Padding(2, 0, 2, 0);
			this.label_NYRange.Margin = margin24;
			this.label_NYRange.Name = "label_NYRange";
			System.Drawing.Size size24 = new System.Drawing.Size(55, 15);
			this.label_NYRange.Size = size24;
			this.label_NYRange.TabIndex = 5;
			this.label_NYRange.Text = "1.5 mA";
			this.label_NYRange.Visible = false;
			this.label_JYRange.AutoSize = true;
			System.Drawing.Point location25 = new System.Drawing.Point(111, 60);
			this.label_JYRange.Location = location25;
			Padding margin25 = new Padding(2, 0, 2, 0);
			this.label_JYRange.Margin = margin25;
			this.label_JYRange.Name = "label_JYRange";
			System.Drawing.Size size25 = new System.Drawing.Size(78, 15);
			this.label_JYRange.Size = size25;
			this.label_JYRange.TabIndex = 5;
			this.label_JYRange.Text = "200.0 MΩ";
			this.label_NYT.AutoSize = true;
			System.Drawing.Point location26 = new System.Drawing.Point(215, 90);
			this.label_NYT.Location = location26;
			Padding margin26 = new Padding(2, 0, 2, 0);
			this.label_NYT.Margin = margin26;
			this.label_NYT.Name = "label_NYT";
			System.Drawing.Size size26 = new System.Drawing.Size(75, 15);
			this.label_NYT.Size = size26;
			this.label_NYT.TabIndex = 0;
			this.label_NYT.Text = "耐压时间:";
			this.label_NYT.Visible = false;
			this.label_JYT.AutoSize = true;
			System.Drawing.Point location27 = new System.Drawing.Point(215, 60);
			this.label_JYT.Location = location27;
			Padding margin27 = new Padding(2, 0, 2, 0);
			this.label_JYT.Margin = margin27;
			this.label_JYT.Name = "label_JYT";
			System.Drawing.Size size27 = new System.Drawing.Size(75, 15);
			this.label_JYT.Size = size27;
			this.label_JYT.TabIndex = 0;
			this.label_JYT.Text = "绝缘时间:";
			this.label_NYVolt.AutoSize = true;
			System.Drawing.Point location28 = new System.Drawing.Point(485, 90);
			this.label_NYVolt.Location = location28;
			Padding margin28 = new Padding(2, 0, 2, 0);
			this.label_NYVolt.Margin = margin28;
			this.label_NYVolt.Name = "label_NYVolt";
			System.Drawing.Size size28 = new System.Drawing.Size(63, 15);
			this.label_NYVolt.Size = size28;
			this.label_NYVolt.TabIndex = 4;
			this.label_NYVolt.Text = "500V AC";
			this.label_NYVolt.Visible = false;
			this.label_NYR.AutoSize = true;
			System.Drawing.Point location29 = new System.Drawing.Point(28, 90);
			this.label_NYR.Location = location29;
			Padding margin29 = new Padding(2, 0, 2, 0);
			this.label_NYR.Margin = margin29;
			this.label_NYR.Name = "label_NYR";
			System.Drawing.Size size29 = new System.Drawing.Size(75, 15);
			this.label_NYR.Size = size29;
			this.label_NYR.TabIndex = 0;
			this.label_NYR.Text = "耐压阈值:";
			this.label_NYR.Visible = false;
			this.label_JYVolt.AutoSize = true;
			System.Drawing.Point location30 = new System.Drawing.Point(485, 60);
			this.label_JYVolt.Location = location30;
			Padding margin30 = new Padding(2, 0, 2, 0);
			this.label_JYVolt.Margin = margin30;
			this.label_JYVolt.Name = "label_JYVolt";
			System.Drawing.Size size30 = new System.Drawing.Size(63, 15);
			this.label_JYVolt.Size = size30;
			this.label_JYVolt.TabIndex = 4;
			this.label_JYVolt.Text = "500V DC";
			this.label_NYV.AutoSize = true;
			System.Drawing.Point location31 = new System.Drawing.Point(403, 90);
			this.label_NYV.Location = location31;
			Padding margin31 = new Padding(2, 0, 2, 0);
			this.label_NYV.Margin = margin31;
			this.label_NYV.Name = "label_NYV";
			System.Drawing.Size size31 = new System.Drawing.Size(75, 15);
			this.label_NYV.Size = size31;
			this.label_NYV.TabIndex = 0;
			this.label_NYV.Text = "耐压电压:";
			this.label_NYV.Visible = false;
			this.label_JYR.AutoSize = true;
			System.Drawing.Point location32 = new System.Drawing.Point(28, 60);
			this.label_JYR.Location = location32;
			Padding margin32 = new Padding(2, 0, 2, 0);
			this.label_JYR.Margin = margin32;
			this.label_JYR.Name = "label_JYR";
			System.Drawing.Size size32 = new System.Drawing.Size(75, 15);
			this.label_JYR.Size = size32;
			this.label_JYR.TabIndex = 0;
			this.label_JYR.Text = "绝缘阈值:";
			this.label_JYV.AutoSize = true;
			System.Drawing.Point location33 = new System.Drawing.Point(403, 60);
			this.label_JYV.Location = location33;
			Padding margin33 = new Padding(2, 0, 2, 0);
			this.label_JYV.Margin = margin33;
			this.label_JYV.Name = "label_JYV";
			System.Drawing.Size size33 = new System.Drawing.Size(75, 15);
			this.label_JYV.Size = size33;
			this.label_JYV.TabIndex = 0;
			this.label_JYV.Text = "绝缘电压:";
			this.label_DTRange.AutoSize = true;
			System.Drawing.Point location34 = new System.Drawing.Point(111, 28);
			this.label_DTRange.Location = location34;
			Padding margin34 = new Padding(2, 0, 2, 0);
			this.label_DTRange.Margin = margin34;
			this.label_DTRange.Name = "label_DTRange";
			System.Drawing.Size size34 = new System.Drawing.Size(54, 15);
			this.label_DTRange.Size = size34;
			this.label_DTRange.TabIndex = 3;
			this.label_DTRange.Text = "1.0 Ω";
			this.label_DTR.AutoSize = true;
			System.Drawing.Point location35 = new System.Drawing.Point(28, 28);
			this.label_DTR.Location = location35;
			Padding margin35 = new Padding(2, 0, 2, 0);
			this.label_DTR.Margin = margin35;
			this.label_DTR.Name = "label_DTR";
			System.Drawing.Size size35 = new System.Drawing.Size(75, 15);
			this.label_DTR.Size = size35;
			this.label_DTR.TabIndex = 0;
			this.label_DTR.Text = "导通阈值:";
			this.groupBox2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox2.Controls.Add(this.dataGridView1);
			this.groupBox2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location36 = new System.Drawing.Point(11, 246);
			this.groupBox2.Location = location36;
			Padding margin36 = new Padding(2, 2, 2, 2);
			this.groupBox2.Margin = margin36;
			this.groupBox2.Name = "groupBox2";
			Padding padding2 = new Padding(2, 2, 2, 2);
			this.groupBox2.Padding = padding2;
			System.Drawing.Size size36 = new System.Drawing.Size(765, 260);
			this.groupBox2.Size = size36;
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "测试数据";
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			System.Drawing.Color window = System.Drawing.SystemColors.Window;
			this.dataGridView1.BackgroundColor = window;
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
			System.Drawing.Point location37 = new System.Drawing.Point(2, 19);
			this.dataGridView1.Location = location37;
			Padding margin37 = new Padding(2, 2, 2, 2);
			this.dataGridView1.Margin = margin37;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size37 = new System.Drawing.Size(761, 239);
			this.dataGridView1.Size = size37;
			this.dataGridView1.TabIndex = 7;
			this.dataGridView1.MouseDoubleClick += new MouseEventHandler(this.dataGridView1_MouseDoubleClick);
			this.Column_xh.HeaderText = "序号";
			this.Column_xh.Name = "Column_xh";
			this.Column_xh.ReadOnly = true;
			this.Column_xh.Width = 70;
			this.Column_startInterface.HeaderText = "起点接口";
			this.Column_startInterface.Name = "Column_startInterface";
			this.Column_startInterface.ReadOnly = true;
			this.Column_startInterface.Width = 110;
			this.Column_startPin.HeaderText = "起点接点";
			this.Column_startPin.Name = "Column_startPin";
			this.Column_startPin.ReadOnly = true;
			this.Column_startPin.Width = 110;
			this.Column_stopInterface.HeaderText = "终点接口";
			this.Column_stopInterface.Name = "Column_stopInterface";
			this.Column_stopInterface.ReadOnly = true;
			this.Column_stopInterface.Width = 110;
			this.Column_stopPin.HeaderText = "终点接点";
			this.Column_stopPin.Name = "Column_stopPin";
			this.Column_stopPin.ReadOnly = true;
			this.Column_stopPin.Width = 110;
			this.Column_dtValue.HeaderText = "导通电阻";
			this.Column_dtValue.Name = "Column_dtValue";
			this.Column_dtValue.ReadOnly = true;
			this.Column_dtValue.Width = 90;
			this.Column_dtResult.HeaderText = "导通\n结论";
			this.Column_dtResult.Name = "Column_dtResult";
			this.Column_dtResult.ReadOnly = true;
			this.Column_dtResult.Width = 110;
			this.Column_jyValue.HeaderText = "绝缘电阻";
			this.Column_jyValue.Name = "Column_jyValue";
			this.Column_jyValue.ReadOnly = true;
			this.Column_jyValue.Width = 90;
			this.Column_jyResult.HeaderText = "绝缘\n结论";
			this.Column_jyResult.Name = "Column_jyResult";
			this.Column_jyResult.ReadOnly = true;
			this.Column_jyResult.Width = 110;
			this.Column_nyValue.HeaderText = "耐压电流";
			this.Column_nyValue.Name = "Column_nyValue";
			this.Column_nyValue.ReadOnly = true;
			this.Column_nyResult.HeaderText = "耐压\n结论";
			this.Column_nyResult.Name = "Column_nyResult";
			this.Column_nyResult.ReadOnly = true;
			this.btnCreateReport.Anchor = AnchorStyles.Bottom;
			this.btnCreateReport.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location38 = new System.Drawing.Point(380, 525);
			this.btnCreateReport.Location = location38;
			Padding margin38 = new Padding(2, 2, 2, 2);
			this.btnCreateReport.Margin = margin38;
			this.btnCreateReport.Name = "btnCreateReport";
			System.Drawing.Size size38 = new System.Drawing.Size(90, 24);
			this.btnCreateReport.Size = size38;
			this.btnCreateReport.TabIndex = 8;
			this.btnCreateReport.Text = "生成报表";
			this.btnCreateReport.UseVisualStyleBackColor = true;
			this.btnCreateReport.Click += new System.EventHandler(this.btnCreateReport_Click);
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location39 = new System.Drawing.Point(660, 525);
			this.btnQuit.Location = location39;
			Padding margin39 = new Padding(2, 2, 2, 2);
			this.btnQuit.Margin = margin39;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size39 = new System.Drawing.Size(90, 24);
			this.btnQuit.Size = size39;
			this.btnQuit.TabIndex = 0;
			this.btnQuit.Text = "关闭";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btnPrintReport.Anchor = AnchorStyles.Bottom;
			this.btnPrintReport.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location40 = new System.Drawing.Point(509, 525);
			this.btnPrintReport.Location = location40;
			Padding margin40 = new Padding(2, 2, 2, 2);
			this.btnPrintReport.Margin = margin40;
			this.btnPrintReport.Name = "btnPrintReport";
			System.Drawing.Size size40 = new System.Drawing.Size(90, 24);
			this.btnPrintReport.Size = size40;
			this.btnPrintReport.TabIndex = 9;
			this.btnPrintReport.Text = "打印报表";
			this.btnPrintReport.UseVisualStyleBackColor = true;
			this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
			this.printDialog1.UseEXDialog = true;
			System.Drawing.Size autoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMargin = autoScrollMargin;
			System.Drawing.Size autoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = autoScrollMinSize;
			System.Drawing.Size clientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.ClientSize = clientSize;
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = (System.Drawing.Icon)resources.GetObject("printPreviewDialog1.Icon");
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.Visible = false;
			this.btnDLTestView.Anchor = AnchorStyles.Bottom;
			this.btnDLTestView.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location41 = new System.Drawing.Point(32, 525);
			this.btnDLTestView.Location = location41;
			Padding margin41 = new Padding(2, 2, 2, 2);
			this.btnDLTestView.Margin = margin41;
			this.btnDLTestView.Name = "btnDLTestView";
			System.Drawing.Size size41 = new System.Drawing.Size(135, 24);
			this.btnDLTestView.Size = size41;
			this.btnDLTestView.TabIndex = 8;
			this.btnDLTestView.Text = "查看短路测试数据";
			this.btnDLTestView.UseVisualStyleBackColor = true;
			this.btnDLTestView.Click += new System.EventHandler(this.btnDLTestView_Click);
			this.btnDDJYTestView.Anchor = AnchorStyles.Bottom;
			this.btnDDJYTestView.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location42 = new System.Drawing.Point(206, 525);
			this.btnDDJYTestView.Location = location42;
			Padding margin42 = new Padding(2, 2, 2, 2);
			this.btnDDJYTestView.Margin = margin42;
			this.btnDDJYTestView.Name = "btnDDJYTestView";
			System.Drawing.Size size42 = new System.Drawing.Size(135, 24);
			this.btnDDJYTestView.Size = size42;
			this.btnDDJYTestView.TabIndex = 8;
			this.btnDDJYTestView.Text = "查看对地绝缘数据";
			this.btnDDJYTestView.UseVisualStyleBackColor = true;
			this.btnDDJYTestView.Click += new System.EventHandler(this.btnDDJYTestView_Click);
			this.contextMenuStrip_DataProc.Font = new System.Drawing.Font("宋体", 10.8f);
			ToolStripItem[] toolStripItems = new ToolStripItem[]
			{
				this.toolStripMenuItem_ExportData
			};
			this.contextMenuStrip_DataProc.Items.AddRange(toolStripItems);
			this.contextMenuStrip_DataProc.Name = "contextMenuStrip1";
			System.Drawing.Size size43 = new System.Drawing.Size(165, 26);
			this.contextMenuStrip_DataProc.Size = size43;
			this.toolStripMenuItem_ExportData.Name = "toolStripMenuItem_ExportData";
			System.Drawing.Size size44 = new System.Drawing.Size(164, 22);
			this.toolStripMenuItem_ExportData.Size = size44;
			this.toolStripMenuItem_ExportData.Text = "导出表格数据";
			this.toolStripMenuItem_ExportData.Click += new System.EventHandler(this.toolStripMenuItem_ExportData_Click);
			this.groupBox3.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox3.Controls.Add(this.label_JYTime);
			this.groupBox3.Controls.Add(this.label_DTR);
			this.groupBox3.Controls.Add(this.label_DTRange);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label_DTV);
			this.groupBox3.Controls.Add(this.label_JYV);
			this.groupBox3.Controls.Add(this.label_JYR);
			this.groupBox3.Controls.Add(this.label_NYV);
			this.groupBox3.Controls.Add(this.label_JYRiseTime);
			this.groupBox3.Controls.Add(this.label_DTVoltage);
			this.groupBox3.Controls.Add(this.label_JYVolt);
			this.groupBox3.Controls.Add(this.label_DTC);
			this.groupBox3.Controls.Add(this.label_NYR);
			this.groupBox3.Controls.Add(this.label_NYVolt);
			this.groupBox3.Controls.Add(this.label_NYTime);
			this.groupBox3.Controls.Add(this.label_JYT);
			this.groupBox3.Controls.Add(this.label_DTCurrent);
			this.groupBox3.Controls.Add(this.label_NYT);
			this.groupBox3.Controls.Add(this.label_NYRange);
			this.groupBox3.Controls.Add(this.label_JYRange);
			this.groupBox3.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location43 = new System.Drawing.Point(11, 129);
			this.groupBox3.Location = location43;
			Padding margin43 = new Padding(2, 2, 2, 2);
			this.groupBox3.Margin = margin43;
			this.groupBox3.Name = "groupBox3";
			Padding padding3 = new Padding(2, 2, 2, 2);
			this.groupBox3.Padding = padding3;
			System.Drawing.Size size45 = new System.Drawing.Size(765, 110);
			this.groupBox3.Size = size45;
			this.groupBox3.TabIndex = 12;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "测试参数";
			this.label4.AutoSize = true;
			System.Drawing.Point location44 = new System.Drawing.Point(590, 60);
			this.label4.Location = location44;
			Padding margin44 = new Padding(2, 0, 2, 0);
			this.label4.Margin = margin44;
			this.label4.Name = "label4";
			System.Drawing.Size size46 = new System.Drawing.Size(105, 15);
			this.label4.Size = size46;
			this.label4.TabIndex = 0;
			this.label4.Text = "绝缘上升时间:";
			this.label4.Visible = false;
			this.label_DTV.AutoSize = true;
			System.Drawing.Point location45 = new System.Drawing.Point(215, 28);
			this.label_DTV.Location = location45;
			Padding margin45 = new Padding(2, 0, 2, 0);
			this.label_DTV.Margin = margin45;
			this.label_DTV.Name = "label_DTV";
			System.Drawing.Size size47 = new System.Drawing.Size(75, 15);
			this.label_DTV.Size = size47;
			this.label_DTV.TabIndex = 0;
			this.label_DTV.Text = "导通电压:";
			this.label_DTV.Visible = false;
			this.label_JYRiseTime.AutoSize = true;
			System.Drawing.Point location46 = new System.Drawing.Point(694, 60);
			this.label_JYRiseTime.Location = location46;
			Padding margin46 = new Padding(2, 0, 2, 0);
			this.label_JYRiseTime.Margin = margin46;
			this.label_JYRiseTime.Name = "label_JYRiseTime";
			System.Drawing.Size size48 = new System.Drawing.Size(47, 15);
			this.label_JYRiseTime.Size = size48;
			this.label_JYRiseTime.TabIndex = 4;
			this.label_JYRiseTime.Text = "1.0 s";
			this.label_JYRiseTime.Visible = false;
			this.label_DTVoltage.AutoSize = true;
			System.Drawing.Point location47 = new System.Drawing.Point(302, 28);
			this.label_DTVoltage.Location = location47;
			Padding margin47 = new Padding(2, 0, 2, 0);
			this.label_DTVoltage.Margin = margin47;
			this.label_DTVoltage.Name = "label_DTVoltage";
			System.Drawing.Size size49 = new System.Drawing.Size(63, 15);
			this.label_DTVoltage.Size = size49;
			this.label_DTVoltage.TabIndex = 4;
			this.label_DTVoltage.Text = "500V DC";
			this.label_DTVoltage.Visible = false;
			this.label_DTC.AutoSize = true;
			System.Drawing.Point location48 = new System.Drawing.Point(403, 28);
			this.label_DTC.Location = location48;
			Padding margin48 = new Padding(2, 0, 2, 0);
			this.label_DTC.Margin = margin48;
			this.label_DTC.Name = "label_DTC";
			System.Drawing.Size size50 = new System.Drawing.Size(75, 15);
			this.label_DTC.Size = size50;
			this.label_DTC.TabIndex = 0;
			this.label_DTC.Text = "导通电流:";
			this.label_DTC.Visible = false;
			this.label_DTCurrent.AutoSize = true;
			System.Drawing.Point location49 = new System.Drawing.Point(485, 28);
			this.label_DTCurrent.Location = location49;
			Padding margin49 = new Padding(2, 0, 2, 0);
			this.label_DTCurrent.Margin = margin49;
			this.label_DTCurrent.Name = "label_DTCurrent";
			System.Drawing.Size size51 = new System.Drawing.Size(55, 15);
			this.label_DTCurrent.Size = size51;
			this.label_DTCurrent.TabIndex = 5;
			this.label_DTCurrent.Text = "1.5 mA";
			this.label_DTCurrent.Visible = false;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize2 = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize2;
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.btnDDJYTestView);
			base.Controls.Add(this.btnDLTestView);
			base.Controls.Add(this.btnCreateReport);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnPrintReport);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin50 = new Padding(2, 2, 2, 2);
			base.Margin = margin50;
			base.Name = "ctFormProjectTestDataDetail";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "查看明细";
			base.Load += new System.EventHandler(this.ctFormProjectTestDataDetail_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormProjectTestDataDetail_SizeChanged);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			this.contextMenuStrip_DataProc.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			base.ResumeLayout(false);
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			base.Close();
		}
		public void RefreshDataGridView()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.dataGridView1.Rows.Clear();
				int inum = 0;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.mddbPathStr;
					connection.Open();
					string sqlcommand = "select top 1 * from THistoryDLDataDetail where HID=" + this.iHistoryDataInfoID + "";
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						this.bExistDLFlag = true;
					}
					dataReader.Close();
					dataReader = null;
					sqlcommand = "select * from THistoryDataInfo where ID = " + this.iHistoryDataInfoID;
					cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						this.ctTestNumberStr = dataReader["TestNumber"].ToString();
						this.ct_TestPCHStr = dataReader["batchMumberStr"].ToString();
						this.ct_TestBCXSStr = dataReader["bcCableName"].ToString();
						this.ct_TestDateStr = dataReader["TestTime"].ToString();
						this.ct_TestUserIDStr = dataReader["Tester"].ToString();
						this.ct_TestUserNameStr = dataReader["Operator"].ToString();
						this.ct_TestEnvironmentTempStr = dataReader["EnvironmentTemperature"].ToString();
						this.ct_TestAmbientHumidityStr = dataReader["AmbientHumidity"].ToString();
						this.ct_TestCSYTypeStr = dataReader["CSYType"].ToString();
						this.ct_TestCSYMeasureNoStr = dataReader["CSYMeasuringNumber"].ToString();
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
						this.iHintDTExcNum = System.Convert.ToInt32(dataReader["iHintDTExcNum"].ToString());
						this.iHintDLExcNum = System.Convert.ToInt32(dataReader["iHintDLExcNum"].ToString());
						this.iHintJYExcNum = System.Convert.ToInt32(dataReader["iHintJYExcNum"].ToString());
						this.iHintDDJYExcNum = System.Convert.ToInt32(dataReader["iHintDDJYExcNum"].ToString());
						this.iHintNYExcNum = System.Convert.ToInt32(dataReader["iHintNYExcNum"].ToString());
					}
					dataReader.Close();
					dataReader = null;
					this.label_DTRange.Text = this.ct_DTLimitValueStr;
					this.label_DTVoltage.Text = this.ct_DTVoltageStr;
					this.label_DTCurrent.Text = this.ct_DTCurrentStr;
					this.label_JYRange.Text = this.ct_JYLimitValueStr;
					this.label_JYTime.Text = this.ct_JYHoldTimeStr;
					this.label_JYVolt.Text = this.ct_JYDCHighVoltStr;
					this.label_JYRiseTime.Text = this.ct_JYDCRiseTimeStr;
					this.label_NYRange.Text = this.ct_NYLimitValueStr;
					this.label_NYTime.Text = this.ct_NYHoldTimeStr;
					this.label_NYVolt.Text = this.ct_NYACHighVoltStr;
					this.label_TestNumber.Text = this.ctTestNumberStr;
					this.label_TestPCHStr.Text = this.ct_TestPCHStr;
					this.label_bcCableName.Text = this.ct_TestBCXSStr;
					this.label_TestResult.Text = this.strTestResult;
					this.label_testDate.Text = this.ct_TestDateStr;
					this.label_OperatorName.Text = this.ct_TestUserNameStr;
					this.label_CSYType.Text = this.ct_TestCSYTypeStr;
					this.label_CSYMeasuringNumber.Text = this.ct_TestCSYMeasureNoStr;
					this.label_EnvironmentTemperature.Text = this.ct_TestEnvironmentTempStr;
					this.label_AmbientHumidity.Text = this.ct_TestAmbientHumidityStr;
					sqlcommand = "select * from THistoryDataDetail where HID = " + this.iHistoryDataInfoID + " order by ID";
					cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView1.Rows.Add(1);
						int num = inum + 1;
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
						this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["PlugName1"].ToString();
						this.dataGridView1.Rows[inum].Cells[2].Value = dataReader["Pin1"].ToString();
						this.dataGridView1.Rows[inum].Cells[3].Value = dataReader["PlugName2"].ToString();
						this.dataGridView1.Rows[inum].Cells[4].Value = dataReader["Pin2"].ToString();
						this.dataGridView1.Rows[inum].Cells[5].Value = dataReader["DTValue"].ToString();
						this.dataGridView1.Rows[inum].Cells[6].Value = dataReader["dtTestResult"].ToString();
						this.dataGridView1.Rows[inum].Cells[7].Value = dataReader["JYValue"].ToString();
						this.dataGridView1.Rows[inum].Cells[8].Value = dataReader["jyTestResult"].ToString();
						this.dataGridView1.Rows[inum].Cells[9].Value = dataReader["NYValue"].ToString();
						this.dataGridView1.Rows[inum].Cells[10].Value = dataReader["nyTestResult"].ToString();
						inum = num;
					}
					this.dataGridView1.AllowUserToAddRows = false;
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_771_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_771_0.StackTrace);
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
			catch (System.Exception arg_795_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_795_0.StackTrace);
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
				this.label_DTR.Visible = this.gLineTestProcessor.bDTTestEnabled;
				this.label_DTRange.Visible = this.gLineTestProcessor.bDTTestEnabled;
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				if (!kLineTestProcessor.bDTTestEnabled)
				{
					this.label_DTV.Visible = false;
					this.label_DTVoltage.Visible = false;
					this.label_DTC.Visible = false;
					this.label_DTCurrent.Visible = false;
				}
				else
				{
					this.label_DTV.Visible = kLineTestProcessor.bDTVoltCurrentShowFlag;
					this.label_DTVoltage.Visible = this.gLineTestProcessor.bDTVoltCurrentShowFlag;
					this.label_DTC.Visible = this.gLineTestProcessor.bDTVoltCurrentShowFlag;
					this.label_DTCurrent.Visible = this.gLineTestProcessor.bDTVoltCurrentShowFlag;
				}
				KLineTestProcessor this2 = this.gLineTestProcessor;
				if (!this2.bJYTestEnabled && !this2.bDDJYTestEnabled)
				{
					this.label_JYRange.Visible = false;
					this.label_JYR.Visible = false;
					this.label_JYTime.Visible = false;
					this.label_JYT.Visible = false;
					this.label_JYVolt.Visible = false;
					this.label_JYV.Visible = false;
				}
				else
				{
					this.label_JYRange.Visible = true;
					this.label_JYR.Visible = true;
					this.label_JYTime.Visible = true;
					this.label_JYT.Visible = true;
					this.label_JYVolt.Visible = true;
					this.label_JYV.Visible = true;
				}
				this.label_NYRange.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.label_NYR.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.label_NYTime.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.label_NYT.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.label_NYVolt.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.label_NYV.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.btnDLTestView.Visible = this.gLineTestProcessor.bDLTestEnabled;
				this.btnDDJYTestView.Visible = this.gLineTestProcessor.bDDJYTestEnabled;
			}
			catch (System.Exception arg_29F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_29F_0.StackTrace);
			}
		}
		public void GetReportDefaultSavePathFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				bool bHaveRecordFlag = false;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "select * from TUserCustomCableTestPara where LoginUser='" + this.loginUser + "'";
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						this.reportDefaultSavePathStr = dataReader["ReportDefaultSavePath"].ToString();
						bHaveRecordFlag = true;
					}
					dataReader.Close();
					dataReader = null;
					if (!bHaveRecordFlag)
					{
						string str = Application.StartupPath + "\\";
						this.reportDefaultSavePathStr = str;
						sqlcommand = "insert into TUserCustomCableTestPara(LoginUser,AutoConnDevice,IsResistanceCompensation,ReportDefaultSavePath) values('" + this.loginUser + "',1,1,'" + str + "')";
						cmd = new OleDbCommand(sqlcommand, connection);
						cmd.ExecuteNonQuery();
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_D9_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_D9_0.StackTrace);
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
			catch (System.Exception arg_FD_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_FD_0.StackTrace);
			}
		}
		private void ctFormProjectTestDataDetail_Load(object sender, System.EventArgs e)
		{
			try
			{
				string path = Application.StartupPath + "\\RBF\\";
				this.reportBackPathStr = path;
				if (!System.IO.Directory.Exists(path))
				{
					System.IO.Directory.CreateDirectory(this.reportBackPathStr);
				}
				this.projectReportPathStr = "";
				this.reportDefaultSavePathStr = "";
				this.bExistDLFlag = false;
				this.GetReportDefaultSavePathFunc();
				this.RefreshDataGridView();
				this.SetDGVWidthSizeFunc();
				for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
				{
					this.dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					this.dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
				{
					this.dataGridView1.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
			}
			catch (System.Exception arg_E8_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_E8_0.StackTrace);
			}
			int k = 0;
			if (0 < this.dataGridView1.Rows.Count)
			{
				do
				{
					this.dataGridView1.Rows[k].Selected = false;
					k++;
				}
				while (k < this.dataGridView1.Rows.Count);
			}
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode == 0)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
			catch (System.Exception arg_14E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_14E_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
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
				string tempfnStr;
				if (this.iFileType == 0)
				{
					string str = "_";
					tempfnStr = "线束测试报告_" + this.ct_TestBCXSStr + str + this.ct_TestPCHStr + str + tt + str + ttms + ".docx";
					string orfn2 = "_";
					string tempStr = "线束测试报告_" + this.ct_TestBCXSStr + orfn2 + this.ct_TestPCHStr + orfn2 + tt + orfn2 + ttms + ".pdf";
					this.reportBackFNStr = this.reportBackPathStr + tempStr;
				}
				else
				{
					string orfn2 = "_";
					tempfnStr = "线束测试报告_" + this.ct_TestBCXSStr + orfn2 + this.ct_TestPCHStr + orfn2 + tt + orfn2 + ttms + ".pdf";
					this.reportBackFNStr = this.reportBackPathStr + tempfnStr;
				}
				fn += tempfnStr;
			}
			catch (System.Exception arg_2CC_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2CC_0.StackTrace);
				if (-1 == fn.LastIndexOf(".pdf"))
				{
					fn = orfn + "\\线束测试报告.pdf";
					this.reportBackFNStr = this.reportBackPathStr + "\\线束测试报告.pdf";
				}
			}
			return fn;
		}
		private void ReportDefaultSavePathFunc()
		{
			OleDbConnection connection = null;
			try
			{
				ctFormSetDefaultSavePath ctFormSetDefaultSavePath = new ctFormSetDefaultSavePath(this.reportDefaultSavePathStr);
				this.setDefaultSavePathForm = ctFormSetDefaultSavePath;
				ctFormSetDefaultSavePath.Activate();
				this.setDefaultSavePathForm.ShowDialog();
				ctFormSetDefaultSavePath ctFormSetDefaultSavePath2 = this.setDefaultSavePathForm;
				if (ctFormSetDefaultSavePath2.bSubmitFlag)
				{
					this.reportDefaultSavePathStr = ctFormSetDefaultSavePath2.reportDefaultSavePathStr;
					try
					{
						connection = new OleDbConnection();
						connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
						connection.Open();
						new OleDbCommand("update TUserCustomCableTestPara set ReportDefaultSavePath = '" + this.reportDefaultSavePathStr + "' where LoginUser='" + this.loginUser + "'", connection).ExecuteNonQuery();
						connection.Close();
						connection = null;
					}
					catch (System.Exception arg_A9_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_A9_0.StackTrace);
						if (connection != null)
						{
							connection.Close();
							connection = null;
						}
					}
				}
			}
			catch (System.Exception arg_C2_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_C2_0.StackTrace);
			}
		}
		private void btnCreateReport_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dataGridView1.Rows.Count < 0)
				{
					MessageBox.Show("无记录!", "提示", MessageBoxButtons.OK);
					return;
				}
				try
				{
					if (string.IsNullOrEmpty(this.reportDefaultSavePathStr))
					{
						MessageBox.Show("未设置报表的默认保存路径，必须马上设置!", "提示", MessageBoxButtons.OK);
						this.ReportDefaultSavePathFunc();
						if (string.IsNullOrEmpty(this.reportDefaultSavePathStr))
						{
							MessageBox.Show("未设置报表的默认保存路径，报表生成失败!", "提示", MessageBoxButtons.OK);
							return;
						}
					}
					if (!System.IO.Directory.Exists(this.reportDefaultSavePathStr))
					{
						System.IO.Directory.CreateDirectory(this.reportDefaultSavePathStr);
						System.Threading.Thread.Sleep(100);
					}
				}
				catch (System.Exception arg_93_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_93_0.StackTrace);
				}
				if (!System.IO.Directory.Exists(this.reportDefaultSavePathStr))
				{
					MessageBox.Show("无效的报表保存路径!", "提示", MessageBoxButtons.OK);
					return;
				}
				if (this.gLineTestProcessor.bIsAdminFlag)
				{
					ctFormReportFileTypeChoice ctFormReportFileTypeChoice = new ctFormReportFileTypeChoice(this.iFileType);
					this.reportFileTypeChoiceForm = ctFormReportFileTypeChoice;
					ctFormReportFileTypeChoice.TopMost = true;
					this.reportFileTypeChoiceForm.Activate();
					this.reportFileTypeChoiceForm.ShowDialog();
					this.iFileType = this.reportFileTypeChoiceForm.iFileType;
				}
				else
				{
					this.iFileType = 1;
				}
				ctFormWait e2 = new ctFormWait(1);
				this.waitFinishedForm = e2;
				e2.TopMost = true;
				this.waitFinishedForm.Activate();
				this.waitFinishedForm.Focus();
				this.waitFinishedForm.Show();
				this.projectReportPathStr = this.GreateReportFNFunc(this.reportDefaultSavePathStr);
				this.bReportSuccFlag = false;
				System.Threading.Thread oThread = new System.Threading.Thread(new System.Threading.ThreadStart(this.SataRecordDataToPDFFunc));
				oThread.Start();
				oThread.Join();
				this.waitFinishedForm.bCloseFlag = true;
				this.waitFinishedForm.bSuccFlag = this.bReportSuccFlag;
				Process.Start(this.projectReportPathStr);
			}
			catch (System.Exception arg_1B3_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1B3_0.StackTrace);
			}
			ctFormWait this2 = this.waitFinishedForm;
			if (this2 != null)
			{
				this2.bCloseFlag = true;
			}
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
					if (this.strTestResult == ctFormProjectTestDataDetail.TEST_QUAL_STR)
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
									string sqlcommand = "select * from THistoryDDJYDataDetail where HID=" + this.iHistoryDataInfoID + " and TestResult='" + ctFormProjectTestDataDetail.TEST_NOT_QUAL_STR + "' order by ID";
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
									string sqlcommand3 = "select * from THistoryDataDetail where HID=" + this.iHistoryDataInfoID + " and nyTestResult='" + ctFormProjectTestDataDetail.TEST_NOT_QUAL_STR + "' order by ID";
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
									string sqlcommand4 = "select * from THistoryDataDetail where HID=" + this.iHistoryDataInfoID + " and jyTestResult='" + ctFormProjectTestDataDetail.TEST_NOT_QUAL_STR + "' order by ID";
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
									string sqlcommand5 = "select * from THistoryDataDetail where HID=" + this.iHistoryDataInfoID + " and dtTestResult='" + ctFormProjectTestDataDetail.TEST_NOT_QUAL_STR + "' order by ID";
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
				if (this.iFileType == 0)
				{
					doc.Save(this.projectReportPathStr, Aspose.Words.SaveFormat.Docx);
				}
				else
				{
					doc.Save(this.projectReportPathStr, Aspose.Words.SaveFormat.Pdf);
				}
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
				if (this.iFileType == 0)
				{
					startInfo.FileName = this.reportBackFNStr;
				}
				else
				{
					startInfo.FileName = this.projectReportPathStr;
				}
				startInfo.Verb = "print";
				startInfo.Arguments = "/p /h \"" + startInfo.FileName + "\"\"" + pd.PrinterSettings.PrinterName.ToString() + "\"";
				p.StartInfo = startInfo;
				p.Start();
				System.Threading.Thread.Sleep(3000);
				p.Close();
				this.bReportPrintSuccFlag = true;
			}
			catch (System.Exception ex_12A)
			{
				this.bReportPrintSuccFlag = false;
			}
		}
		private void btnPrintReport_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.bReportSuccFlag)
				{
					MessageBox.Show("无可打印的报表!", "提示", MessageBoxButtons.OK);
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
			catch (System.Exception arg_99_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_99_0.StackTrace);
			}
			ctFormWait this2 = this.waitFinishedForm;
			if (this2 != null)
			{
				this2.bCloseFlag = true;
			}
		}
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 897;
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
						catch (System.Exception ex_3F)
						{
							ia = iw / 10;
						}
						if (ia > 10)
						{
							ia = 10;
							try
							{
								ih = (iw - this.gLineTestProcessor.iDTJYNYTestColNum * 10) / 2;
								goto IL_87;
							}
							catch (System.Exception ex_68)
							{
								ih = (iw - 100) / 2;
								if (ih < 0)
								{
									ih = 0;
								}
								goto IL_87;
							}
						}
						int expr_7D = iw;
						iys = expr_7D - expr_7D / 10 * 10;
					}
					IL_87:
					int iTWidth = 80;
					try
					{
						int iDTJYNYTestColNum = this.gLineTestProcessor.iDTJYNYTestColNum;
						iTWidth = 800 / iDTJYNYTestColNum;
						iy = 800 - iDTJYNYTestColNum * iTWidth;
					}
					catch (System.Exception ex_B1)
					{
					}
					try
					{
						ic = (this.gLineTestProcessor.iDTJYNYTestColNum - 4) * 5 / 2;
					}
					catch (System.Exception ex_CE)
					{
					}
					this.dataGridView1.Columns[0].Width = iy + (iys - ic) + 75;
					int width = ia + (iTWidth + ih);
					this.dataGridView1.Columns[1].Width = width;
					int num = ia + iTWidth;
					this.dataGridView1.Columns[2].Width = num;
					this.dataGridView1.Columns[3].Width = width;
					this.dataGridView1.Columns[4].Width = num;
					int width2 = num + 10;
					this.dataGridView1.Columns[5].Width = width2;
					int width3 = num - 5;
					this.dataGridView1.Columns[6].Width = width3;
					this.dataGridView1.Columns[7].Width = width2;
					this.dataGridView1.Columns[8].Width = width3;
					this.dataGridView1.Columns[9].Width = width2;
					this.dataGridView1.Columns[10].Width = width3;
				}
			}
			catch (System.Exception arg_200_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_200_0.StackTrace);
			}
		}
		private void ctFormProjectTestDataDetail_SizeChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.SetDGVWidthSizeFunc();
			}
			catch (System.Exception arg_08_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_08_0.StackTrace);
			}
		}
		private void btnDLTestView_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.ct_iDLTFFlagStr == "0")
				{
					MessageBox.Show("未测!", "提示", MessageBoxButtons.OK);
				}
				else if (!this.bExistDLFlag)
				{
					MessageBox.Show("无短路!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					ctFormDLTestResultView this2 = new ctFormDLTestResultView(this.gLineTestProcessor, true, this.iHistoryDataInfoID);
					this.DLTestResultViewForm = this2;
					this2.Activate();
					this.DLTestResultViewForm.ShowDialog();
				}
			}
			catch (System.Exception arg_6E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_6E_0.StackTrace);
			}
		}
		private void btnDDJYTestView_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.ct_iDDJYTFFlagStr == "0")
				{
					MessageBox.Show("未测!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					ctFormDDJYTestResultView this2 = new ctFormDDJYTestResultView(this.gLineTestProcessor, true, this.iHistoryDataInfoID);
					this.DDjyTestResultViewForm = this2;
					this2.Activate();
					this.DDjyTestResultViewForm.ShowDialog();
				}
			}
			catch (System.Exception arg_53_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_53_0.StackTrace);
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
				wb.Save(csvFile, Aspose.Cells.SaveFormat.CSV);
				wb = null;
			}
			catch (System.Exception arg_6F6_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_6F6_0.StackTrace);
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
						string tempStr = this.ct_TestBCXSStr + str + tt + str + ttms;
						string xlsxFn = orfn + "\\测试数据_" + tempStr + ".xlsx";
						string csvFn = orfn + "\\测试数据_" + tempStr + ".csv";
						if (this.SaveToExcelFileFunc(xlsxFn, csvFn, this.ct_TestBCXSStr, ""))
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
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormProjectTestDataDetail();
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
