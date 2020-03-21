namespace CableTestManager.View
{
    partial class EquipmentInfoManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_note = new System.Windows.Forms.Label();
            this.btn_submit = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_DLCSY_SN = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_DLCSY_Model = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_note
            // 
            this.label_note.AutoSize = true;
            this.label_note.Location = new System.Drawing.Point(510, 123);
            this.label_note.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_note.Name = "label_note";
            this.label_note.Size = new System.Drawing.Size(185, 12);
            this.label_note.TabIndex = 17;
            this.label_note.Text = "若需修改设备信息,请联系管理员.";
            // 
            // btn_submit
            // 
            this.btn_submit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_submit.Location = new System.Drawing.Point(332, 304);
            this.btn_submit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(112, 24);
            this.btn_submit.TabIndex = 14;
            this.btn_submit.Text = "确定";
            this.btn_submit.UseVisualStyleBackColor = true;
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Location = new System.Drawing.Point(496, 304);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(112, 24);
            this.btnQuit.TabIndex = 15;
            this.btnQuit.Text = "取消";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_DLCSY_SN);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBox_DLCSY_Model);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(106, 145);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(562, 144);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "试验设备信息";
            // 
            // textBox_DLCSY_SN
            // 
            this.textBox_DLCSY_SN.Location = new System.Drawing.Point(158, 90);
            this.textBox_DLCSY_SN.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_DLCSY_SN.MaxLength = 120;
            this.textBox_DLCSY_SN.Name = "textBox_DLCSY_SN";
            this.textBox_DLCSY_SN.Size = new System.Drawing.Size(316, 24);
            this.textBox_DLCSY_SN.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 94);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 15);
            this.label10.TabIndex = 6;
            this.label10.Text = "测试仪计量编号:";
            // 
            // textBox_DLCSY_Model
            // 
            this.textBox_DLCSY_Model.Location = new System.Drawing.Point(158, 46);
            this.textBox_DLCSY_Model.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_DLCSY_Model.MaxLength = 120;
            this.textBox_DLCSY_Model.Name = "textBox_DLCSY_Model";
            this.textBox_DLCSY_Model.Size = new System.Drawing.Size(316, 24);
            this.textBox_DLCSY_Model.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "测试仪型号:";
            // 
            // EquipmentInfoManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_note);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.groupBox1);
            this.Name = "EquipmentInfoManager";
            this.Text = "设备信息管理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_note;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_DLCSY_SN;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_DLCSY_Model;
        private System.Windows.Forms.Label label1;
    }
}