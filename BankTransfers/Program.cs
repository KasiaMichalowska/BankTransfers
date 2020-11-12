using System;
using VisioForge.Shared.MediaFoundation.dxvahd;
using VisioForge.Types;

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

        private void DomesticTransfer()
        {
            if (_bank.GetAccount().Count <= 1)
            {
                _userInterface.DisplayLessThan2AccountDomesticError();
                return;
            }

            _userInterface.DisplayDomesticTransferStart(_bank.GetAccount());
            BankAccount source = _bank.GetBankAccount(_userInterface.GetSourceAccountIndex());
            BankAccount destination = _bank.GetBankAccount(_userInterface.GetDestinationAccountIndex());

            if (source == null || destination == null)
            {
                _userInterface.DisplayIncorrectDomesticAccountError();
                return;
            }

            if (source == destination)
            {
                _userInterface.DisplayTransferToTheSameDomesticAccountError();
                return;
            }

            string transferTitle = _userInterface.GetTransferTitle();
            decimal transferAmount = _userInterface.GetTransferAmount();

            if (transferAmount <= 0)
            {
                _userInterface.Display0OrLessTransferAmountError();
                return;
            }

            if (transferAmount > source.AccountBalance)
            {
                _userInterface.DisplayGreaterThanSourceBalanceError();
                return;
            }

            Transfer transfer = new Transfer();
            transfer.PerformDomesticTransfer(
                source,
                destination,
                transferAmount,
                transferTitle,
                DateTime.Now);

            _userInterface.DisplayDomesticTransferSummary(transfer);
        }
    }
}