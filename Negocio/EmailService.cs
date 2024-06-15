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
            smtpClient.Credentials = new NetworkCredential("", "");
            smtpClient.EnableSsl = true;
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
        }
        public void SendEmail(string toEmail, string subject, string body) {
            mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("");
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "";

            try {
                smtpClient.Send(mailMessage);
            } catch(Exception exception) {
                throw exception;
            }
        }
    }
}
