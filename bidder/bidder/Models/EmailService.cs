using System.Net;
using System.Net.Mail;

namespace bidder.Models
{
    public class EmailService
    {
        private readonly SmtpClient _smtpClient;

        public EmailService(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword) //"smtp.gmail.com",587,"harlan.j.ferguson@gmail.com","Pomle@$$hf8NTzzKDnJtLj"
        {
            _smtpClient = new SmtpClient(smtpServer, smtpPort);
            _smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            _smtpClient.EnableSsl = true;
        }

        public async Task SendEmailAsync(string from, string to, string subject, string body)
        {
            var message = new MailMessage(from, to, subject, body);
            await _smtpClient.SendMailAsync(message);
        }
    }
}
