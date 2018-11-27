using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//https://www.zhihu.com/question/23293449/answer/120185075

namespace Shell
{
    public partial class Form1 : Form
    {
        private int count = 0;      //繁殖代数

        public Form1()
        {
            InitializeComponent();
            Shell.OriginalBitmap = (Bitmap)Resource1.ResourceManager.GetObject("Firefox");
            Gene.SizeOfTriangle = Shell.OriginalBitmap.Width / 2;
            pb1.Width = pb2.Width = Shell.OriginalBitmap.Width;
            pb1.Height = pb2.Height = Shell.OriginalBitmap.Height;
            pb2.BackgroundImage = Shell.OriginalBitmap;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(tbCount.Text);
                for (int i = 0; i < number; i++)
                {
                    Shell.Reproduction();
                    Shell best = Shell.GetBestShell();
                    if (i % 50 == 0)
                    {
                        pb1.BackgroundImage = best.Map;
                        pb1.Update();
                        string str = "繁殖代数：" + count + "  适应度：" + best.Fitness;
                        Console.WriteLine(str);
                        lblInfo.Text = str;
                        lblInfo.Update();
                    }

                    count++;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("繁殖次数填写错误");
            }
        }
    }
}
