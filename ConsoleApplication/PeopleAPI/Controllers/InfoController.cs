using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Security;
using MySql.Data.MySqlClient;
using System.Xml;

namespace PeopleAPI.Controllers
{
    public class InfoController : ApiController
    {
        private static string connstr = "server=  127.0.0.1  ;  port=  3309  ;  user id=  root  ;  password=  evEt2ylnL!1201  ;  database=  wechat  ;  pooling=true";
        #region 微信接口认证
        // 接口认证
        [HttpGet]
        public async Task<HttpResponseMessage> wx(string echostr, string signature, string timestamp, string nonce)
        {
            string token = "zyy";
            if (!CheckSignature(token, signature, timestamp, nonce))
                echostr = "验证不正确";
            HttpResponseMessage responseMessage = new HttpResponseMessage { Content = new StringContent(echostr, Encoding.GetEncoding("UTF-8"), "text/plain") };

            return responseMessage;
        }
      
        // 验证微信签名
        private bool CheckSignature(string token, string signature, string timestamp, string nonce)
        {
            string[] ArrTmp = { token, timestamp, nonce };

            Array.Sort(ArrTmp);
            string tmpStr = string.Join("", ArrTmp);
            var data = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(tmpStr));
            var sb = new StringBuilder();
            foreach (var t in data)
            {
                sb.Append(t.ToString("X2"));
            }
            tmpStr = sb.ToString();
            tmpStr = tmpStr.ToLower();

            if (tmpStr == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    
        // 接收客户消息  自动回复
        [HttpPost]
        public async Task<HttpResponseMessage> wx()
        {
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent("", Encoding.GetEncoding("UTF-8"), "text/plain") };
            string contentXML = await Request.Content.ReadAsStringAsync();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(contentXML);
                string toUserName = xmlDoc.SelectSingleNode("xml/ToUserName").InnerText;
                string fromUserName = xmlDoc.SelectSingleNode("xml/FromUserName").InnerText;
                string createTime = xmlDoc.SelectSingleNode("xml/CreateTime").InnerText;
                string msgType = xmlDoc.SelectSingleNode("xml/MsgType").InnerText;
                string content = xmlDoc.SelectSingleNode("xml/Content").InnerText;
                string msgId = xmlDoc.SelectSingleNode("xml/MsgId").InnerText;

                using (MySqlConnection conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = @"insert into content 
(ToUserName, FromUserName, CreateTime, MsgType, Content, MsgId) values 
(@ToUserName, @FromUserName, @CreateTime, @MsgType, @Content, @MsgId);";
                    cmd.Parameters.AddWithValue("@ToUserName", toUserName);
                    cmd.Parameters.AddWithValue("@FromUserName", fromUserName);
                    cmd.Parameters.AddWithValue("@CreateTime", createTime);
                    cmd.Parameters.AddWithValue("@MsgType", msgType);
                    cmd.Parameters.AddWithValue("@Content", content);
                    cmd.Parameters.AddWithValue("@MsgId", msgId);
                    cmd.ExecuteNonQuery();

                    MySqlCommand cmd2 = conn.CreateCommand();
                    cmd2.CommandText = @"insert into xmlcontent (XmlContent) values (@XmlContent);";
                    cmd2.Parameters.AddWithValue("@XmlContent", contentXML);
                    cmd2.ExecuteNonQuery();
                }
                DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                long timeticks = (DateTime.Now.Ticks - dt1970.Ticks) / 10000000;
                //返回纯文本text/plain  ,返回json application/json  ,返回xml text/xml
//                string returnXml = string.Format(@"<xml> <ToUserName>< ![CDATA[{0}] ></ToUserName> 
//<FromUserName>< ![CDATA[{1}] ></FromUserName> 
//<CreateTime>{2}</CreateTime> 
//<MsgType>< ![CDATA[text] ></MsgType> 
//<Content>< ![CDATA[你好] ></Content> 
//</xml>", fromUserName, toUserName, timeticks);
                string returnXml = string.Format(@"<xml> <ToUserName>{0}</ToUserName> 
<FromUserName>{1}</FromUserName> 
<CreateTime>{2}</CreateTime> 
<MsgType>text</MsgType> 
<Content>你好</Content> 
</xml>", fromUserName, toUserName, timeticks);
                result = new HttpResponseMessage { Content = new StringContent(returnXml, Encoding.GetEncoding("UTF-8"), "text/xml") };
                return result;
            }
            catch (Exception err)
            {
                MysqlLog(err.Message);
            }
            return result;
        }
     
        // 填写错误日志
        private void MysqlLog(string str)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = @"insert into log (Content, LogTime) values (@Content, NOW());";
                    cmd.Parameters.AddWithValue("@Content", str);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
