using Microsoft.AspNet.Identity;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Possible.MessageWeb.Services
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            var mailMessage = new MailMessage();
            mailMessage.To.Add(message.Destination);
            mailMessage.Subject = message.Subject;
            mailMessage.Body = message.Body;
            mailMessage.IsBodyHtml = true;

            var smtpClient = new SmtpClient();
            smtpClient.SendCompleted += (s, e) => {
                smtpClient.Dispose();
            };

            return smtpClient.SendMailAsync(mailMessage);
        }
    }
}