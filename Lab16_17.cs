using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyCSharp
{
    public class Lab16_17
    {
        public static void Run()
        {
            Console.WriteLine("Лабораторная работа 16-17 выполняется...");

            Console.WriteLine("Введите число n:");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                int k = 1;
                while (n > 0)
                {
                    if (Math.Pow(2, k + 1) > n)
                    {
                        Console.WriteLine(k + 1);
                        break;
                    }
                    k++;
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода. Ожидалось целое число.");
            }
        }
    }
}
