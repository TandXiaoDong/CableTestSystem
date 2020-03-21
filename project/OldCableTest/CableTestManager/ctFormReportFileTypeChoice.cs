using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormReportFileTypeChoice : Form
	{
		public int iFileType;
		private RadioButton radioButton_Word;
		private RadioButton radioButton_Pdf;
		private Button btnOK;
		private Container components;
		public ctFormReportFileTypeChoice(int iFType)
		{
			try
			{
				this.InitializeComponent();
				this.iFileType = iFType;
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormReportFileTypeChoice()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormReportFileTypeChoice));
			this.radioButton_Word = new RadioButton();
			this.radioButton_Pdf = new RadioButton();
			this.btnOK = new Button();
			base.SuspendLayout();
			this.radioButton_Word.AutoSize = true;
			this.radioButton_Word.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(105, 57);
			this.radioButton_Word.Location = location;
			this.radioButton_Word.Name = "radioButton_Word";
			System.Drawing.Size size = new System.Drawing.Size(108, 23);
			this.radioButton_Word.Size = size;
			this.radioButton_Word.TabIndex = 0;
			this.radioButton_Word.Text = "WORD文档";
			this.radioButton_Word.UseVisualStyleBackColor = true;
			this.radioButton_Pdf.AutoSize = true;
			this.radioButton_Pdf.Checked = true;
			this.radioButton_Pdf.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(262, 57);
			this.radioButton_Pdf.Location = location2;
			this.radioButton_Pdf.Name = "radioButton_Pdf";
			System.Drawing.Size size2 = new System.Drawing.Size(98, 23);
			this.radioButton_Pdf.Size = size2;
			this.radioButton_Pdf.TabIndex = 0;
			this.radioButton_Pdf.TabStop = true;
			this.radioButton_Pdf.Text = "PDF文档";
			this.radioButton_Pdf.UseVisualStyleBackColor = true;
			this.btnOK.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(171, 156);
			this.btnOK.Location = location3;
			this.btnOK.Name = "btnOK";
			System.Drawing.Size size3 = new System.Drawing.Size(120, 30);
			this.btnOK.Size = size3;
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "确定";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size this2 = new System.Drawing.Size(474, 265);
			base.ClientSize = this2;
			base.Controls.Add(this.btnOK);
			base.Controls.Add(this.radioButton_Pdf);
			base.Controls.Add(this.radioButton_Word);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormReportFileTypeChoice";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "报表文件类型选择";
			base.Load += new System.EventHandler(this.ctFormReportFileTypeChoice_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.radioButton_Word.Checked)
				{
					this.iFileType = 0;
				}
				else if (this.radioButton_Pdf.Checked)
				{
					this.iFileType = 1;
				}
			}
			catch (System.Exception ex_2C)
			{
			}
			base.Close();
		}
		private void ctFormReportFileTypeChoice_Load(object sender, System.EventArgs e)
		{
			try
			{
				if (this.iFileType == 0)
				{
					this.radioButton_Word.Checked = true;
				}
				else
				{
					this.radioButton_Pdf.Checked = true;
				}
			}
			catch (System.Exception ex_24)
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
					this.~ctFormReportFileTypeChoice();
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
