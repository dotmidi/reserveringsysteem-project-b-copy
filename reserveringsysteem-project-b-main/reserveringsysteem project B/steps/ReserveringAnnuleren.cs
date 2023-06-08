using System;

namespace reserveringsysteem_project_B
{
    public class ReserveringAnnuleren : Screen
    {
        public override void Show()
        {
            Console.Clear();
            int id;
            Console.WriteLine("Voer de reservering id in");
            do
            {
                id = int.Parse(Console.ReadLine());
                if (!Reservations.GetInstance().IsUser(id) || !Reservations.GetInstance().CancelRes(id))
                {
                    Console.Clear();
                    Console.WriteLine("Ongeldig Reserverings id, Let op je kan tot 6 dagen van te voren annuleren!");
                    QuickOptionBack();
                }
            } while (!Reservations.GetInstance().CancelRes(id) || !Reservations.GetInstance().IsUser(id));

            Reservations.GetInstance().DeleteReservation(id);
            Console.WriteLine("Uw reservering is geannuleerd.\n");
            QuickOptionBack();

        }

    }
}
