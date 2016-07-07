using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace FacebookBotApi
{
    public static class FacebookUtilities
    {
        private static IList<RestResponseCookie> GlobalCoockei;

        public static async Task<string> SendMessageFast(string userId, string text)
        {
            Func<string> func = () => SendMessage(userId, text);
            Task<string>task = new Task<string>(func);
            task.Start();
            return await task;
        }

        public static async Task<string> SendMessageResultAsync(string userId, string text)
        {
            Func<string> func = () =>  SendMessage(userId, text);
            return Task<string>.Factory.StartNew(func).Result;
        }
        private static string SendMessage(string userId,string text)
        {
            var client = new RestClient("https://m.facebook.com/messages/send/?icm=1&refid=12");
            var request = new RestRequest(Method.POST);
            request.AddHeader("accept-encoding", "gzip");
            request.AddHeader("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            request.AddHeader("origin", "https://m.facebook.com");
            //Coockie
            request.AddCookie("c_user", "100011563661919");
            request.AddCookie("xs", "134%3A_yF72A-MRcJnMA%3A2%3A1467831009%3A17597");

            request.AddParameter("body", $"{text}");
            request.AddParameter("fb_dtsg", "AQGTNJkUOsNe:AQF5skj4JY5V");
            request.AddParameter($"ids[{userId}]", $"{userId}");
            
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public static string Login(string username, string password)
        {
            var client = new RestClient("https://m.facebook.com/login.php");
            var request = new RestRequest(Method.POST);
//            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("accept-language", "en-US,en;q=0.8,uk;q=0.6,ru;q=0.4");
            request.AddHeader("accept-encoding", "gzip, deflate, br");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("origin", "https://m.facebook.com");

            request.AddParameter("fb_noscript", "true");
            request.AddParameter("email",username);
            request.AddParameter("pass",password);
            IRestResponse response = client.Execute(request);
            foreach (RestResponseCookie cookie in response.Cookies)
            {
                Console.WriteLine($"{cookie.Name}={cookie.Value}"); 
            }
            return response.Content;
        }
    }
}
