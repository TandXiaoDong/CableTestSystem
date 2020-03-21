using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace CableTestManager
{
	public class FormEquipmentInfoManage : Form
	{
		public KLineTestProcessor gLineTestProcessor;
		public static string noteStr = "若需修改设备信息,请联系管理员.";
		public bool bIsAdminFlag;
		private GroupBox groupBox1;
		private TextBox textBox_DLCSY_Model;
		private Label label1;
		private TextBox textBox_DLCSY_SN;
		private Label label10;
		private Button btnQuit;
		private Button btn_submit;
		private Label label_note;
		private Timer timer_move;
		private IContainer components;
		public FormEquipmentInfoManage(KLineTestProcessor gltProcessor, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool bFlag)
		{
			try
			{
				this.InitializeComponent();
				try
				{
					this.gLineTestProcessor = gltProcessor;
					this.bIsAdminFlag = bFlag;
				}
				catch (System.Exception ex_1C)
				{
				}
			}
			catch
			{
				base.Dispose(true);
				throw;
			}
		}
		private void ~FormEquipmentInfoManage()
		{
			IContainer this2 = this.components;
			if (this2 != null)
			{
				this2.Dispose();
			}
		}
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager resources = new ComponentResourceManager(typeof(FormEquipmentInfoManage));
			this.groupBox1 = new GroupBox();
			this.textBox_DLCSY_SN = new TextBox();
			this.label10 = new Label();
			this.textBox_DLCSY_Model = new TextBox();
			this.label1 = new Label();
			this.btnQuit = new Button();
			this.btn_submit = new Button();
			this.label_note = new Label();
			this.timer_move = new Timer(this.components);
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.textBox_DLCSY_SN);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.textBox_DLCSY_Model);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location = new System.Drawing.Point(21, 40);
			this.groupBox1.Location = location;
			this.groupBox1.Name = "groupBox1";
			System.Drawing.Size size = new System.Drawing.Size(750, 180);
			this.groupBox1.Size = size;
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "试验设备信息";
			System.Drawing.Point location2 = new System.Drawing.Point(210, 112);
			this.textBox_DLCSY_SN.Location = location2;
			this.textBox_DLCSY_SN.MaxLength = 120;
			this.textBox_DLCSY_SN.Name = "textBox_DLCSY_SN";
			System.Drawing.Size size2 = new System.Drawing.Size(420, 28);
			this.textBox_DLCSY_SN.Size = size2;
			this.textBox_DLCSY_SN.TabIndex = 2;
			this.label10.AutoSize = true;
			System.Drawing.Point location3 = new System.Drawing.Point(41, 117);
			this.label10.Location = location3;
			this.label10.Name = "label10";
			System.Drawing.Size size3 = new System.Drawing.Size(152, 19);
			this.label10.Size = size3;
			this.label10.TabIndex = 6;
			this.label10.Text = "测试仪计量编号:";
			System.Drawing.Point location4 = new System.Drawing.Point(210, 57);
			this.textBox_DLCSY_Model.Location = location4;
			this.textBox_DLCSY_Model.MaxLength = 120;
			this.textBox_DLCSY_Model.Name = "textBox_DLCSY_Model";
			System.Drawing.Size size4 = new System.Drawing.Size(420, 28);
			this.textBox_DLCSY_Model.Size = size4;
			this.textBox_DLCSY_Model.TabIndex = 1;
			this.label1.AutoSize = true;
			System.Drawing.Point location5 = new System.Drawing.Point(79, 62);
			this.label1.Location = location5;
			this.label1.Name = "label1";
			System.Drawing.Size size5 = new System.Drawing.Size(114, 19);
			this.label1.Size = size5;
			this.label1.TabIndex = 0;
			this.label1.Text = "测试仪型号:";
			this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location6 = new System.Drawing.Point(541, 239);
			this.btnQuit.Location = location6;
			this.btnQuit.Name = "btnQuit";
			System.Drawing.Size size6 = new System.Drawing.Size(150, 30);
			this.btnQuit.Size = size6;
			this.btnQuit.TabIndex = 4;
			this.btnQuit.Text = "取消";
			this.btnQuit.UseVisualStyleBackColor = true;
			this.btnQuit.Visible = false;
			this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
			this.btn_submit.Font = new System.Drawing.Font("宋体", 10.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			System.Drawing.Point location7 = new System.Drawing.Point(322, 239);
			this.btn_submit.Location = location7;
			this.btn_submit.Name = "btn_submit";
			System.Drawing.Size size7 = new System.Drawing.Size(150, 30);
			this.btn_submit.Size = size7;
			this.btn_submit.TabIndex = 0;
			this.btn_submit.Text = "确定";
			this.btn_submit.UseVisualStyleBackColor = true;
			this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
			this.label_note.AutoSize = true;
			System.Drawing.Point location8 = new System.Drawing.Point(560, 12);
			this.label_note.Location = location8;
			this.label_note.Name = "label_note";
			System.Drawing.Size size8 = new System.Drawing.Size(233, 15);
			this.label_note.Size = size8;
			this.label_note.TabIndex = 13;
			this.label_note.Text = "若需修改设备信息,请联系管理员.";
			this.timer_move.Interval = 300;
			this.timer_move.Tick += new System.EventHandler(this.timer_move_Tick);
			System.Drawing.SizeF autoScaleDimensions = new System.Drawing.SizeF(8f, 15f);
			base.AutoScaleDimensions = autoScaleDimensions;
			base.AutoScaleMode = AutoScaleMode.Font;
			System.Drawing.Size this2 = new System.Drawing.Size(794, 325);
			base.ClientSize = this2;
			base.Controls.Add(this.label_note);
			base.Controls.Add(this.btn_submit);
			base.Controls.Add(this.btnQuit);
			base.Controls.Add(this.groupBox1);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormEquipmentInfoManage";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "设备信息管理";
			base.Load += new System.EventHandler(this.FormEquipmentInfoManage_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void btnQuit_Click(object sender, System.EventArgs e)
		{
			base.Close();
		}
		private void btn_submit_Click(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				if (!this.bIsAdminFlag)
				{
					base.Close();
					return;
				}
				string str_DLCSY_Model = this.textBox_DLCSY_Model.Text.ToString().Trim();
				string str_DLCSY_SN = this.textBox_DLCSY_SN.Text.ToString().Trim();
				if (string.IsNullOrEmpty(str_DLCSY_Model) || string.IsNullOrEmpty(str_DLCSY_SN))
				{
					MessageBox.Show("输入的设备信息不完整，请重新输入!", "提示", MessageBoxButtons.OK);
					return;
				}
				string dbpath = Application.StartupPath + "\\ctsdb.mdb";
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					string sqlcommand = "select * from TTestEquipmentInfo";
					OleDbCommand cmd = new OleDbCommand(sqlcommand, connection);
					dataReader = cmd.ExecuteReader();
					if (dataReader.Read())
					{
					}
					dataReader.Close();
					dataReader = null;
					sqlcommand = "update TTestEquipmentInfo set TestEquipmentModel='" + str_DLCSY_Model + "',TestEquipmentSN='" + str_DLCSY_SN + "'";
					cmd = new OleDbCommand(sqlcommand, connection);
					cmd.ExecuteNonQuery();
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_10D_0)
				{
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
					KLineTestProcessor.ExceptionRecordFunc(arg_10D_0.StackTrace);
				}
			}
			catch (System.Exception arg_12E_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_12E_0.StackTrace);
			}
			base.Close();
		}
		private void FormEquipmentInfoManage_Load(object sender, System.EventArgs e)
		{
			OleDbConnection connection = null;
			OleDbDataReader dataReader = null;
			try
			{
				byte readOnly = (!this.bIsAdminFlag) ? 1 : 0;
				this.textBox_DLCSY_Model.ReadOnly = (readOnly != 0);
				byte readOnly2 = (!this.bIsAdminFlag) ? 1 : 0;
				this.textBox_DLCSY_SN.ReadOnly = (readOnly2 != 0);
				byte enabled = (!this.bIsAdminFlag) ? 1 : 0;
				this.timer_move.Enabled = (enabled != 0);
				byte e2 = (!this.bIsAdminFlag) ? 1 : 0;
				this.label_note.Visible = (e2 != 0);
				string dbpath = Application.StartupPath + "\\ctsdb.mdb";
				try
				{
					connection = new OleDbConnection();
					connection.ConnectionString = this.gLineTestProcessor.dbPathStr;
					connection.Open();
					dataReader = new OleDbCommand("select top 1 * from TTestEquipmentInfo", connection).ExecuteReader();
					if (dataReader.Read())
					{
						this.textBox_DLCSY_Model.Text = dataReader["TestEquipmentModel"].ToString();
						this.textBox_DLCSY_SN.Text = dataReader["TestEquipmentSN"].ToString();
					}
					dataReader.Close();
					dataReader = null;
					connection.Close();
					connection = null;
				}
				catch (System.Exception arg_105_0)
				{
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
					KLineTestProcessor.ExceptionRecordFunc(arg_105_0.StackTrace);
				}
			}
			catch (System.Exception arg_113_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_113_0.StackTrace);
			}
		}
		private void timer_move_Tick(object sender, System.EventArgs e)
		{
			try
			{
				this.label_note.Left = this.label_note.Left - 2;
				if (this.label_note.Right <= 3)
				{
					this.label_note.Left = base.Width;
				}
			}
			catch (System.Exception arg_39_0)
			{
				KLineTestProcessor.ExceptionRecordFunc(arg_39_0.StackTrace);
			}
		}
		[HandleProcessCorruptedStateExceptions]
		protected override void Dispose([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U1)] bool flag)
		{
			if (flag)
			{
				try
				{
					this.~FormEquipmentInfoManage();
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
