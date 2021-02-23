using System;
using System.Net;

namespace Exercise_3._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter URL: ");
            string urlStr = Console.ReadLine();

            Uri url = new UriBuilder(urlStr).Uri;
            string host = url.Host;
            Uri robotsTxtUrl = new UriBuilder(host + "/robots.txt").Uri;
            
            try
            {
                WebClient wc = new WebClient();
                wc.Headers.Add(HttpRequestHeader.UserAgent, "bhp-bot; CS student practice crawler; Developer: Bent H. Pedersen (bhp@easv.dk)");
                wc.Headers.Add(HttpRequestHeader.From, "bhp@easv.dk");
            
                String robotstxt = wc.DownloadString(robotsTxtUrl.ToString());
                
                string[] lines = robotstxt.ToLower().Split("\n");
                int i = 0;
                while (i < lines.Length && !lines[i].Contains("user-agent: *"))
                { 
                    i++;
                }

                i++; // by-passing the user-agent: * line
                
                while (i < lines.Length && !lines[i].Contains("user-agent"))
                {
                    Console.WriteLine(lines[i]);
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
