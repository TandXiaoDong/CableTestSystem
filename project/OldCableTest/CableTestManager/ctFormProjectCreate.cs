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
	public class ctFormProjectCreate : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public ctFormGroupTestParaSet groupTestParaSetForm;
		public ctFormCableLibrary cableLibraryForm;
		public ctFormEditCable editCableForm;
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
		public string[] strIDArray;
		public string[] strTempArray;
		public string[] strPlugArray;
		public string dbpath;
		public string tempStr;
		public string oldSXstr;
		public string ct_TestBCXSStr;
		public string testProjectNameStr;
		public bool createSuccFlag;
		private Button btnTMSM;
		private CheckBox checkBox_GroupTest;
		private Button btnGroupTestParaSet;
		private Label label_batchMumber;
		private TextBox textBox_batchMumber;
		private TextBox textBox_yxbcCable;
		private Label label_DYJY_DCRiseTime_unit;
		private Label label_DYJY_HoldTime_unit;
		private Label label_DYJY_DCVolt_unit;
		private Label label_DYJY_Threshold_unit;
		private NumericUpDown numericUpDown_DYJY_DCRiseTime;
		private NumericUpDown numericUpDown_DYJY_HoldTime;
		private NumericUpDown numericUpDown_DYJY_DCVolt;
		private NumericUpDown numericUpDown_DYJY_Threshold;
		private Label label_dyjy_zlssTime;
		private Label label_dyjy_jybcTime;
		private Label label_dyjy_zlgy;
		private Label label_dyjy_yz;
		private RadioButton radioButton_jy_LowVolt;
		private RadioButton radioButton_jy_HighVolt;
		private Label label_jy_TestMode;
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
		private GroupBox groupBox_dtParaSet;
		private NumericUpDown numericUpDown_DT_Current;
		private Label label_DT_Volt_unit;
		private NumericUpDown numericUpDown_DT_Volt;
		private Label label_dt_dy;
		private Label label_dt_yz;
		private Label label_dt_dl;
		private NumericUpDown numericUpDown_DT_Threshold;
		private Label label_DT_Current_unit;
		private Label label_DT_Threshold_unit;
		private CheckBox checkBox_CommonProject;
		private Label label24;
		private GroupBox groupBox1;
		private DataGridView dataGridView1;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn Column3;
		private DataGridViewTextBoxColumn Column4;
		private DataGridViewTextBoxColumn Column5;
		private Label label_projectName;
		private TextBox textBox_projectName;
		private Button btnSubmit;
		private Button btnQuit;
		private Label label_remark;
		private TextBox textBox_Remark;
		private TabControl tabControl_createProject;
		private TabPage tabPage_paraSetting;
		private TabPage tabPage_choiceTestCable;
		private TextBox textBox_Cable;
		private Label label23;
		private Container components;
		public ctFormProjectCreate(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.createSuccFlag = false;
					this.testProjectNameStr = "";
					this.ct_TestBCXSStr = "";
					this.oldSXstr = "";
					this.strIDArray = new string[5000];
					this.strPlugArray = new string[5000];
				}
				catch (System.Exception ex_72)
				{
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormProjectCreate()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormProjectCreate));
			this.label_projectName = new Label();
			this.textBox_projectName = new TextBox();
			this.btnSubmit = new Button();
			this.btnQuit = new Button();
			this.label_remark = new Label();
			this.textBox_Remark = new TextBox();
			this.tabControl_createProject = new TabControl();
			this.tabPage_choiceTestCable = new TabPage();
			this.btnTMSM = new Button();
			this.groupBox1 = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.label24 = new Label();
			this.textBox_yxbcCable = new TextBox();
			this.textBox_Cable = new TextBox();
			this.label23 = new Label();
			this.tabPage_paraSetting = new TabPage();
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
			this.groupBox_jyParaSet = new GroupBox();
			this.label_DYJY_DCRiseTime_unit = new Label();
			this.label_DYJY_HoldTime_unit = new Label();
			this.label_DYJY_DCVolt_unit = new Label();
			this.label_DYJY_Threshold_unit = new Label();
			this.numericUpDown_DYJY_DCRiseTime = new NumericUpDown();
			this.numericUpDown_DYJY_HoldTime = new NumericUpDown();
			this.numericUpDown_DYJY_DCVolt = new NumericUpDown();
			this.numericUpDown_DYJY_Threshold = new NumericUpDown();
			this.label_dyjy_zlssTime = new Label();
			this.label_dyjy_jybcTime = new Label();
			this.label_dyjy_zlgy = new Label();
			this.label_dyjy_yz = new Label();
			this.label_JY_DCRiseTime_unit = new Label();
			this.label_JY_HoldTime_unit = new Label();
			this.radioButton_jy_LowVolt = new RadioButton();
			this.label_JY_DCVolt_unit = new Label();
			this.label_JY_Threshold_unit = new Label();
			this.numericUpDown_JY_DCRiseTime = new NumericUpDown();
			this.numericUpDown_JY_HoldTime = new NumericUpDown();
			this.radioButton_jy_HighVolt = new RadioButton();
			this.numericUpDown_JY_DCVolt = new NumericUpDown();
			this.label_jy_TestMode = new Label();
			this.numericUpDown_JY_Threshold = new NumericUpDown();
			this.label_jy_zlssTime = new Label();
			this.label_jy_jybcTime = new Label();
			this.label_jy_zlgy = new Label();
			this.label_jy_yz = new Label();
			this.groupBox_dtParaSet = new GroupBox();
			this.numericUpDown_DT_Current = new NumericUpDown();
			this.label_DT_Volt_unit = new Label();
			this.numericUpDown_DT_Volt = new NumericUpDown();
			this.label_dt_dy = new Label();
			this.label_dt_yz = new Label();
			this.label_dt_dl = new Label();
			this.numericUpDown_DT_Threshold = new NumericUpDown();
			this.label_DT_Current_unit = new Label();
			this.label_DT_Threshold_unit = new Label();
			this.checkBox_GroupTest = new CheckBox();
			this.btnGroupTestParaSet = new Button();
			this.checkBox_CommonProject = new CheckBox();
			this.label_batchMumber = new Label();
			this.textBox_batchMumber = new TextBox();
			this.tabControl_createProject.SuspendLayout();
			this.tabPage_choiceTestCable.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			this.tabPage_paraSetting.SuspendLayout();
			this.groupBox_nyParaSet.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_NY_Threshold).BeginInit();
			((ISupportInitialize)this.numericUpDown_NY_ACVolt).BeginInit();
			((ISupportInitialize)this.numericUpDown_NY_HoldTime).BeginInit();
			this.groupBox_jyParaSet.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_DYJY_DCRiseTime).BeginInit();
			((ISupportInitialize)this.numericUpDown_DYJY_HoldTime).BeginInit();
			((ISupportInitialize)this.numericUpDown_DYJY_DCVolt).BeginInit();
			((ISupportInitialize)this.numericUpDown_DYJY_Threshold).BeginInit();
			((ISupportInitialize)this.numericUpDown_JY_DCRiseTime).BeginInit();
			((ISupportInitialize)this.numericUpDown_JY_HoldTime).BeginInit();
			((ISupportInitialize)this.numericUpDown_JY_DCVolt).BeginInit();
			((ISupportInitialize)this.numericUpDown_JY_Threshold).BeginInit();
			this.groupBox_dtParaSet.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_DT_Current).BeginInit();
			((ISupportInitialize)this.numericUpDown_DT_Volt).BeginInit();
			((ISupportInitialize)this.numericUpDown_DT_Threshold).BeginInit();
			base.SuspendLayout();
			this.label_projectName.Anchor = AnchorStyles.Top;
			this.label_projectName.AutoSize = true;
			this.label_projectName.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(30, 22);
			this.label_projectName.Location = location;
			Padding margin = new Padding(2, 0, 2, 0);
			this.label_projectName.Margin = margin;
			this.label_projectName.Name = "label_projectName";
			System.Drawing.Size size = new System.Drawing.Size(75, 15);
			this.label_projectName.Size = size;
			this.label_projectName.TabIndex = 0;
			this.label_projectName.Text = "项目名称:";
			this.textBox_projectName.Anchor = AnchorStyles.Top;
			this.textBox_projectName.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(111, 18);
			this.textBox_projectName.Location = location2;
			Padding margin2 = new Padding(2);
			this.textBox_projectName.Margin = margin2;
			this.textBox_projectName.MaxLength = 120;
			this.textBox_projectName.Name = "textBox_projectName";
			System.Drawing.Size size2 = new System.Drawing.Size(286, 24);
			this.textBox_projectName.Size = size2;
			this.textBox_projectName.TabIndex = 0;
			this.textBox_projectName.KeyPress += new KeyPressEventHandler(this.textBox_pn_KeyPress);
			this.btnSubmit.Anchor = AnchorStyles.Bottom;
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(274, 518);
			this.btnSubmit.Location = location3;
			Padding margin3 = new Padding(2);
			this.btnSubmit.Margin = margin3;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size3 = new System.Drawing.Size(90, 24);
			this.btnSubmit.Size = size3;
			this.btnSubmit.TabIndex = 4;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(431, 518);
			this.btnQuit.Location = location4;
			Padding margin4 = new Padding(2);
			this.btnQuit.Margin = margin4;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size4 = new System.Drawing.Size(90, 24);
			this.btnQuit.Size = size4;
			this.btnQuit.TabIndex = 5;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.label_remark.Anchor = AnchorStyles.Top;
			this.label_remark.AutoSize = true;
			this.label_remark.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(30, 58);
			this.label_remark.Location = location5;
			Padding margin5 = new Padding(2, 0, 2, 0);
			this.label_remark.Margin = margin5;
			this.label_remark.Name = "label_remark";
			System.Drawing.Size size5 = new System.Drawing.Size(75, 15);
			this.label_remark.Size = size5;
			this.label_remark.TabIndex = 0;
			this.label_remark.Text = "项目备注:";
			this.textBox_Remark.Anchor = AnchorStyles.Top;
			this.textBox_Remark.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(111, 54);
			this.textBox_Remark.Location = location6;
			Padding margin6 = new Padding(2);
			this.textBox_Remark.Margin = margin6;
			this.textBox_Remark.MaxLength = 120;
			this.textBox_Remark.Name = "textBox_Remark";
			System.Drawing.Size size6 = new System.Drawing.Size(286, 24);
			this.textBox_Remark.Size = size6;
			this.textBox_Remark.TabIndex = 2;
			this.tabControl_createProject.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.tabControl_createProject.Appearance = TabAppearance.Buttons;
			this.tabControl_createProject.Controls.Add(this.tabPage_choiceTestCable);
			this.tabControl_createProject.Controls.Add(this.tabPage_paraSetting);
			this.tabControl_createProject.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Size itemSize = new System.Drawing.Size(320, 30);
			this.tabControl_createProject.ItemSize = itemSize;
			System.Drawing.Point location7 = new System.Drawing.Point(23, 93);
			this.tabControl_createProject.Location = location7;
			Padding margin7 = new Padding(2);
			this.tabControl_createProject.Margin = margin7;
			this.tabControl_createProject.Name = "tabControl_createProject";
			this.tabControl_createProject.SelectedIndex = 0;
			System.Drawing.Size size7 = new System.Drawing.Size(747, 407);
			this.tabControl_createProject.Size = size7;
			this.tabControl_createProject.SizeMode = TabSizeMode.Fixed;
			this.tabControl_createProject.TabIndex = 2;
			this.tabControl_createProject.SelectedIndexChanged += new System.EventHandler(this.tabControl_createProject_SelectedIndexChanged);
			System.Drawing.Color activeCaption = System.Drawing.SystemColors.ActiveCaption;
			this.tabPage_choiceTestCable.BackColor = activeCaption;
			this.tabPage_choiceTestCable.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage_choiceTestCable.Controls.Add(this.btnTMSM);
			this.tabPage_choiceTestCable.Controls.Add(this.groupBox1);
			this.tabPage_choiceTestCable.Controls.Add(this.label24);
			this.tabPage_choiceTestCable.Controls.Add(this.textBox_yxbcCable);
			this.tabPage_choiceTestCable.Controls.Add(this.textBox_Cable);
			this.tabPage_choiceTestCable.Controls.Add(this.label23);
			System.Drawing.Point location8 = new System.Drawing.Point(4, 34);
			this.tabPage_choiceTestCable.Location = location8;
			Padding margin8 = new Padding(2);
			this.tabPage_choiceTestCable.Margin = margin8;
			this.tabPage_choiceTestCable.Name = "tabPage_choiceTestCable";
			Padding padding = new Padding(2);
			this.tabPage_choiceTestCable.Padding = padding;
			System.Drawing.Size size8 = new System.Drawing.Size(739, 369);
			this.tabPage_choiceTestCable.Size = size8;
			this.tabPage_choiceTestCable.TabIndex = 1;
			this.tabPage_choiceTestCable.Text = "步骤1：选择被测线束";
			this.btnTMSM.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.btnTMSM.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(577, 337);
			this.btnTMSM.Location = location9;
			Padding margin9 = new Padding(2);
			this.btnTMSM.Margin = margin9;
			this.btnTMSM.Name = "btnTMSM";
			System.Drawing.Size size9 = new System.Drawing.Size(120, 24);
			this.btnTMSM.Size = size9;
			this.btnTMSM.TabIndex = 23;
			this.btnTMSM.Text = "线束条码扫描";
			this.btnTMSM.UseVisualStyleBackColor = true;
			this.btnTMSM.Click += new System.EventHandler(this.btnTMSM_Click);
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location10 = new System.Drawing.Point(18, 56);
			this.groupBox1.Location = location10;
			Padding margin10 = new Padding(2);
			this.groupBox1.Margin = margin10;
			this.groupBox1.Name = "groupBox1";
			Padding padding2 = new Padding(2);
			this.groupBox1.Padding = padding2;
			System.Drawing.Size size10 = new System.Drawing.Size(704, 271);
			this.groupBox1.Size = size10;
			this.groupBox1.TabIndex = 22;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "线束清单（点击选择被测线束）";
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			System.Drawing.Color window = System.Drawing.SystemColors.Window;
			this.dataGridView1.BackgroundColor = window;
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[]
			{
				this.Column1,
				this.Column2,
				this.Column3,
				this.Column4,
				this.Column5
			};
			this.dataGridView1.Columns.AddRange(dataGridViewColumns);
			this.dataGridView1.Dock = DockStyle.Fill;
			System.Drawing.Point location11 = new System.Drawing.Point(2, 19);
			this.dataGridView1.Location = location11;
			Padding margin11 = new Padding(2);
			this.dataGridView1.Margin = margin11;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size11 = new System.Drawing.Size(700, 250);
			this.dataGridView1.Size = size11;
			this.dataGridView1.TabIndex = 18;
			this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
			this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
			this.Column1.HeaderText = "序号";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 74;
			this.Column2.HeaderText = "线束代号";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 150;
			this.Column3.HeaderText = "接口信息";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 200;
			this.Column4.HeaderText = "芯线数量";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Width = 120;
			this.Column5.HeaderText = "备注";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.label24.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.label24.AutoSize = true;
			this.label24.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location12 = new System.Drawing.Point(37, 342);
			this.label24.Location = location12;
			Padding margin12 = new Padding(2, 0, 2, 0);
			this.label24.Margin = margin12;
			this.label24.Name = "label24";
			System.Drawing.Size size12 = new System.Drawing.Size(105, 15);
			this.label24.Size = size12;
			this.label24.TabIndex = 0;
			this.label24.Text = "已选被测线束:";
			this.textBox_yxbcCable.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Color activeCaption2 = System.Drawing.SystemColors.ActiveCaption;
			this.textBox_yxbcCable.BackColor = activeCaption2;
			this.textBox_yxbcCable.BorderStyle = BorderStyle.FixedSingle;
			this.textBox_yxbcCable.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location13 = new System.Drawing.Point(148, 338);
			this.textBox_yxbcCable.Location = location13;
			Padding margin13 = new Padding(2);
			this.textBox_yxbcCable.Margin = margin13;
			this.textBox_yxbcCable.MaxLength = 255;
			this.textBox_yxbcCable.Name = "textBox_yxbcCable";
			System.Drawing.Size size13 = new System.Drawing.Size(412, 24);
			this.textBox_yxbcCable.Size = size13;
			this.textBox_yxbcCable.TabIndex = 16;
			this.textBox_yxbcCable.TextChanged += new System.EventHandler(this.textBox_Cable_TextChanged);
			this.textBox_Cable.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_Cable.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location14 = new System.Drawing.Point(148, 19);
			this.textBox_Cable.Location = location14;
			Padding margin14 = new Padding(2);
			this.textBox_Cable.Margin = margin14;
			this.textBox_Cable.MaxLength = 120;
			this.textBox_Cable.Name = "textBox_Cable";
			System.Drawing.Size size14 = new System.Drawing.Size(549, 24);
			this.textBox_Cable.Size = size14;
			this.textBox_Cable.TabIndex = 16;
			this.textBox_Cable.TextChanged += new System.EventHandler(this.textBox_Cable_TextChanged);
			this.label23.AutoSize = true;
			this.label23.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location15 = new System.Drawing.Point(65, 23);
			this.label23.Location = location15;
			Padding margin15 = new Padding(2, 0, 2, 0);
			this.label23.Margin = margin15;
			this.label23.Name = "label23";
			System.Drawing.Size size15 = new System.Drawing.Size(75, 15);
			this.label23.Size = size15;
			this.label23.TabIndex = 0;
			this.label23.Text = "筛选条件:";
			System.Drawing.Color activeCaption3 = System.Drawing.SystemColors.ActiveCaption;
			this.tabPage_paraSetting.BackColor = activeCaption3;
			this.tabPage_paraSetting.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage_paraSetting.Controls.Add(this.groupBox_nyParaSet);
			this.tabPage_paraSetting.Controls.Add(this.groupBox_jyParaSet);
			this.tabPage_paraSetting.Controls.Add(this.groupBox_dtParaSet);
			System.Drawing.Point location16 = new System.Drawing.Point(4, 34);
			this.tabPage_paraSetting.Location = location16;
			Padding margin16 = new Padding(2);
			this.tabPage_paraSetting.Margin = margin16;
			this.tabPage_paraSetting.Name = "tabPage_paraSetting";
			Padding padding3 = new Padding(2);
			this.tabPage_paraSetting.Padding = padding3;
			System.Drawing.Size size16 = new System.Drawing.Size(739, 369);
			this.tabPage_paraSetting.Size = size16;
			this.tabPage_paraSetting.TabIndex = 0;
			this.tabPage_paraSetting.Text = "步骤2：设置固定试验参数";
			this.groupBox_nyParaSet.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_nyParaSet.Controls.Add(this.numericUpDown_NY_Threshold);
			this.groupBox_nyParaSet.Controls.Add(this.numericUpDown_NY_ACVolt);
			this.groupBox_nyParaSet.Controls.Add(this.numericUpDown_NY_HoldTime);
			this.groupBox_nyParaSet.Controls.Add(this.label_ny_jlgy);
			this.groupBox_nyParaSet.Controls.Add(this.label_ny_nybcTime);
			this.groupBox_nyParaSet.Controls.Add(this.label_ny_yz);
			this.groupBox_nyParaSet.Controls.Add(this.label_NY_HoldTime_unit);
			this.groupBox_nyParaSet.Controls.Add(this.label_NY_ACVolt_unit);
			this.groupBox_nyParaSet.Controls.Add(this.label_NY_Threshold_unit);
			System.Drawing.Point location17 = new System.Drawing.Point(18, 236);
			this.groupBox_nyParaSet.Location = location17;
			Padding margin17 = new Padding(2);
			this.groupBox_nyParaSet.Margin = margin17;
			this.groupBox_nyParaSet.Name = "groupBox_nyParaSet";
			Padding padding4 = new Padding(2);
			this.groupBox_nyParaSet.Padding = padding4;
			System.Drawing.Size size17 = new System.Drawing.Size(705, 96);
			this.groupBox_nyParaSet.Size = size17;
			this.groupBox_nyParaSet.TabIndex = 30;
			this.groupBox_nyParaSet.TabStop = false;
			this.groupBox_nyParaSet.Text = "耐压试验参数";
			this.numericUpDown_NY_Threshold.Anchor = AnchorStyles.Bottom;
			this.numericUpDown_NY_Threshold.DecimalPlaces = 2;
			this.numericUpDown_NY_Threshold.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location18 = new System.Drawing.Point(110, 28);
			this.numericUpDown_NY_Threshold.Location = location18;
			Padding margin18 = new Padding(2);
			this.numericUpDown_NY_Threshold.Margin = margin18;
			decimal maximum = new decimal(new int[]
			{
				10,
				0,
				0,
				0
			});
			this.numericUpDown_NY_Threshold.Maximum = maximum;
			this.numericUpDown_NY_Threshold.Name = "numericUpDown_NY_Threshold";
			System.Drawing.Size size18 = new System.Drawing.Size(75, 24);
			this.numericUpDown_NY_Threshold.Size = size18;
			this.numericUpDown_NY_Threshold.TabIndex = 23;
			decimal value = new decimal(new int[]
			{
				2,
				0,
				0,
				0
			});
			this.numericUpDown_NY_Threshold.Value = value;
			this.numericUpDown_NY_ACVolt.Anchor = AnchorStyles.Bottom;
			this.numericUpDown_NY_ACVolt.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			decimal increment = new decimal(new int[]
			{
				10,
				0,
				0,
				0
			});
			this.numericUpDown_NY_ACVolt.Increment = increment;
			System.Drawing.Point location19 = new System.Drawing.Point(110, 64);
			this.numericUpDown_NY_ACVolt.Location = location19;
			Padding margin19 = new Padding(2);
			this.numericUpDown_NY_ACVolt.Margin = margin19;
			decimal maximum2 = new decimal(new int[]
			{
				500,
				0,
				0,
				0
			});
			this.numericUpDown_NY_ACVolt.Maximum = maximum2;
			this.numericUpDown_NY_ACVolt.Name = "numericUpDown_NY_ACVolt";
			System.Drawing.Size size19 = new System.Drawing.Size(75, 24);
			this.numericUpDown_NY_ACVolt.Size = size19;
			this.numericUpDown_NY_ACVolt.TabIndex = 25;
			decimal value2 = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			this.numericUpDown_NY_ACVolt.Value = value2;
			this.numericUpDown_NY_HoldTime.Anchor = AnchorStyles.Bottom;
			this.numericUpDown_NY_HoldTime.DecimalPlaces = 1;
			this.numericUpDown_NY_HoldTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location20 = new System.Drawing.Point(477, 28);
			this.numericUpDown_NY_HoldTime.Location = location20;
			Padding margin20 = new Padding(2);
			this.numericUpDown_NY_HoldTime.Margin = margin20;
			decimal maximum3 = new decimal(new int[]
			{
				120,
				0,
				0,
				0
			});
			this.numericUpDown_NY_HoldTime.Maximum = maximum3;
			decimal minimum = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_NY_HoldTime.Minimum = minimum;
			this.numericUpDown_NY_HoldTime.Name = "numericUpDown_NY_HoldTime";
			System.Drawing.Size size20 = new System.Drawing.Size(75, 24);
			this.numericUpDown_NY_HoldTime.Size = size20;
			this.numericUpDown_NY_HoldTime.TabIndex = 24;
			decimal value3 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_NY_HoldTime.Value = value3;
			this.label_ny_jlgy.Anchor = AnchorStyles.Bottom;
			this.label_ny_jlgy.AutoSize = true;
			this.label_ny_jlgy.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location21 = new System.Drawing.Point(29, 68);
			this.label_ny_jlgy.Location = location21;
			Padding margin21 = new Padding(2, 0, 2, 0);
			this.label_ny_jlgy.Margin = margin21;
			this.label_ny_jlgy.Name = "label_ny_jlgy";
			System.Drawing.Size size21 = new System.Drawing.Size(75, 15);
			this.label_ny_jlgy.Size = size21;
			this.label_ny_jlgy.TabIndex = 20;
			this.label_ny_jlgy.Text = "耐压电压:";
			this.label_ny_nybcTime.Anchor = AnchorStyles.Bottom;
			this.label_ny_nybcTime.AutoSize = true;
			this.label_ny_nybcTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location22 = new System.Drawing.Point(368, 32);
			this.label_ny_nybcTime.Location = location22;
			Padding margin22 = new Padding(2, 0, 2, 0);
			this.label_ny_nybcTime.Margin = margin22;
			this.label_ny_nybcTime.Name = "label_ny_nybcTime";
			System.Drawing.Size size22 = new System.Drawing.Size(105, 15);
			this.label_ny_nybcTime.Size = size22;
			this.label_ny_nybcTime.TabIndex = 21;
			this.label_ny_nybcTime.Text = "耐压保持时间:";
			this.label_ny_yz.Anchor = AnchorStyles.Bottom;
			this.label_ny_yz.AutoSize = true;
			this.label_ny_yz.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location23 = new System.Drawing.Point(29, 32);
			this.label_ny_yz.Location = location23;
			Padding margin23 = new Padding(2, 0, 2, 0);
			this.label_ny_yz.Margin = margin23;
			this.label_ny_yz.Name = "label_ny_yz";
			System.Drawing.Size size23 = new System.Drawing.Size(75, 15);
			this.label_ny_yz.Size = size23;
			this.label_ny_yz.TabIndex = 19;
			this.label_ny_yz.Text = "耐压阈值:";
			this.label_NY_HoldTime_unit.Anchor = AnchorStyles.Bottom;
			this.label_NY_HoldTime_unit.AutoSize = true;
			this.label_NY_HoldTime_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location24 = new System.Drawing.Point(559, 32);
			this.label_NY_HoldTime_unit.Location = location24;
			Padding margin24 = new Padding(2, 0, 2, 0);
			this.label_NY_HoldTime_unit.Margin = margin24;
			this.label_NY_HoldTime_unit.Name = "label_NY_HoldTime_unit";
			System.Drawing.Size size24 = new System.Drawing.Size(103, 15);
			this.label_NY_HoldTime_unit.Size = size24;
			this.label_NY_HoldTime_unit.TabIndex = 18;
			this.label_NY_HoldTime_unit.Text = "S  (1.0~120)";
			this.label_NY_ACVolt_unit.Anchor = AnchorStyles.Bottom;
			this.label_NY_ACVolt_unit.AutoSize = true;
			this.label_NY_ACVolt_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location25 = new System.Drawing.Point(191, 68);
			this.label_NY_ACVolt_unit.Location = location25;
			Padding margin25 = new Padding(2, 0, 2, 0);
			this.label_NY_ACVolt_unit.Margin = margin25;
			this.label_NY_ACVolt_unit.Name = "label_NY_ACVolt_unit";
			System.Drawing.Size size25 = new System.Drawing.Size(111, 15);
			this.label_NY_ACVolt_unit.Size = size25;
			this.label_NY_ACVolt_unit.TabIndex = 22;
			this.label_NY_ACVolt_unit.Text = "VAC (100~500)";
			this.label_NY_Threshold_unit.Anchor = AnchorStyles.Bottom;
			this.label_NY_Threshold_unit.AutoSize = true;
			this.label_NY_Threshold_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location26 = new System.Drawing.Point(191, 32);
			this.label_NY_Threshold_unit.Location = location26;
			Padding margin26 = new Padding(2, 0, 2, 0);
			this.label_NY_Threshold_unit.Margin = margin26;
			this.label_NY_Threshold_unit.Name = "label_NY_Threshold_unit";
			System.Drawing.Size size26 = new System.Drawing.Size(103, 15);
			this.label_NY_Threshold_unit.Size = size26;
			this.label_NY_Threshold_unit.TabIndex = 26;
			this.label_NY_Threshold_unit.Text = "mA  (0.1~10)";
			this.groupBox_jyParaSet.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_jyParaSet.Controls.Add(this.label_DYJY_DCRiseTime_unit);
			this.groupBox_jyParaSet.Controls.Add(this.label_DYJY_HoldTime_unit);
			this.groupBox_jyParaSet.Controls.Add(this.label_DYJY_DCVolt_unit);
			this.groupBox_jyParaSet.Controls.Add(this.label_DYJY_Threshold_unit);
			this.groupBox_jyParaSet.Controls.Add(this.numericUpDown_DYJY_DCRiseTime);
			this.groupBox_jyParaSet.Controls.Add(this.numericUpDown_DYJY_HoldTime);
			this.groupBox_jyParaSet.Controls.Add(this.numericUpDown_DYJY_DCVolt);
			this.groupBox_jyParaSet.Controls.Add(this.numericUpDown_DYJY_Threshold);
			this.groupBox_jyParaSet.Controls.Add(this.label_dyjy_zlssTime);
			this.groupBox_jyParaSet.Controls.Add(this.label_dyjy_jybcTime);
			this.groupBox_jyParaSet.Controls.Add(this.label_dyjy_zlgy);
			this.groupBox_jyParaSet.Controls.Add(this.label_dyjy_yz);
			this.groupBox_jyParaSet.Controls.Add(this.label_JY_DCRiseTime_unit);
			this.groupBox_jyParaSet.Controls.Add(this.label_JY_HoldTime_unit);
			this.groupBox_jyParaSet.Controls.Add(this.radioButton_jy_LowVolt);
			this.groupBox_jyParaSet.Controls.Add(this.label_JY_DCVolt_unit);
			this.groupBox_jyParaSet.Controls.Add(this.label_JY_Threshold_unit);
			this.groupBox_jyParaSet.Controls.Add(this.numericUpDown_JY_DCRiseTime);
			this.groupBox_jyParaSet.Controls.Add(this.numericUpDown_JY_HoldTime);
			this.groupBox_jyParaSet.Controls.Add(this.radioButton_jy_HighVolt);
			this.groupBox_jyParaSet.Controls.Add(this.numericUpDown_JY_DCVolt);
			this.groupBox_jyParaSet.Controls.Add(this.label_jy_TestMode);
			this.groupBox_jyParaSet.Controls.Add(this.numericUpDown_JY_Threshold);
			this.groupBox_jyParaSet.Controls.Add(this.label_jy_zlssTime);
			this.groupBox_jyParaSet.Controls.Add(this.label_jy_jybcTime);
			this.groupBox_jyParaSet.Controls.Add(this.label_jy_zlgy);
			this.groupBox_jyParaSet.Controls.Add(this.label_jy_yz);
			System.Drawing.Point location27 = new System.Drawing.Point(18, 98);
			this.groupBox_jyParaSet.Location = location27;
			Padding margin27 = new Padding(2);
			this.groupBox_jyParaSet.Margin = margin27;
			this.groupBox_jyParaSet.Name = "groupBox_jyParaSet";
			Padding padding5 = new Padding(2);
			this.groupBox_jyParaSet.Padding = padding5;
			System.Drawing.Size size27 = new System.Drawing.Size(705, 128);
			this.groupBox_jyParaSet.Size = size27;
			this.groupBox_jyParaSet.TabIndex = 29;
			this.groupBox_jyParaSet.TabStop = false;
			this.groupBox_jyParaSet.Text = "绝缘试验参数";
			this.label_DYJY_DCRiseTime_unit.Anchor = AnchorStyles.Bottom;
			this.label_DYJY_DCRiseTime_unit.AutoSize = true;
			this.label_DYJY_DCRiseTime_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location28 = new System.Drawing.Point(558, 96);
			this.label_DYJY_DCRiseTime_unit.Location = location28;
			Padding margin28 = new Padding(2, 0, 2, 0);
			this.label_DYJY_DCRiseTime_unit.Margin = margin28;
			this.label_DYJY_DCRiseTime_unit.Name = "label_DYJY_DCRiseTime_unit";
			System.Drawing.Size size28 = new System.Drawing.Size(103, 15);
			this.label_DYJY_DCRiseTime_unit.Size = size28;
			this.label_DYJY_DCRiseTime_unit.TabIndex = 50;
			this.label_DYJY_DCRiseTime_unit.Text = "S  (0.2~120)";
			this.label_DYJY_DCRiseTime_unit.Visible = false;
			this.label_DYJY_HoldTime_unit.Anchor = AnchorStyles.Bottom;
			this.label_DYJY_HoldTime_unit.AutoSize = true;
			this.label_DYJY_HoldTime_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location29 = new System.Drawing.Point(558, 60);
			this.label_DYJY_HoldTime_unit.Location = location29;
			Padding margin29 = new Padding(2, 0, 2, 0);
			this.label_DYJY_HoldTime_unit.Margin = margin29;
			this.label_DYJY_HoldTime_unit.Name = "label_DYJY_HoldTime_unit";
			System.Drawing.Size size29 = new System.Drawing.Size(119, 15);
			this.label_DYJY_HoldTime_unit.Size = size29;
			this.label_DYJY_HoldTime_unit.TabIndex = 51;
			this.label_DYJY_HoldTime_unit.Text = "S  (0.001~120)";
			this.label_DYJY_HoldTime_unit.Visible = false;
			this.label_DYJY_DCVolt_unit.Anchor = AnchorStyles.Bottom;
			this.label_DYJY_DCVolt_unit.AutoSize = true;
			this.label_DYJY_DCVolt_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location30 = new System.Drawing.Point(191, 96);
			this.label_DYJY_DCVolt_unit.Location = location30;
			Padding margin30 = new Padding(2, 0, 2, 0);
			this.label_DYJY_DCVolt_unit.Margin = margin30;
			this.label_DYJY_DCVolt_unit.Name = "label_DYJY_DCVolt_unit";
			System.Drawing.Size size30 = new System.Drawing.Size(111, 15);
			this.label_DYJY_DCVolt_unit.Size = size30;
			this.label_DYJY_DCVolt_unit.TabIndex = 49;
			this.label_DYJY_DCVolt_unit.Text = "VDC (0.05~30)";
			this.label_DYJY_DCVolt_unit.Visible = false;
			this.label_DYJY_Threshold_unit.Anchor = AnchorStyles.Bottom;
			this.label_DYJY_Threshold_unit.AutoSize = true;
			this.label_DYJY_Threshold_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location31 = new System.Drawing.Point(191, 60);
			this.label_DYJY_Threshold_unit.Location = location31;
			Padding margin31 = new Padding(2, 0, 2, 0);
			this.label_DYJY_Threshold_unit.Margin = margin31;
			this.label_DYJY_Threshold_unit.Name = "label_DYJY_Threshold_unit";
			System.Drawing.Size size31 = new System.Drawing.Size(102, 15);
			this.label_DYJY_Threshold_unit.Size = size31;
			this.label_DYJY_Threshold_unit.TabIndex = 48;
			this.label_DYJY_Threshold_unit.Text = "MΩ (1~1000)";
			this.label_DYJY_Threshold_unit.Visible = false;
			this.numericUpDown_DYJY_DCRiseTime.Anchor = AnchorStyles.Bottom;
			this.numericUpDown_DYJY_DCRiseTime.DecimalPlaces = 1;
			this.numericUpDown_DYJY_DCRiseTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location32 = new System.Drawing.Point(477, 92);
			this.numericUpDown_DYJY_DCRiseTime.Location = location32;
			Padding margin32 = new Padding(2);
			this.numericUpDown_DYJY_DCRiseTime.Margin = margin32;
			decimal maximum4 = new decimal(new int[]
			{
				120,
				0,
				0,
				0
			});
			this.numericUpDown_DYJY_DCRiseTime.Maximum = maximum4;
			this.numericUpDown_DYJY_DCRiseTime.Name = "numericUpDown_DYJY_DCRiseTime";
			System.Drawing.Size size32 = new System.Drawing.Size(75, 24);
			this.numericUpDown_DYJY_DCRiseTime.Size = size32;
			this.numericUpDown_DYJY_DCRiseTime.TabIndex = 45;
			decimal value4 = new decimal(new int[]
			{
				2,
				0,
				0,
				65536
			});
			this.numericUpDown_DYJY_DCRiseTime.Value = value4;
			this.numericUpDown_DYJY_DCRiseTime.Visible = false;
			this.numericUpDown_DYJY_HoldTime.Anchor = AnchorStyles.Bottom;
			this.numericUpDown_DYJY_HoldTime.DecimalPlaces = 3;
			this.numericUpDown_DYJY_HoldTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location33 = new System.Drawing.Point(477, 56);
			this.numericUpDown_DYJY_HoldTime.Location = location33;
			Padding margin33 = new Padding(2);
			this.numericUpDown_DYJY_HoldTime.Margin = margin33;
			decimal maximum5 = new decimal(new int[]
			{
				120,
				0,
				0,
				0
			});
			this.numericUpDown_DYJY_HoldTime.Maximum = maximum5;
			decimal minimum2 = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.numericUpDown_DYJY_HoldTime.Minimum = minimum2;
			this.numericUpDown_DYJY_HoldTime.Name = "numericUpDown_DYJY_HoldTime";
			System.Drawing.Size size33 = new System.Drawing.Size(75, 24);
			this.numericUpDown_DYJY_HoldTime.Size = size33;
			this.numericUpDown_DYJY_HoldTime.TabIndex = 42;
			decimal value5 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_DYJY_HoldTime.Value = value5;
			this.numericUpDown_DYJY_HoldTime.Visible = false;
			this.numericUpDown_DYJY_DCVolt.Anchor = AnchorStyles.Bottom;
			this.numericUpDown_DYJY_DCVolt.DecimalPlaces = 2;
			this.numericUpDown_DYJY_DCVolt.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			decimal increment2 = new decimal(new int[]
			{
				5,
				0,
				0,
				131072
			});
			this.numericUpDown_DYJY_DCVolt.Increment = increment2;
			System.Drawing.Point location34 = new System.Drawing.Point(110, 92);
			this.numericUpDown_DYJY_DCVolt.Location = location34;
			Padding margin34 = new Padding(2);
			this.numericUpDown_DYJY_DCVolt.Margin = margin34;
			this.numericUpDown_DYJY_DCVolt.Name = "numericUpDown_DYJY_DCVolt";
			System.Drawing.Size size34 = new System.Drawing.Size(75, 24);
			this.numericUpDown_DYJY_DCVolt.Size = size34;
			this.numericUpDown_DYJY_DCVolt.TabIndex = 43;
			decimal value6 = new decimal(new int[]
			{
				30,
				0,
				0,
				0
			});
			this.numericUpDown_DYJY_DCVolt.Value = value6;
			this.numericUpDown_DYJY_DCVolt.Visible = false;
			this.numericUpDown_DYJY_Threshold.Anchor = AnchorStyles.Bottom;
			this.numericUpDown_DYJY_Threshold.DecimalPlaces = 2;
			this.numericUpDown_DYJY_Threshold.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location35 = new System.Drawing.Point(110, 56);
			this.numericUpDown_DYJY_Threshold.Location = location35;
			Padding margin35 = new Padding(2);
			this.numericUpDown_DYJY_Threshold.Margin = margin35;
			decimal maximum6 = new decimal(new int[]
			{
				1000,
				0,
				0,
				0
			});
			this.numericUpDown_DYJY_Threshold.Maximum = maximum6;
			this.numericUpDown_DYJY_Threshold.Name = "numericUpDown_DYJY_Threshold";
			System.Drawing.Size size35 = new System.Drawing.Size(75, 24);
			this.numericUpDown_DYJY_Threshold.Size = size35;
			this.numericUpDown_DYJY_Threshold.TabIndex = 41;
			decimal value7 = new decimal(new int[]
			{
				10,
				0,
				0,
				0
			});
			this.numericUpDown_DYJY_Threshold.Value = value7;
			this.numericUpDown_DYJY_Threshold.Visible = false;
			this.label_dyjy_zlssTime.Anchor = AnchorStyles.Bottom;
			this.label_dyjy_zlssTime.AutoSize = true;
			this.label_dyjy_zlssTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location36 = new System.Drawing.Point(368, 96);
			this.label_dyjy_zlssTime.Location = location36;
			Padding margin36 = new Padding(2, 0, 2, 0);
			this.label_dyjy_zlssTime.Margin = margin36;
			this.label_dyjy_zlssTime.Name = "label_dyjy_zlssTime";
			System.Drawing.Size size36 = new System.Drawing.Size(105, 15);
			this.label_dyjy_zlssTime.Size = size36;
			this.label_dyjy_zlssTime.TabIndex = 44;
			this.label_dyjy_zlssTime.Text = "绝缘上升时间:";
			this.label_dyjy_zlssTime.Visible = false;
			this.label_dyjy_jybcTime.Anchor = AnchorStyles.Bottom;
			this.label_dyjy_jybcTime.AutoSize = true;
			this.label_dyjy_jybcTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location37 = new System.Drawing.Point(368, 60);
			this.label_dyjy_jybcTime.Location = location37;
			Padding margin37 = new Padding(2, 0, 2, 0);
			this.label_dyjy_jybcTime.Margin = margin37;
			this.label_dyjy_jybcTime.Name = "label_dyjy_jybcTime";
			System.Drawing.Size size37 = new System.Drawing.Size(105, 15);
			this.label_dyjy_jybcTime.Size = size37;
			this.label_dyjy_jybcTime.TabIndex = 40;
			this.label_dyjy_jybcTime.Text = "绝缘保持时间:";
			this.label_dyjy_jybcTime.Visible = false;
			this.label_dyjy_zlgy.Anchor = AnchorStyles.Bottom;
			this.label_dyjy_zlgy.AutoSize = true;
			this.label_dyjy_zlgy.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location38 = new System.Drawing.Point(29, 96);
			this.label_dyjy_zlgy.Location = location38;
			Padding margin38 = new Padding(2, 0, 2, 0);
			this.label_dyjy_zlgy.Margin = margin38;
			this.label_dyjy_zlgy.Name = "label_dyjy_zlgy";
			System.Drawing.Size size38 = new System.Drawing.Size(75, 15);
			this.label_dyjy_zlgy.Size = size38;
			this.label_dyjy_zlgy.TabIndex = 46;
			this.label_dyjy_zlgy.Text = "绝缘电压:";
			this.label_dyjy_zlgy.Visible = false;
			this.label_dyjy_yz.Anchor = AnchorStyles.Bottom;
			this.label_dyjy_yz.AutoSize = true;
			this.label_dyjy_yz.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location39 = new System.Drawing.Point(29, 60);
			this.label_dyjy_yz.Location = location39;
			Padding margin39 = new Padding(2, 0, 2, 0);
			this.label_dyjy_yz.Margin = margin39;
			this.label_dyjy_yz.Name = "label_dyjy_yz";
			System.Drawing.Size size39 = new System.Drawing.Size(75, 15);
			this.label_dyjy_yz.Size = size39;
			this.label_dyjy_yz.TabIndex = 47;
			this.label_dyjy_yz.Text = "绝缘阈值:";
			this.label_dyjy_yz.Visible = false;
			this.label_JY_DCRiseTime_unit.Anchor = AnchorStyles.Bottom;
			this.label_JY_DCRiseTime_unit.AutoSize = true;
			this.label_JY_DCRiseTime_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location40 = new System.Drawing.Point(558, 96);
			this.label_JY_DCRiseTime_unit.Location = location40;
			Padding margin40 = new Padding(2, 0, 2, 0);
			this.label_JY_DCRiseTime_unit.Margin = margin40;
			this.label_JY_DCRiseTime_unit.Name = "label_JY_DCRiseTime_unit";
			System.Drawing.Size size40 = new System.Drawing.Size(103, 15);
			this.label_JY_DCRiseTime_unit.Size = size40;
			this.label_JY_DCRiseTime_unit.TabIndex = 38;
			this.label_JY_DCRiseTime_unit.Text = "S  (0.2~120)";
			this.label_JY_DCRiseTime_unit.Visible = false;
			this.label_JY_HoldTime_unit.Anchor = AnchorStyles.Bottom;
			this.label_JY_HoldTime_unit.AutoSize = true;
			this.label_JY_HoldTime_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location41 = new System.Drawing.Point(558, 60);
			this.label_JY_HoldTime_unit.Location = location41;
			Padding margin41 = new Padding(2, 0, 2, 0);
			this.label_JY_HoldTime_unit.Margin = margin41;
			this.label_JY_HoldTime_unit.Name = "label_JY_HoldTime_unit";
			System.Drawing.Size size41 = new System.Drawing.Size(103, 15);
			this.label_JY_HoldTime_unit.Size = size41;
			this.label_JY_HoldTime_unit.TabIndex = 39;
			this.label_JY_HoldTime_unit.Text = "S  (0.5~120)";
			this.radioButton_jy_LowVolt.Anchor = AnchorStyles.Top;
			this.radioButton_jy_LowVolt.AutoSize = true;
			this.radioButton_jy_LowVolt.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location42 = new System.Drawing.Point(215, 22);
			this.radioButton_jy_LowVolt.Location = location42;
			Padding margin42 = new Padding(2);
			this.radioButton_jy_LowVolt.Margin = margin42;
			this.radioButton_jy_LowVolt.Name = "radioButton_jy_LowVolt";
			System.Drawing.Size size42 = new System.Drawing.Size(85, 19);
			this.radioButton_jy_LowVolt.Size = size42;
			this.radioButton_jy_LowVolt.TabIndex = 14;
			this.radioButton_jy_LowVolt.Text = "低压绝缘";
			this.radioButton_jy_LowVolt.UseVisualStyleBackColor = true;
			this.radioButton_jy_LowVolt.Visible = false;
			this.radioButton_jy_LowVolt.CheckedChanged += new System.EventHandler(this.radioButton_jy_LowVolt_CheckedChanged);
			this.label_JY_DCVolt_unit.Anchor = AnchorStyles.Bottom;
			this.label_JY_DCVolt_unit.AutoSize = true;
			this.label_JY_DCVolt_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location43 = new System.Drawing.Point(191, 96);
			this.label_JY_DCVolt_unit.Location = location43;
			Padding margin43 = new Padding(2, 0, 2, 0);
			this.label_JY_DCVolt_unit.Margin = margin43;
			this.label_JY_DCVolt_unit.Name = "label_JY_DCVolt_unit";
			System.Drawing.Size size43 = new System.Drawing.Size(111, 15);
			this.label_JY_DCVolt_unit.Size = size43;
			this.label_JY_DCVolt_unit.TabIndex = 37;
			this.label_JY_DCVolt_unit.Text = "V   (100~500)";
			this.label_JY_Threshold_unit.Anchor = AnchorStyles.Bottom;
			this.label_JY_Threshold_unit.AutoSize = true;
			this.label_JY_Threshold_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location44 = new System.Drawing.Point(191, 60);
			this.label_JY_Threshold_unit.Location = location44;
			Padding margin44 = new Padding(2, 0, 2, 0);
			this.label_JY_Threshold_unit.Margin = margin44;
			this.label_JY_Threshold_unit.Name = "label_JY_Threshold_unit";
			System.Drawing.Size size44 = new System.Drawing.Size(110, 15);
			this.label_JY_Threshold_unit.Size = size44;
			this.label_JY_Threshold_unit.TabIndex = 36;
			this.label_JY_Threshold_unit.Text = "MΩ (10~1000)";
			this.numericUpDown_JY_DCRiseTime.Anchor = AnchorStyles.Bottom;
			this.numericUpDown_JY_DCRiseTime.DecimalPlaces = 1;
			this.numericUpDown_JY_DCRiseTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location45 = new System.Drawing.Point(477, 92);
			this.numericUpDown_JY_DCRiseTime.Location = location45;
			Padding margin45 = new Padding(2);
			this.numericUpDown_JY_DCRiseTime.Margin = margin45;
			decimal maximum7 = new decimal(new int[]
			{
				120,
				0,
				0,
				0
			});
			this.numericUpDown_JY_DCRiseTime.Maximum = maximum7;
			this.numericUpDown_JY_DCRiseTime.Name = "numericUpDown_JY_DCRiseTime";
			System.Drawing.Size size45 = new System.Drawing.Size(75, 24);
			this.numericUpDown_JY_DCRiseTime.Size = size45;
			this.numericUpDown_JY_DCRiseTime.TabIndex = 33;
			decimal value8 = new decimal(new int[]
			{
				2,
				0,
				0,
				65536
			});
			this.numericUpDown_JY_DCRiseTime.Value = value8;
			this.numericUpDown_JY_DCRiseTime.Visible = false;
			this.numericUpDown_JY_HoldTime.Anchor = AnchorStyles.Bottom;
			this.numericUpDown_JY_HoldTime.DecimalPlaces = 3;
			this.numericUpDown_JY_HoldTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location46 = new System.Drawing.Point(477, 56);
			this.numericUpDown_JY_HoldTime.Location = location46;
			Padding margin46 = new Padding(2);
			this.numericUpDown_JY_HoldTime.Margin = margin46;
			decimal maximum8 = new decimal(new int[]
			{
				120,
				0,
				0,
				0
			});
			this.numericUpDown_JY_HoldTime.Maximum = maximum8;
			decimal minimum3 = new decimal(new int[]
			{
				5,
				0,
				0,
				65536
			});
			this.numericUpDown_JY_HoldTime.Minimum = minimum3;
			this.numericUpDown_JY_HoldTime.Name = "numericUpDown_JY_HoldTime";
			System.Drawing.Size size46 = new System.Drawing.Size(75, 24);
			this.numericUpDown_JY_HoldTime.Size = size46;
			this.numericUpDown_JY_HoldTime.TabIndex = 30;
			decimal value9 = new decimal(new int[]
			{
				5,
				0,
				0,
				65536
			});
			this.numericUpDown_JY_HoldTime.Value = value9;
			this.radioButton_jy_HighVolt.Anchor = AnchorStyles.Top;
			this.radioButton_jy_HighVolt.AutoSize = true;
			this.radioButton_jy_HighVolt.Checked = true;
			this.radioButton_jy_HighVolt.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location47 = new System.Drawing.Point(111, 22);
			this.radioButton_jy_HighVolt.Location = location47;
			Padding margin47 = new Padding(2);
			this.radioButton_jy_HighVolt.Margin = margin47;
			this.radioButton_jy_HighVolt.Name = "radioButton_jy_HighVolt";
			System.Drawing.Size size47 = new System.Drawing.Size(85, 19);
			this.radioButton_jy_HighVolt.Size = size47;
			this.radioButton_jy_HighVolt.TabIndex = 15;
			this.radioButton_jy_HighVolt.TabStop = true;
			this.radioButton_jy_HighVolt.Text = "高压绝缘";
			this.radioButton_jy_HighVolt.UseVisualStyleBackColor = true;
			this.radioButton_jy_HighVolt.Visible = false;
			this.numericUpDown_JY_DCVolt.Anchor = AnchorStyles.Bottom;
			this.numericUpDown_JY_DCVolt.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location48 = new System.Drawing.Point(110, 92);
			this.numericUpDown_JY_DCVolt.Location = location48;
			Padding margin48 = new Padding(2);
			this.numericUpDown_JY_DCVolt.Margin = margin48;
			decimal maximum9 = new decimal(new int[]
			{
				1500,
				0,
				0,
				0
			});
			this.numericUpDown_JY_DCVolt.Maximum = maximum9;
			this.numericUpDown_JY_DCVolt.Name = "numericUpDown_JY_DCVolt";
			System.Drawing.Size size48 = new System.Drawing.Size(75, 24);
			this.numericUpDown_JY_DCVolt.Size = size48;
			this.numericUpDown_JY_DCVolt.TabIndex = 31;
			decimal value10 = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			this.numericUpDown_JY_DCVolt.Value = value10;
			this.label_jy_TestMode.Anchor = AnchorStyles.Top;
			this.label_jy_TestMode.AutoSize = true;
			this.label_jy_TestMode.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location49 = new System.Drawing.Point(29, 24);
			this.label_jy_TestMode.Location = location49;
			Padding margin49 = new Padding(2, 0, 2, 0);
			this.label_jy_TestMode.Margin = margin49;
			this.label_jy_TestMode.Name = "label_jy_TestMode";
			System.Drawing.Size size49 = new System.Drawing.Size(75, 15);
			this.label_jy_TestMode.Size = size49;
			this.label_jy_TestMode.TabIndex = 13;
			this.label_jy_TestMode.Text = "试验模式:";
			this.label_jy_TestMode.Visible = false;
			this.numericUpDown_JY_Threshold.Anchor = AnchorStyles.Bottom;
			this.numericUpDown_JY_Threshold.DecimalPlaces = 2;
			this.numericUpDown_JY_Threshold.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location50 = new System.Drawing.Point(110, 56);
			this.numericUpDown_JY_Threshold.Location = location50;
			Padding margin50 = new Padding(2);
			this.numericUpDown_JY_Threshold.Margin = margin50;
			decimal maximum10 = new decimal(new int[]
			{
				1000,
				0,
				0,
				0
			});
			this.numericUpDown_JY_Threshold.Maximum = maximum10;
			this.numericUpDown_JY_Threshold.Name = "numericUpDown_JY_Threshold";
			System.Drawing.Size size50 = new System.Drawing.Size(75, 24);
			this.numericUpDown_JY_Threshold.Size = size50;
			this.numericUpDown_JY_Threshold.TabIndex = 29;
			decimal value11 = new decimal(new int[]
			{
				20,
				0,
				0,
				0
			});
			this.numericUpDown_JY_Threshold.Value = value11;
			this.label_jy_zlssTime.Anchor = AnchorStyles.Bottom;
			this.label_jy_zlssTime.AutoSize = true;
			this.label_jy_zlssTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location51 = new System.Drawing.Point(368, 96);
			this.label_jy_zlssTime.Location = location51;
			Padding margin51 = new Padding(2, 0, 2, 0);
			this.label_jy_zlssTime.Margin = margin51;
			this.label_jy_zlssTime.Name = "label_jy_zlssTime";
			System.Drawing.Size size51 = new System.Drawing.Size(105, 15);
			this.label_jy_zlssTime.Size = size51;
			this.label_jy_zlssTime.TabIndex = 32;
			this.label_jy_zlssTime.Text = "绝缘上升时间:";
			this.label_jy_zlssTime.Visible = false;
			this.label_jy_jybcTime.Anchor = AnchorStyles.Bottom;
			this.label_jy_jybcTime.AutoSize = true;
			this.label_jy_jybcTime.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location52 = new System.Drawing.Point(368, 60);
			this.label_jy_jybcTime.Location = location52;
			Padding margin52 = new Padding(2, 0, 2, 0);
			this.label_jy_jybcTime.Margin = margin52;
			this.label_jy_jybcTime.Name = "label_jy_jybcTime";
			System.Drawing.Size size52 = new System.Drawing.Size(105, 15);
			this.label_jy_jybcTime.Size = size52;
			this.label_jy_jybcTime.TabIndex = 28;
			this.label_jy_jybcTime.Text = "绝缘保持时间:";
			this.label_jy_zlgy.Anchor = AnchorStyles.Bottom;
			this.label_jy_zlgy.AutoSize = true;
			this.label_jy_zlgy.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location53 = new System.Drawing.Point(29, 96);
			this.label_jy_zlgy.Location = location53;
			Padding margin53 = new Padding(2, 0, 2, 0);
			this.label_jy_zlgy.Margin = margin53;
			this.label_jy_zlgy.Name = "label_jy_zlgy";
			System.Drawing.Size size53 = new System.Drawing.Size(75, 15);
			this.label_jy_zlgy.Size = size53;
			this.label_jy_zlgy.TabIndex = 34;
			this.label_jy_zlgy.Text = "绝缘电压:";
			this.label_jy_yz.Anchor = AnchorStyles.Bottom;
			this.label_jy_yz.AutoSize = true;
			this.label_jy_yz.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location54 = new System.Drawing.Point(29, 60);
			this.label_jy_yz.Location = location54;
			Padding margin54 = new Padding(2, 0, 2, 0);
			this.label_jy_yz.Margin = margin54;
			this.label_jy_yz.Name = "label_jy_yz";
			System.Drawing.Size size54 = new System.Drawing.Size(75, 15);
			this.label_jy_yz.Size = size54;
			this.label_jy_yz.TabIndex = 35;
			this.label_jy_yz.Text = "绝缘阈值:";
			this.groupBox_dtParaSet.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_dtParaSet.Controls.Add(this.numericUpDown_DT_Current);
			this.groupBox_dtParaSet.Controls.Add(this.label_DT_Volt_unit);
			this.groupBox_dtParaSet.Controls.Add(this.numericUpDown_DT_Volt);
			this.groupBox_dtParaSet.Controls.Add(this.label_dt_dy);
			this.groupBox_dtParaSet.Controls.Add(this.label_dt_yz);
			this.groupBox_dtParaSet.Controls.Add(this.label_dt_dl);
			this.groupBox_dtParaSet.Controls.Add(this.numericUpDown_DT_Threshold);
			this.groupBox_dtParaSet.Controls.Add(this.label_DT_Current_unit);
			this.groupBox_dtParaSet.Controls.Add(this.label_DT_Threshold_unit);
			System.Drawing.Point location55 = new System.Drawing.Point(18, 15);
			this.groupBox_dtParaSet.Location = location55;
			Padding margin55 = new Padding(2);
			this.groupBox_dtParaSet.Margin = margin55;
			this.groupBox_dtParaSet.Name = "groupBox_dtParaSet";
			Padding padding6 = new Padding(2);
			this.groupBox_dtParaSet.Padding = padding6;
			System.Drawing.Size size55 = new System.Drawing.Size(705, 72);
			this.groupBox_dtParaSet.Size = size55;
			this.groupBox_dtParaSet.TabIndex = 28;
			this.groupBox_dtParaSet.TabStop = false;
			this.groupBox_dtParaSet.Text = "导通试验参数";
			this.numericUpDown_DT_Current.Anchor = AnchorStyles.Bottom;
			this.numericUpDown_DT_Current.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location56 = new System.Drawing.Point(477, 49);
			this.numericUpDown_DT_Current.Location = location56;
			Padding margin56 = new Padding(2);
			this.numericUpDown_DT_Current.Margin = margin56;
			decimal maximum11 = new decimal(new int[]
			{
				2000,
				0,
				0,
				0
			});
			this.numericUpDown_DT_Current.Maximum = maximum11;
			this.numericUpDown_DT_Current.Name = "numericUpDown_DT_Current";
			System.Drawing.Size size56 = new System.Drawing.Size(75, 24);
			this.numericUpDown_DT_Current.Size = size56;
			this.numericUpDown_DT_Current.TabIndex = 23;
			decimal value12 = new decimal(new int[]
			{
				2000,
				0,
				0,
				0
			});
			this.numericUpDown_DT_Current.Value = value12;
			this.numericUpDown_DT_Current.Visible = false;
			this.label_DT_Volt_unit.Anchor = AnchorStyles.Bottom;
			this.label_DT_Volt_unit.AutoSize = true;
			this.label_DT_Volt_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location57 = new System.Drawing.Point(191, 53);
			this.label_DT_Volt_unit.Location = location57;
			Padding margin57 = new Padding(2, 0, 2, 0);
			this.label_DT_Volt_unit.Margin = margin57;
			this.label_DT_Volt_unit.Name = "label_DT_Volt_unit";
			System.Drawing.Size size57 = new System.Drawing.Size(111, 15);
			this.label_DT_Volt_unit.Size = size57;
			this.label_DT_Volt_unit.TabIndex = 42;
			this.label_DT_Volt_unit.Text = "VDC (0.01~30)";
			this.label_DT_Volt_unit.Visible = false;
			this.numericUpDown_DT_Volt.Anchor = AnchorStyles.Bottom;
			this.numericUpDown_DT_Volt.DecimalPlaces = 2;
			this.numericUpDown_DT_Volt.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location58 = new System.Drawing.Point(110, 49);
			this.numericUpDown_DT_Volt.Location = location58;
			Padding margin58 = new Padding(2);
			this.numericUpDown_DT_Volt.Margin = margin58;
			decimal maximum12 = new decimal(new int[]
			{
				50,
				0,
				0,
				0
			});
			this.numericUpDown_DT_Volt.Maximum = maximum12;
			this.numericUpDown_DT_Volt.Name = "numericUpDown_DT_Volt";
			System.Drawing.Size size58 = new System.Drawing.Size(75, 24);
			this.numericUpDown_DT_Volt.Size = size58;
			this.numericUpDown_DT_Volt.TabIndex = 40;
			decimal value13 = new decimal(new int[]
			{
				25,
				0,
				0,
				65536
			});
			this.numericUpDown_DT_Volt.Value = value13;
			this.numericUpDown_DT_Volt.Visible = false;
			this.label_dt_dy.Anchor = AnchorStyles.Bottom;
			this.label_dt_dy.AutoSize = true;
			this.label_dt_dy.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location59 = new System.Drawing.Point(29, 53);
			this.label_dt_dy.Location = location59;
			Padding margin59 = new Padding(2, 0, 2, 0);
			this.label_dt_dy.Margin = margin59;
			this.label_dt_dy.Name = "label_dt_dy";
			System.Drawing.Size size59 = new System.Drawing.Size(75, 15);
			this.label_dt_dy.Size = size59;
			this.label_dt_dy.TabIndex = 41;
			this.label_dt_dy.Text = "导通电压:";
			this.label_dt_dy.Visible = false;
			this.label_dt_yz.Anchor = AnchorStyles.Top;
			this.label_dt_yz.AutoSize = true;
			this.label_dt_yz.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location60 = new System.Drawing.Point(29, 32);
			this.label_dt_yz.Location = location60;
			Padding margin60 = new Padding(2, 0, 2, 0);
			this.label_dt_yz.Margin = margin60;
			this.label_dt_yz.Name = "label_dt_yz";
			System.Drawing.Size size60 = new System.Drawing.Size(75, 15);
			this.label_dt_yz.Size = size60;
			this.label_dt_yz.TabIndex = 19;
			this.label_dt_yz.Text = "导通阈值:";
			this.label_dt_dl.Anchor = AnchorStyles.Bottom;
			this.label_dt_dl.AutoSize = true;
			this.label_dt_dl.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location61 = new System.Drawing.Point(397, 53);
			this.label_dt_dl.Location = location61;
			Padding margin61 = new Padding(2, 0, 2, 0);
			this.label_dt_dl.Margin = margin61;
			this.label_dt_dl.Name = "label_dt_dl";
			System.Drawing.Size size61 = new System.Drawing.Size(75, 15);
			this.label_dt_dl.Size = size61;
			this.label_dt_dl.TabIndex = 19;
			this.label_dt_dl.Text = "导通电流:";
			this.label_dt_dl.Visible = false;
			this.numericUpDown_DT_Threshold.Anchor = AnchorStyles.Top;
			this.numericUpDown_DT_Threshold.DecimalPlaces = 3;
			this.numericUpDown_DT_Threshold.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location62 = new System.Drawing.Point(110, 28);
			this.numericUpDown_DT_Threshold.Location = location62;
			Padding margin62 = new Padding(2);
			this.numericUpDown_DT_Threshold.Margin = margin62;
			decimal maximum13 = new decimal(new int[]
			{
				1000000,
				0,
				0,
				0
			});
			this.numericUpDown_DT_Threshold.Maximum = maximum13;
			this.numericUpDown_DT_Threshold.Name = "numericUpDown_DT_Threshold";
			System.Drawing.Size size62 = new System.Drawing.Size(75, 24);
			this.numericUpDown_DT_Threshold.Size = size62;
			this.numericUpDown_DT_Threshold.TabIndex = 7;
			decimal value14 = new decimal(new int[]
			{
				5,
				0,
				0,
				0
			});
			this.numericUpDown_DT_Threshold.Value = value14;
			this.label_DT_Current_unit.Anchor = AnchorStyles.Bottom;
			this.label_DT_Current_unit.AutoSize = true;
			this.label_DT_Current_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location63 = new System.Drawing.Point(559, 53);
			this.label_DT_Current_unit.Location = location63;
			Padding margin63 = new Padding(2, 0, 2, 0);
			this.label_DT_Current_unit.Margin = margin63;
			this.label_DT_Current_unit.Name = "label_DT_Current_unit";
			System.Drawing.Size size63 = new System.Drawing.Size(103, 15);
			this.label_DT_Current_unit.Size = size63;
			this.label_DT_Current_unit.TabIndex = 26;
			this.label_DT_Current_unit.Text = "mA  (5~2000)";
			this.label_DT_Current_unit.Visible = false;
			this.label_DT_Threshold_unit.Anchor = AnchorStyles.Top;
			this.label_DT_Threshold_unit.AutoSize = true;
			this.label_DT_Threshold_unit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location64 = new System.Drawing.Point(191, 32);
			this.label_DT_Threshold_unit.Location = location64;
			Padding margin64 = new Padding(2, 0, 2, 0);
			this.label_DT_Threshold_unit.Margin = margin64;
			this.label_DT_Threshold_unit.Name = "label_DT_Threshold_unit";
			System.Drawing.Size size64 = new System.Drawing.Size(142, 15);
			this.label_DT_Threshold_unit.Size = size64;
			this.label_DT_Threshold_unit.TabIndex = 23;
			this.label_DT_Threshold_unit.Text = "Ω  (0.1~1000000)";
			this.checkBox_GroupTest.Anchor = AnchorStyles.Top;
			this.checkBox_GroupTest.AutoSize = true;
			this.checkBox_GroupTest.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location65 = new System.Drawing.Point(523, 56);
			this.checkBox_GroupTest.Location = location65;
			Padding margin65 = new Padding(2);
			this.checkBox_GroupTest.Margin = margin65;
			this.checkBox_GroupTest.Name = "checkBox_GroupTest";
			System.Drawing.Size size65 = new System.Drawing.Size(86, 19);
			this.checkBox_GroupTest.Size = size65;
			this.checkBox_GroupTest.TabIndex = 23;
			this.checkBox_GroupTest.Text = "分组测试";
			this.checkBox_GroupTest.UseVisualStyleBackColor = true;
			this.checkBox_GroupTest.CheckedChanged += new System.EventHandler(this.checkBox_GroupTest_CheckedChanged);
			this.btnGroupTestParaSet.Anchor = AnchorStyles.Top;
			this.btnGroupTestParaSet.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location66 = new System.Drawing.Point(614, 53);
			this.btnGroupTestParaSet.Location = location66;
			Padding margin66 = new Padding(2);
			this.btnGroupTestParaSet.Margin = margin66;
			this.btnGroupTestParaSet.Name = "btnGroupTestParaSet";
			System.Drawing.Size size66 = new System.Drawing.Size(150, 24);
			this.btnGroupTestParaSet.Size = size66;
			this.btnGroupTestParaSet.TabIndex = 4;
			this.btnGroupTestParaSet.Text = "分组试验参数设置";
			this.btnGroupTestParaSet.UseVisualStyleBackColor = true;
			this.btnGroupTestParaSet.Visible = false;
			this.btnGroupTestParaSet.Click += new System.EventHandler(this.btnGroupTestParaSet_Click);
			this.checkBox_CommonProject.Anchor = AnchorStyles.Top;
			this.checkBox_CommonProject.AutoSize = true;
			this.checkBox_CommonProject.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location67 = new System.Drawing.Point(432, 56);
			this.checkBox_CommonProject.Location = location67;
			Padding margin67 = new Padding(2);
			this.checkBox_CommonProject.Margin = margin67;
			this.checkBox_CommonProject.Name = "checkBox_CommonProject";
			System.Drawing.Size size67 = new System.Drawing.Size(86, 19);
			this.checkBox_CommonProject.Size = size67;
			this.checkBox_CommonProject.TabIndex = 3;
			this.checkBox_CommonProject.Text = "常用项目";
			this.checkBox_CommonProject.UseVisualStyleBackColor = true;
			this.label_batchMumber.Anchor = AnchorStyles.Top;
			this.label_batchMumber.AutoSize = true;
			this.label_batchMumber.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location68 = new System.Drawing.Point(428, 22);
			this.label_batchMumber.Location = location68;
			Padding margin68 = new Padding(2, 0, 2, 0);
			this.label_batchMumber.Margin = margin68;
			this.label_batchMumber.Name = "label_batchMumber";
			System.Drawing.Size size68 = new System.Drawing.Size(60, 15);
			this.label_batchMumber.Size = size68;
			this.label_batchMumber.TabIndex = 0;
			this.label_batchMumber.Text = "批次号:";
			this.textBox_batchMumber.Anchor = AnchorStyles.Top;
			this.textBox_batchMumber.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location69 = new System.Drawing.Point(494, 18);
			this.textBox_batchMumber.Location = location69;
			Padding margin69 = new Padding(2);
			this.textBox_batchMumber.Margin = margin69;
			this.textBox_batchMumber.MaxLength = 120;
			this.textBox_batchMumber.Name = "textBox_batchMumber";
			System.Drawing.Size size69 = new System.Drawing.Size(271, 24);
			this.textBox_batchMumber.Size = size69;
			this.textBox_batchMumber.TabIndex = 1;
			this.textBox_batchMumber.KeyPress += new KeyPressEventHandler(this.textBox_pn_KeyPress);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.checkBox_GroupTest);
			base.Controls.Add(this.checkBox_CommonProject);
			base.Controls.Add(this.tabControl_createProject);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnSubmit);
			base.Controls.Add(this.btnGroupTestParaSet);
			base.Controls.Add(this.textBox_Remark);
			base.Controls.Add(this.textBox_batchMumber);
			base.Controls.Add(this.textBox_projectName);
			base.Controls.Add(this.label_batchMumber);
			base.Controls.Add(this.label_remark);
			base.Controls.Add(this.label_projectName);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin70 = new Padding(2);
			base.Margin = margin70;
			base.Name = "ctFormProjectCreate";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "新建项目";
			base.Load += new System.EventHandler(this.ctFormProjectCreate_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormProjectCreate_SizeChanged);
			this.tabControl_createProject.ResumeLayout(false);
			this.tabPage_choiceTestCable.ResumeLayout(false);
			this.tabPage_choiceTestCable.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			this.tabPage_paraSetting.ResumeLayout(false);
			this.groupBox_nyParaSet.ResumeLayout(false);
			this.groupBox_nyParaSet.PerformLayout();
			((ISupportInitialize)this.numericUpDown_NY_Threshold).EndInit();
			((ISupportInitialize)this.numericUpDown_NY_ACVolt).EndInit();
			((ISupportInitialize)this.numericUpDown_NY_HoldTime).EndInit();
			this.groupBox_jyParaSet.ResumeLayout(false);
			this.groupBox_jyParaSet.PerformLayout();
			((ISupportInitialize)this.numericUpDown_DYJY_DCRiseTime).EndInit();
			((ISupportInitialize)this.numericUpDown_DYJY_HoldTime).EndInit();
			((ISupportInitialize)this.numericUpDown_DYJY_DCVolt).EndInit();
			((ISupportInitialize)this.numericUpDown_DYJY_Threshold).EndInit();
			((ISupportInitialize)this.numericUpDown_JY_DCRiseTime).EndInit();
			((ISupportInitialize)this.numericUpDown_JY_HoldTime).EndInit();
			((ISupportInitialize)this.numericUpDown_JY_DCVolt).EndInit();
			((ISupportInitialize)this.numericUpDown_JY_Threshold).EndInit();
			this.groupBox_dtParaSet.ResumeLayout(false);
			this.groupBox_dtParaSet.PerformLayout();
			((ISupportInitialize)this.numericUpDown_DT_Current).EndInit();
			((ISupportInitialize)this.numericUpDown_DT_Volt).EndInit();
			((ISupportInitialize)this.numericUpDown_DT_Threshold).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			this.testProjectNameStr = "";
			this.createSuccFlag = false;
			base.Close();
		}
		private void numericUpDown_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '.' && e.KeyChar != '\b')
			{
				e.Handled = true;
			}
			else
			{
				e.Handled = false;
			}
		}
		public void SetDTTestControlVisibleFunc([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool vFlag)
		{
			try
			{
				this.groupBox_dtParaSet.Visible = vFlag;
				if (vFlag)
				{
					vFlag = this.gLineTestProcessor.bDTVoltCurrentShowFlag;
					if (!vFlag)
					{
						System.Drawing.Size this2 = new System.Drawing.Size(this.groupBox_nyParaSet.Width, 70);
						this.groupBox_dtParaSet.Size = this2;
					}
				}
				this.label_dt_dy.Visible = vFlag;
				this.numericUpDown_DT_Volt.Visible = vFlag;
				this.label_DT_Volt_unit.Visible = vFlag;
				this.label_dt_dl.Visible = vFlag;
				this.numericUpDown_DT_Current.Visible = vFlag;
				this.label_DT_Current_unit.Visible = vFlag;
			}
			catch (System.Exception ex_89)
			{
			}
		}
		public void SetNYTestControlVisibleFunc([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool vFlag)
		{
			try
			{
				this.groupBox_nyParaSet.Visible = vFlag;
			}
			catch (System.Exception ex_0E)
			{
			}
		}
		public void SetJYTestControlVisibleFunc([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool vFlag)
		{
			try
			{
				this.groupBox_jyParaSet.Visible = vFlag;
				if (vFlag)
				{
					bool this2 = this.gLineTestProcessor.bJYHighLowModeShowFlag;
					vFlag = this2;
					if (!this2)
					{
						System.Drawing.Size vFlag2 = new System.Drawing.Size(this.groupBox_nyParaSet.Width, this.groupBox_nyParaSet.Height);
						this.groupBox_jyParaSet.Size = vFlag2;
					}
				}
				this.label_jy_TestMode.Visible = vFlag;
				this.radioButton_jy_HighVolt.Visible = vFlag;
				this.radioButton_jy_LowVolt.Visible = vFlag;
			}
			catch (System.Exception ex_70)
			{
			}
		}
		public void LoadDefaultParaFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				double dDT_Threshold = 5.0;
				double dDT_DTVoltage = 9.0;
				double dDT_DTCurrent = 1.0;
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
				bool bExistFlag = false;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select * from TDefaultTestParaInfo", connection).ExecuteReader();
					if (dataReader.Read())
					{
						bExistFlag = true;
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
				catch (System.Exception arg_31D_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_31D_0.StackTrace);
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
				if (bExistFlag)
				{
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
			}
			catch (System.Exception arg_47A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_47A_0.StackTrace);
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
					if (this.numericUpDown_DT_Threshold.DecimalPlaces == 1)
					{
						if (this.d_DT_Threshold_Min < 0.1)
						{
							this.d_DT_Threshold_Min = 0.1;
						}
					}
					else if (this.numericUpDown_DT_Threshold.DecimalPlaces == 2)
					{
						if (this.d_DT_Threshold_Min < 0.01)
						{
							this.d_DT_Threshold_Min = 0.01;
						}
					}
					else if (this.numericUpDown_DT_Threshold.DecimalPlaces == 3 && this.d_DT_Threshold_Min < 0.001)
					{
						this.d_DT_Threshold_Min = 0.001;
					}
					this.label_DT_Threshold_unit.Text = "Ω  (" + System.Convert.ToString(this.d_DT_Threshold_Min) + "~" + System.Convert.ToString(this.d_DT_Threshold_Max) + ")";
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
					if (this.numericUpDown_JY_Threshold.DecimalPlaces == 1)
					{
						if (this.d_JY_Threshold_Min < 0.1)
						{
							this.d_JY_Threshold_Min = 0.1;
						}
					}
					else if (this.numericUpDown_JY_Threshold.DecimalPlaces == 2)
					{
						if (this.d_JY_Threshold_Min < 0.01)
						{
							this.d_JY_Threshold_Min = 0.01;
						}
					}
					else if (this.numericUpDown_JY_Threshold.DecimalPlaces == 3 && this.d_JY_Threshold_Min < 0.001)
					{
						this.d_JY_Threshold_Min = 0.001;
					}
					this.label_JY_Threshold_unit.Text = "MΩ (" + System.Convert.ToString(this.d_JY_Threshold_Min) + "~" + System.Convert.ToString(this.d_JY_Threshold_Max) + ")";
					decimal minimum5 = System.Convert.ToDecimal(this.d_JY_HoldTime_Min);
					this.numericUpDown_JY_HoldTime.Minimum = minimum5;
					decimal maximum5 = System.Convert.ToDecimal(this.d_JY_HoldTime_Max);
					this.numericUpDown_JY_HoldTime.Maximum = maximum5;
					this.label_JY_HoldTime_unit.Text = "s  (" + System.Convert.ToString(this.d_JY_HoldTime_Min) + "~" + System.Convert.ToString(this.d_JY_HoldTime_Max) + ")";
					decimal minimum6 = System.Convert.ToDecimal(this.d_JY_DCVolt_Min);
					this.numericUpDown_JY_DCVolt.Minimum = minimum6;
					decimal maximum6 = System.Convert.ToDecimal(this.d_JY_DCVolt_Max);
					this.numericUpDown_JY_DCVolt.Maximum = maximum6;
					this.label_JY_DCVolt_unit.Text = "VDC (" + System.Convert.ToString(this.d_JY_DCVolt_Min) + "~" + System.Convert.ToString(this.d_JY_DCVolt_Max) + ")";
					decimal minimum7 = System.Convert.ToDecimal(this.d_JY_DCRiseTime_Min);
					this.numericUpDown_JY_DCRiseTime.Minimum = minimum7;
					decimal maximum7 = System.Convert.ToDecimal(this.d_JY_DCRiseTime_Max);
					this.numericUpDown_JY_DCRiseTime.Maximum = maximum7;
					this.label_JY_DCRiseTime_unit.Text = "s  (" + System.Convert.ToString(this.d_JY_DCRiseTime_Min) + "~" + System.Convert.ToString(this.d_JY_DCRiseTime_Max) + ")";
					decimal minimum8 = System.Convert.ToDecimal(this.d_DYJY_Threshold_Min);
					this.numericUpDown_DYJY_Threshold.Minimum = minimum8;
					decimal maximum8 = System.Convert.ToDecimal(this.d_DYJY_Threshold_Max);
					this.numericUpDown_DYJY_Threshold.Maximum = maximum8;
					if (this.numericUpDown_DYJY_Threshold.DecimalPlaces == 1)
					{
						if (this.d_DYJY_Threshold_Min < 0.1)
						{
							this.d_DYJY_Threshold_Min = 0.1;
						}
					}
					else if (this.numericUpDown_DYJY_Threshold.DecimalPlaces == 2)
					{
						if (this.d_DYJY_Threshold_Min < 0.01)
						{
							this.d_DYJY_Threshold_Min = 0.01;
						}
					}
					else if (this.numericUpDown_DYJY_Threshold.DecimalPlaces == 3 && this.d_DYJY_Threshold_Min < 0.001)
					{
						this.d_DYJY_Threshold_Min = 0.001;
					}
					this.label_DYJY_Threshold_unit.Text = "MΩ (" + System.Convert.ToString(this.d_DYJY_Threshold_Min) + "~" + System.Convert.ToString(this.d_DYJY_Threshold_Max) + ")";
					decimal minimum9 = System.Convert.ToDecimal(this.d_DYJY_HoldTime_Min);
					this.numericUpDown_DYJY_HoldTime.Minimum = minimum9;
					decimal maximum9 = System.Convert.ToDecimal(this.d_DYJY_HoldTime_Max);
					this.numericUpDown_DYJY_HoldTime.Maximum = maximum9;
					this.label_DYJY_HoldTime_unit.Text = "s  (" + System.Convert.ToString(this.d_DYJY_HoldTime_Min) + "~" + System.Convert.ToString(this.d_DYJY_HoldTime_Max) + ")";
					decimal minimum10 = System.Convert.ToDecimal(this.d_DYJY_DCVolt_Min);
					this.numericUpDown_DYJY_DCVolt.Minimum = minimum10;
					decimal maximum10 = System.Convert.ToDecimal(this.d_DYJY_DCVolt_Max);
					this.numericUpDown_DYJY_DCVolt.Maximum = maximum10;
					this.label_DYJY_DCVolt_unit.Text = "VDC (" + System.Convert.ToString(this.d_DYJY_DCVolt_Min) + "~" + System.Convert.ToString(this.d_DYJY_DCVolt_Max) + ")";
					decimal minimum11 = System.Convert.ToDecimal(this.d_DYJY_DCRiseTime_Min);
					this.numericUpDown_DYJY_DCRiseTime.Minimum = minimum11;
					decimal maximum11 = System.Convert.ToDecimal(this.d_DYJY_DCRiseTime_Max);
					this.numericUpDown_DYJY_DCRiseTime.Maximum = maximum11;
					this.label_DYJY_DCRiseTime_unit.Text = "s  (" + System.Convert.ToString(this.d_DYJY_DCRiseTime_Min) + "~" + System.Convert.ToString(this.d_DYJY_DCRiseTime_Max) + ")";
					decimal minimum12 = System.Convert.ToDecimal(this.d_NY_Threshold_Min);
					this.numericUpDown_NY_Threshold.Minimum = minimum12;
					decimal maximum12 = System.Convert.ToDecimal(this.d_NY_Threshold_Max);
					this.numericUpDown_NY_Threshold.Maximum = maximum12;
					if (this.numericUpDown_NY_Threshold.DecimalPlaces == 1)
					{
						if (this.d_NY_Threshold_Min < 0.1)
						{
							this.d_NY_Threshold_Min = 0.1;
						}
					}
					else if (this.numericUpDown_NY_Threshold.DecimalPlaces == 2)
					{
						if (this.d_NY_Threshold_Min < 0.01)
						{
							this.d_NY_Threshold_Min = 0.01;
						}
					}
					else if (this.numericUpDown_NY_Threshold.DecimalPlaces == 3 && this.d_NY_Threshold_Min < 0.001)
					{
						this.d_NY_Threshold_Min = 0.001;
					}
					this.label_NY_Threshold_unit.Text = "mA  (" + System.Convert.ToString(this.d_NY_Threshold_Min) + "~" + System.Convert.ToString(this.d_NY_Threshold_Max) + ")";
					decimal minimum13 = System.Convert.ToDecimal(this.d_NY_HoldTime_Min);
					this.numericUpDown_NY_HoldTime.Minimum = minimum13;
					decimal maximum13 = System.Convert.ToDecimal(this.d_NY_HoldTime_Max);
					this.numericUpDown_NY_HoldTime.Maximum = maximum13;
					this.label_NY_HoldTime_unit.Text = "s  (" + System.Convert.ToString(this.d_NY_HoldTime_Min) + "~" + System.Convert.ToString(this.d_NY_HoldTime_Max) + ")";
					decimal minimum14 = System.Convert.ToDecimal(this.d_NY_ACVolt_Min);
					this.numericUpDown_NY_ACVolt.Minimum = minimum14;
					decimal maximum14 = System.Convert.ToDecimal(this.d_NY_ACVolt_Max);
					this.numericUpDown_NY_ACVolt.Maximum = maximum14;
					this.label_NY_ACVolt_unit.Text = "VAC (" + System.Convert.ToString(this.d_NY_ACVolt_Min) + "~" + System.Convert.ToString(this.d_NY_ACVolt_Max) + ")";
				}
			}
			catch (System.Exception arg_C37_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_C37_0.StackTrace);
			}
		}
		private void ctFormProjectCreate_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray = new System.Collections.Generic.List<GroupTestParaStruct>();
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
			catch (System.Exception arg_A3_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_A3_0.StackTrace);
			}
			this.SetDTTestControlVisibleFunc(this.gLineTestProcessor.bDTTestEnabled);
			this.SetJYTestControlVisibleFunc(this.gLineTestProcessor.bJYTestEnabled);
			this.SetNYTestControlVisibleFunc(this.gLineTestProcessor.bNYTestEnabled);
			this.SetControlMaxMinValueFunc();
			this.RefreshDataGridView();
			this.LoadDefaultParaFunc();
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
			}
			catch (System.Exception arg_13A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_13A_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
		}
		public void RefreshDataGridView()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.dataGridView1.Rows.Clear();
				int inum = 0;
				string cableStr = this.textBox_Cable.Text.ToString().Trim();
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select top " + 1000 + " * from TLineStructLibrary order by LID desc", connection).ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView1.Rows.Add(1);
						int num = inum + 1;
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
						this.strIDArray[inum] = dataReader["LID"].ToString();
						this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["LineStructName"].ToString();
						this.strPlugArray[inum] = dataReader["PlugInfo"].ToString();
						this.dataGridView1.Rows[inum].Cells[2].Value = this.strPlugArray[inum];
						this.dataGridView1.Rows[inum].Cells[3].Value = dataReader["LinePinNum"].ToString();
						this.dataGridView1.Rows[inum].Cells[4].Value = dataReader["Remark"].ToString();
						inum = num;
					}
					this.dataGridView1.AllowUserToAddRows = false;
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_1E8_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_1E8_0.StackTrace);
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
				for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
				{
					this.dataGridView1.Rows[i].Selected = false;
				}
			}
			catch (System.Exception arg_23E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_23E_0.StackTrace);
			}
		}
		public void GLDealwithFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				string cableStr = this.textBox_Cable.Text.ToString().Trim();
				if (this.oldSXstr != cableStr)
				{
					this.oldSXstr = cableStr;
				}
				this.dataGridView1.Rows.Clear();
				int inum = 0;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand((!string.IsNullOrEmpty(cableStr)) ? ("select top " + 1000 + " * from TLineStructLibrary where LineStructName like '%" + cableStr + "%' order by LineStructName") : ("select top " + 1000 + " * from TLineStructLibrary order by LID desc"), connection).ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView1.Rows.Add(1);
						int num = inum + 1;
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
						this.strIDArray[inum] = dataReader["LID"].ToString();
						this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["LineStructName"].ToString();
						this.strPlugArray[inum] = dataReader["PlugInfo"].ToString();
						this.dataGridView1.Rows[inum].Cells[2].Value = this.strPlugArray[inum];
						this.dataGridView1.Rows[inum].Cells[3].Value = dataReader["LinePinNum"].ToString();
						this.dataGridView1.Rows[inum].Cells[4].Value = dataReader["Remark"].ToString();
						inum = num;
					}
					this.dataGridView1.AllowUserToAddRows = false;
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_234_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_234_0.StackTrace);
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
			catch (System.Exception arg_258_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_258_0.StackTrace);
			}
		}
		private void textBox_Cable_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.GLDealwithFunc();
			}
			catch (System.Exception arg_08_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_08_0.StackTrace);
			}
		}
		public void SaveGroupTestParaDataToDBFunc()
		{
			OleDbConnection connection = null;
			try
			{
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					KGroupTestParaInfo groupTestParaInfo = this.gLineTestProcessor.groupTestParaInfo;
					string sqlcommand = "delete from TGroupTestParaSet where PID='" + groupTestParaInfo.strPID + "' and LID='" + groupTestParaInfo.strLID + "'";
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					cmd.ExecuteNonQuery();
					System.Threading.Thread.Sleep(50);
					for (int i = 0; i < this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray.Count; i++)
					{
						string str = "','";
						groupTestParaInfo = this.gLineTestProcessor.groupTestParaInfo;
						sqlcommand = "insert into TGroupTestParaSet(PID,LID,PlugName1,PinName1,PlugName2,PinName2," + "DTThreshold,DTVoltage,DTCurrent,JYThreshold,JYTestTime,JYVoltage,JYUpTime,NYThreshold,NYTestTime,NYVoltage)" + " values('" + groupTestParaInfo.strPID + str + groupTestParaInfo.strLID + str + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i].PlugName1 + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i].PinName1 + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i].PlugName2 + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i].PinName2 + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i].DTThreshold + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i].DTVoltage + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i].DTCurrent + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i].JYThreshold + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i].JYTestTime + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i].JYVoltage + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i].JYUpTime + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i].NYThreshold + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i].NYTestTime + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i].NYVoltage + "')";
						cmd = new OleDbCommand(sqlcommand, connection);
						cmd.ExecuteNonQuery();
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_351_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_351_0.StackTrace);
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
			}
			catch (System.Exception arg_36A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_36A_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool DealwithSubmitFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				string projectNameStr = this.textBox_projectName.Text.ToString().Trim();
				byte result;
				if (string.IsNullOrEmpty(projectNameStr))
				{
					MessageBox.Show("项目名称为空!", "提示", MessageBoxButtons.OK);
					result = 0;
					return result != 0;
				}
				string bcCableStr = this.textBox_yxbcCable.Text.ToString().Trim();
				if (string.IsNullOrEmpty(bcCableStr))
				{
					MessageBox.Show("未选择被测线束!", "提示", MessageBoxButtons.OK);
					result = 0;
					return result != 0;
				}
				string batchMumberStr = this.textBox_batchMumber.Text.ToString().Trim();
				if (string.IsNullOrEmpty(batchMumberStr))
				{
					MessageBox.Show("批次号为空!", "提示", MessageBoxButtons.OK);
					result = 0;
					return result != 0;
				}
				string remarkStr = this.textBox_Remark.Text.ToString().Trim();
				int iCommProject = 0;
				if (this.checkBox_CommonProject.Visible && this.checkBox_CommonProject.Checked)
				{
					iCommProject = 1;
				}
				int iGroupTestFlag = 0;
				if (this.checkBox_GroupTest.Visible && this.checkBox_GroupTest.Checked)
				{
					iGroupTestFlag = 1;
				}
				double dDT_Threshold = System.Convert.ToDouble(this.numericUpDown_DT_Threshold.Value);
				double dDT_DTVoltage = System.Convert.ToDouble(this.numericUpDown_DT_Volt.Value);
				double dDT_DTCurrent = System.Convert.ToDouble(this.numericUpDown_DT_Current.Value);
				double dJY_Threshold;
				double dJY_JYHoldTime;
				double dJY_DCHighVolt;
				double dJY_DCRiseTime;
				if (this.radioButton_jy_HighVolt.Checked)
				{
					dJY_Threshold = System.Convert.ToDouble(this.numericUpDown_JY_Threshold.Value);
					dJY_JYHoldTime = System.Convert.ToDouble(this.numericUpDown_JY_HoldTime.Value);
					dJY_DCHighVolt = System.Convert.ToDouble(this.numericUpDown_JY_DCVolt.Value);
					dJY_DCRiseTime = System.Convert.ToDouble(this.numericUpDown_JY_DCRiseTime.Value);
				}
				else
				{
					dJY_Threshold = System.Convert.ToDouble(this.numericUpDown_DYJY_Threshold.Value);
					dJY_JYHoldTime = System.Convert.ToDouble(this.numericUpDown_DYJY_HoldTime.Value);
					dJY_DCHighVolt = System.Convert.ToDouble(this.numericUpDown_DYJY_DCVolt.Value);
					dJY_DCRiseTime = System.Convert.ToDouble(this.numericUpDown_DYJY_DCRiseTime.Value);
				}
				double dNY_Threshold = System.Convert.ToDouble(this.numericUpDown_NY_Threshold.Value);
				double dNY_NYHoldTime = System.Convert.ToDouble(this.numericUpDown_NY_HoldTime.Value);
				double dNY_ACHighVolt = System.Convert.ToDouble(this.numericUpDown_NY_ACVolt.Value);
				dDT_Threshold = System.Math.Round(dDT_Threshold, 2);
				dDT_DTVoltage = System.Math.Round(dDT_DTVoltage, 3);
				dDT_DTCurrent = System.Math.Round(dDT_DTCurrent, 3);
				dJY_Threshold = System.Math.Round(dJY_Threshold, 1);
				dJY_JYHoldTime = System.Math.Round(dJY_JYHoldTime, 1);
				dJY_DCHighVolt = System.Math.Round(dJY_DCHighVolt, 1);
				dJY_DCRiseTime = System.Math.Round(dJY_DCRiseTime, 1);
				dNY_Threshold = System.Math.Round(dNY_Threshold, 1);
				dNY_NYHoldTime = System.Math.Round(dNY_NYHoldTime, 1);
				dNY_ACHighVolt = System.Math.Round(dNY_ACHighVolt, 1);
				bool bExsitFlag = false;
				bool flag;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "select top 1 * from TProjectInfo where ProjectName = '" + projectNameStr + "'";
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
						connection.Close();
						connection = null;
						MessageBox.Show("项目名称已存在!", "提示", MessageBoxButtons.OK);
						result = 0;
						return result != 0;
					}
					bExsitFlag = false;
					sqlcommand = "select top 1 * from TLineStructLibrary where LineStructName = '" + bcCableStr + "'";
					cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						bExsitFlag = true;
						this.gLineTestProcessor.groupTestParaInfo.strLID = dataReader["LID"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					if (!bExsitFlag)
					{
						connection.Close();
						connection = null;
						MessageBox.Show("被测线束不存在，请重新选择!", "提示", MessageBoxButtons.OK);
						result = 0;
						return result != 0;
					}
					string str = "','";
					string str2 = ",";
					sqlcommand = "insert into TProjectInfo(ProjectName,iCommonProject,iTestModel,iDTTestModel,iJYTestModel,iNYTestModel,dDT_Threshold,dDT_DTVoltage,dDT_DTCurrent," + 
						"dJY_Threshold,dJY_JYHoldTime,dJY_DCHighVolt,dJY_DCRiseTime,dNY_Threshold,dNY_NYHoldTime,dNY_ACHighVolt,other1,other2,iGroupTestFlag,batchMumberStr,bcCableName,Creator,Remark) " + 
						"values('" + projectNameStr + "'," + iCommProject + str2 + 1 + str2 + 2 + str2 + 1 + str2 + 1 + str2 + 
						dDT_Threshold + str2 + dDT_DTVoltage + str2 + dDT_DTCurrent + str2 + dJY_Threshold + str2 + dJY_JYHoldTime + 
						str2 + dJY_DCHighVolt + str2 + dJY_DCRiseTime + str2 + dNY_Threshold + str2 + dNY_NYHoldTime + str2 + 
						dNY_ACHighVolt + ",0,0," + iGroupTestFlag + ",'" + batchMumberStr + str + bcCableStr + str + 
						this.gLineTestProcessor.loginUserID + str + remarkStr + "')";
					//项目名称-常用项目-
					cmd = new OleDbCommand(sqlcommand, connection);
					cmd.ExecuteNonQuery();
					System.Threading.Thread.Sleep(100);
					sqlcommand = "select top 1 * from TProjectInfo where ProjectName = '" + projectNameStr + "'";
					cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						this.gLineTestProcessor.groupTestParaInfo.strPID = dataReader["ID"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
					this.createSuccFlag = true;
					this.ct_TestBCXSStr = bcCableStr;
					this.testProjectNameStr = projectNameStr;
					if (this.checkBox_GroupTest.Visible && this.checkBox_GroupTest.Checked)
					{
						this.gLineTestProcessor.groupTestParaInfo.bGroupTestFlag = true;
					}
					else
					{
						this.gLineTestProcessor.groupTestParaInfo.bGroupTestFlag = false;
					}
					this.gLineTestProcessor.groupTestParaInfo.strProjectName = projectNameStr;
					this.gLineTestProcessor.groupTestParaInfo.strCableName = bcCableStr;
				}
				catch (System.Exception arg_6B1_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_6B1_0.StackTrace);
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
					goto IL_6D8;
				}
				goto IL_6ED;
				IL_6D8:
				result = (flag ? 1 : 0);
				return result != 0;
			}
			catch (System.Exception arg_6DE_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_6DE_0.StackTrace);
				return false;
			}
			IL_6ED:
			if (this.gLineTestProcessor.groupTestParaInfo.bGroupTestFlag)
			{
				this.SaveGroupTestParaDataToDBFunc();
			}
			return true;
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.DealwithSubmitFunc())
				{
					return;
				}
			}
			catch (System.Exception arg_0C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_0C_0.StackTrace);
			}
			base.Close();
		}
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 668;
					int ia = 0;
					if (iw > 0)
					{
						ia = iw / 2;
					}
					this.dataGridView1.Columns[0].Width = 74;
					this.dataGridView1.Columns[1].Width = ia + 150;
					this.dataGridView1.Columns[2].Width = ia + 200;
					this.dataGridView1.Columns[3].Width = 120;
					this.dataGridView1.Columns[4].Width = 100;
				}
			}
			catch (System.Exception arg_AC_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_AC_0.StackTrace);
			}
		}
		private void ctFormProjectCreate_SizeChanged(object sender, System.EventArgs e)
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
		private void btnCableLibManage_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				ctFormCableLibrary ctFormCableLibrary = new ctFormCableLibrary(this.gLineTestProcessor);
				this.cableLibraryForm = ctFormCableLibrary;
				ctFormCableLibrary.Activate();
				this.cableLibraryForm.ShowDialog();
			}
			catch (System.Exception arg_2E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2E_0.StackTrace);
			}
			try
			{
				string cableStr = this.textBox_Cable.Text.ToString().Trim();
				this.dataGridView1.Rows.Clear();
				int inum = 0;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand((!string.IsNullOrEmpty(cableStr)) ? ("select * from TLineStructLibrary where LineStructName like '%" + cableStr + "%' order by LineStructName") : "select * from TLineStructLibrary order by LineStructName", connection).ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView1.Rows.Add(1);
						int num = inum + 1;
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
						this.strIDArray[inum] = dataReader["LID"].ToString();
						this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["LineStructName"].ToString();
						string text = dataReader["PlugInfo"].ToString();
						this.tempStr = text;
						this.strPlugArray[inum] = text;
						if (string.IsNullOrEmpty(this.tempStr))
						{
							this.dataGridView1.Rows[inum].Cells[2].Value = "0";
						}
						else if (-1 == this.tempStr.Trim().LastIndexOf(','))
						{
							this.dataGridView1.Rows[inum].Cells[2].Value = "1";
						}
						else
						{
							char[] separator = new char[]
							{
								','
							};
							string[] array = this.tempStr.Trim().Split(separator);
							this.strTempArray = array;
							this.dataGridView1.Rows[inum].Cells[2].Value = System.Convert.ToString(array.Length);
						}
						this.dataGridView1.Rows[inum].Cells[3].Value = dataReader["LinePinNum"].ToString();
						this.dataGridView1.Rows[inum].Cells[4].Value = dataReader["Remark"].ToString();
						inum = num;
						if (inum >= 5000)
						{
							break;
						}
					}
					this.dataGridView1.AllowUserToAddRows = false;
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_2DF_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_2DF_0.StackTrace);
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
				string _yxbcCableStr = this.textBox_yxbcCable.Text.ToString().Trim();
				for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
				{
					if (this.dataGridView1.Rows[i].Cells[1].Value != null)
					{
						string tempStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
						if (0 == _yxbcCableStr.CompareTo(tempStr))
						{
							this.dataGridView1.Rows[i].Selected = true;
							this.dataGridView1.CurrentCell = this.dataGridView1.Rows[i].Cells[0];
							break;
						}
					}
				}
			}
			catch (System.Exception arg_3DC_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3DC_0.StackTrace);
			}
		}
		private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0)
				{
					string tempStr = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
					this.textBox_yxbcCable.Text = tempStr;
					int iRowIndex = 0;
					for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
					{
						if (this.dataGridView1.Rows[i].Cells[1].Value != null)
						{
							string rTempStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
							if (tempStr == rTempStr)
							{
								iRowIndex = i;
							}
							else
							{
								this.dataGridView1.Rows[i].Selected = false;
							}
						}
					}
					this.dataGridView1.Rows[iRowIndex].Selected = true;
				}
			}
			catch (System.Exception arg_FB_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_FB_0.StackTrace);
			}
		}
		private void textBox_pn_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != '_')
			{
				e.Handled = false;
			}
			else
			{
				e.Handled = true;
			}
		}
		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0)
				{
					string tempStr = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
					this.textBox_yxbcCable.Text = tempStr;
					int iRowIndex = 0;
					for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
					{
						if (this.dataGridView1.Rows[i].Cells[1].Value != null)
						{
							string rTempStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
							if (tempStr == rTempStr)
							{
								iRowIndex = i;
							}
							else
							{
								this.dataGridView1.Rows[i].Selected = false;
							}
						}
					}
					this.dataGridView1.Rows[iRowIndex].Selected = true;
				}
			}
			catch (System.Exception arg_FB_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_FB_0.StackTrace);
			}
		}
		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0)
				{
					string tempStr = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
					this.textBox_yxbcCable.Text = tempStr;
					int iRowIndex = 0;
					for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
					{
						if (this.dataGridView1.Rows[i].Cells[1].Value != null)
						{
							string rTempStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
							if (tempStr == rTempStr)
							{
								iRowIndex = i;
							}
							else
							{
								this.dataGridView1.Rows[i].Selected = false;
							}
						}
					}
					this.dataGridView1.Rows[iRowIndex].Selected = true;
				}
			}
			catch (System.Exception arg_FB_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_FB_0.StackTrace);
			}
		}
		private void radioButton_jy_LowVolt_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.label_dyjy_yz.Visible = this.radioButton_jy_LowVolt.Checked;
				this.numericUpDown_DYJY_Threshold.Visible = this.radioButton_jy_LowVolt.Checked;
				this.label_DYJY_Threshold_unit.Visible = this.radioButton_jy_LowVolt.Checked;
				this.label_dyjy_jybcTime.Visible = this.radioButton_jy_LowVolt.Checked;
				this.numericUpDown_DYJY_HoldTime.Visible = this.radioButton_jy_LowVolt.Checked;
				this.label_DYJY_HoldTime_unit.Visible = this.radioButton_jy_LowVolt.Checked;
				this.label_dyjy_zlgy.Visible = this.radioButton_jy_LowVolt.Checked;
				this.numericUpDown_DYJY_DCVolt.Visible = this.radioButton_jy_LowVolt.Checked;
				this.label_DYJY_DCVolt_unit.Visible = this.radioButton_jy_LowVolt.Checked;
				this.label_dyjy_zlssTime.Visible = this.radioButton_jy_LowVolt.Checked;
				this.numericUpDown_DYJY_DCRiseTime.Visible = this.radioButton_jy_LowVolt.Checked;
				this.label_DYJY_DCRiseTime_unit.Visible = this.radioButton_jy_LowVolt.Checked;
				this.label_jy_yz.Visible = this.radioButton_jy_HighVolt.Checked;
				this.numericUpDown_JY_Threshold.Visible = this.radioButton_jy_HighVolt.Checked;
				this.label_JY_Threshold_unit.Visible = this.radioButton_jy_HighVolt.Checked;
				this.label_jy_jybcTime.Visible = this.radioButton_jy_HighVolt.Checked;
				this.numericUpDown_JY_HoldTime.Visible = this.radioButton_jy_HighVolt.Checked;
				this.label_JY_HoldTime_unit.Visible = this.radioButton_jy_HighVolt.Checked;
				this.label_jy_zlgy.Visible = this.radioButton_jy_HighVolt.Checked;
				this.numericUpDown_JY_DCVolt.Visible = this.radioButton_jy_HighVolt.Checked;
				this.label_JY_DCVolt_unit.Visible = this.radioButton_jy_HighVolt.Checked;
				this.label_jy_zlssTime.Visible = this.radioButton_jy_HighVolt.Checked;
				this.numericUpDown_JY_DCRiseTime.Visible = this.radioButton_jy_HighVolt.Checked;
				this.label_JY_DCRiseTime_unit.Visible = this.radioButton_jy_HighVolt.Checked;
			}
			catch (System.Exception arg_212_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_212_0.StackTrace);
			}
		}
		private void btnGroupTestParaSet_Click(object sender, System.EventArgs e)
		{
			try
			{
				string bcCableStr = this.textBox_yxbcCable.Text.ToString();
				if (string.IsNullOrEmpty(bcCableStr))
				{
					MessageBox.Show("未选择被测线束!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					ctFormGroupTestParaSet this2 = new ctFormGroupTestParaSet(this.gLineTestProcessor, bcCableStr, true, 0);
					this.groupTestParaSetForm = this2;
					this2.Activate();
					this.groupTestParaSetForm.ShowDialog();
				}
			}
			catch (System.Exception arg_56_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_56_0.StackTrace);
			}
		}
		private void checkBox_GroupTest_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.btnGroupTestParaSet.Visible = this.checkBox_GroupTest.Checked;
			}
			catch (System.Exception arg_18_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_18_0.StackTrace);
			}
		}
		private void tabControl_createProject_SelectedIndexChanged(object sender, System.EventArgs e)
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
		private void btnTMSM_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.textBox_yxbcCable.Text = "";
				this.textBox_yxbcCable.Focus();
			}
			catch (System.Exception arg_1E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1E_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormProjectCreate();
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
