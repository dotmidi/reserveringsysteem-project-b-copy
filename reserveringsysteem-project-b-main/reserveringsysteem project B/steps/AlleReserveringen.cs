using System;
using System.Collections.Generic;

namespace reserveringsysteem_project_B
{
    internal class AlleReserveringen : Screen
    {
        public override void Show()
        {
            Console.Clear();
            List<Res> list = Reservations.GetInstance().GetReservations();
            foreach (Res res in list)
            {
                Console.WriteLine("\tReservationId: " + res.ReservationId);
                Console.WriteLine("\tNumber of People: " + res.People);
                Console.WriteLine("\tTime of Day: " + res.Type);
                Console.WriteLine("\tFood: " + res.Food);
                Console.WriteLine("\tNotes: " + res.Notes);
                Console.WriteLine("\tReservation Time: " + res.TimeOfReservation + "\n");
            }

            QuickOptionBack();
        }
    }
}