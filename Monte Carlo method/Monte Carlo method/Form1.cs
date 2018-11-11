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
            double N = 1000000000;
            double count = 0;
            Random rnd = new Random();
            double x, y;
            for (int i = 0; i < N; i++)
            {
                x = rnd.NextDouble();
                y = rnd.NextDouble();
                if ((x * x + y * y) < 1.0d)
                {
                    count++;
                }
            }
            double pi = 4 * count / N;
            textBox1.Text = pi.ToString();
        }
    }
}
