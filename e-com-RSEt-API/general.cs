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

            string bodyContent = "<h4>Welcome to our website!</h4><p>Thank you for signing up with us.</p> <a href=\"https://www.example.com\">Click here to visit our website</a>";


            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = Subject ;
            message.To.Add(new MailAddress(Email));

            message.Body = "<html><body>" + bodyContent + "</body></html>" + Body ;
            message.IsBodyHtml = true;

            var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, password),
                EnableSsl = true
            };
            smtp.Send(message);
        }
    }
}
