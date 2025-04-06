using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyCSharp
{
    public class Lab10_11
    {
        public static void Run()
        {
            Console.WriteLine("Лабораторная работа 10-11 выполняется...");

            Console.WriteLine("Введите длину рёбер куба:");
            if (double.TryParse(Console.ReadLine(), out double ribLength))
            {
                double vCube = Math.Pow(ribLength, 3);
                double sCube = 6 * Math.Pow(ribLength, 2);
                Console.WriteLine($"Объём куба: {vCube}");
                Console.WriteLine($"Площадь поверхности куба: {sCube}");
            }
            else
            {
                Console.WriteLine("Ошибка ввода. Ожидалось число.");
            }
        }
    }
}
