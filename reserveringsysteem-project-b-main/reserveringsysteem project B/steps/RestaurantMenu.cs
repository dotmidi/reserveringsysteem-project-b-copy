namespace reserveringsysteem_project_B
{
    internal class RestaurantMenu : Screen
    {
        private readonly Screen _OntbijtMenu;
        private readonly Screen _LunchMenu;
        private readonly Screen _DinerMenu;

        public RestaurantMenu()
        {
            _OntbijtMenu = new OntbijtMenu();
            _OntbijtMenu.SetPrevious(this);

            _LunchMenu = new Lunchmenu();
            _LunchMenu.SetPrevious(this);

            _DinerMenu = new DinerMenu();
            _DinerMenu.SetPrevious(this);
        }

        public override void Show()
        {
            string title = @"Restaurant Menu
Kies welk menu u wilt zien:";
            string[] options = { "Ontbijt\t\t\t\t\t[9:00-12:00]", "Lunch\t\t\t\t\t[12:00-16:00]", "Diner\t\t\t\t\t[16:00-21:00]", "", "Terug" };
            UIPhysics RestaurantMenuScreen = new UIPhysics(title, options);
            int selectedIndex = RestaurantMenuScreen.Run();
            switch (selectedIndex)
            {
                case 0:
                    _OntbijtMenu.Show();
                    break;
                case 1:
                    _LunchMenu.Show();
                    break;
                case 2:
                    _DinerMenu.Show();
                    break;
                case 4:
                    Back();
                    break;
                default:
                    Show();
                    return;

            }

        }
    }
}