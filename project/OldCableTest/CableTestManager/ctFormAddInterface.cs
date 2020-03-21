using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormAddInterface : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public ctFormInterfaceTypeImportPin interfaceTypeImportPinForm;
		public ctFormBatchAddABC batchAddPinForm;
		public static string TEST_TWOWIRE_METHOD = "二线法";
		public static string TEST_FOURWIRE_METHOD = "四线法";
		public string dbpath;
		public string loginUser;
		public int iInterfaceName;
		public string currSelectedRowStr;
		public string currSelectedPinStr;
		public string currSelectedZJDStr;
		public string exportPathStr;
		public string addPlugStr;
		public string connNameStr;
		public string letterStr;
		public int iStartNum;
		public bool bAddSuccFlag;
		public int iLastZJTPin;
		public int iMAX_DX_NUM;
		public int iMAX_XX_NUM;
		public string[] AZArray;
		public string[] azArray;
		private ComboBox comboBox_MeasMethod;
		private ComboBox comboBox_csyzdh_FourWire;
		private ComboBox comboBox_csyzdhTemplate_FourWire;
		private RadioButton radioButton_Pin_FourWire;
		private RadioButton radioButton_Pin_TwoWire;
		private Label label6;
		private Button btnExport;
		private FolderBrowserDialog folderBrowserDialog1;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column_PinName;
		private DataGridViewTextBoxColumn Column_csyzdh;
		private DataGridViewTextBoxColumn Column_MeasuringMethod;
		private Button btnDelAllPin;
		private OpenFileDialog openFileDialog1;
		private Button btnSubmit;
		private Label label2;
		private GroupBox groupBox1;
		private DataGridView dataGridView1;
		private TextBox textBox_InterfaceNo;
		private Button btnQuit;
		private TextBox textBox_Remark;
		private Label label1;
		private GroupBox groupBox2;
		private TextBox textBox_StartPin;
		private Label label_csyzdh;
		private Label label_StartPin;
		private NumericUpDown numericUpDown_csyzdh;
		private Button btnFileToImportPin;
		private Button btnBatchAddPin;
		private Button btnAddPin;
		private Button btnInterfaceTypeImportPin;
		private Button btnDelPin;
		private TextBox textBox_pinTemplate;
		private NumericUpDown numericUpDown_csyzdhTemplate;
		private Container components;
		public ctFormAddInterface(KLineTestProcessor gltProcessor, string lUser, int iLZJTPin)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = lUser;
					this.iLastZJTPin = iLZJTPin;
					this.addPlugStr = "";
					this.connNameStr = "";
					this.letterStr = "";
					this.iStartNum = 1;
					int i = 0;
					while (true)
					{
						int iLZJTPin2 = i + 2;
						if (iLZJTPin2 > this.gLineTestProcessor.SELF_MAX_COUNT)
						{
							break;
						}
						int lUser2 = i + 1;
						string tempStr = System.Convert.ToString(lUser2) + "," + System.Convert.ToString(iLZJTPin2);
						this.comboBox_csyzdh_FourWire.Items.Add(tempStr);
						this.comboBox_csyzdhTemplate_FourWire.Items.Add(tempStr);
						i = lUser2;
						i++;
					}
				}
				catch (System.Exception arg_C6_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_C6_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		public ctFormAddInterface(KLineTestProcessor gltProcessor, string lUser)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = lUser;
					this.addPlugStr = "";
					this.connNameStr = "";
					this.letterStr = "";
					this.iStartNum = 1;
					int i = 0;
					while (true)
					{
						int num = i + 2;
						if (num > this.gLineTestProcessor.SELF_MAX_COUNT)
						{
							break;
						}
						int lUser2 = i + 1;
						string tempStr = System.Convert.ToString(lUser2) + "," + System.Convert.ToString(num);
						this.comboBox_csyzdh_FourWire.Items.Add(tempStr);
						this.comboBox_csyzdhTemplate_FourWire.Items.Add(tempStr);
						i = lUser2;
						i++;
					}
				}
				catch (System.Exception arg_BF_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_BF_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormAddInterface()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormAddInterface));
			this.btnSubmit = new Button();
			this.label2 = new Label();
			this.groupBox1 = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column_PinName = new DataGridViewTextBoxColumn();
			this.Column_csyzdh = new DataGridViewTextBoxColumn();
			this.Column_MeasuringMethod = new DataGridViewTextBoxColumn();
			this.textBox_InterfaceNo = new TextBox();
			this.btnQuit = new Button();
			this.textBox_Remark = new TextBox();
			this.label1 = new Label();
			this.groupBox2 = new GroupBox();
			this.comboBox_csyzdh_FourWire = new ComboBox();
			this.radioButton_Pin_FourWire = new RadioButton();
			this.numericUpDown_csyzdh = new NumericUpDown();
			this.radioButton_Pin_TwoWire = new RadioButton();
			this.label6 = new Label();
			this.textBox_StartPin = new TextBox();
			this.label_csyzdh = new Label();
			this.btnBatchAddPin = new Button();
			this.label_StartPin = new Label();
			this.btnAddPin = new Button();
			this.btnFileToImportPin = new Button();
			this.btnInterfaceTypeImportPin = new Button();
			this.btnDelPin = new Button();
			this.openFileDialog1 = new OpenFileDialog();
			this.textBox_pinTemplate = new TextBox();
			this.numericUpDown_csyzdhTemplate = new NumericUpDown();
			this.btnDelAllPin = new Button();
			this.btnExport = new Button();
			this.folderBrowserDialog1 = new FolderBrowserDialog();
			this.comboBox_csyzdhTemplate_FourWire = new ComboBox();
			this.comboBox_MeasMethod = new ComboBox();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_csyzdh).BeginInit();
			((ISupportInitialize)this.numericUpDown_csyzdhTemplate).BeginInit();
			base.SuspendLayout();
			this.btnSubmit.Anchor = AnchorStyles.Bottom;
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(264, 530);
			this.btnSubmit.Location = location;
			Padding margin = new Padding(2);
			this.btnSubmit.Margin = margin;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size = new System.Drawing.Size(112, 24);
			this.btnSubmit.Size = size;
			this.btnSubmit.TabIndex = 0;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSaveInterface_Click);
			this.label2.Anchor = AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(73, 20);
			this.label2.Location = location2;
			Padding margin2 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin2;
			this.label2.Name = "label2";
			System.Drawing.Size size2 = new System.Drawing.Size(75, 15);
			this.label2.Size = size2;
			this.label2.TabIndex = 2;
			this.label2.Text = "接口代号:";
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(14, 216);
			this.groupBox1.Location = location3;
			Padding margin3 = new Padding(2);
			this.groupBox1.Margin = margin3;
			this.groupBox1.Name = "groupBox1";
			Padding padding = new Padding(2);
			this.groupBox1.Padding = padding;
			System.Drawing.Size size3 = new System.Drawing.Size(767, 300);
			this.groupBox1.Size = size3;
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "接点定义表";
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
				this.Column_PinName,
				this.Column_csyzdh,
				this.Column_MeasuringMethod
			};
			this.dataGridView1.Columns.AddRange(dataGridViewColumns);
			this.dataGridView1.Dock = DockStyle.Fill;
			System.Drawing.Point location4 = new System.Drawing.Point(2, 19);
			this.dataGridView1.Location = location4;
			Padding margin4 = new Padding(2);
			this.dataGridView1.Margin = margin4;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size4 = new System.Drawing.Size(763, 279);
			this.dataGridView1.Size = size4;
			this.dataGridView1.TabIndex = 12;
			this.dataGridView1.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
			this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
			this.dataGridView1.KeyPress += new KeyPressEventHandler(this.dataGridView1_KeyPress);
			this.dataGridView1.MouseClick += new MouseEventHandler(this.dataGridView1_MouseClick);
			this.Column1.HeaderText = "序号";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 70;
			this.Column_PinName.HeaderText = "接点名称";
			this.Column_PinName.Name = "Column_PinName";
			this.Column_PinName.ReadOnly = true;
			this.Column_PinName.Width = 200;
			this.Column_csyzdh.HeaderText = "测试仪针脚号";
			this.Column_csyzdh.Name = "Column_csyzdh";
			this.Column_csyzdh.ReadOnly = true;
			this.Column_csyzdh.Width = 232;
			this.Column_MeasuringMethod.HeaderText = "测量方法";
			this.Column_MeasuringMethod.Name = "Column_MeasuringMethod";
			this.Column_MeasuringMethod.ReadOnly = true;
			this.Column_MeasuringMethod.Width = 150;
			this.textBox_InterfaceNo.Anchor = AnchorStyles.Top;
			this.textBox_InterfaceNo.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(155, 16);
			this.textBox_InterfaceNo.Location = location5;
			Padding margin5 = new Padding(2);
			this.textBox_InterfaceNo.Margin = margin5;
			this.textBox_InterfaceNo.MaxLength = 120;
			this.textBox_InterfaceNo.Name = "textBox_InterfaceNo";
			System.Drawing.Size size5 = new System.Drawing.Size(248, 24);
			this.textBox_InterfaceNo.Size = size5;
			this.textBox_InterfaceNo.TabIndex = 3;
			this.textBox_InterfaceNo.TextAlign = HorizontalAlignment.Center;
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(418, 530);
			this.btnQuit.Location = location6;
			Padding margin6 = new Padding(2);
			this.btnQuit.Margin = margin6;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size6 = new System.Drawing.Size(112, 24);
			this.btnQuit.Size = size6;
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.textBox_Remark.Anchor = AnchorStyles.Top;
			this.textBox_Remark.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(498, 16);
			this.textBox_Remark.Location = location7;
			Padding margin7 = new Padding(2);
			this.textBox_Remark.Margin = margin7;
			this.textBox_Remark.MaxLength = 120;
			this.textBox_Remark.Name = "textBox_Remark";
			System.Drawing.Size size7 = new System.Drawing.Size(226, 24);
			this.textBox_Remark.Size = size7;
			this.textBox_Remark.TabIndex = 5;
			this.textBox_Remark.TextAlign = HorizontalAlignment.Center;
			this.label1.Anchor = AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(442, 20);
			this.label1.Location = location8;
			Padding margin8 = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin8;
			this.label1.Name = "label1";
			System.Drawing.Size size8 = new System.Drawing.Size(45, 15);
			this.label1.Size = size8;
			this.label1.TabIndex = 4;
			this.label1.Text = "备注:";
			this.groupBox2.Anchor = AnchorStyles.Top;
			this.groupBox2.Controls.Add(this.comboBox_csyzdh_FourWire);
			this.groupBox2.Controls.Add(this.radioButton_Pin_FourWire);
			this.groupBox2.Controls.Add(this.numericUpDown_csyzdh);
			this.groupBox2.Controls.Add(this.radioButton_Pin_TwoWire);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.textBox_StartPin);
			this.groupBox2.Controls.Add(this.label_csyzdh);
			this.groupBox2.Controls.Add(this.btnBatchAddPin);
			this.groupBox2.Controls.Add(this.label_StartPin);
			this.groupBox2.Controls.Add(this.btnAddPin);
			this.groupBox2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(14, 83);
			this.groupBox2.Location = location9;
			Padding margin9 = new Padding(2);
			this.groupBox2.Margin = margin9;
			this.groupBox2.Name = "groupBox2";
			Padding padding2 = new Padding(2);
			this.groupBox2.Padding = padding2;
			System.Drawing.Size size9 = new System.Drawing.Size(768, 88);
			this.groupBox2.Size = size9;
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "接点定义添加";
			this.comboBox_csyzdh_FourWire.Anchor = AnchorStyles.Top;
			this.comboBox_csyzdh_FourWire.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_csyzdh_FourWire.FormattingEnabled = true;
			System.Drawing.Point location10 = new System.Drawing.Point(146, 55);
			this.comboBox_csyzdh_FourWire.Location = location10;
			Padding margin10 = new Padding(2);
			this.comboBox_csyzdh_FourWire.Margin = margin10;
			this.comboBox_csyzdh_FourWire.Name = "comboBox_csyzdh_FourWire";
			System.Drawing.Size size10 = new System.Drawing.Size(151, 22);
			this.comboBox_csyzdh_FourWire.Size = size10;
			this.comboBox_csyzdh_FourWire.TabIndex = 25;
			this.comboBox_csyzdh_FourWire.Visible = false;
			this.radioButton_Pin_FourWire.Anchor = AnchorStyles.Top;
			this.radioButton_Pin_FourWire.AutoSize = true;
			this.radioButton_Pin_FourWire.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location11 = new System.Drawing.Point(493, 39);
			this.radioButton_Pin_FourWire.Location = location11;
			Padding margin11 = new Padding(2);
			this.radioButton_Pin_FourWire.Margin = margin11;
			this.radioButton_Pin_FourWire.Name = "radioButton_Pin_FourWire";
			System.Drawing.Size size11 = new System.Drawing.Size(70, 19);
			this.radioButton_Pin_FourWire.Size = size11;
			this.radioButton_Pin_FourWire.TabIndex = 23;
			this.radioButton_Pin_FourWire.Text = "四线法";
			this.radioButton_Pin_FourWire.UseVisualStyleBackColor = true;
			this.numericUpDown_csyzdh.Anchor = AnchorStyles.Top;
			System.Drawing.Point location12 = new System.Drawing.Point(146, 54);
			this.numericUpDown_csyzdh.Location = location12;
			Padding margin12 = new Padding(2);
			this.numericUpDown_csyzdh.Margin = margin12;
			decimal maximum = new decimal(new int[]
			{
				1024,
				0,
				0,
				0
			});
			this.numericUpDown_csyzdh.Maximum = maximum;
			decimal minimum = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_csyzdh.Minimum = minimum;
			this.numericUpDown_csyzdh.Name = "numericUpDown_csyzdh";
			System.Drawing.Size size12 = new System.Drawing.Size(150, 24);
			this.numericUpDown_csyzdh.Size = size12;
			this.numericUpDown_csyzdh.TabIndex = 7;
			this.numericUpDown_csyzdh.TextAlign = HorizontalAlignment.Center;
			decimal value = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_csyzdh.Value = value;
			this.numericUpDown_csyzdh.KeyPress += new KeyPressEventHandler(this.numericUpDown_csyzdh_KeyPress);
			this.numericUpDown_csyzdh.KeyUp += new KeyEventHandler(this.numericUpDown_csyzdh_KeyUp);
			this.radioButton_Pin_TwoWire.Anchor = AnchorStyles.Top;
			this.radioButton_Pin_TwoWire.AutoSize = true;
			this.radioButton_Pin_TwoWire.Checked = true;
			this.radioButton_Pin_TwoWire.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location13 = new System.Drawing.Point(410, 39);
			this.radioButton_Pin_TwoWire.Location = location13;
			Padding margin13 = new Padding(2);
			this.radioButton_Pin_TwoWire.Margin = margin13;
			this.radioButton_Pin_TwoWire.Name = "radioButton_Pin_TwoWire";
			System.Drawing.Size size13 = new System.Drawing.Size(70, 19);
			this.radioButton_Pin_TwoWire.Size = size13;
			this.radioButton_Pin_TwoWire.TabIndex = 24;
			this.radioButton_Pin_TwoWire.TabStop = true;
			this.radioButton_Pin_TwoWire.Text = "二线法";
			this.radioButton_Pin_TwoWire.UseVisualStyleBackColor = true;
			this.radioButton_Pin_TwoWire.CheckedChanged += new System.EventHandler(this.radioButton_Pin_TwoWire_CheckedChanged);
			this.label6.Anchor = AnchorStyles.Top;
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location14 = new System.Drawing.Point(326, 41);
			this.label6.Location = location14;
			Padding margin14 = new Padding(2, 0, 2, 0);
			this.label6.Margin = margin14;
			this.label6.Name = "label6";
			System.Drawing.Size size14 = new System.Drawing.Size(75, 15);
			this.label6.Size = size14;
			this.label6.TabIndex = 22;
			this.label6.Text = "测量方法:";
			this.textBox_StartPin.Anchor = AnchorStyles.Top;
			this.textBox_StartPin.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location15 = new System.Drawing.Point(146, 19);
			this.textBox_StartPin.Location = location15;
			Padding margin15 = new Padding(2);
			this.textBox_StartPin.Margin = margin15;
			this.textBox_StartPin.MaxLength = 120;
			this.textBox_StartPin.Name = "textBox_StartPin";
			System.Drawing.Size size15 = new System.Drawing.Size(151, 24);
			this.textBox_StartPin.Size = size15;
			this.textBox_StartPin.TabIndex = 4;
			this.textBox_StartPin.Text = "1";
			this.textBox_StartPin.TextAlign = HorizontalAlignment.Center;
			this.label_csyzdh.Anchor = AnchorStyles.Top;
			this.label_csyzdh.AutoSize = true;
			this.label_csyzdh.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location16 = new System.Drawing.Point(34, 58);
			this.label_csyzdh.Location = location16;
			Padding margin16 = new Padding(2, 0, 2, 0);
			this.label_csyzdh.Margin = margin16;
			this.label_csyzdh.Name = "label_csyzdh";
			System.Drawing.Size size16 = new System.Drawing.Size(105, 15);
			this.label_csyzdh.Size = size16;
			this.label_csyzdh.TabIndex = 4;
			this.label_csyzdh.Text = "测试仪针脚号:";
			this.btnBatchAddPin.Anchor = AnchorStyles.Top;
			this.btnBatchAddPin.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location17 = new System.Drawing.Point(682, 24);
			this.btnBatchAddPin.Location = location17;
			Padding margin17 = new Padding(2);
			this.btnBatchAddPin.Margin = margin17;
			this.btnBatchAddPin.Name = "btnBatchAddPin";
			System.Drawing.Size size17 = new System.Drawing.Size(60, 48);
			this.btnBatchAddPin.Size = size17;
			this.btnBatchAddPin.TabIndex = 9;
			this.btnBatchAddPin.Text = "批量\n添加";
			this.btnBatchAddPin.UseVisualStyleBackColor = true;
			this.btnBatchAddPin.Click += new System.EventHandler(this.btnBatchAddPin_Click);
			this.label_StartPin.Anchor = AnchorStyles.Top;
			this.label_StartPin.AutoSize = true;
			this.label_StartPin.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location18 = new System.Drawing.Point(63, 23);
			this.label_StartPin.Location = location18;
			Padding margin18 = new Padding(2, 0, 2, 0);
			this.label_StartPin.Margin = margin18;
			this.label_StartPin.Name = "label_StartPin";
			System.Drawing.Size size18 = new System.Drawing.Size(75, 15);
			this.label_StartPin.Size = size18;
			this.label_StartPin.TabIndex = 4;
			this.label_StartPin.Text = "接点名称:";
			this.btnAddPin.Anchor = AnchorStyles.Top;
			this.btnAddPin.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location19 = new System.Drawing.Point(592, 24);
			this.btnAddPin.Location = location19;
			Padding margin19 = new Padding(2);
			this.btnAddPin.Margin = margin19;
			this.btnAddPin.Name = "btnAddPin";
			System.Drawing.Size size19 = new System.Drawing.Size(60, 48);
			this.btnAddPin.Size = size19;
			this.btnAddPin.TabIndex = 8;
			this.btnAddPin.Text = "单个\n添加";
			this.btnAddPin.UseVisualStyleBackColor = true;
			this.btnAddPin.Click += new System.EventHandler(this.btnAddPin_Click);
			this.btnFileToImportPin.Anchor = AnchorStyles.Top;
			this.btnFileToImportPin.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location20 = new System.Drawing.Point(124, 52);
			this.btnFileToImportPin.Location = location20;
			Padding margin20 = new Padding(2);
			this.btnFileToImportPin.Margin = margin20;
			this.btnFileToImportPin.Name = "btnFileToImportPin";
			System.Drawing.Size size20 = new System.Drawing.Size(278, 24);
			this.btnFileToImportPin.Size = size20;
			this.btnFileToImportPin.TabIndex = 6;
			this.btnFileToImportPin.Text = "通过文件导入接点定义";
			this.btnFileToImportPin.UseVisualStyleBackColor = true;
			this.btnFileToImportPin.Click += new System.EventHandler(this.btnFileToImportPin_Click);
			this.btnInterfaceTypeImportPin.Anchor = AnchorStyles.Top;
			this.btnInterfaceTypeImportPin.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location21 = new System.Drawing.Point(445, 52);
			this.btnInterfaceTypeImportPin.Location = location21;
			Padding margin21 = new Padding(2);
			this.btnInterfaceTypeImportPin.Margin = margin21;
			this.btnInterfaceTypeImportPin.Name = "btnInterfaceTypeImportPin";
			System.Drawing.Size size21 = new System.Drawing.Size(278, 24);
			this.btnInterfaceTypeImportPin.Size = size21;
			this.btnInterfaceTypeImportPin.TabIndex = 7;
			this.btnInterfaceTypeImportPin.Text = "通过连接器型号导入接点定义";
			this.btnInterfaceTypeImportPin.UseVisualStyleBackColor = true;
			this.btnInterfaceTypeImportPin.Click += new System.EventHandler(this.btnInterfaceTypeImportPin_Click);
			this.btnDelPin.Anchor = AnchorStyles.Top;
			this.btnDelPin.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location22 = new System.Drawing.Point(139, 183);
			this.btnDelPin.Location = location22;
			Padding margin22 = new Padding(2);
			this.btnDelPin.Margin = margin22;
			this.btnDelPin.Name = "btnDelPin";
			System.Drawing.Size size22 = new System.Drawing.Size(150, 24);
			this.btnDelPin.Size = size22;
			this.btnDelPin.TabIndex = 8;
			this.btnDelPin.Text = "删除选中接点定义";
			this.btnDelPin.UseVisualStyleBackColor = true;
			this.btnDelPin.Click += new System.EventHandler(this.btnDelPin_Click);
			this.openFileDialog1.FileName = "openFileDialog1";
			this.textBox_pinTemplate.Anchor = AnchorStyles.Bottom;
			this.textBox_pinTemplate.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location23 = new System.Drawing.Point(92, 530);
			this.textBox_pinTemplate.Location = location23;
			Padding margin23 = new Padding(2);
			this.textBox_pinTemplate.Margin = margin23;
			this.textBox_pinTemplate.MaxLength = 120;
			this.textBox_pinTemplate.Name = "textBox_pinTemplate";
			System.Drawing.Size size23 = new System.Drawing.Size(68, 24);
			this.textBox_pinTemplate.Size = size23;
			this.textBox_pinTemplate.TabIndex = 13;
			this.textBox_pinTemplate.Text = "1";
			this.textBox_pinTemplate.TextAlign = HorizontalAlignment.Center;
			this.textBox_pinTemplate.Visible = false;
			this.textBox_pinTemplate.KeyPress += new KeyPressEventHandler(this.textBox_pinTemplate_KeyPress);
			this.numericUpDown_csyzdhTemplate.Anchor = AnchorStyles.Bottom;
			this.numericUpDown_csyzdhTemplate.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location24 = new System.Drawing.Point(168, 530);
			this.numericUpDown_csyzdhTemplate.Location = location24;
			Padding margin24 = new Padding(2);
			this.numericUpDown_csyzdhTemplate.Margin = margin24;
			decimal maximum2 = new decimal(new int[]
			{
				1023,
				0,
				0,
				0
			});
			this.numericUpDown_csyzdhTemplate.Maximum = maximum2;
			decimal minimum2 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_csyzdhTemplate.Minimum = minimum2;
			this.numericUpDown_csyzdhTemplate.Name = "numericUpDown_csyzdhTemplate";
			System.Drawing.Size size24 = new System.Drawing.Size(75, 24);
			this.numericUpDown_csyzdhTemplate.Size = size24;
			this.numericUpDown_csyzdhTemplate.TabIndex = 16;
			this.numericUpDown_csyzdhTemplate.TextAlign = HorizontalAlignment.Center;
			decimal value2 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_csyzdhTemplate.Value = value2;
			this.numericUpDown_csyzdhTemplate.Visible = false;
			this.numericUpDown_csyzdhTemplate.KeyPress += new KeyPressEventHandler(this.numericUpDown_csyzdhTemplate_KeyPress);
			this.numericUpDown_csyzdhTemplate.KeyUp += new KeyEventHandler(this.numericUpDown_csyzdhTemplate_KeyUp);
			this.btnDelAllPin.Anchor = AnchorStyles.Top;
			this.btnDelAllPin.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location25 = new System.Drawing.Point(322, 183);
			this.btnDelAllPin.Location = location25;
			Padding margin25 = new Padding(2);
			this.btnDelAllPin.Margin = margin25;
			this.btnDelAllPin.Name = "btnDelAllPin";
			System.Drawing.Size size25 = new System.Drawing.Size(150, 24);
			this.btnDelAllPin.Size = size25;
			this.btnDelAllPin.TabIndex = 8;
			this.btnDelAllPin.Text = "删除所有接点定义";
			this.btnDelAllPin.UseVisualStyleBackColor = true;
			this.btnDelAllPin.Click += new System.EventHandler(this.btnDelAllPin_Click);
			this.btnExport.Anchor = AnchorStyles.Top;
			this.btnExport.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location26 = new System.Drawing.Point(506, 183);
			this.btnExport.Location = location26;
			Padding margin26 = new Padding(2);
			this.btnExport.Margin = margin26;
			this.btnExport.Name = "btnExport";
			System.Drawing.Size size26 = new System.Drawing.Size(150, 24);
			this.btnExport.Size = size26;
			this.btnExport.TabIndex = 21;
			this.btnExport.Text = "导出接点定义表";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			this.comboBox_csyzdhTemplate_FourWire.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_csyzdhTemplate_FourWire.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.comboBox_csyzdhTemplate_FourWire.FormattingEnabled = true;
			System.Drawing.Point location27 = new System.Drawing.Point(14, 529);
			this.comboBox_csyzdhTemplate_FourWire.Location = location27;
			Padding margin27 = new Padding(2);
			this.comboBox_csyzdhTemplate_FourWire.Margin = margin27;
			this.comboBox_csyzdhTemplate_FourWire.Name = "comboBox_csyzdhTemplate_FourWire";
			System.Drawing.Size size27 = new System.Drawing.Size(48, 22);
			this.comboBox_csyzdhTemplate_FourWire.Size = size27;
			this.comboBox_csyzdhTemplate_FourWire.TabIndex = 25;
			this.comboBox_csyzdhTemplate_FourWire.Visible = false;
			this.comboBox_csyzdhTemplate_FourWire.KeyPress += new KeyPressEventHandler(this.comboBox_csyzdhTemplate_FourWire_KeyPress);
			this.comboBox_MeasMethod.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_MeasMethod.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.comboBox_MeasMethod.FormattingEnabled = true;
			object[] items = new object[]
			{
				"二线法",
				"四线法"
			};
			this.comboBox_MeasMethod.Items.AddRange(items);
			System.Drawing.Point location28 = new System.Drawing.Point(579, 532);
			this.comboBox_MeasMethod.Location = location28;
			Padding margin28 = new Padding(2);
			this.comboBox_MeasMethod.Margin = margin28;
			this.comboBox_MeasMethod.Name = "comboBox_MeasMethod";
			System.Drawing.Size size28 = new System.Drawing.Size(48, 22);
			this.comboBox_MeasMethod.Size = size28;
			this.comboBox_MeasMethod.TabIndex = 25;
			this.comboBox_MeasMethod.Visible = false;
			this.comboBox_MeasMethod.SelectedIndexChanged += new System.EventHandler(this.comboBox_MeasMethod_SelectedIndexChanged);
			this.comboBox_MeasMethod.KeyPress += new KeyPressEventHandler(this.comboBox_MeasMethod_KeyPress);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.comboBox_MeasMethod);
			base.Controls.Add(this.comboBox_csyzdhTemplate_FourWire);
			base.Controls.Add(this.btnExport);
			base.Controls.Add(this.numericUpDown_csyzdhTemplate);
			base.Controls.Add(this.btnFileToImportPin);
			base.Controls.Add(this.btnDelAllPin);
			base.Controls.Add(this.btnDelPin);
			base.Controls.Add(this.textBox_pinTemplate);
			base.Controls.Add(this.btnInterfaceTypeImportPin);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.btnSubmit);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.textBox_Remark);
			base.Controls.Add(this.textBox_InterfaceNo);
			base.Controls.Add(this.btnQuit);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin29 = new Padding(2);
			base.Margin = margin29;
			base.Name = "ctFormAddInterface";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "添加接口";
			base.Load += new System.EventHandler(this.ctFormAddInterface_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormAddInterface_SizeChanged);
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((ISupportInitialize)this.numericUpDown_csyzdh).EndInit();
			((ISupportInitialize)this.numericUpDown_csyzdhTemplate).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public void InitAZArrayFunc()
		{
			try
			{
				this.iMAX_DX_NUM = 26;
				this.iMAX_XX_NUM = 26;
				if (!this.gLineTestProcessor.bUseEnglishAlphabetsIOQFlag)
				{
					this.iMAX_DX_NUM = 23;
					this.iMAX_XX_NUM = 22;
				}
				string[] array = new string[this.iMAX_DX_NUM];
				this.AZArray = array;
				array[0] = "A";
				this.AZArray[1] = "B";
				this.AZArray[2] = "C";
				this.AZArray[3] = "D";
				this.AZArray[4] = "E";
				this.AZArray[5] = "F";
				this.AZArray[6] = "G";
				this.AZArray[7] = "H";
				int i = 8;
				if (this.gLineTestProcessor.bUseEnglishAlphabetsIOQFlag)
				{
					this.AZArray[8] = "I";
					i = 9;
				}
				this.AZArray[i] = "J";
				i++;
				this.AZArray[i] = "K";
				i++;
				this.AZArray[i] = "L";
				i++;
				this.AZArray[i] = "M";
				i++;
				this.AZArray[i] = "N";
				i++;
				if (this.gLineTestProcessor.bUseEnglishAlphabetsIOQFlag)
				{
					this.AZArray[i] = "O";
					i++;
				}
				this.AZArray[i] = "P";
				i++;
				if (this.gLineTestProcessor.bUseEnglishAlphabetsIOQFlag)
				{
					this.AZArray[i] = "Q";
					i++;
				}
				this.AZArray[i] = "R";
				i++;
				this.AZArray[i] = "S";
				i++;
				this.AZArray[i] = "T";
				i++;
				this.AZArray[i] = "U";
				i++;
				this.AZArray[i] = "V";
				i++;
				this.AZArray[i] = "W";
				i++;
				this.AZArray[i] = "X";
				i++;
				this.AZArray[i] = "Y";
				i++;
				this.AZArray[i] = "Z";
				i++;
				string[] array2 = new string[this.iMAX_XX_NUM];
				this.azArray = array2;
				array2[0] = "a";
				this.azArray[1] = "b";
				this.azArray[2] = "c";
				this.azArray[3] = "d";
				this.azArray[4] = "e";
				this.azArray[5] = "f";
				this.azArray[6] = "g";
				this.azArray[7] = "h";
				i = 8;
				if (this.gLineTestProcessor.bUseEnglishAlphabetsIOQFlag)
				{
					this.azArray[8] = "i";
					this.azArray[9] = "j";
					i = 10;
				}
				this.azArray[i] = "k";
				i++;
				if (this.gLineTestProcessor.bUseEnglishAlphabetsIOQFlag)
				{
					this.azArray[i] = "l";
					i++;
				}
				this.azArray[i] = "m";
				i++;
				this.azArray[i] = "n";
				i++;
				if (this.gLineTestProcessor.bUseEnglishAlphabetsIOQFlag)
				{
					this.azArray[i] = "o";
					i++;
				}
				this.azArray[i] = "p";
				i++;
				this.azArray[i] = "q";
				i++;
				this.azArray[i] = "r";
				i++;
				this.azArray[i] = "s";
				i++;
				this.azArray[i] = "t";
				i++;
				this.azArray[i] = "u";
				i++;
				this.azArray[i] = "v";
				i++;
				this.azArray[i] = "w";
				i++;
				this.azArray[i] = "x";
				i++;
				this.azArray[i] = "y";
				i++;
				this.azArray[i] = "z";
				i++;
			}
			catch (System.Exception arg_3EF_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3EF_0.StackTrace);
			}
		}
		private void ctFormAddInterface_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.addPlugStr = "";
				this.bAddSuccFlag = false;
				decimal maximum = this.gLineTestProcessor.SELF_MAX_COUNT;
				this.numericUpDown_csyzdh.Maximum = maximum;
				decimal maximum2 = this.gLineTestProcessor.SELF_MAX_COUNT;
				this.numericUpDown_csyzdhTemplate.Maximum = maximum2;
				if (this.comboBox_csyzdh_FourWire.Items.Count > 0)
				{
					this.comboBox_csyzdh_FourWire.SelectedIndex = 0;
					this.comboBox_csyzdhTemplate_FourWire.SelectedIndex = 0;
				}
				if (this.gLineTestProcessor.bUseRelayBoard)
				{
					this.label_csyzdh.Text = "转接台针脚号:";
					this.Column_csyzdh.HeaderText = "转接台针脚号";
				}
				this.iInterfaceName = 1;
				this.currSelectedRowStr = "1";
				this.currSelectedPinStr = "1";
				int iTemp = this.iLastZJTPin + 1;
				if (System.Convert.ToInt32(this.numericUpDown_csyzdh.Maximum) > iTemp)
				{
					decimal value = iTemp;
					this.numericUpDown_csyzdh.Value = value;
				}
				this.currSelectedZJDStr = this.numericUpDown_csyzdh.Text.ToString();
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
			catch (System.Exception arg_198_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_198_0.StackTrace);
			}
			this.InitAZArrayFunc();
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode == 0)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
			catch (System.Exception arg_1C0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1C0_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
		}
		public void GCCollectFunc()
		{
			try
			{
				Process myPro = new Process();
				Process[] proc = Process.GetProcesses();
				for (int i = 0; i < proc.Length; i++)
				{
					myPro = proc[i];
					if (myPro.ProcessName == "EXCEL")
					{
						myPro.Kill();
						System.Threading.Thread.Sleep(50);
						break;
					}
				}
				System.GC.Collect();
				System.GC.WaitForPendingFinalizers();
				System.GC.Collect();
				System.GC.WaitForPendingFinalizers();
			}
			catch (System.Exception ex_54)
			{
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool AsposeCellsReadConfigFileFunc(string file, string fkzm)
		{
			Cells cells = null;
			Cells cells2 = null;
			bool bSuccFlag = true;
			bool bCCFWFlag = false;
			try
			{
				if (string.IsNullOrEmpty(file))
				{
					byte result = 0;
					return result != 0;
				}
				this.dataGridView1.Rows.Clear();
				int iMaxValue = System.Convert.ToInt32(this.numericUpDown_csyzdh.Maximum);
				bool bFailFlag = false;
				string text = "";
				string firstStr = text;
				string secondStr = text;
				string wireStr = text;
				int iRowIndex = 0;
				int iRow = 1;
				int iFailRow = 0;
				if (!(fkzm == "XLS") && !(fkzm == "XLSX"))
				{
					if (fkzm == "CSV")
					{
						Worksheet sht = new Workbook(file, new TxtLoadOptions(LoadFormat.CSV)
						{
							Encoding = System.Text.Encoding.Default
						})
						{
							FileFormat = FileFormatType.CSV
						}.Worksheets[0];
						cells2 = sht.Cells;
						if (sht == null)
						{
							byte result = 0;
							return result != 0;
						}
						int rowCount = cells2.MaxDataRow + 1;
						if (rowCount == 0)
						{
							byte result = 0;
							return result != 0;
						}
						int cellCount = cells2.MaxDataColumn + 1;
						try
						{
							this.dataGridView1.AllowUserToAddRows = true;
							int iColNum = 1;
							iRowIndex = 0;
							firstStr = "";
							while (cells2[iRow, iColNum].Value != null)
							{
								firstStr = cells2[iRow, iColNum].Value.ToString();
								int column = iColNum + 1;
								if (cells2[iRow, column].Value != null)
								{
									secondStr = cells2[iRow, column].Value.ToString();
									try
									{
										secondStr = secondStr.Replace("&", ",");
										char[] separator = new char[]
										{
											','
										};
										string[] tempArray = secondStr.Trim().Split(separator);
										int num = tempArray.Length;
										if (num == 1)
										{
											wireStr = ctFormAddInterface.TEST_TWOWIRE_METHOD;
											int iTemp = System.Convert.ToInt32(secondStr);
											if (iMaxValue < iTemp)
											{
												bCCFWFlag = true;
												break;
											}
										}
										else
										{
											if (num != 2)
											{
												bFailFlag = true;
												iFailRow = iRow + 1;
												break;
											}
											wireStr = ctFormAddInterface.TEST_FOURWIRE_METHOD;
											int iTemp = System.Convert.ToInt32(tempArray[0]);
											int iTemp2 = System.Convert.ToInt32(tempArray[1]);
											if (iTemp != iTemp2 - 1)
											{
												bFailFlag = true;
												iFailRow = iRow + 1;
												break;
											}
											if (iMaxValue < iTemp || iMaxValue < iTemp2)
											{
												bCCFWFlag = true;
												break;
											}
										}
										this.dataGridView1.Rows.Add(1);
										this.dataGridView1.Rows[iRowIndex].Cells[0].Value = System.Convert.ToString(iRowIndex + 1);
										this.dataGridView1.Rows[iRowIndex].Cells[1].Value = firstStr;
										this.dataGridView1.Rows[iRowIndex].Cells[2].Value = secondStr;
										this.dataGridView1.Rows[iRowIndex].Cells[3].Value = wireStr;
									}
									catch (System.Exception ex_2E6)
									{
										bFailFlag = true;
										iFailRow = iRow + 1;
										break;
									}
									iRowIndex++;
									iRow++;
									if (rowCount <= iRow)
									{
										break;
									}
								}
							}
							this.dataGridView1.AllowUserToAddRows = false;
						}
						catch (System.Exception ex)
						{
							this.dataGridView1.AllowUserToAddRows = false;
							KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
							bSuccFlag = false;
							MessageBox.Show("导入失败，请确保文件格式及内容真实有效!", "提示", MessageBoxButtons.OK);
						}
					}
				}
				else
				{
					Workbook wk = new Workbook(file);
					Worksheet sht2 = wk.Worksheets[0];
					cells = sht2.Cells;
					if (sht2 == null)
					{
						byte result = 0;
						return result != 0;
					}
					int rowCount2 = cells.MaxDataRow + 1;
					if (rowCount2 == 0)
					{
						byte result = 0;
						return result != 0;
					}
					int cellCount2 = cells.MaxDataColumn + 1;
					try
					{
						this.dataGridView1.AllowUserToAddRows = true;
						iRowIndex = 0;
						while (cells[iRow, 1].Value != null)
						{
							firstStr = cells[iRow, 1].Value.ToString();
							if (cells[iRow, 2].Value != null)
							{
								secondStr = cells[iRow, 2].Value.ToString();
								try
								{
									char[] separator2 = new char[]
									{
										','
									};
									string[] tempArray = secondStr.Trim().Split(separator2);
									int num2 = tempArray.Length;
									if (num2 == 1)
									{
										wireStr = ctFormAddInterface.TEST_TWOWIRE_METHOD;
										int iTemp = System.Convert.ToInt32(secondStr);
										if (iMaxValue < iTemp)
										{
											bCCFWFlag = true;
											break;
										}
									}
									else
									{
										if (num2 != 2)
										{
											bFailFlag = true;
											iFailRow = iRow + 1;
											break;
										}
										wireStr = ctFormAddInterface.TEST_FOURWIRE_METHOD;
										int iTemp = System.Convert.ToInt32(tempArray[0]);
										int iTemp2 = System.Convert.ToInt32(tempArray[1]);
										if (iTemp != iTemp2 - 1)
										{
											bFailFlag = true;
											iFailRow = iRow + 1;
											break;
										}
										if (iMaxValue < iTemp || iMaxValue < iTemp2)
										{
											bCCFWFlag = true;
											break;
										}
									}
								}
								catch (System.Exception ex_496)
								{
									bFailFlag = true;
									iFailRow = iRow + 1;
									break;
								}
								this.dataGridView1.Rows.Add(1);
								int num3 = iRowIndex + 1;
								this.dataGridView1.Rows[iRowIndex].Cells[0].Value = System.Convert.ToString(num3);
								this.dataGridView1.Rows[iRowIndex].Cells[1].Value = firstStr;
								this.dataGridView1.Rows[iRowIndex].Cells[2].Value = secondStr;
								this.dataGridView1.Rows[iRowIndex].Cells[3].Value = wireStr;
								iRowIndex = num3;
								iRow++;
								if (rowCount2 <= iRow)
								{
									break;
								}
							}
						}
						this.dataGridView1.AllowUserToAddRows = false;
					}
					catch (System.Exception ex_56E)
					{
						this.dataGridView1.AllowUserToAddRows = false;
						this.dataGridView1.Rows.Clear();
						bSuccFlag = false;
					}
				}
				int iLastIndex = this.dataGridView1.Rows.Count - 1;
				if (iLastIndex >= 0)
				{
					this.dataGridView1.Rows[iLastIndex].Selected = true;
				}
				if (bFailFlag)
				{
					bSuccFlag = false;
					MessageBox.Show("文件中第" + System.Convert.ToString(iFailRow) + "行存在无效数据!", "提示", MessageBoxButtons.OK);
				}
				if (bCCFWFlag)
				{
					bSuccFlag = false;
					MessageBox.Show("针脚号已达到最大值" + System.Convert.ToString(this.gLineTestProcessor.SELF_MAX_COUNT) + "，操作已终止!", "提示", MessageBoxButtons.OK);
				}
			}
			catch (System.Exception ex2)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex2.StackTrace);
			}
			return bSuccFlag;
		}
		private void btnFileToImportPin_Click(object sender, System.EventArgs e)
		{
			try
			{
				OpenFileDialog e2 = new OpenFileDialog();
				this.openFileDialog1 = e2;
				e2.Filter = "定义文件|*.xlsx;*.xls;*.csv";
				this.openFileDialog1.RestoreDirectory = true;
				this.openFileDialog1.FilterIndex = 1;
				if (DialogResult.OK == this.openFileDialog1.ShowDialog(this))
				{
					string readfn = this.openFileDialog1.FileName;
					string expr_4F = readfn;
					string strfn = expr_4F.Substring(expr_4F.LastIndexOf("\\") + 1);
					string expr_63 = strfn;
					string fkzm = expr_63.Substring(expr_63.LastIndexOf(".") + 1).ToUpper();
					string jkmcStr = strfn.Substring(0, strfn.LastIndexOf("."));
					if (this.AsposeCellsReadConfigFileFunc(readfn, fkzm))
					{
						this.textBox_InterfaceNo.Text = jkmcStr;
						MessageBox.Show("导入成功!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_B9_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_B9_0.StackTrace);
			}
		}
		private void btnInterfaceTypeImportPin_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			string importPidStr = null;
			try
			{
				ctFormInterfaceTypeImportPin ctFormInterfaceTypeImportPin = new ctFormInterfaceTypeImportPin(this.gLineTestProcessor);
				this.interfaceTypeImportPinForm = ctFormInterfaceTypeImportPin;
				ctFormInterfaceTypeImportPin.Activate();
				this.interfaceTypeImportPinForm.ShowDialog();
				string ifNoStr = this.interfaceTypeImportPinForm.interFaceNoStr;
				if (!string.IsNullOrEmpty(ifNoStr))
				{
					this.connNameStr = ifNoStr;
					int zjxjdh = System.Convert.ToInt32(this.numericUpDown_csyzdh.Value);
					int iMaxValue = System.Convert.ToInt32(this.numericUpDown_csyzdh.Maximum);
					bool bCCFWFlag = false;
					this.dataGridView1.Rows.Clear();
					int inum = 0;
					string measMethodStr = this.interfaceTypeImportPinForm.measMethodStr;
					int iMeasMethod = 0;
					if (measMethodStr == ctFormAddInterface.TEST_TWOWIRE_METHOD)
					{
						iMeasMethod = 1;
					}
					else if (measMethodStr == ctFormAddInterface.TEST_FOURWIRE_METHOD)
					{
						iMeasMethod = 2;
					}
					try
					{
						try
						{
							connection = new OleDbConnection();
							connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
							connection.Open();
							string sqlcommand = "select * from TConnectorLibrary where ConnectorName='" + ifNoStr + "'";
							OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							if (dataReader.Read())
							{
								importPidStr = dataReader["ID"].ToString();
							}
							dataReader.Close();
							dataReader = null;
							sqlcommand = "select * from TConnectorLibraryDetail where CLID='" + importPidStr + "'";
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							bool bIsHaveAddFlag = false;
							this.dataGridView1.AllowUserToAddRows = true;
							while (dataReader.Read())
							{
								string tempStr = dataReader["PinName"].ToString();
								for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
								{
									if (this.dataGridView1.Rows[i].Cells[1].Value != null)
									{
										string temp1Str = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
										if (tempStr == temp1Str)
										{
											MessageBox.Show("接点" + tempStr + "已添加，请勿重复操作!", "提示", MessageBoxButtons.OK);
											goto IL_48B;
										}
									}
									if (!bIsHaveAddFlag && this.dataGridView1.Rows[i].Cells[2].Value != null)
									{
										string temp2Str = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
										string[] tempStrArray = temp2Str.Split(new char[]
										{
											','
										});
										if (tempStrArray.Length >= 2)
										{
											for (int j = 0; j < tempStrArray.Length; j++)
											{
												if (!string.IsNullOrEmpty(tempStrArray[j]))
												{
													int iTemp = System.Convert.ToInt32(tempStrArray[j]);
													if (zjxjdh == iTemp)
													{
														MessageBox.Show("针脚号" + System.Convert.ToString(zjxjdh) + "已添加，请勿重复操作!", "提示", MessageBoxButtons.OK);
														bIsHaveAddFlag = true;
														break;
													}
													if (iMeasMethod == 2)
													{
														int num = zjxjdh + 1;
														if (num == iTemp)
														{
															MessageBox.Show("针脚号" + System.Convert.ToString(num) + "已添加，请勿重复操作!", "提示", MessageBoxButtons.OK);
															bIsHaveAddFlag = true;
															break;
														}
													}
												}
											}
										}
									}
								}
								if (bIsHaveAddFlag)
								{
									break;
								}
								if (zjxjdh > iMaxValue)
								{
									bCCFWFlag = true;
									break;
								}
								this.dataGridView1.Rows.Add(1);
								int num2 = inum + 1;
								this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num2);
								this.dataGridView1.Rows[inum].Cells[1].Value = tempStr;
								int arg_3EB_0 = zjxjdh;
								zjxjdh++;
								tempStr = System.Convert.ToString(arg_3EB_0);
								if (iMeasMethod == 1)
								{
									this.dataGridView1.Rows[inum].Cells[2].Value = tempStr;
								}
								else if (iMeasMethod == 2)
								{
									int value = zjxjdh;
									zjxjdh++;
									tempStr += "," + System.Convert.ToString(value);
									this.dataGridView1.Rows[inum].Cells[2].Value = tempStr;
								}
								this.dataGridView1.Rows[inum].Cells[3].Value = measMethodStr;
								inum = num2;
							}
							IL_48B:
							dataReader.Close();
							dataReader = null;
							connection.Close();
							connection = null;
							if (this.interfaceTypeImportPinForm.bBCKFlag)
							{
								if (iMeasMethod == 1)
								{
									if (zjxjdh <= iMaxValue)
									{
										string tempStr = "BCK";
										this.dataGridView1.Rows.Add(1);
										int value2 = inum + 1;
										this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(value2);
										this.dataGridView1.Rows[inum].Cells[1].Value = tempStr;
										int value3 = zjxjdh;
										zjxjdh++;
										this.dataGridView1.Rows[inum].Cells[2].Value = System.Convert.ToString(value3);
										this.dataGridView1.Rows[inum].Cells[3].Value = measMethodStr;
									}
									else
									{
										bCCFWFlag = true;
									}
								}
								else if (iMeasMethod == 2)
								{
									if (zjxjdh < iMaxValue)
									{
										string tempStr = "BCK";
										this.dataGridView1.Rows.Add(1);
										int value4 = inum + 1;
										this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(value4);
										this.dataGridView1.Rows[inum].Cells[1].Value = tempStr;
										this.dataGridView1.Rows[inum].Cells[2].Value = System.Convert.ToString(zjxjdh) + "," + System.Convert.ToString(zjxjdh + 1);
										this.dataGridView1.Rows[inum].Cells[3].Value = measMethodStr;
									}
									else
									{
										bCCFWFlag = true;
									}
								}
							}
							this.dataGridView1.AllowUserToAddRows = false;
						}
						catch (System.Exception ex)
						{
							this.dataGridView1.AllowUserToAddRows = false;
							KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
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
					catch (System.Exception ex2)
					{
						KLineTestProcessor.ExceptionRecordFunc(ex2.StackTrace);
					}
					if (0 <= this.dataGridView1.Rows.Count - 1)
					{
						this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Selected = true;
					}
					if (bCCFWFlag)
					{
						MessageBox.Show("针脚号已达到最大值" + System.Convert.ToString(this.gLineTestProcessor.SELF_MAX_COUNT) + "，操作已终止!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception ex3)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex3.StackTrace);
			}
		}
		private string GetBatctAddDataFunc(string startTempStr, int iIndex, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool bBigWriteFlag)
		{
			string reStr = startTempStr;
			try
			{
				if (iIndex == 0)
				{
					return startTempStr;
				}
				int iLen = startTempStr.Length;
				int iTemp = 0;
				int iTemp2 = 0;
				int iTemp3 = 0;
				if (bBigWriteFlag)
				{
					if (iLen == 1)
					{
						for (int i = 0; i < this.iMAX_DX_NUM; i++)
						{
							if (startTempStr == this.AZArray[i])
							{
								int num = i + 1;
								if (num < this.iMAX_DX_NUM)
								{
									reStr = this.AZArray[num];
								}
								else
								{
									string expr_7E = this.AZArray[0];
									reStr = expr_7E + expr_7E;
								}
							}
						}
					}
					else if (iLen == 2)
					{
						string tempStr = startTempStr.Substring(0, 1);
						for (int j = 0; j < this.iMAX_DX_NUM; j++)
						{
							if (tempStr == this.AZArray[j])
							{
								iTemp = j;
							}
						}
						string temp2Str = startTempStr.Substring(1, 1);
						for (int k = 0; k < this.iMAX_DX_NUM; k++)
						{
							if (temp2Str == this.AZArray[k])
							{
								iTemp2 = k;
							}
						}
						int num2 = iTemp2 + 1;
						int num3 = this.iMAX_DX_NUM;
						if (num2 < num3)
						{
							reStr = tempStr + this.AZArray[num2];
						}
						else
						{
							int num4 = iTemp + 1;
							if (num4 < num3)
							{
								string[] aZArray = this.AZArray;
								reStr = aZArray[num4] + aZArray[0];
							}
							else
							{
								string text = this.AZArray[0];
								string expr_156 = text;
								reStr = expr_156 + expr_156 + text;
							}
						}
					}
					else if (iLen == 3)
					{
						string tempStr = startTempStr.Substring(0, 1);
						for (int l = 0; l < this.iMAX_DX_NUM; l++)
						{
							if (tempStr == this.AZArray[l])
							{
								iTemp = l;
							}
						}
						string temp2Str = startTempStr.Substring(1, 1);
						for (int m = 0; m < this.iMAX_DX_NUM; m++)
						{
							if (temp2Str == this.AZArray[m])
							{
								iTemp2 = m;
							}
						}
						string temp3Str = startTempStr.Substring(2, 1);
						for (int n = 0; n < this.iMAX_DX_NUM; n++)
						{
							if (temp3Str == this.AZArray[n])
							{
								iTemp3 = n;
							}
						}
						int num5 = iTemp3 + 1;
						int num6 = this.iMAX_DX_NUM;
						if (num5 < num6)
						{
							string[] aZArray2 = this.AZArray;
							reStr = tempStr + aZArray2[iTemp2] + aZArray2[num5];
						}
						else
						{
							int num7 = iTemp2 + 1;
							if (num7 < num6)
							{
								string[] aZArray3 = this.AZArray;
								reStr = tempStr + aZArray3[num7] + aZArray3[0];
							}
							else
							{
								string[] aZArray4 = this.AZArray;
								string str = aZArray4[0];
								reStr = aZArray4[iTemp + 1] + str + str;
							}
						}
					}
				}
				else if (iLen == 1)
				{
					for (int i2 = 0; i2 < this.iMAX_XX_NUM; i2++)
					{
						if (startTempStr == this.azArray[i2])
						{
							int num8 = i2 + 1;
							if (num8 < this.iMAX_XX_NUM)
							{
								reStr = this.azArray[num8];
							}
							else
							{
								string expr_2E1 = this.azArray[0];
								reStr = expr_2E1 + expr_2E1;
							}
						}
					}
				}
				else if (iLen == 2)
				{
					string tempStr = startTempStr.Substring(0, 1);
					for (int i3 = 0; i3 < this.iMAX_XX_NUM; i3++)
					{
						if (tempStr == this.azArray[i3])
						{
							iTemp = i3;
						}
					}
					string temp2Str = startTempStr.Substring(1, 1);
					for (int j2 = 0; j2 < this.iMAX_XX_NUM; j2++)
					{
						if (temp2Str == this.azArray[j2])
						{
							iTemp2 = j2;
						}
					}
					int num9 = iTemp2 + 1;
					int num10 = this.iMAX_XX_NUM;
					if (num9 < num10)
					{
						reStr = tempStr + this.azArray[num9];
					}
					else
					{
						int num11 = iTemp + 1;
						if (num11 < num10)
						{
							string[] array = this.azArray;
							reStr = array[num11] + array[0];
						}
						else
						{
							string text2 = this.azArray[0];
							string expr_3B9 = text2;
							reStr = expr_3B9 + expr_3B9 + text2;
						}
					}
				}
				else if (iLen == 3)
				{
					string tempStr = startTempStr.Substring(0, 1);
					for (int i4 = 0; i4 < this.iMAX_XX_NUM; i4++)
					{
						if (tempStr == this.azArray[i4])
						{
							iTemp = i4;
						}
					}
					string temp2Str = startTempStr.Substring(1, 1);
					for (int j3 = 0; j3 < this.iMAX_XX_NUM; j3++)
					{
						if (temp2Str == this.azArray[j3])
						{
							iTemp2 = j3;
						}
					}
					string temp3Str = startTempStr.Substring(2, 1);
					for (int k2 = 0; k2 < this.iMAX_XX_NUM; k2++)
					{
						if (temp3Str == this.azArray[k2])
						{
							iTemp3 = k2;
						}
					}
					int num12 = iTemp3 + 1;
					int num13 = this.iMAX_XX_NUM;
					if (num12 < num13)
					{
						string[] array2 = this.azArray;
						reStr = tempStr + array2[iTemp2] + array2[num12];
					}
					else
					{
						int num14 = iTemp2 + 1;
						if (num14 < num13)
						{
							string[] array3 = this.azArray;
							reStr = tempStr + array3[num14] + array3[0];
						}
						else
						{
							string[] array4 = this.azArray;
							string str2 = array4[0];
							reStr = array4[iTemp + 1] + str2 + str2;
						}
					}
				}
			}
			catch (System.Exception arg_4F1_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_4F1_0.StackTrace);
				return "";
			}
			return reStr;
		}
		private string GetBatctAddDataAAFunc(string startTempStr, int iIndex, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool bBigWriteFlag)
		{
			string reStr = startTempStr;
			try
			{
				if (iIndex == 0)
				{
					string iIndex2 = startTempStr;
					return iIndex2;
				}
				int iLen = startTempStr.Length;
				int iTemp = 0;
				if (bBigWriteFlag)
				{
					if (iLen == 1)
					{
						for (int i = 0; i < this.iMAX_DX_NUM; i++)
						{
							if (startTempStr == this.AZArray[i])
							{
								int num = i + 1;
								if (num >= this.iMAX_DX_NUM)
								{
									string iIndex2 = "";
									return iIndex2;
								}
								reStr = this.AZArray[num];
							}
						}
					}
					else if (iLen == 2)
					{
						string tempStr = startTempStr.Substring(0, 1);
						for (int j = 0; j < this.iMAX_DX_NUM; j++)
						{
							if (tempStr == this.AZArray[j])
							{
								iTemp = j;
							}
						}
						int num2 = iTemp + 1;
						if (num2 >= this.iMAX_DX_NUM)
						{
							string iIndex2 = "";
							return iIndex2;
						}
						string expr_D8 = this.AZArray[num2];
						reStr = expr_D8 + expr_D8;
					}
					else if (iLen == 3)
					{
						string tempStr = startTempStr.Substring(0, 1);
						for (int k = 0; k < this.iMAX_DX_NUM; k++)
						{
							if (tempStr == this.AZArray[k])
							{
								iTemp = k;
							}
						}
						int num3 = iTemp + 1;
						if (num3 >= this.iMAX_DX_NUM)
						{
							string iIndex2 = "";
							return iIndex2;
						}
						string text = this.AZArray[num3];
						string expr_145 = text;
						reStr = expr_145 + expr_145 + text;
					}
				}
				else if (iLen == 1)
				{
					for (int l = 0; l < this.iMAX_XX_NUM; l++)
					{
						if (startTempStr == this.azArray[l])
						{
							int num4 = l + 1;
							if (num4 >= this.iMAX_XX_NUM)
							{
								string iIndex2 = "";
								return iIndex2;
							}
							reStr = this.azArray[num4];
						}
					}
				}
				else if (iLen == 2)
				{
					string tempStr = startTempStr.Substring(0, 1);
					for (int m = 0; m < this.iMAX_XX_NUM; m++)
					{
						if (tempStr == this.azArray[m])
						{
							iTemp = m;
						}
					}
					int num5 = iTemp + 1;
					if (num5 >= this.iMAX_XX_NUM)
					{
						string iIndex2 = "";
						return iIndex2;
					}
					string expr_207 = this.azArray[num5];
					reStr = expr_207 + expr_207;
				}
				else if (iLen == 3)
				{
					string tempStr = startTempStr.Substring(0, 1);
					for (int n = 0; n < this.iMAX_XX_NUM; n++)
					{
						if (tempStr == this.azArray[n])
						{
							iTemp = n;
						}
					}
					int num6 = iTemp + 1;
					if (num6 >= this.iMAX_XX_NUM)
					{
						string iIndex2 = "";
						return iIndex2;
					}
					string text2 = this.azArray[num6];
					string expr_26E = text2;
					reStr = expr_26E + expr_26E + text2;
				}
			}
			catch (System.Exception arg_288_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_288_0.StackTrace);
				return "";
			}
			return reStr;
		}
		private string GenerateStringDisposeFunc(string startTempStr, int iIndex)
		{
			string reStr = startTempStr;
			int iLen = startTempStr.Length;
			int iTemp = -1;
			try
			{
				if (iIndex == 0)
				{
					try
					{
						for (int i = iLen - 1; i >= 0; i--)
						{
							string tempStr = startTempStr.Substring(i, 1);
							try
							{
								int ia = System.Convert.ToInt32(tempStr);
							}
							catch (System.Exception ex_2B)
							{
								iTemp = i;
							}
						}
						if (iTemp == -1)
						{
							return "";
						}
						this.letterStr = startTempStr.Substring(0, iLen - iTemp - 1);
						this.iStartNum = System.Convert.ToInt32(startTempStr.Substring(iTemp + 1));
					}
					catch (System.Exception arg_6F_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_6F_0.StackTrace);
					}
				}
				reStr = this.letterStr + System.Convert.ToString(this.iStartNum + iIndex);
			}
			catch (System.Exception arg_96_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_96_0.StackTrace);
				return "";
			}
			return reStr;
		}
		private void btnBatchAddPin_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormBatchAddABC ctFormBatchAddABC = new ctFormBatchAddABC(this.gLineTestProcessor, this.iLastZJTPin);
				this.batchAddPinForm = ctFormBatchAddABC;
				ctFormBatchAddABC.Activate();
				this.batchAddPinForm.ShowDialog();
				ctFormBatchAddABC ctFormBatchAddABC2 = this.batchAddPinForm;
				int iACount = ctFormBatchAddABC2.iAddCount;
				if (iACount > 0)
				{
					bool bBCKFlag = ctFormBatchAddABC2.bBCKFlag;
					int iAddRule = ctFormBatchAddABC2.iAddRule;
					string startPinNameStr = ctFormBatchAddABC2.startPinNameStr;
					int iStartPinNo = ctFormBatchAddABC2.iStartPinNo;
					string measMethodStr = ctFormBatchAddABC2.measMethodStr;
					try
					{
						if (iAddRule == 0)
						{
							int ispn = System.Convert.ToInt32(startPinNameStr);
						}
					}
					catch (System.Exception ex_9D)
					{
						MessageBox.Show("起始接点不是数字类型，不能进行批量添加!", "提示", MessageBoxButtons.OK);
						goto IL_6EE;
					}
					int iTNum = 0;
					if (bBCKFlag)
					{
						iACount++;
					}
					if (measMethodStr == ctFormAddInterface.TEST_TWOWIRE_METHOD)
					{
						iTNum = iACount + iStartPinNo - 1;
						if (bBCKFlag)
						{
							iTNum++;
						}
					}
					else if (measMethodStr == ctFormAddInterface.TEST_FOURWIRE_METHOD)
					{
						iTNum = iACount * 2 + iStartPinNo - 1;
					}
					int sELF_MAX_COUNT = this.gLineTestProcessor.SELF_MAX_COUNT;
					if (sELF_MAX_COUNT < iTNum)
					{
						MessageBox.Show("批量添加针点已超出针脚最大值" + System.Convert.ToString(sELF_MAX_COUNT) + "，请减少添加数量!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						int iRowsCount = this.dataGridView1.Rows.Count;
						int iStartPinNum = 1;
						System.Collections.Generic.List<InterfaceDefineStruct> IDefineStructArray = new System.Collections.Generic.List<InterfaceDefineStruct>();
						if (iAddRule == 0)
						{
							iStartPinNum = System.Convert.ToInt32(startPinNameStr);
						}
						string tempStr = startPinNameStr;
						for (int i = 0; i < iACount; i++)
						{
							if (bBCKFlag && i == iACount - 1)
							{
								tempStr = "BCK";
							}
							else
							{
								if (iAddRule == 0)
								{
									int arg_19C_0 = iStartPinNum;
									iStartPinNum++;
									tempStr = System.Convert.ToString(arg_19C_0);
								}
								else if (iAddRule == 1)
								{
									tempStr = this.GetBatctAddDataAAFunc(tempStr, i, true);
								}
								else if (iAddRule == 2)
								{
									tempStr = this.GetBatctAddDataAAFunc(tempStr, i, false);
								}
								else if (iAddRule == 3)
								{
									tempStr = this.GetBatctAddDataFunc(tempStr, i, true);
								}
								else if (iAddRule == 4)
								{
									tempStr = this.GetBatctAddDataFunc(tempStr, i, false);
								}
								else if (iAddRule == 5)
								{
									tempStr = this.GenerateStringDisposeFunc(startPinNameStr, i);
								}
								if (string.IsNullOrEmpty(tempStr))
								{
									break;
								}
							}
							InterfaceDefineStruct iDefineStruct = new InterfaceDefineStruct();
							int num = iRowsCount + 1;
							iDefineStruct.indexStr = System.Convert.ToString(num);
							iDefineStruct.iNameStr = tempStr;
							if (measMethodStr == ctFormAddInterface.TEST_TWOWIRE_METHOD)
							{
								if (bBCKFlag && i == iACount - 1)
								{
									if (iStartPinNo % 2 == 0)
									{
										iStartPinNo++;
									}
									iDefineStruct.trPinStr = System.Convert.ToString(iStartPinNo);
								}
								else
								{
									iDefineStruct.trPinStr = System.Convert.ToString(iStartPinNo);
								}
								iStartPinNo++;
							}
							else if (measMethodStr == ctFormAddInterface.TEST_FOURWIRE_METHOD)
							{
								iDefineStruct.trPinStr = System.Convert.ToString(iStartPinNo) + "," + System.Convert.ToString(iStartPinNo + 1);
								iStartPinNo += 2;
							}
							iDefineStruct.mMethodStr = measMethodStr;
							IDefineStructArray.Add(iDefineStruct);
							iRowsCount = num;
						}
						bool bExistSameFlag = false;
						int iNum = 0;
						for (int j = 0; j < IDefineStructArray.Count; j++)
						{
							int k = 0;
							while (k < this.dataGridView1.Rows.Count)
							{
								string temp1Str = this.dataGridView1.Rows[k].Cells[1].Value.ToString();
								string temp2Str = this.dataGridView1.Rows[k].Cells[2].Value.ToString();
								if (!(IDefineStructArray[j].iNameStr == temp1Str))
								{
									if (IDefineStructArray[j].trPinStr == temp2Str)
									{
										tempStr = temp2Str;
									}
									else
									{
										if (IDefineStructArray[j].mMethodStr == ctFormAddInterface.TEST_TWOWIRE_METHOD)
										{
											string[] tempStrArray = temp2Str.Split(new char[]
											{
												','
											});
											for (int jj = 0; jj < tempStrArray.Length; jj++)
											{
												if (tempStrArray[jj] == IDefineStructArray[j].trPinStr)
												{
													tempStr = IDefineStructArray[j].trPinStr;
													goto IL_4AA;
												}
											}
										}
										else
										{
											char[] separator = new char[]
											{
												','
											};
											string[] tempStrArray = IDefineStructArray[j].trPinStr.Split(separator);
											for (int jj2 = 0; jj2 < tempStrArray.Length; jj2++)
											{
												if (tempStrArray[jj2] == temp2Str)
												{
													tempStr = temp2Str;
													goto IL_4AA;
												}
											}
										}
										if (!bExistSameFlag)
										{
											k++;
											continue;
										}
										if (iNum == 1)
										{
											goto IL_487;
										}
									}
									IL_4AA:
									MessageBox.Show("针脚号" + tempStr + "已在接点" + temp1Str + "中定义，操作失败!", "提示", MessageBoxButtons.OK);
									goto IL_4DC;
								}
								tempStr = temp1Str;
								IL_487:
								MessageBox.Show("接点" + tempStr + "已定义，操作失败!", "提示", MessageBoxButtons.OK);
								IL_4DC:
								return;
							}
						}
						iRowsCount = this.dataGridView1.Rows.Count;
						this.dataGridView1.AllowUserToAddRows = true;
						for (int l = 0; l < IDefineStructArray.Count; l++)
						{
							this.dataGridView1.Rows.Add(1);
							this.dataGridView1.Rows[iRowsCount].Cells[0].Value = IDefineStructArray[l].indexStr;
							this.dataGridView1.Rows[iRowsCount].Cells[1].Value = IDefineStructArray[l].iNameStr;
							this.dataGridView1.Rows[iRowsCount].Cells[2].Value = IDefineStructArray[l].trPinStr;
							this.dataGridView1.Rows[iRowsCount].Cells[3].Value = IDefineStructArray[l].mMethodStr;
							iRowsCount++;
						}
						this.dataGridView1.AllowUserToAddRows = false;
						if (0 <= this.dataGridView1.Rows.Count - 1)
						{
							this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Selected = true;
						}
						this.connNameStr = "";
						IDefineStructArray.Clear();
						int iMax = System.Convert.ToInt32(this.numericUpDown_csyzdh.Maximum);
						if (bBCKFlag && measMethodStr == ctFormAddInterface.TEST_TWOWIRE_METHOD)
						{
							this.iLastZJTPin = iStartPinNo;
							int num2 = iStartPinNo + 1;
							if (iMax < num2)
							{
								decimal value = System.Convert.ToDecimal(iStartPinNo);
								this.numericUpDown_csyzdh.Value = value;
							}
							else
							{
								decimal value2 = System.Convert.ToDecimal(num2);
								this.numericUpDown_csyzdh.Value = value2;
							}
						}
						else
						{
							int value3 = iStartPinNo - 1;
							this.iLastZJTPin = value3;
							if (iMax < iStartPinNo)
							{
								decimal value4 = System.Convert.ToDecimal(value3);
								this.numericUpDown_csyzdh.Value = value4;
							}
							else
							{
								decimal value5 = System.Convert.ToDecimal(iStartPinNo);
								this.numericUpDown_csyzdh.Value = value5;
							}
						}
					}
					IL_6EE:;
				}
			}
			catch (System.Exception ex)
			{
				this.dataGridView1.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		private void btnAddPin_Click(object sender, System.EventArgs e)
		{
			try
			{
				string startPinStr = this.textBox_StartPin.Text.ToString().Trim();
				if (string.IsNullOrEmpty(startPinStr))
				{
					MessageBox.Show("接点不能为空!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					string csyzdhStr = this.numericUpDown_csyzdh.Text.ToString().Trim();
					string measMethodStr = this.radioButton_Pin_TwoWire.Text.ToString();
					if (this.radioButton_Pin_FourWire.Checked)
					{
						csyzdhStr = this.comboBox_csyzdh_FourWire.Text.ToString().Trim();
						measMethodStr = this.radioButton_Pin_FourWire.Text.ToString();
					}
					if (string.IsNullOrEmpty(csyzdhStr))
					{
						MessageBox.Show("针脚号不能为空!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						bool bExistSameFlag = false;
						int i = 0;
						while (i < this.dataGridView1.Rows.Count)
						{
							string tempStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
							if (startPinStr == tempStr)
							{
								MessageBox.Show("接点" + startPinStr + "已添加，请勿重复操作!", "提示", MessageBoxButtons.OK);
								return;
							}
							string temp2Str = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
							if (csyzdhStr == temp2Str)
							{
								MessageBox.Show("针脚号" + temp2Str + "已在接点" + tempStr + "中定义!", "提示", MessageBoxButtons.OK);
								return;
							}
							if (measMethodStr == ctFormAddInterface.TEST_TWOWIRE_METHOD)
							{
								string[] tempStrArray = temp2Str.Split(new char[]
								{
									','
								});
								for (int jj = 0; jj < tempStrArray.Length; jj++)
								{
									if (tempStrArray[jj] == csyzdhStr)
									{
										goto IL_232;
									}
								}
							}
							else
							{
								string[] tempStrArray = csyzdhStr.Split(new char[]
								{
									','
								});
								for (int jj2 = 0; jj2 < tempStrArray.Length; jj2++)
								{
									if (tempStrArray[jj2] == temp2Str)
									{
										goto IL_232;
									}
								}
							}
							if (!bExistSameFlag)
							{
								i++;
								continue;
							}
							IL_232:
							MessageBox.Show("针脚号" + temp2Str + "已在接点" + tempStr + "中定义!", "提示", MessageBoxButtons.OK);
							return;
						}
						int inum = this.dataGridView1.Rows.Count;
						this.dataGridView1.AllowUserToAddRows = true;
						this.dataGridView1.Rows.Add(1);
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(inum + 1);
						this.dataGridView1.Rows[inum].Cells[1].Value = startPinStr;
						this.dataGridView1.Rows[inum].Cells[2].Value = csyzdhStr;
						this.dataGridView1.Rows[inum].Cells[3].Value = measMethodStr;
						this.dataGridView1.AllowUserToAddRows = false;
						int iLastIndex = this.dataGridView1.Rows.Count - 1;
						if (iLastIndex >= 0)
						{
							this.dataGridView1.Rows[iLastIndex].Selected = true;
						}
						this.connNameStr = "";
					}
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool TheSamePinCheckDealwithFunc(string cableNoStr)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			bool bExistFlag = false;
			string text = "";
			string plugInfoStr = text;
			string existPlugStr = text;
			int iPinNum = 0;
			string JKStr = this.textBox_InterfaceNo.Text.ToString();
			try
			{
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "select top 1 * from TLineStructLibrary where LineStructName = '" + cableNoStr + "'";
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					while (dataReader.Read())
					{
						plugInfoStr = dataReader["PlugInfo"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					if (string.IsNullOrEmpty(plugInfoStr))
					{
						connection.Close();
						connection = null;
						return bExistFlag;
					}
					string[] plugNameArray = plugInfoStr.Split(new char[]
					{
						','
					});
					for (int i = 0; i < plugNameArray.Length; i++)
					{
						if (!string.IsNullOrEmpty(plugNameArray[i]))
						{
							if (!(JKStr == plugNameArray[i]))
							{
								int iPID = 0;
								sqlcommand = "select top 1 * from TPlugLibrary where PlugNo = '" + plugNameArray[i] + "'";
								cmd = new OleDbCommand(sqlcommand, connection);
								dataReader = cmd.ExecuteReader();
								while (dataReader.Read())
								{
									iPID = System.Convert.ToInt32(dataReader["PID"].ToString());
								}
								dataReader.Close();
								dataReader = null;
								if (iPID != 0)
								{
									sqlcommand = "select * from TPlugLibraryDetail where PID = '" + System.Convert.ToString(iPID) + "'";
									cmd = new OleDbCommand(sqlcommand, connection);
									dataReader = cmd.ExecuteReader();
									while (dataReader.Read())
									{
										iPinNum = System.Convert.ToInt32(dataReader["DevicePinNum"].ToString());
										for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
										{
											int iUIPinNum = System.Convert.ToInt32(this.dataGridView1.Rows[j].Cells[2].Value.ToString());
											if (iPinNum == iUIPinNum)
											{
												existPlugStr = plugNameArray[i];
												bExistFlag = true;
												goto IL_20B;
											}
										}
										if (bExistFlag)
										{
											break;
										}
									}
									IL_20B:
									dataReader.Close();
									dataReader = null;
								}
							}
						}
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_226_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_226_0.StackTrace);
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
			catch (System.Exception arg_24A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_24A_0.StackTrace);
			}
			if (bExistFlag)
			{
				MessageBox.Show("针点" + System.Convert.ToString(iPinNum) + "已在接口（" + existPlugStr + "）中定义!", "提示", MessageBoxButtons.OK);
			}
			return bExistFlag;
		}
		private void btnSaveInterface_Click(object sender, System.EventArgs e)
		{
			string pidStr = null;
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				if (this.dataGridView1.Rows.Count <= 0)
				{
					MessageBox.Show("没有定义接点!", "提示", MessageBoxButtons.OK);
					return;
				}
				string JKStr = this.textBox_InterfaceNo.Text.ToString().Trim();
				if (string.IsNullOrEmpty(JKStr))
				{
					MessageBox.Show("接口代号为空!", "提示", MessageBoxButtons.OK);
					return;
				}
				int iPinNum = this.dataGridView1.Rows.Count;
				bool bSameFlag = false;
				bool bSamePinFlag = false;
				string e2 = "";
				string theSameStr = e2;
				string index1Str = e2;
				string index2Str = e2;
				for (int i = 0; i < iPinNum; i++)
				{
					string temp1Str = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
					string temp2Str = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
					string temp3Str = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
					for (int j = 0; j < iPinNum; j++)
					{
						if (i != j)
						{
							string temp4Str = this.dataGridView1.Rows[j].Cells[1].Value.ToString();
							string temp5Str = this.dataGridView1.Rows[j].Cells[2].Value.ToString();
							string temp6Str = this.dataGridView1.Rows[j].Cells[3].Value.ToString();
							if (temp1Str == temp4Str)
							{
								theSameStr = temp1Str;
								IL_30D:
								MessageBox.Show("存在相同的接点名称 " + theSameStr, "提示", MessageBoxButtons.OK);
								return;
							}
							if (temp2Str == temp5Str)
							{
								index1Str = System.Convert.ToString(i + 1);
								index2Str = System.Convert.ToString(j + 1);
								bSamePinFlag = true;
								break;
							}
							if (temp3Str == ctFormAddInterface.TEST_TWOWIRE_METHOD && temp6Str == ctFormAddInterface.TEST_FOURWIRE_METHOD)
							{
								string[] pinStrArray = temp5Str.Split(new char[]
								{
									','
								});
								if (temp2Str == pinStrArray[0] || temp2Str == pinStrArray[1])
								{
									index1Str = System.Convert.ToString(i + 1);
									index2Str = System.Convert.ToString(j + 1);
									bSamePinFlag = true;
									break;
								}
							}
							else if (temp3Str == ctFormAddInterface.TEST_FOURWIRE_METHOD && temp6Str == ctFormAddInterface.TEST_TWOWIRE_METHOD)
							{
								string[] pinStrArray = temp2Str.Split(new char[]
								{
									','
								});
								if (temp5Str == pinStrArray[0] || temp5Str == pinStrArray[1])
								{
									index1Str = System.Convert.ToString(i + 1);
									index2Str = System.Convert.ToString(j + 1);
									bSamePinFlag = true;
									break;
								}
							}
						}
					}
					if (bSameFlag)
					{
						goto IL_30D;
					}
					if (bSamePinFlag)
					{
						MessageBox.Show("第 " + index1Str + " 行与第 " + index2Str + " 行针脚号共用!", "提示", MessageBoxButtons.OK);
						return;
					}
				}
				string remarkStr = this.textBox_Remark.Text.ToString();
				bool bFirstFlag = false;
				for (int k = 0; k < iPinNum; k++)
				{
					if (this.dataGridView1.Rows[k].Cells[2].Value != null)
					{
						string temp1Str = this.dataGridView1.Rows[k].Cells[2].Value.ToString();
						string temp2Str = this.dataGridView1.Rows[k].Cells[3].Value.ToString();
						int iTemp;
						if (temp2Str == ctFormAddInterface.TEST_TWOWIRE_METHOD)
						{
							iTemp = System.Convert.ToInt32(temp1Str);
						}
						else
						{
							string[] tempArray = temp1Str.Split(new char[]
							{
								','
							});
							iTemp = System.Convert.ToInt32(tempArray[1]);
						}
						if (!bFirstFlag)
						{
							bFirstFlag = true;
							this.iLastZJTPin = iTemp;
						}
						else if (this.iLastZJTPin < iTemp)
						{
							this.iLastZJTPin = iTemp;
						}
					}
				}
				try
				{
					bool bExsitFlag = false;
					e2 = "";
					pidStr = e2;
					try
					{
						connection = new OleDbConnection();
						connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
						connection.Open();
						string sqlcommand = "select top 1 * from TPlugLibrary where PlugNo = '" + JKStr + "'";
						OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						if (dataReader.Read())
						{
							string tempStr = dataReader["PlugNo"].ToString();
							bExsitFlag = true;
						}
						dataReader.Close();
						dataReader = null;
						if (bExsitFlag)
						{
							connection.Close();
							connection = null;
							MessageBox.Show("接口已存在!", "提示", MessageBoxButtons.OK);
							return;
						}
						try
						{
							string str = "','";
							sqlcommand = "insert into TPlugLibrary(PlugNo,PinNum,Creator,Remark,ConnectorName) values('" + JKStr + "'," + iPinNum + ",'" + this.loginUser + str + remarkStr + str + this.connNameStr + "')";
							cmd = new OleDbCommand(sqlcommand, connection);
							cmd.ExecuteNonQuery();
							System.Threading.Thread.Sleep(100);
							sqlcommand = "select * from TPlugLibrary where PlugNo='" + JKStr + "'";
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							if (dataReader.Read())
							{
								pidStr = dataReader["PID"].ToString();
							}
							dataReader.Close();
							dataReader = null;
						}
						catch (System.Exception ex)
						{
							KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
							if (dataReader != null)
							{
								dataReader.Close();
								dataReader = null;
							}
						}
						if (!string.IsNullOrEmpty(pidStr))
						{
							System.Threading.Thread.Sleep(50);
							for (int l = 0; l < iPinNum; l++)
							{
								int iMeasMethod = 0;
								string temp3Str = this.dataGridView1.Rows[l].Cells[1].Value.ToString();
								string temp4Str = this.dataGridView1.Rows[l].Cells[2].Value.ToString();
								string tempStr = this.dataGridView1.Rows[l].Cells[3].Value.ToString();
								if (tempStr == ctFormAddInterface.TEST_FOURWIRE_METHOD)
								{
									iMeasMethod = 1;
								}
								string str2 = "','";
								sqlcommand = "insert into TPlugLibraryDetail(PID,PinName,DevicePinNum,MeasuringMethod) values('" + pidStr + str2 + temp3Str + str2 + temp4Str + "'," + iMeasMethod + ")";
								cmd = new OleDbCommand(sqlcommand, connection);
								cmd.ExecuteNonQuery();
							}
						}
						connection.Close();
						connection = null;
					}
					catch (System.Exception ex2)
					{
						KLineTestProcessor.ExceptionRecordFunc(ex2.StackTrace);
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
				catch (System.Exception ex3)
				{
					KLineTestProcessor.ExceptionRecordFunc(ex3.StackTrace);
				}
				this.addPlugStr = JKStr;
			}
			catch (System.Exception ex4)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex4.StackTrace);
				MessageBox.Show("存在未知异常!", "提示", MessageBoxButtons.OK);
				base.Close();
				return;
			}
			MessageBox.Show("操作成功!", "提示", MessageBoxButtons.OK);
			this.bAddSuccFlag = true;
			base.Close();
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			base.Close();
		}
		public void ResetTempControlFunc()
		{
			try
			{
				this.textBox_pinTemplate.Visible = false;
				this.numericUpDown_csyzdhTemplate.Visible = false;
				this.comboBox_csyzdhTemplate_FourWire.Visible = false;
				this.comboBox_MeasMethod.Visible = false;
				this.dataGridView1.ScrollBars = ScrollBars.Both;
			}
			catch (System.Exception arg_3E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3E_0.StackTrace);
			}
		}
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 676;
					if (iw > 0)
					{
						iw /= 2;
					}
					this.dataGridView1.Columns[0].Width = 70;
					this.dataGridView1.Columns[1].Width = iw + 200;
					this.dataGridView1.Columns[2].Width = iw + 232;
					this.dataGridView1.Columns[3].Width = 150;
					this.ResetTempControlFunc();
				}
			}
			catch (System.Exception arg_9B_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_9B_0.StackTrace);
			}
		}
		private void ctFormAddInterface_SizeChanged(object sender, System.EventArgs e)
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
		private void btnUpdatePin_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.Rows.Count > 0)
				{
					int iIndex = System.Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
					string pinStr = this.textBox_StartPin.Text.ToString();
					for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
					{
						if (iIndex - 1 != i)
						{
							if (0 == pinStr.CompareTo(this.dataGridView1.Rows[i].Cells[1].Value.ToString()))
							{
								MessageBox.Show("接点已存在!", "提示", MessageBoxButtons.OK);
								return;
							}
						}
					}
					int sender2 = iIndex - 1;
					this.dataGridView1.Rows[sender2].Cells[1].Value = pinStr;
					decimal value = this.numericUpDown_csyzdh.Value;
					this.dataGridView1.Rows[sender2].Cells[2].Value = System.Convert.ToString(value);
				}
			}
			catch (System.Exception arg_12D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_12D_0.StackTrace);
			}
		}
		private void btnDelPin_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.SetControlValueToDGVFunc();
				if (this.dataGridView1.SelectedRows.Count > 0)
				{
					this.dataGridView1.Rows.Remove(this.dataGridView1.SelectedRows[0]);
					int sender2;
					for (int i = 0; i < this.dataGridView1.Rows.Count; i = sender2)
					{
						sender2 = i + 1;
						this.dataGridView1.Rows[i].Cells[0].Value = System.Convert.ToString(sender2);
					}
					this.connNameStr = "";
				}
			}
			catch (System.Exception arg_90_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_90_0.StackTrace);
			}
		}
		private void btnDelAllPin_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.ResetTempControlFunc();
				this.dataGridView1.Rows.Clear();
				this.connNameStr = "";
			}
			catch (System.Exception arg_23_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_23_0.StackTrace);
			}
		}
		private void numericUpDown_csyzdh_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
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
			catch (System.Exception arg_2F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2F_0.StackTrace);
			}
		}
		private void textBox_pinTemplate_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.SetControlValueToDGVFunc();
				}
			}
			catch (System.Exception arg_12_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_12_0.StackTrace);
			}
		}
		private void numericUpDown_csyzdhTemplate_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '\b')
				{
					e.Handled = false;
				}
				else
				{
					e.Handled = true;
				}
				if (e.KeyChar == '\r')
				{
					this.SetControlValueToDGVFunc();
				}
			}
			catch (System.Exception arg_3F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3F_0.StackTrace);
			}
		}
		public void SetControlValueToDGVFunc()
		{
			try
			{
				if (this.textBox_pinTemplate.Visible)
				{
					string text = "";
					string temp1Str = text;
					string editPNameStr = text;
					string editPNumStr = text;
					string editP4NumStr = text;
					string editMethodStr = text;
					try
					{
						bool bPinfzFlag = true;
						if (this.textBox_pinTemplate.Visible)
						{
							editPNameStr = this.textBox_pinTemplate.Text.ToString().Trim();
							if (!string.IsNullOrEmpty(editPNameStr))
							{
								for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
								{
									string temp0Str = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
									temp1Str = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
									if (this.currSelectedRowStr != temp0Str && editPNameStr == temp1Str)
									{
										IL_F9:
										MessageBox.Show("接点已定义!", "提示", MessageBoxButtons.OK);
										this.textBox_pinTemplate.Text = "";
										this.textBox_pinTemplate.Visible = false;
										this.numericUpDown_csyzdhTemplate.Visible = false;
										this.comboBox_csyzdhTemplate_FourWire.Visible = false;
										this.comboBox_MeasMethod.Visible = false;
										this.dataGridView1.ScrollBars = ScrollBars.Both;
										return;
									}
								}
								if (!bPinfzFlag)
								{
									goto IL_F9;
								}
							}
						}
					}
					catch (System.Exception arg_15D_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_15D_0.StackTrace);
					}
					try
					{
						bool bPinfzFlag = true;
						if (this.numericUpDown_csyzdhTemplate.Visible)
						{
							editPNumStr = System.Convert.ToString(this.numericUpDown_csyzdhTemplate.Value);
							for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
							{
								string temp0Str = this.dataGridView1.Rows[j].Cells[0].Value.ToString();
								temp1Str = this.dataGridView1.Rows[j].Cells[1].Value.ToString();
								string temp2Str = this.dataGridView1.Rows[j].Cells[2].Value.ToString();
								if (this.currSelectedRowStr != temp0Str && editPNumStr == temp2Str)
								{
									IL_2A0:
									MessageBox.Show("针脚号" + editPNumStr + "已在接点" + temp1Str + "中定义!", "提示", MessageBoxButtons.OK);
									this.textBox_pinTemplate.Text = "";
									this.textBox_pinTemplate.Visible = false;
									this.numericUpDown_csyzdhTemplate.Visible = false;
									this.comboBox_csyzdhTemplate_FourWire.Visible = false;
									this.comboBox_MeasMethod.Visible = false;
									this.dataGridView1.ScrollBars = ScrollBars.Both;
									return;
								}
								string[] tempStrArray = temp2Str.Split(new char[]
								{
									','
								});
								for (int k = 0; k < tempStrArray.Length; k++)
								{
									if (this.currSelectedRowStr != temp0Str && tempStrArray[k] == editPNumStr)
									{
										bPinfzFlag = false;
										break;
									}
								}
							}
							if (!bPinfzFlag)
							{
								goto IL_2A0;
							}
						}
					}
					catch (System.Exception arg_326_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_326_0.StackTrace);
					}
					try
					{
						bool bPinfzFlag = true;
						if (this.comboBox_csyzdhTemplate_FourWire.Visible)
						{
							editP4NumStr = this.comboBox_csyzdhTemplate_FourWire.Text.ToString();
							for (int l = 0; l < this.dataGridView1.Rows.Count; l++)
							{
								string temp0Str = this.dataGridView1.Rows[l].Cells[0].Value.ToString();
								temp1Str = this.dataGridView1.Rows[l].Cells[1].Value.ToString();
								string temp2Str = this.dataGridView1.Rows[l].Cells[2].Value.ToString();
								if (this.currSelectedRowStr != temp0Str && editP4NumStr == temp2Str)
								{
									IL_469:
									MessageBox.Show("针脚号" + editP4NumStr + "已在接点" + temp1Str + "中定义!", "提示", MessageBoxButtons.OK);
									this.textBox_pinTemplate.Text = "";
									this.textBox_pinTemplate.Visible = false;
									this.numericUpDown_csyzdhTemplate.Visible = false;
									this.comboBox_csyzdhTemplate_FourWire.Visible = false;
									this.comboBox_MeasMethod.Visible = false;
									this.dataGridView1.ScrollBars = ScrollBars.Both;
									return;
								}
								string[] tempStrArray = editP4NumStr.Split(new char[]
								{
									','
								});
								for (int m = 0; m < tempStrArray.Length; m++)
								{
									if (this.currSelectedRowStr != temp0Str && tempStrArray[m] == temp2Str)
									{
										bPinfzFlag = false;
										break;
									}
								}
							}
							if (!bPinfzFlag)
							{
								goto IL_469;
							}
						}
					}
					catch (System.Exception arg_4EF_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_4EF_0.StackTrace);
					}
					try
					{
						if (this.comboBox_MeasMethod.Visible)
						{
							editMethodStr = this.comboBox_MeasMethod.Text.ToString();
						}
						for (int n = 0; n < this.dataGridView1.Rows.Count; n++)
						{
							string temp0Str = this.dataGridView1.Rows[n].Cells[0].Value.ToString();
							if (this.currSelectedRowStr == temp0Str)
							{
								this.dataGridView1.Rows[n].Cells[1].Value = editPNameStr;
								if (this.numericUpDown_csyzdhTemplate.Visible)
								{
									this.dataGridView1.Rows[n].Cells[2].Value = editPNumStr;
								}
								if (this.comboBox_csyzdhTemplate_FourWire.Visible)
								{
									this.dataGridView1.Rows[n].Cells[2].Value = editP4NumStr;
								}
								this.dataGridView1.Rows[n].Cells[3].Value = editMethodStr;
								break;
							}
						}
					}
					catch (System.Exception arg_61E_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_61E_0.StackTrace);
					}
					this.textBox_pinTemplate.Visible = false;
					this.numericUpDown_csyzdhTemplate.Visible = false;
					this.comboBox_csyzdhTemplate_FourWire.Visible = false;
					this.comboBox_MeasMethod.Visible = false;
					this.dataGridView1.ScrollBars = ScrollBars.Both;
				}
			}
			catch (System.Exception arg_668_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_668_0.StackTrace);
			}
		}
		private void dataGridView1_SelectionChanged(object sender, System.EventArgs e)
		{
			try
			{
			}
			catch (System.Exception arg_02_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_02_0.StackTrace);
			}
		}
		private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.Rows.Count > 0)
				{
					string testMethodStr = "";
					try
					{
						this.currSelectedRowStr = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
						this.currSelectedPinStr = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
						this.textBox_pinTemplate.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
						testMethodStr = this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
						this.comboBox_MeasMethod.Text = testMethodStr;
						if (testMethodStr == ctFormAddInterface.TEST_TWOWIRE_METHOD)
						{
							this.numericUpDown_csyzdhTemplate.Text = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
						}
						else
						{
							this.comboBox_csyzdhTemplate_FourWire.Text = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
						}
						int cellTop = 0;
						for (int i = this.dataGridView1.FirstDisplayedCell.RowIndex; i < e.RowIndex; i++)
						{
							cellTop = this.dataGridView1.Rows[i].Height + cellTop;
						}
						System.Drawing.Point location = this.groupBox1.Location;
						int iLeft = this.dataGridView1.Location.X + location.X;
						System.Drawing.Point location2 = this.groupBox1.Location;
						int iTop = this.dataGridView1.Location.Y + location2.Y;
						iLeft = this.dataGridView1.Columns[0].Width + iLeft + 2;
						iTop = this.dataGridView1.ColumnHeadersHeight + cellTop + iTop + 2;
						this.textBox_pinTemplate.Left = iLeft;
						this.textBox_pinTemplate.Top = iTop;
						this.textBox_pinTemplate.Height = this.dataGridView1.RowTemplate.Height + 3;
						this.textBox_pinTemplate.Width = this.dataGridView1.Columns[1].Width - 2;
						iLeft = this.dataGridView1.Columns[1].Width + iLeft;
						this.numericUpDown_csyzdhTemplate.Left = iLeft;
						this.numericUpDown_csyzdhTemplate.Top = iTop;
						this.numericUpDown_csyzdhTemplate.Height = this.dataGridView1.RowTemplate.Height + 3;
						this.numericUpDown_csyzdhTemplate.Width = this.dataGridView1.Columns[2].Width - 2;
						this.comboBox_csyzdhTemplate_FourWire.Left = iLeft;
						this.comboBox_csyzdhTemplate_FourWire.Top = iTop;
						this.comboBox_csyzdhTemplate_FourWire.Height = this.dataGridView1.RowTemplate.Height + 3;
						this.comboBox_csyzdhTemplate_FourWire.Width = this.dataGridView1.Columns[2].Width - 2;
						iLeft = this.dataGridView1.Columns[2].Width + iLeft;
						this.comboBox_MeasMethod.Left = iLeft;
						this.comboBox_MeasMethod.Top = iTop;
						this.comboBox_MeasMethod.Height = this.dataGridView1.RowTemplate.Height + 3;
						this.comboBox_MeasMethod.Width = this.dataGridView1.Columns[3].Width - 2;
					}
					catch (System.Exception ex)
					{
						KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
						this.dataGridView1.ScrollBars = ScrollBars.Both;
					}
					this.textBox_pinTemplate.Visible = true;
					this.textBox_pinTemplate.Focus();
					this.comboBox_MeasMethod.Visible = true;
					if (testMethodStr == ctFormAddInterface.TEST_TWOWIRE_METHOD)
					{
						this.numericUpDown_csyzdhTemplate.Visible = true;
					}
					else
					{
						this.comboBox_csyzdhTemplate_FourWire.Visible = true;
					}
				}
			}
			catch (System.Exception ex2)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex2.StackTrace);
				this.currSelectedRowStr = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
				this.currSelectedPinStr = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
			}
		}
		private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
		{
			try
			{
				this.SetControlValueToDGVFunc();
			}
			catch (System.Exception arg_08_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_08_0.StackTrace);
			}
		}
		private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.SetControlValueToDGVFunc();
				}
			}
			catch (System.Exception arg_12_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_12_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool SaveToExcelFileFunc(string xlsxFile, string csvFile, string plugStr, string bzStr)
		{
			bool bSuccFlag = true;
			try
			{
				if (string.IsNullOrEmpty(xlsxFile) || string.IsNullOrEmpty(csvFile))
				{
					return false;
				}
				Workbook wb = new Workbook();
				Worksheet sht = wb.Worksheets[0];
				Cells cells = sht.Cells;
				Style st = wb.Styles[wb.Styles.Add()];
				st.HorizontalAlignment = TextAlignmentType.Center;
				st.VerticalAlignment = TextAlignmentType.Center;
				st.Font.Name = "宋体";
				st.Font.Size = 11;
				this.putValue(cells, "序号", 0, 0, st);
				this.putValue(cells, "接口代号", 0, 1, st);
				this.putValue(cells, "针脚号", 0, 2, st);
				this.putValue(cells, "测量方法", 0, 3, st);
				int iRow = 1;
				try
				{
					for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
					{
						string temp0Str = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
						string temp1Str = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
						string temp2Str = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
						string temp3Str = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
						this.putValue(cells, temp0Str, iRow, 0, st);
						this.putValue(cells, temp1Str, iRow, 1, st);
						this.putValue(cells, temp2Str, iRow, 2, st);
						this.putValue(cells, temp3Str, iRow, 3, st);
						iRow++;
					}
				}
				catch (System.Exception arg_1D0_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_1D0_0.StackTrace);
				}
				wb.Save(xlsxFile, SaveFormat.Xlsx);
				wb = null;
				wb = new Workbook();
				sht = wb.Worksheets[0];
				cells = sht.Cells;
				st = wb.Styles[wb.Styles.Add()];
				st.HorizontalAlignment = TextAlignmentType.Center;
				st.VerticalAlignment = TextAlignmentType.Center;
				st.Font.Name = "宋体";
				st.Font.Size = 11;
				this.putValue(cells, "序号", 0, 0, st);
				this.putValue(cells, "接口代号", 0, 1, st);
				this.putValue(cells, "针脚号", 0, 2, st);
				this.putValue(cells, "测量方法", 0, 3, st);
				iRow = 1;
				try
				{
					for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
					{
						string temp0Str2 = this.dataGridView1.Rows[j].Cells[0].Value.ToString();
						string temp1Str2 = this.dataGridView1.Rows[j].Cells[1].Value.ToString();
						string temp2Str2 = this.dataGridView1.Rows[j].Cells[2].Value.ToString();
						string temp3Str2 = this.dataGridView1.Rows[j].Cells[3].Value.ToString();
						temp2Str2 = temp2Str2.Replace(",", "&");
						this.putValue(cells, temp0Str2, iRow, 0, st);
						this.putValue(cells, temp1Str2, iRow, 1, st);
						this.putValue(cells, temp2Str2, iRow, 2, st);
						this.putValue(cells, temp3Str2, iRow, 3, st);
						iRow++;
					}
				}
				catch (System.Exception arg_3B0_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_3B0_0.StackTrace);
				}
				wb.Save(csvFile, SaveFormat.CSV);
				wb = null;
			}
			catch (System.Exception arg_3CD_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3CD_0.StackTrace);
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
		private void btnExport_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dataGridView1.Rows.Count <= 0)
				{
					MessageBox.Show("接点定义表为空!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					string orfn = Application.StartupPath;
					FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
					this.folderBrowserDialog1 = folderBrowserDialog;
					folderBrowserDialog.Description = "目录选择";
					if (!string.IsNullOrEmpty(this.exportPathStr))
					{
						this.folderBrowserDialog1.SelectedPath = this.exportPathStr;
					}
					if (DialogResult.OK == this.folderBrowserDialog1.ShowDialog())
					{
						orfn = this.folderBrowserDialog1.SelectedPath;
						this.exportPathStr = this.folderBrowserDialog1.SelectedPath;
						string plugStr = this.textBox_InterfaceNo.Text.ToString();
						string bzStr = this.textBox_Remark.Text.ToString();
						string xlsxFn;
						string csvFn;
						if (string.IsNullOrEmpty(plugStr))
						{
							xlsxFn = orfn + "\\未命名接口.xlsx";
							csvFn = orfn + "\\未命名接口.csv";
						}
						else
						{
							xlsxFn = orfn + "\\" + plugStr + ".xlsx";
							csvFn = orfn + "\\" + plugStr + ".csv";
						}
						if (this.SaveToExcelFileFunc(xlsxFn, csvFn, plugStr, bzStr))
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
			catch (System.Exception arg_148_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_148_0.StackTrace);
			}
		}
		private void radioButton_Pin_TwoWire_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (this.radioButton_Pin_TwoWire.Checked)
				{
					this.numericUpDown_csyzdh.Visible = true;
					this.comboBox_csyzdh_FourWire.Visible = false;
				}
				else
				{
					this.numericUpDown_csyzdh.Visible = false;
					this.comboBox_csyzdh_FourWire.Visible = true;
				}
			}
			catch (System.Exception arg_41_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_41_0.StackTrace);
			}
		}
		private void comboBox_MeasMethod_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (ctFormAddInterface.TEST_TWOWIRE_METHOD == this.comboBox_MeasMethod.Text.ToString())
				{
					this.numericUpDown_csyzdhTemplate.Visible = true;
					this.comboBox_csyzdhTemplate_FourWire.Visible = false;
				}
				else
				{
					this.numericUpDown_csyzdhTemplate.Visible = false;
					this.comboBox_csyzdhTemplate_FourWire.Visible = true;
				}
			}
			catch (System.Exception ex)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
			}
		}
		private void comboBox_csyzdhTemplate_FourWire_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.SetControlValueToDGVFunc();
				}
			}
			catch (System.Exception arg_12_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_12_0.StackTrace);
			}
		}
		private void comboBox_MeasMethod_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.SetControlValueToDGVFunc();
				}
			}
			catch (System.Exception arg_12_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_12_0.StackTrace);
			}
		}
		private void numericUpDown_csyzdh_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_csyzdh.Text.ToString().Trim();
				int iMaxValue = System.Convert.ToInt32(this.numericUpDown_csyzdh.Maximum);
				if (!string.IsNullOrEmpty(tempStr) && System.Convert.ToInt32(tempStr) > iMaxValue)
				{
					MessageBox.Show("针点已超出针脚最大值" + System.Convert.ToString(iMaxValue) + "，请重新输入!", "提示", MessageBoxButtons.OK);
				}
			}
			catch (System.Exception arg_62_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_62_0.StackTrace);
			}
		}
		private void numericUpDown_csyzdhTemplate_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_csyzdhTemplate.Text.ToString().Trim();
				int iMaxValue = System.Convert.ToInt32(this.numericUpDown_csyzdhTemplate.Maximum);
				if (!string.IsNullOrEmpty(tempStr) && System.Convert.ToInt32(tempStr) > iMaxValue)
				{
					MessageBox.Show("针点已超出针脚最大值" + System.Convert.ToString(iMaxValue) + "，请重新输入!", "提示", MessageBoxButtons.OK);
				}
			}
			catch (System.Exception arg_62_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_62_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormAddInterface();
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
