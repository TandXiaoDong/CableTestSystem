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
	public class ctFormGroupTestParaSet : Form
	{
		public KGroupTestParaInfo gtParaInfo;
		public ctFormBatchEditGroupTestPara batchEditGroupTestParaForm;
		public ctFormEditGroupTestPara editGroupTestParaForm;
		public KLineTestProcessor gLineTestProcessor;
		public GroupTestParaStruct gtpTempStruct;
		public bool bNewProjectFlag;
		public bool bDataChangedFlag;
		public bool bUpdateAllPlugFlag;
		public bool bSubmitSuccFlag;
		public string gtpsCableStr;
		public string dbpath;
		public string tempLIDStr;
		public int iRowIndex;
		public int iProjectID;
		private DataGridViewTextBoxColumn Column_xh;
		private DataGridViewTextBoxColumn Column_startInterface;
		private DataGridViewTextBoxColumn Column_startPin;
		private DataGridViewTextBoxColumn Column_stopInterface;
		private DataGridViewTextBoxColumn Column_stopPin;
		private DataGridViewTextBoxColumn Column_DTThreshold;
		private DataGridViewTextBoxColumn Column_JYThreshold;
		private DataGridViewTextBoxColumn Column_JYTestTime;
		private DataGridViewTextBoxColumn Column_JYVoltage;
		private DataGridViewTextBoxColumn Column_NYThreshold;
		private DataGridViewTextBoxColumn Column_NYTestTime;
		private DataGridViewTextBoxColumn Column_NYVoltage;
		private Button btnPLXG;
		private TextBox textBox_bcCable;
		private Label label1;
		private Button btnQuit;
		private Button btnSubmit;
		private GroupBox groupBox1;
		private DataGridView dataGridView1;
		private Container components;
		public ctFormGroupTestParaSet(KLineTestProcessor gltProcessor, string cableStr, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool bNewProjFlag, int iPID)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.gtpsCableStr = cableStr;
					this.bNewProjectFlag = bNewProjFlag;
					this.iProjectID = iPID;
					this.bDataChangedFlag = false;
					this.bSubmitSuccFlag = false;
					this.tempLIDStr = "";
					this.gtParaInfo = new KGroupTestParaInfo();
				}
				catch (System.Exception ex_64)
				{
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormGroupTestParaSet()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormGroupTestParaSet));
			this.groupBox1 = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.Column_xh = new DataGridViewTextBoxColumn();
			this.Column_startInterface = new DataGridViewTextBoxColumn();
			this.Column_startPin = new DataGridViewTextBoxColumn();
			this.Column_stopInterface = new DataGridViewTextBoxColumn();
			this.Column_stopPin = new DataGridViewTextBoxColumn();
			this.Column_DTThreshold = new DataGridViewTextBoxColumn();
			this.Column_JYThreshold = new DataGridViewTextBoxColumn();
			this.Column_JYTestTime = new DataGridViewTextBoxColumn();
			this.Column_JYVoltage = new DataGridViewTextBoxColumn();
			this.Column_NYThreshold = new DataGridViewTextBoxColumn();
			this.Column_NYTestTime = new DataGridViewTextBoxColumn();
			this.Column_NYVoltage = new DataGridViewTextBoxColumn();
			this.btnQuit = new Button();
			this.btnSubmit = new Button();
			this.textBox_bcCable = new TextBox();
			this.label1 = new Label();
			this.btnPLXG = new Button();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(8, 56);
			this.groupBox1.Location = location;
			Padding margin = new Padding(2);
			this.groupBox1.Margin = margin;
			this.groupBox1.Name = "groupBox1";
			Padding padding = new Padding(2);
			this.groupBox1.Padding = padding;
			System.Drawing.Size size = new System.Drawing.Size(1003, 559);
			this.groupBox1.Size = size;
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "分组测试参数表（双击行可单个编辑）";
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
				this.Column_startPin,
				this.Column_stopInterface,
				this.Column_stopPin,
				this.Column_DTThreshold,
				this.Column_JYThreshold,
				this.Column_JYTestTime,
				this.Column_JYVoltage,
				this.Column_NYThreshold,
				this.Column_NYTestTime,
				this.Column_NYVoltage
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
			System.Drawing.Size size2 = new System.Drawing.Size(999, 538);
			this.dataGridView1.Size = size2;
			this.dataGridView1.TabIndex = 13;
			this.dataGridView1.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
			this.Column_xh.HeaderText = "序号";
			this.Column_xh.Name = "Column_xh";
			this.Column_xh.ReadOnly = true;
			this.Column_xh.Width = 70;
			this.Column_startInterface.HeaderText = "起点接口";
			this.Column_startInterface.Name = "Column_startInterface";
			this.Column_startInterface.ReadOnly = true;
			this.Column_startPin.HeaderText = "起点接点";
			this.Column_startPin.Name = "Column_startPin";
			this.Column_startPin.ReadOnly = true;
			this.Column_stopInterface.HeaderText = "终点接口";
			this.Column_stopInterface.Name = "Column_stopInterface";
			this.Column_stopInterface.ReadOnly = true;
			this.Column_stopPin.HeaderText = "终点接点";
			this.Column_stopPin.Name = "Column_stopPin";
			this.Column_stopPin.ReadOnly = true;
			this.Column_DTThreshold.HeaderText = "导通阈值\n(Ω)";
			this.Column_DTThreshold.Name = "Column_DTThreshold";
			this.Column_DTThreshold.ReadOnly = true;
			this.Column_JYThreshold.HeaderText = "绝缘阈值\n(MΩ)";
			this.Column_JYThreshold.Name = "Column_JYThreshold";
			this.Column_JYThreshold.ReadOnly = true;
			this.Column_JYTestTime.HeaderText = "绝缘保持\n时间(s)";
			this.Column_JYTestTime.Name = "Column_JYTestTime";
			this.Column_JYTestTime.ReadOnly = true;
			this.Column_JYVoltage.HeaderText = "绝缘电压\n(VDC)";
			this.Column_JYVoltage.Name = "Column_JYVoltage";
			this.Column_JYVoltage.ReadOnly = true;
			this.Column_NYThreshold.HeaderText = "耐压阈值\n(mA)";
			this.Column_NYThreshold.Name = "Column_NYThreshold";
			this.Column_NYThreshold.ReadOnly = true;
			this.Column_NYTestTime.HeaderText = "耐压保持\n时间(s)";
			this.Column_NYTestTime.Name = "Column_NYTestTime";
			this.Column_NYTestTime.ReadOnly = true;
			this.Column_NYVoltage.HeaderText = "耐压电压\n(VAC)";
			this.Column_NYVoltage.Name = "Column_NYVoltage";
			this.Column_NYVoltage.ReadOnly = true;
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(623, 635);
			this.btnQuit.Location = location3;
			Padding margin3 = new Padding(2);
			this.btnQuit.Margin = margin3;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size3 = new System.Drawing.Size(90, 24);
			this.btnQuit.Size = size3;
			this.btnQuit.TabIndex = 7;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btnSubmit.Anchor = AnchorStyles.Bottom;
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(464, 635);
			this.btnSubmit.Location = location4;
			Padding margin4 = new Padding(2);
			this.btnSubmit.Margin = margin4;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size4 = new System.Drawing.Size(90, 24);
			this.btnSubmit.Size = size4;
			this.btnSubmit.TabIndex = 6;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.textBox_bcCable.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.textBox_bcCable.BorderStyle = BorderStyle.None;
			this.textBox_bcCable.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(100, 19);
			this.textBox_bcCable.Location = location5;
			Padding margin5 = new Padding(2);
			this.textBox_bcCable.Margin = margin5;
			this.textBox_bcCable.Name = "textBox_bcCable";
			this.textBox_bcCable.ReadOnly = true;
			System.Drawing.Size size5 = new System.Drawing.Size(861, 17);
			this.textBox_bcCable.Size = size5;
			this.textBox_bcCable.TabIndex = 9;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(14, 20);
			this.label1.Location = location6;
			Padding margin6 = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin6;
			this.label1.Name = "label1";
			System.Drawing.Size size6 = new System.Drawing.Size(75, 15);
			this.label1.Size = size6;
			this.label1.TabIndex = 8;
			this.label1.Text = "被测线束:";
			this.btnPLXG.Anchor = AnchorStyles.Bottom;
			this.btnPLXG.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(306, 635);
			this.btnPLXG.Location = location7;
			Padding margin7 = new Padding(2);
			this.btnPLXG.Margin = margin7;
			this.btnPLXG.Name = "btnPLXG";
			System.Drawing.Size size7 = new System.Drawing.Size(90, 24);
			this.btnPLXG.Size = size7;
			this.btnPLXG.TabIndex = 11;
			this.btnPLXG.Text = "批量修改";
			this.btnPLXG.UseVisualStyleBackColor = true;
			this.btnPLXG.Click += new System.EventHandler(this.btnPLXG_Click);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(1018, 691);
			base.ClientSize = clientSize;
			base.Controls.Add(this.btnPLXG);
			base.Controls.Add(this.textBox_bcCable);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnSubmit);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin8 = new Padding(2);
			base.Margin = margin8;
			base.Name = "ctFormGroupTestParaSet";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "分组测试参数设置";
			base.Load += new System.EventHandler(this.ctFormGroupTestParaSet_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormGroupTestParaSet_SizeChanged);
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			this.bSubmitSuccFlag = false;
			base.Close();
		}
		public void RefreshDataGridView()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.dataGridView1.Rows.Clear();
				int inum = 0;
				bool bExistFlag = false;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					try
					{
						string sqlcommand = "select * from TLineStructLibrary where LineStructName='" + this.gtpsCableStr + "'";
						OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						this.dataGridView1.AllowUserToAddRows = true;
						if (dataReader.Read())
						{
							this.tempLIDStr = dataReader["LID"].ToString();
							bExistFlag = true;
						}
						dataReader.Close();
						dataReader = null;
					}
					catch (System.Exception ex)
					{
						KLineTestProcessor.ExceptionRecordFunc(ex.StackTrace);
						if (dataReader != null)
						{
							dataReader.Close();
							dataReader = null;
						}
					}
					if (bExistFlag)
					{
						if (this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray.Count <= 0)
						{
							double dDT_Threshold = 5.0;
							double dJY_Threshold = 20.0;
							double dJY_JYHoldTime = 1.0;
							double dJY_DCHighVolt = 100.0;
							double dNY_Threshold = 2.0;
							double dNY_NYHoldTime = 1.0;
							double dNY_ACHighVolt = 100.0;
							try
							{
								string sqlcommand = "select * from TDefaultTestParaInfo";
								OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
								dataReader = cmd.ExecuteReader();
								if (dataReader.Read())
								{
									dDT_Threshold = System.Convert.ToDouble(dataReader["dDT_Threshold"].ToString());
									dJY_Threshold = System.Convert.ToDouble(dataReader["dJY_Threshold"].ToString());
									dJY_JYHoldTime = System.Convert.ToDouble(dataReader["dJY_JYHoldTime"].ToString());
									dJY_DCHighVolt = System.Convert.ToDouble(dataReader["dJY_DCHighVolt"].ToString());
									dNY_Threshold = System.Convert.ToDouble(dataReader["dNY_Threshold"].ToString());
									dNY_NYHoldTime = System.Convert.ToDouble(dataReader["dNY_NYHoldTime"].ToString());
									dNY_ACHighVolt = System.Convert.ToDouble(dataReader["dNY_ACHighVolt"].ToString());
								}
								dataReader.Close();
								dataReader = null;
							}
							catch (System.Exception ex2)
							{
								KLineTestProcessor.ExceptionRecordFunc(ex2.StackTrace);
								if (dataReader != null)
								{
									dataReader.Close();
									dataReader = null;
								}
							}
							string beDTThresholdStr = System.Convert.ToString(dDT_Threshold);
							string beJYThresholdStr = System.Convert.ToString(dJY_Threshold);
							string beJYTestTimeStr = System.Convert.ToString(dJY_JYHoldTime);
							string beJYVoltageStr = System.Convert.ToString(dJY_DCHighVolt);
							string beNYThresholdStr = System.Convert.ToString(dNY_Threshold);
							string beNYTestTimeStr = System.Convert.ToString(dNY_NYHoldTime);
							string beNYVoltageStr = System.Convert.ToString(dNY_ACHighVolt);
							string tempStr = beDTThresholdStr;
							int iTemp = beDTThresholdStr.LastIndexOf('.');
							if (iTemp == -1)
							{
								tempStr = beDTThresholdStr + ".";
								for (int i = 0; i < KLineTestProcessor.INT_DTTHRESHOLD_JD; i++)
								{
									tempStr += "0";
								}
							}
							else
							{
								while (iTemp + KLineTestProcessor.INT_DTTHRESHOLD_JD + 1 > tempStr.Length)
								{
									tempStr += "0";
									iTemp = tempStr.LastIndexOf('.');
								}
							}
							beDTThresholdStr = tempStr;
							tempStr = beJYThresholdStr;
							iTemp = beJYThresholdStr.LastIndexOf('.');
							if (iTemp == -1)
							{
								tempStr = beJYThresholdStr + ".";
								for (int j = 0; j < KLineTestProcessor.INT_JYTHRESHOLD_JD; j++)
								{
									tempStr += "0";
								}
							}
							else
							{
								while (iTemp + KLineTestProcessor.INT_JYTHRESHOLD_JD + 1 > tempStr.Length)
								{
									tempStr += "0";
									iTemp = tempStr.LastIndexOf('.');
								}
							}
							beJYThresholdStr = tempStr;
							tempStr = beJYTestTimeStr;
							iTemp = beJYTestTimeStr.LastIndexOf('.');
							if (iTemp == -1)
							{
								tempStr = beJYTestTimeStr + ".";
								for (int k = 0; k < KLineTestProcessor.INT_JYTESTTIME_JD; k++)
								{
									tempStr += "0";
								}
							}
							else
							{
								while (iTemp + KLineTestProcessor.INT_JYTESTTIME_JD + 1 > tempStr.Length)
								{
									tempStr += "0";
									iTemp = tempStr.LastIndexOf('.');
								}
							}
							beJYTestTimeStr = tempStr;
							tempStr = beJYVoltageStr;
							iTemp = beJYVoltageStr.LastIndexOf('.');
							if (iTemp == -1)
							{
								tempStr = beJYVoltageStr + ".";
								for (int l = 0; l < KLineTestProcessor.INT_JYVOLTAGE_JD; l++)
								{
									tempStr += "0";
								}
							}
							else
							{
								while (iTemp + KLineTestProcessor.INT_JYVOLTAGE_JD + 1 > tempStr.Length)
								{
									tempStr += "0";
									iTemp = tempStr.LastIndexOf('.');
								}
							}
							beJYVoltageStr = tempStr;
							tempStr = beNYThresholdStr;
							iTemp = beNYThresholdStr.LastIndexOf('.');
							if (iTemp == -1)
							{
								tempStr = beNYThresholdStr + ".";
								for (int m = 0; m < KLineTestProcessor.INT_NYTHRESHOLD_JD; m++)
								{
									tempStr += "0";
								}
							}
							else
							{
								while (iTemp + KLineTestProcessor.INT_NYTHRESHOLD_JD + 1 > tempStr.Length)
								{
									tempStr += "0";
									iTemp = tempStr.LastIndexOf('.');
								}
							}
							beNYThresholdStr = tempStr;
							tempStr = beNYTestTimeStr;
							iTemp = beNYTestTimeStr.LastIndexOf('.');
							if (iTemp == -1)
							{
								tempStr = beNYTestTimeStr + ".";
								for (int n = 0; n < KLineTestProcessor.INT_NYTESTTIME_JD; n++)
								{
									tempStr += "0";
								}
							}
							else
							{
								while (iTemp + KLineTestProcessor.INT_NYTESTTIME_JD + 1 > tempStr.Length)
								{
									tempStr += "0";
									iTemp = tempStr.LastIndexOf('.');
								}
							}
							beNYTestTimeStr = tempStr;
							tempStr = beNYVoltageStr;
							iTemp = beNYVoltageStr.LastIndexOf('.');
							if (iTemp == -1)
							{
								tempStr = beNYVoltageStr + ".";
								for (int i2 = 0; i2 < KLineTestProcessor.INT_NYVOLTAGE_JD; i2++)
								{
									tempStr += "0";
								}
							}
							else
							{
								while (iTemp + KLineTestProcessor.INT_NYVOLTAGE_JD + 1 > tempStr.Length)
								{
									tempStr += "0";
									iTemp = tempStr.LastIndexOf('.');
								}
							}
							beNYVoltageStr = tempStr;
							try
							{
								string sqlcommand = "select * from TLineStructLibraryDetail where LID='" + this.tempLIDStr + "' order by LDID asc";
								OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
								dataReader = cmd.ExecuteReader();
								this.dataGridView1.AllowUserToAddRows = true;
								while (dataReader.Read())
								{
									this.dataGridView1.Rows.Add(1);
									int num = inum + 1;
									this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
									this.dataGridView1.Rows[inum].Cells[1].Value = dataReader["PlugName1"].ToString();
									this.dataGridView1.Rows[inum].Cells[2].Value = dataReader["PinName1"].ToString();
									this.dataGridView1.Rows[inum].Cells[3].Value = dataReader["PlugName2"].ToString();
									this.dataGridView1.Rows[inum].Cells[4].Value = dataReader["PinName2"].ToString();
									this.dataGridView1.Rows[inum].Cells[5].Value = beDTThresholdStr;
									this.dataGridView1.Rows[inum].Cells[6].Value = beJYThresholdStr;
									this.dataGridView1.Rows[inum].Cells[7].Value = beJYTestTimeStr;
									this.dataGridView1.Rows[inum].Cells[8].Value = beJYVoltageStr;
									this.dataGridView1.Rows[inum].Cells[9].Value = beNYThresholdStr;
									this.dataGridView1.Rows[inum].Cells[10].Value = beNYTestTimeStr;
									this.dataGridView1.Rows[inum].Cells[11].Value = beNYVoltageStr;
									inum = num;
								}
								this.dataGridView1.AllowUserToAddRows = false;
								dataReader.Close();
								dataReader = null;
							}
							catch (System.Exception ex3)
							{
								this.dataGridView1.AllowUserToAddRows = false;
								KLineTestProcessor.ExceptionRecordFunc(ex3.StackTrace);
								if (dataReader != null)
								{
									dataReader.Close();
									dataReader = null;
								}
							}
						}
						else
						{
							this.dataGridView1.AllowUserToAddRows = true;
							int num2;
							for (int i3 = 0; i3 < this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray.Count; i3 = num2)
							{
								this.dataGridView1.Rows.Add(1);
								num2 = i3 + 1;
								this.dataGridView1.Rows[i3].Cells[0].Value = System.Convert.ToString(num2);
								this.dataGridView1.Rows[i3].Cells[1].Value = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i3].PlugName1;
								this.dataGridView1.Rows[i3].Cells[2].Value = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i3].PinName1;
								this.dataGridView1.Rows[i3].Cells[3].Value = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i3].PlugName2;
								this.dataGridView1.Rows[i3].Cells[4].Value = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i3].PinName2;
								this.dataGridView1.Rows[i3].Cells[5].Value = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i3].DTThreshold;
								this.dataGridView1.Rows[i3].Cells[6].Value = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i3].JYThreshold;
								this.dataGridView1.Rows[i3].Cells[7].Value = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i3].JYTestTime;
								this.dataGridView1.Rows[i3].Cells[8].Value = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i3].JYVoltage;
								this.dataGridView1.Rows[i3].Cells[9].Value = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i3].NYThreshold;
								this.dataGridView1.Rows[i3].Cells[10].Value = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i3].NYTestTime;
								this.dataGridView1.Rows[i3].Cells[11].Value = this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[i3].NYVoltage;
							}
							this.dataGridView1.AllowUserToAddRows = false;
						}
						connection.Close();
						connection = null;
					}
				}
				catch (System.Exception ex4)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(ex4.StackTrace);
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
			catch (System.Exception ex5)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex5.StackTrace);
			}
		}
		private void ctFormGroupTestParaSet_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.textBox_bcCable.Text = this.gtpsCableStr;
				this.gtParaInfo.GroupTestParaStructArray = new System.Collections.Generic.List<GroupTestParaStruct>();
				this.Column_DTThreshold.Visible = this.gLineTestProcessor.bDTTestEnabled;
				this.Column_JYThreshold.Visible = false;
				this.Column_JYTestTime.Visible = false;
				this.Column_JYVoltage.Visible = false;
				KLineTestProcessor e2 = this.gLineTestProcessor;
				if (e2.bJYTestEnabled || e2.bDDJYTestEnabled)
				{
					this.Column_JYThreshold.Visible = true;
					this.Column_JYTestTime.Visible = true;
					this.Column_JYVoltage.Visible = true;
				}
				this.Column_NYThreshold.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.Column_NYTestTime.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.Column_NYVoltage.Visible = this.gLineTestProcessor.bNYTestEnabled;
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
			catch (System.Exception arg_16C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_16C_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
		}
		public void SaveDataToDBFunc()
		{
			OleDbConnection connection = null;
			try
			{
				try
				{
					this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray = new System.Collections.Generic.List<GroupTestParaStruct>();
					int num;
					for (int i = 0; i < this.dataGridView1.Rows.Count; i = num)
					{
						string temp1Str = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
						string temp2Str = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
						string temp3Str = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
						string temp4Str = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
						string text = "";
						string temp5Str = text;
						string temp6Str = text;
						string temp7Str = text;
						string temp8Str = text;
						string temp9Str = text;
						string temp10Str = text;
						string temp11Str = text;
						if (this.dataGridView1.Rows[i].Cells[5].Value != null)
						{
							temp5Str = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
						}
						if (this.dataGridView1.Rows[i].Cells[6].Value != null)
						{
							temp6Str = this.dataGridView1.Rows[i].Cells[6].Value.ToString();
						}
						if (this.dataGridView1.Rows[i].Cells[7].Value != null)
						{
							temp7Str = this.dataGridView1.Rows[i].Cells[7].Value.ToString();
						}
						if (this.dataGridView1.Rows[i].Cells[8].Value != null)
						{
							temp8Str = this.dataGridView1.Rows[i].Cells[8].Value.ToString();
						}
						if (this.dataGridView1.Rows[i].Cells[9].Value != null)
						{
							temp9Str = this.dataGridView1.Rows[i].Cells[9].Value.ToString();
						}
						if (this.dataGridView1.Rows[i].Cells[10].Value != null)
						{
							temp10Str = this.dataGridView1.Rows[i].Cells[10].Value.ToString();
						}
						if (this.dataGridView1.Rows[i].Cells[11].Value != null)
						{
							temp11Str = this.dataGridView1.Rows[i].Cells[11].Value.ToString();
						}
						GroupTestParaStruct gtpStruct = new GroupTestParaStruct();
						num = i + 1;
						gtpStruct.ixh = num;
						gtpStruct.PlugName1 = temp1Str;
						gtpStruct.PinName1 = temp2Str;
						gtpStruct.PlugName2 = temp3Str;
						gtpStruct.PinName2 = temp4Str;
						gtpStruct.DTThreshold = temp5Str;
						gtpStruct.JYThreshold = temp6Str;
						gtpStruct.JYTestTime = temp7Str;
						gtpStruct.JYVoltage = temp8Str;
						gtpStruct.NYThreshold = temp9Str;
						gtpStruct.NYTestTime = temp10Str;
						gtpStruct.NYVoltage = temp11Str;
						this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray.Add(gtpStruct);
					}
				}
				catch (System.Exception arg_3B0_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_3B0_0.StackTrace);
				}
				if (!this.bNewProjectFlag)
				{
					string pIDStr = System.Convert.ToString(this.iProjectID);
					try
					{
						connection = new OleDbConnection();
						connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
						connection.Open();
						string sqlcommand = "delete from TGroupTestParaSet where PID='" + pIDStr + "' and LID='" + this.tempLIDStr + "'";
						OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
						cmd.ExecuteNonQuery();
						System.Threading.Thread.Sleep(50);
						try
						{
							for (int j = 0; j < this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray.Count; j++)
							{
								string str = "','";
								sqlcommand = "insert into TGroupTestParaSet(PID,LID,PlugName1,PinName1,PlugName2,PinName2," + "DTThreshold,DTVoltage,DTCurrent,JYThreshold,JYTestTime,JYVoltage,JYUpTime,NYThreshold,NYTestTime,NYVoltage)" + " values('" + pIDStr + str + this.tempLIDStr + str + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].PlugName1 + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].PinName1 + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].PlugName2 + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].PinName2 + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].DTThreshold + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].DTVoltage + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].DTCurrent + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].JYThreshold + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].JYTestTime + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].JYVoltage + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].JYUpTime + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].NYThreshold + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].NYTestTime + "','" + this.gLineTestProcessor.groupTestParaInfo.GroupTestParaStructArray[j].NYVoltage + "')";
								cmd = new OleDbCommand(sqlcommand, connection);
								cmd.ExecuteNonQuery();
							}
						}
						catch (System.Exception arg_706_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_706_0.StackTrace);
						}
						connection.Close();
						connection = null;
					}
					catch (System.Exception arg_71E_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_71E_0.StackTrace);
						if (connection != null)
						{
							connection.Close();
							connection = null;
						}
					}
				}
			}
			catch (System.Exception arg_73A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_73A_0.StackTrace);
			}
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.SaveDataToDBFunc();
				this.bSubmitSuccFlag = true;
				base.Close();
			}
			catch (System.Exception arg_15_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_15_0.StackTrace);
			}
		}
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 776;
					int iy = 0;
					int iy2 = 0;
					int ia = 0;
					if (iw > 0)
					{
						int iGroupTestDGVColCount = this.gLineTestProcessor.iGroupTestDGVColCount;
						ia = iw / iGroupTestDGVColCount;
						iy2 = iw % iGroupTestDGVColCount;
					}
					int iTWidth = 115;
					try
					{
						int iGroupTestDGVColCount2 = this.gLineTestProcessor.iGroupTestDGVColCount;
						iTWidth = 690 / iGroupTestDGVColCount2;
						iy = 690 - iGroupTestDGVColCount2 * iTWidth;
					}
					catch (System.Exception ex_69)
					{
					}
					this.dataGridView1.Columns[0].Width = iy + 64;
					int width = ia + (iy2 / 2 + iTWidth);
					this.dataGridView1.Columns[1].Width = width;
					int this2 = ia + iTWidth;
					this.dataGridView1.Columns[2].Width = this2;
					this.dataGridView1.Columns[3].Width = width;
					this.dataGridView1.Columns[4].Width = this2;
					this.dataGridView1.Columns[5].Width = this2;
					this.dataGridView1.Columns[6].Width = this2;
					this.dataGridView1.Columns[7].Width = this2;
					this.dataGridView1.Columns[8].Width = this2;
					this.dataGridView1.Columns[9].Width = this2;
					this.dataGridView1.Columns[10].Width = this2;
					this.dataGridView1.Columns[11].Width = this2;
				}
			}
			catch (System.Exception arg_19D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_19D_0.StackTrace);
			}
		}
		private void ctFormGroupTestParaSet_SizeChanged(object sender, System.EventArgs e)
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
					try
					{
						this.gtpTempStruct = new GroupTestParaStruct();
						string tempStr = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
						this.gtpTempStruct.ixh = System.Convert.ToInt32(tempStr) - 1;
						this.gtpTempStruct.PlugName1 = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
						this.gtpTempStruct.PinName1 = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
						this.gtpTempStruct.PlugName2 = this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
						this.gtpTempStruct.PinName2 = this.dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
						tempStr = "";
						if (this.dataGridView1.SelectedRows[0].Cells[5].Value != null)
						{
							tempStr = this.dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
						}
						this.gtpTempStruct.DTThreshold = tempStr;
						tempStr = "";
						if (this.dataGridView1.SelectedRows[0].Cells[6].Value != null)
						{
							tempStr = this.dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
						}
						this.gtpTempStruct.JYThreshold = tempStr;
						tempStr = "";
						if (this.dataGridView1.SelectedRows[0].Cells[7].Value != null)
						{
							tempStr = this.dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
						}
						this.gtpTempStruct.JYTestTime = tempStr;
						tempStr = "";
						if (this.dataGridView1.SelectedRows[0].Cells[8].Value != null)
						{
							tempStr = this.dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
						}
						this.gtpTempStruct.JYVoltage = tempStr;
						tempStr = "";
						if (this.dataGridView1.SelectedRows[0].Cells[9].Value != null)
						{
							tempStr = this.dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
						}
						this.gtpTempStruct.NYThreshold = tempStr;
						tempStr = "";
						if (this.dataGridView1.SelectedRows[0].Cells[10].Value != null)
						{
							tempStr = this.dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
						}
						this.gtpTempStruct.NYTestTime = tempStr;
						tempStr = "";
						if (this.dataGridView1.SelectedRows[0].Cells[11].Value != null)
						{
							tempStr = this.dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
						}
						this.gtpTempStruct.NYVoltage = tempStr;
					}
					catch (System.Exception arg_3C7_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_3C7_0.StackTrace);
						goto IL_57D;
					}
					try
					{
						ctFormEditGroupTestPara ctFormEditGroupTestPara = new ctFormEditGroupTestPara(this.gLineTestProcessor, this.gtpTempStruct);
						this.editGroupTestParaForm = ctFormEditGroupTestPara;
						ctFormEditGroupTestPara.Activate();
						this.editGroupTestParaForm.ShowDialog();
						if (this.editGroupTestParaForm.bSubmitSuccFlag)
						{
							try
							{
								ctFormEditGroupTestPara e2 = this.editGroupTestParaForm;
								string beDTThresholdStr = e2.beDTThresholdStr;
								string beJYThresholdStr = e2.beJYThresholdStr;
								string beJYTestTimeStr = e2.beJYTestTimeStr;
								string beJYVoltageStr = e2.beJYVoltageStr;
								string beNYThresholdStr = e2.beNYThresholdStr;
								string beNYTestTimeStr = e2.beNYTestTimeStr;
								string beNYVoltageStr = e2.beNYVoltageStr;
								int iNum = this.gtpTempStruct.ixh;
								this.dataGridView1.Rows[iNum].Cells[5].Value = beDTThresholdStr;
								this.dataGridView1.Rows[iNum].Cells[6].Value = beJYThresholdStr;
								this.dataGridView1.Rows[iNum].Cells[7].Value = beJYTestTimeStr;
								this.dataGridView1.Rows[iNum].Cells[8].Value = beJYVoltageStr;
								this.dataGridView1.Rows[iNum].Cells[9].Value = beNYThresholdStr;
								this.dataGridView1.Rows[iNum].Cells[10].Value = beNYTestTimeStr;
								this.dataGridView1.Rows[iNum].Cells[11].Value = beNYVoltageStr;
							}
							catch (System.Exception arg_55A_0)
							{
								KLineTestProcessor.ExceptionRecordFunc(arg_55A_0.StackTrace);
							}
							this.bDataChangedFlag = true;
						}
					}
					catch (System.Exception arg_56F_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_56F_0.StackTrace);
					}
					IL_57D:;
				}
			}
			catch (System.Exception arg_581_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_581_0.StackTrace);
			}
		}
		private void btnPLXG_Click(object sender, System.EventArgs e)
		{
			try
			{
				ctFormBatchEditGroupTestPara ctFormBatchEditGroupTestPara = new ctFormBatchEditGroupTestPara(this.gLineTestProcessor, this.gtpsCableStr);
				this.batchEditGroupTestParaForm = ctFormBatchEditGroupTestPara;
				ctFormBatchEditGroupTestPara.Activate();
				this.batchEditGroupTestParaForm.ShowDialog();
				if (this.batchEditGroupTestParaForm.bSubmitSuccFlag)
				{
					try
					{
						ctFormBatchEditGroupTestPara e2 = this.batchEditGroupTestParaForm;
						string beJKStr = e2.beJKStr;
						string beDTThresholdStr = e2.beDTThresholdStr;
						string beJYThresholdStr = e2.beJYThresholdStr;
						string beJYTestTimeStr = e2.beJYTestTimeStr;
						string beJYVoltageStr = e2.beJYVoltageStr;
						string beNYThresholdStr = e2.beNYThresholdStr;
						string beNYTestTimeStr = e2.beNYTestTimeStr;
						string beNYVoltageStr = e2.beNYVoltageStr;
						if (e2.bUpdateAllPlugFlag)
						{
							for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
							{
								this.dataGridView1.Rows[i].Cells[5].Value = beDTThresholdStr;
								this.dataGridView1.Rows[i].Cells[6].Value = beJYThresholdStr;
								this.dataGridView1.Rows[i].Cells[7].Value = beJYTestTimeStr;
								this.dataGridView1.Rows[i].Cells[8].Value = beJYVoltageStr;
								this.dataGridView1.Rows[i].Cells[9].Value = beNYThresholdStr;
								this.dataGridView1.Rows[i].Cells[10].Value = beNYTestTimeStr;
								this.dataGridView1.Rows[i].Cells[11].Value = beNYVoltageStr;
							}
						}
						else
						{
							for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
							{
								string temp1Str = this.dataGridView1.Rows[j].Cells[1].Value.ToString();
								string temp2Str = this.dataGridView1.Rows[j].Cells[3].Value.ToString();
								if (temp1Str == beJKStr || temp2Str == beJKStr)
								{
									this.dataGridView1.Rows[j].Cells[5].Value = beDTThresholdStr;
									this.dataGridView1.Rows[j].Cells[6].Value = beJYThresholdStr;
									this.dataGridView1.Rows[j].Cells[7].Value = beJYTestTimeStr;
									this.dataGridView1.Rows[j].Cells[8].Value = beJYVoltageStr;
									this.dataGridView1.Rows[j].Cells[9].Value = beNYThresholdStr;
									this.dataGridView1.Rows[j].Cells[10].Value = beNYTestTimeStr;
									this.dataGridView1.Rows[j].Cells[11].Value = beNYVoltageStr;
								}
							}
						}
					}
					catch (System.Exception arg_33C_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_33C_0.StackTrace);
					}
					this.bDataChangedFlag = true;
				}
			}
			catch (System.Exception arg_351_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_351_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormGroupTestParaSet();
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
