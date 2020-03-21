using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormBatchAddPin : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public int iAddCount;
		public int iAllowMaxCount;
		public bool bSetAllowMaxCountFlag;
		private Label label_qzfw;
		private Button btnAdd;
		private Button btnQuit;
		private Label label2;
		private NumericUpDown numericUpDown_pinNum;
		private Container components;
		public ctFormBatchAddPin(KLineTestProcessor gltProcessor, int iCount)
		{
			try
			{
				this.InitializeComponent();
				this.gLineTestProcessor = gltProcessor;
				this.iAllowMaxCount = iCount;
				this.bSetAllowMaxCountFlag = true;
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		public ctFormBatchAddPin(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				this.gLineTestProcessor = gltProcessor;
				this.bSetAllowMaxCountFlag = false;
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormBatchAddPin()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormBatchAddPin));
			this.btnAdd = new Button();
			this.btnQuit = new Button();
			this.label2 = new Label();
			this.numericUpDown_pinNum = new NumericUpDown();
			this.label_qzfw = new Label();
			((ISupportInitialize)this.numericUpDown_pinNum).BeginInit();
			base.SuspendLayout();
			this.btnAdd.Anchor = AnchorStyles.Bottom;
			this.btnAdd.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(98, 94);
			this.btnAdd.Location = location;
			Padding margin = new Padding(2, 2, 2, 2);
			this.btnAdd.Margin = margin;
			this.btnAdd.Name = "btnAdd";
			System.Drawing.Size size = new System.Drawing.Size(90, 24);
			this.btnAdd.Size = size;
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "确定";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(213, 94);
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
			this.label2.Anchor = AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(49, 33);
			this.label2.Location = location3;
			Padding margin3 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin3;
			this.label2.Name = "label2";
			System.Drawing.Size size3 = new System.Drawing.Size(75, 15);
			this.label2.Size = size3;
			this.label2.TabIndex = 2;
			this.label2.Text = "添加数量:";
			this.numericUpDown_pinNum.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(131, 29);
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
			this.numericUpDown_pinNum.Name = "numericUpDown_pinNum";
			System.Drawing.Size size4 = new System.Drawing.Size(135, 24);
			this.numericUpDown_pinNum.Size = size4;
			this.numericUpDown_pinNum.TabIndex = 3;
			this.numericUpDown_pinNum.TextAlign = HorizontalAlignment.Center;
			decimal value = new decimal(new int[]
			{
				64,
				0,
				0,
				0
			});
			this.numericUpDown_pinNum.Value = value;
			this.numericUpDown_pinNum.KeyPress += new KeyPressEventHandler(this.numericUpDown_pinNum_KeyPress);
			this.numericUpDown_pinNum.KeyUp += new KeyEventHandler(this.numericUpDown_pinNum_KeyUp);
			this.label_qzfw.AutoSize = true;
			this.label_qzfw.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(276, 33);
			this.label_qzfw.Location = location5;
			Padding margin5 = new Padding(2, 0, 2, 0);
			this.label_qzfw.Margin = margin5;
			this.label_qzfw.Name = "label_qzfw";
			System.Drawing.Size size5 = new System.Drawing.Size(71, 15);
			this.label_qzfw.Size = size5;
			this.label_qzfw.TabIndex = 4;
			this.label_qzfw.Text = "(0~1024)";
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(400, 148);
			base.ClientSize = clientSize;
			base.Controls.Add(this.label_qzfw);
			base.Controls.Add(this.numericUpDown_pinNum);
			base.Controls.Add(this.btnAdd);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.label2);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin6 = new Padding(2, 2, 2, 2);
			base.Margin = margin6;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormBatchAddPin";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "批量添加";
			base.Load += new System.EventHandler(this.ctFormBatchAddPin_Load);
			((ISupportInitialize)this.numericUpDown_pinNum).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			this.iAddCount = 0;
			base.Close();
		}
		private void ctFormBatchAddPin_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.iAddCount = 0;
				if (this.bSetAllowMaxCountFlag)
				{
					decimal maximum = System.Convert.ToDecimal(this.iAllowMaxCount);
					this.numericUpDown_pinNum.Maximum = maximum;
				}
				else
				{
					decimal e2 = System.Convert.ToDecimal(this.gLineTestProcessor.SELF_MAX_COUNT);
					this.numericUpDown_pinNum.Maximum = e2;
				}
				decimal sender2 = this.numericUpDown_pinNum.Maximum;
				this.numericUpDown_pinNum.Value = sender2;
				decimal this2 = this.numericUpDown_pinNum.Maximum;
				this.label_qzfw.Text = "(0~" + System.Convert.ToString(this2) + ")";
			}
			catch (System.Exception arg_91_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_91_0.StackTrace);
			}
		}
		private void numericUpDown_pinNum_KeyPress(object sender, KeyPressEventArgs e)
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
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				decimal this2 = this.numericUpDown_pinNum.Value;
				this.iAddCount = System.Convert.ToInt32(this2);
			}
			catch (System.Exception arg_1A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1A_0.StackTrace);
			}
			base.Close();
		}
		private void numericUpDown_pinNum_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				string tempStr = this.numericUpDown_pinNum.Text.ToString().Trim();
				int iMaxValue = System.Convert.ToInt32(this.numericUpDown_pinNum.Maximum);
				if (!string.IsNullOrEmpty(tempStr) && System.Convert.ToInt32(tempStr) > iMaxValue)
				{
					MessageBox.Show("输入值已超出取值范围!", "提示", MessageBoxButtons.OK);
				}
			}
			catch (System.Exception arg_4D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_4D_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormBatchAddPin();
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
