using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp
{
    static class Bank
    {
        private static List<Account> accounts = new List<Account>();
        public static Account CreateAccount(
            string emailAddress, 
            TypeOfAccounts accountType,
            decimal initialDeposit)
        {
            var account = new Account
            {
                EmailAddress = emailAddress,
                AccountType = accountType
            };

            if(initialDeposit > 0)
            {
                account.Deposit(initialDeposit);
            }
            accounts.Add(account);
            return account;
        }

        public static IEnumerable<Account> 
            GetAllAccountsByEmailAddress(string emailAddress)
        {
            return accounts.Where(a => a.EmailAddress == emailAddress);
        }
    }
}
