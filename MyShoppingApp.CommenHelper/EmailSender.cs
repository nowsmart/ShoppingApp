using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace MyShoppingApp.CommenHelper
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var senderEmail = Environment.GetEnvironmentVariable("EmailSettings__SenderEmail");
            var password = Environment.GetEnvironmentVariable("EmailSettings__Password");
            var toEmail = new MimeMessage();
            toEmail.From.Add(MailboxAddress.Parse(senderEmail));
            toEmail.To.Add(MailboxAddress.Parse(email));
            toEmail.Subject = subject;
            toEmail.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };

            using (var emailClient = new SmtpClient())
            {
                await emailClient.ConnectAsync("chintpakistan.com", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);

                await emailClient.AuthenticateAsync(senderEmail, password);
                await emailClient.SendAsync(toEmail); // Await the send operation
                await emailClient.DisconnectAsync(true); // Await disconnection
            }
        }
    }
}
