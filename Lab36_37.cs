using System;
using System.Linq;

namespace LabyCSharp
{
    public class Lab36_37
    {
        public static void Run()
        {
            Console.WriteLine("Лабораторная работа 36-37 выполняется...");
            // Задание 1: Замена символов
            Console.WriteLine("Задание 1: Замена символов");
            string input = "Это тестовая строка для замены пробелов на нижнее подчеркивание";
            char replaceWith = '_';
            char toReplace = ' ';
            string replacedString = ReplaceCharacter(input, replaceWith, toReplace);
            Console.WriteLine("Исходная строка: " + input);
            Console.WriteLine("Строка после замены: " + replacedString);
            Console.WriteLine();

            // Задание 2: Генерация случайной строки
            Console.WriteLine("Задание 2: Генерация случайной строки");
            string randomString = GenerateRandomString(32);
            Console.WriteLine("Случайная строка: " + randomString);
            Console.WriteLine();

            // Задание 3: Удаление символов после #
            Console.WriteLine("Задание 3: Удаление символов после #");
            string paragraph = "Это пример строки # с комментариями, которые нужно удалить.";
            string cleanedParagraph = RemoveAfterHash(paragraph);
            Console.WriteLine("Исходный абзац: " + paragraph);
            Console.WriteLine("Абзац после удаления: " + cleanedParagraph);
        }

        // Задание 1: Метод замены символов
        public static string ReplaceCharacter(string input, char replaceWith, char toReplace)
        {
            return input.Replace(toReplace, replaceWith);
        }

        // Задание 2: Метод генерации случайной строки
        public static string GenerateRandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Range(0, length).Select(_ => chars[random.Next(chars.Length)]).ToArray());
        }

        // Задание 3: Метод удаления символов после #
        public static string RemoveAfterHash(string input)
        {
            int index = input.IndexOf('#');
            if (index != -1)
            {
                return input.Substring(0, index);
            }
            return input;
        }
    }
}

