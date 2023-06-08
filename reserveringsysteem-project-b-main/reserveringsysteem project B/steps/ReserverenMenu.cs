namespace reserveringsysteem_project_B
{
    public class ReserverenMenu : Screen
    {
        private readonly Screen _NieuweReservering;
        private readonly Screen _WijzigenReservering;
        public ReserverenMenu()
        {
            _NieuweReservering = new NieuweReservering();
            _NieuweReservering.SetPrevious(this);

            _WijzigenReservering = new WijzigenReservering();
            _WijzigenReservering.SetPrevious(this);


        }

        public override void Show()
        {
            string title = "Reserveren";
            string[] options = { "Nieuwe Reservering", "Reservering Wijzigen", "", "Terug" };
            UIPhysics ReserverenMenuScreen = new(title, options);
            int selectedIndex = ReserverenMenuScreen.Run();
            switch (selectedIndex)
            {
                case 0:
                    _NieuweReservering.Show();
                    break;
                case 1:
                    _WijzigenReservering.Show();
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