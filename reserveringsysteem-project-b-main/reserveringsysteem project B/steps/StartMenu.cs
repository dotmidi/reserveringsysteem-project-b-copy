using System;

namespace reserveringsysteem_project_B
{
    internal class StartMenu : Screen
    {
        private readonly Screen _next;
        public StartMenu()
        {
            _next = new MainMenu();
            _next.SetPrevious(this);
        }

        public override void Show()
        {
            ConsoleKeyInfo input;

            do
            {
                switchFullScreen();
                Console.Clear();

                Console.WriteLine(@"

     /$$   /$$                     /$$                             /$$                     /$$   /$$                    /$$      
    | $$  /$$/                    | $$                            | $$                    | $$  /$$/                   | $$      
    | $$ /$$/   /$$$$$$   /$$$$$$ | $$   /$$  /$$$$$$  /$$$$$$$  /$$$$$$    /$$$$$$       | $$ /$$/   /$$$$$$  /$$$$$$ | $$$$$$$ 
    | $$$$$/   /$$__  $$ /$$__  $$| $$  /$$/ |____  $$| $$__  $$|_  $$_/   /$$__  $$      | $$$$$/   /$$__  $$|____  $$| $$__  $$
    | $$  $$  | $$  \__/| $$  \ $$| $$$$$$/   /$$$$$$$| $$  \ $$  | $$    | $$$$$$$$      | $$  $$  | $$  \__/ /$$$$$$$| $$  \ $$
    | $$\  $$ | $$      | $$  | $$| $$_  $$  /$$__  $$| $$  | $$  | $$ /$$| $$_____/      | $$\  $$ | $$      /$$__  $$| $$  | $$
    | $$ \  $$| $$      |  $$$$$$/| $$ \  $$|  $$$$$$$| $$  | $$  |  $$$$/|  $$$$$$$      | $$ \  $$| $$     |  $$$$$$$| $$$$$$$/
    |__/  \__/|__/       \______/ |__/  \__/ \_______/|__/  |__/   \___/   \_______/      |__/  \__/|__/      \_______/|_______/ 
                                                                                                                                                                                                                                                                                                                                                                          

    [Gebruik de pijltjestoetsen om te navigeren]

    [Druk op [ENTER] om door te gaan]
");

                input = Console.ReadKey();
            }
            while (input.Key != ConsoleKey.Enter);

            _next.Show();
        }
    }
}