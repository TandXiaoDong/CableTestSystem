using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormIAndRTPinReletionManage : Form
	{
		public ctFormBatchEditIRTPinRelation batchEditIRTPinRelationForm;
		public KLineTestProcessor gLineTestProcessor;
		public string dbpath;
		public string loginUser;
		public string csIndexStr;
		public bool bOperateFlag;
		private Button btnQuit;
		private Button btnPLXG;
		private Button btnSubmit;
		private GroupBox groupBox1;
		private DataGridView dataGridView1;
		private NumericUpDown numericUpDown_AT;
		private DataGridViewTextBoxColumn Column_pin;
		private DataGridViewTextBoxColumn Column_rc;
		private Container components;
		public ctFormIAndRTPinReletionManage(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
					this.bOperateFlag = false;
				}
				catch (System.Exception arg_3D_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_3D_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormIAndRTPinReletionManage()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormIAndRTPinReletionManage));
			this.btnQuit = new Button();
			this.btnPLXG = new Button();
			this.btnSubmit = new Button();
			this.groupBox1 = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.Column_pin = new DataGridViewTextBoxColumn();
			this.Column_rc = new DataGridViewTextBoxColumn();
			this.numericUpDown_AT = new NumericUpDown();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			((ISupportInitialize)this.numericUpDown_AT).BeginInit();
			base.SuspendLayout();
			this.btnQuit.Anchor = AnchorStyles.Right;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(653, 417);
			this.btnQuit.Location = location;
			Padding margin = new Padding(2, 2, 2, 2);
			this.btnQuit.Margin = margin;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size = new System.Drawing.Size(90, 24);
			this.btnQuit.Size = size;
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btnPLXG.Anchor = AnchorStyles.Right;
			this.btnPLXG.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(653, 111);
			this.btnPLXG.Location = location2;
			Padding margin2 = new Padding(2, 2, 2, 2);
			this.btnPLXG.Margin = margin2;
			this.btnPLXG.Name = "btnPLXG";
			System.Drawing.Size size2 = new System.Drawing.Size(90, 24);
			this.btnPLXG.Size = size2;
			this.btnPLXG.TabIndex = 2;
			this.btnPLXG.Text = "批量修改";
			this.btnPLXG.UseVisualStyleBackColor = true;
			this.btnPLXG.Click += new System.EventHandler(this.btnPLXG_Click);
			this.btnSubmit.Anchor = AnchorStyles.Right;
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(653, 254);
			this.btnSubmit.Location = location3;
			Padding margin3 = new Padding(2, 2, 2, 2);
			this.btnSubmit.Margin = margin3;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size3 = new System.Drawing.Size(90, 24);
			this.btnSubmit.Size = size3;
			this.btnSubmit.TabIndex = 0;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(8, 10);
			this.groupBox1.Location = location4;
			Padding margin4 = new Padding(2, 2, 2, 2);
			this.groupBox1.Margin = margin4;
			this.groupBox1.Name = "groupBox1";
			Padding padding = new Padding(2, 2, 2, 2);
			this.groupBox1.Padding = padding;
			System.Drawing.Size size4 = new System.Drawing.Size(613, 543);
			this.groupBox1.Size = size4;
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "测试仪与转接台针脚映射关系表";
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			System.Drawing.Color window = System.Drawing.SystemColors.Window;
			this.dataGridView1.BackgroundColor = window;
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[]
			{
				this.Column_pin,
				this.Column_rc
			};
			this.dataGridView1.Columns.AddRange(dataGridViewColumns);
			this.dataGridView1.Dock = DockStyle.Fill;
			System.Drawing.Point location5 = new System.Drawing.Point(2, 19);
			this.dataGridView1.Location = location5;
			Padding margin5 = new Padding(2, 2, 2, 2);
			this.dataGridView1.Margin = margin5;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size5 = new System.Drawing.Size(609, 522);
			this.dataGridView1.Size = size5;
			this.dataGridView1.TabIndex = 15;
			this.dataGridView1.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
			this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
			this.Column_pin.HeaderText = "测试仪针脚号";
			this.Column_pin.Name = "Column_pin";
			this.Column_pin.ReadOnly = true;
			this.Column_pin.Width = 197;
			this.Column_rc.HeaderText = "转接台针脚号";
			this.Column_rc.Name = "Column_rc";
			this.Column_rc.ReadOnly = true;
			this.Column_rc.Width = 197;
			this.numericUpDown_AT.Anchor = AnchorStyles.Right;
			this.numericUpDown_AT.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(653, 493);
			this.numericUpDown_AT.Location = location6;
			Padding margin6 = new Padding(2, 2, 2, 2);
			this.numericUpDown_AT.Margin = margin6;
			decimal maximum = new decimal(new int[]
			{
				1024,
				0,
				0,
				0
			});
			this.numericUpDown_AT.Maximum = maximum;
			decimal minimum = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_AT.Minimum = minimum;
			this.numericUpDown_AT.Name = "numericUpDown_AT";
			System.Drawing.Size size6 = new System.Drawing.Size(90, 24);
			this.numericUpDown_AT.Size = size6;
			this.numericUpDown_AT.TabIndex = 6;
			this.numericUpDown_AT.TextAlign = HorizontalAlignment.Center;
			decimal value = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_AT.Value = value;
			this.numericUpDown_AT.Visible = false;
			this.numericUpDown_AT.KeyPress += new KeyPressEventHandler(this.numericUpDown_AT_KeyPress);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.numericUpDown_AT);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnPLXG);
			base.Controls.Add(this.btnSubmit);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin7 = new Padding(2, 2, 2, 2);
			base.Margin = margin7;
			base.Name = "ctFormIAndRTPinReletionManage";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "测试仪与转接台针脚映射关系管理";
			base.Load += new System.EventHandler(this.ctFormIAndRTPinReletionManage_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormIAndRTPinReletionManage_SizeChanged);
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			((ISupportInitialize)this.numericUpDown_AT).EndInit();
			base.ResumeLayout(false);
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			base.Close();
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			try
			{
				if (!this.bOperateFlag)
				{
					base.Close();
					return;
				}
				for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
				{
					if (this.dataGridView1.Rows[i].Cells[0].Value != null && this.dataGridView1.Rows[i].Cells[1].Value != null)
					{
						string temp1Str = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
						string temp2Str = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
						if (!string.IsNullOrEmpty(temp2Str))
						{
							for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
							{
								if (i != j)
								{
									if (this.dataGridView1.Rows[j].Cells[0].Value != null && this.dataGridView1.Rows[j].Cells[1].Value != null)
									{
										string temp3Str = this.dataGridView1.Rows[j].Cells[0].Value.ToString();
										string temp4Str = this.dataGridView1.Rows[j].Cells[1].Value.ToString();
										if (!string.IsNullOrEmpty(temp4Str))
										{
											if (temp2Str == temp4Str)
											{
												MessageBox.Show("第" + temp1Str + "行与第" + temp3Str + "行转接台针脚号相同!", "提示", MessageBoxButtons.OK);
												return;
											}
										}
									}
								}
							}
						}
					}
				}
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					int num;
					for (int k = 0; k < this.dataGridView1.Rows.Count; k = num)
					{
						string temp2Str = "";
						if (this.dataGridView1.Rows[k].Cells[1].Value != null)
						{
							temp2Str = this.dataGridView1.Rows[k].Cells[1].Value.ToString();
						}
						num = k + 1;
						string temp1Str = System.Convert.ToString(num);
						new OleDbCommand("update TIAndRTPinReletionData set AT_PinNum = '" + temp2Str + "' where TI_PinNum= '" + temp1Str + "'", connection).ExecuteNonQuery();
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_2E5_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_2E5_0.StackTrace);
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
			}
			catch (System.Exception arg_2FE_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2FE_0.StackTrace);
			}
			base.Close();
		}
		private void ctFormIAndRTPinReletionManage_Load(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				try
				{
					decimal maximum = this.gLineTestProcessor.SELF_MAX_COUNT;
					this.numericUpDown_AT.Maximum = maximum;
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
				catch (System.Exception ex_BC)
				{
				}
				this.dataGridView1.Rows.Clear();
				int iRCount = 0;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "select * from TIAndRTPinReletionData order by ID ASC";
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						string temp1Str = dataReader["TI_PinNum"].ToString();
						string temp2Str = dataReader["AT_PinNum"].ToString();
						this.dataGridView1.Rows.Add(1);
						this.dataGridView1.Rows[iRCount].Cells[0].Value = temp1Str;
						this.dataGridView1.Rows[iRCount].Cells[1].Value = temp2Str;
						iRCount++;
						if (iRCount >= this.gLineTestProcessor.SELF_MAX_COUNT)
						{
							break;
						}
					}
					dataReader.Close();
					dataReader = null;
					int isyCount = this.gLineTestProcessor.SELF_MAX_COUNT - iRCount;
					if (0 < isyCount)
					{
						for (int k = 0; k < isyCount; k++)
						{
							int num = iRCount + 1;
							string tempStr = System.Convert.ToString(num);
							sqlcommand = "insert into TIAndRTPinReletionData(TI_PinNum,AT_PinNum) values('" + tempStr + "','" + tempStr + "')";
							cmd = new OleDbCommand(sqlcommand, connection);
							cmd.ExecuteNonQuery();
							iRCount = num;
						}
					}
					iRCount = this.gLineTestProcessor.SELF_MAX_COUNT - isyCount;
					for (int l = 0; l < isyCount; l++)
					{
						int num2 = iRCount + 1;
						string tempStr = System.Convert.ToString(num2);
						this.dataGridView1.Rows.Add(1);
						this.dataGridView1.Rows[iRCount].Cells[0].Value = tempStr;
						this.dataGridView1.Rows[iRCount].Cells[1].Value = tempStr;
						iRCount = num2;
					}
					this.dataGridView1.AllowUserToAddRows = false;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_2E5_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_2E5_0.StackTrace);
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
			catch (System.Exception arg_309_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_309_0.StackTrace);
			}
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode == 0)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
			catch (System.Exception arg_32C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_32C_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
		}
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 418;
					int ia;
					if (iw > 0)
					{
						ia = iw / 2;
					}
					else
					{
						ia = 0;
					}
					int width = ia + 199;
					this.dataGridView1.Columns[0].Width = width;
					this.dataGridView1.Columns[1].Width = width;
				}
			}
			catch (System.Exception arg_61_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_61_0.StackTrace);
			}
		}
		private void ctFormIAndRTPinReletionManage_SizeChanged(object sender, System.EventArgs e)
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
		private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.Rows.Count > 0)
				{
					this.bOperateFlag = true;
					int cellTop = 0;
					for (int i = this.dataGridView1.FirstDisplayedCell.RowIndex; i < e.RowIndex; i++)
					{
						cellTop = this.dataGridView1.Rows[i].Height + cellTop;
					}
					System.Drawing.Point location = this.groupBox1.Location;
					int iLeft = this.dataGridView1.Location.X + location.X;
					System.Drawing.Point location2 = this.groupBox1.Location;
					int iTop = this.dataGridView1.Location.Y + location2.Y;
					iLeft = this.dataGridView1.Columns[0].Width + iLeft + 2;
					iTop = this.dataGridView1.ColumnHeadersHeight + cellTop + iTop + 2;
					this.numericUpDown_AT.Left = iLeft;
					this.numericUpDown_AT.Top = iTop;
					this.numericUpDown_AT.Height = this.dataGridView1.RowTemplate.Height + 3;
					this.numericUpDown_AT.Width = this.dataGridView1.Columns[1].Width - 2;
					if (this.dataGridView1.SelectedRows[0].Cells[0].Value != null)
					{
						this.csIndexStr = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
					}
					if (this.dataGridView1.SelectedRows[0].Cells[1].Value != null)
					{
						this.numericUpDown_AT.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
					}
					this.numericUpDown_AT.Visible = true;
					this.numericUpDown_AT.Focus();
				}
			}
			catch (System.Exception arg_206_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_206_0.StackTrace);
			}
		}
		private void numericUpDown_AT_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r' && this.numericUpDown_AT.Visible)
				{
					string editStr = this.numericUpDown_AT.Text.ToString().Trim();
					if (string.IsNullOrEmpty(editStr))
					{
						for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
						{
							if (this.dataGridView1.Rows[i].Cells[0].Value != null)
							{
								string tempStr = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
								if (0 == this.csIndexStr.CompareTo(tempStr))
								{
									this.dataGridView1.Rows[i].Cells[1].Value = editStr;
									break;
								}
							}
						}
					}
					else
					{
						int iTemp = System.Convert.ToInt32(editStr);
						decimal maximum = this.numericUpDown_AT.Maximum;
						if (iTemp > System.Convert.ToInt32(maximum))
						{
							iTemp = System.Convert.ToInt32(this.numericUpDown_AT.Maximum);
						}
						for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
						{
							if (this.dataGridView1.Rows[j].Cells[0].Value != null)
							{
								string tempStr = this.dataGridView1.Rows[j].Cells[0].Value.ToString();
								if (0 == this.csIndexStr.CompareTo(tempStr))
								{
									this.dataGridView1.Rows[j].Cells[1].Value = System.Convert.ToString(iTemp);
									break;
								}
							}
						}
					}
					this.numericUpDown_AT.Visible = false;
					this.dataGridView1.ScrollBars = ScrollBars.Both;
				}
				if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '\b')
				{
					e.Handled = false;
				}
				else
				{
					e.Handled = true;
				}
			}
			catch (System.Exception arg_21A_0)
			{
				this.numericUpDown_AT.Visible = false;
				this.dataGridView1.ScrollBars = ScrollBars.Both;
				KLineTestProcessor.ExceptionRecordFunc(arg_21A_0.StackTrace);
			}
		}
		public void SetControlValueToDGVFunc()
		{
			try
			{
				if (this.numericUpDown_AT.Visible)
				{
					string editStr = this.numericUpDown_AT.Text.ToString();
					if (string.IsNullOrEmpty(editStr))
					{
						for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
						{
							if (this.dataGridView1.Rows[i].Cells[0].Value != null)
							{
								string tempStr = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
								if (0 == this.csIndexStr.CompareTo(tempStr))
								{
									this.dataGridView1.Rows[i].Cells[1].Value = editStr;
									break;
								}
							}
						}
					}
					else
					{
						int iTemp = System.Convert.ToInt32(editStr);
						decimal maximum = this.numericUpDown_AT.Maximum;
						if (iTemp > System.Convert.ToInt32(maximum))
						{
							iTemp = System.Convert.ToInt32(this.numericUpDown_AT.Maximum);
						}
						for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
						{
							if (this.dataGridView1.Rows[j].Cells[0].Value != null)
							{
								string tempStr = this.dataGridView1.Rows[j].Cells[0].Value.ToString();
								if (0 == this.csIndexStr.CompareTo(tempStr))
								{
									this.dataGridView1.Rows[j].Cells[1].Value = System.Convert.ToString(iTemp);
									break;
								}
							}
						}
					}
				}
			}
			catch (System.Exception arg_1AB_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1AB_0.StackTrace);
			}
			this.numericUpDown_AT.Visible = false;
			this.dataGridView1.ScrollBars = ScrollBars.Both;
		}
		private void dataGridView1_SelectionChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.SetControlValueToDGVFunc();
			}
			catch (System.Exception arg_08_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_08_0.StackTrace);
			}
		}
		private void btnPLXG_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormBatchEditIRTPinRelation ctFormBatchEditIRTPinRelation = new ctFormBatchEditIRTPinRelation(this.gLineTestProcessor);
				this.batchEditIRTPinRelationForm = ctFormBatchEditIRTPinRelation;
				ctFormBatchEditIRTPinRelation.Activate();
				this.batchEditIRTPinRelationForm.ShowDialog();
				ctFormBatchEditIRTPinRelation sender2 = this.batchEditIRTPinRelationForm;
				if (sender2.bSubmitFlag)
				{
					this.bOperateFlag = true;
					int iCSYPin = sender2.iCSYPin;
					int iZJTPin = sender2.iZJTPin;
					int iUpdNum = sender2.iUpdNum;
					for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
					{
						if (this.dataGridView1.Rows[i].Cells[0].Value != null)
						{
							string tempStr = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
							int iTemp = System.Convert.ToInt32(tempStr);
							if (iTemp == iCSYPin)
							{
								this.dataGridView1.Rows[i].Cells[1].Value = System.Convert.ToString(iZJTPin);
								iZJTPin++;
								iCSYPin++;
								iUpdNum--;
								if (iUpdNum <= 0)
								{
									break;
								}
							}
						}
					}
				}
			}
			catch (System.Exception arg_119_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_119_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormIAndRTPinReletionManage();
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
