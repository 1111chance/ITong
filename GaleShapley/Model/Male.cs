using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleShapley.Model
{
    public class Male : People
    {
        public List<RequestObj> RequestList { get; set; }
        public Male(int id)
            : base(id)
        {

        }
        public void InitRequestList(Dictionary<int, Female> femaleDic)
        {
            this.RequestList = new List<RequestObj>();
            foreach (Female female in femaleDic.Values)
            {
                if (Marry.Rnd.Next(30) != 1)//控制此人可以接触到的女性人数，目前所有男性的范围相同，后期可以由个人的交际能力代替
                {
                    continue;
                }
                double point = People.GetEstimatePoint(female.Point);//对对方评分
                if (point > this.MyEstimatePoint)
                {
                    double mul = (point - this.MyEstimatePoint) / this.MyEstimatePoint;
                    if (mul < 0.1)
                    {
                        this.RequestList.Add(new RequestObj(female.ID, point));
                    }
                }
                else
                {
                    double mul = (this.MyEstimatePoint - point) / this.MyEstimatePoint;
                    if (mul < 0.4)
                    {
                        this.RequestList.Add(new RequestObj(female.ID, point));
                    }
                }
            }
            this.RequestList = this.RequestList.OrderByDescending(a => a.EstimatePoint).ToList<RequestObj>();//降序
        }

        /// <summary>
        /// 求婚
        /// </summary>
        /// <param name="maleDic"></param>
        /// <param name="femaleDic"></param>
        public void Request(Dictionary<int, Male> maleDic, Dictionary<int, Female> femaleDic)
        {
            if (this.Marryed)
            {
                return;
            }
            if (this.RequestList.Count == 0)
            {
                return;
            }
            Female female = femaleDic[this.RequestList[0].ID];
            if (female.BeRequest(this, maleDic))
            {
                this.PartnerID = female.ID;
                this.PartnerEstimatePoint = this.RequestList[0].EstimatePoint;
            }
            this.RequestList.RemoveAt(0);
        }

        /// <summary>
        /// 离婚
        /// </summary>
        public void Divorce()
        {
            this.PartnerID = -1;
            this.PartnerEstimatePoint = 0;
        }
    }

    /// <summary>
    /// 请求对象
    /// </summary>
    public class RequestObj
    {
        /// <summary>
        /// 对象编号
        /// </summary>
        public int ID { get; private set; }
        /// <summary>
        /// 对象在自己心目中的估分
        /// </summary>
        public double EstimatePoint { get; private set; }

        public RequestObj(int id, double estimatePoint)
        {
            this.ID = id;
            this.EstimatePoint = estimatePoint;
        }
    }
}
