using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormEnvironmentParaSet : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public string loginUser;
		public bool bTJFlag;
		public bool bExistFlag;
		public string hjwdStr;
		public string hjsdStr;
		public string dbpath;
		private Button btnSubmit;
		private Button btnQuit;
		private Label label1;
		private Label label2;
		private TextBox textBox_wd;
		private TextBox textBox_sd;
		private Label label3;
		private Label label4;
		private Container components;
		public ctFormEnvironmentParaSet(KLineTestProcessor gltProcessor, string lUser)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsmddb.mdb";
					this.loginUser = lUser;
					this.gLineTestProcessor = gltProcessor;
				}
				catch (System.Exception arg_31_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_31_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormEnvironmentParaSet()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormEnvironmentParaSet));
			this.btnSubmit = new Button();
			this.btnQuit = new Button();
			this.label1 = new Label();
			this.label2 = new Label();
			this.textBox_wd = new TextBox();
			this.textBox_sd = new TextBox();
			this.label3 = new Label();
			this.label4 = new Label();
			base.SuspendLayout();
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(131, 179);
			this.btnSubmit.Location = location;
			Padding margin = new Padding(2, 2, 2, 2);
			this.btnSubmit.Margin = margin;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size = new System.Drawing.Size(90, 24);
			this.btnSubmit.Size = size;
			this.btnSubmit.TabIndex = 0;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(253, 179);
			this.btnQuit.Location = location2;
			Padding margin2 = new Padding(2, 2, 2, 2);
			this.btnQuit.Margin = margin2;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size2 = new System.Drawing.Size(90, 24);
			this.btnQuit.Size = size2;
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(42, 49);
			this.label1.Location = location3;
			Padding margin3 = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin3;
			this.label1.Name = "label1";
			System.Drawing.Size size3 = new System.Drawing.Size(75, 15);
			this.label1.Size = size3;
			this.label1.TabIndex = 1;
			this.label1.Text = "环境温度:";
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(42, 97);
			this.label2.Location = location4;
			Padding margin4 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin4;
			this.label2.Name = "label2";
			System.Drawing.Size size4 = new System.Drawing.Size(75, 15);
			this.label2.Size = size4;
			this.label2.TabIndex = 1;
			this.label2.Text = "环境湿度:";
			this.textBox_wd.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(121, 45);
			this.textBox_wd.Location = location5;
			Padding margin5 = new Padding(2, 2, 2, 2);
			this.textBox_wd.Margin = margin5;
			this.textBox_wd.Name = "textBox_wd";
			System.Drawing.Size size5 = new System.Drawing.Size(143, 24);
			this.textBox_wd.Size = size5;
			this.textBox_wd.TabIndex = 2;
			this.textBox_wd.TextAlign = HorizontalAlignment.Center;
			this.textBox_wd.KeyPress += new KeyPressEventHandler(this.textBox_wd_KeyPress);
			this.textBox_sd.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(121, 93);
			this.textBox_sd.Location = location6;
			Padding margin6 = new Padding(2, 2, 2, 2);
			this.textBox_sd.Margin = margin6;
			this.textBox_sd.Name = "textBox_sd";
			System.Drawing.Size size6 = new System.Drawing.Size(143, 24);
			this.textBox_sd.Size = size6;
			this.textBox_sd.TabIndex = 3;
			this.textBox_sd.TextAlign = HorizontalAlignment.Center;
			this.textBox_sd.KeyPress += new KeyPressEventHandler(this.textBox_wd_KeyPress);
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(267, 49);
			this.label3.Location = location7;
			Padding margin7 = new Padding(2, 0, 2, 0);
			this.label3.Margin = margin7;
			this.label3.Name = "label3";
			System.Drawing.Size size7 = new System.Drawing.Size(169, 15);
			this.label3.Size = size7;
			this.label3.TabIndex = 1;
			this.label3.Text = "℃ (取值范围: 0~50℃)";
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(266, 97);
			this.label4.Location = location8;
			Padding margin8 = new Padding(2, 0, 2, 0);
			this.label4.Margin = margin8;
			this.label4.Name = "label4";
			System.Drawing.Size size8 = new System.Drawing.Size(179, 15);
			this.label4.Size = size8;
			this.label4.TabIndex = 1;
			this.label4.Text = "%  (取值范围: 20~85 %)";
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(474, 241);
			base.ClientSize = clientSize;
			base.Controls.Add(this.textBox_sd);
			base.Controls.Add(this.textBox_wd);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnSubmit);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding this2 = new Padding(2, 2, 2, 2);
			base.Margin = this2;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormEnvironmentParaSet";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "试验环境参数设置";
			base.Load += new System.EventHandler(this.ctFormEnvironmentParaSet_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
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
				string temp1Str = this.textBox_wd.Text.ToString().Trim();
				string temp2Str = this.textBox_sd.Text.ToString().Trim();
				if (string.IsNullOrEmpty(temp1Str) || string.IsNullOrEmpty(temp2Str))
				{
					MessageBox.Show("输入信息不完整，请重新填写!", "提示", MessageBoxButtons.OK);
					return;
				}
				int iTemp1Value = System.Convert.ToInt32(temp1Str);
				int iTemp2Value = System.Convert.ToInt32(temp2Str);
				if (iTemp1Value > 50 || iTemp2Value - 20 > 65)
				{
					MessageBox.Show("输入信息不合法，请注意取值范围!", "提示", MessageBoxButtons.OK);
					return;
				}
				this.hjwdStr = System.Convert.ToString(iTemp1Value) + " ℃";
				this.hjsdStr = System.Convert.ToString(iTemp2Value) + " %";
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					new OleDbCommand("update TTestEnvironmentPara set EnvironmentTemperature='" + this.hjwdStr + "',AmbientHumidity='" + this.hjsdStr + "'", connection).ExecuteNonQuery();
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_F6_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_F6_0.StackTrace);
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
				}
			}
			catch (System.Exception arg_135_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_135_0.StackTrace);
			}
			this.bTJFlag = true;
			base.Close();
		}
		private void ctFormEnvironmentParaSet_Load(object sender, System.EventArgs e)
		{
			this.bTJFlag = false;
			this.hjwdStr = "";
			this.hjsdStr = "";
			this.bExistFlag = false;
		}
		private void textBox_wd_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '\b')
			{
				e.Handled = false;
			}
			else
			{
				e.Handled = true;
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormEnvironmentParaSet();
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
