using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TMSHomework
{
    public class HttpClientMethods
    {
        public static async Task Get(string uri)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(response);
        }

        public static async Task Delete(string uri)
        {
            using var client = new HttpClient();
            var response = await client.DeleteAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(response);
        }

        public static async Task Put(string uri, HttpContent httpContent)
        {
            using var client = new HttpClient();
            var response = await client.PutAsync(uri, httpContent);
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(response);
        }

        public static async Task Post(string uri, HttpContent httpContent)
        {
            using var client = new HttpClient();
            var response = await client.PostAsync(uri, httpContent);
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(response);
        }

        public static async Task Send(HttpRequestMessage request)
        {
            using var client = new HttpClient();
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(response);
        }

        public static async Task Patch(string uri, HttpContent httpContent)
        {
            using var client = new HttpClient();
            var response = await client.PatchAsync(uri, httpContent);
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(response);
        }
    }
}
