using Aspose.Cells;
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
	public class ctFormInterfaceLibrary : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public ctFormAddInterface addInterfaceForm;
		public ctFormEditInterface editInterfaceForm;
		public System.Collections.Generic.List<int> dpNumList;
		public string[] strIDArray;
		public string[] strPinFWArray;
		public int iPlugCount;
		public string dbpath;
		public string loginUser;
		public string usedLineStr;
		public string exportPathStr;
		private CheckBox checkBox_jkdh;
		private CheckBox checkBox_jdgs;
		private CheckBox checkBox_ljqxh;
		private GroupBox groupBox2;
		private TextBox textBox_ljqxh;
		private TextBox textBox_jdgs;
		private Button btnIFilter;
		public int iLastZJTPin;
		private Button btnExport;
		private FolderBrowserDialog folderBrowserDialog1;
		private GroupBox groupBox1;
		private DataGridView dataGridView1;
		private Button btnAddInterface;
		private Button btnUpdateInterface;
		private Button btnDelInterface;
		private Button btnQuit;
		private TextBox textBox_jkdh;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column3;
		private DataGridViewTextBoxColumn Column4;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn Column6;
		private DataGridViewTextBoxColumn Column5;
		private Container components;
		public ctFormInterfaceLibrary(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
					this.usedLineStr = "";
					this.exportPathStr = "";
					this.iPlugCount = 0;
					this.dpNumList = new System.Collections.Generic.List<int>();
					this.strIDArray = new string[5000];
					this.strPinFWArray = new string[5000];
					for (int i = 0; i < 5000; i++)
					{
						this.strIDArray[i] = "";
						this.strPinFWArray[i] = "";
					}
				}
				catch (System.Exception arg_A8_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_A8_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormInterfaceLibrary()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormInterfaceLibrary));
			this.groupBox1 = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column6 = new DataGridViewTextBoxColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.btnAddInterface = new Button();
			this.btnUpdateInterface = new Button();
			this.btnDelInterface = new Button();
			this.btnQuit = new Button();
			this.textBox_jkdh = new TextBox();
			this.btnExport = new Button();
			this.folderBrowserDialog1 = new FolderBrowserDialog();
			this.checkBox_jkdh = new CheckBox();
			this.checkBox_jdgs = new CheckBox();
			this.checkBox_ljqxh = new CheckBox();
			this.groupBox2 = new GroupBox();
			this.btnIFilter = new Button();
			this.textBox_ljqxh = new TextBox();
			this.textBox_jdgs = new TextBox();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(14, 78);
			this.groupBox1.Location = location;
			Padding margin = new Padding(2);
			this.groupBox1.Margin = margin;
			this.groupBox1.Name = "groupBox1";
			Padding padding = new Padding(2);
			this.groupBox1.Padding = padding;
			System.Drawing.Size size = new System.Drawing.Size(991, 540);
			this.groupBox1.Size = size;
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "接口列表";
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
				this.Column4,
				this.Column2,
				this.Column6,
				this.Column5
			};
			this.dataGridView1.Columns.AddRange(dataGridViewColumns);
			this.dataGridView1.Dock = DockStyle.Fill;
			System.Drawing.Point location2 = new System.Drawing.Point(2, 19);
			this.dataGridView1.Location = location2;
			Padding margin2 = new Padding(2);
			this.dataGridView1.Margin = margin2;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size2 = new System.Drawing.Size(987, 519);
			this.dataGridView1.Size = size2;
			this.dataGridView1.TabIndex = 3;
			this.dataGridView1.MouseDoubleClick += new MouseEventHandler(this.dataGridView1_MouseDoubleClick);
			this.Column1.HeaderText = "序号";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 72;
			this.Column3.HeaderText = "接口代号";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 180;
			this.Column4.HeaderText = "接点个数";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Width = 120;
			this.Column2.HeaderText = "针脚范围";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 120;
			this.Column6.HeaderText = "备注";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column6.Width = 110;
			this.Column5.HeaderText = "连接器型号";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Width = 150;
			this.btnAddInterface.Anchor = AnchorStyles.Bottom;
			this.btnAddInterface.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(273, 639);
			this.btnAddInterface.Location = location3;
			Padding margin3 = new Padding(2);
			this.btnAddInterface.Margin = margin3;
			this.btnAddInterface.Name = "btnAddInterface";
			System.Drawing.Size size3 = new System.Drawing.Size(100, 27);
			this.btnAddInterface.Size = size3;
			this.btnAddInterface.TabIndex = 0;
			this.btnAddInterface.Text = "添加";
			this.btnAddInterface.UseVisualStyleBackColor = true;
			this.btnAddInterface.Click += new System.EventHandler(this.btnAddInterface_Click);
			this.btnUpdateInterface.Anchor = AnchorStyles.Bottom;
			this.btnUpdateInterface.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(397, 639);
			this.btnUpdateInterface.Location = location4;
			Padding margin4 = new Padding(2);
			this.btnUpdateInterface.Margin = margin4;
			this.btnUpdateInterface.Name = "btnUpdateInterface";
			System.Drawing.Size size4 = new System.Drawing.Size(100, 27);
			this.btnUpdateInterface.Size = size4;
			this.btnUpdateInterface.TabIndex = 1;
			this.btnUpdateInterface.Text = "编辑";
			this.btnUpdateInterface.UseVisualStyleBackColor = true;
			this.btnUpdateInterface.Click += new System.EventHandler(this.btnUpdateInterface_Click);
			this.btnDelInterface.Anchor = AnchorStyles.Bottom;
			this.btnDelInterface.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(521, 639);
			this.btnDelInterface.Location = location5;
			Padding margin5 = new Padding(2);
			this.btnDelInterface.Margin = margin5;
			this.btnDelInterface.Name = "btnDelInterface";
			System.Drawing.Size size5 = new System.Drawing.Size(100, 27);
			this.btnDelInterface.Size = size5;
			this.btnDelInterface.TabIndex = 2;
			this.btnDelInterface.Text = "删除";
			this.btnDelInterface.UseVisualStyleBackColor = true;
			this.btnDelInterface.Click += new System.EventHandler(this.btnDelInterface_Click);
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(645, 639);
			this.btnQuit.Location = location6;
			Padding margin6 = new Padding(2);
			this.btnQuit.Margin = margin6;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size6 = new System.Drawing.Size(100, 27);
			this.btnQuit.Size = size6;
			this.btnQuit.TabIndex = 3;
			this.btnQuit.Text = "关闭";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.textBox_jkdh.Anchor = AnchorStyles.Top;
			this.textBox_jkdh.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(113, 23);
			this.textBox_jkdh.Location = location7;
			Padding margin7 = new Padding(2);
			this.textBox_jkdh.Margin = margin7;
			this.textBox_jkdh.MaxLength = 120;
			this.textBox_jkdh.Name = "textBox_jkdh";
			System.Drawing.Size size7 = new System.Drawing.Size(154, 24);
			this.textBox_jkdh.Size = size7;
			this.textBox_jkdh.TabIndex = 4;
			this.btnExport.Anchor = AnchorStyles.Bottom;
			this.btnExport.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(134, 639);
			this.btnExport.Location = location8;
			Padding margin8 = new Padding(2);
			this.btnExport.Margin = margin8;
			this.btnExport.Name = "btnExport";
			System.Drawing.Size size8 = new System.Drawing.Size(100, 27);
			this.btnExport.Size = size8;
			this.btnExport.TabIndex = 4;
			this.btnExport.Text = "导出接口";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Visible = false;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			this.checkBox_jkdh.Anchor = AnchorStyles.Top;
			this.checkBox_jkdh.AutoSize = true;
			this.checkBox_jkdh.Font = new System.Drawing.Font("宋体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(26, 26);
			this.checkBox_jkdh.Location = location9;
			this.checkBox_jkdh.Name = "checkBox_jkdh";
			System.Drawing.Size size9 = new System.Drawing.Size(82, 18);
			this.checkBox_jkdh.Size = size9;
			this.checkBox_jkdh.TabIndex = 17;
			this.checkBox_jkdh.Text = "接口代号";
			this.checkBox_jkdh.UseVisualStyleBackColor = true;
			this.checkBox_jdgs.Anchor = AnchorStyles.Top;
			this.checkBox_jdgs.AutoSize = true;
			this.checkBox_jdgs.Font = new System.Drawing.Font("宋体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location10 = new System.Drawing.Point(301, 26);
			this.checkBox_jdgs.Location = location10;
			this.checkBox_jdgs.Name = "checkBox_jdgs";
			System.Drawing.Size size10 = new System.Drawing.Size(82, 18);
			this.checkBox_jdgs.Size = size10;
			this.checkBox_jdgs.TabIndex = 18;
			this.checkBox_jdgs.Text = "接点个数";
			this.checkBox_jdgs.UseVisualStyleBackColor = true;
			this.checkBox_ljqxh.Anchor = AnchorStyles.Top;
			this.checkBox_ljqxh.AutoSize = true;
			this.checkBox_ljqxh.Font = new System.Drawing.Font("宋体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location11 = new System.Drawing.Point(576, 26);
			this.checkBox_ljqxh.Location = location11;
			this.checkBox_ljqxh.Name = "checkBox_ljqxh";
			System.Drawing.Size size11 = new System.Drawing.Size(96, 18);
			this.checkBox_ljqxh.Size = size11;
			this.checkBox_ljqxh.TabIndex = 19;
			this.checkBox_ljqxh.Text = "连接器型号";
			this.checkBox_ljqxh.UseVisualStyleBackColor = true;
			this.groupBox2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox2.Controls.Add(this.btnIFilter);
			this.groupBox2.Controls.Add(this.textBox_ljqxh);
			this.groupBox2.Controls.Add(this.textBox_jdgs);
			this.groupBox2.Controls.Add(this.checkBox_jkdh);
			this.groupBox2.Controls.Add(this.checkBox_ljqxh);
			this.groupBox2.Controls.Add(this.checkBox_jdgs);
			this.groupBox2.Controls.Add(this.textBox_jkdh);
			this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location12 = new System.Drawing.Point(14, 10);
			this.groupBox2.Location = location12;
			this.groupBox2.Name = "groupBox2";
			System.Drawing.Size size12 = new System.Drawing.Size(991, 60);
			this.groupBox2.Size = size12;
			this.groupBox2.TabIndex = 20;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "筛选条件";
			this.btnIFilter.Anchor = AnchorStyles.Bottom;
			this.btnIFilter.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location13 = new System.Drawing.Point(864, 22);
			this.btnIFilter.Location = location13;
			Padding margin9 = new Padding(2);
			this.btnIFilter.Margin = margin9;
			this.btnIFilter.Name = "btnIFilter";
			System.Drawing.Size size13 = new System.Drawing.Size(100, 27);
			this.btnIFilter.Size = size13;
			this.btnIFilter.TabIndex = 22;
			this.btnIFilter.Text = "筛选";
			this.btnIFilter.UseVisualStyleBackColor = true;
			this.btnIFilter.Click += new System.EventHandler(this.btnIFilter_Click);
			this.textBox_ljqxh.Anchor = AnchorStyles.Top;
			this.textBox_ljqxh.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location14 = new System.Drawing.Point(678, 23);
			this.textBox_ljqxh.Location = location14;
			Padding margin10 = new Padding(2);
			this.textBox_ljqxh.Margin = margin10;
			this.textBox_ljqxh.MaxLength = 120;
			this.textBox_ljqxh.Name = "textBox_ljqxh";
			System.Drawing.Size size14 = new System.Drawing.Size(154, 24);
			this.textBox_ljqxh.Size = size14;
			this.textBox_ljqxh.TabIndex = 21;
			this.textBox_jdgs.Anchor = AnchorStyles.Top;
			this.textBox_jdgs.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location15 = new System.Drawing.Point(389, 23);
			this.textBox_jdgs.Location = location15;
			Padding margin11 = new Padding(2);
			this.textBox_jdgs.Margin = margin11;
			this.textBox_jdgs.MaxLength = 120;
			this.textBox_jdgs.Name = "textBox_jdgs";
			System.Drawing.Size size15 = new System.Drawing.Size(154, 24);
			this.textBox_jdgs.Size = size15;
			this.textBox_jdgs.TabIndex = 20;
			this.textBox_jdgs.KeyPress += new KeyPressEventHandler(this.textBox_jdgs_KeyPress);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(1018, 691);
			base.ClientSize = clientSize;
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnDelInterface);
			base.Controls.Add(this.btnUpdateInterface);
			base.Controls.Add(this.btnExport);
			base.Controls.Add(this.btnAddInterface);
			base.Controls.Add(this.groupBox1);
			this.DoubleBuffered = true;
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin12 = new Padding(2);
			base.Margin = margin12;
			base.Name = "ctFormInterfaceLibrary";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "接口库管理";
			base.Load += new System.EventHandler(this.ctFormInterfaceLibrary_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormInterfaceLibrary_SizeChanged);
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
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
		private void ctFormInterfaceLibrary_Load(object sender, System.EventArgs e)
		{
			try
			{
				try
				{
					this.iLastZJTPin = 0;
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
				catch (System.Exception arg_95_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_95_0.StackTrace);
				}
				this.RefreshDataGridView();
				for (int k = 0; k < this.dataGridView1.Rows.Count; k++)
				{
					this.dataGridView1.Rows[k].Selected = false;
				}
				this.SetDGVWidthSizeFunc();
			}
			catch (System.Exception arg_E1_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_E1_0.StackTrace);
			}
		}
		public void xhglDealwithFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.dataGridView1.Rows.Clear();
				int inum = 0;
				bool bExistFlag = false;
				string jkdhStr = this.textBox_jkdh.Text.ToString().Trim();
				string jdgsStr = this.textBox_jdgs.Text.ToString().Trim();
				string ljqxhStr = this.textBox_ljqxh.Text.ToString().Trim();
				int ijdgs = 0;
				try
				{
					if (this.checkBox_jdgs.Checked && !string.IsNullOrEmpty(jdgsStr))
					{
						ijdgs = System.Convert.ToInt32(jdgsStr);
					}
				}
				catch (System.Exception ex_89)
				{
				}
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "select * from TPlugLibrary";
					if (this.checkBox_jkdh.Checked && !string.IsNullOrEmpty(jkdhStr))
					{
						sqlcommand += " where PlugNo like '%" + jkdhStr + "%' ";
						bExistFlag = true;
					}
					if (this.checkBox_jdgs.Checked && ijdgs != 0)
					{
						if (bExistFlag)
						{
							sqlcommand += " and PinNum=" + ijdgs;
						}
						else
						{
							sqlcommand += " where PinNum=" + ijdgs;
							bExistFlag = true;
						}
					}
					if (this.checkBox_ljqxh.Checked && !string.IsNullOrEmpty(ljqxhStr))
					{
						if (bExistFlag)
						{
							sqlcommand += " and ConnectorName like '%" + ljqxhStr + "%'";
						}
						else
						{
							sqlcommand += " where ConnectorName like '%" + ljqxhStr + "%'";
							bExistFlag = true;
						}
					}
					sqlcommand += " order by PlugNo";
					dataReader = new OleDbCommand(sqlcommand, connection).ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView1.Rows.Add(1);
						int num = inum + 1;
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
						this.strIDArray[inum] = dataReader["PID"].ToString();
						this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["PlugNo"].ToString();
						this.dataGridView1.Rows[inum].Cells[2].Value = dataReader["PinNum"].ToString();
						this.dataGridView1.Rows[inum].Cells[4].Value = dataReader["Remark"].ToString();
						string tempStr = dataReader["ConnectorName"].ToString();
						if (string.IsNullOrEmpty(tempStr))
						{
							this.dataGridView1.Rows[inum].Cells[5].Value = "--";
						}
						else
						{
							this.dataGridView1.Rows[inum].Cells[5].Value = tempStr;
						}
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
				catch (System.Exception arg_347_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
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
				this.QueryJKPinFWFunc();
				for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
				{
					this.dataGridView1.Rows[i].Selected = false;
				}
			}
			catch (System.Exception arg_3A8_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3A8_0.StackTrace);
			}
		}
		public void QueryJKPinFWFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.iPlugCount = this.dataGridView1.Rows.Count;
				this.dpNumList.Clear();
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					for (int i = 0; i < this.iPlugCount; i++)
					{
						try
						{
							this.strPinFWArray[i] = "";
							this.dpNumList.Clear();
							dataReader = new OleDbCommand("select * from TPlugLibraryDetail where PID = '" + this.strIDArray[i] + "' order by PDID", connection).ExecuteReader();
							while (dataReader.Read())
							{
								try
								{
									string tempStr = dataReader["DevicePinNum"].ToString();
									string[] tempArray = tempStr.Split(new char[]
									{
										','
									});
									int iTemp = System.Convert.ToInt32(tempArray[0]);
									this.dpNumList.Add(iTemp);
									if (tempArray.Length >= 2)
									{
										iTemp = System.Convert.ToInt32(tempArray[1]);
										this.dpNumList.Add(iTemp);
									}
								}
								catch (System.Exception ex_10A)
								{
								}
							}
							dataReader.Close();
							dataReader = null;
						}
						catch (System.Exception arg_11D_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_11D_0.StackTrace);
							if (dataReader != null)
							{
								dataReader.Close();
								dataReader = null;
							}
						}
						this.dpNumList.Sort();
						if (this.dpNumList.Count > 0)
						{
							this.strPinFWArray[i] = System.Convert.ToString(this.dpNumList[0]) + "~" + System.Convert.ToString(this.dpNumList[this.dpNumList.Count - 1]);
						}
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_1A5_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_1A5_0.StackTrace);
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
				for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
				{
					this.dataGridView1.Rows[j].Cells[3].Value = this.strPinFWArray[j];
				}
			}
			catch (System.Exception arg_20D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_20D_0.StackTrace);
			}
		}
		private void btnAddInterface_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormAddInterface sender2 = new ctFormAddInterface(this.gLineTestProcessor, this.loginUser, this.iLastZJTPin);
				this.addInterfaceForm = sender2;
				sender2.Activate();
				this.addInterfaceForm.ShowDialog();
				ctFormAddInterface this2 = this.addInterfaceForm;
				if (this2.bAddSuccFlag)
				{
					this.iLastZJTPin = this2.iLastZJTPin;
					this.RefreshDataGridView();
				}
			}
			catch (System.Exception arg_54_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_54_0.StackTrace);
			}
		}
		public void QueryUpdateInterfaceInfoFunc(int iIndex, int iEditPid)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				string text = "";
				string tempFWStr = text;
				this.dpNumList.Clear();
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					try
					{
						string sqlcommand = "select top 1 * from TPlugLibrary where PID=" + iEditPid;
						OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						if (dataReader.Read())
						{
							this.dataGridView1.Rows[iIndex].Cells[2].Value = dataReader["PinNum"].ToString();
							this.dataGridView1.Rows[iIndex].Cells[4].Value = dataReader["Remark"].ToString();
							string tempStr = dataReader["ConnectorName"].ToString();
							if (string.IsNullOrEmpty(tempStr))
							{
								this.dataGridView1.Rows[iIndex].Cells[5].Value = "--";
							}
							else
							{
								this.dataGridView1.Rows[iIndex].Cells[5].Value = tempStr;
							}
						}
						dataReader.Close();
						dataReader = null;
					}
					catch (System.Exception ex_13B)
					{
						if (dataReader != null)
						{
							dataReader.Close();
							dataReader = null;
						}
					}
					try
					{
						string sqlcommand = "select * from TPlugLibraryDetail where PID = '" + System.Convert.ToString(iEditPid) + "'";
						OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						while (dataReader.Read())
						{
							int iTemp = System.Convert.ToInt32(dataReader["DevicePinNum"].ToString());
							this.dpNumList.Add(iTemp);
						}
						dataReader.Close();
						dataReader = null;
					}
					catch (System.Exception ex_1B0)
					{
						if (dataReader != null)
						{
							dataReader.Close();
							dataReader = null;
						}
					}
					this.dpNumList.Sort();
					if (this.dpNumList.Count > 0)
					{
						tempFWStr = System.Convert.ToString(this.dpNumList[0]) + "~" + System.Convert.ToString(this.dpNumList[this.dpNumList.Count - 1]);
					}
					this.dataGridView1.Rows[iIndex].Cells[3].Value = tempFWStr;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_247_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_247_0.StackTrace);
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
			catch (System.Exception arg_26B_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_26B_0.StackTrace);
			}
		}
		private void btnUpdateInterface_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.Rows.Count > 0)
				{
					int e2 = System.Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString()) - 1;
					int iPid = System.Convert.ToInt32(this.strIDArray[e2]);
					ctFormEditInterface this2 = new ctFormEditInterface(this.gLineTestProcessor, this.loginUser, iPid);
					this.editInterfaceForm = this2;
					this2.Activate();
					this.editInterfaceForm.ShowDialog();
					this.QueryUpdateInterfaceInfoFunc(e2, iPid);
				}
			}
			catch (System.Exception arg_9D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_9D_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool PlugUsedQueryFunc(string queryPlugStr)
		{
			OleDbConnection connection = null;
			bool bExistFlag = false;
			try
			{
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					OleDbDataReader dataReader = new OleDbCommand("select LineStructName,PlugInfo from TLineStructLibrary order by PlugInfo", connection).ExecuteReader();
					while (dataReader.Read())
					{
						this.usedLineStr = dataReader["LineStructName"].ToString();
						string[] strArray = dataReader["PlugInfo"].ToString().Split(new char[]
						{
							','
						});
						for (int i = 0; i < strArray.Length; i++)
						{
							if (!string.IsNullOrEmpty(strArray[i]))
							{
								if (queryPlugStr == strArray[i])
								{
									bExistFlag = true;
									break;
								}
							}
						}
					}
					dataReader.Close();
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_B9_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_B9_0.StackTrace);
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
			}
			catch (System.Exception arg_D2_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_D2_0.StackTrace);
			}
			return bExistFlag;
		}
		private void btnDelInterface_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			try
			{
				if (this.dataGridView1.SelectedRows.Count <= 0 || this.dataGridView1.Rows.Count <= 0)
				{
					return;
				}
				string JKStr = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
				if (this.PlugUsedQueryFunc(JKStr))
				{
					MessageBox.Show("接口已被线束 " + this.usedLineStr + " 调用,删除失败!", "提示", MessageBoxButtons.OK);
					return;
				}
				if (DialogResult.Cancel == MessageBox.Show("您确认要删除该接口吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
				{
					return;
				}
				int num = System.Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString()) - 1;
				int iID = System.Convert.ToInt32(this.strIDArray[num]);
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "delete from TPlugLibrary where PID=" + iID;
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					cmd.ExecuteNonQuery();
					System.Threading.Thread.Sleep(10);
					sqlcommand = "delete from TPlugLibraryDetail where PID ='" + this.strIDArray[num] + "'";
					cmd = new OleDbCommand(sqlcommand, connection);
					cmd.ExecuteNonQuery();
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_15D_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_15D_0.StackTrace);
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
			}
			catch (System.Exception arg_178_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_178_0.StackTrace);
			}
			this.RefreshDataGridView();
		}
		public void RefreshDataGridView()
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
					dataReader = new OleDbCommand("select * from TPlugLibrary order by PID", connection).ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView1.Rows.Add(1);
						int num = inum + 1;
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
						this.strIDArray[inum] = dataReader["PID"].ToString();
						this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["PlugNo"].ToString();
						this.dataGridView1.Rows[inum].Cells[2].Value = dataReader["PinNum"].ToString();
						this.dataGridView1.Rows[inum].Cells[4].Value = dataReader["Remark"].ToString();
						string tempStr = dataReader["ConnectorName"].ToString();
						if (string.IsNullOrEmpty(tempStr))
						{
							this.dataGridView1.Rows[inum].Cells[5].Value = "--";
						}
						else
						{
							this.dataGridView1.Rows[inum].Cells[5].Value = tempStr;
						}
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
				catch (System.Exception arg_1EC_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_1EC_0.StackTrace);
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
				this.QueryJKPinFWFunc();
				for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
				{
					this.dataGridView1.Rows[i].Selected = false;
				}
			}
			catch (System.Exception arg_248_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_248_0.StackTrace);
			}
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			base.Close();
		}
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 764;
					int ia = 0;
					if (iw > 0)
					{
						ia = iw / 2;
					}
					this.dataGridView1.Columns[0].Width = 80;
					this.dataGridView1.Columns[1].Width = ia + 150;
					this.dataGridView1.Columns[2].Width = 120;
					this.dataGridView1.Columns[3].Width = 120;
					this.dataGridView1.Columns[4].Width = ia + 120;
					this.dataGridView1.Columns[5].Width = 150;
				}
			}
			catch (System.Exception arg_C4_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_C4_0.StackTrace);
			}
		}
		private void ctFormInterfaceLibrary_SizeChanged(object sender, System.EventArgs e)
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
		private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			try
			{
				this.btnUpdateInterface_Click(null, null);
			}
			catch (System.Exception arg_0A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_0A_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool SaveToExcelFileFunc(string xlsxFile, string csvFile, string plugStr, string bzStr)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			bool bSuccFlag = true;
			try
			{
				if (string.IsNullOrEmpty(xlsxFile) || string.IsNullOrEmpty(csvFile))
				{
					return false;
				}
				Workbook wb = new Workbook();
				Cells cells = wb.Worksheets[0].Cells;
				Style st = wb.Styles[wb.Styles.Add()];
				st.HorizontalAlignment = TextAlignmentType.Center;
				st.VerticalAlignment = TextAlignmentType.Center;
				st.Font.Name = "宋体";
				st.Font.Size = 11;
				int iCol = 1;
				this.putValue(cells, "接口代号", 0, 1, st);
				this.putValue(cells, plugStr, 0, 2, st);
				this.putValue(cells, "备注", 1, 1, st);
				this.putValue(cells, bzStr, 1, 2, st);
				this.putValue(cells, "接口代号", 2, 1, st);
				this.putValue(cells, "测试仪针脚号", 2, 2, st);
				int iRow = 3;
				try
				{
					string text = "";
					string pidStr = text;
					try
					{
						connection = new OleDbConnection();
						connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
						connection.Open();
						string sqlcommand = "select * from TPlugLibrary where PlugNo='" + plugStr + "'";
						OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						while (dataReader.Read())
						{
							pidStr = dataReader["PID"].ToString();
						}
						dataReader.Close();
						dataReader = null;
						if (!string.IsNullOrEmpty(pidStr))
						{
							sqlcommand = "select * from TPlugLibraryDetail where PID='" + pidStr + "'";
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							while (dataReader.Read())
							{
								string temp1Str = dataReader["PinName"].ToString();
								string temp2Str = dataReader["DevicePinNum"].ToString();
								this.putValue(cells, temp1Str, iRow, iCol, st);
								this.putValue(cells, temp2Str, iRow, iCol + 1, st);
								iRow++;
							}
							dataReader.Close();
							dataReader = null;
						}
						connection.Close();
						connection = null;
					}
					catch (System.Exception arg_1F4_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_1F4_0.StackTrace);
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
				catch (System.Exception arg_218_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_218_0.StackTrace);
				}
				wb.Save(xlsxFile, SaveFormat.Xlsx);
				wb = null;
			}
			catch (System.Exception arg_237_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_237_0.StackTrace);
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
				if (this.dataGridView1.Rows.Count > 0)
				{
					if (this.dataGridView1.SelectedRows.Count <= 0)
					{
						MessageBox.Show("没有选择需要导出的接口!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						string plugStr = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
						string bzStr = "";
						if (this.dataGridView1.SelectedRows[0].Cells[1].Value != null)
						{
							bzStr = this.dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
						}
						string orfn = Application.StartupPath;
						FolderBrowserDialog e2 = new FolderBrowserDialog();
						this.folderBrowserDialog1 = e2;
						e2.Description = "目录选择";
						if (!string.IsNullOrEmpty(this.exportPathStr))
						{
							this.folderBrowserDialog1.SelectedPath = this.exportPathStr;
						}
						if (DialogResult.OK == this.folderBrowserDialog1.ShowDialog())
						{
							orfn = this.folderBrowserDialog1.SelectedPath;
							string xlsxFn = orfn + "\\" + plugStr + ".xlsx";
							string csvFn = orfn + "\\" + plugStr + ".csv";
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
			}
			catch (System.Exception arg_181_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_181_0.StackTrace);
			}
		}
		private void btnIFilter_Click(object sender, System.EventArgs e)
		{
			try
			{
				string jkdhStr = this.textBox_jkdh.Text.ToString().Trim();
				string jdgsStr = this.textBox_jdgs.Text.ToString().Trim();
				string ljqxhStr = this.textBox_ljqxh.Text.ToString().Trim();
				if ((!this.checkBox_jkdh.Checked && !this.checkBox_jdgs.Checked && !this.checkBox_ljqxh.Checked) || (string.IsNullOrEmpty(jkdhStr) && string.IsNullOrEmpty(jdgsStr) && string.IsNullOrEmpty(ljqxhStr)))
				{
					MessageBox.Show("未设置筛选条件!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					this.xhglDealwithFunc();
				}
			}
			catch (System.Exception arg_9C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_9C_0.StackTrace);
			}
		}
		private void textBox_jdgs_KeyPress(object sender, KeyPressEventArgs e)
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
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormInterfaceLibrary();
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
