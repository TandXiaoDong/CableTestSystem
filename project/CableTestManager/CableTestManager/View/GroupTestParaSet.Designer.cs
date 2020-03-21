namespace CableTestManager.View
{
    partial class GroupTestParaSet
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
            this.btnPLXG = new System.Windows.Forms.Button();
            this.textBox_bcCable = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_xh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_startInterface = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_startPin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_stopInterface = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_stopPin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DTThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_JYThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_JYTestTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_JYVoltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_NYThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_NYTestTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_NYVoltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPLXG
            // 
            this.btnPLXG.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPLXG.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPLXG.Location = new System.Drawing.Point(315, 634);
            this.btnPLXG.Margin = new System.Windows.Forms.Padding(2);
            this.btnPLXG.Name = "btnPLXG";
            this.btnPLXG.Size = new System.Drawing.Size(90, 24);
            this.btnPLXG.TabIndex = 17;
            this.btnPLXG.Text = "批量修改";
            this.btnPLXG.UseVisualStyleBackColor = true;
            // 
            // textBox_bcCable
            // 
            this.textBox_bcCable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_bcCable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_bcCable.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_bcCable.Location = new System.Drawing.Point(109, 18);
            this.textBox_bcCable.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_bcCable.Name = "textBox_bcCable";
            this.textBox_bcCable.ReadOnly = true;
            this.textBox_bcCable.Size = new System.Drawing.Size(861, 17);
            this.textBox_bcCable.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "被测线束:";
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Location = new System.Drawing.Point(632, 634);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(90, 24);
            this.btnQuit.TabIndex = 14;
            this.btnQuit.Text = "取消";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit.Location = new System.Drawing.Point(473, 634);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(90, 24);
            this.btnSubmit.TabIndex = 13;
            this.btnSubmit.Text = "确定";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(17, 55);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1003, 559);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "分组测试参数表（双击行可单个编辑）";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_xh,
            this.Column_startInterface,
            this.Column_startPin,
            this.Column_stopInterface,
            this.Column_stopPin,
            this.Column_DTThreshold,
            this.Column_JYThreshold,
            this.Column_JYTestTime,
            this.Column_JYVoltage,
            this.Column_NYThreshold,
            this.Column_NYTestTime,
            this.Column_NYVoltage});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(2, 19);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(999, 538);
            this.dataGridView1.TabIndex = 13;
            // 
            // Column_xh
            // 
            this.Column_xh.HeaderText = "序号";
            this.Column_xh.Name = "Column_xh";
            this.Column_xh.ReadOnly = true;
            this.Column_xh.Width = 70;
            // 
            // Column_startInterface
            // 
            this.Column_startInterface.HeaderText = "起点接口";
            this.Column_startInterface.Name = "Column_startInterface";
            this.Column_startInterface.ReadOnly = true;
            // 
            // Column_startPin
            // 
            this.Column_startPin.HeaderText = "起点接点";
            this.Column_startPin.Name = "Column_startPin";
            this.Column_startPin.ReadOnly = true;
            // 
            // Column_stopInterface
            // 
            this.Column_stopInterface.HeaderText = "终点接口";
            this.Column_stopInterface.Name = "Column_stopInterface";
            this.Column_stopInterface.ReadOnly = true;
            // 
            // Column_stopPin
            // 
            this.Column_stopPin.HeaderText = "终点接点";
            this.Column_stopPin.Name = "Column_stopPin";
            this.Column_stopPin.ReadOnly = true;
            // 
            // Column_DTThreshold
            // 
            this.Column_DTThreshold.HeaderText = "导通阈值\n(Ω)";
            this.Column_DTThreshold.Name = "Column_DTThreshold";
            this.Column_DTThreshold.ReadOnly = true;
            // 
            // Column_JYThreshold
            // 
            this.Column_JYThreshold.HeaderText = "绝缘阈值\n(MΩ)";
            this.Column_JYThreshold.Name = "Column_JYThreshold";
            this.Column_JYThreshold.ReadOnly = true;
            // 
            // Column_JYTestTime
            // 
            this.Column_JYTestTime.HeaderText = "绝缘保持\n时间(s)";
            this.Column_JYTestTime.Name = "Column_JYTestTime";
            this.Column_JYTestTime.ReadOnly = true;
            // 
            // Column_JYVoltage
            // 
            this.Column_JYVoltage.HeaderText = "绝缘电压\n(VDC)";
            this.Column_JYVoltage.Name = "Column_JYVoltage";
            this.Column_JYVoltage.ReadOnly = true;
            // 
            // Column_NYThreshold
            // 
            this.Column_NYThreshold.HeaderText = "耐压阈值\n(mA)";
            this.Column_NYThreshold.Name = "Column_NYThreshold";
            this.Column_NYThreshold.ReadOnly = true;
            // 
            // Column_NYTestTime
            // 
            this.Column_NYTestTime.HeaderText = "耐压保持\n时间(s)";
            this.Column_NYTestTime.Name = "Column_NYTestTime";
            this.Column_NYTestTime.ReadOnly = true;
            // 
            // Column_NYVoltage
            // 
            this.Column_NYVoltage.HeaderText = "耐压电压\n(VAC)";
            this.Column_NYVoltage.Name = "Column_NYVoltage";
            this.Column_NYVoltage.ReadOnly = true;
            // 
            // GroupTestParaSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 816);
            this.Controls.Add(this.btnPLXG);
            this.Controls.Add(this.textBox_bcCable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.groupBox1);
            this.Name = "GroupTestParaSet";
            this.Text = "分组测试参数设置";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPLXG;
        private System.Windows.Forms.TextBox textBox_bcCable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_xh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_startInterface;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_startPin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_stopInterface;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_stopPin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DTThreshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_JYThreshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_JYTestTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_JYVoltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_NYThreshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_NYTestTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_NYVoltage;
    }
}