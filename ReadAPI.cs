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
        public static async Task<DataTable> PostHTTP(List<string> Stock)
        {
            DataTable dtAll = new DataTable();

            foreach (var item in Stock)
            {
                
                customObj customObj = new customObj() { a = "3", p = new List<Object> {item, 1, 0 } };

                var jSonData = JsonConvert.SerializeObject(customObj);

                var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await httpClient.PostAsync(URL, new StringContent(jSonData, Encoding.UTF8, "application/json"));

                string responseBody = await response.Content.ReadAsStringAsync();

                string pattern = @"(?<_date>\d+)\|(?<vol>\d+)\|(((?<side>[BS])(#?)|#)(?<_price>-?(\d+)?)|\"""")";

                RegexOptions options = RegexOptions.Multiline;

                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("symbol", typeof(string));
                dt.Columns.Add("date", typeof(DateTime));
                dt.Columns.Add("_date", typeof(int));
                dt.Columns.Add("price", typeof(int));
                dt.Columns.Add("vol", typeof(int));
                dt.Columns.Add("total volume", typeof(int));
                dt.Columns.Add("side", typeof(string));
                dt.Columns.Add("_price", typeof(int));


                foreach (Match m in Regex.Matches(responseBody, pattern, options))
                {
                    int _date = Int32.Parse(m.Groups["_date"].Captures[0].Value);
                    int vol = Int32.Parse(m.Groups["vol"].Captures[0].Value);

                    string side = "";
                    try
                    {
                        side = m.Groups["side"].Captures[0].Value;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                    int _price = 0;
                    try
                    {
                        _price = Int32.Parse(m.Groups["_price"].Captures[0].Value);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e); 
                    }
                    dt.Rows.Add(new Object[] { 0, "", new DateTime(1991, 1, 1, 0, 0, 0), _date, 0, vol, 0, side, _price });
                    
                }

                // covert date, total volume
                DateTime origin = new DateTime(1969, 12, 31, 22, 0, 0);
                try
                {
                    dt.Rows[0]["date"] = origin.Add(new TimeSpan(0, 0, 0, (Int32.Parse(dt.Rows[0]["_date"].ToString()))));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    goto Line;
                }
                dt.Rows[0]["total volume"] = Int32.Parse(dt.Rows[0]["vol"].ToString());
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    DateTime datetime = Convert.ToDateTime(dt.Rows[i - 1]["date"].ToString());
                    dt.Rows[i]["date"] = datetime.Add(new TimeSpan(0, 0, 0, Int32.Parse(dt.Rows[i]["_date"].ToString())));
                    dt.Rows[i]["total volume"] = Int32.Parse(dt.Rows[i - 1]["total volume"].ToString()) + Int32.Parse(dt.Rows[i]["vol"].ToString());
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["id"] = i + 1;
                    dt.Rows[i]["symbol"] = item;
                }

                //convert price
                string pattern2 = @"""\d+";
                string b = Regex.Match(responseBody, pattern2).ToString();
                dt.Rows[0]["price"] = Int32.Parse((Regex.Match(responseBody, pattern2).ToString()).Remove(0, 1));
                //dt.Rows[0]["price"] = Int32.Parse(Regex.Match(responseBody, pattern2).ToString());


                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["price"] = Int32.Parse(dt.Rows[i - 1]["price"].ToString()) + Int32.Parse(dt.Rows[i - 1]["_price"].ToString());
                }

                dt.Columns.Remove("_date");
                dt.Columns.Remove("_price");

                if (dtAll != null && dtAll.Rows.Count > 0)
                {
                    dtAll = dtAll.Copy();
                    dtAll.Merge(dt);
                }
                else
                {
                    dtAll = dt;
                }

                Line:
                Console.WriteLine(item);
            }
            return dtAll;

        }
    }
}
