using System;
using System.Threading;
using Microsoft.Extensions.Caching.Memory;

namespace LabyCSharp
{
    public class Lab74_75
    {
        public static void Run()
        {
            Console.WriteLine("=== Вариант 3: Кэширование с помощью Microsoft.Extensions.Caching.Memory ===");

            // Локальный метод-лоадер для демонстрации «дорогой» операции
            string FetchData(string key)
            {
                Console.WriteLine($"[SOURCE] Загружаем данные по ключу «{key}»...");
                Thread.Sleep(100); // эмуляция задержки
                return $"Value_for_{key}";
            }

            // Создаём MemoryCache (необходимо добавить в проект через NuGet: Microsoft.Extensions.Caching.Memory)
            var cache = new MemoryCache(new MemoryCacheOptions());

            // Обёртка для получения из кэша или загрузки
            string GetFromCache(string key)
            {
                if (cache.TryGetValue(key, out string cachedValue))
                {
                    Console.WriteLine($"[CACHE] Данные для «{key}» получены из кэша.");
                    return cachedValue;
                }

                // При промахе — грузим и кладём в кэш
                var value = FetchData(key);

                // Опции кэширования с абсолютным временем жизни 30 секунд
                var options = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                };

                cache.Set(key, value, options);
                Console.WriteLine($"[CACHE] Данные для «{key}» сохранены в кэше на 30 секунд.");
                return value;
            }

            // Демонстрация
            var a1 = GetFromCache("A");
            Console.WriteLine($"Результат A1: {a1}\n");

            var a2 = GetFromCache("A");
            Console.WriteLine($"Результат A2: {a2}\n");

            var b1 = GetFromCache("B");
            Console.WriteLine($"Результат B1: {b1}\n");
        }
    }
}
