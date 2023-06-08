using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reserveringsysteem_project_B
{
    internal class UI
    {
        public void start()
        {
            RunSplash();
        }

        private void RunSplash()
        {
            string title = @"


       /$$ /$$                                   /$$                                                        /$$    
      / $$/ $$                                  | $$                                                       | $$    
     /$$$$$$$$$$  /$$$$$$   /$$$$$$   /$$$$$$$ /$$$$$$    /$$$$$$  /$$   /$$  /$$$$$$  /$$$$$$  /$$$$$$$  /$$$$$$  
    |   $$  $$_/ /$$__  $$ /$$__  $$ /$$_____/|_  $$_/   |____  $$| $$  | $$ /$$__  $$|____  $$| $$__  $$|_  $$_/  
     /$$$$$$$$$$| $$  \__/| $$$$$$$$|  $$$$$$   | $$      /$$$$$$$| $$  | $$| $$  \__/ /$$$$$$$| $$  \ $$  | $$    
    |_  $$  $$_/| $$      | $$_____/ \____  $$  | $$ /$$ /$$__  $$| $$  | $$| $$      /$$__  $$| $$  | $$  | $$ /$$
      | $$| $$  | $$      |  $$$$$$$ /$$$$$$$/  |  $$$$/|  $$$$$$$|  $$$$$$/| $$     |  $$$$$$$| $$  | $$  |  $$$$/
      |__/|__/  |__/       \_______/|_______/    \___/   \_______/ \______/ |__/      \_______/|__/  |__/   \___/  
                                                                                                               
                                                                                                               
                                                                                                               
                                                                                                                                                                                
";
            string[] options = {"Druk op [ENTER] om door te gaan" };
            UIPhysics SplashMenu = new UIPhysics(title, options);
            int selectedIndex = SplashMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RunMainMenu();
                    break;
                default:
                    break;
            }
        }

        private void RunMainMenu()
        {
            string title = "Welkom bij #shooters!";
            string[] options = { "Inloggen", "Account aanmaken", "Reviews", "<<TEMP>> naar keuzescherm", "", "Sluiten" };
            UIPhysics MainMenu = new UIPhysics(title, options);
            int selectedIndex = MainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    RunMemberMenu();
                    break;
                case 5:
                    Exit();
                    break;
                default:
                    break;
            }
        }

        private void Exit()
        {
            Console.Clear();
        }

        private void RunMemberMenu()
        {
            string title = "Welkom, <voornaam>";
            string[] options = { "Reserveren", "Reservering annuleren", "Menu", "Review plaatsen", "Account opties wijzigen", "", "Uitloggen" };
            UIPhysics MemberMenu = new UIPhysics(title, options);
            int selectedIndex = MemberMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RunWIP();
                    break;
                case 1:
                    RunWIP();
                    break;
                case 2:
                    RunWIP();
                    break;
                case 3:
                    RunWIP();
                    break;
                case 4:
                    RunWIP();
                    break;
                case 6:
                    RunMainMenu();
                    break;
                default:
                    break;
            }

        }

        private void RunWIP()
        {
            string title = "Work in progress";
            string[] options = { "Terug naar hoofdmenu" };
            UIPhysics WIP = new UIPhysics(title, options);
            int selectedIndex = WIP.Run();

            switch (selectedIndex)
            {
                case 0:
                    RunMemberMenu();
                    break;
                default:
                    break;
            }
        }
    }
}
