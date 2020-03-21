using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormReportFormatSet : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public int iReportTemplateFormat;
		private Button btnQuit;
		private Button btnSubmit;
		private GroupBox groupBox2;
		private RadioButton radioButton_ShowFormat_Mea;
		private RadioButton radioButton_ShowFormat_Err;
		private RadioButton radioButton_ShowFormat_All;
		private Container components;
		public ctFormReportFormatSet(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.gLineTestProcessor = gltProcessor;
				}
				catch (System.Exception ex_15)
				{
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormReportFormatSet()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormReportFormatSet));
			this.btnQuit = new Button();
			this.btnSubmit = new Button();
			this.groupBox2 = new GroupBox();
			this.radioButton_ShowFormat_Mea = new RadioButton();
			this.radioButton_ShowFormat_Err = new RadioButton();
			this.radioButton_ShowFormat_All = new RadioButton();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(389, 429);
			this.btnQuit.Location = location;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size = new System.Drawing.Size(120, 30);
			this.btnQuit.Size = size;
			this.btnQuit.TabIndex = 3;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btnSubmit.Anchor = AnchorStyles.Bottom;
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(209, 429);
			this.btnSubmit.Location = location2;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size2 = new System.Drawing.Size(120, 30);
			this.btnSubmit.Size = size2;
			this.btnSubmit.TabIndex = 2;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.groupBox2.Controls.Add(this.radioButton_ShowFormat_Mea);
			this.groupBox2.Controls.Add(this.radioButton_ShowFormat_Err);
			this.groupBox2.Controls.Add(this.radioButton_ShowFormat_All);
			this.groupBox2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(37, 47);
			this.groupBox2.Location = location3;
			this.groupBox2.Name = "groupBox2";
			System.Drawing.Size size3 = new System.Drawing.Size(640, 320);
			this.groupBox2.Size = size3;
			this.groupBox2.TabIndex = 34;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "报表默认格式设置";
			this.radioButton_ShowFormat_Mea.AutoSize = true;
			System.Drawing.Point location4 = new System.Drawing.Point(239, 216);
			this.radioButton_ShowFormat_Mea.Location = location4;
			this.radioButton_ShowFormat_Mea.Name = "radioButton_ShowFormat_Mea";
			System.Drawing.Size size4 = new System.Drawing.Size(163, 23);
			this.radioButton_ShowFormat_Mea.Size = size4;
			this.radioButton_ShowFormat_Mea.TabIndex = 1;
			this.radioButton_ShowFormat_Mea.Text = "仅显示测量数据";
			this.radioButton_ShowFormat_Mea.UseVisualStyleBackColor = true;
			this.radioButton_ShowFormat_Err.AutoSize = true;
			System.Drawing.Point location5 = new System.Drawing.Point(239, 149);
			this.radioButton_ShowFormat_Err.Location = location5;
			this.radioButton_ShowFormat_Err.Name = "radioButton_ShowFormat_Err";
			System.Drawing.Size size5 = new System.Drawing.Size(163, 23);
			this.radioButton_ShowFormat_Err.Size = size5;
			this.radioButton_ShowFormat_Err.TabIndex = 1;
			this.radioButton_ShowFormat_Err.Text = "仅显示异常数据";
			this.radioButton_ShowFormat_Err.UseVisualStyleBackColor = true;
			this.radioButton_ShowFormat_All.AutoSize = true;
			this.radioButton_ShowFormat_All.Checked = true;
			System.Drawing.Point location6 = new System.Drawing.Point(239, 82);
			this.radioButton_ShowFormat_All.Location = location6;
			this.radioButton_ShowFormat_All.Name = "radioButton_ShowFormat_All";
			System.Drawing.Size size6 = new System.Drawing.Size(144, 23);
			this.radioButton_ShowFormat_All.Size = size6;
			this.radioButton_ShowFormat_All.TabIndex = 1;
			this.radioButton_ShowFormat_All.TabStop = true;
			this.radioButton_ShowFormat_All.Text = "显示所有数据";
			this.radioButton_ShowFormat_All.UseVisualStyleBackColor = true;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size this2 = new System.Drawing.Size(714, 505);
			base.ClientSize = this2;
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnSubmit);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormReportFormatSet";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "报表默认格式设置";
			base.Load += new System.EventHandler(this.ctFormReportFormatSet_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			base.ResumeLayout(false);
		}
		public void LoadDefaultParaFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				bool bExsitFlag = false;
				string dbpath = Application.StartupPath + "\\ctsdb.mdb";
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select * from TReportParaSet", connection).ExecuteReader();
					if (dataReader.Read())
					{
						bExsitFlag = true;
						this.iReportTemplateFormat = System.Convert.ToInt32(dataReader["iReportTemplateFormat"].ToString());
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_7C_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_7C_0.StackTrace);
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
				if (bExsitFlag)
				{
					int num = this.iReportTemplateFormat;
					if (num == 0)
					{
						this.radioButton_ShowFormat_All.Checked = true;
					}
					else if (num == 1)
					{
						this.radioButton_ShowFormat_Err.Checked = true;
					}
					else if (num == 2)
					{
						this.radioButton_ShowFormat_Mea.Checked = true;
					}
				}
			}
			catch (System.Exception arg_DD_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_DD_0.StackTrace);
			}
		}
		private void ctFormReportFormatSet_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.LoadDefaultParaFunc();
			}
			catch (System.Exception arg_08_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_08_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool DealwithSubmitFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				if (this.radioButton_ShowFormat_All.Checked)
				{
					this.iReportTemplateFormat = 0;
				}
				else if (this.radioButton_ShowFormat_Err.Checked)
				{
					this.iReportTemplateFormat = 1;
				}
				else if (this.radioButton_ShowFormat_Mea.Checked)
				{
					this.iReportTemplateFormat = 2;
				}
				bool bExsitFlag = false;
				string dbpath = Application.StartupPath + "\\ctsdb.mdb";
				bool result;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "select top 1 * from TReportParaSet";
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						bExsitFlag = true;
					}
					dataReader.Close();
					dataReader = null;
					if (bExsitFlag)
					{
						sqlcommand = "update TReportParaSet set iReportTemplateFormat = " + this.iReportTemplateFormat;
					}
					else
					{
						sqlcommand = "insert into TReportParaSet(iReportTemplateFormat) values(" + this.iReportTemplateFormat + ")";
					}
					cmd = new OleDbCommand(sqlcommand, connection);
					cmd.ExecuteNonQuery();
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_F2_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_F2_0.StackTrace);
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
					result = false;
					goto IL_119;
				}
				return true;
				IL_119:
				return result;
			}
			catch (System.Exception arg_11F_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_11F_0.StackTrace);
				return false;
			}
			return true;
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.DealwithSubmitFunc())
				{
					MessageBox.Show("操作失败!", "提示", MessageBoxButtons.OK);
					return;
				}
			}
			catch (System.Exception arg_1D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1D_0.StackTrace);
			}
			base.Close();
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			try
			{
				base.Close();
			}
			catch (System.Exception arg_08_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_08_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormReportFormatSet();
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
