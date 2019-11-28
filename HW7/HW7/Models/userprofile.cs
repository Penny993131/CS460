using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW7.Models
{
    public class userprofile // I got some ideas from HW6
    {
        public string Name { get; private set; }
        public string Login { get; private set; }
        public string Email { get; private set; }
        public string Bio { get; private set; }
        public string Location { get; private set; }
        public string Company { get; private set; }

        public string Profileurl { get; private set; }
        public userprofile(string Jsonstring)
        {
            JObject userprofile = JObject.Parse(Jsonstring);
            Name = userprofile["name"].ToString();
            Login = userprofile["login"].ToString();
            Email = userprofile["email"].ToString();
            Bio = userprofile["bio"].ToString();
            Location = userprofile["location"].ToString();
            Company = userprofile["company"].ToString();
            Profileurl = userprofile["avatar_url"].ToString();


        }










    }

   








}