using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormComponentMeasure : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public bool bDZTestFlag;
		public bool bDRTestFlag;
		public bool bDGTestFlag;
		public int iProValue;
		public string loginUser;
		public string dbpath;
		public string currDevFreqStr;
		public bool bSetBridgeFreqErrFlag;
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
		private Label label_bSetDGFreqErrTS;
		private System.Windows.Forms.Timer timer_waitfk;
		private ComboBox comboBox_DRFreq;
		private Label label6;
		private ComboBox comboBox_DGFreq;
		private Label label1;
		private Label label_bSetDRFreqErrTS;
		private Label label_progress;
		private TabPage tabPage1;
		private TabPage tabPage3;
		private IContainer components;
		private Label label_DRtv_unit;
		private TabControl tabControl1;
		private TabPage tabPage2;
		private Button btnDRStartTest;
		private Button btnDZStartTest;
		private GroupBox groupBox3;
		private Label label_DZtr;
		private TextBox textBox_DZtr;
		private Label label_DZtv;
		private TextBox textBox_DZtv;
		private Label label_DZtv_unit;
		private Button btnDGStartTest;
		private GroupBox groupBox4;
		private Label label_DGtr;
		private TextBox textBox_DGtr;
		private Label label_DGtv;
		private TextBox textBox_DGtv;
		private Label label_DGtv_unit;
		private RadioButton radioButton_gdzj;
		private RadioButton radioButton_zdzj;
		private GroupBox groupBox2;
		private ComboBox comboBox_stopPin;
		private Label label_stopPin;
		private ComboBox comboBox_startPin;
		private Label label_startPin;
		private GroupBox groupBox1;
		private Label label_DRtr;
		private TextBox textBox_DRtr;
		private Label label_DRtv;
		private TextBox textBox_DRtv;
		private Label label11;
		private ProgressBar progressBar_test;
		private Label label3;
		private System.Windows.Forms.Timer timer_tt;
		private Button btnQuit;
		public ctFormComponentMeasure(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
				}
				catch (System.Exception ex_36)
				{
				}
				this.SysControlInitFunc();
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormComponentMeasure()
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
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormComponentMeasure));
			this.label_DRtv_unit = new Label();
			this.tabControl1 = new TabControl();
			this.tabPage1 = new TabPage();
			this.btnDZStartTest = new Button();
			this.groupBox3 = new GroupBox();
			this.label_DZtr = new Label();
			this.textBox_DZtr = new TextBox();
			this.label_DZtv = new Label();
			this.textBox_DZtv = new TextBox();
			this.label_DZtv_unit = new Label();
			this.tabPage2 = new TabPage();
			this.label_bSetDRFreqErrTS = new Label();
			this.comboBox_DRFreq = new ComboBox();
			this.label6 = new Label();
			this.btnDRStartTest = new Button();
			this.groupBox1 = new GroupBox();
			this.label_DRtr = new Label();
			this.textBox_DRtr = new TextBox();
			this.label_DRtv = new Label();
			this.textBox_DRtv = new TextBox();
			this.label3 = new Label();
			this.tabPage3 = new TabPage();
			this.label_bSetDGFreqErrTS = new Label();
			this.comboBox_DGFreq = new ComboBox();
			this.label1 = new Label();
			this.btnDGStartTest = new Button();
			this.groupBox4 = new GroupBox();
			this.label_DGtr = new Label();
			this.textBox_DGtr = new TextBox();
			this.label_DGtv = new Label();
			this.textBox_DGtv = new TextBox();
			this.label_DGtv_unit = new Label();
			this.label11 = new Label();
			this.progressBar_test = new ProgressBar();
			this.timer_tt = new System.Windows.Forms.Timer(this.components);
			this.btnQuit = new Button();
			this.radioButton_gdzj = new RadioButton();
			this.radioButton_zdzj = new RadioButton();
			this.groupBox2 = new GroupBox();
			this.comboBox_stopPin = new ComboBox();
			this.label_stopPin = new Label();
			this.comboBox_startPin = new ComboBox();
			this.label_startPin = new Label();
			this.label_progress = new Label();
			this.timer_waitfk = new System.Windows.Forms.Timer(this.components);
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.label_DRtv_unit.Anchor = AnchorStyles.Top;
			this.label_DRtv_unit.AutoSize = true;
			System.Drawing.Point location = new System.Drawing.Point(338, 33);
			this.label_DRtv_unit.Location = location;
			Padding margin = new Padding(2, 0, 2, 0);
			this.label_DRtv_unit.Margin = margin;
			this.label_DRtv_unit.Name = "label_DRtv_unit";
			System.Drawing.Size size = new System.Drawing.Size(15, 15);
			this.label_DRtv_unit.Size = size;
			this.label_DRtv_unit.TabIndex = 41;
			this.label_DRtv_unit.Text = "F";
			this.tabControl1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom);
			this.tabControl1.Appearance = TabAppearance.Buttons;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Size itemSize = new System.Drawing.Size(200, 30);
			this.tabControl1.ItemSize = itemSize;
			System.Drawing.Point location2 = new System.Drawing.Point(41, 134);
			this.tabControl1.Location = location2;
			Padding margin2 = new Padding(2, 2, 2, 2);
			this.tabControl1.Margin = margin2;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			System.Drawing.Size size2 = new System.Drawing.Size(735, 327);
			this.tabControl1.Size = size2;
			this.tabControl1.SizeMode = TabSizeMode.Fixed;
			this.tabControl1.TabIndex = 24;
			this.tabPage1.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage1.Controls.Add(this.btnDZStartTest);
			this.tabPage1.Controls.Add(this.groupBox3);
			System.Drawing.Point location3 = new System.Drawing.Point(4, 34);
			this.tabPage1.Location = location3;
			Padding margin3 = new Padding(2, 2, 2, 2);
			this.tabPage1.Margin = margin3;
			this.tabPage1.Name = "tabPage1";
			Padding padding = new Padding(2, 2, 2, 2);
			this.tabPage1.Padding = padding;
			System.Drawing.Size size3 = new System.Drawing.Size(727, 289);
			this.tabPage1.Size = size3;
			this.tabPage1.TabIndex = 2;
			this.tabPage1.Text = "电阻测试";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.btnDZStartTest.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(281, 84);
			this.btnDZStartTest.Location = location4;
			Padding margin4 = new Padding(2, 2, 2, 2);
			this.btnDZStartTest.Margin = margin4;
			this.btnDZStartTest.Name = "btnDZStartTest";
			System.Drawing.Size size4 = new System.Drawing.Size(135, 24);
			this.btnDZStartTest.Size = size4;
			this.btnDZStartTest.TabIndex = 78;
			this.btnDZStartTest.Text = "启动测试";
			this.btnDZStartTest.UseVisualStyleBackColor = true;
			this.btnDZStartTest.Click += new System.EventHandler(this.btnDZStartTest_Click);
			this.groupBox3.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox3.Controls.Add(this.label_DZtr);
			this.groupBox3.Controls.Add(this.textBox_DZtr);
			this.groupBox3.Controls.Add(this.label_DZtv);
			this.groupBox3.Controls.Add(this.textBox_DZtv);
			this.groupBox3.Controls.Add(this.label_DZtv_unit);
			System.Drawing.Point location5 = new System.Drawing.Point(38, 205);
			this.groupBox3.Location = location5;
			Padding margin5 = new Padding(2, 2, 2, 2);
			this.groupBox3.Margin = margin5;
			this.groupBox3.Name = "groupBox3";
			Padding padding2 = new Padding(2, 2, 2, 2);
			this.groupBox3.Padding = padding2;
			System.Drawing.Size size5 = new System.Drawing.Size(651, 74);
			this.groupBox3.Size = size5;
			this.groupBox3.TabIndex = 77;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "测试结果";
			this.label_DZtr.Anchor = AnchorStyles.Top;
			this.label_DZtr.AutoSize = true;
			System.Drawing.Point location6 = new System.Drawing.Point(405, 33);
			this.label_DZtr.Location = location6;
			Padding margin6 = new Padding(2, 0, 2, 0);
			this.label_DZtr.Margin = margin6;
			this.label_DZtr.Name = "label_DZtr";
			System.Drawing.Size size6 = new System.Drawing.Size(75, 15);
			this.label_DZtr.Size = size6;
			this.label_DZtr.TabIndex = 55;
			this.label_DZtr.Text = "测试结论:";
			this.label_DZtr.Visible = false;
			this.textBox_DZtr.Anchor = AnchorStyles.Top;
			System.Drawing.Color control = System.Drawing.SystemColors.Control;
			this.textBox_DZtr.BackColor = control;
			System.Drawing.Color windowText = System.Drawing.SystemColors.WindowText;
			this.textBox_DZtr.ForeColor = windowText;
			System.Drawing.Point location7 = new System.Drawing.Point(488, 29);
			this.textBox_DZtr.Location = location7;
			Padding margin7 = new Padding(2, 2, 2, 2);
			this.textBox_DZtr.Margin = margin7;
			this.textBox_DZtr.Name = "textBox_DZtr";
			this.textBox_DZtr.ReadOnly = true;
			System.Drawing.Size size7 = new System.Drawing.Size(114, 24);
			this.textBox_DZtr.Size = size7;
			this.textBox_DZtr.TabIndex = 10;
			this.textBox_DZtr.Text = "合格";
			this.textBox_DZtr.TextAlign = HorizontalAlignment.Center;
			this.textBox_DZtr.Visible = false;
			this.label_DZtv.Anchor = AnchorStyles.Top;
			this.label_DZtv.AutoSize = true;
			System.Drawing.Point location8 = new System.Drawing.Point(51, 33);
			this.label_DZtv.Location = location8;
			Padding margin8 = new Padding(2, 0, 2, 0);
			this.label_DZtv.Margin = margin8;
			this.label_DZtv.Name = "label_DZtv";
			System.Drawing.Size size8 = new System.Drawing.Size(90, 15);
			this.label_DZtv.Size = size8;
			this.label_DZtv.TabIndex = 37;
			this.label_DZtv.Text = "电阻测试值:";
			this.textBox_DZtv.Anchor = AnchorStyles.Top;
			System.Drawing.Point location9 = new System.Drawing.Point(152, 29);
			this.textBox_DZtv.Location = location9;
			Padding margin9 = new Padding(2, 2, 2, 2);
			this.textBox_DZtv.Margin = margin9;
			this.textBox_DZtv.Name = "textBox_DZtv";
			this.textBox_DZtv.ReadOnly = true;
			System.Drawing.Size size9 = new System.Drawing.Size(181, 24);
			this.textBox_DZtv.Size = size9;
			this.textBox_DZtv.TabIndex = 11;
			this.textBox_DZtv.TextAlign = HorizontalAlignment.Center;
			this.label_DZtv_unit.Anchor = AnchorStyles.Top;
			this.label_DZtv_unit.AutoSize = true;
			System.Drawing.Point location10 = new System.Drawing.Point(338, 33);
			this.label_DZtv_unit.Location = location10;
			Padding margin10 = new Padding(2, 0, 2, 0);
			this.label_DZtv_unit.Margin = margin10;
			this.label_DZtv_unit.Name = "label_DZtv_unit";
			System.Drawing.Size size10 = new System.Drawing.Size(22, 15);
			this.label_DZtv_unit.Size = size10;
			this.label_DZtv_unit.TabIndex = 41;
			this.label_DZtv_unit.Text = "Ω";
			System.Drawing.Color control2 = System.Drawing.SystemColors.Control;
			this.tabPage2.BackColor = control2;
			this.tabPage2.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage2.Controls.Add(this.label_bSetDRFreqErrTS);
			this.tabPage2.Controls.Add(this.comboBox_DRFreq);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.btnDRStartTest);
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location11 = new System.Drawing.Point(4, 34);
			this.tabPage2.Location = location11;
			Padding margin11 = new Padding(2, 2, 2, 2);
			this.tabPage2.Margin = margin11;
			this.tabPage2.Name = "tabPage2";
			Padding padding3 = new Padding(2, 2, 2, 2);
			this.tabPage2.Padding = padding3;
			System.Drawing.Size size11 = new System.Drawing.Size(727, 289);
			this.tabPage2.Size = size11;
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "电容测试";
			System.Drawing.Color red = System.Drawing.Color.Red;
			this.label_bSetDRFreqErrTS.ForeColor = red;
			System.Drawing.Point location12 = new System.Drawing.Point(1, 112);
			this.label_bSetDRFreqErrTS.Location = location12;
			Padding margin12 = new Padding(2, 0, 2, 0);
			this.label_bSetDRFreqErrTS.Margin = margin12;
			this.label_bSetDRFreqErrTS.Name = "label_bSetDRFreqErrTS";
			System.Drawing.Size size12 = new System.Drawing.Size(696, 24);
			this.label_bSetDRFreqErrTS.Size = size12;
			this.label_bSetDRFreqErrTS.TabIndex = 79;
			this.label_bSetDRFreqErrTS.Text = "设置测试频率响应异常!";
			this.label_bSetDRFreqErrTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label_bSetDRFreqErrTS.Visible = false;
			this.comboBox_DRFreq.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_DRFreq.FormattingEnabled = true;
			object[] items = new object[]
			{
				"100Hz",
				"1kHz",
				"10kHz"
			};
			this.comboBox_DRFreq.Items.AddRange(items);
			System.Drawing.Point location13 = new System.Drawing.Point(176, 52);
			this.comboBox_DRFreq.Location = location13;
			Padding margin13 = new Padding(2, 2, 2, 2);
			this.comboBox_DRFreq.Margin = margin13;
			this.comboBox_DRFreq.Name = "comboBox_DRFreq";
			System.Drawing.Size size13 = new System.Drawing.Size(181, 22);
			this.comboBox_DRFreq.Size = size13;
			this.comboBox_DRFreq.TabIndex = 77;
			this.label6.AutoSize = true;
			System.Drawing.Point location14 = new System.Drawing.Point(60, 55);
			this.label6.Location = location14;
			Padding margin14 = new Padding(2, 0, 2, 0);
			this.label6.Margin = margin14;
			this.label6.Name = "label6";
			System.Drawing.Size size14 = new System.Drawing.Size(105, 15);
			this.label6.Size = size14;
			this.label6.TabIndex = 78;
			this.label6.Text = "测试频率设置:";
			this.btnDRStartTest.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location15 = new System.Drawing.Point(472, 50);
			this.btnDRStartTest.Location = location15;
			Padding margin15 = new Padding(2, 2, 2, 2);
			this.btnDRStartTest.Margin = margin15;
			this.btnDRStartTest.Name = "btnDRStartTest";
			System.Drawing.Size size15 = new System.Drawing.Size(135, 24);
			this.btnDRStartTest.Size = size15;
			this.btnDRStartTest.TabIndex = 76;
			this.btnDRStartTest.Text = "启动测试";
			this.btnDRStartTest.UseVisualStyleBackColor = true;
			this.btnDRStartTest.Click += new System.EventHandler(this.btnDRStartTest_Click);
			this.groupBox1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.label_DRtr);
			this.groupBox1.Controls.Add(this.textBox_DRtr);
			this.groupBox1.Controls.Add(this.label_DRtv);
			this.groupBox1.Controls.Add(this.textBox_DRtv);
			this.groupBox1.Controls.Add(this.label_DRtv_unit);
			System.Drawing.Point location16 = new System.Drawing.Point(38, 205);
			this.groupBox1.Location = location16;
			Padding margin16 = new Padding(2, 2, 2, 2);
			this.groupBox1.Margin = margin16;
			this.groupBox1.Name = "groupBox1";
			Padding padding4 = new Padding(2, 2, 2, 2);
			this.groupBox1.Padding = padding4;
			System.Drawing.Size size16 = new System.Drawing.Size(651, 74);
			this.groupBox1.Size = size16;
			this.groupBox1.TabIndex = 71;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "测试结果";
			this.label_DRtr.Anchor = AnchorStyles.Top;
			this.label_DRtr.AutoSize = true;
			System.Drawing.Point location17 = new System.Drawing.Point(405, 33);
			this.label_DRtr.Location = location17;
			Padding margin17 = new Padding(2, 0, 2, 0);
			this.label_DRtr.Margin = margin17;
			this.label_DRtr.Name = "label_DRtr";
			System.Drawing.Size size17 = new System.Drawing.Size(75, 15);
			this.label_DRtr.Size = size17;
			this.label_DRtr.TabIndex = 55;
			this.label_DRtr.Text = "测试频率:";
			this.textBox_DRtr.Anchor = AnchorStyles.Top;
			System.Drawing.Color control3 = System.Drawing.SystemColors.Control;
			this.textBox_DRtr.BackColor = control3;
			System.Drawing.Color windowText2 = System.Drawing.SystemColors.WindowText;
			this.textBox_DRtr.ForeColor = windowText2;
			System.Drawing.Point location18 = new System.Drawing.Point(488, 29);
			this.textBox_DRtr.Location = location18;
			Padding margin18 = new Padding(2, 2, 2, 2);
			this.textBox_DRtr.Margin = margin18;
			this.textBox_DRtr.Name = "textBox_DRtr";
			this.textBox_DRtr.ReadOnly = true;
			System.Drawing.Size size18 = new System.Drawing.Size(114, 24);
			this.textBox_DRtr.Size = size18;
			this.textBox_DRtr.TabIndex = 10;
			this.textBox_DRtr.TextAlign = HorizontalAlignment.Center;
			this.label_DRtv.Anchor = AnchorStyles.Top;
			this.label_DRtv.AutoSize = true;
			System.Drawing.Point location19 = new System.Drawing.Point(51, 33);
			this.label_DRtv.Location = location19;
			Padding margin19 = new Padding(2, 0, 2, 0);
			this.label_DRtv.Margin = margin19;
			this.label_DRtv.Name = "label_DRtv";
			System.Drawing.Size size19 = new System.Drawing.Size(90, 15);
			this.label_DRtv.Size = size19;
			this.label_DRtv.TabIndex = 37;
			this.label_DRtv.Text = "电容测试值:";
			this.textBox_DRtv.Anchor = AnchorStyles.Top;
			System.Drawing.Point location20 = new System.Drawing.Point(152, 29);
			this.textBox_DRtv.Location = location20;
			Padding margin20 = new Padding(2, 2, 2, 2);
			this.textBox_DRtv.Margin = margin20;
			this.textBox_DRtv.Name = "textBox_DRtv";
			this.textBox_DRtv.ReadOnly = true;
			System.Drawing.Size size20 = new System.Drawing.Size(181, 24);
			this.textBox_DRtv.Size = size20;
			this.textBox_DRtv.TabIndex = 11;
			this.textBox_DRtv.TextAlign = HorizontalAlignment.Center;
			this.label3.Anchor = AnchorStyles.Top;
			this.label3.AutoSize = true;
			System.Drawing.Point location21 = new System.Drawing.Point(695, 113);
			this.label3.Location = location21;
			Padding margin21 = new Padding(2, 0, 2, 0);
			this.label3.Margin = margin21;
			this.label3.Name = "label3";
			System.Drawing.Size size21 = new System.Drawing.Size(0, 15);
			this.label3.Size = size21;
			this.label3.TabIndex = 31;
			this.tabPage3.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage3.Controls.Add(this.label_bSetDGFreqErrTS);
			this.tabPage3.Controls.Add(this.comboBox_DGFreq);
			this.tabPage3.Controls.Add(this.label1);
			this.tabPage3.Controls.Add(this.btnDGStartTest);
			this.tabPage3.Controls.Add(this.groupBox4);
			System.Drawing.Point location22 = new System.Drawing.Point(4, 34);
			this.tabPage3.Location = location22;
			Padding margin22 = new Padding(2, 2, 2, 2);
			this.tabPage3.Margin = margin22;
			this.tabPage3.Name = "tabPage3";
			Padding padding5 = new Padding(2, 2, 2, 2);
			this.tabPage3.Padding = padding5;
			System.Drawing.Size size22 = new System.Drawing.Size(727, 289);
			this.tabPage3.Size = size22;
			this.tabPage3.TabIndex = 3;
			this.tabPage3.Text = "电感测试";
			this.tabPage3.UseVisualStyleBackColor = true;
			System.Drawing.Color red2 = System.Drawing.Color.Red;
			this.label_bSetDGFreqErrTS.ForeColor = red2;
			System.Drawing.Point location23 = new System.Drawing.Point(1, 112);
			this.label_bSetDGFreqErrTS.Location = location23;
			Padding margin23 = new Padding(2, 0, 2, 0);
			this.label_bSetDGFreqErrTS.Margin = margin23;
			this.label_bSetDGFreqErrTS.Name = "label_bSetDGFreqErrTS";
			System.Drawing.Size size23 = new System.Drawing.Size(696, 24);
			this.label_bSetDGFreqErrTS.Size = size23;
			this.label_bSetDGFreqErrTS.TabIndex = 81;
			this.label_bSetDGFreqErrTS.Text = "设置测试频率响应异常!";
			this.label_bSetDGFreqErrTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label_bSetDGFreqErrTS.Visible = false;
			this.comboBox_DGFreq.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_DGFreq.FormattingEnabled = true;
			object[] items2 = new object[]
			{
				"100Hz",
				"1kHz",
				"10kHz"
			};
			this.comboBox_DGFreq.Items.AddRange(items2);
			System.Drawing.Point location24 = new System.Drawing.Point(176, 52);
			this.comboBox_DGFreq.Location = location24;
			Padding margin24 = new Padding(2, 2, 2, 2);
			this.comboBox_DGFreq.Margin = margin24;
			this.comboBox_DGFreq.Name = "comboBox_DGFreq";
			System.Drawing.Size size24 = new System.Drawing.Size(181, 22);
			this.comboBox_DGFreq.Size = size24;
			this.comboBox_DGFreq.TabIndex = 79;
			this.label1.AutoSize = true;
			System.Drawing.Point location25 = new System.Drawing.Point(60, 55);
			this.label1.Location = location25;
			Padding margin25 = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin25;
			this.label1.Name = "label1";
			System.Drawing.Size size25 = new System.Drawing.Size(105, 15);
			this.label1.Size = size25;
			this.label1.TabIndex = 80;
			this.label1.Text = "测试频率设置:";
			this.btnDGStartTest.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location26 = new System.Drawing.Point(472, 50);
			this.btnDGStartTest.Location = location26;
			Padding margin26 = new Padding(2, 2, 2, 2);
			this.btnDGStartTest.Margin = margin26;
			this.btnDGStartTest.Name = "btnDGStartTest";
			System.Drawing.Size size26 = new System.Drawing.Size(135, 24);
			this.btnDGStartTest.Size = size26;
			this.btnDGStartTest.TabIndex = 78;
			this.btnDGStartTest.Text = "启动测试";
			this.btnDGStartTest.UseVisualStyleBackColor = true;
			this.btnDGStartTest.Click += new System.EventHandler(this.btnDGStartTest_Click);
			this.groupBox4.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox4.Controls.Add(this.label_DGtr);
			this.groupBox4.Controls.Add(this.textBox_DGtr);
			this.groupBox4.Controls.Add(this.label_DGtv);
			this.groupBox4.Controls.Add(this.textBox_DGtv);
			this.groupBox4.Controls.Add(this.label_DGtv_unit);
			System.Drawing.Point location27 = new System.Drawing.Point(38, 205);
			this.groupBox4.Location = location27;
			Padding margin27 = new Padding(2, 2, 2, 2);
			this.groupBox4.Margin = margin27;
			this.groupBox4.Name = "groupBox4";
			Padding padding6 = new Padding(2, 2, 2, 2);
			this.groupBox4.Padding = padding6;
			System.Drawing.Size size27 = new System.Drawing.Size(651, 74);
			this.groupBox4.Size = size27;
			this.groupBox4.TabIndex = 77;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "测试结果";
			this.label_DGtr.Anchor = AnchorStyles.Top;
			this.label_DGtr.AutoSize = true;
			System.Drawing.Point location28 = new System.Drawing.Point(405, 33);
			this.label_DGtr.Location = location28;
			Padding margin28 = new Padding(2, 0, 2, 0);
			this.label_DGtr.Margin = margin28;
			this.label_DGtr.Name = "label_DGtr";
			System.Drawing.Size size28 = new System.Drawing.Size(75, 15);
			this.label_DGtr.Size = size28;
			this.label_DGtr.TabIndex = 55;
			this.label_DGtr.Text = "测试频率:";
			this.textBox_DGtr.Anchor = AnchorStyles.Top;
			System.Drawing.Color control4 = System.Drawing.SystemColors.Control;
			this.textBox_DGtr.BackColor = control4;
			System.Drawing.Color windowText3 = System.Drawing.SystemColors.WindowText;
			this.textBox_DGtr.ForeColor = windowText3;
			System.Drawing.Point location29 = new System.Drawing.Point(488, 29);
			this.textBox_DGtr.Location = location29;
			Padding margin29 = new Padding(2, 2, 2, 2);
			this.textBox_DGtr.Margin = margin29;
			this.textBox_DGtr.Name = "textBox_DGtr";
			this.textBox_DGtr.ReadOnly = true;
			System.Drawing.Size size29 = new System.Drawing.Size(114, 24);
			this.textBox_DGtr.Size = size29;
			this.textBox_DGtr.TabIndex = 10;
			this.textBox_DGtr.TextAlign = HorizontalAlignment.Center;
			this.label_DGtv.Anchor = AnchorStyles.Top;
			this.label_DGtv.AutoSize = true;
			System.Drawing.Point location30 = new System.Drawing.Point(51, 33);
			this.label_DGtv.Location = location30;
			Padding margin30 = new Padding(2, 0, 2, 0);
			this.label_DGtv.Margin = margin30;
			this.label_DGtv.Name = "label_DGtv";
			System.Drawing.Size size30 = new System.Drawing.Size(90, 15);
			this.label_DGtv.Size = size30;
			this.label_DGtv.TabIndex = 37;
			this.label_DGtv.Text = "电感测试值:";
			this.textBox_DGtv.Anchor = AnchorStyles.Top;
			System.Drawing.Point location31 = new System.Drawing.Point(152, 29);
			this.textBox_DGtv.Location = location31;
			Padding margin31 = new Padding(2, 2, 2, 2);
			this.textBox_DGtv.Margin = margin31;
			this.textBox_DGtv.Name = "textBox_DGtv";
			this.textBox_DGtv.ReadOnly = true;
			System.Drawing.Size size31 = new System.Drawing.Size(181, 24);
			this.textBox_DGtv.Size = size31;
			this.textBox_DGtv.TabIndex = 11;
			this.textBox_DGtv.TextAlign = HorizontalAlignment.Center;
			this.label_DGtv_unit.Anchor = AnchorStyles.Top;
			this.label_DGtv_unit.AutoSize = true;
			System.Drawing.Point location32 = new System.Drawing.Point(338, 33);
			this.label_DGtv_unit.Location = location32;
			Padding margin32 = new Padding(2, 0, 2, 0);
			this.label_DGtv_unit.Margin = margin32;
			this.label_DGtv_unit.Name = "label_DGtv_unit";
			System.Drawing.Size size32 = new System.Drawing.Size(15, 15);
			this.label_DGtv_unit.Size = size32;
			this.label_DGtv_unit.TabIndex = 41;
			this.label_DGtv_unit.Text = "H";
			this.label11.Anchor = AnchorStyles.Bottom;
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location33 = new System.Drawing.Point(67, 471);
			this.label11.Location = location33;
			Padding margin33 = new Padding(2, 0, 2, 0);
			this.label11.Margin = margin33;
			this.label11.Name = "label11";
			System.Drawing.Size size33 = new System.Drawing.Size(75, 15);
			this.label11.Size = size33;
			this.label11.TabIndex = 69;
			this.label11.Text = "测试进度:";
			this.progressBar_test.Anchor = AnchorStyles.Bottom;
			System.Drawing.Color green = System.Drawing.Color.Green;
			this.progressBar_test.ForeColor = green;
			System.Drawing.Point location34 = new System.Drawing.Point(152, 469);
			this.progressBar_test.Location = location34;
			Padding margin34 = new Padding(2, 2, 2, 2);
			this.progressBar_test.Margin = margin34;
			this.progressBar_test.Name = "progressBar_test";
			System.Drawing.Size size34 = new System.Drawing.Size(540, 19);
			this.progressBar_test.Size = size34;
			this.progressBar_test.Step = 1;
			this.progressBar_test.TabIndex = 68;
			this.timer_tt.Interval = 1000;
			this.timer_tt.Tick += new System.EventHandler(this.timer_tt_Tick);
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location35 = new System.Drawing.Point(341, 513);
			this.btnQuit.Location = location35;
			Padding margin35 = new Padding(2, 2, 2, 2);
			this.btnQuit.Margin = margin35;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size35 = new System.Drawing.Size(112, 24);
			this.btnQuit.Size = size35;
			this.btnQuit.TabIndex = 23;
			this.btnQuit.Text = "关闭";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.radioButton_gdzj.AutoSize = true;
			this.radioButton_gdzj.Checked = true;
			this.radioButton_gdzj.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location36 = new System.Drawing.Point(42, 27);
			this.radioButton_gdzj.Location = location36;
			Padding margin36 = new Padding(2, 2, 2, 2);
			this.radioButton_gdzj.Margin = margin36;
			this.radioButton_gdzj.Name = "radioButton_gdzj";
			System.Drawing.Size size36 = new System.Drawing.Size(85, 19);
			this.radioButton_gdzj.Size = size36;
			this.radioButton_gdzj.TabIndex = 75;
			this.radioButton_gdzj.TabStop = true;
			this.radioButton_gdzj.Text = "固定针脚";
			this.radioButton_gdzj.UseVisualStyleBackColor = true;
			this.radioButton_gdzj.CheckedChanged += new System.EventHandler(this.radioButton_zdzj_CheckedChanged);
			this.radioButton_zdzj.AutoSize = true;
			this.radioButton_zdzj.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location37 = new System.Drawing.Point(42, 62);
			this.radioButton_zdzj.Location = location37;
			Padding margin37 = new Padding(2, 2, 2, 2);
			this.radioButton_zdzj.Margin = margin37;
			this.radioButton_zdzj.Name = "radioButton_zdzj";
			System.Drawing.Size size37 = new System.Drawing.Size(85, 19);
			this.radioButton_zdzj.Size = size37;
			this.radioButton_zdzj.TabIndex = 75;
			this.radioButton_zdzj.Text = "指定针脚";
			this.radioButton_zdzj.UseVisualStyleBackColor = true;
			this.radioButton_zdzj.CheckedChanged += new System.EventHandler(this.radioButton_zdzj_CheckedChanged);
			this.groupBox2.Anchor = AnchorStyles.Top;
			this.groupBox2.Controls.Add(this.comboBox_stopPin);
			this.groupBox2.Controls.Add(this.label_stopPin);
			this.groupBox2.Controls.Add(this.comboBox_startPin);
			this.groupBox2.Controls.Add(this.label_startPin);
			this.groupBox2.Controls.Add(this.radioButton_zdzj);
			this.groupBox2.Controls.Add(this.radioButton_gdzj);
			this.groupBox2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location38 = new System.Drawing.Point(41, 21);
			this.groupBox2.Location = location38;
			Padding margin38 = new Padding(2, 2, 2, 2);
			this.groupBox2.Margin = margin38;
			this.groupBox2.Name = "groupBox2";
			Padding padding7 = new Padding(2, 2, 2, 2);
			this.groupBox2.Padding = padding7;
			System.Drawing.Size size38 = new System.Drawing.Size(735, 96);
			this.groupBox2.Size = size38;
			this.groupBox2.TabIndex = 76;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "参数设置";
			this.comboBox_stopPin.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_stopPin.Enabled = false;
			this.comboBox_stopPin.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.comboBox_stopPin.FormattingEnabled = true;
			System.Drawing.Point location39 = new System.Drawing.Point(523, 61);
			this.comboBox_stopPin.Location = location39;
			Padding margin39 = new Padding(2, 2, 2, 2);
			this.comboBox_stopPin.Margin = margin39;
			this.comboBox_stopPin.Name = "comboBox_stopPin";
			System.Drawing.Size size39 = new System.Drawing.Size(158, 22);
			this.comboBox_stopPin.Size = size39;
			this.comboBox_stopPin.TabIndex = 78;
			this.label_stopPin.AutoSize = true;
			this.label_stopPin.Enabled = false;
			this.label_stopPin.Font = new System.Drawing.Font("宋体", 10.8f);
			System.Drawing.Point location40 = new System.Drawing.Point(442, 64);
			this.label_stopPin.Location = location40;
			Padding margin40 = new Padding(2, 0, 2, 0);
			this.label_stopPin.Margin = margin40;
			this.label_stopPin.Name = "label_stopPin";
			System.Drawing.Size size40 = new System.Drawing.Size(75, 15);
			this.label_stopPin.Size = size40;
			this.label_stopPin.TabIndex = 76;
			this.label_stopPin.Text = "终点针脚:";
			this.comboBox_startPin.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_startPin.Enabled = false;
			this.comboBox_startPin.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.comboBox_startPin.FormattingEnabled = true;
			System.Drawing.Point location41 = new System.Drawing.Point(255, 61);
			this.comboBox_startPin.Location = location41;
			Padding margin41 = new Padding(2, 2, 2, 2);
			this.comboBox_startPin.Margin = margin41;
			this.comboBox_startPin.Name = "comboBox_startPin";
			System.Drawing.Size size41 = new System.Drawing.Size(158, 22);
			this.comboBox_startPin.Size = size41;
			this.comboBox_startPin.TabIndex = 78;
			this.label_startPin.AutoSize = true;
			this.label_startPin.Enabled = false;
			this.label_startPin.Font = new System.Drawing.Font("宋体", 10.8f);
			System.Drawing.Point location42 = new System.Drawing.Point(174, 64);
			this.label_startPin.Location = location42;
			Padding margin42 = new Padding(2, 0, 2, 0);
			this.label_startPin.Margin = margin42;
			this.label_startPin.Name = "label_startPin";
			System.Drawing.Size size42 = new System.Drawing.Size(75, 15);
			this.label_startPin.Size = size42;
			this.label_startPin.TabIndex = 76;
			this.label_startPin.Text = "起点针脚:";
			this.label_progress.Anchor = AnchorStyles.Bottom;
			this.label_progress.AutoSize = true;
			this.label_progress.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location43 = new System.Drawing.Point(699, 471);
			this.label_progress.Location = location43;
			Padding margin43 = new Padding(2, 0, 2, 0);
			this.label_progress.Margin = margin43;
			this.label_progress.Name = "label_progress";
			System.Drawing.Size size43 = new System.Drawing.Size(31, 15);
			this.label_progress.Size = size43;
			this.label_progress.TabIndex = 77;
			this.label_progress.Text = "0 %";
			this.label_progress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.timer_waitfk.Interval = 1000;
			this.timer_waitfk.Tick += new System.EventHandler(this.timer_waitfk_Tick);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.label_progress);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.tabControl1);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.progressBar_test);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin44 = new Padding(2, 2, 2, 2);
			base.Margin = margin44;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormComponentMeasure";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "元器件测量";
			base.FormClosing += new FormClosingEventHandler(this.ctFormComponentMeasure_FormClosing);
			base.Load += new System.EventHandler(this.ctFormComponentMeasure_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public void SysControlInitFunc()
		{
			try
			{
				int i = 0;
				while (true)
				{
					int num = i + 2;
					if (num > this.gLineTestProcessor.SELF_MAX_COUNT)
					{
						break;
					}
					int num2 = i + 1;
					string tempStr = System.Convert.ToString(num2) + "," + System.Convert.ToString(num);
					this.comboBox_startPin.Items.Add(tempStr);
					this.comboBox_stopPin.Items.Add(tempStr);
					i = num2;
					i++;
				}
			}
			catch (System.Exception arg_68_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_68_0.StackTrace);
			}
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
		private void ctFormComponentMeasure_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				this.gLineTestProcessor.SendStopCmd();
			}
			catch (System.Exception arg_0D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_0D_0.StackTrace);
			}
		}
		public void StopTestDisposeFunc()
		{
			try
			{
				if (this.bSetBridgeFreqErrFlag)
				{
					this.textBox_DRtr.Text = "未知";
					this.textBox_DGtr.Text = "未知";
				}
				else
				{
					this.textBox_DRtr.Text = this.currDevFreqStr;
					this.textBox_DGtr.Text = this.currDevFreqStr;
				}
				this.timer_waitfk.Enabled = false;
				this.bDZTestFlag = false;
				this.bDRTestFlag = false;
				this.bDGTestFlag = false;
				this.btnQuit.Enabled = true;
				this.iProValue = 100;
				this.progressBar_test.Value = 100;
				this.label_progress.Text = "100 %";
				this.timer_tt.Enabled = false;
				this.btnDZStartTest.Text = "启动测试";
				this.btnDRStartTest.Text = "启动测试";
				this.btnDGStartTest.Text = "启动测试";
				System.Threading.Thread.Sleep(10);
				this.gLineTestProcessor.SendStopCmd();
			}
			catch (System.Exception arg_EE_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_EE_0.StackTrace);
			}
		}
		private void TestFinishedFunc()
		{
			try
			{
				this.StopTestDisposeFunc();
			}
			catch (System.Exception arg_08_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_08_0.StackTrace);
			}
		}
		private void ctFormComponentMeasure_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.comboBox_DRFreq.SelectedIndex = 1;
				this.comboBox_DGFreq.SelectedIndex = 1;
			}
			catch (System.Exception arg_1A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1A_0.StackTrace);
			}
		}
		private void timer_tt_Tick(object sender, System.EventArgs e)
		{
			try
			{
				int num = this.iProValue;
				if (num == 0)
				{
					this.iProValue = 1;
				}
				else if (num >= 100)
				{
					this.iProValue = 99;
				}
				this.progressBar_test.Value = this.iProValue;
				this.label_progress.Text = System.Convert.ToString(this.iProValue) + " %";
				if (this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray.Count > 0)
				{
					double dTestResultValue = System.Math.Abs(this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[0].mdTestResult);
					int iFirstPoint = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[0].mMainDevPinNum;
					int iSecendPoint = this.gLineTestProcessor.mpDevComm.mParseCmd.mUpdataCmdArray[0].mSecDevPinNum;
					byte bUnit = this.gLineTestProcessor.mpDevComm.mParseCmd.byteBridgeUnit;
					if (this.bDZTestFlag)
					{
						string strUnit;
						switch (bUnit)
						{
						case 1:
							strUnit = "pΩ";
							goto IL_16E;
						case 2:
							strUnit = "nΩ";
							goto IL_16E;
						case 3:
							strUnit = "μΩ";
							goto IL_16E;
						case 4:
							strUnit = "mΩ";
							goto IL_16E;
						case 5:
							strUnit = "Ω";
							goto IL_16E;
						case 8:
							strUnit = "kΩ";
							goto IL_16E;
						case 9:
							strUnit = "MΩ";
							goto IL_16E;
						}
						strUnit = "Ω";
						IL_16E:
						this.textBox_DZtv.Text = System.Convert.ToString(dTestResultValue);
						this.label_DZtv_unit.Text = strUnit;
					}
					else if (this.bDRTestFlag)
					{
						string strUnit;
						switch (bUnit)
						{
						case 1:
							strUnit = "pF";
							goto IL_1EC;
						case 2:
							strUnit = "nF";
							goto IL_1EC;
						case 3:
							strUnit = "μF";
							goto IL_1EC;
						case 4:
							strUnit = "mF";
							goto IL_1EC;
						case 7:
							strUnit = "F";
							goto IL_1EC;
						}
						strUnit = "F";
						IL_1EC:
						this.textBox_DRtv.Text = System.Convert.ToString(dTestResultValue);
						this.label_DRtv_unit.Text = strUnit;
					}
					else if (this.bDGTestFlag)
					{
						string strUnit;
						switch (bUnit)
						{
						case 1:
							strUnit = "pH";
							goto IL_266;
						case 2:
							strUnit = "nH";
							goto IL_266;
						case 3:
							strUnit = "μH";
							goto IL_266;
						case 4:
							strUnit = "mH";
							goto IL_266;
						case 6:
							strUnit = "H";
							goto IL_266;
						}
						strUnit = "H";
						IL_266:
						this.textBox_DGtv.Text = System.Convert.ToString(dTestResultValue);
						this.label_DGtv_unit.Text = strUnit;
					}
					this.TestFinishedFunc();
				}
			}
			catch (System.Exception arg_28B_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_28B_0.StackTrace);
				this.TestFinishedFunc();
			}
		}
		private void StartTest()
		{
			try
			{
				this.bSetBridgeFreqErrFlag = false;
				this.progressBar_test.Value = 0;
				this.iProValue = 0;
				this.gLineTestProcessor.mpDevComm.ClearTestCmdBuf();
				this.gLineTestProcessor.bIsTimeOut = false;
				if (this.bDRTestFlag)
				{
					this.label_bSetDRFreqErrTS.Visible = false;
					int iIndex = this.comboBox_DRFreq.SelectedIndex;
					this.currDevFreqStr = this.comboBox_DRFreq.Text;
					this.gLineTestProcessor.SendLCRFreqSetCmd(iIndex);
					this.gLineTestProcessor.mpDevComm.mParseCmd.bRecBridgeFreqFKFlag = false;
					this.timer_waitfk.Enabled = true;
					System.Threading.Thread.Sleep(100);
				}
				else if (this.bDGTestFlag)
				{
					this.label_bSetDGFreqErrTS.Visible = false;
					int iIndex2 = this.comboBox_DGFreq.SelectedIndex;
					this.currDevFreqStr = this.comboBox_DGFreq.Text;
					this.gLineTestProcessor.SendLCRFreqSetCmd(iIndex2);
					this.gLineTestProcessor.mpDevComm.mParseCmd.bRecBridgeFreqFKFlag = false;
					this.timer_waitfk.Enabled = true;
					System.Threading.Thread.Sleep(100);
				}
				else
				{
					this.gLineTestProcessor.DownLoadTestShip(this.testtype, this.port1, this.port2);
					System.Threading.Thread.Sleep(100);
					this.gLineTestProcessor.mpDevComm.mParseCmd.mnDownCmdCount = 1;
					this.gLineTestProcessor.mpDevComm.mnDownCmdCount = 1;
					if (this.bDZTestFlag)
					{
						this.gLineTestProcessor.DownTestCmd(1);
					}
					int this2 = this.currcount + 1;
					this.currcount = this2;
					this.gLineTestProcessor.currcount = this2;
				}
			}
			catch (System.Exception arg_189_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_189_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool GetYQJTestParaFunc()
		{
			try
			{
				this.port1 = 0;
				this.port2 = 0;
				if (this.radioButton_zdzj.Checked)
				{
					if (this.comboBox_startPin.SelectedIndex == this.comboBox_stopPin.SelectedIndex)
					{
						MessageBox.Show("起点针脚和终点针脚不能相同!", "提示", MessageBoxButtons.OK);
						return false;
					}
					string tempStr = this.comboBox_startPin.Text.ToString();
					string[] strArray = tempStr.Split(new char[]
					{
						','
					});
					this.port1 = System.Convert.ToInt32(strArray[0]);
					tempStr = this.comboBox_stopPin.Text.ToString();
					strArray = tempStr.Split(new char[]
					{
						','
					});
					this.port2 = System.Convert.ToInt32(strArray[0]);
				}
				this.testtype = 17;
				this.testtime = 1;
				this.testvolt = 1;
				this.dev1 = 0;
				this.dev2 = 0;
				this.currcount = 0;
				this.gLineTestProcessor.dev1 = 0;
				this.gLineTestProcessor.dev2 = this.dev2;
				this.gLineTestProcessor.port1 = this.port1;
				this.gLineTestProcessor.port2 = this.port2;
				this.gLineTestProcessor.testtype = this.testtype;
				this.gLineTestProcessor.testcount = 1;
				this.gLineTestProcessor.testtime = this.testtime;
				this.gLineTestProcessor.testvolt = this.testvolt;
				this.gLineTestProcessor.currcount = this.currcount;
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				kLineTestProcessor.dtoffset = this.dtoffset;
				kLineTestProcessor.mtimetick = this.mtimetick;
			}
			catch (System.Exception arg_1A6_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1A6_0.StackTrace);
				return false;
			}
			return true;
		}
		private void btnDZStartTest_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.bDRTestFlag && !this.bDGTestFlag)
				{
					bool this2 = this.bDZTestFlag;
					if (!this2 && !this.gLineTestProcessor.bIsConnSuccFlag)
					{
						MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
					}
					else if (this2)
					{
						if (DialogResult.OK == MessageBox.Show("正在进行测试，您确定要停止吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
						{
							this.TestFinishedFunc();
						}
					}
					else
					{
						this.bDZTestFlag = true;
						if (!this.GetYQJTestParaFunc())
						{
							this.bDZTestFlag = false;
						}
						else
						{
							this.gLineTestProcessor.SendStopCmd();
							System.Threading.Thread.Sleep(500);
							this.progressBar_test.Value = 0;
							this.iProValue = 0;
							this.timer_tt.Enabled = true;
							this.btnDZStartTest.Text = "停止测试";
							this.StartTest();
						}
					}
				}
			}
			catch (System.Exception arg_CE_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_CE_0.StackTrace);
			}
		}
		private void btnDRStartTest_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.bDZTestFlag && !this.bDGTestFlag)
				{
					bool this2 = this.bDRTestFlag;
					if (!this2 && !this.gLineTestProcessor.bIsConnSuccFlag)
					{
						MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
					}
					else if (this2)
					{
						if (DialogResult.OK == MessageBox.Show("正在进行测试，您确定要停止吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
						{
							this.TestFinishedFunc();
						}
					}
					else
					{
						this.bDRTestFlag = true;
						if (!this.GetYQJTestParaFunc())
						{
							this.bDRTestFlag = false;
						}
						else
						{
							this.gLineTestProcessor.SendStopCmd();
							System.Threading.Thread.Sleep(500);
							this.progressBar_test.Value = 0;
							this.iProValue = 0;
							this.timer_tt.Enabled = true;
							this.btnDRStartTest.Text = "停止测试";
							this.StartTest();
						}
					}
				}
			}
			catch (System.Exception arg_CE_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_CE_0.StackTrace);
			}
		}
		private void btnDGStartTest_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.bDZTestFlag && !this.bDRTestFlag)
				{
					bool this2 = this.bDGTestFlag;
					if (!this2 && !this.gLineTestProcessor.bIsConnSuccFlag)
					{
						MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
					}
					else if (this2)
					{
						if (DialogResult.OK == MessageBox.Show("正在进行测试，您确定要停止吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
						{
							this.TestFinishedFunc();
						}
					}
					else
					{
						this.bDGTestFlag = true;
						if (!this.GetYQJTestParaFunc())
						{
							this.bDGTestFlag = false;
						}
						else
						{
							this.gLineTestProcessor.SendStopCmd();
							System.Threading.Thread.Sleep(500);
							this.progressBar_test.Value = 0;
							this.iProValue = 0;
							this.timer_tt.Enabled = true;
							this.btnDGStartTest.Text = "停止测试";
							this.StartTest();
						}
					}
				}
			}
			catch (System.Exception arg_CE_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_CE_0.StackTrace);
			}
		}
		private void radioButton_zdzj_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.label_startPin.Enabled = this.radioButton_zdzj.Checked;
				this.comboBox_startPin.Enabled = this.radioButton_zdzj.Checked;
				this.label_stopPin.Enabled = this.radioButton_zdzj.Checked;
				this.comboBox_stopPin.Enabled = this.radioButton_zdzj.Checked;
			}
			catch (System.Exception arg_5A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5A_0.StackTrace);
			}
		}
		private void timer_updatePro_Tick(object sender, System.EventArgs e)
		{
			try
			{
				int this2 = this.iProValue;
				if (this2 >= 100)
				{
					this.iProValue = 100;
				}
				else if (this2 < 2)
				{
					this.iProValue = this2 + 1;
				}
				this.progressBar_test.Value = this.iProValue;
				if (this.gLineTestProcessor.mpDevComm.mParseCmd.bSetBridgeFreqErrFlag)
				{
					this.textBox_DRtr.Text = this.currDevFreqStr;
					this.textBox_DGtr.Text = this.currDevFreqStr;
					this.gLineTestProcessor.mpDevComm.mParseCmd.bSetBridgeFreqErrFlag = false;
					if (this.bDRTestFlag)
					{
						this.label_bSetDRFreqErrTS.Visible = true;
						this.bSetBridgeFreqErrFlag = true;
					}
					else if (this.bDGTestFlag)
					{
						this.label_bSetDGFreqErrTS.Visible = true;
						this.bSetBridgeFreqErrFlag = true;
					}
				}
			}
			catch (System.Exception arg_BD_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_BD_0.StackTrace);
			}
		}
		private void timer_waitfk_Tick(object sender, System.EventArgs e)
		{
			try
			{
				if (this.gLineTestProcessor.mpDevComm.mParseCmd.bRecBridgeFreqFKFlag)
				{
					this.timer_waitfk.Enabled = false;
					this.gLineTestProcessor.DownLoadTestShip(this.testtype, this.port1, this.port2);
					System.Threading.Thread.Sleep(100);
					this.gLineTestProcessor.mpDevComm.mParseCmd.mnDownCmdCount = 1;
					this.gLineTestProcessor.mpDevComm.mnDownCmdCount = 1;
					if (this.bDRTestFlag)
					{
						this.gLineTestProcessor.DownTestCmd(2);
					}
					else if (this.bDGTestFlag)
					{
						this.gLineTestProcessor.DownTestCmd(3);
					}
					int this2 = this.currcount + 1;
					this.currcount = this2;
					this.gLineTestProcessor.currcount = this2;
				}
			}
			catch (System.Exception arg_BB_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_BB_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormComponentMeasure();
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
