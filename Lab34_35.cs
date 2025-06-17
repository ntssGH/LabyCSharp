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
            Console.Write("Введите неотрицательное целое m: ");
            if (!long.TryParse(Console.ReadLine(), out long m) || m < 0)
            {
                Console.WriteLine("Некорректное значение m");
                return;
            }

            Console.Write("Введите неотрицательное целое n: ");
            if (!long.TryParse(Console.ReadLine(), out long n) || n < 0)
            {
                Console.WriteLine("Некорректное значение n");
                return;
            }

            try
            {
                long result = Ackermann(m, n);
                Console.WriteLine($"A({m}, {n}) = {result}");
            }
            catch (StackOverflowException)
            {
                Console.WriteLine("Ошибка: превышена глубина рекурсии.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        private static long Ackermann(long m, long n)
        {
            if (m == 0)
                return n + 1;
            else if (n == 0)
                return Ackermann(m - 1, 1);
            else
                return Ackermann(m - 1, Ackermann(m, n - 1));
        }
    }
}