using Aspose.Cells;
using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormResistanceCompensation : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public ctFormBatchEditRC batchEditRCForm;
		public string dbpath;
		public string loginUser;
		public string currSelectedPinStr;
		public bool bUpdateFlag;
		public int iCurrCount;
		private Button btnImport;
		private OpenFileDialog openFileDialog1;
		private Button btnPLXG;
		private GroupBox groupBox1;
		private Button btnSubmit;
		private Button btnQuit;
		private DataGridView dataGridView1;
		private NumericUpDown numericUpDown_Template;
		private DataGridViewTextBoxColumn Column_pin;
		private DataGridViewTextBoxColumn Column_rc;
		private Container components;
		public ctFormResistanceCompensation(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
					this.currSelectedPinStr = "";
					this.bUpdateFlag = false;
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
		private void ~ctFormResistanceCompensation()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormResistanceCompensation));
			this.groupBox1 = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.Column_pin = new DataGridViewTextBoxColumn();
			this.Column_rc = new DataGridViewTextBoxColumn();
			this.btnSubmit = new Button();
			this.btnQuit = new Button();
			this.numericUpDown_Template = new NumericUpDown();
			this.btnPLXG = new Button();
			this.btnImport = new Button();
			this.openFileDialog1 = new OpenFileDialog();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			((ISupportInitialize)this.numericUpDown_Template).BeginInit();
			base.SuspendLayout();
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(22, 10);
			this.groupBox1.Location = location;
			Padding margin = new Padding(2);
			this.groupBox1.Margin = margin;
			this.groupBox1.Name = "groupBox1";
			Padding padding = new Padding(2);
			this.groupBox1.Padding = padding;
			System.Drawing.Size size = new System.Drawing.Size(613, 531);
			this.groupBox1.Size = size;
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "补偿电阻表";
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
			System.Drawing.Point location2 = new System.Drawing.Point(2, 19);
			this.dataGridView1.Location = location2;
			Padding margin2 = new Padding(2);
			this.dataGridView1.Margin = margin2;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size2 = new System.Drawing.Size(609, 510);
			this.dataGridView1.Size = size2;
			this.dataGridView1.TabIndex = 15;
			this.dataGridView1.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
			this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
			this.dataGridView1.KeyPress += new KeyPressEventHandler(this.dataGridView1_KeyPress);
			this.Column_pin.HeaderText = "测试仪针脚号";
			this.Column_pin.Name = "Column_pin";
			this.Column_pin.ReadOnly = true;
			this.Column_pin.Width = 280;
			this.Column_rc.HeaderText = "补偿电阻值(Ω)";
			this.Column_rc.Name = "Column_rc";
			this.Column_rc.ReadOnly = true;
			this.Column_rc.Width = 300;
			this.btnSubmit.Anchor = AnchorStyles.Right;
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(666, 333);
			this.btnSubmit.Location = location3;
			Padding margin3 = new Padding(2);
			this.btnSubmit.Margin = margin3;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size3 = new System.Drawing.Size(100, 24);
			this.btnSubmit.Size = size3;
			this.btnSubmit.TabIndex = 0;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnQuit.Anchor = AnchorStyles.Right;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(666, 452);
			this.btnQuit.Location = location4;
			Padding margin4 = new Padding(2);
			this.btnQuit.Margin = margin4;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size4 = new System.Drawing.Size(100, 24);
			this.btnQuit.Size = size4;
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.numericUpDown_Template.Anchor = AnchorStyles.Right;
			this.numericUpDown_Template.DecimalPlaces = 3;
			this.numericUpDown_Template.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(671, 506);
			this.numericUpDown_Template.Location = location5;
			Padding margin5 = new Padding(2);
			this.numericUpDown_Template.Margin = margin5;
			decimal maximum = new decimal(new int[]
			{
				10000000,
				0,
				0,
				0
			});
			this.numericUpDown_Template.Maximum = maximum;
			this.numericUpDown_Template.Name = "numericUpDown_Template";
			System.Drawing.Size size5 = new System.Drawing.Size(90, 24);
			this.numericUpDown_Template.Size = size5;
			this.numericUpDown_Template.TabIndex = 17;
			this.numericUpDown_Template.TextAlign = HorizontalAlignment.Center;
			this.numericUpDown_Template.Visible = false;
			this.numericUpDown_Template.KeyPress += new KeyPressEventHandler(this.numericUpDown_Template_KeyPress);
			this.btnPLXG.Anchor = AnchorStyles.Right;
			this.btnPLXG.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(666, 214);
			this.btnPLXG.Location = location6;
			Padding margin6 = new Padding(2);
			this.btnPLXG.Margin = margin6;
			this.btnPLXG.Name = "btnPLXG";
			System.Drawing.Size size6 = new System.Drawing.Size(100, 24);
			this.btnPLXG.Size = size6;
			this.btnPLXG.TabIndex = 2;
			this.btnPLXG.Text = "批量修改";
			this.btnPLXG.UseVisualStyleBackColor = true;
			this.btnPLXG.Click += new System.EventHandler(this.btnPLXG_Click);
			this.btnImport.Anchor = AnchorStyles.Right;
			this.btnImport.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(666, 95);
			this.btnImport.Location = location7;
			Padding margin7 = new Padding(2);
			this.btnImport.Margin = margin7;
			this.btnImport.Name = "btnImport";
			System.Drawing.Size size7 = new System.Drawing.Size(100, 24);
			this.btnImport.Size = size7;
			this.btnImport.TabIndex = 19;
			this.btnImport.Text = "导入补偿表";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			this.openFileDialog1.FileName = "openFileDialog1";
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.btnImport);
			base.Controls.Add(this.numericUpDown_Template);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnPLXG);
			base.Controls.Add(this.btnSubmit);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin8 = new Padding(2);
			base.Margin = margin8;
			base.Name = "ctFormResistanceCompensation";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "补偿电阻管理";
			base.Load += new System.EventHandler(this.ctFormResistanceCompensation_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormResistanceCompensation_SizeChanged);
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			((ISupportInitialize)this.numericUpDown_Template).EndInit();
			base.ResumeLayout(false);
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			this.bUpdateFlag = false;
			base.Close();
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			try
			{
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
					{
						if (this.dataGridView1.Rows[i].Cells[0].Value != null && this.dataGridView1.Rows[i].Cells[1].Value != null)
						{
							string temp1Str = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
							string temp2Str = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
							int num = this.iCurrCount;
							int sELF_MAX_COUNT = this.gLineTestProcessor.SELF_MAX_COUNT;
							if (num < sELF_MAX_COUNT && num < i + 1)
							{
								if (i < sELF_MAX_COUNT)
								{
									string sqlcommand = "insert into TResistanceCompensation(PinNum,CompensationValue) values(" + System.Convert.ToInt32(temp1Str) + "," + System.Convert.ToDouble(temp2Str) + ")";
									OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
									cmd.ExecuteNonQuery();
								}
							}
							else
							{
								string sqlcommand = "update TResistanceCompensation set CompensationValue = " + System.Convert.ToDouble(temp2Str) + " where PinNum=" + System.Convert.ToInt32(temp1Str);
								OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
								cmd.ExecuteNonQuery();
							}
						}
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_1AD_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_1AD_0.StackTrace);
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
			}
			catch (System.Exception arg_1C6_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1C6_0.StackTrace);
			}
			this.bUpdateFlag = true;
			base.Close();
		}
		private void ctFormResistanceCompensation_Load(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.dataGridView1.Rows.Clear();
				int iRCount = 0;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select * from TResistanceCompensation order by ID", connection).ExecuteReader();
					this.dataGridView1.AllowUserToAddRows = true;
					while (dataReader.Read())
					{
						string temp1Str = dataReader["PinNum"].ToString();
						string temp2Str = dataReader["CompensationValue"].ToString();
						this.dataGridView1.Rows.Add(1);
						this.dataGridView1.Rows[iRCount].Cells[0].Value = temp1Str;
						this.dataGridView1.Rows[iRCount].Cells[1].Value = temp2Str;
						iRCount++;
						if (iRCount >= this.gLineTestProcessor.SELF_MAX_COUNT)
						{
							break;
						}
					}
					this.iCurrCount = iRCount;
					dataReader.Close();
					dataReader = null;
					int sELF_MAX_COUNT = this.gLineTestProcessor.SELF_MAX_COUNT;
					if (iRCount < sELF_MAX_COUNT)
					{
						for (int i = iRCount; i < sELF_MAX_COUNT; i++)
						{
							this.dataGridView1.Rows.Add(1);
							int num = iRCount + 1;
							string temp1Str = System.Convert.ToString(num);
							this.dataGridView1.Rows[iRCount].Cells[0].Value = temp1Str;
							this.dataGridView1.Rows[iRCount].Cells[1].Value = "0";
							iRCount = num;
							sELF_MAX_COUNT = this.gLineTestProcessor.SELF_MAX_COUNT;
							if (iRCount >= sELF_MAX_COUNT)
							{
								break;
							}
						}
					}
					this.dataGridView1.AllowUserToAddRows = false;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_1D8_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_1D8_0.StackTrace);
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
			catch (System.Exception arg_1FC_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1FC_0.StackTrace);
			}
			try
			{
				for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
				{
					this.dataGridView1.Columns[j].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					this.dataGridView1.Columns[j].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				for (int k = 0; k < this.dataGridView1.Columns.Count; k++)
				{
					this.dataGridView1.Columns[k].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
			}
			catch (System.Exception arg_29C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_29C_0.StackTrace);
			}
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode == 0)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
			catch (System.Exception arg_2BF_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2BF_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
		}
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 374;
					int ia = 0;
					if (iw > 0)
					{
						ia = iw / 2;
					}
					this.dataGridView1.Columns[0].Width = ia + 150;
					this.dataGridView1.Columns[1].Width = ia + 200;
				}
			}
			catch (System.Exception arg_61_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_61_0.StackTrace);
			}
		}
		private void ctFormResistanceCompensation_SizeChanged(object sender, System.EventArgs e)
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
		public void SetControlValueToDGVFunc()
		{
			try
			{
				if (this.numericUpDown_Template.Visible)
				{
					string editStr = this.numericUpDown_Template.Text.ToString();
					if (!string.IsNullOrEmpty(editStr))
					{
						double dTemp = System.Convert.ToDouble(editStr);
						decimal maximum = this.numericUpDown_Template.Maximum;
						if (dTemp > System.Convert.ToDouble(maximum))
						{
							dTemp = System.Convert.ToDouble(this.numericUpDown_Template.Maximum);
						}
						for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
						{
							if (this.dataGridView1.Rows[i].Cells[0].Value != null)
							{
								string tempStr = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
								if (this.currSelectedPinStr == tempStr)
								{
									this.dataGridView1.Rows[i].Cells[1].Value = System.Convert.ToString(dTemp);
									break;
								}
							}
						}
					}
				}
			}
			catch (System.Exception arg_105_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_105_0.StackTrace);
			}
			this.numericUpDown_Template.Visible = false;
			this.dataGridView1.ScrollBars = ScrollBars.Both;
		}
		private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.SetControlValueToDGVFunc();
				}
			}
			catch (System.Exception arg_12_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_12_0.StackTrace);
			}
		}
		private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{
				if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView1.Rows.Count > 0)
				{
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
					this.numericUpDown_Template.Left = iLeft;
					this.numericUpDown_Template.Top = iTop;
					this.numericUpDown_Template.Height = this.dataGridView1.RowTemplate.Height + 3;
					this.numericUpDown_Template.Width = this.dataGridView1.Columns[1].Width - 2;
					if (this.dataGridView1.SelectedRows[0].Cells[0].Value != null)
					{
						this.currSelectedPinStr = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
					}
					if (this.dataGridView1.SelectedRows[0].Cells[1].Value != null)
					{
						this.numericUpDown_Template.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
					}
					this.numericUpDown_Template.Visible = true;
					this.numericUpDown_Template.Focus();
				}
			}
			catch (System.Exception arg_1FF_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1FF_0.StackTrace);
			}
		}
		private void numericUpDown_Template_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					if (this.numericUpDown_Template.Visible)
					{
						string editStr = this.numericUpDown_Template.Text.ToString().Trim();
						if (string.IsNullOrEmpty(editStr))
						{
							MessageBox.Show("输入数据为空, 请重新输入!", "提示", MessageBoxButtons.OK);
							return;
						}
						double dTemp = System.Convert.ToDouble(editStr);
						decimal maximum = this.numericUpDown_Template.Maximum;
						if (dTemp > System.Convert.ToDouble(maximum))
						{
							dTemp = System.Convert.ToDouble(this.numericUpDown_Template.Maximum);
						}
						for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
						{
							if (this.dataGridView1.Rows[i].Cells[0].Value != null)
							{
								string tempStr = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
								if (this.currSelectedPinStr == tempStr)
								{
									this.dataGridView1.Rows[i].Cells[1].Value = System.Convert.ToString(dTemp);
									break;
								}
							}
						}
						this.numericUpDown_Template.Visible = false;
						this.dataGridView1.ScrollBars = ScrollBars.Both;
					}
				}
				else if (e.KeyChar == '\u001b')
				{
					this.numericUpDown_Template.Visible = false;
					this.dataGridView1.ScrollBars = ScrollBars.Both;
				}
				if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar > '.' && e.KeyChar != '\b')
				{
					e.Handled = true;
				}
				else
				{
					e.Handled = false;
				}
			}
			catch (System.Exception arg_1B5_0)
			{
				this.numericUpDown_Template.Visible = false;
				this.dataGridView1.ScrollBars = ScrollBars.Both;
				KLineTestProcessor.ExceptionRecordFunc(arg_1B5_0.StackTrace);
			}
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
				ctFormBatchEditRC ctFormBatchEditRC = new ctFormBatchEditRC(this.gLineTestProcessor);
				this.batchEditRCForm = ctFormBatchEditRC;
				ctFormBatchEditRC.Activate();
				this.batchEditRCForm.ShowDialog();
				ctFormBatchEditRC ctFormBatchEditRC2 = this.batchEditRCForm;
				if (ctFormBatchEditRC2.bSubmitFlag)
				{
					int iStartPin = ctFormBatchEditRC2.iStartPin;
					int iStopPin = ctFormBatchEditRC2.iStopPin;
					double dRCValue = ctFormBatchEditRC2.dRCValue;
					double dAddRCValue = ctFormBatchEditRC2.dAddRCValue;
					if (!ctFormBatchEditRC2.bAddRCVFlag)
					{
						for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
						{
							if (this.dataGridView1.Rows[i].Cells[0].Value != null)
							{
								string tempStr = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
								if (iStartPin <= System.Convert.ToInt32(tempStr) && iStopPin >= System.Convert.ToInt32(tempStr) && this.dataGridView1.Rows[i].Cells[1].Value != null)
								{
									this.dataGridView1.Rows[i].Cells[1].Value = System.Convert.ToString(dRCValue);
								}
							}
						}
					}
					else
					{
						for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
						{
							if (this.dataGridView1.Rows[j].Cells[0].Value != null)
							{
								string tempStr = this.dataGridView1.Rows[j].Cells[0].Value.ToString();
								if (iStartPin <= System.Convert.ToInt32(tempStr) && iStopPin >= System.Convert.ToInt32(tempStr) && this.dataGridView1.Rows[j].Cells[1].Value != null)
								{
									string temp2Str = this.dataGridView1.Rows[j].Cells[1].Value.ToString();
									double dAddTemp = System.Convert.ToDouble(temp2Str) + dAddRCValue;
									this.dataGridView1.Rows[j].Cells[1].Value = System.Convert.ToString(dAddTemp);
								}
							}
						}
					}
				}
			}
			catch (System.Exception arg_25A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_25A_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool AsposeCellsReadConfigFileFunc(string file, string fkzm)
		{
			string secondStr = null;
			bool bSuccFlag = true;
			try
			{
				if (string.IsNullOrEmpty(file))
				{
					byte result = 0;
					return result != 0;
				}
				int iRowIndex = 0;
				int iRow = 1;
				int iTemp = 0;
				double dTemp = 0.0;
				if (fkzm == "XLS" || fkzm == "XLSX")
				{
					Workbook wk = new Workbook(file);
					Worksheet sht = wk.Worksheets[0];
					Cells cells = sht.Cells;
					if (sht == null)
					{
						byte result = 0;
						return result != 0;
					}
					int rowCount = cells.MaxDataRow + 1;
					if (rowCount == 0)
					{
						byte result = 0;
						return result != 0;
					}
					int cellCount = cells.MaxDataColumn + 1;
					try
					{
						iRowIndex = 0;
						while (cells[iRow, 1].Value != null)
						{
							string firstStr = cells[iRow, 1].Value.ToString();
							try
							{
								iTemp = System.Convert.ToInt32(firstStr);
							}
							catch (System.Exception ex_C7)
							{
								iRowIndex++;
								iRow++;
								if (rowCount <= iRow)
								{
									break;
								}
								continue;
							}
							if (cells[iRow, 2].Value != null)
							{
								secondStr = cells[iRow, 2].Value.ToString();
							}
							try
							{
								dTemp = System.Math.Round(System.Convert.ToDouble(secondStr), 3);
							}
							catch (System.Exception ex_117)
							{
								iRowIndex++;
								iRow++;
								if (rowCount <= iRow)
								{
									break;
								}
								continue;
							}
							if (iTemp <= this.dataGridView1.Rows.Count)
							{
								this.dataGridView1.Rows[iTemp - 1].Cells[1].Value = System.Convert.ToString(dTemp);
							}
							iRowIndex++;
							iRow++;
							if (rowCount <= iRow)
							{
								break;
							}
						}
					}
					catch (System.Exception ex_188)
					{
						bSuccFlag = false;
					}
				}
			}
			catch (System.Exception arg_197_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_197_0.StackTrace);
			}
			return bSuccFlag;
		}
		private void btnImport_Click(object sender, System.EventArgs e)
		{
			try
			{
				OpenFileDialog sender2 = new OpenFileDialog();
				this.openFileDialog1 = sender2;
				sender2.Filter = "补偿表|*.xlsx;*.xls;";
				this.openFileDialog1.RestoreDirectory = true;
				this.openFileDialog1.FilterIndex = 1;
				if (DialogResult.OK == this.openFileDialog1.ShowDialog(this))
				{
					string readfn = this.openFileDialog1.FileName;
					string expr_4F = readfn;
					string expr_61 = expr_4F.Substring(expr_4F.LastIndexOf("\\") + 1);
					string fkzm = expr_61.Substring(expr_61.LastIndexOf(".") + 1).ToUpper();
					if (this.AsposeCellsReadConfigFileFunc(readfn, fkzm))
					{
						MessageBox.Show("导入成功!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						this.dataGridView1.Rows.Clear();
						MessageBox.Show("导入失败，请确保文件格式及内容真实有效!", "提示", MessageBoxButtons.OK);
					}
				}
			}
			catch (System.Exception arg_B9_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_B9_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormResistanceCompensation();
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
