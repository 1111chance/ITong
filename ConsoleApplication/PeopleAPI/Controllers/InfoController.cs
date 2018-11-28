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

namespace PeopleAPI.Controllers
{
    public class InfoController : ApiController
    {
        /// <summary>
        /// 接口认证
        /// </summary>
        /// <param name="echostr"></param>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<HttpResponseMessage> wx(string echostr, string signature, string timestamp, string nonce)
        {
            string token = "zyy";
            if (!CheckSignature(token, signature, timestamp, nonce))
                echostr = "验证不正确";
            HttpResponseMessage responseMessage = new HttpResponseMessage { Content = new StringContent(echostr, Encoding.GetEncoding("UTF-8"), "text/plain") };

            return responseMessage;
        }
        /// <summary>
        /// 接收客服消息
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //public async Task<HttpResponseMessage> wx()
        //{
        //    LogHelper log = new LogHelper();
        //    var content = await Request.Content.ReadAsStringAsync();
        //    log.LogError(content);
        //    HttpResponseMessage responseMessage = new HttpResponseMessage();
        //    return responseMessage;
        //}
        /// <summary>
        /// 验证微信签名
        /// </summary>
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
        //public HttpResponseMessage Get(string signature, string timestamp, string nonce, string echostr)
        //{
        //    //公众平台上开发者设置的token, appID, EncodingAESKey
        //    string sToken = "zyy";
        //    string sAppID = "wx5b3d448e0e1cad7c";
        //    string sEncodingAESKey = "gFLPaPZbUHRI1McPvOT1lDkNhxsyIVhrP8KNxSRBLWF";

        //    Tencent.WXBizMsgCrypt wxcpt = new Tencent.WXBizMsgCrypt(sToken, sEncodingAESKey, sAppID);

        //    /* 1. 对用户回复的数据进行解密。
        //    * 用户回复消息或者点击事件响应时，企业会收到回调消息，假设企业收到的推送消息：
        //    * 	POST /cgi-bin/wxpush? msg_signature=477715d11cdb4164915debcba66cb864d751f3e6&timestamp=1409659813&nonce=1372623149 HTTP/1.1
        //       Host: qy.weixin.qq.com
        //       Content-Length: 613
        //    *
        //    * 	<xml>
        //           <ToUserName><![CDATA[wx5823bf96d3bd56c7]]></ToUserName>
        //           <Encrypt><![CDATA[RypEvHKD8QQKFhvQ6QleEB4J58tiPdvo+rtK1I9qca6aM/wvqnLSV5zEPeusUiX5L5X/0lWfrf0QADHHhGd3QczcdCUpj911L3vg3W/sYYvuJTs3TUUkSUXxaccAS0qhxchrRYt66wiSpGLYL42aM6A8dTT+6k4aSknmPj48kzJs8qLjvd4Xgpue06DOdnLxAUHzM6+kDZ+HMZfJYuR+LtwGc2hgf5gsijff0ekUNXZiqATP7PF5mZxZ3Izoun1s4zG4LUMnvw2r+KqCKIw+3IQH03v+BCA9nMELNqbSf6tiWSrXJB3LAVGUcallcrw8V2t9EL4EhzJWrQUax5wLVMNS0+rUPA3k22Ncx4XXZS9o0MBH27Bo6BpNelZpS+/uh9KsNlY6bHCmJU9p8g7m3fVKn28H3KDYA5Pl/T8Z1ptDAVe0lXdQ2YoyyH2uyPIGHBZZIs2pDBS8R07+qN+E7Q==]]></Encrypt>
        //       </xml>
        //    */
        //    string sMsg = "";  //解析之后的明文
        //    int ret = 0;
        //    ret = wxcpt.DecryptMsg(signature, timestamp, nonce, echostr, ref sMsg);
        //    if (ret != 0)
        //    {
        //        return null;
        //    }
        //    return new HttpResponseMessage()
        //    {
        //        Content = new StringContent(sMsg, Encoding.GetEncoding("UTF-8"), "application/x-www-form-urlencoded")
        //    };
        //}

        //public HttpResponseMessage Get(string signature, string timestamp, string nonce, string echostr)
        //{
        //    string[] ArrTmp = { "zyy", timestamp, nonce };
        //    Array.Sort(ArrTmp);
        //    string tmpStr = string.Join("", ArrTmp);
        //    var result = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1").ToLower();

        //    return new HttpResponseMessage()
        //    {
        //        Content = new StringContent(result, Encoding.GetEncoding("UTF-8"), "application/x-www-form-urlencoded")
        //    };
        //}

    }
}
