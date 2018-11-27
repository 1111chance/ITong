using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell
{
    //贝壳(个体)
    public class Shell
    {
        private static Random rnd = new Random();
        public static List<Shell> ShellList = new List<Shell>();  //种群
        public static Bitmap OriginalBitmap; //原始图片
        #region 字段 属性 构造函数
        private List<Gene> geneList = new List<Gene>();     //贝壳的基因数量
        private decimal fitness;             //贝壳的适应度  越大越好
        private Bitmap bitmap;               //贝壳的图案
        public Bitmap Map
        {
            get { return this.bitmap; }
        }
        public decimal Fitness
        {
            get { return this.fitness; }
        }
        public Shell()
        {

        }

        //复制个体
        public Shell(Shell shell)
        {
            foreach (Gene gene in shell.geneList)
            {
                this.geneList.Add(new Gene(gene));
            }
            this.bitmap = shell.bitmap;
            this.fitness = shell.fitness;
        }

        //根据基因生成个体
        public Shell(List<Gene> geneList)
        {
            this.geneList = geneList;
            this.InitBitmap();
            this.InitFitness();
        }
        //获得随机贝壳
        public static Shell GetRandomShell()
        {
            Shell shell = new Shell();
            for (int i = 0; i < 100; i++)   //每个个体有100个基因
            {
                shell.geneList.Add(Gene.GetRandomGene());
            }
            shell.InitBitmap();
            shell.InitFitness();
            return shell;
        }
        #endregion
        //根据基因初始化贝壳的图案
        public void InitBitmap()
        {
            bitmap = new Bitmap(OriginalBitmap.Width, OriginalBitmap.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);//透明
                foreach (Gene gene in this.geneList)
                {
                    g.FillPolygon(new SolidBrush(gene.ItemColor), gene.Points);
                }
            }
        }

        //根据图案初始化适应度
        public void InitFitness()
        {
            this.fitness = 0;
            for (int i = 0; i < OriginalBitmap.Width; i++)
            {
                for (int j = 0; j < OriginalBitmap.Height; j++)
                {
                    int originalColor = OriginalBitmap.GetPixel(i, j).ToArgb();
                    int shellColor = this.bitmap.GetPixel(i, j).ToArgb();
                    fitness += Math.Abs((originalColor - shellColor) / 1000);
                }
            }
            fitness = fitness / OriginalBitmap.Width / OriginalBitmap.Height;
            fitness = 100 / fitness;
        }

        //繁殖
        public static void Reproduction()
        {
            if (Shell.ShellList.Count == 0)  //第一代直接生成
            {
                for (int i = 0; i < 50; i++)        //种群中的个体数量
                {
                    ShellList.Add(Shell.GetRandomShell());
                }
                return;
            }
            //第二代开始都由上一代繁殖
            //淘汰一个最差的个体
            Shell worst = ShellList[0];
            for (int i = 1; i < ShellList.Count; i++)
            {
                if (ShellList[i].fitness < worst.fitness)
                {
                    worst = ShellList[i];
                }
            }
            ShellList.Remove(worst);
            //随机复制一个个体
            int index = rnd.Next(ShellList.Count);
            ShellList.Add(new Shell(ShellList[index]));

            //配对繁殖
            List<Shell> newShellList = new List<Shell>();
            index = 0;
            while (index < ShellList.Count)
            {
                Shell shell1 = ShellList[index];
                Shell shell2 = ShellList[index + 1];
                int geneNumber = shell1.geneList.Count;
                List<Gene> geneList1 = shell1.geneList;      //将两个个体的基因混在一个
                geneList1.AddRange(shell2.geneList);
                List<Gene> geneList2 = new List<Gene>();
                while (geneList1.Count > geneNumber)
                {
                    int index1 = rnd.Next(geneList1.Count);
                    Gene gene = geneList1[index];
                    geneList2.Add(gene);
                    geneList1.Remove(gene);
                }
                newShellList.Add(new Shell(geneList1));
                newShellList.Add(new Shell(geneList2));
                index = index + 2;
            }
            //选几条个体进行变异
            for (int i = 0; i < 5; i++)
            {
                newShellList[rnd.Next(newShellList.Count)].Mutate();
            }
            ShellList = newShellList;
        }

        //选一个基因进行变异
        private void Mutate()
        {
            Gene gene = this.geneList[rnd.Next(this.geneList.Count)];
            this.geneList.Remove(gene);
            this.geneList.Add(Gene.GetRandomGene());
            this.InitBitmap();
            this.InitFitness();
        }
        
        //选出种群中最优的个体
        public static Shell GetBestShell()
        {
            Shell best = ShellList[0];
            for (int i = 1; i < ShellList.Count; i++)
            {
                if (ShellList[i].fitness > best.fitness)
                {
                    best = ShellList[i];
                }
            }
            return best;
        }
    }
}
