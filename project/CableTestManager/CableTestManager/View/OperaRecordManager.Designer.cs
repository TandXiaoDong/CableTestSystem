namespace CableTestManager.View
{
    partial class OperaRecordManager
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
            this.btnFuzzyQuery = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_stop = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.textBox_user = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_result = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnDetailView = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox_result.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFuzzyQuery
            // 
            this.btnFuzzyQuery.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFuzzyQuery.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFuzzyQuery.Location = new System.Drawing.Point(262, 109);
            this.btnFuzzyQuery.Margin = new System.Windows.Forms.Padding(2);
            this.btnFuzzyQuery.Name = "btnFuzzyQuery";
            this.btnFuzzyQuery.Size = new System.Drawing.Size(112, 24);
            this.btnFuzzyQuery.TabIndex = 7;
            this.btnFuzzyQuery.Text = "模糊查询";
            this.btnFuzzyQuery.UseVisualStyleBackColor = true;
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(415, 109);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(112, 24);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.dateTimePicker_stop);
            this.groupBox1.Controls.Add(this.dateTimePicker_start);
            this.groupBox1.Controls.Add(this.textBox_user);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(11, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(768, 70);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // dateTimePicker_stop
            // 
            this.dateTimePicker_stop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker_stop.Location = new System.Drawing.Point(554, 29);
            this.dateTimePicker_stop.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_stop.Name = "dateTimePicker_stop";
            this.dateTimePicker_stop.Size = new System.Drawing.Size(151, 24);
            this.dateTimePicker_stop.TabIndex = 3;
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker_start.CustomFormat = "";
            this.dateTimePicker_start.Location = new System.Drawing.Point(370, 29);
            this.dateTimePicker_start.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(151, 24);
            this.dateTimePicker_start.TabIndex = 2;
            // 
            // textBox_user
            // 
            this.textBox_user.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox_user.Location = new System.Drawing.Point(128, 29);
            this.textBox_user.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_user.MaxLength = 32;
            this.textBox_user.Name = "textBox_user";
            this.textBox_user.Size = new System.Drawing.Size(151, 24);
            this.textBox_user.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(526, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "至";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "日期:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "操作者:";
            // 
            // groupBox_result
            // 
            this.groupBox_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_result.Controls.Add(this.dataGridView1);
            this.groupBox_result.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox_result.Location = new System.Drawing.Point(11, 146);
            this.groupBox_result.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_result.Name = "groupBox_result";
            this.groupBox_result.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_result.Size = new System.Drawing.Size(767, 309);
            this.groupBox_result.TabIndex = 9;
            this.groupBox_result.TabStop = false;
            this.groupBox_result.Text = "查询结果";
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
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(2, 19);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(763, 288);
            this.dataGridView1.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "操作者";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "操作时间";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 156;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "操作内容";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 240;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExport.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Location = new System.Drawing.Point(245, 488);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(112, 24);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "导出报表";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDel.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.Location = new System.Drawing.Point(143, 488);
            this.btnDel.Margin = new System.Windows.Forms.Padding(2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(48, 24);
            this.btnDel.TabIndex = 11;
            this.btnDel.Text = "删除记录";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Visible = false;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Location = new System.Drawing.Point(437, 488);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(112, 24);
            this.btnQuit.TabIndex = 13;
            this.btnQuit.Text = "取消";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnDetailView
            // 
            this.btnDetailView.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDetailView.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDetailView.Location = new System.Drawing.Point(79, 488);
            this.btnDetailView.Margin = new System.Windows.Forms.Padding(2);
            this.btnDetailView.Name = "btnDetailView";
            this.btnDetailView.Size = new System.Drawing.Size(57, 24);
            this.btnDetailView.TabIndex = 12;
            this.btnDetailView.Text = "查看明细";
            this.btnDetailView.UseVisualStyleBackColor = true;
            this.btnDetailView.Visible = false;
            // 
            // OperaRecordManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 598);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnDetailView);
            this.Controls.Add(this.groupBox_result);
            this.Controls.Add(this.btnFuzzyQuery);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.groupBox1);
            this.Name = "OperaRecordManager";
            this.Text = "操作记录管理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_result.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFuzzyQuery;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_stop;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.TextBox textBox_user;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox_result;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnDetailView;
    }
}