using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace BLL.Services
{
    public class MailService
    {
        private readonly IConfiguration config;

        public MailService(IConfiguration config)
        {
            this.config = config;
        }

        public bool SendWelcomeMail(string toEmail, string farmerName)
        {
            try
            {
                var fromEmail = config["EmailSettings:Email"];
                var password = config["EmailSettings:Password"];
                var host = config["EmailSettings:Host"];
                var port = int.Parse(config["EmailSettings:Port"]);

                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(fromEmail);
                mail.To.Add(toEmail);

                mail.Subject = "Welcome to AgroGuide 🌱";

                mail.Body =
                    $"Hello {farmerName},\n\n" +
                    $"Welcome to AgroGuide!\n\n" +
                    $"We are excited to support your farming journey with crop guidance, weather updates, fertilizer suggestions, and disease solutions.\n\n" +
                    $"Thank you for joining AgroGuide.\n\n" +
                    $"Regards,\n" +
                    $"AgroGuide Support Team";

                SmtpClient smtp = new SmtpClient(host, port);

                smtp.Credentials = new NetworkCredential(fromEmail, password);

                smtp.EnableSsl = true;

                smtp.Send(mail);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}