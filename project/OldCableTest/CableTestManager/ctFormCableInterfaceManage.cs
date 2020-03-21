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
	public class ctFormCableInterfaceManage : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public ctFormInterfaceLibrary interfaceLibraryForm;
		public System.Collections.Generic.List<string> plugList;
		public System.Collections.Generic.List<string> plugIDList;
		public System.Collections.Generic.List<string> plugPinNumList;
		public string dbpath;
		public string loginUser;
		public string strEditXsbh;
		public string[] strIDArray;
		public bool bSubmitFlag;
		private Panel panel1;
		private Panel panel2;
		private Panel panel3;
		private TableLayoutPanel tableLayoutPanel1;
		private TextBox textBox_InterfaceNo;
		private Label label2;
		private Button btnAddAll;
		private Button btnDelAll;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column3;
		private DataGridViewTextBoxColumn Column4;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private Label label1;
		private Label label_EditCableBH;
		private Button btnQuit;
		private Button btnSubmit;
		private Button btnAdd;
		private GroupBox groupBox1;
		private DataGridView dataGridView1;
		private GroupBox groupBox_if;
		private DataGridView dataGridView2;
		private Button btnDel;
		private Container components;
		public ctFormCableInterfaceManage(KLineTestProcessor gltProcessor, string lUser, string xsbhStr, System.Collections.Generic.List<string> pIDList)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = lUser;
					this.strEditXsbh = xsbhStr;
					this.strIDArray = new string[5000];
					this.bSubmitFlag = false;
					this.plugList = new System.Collections.Generic.List<string>();
					this.plugIDList = new System.Collections.Generic.List<string>();
					this.plugPinNumList = new System.Collections.Generic.List<string>();
					for (int i = 0; i < pIDList.Count; i++)
					{
						this.plugIDList.Add(pIDList[i]);
					}
				}
				catch (System.Exception arg_95_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_95_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormCableInterfaceManage()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormCableInterfaceManage));
			this.label1 = new Label();
			this.label_EditCableBH = new Label();
			this.btnQuit = new Button();
			this.btnSubmit = new Button();
			this.btnAdd = new Button();
			this.groupBox1 = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.groupBox_if = new GroupBox();
			this.dataGridView2 = new DataGridView();
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			this.btnDel = new Button();
			this.btnAddAll = new Button();
			this.btnDelAll = new Button();
			this.textBox_InterfaceNo = new TextBox();
			this.label2 = new Label();
			this.tableLayoutPanel1 = new TableLayoutPanel();
			this.panel1 = new Panel();
			this.panel2 = new Panel();
			this.panel3 = new Panel();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			this.groupBox_if.SuspendLayout();
			((ISupportInitialize)this.dataGridView2).BeginInit();
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
			System.Drawing.Size size = new System.Drawing.Size(75, 15);
			this.label1.Size = size;
			this.label1.TabIndex = 2;
			this.label1.Text = "线束代号:";
			this.label_EditCableBH.AutoSize = true;
			this.label_EditCableBH.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(94, 14);
			this.label_EditCableBH.Location = location2;
			Padding margin2 = new Padding(2, 0, 2, 0);
			this.label_EditCableBH.Margin = margin2;
			this.label_EditCableBH.Name = "label_EditCableBH";
			System.Drawing.Size size2 = new System.Drawing.Size(39, 15);
			this.label_EditCableBH.Size = size2;
			this.label_EditCableBH.TabIndex = 3;
			this.label_EditCableBH.Text = "L1-1";
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(422, 527);
			this.btnQuit.Location = location3;
			Padding margin3 = new Padding(2, 2, 2, 2);
			this.btnQuit.Margin = margin3;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size3 = new System.Drawing.Size(112, 24);
			this.btnQuit.Size = size3;
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btnSubmit.Anchor = AnchorStyles.Bottom;
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(260, 527);
			this.btnSubmit.Location = location4;
			Padding margin4 = new Padding(2, 2, 2, 2);
			this.btnSubmit.Margin = margin4;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size4 = new System.Drawing.Size(112, 24);
			this.btnSubmit.Size = size4;
			this.btnSubmit.TabIndex = 0;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnAdd.Anchor = AnchorStyles.Left;
			this.btnAdd.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(5, 66);
			this.btnAdd.Location = location5;
			Padding margin5 = new Padding(2, 2, 2, 2);
			this.btnAdd.Margin = margin5;
			this.btnAdd.Name = "btnAdd";
			System.Drawing.Size size5 = new System.Drawing.Size(112, 24);
			this.btnAdd.Size = size5;
			this.btnAdd.TabIndex = 9;
			this.btnAdd.Text = "添加选中接口";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Dock = DockStyle.Fill;
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(2, 50);
			this.groupBox1.Location = location6;
			Padding margin6 = new Padding(2, 2, 2, 2);
			this.groupBox1.Margin = margin6;
			this.groupBox1.Name = "groupBox1";
			Padding padding = new Padding(2, 2, 2, 2);
			this.groupBox1.Padding = padding;
			System.Drawing.Size size6 = new System.Drawing.Size(320, 447);
			this.groupBox1.Size = size6;
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "线束接口列表";
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
				this.Column3,
				this.Column4
			};
			this.dataGridView1.Columns.AddRange(dataGridViewColumns);
			this.dataGridView1.Dock = DockStyle.Fill;
			System.Drawing.Point location7 = new System.Drawing.Point(2, 19);
			this.dataGridView1.Location = location7;
			Padding margin7 = new Padding(2, 2, 2, 2);
			this.dataGridView1.Margin = margin7;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size7 = new System.Drawing.Size(316, 426);
			this.dataGridView1.Size = size7;
			this.dataGridView1.TabIndex = 3;
			this.Column1.HeaderText = "序号";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 72;
			this.Column3.HeaderText = "接口代号";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 160;
			this.Column4.HeaderText = "接点数";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.groupBox_if.Controls.Add(this.dataGridView2);
			this.groupBox_if.Dock = DockStyle.Fill;
			this.groupBox_if.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(454, 50);
			this.groupBox_if.Location = location8;
			Padding margin8 = new Padding(2, 2, 2, 2);
			this.groupBox_if.Margin = margin8;
			this.groupBox_if.Name = "groupBox_if";
			Padding padding2 = new Padding(2, 2, 2, 2);
			this.groupBox_if.Padding = padding2;
			System.Drawing.Size size8 = new System.Drawing.Size(320, 447);
			this.groupBox_if.Size = size8;
			this.groupBox_if.TabIndex = 8;
			this.groupBox_if.TabStop = false;
			this.groupBox_if.Text = "接口列表";
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.AllowUserToResizeColumns = false;
			this.dataGridView2.AllowUserToResizeRows = false;
			System.Drawing.Color window2 = System.Drawing.SystemColors.Window;
			this.dataGridView2.BackgroundColor = window2;
			this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns2 = new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn1,
				this.dataGridViewTextBoxColumn2,
				this.dataGridViewTextBoxColumn3
			};
			this.dataGridView2.Columns.AddRange(dataGridViewColumns2);
			this.dataGridView2.Dock = DockStyle.Fill;
			System.Drawing.Point location9 = new System.Drawing.Point(2, 19);
			this.dataGridView2.Location = location9;
			Padding margin9 = new Padding(2, 2, 2, 2);
			this.dataGridView2.Margin = margin9;
			this.dataGridView2.MultiSelect = false;
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.RowHeadersVisible = false;
			this.dataGridView2.RowTemplate.Height = 27;
			this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size9 = new System.Drawing.Size(316, 426);
			this.dataGridView2.Size = size9;
			this.dataGridView2.TabIndex = 3;
			this.dataGridViewTextBoxColumn1.HeaderText = "序号";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 72;
			this.dataGridViewTextBoxColumn2.HeaderText = "接口代号";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 160;
			this.dataGridViewTextBoxColumn3.HeaderText = "接点数";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.btnDel.Anchor = AnchorStyles.Left;
			this.btnDel.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location10 = new System.Drawing.Point(5, 309);
			this.btnDel.Location = location10;
			Padding margin10 = new Padding(2, 2, 2, 2);
			this.btnDel.Margin = margin10;
			this.btnDel.Name = "btnDel";
			System.Drawing.Size size10 = new System.Drawing.Size(112, 24);
			this.btnDel.Size = size10;
			this.btnDel.TabIndex = 9;
			this.btnDel.Text = "移除选中接口";
			this.btnDel.UseVisualStyleBackColor = true;
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			this.btnAddAll.Anchor = AnchorStyles.Left;
			this.btnAddAll.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location11 = new System.Drawing.Point(5, 118);
			this.btnAddAll.Location = location11;
			Padding margin11 = new Padding(2, 2, 2, 2);
			this.btnAddAll.Margin = margin11;
			this.btnAddAll.Name = "btnAddAll";
			System.Drawing.Size size11 = new System.Drawing.Size(112, 24);
			this.btnAddAll.Size = size11;
			this.btnAddAll.TabIndex = 9;
			this.btnAddAll.Text = "添加所有接口";
			this.btnAddAll.UseVisualStyleBackColor = true;
			this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
			this.btnDelAll.Anchor = AnchorStyles.Left;
			this.btnDelAll.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location12 = new System.Drawing.Point(5, 357);
			this.btnDelAll.Location = location12;
			Padding margin12 = new Padding(2, 2, 2, 2);
			this.btnDelAll.Margin = margin12;
			this.btnDelAll.Name = "btnDelAll";
			System.Drawing.Size size12 = new System.Drawing.Size(112, 24);
			this.btnDelAll.Size = size12;
			this.btnDelAll.TabIndex = 9;
			this.btnDelAll.Text = "移除所有接口";
			this.btnDelAll.UseVisualStyleBackColor = true;
			this.btnDelAll.Click += new System.EventHandler(this.btnDelAll_Click);
			this.textBox_InterfaceNo.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_InterfaceNo.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location13 = new System.Drawing.Point(88, 10);
			this.textBox_InterfaceNo.Location = location13;
			Padding margin13 = new Padding(2, 2, 2, 2);
			this.textBox_InterfaceNo.Margin = margin13;
			this.textBox_InterfaceNo.MaxLength = 120;
			this.textBox_InterfaceNo.Name = "textBox_InterfaceNo";
			System.Drawing.Size size13 = new System.Drawing.Size(224, 24);
			this.textBox_InterfaceNo.Size = size13;
			this.textBox_InterfaceNo.TabIndex = 13;
			this.textBox_InterfaceNo.TextChanged += new System.EventHandler(this.textBox_InterfaceNo_TextChanged);
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location14 = new System.Drawing.Point(12, 14);
			this.label2.Location = location14;
			Padding margin14 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin14;
			this.label2.Name = "label2";
			System.Drawing.Size size14 = new System.Drawing.Size(75, 15);
			this.label2.Size = size14;
			this.label2.TabIndex = 12;
			this.label2.Text = "接口筛选:";
			this.tableLayoutPanel1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 128f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.groupBox_if, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
			System.Drawing.Point location15 = new System.Drawing.Point(9, 10);
			this.tableLayoutPanel1.Location = location15;
			Padding margin15 = new Padding(2, 2, 2, 2);
			this.tableLayoutPanel1.Margin = margin15;
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			System.Drawing.Size size15 = new System.Drawing.Size(776, 499);
			this.tableLayoutPanel1.Size = size15;
			this.tableLayoutPanel1.TabIndex = 14;
			this.panel1.Controls.Add(this.btnAdd);
			this.panel1.Controls.Add(this.btnAddAll);
			this.panel1.Controls.Add(this.btnDel);
			this.panel1.Controls.Add(this.btnDelAll);
			this.panel1.Dock = DockStyle.Fill;
			System.Drawing.Point location16 = new System.Drawing.Point(326, 50);
			this.panel1.Location = location16;
			Padding margin16 = new Padding(2, 2, 2, 2);
			this.panel1.Margin = margin16;
			this.panel1.Name = "panel1";
			System.Drawing.Size size16 = new System.Drawing.Size(124, 447);
			this.panel1.Size = size16;
			this.panel1.TabIndex = 9;
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.label_EditCableBH);
			this.panel2.Dock = DockStyle.Fill;
			System.Drawing.Point location17 = new System.Drawing.Point(2, 2);
			this.panel2.Location = location17;
			Padding margin17 = new Padding(2, 2, 2, 2);
			this.panel2.Margin = margin17;
			this.panel2.Name = "panel2";
			System.Drawing.Size size17 = new System.Drawing.Size(320, 44);
			this.panel2.Size = size17;
			this.panel2.TabIndex = 10;
			this.panel3.Controls.Add(this.textBox_InterfaceNo);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Dock = DockStyle.Fill;
			System.Drawing.Point location18 = new System.Drawing.Point(454, 2);
			this.panel3.Location = location18;
			Padding margin18 = new Padding(2, 2, 2, 2);
			this.panel3.Margin = margin18;
			this.panel3.Name = "panel3";
			System.Drawing.Size size18 = new System.Drawing.Size(320, 44);
			this.panel3.Size = size18;
			this.panel3.TabIndex = 11;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.tableLayoutPanel1);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnSubmit);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin19 = new Padding(2, 2, 2, 2);
			base.Margin = margin19;
			base.Name = "ctFormCableInterfaceManage";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "线束接口管理";
			base.Load += new System.EventHandler(this.ctFormCableInterfaceManage_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormCableInterfaceManage_SizeChanged);
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			this.groupBox_if.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView2).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			base.ResumeLayout(false);
		}
		public void saveOperationRecord(string operContentStr)
		{
			OleDbConnection connection = null;
			System.ValueType dt = System.DateTime.Now;
			try
			{
				connection = new OleDbConnection();
				connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
				connection.Open();
				new OleDbCommand("insert into TOperationRecord(UEID,OperationTime,OperationContent,TestRecordID,Explain) " + "values('" + this.loginUser + "',#" + dt + "#,'" + operContentStr + "','','')", connection).ExecuteNonQuery();
				connection.Close();
				connection = null;
			}
			catch (System.Exception arg_8D_0)
			{
				if (connection != null)
				{
					connection.Close();
				}
				KLineTestProcessor.ExceptionRecordFunc(arg_8D_0.StackTrace);
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
				string plugNumStr = text;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "select * from TLineStructLibrary where LineStructName = '" + this.strEditXsbh + "'";
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						tempStr = dataReader["PlugInfo"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					if (string.IsNullOrEmpty(tempStr))
					{
						this.dataGridView1.AllowUserToAddRows = true;
						for (int i = 0; i < this.plugIDList.Count; i++)
						{
							sqlcommand = "select * from TPlugLibrary where PID = " + this.plugIDList[i];
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							if (dataReader.Read())
							{
								string plugNameStr = dataReader["PlugNo"].ToString();
								plugNumStr = dataReader["PinNum"].ToString();
								this.dataGridView1.Rows.Add(1);
								int num = inum + 1;
								this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
								this.dataGridView1.Rows[inum].Cells[1].Value = plugNameStr;
								this.dataGridView1.Rows[inum].Cells[2].Value = plugNumStr;
								inum = num;
							}
							dataReader.Close();
							dataReader = null;
						}
						this.dataGridView1.AllowUserToAddRows = false;
					}
					else
					{
						this.dataGridView1.AllowUserToAddRows = true;
						string[] plugStrArray = tempStr.Split(new char[]
						{
							','
						});
						for (int j = 0; j < plugStrArray.Length; j++)
						{
							string plugNameStr = plugStrArray[j];
							if (!string.IsNullOrEmpty(plugNameStr))
							{
								sqlcommand = "select * from TPlugLibrary where PlugNo = '" + plugNameStr + "'";
								cmd = new OleDbCommand(sqlcommand, connection);
								dataReader = cmd.ExecuteReader();
								if (dataReader.Read())
								{
									plugNumStr = dataReader["PinNum"].ToString();
								}
								dataReader.Close();
								dataReader = null;
								this.dataGridView1.Rows.Add(1);
								int num = inum + 1;
								this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
								this.dataGridView1.Rows[inum].Cells[1].Value = plugNameStr;
								this.dataGridView1.Rows[inum].Cells[2].Value = plugNumStr;
								inum = num;
							}
						}
						this.dataGridView1.AllowUserToAddRows = false;
					}
					sqlcommand = "select top " + 5000 + " * from TPlugLibrary order by PlugNo";
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
				catch (System.Exception arg_438_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					this.dataGridView2.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_438_0.StackTrace);
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
			catch (System.Exception arg_45C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_45C_0.StackTrace);
			}
		}
		private void ctFormCableInterfaceManage_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.label_EditCableBH.Text = this.strEditXsbh;
				this.bSubmitFlag = false;
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
			}
			catch (System.Exception arg_132_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_132_0.StackTrace);
			}
			this.RefreshDataGridView();
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode == 0)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
			catch (System.Exception arg_15A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_15A_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
		}
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 322;
					if (iw <= 0)
					{
						iw = 0;
					}
					this.dataGridView1.Columns[0].Width = 68;
					int width = iw + 140;
					this.dataGridView1.Columns[1].Width = width;
					this.dataGridView1.Columns[2].Width = 90;
					this.dataGridView2.Columns[0].Width = 68;
					this.dataGridView2.Columns[1].Width = width;
					this.dataGridView2.Columns[2].Width = 90;
				}
			}
			catch (System.Exception arg_BC_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_BC_0.StackTrace);
			}
		}
		private void ctFormCableInterfaceManage_SizeChanged(object sender, System.EventArgs e)
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
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			this.bSubmitFlag = false;
			base.Close();
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			OleDbConnection connection2 = null;
			if (this.dataGridView1.Rows.Count > 0 || DialogResult.OK == MessageBox.Show("未添加任何接口，您确定要提交吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
			{
				bool bSameFlag = false;
				string text = "";
				string plug1Str = text;
				string plug2Str = text;
				System.Collections.Generic.List<string[]> tempList = new System.Collections.Generic.List<string[]>();
				this.plugList.Clear();
				this.plugIDList.Clear();
				this.plugPinNumList.Clear();
				try
				{
					try
					{
						connection = new OleDbConnection();
						connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
						connection.Open();
						for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
						{
							string tempStr = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
							string temp2Str = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
							int iTemp = System.Convert.ToInt32(temp2Str);
							if (iTemp > 0)
							{
								string[] tempArray = new string[iTemp];
								this.plugList.Add(tempStr);
								this.plugPinNumList.Add(temp2Str);
								string tempIDStr = "";
								try
								{
									string sqlcommand = "select * from TPlugLibrary where PlugNo = '" + tempStr + "' and PinNum=" + iTemp;
									OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
									dataReader = cmd.ExecuteReader();
									if (dataReader.Read())
									{
										tempIDStr = dataReader["PID"].ToString();
									}
									dataReader.Close();
									dataReader = null;
								}
								catch (System.Exception arg_18C_0)
								{
									KLineTestProcessor.ExceptionRecordFunc(arg_18C_0.StackTrace);
									if (dataReader != null)
									{
										dataReader.Close();
										dataReader = null;
									}
								}
								this.plugIDList.Add(tempIDStr);
								try
								{
									int iIndex = 0;
									string sqlcommand = "select * from TPlugLibraryDetail where PID='" + tempIDStr + "' order by PDID";
									OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
									dataReader = cmd.ExecuteReader();
									while (dataReader.Read())
									{
										tempArray[iIndex] = dataReader["DevicePinNum"].ToString();
										iIndex++;
										if (iIndex >= tempArray.Length)
										{
											break;
										}
									}
									dataReader.Close();
									dataReader = null;
									tempList.Add(tempArray);
								}
								catch (System.Exception arg_21C_0)
								{
									KLineTestProcessor.ExceptionRecordFunc(arg_21C_0.StackTrace);
									if (dataReader != null)
									{
										dataReader.Close();
										dataReader = null;
									}
								}
							}
						}
						connection.Close();
						connection = null;
					}
					catch (System.Exception arg_248_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_248_0.StackTrace);
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
					for (int jj = 0; jj < tempList.Count; jj++)
					{
						for (int kk = 0; kk < tempList.Count; kk++)
						{
							if (kk != jj)
							{
								for (int ii = 0; ii < tempList[jj].Length; ii++)
								{
									for (int ijk = 0; ijk < tempList[kk].Length; ijk++)
									{
										if (tempList[jj][ii] == tempList[kk][ijk])
										{
											plug1Str = this.plugList[jj];
											plug2Str = this.plugList[kk];
											bSameFlag = true;
											goto IL_3A6;
										}
										char[] separator = new char[]
										{
											','
										};
										string[] arg_345_0 = tempList[jj][ii].Split(separator);
										char[] separator2 = new char[]
										{
											','
										};
										string[] tempPin2Array = tempList[kk][ijk].Split(separator2);
										if (arg_345_0[0] == tempPin2Array[0])
										{
											plug1Str = this.plugList[jj];
											plug2Str = this.plugList[kk];
											bSameFlag = true;
											goto IL_3A6;
										}
									}
									if (bSameFlag)
									{
										goto IL_3A6;
									}
								}
								if (bSameFlag)
								{
									goto IL_3A6;
								}
							}
						}
						if (bSameFlag)
						{
							break;
						}
					}
					IL_3A6:;
				}
				catch (System.Exception arg_3A8_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_3A8_0.StackTrace);
				}
				if (bSameFlag)
				{
					MessageBox.Show("接口" + plug1Str + "与" + plug2Str + "定义了相同的测试仪针脚!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					string plugTempStr = "";
					int j = 0;
					if (0 < this.plugList.Count)
					{
						do
						{
							if (j == 0)
							{
								plugTempStr += this.plugList[0];
							}
							else
							{
								plugTempStr += "," + this.plugList[j];
							}
							j++;
						}
						while (j < this.plugList.Count);
					}
					try
					{
						connection2 = new OleDbConnection();
						connection2.ConnectionString = this.gLineTestProcessor.dbPathStr;
						connection2.Open();
						new OleDbCommand("update TLineStructLibrary set PlugInfo = '" + plugTempStr + "' where LineStructName= '" + this.strEditXsbh + "'", connection2).ExecuteNonQuery();
						connection2.Close();
						connection2 = null;
					}
					catch (System.Exception arg_4BD_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_4BD_0.StackTrace);
						if (connection2 != null)
						{
							connection2.Close();
						}
					}
					this.bSubmitFlag = true;
					base.Close();
				}
			}
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
						if (inum2 > 200)
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
				catch (System.Exception arg_16B_0)
				{
					this.dataGridView2.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_16B_0.StackTrace);
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
			catch (System.Exception arg_18F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_18F_0.StackTrace);
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
					this.~ctFormCableInterfaceManage();
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
