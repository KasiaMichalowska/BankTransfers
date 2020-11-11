using System;

namespace BankTransfers
{
    class Program
    {
        public static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        private Bank _bank;
        private UserInterface _userInterface;

        private void Run()
        {
            _bank = new Bank();
            _userInterface = new UserInterface();

            do
            {
                _userInterface.DisplayMenu();
                var selectedMenuOption = _userInterface.ReadMenu();

                switch (selectedMenuOption)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Unknown menu option");
                        break;
                }
            } while (true);
        }

        private void CreateAccount()
        {
            _userInterface.DisplayCreateAccountInfo();            
            var accountName = _userInterface.GetAccountName();
            var account = _bank.CreateAccount(accountName);
            _userInterface.DisplayAccountInfo(account);
        }

        private void AccountBalance()
        {
            _userInterface.DisplayAccountBalance();
        }

    }
}