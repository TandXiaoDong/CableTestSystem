using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormSelfStudy : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public ctFormSelfStudyPinRelation selfStudyPinRelationForm;
		public string loginUser;
		public string dbpath;
		public string bcCableStr;
		public bool bImportFlag;
		private Label label12;
		private TabControl tabControl1;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private Label label9;
		private ComboBox comboBox_xsjk;
		private Label label_xsxz;
		private ComboBox comboBox_xsxz;
		private DataGridViewTextBoxColumn Column_xh;
		private DataGridViewTextBoxColumn Column_startInterface;
		private DataGridView dataGridView1;
		private Button btnAddAll;
		private Button btnAddOne;
		private Button btnDelAll;
		private Button btnDelOne;
		private RadioButton radioButton_Pin_FourWire;
		private RadioButton radioButton_Pin_TwoWire;
		private Label label6;
		private RadioButton radioButton_Plug_FourWire;
		private RadioButton radioButton_Plug_TwoWire;
		private Label label13;
		private NumericUpDown numericUpDown_Plug_dtValue;
		private Label label10;
		private Label label11;
		private GroupBox groupBox1;
		private NumericUpDown numericUpDown_stop;
		private NumericUpDown numericUpDown_dtValue;
		private NumericUpDown numericUpDown_start;
		private Label label_ssMaxValue;
		private Label label5;
		private Label label4;
		private Label label2;
		private Label label3;
		private Label label8;
		private Label label7;
		private Label label1;
		private Button btnAllStudy;
		private Button btnStudy;
		private Button btnQuit;
		private Container components;
		public ctFormSelfStudy(KLineTestProcessor gltProcessor, string cableStr)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
					this.bcCableStr = cableStr;
				}
				catch (System.Exception arg_3D_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_3D_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormSelfStudy()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormSelfStudy));
			this.groupBox1 = new GroupBox();
			this.radioButton_Pin_FourWire = new RadioButton();
			this.radioButton_Pin_TwoWire = new RadioButton();
			this.label6 = new Label();
			this.numericUpDown_stop = new NumericUpDown();
			this.numericUpDown_dtValue = new NumericUpDown();
			this.numericUpDown_start = new NumericUpDown();
			this.label_ssMaxValue = new Label();
			this.label5 = new Label();
			this.label4 = new Label();
			this.label2 = new Label();
			this.label3 = new Label();
			this.label8 = new Label();
			this.label7 = new Label();
			this.label1 = new Label();
			this.btnAllStudy = new Button();
			this.btnStudy = new Button();
			this.btnQuit = new Button();
			this.tabControl1 = new TabControl();
			this.tabPage1 = new TabPage();
			this.tabPage2 = new TabPage();
			this.radioButton_Plug_FourWire = new RadioButton();
			this.radioButton_Plug_TwoWire = new RadioButton();
			this.label13 = new Label();
			this.numericUpDown_Plug_dtValue = new NumericUpDown();
			this.label10 = new Label();
			this.label11 = new Label();
			this.dataGridView1 = new DataGridView();
			this.Column_xh = new DataGridViewTextBoxColumn();
			this.Column_startInterface = new DataGridViewTextBoxColumn();
			this.label12 = new Label();
			this.label_xsxz = new Label();
			this.label9 = new Label();
			this.comboBox_xsxz = new ComboBox();
			this.comboBox_xsjk = new ComboBox();
			this.btnDelAll = new Button();
			this.btnAddAll = new Button();
			this.btnDelOne = new Button();
			this.btnAddOne = new Button();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_stop).BeginInit();
			((ISupportInitialize)this.numericUpDown_dtValue).BeginInit();
			((ISupportInitialize)this.numericUpDown_start).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_Plug_dtValue).BeginInit();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.radioButton_Pin_FourWire);
			this.groupBox1.Controls.Add(this.radioButton_Pin_TwoWire);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.numericUpDown_stop);
			this.groupBox1.Controls.Add(this.numericUpDown_dtValue);
			this.groupBox1.Controls.Add(this.numericUpDown_start);
			this.groupBox1.Controls.Add(this.label_ssMaxValue);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(16, 18);
			this.groupBox1.Location = location;
			Padding margin = new Padding(2);
			this.groupBox1.Margin = margin;
			this.groupBox1.Name = "groupBox1";
			Padding padding = new Padding(2);
			this.groupBox1.Padding = padding;
			System.Drawing.Size size = new System.Drawing.Size(739, 403);
			this.groupBox1.Size = size;
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "参数设置";
			this.radioButton_Pin_FourWire.Anchor = AnchorStyles.Left;
			this.radioButton_Pin_FourWire.AutoSize = true;
			this.radioButton_Pin_FourWire.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(445, 105);
			this.radioButton_Pin_FourWire.Location = location2;
			Padding margin2 = new Padding(2);
			this.radioButton_Pin_FourWire.Margin = margin2;
			this.radioButton_Pin_FourWire.Name = "radioButton_Pin_FourWire";
			System.Drawing.Size size2 = new System.Drawing.Size(70, 19);
			this.radioButton_Pin_FourWire.Size = size2;
			this.radioButton_Pin_FourWire.TabIndex = 11;
			this.radioButton_Pin_FourWire.Text = "四线法";
			this.radioButton_Pin_FourWire.UseVisualStyleBackColor = true;
			this.radioButton_Pin_FourWire.Visible = false;
			this.radioButton_Pin_TwoWire.Anchor = AnchorStyles.Left;
			this.radioButton_Pin_TwoWire.AutoSize = true;
			this.radioButton_Pin_TwoWire.Checked = true;
			this.radioButton_Pin_TwoWire.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(333, 105);
			this.radioButton_Pin_TwoWire.Location = location3;
			Padding margin3 = new Padding(2);
			this.radioButton_Pin_TwoWire.Margin = margin3;
			this.radioButton_Pin_TwoWire.Name = "radioButton_Pin_TwoWire";
			System.Drawing.Size size3 = new System.Drawing.Size(70, 19);
			this.radioButton_Pin_TwoWire.Size = size3;
			this.radioButton_Pin_TwoWire.TabIndex = 12;
			this.radioButton_Pin_TwoWire.TabStop = true;
			this.radioButton_Pin_TwoWire.Text = "二线法";
			this.radioButton_Pin_TwoWire.UseVisualStyleBackColor = true;
			this.radioButton_Pin_TwoWire.Visible = false;
			this.radioButton_Pin_TwoWire.CheckedChanged += new System.EventHandler(this.radioButton_Pin_TwoWire_CheckedChanged);
			this.label6.Anchor = AnchorStyles.Left;
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(238, 106);
			this.label6.Location = location4;
			Padding margin4 = new Padding(2, 0, 2, 0);
			this.label6.Margin = margin4;
			this.label6.Name = "label6";
			System.Drawing.Size size4 = new System.Drawing.Size(75, 15);
			this.label6.Size = size4;
			this.label6.TabIndex = 10;
			this.label6.Text = "学习方法:";
			this.label6.Visible = false;
			this.numericUpDown_stop.Anchor = AnchorStyles.Left;
			System.Drawing.Point location5 = new System.Drawing.Point(453, 216);
			this.numericUpDown_stop.Location = location5;
			Padding margin5 = new Padding(2);
			this.numericUpDown_stop.Margin = margin5;
			decimal maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				0
			});
			this.numericUpDown_stop.Maximum = maximum;
			decimal minimum = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_stop.Minimum = minimum;
			this.numericUpDown_stop.Name = "numericUpDown_stop";
			System.Drawing.Size size5 = new System.Drawing.Size(75, 24);
			this.numericUpDown_stop.Size = size5;
			this.numericUpDown_stop.TabIndex = 4;
			this.numericUpDown_stop.TextAlign = HorizontalAlignment.Center;
			decimal value = new decimal(new int[]
			{
				64,
				0,
				0,
				0
			});
			this.numericUpDown_stop.Value = value;
			this.numericUpDown_stop.KeyPress += new KeyPressEventHandler(this.numericUpDown_StudyNum_KeyPress);
			this.numericUpDown_stop.KeyUp += new KeyEventHandler(this.numericUpDown_StartEnd_KeyUp);
			this.numericUpDown_dtValue.Anchor = AnchorStyles.Left;
			System.Drawing.Point location6 = new System.Drawing.Point(322, 273);
			this.numericUpDown_dtValue.Location = location6;
			Padding margin6 = new Padding(2);
			this.numericUpDown_dtValue.Margin = margin6;
			decimal maximum2 = new decimal(new int[]
			{
				1500,
				0,
				0,
				0
			});
			this.numericUpDown_dtValue.Maximum = maximum2;
			this.numericUpDown_dtValue.Name = "numericUpDown_dtValue";
			System.Drawing.Size size6 = new System.Drawing.Size(172, 24);
			this.numericUpDown_dtValue.Size = size6;
			this.numericUpDown_dtValue.TabIndex = 5;
			this.numericUpDown_dtValue.TextAlign = HorizontalAlignment.Center;
			decimal value2 = new decimal(new int[]
			{
				1000,
				0,
				0,
				0
			});
			this.numericUpDown_dtValue.Value = value2;
			this.numericUpDown_dtValue.KeyPress += new KeyPressEventHandler(this.numericUpDown_dtValue_KeyPress);
			this.numericUpDown_dtValue.KeyUp += new KeyEventHandler(this.numericUpDown_dtValue_KeyUp);
			this.numericUpDown_start.Anchor = AnchorStyles.Left;
			System.Drawing.Point location7 = new System.Drawing.Point(322, 216);
			this.numericUpDown_start.Location = location7;
			Padding margin7 = new Padding(2);
			this.numericUpDown_start.Margin = margin7;
			decimal maximum3 = new decimal(new int[]
			{
				1023,
				0,
				0,
				0
			});
			this.numericUpDown_start.Maximum = maximum3;
			decimal minimum2 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_start.Minimum = minimum2;
			this.numericUpDown_start.Name = "numericUpDown_start";
			System.Drawing.Size size7 = new System.Drawing.Size(75, 24);
			this.numericUpDown_start.Size = size7;
			this.numericUpDown_start.TabIndex = 3;
			this.numericUpDown_start.TextAlign = HorizontalAlignment.Center;
			decimal value3 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_start.Value = value3;
			this.numericUpDown_start.KeyPress += new KeyPressEventHandler(this.numericUpDown_StudyNum_KeyPress);
			this.numericUpDown_start.KeyUp += new KeyEventHandler(this.numericUpDown_StartEnd_KeyUp);
			this.label_ssMaxValue.Anchor = AnchorStyles.Left;
			this.label_ssMaxValue.AutoSize = true;
			System.Drawing.Point location8 = new System.Drawing.Point(466, 163);
			this.label_ssMaxValue.Location = location8;
			Padding margin8 = new Padding(2, 0, 2, 0);
			this.label_ssMaxValue.Margin = margin8;
			this.label_ssMaxValue.Name = "label_ssMaxValue";
			System.Drawing.Size size8 = new System.Drawing.Size(39, 15);
			this.label_ssMaxValue.Size = size8;
			this.label_ssMaxValue.TabIndex = 0;
			this.label_ssMaxValue.Text = "1024";
			this.label5.Anchor = AnchorStyles.Left;
			this.label5.AutoSize = true;
			System.Drawing.Point location9 = new System.Drawing.Point(347, 163);
			this.label5.Location = location9;
			Padding margin9 = new Padding(2, 0, 2, 0);
			this.label5.Margin = margin9;
			this.label5.Name = "label5";
			System.Drawing.Size size9 = new System.Drawing.Size(15, 15);
			this.label5.Size = size9;
			this.label5.TabIndex = 0;
			this.label5.Text = "1";
			this.label4.Anchor = AnchorStyles.Left;
			this.label4.AutoSize = true;
			System.Drawing.Point location10 = new System.Drawing.Point(407, 163);
			this.label4.Location = location10;
			Padding margin10 = new Padding(2, 0, 2, 0);
			this.label4.Margin = margin10;
			this.label4.Name = "label4";
			System.Drawing.Size size10 = new System.Drawing.Size(37, 15);
			this.label4.Size = size10;
			this.label4.TabIndex = 0;
			this.label4.Text = "——";
			this.label2.Anchor = AnchorStyles.Left;
			this.label2.AutoSize = true;
			System.Drawing.Point location11 = new System.Drawing.Point(407, 220);
			this.label2.Location = location11;
			Padding margin11 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin11;
			this.label2.Name = "label2";
			System.Drawing.Size size11 = new System.Drawing.Size(37, 15);
			this.label2.Size = size11;
			this.label2.TabIndex = 0;
			this.label2.Text = "——";
			this.label3.Anchor = AnchorStyles.Left;
			this.label3.AutoSize = true;
			System.Drawing.Point location12 = new System.Drawing.Point(224, 163);
			this.label3.Location = location12;
			Padding margin12 = new Padding(2, 0, 2, 0);
			this.label3.Margin = margin12;
			this.label3.Name = "label3";
			System.Drawing.Size size12 = new System.Drawing.Size(90, 15);
			this.label3.Size = size12;
			this.label3.TabIndex = 0;
			this.label3.Text = "全学习范围:";
			this.label8.Anchor = AnchorStyles.Left;
			this.label8.AutoSize = true;
			System.Drawing.Point location13 = new System.Drawing.Point(502, 277);
			this.label8.Location = location13;
			Padding margin13 = new Padding(2, 0, 2, 0);
			this.label8.Margin = margin13;
			this.label8.Name = "label8";
			System.Drawing.Size size13 = new System.Drawing.Size(22, 15);
			this.label8.Size = size13;
			this.label8.TabIndex = 0;
			this.label8.Text = "Ω";
			this.label7.Anchor = AnchorStyles.Left;
			this.label7.AutoSize = true;
			System.Drawing.Point location14 = new System.Drawing.Point(238, 277);
			this.label7.Location = location14;
			Padding margin14 = new Padding(2, 0, 2, 0);
			this.label7.Margin = margin14;
			this.label7.Name = "label7";
			System.Drawing.Size size14 = new System.Drawing.Size(75, 15);
			this.label7.Size = size14;
			this.label7.TabIndex = 0;
			this.label7.Text = "导通阈值:";
			this.label1.Anchor = AnchorStyles.Left;
			this.label1.AutoSize = true;
			System.Drawing.Point location15 = new System.Drawing.Point(210, 220);
			this.label1.Location = location15;
			Padding margin15 = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin15;
			this.label1.Name = "label1";
			System.Drawing.Size size15 = new System.Drawing.Size(105, 15);
			this.label1.Size = size15;
			this.label1.TabIndex = 0;
			this.label1.Text = "指定学习范围:";
			this.btnAllStudy.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.btnAllStudy.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location16 = new System.Drawing.Point(352, 513);
			this.btnAllStudy.Location = location16;
			Padding margin16 = new Padding(2);
			this.btnAllStudy.Margin = margin16;
			this.btnAllStudy.Name = "btnAllStudy";
			System.Drawing.Size size16 = new System.Drawing.Size(112, 24);
			this.btnAllStudy.Size = size16;
			this.btnAllStudy.TabIndex = 1;
			this.btnAllStudy.Text = "全学习";
			this.btnAllStudy.UseVisualStyleBackColor = true;
			this.btnAllStudy.Click += new System.EventHandler(this.btnAllStudy_Click);
			this.btnStudy.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.btnStudy.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location17 = new System.Drawing.Point(170, 513);
			this.btnStudy.Location = location17;
			Padding margin17 = new Padding(2);
			this.btnStudy.Margin = margin17;
			this.btnStudy.Name = "btnStudy";
			System.Drawing.Size size17 = new System.Drawing.Size(135, 24);
			this.btnStudy.Size = size17;
			this.btnStudy.TabIndex = 0;
			this.btnStudy.Text = "按指定范围学习";
			this.btnStudy.UseVisualStyleBackColor = true;
			this.btnStudy.Click += new System.EventHandler(this.btnStudy_Click);
			this.btnQuit.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location18 = new System.Drawing.Point(512, 513);
			this.btnQuit.Location = location18;
			Padding margin18 = new Padding(2);
			this.btnQuit.Margin = margin18;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size18 = new System.Drawing.Size(112, 24);
			this.btnQuit.Size = size18;
			this.btnQuit.TabIndex = 2;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.tabControl1.Appearance = TabAppearance.Buttons;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Size itemSize = new System.Drawing.Size(240, 30);
			this.tabControl1.ItemSize = itemSize;
			System.Drawing.Point location19 = new System.Drawing.Point(8, 13);
			this.tabControl1.Location = location19;
			Padding margin19 = new Padding(2);
			this.tabControl1.Margin = margin19;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			System.Drawing.Size size19 = new System.Drawing.Size(779, 471);
			this.tabControl1.Size = size19;
			this.tabControl1.SizeMode = TabSizeMode.Fixed;
			this.tabControl1.TabIndex = 3;
			this.tabPage1.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage1.Controls.Add(this.groupBox1);
			System.Drawing.Point location20 = new System.Drawing.Point(4, 34);
			this.tabPage1.Location = location20;
			Padding margin20 = new Padding(2);
			this.tabPage1.Margin = margin20;
			this.tabPage1.Name = "tabPage1";
			Padding padding2 = new Padding(2);
			this.tabPage1.Padding = padding2;
			System.Drawing.Size size20 = new System.Drawing.Size(771, 433);
			this.tabPage1.Size = size20;
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "根据测试仪针点";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.tabPage2.BorderStyle = BorderStyle.FixedSingle;
			this.tabPage2.Controls.Add(this.radioButton_Plug_FourWire);
			this.tabPage2.Controls.Add(this.radioButton_Plug_TwoWire);
			this.tabPage2.Controls.Add(this.label13);
			this.tabPage2.Controls.Add(this.numericUpDown_Plug_dtValue);
			this.tabPage2.Controls.Add(this.label10);
			this.tabPage2.Controls.Add(this.label11);
			this.tabPage2.Controls.Add(this.dataGridView1);
			this.tabPage2.Controls.Add(this.label12);
			this.tabPage2.Controls.Add(this.label_xsxz);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.comboBox_xsxz);
			this.tabPage2.Controls.Add(this.comboBox_xsjk);
			this.tabPage2.Controls.Add(this.btnDelAll);
			this.tabPage2.Controls.Add(this.btnAddAll);
			this.tabPage2.Controls.Add(this.btnDelOne);
			this.tabPage2.Controls.Add(this.btnAddOne);
			System.Drawing.Point location21 = new System.Drawing.Point(4, 34);
			this.tabPage2.Location = location21;
			Padding margin21 = new Padding(2);
			this.tabPage2.Margin = margin21;
			this.tabPage2.Name = "tabPage2";
			Padding padding3 = new Padding(2);
			this.tabPage2.Padding = padding3;
			System.Drawing.Size size21 = new System.Drawing.Size(771, 433);
			this.tabPage2.Size = size21;
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "根据线束接口";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.radioButton_Plug_FourWire.AutoSize = true;
			this.radioButton_Plug_FourWire.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location22 = new System.Drawing.Point(638, 195);
			this.radioButton_Plug_FourWire.Location = location22;
			Padding margin22 = new Padding(2);
			this.radioButton_Plug_FourWire.Margin = margin22;
			this.radioButton_Plug_FourWire.Name = "radioButton_Plug_FourWire";
			System.Drawing.Size size22 = new System.Drawing.Size(70, 19);
			this.radioButton_Plug_FourWire.Size = size22;
			this.radioButton_Plug_FourWire.TabIndex = 20;
			this.radioButton_Plug_FourWire.Text = "四线法";
			this.radioButton_Plug_FourWire.UseVisualStyleBackColor = true;
			this.radioButton_Plug_FourWire.Visible = false;
			this.radioButton_Plug_TwoWire.AutoSize = true;
			this.radioButton_Plug_TwoWire.Checked = true;
			this.radioButton_Plug_TwoWire.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location23 = new System.Drawing.Point(535, 195);
			this.radioButton_Plug_TwoWire.Location = location23;
			Padding margin23 = new Padding(2);
			this.radioButton_Plug_TwoWire.Margin = margin23;
			this.radioButton_Plug_TwoWire.Name = "radioButton_Plug_TwoWire";
			System.Drawing.Size size23 = new System.Drawing.Size(70, 19);
			this.radioButton_Plug_TwoWire.Size = size23;
			this.radioButton_Plug_TwoWire.TabIndex = 21;
			this.radioButton_Plug_TwoWire.TabStop = true;
			this.radioButton_Plug_TwoWire.Text = "二线法";
			this.radioButton_Plug_TwoWire.UseVisualStyleBackColor = true;
			this.radioButton_Plug_TwoWire.Visible = false;
			this.radioButton_Plug_TwoWire.CheckedChanged += new System.EventHandler(this.radioButton_Plug_TwoWire_CheckedChanged);
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location24 = new System.Drawing.Point(447, 197);
			this.label13.Location = location24;
			Padding margin24 = new Padding(2, 0, 2, 0);
			this.label13.Margin = margin24;
			this.label13.Name = "label13";
			System.Drawing.Size size24 = new System.Drawing.Size(75, 15);
			this.label13.Size = size24;
			this.label13.TabIndex = 19;
			this.label13.Text = "学习方法:";
			this.label13.Visible = false;
			System.Drawing.Point location25 = new System.Drawing.Point(525, 228);
			this.numericUpDown_Plug_dtValue.Location = location25;
			Padding margin25 = new Padding(2);
			this.numericUpDown_Plug_dtValue.Margin = margin25;
			decimal maximum4 = new decimal(new int[]
			{
				1500,
				0,
				0,
				0
			});
			this.numericUpDown_Plug_dtValue.Maximum = maximum4;
			this.numericUpDown_Plug_dtValue.Name = "numericUpDown_Plug_dtValue";
			System.Drawing.Size size25 = new System.Drawing.Size(168, 24);
			this.numericUpDown_Plug_dtValue.Size = size25;
			this.numericUpDown_Plug_dtValue.TabIndex = 18;
			this.numericUpDown_Plug_dtValue.TextAlign = HorizontalAlignment.Center;
			decimal value4 = new decimal(new int[]
			{
				1000,
				0,
				0,
				0
			});
			this.numericUpDown_Plug_dtValue.Value = value4;
			this.numericUpDown_Plug_dtValue.KeyUp += new KeyEventHandler(this.numericUpDown_Plug_dtValue_KeyUp);
			this.label10.AutoSize = true;
			System.Drawing.Point location26 = new System.Drawing.Point(699, 232);
			this.label10.Location = location26;
			Padding margin26 = new Padding(2, 0, 2, 0);
			this.label10.Margin = margin26;
			this.label10.Name = "label10";
			System.Drawing.Size size26 = new System.Drawing.Size(22, 15);
			this.label10.Size = size26;
			this.label10.TabIndex = 17;
			this.label10.Text = "Ω";
			this.label11.AutoSize = true;
			System.Drawing.Point location27 = new System.Drawing.Point(447, 232);
			this.label11.Location = location27;
			Padding margin27 = new Padding(2, 0, 2, 0);
			this.label11.Margin = margin27;
			this.label11.Name = "label11";
			System.Drawing.Size size27 = new System.Drawing.Size(75, 15);
			this.label11.Size = size27;
			this.label11.TabIndex = 16;
			this.label11.Text = "导通阈值:";
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
				this.Column_xh,
				this.Column_startInterface
			};
			this.dataGridView1.Columns.AddRange(dataGridViewColumns);
			System.Drawing.Point location28 = new System.Drawing.Point(15, 50);
			this.dataGridView1.Location = location28;
			Padding margin28 = new Padding(2);
			this.dataGridView1.Margin = margin28;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size28 = new System.Drawing.Size(380, 360);
			this.dataGridView1.Size = size28;
			this.dataGridView1.TabIndex = 15;
			this.Column_xh.HeaderText = "序号";
			this.Column_xh.Name = "Column_xh";
			this.Column_xh.ReadOnly = true;
			this.Column_xh.Width = 76;
			this.Column_startInterface.HeaderText = "学习接口";
			this.Column_startInterface.Name = "Column_startInterface";
			this.Column_startInterface.ReadOnly = true;
			this.Column_startInterface.Width = 280;
			this.label12.AutoSize = true;
			System.Drawing.Point location29 = new System.Drawing.Point(14, 20);
			this.label12.Location = location29;
			Padding margin29 = new Padding(2, 0, 2, 0);
			this.label12.Margin = margin29;
			this.label12.Name = "label12";
			System.Drawing.Size size29 = new System.Drawing.Size(105, 15);
			this.label12.Size = size29;
			this.label12.TabIndex = 1;
			this.label12.Text = "学习接口列表:";
			this.label_xsxz.AutoSize = true;
			System.Drawing.Point location30 = new System.Drawing.Point(441, 20);
			this.label_xsxz.Location = location30;
			Padding margin30 = new Padding(2, 0, 2, 0);
			this.label_xsxz.Margin = margin30;
			this.label_xsxz.Name = "label_xsxz";
			System.Drawing.Size size30 = new System.Drawing.Size(75, 15);
			this.label_xsxz.Size = size30;
			this.label_xsxz.TabIndex = 1;
			this.label_xsxz.Text = "线束选择:";
			this.label_xsxz.Visible = false;
			this.label9.AutoSize = true;
			System.Drawing.Point location31 = new System.Drawing.Point(441, 62);
			this.label9.Location = location31;
			Padding margin31 = new Padding(2, 0, 2, 0);
			this.label9.Margin = margin31;
			this.label9.Name = "label9";
			System.Drawing.Size size31 = new System.Drawing.Size(75, 15);
			this.label9.Size = size31;
			this.label9.TabIndex = 1;
			this.label9.Text = "接口选择:";
			this.comboBox_xsxz.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_xsxz.FormattingEnabled = true;
			System.Drawing.Point location32 = new System.Drawing.Point(525, 16);
			this.comboBox_xsxz.Location = location32;
			Padding margin32 = new Padding(2);
			this.comboBox_xsxz.Margin = margin32;
			this.comboBox_xsxz.Name = "comboBox_xsxz";
			System.Drawing.Size size32 = new System.Drawing.Size(196, 22);
			this.comboBox_xsxz.Size = size32;
			this.comboBox_xsxz.TabIndex = 0;
			this.comboBox_xsxz.Visible = false;
			this.comboBox_xsxz.SelectedIndexChanged += new System.EventHandler(this.comboBox_xsxz_SelectedIndexChanged);
			this.comboBox_xsjk.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_xsjk.FormattingEnabled = true;
			System.Drawing.Point location33 = new System.Drawing.Point(525, 59);
			this.comboBox_xsjk.Location = location33;
			Padding margin33 = new Padding(2);
			this.comboBox_xsjk.Margin = margin33;
			this.comboBox_xsjk.Name = "comboBox_xsjk";
			System.Drawing.Size size33 = new System.Drawing.Size(196, 22);
			this.comboBox_xsjk.Size = size33;
			this.comboBox_xsjk.TabIndex = 0;
			this.btnDelAll.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location34 = new System.Drawing.Point(523, 347);
			this.btnDelAll.Location = location34;
			Padding margin34 = new Padding(2);
			this.btnDelAll.Margin = margin34;
			this.btnDelAll.Name = "btnDelAll";
			System.Drawing.Size size34 = new System.Drawing.Size(195, 24);
			this.btnDelAll.Size = size34;
			this.btnDelAll.TabIndex = 1;
			this.btnDelAll.Text = "清空线束接口列表";
			this.btnDelAll.UseVisualStyleBackColor = true;
			this.btnDelAll.Click += new System.EventHandler(this.btnDelAll_Click);
			this.btnAddAll.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location35 = new System.Drawing.Point(525, 158);
			this.btnAddAll.Location = location35;
			Padding margin35 = new Padding(2);
			this.btnAddAll.Margin = margin35;
			this.btnAddAll.Name = "btnAddAll";
			System.Drawing.Size size35 = new System.Drawing.Size(195, 24);
			this.btnAddAll.Size = size35;
			this.btnAddAll.TabIndex = 1;
			this.btnAddAll.Text = "添加所有接口到列表";
			this.btnAddAll.UseVisualStyleBackColor = true;
			this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
			this.btnDelOne.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location36 = new System.Drawing.Point(525, 296);
			this.btnDelOne.Location = location36;
			Padding margin36 = new Padding(2);
			this.btnDelOne.Margin = margin36;
			this.btnDelOne.Name = "btnDelOne";
			System.Drawing.Size size36 = new System.Drawing.Size(195, 24);
			this.btnDelOne.Size = size36;
			this.btnDelOne.TabIndex = 1;
			this.btnDelOne.Text = "删除列表中选中接口";
			this.btnDelOne.UseVisualStyleBackColor = true;
			this.btnDelOne.Click += new System.EventHandler(this.btnDelOne_Click);
			this.btnAddOne.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location37 = new System.Drawing.Point(525, 107);
			this.btnAddOne.Location = location37;
			Padding margin37 = new Padding(2);
			this.btnAddOne.Margin = margin37;
			this.btnAddOne.Name = "btnAddOne";
			System.Drawing.Size size37 = new System.Drawing.Size(195, 24);
			this.btnAddOne.Size = size37;
			this.btnAddOne.TabIndex = 1;
			this.btnAddOne.Text = "添加单个接口到列表";
			this.btnAddOne.UseVisualStyleBackColor = true;
			this.btnAddOne.Click += new System.EventHandler(this.btnAddOne_Click);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.tabControl1);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnStudy);
			base.Controls.Add(this.btnAllStudy);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin38 = new Padding(2);
			base.Margin = margin38;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormSelfStudy";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "自学习参数设置";
			base.Load += new System.EventHandler(this.ctFormSelfStudy_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((ISupportInitialize)this.numericUpDown_stop).EndInit();
			((ISupportInitialize)this.numericUpDown_dtValue).EndInit();
			((ISupportInitialize)this.numericUpDown_start).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((ISupportInitialize)this.numericUpDown_Plug_dtValue).EndInit();
			((ISupportInitialize)this.dataGridView1).EndInit();
			base.ResumeLayout(false);
		}
		private void numericUpDown_StudyNum_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '\b')
			{
				e.Handled = false;
			}
			else
			{
				e.Handled = true;
			}
		}
		private void numericUpDown_StartEnd_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_start.Text.ToString();
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dTemp = System.Convert.ToDouble(tempStr);
					int sELF_MAX_COUNT = this.gLineTestProcessor.SELF_MAX_COUNT;
					if (dTemp > (double)sELF_MAX_COUNT)
					{
						MessageBox.Show("参数范围设置错误，只能设置在1至" + System.Convert.ToInt32(sELF_MAX_COUNT) + "范围内!", "提示", MessageBoxButtons.OK);
						return;
					}
				}
				tempStr = this.numericUpDown_stop.Text.ToString();
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dTemp = System.Convert.ToDouble(tempStr);
					int e2 = this.gLineTestProcessor.SELF_MAX_COUNT;
					if (dTemp > (double)e2)
					{
						MessageBox.Show("参数范围设置错误，只能设置在1至" + System.Convert.ToInt32(e2) + "范围内!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_BE_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_BE_0.StackTrace);
			}
		}
		private void numericUpDown_dtValue_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '\b')
			{
				e.Handled = false;
			}
			else
			{
				e.Handled = true;
			}
		}
		private void numericUpDown_dtValue_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_dtValue.Text.ToString();
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dTemp = System.Convert.ToDouble(tempStr);
					double dTemp2 = System.Convert.ToDouble(this.numericUpDown_dtValue.Maximum);
					if (dTemp > dTemp2)
					{
						MessageBox.Show("导通阈值设置异常，请重新输入!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_4A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_4A_0.StackTrace);
			}
		}
		private void btnAllStudy_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.gLineTestProcessor.bAllStudyFlag = true;
				bool sender2;
				if (0 == this.tabControl1.SelectedIndex)
				{
					double dDTLValue = System.Convert.ToDouble(this.numericUpDown_dtValue.Value);
					this.gLineTestProcessor.iTwoFourWireChoice = 2;
					this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyPinNum = 0;
					KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
					int sELF_MAX_COUNT = kLineTestProcessor.SELF_MAX_COUNT;
					KParseRepCmd arg_72_0 = kLineTestProcessor.mpDevComm.mParseCmd;
					int expr_70 = sELF_MAX_COUNT;
					arg_72_0.selfStudyCount = expr_70 * expr_70;
					KLineTestProcessor kLineTestProcessor2 = this.gLineTestProcessor;
					ctFormSelfStudyPinRelation ctFormSelfStudyPinRelation = new ctFormSelfStudyPinRelation(kLineTestProcessor2, this.loginUser, 1, kLineTestProcessor2.SELF_MAX_COUNT, System.Convert.ToInt32(dDTLValue));
					this.selfStudyPinRelationForm = ctFormSelfStudyPinRelation;
					ctFormSelfStudyPinRelation.Activate();
					this.selfStudyPinRelationForm.ShowDialog();
					sender2 = this.selfStudyPinRelationForm.bImportFlag;
					this.bImportFlag = sender2;
				}
				else
				{
					int iRowCount = this.comboBox_xsjk.Items.Count;
					if (iRowCount <= 0)
					{
						MessageBox.Show("学习接口为空!", "提示", MessageBoxButtons.OK);
						return;
					}
					double dDTLValue2 = System.Convert.ToDouble(this.numericUpDown_Plug_dtValue.Value);
					this.gLineTestProcessor.iTwoFourWireChoice = 2;
					this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyPinNum = 0;
					this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyCount = 0;
					string[] studyPlugStrArray = new string[iRowCount];
					for (int i = 0; i < iRowCount; i++)
					{
						studyPlugStrArray[i] = this.comboBox_xsjk.Items[i].ToString();
					}
					ctFormSelfStudyPinRelation ctFormSelfStudyPinRelation2 = new ctFormSelfStudyPinRelation(this.gLineTestProcessor, this.loginUser, studyPlugStrArray, System.Convert.ToInt32(dDTLValue2));
					this.selfStudyPinRelationForm = ctFormSelfStudyPinRelation2;
					ctFormSelfStudyPinRelation2.Activate();
					this.selfStudyPinRelationForm.ShowDialog();
					sender2 = this.selfStudyPinRelationForm.bImportFlag;
					this.bImportFlag = sender2;
				}
				if (sender2)
				{
					base.Close();
				}
			}
			catch (System.Exception arg_1C5_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1C5_0.StackTrace);
			}
		}
		private void btnStudy_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.gLineTestProcessor.bAllStudyFlag = false;
				bool sender2;
				if (0 == this.tabControl1.SelectedIndex)
				{
					int iStart = System.Convert.ToInt32(this.numericUpDown_start.Value);
					int iEnd = System.Convert.ToInt32(this.numericUpDown_stop.Value);
					if (iStart < iEnd)
					{
						int sELF_MAX_COUNT = this.gLineTestProcessor.SELF_MAX_COUNT;
						if (iStart <= sELF_MAX_COUNT && iEnd <= sELF_MAX_COUNT)
						{
							double dDTLValue = System.Convert.ToDouble(this.numericUpDown_dtValue.Value);
							this.gLineTestProcessor.iTwoFourWireChoice = 2;
							if (this.radioButton_Pin_FourWire.Checked)
							{
								this.gLineTestProcessor.iTwoFourWireChoice = 4;
							}
							this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyPinNum = 0;
							int iTemp = System.Math.Abs(iEnd - iStart + 1);
							KParseRepCmd arg_D0_0 = this.gLineTestProcessor.mpDevComm.mParseCmd;
							int expr_CE = iTemp;
							arg_D0_0.selfStudyCount = expr_CE * expr_CE;
							ctFormSelfStudyPinRelation ctFormSelfStudyPinRelation = new ctFormSelfStudyPinRelation(this.gLineTestProcessor, this.loginUser, iStart, iEnd, System.Convert.ToInt32(dDTLValue));
							this.selfStudyPinRelationForm = ctFormSelfStudyPinRelation;
							ctFormSelfStudyPinRelation.Activate();
							this.selfStudyPinRelationForm.ShowDialog();
							sender2 = this.selfStudyPinRelationForm.bImportFlag;
							this.bImportFlag = sender2;
							goto IL_262;
						}
					}
					MessageBox.Show("参数范围设置错误，只能设置在1至" + System.Convert.ToInt32(this.gLineTestProcessor.SELF_MAX_COUNT) + "范围内，并且后者大于前者!", "提示", MessageBoxButtons.OK);
					return;
				}
				int iRowCount = this.dataGridView1.Rows.Count;
				if (iRowCount <= 0)
				{
					MessageBox.Show("学习接口列表为空!", "提示", MessageBoxButtons.OK);
					return;
				}
				double dDTLValue2 = System.Convert.ToDouble(this.numericUpDown_Plug_dtValue.Value);
				this.gLineTestProcessor.iTwoFourWireChoice = 2;
				if (this.radioButton_Plug_FourWire.Checked)
				{
					this.gLineTestProcessor.iTwoFourWireChoice = 4;
				}
				this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyPinNum = 0;
				string[] studyPlugStrArray = new string[iRowCount];
				for (int i = 0; i < iRowCount; i++)
				{
					studyPlugStrArray[i] = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
				}
				ctFormSelfStudyPinRelation ctFormSelfStudyPinRelation2 = new ctFormSelfStudyPinRelation(this.gLineTestProcessor, this.loginUser, studyPlugStrArray, System.Convert.ToInt32(dDTLValue2));
				this.selfStudyPinRelationForm = ctFormSelfStudyPinRelation2;
				ctFormSelfStudyPinRelation2.Activate();
				this.selfStudyPinRelationForm.ShowDialog();
				sender2 = this.selfStudyPinRelationForm.bImportFlag;
				this.bImportFlag = sender2;
				IL_262:
				if (sender2)
				{
					base.Close();
				}
			}
			catch (System.Exception arg_26D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_26D_0.StackTrace);
			}
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			this.bImportFlag = false;
			base.Close();
		}
		private void ctFormSelfStudy_Load(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.bImportFlag = false;
				this.comboBox_xsjk.Items.Clear();
				this.comboBox_xsxz.Items.Clear();
				decimal maximum = this.gLineTestProcessor.SELF_MAX_COUNT;
				this.numericUpDown_start.Maximum = maximum;
				decimal maximum2 = this.gLineTestProcessor.SELF_MAX_COUNT;
				this.numericUpDown_stop.Maximum = maximum2;
				this.label_ssMaxValue.Text = System.Convert.ToString(this.gLineTestProcessor.SELF_MAX_COUNT);
				if (!this.gLineTestProcessor.bOpenProjectFlag)
				{
					this.label_xsxz.Visible = true;
					this.comboBox_xsxz.Visible = true;
				}
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
			catch (System.Exception arg_13C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_13C_0.StackTrace);
			}
			try
			{
				string tempStr = "";
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					if (!this.gLineTestProcessor.bOpenProjectFlag)
					{
						string sqlcommand = "select * from TLineStructLibrary order by LID";
						OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						while (dataReader.Read())
						{
							this.comboBox_xsxz.Items.Add(dataReader["LineStructName"].ToString());
						}
					}
					else
					{
						string sqlcommand = "select * from TLineStructLibrary where LineStructName='" + this.bcCableStr + "'";
						OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						while (dataReader.Read())
						{
							tempStr = dataReader["PlugInfo"].ToString();
						}
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_21A_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_21A_0.StackTrace);
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
				if (!this.gLineTestProcessor.bOpenProjectFlag)
				{
					this.comboBox_xsxz.SelectedIndex = -1;
					this.comboBox_xsjk.SelectedIndex = -1;
				}
				else
				{
					if (!string.IsNullOrEmpty(tempStr))
					{
						string[] tempStrArray = tempStr.Split(new char[]
						{
							','
						});
						for (int k = 0; k < tempStrArray.Length; k++)
						{
							if (!string.IsNullOrEmpty(tempStrArray[k]))
							{
								this.comboBox_xsjk.Items.Add(tempStrArray[k]);
							}
						}
					}
					if (this.comboBox_xsjk.Items.Count > 0)
					{
						this.comboBox_xsjk.SelectedIndex = 0;
					}
				}
			}
			catch (System.Exception arg_2DE_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2DE_0.StackTrace);
			}
		}
		private void numericUpDown_Plug_dtValue_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_Plug_dtValue.Text.ToString();
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dTemp = System.Convert.ToDouble(tempStr);
					double dTemp2 = System.Convert.ToDouble(this.numericUpDown_Plug_dtValue.Maximum);
					if (dTemp > dTemp2)
					{
						MessageBox.Show("导通阈值设置异常，请重新输入!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_4A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_4A_0.StackTrace);
			}
		}
		private void btnAddOne_Click(object sender, System.EventArgs e)
		{
			try
			{
				string tempStr = "";
				string tempCPStr = this.comboBox_xsjk.Text.ToString();
				int iIndex = this.dataGridView1.Rows.Count;
				for (int i = 0; i < iIndex; i++)
				{
					if (this.dataGridView1.Rows[i].Cells[1].Value != null)
					{
						tempStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
					}
					if (tempStr == tempCPStr)
					{
						MessageBox.Show("接口已添加，请勿重复操作!", "提示", MessageBoxButtons.OK);
						return;
					}
				}
				this.dataGridView1.AllowUserToAddRows = true;
				this.dataGridView1.Rows.Add(1);
				this.dataGridView1.Rows[iIndex].Cells[0].Value = System.Convert.ToString(iIndex + 1);
				this.dataGridView1.Rows[iIndex].Cells[1].Value = tempCPStr;
				this.dataGridView1.AllowUserToAddRows = false;
				int iLastIndex = this.dataGridView1.Rows.Count - 1;
				if (iLastIndex >= 0)
				{
					this.dataGridView1.Rows[iLastIndex].Selected = true;
				}
			}
			catch (System.Exception arg_145_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_145_0.StackTrace);
			}
		}
		private void btnAddAll_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.dataGridView1.Rows.Clear();
				int iIndex = this.comboBox_xsjk.Items.Count;
				int e2;
				for (int i = 0; i < iIndex; i = e2)
				{
					string tempCPStr = this.comboBox_xsjk.Items[i].ToString();
					this.dataGridView1.AllowUserToAddRows = true;
					this.dataGridView1.Rows.Add(1);
					e2 = i + 1;
					this.dataGridView1.Rows[i].Cells[0].Value = System.Convert.ToString(e2);
					this.dataGridView1.Rows[i].Cells[1].Value = tempCPStr;
					this.dataGridView1.AllowUserToAddRows = false;
				}
				int iLastIndex = this.dataGridView1.Rows.Count - 1;
				if (iLastIndex >= 0)
				{
					this.dataGridView1.Rows[iLastIndex].Selected = true;
				}
			}
			catch (System.Exception arg_FF_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_FF_0.StackTrace);
			}
		}
		private void btnDelOne_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dataGridView1.Rows.Count > 0 && this.dataGridView1.SelectedRows.Count > 0)
				{
					string tempStr = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
					this.dataGridView1.Rows.RemoveAt(System.Convert.ToInt32(tempStr) - 1);
					int inum = this.dataGridView1.Rows.Count;
					int sender2;
					for (int i = 0; i < inum; i = sender2)
					{
						sender2 = i + 1;
						this.dataGridView1.Rows[i].Cells[0].Value = System.Convert.ToString(sender2);
					}
				}
				else
				{
					MessageBox.Show("没有选中线束接口列表接口!", "提示", MessageBoxButtons.OK);
				}
			}
			catch (System.Exception arg_C6_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_C6_0.StackTrace);
			}
		}
		private void btnDelAll_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.dataGridView1.Rows.Clear();
			}
			catch (System.Exception arg_12_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_12_0.StackTrace);
			}
		}
		private void radioButton_Pin_TwoWire_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.radioButton_Pin_FourWire.Checked)
			{
				decimal sender2 = System.Convert.ToDecimal(50);
				this.numericUpDown_dtValue.Maximum = sender2;
			}
			else
			{
				decimal this2 = System.Convert.ToDecimal(1500);
				this.numericUpDown_dtValue.Maximum = this2;
			}
		}
		private void radioButton_Plug_TwoWire_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.radioButton_Plug_FourWire.Checked)
			{
				decimal sender2 = System.Convert.ToDecimal(50);
				this.numericUpDown_Plug_dtValue.Maximum = sender2;
			}
			else
			{
				decimal this2 = System.Convert.ToDecimal(1500);
				this.numericUpDown_Plug_dtValue.Maximum = this2;
			}
		}
		private void comboBox_xsxz_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				if (!this.gLineTestProcessor.bOpenProjectFlag)
				{
					this.comboBox_xsjk.Items.Clear();
					string seleCableStr = this.comboBox_xsxz.Text.ToString();
					if (!string.IsNullOrEmpty(seleCableStr))
					{
						string tempStr = "";
						try
						{
							connection = new OleDbConnection();
							connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
							connection.Open();
							dataReader = new OleDbCommand("select * from TLineStructLibrary where LineStructName='" + seleCableStr + "'", connection).ExecuteReader();
							while (dataReader.Read())
							{
								tempStr = dataReader["PlugInfo"].ToString();
							}
							dataReader.Close();
							dataReader = null;
							connection.Close();
							connection = null;
						}
						catch (System.Exception arg_BA_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_BA_0.StackTrace);
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
						if (!string.IsNullOrEmpty(tempStr))
						{
							string[] tempStrArray = tempStr.Split(new char[]
							{
								','
							});
							for (int i = 0; i < tempStrArray.Length; i++)
							{
								if (!string.IsNullOrEmpty(tempStrArray[i]))
								{
									this.comboBox_xsjk.Items.Add(tempStrArray[i]);
								}
							}
						}
						if (this.comboBox_xsjk.Items.Count > 0)
						{
							this.comboBox_xsjk.SelectedIndex = 0;
						}
					}
				}
			}
			catch (System.Exception arg_150_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_150_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormSelfStudy();
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
