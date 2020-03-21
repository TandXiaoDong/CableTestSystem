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
	public class ctFormSelfStudyPinRelation : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public ctFormSelfStudyPinRelationView selfStudyPinRelationViewForm;
		public static string PLUGPIN_UNDEFINED_STR = "未定义";
		public static string UN_TEST_COMM_STR = "--";
		public string dbpath;
		public string loginUser;
		public bool bSelfStudyFlag;
		public int iStartValue;
		public int iEndValue;
		public int iDTLimitedValue;
		public int iTestTime;
		public bool bImportFlag;
		public int iStudyModel;
		public int[] iPlugStartPin;
		public int[] iPlugStopPin;
		public string[] studyPlugStrArray;
		public bool bDLTestFlag;
		public int iCurrentCount;
		public int iPlugPinIndex;
		private Button btnTHXSGX;
		private System.Windows.Forms.Timer timer1;
		private Button btnOnOffStudy;
		private ProgressBar progressBar1;
		private DataGridView dataGridView1;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private DataGridView dataGridView2;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private Button btnImport;
		private Button btnQuit;
		private IContainer components;
		public ctFormSelfStudyPinRelation(KLineTestProcessor gltProcessor, string lUser, string[] studyPlugArray, int iDTValue, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool bDLIsTestFlag)
		{
			try
			{
				this.InitializeComponent();
				this.loginUser = lUser;
				this.gLineTestProcessor = gltProcessor;
				this.bDLTestFlag = bDLIsTestFlag;
				this.bSelfStudyFlag = false;
				int lUser2 = studyPlugArray.Length;
				if (lUser2 > 0)
				{
					this.studyPlugStrArray = new string[lUser2];
					int i = 0;
					if (0 < studyPlugArray.Length)
					{
						do
						{
							this.studyPlugStrArray[i] = studyPlugArray[i];
							i++;
						}
						while (i < studyPlugArray.Length);
					}
					string[] gltProcessor2 = this.studyPlugStrArray;
					this.iPlugStartPin = new int[gltProcessor2.Length];
					this.iPlugStopPin = new int[gltProcessor2.Length];
				}
				this.iDTLimitedValue = iDTValue;
				this.bImportFlag = false;
				this.iStudyModel = 1;
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		public ctFormSelfStudyPinRelation(KLineTestProcessor gltProcessor, string lUser, string[] studyPlugArray, int iDTValue)
		{
			try
			{
				this.InitializeComponent();
				this.loginUser = lUser;
				this.gLineTestProcessor = gltProcessor;
				this.bSelfStudyFlag = false;
				int lUser2 = studyPlugArray.Length;
				if (lUser2 > 0)
				{
					this.studyPlugStrArray = new string[lUser2];
					int i = 0;
					if (0 < studyPlugArray.Length)
					{
						do
						{
							this.studyPlugStrArray[i] = studyPlugArray[i];
							i++;
						}
						while (i < studyPlugArray.Length);
					}
					string[] gltProcessor2 = this.studyPlugStrArray;
					this.iPlugStartPin = new int[gltProcessor2.Length];
					this.iPlugStopPin = new int[gltProcessor2.Length];
				}
				this.iDTLimitedValue = iDTValue;
				this.bImportFlag = false;
				this.iStudyModel = 1;
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		public ctFormSelfStudyPinRelation(KLineTestProcessor gltProcessor, string lUser, int iStart, int iEnd, int iDTValue)
		{
			try
			{
				this.InitializeComponent();
				this.loginUser = lUser;
				this.gLineTestProcessor = gltProcessor;
				this.bSelfStudyFlag = false;
				this.iStartValue = iStart;
				this.iEndValue = iEnd;
				this.iDTLimitedValue = iDTValue;
				this.bImportFlag = false;
				this.iStudyModel = 0;
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormSelfStudyPinRelation()
		{
			IContainer this2 = this.components;
			if (this2 != null)
			{
				this2.Dispose();
			}
		}
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormSelfStudyPinRelation));
			this.progressBar1 = new ProgressBar();
			this.dataGridView1 = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.groupBox1 = new GroupBox();
			this.groupBox2 = new GroupBox();
			this.dataGridView2 = new DataGridView();
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.btnImport = new Button();
			this.btnQuit = new Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.btnOnOffStudy = new Button();
			this.btnTHXSGX = new Button();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.dataGridView2).BeginInit();
			base.SuspendLayout();
			System.Drawing.Color green = System.Drawing.Color.Green;
			this.progressBar1.ForeColor = green;
			System.Drawing.Point location = new System.Drawing.Point(35, 24);
			this.progressBar1.Location = location;
			Padding margin = new Padding(2);
			this.progressBar1.Margin = margin;
			this.progressBar1.Name = "progressBar1";
			System.Drawing.Size size = new System.Drawing.Size(465, 24);
			this.progressBar1.Size = size;
			this.progressBar1.TabIndex = 0;
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
				this.Column2
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
			System.Drawing.Size size2 = new System.Drawing.Size(221, 458);
			this.dataGridView1.Size = size2;
			this.dataGridView1.TabIndex = 13;
			this.Column1.HeaderText = "序号";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 80;
			this.Column2.HeaderText = "针脚关系";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 120;
			this.groupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(35, 67);
			this.groupBox1.Location = location3;
			Padding margin3 = new Padding(2);
			this.groupBox1.Margin = margin3;
			this.groupBox1.Name = "groupBox1";
			Padding padding = new Padding(2);
			this.groupBox1.Padding = padding;
			System.Drawing.Size size3 = new System.Drawing.Size(225, 479);
			this.groupBox1.Size = size3;
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "已连接针脚关系";
			this.groupBox2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
			this.groupBox2.Controls.Add(this.dataGridView2);
			this.groupBox2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(275, 67);
			this.groupBox2.Location = location4;
			Padding margin4 = new Padding(2);
			this.groupBox2.Margin = margin4;
			this.groupBox2.Name = "groupBox2";
			Padding padding2 = new Padding(2);
			this.groupBox2.Padding = padding2;
			System.Drawing.Size size4 = new System.Drawing.Size(225, 479);
			this.groupBox2.Size = size4;
			this.groupBox2.TabIndex = 14;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "未连接针脚列表";
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.AllowUserToResizeColumns = false;
			this.dataGridView2.AllowUserToResizeRows = false;
			System.Drawing.Color window2 = System.Drawing.SystemColors.Window;
			this.dataGridView2.BackgroundColor = window2;
			this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns2 = new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn1,
				this.dataGridViewTextBoxColumn2
			};
			this.dataGridView2.Columns.AddRange(dataGridViewColumns2);
			this.dataGridView2.Dock = DockStyle.Fill;
			System.Drawing.Point location5 = new System.Drawing.Point(2, 19);
			this.dataGridView2.Location = location5;
			Padding margin5 = new Padding(2);
			this.dataGridView2.Margin = margin5;
			this.dataGridView2.MultiSelect = false;
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.RowHeadersVisible = false;
			this.dataGridView2.RowTemplate.Height = 27;
			this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size5 = new System.Drawing.Size(221, 458);
			this.dataGridView2.Size = size5;
			this.dataGridView2.TabIndex = 13;
			this.dataGridViewTextBoxColumn1.HeaderText = "序号";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 80;
			this.dataGridViewTextBoxColumn2.HeaderText = "针脚号";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 120;
			this.btnImport.Anchor = AnchorStyles.Top;
			this.btnImport.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(576, 292);
			this.btnImport.Location = location6;
			Padding margin6 = new Padding(2);
			this.btnImport.Margin = margin6;
			this.btnImport.Name = "btnImport";
			System.Drawing.Size size6 = new System.Drawing.Size(150, 28);
			this.btnImport.Size = size6;
			this.btnImport.TabIndex = 2;
			this.btnImport.Text = "导入项目";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			this.btnQuit.Anchor = AnchorStyles.Top;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(576, 428);
			this.btnQuit.Location = location7;
			Padding margin7 = new Padding(2);
			this.btnQuit.Margin = margin7;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size7 = new System.Drawing.Size(150, 28);
			this.btnQuit.Size = size7;
			this.btnQuit.TabIndex = 3;
			this.btnQuit.Text = "关闭";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			this.btnOnOffStudy.Anchor = AnchorStyles.Top;
			this.btnOnOffStudy.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(576, 24);
			this.btnOnOffStudy.Location = location8;
			Padding margin8 = new Padding(2);
			this.btnOnOffStudy.Margin = margin8;
			this.btnOnOffStudy.Name = "btnOnOffStudy";
			System.Drawing.Size size8 = new System.Drawing.Size(150, 24);
			this.btnOnOffStudy.Size = size8;
			this.btnOnOffStudy.TabIndex = 1;
			this.btnOnOffStudy.Text = "开始学习";
			this.btnOnOffStudy.UseVisualStyleBackColor = true;
			this.btnOnOffStudy.Click += new System.EventHandler(this.btnOnOffStudy_Click);
			this.btnTHXSGX.Anchor = AnchorStyles.Top;
			this.btnTHXSGX.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(576, 156);
			this.btnTHXSGX.Location = location9;
			Padding margin9 = new Padding(2);
			this.btnTHXSGX.Margin = margin9;
			this.btnTHXSGX.Name = "btnTHXSGX";
			System.Drawing.Size size9 = new System.Drawing.Size(150, 28);
			this.btnTHXSGX.Size = size9;
			this.btnTHXSGX.TabIndex = 2;
			this.btnTHXSGX.Text = "查看芯线关系";
			this.btnTHXSGX.UseVisualStyleBackColor = true;
			this.btnTHXSGX.Visible = false;
			this.btnTHXSGX.Click += new System.EventHandler(this.btnTHXSGX_Click);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnOnOffStudy);
			base.Controls.Add(this.btnTHXSGX);
			base.Controls.Add(this.btnImport);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.progressBar1);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin10 = new Padding(2);
			base.Margin = margin10;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormSelfStudyPinRelation";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "自学习针脚对应关系";
			base.FormClosing += new FormClosingEventHandler(this.ctFormSelfStudyPinRelation_FormClosing);
			base.Load += new System.EventHandler(this.ctFormSelfStudyPinRelation_Load);
			((ISupportInitialize)this.dataGridView1).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView2).EndInit();
			base.ResumeLayout(false);
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			this.bImportFlag = false;
			base.Close();
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool GetStartStopPinFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				if (this.studyPlugStrArray == null)
				{
					return false;
				}
				System.Collections.Generic.List<int> zjtPinNumList = new System.Collections.Generic.List<int>();
				System.Collections.Generic.List<int> csyPinNumList = new System.Collections.Generic.List<int>();
				string text = "";
				string tempStr = text;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					int i = 0;
					while (true)
					{
						string[] array = this.studyPlugStrArray;
						if (i >= array.Length)
						{
							break;
						}
						string plugNameStr = array[i];
						if (!string.IsNullOrEmpty(plugNameStr))
						{
							zjtPinNumList.Clear();
							csyPinNumList.Clear();
							tempStr = "";
							try
							{
								string sqlcommand = "select * from TPlugLibrary where PlugNo = '" + plugNameStr + "'";
								OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
								dataReader = cmd.ExecuteReader();
								if (dataReader.Read())
								{
									tempStr = dataReader["PID"].ToString();
								}
								dataReader.Close();
								dataReader = null;
							}
							catch (System.Exception arg_EC_0)
							{
								KLineTestProcessor.ExceptionRecordFunc(arg_EC_0.StackTrace);
								if (dataReader != null)
								{
									dataReader.Close();
									dataReader = null;
								}
							}
							if (!string.IsNullOrEmpty(tempStr))
							{
								try
								{
									string sqlcommand = "select * from TPlugLibraryDetail where PID='" + tempStr + "' order by PDID";
									OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
									dataReader = cmd.ExecuteReader();
									while (dataReader.Read())
									{
										string temp1Str = dataReader["DevicePinNum"].ToString();
										string[] tempArray = temp1Str.Split(new char[]
										{
											','
										});
										int iTemp = System.Convert.ToInt32(tempArray[0]);
										zjtPinNumList.Add(iTemp);
										if (tempArray.Length >= 2)
										{
											iTemp = System.Convert.ToInt32(tempArray[1]);
											zjtPinNumList.Add(iTemp);
										}
									}
									dataReader.Close();
									dataReader = null;
								}
								catch (System.Exception arg_1AC_0)
								{
									KLineTestProcessor.ExceptionRecordFunc(arg_1AC_0.StackTrace);
									if (dataReader != null)
									{
										dataReader.Close();
										dataReader = null;
									}
								}
								if (this.gLineTestProcessor.bUseRelayBoard)
								{
									string sqlcommand = "select * from TIAndRTPinReletionData order by ID";
									OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
									dataReader = cmd.ExecuteReader();
									while (dataReader.Read())
									{
										string temp1Str = dataReader["AT_PinNum"].ToString();
										string temp2Str = dataReader["TI_PinNum"].ToString();
										if (!string.IsNullOrEmpty(temp1Str) && !string.IsNullOrEmpty(temp2Str))
										{
											int iTemp = System.Convert.ToInt32(temp1Str);
											for (int j = 0; j < zjtPinNumList.Count; j++)
											{
												if (zjtPinNumList[j] == iTemp)
												{
													iTemp = System.Convert.ToInt32(temp2Str);
													csyPinNumList.Add(iTemp);
													break;
												}
											}
										}
									}
									dataReader.Close();
									dataReader = null;
									if (csyPinNumList.Count > 0)
									{
										int iMax = csyPinNumList[0];
										int iMin = csyPinNumList[0];
										for (int k = 0; k < csyPinNumList.Count; k++)
										{
											if (csyPinNumList[k] > iMax)
											{
												iMax = csyPinNumList[k];
											}
											if (csyPinNumList[k] < iMin)
											{
												iMin = csyPinNumList[k];
											}
										}
										this.iPlugStartPin[i] = iMin;
										this.iPlugStopPin[i] = iMax;
									}
								}
								else if (zjtPinNumList.Count > 0)
								{
									int iMax = zjtPinNumList[0];
									int iMin = zjtPinNumList[0];
									for (int l = 0; l < zjtPinNumList.Count; l++)
									{
										if (zjtPinNumList[l] > iMax)
										{
											iMax = zjtPinNumList[l];
										}
										if (zjtPinNumList[l] < iMin)
										{
											iMin = zjtPinNumList[l];
										}
									}
									this.iPlugStartPin[i] = iMin;
									this.iPlugStopPin[i] = iMax;
								}
							}
						}
						i++;
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_38E_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_38E_0.StackTrace);
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
			catch (System.Exception arg_3B2_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3B2_0.StackTrace);
			}
			return true;
		}
		private void ctFormSelfStudyPinRelation_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
				this.iPlugPinIndex = 0;
				this.iCurrentCount = 0;
				if (!this.bDLTestFlag)
				{
					this.bImportFlag = false;
					this.bSelfStudyFlag = false;
					this.dataGridView1.Rows.Clear();
					this.dataGridView2.Rows.Clear();
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
					if (!this.gLineTestProcessor.bOpenProjectFlag)
					{
						this.btnImport.Visible = false;
					}
					if (this.iStudyModel == 1)
					{
						if (this.gLineTestProcessor.bAllStudyFlag)
						{
							this.btnTHXSGX.Visible = true;
						}
						this.GetStartStopPinFunc();
					}
					this.btnOnOffStudy_Click(null, null);
				}
				else
				{
					this.GetStartStopPinFunc();
					this.btnOnOffStudy_Click(null, null);
				}
			}
			catch (System.Exception arg_1D1_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1D1_0.StackTrace);
			}
		}
		private void btnImport_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.bDLTestFlag)
				{
					if (this.bSelfStudyFlag)
					{
						MessageBox.Show("正在进行自学习!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						this.gLineTestProcessor.SendStopCmd();
						this.gLineTestProcessor.ExportSELFTest();
						this.bImportFlag = true;
						base.Close();
					}
				}
			}
			catch (System.Exception arg_48_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_48_0.StackTrace);
			}
		}
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			try
			{
				KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
				if (kLineTestProcessor.bEmulationMode && kLineTestProcessor.mbKeepRun)
				{
					if (this.iStudyModel == 0)
					{
						int num = this.iStartValue;
						if (this.iEndValue >= num + 1)
						{
							KParseRepCmd mParseCmd = kLineTestProcessor.mpDevComm.mParseCmd;
							mParseCmd.firstPinArray[mParseCmd.selfStudyPinNum] = num;
							int num2 = this.iStartValue + 1;
							this.iStartValue = num2;
							KParseRepCmd mParseCmd2 = this.gLineTestProcessor.mpDevComm.mParseCmd;
							mParseCmd2.secondPinArray[mParseCmd2.selfStudyPinNum] = num2;
							this.iStartValue++;
							this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyPinNum++;
						}
						else
						{
							kLineTestProcessor.mpDevComm.mParseCmd.selfStudyProgress = 100;
						}
					}
					else
					{
						int[] iPlugPinStartArray = kLineTestProcessor.iPlugPinStartArray;
						int num3 = this.iPlugPinIndex;
						if (num3 < iPlugPinStartArray.Length)
						{
							if (this.iCurrentCount == 0)
							{
								this.iCurrentCount = iPlugPinStartArray[num3];
							}
							int num4 = this.iCurrentCount;
							if (kLineTestProcessor.iPlugPinStopArray[num3] >= num4 + 1)
							{
								KParseRepCmd mParseCmd3 = kLineTestProcessor.mpDevComm.mParseCmd;
								mParseCmd3.firstPinArray[mParseCmd3.selfStudyPinNum] = num4;
								int num5 = this.iCurrentCount + 1;
								this.iCurrentCount = num5;
								KParseRepCmd mParseCmd4 = this.gLineTestProcessor.mpDevComm.mParseCmd;
								mParseCmd4.secondPinArray[mParseCmd4.selfStudyPinNum] = num5;
								this.iCurrentCount++;
								this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyPinNum++;
								int num6 = this.iPlugPinIndex;
								if (this.gLineTestProcessor.iPlugPinStopArray[num6] < this.iCurrentCount + 1)
								{
									this.iCurrentCount = 0;
									this.iPlugPinIndex = num6 + 1;
								}
							}
						}
						else
						{
							kLineTestProcessor.mpDevComm.mParseCmd.selfStudyProgress = 100;
						}
					}
				}
				int num7 = this.iTestTime + 1;
				this.iTestTime = num7;
				KLineTestProcessor e2 = this.gLineTestProcessor;
				KParseRepCmd this2 = e2.mpDevComm.mParseCmd;
				if (this2.selfStudyProgress != 100)
				{
					int iProc = System.Convert.ToInt32((double)num7 * 100.0 / ((double)this2.selfStudyCount / 70.0));
					if (iProc >= 100)
					{
						iProc = 99;
					}
					else if (iProc == 0)
					{
						iProc = 1;
					}
					this.progressBar1.Value = iProc;
				}
				else
				{
					e2.SendStopCmd();
					this.gLineTestProcessor.mbKeepRun = false;
					this.timer1.Enabled = false;
					this.bSelfStudyFlag = false;
					int iIndex = 0;
					if (this.iStudyModel == 0)
					{
						for (int i = this.iStartValue; i <= this.iEndValue; i++)
						{
							if (i != 0)
							{
								bool bTempFlag = true;
								int j = 0;
								while (true)
								{
									this2 = this.gLineTestProcessor.mpDevComm.mParseCmd;
									if (j > this2.selfStudyPinNum)
									{
										goto IL_32A;
									}
									int num8 = this2.firstPinArray[j];
									if (num8 != 0)
									{
										int num9 = this2.secondPinArray[j];
										if (num9 != 0)
										{
											if (i == num8 || i == num9)
											{
												break;
											}
										}
									}
									j++;
								}
								goto IL_3B3;
								IL_32A:
								if (bTempFlag)
								{
									this.dataGridView2.AllowUserToAddRows = true;
									this.dataGridView2.Rows.Add(1);
									int num10 = iIndex + 1;
									this.dataGridView2.Rows[iIndex].Cells[0].Value = System.Convert.ToString(num10);
									this.dataGridView2.Rows[iIndex].Cells[1].Value = System.Convert.ToString(i);
									this.dataGridView2.AllowUserToAddRows = false;
									iIndex = num10;
								}
							}
							IL_3B3:;
						}
					}
					else
					{
						e2 = this.gLineTestProcessor;
						if (e2.iPlugPinStartArray != null && e2.iPlugPinStopArray != null)
						{
							int k = 0;
							while (true)
							{
								int[] iPlugPinStartArray2 = e2.iPlugPinStartArray;
								if (k >= iPlugPinStartArray2.Length)
								{
									break;
								}
								int num11 = iPlugPinStartArray2[k];
								if (num11 != 0 && e2.iPlugPinStopArray[k] != 0)
								{
									int l = num11;
									while (true)
									{
										e2 = this.gLineTestProcessor;
										if (l > e2.iPlugPinStopArray[k])
										{
											break;
										}
										bool bTempFlag = true;
										int m = 0;
										while (true)
										{
											this2 = e2.mpDevComm.mParseCmd;
											if (m > this2.selfStudyPinNum)
											{
												goto IL_46D;
											}
											if (l == this2.firstPinArray[m] || l == this2.secondPinArray[m])
											{
												break;
											}
											m++;
										}
										IL_4F6:
										l++;
										continue;
										goto IL_4F6;
										IL_46D:
										if (bTempFlag)
										{
											this.dataGridView2.AllowUserToAddRows = true;
											this.dataGridView2.Rows.Add(1);
											int num12 = iIndex + 1;
											this.dataGridView2.Rows[iIndex].Cells[0].Value = System.Convert.ToString(num12);
											this.dataGridView2.Rows[iIndex].Cells[1].Value = System.Convert.ToString(l);
											this.dataGridView2.AllowUserToAddRows = false;
											iIndex = num12;
											goto IL_4F6;
										}
										goto IL_4F6;
									}
								}
								k++;
							}
						}
					}
					this.progressBar1.Value = this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyProgress;
					this.btnOnOffStudy.Text = "开始学习";
				}
				int iLastIndex = this.dataGridView2.Rows.Count - 1;
				if (iLastIndex >= 0)
				{
					this.dataGridView2.Rows[iLastIndex].Selected = true;
				}
				if (this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyPinNum > 0)
				{
					int iRowCount = this.dataGridView1.Rows.Count;
					int iSSPN = this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyPinNum;
					if (iSSPN >= iRowCount)
					{
						this.dataGridView1.AllowUserToAddRows = true;
						for (int n = iRowCount; n < iSSPN; n++)
						{
							this2 = this.gLineTestProcessor.mpDevComm.mParseCmd;
							if (this2.firstPinArray[n] != 0 && this2.secondPinArray[n] != 0)
							{
								this.dataGridView1.Rows.Add(1);
								string temp1Str = System.Convert.ToString(this.gLineTestProcessor.mpDevComm.mParseCmd.firstPinArray[n]);
								string temp2Str = System.Convert.ToString(this.gLineTestProcessor.mpDevComm.mParseCmd.secondPinArray[n]);
								this.dataGridView1.Rows[n].Cells[0].Value = System.Convert.ToString(n + 1);
								this.dataGridView1.Rows[n].Cells[1].Value = temp1Str + "-" + temp2Str;
							}
						}
						this.dataGridView1.AllowUserToAddRows = false;
						int iLastIndex2 = this.dataGridView1.Rows.Count - 1;
						if (iLastIndex2 >= 0)
						{
							this.dataGridView1.Rows[iLastIndex2].Selected = true;
						}
					}
				}
			}
			catch (System.Exception arg_726_0)
			{
				this.gLineTestProcessor.mbKeepRun = false;
				this.dataGridView1.AllowUserToAddRows = false;
				this.dataGridView2.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_726_0.StackTrace);
			}
		}
		public void btnOnOffStudy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.bSelfStudyFlag)
				{
					if (DialogResult.OK == MessageBox.Show("正在进行自学习，您确定要停止吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
					{
						this.progressBar1.Value = 100;
						this.bSelfStudyFlag = false;
						this.btnOnOffStudy.Text = "开始学习";
						this.timer1.Enabled = false;
						this.gLineTestProcessor.mbKeepRun = false;
						this.gLineTestProcessor.SendStopCmd();
						for (int i = 0; i < 3; i++)
						{
							System.Threading.Thread.Sleep(100);
							this.gLineTestProcessor.SendStopCmd();
						}
						System.Threading.Thread.Sleep(300);
					}
				}
				else
				{
					this.iTestTime = 0;
					this.iPlugPinIndex = 0;
					this.iCurrentCount = 0;
					this.bSelfStudyFlag = true;
					this.btnOnOffStudy.Text = "停止学习";
					this.dataGridView1.Rows.Clear();
					this.dataGridView2.Rows.Clear();
					this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyMainPinCount = 0;
					this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyPinNum = 0;
					this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyProgress = 0;
					if (!this.bDLTestFlag)
					{
						this.progressBar1.Value = 0;
						this.timer1.Enabled = true;
					}
					if (this.iStudyModel != 0)
					{
						this.gLineTestProcessor.iSelfStudyThreshold = this.iDTLimitedValue;
						this.gLineTestProcessor.mpDevComm.mParseCmd.iSetSelfStudyDataRespCount = 0;
						this.gLineTestProcessor.mpDevComm.mParseCmd.selfStudyCount = 800;
						this.gLineTestProcessor.iPlugPinStartArray = null;
						this.gLineTestProcessor.iPlugPinStopArray = null;
						int num = this.iPlugStartPin.Length;
						if (num > 0)
						{
							this.gLineTestProcessor.iPlugPinStartArray = new int[num];
							this.gLineTestProcessor.iPlugPinStopArray = new int[this.iPlugStartPin.Length];
							int j = 0;
							while (true)
							{
								int[] array = this.iPlugStartPin;
								if (j >= array.Length)
								{
									break;
								}
								this.gLineTestProcessor.iPlugPinStartArray[j] = array[j];
								this.gLineTestProcessor.iPlugPinStopArray[j] = this.iPlugStopPin[j];
								int iTemp = System.Math.Abs(this.iPlugStopPin[j] - this.iPlugStartPin[j]) + 1;
								KParseRepCmd e2 = this.gLineTestProcessor.mpDevComm.mParseCmd;
								KParseRepCmd arg_25C_0 = e2;
								int expr_253 = iTemp;
								arg_25C_0.selfStudyCount = expr_253 * expr_253 + e2.selfStudyCount;
								j++;
							}
						}
					}
					this.gLineTestProcessor.mbKeepRun = true;
					if (this.iStudyModel == 0)
					{
						this.gLineTestProcessor.SendSelfStudyCmd(this.iStartValue, this.iEndValue, this.iDTLimitedValue);
					}
					else
					{
						this.gLineTestProcessor.StartSelfStudyPlugModelTest();
					}
				}
			}
			catch (System.Exception arg_2A8_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2A8_0.StackTrace);
			}
		}
		private void ctFormSelfStudyPinRelation_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (!this.bDLTestFlag && this.bSelfStudyFlag)
				{
					if (DialogResult.OK == MessageBox.Show("正在进行自学习，您确定要退出吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
					{
						this.progressBar1.Value = 100;
						this.bSelfStudyFlag = false;
						this.btnOnOffStudy.Text = "开始学习";
						this.timer1.Enabled = false;
						this.gLineTestProcessor.mbKeepRun = false;
						this.gLineTestProcessor.SendStopCmd();
					}
					else
					{
						e.Cancel = true;
					}
				}
			}
			catch (System.Exception arg_77_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_77_0.StackTrace);
			}
		}
		public void SelfStudyLoadCableDeal2Func()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				int iTemp = 0;
				string text = "";
				string temp1Str = text;
				string temp2Str = text;
				string tempPIDStr = text;
				string plugNameStr = text;
				System.Collections.Generic.List<int> csyPinNumList = new System.Collections.Generic.List<int>();
				System.Collections.Generic.List<int> csyMeasMethodList = new System.Collections.Generic.List<int>();
				System.Collections.Generic.List<int> measMethodList = new System.Collections.Generic.List<int>();
				System.Collections.Generic.List<string> pinNumList = new System.Collections.Generic.List<string>();
				System.Collections.Generic.List<string> pinNameList = new System.Collections.Generic.List<string>();
				System.Collections.Generic.List<string> tIPinNumList = new System.Collections.Generic.List<string>();
				System.Collections.Generic.List<string> aTPinNumList = new System.Collections.Generic.List<string>();
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					try
					{
						if (this.gLineTestProcessor.bUseRelayBoard)
						{
							string sqlcommand = "select * from TIAndRTPinReletionData order by ID";
							OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							while (dataReader.Read())
							{
								temp1Str = dataReader["TI_PinNum"].ToString();
								temp2Str = dataReader["AT_PinNum"].ToString();
								if (!string.IsNullOrEmpty(temp1Str) && !string.IsNullOrEmpty(temp2Str))
								{
									tIPinNumList.Add(temp1Str);
									aTPinNumList.Add(temp2Str);
								}
							}
							dataReader.Close();
							dataReader = null;
						}
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
					int i = 0;
					while (true)
					{
						string[] array = this.studyPlugStrArray;
						if (i >= array.Length)
						{
							break;
						}
						plugNameStr = array[i];
						if (!string.IsNullOrEmpty(plugNameStr))
						{
							tempPIDStr = "";
							try
							{
								string sqlcommand = "select top 1 * from TPlugLibrary where PlugNo='" + plugNameStr + "'";
								OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
								dataReader = cmd.ExecuteReader();
								if (dataReader.Read())
								{
									tempPIDStr = dataReader["PID"].ToString();
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
							if (!string.IsNullOrEmpty(tempPIDStr))
							{
								csyPinNumList.Clear();
								csyMeasMethodList.Clear();
								measMethodList.Clear();
								pinNumList.Clear();
								pinNameList.Clear();
								try
								{
									string sqlcommand = "select * from TPlugLibraryDetail where PID='" + tempPIDStr + "' order by PDID";
									OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
									dataReader = cmd.ExecuteReader();
									while (dataReader.Read())
									{
										try
										{
											temp1Str = dataReader["PinName"].ToString();
											temp2Str = dataReader["DevicePinNum"].ToString();
											iTemp = System.Convert.ToInt32(dataReader["MeasuringMethod"].ToString());
										}
										catch (System.Exception ex_289)
										{
											continue;
										}
										pinNameList.Add(temp1Str);
										pinNumList.Add(temp2Str);
										measMethodList.Add(iTemp);
									}
									dataReader.Close();
									dataReader = null;
								}
								catch (System.Exception ex3)
								{
									KLineTestProcessor.ExceptionRecordFunc(ex3.StackTrace);
									if (dataReader != null)
									{
										dataReader.Close();
										dataReader = null;
									}
								}
								if (this.gLineTestProcessor.bUseRelayBoard)
								{
									for (int j = 0; j < pinNumList.Count; j++)
									{
										char[] separator = new char[]
										{
											','
										};
										string[] devPinStrArray = pinNumList[j].Split(separator);
										for (int k = 0; k < aTPinNumList.Count; k++)
										{
											if (devPinStrArray[0] == aTPinNumList[k])
											{
												csyPinNumList.Add(System.Convert.ToInt32(tIPinNumList[k]));
												csyMeasMethodList.Add(measMethodList[j]);
											}
										}
									}
									for (int jj = 0; jj < this.gLineTestProcessor.gDLPinConnectInfoSelf2Array.Count; jj++)
									{
										for (int l = 0; l < csyPinNumList.Count; l++)
										{
											if (csyMeasMethodList[l] == 0)
											{
												if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].mnMainPinNum == csyPinNumList[l])
												{
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].mnALJQPinNum = pinNameList[l];
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].mALJQName = plugNameStr;
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].iAMeasMethod = csyMeasMethodList[l];
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].mnAPinIsGround = 0;
												}
												if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].mnSecPinNum == csyPinNumList[l])
												{
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].mnBLJQPinNum = pinNameList[l];
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].mBLJQName = plugNameStr;
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].iBMeasMethod = csyMeasMethodList[l];
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].mnBPinIsGround = 0;
												}
											}
											else
											{
												if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].mnMainPinNum == csyPinNumList[l] || (int)this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].mnMainPinNum == csyPinNumList[l] + 1)
												{
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].mnALJQPinNum = pinNameList[l];
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].mALJQName = plugNameStr;
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].iAMeasMethod = csyMeasMethodList[l];
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].mnAPinIsGround = 0;
												}
												if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].mnSecPinNum == csyPinNumList[l] || (int)this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].mnSecPinNum == csyPinNumList[l] + 1)
												{
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].mnBLJQPinNum = pinNameList[l];
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].mBLJQName = plugNameStr;
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].iBMeasMethod = csyMeasMethodList[l];
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj].mnBPinIsGround = 0;
												}
											}
										}
									}
								}
								else
								{
									for (int jj2 = 0; jj2 < this.gLineTestProcessor.gDLPinConnectInfoSelf2Array.Count; jj2++)
									{
										for (int m = 0; m < pinNumList.Count; m++)
										{
											char[] separator2 = new char[]
											{
												','
											};
											string[] devPinStrArray = pinNumList[m].Split(separator2);
											iTemp = System.Convert.ToInt32(devPinStrArray[0]);
											if (measMethodList[m] == 0)
											{
												if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].mnMainPinNum == iTemp)
												{
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].mnALJQPinNum = pinNameList[m];
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].mALJQName = plugNameStr;
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].iAMeasMethod = measMethodList[m];
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].mnAPinIsGround = 0;
												}
												if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].mnSecPinNum == iTemp)
												{
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].mnBLJQPinNum = pinNameList[m];
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].mBLJQName = plugNameStr;
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].iBMeasMethod = measMethodList[m];
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].mnBPinIsGround = 0;
												}
											}
											else
											{
												if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].mnMainPinNum == iTemp || (int)this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].mnMainPinNum == iTemp + 1)
												{
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].mnALJQPinNum = pinNameList[m];
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].mALJQName = plugNameStr;
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].iAMeasMethod = measMethodList[m];
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].mnAPinIsGround = 0;
												}
												if ((int)this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].mnSecPinNum == iTemp || (int)this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].mnSecPinNum == iTemp + 1)
												{
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].mnBLJQPinNum = pinNameList[m];
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].mBLJQName = plugNameStr;
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].iBMeasMethod = measMethodList[m];
													this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[jj2].mnBPinIsGround = 0;
												}
											}
										}
									}
								}
							}
						}
						i++;
					}
					connection.Close();
					connection = null;
					for (int aa = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array.Count - 1; aa >= 0; aa--)
					{
						temp1Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[aa].mnALJQPinNum;
						temp2Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[aa].mALJQName;
						string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[aa].mnBLJQPinNum;
						string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[aa].mBLJQName;
						if (!(temp1Str == ctFormSelfStudyPinRelation.PLUGPIN_UNDEFINED_STR) && !(temp2Str == ctFormSelfStudyPinRelation.PLUGPIN_UNDEFINED_STR) && !(temp3Str == ctFormSelfStudyPinRelation.PLUGPIN_UNDEFINED_STR) && !(temp4Str == ctFormSelfStudyPinRelation.PLUGPIN_UNDEFINED_STR))
						{
							if (temp1Str == temp3Str && temp2Str == temp4Str)
							{
								this.gLineTestProcessor.gDLPinConnectInfoSelf2Array.Remove(this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[aa]);
							}
						}
					}
					for (int nn = 0; nn < this.gLineTestProcessor.gDLPinConnectInfoSelf2Array.Count; nn++)
					{
						temp1Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[nn].mnALJQPinNum;
						temp2Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[nn].mALJQName;
						string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[nn].mnBLJQPinNum;
						string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[nn].mBLJQName;
						if (!(temp1Str == ctFormSelfStudyPinRelation.PLUGPIN_UNDEFINED_STR) && !(temp2Str == ctFormSelfStudyPinRelation.PLUGPIN_UNDEFINED_STR) && !(temp3Str == ctFormSelfStudyPinRelation.PLUGPIN_UNDEFINED_STR) && !(temp4Str == ctFormSelfStudyPinRelation.PLUGPIN_UNDEFINED_STR))
						{
							for (int mm = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array.Count - 1; mm > nn; mm--)
							{
								string temp5Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[mm].mnALJQPinNum;
								string temp6Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[mm].mALJQName;
								string temp7Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[mm].mnBLJQPinNum;
								string temp8Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[mm].mBLJQName;
								if ((temp1Str == temp5Str && temp2Str == temp6Str && temp3Str == temp7Str && temp4Str == temp8Str) || (temp1Str == temp7Str && temp2Str == temp8Str && temp3Str == temp5Str && temp4Str == temp6Str))
								{
									this.gLineTestProcessor.gDLPinConnectInfoSelf2Array.Remove(this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[mm]);
								}
							}
						}
					}
					if (this.gLineTestProcessor.gDLPinConnectInfoSelf2Array.Count > 0)
					{
						for (int ik = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array.Count - 1; ik >= 0; ik--)
						{
							if (this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[ik].mALJQName == ctFormSelfStudyPinRelation.PLUGPIN_UNDEFINED_STR || this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[ik].mnALJQPinNum == ctFormSelfStudyPinRelation.PLUGPIN_UNDEFINED_STR || this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[ik].mBLJQName == ctFormSelfStudyPinRelation.PLUGPIN_UNDEFINED_STR || this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[ik].mnBLJQPinNum == ctFormSelfStudyPinRelation.PLUGPIN_UNDEFINED_STR)
							{
								this.gLineTestProcessor.gDLPinConnectInfoSelf2Array.Remove(this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[ik]);
							}
						}
						for (int n = 0; n < this.gLineTestProcessor.gDLPinConnectInfoSelf2Array.Count; n++)
						{
							this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].mnAPinIsGround = 0;
							this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].mnBPinIsGround = 0;
							this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].iDLTestFlag = 0;
							this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].iDTTestFlag = 0;
							this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].iJYTestFlag = 0;
							this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].iDDJYTestFlag = 0;
							this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].iNYTestFlag = 0;
							KLineTestProcessor kLineTestProcessor = this.gLineTestProcessor;
							if (kLineTestProcessor.bDLTestEnabled)
							{
								kLineTestProcessor.gDLPinConnectInfoSelf2Array[n].iDLTestFlag = 1;
							}
							KLineTestProcessor kLineTestProcessor2 = this.gLineTestProcessor;
							if (kLineTestProcessor2.bDTTestEnabled)
							{
								kLineTestProcessor2.gDLPinConnectInfoSelf2Array[n].iDTTestFlag = 1;
							}
							KLineTestProcessor kLineTestProcessor3 = this.gLineTestProcessor;
							if (kLineTestProcessor3.bJYTestEnabled)
							{
								kLineTestProcessor3.gDLPinConnectInfoSelf2Array[n].iJYTestFlag = 1;
							}
							KLineTestProcessor kLineTestProcessor4 = this.gLineTestProcessor;
							if (kLineTestProcessor4.bDDJYTestEnabled)
							{
								kLineTestProcessor4.gDLPinConnectInfoSelf2Array[n].iDDJYTestFlag = 1;
							}
							KLineTestProcessor kLineTestProcessor5 = this.gLineTestProcessor;
							if (kLineTestProcessor5.bNYTestEnabled)
							{
								kLineTestProcessor5.gDLPinConnectInfoSelf2Array[n].iNYTestFlag = 1;
							}
							if (this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].iDTTestFlag != 1)
							{
								this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].strDTTestValue = ctFormSelfStudyPinRelation.UN_TEST_COMM_STR;
								this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].strDTTestResult = ctFormSelfStudyPinRelation.UN_TEST_COMM_STR;
							}
							else
							{
								string strDTTestValue = "";
								this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].strDTTestValue = strDTTestValue;
								string strDTTestResult = "";
								this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].strDTTestResult = strDTTestResult;
							}
							if (this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].iJYTestFlag != 1)
							{
								this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].strJYTestValue = ctFormSelfStudyPinRelation.UN_TEST_COMM_STR;
								this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].strJYTestResult = ctFormSelfStudyPinRelation.UN_TEST_COMM_STR;
							}
							else
							{
								string strJYTestValue = "";
								this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].strJYTestValue = strJYTestValue;
								string strJYTestResult = "";
								this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].strJYTestResult = strJYTestResult;
							}
							if (this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].iNYTestFlag != 1)
							{
								this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].strNYTestValue = ctFormSelfStudyPinRelation.UN_TEST_COMM_STR;
								this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].strNYTestResult = ctFormSelfStudyPinRelation.UN_TEST_COMM_STR;
							}
							else
							{
								string strNYTestValue = "";
								this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].strNYTestValue = strNYTestValue;
								string strNYTestResult = "";
								this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[n].strNYTestResult = strNYTestResult;
							}
						}
					}
				}
				catch (System.Exception ex4)
				{
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
				csyPinNumList.Clear();
				measMethodList.Clear();
				pinNumList.Clear();
				pinNameList.Clear();
				tIPinNumList.Clear();
				aTPinNumList.Clear();
			}
			catch (System.Exception ex5)
			{
				KLineTestProcessor.ExceptionRecordFunc(ex5.StackTrace);
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
		private void btnTHXSGX_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.bDLTestFlag)
				{
					if (this.bSelfStudyFlag)
					{
						MessageBox.Show("正在进行自学习!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						this.gLineTestProcessor.ExportSELFTest2();
						this.SelfStudyLoadCableDeal2Func();
						ctFormSelfStudyPinRelationView this2 = new ctFormSelfStudyPinRelationView(this.gLineTestProcessor);
						this.selfStudyPinRelationViewForm = this2;
						this2.Activate();
						this.selfStudyPinRelationViewForm.ShowDialog();
						this.selfStudyPinRelationViewForm = null;
						this.FreeSystemMemoryResourcesFunc();
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
					this.~ctFormSelfStudyPinRelation();
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
