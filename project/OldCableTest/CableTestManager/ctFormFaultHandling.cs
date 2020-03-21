using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormFaultHandling : Form
	{
		public int iTime;
		private Label label_ts;
		private Label label_djs;
		private Timer timer1;
		private IContainer components;
		public ctFormFaultHandling()
		{
			try
			{
				this.InitializeComponent();
				this.iTime = 5;
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormFaultHandling()
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
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormFaultHandling));
			this.label_ts = new Label();
			this.label_djs = new Label();
			this.timer1 = new Timer(this.components);
			base.SuspendLayout();
			this.label_ts.AutoSize = true;
			this.label_ts.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Color red = System.Drawing.Color.Red;
			this.label_ts.ForeColor = red;
			System.Drawing.Point location = new System.Drawing.Point(116, 62);
			this.label_ts.Location = location;
			this.label_ts.Name = "label_ts";
			System.Drawing.Size size = new System.Drawing.Size(218, 19);
			this.label_ts.Size = size;
			this.label_ts.TabIndex = 0;
			this.label_ts.Text = "系统出现故障即将关闭!";
			this.label_djs.AutoSize = true;
			this.label_djs.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(168, 145);
			this.label_djs.Location = location2;
			this.label_djs.Name = "label_djs";
			System.Drawing.Size size2 = new System.Drawing.Size(115, 19);
			this.label_djs.Size = size2;
			this.label_djs.TabIndex = 1;
			this.label_djs.Text = "倒计时 5 秒";
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size this2 = new System.Drawing.Size(450, 240);
			base.ClientSize = this2;
			base.Controls.Add(this.label_djs);
			base.Controls.Add(this.label_ts);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormFaultHandling";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "故障处理窗口";
			base.Load += new System.EventHandler(this.ctFormFaultHandling_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			try
			{
				int this2 = this.iTime;
				int sender2 = this2;
				this.iTime = this2 - 1;
				this.label_djs.Text = "倒计时 " + System.Convert.ToString(sender2) + " 秒";
				if (this.iTime <= 0)
				{
					base.Close();
				}
			}
			catch (System.Exception ex_48)
			{
			}
		}
		private void ctFormFaultHandling_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.timer1.Enabled = true;
			}
			catch (System.Exception ex_0E)
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
					this.~ctFormFaultHandling();
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
