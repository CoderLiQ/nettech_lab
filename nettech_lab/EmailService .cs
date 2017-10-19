using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace nettech_lab {
    public class EmailService {
        public async Task SendEmailAsync(string email, string subject, string message, string myemail, string mypass, 
                                                int smtpport, string smtpserver ) {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(email, myemail));
            emailMessage.To.Add(new MailboxAddress("Me", myemail));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) {
                Text = message
            };

            using (var client = new SmtpClient()) {
                await client.ConnectAsync(smtpserver, smtpport, false);
                await client.AuthenticateAsync(myemail, mypass);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}