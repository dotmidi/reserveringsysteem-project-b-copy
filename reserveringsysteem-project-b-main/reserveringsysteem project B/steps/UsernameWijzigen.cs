using System;

namespace reserveringsysteem_project_B
{
    public class UsernameWijzigen : Screen
    {

        public override void Show()
        {
            string New_Username;
            Console.Clear();
            do
            {

                Console.WriteLine("Vul een nieuwe Username in: ");
                New_Username = Console.ReadLine();
                if (!Accounts.IsValidUsername(New_Username))
                {
                    Console.Clear();
                    Console.WriteLine("Ongeldige Username!");
                }
            } while (!Accounts.IsValidUsername(New_Username));

            Console.Clear();
            Accounts.GetInstance().ChangeUsername(New_Username);
            Console.WriteLine("Uw Username is aangepast.");
            Console.WriteLine("");
            QuickOptionBack();

        }
    }
}
