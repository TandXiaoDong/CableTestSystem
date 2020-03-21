using Aspose.Words;
using Aspose.Words.Tables;
using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
namespace CableTestManager
{
	public class FormOperRecordManage : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public string loginUser;
		public string qUserStr;
		public System.ValueType qStartdt;
		public System.ValueType qStopdt;
		public int qMethod;
		public bool isAdminFlag;
		public string exportPathStr;
		public string dbpath;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private FolderBrowserDialog folderBrowserDialog1;
		private GroupBox groupBox1;
		private GroupBox groupBox_result;
		private Button btnDetailView;
		private Button btnQuit;
		private TextBox textBox_user;
		private Label label1;
		private DataGridView dataGridView1;
		private DateTimePicker dateTimePicker_stop;
		private DateTimePicker dateTimePicker_start;
		private Label label3;
		private Label label2;
		private Button btnQuery;
		private Button btnFuzzyQuery;
		private Button btnDel;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn Column3;
		private DataGridViewTextBoxColumn Column4;
		private Button btnExport;
		private Container components;
		public FormOperRecordManage(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
					this.isAdminFlag = gltProcessor.bIsAdminFlag;
					this.qMethod = 0;
				}
				catch (System.Exception arg_49_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_49_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~FormOperRecordManage()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(FormOperRecordManage));
			this.groupBox1 = new GroupBox();
			this.dateTimePicker_stop = new DateTimePicker();
			this.dateTimePicker_start = new DateTimePicker();
			this.textBox_user = new TextBox();
			this.label3 = new Label();
			this.label2 = new Label();
			this.label1 = new Label();
			this.groupBox_result = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.btnDetailView = new Button();
			this.btnQuit = new Button();
			this.btnQuery = new Button();
			this.btnFuzzyQuery = new Button();
			this.btnDel = new Button();
			this.btnExport = new Button();
			this.folderBrowserDialog1 = new FolderBrowserDialog();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.groupBox1.SuspendLayout();
			this.groupBox_result.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
			this.groupBox1.Anchor = AnchorStyles.Top;
			this.groupBox1.Controls.Add(this.dateTimePicker_stop);
			this.groupBox1.Controls.Add(this.dateTimePicker_start);
			this.groupBox1.Controls.Add(this.textBox_user);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(14, 17);
			this.groupBox1.Location = location;
			Padding margin = new Padding(2, 2, 2, 2);
			this.groupBox1.Margin = margin;
			this.groupBox1.Name = "groupBox1";
			Padding padding = new Padding(2, 2, 2, 2);
			this.groupBox1.Padding = padding;
			System.Drawing.Size size = new System.Drawing.Size(768, 70);
			this.groupBox1.Size = size;
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "查询条件";
			this.dateTimePicker_stop.Anchor = AnchorStyles.Top;
			System.Drawing.Point location2 = new System.Drawing.Point(554, 29);
			this.dateTimePicker_stop.Location = location2;
			Padding margin2 = new Padding(2, 2, 2, 2);
			this.dateTimePicker_stop.Margin = margin2;
			this.dateTimePicker_stop.Name = "dateTimePicker_stop";
			System.Drawing.Size size2 = new System.Drawing.Size(151, 24);
			this.dateTimePicker_stop.Size = size2;
			this.dateTimePicker_stop.TabIndex = 3;
			this.dateTimePicker_start.Anchor = AnchorStyles.Top;
			this.dateTimePicker_start.CustomFormat = "";
			System.Drawing.Point location3 = new System.Drawing.Point(370, 29);
			this.dateTimePicker_start.Location = location3;
			Padding margin3 = new Padding(2, 2, 2, 2);
			this.dateTimePicker_start.Margin = margin3;
			this.dateTimePicker_start.Name = "dateTimePicker_start";
			System.Drawing.Size size3 = new System.Drawing.Size(151, 24);
			this.dateTimePicker_start.Size = size3;
			this.dateTimePicker_start.TabIndex = 2;
			this.textBox_user.Anchor = AnchorStyles.Top;
			System.Drawing.Point location4 = new System.Drawing.Point(128, 29);
			this.textBox_user.Location = location4;
			Padding margin4 = new Padding(2, 2, 2, 2);
			this.textBox_user.Margin = margin4;
			this.textBox_user.MaxLength = 32;
			this.textBox_user.Name = "textBox_user";
			System.Drawing.Size size4 = new System.Drawing.Size(151, 24);
			this.textBox_user.Size = size4;
			this.textBox_user.TabIndex = 1;
			this.label3.Anchor = AnchorStyles.Top;
			this.label3.AutoSize = true;
			System.Drawing.Point location5 = new System.Drawing.Point(526, 33);
			this.label3.Location = location5;
			Padding margin5 = new Padding(2, 0, 2, 0);
			this.label3.Margin = margin5;
			this.label3.Name = "label3";
			System.Drawing.Size size5 = new System.Drawing.Size(22, 15);
			this.label3.Size = size5;
			this.label3.TabIndex = 0;
			this.label3.Text = "至";
			this.label2.Anchor = AnchorStyles.Top;
			this.label2.AutoSize = true;
			System.Drawing.Point location6 = new System.Drawing.Point(321, 33);
			this.label2.Location = location6;
			Padding margin6 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin6;
			this.label2.Name = "label2";
			System.Drawing.Size size6 = new System.Drawing.Size(45, 15);
			this.label2.Size = size6;
			this.label2.TabIndex = 0;
			this.label2.Text = "日期:";
			this.label1.Anchor = AnchorStyles.Top;
			this.label1.AutoSize = true;
			System.Drawing.Point location7 = new System.Drawing.Point(65, 33);
			this.label1.Location = location7;
			Padding margin7 = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin7;
			this.label1.Name = "label1";
			System.Drawing.Size size7 = new System.Drawing.Size(60, 15);
			this.label1.Size = size7;
			this.label1.TabIndex = 0;
			this.label1.Text = "操作者:";
			this.groupBox_result.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_result.Controls.Add(this.dataGridView1);
			this.groupBox_result.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(14, 138);
			this.groupBox_result.Location = location8;
			Padding margin8 = new Padding(2, 2, 2, 2);
			this.groupBox_result.Margin = margin8;
			this.groupBox_result.Name = "groupBox_result";
			Padding padding2 = new Padding(2, 2, 2, 2);
			this.groupBox_result.Padding = padding2;
			System.Drawing.Size size8 = new System.Drawing.Size(767, 371);
			this.groupBox_result.Size = size8;
			this.groupBox_result.TabIndex = 0;
			this.groupBox_result.TabStop = false;
			this.groupBox_result.Text = "查询结果";
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
				this.Column3,
				this.Column4
			};
			this.dataGridView1.Columns.AddRange(dataGridViewColumns);
			this.dataGridView1.Dock = DockStyle.Fill;
			System.Drawing.Point location9 = new System.Drawing.Point(2, 19);
			this.dataGridView1.Location = location9;
			Padding margin9 = new Padding(2, 2, 2, 2);
			this.dataGridView1.Margin = margin9;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size9 = new System.Drawing.Size(763, 350);
			this.dataGridView1.Size = size9;
			this.dataGridView1.TabIndex = 5;
			this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
			this.dataGridView1.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
			this.Column1.HeaderText = "序号";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 80;
			this.Column2.HeaderText = "操作者";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 120;
			this.Column3.HeaderText = "操作时间";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 156;
			this.Column4.HeaderText = "操作内容";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Width = 240;
			this.btnDetailView.Anchor = AnchorStyles.Bottom;
			this.btnDetailView.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location10 = new System.Drawing.Point(79, 527);
			this.btnDetailView.Location = location10;
			Padding margin10 = new Padding(2, 2, 2, 2);
			this.btnDetailView.Margin = margin10;
			this.btnDetailView.Name = "btnDetailView";
			System.Drawing.Size size10 = new System.Drawing.Size(32, 24);
			this.btnDetailView.Size = size10;
			this.btnDetailView.TabIndex = 7;
			this.btnDetailView.Text = "查看明细";
			this.btnDetailView.UseVisualStyleBackColor = true;
			this.btnDetailView.Visible = false;
			this.btnDetailView.Click += new System.EventHandler(this.btnDetailView_Click);
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location11 = new System.Drawing.Point(437, 527);
			this.btnQuit.Location = location11;
			Padding margin11 = new Padding(2, 2, 2, 2);
			this.btnQuit.Margin = margin11;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size11 = new System.Drawing.Size(112, 24);
			this.btnQuit.Size = size11;
			this.btnQuit.TabIndex = 8;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btnQuery.Anchor = AnchorStyles.Top;
			this.btnQuery.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location12 = new System.Drawing.Point(418, 102);
			this.btnQuery.Location = location12;
			Padding margin12 = new Padding(2, 2, 2, 2);
			this.btnQuery.Margin = margin12;
			this.btnQuery.Name = "btnQuery";
			System.Drawing.Size size12 = new System.Drawing.Size(112, 24);
			this.btnQuery.Size = size12;
			this.btnQuery.TabIndex = 5;
			this.btnQuery.Text = "查询";
			this.btnQuery.UseVisualStyleBackColor = true;
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnFuzzyQuery.Anchor = AnchorStyles.Top;
			this.btnFuzzyQuery.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location13 = new System.Drawing.Point(265, 102);
			this.btnFuzzyQuery.Location = location13;
			Padding margin13 = new Padding(2, 2, 2, 2);
			this.btnFuzzyQuery.Margin = margin13;
			this.btnFuzzyQuery.Name = "btnFuzzyQuery";
			System.Drawing.Size size13 = new System.Drawing.Size(112, 24);
			this.btnFuzzyQuery.Size = size13;
			this.btnFuzzyQuery.TabIndex = 4;
			this.btnFuzzyQuery.Text = "模糊查询";
			this.btnFuzzyQuery.UseVisualStyleBackColor = true;
			this.btnFuzzyQuery.Click += new System.EventHandler(this.btnFuzzyQuery_Click);
			this.btnDel.Anchor = AnchorStyles.Bottom;
			this.btnDel.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location14 = new System.Drawing.Point(143, 527);
			this.btnDel.Location = location14;
			Padding margin14 = new Padding(2, 2, 2, 2);
			this.btnDel.Margin = margin14;
			this.btnDel.Name = "btnDel";
			System.Drawing.Size size14 = new System.Drawing.Size(31, 24);
			this.btnDel.Size = size14;
			this.btnDel.TabIndex = 6;
			this.btnDel.Text = "删除记录";
			this.btnDel.UseVisualStyleBackColor = true;
			this.btnDel.Visible = false;
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			this.btnExport.Anchor = AnchorStyles.Bottom;
			this.btnExport.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location15 = new System.Drawing.Point(245, 527);
			this.btnExport.Location = location15;
			Padding margin15 = new Padding(2, 2, 2, 2);
			this.btnExport.Margin = margin15;
			this.btnExport.Name = "btnExport";
			System.Drawing.Size size15 = new System.Drawing.Size(112, 24);
			this.btnExport.Size = size15;
			this.btnExport.TabIndex = 6;
			this.btnExport.Text = "导出报表";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.btnFuzzyQuery);
			base.Controls.Add(this.btnQuery);
			base.Controls.Add(this.btnExport);
			base.Controls.Add(this.btnDel);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnDetailView);
			base.Controls.Add(this.groupBox_result);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin16 = new Padding(2, 2, 2, 2);
			base.Margin = margin16;
			base.Name = "FormOperRecordManage";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "操作记录管理";
			base.Load += new System.EventHandler(this.FormOperRecordManage_Load);
			base.SizeChanged += new System.EventHandler(this.FormOperRecordManage_SizeChanged);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox_result.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
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
					int iw = this.dataGridView1.Width - 620;
					if (iw > 0)
					{
						iw /= 3;
					}
					this.dataGridView1.Columns[0].Width = 70;
					this.dataGridView1.Columns[1].Width = iw + 120;
					this.dataGridView1.Columns[2].Width = iw + 176;
					this.dataGridView1.Columns[3].Width = iw + 230;
				}
			}
			catch (System.Exception arg_94_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_94_0.StackTrace);
			}
		}
		private void FormOperRecordManage_SizeChanged(object sender, System.EventArgs e)
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
		private void FormOperRecordManage_Load(object sender, System.EventArgs e)
		{
			try
			{
				System.ValueType dt = System.DateTime.Now;
				System.DateTime value = new System.DateTime(((System.DateTime)dt).Year, ((System.DateTime)dt).Month, ((System.DateTime)dt).Day, 0, 0, 0);
				this.dateTimePicker_start.Value = value;
				System.DateTime value2 = new System.DateTime(((System.DateTime)dt).Year, ((System.DateTime)dt).Month, ((System.DateTime)dt).Day, 23, 59, 59);
				this.dateTimePicker_stop.Value = value2;
				for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
				{
					this.dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					this.dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
				{
					this.dataGridView1.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				for (int k = 0; k < this.dataGridView1.Rows.Count; k++)
				{
					this.dataGridView1.Rows[k].Selected = false;
				}
			}
			catch (System.Exception arg_13E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_13E_0.StackTrace);
			}
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode == 0)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
			catch (System.Exception arg_161_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_161_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
		}
		private void btnDetailView_Click(object sender, System.EventArgs e)
		{
			try
			{
				MessageBox.Show("无相关记录!", "提示", MessageBoxButtons.OK);
			}
			catch (System.Exception arg_13_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_13_0.StackTrace);
			}
		}
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				System.ValueType dt = this.dateTimePicker_start.Value;
				System.ValueType dt2 = this.dateTimePicker_stop.Value;
				System.ValueType valueType = default(System.DateTime);
				(System.DateTime)valueType = new System.DateTime(((System.DateTime)dt).Year, ((System.DateTime)dt).Month, ((System.DateTime)dt).Day, 0, 0, 0, 0);
				System.ValueType startdt = valueType;
				System.ValueType valueType2 = default(System.DateTime);
				(System.DateTime)valueType2 = new System.DateTime(((System.DateTime)dt2).Year, ((System.DateTime)dt2).Month, ((System.DateTime)dt2).Day, 23, 59, 59, 999);
				System.ValueType stopdt = valueType2;
				System.DateTime value = this.dateTimePicker_stop.Value;
				if (System.DateTime.Compare(this.dateTimePicker_start.Value, value) > 0)
				{
					MessageBox.Show("起始日期大于终止日期!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					string uStr = this.textBox_user.Text.ToString();
					this.dataGridView1.Rows.Clear();
					int iRecordCount = 0;
					try
					{
						connection = new OleDbConnection();
						connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
						connection.Open();
						string sqlcommand;
						if (this.isAdminFlag)
						{
							if (0 >= uStr.Length)
							{
								sqlcommand = "select * from TOperationRecord where OperationTime Between #" + valueType + "# and #" + valueType2 + "# ORDER BY ID DESC";
							}
							else
							{
								sqlcommand = "select * from TOperationRecord where UEID='" + uStr + "' and OperationTime Between #" + valueType + "# and #" + valueType2 + "# ORDER BY ID DESC";
							}
						}
						else if (0 >= uStr.Length)
						{
							sqlcommand = "select * from TOperationRecord where OperationTime Between #" + valueType + "# and #" + valueType2 + "# and UEID<>'admin' ORDER BY ID DESC";
						}
						else
						{
							sqlcommand = "select * from TOperationRecord where UEID='" + uStr + "' and OperationTime Between #" + valueType + "# and #" + valueType2 + "# and UEID<>'admin' ORDER BY ID DESC";
						}
						dataReader = new OleDbCommand(sqlcommand, connection).ExecuteReader();
						this.dataGridView1.AllowUserToAddRows = true;
						while (dataReader.Read())
						{
							this.dataGridView1.Rows.Add(1);
							int num = iRecordCount + 1;
							this.dataGridView1.Rows[iRecordCount].Cells[0].Value = System.Convert.ToString(num);
							this.dataGridView1.Rows[iRecordCount].Cells[1].Value = dataReader["UEID"].ToString();
							this.dataGridView1.Rows[iRecordCount].Cells[2].Value = dataReader["OperationTime"].ToString();
							this.dataGridView1.Rows[iRecordCount].Cells[3].Value = dataReader["OperationContent"].ToString();
							iRecordCount = num;
						}
						this.dataGridView1.AllowUserToAddRows = false;
						dataReader.Close();
						dataReader = null;
						connection.Close();
						connection = null;
						if (iRecordCount <= 0)
						{
							MessageBox.Show("查无记录!", "提示", MessageBoxButtons.OK);
							return;
						}
					}
					catch (System.Exception arg_376_0)
					{
						this.dataGridView1.AllowUserToAddRows = false;
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
						KLineTestProcessor.ExceptionRecordFunc(arg_376_0.StackTrace);
						goto IL_3A3;
					}
					this.qUserStr = uStr;
					this.qStartdt = startdt;
					this.qStopdt = stopdt;
					this.qMethod = 0;
					IL_3A3:;
				}
			}
			catch (System.Exception arg_3A5_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3A5_0.StackTrace);
			}
		}
		private void btnFuzzyQuery_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				System.ValueType dt = this.dateTimePicker_start.Value;
				System.ValueType dt2 = this.dateTimePicker_stop.Value;
				System.ValueType valueType = default(System.DateTime);
				(System.DateTime)valueType = new System.DateTime(((System.DateTime)dt).Year, ((System.DateTime)dt).Month, ((System.DateTime)dt).Day, 0, 0, 0, 0);
				System.ValueType startdt = valueType;
				System.ValueType valueType2 = default(System.DateTime);
				(System.DateTime)valueType2 = new System.DateTime(((System.DateTime)dt2).Year, ((System.DateTime)dt2).Month, ((System.DateTime)dt2).Day, 23, 59, 59, 999);
				System.ValueType stopdt = valueType2;
				System.DateTime value = this.dateTimePicker_stop.Value;
				if (System.DateTime.Compare(this.dateTimePicker_start.Value, value) > 0)
				{
					MessageBox.Show("起始日期大于终止日期!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					string uStr = this.textBox_user.Text.ToString();
					this.dataGridView1.Rows.Clear();
					int iRecordCount = 0;
					try
					{
						connection = new OleDbConnection();
						connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
						connection.Open();
						string sqlcommand;
						if (this.isAdminFlag)
						{
							if (0 >= uStr.Length)
							{
								sqlcommand = "select * from TOperationRecord where OperationTime Between #" + valueType + "# and #" + valueType2 + "# ORDER BY ID DESC";
							}
							else
							{
								sqlcommand = "select * from TOperationRecord where UEID like '%" + uStr + "%' and OperationTime Between #" + valueType + "# and #" + valueType2 + "# ORDER BY ID DESC";
							}
						}
						else if (0 >= uStr.Length)
						{
							sqlcommand = "select * from TOperationRecord where OperationTime Between #" + valueType + "# and #" + valueType2 + "# and UEID<>'admin' ORDER BY ID DESC";
						}
						else
						{
							sqlcommand = "select * from TOperationRecord where UEID like '%" + uStr + "%' and OperationTime Between #" + valueType + "# and #" + valueType2 + "# and UEID<>'admin' ORDER BY ID DESC";
						}
						dataReader = new OleDbCommand(sqlcommand, connection).ExecuteReader();
						this.dataGridView1.AllowUserToAddRows = true;
						while (dataReader.Read())
						{
							this.dataGridView1.Rows.Add(1);
							int num = iRecordCount + 1;
							this.dataGridView1.Rows[iRecordCount].Cells[0].Value = System.Convert.ToString(num);
							this.dataGridView1.Rows[iRecordCount].Cells[1].Value = dataReader["UEID"].ToString();
							this.dataGridView1.Rows[iRecordCount].Cells[2].Value = dataReader["OperationTime"].ToString();
							this.dataGridView1.Rows[iRecordCount].Cells[3].Value = dataReader["OperationContent"].ToString();
							iRecordCount = num;
						}
						this.dataGridView1.AllowUserToAddRows = false;
						dataReader.Close();
						dataReader = null;
						connection.Close();
						connection = null;
						if (iRecordCount <= 0)
						{
							MessageBox.Show("查无记录!", "提示", MessageBoxButtons.OK);
							return;
						}
					}
					catch (System.Exception arg_376_0)
					{
						this.dataGridView1.AllowUserToAddRows = false;
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
						KLineTestProcessor.ExceptionRecordFunc(arg_376_0.StackTrace);
						goto IL_3A3;
					}
					this.qUserStr = uStr;
					this.qStartdt = startdt;
					this.qStopdt = stopdt;
					this.qMethod = 1;
					IL_3A3:;
				}
			}
			catch (System.Exception arg_3A5_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3A5_0.StackTrace);
			}
		}
		public void RefreshDataGridView()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.dataGridView1.Rows.Clear();
				int iRecordCount = 0;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand;
					if (this.isAdminFlag)
					{
						if (0 >= this.qUserStr.Length)
						{
							sqlcommand = "select * from TOperationRecord where OperationTime Between #" + this.qStartdt + "# and #" + this.qStopdt + "# ORDER BY ID DESC";
						}
						else if (this.qMethod == 0)
						{
							sqlcommand = "select * from TOperationRecord where UEID='" + this.qUserStr + "' and OperationTime Between #" + this.qStartdt + "# and #" + this.qStopdt + "# ORDER BY ID DESC";
						}
						else
						{
							sqlcommand = "select * from TOperationRecord where UEID like '%" + this.qUserStr + "%' and OperationTime Between #" + this.qStartdt + "# and #" + this.qStopdt + "# ORDER BY ID DESC";
						}
					}
					else if (0 >= this.qUserStr.Length)
					{
						sqlcommand = "select * from TOperationRecord where OperationTime Between #" + this.qStartdt + "# and #" + this.qStopdt + "# and UEID<>'admin' ORDER BY ID DESC";
					}
					else if (this.qMethod == 0)
					{
						sqlcommand = "select * from TOperationRecord where UEID='" + this.qUserStr + "' and OperationTime Between #" + this.qStartdt + "# and #" + this.qStopdt + "# and UEID<>'admin' ORDER BY ID DESC";
					}
					else
					{
						sqlcommand = "select * from TOperationRecord where UEID like '%" + this.qUserStr + "%' and OperationTime Between #" + this.qStartdt + "# and #" + this.qStopdt + "# and UEID<>'admin' ORDER BY ID DESC";
					}
					dataReader = new OleDbCommand(sqlcommand, connection).ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView1.Rows.Add(1);
						int num = iRecordCount + 1;
						this.dataGridView1.Rows[iRecordCount].Cells[0].Value = System.Convert.ToString(num);
						this.dataGridView1.Rows[iRecordCount].Cells[1].Value = dataReader["UEID"].ToString();
						this.dataGridView1.Rows[iRecordCount].Cells[2].Value = dataReader["OperationTime"].ToString();
						this.dataGridView1.Rows[iRecordCount].Cells[3].Value = dataReader["OperationContent"].ToString();
						iRecordCount = num;
					}
					this.dataGridView1.AllowUserToAddRows = false;
					dataReader.Close();
					connection.Close();
					dataReader = null;
					connection = null;
					if (iRecordCount <= 0)
					{
					}
				}
				catch (System.Exception arg_338_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
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
					KLineTestProcessor.ExceptionRecordFunc(arg_338_0.StackTrace);
				}
			}
			catch (System.Exception arg_348_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_348_0.StackTrace);
			}
		}
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.Rows.Count > 0)
				{
					if (DialogResult.Cancel != MessageBox.Show("记录删除后将无法找回，您确定要删除吗?", "提示", MessageBoxButtons.OKCancel))
					{
						string userStr = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
						System.ValueType operTime = System.Convert.ToDateTime(this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
						try
						{
							connection = new OleDbConnection();
							connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
							connection.Open();
							new OleDbCommand("delete from TOperationRecord where UEID='" + userStr + "' and OperationTime=#" + operTime + "#", connection).ExecuteNonQuery();
							connection.Close();
							connection = null;
						}
						catch (System.Exception arg_101_0)
						{
							if (connection != null)
							{
								connection.Close();
								connection = null;
							}
							KLineTestProcessor.ExceptionRecordFunc(arg_101_0.StackTrace);
							goto IL_126;
						}
						MessageBox.Show("记录删除成功!", "提示", MessageBoxButtons.OK);
						this.RefreshDataGridView();
						IL_126:;
					}
				}
			}
			catch (System.Exception arg_12A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_12A_0.StackTrace);
			}
		}
		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.Rows.Count > 0)
				{
					if (!this.isAdminFlag)
					{
						string userStr = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
						this.loginUser == userStr;
					}
				}
			}
			catch (System.Exception arg_68_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_68_0.StackTrace);
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
					if (0 == myPro.ProcessName.ToUpper().CompareTo("WORD"))
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
			catch (System.Exception arg_5A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5A_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool SataRecordDataToPDFFunc(string currentPDFfn)
		{
			bool result;
			try
			{
				Document doc = new Document(Application.StartupPath + "\\template\\orTemplate.docx");
				DocumentBuilder builder = new DocumentBuilder(doc);
				builder.MoveToBookmark("myBookmark");
				builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
				builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
				builder.Write("操作记录\n\r");
				builder.StartTable();
				builder.CellFormat.Borders.LineStyle = LineStyle.Single;
				System.Drawing.Color black = System.Drawing.Color.Black;
				builder.CellFormat.Borders.Color = black;
				builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
				builder.CellFormat.HorizontalMerge = CellMerge.None;
				builder.CellFormat.VerticalMerge = CellMerge.None;
				builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
				builder.InsertCell();
				builder.Write("序号");
				builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
				builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
				builder.InsertCell();
				builder.Write("操作者");
				builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
				builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
				builder.InsertCell();
				builder.Write("操作时间");
				builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
				builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
				builder.InsertCell();
				builder.Write("操作内容");
				builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
				builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
				builder.Bold = false;
				builder.EndRow();
				for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
				{
					builder.InsertCell();
					builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
					builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
					builder.Write(this.dataGridView1.Rows[i].Cells[0].Value.ToString());
					builder.InsertCell();
					builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
					builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
					builder.Write(this.dataGridView1.Rows[i].Cells[1].Value.ToString());
					builder.InsertCell();
					builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
					builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
					builder.Write(this.dataGridView1.Rows[i].Cells[2].Value.ToString());
					builder.InsertCell();
					builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
					builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
					builder.Write(this.dataGridView1.Rows[i].Cells[3].Value.ToString());
					builder.EndRow();
				}
				builder.EndTable();
				doc.Save(currentPDFfn, SaveFormat.Pdf);
				return true;
			}
			catch (System.Exception arg_2CE_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2CE_0.StackTrace);
				result = false;
			}
			return result;
		}
		private void btnExport_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dataGridView1.Rows.Count <= 0)
				{
					MessageBox.Show("无相关记录!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					string orfn = Application.StartupPath + "\\操作记录";
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
						this.exportPathStr = orfn;
						System.ValueType dt = System.DateTime.Now;
						string tt = System.Convert.ToString(((System.DateTime)dt).Year);
						tt += System.Convert.ToString(((System.DateTime)dt).Month);
						tt += System.Convert.ToString(((System.DateTime)dt).Day);
						string ttms = System.Convert.ToString(((System.DateTime)dt).Hour);
						ttms += System.Convert.ToString(((System.DateTime)dt).Minute);
						ttms += System.Convert.ToString(((System.DateTime)dt).Second);
						string currentPDFfn = orfn + "\\操作记录_" + tt + ttms + ".pdf";
						if (!this.SataRecordDataToPDFFunc(currentPDFfn))
						{
							MessageBox.Show("导出失败!", "提示", MessageBoxButtons.OK);
						}
						else
						{
							Process.Start(currentPDFfn);
						}
					}
				}
			}
			catch (System.Exception arg_16B_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_16B_0.StackTrace);
			}
		}
		private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.Rows.Count > 0)
				{
					if (!this.isAdminFlag)
					{
						string userStr = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
						this.loginUser == userStr;
					}
				}
			}
			catch (System.Exception arg_68_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_68_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~FormOperRecordManage();
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
