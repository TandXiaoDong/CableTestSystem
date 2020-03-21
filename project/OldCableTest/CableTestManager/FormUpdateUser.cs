using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class FormUpdateUser : Form
	{
		public string userStr;
		public string loginUser;
		public KLineTestProcessor gLineTestProcessor;
		private Button btn_submit;
		private Button btnQuit;
		private TextBox textBox_name;
		private Label label3;
		private TextBox textBox_psw;
		private Label label2;
		private TextBox textBox_user;
		private Label label1;
		private Label label5;
		private Container components;
		public FormUpdateUser(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = "";
					this.userStr = "";
				}
				catch (System.Exception arg_2B_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_2B_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		public FormUpdateUser(KLineTestProcessor gltProcessor, string _loginUser, string _userStr)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = _loginUser;
					this.userStr = _userStr;
				}
				catch (System.Exception arg_23_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_23_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~FormUpdateUser()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(FormUpdateUser));
			this.btn_submit = new Button();
			this.btnQuit = new Button();
			this.textBox_name = new TextBox();
			this.label3 = new Label();
			this.textBox_psw = new TextBox();
			this.label2 = new Label();
			this.textBox_user = new TextBox();
			this.label1 = new Label();
			this.label5 = new Label();
			base.SuspendLayout();
			this.btn_submit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(157, 299);
			this.btn_submit.Location = location;
			this.btn_submit.Name = "btn_submit";
			System.Drawing.Size size = new System.Drawing.Size(100, 30);
			this.btn_submit.Size = size;
			this.btn_submit.TabIndex = 13;
			this.btn_submit.Text = "确定";
			this.btn_submit.UseVisualStyleBackColor = true;
			this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(337, 299);
			this.btnQuit.Location = location2;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size2 = new System.Drawing.Size(100, 30);
			this.btnQuit.Size = size2;
			this.btnQuit.TabIndex = 14;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.textBox_name.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(157, 178);
			this.textBox_name.Location = location3;
			this.textBox_name.MaxLength = 32;
			this.textBox_name.Name = "textBox_name";
			System.Drawing.Size size3 = new System.Drawing.Size(280, 28);
			this.textBox_name.Size = size3;
			this.textBox_name.TabIndex = 11;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(87, 183);
			this.label3.Location = location4;
			this.label3.Name = "label3";
			System.Drawing.Size size4 = new System.Drawing.Size(57, 19);
			this.label3.Size = size4;
			this.label3.TabIndex = 5;
			this.label3.Text = "姓名:";
			this.textBox_psw.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(157, 88);
			this.textBox_psw.Location = location5;
			this.textBox_psw.MaxLength = 32;
			this.textBox_psw.Name = "textBox_psw";
			this.textBox_psw.PasswordChar = '*';
			System.Drawing.Size size5 = new System.Drawing.Size(280, 28);
			this.textBox_psw.Size = size5;
			this.textBox_psw.TabIndex = 10;
			this.textBox_psw.KeyPress += new KeyPressEventHandler(this.textBox_psw_KeyPress);
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(87, 93);
			this.label2.Location = location6;
			this.label2.Name = "label2";
			System.Drawing.Size size6 = new System.Drawing.Size(57, 19);
			this.label2.Size = size6;
			this.label2.TabIndex = 8;
			this.label2.Text = "密码:";
			this.textBox_user.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(157, 38);
			this.textBox_user.Location = location7;
			this.textBox_user.MaxLength = 32;
			this.textBox_user.Name = "textBox_user";
			this.textBox_user.ReadOnly = true;
			System.Drawing.Size size7 = new System.Drawing.Size(280, 28);
			this.textBox_user.Size = size7;
			this.textBox_user.TabIndex = 7;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(87, 43);
			this.label1.Location = location8;
			this.label1.Name = "label1";
			System.Drawing.Size size8 = new System.Drawing.Size(57, 19);
			this.label1.Size = size8;
			this.label1.TabIndex = 6;
			this.label1.Text = "账号:";
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Color menuText = System.Drawing.SystemColors.MenuText;
			this.label5.ForeColor = menuText;
			System.Drawing.Point location9 = new System.Drawing.Point(157, 135);
			this.label5.Location = location9;
			this.label5.Name = "label5";
			System.Drawing.Size size9 = new System.Drawing.Size(288, 15);
			this.label5.Size = size9;
			this.label5.TabIndex = 15;
			this.label5.Text = "注: 密码为6～16个字符(英文字母或数字)";
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size this2 = new System.Drawing.Size(554, 415);
			base.ClientSize = this2;
			base.Controls.Add(this.label5);
			base.Controls.Add(this.btn_submit);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.textBox_name);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.textBox_psw);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.textBox_user);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormUpdateUser";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "修改用户";
			base.Load += new System.EventHandler(this.FormUpdateUser_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public void saveOperationRecord(string operContentStr)
		{
			OleDbConnection connection = null;
			System.ValueType dt = System.DateTime.Now;
			try
			{
				connection = new OleDbConnection();
				connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
				connection.Open();
				new OleDbCommand("insert into TOperationRecord(UEID,OperationTime,OperationContent,TestRecordID,Explain) " + "values('" + this.loginUser + "',#" + dt + "#,'" + operContentStr + "','','')", connection).ExecuteNonQuery();
				connection.Close();
				connection = null;
			}
			catch (System.Exception arg_8D_0)
			{
				if (connection != null)
				{
					connection.Close();
				}
				KLineTestProcessor.ExceptionRecordFunc(arg_8D_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool UpdateUserDealwithFun(string uStr, string sStr, string nStr)
		{
			OleDbConnection connection = null;
			bool uStr2;
			try
			{
				connection = new OleDbConnection();
				connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
				connection.Open();
				new OleDbCommand("update TUser set UNAME='" + nStr + "',UPWD='" + sStr + "' where UEID='" + uStr + "' and UEnabled = 1", connection).ExecuteNonQuery();
				connection.Close();
				connection = null;
				return true;
			}
			catch (System.Exception arg_75_0)
			{
				if (connection != null)
				{
					connection.Close();
				}
				KLineTestProcessor.ExceptionRecordFunc(arg_75_0.StackTrace);
				uStr2 = false;
			}
			return uStr2;
		}
		private void btn_submit_Click(object sender, System.EventArgs e)
		{
			try
			{
				string secrStr = this.textBox_psw.Text.ToString().Trim();
				if (string.IsNullOrEmpty(secrStr))
				{
					MessageBox.Show("密码为空!", "提示", MessageBoxButtons.OK);
				}
				else if (6 <= secrStr.Length && 16 >= secrStr.Length)
				{
					string nameStr = this.textBox_name.Text.ToString().Trim();
					if (string.IsNullOrEmpty(nameStr))
					{
						MessageBox.Show("姓名为空!", "提示", MessageBoxButtons.OK);
					}
					else
					{
						string contStr = "更新用户<" + this.userStr + ">账户信息";
						string uStr = KLineTestProcessor.EncrypDisposeFunc(this.userStr);
						string sStr = KLineTestProcessor.EncrypDisposeFunc(secrStr);
						if (this.UpdateUserDealwithFun(uStr, sStr, nameStr))
						{
							this.saveOperationRecord(contStr);
							MessageBox.Show("更新成功!", "提示", MessageBoxButtons.OK);
							base.Close();
						}
					}
				}
				else
				{
					MessageBox.Show("密码为6～16个字符(英文字母或数字)", "提示", MessageBoxButtons.OK);
				}
			}
			catch (System.Exception arg_F6_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_F6_0.StackTrace);
			}
		}
		private void FormUpdateUser_Load(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.textBox_user.Text = this.userStr;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select * from TUser where UEnabled=1 and UEID='" + KLineTestProcessor.EncrypDisposeFunc(this.userStr) + "'", connection).ExecuteReader();
					if (dataReader.Read())
					{
						this.textBox_name.Text = dataReader["UNAME"].ToString();
						string tempStr = dataReader["UPWD"].ToString();
						this.textBox_psw.Text = KLineTestProcessor.DecodeDisposeFunc(tempStr);
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_BA_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_BA_0.StackTrace);
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
			catch (System.Exception arg_E0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_E0_0.StackTrace);
			}
		}
		private void textBox_psw_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || e.KeyChar == '\b')
			{
				e.Handled = false;
			}
			else
			{
				e.Handled = true;
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
					this.~FormUpdateUser();
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
