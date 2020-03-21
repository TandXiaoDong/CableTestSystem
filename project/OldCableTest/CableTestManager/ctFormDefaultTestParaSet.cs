using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormDefaultTestParaSet : Form
	{
		public KLineTestProcessor gLineTestProcessor;
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
		public double d_DYJY_Threshold_Min;
		public double d_DYJY_Threshold_Max;
		public double d_DYJY_HoldTime_Min;
		public double d_DYJY_HoldTime_Max;
		public double d_DYJY_DCVolt_Min;
		public double d_DYJY_DCVolt_Max;
		public double d_DYJY_DCRiseTime_Min;
		public double d_DYJY_DCRiseTime_Max;
		public double d_NY_Threshold_Min;
		public double d_NY_Threshold_Max;
		public double d_NY_HoldTime_Min;
		public double d_NY_HoldTime_Max;
		public double d_NY_ACVolt_Min;
		public double d_NY_ACVolt_Max;
		private TabControl tabControl2;
		private TabPage tabPage5;
		private GroupBox groupBox_dtParaSet;
		private NumericUpDown numericUpDown_DT_Current;
		private Label label23;
		private Label label_DT_Current_unit;
		private Label label_DT_Volt_unit;
		private NumericUpDown numericUpDown_DT_Volt;
		private Label label21;
		private Label label_dt_yz;
		private NumericUpDown numericUpDown_DT_Threshold;
		private Label label_DT_Threshold_unit;
		private TabPage tabPage6;
		private GroupBox groupBox_jyParaSet_LowVolt;
		private Label label_DYJY_DCRiseTime_unit;
		private Label label_DYJY_HoldTime_unit;
		private Label label_DYJY_DCVolt_unit;
		private Label label_DYJY_Threshold_unit;
		private NumericUpDown numericUpDown_DYJY_DCRiseTime;
		private NumericUpDown numericUpDown_DYJY_HoldTime;
		private NumericUpDown numericUpDown_DYJY_DCVolt;
		private NumericUpDown numericUpDown_DYJY_Threshold;
		private Label label35;
		private Label label37;
		private Label label40;
		private Label label41;
		private GroupBox groupBox_jyParaSet;
		private Label label_JY_DCRiseTime_unit;
		private Label label_JY_HoldTime_unit;
		private Label label_JY_DCVolt_unit;
		private Label label_JY_Threshold_unit;
		private NumericUpDown numericUpDown_JY_DCRiseTime;
		private NumericUpDown numericUpDown_JY_HoldTime;
		private NumericUpDown numericUpDown_JY_DCVolt;
		private NumericUpDown numericUpDown_JY_Threshold;
		private Label label_jy_zlssTime;
		private Label label_jy_jybcTime;
		private Label label_jy_zlgy;
		private Label label_jy_yz;
		private TabPage tabPage7;
		private GroupBox groupBox_nyParaSet;
		private NumericUpDown numericUpDown_NY_Threshold;
		private NumericUpDown numericUpDown_NY_ACVolt;
		private NumericUpDown numericUpDown_NY_HoldTime;
		private Label label_ny_jlgy;
		private Label label_ny_nybcTime;
		private Label label_ny_yz;
		private Label label_NY_HoldTime_unit;
		private Label label_NY_ACVolt_unit;
		private Label label_NY_Threshold_unit;
		private TabControl tabControl1;
		private TabPage tabPage2;
		private Button btnQuit;
		private Button btnSubmit;
		private Container components;
		public ctFormDefaultTestParaSet(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
				}
				catch (System.Exception ex_2A)
				{
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormDefaultTestParaSet()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormDefaultTestParaSet));
			this.tabControl1 = new TabControl();
			this.tabPage2 = new TabPage();
			this.tabControl2 = new TabControl();
			this.tabPage5 = new TabPage();
			this.groupBox_dtParaSet = new GroupBox();
			this.numericUpDown_DT_Current = new NumericUpDown();
			this.label23 = new Label();
			this.label_DT_Current_unit = new Label();
			this.label_DT_Volt_unit = new Label();
			this.numericUpDown_DT_Volt = new NumericUpDown();
			this.label21 = new Label();
			this.label_dt_yz = new Label();
			this.numericUpDown_DT_Threshold = new NumericUpDown();
			this.label_DT_Threshold_unit = new Label();
			this.tabPage6 = new TabPage();
			this.groupBox_jyParaSet_LowVolt = new GroupBox();
			this.label_DYJY_DCRiseTime_unit = new Label();
			this.label_DYJY_HoldTime_unit = new Label();
			this.label_DYJY_DCVolt_unit = new Label();
			this.label_DYJY_Threshold_unit = new Label();
			this.numericUpDown_DYJY_DCRiseTime = new NumericUpDown();
			this.numericUpDown_DYJY_HoldTime = new NumericUpDown();
			this.numericUpDown_DYJY_DCVolt = new NumericUpDown();
			this.numericUpDown_DYJY_Threshold = new NumericUpDown();
			this.label35 = new Label();
			this.label37 = new Label();
			this.label40 = new Label();
			this.label41 = new Label();
			this.groupBox_jyParaSet = new GroupBox();
			this.label_JY_DCRiseTime_unit = new Label();
			this.label_JY_HoldTime_unit = new Label();
			this.label_JY_DCVolt_unit = new Label();
			this.label_JY_Threshold_unit = new Label();
			this.numericUpDown_JY_DCRiseTime = new NumericUpDown();
			this.numericUpDown_JY_HoldTime = new NumericUpDown();
			this.numericUpDown_JY_DCVolt = new NumericUpDown();
			this.numericUpDown_JY_Threshold = new NumericUpDown();
			this.label_jy_zlssTime = new Label();
			this.label_jy_jybcTime = new Label();
			this.label_jy_zlgy = new Label();
			this.label_jy_yz = new Label();
			this.tabPage7 = new TabPage();
			this.groupBox_nyParaSet = new GroupBox();
			this.numericUpDown_NY_Threshold = new NumericUpDown();
			this.numericUpDown_NY_ACVolt = new NumericUpDown();
			this.numericUpDown_NY_HoldTime = new NumericUpDown();
			this.label_ny_jlgy = new Label();
			this.label_ny_nybcTime = new Label();
			this.label_ny_yz = new Label();
			this.label_NY_HoldTime_unit = new Label();
			this.label_NY_ACVolt_unit = new Label();
			this.label_NY_Threshold_unit = new Label();
			this.btnQuit = new Button();
			this.btnSubmit = new Button();
			this.tabControl1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.groupBox_dtParaSet.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_DT_Current).BeginInit();
			((ISupportInitialize)this.numericUpDown_DT_Volt).BeginInit();
			((ISupportInitialize)this.numericUpDown_DT_Threshold).BeginInit();
			this.tabPage6.SuspendLayout();
			this.groupBox_jyParaSet_LowVolt.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_DYJY_DCRiseTime).BeginInit();
			((ISupportInitialize)this.numericUpDown_DYJY_HoldTime).BeginInit();
			((ISupportInitialize)this.numericUpDown_DYJY_DCVolt).BeginInit();
			((ISupportInitialize)this.numericUpDown_DYJY_Threshold).BeginInit();
			this.groupBox_jyParaSet.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_JY_DCRiseTime).BeginInit();
			((ISupportInitialize)this.numericUpDown_JY_HoldTime).BeginInit();
			((ISupportInitialize)this.numericUpDown_JY_DCVolt).BeginInit();
			((ISupportInitialize)this.numericUpDown_JY_Threshold).BeginInit();
			this.tabPage7.SuspendLayout();
			this.groupBox_nyParaSet.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_NY_Threshold).BeginInit();
			((ISupportInitialize)this.numericUpDown_NY_ACVolt).BeginInit();
			((ISupportInitialize)this.numericUpDown_NY_HoldTime).BeginInit();
			base.SuspendLayout();
			this.tabControl1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.tabControl1.Appearance = TabAppearance.Buttons;
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Size itemSize = new System.Drawing.Size(320, 30);
			this.tabControl1.ItemSize = itemSize;
			System.Drawing.Point location = new System.Drawing.Point(20, 21);
			this.tabControl1.Location = location;
			Padding margin = new Padding(2, 2, 2, 2);
			this.tabControl1.Margin = margin;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			System.Drawing.Size size = new System.Drawing.Size(754, 479);
			this.tabControl1.Size = size;
			this.tabControl1.SizeMode = TabSizeMode.Fixed;
			this.tabControl1.TabIndex = 2;
			System.Drawing.Color activeCaption = System.Drawing.SystemColors.ActiveCaption;
			this.tabPage2.BackColor = activeCaption;
			this.tabPage2.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage2.Controls.Add(this.tabControl2);
			System.Drawing.Point location2 = new System.Drawing.Point(4, 34);
			this.tabPage2.Location = location2;
			Padding margin2 = new Padding(2, 2, 2, 2);
			this.tabPage2.Margin = margin2;
			this.tabPage2.Name = "tabPage2";
			Padding padding = new Padding(2, 2, 2, 2);
			this.tabPage2.Padding = padding;
			this.tabPage2.RightToLeft = RightToLeft.No;
			System.Drawing.Size size2 = new System.Drawing.Size(746, 441);
			this.tabPage2.Size = size2;
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "项目默认试验参数设置";
			this.tabControl2.Appearance = TabAppearance.Buttons;
			this.tabControl2.Controls.Add(this.tabPage5);
			this.tabControl2.Controls.Add(this.tabPage6);
			this.tabControl2.Controls.Add(this.tabPage7);
			this.tabControl2.Dock = DockStyle.Fill;
			System.Drawing.Size itemSize2 = new System.Drawing.Size(180, 30);
			this.tabControl2.ItemSize = itemSize2;
			System.Drawing.Point location3 = new System.Drawing.Point(2, 2);
			this.tabControl2.Location = location3;
			Padding margin3 = new Padding(2, 2, 2, 2);
			this.tabControl2.Margin = margin3;
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			System.Drawing.Size size3 = new System.Drawing.Size(740, 435);
			this.tabControl2.Size = size3;
			this.tabControl2.SizeMode = TabSizeMode.Fixed;
			this.tabControl2.TabIndex = 39;
			System.Drawing.Color activeCaption2 = System.Drawing.SystemColors.ActiveCaption;
			this.tabPage5.BackColor = activeCaption2;
			this.tabPage5.Controls.Add(this.groupBox_dtParaSet);
			System.Drawing.Point location4 = new System.Drawing.Point(4, 34);
			this.tabPage5.Location = location4;
			Padding margin4 = new Padding(2, 2, 2, 2);
			this.tabPage5.Margin = margin4;
			this.tabPage5.Name = "tabPage5";
			Padding padding2 = new Padding(2, 2, 2, 2);
			this.tabPage5.Padding = padding2;
			System.Drawing.Size size4 = new System.Drawing.Size(732, 397);
			this.tabPage5.Size = size4;
			this.tabPage5.TabIndex = 0;
			this.tabPage5.Text = "导通参数设置";
			this.groupBox_dtParaSet.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_dtParaSet.Controls.Add(this.numericUpDown_DT_Current);
			this.groupBox_dtParaSet.Controls.Add(this.label23);
			this.groupBox_dtParaSet.Controls.Add(this.label_DT_Current_unit);
			this.groupBox_dtParaSet.Controls.Add(this.label_DT_Volt_unit);
			this.groupBox_dtParaSet.Controls.Add(this.numericUpDown_DT_Volt);
			this.groupBox_dtParaSet.Controls.Add(this.label21);
			this.groupBox_dtParaSet.Controls.Add(this.label_dt_yz);
			this.groupBox_dtParaSet.Controls.Add(this.numericUpDown_DT_Threshold);
			this.groupBox_dtParaSet.Controls.Add(this.label_DT_Threshold_unit);
			System.Drawing.Point location5 = new System.Drawing.Point(29, 22);
			this.groupBox_dtParaSet.Location = location5;
			Padding margin5 = new Padding(2, 2, 2, 2);
			this.groupBox_dtParaSet.Margin = margin5;
			this.groupBox_dtParaSet.Name = "groupBox_dtParaSet";
			Padding padding3 = new Padding(2, 2, 2, 2);
			this.groupBox_dtParaSet.Padding = padding3;
			System.Drawing.Size size5 = new System.Drawing.Size(675, 362);
			this.groupBox_dtParaSet.Size = size5;
			this.groupBox_dtParaSet.TabIndex = 36;
			this.groupBox_dtParaSet.TabStop = false;
			this.groupBox_dtParaSet.Text = "导通默认参数设置";
			this.numericUpDown_DT_Current.Anchor = AnchorStyles.Left;
			this.numericUpDown_DT_Current.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(137, 215);
			this.numericUpDown_DT_Current.Location = location6;
			Padding margin6 = new Padding(2, 2, 2, 2);
			this.numericUpDown_DT_Current.Margin = margin6;
			decimal maximum = new decimal(new int[]
			{
				1000000,
				0,
				0,
				0
			});
			this.numericUpDown_DT_Current.Maximum = maximum;
			decimal minimum = new decimal(new int[]
			{
				5,
				0,
				0,
				0
			});
			this.numericUpDown_DT_Current.Minimum = minimum;
			this.numericUpDown_DT_Current.Name = "numericUpDown_DT_Current";
			System.Drawing.Size size6 = new System.Drawing.Size(150, 24);
			this.numericUpDown_DT_Current.Size = size6;
			this.numericUpDown_DT_Current.TabIndex = 47;
			decimal value = new decimal(new int[]
			{
				2000,
				0,
				0,
				0
			});
			this.numericUpDown_DT_Current.Value = value;
			this.numericUpDown_DT_Current.Visible = false;
			this.label23.Anchor = AnchorStyles.Left;
			this.label23.AutoSize = true;
			this.label23.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(52, 219);
			this.label23.Location = location7;
			Padding margin7 = new Padding(2, 0, 2, 0);
			this.label23.Margin = margin7;
			this.label23.Name = "label23";
			System.Drawing.Size size7 = new System.Drawing.Size(75, 15);
			this.label23.Size = size7;
			this.label23.TabIndex = 44;
			this.label23.Text = "导通电流:";
			this.label23.Visible = false;
			this.label_DT_Current_unit.Anchor = AnchorStyles.Left;
			this.label_DT_Current_unit.AutoSize = true;
			this.label_DT_Current_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(298, 219);
			this.label_DT_Current_unit.Location = location8;
			Padding margin8 = new Padding(2, 0, 2, 0);
			this.label_DT_Current_unit.Margin = margin8;
			this.label_DT_Current_unit.Name = "label_DT_Current_unit";
			System.Drawing.Size size8 = new System.Drawing.Size(23, 15);
			this.label_DT_Current_unit.Size = size8;
			this.label_DT_Current_unit.TabIndex = 48;
			this.label_DT_Current_unit.Text = "mA";
			this.label_DT_Current_unit.Visible = false;
			this.label_DT_Volt_unit.Anchor = AnchorStyles.Left;
			this.label_DT_Volt_unit.AutoSize = true;
			this.label_DT_Volt_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(302, 174);
			this.label_DT_Volt_unit.Location = location9;
			Padding margin9 = new Padding(2, 0, 2, 0);
			this.label_DT_Volt_unit.Margin = margin9;
			this.label_DT_Volt_unit.Name = "label_DT_Volt_unit";
			System.Drawing.Size size9 = new System.Drawing.Size(31, 15);
			this.label_DT_Volt_unit.Size = size9;
			this.label_DT_Volt_unit.TabIndex = 43;
			this.label_DT_Volt_unit.Text = "VDC";
			this.label_DT_Volt_unit.Visible = false;
			this.numericUpDown_DT_Volt.Anchor = AnchorStyles.Left;
			this.numericUpDown_DT_Volt.DecimalPlaces = 2;
			this.numericUpDown_DT_Volt.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location10 = new System.Drawing.Point(137, 170);
			this.numericUpDown_DT_Volt.Location = location10;
			Padding margin10 = new Padding(2, 2, 2, 2);
			this.numericUpDown_DT_Volt.Margin = margin10;
			decimal maximum2 = new decimal(new int[]
			{
				10000,
				0,
				0,
				0
			});
			this.numericUpDown_DT_Volt.Maximum = maximum2;
			this.numericUpDown_DT_Volt.Name = "numericUpDown_DT_Volt";
			System.Drawing.Size size10 = new System.Drawing.Size(150, 24);
			this.numericUpDown_DT_Volt.Size = size10;
			this.numericUpDown_DT_Volt.TabIndex = 38;
			decimal value2 = new decimal(new int[]
			{
				25,
				0,
				0,
				65536
			});
			this.numericUpDown_DT_Volt.Value = value2;
			this.numericUpDown_DT_Volt.Visible = false;
			this.label21.Anchor = AnchorStyles.Left;
			this.label21.AutoSize = true;
			this.label21.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location11 = new System.Drawing.Point(52, 174);
			this.label21.Location = location11;
			Padding margin11 = new Padding(2, 0, 2, 0);
			this.label21.Margin = margin11;
			this.label21.Name = "label21";
			System.Drawing.Size size11 = new System.Drawing.Size(75, 15);
			this.label21.Size = size11;
			this.label21.TabIndex = 41;
			this.label21.Text = "导通电压:";
			this.label21.Visible = false;
			this.label_dt_yz.Anchor = AnchorStyles.Left;
			this.label_dt_yz.AutoSize = true;
			this.label_dt_yz.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location12 = new System.Drawing.Point(52, 128);
			this.label_dt_yz.Location = location12;
			Padding margin12 = new Padding(2, 0, 2, 0);
			this.label_dt_yz.Margin = margin12;
			this.label_dt_yz.Name = "label_dt_yz";
			System.Drawing.Size size12 = new System.Drawing.Size(75, 15);
			this.label_dt_yz.Size = size12;
			this.label_dt_yz.TabIndex = 19;
			this.label_dt_yz.Text = "导通阈值:";
			this.numericUpDown_DT_Threshold.Anchor = AnchorStyles.Left;
			this.numericUpDown_DT_Threshold.DecimalPlaces = 3;
			this.numericUpDown_DT_Threshold.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location13 = new System.Drawing.Point(137, 124);
			this.numericUpDown_DT_Threshold.Location = location13;
			Padding margin13 = new Padding(2, 2, 2, 2);
			this.numericUpDown_DT_Threshold.Margin = margin13;
			decimal maximum3 = new decimal(new int[]
			{
				1000000,
				0,
				0,
				0
			});
			this.numericUpDown_DT_Threshold.Maximum = maximum3;
			this.numericUpDown_DT_Threshold.Name = "numericUpDown_DT_Threshold";
			System.Drawing.Size size13 = new System.Drawing.Size(150, 24);
			this.numericUpDown_DT_Threshold.Size = size13;
			this.numericUpDown_DT_Threshold.TabIndex = 7;
			decimal value3 = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.numericUpDown_DT_Threshold.Value = value3;
			this.label_DT_Threshold_unit.Anchor = AnchorStyles.Left;
			this.label_DT_Threshold_unit.AutoSize = true;
			this.label_DT_Threshold_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location14 = new System.Drawing.Point(298, 128);
			this.label_DT_Threshold_unit.Location = location14;
			Padding margin14 = new Padding(2, 0, 2, 0);
			this.label_DT_Threshold_unit.Margin = margin14;
			this.label_DT_Threshold_unit.Name = "label_DT_Threshold_unit";
			System.Drawing.Size size14 = new System.Drawing.Size(22, 15);
			this.label_DT_Threshold_unit.Size = size14;
			this.label_DT_Threshold_unit.TabIndex = 23;
			this.label_DT_Threshold_unit.Text = "Ω";
			System.Drawing.Color activeCaption3 = System.Drawing.SystemColors.ActiveCaption;
			this.tabPage6.BackColor = activeCaption3;
			this.tabPage6.Controls.Add(this.groupBox_jyParaSet_LowVolt);
			this.tabPage6.Controls.Add(this.groupBox_jyParaSet);
			System.Drawing.Point location15 = new System.Drawing.Point(4, 34);
			this.tabPage6.Location = location15;
			Padding margin15 = new Padding(2, 2, 2, 2);
			this.tabPage6.Margin = margin15;
			this.tabPage6.Name = "tabPage6";
			Padding padding4 = new Padding(2, 2, 2, 2);
			this.tabPage6.Padding = padding4;
			System.Drawing.Size size15 = new System.Drawing.Size(732, 397);
			this.tabPage6.Size = size15;
			this.tabPage6.TabIndex = 1;
			this.tabPage6.Text = "绝缘参数设置";
			this.groupBox_jyParaSet_LowVolt.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_jyParaSet_LowVolt.Controls.Add(this.label_DYJY_DCRiseTime_unit);
			this.groupBox_jyParaSet_LowVolt.Controls.Add(this.label_DYJY_HoldTime_unit);
			this.groupBox_jyParaSet_LowVolt.Controls.Add(this.label_DYJY_DCVolt_unit);
			this.groupBox_jyParaSet_LowVolt.Controls.Add(this.label_DYJY_Threshold_unit);
			this.groupBox_jyParaSet_LowVolt.Controls.Add(this.numericUpDown_DYJY_DCRiseTime);
			this.groupBox_jyParaSet_LowVolt.Controls.Add(this.numericUpDown_DYJY_HoldTime);
			this.groupBox_jyParaSet_LowVolt.Controls.Add(this.numericUpDown_DYJY_DCVolt);
			this.groupBox_jyParaSet_LowVolt.Controls.Add(this.numericUpDown_DYJY_Threshold);
			this.groupBox_jyParaSet_LowVolt.Controls.Add(this.label35);
			this.groupBox_jyParaSet_LowVolt.Controls.Add(this.label37);
			this.groupBox_jyParaSet_LowVolt.Controls.Add(this.label40);
			this.groupBox_jyParaSet_LowVolt.Controls.Add(this.label41);
			System.Drawing.Point location16 = new System.Drawing.Point(29, 225);
			this.groupBox_jyParaSet_LowVolt.Location = location16;
			Padding margin16 = new Padding(2, 2, 2, 2);
			this.groupBox_jyParaSet_LowVolt.Margin = margin16;
			this.groupBox_jyParaSet_LowVolt.Name = "groupBox_jyParaSet_LowVolt";
			Padding padding5 = new Padding(2, 2, 2, 2);
			this.groupBox_jyParaSet_LowVolt.Padding = padding5;
			System.Drawing.Size size16 = new System.Drawing.Size(675, 160);
			this.groupBox_jyParaSet_LowVolt.Size = size16;
			this.groupBox_jyParaSet_LowVolt.TabIndex = 37;
			this.groupBox_jyParaSet_LowVolt.TabStop = false;
			this.groupBox_jyParaSet_LowVolt.Text = "低压绝缘默认参数设置";
			this.label_DYJY_DCRiseTime_unit.AutoSize = true;
			this.label_DYJY_DCRiseTime_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location17 = new System.Drawing.Point(634, 38);
			this.label_DYJY_DCRiseTime_unit.Location = location17;
			Padding margin17 = new Padding(2, 0, 2, 0);
			this.label_DYJY_DCRiseTime_unit.Margin = margin17;
			this.label_DYJY_DCRiseTime_unit.Name = "label_DYJY_DCRiseTime_unit";
			System.Drawing.Size size17 = new System.Drawing.Size(15, 15);
			this.label_DYJY_DCRiseTime_unit.Size = size17;
			this.label_DYJY_DCRiseTime_unit.TabIndex = 38;
			this.label_DYJY_DCRiseTime_unit.Text = "S";
			this.label_DYJY_DCRiseTime_unit.Visible = false;
			this.label_DYJY_HoldTime_unit.AutoSize = true;
			this.label_DYJY_HoldTime_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location18 = new System.Drawing.Point(298, 77);
			this.label_DYJY_HoldTime_unit.Location = location18;
			Padding margin18 = new Padding(2, 0, 2, 0);
			this.label_DYJY_HoldTime_unit.Margin = margin18;
			this.label_DYJY_HoldTime_unit.Name = "label_DYJY_HoldTime_unit";
			System.Drawing.Size size18 = new System.Drawing.Size(15, 15);
			this.label_DYJY_HoldTime_unit.Size = size18;
			this.label_DYJY_HoldTime_unit.TabIndex = 39;
			this.label_DYJY_HoldTime_unit.Text = "S";
			this.label_DYJY_DCVolt_unit.AutoSize = true;
			this.label_DYJY_DCVolt_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location19 = new System.Drawing.Point(298, 115);
			this.label_DYJY_DCVolt_unit.Location = location19;
			Padding margin19 = new Padding(2, 0, 2, 0);
			this.label_DYJY_DCVolt_unit.Margin = margin19;
			this.label_DYJY_DCVolt_unit.Name = "label_DYJY_DCVolt_unit";
			System.Drawing.Size size19 = new System.Drawing.Size(31, 15);
			this.label_DYJY_DCVolt_unit.Size = size19;
			this.label_DYJY_DCVolt_unit.TabIndex = 37;
			this.label_DYJY_DCVolt_unit.Text = "VDC";
			this.label_DYJY_Threshold_unit.AutoSize = true;
			this.label_DYJY_Threshold_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location20 = new System.Drawing.Point(298, 38);
			this.label_DYJY_Threshold_unit.Location = location20;
			Padding margin20 = new Padding(2, 0, 2, 0);
			this.label_DYJY_Threshold_unit.Margin = margin20;
			this.label_DYJY_Threshold_unit.Name = "label_DYJY_Threshold_unit";
			System.Drawing.Size size20 = new System.Drawing.Size(30, 15);
			this.label_DYJY_Threshold_unit.Size = size20;
			this.label_DYJY_Threshold_unit.TabIndex = 36;
			this.label_DYJY_Threshold_unit.Text = "MΩ";
			this.numericUpDown_DYJY_DCRiseTime.DecimalPlaces = 1;
			this.numericUpDown_DYJY_DCRiseTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location21 = new System.Drawing.Point(472, 34);
			this.numericUpDown_DYJY_DCRiseTime.Location = location21;
			Padding margin21 = new Padding(2, 2, 2, 2);
			this.numericUpDown_DYJY_DCRiseTime.Margin = margin21;
			decimal maximum4 = new decimal(new int[]
			{
				600,
				0,
				0,
				0
			});
			this.numericUpDown_DYJY_DCRiseTime.Maximum = maximum4;
			this.numericUpDown_DYJY_DCRiseTime.Name = "numericUpDown_DYJY_DCRiseTime";
			System.Drawing.Size size21 = new System.Drawing.Size(150, 24);
			this.numericUpDown_DYJY_DCRiseTime.Size = size21;
			this.numericUpDown_DYJY_DCRiseTime.TabIndex = 33;
			decimal value4 = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.numericUpDown_DYJY_DCRiseTime.Value = value4;
			this.numericUpDown_DYJY_DCRiseTime.Visible = false;
			this.numericUpDown_DYJY_HoldTime.DecimalPlaces = 3;
			this.numericUpDown_DYJY_HoldTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location22 = new System.Drawing.Point(137, 73);
			this.numericUpDown_DYJY_HoldTime.Location = location22;
			Padding margin22 = new Padding(2, 2, 2, 2);
			this.numericUpDown_DYJY_HoldTime.Margin = margin22;
			decimal maximum5 = new decimal(new int[]
			{
				3600,
				0,
				0,
				0
			});
			this.numericUpDown_DYJY_HoldTime.Maximum = maximum5;
			this.numericUpDown_DYJY_HoldTime.Name = "numericUpDown_DYJY_HoldTime";
			System.Drawing.Size size22 = new System.Drawing.Size(150, 24);
			this.numericUpDown_DYJY_HoldTime.Size = size22;
			this.numericUpDown_DYJY_HoldTime.TabIndex = 30;
			decimal value5 = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.numericUpDown_DYJY_HoldTime.Value = value5;
			this.numericUpDown_DYJY_DCVolt.DecimalPlaces = 3;
			this.numericUpDown_DYJY_DCVolt.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			decimal increment = new decimal(new int[]
			{
				5,
				0,
				0,
				131072
			});
			this.numericUpDown_DYJY_DCVolt.Increment = increment;
			System.Drawing.Point location23 = new System.Drawing.Point(137, 111);
			this.numericUpDown_DYJY_DCVolt.Location = location23;
			Padding margin23 = new Padding(2, 2, 2, 2);
			this.numericUpDown_DYJY_DCVolt.Margin = margin23;
			decimal maximum6 = new decimal(new int[]
			{
				1000000,
				0,
				0,
				0
			});
			this.numericUpDown_DYJY_DCVolt.Maximum = maximum6;
			this.numericUpDown_DYJY_DCVolt.Name = "numericUpDown_DYJY_DCVolt";
			System.Drawing.Size size23 = new System.Drawing.Size(150, 24);
			this.numericUpDown_DYJY_DCVolt.Size = size23;
			this.numericUpDown_DYJY_DCVolt.TabIndex = 31;
			decimal value6 = new decimal(new int[]
			{
				30,
				0,
				0,
				0
			});
			this.numericUpDown_DYJY_DCVolt.Value = value6;
			this.numericUpDown_DYJY_Threshold.DecimalPlaces = 2;
			this.numericUpDown_DYJY_Threshold.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location24 = new System.Drawing.Point(137, 34);
			this.numericUpDown_DYJY_Threshold.Location = location24;
			Padding margin24 = new Padding(2, 2, 2, 2);
			this.numericUpDown_DYJY_Threshold.Margin = margin24;
			decimal maximum7 = new decimal(new int[]
			{
				1000000,
				0,
				0,
				0
			});
			this.numericUpDown_DYJY_Threshold.Maximum = maximum7;
			this.numericUpDown_DYJY_Threshold.Name = "numericUpDown_DYJY_Threshold";
			System.Drawing.Size size24 = new System.Drawing.Size(150, 24);
			this.numericUpDown_DYJY_Threshold.Size = size24;
			this.numericUpDown_DYJY_Threshold.TabIndex = 29;
			decimal value7 = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.numericUpDown_DYJY_Threshold.Value = value7;
			this.label35.AutoSize = true;
			this.label35.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location25 = new System.Drawing.Point(359, 38);
			this.label35.Location = location25;
			Padding margin25 = new Padding(2, 0, 2, 0);
			this.label35.Margin = margin25;
			this.label35.Name = "label35";
			System.Drawing.Size size25 = new System.Drawing.Size(105, 15);
			this.label35.Size = size25;
			this.label35.TabIndex = 32;
			this.label35.Text = "绝缘上升时间:";
			this.label35.Visible = false;
			this.label37.AutoSize = true;
			this.label37.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location26 = new System.Drawing.Point(24, 77);
			this.label37.Location = location26;
			Padding margin26 = new Padding(2, 0, 2, 0);
			this.label37.Margin = margin26;
			this.label37.Name = "label37";
			System.Drawing.Size size26 = new System.Drawing.Size(105, 15);
			this.label37.Size = size26;
			this.label37.TabIndex = 28;
			this.label37.Text = "绝缘保持时间:";
			this.label40.AutoSize = true;
			this.label40.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location27 = new System.Drawing.Point(52, 115);
			this.label40.Location = location27;
			Padding margin27 = new Padding(2, 0, 2, 0);
			this.label40.Margin = margin27;
			this.label40.Name = "label40";
			System.Drawing.Size size27 = new System.Drawing.Size(75, 15);
			this.label40.Size = size27;
			this.label40.TabIndex = 34;
			this.label40.Text = "绝缘电压:";
			this.label41.AutoSize = true;
			this.label41.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location28 = new System.Drawing.Point(52, 38);
			this.label41.Location = location28;
			Padding margin28 = new Padding(2, 0, 2, 0);
			this.label41.Margin = margin28;
			this.label41.Name = "label41";
			System.Drawing.Size size28 = new System.Drawing.Size(75, 15);
			this.label41.Size = size28;
			this.label41.TabIndex = 35;
			this.label41.Text = "绝缘阈值:";
			this.groupBox_jyParaSet.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_jyParaSet.Controls.Add(this.label_JY_DCRiseTime_unit);
			this.groupBox_jyParaSet.Controls.Add(this.label_JY_HoldTime_unit);
			this.groupBox_jyParaSet.Controls.Add(this.label_JY_DCVolt_unit);
			this.groupBox_jyParaSet.Controls.Add(this.label_JY_Threshold_unit);
			this.groupBox_jyParaSet.Controls.Add(this.numericUpDown_JY_DCRiseTime);
			this.groupBox_jyParaSet.Controls.Add(this.numericUpDown_JY_HoldTime);
			this.groupBox_jyParaSet.Controls.Add(this.numericUpDown_JY_DCVolt);
			this.groupBox_jyParaSet.Controls.Add(this.numericUpDown_JY_Threshold);
			this.groupBox_jyParaSet.Controls.Add(this.label_jy_zlssTime);
			this.groupBox_jyParaSet.Controls.Add(this.label_jy_jybcTime);
			this.groupBox_jyParaSet.Controls.Add(this.label_jy_zlgy);
			this.groupBox_jyParaSet.Controls.Add(this.label_jy_yz);
			System.Drawing.Point location29 = new System.Drawing.Point(29, 20);
			this.groupBox_jyParaSet.Location = location29;
			Padding margin29 = new Padding(2, 2, 2, 2);
			this.groupBox_jyParaSet.Margin = margin29;
			this.groupBox_jyParaSet.Name = "groupBox_jyParaSet";
			Padding padding6 = new Padding(2, 2, 2, 2);
			this.groupBox_jyParaSet.Padding = padding6;
			System.Drawing.Size size29 = new System.Drawing.Size(675, 160);
			this.groupBox_jyParaSet.Size = size29;
			this.groupBox_jyParaSet.TabIndex = 37;
			this.groupBox_jyParaSet.TabStop = false;
			this.groupBox_jyParaSet.Text = "高压绝缘默认参数设置";
			this.label_JY_DCRiseTime_unit.AutoSize = true;
			this.label_JY_DCRiseTime_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location30 = new System.Drawing.Point(634, 38);
			this.label_JY_DCRiseTime_unit.Location = location30;
			Padding margin30 = new Padding(2, 0, 2, 0);
			this.label_JY_DCRiseTime_unit.Margin = margin30;
			this.label_JY_DCRiseTime_unit.Name = "label_JY_DCRiseTime_unit";
			System.Drawing.Size size30 = new System.Drawing.Size(15, 15);
			this.label_JY_DCRiseTime_unit.Size = size30;
			this.label_JY_DCRiseTime_unit.TabIndex = 38;
			this.label_JY_DCRiseTime_unit.Text = "S";
			this.label_JY_DCRiseTime_unit.Visible = false;
			this.label_JY_HoldTime_unit.AutoSize = true;
			this.label_JY_HoldTime_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location31 = new System.Drawing.Point(298, 77);
			this.label_JY_HoldTime_unit.Location = location31;
			Padding margin31 = new Padding(2, 0, 2, 0);
			this.label_JY_HoldTime_unit.Margin = margin31;
			this.label_JY_HoldTime_unit.Name = "label_JY_HoldTime_unit";
			System.Drawing.Size size31 = new System.Drawing.Size(15, 15);
			this.label_JY_HoldTime_unit.Size = size31;
			this.label_JY_HoldTime_unit.TabIndex = 39;
			this.label_JY_HoldTime_unit.Text = "S";
			this.label_JY_DCVolt_unit.AutoSize = true;
			this.label_JY_DCVolt_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location32 = new System.Drawing.Point(298, 115);
			this.label_JY_DCVolt_unit.Location = location32;
			Padding margin32 = new Padding(2, 0, 2, 0);
			this.label_JY_DCVolt_unit.Margin = margin32;
			this.label_JY_DCVolt_unit.Name = "label_JY_DCVolt_unit";
			System.Drawing.Size size32 = new System.Drawing.Size(31, 15);
			this.label_JY_DCVolt_unit.Size = size32;
			this.label_JY_DCVolt_unit.TabIndex = 37;
			this.label_JY_DCVolt_unit.Text = "VDC";
			this.label_JY_Threshold_unit.AutoSize = true;
			this.label_JY_Threshold_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location33 = new System.Drawing.Point(298, 38);
			this.label_JY_Threshold_unit.Location = location33;
			Padding margin33 = new Padding(2, 0, 2, 0);
			this.label_JY_Threshold_unit.Margin = margin33;
			this.label_JY_Threshold_unit.Name = "label_JY_Threshold_unit";
			System.Drawing.Size size33 = new System.Drawing.Size(30, 15);
			this.label_JY_Threshold_unit.Size = size33;
			this.label_JY_Threshold_unit.TabIndex = 36;
			this.label_JY_Threshold_unit.Text = "MΩ";
			this.numericUpDown_JY_DCRiseTime.DecimalPlaces = 1;
			this.numericUpDown_JY_DCRiseTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location34 = new System.Drawing.Point(472, 34);
			this.numericUpDown_JY_DCRiseTime.Location = location34;
			Padding margin34 = new Padding(2, 2, 2, 2);
			this.numericUpDown_JY_DCRiseTime.Margin = margin34;
			decimal maximum8 = new decimal(new int[]
			{
				600,
				0,
				0,
				0
			});
			this.numericUpDown_JY_DCRiseTime.Maximum = maximum8;
			this.numericUpDown_JY_DCRiseTime.Name = "numericUpDown_JY_DCRiseTime";
			System.Drawing.Size size34 = new System.Drawing.Size(150, 24);
			this.numericUpDown_JY_DCRiseTime.Size = size34;
			this.numericUpDown_JY_DCRiseTime.TabIndex = 33;
			decimal value8 = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.numericUpDown_JY_DCRiseTime.Value = value8;
			this.numericUpDown_JY_DCRiseTime.Visible = false;
			this.numericUpDown_JY_HoldTime.DecimalPlaces = 3;
			this.numericUpDown_JY_HoldTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location35 = new System.Drawing.Point(137, 73);
			this.numericUpDown_JY_HoldTime.Location = location35;
			Padding margin35 = new Padding(2, 2, 2, 2);
			this.numericUpDown_JY_HoldTime.Margin = margin35;
			decimal maximum9 = new decimal(new int[]
			{
				3600,
				0,
				0,
				0
			});
			this.numericUpDown_JY_HoldTime.Maximum = maximum9;
			this.numericUpDown_JY_HoldTime.Name = "numericUpDown_JY_HoldTime";
			System.Drawing.Size size35 = new System.Drawing.Size(150, 24);
			this.numericUpDown_JY_HoldTime.Size = size35;
			this.numericUpDown_JY_HoldTime.TabIndex = 30;
			decimal value9 = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.numericUpDown_JY_HoldTime.Value = value9;
			this.numericUpDown_JY_DCVolt.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location36 = new System.Drawing.Point(137, 111);
			this.numericUpDown_JY_DCVolt.Location = location36;
			Padding margin36 = new Padding(2, 2, 2, 2);
			this.numericUpDown_JY_DCVolt.Margin = margin36;
			decimal maximum10 = new decimal(new int[]
			{
				1000000,
				0,
				0,
				0
			});
			this.numericUpDown_JY_DCVolt.Maximum = maximum10;
			this.numericUpDown_JY_DCVolt.Name = "numericUpDown_JY_DCVolt";
			System.Drawing.Size size36 = new System.Drawing.Size(150, 24);
			this.numericUpDown_JY_DCVolt.Size = size36;
			this.numericUpDown_JY_DCVolt.TabIndex = 31;
			decimal value10 = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			this.numericUpDown_JY_DCVolt.Value = value10;
			this.numericUpDown_JY_Threshold.DecimalPlaces = 2;
			this.numericUpDown_JY_Threshold.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location37 = new System.Drawing.Point(137, 34);
			this.numericUpDown_JY_Threshold.Location = location37;
			Padding margin37 = new Padding(2, 2, 2, 2);
			this.numericUpDown_JY_Threshold.Margin = margin37;
			decimal maximum11 = new decimal(new int[]
			{
				1000000,
				0,
				0,
				0
			});
			this.numericUpDown_JY_Threshold.Maximum = maximum11;
			this.numericUpDown_JY_Threshold.Name = "numericUpDown_JY_Threshold";
			System.Drawing.Size size37 = new System.Drawing.Size(150, 24);
			this.numericUpDown_JY_Threshold.Size = size37;
			this.numericUpDown_JY_Threshold.TabIndex = 29;
			decimal value11 = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.numericUpDown_JY_Threshold.Value = value11;
			this.label_jy_zlssTime.AutoSize = true;
			this.label_jy_zlssTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location38 = new System.Drawing.Point(359, 38);
			this.label_jy_zlssTime.Location = location38;
			Padding margin38 = new Padding(2, 0, 2, 0);
			this.label_jy_zlssTime.Margin = margin38;
			this.label_jy_zlssTime.Name = "label_jy_zlssTime";
			System.Drawing.Size size38 = new System.Drawing.Size(105, 15);
			this.label_jy_zlssTime.Size = size38;
			this.label_jy_zlssTime.TabIndex = 32;
			this.label_jy_zlssTime.Text = "绝缘上升时间:";
			this.label_jy_zlssTime.Visible = false;
			this.label_jy_jybcTime.AutoSize = true;
			this.label_jy_jybcTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location39 = new System.Drawing.Point(24, 77);
			this.label_jy_jybcTime.Location = location39;
			Padding margin39 = new Padding(2, 0, 2, 0);
			this.label_jy_jybcTime.Margin = margin39;
			this.label_jy_jybcTime.Name = "label_jy_jybcTime";
			System.Drawing.Size size39 = new System.Drawing.Size(105, 15);
			this.label_jy_jybcTime.Size = size39;
			this.label_jy_jybcTime.TabIndex = 28;
			this.label_jy_jybcTime.Text = "绝缘保持时间:";
			this.label_jy_zlgy.AutoSize = true;
			this.label_jy_zlgy.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location40 = new System.Drawing.Point(52, 115);
			this.label_jy_zlgy.Location = location40;
			Padding margin40 = new Padding(2, 0, 2, 0);
			this.label_jy_zlgy.Margin = margin40;
			this.label_jy_zlgy.Name = "label_jy_zlgy";
			System.Drawing.Size size40 = new System.Drawing.Size(75, 15);
			this.label_jy_zlgy.Size = size40;
			this.label_jy_zlgy.TabIndex = 34;
			this.label_jy_zlgy.Text = "绝缘电压:";
			this.label_jy_yz.AutoSize = true;
			this.label_jy_yz.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location41 = new System.Drawing.Point(52, 38);
			this.label_jy_yz.Location = location41;
			Padding margin41 = new Padding(2, 0, 2, 0);
			this.label_jy_yz.Margin = margin41;
			this.label_jy_yz.Name = "label_jy_yz";
			System.Drawing.Size size41 = new System.Drawing.Size(75, 15);
			this.label_jy_yz.Size = size41;
			this.label_jy_yz.TabIndex = 35;
			this.label_jy_yz.Text = "绝缘阈值:";
			System.Drawing.Color activeCaption4 = System.Drawing.SystemColors.ActiveCaption;
			this.tabPage7.BackColor = activeCaption4;
			this.tabPage7.Controls.Add(this.groupBox_nyParaSet);
			System.Drawing.Point location42 = new System.Drawing.Point(4, 34);
			this.tabPage7.Location = location42;
			Padding margin42 = new Padding(2, 2, 2, 2);
			this.tabPage7.Margin = margin42;
			this.tabPage7.Name = "tabPage7";
			Padding padding7 = new Padding(2, 2, 2, 2);
			this.tabPage7.Padding = padding7;
			System.Drawing.Size size42 = new System.Drawing.Size(732, 397);
			this.tabPage7.Size = size42;
			this.tabPage7.TabIndex = 2;
			this.tabPage7.Text = "耐压参数设置";
			this.groupBox_nyParaSet.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_nyParaSet.Controls.Add(this.numericUpDown_NY_Threshold);
			this.groupBox_nyParaSet.Controls.Add(this.numericUpDown_NY_ACVolt);
			this.groupBox_nyParaSet.Controls.Add(this.numericUpDown_NY_HoldTime);
			this.groupBox_nyParaSet.Controls.Add(this.label_ny_jlgy);
			this.groupBox_nyParaSet.Controls.Add(this.label_ny_nybcTime);
			this.groupBox_nyParaSet.Controls.Add(this.label_ny_yz);
			this.groupBox_nyParaSet.Controls.Add(this.label_NY_HoldTime_unit);
			this.groupBox_nyParaSet.Controls.Add(this.label_NY_ACVolt_unit);
			this.groupBox_nyParaSet.Controls.Add(this.label_NY_Threshold_unit);
			System.Drawing.Point location43 = new System.Drawing.Point(29, 22);
			this.groupBox_nyParaSet.Location = location43;
			Padding margin43 = new Padding(2, 2, 2, 2);
			this.groupBox_nyParaSet.Margin = margin43;
			this.groupBox_nyParaSet.Name = "groupBox_nyParaSet";
			Padding padding8 = new Padding(2, 2, 2, 2);
			this.groupBox_nyParaSet.Padding = padding8;
			System.Drawing.Size size43 = new System.Drawing.Size(675, 362);
			this.groupBox_nyParaSet.Size = size43;
			this.groupBox_nyParaSet.TabIndex = 38;
			this.groupBox_nyParaSet.TabStop = false;
			this.groupBox_nyParaSet.Text = "耐压默认参数设置";
			this.numericUpDown_NY_Threshold.Anchor = AnchorStyles.Top;
			this.numericUpDown_NY_Threshold.DecimalPlaces = 2;
			this.numericUpDown_NY_Threshold.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location44 = new System.Drawing.Point(137, 108);
			this.numericUpDown_NY_Threshold.Location = location44;
			Padding margin44 = new Padding(2, 2, 2, 2);
			this.numericUpDown_NY_Threshold.Margin = margin44;
			decimal maximum12 = new decimal(new int[]
			{
				1000000,
				0,
				0,
				0
			});
			this.numericUpDown_NY_Threshold.Maximum = maximum12;
			this.numericUpDown_NY_Threshold.Name = "numericUpDown_NY_Threshold";
			System.Drawing.Size size44 = new System.Drawing.Size(150, 24);
			this.numericUpDown_NY_Threshold.Size = size44;
			this.numericUpDown_NY_Threshold.TabIndex = 23;
			decimal value12 = new decimal(new int[]
			{
				2,
				0,
				0,
				0
			});
			this.numericUpDown_NY_Threshold.Value = value12;
			this.numericUpDown_NY_ACVolt.Anchor = AnchorStyles.Top;
			this.numericUpDown_NY_ACVolt.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location45 = new System.Drawing.Point(137, 199);
			this.numericUpDown_NY_ACVolt.Location = location45;
			Padding margin45 = new Padding(2, 2, 2, 2);
			this.numericUpDown_NY_ACVolt.Margin = margin45;
			decimal maximum13 = new decimal(new int[]
			{
				1000000,
				0,
				0,
				0
			});
			this.numericUpDown_NY_ACVolt.Maximum = maximum13;
			this.numericUpDown_NY_ACVolt.Name = "numericUpDown_NY_ACVolt";
			System.Drawing.Size size45 = new System.Drawing.Size(150, 24);
			this.numericUpDown_NY_ACVolt.Size = size45;
			this.numericUpDown_NY_ACVolt.TabIndex = 25;
			decimal value13 = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			this.numericUpDown_NY_ACVolt.Value = value13;
			this.numericUpDown_NY_HoldTime.Anchor = AnchorStyles.Top;
			this.numericUpDown_NY_HoldTime.DecimalPlaces = 1;
			this.numericUpDown_NY_HoldTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location46 = new System.Drawing.Point(137, 154);
			this.numericUpDown_NY_HoldTime.Location = location46;
			Padding margin46 = new Padding(2, 2, 2, 2);
			this.numericUpDown_NY_HoldTime.Margin = margin46;
			decimal maximum14 = new decimal(new int[]
			{
				3600,
				0,
				0,
				0
			});
			this.numericUpDown_NY_HoldTime.Maximum = maximum14;
			this.numericUpDown_NY_HoldTime.Name = "numericUpDown_NY_HoldTime";
			System.Drawing.Size size46 = new System.Drawing.Size(150, 24);
			this.numericUpDown_NY_HoldTime.Size = size46;
			this.numericUpDown_NY_HoldTime.TabIndex = 24;
			decimal value14 = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.numericUpDown_NY_HoldTime.Value = value14;
			this.label_ny_jlgy.Anchor = AnchorStyles.Top;
			this.label_ny_jlgy.AutoSize = true;
			this.label_ny_jlgy.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location47 = new System.Drawing.Point(53, 203);
			this.label_ny_jlgy.Location = location47;
			Padding margin47 = new Padding(2, 0, 2, 0);
			this.label_ny_jlgy.Margin = margin47;
			this.label_ny_jlgy.Name = "label_ny_jlgy";
			System.Drawing.Size size47 = new System.Drawing.Size(75, 15);
			this.label_ny_jlgy.Size = size47;
			this.label_ny_jlgy.TabIndex = 20;
			this.label_ny_jlgy.Text = "耐压电压:";
			this.label_ny_nybcTime.Anchor = AnchorStyles.Top;
			this.label_ny_nybcTime.AutoSize = true;
			this.label_ny_nybcTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location48 = new System.Drawing.Point(24, 158);
			this.label_ny_nybcTime.Location = location48;
			Padding margin48 = new Padding(2, 0, 2, 0);
			this.label_ny_nybcTime.Margin = margin48;
			this.label_ny_nybcTime.Name = "label_ny_nybcTime";
			System.Drawing.Size size48 = new System.Drawing.Size(105, 15);
			this.label_ny_nybcTime.Size = size48;
			this.label_ny_nybcTime.TabIndex = 21;
			this.label_ny_nybcTime.Text = "耐压保持时间:";
			this.label_ny_yz.Anchor = AnchorStyles.Top;
			this.label_ny_yz.AutoSize = true;
			this.label_ny_yz.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location49 = new System.Drawing.Point(53, 112);
			this.label_ny_yz.Location = location49;
			Padding margin49 = new Padding(2, 0, 2, 0);
			this.label_ny_yz.Margin = margin49;
			this.label_ny_yz.Name = "label_ny_yz";
			System.Drawing.Size size49 = new System.Drawing.Size(75, 15);
			this.label_ny_yz.Size = size49;
			this.label_ny_yz.TabIndex = 19;
			this.label_ny_yz.Text = "耐压阈值:";
			this.label_NY_HoldTime_unit.Anchor = AnchorStyles.Top;
			this.label_NY_HoldTime_unit.AutoSize = true;
			this.label_NY_HoldTime_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location50 = new System.Drawing.Point(299, 158);
			this.label_NY_HoldTime_unit.Location = location50;
			Padding margin50 = new Padding(2, 0, 2, 0);
			this.label_NY_HoldTime_unit.Margin = margin50;
			this.label_NY_HoldTime_unit.Name = "label_NY_HoldTime_unit";
			System.Drawing.Size size50 = new System.Drawing.Size(15, 15);
			this.label_NY_HoldTime_unit.Size = size50;
			this.label_NY_HoldTime_unit.TabIndex = 18;
			this.label_NY_HoldTime_unit.Text = "S";
			this.label_NY_ACVolt_unit.Anchor = AnchorStyles.Top;
			this.label_NY_ACVolt_unit.AutoSize = true;
			this.label_NY_ACVolt_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location51 = new System.Drawing.Point(299, 203);
			this.label_NY_ACVolt_unit.Location = location51;
			Padding margin51 = new Padding(2, 0, 2, 0);
			this.label_NY_ACVolt_unit.Margin = margin51;
			this.label_NY_ACVolt_unit.Name = "label_NY_ACVolt_unit";
			System.Drawing.Size size51 = new System.Drawing.Size(31, 15);
			this.label_NY_ACVolt_unit.Size = size51;
			this.label_NY_ACVolt_unit.TabIndex = 22;
			this.label_NY_ACVolt_unit.Text = "VAC";
			this.label_NY_Threshold_unit.Anchor = AnchorStyles.Top;
			this.label_NY_Threshold_unit.AutoSize = true;
			this.label_NY_Threshold_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location52 = new System.Drawing.Point(299, 112);
			this.label_NY_Threshold_unit.Location = location52;
			Padding margin52 = new Padding(2, 0, 2, 0);
			this.label_NY_Threshold_unit.Margin = margin52;
			this.label_NY_Threshold_unit.Name = "label_NY_Threshold_unit";
			System.Drawing.Size size52 = new System.Drawing.Size(23, 15);
			this.label_NY_Threshold_unit.Size = size52;
			this.label_NY_Threshold_unit.TabIndex = 26;
			this.label_NY_Threshold_unit.Text = "mA";
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location53 = new System.Drawing.Point(420, 521);
			this.btnQuit.Location = location53;
			Padding margin53 = new Padding(2, 2, 2, 2);
			this.btnQuit.Margin = margin53;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size53 = new System.Drawing.Size(90, 24);
			this.btnQuit.Size = size53;
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btnSubmit.Anchor = AnchorStyles.Bottom;
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location54 = new System.Drawing.Point(285, 521);
			this.btnSubmit.Location = location54;
			Padding margin54 = new Padding(2, 2, 2, 2);
			this.btnSubmit.Margin = margin54;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size54 = new System.Drawing.Size(90, 24);
			this.btnSubmit.Size = size54;
			this.btnSubmit.TabIndex = 0;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.tabControl1);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnSubmit);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin55 = new Padding(2, 2, 2, 2);
			base.Margin = margin55;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormDefaultTestParaSet";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "默认试验参数设置";
			base.Load += new System.EventHandler(this.ctFormDefaultTestParaSet_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.groupBox_dtParaSet.ResumeLayout(false);
			this.groupBox_dtParaSet.PerformLayout();
			((ISupportInitialize)this.numericUpDown_DT_Current).EndInit();
			((ISupportInitialize)this.numericUpDown_DT_Volt).EndInit();
			((ISupportInitialize)this.numericUpDown_DT_Threshold).EndInit();
			this.tabPage6.ResumeLayout(false);
			this.groupBox_jyParaSet_LowVolt.ResumeLayout(false);
			this.groupBox_jyParaSet_LowVolt.PerformLayout();
			((ISupportInitialize)this.numericUpDown_DYJY_DCRiseTime).EndInit();
			((ISupportInitialize)this.numericUpDown_DYJY_HoldTime).EndInit();
			((ISupportInitialize)this.numericUpDown_DYJY_DCVolt).EndInit();
			((ISupportInitialize)this.numericUpDown_DYJY_Threshold).EndInit();
			this.groupBox_jyParaSet.ResumeLayout(false);
			this.groupBox_jyParaSet.PerformLayout();
			((ISupportInitialize)this.numericUpDown_JY_DCRiseTime).EndInit();
			((ISupportInitialize)this.numericUpDown_JY_HoldTime).EndInit();
			((ISupportInitialize)this.numericUpDown_JY_DCVolt).EndInit();
			((ISupportInitialize)this.numericUpDown_JY_Threshold).EndInit();
			this.tabPage7.ResumeLayout(false);
			this.groupBox_nyParaSet.ResumeLayout(false);
			this.groupBox_nyParaSet.PerformLayout();
			((ISupportInitialize)this.numericUpDown_NY_Threshold).EndInit();
			((ISupportInitialize)this.numericUpDown_NY_ACVolt).EndInit();
			((ISupportInitialize)this.numericUpDown_NY_HoldTime).EndInit();
			base.ResumeLayout(false);
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
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool DealwithSubmitFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				double dDT_Threshold = System.Convert.ToDouble(this.numericUpDown_DT_Threshold.Value);
				double dDT_DTVoltage = System.Convert.ToDouble(this.numericUpDown_DT_Volt.Value);
				double dDT_DTCurrent = System.Convert.ToDouble(this.numericUpDown_DT_Current.Value);
				double dJY_Threshold = System.Convert.ToDouble(this.numericUpDown_JY_Threshold.Value);
				double dJY_JYHoldTime = System.Convert.ToDouble(this.numericUpDown_JY_HoldTime.Value);
				double dJY_DCHighVolt = System.Convert.ToDouble(this.numericUpDown_JY_DCVolt.Value);
				double dJY_DCRiseTime = System.Convert.ToDouble(this.numericUpDown_JY_DCRiseTime.Value);
				double dDYJY_Threshold = System.Convert.ToDouble(this.numericUpDown_DYJY_Threshold.Value);
				double dDYJY_JYHoldTime = System.Convert.ToDouble(this.numericUpDown_DYJY_HoldTime.Value);
				double dDYJY_DCHighVolt = System.Convert.ToDouble(this.numericUpDown_DYJY_DCVolt.Value);
				double dDYJY_DCRiseTime = System.Convert.ToDouble(this.numericUpDown_DYJY_DCRiseTime.Value);
				double dNY_Threshold = System.Convert.ToDouble(this.numericUpDown_NY_Threshold.Value);
				double dNY_NYHoldTime = System.Convert.ToDouble(this.numericUpDown_NY_HoldTime.Value);
				double dNY_ACHighVolt = System.Convert.ToDouble(this.numericUpDown_NY_ACVolt.Value);
				dDT_Threshold = System.Math.Round(dDT_Threshold, 6);
				dJY_Threshold = System.Math.Round(dJY_Threshold, 6);
				dJY_JYHoldTime = System.Math.Round(dJY_JYHoldTime, 6);
				dJY_DCHighVolt = System.Math.Round(dJY_DCHighVolt, 6);
				dJY_DCRiseTime = System.Math.Round(dJY_DCRiseTime, 6);
				dNY_Threshold = System.Math.Round(dNY_Threshold, 6);
				dNY_NYHoldTime = System.Math.Round(dNY_NYHoldTime, 6);
				dNY_ACHighVolt = System.Math.Round(dNY_ACHighVolt, 6);
				double dDR_Threshold = System.Math.Round(1.0, 6);
				double dDR_DRHoldTime = System.Math.Round(5.0, 6);
				double dDR_FreqValue = System.Math.Round(1000.0, 6);
				double dDR_VoltValue = System.Math.Round(1.0, 6);
				bool bExsitFlag = false;
				bool result;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "select top 1 * from TDefaultTestParaInfo";
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						bExsitFlag = true;
					}
					dataReader.Close();
					dataReader = null;
					if (bExsitFlag)
					{
						sqlcommand = "update TDefaultTestParaInfo set iTestModel = " + 1 + ",iDTTestModel = " + 2 + ",iJYTestModel = " + 1 + ",iNYTestModel = " + 1 + ",dDT_Threshold = " + dDT_Threshold + ",dDT_DTVoltage = " + dDT_DTVoltage + ",dDT_DTCurrent = " + dDT_DTCurrent + ",dJY_Threshold = " + dJY_Threshold + ",dJY_JYHoldTime = " + dJY_JYHoldTime + ",dJY_DCHighVolt = " + dJY_DCHighVolt + ",dJY_DCRiseTime = " + dJY_DCRiseTime + ",dDYJY_Threshold = " + dDYJY_Threshold + ",dDYJY_JYHoldTime = " + dDYJY_JYHoldTime + ",dDYJY_DCHighVolt = " + dDYJY_DCHighVolt + ",dDYJY_DCRiseTime = " + dDYJY_DCRiseTime + ",dNY_Threshold = " + dNY_Threshold + ",dNY_NYHoldTime = " + dNY_NYHoldTime + ",dNY_ACHighVolt = " + dNY_ACHighVolt + ",dDR_Threshold = " + dDR_Threshold + ",dDR_DRHoldTime = " + dDR_DRHoldTime + ",dDR_FreqValue = " + dDR_FreqValue + ",dDR_VoltValue = " + dDR_VoltValue;
					}
					else
					{
						string this2 = ",";
						sqlcommand = "insert into TDefaultTestParaInfo(iTestModel,iDTTestModel,iJYTestModel,iNYTestModel,dDT_Threshold,dDT_DTVoltage,dDT_DTCurrent,dJY_Threshold,dJY_JYHoldTime,dJY_DCHighVolt,dJY_DCRiseTime," + "dDYJY_Threshold,dDYJY_JYHoldTime,dDYJY_DCHighVolt,dDYJY_DCRiseTime,dNY_Threshold,dNY_NYHoldTime,dNY_ACHighVolt,dDR_Threshold,dDR_DRHoldTime,dDR_FreqValue,dDR_VoltValue) " + "values(" + 1 + this2 + 2 + this2 + 1 + this2 + 1 + this2 + dDT_Threshold + this2 + dDT_DTVoltage + this2 + dDT_DTCurrent + this2 + dJY_Threshold + this2 + dJY_JYHoldTime + this2 + dJY_DCHighVolt + this2 + dJY_DCRiseTime + this2 + dDYJY_Threshold + this2 + dDYJY_JYHoldTime + this2 + dDYJY_DCHighVolt + this2 + dDYJY_DCRiseTime + this2 + dNY_Threshold + this2 + dNY_NYHoldTime + this2 + dNY_ACHighVolt + this2 + dDR_Threshold + this2 + dDR_DRHoldTime + this2 + dDR_FreqValue + this2 + dDR_VoltValue + ")";
					}
					cmd = new OleDbCommand(sqlcommand, connection);
					cmd.ExecuteNonQuery();
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_5C5_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_5C5_0.StackTrace);
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
					result = false;
					goto IL_5EC;
				}
				return true;
				IL_5EC:
				return result;
			}
			catch (System.Exception arg_5F2_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5F2_0.StackTrace);
				return false;
			}
			return true;
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.DealwithSubmitFunc())
				{
					MessageBox.Show("操作失败!", "提示", MessageBoxButtons.OK);
					return;
				}
			}
			catch (System.Exception arg_1D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1D_0.StackTrace);
			}
			base.Close();
		}
		public void LoadDefaultTestParaFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				double dDT_Threshold = 5.0;
				double dDT_DTVoltage = 2.5;
				double dDT_DTCurrent = 2000.0;
				double dJY_Threshold = 20.0;
				double dJY_JYHoldTime = 0.5;
				double dJY_DCHighVolt = 100.0;
				double dJY_DCRiseTime = 0.2;
				double dDYJY_Threshold = 10.0;
				double dDYJY_JYHoldTime = 0.5;
				double dDYJY_DCHighVolt = 30.0;
				double dDYJY_DCRiseTime = 0.2;
				double dNY_Threshold = 1.5;
				double dNY_NYHoldTime = 1.0;
				double dNY_ACHighVolt = 100.0;
				string dbpath = Application.StartupPath + "\\ctsdb.mdb";
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select * from TDefaultTestParaInfo", connection).ExecuteReader();
					if (dataReader.Read())
					{
						int iTestModel = System.Convert.ToInt32(dataReader["iTestModel"].ToString());
						int iDTTestModel = System.Convert.ToInt32(dataReader["iDTTestModel"].ToString());
						int iJYTestModel = System.Convert.ToInt32(dataReader["iJYTestModel"].ToString());
						int iNYTestModel = System.Convert.ToInt32(dataReader["iNYTestModel"].ToString());
						dDT_Threshold = System.Convert.ToDouble(dataReader["dDT_Threshold"].ToString());
						dDT_DTVoltage = System.Convert.ToDouble(dataReader["dDT_DTVoltage"].ToString());
						dDT_DTCurrent = System.Convert.ToDouble(dataReader["dDT_DTCurrent"].ToString());
						dJY_Threshold = System.Convert.ToDouble(dataReader["dJY_Threshold"].ToString());
						dJY_JYHoldTime = System.Convert.ToDouble(dataReader["dJY_JYHoldTime"].ToString());
						dJY_DCHighVolt = System.Convert.ToDouble(dataReader["dJY_DCHighVolt"].ToString());
						dJY_DCRiseTime = System.Convert.ToDouble(dataReader["dJY_DCRiseTime"].ToString());
						dDYJY_Threshold = System.Convert.ToDouble(dataReader["dDYJY_Threshold"].ToString());
						dDYJY_JYHoldTime = System.Convert.ToDouble(dataReader["dDYJY_JYHoldTime"].ToString());
						dDYJY_DCHighVolt = System.Convert.ToDouble(dataReader["dDYJY_DCHighVolt"].ToString());
						dDYJY_DCRiseTime = System.Convert.ToDouble(dataReader["dDYJY_DCRiseTime"].ToString());
						dNY_Threshold = System.Convert.ToDouble(dataReader["dNY_Threshold"].ToString());
						dNY_NYHoldTime = System.Convert.ToDouble(dataReader["dNY_NYHoldTime"].ToString());
						dNY_ACHighVolt = System.Convert.ToDouble(dataReader["dNY_ACHighVolt"].ToString());
						double dDR_Threshold = System.Convert.ToDouble(dataReader["dDR_Threshold"].ToString());
						double dDR_DRHoldTime = System.Convert.ToDouble(dataReader["dDR_DRHoldTime"].ToString());
						double dDR_FreqValue = System.Convert.ToDouble(dataReader["dDR_FreqValue"].ToString());
						double dDR_VoltValue = System.Convert.ToDouble(dataReader["dDR_VoltValue"].ToString());
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_328_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_328_0.StackTrace);
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
				decimal value = System.Convert.ToDecimal(dDT_Threshold);
				this.numericUpDown_DT_Threshold.Value = value;
				decimal value2 = System.Convert.ToDecimal(dDT_DTVoltage);
				this.numericUpDown_DT_Volt.Value = value2;
				decimal value3 = System.Convert.ToDecimal(dDT_DTCurrent);
				this.numericUpDown_DT_Current.Value = value3;
				decimal value4 = System.Convert.ToDecimal(dJY_Threshold);
				this.numericUpDown_JY_Threshold.Value = value4;
				decimal value5 = System.Convert.ToDecimal(dJY_JYHoldTime);
				this.numericUpDown_JY_HoldTime.Value = value5;
				decimal value6 = System.Convert.ToDecimal(dJY_DCHighVolt);
				this.numericUpDown_JY_DCVolt.Value = value6;
				decimal value7 = System.Convert.ToDecimal(dJY_DCRiseTime);
				this.numericUpDown_JY_DCRiseTime.Value = value7;
				decimal value8 = System.Convert.ToDecimal(dDYJY_Threshold);
				this.numericUpDown_DYJY_Threshold.Value = value8;
				decimal value9 = System.Convert.ToDecimal(dDYJY_JYHoldTime);
				this.numericUpDown_DYJY_HoldTime.Value = value9;
				decimal value10 = System.Convert.ToDecimal(dDYJY_DCHighVolt);
				this.numericUpDown_DYJY_DCVolt.Value = value10;
				decimal value11 = System.Convert.ToDecimal(dDYJY_DCRiseTime);
				this.numericUpDown_DYJY_DCRiseTime.Value = value11;
				decimal value12 = System.Convert.ToDecimal(dNY_Threshold);
				this.numericUpDown_NY_Threshold.Value = value12;
				decimal value13 = System.Convert.ToDecimal(dNY_NYHoldTime);
				this.numericUpDown_NY_HoldTime.Value = value13;
				decimal value14 = System.Convert.ToDecimal(dNY_ACHighVolt);
				this.numericUpDown_NY_ACVolt.Value = value14;
			}
			catch (System.Exception arg_47E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_47E_0.StackTrace);
			}
		}
		public void SetAllControlMaxMinValueFunc()
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
						this.d_DT_Volt_Min = System.Convert.ToDouble(dataReader["d_DT_Volt_Min"].ToString());
						this.d_DT_Volt_Max = System.Convert.ToDouble(dataReader["d_DT_Volt_Max"].ToString());
						this.d_DT_Current_Min = System.Convert.ToDouble(dataReader["d_DT_Current_Min"].ToString());
						this.d_DT_Current_Max = System.Convert.ToDouble(dataReader["d_DT_Current_Max"].ToString());
						this.d_JY_Threshold_Min = System.Convert.ToDouble(dataReader["d_JY_Threshold_Min"].ToString());
						this.d_JY_Threshold_Max = System.Convert.ToDouble(dataReader["d_JY_Threshold_Max"].ToString());
						this.d_JY_HoldTime_Min = System.Convert.ToDouble(dataReader["d_JY_HoldTime_Min"].ToString());
						this.d_JY_HoldTime_Max = System.Convert.ToDouble(dataReader["d_JY_HoldTime_Max"].ToString());
						this.d_JY_DCVolt_Min = System.Convert.ToDouble(dataReader["d_JY_DCVolt_Min"].ToString());
						this.d_JY_DCVolt_Max = System.Convert.ToDouble(dataReader["d_JY_DCVolt_Max"].ToString());
						this.d_JY_DCRiseTime_Min = System.Convert.ToDouble(dataReader["d_JY_DCRiseTime_Min"].ToString());
						this.d_JY_DCRiseTime_Max = System.Convert.ToDouble(dataReader["d_JY_DCRiseTime_Max"].ToString());
						this.d_DYJY_Threshold_Min = System.Convert.ToDouble(dataReader["d_DYJY_Threshold_Min"].ToString());
						this.d_DYJY_Threshold_Max = System.Convert.ToDouble(dataReader["d_DYJY_Threshold_Max"].ToString());
						this.d_DYJY_HoldTime_Min = System.Convert.ToDouble(dataReader["d_DYJY_HoldTime_Min"].ToString());
						this.d_DYJY_HoldTime_Max = System.Convert.ToDouble(dataReader["d_DYJY_HoldTime_Max"].ToString());
						this.d_DYJY_DCVolt_Min = System.Convert.ToDouble(dataReader["d_DYJY_DCVolt_Min"].ToString());
						this.d_DYJY_DCVolt_Max = System.Convert.ToDouble(dataReader["d_DYJY_DCVolt_Max"].ToString());
						this.d_DYJY_DCRiseTime_Min = System.Convert.ToDouble(dataReader["d_DYJY_DCRiseTime_Min"].ToString());
						this.d_DYJY_DCRiseTime_Max = System.Convert.ToDouble(dataReader["d_DYJY_DCRiseTime_Max"].ToString());
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
				catch (System.Exception arg_347_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_347_0.StackTrace);
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
					this.numericUpDown_DT_Threshold.Minimum = minimum;
					decimal maximum = System.Convert.ToDecimal(this.d_DT_Threshold_Max);
					this.numericUpDown_DT_Threshold.Maximum = maximum;
					this.label_DT_Threshold_unit.Text = "Ω   (" + System.Convert.ToString(this.d_DT_Threshold_Min) + "~" + System.Convert.ToString(this.d_DT_Threshold_Max) + ")";
					decimal minimum2 = System.Convert.ToDecimal(this.d_DT_Volt_Min);
					this.numericUpDown_DT_Volt.Minimum = minimum2;
					decimal maximum2 = System.Convert.ToDecimal(this.d_DT_Volt_Max);
					this.numericUpDown_DT_Volt.Maximum = maximum2;
					this.label_DT_Volt_unit.Text = "VDC (" + System.Convert.ToString(this.d_DT_Volt_Min) + "~" + System.Convert.ToString(this.d_DT_Volt_Max) + ")";
					decimal minimum3 = System.Convert.ToDecimal(this.d_DT_Current_Min);
					this.numericUpDown_DT_Current.Minimum = minimum3;
					decimal maximum3 = System.Convert.ToDecimal(this.d_DT_Current_Max);
					this.numericUpDown_DT_Current.Maximum = maximum3;
					this.label_DT_Current_unit.Text = "mA  (" + System.Convert.ToString(this.d_DT_Current_Min) + "~" + System.Convert.ToString(this.d_DT_Current_Max) + ")";
					decimal minimum4 = System.Convert.ToDecimal(this.d_JY_Threshold_Min);
					this.numericUpDown_JY_Threshold.Minimum = minimum4;
					decimal maximum4 = System.Convert.ToDecimal(this.d_JY_Threshold_Max);
					this.numericUpDown_JY_Threshold.Maximum = maximum4;
					this.label_JY_Threshold_unit.Text = "MΩ  (" + System.Convert.ToString(this.d_JY_Threshold_Min) + "~" + System.Convert.ToString(this.d_JY_Threshold_Max) + ")";
					decimal minimum5 = System.Convert.ToDecimal(this.d_JY_HoldTime_Min);
					this.numericUpDown_JY_HoldTime.Minimum = minimum5;
					decimal maximum5 = System.Convert.ToDecimal(this.d_JY_HoldTime_Max);
					this.numericUpDown_JY_HoldTime.Maximum = maximum5;
					this.label_JY_HoldTime_unit.Text = "S   (" + System.Convert.ToString(this.d_JY_HoldTime_Min) + "~" + System.Convert.ToString(this.d_JY_HoldTime_Max) + ")";
					decimal minimum6 = System.Convert.ToDecimal(this.d_JY_DCVolt_Min);
					this.numericUpDown_JY_DCVolt.Minimum = minimum6;
					decimal maximum6 = System.Convert.ToDecimal(this.d_JY_DCVolt_Max);
					this.numericUpDown_JY_DCVolt.Maximum = maximum6;
					this.label_JY_DCVolt_unit.Text = "VDC (" + System.Convert.ToString(this.d_JY_DCVolt_Min) + "~" + System.Convert.ToString(this.d_JY_DCVolt_Max) + ")";
					decimal minimum7 = System.Convert.ToDecimal(this.d_JY_DCRiseTime_Min);
					this.numericUpDown_JY_DCRiseTime.Minimum = minimum7;
					decimal maximum7 = System.Convert.ToDecimal(this.d_JY_DCRiseTime_Max);
					this.numericUpDown_JY_DCRiseTime.Maximum = maximum7;
					this.label_JY_DCRiseTime_unit.Text = "S   (" + System.Convert.ToString(this.d_JY_DCRiseTime_Min) + "~" + System.Convert.ToString(this.d_JY_DCRiseTime_Max) + ")";
					decimal minimum8 = System.Convert.ToDecimal(this.d_DYJY_Threshold_Min);
					this.numericUpDown_DYJY_Threshold.Minimum = minimum8;
					decimal maximum8 = System.Convert.ToDecimal(this.d_DYJY_Threshold_Max);
					this.numericUpDown_DYJY_Threshold.Maximum = maximum8;
					this.label_DYJY_Threshold_unit.Text = "MΩ  (" + System.Convert.ToString(this.d_DYJY_Threshold_Min) + "~" + System.Convert.ToString(this.d_DYJY_Threshold_Max) + ")";
					decimal minimum9 = System.Convert.ToDecimal(this.d_DYJY_HoldTime_Min);
					this.numericUpDown_DYJY_HoldTime.Minimum = minimum9;
					decimal maximum9 = System.Convert.ToDecimal(this.d_DYJY_HoldTime_Max);
					this.numericUpDown_DYJY_HoldTime.Maximum = maximum9;
					this.label_DYJY_HoldTime_unit.Text = "S   (" + System.Convert.ToString(this.d_DYJY_HoldTime_Min) + "~" + System.Convert.ToString(this.d_DYJY_HoldTime_Max) + ")";
					decimal minimum10 = System.Convert.ToDecimal(this.d_DYJY_DCVolt_Min);
					this.numericUpDown_DYJY_DCVolt.Minimum = minimum10;
					decimal maximum10 = System.Convert.ToDecimal(this.d_DYJY_DCVolt_Max);
					this.numericUpDown_DYJY_DCVolt.Maximum = maximum10;
					this.label_DYJY_DCVolt_unit.Text = "VDC (" + System.Convert.ToString(this.d_DYJY_DCVolt_Min) + "~" + System.Convert.ToString(this.d_DYJY_DCVolt_Max) + ")";
					decimal minimum11 = System.Convert.ToDecimal(this.d_DYJY_DCRiseTime_Min);
					this.numericUpDown_DYJY_DCRiseTime.Minimum = minimum11;
					decimal maximum11 = System.Convert.ToDecimal(this.d_DYJY_DCRiseTime_Max);
					this.numericUpDown_DYJY_DCRiseTime.Maximum = maximum11;
					this.label_DYJY_DCRiseTime_unit.Text = "S   (" + System.Convert.ToString(this.d_DYJY_DCRiseTime_Min) + "~" + System.Convert.ToString(this.d_DYJY_DCRiseTime_Max) + ")";
					decimal minimum12 = System.Convert.ToDecimal(this.d_NY_Threshold_Min);
					this.numericUpDown_NY_Threshold.Minimum = minimum12;
					decimal maximum12 = System.Convert.ToDecimal(this.d_NY_Threshold_Max);
					this.numericUpDown_NY_Threshold.Maximum = maximum12;
					this.label_NY_Threshold_unit.Text = "mA  (" + System.Convert.ToString(this.d_NY_Threshold_Min) + "~" + System.Convert.ToString(this.d_NY_Threshold_Max) + ")";
					decimal minimum13 = System.Convert.ToDecimal(this.d_NY_HoldTime_Min);
					this.numericUpDown_NY_HoldTime.Minimum = minimum13;
					decimal maximum13 = System.Convert.ToDecimal(this.d_NY_HoldTime_Max);
					this.numericUpDown_NY_HoldTime.Maximum = maximum13;
					this.label_NY_HoldTime_unit.Text = "S   (" + System.Convert.ToString(this.d_NY_HoldTime_Min) + "~" + System.Convert.ToString(this.d_NY_HoldTime_Max) + ")";
					decimal minimum14 = System.Convert.ToDecimal(this.d_NY_ACVolt_Min);
					this.numericUpDown_NY_ACVolt.Minimum = minimum14;
					decimal maximum14 = System.Convert.ToDecimal(this.d_NY_ACVolt_Max);
					this.numericUpDown_NY_ACVolt.Maximum = maximum14;
					this.label_NY_ACVolt_unit.Text = "VAC (" + System.Convert.ToString(this.d_NY_ACVolt_Min) + "~" + System.Convert.ToString(this.d_NY_ACVolt_Max) + ")";
				}
			}
			catch (System.Exception arg_9FF_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_9FF_0.StackTrace);
			}
		}
		public void SetTestControlVisibleFunc()
		{
			try
			{
				this.groupBox_jyParaSet_LowVolt.Visible = this.gLineTestProcessor.bJYHighLowModeShowFlag;
			}
			catch (System.Exception arg_18_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_18_0.StackTrace);
			}
		}
		private void ctFormDefaultTestParaSet_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.SetTestControlVisibleFunc();
				this.SetAllControlMaxMinValueFunc();
				this.LoadDefaultTestParaFunc();
			}
			catch (System.Exception arg_14_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_14_0.StackTrace);
			}
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode == 0)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
			catch (System.Exception arg_37_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_37_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormDefaultTestParaSet();
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
