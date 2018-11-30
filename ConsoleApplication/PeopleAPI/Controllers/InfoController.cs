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
using PeopleAPI.Databases;
using PeopleAPI.Models;

namespace PeopleAPI.Controllers
{
    public class InfoController : ApiController
    {

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
                Database.GetInstance().InsertAcceptXmlStr(contentXML);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(contentXML);
                string toUserName = xmlDoc.SelectSingleNode("xml/ToUserName").InnerText;
                string fromUserName = xmlDoc.SelectSingleNode("xml/FromUserName").InnerText;
                int createTime = Convert.ToInt32(xmlDoc.SelectSingleNode("xml/CreateTime").InnerText);
                string msgType = xmlDoc.SelectSingleNode("xml/MsgType").InnerText;
                if (xmlDoc.SelectSingleNode("xml/Event") == null)   //消息  or   事件
                {
                    long msgId = Convert.ToInt64(xmlDoc.SelectSingleNode("xml/MsgId").InnerText);
                    switch (msgType)
                    {
                        case "text":
                            {
                                string content = xmlDoc.SelectSingleNode("xml/Content").InnerText;
                                AcceptText at = new AcceptText()
                                {
                                    MsgId = msgId,
                                    FromUserName = fromUserName,
                                    ToUserName = toUserName,
                                    CreateTime = createTime,
                                    Content = content,
                                    MsgType = msgType
                                };
                                Database.GetInstance().InsertAcceptText(at);
                                break;
                            }
                        case "image":
                            {
                                string picUrl = xmlDoc.SelectSingleNode("xml/PicUrl").InnerText;
                                string mediaId = xmlDoc.SelectSingleNode("xml/MediaId").InnerText;
                                AcceptImage ai = new AcceptImage()
                                {
                                    MsgId = msgId,
                                    FromUserName = fromUserName,
                                    ToUserName = toUserName,
                                    CreateTime = createTime,
                                    MsgType = msgType,
                                    PicUrl = picUrl,
                                    MediaId = mediaId
                                };
                                Database.GetInstance().InsertAcceptImage(ai);
                                break;
                            }
                        case "voice":
                            {
                                string format = xmlDoc.SelectSingleNode("xml/Format").InnerText;
                                string recognition = "";
                                XmlNode node = xmlDoc.SelectSingleNode("xml/Recognition");
                                if (node != null)
                                {
                                    recognition = node.InnerText;
                                }
                                string mediaId = xmlDoc.SelectSingleNode("xml/MediaId").InnerText;
                                AcceptVoice voice = new AcceptVoice()
                                {
                                    MsgId = msgId,
                                    FromUserName = fromUserName,
                                    ToUserName = toUserName,
                                    CreateTime = createTime,
                                    MsgType = msgType,
                                    Format = format,
                                    Recognition = recognition,
                                    MediaId = mediaId
                                };
                                Database.GetInstance().InsertAcceptVoice(voice);
                                break;
                            }
                        case "shortvideo":
                            {
                                string thumbMediaId = xmlDoc.SelectSingleNode("xml/ThumbMediaId").InnerText;
                                string mediaId = xmlDoc.SelectSingleNode("xml/MediaId").InnerText;
                                AcceptVideo video = new AcceptVideo()
                                {
                                    MsgId = msgId,
                                    FromUserName = fromUserName,
                                    ToUserName = toUserName,
                                    CreateTime = createTime,
                                    MsgType = msgType,
                                    ThumbMediaId = thumbMediaId,
                                    MediaId = mediaId
                                };
                                Database.GetInstance().InsertAcceptVideo(video);
                                break;
                            }
                        case "video":
                            {
                                string thumbMediaId = xmlDoc.SelectSingleNode("xml/ThumbMediaId").InnerText;
                                string mediaId = xmlDoc.SelectSingleNode("xml/MediaId").InnerText;
                                AcceptVideo video = new AcceptVideo()
                                {
                                    MsgId = msgId,
                                    FromUserName = fromUserName,
                                    ToUserName = toUserName,
                                    CreateTime = createTime,
                                    MsgType = msgType,
                                    ThumbMediaId = thumbMediaId,
                                    MediaId = mediaId
                                };
                                Database.GetInstance().InsertAcceptVideo(video);
                                break;
                            }
                        case "location":
                            {
                                break;
                            }
                        case "link":
                            {
                                break;
                            }
                        default:
                            break;
                    }
                }
                else
                {

                }




                DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                long timeticks = (DateTime.Now.Ticks - dt1970.Ticks) / 10000000;
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
                Database.GetInstance().InsertErrLog(err.Message);
            }
            return result;
        }
    }
}
