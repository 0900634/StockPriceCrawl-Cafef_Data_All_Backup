using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class customObj
    {
       
        public string a { get; set; }
        public List<Object> p { get; set; }

    }
    class Program
    {
        private const string URL = "http://stockprice.vn/f/df.asmx/do";

        static async Task Main()
        {
            customObj customObj = new customObj() { a = "3", p = new List<Object> { "HVN", 1611240299, 0 }};

            var jSonData = JsonConvert.SerializeObject(customObj);

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://stockprice.vn/f/df.asmx/do");

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await httpClient.PostAsync(URL, new StringContent(jSonData, Encoding.UTF8, "application/json"));

                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseBody);
                Console.ReadLine();
            }
        }
    }
}
