namespace reserveringsysteem_project_B
{
    public class WijzigenReservering : Screen
    {
        private readonly Screen _ReserveringAnnuleren;
        private readonly Screen _NotitieToevoegen;
        public WijzigenReservering()
        {
            _ReserveringAnnuleren = new ReserveringAnnuleren();
            _ReserveringAnnuleren.SetPrevious(this);

            _NotitieToevoegen = new NotitieToevoegen();
            _NotitieToevoegen.SetPrevious(this);
        }

        public override void Show()
        {
            string title = "Reservering Wijzigen";
            string[] options = { "Notitie toevoegen", "Reservering annuleren", "", "Terug" };
            UIPhysics WijzigingenReserveringScreen = new(title, options);
            int selectedIndex = WijzigingenReserveringScreen.Run();
            switch (selectedIndex)
            {
                case 0:
                    _NotitieToevoegen.Show();
                    break;
                case 1:
                    _ReserveringAnnuleren.Show();
                    break;
                case 3:
                    Back();
                    break;
                default:
                    break;
            }
        }
    }
}