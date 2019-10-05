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

                var option = Console.ReadLine();
                switch(option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting my bank!");
                        return;
                    case "1":
                        Console.Write("Email Address: ");
                        var email = Console.ReadLine();
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

                        var account = Bank.CreateAccount(email, accountType, amount);
                        Console.WriteLine($"AN: {account.AccountNumber}, CD: {account.CreatedDate}, AT: {account.AccountType}, B: {account.Balance:C}, EA: {account.EmailAddress}");
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Please select a valid option!");
                        break;
                }
            }


        }
    }
}
