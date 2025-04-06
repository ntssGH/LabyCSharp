using System;
using System.Collections.Generic;
using System.Linq;

namespace LabyCSharp
{
    public struct EXPORT
    {
        public string ProductName;
        public string Country; 
        public double Volume; 

        public EXPORT(string productName, string country, double volume)
        {
            ProductName = productName;
            Country = country;
            Volume = volume;
        }
    }

    public class Lab46_47
    {

        public static void Run()
        {
            Console.WriteLine("Лабораторная работа 46-47 выполняется...");

            List<EXPORT> exports = new List<EXPORT>();

            FillDatabase(exports);

            SortDatabase(exports);

            SearchByCountry(exports);
        }

        public static void FillDatabase(List<EXPORT> exports)
        {
            exports.Add(new EXPORT("Товар1", "Россия", 1000));
            exports.Add(new EXPORT("Товар2", "Германия", 1500));
            exports.Add(new EXPORT("Товар3", "Россия", 2000));
            exports.Add(new EXPORT("Товар4", "США", 500));
            exports.Add(new EXPORT("Товар5", "Германия", 1200));

            Console.WriteLine("База данных заполнена.");
        }

        public static void SortDatabase(List<EXPORT> exports)
        {
            Console.WriteLine("Сортировка данных по наименованию товара...");
            var sortedExports = exports.OrderBy(e => e.ProductName).ToList();

            Console.WriteLine("Отсортированные данные:");
            foreach (var export in sortedExports)
            {
                Console.WriteLine($"{export.ProductName}, {export.Country}, {export.Volume}");
            }
        }

        public static void SearchByCountry(List<EXPORT> exports)
        {
            Console.WriteLine("\nВведите страну для поиска общего объема импорта:");
            string country = Console.ReadLine();

            var countryExports = exports.Where(e => e.Country.Equals(country, StringComparison.OrdinalIgnoreCase)).ToList();
            double totalVolume = countryExports.Sum(e => e.Volume);

            if (countryExports.Any())
            {
                Console.WriteLine($"Общий объем импорта для {country}: {totalVolume} единиц.");
            }
            else
            {
                Console.WriteLine("Данные для этой страны не найдены.");
            }
        }
    }
}
