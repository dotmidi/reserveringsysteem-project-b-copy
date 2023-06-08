using System;
using System.Collections.Generic;

namespace reserveringsysteem_project_B
{
    internal class DinerMenu : Screen
    {
        public override void Show()
        {
            string title = @"



                                    $$$$$$$\  $$\                               
                                    $$  __$$\ \__|                              
                                    $$ |  $$ |$$\ $$$$$$$\   $$$$$$\   $$$$$$\  
                                    $$ |  $$ |$$ |$$  __$$\ $$  __$$\ $$  __$$\ 
                                    $$ |  $$ |$$ |$$ |  $$ |$$$$$$$$ |$$ |  \__|
                                    $$ |  $$ |$$ |$$ |  $$ |$$   ____|$$ |      
                                    $$$$$$$  |$$ |$$ |  $$ |\$$$$$$$\ $$ |      
                                    \_______/ \__|\__|  \__| \_______|\__
                                               
";
            Console.Clear();
            Console.WriteLine(title);
            List<Menu> list = Menus.GetInstance().GetDiner();
            foreach (Menu menu in list)
            {
                Console.WriteLine("\tGerecht: " + menu.Naam);
                
                if (menu.Prijs != null)
                {
                    Console.WriteLine("\tPrijs: " + string.Format("{0:0.00}", menu.Prijs));
                }

                if (menu.Allergenen != null)
                {
                    Console.WriteLine("\tAllergenen: " + menu.Allergenen);
                }
                
                if (menu.Subnaam != null)
                {
                    Console.WriteLine("\t\t" + menu.Subnaam + ": " + string.Format("{0:0.00}", menu.SubPrijs));
                }
                
                if (menu.Subnaam1 != null)
                {
                    Console.WriteLine("\t\t" + menu.Subnaam1 + ": " + string.Format("{0:0.00}", menu.SubPrijs1));
                }
                
                if (menu.Subnaam2 != null)
                {
                    Console.WriteLine("\t\t" + menu.Subnaam2 + ": " + string.Format("{0:0.00}", menu.SubPrijs2));
                }
                
                Console.Write("\n");
            }

            QuickOptionBack();
        }
    }
}