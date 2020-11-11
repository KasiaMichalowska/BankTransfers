using System;

namespace BankTransfers
{
    public class Account
    {
        private string _accountName;
        private Guid _accountNumber;
        private decimal _accountBalance;

        public Account(string name)
        {
            _accountName = name;
            _accountNumber = Guid.NewGuid();
            _accountBalance = 1000;
        }
 
        public override string ToString()
        {
            return $"   Account: {_accountName}\n" +
                   $"   Account No: {_accountNumber}\n" +
                   $"   Balance: ${_accountBalance}";
        }

        public static implicit operator Guid(Account v)
        {
            throw new NotImplementedException();
        }
    }
}