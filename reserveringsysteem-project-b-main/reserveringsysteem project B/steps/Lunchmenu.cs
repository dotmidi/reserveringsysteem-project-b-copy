using System;
using System.Collections.Generic;

namespace reserveringsysteem_project_B
{
    internal class Lunchmenu : Screen
    {
        public override void Show()
        {
            string title = @"


                                     /$$                                     /$$      
                                    | $$                                    | $$      
                                    | $$       /$$   /$$ /$$$$$$$   /$$$$$$$| $$$$$$$ 
                                    | $$      | $$  | $$| $$__  $$ /$$_____/| $$__  $$
                                    | $$      | $$  | $$| $$  \ $$| $$      | $$  \ $$
                                    | $$      | $$  | $$| $$  | $$| $$      | $$  | $$
                                    | $$$$$$$$|  $$$$$$/| $$  | $$|  $$$$$$$| $$  | $$
                                    |________/ \______/ |__/  |__/ \_______/|__/  |__
                                                  
";
            Console.Clear();
            Console.WriteLine(title);
            List<Menu> list = Menus.GetInstance().GetLunch();
            foreach (Menu menu in list)
            {
                Console.WriteLine("\tGerecht: " + menu.Naam);
                Console.WriteLine("\tPrijs: " + menu.Prijs);
                Console.WriteLine("\tAllergenen: " + menu.Allergenen + "\n");
            }

            QuickOptionBack();
        }
    }
}