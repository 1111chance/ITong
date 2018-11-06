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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvMale = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvFemale = new System.Windows.Forms.DataGridView();
            this.MaleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaleSF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FemaleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FemaleSF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMale)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFemale)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(27, 59);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(100, 50);
            this.Start.TabIndex = 0;
            this.Start.Text = "开始";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Start);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 501);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvFemale);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(734, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(468, 501);
            this.panel2.TabIndex = 2;
            // 
            // dgvMale
            // 
            this.dgvMale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaleID,
            this.MaleSF});
            this.dgvMale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMale.Location = new System.Drawing.Point(0, 0);
            this.dgvMale.Name = "dgvMale";
            this.dgvMale.RowTemplate.Height = 23;
            this.dgvMale.Size = new System.Drawing.Size(534, 501);
            this.dgvMale.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvMale);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(200, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(534, 501);
            this.panel3.TabIndex = 3;
            // 
            // dgvFemale
            // 
            this.dgvFemale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFemale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FemaleID,
            this.FemaleSF});
            this.dgvFemale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFemale.Location = new System.Drawing.Point(0, 0);
            this.dgvFemale.Name = "dgvFemale";
            this.dgvFemale.RowTemplate.Height = 23;
            this.dgvFemale.Size = new System.Drawing.Size(468, 501);
            this.dgvFemale.TabIndex = 1;
            // 
            // MaleID
            // 
            this.MaleID.HeaderText = "男性ID";
            this.MaleID.Name = "MaleID";
            this.MaleID.Width = 240;
            // 
            // MaleSF
            // 
            this.MaleSF.HeaderText = "满意度";
            this.MaleSF.Name = "MaleSF";
            this.MaleSF.Width = 240;
            // 
            // FemaleID
            // 
            this.FemaleID.HeaderText = "女性ID";
            this.FemaleID.Name = "FemaleID";
            this.FemaleID.Width = 239;
            // 
            // FemaleSF
            // 
            this.FemaleSF.HeaderText = "满意度";
            this.FemaleSF.Name = "FemaleSF";
            this.FemaleSF.Width = 240;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 501);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMale)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFemale)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvMale;
        private System.Windows.Forms.DataGridView dgvFemale;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaleSF;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn FemaleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FemaleSF;
    }
}

