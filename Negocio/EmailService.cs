using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Negocio {
    public class EmailService {
        private MailMessage mailMessage;
        private SmtpClient smtpClient;
        
        public EmailService() {
            smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential("97bf6405c1113a", "3466f597685572");
            smtpClient.EnableSsl = true;
            smtpClient.Port = 2525;
            smtpClient.Host = "sandbox.smtp.mailtrap.io";
        }
        public void SendEmail(string emailDestino, string subject, string body) {
            mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("noresponder@plataformacursos.com");
            mailMessage.To.Add(emailDestino);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;

            try {
                smtpClient.Send(mailMessage);
            } catch(Exception exception) {
                throw exception;
            }
        }
    }
}
