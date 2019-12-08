using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace BankUI.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        public string Username { get; set; }
        // GET: Accounts
        public IActionResult Index()
        {
            if (HttpContext != null && 
                !string.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                Username = HttpContext.User.Identity.Name;
            }
            return View(Bank.GetAllAccountsByEmailAddress(Username));
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.GetAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("EmailAddress,AccountName,AccountType")]
            Account account)
        {
            if (ModelState.IsValid)
            {
                Bank.CreateAccount(account.AccountName,
                    account.EmailAddress,
                    account.AccountType);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.GetAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
            [Bind("EmailAddress,AccountNumber,AccountName,AccountType")]
            Account account)
        {
            if (id != account.AccountNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Bank.UpdateAccount(account);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        //Get
        public IActionResult Deposit(int? id)
        {
            if (id == null)
                return NotFound();

            var account = Bank.GetAccountByAccountNumber(id.Value);
            if (account == null)
                return NotFound();

            return View(account);
        }

        [HttpPost]
        public IActionResult Deposit(IFormCollection controls)
        {
            var accountNumber = 
                Convert.ToInt32(controls["AccountNumber"]);

            var amount = Convert.ToDecimal(controls["Amount"]);
            Bank.Deposit(accountNumber, amount);

            return RedirectToAction(nameof(Index));
        }

        //Get
        public IActionResult Withdraw(int? id)
        {
            if (id == null)
                return NotFound();

            var account = Bank.GetAccountByAccountNumber(id.Value);
            if (account == null)
                return NotFound();

            return View(account);
        }

        [HttpPost]
        public IActionResult Withdraw(IFormCollection controls)
        {
            var accountNumber =
                Convert.ToInt32(controls["AccountNumber"]);

            var amount = Convert.ToDecimal(controls["Amount"]);
            Bank.Withdraw(accountNumber, amount);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Transactions(int? id)
        {
            if (id == null)
                return NotFound();

            var transactions = 
                Bank.GetAllTransactionsByAccountNumber(id.Value);

            return View(transactions);
        }

    }
}
