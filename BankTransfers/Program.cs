using System;
using VisioForge.Shared.MediaFoundation.OPM;

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
            _userInterface = new UserInterface();
            _bank = new Bank();
       
            do
            {
                _userInterface.DisplaynMenu();
                var selectedMenuOption = _userInterface.ReadMenu();

                switch (selectedMenuOption)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 6:
                        Environment.Exit(0);
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
    }
}