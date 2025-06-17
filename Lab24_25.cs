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

            Random rnd = new Random();
            int[] A = new int[10];
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = rnd.Next(1, 21);
            }

            Console.WriteLine("Массив A: " + string.Join(", ", A));

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
