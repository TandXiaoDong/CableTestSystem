using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormCableInfoView : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public string loginUser;
		public string bcCableStr;
		public string dbpath;
		public int iEditPid;
		private Label label2;
		private TextBox textBox_xsgxs;
		private Label label1;
		private TextBox textBox_bcCable;
		private TabControl tabControl1;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private Button btnQuit;
		private DataGridView dataGridView1;
		private DataGridViewTextBoxColumn Column_xh;
		private DataGridViewTextBoxColumn Column_startInterface;
		private DataGridViewTextBoxColumn Column_startPin;
		private DataGridViewTextBoxColumn Column_stopInterface;
		private DataGridViewTextBoxColumn Column_stopPin;
		private DataGridViewTextBoxColumn Column_isGroundFlag;
		private DataGridViewTextBoxColumn Column_dtTestFlag;
		private DataGridViewTextBoxColumn Column_dlTestFlag;
		private DataGridViewTextBoxColumn Column_jyTestFlag;
		private DataGridViewTextBoxColumn Column_ddjyTestFlag;
		private DataGridViewTextBoxColumn Column_nyTestFlag;
		private DataGridView dataGridView2;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
		private Container components;
		public ctFormCableInfoView(KLineTestProcessor gltProcessor, int iPid, string cableStr)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
					this.iEditPid = iPid;
					this.bcCableStr = cableStr;
				}
				catch (System.Exception arg_2F_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_2F_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormCableInfoView()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormCableInfoView));
			this.label1 = new Label();
			this.textBox_bcCable = new TextBox();
			this.tabControl1 = new TabControl();
			this.tabPage1 = new TabPage();
			this.dataGridView2 = new DataGridView();
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
			this.tabPage2 = new TabPage();
			this.dataGridView1 = new DataGridView();
			this.Column_xh = new DataGridViewTextBoxColumn();
			this.Column_startInterface = new DataGridViewTextBoxColumn();
			this.Column_startPin = new DataGridViewTextBoxColumn();
			this.Column_stopInterface = new DataGridViewTextBoxColumn();
			this.Column_stopPin = new DataGridViewTextBoxColumn();
			this.Column_isGroundFlag = new DataGridViewTextBoxColumn();
			this.Column_dtTestFlag = new DataGridViewTextBoxColumn();
			this.Column_dlTestFlag = new DataGridViewTextBoxColumn();
			this.Column_jyTestFlag = new DataGridViewTextBoxColumn();
			this.Column_ddjyTestFlag = new DataGridViewTextBoxColumn();
			this.Column_nyTestFlag = new DataGridViewTextBoxColumn();
			this.btnQuit = new Button();
			this.label2 = new Label();
			this.textBox_xsgxs = new TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((ISupportInitialize)this.dataGridView2).BeginInit();
			this.tabPage2.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(22, 16);
			this.label1.Location = location;
			Padding margin = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin;
			this.label1.Name = "label1";
			System.Drawing.Size size = new System.Drawing.Size(75, 15);
			this.label1.Size = size;
			this.label1.TabIndex = 1;
			this.label1.Text = "被测线束:";
			this.textBox_bcCable.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_bcCable.BorderStyle = BorderStyle.None;
			this.textBox_bcCable.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(109, 15);
			this.textBox_bcCable.Location = location2;
			Padding margin2 = new Padding(2);
			this.textBox_bcCable.Margin = margin2;
			this.textBox_bcCable.Name = "textBox_bcCable";
			this.textBox_bcCable.ReadOnly = true;
			System.Drawing.Size size2 = new System.Drawing.Size(667, 17);
			this.textBox_bcCable.Size = size2;
			this.textBox_bcCable.TabIndex = 2;
			this.tabControl1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.tabControl1.Appearance = TabAppearance.Buttons;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Size itemSize = new System.Drawing.Size(180, 27);
			this.tabControl1.ItemSize = itemSize;
			System.Drawing.Point location3 = new System.Drawing.Point(4, 81);
			this.tabControl1.Location = location3;
			Padding margin3 = new Padding(2);
			this.tabControl1.Margin = margin3;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			System.Drawing.Size size3 = new System.Drawing.Size(787, 432);
			this.tabControl1.Size = size3;
			this.tabControl1.SizeMode = TabSizeMode.Fixed;
			this.tabControl1.TabIndex = 3;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			this.tabControl1.SizeChanged += new System.EventHandler(this.tabControl1_SizeChanged);
			this.tabPage1.Controls.Add(this.dataGridView2);
			System.Drawing.Point location4 = new System.Drawing.Point(4, 31);
			this.tabPage1.Location = location4;
			Padding margin4 = new Padding(2);
			this.tabPage1.Margin = margin4;
			this.tabPage1.Name = "tabPage1";
			Padding padding = new Padding(2);
			this.tabPage1.Padding = padding;
			System.Drawing.Size size4 = new System.Drawing.Size(779, 397);
			this.tabPage1.Size = size4;
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "线束接口列表";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.AllowUserToResizeColumns = false;
			this.dataGridView2.AllowUserToResizeRows = false;
			System.Drawing.Color window = System.Drawing.SystemColors.Window;
			this.dataGridView2.BackgroundColor = window;
			this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn1,
				this.dataGridViewTextBoxColumn2,
				this.dataGridViewTextBoxColumn8,
				this.dataGridViewTextBoxColumn9
			};
			this.dataGridView2.Columns.AddRange(dataGridViewColumns);
			this.dataGridView2.Dock = DockStyle.Fill;
			System.Drawing.Point location5 = new System.Drawing.Point(2, 2);
			this.dataGridView2.Location = location5;
			Padding margin5 = new Padding(2);
			this.dataGridView2.Margin = margin5;
			this.dataGridView2.MultiSelect = false;
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.RowHeadersVisible = false;
			this.dataGridView2.RowTemplate.Height = 27;
			this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size5 = new System.Drawing.Size(775, 393);
			this.dataGridView2.Size = size5;
			this.dataGridView2.TabIndex = 2;
			this.dataGridView2.SizeChanged += new System.EventHandler(this.dataGridView2_SizeChanged);
			this.dataGridViewTextBoxColumn1.HeaderText = "序号";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn1.Width = 76;
			this.dataGridViewTextBoxColumn2.HeaderText = "接口代号";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 470;
			this.dataGridViewTextBoxColumn8.HeaderText = "接点个数";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.ReadOnly = true;
			this.dataGridViewTextBoxColumn8.Width = 200;
			this.dataGridViewTextBoxColumn9.HeaderText = "备注";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.ReadOnly = true;
			this.dataGridViewTextBoxColumn9.Width = 200;
			this.tabPage2.Controls.Add(this.dataGridView1);
			System.Drawing.Point location6 = new System.Drawing.Point(4, 31);
			this.tabPage2.Location = location6;
			Padding margin6 = new Padding(2);
			this.tabPage2.Margin = margin6;
			this.tabPage2.Name = "tabPage2";
			Padding padding2 = new Padding(2);
			this.tabPage2.Padding = padding2;
			System.Drawing.Size size6 = new System.Drawing.Size(779, 397);
			this.tabPage2.Size = size6;
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "线束关系列表";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			System.Drawing.Color window2 = System.Drawing.SystemColors.Window;
			this.dataGridView1.BackgroundColor = window2;
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns2 = new DataGridViewColumn[]
			{
				this.Column_xh,
				this.Column_startInterface,
				this.Column_startPin,
				this.Column_stopInterface,
				this.Column_stopPin,
				this.Column_isGroundFlag,
				this.Column_dtTestFlag,
				this.Column_dlTestFlag,
				this.Column_jyTestFlag,
				this.Column_ddjyTestFlag,
				this.Column_nyTestFlag
			};
			this.dataGridView1.Columns.AddRange(dataGridViewColumns2);
			this.dataGridView1.Dock = DockStyle.Fill;
			System.Drawing.Point location7 = new System.Drawing.Point(2, 2);
			this.dataGridView1.Location = location7;
			Padding margin7 = new Padding(2);
			this.dataGridView1.Margin = margin7;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size7 = new System.Drawing.Size(775, 393);
			this.dataGridView1.Size = size7;
			this.dataGridView1.TabIndex = 15;
			this.dataGridView1.SizeChanged += new System.EventHandler(this.dataGridView1_SizeChanged);
			this.Column_xh.HeaderText = "序号";
			this.Column_xh.Name = "Column_xh";
			this.Column_xh.ReadOnly = true;
			this.Column_xh.Width = 86;
			this.Column_startInterface.HeaderText = "起点接口";
			this.Column_startInterface.Name = "Column_startInterface";
			this.Column_startInterface.ReadOnly = true;
			this.Column_startInterface.Width = 110;
			this.Column_startPin.HeaderText = "起点接点";
			this.Column_startPin.Name = "Column_startPin";
			this.Column_startPin.ReadOnly = true;
			this.Column_startPin.Width = 110;
			this.Column_stopInterface.HeaderText = "终点接口";
			this.Column_stopInterface.Name = "Column_stopInterface";
			this.Column_stopInterface.ReadOnly = true;
			this.Column_stopInterface.Width = 110;
			this.Column_stopPin.HeaderText = "终点接点";
			this.Column_stopPin.Name = "Column_stopPin";
			this.Column_stopPin.ReadOnly = true;
			this.Column_stopPin.Width = 110;
			this.Column_isGroundFlag.HeaderText = "接地";
			this.Column_isGroundFlag.Name = "Column_isGroundFlag";
			this.Column_isGroundFlag.ReadOnly = true;
			this.Column_dtTestFlag.HeaderText = "导通测试";
			this.Column_dtTestFlag.Name = "Column_dtTestFlag";
			this.Column_dtTestFlag.ReadOnly = true;
			this.Column_dtTestFlag.Width = 110;
			this.Column_dlTestFlag.HeaderText = "短路测试";
			this.Column_dlTestFlag.Name = "Column_dlTestFlag";
			this.Column_dlTestFlag.ReadOnly = true;
			this.Column_dlTestFlag.Width = 110;
			this.Column_jyTestFlag.HeaderText = "绝缘测试";
			this.Column_jyTestFlag.Name = "Column_jyTestFlag";
			this.Column_jyTestFlag.ReadOnly = true;
			this.Column_jyTestFlag.Width = 110;
			this.Column_ddjyTestFlag.HeaderText = "对地绝缘";
			this.Column_ddjyTestFlag.Name = "Column_ddjyTestFlag";
			this.Column_ddjyTestFlag.ReadOnly = true;
			this.Column_ddjyTestFlag.Width = 110;
			this.Column_nyTestFlag.HeaderText = "耐压测试";
			this.Column_nyTestFlag.Name = "Column_nyTestFlag";
			this.Column_nyTestFlag.ReadOnly = true;
			this.Column_nyTestFlag.Width = 110;
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(341, 528);
			this.btnQuit.Location = location8;
			Padding margin8 = new Padding(2);
			this.btnQuit.Margin = margin8;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size8 = new System.Drawing.Size(112, 24);
			this.btnQuit.Size = size8;
			this.btnQuit.TabIndex = 0;
			this.btnQuit.Text = "关闭";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(22, 44);
			this.label2.Location = location9;
			Padding margin9 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin9;
			this.label2.Name = "label2";
			System.Drawing.Size size9 = new System.Drawing.Size(75, 15);
			this.label2.Size = size9;
			this.label2.TabIndex = 1;
			this.label2.Text = "线束关系:";
			this.textBox_xsgxs.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_xsgxs.BorderStyle = BorderStyle.None;
			this.textBox_xsgxs.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location10 = new System.Drawing.Point(109, 43);
			this.textBox_xsgxs.Location = location10;
			Padding margin10 = new Padding(2);
			this.textBox_xsgxs.Margin = margin10;
			this.textBox_xsgxs.Name = "textBox_xsgxs";
			this.textBox_xsgxs.ReadOnly = true;
			System.Drawing.Size size10 = new System.Drawing.Size(667, 17);
			this.textBox_xsgxs.Size = size10;
			this.textBox_xsgxs.TabIndex = 2;
			this.textBox_xsgxs.Text = "0 条";
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.tabControl1);
			base.Controls.Add(this.textBox_xsgxs);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.textBox_bcCable);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin11 = new Padding(2);
			base.Margin = margin11;
			base.Name = "ctFormCableInfoView";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "查看被测线束";
			base.Load += new System.EventHandler(this.ctFormCableInfoView_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormCableInfoView_SizeChanged);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView2).EndInit();
			this.tabPage2.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			base.Close();
		}
		public void RefreshDataGridView()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			string[] plugStringArray = null;
			try
			{
				this.dataGridView1.Rows.Clear();
				int inum = 0;
				string tempStr = "";
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "select * from TLineStructLibraryDetail where LID='" + System.Convert.ToString(this.iEditPid) + "'";
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						this.dataGridView1.Rows.Add(1);
						int num = inum + 1;
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
						string plugName1Str = dataReader["PlugName1"].ToString();
						this.dataGridView1.Rows[inum].Cells[1].Value = plugName1Str;
						this.dataGridView1.Rows[inum].Cells[2].Value = dataReader["PinName1"].ToString();
						string plugName2Str = dataReader["PlugName2"].ToString();
						this.dataGridView1.Rows[inum].Cells[3].Value = plugName2Str;
						this.dataGridView1.Rows[inum].Cells[4].Value = dataReader["PinName2"].ToString();
						this.dataGridView1.Rows[inum].Cells[5].Value = "否";
						if (0 != dataReader["IsGround"].ToString().CompareTo("0"))
						{
							this.dataGridView1.Rows[inum].Cells[5].Value = "是";
						}
						this.dataGridView1.Rows[inum].Cells[6].Value = "否";
						if (0 != dataReader["IsTestDT"].ToString().CompareTo("0"))
						{
							this.dataGridView1.Rows[inum].Cells[6].Value = "是";
						}
						this.dataGridView1.Rows[inum].Cells[7].Value = "否";
						if (0 != dataReader["IsTestDL"].ToString().CompareTo("0"))
						{
							this.dataGridView1.Rows[inum].Cells[7].Value = "是";
						}
						this.dataGridView1.Rows[inum].Cells[8].Value = "否";
						if (0 != dataReader["IsTestJY"].ToString().CompareTo("0"))
						{
							this.dataGridView1.Rows[inum].Cells[8].Value = "是";
						}
						this.dataGridView1.Rows[inum].Cells[9].Value = "否";
						if (0 != dataReader["IsTestDDJY"].ToString().CompareTo("0"))
						{
							this.dataGridView1.Rows[inum].Cells[9].Value = "是";
						}
						this.dataGridView1.Rows[inum].Cells[10].Value = "否";
						if (0 != dataReader["IsTestNY"].ToString().CompareTo("0"))
						{
							this.dataGridView1.Rows[inum].Cells[10].Value = "是";
						}
						inum = num;
					}
					this.dataGridView1.AllowUserToAddRows = false;
					dataReader.Close();
					dataReader = null;
					sqlcommand = "select * from TLineStructLibrary where LID = " + this.iEditPid + "";
					cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					while (dataReader.Read())
					{
						tempStr = dataReader["PlugInfo"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					if (!string.IsNullOrEmpty(tempStr))
					{
						plugStringArray = tempStr.Split(new char[]
						{
							','
						});
					}
					if (plugStringArray != null)
					{
						inum = 0;
						for (int i = 0; i < plugStringArray.Length; i++)
						{
							if (!string.IsNullOrEmpty(plugStringArray[i]))
							{
								sqlcommand = "select * from TPlugLibrary where PlugNo = '" + plugStringArray[i] + "'";
								cmd = new OleDbCommand(sqlcommand, connection);
								dataReader = cmd.ExecuteReader();
								this.dataGridView2.AllowUserToAddRows = true;
								while (dataReader.Read())
								{
									this.dataGridView2.Rows.Add(1);
									int num2 = inum + 1;
									this.dataGridView2.Rows[inum].Cells[0].Value = System.Convert.ToString(num2);
									this.dataGridView2.Rows[inum].Cells[1].Value = dataReader["PlugNo"].ToString();
									this.dataGridView2.Rows[inum].Cells[2].Value = dataReader["PinNum"].ToString();
									this.dataGridView2.Rows[inum].Cells[3].Value = dataReader["Remark"].ToString();
									inum = num2;
								}
								this.dataGridView2.AllowUserToAddRows = false;
								dataReader.Close();
								dataReader = null;
							}
						}
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_626_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					this.dataGridView2.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_626_0.StackTrace);
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
				this.textBox_xsgxs.Text = System.Convert.ToString(this.dataGridView1.Rows.Count) + " 条";
			}
			catch (System.Exception arg_674_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_674_0.StackTrace);
			}
		}
		private void ctFormCableInfoView_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
				this.textBox_bcCable.Text = this.bcCableStr;
				this.Column_dtTestFlag.Visible = this.gLineTestProcessor.bDTTestEnabled;
				this.Column_nyTestFlag.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.Column_dlTestFlag.Visible = this.gLineTestProcessor.bDLTestEnabled;
				this.Column_jyTestFlag.Visible = this.gLineTestProcessor.bJYTestEnabled;
				this.Column_ddjyTestFlag.Visible = this.gLineTestProcessor.bDDJYTestEnabled;
				for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
				{
					this.dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					this.dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
				{
					this.dataGridView1.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				for (int k = 0; k < this.dataGridView2.Columns.Count; k++)
				{
					this.dataGridView2.Columns[k].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					this.dataGridView2.Columns[k].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				for (int l = 0; l < this.dataGridView2.Columns.Count; l++)
				{
					this.dataGridView2.Columns[l].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
			}
			catch (System.Exception arg_1B8_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1B8_0.StackTrace);
			}
			this.RefreshDataGridView();
			int m = 0;
			if (0 < this.dataGridView1.Rows.Count)
			{
				do
				{
					this.dataGridView1.Rows[m].Selected = false;
					m++;
				}
				while (m < this.dataGridView1.Rows.Count);
			}
			int n = 0;
			if (0 < this.dataGridView2.Rows.Count)
			{
				do
				{
					this.dataGridView2.Rows[n].Selected = false;
					n++;
				}
				while (n < this.dataGridView2.Rows.Count);
			}
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode == 0)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
			catch (System.Exception arg_267_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_267_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
		}
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 972;
					int iy = 0;
					int ia = 0;
					if (iw > 0)
					{
						ia = iw / 2;
					}
					int iTWidth = 110;
					try
					{
						int iShowDefineColNum = this.gLineTestProcessor.iShowDefineColNum;
						iTWidth = 880 / iShowDefineColNum;
						iy = 880 - iShowDefineColNum * iTWidth;
					}
					catch (System.Exception ex_54)
					{
					}
					this.dataGridView1.Columns[0].Width = iy + 68;
					int width = ia + iTWidth;
					this.dataGridView1.Columns[1].Width = width;
					this.dataGridView1.Columns[2].Width = iTWidth;
					this.dataGridView1.Columns[3].Width = width;
					this.dataGridView1.Columns[4].Width = iTWidth;
					this.dataGridView1.Columns[5].Width = iTWidth;
					this.dataGridView1.Columns[6].Width = iTWidth;
					this.dataGridView1.Columns[7].Width = iTWidth;
					this.dataGridView1.Columns[8].Width = iTWidth;
					this.dataGridView1.Columns[9].Width = iTWidth;
					this.dataGridView1.Columns[10].Width = iTWidth;
					int ic = 0;
					iw = this.dataGridView1.Width - 776;
					if (iw > 0)
					{
						ic = iw;
					}
					this.dataGridView2.Columns[0].Width = 72;
					this.dataGridView2.Columns[1].Width = ic + 320;
					this.dataGridView2.Columns[2].Width = 180;
					this.dataGridView2.Columns[3].Width = 180;
					this.dataGridView1.Refresh();
					this.dataGridView2.Refresh();
				}
			}
			catch (System.Exception arg_200_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_200_0.StackTrace);
			}
		}
		private void ctFormCableInfoView_SizeChanged(object sender, System.EventArgs e)
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
		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
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
		private void tabControl1_SizeChanged(object sender, System.EventArgs e)
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
		private void dataGridView2_SizeChanged(object sender, System.EventArgs e)
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
		private void dataGridView1_SizeChanged(object sender, System.EventArgs e)
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
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormCableInfoView();
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
