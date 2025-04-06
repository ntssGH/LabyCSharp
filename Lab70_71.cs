using System;
using System.Collections.Generic;
using System.Linq;

namespace LabyCSharp
{
    public class Lab70_71
    {
        public static void Run()
        {
            Console.WriteLine("Лабораторная работа 70-71 выполняется...");
            // Задание 0: Оптимизация с использованием LINQ
            Console.WriteLine("Задание 0:");
            var students1 = new[]
            {
                new { Name = "Алексей", Age = 22 },
                new { Name = "Мария", Age = 19 },
                new { Name = "Дмитрий", Age = 25 }
            };

            var filteredStudents = students1.Where(s => s.Age > 20).Select(s => s.Name).ToList();
            foreach (var name in filteredStudents)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            // Задание 1: Использование Where
            Console.WriteLine("Задание 1:");
            var employees = new[]
            {
                new { Name = "Иван", Age = 28, Department = "IT" },
                new { Name = "Мария", Age = 34, Department = "HR" },
                new { Name = "Анна", Age = 25, Department = "Finance" },
                new { Name = "Дмитрий", Age = 30, Department = "IT" },
            };

            var itEmployees = employees.Where(e => e.Department == "IT").ToList();
            foreach (var employee in itEmployees)
            {
                Console.WriteLine($"{employee.Name}, {employee.Age}, {employee.Department}");
            }

            Console.WriteLine();

            // Задание 2: Использование Select
            Console.WriteLine("Задание 2:");
            var products1 = new[]
            {
                new { Name = "Яблоко", Price = 100 },
                new { Name = "Банан", Price = 80 },
                new { Name = "Груша", Price = 120 },
            };

            var productNames = products1.Select(p => p.Name).ToList();
            foreach (var product in productNames)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine();

            // Задание 3: Использование First
            Console.WriteLine("Задание 3:");
            var books = new[]
            {
                new { Title = "Война и мир", Author = "Лев Толстой" },
                new { Title = "1984", Author = "Джордж Оруэлл" },
                new { Title = "Собачье сердце", Author = "Михаил Булгаков" },
            };

            var tolstoyBook = books.First(b => b.Author == "Лев Толстой");
            Console.WriteLine($"{tolstoyBook.Title} by {tolstoyBook.Author}");

            Console.WriteLine();

            // Задание 4: Использование OrderBy
            Console.WriteLine("Задание 4:");
            var cars = new[]
            {
                new { Brand = "Toyota", Year = 2020 },
                new { Brand = "Honda", Year = 2018 },
                new { Brand = "Ford", Year = 2021 },
            };

            var sortedCars = cars.OrderBy(c => c.Year).ToList();
            foreach (var car in sortedCars)
            {
                Console.WriteLine($"{car.Brand} - {car.Year}");
            }

            Console.WriteLine();

            // Задание 5: Использование GroupBy
            Console.WriteLine("Задание 5:");
            var studentsGrades = new[]
            {
                new { Name = "Алексей", Grade = 5 },
                new { Name = "Мария", Grade = 4 },
                new { Name = "Дмитрий", Grade = 5 },
                new { Name = "Елена", Grade = 3 },
            };

            var groupedByGrade = studentsGrades.GroupBy(s => s.Grade).ToList();
            foreach (var group in groupedByGrade)
            {
                Console.WriteLine($"Оценка {group.Key}:");
                foreach (var student in group)
                {
                    Console.WriteLine($"  {student.Name}");
                }
            }

            Console.WriteLine();

            // Задание 6: Использование Count
            Console.WriteLine("Задание 6:");
            var movies = new[]
            {
                new { Title = "Звёздные войны", Genre = "Фантастика" },
                new { Title = "Зелёная миля", Genre = "Драма" },
                new { Title = "Властелин колец", Genre = "Фантастика" },
            };

            var countFantasyMovies = movies.Count(m => m.Genre == "Фантастика");
            Console.WriteLine($"Количество фильмов в жанре 'Фантастика': {countFantasyMovies}");

            Console.WriteLine();

            // Задание 7: Использование Any
            Console.WriteLine("Задание 7:");
            var clients = new[]
            {
                new { Name = "Андрей", IsActive = false },
                new { Name = "Светлана", IsActive = true },
                new { Name = "Николай", IsActive = false },
            };

            var hasActiveClients = clients.Any(c => c.IsActive);
            Console.WriteLine($"Есть активные клиенты: {hasActiveClients}");

            Console.WriteLine();

            // Задание 8: Использование Last
            Console.WriteLine("Задание 8:");
            var favoriteMovies = new[]
            {
                new { Title = "Терминатор", Year = 1984 },
                new { Title = "Матрица", Year = 1999 },
                new { Title = "Начало", Year = 2010 },
                new { Title = "Интерстеллар", Year = 2014 },
            };

            var lastMovie = favoriteMovies.Last();
            Console.WriteLine($"Последний фильм: {lastMovie.Title} ({lastMovie.Year})");

            Console.WriteLine();

            // Задание 9: Использование Distinct
            Console.WriteLine("Задание 9:");
            var genres = new[]
            {
                new { Name = "Фантастика" },
                new { Name = "Драма" },
                new { Name = "Приключения" },
                new { Name = "Фантастика" },
                new { Name = "Комедия" },
            };

            var distinctGenres = genres.Select(g => g.Name).Distinct().ToList();
            foreach (var genre in distinctGenres)
            {
                Console.WriteLine(genre);
            }

            Console.WriteLine();

            // Задание 10: Использование Take
            Console.WriteLine("Задание 10:");
            var studentsForTake = new[]
            {
                new { Name = "Аня", Age = 18 },
                new { Name = "Борис", Age = 19 },
                new { Name = "Света", Age = 20 },
                new { Name = "Игорь", Age = 21 },
                new { Name = "Фидель", Age = 22 }
            };

            var firstThreeStudents = studentsForTake.Take(3).ToList();
            foreach (var student in firstThreeStudents)
            {
                Console.WriteLine(student.Name);
            }

            Console.WriteLine();

            // Задание 11: Использование Skip
            Console.WriteLine("Задание 11:");
            var booksForSkip = new[]
            {
                new { Title = "1984", Author = "Джордж Оруэлл" },
                new { Title = "Гарри Поттер", Author = "Дж.К. Роулинг" },
                new { Title = "Война и мир", Author = "Лев Толстой" },
                new { Title = "Мастер и Маргарита", Author = "Михаил Булгаков" },
                new { Title = "Убить пересмешника", Author = "Харпер Ли" }
            };

            var skippedBooks = booksForSkip.Skip(2).ToList();
            foreach (var book in skippedBooks)
            {
                Console.WriteLine($"{book.Title} by {book.Author}");
            }

            Console.WriteLine();

            // Задание 12: Использование SelectMany
            Console.WriteLine("Задание 12:");
            var courses = new[]
            {
                new { CourseName = "Математика", Students = new[] { "Аня", "Борис" } },
                new { CourseName = "Физика", Students = new[] { "Света", "Игорь", "Фидель" } }
            };

            var allStudents = courses.SelectMany(c => c.Students).ToList();
            foreach (var student in allStudents)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            // Задание 13: Использование Join
            Console.WriteLine("Задание 13:");
            var customers = new[]
            {
                new { CustomerId = 1, Name = "Иван" },
                new { CustomerId = 2, Name = "Алексей" },
            };

            var ordersList = new[]
            {
                new { OrderId = 101, CustomerId = 1 },
                new { OrderId = 102, CustomerId = 2 },
                new { OrderId = 103, CustomerId = 1 },
            };

            var joinedOrders = customers.Join(ordersList,
                customer => customer.CustomerId,
                order => order.CustomerId,
                (customer, order) => new { order.OrderId, customer.Name }).ToList();

            foreach (var item in joinedOrders)
            {
                Console.WriteLine($"{item.Name} сделал заказ с ID {item.OrderId}");
            }

            Console.WriteLine();

            // Задание 14: Использование ToList
            Console.WriteLine("Задание 14:");
            var services = new[]
            {
                new { ServiceName = "Стрижка", Price = 500 },
                new { ServiceName = "Укладка", Price = 1000 },
                new { ServiceName = "Маникюр", Price = 700 }
            };

            var serviceList = services.Select(s => new { s.ServiceName, s.Price }).ToList();
            foreach (var service in serviceList)
            {
                Console.WriteLine($"{service.ServiceName}: {service.Price} руб.");
            }

            // Задание 15: Использование GroupBy и Select
            Console.WriteLine("Задание 15:");
            var orders = new[]
            {
                new { OrderId = 1, Product = "Шоколад", Quantity = 3 },
                new { OrderId = 2, Product = "Чай", Quantity = 5 },
                new { OrderId = 3, Product = "Шоколад", Quantity = 2 },
                new { OrderId = 4, Product = "Кофе", Quantity = 1 },
                new { OrderId = 5, Product = "Чай", Quantity = 4 }
            };

            var groupedOrders = orders
                .GroupBy(o => o.Product)
                .Select(g => new { Product = g.Key, TotalQuantity = g.Sum(o => o.Quantity) })
                .ToList();

            foreach (var group in groupedOrders)
            {
                Console.WriteLine($"Продукт: {group.Product}, Общее количество: {group.TotalQuantity}");
            }

            Console.WriteLine();

            // Задание 16: Использование OrderByDescending и Take
            Console.WriteLine("Задание 16:");
            var students = new[]
            {
                new { Name = "Анна", Score = 85 },
                new { Name = "Иван", Score = 95 },
                new { Name = "Мария", Score = 90 },
                new { Name = "Дмитрий", Score = 78 },
                new { Name = "Светлана", Score = 88 }
            };

            var top3Students = students
                .OrderByDescending(s => s.Score)
                .Take(3)
                .ToList();

            foreach (var student in top3Students)
            {
                Console.WriteLine($"{student.Name}: {student.Score}");
            }

            Console.WriteLine();

            // Задание 17: Использование Any с условиями
            Console.WriteLine("Задание 17:");
            var products = new[]
            {
                new { Name = "Яблоко", Price = 100, IsAvailable = true },
                new { Name = "Банан", Price = 80, IsAvailable = false },
                new { Name = "Груша", Price = 120, IsAvailable = true },
                new { Name = "Апельсин", Price = 90, IsAvailable = false }
            };

            var hasAvailableProductsAbove90 = products.Any(p => p.IsAvailable && p.Price > 90);
            Console.WriteLine($"Есть доступные продукты по цене выше 90: {hasAvailableProductsAbove90}");

            Console.WriteLine();

            // Задание 18: Использование Zip
            Console.WriteLine("Задание 18:");
            var studentsNames = new[] { "Алексей", "Аня", "Мария" };
            var scores = new[] { 85, 90, 75 };

            var studentScores = studentsNames.Zip(scores, (name, score) => new { Name = name, Score = score }).ToList();
            foreach (var student in studentScores)
            {
                Console.WriteLine($"{student.Name}: {student.Score}");
            }

            Console.WriteLine();

            // Задание 19: Использование TakeWhile
            Console.WriteLine("Задание 19:");
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var numbersLessThan6 = numbers.TakeWhile(n => n < 6).ToList();
            foreach (var number in numbersLessThan6)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();

            // Задание 20: Использование Aggregate
            Console.WriteLine("Задание 20:");
            var incomes = new[] { 50000, 75000, 64000, 48000, 54000 };

            var totalIncome = incomes.Aggregate((sum, income) => sum + income);
            Console.WriteLine($"Общий доход: {totalIncome}");

            Console.WriteLine();

            // Задание 21: Использование Select с GroupBy
            Console.WriteLine("Задание 21:");
            var studentGrades = new[]
            {
                new { Name = "Аня", Subject = "Математика", Grade = 5 },
                new { Name = "Борис", Subject = "Математика", Grade = 4 },
                new { Name = "Аня", Subject = "Физика", Grade = 5 },
                new { Name = "Борис", Subject = "Физика", Grade = 3 }
            };

            var averageGrades = studentGrades
                .GroupBy(s => s.Name)
                .Select(g => new
                {
                    Student = g.Key,
                    AverageGrade = g.Average(s => s.Grade)
                })
                .ToList();

            foreach (var student in averageGrades)
            {
                Console.WriteLine($"{student.Student}: Средняя оценка {student.AverageGrade:F2}");
            }

            Console.WriteLine();

            // Задание 22: Оптимизируйте LINQ-запрос
            Console.WriteLine("Задание 22:");
            var students2 = new[]
            {
                new { Name = "Алексей", Age = 22 },
                new { Name = "Мария", Age = 19 },
                new { Name = "Дмитрий", Age = 25 },
                new { Name = "Светлана", Age = 30 }
            };

            var optimizedQuery = students2
                .Where(s => s.Age > 18)
                .OrderBy(s => s.Name)
                .Select(s => s.Name)
                .ToList();

            foreach (var name in optimizedQuery)
            {
                Console.WriteLine(name);
            }
        }
    }
}
