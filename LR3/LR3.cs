using System;
using Excel = Microsoft.Office.Interop.Excel;

class Program
{
    static void Main()
    {
        // Создаю объект Excel
        Excel.Application excelApp = new Excel.Application();

        // Проверяю, запустился ли Excel
        if (excelApp == null)
        {
            Console.WriteLine("Excel не установлен");
            return;
        }

        // Открываю файл data.xlsx из папки проекта
        Excel.Workbook workbook = excelApp.Workbooks.Open(
            Environment.CurrentDirectory + "\\data.xlsx"
        );

        // Перебираю все листы в Excel-файле
        foreach (Excel.Worksheet sheet in workbook.Worksheets)
        {
            Console.WriteLine("Лист: " + sheet.Name);

            // Получаю область, где есть данные
            Excel.Range range = sheet.UsedRange;

            int rows = range.Rows.Count;
            int cols = range.Columns.Count;

            // Вывожу все ячейки листа
            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    Console.Write(range.Cells[i, j].Value2 + "\t");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        // Закрываю файл
        workbook.Close(false);

        // Закрываю Excel
        excelApp.Quit();

        Console.WriteLine("Данные из Excel выведены");
    }
}
