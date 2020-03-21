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
	public class ctFormProjectOpen : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public ctFormProjectEdit editProjectForm;
		public ctFormProjectCopy copyProjectForm;
		public ctFormWait waitFinishedForm;
		public string dbpath;
		public string loginUser;
		public int iCopyProjextID;
		public bool bCopySuccFlag;
		public string[] strIDArray;
		public bool bOpenProjectFlag;
		public string testProjectNameStr;
		public string ct_TestBCXSStr;
		private Button btnCopy;
		private Button btnEditProject;
		private Button btnQuit;
		private GroupBox groupBox_project;
		private DataGridView dataGridView1;
		private TextBox textBox_Project;
		private Label label23;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn Column5;
		private DataGridViewTextBoxColumn Column6;
		private DataGridViewTextBoxColumn Column3;
		private DataGridViewTextBoxColumn Column4;
		private Button btnOpenProject;
		private Button btnDelProject;
		private Container components;
		public ctFormProjectOpen(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.strIDArray = new string[5000];
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
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
		private void ~ctFormProjectOpen()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormProjectOpen));
			this.btnEditProject = new Button();
			this.btnQuit = new Button();
			this.groupBox_project = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.Column6 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.textBox_Project = new TextBox();
			this.label23 = new Label();
			this.btnOpenProject = new Button();
			this.btnDelProject = new Button();
			this.btnCopy = new Button();
			this.groupBox_project.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
			this.btnEditProject.Anchor = AnchorStyles.Bottom;
			this.btnEditProject.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(202, 525);
			this.btnEditProject.Location = location;
			Padding margin = new Padding(2);
			this.btnEditProject.Margin = margin;
			this.btnEditProject.Name = "btnEditProject";
			System.Drawing.Size size = new System.Drawing.Size(101, 24);
			this.btnEditProject.Size = size;
			this.btnEditProject.TabIndex = 1;
			this.btnEditProject.Text = "编辑项目";
			this.btnEditProject.UseVisualStyleBackColor = true;
			this.btnEditProject.Click += new System.EventHandler(this.btnEditProject_Click);
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(637, 525);
			this.btnQuit.Location = location2;
			Padding margin2 = new Padding(2);
			this.btnQuit.Margin = margin2;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size2 = new System.Drawing.Size(101, 24);
			this.btnQuit.Size = size2;
			this.btnQuit.TabIndex = 3;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.groupBox_project.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox_project.Controls.Add(this.dataGridView1);
			this.groupBox_project.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(11, 51);
			this.groupBox_project.Location = location3;
			Padding margin3 = new Padding(2);
			this.groupBox_project.Margin = margin3;
			this.groupBox_project.Name = "groupBox_project";
			Padding padding = new Padding(2);
			this.groupBox_project.Padding = padding;
			System.Drawing.Size size3 = new System.Drawing.Size(771, 450);
			this.groupBox_project.Size = size3;
			this.groupBox_project.TabIndex = 9;
			this.groupBox_project.TabStop = false;
			this.groupBox_project.Text = "项目列表（双击可打开项目）";
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
				this.Column5,
				this.Column6,
				this.Column3,
				this.Column4
			};
			this.dataGridView1.Columns.AddRange(dataGridViewColumns);
			this.dataGridView1.Dock = DockStyle.Fill;
			System.Drawing.Point location4 = new System.Drawing.Point(2, 19);
			this.dataGridView1.Location = location4;
			Padding margin4 = new Padding(2);
			this.dataGridView1.Margin = margin4;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size4 = new System.Drawing.Size(767, 429);
			this.dataGridView1.Size = size4;
			this.dataGridView1.TabIndex = 5;
			this.dataGridView1.MouseDoubleClick += new MouseEventHandler(this.dataGridView1_MouseDoubleClick);
			this.Column1.HeaderText = "序号";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 72;
			this.Column2.HeaderText = "项目名称";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 150;
			this.Column5.HeaderText = "被测线束";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Width = 150;
			this.Column6.HeaderText = "批次号";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column6.Width = 120;
			this.Column3.HeaderText = "常用项目";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 130;
			this.Column4.HeaderText = "备注";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Width = 150;
			this.textBox_Project.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_Project.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(128, 14);
			this.textBox_Project.Location = location5;
			Padding margin5 = new Padding(2);
			this.textBox_Project.Margin = margin5;
			this.textBox_Project.Name = "textBox_Project";
			System.Drawing.Size size5 = new System.Drawing.Size(563, 24);
			this.textBox_Project.Size = size5;
			this.textBox_Project.TabIndex = 4;
			this.textBox_Project.TextChanged += new System.EventHandler(this.textBox_Project_TextChanged);
			this.label23.AutoSize = true;
			this.label23.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(47, 18);
			this.label23.Location = location6;
			Padding margin6 = new Padding(2, 0, 2, 0);
			this.label23.Margin = margin6;
			this.label23.Name = "label23";
			System.Drawing.Size size6 = new System.Drawing.Size(75, 15);
			this.label23.Size = size6;
			this.label23.TabIndex = 17;
			this.label23.Text = "项目筛选:";
			this.btnOpenProject.Anchor = AnchorStyles.Bottom;
			this.btnOpenProject.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(58, 525);
			this.btnOpenProject.Location = location7;
			Padding margin7 = new Padding(2);
			this.btnOpenProject.Margin = margin7;
			this.btnOpenProject.Name = "btnOpenProject";
			System.Drawing.Size size7 = new System.Drawing.Size(101, 24);
			this.btnOpenProject.Size = size7;
			this.btnOpenProject.TabIndex = 0;
			this.btnOpenProject.Text = "打开项目";
			this.btnOpenProject.UseVisualStyleBackColor = true;
			this.btnOpenProject.Click += new System.EventHandler(this.btnOpenProject_Click);
			this.btnDelProject.Anchor = AnchorStyles.Bottom;
			this.btnDelProject.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(492, 525);
			this.btnDelProject.Location = location8;
			Padding margin8 = new Padding(2);
			this.btnDelProject.Margin = margin8;
			this.btnDelProject.Name = "btnDelProject";
			System.Drawing.Size size8 = new System.Drawing.Size(101, 24);
			this.btnDelProject.Size = size8;
			this.btnDelProject.TabIndex = 2;
			this.btnDelProject.Text = "删除项目";
			this.btnDelProject.UseVisualStyleBackColor = true;
			this.btnDelProject.Click += new System.EventHandler(this.btnDelProject_Click);
			this.btnCopy.Anchor = AnchorStyles.Bottom;
			this.btnCopy.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(347, 525);
			this.btnCopy.Location = location9;
			Padding margin9 = new Padding(2);
			this.btnCopy.Margin = margin9;
			this.btnCopy.Name = "btnCopy";
			System.Drawing.Size size9 = new System.Drawing.Size(101, 24);
			this.btnCopy.Size = size9;
			this.btnCopy.TabIndex = 18;
			this.btnCopy.Text = "复制项目";
			this.btnCopy.UseVisualStyleBackColor = true;
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.btnCopy);
			base.Controls.Add(this.textBox_Project);
			base.Controls.Add(this.label23);
			base.Controls.Add(this.btnOpenProject);
			base.Controls.Add(this.btnDelProject);
			base.Controls.Add(this.btnEditProject);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.groupBox_project);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin10 = new Padding(2);
			base.Margin = margin10;
			base.Name = "ctFormProjectOpen";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "项目管理";
			base.Load += new System.EventHandler(this.ctFormProjectOpen_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormProjectOpen_SizeChanged);
			this.groupBox_project.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 737;
					int iy = 0;
					if (iw > 0)
					{
						iw /= 2;
						iy = iw % 2;
					}
					this.dataGridView1.Columns[0].Width = iy + 63;
					int width = iw + 140;
					this.dataGridView1.Columns[1].Width = width;
					this.dataGridView1.Columns[2].Width = width;
					this.dataGridView1.Columns[3].Width = 130;
					this.dataGridView1.Columns[4].Width = 120;
					this.dataGridView1.Columns[5].Width = 120;
				}
			}
			catch (System.Exception arg_C9_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_C9_0.StackTrace);
			}
		}
		private void ctFormProjectOpen_SizeChanged(object sender, System.EventArgs e)
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
		private void ctFormProjectOpen_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.bOpenProjectFlag = false;
				this.testProjectNameStr = "";
				this.ct_TestBCXSStr = "";
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
			catch (System.Exception arg_AB_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_AB_0.StackTrace);
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
			catch (System.Exception arg_117_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_117_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
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
					dataReader = new OleDbCommand("select top " + 5000 + " * from TProjectInfo order by ID desc", connection).ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView1.Rows.Add(1);
						int num = inum + 1;
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
						this.strIDArray[inum] = dataReader["ID"].ToString();
						this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["ProjectName"].ToString();
						string cpStr = dataReader["iCommonProject"].ToString();
						if (cpStr == "1")
						{
							this.dataGridView1.Rows[inum].Cells[4].Value = "是";
						}
						else
						{
							this.dataGridView1.Rows[inum].Cells[4].Value = "否";
						}
						this.dataGridView1.Rows[inum].Cells[3].Value = dataReader["batchMumberStr"].ToString();
						this.dataGridView1.Rows[inum].Cells[2].Value = dataReader["bcCableName"].ToString();
						this.dataGridView1.Rows[inum].Cells[5].Value = dataReader["Remark"].ToString();
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
				catch (System.Exception arg_23B_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_23B_0.StackTrace);
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
			catch (System.Exception arg_25F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_25F_0.StackTrace);
			}
		}
		public void GLDealwithFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				string pnStr = this.textBox_Project.Text.ToString().Trim();
				this.dataGridView1.Rows.Clear();
				int inum = 0;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand((!string.IsNullOrEmpty(pnStr)) ? ("select * from TProjectInfo where ProjectName like '%" + pnStr + "%' order by ID desc") : "select * from TProjectInfo order by ID desc", connection).ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView1.Rows.Add(1);
						int num = inum + 1;
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
						this.strIDArray[inum] = dataReader["ID"].ToString();
						this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["ProjectName"].ToString();
						string cpStr = dataReader["iCommonProject"].ToString();
						if (cpStr == "1")
						{
							this.dataGridView1.Rows[inum].Cells[4].Value = "是";
						}
						else
						{
							this.dataGridView1.Rows[inum].Cells[4].Value = "否";
						}
						this.dataGridView1.Rows[inum].Cells[3].Value = dataReader["batchMumberStr"].ToString();
						this.dataGridView1.Rows[inum].Cells[2].Value = dataReader["bcCableName"].ToString();
						this.dataGridView1.Rows[inum].Cells[5].Value = dataReader["Remark"].ToString();
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
				catch (System.Exception arg_25A_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_25A_0.StackTrace);
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
			catch (System.Exception arg_27E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_27E_0.StackTrace);
			}
		}
		private void textBox_Project_TextChanged(object sender, System.EventArgs e)
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
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			this.bOpenProjectFlag = false;
			this.testProjectNameStr = "";
			base.Close();
		}
		private void btnOpenProject_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count <= 0 || this.dataGridView1.Rows.Count <= 0)
				{
					MessageBox.Show("未选择待操作项目!", "提示", MessageBoxButtons.OK);
					return;
				}
				string temp1Str = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
				string temp2Str = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
				this.testProjectNameStr = temp1Str;
				this.ct_TestBCXSStr = temp2Str;
				this.bOpenProjectFlag = true;
			}
			catch (System.Exception arg_A1_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_A1_0.StackTrace);
			}
			base.Close();
		}
		public void QueryUpdateProjectInfoFunc(int iIndex, int iEditPid)
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
					dataReader = new OleDbCommand("select top 1 * from TProjectInfo where ID=" + iEditPid, connection).ExecuteReader();
					if (dataReader.Read())
					{
						string cpStr = dataReader["iCommonProject"].ToString();
						if (cpStr == "1")
						{
							this.dataGridView1.Rows[iIndex].Cells[4].Value = "是";
						}
						else
						{
							this.dataGridView1.Rows[iIndex].Cells[4].Value = "否";
						}
						this.dataGridView1.Rows[iIndex].Cells[3].Value = dataReader["batchMumberStr"].ToString();
						this.dataGridView1.Rows[iIndex].Cells[2].Value = dataReader["bcCableName"].ToString();
						this.dataGridView1.Rows[iIndex].Cells[5].Value = dataReader["Remark"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_15F_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_15F_0.StackTrace);
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
			catch (System.Exception arg_183_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_183_0.StackTrace);
			}
		}
		private void btnEditProject_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.Rows.Count > 0)
				{
					int e2 = System.Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString()) - 1;
					int iPid = System.Convert.ToInt32(this.strIDArray[e2]);
					ctFormProjectEdit this2 = new ctFormProjectEdit(this.gLineTestProcessor, iPid);
					this.editProjectForm = this2;
					this2.Activate();
					this.editProjectForm.ShowDialog();
					this.QueryUpdateProjectInfoFunc(e2, iPid);
				}
				else
				{
					MessageBox.Show("未选择待操作项目!", "提示", MessageBoxButtons.OK);
				}
			}
			catch (System.Exception arg_A8_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_A8_0.StackTrace);
			}
		}
		private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			try
			{
				this.btnOpenProject_Click(sender, e);
			}
			catch (System.Exception arg_0A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_0A_0.StackTrace);
			}
		}
		private void btnDelProject_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.Rows.Count > 0)
				{
					if (DialogResult.OK == MessageBox.Show("您确定删除项目信息吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
					{
						int iPIDIndex = System.Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
						int iPid = System.Convert.ToInt32(this.strIDArray[iPIDIndex - 1]);
						try
						{
							connection = new OleDbConnection();
							connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
							connection.Open();
							string sqlcommand = "delete from TProjectInfo where ID=" + iPid + "";
							OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
							cmd.ExecuteNonQuery();
							System.Threading.Thread.Sleep(100);
							try
							{
								sqlcommand = "delete from TGroupTestParaSet where PID='" + System.Convert.ToString(iPid) + "'";
								cmd = new OleDbCommand(sqlcommand, connection);
								cmd.ExecuteNonQuery();
							}
							catch (System.Exception arg_100_0)
							{
								KLineTestProcessor.ExceptionRecordFunc(arg_100_0.StackTrace);
							}
							connection.Close();
							connection = null;
						}
						catch (System.Exception arg_116_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_116_0.StackTrace);
							if (connection != null)
							{
								connection.Close();
								connection = null;
							}
						}
						this.RefreshDataGridView();
					}
				}
				else
				{
					MessageBox.Show("未选择待操作项目!", "提示", MessageBoxButtons.OK);
				}
			}
			catch (System.Exception arg_148_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_148_0.StackTrace);
			}
		}
		public void CopyProjectDisposeFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			OleDbConnection connection2 = null;
			this.bCopySuccFlag = true;
			string tempPNStr = "新项目_20001231_121314";
			string text = "0";
			string nPIDStr = text;
			string nLIDStr = text;
			TProjectInfoStruct projectInfoStruct = new TProjectInfoStruct();
			System.Collections.Generic.List<GroupTestParaStruct> GTParaStructList = new System.Collections.Generic.List<GroupTestParaStruct>();
			try
			{
				System.ValueType dt = System.DateTime.Now;
				string tempMonthStr;
				if (((System.DateTime)dt).Month < 10)
				{
					tempMonthStr = "0" + System.Convert.ToString(((System.DateTime)dt).Month);
				}
				else
				{
					tempMonthStr = System.Convert.ToString(((System.DateTime)dt).Month);
				}
				string tempDayStr;
				if (((System.DateTime)dt).Day < 10)
				{
					tempDayStr = "0" + System.Convert.ToString(((System.DateTime)dt).Day);
				}
				else
				{
					tempDayStr = System.Convert.ToString(((System.DateTime)dt).Day);
				}
				string tempHourStr;
				if (((System.DateTime)dt).Hour < 10)
				{
					tempHourStr = "0" + System.Convert.ToString(((System.DateTime)dt).Hour);
				}
				else
				{
					tempHourStr = System.Convert.ToString(((System.DateTime)dt).Hour);
				}
				string tempMinuteStr;
				if (((System.DateTime)dt).Minute < 10)
				{
					tempMinuteStr = "0" + System.Convert.ToString(((System.DateTime)dt).Minute);
				}
				else
				{
					tempMinuteStr = System.Convert.ToString(((System.DateTime)dt).Minute);
				}
				string tempSecondStr;
				if (((System.DateTime)dt).Second < 10)
				{
					tempSecondStr = "0" + System.Convert.ToString(((System.DateTime)dt).Second);
				}
				else
				{
					tempSecondStr = System.Convert.ToString(((System.DateTime)dt).Second);
				}
				string tt = System.Convert.ToString(((System.DateTime)dt).Year) + tempMonthStr + tempDayStr;
				string ttms = tempHourStr + tempMinuteStr + tempSecondStr;
				tempPNStr = "新项目_" + tt + "_" + ttms;
			}
			catch (System.Exception arg_1F7_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1F7_0.StackTrace);
			}
			try
			{
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "select top 1 * from TProjectInfo where ID=" + this.iCopyProjextID;
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						projectInfoStruct.iID = System.Convert.ToInt32(dataReader["ID"].ToString());
						projectInfoStruct.ProjectName = dataReader["ProjectName"].ToString();
						projectInfoStruct.iCommonProject = System.Convert.ToInt32(dataReader["iCommonProject"].ToString());
						projectInfoStruct.iTestModel = System.Convert.ToInt32(dataReader["iTestModel"].ToString());
						projectInfoStruct.iDTTestModel = System.Convert.ToInt32(dataReader["iDTTestModel"].ToString());
						projectInfoStruct.iJYTestModel = System.Convert.ToInt32(dataReader["iJYTestModel"].ToString());
						projectInfoStruct.iNYTestModel = System.Convert.ToInt32(dataReader["iNYTestModel"].ToString());
						projectInfoStruct.dDT_Threshold = System.Convert.ToDouble(dataReader["dDT_Threshold"].ToString());
						projectInfoStruct.dDT_DTVoltage = System.Convert.ToDouble(dataReader["dDT_DTVoltage"].ToString());
						projectInfoStruct.dDT_DTCurrent = System.Convert.ToDouble(dataReader["dDT_DTCurrent"].ToString());
						projectInfoStruct.dJY_Threshold = System.Convert.ToDouble(dataReader["dJY_Threshold"].ToString());
						projectInfoStruct.dJY_JYHoldTime = System.Convert.ToDouble(dataReader["dJY_JYHoldTime"].ToString());
						projectInfoStruct.dJY_DCHighVolt = System.Convert.ToDouble(dataReader["dJY_DCHighVolt"].ToString());
						projectInfoStruct.dJY_DCRiseTime = System.Convert.ToDouble(dataReader["dJY_DCRiseTime"].ToString());
						projectInfoStruct.dNY_Threshold = System.Convert.ToDouble(dataReader["dNY_Threshold"].ToString());
						projectInfoStruct.dNY_NYHoldTime = System.Convert.ToDouble(dataReader["dNY_NYHoldTime"].ToString());
						projectInfoStruct.dNY_ACHighVolt = System.Convert.ToDouble(dataReader["dNY_ACHighVolt"].ToString());
						projectInfoStruct.other1 = System.Convert.ToDouble(dataReader["other1"].ToString());
						projectInfoStruct.other2 = System.Convert.ToDouble(dataReader["other2"].ToString());
						projectInfoStruct.iGroupTestFlag = System.Convert.ToInt32(dataReader["iGroupTestFlag"].ToString());
						projectInfoStruct.batchMumberStr = dataReader["batchMumberStr"].ToString();
						projectInfoStruct.bcCableName = dataReader["bcCableName"].ToString();
						projectInfoStruct.Creator = dataReader["Creator"].ToString();
						projectInfoStruct.Remark = dataReader["Remark"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					projectInfoStruct.ProjectName = tempPNStr;
					string loginUserID = this.gLineTestProcessor.loginUserID;
					projectInfoStruct.Creator = loginUserID;
					string str = "','";
					string bcCableName = projectInfoStruct.bcCableName;
					int iGroupTestFlag = projectInfoStruct.iGroupTestFlag;
					string str2 = ",";
					sqlcommand = "insert into TProjectInfo(ProjectName,iCommonProject,iTestModel,iDTTestModel,iJYTestModel,iNYTestModel,dDT_Threshold,dDT_DTVoltage,dDT_DTCurrent,dJY_Threshold," + "dJY_JYHoldTime,dJY_DCHighVolt,dJY_DCRiseTime,dNY_Threshold,dNY_NYHoldTime,dNY_ACHighVolt,other1,other2,iGroupTestFlag,batchMumberStr,bcCableName,Creator,Remark) values('" + tempPNStr + "'," + projectInfoStruct.iCommonProject + str2 + projectInfoStruct.iTestModel + str2 + projectInfoStruct.iDTTestModel + str2 + projectInfoStruct.iJYTestModel + str2 + projectInfoStruct.iNYTestModel + str2 + projectInfoStruct.dDT_Threshold + str2 + projectInfoStruct.dDT_DTVoltage + str2 + projectInfoStruct.dDT_DTCurrent + str2 + projectInfoStruct.dJY_Threshold + str2 + projectInfoStruct.dJY_JYHoldTime + str2 + projectInfoStruct.dJY_DCHighVolt + str2 + projectInfoStruct.dJY_DCRiseTime + str2 + projectInfoStruct.dNY_Threshold + str2 + projectInfoStruct.dNY_NYHoldTime + str2 + projectInfoStruct.dNY_ACHighVolt + str2 + projectInfoStruct.other1 + str2 + projectInfoStruct.other2 + str2 + iGroupTestFlag + ",'" + projectInfoStruct.batchMumberStr + str + bcCableName + str + loginUserID + str + projectInfoStruct.Remark + "')";
					cmd = new OleDbCommand(sqlcommand, connection);
					cmd.ExecuteNonQuery();
					System.Threading.Thread.Sleep(100);
					sqlcommand = "select top 1 * from TProjectInfo where ProjectName = '" + tempPNStr + "'";
					cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						nPIDStr = dataReader["ID"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					sqlcommand = "select top 1 * from TLineStructLibrary where LineStructName = '" + bcCableName + "'";
					cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						nLIDStr = dataReader["LID"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					if (iGroupTestFlag == 1)
					{
						try
						{
							sqlcommand = "select * from TGroupTestParaSet where PID='" + System.Convert.ToString(projectInfoStruct.iID) + "' and LID='" + nLIDStr + "' order by ID asc";
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							while (dataReader.Read())
							{
								GTParaStructList.Add(new GroupTestParaStruct
								{
									PlugName1 = dataReader["PlugName1"].ToString(),
									PinName1 = dataReader["PinName1"].ToString(),
									PlugName2 = dataReader["PlugName2"].ToString(),
									PinName2 = dataReader["PinName2"].ToString(),
									DTThreshold = dataReader["DTThreshold"].ToString(),
									DTVoltage = dataReader["DTVoltage"].ToString(),
									DTCurrent = dataReader["DTCurrent"].ToString(),
									JYThreshold = dataReader["JYThreshold"].ToString(),
									JYTestTime = dataReader["JYTestTime"].ToString(),
									JYVoltage = dataReader["JYVoltage"].ToString(),
									JYUpTime = dataReader["JYUpTime"].ToString(),
									NYThreshold = dataReader["NYThreshold"].ToString(),
									NYTestTime = dataReader["NYTestTime"].ToString(),
									NYVoltage = dataReader["NYVoltage"].ToString()
								});
							}
							dataReader.Close();
							dataReader = null;
							for (int i = 0; i < GTParaStructList.Count; i++)
							{
								str = "','";
								sqlcommand = "insert into TGroupTestParaSet(PID,LID,PlugName1,PinName1,PlugName2,PinName2,DTThreshold,DTVoltage," + "DTCurrent,JYThreshold,JYTestTime,JYVoltage,JYUpTime,NYThreshold,NYTestTime,NYVoltage) values('" + nPIDStr + str + nLIDStr + str + GTParaStructList[i].PlugName1 + "','" + GTParaStructList[i].PinName1 + "','" + GTParaStructList[i].PlugName2 + "','" + GTParaStructList[i].PinName2 + "','" + GTParaStructList[i].DTThreshold + "','" + GTParaStructList[i].DTVoltage + "','" + GTParaStructList[i].DTCurrent + "','" + GTParaStructList[i].JYThreshold + "','" + GTParaStructList[i].JYTestTime + "','" + GTParaStructList[i].JYVoltage + "','" + GTParaStructList[i].JYUpTime + "','" + GTParaStructList[i].NYThreshold + "','" + GTParaStructList[i].NYTestTime + "','" + GTParaStructList[i].NYVoltage + "')";
								cmd = new OleDbCommand(sqlcommand, connection);
								cmd.ExecuteNonQuery();
							}
						}
						catch (System.Exception arg_B4F_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_B4F_0.StackTrace);
							if (dataReader != null)
							{
								dataReader.Close();
								dataReader = null;
							}
						}
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_B79_0)
				{
					this.bCopySuccFlag = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_B79_0.StackTrace);
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
			catch (System.Exception arg_BA7_0)
			{
				this.bCopySuccFlag = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_BA7_0.StackTrace);
			}
			if (!this.bCopySuccFlag)
			{
				try
				{
					connection2 = new OleDbConnection();
					connection2.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection2.Open();
					string sqlcommand2 = "delete from TProjectInfo where ProjectName = '" + tempPNStr + "'";
					OleDbCommand cmd2 = new OleDbCommand(sqlcommand2, connection2);
					cmd2.ExecuteNonQuery();
					System.Threading.Thread.Sleep(50);
					sqlcommand2 = "delete from TGroupTestParaSet where PID='" + nPIDStr + "' and LID='" + nLIDStr + "'";
					cmd2 = new OleDbCommand(sqlcommand2, connection2);
					cmd2.ExecuteNonQuery();
					connection2.Close();
					connection2 = null;
				}
				catch (System.Exception arg_C58_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_C58_0.StackTrace);
					if (connection2 != null)
					{
						connection2.Close();
					}
				}
			}
		}
		public void FreeSystemMemoryResourcesFunc()
		{
			try
			{
				System.GC.Collect();
				System.GC.WaitForPendingFinalizers();
			}
			catch (System.Exception arg_0C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_0C_0.StackTrace);
			}
		}
		private void btnCopy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count <= 0 || this.dataGridView1.Rows.Count <= 0)
				{
					MessageBox.Show("未选择待操作项目!", "提示", MessageBoxButtons.OK);
					return;
				}
				int iPIDIndex = System.Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
				int iPid = System.Convert.ToInt32(this.strIDArray[iPIDIndex - 1]);
				this.iCopyProjextID = iPid;
				ctFormProjectCopy this2 = new ctFormProjectCopy(this.gLineTestProcessor, iPid);
				this.copyProjectForm = this2;
				this2.Activate();
				this.copyProjectForm.ShowDialog();
				this.bCopySuccFlag = this.copyProjectForm.bCopySuccFlag;
				this.copyProjectForm = null;
				this.FreeSystemMemoryResourcesFunc();
			}
			catch (System.Exception arg_C8_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_C8_0.StackTrace);
			}
			try
			{
				if (this.bCopySuccFlag)
				{
					this.RefreshDataGridView();
				}
			}
			catch (System.Exception arg_E5_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_E5_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormProjectOpen();
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
