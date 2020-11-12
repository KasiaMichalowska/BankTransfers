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
            _userInterface = new UserInterface();
            _bank = new Bank();

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
                _userInterface.DisplayIncorrectAccountError();
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
        }

        private void OutgoingTransfer()
        {
            if (_bank.GetAccount().Count < 1)
            {
                _userInterface.DisplayLessThan1OutgoingAccountError();
                return;
            }

            _userInterface.DisplayTransferStart(_bank.GetAccount(), false);
            BankAccount source = _bank.GetBankAccount(_userInterface.GetSourceAccountIndex());
            String destination = _userInterface.GetExternalAccountNumber();

            if (source == null || destination.Length == 0)
            {
                _userInterface.DisplayIncorrectAccountError();
                return;
            }

            string transferTitle = _userInterface.GetTransferTitle();
            decimal amount = _userInterface.GetTransferAmount();

            if (amount <= 0)
            {
                _userInterface.Display0OrLessTransferAmountError();
                return;
            }

            if (amount > source.AccountBalance)
            {
                _userInterface.DisplayGreaterThanSourceBalanceError();
                return;
            }

            Transfer transfer = new Transfer();
            transfer.PerformOutgoingTransfer(
                source,
                destination,
                amount,
                transferTitle,
                DateTime.Now);

            _userInterface.DisplayDomesticTransferSummary(transfer);
        }
    }
}