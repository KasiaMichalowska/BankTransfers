using System;
using System.Collections.Generic;

namespace BankTransfers
{
    public class UserInterface
    {
        #region Formatting
        private void WritePrompt(string prompt)
        {
            Console.Write($"\n---- {prompt}: ");
        }

        private void WriteLine(string line)
        {
            Console.WriteLine($"  {line}");
        }

        private void WriteError(string error)
        {
            Console.WriteLine($"\n{error}\n");
        }

        private int ReadIntegerValue(string prompt)
        {
            int userChoice;
            WritePrompt(prompt);
            while (!int.TryParse(Console.ReadLine(), out userChoice))
            {
                WriteError("Incorrect option - try again...");
                WritePrompt(prompt);
            }

            return userChoice;
        }

        private decimal ReadDecimalValue(string prompt)
        {
            decimal userValue;
            WritePrompt(prompt);
            while (!decimal.TryParse(Console.ReadLine(), out userValue))
            {
                WriteError("Incorrect decimal value - try again...");
                WritePrompt(prompt);
            }

            return userValue;
        }

        private string ReadStringValue(string prompt, bool allowEmpty = true)
        {
            WritePrompt(prompt);
            var userValue = Console.ReadLine();
            if (!allowEmpty)
            {
                while (userValue != null && userValue.Trim().Length == 0)
                {
                    WriteError("Provided value cannot be empty");
                    WritePrompt(prompt);
                }
            }

            return userValue;
        }
        #endregion

        #region DisplayMenu
        public void DisplayMenu()
        {
            // implementacja po nazwie jest bardziej uciążliwa w obsłudze (wymaga wpisywania nazwy opcji menu zamiast numerka)
            Console.WriteLine(" Bank Transfer App - Menu: ");
            Console.WriteLine(" 1. Create account");
            Console.WriteLine(" 2. Domestic transfer");
            Console.WriteLine(" 3. Outgoing transfer");
            Console.WriteLine(" 4. Accounts balance");
            Console.WriteLine(" 5. Transfers history");
            Console.WriteLine(" 6. Exit");
        }

        public int ReadMenu()
        {
            Console.WriteLine(" Choose option");
            int userChoice;

            while (!int.TryParse(Console.ReadLine(), out userChoice))
            {
                Console.WriteLine("Incorrect option - try again...");
            }
            return userChoice;
        }

        #endregion

        #region CreateAccount

        public void DisplayCreateAccountInfo()
        {
            Console.WriteLine(" Creating new account");
            Console.WriteLine(" Provide account name: ");
        }

        public void DisplayAccountInfo(BankAccount account)
        {
            Console.WriteLine(account.ToString());
        }

        public string GetAccountName()
        {
            return Console.ReadLine();
        }

        #endregion

        #region Transfer
        public void DisplayDomesticTransferStart(List<BankAccount> account)
        {
            Console.WriteLine("Domestic Transfer");
            int position = 1;
            foreach (var bankaccount in account)
            {
                Console.WriteLine($"{position}.{bankaccount.Name}\t{bankaccount.AccountNumber}\tBalance: ${bankaccount.AccountBalance}");
            }
        }

        public int GetSourceAccountIndex()
        {
            int accountIndex = ReadIntegerValue("Provide source account");
            accountIndex--;
            return accountIndex;
        }

        public int GetDestinationAccountIndex()
        {
            int accountIndex = ReadIntegerValue("Provide destination account");
            accountIndex--;
            return accountIndex;
        }
        public String GetTransferTitle()
        {
            return ReadStringValue("Provide transfer title");
        }

        public decimal GetTransferAmount()
        {
            return ReadDecimalValue("Provide transfer amount");
        }


        public void DisplayAccountBalance()
        {
            Console.WriteLine(" Display account Balance");
        }

        public void DisplayDomesticTransferSummary(Transfer transfer)
        {
            WriteLine("Transfer successful");
            WriteLine(transfer.ToString());
        }

        #endregion

        #region errorsHandling

        public void DisplayLessThan2AccountDomesticError()
        {
            WriteError("There are less than 2 domestic accounts, cannot perform a domestic transfer.");
        }

        public void DisplayIncorrectDomesticAccountError()
        {
            WriteError("Source or destination account is invalid, cannot perform a domestic transfer.");
        }

        public void DisplayTransferToTheSameDomesticAccountError()
        {
            WriteError("Source and destination account is the same, cannot do a domestic transfer");
        }

        public void Display0OrLessTransferAmountError()
        {
            WriteError("$0 or less cannot be transferred");
        }

        public void DisplayGreaterThanSourceBalanceError()
        {
            WriteError("Amount greater than source account balance cannot be transferred");
        }

        #endregion
    }
}