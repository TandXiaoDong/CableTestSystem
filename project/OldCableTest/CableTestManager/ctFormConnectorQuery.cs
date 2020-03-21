using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class ctFormConnectorQuery : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public string interFaceNoStr;
		public string dbpath;
		public System.Collections.Generic.List<string> connectorNameStrArray;
		private TextBox textBox_Connector;
		private Label label1;
		private Label label2;
		private ComboBox comboBox_it;
		private Button btnQuit;
		private Button btnImport;
		private Container components;
		public ctFormConnectorQuery(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.connectorNameStrArray = new System.Collections.Generic.List<string>();
				}
				catch (System.Exception arg_35_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_35_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormConnectorQuery()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormConnectorQuery));
			this.label2 = new Label();
			this.comboBox_it = new ComboBox();
			this.btnQuit = new Button();
			this.btnImport = new Button();
			this.textBox_Connector = new TextBox();
			this.label1 = new Label();
			base.SuspendLayout();
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(50, 96);
			this.label2.Location = location;
			this.label2.Name = "label2";
			System.Drawing.Size size = new System.Drawing.Size(114, 19);
			this.label2.Size = size;
			this.label2.TabIndex = 3;
			this.label2.Text = "连接器型号:";
			this.comboBox_it.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_it.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.comboBox_it.FormattingEnabled = true;
			System.Drawing.Point location2 = new System.Drawing.Point(179, 92);
			this.comboBox_it.Location = location2;
			this.comboBox_it.Name = "comboBox_it";
			System.Drawing.Size size2 = new System.Drawing.Size(280, 26);
			this.comboBox_it.Size = size2;
			this.comboBox_it.TabIndex = 2;
			this.btnQuit.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(296, 176);
			this.btnQuit.Location = location3;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size3 = new System.Drawing.Size(120, 30);
			this.btnQuit.Size = size3;
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnImport.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.btnImport.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(119, 176);
			this.btnImport.Location = location4;
			this.btnImport.Name = "btnImport";
			System.Drawing.Size size4 = new System.Drawing.Size(120, 30);
			this.btnImport.Size = size4;
			this.btnImport.TabIndex = 0;
			this.btnImport.Text = "确定";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			this.textBox_Connector.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(179, 33);
			this.textBox_Connector.Location = location5;
			this.textBox_Connector.Name = "textBox_Connector";
			System.Drawing.Size size5 = new System.Drawing.Size(280, 28);
			this.textBox_Connector.Size = size5;
			this.textBox_Connector.TabIndex = 7;
			this.textBox_Connector.TextChanged += new System.EventHandler(this.textBox_Connector_TextChanged);
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(50, 38);
			this.label1.Location = location6;
			this.label1.Name = "label1";
			System.Drawing.Size size6 = new System.Drawing.Size(114, 19);
			this.label1.Size = size6;
			this.label1.TabIndex = 6;
			this.label1.Text = "连接器筛选:";
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size this2 = new System.Drawing.Size(534, 285);
			base.ClientSize = this2;
			base.Controls.Add(this.textBox_Connector);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnImport);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.comboBox_it);
			base.Controls.Add(this.label2);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormConnectorQuery";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "连接器型号查找";
			base.Load += new System.EventHandler(this.ctFormConnectorQuery_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void btnImport_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.comboBox_it.Items.Count < 0)
				{
					MessageBox.Show("未选择连接器型号!", "提示", MessageBoxButtons.OK);
					return;
				}
				string itTypeStr = this.comboBox_it.Text.ToString();
				if (string.IsNullOrEmpty(itTypeStr))
				{
					MessageBox.Show("未选择连接器型号!", "提示", MessageBoxButtons.OK);
					return;
				}
				this.interFaceNoStr = itTypeStr;
			}
			catch (System.Exception arg_5B_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_5B_0.StackTrace);
			}
			base.Close();
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			this.interFaceNoStr = "";
			base.Close();
		}
		private void ctFormConnectorQuery_Load(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.comboBox_it.Items.Clear();
				this.connectorNameStrArray.Clear();
				try
				{
					connection = new OleDbConnection();
					string dbpath = Application.StartupPath + "\\ctsdb.mdb";
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select * from TConnectorLibrary order by ConnectorName", connection).ExecuteReader();
					while (dataReader.Read())
					{
						this.connectorNameStrArray.Add(dataReader["ConnectorName"].ToString());
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_94_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_94_0.StackTrace);
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
				for (int i = 0; i < this.connectorNameStrArray.Count; i++)
				{
					this.comboBox_it.Items.Add(this.connectorNameStrArray[i]);
				}
			}
			catch (System.Exception arg_EB_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_EB_0.StackTrace);
			}
		}
		public void GLDealwithFunc()
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.comboBox_it.Items.Clear();
				this.connectorNameStrArray.Clear();
				string cNameStr = this.textBox_Connector.Text.ToString().Trim();
				try
				{
					connection = new OleDbConnection();
					string dbpath = Application.StartupPath + "\\ctsdb.mdb";
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand((!string.IsNullOrEmpty(cNameStr)) ? ("select * from TConnectorLibrary where ConnectorName like '%" + cNameStr + "%' order by ConnectorName") : "select * from TConnectorLibrary order by ConnectorName", connection).ExecuteReader();
					while (dataReader.Read())
					{
						this.connectorNameStrArray.Add(dataReader["ConnectorName"].ToString());
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_CA_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_CA_0.StackTrace);
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
				for (int i = 0; i < this.connectorNameStrArray.Count; i++)
				{
					this.comboBox_it.Items.Add(this.connectorNameStrArray[i]);
				}
			}
			catch (System.Exception arg_121_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_121_0.StackTrace);
			}
		}
		private void textBox_Connector_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.GLDealwithFunc();
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
					this.~ctFormConnectorQuery();
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
