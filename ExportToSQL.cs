using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class ExportToSQL
    {
        public static void ExportToSQLFromTable(DataTable tableData)
        {
            // home: Data Source=TUANANH-LAPTOP\TASQLSERVER;Initial Catalog=HowKteam;Integrated Security=True
            //string connectionString = @"Data Source=TUANANH-LAPTOP\TASQLSERVER;Initial Catalog=HowKteam;Integrated Security=True";

            // company: Data Source=.;Initial Catalog=HowKteam;Integrated Security=True
            string connectionString = @"Data Source=.;Initial Catalog=HowKteam;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                DateTime dt = new DateTime();
                dt = DateTime.Now;
                string tableName = "DATA_" + dt.Year + "_" + dt.Month + "_" + dt.Day;

                string commandtext = "CREATE TABLE [dbo].[" + tableName + "]" +
                    "([date] INT NULL, " +
                    "[vol] INT NULL, " +
                    "[side] NVARCHAR(10) NULL, " +
                    "[price] INT NULL,)";
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
