using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormBarcodeScanOpenProj : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public bool bOpenProjectFlag;
		public string testProjectNameStr;
		public string dbpath;
		private TextBox textBox_tm;
		private Label label1;
		private Button btnTMSM;
		private Button btnOpenProj;
		private Container components;
		public ctFormBarcodeScanOpenProj(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.bOpenProjectFlag = false;
				}
				catch (System.Exception arg_31_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_31_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormBarcodeScanOpenProj()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormBarcodeScanOpenProj));
			this.textBox_tm = new TextBox();
			this.label1 = new Label();
			this.btnTMSM = new Button();
			this.btnOpenProj = new Button();
			base.SuspendLayout();
			this.textBox_tm.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(132, 51);
			this.textBox_tm.Location = location;
			this.textBox_tm.Name = "textBox_tm";
			System.Drawing.Size size = new System.Drawing.Size(240, 28);
			this.textBox_tm.Size = size;
			this.textBox_tm.TabIndex = 0;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(36, 56);
			this.label1.Location = location2;
			this.label1.Name = "label1";
			System.Drawing.Size size2 = new System.Drawing.Size(76, 19);
			this.label1.Size = size2;
			this.label1.TabIndex = 1;
			this.label1.Text = "项目名:";
			this.btnTMSM.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(402, 50);
			this.btnTMSM.Location = location3;
			Padding margin = new Padding(3, 2, 3, 2);
			this.btnTMSM.Margin = margin;
			this.btnTMSM.Name = "btnTMSM";
			System.Drawing.Size size3 = new System.Drawing.Size(160, 30);
			this.btnTMSM.Size = size3;
			this.btnTMSM.TabIndex = 24;
			this.btnTMSM.Text = "条码扫描";
			this.btnTMSM.UseVisualStyleBackColor = true;
			this.btnTMSM.Click += new System.EventHandler(this.btnTMSM_Click);
			this.btnOpenProj.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(132, 131);
			this.btnOpenProj.Location = location4;
			Padding margin2 = new Padding(3, 2, 3, 2);
			this.btnOpenProj.Margin = margin2;
			this.btnOpenProj.Name = "btnOpenProj";
			System.Drawing.Size size4 = new System.Drawing.Size(430, 30);
			this.btnOpenProj.Size = size4;
			this.btnOpenProj.TabIndex = 24;
			this.btnOpenProj.Text = "打开项目";
			this.btnOpenProj.UseVisualStyleBackColor = true;
			this.btnOpenProj.Click += new System.EventHandler(this.btnOpenProj_Click);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size this2 = new System.Drawing.Size(654, 235);
			base.ClientSize = this2;
			base.Controls.Add(this.btnOpenProj);
			base.Controls.Add(this.btnTMSM);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.textBox_tm);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormBarcodeScanOpenProj";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "扫码快速打开项目";
			base.Load += new System.EventHandler(this.ctFormBarcodeScanOpenProj_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void ctFormBarcodeScanOpenProj_Load(object sender, System.EventArgs e)
		{
		}
		private void btnTMSM_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.textBox_tm.Text = "";
				this.textBox_tm.Focus();
			}
			catch (System.Exception arg_1E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1E_0.StackTrace);
			}
		}
		private void btnOpenProj_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				string projectNameStr = this.textBox_tm.Text.ToString().Trim();
				if (string.IsNullOrEmpty(projectNameStr))
				{
					MessageBox.Show("项目名为空!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					bool bExsitFlag = false;
					try
					{
						connection = new OleDbConnection();
						connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
						connection.Open();
						dataReader = new OleDbCommand("select top 1 * from TProjectInfo where ProjectName = '" + projectNameStr + "'", connection).ExecuteReader();
						if (dataReader.Read())
						{
							bExsitFlag = true;
						}
						dataReader.Close();
						dataReader = null;
						if (!bExsitFlag)
						{
							connection.Close();
							connection = null;
							MessageBox.Show("项目不存在!", "提示", MessageBoxButtons.OK);
						}
						else
						{
							this.bOpenProjectFlag = true;
							this.testProjectNameStr = projectNameStr;
							base.Close();
						}
					}
					catch (System.Exception arg_BE_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_BE_0.StackTrace);
						if (dataReader != null)
						{
							dataReader.Close();
							dataReader = null;
						}
						if (connection != null)
						{
							connection.Close();
							connection = null;
						}
					}
				}
			}
			catch (System.Exception arg_E2_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_E2_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormBarcodeScanOpenProj();
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
