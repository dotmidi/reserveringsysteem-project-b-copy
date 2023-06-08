using System;
using System.Numerics;


namespace reserveringsysteem_project_B
{
    internal class NieuweReservering : Screen
    {
        public NieuweReservering()
        {

        }

        private readonly int reservationId = Reservations.GetInstance().ReservationIdCounter();
        private readonly string currentDate = DateTime.Now.ToString("H:m:ss dd-MM-y");
        
        public override void Show()
        {
            string type;
            string food = null;
            string notes;
            string datum;
            int people = 0;

            int People() 
            {
                int p = -1;
                UIPhysics AntaalPersonen = new("Aantal Personen", new string[] { "1", "2", "3", "4", "", "Terug" });
                int PersonenAantal = AntaalPersonen.Run();
                switch (PersonenAantal)
                {
                    case 0:
                        p = 1;
                        break;
                    case 1:
                        p = 2;
                        break;
                    case 2:
                        p = 3;
                        break;
                    case 3:
                        p = 4;
                        break;
                    case 5:
                        Back();
                        type = null;
                        break;
                    default:
                        type = null;
                        break;
                }
                return p;
            }


            Console.Clear();

            UIPhysics SelectieMenu = new("Nieuwe reservering", new string[] { "Ontbijt\t\t\t\t\t[9:00-12:00]", "Lunch\t\t\t\t\t[12:00-16:00]", "Diner\t\t\t\t\t[16:00-21:00]", "", "Terug" });
            int SelectedIndex = SelectieMenu.Run();
            switch (SelectedIndex)
            {
                case 0:
                    type = "Ontbijt";
                    break;
                case 1:
                    type = "Lunch";
                    break;
                case 2:
                    type = "Diner";
                    break;
                case 4:
                    Back();
                    type = null; // null want anders gaat de compiler zeiken dat er geen type aan wordt gewezen
                    break;
                default:
                    type = null;
                    break;
            }
            Console.Clear();

            if (type == "Ontbijt")
            {
                people = People();

                string[] options = new string[(Menus.GetInstance().GetOntbijt().Count) + 2];
                for (int i = 0; i < options.Length - 2; i++)
                {
                    options[i] = Menus.GetInstance().GetOntbijt()[i].Naam;
                }
                int length = options.Length;
                options[length - 2] = "";
                options[length - 1] = "Terug";

                if (people == 1)
                {
                    UIPhysics MenuOptions = new UIPhysics("Kies hier het item dat u wilt hebben.", options);
                    int MenuSelectedIndex = MenuOptions.Run();
                    switch (MenuSelectedIndex)
                    {
                        case int n:
                            if (n == (options.Length) - 1)
                            {
                                Back();
                            }
                            else
                            {
                                food = Menus.GetInstance().GetOntbijt()[n].Naam;
                            }
                            break;
                    }

                }
                else
                {
                    int persoon = 0;
                    while (persoon < people)
                    {
                        UIPhysics MenuOptions = new UIPhysics($"Persoon {persoon + 1} kies hier het item dat u wilt hebben.", options);
                        int MenuSelectedIndex = MenuOptions.Run();
                        switch (MenuSelectedIndex)
                        {
                            case int n:
                                if (n == (options.Length) - 1)
                                {
                                    Back();
                                }
                                else
                                {
                                    food += Menus.GetInstance().GetOntbijt()[n].Naam + ", ";
                                    persoon++;
                                }
                                break;
                        }
                    }
                    food = food.Remove(food.Length - 2);
                }
            }
            else if (type == "Lunch")
            {
                people = People();

                string[] options = new string[(Menus.GetInstance().GetLunch().Count) + 2];
                for (int i = 0; i < options.Length - 2; i++)
                {
                    options[i] = Menus.GetInstance().GetLunch()[i].Naam;
                }
                int length = options.Length;
                options[length - 2] = "";
                options[length - 1] = "Terug";

                if (people == 1)
                {
                    UIPhysics MenuOptions = new UIPhysics("Kies hier het item dat u wilt hebben.", options);
                    int MenuSelectedIndex = MenuOptions.Run();
                    switch (MenuSelectedIndex)
                    {
                        case int n:
                            if (n == (options.Length) - 1)
                            {
                                Back();
                            }
                            else
                            {
                                food = Menus.GetInstance().GetLunch()[n].Naam;
                            }
                            break;
                    }
                }
                else
                {
                    int persoon = 0;
                    while (persoon < people)
                    {
                        UIPhysics MenuOptions = new UIPhysics($"Persoon {persoon + 1} kies hier het item dat u wilt hebben.", options);
                        int MenuSelectedIndex = MenuOptions.Run();
                        switch (MenuSelectedIndex)
                        {
                            case int n:
                                if (n == (options.Length) - 1)
                                {
                                    Back();
                                }
                                else
                                {
                                    food += Menus.GetInstance().GetLunch()[n].Naam + ", ";
                                    persoon++;
                                }
                                break;
                        }
                    }
                    food = food.Remove(food.Length - 2);
                } 
            }
            else
            {
                people = People();

                string[] options = new string[(Menus.GetInstance().GetDiner().Count) + 2];
                for (int i = 0; i < options.Length - 2; i++)
                {
                    options[i] = Menus.GetInstance().GetDiner()[i].Naam;
                }
                int length = options.Length;
                options[length - 2] = "";
                options[length - 1] = "Terug";

                if (type == "1")
                {
                    UIPhysics MenuOptions = new UIPhysics("Kies hier het item dat u wilt hebben.", options);
                    int MenuSelectedIndex = MenuOptions.Run();
                    switch (MenuSelectedIndex)
                    {
                        case int n:
                            if (n == (options.Length) - 1)
                            {
                                Back();
                            }
                            else
                            {
                                food = Menus.GetInstance().GetDiner()[n].Naam;
                            }
                            break;
                    }

                }
                else
                {
                    int persoon = 0;
                    while (persoon < people)
                    {
                        UIPhysics MenuOptions = new UIPhysics($"Persoon {persoon + 1} kies hier het item dat u wilt hebben.", options);
                        int MenuSelectedIndex = MenuOptions.Run();
                        switch (MenuSelectedIndex)
                        {
                            case int n:
                                if (n == (options.Length) - 1)
                                {
                                    Back();
                                }
                                else
                                {
                                    food += Menus.GetInstance().GetDiner()[n].Naam + ", ";
                                    persoon++;
                                }
                                break;
                        }
                    }
                    food = food.Remove(food.Length - 2);
                }
            }

            Console.Clear();

            do
            {
                
                Console.WriteLine("Type hier uw datum in (dd/mm/YYYY): \n");
                datum = Console.ReadLine();
                if (!Reservations.IsDate(datum))
                {
                    Console.Clear();
                    Console.WriteLine("Ongeldige Datum. Let op minimaal 1 dag van te voren reserveren!\n");
                }
            } while (!Reservations.IsDate(datum));

            do
            {
                Console.WriteLine("\nSchrijf hier eventuele notities zoals allergenen.\n");
                notes = Console.ReadLine();
                if (!Reservations.IsValidNotes(notes))
                {
                    Console.Clear();
                    Console.WriteLine("Huh?!\n");
                }
            } while (!Reservations.IsValidNotes(notes));

            Vector2 tableLocation = Grid.GetInstance().SelectorRun();
            int tableLocationX = (int)tableLocation.X;
            int tableLocationY = (int)tableLocation.Y;

            Res new_Reservation = new Res{ReservationId = Reservations.GetInstance().ReservationIdCounter(), People = people, Type = type, Food = food, Notes = notes, TimeOfReservation = currentDate, UserId = Accounts.GetInstance().User.Id, Date = datum, TableLocationX = tableLocationX, TableLocationY = tableLocationY };

            if (people > 1)
            {
                int p = 1;
                while (p < people) 
                {
                    Vector2 tablesLocation = Grid.GetInstance().SelectorRun();
                    int tablesLocationX = (int)tableLocation.X;
                    int tablesLocationY = (int)tableLocation.Y;

                    new_Reservation.TableLocationX = tablesLocationX;
                    new_Reservation.TableLocationY = tablesLocationY;

                    p++;
                }
            }

            Reservations.GetInstance().CreateReservation(new_Reservation);

            Console.WriteLine("\nReservering gecreëerd. Uw reserveringsnummer is " + (Reservations.GetInstance().ReservationIdCounter() - 1));
            Console.WriteLine("\nLet op! Noteer uw reserveringsnummer goed, deze heeft u nodig om een notitie toe te voegen of te annuleren.");

            Mail.SendConfirmationMail(Accounts.GetInstance().User.Email, reservationId, type, datum, people);

            QuickOptionBack();

        }
    }
}