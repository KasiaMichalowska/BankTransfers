using System;
using VisioForge.Shared.MediaFoundation.OPM;

namespace BankTransfers
{
    class AccountNumber
    {
        static void Main(string[] args)
        {
            new AccountNumber().Run();
        }

        void Run()
        {
            /* 
            1. add Menu - app ma wyświetlać menu z opcjami (poniżej)
            2. opcje mogą pozostać puste - czy mają być obiektami ?
            3. app ma pytac o kolejna opcje w menu w nieskonczonść - pętla ?
            4. Dostępne opcje w menu powinny pojawiać się na ekranie za każdym razem przed wprowadzeniem komendy 
            - powinny pojawiać się na ekranie za każdym razem - za każdym razem, czyli zapis do pamięci czy pętla, czy jeszcze coś innego ?
            - jakiej komendy (opcji z menu) ?
            */

            Console.WriteLine("Menu: ");
            Console.WriteLine("Create account");
            Console.WriteLine("Domestic transfer");
            Console.WriteLine("Outgoing transfer");
            Console.WriteLine("Accounts balance");
            Console.WriteLine("Transfers history");
            Console.WriteLine("Exit");
        }        
    }
}