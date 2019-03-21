using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monte_Carlo_method
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            bgw1.RunWorkerAsync();
        }

        private void bgw1_DoWork(object sender, DoWorkEventArgs e)
        {
            double N = Math.Pow(10, 8);
            double reportStep = N / 100;
            double count = 0;
            Random rnd = new Random();
            double x, y;
            for (int i = 0; i < N; i++)
            {
                if ((i % reportStep) == 0)
                {
                    bgw1.ReportProgress((int)(i / reportStep));
                }
                x = rnd.NextDouble();
                y = rnd.NextDouble();
                if ((x * x + y * y) < 1.0d)
                {
                    count++;
                }
            }
            double pi = 4 * count / N;
            e.Result = pi.ToString();
        }

        private void bgw1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label1.Text = "进度：" + e.ProgressPercentage.ToString() + " %";
        }

        private void bgw1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label1.Text = "进度：100%";
            tb1.Text = e.Result as string;
        }
    }
}
