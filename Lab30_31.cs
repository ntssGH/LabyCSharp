using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyCSharp
{
    public class Lab30_31
    {
        public static void Run()
        {
            Console.WriteLine("Лабораторная работа 30-31 выполняется...");

            int[] nums = new int[7];
            Console.WriteLine("Введите семь чисел для сортировки по возрастанию:");

            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write($"{i + 1}-е число: ");
                nums[i] = Int32.Parse(Console.ReadLine());
            }

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        int temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Отсортировано по возрастанию:");
            Console.WriteLine(string.Join(", ", nums));

            Array.Reverse(nums);
            Console.WriteLine();
            Console.WriteLine("Отсортировано по убыванию:");
            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
