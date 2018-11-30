namespace FormApp
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
            this.btnToken = new System.Windows.Forms.Button();
            this.btnRemindList = new System.Windows.Forms.Button();
            this.btnUserList = new System.Windows.Forms.Button();
            this.btnGetImg = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnToken
            // 
            this.btnToken.Location = new System.Drawing.Point(91, 40);
            this.btnToken.Name = "btnToken";
            this.btnToken.Size = new System.Drawing.Size(86, 61);
            this.btnToken.TabIndex = 0;
            this.btnToken.Text = "获取 token";
            this.btnToken.UseVisualStyleBackColor = true;
            this.btnToken.Click += new System.EventHandler(this.btnToken_Click);
            // 
            // btnRemindList
            // 
            this.btnRemindList.Location = new System.Drawing.Point(183, 40);
            this.btnRemindList.Name = "btnRemindList";
            this.btnRemindList.Size = new System.Drawing.Size(86, 61);
            this.btnRemindList.TabIndex = 2;
            this.btnRemindList.Text = "获取提醒模板";
            this.btnRemindList.UseVisualStyleBackColor = true;
            this.btnRemindList.Click += new System.EventHandler(this.btnRemindList_Click);
            // 
            // btnUserList
            // 
            this.btnUserList.Location = new System.Drawing.Point(91, 121);
            this.btnUserList.Name = "btnUserList";
            this.btnUserList.Size = new System.Drawing.Size(86, 61);
            this.btnUserList.TabIndex = 4;
            this.btnUserList.Text = "获取用户列表";
            this.btnUserList.UseVisualStyleBackColor = true;
            this.btnUserList.Click += new System.EventHandler(this.btnUserList_Click);
            // 
            // btnGetImg
            // 
            this.btnGetImg.Location = new System.Drawing.Point(183, 121);
            this.btnGetImg.Name = "btnGetImg";
            this.btnGetImg.Size = new System.Drawing.Size(86, 61);
            this.btnGetImg.TabIndex = 6;
            this.btnGetImg.Text = "获取二维码";
            this.btnGetImg.UseVisualStyleBackColor = true;
            this.btnGetImg.Click += new System.EventHandler(this.btnGetImg_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTest);
            this.panel1.Controls.Add(this.btnGetImg);
            this.panel1.Controls.Add(this.btnToken);
            this.panel1.Controls.Add(this.btnUserList);
            this.panel1.Controls.Add(this.btnRemindList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 744);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(562, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(725, 744);
            this.panel2.TabIndex = 8;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(91, 585);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(86, 61);
            this.btnTest.TabIndex = 7;
            this.btnTest.Text = "test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1287, 744);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "测试微信公众号";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnToken;
        private System.Windows.Forms.Button btnRemindList;
        private System.Windows.Forms.Button btnUserList;
        private System.Windows.Forms.Button btnGetImg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTest;
    }
}

