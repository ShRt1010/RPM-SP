using System;
using System.IO;
using System.Windows.Forms;

class Program
{
    [STAThread] // Нужно для работы с буфером обмена
    static void Main()
    {
        // Проверяю, есть ли текст в буфере обмена
        if (Clipboard.ContainsText())
        {
            Console.WriteLine("Текст из буфера обмена:");
            Console.WriteLine(Clipboard.GetText());
        }
        else
        {
            Console.WriteLine("В буфере обмена нет текста");
        }

        // Текст, который я копирую в буфер обмена
        string text = "Текст для лабораторной работы";

        // Копирую текст в буфер обмена
        Clipboard.SetText(text);

        Console.WriteLine("\nНовый текст скопирован в буфер обмена");

        // Получаю текст из буфера обмена
        string bufferText = Clipboard.GetText();

        // Записываю текст в сторонний файл
        File.WriteAllText("result.txt", bufferText);

        Console.WriteLine("Текст вставлен в файл result.txt");
    }
}
