using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class ExportToSQL
    {
        public static void ExportToSQLFromTableToEndOfDay(DataTable tableData)
        {
            // home: 
            //string connectionString = @"Data Source=TUANANH-LAPTOP\TASQLSERVER;Initial Catalog=HowKteam;Integrated Security=True";

            // company:
            string connectionString = @"Data Source=.;Initial Catalog=HowKteam;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                DateTime dt = new DateTime();
                dt = DateTime.Now;
                string tableName = "DATA_" + dt.Year + "_" + dt.Month + "_" + dt.Day;
                //try
                //{
                //    string commandText = "DROP TABLE A";
                //    SqlCommand command = new SqlCommand(commandText, connection);
                //    command.ExecuteNonQuery();
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e);
                //}
                string commandtext = "CREATE TABLE [dbo].[" + tableName + "]" +
                    "([Id] INT NULL, " +
                    "[Symbol] NVARCHAR(10) NULL, " +
                    "[Date] DATETIME NULL, " +
                    "[Price] INT NULL, " +
                    "[Volume] INT NULL, " +
                    "[Total Volume] INT NULL, " +
                    "[Side] NVARCHAR(10) NULL,)";
                SqlCommand sqlCommand = new SqlCommand(commandtext, connection);
                sqlCommand.ExecuteNonQuery();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = tableName;

                    try
                    {
                        //Write from the source to the destination.
                        bulkCopy.WriteToServer(tableData);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                connection.Close();
                connection.Dispose();
            }
        }
        public static void ExportToSQLFromTableToDataAll(DataTable tableData)
        {
            string connectionString = @"Data Source=.;Initial Catalog=HowKteam;Integrated Security=True";
            // home: Data Source=TUANANH-LAPTOP\TASQLSERVER;Initial Catalog=Primary_Forein;Integrated Security=True
            // company: Data Source=.;Initial Catalog=HowKteam;Integrated Security=True
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "DATA_ALL";

                    try
                    {
                        //Write from the source to the destination.
                        bulkCopy.WriteToServer(tableData);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                connection.Close();
                connection.Dispose();

            }
        }
        public static void ExportToSQLFromTableToPriceBoad(DataTable tableData)
        {
            // home: 
            //string connectionString = @"Data Source=TUANANH-LAPTOP\TASQLSERVER;Initial Catalog=PriceBoard;Integrated Security=True";

            // company: 
            string connectionString = @"Data Source=.;Initial Catalog=PriceBoard;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                DateTime dt = new DateTime();
                dt = DateTime.Now;
                string tableName = "PRICEBOARD_" + dt.Year + "_" + dt.Month + "_" + dt.Day + "_" + dt.Hour + "_" + dt.Minute + "_" + dt.Second;
                
                string commandtext = "CREATE TABLE [dbo].[" + tableName + "]" +
                    "([MaCK] NVARCHAR(10) NULL, " +
                    "[ThamChieu] REAL NULL, " +
                    "[Tran] REAL NULL, " +
                    "[San] REAL NULL, " +
                    "[GiaMua3] REAL NULL, " +
                    "[KLMua3] REAL NULL, " +

                    "[GiaMua2] REAL NULL, " +
                    "[KLMua2] REAL NULL, " +

                    "[GiaMua1] NVARCHAR(10) NULL, " +
                    "[KLMua1] REAL NULL, " +

                    "[ChenhKhop] REAL NULL, " +
                    "[GiaKhop] REAL NULL, " +
                    "[KLKhop] REAL NULL, " +
                    "[TongKLKhop] REAL NULL, " +

                    "[GiaBan1] NVARCHAR(10) NULL, " +
                    "[KLBan1] REAL NULL, " +

                    "[GiaBan2] REAL NULL, " +
                    "[KLBan2] REAL NULL, " +

                    "[GiaBan3] REAL NULL, " +
                    "[KLBan3] REAL NULL, " +

                    "[Khong] REAL NULL, " +

                    "[CaoNhat] REAL NULL, " +
                    "[ThapNhat] REAL NULL, " +

                    "[NNMua] REAL NULL, " +
                    "[NNBan] REAL NULL, " +

                    "[Mot] REAL NULL, " +

                    "[ThoiGian] DATETIME NULL, " +
                    "[TB] REAL NULL, " +
                    "[TS] REAL NULL, )";

                SqlCommand sqlCommand = new SqlCommand(commandtext, connection);
                sqlCommand.ExecuteNonQuery();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = tableName;

                    try
                    {
                        //Write from the source to the destination.
                        bulkCopy.WriteToServer(tableData);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                connection.Close();
                connection.Dispose();
            }
        }

    }
}
