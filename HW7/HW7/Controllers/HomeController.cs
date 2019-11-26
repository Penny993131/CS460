using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Configuration;
using System.Net;
using System.IO;
using HW7.Models;

namespace HW7.Controllers
{
    public class HomeController : Controller
    {

        private string SendRequest(string uri, string credentials, string username)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers.Add("Authorization", "token " + credentials);
            request.UserAgent = username;       // Required, see: https://developer.github.com/v3/#user-agent-required
            request.Accept = "application/json";

            string jsonString = null;
            // TODO: You should handle exceptions here
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return jsonString;
        }

        public ContentResult Repos()
        {
            string json = SendRequest("https://api.github.com/user/repos", ConfigurationManager.AppSettings.Get("Token"), "penny993131");
            return Content(json, "application/json");
        }

        public ContentResult Commit(string owner, string repo)
        {
            string json = SendRequest("https://api.github.com/repos/" + owner + "/" + repo + "/commits", ConfigurationManager.AppSettings.Get("Token"), "penny993131");
            return Content(json, "application/json");
        }




        public ActionResult Index()
        {
            //Debug.WriteLine($"My key:{ConfigurationManager.AppSettings.Get("Token")}");
            string json = SendRequest("https://api.github.com/users/penny993131", ConfigurationManager.AppSettings.Get("Token"), "penny993131");
            return View(new userprofile(json));
        }
        







        
    }
}