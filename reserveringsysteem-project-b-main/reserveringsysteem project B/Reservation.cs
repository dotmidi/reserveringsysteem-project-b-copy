
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace reserveringsysteem_project_B
{
    public struct Res
    {
        [JsonPropertyName("reservationId")]
        public int ReservationId { get; set; }

        [JsonPropertyName("people")]
        public int People { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("food")]
        public string Food { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        [JsonPropertyName("timeOfReservation")]
        public string TimeOfReservation { get; set; }

        [JsonPropertyName("reviewed")]
        public bool Reviewed { get; set; }

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("datum")]
        public string Date { get; set; }

        [JsonPropertyName("tableLocationX")]
        public int TableLocationX { get; set; }

        [JsonPropertyName("tableLocationY")]
        public int TableLocationY { get; set; }

    }

    public class Reservations
    {
        private readonly List<Res> _data;
        private static Reservations _instance;
        
        public Res Reservation;

        public Reservations()
        {
            Data<Res> data = new();
            _data = data.Load("reservations.json");
        }

        public void CreateReservation(Res new_res)
        {
            _data.Add(new_res);
            Save();
        }

        public static bool IsValidType(string type)
        {
            return type != "Ontbijt" ^ type != "ontbijt" ^ type != "Lunch" ^ type != "lunch" ^ type != "Diner" ^ type != "diner";
        }

        public static bool IsValidFood(string food)
        {
            return food.Length >= 4;
        }

        public static bool IsValidNotes(string notes)
        {
            return notes.Length >= 0;
        }

        public static bool GetReviewBool(int id)
        {
            List<Res> _data = GetInstance()._data;
            for (int i = 0; i < _data.Count; i++)
            {
                if (_data[i].ReservationId == id)
                {
                    return _data[i].Reviewed;
                }
            }
            return false;
        }

        public static bool IsValidEmail(string email)
        {
            string trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                System.Net.Mail.MailAddress addr = new(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public void DeleteReservation(int id)
        {
            for (int i = 0; i < _data.Count; i++)
            {
                if (id == _data[i].ReservationId)
                {
                    _ = _data.Remove(_data[i]);
                }
            }
            Save();
        }

        public void SetReviewd(int id)
        {
            Res temp;
            for (int i = 0; i < _data.Count; i++)
            {
                if (_data[i].ReservationId == id)
                {
                    temp = _data[i];
                    temp.Reviewed = true;
                    _ = _data.Remove(_data[i]);
                    _data.Add(temp);
                }
            }
            Save();
        }

        public void AddNote(int id, string note)
        {
            for (int i = 0; i < _data.Count; i++)
            {
                if (id == _data[i].ReservationId)
                {
                    Res new_res = _data[i];
                    DeleteReservation(id);
                    new_res.Notes += $", {note}";
                    _data.Add(new_res);
                }
            }
            Save();
        }

        public int ReservationIdCounter()
        {
            return _data.Count + 1;
        }

        public static Reservations GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Reservations();
            }
            return _instance;
        }


        public bool InReservations(int id)
        {

            foreach (Res res in _data)
            {
                if (res.ReservationId == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsUser(int res_id)
        {
            foreach (Res res in _data)
            {
                if (res.ReservationId == res_id)
                {
                    if (Accounts.GetInstance().User.Id == res.UserId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Save()
        {
            Data<Res> data = new();
            data.Save("reservations.json", _data);
        }
        public List<Res> GetReservations()
        {
            return _data;
        }

        public static bool IsDate(string Date) //functie om datum te checken
        {
            DateTime fromDateValue;
            var formats = new[] { "dd/MM/yyyy" };
            if (DateTime.TryParseExact(Date, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue) && fromDateValue > DateTime.Now.AddDays(1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CancelRes(int id)
        {
 
            DateTime date = default;
            foreach (Res res in _data)
            {
                if (res.ReservationId == id)
                {
                    date = Convert.ToDateTime(res.Date);
                }
            }
            if((date - DateTime.Now).TotalDays < 6)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
