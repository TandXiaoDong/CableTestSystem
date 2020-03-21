namespace CableTestManager.View
{
    partial class PinPinContrast
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_xh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_startInterface = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_startPin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_stopInterface = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_stopPin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnShowUnSame = new System.Windows.Forms.Button();
            this.btnShowSame = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnExportPinRelation = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 11);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(779, 476);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(385, 472);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已定义连接关系";
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
            this.Column_stopPin});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(2, 19);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(381, 451);
            this.dataGridView1.TabIndex = 15;
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
            this.Column_startInterface.Width = 90;
            // 
            // Column_startPin
            // 
            this.Column_startPin.HeaderText = "起点接点";
            this.Column_startPin.Name = "Column_startPin";
            this.Column_startPin.ReadOnly = true;
            this.Column_startPin.Width = 90;
            // 
            // Column_stopInterface
            // 
            this.Column_stopInterface.HeaderText = "终点接口";
            this.Column_stopInterface.Name = "Column_stopInterface";
            this.Column_stopInterface.ReadOnly = true;
            this.Column_stopInterface.Width = 90;
            // 
            // Column_stopPin
            // 
            this.Column_stopPin.HeaderText = "终点接点";
            this.Column_stopPin.Name = "Column_stopPin";
            this.Column_stopPin.ReadOnly = true;
            this.Column_stopPin.Width = 90;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(391, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(386, 472);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "自学习芯线关系";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(2, 19);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(382, 451);
            this.dataGridView2.TabIndex = 16;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "序号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "起点接口";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "起点接点";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "终点接口";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 90;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "终点接点";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.flowLayoutPanel1.Controls.Add(this.btnShowUnSame);
            this.flowLayoutPanel1.Controls.Add(this.btnShowSame);
            this.flowLayoutPanel1.Controls.Add(this.btnShowAll);
            this.flowLayoutPanel1.Controls.Add(this.btnExportPinRelation);
            this.flowLayoutPanel1.Controls.Add(this.btnQuit);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(44, 509);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(712, 30);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // btnShowUnSame
            // 
            this.btnShowUnSame.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnShowUnSame.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShowUnSame.Location = new System.Drawing.Point(15, 2);
            this.btnShowUnSame.Margin = new System.Windows.Forms.Padding(15, 2, 2, 2);
            this.btnShowUnSame.Name = "btnShowUnSame";
            this.btnShowUnSame.Size = new System.Drawing.Size(120, 24);
            this.btnShowUnSame.TabIndex = 1;
            this.btnShowUnSame.Text = "仅显示差异项";
            this.btnShowUnSame.UseVisualStyleBackColor = true;
            // 
            // btnShowSame
            // 
            this.btnShowSame.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnShowSame.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShowSame.Location = new System.Drawing.Point(152, 2);
            this.btnShowSame.Margin = new System.Windows.Forms.Padding(15, 2, 2, 2);
            this.btnShowSame.Name = "btnShowSame";
            this.btnShowSame.Size = new System.Drawing.Size(120, 24);
            this.btnShowSame.TabIndex = 2;
            this.btnShowSame.Text = "仅显示相同项";
            this.btnShowSame.UseVisualStyleBackColor = true;
            // 
            // btnShowAll
            // 
            this.btnShowAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnShowAll.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShowAll.Location = new System.Drawing.Point(289, 2);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(15, 2, 2, 2);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(120, 24);
            this.btnShowAll.TabIndex = 3;
            this.btnShowAll.Text = "显示所有";
            this.btnShowAll.UseVisualStyleBackColor = true;
            // 
            // btnExportPinRelation
            // 
            this.btnExportPinRelation.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExportPinRelation.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExportPinRelation.Location = new System.Drawing.Point(426, 2);
            this.btnExportPinRelation.Margin = new System.Windows.Forms.Padding(15, 2, 2, 2);
            this.btnExportPinRelation.Name = "btnExportPinRelation";
            this.btnExportPinRelation.Size = new System.Drawing.Size(120, 24);
            this.btnExportPinRelation.TabIndex = 4;
            this.btnExportPinRelation.Text = "导出学习关系";
            this.btnExportPinRelation.UseVisualStyleBackColor = true;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnQuit.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuit.Location = new System.Drawing.Point(563, 2);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(15, 2, 2, 2);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(120, 24);
            this.btnQuit.TabIndex = 0;
            this.btnQuit.Text = "关闭";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // PinPinContrast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 598);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "PinPinContrast";
            this.Text = "连接关系对比";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_xh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_startInterface;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_startPin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_stopInterface;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_stopPin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnShowUnSame;
        private System.Windows.Forms.Button btnShowSame;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnExportPinRelation;
        private System.Windows.Forms.Button btnQuit;
    }
}