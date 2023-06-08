using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace reserveringsysteem_project_B
{
    public struct Review
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("id")]

        public int Id { get; set; }

        [JsonPropertyName("stars")]
        public int Stars { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

    }


    public class Reviews
    {
        private readonly List<Review> _data;
        private static Reviews _instance = null;

        public Reviews()
        {
            Data<Review> data = new();
            _data = data.Load("reviews.json");

        }
        public List<Review> GetReviews()
        {
            return _data;
        }

        public static Reviews GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Reviews();
            }
            return _instance;
        }

        public bool Add(int stars, string desc, int res_id)  //functie voor het plaatsen van review. 
        {
            if(Reservations.GetReviewBool(res_id) == false && stars > 0 && stars <= 5 && Reservations.GetInstance().InReservations(res_id) && Reservations.GetInstance().IsUser(res_id)) //check in de ReserveringJson
            {
                string user_username = Accounts.GetInstance().User.Username;
                _data.Add(new Review { Username = user_username, Id = ReviewIDCounter(), Stars = stars, Description = desc });
                Reservations.GetInstance().SetReviewd(res_id);
                Save();
                return false;
            }
            else
            {
                return true;
            }

        }

        public void Remove(int id) //functie review verwijderen dmv review_id
        {
            for (int i = 0; i < _data.Count; i++)
            {
                if (id == _data[i].Id)
                {
                    _data.RemoveAt(i);
                }
            }
            Save();
        }

        public void Save()
        {
            Data<Review> data = new();
            data.Save("reviews.json", _data);
        }

        public int ReviewIDCounter()
        {
            return _data.Count + 1;
        }

        public bool IsInt(string input)
        {
            if (int.TryParse(input, out int n))
            {
                return true;
            }
            return false;
        }
    }
}
