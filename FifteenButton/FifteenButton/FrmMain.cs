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
    public partial class FrmMain : Form
    {
        #region Field
        private List<ChessMan> chessManList;
        private int N = 4;       //边长
        private int X0 = 100;    //横向起始坐标
        private int Y0 = 100;    //竖向起始坐标
        private int Step = 50;   //按钮间距
        private int CmWidth = 45;    //按钮宽度
        private int MoveCount = 200; //移动次数
        private ChessMan hiddenCm;

        public FrmMain()
        {
            InitializeComponent();
        }
        #endregion

        #region Event
        //开始
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (chessManList == null)
            {
                InitChessMan();
            }
            //MoveCm();
            MoveCm2();
        }

        //点击按钮
        private void ChessMan_Click(object sender, EventArgs e)
        {
            ChessMan cm = sender as ChessMan;
            int differ = Math.Abs(cm.Index - hiddenCm.Index);
            if (differ == 1 || differ == N)
            {
                ExChange(ref hiddenCm, cm);
            }
            if (GameOver())
            {
                MessageBox.Show("游戏结束");
            }
        }
        #endregion

        #region Method
        //初始化所有按钮
        private void InitChessMan()
        {
            chessManList = new List<ChessMan>();
            for (int i = 0; i < N * N; i++)
            {
                ChessMan cm = new ChessMan();
                cm.Text = (i + 1).ToString();
                cm.RowIndex = i / N;
                cm.ColumnIndex = i % N;
                cm.Index = i;
                cm.Width = CmWidth;
                cm.Height = CmWidth;
                cm.Top = Y0 + cm.RowIndex * Step;
                cm.Left = X0 + cm.ColumnIndex * Step;
                if (i == (N * N - 1))
                {
                    cm.Visible = false;
                    this.hiddenCm = cm;
                }
                else
                {
                    cm.Visible = true;
                }
                chessManList.Add(cm);
                cm.Click += new EventHandler(ChessMan_Click);
                this.Controls.Add(cm);
            }
        }

        //打乱所有按钮
        private void MoveCm()
        {
            Random rnd = new Random();
            for (int i = 0; i < MoveCount; i++)
            {
                int direction = rnd.Next(4);
                switch (direction)
                {
                    //上
                    case 0:
                        {
                            if (this.hiddenCm.RowIndex == 0)
                            {
                                break;
                            }
                            int index = this.hiddenCm.ColumnIndex + N * (this.hiddenCm.RowIndex - 1);
                            ChessMan cm = chessManList[index];
                            ExChange(ref this.hiddenCm, cm);
                            break;
                        }
                    //下
                    case 1:
                        {
                            if (this.hiddenCm.RowIndex == (N - 1))
                            {
                                break;
                            }
                            int index = this.hiddenCm.ColumnIndex + N * (this.hiddenCm.RowIndex + 1);
                            ChessMan cm = chessManList[index];
                            ExChange(ref this.hiddenCm, cm);
                            break;
                        }
                    //左
                    case 2:
                        {
                            if (this.hiddenCm.ColumnIndex == 0)
                            {
                                break;
                            }
                            int index = this.hiddenCm.ColumnIndex - 1 + N * (this.hiddenCm.RowIndex);
                            ChessMan cm = chessManList[index];
                            ExChange(ref this.hiddenCm, cm);
                            break;
                        }
                    //右
                    case 3:
                        {
                            if (this.hiddenCm.ColumnIndex == (N - 1))
                            {
                                break;
                            }
                            int index = this.hiddenCm.ColumnIndex + 1 + N * (this.hiddenCm.RowIndex);
                            ChessMan cm = chessManList[index];
                            ExChange(ref this.hiddenCm, cm);
                            break;
                        }
                }
            }
        }

        //打乱所有按钮       
        //陈景润方法
        //http://www.doc88.com/p-7092015263762.html
        private void MoveCm2()
        {
            Random rnd = new Random();
            List<int> list = new List<int>();
            for (int i = 0; i < N * N; i++)
            {
                list.Add(i);
            }
            List<int> list2 = new List<int>();
            while (list.Count > 0)
            {
                int i = list[rnd.Next(list.Count)];
                list.Remove(i);
                list2.Add(i);
            }

            //计算倒置数
            int count = 0;
            for (int i = 0; i < list2.Count; i++)
            {
                if (list2[i] != list2.Count - 1)
                {
                    for (int j = i + 1; j < list2.Count; j++)
                    {
                        if (list2[i] > list2[j])
                        {
                            count++;
                        }
                    }
                }
            }
            //空白所在行号
            int rowIndex = 0;
            for (int i = 0; i < list2.Count; i++)
            {
                if (list2[i] == N * N - 1)
                {
                    rowIndex = i / N;
                    break;
                }
            }
            bool list2IsOdd = (count % 2 == 0) ? false : true;
            bool rowIsOdd = (rowIndex % 2 == 0) ? true : false;         //0行为奇数，1行为偶数
            if (N % 2 == 0) //N为偶数：序列为偶置序列，空格必须在偶数行。序列为奇置序列，空格必须在奇数行。
            {
                if (!list2IsOdd && rowIsOdd) //偶置序列   空格行号为奇数
                {
                    int temp = list2[list2.Count - 1];       //交换后两个元素，改变奇偶性
                    list2[list2.Count - 1] = list2[list2.Count - 2];
                    list2[list2.Count - 2] = temp;
                }
                else if (list2IsOdd && !rowIsOdd)//奇置序列   空格行号为偶数
                {
                    int temp = list2[0];    //交换前两个元素，改变奇偶性
                    list2[0] = list2[1];
                    list2[1] = temp;
                }
            }
            else //N为奇数，序列必须为偶置序列
            {
                if (list2IsOdd)
                {
                    if (rowIsOdd)  
                    {
                        int temp = list2[N];       //交换后两个元素，改变奇偶性
                        list2[N] = list2[N+1];
                        list2[N+1] = temp;
                    }
                    else
                    {
                        int temp = list2[0];    //交换前两个元素，改变奇偶性
                        list2[0] = list2[1];
                        list2[1] = temp;
                    }
                }
            }


            for (int i = 0; i < chessManList.Count; i++)
            {
                chessManList[i].Text = (list2[i] + 1).ToString();
                if (list2[i] == chessManList.Count - 1)
                {
                    chessManList[i].Visible = false;
                    hiddenCm = chessManList[i];
                }
                else
                {
                    chessManList[i].Visible = true;
                }
            }
        }
        //交换按钮
        private void ExChange(ref ChessMan hiddenCm, ChessMan cm)
        {
            string str = hiddenCm.Text;
            hiddenCm.Text = cm.Text;
            cm.Text = str;

            hiddenCm.Visible = true;
            cm.Visible = false;
            hiddenCm = cm;
            this.hiddenCm = hiddenCm;
        }

        //游戏结束
        private bool GameOver()
        {
            for (int i = 0; i < chessManList.Count; i++)
            {
                if (chessManList[i].Text != (i + 1).ToString())
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
