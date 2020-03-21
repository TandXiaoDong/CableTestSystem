using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormInterfaceModelConnectorManage : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public bool bSubmitFlag;
		public string loginUser;
		public string currConnectorNameStr;
		private Button btnQuit;
		private Button btnSubmit;
		private GroupBox groupBox1;
		private DataGridView dataGridView1;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column3;
		private DataGridViewTextBoxColumn Column4;
		private Label label1;
		private TextBox textBox_name;
		private Container components;
		public ctFormInterfaceModelConnectorManage(KLineTestProcessor gltProcessor, string lUser, string cConnNameStr)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = lUser;
					this.currConnectorNameStr = cConnNameStr;
				}
				catch (System.Exception ex_23)
				{
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormInterfaceModelConnectorManage()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormInterfaceModelConnectorManage));
			this.btnQuit = new Button();
			this.btnSubmit = new Button();
			this.groupBox1 = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.label1 = new Label();
			this.textBox_name = new TextBox();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
			this.btnQuit.Anchor = AnchorStyles.Right;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(631, 383);
			this.btnQuit.Location = location;
			Padding margin = new Padding(2, 2, 2, 2);
			this.btnQuit.Margin = margin;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size = new System.Drawing.Size(112, 24);
			this.btnQuit.Size = size;
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btnSubmit.Anchor = AnchorStyles.Right;
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(631, 209);
			this.btnSubmit.Location = location2;
			Padding margin2 = new Padding(2, 2, 2, 2);
			this.btnSubmit.Margin = margin2;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size2 = new System.Drawing.Size(112, 24);
			this.btnSubmit.Size = size2;
			this.btnSubmit.TabIndex = 0;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(23, 55);
			this.groupBox1.Location = location3;
			Padding margin3 = new Padding(2, 2, 2, 2);
			this.groupBox1.Margin = margin3;
			this.groupBox1.Name = "groupBox1";
			Padding padding = new Padding(2, 2, 2, 2);
			this.groupBox1.Padding = padding;
			System.Drawing.Size size3 = new System.Drawing.Size(558, 499);
			this.groupBox1.Size = size3;
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "连接器列表";
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
			System.Drawing.Point location4 = new System.Drawing.Point(2, 19);
			this.dataGridView1.Location = location4;
			Padding margin4 = new Padding(2, 2, 2, 2);
			this.dataGridView1.Margin = margin4;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size4 = new System.Drawing.Size(554, 478);
			this.dataGridView1.Size = size4;
			this.dataGridView1.TabIndex = 3;
			this.dataGridView1.MouseClick += new MouseEventHandler(this.dataGridView1_MouseClick);
			this.Column1.HeaderText = "序号";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 72;
			this.Column3.HeaderText = "连接器型号";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 160;
			this.Column4.HeaderText = "针点数";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(30, 20);
			this.label1.Location = location5;
			Padding margin5 = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin5;
			this.label1.Name = "label1";
			System.Drawing.Size size5 = new System.Drawing.Size(150, 15);
			this.label1.Size = size5;
			this.label1.TabIndex = 15;
			this.label1.Text = "当前选择连接器型号:";
			this.textBox_name.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_name.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(188, 16);
			this.textBox_name.Location = location6;
			Padding margin6 = new Padding(2, 2, 2, 2);
			this.textBox_name.Margin = margin6;
			this.textBox_name.Name = "textBox_name";
			this.textBox_name.ReadOnly = true;
			System.Drawing.Size size6 = new System.Drawing.Size(392, 24);
			this.textBox_name.Size = size6;
			this.textBox_name.TabIndex = 2;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.textBox_name);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnSubmit);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin7 = new Padding(2, 2, 2, 2);
			base.Margin = margin7;
			base.Name = "ctFormInterfaceModelConnectorManage";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "被调用连接器选择";
			base.Load += new System.EventHandler(this.ctFormInterfaceModelConnectorManage_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormInterfaceModelConnectorManage_SizeChanged);
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public void saveOperationRecord(string operContentStr)
		{
			OleDbConnection connection = null;
			System.ValueType dt = System.DateTime.Now;
			Application.StartupPath + "\\ctsdb.mdb";
			try
			{
				connection = new OleDbConnection();
				connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
				connection.Open();
				new OleDbCommand("insert into TOperationRecord(UEID,OperationTime,OperationContent,TestRecordID,Explain) " + "values('" + this.loginUser + "',#" + dt + "#,'" + operContentStr + "','','')", connection).ExecuteNonQuery();
				connection.Close();
				connection = null;
			}
			catch (System.Exception arg_9D_0)
			{
				if (connection != null)
				{
					connection.Close();
				}
				KLineTestProcessor.ExceptionRecordFunc(arg_9D_0.StackTrace);
			}
		}
		public void RefreshDataGridView()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.dataGridView1.Rows.Clear();
				int inum = 0;
				string dbpath = Application.StartupPath + "\\ctsdb.mdb";
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select * from TConnectorLibrary order by ConnectorName", connection).ExecuteReader();
					while (dataReader.Read())
					{
						string temp1Str = dataReader["ConnectorName"].ToString();
						string temp2Str = dataReader["PinNum"].ToString();
						this.dataGridView1.AllowUserToAddRows = true;
						this.dataGridView1.Rows.Add(1);
						int num = inum + 1;
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
						this.dataGridView1.Rows[inum].Cells[1].Value = temp1Str;
						this.dataGridView1.Rows[inum].Cells[2].Value = temp2Str;
						this.dataGridView1.AllowUserToAddRows = false;
						inum = num;
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_144_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_144_0.StackTrace);
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
			catch (System.Exception arg_168_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_168_0.StackTrace);
			}
		}
		private void ctFormInterfaceModelConnectorManage_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.bSubmitFlag = false;
				this.textBox_name.Text = this.currConnectorNameStr;
				this.RefreshDataGridView();
				for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
				{
					this.dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					this.dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
				{
					this.dataGridView1.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				this.dataGridView1.ClearSelection();
			}
			catch (System.Exception arg_B7_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_B7_0.StackTrace);
			}
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode == 0)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
			catch (System.Exception arg_DA_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_DA_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
		}
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 356;
					if (iw < 0)
					{
						iw = 0;
					}
					this.dataGridView1.Columns[0].Width = 72;
					this.dataGridView1.Columns[1].Width = iw + 160;
					this.dataGridView1.Columns[2].Width = 100;
				}
			}
			catch (System.Exception arg_70_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_70_0.StackTrace);
			}
		}
		private void ctFormInterfaceModelConnectorManage_SizeChanged(object sender, System.EventArgs e)
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
			this.currConnectorNameStr = this.textBox_name.Text.ToString().Trim();
			this.bSubmitFlag = true;
			base.Close();
		}
		private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.Rows.Count > 0)
				{
					if (this.dataGridView1.SelectedRows[0].Cells[1].Value != null)
					{
						this.textBox_name.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
					}
				}
			}
			catch (System.Exception arg_7E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_7E_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormInterfaceModelConnectorManage();
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
