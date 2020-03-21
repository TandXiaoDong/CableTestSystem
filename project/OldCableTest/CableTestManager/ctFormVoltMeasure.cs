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
	public class ctFormVoltMeasure : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public string dbpath;
		public int iQueryType;
		public int iTimeCount;
		public bool bSuccFlag;
		private Label label_QTC;
		private GroupBox groupBox4;
		private TextBox textBox_HVDC_RV;
		private Label label11;
		private NumericUpDown numericUpDown_HV_DC;
		private Button btn_HVDC_OUT;
		private Button btn_HVDC_QUERY;
		private Button btn_HVAC_QUERY;
		private Button btn_LVDC_QUERY;
		private System.Windows.Forms.Timer timer_r;
		private Label label12;
		private Label label13;
		private Label label14;
		private GroupBox groupBox1;
		private TextBox textBox_HVAC_RV;
		private Label label1;
		private NumericUpDown numericUpDown_HV_AC;
		private Button btn_HVAC_OUT;
		private Label label2;
		private Label label3;
		private Label label4;
		private GroupBox groupBox2;
		private TextBox textBox_LVDC_RV;
		private Label label5;
		private NumericUpDown numericUpDown_LV_DC;
		private Button btn_LVDC_OUT;
		private Label label6;
		private Label label7;
		private Label label8;
		private Button btnQuit;
		private IContainer components;
		public ctFormVoltMeasure(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.iQueryType = 0;
					this.iTimeCount = 0;
					this.bSuccFlag = false;
				}
				catch (System.Exception arg_3F_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_3F_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormVoltMeasure()
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
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormVoltMeasure));
			this.groupBox4 = new GroupBox();
			this.textBox_HVDC_RV = new TextBox();
			this.label11 = new Label();
			this.numericUpDown_HV_DC = new NumericUpDown();
			this.btn_HVDC_QUERY = new Button();
			this.btn_HVDC_OUT = new Button();
			this.label12 = new Label();
			this.label13 = new Label();
			this.label14 = new Label();
			this.groupBox1 = new GroupBox();
			this.textBox_HVAC_RV = new TextBox();
			this.label1 = new Label();
			this.numericUpDown_HV_AC = new NumericUpDown();
			this.btn_HVAC_QUERY = new Button();
			this.btn_HVAC_OUT = new Button();
			this.label2 = new Label();
			this.label3 = new Label();
			this.label4 = new Label();
			this.groupBox2 = new GroupBox();
			this.textBox_LVDC_RV = new TextBox();
			this.label5 = new Label();
			this.numericUpDown_LV_DC = new NumericUpDown();
			this.btn_LVDC_QUERY = new Button();
			this.btn_LVDC_OUT = new Button();
			this.label6 = new Label();
			this.label7 = new Label();
			this.label8 = new Label();
			this.btnQuit = new Button();
			this.timer_r = new System.Windows.Forms.Timer(this.components);
			this.label_QTC = new Label();
			this.groupBox4.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_HV_DC).BeginInit();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_HV_AC).BeginInit();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_LV_DC).BeginInit();
			base.SuspendLayout();
			this.groupBox4.Controls.Add(this.textBox_HVDC_RV);
			this.groupBox4.Controls.Add(this.label11);
			this.groupBox4.Controls.Add(this.numericUpDown_HV_DC);
			this.groupBox4.Controls.Add(this.btn_HVDC_QUERY);
			this.groupBox4.Controls.Add(this.btn_HVDC_OUT);
			this.groupBox4.Controls.Add(this.label12);
			this.groupBox4.Controls.Add(this.label13);
			this.groupBox4.Controls.Add(this.label14);
			this.groupBox4.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(20, 52);
			this.groupBox4.Location = location;
			Padding margin = new Padding(2, 2, 2, 2);
			this.groupBox4.Margin = margin;
			this.groupBox4.Name = "groupBox4";
			Padding padding = new Padding(2, 2, 2, 2);
			this.groupBox4.Padding = padding;
			System.Drawing.Size size = new System.Drawing.Size(756, 96);
			this.groupBox4.Size = size;
			this.groupBox4.TabIndex = 1;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "HV-DC";
			System.Drawing.Point location2 = new System.Drawing.Point(556, 41);
			this.textBox_HVDC_RV.Location = location2;
			Padding margin2 = new Padding(2, 2, 2, 2);
			this.textBox_HVDC_RV.Margin = margin2;
			this.textBox_HVDC_RV.Name = "textBox_HVDC_RV";
			this.textBox_HVDC_RV.ReadOnly = true;
			System.Drawing.Size size2 = new System.Drawing.Size(114, 24);
			this.textBox_HVDC_RV.Size = size2;
			this.textBox_HVDC_RV.TabIndex = 7;
			this.textBox_HVDC_RV.TextAlign = HorizontalAlignment.Center;
			this.label11.AutoSize = true;
			System.Drawing.Point location3 = new System.Drawing.Point(494, 45);
			this.label11.Location = location3;
			Padding margin3 = new Padding(2, 0, 2, 0);
			this.label11.Margin = margin3;
			this.label11.Name = "label11";
			System.Drawing.Size size3 = new System.Drawing.Size(60, 15);
			this.label11.Size = size3;
			this.label11.TabIndex = 3;
			this.label11.Text = "返回值:";
			System.Drawing.Point location4 = new System.Drawing.Point(97, 41);
			this.numericUpDown_HV_DC.Location = location4;
			Padding margin4 = new Padding(2, 2, 2, 2);
			this.numericUpDown_HV_DC.Margin = margin4;
			decimal maximum = new decimal(new int[]
			{
				1500,
				0,
				0,
				0
			});
			this.numericUpDown_HV_DC.Maximum = maximum;
			this.numericUpDown_HV_DC.Name = "numericUpDown_HV_DC";
			System.Drawing.Size size4 = new System.Drawing.Size(120, 24);
			this.numericUpDown_HV_DC.Size = size4;
			this.numericUpDown_HV_DC.TabIndex = 5;
			this.numericUpDown_HV_DC.TextAlign = HorizontalAlignment.Center;
			decimal value = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			this.numericUpDown_HV_DC.Value = value;
			System.Drawing.Point location5 = new System.Drawing.Point(310, 40);
			this.btn_HVDC_QUERY.Location = location5;
			Padding margin5 = new Padding(2, 2, 2, 2);
			this.btn_HVDC_QUERY.Margin = margin5;
			this.btn_HVDC_QUERY.Name = "btn_HVDC_QUERY";
			System.Drawing.Size size5 = new System.Drawing.Size(135, 24);
			this.btn_HVDC_QUERY.Size = size5;
			this.btn_HVDC_QUERY.TabIndex = 6;
			this.btn_HVDC_QUERY.Text = "输出并查询";
			this.btn_HVDC_QUERY.UseVisualStyleBackColor = true;
			this.btn_HVDC_QUERY.Click += new System.EventHandler(this.btn_HVDC_QUERY_Click);
			System.Drawing.Point location6 = new System.Drawing.Point(277, 40);
			this.btn_HVDC_OUT.Location = location6;
			Padding margin6 = new Padding(2, 2, 2, 2);
			this.btn_HVDC_OUT.Margin = margin6;
			this.btn_HVDC_OUT.Name = "btn_HVDC_OUT";
			System.Drawing.Size size6 = new System.Drawing.Size(15, 24);
			this.btn_HVDC_OUT.Size = size6;
			this.btn_HVDC_OUT.TabIndex = 6;
			this.btn_HVDC_OUT.Text = "输出";
			this.btn_HVDC_OUT.UseVisualStyleBackColor = true;
			this.btn_HVDC_OUT.Visible = false;
			this.btn_HVDC_OUT.Click += new System.EventHandler(this.btn_HVDC_OUT_Click);
			this.label12.AutoSize = true;
			System.Drawing.Point location7 = new System.Drawing.Point(31, 45);
			this.label12.Location = location7;
			Padding margin7 = new Padding(2, 0, 2, 0);
			this.label12.Margin = margin7;
			this.label12.Name = "label12";
			System.Drawing.Size size7 = new System.Drawing.Size(60, 15);
			this.label12.Size = size7;
			this.label12.TabIndex = 0;
			this.label12.Text = "测量值:";
			this.label13.AutoSize = true;
			System.Drawing.Point location8 = new System.Drawing.Point(675, 45);
			this.label13.Location = location8;
			Padding margin8 = new Padding(2, 0, 2, 0);
			this.label13.Margin = margin8;
			this.label13.Name = "label13";
			System.Drawing.Size size8 = new System.Drawing.Size(31, 15);
			this.label13.Size = size8;
			this.label13.TabIndex = 0;
			this.label13.Text = "VDC";
			this.label14.AutoSize = true;
			System.Drawing.Point location9 = new System.Drawing.Point(224, 45);
			this.label14.Location = location9;
			Padding margin9 = new Padding(2, 0, 2, 0);
			this.label14.Margin = margin9;
			this.label14.Name = "label14";
			System.Drawing.Size size9 = new System.Drawing.Size(31, 15);
			this.label14.Size = size9;
			this.label14.TabIndex = 0;
			this.label14.Text = "VDC";
			this.groupBox1.Controls.Add(this.textBox_HVAC_RV);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.numericUpDown_HV_AC);
			this.groupBox1.Controls.Add(this.btn_HVAC_QUERY);
			this.groupBox1.Controls.Add(this.btn_HVAC_OUT);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location10 = new System.Drawing.Point(20, 284);
			this.groupBox1.Location = location10;
			Padding margin10 = new Padding(2, 2, 2, 2);
			this.groupBox1.Margin = margin10;
			this.groupBox1.Name = "groupBox1";
			Padding padding2 = new Padding(2, 2, 2, 2);
			this.groupBox1.Padding = padding2;
			System.Drawing.Size size10 = new System.Drawing.Size(756, 96);
			this.groupBox1.Size = size10;
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "HV-AC";
			System.Drawing.Point location11 = new System.Drawing.Point(556, 41);
			this.textBox_HVAC_RV.Location = location11;
			Padding margin11 = new Padding(2, 2, 2, 2);
			this.textBox_HVAC_RV.Margin = margin11;
			this.textBox_HVAC_RV.Name = "textBox_HVAC_RV";
			this.textBox_HVAC_RV.ReadOnly = true;
			System.Drawing.Size size11 = new System.Drawing.Size(114, 24);
			this.textBox_HVAC_RV.Size = size11;
			this.textBox_HVAC_RV.TabIndex = 7;
			this.textBox_HVAC_RV.TextAlign = HorizontalAlignment.Center;
			this.label1.AutoSize = true;
			System.Drawing.Point location12 = new System.Drawing.Point(494, 45);
			this.label1.Location = location12;
			Padding margin12 = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin12;
			this.label1.Name = "label1";
			System.Drawing.Size size12 = new System.Drawing.Size(60, 15);
			this.label1.Size = size12;
			this.label1.TabIndex = 3;
			this.label1.Text = "返回值:";
			System.Drawing.Point location13 = new System.Drawing.Point(97, 41);
			this.numericUpDown_HV_AC.Location = location13;
			Padding margin13 = new Padding(2, 2, 2, 2);
			this.numericUpDown_HV_AC.Margin = margin13;
			decimal maximum2 = new decimal(new int[]
			{
				1000,
				0,
				0,
				0
			});
			this.numericUpDown_HV_AC.Maximum = maximum2;
			this.numericUpDown_HV_AC.Name = "numericUpDown_HV_AC";
			System.Drawing.Size size13 = new System.Drawing.Size(120, 24);
			this.numericUpDown_HV_AC.Size = size13;
			this.numericUpDown_HV_AC.TabIndex = 5;
			this.numericUpDown_HV_AC.TextAlign = HorizontalAlignment.Center;
			decimal value2 = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			this.numericUpDown_HV_AC.Value = value2;
			System.Drawing.Point location14 = new System.Drawing.Point(310, 40);
			this.btn_HVAC_QUERY.Location = location14;
			Padding margin14 = new Padding(2, 2, 2, 2);
			this.btn_HVAC_QUERY.Margin = margin14;
			this.btn_HVAC_QUERY.Name = "btn_HVAC_QUERY";
			System.Drawing.Size size14 = new System.Drawing.Size(135, 24);
			this.btn_HVAC_QUERY.Size = size14;
			this.btn_HVAC_QUERY.TabIndex = 6;
			this.btn_HVAC_QUERY.Text = "输出并查询";
			this.btn_HVAC_QUERY.UseVisualStyleBackColor = true;
			this.btn_HVAC_QUERY.Click += new System.EventHandler(this.btn_HVAC_QUERY_Click);
			System.Drawing.Point location15 = new System.Drawing.Point(277, 40);
			this.btn_HVAC_OUT.Location = location15;
			Padding margin15 = new Padding(2, 2, 2, 2);
			this.btn_HVAC_OUT.Margin = margin15;
			this.btn_HVAC_OUT.Name = "btn_HVAC_OUT";
			System.Drawing.Size size15 = new System.Drawing.Size(15, 24);
			this.btn_HVAC_OUT.Size = size15;
			this.btn_HVAC_OUT.TabIndex = 6;
			this.btn_HVAC_OUT.Text = "输出";
			this.btn_HVAC_OUT.UseVisualStyleBackColor = true;
			this.btn_HVAC_OUT.Visible = false;
			this.btn_HVAC_OUT.Click += new System.EventHandler(this.btn_HVAC_OUT_Click);
			this.label2.AutoSize = true;
			System.Drawing.Point location16 = new System.Drawing.Point(31, 45);
			this.label2.Location = location16;
			Padding margin16 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin16;
			this.label2.Name = "label2";
			System.Drawing.Size size16 = new System.Drawing.Size(60, 15);
			this.label2.Size = size16;
			this.label2.TabIndex = 0;
			this.label2.Text = "测量值:";
			this.label3.AutoSize = true;
			System.Drawing.Point location17 = new System.Drawing.Point(675, 45);
			this.label3.Location = location17;
			Padding margin17 = new Padding(2, 0, 2, 0);
			this.label3.Margin = margin17;
			this.label3.Name = "label3";
			System.Drawing.Size size17 = new System.Drawing.Size(31, 15);
			this.label3.Size = size17;
			this.label3.TabIndex = 0;
			this.label3.Text = "VAC";
			this.label4.AutoSize = true;
			System.Drawing.Point location18 = new System.Drawing.Point(224, 45);
			this.label4.Location = location18;
			Padding margin18 = new Padding(2, 0, 2, 0);
			this.label4.Margin = margin18;
			this.label4.Name = "label4";
			System.Drawing.Size size18 = new System.Drawing.Size(31, 15);
			this.label4.Size = size18;
			this.label4.TabIndex = 0;
			this.label4.Text = "VAC";
			this.groupBox2.Controls.Add(this.textBox_LVDC_RV);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.numericUpDown_LV_DC);
			this.groupBox2.Controls.Add(this.btn_LVDC_QUERY);
			this.groupBox2.Controls.Add(this.btn_LVDC_OUT);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location19 = new System.Drawing.Point(20, 168);
			this.groupBox2.Location = location19;
			Padding margin19 = new Padding(2, 2, 2, 2);
			this.groupBox2.Margin = margin19;
			this.groupBox2.Name = "groupBox2";
			Padding padding3 = new Padding(2, 2, 2, 2);
			this.groupBox2.Padding = padding3;
			System.Drawing.Size size19 = new System.Drawing.Size(756, 96);
			this.groupBox2.Size = size19;
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "LV-DC";
			this.groupBox2.Visible = false;
			System.Drawing.Point location20 = new System.Drawing.Point(556, 41);
			this.textBox_LVDC_RV.Location = location20;
			Padding margin20 = new Padding(2, 2, 2, 2);
			this.textBox_LVDC_RV.Margin = margin20;
			this.textBox_LVDC_RV.Name = "textBox_LVDC_RV";
			this.textBox_LVDC_RV.ReadOnly = true;
			System.Drawing.Size size20 = new System.Drawing.Size(114, 24);
			this.textBox_LVDC_RV.Size = size20;
			this.textBox_LVDC_RV.TabIndex = 7;
			this.textBox_LVDC_RV.TextAlign = HorizontalAlignment.Center;
			this.textBox_LVDC_RV.Visible = false;
			this.label5.AutoSize = true;
			System.Drawing.Point location21 = new System.Drawing.Point(494, 45);
			this.label5.Location = location21;
			Padding margin21 = new Padding(2, 0, 2, 0);
			this.label5.Margin = margin21;
			this.label5.Name = "label5";
			System.Drawing.Size size21 = new System.Drawing.Size(60, 15);
			this.label5.Size = size21;
			this.label5.TabIndex = 3;
			this.label5.Text = "返回值:";
			this.label5.Visible = false;
			this.numericUpDown_LV_DC.DecimalPlaces = 1;
			System.Drawing.Point location22 = new System.Drawing.Point(97, 41);
			this.numericUpDown_LV_DC.Location = location22;
			Padding margin22 = new Padding(2, 2, 2, 2);
			this.numericUpDown_LV_DC.Margin = margin22;
			decimal maximum3 = new decimal(new int[]
			{
				1500,
				0,
				0,
				0
			});
			this.numericUpDown_LV_DC.Maximum = maximum3;
			this.numericUpDown_LV_DC.Name = "numericUpDown_LV_DC";
			System.Drawing.Size size22 = new System.Drawing.Size(120, 24);
			this.numericUpDown_LV_DC.Size = size22;
			this.numericUpDown_LV_DC.TabIndex = 5;
			this.numericUpDown_LV_DC.TextAlign = HorizontalAlignment.Center;
			decimal value3 = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			this.numericUpDown_LV_DC.Value = value3;
			System.Drawing.Point location23 = new System.Drawing.Point(450, 40);
			this.btn_LVDC_QUERY.Location = location23;
			Padding margin23 = new Padding(2, 2, 2, 2);
			this.btn_LVDC_QUERY.Margin = margin23;
			this.btn_LVDC_QUERY.Name = "btn_LVDC_QUERY";
			System.Drawing.Size size23 = new System.Drawing.Size(21, 24);
			this.btn_LVDC_QUERY.Size = size23;
			this.btn_LVDC_QUERY.TabIndex = 6;
			this.btn_LVDC_QUERY.Text = "输出并查询";
			this.btn_LVDC_QUERY.UseVisualStyleBackColor = true;
			this.btn_LVDC_QUERY.Visible = false;
			this.btn_LVDC_QUERY.Click += new System.EventHandler(this.btn_LVDC_QUERY_Click);
			System.Drawing.Point location24 = new System.Drawing.Point(310, 40);
			this.btn_LVDC_OUT.Location = location24;
			Padding margin24 = new Padding(2, 2, 2, 2);
			this.btn_LVDC_OUT.Margin = margin24;
			this.btn_LVDC_OUT.Name = "btn_LVDC_OUT";
			System.Drawing.Size size24 = new System.Drawing.Size(135, 24);
			this.btn_LVDC_OUT.Size = size24;
			this.btn_LVDC_OUT.TabIndex = 6;
			this.btn_LVDC_OUT.Text = "输出";
			this.btn_LVDC_OUT.UseVisualStyleBackColor = true;
			this.btn_LVDC_OUT.Click += new System.EventHandler(this.btn_LVDC_OUT_Click);
			this.label6.AutoSize = true;
			System.Drawing.Point location25 = new System.Drawing.Point(31, 45);
			this.label6.Location = location25;
			Padding margin25 = new Padding(2, 0, 2, 0);
			this.label6.Margin = margin25;
			this.label6.Name = "label6";
			System.Drawing.Size size25 = new System.Drawing.Size(60, 15);
			this.label6.Size = size25;
			this.label6.TabIndex = 0;
			this.label6.Text = "测量值:";
			this.label7.AutoSize = true;
			System.Drawing.Point location26 = new System.Drawing.Point(675, 45);
			this.label7.Location = location26;
			Padding margin26 = new Padding(2, 0, 2, 0);
			this.label7.Margin = margin26;
			this.label7.Name = "label7";
			System.Drawing.Size size26 = new System.Drawing.Size(31, 15);
			this.label7.Size = size26;
			this.label7.TabIndex = 0;
			this.label7.Text = "VDC";
			this.label7.Visible = false;
			this.label8.AutoSize = true;
			System.Drawing.Point location27 = new System.Drawing.Point(224, 45);
			this.label8.Location = location27;
			Padding margin27 = new Padding(2, 0, 2, 0);
			this.label8.Margin = margin27;
			this.label8.Name = "label8";
			System.Drawing.Size size27 = new System.Drawing.Size(31, 15);
			this.label8.Size = size27;
			this.label8.TabIndex = 0;
			this.label8.Text = "VDC";
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location28 = new System.Drawing.Point(330, 465);
			this.btnQuit.Location = location28;
			Padding margin28 = new Padding(2, 2, 2, 2);
			this.btnQuit.Margin = margin28;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size28 = new System.Drawing.Size(135, 24);
			this.btnQuit.Size = size28;
			this.btnQuit.TabIndex = 2;
			this.btnQuit.Text = "关闭";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.timer_r.Interval = 1000;
			this.timer_r.Tick += new System.EventHandler(this.timer_r_Tick);
			this.label_QTC.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location29 = new System.Drawing.Point(330, 14);
			this.label_QTC.Location = location29;
			Padding margin29 = new Padding(2, 0, 2, 0);
			this.label_QTC.Margin = margin29;
			this.label_QTC.Name = "label_QTC";
			System.Drawing.Size size29 = new System.Drawing.Size(135, 24);
			this.label_QTC.Size = size29;
			this.label_QTC.TabIndex = 8;
			this.label_QTC.Text = "查询计时: 0 秒";
			this.label_QTC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.label_QTC);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox4);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin30 = new Padding(2, 2, 2, 2);
			base.Margin = margin30;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormVoltMeasure";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "电压测量";
			base.FormClosing += new FormClosingEventHandler(this.ctFormVoltMeasure_FormClosing);
			base.Load += new System.EventHandler(this.ctFormVoltMeasure_Load);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((ISupportInitialize)this.numericUpDown_HV_DC).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((ISupportInitialize)this.numericUpDown_HV_AC).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((ISupportInitialize)this.numericUpDown_LV_DC).EndInit();
			base.ResumeLayout(false);
		}
		public void LoadDefaultParaFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				double d_JY_DCVolt_Min = 0.0;
				double d_JY_DCVolt_Max = 0.0;
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
						d_JY_DCVolt_Min = System.Convert.ToDouble(dataReader["d_JY_DCVolt_Min"].ToString());
						d_JY_DCVolt_Max = System.Convert.ToDouble(dataReader["d_JY_DCVolt_Max"].ToString());
						d_NY_ACVolt_Min = System.Convert.ToDouble(dataReader["d_NY_ACVolt_Min"].ToString());
						d_NY_ACVolt_Max = System.Convert.ToDouble(dataReader["d_NY_ACVolt_Max"].ToString());
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_D6_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_D6_0.StackTrace);
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
					decimal maximum = System.Convert.ToDecimal(d_JY_DCVolt_Max);
					this.numericUpDown_HV_DC.Maximum = maximum;
					decimal value = System.Convert.ToDecimal(d_JY_DCVolt_Min);
					this.numericUpDown_HV_DC.Value = value;
					decimal maximum2 = System.Convert.ToDecimal(d_NY_ACVolt_Max);
					this.numericUpDown_HV_AC.Maximum = maximum2;
					decimal value2 = System.Convert.ToDecimal(d_NY_ACVolt_Min);
					this.numericUpDown_HV_AC.Value = value2;
					decimal maximum3 = System.Convert.ToDecimal(d_JY_DCVolt_Max);
					this.numericUpDown_LV_DC.Maximum = maximum3;
					decimal value3 = System.Convert.ToDecimal(d_JY_DCVolt_Min);
					this.numericUpDown_LV_DC.Value = value3;
				}
			}
			catch (System.Exception arg_181_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_181_0.StackTrace);
			}
		}
		private void ctFormVoltMeasure_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.LoadDefaultParaFunc();
			}
			catch (System.Exception arg_08_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_08_0.StackTrace);
			}
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			base.Close();
		}
		private void timer_r_Tick(object sender, System.EventArgs e)
		{
			try
			{
				int this2 = this.iQueryType;
				if (this2 == 1)
				{
					this.iTimeCount++;
					KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
					if (kLineTestProcessor.mpDevComm.mParseCmd.bHVDC_RFlag)
					{
						this.bSuccFlag = true;
						double dTemp = kLineTestProcessor.mpDevComm.mParseCmd.dHVDC_Value;
						this.textBox_HVDC_RV.Text = System.Convert.ToString(dTemp);
					}
					if (this.bSuccFlag || this.iTimeCount > 5)
					{
						this.gLineTestProcessor.mbKeepRun = false;
						this.timer_r.Enabled = false;
						this.gLineTestProcessor.SendStopCmd();
					}
					if (this.iTimeCount > 5 && !this.bSuccFlag)
					{
						MessageBox.Show("查询失败!", "提示", MessageBoxButtons.OK);
						return;
					}
				}
				else if (this2 == 2)
				{
					this.iTimeCount++;
					KLineTestProcessor e2 = this.gLineTestProcessor;
					if (e2.mpDevComm.mParseCmd.bLVDC_RFlag)
					{
						this.bSuccFlag = true;
						double dTemp2 = e2.mpDevComm.mParseCmd.dLVDC_Value;
						this.textBox_LVDC_RV.Text = System.Convert.ToString(dTemp2);
					}
					if (this.bSuccFlag || this.iTimeCount > 5)
					{
						this.gLineTestProcessor.mbKeepRun = false;
						this.timer_r.Enabled = false;
						this.gLineTestProcessor.SendStopCmd();
					}
					if (this.iTimeCount > 5 && !this.bSuccFlag)
					{
						MessageBox.Show("查询失败!", "提示", MessageBoxButtons.OK);
						return;
					}
				}
				else if (this2 == 3)
				{
					this.iTimeCount++;
					KLineTestProcessor sender2 = this.gLineTestProcessor;
					if (sender2.mpDevComm.mParseCmd.bHVAC_RFlag)
					{
						this.bSuccFlag = true;
						double dTemp3 = sender2.mpDevComm.mParseCmd.dHVAC_Value;
						this.textBox_HVAC_RV.Text = System.Convert.ToString(dTemp3);
					}
					if (this.bSuccFlag || this.iTimeCount > 5)
					{
						this.gLineTestProcessor.mbKeepRun = false;
						this.timer_r.Enabled = false;
						this.gLineTestProcessor.SendStopCmd();
					}
					if (this.iTimeCount > 5 && !this.bSuccFlag)
					{
						MessageBox.Show("查询失败!", "提示", MessageBoxButtons.OK);
						return;
					}
				}
				this.label_QTC.Text = "查询计时: " + System.Convert.ToString(this.iTimeCount) + " 秒";
			}
			catch (System.Exception arg_25B_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_25B_0.StackTrace);
			}
		}
		private void btn_HVDC_OUT_Click(object sender, System.EventArgs e)
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
					this2.mbKeepRun = true;
					double dTemp = System.Convert.ToDouble(this.numericUpDown_HV_DC.Value);
					this.gLineTestProcessor.DYCL_HVDCFunc(dTemp);
				}
			}
			catch (System.Exception arg_48_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_48_0.StackTrace);
			}
		}
		private void btn_HVDC_QUERY_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.gLineTestProcessor.bIsConnSuccFlag)
				{
					MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					double dTemp = System.Convert.ToDouble(this.numericUpDown_HV_DC.Value);
					this.gLineTestProcessor.DYCL_HVDCFunc(dTemp);
					System.Threading.Thread.Sleep(500);
					this.label_QTC.Text = "查询计时: 0 秒";
					this.timer_r.Enabled = true;
					this.iTimeCount = 0;
					this.iQueryType = 1;
					this.bSuccFlag = false;
					this.textBox_HVDC_RV.Text = "";
					this.gLineTestProcessor.mbKeepRun = true;
					this.gLineTestProcessor.mpDevComm.mParseCmd.bHVDC_RFlag = false;
					KLineTestProcessor this2 = this.gLineTestProcessor;
					this2.mpDevComm.mParseCmd.dHVDC_Value = 0.0;
					this2.DYCL_HVDC_QUERYFunc();
				}
			}
			catch (System.Exception arg_D5_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_D5_0.StackTrace);
			}
		}
		private void btn_LVDC_OUT_Click(object sender, System.EventArgs e)
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
					this2.mbKeepRun = true;
					double dTemp = System.Convert.ToDouble(this.numericUpDown_LV_DC.Value);
					this.gLineTestProcessor.DYCL_LVDCFunc(dTemp * 100.0, 2000.0);
				}
			}
			catch (System.Exception arg_5B_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5B_0.StackTrace);
			}
		}
		private void btn_LVDC_QUERY_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.gLineTestProcessor.bIsConnSuccFlag)
				{
					MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					double dTemp = System.Convert.ToDouble(this.numericUpDown_LV_DC.Value);
					this.gLineTestProcessor.DYCL_LVDCFunc(dTemp * 100.0, 2000.0);
					System.Threading.Thread.Sleep(500);
					this.label_QTC.Text = "查询计时: 0 秒";
					this.timer_r.Enabled = true;
					this.iTimeCount = 0;
					this.iQueryType = 2;
					this.bSuccFlag = false;
					this.textBox_LVDC_RV.Text = "";
					this.gLineTestProcessor.mbKeepRun = true;
					this.gLineTestProcessor.mpDevComm.mParseCmd.bLVDC_RFlag = false;
					KLineTestProcessor this2 = this.gLineTestProcessor;
					this2.mpDevComm.mParseCmd.dLVDC_Value = 0.0;
					this2.DYCL_LVDC_QUERYFunc();
				}
			}
			catch (System.Exception arg_E8_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_E8_0.StackTrace);
			}
		}
		private void btn_HVAC_OUT_Click(object sender, System.EventArgs e)
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
					this2.mbKeepRun = true;
					double dTemp = System.Convert.ToDouble(this.numericUpDown_HV_AC.Value);
					this.gLineTestProcessor.DYCL_HVACFunc(dTemp);
				}
			}
			catch (System.Exception arg_48_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_48_0.StackTrace);
			}
		}
		private void btn_HVAC_QUERY_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.gLineTestProcessor.bIsConnSuccFlag)
				{
					MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					double dTemp = System.Convert.ToDouble(this.numericUpDown_HV_AC.Value);
					this.gLineTestProcessor.DYCL_HVACFunc(dTemp);
					System.Threading.Thread.Sleep(500);
					this.label_QTC.Text = "查询计时: 0 秒";
					this.timer_r.Enabled = true;
					this.iTimeCount = 0;
					this.iQueryType = 3;
					this.bSuccFlag = false;
					this.textBox_HVAC_RV.Text = "";
					this.gLineTestProcessor.mbKeepRun = true;
					this.gLineTestProcessor.mpDevComm.mParseCmd.bHVAC_RFlag = false;
					this.gLineTestProcessor.mpDevComm.mParseCmd.bHVAC_RFlag = false;
					this.gLineTestProcessor.DYCL_HVAC_QUERYFunc();
				}
			}
			catch (System.Exception arg_D0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_D0_0.StackTrace);
			}
		}
		private void ctFormVoltMeasure_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				this.timer_r.Enabled = false;
				this.gLineTestProcessor.mbKeepRun = false;
				this.gLineTestProcessor.SendStopCmd();
			}
			catch (System.Exception arg_25_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_25_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormVoltMeasure();
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
