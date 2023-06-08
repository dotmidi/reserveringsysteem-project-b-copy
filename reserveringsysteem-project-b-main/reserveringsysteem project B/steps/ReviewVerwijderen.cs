using System;

namespace reserveringsysteem_project_B
{
    public class ReviewVerwijderen : Screen
    {
        public override void Show()
        {
            Console.Clear();
            string id;
            Console.WriteLine("Voer de review id in");
            do
            {
                id = Console.ReadLine();
                if (!Reviews.GetInstance().IsInt(id))
                {
                    Console.Clear();
                    Console.WriteLine("Vul een geldige input in.");
                }
            } while (!Reviews.GetInstance().IsInt(id));
            Reviews.GetInstance().Remove(int.Parse(id));
            Console.WriteLine("De review is verwijderd.\n");
            QuickOptionBack();
        }
    }
}