namespace reserveringsysteem_project_B
{
    internal class ReviewMemberMenu : Screen

    {
        private readonly Screen _ReviewSchrijven;
        private readonly Screen _Reviews;
        public ReviewMemberMenu()
        {
            _ReviewSchrijven = new ReviewSchrijven();
            _ReviewSchrijven.SetPrevious(this);

            _Reviews = new ReviewMenu();
            _Reviews.SetPrevious(this);
        }
        public override void Show()
        {
            string title = "Review menu";
            string[] options = { "Review schrijven", "Reviews", "", "Terug" };
            UIPhysics ReviewMemberMenuScreen = new(title, options);
            int selectedIndex = ReviewMemberMenuScreen.Run();
            switch (selectedIndex)
            {
                case 0:
                    _ReviewSchrijven.Show();
                    break;
                case 1:
                    _Reviews.Show();
                    break;
                case 2:
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