using System;

namespace BankTransfers
{
    class BankAccount
    {
        /* 
            1. logika tworzenia konta bankowego, po utworzeniu zapisywane jest w pamięci aplikacji 
            2. logika powinna być dostępna pod odpowiednią pozycją w menu - nazwą pozycji ?
            3. Konto powinno zawierać następujące dane:
            - nazwę,
            - numer (GUID)
            - saldo (po utworzeniu konto automatycznie powinno posiadać 1000$)
            */

        public BankAccount(string accountName, uint accountNumber, uint accountBalance)
        {
            AccountName = accountName;
            AccountNumber = accountNumber;

            Guid g = Guid.NewGuid();
            Console.WriteLine(g);
        }
    }
}
