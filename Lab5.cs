using System;

namespace LabyCSharp
{
    // 1. Реализация класса BankAccount
    public class BankAccount
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public bool IsActive { get; private set; }

        public BankAccount()
        {
            IsActive = false;
            Balance = 0;
        }

        public void OpenAccount(string accountNumber, decimal initialDeposit)
        {
            if (initialDeposit < 0)
                throw new ArgumentException("Начальный вклад не может быть отрицательным.");

            AccountNumber = accountNumber;
            Balance = initialDeposit;
            IsActive = true;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма депозита должна быть положительной.");
            if (!IsActive)
                throw new InvalidOperationException("Счет закрыт.");

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма снятия должна быть положительной.");
            if (!IsActive)
                throw new InvalidOperationException("Счет закрыт.");
            if (Balance < amount)
                throw new InvalidOperationException("Недостаточно средств.");

            Balance -= amount;
        }

        public void CloseAccount()
        {
            if (!IsActive)
                throw new InvalidOperationException("Счет уже закрыт.");

            IsActive = false;
        }
    }

    // 2. Создание тестового проекта (в рамках класса Lab5)
    public class BankAccountTests
    {
        public void TestOpenAccount_Successful()
        {
            var account = new BankAccount();
            account.OpenAccount("12345", 100);
            Console.WriteLine("Тест 1: Открытие счета успешно.");
            Console.WriteLine($"Номер счета: {account.AccountNumber}, Баланс: {account.Balance}, Статус: {account.IsActive}");
        }

        public void TestOpenAccount_NegativeDeposit_ThrowsArgumentException()
        {
            var account = new BankAccount();
            try
            {
                account.OpenAccount("12345", -100);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Тест 2: Открытие счета с отрицательным вкладом.");
                Console.WriteLine(e.Message); // Ожидается: "Начальный вклад не может быть отрицательным."
            }
        }

        public void TestDeposit_Successful()
        {
            var account = new BankAccount();
            account.OpenAccount("12345", 100);
            account.Deposit(50);
            Console.WriteLine("Тест 3: Пополнение счета успешно.");
            Console.WriteLine($"Баланс после пополнения: {account.Balance}");
        }

        public void TestDeposit_NegativeAmount_ThrowsArgumentException()
        {
            var account = new BankAccount();
            account.OpenAccount("12345", 100);
            try
            {
                account.Deposit(-50);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Тест 4: Пополнение счета отрицательной суммой.");
                Console.WriteLine(e.Message); // Ожидается: "Сумма депозита должна быть положительной."
            }
        }

        public void TestDeposit_ClosedAccount_ThrowsInvalidOperationException()
        {
            var account = new BankAccount();
            account.OpenAccount("12345", 100);
            account.CloseAccount();
            try
            {
                account.Deposit(50);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Тест 5: Пополнение закрытого счета.");
                Console.WriteLine(e.Message); // Ожидается: "Счет закрыт."
            }
        }

        public void TestWithdraw_Successful()
        {
            var account = new BankAccount();
            account.OpenAccount("12345", 100);
            account.Withdraw(50);
            Console.WriteLine("Тест 6: Снятие со счета успешно.");
            Console.WriteLine($"Баланс после снятия: {account.Balance}");
        }

        public void TestWithdraw_NegativeAmount_ThrowsArgumentException()
        {
            var account = new BankAccount();
            account.OpenAccount("12345", 100);
            try
            {
                account.Withdraw(-50);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Тест 7: Снятие отрицательной суммы.");
                Console.WriteLine(e.Message); // Ожидается: "Сумма снятия должна быть положительной."
            }
        }

        public void TestWithdraw_InsufficientFunds_ThrowsInvalidOperationException()
        {
            var account = new BankAccount();
            account.OpenAccount("12345", 100);
            try
            {
                account.Withdraw(150);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Тест 8: Снятие суммы, превышающей баланс.");
                Console.WriteLine(e.Message); // Ожидается: "Недостаточно средств."
            }
        }

        public void TestWithdraw_ClosedAccount_ThrowsInvalidOperationException()
        {
            var account = new BankAccount();
            account.OpenAccount("12345", 100);
            account.CloseAccount();
            try
            {
                account.Withdraw(50);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Тест 9: Снятие с закрытого счета.");
                Console.WriteLine(e.Message); // Ожидается: "Счет закрыт."
            }
        }

        public void TestCloseAccount_Successful()
        {
            var account = new BankAccount();
            account.OpenAccount("12345", 100);
            account.CloseAccount();
            Console.WriteLine("Тест 10: Закрытие счета успешно.");
            Console.WriteLine($"Статус счета после закрытия: {account.IsActive}");
        }

        public void TestCloseAccount_AlreadyClosed_ThrowsInvalidOperationException()
        {
            var account = new BankAccount();
            account.OpenAccount("12345", 100);
            account.CloseAccount();
            try
            {
                account.CloseAccount();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Тест 11: Попытка закрыть уже закрытый счет.");
                Console.WriteLine(e.Message); // Ожидается: "Счет уже закрыт."
            }
        }
    }

    // 3. Запуск тестов
    public class Lab5
    {
        public static void Run()
        {
            Console.WriteLine("Лабораторная работа 5 выполняется...");
            var tests = new BankAccountTests();
            tests.TestOpenAccount_Successful();
            tests.TestOpenAccount_NegativeDeposit_ThrowsArgumentException();
            tests.TestDeposit_Successful();
            tests.TestDeposit_NegativeAmount_ThrowsArgumentException();
            tests.TestDeposit_ClosedAccount_ThrowsInvalidOperationException();
            tests.TestWithdraw_Successful();
            tests.TestWithdraw_NegativeAmount_ThrowsArgumentException();
            tests.TestWithdraw_InsufficientFunds_ThrowsInvalidOperationException();
            tests.TestWithdraw_ClosedAccount_ThrowsInvalidOperationException();
            tests.TestCloseAccount_Successful();
            tests.TestCloseAccount_AlreadyClosed_ThrowsInvalidOperationException();
        }
    }
}
