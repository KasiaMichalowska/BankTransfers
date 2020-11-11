using System;
using System.Globalization;

namespace BankTransfers
{
    public class Transfer
    {
        public bool _domestic;
        private Guid _sourceAccountNumber;
        private Guid _destinationAccountNumber;
        public string _transferTitle;
        public decimal _transferAmount;
        public DateTime _transferDate;

        public void PerformDomesticTransfer(Account sourceAccountNumber, Account destinationAccountNumber, string transferTitle, decimal transferAmount, DateTime transferDate)
        {
            _domestic = true;
            _sourceAccountNumber = sourceAccountNumber;
            _destinationAccountNumber = destinationAccountNumber;
            _transferTitle = transferTitle;
            _transferAmount = transferAmount;
            _transferDate = transferDate;
        }

        public static DateTime Now { get; }

    }
}