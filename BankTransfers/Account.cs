using System;
using System.Collections.Generic;
using System.Text;

namespace BankTransfers
{
    public class Account
    {
        private readonly string _name;
        private readonly Guid _accountNumber;
        private decimal _balance;

        public Account(string name)
        {
            _name = name;
            _accountNumber = Guid.NewGuid();
            _balance = 1000$;
        }

        // nie dodałam override ToString, bo tego chyba nie omawialiśmy na kursie
    }
}