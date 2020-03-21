using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormBatchAddZD : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public int iAddRule;
		public int iAddCount;
		public int iStartPinNo;
		public string startPinNameStr;
		private Label label_JYTS;
		private TextBox textBox_StartPin;
		private Label label3;
		private ComboBox comboBox_batchRule;
		private NumericUpDown numericUpDown_pinNum;
		private Button btnAdd;
		private Label label1;
		private Button btnQuit;
		private Label label2;
		private Container components;
		public ctFormBatchAddZD(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.gLineTestProcessor = gltProcessor;
				}
				catch (System.Exception arg_15_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_15_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormBatchAddZD()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormBatchAddZD));
			this.textBox_StartPin = new TextBox();
			this.label3 = new Label();
			this.comboBox_batchRule = new ComboBox();
			this.numericUpDown_pinNum = new NumericUpDown();
			this.btnAdd = new Button();
			this.label1 = new Label();
			this.btnQuit = new Button();
			this.label2 = new Label();
			this.label_JYTS = new Label();
			((ISupportInitialize)this.numericUpDown_pinNum).BeginInit();
			base.SuspendLayout();
			this.textBox_StartPin.Anchor = AnchorStyles.Top;
			this.textBox_StartPin.Font = new System.Drawing.Font("宋体", 10.8f);
			System.Drawing.Point location = new System.Drawing.Point(171, 80);
			this.textBox_StartPin.Location = location;
			Padding margin = new Padding(2, 2, 2, 2);
			this.textBox_StartPin.Margin = margin;
			this.textBox_StartPin.MaxLength = 7;
			this.textBox_StartPin.Name = "textBox_StartPin";
			System.Drawing.Size size = new System.Drawing.Size(271, 24);
			this.textBox_StartPin.Size = size;
			this.textBox_StartPin.TabIndex = 33;
			this.textBox_StartPin.Text = "1";
			this.textBox_StartPin.TextChanged += new System.EventHandler(this.textBox_StartPin_TextChanged);
			this.textBox_StartPin.KeyPress += new KeyPressEventHandler(this.textBox_StartPin_KeyPress);
			this.textBox_StartPin.Leave += new System.EventHandler(this.textBox_StartPin_Leave);
			this.label3.Anchor = AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.8f);
			System.Drawing.Point location2 = new System.Drawing.Point(86, 84);
			this.label3.Location = location2;
			Padding margin2 = new Padding(2, 0, 2, 0);
			this.label3.Margin = margin2;
			this.label3.Name = "label3";
			System.Drawing.Size size2 = new System.Drawing.Size(75, 15);
			this.label3.Size = size2;
			this.label3.TabIndex = 32;
			this.label3.Text = "起始针点:";
			this.comboBox_batchRule.Anchor = AnchorStyles.Top;
			this.comboBox_batchRule.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_batchRule.Font = new System.Drawing.Font("宋体", 10.8f);
			this.comboBox_batchRule.FormattingEnabled = true;
			object[] items = new object[]
			{
				"1，2，3，...(数字递增)",
				"AA,BB,CC,...ZZ(大写字母同时递变)",
				"aa,bb,cc,...zz(小写字母同时递变)",
				"A,B,...Z,AA,AB,...ZZ(大写字母递变)",
				"a,b,...z,aa,ab,...zz(小写字母递变)",
				"字母+数字(字母不变,数字递增)"
			};
			this.comboBox_batchRule.Items.AddRange(items);
			System.Drawing.Point location3 = new System.Drawing.Point(171, 35);
			this.comboBox_batchRule.Location = location3;
			Padding margin3 = new Padding(2, 2, 2, 2);
			this.comboBox_batchRule.Margin = margin3;
			this.comboBox_batchRule.Name = "comboBox_batchRule";
			System.Drawing.Size size3 = new System.Drawing.Size(271, 22);
			this.comboBox_batchRule.Size = size3;
			this.comboBox_batchRule.TabIndex = 31;
			this.comboBox_batchRule.SelectedIndexChanged += new System.EventHandler(this.comboBox_batchRule_SelectedIndexChanged);
			this.numericUpDown_pinNum.Anchor = AnchorStyles.Top;
			this.numericUpDown_pinNum.Font = new System.Drawing.Font("宋体", 10.8f);
			System.Drawing.Point location4 = new System.Drawing.Point(171, 126);
			this.numericUpDown_pinNum.Location = location4;
			Padding margin4 = new Padding(2, 2, 2, 2);
			this.numericUpDown_pinNum.Margin = margin4;
			decimal maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				0
			});
			this.numericUpDown_pinNum.Maximum = maximum;
			decimal minimum = new decimal(new int[]
			{
				2,
				0,
				0,
				0
			});
			this.numericUpDown_pinNum.Minimum = minimum;
			this.numericUpDown_pinNum.Name = "numericUpDown_pinNum";
			System.Drawing.Size size4 = new System.Drawing.Size(270, 24);
			this.numericUpDown_pinNum.Size = size4;
			this.numericUpDown_pinNum.TabIndex = 37;
			decimal value = new decimal(new int[]
			{
				64,
				0,
				0,
				0
			});
			this.numericUpDown_pinNum.Value = value;
			this.numericUpDown_pinNum.KeyUp += new KeyEventHandler(this.numericUpDown_pinNum_KeyUp);
			this.btnAdd.Anchor = AnchorStyles.Bottom;
			this.btnAdd.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(171, 217);
			this.btnAdd.Location = location5;
			Padding margin5 = new Padding(2, 2, 2, 2);
			this.btnAdd.Margin = margin5;
			this.btnAdd.Name = "btnAdd";
			System.Drawing.Size size5 = new System.Drawing.Size(90, 24);
			this.btnAdd.Size = size5;
			this.btnAdd.TabIndex = 28;
			this.btnAdd.Text = "确定";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.label1.Anchor = AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f);
			System.Drawing.Point location6 = new System.Drawing.Point(86, 38);
			this.label1.Location = location6;
			Padding margin6 = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin6;
			this.label1.Name = "label1";
			System.Drawing.Size size6 = new System.Drawing.Size(75, 15);
			this.label1.Size = size6;
			this.label1.TabIndex = 30;
			this.label1.Text = "命名规则:";
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(320, 217);
			this.btnQuit.Location = location7;
			Padding margin7 = new Padding(2, 2, 2, 2);
			this.btnQuit.Margin = margin7;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size7 = new System.Drawing.Size(90, 24);
			this.btnQuit.Size = size7;
			this.btnQuit.TabIndex = 29;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.label2.Anchor = AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f);
			System.Drawing.Point location8 = new System.Drawing.Point(86, 130);
			this.label2.Location = location8;
			Padding margin8 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin8;
			this.label2.Name = "label2";
			System.Drawing.Size size8 = new System.Drawing.Size(75, 15);
			this.label2.Size = size8;
			this.label2.TabIndex = 36;
			this.label2.Text = "操作数量:";
			this.label_JYTS.AutoSize = true;
			System.Drawing.Color red = System.Drawing.Color.Red;
			this.label_JYTS.ForeColor = red;
			System.Drawing.Point location9 = new System.Drawing.Point(133, 7);
			this.label_JYTS.Location = location9;
			Padding margin9 = new Padding(2, 0, 2, 0);
			this.label_JYTS.Margin = margin9;
			this.label_JYTS.Name = "label_JYTS";
			System.Drawing.Size size9 = new System.Drawing.Size(317, 12);
			this.label_JYTS.Size = size9;
			this.label_JYTS.TabIndex = 38;
			this.label_JYTS.Text = "注：已禁用大写英文字母(I,O,Q)和小写英文字母(i,j,l,o)";
			this.label_JYTS.Visible = false;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(536, 292);
			base.ClientSize = clientSize;
			base.Controls.Add(this.label_JYTS);
			base.Controls.Add(this.textBox_StartPin);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.comboBox_batchRule);
			base.Controls.Add(this.numericUpDown_pinNum);
			base.Controls.Add(this.btnAdd);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.label2);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin10 = new Padding(2, 2, 2, 2);
			base.Margin = margin10;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormBatchAddZD";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "批量添加针点";
			base.Load += new System.EventHandler(this.ctFormBatchAddZD_Load);
			((ISupportInitialize)this.numericUpDown_pinNum).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void comboBox_batchRule_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (this.comboBox_batchRule.SelectedIndex == 0)
				{
					this.textBox_StartPin.Text = "1";
					this.textBox_StartPin.MaxLength = 7;
				}
				else if (this.comboBox_batchRule.SelectedIndex == 1)
				{
					this.textBox_StartPin.Text = "AA";
					this.textBox_StartPin.MaxLength = 3;
					decimal sender2 = System.Convert.ToDecimal(26);
					this.numericUpDown_pinNum.Value = sender2;
				}
				else if (this.comboBox_batchRule.SelectedIndex == 2)
				{
					this.textBox_StartPin.Text = "aa";
					this.textBox_StartPin.MaxLength = 3;
					decimal this2 = System.Convert.ToDecimal(26);
					this.numericUpDown_pinNum.Value = this2;
				}
				else if (this.comboBox_batchRule.SelectedIndex == 3)
				{
					this.textBox_StartPin.Text = "A";
					this.textBox_StartPin.MaxLength = 3;
				}
				else if (this.comboBox_batchRule.SelectedIndex == 4)
				{
					this.textBox_StartPin.Text = "a";
					this.textBox_StartPin.MaxLength = 3;
				}
				else if (this.comboBox_batchRule.SelectedIndex == 5)
				{
					this.textBox_StartPin.Text = "A1";
					this.textBox_StartPin.MaxLength = 16;
				}
			}
			catch (System.Exception arg_139_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_139_0.StackTrace);
			}
		}
		private void textBox_StartPin_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (this.comboBox_batchRule.SelectedIndex == 0)
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
				if (this.comboBox_batchRule.SelectedIndex != 1 && this.comboBox_batchRule.SelectedIndex != 2 && this.comboBox_batchRule.SelectedIndex != 3 && this.comboBox_batchRule.SelectedIndex != 4)
				{
					if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar < 'A' || e.KeyChar > 'Z') && (e.KeyChar < 'a' || e.KeyChar > 'z') && e.KeyChar < '_' && e.KeyChar != '\b')
					{
						e.Handled = true;
					}
					else
					{
						e.Handled = false;
					}
				}
				else if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || e.KeyChar == '\b')
				{
					e.Handled = false;
				}
				else
				{
					e.Handled = true;
				}
			}
			catch (System.Exception ex_11C)
			{
			}
		}
		private void textBox_StartPin_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				string tempStr = this.textBox_StartPin.Text.ToString();
				if (tempStr.Length <= 0)
				{
					if (this.comboBox_batchRule.SelectedIndex != 1 && this.comboBox_batchRule.SelectedIndex != 3)
					{
						if (this.comboBox_batchRule.SelectedIndex == 2 || this.comboBox_batchRule.SelectedIndex == 4)
						{
							this.textBox_StartPin.Text = tempStr.Trim().ToLower();
						}
					}
					else
					{
						this.textBox_StartPin.Text = tempStr.Trim().ToUpper();
					}
				}
			}
			catch (System.Exception ex_84)
			{
			}
		}
		private void textBox_StartPin_Leave(object sender, System.EventArgs e)
		{
			try
			{
				string tempStr = this.textBox_StartPin.Text.ToString();
				if (tempStr.Length <= 0)
				{
					if (this.comboBox_batchRule.SelectedIndex != 1 && this.comboBox_batchRule.SelectedIndex != 3)
					{
						if (this.comboBox_batchRule.SelectedIndex == 2 || this.comboBox_batchRule.SelectedIndex == 4)
						{
							this.textBox_StartPin.Text = tempStr.Trim().ToLower();
						}
					}
					else
					{
						this.textBox_StartPin.Text = tempStr.Trim().ToUpper();
					}
				}
			}
			catch (System.Exception ex_84)
			{
			}
		}
		private void ctFormBatchAddZD_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.iAddRule = 0;
				this.iAddCount = 0;
				this.startPinNameStr = "1";
				this.comboBox_batchRule.SelectedIndex = 0;
				decimal this2 = this.gLineTestProcessor.SELF_MAX_COUNT;
				this.numericUpDown_pinNum.Maximum = this2;
				if (!this.gLineTestProcessor.bUseEnglishAlphabetsIOQFlag)
				{
					this.label_JYTS.Visible = true;
				}
			}
			catch (System.Exception arg_5D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5D_0.StackTrace);
			}
		}
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				int iTemp = 0;
				int iSelectedIndex = this.comboBox_batchRule.SelectedIndex;
				string strSPN = this.textBox_StartPin.Text.ToString().Trim();
				if (iSelectedIndex == 0)
				{
					try
					{
						iTemp = System.Convert.ToInt32(strSPN);
						goto IL_125;
					}
					catch (System.Exception ex_39)
					{
						MessageBox.Show("起始接点名和命名规则不符，请重新录入!", "提示", MessageBoxButtons.OK);
					}
					return;
				}
				if (iSelectedIndex != 1 && iSelectedIndex != 3)
				{
					if (iSelectedIndex != 2 && iSelectedIndex != 4)
					{
						if (iSelectedIndex == 5)
						{
							string tempStr = strSPN.Substring(0, 1);
							iTemp = -1;
							try
							{
								iTemp = System.Convert.ToInt32(tempStr);
							}
							catch (System.Exception ex_87)
							{
							}
							if (iTemp != -1)
							{
								MessageBox.Show("起始接点名和命名规则不符，请重新录入!", "提示", MessageBoxButtons.OK);
								return;
							}
							string expr_A9 = strSPN;
							tempStr = expr_A9.Substring(expr_A9.Length - 1);
							iTemp = -1;
							try
							{
								iTemp = System.Convert.ToInt32(tempStr);
							}
							catch (System.Exception ex_C2)
							{
							}
							if (iTemp == -1)
							{
								MessageBox.Show("起始接点名和命名规则不符，请重新录入!", "提示", MessageBoxButtons.OK);
								return;
							}
						}
					}
					else
					{
						string expr_E4 = strSPN;
						if (expr_E4 != expr_E4.ToLower())
						{
							MessageBox.Show("起始接点名和命名规则不符，请重新录入!", "提示", MessageBoxButtons.OK);
							return;
						}
					}
				}
				else
				{
					string expr_105 = strSPN;
					if (expr_105 != expr_105.ToUpper())
					{
						MessageBox.Show("起始接点名和命名规则不符，请重新录入!", "提示", MessageBoxButtons.OK);
						return;
					}
				}
				IL_125:
				int iPNTemp = System.Convert.ToInt32(this.numericUpDown_pinNum.Value);
				this.iAddRule = iSelectedIndex;
				this.iAddCount = iPNTemp;
				this.startPinNameStr = strSPN;
			}
			catch (System.Exception arg_156_0)
			{
				this.iAddCount = 0;
				KLineTestProcessor.ExceptionRecordFunc(arg_156_0.StackTrace);
			}
			base.Close();
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			this.iAddCount = 0;
			base.Close();
		}
		private void numericUpDown_pinNum_KeyUp(object sender, KeyEventArgs e)
		{
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormBatchAddZD();
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
