using Aspose.Cells;
using System;
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
	public class ctFormEditConnector : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public ctFormBatchAddZD batchAddZDForm;
		public string loginUser;
		public string dbpath;
		public int iEditPid;
		public string currSelectedRowStr;
		public string currSelectedPinStr;
		public string strEditXsbh;
		public string exportPathStr;
		public bool bUpdateDataFlag;
		public string letterStr;
		public int iStartNum;
		public int iMAX_DX_NUM;
		public int iMAX_XX_NUM;
		public string[] AZArray;
		public string[] azArray;
		private Label label_ConverterType;
		private TextBox textBox_ConverterType;
		private FlowLayoutPanel flowLayoutPanel1;
		private OpenFileDialog openFileDialog1;
		private Button btnFileToImportPin;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column2;
		private Button btnDelAll;
		private TextBox textBox1;
		private Button btnBatchAdd;
		private Button btnDel;
		private Button btnAdd;
		private Button btnSubmit;
		private Label label1;
		private Label label2;
		private GroupBox groupBox1;
		private DataGridView dataGridView1;
		private TextBox textBox_StartPin;
		private Label label7;
		private TextBox textBox_Remark;
		private TextBox textBox_name;
		private Button btnQuit;
		private Container components;
		public ctFormEditConnector(KLineTestProcessor gltProcessor, string lUser, int iPid, string xsbhStr)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = lUser;
					this.iEditPid = iPid;
					this.strEditXsbh = xsbhStr;
				}
				catch (System.Exception arg_40_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_40_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormEditConnector()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormEditConnector));
			this.btnDelAll = new Button();
			this.textBox1 = new TextBox();
			this.btnBatchAdd = new Button();
			this.btnDel = new Button();
			this.btnAdd = new Button();
			this.btnSubmit = new Button();
			this.label1 = new Label();
			this.label2 = new Label();
			this.groupBox1 = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.textBox_StartPin = new TextBox();
			this.label7 = new Label();
			this.textBox_Remark = new TextBox();
			this.textBox_name = new TextBox();
			this.btnQuit = new Button();
			this.btnFileToImportPin = new Button();
			this.openFileDialog1 = new OpenFileDialog();
			this.label_ConverterType = new Label();
			this.textBox_ConverterType = new TextBox();
			this.flowLayoutPanel1 = new FlowLayoutPanel();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			this.btnDelAll.Anchor = AnchorStyles.Top;
			this.btnDelAll.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(655, 103);
			this.btnDelAll.Location = location;
			Padding margin = new Padding(2);
			this.btnDelAll.Margin = margin;
			this.btnDelAll.Name = "btnDelAll";
			System.Drawing.Size size = new System.Drawing.Size(112, 24);
			this.btnDelAll.Size = size;
			this.btnDelAll.TabIndex = 8;
			this.btnDelAll.Text = "删除所有针点";
			this.btnDelAll.UseVisualStyleBackColor = true;
			this.btnDelAll.Click += new System.EventHandler(this.btnDelAll_Click);
			this.textBox1.Anchor = AnchorStyles.Bottom;
			this.textBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(566, 525);
			this.textBox1.Location = location2;
			Padding margin2 = new Padding(2);
			this.textBox1.Margin = margin2;
			this.textBox1.MaxLength = 120;
			this.textBox1.Name = "textBox1";
			System.Drawing.Size size2 = new System.Drawing.Size(76, 24);
			this.textBox1.Size = size2;
			this.textBox1.TabIndex = 19;
			this.textBox1.TextAlign = HorizontalAlignment.Center;
			this.textBox1.Visible = false;
			this.textBox1.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
			this.btnBatchAdd.Anchor = AnchorStyles.Top;
			this.btnBatchAdd.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(351, 103);
			this.btnBatchAdd.Location = location3;
			Padding margin3 = new Padding(2);
			this.btnBatchAdd.Margin = margin3;
			this.btnBatchAdd.Name = "btnBatchAdd";
			System.Drawing.Size size3 = new System.Drawing.Size(112, 24);
			this.btnBatchAdd.Size = size3;
			this.btnBatchAdd.TabIndex = 6;
			this.btnBatchAdd.Text = "批量添加针点";
			this.btnBatchAdd.UseVisualStyleBackColor = true;
			this.btnBatchAdd.Click += new System.EventHandler(this.btnBatchAdd_Click);
			this.btnDel.Anchor = AnchorStyles.Top;
			this.btnDel.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(521, 103);
			this.btnDel.Location = location4;
			Padding margin4 = new Padding(2);
			this.btnDel.Margin = margin4;
			this.btnDel.Name = "btnDel";
			System.Drawing.Size size4 = new System.Drawing.Size(112, 24);
			this.btnDel.Size = size4;
			this.btnDel.TabIndex = 7;
			this.btnDel.Text = "删除选中针点";
			this.btnDel.UseVisualStyleBackColor = true;
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			this.btnAdd.Anchor = AnchorStyles.Top;
			this.btnAdd.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(223, 103);
			this.btnAdd.Location = location5;
			Padding margin5 = new Padding(2);
			this.btnAdd.Margin = margin5;
			this.btnAdd.Name = "btnAdd";
			System.Drawing.Size size5 = new System.Drawing.Size(100, 24);
			this.btnAdd.Size = size5;
			this.btnAdd.TabIndex = 5;
			this.btnAdd.Text = "添加针点";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnSubmit.Anchor = AnchorStyles.Bottom;
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(260, 524);
			this.btnSubmit.Location = location6;
			Padding margin6 = new Padding(2);
			this.btnSubmit.Margin = margin6;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size6 = new System.Drawing.Size(112, 24);
			this.btnSubmit.Size = size6;
			this.btnSubmit.TabIndex = 0;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.label1.Anchor = AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(85, 61);
			this.label1.Location = location7;
			Padding margin7 = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin7;
			this.label1.Name = "label1";
			System.Drawing.Size size7 = new System.Drawing.Size(45, 15);
			this.label1.Size = size7;
			this.label1.TabIndex = 17;
			this.label1.Text = "备注:";
			this.label2.Anchor = AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(40, 24);
			this.label2.Location = location8;
			Padding margin8 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin8;
			this.label2.Name = "label2";
			System.Drawing.Size size8 = new System.Drawing.Size(90, 15);
			this.label2.Size = size8;
			this.label2.TabIndex = 15;
			this.label2.Text = "连接器型号:";
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(14, 148);
			this.groupBox1.Location = location9;
			Padding margin9 = new Padding(2);
			this.groupBox1.Margin = margin9;
			this.groupBox1.Name = "groupBox1";
			Padding padding = new Padding(2);
			this.groupBox1.Padding = padding;
			System.Drawing.Size size9 = new System.Drawing.Size(767, 359);
			this.groupBox1.Size = size9;
			this.groupBox1.TabIndex = 20;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "针点列表（双击行可编辑）";
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
				this.Column2
			};
			this.dataGridView1.Columns.AddRange(dataGridViewColumns);
			this.dataGridView1.Dock = DockStyle.Fill;
			System.Drawing.Point location10 = new System.Drawing.Point(2, 19);
			this.dataGridView1.Location = location10;
			Padding margin10 = new Padding(2);
			this.dataGridView1.Margin = margin10;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size10 = new System.Drawing.Size(763, 338);
			this.dataGridView1.Size = size10;
			this.dataGridView1.TabIndex = 6;
			this.dataGridView1.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
			this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
			this.Column1.HeaderText = "序号";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 74;
			this.Column2.HeaderText = "针点";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 500;
			this.textBox_StartPin.Anchor = AnchorStyles.Top;
			this.textBox_StartPin.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location11 = new System.Drawing.Point(91, 103);
			this.textBox_StartPin.Location = location11;
			Padding margin11 = new Padding(2);
			this.textBox_StartPin.Margin = margin11;
			this.textBox_StartPin.MaxLength = 120;
			this.textBox_StartPin.Name = "textBox_StartPin";
			System.Drawing.Size size11 = new System.Drawing.Size(104, 24);
			this.textBox_StartPin.Size = size11;
			this.textBox_StartPin.TabIndex = 3;
			this.textBox_StartPin.Text = "1";
			this.textBox_StartPin.TextAlign = HorizontalAlignment.Center;
			this.label7.Anchor = AnchorStyles.Top;
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location12 = new System.Drawing.Point(22, 108);
			this.label7.Location = location12;
			Padding margin12 = new Padding(2, 0, 2, 0);
			this.label7.Margin = margin12;
			this.label7.Name = "label7";
			System.Drawing.Size size12 = new System.Drawing.Size(60, 15);
			this.label7.Size = size12;
			this.label7.TabIndex = 14;
			this.label7.Text = "针点名:";
			this.textBox_Remark.Anchor = AnchorStyles.Top;
			this.textBox_Remark.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location13 = new System.Drawing.Point(139, 56);
			this.textBox_Remark.Location = location13;
			Padding margin13 = new Padding(2);
			this.textBox_Remark.Margin = margin13;
			this.textBox_Remark.MaxLength = 120;
			this.textBox_Remark.Name = "textBox_Remark";
			System.Drawing.Size size13 = new System.Drawing.Size(240, 24);
			this.textBox_Remark.Size = size13;
			this.textBox_Remark.TabIndex = 4;
			this.textBox_Remark.TextAlign = HorizontalAlignment.Center;
			this.textBox_name.Anchor = AnchorStyles.Top;
			this.textBox_name.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location14 = new System.Drawing.Point(139, 19);
			this.textBox_name.Location = location14;
			Padding margin14 = new Padding(2);
			this.textBox_name.Margin = margin14;
			this.textBox_name.MaxLength = 120;
			this.textBox_name.Name = "textBox_name";
			this.textBox_name.ReadOnly = true;
			System.Drawing.Size size14 = new System.Drawing.Size(240, 24);
			this.textBox_name.Size = size14;
			this.textBox_name.TabIndex = 2;
			this.textBox_name.TextAlign = HorizontalAlignment.Center;
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location15 = new System.Drawing.Point(423, 524);
			this.btnQuit.Location = location15;
			Padding margin15 = new Padding(2);
			this.btnQuit.Margin = margin15;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size15 = new System.Drawing.Size(112, 24);
			this.btnQuit.Size = size15;
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btnFileToImportPin.Anchor = AnchorStyles.Top;
			this.btnFileToImportPin.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location16 = new System.Drawing.Point(2, 36);
			this.btnFileToImportPin.Location = location16;
			Padding margin16 = new Padding(2, 0, 2, 2);
			this.btnFileToImportPin.Margin = margin16;
			this.btnFileToImportPin.Name = "btnFileToImportPin";
			System.Drawing.Size size16 = new System.Drawing.Size(323, 24);
			this.btnFileToImportPin.Size = size16;
			this.btnFileToImportPin.TabIndex = 21;
			this.btnFileToImportPin.Text = "由文件导入针点信息";
			this.btnFileToImportPin.UseVisualStyleBackColor = true;
			this.btnFileToImportPin.Click += new System.EventHandler(this.btnFileToImportPin_Click);
			this.openFileDialog1.FileName = "openFileDialog1";
			this.label_ConverterType.Anchor = AnchorStyles.Top;
			this.label_ConverterType.AutoSize = true;
			this.label_ConverterType.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location17 = new System.Drawing.Point(2, 5);
			this.label_ConverterType.Location = location17;
			Padding margin17 = new Padding(2, 5, 2, 16);
			this.label_ConverterType.Margin = margin17;
			this.label_ConverterType.Name = "label_ConverterType";
			System.Drawing.Size size17 = new System.Drawing.Size(75, 15);
			this.label_ConverterType.Size = size17;
			this.label_ConverterType.TabIndex = 27;
			this.label_ConverterType.Text = "转接型号:";
			this.textBox_ConverterType.Anchor = AnchorStyles.Top;
			this.textBox_ConverterType.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location18 = new System.Drawing.Point(85, 0);
			this.textBox_ConverterType.Location = location18;
			Padding margin18 = new Padding(6, 0, 2, 12);
			this.textBox_ConverterType.Margin = margin18;
			this.textBox_ConverterType.MaxLength = 120;
			this.textBox_ConverterType.Name = "textBox_ConverterType";
			System.Drawing.Size size18 = new System.Drawing.Size(240, 24);
			this.textBox_ConverterType.Size = size18;
			this.textBox_ConverterType.TabIndex = 28;
			this.textBox_ConverterType.TextAlign = HorizontalAlignment.Center;
			this.flowLayoutPanel1.Controls.Add(this.label_ConverterType);
			this.flowLayoutPanel1.Controls.Add(this.textBox_ConverterType);
			this.flowLayoutPanel1.Controls.Add(this.btnFileToImportPin);
			System.Drawing.Point location19 = new System.Drawing.Point(410, 19);
			this.flowLayoutPanel1.Location = location19;
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			System.Drawing.Size size19 = new System.Drawing.Size(360, 72);
			this.flowLayoutPanel1.Size = size19;
			this.flowLayoutPanel1.TabIndex = 29;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.flowLayoutPanel1);
			base.Controls.Add(this.btnDelAll);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.btnBatchAdd);
			base.Controls.Add(this.btnDel);
			base.Controls.Add(this.btnAdd);
			base.Controls.Add(this.btnSubmit);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.textBox_StartPin);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.textBox_Remark);
			base.Controls.Add(this.textBox_name);
			base.Controls.Add(this.btnQuit);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin19 = new Padding(2);
			base.Margin = margin19;
			base.Name = "ctFormEditConnector";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "编辑连接器";
			base.Load += new System.EventHandler(this.ctFormEditConnector_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormEditConnector_SizeChanged);
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public void ResetTempTextBoxControlFunc()
		{
			try
			{
				this.textBox1.Visible = false;
				this.dataGridView1.ScrollBars = ScrollBars.Both;
			}
			catch (System.Exception arg_1A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1A_0.StackTrace);
			}
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
		private void ctFormEditConnector_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.currSelectedRowStr = "";
				this.currSelectedPinStr = "";
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
			catch (System.Exception arg_A4_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_A4_0.StackTrace);
			}
			this.RefreshFormControlFunc();
			this.InitAZArrayFunc();
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode == 0)
				{
					base.WindowState = FormWindowState.Normal;
					this.label_ConverterType.Visible = true;
					this.textBox_ConverterType.Visible = true;
				}
				else
				{
					this.label_ConverterType.Visible = false;
					this.textBox_ConverterType.Visible = false;
				}
			}
			catch (System.Exception arg_104_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_104_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
		}
		public void RefreshFormControlFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.dataGridView1.Rows.Clear();
				int inum = 0;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "select * from TConnectorLibrary where ID = " + this.iEditPid;
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						this.textBox_name.Text = dataReader["ConnectorName"].ToString();
						this.textBox_ConverterType.Text = dataReader["ConverterType"].ToString();
						this.textBox_Remark.Text = dataReader["Remark"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					sqlcommand = "select * from TConnectorLibraryDetail where CLID = '" + System.Convert.ToString(this.iEditPid) + "'";
					cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView1.Rows.Add(1);
						int num = inum + 1;
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
						if (inum == 0)
						{
							string tempStr = dataReader["PinName"].ToString();
							this.textBox_StartPin.Text = tempStr;
							this.dataGridView1.Rows[0].Cells[1].Value = tempStr;
						}
						else
						{
							this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["PinName"].ToString();
						}
						inum = num;
					}
					this.dataGridView1.AllowUserToAddRows = false;
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_1F3_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_1F3_0.StackTrace);
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
			catch (System.Exception arg_217_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_217_0.StackTrace);
			}
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			base.Close();
		}
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 618;
					if (iw < 0)
					{
						iw = 0;
					}
					this.dataGridView1.Columns[0].Width = 74;
					this.dataGridView1.Columns[1].Width = iw + 520;
					this.ResetTempTextBoxControlFunc();
				}
			}
			catch (System.Exception arg_5E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5E_0.StackTrace);
			}
		}
		private void ctFormEditConnector_SizeChanged(object sender, System.EventArgs e)
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
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				if (this.dataGridView1.Rows.Count <= 0)
				{
					MessageBox.Show("针点未定义!", "提示", MessageBoxButtons.OK);
					return;
				}
				if (string.IsNullOrEmpty(this.textBox_name.Text.ToString().Trim()))
				{
					MessageBox.Show("连接器型号为空!", "提示", MessageBoxButtons.OK);
					return;
				}
				string converterTypeStr = this.textBox_ConverterType.Text.ToString().Trim();
				int iPinNum = this.dataGridView1.Rows.Count;
				string text = "";
				string tempStr = text;
				bool bSameFlag = false;
				for (int i = 0; i < iPinNum; i++)
				{
					if (this.dataGridView1.Rows[i].Cells[1].Value != null)
					{
						tempStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
						for (int j = 0; j < iPinNum; j++)
						{
							if (j != i)
							{
								if (this.dataGridView1.Rows[j].Cells[1].Value != null)
								{
									string temp2Str = this.dataGridView1.Rows[j].Cells[1].Value.ToString();
									if (tempStr == temp2Str)
									{
										goto IL_176;
									}
								}
							}
						}
						if (!bSameFlag)
						{
							goto IL_169;
						}
						IL_176:
						MessageBox.Show("存在相同的针点" + tempStr + "!", "提示", MessageBoxButtons.OK);
						return;
					}
					IL_169:;
				}
				if (bSameFlag)
				{
					goto IL_176;
				}
				string remarkStr = this.textBox_Remark.Text.ToString();
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "update TConnectorLibrary set ConverterType = '" + converterTypeStr + "',PinNum = " + iPinNum + ",Remark = '" + remarkStr + "' where ID = " + this.iEditPid;
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					cmd.ExecuteNonQuery();
					System.Threading.Thread.Sleep(50);
					sqlcommand = "delete from TConnectorLibraryDetail where CLID='" + System.Convert.ToString(this.iEditPid) + "'";
					cmd = new OleDbCommand(sqlcommand, connection);
					cmd.ExecuteNonQuery();
					System.Threading.Thread.Sleep(100);
					for (int k = 0; k < iPinNum; k++)
					{
						if (this.dataGridView1.Rows[k].Cells[1].Value != null)
						{
							tempStr = this.dataGridView1.Rows[k].Cells[1].Value.ToString();
							sqlcommand = "insert into TConnectorLibraryDetail(CLID,PinName) values('" + System.Convert.ToString(this.iEditPid) + "','" + tempStr + "')";
							cmd = new OleDbCommand(sqlcommand, connection);
							cmd.ExecuteNonQuery();
						}
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_31C_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_31C_0.StackTrace);
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
					base.Close();
					goto IL_35A;
				}
				goto IL_37F;
				IL_35A:
				return;
			}
			catch (System.Exception arg_35C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_35C_0.StackTrace);
				MessageBox.Show("存在未知异常!", "提示", MessageBoxButtons.OK);
				base.Close();
				return;
			}
			IL_37F:
			MessageBox.Show("操作成功!", "提示", MessageBoxButtons.OK);
			base.Close();
		}
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				string startPinStr = this.textBox_StartPin.Text.ToString().Trim();
				if (string.IsNullOrEmpty(startPinStr))
				{
					MessageBox.Show("起始针点不能为空!", "提示", MessageBoxButtons.OK);
					return;
				}
				int inum = this.dataGridView1.Rows.Count;
				for (int i = 0; i < inum; i++)
				{
					if (this.dataGridView1.Rows[i].Cells[1].Value != null)
					{
						string tempStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
						if (startPinStr == tempStr)
						{
							MessageBox.Show("针点" + startPinStr + "已添加，请勿重复操作!", "提示", MessageBoxButtons.OK);
							return;
						}
					}
				}
				this.dataGridView1.AllowUserToAddRows = true;
				this.dataGridView1.Rows.Add(1);
				this.dataGridView1.Rows[inum].Cells[0].Value = inum + 1;
				this.dataGridView1.Rows[inum].Cells[1].Value = startPinStr;
				this.dataGridView1.AllowUserToAddRows = false;
				this.dataGridView1.ClearSelection();
			}
			catch (System.Exception arg_15A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_15A_0.StackTrace);
			}
			this.ResetTempTextBoxControlFunc();
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
		private void btnBatchAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormBatchAddZD ctFormBatchAddZD = new ctFormBatchAddZD(this.gLineTestProcessor);
				this.batchAddZDForm = ctFormBatchAddZD;
				ctFormBatchAddZD.Activate();
				this.batchAddZDForm.ShowDialog();
				ctFormBatchAddZD ctFormBatchAddZD2 = this.batchAddZDForm;
				int iACount = ctFormBatchAddZD2.iAddCount;
				if (iACount <= 0)
				{
					return;
				}
				int iAddRule = ctFormBatchAddZD2.iAddRule;
				string startPinNameStr = ctFormBatchAddZD2.startPinNameStr;
				string tempStr;
				for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
				{
					if (this.dataGridView1.Rows[i].Cells[1].Value != null)
					{
						tempStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
						if (startPinNameStr == tempStr)
						{
							MessageBox.Show("针点" + startPinNameStr + "已存在!", "提示", MessageBoxButtons.OK);
							return;
						}
					}
				}
				tempStr = startPinNameStr;
				this.dataGridView1.AllowUserToAddRows = true;
				int iRowsCount = this.dataGridView1.Rows.Count;
				int iStartPinNum = 1;
				if (iAddRule == 0)
				{
					iStartPinNum = System.Convert.ToInt32(startPinNameStr);
				}
				for (int j = 0; j < iACount; j++)
				{
					if (iAddRule == 0)
					{
						int arg_13B_0 = iStartPinNum;
						iStartPinNum++;
						tempStr = System.Convert.ToString(arg_13B_0);
					}
					else if (iAddRule == 1)
					{
						tempStr = this.GetBatctAddDataAAFunc(tempStr, j, true);
					}
					else if (iAddRule == 2)
					{
						tempStr = this.GetBatctAddDataAAFunc(tempStr, j, false);
					}
					else if (iAddRule == 3)
					{
						tempStr = this.GetBatctAddDataFunc(tempStr, j, true);
					}
					else if (iAddRule == 4)
					{
						tempStr = this.GetBatctAddDataFunc(tempStr, j, false);
					}
					else if (iAddRule == 5)
					{
						tempStr = this.GenerateStringDisposeFunc(startPinNameStr, j);
					}
					if (!string.IsNullOrEmpty(tempStr))
					{
						this.dataGridView1.Rows.Add(1);
						int index = iRowsCount - 1;
						this.dataGridView1.Rows[index].Cells[0].Value = System.Convert.ToString(iRowsCount);
						this.dataGridView1.Rows[index].Cells[1].Value = tempStr;
						iRowsCount++;
					}
				}
				this.dataGridView1.AllowUserToAddRows = false;
				if (0 <= this.dataGridView1.Rows.Count - 1)
				{
					this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Selected = true;
				}
			}
			catch (System.Exception arg_265_0)
			{
				this.dataGridView1.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_265_0.StackTrace);
			}
			this.ResetTempTextBoxControlFunc();
		}
		private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.Rows.Count > 0)
				{
					this.currSelectedRowStr = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
					this.currSelectedPinStr = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
					int cellTop = 0;
					for (int i = this.dataGridView1.FirstDisplayedCell.RowIndex; i < e.RowIndex; i++)
					{
						cellTop = this.dataGridView1.Rows[i].Height + cellTop;
					}
					System.Drawing.Point location = this.groupBox1.Location;
					int iLeft = this.dataGridView1.Location.X + location.X;
					System.Drawing.Point location2 = this.groupBox1.Location;
					int iTop = this.dataGridView1.Location.Y + location2.Y;
					iLeft = this.dataGridView1.Columns[0].Width + iLeft + 1;
					iTop = this.dataGridView1.ColumnHeadersHeight + cellTop + iTop + 2;
					this.textBox1.Left = iLeft;
					this.textBox1.Top = iTop;
					this.textBox1.Height = this.dataGridView1.RowTemplate.Height + 3;
					this.textBox1.Width = this.dataGridView1.Columns[1].Width;
					this.textBox1.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
					this.textBox1.Visible = true;
					this.textBox1.Focus();
				}
			}
			catch (System.Exception arg_1E3_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1E3_0.StackTrace);
				this.dataGridView1.ScrollBars = ScrollBars.Both;
			}
		}
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count <= 0)
				{
					return;
				}
				this.dataGridView1.Rows.Remove(this.dataGridView1.SelectedRows[0]);
				int sender2;
				for (int i = 0; i < this.dataGridView1.Rows.Count; i = sender2)
				{
					sender2 = i + 1;
					this.dataGridView1.Rows[i].Cells[0].Value = System.Convert.ToString(sender2);
				}
			}
			catch (System.Exception arg_7F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_7F_0.StackTrace);
			}
			this.ResetTempTextBoxControlFunc();
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
			this.ResetTempTextBoxControlFunc();
		}
		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					if (this.textBox1.Visible)
					{
						string editStr = this.textBox1.Text.ToString().Trim();
						if (string.IsNullOrEmpty(editStr))
						{
							MessageBox.Show("针点为空!", "提示", MessageBoxButtons.OK);
						}
						else
						{
							for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
							{
								string tempStr = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
								if (0 != this.currSelectedRowStr.CompareTo(tempStr))
								{
									tempStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
									if (0 == editStr.CompareTo(tempStr))
									{
										MessageBox.Show("针点已存在!", "提示", MessageBoxButtons.OK);
										this.textBox1.Visible = false;
										this.dataGridView1.ScrollBars = ScrollBars.Both;
										return;
									}
								}
							}
							for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
							{
								if (this.currSelectedRowStr == this.dataGridView1.Rows[j].Cells[0].Value.ToString())
								{
									this.dataGridView1.Rows[j].Cells[1].Value = this.textBox1.Text.ToString();
									break;
								}
							}
							this.textBox1.Visible = false;
							this.dataGridView1.ScrollBars = ScrollBars.Both;
						}
					}
				}
				else if (e.KeyChar == '\u001b')
				{
					this.textBox1.Visible = false;
					this.dataGridView1.ScrollBars = ScrollBars.Both;
				}
			}
			catch (System.Exception arg_1CC_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1CC_0.StackTrace);
			}
		}
		private void dataGridView1_SelectionChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (this.textBox1.Visible)
				{
					string editStr = this.textBox1.Text.ToString().Trim();
					if (!string.IsNullOrEmpty(editStr))
					{
						for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
						{
							if (this.currSelectedRowStr != this.dataGridView1.Rows[i].Cells[0].Value.ToString() && editStr == this.dataGridView1.Rows[i].Cells[1].Value.ToString())
							{
								MessageBox.Show("针点已存在!", "提示", MessageBoxButtons.OK);
								this.textBox1.Text = "";
								this.textBox1.Visible = false;
								return;
							}
						}
						for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
						{
							if (this.currSelectedRowStr == this.dataGridView1.Rows[j].Cells[0].Value.ToString())
							{
								this.dataGridView1.Rows[j].Cells[1].Value = this.textBox1.Text.ToString();
								break;
							}
						}
					}
					this.textBox1.Text = "";
					this.textBox1.Visible = false;
				}
			}
			catch (System.Exception arg_184_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_184_0.StackTrace);
			}
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
			bool bSuccFlag = true;
			try
			{
				if (string.IsNullOrEmpty(file))
				{
					byte result = 0;
					return result != 0;
				}
				this.dataGridView1.Rows.Clear();
				int iRow = 1;
				bool bFailFlag = false;
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
						Cells cells = sht.Cells;
						if (sht == null)
						{
							byte result = 0;
							return result != 0;
						}
						int rowCount = cells.MaxDataRow + 1;
						if (rowCount == 0)
						{
							byte result = 0;
							return result != 0;
						}
						int cellCount = cells.MaxDataColumn + 1;
						try
						{
							this.dataGridView1.AllowUserToAddRows = true;
							int iRowIndex = 0;
							int iColNum = 0;
							string firstStr = "";
							if (cells[1, 0].Value != null)
							{
								firstStr = cells[1, 0].Value.ToString();
							}
							if (string.IsNullOrEmpty(firstStr))
							{
								iColNum = 1;
							}
							while (cells[iRow, iColNum].Value != null)
							{
								firstStr = cells[iRow, iColNum].Value.ToString();
								this.dataGridView1.Rows.Add(1);
								int num = iRowIndex + 1;
								this.dataGridView1.Rows[iRowIndex].Cells[0].Value = System.Convert.ToString(num);
								this.dataGridView1.Rows[iRowIndex].Cells[1].Value = firstStr;
								iRowIndex = num;
								iRow++;
								if (rowCount <= iRow)
								{
									break;
								}
							}
							this.dataGridView1.AllowUserToAddRows = false;
						}
						catch (System.Exception arg_1D0_0)
						{
							this.dataGridView1.AllowUserToAddRows = false;
							this.dataGridView1.Rows.Clear();
							KLineTestProcessor.ExceptionRecordFunc(arg_1D0_0.StackTrace);
							bSuccFlag = false;
						}
					}
				}
				else
				{
					Workbook wk = new Workbook(file);
					Worksheet sht2 = wk.Worksheets[0];
					Cells cells2 = sht2.Cells;
					if (sht2 == null)
					{
						byte result = 0;
						return result != 0;
					}
					int rowCount2 = cells2.MaxDataRow + 1;
					if (rowCount2 == 0)
					{
						byte result = 0;
						return result != 0;
					}
					int cellCount2 = cells2.MaxDataColumn + 1;
					try
					{
						this.dataGridView1.AllowUserToAddRows = true;
						int iRowIndex = 0;
						while (cells2[iRow, 1].Value != null)
						{
							string firstStr = cells2[iRow, 1].Value.ToString();
							this.dataGridView1.Rows.Add(1);
							int num2 = iRowIndex + 1;
							this.dataGridView1.Rows[iRowIndex].Cells[0].Value = System.Convert.ToString(num2);
							this.dataGridView1.Rows[iRowIndex].Cells[1].Value = firstStr;
							iRowIndex = num2;
							iRow++;
							if (rowCount2 <= iRow)
							{
								break;
							}
						}
						this.dataGridView1.AllowUserToAddRows = false;
					}
					catch (System.Exception ex_2EA)
					{
						this.dataGridView1.AllowUserToAddRows = false;
						this.dataGridView1.Rows.Clear();
						bSuccFlag = false;
					}
				}
				if (this.dataGridView1.Rows.Count - 1 >= 0)
				{
					this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Selected = true;
				}
				if (bFailFlag)
				{
					this.dataGridView1.Rows.Clear();
					MessageBox.Show("文件中第" + System.Convert.ToString(iFailRow) + "行存在无效数据!", "提示", MessageBoxButtons.OK);
					bSuccFlag = false;
				}
			}
			catch (System.Exception arg_390_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_390_0.StackTrace);
			}
			return bSuccFlag;
		}
		private void btnFileToImportPin_Click(object sender, System.EventArgs e)
		{
			try
			{
				OpenFileDialog sender2 = new OpenFileDialog();
				this.openFileDialog1 = sender2;
				sender2.Filter = "定义文件|*.xlsx;*.xls;*.csv";
				this.openFileDialog1.RestoreDirectory = true;
				this.openFileDialog1.FilterIndex = 1;
				if (DialogResult.OK == this.openFileDialog1.ShowDialog(this))
				{
					string readfn = this.openFileDialog1.FileName;
					string expr_4F = readfn;
					string expr_61 = expr_4F.Substring(expr_4F.LastIndexOf("\\") + 1);
					string fkzm = expr_61.Substring(expr_61.LastIndexOf(".") + 1).ToUpper();
					if (this.AsposeCellsReadConfigFileFunc(readfn, fkzm))
					{
						this.bUpdateDataFlag = true;
						MessageBox.Show("导入成功!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						this.dataGridView1.Rows.Clear();
						MessageBox.Show("导入失败，请确保文件格式及内容真实有效!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_C0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_C0_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormEditConnector();
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
