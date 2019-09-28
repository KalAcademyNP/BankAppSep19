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
