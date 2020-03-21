using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class FormUpdateSecret : Form
	{
		public string loginUser;
		public string loginSecr;
		public string dbloginUserStr;
		public int _loginUserLevel;
		public bool updateSuccFlag;
		public KLineTestProcessor gLineTestProcessor;
		private Label label1;
		private TextBox textBox_oldpsw;
		private Label label_user;
		private Label label3;
		private Label label4;
		private Label label5;
		private TextBox textBox_newpsw;
		private TextBox textBox_renewpsw;
		private Button btnQuit;
		private Button btn_submit;
		private Label label2;
		private Container components;
		public FormUpdateSecret(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.gLineTestProcessor = gltProcessor;
					this.loginUser = gltProcessor.loginUserID;
					this.loginSecr = gltProcessor.loginUserPsw;
					this._loginUserLevel = 0;
					this.dbloginUserStr = "";
				}
				catch (System.Exception arg_3F_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_3F_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~FormUpdateSecret()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(FormUpdateSecret));
			this.label1 = new Label();
			this.textBox_oldpsw = new TextBox();
			this.label_user = new Label();
			this.label3 = new Label();
			this.label4 = new Label();
			this.label5 = new Label();
			this.textBox_newpsw = new TextBox();
			this.textBox_renewpsw = new TextBox();
			this.btnQuit = new Button();
			this.btn_submit = new Button();
			this.label2 = new Label();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(68, 42);
			this.label1.Location = location;
			this.label1.Name = "label1";
			System.Drawing.Size size = new System.Drawing.Size(95, 19);
			this.label1.Size = size;
			this.label1.TabIndex = 6;
			this.label1.Text = "登录账号:";
			this.textBox_oldpsw.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(178, 82);
			this.textBox_oldpsw.Location = location2;
			this.textBox_oldpsw.MaxLength = 32;
			this.textBox_oldpsw.Name = "textBox_oldpsw";
			this.textBox_oldpsw.PasswordChar = '*';
			System.Drawing.Size size2 = new System.Drawing.Size(280, 28);
			this.textBox_oldpsw.Size = size2;
			this.textBox_oldpsw.TabIndex = 0;
			this.textBox_oldpsw.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
			this.label_user.AutoSize = true;
			this.label_user.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(178, 42);
			this.label_user.Location = location3;
			this.label_user.Name = "label_user";
			System.Drawing.Size size3 = new System.Drawing.Size(59, 19);
			this.label_user.Size = size3;
			this.label_user.TabIndex = 5;
			this.label_user.Text = "admin";
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(67, 87);
			this.label3.Location = location4;
			this.label3.Name = "label3";
			System.Drawing.Size size4 = new System.Drawing.Size(105, 19);
			this.label3.Size = size4;
			this.label3.TabIndex = 7;
			this.label3.Text = "旧 密 码：";
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(67, 132);
			this.label4.Location = location5;
			this.label4.Name = "label4";
			System.Drawing.Size size5 = new System.Drawing.Size(105, 19);
			this.label4.Size = size5;
			this.label4.TabIndex = 8;
			this.label4.Text = "新 密 码：";
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(49, 222);
			this.label5.Location = location6;
			this.label5.Name = "label5";
			System.Drawing.Size size6 = new System.Drawing.Size(123, 19);
			this.label5.Size = size6;
			this.label5.TabIndex = 9;
			this.label5.Text = "新密码确认：";
			this.textBox_newpsw.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(178, 127);
			this.textBox_newpsw.Location = location7;
			this.textBox_newpsw.MaxLength = 32;
			this.textBox_newpsw.Name = "textBox_newpsw";
			this.textBox_newpsw.PasswordChar = '*';
			System.Drawing.Size size7 = new System.Drawing.Size(280, 28);
			this.textBox_newpsw.Size = size7;
			this.textBox_newpsw.TabIndex = 1;
			this.textBox_newpsw.KeyPress += new KeyPressEventHandler(this.textBox_KeyPress);
			this.textBox_renewpsw.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(178, 217);
			this.textBox_renewpsw.Location = location8;
			this.textBox_renewpsw.MaxLength = 32;
			this.textBox_renewpsw.Name = "textBox_renewpsw";
			this.textBox_renewpsw.PasswordChar = '*';
			System.Drawing.Size size8 = new System.Drawing.Size(280, 28);
			this.textBox_renewpsw.Size = size8;
			this.textBox_renewpsw.TabIndex = 2;
			this.textBox_renewpsw.KeyPress += new KeyPressEventHandler(this.textBox_renewpsw_KeyPress);
			this.btnQuit.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(358, 310);
			this.btnQuit.Location = location9;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size9 = new System.Drawing.Size(100, 30);
			this.btnQuit.Size = size9;
			this.btnQuit.TabIndex = 4;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btn_submit.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.btn_submit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location10 = new System.Drawing.Point(178, 310);
			this.btn_submit.Location = location10;
			this.btn_submit.Name = "btn_submit";
			System.Drawing.Size size10 = new System.Drawing.Size(100, 30);
			this.btn_submit.Size = size10;
			this.btn_submit.TabIndex = 3;
			this.btn_submit.Text = "确定";
			this.btn_submit.UseVisualStyleBackColor = true;
			this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Color menuText = System.Drawing.SystemColors.MenuText;
			this.label2.ForeColor = menuText;
			System.Drawing.Point location11 = new System.Drawing.Point(178, 170);
			this.label2.Location = location11;
			this.label2.Name = "label2";
			System.Drawing.Size size11 = new System.Drawing.Size(288, 15);
			this.label2.Size = size11;
			this.label2.TabIndex = 11;
			this.label2.Text = "注: 密码为6～16个字符(英文字母或数字)";
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size this2 = new System.Drawing.Size(554, 415);
			base.ClientSize = this2;
			base.Controls.Add(this.label2);
			base.Controls.Add(this.btn_submit);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label_user);
			base.Controls.Add(this.textBox_renewpsw);
			base.Controls.Add(this.textBox_newpsw);
			base.Controls.Add(this.textBox_oldpsw);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormUpdateSecret";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "密码修改";
			base.Load += new System.EventHandler(this.FormUpdateSecret_Load);
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
		private void textBox_KeyPress(object sender, KeyPressEventArgs e)
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
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool UpdatePSWDealwithFunc(string oldSecret, string newSecret)
		{
			OleDbConnection connection = null;
			bool oldSecret2;
			try
			{
				this._loginUserLevel = 0;
				if (-1 != this.loginUser.ToUpper().LastIndexOf("ADMIN"))
				{
					this._loginUserLevel = 1;
				}
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string arg_A5_0 = "update TUser set UPWD='" + newSecret + "' where UEID = '" + this.dbloginUserStr + "'";
					if (this._loginUserLevel == 1)
					{
						arg_A5_0 = "update TAdmin set UPWD='" + newSecret + "' where UEID = '" + this.dbloginUserStr + "'";
					}
					new OleDbCommand(arg_A5_0, connection).ExecuteNonQuery();
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_C5_0)
				{
					if (connection != null)
					{
						connection.Close();
						connection = null;
					}
					KLineTestProcessor.ExceptionRecordFunc(arg_C5_0.StackTrace);
				}
				return true;
			}
			catch (System.Exception arg_D5_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_D5_0.StackTrace);
				oldSecret2 = false;
			}
			return oldSecret2;
		}
		private void btn_submit_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.dbloginUserStr = this.label_user.Text.ToString().Trim();
				string oldSecret = this.textBox_oldpsw.Text.ToString().Trim();
				string newSecret = this.textBox_newpsw.Text.ToString().Trim();
				string renewSecret = this.textBox_renewpsw.Text.ToString().Trim();
				if (string.IsNullOrEmpty(oldSecret))
				{
					MessageBox.Show("请输入旧密码!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else if (string.IsNullOrEmpty(newSecret))
				{
					MessageBox.Show("请输入新密码!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else if (string.IsNullOrEmpty(renewSecret))
				{
					MessageBox.Show("请再次输入新密码!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else if (oldSecret == newSecret)
				{
					MessageBox.Show("新密码和旧密码相同!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else if (6 <= oldSecret.Length && 16 >= oldSecret.Length && !(this.loginSecr != oldSecret))
				{
					if (6 <= newSecret.Length && 16 >= newSecret.Length)
					{
						if (newSecret != renewSecret)
						{
							MessageBox.Show("两次输入的新密码不一致!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						else
						{
							string contStr = "修改用户<" + this.loginUser + ">登录密码";
							oldSecret = KLineTestProcessor.EncrypDisposeFunc(oldSecret);
							newSecret = KLineTestProcessor.EncrypDisposeFunc(newSecret);
							this.dbloginUserStr = KLineTestProcessor.EncrypDisposeFunc(this.dbloginUserStr);
							if (this.UpdatePSWDealwithFunc(oldSecret, newSecret))
							{
								this.updateSuccFlag = true;
								this.saveOperationRecord(contStr);
								MessageBox.Show("密码修改成功!", "提示", MessageBoxButtons.OK);
								base.Close();
							}
							else
							{
								MessageBox.Show("密码修改失败!", "提示", MessageBoxButtons.OK);
							}
						}
					}
					else
					{
						MessageBox.Show("请输入6~16位新密码!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				else
				{
					MessageBox.Show("旧密码错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (System.Exception ex)
			{
				MessageBox.Show("密码修改失败!" + ex.Message);
			}
		}
		private void FormUpdateSecret_Load(object sender, System.EventArgs e)
		{
			this.label_user.Text = this.loginUser;
			this.updateSuccFlag = false;
		}
		private void textBox_renewpsw_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar < 'A' || e.KeyChar > 'Z') && (e.KeyChar < 'a' || e.KeyChar > 'z') && e.KeyChar != '\b' && e.KeyChar != '\r')
				{
					e.Handled = true;
				}
				else
				{
					e.Handled = false;
				}
				if (e.KeyChar == '\r')
				{
					this.btn_submit_Click(null, null);
				}
			}
			catch (System.Exception arg_73_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_73_0.StackTrace);
			}
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			this.updateSuccFlag = false;
			base.Close();
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~FormUpdateSecret();
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
