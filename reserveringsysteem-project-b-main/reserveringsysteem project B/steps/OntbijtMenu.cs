using System;
using System.Collections.Generic;

namespace reserveringsysteem_project_B
{
    internal class OntbijtMenu : Screen
    {
        public override void Show()
        {
            string title = @"


                                      /$$$$$$              /$$     /$$       /$$       /$$    
                                     /$$__  $$            | $$    | $$      |__/      | $$    
                                    | $$  \ $$ /$$$$$$$  /$$$$$$  | $$$$$$$  /$$ /$$ /$$$$$$  
                                    | $$  | $$| $$__  $$|_  $$_/  | $$__  $$| $$|__/|_  $$_/  
                                    | $$  | $$| $$  \ $$  | $$    | $$  \ $$| $$ /$$  | $$    
                                    | $$  | $$| $$  | $$  | $$ /$$| $$  | $$| $$| $$  | $$ /$$
                                    |  $$$$$$/| $$  | $$  |  $$$$/| $$$$$$$/| $$| $$  |  $$$$/
                                     \______/ |__/  |__/   \___/  |_______/ |__/| $$   \___/  
                                                                           /$$  | $$          
                                                                          |  $$$$$$/          
                                                                           \______/           

";
            Console.Clear();
            Console.WriteLine(title);
            List<Menu> list = Menus.GetInstance().GetOntbijt();
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