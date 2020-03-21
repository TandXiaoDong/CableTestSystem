using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormConverterInfoView : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public string loginUser;
		public string proNameStr;
		public string xsNameStr;
		public int iEditPid;
		private Button btnQuit;
		private Button btnExport;
		private GroupBox groupBox2;
		private DataGridView dataGridView1;
		private DataGridViewTextBoxColumn Column_xh;
		private DataGridViewTextBoxColumn Column_startInterface;
		private DataGridViewTextBoxColumn Column_stopPin;
		private DataGridViewTextBoxColumn Column_stopInterface;
		private DataGridViewTextBoxColumn Column_startPin;
		public System.Collections.Generic.List<string> temp01List;
		public System.Collections.Generic.List<string> temp04List;
		public System.Collections.Generic.List<string> temp03List;
		public System.Collections.Generic.List<string> temp02List;
		private FolderBrowserDialog folderBrowserDialog1;
		private Container components;
		public ctFormConverterInfoView(KLineTestProcessor gltProcessor, int iPid, string pnStr, string xsStr)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
					this.iEditPid = iPid;
					this.proNameStr = pnStr;
					this.xsNameStr = xsStr;
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
		private void ~ctFormConverterInfoView()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormConverterInfoView));
			this.btnQuit = new Button();
			this.btnExport = new Button();
			this.groupBox2 = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.folderBrowserDialog1 = new FolderBrowserDialog();
			this.Column_xh = new DataGridViewTextBoxColumn();
			this.Column_startInterface = new DataGridViewTextBoxColumn();
			this.Column_stopPin = new DataGridViewTextBoxColumn();
			this.Column_stopInterface = new DataGridViewTextBoxColumn();
			this.Column_startPin = new DataGridViewTextBoxColumn();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(452, 517);
			this.btnQuit.Location = location;
			Padding margin = new Padding(2);
			this.btnQuit.Margin = margin;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size = new System.Drawing.Size(100, 24);
			this.btnQuit.Size = size;
			this.btnQuit.TabIndex = 0;
			this.btnQuit.Text = "关闭";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btnExport.Anchor = AnchorStyles.Bottom;
			this.btnExport.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(243, 517);
			this.btnExport.Location = location2;
			Padding margin2 = new Padding(2);
			this.btnExport.Margin = margin2;
			this.btnExport.Name = "btnExport";
			System.Drawing.Size size2 = new System.Drawing.Size(100, 24);
			this.btnExport.Size = size2;
			this.btnExport.TabIndex = 1;
			this.btnExport.Text = "导出";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			this.groupBox2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox2.Controls.Add(this.dataGridView1);
			this.groupBox2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(11, 16);
			this.groupBox2.Location = location3;
			Padding margin3 = new Padding(2);
			this.groupBox2.Margin = margin3;
			this.groupBox2.Name = "groupBox2";
			Padding padding = new Padding(2);
			this.groupBox2.Padding = padding;
			System.Drawing.Size size3 = new System.Drawing.Size(772, 480);
			this.groupBox2.Size = size3;
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "转接工装清单";
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
				this.Column_stopPin,
				this.Column_stopInterface,
				this.Column_startPin
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
			System.Drawing.Size size4 = new System.Drawing.Size(768, 459);
			this.dataGridView1.Size = size4;
			this.dataGridView1.TabIndex = 1;
			this.Column_xh.HeaderText = "序号";
			this.Column_xh.Name = "Column_xh";
			this.Column_xh.ReadOnly = true;
			this.Column_xh.Width = 74;
			this.Column_startInterface.HeaderText = "转接工装代号";
			this.Column_startInterface.Name = "Column_startInterface";
			this.Column_startInterface.ReadOnly = true;
			this.Column_startInterface.Width = 135;
			this.Column_stopPin.HeaderText = "转接型号";
			this.Column_stopPin.Name = "Column_stopPin";
			this.Column_stopPin.ReadOnly = true;
			this.Column_stopPin.Width = 150;
			this.Column_stopInterface.HeaderText = "线束接口";
			this.Column_stopInterface.Name = "Column_stopInterface";
			this.Column_stopInterface.ReadOnly = true;
			this.Column_stopInterface.Width = 110;
			this.Column_startPin.HeaderText = "测试仪针脚范围";
			this.Column_startPin.Name = "Column_startPin";
			this.Column_startPin.ReadOnly = true;
			this.Column_startPin.Width = 140;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.btnExport);
			base.Controls.Add(this.btnQuit);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin5 = new Padding(2);
			base.Margin = margin5;
			base.Name = "ctFormConverterInfoView";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "查看工装";
			base.Load += new System.EventHandler(this.ctFormConverterInfoView_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormConverterInfoView_SizeChanged);
			this.groupBox2.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			base.ResumeLayout(false);
		}
		public void RefreshDataGridView34()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.temp01List.Clear();
				this.temp03List.Clear();
				this.temp04List.Clear();
				this.temp02List.Clear();
				this.dataGridView1.Rows.Clear();
				string text = "";
				string tempStr = text;
				string tempPIDStr = text;
				int inum = 0;
				System.Collections.Generic.List<string> strDPNArray = new System.Collections.Generic.List<string>();
				System.Collections.Generic.List<int> iAPNArray = new System.Collections.Generic.List<int>();
				string dbpath = Application.StartupPath + "\\ctsdb.mdb";
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "select * from TLineStructLibrary where LID=" + this.iEditPid;
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						tempStr = dataReader["PlugInfo"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					if (!string.IsNullOrEmpty(tempStr))
					{
						string[] plugStringArray = tempStr.Split(new char[]
						{
							','
						});
						for (int i = 0; i < plugStringArray.Length; i++)
						{
							if (!string.IsNullOrEmpty(plugStringArray[i]))
							{
								bool bExistFlag = false;
								sqlcommand = "select * from TPlugLibrary where PlugNo= '" + plugStringArray[i] + "'";
								cmd = new OleDbCommand(sqlcommand, connection);
								dataReader = cmd.ExecuteReader();
								if (dataReader.Read())
								{
									tempPIDStr = dataReader["PID"].ToString();
									bExistFlag = true;
								}
								dataReader.Close();
								dataReader = null;
								if (bExistFlag)
								{
									strDPNArray.Clear();
									iAPNArray.Clear();
									sqlcommand = "select * from TPlugLibraryDetail where PID= '" + tempPIDStr + "'";
									cmd = new OleDbCommand(sqlcommand, connection);
									dataReader = cmd.ExecuteReader();
									while (dataReader.Read())
									{
										strDPNArray.Add(dataReader["DevicePinNum"].ToString());
									}
									dataReader.Close();
									dataReader = null;
									for (int j = 0; j < strDPNArray.Count; j++)
									{
										sqlcommand = "select * from TIAndRTPinReletionData where AT_PinNum = '" + strDPNArray[j] + "'";
										cmd = new OleDbCommand(sqlcommand, connection);
										dataReader = cmd.ExecuteReader();
										if (dataReader.Read())
										{
											iAPNArray.Add(System.Convert.ToInt32(dataReader["TI_PinNum"].ToString()));
										}
										dataReader.Close();
										dataReader = null;
									}
									if (iAPNArray.Count > 0)
									{
										int iMaxValue = iAPNArray[0];
										int iMinValue = iAPNArray[0];
										for (int k = 0; k < iAPNArray.Count; k++)
										{
											if (iAPNArray[k] > iMaxValue)
											{
												iMaxValue = iAPNArray[k];
											}
											if (iAPNArray[k] < iMinValue)
											{
												iMinValue = iAPNArray[k];
											}
										}
										string tempStartStr = System.Convert.ToString(iMinValue);
										string tempEndStr = System.Convert.ToString(iMaxValue);
										this.temp03List.Add(plugStringArray[i]);
										string tempPinStr = tempStartStr + "~" + tempEndStr;
										this.temp04List.Add(tempPinStr);
									}
								}
							}
						}
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_326_0)
				{
					this.dataGridView1.AllowUserToAddRows = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_326_0.StackTrace);
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
				if (this.temp03List != null)
				{
					for (int l = 0; l < this.temp03List.Count; l++)
					{
						this.dataGridView1.AllowUserToAddRows = true;
						this.dataGridView1.Rows.Add(1);
						int num = inum + 1;
						this.dataGridView1.Rows[inum].Cells[0].Value = System.Convert.ToString(num);
						this.dataGridView1.Rows[inum].Cells[1].Value = "";
						this.dataGridView1.Rows[inum].Cells[2].Value = "";
						this.dataGridView1.Rows[inum].Cells[3].Value = this.temp03List[l];
						this.dataGridView1.Rows[inum].Cells[4].Value = this.temp04List[l];
						this.dataGridView1.AllowUserToAddRows = false;
						inum = num;
					}
				}
			}
			catch (System.Exception arg_48A_0)
			{
				this.dataGridView1.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_48A_0.StackTrace);
			}
		}
		public void RefreshDataGridView12()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				if (this.dataGridView1.Rows.Count > 0)
				{
					string text = "";
					string tempCNStr = text;
					string tempCCTStr = text;
					string tempStr = text;
					bool bFindFlag = false;
					bool bMultiZJGZFlag = false;
					string dbpath = Application.StartupPath + "\\ctsdb.mdb";
					try
					{
						connection = new OleDbConnection();
						connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
						connection.Open();
						for (int i = 0; i < this.temp03List.Count; i++)
						{
							text = "";
							tempCNStr = text;
							tempCCTStr = text;
							string connNameStr = text;
							bFindFlag = false;
							bMultiZJGZFlag = false;
							try
							{
								string sqlcommand = "select * from TPlugLibrary where PlugNo='" + this.temp03List[i] + "'";
								OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
								dataReader = cmd.ExecuteReader();
								if (dataReader.Read())
								{
									connNameStr = dataReader["ConnectorName"].ToString();
								}
								dataReader.Close();
								dataReader = null;
								sqlcommand = "select * from TConnectorLibrary where ConnectorName='" + connNameStr + "'";
								cmd = new OleDbCommand(sqlcommand, connection);
								dataReader = cmd.ExecuteReader();
								if (dataReader.Read())
								{
									tempCCTStr = dataReader["ConverterType"].ToString();
								}
								dataReader.Close();
								dataReader = null;
								sqlcommand = "select * from TConverterLibrary where ConverterType='" + tempCCTStr + "'";
								cmd = new OleDbCommand(sqlcommand, connection);
								dataReader = cmd.ExecuteReader();
								while (dataReader.Read())
								{
									try
									{
										tempStr = "";
										if (!bFindFlag)
										{
											bFindFlag = true;
											tempCNStr = dataReader["ConverterName"].ToString();
											continue;
										}
										tempStr = dataReader["ConverterName"].ToString();
									}
									catch (System.Exception ex_19D)
									{
										break;
									}
									if (!bMultiZJGZFlag)
									{
										bMultiZJGZFlag = true;
										tempCNStr += "(或" + tempStr;
									}
									else
									{
										tempCNStr += "、" + tempStr;
									}
								}
								dataReader.Close();
								dataReader = null;
								if (bMultiZJGZFlag)
								{
									tempCNStr += ")";
								}
							}
							catch (System.Exception arg_1EF_0)
							{
								KLineTestProcessor.ExceptionRecordFunc(arg_1EF_0.StackTrace);
								if (dataReader != null)
								{
									dataReader.Close();
									dataReader = null;
								}
							}
							if (bFindFlag)
							{
								this.temp01List.Add(tempCNStr);
								this.temp02List.Add(tempCCTStr);
							}
							else
							{
								this.temp01List.Add("");
								this.temp02List.Add("");
							}
						}
						connection.Close();
						connection = null;
					}
					catch (System.Exception arg_25A_0)
					{
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
					for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
					{
						System.Collections.Generic.List<string> list = this.temp01List;
						if (list != null && list.Count > j)
						{
							this.dataGridView1.Rows[j].Cells[1].Value = this.temp01List[j];
						}
						System.Collections.Generic.List<string> list2 = this.temp02List;
						if (list2 != null && list2.Count > j)
						{
							this.dataGridView1.Rows[j].Cells[2].Value = this.temp02List[j];
						}
					}
				}
			}
			catch (System.Exception arg_331_0)
			{
				this.dataGridView1.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_331_0.StackTrace);
			}
		}
		private void ctFormConverterInfoView_Load(object sender, System.EventArgs e)
		{
			try
			{
				if (this.gLineTestProcessor.bUseRelayBoard)
				{
					this.Column_startPin.HeaderText = "转接台针脚范围";
				}
				this.temp01List = new System.Collections.Generic.List<string>();
				this.temp04List = new System.Collections.Generic.List<string>();
				this.temp03List = new System.Collections.Generic.List<string>();
				this.temp02List = new System.Collections.Generic.List<string>();
				for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
				{
					this.dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					this.dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
				{
					this.dataGridView1.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				this.RefreshDataGridView34();
				this.RefreshDataGridView12();
				for (int k = 0; k < this.dataGridView1.Rows.Count; k++)
				{
					this.dataGridView1.Rows[k].Selected = false;
				}
			}
			catch (System.Exception arg_115_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_115_0.StackTrace);
			}
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode == 0)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
			catch (System.Exception arg_138_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_138_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
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
						ia = iw / 2;
						iy = iw % 2;
					}
					this.dataGridView1.Columns[0].Width = iy + 76;
					this.dataGridView1.Columns[1].Width = ia + 190;
					this.dataGridView1.Columns[2].Width = ia + 180;
					this.dataGridView1.Columns[3].Width = 150;
					this.dataGridView1.Columns[4].Width = 150;
				}
			}
			catch (System.Exception arg_BA_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_BA_0.StackTrace);
			}
		}
		private void ctFormConverterInfoView_SizeChanged(object sender, System.EventArgs e)
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
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool SaveToExcelFileFunc(string xlsxFile)
		{
			bool bSuccFlag = true;
			try
			{
				if (string.IsNullOrEmpty(xlsxFile))
				{
					return false;
				}
				Workbook wb = new Workbook();
				Cells cells = wb.Worksheets[0].Cells;
				Style st = wb.Styles[wb.Styles.Add()];
				st.HorizontalAlignment = TextAlignmentType.Center;
				st.VerticalAlignment = TextAlignmentType.Center;
				st.Font.Name = "宋体";
				st.Font.Size = 11;
				int iRow = 0;
				int iCol = 0;
				for (int i = 0; i < 5; i++)
				{
					cells.SetColumnWidth(i, 20.0);
				}
				cells.Merge(0, 0, 1, 5);
				this.putValue(cells, "转接工装清单", iRow, iCol, st);
				iRow++;
				iRow++;
				this.putValue(cells, "项目名称:", iRow, iCol, st);
				int column = iCol + 1;
				this.putValue(cells, this.proNameStr, iRow, column, st);
				int column2 = iCol + 2;
				this.putValue(cells, "线束代号:", iRow, column2, st);
				int column3 = iCol + 3;
				this.putValue(cells, this.xsNameStr, iRow, column3, st);
				iRow++;
				iRow++;
				this.putValue(cells, this.Column_xh.HeaderText.ToString(), iRow, iCol, st);
				this.putValue(cells, this.Column_startInterface.HeaderText.ToString(), iRow, column, st);
				this.putValue(cells, this.Column_stopPin.HeaderText.ToString(), iRow, column2, st);
				this.putValue(cells, this.Column_stopInterface.HeaderText.ToString(), iRow, column3, st);
				int column4 = iCol + 4;
				this.putValue(cells, this.Column_startPin.HeaderText.ToString(), iRow, column4, st);
				iRow++;
				try
				{
					int num;
					for (int j = 0; j < this.dataGridView1.Rows.Count; j = num)
					{
						num = j + 1;
						string temp0Str = System.Convert.ToString(num);
						string temp1Str = this.dataGridView1.Rows[j].Cells[1].Value.ToString();
						string temp2Str = this.dataGridView1.Rows[j].Cells[2].Value.ToString();
						string temp3Str = this.dataGridView1.Rows[j].Cells[3].Value.ToString();
						string temp4Str = this.dataGridView1.Rows[j].Cells[4].Value.ToString();
						this.putValue(cells, temp0Str, iRow, iCol, st);
						this.putValue(cells, temp1Str, iRow, column, st);
						this.putValue(cells, temp2Str, iRow, column2, st);
						this.putValue(cells, temp3Str, iRow, column3, st);
						this.putValue(cells, temp4Str, iRow, column4, st);
						iRow++;
					}
				}
				catch (System.Exception arg_2D5_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_2D5_0.StackTrace);
				}
				wb.Save(xlsxFile, SaveFormat.Xlsx);
				wb = null;
			}
			catch (System.Exception arg_2EF_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2EF_0.StackTrace);
				bSuccFlag = false;
			}
			return bSuccFlag;
		}
		public void putValue(Cells cell, object tempValue, int row, int column, Style st)
		{
			try
			{
				cell[row, column].PutValue(tempValue);
				cell[row, column].SetStyle(st);
			}
			catch (System.Exception arg_21_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_21_0.StackTrace);
			}
		}
		private void btnExport_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dataGridView1.Rows.Count <= 0)
				{
					MessageBox.Show("转接工装清单为空!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					string orfn = Application.StartupPath;
					FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
					this.folderBrowserDialog1 = folderBrowserDialog;
					folderBrowserDialog.Description = "目录选择";
					if (DialogResult.OK == this.folderBrowserDialog1.ShowDialog())
					{
						orfn = this.folderBrowserDialog1.SelectedPath;
						System.ValueType dt = System.DateTime.Now;
						string tt = System.Convert.ToString(((System.DateTime)dt).Year);
						tt += System.Convert.ToString(((System.DateTime)dt).Month);
						tt += System.Convert.ToString(((System.DateTime)dt).Day);
						string ttms = System.Convert.ToString(((System.DateTime)dt).Hour);
						ttms += System.Convert.ToString(((System.DateTime)dt).Minute);
						ttms += System.Convert.ToString(((System.DateTime)dt).Second);
						string xlsxFn = orfn + "\\转接工装清单_" + tt + "_" + ttms + ".xlsx";
						if (this.SaveToExcelFileFunc(xlsxFn))
						{
							MessageBox.Show("导出成功!", "提示", MessageBoxButtons.OK);
						}
						else
						{
							MessageBox.Show("导出失败!", "提示", MessageBoxButtons.OK);
						}
					}
				}
			}
			catch (System.Exception arg_14F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_14F_0.StackTrace);
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
					this.~ctFormConverterInfoView();
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
