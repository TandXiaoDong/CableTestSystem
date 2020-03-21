using Aspose.Cells;
using Aspose.Words;
using Aspose.Words.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormAddCable : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public ctFormInterfaceLibrary interfaceLibraryForm;
		public ctFormBatchEditCoreRelation batchEditCoreRelationForm;
		public ctFormCableInterfaceManage cableInterfaceManageForm;
		public ctFormEditCoreRelation editCoreRelationForm;
		public ctFormBatchAddPin batchAddPinForm;
		public string loginUser;
		public bool bAddSuccFlag;
		public string exportPathStr;
		public string dbpath;
		public System.Collections.Generic.List<string> plugList;
		public System.Collections.Generic.List<string> plugIDList;
		public System.Collections.Generic.List<PinConnRelationStruct> pinRelationStructList;
		public System.Collections.Generic.List<int> startPinMeasMethodList;
		public System.Collections.Generic.List<string> startPinStrList;
		public System.Collections.Generic.List<int> stopPinMeasMethodList;
		public System.Collections.Generic.List<string> stopPinStrList;
		public string[] strPlugArray;
		public string[] strCoreArray;
		private FlowLayoutPanel flowLayoutPanel_csx;
		private FlowLayoutPanel flowLayoutPanel_clff;
		private FlowLayoutPanel flowLayoutPanel_jkjd;
		private FlowLayoutPanel flowLayoutPanel_bjgx;
		private FlowLayoutPanel flowLayoutPanel_sdqq;
		private Label label3;
		private ComboBox comboBox_startIFBH;
		private Label label5;
		private ComboBox comboBox_startPin;
		private Label label4;
		private ComboBox comboBox_stopIFBH;
		private Label label6;
		private ComboBox comboBox_stopPin;
		private RadioButton radioButton_Pin_FourWire;
		private RadioButton radioButton_Pin_TwoWire;
		private ContextMenuStrip contextMenuStrip_RelationManage;
		private ToolStripMenuItem toolStripMenuItem_Update;
		private ToolStripSeparator toolStripSeparator_DelOne;
		private ToolStripMenuItem toolStripMenuItem_DelOne;
		private ToolStripSeparator toolStripSeparator_DelAll;
		private ToolStripMenuItem toolStripMenuItem_DelAll;
		private Button btnExport;
		private FolderBrowserDialog folderBrowserDialog1;
		private Button btnBatchEdit;
		private Button btnDelAll;
		private TextBox textBox_cableNo;
		private Button btnCablePlugManage;
		private CheckBox checkBox_dlTestFlag;
		private CheckBox checkBox_ddjyTestFlag;
		private DataGridViewTextBoxColumn Column_xh;
		private DataGridViewTextBoxColumn Column_startInterface;
		private DataGridViewTextBoxColumn Column_startPin;
		private DataGridViewTextBoxColumn Column_stopInterface;
		private DataGridViewTextBoxColumn Column_stopPin;
		private DataGridViewTextBoxColumn Column_isGroundFlag;
		private DataGridViewTextBoxColumn Column_dtTestFlag;
		private DataGridViewTextBoxColumn Column_dlTestFlag;
		private DataGridViewTextBoxColumn Column_jyTestFlag;
		private DataGridViewTextBoxColumn Column_ddjyTestFlag;
		private DataGridViewTextBoxColumn Column_nyTestFlag;
		private CheckBox checkBox_nyTestFlag;
		private Label label1;
		private Label label2;
		private TextBox textBox_Remark;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private Button btnSubmit;
		private Button btnQuit;
		private DataGridView dataGridView1;
		private Button btnAdd;
		private Button btnDel;
		private CheckBox checkBox_dtTestFlag;
		private CheckBox checkBox_jyTestFlag;
		private CheckBox checkBox_isGroundFlag;
		private Button btnBatchAdd;
		private Button btnFileImport;
		private OpenFileDialog openFileDialog1;
		private IContainer components;
		public ctFormAddCable(KLineTestProcessor gltProcessor, string lUser)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = lUser;
				}
				catch (System.Exception arg_31_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_31_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormAddCable()
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
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormAddCable));
			this.label1 = new Label();
			this.label2 = new Label();
			this.textBox_Remark = new TextBox();
			this.groupBox1 = new GroupBox();
			this.flowLayoutPanel_jkjd = new FlowLayoutPanel();
			this.label3 = new Label();
			this.comboBox_startIFBH = new ComboBox();
			this.label5 = new Label();
			this.comboBox_startPin = new ComboBox();
			this.label4 = new Label();
			this.comboBox_stopIFBH = new ComboBox();
			this.label6 = new Label();
			this.comboBox_stopPin = new ComboBox();
			this.flowLayoutPanel_clff = new FlowLayoutPanel();
			this.radioButton_Pin_TwoWire = new RadioButton();
			this.radioButton_Pin_FourWire = new RadioButton();
			this.flowLayoutPanel_csx = new FlowLayoutPanel();
			this.checkBox_isGroundFlag = new CheckBox();
			this.checkBox_dtTestFlag = new CheckBox();
			this.checkBox_dlTestFlag = new CheckBox();
			this.checkBox_jyTestFlag = new CheckBox();
			this.checkBox_ddjyTestFlag = new CheckBox();
			this.checkBox_nyTestFlag = new CheckBox();
			this.groupBox2 = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.Column_xh = new DataGridViewTextBoxColumn();
			this.Column_startInterface = new DataGridViewTextBoxColumn();
			this.Column_startPin = new DataGridViewTextBoxColumn();
			this.Column_stopInterface = new DataGridViewTextBoxColumn();
			this.Column_stopPin = new DataGridViewTextBoxColumn();
			this.Column_isGroundFlag = new DataGridViewTextBoxColumn();
			this.Column_dtTestFlag = new DataGridViewTextBoxColumn();
			this.Column_dlTestFlag = new DataGridViewTextBoxColumn();
			this.Column_jyTestFlag = new DataGridViewTextBoxColumn();
			this.Column_ddjyTestFlag = new DataGridViewTextBoxColumn();
			this.Column_nyTestFlag = new DataGridViewTextBoxColumn();
			this.btnSubmit = new Button();
			this.btnQuit = new Button();
			this.btnAdd = new Button();
			this.btnDel = new Button();
			this.btnDelAll = new Button();
			this.btnBatchAdd = new Button();
			this.btnFileImport = new Button();
			this.openFileDialog1 = new OpenFileDialog();
			this.btnCablePlugManage = new Button();
			this.btnBatchEdit = new Button();
			this.textBox_cableNo = new TextBox();
			this.btnExport = new Button();
			this.folderBrowserDialog1 = new FolderBrowserDialog();
			this.contextMenuStrip_RelationManage = new ContextMenuStrip(this.components);
			this.toolStripMenuItem_Update = new ToolStripMenuItem();
			this.toolStripSeparator_DelOne = new ToolStripSeparator();
			this.toolStripMenuItem_DelOne = new ToolStripMenuItem();
			this.toolStripSeparator_DelAll = new ToolStripSeparator();
			this.toolStripMenuItem_DelAll = new ToolStripMenuItem();
			this.flowLayoutPanel_bjgx = new FlowLayoutPanel();
			this.flowLayoutPanel_sdqq = new FlowLayoutPanel();
			this.groupBox1.SuspendLayout();
			this.flowLayoutPanel_jkjd.SuspendLayout();
			this.flowLayoutPanel_clff.SuspendLayout();
			this.flowLayoutPanel_csx.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			this.contextMenuStrip_RelationManage.SuspendLayout();
			this.flowLayoutPanel_bjgx.SuspendLayout();
			this.flowLayoutPanel_sdqq.SuspendLayout();
			base.SuspendLayout();
			this.label1.Anchor = AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(39, 20);
			this.label1.Location = location;
			Padding margin = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin;
			this.label1.Name = "label1";
			System.Drawing.Size size = new System.Drawing.Size(75, 15);
			this.label1.Size = size;
			this.label1.TabIndex = 2;
			this.label1.Text = "线束代号:";
			this.label2.Anchor = AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(545, 20);
			this.label2.Location = location2;
			Padding margin2 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin2;
			this.label2.Name = "label2";
			System.Drawing.Size size2 = new System.Drawing.Size(45, 15);
			this.label2.Size = size2;
			this.label2.TabIndex = 5;
			this.label2.Text = "备注:";
			this.textBox_Remark.Anchor = AnchorStyles.Top;
			this.textBox_Remark.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(598, 16);
			this.textBox_Remark.Location = location3;
			Padding margin3 = new Padding(2);
			this.textBox_Remark.Margin = margin3;
			this.textBox_Remark.MaxLength = 120;
			this.textBox_Remark.Name = "textBox_Remark";
			System.Drawing.Size size3 = new System.Drawing.Size(200, 24);
			this.textBox_Remark.Size = size3;
			this.textBox_Remark.TabIndex = 6;
			this.textBox_Remark.TextAlign = HorizontalAlignment.Center;
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.BackgroundImageLayout = ImageLayout.Stretch;
			this.groupBox1.Controls.Add(this.flowLayoutPanel_jkjd);
			this.groupBox1.Controls.Add(this.flowLayoutPanel_clff);
			this.groupBox1.Controls.Add(this.flowLayoutPanel_csx);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(5, 52);
			this.groupBox1.Location = location4;
			Padding margin4 = new Padding(2);
			this.groupBox1.Margin = margin4;
			this.groupBox1.Name = "groupBox1";
			Padding padding = new Padding(2);
			this.groupBox1.Padding = padding;
			System.Drawing.Size size4 = new System.Drawing.Size(864, 108);
			this.groupBox1.Size = size4;
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "连接关系定义";
			this.flowLayoutPanel_jkjd.Controls.Add(this.label3);
			this.flowLayoutPanel_jkjd.Controls.Add(this.comboBox_startIFBH);
			this.flowLayoutPanel_jkjd.Controls.Add(this.label5);
			this.flowLayoutPanel_jkjd.Controls.Add(this.comboBox_startPin);
			this.flowLayoutPanel_jkjd.Controls.Add(this.label4);
			this.flowLayoutPanel_jkjd.Controls.Add(this.comboBox_stopIFBH);
			this.flowLayoutPanel_jkjd.Controls.Add(this.label6);
			this.flowLayoutPanel_jkjd.Controls.Add(this.comboBox_stopPin);
			System.Drawing.Point location5 = new System.Drawing.Point(92, 18);
			this.flowLayoutPanel_jkjd.Location = location5;
			Padding margin5 = new Padding(2);
			this.flowLayoutPanel_jkjd.Margin = margin5;
			this.flowLayoutPanel_jkjd.Name = "flowLayoutPanel_jkjd";
			System.Drawing.Size size5 = new System.Drawing.Size(458, 80);
			this.flowLayoutPanel_jkjd.Size = size5;
			this.flowLayoutPanel_jkjd.TabIndex = 35;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(4, 15);
			this.label3.Location = location6;
			Padding margin6 = new Padding(4, 15, 2, 0);
			this.label3.Margin = margin6;
			this.label3.Name = "label3";
			System.Drawing.Size size6 = new System.Drawing.Size(75, 15);
			this.label3.Size = size6;
			this.label3.TabIndex = 0;
			this.label3.Text = "起点接口:";
			this.comboBox_startIFBH.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_startIFBH.FormattingEnabled = true;
			System.Drawing.Point location7 = new System.Drawing.Point(85, 13);
			this.comboBox_startIFBH.Location = location7;
			Padding margin7 = new Padding(4, 13, 2, 2);
			this.comboBox_startIFBH.Margin = margin7;
			this.comboBox_startIFBH.Name = "comboBox_startIFBH";
			System.Drawing.Size size7 = new System.Drawing.Size(166, 22);
			this.comboBox_startIFBH.Size = size7;
			this.comboBox_startIFBH.TabIndex = 7;
			this.comboBox_startIFBH.SelectedIndexChanged += new System.EventHandler(this.comboBox_startIFBH_SelectedIndexChanged);
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(257, 15);
			this.label5.Location = location8;
			Padding margin8 = new Padding(4, 15, 2, 0);
			this.label5.Margin = margin8;
			this.label5.Name = "label5";
			System.Drawing.Size size8 = new System.Drawing.Size(75, 15);
			this.label5.Size = size8;
			this.label5.TabIndex = 0;
			this.label5.Text = "起点接点:";
			this.comboBox_startPin.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_startPin.FormattingEnabled = true;
			System.Drawing.Point location9 = new System.Drawing.Point(338, 13);
			this.comboBox_startPin.Location = location9;
			Padding margin9 = new Padding(4, 13, 2, 2);
			this.comboBox_startPin.Margin = margin9;
			this.comboBox_startPin.Name = "comboBox_startPin";
			System.Drawing.Size size9 = new System.Drawing.Size(114, 22);
			this.comboBox_startPin.Size = size9;
			this.comboBox_startPin.TabIndex = 8;
			this.comboBox_startPin.SelectedIndexChanged += new System.EventHandler(this.comboBox_startPin_SelectedIndexChanged);
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location10 = new System.Drawing.Point(4, 52);
			this.label4.Location = location10;
			Padding margin10 = new Padding(4, 15, 2, 0);
			this.label4.Margin = margin10;
			this.label4.Name = "label4";
			System.Drawing.Size size10 = new System.Drawing.Size(75, 15);
			this.label4.Size = size10;
			this.label4.TabIndex = 0;
			this.label4.Text = "终点接口:";
			this.comboBox_stopIFBH.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_stopIFBH.FormattingEnabled = true;
			System.Drawing.Point location11 = new System.Drawing.Point(85, 50);
			this.comboBox_stopIFBH.Location = location11;
			Padding margin11 = new Padding(4, 13, 2, 2);
			this.comboBox_stopIFBH.Margin = margin11;
			this.comboBox_stopIFBH.Name = "comboBox_stopIFBH";
			System.Drawing.Size size11 = new System.Drawing.Size(166, 22);
			this.comboBox_stopIFBH.Size = size11;
			this.comboBox_stopIFBH.TabIndex = 9;
			this.comboBox_stopIFBH.SelectedIndexChanged += new System.EventHandler(this.comboBox_stopIFBH_SelectedIndexChanged);
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location12 = new System.Drawing.Point(257, 52);
			this.label6.Location = location12;
			Padding margin12 = new Padding(4, 15, 2, 0);
			this.label6.Margin = margin12;
			this.label6.Name = "label6";
			System.Drawing.Size size12 = new System.Drawing.Size(75, 15);
			this.label6.Size = size12;
			this.label6.TabIndex = 0;
			this.label6.Text = "终点接点:";
			this.comboBox_stopPin.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_stopPin.FormattingEnabled = true;
			System.Drawing.Point location13 = new System.Drawing.Point(338, 50);
			this.comboBox_stopPin.Location = location13;
			Padding margin13 = new Padding(4, 13, 2, 2);
			this.comboBox_stopPin.Margin = margin13;
			this.comboBox_stopPin.Name = "comboBox_stopPin";
			System.Drawing.Size size13 = new System.Drawing.Size(114, 22);
			this.comboBox_stopPin.Size = size13;
			this.comboBox_stopPin.TabIndex = 10;
			this.flowLayoutPanel_clff.Controls.Add(this.radioButton_Pin_TwoWire);
			this.flowLayoutPanel_clff.Controls.Add(this.radioButton_Pin_FourWire);
			System.Drawing.Point location14 = new System.Drawing.Point(9, 18);
			this.flowLayoutPanel_clff.Location = location14;
			Padding margin14 = new Padding(2);
			this.flowLayoutPanel_clff.Margin = margin14;
			this.flowLayoutPanel_clff.Name = "flowLayoutPanel_clff";
			System.Drawing.Size size14 = new System.Drawing.Size(79, 80);
			this.flowLayoutPanel_clff.Size = size14;
			this.flowLayoutPanel_clff.TabIndex = 34;
			this.radioButton_Pin_TwoWire.AutoSize = true;
			this.radioButton_Pin_TwoWire.Checked = true;
			this.radioButton_Pin_TwoWire.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location15 = new System.Drawing.Point(4, 14);
			this.radioButton_Pin_TwoWire.Location = location15;
			Padding margin15 = new Padding(4, 14, 2, 2);
			this.radioButton_Pin_TwoWire.Margin = margin15;
			this.radioButton_Pin_TwoWire.Name = "radioButton_Pin_TwoWire";
			System.Drawing.Size size15 = new System.Drawing.Size(70, 19);
			this.radioButton_Pin_TwoWire.Size = size15;
			this.radioButton_Pin_TwoWire.TabIndex = 32;
			this.radioButton_Pin_TwoWire.TabStop = true;
			this.radioButton_Pin_TwoWire.Text = "二线法";
			this.radioButton_Pin_TwoWire.UseVisualStyleBackColor = true;
			this.radioButton_Pin_TwoWire.CheckedChanged += new System.EventHandler(this.radioButton_Pin_TwoWire_CheckedChanged);
			this.radioButton_Pin_FourWire.AutoSize = true;
			this.radioButton_Pin_FourWire.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location16 = new System.Drawing.Point(4, 49);
			this.radioButton_Pin_FourWire.Location = location16;
			Padding margin16 = new Padding(4, 14, 2, 2);
			this.radioButton_Pin_FourWire.Margin = margin16;
			this.radioButton_Pin_FourWire.Name = "radioButton_Pin_FourWire";
			System.Drawing.Size size16 = new System.Drawing.Size(70, 19);
			this.radioButton_Pin_FourWire.Size = size16;
			this.radioButton_Pin_FourWire.TabIndex = 31;
			this.radioButton_Pin_FourWire.Text = "四线法";
			this.radioButton_Pin_FourWire.UseVisualStyleBackColor = true;
			this.flowLayoutPanel_csx.Controls.Add(this.checkBox_isGroundFlag);
			this.flowLayoutPanel_csx.Controls.Add(this.checkBox_dtTestFlag);
			this.flowLayoutPanel_csx.Controls.Add(this.checkBox_dlTestFlag);
			this.flowLayoutPanel_csx.Controls.Add(this.checkBox_jyTestFlag);
			this.flowLayoutPanel_csx.Controls.Add(this.checkBox_ddjyTestFlag);
			this.flowLayoutPanel_csx.Controls.Add(this.checkBox_nyTestFlag);
			System.Drawing.Point location17 = new System.Drawing.Point(553, 18);
			this.flowLayoutPanel_csx.Location = location17;
			Padding margin17 = new Padding(2);
			this.flowLayoutPanel_csx.Margin = margin17;
			this.flowLayoutPanel_csx.Name = "flowLayoutPanel_csx";
			System.Drawing.Size size17 = new System.Drawing.Size(290, 80);
			this.flowLayoutPanel_csx.Size = size17;
			this.flowLayoutPanel_csx.TabIndex = 33;
			this.checkBox_isGroundFlag.Anchor = AnchorStyles.Top;
			this.checkBox_isGroundFlag.AutoSize = true;
			System.Drawing.Point location18 = new System.Drawing.Point(4, 15);
			this.checkBox_isGroundFlag.Location = location18;
			Padding margin18 = new Padding(4, 15, 2, 2);
			this.checkBox_isGroundFlag.Margin = margin18;
			this.checkBox_isGroundFlag.Name = "checkBox_isGroundFlag";
			System.Drawing.Size size18 = new System.Drawing.Size(88, 19);
			this.checkBox_isGroundFlag.Size = size18;
			this.checkBox_isGroundFlag.TabIndex = 11;
			this.checkBox_isGroundFlag.Text = "接地    ";
			this.checkBox_isGroundFlag.UseVisualStyleBackColor = true;
			this.checkBox_isGroundFlag.CheckedChanged += new System.EventHandler(this.checkBox_isGroundFlag_CheckedChanged);
			this.checkBox_dtTestFlag.Anchor = AnchorStyles.Top;
			this.checkBox_dtTestFlag.AutoSize = true;
			this.checkBox_dtTestFlag.Checked = true;
			this.checkBox_dtTestFlag.CheckState = CheckState.Checked;
			this.checkBox_dtTestFlag.Enabled = false;
			System.Drawing.Point location19 = new System.Drawing.Point(98, 15);
			this.checkBox_dtTestFlag.Location = location19;
			Padding margin19 = new Padding(4, 15, 2, 2);
			this.checkBox_dtTestFlag.Margin = margin19;
			this.checkBox_dtTestFlag.Name = "checkBox_dtTestFlag";
			System.Drawing.Size size19 = new System.Drawing.Size(86, 19);
			this.checkBox_dtTestFlag.Size = size19;
			this.checkBox_dtTestFlag.TabIndex = 12;
			this.checkBox_dtTestFlag.Text = "导通测试";
			this.checkBox_dtTestFlag.UseVisualStyleBackColor = true;
			this.checkBox_dlTestFlag.Anchor = AnchorStyles.Top;
			this.checkBox_dlTestFlag.AutoSize = true;
			this.checkBox_dlTestFlag.Checked = true;
			this.checkBox_dlTestFlag.CheckState = CheckState.Checked;
			System.Drawing.Point location20 = new System.Drawing.Point(190, 15);
			this.checkBox_dlTestFlag.Location = location20;
			Padding margin20 = new Padding(4, 15, 2, 2);
			this.checkBox_dlTestFlag.Margin = margin20;
			this.checkBox_dlTestFlag.Name = "checkBox_dlTestFlag";
			System.Drawing.Size size20 = new System.Drawing.Size(86, 19);
			this.checkBox_dlTestFlag.Size = size20;
			this.checkBox_dlTestFlag.TabIndex = 13;
			this.checkBox_dlTestFlag.Text = "短路测试";
			this.checkBox_dlTestFlag.UseVisualStyleBackColor = true;
			this.checkBox_jyTestFlag.Anchor = AnchorStyles.Top;
			this.checkBox_jyTestFlag.AutoSize = true;
			this.checkBox_jyTestFlag.Checked = true;
			this.checkBox_jyTestFlag.CheckState = CheckState.Checked;
			System.Drawing.Point location21 = new System.Drawing.Point(4, 51);
			this.checkBox_jyTestFlag.Location = location21;
			Padding margin21 = new Padding(4, 15, 2, 2);
			this.checkBox_jyTestFlag.Margin = margin21;
			this.checkBox_jyTestFlag.Name = "checkBox_jyTestFlag";
			System.Drawing.Size size21 = new System.Drawing.Size(86, 19);
			this.checkBox_jyTestFlag.Size = size21;
			this.checkBox_jyTestFlag.TabIndex = 14;
			this.checkBox_jyTestFlag.Text = "绝缘测试";
			this.checkBox_jyTestFlag.UseVisualStyleBackColor = true;
			this.checkBox_jyTestFlag.CheckedChanged += new System.EventHandler(this.checkBox_jyTestFlag_CheckedChanged);
			this.checkBox_ddjyTestFlag.Anchor = AnchorStyles.Top;
			this.checkBox_ddjyTestFlag.AutoSize = true;
			this.checkBox_ddjyTestFlag.Checked = true;
			this.checkBox_ddjyTestFlag.CheckState = CheckState.Checked;
			System.Drawing.Point location22 = new System.Drawing.Point(96, 51);
			this.checkBox_ddjyTestFlag.Location = location22;
			Padding margin22 = new Padding(4, 15, 2, 2);
			this.checkBox_ddjyTestFlag.Margin = margin22;
			this.checkBox_ddjyTestFlag.Name = "checkBox_ddjyTestFlag";
			System.Drawing.Size size22 = new System.Drawing.Size(86, 19);
			this.checkBox_ddjyTestFlag.Size = size22;
			this.checkBox_ddjyTestFlag.TabIndex = 15;
			this.checkBox_ddjyTestFlag.Text = "对地绝缘";
			this.checkBox_ddjyTestFlag.UseVisualStyleBackColor = true;
			this.checkBox_ddjyTestFlag.CheckedChanged += new System.EventHandler(this.checkBox_ddjyTestFlag_CheckedChanged);
			this.checkBox_nyTestFlag.Anchor = AnchorStyles.Top;
			this.checkBox_nyTestFlag.AutoSize = true;
			this.checkBox_nyTestFlag.Checked = true;
			this.checkBox_nyTestFlag.CheckState = CheckState.Checked;
			System.Drawing.Point location23 = new System.Drawing.Point(188, 51);
			this.checkBox_nyTestFlag.Location = location23;
			Padding margin23 = new Padding(4, 15, 2, 2);
			this.checkBox_nyTestFlag.Margin = margin23;
			this.checkBox_nyTestFlag.Name = "checkBox_nyTestFlag";
			System.Drawing.Size size23 = new System.Drawing.Size(86, 19);
			this.checkBox_nyTestFlag.Size = size23;
			this.checkBox_nyTestFlag.TabIndex = 16;
			this.checkBox_nyTestFlag.Text = "耐压测试";
			this.checkBox_nyTestFlag.UseVisualStyleBackColor = true;
			this.checkBox_nyTestFlag.CheckedChanged += new System.EventHandler(this.checkBox_nyTestFlag_CheckedChanged);
			this.groupBox2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox2.Controls.Add(this.dataGridView1);
			this.groupBox2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location24 = new System.Drawing.Point(5, 212);
			this.groupBox2.Location = location24;
			Padding margin24 = new Padding(2);
			this.groupBox2.Margin = margin24;
			this.groupBox2.Name = "groupBox2";
			Padding padding2 = new Padding(2);
			this.groupBox2.Padding = padding2;
			System.Drawing.Size size24 = new System.Drawing.Size(864, 297);
			this.groupBox2.Size = size24;
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "线束连接关系定义表";
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			System.Drawing.Color window = System.Drawing.SystemColors.Window;
			this.dataGridView1.BackgroundColor = window;
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[]
			{
				this.Column_xh,
				this.Column_startInterface,
				this.Column_startPin,
				this.Column_stopInterface,
				this.Column_stopPin,
				this.Column_isGroundFlag,
				this.Column_dtTestFlag,
				this.Column_dlTestFlag,
				this.Column_jyTestFlag,
				this.Column_ddjyTestFlag,
				this.Column_nyTestFlag
			};
			this.dataGridView1.Columns.AddRange(dataGridViewColumns);
			this.dataGridView1.Dock = DockStyle.Fill;
			System.Drawing.Point location25 = new System.Drawing.Point(2, 19);
			this.dataGridView1.Location = location25;
			Padding margin25 = new Padding(2);
			this.dataGridView1.Margin = margin25;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size25 = new System.Drawing.Size(860, 276);
			this.dataGridView1.Size = size25;
			this.dataGridView1.TabIndex = 13;
			this.dataGridView1.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
			this.dataGridView1.CellMouseDown += new DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
			this.Column_xh.HeaderText = "序号";
			this.Column_xh.Name = "Column_xh";
			this.Column_xh.ReadOnly = true;
			this.Column_xh.Width = 70;
			this.Column_startInterface.HeaderText = "起点接口";
			this.Column_startInterface.Name = "Column_startInterface";
			this.Column_startInterface.ReadOnly = true;
			this.Column_startInterface.Width = 98;
			this.Column_startPin.HeaderText = "起点接点";
			this.Column_startPin.Name = "Column_startPin";
			this.Column_startPin.ReadOnly = true;
			this.Column_startPin.Width = 98;
			this.Column_stopInterface.HeaderText = "终点接口";
			this.Column_stopInterface.Name = "Column_stopInterface";
			this.Column_stopInterface.ReadOnly = true;
			this.Column_stopInterface.Width = 98;
			this.Column_stopPin.HeaderText = "终点接点";
			this.Column_stopPin.Name = "Column_stopPin";
			this.Column_stopPin.ReadOnly = true;
			this.Column_stopPin.Width = 98;
			this.Column_isGroundFlag.HeaderText = "接地";
			this.Column_isGroundFlag.Name = "Column_isGroundFlag";
			this.Column_isGroundFlag.ReadOnly = true;
			this.Column_isGroundFlag.Width = 70;
			this.Column_dtTestFlag.HeaderText = "导通测试";
			this.Column_dtTestFlag.Name = "Column_dtTestFlag";
			this.Column_dtTestFlag.ReadOnly = true;
			this.Column_dtTestFlag.Width = 110;
			this.Column_dlTestFlag.HeaderText = "短路测试";
			this.Column_dlTestFlag.Name = "Column_dlTestFlag";
			this.Column_dlTestFlag.ReadOnly = true;
			this.Column_dlTestFlag.Width = 98;
			this.Column_jyTestFlag.HeaderText = "绝缘测试";
			this.Column_jyTestFlag.Name = "Column_jyTestFlag";
			this.Column_jyTestFlag.ReadOnly = true;
			this.Column_jyTestFlag.Width = 98;
			this.Column_ddjyTestFlag.HeaderText = "对地绝缘";
			this.Column_ddjyTestFlag.Name = "Column_ddjyTestFlag";
			this.Column_ddjyTestFlag.ReadOnly = true;
			this.Column_nyTestFlag.HeaderText = "耐压测试";
			this.Column_nyTestFlag.Name = "Column_nyTestFlag";
			this.Column_nyTestFlag.ReadOnly = true;
			this.btnSubmit.Anchor = AnchorStyles.Bottom;
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location26 = new System.Drawing.Point(462, 2);
			this.btnSubmit.Location = location26;
			Padding margin26 = new Padding(30, 2, 2, 2);
			this.btnSubmit.Margin = margin26;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size26 = new System.Drawing.Size(112, 24);
			this.btnSubmit.Size = size26;
			this.btnSubmit.TabIndex = 0;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location27 = new System.Drawing.Point(606, 2);
			this.btnQuit.Location = location27;
			Padding margin27 = new Padding(30, 2, 2, 2);
			this.btnQuit.Margin = margin27;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size27 = new System.Drawing.Size(112, 24);
			this.btnQuit.Size = size27;
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btnAdd.Anchor = AnchorStyles.Top;
			this.btnAdd.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location28 = new System.Drawing.Point(38, 2);
			this.btnAdd.Location = location28;
			Padding margin28 = new Padding(38, 2, 2, 2);
			this.btnAdd.Margin = margin28;
			this.btnAdd.Name = "btnAdd";
			System.Drawing.Size size28 = new System.Drawing.Size(158, 24);
			this.btnAdd.Size = size28;
			this.btnAdd.TabIndex = 22;
			this.btnAdd.Text = "添加单个连接关系";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnDel.Anchor = AnchorStyles.Bottom;
			this.btnDel.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location29 = new System.Drawing.Point(30, 2);
			this.btnDel.Location = location29;
			Padding margin29 = new Padding(30, 2, 2, 2);
			this.btnDel.Margin = margin29;
			this.btnDel.Name = "btnDel";
			System.Drawing.Size size29 = new System.Drawing.Size(112, 24);
			this.btnDel.Size = size29;
			this.btnDel.TabIndex = 22;
			this.btnDel.Text = "删除连接关系";
			this.btnDel.UseVisualStyleBackColor = true;
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			this.btnDelAll.Anchor = AnchorStyles.Bottom;
			this.btnDelAll.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location30 = new System.Drawing.Point(174, 2);
			this.btnDelAll.Location = location30;
			Padding margin30 = new Padding(30, 2, 2, 2);
			this.btnDelAll.Margin = margin30;
			this.btnDelAll.Name = "btnDelAll";
			System.Drawing.Size size30 = new System.Drawing.Size(112, 24);
			this.btnDelAll.Size = size30;
			this.btnDelAll.TabIndex = 22;
			this.btnDelAll.Text = "删除所有关系";
			this.btnDelAll.UseVisualStyleBackColor = true;
			this.btnDelAll.Click += new System.EventHandler(this.btnDelAll_Click);
			this.btnBatchAdd.Anchor = AnchorStyles.Top;
			this.btnBatchAdd.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location31 = new System.Drawing.Point(228, 2);
			this.btnBatchAdd.Location = location31;
			Padding margin31 = new Padding(30, 2, 2, 2);
			this.btnBatchAdd.Margin = margin31;
			this.btnBatchAdd.Name = "btnBatchAdd";
			System.Drawing.Size size31 = new System.Drawing.Size(158, 24);
			this.btnBatchAdd.Size = size31;
			this.btnBatchAdd.TabIndex = 22;
			this.btnBatchAdd.Text = "批量添加连接关系";
			this.btnBatchAdd.UseVisualStyleBackColor = true;
			this.btnBatchAdd.Click += new System.EventHandler(this.btnBatchAdd_Click);
			this.btnFileImport.Anchor = AnchorStyles.Top;
			this.btnFileImport.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location32 = new System.Drawing.Point(418, 2);
			this.btnFileImport.Location = location32;
			Padding margin32 = new Padding(30, 2, 2, 2);
			this.btnFileImport.Margin = margin32;
			this.btnFileImport.Name = "btnFileImport";
			System.Drawing.Size size32 = new System.Drawing.Size(158, 24);
			this.btnFileImport.Size = size32;
			this.btnFileImport.TabIndex = 22;
			this.btnFileImport.Text = "由文件导入连接关系";
			this.btnFileImport.UseVisualStyleBackColor = true;
			this.btnFileImport.Click += new System.EventHandler(this.btnFileImport_Click);
			this.openFileDialog1.FileName = "openFileDialog1";
			this.btnCablePlugManage.Anchor = AnchorStyles.Top;
			this.btnCablePlugManage.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.btnCablePlugManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			System.Drawing.Point location33 = new System.Drawing.Point(386, 15);
			this.btnCablePlugManage.Location = location33;
			Padding margin33 = new Padding(2);
			this.btnCablePlugManage.Margin = margin33;
			this.btnCablePlugManage.Name = "btnCablePlugManage";
			System.Drawing.Size size33 = new System.Drawing.Size(135, 24);
			this.btnCablePlugManage.Size = size33;
			this.btnCablePlugManage.TabIndex = 4;
			this.btnCablePlugManage.Text = "线束接口管理";
			this.btnCablePlugManage.UseVisualStyleBackColor = true;
			this.btnCablePlugManage.Click += new System.EventHandler(this.btnCablePlugManage_Click);
			this.btnBatchEdit.Anchor = AnchorStyles.Top;
			this.btnBatchEdit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location34 = new System.Drawing.Point(608, 2);
			this.btnBatchEdit.Location = location34;
			Padding margin34 = new Padding(30, 2, 2, 2);
			this.btnBatchEdit.Margin = margin34;
			this.btnBatchEdit.Name = "btnBatchEdit";
			System.Drawing.Size size34 = new System.Drawing.Size(112, 24);
			this.btnBatchEdit.Size = size34;
			this.btnBatchEdit.TabIndex = 27;
			this.btnBatchEdit.Text = "批量修改";
			this.btnBatchEdit.UseVisualStyleBackColor = true;
			this.btnBatchEdit.Click += new System.EventHandler(this.btnBatchEdit_Click);
			this.textBox_cableNo.Anchor = AnchorStyles.Top;
			this.textBox_cableNo.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location35 = new System.Drawing.Point(121, 16);
			this.textBox_cableNo.Location = location35;
			Padding margin35 = new Padding(2);
			this.textBox_cableNo.Margin = margin35;
			this.textBox_cableNo.MaxLength = 120;
			this.textBox_cableNo.Name = "textBox_cableNo";
			System.Drawing.Size size35 = new System.Drawing.Size(241, 24);
			this.textBox_cableNo.Size = size35;
			this.textBox_cableNo.TabIndex = 3;
			this.textBox_cableNo.TextAlign = HorizontalAlignment.Center;
			this.btnExport.Anchor = AnchorStyles.Bottom;
			this.btnExport.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location36 = new System.Drawing.Point(318, 2);
			this.btnExport.Location = location36;
			Padding margin36 = new Padding(30, 2, 2, 2);
			this.btnExport.Margin = margin36;
			this.btnExport.Name = "btnExport";
			System.Drawing.Size size36 = new System.Drawing.Size(112, 24);
			this.btnExport.Size = size36;
			this.btnExport.TabIndex = 29;
			this.btnExport.Text = "导出连接关系";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			this.contextMenuStrip_RelationManage.Font = new System.Drawing.Font("宋体", 10.8f);
			ToolStripItem[] toolStripItems = new ToolStripItem[]
			{
				this.toolStripMenuItem_Update,
				this.toolStripSeparator_DelOne,
				this.toolStripMenuItem_DelOne,
				this.toolStripSeparator_DelAll,
				this.toolStripMenuItem_DelAll
			};
			this.contextMenuStrip_RelationManage.Items.AddRange(toolStripItems);
			this.contextMenuStrip_RelationManage.Name = "contextMenuStrip1";
			System.Drawing.Size size37 = new System.Drawing.Size(165, 82);
			this.contextMenuStrip_RelationManage.Size = size37;
			this.toolStripMenuItem_Update.Name = "toolStripMenuItem_Update";
			System.Drawing.Size size38 = new System.Drawing.Size(164, 22);
			this.toolStripMenuItem_Update.Size = size38;
			this.toolStripMenuItem_Update.Text = "修改连接关系";
			this.toolStripMenuItem_Update.Click += new System.EventHandler(this.toolStripMenuItem_Update_Click);
			this.toolStripSeparator_DelOne.Name = "toolStripSeparator_DelOne";
			System.Drawing.Size size39 = new System.Drawing.Size(161, 6);
			this.toolStripSeparator_DelOne.Size = size39;
			this.toolStripMenuItem_DelOne.Name = "toolStripMenuItem_DelOne";
			System.Drawing.Size size40 = new System.Drawing.Size(164, 22);
			this.toolStripMenuItem_DelOne.Size = size40;
			this.toolStripMenuItem_DelOne.Text = "删除连接关系";
			this.toolStripMenuItem_DelOne.Click += new System.EventHandler(this.toolStripMenuItem_DelOne_Click);
			this.toolStripSeparator_DelAll.Name = "toolStripSeparator_DelAll";
			System.Drawing.Size size41 = new System.Drawing.Size(161, 6);
			this.toolStripSeparator_DelAll.Size = size41;
			this.toolStripMenuItem_DelAll.Name = "toolStripMenuItem_DelAll";
			System.Drawing.Size size42 = new System.Drawing.Size(164, 22);
			this.toolStripMenuItem_DelAll.Size = size42;
			this.toolStripMenuItem_DelAll.Text = "删除所有关系";
			this.toolStripMenuItem_DelAll.Click += new System.EventHandler(this.toolStripMenuItem_DelAll_Click);
			this.flowLayoutPanel_bjgx.Anchor = AnchorStyles.Top;
			this.flowLayoutPanel_bjgx.Controls.Add(this.btnAdd);
			this.flowLayoutPanel_bjgx.Controls.Add(this.btnBatchAdd);
			this.flowLayoutPanel_bjgx.Controls.Add(this.btnFileImport);
			this.flowLayoutPanel_bjgx.Controls.Add(this.btnBatchEdit);
			System.Drawing.Point location37 = new System.Drawing.Point(17, 168);
			this.flowLayoutPanel_bjgx.Location = location37;
			Padding margin37 = new Padding(2);
			this.flowLayoutPanel_bjgx.Margin = margin37;
			this.flowLayoutPanel_bjgx.Name = "flowLayoutPanel_bjgx";
			System.Drawing.Size size43 = new System.Drawing.Size(789, 30);
			this.flowLayoutPanel_bjgx.Size = size43;
			this.flowLayoutPanel_bjgx.TabIndex = 30;
			this.flowLayoutPanel_sdqq.Anchor = AnchorStyles.Bottom;
			this.flowLayoutPanel_sdqq.Controls.Add(this.btnDel);
			this.flowLayoutPanel_sdqq.Controls.Add(this.btnDelAll);
			this.flowLayoutPanel_sdqq.Controls.Add(this.btnExport);
			this.flowLayoutPanel_sdqq.Controls.Add(this.btnSubmit);
			this.flowLayoutPanel_sdqq.Controls.Add(this.btnQuit);
			System.Drawing.Point location38 = new System.Drawing.Point(17, 522);
			this.flowLayoutPanel_sdqq.Location = location38;
			Padding margin38 = new Padding(2);
			this.flowLayoutPanel_sdqq.Margin = margin38;
			this.flowLayoutPanel_sdqq.Name = "flowLayoutPanel_sdqq";
			System.Drawing.Size size44 = new System.Drawing.Size(789, 30);
			this.flowLayoutPanel_sdqq.Size = size44;
			this.flowLayoutPanel_sdqq.TabIndex = 31;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(874, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.flowLayoutPanel_sdqq);
			base.Controls.Add(this.flowLayoutPanel_bjgx);
			base.Controls.Add(this.textBox_cableNo);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.btnCablePlugManage);
			base.Controls.Add(this.textBox_Remark);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin39 = new Padding(2);
			base.Margin = margin39;
			base.Name = "ctFormAddCable";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "添加线束";
			base.Load += new System.EventHandler(this.ctFormEditCable_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormAddCable_SizeChanged);
			this.groupBox1.ResumeLayout(false);
			this.flowLayoutPanel_jkjd.ResumeLayout(false);
			this.flowLayoutPanel_jkjd.PerformLayout();
			this.flowLayoutPanel_clff.ResumeLayout(false);
			this.flowLayoutPanel_clff.PerformLayout();
			this.flowLayoutPanel_csx.ResumeLayout(false);
			this.flowLayoutPanel_csx.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			this.contextMenuStrip_RelationManage.ResumeLayout(false);
			this.flowLayoutPanel_bjgx.ResumeLayout(false);
			this.flowLayoutPanel_sdqq.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void checkBox_isGroundFlag_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.checkBox_isGroundFlag.Checked)
			{
				this.checkBox_jyTestFlag.Checked = false;
				this.checkBox_ddjyTestFlag.Checked = false;
				this.checkBox_nyTestFlag.Checked = false;
			}
		}
		private void ctFormEditCable_Load(object sender, System.EventArgs e)
		{
			try
			{
				try
				{
					this.textBox_cableNo.Text = "";
					this.textBox_Remark.Text = "";
					this.bAddSuccFlag = false;
					this.plugList = new System.Collections.Generic.List<string>();
					this.plugIDList = new System.Collections.Generic.List<string>();
					this.pinRelationStructList = new System.Collections.Generic.List<PinConnRelationStruct>();
					this.startPinMeasMethodList = new System.Collections.Generic.List<int>();
					this.startPinStrList = new System.Collections.Generic.List<string>();
					this.stopPinMeasMethodList = new System.Collections.Generic.List<int>();
					this.stopPinStrList = new System.Collections.Generic.List<string>();
					for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
					{
						this.dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
						this.dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					}
					for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
					{
						this.dataGridView1.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
					}
					this.checkBox_dtTestFlag.Visible = this.gLineTestProcessor.bDTTestEnabled;
					this.checkBox_nyTestFlag.Visible = this.gLineTestProcessor.bNYTestEnabled;
					this.checkBox_dlTestFlag.Visible = this.gLineTestProcessor.bDLTestEnabled;
					this.checkBox_jyTestFlag.Visible = this.gLineTestProcessor.bJYTestEnabled;
					this.checkBox_ddjyTestFlag.Visible = this.gLineTestProcessor.bDDJYTestEnabled;
					this.Column_dtTestFlag.Visible = this.gLineTestProcessor.bDTTestEnabled;
					this.Column_nyTestFlag.Visible = this.gLineTestProcessor.bNYTestEnabled;
					this.Column_dlTestFlag.Visible = this.gLineTestProcessor.bDLTestEnabled;
					this.Column_jyTestFlag.Visible = this.gLineTestProcessor.bJYTestEnabled;
					this.Column_ddjyTestFlag.Visible = this.gLineTestProcessor.bDDJYTestEnabled;
				}
				catch (System.Exception arg_1E3_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_1E3_0.StackTrace);
				}
				try
				{
					int ixs = 1;
					KLineTestProcessor sender2 = this.gLineTestProcessor;
					if (sender2.bDTTestEnabled)
					{
						ixs = 2;
					}
					if (sender2.bDLTestEnabled)
					{
						ixs++;
					}
					if (sender2.bJYTestEnabled)
					{
						ixs++;
					}
					if (sender2.bDDJYTestEnabled)
					{
						ixs++;
					}
					if (sender2.bNYTestEnabled)
					{
						ixs++;
					}
					if (1 == ixs % 2)
					{
						ixs = ixs / 2 + 1;
					}
					else
					{
						ixs /= 2;
					}
					System.Drawing.Size size = this.flowLayoutPanel_jkjd.Size;
					System.Drawing.Size size2 = new System.Drawing.Size(ixs * 120, size.Height);
					this.flowLayoutPanel_csx.Size = size2;
					this.flowLayoutPanel_csx.Refresh();
				}
				catch (System.Exception arg_27E_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_27E_0.StackTrace);
				}
				for (int k = 0; k < this.dataGridView1.Rows.Count; k++)
				{
					this.dataGridView1.Rows[k].Selected = false;
				}
				try
				{
					if (this.gLineTestProcessor.iUIDisplayMode == 0)
					{
						base.WindowState = FormWindowState.Normal;
					}
				}
				catch (System.Exception arg_2D3_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_2D3_0.StackTrace);
				}
				this.SetDGVWidthSizeFunc();
			}
			catch (System.Exception arg_2E7_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2E7_0.StackTrace);
			}
		}
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.comboBox_startIFBH.Items.Count <= 0)
				{
					MessageBox.Show("线束接口数量为0!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					string _startPin = this.comboBox_startPin.Text.ToString();
					string _stopPin = this.comboBox_stopPin.Text.ToString();
					if (!string.IsNullOrEmpty(_startPin) && !string.IsNullOrEmpty(_stopPin))
					{
						string _startIFBH = this.comboBox_startIFBH.Text.ToString();
						string _stopIFBH = this.comboBox_stopIFBH.Text.ToString();
						int iRows = this.dataGridView1.Rows.Count;
						for (int i = 0; i < iRows; i++)
						{
							string tempStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
							string tempStr2 = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
							string tempStr3 = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
							string tempStr4 = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
							if (tempStr == _startIFBH && tempStr2 == _startPin && tempStr3 == _stopIFBH && tempStr4 == _stopPin)
							{
								MessageBox.Show("该连接关系已添加!", "提示", MessageBoxButtons.OK);
								return;
							}
							if (tempStr3 == _startIFBH && tempStr4 == _startPin && tempStr == _stopIFBH && tempStr2 == _stopPin)
							{
								MessageBox.Show("该连接关系已添加!", "提示", MessageBoxButtons.OK);
								return;
							}
						}
						string e2 = "否";
						string _isGroundFlagStr = e2;
						string _dtTestFlagStr = e2;
						string _dlTestFlagStr = e2;
						string _jyTestFlagStr = e2;
						string _ddjyTestFlagStr = e2;
						string _nyTestFlagStr = e2;
						if (this.checkBox_isGroundFlag.Checked)
						{
							_isGroundFlagStr = "是";
						}
						if (this.checkBox_dtTestFlag.Checked)
						{
							_dtTestFlagStr = "是";
						}
						if (this.checkBox_dlTestFlag.Checked)
						{
							_dlTestFlagStr = "是";
						}
						if (this.checkBox_jyTestFlag.Checked)
						{
							_jyTestFlagStr = "是";
						}
						if (this.checkBox_ddjyTestFlag.Checked)
						{
							_ddjyTestFlagStr = "是";
						}
						if (this.checkBox_nyTestFlag.Checked)
						{
							_nyTestFlagStr = "是";
						}
						this.dataGridView1.AllowUserToAddRows = true;
						this.dataGridView1.Rows.Add(1);
						int num = iRows + 1;
						this.dataGridView1.Rows[iRows].Cells[0].Value = num.ToString();
						this.dataGridView1.Rows[iRows].Cells[1].Value = _startIFBH;
						this.dataGridView1.Rows[iRows].Cells[2].Value = _startPin;
						this.dataGridView1.Rows[iRows].Cells[3].Value = _stopIFBH;
						this.dataGridView1.Rows[iRows].Cells[4].Value = _stopPin;
						this.dataGridView1.Rows[iRows].Cells[5].Value = _isGroundFlagStr;
						this.dataGridView1.Rows[iRows].Cells[6].Value = _dtTestFlagStr;
						this.dataGridView1.Rows[iRows].Cells[7].Value = _dlTestFlagStr;
						this.dataGridView1.Rows[iRows].Cells[8].Value = _jyTestFlagStr;
						this.dataGridView1.Rows[iRows].Cells[9].Value = _ddjyTestFlagStr;
						this.dataGridView1.Rows[iRows].Cells[10].Value = _nyTestFlagStr;
						this.dataGridView1.AllowUserToAddRows = false;
						if (0 <= this.dataGridView1.Rows.Count - 1)
						{
							this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Selected = true;
						}
					}
					else
					{
						MessageBox.Show("未选择匹配的起点接点或终点接点!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_470_0)
			{
				this.dataGridView1.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_470_0.StackTrace);
			}
		}
		private void btnBatchAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.comboBox_startIFBH.Items.Count <= 0)
				{
					MessageBox.Show("线束接口未定义!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					string _startIFBH = this.comboBox_startIFBH.Text.ToString();
					string _stopIFBH = this.comboBox_stopIFBH.Text.ToString();
					string _startPin = this.comboBox_startPin.Text.ToString();
					string _stopPin = this.comboBox_stopPin.Text.ToString();
					if (!string.IsNullOrEmpty(_startPin) && !string.IsNullOrEmpty(_stopPin))
					{
						int istpIndex = this.comboBox_startPin.SelectedIndex;
						int isppIndex = this.comboBox_stopPin.SelectedIndex;
						int iStartPinCount;
						int iStopPinCount;
						if (_startIFBH == _stopIFBH)
						{
							if (isppIndex > istpIndex)
							{
								iStartPinCount = isppIndex - istpIndex;
								iStopPinCount = this.comboBox_startPin.Items.Count - isppIndex;
							}
							else
							{
								iStartPinCount = istpIndex - isppIndex;
								iStopPinCount = this.comboBox_startPin.Items.Count - istpIndex;
							}
						}
						else
						{
							iStartPinCount = this.comboBox_startPin.Items.Count - istpIndex;
							iStopPinCount = this.comboBox_stopPin.Items.Count - isppIndex;
						}
						int iAllowAddCount;
						if (iStartPinCount > iStopPinCount)
						{
							iAllowAddCount = iStopPinCount;
						}
						else
						{
							iAllowAddCount = iStartPinCount;
						}
						ctFormBatchAddPin ctFormBatchAddPin = new ctFormBatchAddPin(this.gLineTestProcessor, iAllowAddCount);
						this.batchAddPinForm = ctFormBatchAddPin;
						ctFormBatchAddPin.Activate();
						this.batchAddPinForm.ShowDialog();
						int iACount = this.batchAddPinForm.iAddCount;
						if (iACount > 0)
						{
							int iRows = this.dataGridView1.Rows.Count;
							for (int i = 0; i < iRows; i++)
							{
								string tempStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
								string tempStr2 = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
								string tempStr3 = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
								string tempStr4 = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
								if ((tempStr == _startIFBH && tempStr2 == _startPin && tempStr3 == _stopIFBH && tempStr4 == _stopPin) || (tempStr3 == _startIFBH && tempStr4 == _startPin && tempStr == _stopIFBH && tempStr2 == _stopPin))
								{
									MessageBox.Show("该连接关系已添加!", "提示", MessageBoxButtons.OK);
									return;
								}
							}
							string text = "否";
							string _isGroundFlagStr = text;
							string _dtTestFlagStr = text;
							string _dlTestFlagStr = text;
							string _jyTestFlagStr = text;
							string _ddjyTestFlagStr = text;
							string _nyTestFlagStr = text;
							if (this.checkBox_isGroundFlag.Checked)
							{
								_isGroundFlagStr = "是";
							}
							if (this.checkBox_dtTestFlag.Checked)
							{
								_dtTestFlagStr = "是";
							}
							if (this.checkBox_dlTestFlag.Checked)
							{
								_dlTestFlagStr = "是";
							}
							if (this.checkBox_jyTestFlag.Checked)
							{
								_jyTestFlagStr = "是";
							}
							if (this.checkBox_ddjyTestFlag.Checked)
							{
								_ddjyTestFlagStr = "是";
							}
							if (this.checkBox_nyTestFlag.Checked)
							{
								_nyTestFlagStr = "是";
							}
							if (iACount + istpIndex > this.comboBox_startPin.Items.Count)
							{
								MessageBox.Show("始端接口接点后续个数小于" + System.Convert.ToString(iACount) + " !", "提示", MessageBoxButtons.OK);
							}
							else
							{
								bool bOnlyOneFlag = false;
								if (this.comboBox_stopPin.Items.Count == 1)
								{
									bOnlyOneFlag = true;
								}
								else if (iACount + isppIndex > this.comboBox_stopPin.Items.Count)
								{
									MessageBox.Show("末端接口接点后续个数小于" + System.Convert.ToString(iACount) + " !", "提示", MessageBoxButtons.OK);
									return;
								}
								iRows = this.dataGridView1.Rows.Count;
								this.dataGridView1.AllowUserToAddRows = true;
								for (int j = 0; j < iACount; j++)
								{
									int num;
									if (j == 0)
									{
										this.dataGridView1.Rows.Add(1);
										num = iRows + 1;
										int num2 = num;
										this.dataGridView1.Rows[iRows].Cells[0].Value = num2.ToString();
										this.dataGridView1.Rows[iRows].Cells[1].Value = _startIFBH;
										this.dataGridView1.Rows[iRows].Cells[2].Value = _startPin;
										this.dataGridView1.Rows[iRows].Cells[3].Value = _stopIFBH;
										this.dataGridView1.Rows[iRows].Cells[4].Value = _stopPin;
										this.dataGridView1.Rows[iRows].Cells[5].Value = _isGroundFlagStr;
										this.dataGridView1.Rows[iRows].Cells[6].Value = _dtTestFlagStr;
										this.dataGridView1.Rows[iRows].Cells[7].Value = _dlTestFlagStr;
										this.dataGridView1.Rows[iRows].Cells[8].Value = _jyTestFlagStr;
										this.dataGridView1.Rows[iRows].Cells[9].Value = _ddjyTestFlagStr;
										this.dataGridView1.Rows[iRows].Cells[10].Value = _nyTestFlagStr;
									}
									else
									{
										istpIndex++;
										_startPin = this.comboBox_startPin.Items[istpIndex].ToString();
										if (bOnlyOneFlag)
										{
											_stopPin = this.comboBox_stopPin.Items[0].ToString();
										}
										else
										{
											isppIndex++;
											_stopPin = this.comboBox_stopPin.Items[isppIndex].ToString();
										}
										for (int k = 0; k < iRows; k++)
										{
											string tempStr = this.dataGridView1.Rows[k].Cells[1].Value.ToString();
											string tempStr2 = this.dataGridView1.Rows[k].Cells[2].Value.ToString();
											string tempStr3 = this.dataGridView1.Rows[k].Cells[3].Value.ToString();
											string tempStr4 = this.dataGridView1.Rows[k].Cells[4].Value.ToString();
											if ((tempStr == _startIFBH && tempStr2 == _startPin && tempStr3 == _stopIFBH && tempStr4 == _stopPin) || (tempStr3 == _startIFBH && tempStr4 == _startPin && tempStr == _stopIFBH && tempStr2 == _stopPin))
											{
											}
										}
										this.dataGridView1.Rows.Add(1);
										num = iRows + 1;
										int num3 = num;
										this.dataGridView1.Rows[iRows].Cells[0].Value = num3.ToString();
										this.dataGridView1.Rows[iRows].Cells[1].Value = _startIFBH;
										this.dataGridView1.Rows[iRows].Cells[2].Value = _startPin;
										this.dataGridView1.Rows[iRows].Cells[3].Value = _stopIFBH;
										this.dataGridView1.Rows[iRows].Cells[4].Value = _stopPin;
										this.dataGridView1.Rows[iRows].Cells[5].Value = _isGroundFlagStr;
										this.dataGridView1.Rows[iRows].Cells[6].Value = _dtTestFlagStr;
										this.dataGridView1.Rows[iRows].Cells[7].Value = _dlTestFlagStr;
										this.dataGridView1.Rows[iRows].Cells[8].Value = _jyTestFlagStr;
										this.dataGridView1.Rows[iRows].Cells[9].Value = _ddjyTestFlagStr;
										this.dataGridView1.Rows[iRows].Cells[10].Value = _nyTestFlagStr;
									}
									iRows = num;
								}
								this.dataGridView1.AllowUserToAddRows = false;
								int iLastIndex = this.dataGridView1.Rows.Count - 1;
								if (iLastIndex >= 0)
								{
									this.dataGridView1.Rows[iLastIndex].Selected = true;
								}
							}
						}
					}
					else
					{
						MessageBox.Show("未选择匹配的起点或终点接点!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_935_0)
			{
				this.dataGridView1.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_935_0.StackTrace);
			}
		}
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0)
				{
					this.dataGridView1.Rows.Remove(this.dataGridView1.SelectedRows[0]);
					int sender2;
					for (int i = 0; i < this.dataGridView1.Rows.Count; i = sender2)
					{
						sender2 = i + 1;
						this.dataGridView1.Rows[i].Cells[0].Value = System.Convert.ToString(sender2);
					}
				}
			}
			catch (System.Exception arg_7C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_7C_0.StackTrace);
			}
		}
		private void btnDelAll_Click(object sender, System.EventArgs e)
		{
			this.dataGridView1.Rows.Clear();
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool JKJDExistFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			bool bRFlag = true;
			try
			{
				System.Collections.Generic.List<string> JKStringArray = new System.Collections.Generic.List<string>();
				System.Collections.Generic.List<string> JDStringArray = new System.Collections.Generic.List<string>();
				int i = 0;
				IL_19:
				while (i < this.pinRelationStructList.Count)
				{
					bool bExistFlag = false;
					string temp1Str = this.pinRelationStructList[i].firstStr;
					int j = 0;
					while (j < JKStringArray.Count)
					{
						if (JKStringArray[j] == temp1Str)
						{
							IL_7C:
							bExistFlag = false;
							string temp2Str = this.pinRelationStructList[i].thirdStr;
							for (int k = 0; k < JKStringArray.Count; k++)
							{
								if (JKStringArray[k] == temp2Str)
								{
									IL_CD:
									i++;
									goto IL_19;
								}
							}
							if (!bExistFlag)
							{
								System.Collections.Generic.List<string> expr_C0 = JKStringArray;
								expr_C0.Insert(expr_C0.Count, temp2Str);
								goto IL_CD;
							}
							goto IL_CD;
						}
						else
						{
							j++;
						}
					}
					if (!bExistFlag)
					{
						System.Collections.Generic.List<string> expr_6F = JKStringArray;
						expr_6F.Insert(expr_6F.Count, temp1Str);
						goto IL_7C;
					}
					goto IL_7C;
				}
				string text = "1";
				string pidStr = text;
				bool bExcFlag = false;
				string excStr = "接口或接点不存在!";
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					for (int l = 0; l < JKStringArray.Count; l++)
					{
						JDStringArray.Clear();
						bool bExistFlag;
						for (int m = 0; m < this.pinRelationStructList.Count; m++)
						{
							string temp1Str = this.pinRelationStructList[m].firstStr;
							if (temp1Str == JKStringArray[l])
							{
								bExistFlag = false;
								string temp3Str = this.pinRelationStructList[m].secondStr;
								for (int n = 0; n < JDStringArray.Count; n++)
								{
									if (JDStringArray[n] == temp3Str)
									{
										goto IL_1B2;
									}
								}
								if (!bExistFlag)
								{
									System.Collections.Generic.List<string> expr_1A5 = JDStringArray;
									expr_1A5.Insert(expr_1A5.Count, temp3Str);
								}
							}
							IL_1B2:
							string temp2Str = this.pinRelationStructList[m].thirdStr;
							if (temp2Str == JKStringArray[l])
							{
								bExistFlag = false;
								string temp4Str = this.pinRelationStructList[m].fourStr;
								for (int i2 = 0; i2 < JDStringArray.Count; i2++)
								{
									if (JDStringArray[i2] == temp4Str)
									{
										goto IL_228;
									}
								}
								if (!bExistFlag)
								{
									System.Collections.Generic.List<string> expr_21B = JDStringArray;
									expr_21B.Insert(expr_21B.Count, temp4Str);
								}
							}
							IL_228:;
						}
						bExistFlag = false;
						string sqlcommand = "select top 1 * from TPlugLibrary where PlugNo = '" + JKStringArray[l] + "'";
						OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						if (dataReader.Read())
						{
							pidStr = dataReader["PID"].ToString();
							bExistFlag = true;
						}
						dataReader.Close();
						dataReader = null;
						if (!bExistFlag)
						{
							bExcFlag = true;
							excStr = "接口 " + JKStringArray[l] + " 未添加或不存在!";
							break;
						}
						for (int k2 = 0; k2 < JDStringArray.Count; k2++)
						{
							bExistFlag = false;
							sqlcommand = "select top 1 * from TPlugLibraryDetail where PinName = '" + JDStringArray[k2] + "' and PID='" + pidStr + "'";
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							if (dataReader.Read())
							{
								bExistFlag = true;
							}
							dataReader.Close();
							dataReader = null;
							if (!bExistFlag)
							{
								bExcFlag = true;
								excStr = "接口 " + JKStringArray[l] + " 的接点 " + JDStringArray[k2] + " 未添加或不存在!";
								break;
							}
							if (bExcFlag)
							{
								break;
							}
						}
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_37A_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_37A_0.StackTrace);
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
				if (bExcFlag)
				{
					bRFlag = false;
					MessageBox.Show(excStr, "提示", MessageBoxButtons.OK);
				}
			}
			catch (System.Exception arg_3B6_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3B6_0.StackTrace);
			}
			return bRFlag;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool QueryCableIsExistFunc(string bhTempStr)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				bool bExsitFlag = false;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select top 1 * from TLineStructLibrary where LineStructName = '" + bhTempStr + "'", connection).ExecuteReader();
					if (dataReader.Read())
					{
						bExsitFlag = true;
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_60_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_60_0.StackTrace);
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
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
					MessageBox.Show("该线束已定义!", "提示", MessageBoxButtons.OK);
					return false;
				}
			}
			catch (System.Exception arg_A7_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_A7_0.StackTrace);
			}
			return true;
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool QueryCableAbnormal_AddFunc()
		{
			try
			{
				if (this.comboBox_startIFBH.Items.Count <= 0)
				{
					MessageBox.Show("未添加线束接口!", "提示", MessageBoxButtons.OK);
					byte result = 0;
					return result != 0;
				}
				string bhTempStr = this.textBox_cableNo.Text.ToString().Trim();
				if (string.IsNullOrEmpty(bhTempStr))
				{
					MessageBox.Show("线束代号为空!", "提示", MessageBoxButtons.OK);
					byte result = 0;
					return result != 0;
				}
				if (!this.QueryCableIsExistFunc(bhTempStr))
				{
					byte result = 0;
					return result != 0;
				}
				this.pinRelationStructList.Clear();
				for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
				{
					PinConnRelationStruct pinRelationStruct = new PinConnRelationStruct();
					pinRelationStruct.indexStr = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
					pinRelationStruct.firstStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
					pinRelationStruct.secondStr = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
					pinRelationStruct.thirdStr = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
					pinRelationStruct.fourStr = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
					pinRelationStruct.fiveStr = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
					if (this.dataGridView1.Rows[i].Cells[6].Value != null)
					{
						pinRelationStruct.sixthStr = this.dataGridView1.Rows[i].Cells[6].Value.ToString();
					}
					if (this.dataGridView1.Rows[i].Cells[7].Value != null)
					{
						pinRelationStruct.seventhStr = this.dataGridView1.Rows[i].Cells[7].Value.ToString();
					}
					if (this.dataGridView1.Rows[i].Cells[8].Value != null)
					{
						pinRelationStruct.eightStr = this.dataGridView1.Rows[i].Cells[8].Value.ToString();
					}
					if (this.dataGridView1.Rows[i].Cells[9].Value != null)
					{
						pinRelationStruct.nineStr = this.dataGridView1.Rows[i].Cells[9].Value.ToString();
					}
					if (this.dataGridView1.Rows[i].Cells[10].Value != null)
					{
						pinRelationStruct.tenStr = this.dataGridView1.Rows[i].Cells[10].Value.ToString();
					}
					this.pinRelationStructList.Add(pinRelationStruct);
				}
				if (!this.JKJDExistFunc())
				{
					byte result = 0;
					return result != 0;
				}
				int j = 0;
				IL_364:
				while (j < this.pinRelationStructList.Count)
				{
					bool bStartPlugExistFlag = false;
					bool bStopPlugExistFlag = false;
					if (this.pinRelationStructList[j].firstStr == this.pinRelationStructList[j].thirdStr && this.pinRelationStructList[j].secondStr == this.pinRelationStructList[j].fourStr)
					{
						MessageBox.Show("第" + System.Convert.ToString(j + 1) + "行起点和终点的接口接点相同!", "提示", MessageBoxButtons.OK);
						byte result = 0;
						return result != 0;
					}
					int k = 0;
					while (k < this.comboBox_startIFBH.Items.Count)
					{
						if (this.pinRelationStructList[j].firstStr == this.comboBox_startIFBH.Items[k].ToString())
						{
							bStartPlugExistFlag = true;
						}
						if (this.pinRelationStructList[j].thirdStr == this.comboBox_startIFBH.Items[k].ToString())
						{
							bStopPlugExistFlag = true;
							goto IL_481;
						}
						if (bStopPlugExistFlag)
						{
							goto IL_481;
						}
						IL_485:
						k++;
						continue;
						IL_481:
						if (!bStartPlugExistFlag)
						{
							goto IL_485;
						}
						IL_494:
						if (bStopPlugExistFlag)
						{
							j++;
							goto IL_364;
						}
						IL_4A1:
						MessageBox.Show("第" + System.Convert.ToString(j + 1) + "行接口未添加到线束!", "提示", MessageBoxButtons.OK);
						byte result = 0;
						return result != 0;
					}
					if (bStartPlugExistFlag)
					{
						goto IL_494;
					}
					goto IL_4A1;
				}
				bool bISJDJYFlag = false;
				int iFailRows = 0;
				for (int l = 0; l < this.pinRelationStructList.Count; l++)
				{
					if (this.pinRelationStructList[l].fiveStr == "是" && (this.pinRelationStructList[l].eightStr == "是" || this.pinRelationStructList[l].nineStr == "是" || this.pinRelationStructList[l].tenStr == "是"))
					{
						iFailRows = l + 1;
						IL_590:
						MessageBox.Show("第" + System.Convert.ToString(iFailRows) + "行存在异常（接地时不能进行绝缘和耐压测试）!", "提示", MessageBoxButtons.OK);
						byte result = 0;
						return result != 0;
					}
				}
				if (bISJDJYFlag)
				{
					goto IL_590;
				}
			}
			catch (System.Exception arg_5BE_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5BE_0.StackTrace);
			}
			return true;
		}
		public void OneToMultiRelaDisposeFunc()
		{
			System.Collections.Generic.List<PinConnRelationStruct> list = this.pinRelationStructList;
			if (list != null && list.Count > 1)
			{
				try
				{
					System.Collections.Generic.List<JYNYTestStruct> vecArray2 = new System.Collections.Generic.List<JYNYTestStruct>();
					for (int i = 0; i < this.pinRelationStructList.Count; i++)
					{
						JYNYTestStruct vecTemp2 = new JYNYTestStruct();
						if (vecArray2.Count <= 0)
						{
							vecTemp2.mPinName = this.pinRelationStructList[i].thirdStr;
							vecTemp2.mPinNumber = this.pinRelationStructList[i].fourStr;
							vecArray2.Add(vecTemp2);
						}
						else
						{
							bool bExistFlag = false;
							for (int j = 0; j < vecArray2.Count; j++)
							{
								if (this.pinRelationStructList[i].thirdStr == vecArray2[j].mPinName && this.pinRelationStructList[i].fourStr == vecArray2[j].mPinNumber)
								{
									goto IL_14C;
								}
							}
							if (!bExistFlag)
							{
								vecTemp2.mPinName = this.pinRelationStructList[i].thirdStr;
								vecTemp2.mPinNumber = this.pinRelationStructList[i].fourStr;
								vecArray2.Add(vecTemp2);
							}
						}
						IL_14C:;
					}
					for (int j2 = 0; j2 < vecArray2.Count; j2++)
					{
						string temp1Str = vecArray2[j2].mPinName;
						string temp2Str = vecArray2[j2].mPinNumber;
						int iNumCount = 0;
						for (int i2 = 0; i2 < this.pinRelationStructList.Count; i2++)
						{
							string temp3Str = this.pinRelationStructList[i2].thirdStr;
							string temp4Str = this.pinRelationStructList[i2].fourStr;
							if (temp1Str == temp3Str && temp2Str == temp4Str)
							{
								iNumCount++;
							}
						}
						if (iNumCount > 1)
						{
							for (int i3 = 0; i3 < this.pinRelationStructList.Count; i3++)
							{
								string temp3Str = this.pinRelationStructList[i3].thirdStr;
								string temp4Str = this.pinRelationStructList[i3].fourStr;
								if (temp1Str == temp3Str && temp2Str == temp4Str)
								{
									string temp5Str = this.pinRelationStructList[i3].firstStr;
									string temp6Str = this.pinRelationStructList[i3].secondStr;
									iNumCount--;
									this.pinRelationStructList[i3].firstStr = temp3Str;
									this.pinRelationStructList[i3].secondStr = temp4Str;
									this.pinRelationStructList[i3].thirdStr = temp5Str;
									this.pinRelationStructList[i3].fourStr = temp6Str;
									if (iNumCount == 0)
									{
										break;
									}
								}
							}
						}
					}
					vecArray2.Clear();
					System.GC.Collect();
					System.GC.WaitForPendingFinalizers();
				}
				catch (System.Exception arg_2E3_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_2E3_0.StackTrace);
				}
			}
		}
		public void CloseFormDisposeFunc()
		{
			try
			{
				this.startPinMeasMethodList.Clear();
				this.stopPinMeasMethodList.Clear();
				this.stopPinStrList.Clear();
				this.startPinMeasMethodList = null;
				this.stopPinMeasMethodList = null;
				this.stopPinStrList = null;
			}
			catch (System.Exception arg_38_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_38_0.StackTrace);
			}
			base.Close();
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				if (!this.QueryCableAbnormal_AddFunc())
				{
					return;
				}
				this.OneToMultiRelaDisposeFunc();
				string bhTempStr = this.textBox_cableNo.Text.ToString().Trim();
				string remarkStr = this.textBox_Remark.Text.ToString();
				string text = "";
				string plugInfoStr = text;
				System.Collections.Generic.List<string> plugInfoList = new System.Collections.Generic.List<string>();
				for (int i = 0; i < this.comboBox_startIFBH.Items.Count; i++)
				{
					string tempStr = this.comboBox_startIFBH.Items[i].ToString();
					plugInfoList.Add(tempStr);
					if (i == 0)
					{
						plugInfoStr += tempStr;
					}
					else
					{
						plugInfoStr += "," + tempStr;
					}
				}
				bool bExsitFlag = false;
				string pidStr = "";
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "select top 1 * from TLineStructLibrary where LineStructName = '" + bhTempStr + "'";
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						string tempStr = dataReader["LineStructName"].ToString();
						bExsitFlag = true;
					}
					dataReader.Close();
					dataReader = null;
					if (bExsitFlag)
					{
						connection.Close();
						connection = null;
						MessageBox.Show("线束已存在!", "提示", MessageBoxButtons.OK);
						return;
					}
					sqlcommand = "insert into TLineStructLibrary(LineStructName,PlugInfo,LinePinNum,Remark) values('" + bhTempStr + "','" + plugInfoStr + "'," + this.pinRelationStructList.Count + ",'" + remarkStr + "')";
					cmd = new OleDbCommand(sqlcommand, connection);
					cmd.ExecuteNonQuery();
					System.Threading.Thread.Sleep(50);
					sqlcommand = "select * from TLineStructLibrary where LineStructName = '" + bhTempStr + "'";
					cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						pidStr = dataReader["LID"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					System.Threading.Thread.Sleep(50);
					try
					{
						if (!string.IsNullOrEmpty(pidStr))
						{
							for (int j = 0; j < this.plugIDList.Count; j++)
							{
								sqlcommand = "insert into TLineStructJKID(LID,JKID) values('" + pidStr + "','" + this.plugIDList[j] + "')";
								cmd = new OleDbCommand(sqlcommand, connection);
								cmd.ExecuteNonQuery();
							}
						}
					}
					catch (System.Exception arg_27D_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_27D_0.StackTrace);
					}
					System.Threading.Thread.Sleep(50);
					try
					{
						for (int k = 0; k < this.pinRelationStructList.Count; k++)
						{
							int iIsGround = 0;
							int iIsTestDT = 0;
							int iIsTestDL = 0;
							int iIsTestJY = 0;
							int iIsTestDDJY = 0;
							int iIsTestNY = 0;
							if (this.pinRelationStructList[k].fiveStr == "是")
							{
								iIsGround = 1;
							}
							if (this.pinRelationStructList[k].sixthStr == "是")
							{
								iIsTestDT = 1;
							}
							if (this.pinRelationStructList[k].seventhStr == "是")
							{
								iIsTestDL = 1;
							}
							if (this.pinRelationStructList[k].eightStr == "是")
							{
								iIsTestJY = 1;
							}
							if (this.pinRelationStructList[k].nineStr == "是")
							{
								iIsTestDDJY = 1;
							}
							if (this.pinRelationStructList[k].tenStr == "是")
							{
								iIsTestNY = 1;
							}
							string str = ",";
							sqlcommand = "insert into TLineStructLibraryDetail(LID,PlugName1,PinName1,PlugName2,PinName2,IsGround,IsTestDT,IsTestDL,IsTestJY,IsTestDDJY,IsTestNY) values('" + pidStr + "','" + this.pinRelationStructList[k].firstStr + "','" + this.pinRelationStructList[k].secondStr + "','" + this.pinRelationStructList[k].thirdStr + "','" + this.pinRelationStructList[k].fourStr + "'," + iIsGround + str + iIsTestDT + str + iIsTestDL + str + iIsTestJY + str + iIsTestDDJY + str + iIsTestNY + ")";
							cmd = new OleDbCommand(sqlcommand, connection);
							cmd.ExecuteNonQuery();
						}
					}
					catch (System.Exception arg_4B6_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_4B6_0.StackTrace);
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_4CC_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_4CC_0.StackTrace);
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
					MessageBox.Show("数据库访问异常!", "提示", MessageBoxButtons.OK);
					this.CloseFormDisposeFunc();
					goto IL_507;
				}
				goto IL_52C;
				IL_507:
				return;
			}
			catch (System.Exception arg_509_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_509_0.StackTrace);
				MessageBox.Show("存在未知异常!", "提示", MessageBoxButtons.OK);
				this.CloseFormDisposeFunc();
				return;
			}
			IL_52C:
			MessageBox.Show("操作成功!", "提示", MessageBoxButtons.OK);
			this.bAddSuccFlag = true;
			this.CloseFormDisposeFunc();
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
		public void SymbolSubstitutionDisposeFunc()
		{
			try
			{
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				if (kLineTestProcessor.gPinConnRelaInfoArray != null)
				{
					if (kLineTestProcessor.gPinConnRelaInfoArray.Count > 0)
					{
						for (int i = 0; i < this.gLineTestProcessor.gPinConnRelaInfoArray.Count; i++)
						{
							string temp1Str = this.gLineTestProcessor.gPinConnRelaInfoArray[i].secondStr;
							string temp2Str = this.gLineTestProcessor.gPinConnRelaInfoArray[i].fourStr;
							if (temp1Str.Length == 2)
							{
								string temp3Str = temp1Str.Substring(0, 1);
								string temp4Str = temp1Str.Substring(1, 1);
								if (temp4Str == "-")
								{
									int j = 0;
									while (true)
									{
										string[] strAZArray = this.gLineTestProcessor.strAZArray;
										if (j >= strAZArray.Length)
										{
											break;
										}
										if (strAZArray[j] == temp3Str)
										{
											this.gLineTestProcessor.gPinConnRelaInfoArray[i].secondStr = temp3Str.ToLower();
										}
										j++;
									}
								}
							}
							if (temp2Str.Length == 2)
							{
								string temp3Str = temp2Str.Substring(0, 1);
								string temp4Str = temp2Str.Substring(1, 1);
								if (temp4Str == "-")
								{
									int k = 0;
									while (true)
									{
										string[] strAZArray2 = this.gLineTestProcessor.strAZArray;
										if (k >= strAZArray2.Length)
										{
											break;
										}
										if (strAZArray2[k] == temp3Str)
										{
											this.gLineTestProcessor.gPinConnRelaInfoArray[i].fourStr = temp3Str.ToLower();
										}
										k++;
									}
								}
							}
						}
						int num;
						for (int kk = 0; kk < this.gLineTestProcessor.gPinConnRelaInfoArray.Count; kk = num)
						{
							num = kk + 1;
							this.gLineTestProcessor.gPinConnRelaInfoArray[kk].indexStr = System.Convert.ToString(num);
						}
					}
				}
			}
			catch (System.Exception arg_1C0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1C0_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool AsposeCellsReadConfigFileFunc(string file, string fkzm)
		{
			Workbook wk = null;
			string firstStr = null;
			string secondStr = null;
			string thirdStr = null;
			string fourStr = null;
			bool bSuccFlag = true;
			this.dataGridView1.Rows.Clear();
			this.gLineTestProcessor.gPinConnRelaInfoArray.Clear();
			try
			{
				int iRowIndex = 0;
				int iRow = 1;
				if (!(fkzm == "XLS") && !(fkzm == "XLSX") && !(fkzm == "CSV"))
				{
					if (fkzm == "DOCX" || fkzm == "DOC")
					{
						Document doc = new Document(file);
						try
						{
							Body oleBody = ((Section)doc.ChildNodes[0]).Body;
							int iTableMode = 0;
							for (int i = 0; i < oleBody.ChildNodes.Count; i++)
							{
								try
								{
									Table tempTable = (Table)oleBody.ChildNodes[i];
									if (tempTable.Rows.Count <= 1)
									{
										break;
									}
									int j = 1;
									while (j < tempTable.Rows.Count)
									{
										try
										{
											Aspose.Words.Tables.Row tempRow = tempTable.Rows[j];
											int iCellCount = tempRow.Cells.Count;
											if (iCellCount < 5)
											{
												goto IL_4AB;
											}
											if (iTableMode == 0)
											{
												string pin1Str = tempRow.Cells[2].Range.Text.ToString();
												pin1Str = pin1Str.Trim();
												string[] tempStrArray = pin1Str.Split(new char[]
												{
													':'
												});
												if (tempStrArray.Length != 2)
												{
													iTableMode = 1;
												}
												else
												{
													string pin2Str = tempRow.Cells[3].Range.Text.ToString();
													pin2Str = pin2Str.Trim();
													string[] tempStrArray2 = pin2Str.Split(new char[]
													{
														':'
													});
													if (tempStrArray2.Length == 2)
													{
														firstStr = tempStrArray[0].ToString().Trim();
														secondStr = tempStrArray[1].ToString().Trim();
														secondStr = secondStr.Substring(0, secondStr.Length - 1);
														thirdStr = tempStrArray2[0].ToString().Trim();
														fourStr = tempStrArray2[1].ToString().Trim();
														fourStr = fourStr.Substring(0, fourStr.Length - 1);
														goto IL_3E9;
													}
													iTableMode = 1;
												}
												firstStr = tempRow.Cells[1].Range.Text.ToString();
												secondStr = tempRow.Cells[2].Range.Text.ToString();
												thirdStr = tempRow.Cells[3].Range.Text.ToString();
												fourStr = tempRow.Cells[4].Range.Text.ToString();
												firstStr = firstStr.Substring(0, firstStr.Length - 1);
												secondStr = secondStr.Substring(0, secondStr.Length - 1);
												thirdStr = thirdStr.Substring(0, thirdStr.Length - 1);
												fourStr = fourStr.Substring(0, fourStr.Length - 1);
											}
											else if (iTableMode == 1)
											{
												firstStr = tempRow.Cells[1].Range.Text.ToString();
												secondStr = tempRow.Cells[2].Range.Text.ToString();
												thirdStr = tempRow.Cells[3].Range.Text.ToString();
												fourStr = tempRow.Cells[4].Range.Text.ToString();
												firstStr = firstStr.Substring(0, firstStr.Length - 1);
												secondStr = secondStr.Substring(0, secondStr.Length - 1);
												thirdStr = thirdStr.Substring(0, thirdStr.Length - 1);
												fourStr = fourStr.Substring(0, fourStr.Length - 1);
											}
											IL_3E9:;
										}
										catch (System.Exception rex_3EB)
										{
											goto IL_4AB;
										}
										goto IL_3F5;
										IL_4AB:
										j++;
										continue;
										IL_3F5:
										firstStr = firstStr.Trim();
										secondStr = secondStr.Trim();
										thirdStr = thirdStr.Trim();
										fourStr = fourStr.Trim();
										PinConnRelationStruct pinConnRelaStruct = new PinConnRelationStruct();
										int num = iRowIndex + 1;
										pinConnRelaStruct.indexStr = System.Convert.ToString(num);
										pinConnRelaStruct.firstStr = firstStr;
										pinConnRelaStruct.secondStr = secondStr;
										pinConnRelaStruct.thirdStr = thirdStr;
										pinConnRelaStruct.fourStr = fourStr;
										pinConnRelaStruct.fiveStr = "否";
										pinConnRelaStruct.sixthStr = "是";
										pinConnRelaStruct.seventhStr = "是";
										pinConnRelaStruct.eightStr = "是";
										pinConnRelaStruct.nineStr = "是";
										pinConnRelaStruct.tenStr = "是";
										this.gLineTestProcessor.gPinConnRelaInfoArray.Add(pinConnRelaStruct);
										iRowIndex = num;
										goto IL_4AB;
									}
								}
								catch (System.Exception wex_4B8)
								{
								}
							}
						}
						catch (System.Exception ex_4CC)
						{
							bSuccFlag = false;
							this.dataGridView1.Rows.Clear();
						}
					}
				}
				else
				{
					if (!(fkzm == "XLS") && !(fkzm == "XLSX"))
					{
						if (fkzm == "CSV")
						{
							wk = new Workbook(file, new TxtLoadOptions(Aspose.Cells.LoadFormat.CSV)
							{
								Encoding = System.Text.Encoding.Default
							});
							wk.FileFormat = FileFormatType.CSV;
						}
					}
					else
					{
						wk = new Workbook(file);
					}
					Worksheet sht = wk.Worksheets[0];
					Cells cells = sht.Cells;
					if (sht == null)
					{
						byte result = 0;
						return result != 0;
					}
					if (cells.MaxDataRow + 1 == 0)
					{
						byte result = 0;
						return result != 0;
					}
					int cellCount = cells.MaxDataColumn + 1;
					try
					{
						while (cells[iRow, 0].Value != null)
						{
							if (cells[iRow, 1].Value != null && cells[iRow, 2].Value != null && cells[iRow, 3].Value != null && cells[iRow, 4].Value != null)
							{
								string fiveStr = "否";
								string text = "是";
								string sixthStr = text;
								string seventhStr = text;
								string eightStr = text;
								string nineStr = text;
								string tenStr = text;
								firstStr = cells[iRow, 1].Value.ToString();
								secondStr = cells[iRow, 2].Value.ToString();
								thirdStr = cells[iRow, 3].Value.ToString();
								fourStr = cells[iRow, 4].Value.ToString();
								if (cells[iRow, 5].Value != null)
								{
									fiveStr = cells[iRow, 5].Value.ToString();
								}
								if (cells[iRow, 7].Value != null)
								{
									seventhStr = cells[iRow, 7].Value.ToString();
								}
								if (cells[iRow, 8].Value != null)
								{
									eightStr = cells[iRow, 8].Value.ToString();
								}
								if (cells[iRow, 9].Value != null)
								{
									nineStr = cells[iRow, 9].Value.ToString();
								}
								if (cells[iRow, 10].Value != null)
								{
									tenStr = cells[iRow, 10].Value.ToString();
								}
								try
								{
									if (fiveStr == "1" || fiveStr == "是")
									{
										fiveStr = "是";
									}
								}
								catch (System.Exception ex_735)
								{
								}
								try
								{
									if (seventhStr != "1" && seventhStr != "是")
									{
										seventhStr = "否";
									}
								}
								catch (System.Exception ex_762)
								{
								}
								try
								{
									if (eightStr != "1" && eightStr != "是")
									{
										eightStr = "否";
									}
								}
								catch (System.Exception ex_78F)
								{
								}
								try
								{
									if (nineStr != "1" && nineStr != "是")
									{
										nineStr = "否";
									}
								}
								catch (System.Exception ex_7BC)
								{
								}
								try
								{
									if (tenStr != "1" && tenStr != "是")
									{
										tenStr = "否";
									}
								}
								catch (System.Exception ex_7E9)
								{
								}
								PinConnRelationStruct pinConnRelaStruct = new PinConnRelationStruct();
								int num2 = iRowIndex + 1;
								pinConnRelaStruct.indexStr = System.Convert.ToString(num2);
								pinConnRelaStruct.firstStr = firstStr;
								pinConnRelaStruct.secondStr = secondStr;
								pinConnRelaStruct.thirdStr = thirdStr;
								pinConnRelaStruct.fourStr = fourStr;
								pinConnRelaStruct.fiveStr = fiveStr;
								pinConnRelaStruct.sixthStr = sixthStr;
								pinConnRelaStruct.seventhStr = seventhStr;
								pinConnRelaStruct.eightStr = eightStr;
								pinConnRelaStruct.nineStr = nineStr;
								pinConnRelaStruct.tenStr = tenStr;
								this.gLineTestProcessor.gPinConnRelaInfoArray.Add(pinConnRelaStruct);
								iRow++;
								iRowIndex = num2;
							}
							else
							{
								iRow++;
							}
						}
					}
					catch (System.Exception arg_882_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_882_0.StackTrace);
						bSuccFlag = false;
					}
				}
				try
				{
					if (bSuccFlag)
					{
						this.PinRelaRepetitionFilterFunc();
						this.dataGridView1.AllowUserToAddRows = true;
						for (int mn = 0; mn < this.gLineTestProcessor.gPinConnRelaInfoArray.Count; mn++)
						{
							this.dataGridView1.Rows.Add(1);
							this.dataGridView1.Rows[mn].Cells[0].Value = this.gLineTestProcessor.gPinConnRelaInfoArray[mn].indexStr;
							this.dataGridView1.Rows[mn].Cells[1].Value = this.gLineTestProcessor.gPinConnRelaInfoArray[mn].firstStr;
							this.dataGridView1.Rows[mn].Cells[2].Value = this.gLineTestProcessor.gPinConnRelaInfoArray[mn].secondStr;
							this.dataGridView1.Rows[mn].Cells[3].Value = this.gLineTestProcessor.gPinConnRelaInfoArray[mn].thirdStr;
							this.dataGridView1.Rows[mn].Cells[4].Value = this.gLineTestProcessor.gPinConnRelaInfoArray[mn].fourStr;
							this.dataGridView1.Rows[mn].Cells[5].Value = this.gLineTestProcessor.gPinConnRelaInfoArray[mn].fiveStr;
							this.dataGridView1.Rows[mn].Cells[6].Value = this.gLineTestProcessor.gPinConnRelaInfoArray[mn].sixthStr;
							this.dataGridView1.Rows[mn].Cells[7].Value = this.gLineTestProcessor.gPinConnRelaInfoArray[mn].seventhStr;
							this.dataGridView1.Rows[mn].Cells[8].Value = this.gLineTestProcessor.gPinConnRelaInfoArray[mn].eightStr;
							this.dataGridView1.Rows[mn].Cells[9].Value = this.gLineTestProcessor.gPinConnRelaInfoArray[mn].nineStr;
							this.dataGridView1.Rows[mn].Cells[10].Value = this.gLineTestProcessor.gPinConnRelaInfoArray[mn].tenStr;
						}
						this.dataGridView1.AllowUserToAddRows = false;
					}
				}
				catch (System.Exception ex_B51)
				{
					bSuccFlag = false;
					this.dataGridView1.AllowUserToAddRows = false;
					this.dataGridView1.Rows.Clear();
				}
				if (this.dataGridView1.Rows.Count > 0)
				{
					this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Selected = true;
				}
			}
			catch (System.Exception arg_BB4_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_BB4_0.StackTrace);
			}
			this.gLineTestProcessor.gPinConnRelaInfoArray.Clear();
			System.GC.Collect();
			System.GC.WaitForPendingFinalizers();
			return bSuccFlag;
		}
		public void PinRelaRepetitionFilterFunc()
		{
			try
			{
				if (this.gLineTestProcessor.gPinConnRelaInfoArray != null)
				{
					for (int i = 0; i < this.gLineTestProcessor.gPinConnRelaInfoArray.Count; i++)
					{
						string temp1Str = this.gLineTestProcessor.gPinConnRelaInfoArray[i].firstStr;
						string temp2Str = this.gLineTestProcessor.gPinConnRelaInfoArray[i].secondStr;
						string temp3Str = this.gLineTestProcessor.gPinConnRelaInfoArray[i].thirdStr;
						string temp4Str = this.gLineTestProcessor.gPinConnRelaInfoArray[i].fourStr;
						int j = this.dataGridView1.Rows.Count - 1;
						while (j > 0 && i != j)
						{
							string temp5Str = this.gLineTestProcessor.gPinConnRelaInfoArray[j].firstStr;
							string temp6Str = this.gLineTestProcessor.gPinConnRelaInfoArray[j].secondStr;
							string temp7Str = this.gLineTestProcessor.gPinConnRelaInfoArray[j].thirdStr;
							string temp8Str = this.gLineTestProcessor.gPinConnRelaInfoArray[j].fourStr;
							if ((temp1Str == temp5Str && temp2Str == temp6Str && temp3Str == temp7Str && temp4Str == temp8Str) || (temp1Str == temp7Str && temp2Str == temp8Str && temp3Str == temp5Str && temp4Str == temp6Str))
							{
								this.dataGridView1.Rows.RemoveAt(j);
							}
							j--;
						}
					}
				}
			}
			catch (System.Exception arg_1A2_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1A2_0.StackTrace);
			}
		}
		private void btnFileImport_Click(object sender, System.EventArgs e)
		{
			try
			{
				OpenFileDialog sender2 = new OpenFileDialog();
				this.openFileDialog1 = sender2;
				sender2.Filter = "连接关系文件|*.xlsx;*.xls;*.csv;*.docx;*.doc";
				this.openFileDialog1.RestoreDirectory = true;
				this.openFileDialog1.FilterIndex = 1;
				if (DialogResult.OK == this.openFileDialog1.ShowDialog(this))
				{
					string readfn = this.openFileDialog1.FileName;
					string expr_4F = readfn;
					string expr_61 = expr_4F.Substring(expr_4F.LastIndexOf("\\") + 1);
					string fkzm = expr_61.Substring(expr_61.LastIndexOf(".") + 1).ToUpper();
					bool bSuccFlag = this.AsposeCellsReadConfigFileFunc(readfn, fkzm);
					if (bSuccFlag)
					{
						MessageBox.Show("导入成功，已过滤重复连接关系!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						this.dataGridView1.Rows.Clear();
						MessageBox.Show("导入失败，请确保文件格式及内容真实有效!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_BB_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_BB_0.StackTrace);
			}
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.CloseFormDisposeFunc();
			}
			catch (System.Exception arg_08_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_08_0.StackTrace);
			}
		}
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 972;
					int iy = 0;
					int ia = 0;
					if (iw > 0)
					{
						ia = iw / 2;
					}
					int iTWidth = 110;
					try
					{
						int iShowDefineColNum = this.gLineTestProcessor.iShowDefineColNum;
						iTWidth = 880 / iShowDefineColNum;
						iy = 880 - iShowDefineColNum * iTWidth;
					}
					catch (System.Exception ex_52)
					{
					}
					this.dataGridView1.Columns[0].Width = iy + 68;
					int width = ia + iTWidth;
					this.dataGridView1.Columns[1].Width = width;
					this.dataGridView1.Columns[2].Width = iTWidth;
					this.dataGridView1.Columns[3].Width = width;
					this.dataGridView1.Columns[4].Width = iTWidth;
					this.dataGridView1.Columns[5].Width = iTWidth;
					this.dataGridView1.Columns[6].Width = iTWidth;
					this.dataGridView1.Columns[7].Width = iTWidth;
					this.dataGridView1.Columns[8].Width = iTWidth;
					this.dataGridView1.Columns[9].Width = iTWidth;
					this.dataGridView1.Columns[10].Width = iTWidth;
				}
			}
			catch (System.Exception arg_162_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_162_0.StackTrace);
			}
		}
		private void ctFormAddCable_SizeChanged(object sender, System.EventArgs e)
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
		private void comboBox_startIFBH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				if (!string.IsNullOrEmpty(this.comboBox_startIFBH.Text.ToString().Trim()))
				{
					if (this.comboBox_startIFBH.SelectedIndex >= 0)
					{
						this.comboBox_startPin.Items.Clear();
						this.startPinStrList.Clear();
						this.startPinMeasMethodList.Clear();
						string pidStr = this.plugIDList[this.comboBox_startIFBH.SelectedIndex];
						try
						{
							connection = new OleDbConnection();
							connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
							connection.Open();
							dataReader = new OleDbCommand("select * from TPlugLibraryDetail where PID = '" + pidStr + "' order by PDID", connection).ExecuteReader();
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
						catch (System.Exception arg_126_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_126_0.StackTrace);
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
							if (this.radioButton_Pin_TwoWire.Checked)
							{
								if (this.startPinMeasMethodList[nn] == 0)
								{
									this.comboBox_startPin.Items.Add(this.startPinStrList[nn]);
								}
							}
							else if (this.startPinMeasMethodList[nn] != 0)
							{
								this.comboBox_startPin.Items.Add(this.startPinStrList[nn]);
							}
						}
						if (this.comboBox_startPin.Items.Count > 0)
						{
							this.comboBox_startPin.SelectedIndex = 0;
						}
					}
				}
			}
			catch (System.Exception arg_1E4_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1E4_0.StackTrace);
			}
		}
		private void comboBox_stopIFBH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				if (!string.IsNullOrEmpty(this.comboBox_stopIFBH.Text.ToString().Trim()))
				{
					if (this.comboBox_stopIFBH.SelectedIndex >= 0)
					{
						this.comboBox_stopPin.Items.Clear();
						this.stopPinStrList.Clear();
						this.stopPinMeasMethodList.Clear();
						string pidStr = this.plugIDList[this.comboBox_stopIFBH.SelectedIndex];
						try
						{
							connection = new OleDbConnection();
							connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
							connection.Open();
							dataReader = new OleDbCommand("select * from TPlugLibraryDetail where PID = '" + pidStr + "' order by PDID", connection).ExecuteReader();
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
						catch (System.Exception arg_126_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_126_0.StackTrace);
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
							if (this.radioButton_Pin_TwoWire.Checked)
							{
								if (this.stopPinMeasMethodList[nn] == 0)
								{
									this.comboBox_stopPin.Items.Add(this.stopPinStrList[nn]);
								}
							}
							else if (this.stopPinMeasMethodList[nn] != 0)
							{
								this.comboBox_stopPin.Items.Add(this.stopPinStrList[nn]);
							}
						}
						if (this.comboBox_stopPin.Items.Count > 0)
						{
							this.comboBox_stopPin.SelectedIndex = 0;
						}
					}
				}
			}
			catch (System.Exception arg_1E4_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1E4_0.StackTrace);
			}
		}
		private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0)
				{
					string _strStartIFBH = System.Convert.ToString(this.dataGridView1.SelectedRows[0].Cells[1].Value);
					string _strStartPin = System.Convert.ToString(this.dataGridView1.SelectedRows[0].Cells[2].Value);
					string _strStopIFBH = System.Convert.ToString(this.dataGridView1.SelectedRows[0].Cells[3].Value);
					string _strStopPin = System.Convert.ToString(this.dataGridView1.SelectedRows[0].Cells[4].Value);
					bool _bisGroundFlag = false;
					bool _bdlTestFlag = false;
					bool _bjyTestFlag = false;
					bool _bddjyTestFlag = false;
					bool _bnyTestFlag = false;
					string text = "";
					string cells5Str = text;
					string cells7Str = text;
					string cells8Str = text;
					string cells9Str = text;
					string cells10Str = text;
					if (this.dataGridView1.SelectedRows[0].Cells[5].Value != null)
					{
						cells5Str = this.dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
					}
					if (this.dataGridView1.SelectedRows[0].Cells[6].Value != null)
					{
						string cells6Str = this.dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
					}
					if (this.dataGridView1.SelectedRows[0].Cells[7].Value != null)
					{
						cells7Str = this.dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
					}
					if (this.dataGridView1.SelectedRows[0].Cells[8].Value != null)
					{
						cells8Str = this.dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
					}
					if (this.dataGridView1.SelectedRows[0].Cells[9].Value != null)
					{
						cells9Str = this.dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
					}
					if (this.dataGridView1.SelectedRows[0].Cells[10].Value != null)
					{
						cells10Str = this.dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
					}
					if (!string.IsNullOrEmpty(cells5Str) && cells5Str == "是")
					{
						_bisGroundFlag = true;
					}
					if (!string.IsNullOrEmpty(cells7Str) && cells7Str == "是")
					{
						_bdlTestFlag = true;
					}
					if (!string.IsNullOrEmpty(cells8Str) && cells8Str == "是")
					{
						_bjyTestFlag = true;
					}
					if (!string.IsNullOrEmpty(cells9Str) && cells9Str == "是")
					{
						_bddjyTestFlag = true;
					}
					if (!string.IsNullOrEmpty(cells10Str) && cells10Str == "是")
					{
						_bnyTestFlag = true;
					}
					int iCoreNum = this.comboBox_startIFBH.Items.Count;
					this.strCoreArray = new string[iCoreNum];
					for (int i = 0; i < iCoreNum; i++)
					{
						this.strCoreArray[i] = this.comboBox_startIFBH.Items[i].ToString();
					}
					int isRowIndex = System.Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value) - 1;
					ctFormEditCoreRelation ctFormEditCoreRelation = new ctFormEditCoreRelation(this.gLineTestProcessor, this.loginUser, this.strCoreArray, _strStartIFBH, _strStartPin, _strStopIFBH, _strStopPin, _bisGroundFlag, _bdlTestFlag, _bjyTestFlag, _bddjyTestFlag, _bnyTestFlag);
					this.editCoreRelationForm = ctFormEditCoreRelation;
					ctFormEditCoreRelation.Activate();
					this.editCoreRelationForm.ShowDialog();
					ctFormEditCoreRelation sender2 = this.editCoreRelationForm;
					if (sender2.bSuccFlag)
					{
						_strStartIFBH = sender2._strStartIFBH_s;
						_strStartPin = sender2._strStartPin_s;
						_strStopIFBH = sender2._strStopIFBH_s;
						_strStopPin = sender2._strStopPin_s;
						_bisGroundFlag = sender2.bIsGroundFlag_s;
						_bjyTestFlag = sender2.bJYTestFlag_s;
						_bddjyTestFlag = sender2.bDDJYTestFlag_s;
						_bdlTestFlag = sender2.bDLTestFlag_s;
						_bnyTestFlag = sender2.bNYTestFlag_s;
						int iRows = this.dataGridView1.Rows.Count;
						for (int j = 0; j < iRows; j++)
						{
							if (j != isRowIndex)
							{
								string tempStr = this.dataGridView1.Rows[j].Cells[1].Value.ToString();
								string tempStr2 = this.dataGridView1.Rows[j].Cells[2].Value.ToString();
								string tempStr3 = this.dataGridView1.Rows[j].Cells[3].Value.ToString();
								string tempStr4 = this.dataGridView1.Rows[j].Cells[4].Value.ToString();
								if ((tempStr == _strStartIFBH && tempStr2 == _strStartPin && tempStr3 == _strStopIFBH && tempStr4 == _strStopPin) || (tempStr3 == _strStartIFBH && tempStr4 == _strStartPin && tempStr == _strStopIFBH && tempStr2 == _strStopPin))
								{
									MessageBox.Show("该芯线定义已定义!", "提示", MessageBoxButtons.OK);
									return;
								}
							}
						}
						this.dataGridView1.Rows[isRowIndex].Cells[1].Value = _strStartIFBH;
						this.dataGridView1.Rows[isRowIndex].Cells[2].Value = _strStartPin;
						this.dataGridView1.Rows[isRowIndex].Cells[3].Value = _strStopIFBH;
						this.dataGridView1.Rows[isRowIndex].Cells[4].Value = _strStopPin;
						if (_bisGroundFlag)
						{
							this.dataGridView1.Rows[isRowIndex].Cells[5].Value = "是";
						}
						else
						{
							this.dataGridView1.Rows[isRowIndex].Cells[5].Value = "否";
						}
						this.dataGridView1.Rows[isRowIndex].Cells[6].Value = "是";
						if (_bdlTestFlag)
						{
							this.dataGridView1.Rows[isRowIndex].Cells[7].Value = "是";
						}
						else
						{
							this.dataGridView1.Rows[isRowIndex].Cells[7].Value = "否";
						}
						if (_bjyTestFlag)
						{
							this.dataGridView1.Rows[isRowIndex].Cells[8].Value = "是";
						}
						else
						{
							this.dataGridView1.Rows[isRowIndex].Cells[8].Value = "否";
						}
						if (_bddjyTestFlag)
						{
							this.dataGridView1.Rows[isRowIndex].Cells[9].Value = "是";
						}
						else
						{
							this.dataGridView1.Rows[isRowIndex].Cells[9].Value = "否";
						}
						if (_bnyTestFlag)
						{
							this.dataGridView1.Rows[isRowIndex].Cells[10].Value = "是";
						}
						else
						{
							this.dataGridView1.Rows[isRowIndex].Cells[10].Value = "否";
						}
					}
				}
			}
			catch (System.Exception arg_7D0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_7D0_0.StackTrace);
			}
		}
		private void btnCablePlugManage_Click(object sender, System.EventArgs e)
		{
			try
			{
				string bhTempStr = this.textBox_cableNo.Text.ToString().Trim();
				if (string.IsNullOrEmpty(bhTempStr))
				{
					MessageBox.Show("线束代号为空!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					ctFormCableInterfaceManage ctFormCableInterfaceManage = new ctFormCableInterfaceManage(this.gLineTestProcessor, this.loginUser, bhTempStr, this.plugIDList);
					this.cableInterfaceManageForm = ctFormCableInterfaceManage;
					ctFormCableInterfaceManage.Activate();
					this.cableInterfaceManageForm.ShowDialog();
					if (this.cableInterfaceManageForm.bSubmitFlag)
					{
						this.plugIDList.Clear();
						for (int i = 0; i < this.cableInterfaceManageForm.plugIDList.Count; i++)
						{
							this.plugIDList.Add(this.cableInterfaceManageForm.plugIDList[i]);
						}
						this.plugList.Clear();
						for (int j = 0; j < this.cableInterfaceManageForm.plugList.Count; j++)
						{
							this.plugList.Add(this.cableInterfaceManageForm.plugList[j]);
						}
						this.comboBox_startPin.Items.Clear();
						this.comboBox_stopPin.Items.Clear();
						this.comboBox_startIFBH.Items.Clear();
						this.comboBox_stopIFBH.Items.Clear();
						for (int k = 0; k < this.plugList.Count; k++)
						{
							this.comboBox_startIFBH.Items.Add(this.plugList[k]);
							this.comboBox_stopIFBH.Items.Add(this.plugList[k]);
						}
						if (this.comboBox_startIFBH.Items.Count > 0)
						{
							this.comboBox_startIFBH.SelectedIndex = 0;
						}
						if (this.comboBox_stopIFBH.Items.Count > 0)
						{
							this.comboBox_stopIFBH.SelectedIndex = 0;
						}
					}
				}
			}
			catch (System.Exception arg_1CF_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1CF_0.StackTrace);
			}
		}
		private void btnBatchEdit_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dataGridView1.Rows.Count <= 0)
				{
					MessageBox.Show("未定义线束芯线关系!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					int icount = this.comboBox_startIFBH.Items.Count;
					this.strCoreArray = new string[icount];
					int iIndex = 0;
					int i = 0;
					IL_5C:
					while (i < this.dataGridView1.Rows.Count)
					{
						bool bExistFlag = false;
						string tempStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
						int j = 0;
						while (j < icount)
						{
							if (tempStr == this.strCoreArray[j])
							{
								IL_DE:
								bExistFlag = false;
								string temp2Str = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
								for (int k = 0; k < icount; k++)
								{
									if (temp2Str == this.strCoreArray[k])
									{
										IL_149:
										i++;
										goto IL_5C;
									}
								}
								if (!bExistFlag && icount > iIndex)
								{
									this.strCoreArray[iIndex] = temp2Str;
									iIndex++;
									goto IL_149;
								}
								goto IL_149;
							}
							else
							{
								j++;
							}
						}
						if (!bExistFlag && icount > iIndex)
						{
							this.strCoreArray[iIndex] = tempStr;
							iIndex++;
							goto IL_DE;
						}
						goto IL_DE;
					}
					ctFormBatchEditCoreRelation ctFormBatchEditCoreRelation = new ctFormBatchEditCoreRelation(this.gLineTestProcessor, this.loginUser, this.strCoreArray);
					this.batchEditCoreRelationForm = ctFormBatchEditCoreRelation;
					ctFormBatchEditCoreRelation.Activate();
					this.batchEditCoreRelationForm.ShowDialog();
					ctFormBatchEditCoreRelation ctFormBatchEditCoreRelation2 = this.batchEditCoreRelationForm;
					if (ctFormBatchEditCoreRelation2.bSuccFlag)
					{
						if (ctFormBatchEditCoreRelation2.bUpdateAllPlugFlag)
						{
							for (int l = 0; l < this.dataGridView1.Rows.Count; l++)
							{
								if (this.batchEditCoreRelationForm.bIsGroundFlag_s)
								{
									this.dataGridView1.Rows[l].Cells[5].Value = "是";
								}
								else
								{
									this.dataGridView1.Rows[l].Cells[5].Value = "否";
								}
								if (this.batchEditCoreRelationForm.bDLTestFlag_s)
								{
									this.dataGridView1.Rows[l].Cells[7].Value = "是";
								}
								else
								{
									this.dataGridView1.Rows[l].Cells[7].Value = "否";
								}
								if (this.batchEditCoreRelationForm.bJYTestFlag_s)
								{
									this.dataGridView1.Rows[l].Cells[8].Value = "是";
								}
								else
								{
									this.dataGridView1.Rows[l].Cells[8].Value = "否";
								}
								if (this.batchEditCoreRelationForm.bDDJYTestFlag_s)
								{
									this.dataGridView1.Rows[l].Cells[9].Value = "是";
								}
								else
								{
									this.dataGridView1.Rows[l].Cells[9].Value = "否";
								}
								if (this.batchEditCoreRelationForm.bNYTestFlag_s)
								{
									this.dataGridView1.Rows[l].Cells[10].Value = "是";
								}
								else
								{
									this.dataGridView1.Rows[l].Cells[10].Value = "否";
								}
							}
						}
						else
						{
							string startIFBHStr = ctFormBatchEditCoreRelation2._strStartIFBH_s;
							System.Collections.Generic.List<string> batchEditPinStrList = new System.Collections.Generic.List<string>();
							for (int nn = 0; nn < this.batchEditCoreRelationForm.batchEditPinStrList.Count; nn++)
							{
								batchEditPinStrList.Add(this.batchEditCoreRelationForm.batchEditPinStrList[nn]);
							}
							this.batchEditCoreRelationForm.batchEditPinStrList.Clear();
							try
							{
								for (int mm = 0; mm < batchEditPinStrList.Count; mm++)
								{
									string tempStr = batchEditPinStrList[mm];
									for (int m = 0; m < this.dataGridView1.Rows.Count; m++)
									{
										string temp1Str = this.dataGridView1.Rows[m].Cells[1].Value.ToString();
										string temp2Str = this.dataGridView1.Rows[m].Cells[2].Value.ToString();
										string temp3Str = this.dataGridView1.Rows[m].Cells[3].Value.ToString();
										string temp4Str = this.dataGridView1.Rows[m].Cells[4].Value.ToString();
										if ((startIFBHStr == temp1Str && tempStr == temp2Str) || (startIFBHStr == temp3Str && tempStr == temp4Str))
										{
											if (this.batchEditCoreRelationForm.bIsGroundFlag_s)
											{
												this.dataGridView1.Rows[m].Cells[5].Value = "是";
											}
											else
											{
												this.dataGridView1.Rows[m].Cells[5].Value = "否";
											}
											if (this.batchEditCoreRelationForm.bDLTestFlag_s)
											{
												this.dataGridView1.Rows[m].Cells[7].Value = "是";
											}
											else
											{
												this.dataGridView1.Rows[m].Cells[7].Value = "否";
											}
											if (this.batchEditCoreRelationForm.bJYTestFlag_s)
											{
												this.dataGridView1.Rows[m].Cells[8].Value = "是";
											}
											else
											{
												this.dataGridView1.Rows[m].Cells[8].Value = "否";
											}
											if (this.batchEditCoreRelationForm.bDDJYTestFlag_s)
											{
												this.dataGridView1.Rows[m].Cells[9].Value = "是";
											}
											else
											{
												this.dataGridView1.Rows[m].Cells[9].Value = "否";
											}
											if (this.batchEditCoreRelationForm.bNYTestFlag_s)
											{
												this.dataGridView1.Rows[m].Cells[10].Value = "是";
											}
											else
											{
												this.dataGridView1.Rows[m].Cells[10].Value = "否";
											}
										}
									}
								}
							}
							catch (System.Exception arg_6ED_0)
							{
								KLineTestProcessor.ExceptionRecordFunc(arg_6ED_0.StackTrace);
							}
						}
					}
				}
			}
			catch (System.Exception arg_6FB_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_6FB_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool SaveToExcelFileFunc(string xlsxFile, string csvFile, string cableStr, string bzStr)
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
				Aspose.Cells.Style st = wb.Styles[wb.Styles.Add()];
				st.HorizontalAlignment = TextAlignmentType.Center;
				st.VerticalAlignment = TextAlignmentType.Center;
				st.Font.Name = "宋体";
				st.Font.Size = 11;
				int iCol = 0;
				this.putValue(cells, "序号", 0, 0, st);
				this.putValue(cells, "起点接口", 0, 1, st);
				this.putValue(cells, "起点接点", 0, 2, st);
				this.putValue(cells, "终点接口", 0, 3, st);
				this.putValue(cells, "终点接点", 0, 4, st);
				this.putValue(cells, "是否接地", 0, 5, st);
				this.putValue(cells, "是否导通测试", 0, 6, st);
				this.putValue(cells, "是否短路测试", 0, 7, st);
				this.putValue(cells, "是否绝缘测试", 0, 8, st);
				this.putValue(cells, "是否对地绝缘测试", 0, 9, st);
				this.putValue(cells, "是否耐压测试", 0, 10, st);
				int iRow = 1;
				try
				{
					for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
					{
						string csvFile2 = "";
						string temp0Str = csvFile2;
						string temp1Str = csvFile2;
						string temp2Str = csvFile2;
						string temp3Str = csvFile2;
						string temp4Str = csvFile2;
						string temp5Str = csvFile2;
						string temp6Str = csvFile2;
						string temp7Str = csvFile2;
						string temp8Str = csvFile2;
						string temp9Str = csvFile2;
						string temp10Str = csvFile2;
						if (this.dataGridView1.Rows[i].Cells[0].Value != null)
						{
							temp0Str = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
						}
						if (this.dataGridView1.Rows[i].Cells[1].Value != null)
						{
							temp1Str = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
						}
						if (this.dataGridView1.Rows[i].Cells[2].Value != null)
						{
							temp2Str = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
						}
						if (this.dataGridView1.Rows[i].Cells[3].Value != null)
						{
							temp3Str = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
						}
						if (this.dataGridView1.Rows[i].Cells[4].Value != null)
						{
							temp4Str = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
						}
						if (this.dataGridView1.Rows[i].Cells[5].Value != null)
						{
							temp5Str = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
						}
						if (this.dataGridView1.Rows[i].Cells[6].Value != null)
						{
							temp6Str = this.dataGridView1.Rows[i].Cells[6].Value.ToString();
						}
						if (this.dataGridView1.Rows[i].Cells[7].Value != null)
						{
							temp7Str = this.dataGridView1.Rows[i].Cells[7].Value.ToString();
						}
						if (this.dataGridView1.Rows[i].Cells[8].Value != null)
						{
							temp8Str = this.dataGridView1.Rows[i].Cells[8].Value.ToString();
						}
						if (this.dataGridView1.Rows[i].Cells[9].Value != null)
						{
							temp9Str = this.dataGridView1.Rows[i].Cells[9].Value.ToString();
						}
						if (this.dataGridView1.Rows[i].Cells[10].Value != null)
						{
							temp10Str = this.dataGridView1.Rows[i].Cells[10].Value.ToString();
						}
						this.putValue(cells, temp0Str, iRow, iCol, st);
						this.putValue(cells, temp1Str, iRow, iCol + 1, st);
						this.putValue(cells, temp2Str, iRow, iCol + 2, st);
						this.putValue(cells, temp3Str, iRow, iCol + 3, st);
						this.putValue(cells, temp4Str, iRow, iCol + 4, st);
						this.putValue(cells, temp5Str, iRow, iCol + 5, st);
						this.putValue(cells, temp6Str, iRow, iCol + 6, st);
						this.putValue(cells, temp7Str, iRow, iCol + 7, st);
						this.putValue(cells, temp8Str, iRow, iCol + 8, st);
						this.putValue(cells, temp9Str, iRow, iCol + 9, st);
						this.putValue(cells, temp10Str, iRow, iCol + 10, st);
						iRow++;
					}
				}
				catch (System.Exception arg_585_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_585_0.StackTrace);
				}
				wb.Save(xlsxFile, Aspose.Cells.SaveFormat.Xlsx);
				wb = null;
			}
			catch (System.Exception arg_59F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_59F_0.StackTrace);
				bSuccFlag = false;
			}
			return bSuccFlag;
		}
		public void putValue(Cells cell, object tempValue, int row, int column, Aspose.Cells.Style st)
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
			string csvFn = null;
			try
			{
				if (this.dataGridView1.Rows.Count <= 0)
				{
					MessageBox.Show("线束连接关系表为空!", "提示", MessageBoxButtons.OK);
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
						string cableNameStr = this.textBox_cableNo.Text.ToString().Trim();
						string bzStr = this.textBox_Remark.Text.ToString().Trim();
						string xlsxFn;
						if (string.IsNullOrEmpty(cableNameStr))
						{
							xlsxFn = orfn + "\\连接关系表.xlsx";
						}
						else
						{
							xlsxFn = orfn + "\\" + cableNameStr + "_连接关系表.xlsx";
						}
						if ((!System.IO.File.Exists(xlsxFn) && !System.IO.File.Exists(csvFn)) || DialogResult.OK == MessageBox.Show("该连接关系文件已定义，这将替换掉原有文件，您确定要继续吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
						{
							if (this.SaveToExcelFileFunc(xlsxFn, csvFn, cableNameStr, bzStr))
							{
								MessageBox.Show("导出成功!", "提示", MessageBoxButtons.OK);
							}
							else
							{
								MessageBox.Show("导出失败!请检查关系文件是否处于关闭状态!", "提示", MessageBoxButtons.OK);
							}
						}
					}
				}
			}
			catch (System.Exception arg_153_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_153_0.StackTrace);
			}
		}
		private void checkBox_jyTestFlag_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.checkBox_isGroundFlag.Checked)
			{
				this.checkBox_jyTestFlag.Checked = false;
			}
		}
		private void checkBox_ddjyTestFlag_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.checkBox_isGroundFlag.Checked)
			{
				this.checkBox_ddjyTestFlag.Checked = false;
			}
		}
		private void checkBox_nyTestFlag_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.checkBox_isGroundFlag.Checked)
			{
				this.checkBox_nyTestFlag.Checked = false;
			}
		}
		private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{
				if (e.ColumnIndex != -1 && e.RowIndex != -1)
				{
					if (e.Button == MouseButtons.Right)
					{
						for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
						{
							if (!this.dataGridView1.Rows[e.RowIndex].Selected)
							{
								return;
							}
						}
						System.Drawing.Point e2 = Control.MousePosition;
						System.Drawing.Point sender2 = Control.MousePosition;
						this.contextMenuStrip_RelationManage.Show(sender2.X, e2.Y);
					}
				}
			}
			catch (System.Exception arg_87_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_87_0.StackTrace);
			}
		}
		private void toolStripMenuItem_Update_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.dataGridView1_CellMouseDoubleClick(null, null);
			}
			catch (System.Exception arg_0A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_0A_0.StackTrace);
			}
		}
		private void toolStripMenuItem_DelOne_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.btnDel_Click(null, null);
			}
			catch (System.Exception arg_0A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_0A_0.StackTrace);
			}
		}
		private void toolStripMenuItem_DelAll_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.btnDelAll_Click(null, null);
			}
			catch (System.Exception arg_0A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_0A_0.StackTrace);
			}
		}
		private void comboBox_startPin_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		}
		private void radioButton_Pin_TwoWire_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.comboBox_startPin.Items.Clear();
				this.comboBox_stopPin.Items.Clear();
				for (int nn = 0; nn < this.startPinMeasMethodList.Count; nn++)
				{
					if (this.radioButton_Pin_TwoWire.Checked)
					{
						if (this.startPinMeasMethodList[nn] == 0)
						{
							this.comboBox_startPin.Items.Add(this.startPinStrList[nn]);
						}
					}
					else if (this.startPinMeasMethodList[nn] != 0)
					{
						this.comboBox_startPin.Items.Add(this.startPinStrList[nn]);
					}
				}
				if (this.comboBox_startPin.Items.Count > 0)
				{
					this.comboBox_startPin.SelectedIndex = 0;
				}
				for (int nn2 = 0; nn2 < this.stopPinMeasMethodList.Count; nn2++)
				{
					if (this.radioButton_Pin_TwoWire.Checked)
					{
						if (this.stopPinMeasMethodList[nn2] == 0)
						{
							this.comboBox_stopPin.Items.Add(this.stopPinStrList[nn2]);
						}
					}
					else if (this.stopPinMeasMethodList[nn2] != 0)
					{
						this.comboBox_stopPin.Items.Add(this.stopPinStrList[nn2]);
					}
				}
				if (this.comboBox_stopPin.Items.Count > 0)
				{
					this.comboBox_stopPin.SelectedIndex = 0;
				}
			}
			catch (System.Exception arg_156_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_156_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormAddCable();
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
