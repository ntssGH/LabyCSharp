using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LabyCSharp.Lab40_41;

public class Student
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Patronymic { get; set; }
    public string Group { get; set; }
    public int Score { get; set; }
}

public class Book
{
    public string Author { get; set; }
    public string Title { get; set; }
    public string Publisher { get; set; }
    public int Year { get; set; }
}

public class Car
{
    public string Owner { get; set; }
    public string Brand { get; set; }
    public int Year { get; set; }
    public string Country { get; set; }
}

public class Lab40_41
{
    public static void Run()
    {
        Console.WriteLine("Лабораторная работа 40-41 выполняется...");
        using (StreamWriter writer = new StreamWriter("40_41output.txt"))
        {
            // Считываем студентов из файла
            List<Student> students = File.ReadAllLines("students.txt")
                .Select(line => line.Split(','))
                .Select(parts => new Student
                {
                    LastName = parts[0],
                    FirstName = parts[1],
                    Patronymic = parts[2],
                    Group = parts[3],
                    Score = int.Parse(parts[4])
                }).ToList();

            // Подсчёт количества студентов по фамилиям, именам, отчества и т.д.
            var lastNamesCount = students.GroupBy(s => s.LastName)
                .ToDictionary(g => g.Key, g => g.Count());
            var firstNamesCount = students.GroupBy(s => s.FirstName)
                .ToDictionary(g => g.Key, g => g.Count());
            var patronymicsCount = students.GroupBy(s => s.Patronymic)
                .ToDictionary(g => g.Key, g => g.Count());
            var groupsCount = students.GroupBy(s => s.Group)
                .ToDictionary(g => g.Key, g => g.Count());
            var scoresCount = students.GroupBy(s => s.Score)
                .ToDictionary(g => g.Key, g => g.Count());

            // Запись в файл
            writer.WriteLine("3.1 Студенты:");

            // 3.1.6) Перечень имен, встречающихся максимальное количество раз
            var maxFirstNameCount = firstNamesCount.Values.Max();
            var maxFirstNames = firstNamesCount.Where(kv => kv.Value == maxFirstNameCount)
                                               .Select(kv => kv.Key);
            writer.WriteLine("\n3.1.6) Имена, встречающиеся максимальное количество раз:");
            foreach (var name in maxFirstNames)
            {
                writer.WriteLine(name);
            }

            // 3.1.7) Перечень групп с максимальным количеством студентов
            var maxGroupCount = groupsCount.Values.Max();
            var maxGroups = groupsCount.Where(kv => kv.Value == maxGroupCount)
                                       .Select(kv => kv.Key);
            writer.WriteLine("\n3.1.7) Группы с максимальным количеством студентов:");
            foreach (var group in maxGroups)
            {
                writer.WriteLine(group);
            }

            // 3.1.8) Перечень студентов, набравших максимальное количество баллов
            var maxScore = students.Max(s => s.Score);
            var topScorers = students.Where(s => s.Score == maxScore);
            writer.WriteLine("\n3.1.8) Студенты с максимальными баллами:");
            foreach (var student in topScorers)
            {
                writer.WriteLine($"{student.LastName} {student.FirstName} {student.Patronymic}: {student.Score}");
            }

            // 3.1.9) Перечень групп с максимальным количеством студентов, набравших максимальное количество баллов
            var groupTopScorers = topScorers.GroupBy(s => s.Group)
                .ToDictionary(g => g.Key, g => g.Count());
            var maxTopScorersInGroup = groupTopScorers.Values.DefaultIfEmpty(0).Max();
            var maxTopGroups = groupTopScorers.Where(g => g.Value == maxTopScorersInGroup)
                                              .Select(g => g.Key);
            writer.WriteLine("\n3.1.9) Группы с максимальным количеством студентов, набравших максимальные баллы:");
            foreach (var group in maxTopGroups)
            {
                writer.WriteLine(group);
            }

            // 3.1.10) Перечень групп, в которых максимальный средний балл
            var avgScoreByGroup = students.GroupBy(s => s.Group)
                .ToDictionary(g => g.Key, g => g.Average(s => s.Score));
            var maxAvgScore = avgScoreByGroup.Values.Max();
            var maxAvgGroups = avgScoreByGroup.Where(g => g.Value == maxAvgScore)
                                              .Select(g => g.Key);
            writer.WriteLine("\n3.1.10) Группы с максимальным средним баллом:");
            foreach (var group in maxAvgGroups)
            {
                writer.WriteLine(group);
            }

            // Считываем книги из файла
            List<Book> books = File.ReadAllLines("books.txt")
                .Select(line => line.Split(','))
                .Select(parts => new Book
                {
                    Author = parts[0],
                    Title = parts[1],
                    Publisher = parts[2],
                    Year = int.Parse(parts[3])
                }).ToList();

            // Подсчёт количества книг по авторам, названиям и т.д.
            var authorCounts = books.GroupBy(b => b.Author)
                .ToDictionary(g => g.Key, g => g.Count());
            var titleCounts = books.GroupBy(b => b.Title)
                .ToDictionary(g => g.Key, g => g.Count());
            var publisherCounts = books.GroupBy(b => b.Publisher)
                .ToDictionary(g => g.Key, g => g.Count());
            var yearCounts = books.GroupBy(b => b.Year)
                .ToDictionary(g => g.Key, g => g.Count());

            // Запись в файл
            writer.WriteLine("\n3.2 Книги:");

            // 3.2.5) Перечень авторов с максимальным количеством книг
            var maxAuthorCount = authorCounts.Values.Max();
            var maxAuthors = authorCounts.Where(kv => kv.Value == maxAuthorCount)
                                         .Select(kv => kv.Key);
            writer.WriteLine("\n3.2.5) Авторы с максимальным количеством книг:");
            foreach (var author in maxAuthors)
            {
                writer.WriteLine(author);
            }

            // 3.2.6) Перечень издательств с максимальным количеством книг
            var maxPublisherCount = publisherCounts.Values.Max();
            var maxPublishers = publisherCounts.Where(kv => kv.Value == maxPublisherCount)
                                               .Select(kv => kv.Key);
            writer.WriteLine("\n3.2.6) Издательства с максимальным количеством книг:");
            foreach (var publisher in maxPublishers)
            {
                writer.WriteLine(publisher);
            }

            // 3.2.7) Перечень наименований книг, встречающихся максимальное число раз
            var maxTitleCount = titleCounts.Values.Max();
            var maxTitles = titleCounts.Where(kv => kv.Value == maxTitleCount)
                                       .Select(kv => kv.Key);
            writer.WriteLine("\n3.2.7) Книги с максимальным количеством повторений:");
            foreach (var title in maxTitles)
            {
                writer.WriteLine(title);
            }

            // 3.2.8) Перечень годов издания, в которых было выпущено максимальное количество книг
            var maxYearCount = yearCounts.Values.Max();
            var maxYears = yearCounts.Where(kv => kv.Value == maxYearCount)
                                     .Select(kv => kv.Key);
            writer.WriteLine("\n3.2.8) Года издания с максимальным количеством книг:");
            foreach (var year in maxYears)
            {
                writer.WriteLine(year);
            }

            // Считываем данные о машинах
            List<Car> cars = File.ReadAllLines("cars.txt")
                .Select(line => line.Split(','))
                .Select(parts => new Car
                {
                    Owner = parts[0],
                    Brand = parts[1],
                    Year = int.Parse(parts[2]),
                    Country = parts[3]
                }).ToList();

            // Подсчёт количества машин по владельцам, маркам и т.д.
            var ownerCounts = cars.GroupBy(c => c.Owner)
                .ToDictionary(g => g.Key, g => g.Count());
            var brandCounts = cars.GroupBy(c => c.Brand)
                .ToDictionary(g => g.Key, g => g.Count());
            var countryCounts = cars.GroupBy(c => c.Country)
                .ToDictionary(g => g.Key, g => g.Count());
            var yearCarCounts = cars.GroupBy(c => c.Year)
                .ToDictionary(g => g.Key, g => g.Count());

            // Запись в файл
            writer.WriteLine("\n3.3 Машины:");

            // 3.3.5) Перечень владельцев с максимальным количеством машин
            var maxOwnerCount = ownerCounts.Values.Max();
            var maxOwners = ownerCounts.Where(kv => kv.Value == maxOwnerCount)
                                       .Select(kv => kv.Key);
            writer.WriteLine("\n3.3.5) Владельцы с максимальным количеством машин:");
            foreach (var owner in maxOwners)
            {
                writer.WriteLine(owner);
            }

            // 3.3.6) Перечень стран с максимальным количеством машин
            var maxCountryCount = countryCounts.Values.Max();
            var maxCountries = countryCounts.Where(kv => kv.Value == maxCountryCount)
                                            .Select(kv => kv.Key);
            writer.WriteLine("\n3.3.6) Страны с максимальным количеством машин:");
            foreach (var country in maxCountries)
            {
                writer.WriteLine(country);
            }

            // 3.3.7) Перечень марок машин, встречающихся максимальное количество раз
            var maxBrandCount = brandCounts.Values.Max();
            var maxBrands = brandCounts.Where(kv => kv.Value == maxBrandCount)
                                       .Select(kv => kv.Key);
            writer.WriteLine("\n3.3.7) Марки машин, встречающиеся максимальное количество раз:");
            foreach (var brand in maxBrands)
            {
                writer.WriteLine(brand);
            }

            // 3.3.8) Перечень годов выпуска машин, в которые было выпущено максимальное количество машин
            var maxCarYearCount = yearCarCounts.Values.Max();
            var maxCarYears = yearCarCounts.Where(kv => kv.Value == maxCarYearCount)
                                           .Select(kv => kv.Key);
            writer.WriteLine("\n3.3.8) Года выпуска машин с максимальным количеством машин:");
            foreach (var year in maxCarYears)
            {
                writer.WriteLine(year);
            }
            Console.WriteLine("Лабораторная работа 40-41 выполнена, результат в файле 40_41output.txt");
        }
    }
}
