using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    static class Bank
    {
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

            return account;
        }
    }
}
