using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyCSharp
{
    public class Lab14_15
    {
        public static void Run()
        {
            Console.WriteLine("Лабораторная работа 14-15 выполняется...");

            Console.WriteLine("Выберите задание:");
            Console.WriteLine("1 - Задание а (вычисление суммы S)");
            Console.WriteLine("2 - Задание б (вычисление максимума m)");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 1)
                {
                    CalculateSum();
                }
                else if (choice == 2)
                {
                    CalculateMax();
                }
                else
                {
                    Console.WriteLine("Некорректный выбор");
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода. Ожидалось число.");
            }


            static void CalculateSum()
            {
                Console.Write("Введите значение M: ");
                if (int.TryParse(Console.ReadLine(), out int M))
                {
                    int S = 0;
                    for (int n = 1; n <= M; n++)
                    {
                        S += n * (n + 1);
                    }
                    Console.WriteLine($"Сумма S = {S}");
                }
                else
                {
                    Console.WriteLine("Ошибка ввода. Ожидалось целое число.");
                }
            }

            static void CalculateMax()
            {
                int[] a = { 1, 2, 3, 4, 5 };
                int[] b = { 15, 4, 3, 2, 1 };
                int N = a.Length;
                int m = int.MinValue;

                for (int i = 0; i < N; i++)
                {
                    int diff = a[i] - b[i];
                    if (diff > m)
                    {
                        m = diff;
                    }
                }

                Console.WriteLine($"Максимум m = {m}");
            }
        }
    }
}
