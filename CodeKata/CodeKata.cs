using CodeKata.Models;
using System;
using System.Collections.Generic;

namespace CodeKata
{
    public class CodeKata
    {
        public static List<Message> msgList = new List<Message>();
        public static List<Message> wallList = new List<Message>();

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static Message PublishMessage(string user, string message, DateTime time)
        {
            Message publishedMsg = new Message();
            if (user != "" && message != "")
            {
                publishedMsg.author = user;
                publishedMsg.message = message;
                publishedMsg.time = time;
            }
            msgList.Add(publishedMsg);
            return publishedMsg;
        }

        public static string ViewTimeline(string currUser, string userToView)
        {
            List<Message> timeline = msgList;
            List<Message> view = new List<Message>(timeline);
            var viewStr = "";

            view.Reverse();
            if (currUser == userToView)
            {              
                foreach(var t in view)
                {
                    viewStr += $"{t.author} - {t.message}";
                    
                }
                return viewStr;
            }
            else if (currUser != userToView)
            {              
                foreach(var t in view)
                {
                    if(t.author == userToView)
                    {
                        viewStr += $"{t.message}";
                    }                  
                }
                return viewStr;
            }
            return null;
        }

        public static string Follow(string currentUser, string userToFollow)
        {
            List<Message> followingWall = new List<Message>(msgList);
            //add messages of userToFollow to wall
            foreach(var m in msgList)
            {
                if(m.author == userToFollow)
                {
                    followingWall.Add(m);
                }
            }
            return followingWall.ToString();
        }

        public static string ViewWall(string user)
        {
            //add messages of userToFollow to wall
            List<Message> wall = msgList;
            List<Message> view = new List<Message>(wall);
            var wallStr = "";

            view.Reverse();

            foreach (var m in view)
            {
                wallStr += $"{m.author} - {m.message}";
            }
            return wallStr;
        }
    }
}
