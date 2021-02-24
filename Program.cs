using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading;
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

            //await Checkma();
            //ExportToSQL.ExportToSQLFromTableToEndOfDay(await ReadAPI.PostHTTP(await PriceBoard_GetData.GetHSXStock()));
            ExportToSQL.ExportToSQLFromTableToPriceBoad(await PriceBoard_GetData.GetHSXPriceBoard());
            //ExportToSQL.ExportToSQLFromTableToPriceBoad(await PriceBoard_GetData.GetHNXPriceBoard());
            //ExportToSQL.ExportToSQLFromTableToPriceBoad(await PriceBoard_GetData.GetUPCOMPriceBoard());
            Console.WriteLine("finished!");
            Console.ReadKey();
        }

        static async Task Checkma()
        {
            Console.WriteLine("Nhap ma can theo doi:");

            string maCk = Console.ReadLine();

            Console.WriteLine("Nhap Vol 1 min:");

            int minvol1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Nhap Vol 2 min:");

            int minvol2 = Convert.ToInt32(Console.ReadLine());


            //await Task.Run(async () =>
            //{
            //    while (true)
            //    {
            //        await PriceBoard_GetData.CheckVolPriceBoard(maCk, minvol1, minvol2);

            //        await Task.Delay(10000, CancellationToken);
            //        if (CancellationToken.IsCancellationRequested)
            //            break;
            //        Console.ReadKey();
            //    }
            //}
        }

        public static void SendMail(double wvol1, double wvol2)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("tuyendung.vat@gmail.com");
                mail.To.Add("tuyendung.vat@gmail.com");
                mail.Subject = "Notificated date: " + DateTime.Now.ToLongDateString();
                mail.Body = "Buy Alarm \n Buy Waiting Vol 1: "+ wvol1 + "\n Buy Waiting Vol 2: " + wvol2;


                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("tuyendung.vat@gmail.com", "Keylogger911");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                Console.WriteLine("Send mail!");

                
                // phải làm cái này ở mail dùng để gửi phải bật lên
                // https://www.google.com/settings/u/1/security/lesssecureapps
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
