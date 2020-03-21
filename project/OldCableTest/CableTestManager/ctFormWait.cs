using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormWait : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public string uiShowStr;
		public int iShowStep;
		public int iShowType;
		public bool bCloseFlag;
		public bool bSuccFlag;
		public bool bRelayFlag;
		public int iCount;
		private Label label_ShowStr;
		private Timer timer1;
		private IContainer components;
		public ctFormWait(int iType)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.iShowType = iType;
					this.bCloseFlag = false;
					this.bSuccFlag = true;
					this.iCount = 0;
				}
				catch (System.Exception ex_2A)
				{
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormWait()
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
			this.label_ShowStr = new Label();
			this.timer1 = new Timer(this.components);
			base.SuspendLayout();
			this.label_ShowStr.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
			this.label_ShowStr.Font = new System.Drawing.Font("宋体", 22.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(9, 276);
			this.label_ShowStr.Location = location;
			Padding margin = new Padding(2, 0, 2, 0);
			this.label_ShowStr.Margin = margin;
			this.label_ShowStr.Name = "label_ShowStr";
			System.Drawing.Size size = new System.Drawing.Size(782, 48);
			this.label_ShowStr.Size = size;
			this.label_ShowStr.TabIndex = 0;
			this.label_ShowStr.Text = "正在生成报表，请稍等..";
			this.label_ShowStr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(800, 600);
			base.ClientSize = clientSize;
			base.Controls.Add(this.label_ShowStr);
			base.FormBorderStyle = FormBorderStyle.None;
			Padding this2 = new Padding(2, 2, 2, 2);
			base.Margin = this2;
			base.Name = "ctFormWait";
			base.Opacity = 0.99;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "ctFormWait";
			base.Load += new System.EventHandler(this.ctFormWait_Load);
			base.ResumeLayout(false);
		}
		private void ctFormWait_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.bRelayFlag = true;
				this.timer1.Enabled = true;
				switch (this.iShowType)
				{
				case 1:
					this.uiShowStr = "生成报表中，请稍等..";
					goto IL_201;
				case 2:
					this.uiShowStr = "打印报表中，请稍等..";
					goto IL_201;
				case 3:
					this.uiShowStr = "项目复制中，请稍等..";
					goto IL_201;
				case 100:
					this.uiShowStr = "正在更新数据库，请稍等..";
					this.timer1.Interval = 3000;
					goto IL_201;
				}
				this.uiShowStr = "请稍等..";
				IL_201:
				this.label_ShowStr.Text = this.uiShowStr;
			}
			catch (System.Exception arg_214_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_214_0.StackTrace);
			}
		}
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			try
			{
				if (this.bCloseFlag)
				{
					if (this.bRelayFlag)
					{
						this.bRelayFlag = false;
					}
					else
					{
						this.timer1.Enabled = false;
						base.Close();
					}
				}
			}
			catch (System.Exception arg_2D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2D_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormWait();
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
