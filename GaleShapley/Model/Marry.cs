using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleShapley.Model
{
    public class Marry
    {
        public static Random rd = new Random();     //随机数   
        public static int Number;       //人数
        public static int Cost;             //成本
        public Dictionary<int, Male> MaleDic;      //男性列表
        public Dictionary<int, Female> FemaleDic;      //女性列表
        public decimal MaleSF;
        public decimal FemaleSF;
        private static Marry instance = null;
        //需要继续匹配
        private bool NeedMatch
        {
            get
            {
                foreach (Male male in this.MaleDic.Values)
                {
                    if (!male.Marryed)
                    {
                        return true;
                    }
                }
                foreach (Female female in this.FemaleDic.Values)
                {
                    if (!female.Marryed)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public static Marry GetInstance()
        {
            if (Marry.instance == null)
            {
                instance = new Marry(Marry.Number);
            }
            return instance;
        }

        public static void ClearInstance()
        {
            Marry.instance = null;
        }

        //初始化人数
        public Marry(int number)
        {
            Marry.Number = number;
            MaleDic = new Dictionary<int, Male>();
            FemaleDic = new Dictionary<int, Female>();
            for (int i = 0; i < number; i++)
            {
                MaleDic.Add(i, new Male(i));
                FemaleDic.Add(i, new Female(i));
            }
        }

        //开始
        public void Start()
        {
            InitPeopleList();
            while (this.NeedMatch)
            {
                Match();
            }
            CalculateSatisfaction(out this.MaleSF, out this.FemaleSF);
        }

        //初始化个人喜好
        private void InitPeopleList()
        {
            foreach (Male male in MaleDic.Values)
            {
                male.InitMyList();
            }
            foreach (Female female in FemaleDic.Values)
            {
                female.InitMyList();
            }
        }

        //匹配
        private void Match()
        {
            foreach (Male male in MaleDic.Values)
            {
                if (!male.Marryed)
                {
                    male.Request();
                }
            }
        }

        //计算满意度
        private void CalculateSatisfaction(out decimal maleSatisfaction, out decimal femaleSatisfaction)
        {
            maleSatisfaction = 0;
            femaleSatisfaction = 0;
            foreach (Male male in this.MaleDic.Values)
            {
                for (int i = 0; i < male.FemaleIDList.Count; i++)
                {
                    if (male.PartnerID == male.FemaleIDList[i])
                    {
                        male.Satisfaction = 100 - 100 * Convert.ToDecimal(i) / male.FemaleIDList.Count;
                        maleSatisfaction += male.Satisfaction;
                        break;
                    }
                }
            }
            maleSatisfaction = maleSatisfaction / this.MaleDic.Count;
            foreach (Female female in this.FemaleDic.Values)
            {
                for (int i = 0; i < female.MaleIDList.Count; i++)
                {
                    if (female.PartnerID == female.MaleIDList[i])
                    {
                        female.Satisfaction = 100 - 100 * Convert.ToDecimal(i) / female.MaleIDList.Count;
                        femaleSatisfaction += female.Satisfaction;
                        break;
                    }
                }
            }
            femaleSatisfaction = femaleSatisfaction / this.FemaleDic.Count;
        }

        //打乱list
        public static List<T> GetRandomList<T>(List<T> inputList)
        {
            //Copy to a array
            T[] copyArray = new T[inputList.Count];
            inputList.CopyTo(copyArray);

            //Add range
            List<T> copyList = new List<T>();
            copyList.AddRange(copyArray);

            //Set outputList and random
            List<T> outputList = new List<T>();

            while (copyList.Count > 0)
            {
                //Select an index and item
                int rdIndex = rd.Next(0, copyList.Count - 1);
                T remove = copyList[rdIndex];

                //remove it from copyList and add it to output
                copyList.Remove(remove);
                outputList.Add(remove);
            }
            return outputList;
        }
    }
}
