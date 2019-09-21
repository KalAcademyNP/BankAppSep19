using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instance of an account == object
            var account = new Account
            {
                EmailAddress = "test@test.com",
                AccountType = "Checking"
            };

            account.Deposit(2034.56M);

            Console.WriteLine($"AN: {account.AccountNumber}, " +
                $"Balance: {account.Balance:C}, " +
                $"AT: {account.AccountType}, " +
                $"EA:{account.EmailAddress}, " +
                $"CD: {account.CreatedDate}");

            var account2 = new Account();
            Console.WriteLine($"AN: {account2.AccountNumber}, " +
                $"Balance: {account2.Balance}, " +
                $"AT: {account2.AccountType}, " +
                $"EA:{account2.EmailAddress}, " +
                $"CD: {account2.CreatedDate}");

        }
    }
}
