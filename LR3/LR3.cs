using System;
using Excel = Microsoft.Office.Interop.Excel;

class Program
{
    static void Main()
    {
        string path = Environment.CurrentDirectory + @"\lab3.xlsx";

        var app = new Excel.Application();
        var book = app.Workbooks.Open(path);

        for (int s = 1; s <= book.Sheets.Count; s++)
        {
            Excel.Worksheet sheet = (Excel.Worksheet)book.Sheets[s];
            Excel.Range range = sheet.UsedRange;

            Console.WriteLine($"\nЛист: {sheet.Name}");

            for (int i = 1; i <= range.Rows.Count; i++)
            {
                for (int j = 1; j <= range.Columns.Count; j++)
                {
                    var cell = (Excel.Range)range.Cells[i, j];
                    Console.Write(cell.Value2 + "\t");
                }

                Console.WriteLine();
            }
        }

        book.Close(false);
        app.Quit();

        Console.WriteLine("\nГотово.");
        Console.ReadKey();
    }
}
