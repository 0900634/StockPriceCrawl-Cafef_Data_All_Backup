using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class ExportExcelFromTable
    {
        #region Export DataTable to Excel
        public static void ExportToExcel(DataTable tableData, string FileName)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Add(true);

            // Add column headings...
            int iCol = 0;
            foreach (DataColumn c in tableData.Columns)
            {
                iCol++;
                excel.Cells[1, iCol] = c.ColumnName;
            }
            // for each row of data...
            int iRow = 0;
            foreach (DataRow r in tableData.Rows)
            {
                iRow++;
                Console.WriteLine(iRow);
                // add each row's cell data...
                iCol = 0;
                foreach (DataColumn c in tableData.Columns)
                {
                    iCol++;
                    excel.Cells[iRow + 1, iCol] = r[c.ColumnName];
                }
            }


            // Global missing reference for objects we are not defining...
            object missing = System.Reflection.Missing.Value;

            // If wanting to Save the workbook...
            workbook.SaveAs(FileName + ".xls",
                Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, missing, missing,
                false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                missing, missing, missing, missing, missing);

            // If wanting to make Excel visible and activate the worksheet...
            excel.Visible = true;
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
            ((Microsoft.Office.Interop.Excel._Worksheet)worksheet).Activate();

            //// If wanting excel to shutdown...
            //((Microsoft.Office.Interop.Excel._Application)excel).Quit();
        }
        #endregion
    }
}
