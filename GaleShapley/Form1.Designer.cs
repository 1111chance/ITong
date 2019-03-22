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
            this.dgvMale = new System.Windows.Forms.DataGridView();
            this.btnBuild = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.MaleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MalePoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaleESPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaleSF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FemaleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FemalePoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FemaleESPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FemaleSF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.PeopleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PeoplePoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PeopleESPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PeopleSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDManCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMale)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(16, 302);
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
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnBuild);
            this.panel1.Controls.Add(this.numUDManCount);
            this.panel1.Controls.Add(this.tbFemaleSF);
            this.panel1.Controls.Add(this.tbMaleSF);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Start);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 643);
            this.panel1.TabIndex = 1;
            // 
            // numUDManCount
            // 
            this.numUDManCount.Location = new System.Drawing.Point(12, 78);
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
            this.tbFemaleSF.Location = new System.Drawing.Point(12, 439);
            this.tbFemaleSF.Name = "tbFemaleSF";
            this.tbFemaleSF.ReadOnly = true;
            this.tbFemaleSF.Size = new System.Drawing.Size(120, 29);
            this.tbFemaleSF.TabIndex = 6;
            this.tbFemaleSF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMaleSF
            // 
            this.tbMaleSF.BackColor = System.Drawing.SystemColors.Window;
            this.tbMaleSF.Location = new System.Drawing.Point(12, 404);
            this.tbMaleSF.Name = "tbMaleSF";
            this.tbMaleSF.ReadOnly = true;
            this.tbMaleSF.Size = new System.Drawing.Size(120, 29);
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
            this.MalePoint,
            this.MaleESPoint,
            this.MaleSF,
            this.FemaleID,
            this.FemalePoint,
            this.FemaleESPoint,
            this.FemaleSF});
            this.dgvMale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMale.Location = new System.Drawing.Point(0, 0);
            this.dgvMale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvMale.Name = "dgvMale";
            this.dgvMale.ReadOnly = true;
            this.dgvMale.RowHeadersVisible = false;
            this.dgvMale.RowTemplate.Height = 23;
            this.dgvMale.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMale.Size = new System.Drawing.Size(743, 643);
            this.dgvMale.TabIndex = 0;
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(12, 115);
            this.btnBuild.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(100, 50);
            this.btnBuild.TabIndex = 7;
            this.btnBuild.Text = "生成";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvPeople);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(894, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 643);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvMale);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(151, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(743, 643);
            this.panel3.TabIndex = 3;
            // 
            // MaleID
            // 
            this.MaleID.HeaderText = "男性ID";
            this.MaleID.Name = "MaleID";
            this.MaleID.ReadOnly = true;
            // 
            // MalePoint
            // 
            this.MalePoint.HeaderText = "得分";
            this.MalePoint.Name = "MalePoint";
            this.MalePoint.ReadOnly = true;
            // 
            // MaleESPoint
            // 
            this.MaleESPoint.HeaderText = "估分";
            this.MaleESPoint.Name = "MaleESPoint";
            this.MaleESPoint.ReadOnly = true;
            // 
            // MaleSF
            // 
            this.MaleSF.HeaderText = "满意度";
            this.MaleSF.Name = "MaleSF";
            this.MaleSF.ReadOnly = true;
            // 
            // FemaleID
            // 
            this.FemaleID.HeaderText = "女性ID";
            this.FemaleID.Name = "FemaleID";
            this.FemaleID.ReadOnly = true;
            // 
            // FemalePoint
            // 
            this.FemalePoint.HeaderText = "得分";
            this.FemalePoint.Name = "FemalePoint";
            this.FemalePoint.ReadOnly = true;
            // 
            // FemaleESPoint
            // 
            this.FemaleESPoint.HeaderText = "估分";
            this.FemaleESPoint.Name = "FemaleESPoint";
            this.FemaleESPoint.ReadOnly = true;
            // 
            // FemaleSF
            // 
            this.FemaleSF.HeaderText = "满意度";
            this.FemaleSF.Name = "FemaleSF";
            this.FemaleSF.ReadOnly = true;
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AllowUserToDeleteRows = false;
            this.dgvPeople.AllowUserToResizeRows = false;
            this.dgvPeople.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPeople.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PeopleID,
            this.PeoplePoint,
            this.PeopleESPoint,
            this.PeopleSex});
            this.dgvPeople.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPeople.Location = new System.Drawing.Point(0, 0);
            this.dgvPeople.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            this.dgvPeople.RowHeadersVisible = false;
            this.dgvPeople.RowTemplate.Height = 23;
            this.dgvPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeople.Size = new System.Drawing.Size(310, 643);
            this.dgvPeople.TabIndex = 1;
            // 
            // PeopleID
            // 
            this.PeopleID.HeaderText = "人物ID";
            this.PeopleID.Name = "PeopleID";
            this.PeopleID.ReadOnly = true;
            // 
            // PeoplePoint
            // 
            this.PeoplePoint.HeaderText = "得分";
            this.PeoplePoint.Name = "PeoplePoint";
            this.PeoplePoint.ReadOnly = true;
            // 
            // PeopleESPoint
            // 
            this.PeopleESPoint.HeaderText = "估分";
            this.PeopleESPoint.Name = "PeopleESPoint";
            this.PeopleESPoint.ReadOnly = true;
            // 
            // PeopleSex
            // 
            this.PeopleSex.HeaderText = "性别";
            this.PeopleSex.Name = "PeopleSex";
            this.PeopleSex.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "满意度";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 643);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvMale)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvMale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMaleSF;
        private System.Windows.Forms.TextBox tbFemaleSF;
        private System.Windows.Forms.NumericUpDown numUDManCount;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MalePoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaleESPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaleSF;
        private System.Windows.Forms.DataGridViewTextBoxColumn FemaleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FemalePoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn FemaleESPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn FemaleSF;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeopleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeoplePoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeopleESPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeopleSex;
        private System.Windows.Forms.Label label2;
    }
}

