using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Web_Api_Consume_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RunClient();
            Console.ReadLine();
        }



        static void RunClient()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080"); // Base Server Address (Change Your Address)
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                GetById(client, "1").Wait();
            }
        }


        static async Task GetById(HttpClient client, string id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("api/UrlGeneration/" + id); // api/Controller/Parameter
                response.EnsureSuccessStatusCode();

                string url = await response.Content.ReadAsAsync<String>();
                Console.WriteLine(url);

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex);
            }
        }





    }
}
