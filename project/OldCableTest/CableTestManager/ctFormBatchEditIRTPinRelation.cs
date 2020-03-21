using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormBatchEditIRTPinRelation : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public bool bSubmitFlag;
		public int iCSYPin;
		public int iZJTPin;
		public int iUpdNum;
		private Button btnSubmit;
		private Button btnQuit;
		private Label label1;
		private Label label2;
		private Label label3;
		private NumericUpDown numericUpDown_csy;
		private NumericUpDown numericUpDown_zjt;
		private NumericUpDown numericUpDown_updateNum;
		private Container components;
		public ctFormBatchEditIRTPinRelation(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				this.gLineTestProcessor = gltProcessor;
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormBatchEditIRTPinRelation()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormBatchEditIRTPinRelation));
			this.btnSubmit = new Button();
			this.btnQuit = new Button();
			this.label1 = new Label();
			this.label2 = new Label();
			this.label3 = new Label();
			this.numericUpDown_csy = new NumericUpDown();
			this.numericUpDown_zjt = new NumericUpDown();
			this.numericUpDown_updateNum = new NumericUpDown();
			((ISupportInitialize)this.numericUpDown_csy).BeginInit();
			((ISupportInitialize)this.numericUpDown_zjt).BeginInit();
			((ISupportInitialize)this.numericUpDown_updateNum).BeginInit();
			base.SuspendLayout();
			this.btnSubmit.Anchor = AnchorStyles.Bottom;
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(88, 259);
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
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(213, 259);
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
			System.Drawing.Point location3 = new System.Drawing.Point(46, 55);
			this.label1.Location = location3;
			Padding margin3 = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin3;
			this.label1.Name = "label1";
			System.Drawing.Size size3 = new System.Drawing.Size(151, 15);
			this.label1.Size = size3;
			this.label1.TabIndex = 27;
			this.label1.Text = "测试仪针脚号(起始):";
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(46, 109);
			this.label2.Location = location4;
			Padding margin4 = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin4;
			this.label2.Name = "label2";
			System.Drawing.Size size4 = new System.Drawing.Size(151, 15);
			this.label2.Size = size4;
			this.label2.TabIndex = 27;
			this.label2.Text = "转接台针脚号(起始):";
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(89, 160);
			this.label3.Location = location5;
			Padding margin5 = new Padding(2, 0, 2, 0);
			this.label3.Margin = margin5;
			this.label3.Name = "label3";
			System.Drawing.Size size5 = new System.Drawing.Size(105, 15);
			this.label3.Size = size5;
			this.label3.TabIndex = 27;
			this.label3.Text = "批量修改数量:";
			this.numericUpDown_csy.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(198, 54);
			this.numericUpDown_csy.Location = location6;
			Padding margin6 = new Padding(2, 2, 2, 2);
			this.numericUpDown_csy.Margin = margin6;
			decimal maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				0
			});
			this.numericUpDown_csy.Maximum = maximum;
			decimal minimum = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_csy.Minimum = minimum;
			this.numericUpDown_csy.Name = "numericUpDown_csy";
			System.Drawing.Size size6 = new System.Drawing.Size(112, 24);
			this.numericUpDown_csy.Size = size6;
			this.numericUpDown_csy.TabIndex = 2;
			this.numericUpDown_csy.TextAlign = HorizontalAlignment.Center;
			decimal value = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_csy.Value = value;
			this.numericUpDown_zjt.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(198, 105);
			this.numericUpDown_zjt.Location = location7;
			Padding margin7 = new Padding(2, 2, 2, 2);
			this.numericUpDown_zjt.Margin = margin7;
			decimal maximum2 = new decimal(new int[]
			{
				1023,
				0,
				0,
				0
			});
			this.numericUpDown_zjt.Maximum = maximum2;
			decimal minimum2 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_zjt.Minimum = minimum2;
			this.numericUpDown_zjt.Name = "numericUpDown_zjt";
			System.Drawing.Size size7 = new System.Drawing.Size(112, 24);
			this.numericUpDown_zjt.Size = size7;
			this.numericUpDown_zjt.TabIndex = 3;
			this.numericUpDown_zjt.TextAlign = HorizontalAlignment.Center;
			decimal value2 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_zjt.Value = value2;
			this.numericUpDown_updateNum.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(198, 156);
			this.numericUpDown_updateNum.Location = location8;
			Padding margin8 = new Padding(2, 2, 2, 2);
			this.numericUpDown_updateNum.Margin = margin8;
			decimal maximum3 = new decimal(new int[]
			{
				1023,
				0,
				0,
				0
			});
			this.numericUpDown_updateNum.Maximum = maximum3;
			decimal minimum3 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_updateNum.Minimum = minimum3;
			this.numericUpDown_updateNum.Name = "numericUpDown_updateNum";
			System.Drawing.Size size8 = new System.Drawing.Size(112, 24);
			this.numericUpDown_updateNum.Size = size8;
			this.numericUpDown_updateNum.TabIndex = 4;
			this.numericUpDown_updateNum.TextAlign = HorizontalAlignment.Center;
			decimal value3 = new decimal(new int[]
			{
				64,
				0,
				0,
				0
			});
			this.numericUpDown_updateNum.Value = value3;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(400, 332);
			base.ClientSize = clientSize;
			base.Controls.Add(this.numericUpDown_updateNum);
			base.Controls.Add(this.numericUpDown_zjt);
			base.Controls.Add(this.numericUpDown_csy);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnSubmit);
			base.Controls.Add(this.btnQuit);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin9 = new Padding(2, 2, 2, 2);
			base.Margin = margin9;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormBatchEditIRTPinRelation";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "批量修改测试仪和转接台针脚关系";
			base.Load += new System.EventHandler(this.ctFormBatchEditIRTPinRelation_Load);
			((ISupportInitialize)this.numericUpDown_csy).EndInit();
			((ISupportInitialize)this.numericUpDown_zjt).EndInit();
			((ISupportInitialize)this.numericUpDown_updateNum).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			this.bSubmitFlag = false;
			base.Close();
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			try
			{
				string csyStr = this.numericUpDown_csy.Text.ToString().Trim();
				string zjtStr = this.numericUpDown_zjt.Text.ToString().Trim();
				string uNumStr = this.numericUpDown_updateNum.Text.ToString().Trim();
				if (string.IsNullOrEmpty(csyStr))
				{
					MessageBox.Show("测试仪针脚号(起始)为空!", "提示", MessageBoxButtons.OK);
					return;
				}
				if (string.IsNullOrEmpty(zjtStr))
				{
					MessageBox.Show("转接台针脚号(起始)为空!", "提示", MessageBoxButtons.OK);
					return;
				}
				if (string.IsNullOrEmpty(uNumStr))
				{
					MessageBox.Show("批量修改数量为空!", "提示", MessageBoxButtons.OK);
					return;
				}
				this.iCSYPin = System.Convert.ToInt32(csyStr);
				this.iZJTPin = System.Convert.ToInt32(zjtStr);
				int this2 = System.Convert.ToInt32(uNumStr);
				this.iUpdNum = this2;
				int sender2 = this.gLineTestProcessor.SELF_MAX_COUNT;
				if (sender2 < this.iCSYPin + this2)
				{
					MessageBox.Show("批量修改数量过大，已超出测试仪针脚最大值!", "提示", MessageBoxButtons.OK);
					return;
				}
				if (sender2 < this.iZJTPin + this2)
				{
					MessageBox.Show("批量修改数量过大，已超出转接台针脚号最大值!", "提示", MessageBoxButtons.OK);
					return;
				}
			}
			catch (System.Exception arg_10F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_10F_0.StackTrace);
			}
			this.bSubmitFlag = true;
			base.Close();
		}
		private void ctFormBatchEditIRTPinRelation_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.bSubmitFlag = false;
				this.iCSYPin = 0;
				this.iZJTPin = 0;
				this.iUpdNum = 0;
				decimal e2 = this.gLineTestProcessor.SELF_MAX_COUNT;
				this.numericUpDown_csy.Maximum = e2;
				decimal sender2 = this.gLineTestProcessor.SELF_MAX_COUNT;
				this.numericUpDown_zjt.Maximum = sender2;
				decimal this2 = this.gLineTestProcessor.SELF_MAX_COUNT;
				this.numericUpDown_updateNum.Maximum = this2;
			}
			catch (System.Exception arg_75_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_75_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormBatchEditIRTPinRelation();
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
