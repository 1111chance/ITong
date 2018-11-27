using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell
{
    //基因   一个三角形（包含坐标颜色信息）
    public class Gene
    {
        private static Random rnd = new Random();
        private const int ColorAlpha = 100;             //三角形颜色 alpha 值
        public static int SizeOfTriangle = 100;     //三角形尺寸
        public Point[] Points { get; set; }     //三角形坐标
        public Color ItemColor { get; set; }    //三角形颜色
        public Gene()
        {
            this.Points = new Point[3];
        }

        //复制基因
        public Gene(Gene gene)
        {
            this.Points = gene.Points;
            this.ItemColor = gene.ItemColor;
        }

        //获得随机基因
        public static Gene GetRandomGene()
        {
            Gene gene = new Gene();
            gene.ItemColor = Color.FromArgb(ColorAlpha, rnd.Next(256), rnd.Next(256), rnd.Next(256));
            gene.Points[0] = gene.Points[1] = gene.Points[2] = new Point(rnd.Next(Shell.OriginalBitmap.Width), rnd.Next(Shell.OriginalBitmap.Height));
            gene.Points[1].X += rnd.Next(-SizeOfTriangle, SizeOfTriangle);
            gene.Points[1].Y += rnd.Next(-SizeOfTriangle, SizeOfTriangle);
            gene.Points[2].X += rnd.Next(-SizeOfTriangle, SizeOfTriangle);
            gene.Points[2].Y += rnd.Next(-SizeOfTriangle, SizeOfTriangle);
            return gene;
        }
    }
}
