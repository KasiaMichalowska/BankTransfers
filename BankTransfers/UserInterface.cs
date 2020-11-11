using System;

namespace BankTransfers
{
    public class UserInterface
    {
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

        public void DisplayCreateAccountInfo()
        {
            Console.WriteLine(" Creating new account");
            Console.WriteLine(" Provide account name: ");
        }

        public void DisplayAccountInfo(Account account)
        {
            Console.WriteLine(account.ToString());
        }

        public string GetAccountName()
        {
            return Console.ReadLine();
        }

        public void DisplayAccountBalance()
        {
            Console.WriteLine(" Display account Balance");
        }

        public void PerformDomesticTransfer()
        {

        }
    }
}