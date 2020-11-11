using System;

namespace BankTransfers
{
    class BankAccount
    {
        public string AccountName;
        private Guid AccountNumber;
        public decimal AccountBalance;

        public BankAccount(string accountName, Guid accountNumber, decimal accountBalance)

        {
            AccountName = accountName;
            AccountNumber = accountNumber;
            AccountBalance = accountBalance;

            // Guid g = Guid.NewGuid();
        }
    }
}