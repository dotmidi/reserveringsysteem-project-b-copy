using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace reserveringsysteem_project_B
{
    public struct Account
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("creditcard")]
        public string CreditCard { get; set; }
    }

    public class Accounts
    {
        private List<Account> _data;
        private static Accounts _instance;

        public Account User;

        public Accounts()
        {
            var data = new Data<Account>();
            _data = data.Load("accounts.json");
        }

        public void CreateAccount(Account new_acc)
        {
            _data.Add(new_acc);
            Data<Account> data = new Data<Account>();
            data.Save("accounts.json", _data);
        }

 
        public static List<Account> GetAccounts()
        {
            return GetInstance()._data;
        }

        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPassword(string password)
        {
            return password.Length >= 6;
        }

        public static bool IsValidCard(string number)
        {

            int[] cardNumber = new int[number.Length];
            for (int i = 0; i < number.Length; i++) //step 0
            {
                cardNumber[i] = int.Parse(number[i].ToString());
            }

            int[] newList = new int[cardNumber.Length];
            int j = 0;
            for (int i = cardNumber.Length - 1; i >= 0; i--, j++)
            {
                if (j % 2 == 0)
                {
                    newList[i] = cardNumber[i];
                }
                else
                {
                    if (cardNumber[i] * 2 > 9)
                    {
                        newList[i] = ((cardNumber[i] * 2) % 10) + 1;
                    }
                    else
                    {
                        newList[i] = cardNumber[i] * 2;
                    }
                }
            }

            int sum = 0;
            foreach (int i in newList)
            {
                sum += i;
            }
            return sum % 10 == 0 ? true : false;
        }

        public static Accounts GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Accounts();
            }
            return _instance;
        }

        public static bool IsValidUsername(string username)
        {
            for (int i = 0; i < Accounts.GetInstance()._data.Count; i++)
            {
                if (username == Accounts.GetInstance()._data[i].Username)
                {
                    return false;
                }
            }
            return username.Length >= 3;
        }

        public bool Login(string username, string password)
        {
            foreach (Account x in _data)  
            {
                if (x.Username == username && x.Password == password)
                {
                    User = x;

                    return true;
                }
  
            }

            return false;
   
        }

        public int IdCounter()
        {
            return _data.Count + 1;
        }
      
        public bool IsOldPassword(string old)
        {
            if(old == User.Password)
            {
                return true;
            }

            return false;
        }

        public void DeleteAccount(Account a)
        {
            for(int i = 0; i < _data.Count; i++)
            {
                if(a.Id == _data[i].Id) 
                { 
                    _data.RemoveAt(i); 
                }
            }
        }

        public void ChangePassword(string password)
        {
            Account temp = User;
            DeleteAccount(User);
            temp.Password = password;
            _data.Add(temp);
            User = temp;    
            Data<Account> data = new Data<Account>();
            data.Save("accounts.json", _data);
        }

        public void ChangeUsername(string username)
        {
            Account temp = User;
            DeleteAccount(User);
            temp.Username = username;
            _data.Add(temp);
            User = temp;
            Data<Account> data = new Data<Account>();
            data.Save("accounts.json", _data);
        }

        public void ChangeEmail(string email)
        {
            Account temp = User;
            DeleteAccount(User);
            temp.Email = email;
            _data.Add(temp);
            User = temp;
            Data<Account> data = new Data<Account>();
            data.Save("accounts.json", _data);
        }

        public void ChangeCreditcard(string number)
        {
            Account temp = User;
            DeleteAccount(User);
            temp.CreditCard = number;
            _data.Add(temp);
            User = temp;
            Data<Account> data = new Data<Account>();
            data.Save("accounts.json", _data);
        }
      
        public static string RemoveNonNumeric(string value) => Regex.Replace(value, "[^0-9]", "");
    }
}
