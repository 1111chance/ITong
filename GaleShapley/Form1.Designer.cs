namespace GaleShapley
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Start = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numUDManCount = new System.Windows.Forms.NumericUpDown();
            this.tbFemaleSF = new System.Windows.Forms.TextBox();
            this.tbMaleSF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvFemale = new System.Windows.Forms.DataGridView();
            this.FemaleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FemaleSF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMale = new System.Windows.Forms.DataGridView();
            this.MaleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaleSF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDManCount)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFemale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMale)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(175, 297);
            this.Start.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(100, 50);
            this.Start.TabIndex = 0;
            this.Start.Text = "开始";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.numUDManCount);
            this.panel1.Controls.Add(this.tbFemaleSF);
            this.panel1.Controls.Add(this.tbMaleSF);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Start);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 579);
            this.panel1.TabIndex = 1;
            // 
            // numUDManCount
            // 
            this.numUDManCount.Location = new System.Drawing.Point(108, 52);
            this.numUDManCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUDManCount.Name = "numUDManCount";
            this.numUDManCount.Size = new System.Drawing.Size(120, 29);
            this.numUDManCount.TabIndex = 1;
            this.numUDManCount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUDManCount.ValueChanged += new System.EventHandler(this.numUDManCount_ValueChanged);
            // 
            // tbFemaleSF
            // 
            this.tbFemaleSF.BackColor = System.Drawing.SystemColors.Window;
            this.tbFemaleSF.Location = new System.Drawing.Point(12, 239);
            this.tbFemaleSF.Name = "tbFemaleSF";
            this.tbFemaleSF.ReadOnly = true;
            this.tbFemaleSF.Size = new System.Drawing.Size(263, 29);
            this.tbFemaleSF.TabIndex = 6;
            this.tbFemaleSF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMaleSF
            // 
            this.tbMaleSF.BackColor = System.Drawing.SystemColors.Window;
            this.tbMaleSF.Location = new System.Drawing.Point(12, 188);
            this.tbMaleSF.Name = "tbMaleSF";
            this.tbMaleSF.ReadOnly = true;
            this.tbMaleSF.Size = new System.Drawing.Size(263, 29);
            this.tbMaleSF.TabIndex = 5;
            this.tbMaleSF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "人    数：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvFemale);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(610, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 579);
            this.panel2.TabIndex = 2;
            // 
            // dgvFemale
            // 
            this.dgvFemale.AllowUserToAddRows = false;
            this.dgvFemale.AllowUserToDeleteRows = false;
            this.dgvFemale.AllowUserToResizeRows = false;
            this.dgvFemale.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFemale.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvFemale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFemale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FemaleID,
            this.FemaleSF});
            this.dgvFemale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFemale.Location = new System.Drawing.Point(0, 0);
            this.dgvFemale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvFemale.Name = "dgvFemale";
            this.dgvFemale.ReadOnly = true;
            this.dgvFemale.RowTemplate.Height = 23;
            this.dgvFemale.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFemale.Size = new System.Drawing.Size(319, 579);
            this.dgvFemale.TabIndex = 1;
            // 
            // FemaleID
            // 
            this.FemaleID.HeaderText = "女性ID";
            this.FemaleID.Name = "FemaleID";
            this.FemaleID.ReadOnly = true;
            // 
            // FemaleSF
            // 
            this.FemaleSF.HeaderText = "满意度";
            this.FemaleSF.Name = "FemaleSF";
            this.FemaleSF.ReadOnly = true;
            // 
            // dgvMale
            // 
            this.dgvMale.AllowUserToAddRows = false;
            this.dgvMale.AllowUserToDeleteRows = false;
            this.dgvMale.AllowUserToResizeRows = false;
            this.dgvMale.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMale.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvMale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaleID,
            this.MaleSF});
            this.dgvMale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMale.Location = new System.Drawing.Point(0, 0);
            this.dgvMale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvMale.Name = "dgvMale";
            this.dgvMale.ReadOnly = true;
            this.dgvMale.RowTemplate.Height = 23;
            this.dgvMale.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMale.Size = new System.Drawing.Size(277, 579);
            this.dgvMale.TabIndex = 0;
            // 
            // MaleID
            // 
            this.MaleID.HeaderText = "男性ID";
            this.MaleID.Name = "MaleID";
            this.MaleID.ReadOnly = true;
            // 
            // MaleSF
            // 
            this.MaleSF.HeaderText = "满意度";
            this.MaleSF.Name = "MaleSF";
            this.MaleSF.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvMale);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(333, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(277, 579);
            this.panel3.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 579);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "盖尔-沙普利[Gale-Shapley]婚姻稳定匹配算法";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDManCount)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFemale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMale)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvMale;
        private System.Windows.Forms.DataGridView dgvFemale;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn FemaleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FemaleSF;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaleSF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMaleSF;
        private System.Windows.Forms.TextBox tbFemaleSF;
        private System.Windows.Forms.NumericUpDown numUDManCount;
    }
}

