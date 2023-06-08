using System;
using System.Collections.Generic;

namespace reserveringsysteem_project_B
{
    internal class ReviewMenu : Screen
    {

        private static string StarReview(int star) //functie om sterren te maken
        {
            string temp = "";
            for (int i = 0; i < star; i++)
            {
                temp += "*";
            }
            return temp;
        }



        public override void Show()
        {
            Console.Clear();
            string Title = @"


                         _______                        __                                   
                        /       \                      /  |                                  
                        $$$$$$$  |  ______   __     __ $$/   ______   __   __   __   _______ 
                        $$ |__$$ | /      \ /  \   /  |/  | /      \ /  | /  | /  | /       |
                        $$    $$< /$$$$$$  |$$  \ /$$/ $$ |/$$$$$$  |$$ | $$ | $$ |/$$$$$$$/ 
                        $$$$$$$  |$$    $$ | $$  /$$/  $$ |$$    $$ |$$ | $$ | $$ |$$      \ 
                        $$ |  $$ |$$$$$$$$/   $$ $$/   $$ |$$$$$$$$/ $$ \_$$ \_$$ | $$$$$$  |
                        $$ |  $$ |$$       |   $$$/    $$ |$$       |$$   $$   $$/ /     $$/ 
                        $$/   $$/  $$$$$$$/     $/     $$/  $$$$$$$/  $$$$$/$$$$/  $$$$$$$  
";
            Console.WriteLine(Title + "\n");
            List<Review> list = Reviews.GetInstance().GetReviews();
            foreach (Review review in list)
            {
                Console.WriteLine("\t" + review.Id);
                Console.WriteLine("\t" + review.Username);
                Console.WriteLine("\t" + StarReview(review.Stars));
                Console.WriteLine("\t" + review.Description);
                Console.WriteLine("\t" + "");
            }

            QuickOptionBack();



        }
    }
}
