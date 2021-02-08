using System;
using System.Collections.Generic;
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
        

        static async Task Main(string[] args)
        {
            DateTime date = new DateTime();
            date = DateTime.Now;
            string Filename = "D:/" + date.Year + "." + date.Month + "." + date.Day + "data";

            await ReadAPI.PostHTTP();


            ExportToSQL.ExportToSQLFromTable(await ReadAPI.PostHTTP());
            Console.WriteLine("finished!");
            Console.ReadKey();
        }
    }      
}
