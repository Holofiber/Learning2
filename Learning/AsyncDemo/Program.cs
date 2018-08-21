using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            LookupHostName(("http://google.com/favicon.ico"));
            Thread.Sleep(10000);
        }



        private static async void LookupHostName(string uri)
        {
            WebClient webClient = new WebClient();
            WebClient webClient1 = new WebClient();
            WebClient webClient2 = new WebClient();
            string page = await webClient.DownloadStringTaskAsync(uri);

            Task<string> firstTask =
                webClient1.DownloadStringTaskAsync("http://oreilly.com");
            Task<string> secondTask =
                webClient2.DownloadStringTaskAsync("http://simpletalk.com");
            string firstPage = await firstTask;

            string secondPage = await secondTask;
            Console.WriteLine("firstPage");
            Console.WriteLine("secondPage");
            Task<int> i = GetPageSizeAsync("http://oreilly.com");

            Console.WriteLine(i.Result);
        }

        private static async Task<int> GetPageSizeAsync(string url)
        {
            Func<Task<int>> getNumberAsync = async delegate { return 3; };

            Func<Task<string>> getWordAsync = async () => "hello";

            WebClient webClient = new WebClient();
            string page = await webClient.DownloadStringTaskAsync(url);
            return page.Length;

            
            
        }

    }
}
