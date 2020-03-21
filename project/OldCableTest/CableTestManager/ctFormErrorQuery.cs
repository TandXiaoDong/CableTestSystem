using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormErrorQuery : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public static int MAX_SHOW_NUM = 100;
		public string loginUser;
		public string dbpath;
		public int iTestTime;
		private Button btnQuit;
		private DataGridView dataGridView1;
		private DataGridViewTextBoxColumn Column_xh;
		private DataGridViewTextBoxColumn Column_startInterface;
		private DataGridViewTextBoxColumn Column_startPin;
		private GroupBox groupBox1;
		private IContainer components;
		public ctFormErrorQuery(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
				}
				catch (System.Exception arg_36_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_36_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormErrorQuery()
		{
			IContainer this2 = this.components;
			if (this2 != null)
			{
				this2.Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormErrorQuery));
			this.btnQuit = new Button();
			this.dataGridView1 = new DataGridView();
			this.Column_xh = new DataGridViewTextBoxColumn();
			this.Column_startInterface = new DataGridViewTextBoxColumn();
			this.Column_startPin = new DataGridViewTextBoxColumn();
			this.groupBox1 = new GroupBox();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(241, 406);
			this.btnQuit.Location = location;
			Padding margin = new Padding(2, 2, 2, 2);
			this.btnQuit.Margin = margin;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size = new System.Drawing.Size(112, 24);
			this.btnQuit.Size = size;
			this.btnQuit.TabIndex = 0;
			this.btnQuit.Text = "确定";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			System.Drawing.Color window = System.Drawing.SystemColors.Window;
			this.dataGridView1.BackgroundColor = window;
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[]
			{
				this.Column_xh,
				this.Column_startInterface,
				this.Column_startPin
			};
			this.dataGridView1.Columns.AddRange(dataGridViewColumns);
			this.dataGridView1.Dock = DockStyle.Fill;
			System.Drawing.Point location2 = new System.Drawing.Point(2, 19);
			this.dataGridView1.Location = location2;
			Padding margin2 = new Padding(2, 2, 2, 2);
			this.dataGridView1.Margin = margin2;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size2 = new System.Drawing.Size(556, 346);
			this.dataGridView1.Size = size2;
			this.dataGridView1.TabIndex = 14;
			this.Column_xh.HeaderText = "序号";
			this.Column_xh.Name = "Column_xh";
			this.Column_xh.ReadOnly = true;
			this.Column_xh.Width = 86;
			this.Column_startInterface.HeaderText = "时间";
			this.Column_startInterface.Name = "Column_startInterface";
			this.Column_startInterface.ReadOnly = true;
			this.Column_startInterface.Width = 180;
			this.Column_startPin.HeaderText = "故障内容";
			this.Column_startPin.Name = "Column_startPin";
			this.Column_startPin.ReadOnly = true;
			this.Column_startPin.Width = 240;
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(17, 18);
			this.groupBox1.Location = location3;
			Padding margin3 = new Padding(2, 2, 2, 2);
			this.groupBox1.Margin = margin3;
			this.groupBox1.Name = "groupBox1";
			Padding padding = new Padding(2, 2, 2, 2);
			this.groupBox1.Padding = padding;
			System.Drawing.Size size3 = new System.Drawing.Size(560, 367);
			this.groupBox1.Size = size3;
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "设备故障列表";
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(594, 451);
			base.ClientSize = clientSize;
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.btnQuit);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin4 = new Padding(2, 2, 2, 2);
			base.Margin = margin4;
			base.Name = "ctFormErrorQuery";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "故障查询";
			base.Load += new System.EventHandler(this.ctFormErrorQuery_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormErrorQuery_SizeChanged);
			((ISupportInitialize)this.dataGridView1).EndInit();
			this.groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 528;
					if (iw < 0)
					{
						iw = 0;
					}
					this.dataGridView1.Columns[0].Width = 84;
					this.dataGridView1.Columns[1].Width = 180;
					this.dataGridView1.Columns[2].Width = iw + 240;
				}
			}
			catch (System.Exception arg_73_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_73_0.StackTrace);
			}
		}
		private void ctFormErrorQuery_SizeChanged(object sender, System.EventArgs e)
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
					dataReader = new OleDbCommand("select * from TEquipmentFaultRecord order by ID desc", connection).ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView1.Rows.Add(1);
						int num = inum + 1;
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
						this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["EFaultTime"].ToString();
						this.dataGridView1.Rows[inum].Cells[2].Value = dataReader["EFaultContent"].ToString();
						inum = num;
						if (inum >= ctFormErrorQuery.MAX_SHOW_NUM)
						{
							break;
						}
					}
					this.dataGridView1.AllowUserToAddRows = false;
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
					if (this.dataGridView1.Rows.Count > 0)
					{
						this.dataGridView1.Rows[0].Selected = false;
					}
				}
				catch (System.Exception ex)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
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
			catch (System.Exception ex2)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex2.StackTrace);
			}
		}
		private void ctFormErrorQuery_Load(object sender, System.EventArgs e)
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
				this.RefreshDataGridView();
			}
			catch (System.Exception arg_94_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_94_0.StackTrace);
			}
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode == 0)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
			catch (System.Exception arg_B7_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_B7_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
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
					this.~ctFormErrorQuery();
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
