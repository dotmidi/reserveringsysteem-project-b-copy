using System;

namespace reserveringsysteem_project_B
{
    public class NotitieToevoegen : Screen
    {

        public NotitieToevoegen()
        {

        }

        public override void Show()
        {
            int id;
            string note;
            Console.Clear();
            Console.WriteLine("Voer reservering id in.");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine("Voer uw Notitie in.");
            note = Console.ReadLine();
            if (Reservations.GetInstance().InReservations(id) && Reservations.GetInstance().IsUser(id))
            {
                Console.Clear();
                Reservations.GetInstance().AddNote(id, note);
                Console.WriteLine("Uw notitie is toegevoed.\n");
            }
            else
            {
                Console.WriteLine("Ongeldig reserverings Id.");
            }
            QuickOptionBack();
        }
    }
}
