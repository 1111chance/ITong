using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleShapley.Model
{
    public class People
    {
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
        public double Satisfaction
        {
            get
            {
                if (!this.Marryed)
                {
                    return 0;
                }
                double mul = Math.Abs(this.MyEstimatePoint - this.PartnerEstimatePoint) / this.MyEstimatePoint;
                if (this.MyEstimatePoint > this.PartnerEstimatePoint)
                {
                    return 60.0 * (1 - mul);
                }
                else
                {
                    return 60.0 * (1 + mul);
                }
            }
        }
        public People(int id)
        {
            this.PartnerID = -1;
            this.ID = id;
            this.Point = Marry.Rnd.Next(0, 1000);
            this.MyEstimatePoint = People.GetEstimatePoint(this.Point);
        }

        /// <summary>
        /// 估分系统
        /// </summary>
        /// <param name="point">实际得分</param>
        /// <returns>估分</returns>
        public static double GetEstimatePoint(double point)
        {
            double mul = 0.8 + Marry.Rnd.NextDouble() * 0.4;    //控制估分在80% - 120% 之间
            return point * mul;
        }
    }
}
