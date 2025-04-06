using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyCSharp
{
    public class Lab54_55
    {
        public static void Run()
        {
            Console.WriteLine("Лабораторная работа 54-55 выполняется...");

            string inputPath = "length.txt";
            string outputPath = "output.txt";

            try
            {
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("Файл length.txt не найден в корне проекта.");
                    return;
                }

                int maxLength = 0;
                string longestLine = "";

                using (StreamReader reader = new StreamReader(inputPath))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Length > maxLength)
                        {
                            maxLength = line.Length;
                            longestLine = line;
                        }
                    }
                }

                string result = $"Длина самой длинной строки: {maxLength}\nСама строка: {longestLine}";

                File.WriteAllText(outputPath, result);

                Console.WriteLine("Результат записан в файл output.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}
