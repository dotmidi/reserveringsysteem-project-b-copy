using System;

namespace reserveringsysteem_project_B
{

    public class CreditcardWijzigen : Screen
    {
        public override void Show()
        {
            Console.Clear();
            string New_Creditcard;
            do
            {
                Console.WriteLine("Vul een nieuw Creditcard nummer in: ");
                New_Creditcard = Console.ReadLine();
                if (!Accounts.IsValidCard(New_Creditcard))
                {
                    Console.Clear();
                    Console.WriteLine("Ongeldig Creditcard nummer!");
                }
            } while (!Accounts.IsValidCard(New_Creditcard));

            Console.Clear();
            Accounts.GetInstance().ChangeCreditcard(New_Creditcard);
            Console.WriteLine("Uw Creditcard nummer is gewijzigd.");
            QuickOptionBack();
        }
    }
}
