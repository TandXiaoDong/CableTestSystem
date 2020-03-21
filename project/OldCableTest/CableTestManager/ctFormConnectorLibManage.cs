using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormConnectorLibManage : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public ctFormAddConnector addConnectorForm;
		public ctFormEditConnector editConnectorForm;
		public string dbpath;
		public string usedPlugStr;
		public string loginUser;
		public string[] strIDArray;
		private ComboBox comboBox_sxtj;
		private Button btnQuit;
		private Button btnDel;
		private Button btnUpdate;
		private Button btnAdd;
		private GroupBox groupBox1;
		private DataGridView dataGridView1;
		private TextBox textBox_Connector;
		private Label label2;
		private DataGridViewTextBoxColumn Column_XH;
		private DataGridViewTextBoxColumn Column_LJQXH;
		private DataGridViewTextBoxColumn Column_ZJXH;
		private DataGridViewTextBoxColumn Column_ZDS;
		private DataGridViewTextBoxColumn Column_BZ;
		private Container components;
		public ctFormConnectorLibManage(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
					this.strIDArray = new string[5000];
				}
				catch (System.Exception arg_46_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_46_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormConnectorLibManage()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormConnectorLibManage));
			this.btnQuit = new Button();
			this.btnDel = new Button();
			this.btnUpdate = new Button();
			this.btnAdd = new Button();
			this.groupBox1 = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.Column_XH = new DataGridViewTextBoxColumn();
			this.Column_LJQXH = new DataGridViewTextBoxColumn();
			this.Column_ZJXH = new DataGridViewTextBoxColumn();
			this.Column_ZDS = new DataGridViewTextBoxColumn();
			this.Column_BZ = new DataGridViewTextBoxColumn();
			this.textBox_Connector = new TextBox();
			this.label2 = new Label();
			this.comboBox_sxtj = new ComboBox();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(548, 522);
			this.btnQuit.Location = location;
			Padding margin = new Padding(2);
			this.btnQuit.Margin = margin;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size = new System.Drawing.Size(90, 24);
			this.btnQuit.Size = size;
			this.btnQuit.TabIndex = 3;
			this.btnQuit.Text = "关闭";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btnDel.Anchor = AnchorStyles.Bottom;
			this.btnDel.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(418, 522);
			this.btnDel.Location = location2;
			Padding margin2 = new Padding(2);
			this.btnDel.Margin = margin2;
			this.btnDel.Name = "btnDel";
			System.Drawing.Size size2 = new System.Drawing.Size(90, 24);
			this.btnDel.Size = size2;
			this.btnDel.TabIndex = 2;
			this.btnDel.Text = "删除";
			this.btnDel.UseVisualStyleBackColor = true;
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			this.btnUpdate.Anchor = AnchorStyles.Bottom;
			this.btnUpdate.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(287, 522);
			this.btnUpdate.Location = location3;
			Padding margin3 = new Padding(2);
			this.btnUpdate.Margin = margin3;
			this.btnUpdate.Name = "btnUpdate";
			System.Drawing.Size size3 = new System.Drawing.Size(90, 24);
			this.btnUpdate.Size = size3;
			this.btnUpdate.TabIndex = 1;
			this.btnUpdate.Text = "编辑";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnAdd.Anchor = AnchorStyles.Bottom;
			this.btnAdd.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(157, 522);
			this.btnAdd.Location = location4;
			Padding margin4 = new Padding(2);
			this.btnAdd.Margin = margin4;
			this.btnAdd.Name = "btnAdd";
			System.Drawing.Size size4 = new System.Drawing.Size(90, 24);
			this.btnAdd.Size = size4;
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "添加";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(14, 60);
			this.groupBox1.Location = location5;
			Padding margin5 = new Padding(2);
			this.groupBox1.Margin = margin5;
			this.groupBox1.Name = "groupBox1";
			Padding padding = new Padding(2);
			this.groupBox1.Padding = padding;
			System.Drawing.Size size5 = new System.Drawing.Size(767, 440);
			this.groupBox1.Size = size5;
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "连接器型号列表";
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			System.Drawing.Color window = System.Drawing.SystemColors.Window;
			this.dataGridView1.BackgroundColor = window;
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[]
			{
				this.Column_XH,
				this.Column_LJQXH,
				this.Column_ZJXH,
				this.Column_ZDS,
				this.Column_BZ
			};
			this.dataGridView1.Columns.AddRange(dataGridViewColumns);
			this.dataGridView1.Dock = DockStyle.Fill;
			System.Drawing.Point location6 = new System.Drawing.Point(2, 19);
			this.dataGridView1.Location = location6;
			Padding margin6 = new Padding(2);
			this.dataGridView1.Margin = margin6;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size6 = new System.Drawing.Size(763, 419);
			this.dataGridView1.Size = size6;
			this.dataGridView1.TabIndex = 2;
			this.dataGridView1.MouseDoubleClick += new MouseEventHandler(this.dataGridView1_MouseDoubleClick);
			this.Column_XH.HeaderText = "序号";
			this.Column_XH.Name = "Column_XH";
			this.Column_XH.ReadOnly = true;
			this.Column_XH.Width = 76;
			this.Column_LJQXH.HeaderText = "连接器型号";
			this.Column_LJQXH.Name = "Column_LJQXH";
			this.Column_LJQXH.ReadOnly = true;
			this.Column_LJQXH.Width = 150;
			this.Column_ZJXH.HeaderText = "转接型号";
			this.Column_ZJXH.Name = "Column_ZJXH";
			this.Column_ZJXH.ReadOnly = true;
			this.Column_ZJXH.Width = 150;
			this.Column_ZDS.HeaderText = "针点数";
			this.Column_ZDS.Name = "Column_ZDS";
			this.Column_ZDS.ReadOnly = true;
			this.Column_ZDS.Width = 110;
			this.Column_BZ.HeaderText = "备注";
			this.Column_BZ.Name = "Column_BZ";
			this.Column_BZ.ReadOnly = true;
			this.textBox_Connector.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_Connector.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(266, 19);
			this.textBox_Connector.Location = location7;
			Padding margin7 = new Padding(2);
			this.textBox_Connector.Margin = margin7;
			this.textBox_Connector.Name = "textBox_Connector";
			System.Drawing.Size size7 = new System.Drawing.Size(480, 24);
			this.textBox_Connector.Size = size7;
			this.textBox_Connector.TabIndex = 5;
			this.textBox_Connector.TextChanged += new System.EventHandler(this.textBox_Connector_TextChanged);
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(32, 24);
			this.label2.Location = location8;
			Padding margin8 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin8;
			this.label2.Name = "label2";
			System.Drawing.Size size8 = new System.Drawing.Size(75, 15);
			this.label2.Size = size8;
			this.label2.TabIndex = 4;
			this.label2.Text = "筛选条件:";
			this.comboBox_sxtj.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_sxtj.Font = new System.Drawing.Font("宋体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.comboBox_sxtj.FormattingEnabled = true;
			object[] items = new object[]
			{
				"连接器型号",
				"转接型号",
				"针点数"
			};
			this.comboBox_sxtj.Items.AddRange(items);
			System.Drawing.Point location9 = new System.Drawing.Point(115, 20);
			this.comboBox_sxtj.Location = location9;
			this.comboBox_sxtj.Name = "comboBox_sxtj";
			System.Drawing.Size size9 = new System.Drawing.Size(140, 22);
			this.comboBox_sxtj.Size = size9;
			this.comboBox_sxtj.TabIndex = 15;
			this.comboBox_sxtj.SelectedIndexChanged += new System.EventHandler(this.comboBox_sxtj_SelectedIndexChanged);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.comboBox_sxtj);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnDel);
			base.Controls.Add(this.btnUpdate);
			base.Controls.Add(this.btnAdd);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.textBox_Connector);
			base.Controls.Add(this.label2);
			this.DoubleBuffered = true;
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin9 = new Padding(2);
			base.Margin = margin9;
			base.Name = "ctFormConnectorLibManage";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "连接器库管理";
			base.Load += new System.EventHandler(this.ctFormConnectorLibManage_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormConnectorLibManage_SizeChanged);
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
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
				int inum = 0;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select * from TConnectorLibrary order by ID", connection).ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView1.Rows.Add(1);
						int num = inum + 1;
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
						this.strIDArray[inum] = dataReader["ID"].ToString();
						this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["ConnectorName"].ToString();
						this.dataGridView1.Rows[inum].Cells[2].Value = dataReader["ConverterType"].ToString();
						this.dataGridView1.Rows[inum].Cells[3].Value = dataReader["PinNum"].ToString();
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
				catch (System.Exception arg_1AD_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_1AD_0.StackTrace);
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
			catch (System.Exception arg_1D1_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1D1_0.StackTrace);
			}
		}
		private void ctFormConnectorLibManage_Load(object sender, System.EventArgs e)
		{
			try
			{
				try
				{
					this.comboBox_sxtj.SelectedIndex = 0;
					this.textBox_Connector.Text = "";
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
				catch (System.Exception arg_AA_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_AA_0.StackTrace);
				}
				this.RefreshDataGridView();
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
				catch (System.Exception arg_105_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_105_0.StackTrace);
				}
				this.SetDGVWidthSizeFunc();
			}
			catch (System.Exception arg_119_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_119_0.StackTrace);
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
					int iw = this.dataGridView1.Width - 610;
					int ia = 0;
					this.Column_ZJXH.Visible = this.gLineTestProcessor.bUseRelayBoard;
					if (this.gLineTestProcessor.bUseRelayBoard)
					{
						if (iw > 0)
						{
							ia = iw / 3;
						}
						this.dataGridView1.Columns[0].Width = 78;
						int width = ia + 150;
						this.dataGridView1.Columns[1].Width = width;
						this.dataGridView1.Columns[2].Width = width;
						this.dataGridView1.Columns[3].Width = 110;
						this.dataGridView1.Columns[4].Width = ia + 100;
					}
					else
					{
						if (iw > 0)
						{
							ia = iw / 2;
						}
						this.dataGridView1.Columns[0].Width = 78;
						this.dataGridView1.Columns[1].Width = ia + 300;
						this.dataGridView1.Columns[3].Width = 110;
						this.dataGridView1.Columns[4].Width = ia + 100;
					}
				}
			}
			catch (System.Exception arg_141_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_141_0.StackTrace);
			}
		}
		private void ctFormConnectorLibManage_SizeChanged(object sender, System.EventArgs e)
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
		public void GLDealwithFunc()
		{
			OleDbConnection connection = null;
			string sqlcommand = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.dataGridView1.Rows.Clear();
				int inum = 0;
				string cNameStr = this.textBox_Connector.Text.ToString().Trim();
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					if (this.comboBox_sxtj.SelectedIndex == 0)
					{
						if (string.IsNullOrEmpty(cNameStr))
						{
							sqlcommand = "select * from TConnectorLibrary order by ConnectorName";
						}
						else
						{
							sqlcommand = "select * from TConnectorLibrary where ConnectorName like '%" + cNameStr + "%' order by ConnectorName";
						}
					}
					else if (this.comboBox_sxtj.SelectedIndex == 1)
					{
						if (string.IsNullOrEmpty(cNameStr))
						{
							sqlcommand = "select * from TConnectorLibrary order by ConverterType";
						}
						else
						{
							sqlcommand = "select * from TConnectorLibrary where ConverterType like '%" + cNameStr + "%' order by ConverterType";
						}
					}
					else if (this.comboBox_sxtj.SelectedIndex == 2)
					{
						if (string.IsNullOrEmpty(cNameStr))
						{
							sqlcommand = "select * from TConnectorLibrary order by PinNum";
						}
						else
						{
							sqlcommand = "select * from TConnectorLibrary where PinNum='" + cNameStr + "'";
						}
					}
					dataReader = new OleDbCommand(sqlcommand, connection).ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView1.Rows.Add(1);
						int num = inum + 1;
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
						this.strIDArray[inum] = dataReader["ID"].ToString();
						this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["ConnectorName"].ToString();
						this.dataGridView1.Rows[inum].Cells[2].Value = dataReader["ConverterType"].ToString();
						this.dataGridView1.Rows[inum].Cells[3].Value = dataReader["PinNum"].ToString();
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
				catch (System.Exception arg_26D_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_26D_0.StackTrace);
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
			catch (System.Exception arg_291_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_291_0.StackTrace);
			}
		}
		private void textBox_Connector_TextChanged(object sender, System.EventArgs e)
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
		private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			try
			{
				this.btnUpdate_Click(null, null);
			}
			catch (System.Exception arg_0A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_0A_0.StackTrace);
			}
		}
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormAddConnector this2 = new ctFormAddConnector(this.gLineTestProcessor, this.loginUser);
				this.addConnectorForm = this2;
				this2.Activate();
				this.addConnectorForm.ShowDialog();
				if (this.addConnectorForm.bAddSuccFlag)
				{
					this.RefreshDataGridView();
				}
			}
			catch (System.Exception arg_40_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_40_0.StackTrace);
			}
		}
		public void QueryUpdateConnectorInfoFunc(int iIndex, int iEditPid)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select top 1 * from TConnectorLibrary where ID=" + iEditPid, connection).ExecuteReader();
					if (dataReader.Read())
					{
						this.dataGridView1.Rows[iIndex].Cells[2].Value = dataReader["ConverterType"].ToString();
						this.dataGridView1.Rows[iIndex].Cells[3].Value = dataReader["PinNum"].ToString();
						this.dataGridView1.Rows[iIndex].Cells[4].Value = dataReader["Remark"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_ED_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_ED_0.StackTrace);
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
			catch (System.Exception arg_111_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_111_0.StackTrace);
			}
		}
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.Rows.Count > 0)
				{
					int e2 = System.Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString()) - 1;
					int iPid = System.Convert.ToInt32(this.strIDArray[e2]);
					string xsbhStr = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
					ctFormEditConnector this2 = new ctFormEditConnector(this.gLineTestProcessor, this.loginUser, iPid, xsbhStr);
					this.editConnectorForm = this2;
					this2.Activate();
					this.editConnectorForm.ShowDialog();
					this.QueryUpdateConnectorInfoFunc(e2, iPid);
				}
			}
			catch (System.Exception arg_C8_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_C8_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool CableUsedQueryFunc(string queryStr)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			bool bExistFlag = false;
			try
			{
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select * from TPlugLibrary where ConnectorName='" + queryStr + "'", connection).ExecuteReader();
					if (dataReader.Read())
					{
						this.usedPlugStr = dataReader["PlugNo"].ToString();
						bExistFlag = true;
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_76_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_76_0.StackTrace);
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
			catch (System.Exception arg_9A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_9A_0.StackTrace);
			}
			return bExistFlag;
		}
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			try
			{
				if (this.dataGridView1.SelectedRows.Count <= 0)
				{
					return;
				}
				if (DialogResult.Cancel == MessageBox.Show("您确认要删除该连接器吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
				{
					return;
				}
				if (this.dataGridView1.SelectedRows[0].Cells[1].Value != null)
				{
					string JKStr = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
					if (this.CableUsedQueryFunc(JKStr))
					{
						MessageBox.Show("连接器型号已被接口 " + this.usedPlugStr + " 调用，无法删除!", "提示", MessageBoxButtons.OK);
						return;
					}
				}
				int num = System.Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString()) - 1;
				int iID = System.Convert.ToInt32(this.strIDArray[num]);
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "delete from TConnectorLibrary where ID =" + iID;
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					cmd.ExecuteNonQuery();
					System.Threading.Thread.Sleep(100);
					sqlcommand = "delete from TConnectorLibraryDetail where CLID='" + this.strIDArray[num] + "'";
					cmd = new OleDbCommand(sqlcommand, connection);
					cmd.ExecuteNonQuery();
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_16C_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_16C_0.StackTrace);
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
			}
			catch (System.Exception arg_185_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_185_0.StackTrace);
			}
			this.RefreshDataGridView();
		}
		private void comboBox_sxtj_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.textBox_Connector.Text = "";
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormConnectorLibManage();
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
