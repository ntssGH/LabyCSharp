using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyCSharp
{
    public class Lab34_35
    {
        public static void Run()
        {
            Console.WriteLine("Лабораторная работа 34-35 выполняется...");

            Console.WriteLine("Выберите задание:");
            Console.WriteLine("1 - Вывод чисел от 1 до n (рекурсия)");
            Console.WriteLine("2 - Вывод чисел от A до B (рекурсия)");

            Console.Write("Ваш выбор: ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.Write("Введите число n: ");
                if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
                {
                    Console.Write("Результат: ");
                    PrintNumbers(1, n);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Ошибка: введите натуральное число.");
                }
            }
            else if (input == "2")
            {
                Console.Write("Введите число A: ");
                if (!int.TryParse(Console.ReadLine(), out int a))
                {
                    Console.WriteLine("Ошибка: некорректный ввод A.");
                    return;
                }

                Console.Write("Введите число B: ");
                if (!int.TryParse(Console.ReadLine(), out int b))
                {
                    Console.WriteLine("Ошибка: некорректный ввод B.");
                    return;
                }

                Console.Write("Результат: ");
                PrintRange(a, b);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Некорректный выбор.");
            }

            static void PrintNumbers(int current, int n)
            {
                if (current > n)
                    return;

                Console.Write(current + " ");
                PrintNumbers(current + 1, n);
            }

            static void PrintRange(int a, int b)
            {
                Console.Write(a + " ");
                if (a < b)
                    PrintRange(a + 1, b);
                else if (a > b)
                    PrintRange(a - 1, b);
            }
        }
    }
}
