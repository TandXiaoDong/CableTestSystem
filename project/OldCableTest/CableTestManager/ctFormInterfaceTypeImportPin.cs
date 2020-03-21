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
	public class ctFormInterfaceTypeImportPin : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public string interFaceNoStr;
		public string dbpath;
		public bool bBCKFlag;
		public string measMethodStr;
		public System.Collections.Generic.List<string> connectorNameStrArray;
		private RadioButton radioButton_Pin_FourWire;
		private RadioButton radioButton_Pin_TwoWire;
		private Label label6;
		private CheckBox checkBox_BCK;
		private TextBox textBox_Connector;
		private Label label1;
		private Label label2;
		private ComboBox comboBox_it;
		private Button btnQuit;
		private Button btnImport;
		private Container components;
		public ctFormInterfaceTypeImportPin(KLineTestProcessor gltProcessor)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
					this.gLineTestProcessor = gltProcessor;
					this.interFaceNoStr = "";
					this.bBCKFlag = false;
					this.connectorNameStrArray = new System.Collections.Generic.List<string>();
				}
				catch (System.Exception arg_47_0)
				{
					KLineTestProcessor.ExceptionRecordFunc(arg_47_0.StackTrace);
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormInterfaceTypeImportPin()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormInterfaceTypeImportPin));
			this.label2 = new Label();
			this.comboBox_it = new ComboBox();
			this.btnQuit = new Button();
			this.btnImport = new Button();
			this.textBox_Connector = new TextBox();
			this.label1 = new Label();
			this.checkBox_BCK = new CheckBox();
			this.radioButton_Pin_FourWire = new RadioButton();
			this.radioButton_Pin_TwoWire = new RadioButton();
			this.label6 = new Label();
			base.SuspendLayout();
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(38, 77);
			this.label2.Location = location;
			Padding margin = new Padding(2, 0, 2, 0);
			this.label2.Margin = margin;
			this.label2.Name = "label2";
			System.Drawing.Size size = new System.Drawing.Size(90, 15);
			this.label2.Size = size;
			this.label2.TabIndex = 3;
			this.label2.Text = "连接器型号:";
			this.comboBox_it.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_it.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.comboBox_it.FormattingEnabled = true;
			System.Drawing.Point location2 = new System.Drawing.Point(134, 74);
			this.comboBox_it.Location = location2;
			Padding margin2 = new Padding(2, 2, 2, 2);
			this.comboBox_it.Margin = margin2;
			this.comboBox_it.Name = "comboBox_it";
			System.Drawing.Size size2 = new System.Drawing.Size(211, 22);
			this.comboBox_it.Size = size2;
			this.comboBox_it.TabIndex = 2;
			this.btnQuit.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location3 = new System.Drawing.Point(222, 222);
			this.btnQuit.Location = location3;
			Padding margin3 = new Padding(2, 2, 2, 2);
			this.btnQuit.Margin = margin3;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size3 = new System.Drawing.Size(90, 24);
			this.btnQuit.Size = size3;
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnImport.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.btnImport.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(89, 222);
			this.btnImport.Location = location4;
			Padding margin4 = new Padding(2, 2, 2, 2);
			this.btnImport.Margin = margin4;
			this.btnImport.Name = "btnImport";
			System.Drawing.Size size4 = new System.Drawing.Size(90, 24);
			this.btnImport.Size = size4;
			this.btnImport.TabIndex = 0;
			this.btnImport.Text = "确定";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			this.textBox_Connector.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(134, 26);
			this.textBox_Connector.Location = location5;
			Padding margin5 = new Padding(2, 2, 2, 2);
			this.textBox_Connector.Margin = margin5;
			this.textBox_Connector.Name = "textBox_Connector";
			System.Drawing.Size size5 = new System.Drawing.Size(211, 24);
			this.textBox_Connector.Size = size5;
			this.textBox_Connector.TabIndex = 7;
			this.textBox_Connector.TextChanged += new System.EventHandler(this.textBox_Connector_TextChanged);
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(38, 30);
			this.label1.Location = location6;
			Padding margin6 = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin6;
			this.label1.Name = "label1";
			System.Drawing.Size size6 = new System.Drawing.Size(90, 15);
			this.label1.Size = size6;
			this.label1.TabIndex = 6;
			this.label1.Text = "连接器筛选:";
			this.checkBox_BCK.AutoSize = true;
			this.checkBox_BCK.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(134, 156);
			this.checkBox_BCK.Location = location7;
			Padding margin7 = new Padding(2, 2, 2, 2);
			this.checkBox_BCK.Margin = margin7;
			this.checkBox_BCK.Name = "checkBox_BCK";
			System.Drawing.Size size7 = new System.Drawing.Size(110, 19);
			this.checkBox_BCK.Size = size7;
			this.checkBox_BCK.TabIndex = 28;
			this.checkBox_BCK.Text = "末尾追加BCK";
			this.checkBox_BCK.UseVisualStyleBackColor = true;
			this.checkBox_BCK.Visible = false;
			this.radioButton_Pin_FourWire.Anchor = AnchorStyles.Top;
			this.radioButton_Pin_FourWire.AutoSize = true;
			this.radioButton_Pin_FourWire.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(219, 115);
			this.radioButton_Pin_FourWire.Location = location8;
			Padding margin8 = new Padding(2, 2, 2, 2);
			this.radioButton_Pin_FourWire.Margin = margin8;
			this.radioButton_Pin_FourWire.Name = "radioButton_Pin_FourWire";
			System.Drawing.Size size8 = new System.Drawing.Size(70, 19);
			this.radioButton_Pin_FourWire.Size = size8;
			this.radioButton_Pin_FourWire.TabIndex = 30;
			this.radioButton_Pin_FourWire.Text = "四线法";
			this.radioButton_Pin_FourWire.UseVisualStyleBackColor = true;
			this.radioButton_Pin_TwoWire.Anchor = AnchorStyles.Top;
			this.radioButton_Pin_TwoWire.AutoSize = true;
			this.radioButton_Pin_TwoWire.Checked = true;
			this.radioButton_Pin_TwoWire.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(136, 115);
			this.radioButton_Pin_TwoWire.Location = location9;
			Padding margin9 = new Padding(2, 2, 2, 2);
			this.radioButton_Pin_TwoWire.Margin = margin9;
			this.radioButton_Pin_TwoWire.Name = "radioButton_Pin_TwoWire";
			System.Drawing.Size size9 = new System.Drawing.Size(70, 19);
			this.radioButton_Pin_TwoWire.Size = size9;
			this.radioButton_Pin_TwoWire.TabIndex = 31;
			this.radioButton_Pin_TwoWire.TabStop = true;
			this.radioButton_Pin_TwoWire.Text = "二线法";
			this.radioButton_Pin_TwoWire.UseVisualStyleBackColor = true;
			this.label6.Anchor = AnchorStyles.Top;
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location10 = new System.Drawing.Point(52, 117);
			this.label6.Location = location10;
			Padding margin10 = new Padding(2, 0, 2, 0);
			this.label6.Margin = margin10;
			this.label6.Name = "label6";
			System.Drawing.Size size10 = new System.Drawing.Size(75, 15);
			this.label6.Size = size10;
			this.label6.TabIndex = 29;
			this.label6.Text = "测量方法:";
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(400, 276);
			base.ClientSize = clientSize;
			base.Controls.Add(this.radioButton_Pin_FourWire);
			base.Controls.Add(this.radioButton_Pin_TwoWire);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.checkBox_BCK);
			base.Controls.Add(this.textBox_Connector);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnImport);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.comboBox_it);
			base.Controls.Add(this.label2);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding this2 = new Padding(2, 2, 2, 2);
			base.Margin = this2;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormInterfaceTypeImportPin";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "通过连接器型号导入接点定义";
			base.Load += new System.EventHandler(this.ctFormInterfaceTypeImportPin_Load);
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
				if (this.radioButton_Pin_TwoWire.Checked)
				{
					this.measMethodStr = this.radioButton_Pin_TwoWire.Text.ToString();
				}
				else if (this.radioButton_Pin_FourWire.Checked)
				{
					this.measMethodStr = this.radioButton_Pin_FourWire.Text.ToString();
				}
				this.bBCKFlag = this.checkBox_BCK.Checked;
				this.interFaceNoStr = itTypeStr;
			}
			catch (System.Exception arg_BA_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_BA_0.StackTrace);
			}
			base.Close();
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			this.interFaceNoStr = "";
			base.Close();
		}
		private void ctFormInterfaceTypeImportPin_Load(object sender, System.EventArgs e)
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
					this.~ctFormInterfaceTypeImportPin();
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
