using Aspose.Cells;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormSelfStudyPinRelationView : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		private FolderBrowserDialog folderBrowserDialog1;
		private GroupBox groupBox2;
		private DataGridView dataGridView1;
		private Button btnExportPinRelation;
		private Button btnQuit;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private Container components;
		public ctFormSelfStudyPinRelationView(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.gLineTestProcessor = gltProcessor;
				}
				catch (System.Exception ex_15)
				{
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormSelfStudyPinRelationView()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormSelfStudyPinRelationView));
			this.groupBox2 = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.btnExportPinRelation = new Button();
			this.btnQuit = new Button();
			this.folderBrowserDialog1 = new FolderBrowserDialog();
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			base.SuspendLayout();
			this.groupBox2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.groupBox2.Controls.Add(this.dataGridView1);
			this.groupBox2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(10, 8);
			this.groupBox2.Location = location;
			Padding margin = new Padding(2);
			this.groupBox2.Margin = margin;
			this.groupBox2.Name = "groupBox2";
			Padding padding = new Padding(2);
			this.groupBox2.Padding = padding;
			System.Drawing.Size size = new System.Drawing.Size(775, 480);
			this.groupBox2.Size = size;
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "芯线关系表";
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
			Padding margin2 = new Padding(2);
			this.dataGridView1.Margin = margin2;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size2 = new System.Drawing.Size(771, 459);
			this.dataGridView1.Size = size2;
			this.dataGridView1.TabIndex = 16;
			this.btnExportPinRelation.Anchor = AnchorStyles.Bottom;
			this.btnExportPinRelation.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(237, 512);
			this.btnExportPinRelation.Location = location3;
			Padding margin3 = new Padding(15, 2, 2, 2);
			this.btnExportPinRelation.Margin = margin3;
			this.btnExportPinRelation.Name = "btnExportPinRelation";
			System.Drawing.Size size3 = new System.Drawing.Size(120, 24);
			this.btnExportPinRelation.Size = size3;
			this.btnExportPinRelation.TabIndex = 6;
			this.btnExportPinRelation.Text = "导出芯线关系";
			this.btnExportPinRelation.UseVisualStyleBackColor = true;
			this.btnExportPinRelation.Click += new System.EventHandler(this.btnExportPinRelation_Click);
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(438, 512);
			this.btnQuit.Location = location4;
			Padding margin4 = new Padding(15, 2, 2, 2);
			this.btnQuit.Margin = margin4;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size4 = new System.Drawing.Size(120, 24);
			this.btnQuit.Size = size4;
			this.btnQuit.TabIndex = 5;
			this.btnQuit.Text = "关闭";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.dataGridViewTextBoxColumn1.HeaderText = "序号";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 70;
			this.dataGridViewTextBoxColumn2.HeaderText = "起点接口";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 90;
			this.dataGridViewTextBoxColumn3.HeaderText = "起点接点";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.Width = 90;
			this.dataGridViewTextBoxColumn4.HeaderText = "终点接口";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Width = 90;
			this.dataGridViewTextBoxColumn5.HeaderText = "终点接点";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.Width = 90;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.btnExportPinRelation);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.groupBox2);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "ctFormSelfStudyPinRelationView";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "自学习线束芯线关系浏览";
			base.Load += new System.EventHandler(this.ctFormSelfStudyPinRelationView_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormSelfStudyPinRelationView_SizeChanged);
			this.groupBox2.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			base.ResumeLayout(false);
		}
		public void ShowAllPinRelationFunc()
		{
			try
			{
				this.dataGridView1.Rows.Clear();
				int iIndex = 0;
				this.dataGridView1.AllowUserToAddRows = true;
				for (int ii = 0; ii < this.gLineTestProcessor.gDLPinConnectInfoSelf2Array.Count; ii++)
				{
					string temp5Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[ii].mALJQName;
					string temp6Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[ii].mnALJQPinNum;
					string temp7Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[ii].mBLJQName;
					string temp8Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[ii].mnBLJQPinNum;
					this.dataGridView1.Rows.Add(1);
					int num = iIndex + 1;
					this.dataGridView1.Rows[iIndex].Cells[0].Value = System.Convert.ToString(num);
					this.dataGridView1.Rows[iIndex].Cells[1].Value = temp5Str;
					this.dataGridView1.Rows[iIndex].Cells[2].Value = temp6Str;
					this.dataGridView1.Rows[iIndex].Cells[3].Value = temp7Str;
					this.dataGridView1.Rows[iIndex].Cells[4].Value = temp8Str;
					iIndex = num;
				}
				this.dataGridView1.AllowUserToAddRows = false;
			}
			catch (System.Exception arg_196_0)
			{
				this.dataGridView1.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_196_0.StackTrace);
			}
		}
		private void ctFormSelfStudyPinRelationView_Load(object sender, System.EventArgs e)
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
			this.ShowAllPinRelationFunc();
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
			catch (System.Exception arg_FA_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_FA_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
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
					string xlsxFn = orfn + "\\自学习芯线关系_" + tt + "_" + ttms + ".xlsx";
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
				this.putValue(cells, "序号", iRow, iCol, st);
				int column = iCol + 1;
				this.putValue(cells, "起点接口", iRow, column, st);
				int column2 = iCol + 2;
				this.putValue(cells, "起点接点", iRow, column2, st);
				int column3 = iCol + 3;
				this.putValue(cells, "终点接口", iRow, column3, st);
				int column4 = iCol + 4;
				this.putValue(cells, "终点接点", iRow, column4, st);
				iRow++;
				try
				{
					int num;
					for (int j = 0; j < this.gLineTestProcessor.gDLPinConnectInfoSelf2Array.Count; j = num)
					{
						num = j + 1;
						string temp1Str = System.Convert.ToString(num);
						string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[j].mALJQName;
						string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[j].mnALJQPinNum;
						string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[j].mBLJQName;
						string temp5Str = this.gLineTestProcessor.gDLPinConnectInfoSelf2Array[j].mnBLJQPinNum;
						this.putValue(cells, temp1Str, iRow, iCol, st);
						this.putValue(cells, temp2Str, iRow, column, st);
						this.putValue(cells, temp3Str, iRow, column2, st);
						this.putValue(cells, temp4Str, iRow, column3, st);
						this.putValue(cells, temp5Str, iRow, column4, st);
						iRow++;
					}
				}
				catch (System.Exception arg_1F3_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_1F3_0.StackTrace);
				}
				wb.Save(xlsxFile, SaveFormat.Xlsx);
				wb = null;
			}
			catch (System.Exception arg_20D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_20D_0.StackTrace);
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
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			base.Close();
		}
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 382;
					int iy = 0;
					int arg_49_0 = 0;
					if (iw > 0)
					{
						arg_49_0 = iw / 4;
						iy = iw % 4;
					}
					this.dataGridView1.Columns[0].Width = iy + 60;
					int this2 = arg_49_0 + 75;
					this.dataGridView1.Columns[1].Width = this2;
					this.dataGridView1.Columns[2].Width = this2;
					this.dataGridView1.Columns[3].Width = this2;
					this.dataGridView1.Columns[4].Width = this2;
				}
			}
			catch (System.Exception arg_A9_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_A9_0.StackTrace);
			}
		}
		private void ctFormSelfStudyPinRelationView_SizeChanged(object sender, System.EventArgs e)
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
					this.~ctFormSelfStudyPinRelationView();
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
