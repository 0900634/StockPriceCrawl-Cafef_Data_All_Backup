using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data;
using System.Linq;
using System.IO;

namespace ConsoleApp1
{
    public class PriceBoardValue
    {
        public string a { get; set; }
        public decimal b { get; set; }
        public decimal c { get; set; }
        public decimal d { get; set; }
        public decimal e { get; set; }
        public decimal f { get; set; }
        public decimal g { get; set; }
        public decimal h { get; set; }
        public decimal i { get; set; }
        public decimal j { get; set; }
        public decimal k { get; set; }
        public decimal l { get; set; }
        public decimal m { get; set; }
        public decimal n { get; set; }
        public decimal o { get; set; }
        public decimal p { get; set; }
        public decimal q { get; set; }
        public decimal r { get; set; }
        public decimal s { get; set; }
        public decimal t { get; set; }
        public decimal u { get; set; }
        public decimal v { get; set; }
        public decimal w { get; set; }
        public decimal x { get; set; }
        public decimal y { get; set; }
        public decimal z { get; set; }
        public DateTime? Time { get; set; }
        public decimal tb { get; set; }
        public decimal ts { get; set; }
    }
    class PriceBoard_GetData
    {
        private const string URL = "https://banggia.cafef.vn/stockhandler.ashx?center=undefined";

        public static async Task<DataTable> GetHSXPriceBoard()
        {
            HttpClient http = new HttpClient();

            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await http.PostAsync(URL, new StringContent("center = 1", Encoding.UTF8, "application/json"));

            string result = await response.Content.ReadAsStringAsync();


            DataTable dt = new DataTable();


            dt = JsonConvert.DeserializeObject<DataTable>(result);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Console.WriteLine(dt.Rows[i]["a"]);
                dt.Rows[i]["b"] = Convert.ToDouble(dt.Rows[i]["b"]);
                dt.Rows[i]["c"] = Convert.ToDouble(dt.Rows[i]["c"]);
                dt.Rows[i]["d"] = Convert.ToDouble(dt.Rows[i]["d"]);
                dt.Rows[i]["e"] = Convert.ToDouble(dt.Rows[i]["e"]);
                dt.Rows[i]["f"] = Convert.ToDouble(dt.Rows[i]["f"]);
                dt.Rows[i]["g"] = Convert.ToDouble(dt.Rows[i]["g"]);
                dt.Rows[i]["h"] = Convert.ToDouble(dt.Rows[i]["h"]);
                //try
                //{
                //    dt.Rows[i]["i"] = Convert.ToDouble(dt.Rows[i]["i"]);
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e);
                //}
                dt.Rows[i]["j"] = Convert.ToDouble(dt.Rows[i]["j"]);
                dt.Rows[i]["k"] = Convert.ToDouble(dt.Rows[i]["k"]);
                dt.Rows[i]["l"] = Convert.ToDouble(dt.Rows[i]["l"]);
                dt.Rows[i]["m"] = Convert.ToDouble(dt.Rows[i]["m"]);
                dt.Rows[i]["n"] = Convert.ToDouble(dt.Rows[i]["n"]);
                //try
                //{
                //    dt.Rows[i]["o"] = Convert.ToDouble(dt.Rows[i]["o"]);
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e);
                //}

                dt.Rows[i]["p"] = Convert.ToDouble(dt.Rows[i]["p"]);
                dt.Rows[i]["q"] = Convert.ToDouble(dt.Rows[i]["q"]);
                dt.Rows[i]["r"] = Convert.ToDouble(dt.Rows[i]["r"]);
                dt.Rows[i]["s"] = Convert.ToDouble(dt.Rows[i]["s"]);
                dt.Rows[i]["t"] = Convert.ToDouble(dt.Rows[i]["t"]);
                dt.Rows[i]["u"] = Convert.ToDouble(dt.Rows[i]["u"]);
                dt.Rows[i]["v"] = Convert.ToDouble(dt.Rows[i]["v"]);
                dt.Rows[i]["w"] = Convert.ToDouble(dt.Rows[i]["w"]);
                dt.Rows[i]["x"] = Convert.ToDouble(dt.Rows[i]["x"]);
                dt.Rows[i]["y"] = Convert.ToDouble(dt.Rows[i]["y"]);
                dt.Rows[i]["z"] = Convert.ToDouble(dt.Rows[i]["z"]);
                dt.Rows[i]["tb"] = Convert.ToDouble(dt.Rows[i]["tb"]);
                dt.Rows[i]["ts"] = Convert.ToDouble(dt.Rows[i]["ts"]);

                string datetimee = dt.Rows[i]["Time"].ToString();

                if (datetimee != string.Empty)
                {
                    DateTime dtime = new DateTime(
                        int.Parse(datetimee.Substring(12, 4)),
                        int.Parse(datetimee.Substring(9, 2)),
                        int.Parse(datetimee.ToString().Substring(6, 2)),
                        int.Parse(datetimee.ToString().Substring(0, 2)),
                        int.Parse(datetimee.ToString().Substring(3, 2)), 0);
                    dt.Rows[i]["Time"] = dtime;
                }
                else
                {
                    DateTime dtime = new DateTime(1900, 1, 1, 0, 0, 0);
                    dt.Rows[i]["Time"] = dtime;
                }
            }
            return dt; // into CSDL
        }

        public static async Task<DataTable> GetHNXPriceBoard()
        {
            HttpClient http = new HttpClient();

            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await http.PostAsync(URL, new StringContent("center = 2", Encoding.UTF8, "application/json"));

            string result = await response.Content.ReadAsStringAsync();


            DataTable dt = new DataTable();


            dt = JsonConvert.DeserializeObject<DataTable>(result);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["b"] = Convert.ToDouble(dt.Rows[i]["b"]);
                dt.Rows[i]["c"] = Convert.ToDouble(dt.Rows[i]["c"]);
                dt.Rows[i]["d"] = Convert.ToDouble(dt.Rows[i]["d"]);
                dt.Rows[i]["e"] = Convert.ToDouble(dt.Rows[i]["e"]);
                dt.Rows[i]["f"] = Convert.ToDouble(dt.Rows[i]["f"]);
                dt.Rows[i]["g"] = Convert.ToDouble(dt.Rows[i]["g"]);
                dt.Rows[i]["h"] = Convert.ToDouble(dt.Rows[i]["h"]);
                try
                {
                    dt.Rows[i]["i"] = Convert.ToDouble(dt.Rows[i]["i"]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                dt.Rows[i]["j"] = Convert.ToDouble(dt.Rows[i]["j"]);
                dt.Rows[i]["k"] = Convert.ToDouble(dt.Rows[i]["k"]);
                dt.Rows[i]["l"] = Convert.ToDouble(dt.Rows[i]["l"]);
                dt.Rows[i]["m"] = Convert.ToDouble(dt.Rows[i]["m"]);
                dt.Rows[i]["n"] = Convert.ToDouble(dt.Rows[i]["n"]);
                try
                {
                    dt.Rows[i]["o"] = Convert.ToDouble(dt.Rows[i]["o"]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                dt.Rows[i]["p"] = Convert.ToDouble(dt.Rows[i]["p"]);
                dt.Rows[i]["q"] = Convert.ToDouble(dt.Rows[i]["q"]);
                dt.Rows[i]["r"] = Convert.ToDouble(dt.Rows[i]["r"]);
                dt.Rows[i]["s"] = Convert.ToDouble(dt.Rows[i]["s"]);
                dt.Rows[i]["t"] = Convert.ToDouble(dt.Rows[i]["t"]);
                dt.Rows[i]["u"] = Convert.ToDouble(dt.Rows[i]["u"]);
                dt.Rows[i]["v"] = Convert.ToDouble(dt.Rows[i]["v"]);
                dt.Rows[i]["w"] = Convert.ToDouble(dt.Rows[i]["w"]);
                dt.Rows[i]["x"] = Convert.ToDouble(dt.Rows[i]["x"]);
                dt.Rows[i]["y"] = Convert.ToDouble(dt.Rows[i]["y"]);
                dt.Rows[i]["z"] = Convert.ToDouble(dt.Rows[i]["z"]);
                dt.Rows[i]["tb"] = Convert.ToDouble(dt.Rows[i]["tb"]);
                dt.Rows[i]["ts"] = Convert.ToDouble(dt.Rows[i]["ts"]);

                string datetimee = dt.Rows[i]["Time"].ToString();

                if (datetimee != string.Empty)
                {
                    DateTime dtime = new DateTime(
                        int.Parse(datetimee.Substring(12, 4)),
                        int.Parse(datetimee.Substring(9, 2)),
                        int.Parse(datetimee.ToString().Substring(6, 2)),
                        int.Parse(datetimee.ToString().Substring(0, 2)),
                        int.Parse(datetimee.ToString().Substring(3, 2)), 0);
                    dt.Rows[i]["Time"] = dtime;
                }
                else
                {
                    DateTime dtime = new DateTime(1900, 1, 1, 0, 0, 0);
                    dt.Rows[i]["Time"] = dtime;
                }
            }
            return dt; // into CSDL
        }

        public static async Task<DataTable> GetUPCOMPriceBoard()
        {
            HttpClient http = new HttpClient();

            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await http.PostAsync(URL, new StringContent("center = 9", Encoding.UTF8, "application/json"));

            string result = await response.Content.ReadAsStringAsync();


            DataTable dt = new DataTable();


            dt = JsonConvert.DeserializeObject<DataTable>(result);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["b"] = Convert.ToDouble(dt.Rows[i]["b"]);
                dt.Rows[i]["c"] = Convert.ToDouble(dt.Rows[i]["c"]);
                dt.Rows[i]["d"] = Convert.ToDouble(dt.Rows[i]["d"]);
                dt.Rows[i]["e"] = Convert.ToDouble(dt.Rows[i]["e"]);
                dt.Rows[i]["f"] = Convert.ToDouble(dt.Rows[i]["f"]);
                dt.Rows[i]["g"] = Convert.ToDouble(dt.Rows[i]["g"]);
                dt.Rows[i]["h"] = Convert.ToDouble(dt.Rows[i]["h"]);
                try
                {
                    dt.Rows[i]["i"] = Convert.ToDouble(dt.Rows[i]["i"]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                dt.Rows[i]["j"] = Convert.ToDouble(dt.Rows[i]["j"]);
                dt.Rows[i]["k"] = Convert.ToDouble(dt.Rows[i]["k"]);
                dt.Rows[i]["l"] = Convert.ToDouble(dt.Rows[i]["l"]);
                dt.Rows[i]["m"] = Convert.ToDouble(dt.Rows[i]["m"]);
                dt.Rows[i]["n"] = Convert.ToDouble(dt.Rows[i]["n"]);
                try
                {
                    dt.Rows[i]["o"] = Convert.ToDouble(dt.Rows[i]["o"]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                dt.Rows[i]["p"] = Convert.ToDouble(dt.Rows[i]["p"]);
                dt.Rows[i]["q"] = Convert.ToDouble(dt.Rows[i]["q"]);
                dt.Rows[i]["r"] = Convert.ToDouble(dt.Rows[i]["r"]);
                dt.Rows[i]["s"] = Convert.ToDouble(dt.Rows[i]["s"]);
                dt.Rows[i]["t"] = Convert.ToDouble(dt.Rows[i]["t"]);
                dt.Rows[i]["u"] = Convert.ToDouble(dt.Rows[i]["u"]);
                dt.Rows[i]["v"] = Convert.ToDouble(dt.Rows[i]["v"]);
                dt.Rows[i]["w"] = Convert.ToDouble(dt.Rows[i]["w"]);
                dt.Rows[i]["x"] = Convert.ToDouble(dt.Rows[i]["x"]);
                dt.Rows[i]["y"] = Convert.ToDouble(dt.Rows[i]["y"]);
                dt.Rows[i]["z"] = Convert.ToDouble(dt.Rows[i]["z"]);
                dt.Rows[i]["tb"] = Convert.ToDouble(dt.Rows[i]["tb"]);
                dt.Rows[i]["ts"] = Convert.ToDouble(dt.Rows[i]["ts"]);

                string datetimee = dt.Rows[i]["Time"].ToString();

                if (datetimee != string.Empty)
                {
                    DateTime dtime = new DateTime(
                        int.Parse(datetimee.Substring(12, 4)),
                        int.Parse(datetimee.Substring(9, 2)),
                        int.Parse(datetimee.ToString().Substring(6, 2)),
                        int.Parse(datetimee.ToString().Substring(0, 2)),
                        int.Parse(datetimee.ToString().Substring(3, 2)), 0);
                    dt.Rows[i]["Time"] = dtime;
                }
                else
                {
                    DateTime dtime = new DateTime(1900, 1, 1, 0, 0, 0);
                    dt.Rows[i]["Time"] = dtime;
                }
            }
            return dt; // into CSDL
        }

        public static async Task<List<string>> GetHSXStock()
        {
            HttpClient http = new HttpClient();

            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await http.PostAsync(URL, new StringContent("center = 1", Encoding.UTF8, "application/json"));

            string result = await response.Content.ReadAsStringAsync();

            DataTable dt = JsonConvert.DeserializeObject<DataTable>(result);

            string columnName = "a";

            List<string> HSX_Stock = dt.Rows.OfType<DataRow>().Select(dr => dr.Field<string>(columnName)).ToList();

            return HSX_Stock;
        }

        public static async Task<List<string>> GetHNXStock()
        {
            HttpClient http = new HttpClient();

            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await http.PostAsync(URL, new StringContent("center = 2", Encoding.UTF8, "application/json"));

            string result = await response.Content.ReadAsStringAsync();

            DataTable dt = JsonConvert.DeserializeObject<DataTable>(result);

            string columnName = "a";

            List<string> HNX_Stock = dt.Rows.OfType<DataRow>().Select(dr => dr.Field<string>(columnName)).ToList();

            return HNX_Stock;
        }

        public static async Task<List<string>> GetUPCOMStock()
        {
            HttpClient http = new HttpClient();

            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await http.PostAsync(URL, new StringContent("center = 9", Encoding.UTF8, "application/json"));

            string result = await response.Content.ReadAsStringAsync();

            DataTable dt = JsonConvert.DeserializeObject<DataTable>(result);

            string columnName = "a";

            List<string> UPCOM_Stock = dt.Rows.OfType<DataRow>().Select(dr => dr.Field<string>(columnName)).ToList();

            return UPCOM_Stock;
        }

        public static async Task CheckVolPriceBoard(string maCk, int minvol1, int minvol2 )
        {

            HttpClient http = new HttpClient();

            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await http.PostAsync(URL, new StringContent("center = 1", Encoding.UTF8, "application/json"));

            string result = await response.Content.ReadAsStringAsync();


            DataTable dt = new DataTable();


            dt = JsonConvert.DeserializeObject<DataTable>(result);

            int maso = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["a"].Equals(maCk))
                {
                    maso = i;
                }
            }

            double wvol1 = Convert.ToInt32(dt.Rows[maso]["j"].ToString());
            double wvol2 = Convert.ToInt32(dt.Rows[maso]["p"].ToString());

            //double wvol1 = 100;
            //double wvol2 = 100;

            if ((wvol1 >= minvol1) && (wvol2>= minvol2))
            {
                Program.SendMail(wvol1, wvol2);
            }
          
        }
    }
}
