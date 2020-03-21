using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormProjectCopy : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public TProjectInfoStruct projectInfoStruct;
		public string dbpath;
		public bool bCopySuccFlag;
		public int iCopyProjextID;
		private TextBox textBox_copyPN;
		private Label label1;
		private TextBox textBox_CopyXS;
		private Label label2;
		private TextBox textBox_ybcxs;
		private Label label3;
		private Label label_projectName;
		private TextBox textBox_yxmmc;
		private Button btnSubmit;
		private Button btnQuit;
		private Container components;
		public ctFormProjectCopy(KLineTestProcessor gltProcessor, int iPID)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.iCopyProjextID = iPID;
					this.bCopySuccFlag = false;
				}
				catch (System.Exception ex_38)
				{
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormProjectCopy()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			this.label_projectName = new Label();
			this.textBox_yxmmc = new TextBox();
			this.btnSubmit = new Button();
			this.btnQuit = new Button();
			this.textBox_copyPN = new TextBox();
			this.label1 = new Label();
			this.textBox_CopyXS = new TextBox();
			this.label2 = new Label();
			this.textBox_ybcxs = new TextBox();
			this.label3 = new Label();
			base.SuspendLayout();
			this.label_projectName.Anchor = AnchorStyles.Top;
			this.label_projectName.AutoSize = true;
			this.label_projectName.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(39, 32);
			this.label_projectName.Location = location;
			this.label_projectName.Name = "label_projectName";
			System.Drawing.Size size = new System.Drawing.Size(114, 19);
			this.label_projectName.Size = size;
			this.label_projectName.TabIndex = 0;
			this.label_projectName.Text = "原项目名称:";
			this.textBox_yxmmc.Anchor = AnchorStyles.Top;
			this.textBox_yxmmc.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location2 = new System.Drawing.Point(166, 27);
			this.textBox_yxmmc.Location = location2;
			Padding margin = new Padding(3, 2, 3, 2);
			this.textBox_yxmmc.Margin = margin;
			this.textBox_yxmmc.MaxLength = 120;
			this.textBox_yxmmc.Name = "textBox_yxmmc";
			this.textBox_yxmmc.ReadOnly = true;
			System.Drawing.Size size2 = new System.Drawing.Size(320, 28);
			this.textBox_yxmmc.Size = size2;
			this.textBox_yxmmc.TabIndex = 0;
			this.btnSubmit.Anchor = AnchorStyles.Bottom;
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(366, 599);
			this.btnSubmit.Location = location3;
			Padding margin2 = new Padding(3, 2, 3, 2);
			this.btnSubmit.Margin = margin2;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size3 = new System.Drawing.Size(120, 30);
			this.btnSubmit.Size = size3;
			this.btnSubmit.TabIndex = 4;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(575, 599);
			this.btnQuit.Location = location4;
			Padding margin3 = new Padding(3, 2, 3, 2);
			this.btnQuit.Margin = margin3;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size4 = new System.Drawing.Size(120, 30);
			this.btnQuit.Size = size4;
			this.btnQuit.TabIndex = 5;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.textBox_copyPN.Anchor = AnchorStyles.Top;
			this.textBox_copyPN.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(668, 27);
			this.textBox_copyPN.Location = location5;
			Padding margin4 = new Padding(3, 2, 3, 2);
			this.textBox_copyPN.Margin = margin4;
			this.textBox_copyPN.MaxLength = 120;
			this.textBox_copyPN.Name = "textBox_copyPN";
			System.Drawing.Size size5 = new System.Drawing.Size(320, 28);
			this.textBox_copyPN.Size = size5;
			this.textBox_copyPN.TabIndex = 7;
			this.label1.Anchor = AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(523, 32);
			this.label1.Location = location6;
			this.label1.Name = "label1";
			System.Drawing.Size size6 = new System.Drawing.Size(133, 19);
			this.label1.Size = size6;
			this.label1.TabIndex = 6;
			this.label1.Text = "复制项目名称:";
			this.textBox_CopyXS.Anchor = AnchorStyles.Top;
			this.textBox_CopyXS.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(668, 80);
			this.textBox_CopyXS.Location = location7;
			Padding margin5 = new Padding(3, 2, 3, 2);
			this.textBox_CopyXS.Margin = margin5;
			this.textBox_CopyXS.MaxLength = 120;
			this.textBox_CopyXS.Name = "textBox_CopyXS";
			System.Drawing.Size size7 = new System.Drawing.Size(320, 28);
			this.textBox_CopyXS.Size = size7;
			this.textBox_CopyXS.TabIndex = 11;
			this.label2.Anchor = AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(523, 85);
			this.label2.Location = location8;
			this.label2.Name = "label2";
			System.Drawing.Size size8 = new System.Drawing.Size(133, 19);
			this.label2.Size = size8;
			this.label2.TabIndex = 10;
			this.label2.Text = "复制被测线束:";
			this.textBox_ybcxs.Anchor = AnchorStyles.Top;
			this.textBox_ybcxs.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(166, 80);
			this.textBox_ybcxs.Location = location9;
			Padding margin6 = new Padding(3, 2, 3, 2);
			this.textBox_ybcxs.Margin = margin6;
			this.textBox_ybcxs.MaxLength = 120;
			this.textBox_ybcxs.Name = "textBox_ybcxs";
			this.textBox_ybcxs.ReadOnly = true;
			System.Drawing.Size size9 = new System.Drawing.Size(320, 28);
			this.textBox_ybcxs.Size = size9;
			this.textBox_ybcxs.TabIndex = 8;
			this.label3.Anchor = AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location10 = new System.Drawing.Point(39, 85);
			this.label3.Location = location10;
			this.label3.Name = "label3";
			System.Drawing.Size size10 = new System.Drawing.Size(114, 19);
			this.label3.Size = size10;
			this.label3.TabIndex = 9;
			this.label3.Text = "原被测线束:";
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(1060, 665);
			base.ClientSize = clientSize;
			base.Controls.Add(this.textBox_CopyXS);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.textBox_ybcxs);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.textBox_copyPN);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.btnSubmit);
			base.Controls.Add(this.textBox_yxmmc);
			base.Controls.Add(this.label_projectName);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			Padding this2 = new Padding(3, 2, 3, 2);
			base.Margin = this2;
			base.Name = "ctFormProjectCopy";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "复制项目";
			base.Load += new System.EventHandler(this.ctFormProjectCopy_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			this.bCopySuccFlag = false;
			base.Close();
		}
		private void ctFormProjectCopy_Load(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				TProjectInfoStruct tProjectInfoStruct = new TProjectInfoStruct();
				this.projectInfoStruct = tProjectInfoStruct;
				tProjectInfoStruct.Creator = this.gLineTestProcessor.loginUserID;
				bool bExistFlag = false;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select top 1 * from TProjectInfo where ID=" + this.iCopyProjextID, connection).ExecuteReader();
					if (dataReader.Read())
					{
						this.projectInfoStruct.iID = System.Convert.ToInt32(dataReader["ID"].ToString());
						this.projectInfoStruct.ProjectName = dataReader["ProjectName"].ToString();
						this.projectInfoStruct.iCommonProject = System.Convert.ToInt32(dataReader["iCommonProject"].ToString());
						this.projectInfoStruct.iTestModel = System.Convert.ToInt32(dataReader["iTestModel"].ToString());
						this.projectInfoStruct.iDTTestModel = System.Convert.ToInt32(dataReader["iDTTestModel"].ToString());
						this.projectInfoStruct.iJYTestModel = System.Convert.ToInt32(dataReader["iJYTestModel"].ToString());
						this.projectInfoStruct.iNYTestModel = System.Convert.ToInt32(dataReader["iNYTestModel"].ToString());
						this.projectInfoStruct.dDT_Threshold = System.Convert.ToDouble(dataReader["dDT_Threshold"].ToString());
						this.projectInfoStruct.dDT_DTVoltage = System.Convert.ToDouble(dataReader["dDT_DTVoltage"].ToString());
						this.projectInfoStruct.dDT_DTCurrent = System.Convert.ToDouble(dataReader["dDT_DTCurrent"].ToString());
						this.projectInfoStruct.dJY_Threshold = System.Convert.ToDouble(dataReader["dJY_Threshold"].ToString());
						this.projectInfoStruct.dJY_JYHoldTime = System.Convert.ToDouble(dataReader["dJY_JYHoldTime"].ToString());
						this.projectInfoStruct.dJY_DCHighVolt = System.Convert.ToDouble(dataReader["dJY_DCHighVolt"].ToString());
						this.projectInfoStruct.dJY_DCRiseTime = System.Convert.ToDouble(dataReader["dJY_DCRiseTime"].ToString());
						this.projectInfoStruct.dNY_Threshold = System.Convert.ToDouble(dataReader["dNY_Threshold"].ToString());
						this.projectInfoStruct.dNY_NYHoldTime = System.Convert.ToDouble(dataReader["dNY_NYHoldTime"].ToString());
						this.projectInfoStruct.dNY_ACHighVolt = System.Convert.ToDouble(dataReader["dNY_ACHighVolt"].ToString());
						this.projectInfoStruct.other1 = System.Convert.ToDouble(dataReader["other1"].ToString());
						this.projectInfoStruct.other2 = System.Convert.ToDouble(dataReader["other2"].ToString());
						this.projectInfoStruct.iGroupTestFlag = System.Convert.ToInt32(dataReader["iGroupTestFlag"].ToString());
						this.projectInfoStruct.batchMumberStr = dataReader["batchMumberStr"].ToString();
						this.projectInfoStruct.bcCableName = dataReader["bcCableName"].ToString();
						this.projectInfoStruct.Remark = dataReader["Remark"].ToString();
						bExistFlag = true;
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_34D_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_34D_0.StackTrace);
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
				if (bExistFlag)
				{
					this.textBox_yxmmc.Text = this.projectInfoStruct.ProjectName;
					this.textBox_copyPN.Text = this.projectInfoStruct.ProjectName + "_副本";
					this.textBox_ybcxs.Text = this.projectInfoStruct.bcCableName;
					this.textBox_CopyXS.Text = this.projectInfoStruct.bcCableName + "_副本";
				}
			}
			catch (System.Exception arg_3E0_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_3E0_0.StackTrace);
			}
			try
			{
				if (this.gLineTestProcessor.iUIDisplayMode == 0)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
			catch (System.Exception arg_403_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_403_0.StackTrace);
			}
		}
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)]
		public bool DealwithSubmitFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				string newPNStr = this.textBox_copyPN.Text.ToString().Trim();
				if (string.IsNullOrEmpty(newPNStr))
				{
					MessageBox.Show("项目名称为空!", "提示", MessageBoxButtons.OK);
					byte result = 0;
					return result != 0;
				}
				string newXSStr = this.textBox_CopyXS.Text.ToString().Trim();
				if (string.IsNullOrEmpty(newXSStr))
				{
					MessageBox.Show("被测线束为空!", "提示", MessageBoxButtons.OK);
					byte result = 0;
					return result != 0;
				}
				try
				{
					bool bExsitFlag = false;
					try
					{
						connection = new OleDbConnection();
						connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
						connection.Open();
						string sqlcommand = "select top 1 * from TProjectInfo where ProjectName = '" + newPNStr + "'";
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
							connection.Close();
							connection = null;
							MessageBox.Show("项目 " + newPNStr + " 已存在!", "提示", MessageBoxButtons.OK);
							byte result = 0;
							return result != 0;
						}
						sqlcommand = "select top 1 * from TLineStructLibrary where LineStructName = '" + newXSStr + "'";
						cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						if (dataReader.Read())
						{
							bExsitFlag = true;
						}
						dataReader.Close();
						dataReader = null;
						if (bExsitFlag)
						{
							connection.Close();
							connection = null;
							MessageBox.Show("线束 " + newXSStr + " 已存在!", "提示", MessageBoxButtons.OK);
							byte result = 0;
							return result != 0;
						}
						connection.Close();
						connection = null;
					}
					catch (System.Exception arg_17B_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_17B_0.StackTrace);
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
						MessageBox.Show("数据库访问异常!", "提示", MessageBoxButtons.OK);
					}
				}
				catch (System.Exception arg_1B0_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_1B0_0.StackTrace);
				}
			}
			catch (System.Exception arg_1BE_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1BE_0.StackTrace);
			}
			return true;
		}
		public void FreeSystemMemoryResourcesFunc()
		{
			try
			{
				System.GC.Collect();
				System.GC.WaitForPendingFinalizers();
			}
			catch (System.Exception arg_0C_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_0C_0.StackTrace);
			}
		}
		public void CopyProjectDisposeFunc(string oldPNStr, string newPNStr, string oldXSStr, string newXSStr)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			OleDbConnection connection2 = null;
			this.projectInfoStruct.ProjectName = newPNStr;
			this.projectInfoStruct.bcCableName = newXSStr;
			string text = "0";
			string nPIDStr = text;
			string nLIDStr = text;
			string oLIDStr = text;
			System.Collections.Generic.List<GroupTestParaStruct> GTParaStructList = new System.Collections.Generic.List<GroupTestParaStruct>();
			System.Collections.Generic.List<TLineStructLibraryDetailStruct> lsldStructList = new System.Collections.Generic.List<TLineStructLibraryDetailStruct>();
			TLineStructLibraryStruct lslStruct = new TLineStructLibraryStruct();
			lslStruct.LineStructName = this.projectInfoStruct.bcCableName;
			System.Collections.Generic.List<TLineStructJKIDStruct> lsjkIDStructList = new System.Collections.Generic.List<TLineStructJKIDStruct>();
			try
			{
				bool bExsitFlag = false;
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand;
					OleDbCommand cmd;
					try
					{
						sqlcommand = "select * from TLineStructLibrary where LineStructName = '" + oldXSStr + "'";
						cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						if (dataReader.Read())
						{
							bExsitFlag = true;
							lslStruct.LID = dataReader["LID"].ToString();
							lslStruct.PlugInfo = dataReader["PlugInfo"].ToString();
							lslStruct.LinePinNum = System.Convert.ToInt32(dataReader["LinePinNum"].ToString());
							lslStruct.Remark = dataReader["Remark"].ToString();
						}
						dataReader.Close();
						dataReader = null;
						if (bExsitFlag)
						{
							sqlcommand = "select * from TLineStructLibraryDetail where LID = '" + lslStruct.LID + "'";
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							while (dataReader.Read())
							{
								lsldStructList.Add(new TLineStructLibraryDetailStruct
								{
									LID = dataReader["LID"].ToString(),
									PlugName1 = dataReader["PlugName1"].ToString(),
									PinName1 = dataReader["PinName1"].ToString(),
									PlugName2 = dataReader["PlugName2"].ToString(),
									PinName2 = dataReader["PinName2"].ToString(),
									IsGround = System.Convert.ToInt32(dataReader["IsGround"].ToString()),
									IsTestDT = System.Convert.ToInt32(dataReader["IsTestDT"].ToString()),
									IsTestDL = System.Convert.ToInt32(dataReader["IsTestDL"].ToString()),
									IsTestJY = System.Convert.ToInt32(dataReader["IsTestJY"].ToString()),
									IsTestDDJY = System.Convert.ToInt32(dataReader["IsTestDDJY"].ToString()),
									IsTestNY = System.Convert.ToInt32(dataReader["IsTestNY"].ToString())
								});
							}
							dataReader.Close();
							dataReader = null;
							sqlcommand = "select * from TLineStructJKID where LID = '" + lslStruct.LID + "'";
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							while (dataReader.Read())
							{
								lsjkIDStructList.Add(new TLineStructJKIDStruct
								{
									LID = dataReader["LID"].ToString(),
									JKID = dataReader["JKID"].ToString()
								});
							}
							dataReader.Close();
							dataReader = null;
						}
					}
					catch (System.Exception arg_313_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_313_0.StackTrace);
						if (dataReader != null)
						{
							dataReader.Close();
							dataReader = null;
						}
					}
					string lineStructName = lslStruct.LineStructName;
					sqlcommand = "insert into TLineStructLibrary(LineStructName,PlugInfo,LinePinNum,Remark) values('" + lineStructName + "','" + lslStruct.PlugInfo + "'," + lslStruct.LinePinNum + ",'" + lslStruct.Remark + "')";
					cmd = new OleDbCommand(sqlcommand, connection);
					cmd.ExecuteNonQuery();
					System.Threading.Thread.Sleep(50);
					sqlcommand = "select * from TLineStructLibrary where LineStructName = '" + lineStructName + "'";
					cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						nLIDStr = dataReader["LID"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					System.Threading.Thread.Sleep(50);
					try
					{
						if (!string.IsNullOrEmpty(nLIDStr))
						{
							for (int i = 0; i < lsjkIDStructList.Count; i++)
							{
								sqlcommand = "insert into TLineStructJKID(LID,JKID) values('" + nLIDStr + "','" + lsjkIDStructList[i].JKID + "')";
								cmd = new OleDbCommand(sqlcommand, connection);
								cmd.ExecuteNonQuery();
							}
						}
					}
					catch (System.Exception arg_45D_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_45D_0.StackTrace);
					}
					System.Threading.Thread.Sleep(50);
					try
					{
						for (int j = 0; j < lsldStructList.Count; j++)
						{
							sqlcommand = "insert into TLineStructLibraryDetail(LID,PlugName1,PinName1,PlugName2,PinName2,IsGround,IsTestDT,IsTestDL,IsTestJY,IsTestDDJY,IsTestNY) values('" + nLIDStr + "','" + lsldStructList[j].PlugName1 + "','" + lsldStructList[j].PinName1 + "','" + lsldStructList[j].PlugName2 + "','" + lsldStructList[j].PinName2 + "'," + lsldStructList[j].IsGround + "," + lsldStructList[j].IsTestDT + "," + lsldStructList[j].IsTestDL + "," + lsldStructList[j].IsTestJY + "," + lsldStructList[j].IsTestDDJY + "," + lsldStructList[j].IsTestNY + ")";
							cmd = new OleDbCommand(sqlcommand, connection);
							cmd.ExecuteNonQuery();
						}
					}
					catch (System.Exception arg_5F5_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_5F5_0.StackTrace);
					}
					System.Threading.Thread.Sleep(50);
					TProjectInfoStruct oldPNStr2 = this.projectInfoStruct;
					string str = "','";
					string str2 = ",";
					sqlcommand = "insert into TProjectInfo(ProjectName,iCommonProject,iTestModel,iDTTestModel,iJYTestModel,iNYTestModel,dDT_Threshold,dDT_DTVoltage,dDT_DTCurrent,dJY_Threshold," + "dJY_JYHoldTime,dJY_DCHighVolt,dJY_DCRiseTime,dNY_Threshold,dNY_NYHoldTime,dNY_ACHighVolt,other1,other2,iGroupTestFlag,batchMumberStr,bcCableName,Creator,Remark) values('" + oldPNStr2.ProjectName + "'," + oldPNStr2.iCommonProject + str2 + oldPNStr2.iTestModel + str2 + oldPNStr2.iDTTestModel + str2 + oldPNStr2.iJYTestModel + str2 + oldPNStr2.iNYTestModel + str2 + oldPNStr2.dDT_Threshold + str2 + oldPNStr2.dDT_DTVoltage + str2 + oldPNStr2.dDT_DTCurrent + str2 + oldPNStr2.dJY_Threshold + str2 + oldPNStr2.dJY_JYHoldTime + str2 + oldPNStr2.dJY_DCHighVolt + str2 + oldPNStr2.dJY_DCRiseTime + str2 + oldPNStr2.dNY_Threshold + str2 + oldPNStr2.dNY_NYHoldTime + str2 + oldPNStr2.dNY_ACHighVolt + str2 + oldPNStr2.other1 + str2 + oldPNStr2.other2 + str2 + oldPNStr2.iGroupTestFlag + ",'" + oldPNStr2.batchMumberStr + str + oldPNStr2.bcCableName + str + oldPNStr2.Creator + str + oldPNStr2.Remark + "')";
					cmd = new OleDbCommand(sqlcommand, connection);
					cmd.ExecuteNonQuery();
					System.Threading.Thread.Sleep(100);
					sqlcommand = "select top 1 * from TProjectInfo where ProjectName = '" + newPNStr + "'";
					cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						nPIDStr = dataReader["ID"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					sqlcommand = "select top 1 * from TLineStructLibrary where LineStructName = '" + oldXSStr + "'";
					cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
						oLIDStr = dataReader["LID"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					if (this.projectInfoStruct.iGroupTestFlag == 1)
					{
						try
						{
							sqlcommand = "select * from TGroupTestParaSet where PID='" + System.Convert.ToString(this.iCopyProjextID) + "' and LID='" + oLIDStr + "' order by ID asc";
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							while (dataReader.Read())
							{
								GTParaStructList.Add(new GroupTestParaStruct
								{
									PlugName1 = dataReader["PlugName1"].ToString(),
									PinName1 = dataReader["PinName1"].ToString(),
									PlugName2 = dataReader["PlugName2"].ToString(),
									PinName2 = dataReader["PinName2"].ToString(),
									DTThreshold = dataReader["DTThreshold"].ToString(),
									DTVoltage = dataReader["DTVoltage"].ToString(),
									DTCurrent = dataReader["DTCurrent"].ToString(),
									JYThreshold = dataReader["JYThreshold"].ToString(),
									JYTestTime = dataReader["JYTestTime"].ToString(),
									JYVoltage = dataReader["JYVoltage"].ToString(),
									JYUpTime = dataReader["JYUpTime"].ToString(),
									NYThreshold = dataReader["NYThreshold"].ToString(),
									NYTestTime = dataReader["NYTestTime"].ToString(),
									NYVoltage = dataReader["NYVoltage"].ToString()
								});
							}
							dataReader.Close();
							dataReader = null;
							for (int k = 0; k < GTParaStructList.Count; k++)
							{
								str = "','";
								sqlcommand = "insert into TGroupTestParaSet(PID,LID,PlugName1,PinName1,PlugName2,PinName2,DTThreshold,DTVoltage," + "DTCurrent,JYThreshold,JYTestTime,JYVoltage,JYUpTime,NYThreshold,NYTestTime,NYVoltage) values('" + nPIDStr + str + nLIDStr + str + GTParaStructList[k].PlugName1 + "','" + GTParaStructList[k].PinName1 + "','" + GTParaStructList[k].PlugName2 + "','" + GTParaStructList[k].PinName2 + "','" + GTParaStructList[k].DTThreshold + "','" + GTParaStructList[k].DTVoltage + "','" + GTParaStructList[k].DTCurrent + "','" + GTParaStructList[k].JYThreshold + "','" + GTParaStructList[k].JYTestTime + "','" + GTParaStructList[k].JYVoltage + "','" + GTParaStructList[k].JYUpTime + "','" + GTParaStructList[k].NYThreshold + "','" + GTParaStructList[k].NYTestTime + "','" + GTParaStructList[k].NYVoltage + "')";
								cmd = new OleDbCommand(sqlcommand, connection);
								cmd.ExecuteNonQuery();
							}
						}
						catch (System.Exception arg_C88_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_C88_0.StackTrace);
							if (dataReader != null)
							{
								dataReader.Close();
								dataReader = null;
							}
						}
					}
					connection.Close();
					connection = null;
					this.bCopySuccFlag = true;
				}
				catch (System.Exception arg_CB9_0)
				{
					this.bCopySuccFlag = false;
					KLineTestProcessor.ExceptionRecordFunc(arg_CB9_0.StackTrace);
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
			catch (System.Exception arg_CE7_0)
			{
				this.bCopySuccFlag = false;
				KLineTestProcessor.ExceptionRecordFunc(arg_CE7_0.StackTrace);
			}
			GTParaStructList.Clear();
			lsldStructList.Clear();
			lsjkIDStructList.Clear();
			this.FreeSystemMemoryResourcesFunc();
			if (!this.bCopySuccFlag)
			{
				try
				{
					connection2 = new OleDbConnection();
					connection2.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection2.Open();
					string sqlcommand2 = "delete from TLineStructLibrary where LineStructName = '" + newXSStr + "'";
					OleDbCommand cmd2 = new OleDbCommand(sqlcommand2, connection2);
					cmd2.ExecuteNonQuery();
					System.Threading.Thread.Sleep(50);
					sqlcommand2 = "delete from TLineStructLibraryDetail where LID = '" + nLIDStr + "'";
					cmd2 = new OleDbCommand(sqlcommand2, connection2);
					cmd2.ExecuteNonQuery();
					System.Threading.Thread.Sleep(50);
					sqlcommand2 = "delete from TLineStructJKID where LID = '" + nLIDStr + "'";
					cmd2 = new OleDbCommand(sqlcommand2, connection2);
					cmd2.ExecuteNonQuery();
					System.Threading.Thread.Sleep(50);
					sqlcommand2 = "delete from TProjectInfo where ProjectName = '" + newPNStr + "'";
					cmd2 = new OleDbCommand(sqlcommand2, connection2);
					cmd2.ExecuteNonQuery();
					System.Threading.Thread.Sleep(50);
					sqlcommand2 = "delete from TGroupTestParaSet where PID='" + nPIDStr + "' and LID='" + nLIDStr + "'";
					cmd2 = new OleDbCommand(sqlcommand2, connection2);
					cmd2.ExecuteNonQuery();
					connection2.Close();
					connection2 = null;
				}
				catch (System.Exception arg_E48_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_E48_0.StackTrace);
					if (connection2 != null)
					{
						connection2.Close();
					}
				}
			}
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.DealwithSubmitFunc())
				{
					return;
				}
				string newPNStr = this.textBox_copyPN.Text.ToString().Trim();
				string newXSStr = this.textBox_CopyXS.Text.ToString().Trim();
				string oldPNStr = this.textBox_yxmmc.Text.ToString().Trim();
				string oldXSStr = this.textBox_ybcxs.Text.ToString().Trim();
				this.CopyProjectDisposeFunc(oldPNStr, newPNStr, oldXSStr, newXSStr);
				if (this.bCopySuccFlag)
				{
					MessageBox.Show("项目复制成功!", "提示", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("项目复制失败!", "提示", MessageBoxButtons.OK);
				}
			}
			catch (System.Exception arg_9D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_9D_0.StackTrace);
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
					this.~ctFormProjectCopy();
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
