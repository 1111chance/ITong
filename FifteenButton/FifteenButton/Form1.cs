using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FifteenButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int arC = 0;
        const int N = 4;    //边长
        Button[] buttons = new Button[N * N];   //建立表格
        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Button blank = FindHiddenButton();
            int a = int.Parse(btn.Name);
            int b = int.Parse(blank.Name);
            if (IsNeighbor(a, b))
            {
                Swap(btn, blank);
                blank.Focus();
            }
            if (ResultIsOk())
            {
                MessageBox.Show("ok");
            }
        }

        int GetButtonIndex(Button btn)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i] == btn)
                {
                    return i;
                }
            }
            return -1;
        }

        //判断是否为相邻按钮
        bool IsNeighbor(int a, int b)
        {
            int r1 = a / N, c1 = a % N;
            int r2 = b / N, c2 = b % N;
            if (r1 == r2 && (c1 == c2 - 1 || c1 == c2 + 1)
                ||
                c1 == c2 && (r1 == r2 - 1 || r1 == r2 + 1))
                return true;
            return false;
        }

        //判断游戏是否结束
        bool ResultIsOk()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Text != (i + 1).ToString())
                {
                    return false;
                }
            }
            return true;
        }

        //寻找隐藏按钮
        Button FindHiddenButton()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (!buttons[i].Visible) return buttons[i];
            }
            return null;
        }

        //创建按钮
        void GenerateAllButtons()
        {
            //如果已存在15子按钮，则不创建按钮，直接返回，或删除原按钮后创建
            if (arC == 2)
            {
                return;
                //for (int i = 0; i < buttons.Length; i++)
                //{
                //    Controls.RemoveByKey(i.ToString());
                //}
            }
            //基点定义，高度定义，间隔定义
            int x0 = 100, y0 = 100, w = 45, d = 50;
            for (int i = 0; i < buttons.Length; i++)
            {
                Button btn = new Button();
                int r = i / N;  // 行
                int c = i % N;  // 列
                btn.Name = i.ToString();
                btn.Text = (i + 1).ToString();
                btn.Top = y0 + r * d;
                btn.Left = x0 + c * d;
                btn.Width = w;
                btn.Height = w;
                btn.Visible = true;
                btn.Click += new EventHandler(btn_Click);   //注册事件
                buttons[i] = btn;
                this.Controls.Add(btn);
            }
            buttons[N * N - 1].Visible = false;
        }

        //打乱按钮显示的字符串和可见性
        void Shuffle()
        {
            Random rnd = new Random();
            Button blank = FindHiddenButton();
            int a = int.Parse(blank.Name);
            for (int i = 0; i < 300; i++)//打乱次数对性能影响很大
            {
                blank = buttons[a];
                //   a = int.Parse(blank.Name);
                int r1 = a / N, c1 = a % N;
                int c = rnd.Next(4);
                switch (c)
                {
                    //上
                    case 0:
                        if (r1 != 0)
                        {
                            moveUp(blank, a);
                            a = a - N;
                        }
                        break;
                    //下
                    case 1:
                        if (r1 != N - 1)
                        {
                            moveDown(blank, a);
                            a = a + N;
                        }
                        break;
                    //左
                    case 2:
                        if (c1 != 0)
                        {
                            moveLeft(blank, a);
                            a = a - 1;
                        }
                        break;
                    //右
                    case 3:
                        if (c1 != N - 1)
                        {
                            moveRight(blank, a);
                            a = a + 1;
                        }
                        break;
                }
            }
        }

        void moveUp(Button blank, int a)
        {
            Button btn = new Button();
            btn = buttons[a - N];
            Swap(blank, btn);
        }
        void moveDown(Button blank, int a)
        {
            Button btn = new Button();
            btn = buttons[a + N];
            Swap(blank, btn);
        }
        void moveLeft(Button blank, int a)
        {
            Button btn = new Button();
            btn = buttons[a - 1];
            Swap(blank, btn);
        }
        void moveRight(Button blank, int a)
        {
            Button btn = new Button();
            btn = buttons[a + 1];
            Swap(blank, btn);
        }


        //交换按钮的text属性和visible属性
        void Swap(Button btna, Button btnb)
        {
            string t = btna.Text;
            btna.Text = btnb.Text;
            btnb.Text = t;

            bool v = btna.Visible;
            btna.Visible = btnb.Visible;
            btnb.Visible = v;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //创建按钮
            GenerateAllButtons();
            //打乱按钮
            Shuffle();

            arC = 2;
        }
    }
}
