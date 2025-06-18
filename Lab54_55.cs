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

            // 1. Создаем файл numbers54_55.txt с числами от 1 до 500 через запятую
            Task1_CreateNumbersFile();

            // 2. Записываем массив цветов в файл colors54_55.txt построчно
            Task2_WriteColorsToFile();

            // 3. Находим самую длинную строку в файле length.txt
            Task3_FindLongestLine();

            // Для задач 4-6 вводим массив пользователем
            Console.WriteLine("\nДля задач 4-6 введите целочисленный массив:");
            Console.Write("Введите элементы массива через пробел: ");
            int[] arr = Console.ReadLine()
                                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            // 4. Выводим элементы массива в обратном порядке и записываем их в файл reverse54_55.txt
            Task4_ReverseArray(arr);

            // 5. Выводим сначала элементы с четными индексами, затем с нечетными, записываем в файл evenOdd54_55.txt
            Task5_EvenOddIndices(arr);

            // 6. Преобразуем массив: к четным числам прибавляем первый элемент, кроме первого и последнего
            Task6_TransformArray(arr);

            Console.WriteLine("Все задачи выполнены. Проверьте созданные файлы в корне проекта.");
        }

        private static void Task1_CreateNumbersFile()
        {
            string path = "numbers54_55.txt";
            var numbers = Enumerable.Range(1, 500);
            File.WriteAllText(path, string.Join(",", numbers));
            Console.WriteLine("1) Файл numbers54_55.txt создан.");
        }

        private static void Task2_WriteColorsToFile()
        {
            string path = "colors54_55.txt";
            string[] colors = { "red", "green", "black", "white", "blue" };
            File.WriteAllLines(path, colors);
            Console.WriteLine("2) Файл colors54_55.txt создан.");
        }

        private static void Task3_FindLongestLine()
        {
            string inputPath = "length.txt";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Файл length.txt не найден в корне проекта.");
                return;
            }

            int maxLength = 0;
            string longestLine = string.Empty;

            foreach (var line in File.ReadLines(inputPath))
            {
                if (line.Length > maxLength)
                {
                    maxLength = line.Length;
                    longestLine = line;
                }
            }

            string outputPath = "longestLine54_55.txt";
            string result = $"Длина самой длинной строки: {maxLength}{Environment.NewLine}Сама строка: {longestLine}";
            File.WriteAllText(outputPath, result);
            Console.WriteLine("3) Результат записан в файл longestLine54_55.txt");
        }

        private static void Task4_ReverseArray(int[] arr)
        {
            string outputPath = "reverse54_55.txt";
            var reversed = arr.Reverse();
            File.WriteAllText(outputPath, string.Join(" ", reversed));
            Console.WriteLine("4) Массив записан в обратном порядке в файл reverse54_55.txt");
        }

        private static void Task5_EvenOddIndices(int[] arr)
        {
            string outputPath = "evenOdd54_55.txt";
            var evenIndex = arr.Where((value, index) => index % 2 == 0);
            var oddIndex = arr.Where((value, index) => index % 2 != 0);
            var combined = evenIndex.Concat(oddIndex);
            File.WriteAllText(outputPath, string.Join(" ", combined));
            Console.WriteLine("5) Элементы с четными и нечетными индексами записаны в файл evenOdd54_55.txt");
        }

        private static void Task6_TransformArray(int[] arr)
        {
            string outputPath = "transformed54_55.txt";
            if (arr.Length < 2)
            {
                Console.WriteLine("6) Массив слишком короткий для преобразования.");
                return;
            }

            int first = arr[0];
            int lastIndex = arr.Length - 1;
            int[] transformed = new int[arr.Length];

            transformed[0] = first;
            transformed[lastIndex] = arr[lastIndex];

            for (int i = 1; i < lastIndex; i++)
            {
                if (arr[i] % 2 == 0)
                    transformed[i] = arr[i] + first;
                else
                    transformed[i] = arr[i];
            }

            File.WriteAllText(outputPath, string.Join(" ", transformed));
            Console.WriteLine("6) Преобразованный массив записан в файл transformed54_55.txt");
        }
    }
}