using System.Net.Http;
using System;

namespace TMSHomework
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("TMS Lesson14-Task1-HttpClient");
            Console.WriteLine("Приложение направляет запросы и принимает данные с https://httpbin.org");

            var url = "https://httpbin.org/";
            var content = new StringContent("Hello from TMS!!!");
            using var request = new HttpRequestMessage(HttpMethod.Post, url);

            await HttpClientMethods.Get(url);
            await HttpClientMethods.Delete(url);
            await HttpClientMethods.Put(url, content);
            await HttpClientMethods.Post(url, content);
            await HttpClientMethods.Send(request);
            await HttpClientMethods.Patch(url, content);
        }
    }
}
