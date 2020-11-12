using System;
using System.Collections.Generic;
using System.Globalization;

namespace BankTransfers
{
    public class Transfer
    {
        public bool _domestic;
        private Guid _sourceAccountNumberGuid;
        private Guid _destinationAccountNumberGuid;
        public string _transferTitle;
        public decimal _transferAmount;
        public DateTime _transferDate;

        public void PerformDomesticTransfer(BankAccount source, BankAccount destination, string transferTitle, decimal transferAmount, DateTime transferDate)
        {
            _domestic = true;
            _sourceAccountNumberGuid = source.AccountNumber;
            _destinationAccountNumberGuid = destination.AccountNumber;
            _transferTitle = transferTitle;
            _transferAmount = transferAmount;
            _transferDate = transferDate;

            source.AccountBalance -= transferAmount;
            destination.AccountBalance += transferAmount;
        }

       // public static DateTime Now { get; }
      
    }
}