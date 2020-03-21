using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class FormUserManage : Form
	{
		public FormAddUser addUserForm;
		public FormUpdateUser updateUserForm;
		public static int MAX_USER_NUM = 1024;
		public string[] userStrArray;
		public string[] nameStrArray;
		public string loginUser;
		public KLineTestProcessor gLineTestProcessor;
		private DataGridView dataGridView1;
		private GroupBox groupBox1;
		private Button btn_addUser;
		private Button btn_delUser;
		private Button btn_updateUser;
		private Button btnQuit;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn Column3;
		private Container components;
		public FormUserManage(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
					this.userStrArray = new string[FormUserManage.MAX_USER_NUM];
					this.nameStrArray = new string[FormUserManage.MAX_USER_NUM];
				}
				catch (System.Exception ex)
				{
					KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~FormUserManage()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(FormUserManage));
			this.dataGridView1 = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.groupBox1 = new GroupBox();
			this.btn_addUser = new Button();
			this.btn_delUser = new Button();
			this.btn_updateUser = new Button();
			this.btnQuit = new Button();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
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
				this.Column3
			};
			this.dataGridView1.Columns.AddRange(dataGridViewColumns);
			this.dataGridView1.Dock = DockStyle.Fill;
			System.Drawing.Point location = new System.Drawing.Point(2, 19);
			this.dataGridView1.Location = location;
			Padding margin = new Padding(2, 2, 2, 2);
			this.dataGridView1.Margin = margin;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size = new System.Drawing.Size(763, 458);
			this.dataGridView1.Size = size;
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.MouseDoubleClick += new MouseEventHandler(this.dataGridView1_MouseDoubleClick);
			this.Column1.HeaderText = "序号";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 70;
			this.Column2.HeaderText = "账号";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 178;
			this.Column3.HeaderText = "姓名";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 180;
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(14, 12);
			this.groupBox1.Location = location2;
			Padding margin2 = new Padding(2, 2, 2, 2);
			this.groupBox1.Margin = margin2;
			this.groupBox1.Name = "groupBox1";
			Padding padding = new Padding(2, 2, 2, 2);
			this.groupBox1.Padding = padding;
			System.Drawing.Size size2 = new System.Drawing.Size(767, 479);
			this.groupBox1.Size = size2;
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "用户列表";
			this.btn_addUser.Anchor = AnchorStyles.Bottom;
			this.btn_addUser.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(152, 514);
			this.btn_addUser.Location = location3;
			Padding margin3 = new Padding(2, 2, 2, 2);
			this.btn_addUser.Margin = margin3;
			this.btn_addUser.Name = "btn_addUser";
			System.Drawing.Size size3 = new System.Drawing.Size(90, 24);
			this.btn_addUser.Size = size3;
			this.btn_addUser.TabIndex = 0;
			this.btn_addUser.Text = "添加";
			this.btn_addUser.UseVisualStyleBackColor = true;
			this.btn_addUser.Click += new System.EventHandler(this.btn_addUser_Click);
			this.btn_delUser.Anchor = AnchorStyles.Bottom;
			this.btn_delUser.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(419, 514);
			this.btn_delUser.Location = location4;
			Padding margin4 = new Padding(2, 2, 2, 2);
			this.btn_delUser.Margin = margin4;
			this.btn_delUser.Name = "btn_delUser";
			System.Drawing.Size size4 = new System.Drawing.Size(90, 24);
			this.btn_delUser.Size = size4;
			this.btn_delUser.TabIndex = 2;
			this.btn_delUser.Text = "删除";
			this.btn_delUser.UseVisualStyleBackColor = true;
			this.btn_delUser.Click += new System.EventHandler(this.btn_delUser_Click);
			this.btn_updateUser.Anchor = AnchorStyles.Bottom;
			this.btn_updateUser.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(286, 514);
			this.btn_updateUser.Location = location5;
			Padding margin5 = new Padding(2, 2, 2, 2);
			this.btn_updateUser.Margin = margin5;
			this.btn_updateUser.Name = "btn_updateUser";
			System.Drawing.Size size5 = new System.Drawing.Size(90, 24);
			this.btn_updateUser.Size = size5;
			this.btn_updateUser.TabIndex = 1;
			this.btn_updateUser.Text = "编辑";
			this.btn_updateUser.UseVisualStyleBackColor = true;
			this.btn_updateUser.Click += new System.EventHandler(this.btn_updateUser_Click);
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(553, 514);
			this.btnQuit.Location = location6;
			Padding margin6 = new Padding(2, 2, 2, 2);
			this.btnQuit.Margin = margin6;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size6 = new System.Drawing.Size(90, 24);
			this.btnQuit.Size = size6;
			this.btnQuit.TabIndex = 3;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.btn_updateUser);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btn_delUser);
			base.Controls.Add(this.btn_addUser);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin7 = new Padding(2, 2, 2, 2);
			base.Margin = margin7;
			base.Name = "FormUserManage";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "用户管理";
			base.Load += new System.EventHandler(this.FormUserManage_Load);
			base.SizeChanged += new System.EventHandler(this.FormUserManage_SizeChanged);
			((ISupportInitialize)this.dataGridView1).EndInit();
			this.groupBox1.ResumeLayout(false);
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
				int iUserCount = 0;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select * from TUser where UEnabled=1 order by UID asc", connection).ExecuteReader();
					while (dataReader.Read())
					{
						string tempStr = dataReader["UEID"].ToString();
						this.userStrArray[iUserCount] = KLineTestProcessor.DecodeDisposeFunc(tempStr);
						this.nameStrArray[iUserCount] = dataReader["UNAME"].ToString();
						iUserCount++;
						if (iUserCount >= FormUserManage.MAX_USER_NUM)
						{
							break;
						}
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception ex)
				{
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
					KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
					goto IL_19E;
				}
				if (iUserCount > 0)
				{
					this.dataGridView1.AllowUserToAddRows = true;
					int num;
					for (int i = 0; i < iUserCount; i = num)
					{
						this.dataGridView1.Rows.Add(1);
						num = i + 1;
						this.dataGridView1.Rows[i].Cells[0].Value = System.Convert.ToString(num);
						this.dataGridView1.Rows[i].Cells[1].Value = this.userStrArray[i];
						this.dataGridView1.Rows[i].Cells[2].Value = this.nameStrArray[i];
					}
					this.dataGridView1.AllowUserToAddRows = false;
				}
				IL_19E:;
			}
			catch (System.Exception ex2)
			{
				this.dataGridView1.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(ex2.StackTrace);
			}
		}
		private void btn_addUser_Click(object sender, System.EventArgs e)
		{
			try
			{
				FormAddUser this2 = new FormAddUser(this.gLineTestProcessor, this.loginUser);
				this.addUserForm = this2;
				this2.Activate();
				this.addUserForm.ShowDialog();
				this.RefreshDataGridView();
			}
			catch (System.Exception ex_33)
			{
			}
		}
		private void btn_updateUser_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.Rows.Count > 0)
				{
					string uStr = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
					FormUpdateUser this2 = new FormUpdateUser(this.gLineTestProcessor, this.loginUser, uStr);
					this.updateUserForm = this2;
					this2.Activate();
					this.updateUserForm.ShowDialog();
					this.RefreshDataGridView();
				}
			}
			catch (System.Exception ex_83)
			{
			}
		}
		private void btn_delUser_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.Rows.Count > 0)
				{
					string userStr = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
					if (DialogResult.Cancel != MessageBox.Show("删除后将无法找回，您确定要删除用户（" + userStr + "）吗?", "提示", MessageBoxButtons.OKCancel))
					{
						string contStr = "删除用户<" + userStr + ">账户信息";
						userStr = KLineTestProcessor.EncrypDisposeFunc(userStr);
						try
						{
							connection = new OleDbConnection();
							connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
							connection.Open();
							new OleDbCommand("delete from TUser where UEID = '" + userStr + "'", connection).ExecuteNonQuery();
							connection.Close();
							connection = null;
						}
						catch (System.Exception arg_ED_0)
						{
							if (connection != null)
							{
								connection.Close();
								connection = null;
							}
							KLineTestProcessor.ExceptionRecordFunc(arg_ED_0.StackTrace);
							goto IL_119;
						}
						this.saveOperationRecord(contStr);
						MessageBox.Show("用户删除成功!", "提示", MessageBoxButtons.OK);
						this.RefreshDataGridView();
						IL_119:;
					}
				}
				else
				{
					MessageBox.Show("没有选择任何记录!", "提示", MessageBoxButtons.OK);
				}
			}
			catch (System.Exception arg_12E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_12E_0.StackTrace);
			}
		}
		private void FormUserManage_Load(object sender, System.EventArgs e)
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
			this.FormUserManage_SizeChanged(null, null);
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
			catch (System.Exception arg_102_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_102_0.StackTrace);
			}
		}
		private void FormUserManage_SizeChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 452;
					if (iw > 0)
					{
						iw /= 2;
					}
					this.dataGridView1.Columns[0].Width = 70;
					this.dataGridView1.Columns[1].Width = iw + 178;
					this.dataGridView1.Columns[2].Width = iw + 180;
				}
			}
			catch (System.Exception ex_77)
			{
			}
		}
		private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			try
			{
				this.btn_updateUser_Click(null, null);
			}
			catch (System.Exception ex_0A)
			{
			}
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			base.Close();
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~FormUserManage();
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
