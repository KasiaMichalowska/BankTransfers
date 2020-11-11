using System;
using VisioForge.Shared.MediaFoundation.OPM;

namespace BankTransfers
{
    class Program
    {
        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }
        private void Run()
        {
            UserInterface userInterface = new UserInterface();
            userInterface.DisplaynMenu();
            userInterface.ReadMenu();
        }        
    }
}