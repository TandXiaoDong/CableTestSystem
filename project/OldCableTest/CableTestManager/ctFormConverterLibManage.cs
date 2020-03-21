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
	public class ctFormConverterLibManage : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public ctFormAddConverter addConverterForm;
		public ctFormEditConverter editConverterForm;
		public string dbpath;
		public string loginUser;
		public string usedProjectStr;
		public string[] strIDArray;
		private ComboBox comboBox_sxtj;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn Column4;
		private DataGridViewTextBoxColumn Column5;
		private Button btnQuit;
		private Button btnDel;
		private Button btnUpdate;
		private Button btnAdd;
		private GroupBox groupBox1;
		private DataGridView dataGridView1;
		private TextBox textBox_Converter;
		private Label label2;
		private Container components;
		public ctFormConverterLibManage(KLineTestProcessor gltProcessor)
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
		private void ~ctFormConverterLibManage()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormConverterLibManage));
			this.btnQuit = new Button();
			this.btnDel = new Button();
			this.btnUpdate = new Button();
			this.btnAdd = new Button();
			this.groupBox1 = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.textBox_Converter = new TextBox();
			this.label2 = new Label();
			this.comboBox_sxtj = new ComboBox();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(548, 527);
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
			System.Drawing.Point location2 = new System.Drawing.Point(418, 527);
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
			System.Drawing.Point location3 = new System.Drawing.Point(287, 527);
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
			System.Drawing.Point location4 = new System.Drawing.Point(157, 527);
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
			System.Drawing.Size size5 = new System.Drawing.Size(767, 447);
			this.groupBox1.Size = size5;
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "转接工装列表";
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
			System.Drawing.Size size6 = new System.Drawing.Size(763, 426);
			this.dataGridView1.Size = size6;
			this.dataGridView1.TabIndex = 9;
			this.dataGridView1.MouseDoubleClick += new MouseEventHandler(this.dataGridView1_MouseDoubleClick);
			this.Column1.HeaderText = "序号";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 76;
			this.Column2.HeaderText = "转接工装代号";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 190;
			this.Column4.HeaderText = "转接型号";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Width = 190;
			this.Column5.HeaderText = "备注";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Width = 130;
			this.textBox_Converter.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_Converter.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(266, 19);
			this.textBox_Converter.Location = location7;
			Padding margin7 = new Padding(2);
			this.textBox_Converter.Margin = margin7;
			this.textBox_Converter.Name = "textBox_Converter";
			System.Drawing.Size size7 = new System.Drawing.Size(480, 24);
			this.textBox_Converter.Size = size7;
			this.textBox_Converter.TabIndex = 5;
			this.textBox_Converter.TextChanged += new System.EventHandler(this.textBox_Converter_TextChanged);
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
				"转接工装代号",
				"转接型号"
			};
			this.comboBox_sxtj.Items.AddRange(items);
			System.Drawing.Point location9 = new System.Drawing.Point(115, 20);
			this.comboBox_sxtj.Location = location9;
			this.comboBox_sxtj.Name = "comboBox_sxtj";
			System.Drawing.Size size9 = new System.Drawing.Size(140, 22);
			this.comboBox_sxtj.Size = size9;
			this.comboBox_sxtj.TabIndex = 11;
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
			base.Controls.Add(this.textBox_Converter);
			base.Controls.Add(this.label2);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin9 = new Padding(2);
			base.Margin = margin9;
			base.Name = "ctFormConverterLibManage";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "转接工装库管理";
			base.Load += new System.EventHandler(this.ctFormConverterLibManage_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormConverterLibManage_SizeChanged);
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
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 610;
					int ia = 0;
					if (iw > 0)
					{
						ia = iw / 3;
					}
					this.dataGridView1.Columns[0].Width = 76;
					int width = ia + 190;
					this.dataGridView1.Columns[1].Width = width;
					this.dataGridView1.Columns[2].Width = width;
					this.dataGridView1.Columns[3].Width = ia + 130;
				}
			}
			catch (System.Exception arg_95_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_95_0.StackTrace);
			}
		}
		private void ctFormConverterLibManage_SizeChanged(object sender, System.EventArgs e)
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
					dataReader = new OleDbCommand("select * from TConverterLibrary order by ID", connection).ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView1.Rows.Add(1);
						int num = inum + 1;
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
						this.strIDArray[inum] = dataReader["ID"].ToString();
						this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["ConverterName"].ToString();
						this.dataGridView1.Rows[inum].Cells[2].Value = dataReader["ConverterType"].ToString();
						this.dataGridView1.Rows[inum].Cells[3].Value = dataReader["Remark"].ToString();
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
				catch (System.Exception arg_183_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_183_0.StackTrace);
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
			catch (System.Exception arg_1A7_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1A7_0.StackTrace);
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
				string cNameStr = this.textBox_Converter.Text.ToString().Trim();
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					if (this.comboBox_sxtj.SelectedIndex == 0)
					{
						if (string.IsNullOrEmpty(cNameStr))
						{
							sqlcommand = "select * from TConverterLibrary order by ConverterName";
						}
						else
						{
							sqlcommand = "select * from TConverterLibrary where ConverterName like '%" + cNameStr + "%' order by ConverterName";
						}
					}
					else if (this.comboBox_sxtj.SelectedIndex == 1)
					{
						if (string.IsNullOrEmpty(cNameStr))
						{
							sqlcommand = "select * from TConverterLibrary order by ConverterType";
						}
						else
						{
							sqlcommand = "select * from TConverterLibrary where ConverterType like '%" + cNameStr + "%' order by ConverterType";
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
						this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["ConverterName"].ToString();
						this.dataGridView1.Rows[inum].Cells[2].Value = dataReader["ConverterType"].ToString();
						this.dataGridView1.Rows[inum].Cells[3].Value = dataReader["Remark"].ToString();
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
				catch (System.Exception arg_208_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_208_0.StackTrace);
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
			catch (System.Exception arg_22C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_22C_0.StackTrace);
			}
		}
		private void ctFormConverterLibManage_Load(object sender, System.EventArgs e)
		{
			try
			{
				try
				{
					this.comboBox_sxtj.SelectedIndex = 0;
					this.textBox_Converter.Text = "";
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
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormAddConverter this2 = new ctFormAddConverter(this.gLineTestProcessor, this.loginUser);
				this.addConverterForm = this2;
				this2.Activate();
				this.addConverterForm.ShowDialog();
				if (this.addConverterForm.bAddSuccFlag)
				{
					this.RefreshDataGridView();
				}
			}
			catch (System.Exception arg_40_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_40_0.StackTrace);
			}
		}
		public void QueryUpdateConverterInfoFunc(int iIndex, int iEditPid)
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
					dataReader = new OleDbCommand("select top 1 * from TConverterLibrary where ID=" + iEditPid, connection).ExecuteReader();
					if (dataReader.Read())
					{
						this.dataGridView1.Rows[iIndex].Cells[1].Value = dataReader["ConverterName"].ToString();
						this.dataGridView1.Rows[iIndex].Cells[2].Value = dataReader["ConverterType"].ToString();
						this.dataGridView1.Rows[iIndex].Cells[3].Value = dataReader["Remark"].ToString();
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
					ctFormEditConverter this2 = new ctFormEditConverter(this.gLineTestProcessor, this.loginUser, iPid);
					this.editConverterForm = this2;
					this2.Activate();
					this.editConverterForm.ShowDialog();
					this.QueryUpdateConverterInfoFunc(e2, iPid);
				}
			}
			catch (System.Exception arg_9D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_9D_0.StackTrace);
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
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			try
			{
				if (this.dataGridView1.SelectedRows.Count <= 0)
				{
					return;
				}
				if (DialogResult.Cancel == MessageBox.Show("您确认要删除该转接工装吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
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
					string sqlcommand = "delete from TConverterLibrary where ID =" + iID;
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					cmd.ExecuteNonQuery();
					System.Threading.Thread.Sleep(100);
					sqlcommand = "delete from TConverterLibraryDetail where CLID='" + this.strIDArray[num] + "'";
					cmd = new OleDbCommand(sqlcommand, connection);
					cmd.ExecuteNonQuery();
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_EC_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_EC_0.StackTrace);
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
			}
			catch (System.Exception arg_105_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_105_0.StackTrace);
			}
			this.RefreshDataGridView();
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
		private void textBox_Converter_TextChanged(object sender, System.EventArgs e)
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
		private void comboBox_sxtj_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.textBox_Converter.Text = "";
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormConverterLibManage();
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
