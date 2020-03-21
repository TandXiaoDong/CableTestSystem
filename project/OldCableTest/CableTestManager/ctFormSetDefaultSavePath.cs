using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormSetDefaultSavePath : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public bool bSubmitFlag;
		public string reportDefaultSavePathStr;
		private FolderBrowserDialog folderBrowserDialog1;
		private Label label1;
		private TextBox textBox_savePath;
		private Button btnSelectSavePath;
		private Button btnSubmit;
		private Button btnQuit;
		private Container components;
		public ctFormSetDefaultSavePath(string savePathStr)
		{
			try
			{
				this.InitializeComponent();
				this.reportDefaultSavePathStr = savePathStr;
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormSetDefaultSavePath()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormSetDefaultSavePath));
			this.folderBrowserDialog1 = new FolderBrowserDialog();
			this.label1 = new Label();
			this.textBox_savePath = new TextBox();
			this.btnSelectSavePath = new Button();
			this.btnSubmit = new Button();
			this.btnQuit = new Button();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(50, 65);
			this.label1.Location = location;
			this.label1.Name = "label1";
			System.Drawing.Size size = new System.Drawing.Size(95, 19);
			this.label1.Size = size;
			this.label1.TabIndex = 0;
			this.label1.Text = "保存路径:";
			this.textBox_savePath.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(155, 60);
			this.textBox_savePath.Location = location2;
			this.textBox_savePath.Name = "textBox_savePath";
			this.textBox_savePath.ReadOnly = true;
			System.Drawing.Size size2 = new System.Drawing.Size(450, 28);
			this.textBox_savePath.Size = size2;
			this.textBox_savePath.TabIndex = 2;
			this.btnSelectSavePath.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(54, 127);
			this.btnSelectSavePath.Location = location3;
			this.btnSelectSavePath.Name = "btnSelectSavePath";
			System.Drawing.Size size3 = new System.Drawing.Size(551, 30);
			this.btnSelectSavePath.Size = size3;
			this.btnSelectSavePath.TabIndex = 3;
			this.btnSelectSavePath.Text = "选择默认保存路径";
			this.btnSelectSavePath.UseVisualStyleBackColor = true;
			this.btnSelectSavePath.Click += new System.EventHandler(this.btnSelectSavePath_Click);
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(155, 289);
			this.btnSubmit.Location = location4;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size4 = new System.Drawing.Size(150, 30);
			this.btnSubmit.Size = size4;
			this.btnSubmit.TabIndex = 0;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(383, 289);
			this.btnQuit.Location = location5;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size5 = new System.Drawing.Size(150, 30);
			this.btnQuit.Size = size5;
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size this2 = new System.Drawing.Size(654, 385);
			base.ClientSize = this2;
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnSubmit);
			base.Controls.Add(this.btnSelectSavePath);
			base.Controls.Add(this.textBox_savePath);
			base.Controls.Add(this.label1);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormSetDefaultSavePath";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "默认保存路径设置";
			base.Load += new System.EventHandler(this.ctFormSetDefaultSavePath_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void ctFormSetDefaultSavePath_Load(object sender, System.EventArgs e)
		{
			this.textBox_savePath.Text = this.reportDefaultSavePathStr;
			this.bSubmitFlag = false;
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
				string tempStr = this.textBox_savePath.Text.ToString().Trim();
				if (string.IsNullOrEmpty(tempStr))
				{
					MessageBox.Show("没有选择保存路径!", "提示", MessageBoxButtons.OK);
					return;
				}
				this.reportDefaultSavePathStr = tempStr;
			}
			catch (System.Exception arg_3A_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3A_0.StackTrace);
			}
			this.bSubmitFlag = true;
			base.Close();
		}
		private void btnSelectSavePath_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (DialogResult.OK == this.folderBrowserDialog1.ShowDialog(this))
				{
					string pathStr = this.folderBrowserDialog1.SelectedPath.ToString();
					if (!string.IsNullOrEmpty(pathStr))
					{
						this.textBox_savePath.Text = pathStr;
					}
				}
			}
			catch (System.Exception arg_36_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_36_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormSetDefaultSavePath();
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
