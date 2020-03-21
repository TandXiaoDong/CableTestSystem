using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormDeviceCalibration : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public static int SEND_STOP_CMD_NUM = 500;
		public string loginUser;
		public string dbpath;
		public int iJZType;
		public bool bSuccFlag;
		public bool bDCJZFlag;
		public bool bACJZFlag;
		public bool bJYDZJZFlag;
		public bool bJLDLJZFlag;
		public bool bInquiryHintFlag;
		public int iTimeCount;
		public double dZeroValue;
		public bool bZeroTestFlag;
		private FlowLayoutPanel flowLayoutPanel1;
		private GroupBox groupBox_dyzl;
		private NumericUpDown numericUpDown_LVDCmax;
		private Button btnJZ_LVDC;
		private NumericUpDown numericUpDown_LVDLmax;
		private Label label22;
		private Label label21;
		private Label label19;
		private Label label20;
		private GroupBox groupBox_nyjl;
		private NumericUpDown numericUpDown_AC;
		private Button btnJZ_AC;
		private Label label5;
		private Label label6;
		private GroupBox groupBox_nydl;
		private TextBox textBox_NYDL;
		private Label label8;
		private NumericUpDown numericUpDown_AC_BCSJ;
		private NumericUpDown numericUpDown_AC_JZDY;
		private Label label9;
		private Button btnJZ_NYDL;
		private Label label15;
		private Label label16;
		private Label label17;
		private Label label18;
		private Button btnJZ_JXDT;
		private NumericUpDown numericUpDown_rHT;
		private Label label2;
		private Label label1;
		private GroupBox groupBox_dt;
		private GroupBox groupBox_jydl;
		private Button btnQuit;
		private TextBox textBox_dt;
		private Label label7;
		private Label label10;
		private Button btnJZ_DT;
		private NumericUpDown numericUpDown_DC;
		private Label label3;
		private Label label4;
		private IContainer components;
		private Button btnJZ_DC;
		private System.Windows.Forms.Timer timer1;
		private GroupBox groupBox_jydz;
		private TextBox textBox_JYDZ;
		private Label label11;
		private NumericUpDown numericUpDown_JYDZ;
		private Button btnJZ_JYDZ;
		private Label label12;
		private Label label13;
		private Label label14;
		public ctFormDeviceCalibration(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
					this.iTimeCount = 0;
					this.dZeroValue = 0.0;
					this.iJZType = 0;
					this.bInquiryHintFlag = false;
					this.bZeroTestFlag = false;
					this.bSuccFlag = false;
				}
				catch (System.Exception arg_68_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_68_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormDeviceCalibration()
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
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormDeviceCalibration));
			this.groupBox_dt = new GroupBox();
			this.textBox_dt = new TextBox();
			this.label7 = new Label();
			this.btnJZ_JXDT = new Button();
			this.btnJZ_DT = new Button();
			this.label10 = new Label();
			this.groupBox_jydl = new GroupBox();
			this.numericUpDown_DC = new NumericUpDown();
			this.btnJZ_DC = new Button();
			this.label3 = new Label();
			this.label4 = new Label();
			this.btnQuit = new Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox_jydz = new GroupBox();
			this.textBox_JYDZ = new TextBox();
			this.label11 = new Label();
			this.numericUpDown_rHT = new NumericUpDown();
			this.numericUpDown_JYDZ = new NumericUpDown();
			this.label2 = new Label();
			this.btnJZ_JYDZ = new Button();
			this.label12 = new Label();
			this.label1 = new Label();
			this.label13 = new Label();
			this.label14 = new Label();
			this.groupBox_nyjl = new GroupBox();
			this.numericUpDown_AC = new NumericUpDown();
			this.btnJZ_AC = new Button();
			this.label5 = new Label();
			this.label6 = new Label();
			this.groupBox_nydl = new GroupBox();
			this.textBox_NYDL = new TextBox();
			this.label8 = new Label();
			this.numericUpDown_AC_BCSJ = new NumericUpDown();
			this.numericUpDown_AC_JZDY = new NumericUpDown();
			this.label9 = new Label();
			this.btnJZ_NYDL = new Button();
			this.label15 = new Label();
			this.label16 = new Label();
			this.label17 = new Label();
			this.label18 = new Label();
			this.flowLayoutPanel1 = new FlowLayoutPanel();
			this.groupBox_dyzl = new GroupBox();
			this.numericUpDown_LVDLmax = new NumericUpDown();
			this.numericUpDown_LVDCmax = new NumericUpDown();
			this.btnJZ_LVDC = new Button();
			this.label22 = new Label();
			this.label19 = new Label();
			this.label21 = new Label();
			this.label20 = new Label();
			this.groupBox_dt.SuspendLayout();
			this.groupBox_jydl.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_DC).BeginInit();
			this.groupBox_jydz.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_rHT).BeginInit();
			((ISupportInitialize)this.numericUpDown_JYDZ).BeginInit();
			this.groupBox_nyjl.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_AC).BeginInit();
			this.groupBox_nydl.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_AC_BCSJ).BeginInit();
			((ISupportInitialize)this.numericUpDown_AC_JZDY).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.groupBox_dyzl.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_LVDLmax).BeginInit();
			((ISupportInitialize)this.numericUpDown_LVDCmax).BeginInit();
			base.SuspendLayout();
			this.groupBox_dt.Controls.Add(this.textBox_dt);
			this.groupBox_dt.Controls.Add(this.label7);
			this.groupBox_dt.Controls.Add(this.btnJZ_JXDT);
			this.groupBox_dt.Controls.Add(this.btnJZ_DT);
			this.groupBox_dt.Controls.Add(this.label10);
			this.groupBox_dt.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(8, 8);
			this.groupBox_dt.Location = location;
			Padding margin = new Padding(8, 8, 2, 2);
			this.groupBox_dt.Margin = margin;
			this.groupBox_dt.Name = "groupBox_dt";
			Padding padding = new Padding(2);
			this.groupBox_dt.Padding = padding;
			System.Drawing.Size size = new System.Drawing.Size(756, 60);
			this.groupBox_dt.Size = size;
			this.groupBox_dt.TabIndex = 0;
			this.groupBox_dt.TabStop = false;
			this.groupBox_dt.Text = "导通电阻校准";
			System.Drawing.Point location2 = new System.Drawing.Point(540, 22);
			this.textBox_dt.Location = location2;
			Padding margin2 = new Padding(2);
			this.textBox_dt.Margin = margin2;
			this.textBox_dt.Name = "textBox_dt";
			this.textBox_dt.ReadOnly = true;
			System.Drawing.Size size2 = new System.Drawing.Size(136, 24);
			this.textBox_dt.Size = size2;
			this.textBox_dt.TabIndex = 2;
			this.textBox_dt.TextAlign = HorizontalAlignment.Center;
			this.label7.AutoSize = true;
			System.Drawing.Point location3 = new System.Drawing.Point(475, 26);
			this.label7.Location = location3;
			Padding margin3 = new Padding(2, 0, 2, 0);
			this.label7.Margin = margin3;
			this.label7.Name = "label7";
			System.Drawing.Size size3 = new System.Drawing.Size(60, 15);
			this.label7.Size = size3;
			this.label7.TabIndex = 3;
			this.label7.Text = "返回值:";
			System.Drawing.Point location4 = new System.Drawing.Point(92, 22);
			this.btnJZ_JXDT.Location = location4;
			Padding margin4 = new Padding(2);
			this.btnJZ_JXDT.Margin = margin4;
			this.btnJZ_JXDT.Name = "btnJZ_JXDT";
			System.Drawing.Size size4 = new System.Drawing.Size(150, 24);
			this.btnJZ_JXDT.Size = size4;
			this.btnJZ_JXDT.TabIndex = 1;
			this.btnJZ_JXDT.Text = "接线电阻测试";
			this.btnJZ_JXDT.UseVisualStyleBackColor = true;
			this.btnJZ_JXDT.Click += new System.EventHandler(this.btnJZ_JXDT_Click);
			System.Drawing.Point location5 = new System.Drawing.Point(303, 22);
			this.btnJZ_DT.Location = location5;
			Padding margin5 = new Padding(2);
			this.btnJZ_DT.Margin = margin5;
			this.btnJZ_DT.Name = "btnJZ_DT";
			System.Drawing.Size size5 = new System.Drawing.Size(150, 24);
			this.btnJZ_DT.Size = size5;
			this.btnJZ_DT.TabIndex = 1;
			this.btnJZ_DT.Text = "导通电阻校准";
			this.btnJZ_DT.UseVisualStyleBackColor = true;
			this.btnJZ_DT.Click += new System.EventHandler(this.btnJZ_DT_Click);
			this.label10.AutoSize = true;
			System.Drawing.Point location6 = new System.Drawing.Point(682, 26);
			this.label10.Location = location6;
			Padding margin6 = new Padding(2, 0, 2, 0);
			this.label10.Margin = margin6;
			this.label10.Name = "label10";
			System.Drawing.Size size6 = new System.Drawing.Size(22, 15);
			this.label10.Size = size6;
			this.label10.TabIndex = 0;
			this.label10.Text = "Ω";
			this.groupBox_jydl.Controls.Add(this.numericUpDown_DC);
			this.groupBox_jydl.Controls.Add(this.btnJZ_DC);
			this.groupBox_jydl.Controls.Add(this.label3);
			this.groupBox_jydl.Controls.Add(this.label4);
			this.groupBox_jydl.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(8, 156);
			this.groupBox_jydl.Location = location7;
			Padding margin7 = new Padding(8, 2, 2, 2);
			this.groupBox_jydl.Margin = margin7;
			this.groupBox_jydl.Name = "groupBox_jydl";
			Padding padding2 = new Padding(2);
			this.groupBox_jydl.Padding = padding2;
			System.Drawing.Size size7 = new System.Drawing.Size(756, 60);
			this.groupBox_jydl.Size = size7;
			this.groupBox_jydl.TabIndex = 0;
			this.groupBox_jydl.TabStop = false;
			this.groupBox_jydl.Text = "直流高压电源校准";
			this.numericUpDown_DC.DecimalPlaces = 1;
			decimal increment = new decimal(new int[]
			{
				2,
				0,
				0,
				0
			});
			this.numericUpDown_DC.Increment = increment;
			System.Drawing.Point location8 = new System.Drawing.Point(122, 22);
			this.numericUpDown_DC.Location = location8;
			Padding margin8 = new Padding(2);
			this.numericUpDown_DC.Margin = margin8;
			decimal maximum = new decimal(new int[]
			{
				1500,
				0,
				0,
				0
			});
			this.numericUpDown_DC.Maximum = maximum;
			this.numericUpDown_DC.Name = "numericUpDown_DC";
			System.Drawing.Size size8 = new System.Drawing.Size(120, 24);
			this.numericUpDown_DC.Size = size8;
			this.numericUpDown_DC.TabIndex = 5;
			this.numericUpDown_DC.TextAlign = HorizontalAlignment.Center;
			decimal value = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			this.numericUpDown_DC.Value = value;
			this.numericUpDown_DC.KeyUp += new KeyEventHandler(this.numericUpDown_DC_KeyUp);
			System.Drawing.Point location9 = new System.Drawing.Point(323, 22);
			this.btnJZ_DC.Location = location9;
			Padding margin9 = new Padding(2);
			this.btnJZ_DC.Margin = margin9;
			this.btnJZ_DC.Name = "btnJZ_DC";
			System.Drawing.Size size9 = new System.Drawing.Size(339, 24);
			this.btnJZ_DC.Size = size9;
			this.btnJZ_DC.TabIndex = 4;
			this.btnJZ_DC.Text = "直流高压电源校准";
			this.btnJZ_DC.UseVisualStyleBackColor = true;
			this.btnJZ_DC.Click += new System.EventHandler(this.btnJZ_DC_Click);
			this.label3.AutoSize = true;
			System.Drawing.Point location10 = new System.Drawing.Point(56, 26);
			this.label3.Location = location10;
			Padding margin10 = new Padding(2, 0, 2, 0);
			this.label3.Margin = margin10;
			this.label3.Name = "label3";
			System.Drawing.Size size10 = new System.Drawing.Size(60, 15);
			this.label3.Size = size10;
			this.label3.TabIndex = 0;
			this.label3.Text = "校准值:";
			this.label4.AutoSize = true;
			System.Drawing.Point location11 = new System.Drawing.Point(250, 26);
			this.label4.Location = location11;
			Padding margin11 = new Padding(2, 0, 2, 0);
			this.label4.Margin = margin11;
			this.label4.Name = "label4";
			System.Drawing.Size size11 = new System.Drawing.Size(31, 15);
			this.label4.Size = size11;
			this.label4.TabIndex = 0;
			this.label4.Text = "VDC";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location12 = new System.Drawing.Point(341, 495);
			this.btnQuit.Location = location12;
			Padding margin12 = new Padding(2);
			this.btnQuit.Margin = margin12;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size12 = new System.Drawing.Size(112, 24);
			this.btnQuit.Size = size12;
			this.btnQuit.TabIndex = 0;
			this.btnQuit.Text = "关闭";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			this.groupBox_jydz.Controls.Add(this.textBox_JYDZ);
			this.groupBox_jydz.Controls.Add(this.label11);
			this.groupBox_jydz.Controls.Add(this.numericUpDown_rHT);
			this.groupBox_jydz.Controls.Add(this.numericUpDown_JYDZ);
			this.groupBox_jydz.Controls.Add(this.label2);
			this.groupBox_jydz.Controls.Add(this.btnJZ_JYDZ);
			this.groupBox_jydz.Controls.Add(this.label12);
			this.groupBox_jydz.Controls.Add(this.label1);
			this.groupBox_jydz.Controls.Add(this.label13);
			this.groupBox_jydz.Controls.Add(this.label14);
			this.groupBox_jydz.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location13 = new System.Drawing.Point(8, 220);
			this.groupBox_jydz.Location = location13;
			Padding margin13 = new Padding(8, 2, 2, 2);
			this.groupBox_jydz.Margin = margin13;
			this.groupBox_jydz.Name = "groupBox_jydz";
			Padding padding3 = new Padding(2);
			this.groupBox_jydz.Padding = padding3;
			System.Drawing.Size size13 = new System.Drawing.Size(756, 80);
			this.groupBox_jydz.Size = size13;
			this.groupBox_jydz.TabIndex = 0;
			this.groupBox_jydz.TabStop = false;
			this.groupBox_jydz.Text = "绝缘电阻校准";
			System.Drawing.Point location14 = new System.Drawing.Point(540, 41);
			this.textBox_JYDZ.Location = location14;
			Padding margin14 = new Padding(2);
			this.textBox_JYDZ.Margin = margin14;
			this.textBox_JYDZ.Name = "textBox_JYDZ";
			this.textBox_JYDZ.ReadOnly = true;
			System.Drawing.Size size14 = new System.Drawing.Size(136, 24);
			this.textBox_JYDZ.Size = size14;
			this.textBox_JYDZ.TabIndex = 7;
			this.textBox_JYDZ.TextAlign = HorizontalAlignment.Center;
			this.label11.AutoSize = true;
			System.Drawing.Point location15 = new System.Drawing.Point(475, 45);
			this.label11.Location = location15;
			Padding margin15 = new Padding(2, 0, 2, 0);
			this.label11.Margin = margin15;
			this.label11.Name = "label11";
			System.Drawing.Size size15 = new System.Drawing.Size(60, 15);
			this.label11.Size = size15;
			this.label11.TabIndex = 3;
			this.label11.Text = "返回值:";
			this.numericUpDown_rHT.DecimalPlaces = 1;
			System.Drawing.Point location16 = new System.Drawing.Point(122, 48);
			this.numericUpDown_rHT.Location = location16;
			Padding margin16 = new Padding(2);
			this.numericUpDown_rHT.Margin = margin16;
			decimal maximum2 = new decimal(new int[]
			{
				120,
				0,
				0,
				0
			});
			this.numericUpDown_rHT.Maximum = maximum2;
			this.numericUpDown_rHT.Name = "numericUpDown_rHT";
			System.Drawing.Size size16 = new System.Drawing.Size(120, 24);
			this.numericUpDown_rHT.Size = size16;
			this.numericUpDown_rHT.TabIndex = 5;
			this.numericUpDown_rHT.TextAlign = HorizontalAlignment.Center;
			decimal value2 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_rHT.Value = value2;
			this.numericUpDown_rHT.KeyUp += new KeyEventHandler(this.numericUpDown_rHT_KeyUp);
			this.numericUpDown_JYDZ.DecimalPlaces = 1;
			System.Drawing.Point location17 = new System.Drawing.Point(122, 18);
			this.numericUpDown_JYDZ.Location = location17;
			Padding margin17 = new Padding(2);
			this.numericUpDown_JYDZ.Margin = margin17;
			decimal maximum3 = new decimal(new int[]
			{
				1500,
				0,
				0,
				0
			});
			this.numericUpDown_JYDZ.Maximum = maximum3;
			this.numericUpDown_JYDZ.Name = "numericUpDown_JYDZ";
			System.Drawing.Size size17 = new System.Drawing.Size(120, 24);
			this.numericUpDown_JYDZ.Size = size17;
			this.numericUpDown_JYDZ.TabIndex = 5;
			this.numericUpDown_JYDZ.TextAlign = HorizontalAlignment.Center;
			decimal value3 = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			this.numericUpDown_JYDZ.Value = value3;
			this.numericUpDown_JYDZ.KeyUp += new KeyEventHandler(this.numericUpDown_JYDZ_KeyUp);
			this.label2.AutoSize = true;
			System.Drawing.Point location18 = new System.Drawing.Point(42, 52);
			this.label2.Location = location18;
			Padding margin18 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin18;
			this.label2.Name = "label2";
			System.Drawing.Size size18 = new System.Drawing.Size(75, 15);
			this.label2.Size = size18;
			this.label2.TabIndex = 0;
			this.label2.Text = "保持时间:";
			System.Drawing.Point location19 = new System.Drawing.Point(303, 40);
			this.btnJZ_JYDZ.Location = location19;
			Padding margin19 = new Padding(2);
			this.btnJZ_JYDZ.Margin = margin19;
			this.btnJZ_JYDZ.Name = "btnJZ_JYDZ";
			System.Drawing.Size size19 = new System.Drawing.Size(150, 24);
			this.btnJZ_JYDZ.Size = size19;
			this.btnJZ_JYDZ.TabIndex = 6;
			this.btnJZ_JYDZ.Text = "绝缘电阻校准";
			this.btnJZ_JYDZ.UseVisualStyleBackColor = true;
			this.btnJZ_JYDZ.Click += new System.EventHandler(this.btnJZ_JYDZ_Click);
			this.label12.AutoSize = true;
			System.Drawing.Point location20 = new System.Drawing.Point(56, 22);
			this.label12.Location = location20;
			Padding margin20 = new Padding(2, 0, 2, 0);
			this.label12.Margin = margin20;
			this.label12.Name = "label12";
			System.Drawing.Size size20 = new System.Drawing.Size(60, 15);
			this.label12.Size = size20;
			this.label12.TabIndex = 0;
			this.label12.Text = "校准值:";
			this.label1.AutoSize = true;
			System.Drawing.Point location21 = new System.Drawing.Point(250, 52);
			this.label1.Location = location21;
			Padding margin21 = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin21;
			this.label1.Name = "label1";
			System.Drawing.Size size21 = new System.Drawing.Size(15, 15);
			this.label1.Size = size21;
			this.label1.TabIndex = 0;
			this.label1.Text = "s";
			this.label13.AutoSize = true;
			System.Drawing.Point location22 = new System.Drawing.Point(683, 45);
			this.label13.Location = location22;
			Padding margin22 = new Padding(2, 0, 2, 0);
			this.label13.Margin = margin22;
			this.label13.Name = "label13";
			System.Drawing.Size size22 = new System.Drawing.Size(30, 15);
			this.label13.Size = size22;
			this.label13.TabIndex = 0;
			this.label13.Text = "MΩ";
			this.label14.AutoSize = true;
			System.Drawing.Point location23 = new System.Drawing.Point(250, 22);
			this.label14.Location = location23;
			Padding margin23 = new Padding(2, 0, 2, 0);
			this.label14.Margin = margin23;
			this.label14.Name = "label14";
			System.Drawing.Size size23 = new System.Drawing.Size(31, 15);
			this.label14.Size = size23;
			this.label14.TabIndex = 0;
			this.label14.Text = "VDC";
			this.groupBox_nyjl.Controls.Add(this.numericUpDown_AC);
			this.groupBox_nyjl.Controls.Add(this.btnJZ_AC);
			this.groupBox_nyjl.Controls.Add(this.label5);
			this.groupBox_nyjl.Controls.Add(this.label6);
			this.groupBox_nyjl.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location24 = new System.Drawing.Point(8, 304);
			this.groupBox_nyjl.Location = location24;
			Padding margin24 = new Padding(8, 2, 2, 2);
			this.groupBox_nyjl.Margin = margin24;
			this.groupBox_nyjl.Name = "groupBox_nyjl";
			Padding padding4 = new Padding(2);
			this.groupBox_nyjl.Padding = padding4;
			System.Drawing.Size size24 = new System.Drawing.Size(756, 60);
			this.groupBox_nyjl.Size = size24;
			this.groupBox_nyjl.TabIndex = 1;
			this.groupBox_nyjl.TabStop = false;
			this.groupBox_nyjl.Text = "交流高压电源校准";
			this.numericUpDown_AC.DecimalPlaces = 1;
			System.Drawing.Point location25 = new System.Drawing.Point(122, 22);
			this.numericUpDown_AC.Location = location25;
			Padding margin25 = new Padding(2);
			this.numericUpDown_AC.Margin = margin25;
			decimal maximum4 = new decimal(new int[]
			{
				1000,
				0,
				0,
				0
			});
			this.numericUpDown_AC.Maximum = maximum4;
			this.numericUpDown_AC.Name = "numericUpDown_AC";
			System.Drawing.Size size25 = new System.Drawing.Size(120, 24);
			this.numericUpDown_AC.Size = size25;
			this.numericUpDown_AC.TabIndex = 5;
			this.numericUpDown_AC.TextAlign = HorizontalAlignment.Center;
			decimal value4 = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			this.numericUpDown_AC.Value = value4;
			this.numericUpDown_AC.KeyUp += new KeyEventHandler(this.numericUpDown_AC_KeyUp);
			System.Drawing.Point location26 = new System.Drawing.Point(323, 22);
			this.btnJZ_AC.Location = location26;
			Padding margin26 = new Padding(2);
			this.btnJZ_AC.Margin = margin26;
			this.btnJZ_AC.Name = "btnJZ_AC";
			System.Drawing.Size size26 = new System.Drawing.Size(339, 24);
			this.btnJZ_AC.Size = size26;
			this.btnJZ_AC.TabIndex = 4;
			this.btnJZ_AC.Text = "交流高压电源校准";
			this.btnJZ_AC.UseVisualStyleBackColor = true;
			this.btnJZ_AC.Click += new System.EventHandler(this.btnJZ_AC_Click);
			this.label5.AutoSize = true;
			System.Drawing.Point location27 = new System.Drawing.Point(56, 26);
			this.label5.Location = location27;
			Padding margin27 = new Padding(2, 0, 2, 0);
			this.label5.Margin = margin27;
			this.label5.Name = "label5";
			System.Drawing.Size size27 = new System.Drawing.Size(60, 15);
			this.label5.Size = size27;
			this.label5.TabIndex = 0;
			this.label5.Text = "校准值:";
			this.label6.AutoSize = true;
			System.Drawing.Point location28 = new System.Drawing.Point(250, 26);
			this.label6.Location = location28;
			Padding margin28 = new Padding(2, 0, 2, 0);
			this.label6.Margin = margin28;
			this.label6.Name = "label6";
			System.Drawing.Size size28 = new System.Drawing.Size(31, 15);
			this.label6.Size = size28;
			this.label6.TabIndex = 0;
			this.label6.Text = "VAC";
			this.groupBox_nydl.Controls.Add(this.textBox_NYDL);
			this.groupBox_nydl.Controls.Add(this.label8);
			this.groupBox_nydl.Controls.Add(this.numericUpDown_AC_BCSJ);
			this.groupBox_nydl.Controls.Add(this.numericUpDown_AC_JZDY);
			this.groupBox_nydl.Controls.Add(this.label9);
			this.groupBox_nydl.Controls.Add(this.btnJZ_NYDL);
			this.groupBox_nydl.Controls.Add(this.label15);
			this.groupBox_nydl.Controls.Add(this.label16);
			this.groupBox_nydl.Controls.Add(this.label17);
			this.groupBox_nydl.Controls.Add(this.label18);
			this.groupBox_nydl.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location29 = new System.Drawing.Point(8, 368);
			this.groupBox_nydl.Location = location29;
			Padding margin29 = new Padding(8, 2, 2, 2);
			this.groupBox_nydl.Margin = margin29;
			this.groupBox_nydl.Name = "groupBox_nydl";
			Padding padding5 = new Padding(2);
			this.groupBox_nydl.Padding = padding5;
			System.Drawing.Size size29 = new System.Drawing.Size(756, 80);
			this.groupBox_nydl.Size = size29;
			this.groupBox_nydl.TabIndex = 0;
			this.groupBox_nydl.TabStop = false;
			this.groupBox_nydl.Text = "耐压漏电流校准";
			System.Drawing.Point location30 = new System.Drawing.Point(540, 33);
			this.textBox_NYDL.Location = location30;
			Padding margin30 = new Padding(2);
			this.textBox_NYDL.Margin = margin30;
			this.textBox_NYDL.Name = "textBox_NYDL";
			this.textBox_NYDL.ReadOnly = true;
			System.Drawing.Size size30 = new System.Drawing.Size(136, 24);
			this.textBox_NYDL.Size = size30;
			this.textBox_NYDL.TabIndex = 7;
			this.textBox_NYDL.TextAlign = HorizontalAlignment.Center;
			this.label8.AutoSize = true;
			System.Drawing.Point location31 = new System.Drawing.Point(475, 37);
			this.label8.Location = location31;
			Padding margin31 = new Padding(2, 0, 2, 0);
			this.label8.Margin = margin31;
			this.label8.Name = "label8";
			System.Drawing.Size size31 = new System.Drawing.Size(60, 15);
			this.label8.Size = size31;
			this.label8.TabIndex = 3;
			this.label8.Text = "返回值:";
			this.numericUpDown_AC_BCSJ.DecimalPlaces = 1;
			System.Drawing.Point location32 = new System.Drawing.Point(122, 48);
			this.numericUpDown_AC_BCSJ.Location = location32;
			Padding margin32 = new Padding(2);
			this.numericUpDown_AC_BCSJ.Margin = margin32;
			decimal maximum5 = new decimal(new int[]
			{
				120,
				0,
				0,
				0
			});
			this.numericUpDown_AC_BCSJ.Maximum = maximum5;
			this.numericUpDown_AC_BCSJ.Name = "numericUpDown_AC_BCSJ";
			System.Drawing.Size size32 = new System.Drawing.Size(120, 24);
			this.numericUpDown_AC_BCSJ.Size = size32;
			this.numericUpDown_AC_BCSJ.TabIndex = 5;
			this.numericUpDown_AC_BCSJ.TextAlign = HorizontalAlignment.Center;
			decimal value5 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_AC_BCSJ.Value = value5;
			this.numericUpDown_AC_BCSJ.KeyUp += new KeyEventHandler(this.numericUpDown_AC_BCSJ_KeyUp);
			this.numericUpDown_AC_JZDY.DecimalPlaces = 1;
			System.Drawing.Point location33 = new System.Drawing.Point(122, 18);
			this.numericUpDown_AC_JZDY.Location = location33;
			Padding margin33 = new Padding(2);
			this.numericUpDown_AC_JZDY.Margin = margin33;
			decimal maximum6 = new decimal(new int[]
			{
				1000,
				0,
				0,
				0
			});
			this.numericUpDown_AC_JZDY.Maximum = maximum6;
			this.numericUpDown_AC_JZDY.Name = "numericUpDown_AC_JZDY";
			System.Drawing.Size size33 = new System.Drawing.Size(120, 24);
			this.numericUpDown_AC_JZDY.Size = size33;
			this.numericUpDown_AC_JZDY.TabIndex = 5;
			this.numericUpDown_AC_JZDY.TextAlign = HorizontalAlignment.Center;
			decimal value6 = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			this.numericUpDown_AC_JZDY.Value = value6;
			this.numericUpDown_AC_JZDY.KeyUp += new KeyEventHandler(this.numericUpDown_AC_JZDY_KeyUp);
			this.label9.AutoSize = true;
			System.Drawing.Point location34 = new System.Drawing.Point(42, 52);
			this.label9.Location = location34;
			Padding margin34 = new Padding(2, 0, 2, 0);
			this.label9.Margin = margin34;
			this.label9.Name = "label9";
			System.Drawing.Size size34 = new System.Drawing.Size(75, 15);
			this.label9.Size = size34;
			this.label9.TabIndex = 0;
			this.label9.Text = "保持时间:";
			System.Drawing.Point location35 = new System.Drawing.Point(303, 32);
			this.btnJZ_NYDL.Location = location35;
			Padding margin35 = new Padding(2);
			this.btnJZ_NYDL.Margin = margin35;
			this.btnJZ_NYDL.Name = "btnJZ_NYDL";
			System.Drawing.Size size35 = new System.Drawing.Size(150, 24);
			this.btnJZ_NYDL.Size = size35;
			this.btnJZ_NYDL.TabIndex = 6;
			this.btnJZ_NYDL.Text = "耐压漏电流校准";
			this.btnJZ_NYDL.UseVisualStyleBackColor = true;
			this.btnJZ_NYDL.Click += new System.EventHandler(this.btnJZ_NYDL_Click);
			this.label15.AutoSize = true;
			System.Drawing.Point location36 = new System.Drawing.Point(56, 22);
			this.label15.Location = location36;
			Padding margin36 = new Padding(2, 0, 2, 0);
			this.label15.Margin = margin36;
			this.label15.Name = "label15";
			System.Drawing.Size size36 = new System.Drawing.Size(60, 15);
			this.label15.Size = size36;
			this.label15.TabIndex = 0;
			this.label15.Text = "校准值:";
			this.label16.AutoSize = true;
			System.Drawing.Point location37 = new System.Drawing.Point(250, 52);
			this.label16.Location = location37;
			Padding margin37 = new Padding(2, 0, 2, 0);
			this.label16.Margin = margin37;
			this.label16.Name = "label16";
			System.Drawing.Size size37 = new System.Drawing.Size(15, 15);
			this.label16.Size = size37;
			this.label16.TabIndex = 0;
			this.label16.Text = "s";
			this.label17.AutoSize = true;
			System.Drawing.Point location38 = new System.Drawing.Point(683, 37);
			this.label17.Location = location38;
			Padding margin38 = new Padding(2, 0, 2, 0);
			this.label17.Margin = margin38;
			this.label17.Name = "label17";
			System.Drawing.Size size38 = new System.Drawing.Size(23, 15);
			this.label17.Size = size38;
			this.label17.TabIndex = 0;
			this.label17.Text = "mA";
			this.label18.AutoSize = true;
			System.Drawing.Point location39 = new System.Drawing.Point(250, 22);
			this.label18.Location = location39;
			Padding margin39 = new Padding(2, 0, 2, 0);
			this.label18.Margin = margin39;
			this.label18.Name = "label18";
			System.Drawing.Size size39 = new System.Drawing.Size(31, 15);
			this.label18.Size = size39;
			this.label18.TabIndex = 0;
			this.label18.Text = "VAC";
			this.flowLayoutPanel1.Controls.Add(this.groupBox_dt);
			this.flowLayoutPanel1.Controls.Add(this.groupBox_dyzl);
			this.flowLayoutPanel1.Controls.Add(this.groupBox_jydl);
			this.flowLayoutPanel1.Controls.Add(this.groupBox_jydz);
			this.flowLayoutPanel1.Controls.Add(this.groupBox_nyjl);
			this.flowLayoutPanel1.Controls.Add(this.groupBox_nydl);
			System.Drawing.Point location40 = new System.Drawing.Point(2, 1);
			this.flowLayoutPanel1.Location = location40;
			Padding margin40 = new Padding(2);
			this.flowLayoutPanel1.Margin = margin40;
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			System.Drawing.Size size40 = new System.Drawing.Size(792, 472);
			this.flowLayoutPanel1.Size = size40;
			this.flowLayoutPanel1.TabIndex = 2;
			this.groupBox_dyzl.Controls.Add(this.numericUpDown_LVDLmax);
			this.groupBox_dyzl.Controls.Add(this.numericUpDown_LVDCmax);
			this.groupBox_dyzl.Controls.Add(this.btnJZ_LVDC);
			this.groupBox_dyzl.Controls.Add(this.label22);
			this.groupBox_dyzl.Controls.Add(this.label19);
			this.groupBox_dyzl.Controls.Add(this.label21);
			this.groupBox_dyzl.Controls.Add(this.label20);
			this.groupBox_dyzl.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location41 = new System.Drawing.Point(8, 72);
			this.groupBox_dyzl.Location = location41;
			Padding margin41 = new Padding(8, 2, 2, 2);
			this.groupBox_dyzl.Margin = margin41;
			this.groupBox_dyzl.Name = "groupBox_dyzl";
			Padding padding6 = new Padding(2);
			this.groupBox_dyzl.Padding = padding6;
			System.Drawing.Size size41 = new System.Drawing.Size(756, 80);
			this.groupBox_dyzl.Size = size41;
			this.groupBox_dyzl.TabIndex = 2;
			this.groupBox_dyzl.TabStop = false;
			this.groupBox_dyzl.Text = "直流低压电源校准";
			System.Drawing.Point location42 = new System.Drawing.Point(122, 48);
			this.numericUpDown_LVDLmax.Location = location42;
			Padding margin42 = new Padding(2);
			this.numericUpDown_LVDLmax.Margin = margin42;
			decimal maximum7 = new decimal(new int[]
			{
				2000,
				0,
				0,
				0
			});
			this.numericUpDown_LVDLmax.Maximum = maximum7;
			this.numericUpDown_LVDLmax.Name = "numericUpDown_LVDLmax";
			System.Drawing.Size size42 = new System.Drawing.Size(120, 24);
			this.numericUpDown_LVDLmax.Size = size42;
			this.numericUpDown_LVDLmax.TabIndex = 5;
			this.numericUpDown_LVDLmax.TextAlign = HorizontalAlignment.Center;
			decimal value7 = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			this.numericUpDown_LVDLmax.Value = value7;
			this.numericUpDown_LVDLmax.KeyUp += new KeyEventHandler(this.numericUpDown_LVDLmax_KeyUp);
			this.numericUpDown_LVDCmax.DecimalPlaces = 2;
			System.Drawing.Point location43 = new System.Drawing.Point(122, 18);
			this.numericUpDown_LVDCmax.Location = location43;
			Padding margin43 = new Padding(2);
			this.numericUpDown_LVDCmax.Margin = margin43;
			decimal maximum8 = new decimal(new int[]
			{
				50,
				0,
				0,
				0
			});
			this.numericUpDown_LVDCmax.Maximum = maximum8;
			this.numericUpDown_LVDCmax.Name = "numericUpDown_LVDCmax";
			System.Drawing.Size size43 = new System.Drawing.Size(120, 24);
			this.numericUpDown_LVDCmax.Size = size43;
			this.numericUpDown_LVDCmax.TabIndex = 5;
			this.numericUpDown_LVDCmax.TextAlign = HorizontalAlignment.Center;
			decimal value8 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_LVDCmax.Value = value8;
			this.numericUpDown_LVDCmax.KeyUp += new KeyEventHandler(this.numericUpDown_LVDCmax_KeyUp);
			System.Drawing.Point location44 = new System.Drawing.Point(323, 32);
			this.btnJZ_LVDC.Location = location44;
			Padding margin44 = new Padding(2);
			this.btnJZ_LVDC.Margin = margin44;
			this.btnJZ_LVDC.Name = "btnJZ_LVDC";
			System.Drawing.Size size44 = new System.Drawing.Size(339, 24);
			this.btnJZ_LVDC.Size = size44;
			this.btnJZ_LVDC.TabIndex = 4;
			this.btnJZ_LVDC.Text = "直流低压电源校准";
			this.btnJZ_LVDC.UseVisualStyleBackColor = true;
			this.btnJZ_LVDC.Click += new System.EventHandler(this.btnJZ_LVDC_Click);
			this.label22.AutoSize = true;
			System.Drawing.Point location45 = new System.Drawing.Point(13, 52);
			this.label22.Location = location45;
			Padding margin45 = new Padding(2, 0, 2, 0);
			this.label22.Margin = margin45;
			this.label22.Name = "label22";
			System.Drawing.Size size45 = new System.Drawing.Size(106, 15);
			this.label22.Size = size45;
			this.label22.TabIndex = 0;
			this.label22.Text = "电流值(最大):";
			this.label19.AutoSize = true;
			System.Drawing.Point location46 = new System.Drawing.Point(13, 22);
			this.label19.Location = location46;
			Padding margin46 = new Padding(2, 0, 2, 0);
			this.label19.Margin = margin46;
			this.label19.Name = "label19";
			System.Drawing.Size size46 = new System.Drawing.Size(106, 15);
			this.label19.Size = size46;
			this.label19.TabIndex = 0;
			this.label19.Text = "电压值(最大):";
			this.label21.AutoSize = true;
			System.Drawing.Point location47 = new System.Drawing.Point(250, 52);
			this.label21.Location = location47;
			Padding margin47 = new Padding(2, 0, 2, 0);
			this.label21.Margin = margin47;
			this.label21.Name = "label21";
			System.Drawing.Size size47 = new System.Drawing.Size(23, 15);
			this.label21.Size = size47;
			this.label21.TabIndex = 0;
			this.label21.Text = "mA";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label20.AutoSize = true;
			System.Drawing.Point location48 = new System.Drawing.Point(250, 22);
			this.label20.Location = location48;
			Padding margin48 = new Padding(2, 0, 2, 0);
			this.label20.Margin = margin48;
			this.label20.Name = "label20";
			System.Drawing.Size size48 = new System.Drawing.Size(31, 15);
			this.label20.Size = size48;
			this.label20.TabIndex = 0;
			this.label20.Text = "VDC";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.flowLayoutPanel1);
			base.Controls.Add(this.btnQuit);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin49 = new Padding(2);
			base.Margin = margin49;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormDeviceCalibration";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "设备校准";
			base.FormClosing += new FormClosingEventHandler(this.ctFormDeviceCalibration_FormClosing);
			base.Load += new System.EventHandler(this.ctFormDeviceCalibration_Load);
			this.groupBox_dt.ResumeLayout(false);
			this.groupBox_dt.PerformLayout();
			this.groupBox_jydl.ResumeLayout(false);
			this.groupBox_jydl.PerformLayout();
			((ISupportInitialize)this.numericUpDown_DC).EndInit();
			this.groupBox_jydz.ResumeLayout(false);
			this.groupBox_jydz.PerformLayout();
			((ISupportInitialize)this.numericUpDown_rHT).EndInit();
			((ISupportInitialize)this.numericUpDown_JYDZ).EndInit();
			this.groupBox_nyjl.ResumeLayout(false);
			this.groupBox_nyjl.PerformLayout();
			((ISupportInitialize)this.numericUpDown_AC).EndInit();
			this.groupBox_nydl.ResumeLayout(false);
			this.groupBox_nydl.PerformLayout();
			((ISupportInitialize)this.numericUpDown_AC_BCSJ).EndInit();
			((ISupportInitialize)this.numericUpDown_AC_JZDY).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.groupBox_dyzl.ResumeLayout(false);
			this.groupBox_dyzl.PerformLayout();
			((ISupportInitialize)this.numericUpDown_LVDLmax).EndInit();
			((ISupportInitialize)this.numericUpDown_LVDCmax).EndInit();
			base.ResumeLayout(false);
		}
		public void LoadDefaultParaFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				double d_DT_Volt_Min = 0.0;
				double d_DT_Volt_Max = 0.0;
				double d_DT_Current_Min = 0.0;
				double d_DT_Current_Max = 0.0;
				double d_JY_HoldTime_Min = 0.0;
				double d_JY_HoldTime_Max = 0.0;
				double d_JY_DCVolt_Min = 0.0;
				double d_JY_DCVolt_Max = 0.0;
				double d_NY_HoldTime_Min = 0.0;
				double d_NY_HoldTime_Max = 0.0;
				double d_NY_ACVolt_Min = 0.0;
				double d_NY_ACVolt_Max = 0.0;
				bool bExsitFlag = false;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select * from TTestParaRangeTable", connection).ExecuteReader();
					if (dataReader.Read())
					{
						bExsitFlag = true;
						d_DT_Volt_Min = System.Convert.ToDouble(dataReader["d_DT_Volt_Min"].ToString());
						d_DT_Volt_Max = System.Convert.ToDouble(dataReader["d_DT_Volt_Max"].ToString());
						d_DT_Current_Min = System.Convert.ToDouble(dataReader["d_DT_Current_Min"].ToString());
						d_DT_Current_Max = System.Convert.ToDouble(dataReader["d_DT_Current_Max"].ToString());
						d_JY_HoldTime_Min = System.Convert.ToDouble(dataReader["d_JY_HoldTime_Min"].ToString());
						d_JY_HoldTime_Max = System.Convert.ToDouble(dataReader["d_JY_HoldTime_Max"].ToString());
						d_JY_DCVolt_Min = System.Convert.ToDouble(dataReader["d_JY_DCVolt_Min"].ToString());
						d_JY_DCVolt_Max = System.Convert.ToDouble(dataReader["d_JY_DCVolt_Max"].ToString());
						d_NY_HoldTime_Min = System.Convert.ToDouble(dataReader["d_NY_HoldTime_Min"].ToString());
						d_NY_HoldTime_Max = System.Convert.ToDouble(dataReader["d_NY_HoldTime_Max"].ToString());
						d_NY_ACVolt_Min = System.Convert.ToDouble(dataReader["d_NY_ACVolt_Min"].ToString());
						d_NY_ACVolt_Max = System.Convert.ToDouble(dataReader["d_NY_ACVolt_Max"].ToString());
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_1E9_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_1E9_0.StackTrace);
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
				if (bExsitFlag)
				{
					decimal minimum = System.Convert.ToDecimal(d_DT_Volt_Min);
					this.numericUpDown_LVDCmax.Minimum = minimum;
					decimal maximum = System.Convert.ToDecimal(d_DT_Volt_Max);
					this.numericUpDown_LVDCmax.Maximum = maximum;
					decimal value = System.Convert.ToDecimal(d_DT_Volt_Min);
					this.numericUpDown_LVDCmax.Value = value;
					decimal minimum2 = System.Convert.ToDecimal(d_DT_Current_Min);
					this.numericUpDown_LVDLmax.Minimum = minimum2;
					decimal maximum2 = System.Convert.ToDecimal(d_DT_Current_Max);
					this.numericUpDown_LVDLmax.Maximum = maximum2;
					decimal value2 = System.Convert.ToDecimal(d_DT_Current_Max);
					this.numericUpDown_LVDLmax.Value = value2;
					decimal minimum3 = System.Convert.ToDecimal(d_JY_DCVolt_Min);
					this.numericUpDown_DC.Minimum = minimum3;
					decimal maximum3 = System.Convert.ToDecimal(d_JY_DCVolt_Max);
					this.numericUpDown_DC.Maximum = maximum3;
					decimal value3 = System.Convert.ToDecimal(d_JY_DCVolt_Min);
					this.numericUpDown_DC.Value = value3;
					decimal minimum4 = System.Convert.ToDecimal(d_JY_DCVolt_Min);
					this.numericUpDown_JYDZ.Minimum = minimum4;
					decimal maximum4 = System.Convert.ToDecimal(d_JY_DCVolt_Max);
					this.numericUpDown_JYDZ.Maximum = maximum4;
					decimal value4 = System.Convert.ToDecimal(d_JY_DCVolt_Min);
					this.numericUpDown_JYDZ.Value = value4;
					if (d_JY_HoldTime_Min <= 0.1)
					{
						d_JY_HoldTime_Min = 0.1;
					}
					decimal minimum5 = System.Convert.ToDecimal(d_JY_HoldTime_Min);
					this.numericUpDown_rHT.Minimum = minimum5;
					decimal maximum5 = System.Convert.ToDecimal(d_JY_HoldTime_Max);
					this.numericUpDown_rHT.Maximum = maximum5;
					decimal value5 = System.Convert.ToDecimal(d_JY_HoldTime_Min);
					this.numericUpDown_rHT.Value = value5;
					decimal minimum6 = System.Convert.ToDecimal(d_NY_ACVolt_Min);
					this.numericUpDown_AC.Minimum = minimum6;
					decimal maximum6 = System.Convert.ToDecimal(d_NY_ACVolt_Max);
					this.numericUpDown_AC.Maximum = maximum6;
					decimal value6 = System.Convert.ToDecimal(d_NY_ACVolt_Min);
					this.numericUpDown_AC.Value = value6;
					decimal minimum7 = System.Convert.ToDecimal(d_NY_ACVolt_Min);
					this.numericUpDown_AC_JZDY.Minimum = minimum7;
					decimal maximum7 = System.Convert.ToDecimal(d_NY_ACVolt_Max);
					this.numericUpDown_AC_JZDY.Maximum = maximum7;
					decimal value7 = System.Convert.ToDecimal(d_NY_ACVolt_Min);
					this.numericUpDown_AC_JZDY.Value = value7;
					if (d_NY_HoldTime_Min <= 0.1)
					{
						d_NY_HoldTime_Min = 0.1;
					}
					decimal minimum8 = System.Convert.ToDecimal(d_NY_HoldTime_Min);
					this.numericUpDown_AC_BCSJ.Minimum = minimum8;
					decimal maximum8 = System.Convert.ToDecimal(d_NY_HoldTime_Max);
					this.numericUpDown_AC_BCSJ.Maximum = maximum8;
					decimal value8 = System.Convert.ToDecimal(d_NY_HoldTime_Min);
					this.numericUpDown_AC_BCSJ.Value = value8;
				}
			}
			catch (System.Exception arg_44C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_44C_0.StackTrace);
			}
		}
		private void ctFormDeviceCalibration_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.groupBox_dt.Visible = this.gLineTestProcessor.bDTTestEnabled;
				this.groupBox_jydl.Visible = false;
				this.groupBox_jydz.Visible = false;
				KLineTestProcessor sender2 = this.gLineTestProcessor;
				if (sender2.bJYTestEnabled || sender2.bDDJYTestEnabled)
				{
					this.groupBox_jydl.Visible = true;
					this.groupBox_jydz.Visible = true;
				}
				KLineTestProcessor this2 = this.gLineTestProcessor;
				if (this2.iUIDisplayMode == 1)
				{
					this.groupBox_dyzl.Visible = false;
					this.groupBox_nyjl.Visible = false;
					this.groupBox_nydl.Visible = false;
				}
				else
				{
					this.groupBox_dyzl.Visible = this2.bDTTestEnabled;
					this.groupBox_nyjl.Visible = this.gLineTestProcessor.bNYTestEnabled;
					this.groupBox_nydl.Visible = this.gLineTestProcessor.bNYTestEnabled;
				}
			}
			catch (System.Exception arg_D2_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_D2_0.StackTrace);
			}
			this.LoadDefaultParaFunc();
		}
		private void btnJZ_DT_Click(object sender, System.EventArgs e)
		{
			try
			{
				KLineTestProcessor sender2 = this.gLineTestProcessor;
				if (!sender2.bIsConnSuccFlag)
				{
					MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					sender2.SendStopCmd();
					System.Threading.Thread.Sleep(ctFormDeviceCalibration.SEND_STOP_CMD_NUM);
					this.textBox_dt.Text = "";
					this.iJZType = 1;
					this.bSuccFlag = false;
					this.bZeroTestFlag = false;
					this.timer1.Enabled = true;
					this.gLineTestProcessor.mpDevComm.mParseCmd.bDTJZRFlag = false;
					KLineTestProcessor this2 = this.gLineTestProcessor;
					this2.mpDevComm.mParseCmd.dDTJZValue = 0.0;
					this2.mbKeepRun = true;
					this.gLineTestProcessor.SendDTVlotAndCurrentCmd(250.0, 2000.0);
					System.Threading.Thread.Sleep(300);
					this.gLineTestProcessor.DTVoltCal(1, 0, 0);
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		private void btnJZ_DC_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.bJYDZJZFlag)
				{
					MessageBox.Show("校准中，请稍等!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					KLineTestProcessor this2 = this.gLineTestProcessor;
					if (!this2.bIsConnSuccFlag)
					{
						MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						this2.SendStopCmd();
						System.Threading.Thread.Sleep(ctFormDeviceCalibration.SEND_STOP_CMD_NUM);
						this.gLineTestProcessor.mbKeepRun = true;
						this.bDCJZFlag = true;
						this.iTimeCount = 0;
						this.iJZType = 2;
						this.bSuccFlag = false;
						double dTemp = System.Convert.ToDouble(this.numericUpDown_DC.Text.ToString());
						int iV = System.Convert.ToInt32(dTemp * 10.0);
						this.timer1.Enabled = true;
						this.gLineTestProcessor.SendNYTimeCmd(5.0);
						this.gLineTestProcessor.DCJZFunc(iV);
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		private void btnJZ_AC_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.bJLDLJZFlag)
				{
					MessageBox.Show("校准中，请稍等!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					KLineTestProcessor this2 = this.gLineTestProcessor;
					if (!this2.bIsConnSuccFlag)
					{
						MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						this2.SendStopCmd();
						System.Threading.Thread.Sleep(ctFormDeviceCalibration.SEND_STOP_CMD_NUM);
						this.gLineTestProcessor.mbKeepRun = true;
						this.bACJZFlag = true;
						this.iTimeCount = 0;
						this.iJZType = 3;
						this.bSuccFlag = false;
						double dTemp = System.Convert.ToDouble(this.numericUpDown_AC.Text.ToString());
						int iV = System.Convert.ToInt32(dTemp * 10.0);
						this.timer1.Enabled = true;
						this.gLineTestProcessor.SendNYTimeCmd(5.0);
						this.gLineTestProcessor.ACJZFunc(iV);
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			try
			{
				int num = this.iJZType;
				if (num == 1)
				{
					KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
					if (kLineTestProcessor.mpDevComm.mParseCmd.bDTJZRFlag)
					{
						kLineTestProcessor.mbKeepRun = false;
						this.timer1.Enabled = false;
						this.bSuccFlag = true;
						string text = "";
						string tempStr = text;
						string showStr = text;
						int iIndex = 0;
						double dTemp = this.gLineTestProcessor.mpDevComm.mParseCmd.dDTJZValue;
						if (this.bZeroTestFlag)
						{
							this.dZeroValue = dTemp;
						}
						else
						{
							dTemp -= this.dZeroValue;
							if (dTemp <= 0.0)
							{
								dTemp = 0.0;
								goto IL_B0;
							}
						}
						if (dTemp >= 1000.0)
						{
							if (dTemp >= 1000.0 && dTemp < 1000000.0)
							{
								iIndex = 1;
								tempStr = System.Convert.ToString(System.Math.Round(dTemp / 1000.0, 3));
								goto IL_153;
							}
							if (dTemp >= 1000000.0 && dTemp < 1000000000.0)
							{
								iIndex = 2;
								tempStr = System.Convert.ToString(System.Math.Round(dTemp / 1000000.0, 3));
								goto IL_153;
							}
							if (dTemp >= 1000000000.0)
							{
								iIndex = 3;
								tempStr = System.Convert.ToString(System.Math.Round(dTemp / 1000000000.0, 3));
								goto IL_153;
							}
							goto IL_153;
						}
						IL_B0:
						iIndex = 0;
						tempStr = System.Convert.ToString(System.Math.Round(dTemp, 3));
						IL_153:
						int iTemp = tempStr.LastIndexOf('.');
						if (-1 == iTemp)
						{
							tempStr += ".";
							for (int i = 0; i < 3; i++)
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
						if (iIndex == 0)
						{
							showStr = tempStr;
						}
						else if (iIndex == 1)
						{
							showStr = tempStr + "K";
						}
						else if (iIndex == 2)
						{
							showStr = tempStr + "M";
						}
						else if (iIndex == 3)
						{
							showStr = tempStr + "G";
						}
						this.textBox_dt.Text = showStr;
					}
				}
				else if (num == 2)
				{
					int num2 = this.iTimeCount + 1;
					this.iTimeCount = num2;
					if (num2 >= 5)
					{
						this.timer1.Enabled = false;
						this.bDCJZFlag = false;
						this.btnJZ_DC.Enabled = true;
						this.gLineTestProcessor.SendStopCmd();
						this.gLineTestProcessor.mbKeepRun = false;
					}
				}
				else if (num == 3)
				{
					int num3 = this.iTimeCount + 1;
					this.iTimeCount = num3;
					if (num3 >= 5)
					{
						this.timer1.Enabled = false;
						this.bACJZFlag = false;
						this.btnJZ_AC.Enabled = true;
						this.gLineTestProcessor.SendStopCmd();
						this.gLineTestProcessor.mbKeepRun = false;
					}
				}
				else if (num == 4)
				{
					KLineTestProcessor kLineTestProcessor2 = this.gLineTestProcessor;
					if (kLineTestProcessor2.mpDevComm.mParseCmd.bJYDZJZRFlag)
					{
						kLineTestProcessor2.mbKeepRun = false;
						this.bSuccFlag = true;
						double dTemp2 = this.gLineTestProcessor.mpDevComm.mParseCmd.dJYDZJZValue;
						string tempStr2 = System.Convert.ToString(System.Math.Round(dTemp2, 3));
						int iTemp = tempStr2.LastIndexOf('.');
						if (-1 == iTemp)
						{
							tempStr2 += ".";
							for (int j = 0; j < 3; j++)
							{
								tempStr2 += "0";
							}
						}
						else
						{
							while (iTemp + 4 > tempStr2.Length)
							{
								tempStr2 += "0";
								iTemp = tempStr2.LastIndexOf('.');
							}
						}
						this.textBox_JYDZ.Text = tempStr2;
						this.timer1.Enabled = false;
						this.btnJZ_JYDZ.Enabled = true;
						this.bJYDZJZFlag = false;
						this.gLineTestProcessor.SendStopCmd();
						this.gLineTestProcessor.mbKeepRun = false;
					}
				}
				else if (num == 5)
				{
					KLineTestProcessor kLineTestProcessor3 = this.gLineTestProcessor;
					if (kLineTestProcessor3.mpDevComm.mParseCmd.bNYDLJZRFlag)
					{
						kLineTestProcessor3.mbKeepRun = false;
						this.bSuccFlag = true;
						double dTemp3 = this.gLineTestProcessor.mpDevComm.mParseCmd.dNYDLJZValue;
						string tempStr3 = System.Convert.ToString(System.Math.Round(dTemp3, 3));
						int iTemp = tempStr3.LastIndexOf('.');
						if (-1 == iTemp)
						{
							tempStr3 += ".";
							for (int k = 0; k < 3; k++)
							{
								tempStr3 += "0";
							}
						}
						else
						{
							while (iTemp + 4 > tempStr3.Length)
							{
								tempStr3 += "0";
								iTemp = tempStr3.LastIndexOf('.');
							}
						}
						this.textBox_NYDL.Text = tempStr3;
						this.timer1.Enabled = false;
						this.btnJZ_NYDL.Enabled = true;
						this.bJLDLJZFlag = false;
						this.gLineTestProcessor.SendStopCmd();
						this.gLineTestProcessor.mbKeepRun = false;
					}
				}
			}
			catch (System.Exception arg_4CE_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_4CE_0.StackTrace);
			}
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			this.bInquiryHintFlag = false;
			if (this.bDCJZFlag || this.bJYDZJZFlag || this.bJLDLJZFlag)
			{
				if (DialogResult.OK != MessageBox.Show("退出将停止校准，您确定退出吗?", "提示", MessageBoxButtons.OKCancel))
				{
					return;
				}
				this.gLineTestProcessor.SendStopCmd();
			}
			this.bInquiryHintFlag = true;
			base.Close();
		}
		private void ctFormDeviceCalibration_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (!this.bInquiryHintFlag)
				{
					if (this.bDCJZFlag || this.bJYDZJZFlag)
					{
						if (DialogResult.OK == MessageBox.Show("退出将停止校准，您确定退出吗?", "提示", MessageBoxButtons.OKCancel))
						{
							this.bInquiryHintFlag = true;
							this.gLineTestProcessor.SendStopCmd();
						}
						else
						{
							e.Cancel = true;
						}
					}
				}
			}
			catch (System.Exception arg_4A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_4A_0.StackTrace);
			}
		}
		private void btnJZ_JYDZ_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.bDCJZFlag)
				{
					MessageBox.Show("校准中，请稍等!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					KLineTestProcessor sender2 = this.gLineTestProcessor;
					if (!sender2.bIsConnSuccFlag)
					{
						MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						sender2.SendStopCmd();
						System.Threading.Thread.Sleep(ctFormDeviceCalibration.SEND_STOP_CMD_NUM);
						this.gLineTestProcessor.mbKeepRun = true;
						this.bJYDZJZFlag = true;
						this.textBox_JYDZ.Text = "";
						this.iTimeCount = 0;
						this.iJZType = 4;
						this.bSuccFlag = false;
						double dTemp = System.Convert.ToDouble(this.numericUpDown_JYDZ.Text.ToString());
						int iV = System.Convert.ToInt32(dTemp * 10.0);
						double dTemp2 = System.Convert.ToDouble(this.numericUpDown_rHT.Text.ToString());
						if (dTemp2 < 1.000001)
						{
							dTemp2 = 1.0;
						}
						int iR = System.Convert.ToInt32(dTemp2);
						this.gLineTestProcessor.mpDevComm.mParseCmd.bJYDZJZRFlag = false;
						this.gLineTestProcessor.mpDevComm.mParseCmd.dJYDZJZValue = 0.0;
						this.timer1.Enabled = true;
						this.gLineTestProcessor.SendNYTimeCmd((double)iR);
						this.gLineTestProcessor.JYDZJZFunc(iV);
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		private void btnJZ_JXDT_Click(object sender, System.EventArgs e)
		{
			try
			{
				KLineTestProcessor sender2 = this.gLineTestProcessor;
				if (!sender2.bIsConnSuccFlag)
				{
					MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					sender2.SendStopCmd();
					System.Threading.Thread.Sleep(ctFormDeviceCalibration.SEND_STOP_CMD_NUM);
					this.textBox_dt.Text = "";
					this.iJZType = 1;
					this.bSuccFlag = false;
					this.bZeroTestFlag = true;
					this.timer1.Enabled = true;
					this.gLineTestProcessor.mpDevComm.mParseCmd.bDTJZRFlag = false;
					KLineTestProcessor this2 = this.gLineTestProcessor;
					this2.mpDevComm.mParseCmd.dDTJZValue = 0.0;
					this2.mbKeepRun = true;
					this.gLineTestProcessor.SendDTVlotAndCurrentCmd(250.0, 2000.0);
					System.Threading.Thread.Sleep(300);
					this.gLineTestProcessor.DTVoltCal(1, 0, 0);
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		private void btnJZ_NYDL_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.bACJZFlag)
				{
					MessageBox.Show("校准中，请稍等!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					KLineTestProcessor sender2 = this.gLineTestProcessor;
					if (!sender2.bIsConnSuccFlag)
					{
						MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						sender2.SendStopCmd();
						System.Threading.Thread.Sleep(ctFormDeviceCalibration.SEND_STOP_CMD_NUM);
						this.gLineTestProcessor.mbKeepRun = true;
						this.bJLDLJZFlag = true;
						this.textBox_NYDL.Text = "";
						this.iTimeCount = 0;
						this.iJZType = 5;
						this.bSuccFlag = false;
						double dTemp = System.Convert.ToDouble(this.numericUpDown_AC_JZDY.Text.ToString());
						int iV = System.Convert.ToInt32(dTemp * 10.0);
						double dTemp2 = System.Convert.ToDouble(this.numericUpDown_AC_BCSJ.Text.ToString());
						if (dTemp2 < 1.000001)
						{
							dTemp2 = 1.0;
						}
						int iR = System.Convert.ToInt32(dTemp2);
						this.gLineTestProcessor.mpDevComm.mParseCmd.bNYDLJZRFlag = false;
						this.gLineTestProcessor.mpDevComm.mParseCmd.dNYDLJZValue = 0.0;
						this.timer1.Enabled = true;
						this.gLineTestProcessor.SendNYTimeCmd((double)iR);
						this.gLineTestProcessor.NYDLJZFunc(iV);
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		private void btnJZ_LVDC_Click(object sender, System.EventArgs e)
		{
			try
			{
				KLineTestProcessor this2 = this.gLineTestProcessor;
				if (!this2.bIsConnSuccFlag)
				{
					MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					this2.SendStopCmd();
					System.Threading.Thread.Sleep(ctFormDeviceCalibration.SEND_STOP_CMD_NUM);
					double dTemp = System.Convert.ToDouble(this.numericUpDown_LVDCmax.Value);
					double dTemp2 = System.Convert.ToDouble(this.numericUpDown_LVDLmax.Value);
					this.gLineTestProcessor.SendDTVlotAndCurrentCmd((dTemp + 0.04) * 100.0, dTemp2 - 2.0);
					System.Threading.Thread.Sleep(100);
					this.gLineTestProcessor.SendNYTimeCmd(5.0);
					this.gLineTestProcessor.DTVoltCal(1, 0, 0);
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		private void numericUpDown_DC_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_DC.Text.ToString().Trim();
				double dMaxValue = System.Convert.ToDouble(this.numericUpDown_DC.Maximum);
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dCurrValue = System.Convert.ToDouble(tempStr);
					if (dCurrValue > dMaxValue)
					{
						MessageBox.Show("输入值已超出最大值" + System.Convert.ToString(dMaxValue) + "，请重新输入!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception ex_64)
			{
			}
		}
		private void numericUpDown_JYDZ_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_JYDZ.Text.ToString().Trim();
				double dMaxValue = System.Convert.ToDouble(this.numericUpDown_JYDZ.Maximum);
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dCurrValue = System.Convert.ToDouble(tempStr);
					if (dCurrValue > dMaxValue)
					{
						MessageBox.Show("输入值已超出最大值" + System.Convert.ToString(dMaxValue) + "，请重新输入!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception ex_64)
			{
			}
		}
		private void numericUpDown_rHT_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_rHT.Text.ToString().Trim();
				double dMaxValue = System.Convert.ToDouble(this.numericUpDown_rHT.Maximum);
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dCurrValue = System.Convert.ToDouble(tempStr);
					if (dCurrValue > dMaxValue)
					{
						MessageBox.Show("输入值已超出最大值" + System.Convert.ToString(dMaxValue) + "，请重新输入!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception ex_64)
			{
			}
		}
		private void numericUpDown_AC_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_AC.Text.ToString().Trim();
				double dMaxValue = System.Convert.ToDouble(this.numericUpDown_AC.Maximum);
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dCurrValue = System.Convert.ToDouble(tempStr);
					if (dCurrValue > dMaxValue)
					{
						MessageBox.Show("输入值已超出最大值" + System.Convert.ToString(dMaxValue) + "，请重新输入!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception ex_64)
			{
			}
		}
		private void numericUpDown_AC_JZDY_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_AC_JZDY.Text.ToString().Trim();
				double dMaxValue = System.Convert.ToDouble(this.numericUpDown_AC_JZDY.Maximum);
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dCurrValue = System.Convert.ToDouble(tempStr);
					if (dCurrValue > dMaxValue)
					{
						MessageBox.Show("输入值已超出最大值" + System.Convert.ToString(dMaxValue) + "，请重新输入!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception ex_64)
			{
			}
		}
		private void numericUpDown_AC_BCSJ_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_AC_BCSJ.Text.ToString().Trim();
				double dMaxValue = System.Convert.ToDouble(this.numericUpDown_AC_BCSJ.Maximum);
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dCurrValue = System.Convert.ToDouble(tempStr);
					if (dCurrValue > dMaxValue)
					{
						MessageBox.Show("输入值已超出最大值" + System.Convert.ToString(dMaxValue) + "，请重新输入!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception ex_64)
			{
			}
		}
		private void numericUpDown_LVDCmax_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_LVDCmax.Text.ToString().Trim();
				double dMaxValue = System.Convert.ToDouble(this.numericUpDown_LVDCmax.Maximum);
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dCurrValue = System.Convert.ToDouble(tempStr);
					if (dCurrValue > dMaxValue)
					{
						MessageBox.Show("输入值已超出最大值" + System.Convert.ToString(dMaxValue) + "，请重新输入!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception ex_64)
			{
			}
		}
		private void numericUpDown_LVDLmax_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_LVDLmax.Text.ToString().Trim();
				double dMaxValue = System.Convert.ToDouble(this.numericUpDown_LVDLmax.Maximum);
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dCurrValue = System.Convert.ToDouble(tempStr);
					if (dCurrValue > dMaxValue)
					{
						MessageBox.Show("输入值已超出最大值" + System.Convert.ToString(dMaxValue) + "，请重新输入!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception ex_64)
			{
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormDeviceCalibration();
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
