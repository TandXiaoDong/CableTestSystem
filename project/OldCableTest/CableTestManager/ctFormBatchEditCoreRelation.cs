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
	public class ctFormBatchEditCoreRelation : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public string dbpath;
		public string _strStartIFBH_s;
		public string _strStartPin_s;
		public string _strStopIFBH_s;
		public string _strStopPin_s;
		public bool bIsGroundFlag_s;
		public bool bJYTestFlag_s;
		public bool bDDJYTestFlag_s;
		public bool bDLTestFlag_s;
		public bool bNYTestFlag_s;
		public string[] strCoreArray;
		public string loginUser;
		public bool bSuccFlag;
		public bool bUpdateAllPlugFlag;
		public System.Collections.Generic.List<int> startPinMeasMethodList;
		public System.Collections.Generic.List<string> startPinStrList;
		public System.Collections.Generic.List<string> batchEditPinStrList;
		private RadioButton radioButton_Pin_FourWire;
		private RadioButton radioButton_Pin_TwoWire;
		private Label label1;
		private CheckBox checkBox_nyTestFlag;
		private ComboBox comboBox_startPin;
		private ComboBox comboBox_stopPin;
		private ComboBox comboBox_startIFBH;
		private CheckBox checkBox_dlTestFlag;
		private CheckBox checkBox_ddjyTestFlag;
		private CheckBox checkBox_dtTestFlag;
		private CheckBox checkBox_jyTestFlag;
		private CheckBox checkBox_isGroundFlag;
		private Label label6;
		private Label label5;
		private Label label3;
		private Button btnSubmit;
		private Button btnQuit;
		private Container components;
		public ctFormBatchEditCoreRelation(KLineTestProcessor gltProcessor, string lUser, string[] strCRArray)
		{
			try
			{
				this.InitializeComponent();
				this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
				this.gLineTestProcessor = gltProcessor;
				this.loginUser = lUser;
				if (strCRArray != null)
				{
					this.strCoreArray = new string[strCRArray.Length];
					int i = 0;
					if (0 < strCRArray.Length)
					{
						do
						{
							this.strCoreArray[i] = strCRArray[i];
							i++;
						}
						while (i < strCRArray.Length);
					}
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormBatchEditCoreRelation()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormBatchEditCoreRelation));
			this.comboBox_startPin = new ComboBox();
			this.comboBox_stopPin = new ComboBox();
			this.comboBox_startIFBH = new ComboBox();
			this.checkBox_dtTestFlag = new CheckBox();
			this.checkBox_jyTestFlag = new CheckBox();
			this.checkBox_isGroundFlag = new CheckBox();
			this.label6 = new Label();
			this.label5 = new Label();
			this.label3 = new Label();
			this.btnSubmit = new Button();
			this.btnQuit = new Button();
			this.checkBox_dlTestFlag = new CheckBox();
			this.checkBox_ddjyTestFlag = new CheckBox();
			this.checkBox_nyTestFlag = new CheckBox();
			this.radioButton_Pin_FourWire = new RadioButton();
			this.radioButton_Pin_TwoWire = new RadioButton();
			this.label1 = new Label();
			base.SuspendLayout();
			this.comboBox_startPin.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_startPin.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.comboBox_startPin.FormattingEnabled = true;
			System.Drawing.Point location = new System.Drawing.Point(164, 117);
			this.comboBox_startPin.Location = location;
			Padding margin = new Padding(3, 2, 3, 2);
			this.comboBox_startPin.Margin = margin;
			this.comboBox_startPin.Name = "comboBox_startPin";
			System.Drawing.Size size = new System.Drawing.Size(250, 26);
			this.comboBox_startPin.Size = size;
			this.comboBox_startPin.TabIndex = 3;
			this.comboBox_stopPin.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_stopPin.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.comboBox_stopPin.FormattingEnabled = true;
			System.Drawing.Point location2 = new System.Drawing.Point(164, 165);
			this.comboBox_stopPin.Location = location2;
			Padding margin2 = new Padding(3, 2, 3, 2);
			this.comboBox_stopPin.Margin = margin2;
			this.comboBox_stopPin.Name = "comboBox_stopPin";
			System.Drawing.Size size2 = new System.Drawing.Size(250, 26);
			this.comboBox_stopPin.Size = size2;
			this.comboBox_stopPin.TabIndex = 4;
			this.comboBox_startIFBH.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_startIFBH.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.comboBox_startIFBH.FormattingEnabled = true;
			System.Drawing.Point location3 = new System.Drawing.Point(164, 21);
			this.comboBox_startIFBH.Location = location3;
			Padding margin3 = new Padding(3, 2, 3, 2);
			this.comboBox_startIFBH.Margin = margin3;
			this.comboBox_startIFBH.Name = "comboBox_startIFBH";
			System.Drawing.Size size3 = new System.Drawing.Size(250, 26);
			this.comboBox_startIFBH.Size = size3;
			this.comboBox_startIFBH.TabIndex = 2;
			this.comboBox_startIFBH.SelectedIndexChanged += new System.EventHandler(this.comboBox_startIFBH_SelectedIndexChanged);
			this.checkBox_dtTestFlag.AutoSize = true;
			this.checkBox_dtTestFlag.Checked = true;
			this.checkBox_dtTestFlag.CheckState = CheckState.Checked;
			this.checkBox_dtTestFlag.Enabled = false;
			this.checkBox_dtTestFlag.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location4 = new System.Drawing.Point(164, 274);
			this.checkBox_dtTestFlag.Location = location4;
			Padding margin4 = new Padding(3, 2, 3, 2);
			this.checkBox_dtTestFlag.Margin = margin4;
			this.checkBox_dtTestFlag.Name = "checkBox_dtTestFlag";
			System.Drawing.Size size4 = new System.Drawing.Size(107, 23);
			this.checkBox_dtTestFlag.Size = size4;
			this.checkBox_dtTestFlag.TabIndex = 6;
			this.checkBox_dtTestFlag.Text = "导通测试";
			this.checkBox_dtTestFlag.UseVisualStyleBackColor = true;
			this.checkBox_jyTestFlag.AutoSize = true;
			this.checkBox_jyTestFlag.Checked = true;
			this.checkBox_jyTestFlag.CheckState = CheckState.Checked;
			this.checkBox_jyTestFlag.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(164, 378);
			this.checkBox_jyTestFlag.Location = location5;
			Padding margin5 = new Padding(3, 2, 3, 2);
			this.checkBox_jyTestFlag.Margin = margin5;
			this.checkBox_jyTestFlag.Name = "checkBox_jyTestFlag";
			System.Drawing.Size size5 = new System.Drawing.Size(107, 23);
			this.checkBox_jyTestFlag.Size = size5;
			this.checkBox_jyTestFlag.TabIndex = 8;
			this.checkBox_jyTestFlag.Text = "绝缘测试";
			this.checkBox_jyTestFlag.UseVisualStyleBackColor = true;
			this.checkBox_jyTestFlag.CheckedChanged += new System.EventHandler(this.checkBox_jyTestFlag_CheckedChanged);
			this.checkBox_isGroundFlag.AutoSize = true;
			this.checkBox_isGroundFlag.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(164, 222);
			this.checkBox_isGroundFlag.Location = location6;
			Padding margin6 = new Padding(3, 2, 3, 2);
			this.checkBox_isGroundFlag.Margin = margin6;
			this.checkBox_isGroundFlag.Name = "checkBox_isGroundFlag";
			System.Drawing.Size size6 = new System.Drawing.Size(69, 23);
			this.checkBox_isGroundFlag.Size = size6;
			this.checkBox_isGroundFlag.TabIndex = 5;
			this.checkBox_isGroundFlag.Text = "接地";
			this.checkBox_isGroundFlag.UseVisualStyleBackColor = true;
			this.checkBox_isGroundFlag.CheckedChanged += new System.EventHandler(this.checkBox_isGroundFlag_CheckedChanged);
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(58, 169);
			this.label6.Location = location7;
			this.label6.Name = "label6";
			System.Drawing.Size size7 = new System.Drawing.Size(95, 19);
			this.label6.Size = size7;
			this.label6.TabIndex = 4;
			this.label6.Text = "终止接点:";
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(58, 121);
			this.label5.Location = location8;
			this.label5.Name = "label5";
			System.Drawing.Size size8 = new System.Drawing.Size(95, 19);
			this.label5.Size = size8;
			this.label5.TabIndex = 5;
			this.label5.Text = "起始接点:";
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(58, 25);
			this.label3.Location = location9;
			this.label3.Name = "label3";
			System.Drawing.Size size9 = new System.Drawing.Size(95, 19);
			this.label3.Size = size9;
			this.label3.TabIndex = 7;
			this.label3.Text = "接口代号:";
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location10 = new System.Drawing.Point(110, 545);
			this.btnSubmit.Location = location10;
			Padding margin7 = new Padding(3, 2, 3, 2);
			this.btnSubmit.Margin = margin7;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size10 = new System.Drawing.Size(120, 30);
			this.btnSubmit.Size = size10;
			this.btnSubmit.TabIndex = 0;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location11 = new System.Drawing.Point(275, 545);
			this.btnQuit.Location = location11;
			Padding margin8 = new Padding(3, 2, 3, 2);
			this.btnQuit.Margin = margin8;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size11 = new System.Drawing.Size(120, 30);
			this.btnQuit.Size = size11;
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.checkBox_dlTestFlag.AutoSize = true;
			this.checkBox_dlTestFlag.Checked = true;
			this.checkBox_dlTestFlag.CheckState = CheckState.Checked;
			this.checkBox_dlTestFlag.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location12 = new System.Drawing.Point(164, 326);
			this.checkBox_dlTestFlag.Location = location12;
			Padding margin9 = new Padding(3, 2, 3, 2);
			this.checkBox_dlTestFlag.Margin = margin9;
			this.checkBox_dlTestFlag.Name = "checkBox_dlTestFlag";
			System.Drawing.Size size12 = new System.Drawing.Size(107, 23);
			this.checkBox_dlTestFlag.Size = size12;
			this.checkBox_dlTestFlag.TabIndex = 7;
			this.checkBox_dlTestFlag.Text = "短路测试";
			this.checkBox_dlTestFlag.UseVisualStyleBackColor = true;
			this.checkBox_ddjyTestFlag.AutoSize = true;
			this.checkBox_ddjyTestFlag.Checked = true;
			this.checkBox_ddjyTestFlag.CheckState = CheckState.Checked;
			this.checkBox_ddjyTestFlag.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location13 = new System.Drawing.Point(164, 430);
			this.checkBox_ddjyTestFlag.Location = location13;
			Padding margin10 = new Padding(3, 2, 3, 2);
			this.checkBox_ddjyTestFlag.Margin = margin10;
			this.checkBox_ddjyTestFlag.Name = "checkBox_ddjyTestFlag";
			System.Drawing.Size size13 = new System.Drawing.Size(107, 23);
			this.checkBox_ddjyTestFlag.Size = size13;
			this.checkBox_ddjyTestFlag.TabIndex = 9;
			this.checkBox_ddjyTestFlag.Text = "对地绝缘";
			this.checkBox_ddjyTestFlag.UseVisualStyleBackColor = true;
			this.checkBox_ddjyTestFlag.CheckedChanged += new System.EventHandler(this.checkBox_ddjyTestFlag_CheckedChanged);
			this.checkBox_nyTestFlag.AutoSize = true;
			this.checkBox_nyTestFlag.Checked = true;
			this.checkBox_nyTestFlag.CheckState = CheckState.Checked;
			this.checkBox_nyTestFlag.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location14 = new System.Drawing.Point(164, 482);
			this.checkBox_nyTestFlag.Location = location14;
			this.checkBox_nyTestFlag.Name = "checkBox_nyTestFlag";
			System.Drawing.Size size14 = new System.Drawing.Size(107, 23);
			this.checkBox_nyTestFlag.Size = size14;
			this.checkBox_nyTestFlag.TabIndex = 10;
			this.checkBox_nyTestFlag.Text = "耐压测试";
			this.checkBox_nyTestFlag.UseVisualStyleBackColor = true;
			this.checkBox_nyTestFlag.Click += new System.EventHandler(this.checkBox_nyTestFlag_Click);
			this.radioButton_Pin_FourWire.AutoSize = true;
			this.radioButton_Pin_FourWire.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location15 = new System.Drawing.Point(311, 72);
			this.radioButton_Pin_FourWire.Location = location15;
			this.radioButton_Pin_FourWire.Name = "radioButton_Pin_FourWire";
			System.Drawing.Size size15 = new System.Drawing.Size(87, 23);
			this.radioButton_Pin_FourWire.Size = size15;
			this.radioButton_Pin_FourWire.TabIndex = 35;
			this.radioButton_Pin_FourWire.Text = "四线法";
			this.radioButton_Pin_FourWire.UseVisualStyleBackColor = true;
			this.radioButton_Pin_TwoWire.AutoSize = true;
			this.radioButton_Pin_TwoWire.Checked = true;
			this.radioButton_Pin_TwoWire.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location16 = new System.Drawing.Point(173, 72);
			this.radioButton_Pin_TwoWire.Location = location16;
			this.radioButton_Pin_TwoWire.Name = "radioButton_Pin_TwoWire";
			System.Drawing.Size size16 = new System.Drawing.Size(87, 23);
			this.radioButton_Pin_TwoWire.Size = size16;
			this.radioButton_Pin_TwoWire.TabIndex = 36;
			this.radioButton_Pin_TwoWire.TabStop = true;
			this.radioButton_Pin_TwoWire.Text = "二线法";
			this.radioButton_Pin_TwoWire.UseVisualStyleBackColor = true;
			this.radioButton_Pin_TwoWire.CheckedChanged += new System.EventHandler(this.radioButton_Pin_TwoWire_CheckedChanged);
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location17 = new System.Drawing.Point(58, 73);
			this.label1.Location = location17;
			this.label1.Name = "label1";
			System.Drawing.Size size17 = new System.Drawing.Size(95, 19);
			this.label1.Size = size17;
			this.label1.TabIndex = 37;
			this.label1.Text = "测量方法:";
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(504, 645);
			base.ClientSize = clientSize;
			base.Controls.Add(this.label1);
			base.Controls.Add(this.radioButton_Pin_FourWire);
			base.Controls.Add(this.radioButton_Pin_TwoWire);
			base.Controls.Add(this.checkBox_nyTestFlag);
			base.Controls.Add(this.btnSubmit);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.comboBox_startPin);
			base.Controls.Add(this.comboBox_stopPin);
			base.Controls.Add(this.comboBox_startIFBH);
			base.Controls.Add(this.checkBox_dlTestFlag);
			base.Controls.Add(this.checkBox_dtTestFlag);
			base.Controls.Add(this.checkBox_ddjyTestFlag);
			base.Controls.Add(this.checkBox_jyTestFlag);
			base.Controls.Add(this.checkBox_isGroundFlag);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label3);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding this2 = new Padding(3, 2, 3, 2);
			base.Margin = this2;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormBatchEditCoreRelation";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "批量修改芯线定义";
			base.Load += new System.EventHandler(this.ctFormBatchEditCoreRelation_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (!this.bUpdateAllPlugFlag)
				{
					this.batchEditPinStrList.Clear();
					int iStartIndex = this.comboBox_startPin.SelectedIndex;
					int iStopIndex = this.comboBox_stopPin.SelectedIndex;
					if (iStartIndex == -1 || iStopIndex == -1)
					{
						MessageBox.Show("未选择起始接点和终止接点!", "提示", MessageBoxButtons.OK);
						return;
					}
					this._strStartIFBH_s = this.comboBox_startIFBH.Text.ToString();
					this._strStartPin_s = this.comboBox_startPin.Text.ToString();
					this._strStopPin_s = this.comboBox_stopPin.Text.ToString();
					if (iStartIndex > iStopIndex)
					{
						int arg_85_0 = iStartIndex;
						iStartIndex = iStopIndex;
						iStopIndex = arg_85_0;
					}
					for (int i = iStartIndex; i <= iStopIndex; i++)
					{
						this.batchEditPinStrList.Add(this.comboBox_stopPin.Items[i].ToString());
					}
				}
				this.bIsGroundFlag_s = this.checkBox_isGroundFlag.Checked;
				this.bJYTestFlag_s = this.checkBox_jyTestFlag.Checked;
				this.bDLTestFlag_s = this.checkBox_dlTestFlag.Checked;
				this.bDDJYTestFlag_s = this.checkBox_ddjyTestFlag.Checked;
				this.bNYTestFlag_s = this.checkBox_nyTestFlag.Checked;
			}
			catch (System.Exception arg_11D_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_11D_0.StackTrace);
			}
			this.bSuccFlag = true;
			base.Close();
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.batchEditPinStrList.Clear();
				this.bSuccFlag = false;
			}
			catch (System.Exception arg_14_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_14_0.StackTrace);
			}
			base.Close();
		}
		private void checkBox_isGroundFlag_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.checkBox_isGroundFlag.Checked)
			{
				this.checkBox_jyTestFlag.Checked = false;
				this.checkBox_ddjyTestFlag.Checked = false;
				this.checkBox_nyTestFlag.Checked = false;
			}
		}
		private void ctFormBatchEditCoreRelation_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.bUpdateAllPlugFlag = false;
				this.startPinMeasMethodList = new System.Collections.Generic.List<int>();
				this.startPinStrList = new System.Collections.Generic.List<string>();
				this.batchEditPinStrList = new System.Collections.Generic.List<string>();
				this.checkBox_dtTestFlag.Visible = this.gLineTestProcessor.bDTTestEnabled;
				this.checkBox_nyTestFlag.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.checkBox_dlTestFlag.Visible = this.gLineTestProcessor.bDLTestEnabled;
				this.checkBox_jyTestFlag.Visible = this.gLineTestProcessor.bJYTestEnabled;
				this.checkBox_ddjyTestFlag.Visible = this.gLineTestProcessor.bDDJYTestEnabled;
				this.bSuccFlag = false;
				this.comboBox_startIFBH.Items.Clear();
				this.comboBox_startIFBH.Items.Add("所有接口");
				if (this.strCoreArray != null)
				{
					int i = 0;
					while (true)
					{
						string[] sender2 = this.strCoreArray;
						if (i >= sender2.Length)
						{
							break;
						}
						if (!string.IsNullOrEmpty(sender2[i]))
						{
							this.comboBox_startIFBH.Items.Add(this.strCoreArray[i]);
						}
						i++;
					}
				}
				if (this.comboBox_startIFBH.Items.Count > 0)
				{
					this.comboBox_startIFBH.SelectedIndex = 0;
				}
			}
			catch (System.Exception arg_125_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_125_0.StackTrace);
			}
		}
		private void comboBox_startIFBH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.startPinMeasMethodList.Clear();
				this.startPinStrList.Clear();
				this.comboBox_startPin.Items.Clear();
				this.comboBox_stopPin.Items.Clear();
				if (this.comboBox_startIFBH.SelectedIndex == 0)
				{
					this.bUpdateAllPlugFlag = true;
					this.radioButton_Pin_TwoWire.Enabled = false;
					this.radioButton_Pin_FourWire.Enabled = false;
					this.comboBox_startPin.Enabled = false;
					this.comboBox_stopPin.Enabled = false;
				}
				else
				{
					this.bUpdateAllPlugFlag = false;
					this.radioButton_Pin_TwoWire.Enabled = true;
					this.radioButton_Pin_FourWire.Enabled = true;
					this.comboBox_startPin.Enabled = true;
					this.comboBox_stopPin.Enabled = true;
					string _IFBHStr = this.comboBox_startIFBH.Text.ToString().Trim();
					string text = "";
					string IdStr = text;
					try
					{
						connection = new OleDbConnection();
						connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
						connection.Open();
						string sqlcommand = "select top 1 * from TPlugLibrary where PlugNo = '" + _IFBHStr + "'";
						OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						if (dataReader.Read())
						{
							IdStr = dataReader["PID"].ToString();
						}
						dataReader.Close();
						dataReader = null;
						sqlcommand = "select * from TPlugLibraryDetail where PID = '" + IdStr + "'";
						cmd = new OleDbCommand(sqlcommand, connection);
						dataReader = cmd.ExecuteReader();
						while (dataReader.Read())
						{
							string tempStr = dataReader["PinName"].ToString();
							int iTemp = System.Convert.ToInt32(dataReader["MeasuringMethod"].ToString());
							this.startPinStrList.Add(tempStr);
							this.startPinMeasMethodList.Add(iTemp);
						}
						dataReader.Close();
						dataReader = null;
						connection.Close();
						connection = null;
					}
					catch (System.Exception arg_1D4_0)
					{
						KLineTestProcessor.ExceptionRecordFunc(arg_1D4_0.StackTrace);
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
					for (int nn = 0; nn < this.startPinMeasMethodList.Count; nn++)
					{
						if (this.radioButton_Pin_TwoWire.Checked)
						{
							if (this.startPinMeasMethodList[nn] == 0)
							{
								this.comboBox_startPin.Items.Add(this.startPinStrList[nn]);
								this.comboBox_stopPin.Items.Add(this.startPinStrList[nn]);
							}
						}
						else if (this.startPinMeasMethodList[nn] != 0)
						{
							this.comboBox_startPin.Items.Add(this.startPinStrList[nn]);
							this.comboBox_stopPin.Items.Add(this.startPinStrList[nn]);
						}
					}
					if (this.comboBox_startPin.Items.Count > 0)
					{
						this.comboBox_startPin.SelectedIndex = 0;
						this.comboBox_stopPin.SelectedIndex = this.comboBox_stopPin.Items.Count - 1;
					}
				}
			}
			catch (System.Exception arg_2F2_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2F2_0.StackTrace);
			}
		}
		private void checkBox_jyTestFlag_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.checkBox_isGroundFlag.Checked)
			{
				this.checkBox_jyTestFlag.Checked = false;
			}
		}
		private void checkBox_ddjyTestFlag_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.checkBox_isGroundFlag.Checked)
			{
				this.checkBox_ddjyTestFlag.Checked = false;
			}
		}
		private void checkBox_nyTestFlag_Click(object sender, System.EventArgs e)
		{
			if (this.checkBox_isGroundFlag.Checked)
			{
				this.checkBox_nyTestFlag.Checked = false;
			}
		}
		private void radioButton_Pin_TwoWire_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.comboBox_startPin.Items.Clear();
				this.comboBox_stopPin.Items.Clear();
				if (!this.bUpdateAllPlugFlag)
				{
					for (int nn = 0; nn < this.startPinMeasMethodList.Count; nn++)
					{
						if (this.radioButton_Pin_TwoWire.Checked)
						{
							if (this.startPinMeasMethodList[nn] == 0)
							{
								this.comboBox_startPin.Items.Add(this.startPinStrList[nn]);
								this.comboBox_stopPin.Items.Add(this.startPinStrList[nn]);
							}
						}
						else if (this.startPinMeasMethodList[nn] != 0)
						{
							this.comboBox_startPin.Items.Add(this.startPinStrList[nn]);
							this.comboBox_stopPin.Items.Add(this.startPinStrList[nn]);
						}
					}
					if (this.comboBox_startPin.Items.Count > 0)
					{
						this.comboBox_startPin.SelectedIndex = 0;
						this.comboBox_stopPin.SelectedIndex = this.comboBox_stopPin.Items.Count - 1;
					}
				}
			}
			catch (System.Exception arg_129_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_129_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormBatchEditCoreRelation();
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
