using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace reserveringsysteem_project_B
{
    internal class Mail
    {
        public static void SendConfirmationMail(string toMail, int reservationId, string type, string date, int amountOfPeople)
        {
            StreamReader html = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\..\\Data\\html\\index.html");
            MailAddress from = new MailAddress("codeboys.rs@gmail.com");
            MailAddress to = new MailAddress(toMail);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Automatische mail.";
            message.IsBodyHtml = true;
            string strhtml = html.ReadToEnd();
            strhtml = strhtml.Replace("[RESERVATIONID]", reservationId.ToString());
            strhtml = strhtml.Replace("[TYPE]", type.ToLower());
            strhtml = strhtml.Replace("[PERSOON]", Accounts.GetInstance().User.Username);
            strhtml = strhtml.Replace("[RESERVATIONDATE]", date);
            strhtml = strhtml.Replace("[AANTALPERSONEN]", amountOfPeople.ToString());
            message.Body = strhtml;
            // message.Body = html.ReadToEnd();
            // message.Body = "Uw reserveringID is {reservationId}.";
            // SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            SmtpClient client = new SmtpClient("smtp.mailgun.org", 587);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            // client.Credentials = new System.Net.NetworkCredential("codeboys.rs@gmail.com", "codeboys123");
            client.Credentials = new System.Net.NetworkCredential("postmaster@mailgun.hakoptak.nl", "ec4082b5197f5b52afb1d5cecee966bb-8d821f0c-41f142d8");
            Console.WriteLine($"We hebben een bevestiging email gestuurd naar {toMail}.");

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage4(): {0}",
                    ex.ToString());
            }
        }
    }
}
