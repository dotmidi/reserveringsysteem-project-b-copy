namespace reserveringsysteem_project_B
{
    public class MemberMenu : Screen
    {
        private readonly Screen _Reserveren;
        private readonly Screen _ReviewMenu;
        private readonly Screen _Menu;
        private readonly Screen _AccountWijzigen;

        public MemberMenu()
        {
            _Reserveren = new ReserverenMenu();
            _Reserveren.SetPrevious(this);

            _ReviewMenu = new ReviewMemberMenu();
            _ReviewMenu.SetPrevious(this);

            _Menu = new RestaurantMenu();
            _Menu.SetPrevious(this);

            _AccountWijzigen = new AccountWijzigen();
            _AccountWijzigen.SetPrevious(this);
        }

        public override void Show()
        {
            string Name = Accounts.GetInstance().User.Username;
            string title = $"Welkom, {Name}";
            string[] options = { "Reserveren", "Menukaart", "Review menu", "Account instellingen", "", "Uitloggen" };
            UIPhysics MemberMenuScreen = new(title, options);
            int selectedIndex = MemberMenuScreen.Run();
            switch (selectedIndex)
            {
                case 0:
                    _Reserveren.Show();
                    break;
                case 1:
                    _Menu.Show();
                    break;
                case 2:
                    _ReviewMenu.Show();
                    break;
                case 3:
                    _AccountWijzigen.Show();
                    break;
                case 5:
                    Jump(3);
                    break;
                default:
                    break;
            }
        }
    }
}