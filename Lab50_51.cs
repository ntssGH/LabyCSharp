using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LabyCSharp.Lab50_51
{
    public class Freshman
    {
        public string LastName, FirstName, Patronymic, Group;
        public int Score;

        public Freshman(string lastName, string firstName, string patronymic, string group, int score)
        {
            LastName = lastName; FirstName = firstName; Patronymic = patronymic; Group = group; Score = score;
        }

        ~Freshman() => Console.WriteLine($"Студент {LastName} удален.");
    }

    public class Book
    {
        public string Author, Title, Publisher;
        public int Year;

        public Book(string author, string title, string publisher, int year)
        {
            Author = author; Title = title; Publisher = publisher; Year = year;
        }

        ~Book() => Console.WriteLine($"Книга {Title} удалена.");
    }

    public class CarOwner
    {
        public string Owner, Brand, Country;
        public int Year;

        public CarOwner(string owner, string brand, int year, string country)
        {
            Owner = owner; Brand = brand; Year = year; Country = country;
        }

        ~CarOwner() => Console.WriteLine($"Авто {Brand} владельца {Owner} удалено.");
    }

    public class Lab50_51
    {
        public static void Run()
        {
            Console.WriteLine("Лабораторная работа 50-51 выполняется...");
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // === Freshman ===
            var students = File.ReadAllLines("students.txt")
                .Select(l => l.Split(','))
                .Select(p => new Freshman(p[0].Trim(), p[1].Trim(), p[2].Trim(), p[3].Trim(), int.Parse(p[4].Trim())))
                .ToList();

            PrintStats(students, s => s.LastName, "Фамилии", "3.1.1");
            PrintStats(students, s => s.FirstName, "Имена", "3.1.2");
            PrintStats(students, s => s.Patronymic, "Отчества", "3.1.3");
            PrintStats(students, s => s.Group, "Группы", "3.1.4");
            PrintStats(students, s => s.Score.ToString(), "Баллы", "3.1.5");

            PrintMaxCountGroup(students, s => s.FirstName, "Имена, встречающиеся чаще всего", "3.1.6");
            PrintMaxCountGroup(students, s => s.Group, "Группы с наибольшим числом студентов", "3.1.7");

            int maxScore = students.Max(s => s.Score);
            Console.WriteLine("3.1.8 Студенты с максимальными баллами:");
            foreach (var s in students.Where(s => s.Score == maxScore))
                Console.WriteLine($"{s.LastName} {s.FirstName} {s.Patronymic}, {s.Group}, {s.Score}");

            var maxScoreGroups = students.Where(s => s.Score == maxScore)
                                          .GroupBy(s => s.Group)
                                          .OrderByDescending(g => g.Count());
            int maxGroupCount = maxScoreGroups.First().Count();
            Console.WriteLine("3.1.9 Группы с макс. числом студентов с макс. баллами:");
            foreach (var g in maxScoreGroups.Where(g => g.Count() == maxGroupCount))
                Console.WriteLine($"{g.Key}: {g.Count()}");

            double maxAvg = students.GroupBy(s => s.Group).Max(g => g.Average(s => s.Score));
            Console.WriteLine("3.1.10 Группы с максимальным средним баллом:");
            foreach (var g in students.GroupBy(s => s.Group).Where(g => Math.Abs(g.Average(s => s.Score) - maxAvg) < 0.001))
                Console.WriteLine($"{g.Key}: {g.Average(s => s.Score):F2}");

            // === Books ===
            var books = File.ReadAllLines("books.txt")
                .Select(l => l.Split(','))
                .Select(p => new Book(p[0].Trim(), p[1].Trim(), p[2].Trim(), int.Parse(p[3].Trim())))
                .ToList();

            PrintStats(books, b => b.Author, "Авторы", "3.2.1");
            PrintStats(books, b => b.Title, "Названия книг", "3.2.2");
            PrintStats(books, b => b.Publisher, "Издательства", "3.2.3");
            PrintStats(books, b => b.Year.ToString(), "Годы издания", "3.2.4");

            PrintMaxCountGroup(books, b => b.Author, "Авторы с макс. кол-вом книг", "3.2.5");
            PrintMaxCountGroup(books, b => b.Publisher, "Издательства с макс. кол-вом книг", "3.2.6");
            PrintMaxCountGroup(books, b => b.Title, "Книги, встречающиеся чаще всего", "3.2.7");
            PrintMaxCountGroup(books, b => b.Year.ToString(), "Годы, в которые издано больше всего книг", "3.2.8");

            var maxBooksAuthors = books.GroupBy(b => b.Author).OrderByDescending(g => g.Count()).First().Key;
            var publishers = books.Where(b => b.Author == maxBooksAuthors).Select(b => b.Publisher).Distinct();
            Console.WriteLine("3.2.9 Издательства, выпустившие книги авторов-лидеров:");
            foreach (var pub in publishers) Console.WriteLine(pub);

            int topYear = books.GroupBy(b => b.Year).OrderByDescending(g => g.Count()).First().Key;
            var authorsInTopYear = books.Where(b => b.Year == topYear).Select(b => b.Author).Distinct();
            Console.WriteLine("3.2.10 Авторы, публиковавшиеся в самый активный год:");
            foreach (var a in authorsInTopYear) Console.WriteLine(a);

            // === Car Owners ===
            var cars = File.ReadAllLines("cars.txt")
                .Select(l => l.Split(','))
                .Select(p => new CarOwner(p[0].Trim(), p[1].Trim(), int.Parse(p[2].Trim()), p[3].Trim()))
                .ToList();

            PrintStats(cars, c => c.Owner, "Владельцы", "3.3.1");
            PrintStats(cars, c => c.Brand, "Марки авто", "3.3.2");
            PrintStats(cars, c => c.Country, "Страны производители", "3.3.3");
            PrintStats(cars, c => c.Year.ToString(), "Годы выпуска", "3.3.4");

            PrintMaxCountGroup(cars, c => c.Owner, "Владельцы с макс. числом авто", "3.3.5");
            PrintMaxCountGroup(cars, c => c.Country, "Страны с макс. числом авто", "3.3.6");
            PrintMaxCountGroup(cars, c => c.Brand, "Марки, встречающиеся чаще всего", "3.3.7");
            PrintMaxCountGroup(cars, c => c.Year.ToString(), "Годы с макс. числом авто", "3.3.8");

            var topBrand = cars.GroupBy(c => c.Brand).OrderByDescending(g => g.Count()).First().Key;
            var topCountries = cars.Where(c => c.Brand == topBrand).Select(c => c.Country).Distinct();
            Console.WriteLine("3.3.9 Страны, выпустившие наиболее популярные марки:");
            foreach (var c in topCountries) Console.WriteLine(c);

            var topCarYear = cars.GroupBy(c => c.Year).OrderByDescending(g => g.Count()).First().Key;
            var brandsInTopYear = cars.Where(c => c.Year == topCarYear).Select(c => c.Brand).Distinct();
            Console.WriteLine("3.3.10 Марки, выпущенные в самые продуктивные годы:");
            foreach (var b in brandsInTopYear) Console.WriteLine(b);
        }

        static void PrintStats<T>(List<T> data, Func<T, string> selector, string label, string code)
        {
            Console.WriteLine($"{code} {label}:");
            foreach (var g in data.GroupBy(selector).OrderBy(g => g.Key))
                Console.WriteLine($"{g.Key}: {g.Count()}");
        }

        static void PrintMaxCountGroup<T>(List<T> data, Func<T, string> selector, string label, string code)
        {
            Console.WriteLine($"{code} {label}:");
            var grouped = data.GroupBy(selector);
            int max = grouped.Max(g => g.Count());
            foreach (var g in grouped.Where(g => g.Count() == max))
                Console.WriteLine($"{g.Key}: {g.Count()}");
        }
    }
}