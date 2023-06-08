

namespace reserveringsysteem_project_B
{
    public class AccountWijzigen : Screen
    {
        private readonly Screen _WachtwoordWijzigen;
        private readonly Screen _UserNameWijzigen;
        private readonly Screen _CreditcardWijzigen;
        private readonly Screen _EmailWijzigen;

        public AccountWijzigen()
        {
            _WachtwoordWijzigen = new WachtwoordWijzigen();
            _WachtwoordWijzigen.SetPrevious(this);

            _UserNameWijzigen = new UsernameWijzigen();
            _UserNameWijzigen.SetPrevious(this);

            _CreditcardWijzigen = new CreditcardWijzigen();
            _CreditcardWijzigen.SetPrevious(this);

            _EmailWijzigen = new EmailWijzigen();
            _EmailWijzigen.SetPrevious(this);

        }

        public override void Show()
        {
            string title = "Account Wijzigen";
            string[] options = { "Wachtwoord wijzigen", "Username wijzigen", "Creditcard wijzigen", "E-mail wijzigen", "", "Terug" };
            UIPhysics AccountWijzigenScreen = new(title, options);
            int selectedIndex = AccountWijzigenScreen.Run();
            switch (selectedIndex)
            {
                case 0:
                    _WachtwoordWijzigen.Show();
                    break;
                case 1:
                    _UserNameWijzigen.Show();
                    break;
                case 2:
                    _CreditcardWijzigen.Show();
                    break;
                case 3:
                    _EmailWijzigen.Show();
                    break;
                case 4:
                    break;
                case 5:
                    Back();
                    break;
                default:
                    break;
            }
        }
    }

}