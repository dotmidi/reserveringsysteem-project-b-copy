using System;

namespace reserveringsysteem_project_B
{
    public class EmailWijzigen : Screen
    {
        public override void Show()
        {
            Console.Clear();
            string new_email;
            do
            {
                Console.WriteLine("Vul uw nieuwe E-mail adres in: ");
                new_email = Console.ReadLine();
                if (!Accounts.IsValidEmail(new_email))
                {
                    Console.Clear();
                    Console.WriteLine("Ongeldig E-mail adres!");
                }
            } while (!Accounts.IsValidEmail(new_email));

            Console.Clear();
            Accounts.GetInstance().ChangeEmail(new_email);
            Console.WriteLine("Uw E-mail adres is gewijzigd.");
            Console.WriteLine("");
            QuickOptionBack();
        }
    }
}
