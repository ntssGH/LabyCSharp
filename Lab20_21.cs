using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyCSharp
{
    public class Lab20_21
    {
        public static void Run()
        {
            Console.WriteLine("Лабораторная работа 20-21 выполняется...");

            Console.WriteLine("Введите три числа (a, b, c):");

            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());
            double c = Convert.ToDouble(Console.ReadLine());

            double max = FindMax(a, b, c);

            Console.WriteLine("Максимальное значение: " + max);

            Console.ReadLine();


            static double FindMax(double a, double b, double c)
            {
                double max = a;
                if (b > max) max = b;
                if (c > max) max = c;
                return max;
            }
        }
    }
}