using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CableTestManager
{
	public class ctFormWarningHint : Form
	{
		private PictureBox pictureBox1;
		private IContainer components;
		public ctFormWarningHint()
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
		//private void ~ctFormWarningHint()
		//{
		//	IContainer this2 = this.components;
		//	if (this2 != null)
		//	{
		//		this2.Dispose();
		//	}
		//}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormWarningHint));
			PictureBox this2 = new PictureBox();
			this.pictureBox1 = this2;
			((ISupportInitialize)this2).BeginInit();
			base.SuspendLayout();
			this.pictureBox1.Dock = DockStyle.Fill;
			this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			System.Drawing.Point location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Location = location;
			this.pictureBox1.Name = "pictureBox1";
			System.Drawing.Size size = new System.Drawing.Size(320, 480);
			this.pictureBox1.Size = size;
			this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(320, 480);
			base.ClientSize = clientSize;
			base.Controls.Add(this.pictureBox1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "ctFormWarningHint";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "高压危险";
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					//this.~ctFormWarningHint();
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
