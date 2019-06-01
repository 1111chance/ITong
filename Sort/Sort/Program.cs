using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sort
{
    /// <summary>
    /// 排序算法
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string info = "0 退出\r\n1 直接插入\r\n2 折半插入\r\n";
            Console.WriteLine(info);
            while (true)
            {
                string line = Console.ReadLine();
                int code;
                if (int.TryParse(line, out code))
                {
                    if (code == 0)
                    {
                        return;
                    }
                    else if (code > 0)
                    {
                        FrmSort frm = new FrmSort(code);
                        frm.ShowDialog();
                    }
                }
                Console.WriteLine(info);
            }
        }
    }

    class FrmSort : Form
    {
        /// <summary>
        /// 1直接插入
        /// 2折半插入
        /// </summary>
        private int code;
        private const int length = 200; //数组宽度
        private const int xBase = 50;   //绘图起始 x 坐标
        private const int yBase = 50;   //绘图起始 y 坐标
        private const int width = 2;   //绘图时每个柱子的宽度
        private const int height = 2;   //绘图时每个柱子的高度放大倍数

        public FrmSort(int code)
        {
            this.Width = 800;
            this.Height = 800;
            this.code = code;
            this.Shown += new System.EventHandler(this.Frm_Shown);
        }

        private void Frm_Shown(object sender, EventArgs e)
        {
            switch (this.code)
            {
                case 1:
                    {
                        Insert();
                        break;
                    }
                case 2:
                    {
                        HalfInsert();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        //获得随机数组
        static List<int> GetRandomList()
        {
            Random rnd = new Random(1);
            List<int> listOriginal = new List<int>();
            for (int i = 1; i < (length + 1); i++)
            {
                listOriginal.Add(i);
            }
            List<int> list = new List<int>();
            foreach (int item in listOriginal)
            {
                list.Insert(rnd.Next(list.Count), item);
            }
            return list;
        }

        //绘图
        private void Draw(List<int> list, int start, int end, Graphics g)
        {
            Pen whitePen = new Pen(Brushes.White, width);
            int recTangleWidth = (end == start)? width: (end - start) * width;
            g.DrawRectangle(whitePen, xBase + start * width, yBase, recTangleWidth, list.Count * height);
            Pen blackPen = new Pen(Brushes.Black, width);
            for (int i = start; i <= end; i++)
            {
                Point point1 = new Point(xBase + i * width, yBase);
                Point point2 = new Point(xBase + i * width, yBase + list[i] * height);
                g.DrawLine(blackPen, point1, point2);
            }
        }

        //直接插入
        private void Insert()
        {
            List<int> list = GetRandomList();
            using (Graphics g = this.CreateGraphics())
            {
                Draw(list, 0, list.Count - 1, g);
                for (int i = 1; i < list.Count; i++)
                {
                    for (int j = i - 1; (j >= 0) && (list[j + 1] < list[j]); j--)
                    {
                        int temp = list[j + 1];
                        list[j + 1] = list[j];
                        list[j] = temp;
                        Draw(list, j, j + 1, g);
                    }
                }
            }
        }

        //折半插入
        private void HalfInsert()
        {
            List<int> list = GetRandomList();
            using (Graphics g = this.CreateGraphics())
            {
                Draw(list, 0, list.Count - 1, g);
                for (int i = 1; i < list.Count; i++)
                {
                    int temp = list[i];
                    int low = 0;
                    int high = i - 1;
                    while (low <= high)
                    {
                        int mid = (low + high) / 2;
                        if (temp < list[mid])
                        {
                            high = mid - 1;
                        }
                        else
                        {
                            low = mid + 1;
                        }
                    }
                    list.RemoveAt(i);
                    list.Insert(low, temp);
                    Draw(list, low, i, g);
                }
            }//end using
        }
    }//end class 
}
