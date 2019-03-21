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
                double point = People.GetEstimatePoint(female.Point);//对对方评分
                if (point > this.MyEstimatePoint)
                {
                    if ((point - this.MyEstimatePoint) / this.MyEstimatePoint < 0.2)//向上20%
                    {
                        this.RequestList.Add(new RequestObj(female.ID, point));
                    }
                }
                else
                {
                    if ((this.MyEstimatePoint - point) / this.MyEstimatePoint < 0.4)//向下40%
                    {
                        this.RequestList.Add(new RequestObj(female.ID, point));
                    }
                }
            }
            this.RequestList = this.RequestList.OrderByDescending(a => a.EstimatePoint).ToList<RequestObj>();//降序
        }

        public void Request(Dictionary<int, Female> femaleDic)
        {
            if (this.RequestList.Count == 0)
            {
                return;
            }
            Female female = femaleDic[this.RequestList[0].ID];
            if (female.BeRequest(this))
            {
                this.PartnerID = female.ID;
                this.PartnerEstimatePoint = this.RequestList[0].EstimatePoint;
            }
            this.RequestList.RemoveAt(0);
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



    //public class Male
    //{
    //    public int ID { get; set; }         //人员编号
    //    public int PartnerID { get; set; }    //伴侣编号

    //    public bool Marryed { get; set; }       //人员状态
    //    public int StationInList { get; set; }      //当前状态，对应喜好列表的索引号
    //    public List<int> FemaleIDList { get; set; }      //喜好列表

    //    public decimal Satisfaction { get; set; }   //满意度
    //    public Male(int id)
    //    {
    //        this.ID = id;
    //        this.Marryed = false;
    //        this.PartnerID = -1;
    //    }
    //    //初始化名单
    //    public void InitMyList()
    //    {
    //        List<int> list = Marry.GetInstance().FemaleDic.Keys.ToList();
    //        FemaleIDList = Marry.GetRandomList<int>(list);
    //    }

    //    //请求
    //    public void Request()
    //    {
    //        int index = this.FemaleIDList[StationInList];
    //        Female female =Marry.GetInstance().FemaleDic.ElementAt(index).Value;
    //        if (female.Accept(this.ID))
    //        {
    //            this.PartnerID = female.ID;
    //            this.Marryed = true;
    //        }
    //        else
    //        {
    //            this.StationInList++;
    //        }
    //    }

    //    //离婚
    //    public void Divorce()
    //    {
    //        this.Marryed = false;
    //        this.PartnerID = -1;
    //        this.StationInList++;
    //    }
    //}
}
