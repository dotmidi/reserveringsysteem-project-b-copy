using System;
using System.Threading;

namespace reserveringsysteem_project_B
{
    internal class Registreren : Screen
    {
        public override void Show()
        {
            string name;
            string email;
            string password;
            string creditCard;
            Console.Clear();
            Console.WriteLine("Registreren\n");
            do
            {
                Console.Write("Gebruikersnaam: ");
                name = Console.ReadLine();
                if (!Accounts.IsValidUsername(name))
                {
                    Console.WriteLine("\nGebruikersnaam moet minstens 3 tekens lang zijn, en mag niet eerder voorkomen.\n");
                }
            } while (!Accounts.IsValidUsername(name));
            do
            {
                Console.WriteLine("\nE-mail: \n");
                email = Console.ReadLine();
                if (!Accounts.IsValidEmail(email))
                {
                    Console.WriteLine("Ongeldig e-mailadres");
                }
            } while (!Accounts.IsValidEmail(email));
            do
            {
                Console.WriteLine("\nWachtwoord: \n");
                password = Console.ReadLine();
                if (!Accounts.IsValidPassword(password))
                {
                    Console.WriteLine("\nWachtwoord moet minstens 6 karakters lang zijn.\n");
                }
            } while (!Accounts.IsValidPassword(password));
            do
            {
                Console.WriteLine("\nCreditcardnummer: \n");
                creditCard = Accounts.RemoveNonNumeric(Console.ReadLine());
                if (!Accounts.IsValidCard(creditCard))
                {
                    Console.WriteLine("\nOngeldig creditcardnummer\n");
                }
            } while (!Accounts.IsValidCard(creditCard));



            Account new_Account = new() { Id = Accounts.GetInstance().IdCounter(), Username = name, Password = password, Email = email, CreditCard = creditCard };
            Accounts.GetInstance().CreateAccount(new_Account);

            Console.WriteLine("\nAccount gecreëerd");
            Thread.Sleep(4000);
            Back();

        }
    }
}