using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormSelfTest : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public string loginUser;
		public int iStartValue;
		public int iEndValue;
		public int iTestTime;
		public bool bRunFlag;
		private GroupBox groupBox1;
		private NumericUpDown numericUpDown_stop;
		private NumericUpDown numericUpDown_start;
		private Label label2;
		private Label label1;
		private Button btnStart;
		private GroupBox groupBox2;
		private DataGridView dataGridView1;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private GroupBox groupBox3;
		private DataGridView dataGridView2;
		private TextBox textBox_ex_count;
		private Label label3;
		private Button btnQuit;
		private IContainer components;
		private ProgressBar progressBar1;
		private System.Windows.Forms.Timer timer1;
		public ctFormSelfTest(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
				}
				catch (System.Exception arg_21_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_21_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormSelfTest()
		{
			IContainer this2 = this.components;
			if (this2 != null)
			{
				this2.Dispose();
			}
		}
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown_stop = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_start = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_ex_count = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_start)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown_stop);
            this.groupBox1.Controls.Add(this.numericUpDown_start);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(21, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(560, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数设置";
            // 
            // numericUpDown_stop
            // 
            this.numericUpDown_stop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numericUpDown_stop.Location = new System.Drawing.Point(387, 29);
            this.numericUpDown_stop.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown_stop.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_stop.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_stop.Name = "numericUpDown_stop";
            this.numericUpDown_stop.Size = new System.Drawing.Size(112, 24);
            this.numericUpDown_stop.TabIndex = 2;
            this.numericUpDown_stop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_stop.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDown_stop.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_KeyUp);
            // 
            // numericUpDown_start
            // 
            this.numericUpDown_start.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numericUpDown_start.Location = new System.Drawing.Point(196, 29);
            this.numericUpDown_start.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown_start.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_start.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_start.Name = "numericUpDown_start";
            this.numericUpDown_start.Size = new System.Drawing.Size(112, 24);
            this.numericUpDown_start.TabIndex = 1;
            this.numericUpDown_start.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_start.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_start.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_KeyUp);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "——";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "请输入自检范围:";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStart.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(647, 44);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 28);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始自检";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Location = new System.Drawing.Point(647, 412);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(90, 28);
            this.btnQuit.TabIndex = 6;
            this.btnQuit.Text = "关闭";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Green;
            this.progressBar1.Location = new System.Drawing.Point(21, 89);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(560, 19);
            this.progressBar1.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(22, 125);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(270, 420);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "正常点";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(2, 19);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(266, 399);
            this.dataGridView1.TabIndex = 13;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "引脚";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 162;
            // 
            // textBox_ex_count
            // 
            this.textBox_ex_count.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox_ex_count.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_ex_count.Location = new System.Drawing.Point(641, 231);
            this.textBox_ex_count.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ex_count.Name = "textBox_ex_count";
            this.textBox_ex_count.ReadOnly = true;
            this.textBox_ex_count.Size = new System.Drawing.Size(91, 24);
            this.textBox_ex_count.TabIndex = 5;
            this.textBox_ex_count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(643, 204);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "错误总点数:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(310, 125);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(270, 420);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "异常点";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(2, 19);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(266, 399);
            this.dataGridView2.TabIndex = 13;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "序号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "引脚";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 162;
            // 
            // ctFormSelfTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 571);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_ex_count);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ctFormSelfTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备自检";
            this.Load += new System.EventHandler(this.ctFormSelfTest_Load);
            this.SizeChanged += new System.EventHandler(this.ctFormSelfTest_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_start)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			if (!this.bRunFlag || !this.gLineTestProcessor.mbKeepRun || DialogResult.OK == MessageBox.Show("正在进行设备自检，您确定要退出吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
			{
				this.timer1.Enabled = false;
				this.gLineTestProcessor.mbKeepRun = false;
				this.gLineTestProcessor.SendStopCmd();
				base.Close();
			}
		}
		public void StopRunDisposeFunc()
		{
			try
			{
				this.bRunFlag = false;
				this.gLineTestProcessor.mbKeepRun = false;
				this.progressBar1.Value = 100;
				this.timer1.Enabled = false;
				this.btnStart.Text = "开始自检";
				this.gLineTestProcessor.SendStopCmd();
				for (int i = 0; i < 3; i++)
				{
					System.Threading.Thread.Sleep(100);
					this.gLineTestProcessor.SendStopCmd();
				}
				System.Threading.Thread.Sleep(500);
			}
			catch (System.Exception arg_71_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_71_0.StackTrace);
			}
		}
		private void btnStart_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.gLineTestProcessor.bIsConnSuccFlag)
				{
					MessageBox.Show("设备未连接!", "提示", MessageBoxButtons.OK);
				}
				else if (!this.bRunFlag)
				{
					this.iStartValue = System.Convert.ToInt32(this.numericUpDown_start.Text.ToString());
					this.iEndValue = System.Convert.ToInt32(this.numericUpDown_stop.Text.ToString());
					this.dataGridView1.Rows.Clear();
					this.dataGridView2.Rows.Clear();
					this.textBox_ex_count.Text = "";
					this.iTestTime = 0;
					this.progressBar1.Value = 0;
					this.btnStart.Text = "停止自检";
					this.gLineTestProcessor.mpDevComm.mParseCmd.selfTestExPointCount = 0;
					this.gLineTestProcessor.mpDevComm.mParseCmd.selfTestDataCount = 0;
					this.gLineTestProcessor.mpDevComm.mParseCmd.selfTestOKCount = 0;
					this.gLineTestProcessor.mpDevComm.mParseCmd.selfTestEXCount = 0;
					this.gLineTestProcessor.mpDevComm.mParseCmd.selfTestProgress = 0;
					this.timer1.Enabled = true;
					this.gLineTestProcessor.mbKeepRun = true;
					this.bRunFlag = true;
					this.gLineTestProcessor.SendSelfTestCmd(this.iStartValue, this.iEndValue);
				}
				else if (DialogResult.OK == MessageBox.Show("正在进行设备自检，您确定要停止吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
				{
					this.StopRunDisposeFunc();
				}
			}
			catch (System.Exception arg_17C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_17C_0.StackTrace);
				this.StopRunDisposeFunc();
				MessageBox.Show("系统出现未知异常!", "提示", MessageBoxButtons.OK);
			}
		}
		public void showFunc()
		{
			try
			{
				int iDGV1RowCount = this.dataGridView1.Rows.Count;
				int iOKCount = this.gLineTestProcessor.mpDevComm.mParseCmd.selfTestOKCount;
				if (iDGV1RowCount < iOKCount)
				{
					this.dataGridView1.AllowUserToAddRows = true;
					int num;
					for (int i = iDGV1RowCount; i < iOKCount; i = num)
					{
						this.dataGridView1.Rows.Add(1);
						num = i + 1;
						this.dataGridView1.Rows[i].Cells[0].Value = System.Convert.ToString(num);
						this.dataGridView1.Rows[i].Cells[1].Value = System.Convert.ToString(this.gLineTestProcessor.mpDevComm.mParseCmd.selfTestPointArray[i]);
					}
					this.dataGridView1.AllowUserToAddRows = false;
				}
				int iDGV2RowCount = this.dataGridView2.Rows.Count;
				int iEXCount = this.gLineTestProcessor.mpDevComm.mParseCmd.selfTestEXCount;
				if (iDGV2RowCount < iEXCount)
				{
					this.dataGridView2.AllowUserToAddRows = true;
					int num2;
					for (int j = iDGV2RowCount; j < iEXCount; j = num2)
					{
						this.dataGridView2.Rows.Add(1);
						num2 = j + 1;
						this.dataGridView2.Rows[j].Cells[0].Value = System.Convert.ToString(num2);
						this.dataGridView2.Rows[j].Cells[1].Value = System.Convert.ToString(this.gLineTestProcessor.mpDevComm.mParseCmd.selfTestExPointArray[j]);
					}
					this.dataGridView2.AllowUserToAddRows = false;
				}
			}
			catch (System.Exception arg_1C6_0)
			{
				this.dataGridView1.AllowUserToAddRows = false;
				this.dataGridView2.AllowUserToAddRows = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_1C6_0.StackTrace);
			}
		}
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			try
			{
				this.iTestTime++;
				KLineTestProcessor e2 = this.gLineTestProcessor;
				KParseRepCmd sender2 = e2.mpDevComm.mParseCmd;
				if (sender2.selfTestProgress != 100)
				{
					int iProc = System.Convert.ToInt32((double)sender2.selfTestDataCount * 100.0 / ((double)(this.iEndValue - this.iStartValue) + 1.0));
					if (iProc >= 100)
					{
						iProc = 99;
					}
					this.progressBar1.Value = iProc;
					this.showFunc();
				}
				else
				{
					e2.mbKeepRun = false;
					this.timer1.Enabled = false;
					this.progressBar1.Value = this.gLineTestProcessor.mpDevComm.mParseCmd.selfTestProgress;
					this.textBox_ex_count.Text = System.Convert.ToString(this.gLineTestProcessor.mpDevComm.mParseCmd.selfTestExPointCount);
					this.showFunc();
					this.StopRunDisposeFunc();
				}
			}
			catch (System.Exception arg_E3_0)
			{
				this.StopRunDisposeFunc();
				KLineTestProcessor.ExceptionRecordFunc(arg_E3_0.StackTrace);
			}
		}
		private void numericUpDown_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_start.Text.ToString();
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dTemp = System.Convert.ToDouble(tempStr);
				}
				tempStr = this.numericUpDown_stop.Text.ToString();
				if (!string.IsNullOrEmpty(tempStr))
				{
					double dTemp = System.Convert.ToDouble(tempStr);
				}
			}
			catch (System.Exception arg_42_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_42_0.StackTrace);
			}
		}
		private void ctFormSelfTest_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.bRunFlag = false;
				decimal maximum = this.gLineTestProcessor.SELF_MAX_COUNT;
				this.numericUpDown_start.Maximum = maximum;
				decimal maximum2 = this.gLineTestProcessor.SELF_MAX_COUNT;
				this.numericUpDown_stop.Maximum = maximum2;
				decimal maximum3 = this.numericUpDown_stop.Maximum;
				this.numericUpDown_stop.Value = maximum3;
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
			catch (System.Exception arg_179_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_179_0.StackTrace);
			}
		}
		private void ctFormSelfTest_SizeChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (base.WindowState != FormWindowState.Minimized)
				{
					int iw = this.dataGridView1.Width - 266;
					if (iw < 0)
					{
						iw = 0;
					}
					this.dataGridView1.Columns[0].Width = 80;
					int sender2 = iw + 162;
					this.dataGridView1.Columns[1].Width = sender2;
					this.dataGridView2.Columns[0].Width = 80;
					this.dataGridView2.Columns[1].Width = sender2;
				}
			}
			catch (System.Exception arg_8C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_8C_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormSelfTest();
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
