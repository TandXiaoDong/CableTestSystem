using Aspose.Cells;
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
	public class ctFormCableLibrary : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public ctFormAddCable addCableForm;
		public ctFormEditCable editCableForm;
		public string oldbcCableStr;
		public string loginUser;
		public string tempStr;
		public string exportPathStr;
		public string usedProjectStr;
		public string[] strIDArray;
		public string[] strTempArray;
		public string[] strPlugArray;
		private GroupBox groupBox2;
		private Button btnIFilter;
		private TextBox textBox_jkxx;
		private TextBox textBox_xxsl;
		private CheckBox checkBox_xsdh;
		private CheckBox checkBox_jkxx;
		private CheckBox checkBox_xxsl;
		private TextBox textBox_xsdh;
		public bool bChangedFlag;
		private FolderBrowserDialog folderBrowserDialog1;
		private Button btnExport;
		private Button btnQuit;
		private Button btnDelCable;
		private Button btnUpdateCable;
		private Button btnAddCable;
		private GroupBox groupBox1;
		private DataGridView dataGridView1;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn Column6;
		private DataGridViewTextBoxColumn Column3;
		private DataGridViewTextBoxColumn Column4;
		private DataGridViewTextBoxColumn Column5;
		private Container components;
		public ctFormCableLibrary(KLineTestProcessor gltProcessor, string obcCableStr)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
					this.oldbcCableStr = obcCableStr;
					this.bChangedFlag = false;
					this.strIDArray = new string[5000];
					this.strPlugArray = new string[5000];
				}
				catch (System.Exception arg_4F_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_4F_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		public ctFormCableLibrary(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
					this.bChangedFlag = false;
					this.strIDArray = new string[5000];
					this.strPlugArray = new string[5000];
				}
				catch (System.Exception arg_48_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_48_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormCableLibrary()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormCableLibrary));
			this.btnQuit = new Button();
			this.btnDelCable = new Button();
			this.btnUpdateCable = new Button();
			this.btnAddCable = new Button();
			this.groupBox1 = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column6 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.folderBrowserDialog1 = new FolderBrowserDialog();
			this.btnExport = new Button();
			this.groupBox2 = new GroupBox();
			this.btnIFilter = new Button();
			this.textBox_jkxx = new TextBox();
			this.textBox_xxsl = new TextBox();
			this.checkBox_xsdh = new CheckBox();
			this.checkBox_jkxx = new CheckBox();
			this.checkBox_xxsl = new CheckBox();
			this.textBox_xsdh = new TextBox();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(654, 639);
			this.btnQuit.Location = location;
			Padding margin = new Padding(2);
			this.btnQuit.Margin = margin;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size = new System.Drawing.Size(100, 27);
			this.btnQuit.Size = size;
			this.btnQuit.TabIndex = 3;
			this.btnQuit.Text = "关闭";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnDelCable.Anchor = AnchorStyles.Bottom;
			this.btnDelCable.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(524, 639);
			this.btnDelCable.Location = location2;
			Padding margin2 = new Padding(2);
			this.btnDelCable.Margin = margin2;
			this.btnDelCable.Name = "btnDelCable";
			System.Drawing.Size size2 = new System.Drawing.Size(100, 27);
			this.btnDelCable.Size = size2;
			this.btnDelCable.TabIndex = 2;
			this.btnDelCable.Text = "删除";
			this.btnDelCable.UseVisualStyleBackColor = true;
			this.btnDelCable.Click += new System.EventHandler(this.btnDelCable_Click);
			this.btnUpdateCable.Anchor = AnchorStyles.Bottom;
			this.btnUpdateCable.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(394, 639);
			this.btnUpdateCable.Location = location3;
			Padding margin3 = new Padding(2);
			this.btnUpdateCable.Margin = margin3;
			this.btnUpdateCable.Name = "btnUpdateCable";
			System.Drawing.Size size3 = new System.Drawing.Size(100, 27);
			this.btnUpdateCable.Size = size3;
			this.btnUpdateCable.TabIndex = 1;
			this.btnUpdateCable.Text = "编辑";
			this.btnUpdateCable.UseVisualStyleBackColor = true;
			this.btnUpdateCable.Click += new System.EventHandler(this.btnUpdateCable_Click);
			this.btnAddCable.Anchor = AnchorStyles.Bottom;
			this.btnAddCable.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(264, 639);
			this.btnAddCable.Location = location4;
			Padding margin4 = new Padding(2);
			this.btnAddCable.Margin = margin4;
			this.btnAddCable.Name = "btnAddCable";
			System.Drawing.Size size4 = new System.Drawing.Size(100, 27);
			this.btnAddCable.Size = size4;
			this.btnAddCable.TabIndex = 0;
			this.btnAddCable.Text = "添加";
			this.btnAddCable.UseVisualStyleBackColor = true;
			this.btnAddCable.Click += new System.EventHandler(this.btnAddCable_Click);
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(14, 78);
			this.groupBox1.Location = location5;
			Padding margin5 = new Padding(2);
			this.groupBox1.Margin = margin5;
			this.groupBox1.Name = "groupBox1";
			Padding padding = new Padding(2);
			this.groupBox1.Padding = padding;
			System.Drawing.Size size5 = new System.Drawing.Size(991, 540);
			this.groupBox1.Size = size5;
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "线束列表";
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
				this.Column6,
				this.Column3,
				this.Column4,
				this.Column5
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
			System.Drawing.Size size6 = new System.Drawing.Size(987, 519);
			this.dataGridView1.Size = size6;
			this.dataGridView1.TabIndex = 2;
			this.dataGridView1.MouseDoubleClick += new MouseEventHandler(this.dataGridView1_MouseDoubleClick);
			this.Column1.HeaderText = "序号";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 74;
			this.Column2.HeaderText = "线束代号";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 150;
			this.Column6.HeaderText = "接口数量";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column6.Width = 110;
			this.Column3.HeaderText = "接口信息";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 150;
			this.Column4.HeaderText = "芯线数量";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Width = 110;
			this.Column5.HeaderText = "备注";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.btnExport.Anchor = AnchorStyles.Bottom;
			this.btnExport.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(82, 639);
			this.btnExport.Location = location7;
			Padding margin7 = new Padding(2);
			this.btnExport.Margin = margin7;
			this.btnExport.Name = "btnExport";
			System.Drawing.Size size7 = new System.Drawing.Size(152, 27);
			this.btnExport.Size = size7;
			this.btnExport.TabIndex = 7;
			this.btnExport.Text = "导出连接关系";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Visible = false;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			this.groupBox2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox2.Controls.Add(this.btnIFilter);
			this.groupBox2.Controls.Add(this.textBox_jkxx);
			this.groupBox2.Controls.Add(this.textBox_xxsl);
			this.groupBox2.Controls.Add(this.checkBox_xsdh);
			this.groupBox2.Controls.Add(this.checkBox_jkxx);
			this.groupBox2.Controls.Add(this.checkBox_xxsl);
			this.groupBox2.Controls.Add(this.textBox_xsdh);
			this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(14, 10);
			this.groupBox2.Location = location8;
			this.groupBox2.Name = "groupBox2";
			System.Drawing.Size size8 = new System.Drawing.Size(991, 60);
			this.groupBox2.Size = size8;
			this.groupBox2.TabIndex = 21;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "筛选条件";
			this.btnIFilter.Anchor = AnchorStyles.Bottom;
			this.btnIFilter.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(864, 22);
			this.btnIFilter.Location = location9;
			Padding margin8 = new Padding(2);
			this.btnIFilter.Margin = margin8;
			this.btnIFilter.Name = "btnIFilter";
			System.Drawing.Size size9 = new System.Drawing.Size(100, 27);
			this.btnIFilter.Size = size9;
			this.btnIFilter.TabIndex = 22;
			this.btnIFilter.Text = "筛选";
			this.btnIFilter.UseVisualStyleBackColor = true;
			this.btnIFilter.Click += new System.EventHandler(this.btnIFilter_Click);
			this.textBox_jkxx.Anchor = AnchorStyles.Top;
			this.textBox_jkxx.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location10 = new System.Drawing.Point(389, 23);
			this.textBox_jkxx.Location = location10;
			Padding margin9 = new Padding(2);
			this.textBox_jkxx.Margin = margin9;
			this.textBox_jkxx.MaxLength = 120;
			this.textBox_jkxx.Name = "textBox_jkxx";
			System.Drawing.Size size10 = new System.Drawing.Size(154, 24);
			this.textBox_jkxx.Size = size10;
			this.textBox_jkxx.TabIndex = 21;
			this.textBox_xxsl.Anchor = AnchorStyles.Top;
			this.textBox_xxsl.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location11 = new System.Drawing.Point(663, 23);
			this.textBox_xxsl.Location = location11;
			Padding margin10 = new Padding(2);
			this.textBox_xxsl.Margin = margin10;
			this.textBox_xxsl.MaxLength = 120;
			this.textBox_xxsl.Name = "textBox_xxsl";
			System.Drawing.Size size11 = new System.Drawing.Size(154, 24);
			this.textBox_xxsl.Size = size11;
			this.textBox_xxsl.TabIndex = 20;
			this.textBox_xxsl.KeyPress += new KeyPressEventHandler(this.textBox_xxsl_KeyPress);
			this.checkBox_xsdh.Anchor = AnchorStyles.Top;
			this.checkBox_xsdh.AutoSize = true;
			this.checkBox_xsdh.Font = new System.Drawing.Font("宋体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location12 = new System.Drawing.Point(26, 26);
			this.checkBox_xsdh.Location = location12;
			this.checkBox_xsdh.Name = "checkBox_xsdh";
			System.Drawing.Size size12 = new System.Drawing.Size(82, 18);
			this.checkBox_xsdh.Size = size12;
			this.checkBox_xsdh.TabIndex = 17;
			this.checkBox_xsdh.Text = "线束代号";
			this.checkBox_xsdh.UseVisualStyleBackColor = true;
			this.checkBox_jkxx.Anchor = AnchorStyles.Top;
			this.checkBox_jkxx.AutoSize = true;
			this.checkBox_jkxx.Font = new System.Drawing.Font("宋体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location13 = new System.Drawing.Point(301, 26);
			this.checkBox_jkxx.Location = location13;
			this.checkBox_jkxx.Name = "checkBox_jkxx";
			System.Drawing.Size size13 = new System.Drawing.Size(82, 18);
			this.checkBox_jkxx.Size = size13;
			this.checkBox_jkxx.TabIndex = 19;
			this.checkBox_jkxx.Text = "接口信息";
			this.checkBox_jkxx.UseVisualStyleBackColor = true;
			this.checkBox_xxsl.Anchor = AnchorStyles.Top;
			this.checkBox_xxsl.AutoSize = true;
			this.checkBox_xxsl.Font = new System.Drawing.Font("宋体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location14 = new System.Drawing.Point(576, 26);
			this.checkBox_xxsl.Location = location14;
			this.checkBox_xxsl.Name = "checkBox_xxsl";
			System.Drawing.Size size14 = new System.Drawing.Size(82, 18);
			this.checkBox_xxsl.Size = size14;
			this.checkBox_xxsl.TabIndex = 18;
			this.checkBox_xxsl.Text = "芯线数量";
			this.checkBox_xxsl.UseVisualStyleBackColor = true;
			this.textBox_xsdh.Anchor = AnchorStyles.Top;
			this.textBox_xsdh.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location15 = new System.Drawing.Point(113, 23);
			this.textBox_xsdh.Location = location15;
			Padding margin11 = new Padding(2);
			this.textBox_xsdh.Margin = margin11;
			this.textBox_xsdh.MaxLength = 120;
			this.textBox_xsdh.Name = "textBox_xsdh";
			System.Drawing.Size size15 = new System.Drawing.Size(154, 24);
			this.textBox_xsdh.Size = size15;
			this.textBox_xsdh.TabIndex = 4;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(1018, 691);
			base.ClientSize = clientSize;
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.btnExport);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnDelCable);
			base.Controls.Add(this.btnUpdateCable);
			base.Controls.Add(this.btnAddCable);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin12 = new Padding(2);
			base.Margin = margin12;
			base.Name = "ctFormCableLibrary";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "线束库管理";
			base.Load += new System.EventHandler(this.ctFormCableLibrary_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormCableLibrary_SizeChanged);
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
		private void btnAddCable_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormAddCable this2 = new ctFormAddCable(this.gLineTestProcessor, this.loginUser);
				this.addCableForm = this2;
				this2.Activate();
				this.addCableForm.ShowDialog();
				if (this.addCableForm.bAddSuccFlag)
				{
					this.RefreshDataGridView();
				}
			}
			catch (System.Exception arg_40_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_40_0.StackTrace);
			}
		}
		public void QueryUpdateCableInfoFunc(int iIndex, int iEditPid)
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
					dataReader = new OleDbCommand("select top 1 * from TLineStructLibrary where LID=" + iEditPid, connection).ExecuteReader();
					if (dataReader.Read())
					{
						this.dataGridView1.Rows[iIndex].Cells[1].Value = dataReader["LineStructName"].ToString();
						this.strPlugArray[iIndex] = dataReader["PlugInfo"].ToString();
						this.dataGridView1.Rows[iIndex].Cells[3].Value = this.strPlugArray[iIndex];
						int iIFCount = 0;
						if (string.IsNullOrEmpty(this.strPlugArray[iIndex]))
						{
							this.dataGridView1.Rows[iIndex].Cells[2].Value = "0";
						}
						else if (-1 == this.strPlugArray[iIndex].Trim().LastIndexOf(','))
						{
							this.dataGridView1.Rows[iIndex].Cells[2].Value = "1";
						}
						else
						{
							char[] separator = new char[]
							{
								','
							};
							this.strTempArray = this.strPlugArray[iIndex].Trim().Split(separator);
							int i = 0;
							while (true)
							{
								string[] array = this.strTempArray;
								if (i >= array.Length)
								{
									break;
								}
								if (!string.IsNullOrEmpty(array[i]))
								{
									iIFCount++;
								}
								i++;
							}
							this.dataGridView1.Rows[iIndex].Cells[2].Value = System.Convert.ToString(iIFCount);
						}
						this.dataGridView1.Rows[iIndex].Cells[4].Value = dataReader["LinePinNum"].ToString();
						this.dataGridView1.Rows[iIndex].Cells[5].Value = dataReader["Remark"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_230_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_230_0.StackTrace);
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
			catch (System.Exception arg_254_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_254_0.StackTrace);
			}
		}
		private void btnUpdateCable_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.Rows.Count > 0)
				{
					int this2 = System.Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString()) - 1;
					int iPid = System.Convert.ToInt32(this.strIDArray[this2]);
					string plugInfoStr = this.strPlugArray[this2];
					string xsbhStr = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
					string remarkStr = this.dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
					ctFormEditCable sender2 = new ctFormEditCable(this.gLineTestProcessor, this.loginUser, iPid, plugInfoStr, xsbhStr, remarkStr);
					this.editCableForm = sender2;
					sender2.Activate();
					this.editCableForm.ShowDialog();
					this.QueryUpdateCableInfoFunc(this2, iPid);
				}
			}
			catch (System.Exception arg_FE_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_FE_0.StackTrace);
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
					dataReader = new OleDbCommand("select * from TProjectInfo where bcCableName='" + queryStr + "'", connection).ExecuteReader();
					if (dataReader.Read())
					{
						this.usedProjectStr = dataReader["ProjectName"].ToString();
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
		private void btnDelCable_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			try
			{
				if (this.dataGridView1.SelectedRows.Count <= 0)
				{
					return;
				}
				if (DialogResult.Cancel == MessageBox.Show("您确认要删除该线束吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
				{
					return;
				}
				if (this.dataGridView1.SelectedRows[0].Cells[1].Value != null)
				{
					string JKStr = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
					if (this.CableUsedQueryFunc(JKStr))
					{
						MessageBox.Show("线束已被项目 " + this.usedProjectStr + " 调用,删除失败!", "提示", MessageBoxButtons.OK);
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
					string sqlcommand = "delete from TLineStructLibrary where LID = " + iID;
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					cmd.ExecuteNonQuery();
					System.Threading.Thread.Sleep(50);
					sqlcommand = "delete from TLineStructLibraryDetail where LID='" + this.strIDArray[num] + "'";
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
					int iw = this.dataGridView1.Width - 718;
					int ia = 0;
					if (iw > 0)
					{
						ia = iw / 3;
					}
					this.dataGridView1.Columns[0].Width = 74;
					int width = ia + 150;
					this.dataGridView1.Columns[1].Width = width;
					this.dataGridView1.Columns[2].Width = 110;
					this.dataGridView1.Columns[3].Width = width;
					this.dataGridView1.Columns[4].Width = 110;
					this.dataGridView1.Columns[5].Width = ia + 100;
				}
			}
			catch (System.Exception arg_C2_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_C2_0.StackTrace);
			}
		}
		private void ctFormCableLibrary_SizeChanged(object sender, System.EventArgs e)
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
			OleDbDataReader dataReader = null;
			try
			{
				this.dataGridView1.Rows.Clear();
				int inum = 0;
				bool bExistFlag = false;
				string xsdhStr = this.textBox_xsdh.Text.ToString().Trim();
				string xxslStr = this.textBox_xxsl.Text.ToString().Trim();
				string jkxxStr = this.textBox_jkxx.Text.ToString().Trim();
				int ixxsl = 0;
				try
				{
					if (this.checkBox_xxsl.Checked && !string.IsNullOrEmpty(xxslStr))
					{
						ixxsl = System.Convert.ToInt32(xxslStr);
					}
				}
				catch (System.Exception ex_8C)
				{
				}
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "select * from TLineStructLibrary";
					if (this.checkBox_xsdh.Checked && !string.IsNullOrEmpty(xsdhStr))
					{
						sqlcommand += " where LineStructName like '%" + xsdhStr + "%' ";
						bExistFlag = true;
					}
					if (this.checkBox_jkxx.Checked && !string.IsNullOrEmpty(jkxxStr))
					{
						if (bExistFlag)
						{
							sqlcommand += " and PlugInfo like '%" + jkxxStr + "%'";
						}
						else
						{
							sqlcommand += " where PlugInfo like '%" + jkxxStr + "%'";
							bExistFlag = true;
						}
					}
					if (this.checkBox_xxsl.Checked && ixxsl >= 0)
					{
						if (bExistFlag)
						{
							sqlcommand += " and LinePinNum=" + ixxsl;
						}
						else
						{
							sqlcommand += " where LinePinNum=" + ixxsl;
							bExistFlag = true;
						}
					}
					sqlcommand += " order by LineStructName";
					dataReader = new OleDbCommand(sqlcommand, connection).ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView1.Rows.Add(1);
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(inum + 1);
						this.strIDArray[inum] = dataReader["LID"].ToString();
						this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["LineStructName"].ToString();
						this.strPlugArray[inum] = dataReader["PlugInfo"].ToString();
						this.dataGridView1.Rows[inum].Cells[3].Value = this.strPlugArray[inum];
						int iIFCount = 0;
						if (string.IsNullOrEmpty(this.strPlugArray[inum]))
						{
							this.dataGridView1.Rows[inum].Cells[2].Value = "0";
						}
						else if (-1 == this.strPlugArray[inum].Trim().LastIndexOf(','))
						{
							this.dataGridView1.Rows[inum].Cells[2].Value = "1";
						}
						else
						{
							char[] separator = new char[]
							{
								','
							};
							string[] strTempArray = this.strPlugArray[inum].Trim().Split(separator);
							for (int i = 0; i < strTempArray.Length; i++)
							{
								if (!string.IsNullOrEmpty(strTempArray[i]))
								{
									iIFCount++;
								}
							}
							this.dataGridView1.Rows[inum].Cells[2].Value = System.Convert.ToString(iIFCount);
						}
						this.dataGridView1.Rows[inum].Cells[4].Value = dataReader["LinePinNum"].ToString();
						this.dataGridView1.Rows[inum].Cells[5].Value = dataReader["Remark"].ToString();
						inum++;
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
				catch (System.Exception arg_419_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_419_0.StackTrace);
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
			catch (System.Exception arg_43D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_43D_0.StackTrace);
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
					dataReader = new OleDbCommand("select * from TLineStructLibrary order by LID", connection).ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView1.Rows.Add(1);
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(inum + 1);
						this.strIDArray[inum] = dataReader["LID"].ToString();
						this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["LineStructName"].ToString();
						this.strPlugArray[inum] = dataReader["PlugInfo"].ToString();
						this.dataGridView1.Rows[inum].Cells[3].Value = this.strPlugArray[inum];
						int iIFCount = 0;
						if (string.IsNullOrEmpty(this.strPlugArray[inum]))
						{
							this.dataGridView1.Rows[inum].Cells[2].Value = "0";
						}
						else if (-1 == this.strPlugArray[inum].Trim().LastIndexOf(','))
						{
							this.dataGridView1.Rows[inum].Cells[2].Value = "1";
						}
						else
						{
							char[] separator = new char[]
							{
								','
							};
							string[] strTempArray = this.strPlugArray[inum].Trim().Split(separator);
							for (int i = 0; i < strTempArray.Length; i++)
							{
								if (!string.IsNullOrEmpty(strTempArray[i]))
								{
									iIFCount++;
								}
							}
							this.dataGridView1.Rows[inum].Cells[2].Value = System.Convert.ToString(iIFCount);
						}
						this.dataGridView1.Rows[inum].Cells[4].Value = dataReader["LinePinNum"].ToString();
						this.dataGridView1.Rows[inum].Cells[5].Value = dataReader["Remark"].ToString();
						inum++;
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
				catch (System.Exception arg_2AE_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_2AE_0.StackTrace);
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
			catch (System.Exception arg_2D2_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2D2_0.StackTrace);
			}
		}
		private void ctFormCableLibrary_Load(object sender, System.EventArgs e)
		{
			try
			{
				try
				{
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
				catch (System.Exception arg_8E_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_8E_0.StackTrace);
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
				catch (System.Exception arg_E9_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_E9_0.StackTrace);
				}
				this.SetDGVWidthSizeFunc();
			}
			catch (System.Exception arg_FD_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_FD_0.StackTrace);
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
		private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			try
			{
				this.btnUpdateCable_Click(null, null);
			}
			catch (System.Exception arg_0A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_0A_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool SaveToExcelFileFunc(string xlsxFile, string csvFile, string cableStr, string bzStr)
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
				cells.Merge(0, 2, 1, 6);
				cells.Merge(1, 2, 1, 6);
				Style st = wb.Styles[wb.Styles.Add()];
				st.HorizontalAlignment = TextAlignmentType.Center;
				st.VerticalAlignment = TextAlignmentType.Center;
				st.Font.Name = "宋体";
				st.Font.Size = 11;
				int iCol = 1;
				this.putValue(cells, "线束代号", 0, 1, st);
				this.putValue(cells, cableStr, 0, 2, st);
				this.putValue(cells, "备注", 1, 1, st);
				this.putValue(cells, bzStr, 1, 2, st);
				this.putValue(cells, "起点接口代号", 2, 1, st);
				this.putValue(cells, "起点接点", 2, 2, st);
				this.putValue(cells, "终点接口代号", 2, 3, st);
				this.putValue(cells, "终点接点", 2, 4, st);
				this.putValue(cells, "是否接地", 2, 5, st);
				this.putValue(cells, "是否导通测试", 2, 6, st);
				this.putValue(cells, "是否绝缘测试", 2, 7, st);
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
						string sqlcommand = "select * from TLineStructLibrary where LineStructName='" + cableStr + "'";
						OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						while (dataReader.Read())
						{
							pidStr = dataReader["LID"].ToString();
						}
						dataReader.Close();
						dataReader = null;
						if (!string.IsNullOrEmpty(pidStr))
						{
							sqlcommand = "select * from TLineStructLibraryDetail where LID='" + pidStr + "'";
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							while (dataReader.Read())
							{
								string temp1Str = dataReader["PlugName1"].ToString();
								string temp2Str = dataReader["PinName1"].ToString();
								string temp3Str = dataReader["PlugName2"].ToString();
								string temp4Str = dataReader["PinName2"].ToString();
								string temp5Str = dataReader["IsGround"].ToString();
								string temp6Str = dataReader["IsTestDT"].ToString();
								string temp7Str = dataReader["IsTestJY"].ToString();
								this.putValue(cells, temp1Str, iRow, iCol, st);
								this.putValue(cells, temp2Str, iRow, iCol + 1, st);
								this.putValue(cells, temp3Str, iRow, iCol + 2, st);
								this.putValue(cells, temp4Str, iRow, iCol + 3, st);
								this.putValue(cells, temp5Str, iRow, iCol + 4, st);
								this.putValue(cells, temp6Str, iRow, iCol + 5, st);
								this.putValue(cells, temp7Str, iRow, iCol + 6, st);
								iRow++;
							}
							dataReader.Close();
							dataReader = null;
						}
						connection.Close();
						connection = null;
					}
					catch (System.Exception arg_312_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_312_0.StackTrace);
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
				catch (System.Exception arg_339_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_339_0.StackTrace);
				}
				wb.Save(xlsxFile, SaveFormat.Xlsx);
				wb = null;
			}
			catch (System.Exception arg_358_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_358_0.StackTrace);
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
						MessageBox.Show("没有选择需要导出的线束!", "提示", MessageBoxButtons.OK);
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
				string xsdhStr = this.textBox_xsdh.Text.ToString().Trim();
				string xxslStr = this.textBox_xxsl.Text.ToString().Trim();
				string jkxxStr = this.textBox_jkxx.Text.ToString().Trim();
				if ((!this.checkBox_xsdh.Checked && !this.checkBox_xxsl.Checked && !this.checkBox_jkxx.Checked) || (string.IsNullOrEmpty(xsdhStr) && string.IsNullOrEmpty(xxslStr) && string.IsNullOrEmpty(jkxxStr)))
				{
					MessageBox.Show("未设置筛选条件!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					this.GLDealwithFunc();
				}
			}
			catch (System.Exception arg_9C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_9C_0.StackTrace);
			}
		}
		private void textBox_xxsl_KeyPress(object sender, KeyPressEventArgs e)
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
					this.~ctFormCableLibrary();
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
