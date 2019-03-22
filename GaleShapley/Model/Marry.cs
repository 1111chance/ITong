using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//盖尔-沙普利[Gale-Shapley]婚姻稳定匹配算法
//有N人男性，M个女性，每个人有一个实际得分(考虑分布方式)，个人估分，每个人对其他人都有一个估分
//每个人进行喜好排序，获得自己的追求名单（按照自己的自身估分加减一定的分值获得一个区间）。
//循环进行请求，女性按照自己的估分和对男性的估分接受或拒绝。
//直到每个人的追求名单结束
namespace GaleShapley.Model
{
    public class Marry
    {
        /// <summary>
        /// 全局使用的随机数
        /// </summary>
        public static Random Rnd = new Random();
        public Dictionary<int, Male> MaleDic { get; set; }
        public Dictionary<int, Female> FemaleDic { get; set; }
        /// <summary>
        /// 结婚数
        /// </summary>
        public int MarriageCount
        {
            get
            {
                int count = 0;
                foreach (Male male in this.MaleDic.Values)
                {
                    if (male.Marryed)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
        /// <summary>
        /// 单身人数
        /// </summary>
        public int SingleCount
        {
            get
            {
                return this.MaleDic.Count + this.FemaleDic.Count - this.MarriageCount * 2;
            }
        }
        public double MaleSatisfaction
        {
            get
            {
                double satisfaction = 0;
                foreach (Male male in this.MaleDic.Values)
                {
                    satisfaction += male.Satisfaction;
                }
                return satisfaction / this.MaleDic.Count;
            }
        }
        public double FemaleSatisfaction
        {
            get
            {
                double satisfaction = 0;
                foreach (Female female in this.FemaleDic.Values)
                {
                    satisfaction += female.Satisfaction;
                }
                return satisfaction / this.FemaleDic.Count;
            }
        }
        /// <summary>
        /// 需要继续匹配
        /// </summary>
        public bool NeedMatch
        {
            get
            {
                foreach (Male male in this.MaleDic.Values)
                {
                    if (male.RequestList.Count > 0 && !male.Marryed)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public Marry(int maleNum, int femaleNum)
        {
            this.MaleDic = new Dictionary<int, Male>();
            this.FemaleDic = new Dictionary<int, Female>();
            for (int i = 0; i < maleNum; i++)
            {
                MaleDic.Add(i, new Male(i));
            }
            for (int i = 0; i < femaleNum; i++)
            {
                FemaleDic.Add(i, new Female(i));
            }
            foreach (Male male in this.MaleDic.Values)
            {
                male.InitRequestList(this.FemaleDic);
            }
        }
        public void Start()
        {
            while (this.NeedMatch)
            {
                foreach (Male male in this.MaleDic.Values)
                {
                    male.Request(this.MaleDic, this.FemaleDic);
                }
            }
        }
    }
}
