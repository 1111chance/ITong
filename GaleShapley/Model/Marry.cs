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
        /// 需要继续匹配
        /// </summary>
        public bool NeedMatch
        {
            get
            {
                foreach (Male male in this.MaleDic.Values)
                {
                    if (male.RequestList.Count > 0)
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
                    male.Request(this.FemaleDic);
                }
            }
        }
    }
    //public class Marry
    //{
    //    public static Random rd = new Random();     //随机数   
    //    public static int Number;       //人数
    //    public static int Cost;             //成本
    //    public Dictionary<int, Male> MaleDic;      //男性列表
    //    public Dictionary<int, Female> FemaleDic;      //女性列表
    //    public decimal MaleSF;
    //    public decimal FemaleSF;
    //    private static Marry instance = null;
    //    //需要继续匹配
    //    private bool NeedMatch
    //    {
    //        get
    //        {
    //            foreach (Male male in this.MaleDic.Values)
    //            {
    //                if (!male.Marryed)
    //                {
    //                    return true;
    //                }
    //            }
    //            foreach (Female female in this.FemaleDic.Values)
    //            {
    //                if (!female.Marryed)
    //                {
    //                    return true;
    //                }
    //            }
    //            return false;
    //        }
    //    }

    //    public static Marry GetInstance()
    //    {
    //        if (Marry.instance == null)
    //        {
    //            instance = new Marry(Marry.Number);
    //        }
    //        return instance;
    //    }

    //    public static void ClearInstance()
    //    {
    //        Marry.instance = null;
    //    }

    //    //初始化人数
    //    public Marry(int number)
    //    {
    //        Marry.Number = number;
    //        MaleDic = new Dictionary<int, Male>();
    //        FemaleDic = new Dictionary<int, Female>();
    //        for (int i = 0; i < number; i++)
    //        {
    //            MaleDic.Add(i, new Male(i));
    //            FemaleDic.Add(i, new Female(i));
    //        }
    //    }

    //    //开始
    //    public void Start()
    //    {
    //        InitPeopleList();
    //        while (this.NeedMatch)
    //        {
    //            Match();
    //        }
    //        CalculateSatisfaction(out this.MaleSF, out this.FemaleSF);
    //    }

    //    //初始化个人喜好
    //    private void InitPeopleList()
    //    {
    //        foreach (Male male in MaleDic.Values)
    //        {
    //            male.InitMyList();
    //        }
    //        foreach (Female female in FemaleDic.Values)
    //        {
    //            female.InitMyList();
    //        }
    //    }

    //    //匹配
    //    private void Match()
    //    {
    //        foreach (Male male in MaleDic.Values)
    //        {
    //            if (!male.Marryed)
    //            {
    //                male.Request();
    //            }
    //        }
    //    }

    //    //计算满意度
    //    private void CalculateSatisfaction(out decimal maleSatisfaction, out decimal femaleSatisfaction)
    //    {
    //        maleSatisfaction = 0;
    //        femaleSatisfaction = 0;
    //        foreach (Male male in this.MaleDic.Values)
    //        {
    //            for (int i = 0; i < male.FemaleIDList.Count; i++)
    //            {
    //                if (male.PartnerID == male.FemaleIDList[i])
    //                {
    //                    male.Satisfaction = 100 - 100 * Convert.ToDecimal(i) / male.FemaleIDList.Count;
    //                    maleSatisfaction += male.Satisfaction;
    //                    break;
    //                }
    //            }
    //        }
    //        maleSatisfaction = maleSatisfaction / this.MaleDic.Count;
    //        foreach (Female female in this.FemaleDic.Values)
    //        {
    //            for (int i = 0; i < female.MaleIDList.Count; i++)
    //            {
    //                if (female.PartnerID == female.MaleIDList[i])
    //                {
    //                    female.Satisfaction = 100 - 100 * Convert.ToDecimal(i) / female.MaleIDList.Count;
    //                    femaleSatisfaction += female.Satisfaction;
    //                    break;
    //                }
    //            }
    //        }
    //        femaleSatisfaction = femaleSatisfaction / this.FemaleDic.Count;
    //    }

    //    //打乱list
    //    public static List<T> GetRandomList<T>(List<T> inputList)
    //    {
    //        T[] copyArray = new T[inputList.Count];
    //        inputList.CopyTo(copyArray);
    //        List<T> copyList = new List<T>();
    //        copyList.AddRange(copyArray);

    //        List<T> outputList = new List<T>();
    //        while (copyList.Count > 0)
    //        {
    //            int rdIndex = rd.Next(0, copyList.Count - 1);
    //            T remove = copyList[rdIndex];
    //            copyList.Remove(remove);
    //            outputList.Add(remove);
    //        }
    //        return outputList;
    //    }
    //}
}
