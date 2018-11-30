using MySql.Data.MySqlClient;
using PeopleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleAPI.Databases
{
    public class Database
    {
        private string connstr = "server=  127.0.0.1  ;  port=  3309  ;  user id=  root  ;  password=  evEt2ylnL!1201  ;  database=  wechat  ;  pooling=true";

        private static Database instance;

        private Database()
        {

        }

        public static Database GetInstance()
        {
            if (instance == null)
            {
                instance = new Database();
            }
            return instance;
        }

        //错误日志
        public void InsertErrLog(string err)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = @"insert into log (Content, LogTime) values (@Content, NOW());";
                    cmd.Parameters.AddWithValue("@Content", err);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

            }
        }

        //插入接收到的原始数据
        public void InsertAcceptXmlStr(string xmlStr)
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"insert into acceptxmlstr (XmlStr) values (@XmlStr);";
                cmd.Parameters.AddWithValue("@XmlStr", xmlStr);
                cmd.ExecuteNonQuery();
            }
        }

        //插入接收到的text消息
        public void InsertAcceptText(AcceptText at)
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                conn.Open();
                MySqlCommand cmdCheck = conn.CreateCommand();
                cmdCheck.CommandText = "select count(*) from accepttext where MsgId = @MsgId";
                cmdCheck.Parameters.AddWithValue("@MsgId", at.MsgId);
                int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                if (count < 1)
                {
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = @"insert into accepttext (MsgId, Content, ToUserName, FromUserName, CreateTime) 
values (@MsgId, @Content, @ToUserName, @FromUserName, @CreateTime);";
                    cmd.Parameters.AddWithValue("@MsgId", at.MsgId);
                    cmd.Parameters.AddWithValue("@Content", at.Content);
                    cmd.Parameters.AddWithValue("@ToUserName", at.ToUserName);
                    cmd.Parameters.AddWithValue("@FromUserName", at.FromUserName);
                    cmd.Parameters.AddWithValue("@CreateTime", at.CreateTime);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //插入接收到的image消息
        public void InsertAcceptImage(AcceptImage ai)
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                conn.Open();
                MySqlCommand cmdCheck = conn.CreateCommand();
                cmdCheck.CommandText = "select count(*) from acceptimage where MsgId = @MsgId";
                cmdCheck.Parameters.AddWithValue("@MsgId", ai.MsgId);
                int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                if (count < 1)
                {
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = @"insert into acceptimage (MsgId, ToUserName, FromUserName, CreateTime, PicUrl, MediaId) 
values (@MsgId, @ToUserName, @FromUserName, @CreateTime, @PicUrl, @MediaId);";
                    cmd.Parameters.AddWithValue("@MsgId", ai.MsgId);
                    cmd.Parameters.AddWithValue("@ToUserName", ai.ToUserName);
                    cmd.Parameters.AddWithValue("@FromUserName", ai.FromUserName);
                    cmd.Parameters.AddWithValue("@CreateTime", ai.CreateTime);
                    cmd.Parameters.AddWithValue("@PicUrl", ai.PicUrl);
                    cmd.Parameters.AddWithValue("@MediaId", ai.MediaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //插入接收到的voice消息
        public void InsertAcceptVoice(AcceptVoice voice)
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                conn.Open();
                MySqlCommand cmdCheck = conn.CreateCommand();
                cmdCheck.CommandText = "select count(*) from acceptvoice where MsgId = @MsgId";
                cmdCheck.Parameters.AddWithValue("@MsgId", voice.MsgId);
                int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                if (count < 1)
                {
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = @"insert into acceptvoice (MsgId, ToUserName, FromUserName, CreateTime, Format, Recognition, MediaId) 
values (@MsgId, @ToUserName, @FromUserName, @CreateTime, @Format, @Recognition, @MediaId);";
                    cmd.Parameters.AddWithValue("@MsgId", voice.MsgId);
                    cmd.Parameters.AddWithValue("@ToUserName", voice.ToUserName);
                    cmd.Parameters.AddWithValue("@FromUserName", voice.FromUserName);
                    cmd.Parameters.AddWithValue("@CreateTime", voice.CreateTime);
                    cmd.Parameters.AddWithValue("@Format", voice.Format);
                    cmd.Parameters.AddWithValue("@Recognition", voice.Recognition);
                    cmd.Parameters.AddWithValue("@MediaId", voice.MediaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //插入接收到的video消息
        public void InsertAcceptVideo(AcceptVideo video)
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                conn.Open();
                MySqlCommand cmdCheck = conn.CreateCommand();
                cmdCheck.CommandText = "select count(*) from acceptvideo where MsgId = @MsgId";
                cmdCheck.Parameters.AddWithValue("@MsgId", video.MsgId);
                int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                if (count < 1)
                {
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = @"insert into acceptvideo (MsgId, ToUserName, FromUserName, CreateTime, ThumbMediaId, MediaId) 
values (@MsgId, @ToUserName, @FromUserName, @CreateTime, @ThumbMediaId, @MediaId);";
                    cmd.Parameters.AddWithValue("@MsgId", video.MsgId);
                    cmd.Parameters.AddWithValue("@ToUserName", video.ToUserName);
                    cmd.Parameters.AddWithValue("@FromUserName", video.FromUserName);
                    cmd.Parameters.AddWithValue("@CreateTime", video.CreateTime);
                    cmd.Parameters.AddWithValue("@ThumbMediaId", video.ThumbMediaId);
                    cmd.Parameters.AddWithValue("@MediaId", video.MediaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //插入接收到的location消息
        public void InsertAcceptLocation(AcceptLocation at)
        {

        }
        //插入接收到的link消息
        public void InsertAcceptLink(AcceptLink at)
        {

        }
    }
}