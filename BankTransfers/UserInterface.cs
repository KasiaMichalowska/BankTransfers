using System;

namespace BankTransfers
{
    public class UserInterface
    {
        public void DisplaynMenu()
        {
            Console.WriteLine(" Bank Transfers App - Menu: ");
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
    }
}