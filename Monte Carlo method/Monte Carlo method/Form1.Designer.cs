namespace Monte_Carlo_method
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
            this.btnStart = new System.Windows.Forms.Button();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bgw1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(65, 56);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 50);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(317, 68);
            this.tb1.Name = "tb1";
            this.tb1.ReadOnly = true;
            this.tb1.Size = new System.Drawing.Size(241, 29);
            this.tb1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "进度：0";
            // 
            // bgw1
            // 
            this.bgw1.WorkerReportsProgress = true;
            this.bgw1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw1_DoWork);
            this.bgw1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw1_ProgressChanged);
            this.bgw1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(633, 166);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.btnStart);
            this.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "蒙特卡洛算法求圆周率";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker bgw1;
    }
}

