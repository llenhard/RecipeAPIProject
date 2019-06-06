using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace RecipeAPIProject.Models
{
    public class RecipeDAL
    {
        public static string GetData(string url)
        {
            HttpWebRequest request = WebRequest.CreateHttp(url);
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if(response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());
                return data.ReadToEnd();
            }

            throw new Exception("API machine broke");
        }

        public static JObject GetRecipes(string args)
        {
            return JObject.Parse(GetData($"http://www.recipepuppy.com/api/{args}"));
        }
    }
}