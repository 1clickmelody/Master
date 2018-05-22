using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1ClickMelodyApplication.Controllers
{
    public class SongsApiController : ApiController
    {
        public string RunQuery(string url, string method = "GET")
        {
            return GetResponse(url, method);
        }

        public string GetResponse(string url, string method = "GET")
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = method;

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            string result = string.Empty;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}

