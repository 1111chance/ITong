using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleShapley.Model
{
    public class People
    {
        private static double MaxPoint = 1000;
        private static double MinPoint = 200;
        /// <summary>
        /// 个人编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 配偶编号
        /// </summary>
        public int PartnerID { get; set; }
        public bool Marryed
        {
            get
            {
                return this.PartnerID < 0 ? false : true;
            }
        }
        /// <summary>
        /// 实际得分
        /// </summary>
        public double Point { get; set; }
        /// <summary>
        /// 个人估分
        /// </summary>
        public double MyEstimatePoint { get; set; }
        /// <summary>
        /// 配偶得分
        /// </summary>
        public double PartnerEstimatePoint { get; set; }
        /// <summary>
        /// 满意度
        /// </summary>
        public double Satisfaction
        {
            get
            {
                if (!this.Marryed)
                {
                    return 0;
                }
                //很难找到合适的计算满意度的方法
                double mul = Math.Abs(this.MyEstimatePoint - this.PartnerEstimatePoint) / People.MaxPoint;
                if (this.MyEstimatePoint > this.PartnerEstimatePoint)
                {
                    return 50.0 * (1 - mul);
                }
                else
                {
                    return 50.0 * (1 + mul);
                }
            }
        }
        public People(int id)
        {
            this.PartnerID = -1;
            this.ID = id;
            this.Point = Marry.Rnd.NextDouble() * (People.MaxPoint - People.MinPoint) + People.MinPoint;   //个人得分在0-1000之间，现在是平均分布，可修改为正态分布
            this.MyEstimatePoint = People.GetEstimatePoint(this.Point);
        }

        /// <summary>
        /// 估分系统
        /// </summary>
        /// <param name="point">实际得分</param>
        /// <returns>估分</returns>
        public static double GetEstimatePoint(double point)
        {
            return point;
            double mul = 0.8 + Marry.Rnd.NextDouble() * 0.4;    //控制估分在80% - 120% 之间
            return point * mul;
        }
    }
}
