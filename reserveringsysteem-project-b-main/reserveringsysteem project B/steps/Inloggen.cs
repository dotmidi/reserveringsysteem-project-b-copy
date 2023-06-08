using System;

namespace reserveringsysteem_project_B
{
    internal class Inloggen : Screen
    {
        private readonly Screen _MemberMenu;
        private readonly Screen _AdminMenu;
        private readonly Screen _KokMenu;

        public Inloggen()
        {
            _MemberMenu = new MemberMenu();
            _MemberMenu.SetPrevious(this);

            _AdminMenu = new AdminMenu();
            _AdminMenu.SetPrevious(this);

            _KokMenu = new KokMenu();
            _KokMenu.SetPrevious(this);
        }
        public override void Show()
        {
            Console.Clear();
            Console.WriteLine("Inloggen\n");
            Console.WriteLine("Gebruikersnaam: \n");
            string username = Console.ReadLine();
            Console.WriteLine("\nWachtwoord: \n");

            string password = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            bool IsAdmin = Screen.IsAdmin(username, password);
            bool IsKok = Screen.IsKok(username, password);
            bool check = Accounts.GetInstance().Login(username, password);
            if (IsAdmin)
            {
                _AdminMenu.Show();
            }
            else
            if (IsKok)
            {
                _KokMenu.Show();
            }
            {

                if (check)
                {
                    _MemberMenu.Show();
                }
                else
                {
                    Console.WriteLine("\nGegevens kloppen niet. Probeer opnieuw in te loggen of maak een account aan.\n");
                    QuickOptionBack();
                }

            }
        }
    }
}