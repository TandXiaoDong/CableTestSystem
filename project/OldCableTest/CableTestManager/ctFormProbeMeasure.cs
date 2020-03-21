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
	public class ctFormProbeMeasure : Form
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
		public bool bProbeTestFlag;
		public bool bProbeJKTestFlag;
		public bool bProbeFWTestFlag;
		public double dTestResultValue;
		public string jkNameStr;
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
		private System.Windows.Forms.Timer timerZXXWait;
		private System.Windows.Forms.Timer timerWait;
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
		private TabPage tabPage3;
		private System.Windows.Forms.Timer timer_ProbeTest;
		private Button btnStartProbeTest;
		private NumericUpDown numericUpDown_Probe_Pin;
		private Label label_Probe_Pin;
		private RadioButton radioButton_Probe_DD;
		private IContainer components;
		private TabControl tabControl_Debugging;
		private GroupBox groupBox_Debugging;
		private ProgressBar progressBar1;
		private Label label_progress;
		private System.Windows.Forms.Timer timer_updatePro;
		public ctFormProbeMeasure(KLineTestProcessor gltProcessor)
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
		private void ~ctFormProbeMeasure()
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
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormProbeMeasure));
			this.groupBox_Debugging = new GroupBox();
			this.tabControl_Debugging = new TabControl();
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
			this.progressBar1 = new ProgressBar();
			this.label_progress = new Label();
			this.timer_updatePro = new System.Windows.Forms.Timer(this.components);
			this.timer_ProbeTest = new System.Windows.Forms.Timer(this.components);
			this.contextMenuStrip_DataProc = new ContextMenuStrip(this.components);
			this.toolStripMenuItem_ClearData = new ToolStripMenuItem();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.toolStripMenuItem_ExportData = new ToolStripMenuItem();
			this.folderBrowserDialog1 = new FolderBrowserDialog();
			this.timerWait = new System.Windows.Forms.Timer(this.components);
			this.timerZXXWait = new System.Windows.Forms.Timer(this.components);
			this.groupBox_Debugging.SuspendLayout();
			this.tabControl_Debugging.SuspendLayout();
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
			this.tabControl_Debugging.Controls.Add(this.tabPage3);
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
			this.tabPage3.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage3.Controls.Add(this.tabControl1);
			System.Drawing.Point location3 = new System.Drawing.Point(4, 34);
			this.tabPage3.Location = location3;
			Padding margin3 = new Padding(2);
			this.tabPage3.Margin = margin3;
			this.tabPage3.Name = "tabPage3";
			Padding padding2 = new Padding(2);
			this.tabPage3.Padding = padding2;
			System.Drawing.Size size3 = new System.Drawing.Size(764, 465);
			this.tabPage3.Size = size3;
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "探针功能";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.tabControl1.Appearance = TabAppearance.Buttons;
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Dock = DockStyle.Fill;
			System.Drawing.Size itemSize2 = new System.Drawing.Size(240, 30);
			this.tabControl1.ItemSize = itemSize2;
			System.Drawing.Point location4 = new System.Drawing.Point(2, 2);
			this.tabControl1.Location = location4;
			Padding margin4 = new Padding(2);
			this.tabControl1.Margin = margin4;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			System.Drawing.Size size4 = new System.Drawing.Size(758, 459);
			this.tabControl1.Size = size4;
			this.tabControl1.SizeMode = TabSizeMode.Fixed;
			this.tabControl1.TabIndex = 41;
			this.tabPage4.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage4.Controls.Add(this.dataGridView3);
			this.tabPage4.Controls.Add(this.btnStartProbeTest);
			this.tabPage4.Controls.Add(this.numericUpDown_Probe_Pin);
			this.tabPage4.Controls.Add(this.label_Probe_Pin);
			this.tabPage4.Controls.Add(this.radioButton_Probe_DD);
			System.Drawing.Point location5 = new System.Drawing.Point(4, 34);
			this.tabPage4.Location = location5;
			Padding margin5 = new Padding(2);
			this.tabPage4.Margin = margin5;
			this.tabPage4.Name = "tabPage4";
			Padding padding3 = new Padding(2);
			this.tabPage4.Padding = padding3;
			System.Drawing.Size size5 = new System.Drawing.Size(750, 421);
			this.tabPage4.Size = size5;
			this.tabPage4.TabIndex = 0;
			this.tabPage4.Text = "探针测试";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.dataGridView3.AllowUserToAddRows = false;
			this.dataGridView3.AllowUserToDeleteRows = false;
			this.dataGridView3.AllowUserToResizeColumns = false;
			this.dataGridView3.AllowUserToResizeRows = false;
			this.dataGridView3.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Color window = System.Drawing.SystemColors.Window;
			this.dataGridView3.BackgroundColor = window;
			this.dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn2,
				this.dgvTBC_StartPin,
				this.dgvTBC_StopPin,
				this.dataGridViewTextBoxColumn7
			};
			this.dataGridView3.Columns.AddRange(dataGridViewColumns);
			System.Drawing.Point location6 = new System.Drawing.Point(9, 91);
			this.dataGridView3.Location = location6;
			Padding margin6 = new Padding(2);
			this.dataGridView3.Margin = margin6;
			this.dataGridView3.MultiSelect = false;
			this.dataGridView3.Name = "dataGridView3";
			this.dataGridView3.RowHeadersVisible = false;
			this.dataGridView3.RowTemplate.Height = 27;
			this.dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size6 = new System.Drawing.Size(733, 323);
			this.dataGridView3.Size = size6;
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
			System.Drawing.Point location7 = new System.Drawing.Point(459, 30);
			this.btnStartProbeTest.Location = location7;
			Padding margin7 = new Padding(2);
			this.btnStartProbeTest.Margin = margin7;
			this.btnStartProbeTest.Name = "btnStartProbeTest";
			System.Drawing.Size size7 = new System.Drawing.Size(90, 28);
			this.btnStartProbeTest.Size = size7;
			this.btnStartProbeTest.TabIndex = 30;
			this.btnStartProbeTest.Text = "启动测试";
			this.btnStartProbeTest.UseVisualStyleBackColor = true;
			this.btnStartProbeTest.Click += new System.EventHandler(this.btnStartProbeTest_Click);
			System.Drawing.Point location8 = new System.Drawing.Point(247, 32);
			this.numericUpDown_Probe_Pin.Location = location8;
			Padding margin8 = new Padding(2);
			this.numericUpDown_Probe_Pin.Margin = margin8;
			decimal maximum = new decimal(new int[]
			{
				262144,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_Pin.Maximum = maximum;
			decimal minimum = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_Pin.Minimum = minimum;
			this.numericUpDown_Probe_Pin.Name = "numericUpDown_Probe_Pin";
			System.Drawing.Size size8 = new System.Drawing.Size(90, 24);
			this.numericUpDown_Probe_Pin.Size = size8;
			this.numericUpDown_Probe_Pin.TabIndex = 27;
			this.numericUpDown_Probe_Pin.TextAlign = HorizontalAlignment.Center;
			decimal value = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_Pin.Value = value;
			this.label_Probe_Pin.AutoSize = true;
			System.Drawing.Point location9 = new System.Drawing.Point(164, 36);
			this.label_Probe_Pin.Location = location9;
			Padding margin9 = new Padding(2, 0, 2, 0);
			this.label_Probe_Pin.Margin = margin9;
			this.label_Probe_Pin.Name = "label_Probe_Pin";
			System.Drawing.Size size9 = new System.Drawing.Size(75, 15);
			this.label_Probe_Pin.Size = size9;
			this.label_Probe_Pin.TabIndex = 26;
			this.label_Probe_Pin.Text = "测试针脚:";
			this.radioButton_Probe_DD.AutoSize = true;
			this.radioButton_Probe_DD.Checked = true;
			System.Drawing.Point location10 = new System.Drawing.Point(63, 34);
			this.radioButton_Probe_DD.Location = location10;
			Padding margin10 = new Padding(2);
			this.radioButton_Probe_DD.Margin = margin10;
			this.radioButton_Probe_DD.Name = "radioButton_Probe_DD";
			System.Drawing.Size size10 = new System.Drawing.Size(85, 19);
			this.radioButton_Probe_DD.Size = size10;
			this.radioButton_Probe_DD.TabIndex = 17;
			this.radioButton_Probe_DD.TabStop = true;
			this.radioButton_Probe_DD.Text = "单针方式";
			this.radioButton_Probe_DD.UseVisualStyleBackColor = true;
			this.tabPage5.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage5.Controls.Add(this.tabControl2);
			System.Drawing.Point location11 = new System.Drawing.Point(4, 34);
			this.tabPage5.Location = location11;
			Padding margin11 = new Padding(2);
			this.tabPage5.Margin = margin11;
			this.tabPage5.Name = "tabPage5";
			Padding padding4 = new Padding(2);
			this.tabPage5.Padding = padding4;
			System.Drawing.Size size11 = new System.Drawing.Size(750, 421);
			this.tabPage5.Size = size11;
			this.tabPage5.TabIndex = 1;
			this.tabPage5.Text = "探针寻址";
			this.tabPage5.UseVisualStyleBackColor = true;
			this.tabControl2.Appearance = TabAppearance.Buttons;
			this.tabControl2.Controls.Add(this.tabPage6);
			this.tabControl2.Controls.Add(this.tabPage7);
			this.tabControl2.Dock = DockStyle.Fill;
			System.Drawing.Size itemSize3 = new System.Drawing.Size(260, 30);
			this.tabControl2.ItemSize = itemSize3;
			System.Drawing.Point location12 = new System.Drawing.Point(2, 2);
			this.tabControl2.Location = location12;
			Padding margin12 = new Padding(2);
			this.tabControl2.Margin = margin12;
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			System.Drawing.Size size12 = new System.Drawing.Size(744, 415);
			this.tabControl2.Size = size12;
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
			System.Drawing.Point location13 = new System.Drawing.Point(4, 34);
			this.tabPage6.Location = location13;
			Padding margin13 = new Padding(2);
			this.tabPage6.Margin = margin13;
			this.tabPage6.Name = "tabPage6";
			Padding padding5 = new Padding(2);
			this.tabPage6.Padding = padding5;
			System.Drawing.Size size13 = new System.Drawing.Size(736, 377);
			this.tabPage6.Size = size13;
			this.tabPage6.TabIndex = 0;
			this.tabPage6.Text = "范围方式寻址";
			this.tabPage6.UseVisualStyleBackColor = true;
			this.dataGridView4.AllowUserToAddRows = false;
			this.dataGridView4.AllowUserToDeleteRows = false;
			this.dataGridView4.AllowUserToResizeColumns = false;
			this.dataGridView4.AllowUserToResizeRows = false;
			this.dataGridView4.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Color window2 = System.Drawing.SystemColors.Window;
			this.dataGridView4.BackgroundColor = window2;
			this.dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns2 = new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn4,
				this.dataGridViewTextBoxColumn6,
				this.dataGridViewTextBoxColumn8,
				this.dataGridViewTextBoxColumn9
			};
			this.dataGridView4.Columns.AddRange(dataGridViewColumns2);
			System.Drawing.Point location14 = new System.Drawing.Point(11, 110);
			this.dataGridView4.Location = location14;
			Padding margin14 = new Padding(2);
			this.dataGridView4.Margin = margin14;
			this.dataGridView4.MultiSelect = false;
			this.dataGridView4.Name = "dataGridView4";
			this.dataGridView4.RowHeadersVisible = false;
			this.dataGridView4.RowTemplate.Height = 27;
			this.dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size14 = new System.Drawing.Size(714, 262);
			this.dataGridView4.Size = size14;
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
			System.Drawing.Point location15 = new System.Drawing.Point(580, 36);
			this.btnStartProbeFWTest.Location = location15;
			Padding margin15 = new Padding(2);
			this.btnStartProbeFWTest.Margin = margin15;
			this.btnStartProbeFWTest.Name = "btnStartProbeFWTest";
			System.Drawing.Size size15 = new System.Drawing.Size(90, 28);
			this.btnStartProbeFWTest.Size = size15;
			this.btnStartProbeFWTest.TabIndex = 66;
			this.btnStartProbeFWTest.Text = "启动测试";
			this.btnStartProbeFWTest.UseVisualStyleBackColor = true;
			this.btnStartProbeFWTest.Click += new System.EventHandler(this.btnStartProbeFWTest_Click);
			this.radioButton_Probe_FW.AutoSize = true;
			this.radioButton_Probe_FW.Checked = true;
			System.Drawing.Point location16 = new System.Drawing.Point(26, 22);
			this.radioButton_Probe_FW.Location = location16;
			Padding margin16 = new Padding(2);
			this.radioButton_Probe_FW.Margin = margin16;
			this.radioButton_Probe_FW.Name = "radioButton_Probe_FW";
			System.Drawing.Size size16 = new System.Drawing.Size(85, 19);
			this.radioButton_Probe_FW.Size = size16;
			this.radioButton_Probe_FW.TabIndex = 52;
			this.radioButton_Probe_FW.TabStop = true;
			this.radioButton_Probe_FW.Text = "范围方式";
			this.radioButton_Probe_FW.UseVisualStyleBackColor = true;
			this.label_Probe_StartPin.AutoSize = true;
			System.Drawing.Point location17 = new System.Drawing.Point(127, 23);
			this.label_Probe_StartPin.Location = location17;
			Padding margin17 = new Padding(2, 0, 2, 0);
			this.label_Probe_StartPin.Margin = margin17;
			this.label_Probe_StartPin.Name = "label_Probe_StartPin";
			System.Drawing.Size size17 = new System.Drawing.Size(75, 15);
			this.label_Probe_StartPin.Size = size17;
			this.label_Probe_StartPin.TabIndex = 54;
			this.label_Probe_StartPin.Text = "起始针脚:";
			System.Drawing.Point location18 = new System.Drawing.Point(209, 19);
			this.numericUpDown_Probe_StartPin.Location = location18;
			Padding margin18 = new Padding(2);
			this.numericUpDown_Probe_StartPin.Margin = margin18;
			decimal maximum2 = new decimal(new int[]
			{
				262144,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_StartPin.Maximum = maximum2;
			decimal minimum2 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_StartPin.Minimum = minimum2;
			this.numericUpDown_Probe_StartPin.Name = "numericUpDown_Probe_StartPin";
			System.Drawing.Size size18 = new System.Drawing.Size(90, 24);
			this.numericUpDown_Probe_StartPin.Size = size18;
			this.numericUpDown_Probe_StartPin.TabIndex = 56;
			this.numericUpDown_Probe_StartPin.TextAlign = HorizontalAlignment.Center;
			decimal value2 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_StartPin.Value = value2;
			System.Drawing.Point location19 = new System.Drawing.Point(407, 19);
			this.numericUpDown_Probe_StopPin.Location = location19;
			Padding margin19 = new Padding(2);
			this.numericUpDown_Probe_StopPin.Margin = margin19;
			decimal maximum3 = new decimal(new int[]
			{
				262144,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_StopPin.Maximum = maximum3;
			decimal minimum3 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_StopPin.Minimum = minimum3;
			this.numericUpDown_Probe_StopPin.Name = "numericUpDown_Probe_StopPin";
			System.Drawing.Size size19 = new System.Drawing.Size(90, 24);
			this.numericUpDown_Probe_StopPin.Size = size19;
			this.numericUpDown_Probe_StopPin.TabIndex = 55;
			this.numericUpDown_Probe_StopPin.TextAlign = HorizontalAlignment.Center;
			decimal value3 = new decimal(new int[]
			{
				64,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_StopPin.Value = value3;
			this.label_Probe_StopPin.AutoSize = true;
			System.Drawing.Point location20 = new System.Drawing.Point(326, 23);
			this.label_Probe_StopPin.Location = location20;
			Padding margin20 = new Padding(2, 0, 2, 0);
			this.label_Probe_StopPin.Margin = margin20;
			this.label_Probe_StopPin.Name = "label_Probe_StopPin";
			System.Drawing.Size size20 = new System.Drawing.Size(75, 15);
			this.label_Probe_StopPin.Size = size20;
			this.label_Probe_StopPin.TabIndex = 53;
			this.label_Probe_StopPin.Text = "终止针脚:";
			this.label_Probe_FW_DTYZ.AutoSize = true;
			System.Drawing.Point location21 = new System.Drawing.Point(127, 62);
			this.label_Probe_FW_DTYZ.Location = location21;
			Padding margin21 = new Padding(2, 0, 2, 0);
			this.label_Probe_FW_DTYZ.Margin = margin21;
			this.label_Probe_FW_DTYZ.Name = "label_Probe_FW_DTYZ";
			System.Drawing.Size size21 = new System.Drawing.Size(75, 15);
			this.label_Probe_FW_DTYZ.Size = size21;
			this.label_Probe_FW_DTYZ.TabIndex = 57;
			this.label_Probe_FW_DTYZ.Text = "导通阈值:";
			this.label_Probe_FW_DTYZ_unit.AutoSize = true;
			System.Drawing.Point location22 = new System.Drawing.Point(306, 62);
			this.label_Probe_FW_DTYZ_unit.Location = location22;
			Padding margin22 = new Padding(2, 0, 2, 0);
			this.label_Probe_FW_DTYZ_unit.Margin = margin22;
			this.label_Probe_FW_DTYZ_unit.Name = "label_Probe_FW_DTYZ_unit";
			System.Drawing.Size size22 = new System.Drawing.Size(22, 15);
			this.label_Probe_FW_DTYZ_unit.Size = size22;
			this.label_Probe_FW_DTYZ_unit.TabIndex = 59;
			this.label_Probe_FW_DTYZ_unit.Text = "Ω";
			System.Drawing.Point location23 = new System.Drawing.Point(209, 58);
			this.numericUpDown_Probe_FW_DTYZ.Location = location23;
			Padding margin23 = new Padding(2);
			this.numericUpDown_Probe_FW_DTYZ.Margin = margin23;
			decimal maximum4 = new decimal(new int[]
			{
				1500,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_FW_DTYZ.Maximum = maximum4;
			this.numericUpDown_Probe_FW_DTYZ.Name = "numericUpDown_Probe_FW_DTYZ";
			System.Drawing.Size size23 = new System.Drawing.Size(90, 24);
			this.numericUpDown_Probe_FW_DTYZ.Size = size23;
			this.numericUpDown_Probe_FW_DTYZ.TabIndex = 58;
			this.numericUpDown_Probe_FW_DTYZ.TextAlign = HorizontalAlignment.Center;
			decimal value4 = new decimal(new int[]
			{
				1000,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_FW_DTYZ.Value = value4;
			this.tabPage7.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage7.Controls.Add(this.btnStartProbeJKTest);
			this.tabPage7.Controls.Add(this.dataGridView5);
			this.tabPage7.Controls.Add(this.radioButton_Probe_JK);
			this.tabPage7.Controls.Add(this.label_Probe_JK_DTYZ_unit);
			this.tabPage7.Controls.Add(this.label_Probe_JK);
			this.tabPage7.Controls.Add(this.numericUpDown_Probe_JK_DTYZ);
			this.tabPage7.Controls.Add(this.comboBox_Probe_JK);
			this.tabPage7.Controls.Add(this.label_Probe_JK_DTYZ);
			System.Drawing.Point location24 = new System.Drawing.Point(4, 34);
			this.tabPage7.Location = location24;
			Padding margin24 = new Padding(2);
			this.tabPage7.Margin = margin24;
			this.tabPage7.Name = "tabPage7";
			Padding padding6 = new Padding(2);
			this.tabPage7.Padding = padding6;
			System.Drawing.Size size24 = new System.Drawing.Size(736, 377);
			this.tabPage7.Size = size24;
			this.tabPage7.TabIndex = 1;
			this.tabPage7.Text = "接口方式寻址";
			this.tabPage7.UseVisualStyleBackColor = true;
			this.btnStartProbeJKTest.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location25 = new System.Drawing.Point(580, 36);
			this.btnStartProbeJKTest.Location = location25;
			Padding margin25 = new Padding(2);
			this.btnStartProbeJKTest.Margin = margin25;
			this.btnStartProbeJKTest.Name = "btnStartProbeJKTest";
			System.Drawing.Size size25 = new System.Drawing.Size(90, 28);
			this.btnStartProbeJKTest.Size = size25;
			this.btnStartProbeJKTest.TabIndex = 67;
			this.btnStartProbeJKTest.Text = "启动测试";
			this.btnStartProbeJKTest.UseVisualStyleBackColor = true;
			this.btnStartProbeJKTest.Click += new System.EventHandler(this.btnStartProbeJKTest_Click);
			this.dataGridView5.AllowUserToAddRows = false;
			this.dataGridView5.AllowUserToDeleteRows = false;
			this.dataGridView5.AllowUserToResizeColumns = false;
			this.dataGridView5.AllowUserToResizeRows = false;
			this.dataGridView5.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Color window3 = System.Drawing.SystemColors.Window;
			this.dataGridView5.BackgroundColor = window3;
			this.dataGridView5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns3 = new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn10,
				this.dataGridViewTextBoxColumn11,
				this.dataGridViewTextBoxColumn12,
				this.dataGridViewTextBoxColumn13,
				this.dataGridViewTextBoxColumn14
			};
			this.dataGridView5.Columns.AddRange(dataGridViewColumns3);
			System.Drawing.Point location26 = new System.Drawing.Point(11, 110);
			this.dataGridView5.Location = location26;
			Padding margin26 = new Padding(2);
			this.dataGridView5.Margin = margin26;
			this.dataGridView5.MultiSelect = false;
			this.dataGridView5.Name = "dataGridView5";
			this.dataGridView5.RowHeadersVisible = false;
			this.dataGridView5.RowTemplate.Height = 27;
			this.dataGridView5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size26 = new System.Drawing.Size(715, 223);
			this.dataGridView5.Size = size26;
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
			System.Drawing.Point location27 = new System.Drawing.Point(26, 22);
			this.radioButton_Probe_JK.Location = location27;
			Padding margin27 = new Padding(2);
			this.radioButton_Probe_JK.Margin = margin27;
			this.radioButton_Probe_JK.Name = "radioButton_Probe_JK";
			System.Drawing.Size size27 = new System.Drawing.Size(85, 19);
			this.radioButton_Probe_JK.Size = size27;
			this.radioButton_Probe_JK.TabIndex = 52;
			this.radioButton_Probe_JK.TabStop = true;
			this.radioButton_Probe_JK.Text = "接口方式";
			this.radioButton_Probe_JK.UseVisualStyleBackColor = true;
			this.label_Probe_JK_DTYZ_unit.AutoSize = true;
			System.Drawing.Point location28 = new System.Drawing.Point(306, 62);
			this.label_Probe_JK_DTYZ_unit.Location = location28;
			Padding margin28 = new Padding(2, 0, 2, 0);
			this.label_Probe_JK_DTYZ_unit.Margin = margin28;
			this.label_Probe_JK_DTYZ_unit.Name = "label_Probe_JK_DTYZ_unit";
			System.Drawing.Size size28 = new System.Drawing.Size(22, 15);
			this.label_Probe_JK_DTYZ_unit.Size = size28;
			this.label_Probe_JK_DTYZ_unit.TabIndex = 64;
			this.label_Probe_JK_DTYZ_unit.Text = "Ω";
			this.label_Probe_JK.AutoSize = true;
			System.Drawing.Point location29 = new System.Drawing.Point(127, 23);
			this.label_Probe_JK.Location = location29;
			Padding margin29 = new Padding(2, 0, 2, 0);
			this.label_Probe_JK.Margin = margin29;
			this.label_Probe_JK.Name = "label_Probe_JK";
			System.Drawing.Size size29 = new System.Drawing.Size(75, 15);
			this.label_Probe_JK.Size = size29;
			this.label_Probe_JK.TabIndex = 60;
			this.label_Probe_JK.Text = "测试接口:";
			System.Drawing.Point location30 = new System.Drawing.Point(209, 58);
			this.numericUpDown_Probe_JK_DTYZ.Location = location30;
			Padding margin30 = new Padding(2);
			this.numericUpDown_Probe_JK_DTYZ.Margin = margin30;
			decimal maximum5 = new decimal(new int[]
			{
				1500,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_JK_DTYZ.Maximum = maximum5;
			this.numericUpDown_Probe_JK_DTYZ.Name = "numericUpDown_Probe_JK_DTYZ";
			System.Drawing.Size size30 = new System.Drawing.Size(90, 24);
			this.numericUpDown_Probe_JK_DTYZ.Size = size30;
			this.numericUpDown_Probe_JK_DTYZ.TabIndex = 63;
			this.numericUpDown_Probe_JK_DTYZ.TextAlign = HorizontalAlignment.Center;
			decimal value5 = new decimal(new int[]
			{
				1000,
				0,
				0,
				0
			});
			this.numericUpDown_Probe_JK_DTYZ.Value = value5;
			this.comboBox_Probe_JK.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_Probe_JK.FormattingEnabled = true;
			System.Drawing.Point location31 = new System.Drawing.Point(209, 20);
			this.comboBox_Probe_JK.Location = location31;
			Padding margin31 = new Padding(2);
			this.comboBox_Probe_JK.Margin = margin31;
			this.comboBox_Probe_JK.Name = "comboBox_Probe_JK";
			System.Drawing.Size size31 = new System.Drawing.Size(289, 22);
			this.comboBox_Probe_JK.Size = size31;
			this.comboBox_Probe_JK.TabIndex = 61;
			this.label_Probe_JK_DTYZ.AutoSize = true;
			System.Drawing.Point location32 = new System.Drawing.Point(127, 62);
			this.label_Probe_JK_DTYZ.Location = location32;
			Padding margin32 = new Padding(2, 0, 2, 0);
			this.label_Probe_JK_DTYZ.Margin = margin32;
			this.label_Probe_JK_DTYZ.Name = "label_Probe_JK_DTYZ";
			System.Drawing.Size size32 = new System.Drawing.Size(75, 15);
			this.label_Probe_JK_DTYZ.Size = size32;
			this.label_Probe_JK_DTYZ.TabIndex = 62;
			this.label_Probe_JK_DTYZ.Text = "导通阈值:";
			this.progressBar1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Color green = System.Drawing.Color.Green;
			this.progressBar1.ForeColor = green;
			System.Drawing.Point location33 = new System.Drawing.Point(10, 539);
			this.progressBar1.Location = location33;
			Padding margin33 = new Padding(2);
			this.progressBar1.Margin = margin33;
			this.progressBar1.Name = "progressBar1";
			System.Drawing.Size size33 = new System.Drawing.Size(723, 19);
			this.progressBar1.Size = size33;
			this.progressBar1.TabIndex = 3;
			this.label_progress.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			System.Drawing.Point location34 = new System.Drawing.Point(745, 540);
			this.label_progress.Location = location34;
			Padding margin34 = new Padding(2, 0, 2, 0);
			this.label_progress.Margin = margin34;
			this.label_progress.Name = "label_progress";
			System.Drawing.Size size34 = new System.Drawing.Size(38, 18);
			this.label_progress.Size = size34;
			this.label_progress.TabIndex = 4;
			this.label_progress.Text = "0 %";
			this.label_progress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.timer_updatePro.Interval = 1000;
			this.timer_updatePro.Tick += new System.EventHandler(this.timer_updatePro_Tick);
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
			System.Drawing.Size size35 = new System.Drawing.Size(165, 54);
			this.contextMenuStrip_DataProc.Size = size35;
			this.toolStripMenuItem_ClearData.Name = "toolStripMenuItem_ClearData";
			System.Drawing.Size size36 = new System.Drawing.Size(164, 22);
			this.toolStripMenuItem_ClearData.Size = size36;
			this.toolStripMenuItem_ClearData.Text = "清除表格数据";
			this.toolStripMenuItem_ClearData.Click += new System.EventHandler(this.toolStripMenuItem_ClearData_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			System.Drawing.Size size37 = new System.Drawing.Size(161, 6);
			this.toolStripSeparator1.Size = size37;
			this.toolStripMenuItem_ExportData.Name = "toolStripMenuItem_ExportData";
			System.Drawing.Size size38 = new System.Drawing.Size(164, 22);
			this.toolStripMenuItem_ExportData.Size = size38;
			this.toolStripMenuItem_ExportData.Text = "导出表格数据";
			this.toolStripMenuItem_ExportData.Click += new System.EventHandler(this.toolStripMenuItem_ExportData_Click);
			this.timerWait.Interval = 1000;
			this.timerWait.Tick += new System.EventHandler(this.timerWait_Tick);
			this.timerZXXWait.Interval = 1000;
			this.timerZXXWait.Tick += new System.EventHandler(this.timerZXXWait_Tick);
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
			Padding margin35 = new Padding(2);
			base.Margin = margin35;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormProbeMeasure";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "探针";
			base.FormClosing += new FormClosingEventHandler(this.ctFormProbeMeasure_FormClosing);
			base.Load += new System.EventHandler(this.ctFormProbeMeasure_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormProbeMeasure_SizeChanged);
			this.groupBox_Debugging.ResumeLayout(false);
			this.tabControl_Debugging.ResumeLayout(false);
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
			this.contextMenuStrip_DataProc.ResumeLayout(false);
			base.ResumeLayout(false);
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
		private void ctFormProbeMeasure_Load(object sender, System.EventArgs e)
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
				this.dataGridView3.Rows.Clear();
				for (int i = 0; i < this.dataGridView3.Columns.Count; i++)
				{
					this.dataGridView3.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					this.dataGridView3.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				for (int j = 0; j < this.dataGridView3.Columns.Count; j++)
				{
					this.dataGridView3.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				for (int k = 0; k < this.dataGridView4.Columns.Count; k++)
				{
					this.dataGridView4.Columns[k].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					this.dataGridView4.Columns[k].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				for (int l = 0; l < this.dataGridView4.Columns.Count; l++)
				{
					this.dataGridView4.Columns[l].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				for (int m = 0; m < this.dataGridView5.Columns.Count; m++)
				{
					this.dataGridView5.Columns[m].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					this.dataGridView5.Columns[m].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				for (int n = 0; n < this.dataGridView5.Columns.Count; n++)
				{
					this.dataGridView5.Columns[n].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
			}
			catch (System.Exception arg_204_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_204_0.StackTrace);
			}
			this.AddComboBoxProbeJKFunc();
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode == 0)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
			catch (System.Exception arg_22C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_22C_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
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
				this.testtype = 5;
				int iCount = this.testcount;
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
					this.gLineTestProcessor.SendDTVlotAndCurrentCmd(250.0, 2000.0);
					System.Threading.Thread.Sleep(200);
					this.gLineTestProcessor.DownProbeAddrCmd(this.iStartValue, this.iEndValue, this.iDTLimitedValue);
					this.testcount = 1 - this.iStartValue + this.iEndValue;
				}
				else if (this.bProbeJKTestFlag)
				{
					this.gLineTestProcessor.SendDTVlotAndCurrentCmd(250.0, 2000.0);
					System.Threading.Thread.Sleep(200);
					this.gLineTestProcessor.DownProbeAddrCmd(this.iStartValue, this.iEndValue, this.iDTLimitedValue);
					this.testcount = this.gLineTestProcessor.iPort1Array.Count;
				}
				else
				{
					for (int j = 0; j < iCount; j++)
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
				int num = this.currcount + 1;
				this.currcount = num;
				this.gLineTestProcessor.currcount = num;
			}
			catch (System.Exception arg_21F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_21F_0.StackTrace);
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
				System.Threading.Thread.Sleep(100);
				this.gLineTestProcessor.SendStopCmd();
			}
			catch (System.Exception arg_50_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_50_0.StackTrace);
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
									goto IL_2C9;
								}
							}
							MessageBox.Show("参数范围设置错误，只能设置在1至" + System.Convert.ToInt32(this.gLineTestProcessor.SELF_MAX_COUNT) + "范围内，并且后者大于前者!", "提示", MessageBoxButtons.OK);
							result = 0;
							return result != 0;
						}
						catch (System.Exception ex_101)
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
						this.iStartValue = this.gLineTestProcessor.iPort1Array[0];
						this.iEndValue = this.gLineTestProcessor.iPort1Array[0];
						for (int i = 0; i < this.gLineTestProcessor.iPort1Array.Count; i++)
						{
							if (this.gLineTestProcessor.iPort1Array[i] < this.iStartValue)
							{
								this.iStartValue = this.gLineTestProcessor.iPort1Array[i];
							}
							if (this.gLineTestProcessor.iPort1Array[i] > this.iEndValue)
							{
								this.iEndValue = this.gLineTestProcessor.iPort1Array[i];
							}
						}
					}
				}
				IL_2C9:
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
			catch (System.Exception arg_3E2_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3E2_0.StackTrace);
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
				this.timer_updatePro.Enabled = false;
				this.gLineTestProcessor.mbKeepRun = false;
				this.gLineTestProcessor.SendStopCmd();
			}
			catch (System.Exception arg_93_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_93_0.StackTrace);
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
				bool bStopFlag = false;
				bool bShowFlag = true;
				if (this.bProbeFWTestFlag)
				{
					for (int i = 0; i < this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count; i++)
					{
						this.dTestResultValue = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mdTestResult;
						int iPortTemp = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[i].mMainDevPinNum;
						if (iPortTemp == 65535)
						{
							bStopFlag = true;
							break;
						}
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
							catch (System.Exception ex_236)
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
					if (bStopFlag)
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
						if (iPortTemp == 65535)
						{
							bStopFlag = true;
							break;
						}
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
								int i2 = this.dataGridView5.Rows.Count;
								this.dataGridView5.AllowUserToAddRows = true;
								this.dataGridView5.Rows.Add(1);
								this.dataGridView5.Rows[k].Cells[0].Value = System.Convert.ToString(i2 + 1);
								this.dataGridView5.Rows[k].Cells[1].Value = this.jkNameStr;
								this.dataGridView5.Rows[k].Cells[2].Value = jkjdStr;
								this.dataGridView5.Rows[k].Cells[3].Value = "探针";
								this.dataGridView5.Rows[k].Cells[4].Value = strvalue2;
								this.dataGridView5.AllowUserToAddRows = false;
								this.dataGridView5.Rows[k].Selected = false;
							}
							catch (System.Exception ex_4D6)
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
					if (bStopFlag)
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
								int m = this.dataGridView3.Rows.Count;
								this.dataGridView3.AllowUserToAddRows = true;
								this.dataGridView3.Rows.Add(1);
								this.dataGridView3.Rows[m].Cells[0].Value = System.Convert.ToString(m + 1);
								this.dataGridView3.Rows[m].Cells[1].Value = System.Convert.ToString(iPortTemp);
								this.dataGridView3.Rows[m].Cells[2].Value = "探针";
								this.dataGridView3.Rows[m].Cells[3].Value = strvalue3;
								this.dataGridView3.AllowUserToAddRows = false;
								this.dataGridView3.Rows[m].Selected = false;
							}
							catch (System.Exception ex_72E)
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
			catch (System.Exception arg_80E_0)
			{
				this.dataGridView3.AllowUserToAddRows = false;
				this.dataGridView4.AllowUserToAddRows = false;
				this.dataGridView5.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_80E_0.StackTrace);
			}
		}
		private void tabControl_Debugging_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.ctFormProbeMeasure_SizeChanged(null, null);
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
					int ib = this.dataGridView3.Width - 700;
					if (ib < 0)
					{
						ib = 0;
					}
					int num = ib / 3;
					int ic = num;
					int iv = ib - num * 3;
					this.dataGridView3.Columns[0].Width = iv + 76;
					int width = ic + 200;
					this.dataGridView3.Columns[1].Width = width;
					this.dataGridView3.Columns[2].Width = width;
					this.dataGridView3.Columns[3].Width = width;
					ib = this.dataGridView4.Width - 700;
					if (ib < 0)
					{
						ib = 0;
					}
					int num2 = ib / 3;
					ic = num2;
					iv = ib - num2 * 3;
					this.dataGridView4.Columns[0].Width = iv + 76;
					int width2 = ic + 200;
					this.dataGridView4.Columns[1].Width = width2;
					this.dataGridView4.Columns[2].Width = width2;
					this.dataGridView4.Columns[3].Width = width2;
					ib = this.dataGridView5.Width - 700;
					if (ib < 0)
					{
						ib = 0;
					}
					ic = ib / 4;
					iv = ib % 4;
					this.dataGridView5.Columns[0].Width = iv + 76;
					int width3 = ic + 150;
					this.dataGridView5.Columns[1].Width = width3;
					this.dataGridView5.Columns[2].Width = width3;
					this.dataGridView5.Columns[3].Width = width3;
					this.dataGridView5.Columns[4].Width = width3;
				}
			}
			catch (System.Exception arg_1DC_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1DC_0.StackTrace);
			}
		}
		private void ctFormProbeMeasure_SizeChanged(object sender, System.EventArgs e)
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
		private void ctFormProbeMeasure_FormClosing(object sender, FormClosingEventArgs e)
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
				if (this.timerWait.Enabled)
				{
					this.timerWait.Enabled = false;
				}
				this.StartTest();
			}
			catch (System.Exception arg_21_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_21_0.StackTrace);
			}
		}
		private void timerZXXWait_Tick(object sender, System.EventArgs e)
		{
			try
			{
				if (this.timerZXXWait.Enabled)
				{
					this.timerZXXWait.Enabled = false;
				}
				this.gLineTestProcessor.SendSelfStudyCmd(this.iStartValue, this.iEndValue, this.iDTLimitedValue);
			}
			catch (System.Exception arg_38_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_38_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormProbeMeasure();
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
