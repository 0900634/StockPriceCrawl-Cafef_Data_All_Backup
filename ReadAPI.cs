using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data;

namespace ConsoleApp1
{
    class ReadAPI
    {
        private const string URL = "http://stockprice.vn/f/df.asmx/do";
        public static async Task<DataTable> PostHTTP()
        {
            customObj customObj = new customObj() { a = "3", p = new List<Object> { "SHB", 1, 0 } };

            var jSonData = JsonConvert.SerializeObject(customObj);

            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://stockprice.vn/f/df.asmx/do");

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await httpClient.PostAsync(URL, new StringContent(jSonData, Encoding.UTF8, "application/json"));

            string responseBody = await response.Content.ReadAsStringAsync();

            string pattern = @"(?<date>\d+)\|(?<vol>\d+)\|(((?<side>[BS])(#?)|#)(?<price>-?(\d+)?)|\"""")";
            RegexOptions options = RegexOptions.Multiline;


            DataTable dt = new DataTable();

            foreach (var columnName in new[] {"date", "vol", "side", "price",})
            { dt.Columns.Add(columnName);}


            foreach (Match m in Regex.Matches(responseBody, pattern, options))
            {
                dt.Rows.Add(new Object[] { m.Groups["date"].Captures[0].Value, m.Groups["vol"].Captures[0].Value, m.Groups["side"].Captures[0].Value, m.Groups["price"].Captures[0].Value}) ;
            }

            return dt;
        }
    }
}
