using PeopleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PeopleAPI.Controllers
{
    public class PeopleController : ApiController
    {
        static List<People> listPeople;
        static PeopleController()
        {
            listPeople = new List<People>()
            {
                new People(){Name = "张三", Gender = "男", Age = "12"},
                new People(){Name = "李四", Gender = "女", Age = "18"},
                new People(){Name = "王五", Gender = "中", Age = "22"}
            };
        }

        /// <summary>
        /// 根据名字获取人
        /// </summary>
        /// <param name="name">名字</param>
        /// <returns>人</returns>
        public People GetPeopleByName(string name)
        { 
            return listPeople.Where(x  => x.Name == name).SingleOrDefault();
        }

        /// <summary>
        /// 获取所有人员
        /// </summary>
        /// <returns>人员列表</returns>
        public IEnumerable<People> GetPeopleList()
        {
            return listPeople;
        }

        /// <summary>
        /// 新增人员
        /// </summary>
        /// <param name="value">新增的值</param>
        public void AddPeopleInfo([FromBody]People value)
        {
            listPeople.Add(value);
        }
    }
}
