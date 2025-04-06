using System;
using System.Collections.Generic;

namespace LabyCSharp
{
    public class Lab60_61
    {
        // Класс Product с пятью полями разных типов данных
        public class Product
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
            public DateTime ExpiryDate { get; set; }
            public bool IsInStock { get; set; }

            public Product(string name, int quantity, double price, DateTime expiryDate, bool isInStock)
            {
                Name = name;
                Quantity = quantity;
                Price = price;
                ExpiryDate = expiryDate;
                IsInStock = isInStock;
            }
        }

        // Делегат для сравнения объектов Product
        public delegate int ComparisonDelegate(Product p1, Product p2);

        // Метод сортировки с использованием делегата
        public static void SortProducts(List<Product> products, ComparisonDelegate comparison)
        {
            products.Sort(new Comparison<Product>(comparison));
        }

        // Пример сравнения по цене
        public static int CompareByPrice(Product p1, Product p2)
        {
            return p1.Price.CompareTo(p2.Price);
        }

        // Пример сравнения по количеству
        public static int CompareByQuantity(Product p1, Product p2)
        {
            return p1.Quantity.CompareTo(p2.Quantity);
        }

        // Пример сравнения по дате истечения срока
        public static int CompareByExpiryDate(Product p1, Product p2)
        {
            return p1.ExpiryDate.CompareTo(p2.ExpiryDate);
        }

        // Метод Run для выполнения лабораторной работы
        public static void Run()
        {
            Console.WriteLine("Лабораторная работа 60-61 выполняется...");
            // Создание списка объектов Product
            List<Product> products = new List<Product>
            {
                new Product("Product A", 10, 5.99, new DateTime(2025, 12, 1), true),
                new Product("Product B", 25, 2.49, new DateTime(2023, 6, 15), false),
                new Product("Product C", 15, 3.49, new DateTime(2024, 9, 30), true),
                new Product("Product D", 30, 7.99, new DateTime(2022, 1, 5), true),
                new Product("Product E", 5, 9.99, new DateTime(2026, 3, 20), false)
            };

            // Пример сортировки по цене
            Console.WriteLine("Sorting by Price:");
            SortProducts(products, CompareByPrice);
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} - ${product.Price}");
            }

            Console.WriteLine();

            // Пример сортировки по количеству
            Console.WriteLine("Sorting by Quantity:");
            SortProducts(products, CompareByQuantity);
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} - Quantity: {product.Quantity}");
            }

            Console.WriteLine();

            // Пример сортировки по дате истечения срока
            Console.WriteLine("Sorting by Expiry Date:");
            SortProducts(products, CompareByExpiryDate);
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} - Expiry Date: {product.ExpiryDate.ToShortDateString()}");
            }
        }
    }
}
