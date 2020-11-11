using System.Collections.Generic;

namespace BankTransfers
{
    public class Bank
    {
        private List<Account> _accounts;

        public Bank()
        {
            _accounts = new List<Account>();
        }

        public Account CreateAccount(string accountName)
        {
            Account newAccount = new Account(accountName);
            _accounts.Add(newAccount);
            
            return newAccount;
        }
    }
}