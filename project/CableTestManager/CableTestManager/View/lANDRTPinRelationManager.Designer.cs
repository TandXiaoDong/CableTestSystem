namespace CableTestManager.View
{
    partial class lANDRTPinRelationManager
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
            this.numericUpDown_AT = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_pin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_rc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnPLXG = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AT)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown_AT
            // 
            this.numericUpDown_AT.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numericUpDown_AT.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDown_AT.Location = new System.Drawing.Point(741, 511);
            this.numericUpDown_AT.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown_AT.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDown_AT.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_AT.Name = "numericUpDown_AT";
            this.numericUpDown_AT.Size = new System.Drawing.Size(90, 24);
            this.numericUpDown_AT.TabIndex = 11;
            this.numericUpDown_AT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_AT.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_AT.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(96, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(613, 543);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测试仪与转接台针脚映射关系表";
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
            this.Column_pin,
            this.Column_rc});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(2, 19);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(609, 522);
            this.dataGridView1.TabIndex = 15;
            // 
            // Column_pin
            // 
            this.Column_pin.HeaderText = "测试仪针脚号";
            this.Column_pin.Name = "Column_pin";
            this.Column_pin.ReadOnly = true;
            this.Column_pin.Width = 197;
            // 
            // Column_rc
            // 
            this.Column_rc.HeaderText = "转接台针脚号";
            this.Column_rc.Name = "Column_rc";
            this.Column_rc.ReadOnly = true;
            this.Column_rc.Width = 197;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Location = new System.Drawing.Point(741, 435);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(90, 24);
            this.btnQuit.TabIndex = 8;
            this.btnQuit.Text = "取消";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnPLXG
            // 
            this.btnPLXG.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPLXG.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPLXG.Location = new System.Drawing.Point(741, 129);
            this.btnPLXG.Margin = new System.Windows.Forms.Padding(2);
            this.btnPLXG.Name = "btnPLXG";
            this.btnPLXG.Size = new System.Drawing.Size(90, 24);
            this.btnPLXG.TabIndex = 9;
            this.btnPLXG.Text = "批量修改";
            this.btnPLXG.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSubmit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit.Location = new System.Drawing.Point(741, 272);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(90, 24);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "确定";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // lANDRTPinRelationManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 610);
            this.Controls.Add(this.numericUpDown_AT);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnPLXG);
            this.Controls.Add(this.btnSubmit);
            this.Name = "lANDRTPinRelationManager";
            this.Text = "测试仪与转接台针脚映射关系管理";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AT)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown_AT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_pin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_rc;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnPLXG;
        private System.Windows.Forms.Button btnSubmit;
    }
}