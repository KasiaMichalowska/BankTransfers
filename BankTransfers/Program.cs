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
                    case 2:
                        DomesticTransfer();
                        break;
                    case 3:
                        OutgoingTransfer();
                        break;
                    case 4:
                        ListAccountsBalance();
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
            //public void DisplayCreateAccountInfo()
            //{
            //    Console.WriteLine(" Creating new account");
            //    Console.WriteLine(" Provide account name: ");
            //}

            var accountName = _userInterface.GetAccountName();
            //public string GetAccountName()
            //{
            //    return Console.ReadLine();
            //}

            var account = _bank.CreateAccount(accountName);
            Console.WriteLine("Creating new account");
        }

        private void DomesticTransfer()
        {
            if (_bank.GetAccount().Count <= 1)
            {
                Console.WriteLine("There are less than 2 domestic bank accounts, cannot perform a domestic transfer.");
                return;
            }

            _userInterface.DisplayTransferStart(_bank.GetAccount(), true);

            //public void DisplayTransferStart(List<BankAccount> accounts, bool isDomestic)
            //{
            //    if (isDomestic)
            //    {
            //        Console.WriteLine("Domestic Transfer");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Outgoing Transfer");
            //    }

            //    int position = 1;
            //    foreach (var bankaccount in accounts)
            //    {
            //        Console.WriteLine($"{position}. {bankaccount.Name}\t{bankaccount.AccountNumber}\tBalance: ${bankaccount.AccountBalance}");
            //        position++;
            //    }
            //}

            BankAccount source = _bank.GetBankAccount(_userInterface.GetSourceAccountIndex());

            //public int GetSourceAccountIndex()
            //{
            //    int accountIndex = ReadIntegerValue("Provide source bank account");
            //    accountIndex--;
            //    return accountIndex;
            //}

            BankAccount destination = _bank.GetBankAccount(_userInterface.GetDestinationAccountIndex());

            //public int GetDestinationAccountIndex()
            //{
            //    int accountIndex = ReadIntegerValue("Provide destination bank account");
            //    accountIndex--;
            //    return accountIndex;
            //}

            if (source == null || destination == null)
            {
                Console.WriteLine("Source or destination account is invalid, cannot do a transfer");
                return;
            }

            if (source == destination)
            {
                Console.WriteLine("Source and destination account is the same, cannot do a domestic transfer");
                return;
            }

            string transferTitle = _userInterface.GetTransferTitle();
            Console.WriteLine("Provide transfer title");

            decimal transferAmount = GetTransferAmount();
            Console.WriteLine("Provide transfer amount");

            if (transferAmount <= 0)
            {
                Console.WriteLine("$0 or less cannot be transferred");
                return;
            }

            if (transferAmount > source.AccountBalance)
            {
                Console.WriteLine("Amount greater than source account balance cannot be transferred");
            }
            return;
        }
    }

    private void OutgoingTransfer()
    {
        if (_bank.GetAccount().Count < 1)
        {
            Console.WriteLine("To do a transfer there has to be at least 1 domestic account");
            return;
        }

        _userInterface.DisplayTransferStart(_bank.GetAccount(), false);
        BankAccount source = _bank.GetBankAccount(_userInterface.GetSourceAccountIndex());
        String destination = _userInterface.GetExternalAccountNumber();

        if (source == null || destination.Length == 0)
        {
            Console.WriteLine("Source or destination account is invalid, cannot perform a domestic transfer.");
            return;
        }

        string transferTitle = ("Provide transfer title");
   
        decimal amount = _userInterface.GetTransferAmount();
        // return ("Provide transfer amount");

        if (amount <= 0)
        {
            Console.WriteLine("$0 or less cannot be transferred");
            return;
        }

        if (amount > source.AccountBalance)
        {
            Console.WriteLine("Amount greater than source account balance cannot be transferred");
            return;
        }

        Transfer transfer = new Transfer();
        transfer.PerformOutgoingTransfer(
            source,
            destination,
            amount,
            transferTitle,
            DateTime.Now);

        Console.WriteLine("Transfer is successful");
        Console.WriteLine(transfer.ToString());
    }

    private void ListAccountsBalance()
    {
        Console.WriteLine("Accounts balance");
      //  DisplayAccountsBalance(_bank.GetAccount());
    }
    public void DisplayAccountsBalance(List<BankAccount> accounts)
    {
        if (accounts.Count == 0)
        {
            Console.WriteLine("No accounts has been created");
        }
        foreach (var bankaccount in accounts)
        {
            Console.WriteLine($"Name: {bankaccount.Name}, Guid: {bankaccount.AccountNumber.ToString()}, Balance: ${bankaccount.AccountBalance}");
        }
    }
}