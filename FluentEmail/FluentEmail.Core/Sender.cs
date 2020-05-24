using System;
using System.Net;
using System.Net.Mail;

namespace FluentEmail.Core
{
    public class Sender
    {
        private readonly string mailFrom = "plantechHF@gmail.com";
        private readonly string password = "highfiveteam";

        public void Dispatch(string mailTo, string subject, string message)
        {
            var credentials = new NetworkCredential(mailFrom, password);

            var mail = new MailMessage()
            {
                From = new MailAddress(mailFrom),
                Subject = subject,
                Body = message
            };

            mail.IsBodyHtml = true;
            mail.To.Add(new MailAddress(mailTo));

            var client = new SmtpClient()
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = credentials
            };

            client.Send(mail);
        }

    }
}
