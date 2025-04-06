using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyCSharp
{
    public class Lab12_13
    {
        public static void Run()
        {
            Console.WriteLine("Лабораторная работа 12-13 выполняется...");

            Console.WriteLine("Введите три величины:");
            bool aOk = int.TryParse(Console.ReadLine(), out int a);
            bool bOk = int.TryParse(Console.ReadLine(), out int b);
            bool cOk = int.TryParse(Console.ReadLine(), out int c);

            if (aOk && bOk && cOk)
            {
                int x;
                if (a > b && a > c)
                    x = a;
                else if (b > c)
                    x = b;
                else
                    x = c;

                Console.WriteLine($"Максимальная величина: {x}");
            }
            else
            {
                Console.WriteLine("Ошибка ввода. Все значения должны быть целыми числами.");
            }
        }
    }
}
