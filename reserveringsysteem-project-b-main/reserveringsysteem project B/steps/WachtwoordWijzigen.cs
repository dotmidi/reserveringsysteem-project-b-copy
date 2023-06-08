using System;

namespace reserveringsysteem_project_B
{
    internal class WachtwoordWijzigen : Screen
    {
        public override void Show()
        {
            Console.Clear();
            string OldPassword;
            do
            {
                Console.WriteLine("Vul uw oude wachtwoord in: ");
                OldPassword = Console.ReadLine();
                if (!Accounts.GetInstance().IsOldPassword(OldPassword))
                {
                    Console.Clear();
                    Console.WriteLine("Wachtwoorden komen niet overeen!");
                }
            } while (!Accounts.GetInstance().IsOldPassword(OldPassword));
            string NewPassword;

            do
            {
                Console.WriteLine("Vul nieuw wachtwoord in: ");
                NewPassword = Console.ReadLine();
                if (!Accounts.IsValidPassword(NewPassword))
                {
                    Console.Clear();
                    Console.WriteLine("Wachtwoord niet geldig!");
                }
            } while (!Accounts.IsValidPassword(NewPassword));

            Console.Clear();
            Accounts.GetInstance().ChangePassword(NewPassword);
            Console.WriteLine("Uw wachtwoord is aangepast");

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            string prefix = ">>";
            Console.WriteLine($"{prefix} Terug");
            Console.ResetColor();
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Jump(2);
            }

        }

    }
}
