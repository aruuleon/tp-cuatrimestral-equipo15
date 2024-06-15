using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Xml.Linq;
using Dominio;

namespace Negocio {
    public class EmailService {
        private MailMessage mailMessage;
        private SmtpClient smtpClient;
        private const string SUBJECT_STUDENT = "MaxiPrograma - Registro Exitoso";
        private const string SUBJECT_ADMINISTRATOR = "MaxiPrograma - Tenes un nuevo estudiante";

        public EmailService() {
            smtpClient = new SmtpClient();
            smtpClient.Host = ConfigurationManager.AppSettings["SMTP_HOST"];
            smtpClient.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_PORT"]);
            smtpClient.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["SMTP_ENABLE"]);
            smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SMTP_EMAIL"], ConfigurationManager.AppSettings["SMTP_PASSWORD"]);
        }
        public void SendEmail(Usuario usuario) {
            sendEmailToStudent(usuario);
            sendEmailToAdministrator(usuario);
        }
        public void sendEmailToStudent(Usuario usuario) {
            mailMessage = new MailMessage {
                From = new MailAddress(ConfigurationManager.AppSettings["SMTP_EMAIL"]),
                Subject = SUBJECT_STUDENT,
                Body = CreateEmailForStudent(usuario.Nombre),
                IsBodyHtml = true
            };
            mailMessage.To.Add(usuario.Email);
            smtpClient.Send(mailMessage);
        }
        public void sendEmailToAdministrator(Usuario usuario) {
            mailMessage = new MailMessage {
                From = new MailAddress(ConfigurationManager.AppSettings["SMTP_EMAIL"]),
                Subject = SUBJECT_ADMINISTRATOR,
                Body = CreateEmailForAdministrator(usuario.Nombre, usuario.Apellido, usuario.Email),
                IsBodyHtml = true
            };
            mailMessage.To.Add(ConfigurationManager.AppSettings["SMTP_EMAIL"]);
            smtpClient.Send(mailMessage);
        }
        public string CreateEmailForStudent(string nombre) {
            return $@"
                <p>Estimado/a {nombre},</p>
                <p>¡Felicidades! Tu registro en nuestra plataforma ha sido exitoso.</p>
                <p>Estamos encantados de darte la bienvenida a nuestros cursos. Ahora puedes acceder a todos nuestros recursos y comenzar tu aprendizaje.</p>
                <p>Si tienes alguna pregunta o necesitas más detalles sobre nuestros cursos, no dudes en comunicarte con nosotros a través de este correo electrónico o a través de los medios de contacto proporcionados en nuestra <a href='https://maxiprograma.com/'>página web</a>.</p>
                <p>¡Esperamos que disfrutes de tu experiencia de aprendizaje con nosotros!</p>
                <br>
                <p>Te saluda, MaxiPrograma.</p>
                <br>
                <hr>
                <br>
                <div> <a href='https://maxiprograma.com/'> <img src='https://maxiprograma.com/assets/images/maxi-programa-banner-solo.png' width='25%' height='100px'/> </a> </div>";
        }
        public string CreateEmailForAdministrator(string nombre, string apellido, string email) {
            return $@"
            <p>Estimado/a MaxiPrograma,</p>
            <p>Queremos informarte que un nuevo usuario se ha registrado en tu plataforma de cursos.</p>
            <p>Aquí están los detalles del usuario:</p>
            <ul>
                <li>Nombre: {nombre}</li>
                <li>Apellido: {apellido}</li>
                <li>Email: {email}</li>
            </ul>
            <p>Por favor, da la bienvenida al nuevo usuario y asegúrate de que tenga acceso a todos los recursos necesarios.</p>
            <br>
            <p>Te saluda, Equipo Administrativo.</p>
            <br>
            <hr>
            <br>
            <div> <a href='https://maxiprograma.com/'> <img src='https://maxiprograma.com/assets/images/maxi-programa-banner-solo.png' width='25%' height='100px'/> </a> </div>";
        }
    }
}
