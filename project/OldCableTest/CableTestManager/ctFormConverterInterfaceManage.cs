using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormConverterInterfaceManage : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public ctFormInterfaceLibrary interfaceLibraryForm;
		public string loginUser;
		public string strEditXsbh;
		public string[] strIDArray;
		public System.Collections.Generic.List<string> plugList;
		public System.Collections.Generic.List<string> plugPinNumList;
		public bool bSubmitFlag;
		private TableLayoutPanel tableLayoutPanel1;
		private Panel panel1;
		private Panel panel2;
		private Panel panel3;
		private Label label1;
		private DataGridView dataGridView2;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column3;
		private DataGridViewTextBoxColumn Column4;
		private Button btnIFManage;
		private Button btnDel;
		private Button btnAddAll;
		private GroupBox groupBox_if;
		private Button btnQuit;
		private Button btnDelAll;
		private Button btnSubmit;
		private Button btnAdd;
		private GroupBox groupBox1;
		private DataGridView dataGridView1;
		private Label label_EditCableBH;
		private TextBox textBox_InterfaceNo;
		private Label label2;
		private Container components;
		public ctFormConverterInterfaceManage(KLineTestProcessor gltProcessor, string lUser, System.Collections.Generic.List<string> plugTempList, System.Collections.Generic.List<string> pinNumTempList)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = lUser;
					this.plugList = new System.Collections.Generic.List<string>();
					this.plugPinNumList = new System.Collections.Generic.List<string>();
					this.strIDArray = new string[5000];
					for (int i = 0; i < plugTempList.Count; i++)
					{
						this.plugList.Add(plugTempList[i]);
					}
					for (int j = 0; j < pinNumTempList.Count; j++)
					{
						this.plugPinNumList.Add(pinNumTempList[j]);
					}
				}
				catch (System.Exception arg_8A_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_8A_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormConverterInterfaceManage()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormConverterInterfaceManage));
			this.label1 = new Label();
			this.dataGridView2 = new DataGridView();
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			this.btnIFManage = new Button();
			this.btnDel = new Button();
			this.btnAddAll = new Button();
			this.groupBox_if = new GroupBox();
			this.btnQuit = new Button();
			this.btnDelAll = new Button();
			this.btnSubmit = new Button();
			this.btnAdd = new Button();
			this.groupBox1 = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.label_EditCableBH = new Label();
			this.textBox_InterfaceNo = new TextBox();
			this.label2 = new Label();
			this.tableLayoutPanel1 = new TableLayoutPanel();
			this.panel1 = new Panel();
			this.panel2 = new Panel();
			this.panel3 = new Panel();
			((ISupportInitialize)this.dataGridView2).BeginInit();
			this.groupBox_if.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(11, 14);
			this.label1.Location = location;
			Padding margin = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin;
			this.label1.Name = "label1";
			System.Drawing.Size size = new System.Drawing.Size(105, 15);
			this.label1.Size = size;
			this.label1.TabIndex = 2;
			this.label1.Text = "转接工装代号:";
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.AllowUserToResizeColumns = false;
			this.dataGridView2.AllowUserToResizeRows = false;
			System.Drawing.Color window = System.Drawing.SystemColors.Window;
			this.dataGridView2.BackgroundColor = window;
			this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn1,
				this.dataGridViewTextBoxColumn2,
				this.dataGridViewTextBoxColumn3
			};
			this.dataGridView2.Columns.AddRange(dataGridViewColumns);
			this.dataGridView2.Dock = DockStyle.Fill;
			System.Drawing.Point location2 = new System.Drawing.Point(2, 19);
			this.dataGridView2.Location = location2;
			Padding margin2 = new Padding(2);
			this.dataGridView2.Margin = margin2;
			this.dataGridView2.MultiSelect = false;
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.RowHeadersVisible = false;
			this.dataGridView2.RowTemplate.Height = 27;
			this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size2 = new System.Drawing.Size(317, 431);
			this.dataGridView2.Size = size2;
			this.dataGridView2.TabIndex = 3;
			this.dataGridViewTextBoxColumn1.HeaderText = "序号";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 74;
			this.dataGridViewTextBoxColumn2.HeaderText = "接口代号";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 130;
			this.dataGridViewTextBoxColumn3.HeaderText = "接点数";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.Width = 90;
			this.btnIFManage.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.btnIFManage.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(550, 542);
			this.btnIFManage.Location = location3;
			Padding margin3 = new Padding(2);
			this.btnIFManage.Margin = margin3;
			this.btnIFManage.Name = "btnIFManage";
			System.Drawing.Size size3 = new System.Drawing.Size(112, 24);
			this.btnIFManage.Size = size3;
			this.btnIFManage.TabIndex = 18;
			this.btnIFManage.Text = "接口库管理";
			this.btnIFManage.UseVisualStyleBackColor = true;
			this.btnIFManage.Visible = false;
			this.btnIFManage.Click += new System.EventHandler(this.btnIFManage_Click);
			this.btnDel.Anchor = AnchorStyles.Left;
			this.btnDel.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(5, 312);
			this.btnDel.Location = location4;
			Padding margin4 = new Padding(2);
			this.btnDel.Margin = margin4;
			this.btnDel.Name = "btnDel";
			System.Drawing.Size size4 = new System.Drawing.Size(112, 24);
			this.btnDel.Size = size4;
			this.btnDel.TabIndex = 19;
			this.btnDel.Text = "移除选中接口";
			this.btnDel.UseVisualStyleBackColor = true;
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			this.btnAddAll.Anchor = AnchorStyles.Left;
			this.btnAddAll.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(5, 121);
			this.btnAddAll.Location = location5;
			Padding margin5 = new Padding(2);
			this.btnAddAll.Margin = margin5;
			this.btnAddAll.Name = "btnAddAll";
			System.Drawing.Size size5 = new System.Drawing.Size(112, 24);
			this.btnAddAll.Size = size5;
			this.btnAddAll.TabIndex = 20;
			this.btnAddAll.Text = "添加所有接口";
			this.btnAddAll.UseVisualStyleBackColor = true;
			this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
			this.groupBox_if.Controls.Add(this.dataGridView2);
			this.groupBox_if.Dock = DockStyle.Fill;
			this.groupBox_if.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(454, 50);
			this.groupBox_if.Location = location6;
			Padding margin6 = new Padding(2);
			this.groupBox_if.Margin = margin6;
			this.groupBox_if.Name = "groupBox_if";
			Padding padding = new Padding(2);
			this.groupBox_if.Padding = padding;
			System.Drawing.Size size6 = new System.Drawing.Size(321, 452);
			this.groupBox_if.Size = size6;
			this.groupBox_if.TabIndex = 16;
			this.groupBox_if.TabStop = false;
			this.groupBox_if.Text = "线束接口列表";
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(422, 532);
			this.btnQuit.Location = location7;
			Padding margin7 = new Padding(2);
			this.btnQuit.Margin = margin7;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size7 = new System.Drawing.Size(112, 24);
			this.btnQuit.Size = size7;
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btnDelAll.Anchor = AnchorStyles.Left;
			this.btnDelAll.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(5, 360);
			this.btnDelAll.Location = location8;
			Padding margin8 = new Padding(2);
			this.btnDelAll.Margin = margin8;
			this.btnDelAll.Name = "btnDelAll";
			System.Drawing.Size size8 = new System.Drawing.Size(112, 24);
			this.btnDelAll.Size = size8;
			this.btnDelAll.TabIndex = 21;
			this.btnDelAll.Text = "移除所有接口";
			this.btnDelAll.UseVisualStyleBackColor = true;
			this.btnDelAll.Click += new System.EventHandler(this.btnDelAll_Click);
			this.btnSubmit.Anchor = AnchorStyles.Bottom;
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(260, 532);
			this.btnSubmit.Location = location9;
			Padding margin9 = new Padding(2);
			this.btnSubmit.Margin = margin9;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size9 = new System.Drawing.Size(112, 24);
			this.btnSubmit.Size = size9;
			this.btnSubmit.TabIndex = 0;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnAdd.Anchor = AnchorStyles.Left;
			this.btnAdd.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location10 = new System.Drawing.Point(5, 69);
			this.btnAdd.Location = location10;
			Padding margin10 = new Padding(2);
			this.btnAdd.Margin = margin10;
			this.btnAdd.Name = "btnAdd";
			System.Drawing.Size size10 = new System.Drawing.Size(112, 24);
			this.btnAdd.Size = size10;
			this.btnAdd.TabIndex = 17;
			this.btnAdd.Text = "添加选中接口";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Dock = DockStyle.Fill;
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location11 = new System.Drawing.Point(2, 50);
			this.groupBox1.Location = location11;
			Padding margin11 = new Padding(2);
			this.groupBox1.Margin = margin11;
			this.groupBox1.Name = "groupBox1";
			Padding padding2 = new Padding(2);
			this.groupBox1.Padding = padding2;
			System.Drawing.Size size11 = new System.Drawing.Size(320, 452);
			this.groupBox1.Size = size11;
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "已选线束接口列表";
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			System.Drawing.Color window2 = System.Drawing.SystemColors.Window;
			this.dataGridView1.BackgroundColor = window2;
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns2 = new DataGridViewColumn[]
			{
				this.Column1,
				this.Column3,
				this.Column4
			};
			this.dataGridView1.Columns.AddRange(dataGridViewColumns2);
			this.dataGridView1.Dock = DockStyle.Fill;
			System.Drawing.Point location12 = new System.Drawing.Point(2, 19);
			this.dataGridView1.Location = location12;
			Padding margin12 = new Padding(2);
			this.dataGridView1.Margin = margin12;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size12 = new System.Drawing.Size(316, 431);
			this.dataGridView1.Size = size12;
			this.dataGridView1.TabIndex = 3;
			this.Column1.HeaderText = "序号";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 74;
			this.Column3.HeaderText = "接口代号";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 130;
			this.Column4.HeaderText = "接点数";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Width = 90;
			this.label_EditCableBH.AutoSize = true;
			this.label_EditCableBH.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location13 = new System.Drawing.Point(122, 14);
			this.label_EditCableBH.Location = location13;
			Padding margin13 = new Padding(2, 0, 2, 0);
			this.label_EditCableBH.Margin = margin13;
			this.label_EditCableBH.Name = "label_EditCableBH";
			System.Drawing.Size size13 = new System.Drawing.Size(39, 15);
			this.label_EditCableBH.Size = size13;
			this.label_EditCableBH.TabIndex = 3;
			this.label_EditCableBH.Text = "L1-1";
			this.textBox_InterfaceNo.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_InterfaceNo.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location14 = new System.Drawing.Point(93, 10);
			this.textBox_InterfaceNo.Location = location14;
			Padding margin14 = new Padding(2);
			this.textBox_InterfaceNo.Margin = margin14;
			this.textBox_InterfaceNo.MaxLength = 120;
			this.textBox_InterfaceNo.Name = "textBox_InterfaceNo";
			System.Drawing.Size size14 = new System.Drawing.Size(205, 24);
			this.textBox_InterfaceNo.Size = size14;
			this.textBox_InterfaceNo.TabIndex = 23;
			this.textBox_InterfaceNo.TextChanged += new System.EventHandler(this.textBox_InterfaceNo_TextChanged);
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location15 = new System.Drawing.Point(12, 14);
			this.label2.Location = location15;
			Padding margin15 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin15;
			this.label2.Name = "label2";
			System.Drawing.Size size15 = new System.Drawing.Size(75, 15);
			this.label2.Size = size15;
			this.label2.TabIndex = 22;
			this.label2.Text = "接口筛选:";
			this.tableLayoutPanel1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 128f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.groupBox_if, 2, 1);
			System.Drawing.Point location16 = new System.Drawing.Point(9, 10);
			this.tableLayoutPanel1.Location = location16;
			Padding margin16 = new Padding(2);
			this.tableLayoutPanel1.Margin = margin16;
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			System.Drawing.Size size16 = new System.Drawing.Size(777, 504);
			this.tableLayoutPanel1.Size = size16;
			this.tableLayoutPanel1.TabIndex = 24;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.label_EditCableBH);
			this.panel1.Dock = DockStyle.Fill;
			System.Drawing.Point location17 = new System.Drawing.Point(2, 2);
			this.panel1.Location = location17;
			Padding margin17 = new Padding(2);
			this.panel1.Margin = margin17;
			this.panel1.Name = "panel1";
			System.Drawing.Size size17 = new System.Drawing.Size(320, 44);
			this.panel1.Size = size17;
			this.panel1.TabIndex = 0;
			this.panel2.Controls.Add(this.textBox_InterfaceNo);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Dock = DockStyle.Fill;
			System.Drawing.Point location18 = new System.Drawing.Point(454, 2);
			this.panel2.Location = location18;
			Padding margin18 = new Padding(2);
			this.panel2.Margin = margin18;
			this.panel2.Name = "panel2";
			System.Drawing.Size size18 = new System.Drawing.Size(321, 44);
			this.panel2.Size = size18;
			this.panel2.TabIndex = 1;
			this.panel3.Controls.Add(this.btnAdd);
			this.panel3.Controls.Add(this.btnAddAll);
			this.panel3.Controls.Add(this.btnDel);
			this.panel3.Controls.Add(this.btnDelAll);
			this.panel3.Dock = DockStyle.Fill;
			System.Drawing.Point location19 = new System.Drawing.Point(326, 50);
			this.panel3.Location = location19;
			Padding margin19 = new Padding(2);
			this.panel3.Margin = margin19;
			this.panel3.Name = "panel3";
			System.Drawing.Size size19 = new System.Drawing.Size(124, 452);
			this.panel3.Size = size19;
			this.panel3.TabIndex = 2;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.tableLayoutPanel1);
			base.Controls.Add(this.btnIFManage);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnSubmit);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin20 = new Padding(2);
			base.Margin = margin20;
			base.Name = "ctFormConverterInterfaceManage";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "转接工装接口管理";
			base.Load += new System.EventHandler(this.ctFormConverterInterfaceManage_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormConverterInterfaceManage_SizeChanged);
			((ISupportInitialize)this.dataGridView2).EndInit();
			this.groupBox_if.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			base.ResumeLayout(false);
		}
		public void saveOperationRecord(string operContentStr)
		{
			OleDbConnection connection = null;
			try
			{
				System.ValueType dt = System.DateTime.Now;
				string dbpath = Application.StartupPath + "\\ctsdb.mdb";
				connection = new OleDbConnection();
				connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
				connection.Open();
				new OleDbCommand("insert into TOperationRecord(UEID,OperationTime,OperationContent,TestRecordID,Explain) " + "values('" + this.loginUser + "',#" + dt + "#,'" + operContentStr + "','','')", connection).ExecuteNonQuery();
				connection.Close();
				connection = null;
			}
			catch (System.Exception arg_9F_0)
			{
				if (connection != null)
				{
					connection.Close();
				}
				KLineTestProcessor.ExceptionRecordFunc(arg_9F_0.StackTrace);
			}
		}
		public void RefreshDataGridView()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.dataGridView1.Rows.Clear();
				this.dataGridView2.Rows.Clear();
				int inum = 0;
				int inum2 = 0;
				string text = "";
				string tempStr = text;
				string dbpath = Application.StartupPath + "\\ctsdb.mdb";
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand;
					OleDbCommand cmd;
					try
					{
						sqlcommand = "select * from TLineStructLibrary where LineStructName= '" + this.strEditXsbh + "'";
						cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						if (dataReader.Read())
						{
							tempStr = dataReader["PlugInfo"].ToString();
						}
						dataReader.Close();
						dataReader = null;
					}
					catch (System.Exception arg_BB_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_BB_0.StackTrace);
						if (dataReader != null)
						{
							dataReader.Close();
							dataReader = null;
						}
					}
					if (!string.IsNullOrEmpty(tempStr))
					{
						this.dataGridView1.AllowUserToAddRows = true;
						string[] plugStringArray = tempStr.Split(new char[]
						{
							','
						});
						for (int i = 0; i < plugStringArray.Length; i++)
						{
							string text2 = plugStringArray[i];
							string tempNameStr = text2;
							if (!string.IsNullOrEmpty(text2))
							{
								string tempPNumStr = "";
								sqlcommand = "select * from TPlugLibrary where PlugNo= '" + plugStringArray[i] + "'";
								cmd = new OleDbCommand(sqlcommand, connection);
								dataReader = cmd.ExecuteReader();
								if (dataReader.Read())
								{
									tempPNumStr = dataReader["PinNum"].ToString();
								}
								dataReader.Close();
								dataReader = null;
								this.dataGridView1.Rows.Add(1);
								int num = inum + 1;
								this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
								this.dataGridView1.Rows[inum].Cells[1].Value = tempNameStr;
								this.dataGridView1.Rows[inum].Cells[2].Value = tempPNumStr;
								inum = num;
							}
						}
						this.dataGridView1.AllowUserToAddRows = false;
					}
					sqlcommand = "select * from TPlugLibrary order by PlugNo";
					cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					this.dataGridView2.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView2.Rows.Add(1);
						int num2 = inum2 + 1;
						this.dataGridView2.Rows[inum2].Cells[0].Value = System.Convert.ToString(num2);
						this.dataGridView2.Rows[inum2].Cells[1].Value = dataReader["PlugNo"].ToString();
						this.dataGridView2.Rows[inum2].Cells[2].Value = dataReader["PinNum"].ToString();
						inum2 = num2;
					}
					dataReader.Close();
					dataReader = null;
					this.dataGridView2.AllowUserToAddRows = false;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_332_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					this.dataGridView2.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_332_0.StackTrace);
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
			catch (System.Exception arg_356_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_356_0.StackTrace);
			}
		}
		public void RefreshDataGridView2()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.dataGridView2.Rows.Clear();
				int inum2 = 0;
				string dbpath = Application.StartupPath + "\\ctsdb.mdb";
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select top " + 5000 + " * from TPlugLibrary order by PlugNo", connection).ExecuteReader();
					this.dataGridView2.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView2.Rows.Add(1);
						int num = inum2 + 1;
						this.dataGridView2.Rows[inum2].Cells[0].Value = System.Convert.ToString(num);
						this.dataGridView2.Rows[inum2].Cells[1].Value = dataReader["PlugNo"].ToString();
						this.dataGridView2.Rows[inum2].Cells[2].Value = dataReader["PinNum"].ToString();
						inum2 = num;
					}
					dataReader.Close();
					dataReader = null;
					this.dataGridView2.AllowUserToAddRows = false;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_155_0)
				{
					this.dataGridView2.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_155_0.StackTrace);
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
			catch (System.Exception arg_179_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_179_0.StackTrace);
			}
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			this.plugList.Clear();
			this.plugPinNumList.Clear();
			this.bSubmitFlag = false;
			base.Close();
		}
		private void btnIFManage_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormInterfaceLibrary this2 = new ctFormInterfaceLibrary(this.gLineTestProcessor);
				this.interfaceLibraryForm = this2;
				this2.Activate();
				this.interfaceLibraryForm.ShowDialog();
				this.RefreshDataGridView2();
			}
			catch (System.Exception arg_2D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2D_0.StackTrace);
			}
		}
		private void ctFormConverterInterfaceManage_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.dataGridView1.Rows.Clear();
				this.dataGridView2.Rows.Clear();
				this.label_EditCableBH.Text = this.strEditXsbh;
				this.bSubmitFlag = false;
				this.RefreshDataGridView2();
				for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
				{
					this.dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					this.dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
				{
					this.dataGridView1.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				for (int k = 0; k < this.dataGridView2.Columns.Count; k++)
				{
					this.dataGridView2.Columns[k].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					this.dataGridView2.Columns[k].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				for (int l = 0; l < this.dataGridView2.Columns.Count; l++)
				{
					this.dataGridView2.Columns[l].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				if (this.plugList != null)
				{
					int num;
					for (int m = 0; m < this.plugList.Count; m = num)
					{
						this.dataGridView1.AllowUserToAddRows = true;
						this.dataGridView1.Rows.Add(1);
						num = m + 1;
						this.dataGridView1.Rows[m].Cells[0].Value = System.Convert.ToString(num);
						this.dataGridView1.Rows[m].Cells[1].Value = this.plugList[m];
						this.dataGridView1.Rows[m].Cells[2].Value = this.plugPinNumList[m];
						this.dataGridView1.AllowUserToAddRows = false;
					}
				}
			}
			catch (System.Exception arg_240_0)
			{
				this.dataGridView1.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_240_0.StackTrace);
			}
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode == 0)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
			catch (System.Exception arg_263_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_263_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
		}
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 316;
					if (iw <= 0)
					{
						iw = 0;
					}
					this.dataGridView1.Columns[0].Width = 74;
					int width = iw + 130;
					this.dataGridView1.Columns[1].Width = width;
					this.dataGridView1.Columns[2].Width = 90;
					this.dataGridView2.Columns[0].Width = 74;
					this.dataGridView2.Columns[1].Width = width;
					this.dataGridView2.Columns[2].Width = 90;
				}
			}
			catch (System.Exception arg_BC_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_BC_0.StackTrace);
			}
		}
		private void ctFormConverterInterfaceManage_SizeChanged(object sender, System.EventArgs e)
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
			try
			{
				this.plugList.Clear();
				this.plugPinNumList.Clear();
				for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
				{
					if (this.dataGridView1.Rows[i].Cells[1].Value != null)
					{
						string plugNameStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
						string tempStr = "0";
						if (this.dataGridView1.Rows[i].Cells[2].Value != null)
						{
							tempStr = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
						}
						this.plugPinNumList.Add(tempStr);
						this.plugList.Add(plugNameStr);
					}
				}
			}
			catch (System.Exception arg_FE_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_FE_0.StackTrace);
			}
			this.bSubmitFlag = true;
			base.Close();
		}
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dataGridView2.Rows.Count > 0 && this.dataGridView2.SelectedRows.Count > 0)
				{
					string xxStr = this.dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
					string gsStr = this.dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
					bool bExistFlag = false;
					for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
					{
						string tempStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
						string temp2Str = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
						if (xxStr == tempStr && gsStr == temp2Str)
						{
							IL_112:
							MessageBox.Show("接口已添加，请勿重复操作!", "提示", MessageBoxButtons.OK);
							return;
						}
					}
					if (bExistFlag)
					{
						goto IL_112;
					}
					int inum = this.dataGridView1.Rows.Count;
					this.dataGridView1.AllowUserToAddRows = true;
					this.dataGridView1.Rows.Add(1);
					this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(inum + 1);
					this.dataGridView1.Rows[inum].Cells[1].Value = xxStr;
					this.dataGridView1.Rows[inum].Cells[2].Value = gsStr;
					this.dataGridView1.AllowUserToAddRows = false;
				}
				else
				{
					MessageBox.Show("没有选中需要添加的接口!", "提示", MessageBoxButtons.OK);
				}
			}
			catch (System.Exception arg_1F3_0)
			{
				this.dataGridView1.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_1F3_0.StackTrace);
			}
		}
		private void btnDel_Click(object sender, System.EventArgs e)
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
					MessageBox.Show("没有选中需要移除的接口!", "提示", MessageBoxButtons.OK);
				}
			}
			catch (System.Exception arg_C6_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_C6_0.StackTrace);
			}
		}
		private void btnAddAll_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.dataGridView1.Rows.Clear();
				this.dataGridView1.AllowUserToAddRows = true;
				for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
				{
					if (this.dataGridView2.Rows[i].Cells[1].Value != null && this.dataGridView2.Rows[i].Cells[2].Value != null)
					{
						string xxStr = this.dataGridView2.Rows[i].Cells[1].Value.ToString();
						string gsStr = this.dataGridView2.Rows[i].Cells[2].Value.ToString();
						this.dataGridView1.Rows.Add(1);
						this.dataGridView1.Rows[i].Cells[0].Value = System.Convert.ToString(i + 1);
						this.dataGridView1.Rows[i].Cells[1].Value = xxStr;
						this.dataGridView1.Rows[i].Cells[2].Value = gsStr;
					}
				}
				this.dataGridView1.AllowUserToAddRows = false;
			}
			catch (System.Exception arg_17A_0)
			{
				this.dataGridView1.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_17A_0.StackTrace);
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
		public void xhglDealwithFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.dataGridView2.Rows.Clear();
				int inum2 = 0;
				string dbpath = Application.StartupPath + "\\ctsdb.mdb";
				string ifNoStr = this.textBox_InterfaceNo.Text.ToString().Trim();
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand((!string.IsNullOrEmpty(ifNoStr)) ? ("select * from TPlugLibrary where PlugNo like '%" + ifNoStr + "%' order by PlugNo") : "select * from TPlugLibrary order by PlugNo", connection).ExecuteReader();
					this.dataGridView2.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView2.Rows.Add(1);
						int num = inum2 + 1;
						this.dataGridView2.Rows[inum2].Cells[0].Value = System.Convert.ToString(num);
						this.dataGridView2.Rows[inum2].Cells[1].Value = dataReader["PlugNo"].ToString();
						this.dataGridView2.Rows[inum2].Cells[2].Value = dataReader["PinNum"].ToString();
						inum2 = num;
						if (inum2 > 5000)
						{
							break;
						}
					}
					dataReader.Close();
					dataReader = null;
					this.dataGridView2.AllowUserToAddRows = false;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_17C_0)
				{
					this.dataGridView2.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_17C_0.StackTrace);
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
			catch (System.Exception arg_1A0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1A0_0.StackTrace);
			}
		}
		private void textBox_InterfaceNo_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.xhglDealwithFunc();
			}
			catch (System.Exception arg_08_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_08_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormConverterInterfaceManage();
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
