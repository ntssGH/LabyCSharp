using System;
using System.IO;

namespace LabyCSharp
{
    class Lab56_57
    {
        public static void Run()
        {
            Console.WriteLine("Лабораторная работа 56-57 выполняется...");
            // Задание 1: Создание файла с числами от 1 до 256
            string numbersFilePath = "numbers.txt";
            using (StreamWriter writer = new StreamWriter(numbersFilePath))
            {
                for (int i = 1; i <= 256; i++)
                {
                    writer.Write(i);
                    if (i < 256) writer.Write(", ");
                }
            }
            Console.WriteLine("Задание 1: Числа от 1 до 256 записаны в файл numbers.txt.\n");

            // Задание 2: Запись элементов массива в файл
            string[] cars = { "Toyota", "Ford", "Chevrolet", "Honda", "Nissan", "BMW", "Mercedes-Benz", "Audi", "Volkswagen", "Hyundai", "Kia" };
            string carsFilePath = "cars56_57.txt";
            using (StreamWriter writer = new StreamWriter(carsFilePath))
            {
                foreach (var car in cars)
                {
                    writer.WriteLine(car);
                }
            }
            Console.WriteLine("Задание 2: Массив марок автомобилей записан в файл cars56_57.txt.\n");

            // Задание 3: Нахождение самой длинной строки в файле
            string filePath = "length.txt"; // Укажите путь к своему текстовому файлу
            string longestLine = "";
            try
            {
                foreach (var line in File.ReadLines(filePath))
                {
                    if (line.Length > longestLine.Length)
                    {
                        longestLine = line;
                    }
                }
                Console.WriteLine("Задание 3: Самая длинная строка в файле: " + longestLine + "\n");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Задание 3: Файл length.txt не найден.\n");
            }

            // Задание 4: Обработка массива случайных чисел
            Random random = new Random();
            int N = 20; // Размер массива
            int[] array = new int[N];

            // Заполнение массива случайными числами
            for (int i = 0; i < N; i++)
            {
                array[i] = random.Next(1, 1000);
            }

            string outputFilePath = "output56_57.txt";
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                // Печать четных индексов
                writer.WriteLine("Четные индексы:");
                for (int i = 0; i < N; i += 2)
                {
                    writer.Write(array[i] + " ");
                }
                writer.WriteLine();

                // Печать нечетных индексов
                writer.WriteLine("Нечетные индексы:");
                for (int i = 1; i < N; i += 2)
                {
                    writer.Write(array[i] + " ");
                }
            }

            Console.WriteLine("Задание 4: Массив с четными и нечетными индексами записан в файл output.txt.\n");

            // Вариант 3: Шифрование и дешифрование бинарного файла
            string inputFile = "input_image56_57.jpg"; // Исходный файл изображения
            string encryptedFile = "encrypted_image56_57.jpg"; // Зашифрованный файл
            string decryptedFile = "decrypted_image56_57.jpg"; // Дешифрованный файл
            byte key = 123; // Ключ для шифрования и дешифрования

            try
            {
                // Чтение бинарного файла и шифрование
                byte[] fileBytes = File.ReadAllBytes(inputFile);
                for (int i = 0; i < fileBytes.Length; i++)
                {
                    fileBytes[i] ^= key;
                }

                // Запись зашифрованных данных в новый файл
                File.WriteAllBytes(encryptedFile, fileBytes);

                // Дешифрование
                for (int i = 0; i < fileBytes.Length; i++)
                {
                    fileBytes[i] ^= key;
                }

                // Запись дешифрованных данных в новый файл
                File.WriteAllBytes(decryptedFile, fileBytes);

                Console.WriteLine("Задание 5: Шифрование и дешифрование изображения завершены. Файлы сохранены.\n");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Задание 5: Изображение не найдено (input_image56_57.jpgg).\n");
            }
        }
    }
}
