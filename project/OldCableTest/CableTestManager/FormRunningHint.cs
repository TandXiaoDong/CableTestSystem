using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class FormRunningHint : Form
	{
		public static int iTimeCount = 3;
		private Label label1;
		private Label label2;
		private Label label_time;
		private Timer timer1;
		private IContainer components;
		public FormRunningHint()
		{
			try
			{
				this.InitializeComponent();
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~FormRunningHint()
		{
			IContainer this2 = this.components;
			if (this2 != null)
			{
				this2.Dispose();
			}
		}
		private void InitializeComponent()
		{
			this.components = new Container();
			this.label1 = new Label();
			this.label2 = new Label();
			this.label_time = new Label();
			this.timer1 = new Timer(this.components);
			base.SuspendLayout();
			this.label1.AutoSize = true;
			System.Drawing.Color transparent = System.Drawing.Color.Transparent;
			this.label1.BackColor = transparent;
			this.label1.Font = new System.Drawing.Font("宋体", 13.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Color red = System.Drawing.Color.Red;
			this.label1.ForeColor = red;
			System.Drawing.Point location = new System.Drawing.Point(39, 22);
			this.label1.Location = location;
			this.label1.Name = "label1";
			System.Drawing.Size size = new System.Drawing.Size(322, 24);
			this.label1.Size = size;
			this.label1.TabIndex = 0;
			this.label1.Text = "程序已经运行,请勿重复运行!";
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(129, 78);
			this.label2.Location = location2;
			this.label2.Name = "label2";
			System.Drawing.Size size2 = new System.Drawing.Size(119, 20);
			this.label2.Size = size2;
			this.label2.TabIndex = 1;
			this.label2.Text = "退出倒计时:";
			this.label_time.AutoSize = true;
			this.label_time.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(252, 78);
			this.label_time.Location = location3;
			this.label_time.Name = "label_time";
			System.Drawing.Size size3 = new System.Drawing.Size(19, 20);
			this.label_time.Size = size3;
			this.label_time.TabIndex = 1;
			this.label_time.Text = "3";
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size this2 = new System.Drawing.Size(400, 120);
			base.ClientSize = this2;
			base.Controls.Add(this.label_time);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "FormRunningHint";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "退出倒计时";
			base.Load += new System.EventHandler(this.FormRunningHint_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			try
			{
				if (FormRunningHint.iTimeCount <= 0)
				{
					base.Close();
				}
				else
				{
					FormRunningHint.iTimeCount--;
					this.label_time.Text = System.Convert.ToString(FormRunningHint.iTimeCount);
				}
			}
			catch (System.Exception ex_35)
			{
			}
		}
		private void FormRunningHint_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.label_time.Text = "3";
				FormRunningHint.iTimeCount = 3;
				this.timer1.Enabled = true;
			}
			catch (System.Exception ex_26)
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
					this.~FormRunningHint();
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
