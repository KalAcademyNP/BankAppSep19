﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    /// <summary>
    /// This is a bank account
    /// where a user can deposit 
    /// and withdraw money from it
    /// </summary>
    class Account
    {
        private static int lastAccountNumber = 0;

        #region Properties
        /// <summary>
        /// Email Address of the account
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Autogenerated Account number 
        /// for the account
        /// </summary>
        public int AccountNumber { get; }

        public string AccountType { get; set; }
        public decimal Balance { get; private set; }

        public DateTime CreatedDate { get; private set; }
        #endregion

        #region Constructor
        public Account()
        {
            AccountNumber = ++lastAccountNumber;
            CreatedDate = DateTime.Now;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Deposit money into the account
        /// </summary>
        /// <param name="amount">Amount to deposit</param>
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
        #endregion
    }
}