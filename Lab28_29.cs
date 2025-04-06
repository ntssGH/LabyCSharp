using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyCSharp
{
    public class Lab28_29
    {
        public static void Run()
        {
            Console.WriteLine("Лабораторная работа 28-29 выполняется...");

            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Сортировка выбором по возрастанию");
            Console.WriteLine("2 - Сортировка выбором по убыванию");

            Console.Write("Введите номер операции: ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                int[] array = ReadArrayFromUser();
                SelectionSortAscending(array);
                Console.WriteLine("Отсортированный массив (по возрастанию):");
                PrintArray(array);
            }
            else if (input == "2")
            {
                int[] array = ReadArrayFromUser();
                SelectionSortDescending(array);
                Console.WriteLine("Отсортированный массив (по убыванию):");
                PrintArray(array);
            }
            else
            {
                Console.WriteLine("Некорректный выбор.");
            }

            Console.WriteLine("Нажмите Enter для выхода...");
            Console.ReadLine();


            static int[] ReadArrayFromUser()
            {
                Console.Write("Введите элементы массива через пробел: ");
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int[] arr = new int[tokens.Length];

                for (int i = 0; i < tokens.Length; i++)
                {
                    arr[i] = int.Parse(tokens[i]);
                }

                return arr;
            }

            static void SelectionSortAscending(int[] arr)
            {
                int n = arr.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < n; j++)
                    {
                        if (arr[j] < arr[minIndex])
                        {
                            minIndex = j;
                        }
                    }
                    if (minIndex != i)
                    {
                        int temp = arr[i];
                        arr[i] = arr[minIndex];
                        arr[minIndex] = temp;
                    }
                }
            }

            static void SelectionSortDescending(int[] arr)
            {
                int n = arr.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    int maxIndex = i;
                    for (int j = i + 1; j < n; j++)
                    {
                        if (arr[j] > arr[maxIndex])
                        {
                            maxIndex = j;
                        }
                    }
                    if (maxIndex != i)
                    {
                        int temp = arr[i];
                        arr[i] = arr[maxIndex];
                        arr[maxIndex] = temp;
                    }
                }
            }

            static void PrintArray(int[] arr)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}