using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Script.Serialization;
using PeopleAPI.Models;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("项目启动");
            //GetPeopleApiData().Wait();
            //GetPeopleApiDataByName("张三").Wait();
            GetInfo().Wait();
        }

        private async static Task GetPeopleApiData()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://180.76.52.108");
            string response = await client.GetStringAsync("/api/People");
            var serializer = new JavaScriptSerializer();
            People[] peoples = serializer.Deserialize<People[]>(response);

            foreach (People item in peoples)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }

        private static async Task GetPeopleApiDataByName(string name)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://180.76.52.108");
            HttpResponseMessage response = await client.GetAsync("/api/People?name=" + name);
            string peopleInfo = await response.Content.ReadAsStringAsync();
            var serializer = new JavaScriptSerializer();
            People p = serializer.Deserialize<People>(peopleInfo);
            Console.WriteLine("姓名：" + p.Name + ", 性别：" + p.Gender + ", 年龄：" + p.Age);
            Console.ReadLine();
        }

        private static async Task GetInfo()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://180.76.52.108");
            HttpResponseMessage response = await client.GetAsync("/api/Info");
            string peopleInfo = await response.Content.ReadAsStringAsync();
            var serializer = new JavaScriptSerializer();
            string info = serializer.Deserialize<string>(peopleInfo);
            Console.WriteLine(info);
            Console.ReadLine();
        }
    }
}
