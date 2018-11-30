using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace FormApp
{
    public partial class Form1 : Form
    {
        private string frmToken;
        public Form1()
        {
            InitializeComponent();
            frmToken = "16_1L9-bhPm_n1TbSkv7T2WSOT629ADH_kRhKJg2kcJPSUyVet2WctOhru3ADwZDEHF-TQ-97KsqqoEzr6i2QTrggFYj-I1D8uSsU1IewoktTykngEwDj3Y1gueMu4Y-zL0sWs1RKfuGC4_YiMbFPDdAHAUES";
        }

        private static string HttpGet(string url)
        {
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
            return responseStr;
        }

        private static string HttpPost(string url, string postStr)
        {
            //当请求为https时，验证服务器证书
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((a, b, c, d) => { return true; });
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            //request.Accept = "*/*";
            request.Timeout = 15000;
            request.AllowAutoRedirect = false;
            string responseStr = "";
            using (StreamWriter requestStream = new StreamWriter(request.GetRequestStream()))
            {
                requestStream.Write(postStr);//将请求的数据写入到请求流中
            }
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    responseStr = reader.ReadToEnd();//获取响应
                }
            }
            return responseStr;
        }

        //获取token
        private void btnToken_Click(object sender, EventArgs e)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wx9a5a1a98123f0f18&secret=54621d1a91dd6b5c1b1a3cb41210ba48";
            string responseStr = HttpGet(url);
            JObject jo = (JObject)JsonConvert.DeserializeObject(responseStr);
            string token = jo["access_token"].ToString();
            frmToken = token;
            Console.WriteLine("获取token：" + token);
        }

        //获取提醒模板列表
        private void btnRemindList_Click(object sender, EventArgs e)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/template/get_all_private_template?access_token=" + frmToken;
            string responseStr = HttpGet(url);
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
                Console.WriteLine(string.Format("标题：{0}， 内容：{1}", rt.Title, rt.Content));
            }
        }

        //获取用户列表
        private void btnUserList_Click(object sender, EventArgs e)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/template/get_all_private_template?access_token=" + frmToken;
            string responseStr = HttpGet(url);
            Console.WriteLine(responseStr);
        }

        //获取二维码
        private void btnGetImg_Click(object sender, EventArgs e)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token=" + frmToken;
            string postStr = "{\"expire_seconds\": 604800, \"action_name\": \"QR_SCENE\", \"action_info\": {\"scene\": {\"scene_id\": 123}}}";
            string responseStr = HttpPost(url, postStr);
            JObject jo = (JObject)JsonConvert.DeserializeObject(responseStr);
            string ticket = jo["ticket"].ToString();
            string url2 = string.Format("https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={0}", HttpUtility.UrlEncode(ticket));
            Console.WriteLine(url2);

            panel2.Controls.Clear();
            PictureBox pb1 = new PictureBox();
            pb1.Dock = DockStyle.Fill;
            panel2.Controls.Add(pb1);
            pb1.Load(url2);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string connStr = "server=  127.0.0.1  ;  port=  3309  ;  user id=  root  ;  password=  evEt2ylnL!1201  ;  database=  evet2  ;  pooling=true";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select * from test;";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString("CreateTime"));
                    }
                }
            }

            //Console.WriteLine((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000);
        }
    }
}
