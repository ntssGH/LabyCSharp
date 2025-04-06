using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyCSharp
{
    public class Lab18_19
    {
        public static void Run()
        {
            Console.WriteLine("Лабораторная работа 18-19 выполняется...");

            Console.Write("Введите натуральное число n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                int k = 0;
                while (Math.Pow(2, k) < n)
                {
                    k++;
                }
                Console.WriteLine($"Наименьшее целое k, такое что 2^k ≥ n, равно {k}");
            }
            else
            {
                Console.WriteLine("Ошибка ввода. Введите натуральное число.");
            }
        }
    }
}
