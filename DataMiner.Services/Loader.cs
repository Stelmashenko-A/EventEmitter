using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DataMiner.Services
{
    public class Loader : IDisposable
    {
        protected WebClient WebClient { get; set; }

        public Loader()
        {
            WebClient = new WebClient();
        }

        public string Load(string url)
        {

            CookieContainer cookieJar = new CookieContainer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = cookieJar;

            request.Accept = @"text/html, application/xhtml+xml, */*";
           // request.Referer = @"https://www.eventbrite.com/";
            //request.Headers.Add("Accept-Language", "en-GB");
            request.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
            //request.Host = @"www.eventbrite.com";
            //request.UseDefaultCredentials = true;
            //request.Proxy.Credentials = CredentialCache.DefaultCredentials;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }



        }

        public void Dispose()
        {
            WebClient.Dispose();
        }
    }
}
