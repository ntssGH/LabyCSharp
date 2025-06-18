using System;
using System.Collections.Concurrent;
using System.Threading;

namespace LabyCSharp
{
    // Простая сущность для демонстрации
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // Потоко-безопасный кэш для любых типов сущностей
    public class Cache<T, TKey>
    {
        private static readonly Lazy<Cache<T, TKey>> _instance =
            new Lazy<Cache<T, TKey>>(() => new Cache<T, TKey>());

        private readonly ConcurrentDictionary<TKey, Lazy<T>> _store;

        private Cache()
        {
            _store = new ConcurrentDictionary<TKey, Lazy<T>>();
        }

        public static Cache<T, TKey> Instance => _instance.Value;

        public T Get(TKey key, Func<TKey, T> loader)
        {
            // Lazy гарантирует, что loader выполнится только один раз для данного ключа
            var lazyResult = _store.GetOrAdd(
                key,
                k => new Lazy<T>(() => loader(k), LazyThreadSafetyMode.ExecutionAndPublication)
            );

            return lazyResult.Value;
        }
    }

    public class Lab72_73
    {
        public static void Run()
        {
            // Симуляция метода загрузки из "базы данных"
            User FetchUserFromDb(int id)
            {
                Console.WriteLine($"[DB] Загрузка пользователя с Id = {id}");
                // Здесь мог бы быть реальный запрос к БД
                Thread.Sleep(100); // эмуляция задержки
                return new User { Id = id, Name = $"User_{id}" };
            }

            Console.WriteLine("=== Демонстрация кэширования пользователей ===");

            // Первый запрос — пойдёт в «БД»
            var user1 = Cache<User, int>.Instance.Get(1, FetchUserFromDb);
            Console.WriteLine($"Получили: Id={user1.Id}, Name={user1.Name}");

            // Второй раз тот же ключ — из кэша (без вывода [DB])
            var user2 = Cache<User, int>.Instance.Get(1, FetchUserFromDb);
            Console.WriteLine($"Получили: Id={user2.Id}, Name={user2.Name}");

            // Запрос другого пользователя — снова в «БД»
            var user3 = Cache<User, int>.Instance.Get(2, FetchUserFromDb);
            Console.WriteLine($"Получили: Id={user3.Id}, Name={user3.Name}");
        }
    }
}
