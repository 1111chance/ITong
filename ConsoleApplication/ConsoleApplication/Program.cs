using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Script.Serialization;
using PeopleAPI.Models;
using System.IO;
using System.Net.Security;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ConsoleApplication.Models;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("项目启动");
            string token = "16_VepQS8OCjqwf2tGlJ1PoKe_62m0YcvPyBNni_5lnK6pdfY8agSuuJ0N8NwLeIf0NmAmLjhrJQFaIehCiKqDuq8llgx6_oijcPFgIHD3HyMgGkgX7Dd0c5OPhEtlrEKQaS_RRb7V2ccFya7zoMXIhAAAALW";
                //GetTokenID();
            GetRemindTemplateList(token);
        }

        #region 无用接口
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
            client.BaseAddress = new Uri("http://localhost:9218");
            HttpResponseMessage response = await client.GetAsync("/api/Info");
            string peopleInfo = await response.Content.ReadAsStringAsync();
            var serializer = new JavaScriptSerializer();
            string info = serializer.Deserialize<string>(peopleInfo);
            Console.WriteLine(info);
            Console.ReadLine();
        }

        private static async Task GetInfo2()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:9218/api/Info");
            request.Method = "GET";//设置请求的方法。这里表示的是请求的方式是GET
            request.Accept = "*/*";//设置Accept标头的值
            string responseStr = "";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())//获取响应
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    responseStr = reader.ReadToEnd();
                }
            }
            Console.WriteLine(responseStr);
            Console.ReadLine();
        }

        public static void HttpPost()
        {
            //当请求为https时，验证服务器证书
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((a, b, c, d) => { return true; });
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:9218/api/Info");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.Timeout = 15000;
            request.AllowAutoRedirect = false;
            string responseStr = "";
            using (StreamWriter requestStream = new StreamWriter(request.GetRequestStream()))
            {
                requestStream.Write("pos");//将请求的数据写入到请求流中
            }
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    responseStr = reader.ReadToEnd();//获取响应
                }
            }
            Console.WriteLine(responseStr);
            Console.ReadLine();
        }

        #endregion
     
        private static string GetTokenID()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wx9a5a1a98123f0f18&secret=54621d1a91dd6b5c1b1a3cb41210ba48");
            request.Method = "GET";//设置请求的方法。这里表示的是请求的方式是GET
            request.Accept = "*/*";//设置Accept标头的值
            string responseStr = "";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())//获取响应
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    responseStr = reader.ReadToEnd();
                }
            }
            JObject jo = (JObject)JsonConvert.DeserializeObject(responseStr);
            string token = jo["access_token"].ToString();
            return token;
        }

        //设置行业，每月一次
        private static void SetIndustry(string token)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/template/api_set_industry?access_token=" + token;
            //当请求为https时，验证服务器证书
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((a, b, c, d) => { return true; });
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.Timeout = 15000;
            request.AllowAutoRedirect = false;
            string responseStr = "";
            using (StreamWriter requestStream = new StreamWriter(request.GetRequestStream()))
            {
                requestStream.Write("{\"industry_id1\":\"1\",\"industry_id2\":\"22\"}");//将请求的数据写入到请求流中
            }
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    responseStr = reader.ReadToEnd();//获取响应
                }
            }
            Console.WriteLine(responseStr);
            Console.ReadLine();
        }

        private static void GetIndustry(string token)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/template/get_industry?access_token=" + token;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";//设置请求的方法。这里表示的是请求的方式是GET
            request.Accept = "*/*";//设置Accept标头的值
            string responseStr = "";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())//获取响应
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    responseStr = reader.ReadToEnd();
                }
            }
            Console.WriteLine(responseStr);
            Console.ReadLine();
        }

        private static void GetRemindTemplateList(string token)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/template/get_all_private_template?access_token=" + token;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";//设置请求的方法。这里表示的是请求的方式是GET
            request.Accept = "*/*";//设置Accept标头的值
            string responseStr = "";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())//获取响应
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    responseStr = reader.ReadToEnd();
                }
            }
            Console.WriteLine(responseStr);
            //JObject jo = (JObject)JsonConvert.DeserializeObject(responseStr);

            JObject obj = JObject.Parse(responseStr);
            JArray ja = (JArray)obj["template_list"];
            List<RemindTemplate> list = new List<RemindTemplate>();
            foreach (var item in ja)
            {
                RemindTemplate rt = new RemindTemplate();
                rt.ID = item["template_id"].ToString();
                rt.Title = item["title"].ToString();
                rt.Primary_industry = item["primary_industry"].ToString();
                rt.Deputy_industry = item["deputy_industry"].ToString();
                rt.Content = item["content"].ToString();
                rt.Example = item["example"].ToString();
                list.Add(rt);
            }
            foreach (RemindTemplate rt in list)
            {
                Console.WriteLine(string.Format("标题：{0}， 内容：{1}\r\n", rt.Title, rt.Content));
            }
          
            Console.ReadLine();
        }
    }
}
