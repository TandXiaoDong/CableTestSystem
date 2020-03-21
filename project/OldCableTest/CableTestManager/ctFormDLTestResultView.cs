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
	public class ctFormDLTestResultView : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public string loginUser;
		public string dbpath;
		public string mddbpath;
		public int iEditPid;
		public bool bDLHistoryInfoView;
		private Button btnQuit;
		private Button btnExportPinRelation;
		private FolderBrowserDialog folderBrowserDialog1;
		private GroupBox groupBox2;
		private DataGridView dataGridView1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private Container components;
		public ctFormDLTestResultView(KLineTestProcessor gltProcessor, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool bHistoryView, int iPid)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.mddbpath = Application.StartupPath + "\\ctsmddb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
					this.bDLHistoryInfoView = bHistoryView;
					this.iEditPid = iPid;
				}
				catch (System.Exception ex_59)
				{
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormDLTestResultView()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormDLTestResultView));
			this.groupBox2 = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
			this.btnQuit = new Button();
			this.btnExportPinRelation = new Button();
			this.folderBrowserDialog1 = new FolderBrowserDialog();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
			this.groupBox2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox2.Controls.Add(this.dataGridView1);
			this.groupBox2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(8, 16);
			this.groupBox2.Location = location;
			Padding margin = new Padding(2, 2, 2, 2);
			this.groupBox2.Margin = margin;
			this.groupBox2.Name = "groupBox2";
			Padding padding = new Padding(2, 2, 2, 2);
			this.groupBox2.Padding = padding;
			System.Drawing.Size size = new System.Drawing.Size(778, 495);
			this.groupBox2.Size = size;
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "短路连接关系表";
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			System.Drawing.Color window = System.Drawing.SystemColors.Window;
			this.dataGridView1.BackgroundColor = window;
			this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[]
			{
				this.dataGridViewTextBoxColumn1,
				this.dataGridViewTextBoxColumn2,
				this.dataGridViewTextBoxColumn3,
				this.dataGridViewTextBoxColumn4,
				this.dataGridViewTextBoxColumn5
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
			System.Drawing.Size size2 = new System.Drawing.Size(774, 474);
			this.dataGridView1.Size = size2;
			this.dataGridView1.TabIndex = 16;
			this.dataGridViewTextBoxColumn1.HeaderText = "序号";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 80;
			this.dataGridViewTextBoxColumn2.HeaderText = "起点接口";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 180;
			this.dataGridViewTextBoxColumn3.HeaderText = "起点接点";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.Width = 150;
			this.dataGridViewTextBoxColumn4.HeaderText = "终点接口";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Width = 180;
			this.dataGridViewTextBoxColumn5.HeaderText = "终点接点";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.Width = 150;
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(489, 529);
			this.btnQuit.Location = location3;
			Padding margin3 = new Padding(2, 2, 2, 2);
			this.btnQuit.Margin = margin3;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size3 = new System.Drawing.Size(90, 24);
			this.btnQuit.Size = size3;
			this.btnQuit.TabIndex = 0;
			this.btnQuit.Text = "关闭";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btnExportPinRelation.Anchor = AnchorStyles.Bottom;
			this.btnExportPinRelation.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(216, 529);
			this.btnExportPinRelation.Location = location4;
			Padding margin4 = new Padding(2, 2, 2, 2);
			this.btnExportPinRelation.Margin = margin4;
			this.btnExportPinRelation.Name = "btnExportPinRelation";
			System.Drawing.Size size4 = new System.Drawing.Size(90, 24);
			this.btnExportPinRelation.Size = size4;
			this.btnExportPinRelation.TabIndex = 1;
			this.btnExportPinRelation.Text = "导出";
			this.btnExportPinRelation.UseVisualStyleBackColor = true;
			this.btnExportPinRelation.Click += new System.EventHandler(this.btnExportPinRelation_Click);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnExportPinRelation);
			base.Controls.Add(this.groupBox2);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin5 = new Padding(2, 2, 2, 2);
			base.Margin = margin5;
			base.Name = "ctFormDLTestResultView";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "短路测试数据";
			base.Load += new System.EventHandler(this.ctFormDLTestResultView_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormDLTestResultView_SizeChanged);
			this.groupBox2.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			base.ResumeLayout(false);
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
				int iCol = 1;
				for (int i = 1; i < 5; i++)
				{
					cells.SetColumnWidth(i, 24.0);
				}
				cells.Merge(0, 1, 1, 4);
				cells.Merge(1, 2, 1, 3);
				this.putValue(cells, "短路连接关系", iRow, iCol, st);
				iRow++;
				this.putValue(cells, "备注", iRow, iCol, st);
				int column = iCol + 1;
				this.putValue(cells, "", iRow, column, st);
				iRow++;
				this.putValue(cells, "起点接口", iRow, iCol, st);
				this.putValue(cells, "起点接点", iRow, column, st);
				int column2 = iCol + 2;
				this.putValue(cells, "终点接口", iRow, column2, st);
				int column3 = iCol + 3;
				this.putValue(cells, "终点接点", iRow, column3, st);
				iRow++;
				try
				{
					for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
					{
						string temp1Str = this.dataGridView1.Rows[j].Cells[1].Value.ToString();
						string temp2Str = this.dataGridView1.Rows[j].Cells[2].Value.ToString();
						string temp3Str = this.dataGridView1.Rows[j].Cells[3].Value.ToString();
						string temp4Str = this.dataGridView1.Rows[j].Cells[4].Value.ToString();
						this.putValue(cells, temp1Str, iRow, iCol, st);
						this.putValue(cells, temp2Str, iRow, column, st);
						this.putValue(cells, temp3Str, iRow, column2, st);
						this.putValue(cells, temp4Str, iRow, column3, st);
						iRow++;
					}
				}
				catch (System.Exception arg_24B_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_24B_0.StackTrace);
				}
				wb.Save(xlsxFile, SaveFormat.Xlsx);
				wb = null;
			}
			catch (System.Exception arg_265_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_265_0.StackTrace);
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
		private void btnExportPinRelation_Click(object sender, System.EventArgs e)
		{
			try
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
					string xlsxFn = orfn + "\\短路连接关系_" + tt + "_" + ttms + ".xlsx";
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
			catch (System.Exception arg_126_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_126_0.StackTrace);
			}
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			base.Close();
		}
		public void ShowPinRelationFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				int iIndex = 0;
				if (this.bDLHistoryInfoView)
				{
					try
					{
						try
						{
							connection = new OleDbConnection();
							connection.ConnectionString = this.gLineTestProcessor.mddbPathStr;
							connection.Open();
							dataReader = new OleDbCommand("select * from THistoryDLDataDetail where HID=" + this.iEditPid + "", connection).ExecuteReader();
							this.dataGridView1.AllowUserToAddRows = true;
							while (dataReader.Read())
							{
								string temp1Str = dataReader["PlugName1"].ToString();
								string temp2Str = dataReader["Pin1"].ToString();
								string temp3Str = dataReader["PlugName2"].ToString();
								string temp4Str = dataReader["Pin2"].ToString();
								this.dataGridView1.Rows.Add(1);
								int num = iIndex + 1;
								int num2 = num;
								this.dataGridView1.Rows[iIndex].Cells[0].Value = num2.ToString();
								this.dataGridView1.Rows[iIndex].Cells[1].Value = temp1Str;
								this.dataGridView1.Rows[iIndex].Cells[2].Value = temp2Str;
								this.dataGridView1.Rows[iIndex].Cells[3].Value = temp3Str;
								this.dataGridView1.Rows[iIndex].Cells[4].Value = temp4Str;
								iIndex = num;
							}
							dataReader.Close();
							dataReader = null;
							this.dataGridView1.AllowUserToAddRows = false;
							connection.Close();
							connection = null;
						}
						catch (System.Exception arg_1D0_0)
						{
							this.dataGridView1.AllowUserToAddRows = false;
							KLineTestProcessor.ExceptionRecordFunc(arg_1D0_0.StackTrace);
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
						goto IL_383;
					}
					catch (System.Exception arg_1F7_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_1F7_0.StackTrace);
						goto IL_383;
					}
				}
				if (this.gLineTestProcessor.gDLPinConnectInfoDLResultArray != null)
				{
					for (int i = 0; i < this.gLineTestProcessor.gDLPinConnectInfoDLResultArray.Count; i++)
					{
						string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoDLResultArray[i].mALJQName;
						string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoDLResultArray[i].mnALJQPinNum;
						string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoDLResultArray[i].mBLJQName;
						string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoDLResultArray[i].mnBLJQPinNum;
						this.dataGridView1.AllowUserToAddRows = true;
						this.dataGridView1.Rows.Add(1);
						int num3 = iIndex + 1;
						int num4 = num3;
						this.dataGridView1.Rows[iIndex].Cells[0].Value = num4.ToString();
						this.dataGridView1.Rows[iIndex].Cells[1].Value = temp1Str;
						this.dataGridView1.Rows[iIndex].Cells[2].Value = temp2Str;
						this.dataGridView1.Rows[iIndex].Cells[3].Value = temp3Str;
						this.dataGridView1.Rows[iIndex].Cells[4].Value = temp4Str;
						this.dataGridView1.AllowUserToAddRows = false;
						iIndex = num3;
					}
				}
				IL_383:;
			}
			catch (System.Exception arg_385_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_385_0.StackTrace);
			}
		}
		private void ctFormDLTestResultView_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.dataGridView1.Rows.Clear();
				for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
				{
					this.dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
					this.dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
				{
					this.dataGridView1.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				this.ShowPinRelationFunc();
				for (int k = 0; k < this.dataGridView1.Rows.Count; k++)
				{
					this.dataGridView1.Rows[k].Selected = false;
				}
			}
			catch (System.Exception arg_D6_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_D6_0.StackTrace);
			}
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode == 0)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
			catch (System.Exception arg_F9_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_F9_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
		}
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 746;
					int iy = 0;
					int ia = 0;
					if (iw > 0)
					{
						ia = iw / 4;
						iy = iw % 4;
					}
					this.dataGridView1.Columns[0].Width = iy + 72;
					int width = ia + 170;
					this.dataGridView1.Columns[1].Width = width;
					int width2 = ia + 155;
					this.dataGridView1.Columns[2].Width = width2;
					this.dataGridView1.Columns[3].Width = width;
					this.dataGridView1.Columns[4].Width = width2;
				}
			}
			catch (System.Exception arg_B9_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_B9_0.StackTrace);
			}
		}
		private void ctFormDLTestResultView_SizeChanged(object sender, System.EventArgs e)
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
					this.~ctFormDLTestResultView();
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
