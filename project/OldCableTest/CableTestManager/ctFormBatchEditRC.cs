using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormBatchEditRC : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public bool bSubmitFlag;
		public int iStartPin;
		public int iStopPin;
		public double dRCValue;
		public bool bAddRCVFlag;
		public double dAddRCValue;
		private Label label1;
		private Label label2;
		private NumericUpDown numericUpDown_start;
		private NumericUpDown numericUpDown_stop;
		private Label label_updateR;
		private RadioButton radioButton_update;
		private RadioButton radioButton_add;
		private NumericUpDown numericUpDown_rcv;
		private Button btnQuit;
		private Button btnSubmit;
		private Container components;
		public ctFormBatchEditRC(KLineTestProcessor gltProcessor)
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
		private void ~ctFormBatchEditRC()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormBatchEditRC));
			this.label1 = new Label();
			this.label2 = new Label();
			this.numericUpDown_start = new NumericUpDown();
			this.numericUpDown_stop = new NumericUpDown();
			this.label_updateR = new Label();
			this.numericUpDown_rcv = new NumericUpDown();
			this.btnQuit = new Button();
			this.btnSubmit = new Button();
			this.radioButton_update = new RadioButton();
			this.radioButton_add = new RadioButton();
			((ISupportInitialize)this.numericUpDown_start).BeginInit();
			((ISupportInitialize)this.numericUpDown_stop).BeginInit();
			((ISupportInitialize)this.numericUpDown_rcv).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(79, 101);
			this.label1.Location = location;
			this.label1.Name = "label1";
			System.Drawing.Size size = new System.Drawing.Size(191, 19);
			this.label1.Size = size;
			this.label1.TabIndex = 0;
			this.label1.Text = "测试仪针脚号(起始):";
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(79, 160);
			this.label2.Location = location2;
			this.label2.Name = "label2";
			System.Drawing.Size size2 = new System.Drawing.Size(191, 19);
			this.label2.Size = size2;
			this.label2.TabIndex = 0;
			this.label2.Text = "测试仪针脚号(终止):";
			this.numericUpDown_start.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(285, 96);
			this.numericUpDown_start.Location = location3;
			decimal maximum = new decimal(new int[]
			{
				1023,
				0,
				0,
				0
			});
			this.numericUpDown_start.Maximum = maximum;
			decimal minimum = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_start.Minimum = minimum;
			this.numericUpDown_start.Name = "numericUpDown_start";
			System.Drawing.Size size3 = new System.Drawing.Size(180, 28);
			this.numericUpDown_start.Size = size3;
			this.numericUpDown_start.TabIndex = 2;
			this.numericUpDown_start.TextAlign = HorizontalAlignment.Center;
			decimal value = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_start.Value = value;
			this.numericUpDown_stop.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(285, 155);
			this.numericUpDown_stop.Location = location4;
			decimal maximum2 = new decimal(new int[]
			{
				1023,
				0,
				0,
				0
			});
			this.numericUpDown_stop.Maximum = maximum2;
			decimal minimum2 = new decimal(new int[]
			{
				1,
				0,
				0,
				0
			});
			this.numericUpDown_stop.Minimum = minimum2;
			this.numericUpDown_stop.Name = "numericUpDown_stop";
			System.Drawing.Size size4 = new System.Drawing.Size(180, 28);
			this.numericUpDown_stop.Size = size4;
			this.numericUpDown_stop.TabIndex = 3;
			this.numericUpDown_stop.TextAlign = HorizontalAlignment.Center;
			decimal value2 = new decimal(new int[]
			{
				1023,
				0,
				0,
				0
			});
			this.numericUpDown_stop.Value = value2;
			this.label_updateR.AutoSize = true;
			this.label_updateR.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(136, 219);
			this.label_updateR.Location = location5;
			this.label_updateR.Name = "label_updateR";
			System.Drawing.Size size5 = new System.Drawing.Size(134, 19);
			this.label_updateR.Size = size5;
			this.label_updateR.TabIndex = 0;
			this.label_updateR.Text = "补偿电阻(Ω):";
			this.numericUpDown_rcv.DecimalPlaces = 3;
			this.numericUpDown_rcv.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(285, 214);
			this.numericUpDown_rcv.Location = location6;
			decimal maximum3 = new decimal(new int[]
			{
				1000,
				0,
				0,
				0
			});
			this.numericUpDown_rcv.Maximum = maximum3;
			this.numericUpDown_rcv.Name = "numericUpDown_rcv";
			System.Drawing.Size size6 = new System.Drawing.Size(180, 28);
			this.numericUpDown_rcv.Size = size6;
			this.numericUpDown_rcv.TabIndex = 4;
			this.numericUpDown_rcv.TextAlign = HorizontalAlignment.Center;
			decimal value3 = new decimal(new int[]
			{
				10,
				0,
				0,
				65536
			});
			this.numericUpDown_rcv.Value = value3;
			this.btnQuit.Anchor = AnchorStyles.Right;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(345, 293);
			this.btnQuit.Location = location7;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size7 = new System.Drawing.Size(120, 30);
			this.btnQuit.Size = size7;
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btnSubmit.Anchor = AnchorStyles.Right;
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(154, 293);
			this.btnSubmit.Location = location8;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size8 = new System.Drawing.Size(120, 30);
			this.btnSubmit.Size = size8;
			this.btnSubmit.TabIndex = 0;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.radioButton_update.AutoSize = true;
			this.radioButton_update.Checked = true;
			this.radioButton_update.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(154, 34);
			this.radioButton_update.Location = location9;
			this.radioButton_update.Name = "radioButton_update";
			System.Drawing.Size size9 = new System.Drawing.Size(106, 23);
			this.radioButton_update.Size = size9;
			this.radioButton_update.TabIndex = 6;
			this.radioButton_update.TabStop = true;
			this.radioButton_update.Text = "批量修改";
			this.radioButton_update.UseVisualStyleBackColor = true;
			this.radioButton_add.AutoSize = true;
			this.radioButton_add.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location10 = new System.Drawing.Point(320, 34);
			this.radioButton_add.Location = location10;
			this.radioButton_add.Name = "radioButton_add";
			System.Drawing.Size size10 = new System.Drawing.Size(106, 23);
			this.radioButton_add.Size = size10;
			this.radioButton_add.TabIndex = 7;
			this.radioButton_add.Text = "批量追加";
			this.radioButton_add.UseVisualStyleBackColor = true;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(624, 385);
			base.ClientSize = clientSize;
			base.Controls.Add(this.radioButton_add);
			base.Controls.Add(this.radioButton_update);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnSubmit);
			base.Controls.Add(this.numericUpDown_rcv);
			base.Controls.Add(this.numericUpDown_stop);
			base.Controls.Add(this.numericUpDown_start);
			base.Controls.Add(this.label_updateR);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormBatchEditRC";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "批量操作窗口";
			base.Load += new System.EventHandler(this.ctFormBatchEditRC_Load);
			((ISupportInitialize)this.numericUpDown_start).EndInit();
			((ISupportInitialize)this.numericUpDown_stop).EndInit();
			((ISupportInitialize)this.numericUpDown_rcv).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			base.Close();
		}
		private void ctFormBatchEditRC_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.bSubmitFlag = false;
				this.iStartPin = 0;
				this.iStopPin = 0;
				this.dRCValue = 0.0;
				this.bAddRCVFlag = false;
				this.dAddRCValue = 0.0;
				decimal e2 = this.gLineTestProcessor.SELF_MAX_COUNT;
				this.numericUpDown_start.Maximum = e2;
				decimal sender2 = this.gLineTestProcessor.SELF_MAX_COUNT;
				this.numericUpDown_stop.Maximum = sender2;
				decimal this2 = this.gLineTestProcessor.SELF_MAX_COUNT;
				this.numericUpDown_stop.Value = this2;
			}
			catch (System.Exception arg_93_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_93_0.StackTrace);
			}
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			try
			{
				string arg_43_0 = this.numericUpDown_start.Text.ToString().Trim();
				string temp2Str = this.numericUpDown_stop.Text.ToString().Trim();
				string temp3Str = this.numericUpDown_rcv.Text.ToString().Trim();
				if (string.IsNullOrEmpty(arg_43_0) || string.IsNullOrEmpty(temp2Str))
				{
					MessageBox.Show("针脚号不能为空, 请重新输入!", "提示", MessageBoxButtons.OK);
					return;
				}
				if (string.IsNullOrEmpty(temp3Str))
				{
					MessageBox.Show("补偿电阻不能为空, 请重新输入!", "提示", MessageBoxButtons.OK);
					return;
				}
				decimal value = this.numericUpDown_rcv.Value;
				this.dRCValue = System.Convert.ToDouble(value);
				decimal value2 = this.numericUpDown_start.Value;
				this.iStartPin = System.Convert.ToInt32(value2);
				decimal value3 = this.numericUpDown_stop.Value;
				this.iStopPin = System.Convert.ToInt32(value3);
				this.bAddRCVFlag = this.radioButton_add.Checked;
				int sender2 = this.iStartPin;
				int this2 = this.iStopPin;
				if (sender2 > this2)
				{
					int iTemp = sender2;
					this.iStartPin = this2;
					this.iStopPin = iTemp;
				}
				this.bSubmitFlag = true;
			}
			catch (System.Exception arg_113_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_113_0.StackTrace);
				this.bSubmitFlag = false;
			}
			base.Close();
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormBatchEditRC();
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
