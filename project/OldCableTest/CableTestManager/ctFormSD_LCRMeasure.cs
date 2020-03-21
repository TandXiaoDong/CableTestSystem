using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.IO.Ports;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormSD_LCRMeasure : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public SerialPort _serialPort;
		public int rcv_inpointer;
		public int rcv_outpointer;
		public int rcv_startPointer;
		public string[] _availablePortStrArray;
		public int _iAvailablePortNum;
		public bool _bOpenState;
		public byte[] bBufferDataArray;
		public static int MAX_BUFFER_COUNT = 65536;
		public byte[] rcvbuffer;
		public int[] _iTestValuesArray;
		public int[] _iAllTestDataArray;
		public static int MAX_WAIT_TIME = 4;
		public int iTestTimeCount;
		public string loginUser;
		public string portNameStr;
		public string parityStr;
		public string stopBitsStr;
		public int iBaudrate;
		public int iDatadits;
		public int iReadIndex;
		public System.Collections.Generic.List<byte[]> cmdList;
		public System.Collections.Generic.List<bool> cmdReturnList;
		public double dTestVol;
		public double dTestTime;
		public int iCurrSendCmdIndex;
		public int iTestTimeTatal;
		public bool bTestFinished;
		public string testFreqStr;
		public string testVoltStr;
		public double dTestValue;
		public int iGetTestVCount;
		public double dZZTestValue;
		public double dCapacitanceThreshold;
		public string strTestResult;
		public string strTestConclusion;
		public string startJKStr;
		public string startPinStr;
		public string stopJKStr;
		public string stopPinStr;
		public int iStartReadIndex;
		public int iReadCount;
		public int iRecWaitTime;
		public bool bTestFlag;
		public string strPlugInfo;
		public string dbpath;
		public System.Collections.Generic.List<int> startPinMeasMethodList;
		public System.Collections.Generic.List<string> startPinStrList;
		public System.Collections.Generic.List<int> stopPinMeasMethodList;
		public System.Collections.Generic.List<string> stopPinStrList;
		private ComboBox comboBox_startPin;
		private ComboBox comboBox_stopPin;
		private ComboBox comboBox_stopIFBH;
		private ComboBox comboBox_startIFBH;
		private Label label1;
		private Label label4;
		private Label label5;
		private Label label2;
		private Label label_progress;
		private Label label11;
		private ProgressBar progressBar_test;
		private GroupBox groupBox1;
		private Label label12;
		private TextBox textBox_jl;
		private Button btnOpenClose;
		private ComboBox comboBox_PortName;
		private Label label_ckh;
		private TabControl tabControl1;
		private TabPage tabPage2;
		private Label label9;
		private Label label8;
		private TextBox textBox_ldl;
		private Label label3;
		private Label label6;
		private GroupBox groupBox_nyParaSet;
		private Label label10;
		private NumericUpDown numericUpDown_HoldTime;
		private NumericUpDown numericUpDown_Threshold;
		private Label label_ny_yz;
		private Label label_Threshold_unit;
		private Label label_ny_jlgy;
		private Label label_ny_nybcTime;
		private Label label_HoldTime_unit;
		private ComboBox comboBox_Voltage;
		private ComboBox comboBox_Frequency;
		private System.Windows.Forms.Timer timer_tt;
		private System.Windows.Forms.Timer timer_statusQ;
		private System.Windows.Forms.Timer timer_tCount;
		private Button btnQuit;
		private Button btnSaveData;
		private Button btnStartTest;
		private IContainer components;
		public ctFormSD_LCRMeasure(KLineTestProcessor gltProcessor, string plugInfoStr)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
					this.strPlugInfo = plugInfoStr;
					this.bBufferDataArray = new byte[ctFormSD_LCRMeasure.MAX_BUFFER_COUNT];
					this.cmdList = new System.Collections.Generic.List<byte[]>();
					this.cmdReturnList = new System.Collections.Generic.List<bool>();
					this.startPinMeasMethodList = new System.Collections.Generic.List<int>();
					this.startPinStrList = new System.Collections.Generic.List<string>();
					this.stopPinMeasMethodList = new System.Collections.Generic.List<int>();
					this.stopPinStrList = new System.Collections.Generic.List<string>();
				}
				catch (System.Exception ex_91)
				{
				}
				this.SysVariablesInitFunc();
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormSD_LCRMeasure()
		{
			IContainer this2 = this.components;
			if (this2 != null)
			{
				this2.Dispose();
			}
		}
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox_nyParaSet = new System.Windows.Forms.GroupBox();
            this.comboBox_startPin = new System.Windows.Forms.ComboBox();
            this.comboBox_stopPin = new System.Windows.Forms.ComboBox();
            this.comboBox_stopIFBH = new System.Windows.Forms.ComboBox();
            this.comboBox_startIFBH = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_Threshold = new System.Windows.Forms.NumericUpDown();
            this.label_ny_yz = new System.Windows.Forms.Label();
            this.label_Threshold_unit = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_Voltage = new System.Windows.Forms.ComboBox();
            this.comboBox_Frequency = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_HoldTime = new System.Windows.Forms.NumericUpDown();
            this.label_ny_jlgy = new System.Windows.Forms.Label();
            this.label_ny_nybcTime = new System.Windows.Forms.Label();
            this.label_HoldTime_unit = new System.Windows.Forms.Label();
            this.btnOpenClose = new System.Windows.Forms.Button();
            this.comboBox_PortName = new System.Windows.Forms.ComboBox();
            this.label_ckh = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_jl = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_ldl = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label_progress = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.progressBar_test = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.timer_tt = new System.Windows.Forms.Timer(this.components);
            this.timer_statusQ = new System.Windows.Forms.Timer(this.components);
            this.timer_tCount = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox_nyParaSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Threshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HoldTime)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Location = new System.Drawing.Point(346, 565);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(112, 24);
            this.btnQuit.TabIndex = 4;
            this.btnQuit.Text = "退出";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSaveData
            // 
            this.btnSaveData.Enabled = false;
            this.btnSaveData.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveData.Location = new System.Drawing.Point(490, 298);
            this.btnSaveData.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(135, 24);
            this.btnSaveData.TabIndex = 1;
            this.btnSaveData.Text = "保存数据";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Visible = false;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // btnStartTest
            // 
            this.btnStartTest.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartTest.Location = new System.Drawing.Point(313, 298);
            this.btnStartTest.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(135, 24);
            this.btnStartTest.TabIndex = 0;
            this.btnStartTest.Text = "启动测试";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.ItemSize = new System.Drawing.Size(120, 27);
            this.tabControl1.Location = new System.Drawing.Point(16, 18);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(768, 524);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.groupBox_nyParaSet);
            this.tabPage2.Controls.Add(this.btnOpenClose);
            this.tabPage2.Controls.Add(this.comboBox_PortName);
            this.tabPage2.Controls.Add(this.label_ckh);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label_progress);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.progressBar_test);
            this.tabPage2.Controls.Add(this.btnSaveData);
            this.tabPage2.Controls.Add(this.btnStartTest);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(760, 489);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "电容测试";
            // 
            // groupBox_nyParaSet
            // 
            this.groupBox_nyParaSet.Controls.Add(this.comboBox_startPin);
            this.groupBox_nyParaSet.Controls.Add(this.comboBox_stopPin);
            this.groupBox_nyParaSet.Controls.Add(this.comboBox_stopIFBH);
            this.groupBox_nyParaSet.Controls.Add(this.comboBox_startIFBH);
            this.groupBox_nyParaSet.Controls.Add(this.label1);
            this.groupBox_nyParaSet.Controls.Add(this.label4);
            this.groupBox_nyParaSet.Controls.Add(this.label5);
            this.groupBox_nyParaSet.Controls.Add(this.label2);
            this.groupBox_nyParaSet.Controls.Add(this.numericUpDown_Threshold);
            this.groupBox_nyParaSet.Controls.Add(this.label_ny_yz);
            this.groupBox_nyParaSet.Controls.Add(this.label_Threshold_unit);
            this.groupBox_nyParaSet.Controls.Add(this.label10);
            this.groupBox_nyParaSet.Controls.Add(this.comboBox_Voltage);
            this.groupBox_nyParaSet.Controls.Add(this.comboBox_Frequency);
            this.groupBox_nyParaSet.Controls.Add(this.label6);
            this.groupBox_nyParaSet.Controls.Add(this.numericUpDown_HoldTime);
            this.groupBox_nyParaSet.Controls.Add(this.label_ny_jlgy);
            this.groupBox_nyParaSet.Controls.Add(this.label_ny_nybcTime);
            this.groupBox_nyParaSet.Controls.Add(this.label_HoldTime_unit);
            this.groupBox_nyParaSet.Location = new System.Drawing.Point(32, 60);
            this.groupBox_nyParaSet.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_nyParaSet.Name = "groupBox_nyParaSet";
            this.groupBox_nyParaSet.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_nyParaSet.Size = new System.Drawing.Size(696, 190);
            this.groupBox_nyParaSet.TabIndex = 75;
            this.groupBox_nyParaSet.TabStop = false;
            this.groupBox_nyParaSet.Text = "参数设置";
            // 
            // comboBox_startPin
            // 
            this.comboBox_startPin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox_startPin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_startPin.FormattingEnabled = true;
            this.comboBox_startPin.Location = new System.Drawing.Point(409, 29);
            this.comboBox_startPin.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_startPin.Name = "comboBox_startPin";
            this.comboBox_startPin.Size = new System.Drawing.Size(188, 22);
            this.comboBox_startPin.TabIndex = 85;
            // 
            // comboBox_stopPin
            // 
            this.comboBox_stopPin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox_stopPin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_stopPin.FormattingEnabled = true;
            this.comboBox_stopPin.Location = new System.Drawing.Point(409, 66);
            this.comboBox_stopPin.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_stopPin.Name = "comboBox_stopPin";
            this.comboBox_stopPin.Size = new System.Drawing.Size(188, 22);
            this.comboBox_stopPin.TabIndex = 87;
            // 
            // comboBox_stopIFBH
            // 
            this.comboBox_stopIFBH.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox_stopIFBH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_stopIFBH.FormattingEnabled = true;
            this.comboBox_stopIFBH.Location = new System.Drawing.Point(98, 66);
            this.comboBox_stopIFBH.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_stopIFBH.Name = "comboBox_stopIFBH";
            this.comboBox_stopIFBH.Size = new System.Drawing.Size(188, 22);
            this.comboBox_stopIFBH.TabIndex = 86;
            this.comboBox_stopIFBH.SelectedIndexChanged += new System.EventHandler(this.comboBox_stopIFBH_SelectedIndexChanged);
            // 
            // comboBox_startIFBH
            // 
            this.comboBox_startIFBH.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox_startIFBH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_startIFBH.FormattingEnabled = true;
            this.comboBox_startIFBH.Location = new System.Drawing.Point(98, 29);
            this.comboBox_startIFBH.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_startIFBH.Name = "comboBox_startIFBH";
            this.comboBox_startIFBH.Size = new System.Drawing.Size(188, 22);
            this.comboBox_startIFBH.TabIndex = 84;
            this.comboBox_startIFBH.SelectedIndexChanged += new System.EventHandler(this.comboBox_startIFBH_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(325, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 81;
            this.label1.Text = "终点接点:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(16, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 80;
            this.label4.Text = "终点接口:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(325, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 83;
            this.label5.Text = "起点接点:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 82;
            this.label2.Text = "起点接口:";
            // 
            // numericUpDown_Threshold
            // 
            this.numericUpDown_Threshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown_Threshold.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDown_Threshold.Location = new System.Drawing.Point(409, 114);
            this.numericUpDown_Threshold.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown_Threshold.Maximum = new decimal(new int[] {
            705032704,
            1,
            0,
            0});
            this.numericUpDown_Threshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Threshold.Name = "numericUpDown_Threshold";
            this.numericUpDown_Threshold.Size = new System.Drawing.Size(112, 24);
            this.numericUpDown_Threshold.TabIndex = 77;
            this.numericUpDown_Threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_Threshold.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label_ny_yz
            // 
            this.label_ny_yz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ny_yz.AutoSize = true;
            this.label_ny_yz.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ny_yz.Location = new System.Drawing.Point(325, 118);
            this.label_ny_yz.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ny_yz.Name = "label_ny_yz";
            this.label_ny_yz.Size = new System.Drawing.Size(75, 15);
            this.label_ny_yz.TabIndex = 78;
            this.label_ny_yz.Text = "电容阈值:";
            // 
            // label_Threshold_unit
            // 
            this.label_Threshold_unit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Threshold_unit.AutoSize = true;
            this.label_Threshold_unit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Threshold_unit.Location = new System.Drawing.Point(529, 118);
            this.label_Threshold_unit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Threshold_unit.Name = "label_Threshold_unit";
            this.label_Threshold_unit.Size = new System.Drawing.Size(151, 15);
            this.label_Threshold_unit.TabIndex = 79;
            this.label_Threshold_unit.Text = "pF (10~5000000000)";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.label10.Location = new System.Drawing.Point(14, 93);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(641, 12);
            this.label10.TabIndex = 32;
            this.label10.Text = "---------------------------------------------------------------------------------" +
    "-------------------------";
            // 
            // comboBox_Voltage
            // 
            this.comboBox_Voltage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox_Voltage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Voltage.FormattingEnabled = true;
            this.comboBox_Voltage.Items.AddRange(new object[] {
            "0.1V",
            "0.3V",
            "1V"});
            this.comboBox_Voltage.Location = new System.Drawing.Point(98, 155);
            this.comboBox_Voltage.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Voltage.Name = "comboBox_Voltage";
            this.comboBox_Voltage.Size = new System.Drawing.Size(188, 22);
            this.comboBox_Voltage.TabIndex = 72;
            // 
            // comboBox_Frequency
            // 
            this.comboBox_Frequency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox_Frequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Frequency.FormattingEnabled = true;
            this.comboBox_Frequency.Items.AddRange(new object[] {
            "50Hz",
            "60Hz",
            "100Hz",
            "120Hz",
            "1kHz",
            "10kHz",
            "20kHz",
            "40kHz",
            "50kHz",
            "100kHz"});
            this.comboBox_Frequency.Location = new System.Drawing.Point(98, 115);
            this.comboBox_Frequency.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Frequency.Name = "comboBox_Frequency";
            this.comboBox_Frequency.Size = new System.Drawing.Size(188, 22);
            this.comboBox_Frequency.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 118);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 76;
            this.label6.Text = "测试频率:";
            // 
            // numericUpDown_HoldTime
            // 
            this.numericUpDown_HoldTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown_HoldTime.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDown_HoldTime.Location = new System.Drawing.Point(409, 154);
            this.numericUpDown_HoldTime.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown_HoldTime.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numericUpDown_HoldTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_HoldTime.Name = "numericUpDown_HoldTime";
            this.numericUpDown_HoldTime.Size = new System.Drawing.Size(112, 24);
            this.numericUpDown_HoldTime.TabIndex = 5;
            this.numericUpDown_HoldTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_HoldTime.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label_ny_jlgy
            // 
            this.label_ny_jlgy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ny_jlgy.AutoSize = true;
            this.label_ny_jlgy.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ny_jlgy.Location = new System.Drawing.Point(18, 158);
            this.label_ny_jlgy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ny_jlgy.Name = "label_ny_jlgy";
            this.label_ny_jlgy.Size = new System.Drawing.Size(75, 15);
            this.label_ny_jlgy.TabIndex = 20;
            this.label_ny_jlgy.Text = "测试电平:";
            // 
            // label_ny_nybcTime
            // 
            this.label_ny_nybcTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ny_nybcTime.AutoSize = true;
            this.label_ny_nybcTime.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ny_nybcTime.Location = new System.Drawing.Point(325, 158);
            this.label_ny_nybcTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ny_nybcTime.Name = "label_ny_nybcTime";
            this.label_ny_nybcTime.Size = new System.Drawing.Size(75, 15);
            this.label_ny_nybcTime.TabIndex = 21;
            this.label_ny_nybcTime.Text = "测试时间:";
            // 
            // label_HoldTime_unit
            // 
            this.label_HoldTime_unit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_HoldTime_unit.AutoSize = true;
            this.label_HoldTime_unit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_HoldTime_unit.Location = new System.Drawing.Point(529, 158);
            this.label_HoldTime_unit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_HoldTime_unit.Name = "label_HoldTime_unit";
            this.label_HoldTime_unit.Size = new System.Drawing.Size(87, 15);
            this.label_HoldTime_unit.TabIndex = 18;
            this.label_HoldTime_unit.Text = "s  (1~120)";
            // 
            // btnOpenClose
            // 
            this.btnOpenClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOpenClose.Location = new System.Drawing.Point(437, 20);
            this.btnOpenClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenClose.Name = "btnOpenClose";
            this.btnOpenClose.Size = new System.Drawing.Size(112, 24);
            this.btnOpenClose.TabIndex = 73;
            this.btnOpenClose.Text = "打开串口";
            this.btnOpenClose.UseVisualStyleBackColor = true;
            this.btnOpenClose.Click += new System.EventHandler(this.btnOpenClose_Click);
            // 
            // comboBox_PortName
            // 
            this.comboBox_PortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PortName.FormattingEnabled = true;
            this.comboBox_PortName.Items.AddRange(new object[] {
            "COM4",
            "COM12"});
            this.comboBox_PortName.Location = new System.Drawing.Point(283, 22);
            this.comboBox_PortName.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_PortName.Name = "comboBox_PortName";
            this.comboBox_PortName.Size = new System.Drawing.Size(114, 22);
            this.comboBox_PortName.TabIndex = 72;
            // 
            // label_ckh
            // 
            this.label_ckh.AutoSize = true;
            this.label_ckh.Location = new System.Drawing.Point(212, 24);
            this.label_ckh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ckh.Name = "label_ckh";
            this.label_ckh.Size = new System.Drawing.Size(60, 15);
            this.label_ckh.TabIndex = 74;
            this.label_ckh.Text = "串口号:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBox_jl);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox_ldl);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(32, 370);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(696, 68);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测试结果";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(395, 33);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 15);
            this.label12.TabIndex = 55;
            this.label12.Text = "测试结论:";
            // 
            // textBox_jl
            // 
            this.textBox_jl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox_jl.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_jl.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox_jl.Location = new System.Drawing.Point(478, 29);
            this.textBox_jl.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_jl.Name = "textBox_jl";
            this.textBox_jl.ReadOnly = true;
            this.textBox_jl.Size = new System.Drawing.Size(114, 24);
            this.textBox_jl.TabIndex = 10;
            this.textBox_jl.Text = "合格";
            this.textBox_jl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 33);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 15);
            this.label8.TabIndex = 37;
            this.label8.Text = "电容测试值:";
            // 
            // textBox_ldl
            // 
            this.textBox_ldl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox_ldl.Location = new System.Drawing.Point(175, 29);
            this.textBox_ldl.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ldl.Name = "textBox_ldl";
            this.textBox_ldl.ReadOnly = true;
            this.textBox_ldl.Size = new System.Drawing.Size(114, 24);
            this.textBox_ldl.TabIndex = 11;
            this.textBox_ldl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(293, 33);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 15);
            this.label9.TabIndex = 41;
            this.label9.Text = "pF";
            // 
            // label_progress
            // 
            this.label_progress.AutoSize = true;
            this.label_progress.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_progress.Location = new System.Drawing.Point(672, 458);
            this.label_progress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_progress.Name = "label_progress";
            this.label_progress.Size = new System.Drawing.Size(23, 15);
            this.label_progress.TabIndex = 70;
            this.label_progress.Text = "0%";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(45, 458);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 69;
            this.label11.Text = "测试进度:";
            // 
            // progressBar_test
            // 
            this.progressBar_test.ForeColor = System.Drawing.Color.Green;
            this.progressBar_test.Location = new System.Drawing.Point(130, 455);
            this.progressBar_test.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar_test.Name = "progressBar_test";
            this.progressBar_test.Size = new System.Drawing.Size(530, 19);
            this.progressBar_test.Step = 1;
            this.progressBar_test.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(714, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 31;
            // 
            // timer_tt
            // 
            this.timer_tt.Interval = 1000;
            this.timer_tt.Tick += new System.EventHandler(this.timer_tt_Tick);
            // 
            // timer_statusQ
            // 
            this.timer_statusQ.Interval = 3000;
            this.timer_statusQ.Tick += new System.EventHandler(this.timer_statusQ_Tick);
            // 
            // timer_tCount
            // 
            this.timer_tCount.Interval = 1000;
            this.timer_tCount.Tick += new System.EventHandler(this.timer_tCount_Tick);
            // 
            // ctFormSD_LCRMeasure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 616);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnQuit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ctFormSD_LCRMeasure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "电容测试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ctFormSD_LCRMeasure_FormClosing);
            this.Load += new System.EventHandler(this.ctFormSD_LCRMeasure_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox_nyParaSet.ResumeLayout(false);
            this.groupBox_nyParaSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Threshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_HoldTime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		public void SysVariablesInitFunc()
		{
			try
			{
				this.iTestTimeCount = 0;
				this._serialPort = new SerialPort();
				this._serialPort.DataReceived += new SerialDataReceivedEventHandler(this._serialPort_DataReceived);
				this._serialPort.ReadBufferSize = ctFormSD_LCRMeasure.MAX_BUFFER_COUNT;
				this._serialPort.WriteBufferSize = ctFormSD_LCRMeasure.MAX_BUFFER_COUNT;
				this.SPComm_Init();
				this.comboBox_PortName.Items.Clear();
				for (int i = 0; i < this._iAvailablePortNum; i++)
				{
					this.comboBox_PortName.Items.Add(this._availablePortStrArray[i]);
				}
				if (this.comboBox_PortName.Items.Count > 0)
				{
					this.comboBox_PortName.SelectedIndex = 0;
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		public void SPComm_Init()
		{
			try
			{
				int iComNum = 16;
				this._availablePortStrArray = new string[16];
				this.rcvbuffer = new byte[ctFormSD_LCRMeasure.MAX_BUFFER_COUNT];
				this.rcv_inpointer = 0;
				this.rcv_startPointer = 0;
				this.rcv_outpointer = 0;
				this._iAvailablePortNum = 0;
				int i = 1;
				while (i <= iComNum)
				{
					try
					{
						int num = i;
						this._serialPort.PortName = "COM" + num.ToString();
						try
						{
							this._serialPort.Open();
						}
						catch (System.Exception ex_79)
						{
						}
						System.Threading.Thread.Sleep(50);
						if (this._serialPort.IsOpen)
						{
							this._serialPort.Close();
							this._availablePortStrArray[this._iAvailablePortNum] = this._serialPort.PortName;
							this._iAvailablePortNum++;
						}
					}
					catch (System.Exception ex_C5)
					{
					}
					IL_CC:
					i++;
					continue;
					goto IL_CC;
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool ReadRecData()
		{
			bool result2;
			try
			{
				byte result;
				if (!this._serialPort.IsOpen)
				{
					result = 0;
					return result != 0;
				}
				int length = this._serialPort.BytesToRead;
				if (length <= 0)
				{
					result = 0;
					return result != 0;
				}
				byte[] data = new byte[length];
				this._serialPort.Read(data, 0, length);
				for (int i = 0; i < length; i++)
				{
					this.rcvbuffer[this.rcv_inpointer] = data[i];
					this.rcv_inpointer++;
					if (this.rcv_inpointer >= ctFormSD_LCRMeasure.MAX_BUFFER_COUNT)
					{
						this.rcv_inpointer = 0;
					}
				}
				result = 1;
				return result != 0;
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
				result2 = false;
			}
			return result2;
		}
		public void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			try
			{
				this.ReadRecData();
			}
			catch (System.Exception ex_09)
			{
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool IsHaveNoReadData()
		{
			return this.rcv_outpointer != this.rcv_inpointer;
		}
		public byte GetLocalData()
		{
			byte data = 0;
			try
			{
				if (this.IsHaveNoReadData())
				{
					int this2 = this.rcv_outpointer;
					data = this.rcvbuffer[this2];
					this.rcv_outpointer = this2 + 1;
					if (this.rcv_outpointer >= ctFormSD_LCRMeasure.MAX_BUFFER_COUNT)
					{
						this.rcv_outpointer = 0;
					}
				}
			}
			catch (System.Exception ex_3B)
			{
			}
			return data;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool SendMessage(string smStr)
		{
			if (!this._serialPort.IsOpen)
			{
				return false;
			}
			bool this2;
			try
			{
				this._serialPort.WriteLine(smStr);
				return true;
			}
			catch (System.Exception arg_20_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_20_0.StackTrace);
				try
				{
					this._serialPort.Close();
				}
				catch (System.Exception ex_37)
				{
				}
				this2 = false;
			}
			return this2;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool SendData(byte[] sendData)
		{
			if (!this._serialPort.IsOpen)
			{
				return false;
			}
			bool this2;
			try
			{
				this._serialPort.Write(sendData, 0, sendData.Length);
				return true;
			}
			catch (System.Exception arg_23_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_23_0.StackTrace);
				try
				{
					this._serialPort.Close();
				}
				catch (System.Exception ex_3A)
				{
				}
				this2 = false;
			}
			return this2;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool OpenCloseSerialPort([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool onoff)
		{
			bool result;
			try
			{
				SerialPort onoff2 = this._serialPort;
				byte this2;
				if (onoff2 == null)
				{
					this2 = 0;
					return this2 != 0;
				}
				if (onoff2.IsOpen)
				{
					this._serialPort.Close();
					System.Threading.Thread.Sleep(100);
				}
				if (onoff)
				{
					this._serialPort.Open();
					System.Threading.Thread.Sleep(10);
				}
				this2 = 1;
				return this2 != 0;
			}
			catch (System.Exception arg_41_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_41_0.StackTrace);
				result = false;
			}
			return result;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool OpenSerialPort()
		{
			bool result;
			try
			{
				byte this2;
				if (string.IsNullOrEmpty(this.portNameStr))
				{
					MessageBox.Show("打开串口失败，端口号为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					this2 = 0;
					return this2 != 0;
				}
				if (this._serialPort.IsOpen)
				{
					this._serialPort.Close();
					System.Threading.Thread.Sleep(100);
				}
				this._serialPort.PortName = this.portNameStr;
				this._serialPort.BaudRate = this.iBaudrate;
				this._serialPort.DataBits = this.iDatadits;
				if (this.parityStr == "Even")
				{
					this._serialPort.Parity = Parity.Even;
				}
				else if (this.parityStr == "Mark")
				{
					this._serialPort.Parity = Parity.Mark;
				}
				else if (this.parityStr == "Odd")
				{
					this._serialPort.Parity = Parity.Odd;
				}
				else if (this.parityStr == "Space")
				{
					this._serialPort.Parity = Parity.Space;
				}
				else
				{
					this._serialPort.Parity = Parity.None;
				}
				if (this.stopBitsStr == "One")
				{
					this._serialPort.StopBits = StopBits.One;
				}
				else if (this.stopBitsStr == "Two")
				{
					this._serialPort.StopBits = StopBits.Two;
				}
				else if (this.stopBitsStr == "OnePointFive")
				{
					this._serialPort.StopBits = StopBits.OnePointFive;
				}
				else
				{
					this._serialPort.StopBits = StopBits.None;
				}
				this._serialPort.Open();
				System.Threading.Thread.Sleep(10);
				this2 = 1;
				return this2 != 0;
			}
			catch (System.Exception arg_187_0)
			{
				MessageBox.Show(arg_187_0.Message, "提示", MessageBoxButtons.OK);
				result = false;
			}
			return result;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool OpenSerialPort(string portNameStr, int iBaudrate, int iDatadits, string parityStr, string stopbitsStr)
		{
			bool portNameStr2;
			try
			{
				byte this2;
				if (string.IsNullOrEmpty(portNameStr))
				{
					MessageBox.Show("打开串口失败，端口号为空!", "提示", MessageBoxButtons.OK);
					this2 = 0;
					return this2 != 0;
				}
				if (this._serialPort.IsOpen)
				{
					this._serialPort.Close();
					this._bOpenState = false;
					System.Threading.Thread.Sleep(100);
				}
				this._serialPort.PortName = portNameStr;
				this._serialPort.BaudRate = iBaudrate;
				this._serialPort.DataBits = iDatadits;
				if (parityStr == "Even")
				{
					this._serialPort.Parity = Parity.Even;
				}
				else if (parityStr == "Mark")
				{
					this._serialPort.Parity = Parity.Mark;
				}
				else if (parityStr == "Odd")
				{
					this._serialPort.Parity = Parity.Odd;
				}
				else if (parityStr == "Space")
				{
					this._serialPort.Parity = Parity.Space;
				}
				else
				{
					this._serialPort.Parity = Parity.None;
				}
				if (stopbitsStr == "One")
				{
					this._serialPort.StopBits = StopBits.One;
				}
				else if (stopbitsStr == "Two")
				{
					this._serialPort.StopBits = StopBits.Two;
				}
				else if (stopbitsStr == "OnePointFive")
				{
					this._serialPort.StopBits = StopBits.OnePointFive;
				}
				else
				{
					this._serialPort.StopBits = StopBits.None;
				}
				this._serialPort.Open();
				this._bOpenState = true;
				System.Threading.Thread.Sleep(100);
				this2 = 1;
				return this2 != 0;
			}
			catch (System.Exception arg_172_0)
			{
				MessageBox.Show(arg_172_0.Message, "提示", MessageBoxButtons.OK);
				portNameStr2 = false;
			}
			return portNameStr2;
		}
		public byte[] CreateCmdFunc(string zlStr, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool bReturn)
		{
			byte[] bArrayCmd = System.Text.Encoding.ASCII.GetBytes(zlStr);
			byte[] sendCmd = new byte[bArrayCmd.Length + 3];
			try
			{
				for (int i = 0; i < bArrayCmd.Length; i++)
				{
					sendCmd[i] = bArrayCmd[i];
				}
				sendCmd[bArrayCmd.Length] = 13;
				sendCmd[bArrayCmd.Length + 1] = 10;
				this.cmdList.Add(sendCmd);
				this.cmdReturnList.Add(bReturn);
			}
			catch (System.Exception ex_51)
			{
			}
			return sendCmd;
		}
		public byte[] CreateCmdFunc2(string zlStr, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool bReturn)
		{
			byte[] bArrayCmd = System.Text.Encoding.ASCII.GetBytes(zlStr);
			byte[] sendCmd = new byte[bArrayCmd.Length + 3];
			try
			{
				for (int i = 0; i < bArrayCmd.Length; i++)
				{
					sendCmd[i] = bArrayCmd[i];
				}
				sendCmd[bArrayCmd.Length] = 13;
				sendCmd[bArrayCmd.Length + 1] = 10;
			}
			catch (System.Exception ex_39)
			{
			}
			return sendCmd;
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			try
			{
				base.Close();
			}
			catch (System.Exception arg_08_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_08_0.StackTrace);
			}
		}
		public void SendCmdFunc()
		{
			try
			{
				int this2 = this.iCurrSendCmdIndex;
				if (this2 < this.cmdList.Count)
				{
					if (!this.SendData(this.cmdList[this2]))
					{
						this.StopTestDisposeFunc();
						MessageBox.Show("发送指令失败，请检查设备状态及连接是否正常!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						System.Threading.Thread.Sleep(300);
						if (this.iCurrSendCmdIndex + 1 >= this.cmdList.Count)
						{
							this.timer_statusQ.Enabled = true;
						}
					}
				}
			}
			catch (System.Exception arg_6F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_6F_0.StackTrace);
			}
		}
		public string GetThreeRountDataStrFunc(string rStr)
		{
			if (string.IsNullOrEmpty(rStr))
			{
				return "";
			}
			string reStr = rStr;
			try
			{
				int iNetIndex = rStr.LastIndexOf('.');
				if (iNetIndex == -1)
				{
					reStr = rStr + ".000";
				}
				else
				{
					for (int i = 0; i < iNetIndex - reStr.Length + 4; i++)
					{
						reStr += "0";
					}
				}
				return reStr;
			}
			catch (System.Exception arg_50_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_50_0.StackTrace);
			}
			return reStr;
		}
		public void RecDataDealWithFunc()
		{
			try
			{
				int num = this.iReadCount;
				byte[] bRDataArray = new byte[num];
				int iIndex = 0;
				for (int i = this.iReadIndex - num; i < this.iReadIndex; i++)
				{
					bRDataArray[iIndex] = this.bBufferDataArray[i];
					iIndex++;
				}
				string arg_63_0 = System.Text.Encoding.ASCII.GetString(bRDataArray);
				string temp1Str = "";
				string[] arrayTemp = arg_63_0.Split(new char[]
				{
					','
				});
				if (arrayTemp != null)
				{
					temp1Str = arrayTemp[0];
				}
				if (!string.IsNullOrEmpty(temp1Str))
				{
					bool bPassFlag = true;
					try
					{
						double value = System.Convert.ToDouble(temp1Str);
						this.dZZTestValue = value;
						double num2 = System.Math.Abs(value);
						this.dZZTestValue = num2;
						double value2 = num2 * 1000000000000.0;
						this.dZZTestValue = value2;
						this.dZZTestValue = System.Math.Round(value2, 4);
					}
					catch (System.Exception ex_C9)
					{
					}
					if (this.dZZTestValue > this.dCapacitanceThreshold)
					{
						bPassFlag = false;
					}
					if (this.bTestFinished || !bPassFlag)
					{
						this.strTestConclusion = "合格";
						if (!bPassFlag)
						{
							this.strTestConclusion = "不合格\n";
							System.Drawing.Color red = System.Drawing.Color.Red;
							this.textBox_jl.ForeColor = red;
						}
						this.strTestResult = System.Convert.ToString(this.dZZTestValue) + " pF";
						this.textBox_ldl.Text = System.Convert.ToString(this.dZZTestValue);
						this.textBox_jl.Text = this.strTestConclusion;
						this.StopTestDisposeFunc();
					}
				}
			}
			catch (System.Exception arg_165_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_165_0.StackTrace);
			}
		}
		private void btnStartTest_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.bTestFlag)
				{
					this.StopTestDisposeFunc();
				}
				else
				{
					this.OpenSerialPort();
					decimal value = this.numericUpDown_Threshold.Value;
					this.dCapacitanceThreshold = System.Convert.ToDouble(value);
					decimal value2 = this.numericUpDown_HoldTime.Value;
					this.dTestTime = System.Convert.ToDouble(value2);
					string e2 = this.comboBox_Frequency.Text;
					this.testFreqStr = e2;
					if (string.IsNullOrEmpty(e2))
					{
						MessageBox.Show("未选择测试频率!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else
					{
						this.startJKStr = this.comboBox_startIFBH.Text.ToString();
						this.startPinStr = this.comboBox_startPin.Text.ToString();
						this.stopJKStr = this.comboBox_stopIFBH.Text.ToString();
						this.stopPinStr = this.comboBox_stopPin.Text.ToString();
						this.btnStartTest.Text = "停止测试";
						this.textBox_ldl.Text = "";
						this.textBox_jl.Text = "";
						System.Drawing.Color black = System.Drawing.Color.Black;
						this.textBox_jl.ForeColor = black;
						this.label_ckh.Enabled = false;
						this.btnOpenClose.Enabled = false;
						this.btnSaveData.Enabled = false;
						this.btnQuit.Enabled = false;
						this.progressBar_test.Value = 0;
						this.label_progress.Text = "0%";
						this.timer_tt.Enabled = true;
						this.timer_tCount.Enabled = true;
						this.timer_statusQ.Enabled = false;
						this.strTestResult = "";
						this.strTestConclusion = "";
						this.bTestFinished = false;
						this.bTestFlag = true;
						this.iRecWaitTime = 0;
						this.iReadCount = 0;
						this.iStartReadIndex = 0;
						this.dTestValue = 0.0;
						this.dZZTestValue = 0.0;
						this.iGetTestVCount = 0;
						this.iReadIndex = 0;
						this.iTestTimeTatal = 0;
						this.iCurrSendCmdIndex = 0;
						string sStr = "";
						if (this.comboBox_Voltage.SelectedIndex == 0)
						{
							sStr = "VOLT 100mV";
						}
						else if (this.comboBox_Voltage.SelectedIndex == 1)
						{
							sStr = "VOLT 300mV";
						}
						else if (this.comboBox_Voltage.SelectedIndex == 2)
						{
							sStr = "VOLT 1V";
						}
						byte[] sendCmd = this.CreateCmdFunc2(sStr, false);
						this.SendData(sendCmd);
						System.Threading.Thread.Sleep(1000);
						sStr = "FREQ " + this.testFreqStr.ToUpper();
						sendCmd = this.CreateCmdFunc2(sStr, false);
						this.SendData(sendCmd);
						this.timer_statusQ.Enabled = true;
					}
				}
			}
			catch (System.Exception arg_293_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_293_0.StackTrace);
				this.StopTestDisposeFunc();
			}
		}
		public void StopTestDisposeFunc()
		{
			try
			{
				this.btnStartTest.Text = "启动测试";
				this.iRecWaitTime = 0;
				this.bTestFinished = false;
				this.bTestFlag = false;
				this.label_ckh.Enabled = true;
				this.btnOpenClose.Enabled = true;
				this.btnSaveData.Enabled = true;
				this.btnQuit.Enabled = true;
				this.timer_tt.Enabled = false;
				this.timer_statusQ.Enabled = false;
				this.timer_tCount.Enabled = false;
				this.progressBar_test.Value = 100;
				this.label_progress.Text = "100%";
				this.OpenCloseSerialPort(false);
				this.cmdList.Clear();
				this.cmdReturnList.Clear();
			}
			catch (System.Exception arg_B6_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_B6_0.StackTrace);
			}
		}
		public void AddInterfaceNoToControlFunc()
		{
			try
			{
				this.comboBox_startIFBH.Items.Clear();
				this.comboBox_stopIFBH.Items.Clear();
				if (!string.IsNullOrEmpty(this.strPlugInfo))
				{
					if (-1 == this.strPlugInfo.Trim().LastIndexOf(','))
					{
						this.comboBox_startIFBH.Items.Add(this.strPlugInfo);
						this.comboBox_stopIFBH.Items.Add(this.strPlugInfo);
					}
					else
					{
						char[] separator = new char[]
						{
							','
						};
						string[] strTempArray = this.strPlugInfo.Trim().Split(separator);
						for (int i = 0; i < strTempArray.Length; i++)
						{
							if (!string.IsNullOrEmpty(strTempArray[i]))
							{
								this.comboBox_startIFBH.Items.Add(strTempArray[i]);
								this.comboBox_stopIFBH.Items.Add(strTempArray[i]);
							}
						}
					}
				}
				if (this.comboBox_startIFBH.Items.Count > 0)
				{
					this.comboBox_startIFBH.SelectedIndex = 0;
					this.comboBox_stopIFBH.SelectedIndex = 0;
					if (this.comboBox_stopIFBH.Items.Count > 1)
					{
						this.comboBox_stopIFBH.SelectedIndex = 1;
					}
				}
			}
			catch (System.Exception arg_123_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_123_0.StackTrace);
			}
		}
		private void ctFormSD_LCRMeasure_Load(object sender, System.EventArgs e)
		{
			try
			{
				this._bOpenState = false;
				this.comboBox_Frequency.SelectedIndex = 4;
				this.comboBox_Voltage.SelectedIndex = 2;
				this.rcvbuffer = new byte[ctFormSD_LCRMeasure.MAX_BUFFER_COUNT];
				this.rcv_inpointer = 0;
				this.rcv_startPointer = 0;
				this.rcv_outpointer = 0;
				this.iReadIndex = 0;
				this.portNameStr = "";
				this.iBaudrate = 9600;
				this.iDatadits = 8;
				this.parityStr = "None";
				this.stopBitsStr = "One";
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
			this.AddInterfaceNoToControlFunc();
		}
		public void WriteTestInfoToDBFunc()
		{
		}
		private void ctFormSD_LCRMeasure_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (this.bTestFlag)
				{
					e.Cancel = true;
				}
				else if (this._serialPort.IsOpen)
				{
					this._serialPort.Close();
					System.Threading.Thread.Sleep(50);
					this._serialPort = null;
				}
			}
			catch (System.Exception arg_3B_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3B_0.StackTrace);
			}
		}
		private void timer_tt_Tick(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.IsHaveNoReadData())
				{
					if (this.bTestFinished)
					{
						int sender2 = this.iRecWaitTime + 1;
						this.iRecWaitTime = sender2;
						if (sender2 > 5)
						{
							this.StopTestDisposeFunc();
							MessageBox.Show("读数据超时!请检查通讯连接是否正常!", "提示", MessageBoxButtons.OK);
						}
					}
				}
				else
				{
					this.iReadCount = 0;
					while (this.IsHaveNoReadData())
					{
						byte bTemp = this.GetLocalData();
						this.bBufferDataArray[this.iReadIndex] = bTemp;
						this.iReadIndex++;
						this.iReadCount++;
					}
					this.RecDataDealWithFunc();
					this.iCurrSendCmdIndex++;
					System.Threading.Thread.Sleep(100);
					this.SendCmdFunc();
				}
			}
			catch (System.Exception arg_B0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_B0_0.StackTrace);
			}
		}
		private void timer_statusQ_Tick(object sender, System.EventArgs e)
		{
			try
			{
				string sStr = "FETC?";
				byte[] sendCmd = this.CreateCmdFunc2(sStr, true);
				this.SendData(sendCmd);
			}
			catch (System.Exception arg_19_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_19_0.StackTrace);
			}
		}
		private void timer_tCount_Tick(object sender, System.EventArgs e)
		{
			try
			{
				if (this.bTestFinished)
				{
					this.progressBar_test.Value = 100;
					this.label_progress.Text = "100%";
				}
				else
				{
					this.iTestTimeTatal++;
					if (this.iTestTimeTatal >= ctFormSD_LCRMeasure.MAX_WAIT_TIME)
					{
						double dTemp = (double)((this.iTestTimeTatal - ctFormSD_LCRMeasure.MAX_WAIT_TIME) * 100) / this.dTestTime;
						if (dTemp > 100.0)
						{
							dTemp = 100.0;
						}
						else if (dTemp <= 0.0)
						{
							dTemp = 1.0;
						}
						int iTemp = (int)System.Convert.ToUInt32(dTemp);
						this.progressBar_test.Value = iTemp;
						this.label_progress.Text = System.Convert.ToString(iTemp) + "%";
						if (this.dTestTime < (double)(this.iTestTimeTatal - ctFormSD_LCRMeasure.MAX_WAIT_TIME))
						{
							this.timer_tCount.Enabled = false;
							string sStr = "FETC?";
							byte[] sendCmd = this.CreateCmdFunc2(sStr, true);
							this.SendData(sendCmd);
							System.Threading.Thread.Sleep(1000);
							this.bTestFinished = true;
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		private void btnOpenClose_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this._bOpenState)
				{
					if (this.OpenCloseSerialPort(false))
					{
						this._bOpenState = false;
						this.btnOpenClose.Text = "打开串口";
						this.comboBox_PortName.Enabled = true;
					}
				}
				else
				{
					string this2 = this.comboBox_PortName.Text;
					this.portNameStr = this2;
					if (string.IsNullOrEmpty(this2))
					{
						MessageBox.Show("打开串口失败，串口号为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else if (this.OpenSerialPort(this.portNameStr, this.iBaudrate, this.iDatadits, this.parityStr, this.stopBitsStr))
					{
						this._bOpenState = true;
						this.btnOpenClose.Text = "关闭串口";
						this.comboBox_PortName.Enabled = false;
					}
				}
			}
			catch (System.Exception arg_B7_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_B7_0.StackTrace);
			}
		}
		private void comboBox_startIFBH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.comboBox_startPin.Items.Clear();
				this.startPinStrList.Clear();
				this.startPinMeasMethodList.Clear();
				string _IFBHStr = this.comboBox_startIFBH.Text.ToString().Trim();
				if (!string.IsNullOrEmpty(_IFBHStr))
				{
					if (this.comboBox_startIFBH.SelectedIndex >= 0)
					{
						string text = "";
						string IdStr = text;
						try
						{
							connection = new OleDbConnection();
							connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
							connection.Open();
							string sqlcommand = "select top 1 * from TPlugLibrary where PlugNo = '" + _IFBHStr + "'";
							OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							if (dataReader.Read())
							{
								IdStr = dataReader["PID"].ToString();
							}
							dataReader.Close();
							dataReader = null;
							sqlcommand = "select * from TPlugLibraryDetail where PID = '" + IdStr + "' order by PDID";
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							while (dataReader.Read())
							{
								string tempStr = dataReader["PinName"].ToString();
								int iTemp = System.Convert.ToInt32(dataReader["MeasuringMethod"].ToString());
								this.startPinStrList.Add(tempStr);
								this.startPinMeasMethodList.Add(iTemp);
							}
							dataReader.Close();
							dataReader = null;
							connection.Close();
							connection = null;
						}
						catch (System.Exception arg_165_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_165_0.StackTrace);
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
						for (int nn = 0; nn < this.startPinMeasMethodList.Count; nn++)
						{
							this.comboBox_startPin.Items.Add(this.startPinStrList[nn]);
						}
						if (this.comboBox_startPin.Items.Count > 0)
						{
							this.comboBox_startPin.SelectedIndex = 0;
						}
					}
				}
			}
			catch (System.Exception arg_1DB_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1DB_0.StackTrace);
			}
		}
		private void comboBox_stopIFBH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.comboBox_stopPin.Items.Clear();
				this.stopPinStrList.Clear();
				this.stopPinMeasMethodList.Clear();
				string _IFBHStr = this.comboBox_stopIFBH.Text.ToString().Trim();
				if (!string.IsNullOrEmpty(_IFBHStr))
				{
					if (this.comboBox_stopIFBH.SelectedIndex >= 0)
					{
						string text = "";
						string IdStr = text;
						try
						{
							connection = new OleDbConnection();
							connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
							connection.Open();
							string sqlcommand = "select top 1 * from TPlugLibrary where PlugNo = '" + _IFBHStr + "'";
							OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							if (dataReader.Read())
							{
								IdStr = dataReader["PID"].ToString();
							}
							dataReader.Close();
							dataReader = null;
							sqlcommand = "select * from TPlugLibraryDetail where PID = '" + IdStr + "' order by PDID";
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							while (dataReader.Read())
							{
								string tempStr = dataReader["PinName"].ToString();
								int iTemp = System.Convert.ToInt32(dataReader["MeasuringMethod"].ToString());
								this.stopPinStrList.Add(tempStr);
								this.stopPinMeasMethodList.Add(iTemp);
							}
							dataReader.Close();
							dataReader = null;
							connection.Close();
							connection = null;
						}
						catch (System.Exception arg_165_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_165_0.StackTrace);
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
						for (int nn = 0; nn < this.stopPinMeasMethodList.Count; nn++)
						{
							this.comboBox_stopPin.Items.Add(this.stopPinStrList[nn]);
						}
						if (this.comboBox_stopPin.Items.Count > 0)
						{
							this.comboBox_stopPin.SelectedIndex = 0;
						}
					}
				}
			}
			catch (System.Exception arg_1DB_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1DB_0.StackTrace);
			}
		}
		private void btnSaveData_Click(object sender, System.EventArgs e)
		{
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormSD_LCRMeasure();
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
