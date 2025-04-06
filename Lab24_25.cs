using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyCSharp
{
    public class Lab24_25
    {
        public static void Run()
        {
            Console.WriteLine("Лабораторная работа 24-25 выполняется...");

            int[] A = { 5, 8, 12, 3, 15, 7, 9, 10, 4, 11 };
            int firstIndex = -1;
            int lastIndex = -1;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > A[1] && A[i] < A[9])
                {
                    if (firstIndex == -1) firstIndex = i;
                    lastIndex = i;
                }
            }

            if (firstIndex == -1)
            {
                Console.WriteLine("0");
            }
            else
            {
                Console.WriteLine($"Первый индекс: {firstIndex + 1}, последний индекс: {lastIndex + 1}");
            }
        }
    }
}
