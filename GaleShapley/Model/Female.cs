using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleShapley.Model
{
    public class Female
    {

        public static int Count = 0;                //第几轮

        public int ID { get; set; }         //人员编号
        public int PartnerID { get; set; }    //伴侣编号


        public bool Marryed { get; set; }       //人员状态

        public int PartnerIndexInList { get; set; }
        public List<int> MaleIDList { get; set; }      //喜好列表

        public decimal Satisfaction { get; set; }   //满意度
        public Female(int id)
        {
            this.ID = id;
            this.Marryed = false;
            this.PartnerID = -1;
        }

        //初始化名单
        public void InitMyList()
        {
            List<int> list = Marry.GetInstance().MaleDic.Keys.ToList();
            MaleIDList = Marry.GetRandomList<int>(list);
        }

        //接受
        public bool Accept(int maleID)
        {
            if (this.Marryed)//已婚
            {
                for (int i = 0; i < this.MaleIDList.Count; i++)
                {
                    if (this.MaleIDList[i] == maleID)
                    {
                        int maleIndex = i;      //求偶者的位置
                        if ((maleIndex + Marry.Cost) < this.PartnerIndexInList)    //成功
                        {
                            Male oldPartner = Marry.GetInstance().MaleDic[this.PartnerID];
                            oldPartner.Divorce();
                            this.PartnerID = maleID;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return false;
            }
            else//未婚
            {
                this.PartnerID = maleID;
                this.Marryed = true;
                return true;
            }
        }
    }
}
