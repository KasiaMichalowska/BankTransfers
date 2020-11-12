using System.Collections.Generic;

namespace BankTransfers
{
    public class Bank
    {
        private List<BankAccount> _accounts;

        public Bank()
        {
            _accounts = new List<BankAccount>();
        }

        public BankAccount CreateAccount(string accountName)
        {
            BankAccount newAccount = new BankAccount(accountName);
            _accounts.Add(newAccount);
            
            return newAccount;
        }

        public List<BankAccount> GetAccount()
        {
            return _accounts;
        }

        public BankAccount GetBankAccount(int index)
        {
            if (index >= 0 && index < _accounts.Count)
            {
                return _accounts[index];
            }

            return null;
        }
    }
}