namespace reserveringsysteem_project_B
{
    internal class AdminMenu : Screen
    {
        private readonly Screen _AlleReserveringen;
        private readonly Screen _ReviewVerwijderen;
        private readonly Screen _Reviews;
        private readonly Screen _ReserveringAnnuleren;
        public AdminMenu()
        {
            _AlleReserveringen = new AlleReserveringen();
            _AlleReserveringen.SetPrevious(this);

            _ReviewVerwijderen = new ReviewVerwijderen();
            _ReviewVerwijderen.SetPrevious(this);

            _Reviews = new ReviewMenu();
            _Reviews.SetPrevious(this);

            _ReserveringAnnuleren = new ReserveringAnnuleren();
            _ReserveringAnnuleren.SetPrevious(this);
        }

        public override void Show()
        {
            string title = "Admin Menu";
            string[] options = { "Alle reserveringen bekijken", "Reservering verwijderen", "", "Alle reviews bekijken", "Review verwijderen", "", "Uitloggen" };
            UIPhysics AlleReserveringenScreen = new(title, options);
            int selectedIndex = AlleReserveringenScreen.Run();
            switch (selectedIndex)
            {
                case 0:
                    _AlleReserveringen.Show();
                    break;
                case 1:
                    _ReserveringAnnuleren.Show();
                    break;
                case 3:
                    _Reviews.Show();
                    break;
                case 4:
                    _ReviewVerwijderen.Show();
                    break;
                case 6:
                    Jump(3);
                    break;
                default:
                    break;
            }

        }
    }
}