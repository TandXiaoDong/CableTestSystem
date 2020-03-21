using Aspose.Cells;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormPinPinContrast : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public string loginUser;
		private FlowLayoutPanel flowLayoutPanel1;
		private Button btnShowAll;
		private FolderBrowserDialog folderBrowserDialog1;
		private Button btnQuit;
		private Button btnShowUnSame;
		private Button btnShowSame;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private DataGridView dataGridView1;
		private TableLayoutPanel tableLayoutPanel1;
		private DataGridViewTextBoxColumn Column_xh;
		private DataGridViewTextBoxColumn Column_startInterface;
		private DataGridViewTextBoxColumn Column_startPin;
		private DataGridViewTextBoxColumn Column_stopInterface;
		private DataGridViewTextBoxColumn Column_stopPin;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private DataGridView dataGridView2;
		private Button btnExportPinRelation;
		private Container components;
		public ctFormPinPinContrast(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
				}
				catch (System.Exception ex_21)
				{
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormPinPinContrast()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormPinPinContrast));
			this.btnShowAll = new Button();
			this.btnQuit = new Button();
			this.btnShowUnSame = new Button();
			this.btnShowSame = new Button();
			this.groupBox1 = new GroupBox();
			this.dataGridView1 = new DataGridView();
			this.Column_xh = new DataGridViewTextBoxColumn();
			this.Column_startInterface = new DataGridViewTextBoxColumn();
			this.Column_startPin = new DataGridViewTextBoxColumn();
			this.Column_stopInterface = new DataGridViewTextBoxColumn();
			this.Column_stopPin = new DataGridViewTextBoxColumn();
			this.groupBox2 = new GroupBox();
			this.dataGridView2 = new DataGridView();
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
			this.btnExportPinRelation = new Button();
			this.folderBrowserDialog1 = new FolderBrowserDialog();
			this.flowLayoutPanel1 = new FlowLayoutPanel();
			this.tableLayoutPanel1 = new TableLayoutPanel();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.dataGridView1).BeginInit();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.dataGridView2).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			this.btnShowAll.Anchor = AnchorStyles.Top;
			this.btnShowAll.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(289, 2);
			this.btnShowAll.Location = location;
			Padding margin = new Padding(15, 2, 2, 2);
			this.btnShowAll.Margin = margin;
			this.btnShowAll.Name = "btnShowAll";
			System.Drawing.Size size = new System.Drawing.Size(120, 24);
			this.btnShowAll.Size = size;
			this.btnShowAll.TabIndex = 3;
			this.btnShowAll.Text = "显示所有";
			this.btnShowAll.UseVisualStyleBackColor = true;
			this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
			this.btnQuit.Anchor = AnchorStyles.Top;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(563, 2);
			this.btnQuit.Location = location2;
			Padding margin2 = new Padding(15, 2, 2, 2);
			this.btnQuit.Margin = margin2;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size2 = new System.Drawing.Size(120, 24);
			this.btnQuit.Size = size2;
			this.btnQuit.TabIndex = 0;
			this.btnQuit.Text = "关闭";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btnShowUnSame.Anchor = AnchorStyles.Top;
			this.btnShowUnSame.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(15, 2);
			this.btnShowUnSame.Location = location3;
			Padding margin3 = new Padding(15, 2, 2, 2);
			this.btnShowUnSame.Margin = margin3;
			this.btnShowUnSame.Name = "btnShowUnSame";
			System.Drawing.Size size3 = new System.Drawing.Size(120, 24);
			this.btnShowUnSame.Size = size3;
			this.btnShowUnSame.TabIndex = 1;
			this.btnShowUnSame.Text = "仅显示差异项";
			this.btnShowUnSame.UseVisualStyleBackColor = true;
			this.btnShowUnSame.Click += new System.EventHandler(this.btnShowUnSame_Click);
			this.btnShowSame.Anchor = AnchorStyles.Top;
			this.btnShowSame.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(152, 2);
			this.btnShowSame.Location = location4;
			Padding margin4 = new Padding(15, 2, 2, 2);
			this.btnShowSame.Margin = margin4;
			this.btnShowSame.Name = "btnShowSame";
			System.Drawing.Size size4 = new System.Drawing.Size(120, 24);
			this.btnShowSame.Size = size4;
			this.btnShowSame.TabIndex = 2;
			this.btnShowSame.Text = "仅显示相同项";
			this.btnShowSame.UseVisualStyleBackColor = true;
			this.btnShowSame.Click += new System.EventHandler(this.btnShowSame_Click);
			this.groupBox1.Controls.Add(this.dataGridView1);
			this.groupBox1.Dock = DockStyle.Fill;
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(2, 2);
			this.groupBox1.Location = location5;
			Padding margin5 = new Padding(2);
			this.groupBox1.Margin = margin5;
			this.groupBox1.Name = "groupBox1";
			Padding padding = new Padding(2);
			this.groupBox1.Padding = padding;
			System.Drawing.Size size5 = new System.Drawing.Size(385, 472);
			this.groupBox1.Size = size5;
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "已定义连接关系";
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
				this.Column_stopPin
			};
			this.dataGridView1.Columns.AddRange(dataGridViewColumns);
			this.dataGridView1.Dock = DockStyle.Fill;
			System.Drawing.Point location6 = new System.Drawing.Point(2, 19);
			this.dataGridView1.Location = location6;
			Padding margin6 = new Padding(2);
			this.dataGridView1.Margin = margin6;
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 27;
			this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size6 = new System.Drawing.Size(381, 451);
			this.dataGridView1.Size = size6;
			this.dataGridView1.TabIndex = 15;
			this.dataGridView1.SizeChanged += new System.EventHandler(this.dataGridView1_SizeChanged);
			this.Column_xh.HeaderText = "序号";
			this.Column_xh.Name = "Column_xh";
			this.Column_xh.ReadOnly = true;
			this.Column_xh.Width = 70;
			this.Column_startInterface.HeaderText = "起点接口";
			this.Column_startInterface.Name = "Column_startInterface";
			this.Column_startInterface.ReadOnly = true;
			this.Column_startInterface.Width = 90;
			this.Column_startPin.HeaderText = "起点接点";
			this.Column_startPin.Name = "Column_startPin";
			this.Column_startPin.ReadOnly = true;
			this.Column_startPin.Width = 90;
			this.Column_stopInterface.HeaderText = "终点接口";
			this.Column_stopInterface.Name = "Column_stopInterface";
			this.Column_stopInterface.ReadOnly = true;
			this.Column_stopInterface.Width = 90;
			this.Column_stopPin.HeaderText = "终点接点";
			this.Column_stopPin.Name = "Column_stopPin";
			this.Column_stopPin.ReadOnly = true;
			this.Column_stopPin.Width = 90;
			this.groupBox2.Controls.Add(this.dataGridView2);
			this.groupBox2.Dock = DockStyle.Fill;
			this.groupBox2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(391, 2);
			this.groupBox2.Location = location7;
			Padding margin7 = new Padding(2);
			this.groupBox2.Margin = margin7;
			this.groupBox2.Name = "groupBox2";
			Padding padding2 = new Padding(2);
			this.groupBox2.Padding = padding2;
			System.Drawing.Size size7 = new System.Drawing.Size(386, 472);
			this.groupBox2.Size = size7;
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "自学习芯线关系";
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
				this.dataGridViewTextBoxColumn2,
				this.dataGridViewTextBoxColumn3,
				this.dataGridViewTextBoxColumn4,
				this.dataGridViewTextBoxColumn5
			};
			this.dataGridView2.Columns.AddRange(dataGridViewColumns2);
			this.dataGridView2.Dock = DockStyle.Fill;
			System.Drawing.Point location8 = new System.Drawing.Point(2, 19);
			this.dataGridView2.Location = location8;
			Padding margin8 = new Padding(2);
			this.dataGridView2.Margin = margin8;
			this.dataGridView2.MultiSelect = false;
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.RowHeadersVisible = false;
			this.dataGridView2.RowTemplate.Height = 27;
			this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			System.Drawing.Size size8 = new System.Drawing.Size(382, 451);
			this.dataGridView2.Size = size8;
			this.dataGridView2.TabIndex = 16;
			this.dataGridView2.SizeChanged += new System.EventHandler(this.dataGridView2_SizeChanged);
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
			this.btnExportPinRelation.Anchor = AnchorStyles.Top;
			this.btnExportPinRelation.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(426, 2);
			this.btnExportPinRelation.Location = location9;
			Padding margin9 = new Padding(15, 2, 2, 2);
			this.btnExportPinRelation.Margin = margin9;
			this.btnExportPinRelation.Name = "btnExportPinRelation";
			System.Drawing.Size size9 = new System.Drawing.Size(120, 24);
			this.btnExportPinRelation.Size = size9;
			this.btnExportPinRelation.TabIndex = 4;
			this.btnExportPinRelation.Text = "导出学习关系";
			this.btnExportPinRelation.UseVisualStyleBackColor = true;
			this.btnExportPinRelation.Click += new System.EventHandler(this.btnExportPinRelation_Click);
			this.flowLayoutPanel1.Anchor = AnchorStyles.Bottom;
			this.flowLayoutPanel1.Controls.Add(this.btnShowUnSame);
			this.flowLayoutPanel1.Controls.Add(this.btnShowSame);
			this.flowLayoutPanel1.Controls.Add(this.btnShowAll);
			this.flowLayoutPanel1.Controls.Add(this.btnExportPinRelation);
			this.flowLayoutPanel1.Controls.Add(this.btnQuit);
			System.Drawing.Point location10 = new System.Drawing.Point(41, 514);
			this.flowLayoutPanel1.Location = location10;
			Padding margin10 = new Padding(2);
			this.flowLayoutPanel1.Margin = margin10;
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			System.Drawing.Size size10 = new System.Drawing.Size(712, 30);
			this.flowLayoutPanel1.Size = size10;
			this.flowLayoutPanel1.TabIndex = 5;
			this.tableLayoutPanel1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
			System.Drawing.Point location11 = new System.Drawing.Point(8, 16);
			this.tableLayoutPanel1.Location = location11;
			Padding margin11 = new Padding(2);
			this.tableLayoutPanel1.Margin = margin11;
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90f));
			System.Drawing.Size size11 = new System.Drawing.Size(779, 476);
			this.tableLayoutPanel1.Size = size11;
			this.tableLayoutPanel1.TabIndex = 6;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(794, 571);
			base.ClientSize = clientSize;
			base.Controls.Add(this.tableLayoutPanel1);
			base.Controls.Add(this.flowLayoutPanel1);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin12 = new Padding(2);
			base.Margin = margin12;
			base.Name = "ctFormPinPinContrast";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "连接关系对比";
			base.Load += new System.EventHandler(this.ctFormPinPinContrast_Load);
			base.SizeChanged += new System.EventHandler(this.ctFormPinPinContrast_SizeChanged);
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView1).EndInit();
			this.groupBox2.ResumeLayout(false);
			((ISupportInitialize)this.dataGridView2).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			base.ResumeLayout(false);
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
		public void SetDGVWidthSizeFunc()
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 382;
					int arg_2F_0 = 0;
					int ia = 0;
					if (iw > 0)
					{
						ia = iw / 4;
						arg_2F_0 = iw % 4;
					}
					int width = arg_2F_0 + 60;
					this.dataGridView1.Columns[0].Width = width;
					int this2 = ia + 75;
					this.dataGridView1.Columns[1].Width = this2;
					this.dataGridView1.Columns[2].Width = this2;
					this.dataGridView1.Columns[3].Width = this2;
					this.dataGridView1.Columns[4].Width = this2;
					this.dataGridView2.Columns[0].Width = width;
					this.dataGridView2.Columns[1].Width = this2;
					this.dataGridView2.Columns[2].Width = this2;
					this.dataGridView2.Columns[3].Width = this2;
					this.dataGridView2.Columns[4].Width = this2;
				}
			}
			catch (System.Exception arg_11E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_11E_0.StackTrace);
			}
		}
		private void ctFormPinPinContrast_SizeChanged(object sender, System.EventArgs e)
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
		private void ctFormPinPinContrast_Load(object sender, System.EventArgs e)
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
			catch (System.Exception arg_124_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_124_0.StackTrace);
			}
			this.btnShowAll_Click(null, null);
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
			catch (System.Exception arg_1D5_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1D5_0.StackTrace);
			}
			this.SetDGVWidthSizeFunc();
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			base.Close();
		}
		private void btnShowUnSame_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.dataGridView1.Rows.Clear();
				this.dataGridView2.Rows.Clear();
				int iIndex = 0;
				int ii = 0;
				IL_49:
				while (ii < this.gLineTestProcessor.gDLPinConnectInfoArray.Count)
				{
					bool bExistFlag = false;
					string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoArray[ii].mALJQName;
					string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoArray[ii].mnALJQPinNum;
					string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoArray[ii].mBLJQName;
					string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoArray[ii].mnBLJQPinNum;
					for (int jj = 0; jj < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; jj++)
					{
						string temp5Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mALJQName;
						string temp6Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnALJQPinNum;
						string temp7Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mBLJQName;
						string temp8Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnBLJQPinNum;
						if (0 == temp1Str.CompareTo(temp5Str) && 0 == temp2Str.CompareTo(temp6Str) && 0 == temp3Str.CompareTo(temp7Str) && 0 == temp4Str.CompareTo(temp8Str))
						{
							IL_189:
							IL_278:
							ii++;
							goto IL_49;
						}
					}
					if (bExistFlag)
					{
						goto IL_189;
					}
					this.dataGridView1.AllowUserToAddRows = true;
					this.dataGridView1.Rows.Add(1);
					int num = iIndex + 1;
					int num2 = num;
					this.dataGridView1.Rows[iIndex].Cells[0].Value = num2.ToString();
					this.dataGridView1.Rows[iIndex].Cells[1].Value = temp1Str;
					this.dataGridView1.Rows[iIndex].Cells[2].Value = temp2Str;
					this.dataGridView1.Rows[iIndex].Cells[3].Value = temp3Str;
					this.dataGridView1.Rows[iIndex].Cells[4].Value = temp4Str;
					this.dataGridView1.AllowUserToAddRows = false;
					iIndex = num;
					goto IL_278;
				}
				iIndex = 0;
				int ii2 = 0;
				IL_287:
				while (ii2 < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count)
				{
					bool bExistFlag = false;
					string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[ii2].mALJQName;
					string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[ii2].mnALJQPinNum;
					string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[ii2].mBLJQName;
					string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[ii2].mnBLJQPinNum;
					for (int jj2 = 0; jj2 < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; jj2++)
					{
						string temp5Str = this.gLineTestProcessor.gDLPinConnectInfoArray[jj2].mALJQName;
						string temp6Str = this.gLineTestProcessor.gDLPinConnectInfoArray[jj2].mnALJQPinNum;
						string temp7Str = this.gLineTestProcessor.gDLPinConnectInfoArray[jj2].mBLJQName;
						string temp8Str = this.gLineTestProcessor.gDLPinConnectInfoArray[jj2].mnBLJQPinNum;
						if (0 == temp1Str.CompareTo(temp5Str) && 0 == temp2Str.CompareTo(temp6Str) && 0 == temp3Str.CompareTo(temp7Str) && 0 == temp4Str.CompareTo(temp8Str))
						{
							IL_3BA:
							IL_4A9:
							ii2++;
							goto IL_287;
						}
					}
					if (bExistFlag)
					{
						goto IL_3BA;
					}
					this.dataGridView2.AllowUserToAddRows = true;
					this.dataGridView2.Rows.Add(1);
					int num = iIndex + 1;
					int num3 = num;
					this.dataGridView2.Rows[iIndex].Cells[0].Value = num3.ToString();
					this.dataGridView2.Rows[iIndex].Cells[1].Value = temp1Str;
					this.dataGridView2.Rows[iIndex].Cells[2].Value = temp2Str;
					this.dataGridView2.Rows[iIndex].Cells[3].Value = temp3Str;
					this.dataGridView2.Rows[iIndex].Cells[4].Value = temp4Str;
					this.dataGridView2.AllowUserToAddRows = false;
					iIndex = num;
					goto IL_4A9;
				}
			}
			catch (System.Exception arg_4CC_0)
			{
				this.dataGridView1.AllowUserToAddRows = false;
				this.dataGridView2.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_4CC_0.StackTrace);
			}
		}
		private void btnShowSame_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.dataGridView1.Rows.Clear();
				this.dataGridView2.Rows.Clear();
				int iIndex = 0;
				this.dataGridView1.AllowUserToAddRows = true;
				this.dataGridView2.AllowUserToAddRows = true;
				int ii = 0;
				IL_60:
				while (ii < this.gLineTestProcessor.gDLPinConnectInfoArray.Count)
				{
					bool bExistFlag = false;
					string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoArray[ii].mALJQName;
					string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoArray[ii].mnALJQPinNum;
					string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoArray[ii].mBLJQName;
					string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoArray[ii].mnBLJQPinNum;
					for (int jj = 0; jj < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; jj++)
					{
						string temp5Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mALJQName;
						string temp6Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnALJQPinNum;
						string temp7Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mBLJQName;
						string temp8Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[jj].mnBLJQPinNum;
						if (0 == temp1Str.CompareTo(temp5Str) && 0 == temp2Str.CompareTo(temp6Str) && 0 == temp3Str.CompareTo(temp7Str) && 0 == temp4Str.CompareTo(temp8Str))
						{
							IL_196:
							this.dataGridView1.Rows.Add(1);
							int num = iIndex + 1;
							int num2 = num;
							this.dataGridView1.Rows[iIndex].Cells[0].Value = num2.ToString();
							this.dataGridView1.Rows[iIndex].Cells[1].Value = temp1Str;
							this.dataGridView1.Rows[iIndex].Cells[2].Value = temp2Str;
							this.dataGridView1.Rows[iIndex].Cells[3].Value = temp3Str;
							this.dataGridView1.Rows[iIndex].Cells[4].Value = temp4Str;
							this.dataGridView2.Rows.Add(1);
							int num3 = num;
							this.dataGridView2.Rows[iIndex].Cells[0].Value = num3.ToString();
							this.dataGridView2.Rows[iIndex].Cells[1].Value = temp1Str;
							this.dataGridView2.Rows[iIndex].Cells[2].Value = temp2Str;
							this.dataGridView2.Rows[iIndex].Cells[3].Value = temp3Str;
							this.dataGridView2.Rows[iIndex].Cells[4].Value = temp4Str;
							iIndex = num;
							IL_332:
							ii++;
							goto IL_60;
						}
					}
					if (bExistFlag)
					{
						goto IL_196;
					}
					goto IL_332;
				}
				this.dataGridView1.AllowUserToAddRows = false;
				this.dataGridView2.AllowUserToAddRows = false;
			}
			catch (System.Exception arg_36D_0)
			{
				this.dataGridView1.AllowUserToAddRows = false;
				this.dataGridView2.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_36D_0.StackTrace);
			}
		}
		private void btnShowAll_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.dataGridView1.Rows.Clear();
				this.dataGridView2.Rows.Clear();
				int iIndex = 0;
				this.dataGridView1.AllowUserToAddRows = true;
				for (int ii = 0; ii < this.gLineTestProcessor.gDLPinConnectInfoArray.Count; ii++)
				{
					string temp1Str = this.gLineTestProcessor.gDLPinConnectInfoArray[ii].mALJQName;
					string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoArray[ii].mnALJQPinNum;
					string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoArray[ii].mBLJQName;
					string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoArray[ii].mnBLJQPinNum;
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
				this.dataGridView1.AllowUserToAddRows = false;
				iIndex = 0;
				this.dataGridView2.AllowUserToAddRows = true;
				for (int ii2 = 0; ii2 < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; ii2++)
				{
					string temp5Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[ii2].mALJQName;
					string temp6Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[ii2].mnALJQPinNum;
					string temp7Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[ii2].mBLJQName;
					string temp8Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[ii2].mnBLJQPinNum;
					this.dataGridView2.Rows.Add(1);
					int num3 = iIndex + 1;
					int num4 = num3;
					this.dataGridView2.Rows[iIndex].Cells[0].Value = num4.ToString();
					this.dataGridView2.Rows[iIndex].Cells[1].Value = temp5Str;
					this.dataGridView2.Rows[iIndex].Cells[2].Value = temp6Str;
					this.dataGridView2.Rows[iIndex].Cells[3].Value = temp7Str;
					this.dataGridView2.Rows[iIndex].Cells[4].Value = temp8Str;
					iIndex = num3;
				}
				this.dataGridView2.AllowUserToAddRows = false;
			}
			catch (System.Exception arg_338_0)
			{
				this.dataGridView1.AllowUserToAddRows = false;
				this.dataGridView2.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_338_0.StackTrace);
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
					for (int j = 0; j < this.gLineTestProcessor.gDLPinConnectInfoSelfArray.Count; j = num)
					{
						num = j + 1;
						string temp1Str = System.Convert.ToString(num);
						string temp2Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j].mALJQName;
						string temp3Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j].mnALJQPinNum;
						string temp4Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j].mBLJQName;
						string temp5Str = this.gLineTestProcessor.gDLPinConnectInfoSelfArray[j].mnBLJQPinNum;
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
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormPinPinContrast();
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
