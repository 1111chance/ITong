using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleAPI.Models
{
    public class AcceptMessage
    {
        public long MsgId { get; set; }
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public int CreateTime { get; set; }
        public string MsgType { get; set; }
    }

    public class AcceptText : AcceptMessage
    {
        public string Content { get; set; }
    }

    public class AcceptImage : AcceptMessage
    {
        public string PicUrl { get; set; }
        public string MediaId { get; set; }
    }

    public class AcceptVoice : AcceptMessage
    {
        public string MediaId { get; set; }
        public string Format { get; set; }
        public string Recognition { get; set; }
    }

    public class AcceptVideo : AcceptMessage
    {
        public string MediaId { get; set; }
        public string ThumbMediaId { get; set; }
    }
    public class AcceptLocation : AcceptMessage
    {
        public string Location_X { get; set; }
        public string Location_Y { get; set; }
        public string Scale { get; set; }
        public string Label { get; set; }
    }
    public class AcceptLink : AcceptMessage
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}