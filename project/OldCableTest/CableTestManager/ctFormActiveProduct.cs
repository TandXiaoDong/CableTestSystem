using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormActiveProduct : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public bool bRegisterSuccFlag;
		public string licFilePathStr;
		public System.ValueType endTime;
		public double dYear;
		public double dMonth;
		public double dDay;
		public double dHour;
		public double dMinute;
		public double dSecond;
		public double dMillisecond;
		private Button btnQuit;
		private Button btnActivation;
		private TextBox textBox_CDkey;
		private Label label2;
		private Label label1;
		private Container components;
		public ctFormActiveProduct(string licFilePath, System.ValueType currentEndTime)
		{
			try
			{
				this.InitializeComponent();
				this.licFilePathStr = licFilePath;
				this.endTime = currentEndTime;
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormActiveProduct()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormActiveProduct));
			this.btnQuit = new Button();
			this.btnActivation = new Button();
			this.textBox_CDkey = new TextBox();
			this.label2 = new Label();
			this.label1 = new Label();
			base.SuspendLayout();
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(226, 168);
			this.btnQuit.Location = location;
			Padding margin = new Padding(2, 2, 2, 2);
			this.btnQuit.Margin = margin;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size = new System.Drawing.Size(90, 24);
			this.btnQuit.Size = size;
			this.btnQuit.TabIndex = 11;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btnActivation.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(97, 168);
			this.btnActivation.Location = location2;
			Padding margin2 = new Padding(2, 2, 2, 2);
			this.btnActivation.Margin = margin2;
			this.btnActivation.Name = "btnActivation";
			System.Drawing.Size size2 = new System.Drawing.Size(90, 24);
			this.btnActivation.Size = size2;
			this.btnActivation.TabIndex = 9;
			this.btnActivation.Text = "激活";
			this.btnActivation.UseVisualStyleBackColor = true;
			this.btnActivation.Click += new System.EventHandler(this.btnActivation_Click);
			this.textBox_CDkey.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Color controlDark = System.Drawing.SystemColors.ControlDark;
			this.textBox_CDkey.ForeColor = controlDark;
			System.Drawing.Point location3 = new System.Drawing.Point(129, 95);
			this.textBox_CDkey.Location = location3;
			Padding margin3 = new Padding(2, 2, 2, 2);
			this.textBox_CDkey.Margin = margin3;
			this.textBox_CDkey.MaxLength = 32;
			this.textBox_CDkey.Name = "textBox_CDkey";
			System.Drawing.Size size3 = new System.Drawing.Size(226, 24);
			this.textBox_CDkey.Size = size3;
			this.textBox_CDkey.TabIndex = 10;
			this.textBox_CDkey.Text = "请输入20位激活码";
			this.textBox_CDkey.MouseClick += new MouseEventHandler(this.textBox_CDkey_MouseClick);
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(59, 99);
			this.label2.Location = location4;
			Padding margin4 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin4;
			this.label2.Name = "label2";
			System.Drawing.Size size4 = new System.Drawing.Size(60, 15);
			this.label2.Size = size4;
			this.label2.TabIndex = 12;
			this.label2.Text = "激活码:";
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(78, 35);
			this.label1.Location = location5;
			Padding margin5 = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin5;
			this.label1.Name = "label1";
			System.Drawing.Size size5 = new System.Drawing.Size(270, 15);
			this.label1.Size = size5;
			this.label1.TabIndex = 8;
			this.label1.Text = "注册码已过期，请输入激活码进行激活!";
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(414, 221);
			base.ClientSize = clientSize;
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnActivation);
			base.Controls.Add(this.textBox_CDkey);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding this2 = new Padding(2, 2, 2, 2);
			base.Margin = this2;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormActiveProduct";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "产品激活窗口";
			base.Load += new System.EventHandler(this.ctFormActiveProduct_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void ctFormActiveProduct_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.bRegisterSuccFlag = false;
				this.dYear = System.Convert.ToDouble(((System.DateTime)this.endTime).Year);
				this.dMonth = System.Convert.ToDouble(((System.DateTime)this.endTime).Month);
				this.dDay = System.Convert.ToDouble(((System.DateTime)this.endTime).Day);
				this.dHour = System.Convert.ToDouble(((System.DateTime)this.endTime).Hour);
				this.dMinute = System.Convert.ToDouble(((System.DateTime)this.endTime).Minute);
				this.dSecond = System.Convert.ToDouble(((System.DateTime)this.endTime).Second);
				this.dMillisecond = System.Convert.ToDouble(((System.DateTime)this.endTime).Millisecond);
			}
			catch (System.Exception arg_C6_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_C6_0.StackTrace);
			}
		}
		public int GetIntTimeNum(string timeStr)
		{
			int iReturnValue = 0;
			try
			{
				if (string.IsNullOrEmpty(timeStr))
				{
					return 0;
				}
				int arg_21_0 = timeStr.Length;
				int iCount = 0;
				for (int i = arg_21_0 - 1; i >= 0; i--)
				{
					string tempStr = timeStr.Substring(i, 1).ToString();
					tempStr = tempStr.ToUpper();
					if (tempStr == "A")
					{
						if (iCount == 0)
						{
							iReturnValue++;
						}
						else if (iCount == 1)
						{
							iReturnValue += 10;
						}
						else if (iCount == 2)
						{
							iReturnValue += 100;
						}
						else if (iCount == 3)
						{
							iReturnValue += 1000;
						}
					}
					else if (tempStr == "B")
					{
						if (iCount == 0)
						{
							iReturnValue += 2;
						}
						else if (iCount == 1)
						{
							iReturnValue += 20;
						}
						else if (iCount == 2)
						{
							iReturnValue += 200;
						}
						else if (iCount == 3)
						{
							iReturnValue += 2000;
						}
					}
					else if (tempStr == "C")
					{
						if (iCount == 0)
						{
							iReturnValue += 3;
						}
						else if (iCount == 1)
						{
							iReturnValue += 30;
						}
						else if (iCount == 2)
						{
							iReturnValue += 300;
						}
						else if (iCount == 3)
						{
							iReturnValue += 3000;
						}
					}
					else if (tempStr == "D")
					{
						if (iCount == 0)
						{
							iReturnValue += 4;
						}
						else if (iCount == 1)
						{
							iReturnValue += 40;
						}
						else if (iCount == 2)
						{
							iReturnValue += 400;
						}
						else if (iCount == 3)
						{
							iReturnValue += 4000;
						}
					}
					else if (tempStr == "E")
					{
						if (iCount == 0)
						{
							iReturnValue += 5;
						}
						else if (iCount == 1)
						{
							iReturnValue += 50;
						}
						else if (iCount == 2)
						{
							iReturnValue += 500;
						}
						else if (iCount == 3)
						{
							iReturnValue += 5000;
						}
					}
					else if (tempStr == "F")
					{
						if (iCount == 0)
						{
							iReturnValue += 6;
						}
						else if (iCount == 1)
						{
							iReturnValue += 60;
						}
						else if (iCount == 2)
						{
							iReturnValue += 600;
						}
						else if (iCount == 3)
						{
							iReturnValue += 6000;
						}
					}
					else if (tempStr == "G")
					{
						if (iCount == 0)
						{
							iReturnValue += 7;
						}
						else if (iCount == 1)
						{
							iReturnValue += 70;
						}
						else if (iCount == 2)
						{
							iReturnValue += 700;
						}
						else if (iCount == 3)
						{
							iReturnValue += 7000;
						}
					}
					else if (tempStr == "H")
					{
						if (iCount == 0)
						{
							iReturnValue += 8;
						}
						else if (iCount == 1)
						{
							iReturnValue += 80;
						}
						else if (iCount == 2)
						{
							iReturnValue += 800;
						}
						else if (iCount == 3)
						{
							iReturnValue += 8000;
						}
					}
					else if (tempStr == "I")
					{
						if (iCount == 0)
						{
							iReturnValue += 9;
						}
						else if (iCount == 1)
						{
							iReturnValue += 90;
						}
						else if (iCount == 2)
						{
							iReturnValue += 900;
						}
						else if (iCount == 3)
						{
							iReturnValue += 9000;
						}
					}
					else if (tempStr == "J")
					{
						iReturnValue = iReturnValue;
					}
					iCount++;
				}
			}
			catch (System.Exception arg_2EC_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2EC_0.StackTrace);
			}
			return iReturnValue;
		}
		private void btnActivation_Click(object sender, System.EventArgs e)
		{
			try
			{
				string cdkeyStr = this.textBox_CDkey.Text.ToString();
				if (string.IsNullOrEmpty(cdkeyStr))
				{
					MessageBox.Show("输入的激活码为空!", "提示", MessageBoxButtons.OK);
				}
				else if (cdkeyStr == "请输入20位激活码")
				{
					MessageBox.Show("输入的激活码为空!", "提示", MessageBoxButtons.OK);
				}
				else if (cdkeyStr.Length != 20)
				{
					MessageBox.Show("输入的激活码无效!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					string yearStr = cdkeyStr.Substring(6, 4);
					string monthStr = cdkeyStr.Substring(10, 2);
					string dayStr = cdkeyStr.Substring(12, 2);
					string hourStr = cdkeyStr.Substring(14, 2);
					string minuteStr = cdkeyStr.Substring(16, 2);
					string secondStr = cdkeyStr.Substring(18, 2);
					int iYear = this.GetIntTimeNum(yearStr);
					int iMonth = this.GetIntTimeNum(monthStr);
					int iDay = this.GetIntTimeNum(dayStr);
					int iHour = this.GetIntTimeNum(hourStr);
					int iMinute = this.GetIntTimeNum(minuteStr);
					int iSecond = this.GetIntTimeNum(secondStr);
					if (iYear != 0 && iMonth != 0 && iDay != 0 && iHour < 24 && iMinute < 60 && iSecond < 60)
					{
						System.ValueType valueType = default(System.DateTime);
						(System.DateTime)valueType = new System.DateTime(iYear, iMonth, iDay, iHour, iMinute, iSecond);
						if (((System.DateTime)System.DateTime.Now).CompareTo(valueType) >= 0)
						{
							MessageBox.Show("激活码无效!", "提示", MessageBoxButtons.OK);
							this.bRegisterSuccFlag = false;
						}
						else
						{
							string chyStr = cdkeyStr.Substring(0, 6);
							if ("CCHHYY" == chyStr)
							{
								System.ValueType nTime = System.DateTime.Now;
								System.ValueType valueType2 = default(System.DateTime);
								(System.DateTime)valueType2 = new System.DateTime(((System.DateTime)nTime).Year, ((System.DateTime)nTime).Month, ((System.DateTime)nTime).Day + 3, ((System.DateTime)nTime).Hour, ((System.DateTime)nTime).Minute, ((System.DateTime)nTime).Second);
								this.endTime = valueType2;
							}
							else if ("CCYYHH" == chyStr)
							{
								System.ValueType nTime2 = System.DateTime.Now;
								System.ValueType valueType3 = default(System.DateTime);
								(System.DateTime)valueType3 = new System.DateTime(((System.DateTime)nTime2).Year, ((System.DateTime)nTime2).Month + 1, ((System.DateTime)nTime2).Day, ((System.DateTime)nTime2).Hour, ((System.DateTime)nTime2).Minute, ((System.DateTime)nTime2).Second);
								this.endTime = valueType3;
							}
							else if ("YYHHCC" == chyStr)
							{
								System.ValueType nTime3 = System.DateTime.Now;
								System.ValueType valueType4 = default(System.DateTime);
								(System.DateTime)valueType4 = new System.DateTime(((System.DateTime)nTime3).Year + 1, ((System.DateTime)nTime3).Month, ((System.DateTime)nTime3).Day, ((System.DateTime)nTime3).Hour, ((System.DateTime)nTime3).Minute, ((System.DateTime)nTime3).Second);
								this.endTime = valueType4;
							}
							else
							{
								System.ValueType valueType5 = default(System.DateTime);
								(System.DateTime)valueType5 = new System.DateTime(iYear, iMonth, iDay, iHour, iMinute, iSecond);
								this.endTime = valueType5;
							}
							try
							{
								System.IO.FileStream fs = new System.IO.FileStream(this.licFilePathStr, System.IO.FileMode.OpenOrCreate);
								System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
								bw.Write("截止日期");
								bw.Write(System.Convert.ToDouble(((System.DateTime)this.endTime).Year));
								bw.Write("年");
								bw.Write(System.Convert.ToDouble(((System.DateTime)this.endTime).Month));
								bw.Write("月");
								bw.Write(System.Convert.ToDouble(((System.DateTime)this.endTime).Day));
								bw.Write("日");
								bw.Write(System.Convert.ToDouble(((System.DateTime)this.endTime).Hour));
								bw.Write("时");
								bw.Write(System.Convert.ToDouble(((System.DateTime)this.endTime).Minute));
								bw.Write("分");
								bw.Write(System.Convert.ToDouble(((System.DateTime)this.endTime).Second));
								bw.Write("秒");
								bw.Write(System.Convert.ToDouble(((System.DateTime)this.endTime).Millisecond));
								bw.Write("豪秒");
								bw.Flush();
								bw.Close();
								fs.Close();
							}
							catch (System.Exception arg_4BB_0)
							{
								KLineTestProcessor.ExceptionRecordFunc(arg_4BB_0.StackTrace);
							}
							this.bRegisterSuccFlag = true;
							MessageBox.Show("恭喜您，激活成功!", "提示", MessageBoxButtons.OK);
							this.dYear = System.Convert.ToDouble(((System.DateTime)this.endTime).Year);
							this.dMonth = System.Convert.ToDouble(((System.DateTime)this.endTime).Month);
							this.dDay = System.Convert.ToDouble(((System.DateTime)this.endTime).Day);
							this.dHour = System.Convert.ToDouble(((System.DateTime)this.endTime).Hour);
							this.dMinute = System.Convert.ToDouble(((System.DateTime)this.endTime).Minute);
							this.dSecond = System.Convert.ToDouble(((System.DateTime)this.endTime).Second);
							this.dMillisecond = System.Convert.ToDouble(((System.DateTime)this.endTime).Millisecond);
							base.Close();
						}
					}
					else
					{
						MessageBox.Show("无效的激活码!", "提示", MessageBoxButtons.OK);
						this.bRegisterSuccFlag = false;
					}
				}
			}
			catch (System.Exception arg_5BE_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5BE_0.StackTrace);
				MessageBox.Show("无效的激活码!", "提示", MessageBoxButtons.OK);
				this.bRegisterSuccFlag = false;
			}
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			base.Close();
		}
		private void textBox_CDkey_MouseClick(object sender, MouseEventArgs e)
		{
			try
			{
				if (this.textBox_CDkey.Text.ToString() == "请输入20位激活码")
				{
					this.textBox_CDkey.Text = "";
					System.Drawing.Color this2 = System.Drawing.Color.Black;
					this.textBox_CDkey.ForeColor = this2;
				}
			}
			catch (System.Exception arg_40_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_40_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormActiveProduct();
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
