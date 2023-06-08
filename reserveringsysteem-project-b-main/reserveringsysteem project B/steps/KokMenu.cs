namespace reserveringsysteem_project_B
{
    internal class KokMenu : Screen
    {
        private readonly Screen _AlleReserveringen;
        public KokMenu()
        {
            _AlleReserveringen = new AlleReserveringen();
            _AlleReserveringen.SetPrevious(this);
        }

        public override void Show()
        {
            string title = "Kok Menu";
            string[] options = { "Alle reserveringen", "", "Terug" };
            UIPhysics KokMenuScreen = new(title, options);
            int selectedIndex = KokMenuScreen.Run();
            switch (selectedIndex)
            {
                case 0:
                    _AlleReserveringen.Show();
                    break;
                case 2:
                    Jump(3);
                    break;
                default:
                    break;
            }
        }
    }
}