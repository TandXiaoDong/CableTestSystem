using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormBatchAddABC : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public int iAddRule;
		public int iAddCount;
		public int iStartPinNo;
		public int iLastZJTPin;
		public bool bBCKFlag;
		public string startPinNameStr;
		public string measMethodStr;
		private Label label_JYTS;
		private CheckBox checkBox_BCK;
		private ComboBox comboBox_csyzdh_FourWire;
		private RadioButton radioButton_Pin_FourWire;
		private RadioButton radioButton_Pin_TwoWire;
		private Label label6;
		private NumericUpDown numericUpDown_csyzdh;
		private TextBox textBox_StartPin;
		private Label label4;
		private Label label3;
		private NumericUpDown numericUpDown_pinNum;
		private Button btnAdd;
		private Button btnQuit;
		private Label label2;
		private Label label1;
		private ComboBox comboBox_batchRule;
		private Container components;
		public ctFormBatchAddABC(KLineTestProcessor gltProcessor, int iLZJTPin)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.gLineTestProcessor = gltProcessor;
					this.iLastZJTPin = iLZJTPin;
					int i = 0;
					while (true)
					{
						int iLZJTPin2 = i + 2;
						if (iLZJTPin2 > this.gLineTestProcessor.SELF_MAX_COUNT)
						{
							break;
						}
						int gltProcessor2 = i + 1;
						string tempStr = System.Convert.ToString(gltProcessor2) + "," + System.Convert.ToString(iLZJTPin2);
						this.comboBox_csyzdh_FourWire.Items.Add(tempStr);
						i = gltProcessor2;
						i++;
					}
				}
				catch (System.Exception arg_70_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_70_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		public ctFormBatchAddABC(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.gLineTestProcessor = gltProcessor;
					this.iLastZJTPin = 0;
					int i = 0;
					while (true)
					{
						int num = i + 2;
						if (num > this.gLineTestProcessor.SELF_MAX_COUNT)
						{
							break;
						}
						int gltProcessor2 = i + 1;
						string tempStr = System.Convert.ToString(gltProcessor2) + "," + System.Convert.ToString(num);
						this.comboBox_csyzdh_FourWire.Items.Add(tempStr);
						i = gltProcessor2;
						i++;
					}
				}
				catch (System.Exception arg_70_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_70_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormBatchAddABC()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormBatchAddABC));
			this.numericUpDown_pinNum = new NumericUpDown();
			this.btnAdd = new Button();
			this.btnQuit = new Button();
			this.label2 = new Label();
			this.label1 = new Label();
			this.comboBox_batchRule = new ComboBox();
			this.numericUpDown_csyzdh = new NumericUpDown();
			this.textBox_StartPin = new TextBox();
			this.label4 = new Label();
			this.label3 = new Label();
			this.radioButton_Pin_FourWire = new RadioButton();
			this.radioButton_Pin_TwoWire = new RadioButton();
			this.label6 = new Label();
			this.comboBox_csyzdh_FourWire = new ComboBox();
			this.checkBox_BCK = new CheckBox();
			this.label_JYTS = new Label();
			((ISupportInitialize)this.numericUpDown_pinNum).BeginInit();
			((ISupportInitialize)this.numericUpDown_csyzdh).BeginInit();
			base.SuspendLayout();
			this.numericUpDown_pinNum.Anchor = AnchorStyles.Top;
			this.numericUpDown_pinNum.Font = new System.Drawing.Font("宋体", 10.8f);
			System.Drawing.Point location = new System.Drawing.Point(171, 217);
			this.numericUpDown_pinNum.Location = location;
			Padding margin = new Padding(2);
			this.numericUpDown_pinNum.Margin = margin;
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
			System.Drawing.Size size = new System.Drawing.Size(270, 24);
			this.numericUpDown_pinNum.Size = size;
			this.numericUpDown_pinNum.TabIndex = 9;
			decimal value = new decimal(new int[]
			{
				64,
				0,
				0,
				0
			});
			this.numericUpDown_pinNum.Value = value;
			this.numericUpDown_pinNum.KeyPress += new KeyPressEventHandler(this.numericUpDown_batchNum_KeyPress);
			this.btnAdd.Anchor = AnchorStyles.Bottom;
			this.btnAdd.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(171, 343);
			this.btnAdd.Location = location2;
			Padding margin2 = new Padding(2);
			this.btnAdd.Margin = margin2;
			this.btnAdd.Name = "btnAdd";
			System.Drawing.Size size2 = new System.Drawing.Size(90, 24);
			this.btnAdd.Size = size2;
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "确定";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(320, 343);
			this.btnQuit.Location = location3;
			Padding margin3 = new Padding(2);
			this.btnQuit.Margin = margin3;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size3 = new System.Drawing.Size(90, 24);
			this.btnQuit.Size = size3;
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.label2.Anchor = AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f);
			System.Drawing.Point location4 = new System.Drawing.Point(86, 221);
			this.label2.Location = location4;
			Padding margin4 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin4;
			this.label2.Name = "label2";
			System.Drawing.Size size4 = new System.Drawing.Size(75, 15);
			this.label2.Size = size4;
			this.label2.TabIndex = 8;
			this.label2.Text = "操作数量:";
			this.label1.Anchor = AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f);
			System.Drawing.Point location5 = new System.Drawing.Point(86, 38);
			this.label1.Location = location5;
			Padding margin5 = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin5;
			this.label1.Name = "label1";
			System.Drawing.Size size5 = new System.Drawing.Size(75, 15);
			this.label1.Size = size5;
			this.label1.TabIndex = 2;
			this.label1.Text = "命名规则:";
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
			System.Drawing.Point location6 = new System.Drawing.Point(171, 35);
			this.comboBox_batchRule.Location = location6;
			Padding margin6 = new Padding(2);
			this.comboBox_batchRule.Margin = margin6;
			this.comboBox_batchRule.Name = "comboBox_batchRule";
			System.Drawing.Size size6 = new System.Drawing.Size(271, 22);
			this.comboBox_batchRule.Size = size6;
			this.comboBox_batchRule.TabIndex = 3;
			this.comboBox_batchRule.SelectedIndexChanged += new System.EventHandler(this.comboBox_batchRule_SelectedIndexChanged);
			this.numericUpDown_csyzdh.Anchor = AnchorStyles.Top;
			this.numericUpDown_csyzdh.Font = new System.Drawing.Font("宋体", 10.8f);
			System.Drawing.Point location7 = new System.Drawing.Point(171, 171);
			this.numericUpDown_csyzdh.Location = location7;
			Padding margin7 = new Padding(2);
			this.numericUpDown_csyzdh.Margin = margin7;
			decimal maximum2 = new decimal(new int[]
			{
				1023,
				0,
				0,
				0
			});
			this.numericUpDown_csyzdh.Maximum = maximum2;
			decimal minimum2 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_csyzdh.Minimum = minimum2;
			this.numericUpDown_csyzdh.Name = "numericUpDown_csyzdh";
			System.Drawing.Size size7 = new System.Drawing.Size(270, 24);
			this.numericUpDown_csyzdh.Size = size7;
			this.numericUpDown_csyzdh.TabIndex = 7;
			decimal value2 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_csyzdh.Value = value2;
			this.numericUpDown_csyzdh.KeyPress += new KeyPressEventHandler(this.numericUpDown_csyzdh_KeyPress);
			this.numericUpDown_csyzdh.KeyUp += new KeyEventHandler(this.numericUpDown_csyzdh_KeyUp);
			this.textBox_StartPin.Anchor = AnchorStyles.Top;
			this.textBox_StartPin.Font = new System.Drawing.Font("宋体", 10.8f);
			System.Drawing.Point location8 = new System.Drawing.Point(171, 80);
			this.textBox_StartPin.Location = location8;
			Padding margin8 = new Padding(2);
			this.textBox_StartPin.Margin = margin8;
			this.textBox_StartPin.MaxLength = 7;
			this.textBox_StartPin.Name = "textBox_StartPin";
			System.Drawing.Size size8 = new System.Drawing.Size(271, 24);
			this.textBox_StartPin.Size = size8;
			this.textBox_StartPin.TabIndex = 5;
			this.textBox_StartPin.Text = "1";
			this.textBox_StartPin.TextChanged += new System.EventHandler(this.textBox_StartPin_TextChanged);
			this.textBox_StartPin.KeyPress += new KeyPressEventHandler(this.textBox_StartPin_KeyPress);
			this.textBox_StartPin.Leave += new System.EventHandler(this.textBox_StartPin_Leave);
			this.label4.Anchor = AnchorStyles.Top;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 10.8f);
			System.Drawing.Point location9 = new System.Drawing.Point(86, 175);
			this.label4.Location = location9;
			Padding margin9 = new Padding(2, 0, 2, 0);
			this.label4.Margin = margin9;
			this.label4.Name = "label4";
			System.Drawing.Size size9 = new System.Drawing.Size(75, 15);
			this.label4.Size = size9;
			this.label4.TabIndex = 6;
			this.label4.Text = "起始针脚:";
			this.label3.Anchor = AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.8f);
			System.Drawing.Point location10 = new System.Drawing.Point(86, 84);
			this.label3.Location = location10;
			Padding margin10 = new Padding(2, 0, 2, 0);
			this.label3.Margin = margin10;
			this.label3.Name = "label3";
			System.Drawing.Size size10 = new System.Drawing.Size(75, 15);
			this.label3.Size = size10;
			this.label3.TabIndex = 4;
			this.label3.Text = "起始接点:";
			this.radioButton_Pin_FourWire.Anchor = AnchorStyles.Top;
			this.radioButton_Pin_FourWire.AutoSize = true;
			this.radioButton_Pin_FourWire.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location11 = new System.Drawing.Point(291, 128);
			this.radioButton_Pin_FourWire.Location = location11;
			Padding margin11 = new Padding(2);
			this.radioButton_Pin_FourWire.Margin = margin11;
			this.radioButton_Pin_FourWire.Name = "radioButton_Pin_FourWire";
			System.Drawing.Size size11 = new System.Drawing.Size(70, 19);
			this.radioButton_Pin_FourWire.Size = size11;
			this.radioButton_Pin_FourWire.TabIndex = 14;
			this.radioButton_Pin_FourWire.Text = "四线法";
			this.radioButton_Pin_FourWire.UseVisualStyleBackColor = true;
			this.radioButton_Pin_TwoWire.Anchor = AnchorStyles.Top;
			this.radioButton_Pin_TwoWire.AutoSize = true;
			this.radioButton_Pin_TwoWire.Checked = true;
			this.radioButton_Pin_TwoWire.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location12 = new System.Drawing.Point(171, 128);
			this.radioButton_Pin_TwoWire.Location = location12;
			Padding margin12 = new Padding(2);
			this.radioButton_Pin_TwoWire.Margin = margin12;
			this.radioButton_Pin_TwoWire.Name = "radioButton_Pin_TwoWire";
			System.Drawing.Size size12 = new System.Drawing.Size(70, 19);
			this.radioButton_Pin_TwoWire.Size = size12;
			this.radioButton_Pin_TwoWire.TabIndex = 15;
			this.radioButton_Pin_TwoWire.TabStop = true;
			this.radioButton_Pin_TwoWire.Text = "二线法";
			this.radioButton_Pin_TwoWire.UseVisualStyleBackColor = true;
			this.radioButton_Pin_TwoWire.CheckedChanged += new System.EventHandler(this.radioButton_Pin_TwoWire_CheckedChanged);
			this.label6.Anchor = AnchorStyles.Top;
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location13 = new System.Drawing.Point(86, 130);
			this.label6.Location = location13;
			Padding margin13 = new Padding(2, 0, 2, 0);
			this.label6.Margin = margin13;
			this.label6.Name = "label6";
			System.Drawing.Size size13 = new System.Drawing.Size(75, 15);
			this.label6.Size = size13;
			this.label6.TabIndex = 13;
			this.label6.Text = "测量方法:";
			this.comboBox_csyzdh_FourWire.Anchor = AnchorStyles.Top;
			this.comboBox_csyzdh_FourWire.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_csyzdh_FourWire.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.comboBox_csyzdh_FourWire.FormattingEnabled = true;
			System.Drawing.Point location14 = new System.Drawing.Point(171, 172);
			this.comboBox_csyzdh_FourWire.Location = location14;
			Padding margin14 = new Padding(2);
			this.comboBox_csyzdh_FourWire.Margin = margin14;
			this.comboBox_csyzdh_FourWire.Name = "comboBox_csyzdh_FourWire";
			System.Drawing.Size size14 = new System.Drawing.Size(271, 22);
			this.comboBox_csyzdh_FourWire.Size = size14;
			this.comboBox_csyzdh_FourWire.TabIndex = 26;
			this.comboBox_csyzdh_FourWire.Visible = false;
			this.checkBox_BCK.AutoSize = true;
			this.checkBox_BCK.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location15 = new System.Drawing.Point(171, 268);
			this.checkBox_BCK.Location = location15;
			Padding margin15 = new Padding(2);
			this.checkBox_BCK.Margin = margin15;
			this.checkBox_BCK.Name = "checkBox_BCK";
			System.Drawing.Size size15 = new System.Drawing.Size(110, 19);
			this.checkBox_BCK.Size = size15;
			this.checkBox_BCK.TabIndex = 27;
			this.checkBox_BCK.Text = "末尾追加BCK";
			this.checkBox_BCK.UseVisualStyleBackColor = true;
			this.checkBox_BCK.Visible = false;
			this.label_JYTS.AutoSize = true;
			System.Drawing.Color red = System.Drawing.Color.Red;
			this.label_JYTS.ForeColor = red;
			System.Drawing.Point location16 = new System.Drawing.Point(133, 9);
			this.label_JYTS.Location = location16;
			Padding margin16 = new Padding(2, 0, 2, 0);
			this.label_JYTS.Margin = margin16;
			this.label_JYTS.Name = "label_JYTS";
			System.Drawing.Size size16 = new System.Drawing.Size(317, 12);
			this.label_JYTS.Size = size16;
			this.label_JYTS.TabIndex = 28;
			this.label_JYTS.Text = "注：已禁用大写英文字母(I,O,Q)和小写英文字母(i,j,l,o)";
			this.label_JYTS.Visible = false;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(536, 404);
			base.ClientSize = clientSize;
			base.Controls.Add(this.label_JYTS);
			base.Controls.Add(this.checkBox_BCK);
			base.Controls.Add(this.comboBox_csyzdh_FourWire);
			base.Controls.Add(this.radioButton_Pin_FourWire);
			base.Controls.Add(this.radioButton_Pin_TwoWire);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.numericUpDown_csyzdh);
			base.Controls.Add(this.textBox_StartPin);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.comboBox_batchRule);
			base.Controls.Add(this.numericUpDown_pinNum);
			base.Controls.Add(this.btnAdd);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.label2);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin17 = new Padding(2);
			base.Margin = margin17;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormBatchAddABC";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "批量操作";
			base.Load += new System.EventHandler(this.ctFormBatchAddABC_Load);
			((ISupportInitialize)this.numericUpDown_pinNum).EndInit();
			((ISupportInitialize)this.numericUpDown_csyzdh).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				int iSelectedIndex = this.comboBox_batchRule.SelectedIndex;
				string strSPN = this.textBox_StartPin.Text.ToString().Trim();
				if (iSelectedIndex != 1 && iSelectedIndex != 3)
				{
					if (iSelectedIndex != 2 && iSelectedIndex != 4)
					{
						if (iSelectedIndex == 5)
						{
							string tempStr = strSPN.Substring(0, 1);
							int iTemp = -1;
							try
							{
								iTemp = System.Convert.ToInt32(tempStr);
							}
							catch (System.Exception ex_59)
							{
							}
							if (iTemp != -1)
							{
								MessageBox.Show("起始接点名和命名规则不符，请重新录入!", "提示", MessageBoxButtons.OK);
								return;
							}
							string expr_7B = strSPN;
							tempStr = expr_7B.Substring(expr_7B.Length - 1);
							iTemp = -1;
							try
							{
								iTemp = System.Convert.ToInt32(tempStr);
							}
							catch (System.Exception ex_94)
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
						string expr_B6 = strSPN;
						if (expr_B6 != expr_B6.ToLower())
						{
							MessageBox.Show("起始接点名和命名规则不符，请重新录入!", "提示", MessageBoxButtons.OK);
							return;
						}
					}
				}
				else
				{
					string expr_DA = strSPN;
					if (expr_DA != expr_DA.ToUpper())
					{
						MessageBox.Show("起始接点名和命名规则不符，请重新录入!", "提示", MessageBoxButtons.OK);
						return;
					}
				}
				int iPNTemp = System.Convert.ToInt32(this.numericUpDown_pinNum.Value);
				if (this.radioButton_Pin_TwoWire.Checked)
				{
					decimal value = this.numericUpDown_csyzdh.Value;
					this.iStartPinNo = System.Convert.ToInt32(value);
					this.measMethodStr = this.radioButton_Pin_TwoWire.Text.ToString();
				}
				else if (this.radioButton_Pin_FourWire.Checked)
				{
					string tempStr = this.comboBox_csyzdh_FourWire.Text.ToString();
					string[] tempArray = tempStr.Split(new char[]
					{
						','
					});
					this.iStartPinNo = System.Convert.ToInt32(tempArray[0]);
					this.measMethodStr = this.radioButton_Pin_FourWire.Text.ToString();
				}
				this.bBCKFlag = this.checkBox_BCK.Checked;
				this.iAddRule = iSelectedIndex;
				this.iAddCount = iPNTemp;
				this.startPinNameStr = strSPN;
			}
			catch (System.Exception ex_1D7)
			{
			}
			base.Close();
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			this.iAddCount = 0;
			base.Close();
		}
		private void numericUpDown_batchNum_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '\b')
				{
					e.Handled = false;
				}
				else
				{
					e.Handled = true;
				}
				decimal sender2 = this.numericUpDown_pinNum.Maximum;
				if (System.Convert.ToDecimal(this.numericUpDown_pinNum.Text.ToString()) > sender2)
				{
					decimal this2 = this.numericUpDown_pinNum.Maximum;
					this.numericUpDown_pinNum.Value = this2;
				}
			}
			catch (System.Exception ex_70)
			{
			}
		}
		private void ctFormBatchAddABC_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.iAddRule = 0;
				this.iAddCount = 0;
				this.iStartPinNo = this.iLastZJTPin + 1;
				this.startPinNameStr = "1";
				this.bBCKFlag = false;
				this.measMethodStr = this.radioButton_Pin_TwoWire.Text.ToString();
				this.comboBox_batchRule.SelectedIndex = this.iAddRule;
				decimal maximum = this.gLineTestProcessor.SELF_MAX_COUNT;
				this.numericUpDown_pinNum.Maximum = maximum;
				decimal maximum2 = this.gLineTestProcessor.SELF_MAX_COUNT;
				this.numericUpDown_csyzdh.Maximum = maximum2;
				if (!this.gLineTestProcessor.bUseEnglishAlphabetsIOQFlag)
				{
					this.label_JYTS.Visible = true;
				}
				if (this.comboBox_csyzdh_FourWire.Items.Count > 0)
				{
					this.comboBox_csyzdh_FourWire.SelectedIndex = 0;
				}
				int sender2 = this.iLastZJTPin + 1;
				int this2 = this.gLineTestProcessor.SELF_MAX_COUNT;
				if (this2 < sender2)
				{
					this.iLastZJTPin = this2;
					decimal value = System.Convert.ToDecimal(this2);
					this.numericUpDown_csyzdh.Value = value;
				}
				else
				{
					decimal e2 = System.Convert.ToDecimal(sender2);
					this.numericUpDown_csyzdh.Value = e2;
				}
			}
			catch (System.Exception arg_115_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_115_0.StackTrace);
			}
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
		private void numericUpDown_csyzdh_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
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
			catch (System.Exception arg_2F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2F_0.StackTrace);
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
		private void radioButton_Pin_TwoWire_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (this.radioButton_Pin_TwoWire.Checked)
				{
					this.numericUpDown_csyzdh.Visible = true;
					this.comboBox_csyzdh_FourWire.Visible = false;
					decimal sender2 = this.gLineTestProcessor.SELF_MAX_COUNT;
					this.numericUpDown_pinNum.Maximum = sender2;
				}
				else
				{
					this.numericUpDown_csyzdh.Visible = false;
					this.comboBox_csyzdh_FourWire.Visible = true;
					decimal this2 = this.comboBox_csyzdh_FourWire.Items.Count;
					this.numericUpDown_pinNum.Maximum = this2;
				}
			}
			catch (System.Exception arg_80_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_80_0.StackTrace);
			}
		}
		private void numericUpDown_csyzdh_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_csyzdh.Text.ToString().Trim();
				int iMaxValue = System.Convert.ToInt32(this.numericUpDown_csyzdh.Maximum);
				if (!string.IsNullOrEmpty(tempStr) && System.Convert.ToInt32(tempStr) > iMaxValue)
				{
					MessageBox.Show("起始针脚超出针脚最大值" + System.Convert.ToString(iMaxValue) + "，请重新输入!", "提示", MessageBoxButtons.OK);
				}
			}
			catch (System.Exception arg_62_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_62_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormBatchAddABC();
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
