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
	public class ctFormEditCoreRelation : Form
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
		public bool bLoadFlag;
		public System.Collections.Generic.List<int> startPinMeasMethodList;
		public System.Collections.Generic.List<string> startPinStrList;
		public System.Collections.Generic.List<int> stopPinMeasMethodList;
		public System.Collections.Generic.List<string> stopPinStrList;
		private RadioButton radioButton_Pin_FourWire;
		private RadioButton radioButton_Pin_TwoWire;
		private Label label1;
		private FlowLayoutPanel flowLayoutPanel1;
		private CheckBox checkBox_nyTestFlag;
		private ComboBox comboBox_startPin;
		private ComboBox comboBox_stopPin;
		private ComboBox comboBox_stopIFBH;
		private ComboBox comboBox_startIFBH;
		private CheckBox checkBox_ddjyTestFlag;
		private CheckBox checkBox_dlTestFlag;
		private CheckBox checkBox_dtTestFlag;
		private CheckBox checkBox_jyTestFlag;
		private CheckBox checkBox_isGroundFlag;
		private Label label6;
		private Label label4;
		private Label label5;
		private Label label3;
		private Button btnSubmit;
		private Button btnQuit;
		private Container components;
		public ctFormEditCoreRelation(KLineTestProcessor gltProcessor, string lUser, string[] strCRArray, string _strStartIFBH, string _strStartPin, string _strStopIFBH, string _strStopPin, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool _bisGroundFlag, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool _bdlTestFlag, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool _bjyTestFlag, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool _bddjyTestFlag, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool _bnyTestFlag)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					if (strCRArray != null)
					{
						this.strCoreArray = new string[strCRArray.Length];
						for (int i = 0; i < strCRArray.Length; i++)
						{
							this.strCoreArray[i] = strCRArray[i];
						}
					}
				}
				catch (System.Exception ex_36)
				{
				}
				this.dbpath = Application.StartupPath + "\\ctsdb.mdb";
				this.gLineTestProcessor = gltProcessor;
				this.loginUser = lUser;
				this._strStartIFBH_s = _strStartIFBH;
				this._strStartPin_s = _strStartPin;
				this._strStopIFBH_s = _strStopIFBH;
				this._strStopPin_s = _strStopPin;
				this.bIsGroundFlag_s = _bisGroundFlag;
				this.bJYTestFlag_s = _bjyTestFlag;
				this.bDLTestFlag_s = _bdlTestFlag;
				this.bDDJYTestFlag_s = _bddjyTestFlag;
				this.bNYTestFlag_s = _bnyTestFlag;
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~ctFormEditCoreRelation()
		{
			Container this2 = this.components;
			if (this2 != null)
			{
				((System.IDisposable)this2).Dispose();
			}
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(ctFormEditCoreRelation));
			this.comboBox_startPin = new ComboBox();
			this.comboBox_stopPin = new ComboBox();
			this.comboBox_stopIFBH = new ComboBox();
			this.comboBox_startIFBH = new ComboBox();
			this.checkBox_dtTestFlag = new CheckBox();
			this.checkBox_jyTestFlag = new CheckBox();
			this.checkBox_isGroundFlag = new CheckBox();
			this.label6 = new Label();
			this.label4 = new Label();
			this.label5 = new Label();
			this.label3 = new Label();
			this.btnSubmit = new Button();
			this.btnQuit = new Button();
			this.checkBox_ddjyTestFlag = new CheckBox();
			this.checkBox_dlTestFlag = new CheckBox();
			this.checkBox_nyTestFlag = new CheckBox();
			this.radioButton_Pin_FourWire = new RadioButton();
			this.radioButton_Pin_TwoWire = new RadioButton();
			this.label1 = new Label();
			FlowLayoutPanel this2 = new FlowLayoutPanel();
			this.flowLayoutPanel1 = this2;
			this2.SuspendLayout();
			base.SuspendLayout();
			this.comboBox_startPin.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_startPin.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.comboBox_startPin.FormattingEnabled = true;
			System.Drawing.Point location = new System.Drawing.Point(424, 70);
			this.comboBox_startPin.Location = location;
			Padding margin = new Padding(2, 2, 2, 2);
			this.comboBox_startPin.Margin = margin;
			this.comboBox_startPin.Name = "comboBox_startPin";
			System.Drawing.Size size = new System.Drawing.Size(121, 22);
			this.comboBox_startPin.Size = size;
			this.comboBox_startPin.TabIndex = 3;
			this.comboBox_stopPin.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_stopPin.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.comboBox_stopPin.FormattingEnabled = true;
			System.Drawing.Point location2 = new System.Drawing.Point(424, 111);
			this.comboBox_stopPin.Location = location2;
			Padding margin2 = new Padding(2, 2, 2, 2);
			this.comboBox_stopPin.Margin = margin2;
			this.comboBox_stopPin.Name = "comboBox_stopPin";
			System.Drawing.Size size2 = new System.Drawing.Size(121, 22);
			this.comboBox_stopPin.Size = size2;
			this.comboBox_stopPin.TabIndex = 5;
			this.comboBox_stopIFBH.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_stopIFBH.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.comboBox_stopIFBH.FormattingEnabled = true;
			System.Drawing.Point location3 = new System.Drawing.Point(126, 111);
			this.comboBox_stopIFBH.Location = location3;
			Padding margin3 = new Padding(2, 2, 2, 2);
			this.comboBox_stopIFBH.Margin = margin3;
			this.comboBox_stopIFBH.Name = "comboBox_stopIFBH";
			System.Drawing.Size size3 = new System.Drawing.Size(188, 22);
			this.comboBox_stopIFBH.Size = size3;
			this.comboBox_stopIFBH.TabIndex = 4;
			this.comboBox_stopIFBH.SelectedIndexChanged += new System.EventHandler(this.comboBox_stopIFBH_SelectedIndexChanged);
			this.comboBox_startIFBH.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_startIFBH.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			this.comboBox_startIFBH.FormattingEnabled = true;
			System.Drawing.Point location4 = new System.Drawing.Point(126, 70);
			this.comboBox_startIFBH.Location = location4;
			Padding margin4 = new Padding(2, 2, 2, 2);
			this.comboBox_startIFBH.Margin = margin4;
			this.comboBox_startIFBH.Name = "comboBox_startIFBH";
			System.Drawing.Size size4 = new System.Drawing.Size(188, 22);
			this.comboBox_startIFBH.Size = size4;
			this.comboBox_startIFBH.TabIndex = 2;
			this.comboBox_startIFBH.SelectedIndexChanged += new System.EventHandler(this.comboBox_startIFBH_SelectedIndexChanged);
			this.checkBox_dtTestFlag.AutoSize = true;
			this.checkBox_dtTestFlag.Checked = true;
			this.checkBox_dtTestFlag.CheckState = CheckState.Checked;
			this.checkBox_dtTestFlag.Enabled = false;
			this.checkBox_dtTestFlag.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location5 = new System.Drawing.Point(2, 37);
			this.checkBox_dtTestFlag.Location = location5;
			Padding margin5 = new Padding(2, 6, 2, 6);
			this.checkBox_dtTestFlag.Margin = margin5;
			this.checkBox_dtTestFlag.Name = "checkBox_dtTestFlag";
			System.Drawing.Size size5 = new System.Drawing.Size(86, 19);
			this.checkBox_dtTestFlag.Size = size5;
			this.checkBox_dtTestFlag.TabIndex = 7;
			this.checkBox_dtTestFlag.Text = "导通测试";
			this.checkBox_dtTestFlag.UseVisualStyleBackColor = true;
			this.checkBox_jyTestFlag.AutoSize = true;
			this.checkBox_jyTestFlag.Checked = true;
			this.checkBox_jyTestFlag.CheckState = CheckState.Checked;
			this.checkBox_jyTestFlag.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(2, 99);
			this.checkBox_jyTestFlag.Location = location6;
			Padding margin6 = new Padding(2, 6, 2, 6);
			this.checkBox_jyTestFlag.Margin = margin6;
			this.checkBox_jyTestFlag.Name = "checkBox_jyTestFlag";
			System.Drawing.Size size6 = new System.Drawing.Size(86, 19);
			this.checkBox_jyTestFlag.Size = size6;
			this.checkBox_jyTestFlag.TabIndex = 9;
			this.checkBox_jyTestFlag.Text = "绝缘测试";
			this.checkBox_jyTestFlag.UseVisualStyleBackColor = true;
			this.checkBox_jyTestFlag.CheckedChanged += new System.EventHandler(this.checkBox_jyTestFlag_CheckedChanged);
			this.checkBox_isGroundFlag.AutoSize = true;
			this.checkBox_isGroundFlag.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(2, 6);
			this.checkBox_isGroundFlag.Location = location7;
			Padding margin7 = new Padding(2, 6, 2, 6);
			this.checkBox_isGroundFlag.Margin = margin7;
			this.checkBox_isGroundFlag.Name = "checkBox_isGroundFlag";
			System.Drawing.Size size7 = new System.Drawing.Size(56, 19);
			this.checkBox_isGroundFlag.Size = size7;
			this.checkBox_isGroundFlag.TabIndex = 6;
			this.checkBox_isGroundFlag.Text = "接地";
			this.checkBox_isGroundFlag.UseVisualStyleBackColor = true;
			this.checkBox_isGroundFlag.CheckedChanged += new System.EventHandler(this.checkBox_isGroundFlag_CheckedChanged);
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location8 = new System.Drawing.Point(344, 114);
			this.label6.Location = location8;
			Padding margin8 = new Padding(2, 0, 2, 0);
			this.label6.Margin = margin8;
			this.label6.Name = "label6";
			System.Drawing.Size size8 = new System.Drawing.Size(75, 15);
			this.label6.Size = size8;
			this.label6.TabIndex = 4;
			this.label6.Text = "终点接点:";
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location9 = new System.Drawing.Point(44, 114);
			this.label4.Location = location9;
			Padding margin9 = new Padding(2, 0, 2, 0);
			this.label4.Margin = margin9;
			this.label4.Name = "label4";
			System.Drawing.Size size9 = new System.Drawing.Size(75, 15);
			this.label4.Size = size9;
			this.label4.TabIndex = 6;
			this.label4.Text = "终点接口:";
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location10 = new System.Drawing.Point(344, 74);
			this.label5.Location = location10;
			Padding margin10 = new Padding(2, 0, 2, 0);
			this.label5.Margin = margin10;
			this.label5.Name = "label5";
			System.Drawing.Size size10 = new System.Drawing.Size(75, 15);
			this.label5.Size = size10;
			this.label5.TabIndex = 5;
			this.label5.Text = "起点接点:";
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location11 = new System.Drawing.Point(44, 74);
			this.label3.Location = location11;
			Padding margin11 = new Padding(2, 0, 2, 0);
			this.label3.Margin = margin11;
			this.label3.Name = "label3";
			System.Drawing.Size size11 = new System.Drawing.Size(75, 15);
			this.label3.Size = size11;
			this.label3.TabIndex = 7;
			this.label3.Text = "起点接口:";
			this.btnSubmit.Anchor = AnchorStyles.Bottom;
			this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location12 = new System.Drawing.Point(165, 369);
			this.btnSubmit.Location = location12;
			Padding margin12 = new Padding(2, 2, 2, 2);
			this.btnSubmit.Margin = margin12;
			this.btnSubmit.Name = "btnSubmit";
			System.Drawing.Size size12 = new System.Drawing.Size(112, 24);
			this.btnSubmit.Size = size12;
			this.btnSubmit.TabIndex = 0;
			this.btnSubmit.Text = "确定";
			this.btnSubmit.UseVisualStyleBackColor = true;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.btnQuit.Anchor = AnchorStyles.Bottom;
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location13 = new System.Drawing.Point(315, 369);
			this.btnQuit.Location = location13;
			Padding margin13 = new Padding(2, 2, 2, 2);
			this.btnQuit.Margin = margin13;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size13 = new System.Drawing.Size(112, 24);
			this.btnQuit.Size = size13;
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.checkBox_ddjyTestFlag.AutoSize = true;
			this.checkBox_ddjyTestFlag.Checked = true;
			this.checkBox_ddjyTestFlag.CheckState = CheckState.Checked;
			this.checkBox_ddjyTestFlag.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location14 = new System.Drawing.Point(2, 130);
			this.checkBox_ddjyTestFlag.Location = location14;
			Padding margin14 = new Padding(2, 6, 2, 6);
			this.checkBox_ddjyTestFlag.Margin = margin14;
			this.checkBox_ddjyTestFlag.Name = "checkBox_ddjyTestFlag";
			System.Drawing.Size size14 = new System.Drawing.Size(86, 19);
			this.checkBox_ddjyTestFlag.Size = size14;
			this.checkBox_ddjyTestFlag.TabIndex = 10;
			this.checkBox_ddjyTestFlag.Text = "对地绝缘";
			this.checkBox_ddjyTestFlag.UseVisualStyleBackColor = true;
			this.checkBox_ddjyTestFlag.CheckedChanged += new System.EventHandler(this.checkBox_ddjyTestFlag_CheckedChanged);
			this.checkBox_dlTestFlag.AutoSize = true;
			this.checkBox_dlTestFlag.Checked = true;
			this.checkBox_dlTestFlag.CheckState = CheckState.Checked;
			this.checkBox_dlTestFlag.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location15 = new System.Drawing.Point(2, 68);
			this.checkBox_dlTestFlag.Location = location15;
			Padding margin15 = new Padding(2, 6, 2, 6);
			this.checkBox_dlTestFlag.Margin = margin15;
			this.checkBox_dlTestFlag.Name = "checkBox_dlTestFlag";
			System.Drawing.Size size15 = new System.Drawing.Size(86, 19);
			this.checkBox_dlTestFlag.Size = size15;
			this.checkBox_dlTestFlag.TabIndex = 8;
			this.checkBox_dlTestFlag.Text = "短路测试";
			this.checkBox_dlTestFlag.UseVisualStyleBackColor = true;
			this.checkBox_nyTestFlag.AutoSize = true;
			this.checkBox_nyTestFlag.Checked = true;
			this.checkBox_nyTestFlag.CheckState = CheckState.Checked;
			this.checkBox_nyTestFlag.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location16 = new System.Drawing.Point(2, 161);
			this.checkBox_nyTestFlag.Location = location16;
			Padding margin16 = new Padding(2, 6, 2, 6);
			this.checkBox_nyTestFlag.Margin = margin16;
			this.checkBox_nyTestFlag.Name = "checkBox_nyTestFlag";
			System.Drawing.Size size16 = new System.Drawing.Size(86, 19);
			this.checkBox_nyTestFlag.Size = size16;
			this.checkBox_nyTestFlag.TabIndex = 11;
			this.checkBox_nyTestFlag.Text = "耐压测试";
			this.checkBox_nyTestFlag.UseVisualStyleBackColor = true;
			this.checkBox_nyTestFlag.CheckedChanged += new System.EventHandler(this.checkBox_nyTestFlag_CheckedChanged);
			this.radioButton_Pin_FourWire.AutoSize = true;
			this.radioButton_Pin_FourWire.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location17 = new System.Drawing.Point(235, 24);
			this.radioButton_Pin_FourWire.Location = location17;
			Padding margin17 = new Padding(2, 2, 2, 2);
			this.radioButton_Pin_FourWire.Margin = margin17;
			this.radioButton_Pin_FourWire.Name = "radioButton_Pin_FourWire";
			System.Drawing.Size size17 = new System.Drawing.Size(70, 19);
			this.radioButton_Pin_FourWire.Size = size17;
			this.radioButton_Pin_FourWire.TabIndex = 26;
			this.radioButton_Pin_FourWire.Text = "四线法";
			this.radioButton_Pin_FourWire.UseVisualStyleBackColor = true;
			this.radioButton_Pin_TwoWire.AutoSize = true;
			this.radioButton_Pin_TwoWire.Checked = true;
			this.radioButton_Pin_TwoWire.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location18 = new System.Drawing.Point(136, 24);
			this.radioButton_Pin_TwoWire.Location = location18;
			Padding margin18 = new Padding(2, 2, 2, 2);
			this.radioButton_Pin_TwoWire.Margin = margin18;
			this.radioButton_Pin_TwoWire.Name = "radioButton_Pin_TwoWire";
			System.Drawing.Size size18 = new System.Drawing.Size(70, 19);
			this.radioButton_Pin_TwoWire.Size = size18;
			this.radioButton_Pin_TwoWire.TabIndex = 27;
			this.radioButton_Pin_TwoWire.TabStop = true;
			this.radioButton_Pin_TwoWire.Text = "二线法";
			this.radioButton_Pin_TwoWire.UseVisualStyleBackColor = true;
			this.radioButton_Pin_TwoWire.CheckedChanged += new System.EventHandler(this.radioButton_Pin_TwoWire_CheckedChanged);
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location19 = new System.Drawing.Point(44, 26);
			this.label1.Location = location19;
			Padding margin19 = new Padding(2, 0, 2, 0);
			this.label1.Margin = margin19;
			this.label1.Name = "label1";
			System.Drawing.Size size19 = new System.Drawing.Size(75, 15);
			this.label1.Size = size19;
			this.label1.TabIndex = 25;
			this.label1.Text = "测量方法:";
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.Controls.Add(this.checkBox_isGroundFlag);
			this.flowLayoutPanel1.Controls.Add(this.checkBox_dtTestFlag);
			this.flowLayoutPanel1.Controls.Add(this.checkBox_dlTestFlag);
			this.flowLayoutPanel1.Controls.Add(this.checkBox_jyTestFlag);
			this.flowLayoutPanel1.Controls.Add(this.checkBox_ddjyTestFlag);
			this.flowLayoutPanel1.Controls.Add(this.checkBox_nyTestFlag);
			this.flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
			this.flowLayoutPanel1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location20 = new System.Drawing.Point(126, 156);
			this.flowLayoutPanel1.Location = location20;
			Padding margin20 = new Padding(2, 2, 2, 2);
			this.flowLayoutPanel1.Margin = margin20;
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			System.Drawing.Size size20 = new System.Drawing.Size(360, 192);
			this.flowLayoutPanel1.Size = size20;
			this.flowLayoutPanel1.TabIndex = 28;
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size clientSize = new System.Drawing.Size(594, 421);
			base.ClientSize = clientSize;
			base.Controls.Add(this.flowLayoutPanel1);
			base.Controls.Add(this.radioButton_Pin_FourWire);
			base.Controls.Add(this.radioButton_Pin_TwoWire);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.btnSubmit);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.comboBox_startPin);
			base.Controls.Add(this.comboBox_stopPin);
			base.Controls.Add(this.comboBox_stopIFBH);
			base.Controls.Add(this.comboBox_startIFBH);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label3);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Padding margin21 = new Padding(2, 2, 2, 2);
			base.Margin = margin21;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ctFormEditCoreRelation";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "修改芯线定义";
			base.Load += new System.EventHandler(this.ctFormEditCoreRelation_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			try
			{
				this._strStartIFBH_s = this.comboBox_startIFBH.Text.ToString();
				this._strStartPin_s = this.comboBox_startPin.Text.ToString();
				this._strStopIFBH_s = this.comboBox_stopIFBH.Text.ToString();
				this._strStopPin_s = this.comboBox_stopPin.Text.ToString();
				this.bIsGroundFlag_s = this.checkBox_isGroundFlag.Checked;
				this.bJYTestFlag_s = this.checkBox_jyTestFlag.Checked;
				this.bDLTestFlag_s = this.checkBox_dlTestFlag.Checked;
				this.bDDJYTestFlag_s = this.checkBox_ddjyTestFlag.Checked;
				this.bNYTestFlag_s = this.checkBox_nyTestFlag.Checked;
			}
			catch (System.Exception arg_AF_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_AF_0.StackTrace);
			}
			this.bSuccFlag = true;
			base.Close();
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			this.bSuccFlag = false;
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
		private void ctFormEditCoreRelation_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.bSuccFlag = false;
				this.bLoadFlag = false;
				this.startPinMeasMethodList = new System.Collections.Generic.List<int>();
				this.startPinStrList = new System.Collections.Generic.List<string>();
				this.stopPinMeasMethodList = new System.Collections.Generic.List<int>();
				this.stopPinStrList = new System.Collections.Generic.List<string>();
				this.checkBox_dtTestFlag.Visible = this.gLineTestProcessor.bDTTestEnabled;
				this.checkBox_nyTestFlag.Visible = this.gLineTestProcessor.bNYTestEnabled;
				this.checkBox_dlTestFlag.Visible = this.gLineTestProcessor.bDLTestEnabled;
				this.checkBox_jyTestFlag.Visible = this.gLineTestProcessor.bJYTestEnabled;
				this.checkBox_ddjyTestFlag.Visible = this.gLineTestProcessor.bDDJYTestEnabled;
				this.checkBox_isGroundFlag.Checked = this.bIsGroundFlag_s;
				this.checkBox_jyTestFlag.Checked = this.bJYTestFlag_s;
				this.checkBox_dlTestFlag.Checked = this.bDLTestFlag_s;
				this.checkBox_ddjyTestFlag.Checked = this.bDDJYTestFlag_s;
				this.checkBox_nyTestFlag.Checked = this.bNYTestFlag_s;
				this.comboBox_startIFBH.Items.Clear();
				this.comboBox_stopIFBH.Items.Clear();
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
						this.comboBox_startIFBH.Items.Add(sender2[i]);
						this.comboBox_stopIFBH.Items.Add(this.strCoreArray[i]);
						i++;
					}
				}
				this.comboBox_startIFBH.Text = this._strStartIFBH_s;
				this.comboBox_stopIFBH.Text = this._strStopIFBH_s;
				this.comboBox_startIFBH_SelectedIndexChanged(null, null);
				this.comboBox_stopIFBH_SelectedIndexChanged(null, null);
				this.comboBox_startPin.Text = this._strStartPin_s;
				this.comboBox_stopPin.Text = this._strStopPin_s;
				this.bLoadFlag = true;
			}
			catch (System.Exception arg_1C3_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_1C3_0.StackTrace);
			}
		}
		private void comboBox_startIFBH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.comboBox_startPin.Items.Clear();
				this.startPinStrList.Clear();
				this.startPinMeasMethodList.Clear();
				string _IFBHStr = this.comboBox_startIFBH.Text.ToString().Trim();
				if (!string.IsNullOrEmpty(_IFBHStr))
				{
					if (this.comboBox_startIFBH.SelectedIndex >= 0)
					{
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
							sqlcommand = "select * from TPlugLibraryDetail where PID = '" + IdStr + "' order by PDID";
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
						catch (System.Exception arg_169_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_169_0.StackTrace);
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
						if (!this.bLoadFlag)
						{
							int kk = 0;
							while (kk < this.startPinStrList.Count)
							{
								if (this._strStartPin_s == this.startPinStrList[kk])
								{
									if (this.startPinMeasMethodList[kk] == 0)
									{
										this.radioButton_Pin_TwoWire.Checked = true;
										break;
									}
									this.radioButton_Pin_FourWire.Checked = true;
									break;
								}
								else
								{
									kk++;
								}
							}
						}
						for (int nn = 0; nn < this.startPinMeasMethodList.Count; nn++)
						{
							if (this.radioButton_Pin_TwoWire.Checked)
							{
								if (this.startPinMeasMethodList[nn] == 0)
								{
									this.comboBox_startPin.Items.Add(this.startPinStrList[nn]);
								}
							}
							else if (this.startPinMeasMethodList[nn] != 0)
							{
								this.comboBox_startPin.Items.Add(this.startPinStrList[nn]);
							}
						}
						if (!this.bLoadFlag)
						{
							this.comboBox_startPin.Text = this._strStartPin_s;
						}
						else if (this.comboBox_startPin.Items.Count > 0)
						{
							this.comboBox_startPin.SelectedIndex = 0;
						}
					}
				}
			}
			catch (System.Exception arg_2A3_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2A3_0.StackTrace);
			}
		}
		private void comboBox_stopIFBH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				this.comboBox_stopPin.Items.Clear();
				this.stopPinStrList.Clear();
				this.stopPinMeasMethodList.Clear();
				string _IFBHStr = this.comboBox_stopIFBH.Text.ToString().Trim();
				if (!string.IsNullOrEmpty(_IFBHStr))
				{
					if (this.comboBox_stopIFBH.SelectedIndex >= 0)
					{
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
							sqlcommand = "select * from TPlugLibraryDetail where PID = '" + IdStr + "' order by PDID";
							cmd = new OleDbCommand(sqlcommand, connection);
							dataReader = cmd.ExecuteReader();
							while (dataReader.Read())
							{
								string tempStr = dataReader["PinName"].ToString();
								int iTemp = System.Convert.ToInt32(dataReader["MeasuringMethod"].ToString());
								this.stopPinStrList.Add(tempStr);
								this.stopPinMeasMethodList.Add(iTemp);
							}
							dataReader.Close();
							dataReader = null;
							connection.Close();
							connection = null;
						}
						catch (System.Exception arg_169_0)
						{
							KLineTestProcessor.ExceptionRecordFunc(arg_169_0.StackTrace);
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
						if (!this.bLoadFlag)
						{
							int kk = 0;
							while (kk < this.stopPinStrList.Count)
							{
								if (this._strStopPin_s == this.stopPinStrList[kk])
								{
									if (this.stopPinMeasMethodList[kk] == 0)
									{
										this.radioButton_Pin_TwoWire.Checked = true;
										break;
									}
									this.radioButton_Pin_FourWire.Checked = true;
									break;
								}
								else
								{
									kk++;
								}
							}
						}
						for (int nn = 0; nn < this.stopPinMeasMethodList.Count; nn++)
						{
							if (this.radioButton_Pin_TwoWire.Checked)
							{
								if (this.stopPinMeasMethodList[nn] == 0)
								{
									this.comboBox_stopPin.Items.Add(this.stopPinStrList[nn]);
								}
							}
							else if (this.stopPinMeasMethodList[nn] != 0)
							{
								this.comboBox_stopPin.Items.Add(this.stopPinStrList[nn]);
							}
						}
						if (!this.bLoadFlag)
						{
							this.comboBox_stopPin.Text = this._strStopPin_s;
						}
						else if (this.comboBox_stopPin.Items.Count > 0)
						{
							this.comboBox_stopPin.SelectedIndex = 0;
						}
					}
				}
			}
			catch (System.Exception arg_2A3_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_2A3_0.StackTrace);
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
		private void checkBox_nyTestFlag_CheckedChanged(object sender, System.EventArgs e)
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
				for (int nn = 0; nn < this.startPinMeasMethodList.Count; nn++)
				{
					if (this.radioButton_Pin_TwoWire.Checked)
					{
						if (this.startPinMeasMethodList[nn] == 0)
						{
							this.comboBox_startPin.Items.Add(this.startPinStrList[nn]);
						}
					}
					else if (this.startPinMeasMethodList[nn] != 0)
					{
						this.comboBox_startPin.Items.Add(this.startPinStrList[nn]);
					}
				}
				if (this.comboBox_startPin.Items.Count > 0)
				{
					this.comboBox_startPin.SelectedIndex = 0;
				}
				for (int nn2 = 0; nn2 < this.stopPinMeasMethodList.Count; nn2++)
				{
					if (this.radioButton_Pin_TwoWire.Checked)
					{
						if (this.stopPinMeasMethodList[nn2] == 0)
						{
							this.comboBox_stopPin.Items.Add(this.stopPinStrList[nn2]);
						}
					}
					else if (this.stopPinMeasMethodList[nn2] != 0)
					{
						this.comboBox_stopPin.Items.Add(this.stopPinStrList[nn2]);
					}
				}
				if (this.comboBox_stopPin.Items.Count > 0)
				{
					this.comboBox_stopPin.SelectedIndex = 0;
				}
			}
			catch (System.Exception arg_156_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_156_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~ctFormEditCoreRelation();
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
