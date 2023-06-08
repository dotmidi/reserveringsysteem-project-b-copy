using System;

namespace reserveringsysteem_project_B
{
    public class MainMenu : Screen
    {
        private readonly Screen _LoginMenu;
        private readonly Screen _ReviewMenu;
        private readonly Screen _RestaurantMenu;
        private readonly Screen _GridTest;
        public MainMenu()
        {

            _LoginMenu = new LoginMenu();
            _LoginMenu.SetPrevious(this);

            _ReviewMenu = new ReviewMenu();
            _ReviewMenu.SetPrevious(this);

            _RestaurantMenu = new RestaurantMenu();
            _RestaurantMenu.SetPrevious(this);

            _GridTest = new GridScreen();
            _GridTest.SetPrevious(this);
        }

        public override void Show()
        {
            string title = "Welkom bij de Krokante Krab";
            string[] options = { "Menukaart", "Login/Registreren", "Reviews", "", "Sluiten" };
            UIPhysics MemberMenuScreen = new(title, options);
            int selectedIndex = MemberMenuScreen.Run();
            switch (selectedIndex)
            {
                case 0:
                    _RestaurantMenu.Show();
                    break;
                case 1:
                    _LoginMenu.Show();
                    break;
                case 2:
                    _ReviewMenu.Show();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    return;
            }
        }
    }
}
