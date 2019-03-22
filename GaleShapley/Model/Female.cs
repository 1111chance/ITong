using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleShapley.Model
{
    public class Female : People
    {
        public Female(int id)
            : base(id)
        {

        }

        public bool BeRequest(Male male, Dictionary<int, Male> maleDic)
        {
            double estimatePoint = People.GetEstimatePoint(male.Point);//先评分
            if (this.Marryed)//和配偶比较
            {
                if (this.PartnerEstimatePoint < estimatePoint)
                {
                    double difference = estimatePoint / this.PartnerEstimatePoint;
                    if (difference > 1.5)
                    {
                        maleDic[this.PartnerID].Divorce();
                        this.PartnerID = male.ID;
                        this.PartnerEstimatePoint = estimatePoint;
                        return true;
                    }
                }
                return false;
            }
            else//未婚
            {
                if (estimatePoint > (this.MyEstimatePoint * 0.8))
                {
                    this.PartnerID = male.ID;
                    this.PartnerEstimatePoint = estimatePoint;
                    return true;
                }
                return false;
            }
        }
    }
}
