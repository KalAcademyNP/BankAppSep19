using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********Welcome to my bank!******");

            while(true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Print all accounts");
                Console.WriteLine("5. Print all transactions");

                var option = Console.ReadLine();
                switch(option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting my bank!");
                        return;
                    case "1":
                        Console.Write("Email Address: ");
                        var email = Console.ReadLine();

                        Console.Write("Account Name: ");
                        var accountName = Console.ReadLine();

                        Console.WriteLine("Account type: ");
                        //Convert enum to array
                        var accountTypes = 
                            Enum.GetNames(typeof(TypeOfAccounts));
                        //Loop through the array and print out
                        for(var i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}. {accountTypes[i]}");
                        }
                        var accountType = Enum.Parse<TypeOfAccounts>(Console.ReadLine());
                        Console.Write("Initial Deposit: ");
                        var amount = Convert.ToDecimal(Console.ReadLine());
                        var account = Bank.CreateAccount(accountName, email, accountType, amount);
                        Console.WriteLine($"AN: {account.AccountNumber}, CD: {account.CreatedDate}, AT: {account.AccountType}, B: {account.Balance:C}, EA: {account.EmailAddress}");
                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Account number: ");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to deposit: ");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNumber, amount);

                        Console.WriteLine("Deposit completed successfuly!");

                        break;
                    case "3":
                        PrintAllAccounts();
                        Console.Write("Account number: ");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to withdraw: ");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Withdraw(accountNumber, amount);

                        Console.WriteLine("Withdrawal completed successfuly!");
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;

                    case "5":
                        PrintAllAccounts();
                        Console.Write("Account number: ");
                        accountNumber = Convert.ToInt32(Console.ReadLine());

                        var transactions =
                            Bank.GetAllTransactionsByAccountNumber(accountNumber);
                        foreach (var transaction in transactions)
                        {
                            Console.WriteLine($"ID: {transaction.Id}, Date: {transaction.TransactionDate}, TT: {transaction.TransactionType}, Amount: {transaction.Amount:C}, AN: {transaction.AccountNumber}, B: {transaction.Balance:C}");
                        }
                        break;
                    default:
                        Console.WriteLine("Please select a valid option!");
                        break;
                }
            }


        }

        private static void PrintAllAccounts()
        {
            Console.Write("Email Address: ");
            var emailAddress = Console.ReadLine();
            var accounts =
                Bank.GetAllAccountsByEmailAddress(emailAddress);
            foreach (var myAccount in accounts)
            {
                Console.WriteLine($"AN: {myAccount.AccountNumber}, CD: {myAccount.CreatedDate}, AT: {myAccount.AccountType}, B: {myAccount.Balance:C}, EA: {myAccount.EmailAddress}");
            }
        }
    }
}
