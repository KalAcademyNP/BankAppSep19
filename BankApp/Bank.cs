using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp
{
    public static class Bank
    {
        private static BankContext db = new BankContext();
        public static Account CreateAccount(
            string accountName,
            string emailAddress, 
            TypeOfAccounts accountType = TypeOfAccounts.Checking,
            decimal initialDeposit=0)
        {
            var account = new Account
            {
                AccountName = accountName,
                EmailAddress = emailAddress,
                AccountType = accountType
            };

            if(initialDeposit > 0)
            {
                account.Deposit(initialDeposit);
            }
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public static Account 
            GetAccountByAccountNumber(int accountNumber)
        {
            return db.Accounts.Find(accountNumber);
        }

        public static void UpdateAccount(Account updatedAccount)
        {
            var oldAccount = GetAccountByAccountNumber(
                updatedAccount.AccountNumber);
            oldAccount.EmailAddress = updatedAccount.EmailAddress;
            oldAccount.AccountName = updatedAccount.AccountName;
            oldAccount.AccountType = updatedAccount.AccountType;

            db.SaveChanges();

        }

        public static IEnumerable<Account> 
            GetAllAccountsByEmailAddress(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress) 
                || string.IsNullOrWhiteSpace(emailAddress))
            {
                throw new ArgumentNullException("emailAddress", "Email Address is required!");
            }
            return db.Accounts.Where(a => a.EmailAddress == emailAddress);
        }

        public static IEnumerable<Transaction>
    GetAllTransactionsByAccountNumber(int accountNumber)
        {
            return db.Transactions
                .Where(t => t.AccountNumber == accountNumber)
                .OrderByDescending(t => t.TransactionDate);
        }

        public static void Deposit(int accountNumber, 
            decimal amount)
        {
            var account = 
                db.Accounts.SingleOrDefault(
                    a => a.AccountNumber == accountNumber);

            if (account == null)
            {
                //Throw exception
                return;
            }

            account.Deposit(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                Amount = amount,
                TransactionType = TypeOfTransaction.Credit,
                Description = "Bank deposit",
                Balance = account.Balance,
                AccountNumber = accountNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public static void Withdraw(int accountNumber,
    decimal amount)
        {
            var account =
                db.Accounts.SingleOrDefault(
                    a => a.AccountNumber == accountNumber);

            if (account == null)
            {
                //Throw exception
                return;
            }

            account.Withdraw(amount);
            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                Amount = amount,
                TransactionType = TypeOfTransaction.Debit,
                Description = "Bank withdrawal",
                Balance = account.Balance,
                AccountNumber = accountNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();

        }

    }
}
