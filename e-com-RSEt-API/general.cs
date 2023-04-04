using System.Text;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;

namespace e_com_RSEt_API
{
    public class general
    {
        public static string hashPassword(string Password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordByte = Encoding.UTF8.GetBytes(Password);
                byte[] hashByte = sha256.ComputeHash(passwordByte);
                return Convert.ToBase64String(hashByte);
            }


        }

        public static void EmailSend(string Email, string Subject, string Body)
        {
            string fromMail = "miyuranga.athugala@gmail.com";
            string password = "osrifjrflkkpscox";
           
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = Subject ;
            message.To.Add(new MailAddress(Email));
            message.Body = "<html><body>" + Body + "</body></html>" ;
            message.IsBodyHtml = true;
            var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, password),
                EnableSsl = true
            };
            smtp.Send(message);

            //// Send email message
            //try
            //{
            //    client.Send(message);
            //    Console.WriteLine("Email sent successfully.");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Email send failed: " + ex.Message);
            //}
        }


        //Generate The Random OTP Code 
        public static int emailConfirmCode()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
    }
}
