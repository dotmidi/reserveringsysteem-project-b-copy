namespace reserveringsysteem_project_B
{
    internal class LoginMenu : Screen
    {
        private readonly Screen _Inlog;
        private readonly Screen _Registreren;

        public LoginMenu()
        {
            _Inlog = new Inloggen();
            _Inlog.SetPrevious(this);

            _Registreren = new Registreren();
            _Registreren.SetPrevious(this);
        }

        public override void Show()
        {
            string title = "Login";
            string[] options = { "Inloggen", "Account aanmaken", "", "Terug" };
            UIPhysics MemberMenuScreen = new(title, options);
            int selectedIndex = MemberMenuScreen.Run();
            switch (selectedIndex)
            {
                case 0:
                    _Inlog.Show();
                    break;
                case 1:
                    _Registreren.Show();
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
