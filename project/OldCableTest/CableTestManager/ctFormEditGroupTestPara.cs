using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormEditGroupTestPara : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public GroupTestParaStruct gtpStruct;
		public bool bSubmitSuccFlag;
		public bool bUpdateAllPlugFlag;
		public string dbpath;
		public double d_DT_Threshold_Min;
		public double d_DT_Threshold_Max;
		public double d_DT_Volt_Min;
		public double d_DT_Volt_Max;
		public double d_DT_Current_Min;
		public double d_DT_Current_Max;
		public double d_JY_Threshold_Min;
		public double d_JY_Threshold_Max;
		public double d_JY_HoldTime_Min;
		public double d_JY_HoldTime_Max;
		public double d_JY_DCVolt_Min;
		public double d_JY_DCVolt_Max;
		public double d_JY_DCRiseTime_Min;
		public double d_JY_DCRiseTime_Max;
		public double d_NY_Threshold_Min;
		public double d_NY_Threshold_Max;
		public double d_NY_HoldTime_Min;
		public double d_NY_HoldTime_Max;
		public double d_NY_ACVolt_Min;
		public double d_NY_ACVolt_Max;
		public string beDTThresholdStr;
		public string beJYThresholdStr;
		public string beJYTestTimeStr;
		public string beJYVoltageStr;
		public string beNYThresholdStr;
		public string beNYTestTimeStr;
		public string beNYVoltageStr;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label_PlugName1;
		private Label label_PinName1;
		private Label label_PlugName2;
		private Label label_PinName2;
		private FlowLayoutPanel flowLayoutPanel1;
		private FlowLayoutPanel flowLayoutPanel2;
		private Label label_DTThreshold;
		private Label label_JYThreshold;
		private Label label_JYTestTime;
		private Label label_JYVoltage;
		private Label label_NYThreshold;
		private Label label_NYTestTime;
		private Label label_NYVoltage;
		private NumericUpDown numericUpDown_DTThreshold;
		private NumericUpDown numericUpDown_JYThreshold;
		private NumericUpDown numericUpDown_JYTestTime;
		private NumericUpDown numericUpDown_JYVoltage;
		private NumericUpDown numericUpDown_NYThreshold;
		private NumericUpDown numericUpDown_NYTestTime;
		private NumericUpDown numericUpDown_NYVoltage;
		private Button btnQuit;
		private Button btnSubmit;
		private Container components;
		public ctFormEditGroupTestPara(KLineTestProcessor gltProcessor, GroupTestParaStruct gtpTempStruct)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.bSubmitSuccFlag = false;
					GroupTestParaStruct this2 = new GroupTestParaStruct();
					this.gtpStruct = this2;
					this2.ixh = gtpTempStruct.ixh;
					this.gtpStruct.PlugName1 = gtpTempStruct.PlugName1;
					this.gtpStruct.PinName1 = gtpTempStruct.PinName1;
					this.gtpStruct.PlugName2 = gtpTempStruct.PlugName2;
					this.gtpStruct.PinName2 = gtpTempStruct.PinName2;
					this.gtpStruct.DTThreshold = gtpTempStruct.DTThreshold;
					this.gtpStruct.JYThreshold = gtpTempStruct.JYThreshold;
					this.gtpStruct.JYTestTime = gtpTempStruct.JYTestTime;
					this.gtpStruct.JYVoltage = gtpTempStruct.JYVoltage;
					this.gtpStruct.NYThreshold = gtpTempStruct.NYThreshold;
					this.gtpStruct.NYTestTime = gtpTempStruct.NYTestTime;
					this.gtpStruct.NYVoltage = gtpTempStruct.NYVoltage;
				}
				catch (System.Exception ex_105)
				{
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormEditGroupTestPara()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormEditGroupTestPara));
			this.btnQuit = new Button();
			this.btnSubmit = new Button();
			this.flowLayoutPanel1 = new FlowLayoutPanel();
			this.label1 = new Label();
			this.label2 = new Label();
			this.label3 = new Label();
			this.label4 = new Label();
			this.label_DTThreshold = new Label();
			this.label_JYThreshold = new Label();
			this.label_JYTestTime = new Label();
			this.label_JYVoltage = new Label();
			this.label_NYThreshold = new Label();
			this.label_NYTestTime = new Label();
			this.label_NYVoltage = new Label();
			this.flowLayoutPanel2 = new FlowLayoutPanel();
			this.label_PlugName1 = new Label();
			this.label_PinName1 = new Label();
			this.label_PlugName2 = new Label();
			this.label_PinName2 = new Label();
			this.numericUpDown_DTThreshold = new NumericUpDown();
			this.numericUpDown_JYThreshold = new NumericUpDown();
			this.numericUpDown_JYTestTime = new NumericUpDown();
			this.numericUpDown_JYVoltage = new NumericUpDown();
			this.numericUpDown_NYThreshold = new NumericUpDown();
			this.numericUpDown_NYTestTime = new NumericUpDown();
			this.numericUpDown_NYVoltage = new NumericUpDown();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_DTThreshold).BeginInit();
			((ISupportInitialize)this.numericUpDown_JYThreshold).BeginInit();
			((ISupportInitialize)this.numericUpDown_JYTestTime).BeginInit();
			((ISupportInitialize)this.numericUpDown_JYVoltage).BeginInit();
			((ISupportInitialize)this.numericUpDown_NYThreshold).BeginInit();
			((ISupportInitialize)this.numericUpDown_NYTestTime).BeginInit();
			((ISupportInitialize)this.numericUpDown_NYVoltage).BeginInit();
			base.SuspendLayout();
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(363, 497);
			this.btnQuit.Location = location;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size = new System.Drawing.Size(120, 30);
			this.btnQuit.Size = size;
			this.btnQuit.TabIndex = 12;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btnSubmit.Anchor = AnchorStyles.Bottom;
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(172, 497);
			this.btnSubmit.Location = location2;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size2 = new System.Drawing.Size(120, 30);
			this.btnSubmit.Size = size2;
			this.btnSubmit.TabIndex = 8;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.flowLayoutPanel1.Anchor = AnchorStyles.Top;
			this.flowLayoutPanel1.Controls.Add(this.label1);
			this.flowLayoutPanel1.Controls.Add(this.label2);
			this.flowLayoutPanel1.Controls.Add(this.label3);
			this.flowLayoutPanel1.Controls.Add(this.label4);
			this.flowLayoutPanel1.Controls.Add(this.label_DTThreshold);
			this.flowLayoutPanel1.Controls.Add(this.label_JYThreshold);
			this.flowLayoutPanel1.Controls.Add(this.label_JYTestTime);
			this.flowLayoutPanel1.Controls.Add(this.label_JYVoltage);
			this.flowLayoutPanel1.Controls.Add(this.label_NYThreshold);
			this.flowLayoutPanel1.Controls.Add(this.label_NYTestTime);
			this.flowLayoutPanel1.Controls.Add(this.label_NYVoltage);
			this.flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
			System.Drawing.Point location3 = new System.Drawing.Point(30, 22);
			this.flowLayoutPanel1.Location = location3;
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			System.Drawing.Size size3 = new System.Drawing.Size(228, 450);
			this.flowLayoutPanel1.Size = size3;
			this.flowLayoutPanel1.TabIndex = 22;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(123, 10);
			this.label1.Location = location4;
			Padding margin = new Padding(10, 10, 10, 6);
			this.label1.Margin = margin;
			this.label1.Name = "label1";
			System.Drawing.Size size4 = new System.Drawing.Size(95, 19);
			this.label1.Size = size4;
			this.label1.TabIndex = 33;
			this.label1.Text = "起点接口:";
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(123, 45);
			this.label2.Location = location5;
			Padding margin2 = new Padding(10, 10, 10, 6);
			this.label2.Margin = margin2;
			this.label2.Name = "label2";
			System.Drawing.Size size5 = new System.Drawing.Size(95, 19);
			this.label2.Size = size5;
			this.label2.TabIndex = 32;
			this.label2.Text = "起点接点:";
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(123, 80);
			this.label3.Location = location6;
			Padding margin3 = new Padding(10, 10, 10, 6);
			this.label3.Margin = margin3;
			this.label3.Name = "label3";
			System.Drawing.Size size6 = new System.Drawing.Size(95, 19);
			this.label3.Size = size6;
			this.label3.TabIndex = 34;
			this.label3.Text = "终点接口:";
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(123, 115);
			this.label4.Location = location7;
			Padding margin4 = new Padding(10);
			this.label4.Margin = margin4;
			this.label4.Name = "label4";
			System.Drawing.Size size7 = new System.Drawing.Size(95, 19);
			this.label4.Size = size7;
			this.label4.TabIndex = 35;
			this.label4.Text = "终点接点:";
			this.label_DTThreshold.AutoSize = true;
			this.label_DTThreshold.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(84, 154);
			this.label_DTThreshold.Location = location8;
			Padding margin5 = new Padding(10);
			this.label_DTThreshold.Margin = margin5;
			this.label_DTThreshold.Name = "label_DTThreshold";
			System.Drawing.Size size8 = new System.Drawing.Size(134, 19);
			this.label_DTThreshold.Size = size8;
			this.label_DTThreshold.TabIndex = 26;
			this.label_DTThreshold.Text = "导通阈值(Ω):";
			this.label_JYThreshold.AutoSize = true;
			this.label_JYThreshold.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(74, 193);
			this.label_JYThreshold.Location = location9;
			Padding margin6 = new Padding(10);
			this.label_JYThreshold.Margin = margin6;
			this.label_JYThreshold.Name = "label_JYThreshold";
			System.Drawing.Size size9 = new System.Drawing.Size(144, 19);
			this.label_JYThreshold.Size = size9;
			this.label_JYThreshold.TabIndex = 25;
			this.label_JYThreshold.Text = "绝缘阈值(MΩ):";
			this.label_JYTestTime.AutoSize = true;
			this.label_JYTestTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location10 = new System.Drawing.Point(55, 232);
			this.label_JYTestTime.Location = location10;
			Padding margin7 = new Padding(10);
			this.label_JYTestTime.Margin = margin7;
			this.label_JYTestTime.Name = "label_JYTestTime";
			System.Drawing.Size size10 = new System.Drawing.Size(163, 19);
			this.label_JYTestTime.Size = size10;
			this.label_JYTestTime.TabIndex = 28;
			this.label_JYTestTime.Text = "绝缘保持时间(s):";
			this.label_JYVoltage.AutoSize = true;
			this.label_JYVoltage.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location11 = new System.Drawing.Point(73, 271);
			this.label_JYVoltage.Location = location11;
			Padding margin8 = new Padding(10);
			this.label_JYVoltage.Margin = margin8;
			this.label_JYVoltage.Name = "label_JYVoltage";
			System.Drawing.Size size11 = new System.Drawing.Size(145, 19);
			this.label_JYVoltage.Size = size11;
			this.label_JYVoltage.TabIndex = 29;
			this.label_JYVoltage.Text = "绝缘电压(VDC):";
			this.label_NYThreshold.AutoSize = true;
			this.label_NYThreshold.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location12 = new System.Drawing.Point(83, 310);
			this.label_NYThreshold.Location = location12;
			Padding margin9 = new Padding(10);
			this.label_NYThreshold.Margin = margin9;
			this.label_NYThreshold.Name = "label_NYThreshold";
			System.Drawing.Size size12 = new System.Drawing.Size(135, 19);
			this.label_NYThreshold.Size = size12;
			this.label_NYThreshold.TabIndex = 27;
			this.label_NYThreshold.Text = "耐压阈值(mA):";
			this.label_NYTestTime.AutoSize = true;
			this.label_NYTestTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location13 = new System.Drawing.Point(55, 349);
			this.label_NYTestTime.Location = location13;
			Padding margin10 = new Padding(10);
			this.label_NYTestTime.Margin = margin10;
			this.label_NYTestTime.Name = "label_NYTestTime";
			System.Drawing.Size size13 = new System.Drawing.Size(163, 19);
			this.label_NYTestTime.Size = size13;
			this.label_NYTestTime.TabIndex = 30;
			this.label_NYTestTime.Text = "耐压保持时间(s):";
			this.label_NYVoltage.AutoSize = true;
			this.label_NYVoltage.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location14 = new System.Drawing.Point(73, 388);
			this.label_NYVoltage.Location = location14;
			Padding margin11 = new Padding(10);
			this.label_NYVoltage.Margin = margin11;
			this.label_NYVoltage.Name = "label_NYVoltage";
			System.Drawing.Size size14 = new System.Drawing.Size(145, 19);
			this.label_NYVoltage.Size = size14;
			this.label_NYVoltage.TabIndex = 31;
			this.label_NYVoltage.Text = "耐压电压(VAC):";
			this.flowLayoutPanel2.Anchor = AnchorStyles.Top;
			this.flowLayoutPanel2.Controls.Add(this.label_PlugName1);
			this.flowLayoutPanel2.Controls.Add(this.label_PinName1);
			this.flowLayoutPanel2.Controls.Add(this.label_PlugName2);
			this.flowLayoutPanel2.Controls.Add(this.label_PinName2);
			this.flowLayoutPanel2.Controls.Add(this.numericUpDown_DTThreshold);
			this.flowLayoutPanel2.Controls.Add(this.numericUpDown_JYThreshold);
			this.flowLayoutPanel2.Controls.Add(this.numericUpDown_JYTestTime);
			this.flowLayoutPanel2.Controls.Add(this.numericUpDown_JYVoltage);
			this.flowLayoutPanel2.Controls.Add(this.numericUpDown_NYThreshold);
			this.flowLayoutPanel2.Controls.Add(this.numericUpDown_NYTestTime);
			this.flowLayoutPanel2.Controls.Add(this.numericUpDown_NYVoltage);
			this.flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
			System.Drawing.Point location15 = new System.Drawing.Point(264, 22);
			this.flowLayoutPanel2.Location = location15;
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			System.Drawing.Size size15 = new System.Drawing.Size(350, 450);
			this.flowLayoutPanel2.Size = size15;
			this.flowLayoutPanel2.TabIndex = 23;
			this.label_PlugName1.AutoSize = true;
			this.label_PlugName1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location16 = new System.Drawing.Point(6, 10);
			this.label_PlugName1.Location = location16;
			Padding margin12 = new Padding(6, 10, 10, 6);
			this.label_PlugName1.Margin = margin12;
			this.label_PlugName1.Name = "label_PlugName1";
			System.Drawing.Size size16 = new System.Drawing.Size(85, 19);
			this.label_PlugName1.Size = size16;
			this.label_PlugName1.TabIndex = 37;
			this.label_PlugName1.Text = "起点接口";
			this.label_PinName1.AutoSize = true;
			this.label_PinName1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location17 = new System.Drawing.Point(6, 45);
			this.label_PinName1.Location = location17;
			Padding margin13 = new Padding(6, 10, 10, 6);
			this.label_PinName1.Margin = margin13;
			this.label_PinName1.Name = "label_PinName1";
			System.Drawing.Size size17 = new System.Drawing.Size(85, 19);
			this.label_PinName1.Size = size17;
			this.label_PinName1.TabIndex = 36;
			this.label_PinName1.Text = "起点接点";
			this.label_PlugName2.AutoSize = true;
			this.label_PlugName2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location18 = new System.Drawing.Point(6, 80);
			this.label_PlugName2.Location = location18;
			Padding margin14 = new Padding(6, 10, 10, 6);
			this.label_PlugName2.Margin = margin14;
			this.label_PlugName2.Name = "label_PlugName2";
			System.Drawing.Size size18 = new System.Drawing.Size(85, 19);
			this.label_PlugName2.Size = size18;
			this.label_PlugName2.TabIndex = 38;
			this.label_PlugName2.Text = "终点接口";
			this.label_PinName2.AutoSize = true;
			this.label_PinName2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location19 = new System.Drawing.Point(6, 115);
			this.label_PinName2.Location = location19;
			Padding margin15 = new Padding(6, 10, 10, 10);
			this.label_PinName2.Margin = margin15;
			this.label_PinName2.Name = "label_PinName2";
			System.Drawing.Size size19 = new System.Drawing.Size(85, 19);
			this.label_PinName2.Size = size19;
			this.label_PinName2.TabIndex = 39;
			this.label_PinName2.Text = "终点接点";
			this.numericUpDown_DTThreshold.DecimalPlaces = 3;
			this.numericUpDown_DTThreshold.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location20 = new System.Drawing.Point(6, 150);
			this.numericUpDown_DTThreshold.Location = location20;
			Padding margin16 = new Padding(6, 6, 6, 5);
			this.numericUpDown_DTThreshold.Margin = margin16;
			decimal maximum = new decimal(new int[]
			{
				1000000000,
				0,
				0,
				0
			});
			this.numericUpDown_DTThreshold.Maximum = maximum;
			this.numericUpDown_DTThreshold.Name = "numericUpDown_DTThreshold";
			System.Drawing.Size size20 = new System.Drawing.Size(300, 28);
			this.numericUpDown_DTThreshold.Size = size20;
			this.numericUpDown_DTThreshold.TabIndex = 29;
			decimal value = new decimal(new int[]
			{
				5,
				0,
				0,
				0
			});
			this.numericUpDown_DTThreshold.Value = value;
			this.numericUpDown_DTThreshold.KeyUp += new KeyEventHandler(this.numericUpDown_DTThreshold_KeyUp);
			this.numericUpDown_JYThreshold.DecimalPlaces = 2;
			this.numericUpDown_JYThreshold.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location21 = new System.Drawing.Point(6, 189);
			this.numericUpDown_JYThreshold.Location = location21;
			Padding margin17 = new Padding(6, 6, 6, 5);
			this.numericUpDown_JYThreshold.Margin = margin17;
			decimal maximum2 = new decimal(new int[]
			{
				1000000000,
				0,
				0,
				0
			});
			this.numericUpDown_JYThreshold.Maximum = maximum2;
			this.numericUpDown_JYThreshold.Name = "numericUpDown_JYThreshold";
			System.Drawing.Size size21 = new System.Drawing.Size(300, 28);
			this.numericUpDown_JYThreshold.Size = size21;
			this.numericUpDown_JYThreshold.TabIndex = 28;
			decimal value2 = new decimal(new int[]
			{
				20,
				0,
				0,
				0
			});
			this.numericUpDown_JYThreshold.Value = value2;
			this.numericUpDown_JYThreshold.KeyUp += new KeyEventHandler(this.numericUpDown_JYThreshold_KeyUp);
			this.numericUpDown_JYTestTime.DecimalPlaces = 1;
			this.numericUpDown_JYTestTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location22 = new System.Drawing.Point(6, 228);
			this.numericUpDown_JYTestTime.Location = location22;
			Padding margin18 = new Padding(6, 6, 6, 5);
			this.numericUpDown_JYTestTime.Margin = margin18;
			decimal maximum3 = new decimal(new int[]
			{
				120,
				0,
				0,
				0
			});
			this.numericUpDown_JYTestTime.Maximum = maximum3;
			this.numericUpDown_JYTestTime.Name = "numericUpDown_JYTestTime";
			System.Drawing.Size size22 = new System.Drawing.Size(300, 28);
			this.numericUpDown_JYTestTime.Size = size22;
			this.numericUpDown_JYTestTime.TabIndex = 30;
			decimal value3 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_JYTestTime.Value = value3;
			this.numericUpDown_JYTestTime.KeyUp += new KeyEventHandler(this.numericUpDown_JYTestTime_KeyUp);
			this.numericUpDown_JYVoltage.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location23 = new System.Drawing.Point(6, 267);
			this.numericUpDown_JYVoltage.Location = location23;
			Padding margin19 = new Padding(6, 6, 6, 5);
			this.numericUpDown_JYVoltage.Margin = margin19;
			decimal maximum4 = new decimal(new int[]
			{
				10000,
				0,
				0,
				0
			});
			this.numericUpDown_JYVoltage.Maximum = maximum4;
			this.numericUpDown_JYVoltage.Name = "numericUpDown_JYVoltage";
			System.Drawing.Size size23 = new System.Drawing.Size(300, 28);
			this.numericUpDown_JYVoltage.Size = size23;
			this.numericUpDown_JYVoltage.TabIndex = 32;
			decimal value4 = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			this.numericUpDown_JYVoltage.Value = value4;
			this.numericUpDown_JYVoltage.KeyUp += new KeyEventHandler(this.numericUpDown_JYVoltage_KeyUp);
			this.numericUpDown_NYThreshold.DecimalPlaces = 2;
			this.numericUpDown_NYThreshold.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location24 = new System.Drawing.Point(6, 306);
			this.numericUpDown_NYThreshold.Location = location24;
			Padding margin20 = new Padding(6, 6, 6, 5);
			this.numericUpDown_NYThreshold.Margin = margin20;
			decimal maximum5 = new decimal(new int[]
			{
				10000,
				0,
				0,
				0
			});
			this.numericUpDown_NYThreshold.Maximum = maximum5;
			this.numericUpDown_NYThreshold.Name = "numericUpDown_NYThreshold";
			System.Drawing.Size size24 = new System.Drawing.Size(300, 28);
			this.numericUpDown_NYThreshold.Size = size24;
			this.numericUpDown_NYThreshold.TabIndex = 31;
			decimal value5 = new decimal(new int[]
			{
				2,
				0,
				0,
				0
			});
			this.numericUpDown_NYThreshold.Value = value5;
			this.numericUpDown_NYThreshold.KeyUp += new KeyEventHandler(this.numericUpDown_NYThreshold_KeyUp);
			this.numericUpDown_NYTestTime.DecimalPlaces = 1;
			this.numericUpDown_NYTestTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location25 = new System.Drawing.Point(6, 345);
			this.numericUpDown_NYTestTime.Location = location25;
			Padding margin21 = new Padding(6, 6, 6, 5);
			this.numericUpDown_NYTestTime.Margin = margin21;
			decimal maximum6 = new decimal(new int[]
			{
				120,
				0,
				0,
				0
			});
			this.numericUpDown_NYTestTime.Maximum = maximum6;
			this.numericUpDown_NYTestTime.Name = "numericUpDown_NYTestTime";
			System.Drawing.Size size25 = new System.Drawing.Size(300, 28);
			this.numericUpDown_NYTestTime.Size = size25;
			this.numericUpDown_NYTestTime.TabIndex = 30;
			decimal value6 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_NYTestTime.Value = value6;
			this.numericUpDown_NYTestTime.KeyUp += new KeyEventHandler(this.numericUpDown_NYTestTime_KeyUp);
			this.numericUpDown_NYVoltage.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location26 = new System.Drawing.Point(6, 384);
			this.numericUpDown_NYVoltage.Location = location26;
			Padding margin22 = new Padding(6, 6, 6, 5);
			this.numericUpDown_NYVoltage.Margin = margin22;
			decimal maximum7 = new decimal(new int[]
			{
				10000,
				0,
				0,
				0
			});
			this.numericUpDown_NYVoltage.Maximum = maximum7;
			this.numericUpDown_NYVoltage.Name = "numericUpDown_NYVoltage";
			System.Drawing.Size size26 = new System.Drawing.Size(300, 28);
			this.numericUpDown_NYVoltage.Size = size26;
			this.numericUpDown_NYVoltage.TabIndex = 32;
			decimal value7 = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			this.numericUpDown_NYVoltage.Value = value7;
			this.numericUpDown_NYVoltage.KeyUp += new KeyEventHandler(this.numericUpDown_NYVoltage_KeyUp);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(654, 565);
			base.ClientSize = clientSize;
			base.Controls.Add(this.flowLayoutPanel2);
			base.Controls.Add(this.flowLayoutPanel1);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnSubmit);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormEditGroupTestPara";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "编辑分组测试参数";
			base.Load += new System.EventHandler(this.ctFormEditGroupTestPara_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			((ISupportInitialize)this.numericUpDown_DTThreshold).EndInit();
			((ISupportInitialize)this.numericUpDown_JYThreshold).EndInit();
			((ISupportInitialize)this.numericUpDown_JYTestTime).EndInit();
			((ISupportInitialize)this.numericUpDown_JYVoltage).EndInit();
			((ISupportInitialize)this.numericUpDown_NYThreshold).EndInit();
			((ISupportInitialize)this.numericUpDown_NYTestTime).EndInit();
			((ISupportInitialize)this.numericUpDown_NYVoltage).EndInit();
			base.ResumeLayout(false);
		}
		public void SetControlVisibleFunc()
		{
			try
			{
				this.label_DTThreshold.Visible = this.gLineTestProcessor.bDTTestEnabled;
				this.numericUpDown_DTThreshold.Visible = this.gLineTestProcessor.bDTTestEnabled;
				KLineTestProcessor this2 = this.gLineTestProcessor;
				if (!this2.bJYTestEnabled && !this2.bDDJYTestEnabled)
				{
					this.label_JYThreshold.Visible = false;
					this.label_JYTestTime.Visible = false;
					this.label_JYVoltage.Visible = false;
					this.numericUpDown_JYThreshold.Visible = false;
					this.numericUpDown_JYTestTime.Visible = false;
					this.numericUpDown_JYVoltage.Visible = false;
				}
				else
				{
					this.label_JYThreshold.Visible = true;
					this.label_JYTestTime.Visible = true;
					this.label_JYVoltage.Visible = true;
					this.numericUpDown_JYThreshold.Visible = true;
					this.numericUpDown_JYTestTime.Visible = true;
					this.numericUpDown_JYVoltage.Visible = true;
				}
				this.label_NYThreshold.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.label_NYTestTime.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.label_NYVoltage.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.numericUpDown_NYTestTime.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.numericUpDown_NYVoltage.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.numericUpDown_NYThreshold.Visible = this.gLineTestProcessor.bNYTestEnabled;
			}
			catch (System.Exception arg_15B_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_15B_0.StackTrace);
			}
		}
		public void SetControlMaxMinValueFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				bool bFExsitFlag = false;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select * from TTestParaRangeTable", connection).ExecuteReader();
					if (dataReader.Read())
					{
						bFExsitFlag = true;
						this.d_DT_Threshold_Min = System.Convert.ToDouble(dataReader["d_DT_Threshold_Min"].ToString());
						this.d_DT_Threshold_Max = System.Convert.ToDouble(dataReader["d_DT_Threshold_Max"].ToString());
						this.d_JY_Threshold_Min = System.Convert.ToDouble(dataReader["d_JY_Threshold_Min"].ToString());
						this.d_JY_Threshold_Max = System.Convert.ToDouble(dataReader["d_JY_Threshold_Max"].ToString());
						this.d_JY_HoldTime_Min = System.Convert.ToDouble(dataReader["d_JY_HoldTime_Min"].ToString());
						this.d_JY_HoldTime_Max = System.Convert.ToDouble(dataReader["d_JY_HoldTime_Max"].ToString());
						this.d_JY_DCVolt_Min = System.Convert.ToDouble(dataReader["d_JY_DCVolt_Min"].ToString());
						this.d_JY_DCVolt_Max = System.Convert.ToDouble(dataReader["d_JY_DCVolt_Max"].ToString());
						this.d_NY_Threshold_Min = System.Convert.ToDouble(dataReader["d_NY_Threshold_Min"].ToString());
						this.d_NY_Threshold_Max = System.Convert.ToDouble(dataReader["d_NY_Threshold_Max"].ToString());
						this.d_NY_HoldTime_Min = System.Convert.ToDouble(dataReader["d_NY_HoldTime_Min"].ToString());
						this.d_NY_HoldTime_Max = System.Convert.ToDouble(dataReader["d_NY_HoldTime_Max"].ToString());
						this.d_NY_ACVolt_Min = System.Convert.ToDouble(dataReader["d_NY_ACVolt_Min"].ToString());
						this.d_NY_ACVolt_Max = System.Convert.ToDouble(dataReader["d_NY_ACVolt_Max"].ToString());
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_1CD_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_1CD_0.StackTrace);
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
				if (bFExsitFlag)
				{
					decimal minimum = System.Convert.ToDecimal(this.d_DT_Threshold_Min);
					this.numericUpDown_DTThreshold.Minimum = minimum;
					decimal maximum = System.Convert.ToDecimal(this.d_DT_Threshold_Max);
					this.numericUpDown_DTThreshold.Maximum = maximum;
					decimal minimum2 = System.Convert.ToDecimal(this.d_JY_Threshold_Min);
					this.numericUpDown_JYThreshold.Minimum = minimum2;
					decimal maximum2 = System.Convert.ToDecimal(this.d_JY_Threshold_Max);
					this.numericUpDown_JYThreshold.Maximum = maximum2;
					decimal minimum3 = System.Convert.ToDecimal(this.d_JY_HoldTime_Min);
					this.numericUpDown_JYTestTime.Minimum = minimum3;
					decimal maximum3 = System.Convert.ToDecimal(this.d_JY_HoldTime_Max);
					this.numericUpDown_JYTestTime.Maximum = maximum3;
					decimal minimum4 = System.Convert.ToDecimal(this.d_JY_DCVolt_Min);
					this.numericUpDown_JYVoltage.Minimum = minimum4;
					decimal maximum4 = System.Convert.ToDecimal(this.d_JY_DCVolt_Max);
					this.numericUpDown_JYVoltage.Maximum = maximum4;
					decimal minimum5 = System.Convert.ToDecimal(this.d_NY_Threshold_Min);
					this.numericUpDown_NYThreshold.Minimum = minimum5;
					decimal maximum5 = System.Convert.ToDecimal(this.d_NY_Threshold_Max);
					this.numericUpDown_NYThreshold.Maximum = maximum5;
					decimal minimum6 = System.Convert.ToDecimal(this.d_NY_HoldTime_Min);
					this.numericUpDown_NYTestTime.Minimum = minimum6;
					decimal maximum6 = System.Convert.ToDecimal(this.d_NY_HoldTime_Max);
					this.numericUpDown_NYTestTime.Maximum = maximum6;
					decimal minimum7 = System.Convert.ToDecimal(this.d_NY_ACVolt_Min);
					this.numericUpDown_NYVoltage.Minimum = minimum7;
					decimal maximum7 = System.Convert.ToDecimal(this.d_NY_ACVolt_Max);
					this.numericUpDown_NYVoltage.Maximum = maximum7;
				}
			}
			catch (System.Exception arg_361_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_361_0.StackTrace);
			}
		}
		private void ctFormEditGroupTestPara_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.label_PlugName1.Text = this.gtpStruct.PlugName1;
				this.label_PinName1.Text = this.gtpStruct.PinName1;
				this.label_PlugName2.Text = this.gtpStruct.PlugName2;
				this.label_PinName2.Text = this.gtpStruct.PinName2;
			}
			catch (System.Exception arg_5A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5A_0.StackTrace);
			}
			this.SetControlMaxMinValueFunc();
			this.SetControlVisibleFunc();
			try
			{
				double dValue = System.Convert.ToDouble(this.gtpStruct.DTThreshold);
				double dMaxValue = System.Convert.ToDouble(this.numericUpDown_DTThreshold.Maximum);
				double dMinValue = System.Convert.ToDouble(this.numericUpDown_DTThreshold.Minimum);
				if (dValue >= dMinValue && dValue <= dMaxValue)
				{
					decimal value = System.Convert.ToDecimal(dValue);
					this.numericUpDown_DTThreshold.Value = value;
				}
				else if (dValue < dMinValue)
				{
					decimal value2 = System.Convert.ToDecimal(dMinValue);
					this.numericUpDown_DTThreshold.Value = value2;
				}
				else if (dValue > dMaxValue)
				{
					decimal value3 = System.Convert.ToDecimal(dMaxValue);
					this.numericUpDown_DTThreshold.Value = value3;
				}
				dValue = System.Convert.ToDouble(this.gtpStruct.JYThreshold);
				dMaxValue = System.Convert.ToDouble(this.numericUpDown_JYThreshold.Maximum);
				dMinValue = System.Convert.ToDouble(this.numericUpDown_JYThreshold.Minimum);
				if (dValue >= dMinValue && dValue <= dMaxValue)
				{
					decimal value4 = System.Convert.ToDecimal(dValue);
					this.numericUpDown_JYThreshold.Value = value4;
				}
				else if (dValue < dMinValue)
				{
					decimal value5 = System.Convert.ToDecimal(dMinValue);
					this.numericUpDown_JYThreshold.Value = value5;
				}
				else if (dValue > dMaxValue)
				{
					decimal value6 = System.Convert.ToDecimal(dMaxValue);
					this.numericUpDown_JYThreshold.Value = value6;
				}
				dValue = System.Convert.ToDouble(this.gtpStruct.JYTestTime);
				dMaxValue = System.Convert.ToDouble(this.numericUpDown_JYTestTime.Maximum);
				dMinValue = System.Convert.ToDouble(this.numericUpDown_JYTestTime.Minimum);
				if (dValue >= dMinValue && dValue <= dMaxValue)
				{
					decimal value7 = System.Convert.ToDecimal(dValue);
					this.numericUpDown_JYTestTime.Value = value7;
				}
				else if (dValue < dMinValue)
				{
					decimal value8 = System.Convert.ToDecimal(dMinValue);
					this.numericUpDown_JYTestTime.Value = value8;
				}
				else if (dValue > dMaxValue)
				{
					decimal value9 = System.Convert.ToDecimal(dMaxValue);
					this.numericUpDown_JYTestTime.Value = value9;
				}
				dValue = System.Convert.ToDouble(this.gtpStruct.JYVoltage);
				dMaxValue = System.Convert.ToDouble(this.numericUpDown_JYVoltage.Maximum);
				dMinValue = System.Convert.ToDouble(this.numericUpDown_JYVoltage.Minimum);
				if (dValue >= dMinValue && dValue <= dMaxValue)
				{
					decimal value10 = System.Convert.ToDecimal(dValue);
					this.numericUpDown_JYVoltage.Value = value10;
				}
				else if (dValue < dMinValue)
				{
					decimal value11 = System.Convert.ToDecimal(dMinValue);
					this.numericUpDown_JYVoltage.Value = value11;
				}
				else if (dValue > dMaxValue)
				{
					decimal value12 = System.Convert.ToDecimal(dMaxValue);
					this.numericUpDown_JYVoltage.Value = value12;
				}
				dValue = System.Convert.ToDouble(this.gtpStruct.NYThreshold);
				dMaxValue = System.Convert.ToDouble(this.numericUpDown_NYThreshold.Maximum);
				dMinValue = System.Convert.ToDouble(this.numericUpDown_NYThreshold.Minimum);
				if (dValue >= dMinValue && dValue <= dMaxValue)
				{
					decimal value13 = System.Convert.ToDecimal(dValue);
					this.numericUpDown_NYThreshold.Value = value13;
				}
				else if (dValue < dMinValue)
				{
					decimal value14 = System.Convert.ToDecimal(dMinValue);
					this.numericUpDown_NYThreshold.Value = value14;
				}
				else if (dValue > dMaxValue)
				{
					decimal value15 = System.Convert.ToDecimal(dMaxValue);
					this.numericUpDown_NYThreshold.Value = value15;
				}
				dValue = System.Convert.ToDouble(this.gtpStruct.NYTestTime);
				dMaxValue = System.Convert.ToDouble(this.numericUpDown_NYTestTime.Maximum);
				dMinValue = System.Convert.ToDouble(this.numericUpDown_NYTestTime.Minimum);
				if (dValue >= dMinValue && dValue <= dMaxValue)
				{
					decimal value16 = System.Convert.ToDecimal(dValue);
					this.numericUpDown_NYTestTime.Value = value16;
				}
				else if (dValue < dMinValue)
				{
					decimal value17 = System.Convert.ToDecimal(dMinValue);
					this.numericUpDown_NYTestTime.Value = value17;
				}
				else if (dValue > dMaxValue)
				{
					decimal value18 = System.Convert.ToDecimal(dMaxValue);
					this.numericUpDown_NYTestTime.Value = value18;
				}
				dValue = System.Convert.ToDouble(this.gtpStruct.NYVoltage);
				dMaxValue = System.Convert.ToDouble(this.numericUpDown_NYVoltage.Maximum);
				dMinValue = System.Convert.ToDouble(this.numericUpDown_NYVoltage.Minimum);
				if (dValue >= dMinValue && dValue <= dMaxValue)
				{
					decimal value19 = System.Convert.ToDecimal(dValue);
					this.numericUpDown_NYVoltage.Value = value19;
				}
				else if (dValue < dMinValue)
				{
					decimal value20 = System.Convert.ToDecimal(dMinValue);
					this.numericUpDown_NYVoltage.Value = value20;
				}
				else if (dValue > dMaxValue)
				{
					decimal value21 = System.Convert.ToDecimal(dMaxValue);
					this.numericUpDown_NYVoltage.Value = value21;
				}
			}
			catch (System.Exception arg_43A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_43A_0.StackTrace);
			}
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			this.bSubmitSuccFlag = false;
			base.Close();
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			try
			{
				string tempStr = System.Convert.ToString(this.numericUpDown_DTThreshold.Value);
				int iTemp = tempStr.LastIndexOf('.');
				if (iTemp == -1)
				{
					tempStr += ".";
					for (int i = 0; i < KLineTestProcessor.INT_DTTHRESHOLD_JD; i++)
					{
						tempStr += "0";
					}
				}
				else
				{
					while (iTemp + KLineTestProcessor.INT_DTTHRESHOLD_JD + 1 > tempStr.Length)
					{
						tempStr += "0";
						iTemp = tempStr.LastIndexOf('.');
					}
				}
				this.beDTThresholdStr = tempStr;
				tempStr = System.Convert.ToString(this.numericUpDown_JYThreshold.Value);
				iTemp = tempStr.LastIndexOf('.');
				if (iTemp == -1)
				{
					tempStr += ".";
					for (int j = 0; j < KLineTestProcessor.INT_JYTHRESHOLD_JD; j++)
					{
						tempStr += "0";
					}
				}
				else
				{
					while (iTemp + KLineTestProcessor.INT_JYTHRESHOLD_JD + 1 > tempStr.Length)
					{
						tempStr += "0";
						iTemp = tempStr.LastIndexOf('.');
					}
				}
				this.beJYThresholdStr = tempStr;
				tempStr = System.Convert.ToString(this.numericUpDown_JYTestTime.Value);
				iTemp = tempStr.LastIndexOf('.');
				if (iTemp == -1)
				{
					tempStr += ".";
					for (int k = 0; k < KLineTestProcessor.INT_JYTESTTIME_JD; k++)
					{
						tempStr += "0";
					}
				}
				else
				{
					while (iTemp + KLineTestProcessor.INT_JYTESTTIME_JD + 1 > tempStr.Length)
					{
						tempStr += "0";
						iTemp = tempStr.LastIndexOf('.');
					}
				}
				this.beJYTestTimeStr = tempStr;
				tempStr = System.Convert.ToString(this.numericUpDown_JYVoltage.Value);
				iTemp = tempStr.LastIndexOf('.');
				if (iTemp == -1)
				{
					tempStr += ".";
					for (int l = 0; l < KLineTestProcessor.INT_JYVOLTAGE_JD; l++)
					{
						tempStr += "0";
					}
				}
				else
				{
					while (iTemp + KLineTestProcessor.INT_JYVOLTAGE_JD + 1 > tempStr.Length)
					{
						tempStr += "0";
						iTemp = tempStr.LastIndexOf('.');
					}
				}
				this.beJYVoltageStr = tempStr;
				tempStr = System.Convert.ToString(this.numericUpDown_NYThreshold.Value);
				iTemp = tempStr.LastIndexOf('.');
				if (iTemp == -1)
				{
					tempStr += ".";
					for (int m = 0; m < KLineTestProcessor.INT_NYTHRESHOLD_JD; m++)
					{
						tempStr += "0";
					}
				}
				else
				{
					while (iTemp + KLineTestProcessor.INT_NYTHRESHOLD_JD + 1 > tempStr.Length)
					{
						tempStr += "0";
						iTemp = tempStr.LastIndexOf('.');
					}
				}
				this.beNYThresholdStr = tempStr;
				tempStr = System.Convert.ToString(this.numericUpDown_NYTestTime.Value);
				iTemp = tempStr.LastIndexOf('.');
				if (iTemp == -1)
				{
					tempStr += ".";
					for (int n = 0; n < KLineTestProcessor.INT_NYTESTTIME_JD; n++)
					{
						tempStr += "0";
					}
				}
				else
				{
					while (iTemp + KLineTestProcessor.INT_NYTESTTIME_JD + 1 > tempStr.Length)
					{
						tempStr += "0";
						iTemp = tempStr.LastIndexOf('.');
					}
				}
				this.beNYTestTimeStr = tempStr;
				tempStr = System.Convert.ToString(this.numericUpDown_NYVoltage.Value);
				iTemp = tempStr.LastIndexOf('.');
				if (iTemp == -1)
				{
					tempStr += ".";
					for (int i2 = 0; i2 < KLineTestProcessor.INT_NYVOLTAGE_JD; i2++)
					{
						tempStr += "0";
					}
				}
				else
				{
					while (iTemp + KLineTestProcessor.INT_NYVOLTAGE_JD + 1 > tempStr.Length)
					{
						tempStr += "0";
						iTemp = tempStr.LastIndexOf('.');
					}
				}
				this.beNYVoltageStr = tempStr;
				this.bSubmitSuccFlag = true;
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
				this.bSubmitSuccFlag = false;
			}
			base.Close();
		}
		private void numericUpDown_DTThreshold_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_DTThreshold.Text.ToString().Trim();
				double dMaxValue = System.Convert.ToDouble(this.numericUpDown_DTThreshold.Maximum);
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dCurrValue = System.Convert.ToDouble(tempStr);
					if (dCurrValue > dMaxValue)
					{
						MessageBox.Show("输入值已超出允许最大值" + System.Convert.ToString(dMaxValue) + "，请重新输入!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_64_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_64_0.StackTrace);
			}
		}
		private void numericUpDown_JYThreshold_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_JYThreshold.Text.ToString().Trim();
				double dMaxValue = System.Convert.ToDouble(this.numericUpDown_JYThreshold.Maximum);
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dCurrValue = System.Convert.ToDouble(tempStr);
					if (dCurrValue > dMaxValue)
					{
						MessageBox.Show("输入值已超出允许最大值" + System.Convert.ToString(dMaxValue) + "，请重新输入!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_64_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_64_0.StackTrace);
			}
		}
		private void numericUpDown_JYTestTime_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_JYTestTime.Text.ToString().Trim();
				double dMaxValue = System.Convert.ToDouble(this.numericUpDown_JYTestTime.Maximum);
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dCurrValue = System.Convert.ToDouble(tempStr);
					if (dCurrValue > dMaxValue)
					{
						MessageBox.Show("输入值已超出允许最大值" + System.Convert.ToString(dMaxValue) + "，请重新输入!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_64_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_64_0.StackTrace);
			}
		}
		private void numericUpDown_JYVoltage_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_JYVoltage.Text.ToString().Trim();
				double dMaxValue = System.Convert.ToDouble(this.numericUpDown_JYVoltage.Maximum);
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dCurrValue = System.Convert.ToDouble(tempStr);
					if (dCurrValue > dMaxValue)
					{
						MessageBox.Show("输入值已超出允许最大值" + System.Convert.ToString(dMaxValue) + "，请重新输入!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_64_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_64_0.StackTrace);
			}
		}
		private void numericUpDown_NYThreshold_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_NYThreshold.Text.ToString().Trim();
				double dMaxValue = System.Convert.ToDouble(this.numericUpDown_NYThreshold.Maximum);
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dCurrValue = System.Convert.ToDouble(tempStr);
					if (dCurrValue > dMaxValue)
					{
						MessageBox.Show("输入值已超出允许最大值" + System.Convert.ToString(dMaxValue) + "，请重新输入!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_64_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_64_0.StackTrace);
			}
		}
		private void numericUpDown_NYTestTime_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_NYTestTime.Text.ToString().Trim();
				double dMaxValue = System.Convert.ToDouble(this.numericUpDown_NYTestTime.Maximum);
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dCurrValue = System.Convert.ToDouble(tempStr);
					if (dCurrValue > dMaxValue)
					{
						MessageBox.Show("输入值已超出允许最大值" + System.Convert.ToString(dMaxValue) + "，请重新输入!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_64_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_64_0.StackTrace);
			}
		}
		private void numericUpDown_NYVoltage_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_NYVoltage.Text.ToString().Trim();
				double dMaxValue = System.Convert.ToDouble(this.numericUpDown_NYVoltage.Maximum);
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dCurrValue = System.Convert.ToDouble(tempStr);
					if (dCurrValue > dMaxValue)
					{
						MessageBox.Show("输入值已超出允许最大值" + System.Convert.ToString(dMaxValue) + "，请重新输入!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_64_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_64_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormEditGroupTestPara();
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
