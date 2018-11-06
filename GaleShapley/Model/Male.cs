using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleShapley.Model
{
    public class Male
    {
        public static Random rd = new Random();     //随机数   
        public static int Count = 0;                //第几轮

        public int ID { get; set; }         //人员编号
        public int PartnerID { get; set; }    //伴侣编号

        public bool Marryed { get; set; }       //人员状态
        public int StationInList { get; set; }      //当前状态，对应喜好列表的索引号
        public List<int> FemaleIDList { get; set; }      //喜好列表

        public decimal Satisfaction { get; set; }   //满意度
        public Male(int id)
        {
            this.ID = id;
            this.Marryed = false;
            this.PartnerID = -1;
        }
        //初始化名单
        public void InitMyList()
        {
            List<int> list = Marry.GetInstance().FemaleDic.Keys.ToList();
            FemaleIDList = Marry.GetRandomList<int>(list);
            //Console.Write("MaleID:  " + this.ID + "       MyList:  ");
            //foreach (int item in FemaleIDList)
            //{
            //    Console.Write(item + "  ");
            //}
            //Console.WriteLine();
        }

        //请求
        public void Request()
        {
            int index = this.FemaleIDList[StationInList];
            Female female =Marry.GetInstance().FemaleDic.ElementAt(index).Value;
            if (female.Accept(this.ID))
            {
                this.PartnerID = female.ID;
                this.Marryed = true;
            }
            else
            {
                this.StationInList++;
            }
        }

        //离婚
        public void Divorce()
        {
            this.Marryed = false;
            this.PartnerID = -1;
            this.StationInList++;
        }
    }
}
