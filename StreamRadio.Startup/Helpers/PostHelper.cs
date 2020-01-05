using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace StreamRadio.Startup.Helpers
{
    public class PostHelper
    {
        public static void Post(string postUrl, string text)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(postUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JObject.FromObject(new { Text = text });
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using var streamReader = new StreamReader(httpResponse.GetResponseStream());
            streamReader.ReadToEnd();
        }
    }
}