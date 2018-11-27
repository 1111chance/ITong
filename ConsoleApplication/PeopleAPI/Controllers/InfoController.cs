using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PeopleAPI.Controllers
{
    public class InfoController : ApiController
    {
        /// <summary>
        /// 获得信息
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            return "api 信息";
        }
    }
}
