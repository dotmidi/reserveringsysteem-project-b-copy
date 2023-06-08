using System;

namespace reserveringsysteem_project_B
{
    internal class ReviewSchrijven : Screen
    {
        public override void Show()
        {
            string Res_Id;
            string stars;
            string review;
            Console.Clear();

            do
            {
                Console.WriteLine("Vul uw desbetreffende Reserverings ID in : ");
                Res_Id = Console.ReadLine();
                if (!Reviews.GetInstance().IsInt(Res_Id) || Reservations.GetReviewBool(int.Parse(Res_Id)) == true || !Reservations.GetInstance().IsUser(int.Parse(Res_Id)))
                {
                    Console.WriteLine("Uw Reserverings ID is niet correct of u heeft al een review gegeven");
                }
            } while (!Reviews.GetInstance().IsInt(Res_Id) || Reservations.GetReviewBool(int.Parse(Res_Id)) == true || !Reservations.GetInstance().IsUser(int.Parse(Res_Id)));

            Console.WriteLine("");

            do
            {
                Console.WriteLine("Vul aantal sterren in (1 - 5): ");
                stars = Console.ReadLine();
                if (!Reviews.GetInstance().IsInt(stars) || int.Parse(stars) < 1 || int.Parse(stars) > 5)
                {
                    Console.Clear();
                    Console.WriteLine("Vul een geldige input in.");
                }
            } while (!Reviews.GetInstance().IsInt(stars) || int.Parse(stars) < 1 || int.Parse(stars) > 5);

            Console.WriteLine("");
            Console.WriteLine("Vul review in: ");
            review = Console.ReadLine();
            int starsInt = int.Parse(stars);
            int idInt = int.Parse(Res_Id);
            if (!Reviews.GetInstance().Add(starsInt, review, idInt))
            {
                Console.Clear();
                Console.WriteLine("Ongeldige review, Let op 1 review per reservering!");
            }

            Reviews.GetInstance().Add(starsInt, review, idInt);
            Console.Clear();
            Console.WriteLine("Uw review is geplaatst\n");

            QuickOptionBack();

        }
    }
}
