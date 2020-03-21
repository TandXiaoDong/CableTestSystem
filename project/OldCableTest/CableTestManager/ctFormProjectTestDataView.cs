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
	public class ctFormProjectTestDataView : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public ctFormProjectTestDataDetail projectTestDataDetailForm;
		public System.Collections.Generic.List<string> userIDStrList;
		public string[] strIDArray;
		public string loginUser;
		public string dbpath;
		public string mddbpath;
		public string qCablebhStr;
		public System.ValueType qStartdt;
		public System.ValueType qStopdt;
		public int qMethod;
		private GroupBox groupBox1;
		private TextBox textBox_cableName;
		private Label label2;
		private TextBox textBox_batchMumber;
		private Label label_batchMumber;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn Column3;
		private DataGridViewTextBoxColumn Column4;
		private DataGridViewTextBoxColumn Column8;
		private DataGridViewTextBoxColumn Column6;
		private DataGridViewTextBoxColumn Column7;
		private DateTimePicker dateTimePicker_stop;
		private DateTimePicker dateTimePicker_start;
		private Label label3;
		private Label label4;
		private Button btnFuzzyQuery;
		private Button btnQuery;
		private GroupBox groupBox2;
		private DataGridView dataGridView1;
		private Button btnViewDetail;
		private Button btnDelRecord;
		private Button btnQuit;
		private Container components;
		public ctFormProjectTestDataView(string lUser)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.loginUser = lUser;
					this.strIDArray = new string[5000];
					this.qMethod = 0;
					this.userIDStrList = new System.Collections.Generic.List<string>();
				}
				catch (System.Exception arg_37_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_37_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		public ctFormProjectTestDataView(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
					this.strIDArray = new string[5000];
					this.qMethod = 0;
					this.userIDStrList = new System.Collections.Generic.List<string>();
				}
				catch (System.Exception arg_43_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_43_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormProjectTestDataView()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormProjectTestDataView));
			this.groupBox1 = new GroupBox();
			this.textBox_batchMumber = new TextBox();
			this.label_batchMumber = new Label();
			this.dateTimePicker_stop = new DateTimePicker();
			this.dateTimePicker_start = new DateTimePicker();
			this.label3 = new Label();
			this.label4 = new Label();
			this.textBox_cableName = new TextBox();
			this.label2 = new Label();
			this.btnFuzzyQuery = new Button();
			this.btnQuery = new Button();
			this.groupBox2 = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.Column8 = new DataGridViewTextBoxColumn();
			this.Column6 = new DataGridViewTextBoxColumn();
			this.Column7 = new DataGridViewTextBoxColumn();
			this.btnViewDetail = new Button();
			this.btnDelRecord = new Button();
			this.btnQuit = new Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.textBox_batchMumber);
			this.groupBox1.Controls.Add(this.label_batchMumber);
			this.groupBox1.Controls.Add(this.dateTimePicker_stop);
			this.groupBox1.Controls.Add(this.dateTimePicker_start);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.textBox_cableName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(11, 12);
			this.groupBox1.Location = location;
			Padding margin = new Padding(2, 2, 2, 2);
			this.groupBox1.Margin = margin;
			this.groupBox1.Name = "groupBox1";
			Padding padding = new Padding(2, 2, 2, 2);
			this.groupBox1.Padding = padding;
			System.Drawing.Size size = new System.Drawing.Size(771, 96);
			this.groupBox1.Size = size;
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "查询条件";
			this.textBox_batchMumber.Anchor = AnchorStyles.Top;
			this.textBox_batchMumber.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(91, 58);
			this.textBox_batchMumber.Location = location2;
			Padding margin2 = new Padding(2, 2, 2, 2);
			this.textBox_batchMumber.Margin = margin2;
			this.textBox_batchMumber.MaxLength = 120;
			this.textBox_batchMumber.Name = "textBox_batchMumber";
			System.Drawing.Size size2 = new System.Drawing.Size(271, 24);
			this.textBox_batchMumber.Size = size2;
			this.textBox_batchMumber.TabIndex = 11;
			this.label_batchMumber.Anchor = AnchorStyles.Top;
			this.label_batchMumber.AutoSize = true;
			this.label_batchMumber.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(9, 62);
			this.label_batchMumber.Location = location3;
			Padding margin3 = new Padding(2, 0, 2, 0);
			this.label_batchMumber.Margin = margin3;
			this.label_batchMumber.Name = "label_batchMumber";
			System.Drawing.Size size3 = new System.Drawing.Size(76, 15);
			this.label_batchMumber.Size = size3;
			this.label_batchMumber.TabIndex = 10;
			this.label_batchMumber.Text = "批 次 号:";
			this.dateTimePicker_stop.Anchor = AnchorStyles.Top;
			this.dateTimePicker_stop.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(607, 41);
			this.dateTimePicker_stop.Location = location4;
			Padding margin4 = new Padding(2, 2, 2, 2);
			this.dateTimePicker_stop.Margin = margin4;
			this.dateTimePicker_stop.Name = "dateTimePicker_stop";
			System.Drawing.Size size4 = new System.Drawing.Size(128, 24);
			this.dateTimePicker_stop.Size = size4;
			this.dateTimePicker_stop.TabIndex = 3;
			this.dateTimePicker_start.Anchor = AnchorStyles.Top;
			this.dateTimePicker_start.CustomFormat = "";
			this.dateTimePicker_start.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(442, 41);
			this.dateTimePicker_start.Location = location5;
			Padding margin5 = new Padding(2, 2, 2, 2);
			this.dateTimePicker_start.Margin = margin5;
			this.dateTimePicker_start.Name = "dateTimePicker_start";
			System.Drawing.Size size5 = new System.Drawing.Size(128, 24);
			this.dateTimePicker_start.Size = size5;
			this.dateTimePicker_start.TabIndex = 2;
			this.label3.Anchor = AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(578, 45);
			this.label3.Location = location6;
			Padding margin6 = new Padding(2, 0, 2, 0);
			this.label3.Margin = margin6;
			this.label3.Name = "label3";
			System.Drawing.Size size6 = new System.Drawing.Size(22, 15);
			this.label3.Size = size6;
			this.label3.TabIndex = 4;
			this.label3.Text = "至";
			this.label4.Anchor = AnchorStyles.Top;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(392, 45);
			this.label4.Location = location7;
			Padding margin7 = new Padding(2, 0, 2, 0);
			this.label4.Margin = margin7;
			this.label4.Name = "label4";
			System.Drawing.Size size7 = new System.Drawing.Size(45, 15);
			this.label4.Size = size7;
			this.label4.TabIndex = 5;
			this.label4.Text = "日期:";
			this.textBox_cableName.Anchor = AnchorStyles.Top;
			this.textBox_cableName.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(91, 25);
			this.textBox_cableName.Location = location8;
			Padding margin8 = new Padding(2, 2, 2, 2);
			this.textBox_cableName.Margin = margin8;
			this.textBox_cableName.Name = "textBox_cableName";
			System.Drawing.Size size8 = new System.Drawing.Size(271, 24);
			this.textBox_cableName.Size = size8;
			this.textBox_cableName.TabIndex = 1;
			this.label2.Anchor = AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(10, 29);
			this.label2.Location = location9;
			Padding margin9 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin9;
			this.label2.Name = "label2";
			System.Drawing.Size size9 = new System.Drawing.Size(75, 15);
			this.label2.Size = size9;
			this.label2.TabIndex = 0;
			this.label2.Text = "被测线束:";
			this.btnFuzzyQuery.Anchor = AnchorStyles.Top;
			this.btnFuzzyQuery.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location10 = new System.Drawing.Point(241, 118);
			this.btnFuzzyQuery.Location = location10;
			Padding margin10 = new Padding(2, 2, 2, 2);
			this.btnFuzzyQuery.Margin = margin10;
			this.btnFuzzyQuery.Name = "btnFuzzyQuery";
			System.Drawing.Size size10 = new System.Drawing.Size(112, 24);
			this.btnFuzzyQuery.Size = size10;
			this.btnFuzzyQuery.TabIndex = 4;
			this.btnFuzzyQuery.Text = "模糊查询";
			this.btnFuzzyQuery.UseVisualStyleBackColor = true;
			this.btnFuzzyQuery.Click += new System.EventHandler(this.btnFuzzyQuery_Click);
			this.btnQuery.Anchor = AnchorStyles.Top;
			this.btnQuery.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location11 = new System.Drawing.Point(442, 118);
			this.btnQuery.Location = location11;
			Padding margin11 = new Padding(2, 2, 2, 2);
			this.btnQuery.Margin = margin11;
			this.btnQuery.Name = "btnQuery";
			System.Drawing.Size size11 = new System.Drawing.Size(112, 24);
			this.btnQuery.Size = size11;
			this.btnQuery.TabIndex = 6;
			this.btnQuery.Text = "精确查询";
			this.btnQuery.UseVisualStyleBackColor = true;
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.groupBox2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox2.Controls.Add(this.dataGridView1);
			this.groupBox2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location12 = new System.Drawing.Point(11, 155);
			this.groupBox2.Location = location12;
			Padding margin12 = new Padding(2, 2, 2, 2);
			this.groupBox2.Margin = margin12;
			this.groupBox2.Name = "groupBox2";
			Padding padding2 = new Padding(2, 2, 2, 2);
			this.groupBox2.Padding = padding2;
			System.Drawing.Size size12 = new System.Drawing.Size(771, 350);
			this.groupBox2.Size = size12;
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "历史数据";
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
				this.Column4,
				this.Column8,
				this.Column6,
				this.Column7
			};
			this.dataGridView1.Columns.AddRange(dataGridViewColumns);
			this.dataGridView1.Dock = DockStyle.Fill;
			System.Drawing.Point location13 = new System.Drawing.Point(2, 19);
			this.dataGridView1.Location = location13;
			Padding margin13 = new Padding(2, 2, 2, 2);
			this.dataGridView1.Margin = margin13;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size13 = new System.Drawing.Size(767, 329);
			this.dataGridView1.Size = size13;
			this.dataGridView1.TabIndex = 6;
			this.dataGridView1.CellMouseClick += new DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
			this.dataGridView1.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
			this.Column1.HeaderText = "序号";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 70;
			this.Column2.HeaderText = "项目名称";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 120;
			this.Column3.HeaderText = "被测线束";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column4.HeaderText = "批次号";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column8.HeaderText = "测试时间";
			this.Column8.Name = "Column8";
			this.Column8.ReadOnly = true;
			this.Column8.Width = 120;
			this.Column6.HeaderText = "测试人员";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column7.HeaderText = "测试结果";
			this.Column7.Name = "Column7";
			this.Column7.ReadOnly = true;
			this.btnViewDetail.Anchor = AnchorStyles.Bottom;
			this.btnViewDetail.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location14 = new System.Drawing.Point(138, 522);
			this.btnViewDetail.Location = location14;
			Padding margin14 = new Padding(2, 2, 2, 2);
			this.btnViewDetail.Margin = margin14;
			this.btnViewDetail.Name = "btnViewDetail";
			System.Drawing.Size size14 = new System.Drawing.Size(135, 24);
			this.btnViewDetail.Size = size14;
			this.btnViewDetail.TabIndex = 7;
			this.btnViewDetail.Text = "查看明细";
			this.btnViewDetail.UseVisualStyleBackColor = true;
			this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
			this.btnDelRecord.Anchor = AnchorStyles.Bottom;
			this.btnDelRecord.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location15 = new System.Drawing.Point(330, 522);
			this.btnDelRecord.Location = location15;
			Padding margin15 = new Padding(2, 2, 2, 2);
			this.btnDelRecord.Margin = margin15;
			this.btnDelRecord.Name = "btnDelRecord";
			System.Drawing.Size size15 = new System.Drawing.Size(135, 24);
			this.btnDelRecord.Size = size15;
			this.btnDelRecord.TabIndex = 8;
			this.btnDelRecord.Text = "删除测试数据";
			this.btnDelRecord.UseVisualStyleBackColor = true;
			this.btnDelRecord.Visible = false;
			this.btnDelRecord.Click += new System.EventHandler(this.btnDelRecord_Click);
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location16 = new System.Drawing.Point(522, 522);
			this.btnQuit.Location = location16;
			Padding margin16 = new Padding(2, 2, 2, 2);
			this.btnQuit.Margin = margin16;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size16 = new System.Drawing.Size(135, 24);
			this.btnQuit.Size = size16;
			this.btnQuit.TabIndex = 9;
			this.btnQuit.Text = "关闭";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnDelRecord);
			base.Controls.Add(this.btnViewDetail);
			base.Controls.Add(this.btnFuzzyQuery);
			base.Controls.Add(this.btnQuery);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin17 = new Padding(2, 2, 2, 2);
			base.Margin = margin17;
			base.Name = "ctFormProjectTestDataView";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "查看历史数据";
			base.Load += new System.EventHandler(this.ctFormProjectTestDataView_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormProjectTestDataView_SizeChanged);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			base.ResumeLayout(false);
		}
		public void RefreshDataGridView()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.userIDStrList.Clear();
				this.dataGridView1.Rows.Clear();
				this.btnDelRecord.Visible = false;
				int inum = 0;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.mddbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select * from THistoryDataInfo ORDER BY ID DESC", connection).ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView1.Rows.Add(1);
						int num = inum + 1;
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
						this.strIDArray[inum] = dataReader["ID"].ToString();
						this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["ProjectName"].ToString();
						this.dataGridView1.Rows[inum].Cells[3].Value = dataReader["batchMumberStr"].ToString();
						this.dataGridView1.Rows[inum].Cells[2].Value = dataReader["bcCableName"].ToString();
						this.dataGridView1.Rows[inum].Cells[4].Value = dataReader["TestTime"].ToString();
						this.userIDStrList.Add(dataReader["Tester"].ToString());
						this.dataGridView1.Rows[inum].Cells[5].Value = dataReader["Operator"].ToString();
						this.dataGridView1.Rows[inum].Cells[6].Value = dataReader["TestResult"].ToString();
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
				catch (System.Exception arg_241_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_241_0.StackTrace);
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
			catch (System.Exception arg_265_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_265_0.StackTrace);
			}
		}
		private void ctFormProjectTestDataView_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
				this.mddbpath = Application.StartupPath + "\\ctsmddb.mdb";
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
			}
			catch (System.Exception arg_136_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_136_0.StackTrace);
			}
			this.RefreshDataGridView();
			int k = 0;
			if (0 < this.dataGridView1.Rows.Count)
			{
				do
				{
					this.dataGridView1.Rows[k].Selected = false;
					k++;
				}
				while (k < this.dataGridView1.Rows.Count);
			}
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode == 0)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
			catch (System.Exception arg_1A2_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1A2_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
		}
		private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{
				this.btnViewDetail_Click(null, null);
			}
			catch (System.Exception arg_0A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_0A_0.StackTrace);
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
					int iw = this.dataGridView1.Width - 768;
					int iy = 0;
					int ia = 0;
					if (iw > 0)
					{
						int num = iw / 3;
						ia = num;
						iy = iw - num * 3;
					}
					this.dataGridView1.Columns[0].Width = iy + 60;
					int width = ia + 120;
					this.dataGridView1.Columns[1].Width = width;
					this.dataGridView1.Columns[2].Width = width;
					this.dataGridView1.Columns[3].Width = ia + 100;
					this.dataGridView1.Columns[4].Width = 164;
					this.dataGridView1.Columns[5].Width = 90;
					this.dataGridView1.Columns[6].Width = 90;
				}
			}
			catch (System.Exception arg_E9_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_E9_0.StackTrace);
			}
		}
		private void ctFormProjectTestDataView_SizeChanged(object sender, System.EventArgs e)
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
		private void btnFuzzyQuery_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			string sqlcommand = null;
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
					MessageBox.Show("起始日期大于终止日期!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					string _cablebhStr = this.textBox_cableName.Text.ToString();
					string batchMumberStr = this.textBox_batchMumber.Text.ToString().Trim();
					this.userIDStrList.Clear();
					this.dataGridView1.Rows.Clear();
					this.btnDelRecord.Visible = false;
					int inum = 0;
					try
					{
						connection = new OleDbConnection();
						connection.ConnectionString = this.gLineTestProcessor.mddbPathStr;
						connection.Open();
						if (string.IsNullOrEmpty(_cablebhStr) && string.IsNullOrEmpty(batchMumberStr))
						{
							sqlcommand = "select * from THistoryDataInfo where TestTime Between #" + valueType + "# and #" + valueType2 + "# ORDER BY ID DESC";
						}
						else if (!string.IsNullOrEmpty(_cablebhStr) && !string.IsNullOrEmpty(batchMumberStr))
						{
							sqlcommand = "select * from THistoryDataInfo where batchMumberStr like '%" + batchMumberStr + "%' and bcCableName like '%" + _cablebhStr + "%' and TestTime Between #" + valueType + "# and #" + valueType2 + "# ORDER BY ID DESC";
						}
						else if (string.IsNullOrEmpty(_cablebhStr) && !string.IsNullOrEmpty(batchMumberStr))
						{
							sqlcommand = "select * from THistoryDataInfo where batchMumberStr like '%" + batchMumberStr + "%' and TestTime Between #" + valueType + "# and #" + valueType2 + "# ORDER BY ID DESC";
						}
						else if (!string.IsNullOrEmpty(_cablebhStr) && string.IsNullOrEmpty(batchMumberStr))
						{
							sqlcommand = "select * from THistoryDataInfo where bcCableName like '%" + _cablebhStr + "%' and TestTime Between #" + valueType + "# and #" + valueType2 + "# ORDER BY ID DESC";
						}
						dataReader = new OleDbCommand(sqlcommand, connection).ExecuteReader();
						this.dataGridView1.AllowUserToAddRows = true;
						while (dataReader.Read())
						{
							this.dataGridView1.Rows.Add(1);
							int num = inum + 1;
							this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
							this.strIDArray[inum] = dataReader["ID"].ToString();
							this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["ProjectName"].ToString();
							this.dataGridView1.Rows[inum].Cells[3].Value = dataReader["batchMumberStr"].ToString();
							this.dataGridView1.Rows[inum].Cells[2].Value = dataReader["bcCableName"].ToString();
							this.dataGridView1.Rows[inum].Cells[4].Value = dataReader["TestTime"].ToString();
							this.userIDStrList.Add(dataReader["Tester"].ToString());
							this.dataGridView1.Rows[inum].Cells[5].Value = dataReader["Operator"].ToString();
							this.dataGridView1.Rows[inum].Cells[6].Value = dataReader["TestResult"].ToString();
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
						if (inum <= 0)
						{
							MessageBox.Show("查无记录!", "提示", MessageBoxButtons.OK);
							return;
						}
					}
					catch (System.Exception arg_4AE_0)
					{
						this.dataGridView1.AllowUserToAddRows = false;
						KLineTestProcessor.ExceptionRecordFunc(arg_4AE_0.StackTrace);
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
					this.qCablebhStr = _cablebhStr;
					this.qStartdt = startdt;
					this.qStopdt = stopdt;
					this.qMethod = 1;
				}
			}
			catch (System.Exception arg_4F0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_4F0_0.StackTrace);
			}
		}
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			string sqlcommand = null;
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
					MessageBox.Show("起始日期大于终止日期!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					string _cablebhStr = this.textBox_cableName.Text.ToString();
					string batchMumberStr = this.textBox_batchMumber.Text.ToString().Trim();
					this.userIDStrList.Clear();
					this.dataGridView1.Rows.Clear();
					this.btnDelRecord.Visible = false;
					int inum = 0;
					try
					{
						connection = new OleDbConnection();
						connection.ConnectionString = this.gLineTestProcessor.mddbPathStr;
						connection.Open();
						if (string.IsNullOrEmpty(_cablebhStr) && string.IsNullOrEmpty(batchMumberStr))
						{
							sqlcommand = "select * from THistoryDataInfo where TestTime Between #" + valueType + "# and #" + valueType2 + "# ORDER BY ID DESC";
						}
						else if (!string.IsNullOrEmpty(_cablebhStr) && !string.IsNullOrEmpty(batchMumberStr))
						{
							sqlcommand = "select * from THistoryDataInfo where batchMumberStr = '" + batchMumberStr + "' and bcCableName = '" + _cablebhStr + "' and TestTime Between #" + valueType + "# and #" + valueType2 + "# ORDER BY ID DESC";
						}
						else if (string.IsNullOrEmpty(_cablebhStr) && !string.IsNullOrEmpty(batchMumberStr))
						{
							sqlcommand = "select * from THistoryDataInfo where batchMumberStr = '" + batchMumberStr + "' and TestTime Between #" + valueType + "# and #" + valueType2 + "# ORDER BY ID DESC";
						}
						else if (!string.IsNullOrEmpty(_cablebhStr) && string.IsNullOrEmpty(batchMumberStr))
						{
							sqlcommand = "select * from THistoryDataInfo where bcCableName = '" + _cablebhStr + "' and TestTime Between #" + valueType + "# and #" + valueType2 + "# ORDER BY ID DESC";
						}
						dataReader = new OleDbCommand(sqlcommand, connection).ExecuteReader();
						this.dataGridView1.AllowUserToAddRows = true;
						while (dataReader.Read())
						{
							this.dataGridView1.Rows.Add(1);
							int num = inum + 1;
							this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
							this.strIDArray[inum] = dataReader["ID"].ToString();
							this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["ProjectName"].ToString();
							this.dataGridView1.Rows[inum].Cells[3].Value = dataReader["batchMumberStr"].ToString();
							this.dataGridView1.Rows[inum].Cells[2].Value = dataReader["bcCableName"].ToString();
							this.dataGridView1.Rows[inum].Cells[4].Value = dataReader["TestTime"].ToString();
							this.userIDStrList.Add(dataReader["Tester"].ToString());
							this.dataGridView1.Rows[inum].Cells[5].Value = dataReader["Operator"].ToString();
							this.dataGridView1.Rows[inum].Cells[6].Value = dataReader["TestResult"].ToString();
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
						if (inum <= 0)
						{
							MessageBox.Show("查无记录!", "提示", MessageBoxButtons.OK);
							return;
						}
					}
					catch (System.Exception arg_4AE_0)
					{
						this.dataGridView1.AllowUserToAddRows = false;
						KLineTestProcessor.ExceptionRecordFunc(arg_4AE_0.StackTrace);
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
					this.qCablebhStr = _cablebhStr;
					this.qStartdt = startdt;
					this.qStopdt = stopdt;
					this.qMethod = 0;
				}
			}
			catch (System.Exception arg_4F0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_4F0_0.StackTrace);
			}
		}
		private void btnDelRecord_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.Rows.Count > 0)
				{
					if (DialogResult.Cancel != MessageBox.Show("记录删除后将无法找回，您确定要删除吗?", "提示", MessageBoxButtons.OKCancel))
					{
						int iRCount = this.dataGridView1.Rows.Count;
						int num = System.Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString()) - 1;
						int iPid = System.Convert.ToInt32(this.strIDArray[num]);
						for (int i = 0; i < iRCount; i++)
						{
							if (i > num)
							{
								string[] array = this.strIDArray;
								array[i - 1] = array[i];
							}
						}
						this.userIDStrList.RemoveAt(num);
						this.dataGridView1.Rows.RemoveAt(num);
						int num2;
						for (int j = 0; j < this.dataGridView1.Rows.Count; j = num2)
						{
							num2 = j + 1;
							this.dataGridView1.Rows[j].Cells[0].Value = System.Convert.ToString(num2);
						}
						try
						{
							connection = new OleDbConnection();
							connection.ConnectionString = this.gLineTestProcessor.mddbPathStr;
							connection.Open();
							string sqlcommand = "delete from THistoryDataDetail where HID=" + iPid;
							OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
							cmd.ExecuteNonQuery();
							System.Threading.Thread.Sleep(100);
							sqlcommand = "delete from THistoryDataInfo where ID=" + iPid;
							cmd = new OleDbCommand(sqlcommand, connection);
							cmd.ExecuteNonQuery();
							connection.Close();
							connection = null;
						}
						catch (System.Exception arg_195_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_195_0.StackTrace);
							if (connection != null)
							{
								connection.Close();
								connection = null;
							}
						}
					}
				}
			}
			catch (System.Exception arg_1B0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1B0_0.StackTrace);
			}
		}
		public void DGVClickFunc()
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.Rows.Count > 0)
				{
					if (this.dataGridView1.SelectedRows[0].Cells[0].Value != null)
					{
						int iPIDIndex = System.Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
						if (this.userIDStrList[iPIDIndex - 1] == this.loginUser)
						{
							this.btnDelRecord.Visible = true;
						}
						else
						{
							this.btnDelRecord.Visible = false;
						}
					}
				}
			}
			catch (System.Exception arg_B4_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_B4_0.StackTrace);
			}
		}
		private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{
				this.DGVClickFunc();
			}
			catch (System.Exception arg_08_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_08_0.StackTrace);
			}
		}
		private void btnViewDetail_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dataGridView1.Rows.Count > 0)
				{
					this.DGVClickFunc();
					int iPIDIndex = System.Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
					int iPid = System.Convert.ToInt32(this.strIDArray[iPIDIndex - 1]);
					ctFormProjectTestDataDetail this2 = new ctFormProjectTestDataDetail(this.loginUser, this.gLineTestProcessor, iPid);
					this.projectTestDataDetailForm = this2;
					this2.Activate();
					this.projectTestDataDetailForm.ShowDialog();
				}
			}
			catch (System.Exception arg_88_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_88_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormProjectTestDataView();
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
