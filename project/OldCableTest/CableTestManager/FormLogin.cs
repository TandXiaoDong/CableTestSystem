using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class FormLogin : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public static int CHAR_MAX_LEN = 256;
		public bool bIsAdminFlag;
		public bool bLoginSuccFlag;
		public string loginUser;
		public string loginSecr;
		public string loginName;
		private Label label1;
		private Label label_login;
		private TextBox textBox_UserName;
		private TextBox textBox_Password;
		private Container components;
		public FormLogin(KLineTestProcessor gltProcessor)
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
		private void ~FormLogin()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(FormLogin));
			this.textBox_UserName = new TextBox();
			this.textBox_Password = new TextBox();
			this.label_login = new Label();
			this.label1 = new Label();
			base.SuspendLayout();
			this.textBox_UserName.BorderStyle = BorderStyle.None;
			this.textBox_UserName.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(87, 86);
			this.textBox_UserName.Location = location;
			Padding margin = new Padding(2);
			this.textBox_UserName.Margin = margin;
			this.textBox_UserName.Name = "textBox_UserName";
			System.Drawing.Size size = new System.Drawing.Size(180, 19);
			this.textBox_UserName.Size = size;
			this.textBox_UserName.TabIndex = 2;
			this.textBox_UserName.Text = "admin";
			this.textBox_UserName.TextAlign = HorizontalAlignment.Center;
			this.textBox_Password.BorderStyle = BorderStyle.None;
			this.textBox_Password.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(87, 143);
			this.textBox_Password.Location = location2;
			Padding margin2 = new Padding(2);
			this.textBox_Password.Margin = margin2;
			this.textBox_Password.Name = "textBox_Password";
			this.textBox_Password.PasswordChar = '*';
			System.Drawing.Size size2 = new System.Drawing.Size(180, 19);
			this.textBox_Password.Size = size2;
			this.textBox_Password.TabIndex = 0;
			this.textBox_Password.TextAlign = HorizontalAlignment.Center;
			this.textBox_Password.KeyPress += new KeyPressEventHandler(this.textBox_Password_KeyPress);
			this.label_login.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Color transparent = System.Drawing.Color.Transparent;
			this.label_login.BackColor = transparent;
			this.label_login.Font = new System.Drawing.Font("新宋体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(47, 194);
			this.label_login.Location = location3;
			Padding margin3 = new Padding(2, 0, 2, 0);
			this.label_login.Margin = margin3;
			this.label_login.Name = "label_login";
			System.Drawing.Size size3 = new System.Drawing.Size(267, 28);
			this.label_login.Size = size3;
			this.label_login.TabIndex = 1;
			this.label_login.Text = "登  录";
			this.label_login.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label_login.Click += new System.EventHandler(this.label_login_Click);
			this.label1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			System.Drawing.Color backColor = System.Drawing.Color.FromArgb(247, 243, 242);
			this.label1.BackColor = backColor;
			this.label1.Font = new System.Drawing.Font("宋体", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(45, 27);
			this.label1.Location = location4;
			this.label1.Name = "label1";
			System.Drawing.Size size4 = new System.Drawing.Size(270, 27);
			this.label1.Size = size4;
			this.label1.TabIndex = 3;
			this.label1.Text = "线束测试系统";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
			this.BackgroundImageLayout = ImageLayout.Stretch;
			System.Drawing.Size clientSize = new System.Drawing.Size(360, 260);
			base.ClientSize = clientSize;
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label_login);
			base.Controls.Add(this.textBox_Password);
			base.Controls.Add(this.textBox_UserName);
			this.DoubleBuffered = true;
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin4 = new Padding(2);
			base.Margin = margin4;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormLogin";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "登录";
			base.Load += new System.EventHandler(this.FormLogin_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public void LoginDisposeFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				string userStr = this.textBox_UserName.Text.ToString();
				string secrStr = this.textBox_Password.Text.ToString();
				if (!string.IsNullOrEmpty(userStr) && !string.IsNullOrEmpty(secrStr))
				{
					this.bIsAdminFlag = false;
					try
					{
						connection = new OleDbConnection();
						connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
						connection.Open();
						string arg_A4_0 = "select * from TUser where UEnabled = 1";
						if (-1 != userStr.ToUpper().LastIndexOf("ADMIN"))
						{
							arg_A4_0 = "select * from TAdmin where UEnabled = 1";
							this.bIsAdminFlag = true;
						}
						dataReader = new OleDbCommand(arg_A4_0, connection).ExecuteReader();
						while (dataReader.Read())
						{
							string uidStr = dataReader["UEID"].ToString();
							this.loginName = dataReader["UNAME"].ToString();
							string upsStr = dataReader["UPWD"].ToString();
							string uStr = KLineTestProcessor.EncrypDisposeFunc(userStr);
							string sStr = KLineTestProcessor.EncrypDisposeFunc(secrStr);
							if (uStr == uidStr && sStr == upsStr)
							{
								this.bLoginSuccFlag = true;
								this.loginUser = userStr;
								this.loginSecr = secrStr;
								break;
							}
						}
						dataReader.Close();
						connection.Close();
						dataReader = null;
						connection = null;
					}
					catch (System.Exception arg_15E_0)
					{
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
						KLineTestProcessor.ExceptionRecordFunc(arg_15E_0.StackTrace);
						goto IL_19C;
					}
					if (!this.bLoginSuccFlag)
					{
						MessageBox.Show("用户名或密码错误!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						string contStr = "登录系统";
						this.saveOperationRecord(contStr);
						base.Close();
					}
					IL_19C:;
				}
				else
				{
					MessageBox.Show("用户名或密码错误!", "提示", MessageBoxButtons.OK);
				}
			}
			catch (System.Exception arg_1B1_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1B1_0.StackTrace);
			}
		}
		public void saveOperationRecord(string operContentStr)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			bool bExistRecord = true;
			System.ValueType dt = System.DateTime.Now;
			try
			{
				connection = new OleDbConnection();
				connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
				connection.Open();
				string sqlcommand;
				OleDbCommand cmd;
				try
				{
					sqlcommand = "select count(*) as num from TLoginRecord where LoginUser='" + this.loginUser + "'";
					cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						string tempStr = dataReader["num"].ToString();
						if (!string.IsNullOrEmpty(tempStr) && System.Convert.ToInt32(tempStr) <= 0)
						{
							bExistRecord = false;
						}
					}
					dataReader.Close();
					dataReader = null;
				}
				catch (System.Exception arg_94_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_94_0.StackTrace);
					if (dataReader != null)
					{
						dataReader.Close();
						dataReader = null;
					}
				}
				try
				{
					if (bExistRecord)
					{
						sqlcommand = "delete from TLoginRecord where LoginUser='" + this.loginUser + "'";
						cmd = new OleDbCommand(sqlcommand, connection);
						cmd.ExecuteNonQuery();
					}
				}
				catch (System.Exception arg_DC_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_DC_0.StackTrace);
				}
				sqlcommand = "insert into TLoginRecord(LoginUser,LoginDate,LoginTime,LoginState) values('" + this.loginUser + "','" + ((System.DateTime)dt).ToShortDateString() + "','" + ((System.DateTime)dt).ToLongTimeString() + "',1)";
				cmd = new OleDbCommand(sqlcommand, connection);
				cmd.ExecuteNonQuery();
				sqlcommand = "insert into TOperationRecord(UEID,OperationTime,OperationContent,TestRecordID,Explain) " + "values('" + this.loginUser + "',#" + dt + "#,'" + operContentStr + "','','')";
				cmd = new OleDbCommand(sqlcommand, connection);
				cmd.ExecuteNonQuery();
				connection.Close();
				connection = null;
			}
			catch (System.Exception arg_1A7_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1A7_0.StackTrace);
				if (dataReader != null)
				{
					dataReader.Close();
				}
				if (connection != null)
				{
					connection.Close();
				}
			}
		}
		private void FormLogin_Load(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.loginUser = "";
				this.loginSecr = "";
				this.loginName = "";
				this.bIsAdminFlag = false;
				this.bLoginSuccFlag = false;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select top 1 * from TLoginRecord order by ID desc", connection).ExecuteReader();
					if (dataReader.Read())
					{
						string tempStr = dataReader["LoginUser"].ToString();
						if (!string.IsNullOrEmpty(tempStr))
						{
							this.textBox_UserName.Text = tempStr;
						}
					}
					dataReader.Close();
					connection.Close();
					dataReader = null;
					connection = null;
				}
				catch (System.Exception arg_BC_0)
				{
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
					KLineTestProcessor.ExceptionRecordFunc(arg_BC_0.StackTrace);
				}
				this.textBox_Password.Focus();
			}
			catch (System.Exception ex_D6)
			{
			}
		}
		private void textBox_Password_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.LoginDisposeFunc();
				}
			}
			catch (System.Exception ex_12)
			{
			}
		}
		private void label_login_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.LoginDisposeFunc();
			}
			catch (System.Exception ex_08)
			{
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~FormLogin();
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
