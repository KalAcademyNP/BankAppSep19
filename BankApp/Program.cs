using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instance of an account == object
            var account = Bank.CreateAccount("test@test.com", 
                TypeOfAccounts.Checking, 245);

            Console.WriteLine($"AN: {account.AccountNumber}, " +
                $"Balance: {account.Balance:C}, " +
                $"AT: {account.AccountType}, " +
                $"EA:{account.EmailAddress}, " +
                $"CD: {account.CreatedDate}");

            var account2 = Bank.CreateAccount("test1@test.com",
                TypeOfAccounts.Savings, 0);
            Console.WriteLine($"AN: {account2.AccountNumber}, " +
                $"Balance: {account2.Balance}, " +
                $"AT: {account2.AccountType}, " +
                $"EA:{account2.EmailAddress}, " +
                $"CD: {account2.CreatedDate}");

        }
    }
}
