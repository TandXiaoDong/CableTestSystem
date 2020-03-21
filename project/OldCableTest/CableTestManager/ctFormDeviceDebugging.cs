using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormDeviceDebugging : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public string[] strIDArray;
		public string exportPathStr;
		public string loginUser;
		public string dbpath;
		public bool bCloseFlag;
		public int iStartValue;
		public int iEndValue;
		public int iDTLimitedValue;
		public int iTestTime;
		public int iAddedCount;
		public bool bSelfStudyFlag;
		public bool bSingleTestFlag;
		public bool bDTSDTestFlag;
		public bool bProbeTestFlag;
		public bool bProbeJKTestFlag;
		public bool bProbeFWTestFlag;
		public double dTestResultValue;
		public string jkNameStr;
		public int iDTSelfStudyTime;
		public int dev1;
		public int dev2;
		public int port1;
		public int port2;
		public int testtype;
		public int testcount;
		public int testtime;
		public int testvolt;
		public int currcount;
		public double dtoffset;
		public double mtimetick;
		public double ddtvolt;
		public double ddtcurr;
		private TabPage tabPage8;
		private NumericUpDown numericUpDown_DTSDTest_StopPin;
		private NumericUpDown numericUpDown_DTSDTest_StartPin;
		private Label label1;
		private Label label2;
		private Button btnDTSDTest;
		private Label label_ZXXSJ;
		private Label label_xxsj;
		private System.Windows.Forms.Timer timerXXSJ;
		private System.Windows.Forms.Timer timerZXXWait;
		private System.Windows.Forms.Timer timerWait;
		private System.Windows.Forms.Timer timerProbeJK;
		private System.Windows.Forms.Timer timerProbeFW;
		private DataGridView dataGridView4;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
		private ToolStripMenuItem toolStripMenuItem_ClearData;
		private ToolStripSeparator toolStripSeparator1;
		private TabControl tabControl1;
		private TabPage tabPage4;
		private TabPage tabPage5;
		private DataGridView dataGridView3;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn dgvTBC_StartPin;
		private DataGridViewTextBoxColumn dgvTBC_StopPin;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private Label label_Probe_JK_DTYZ_unit;
		private NumericUpDown numericUpDown_Probe_JK_DTYZ;
		private Label label_Probe_JK_DTYZ;
		private ComboBox comboBox_Probe_JK;
		private Label label_Probe_JK;
		private Label label_Probe_FW_DTYZ_unit;
		private NumericUpDown numericUpDown_Probe_FW_DTYZ;
		private Label label_Probe_FW_DTYZ;
		private Label label_Probe_StopPin;
		private RadioButton radioButton_Probe_JK;
		private RadioButton radioButton_Probe_FW;
		private NumericUpDown numericUpDown_Probe_StopPin;
		private NumericUpDown numericUpDown_Probe_StartPin;
		private Label label_Probe_StartPin;
		private TabControl tabControl2;
		private TabPage tabPage6;
		private TabPage tabPage7;
		private Button btnStartProbeFWTest;
		private Button btnStartProbeJKTest;
		private DataGridView dataGridView5;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
		private ContextMenuStrip contextMenuStrip_DataProc;
		private ToolStripMenuItem toolStripMenuItem_ExportData;
		private FolderBrowserDialog folderBrowserDialog1;
		private CheckBox checkBox_JYTest_LV;
		private NumericUpDown numericUpDown_DT_Current;
		private Label label_DT_Volt_unit;
		private NumericUpDown numericUpDown_DT_Volt;
		private Label label_dt_dy;
		private Label label_dt_dl;
		private Label label_DT_Current_unit;
		private CheckBox checkBox_SelfStudy_FourWire;
		private CheckBox checkBox_DTTest_FourWire;
		private TabPage tabPage3;
		private System.Windows.Forms.Timer timer_ProbeTest;
		private Button btnStartProbeTest;
		private NumericUpDown numericUpDown_Probe_Pin;
		private Label label_Probe_Pin;
		private RadioButton radioButton_Probe_DD;
		private IContainer components;
		private TabControl tabControl_Debugging;
		private RadioButton radioButton_NYTest;
		private RadioButton radioButton_JYTest;
		private RadioButton radioButton_DTTest;
		private Label label_DTBC_FH;
		private NumericUpDown numericUpDown_DTBC;
		private Label label_DTBC;
		private Label label_testvolt_FH;
		private Label label4;
		private Label label_testtime_FH;
		private NumericUpDown numericUpDown_testvolt;
		private NumericUpDown numericUpDown_testtime;
		private Label label_testvolt;
		private Label label_testtime;
		private Label label_JGSJ_FH;
		private NumericUpDown numericUpDown_JGSJ;
		private Label label_JGSJ;
		private Button btnStartTest;
		private NumericUpDown numericUpDown_SingleTest_TestNum;
		private NumericUpDown numericUpDown_SingleTest_StopPin;
		private NumericUpDown numericUpDown_SingleTest_StartPin;
		private Label label10;
		private Label label11;
		private Label label12;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private DataGridView dataGridView1;
		private NumericUpDown numericUpDown_SelfStudy_StartPin;
		private Label label_SelfStudy_StartPin;
		private NumericUpDown numericUpDown_SelfStudy_StopPin;
		private Label label_SelfStudy_StopPin;
		private NumericUpDown numericUpDown_SelfStudy_DTYZ;
		private Label label_SelfStudy_DTYZ;
		private Label label_SelfStudy_DTYZ_unit;
		private Button btnOnOffStudy;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column3;
		private DataGridViewTextBoxColumn Column5;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private DataGridViewTextBoxColumn Column6;
		private DataGridView dataGridView2;
		private GroupBox groupBox_Debugging;
		private ProgressBar progressBar1;
		private Label label_progress;
		private System.Windows.Forms.Timer timer_updatePro;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Timer timer_SingleTest;
		public ctFormDeviceDebugging(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
					this.strIDArray = new string[5000];
				}
				catch (System.Exception arg_46_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_46_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormDeviceDebugging()
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
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormDeviceDebugging));
			this.groupBox_Debugging = new GroupBox();
			this.tabControl_Debugging = new TabControl();
			this.tabPage1 = new TabPage();
			this.checkBox_SelfStudy_FourWire = new CheckBox();
			this.btnOnOffStudy = new Button();
			this.label_SelfStudy_DTYZ_unit = new Label();
			this.numericUpDown_SelfStudy_DTYZ = new NumericUpDown();
			this.numericUpDown_SelfStudy_StopPin = new NumericUpDown();
			this.numericUpDown_SelfStudy_StartPin = new NumericUpDown();
			this.label_SelfStudy_DTYZ = new Label();
			this.label_SelfStudy_StopPin = new Label();
			this.label_SelfStudy_StartPin = new Label();
			this.dataGridView1 = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.tabPage2 = new TabPage();
			this.checkBox_JYTest_LV = new CheckBox();
			this.numericUpDown_DT_Current = new NumericUpDown();
			this.label_DT_Volt_unit = new Label();
			this.numericUpDown_DT_Volt = new NumericUpDown();
			this.label_dt_dy = new Label();
			this.label_dt_dl = new Label();
			this.label_DT_Current_unit = new Label();
			this.checkBox_DTTest_FourWire = new CheckBox();
			this.label4 = new Label();
			this.btnStartTest = new Button();
			this.numericUpDown_SingleTest_TestNum = new NumericUpDown();
			this.numericUpDown_SingleTest_StopPin = new NumericUpDown();
			this.numericUpDown_SingleTest_StartPin = new NumericUpDown();
			this.label10 = new Label();
			this.label11 = new Label();
			this.label12 = new Label();
			this.label_testvolt_FH = new Label();
			this.label_testtime_FH = new Label();
			this.label_JGSJ_FH = new Label();
			this.label_DTBC_FH = new Label();
			this.numericUpDown_testvolt = new NumericUpDown();
			this.numericUpDown_testtime = new NumericUpDown();
			this.numericUpDown_JGSJ = new NumericUpDown();
			this.label_testvolt = new Label();
			this.numericUpDown_DTBC = new NumericUpDown();
			this.label_testtime = new Label();
			this.label_JGSJ = new Label();
			this.label_DTBC = new Label();
			this.radioButton_NYTest = new RadioButton();
			this.radioButton_JYTest = new RadioButton();
			this.radioButton_DTTest = new RadioButton();
			this.dataGridView2 = new DataGridView();
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
			this.Column6 = new DataGridViewTextBoxColumn();
			this.tabPage3 = new TabPage();
			this.tabControl1 = new TabControl();
			this.tabPage4 = new TabPage();
			this.dataGridView3 = new DataGridView();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.dgvTBC_StartPin = new DataGridViewTextBoxColumn();
			this.dgvTBC_StopPin = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
			this.btnStartProbeTest = new Button();
			this.numericUpDown_Probe_Pin = new NumericUpDown();
			this.label_Probe_Pin = new Label();
			this.radioButton_Probe_DD = new RadioButton();
			this.tabPage5 = new TabPage();
			this.tabControl2 = new TabControl();
			this.tabPage6 = new TabPage();
			this.dataGridView4 = new DataGridView();
			this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
			this.btnStartProbeFWTest = new Button();
			this.radioButton_Probe_FW = new RadioButton();
			this.label_Probe_StartPin = new Label();
			this.numericUpDown_Probe_StartPin = new NumericUpDown();
			this.numericUpDown_Probe_StopPin = new NumericUpDown();
			this.label_Probe_StopPin = new Label();
			this.label_Probe_FW_DTYZ = new Label();
			this.label_Probe_FW_DTYZ_unit = new Label();
			this.numericUpDown_Probe_FW_DTYZ = new NumericUpDown();
			this.tabPage7 = new TabPage();
			this.btnStartProbeJKTest = new Button();
			this.dataGridView5 = new DataGridView();
			this.dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
			this.radioButton_Probe_JK = new RadioButton();
			this.label_Probe_JK_DTYZ_unit = new Label();
			this.label_Probe_JK = new Label();
			this.numericUpDown_Probe_JK_DTYZ = new NumericUpDown();
			this.comboBox_Probe_JK = new ComboBox();
			this.label_Probe_JK_DTYZ = new Label();
			this.tabPage8 = new TabPage();
			this.numericUpDown_DTSDTest_StopPin = new NumericUpDown();
			this.numericUpDown_DTSDTest_StartPin = new NumericUpDown();
			this.label1 = new Label();
			this.label2 = new Label();
			this.btnDTSDTest = new Button();
			this.label_ZXXSJ = new Label();
			this.label_xxsj = new Label();
			this.progressBar1 = new ProgressBar();
			this.label_progress = new Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer_updatePro = new System.Windows.Forms.Timer(this.components);
			this.timer_SingleTest = new System.Windows.Forms.Timer(this.components);
			this.timer_ProbeTest = new System.Windows.Forms.Timer(this.components);
			this.contextMenuStrip_DataProc = new ContextMenuStrip(this.components);
			this.toolStripMenuItem_ClearData = new ToolStripMenuItem();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.toolStripMenuItem_ExportData = new ToolStripMenuItem();
			this.folderBrowserDialog1 = new FolderBrowserDialog();
			this.timerProbeJK = new System.Windows.Forms.Timer(this.components);
			this.timerProbeFW = new System.Windows.Forms.Timer(this.components);
			this.timerWait = new System.Windows.Forms.Timer(this.components);
			this.timerZXXWait = new System.Windows.Forms.Timer(this.components);
			this.timerXXSJ = new System.Windows.Forms.Timer(this.components);
			this.groupBox_Debugging.SuspendLayout();
			this.tabControl_Debugging.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_SelfStudy_DTYZ).BeginInit();
			((ISupportInitialize)this.numericUpDown_SelfStudy_StopPin).BeginInit();
			((ISupportInitialize)this.numericUpDown_SelfStudy_StartPin).BeginInit();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			this.tabPage2.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_DT_Current).BeginInit();
			((ISupportInitialize)this.numericUpDown_DT_Volt).BeginInit();
			((ISupportInitialize)this.numericUpDown_SingleTest_TestNum).BeginInit();
			((ISupportInitialize)this.numericUpDown_SingleTest_StopPin).BeginInit();
			((ISupportInitialize)this.numericUpDown_SingleTest_StartPin).BeginInit();
			((ISupportInitialize)this.numericUpDown_testvolt).BeginInit();
			((ISupportInitialize)this.numericUpDown_testtime).BeginInit();
			((ISupportInitialize)this.numericUpDown_JGSJ).BeginInit();
			((ISupportInitialize)this.numericUpDown_DTBC).BeginInit();
			((ISupportInitialize)this.dataGridView2).BeginInit();
			this.tabPage3.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage4.SuspendLayout();
			((ISupportInitialize)this.dataGridView3).BeginInit();
			((ISupportInitialize)this.numericUpDown_Probe_Pin).BeginInit();
			this.tabPage5.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage6.SuspendLayout();
			((ISupportInitialize)this.dataGridView4).BeginInit();
			((ISupportInitialize)this.numericUpDown_Probe_StartPin).BeginInit();
			((ISupportInitialize)this.numericUpDown_Probe_StopPin).BeginInit();
			((ISupportInitialize)this.numericUpDown_Probe_FW_DTYZ).BeginInit();
			this.tabPage7.SuspendLayout();
			((ISupportInitialize)this.dataGridView5).BeginInit();
			((ISupportInitialize)this.numericUpDown_Probe_JK_DTYZ).BeginInit();
			this.tabPage8.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_DTSDTest_StopPin).BeginInit();
			((ISupportInitialize)this.numericUpDown_DTSDTest_StartPin).BeginInit();
			this.contextMenuStrip_DataProc.SuspendLayout();
			base.SuspendLayout();
			this.groupBox_Debugging.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_Debugging.Controls.Add(this.tabControl_Debugging);
			this.groupBox_Debugging.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(9, 5);
			this.groupBox_Debugging.Location = location;
			Padding margin = new Padding(2);
			this.groupBox_Debugging.Margin = margin;
			this.groupBox_Debugging.Name = "groupBox_Debugging";
			Padding padding = new Padding(2);
			this.groupBox_Debugging.Padding = padding;
			System.Drawing.Size size = new System.Drawing.Size(776, 524);
			this.groupBox_Debugging.Size = size;
			this.groupBox_Debugging.TabIndex = 1;
			this.groupBox_Debugging.TabStop = false;
			this.tabControl_Debugging.Appearance = TabAppearance.Buttons;
			this.tabControl_Debugging.Controls.Add(this.tabPage1);
			this.tabControl_Debugging.Controls.Add(this.tabPage2);
			this.tabControl_Debugging.Controls.Add(this.tabPage3);
			this.tabControl_Debugging.Controls.Add(this.tabPage8);
			this.tabControl_Debugging.Dock = DockStyle.Fill;
			System.Drawing.Size itemSize = new System.Drawing.Size(150, 30);
			this.tabControl_Debugging.ItemSize = itemSize;
			System.Drawing.Point location2 = new System.Drawing.Point(2, 19);
			this.tabControl_Debugging.Location = location2;
			Padding margin2 = new Padding(2);
			this.tabControl_Debugging.Margin = margin2;
			this.tabControl_Debugging.Name = "tabControl_Debugging";
			this.tabControl_Debugging.SelectedIndex = 0;
			System.Drawing.Size size2 = new System.Drawing.Size(772, 503);
			this.tabControl_Debugging.Size = size2;
			this.tabControl_Debugging.SizeMode = TabSizeMode.Fixed;
			this.tabControl_Debugging.TabIndex = 0;
			this.tabControl_Debugging.SelectedIndexChanged += new System.EventHandler(this.tabControl_Debugging_SelectedIndexChanged);
			this.tabPage1.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage1.Controls.Add(this.checkBox_SelfStudy_FourWire);
			this.tabPage1.Controls.Add(this.btnOnOffStudy);
			this.tabPage1.Controls.Add(this.label_SelfStudy_DTYZ_unit);
			this.tabPage1.Controls.Add(this.numericUpDown_SelfStudy_DTYZ);
			this.tabPage1.Controls.Add(this.numericUpDown_SelfStudy_StopPin);
			this.tabPage1.Controls.Add(this.numericUpDown_SelfStudy_StartPin);
			this.tabPage1.Controls.Add(this.label_SelfStudy_DTYZ);
			this.tabPage1.Controls.Add(this.label_SelfStudy_StopPin);
			this.tabPage1.Controls.Add(this.label_SelfStudy_StartPin);
			this.tabPage1.Controls.Add(this.dataGridView1);
			System.Drawing.Point location3 = new System.Drawing.Point(4, 34);
			this.tabPage1.Location = location3;
			Padding margin3 = new Padding(2);
			this.tabPage1.Margin = margin3;
			this.tabPage1.Name = "tabPage1";
			Padding padding2 = new Padding(2);
			this.tabPage1.Padding = padding2;
			System.Drawing.Size size3 = new System.Drawing.Size(764, 465);
			this.tabPage1.Size = size3;
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "自学习测试";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.checkBox_SelfStudy_FourWire.AutoSize = true;
			System.Drawing.Point location4 = new System.Drawing.Point(608, 16);
			this.checkBox_SelfStudy_FourWire.Location = location4;
			Padding margin4 = new Padding(2);
			this.checkBox_SelfStudy_FourWire.Margin = margin4;
			this.checkBox_SelfStudy_FourWire.Name = "checkBox_SelfStudy_FourWire";
			System.Drawing.Size size4 = new System.Drawing.Size(71, 19);
			this.checkBox_SelfStudy_FourWire.Size = size4;
			this.checkBox_SelfStudy_FourWire.TabIndex = 20;
			this.checkBox_SelfStudy_FourWire.Text = "四线法";
			this.checkBox_SelfStudy_FourWire.UseVisualStyleBackColor = true;
			this.btnOnOffStudy.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(336, 61);
			this.btnOnOffStudy.Location = location5;
			Padding margin5 = new Padding(2);
			this.btnOnOffStudy.Margin = margin5;
			this.btnOnOffStudy.Name = "btnOnOffStudy";
			System.Drawing.Size size5 = new System.Drawing.Size(90, 28);
			this.btnOnOffStudy.Size = size5;
			this.btnOnOffStudy.TabIndex = 19;
			this.btnOnOffStudy.Text = "开始学习";
			this.btnOnOffStudy.UseVisualStyleBackColor = true;
			this.btnOnOffStudy.Click += new System.EventHandler(this.btnOnOffStudy_Click);
			this.label_SelfStudy_DTYZ_unit.AutoSize = true;
			System.Drawing.Point location6 = new System.Drawing.Point(541, 18);
			this.label_SelfStudy_DTYZ_unit.Location = location6;
			Padding margin6 = new Padding(2, 0, 2, 0);
			this.label_SelfStudy_DTYZ_unit.Margin = margin6;
			this.label_SelfStudy_DTYZ_unit.Name = "label_SelfStudy_DTYZ_unit";
			System.Drawing.Size size6 = new System.Drawing.Size(22, 15);
			this.label_SelfStudy_DTYZ_unit.Size = size6;
			this.label_SelfStudy_DTYZ_unit.TabIndex = 18;
			this.label_SelfStudy_DTYZ_unit.Text = "Ω";
			System.Drawing.Point location7 = new System.Drawing.Point(463, 13);
			this.numericUpDown_SelfStudy_DTYZ.Location = location7;
			Padding margin7 = new Padding(2);
			this.numericUpDown_SelfStudy_DTYZ.Margin = margin7;
			decimal maximum = new decimal(new int[]
			{
				1000000,
				0,
				0,
				0
			});
			this.numericUpDown_SelfStudy_DTYZ.Maximum = maximum;
			this.numericUpDown_SelfStudy_DTYZ.Name = "numericUpDown_SelfStudy_DTYZ";
			System.Drawing.Size size7 = new System.Drawing.Size(75, 24);
			this.numericUpDown_SelfStudy_DTYZ.Size = size7;
			this.numericUpDown_SelfStudy_DTYZ.TabIndex = 17;
			this.numericUpDown_SelfStudy_DTYZ.TextAlign = HorizontalAlignment.Center;
			decimal value = new decimal(new int[]
			{
				1000,
				0,
				0,
				0
			});
			this.numericUpDown_SelfStudy_DTYZ.Value = value;
			System.Drawing.Point location8 = new System.Drawing.Point(282, 13);
			this.numericUpDown_SelfStudy_StopPin.Location = location8;
			Padding margin8 = new Padding(2);
			this.numericUpDown_SelfStudy_StopPin.Margin = margin8;
			decimal maximum2 = new decimal(new int[]
			{
				262144,
				0,
				0,
				0
			});
			this.numericUpDown_SelfStudy_StopPin.Maximum = maximum2;
			decimal minimum = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_SelfStudy_StopPin.Minimum = minimum;
			this.numericUpDown_SelfStudy_StopPin.Name = "numericUpDown_SelfStudy_StopPin";
			System.Drawing.Size size8 = new System.Drawing.Size(75, 24);
			this.numericUpDown_SelfStudy_StopPin.Size = size8;
			this.numericUpDown_SelfStudy_StopPin.TabIndex = 17;
			this.numericUpDown_SelfStudy_StopPin.TextAlign = HorizontalAlignment.Center;
			decimal value2 = new decimal(new int[]
			{
				64,
				0,
				0,
				0
			});
			this.numericUpDown_SelfStudy_StopPin.Value = value2;
			System.Drawing.Point location9 = new System.Drawing.Point(101, 13);
			this.numericUpDown_SelfStudy_StartPin.Location = location9;
			Padding margin9 = new Padding(2);
			this.numericUpDown_SelfStudy_StartPin.Margin = margin9;
			decimal maximum3 = new decimal(new int[]
			{
				262144,
				0,
				0,
				0
			});
			this.numericUpDown_SelfStudy_StartPin.Maximum = maximum3;
			decimal minimum2 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_SelfStudy_StartPin.Minimum = minimum2;
			this.numericUpDown_SelfStudy_StartPin.Name = "numericUpDown_SelfStudy_StartPin";
			System.Drawing.Size size9 = new System.Drawing.Size(75, 24);
			this.numericUpDown_SelfStudy_StartPin.Size = size9;
			this.numericUpDown_SelfStudy_StartPin.TabIndex = 17;
			this.numericUpDown_SelfStudy_StartPin.TextAlign = HorizontalAlignment.Center;
			decimal value3 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_SelfStudy_StartPin.Value = value3;
			this.label_SelfStudy_DTYZ.AutoSize = true;
			System.Drawing.Point location10 = new System.Drawing.Point(384, 18);
			this.label_SelfStudy_DTYZ.Location = location10;
			Padding margin10 = new Padding(2, 0, 2, 0);
			this.label_SelfStudy_DTYZ.Margin = margin10;
			this.label_SelfStudy_DTYZ.Name = "label_SelfStudy_DTYZ";
			System.Drawing.Size size10 = new System.Drawing.Size(75, 15);
			this.label_SelfStudy_DTYZ.Size = size10;
			this.label_SelfStudy_DTYZ.TabIndex = 15;
			this.label_SelfStudy_DTYZ.Text = "导通阈值:";
			this.label_SelfStudy_StopPin.AutoSize = true;
			System.Drawing.Point location11 = new System.Drawing.Point(203, 18);
			this.label_SelfStudy_StopPin.Location = location11;
			Padding margin11 = new Padding(2, 0, 2, 0);
			this.label_SelfStudy_StopPin.Margin = margin11;
			this.label_SelfStudy_StopPin.Name = "label_SelfStudy_StopPin";
			System.Drawing.Size size11 = new System.Drawing.Size(75, 15);
			this.label_SelfStudy_StopPin.Size = size11;
			this.label_SelfStudy_StopPin.TabIndex = 15;
			this.label_SelfStudy_StopPin.Text = "终点针脚:";
			this.label_SelfStudy_StartPin.AutoSize = true;
			System.Drawing.Point location12 = new System.Drawing.Point(22, 18);
			this.label_SelfStudy_StartPin.Location = location12;
			Padding margin12 = new Padding(2, 0, 2, 0);
			this.label_SelfStudy_StartPin.Margin = margin12;
			this.label_SelfStudy_StartPin.Name = "label_SelfStudy_StartPin";
			System.Drawing.Size size12 = new System.Drawing.Size(75, 15);
			this.label_SelfStudy_StartPin.Size = size12;
			this.label_SelfStudy_StartPin.TabIndex = 15;
			this.label_SelfStudy_StartPin.Text = "起点针脚:";
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Color window = System.Drawing.SystemColors.Window;
			this.dataGridView1.BackgroundColor = window;
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[]
			{
				this.Column1,
				this.Column3,
				this.Column5
			};
			this.dataGridView1.Columns.AddRange(dataGridViewColumns);
			System.Drawing.Point location13 = new System.Drawing.Point(7, 106);
			this.dataGridView1.Location = location13;
			Padding margin13 = new Padding(2);
			this.dataGridView1.Margin = margin13;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size13 = new System.Drawing.Size(752, 355);
			this.dataGridView1.Size = size13;
			this.dataGridView1.TabIndex = 14;
			this.Column1.HeaderText = "序号";
			this.Column1.Name = "Column1";
			this.Column1.Width = 76;
			this.Column3.HeaderText = "起点针脚";
			this.Column3.Name = "Column3";
			this.Column3.Width = 200;
			this.Column5.HeaderText = "终点针脚";
			this.Column5.Name = "Column5";
			this.Column5.Width = 200;
			this.tabPage2.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage2.Controls.Add(this.checkBox_JYTest_LV);
			this.tabPage2.Controls.Add(this.numericUpDown_DT_Current);
			this.tabPage2.Controls.Add(this.label_DT_Volt_unit);
			this.tabPage2.Controls.Add(this.numericUpDown_DT_Volt);
			this.tabPage2.Controls.Add(this.label_dt_dy);
			this.tabPage2.Controls.Add(this.label_dt_dl);
			this.tabPage2.Controls.Add(this.label_DT_Current_unit);
			this.tabPage2.Controls.Add(this.checkBox_DTTest_FourWire);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.btnStartTest);
			this.tabPage2.Controls.Add(this.numericUpDown_SingleTest_TestNum);
			this.tabPage2.Controls.Add(this.numericUpDown_SingleTest_StopPin);
			this.tabPage2.Controls.Add(this.numericUpDown_SingleTest_StartPin);
			this.tabPage2.Controls.Add(this.label10);
			this.tabPage2.Controls.Add(this.label11);
			this.tabPage2.Controls.Add(this.label12);
			this.tabPage2.Controls.Add(this.label_testvolt_FH);
			this.tabPage2.Controls.Add(this.label_testtime_FH);
			this.tabPage2.Controls.Add(this.label_JGSJ_FH);
			this.tabPage2.Controls.Add(this.label_DTBC_FH);
			this.tabPage2.Controls.Add(this.numericUpDown_testvolt);
			this.tabPage2.Controls.Add(this.numericUpDown_testtime);
			this.tabPage2.Controls.Add(this.numericUpDown_JGSJ);
			this.tabPage2.Controls.Add(this.label_testvolt);
			this.tabPage2.Controls.Add(this.numericUpDown_DTBC);
			this.tabPage2.Controls.Add(this.label_testtime);
			this.tabPage2.Controls.Add(this.label_JGSJ);
			this.tabPage2.Controls.Add(this.label_DTBC);
			this.tabPage2.Controls.Add(this.radioButton_NYTest);
			this.tabPage2.Controls.Add(this.radioButton_JYTest);
			this.tabPage2.Controls.Add(this.radioButton_DTTest);
			this.tabPage2.Controls.Add(this.dataGridView2);
			System.Drawing.Point location14 = new System.Drawing.Point(4, 34);
			this.tabPage2.Location = location14;
			Padding margin14 = new Padding(2);
			this.tabPage2.Margin = margin14;
			this.tabPage2.Name = "tabPage2";
			Padding padding3 = new Padding(2);
			this.tabPage2.Padding = padding3;
			System.Drawing.Size size14 = new System.Drawing.Size(764, 465);
			this.tabPage2.Size = size14;
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "单项测试";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.checkBox_JYTest_LV.AutoSize = true;
			System.Drawing.Point location15 = new System.Drawing.Point(121, 50);
			this.checkBox_JYTest_LV.Location = location15;
			Padding margin15 = new Padding(2);
			this.checkBox_JYTest_LV.Margin = margin15;
			this.checkBox_JYTest_LV.Name = "checkBox_JYTest_LV";
			System.Drawing.Size size15 = new System.Drawing.Size(86, 19);
			this.checkBox_JYTest_LV.Size = size15;
			this.checkBox_JYTest_LV.TabIndex = 49;
			this.checkBox_JYTest_LV.Text = "低压绝缘";
			this.checkBox_JYTest_LV.UseVisualStyleBackColor = true;
			this.checkBox_JYTest_LV.Visible = false;
			this.checkBox_JYTest_LV.CheckedChanged += new System.EventHandler(this.checkBox_JYTest_LV_CheckedChanged);
			this.numericUpDown_DT_Current.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location16 = new System.Drawing.Point(502, 46);
			this.numericUpDown_DT_Current.Location = location16;
			Padding margin16 = new Padding(2);
			this.numericUpDown_DT_Current.Margin = margin16;
			decimal maximum4 = new decimal(new int[]
			{
				10000,
				0,
				0,
				0
			});
			this.numericUpDown_DT_Current.Maximum = maximum4;
			this.numericUpDown_DT_Current.Name = "numericUpDown_DT_Current";
			System.Drawing.Size size16 = new System.Drawing.Size(82, 24);
			this.numericUpDown_DT_Current.Size = size16;
			this.numericUpDown_DT_Current.TabIndex = 44;
			this.numericUpDown_DT_Current.TextAlign = HorizontalAlignment.Center;
			decimal value4 = new decimal(new int[]
			{
				2000,
				0,
				0,
				0
			});
			this.numericUpDown_DT_Current.Value = value4;
			this.label_DT_Volt_unit.AutoSize = true;
			this.label_DT_Volt_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location17 = new System.Drawing.Point(386, 50);
			this.label_DT_Volt_unit.Location = location17;
			Padding margin17 = new Padding(2, 0, 2, 0);
			this.label_DT_Volt_unit.Margin = margin17;
			this.label_DT_Volt_unit.Name = "label_DT_Volt_unit";
			System.Drawing.Size size17 = new System.Drawing.Size(15, 15);
			this.label_DT_Volt_unit.Size = size17;
			this.label_DT_Volt_unit.TabIndex = 48;
			this.label_DT_Volt_unit.Text = "V";
			this.numericUpDown_DT_Volt.DecimalPlaces = 2;
			this.numericUpDown_DT_Volt.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location18 = new System.Drawing.Point(302, 46);
			this.numericUpDown_DT_Volt.Location = location18;
			Padding margin18 = new Padding(2);
			this.numericUpDown_DT_Volt.Margin = margin18;
			this.numericUpDown_DT_Volt.Name = "numericUpDown_DT_Volt";
			System.Drawing.Size size18 = new System.Drawing.Size(75, 24);
			this.numericUpDown_DT_Volt.Size = size18;
			this.numericUpDown_DT_Volt.TabIndex = 46;
			this.numericUpDown_DT_Volt.TextAlign = HorizontalAlignment.Center;
			decimal value5 = new decimal(new int[]
			{
				25,
				0,
				0,
				65536
			});
			this.numericUpDown_DT_Volt.Value = value5;
			this.label_dt_dy.AutoSize = true;
			this.label_dt_dy.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location19 = new System.Drawing.Point(222, 50);
			this.label_dt_dy.Location = location19;
			Padding margin19 = new Padding(2, 0, 2, 0);
			this.label_dt_dy.Margin = margin19;
			this.label_dt_dy.Name = "label_dt_dy";
			System.Drawing.Size size19 = new System.Drawing.Size(75, 15);
			this.label_dt_dy.Size = size19;
			this.label_dt_dy.TabIndex = 47;
			this.label_dt_dy.Text = "导通电压:";
			this.label_dt_dl.AutoSize = true;
			this.label_dt_dl.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location20 = new System.Drawing.Point(423, 50);
			this.label_dt_dl.Location = location20;
			Padding margin20 = new Padding(2, 0, 2, 0);
			this.label_dt_dl.Margin = margin20;
			this.label_dt_dl.Name = "label_dt_dl";
			System.Drawing.Size size20 = new System.Drawing.Size(75, 15);
			this.label_dt_dl.Size = size20;
			this.label_dt_dl.TabIndex = 43;
			this.label_dt_dl.Text = "导通电流:";
			this.label_DT_Current_unit.AutoSize = true;
			this.label_DT_Current_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location21 = new System.Drawing.Point(591, 50);
			this.label_DT_Current_unit.Location = location21;
			Padding margin21 = new Padding(2, 0, 2, 0);
			this.label_DT_Current_unit.Margin = margin21;
			this.label_DT_Current_unit.Name = "label_DT_Current_unit";
			System.Drawing.Size size21 = new System.Drawing.Size(23, 15);
			this.label_DT_Current_unit.Size = size21;
			this.label_DT_Current_unit.TabIndex = 45;
			this.label_DT_Current_unit.Text = "mA";
			this.checkBox_DTTest_FourWire.AutoSize = true;
			System.Drawing.Point location22 = new System.Drawing.Point(638, 18);
			this.checkBox_DTTest_FourWire.Location = location22;
			Padding margin22 = new Padding(2);
			this.checkBox_DTTest_FourWire.Margin = margin22;
			this.checkBox_DTTest_FourWire.Name = "checkBox_DTTest_FourWire";
			System.Drawing.Size size22 = new System.Drawing.Size(71, 19);
			this.checkBox_DTTest_FourWire.Size = size22;
			this.checkBox_DTTest_FourWire.TabIndex = 31;
			this.checkBox_DTTest_FourWire.Text = "四线法";
			this.checkBox_DTTest_FourWire.UseVisualStyleBackColor = true;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Color scrollBar = System.Drawing.SystemColors.ScrollBar;
			this.label4.ForeColor = scrollBar;
			System.Drawing.Point location23 = new System.Drawing.Point(22, 110);
			this.label4.Location = location23;
			Padding margin23 = new Padding(2, 0, 2, 0);
			this.label4.Margin = margin23;
			this.label4.Name = "label4";
			System.Drawing.Size size23 = new System.Drawing.Size(563, 12);
			this.label4.Size = size23;
			this.label4.TabIndex = 30;
			this.label4.Text = "---------------------------------------------------------------------------------------------";
			this.btnStartTest.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location24 = new System.Drawing.Point(638, 102);
			this.btnStartTest.Location = location24;
			Padding margin24 = new Padding(2);
			this.btnStartTest.Margin = margin24;
			this.btnStartTest.Name = "btnStartTest";
			System.Drawing.Size size24 = new System.Drawing.Size(90, 28);
			this.btnStartTest.Size = size24;
			this.btnStartTest.TabIndex = 29;
			this.btnStartTest.Text = "启动测试";
			this.btnStartTest.UseVisualStyleBackColor = true;
			this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
			System.Drawing.Point location25 = new System.Drawing.Point(502, 129);
			this.numericUpDown_SingleTest_TestNum.Location = location25;
			Padding margin25 = new Padding(2);
			this.numericUpDown_SingleTest_TestNum.Margin = margin25;
			decimal minimum3 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_SingleTest_TestNum.Minimum = minimum3;
			this.numericUpDown_SingleTest_TestNum.Name = "numericUpDown_SingleTest_TestNum";
			System.Drawing.Size size25 = new System.Drawing.Size(82, 24);
			this.numericUpDown_SingleTest_TestNum.Size = size25;
			this.numericUpDown_SingleTest_TestNum.TabIndex = 26;
			this.numericUpDown_SingleTest_TestNum.TextAlign = HorizontalAlignment.Center;
			decimal value6 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_SingleTest_TestNum.Value = value6;
			System.Drawing.Point location26 = new System.Drawing.Point(302, 129);
			this.numericUpDown_SingleTest_StopPin.Location = location26;
			Padding margin26 = new Padding(2);
			this.numericUpDown_SingleTest_StopPin.Margin = margin26;
			decimal maximum5 = new decimal(new int[]
			{
				262144,
				0,
				0,
				0
			});
			this.numericUpDown_SingleTest_StopPin.Maximum = maximum5;
			decimal minimum4 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_SingleTest_StopPin.Minimum = minimum4;
			this.numericUpDown_SingleTest_StopPin.Name = "numericUpDown_SingleTest_StopPin";
			System.Drawing.Size size26 = new System.Drawing.Size(75, 24);
			this.numericUpDown_SingleTest_StopPin.Size = size26;
			this.numericUpDown_SingleTest_StopPin.TabIndex = 27;
			this.numericUpDown_SingleTest_StopPin.TextAlign = HorizontalAlignment.Center;
			decimal value7 = new decimal(new int[]
			{
				64,
				0,
				0,
				0
			});
			this.numericUpDown_SingleTest_StopPin.Value = value7;
			System.Drawing.Point location27 = new System.Drawing.Point(106, 129);
			this.numericUpDown_SingleTest_StartPin.Location = location27;
			Padding margin27 = new Padding(2);
			this.numericUpDown_SingleTest_StartPin.Margin = margin27;
			decimal maximum6 = new decimal(new int[]
			{
				262144,
				0,
				0,
				0
			});
			this.numericUpDown_SingleTest_StartPin.Maximum = maximum6;
			decimal minimum5 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_SingleTest_StartPin.Minimum = minimum5;
			this.numericUpDown_SingleTest_StartPin.Name = "numericUpDown_SingleTest_StartPin";
			System.Drawing.Size size27 = new System.Drawing.Size(75, 24);
			this.numericUpDown_SingleTest_StartPin.Size = size27;
			this.numericUpDown_SingleTest_StartPin.TabIndex = 25;
			this.numericUpDown_SingleTest_StartPin.TextAlign = HorizontalAlignment.Center;
			decimal value8 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_SingleTest_StartPin.Value = value8;
			this.label10.AutoSize = true;
			System.Drawing.Point location28 = new System.Drawing.Point(423, 133);
			this.label10.Location = location28;
			Padding margin28 = new Padding(2, 0, 2, 0);
			this.label10.Margin = margin28;
			this.label10.Name = "label10";
			System.Drawing.Size size28 = new System.Drawing.Size(75, 15);
			this.label10.Size = size28;
			this.label10.TabIndex = 22;
			this.label10.Text = "测试次数:";
			this.label11.AutoSize = true;
			System.Drawing.Point location29 = new System.Drawing.Point(221, 133);
			this.label11.Location = location29;
			Padding margin29 = new Padding(2, 0, 2, 0);
			this.label11.Margin = margin29;
			this.label11.Name = "label11";
			System.Drawing.Size size29 = new System.Drawing.Size(75, 15);
			this.label11.Size = size29;
			this.label11.TabIndex = 23;
			this.label11.Text = "终点针脚:";
			this.label12.AutoSize = true;
			System.Drawing.Point location30 = new System.Drawing.Point(22, 133);
			this.label12.Location = location30;
			Padding margin30 = new Padding(2, 0, 2, 0);
			this.label12.Margin = margin30;
			this.label12.Name = "label12";
			System.Drawing.Size size30 = new System.Drawing.Size(75, 15);
			this.label12.Size = size30;
			this.label12.TabIndex = 24;
			this.label12.Text = "起点针脚:";
			this.label_testvolt_FH.AutoSize = true;
			System.Drawing.Point location31 = new System.Drawing.Point(595, 85);
			this.label_testvolt_FH.Location = location31;
			Padding margin31 = new Padding(2, 0, 2, 0);
			this.label_testvolt_FH.Margin = margin31;
			this.label_testvolt_FH.Name = "label_testvolt_FH";
			System.Drawing.Size size31 = new System.Drawing.Size(15, 15);
			this.label_testvolt_FH.Size = size31;
			this.label_testvolt_FH.TabIndex = 21;
			this.label_testvolt_FH.Text = "V";
			this.label_testvolt_FH.Visible = false;
			this.label_testtime_FH.AutoSize = true;
			System.Drawing.Point location32 = new System.Drawing.Point(386, 85);
			this.label_testtime_FH.Location = location32;
			Padding margin32 = new Padding(2, 0, 2, 0);
			this.label_testtime_FH.Margin = margin32;
			this.label_testtime_FH.Name = "label_testtime_FH";
			System.Drawing.Size size32 = new System.Drawing.Size(15, 15);
			this.label_testtime_FH.Size = size32;
			this.label_testtime_FH.TabIndex = 21;
			this.label_testtime_FH.Text = "s";
			this.label_testtime_FH.Visible = false;
			this.label_JGSJ_FH.AutoSize = true;
			System.Drawing.Point location33 = new System.Drawing.Point(595, 19);
			this.label_JGSJ_FH.Location = location33;
			Padding margin33 = new Padding(2, 0, 2, 0);
			this.label_JGSJ_FH.Margin = margin33;
			this.label_JGSJ_FH.Name = "label_JGSJ_FH";
			System.Drawing.Size size33 = new System.Drawing.Size(15, 15);
			this.label_JGSJ_FH.Size = size33;
			this.label_JGSJ_FH.TabIndex = 21;
			this.label_JGSJ_FH.Text = "s";
			this.label_DTBC_FH.AutoSize = true;
			System.Drawing.Point location34 = new System.Drawing.Point(382, 19);
			this.label_DTBC_FH.Location = location34;
			Padding margin34 = new Padding(2, 0, 2, 0);
			this.label_DTBC_FH.Margin = margin34;
			this.label_DTBC_FH.Name = "label_DTBC_FH";
			System.Drawing.Size size34 = new System.Drawing.Size(22, 15);
			this.label_DTBC_FH.Size = size34;
			this.label_DTBC_FH.TabIndex = 21;
			this.label_DTBC_FH.Text = "Ω";
			System.Drawing.Point location35 = new System.Drawing.Point(502, 81);
			this.numericUpDown_testvolt.Location = location35;
			Padding margin35 = new Padding(2);
			this.numericUpDown_testvolt.Margin = margin35;
			decimal maximum7 = new decimal(new int[]
			{
				2000,
				0,
				0,
				0
			});
			this.numericUpDown_testvolt.Maximum = maximum7;
			this.numericUpDown_testvolt.Name = "numericUpDown_testvolt";
			System.Drawing.Size size35 = new System.Drawing.Size(82, 24);
			this.numericUpDown_testvolt.Size = size35;
			this.numericUpDown_testvolt.TabIndex = 20;
			this.numericUpDown_testvolt.TextAlign = HorizontalAlignment.Center;
			decimal value9 = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			this.numericUpDown_testvolt.Value = value9;
			this.numericUpDown_testvolt.Visible = false;
			this.numericUpDown_testtime.DecimalPlaces = 1;
			System.Drawing.Point location36 = new System.Drawing.Point(302, 81);
			this.numericUpDown_testtime.Location = location36;
			Padding margin36 = new Padding(2);
			this.numericUpDown_testtime.Margin = margin36;
			decimal maximum8 = new decimal(new int[]
			{
				120,
				0,
				0,
				0
			});
			this.numericUpDown_testtime.Maximum = maximum8;
			decimal minimum6 = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.numericUpDown_testtime.Minimum = minimum6;
			this.numericUpDown_testtime.Name = "numericUpDown_testtime";
			System.Drawing.Size size36 = new System.Drawing.Size(75, 24);
			this.numericUpDown_testtime.Size = size36;
			this.numericUpDown_testtime.TabIndex = 20;
			this.numericUpDown_testtime.TextAlign = HorizontalAlignment.Center;
			decimal value10 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_testtime.Value = value10;
			this.numericUpDown_testtime.Visible = false;
			this.numericUpDown_JGSJ.DecimalPlaces = 2;
			decimal increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.numericUpDown_JGSJ.Increment = increment;
			System.Drawing.Point location37 = new System.Drawing.Point(502, 15);
			this.numericUpDown_JGSJ.Location = location37;
			Padding margin37 = new Padding(2);
			this.numericUpDown_JGSJ.Margin = margin37;
			decimal maximum9 = new decimal(new int[]
			{
				10,
				0,
				0,
				0
			});
			this.numericUpDown_JGSJ.Maximum = maximum9;
			this.numericUpDown_JGSJ.Name = "numericUpDown_JGSJ";
			System.Drawing.Size size37 = new System.Drawing.Size(82, 24);
			this.numericUpDown_JGSJ.Size = size37;
			this.numericUpDown_JGSJ.TabIndex = 20;
			this.numericUpDown_JGSJ.TextAlign = HorizontalAlignment.Center;
			decimal value11 = new decimal(new int[]
			{
				5,
				0,
				0,
				65536
			});
			this.numericUpDown_JGSJ.Value = value11;
			this.label_testvolt.AutoSize = true;
			System.Drawing.Point location38 = new System.Drawing.Point(423, 85);
			this.label_testvolt.Location = location38;
			Padding margin38 = new Padding(2, 0, 2, 0);
			this.label_testvolt.Margin = margin38;
			this.label_testvolt.Name = "label_testvolt";
			System.Drawing.Size size38 = new System.Drawing.Size(75, 15);
			this.label_testvolt.Size = size38;
			this.label_testvolt.TabIndex = 19;
			this.label_testvolt.Text = "测试电压:";
			this.label_testvolt.Visible = false;
			this.numericUpDown_DTBC.DecimalPlaces = 3;
			System.Drawing.Point location39 = new System.Drawing.Point(302, 15);
			this.numericUpDown_DTBC.Location = location39;
			Padding margin39 = new Padding(2);
			this.numericUpDown_DTBC.Margin = margin39;
			decimal maximum10 = new decimal(new int[]
			{
				1000,
				0,
				0,
				0
			});
			this.numericUpDown_DTBC.Maximum = maximum10;
			this.numericUpDown_DTBC.Name = "numericUpDown_DTBC";
			System.Drawing.Size size39 = new System.Drawing.Size(75, 24);
			this.numericUpDown_DTBC.Size = size39;
			this.numericUpDown_DTBC.TabIndex = 20;
			this.numericUpDown_DTBC.TextAlign = HorizontalAlignment.Center;
			this.label_testtime.AutoSize = true;
			System.Drawing.Point location40 = new System.Drawing.Point(222, 85);
			this.label_testtime.Location = location40;
			Padding margin40 = new Padding(2, 0, 2, 0);
			this.label_testtime.Margin = margin40;
			this.label_testtime.Name = "label_testtime";
			System.Drawing.Size size40 = new System.Drawing.Size(75, 15);
			this.label_testtime.Size = size40;
			this.label_testtime.TabIndex = 19;
			this.label_testtime.Text = "保持时间:";
			this.label_testtime.Visible = false;
			this.label_JGSJ.AutoSize = true;
			System.Drawing.Point location41 = new System.Drawing.Point(423, 19);
			this.label_JGSJ.Location = location41;
			Padding margin41 = new Padding(2, 0, 2, 0);
			this.label_JGSJ.Margin = margin41;
			this.label_JGSJ.Name = "label_JGSJ";
			System.Drawing.Size size41 = new System.Drawing.Size(75, 15);
			this.label_JGSJ.Size = size41;
			this.label_JGSJ.TabIndex = 19;
			this.label_JGSJ.Text = "测试间隔:";
			this.label_DTBC.AutoSize = true;
			System.Drawing.Point location42 = new System.Drawing.Point(222, 19);
			this.label_DTBC.Location = location42;
			Padding margin42 = new Padding(2, 0, 2, 0);
			this.label_DTBC.Margin = margin42;
			this.label_DTBC.Name = "label_DTBC";
			System.Drawing.Size size42 = new System.Drawing.Size(75, 15);
			this.label_DTBC.Size = size42;
			this.label_DTBC.TabIndex = 19;
			this.label_DTBC.Text = "导通补偿:";
			this.radioButton_NYTest.AutoSize = true;
			System.Drawing.Point location43 = new System.Drawing.Point(24, 83);
			this.radioButton_NYTest.Location = location43;
			Padding margin43 = new Padding(2);
			this.radioButton_NYTest.Margin = margin43;
			this.radioButton_NYTest.Name = "radioButton_NYTest";
			System.Drawing.Size size43 = new System.Drawing.Size(85, 19);
			this.radioButton_NYTest.Size = size43;
			this.radioButton_NYTest.TabIndex = 16;
			this.radioButton_NYTest.Text = "耐压测试";
			this.radioButton_NYTest.UseVisualStyleBackColor = true;
			this.radioButton_NYTest.CheckedChanged += new System.EventHandler(this.radioButton_NYTest_CheckedChanged);
			this.radioButton_JYTest.AutoSize = true;
			System.Drawing.Point location44 = new System.Drawing.Point(24, 50);
			this.radioButton_JYTest.Location = location44;
			Padding margin44 = new Padding(2);
			this.radioButton_JYTest.Margin = margin44;
			this.radioButton_JYTest.Name = "radioButton_JYTest";
			System.Drawing.Size size44 = new System.Drawing.Size(85, 19);
			this.radioButton_JYTest.Size = size44;
			this.radioButton_JYTest.TabIndex = 16;
			this.radioButton_JYTest.Text = "绝缘测试";
			this.radioButton_JYTest.UseVisualStyleBackColor = true;
			this.radioButton_JYTest.CheckedChanged += new System.EventHandler(this.radioButton_JYTest_CheckedChanged);
			this.radioButton_DTTest.AutoSize = true;
			this.radioButton_DTTest.Checked = true;
			System.Drawing.Point location45 = new System.Drawing.Point(24, 18);
			this.radioButton_DTTest.Location = location45;
			Padding margin45 = new Padding(2);
			this.radioButton_DTTest.Margin = margin45;
			this.radioButton_DTTest.Name = "radioButton_DTTest";
			System.Drawing.Size size45 = new System.Drawing.Size(85, 19);
			this.radioButton_DTTest.Size = size45;
			this.radioButton_DTTest.TabIndex = 16;
			this.radioButton_DTTest.TabStop = true;
			this.radioButton_DTTest.Text = "导通测试";
			this.radioButton_DTTest.UseVisualStyleBackColor = true;
			this.radioButton_DTTest.CheckedChanged += new System.EventHandler(this.radioButton_DTTest_CheckedChanged);
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.AllowUserToResizeColumns = false;
			this.dataGridView2.AllowUserToResizeRows = false;
			this.dataGridView2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Color window2 = System.Drawing.SystemColors.Window;
			this.dataGridView2.BackgroundColor = window2;
			this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns2 = new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn1,
				this.dataGridViewTextBoxColumn3,
				this.dataGridViewTextBoxColumn5,
				this.Column6
			};
			this.dataGridView2.Columns.AddRange(dataGridViewColumns2);
			System.Drawing.Point location46 = new System.Drawing.Point(7, 178);
			this.dataGridView2.Location = location46;
			Padding margin46 = new Padding(2);
			this.dataGridView2.Margin = margin46;
			this.dataGridView2.MultiSelect = false;
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.RowHeadersVisible = false;
			this.dataGridView2.RowTemplate.Height = 27;
			this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size46 = new System.Drawing.Size(751, 285);
			this.dataGridView2.Size = size46;
			this.dataGridView2.TabIndex = 15;
			this.dataGridViewTextBoxColumn1.HeaderText = "序号";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Width = 76;
			this.dataGridViewTextBoxColumn3.HeaderText = "起点针脚";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Width = 200;
			this.dataGridViewTextBoxColumn5.HeaderText = "终点针脚";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.Width = 200;
			this.Column6.HeaderText = "测试值";
			this.Column6.Name = "Column6";
			this.Column6.Width = 200;
			this.tabPage3.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage3.Controls.Add(this.tabControl1);
			System.Drawing.Point location47 = new System.Drawing.Point(4, 34);
			this.tabPage3.Location = location47;
			Padding margin47 = new Padding(2);
			this.tabPage3.Margin = margin47;
			this.tabPage3.Name = "tabPage3";
			Padding padding4 = new Padding(2);
			this.tabPage3.Padding = padding4;
			System.Drawing.Size size47 = new System.Drawing.Size(764, 465);
			this.tabPage3.Size = size47;
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "探针测试";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.tabControl1.Appearance = TabAppearance.Buttons;
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Dock = DockStyle.Fill;
			System.Drawing.Size itemSize2 = new System.Drawing.Size(240, 30);
			this.tabControl1.ItemSize = itemSize2;
			System.Drawing.Point location48 = new System.Drawing.Point(2, 2);
			this.tabControl1.Location = location48;
			Padding margin48 = new Padding(2);
			this.tabControl1.Margin = margin48;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			System.Drawing.Size size48 = new System.Drawing.Size(758, 459);
			this.tabControl1.Size = size48;
			this.tabControl1.SizeMode = TabSizeMode.Fixed;
			this.tabControl1.TabIndex = 41;
			this.tabPage4.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage4.Controls.Add(this.dataGridView3);
			this.tabPage4.Controls.Add(this.btnStartProbeTest);
			this.tabPage4.Controls.Add(this.numericUpDown_Probe_Pin);
			this.tabPage4.Controls.Add(this.label_Probe_Pin);
			this.tabPage4.Controls.Add(this.radioButton_Probe_DD);
			System.Drawing.Point location49 = new System.Drawing.Point(4, 34);
			this.tabPage4.Location = location49;
			Padding margin49 = new Padding(2);
			this.tabPage4.Margin = margin49;
			this.tabPage4.Name = "tabPage4";
			Padding padding5 = new Padding(2);
			this.tabPage4.Padding = padding5;
			System.Drawing.Size size49 = new System.Drawing.Size(750, 421);
			this.tabPage4.Size = size49;
			this.tabPage4.TabIndex = 0;
			this.tabPage4.Text = "探针测试";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.dataGridView3.AllowUserToAddRows = false;
			this.dataGridView3.AllowUserToDeleteRows = false;
			this.dataGridView3.AllowUserToResizeColumns = false;
			this.dataGridView3.AllowUserToResizeRows = false;
			this.dataGridView3.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Color window3 = System.Drawing.SystemColors.Window;
			this.dataGridView3.BackgroundColor = window3;
			this.dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns3 = new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn2,
				this.dgvTBC_StartPin,
				this.dgvTBC_StopPin,
				this.dataGridViewTextBoxColumn7
			};
			this.dataGridView3.Columns.AddRange(dataGridViewColumns3);
			System.Drawing.Point location50 = new System.Drawing.Point(9, 96);
			this.dataGridView3.Location = location50;
			Padding margin50 = new Padding(2);
			this.dataGridView3.Margin = margin50;
			this.dataGridView3.MultiSelect = false;
			this.dataGridView3.Name = "dataGridView3";
			this.dataGridView3.RowHeadersVisible = false;
			this.dataGridView3.RowTemplate.Height = 27;
			this.dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size50 = new System.Drawing.Size(733, 323);
			this.dataGridView3.Size = size50;
			this.dataGridView3.TabIndex = 45;
			this.dataGridViewTextBoxColumn2.HeaderText = "序号";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Width = 76;
			this.dgvTBC_StartPin.HeaderText = "起点针脚";
			this.dgvTBC_StartPin.Name = "dgvTBC_StartPin";
			this.dgvTBC_StartPin.Width = 200;
			this.dgvTBC_StopPin.HeaderText = "终点针脚";
			this.dgvTBC_StopPin.Name = "dgvTBC_StopPin";
			this.dgvTBC_StopPin.Width = 200;
			this.dataGridViewTextBoxColumn7.HeaderText = "测试值";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.Width = 200;
			this.btnStartProbeTest.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location51 = new System.Drawing.Point(459, 30);
			this.btnStartProbeTest.Location = location51;
			Padding margin51 = new Padding(2);
			this.btnStartProbeTest.Margin = margin51;
			this.btnStartProbeTest.Name = "btnStartProbeTest";
			System.Drawing.Size size51 = new System.Drawing.Size(90, 28);
			this.btnStartProbeTest.Size = size51;
			this.btnStartProbeTest.TabIndex = 30;
			this.btnStartProbeTest.Text = "启动测试";
			this.btnStartProbeTest.UseVisualStyleBackColor = true;
			this.btnStartProbeTest.Click += new System.EventHandler(this.btnStartProbeTest_Click);
			System.Drawing.Point location52 = new System.Drawing.Point(247, 32);
			this.numericUpDown_Probe_Pin.Location = location52;
			Padding margin52 = new Padding(2);
			this.numericUpDown_Probe_Pin.Margin = margin52;
			decimal maximum11 = new decimal(new int[]
			{
				262144,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_Pin.Maximum = maximum11;
			decimal minimum7 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_Pin.Minimum = minimum7;
			this.numericUpDown_Probe_Pin.Name = "numericUpDown_Probe_Pin";
			System.Drawing.Size size52 = new System.Drawing.Size(90, 24);
			this.numericUpDown_Probe_Pin.Size = size52;
			this.numericUpDown_Probe_Pin.TabIndex = 27;
			this.numericUpDown_Probe_Pin.TextAlign = HorizontalAlignment.Center;
			decimal value12 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_Pin.Value = value12;
			this.label_Probe_Pin.AutoSize = true;
			System.Drawing.Point location53 = new System.Drawing.Point(164, 36);
			this.label_Probe_Pin.Location = location53;
			Padding margin53 = new Padding(2, 0, 2, 0);
			this.label_Probe_Pin.Margin = margin53;
			this.label_Probe_Pin.Name = "label_Probe_Pin";
			System.Drawing.Size size53 = new System.Drawing.Size(75, 15);
			this.label_Probe_Pin.Size = size53;
			this.label_Probe_Pin.TabIndex = 26;
			this.label_Probe_Pin.Text = "测试针脚:";
			this.radioButton_Probe_DD.AutoSize = true;
			this.radioButton_Probe_DD.Checked = true;
			System.Drawing.Point location54 = new System.Drawing.Point(63, 34);
			this.radioButton_Probe_DD.Location = location54;
			Padding margin54 = new Padding(2);
			this.radioButton_Probe_DD.Margin = margin54;
			this.radioButton_Probe_DD.Name = "radioButton_Probe_DD";
			System.Drawing.Size size54 = new System.Drawing.Size(85, 19);
			this.radioButton_Probe_DD.Size = size54;
			this.radioButton_Probe_DD.TabIndex = 17;
			this.radioButton_Probe_DD.TabStop = true;
			this.radioButton_Probe_DD.Text = "单针方式";
			this.radioButton_Probe_DD.UseVisualStyleBackColor = true;
			this.tabPage5.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage5.Controls.Add(this.tabControl2);
			System.Drawing.Point location55 = new System.Drawing.Point(4, 34);
			this.tabPage5.Location = location55;
			Padding margin55 = new Padding(2);
			this.tabPage5.Margin = margin55;
			this.tabPage5.Name = "tabPage5";
			Padding padding6 = new Padding(2);
			this.tabPage5.Padding = padding6;
			System.Drawing.Size size55 = new System.Drawing.Size(750, 421);
			this.tabPage5.Size = size55;
			this.tabPage5.TabIndex = 1;
			this.tabPage5.Text = "探针寻址";
			this.tabPage5.UseVisualStyleBackColor = true;
			this.tabControl2.Appearance = TabAppearance.Buttons;
			this.tabControl2.Controls.Add(this.tabPage6);
			this.tabControl2.Controls.Add(this.tabPage7);
			this.tabControl2.Dock = DockStyle.Fill;
			System.Drawing.Size itemSize3 = new System.Drawing.Size(260, 30);
			this.tabControl2.ItemSize = itemSize3;
			System.Drawing.Point location56 = new System.Drawing.Point(2, 2);
			this.tabControl2.Location = location56;
			Padding margin56 = new Padding(2);
			this.tabControl2.Margin = margin56;
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			System.Drawing.Size size56 = new System.Drawing.Size(744, 415);
			this.tabControl2.Size = size56;
			this.tabControl2.SizeMode = TabSizeMode.Fixed;
			this.tabControl2.TabIndex = 65;
			this.tabPage6.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage6.Controls.Add(this.dataGridView4);
			this.tabPage6.Controls.Add(this.btnStartProbeFWTest);
			this.tabPage6.Controls.Add(this.radioButton_Probe_FW);
			this.tabPage6.Controls.Add(this.label_Probe_StartPin);
			this.tabPage6.Controls.Add(this.numericUpDown_Probe_StartPin);
			this.tabPage6.Controls.Add(this.numericUpDown_Probe_StopPin);
			this.tabPage6.Controls.Add(this.label_Probe_StopPin);
			this.tabPage6.Controls.Add(this.label_Probe_FW_DTYZ);
			this.tabPage6.Controls.Add(this.label_Probe_FW_DTYZ_unit);
			this.tabPage6.Controls.Add(this.numericUpDown_Probe_FW_DTYZ);
			System.Drawing.Point location57 = new System.Drawing.Point(4, 34);
			this.tabPage6.Location = location57;
			Padding margin57 = new Padding(2);
			this.tabPage6.Margin = margin57;
			this.tabPage6.Name = "tabPage6";
			Padding padding7 = new Padding(2);
			this.tabPage6.Padding = padding7;
			System.Drawing.Size size57 = new System.Drawing.Size(736, 377);
			this.tabPage6.Size = size57;
			this.tabPage6.TabIndex = 0;
			this.tabPage6.Text = "范围方式寻址";
			this.tabPage6.UseVisualStyleBackColor = true;
			this.dataGridView4.AllowUserToAddRows = false;
			this.dataGridView4.AllowUserToDeleteRows = false;
			this.dataGridView4.AllowUserToResizeColumns = false;
			this.dataGridView4.AllowUserToResizeRows = false;
			this.dataGridView4.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Color window4 = System.Drawing.SystemColors.Window;
			this.dataGridView4.BackgroundColor = window4;
			this.dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns4 = new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn4,
				this.dataGridViewTextBoxColumn6,
				this.dataGridViewTextBoxColumn8,
				this.dataGridViewTextBoxColumn9
			};
			this.dataGridView4.Columns.AddRange(dataGridViewColumns4);
			System.Drawing.Point location58 = new System.Drawing.Point(11, 110);
			this.dataGridView4.Location = location58;
			Padding margin58 = new Padding(2);
			this.dataGridView4.Margin = margin58;
			this.dataGridView4.MultiSelect = false;
			this.dataGridView4.Name = "dataGridView4";
			this.dataGridView4.RowHeadersVisible = false;
			this.dataGridView4.RowTemplate.Height = 27;
			this.dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size58 = new System.Drawing.Size(714, 262);
			this.dataGridView4.Size = size58;
			this.dataGridView4.TabIndex = 67;
			this.dataGridViewTextBoxColumn4.HeaderText = "序号";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.Width = 76;
			this.dataGridViewTextBoxColumn6.HeaderText = "起点针脚";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.Width = 200;
			this.dataGridViewTextBoxColumn8.HeaderText = "终点针脚";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.Width = 200;
			this.dataGridViewTextBoxColumn9.HeaderText = "测试值";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.Width = 200;
			this.btnStartProbeFWTest.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location59 = new System.Drawing.Point(580, 36);
			this.btnStartProbeFWTest.Location = location59;
			Padding margin59 = new Padding(2);
			this.btnStartProbeFWTest.Margin = margin59;
			this.btnStartProbeFWTest.Name = "btnStartProbeFWTest";
			System.Drawing.Size size59 = new System.Drawing.Size(90, 28);
			this.btnStartProbeFWTest.Size = size59;
			this.btnStartProbeFWTest.TabIndex = 66;
			this.btnStartProbeFWTest.Text = "启动测试";
			this.btnStartProbeFWTest.UseVisualStyleBackColor = true;
			this.btnStartProbeFWTest.Click += new System.EventHandler(this.btnStartProbeFWTest_Click);
			this.radioButton_Probe_FW.AutoSize = true;
			this.radioButton_Probe_FW.Checked = true;
			System.Drawing.Point location60 = new System.Drawing.Point(26, 22);
			this.radioButton_Probe_FW.Location = location60;
			Padding margin60 = new Padding(2);
			this.radioButton_Probe_FW.Margin = margin60;
			this.radioButton_Probe_FW.Name = "radioButton_Probe_FW";
			System.Drawing.Size size60 = new System.Drawing.Size(85, 19);
			this.radioButton_Probe_FW.Size = size60;
			this.radioButton_Probe_FW.TabIndex = 52;
			this.radioButton_Probe_FW.TabStop = true;
			this.radioButton_Probe_FW.Text = "范围方式";
			this.radioButton_Probe_FW.UseVisualStyleBackColor = true;
			this.label_Probe_StartPin.AutoSize = true;
			System.Drawing.Point location61 = new System.Drawing.Point(127, 23);
			this.label_Probe_StartPin.Location = location61;
			Padding margin61 = new Padding(2, 0, 2, 0);
			this.label_Probe_StartPin.Margin = margin61;
			this.label_Probe_StartPin.Name = "label_Probe_StartPin";
			System.Drawing.Size size61 = new System.Drawing.Size(75, 15);
			this.label_Probe_StartPin.Size = size61;
			this.label_Probe_StartPin.TabIndex = 54;
			this.label_Probe_StartPin.Text = "起始针脚:";
			System.Drawing.Point location62 = new System.Drawing.Point(209, 19);
			this.numericUpDown_Probe_StartPin.Location = location62;
			Padding margin62 = new Padding(2);
			this.numericUpDown_Probe_StartPin.Margin = margin62;
			decimal maximum12 = new decimal(new int[]
			{
				262144,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_StartPin.Maximum = maximum12;
			decimal minimum8 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_StartPin.Minimum = minimum8;
			this.numericUpDown_Probe_StartPin.Name = "numericUpDown_Probe_StartPin";
			System.Drawing.Size size62 = new System.Drawing.Size(90, 24);
			this.numericUpDown_Probe_StartPin.Size = size62;
			this.numericUpDown_Probe_StartPin.TabIndex = 56;
			this.numericUpDown_Probe_StartPin.TextAlign = HorizontalAlignment.Center;
			decimal value13 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_StartPin.Value = value13;
			System.Drawing.Point location63 = new System.Drawing.Point(407, 19);
			this.numericUpDown_Probe_StopPin.Location = location63;
			Padding margin63 = new Padding(2);
			this.numericUpDown_Probe_StopPin.Margin = margin63;
			decimal maximum13 = new decimal(new int[]
			{
				262144,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_StopPin.Maximum = maximum13;
			decimal minimum9 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_StopPin.Minimum = minimum9;
			this.numericUpDown_Probe_StopPin.Name = "numericUpDown_Probe_StopPin";
			System.Drawing.Size size63 = new System.Drawing.Size(90, 24);
			this.numericUpDown_Probe_StopPin.Size = size63;
			this.numericUpDown_Probe_StopPin.TabIndex = 55;
			this.numericUpDown_Probe_StopPin.TextAlign = HorizontalAlignment.Center;
			decimal value14 = new decimal(new int[]
			{
				64,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_StopPin.Value = value14;
			this.label_Probe_StopPin.AutoSize = true;
			System.Drawing.Point location64 = new System.Drawing.Point(326, 23);
			this.label_Probe_StopPin.Location = location64;
			Padding margin64 = new Padding(2, 0, 2, 0);
			this.label_Probe_StopPin.Margin = margin64;
			this.label_Probe_StopPin.Name = "label_Probe_StopPin";
			System.Drawing.Size size64 = new System.Drawing.Size(75, 15);
			this.label_Probe_StopPin.Size = size64;
			this.label_Probe_StopPin.TabIndex = 53;
			this.label_Probe_StopPin.Text = "终止针脚:";
			this.label_Probe_FW_DTYZ.AutoSize = true;
			System.Drawing.Point location65 = new System.Drawing.Point(127, 62);
			this.label_Probe_FW_DTYZ.Location = location65;
			Padding margin65 = new Padding(2, 0, 2, 0);
			this.label_Probe_FW_DTYZ.Margin = margin65;
			this.label_Probe_FW_DTYZ.Name = "label_Probe_FW_DTYZ";
			System.Drawing.Size size65 = new System.Drawing.Size(75, 15);
			this.label_Probe_FW_DTYZ.Size = size65;
			this.label_Probe_FW_DTYZ.TabIndex = 57;
			this.label_Probe_FW_DTYZ.Text = "导通阈值:";
			this.label_Probe_FW_DTYZ_unit.AutoSize = true;
			System.Drawing.Point location66 = new System.Drawing.Point(306, 62);
			this.label_Probe_FW_DTYZ_unit.Location = location66;
			Padding margin66 = new Padding(2, 0, 2, 0);
			this.label_Probe_FW_DTYZ_unit.Margin = margin66;
			this.label_Probe_FW_DTYZ_unit.Name = "label_Probe_FW_DTYZ_unit";
			System.Drawing.Size size66 = new System.Drawing.Size(22, 15);
			this.label_Probe_FW_DTYZ_unit.Size = size66;
			this.label_Probe_FW_DTYZ_unit.TabIndex = 59;
			this.label_Probe_FW_DTYZ_unit.Text = "Ω";
			System.Drawing.Point location67 = new System.Drawing.Point(209, 58);
			this.numericUpDown_Probe_FW_DTYZ.Location = location67;
			Padding margin67 = new Padding(2);
			this.numericUpDown_Probe_FW_DTYZ.Margin = margin67;
			decimal maximum14 = new decimal(new int[]
			{
				1000000,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_FW_DTYZ.Maximum = maximum14;
			this.numericUpDown_Probe_FW_DTYZ.Name = "numericUpDown_Probe_FW_DTYZ";
			System.Drawing.Size size67 = new System.Drawing.Size(90, 24);
			this.numericUpDown_Probe_FW_DTYZ.Size = size67;
			this.numericUpDown_Probe_FW_DTYZ.TabIndex = 58;
			this.numericUpDown_Probe_FW_DTYZ.TextAlign = HorizontalAlignment.Center;
			decimal value15 = new decimal(new int[]
			{
				1000,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_FW_DTYZ.Value = value15;
			this.tabPage7.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage7.Controls.Add(this.btnStartProbeJKTest);
			this.tabPage7.Controls.Add(this.dataGridView5);
			this.tabPage7.Controls.Add(this.radioButton_Probe_JK);
			this.tabPage7.Controls.Add(this.label_Probe_JK_DTYZ_unit);
			this.tabPage7.Controls.Add(this.label_Probe_JK);
			this.tabPage7.Controls.Add(this.numericUpDown_Probe_JK_DTYZ);
			this.tabPage7.Controls.Add(this.comboBox_Probe_JK);
			this.tabPage7.Controls.Add(this.label_Probe_JK_DTYZ);
			System.Drawing.Point location68 = new System.Drawing.Point(4, 34);
			this.tabPage7.Location = location68;
			Padding margin68 = new Padding(2);
			this.tabPage7.Margin = margin68;
			this.tabPage7.Name = "tabPage7";
			Padding padding8 = new Padding(2);
			this.tabPage7.Padding = padding8;
			System.Drawing.Size size68 = new System.Drawing.Size(736, 377);
			this.tabPage7.Size = size68;
			this.tabPage7.TabIndex = 1;
			this.tabPage7.Text = "接口方式寻址";
			this.tabPage7.UseVisualStyleBackColor = true;
			this.btnStartProbeJKTest.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location69 = new System.Drawing.Point(580, 36);
			this.btnStartProbeJKTest.Location = location69;
			Padding margin69 = new Padding(2);
			this.btnStartProbeJKTest.Margin = margin69;
			this.btnStartProbeJKTest.Name = "btnStartProbeJKTest";
			System.Drawing.Size size69 = new System.Drawing.Size(90, 28);
			this.btnStartProbeJKTest.Size = size69;
			this.btnStartProbeJKTest.TabIndex = 67;
			this.btnStartProbeJKTest.Text = "启动测试";
			this.btnStartProbeJKTest.UseVisualStyleBackColor = true;
			this.btnStartProbeJKTest.Click += new System.EventHandler(this.btnStartProbeJKTest_Click);
			this.dataGridView5.AllowUserToAddRows = false;
			this.dataGridView5.AllowUserToDeleteRows = false;
			this.dataGridView5.AllowUserToResizeColumns = false;
			this.dataGridView5.AllowUserToResizeRows = false;
			this.dataGridView5.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Color window5 = System.Drawing.SystemColors.Window;
			this.dataGridView5.BackgroundColor = window5;
			this.dataGridView5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns5 = new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn10,
				this.dataGridViewTextBoxColumn11,
				this.dataGridViewTextBoxColumn12,
				this.dataGridViewTextBoxColumn13,
				this.dataGridViewTextBoxColumn14
			};
			this.dataGridView5.Columns.AddRange(dataGridViewColumns5);
			System.Drawing.Point location70 = new System.Drawing.Point(11, 110);
			this.dataGridView5.Location = location70;
			Padding margin70 = new Padding(2);
			this.dataGridView5.Margin = margin70;
			this.dataGridView5.MultiSelect = false;
			this.dataGridView5.Name = "dataGridView5";
			this.dataGridView5.RowHeadersVisible = false;
			this.dataGridView5.RowTemplate.Height = 27;
			this.dataGridView5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size70 = new System.Drawing.Size(715, 223);
			this.dataGridView5.Size = size70;
			this.dataGridView5.TabIndex = 66;
			this.dataGridView5.CellMouseDown += new DataGridViewCellMouseEventHandler(this.dataGridView5_CellMouseDown);
			this.dataGridViewTextBoxColumn10.HeaderText = "序号";
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn10.Width = 76;
			this.dataGridViewTextBoxColumn11.HeaderText = "起点接口";
			this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn11.Width = 150;
			this.dataGridViewTextBoxColumn12.HeaderText = "起点接点";
			this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewTextBoxColumn12.Width = 150;
			this.dataGridViewTextBoxColumn13.HeaderText = "终点针脚";
			this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
			this.dataGridViewTextBoxColumn13.Width = 150;
			this.dataGridViewTextBoxColumn14.HeaderText = "测试值";
			this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
			this.dataGridViewTextBoxColumn14.Width = 150;
			this.radioButton_Probe_JK.AutoSize = true;
			this.radioButton_Probe_JK.Checked = true;
			System.Drawing.Point location71 = new System.Drawing.Point(26, 22);
			this.radioButton_Probe_JK.Location = location71;
			Padding margin71 = new Padding(2);
			this.radioButton_Probe_JK.Margin = margin71;
			this.radioButton_Probe_JK.Name = "radioButton_Probe_JK";
			System.Drawing.Size size71 = new System.Drawing.Size(85, 19);
			this.radioButton_Probe_JK.Size = size71;
			this.radioButton_Probe_JK.TabIndex = 52;
			this.radioButton_Probe_JK.TabStop = true;
			this.radioButton_Probe_JK.Text = "接口方式";
			this.radioButton_Probe_JK.UseVisualStyleBackColor = true;
			this.label_Probe_JK_DTYZ_unit.AutoSize = true;
			System.Drawing.Point location72 = new System.Drawing.Point(306, 62);
			this.label_Probe_JK_DTYZ_unit.Location = location72;
			Padding margin72 = new Padding(2, 0, 2, 0);
			this.label_Probe_JK_DTYZ_unit.Margin = margin72;
			this.label_Probe_JK_DTYZ_unit.Name = "label_Probe_JK_DTYZ_unit";
			System.Drawing.Size size72 = new System.Drawing.Size(22, 15);
			this.label_Probe_JK_DTYZ_unit.Size = size72;
			this.label_Probe_JK_DTYZ_unit.TabIndex = 64;
			this.label_Probe_JK_DTYZ_unit.Text = "Ω";
			this.label_Probe_JK.AutoSize = true;
			System.Drawing.Point location73 = new System.Drawing.Point(127, 23);
			this.label_Probe_JK.Location = location73;
			Padding margin73 = new Padding(2, 0, 2, 0);
			this.label_Probe_JK.Margin = margin73;
			this.label_Probe_JK.Name = "label_Probe_JK";
			System.Drawing.Size size73 = new System.Drawing.Size(75, 15);
			this.label_Probe_JK.Size = size73;
			this.label_Probe_JK.TabIndex = 60;
			this.label_Probe_JK.Text = "测试接口:";
			System.Drawing.Point location74 = new System.Drawing.Point(209, 58);
			this.numericUpDown_Probe_JK_DTYZ.Location = location74;
			Padding margin74 = new Padding(2);
			this.numericUpDown_Probe_JK_DTYZ.Margin = margin74;
			decimal maximum15 = new decimal(new int[]
			{
				1000000,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_JK_DTYZ.Maximum = maximum15;
			this.numericUpDown_Probe_JK_DTYZ.Name = "numericUpDown_Probe_JK_DTYZ";
			System.Drawing.Size size74 = new System.Drawing.Size(90, 24);
			this.numericUpDown_Probe_JK_DTYZ.Size = size74;
			this.numericUpDown_Probe_JK_DTYZ.TabIndex = 63;
			this.numericUpDown_Probe_JK_DTYZ.TextAlign = HorizontalAlignment.Center;
			decimal value16 = new decimal(new int[]
			{
				1000,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_JK_DTYZ.Value = value16;
			this.comboBox_Probe_JK.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_Probe_JK.FormattingEnabled = true;
			System.Drawing.Point location75 = new System.Drawing.Point(209, 20);
			this.comboBox_Probe_JK.Location = location75;
			Padding margin75 = new Padding(2);
			this.comboBox_Probe_JK.Margin = margin75;
			this.comboBox_Probe_JK.Name = "comboBox_Probe_JK";
			System.Drawing.Size size75 = new System.Drawing.Size(289, 22);
			this.comboBox_Probe_JK.Size = size75;
			this.comboBox_Probe_JK.TabIndex = 61;
			this.label_Probe_JK_DTYZ.AutoSize = true;
			System.Drawing.Point location76 = new System.Drawing.Point(127, 62);
			this.label_Probe_JK_DTYZ.Location = location76;
			Padding margin76 = new Padding(2, 0, 2, 0);
			this.label_Probe_JK_DTYZ.Margin = margin76;
			this.label_Probe_JK_DTYZ.Name = "label_Probe_JK_DTYZ";
			System.Drawing.Size size76 = new System.Drawing.Size(75, 15);
			this.label_Probe_JK_DTYZ.Size = size76;
			this.label_Probe_JK_DTYZ.TabIndex = 62;
			this.label_Probe_JK_DTYZ.Text = "导通阈值:";
			this.tabPage8.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage8.Controls.Add(this.numericUpDown_DTSDTest_StopPin);
			this.tabPage8.Controls.Add(this.numericUpDown_DTSDTest_StartPin);
			this.tabPage8.Controls.Add(this.label1);
			this.tabPage8.Controls.Add(this.label2);
			this.tabPage8.Controls.Add(this.btnDTSDTest);
			this.tabPage8.Controls.Add(this.label_ZXXSJ);
			this.tabPage8.Controls.Add(this.label_xxsj);
			System.Drawing.Point location77 = new System.Drawing.Point(4, 34);
			this.tabPage8.Location = location77;
			this.tabPage8.Name = "tabPage8";
			Padding padding9 = new Padding(3);
			this.tabPage8.Padding = padding9;
			System.Drawing.Size size77 = new System.Drawing.Size(764, 465);
			this.tabPage8.Size = size77;
			this.tabPage8.TabIndex = 3;
			this.tabPage8.Tag = "";
			this.tabPage8.Text = "导通速度测试";
			this.tabPage8.UseVisualStyleBackColor = true;
			System.Drawing.Point location78 = new System.Drawing.Point(474, 51);
			this.numericUpDown_DTSDTest_StopPin.Location = location78;
			Padding margin77 = new Padding(2);
			this.numericUpDown_DTSDTest_StopPin.Margin = margin77;
			decimal maximum16 = new decimal(new int[]
			{
				262144,
				0,
				0,
				0
			});
			this.numericUpDown_DTSDTest_StopPin.Maximum = maximum16;
			decimal minimum10 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_DTSDTest_StopPin.Minimum = minimum10;
			this.numericUpDown_DTSDTest_StopPin.Name = "numericUpDown_DTSDTest_StopPin";
			System.Drawing.Size size78 = new System.Drawing.Size(75, 24);
			this.numericUpDown_DTSDTest_StopPin.Size = size78;
			this.numericUpDown_DTSDTest_StopPin.TabIndex = 28;
			this.numericUpDown_DTSDTest_StopPin.TextAlign = HorizontalAlignment.Center;
			decimal value17 = new decimal(new int[]
			{
				64,
				0,
				0,
				0
			});
			this.numericUpDown_DTSDTest_StopPin.Value = value17;
			System.Drawing.Point location79 = new System.Drawing.Point(293, 51);
			this.numericUpDown_DTSDTest_StartPin.Location = location79;
			Padding margin78 = new Padding(2);
			this.numericUpDown_DTSDTest_StartPin.Margin = margin78;
			decimal maximum17 = new decimal(new int[]
			{
				262144,
				0,
				0,
				0
			});
			this.numericUpDown_DTSDTest_StartPin.Maximum = maximum17;
			decimal minimum11 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_DTSDTest_StartPin.Minimum = minimum11;
			this.numericUpDown_DTSDTest_StartPin.Name = "numericUpDown_DTSDTest_StartPin";
			System.Drawing.Size size79 = new System.Drawing.Size(75, 24);
			this.numericUpDown_DTSDTest_StartPin.Size = size79;
			this.numericUpDown_DTSDTest_StartPin.TabIndex = 29;
			this.numericUpDown_DTSDTest_StartPin.TextAlign = HorizontalAlignment.Center;
			decimal value18 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_DTSDTest_StartPin.Value = value18;
			this.label1.AutoSize = true;
			System.Drawing.Point location80 = new System.Drawing.Point(395, 56);
			this.label1.Location = location80;
			Padding margin79 = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin79;
			this.label1.Name = "label1";
			System.Drawing.Size size80 = new System.Drawing.Size(75, 15);
			this.label1.Size = size80;
			this.label1.TabIndex = 26;
			this.label1.Text = "终点针脚:";
			this.label2.AutoSize = true;
			System.Drawing.Point location81 = new System.Drawing.Point(214, 56);
			this.label2.Location = location81;
			Padding margin80 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin80;
			this.label2.Name = "label2";
			System.Drawing.Size size81 = new System.Drawing.Size(75, 15);
			this.label2.Size = size81;
			this.label2.TabIndex = 27;
			this.label2.Text = "起点针脚:";
			this.btnDTSDTest.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location82 = new System.Drawing.Point(336, 217);
			this.btnDTSDTest.Location = location82;
			Padding margin81 = new Padding(2);
			this.btnDTSDTest.Margin = margin81;
			this.btnDTSDTest.Name = "btnDTSDTest";
			System.Drawing.Size size82 = new System.Drawing.Size(90, 28);
			this.btnDTSDTest.Size = size82;
			this.btnDTSDTest.TabIndex = 25;
			this.btnDTSDTest.Text = "开始测试";
			this.btnDTSDTest.UseVisualStyleBackColor = true;
			this.btnDTSDTest.Click += new System.EventHandler(this.btnDTSDTest_Click);
			this.label_ZXXSJ.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.label_ZXXSJ.AutoSize = true;
			this.label_ZXXSJ.Font = new System.Drawing.Font("宋体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location83 = new System.Drawing.Point(394, 119);
			this.label_ZXXSJ.Location = location83;
			this.label_ZXXSJ.Name = "label_ZXXSJ";
			System.Drawing.Size size83 = new System.Drawing.Size(35, 14);
			this.label_ZXXSJ.Size = size83;
			this.label_ZXXSJ.TabIndex = 24;
			this.label_ZXXSJ.Text = "0.0s";
			this.label_xxsj.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.label_xxsj.Font = new System.Drawing.Font("宋体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location84 = new System.Drawing.Point(221, 119);
			this.label_xxsj.Location = location84;
			this.label_xxsj.Name = "label_xxsj";
			System.Drawing.Size size84 = new System.Drawing.Size(160, 14);
			this.label_xxsj.Size = size84;
			this.label_xxsj.TabIndex = 23;
			this.label_xxsj.Text = "测试时间:";
			this.label_xxsj.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.progressBar1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Color green = System.Drawing.Color.Green;
			this.progressBar1.ForeColor = green;
			System.Drawing.Point location85 = new System.Drawing.Point(10, 539);
			this.progressBar1.Location = location85;
			Padding margin82 = new Padding(2);
			this.progressBar1.Margin = margin82;
			this.progressBar1.Name = "progressBar1";
			System.Drawing.Size size85 = new System.Drawing.Size(723, 19);
			this.progressBar1.Size = size85;
			this.progressBar1.TabIndex = 3;
			this.label_progress.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			System.Drawing.Point location86 = new System.Drawing.Point(745, 540);
			this.label_progress.Location = location86;
			Padding margin83 = new Padding(2, 0, 2, 0);
			this.label_progress.Margin = margin83;
			this.label_progress.Name = "label_progress";
			System.Drawing.Size size86 = new System.Drawing.Size(38, 18);
			this.label_progress.Size = size86;
			this.label_progress.TabIndex = 4;
			this.label_progress.Text = "0 %";
			this.label_progress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			this.timer_updatePro.Interval = 1000;
			this.timer_updatePro.Tick += new System.EventHandler(this.timer_updatePro_Tick);
			this.timer_SingleTest.Interval = 1000;
			this.timer_SingleTest.Tick += new System.EventHandler(this.timer_SingleTest_Tick);
			this.timer_ProbeTest.Interval = 1000;
			this.timer_ProbeTest.Tick += new System.EventHandler(this.timer_ProbeTest_Tick);
			this.contextMenuStrip_DataProc.Font = new System.Drawing.Font("宋体", 10.8f);
			ToolStripItem[] toolStripItems = new ToolStripItem[]
			{
				this.toolStripMenuItem_ClearData,
				this.toolStripSeparator1,
				this.toolStripMenuItem_ExportData
			};
			this.contextMenuStrip_DataProc.Items.AddRange(toolStripItems);
			this.contextMenuStrip_DataProc.Name = "contextMenuStrip1";
			System.Drawing.Size size87 = new System.Drawing.Size(165, 54);
			this.contextMenuStrip_DataProc.Size = size87;
			this.toolStripMenuItem_ClearData.Name = "toolStripMenuItem_ClearData";
			System.Drawing.Size size88 = new System.Drawing.Size(164, 22);
			this.toolStripMenuItem_ClearData.Size = size88;
			this.toolStripMenuItem_ClearData.Text = "清除表格数据";
			this.toolStripMenuItem_ClearData.Click += new System.EventHandler(this.toolStripMenuItem_ClearData_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			System.Drawing.Size size89 = new System.Drawing.Size(161, 6);
			this.toolStripSeparator1.Size = size89;
			this.toolStripMenuItem_ExportData.Name = "toolStripMenuItem_ExportData";
			System.Drawing.Size size90 = new System.Drawing.Size(164, 22);
			this.toolStripMenuItem_ExportData.Size = size90;
			this.toolStripMenuItem_ExportData.Text = "导出表格数据";
			this.toolStripMenuItem_ExportData.Click += new System.EventHandler(this.toolStripMenuItem_ExportData_Click);
			this.timerProbeJK.Interval = 1000;
			this.timerProbeJK.Tick += new System.EventHandler(this.timerProbeJK_Tick);
			this.timerProbeFW.Interval = 1000;
			this.timerProbeFW.Tick += new System.EventHandler(this.timerProbeFW_Tick);
			this.timerWait.Interval = 1000;
			this.timerWait.Tick += new System.EventHandler(this.timerWait_Tick);
			this.timerZXXWait.Tick += new System.EventHandler(this.timerZXXWait_Tick);
			this.timerXXSJ.Tick += new System.EventHandler(this.timerXXSJ_Tick);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.label_progress);
			base.Controls.Add(this.progressBar1);
			base.Controls.Add(this.groupBox_Debugging);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin84 = new Padding(2);
			base.Margin = margin84;
			base.Name = "ctFormDeviceDebugging";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "设备调试助手";
			base.FormClosing += new FormClosingEventHandler(this.ctFormDeviceDebugging_FormClosing);
			base.Load += new System.EventHandler(this.ctFormDeviceDebugging_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormDeviceDebugging_SizeChanged);
			this.groupBox_Debugging.ResumeLayout(false);
			this.tabControl_Debugging.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((ISupportInitialize)this.numericUpDown_SelfStudy_DTYZ).EndInit();
			((ISupportInitialize)this.numericUpDown_SelfStudy_StopPin).EndInit();
			((ISupportInitialize)this.numericUpDown_SelfStudy_StartPin).EndInit();
			((ISupportInitialize)this.dataGridView1).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((ISupportInitialize)this.numericUpDown_DT_Current).EndInit();
			((ISupportInitialize)this.numericUpDown_DT_Volt).EndInit();
			((ISupportInitialize)this.numericUpDown_SingleTest_TestNum).EndInit();
			((ISupportInitialize)this.numericUpDown_SingleTest_StopPin).EndInit();
			((ISupportInitialize)this.numericUpDown_SingleTest_StartPin).EndInit();
			((ISupportInitialize)this.numericUpDown_testvolt).EndInit();
			((ISupportInitialize)this.numericUpDown_testtime).EndInit();
			((ISupportInitialize)this.numericUpDown_JGSJ).EndInit();
			((ISupportInitialize)this.numericUpDown_DTBC).EndInit();
			((ISupportInitialize)this.dataGridView2).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			((ISupportInitialize)this.dataGridView3).EndInit();
			((ISupportInitialize)this.numericUpDown_Probe_Pin).EndInit();
			this.tabPage5.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.tabPage6.PerformLayout();
			((ISupportInitialize)this.dataGridView4).EndInit();
			((ISupportInitialize)this.numericUpDown_Probe_StartPin).EndInit();
			((ISupportInitialize)this.numericUpDown_Probe_StopPin).EndInit();
			((ISupportInitialize)this.numericUpDown_Probe_FW_DTYZ).EndInit();
			this.tabPage7.ResumeLayout(false);
			this.tabPage7.PerformLayout();
			((ISupportInitialize)this.dataGridView5).EndInit();
			((ISupportInitialize)this.numericUpDown_Probe_JK_DTYZ).EndInit();
			this.tabPage8.ResumeLayout(false);
			this.tabPage8.PerformLayout();
			((ISupportInitialize)this.numericUpDown_DTSDTest_StopPin).EndInit();
			((ISupportInitialize)this.numericUpDown_DTSDTest_StartPin).EndInit();
			this.contextMenuStrip_DataProc.ResumeLayout(false);
			base.ResumeLayout(false);
		}
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			try
			{
				int num = this.iTestTime + 1;
				this.iTestTime = num;
				KParseRepCmd e2 = this.gLineTestProcessor.mpDevComm.mParseCmd;
				if (e2.selfStudyProgress != 100)
				{
					int iProc = System.Convert.ToInt32((double)num * 100.0 / ((double)e2.selfStudyCount / 3600.0));
					if (iProc >= 100)
					{
						iProc = 99;
					}
					else if (iProc == 0)
					{
						iProc = 1;
					}
					this.progressBar1.Value = iProc;
				}
				else
				{
					this.timer_updatePro.Enabled = false;
					this.progressBar1.Value = 100;
					this.label_progress.Text = "100 %";
					this.gLineTestProcessor.mbKeepRun = false;
					this.timer1.Enabled = false;
					this.timerXXSJ.Enabled = false;
					this.bSelfStudyFlag = false;
					this.btnOnOffStudy.Text = "开始学习";
					this.progressBar1.Value = this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyProgress;
					this.gLineTestProcessor.SendStopCmd();
					System.Threading.Thread.Sleep(100);
					if (this.bDTSDTestFlag)
					{
						this.bDTSDTestFlag = false;
						this.btnDTSDTest.Text = "开始测试";
						MessageBox.Show("测试完成!", "提示", MessageBoxButtons.OK);
					}
				}
				if (this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyPinNum > 0)
				{
					int iRowCount = this.dataGridView1.Rows.Count;
					int iSSPN = this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyPinNum;
					if (iSSPN >= iRowCount && this.bSelfStudyFlag)
					{
						this.dataGridView1.AllowUserToAddRows = true;
						for (int i = iRowCount; i < iSSPN; i++)
						{
							e2 = this.gLineTestProcessor.mpDevComm.mParseCmd;
							int num2 = e2.firstPinArray[i];
							if (num2 != 0 && e2.secondPinArray[i] != 0)
							{
								string temp1Str = System.Convert.ToString(num2);
								string temp2Str = System.Convert.ToString(this.gLineTestProcessor.mpDevComm.mParseCmd.secondPinArray[i]);
								this.dataGridView1.Rows.Add(1);
								this.dataGridView1.Rows[i].Cells[0].Value = System.Convert.ToString(i + 1);
								this.dataGridView1.Rows[i].Cells[1].Value = temp1Str;
								this.dataGridView1.Rows[i].Cells[2].Value = temp2Str;
							}
						}
						this.dataGridView1.AllowUserToAddRows = false;
						int iLastIndex = this.dataGridView1.Rows.Count - 1;
						this.dataGridView1.Rows[iLastIndex].Selected = false;
					}
				}
			}
			catch (System.Exception arg_2E7_0)
			{
				this.gLineTestProcessor.mbKeepRun = false;
				this.dataGridView1.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_2E7_0.StackTrace);
			}
		}
		private void btnOnOffStudy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.bSingleTestFlag && !this.bDTSDTestFlag)
				{
					if (!this.gLineTestProcessor.bIsConnSuccFlag)
					{
						MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						if (this.bSelfStudyFlag)
						{
							if (DialogResult.OK == MessageBox.Show("正在进行自学习，您确定要停止吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
							{
								this.timer_updatePro.Enabled = false;
								this.progressBar1.Value = 100;
								this.label_progress.Text = "100 %";
								this.bSelfStudyFlag = false;
								this.btnOnOffStudy.Text = "开始学习";
								this.timer1.Enabled = false;
								this.gLineTestProcessor.mbKeepRun = false;
								for (int i = 0; i < 2; i++)
								{
									this.gLineTestProcessor.SendStopCmd();
									System.Threading.Thread.Sleep(300);
								}
							}
						}
						else
						{
							int iStart = System.Convert.ToInt32(this.numericUpDown_SelfStudy_StartPin.Text.ToString());
							int iEnd = System.Convert.ToInt32(this.numericUpDown_SelfStudy_StopPin.Text.ToString());
							if (iStart < iEnd)
							{
								int sELF_MAX_COUNT = this.gLineTestProcessor.SELF_MAX_COUNT;
								if (iStart <= sELF_MAX_COUNT && iEnd <= sELF_MAX_COUNT)
								{
									this.timer_updatePro.Enabled = true;
									this.progressBar1.Value = 0;
									this.label_progress.Text = "0 %";
									this.gLineTestProcessor.SendStopCmd();
									System.Threading.Thread.Sleep(500);
									this.gLineTestProcessor.iTwoFourWireChoice = 2;
									if (this.checkBox_SelfStudy_FourWire.Checked)
									{
										this.gLineTestProcessor.iTwoFourWireChoice = 4;
									}
									int iDTLValue = System.Convert.ToInt32(this.numericUpDown_SelfStudy_DTYZ.Text.ToString());
									this.iStartValue = iStart;
									this.iEndValue = iEnd;
									this.iDTLimitedValue = iDTLValue;
									int iTemp = System.Math.Abs(iEnd - iStart + 1);
									KParseRepCmd arg_1D6_0 = this.gLineTestProcessor.mpDevComm.mParseCmd;
									int expr_1D4 = iTemp;
									arg_1D6_0.selfStudyCount = expr_1D4 * expr_1D4;
									this.iTestTime = 0;
									this.bSelfStudyFlag = true;
									this.btnOnOffStudy.Text = "停止学习";
									this.dataGridView1.Rows.Clear();
									this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyMainPinCount = 0;
									this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyPinNum = 0;
									this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyProgress = 0;
									this.timer1.Enabled = true;
									this.gLineTestProcessor.mbKeepRun = true;
									this.timerZXXWait.Enabled = true;
									goto IL_26F;
								}
							}
							MessageBox.Show("参数范围设置错误，只能设置在1至" + System.Convert.ToInt32(this.gLineTestProcessor.SELF_MAX_COUNT) + "范围内，并且后者大于前者!", "提示", MessageBoxButtons.OK);
						}
						IL_26F:;
					}
				}
			}
			catch (System.Exception arg_2AA_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2AA_0.StackTrace);
			}
		}
		private void timer_updatePro_Tick(object sender, System.EventArgs e)
		{
			try
			{
				int iPro = System.Convert.ToInt32(this.progressBar1.Value);
				if (iPro > 100)
				{
					iPro = 100;
				}
				this.label_progress.Text = System.Convert.ToString(iPro) + " %";
			}
			catch (System.Exception arg_36_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_36_0.StackTrace);
			}
		}
		public void AddComboBoxProbeJKFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.comboBox_Probe_JK.Items.Clear();
				int inum = 0;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select * from TPlugLibrary order by PlugNo", connection).ExecuteReader();
					while (dataReader.Read())
					{
						this.strIDArray[inum] = dataReader["PID"].ToString();
						string tempStr = dataReader["PlugNo"].ToString() + ";";
						tempStr += dataReader["PinNum"].ToString() + "pin";
						this.comboBox_Probe_JK.Items.Add(tempStr);
						inum++;
						if (inum >= 5000)
						{
							break;
						}
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_DB_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_DB_0.StackTrace);
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
			catch (System.Exception arg_FF_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_FF_0.StackTrace);
			}
		}
		private void ctFormDeviceDebugging_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.timer_updatePro.Enabled = false;
				this.progressBar1.Value = 0;
				this.label_progress.Text = "0 %";
				this.bSelfStudyFlag = false;
				this.bSingleTestFlag = false;
				this.bProbeTestFlag = false;
				this.bCloseFlag = false;
				this.iDTSelfStudyTime = 0;
				this.dataGridView1.Rows.Clear();
				this.dataGridView2.Rows.Clear();
				this.dataGridView3.Rows.Clear();
				for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
				{
					this.dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					this.dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
				{
					this.dataGridView1.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				for (int k = 0; k < this.dataGridView2.Columns.Count; k++)
				{
					this.dataGridView2.Columns[k].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					this.dataGridView2.Columns[k].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				for (int l = 0; l < this.dataGridView2.Columns.Count; l++)
				{
					this.dataGridView2.Columns[l].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				for (int m = 0; m < this.dataGridView3.Columns.Count; m++)
				{
					this.dataGridView3.Columns[m].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					this.dataGridView3.Columns[m].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				for (int n = 0; n < this.dataGridView3.Columns.Count; n++)
				{
					this.dataGridView3.Columns[n].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				for (int j2 = 0; j2 < this.dataGridView4.Columns.Count; j2++)
				{
					this.dataGridView4.Columns[j2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					this.dataGridView4.Columns[j2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				for (int k2 = 0; k2 < this.dataGridView4.Columns.Count; k2++)
				{
					this.dataGridView4.Columns[k2].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				for (int j3 = 0; j3 < this.dataGridView5.Columns.Count; j3++)
				{
					this.dataGridView5.Columns[j3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					this.dataGridView5.Columns[j3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				for (int k3 = 0; k3 < this.dataGridView5.Columns.Count; k3++)
				{
					this.dataGridView5.Columns[k3].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
			}
			catch (System.Exception arg_358_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_358_0.StackTrace);
			}
			this.ControlVisibleSetFunc();
			this.AddComboBoxProbeJKFunc();
			try
			{
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				if (!kLineTestProcessor.bJYTestEnabled && !kLineTestProcessor.bDDJYTestEnabled)
				{
					this.radioButton_JYTest.Visible = false;
					this.checkBox_JYTest_LV.Visible = false;
				}
				else
				{
					this.radioButton_JYTest.Visible = true;
					this.checkBox_JYTest_LV.Visible = true;
				}
				this.radioButton_NYTest.Visible = this.gLineTestProcessor.bNYTestEnabled;
				if (this.gLineTestProcessor.iUIDisplayMode == 0)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
			catch (System.Exception arg_3E8_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3E8_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool GetTestParaFunc()
		{
			try
			{
				int iStart = System.Convert.ToInt32(this.numericUpDown_SingleTest_StartPin.Value);
				int iEnd = System.Convert.ToInt32(this.numericUpDown_SingleTest_StopPin.Value);
				int this2 = this.gLineTestProcessor.SELF_MAX_COUNT;
				if (iStart > this2 || iEnd > this2)
				{
					MessageBox.Show("参数范围设置错误，只能设置在1至" + System.Convert.ToInt32(this2) + "范围内!", "提示", MessageBoxButtons.OK);
					byte result = 0;
					return result != 0;
				}
				if (iStart == iEnd)
				{
					MessageBox.Show("起点和终点针脚号不能相同!", "提示", MessageBoxButtons.OK);
					byte result = 0;
					return result != 0;
				}
				int iTestNum = System.Convert.ToInt32(this.numericUpDown_SingleTest_TestNum.Value);
				double dDTBCValue = System.Convert.ToDouble(this.numericUpDown_DTBC.Value);
				double dJGSJValue = System.Convert.ToDouble(this.numericUpDown_JGSJ.Value);
				double dDTVoltValue = System.Convert.ToDouble(this.numericUpDown_DT_Volt.Value);
				double dDTCurrValue = System.Convert.ToDouble(this.numericUpDown_DT_Current.Value);
				if (this.radioButton_DTTest.Checked)
				{
					this.testtype = 5;
				}
				else if (this.radioButton_JYTest.Checked)
				{
					this.testtype = 7;
				}
				else if (this.radioButton_NYTest.Checked)
				{
					this.testtype = 9;
				}
				this.testcount = iTestNum;
				int num = System.Convert.ToInt32(this.numericUpDown_testtime.Value);
				this.testtime = num;
				if (num <= 1)
				{
					this.testtime = 1;
				}
				decimal value = this.numericUpDown_testvolt.Value;
				this.testvolt = System.Convert.ToInt32(value);
				this.dev1 = 0;
				this.dev2 = 0;
				this.port1 = iStart;
				this.port2 = iEnd;
				this.currcount = 0;
				this.dtoffset = dDTBCValue;
				this.mtimetick = dJGSJValue;
				this.ddtvolt = dDTVoltValue;
				this.ddtcurr = dDTCurrValue;
				this.gLineTestProcessor.dev1 = 0;
				this.gLineTestProcessor.dev2 = this.dev2;
				this.gLineTestProcessor.port1 = this.port1;
				this.gLineTestProcessor.port2 = this.port2;
				this.gLineTestProcessor.testtype = this.testtype;
				this.gLineTestProcessor.testcount = this.testcount;
				this.gLineTestProcessor.testtime = this.testtime;
				this.gLineTestProcessor.testvolt = this.testvolt;
				this.gLineTestProcessor.currcount = this.currcount;
				this.gLineTestProcessor.dtoffset = this.dtoffset;
				this.gLineTestProcessor.mtimetick = this.mtimetick;
				this.gLineTestProcessor.ddtvolt = this.ddtvolt;
				this.gLineTestProcessor.ddtcurr = this.ddtcurr;
			}
			catch (System.Exception arg_286_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_286_0.StackTrace);
			}
			return true;
		}
		private void StartTest()
		{
			try
			{
				this.gLineTestProcessor.mbKeepRun = true;
				this.timer_updatePro.Enabled = true;
				this.progressBar1.Value = 0;
				this.label_progress.Text = "0 %";
				this.gLineTestProcessor.mpDevComm.ClearTestCmdBuf();
				this.gLineTestProcessor.bIsTimeOut = false;
				if (this.testtype == 5)
				{
					if (!this.bProbeTestFlag && this.checkBox_DTTest_FourWire.Checked)
					{
						this.testtype = 6;
					}
					this.gLineTestProcessor.ddtcurr = 2000.0;
					this.gLineTestProcessor.ddtvolt = 2.5;
				}
				int num = this.testtype;
				if (num != 7 && num != 9)
				{
					KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
					KLineTestProcessor expr_BA = kLineTestProcessor;
					expr_BA.SendDTVlotAndCurrentCmd(expr_BA.ddtvolt * 100.0, kLineTestProcessor.ddtcurr);
				}
				else
				{
					this.gLineTestProcessor.DownJYNYTime();
					System.Threading.Thread.Sleep(200);
					if (this.testtype == 7 && this.checkBox_JYTest_LV.Checked)
					{
						KLineTestProcessor expr_109 = this.gLineTestProcessor;
						expr_109.SendDTVlotAndCurrentCmd((double)(expr_109.testvolt * 100), 2000.0);
					}
					else
					{
						this.gLineTestProcessor.DownJYNYVolt();
					}
				}
				System.Threading.Thread.Sleep(200);
				int iCount = 1;
				int num2 = this.testtype;
				if (num2 != 5 && num2 != 6)
				{
					this.timer_SingleTest.Interval = 1000;
				}
				else
				{
					iCount = this.testcount;
					this.timer_SingleTest.Interval = 150;
				}
				if (this.bProbeTestFlag)
				{
					for (int i = 0; i < iCount; i++)
					{
						this.gLineTestProcessor.DownLoadTestShip(this.testtype, this.dev1, this.dev2, this.port1, this.port2);
						System.Threading.Thread.Sleep(10);
					}
				}
				else if (this.bProbeFWTestFlag)
				{
					for (int j = this.iStartValue; j <= this.iEndValue; j++)
					{
						this.gLineTestProcessor.DownLoadTestShip(this.testtype, this.dev1, this.dev2, j, this.port2);
						System.Threading.Thread.Sleep(2);
					}
					this.testcount = 1 - this.iStartValue + this.iEndValue;
				}
				else if (this.bProbeJKTestFlag)
				{
					this.testcount = this.gLineTestProcessor.iPort1Array.Count;
					for (int k = 0; k < this.gLineTestProcessor.iPort1Array.Count; k++)
					{
						this.gLineTestProcessor.DownLoadTestShip(this.testtype, this.dev1, this.dev2, this.gLineTestProcessor.iPort1Array[k], this.port2);
						System.Threading.Thread.Sleep(2);
					}
				}
				else
				{
					for (int l = 0; l < iCount; l++)
					{
						this.gLineTestProcessor.DownLoadTestShip(this.testtype, this.dev1, this.dev2, this.port1, this.port2);
						System.Threading.Thread.Sleep(10);
					}
				}
				System.Threading.Thread.Sleep(100);
				this.gLineTestProcessor.mpDevComm.mParseCmd.mnDownCmdCount = 1;
				this.gLineTestProcessor.mpDevComm.mnDownCmdCount = 1;
				if (!this.bProbeFWTestFlag && !this.bProbeJKTestFlag)
				{
					this.gLineTestProcessor.DownTestCmd();
				}
				else
				{
					this.gLineTestProcessor.DownTestCmdTZXZ();
				}
				int num3 = this.currcount + 1;
				this.currcount = num3;
				this.gLineTestProcessor.currcount = num3;
			}
			catch (System.Exception arg_34B_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_34B_0.StackTrace);
			}
		}
		private void TestFinishedFunc()
		{
			try
			{
				this.gLineTestProcessor.mbKeepRun = false;
				this.timer_updatePro.Enabled = false;
				this.progressBar1.Value = 100;
				this.label_progress.Text = "100 %";
				this.bSingleTestFlag = false;
				this.bSelfStudyFlag = false;
				this.bDTSDTestFlag = false;
				this.timer_SingleTest.Enabled = false;
				this.btnStartTest.Text = "开始测试";
				this.btnDTSDTest.Text = "开始测试";
				this.gLineTestProcessor.SendStopCmd();
				System.Threading.Thread.Sleep(200);
			}
			catch (System.Exception arg_8D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_8D_0.StackTrace);
			}
		}
		private void btnStartTest_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.bSelfStudyFlag && !this.bDTSDTestFlag)
				{
					if (!this.gLineTestProcessor.bIsConnSuccFlag)
					{
						MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
					}
					else if (this.bSingleTestFlag)
					{
						if (DialogResult.OK == MessageBox.Show("正在进行测试，您确定要停止吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
						{
							this.TestFinishedFunc();
						}
					}
					else if (this.GetTestParaFunc())
					{
						this.gLineTestProcessor.iTwoFourWireChoice = 2;
						if (this.checkBox_DTTest_FourWire.Checked)
						{
							this.gLineTestProcessor.iTwoFourWireChoice = 4;
						}
						this.gLineTestProcessor.SendStopCmd();
						this.iAddedCount = 0;
						this.bSingleTestFlag = true;
						this.timer_SingleTest.Enabled = true;
						this.btnStartTest.Text = "停止测试";
						this.dataGridView2.Rows.Clear();
						this.timerWait.Enabled = true;
					}
				}
			}
			catch (System.Exception arg_ED_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_ED_0.StackTrace);
			}
		}
		public string AddRrecStrFunc(string valueStr, int iPrec)
		{
			string tempStr = valueStr;
			try
			{
				int iTemp = valueStr.LastIndexOf('.');
				if (iTemp == -1)
				{
					tempStr = valueStr + ".";
					for (int i = 0; i < iPrec; i++)
					{
						tempStr += "0";
					}
				}
				else
				{
					while (iTemp + iPrec + 1 > tempStr.Length)
					{
						tempStr += "0";
						iTemp = tempStr.LastIndexOf('.');
					}
				}
			}
			catch (System.Exception arg_5B_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5B_0.StackTrace);
			}
			return tempStr;
		}
		public string GetDZStr(double data, int type)
		{
			string srV = "";
			try
			{
				if (type == 7)
				{
					data = System.Math.Abs(data * 1000.0);
				}
				if (data < 1000.0)
				{
					string tempStr = System.Convert.ToString(System.Math.Round(data, 3));
					srV = this.AddRrecStrFunc(tempStr, 3) + " Ω";
				}
				else if (data < 1000000.0)
				{
					string tempStr = System.Convert.ToString(System.Math.Round(data / 1000.0, 3));
					srV = this.AddRrecStrFunc(tempStr, 3) + " KΩ";
				}
				else if (data < 1000000000.0)
				{
					string tempStr = System.Convert.ToString(System.Math.Round(data / 1000.0 / 1000.0, 3));
					srV = this.AddRrecStrFunc(tempStr, 3) + " MΩ";
				}
				else
				{
					double type2 = data / 1000.0;
					if (type2 < 5100000.0)
					{
						string tempStr = System.Convert.ToString(System.Math.Round(type2 / 1000.0 / 1000.0, 3));
						srV = this.AddRrecStrFunc(tempStr, 3) + " GΩ";
					}
					else
					{
						string tempStr = System.Convert.ToString(System.Math.Round(type2 / 1000.0 / 1000.0, 3));
						srV = this.AddRrecStrFunc(tempStr, 3) + " GΩ";
					}
				}
			}
			catch (System.Exception arg_153_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_153_0.StackTrace);
			}
			return srV;
		}
		public string GetDLStr(double data, int type)
		{
			string srV = "";
			try
			{
				if (type == 9)
				{
					data = System.Math.Abs(data);
					if (data < 1000.0)
					{
						string tempStr = System.Convert.ToString(System.Math.Round(data, 3));
						srV = this.AddRrecStrFunc(tempStr, 3) + " nA";
					}
					else if (data < 1000000.0)
					{
						string tempStr = System.Convert.ToString(System.Math.Round(data / 1000.0, 3));
						srV = this.AddRrecStrFunc(tempStr, 3) + " uA";
					}
					else if (data < 1000000000.0)
					{
						string tempStr = System.Convert.ToString(System.Math.Round(data / 1000.0 / 1000.0, 3));
						srV = this.AddRrecStrFunc(tempStr, 3) + " mA";
					}
					else
					{
						string tempStr = System.Convert.ToString(System.Math.Round(data / 1000.0 / 1000.0 / 1000.0, 3));
						srV = this.AddRrecStrFunc(tempStr, 3) + " A";
					}
				}
			}
			catch (System.Exception arg_104_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_104_0.StackTrace);
			}
			return srV;
		}
		private void timer_SingleTest_Tick(object sender, System.EventArgs e)
		{
			try
			{
				if (this.bSingleTestFlag)
				{
					int iProc;
					if (System.Convert.ToInt32(this.progressBar1.Value) == 0)
					{
						iProc = 1;
					}
					else
					{
						iProc = System.Convert.ToInt32(this.currcount * 100 / this.testcount);
						if (iProc >= 100)
						{
							iProc = 99;
						}
					}
					this.progressBar1.Value = iProc;
				}
				int iTempIndex = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count;
				if (iTempIndex > 0)
				{
					int num = this.iAddedCount;
					if (num < this.currcount)
					{
						int num2 = this.testtype;
						if (num2 != 5 && num2 != 6)
						{
							this.dTestResultValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[0].mdTestResult;
						}
						else
						{
							if (num >= iTempIndex)
							{
								return;
							}
							this.dTestResultValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[num].mdTestResult;
						}
						int num3 = this.testtype;
						string strvalue;
						if (num3 != 9)
						{
							if (num3 == 7)
							{
								strvalue = this.GetDZStr(this.dTestResultValue, 7);
							}
							else
							{
								double df = System.Math.Abs(this.dTestResultValue - this.dtoffset);
								double data;
								if (df < 0.001)
								{
									data = 0.001;
								}
								else
								{
									data = df;
								}
								strvalue = this.GetDZStr(data, this.testtype);
							}
						}
						else
						{
							strvalue = this.GetDLStr(this.dTestResultValue, 9);
						}
						try
						{
							int i = this.dataGridView2.Rows.Count;
							this.dataGridView2.AllowUserToAddRows = true;
							this.dataGridView2.Rows.Add(1);
							this.dataGridView2.Rows[i].Cells[0].Value = System.Convert.ToString(i + 1);
							this.dataGridView2.Rows[i].Cells[1].Value = System.Convert.ToString(this.port1);
							this.dataGridView2.Rows[i].Cells[2].Value = System.Convert.ToString(this.port2);
							this.dataGridView2.Rows[i].Cells[3].Value = strvalue;
							this.dataGridView2.AllowUserToAddRows = false;
							this.dataGridView2.Rows[i].Selected = false;
						}
						catch (System.Exception ex_262)
						{
						}
						this.iAddedCount++;
						if (this.bSingleTestFlag)
						{
							int num4 = this.currcount;
							if (num4 < this.testcount)
							{
								int num5 = this.testtype;
								if (num5 != 5 && num5 != 6)
								{
									this.gLineTestProcessor.SendStopCmd();
									this.timerWait.Enabled = true;
								}
								else
								{
									int num6 = num4 + 1;
									this.currcount = num6;
									this.gLineTestProcessor.currcount = num6;
								}
							}
							else
							{
								this.TestFinishedFunc();
							}
						}
					}
				}
			}
			catch (System.Exception arg_2ED_0)
			{
				this.dataGridView2.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_2ED_0.StackTrace);
			}
		}
		public void ControlVisibleSetFunc()
		{
			try
			{
				bool bDTEnbleFlag = true;
				if (!this.radioButton_DTTest.Checked)
				{
					bDTEnbleFlag = false;
				}
				this.label_DTBC.Visible = bDTEnbleFlag;
				this.numericUpDown_DTBC.Visible = bDTEnbleFlag;
				this.label_DTBC_FH.Visible = bDTEnbleFlag;
				this.checkBox_DTTest_FourWire.Visible = bDTEnbleFlag;
				this.label_JGSJ.Visible = bDTEnbleFlag;
				this.numericUpDown_JGSJ.Visible = bDTEnbleFlag;
				this.label_JGSJ_FH.Visible = bDTEnbleFlag;
				this.label_dt_dy.Visible = bDTEnbleFlag;
				this.numericUpDown_DT_Volt.Visible = bDTEnbleFlag;
				this.label_DT_Volt_unit.Visible = bDTEnbleFlag;
				this.label_dt_dl.Visible = bDTEnbleFlag;
				this.numericUpDown_DT_Current.Visible = bDTEnbleFlag;
				this.label_DT_Current_unit.Visible = bDTEnbleFlag;
				byte visible = (!bDTEnbleFlag) ? 1 : 0;
				this.label_testtime.Visible = (visible != 0);
				byte visible2 = (!bDTEnbleFlag) ? 1 : 0;
				this.numericUpDown_testtime.Visible = (visible2 != 0);
				byte visible3 = (!bDTEnbleFlag) ? 1 : 0;
				this.label_testtime_FH.Visible = (visible3 != 0);
				byte visible4 = (!bDTEnbleFlag) ? 1 : 0;
				this.label_testvolt.Visible = (visible4 != 0);
				byte visible5 = (!bDTEnbleFlag) ? 1 : 0;
				this.numericUpDown_testvolt.Visible = (visible5 != 0);
				byte visible6 = (!bDTEnbleFlag) ? 1 : 0;
				this.label_testvolt_FH.Visible = (visible6 != 0);
				this.checkBox_JYTest_LV.Visible = this.radioButton_JYTest.Checked;
				if (this.radioButton_NYTest.Checked)
				{
					this.numericUpDown_testvolt.DecimalPlaces = 0;
					decimal increment = new decimal(new int[]
					{
						1,
						0,
						0,
						65536
					});
					this.numericUpDown_testvolt.Increment = increment;
				}
			}
			catch (System.Exception arg_17D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_17D_0.StackTrace);
			}
		}
		private void radioButton_JYTest_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.ControlVisibleSetFunc();
			}
			catch (System.Exception arg_08_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_08_0.StackTrace);
			}
		}
		private void radioButton_NYTest_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.ControlVisibleSetFunc();
			}
			catch (System.Exception arg_08_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_08_0.StackTrace);
			}
		}
		private void radioButton_DTTest_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.ControlVisibleSetFunc();
			}
			catch (System.Exception arg_08_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_08_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool GetCSYPinAndAddArrayFunc(string jkNameStr, string jkIDIDStr, int iNum)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			string jkIDStr = jkIDIDStr;
			try
			{
				this.gLineTestProcessor.iPort1Array.Clear();
				this.gLineTestProcessor.strPort1Array.Clear();
				string tempStr = "";
				System.Collections.Generic.List<string> tempStrArray = new System.Collections.Generic.List<string>();
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand;
					OleDbCommand cmd;
					if (iNum == 0)
					{
						sqlcommand = "select * from TPlugLibrary where PlugNo='" + jkNameStr + "'";
						cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						if (dataReader.Read())
						{
							tempStr = dataReader["PID"].ToString();
						}
						dataReader.Close();
						dataReader = null;
						if (string.IsNullOrEmpty(tempStr))
						{
							return false;
						}
						jkIDStr = tempStr;
					}
					sqlcommand = "select * from TPlugLibraryDetail where PID = '" + jkIDStr + "'";
					cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					while (dataReader.Read())
					{
						tempStr = dataReader["PinName"].ToString();
						this.gLineTestProcessor.strPort1Array.Add(tempStr);
						tempStr = dataReader["DevicePinNum"].ToString();
						string[] tempArray = tempStr.Split(new char[]
						{
							','
						});
						tempStrArray.Add(tempArray[0]);
					}
					dataReader.Close();
					dataReader = null;
					if (this.gLineTestProcessor.bUseRelayBoard)
					{
						System.Collections.Generic.List<string> tempStr2Array = new System.Collections.Generic.List<string>();
						for (int i = 0; i < tempStrArray.Count; i++)
						{
							sqlcommand = "select top 1 * from TIAndRTPinReletionData where AT_PinNum = '" + tempStrArray[i] + "'";
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							while (dataReader.Read())
							{
								tempStr = dataReader["TI_PinNum"].ToString();
								tempStr2Array.Add(tempStr);
							}
							dataReader.Close();
							dataReader = null;
						}
						for (int j = 0; j < tempStr2Array.Count; j++)
						{
							this.gLineTestProcessor.iPort1Array.Add(System.Convert.ToInt32(tempStr2Array[j]));
						}
					}
					else
					{
						for (int k = 0; k < tempStrArray.Count; k++)
						{
							this.gLineTestProcessor.iPort1Array.Add(System.Convert.ToInt32(tempStrArray[k]));
						}
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_23D_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_23D_0.StackTrace);
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
			catch (System.Exception arg_261_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_261_0.StackTrace);
			}
			return true;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool GetProbeTestParaFunc()
		{
			try
			{
				string jkIDStr = "1";
				int iStartPin = 1;
				int iCount = 1;
				if (this.bProbeTestFlag)
				{
					iStartPin = System.Convert.ToInt32(this.numericUpDown_Probe_Pin.Value);
				}
				else
				{
					if (this.bProbeFWTestFlag)
					{
						byte result;
						bool flag;
						try
						{
							int iPSta = System.Convert.ToInt32(this.numericUpDown_Probe_StartPin.Text.ToString());
							int iPEnd = System.Convert.ToInt32(this.numericUpDown_Probe_StopPin.Text.ToString());
							if (iPSta < iPEnd)
							{
								int sELF_MAX_COUNT = this.gLineTestProcessor.SELF_MAX_COUNT;
								if (iPSta <= sELF_MAX_COUNT && iPEnd <= sELF_MAX_COUNT)
								{
									this.iStartValue = iPSta;
									this.iEndValue = iPEnd;
									iCount = iPEnd - iPSta + 1;
									int iDTLValue = System.Convert.ToInt32(this.numericUpDown_Probe_FW_DTYZ.Text.ToString());
									this.iDTLimitedValue = iDTLValue;
									goto IL_21D;
								}
							}
							MessageBox.Show("参数范围设置错误，只能设置在1至" + System.Convert.ToInt32(this.gLineTestProcessor.SELF_MAX_COUNT) + "范围内，并且后者大于前者!", "提示", MessageBoxButtons.OK);
							result = 0;
							return result != 0;
						}
						catch (System.Exception ex_FF)
						{
							MessageBox.Show("参数设置异常!", "提示", MessageBoxButtons.OK);
							flag = false;
						}
						result = (flag ? 1 : 0);
						return result != 0;
					}
					if (this.bProbeJKTestFlag)
					{
						string tempStr = this.comboBox_Probe_JK.Text;
						if (string.IsNullOrEmpty(tempStr))
						{
							MessageBox.Show("测试接口为空!", "提示", MessageBoxButtons.OK);
							byte result = 0;
							return result != 0;
						}
						string[] tempSrrArray = tempStr.Split(new char[]
						{
							';'
						});
						this.jkNameStr = tempSrrArray[0];
						int iIDIndex = this.comboBox_Probe_JK.SelectedIndex;
						if (iIDIndex == -1)
						{
							this.GetCSYPinAndAddArrayFunc(this.jkNameStr, jkIDStr, 0);
						}
						else
						{
							jkIDStr = this.strIDArray[iIDIndex];
							this.GetCSYPinAndAddArrayFunc(this.jkNameStr, jkIDStr, 1);
						}
						if (this.gLineTestProcessor.iPort1Array.Count < 0)
						{
							MessageBox.Show("未找到可用的测试仪针脚!", "提示", MessageBoxButtons.OK);
							byte result = 0;
							return result != 0;
						}
						int iDTLValue2 = System.Convert.ToInt32(this.numericUpDown_Probe_JK_DTYZ.Text.ToString());
						this.iDTLimitedValue = iDTLValue2;
						iCount = this.gLineTestProcessor.iPort1Array.Count;
					}
				}
				IL_21D:
				this.testtype = 5;
				this.testcount = iCount;
				this.testtime = 1;
				this.testvolt = 1;
				this.dev1 = 0;
				this.dev2 = 0;
				this.port1 = iStartPin;
				this.port2 = 65534;
				this.currcount = 0;
				this.gLineTestProcessor.dev1 = 0;
				this.gLineTestProcessor.dev2 = this.dev2;
				this.gLineTestProcessor.port1 = this.port1;
				this.gLineTestProcessor.port2 = this.port2;
				this.gLineTestProcessor.testtype = this.testtype;
				this.gLineTestProcessor.testcount = this.testcount;
				this.gLineTestProcessor.testtime = this.testtime;
				this.gLineTestProcessor.testvolt = this.testvolt;
				this.gLineTestProcessor.currcount = this.currcount;
				this.gLineTestProcessor.dtoffset = this.dtoffset;
				this.gLineTestProcessor.mtimetick = this.mtimetick;
				this.progressBar1.Value = 0;
				this.label_progress.Text = "0 %";
			}
			catch (System.Exception arg_335_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_335_0.StackTrace);
				return false;
			}
			return true;
		}
		public void ProbeTestFinishedFunc()
		{
			try
			{
				this.bProbeTestFlag = false;
				this.bProbeFWTestFlag = false;
				this.bProbeJKTestFlag = false;
				this.progressBar1.Value = 100;
				this.label_progress.Text = "100 %";
				this.btnStartProbeTest.Text = "启动测试";
				this.btnStartProbeFWTest.Text = "启动测试";
				this.btnStartProbeJKTest.Text = "启动测试";
				this.timer_ProbeTest.Enabled = false;
				this.timerProbeFW.Enabled = false;
				this.timerProbeJK.Enabled = false;
				this.timer_updatePro.Enabled = false;
				this.gLineTestProcessor.mbKeepRun = false;
				this.gLineTestProcessor.SendStopCmd();
			}
			catch (System.Exception arg_AB_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_AB_0.StackTrace);
			}
		}
		private void btnStartProbeTest_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.bSelfStudyFlag && !this.bSingleTestFlag && !this.bProbeFWTestFlag && !this.bProbeJKTestFlag)
				{
					if (!this.gLineTestProcessor.bIsConnSuccFlag)
					{
						MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
					}
					else if (this.bProbeTestFlag)
					{
						if (DialogResult.OK == MessageBox.Show("正在进行测试，您确定要停止吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
						{
							this.ProbeTestFinishedFunc();
						}
					}
					else
					{
						this.bProbeTestFlag = true;
						if (!this.GetProbeTestParaFunc())
						{
							this.bProbeTestFlag = false;
						}
						else
						{
							this.gLineTestProcessor.SendStopCmd();
							this.dataGridView3.Rows.Clear();
							this.iAddedCount = 0;
							this.timer_ProbeTest.Enabled = true;
							this.btnStartProbeTest.Text = "停止测试";
							this.timerWait.Enabled = true;
						}
					}
				}
			}
			catch (System.Exception arg_DF_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_DF_0.StackTrace);
			}
		}
		private void timer_ProbeTest_Tick(object sender, System.EventArgs e)
		{
			try
			{
				if (this.bProbeTestFlag || this.bProbeFWTestFlag || this.bProbeJKTestFlag)
				{
					int iProc = System.Convert.ToInt32(this.progressBar1.Value);
					if (iProc < 99)
					{
						iProc++;
					}
					else
					{
						iProc = System.Convert.ToInt32(this.currcount * 100 / this.testcount);
						if (iProc >= 100)
						{
							iProc = 100;
						}
					}
					this.progressBar1.Value = iProc;
				}
				bool bShowFlag = true;
				if (this.bProbeFWTestFlag)
				{
					for (int i = 0; i < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count; i++)
					{
						this.dTestResultValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mdTestResult;
						int iPortTemp = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mMainDevPinNum;
						if (this.dTestResultValue > (double)this.iDTLimitedValue)
						{
							bShowFlag = false;
						}
						else
						{
							bShowFlag = true;
							double df = System.Math.Abs(this.dTestResultValue);
							double data;
							if (df < 0.001)
							{
								data = 0.001;
							}
							else
							{
								data = df;
							}
							string strvalue = this.GetDZStr(data, this.testtype);
							try
							{
								int j = this.dataGridView4.Rows.Count;
								this.dataGridView4.AllowUserToAddRows = true;
								this.dataGridView4.Rows.Add(1);
								this.dataGridView4.Rows[j].Cells[0].Value = System.Convert.ToString(j + 1);
								this.dataGridView4.Rows[j].Cells[1].Value = System.Convert.ToString(iPortTemp);
								this.dataGridView4.Rows[j].Cells[2].Value = "探针";
								this.dataGridView4.Rows[j].Cells[3].Value = strvalue;
								this.dataGridView4.AllowUserToAddRows = false;
								this.dataGridView4.Rows[j].Selected = false;
							}
							catch (System.Exception ex_224)
							{
								this.dataGridView4.AllowUserToAddRows = false;
							}
							this.ProbeTestFinishedFunc();
						}
					}
					if (this.testcount == this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count && !bShowFlag)
					{
						this.ProbeTestFinishedFunc();
					}
				}
				else if (this.bProbeJKTestFlag)
				{
					for (int k = 0; k < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count; k++)
					{
						this.dTestResultValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k].mdTestResult;
						int iPortTemp = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[k].mMainDevPinNum;
						if (this.dTestResultValue > (double)this.iDTLimitedValue)
						{
							bShowFlag = false;
						}
						else
						{
							bShowFlag = true;
							string jkjdStr = "";
							for (int l = 0; l < this.gLineTestProcessor.iPort1Array.Count; l++)
							{
								if (iPortTemp == this.gLineTestProcessor.iPort1Array[l])
								{
									jkjdStr = this.gLineTestProcessor.strPort1Array[l];
									break;
								}
							}
							double df2 = System.Math.Abs(this.dTestResultValue);
							double data2;
							if (df2 < 0.001)
							{
								data2 = 0.001;
							}
							else
							{
								data2 = df2;
							}
							string strvalue2 = this.GetDZStr(data2, this.testtype);
							try
							{
								int m = this.dataGridView5.Rows.Count;
								this.dataGridView5.AllowUserToAddRows = true;
								this.dataGridView5.Rows.Add(1);
								this.dataGridView5.Rows[m].Cells[0].Value = System.Convert.ToString(m + 1);
								this.dataGridView5.Rows[m].Cells[1].Value = this.jkNameStr;
								this.dataGridView5.Rows[m].Cells[2].Value = jkjdStr;
								this.dataGridView5.Rows[m].Cells[3].Value = "探针";
								this.dataGridView5.Rows[m].Cells[4].Value = strvalue2;
								this.dataGridView5.AllowUserToAddRows = false;
								this.dataGridView5.Rows[m].Selected = false;
							}
							catch (System.Exception ex_4B3)
							{
								this.dataGridView5.AllowUserToAddRows = false;
							}
							this.ProbeTestFinishedFunc();
						}
					}
					if (this.testcount == this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count && !bShowFlag)
					{
						this.ProbeTestFinishedFunc();
					}
				}
				else if (this.bProbeTestFlag)
				{
					int iTempIndex = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count;
					if (this.testcount >= iTempIndex && this.iAddedCount < iTempIndex)
					{
						int num = this.iAddedCount;
						if (num == this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count && this.testcount == iTempIndex)
						{
							this.ProbeTestFinishedFunc();
						}
						else
						{
							int iPortTemp = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[num].mMainDevPinNum;
							double mdTestResult = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[this.iAddedCount].mdTestResult;
							this.dTestResultValue = mdTestResult;
							double df3 = System.Math.Abs(mdTestResult);
							double data3;
							if (df3 < 0.001)
							{
								data3 = 0.001;
							}
							else
							{
								data3 = df3;
							}
							string strvalue3 = this.GetDZStr(data3, this.testtype);
							try
							{
								int n = this.dataGridView3.Rows.Count;
								this.dataGridView3.AllowUserToAddRows = true;
								this.dataGridView3.Rows.Add(1);
								this.dataGridView3.Rows[n].Cells[0].Value = System.Convert.ToString(n + 1);
								this.dataGridView3.Rows[n].Cells[1].Value = System.Convert.ToString(iPortTemp);
								this.dataGridView3.Rows[n].Cells[2].Value = "探针";
								this.dataGridView3.Rows[n].Cells[3].Value = strvalue3;
								this.dataGridView3.AllowUserToAddRows = false;
								this.dataGridView3.Rows[n].Selected = false;
							}
							catch (System.Exception ex_705)
							{
								this.dataGridView3.AllowUserToAddRows = false;
							}
							int num2 = this.currcount + 1;
							this.currcount = num2;
							int num3 = this.iAddedCount + 1;
							this.iAddedCount = num3;
							if (this.bProbeTestFlag)
							{
								int t = System.Convert.ToInt32(this.mtimetick * 1000.0);
								int millisecondsTimeout;
								if (t > 50)
								{
									millisecondsTimeout = t;
								}
								else
								{
									millisecondsTimeout = 50;
								}
								System.Threading.Thread.Sleep(millisecondsTimeout);
								if (this.currcount < this.testcount)
								{
									this.gLineTestProcessor.SendStopCmd();
									this.timerWait.Enabled = true;
								}
								else
								{
									this.ProbeTestFinishedFunc();
								}
							}
							else
							{
								int num4 = this.testcount;
								if (num4 == num3 && num4 < num2)
								{
									this.ProbeTestFinishedFunc();
								}
							}
						}
					}
				}
			}
			catch (System.Exception arg_7E5_0)
			{
				this.dataGridView3.AllowUserToAddRows = false;
				this.dataGridView4.AllowUserToAddRows = false;
				this.dataGridView5.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_7E5_0.StackTrace);
			}
		}
		private void tabControl_Debugging_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.ctFormDeviceDebugging_SizeChanged(null, null);
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
					int iw = this.dataGridView1.Width - 500;
					if (iw < 0)
					{
						iw = 0;
					}
					int arg_4F_0 = iw / 2;
					int iv = iw % 2;
					this.dataGridView1.Columns[0].Width = iv + 76;
					int width = arg_4F_0 + 200;
					this.dataGridView1.Columns[1].Width = width;
					this.dataGridView1.Columns[2].Width = width;
					int ib = this.dataGridView2.Width - 700;
					if (ib < 0)
					{
						ib = 0;
					}
					int num = ib / 3;
					int ic = num;
					iv = ib - num * 3;
					this.dataGridView2.Columns[0].Width = iv + 76;
					int width2 = ic + 200;
					this.dataGridView2.Columns[1].Width = width2;
					this.dataGridView2.Columns[2].Width = width2;
					this.dataGridView2.Columns[3].Width = width2;
					ib = this.dataGridView3.Width - 700;
					if (ib < 0)
					{
						ib = 0;
					}
					int num2 = ib / 3;
					ic = num2;
					iv = ib - num2 * 3;
					this.dataGridView3.Columns[0].Width = iv + 76;
					int width3 = ic + 200;
					this.dataGridView3.Columns[1].Width = width3;
					this.dataGridView3.Columns[2].Width = width3;
					this.dataGridView3.Columns[3].Width = width3;
					ib = this.dataGridView4.Width - 700;
					if (ib < 0)
					{
						ib = 0;
					}
					int num3 = ib / 3;
					ic = num3;
					iv = ib - num3 * 3;
					this.dataGridView4.Columns[0].Width = iv + 76;
					int width4 = ic + 200;
					this.dataGridView4.Columns[1].Width = width4;
					this.dataGridView4.Columns[2].Width = width4;
					this.dataGridView4.Columns[3].Width = width4;
					ib = this.dataGridView5.Width - 700;
					if (ib < 0)
					{
						ib = 0;
					}
					ic = ib / 4;
					iv = ib % 4;
					this.dataGridView5.Columns[0].Width = iv + 76;
					int width5 = ic + 150;
					this.dataGridView5.Columns[1].Width = width5;
					this.dataGridView5.Columns[2].Width = width5;
					this.dataGridView5.Columns[3].Width = width5;
					this.dataGridView5.Columns[4].Width = width5;
				}
			}
			catch (System.Exception arg_2D8_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2D8_0.StackTrace);
			}
		}
		private void ctFormDeviceDebugging_SizeChanged(object sender, System.EventArgs e)
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
		private void ctFormDeviceDebugging_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				this.bCloseFlag = true;
				this.gLineTestProcessor.mbKeepRun = false;
				this.gLineTestProcessor.SendStopCmd();
			}
			catch (System.Exception arg_20_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_20_0.StackTrace);
			}
		}
		private void checkBox_JYTest_LV_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (this.checkBox_JYTest_LV.Checked)
				{
					this.numericUpDown_testvolt.DecimalPlaces = 3;
					decimal increment = new decimal(new int[]
					{
						1,
						0,
						0,
						196608
					});
					this.numericUpDown_testvolt.Increment = increment;
				}
				else
				{
					this.numericUpDown_testvolt.DecimalPlaces = 0;
					decimal e2 = new decimal(new int[]
					{
						1,
						0,
						0,
						65536
					});
					this.numericUpDown_testvolt.Increment = e2;
				}
			}
			catch (System.Exception arg_87_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_87_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool SaveToExcelFileFunc(string xlsxFile, string bzStr)
		{
			bool bSuccFlag = true;
			try
			{
				if (string.IsNullOrEmpty(xlsxFile))
				{
					return false;
				}
				Workbook wb = new Workbook();
				Cells cells = wb.Worksheets[0].Cells;
				Style st = wb.Styles[wb.Styles.Add()];
				st.HorizontalAlignment = TextAlignmentType.Center;
				st.VerticalAlignment = TextAlignmentType.Center;
				st.Font.Name = "宋体";
				st.Font.Size = 11;
				int iCol = 0;
				this.putValue(cells, "序号", 0, 0, st);
				this.putValue(cells, "起点针脚", 0, 1, st);
				this.putValue(cells, "终点针脚", 0, 2, st);
				this.putValue(cells, "测试值", 0, 3, st);
				int iRow = 1;
				try
				{
					for (int i = 0; i < this.dataGridView5.Rows.Count; i++)
					{
						string bzStr2 = "";
						string temp0Str = bzStr2;
						string temp1Str = bzStr2;
						string temp2Str = bzStr2;
						string temp3Str = bzStr2;
						if (this.dataGridView5.Rows[i].Cells[0].Value != null)
						{
							temp0Str = this.dataGridView5.Rows[i].Cells[0].Value.ToString();
						}
						if (this.dataGridView5.Rows[i].Cells[1].Value != null)
						{
							temp1Str = this.dataGridView5.Rows[i].Cells[1].Value.ToString();
						}
						if (this.dataGridView5.Rows[i].Cells[2].Value != null)
						{
							temp2Str = this.dataGridView5.Rows[i].Cells[2].Value.ToString();
						}
						if (this.dataGridView5.Rows[i].Cells[3].Value != null)
						{
							temp3Str = this.dataGridView5.Rows[i].Cells[3].Value.ToString();
						}
						this.putValue(cells, temp0Str, iRow, iCol, st);
						this.putValue(cells, temp1Str, iRow, iCol + 1, st);
						this.putValue(cells, temp2Str, iRow, iCol + 2, st);
						this.putValue(cells, temp3Str, iRow, iCol + 3, st);
						iRow++;
					}
				}
				catch (System.Exception arg_26D_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_26D_0.StackTrace);
				}
				wb.Save(xlsxFile, SaveFormat.Xlsx);
				wb = null;
			}
			catch (System.Exception arg_287_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_287_0.StackTrace);
				bSuccFlag = false;
			}
			return bSuccFlag;
		}
		public void putValue(Cells cell, object tempValue, int row, int column, Style st)
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
				if (this.dataGridView5.Rows.Count <= 0)
				{
					MessageBox.Show("表格数据为空!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					string orfn = Application.StartupPath;
					FolderBrowserDialog sender2 = new FolderBrowserDialog();
					this.folderBrowserDialog1 = sender2;
					sender2.Description = "目录选择";
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
						string xlsxFn = orfn + "\\探针测试数据_" + tt + "_" + ttms + ".xlsx";
						if (this.SaveToExcelFileFunc(xlsxFn, ""))
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
			catch (System.Exception arg_17A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_17A_0.StackTrace);
			}
		}
		private void toolStripMenuItem_ClearData_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.dataGridView5.Rows.Clear();
			}
			catch (System.Exception arg_12_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_12_0.StackTrace);
			}
		}
		private void btnStartProbeFWTest_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.bSelfStudyFlag && !this.bSingleTestFlag && !this.bProbeTestFlag && !this.bProbeJKTestFlag)
				{
					if (!this.gLineTestProcessor.bIsConnSuccFlag)
					{
						MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
					}
					else if (this.bProbeFWTestFlag)
					{
						if (DialogResult.OK == MessageBox.Show("正在进行测试，您确定要停止吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
						{
							this.ProbeTestFinishedFunc();
						}
					}
					else
					{
						this.bProbeFWTestFlag = true;
						if (!this.GetProbeTestParaFunc())
						{
							this.bProbeFWTestFlag = false;
						}
						else
						{
							this.gLineTestProcessor.SendStopCmd();
							this.iAddedCount = 0;
							this.timer_ProbeTest.Enabled = true;
							this.btnStartProbeFWTest.Text = "停止测试";
							this.dataGridView4.Rows.Clear();
							this.timerWait.Enabled = true;
						}
					}
				}
			}
			catch (System.Exception arg_DF_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_DF_0.StackTrace);
			}
		}
		private void timerProbeFW_Tick(object sender, System.EventArgs e)
		{
		}
		private void btnStartProbeJKTest_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.bSelfStudyFlag && !this.bSingleTestFlag && !this.bProbeTestFlag && !this.bProbeFWTestFlag)
				{
					if (!this.gLineTestProcessor.bIsConnSuccFlag)
					{
						MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
					}
					else if (this.bProbeJKTestFlag)
					{
						if (DialogResult.OK == MessageBox.Show("正在进行测试，您确定要停止吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
						{
							this.ProbeTestFinishedFunc();
						}
					}
					else
					{
						this.bProbeJKTestFlag = true;
						if (!this.GetProbeTestParaFunc())
						{
							this.bProbeJKTestFlag = false;
						}
						else
						{
							this.gLineTestProcessor.SendStopCmd();
							this.iAddedCount = 0;
							this.timer_ProbeTest.Enabled = true;
							this.btnStartProbeJKTest.Text = "停止测试";
							this.dataGridView5.Rows.Clear();
							this.timerWait.Enabled = true;
						}
					}
				}
			}
			catch (System.Exception arg_DF_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_DF_0.StackTrace);
			}
		}
		private void timerProbeJK_Tick(object sender, System.EventArgs e)
		{
		}
		private void dataGridView5_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{
				if (e.ColumnIndex != -1 && e.RowIndex != -1)
				{
					if (e.Button == MouseButtons.Right)
					{
						System.Drawing.Point sender2 = Control.MousePosition;
						System.Drawing.Point this2 = Control.MousePosition;
						this.contextMenuStrip_DataProc.Show(this2.X, sender2.Y);
					}
				}
			}
			catch (System.Exception arg_4A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_4A_0.StackTrace);
			}
		}
		private void timerWait_Tick(object sender, System.EventArgs e)
		{
			try
			{
				this.timerWait.Enabled = false;
				this.StartTest();
			}
			catch (System.Exception arg_14_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_14_0.StackTrace);
			}
		}
		private void timerZXXWait_Tick(object sender, System.EventArgs e)
		{
			try
			{
				this.timerZXXWait.Enabled = false;
				if (this.bDTSDTestFlag)
				{
					this.gLineTestProcessor.SendDTSelfStudyCmd(this.iStartValue, this.iEndValue, this.iDTLimitedValue);
					System.Threading.Thread.Sleep(100);
					this.timerXXSJ.Enabled = true;
				}
				else
				{
					this.gLineTestProcessor.SendSelfStudyCmd(this.iStartValue, this.iEndValue, this.iDTLimitedValue);
				}
			}
			catch (System.Exception arg_65_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_65_0.StackTrace);
			}
		}
		private void timerXXSJ_Tick(object sender, System.EventArgs e)
		{
			try
			{
				double dTemp = System.Math.Round((double)this.iDTSelfStudyTime / 10.0, 1);
				string showStr = System.Convert.ToString(dTemp);
				if (-1 == showStr.LastIndexOf('.'))
				{
					showStr += ".0";
				}
				this.label_ZXXSJ.Text = showStr + "s";
				this.iDTSelfStudyTime++;
			}
			catch (System.Exception arg_5C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5C_0.StackTrace);
			}
		}
		private void btnDTSDTest_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.bSingleTestFlag && !this.bSelfStudyFlag)
				{
					if (!this.gLineTestProcessor.bIsConnSuccFlag)
					{
						MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						if (this.bDTSDTestFlag)
						{
							if (DialogResult.OK == MessageBox.Show("正在进行测试，您确定要停止吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
							{
								this.timer_updatePro.Enabled = false;
								this.progressBar1.Value = 100;
								this.label_progress.Text = "100 %";
								this.bDTSDTestFlag = false;
								this.btnDTSDTest.Text = "开始测试";
								this.timer1.Enabled = false;
								this.timerXXSJ.Enabled = false;
								this.gLineTestProcessor.mbKeepRun = false;
								for (int i = 0; i < 2; i++)
								{
									this.gLineTestProcessor.SendStopCmd();
									System.Threading.Thread.Sleep(300);
								}
							}
						}
						else
						{
							int iStart = System.Convert.ToInt32(this.numericUpDown_DTSDTest_StartPin.Text.ToString());
							int iEnd = System.Convert.ToInt32(this.numericUpDown_DTSDTest_StopPin.Text.ToString());
							if (iStart < iEnd)
							{
								int sELF_MAX_COUNT = this.gLineTestProcessor.SELF_MAX_COUNT;
								if (iStart <= sELF_MAX_COUNT && iEnd <= sELF_MAX_COUNT)
								{
									this.timer_updatePro.Enabled = true;
									this.progressBar1.Value = 0;
									this.label_progress.Text = "0 %";
									int iTemp = System.Math.Abs(iEnd - iStart + 1);
									if (iTemp > 16)
									{
										if (iEnd <= 128)
										{
											iEnd -= 2;
										}
										else
										{
											iEnd -= 6;
										}
									}
									iTemp = System.Math.Abs(iEnd - iStart + 1);
									KParseRepCmd arg_19E_0 = this.gLineTestProcessor.mpDevComm.mParseCmd;
									int expr_19C = iTemp;
									arg_19E_0.selfStudyCount = expr_19C * expr_19C;
									this.iStartValue = iStart;
									this.iEndValue = iEnd;
									this.iDTLimitedValue = 1000;
									this.gLineTestProcessor.iTwoFourWireChoice = 2;
									this.iTestTime = 0;
									this.iDTSelfStudyTime = 0;
									this.bDTSDTestFlag = true;
									this.btnDTSDTest.Text = "停止测试";
									this.label_ZXXSJ.Text = "0s";
									this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyMainPinCount = 0;
									this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyPinNum = 0;
									this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyProgress = 0;
									this.gLineTestProcessor.mbKeepRun = true;
									this.timerZXXWait.Enabled = true;
									this.timer1.Enabled = true;
									goto IL_263;
								}
							}
							MessageBox.Show("参数范围设置异常!", "提示", MessageBoxButtons.OK);
						}
						IL_263:;
					}
				}
			}
			catch (System.Exception arg_27A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_27A_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormDeviceDebugging();
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
