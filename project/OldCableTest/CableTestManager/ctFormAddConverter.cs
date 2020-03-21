using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormAddConverter : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public string loginUser;
		public string dbpath;
		public bool bAddSuccFlag;
		private TextBox textBox_name;
		private Label label3;
		private TextBox textBox_ConverterType;
		private Button btnSubmit;
		private Button btnQuit;
		private Label label1;
		private TextBox textBox_Remark;
		private Label label2;
		private Container components;
		public ctFormAddConverter(KLineTestProcessor gltProcessor, string lUser)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = lUser;
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
		private void ~ctFormAddConverter()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormAddConverter));
			this.textBox_name = new TextBox();
			this.btnSubmit = new Button();
			this.btnQuit = new Button();
			this.label1 = new Label();
			this.textBox_Remark = new TextBox();
			this.label2 = new Label();
			this.label3 = new Label();
			this.textBox_ConverterType = new TextBox();
			base.SuspendLayout();
			this.textBox_name.Anchor = AnchorStyles.Top;
			this.textBox_name.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(144, 22);
			this.textBox_name.Location = location;
			Padding margin = new Padding(2);
			this.textBox_name.Margin = margin;
			this.textBox_name.MaxLength = 120;
			this.textBox_name.Name = "textBox_name";
			System.Drawing.Size size = new System.Drawing.Size(400, 24);
			this.textBox_name.Size = size;
			this.textBox_name.TabIndex = 3;
			this.btnSubmit.Anchor = AnchorStyles.Bottom;
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(144, 198);
			this.btnSubmit.Location = location2;
			Padding margin2 = new Padding(2);
			this.btnSubmit.Margin = margin2;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size2 = new System.Drawing.Size(120, 24);
			this.btnSubmit.Size = size2;
			this.btnSubmit.TabIndex = 0;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(336, 198);
			this.btnQuit.Location = location3;
			Padding margin3 = new Padding(2);
			this.btnQuit.Margin = margin3;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size3 = new System.Drawing.Size(120, 24);
			this.btnQuit.Size = size3;
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.label1.Anchor = AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(30, 27);
			this.label1.Location = location4;
			Padding margin4 = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin4;
			this.label1.Name = "label1";
			System.Drawing.Size size4 = new System.Drawing.Size(105, 15);
			this.label1.Size = size4;
			this.label1.TabIndex = 2;
			this.label1.Text = "转接工装代号:";
			this.textBox_Remark.Anchor = AnchorStyles.Top;
			this.textBox_Remark.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(144, 96);
			this.textBox_Remark.Location = location5;
			Padding margin5 = new Padding(2);
			this.textBox_Remark.Margin = margin5;
			this.textBox_Remark.MaxLength = 120;
			this.textBox_Remark.Name = "textBox_Remark";
			System.Drawing.Size size5 = new System.Drawing.Size(400, 24);
			this.textBox_Remark.Size = size5;
			this.textBox_Remark.TabIndex = 7;
			this.label2.Anchor = AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(90, 101);
			this.label2.Location = location6;
			Padding margin6 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin6;
			this.label2.Name = "label2";
			System.Drawing.Size size6 = new System.Drawing.Size(45, 15);
			this.label2.Size = size6;
			this.label2.TabIndex = 6;
			this.label2.Text = "备注:";
			this.label3.Anchor = AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(60, 64);
			this.label3.Location = location7;
			Padding margin7 = new Padding(2, 0, 2, 0);
			this.label3.Margin = margin7;
			this.label3.Name = "label3";
			System.Drawing.Size size7 = new System.Drawing.Size(75, 15);
			this.label3.Size = size7;
			this.label3.TabIndex = 4;
			this.label3.Text = "转接型号:";
			this.textBox_ConverterType.Anchor = AnchorStyles.Top;
			this.textBox_ConverterType.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(144, 59);
			this.textBox_ConverterType.Location = location8;
			Padding margin8 = new Padding(2);
			this.textBox_ConverterType.Margin = margin8;
			this.textBox_ConverterType.MaxLength = 120;
			this.textBox_ConverterType.Name = "textBox_ConverterType";
			System.Drawing.Size size8 = new System.Drawing.Size(400, 24);
			this.textBox_ConverterType.Size = size8;
			this.textBox_ConverterType.TabIndex = 5;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(594, 271);
			base.ClientSize = clientSize;
			base.Controls.Add(this.textBox_ConverterType);
			base.Controls.Add(this.textBox_name);
			base.Controls.Add(this.btnSubmit);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.textBox_Remark);
			base.Controls.Add(this.label2);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding this2 = new Padding(2);
			base.Margin = this2;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormAddConverter";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "添加转接工装";
			base.Load += new System.EventHandler(this.ctFormAddConverter_Load);
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
				string zjlbhStr = this.textBox_name.Text.ToString().Trim();
				if (string.IsNullOrEmpty(zjlbhStr))
				{
					MessageBox.Show("转接工装代号为空!", "提示", MessageBoxButtons.OK);
					return;
				}
				string converterTypeStr = this.textBox_ConverterType.Text.ToString().Trim();
				if (string.IsNullOrEmpty(converterTypeStr))
				{
					MessageBox.Show("转接型号为空!", "提示", MessageBoxButtons.OK);
					return;
				}
				string remarkStr = this.textBox_Remark.Text.ToString();
				bool bExsitFlag = false;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "select top 1 * from TConverterLibrary where ConverterName = '" + zjlbhStr + "'";
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					OleDbDataReader dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						bExsitFlag = true;
					}
					dataReader.Close();
					if (!bExsitFlag)
					{
						string str = "','";
						sqlcommand = "insert into TConverterLibrary(ConverterName,ConverterType,Remark) values('" + zjlbhStr + str + converterTypeStr + str + remarkStr + "')";
						cmd = new OleDbCommand(sqlcommand, connection);
						cmd.ExecuteNonQuery();
					}
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_137_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_137_0.StackTrace);
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
					MessageBox.Show("数据库访问异常!", "提示", MessageBoxButtons.OK);
					base.Close();
					goto IL_17E;
				}
				if (!bExsitFlag)
				{
					goto IL_1A3;
				}
				MessageBox.Show("转接工装已存在!", "提示", MessageBoxButtons.OK);
				IL_17E:
				return;
			}
			catch (System.Exception arg_180_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_180_0.StackTrace);
				MessageBox.Show("存在未知异常!", "提示", MessageBoxButtons.OK);
				base.Close();
				return;
			}
			IL_1A3:
			MessageBox.Show("操作成功!", "提示", MessageBoxButtons.OK);
			this.bAddSuccFlag = true;
			base.Close();
		}
		private void ctFormAddConverter_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.textBox_name.Text = "";
				this.textBox_ConverterType.Text = "";
				this.textBox_Remark.Text = "";
				this.bAddSuccFlag = false;
			}
			catch (System.Exception arg_39_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_39_0.StackTrace);
			}
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode == 0)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
			catch (System.Exception arg_5C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5C_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormAddConverter();
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
