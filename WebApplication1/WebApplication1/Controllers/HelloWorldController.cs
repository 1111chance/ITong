using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/ 
        public ActionResult Index()
        {
            List<User> userList = new List<User>()
            {
                new User(){  UserID = "US0", Name = "张三", Address = "长江路1号"},
                    new User(){  UserID = "US1", Name = "李四", Address = "勤业路1号"},
                        new User(){  UserID = "US2", Name = "王五", Address = "劳动路1号"}
            };

            ViewBag.UserList = userList;
            return View();
        }

        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }
    } 
}