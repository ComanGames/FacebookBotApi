using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using FacebookBotApi;

namespace ApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
//            Console.WriteLine("Start login");
            string respone;//= FacebookBotApi.FacebookUtilities.Login("coman.games@outlook.com", "Train@brain");
//            File.WriteAllText(@"C:\Users\coman\Desktop\index.html", respone);
//            Console.WriteLine("Done Login");
            Stopwatch sw = new Stopwatch();
            for (int i = 0; i < 5; i++)
            {
//                sw.Start();
//                FacebookUtilities.SendMessageFast("100003159370688", i.ToString()+".").Wait();
//                sw.Stop();
//                Console.WriteLine($"{i}.Time = {sw.ElapsedTicks}");
//                sw.Reset();
            }

             respone = FacebookUtilities.Login("psp350z@mail.ru", "Train@brain");
             File.WriteAllText(@"C:\Users\coman\Desktop\index.html", respone);
            while (true)
            {
                Console.WriteLine("Write your text:");
                string text = Console.ReadLine();
                Console.WriteLine("Start Sending Message");
                FacebookUtilities.SendMessageFast("100003159370688", text).Wait();
                Console.WriteLine("Message sended");
            }
        }
    }
}
