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
        private const string SUBJECT_STUDENT_ACCOUNT_REGISTRATION = "MaxiPrograma - Registro Exitoso";
        private const string SUBJECT_ADMINISTRATOR_ACCOUNT_REGISTRATION = "MaxiPrograma - Tenes un nuevo estudiante";
        private const string SUBJECT_STUDENT_ENROLLMENT_COURSE_CONFIRMATION = "MaxiPrograma - Inscripción a Curso";

        public EmailService() {
            smtpClient = new SmtpClient();
            smtpClient.Host = ConfigurationManager.AppSettings["SMTP_HOST"];
            smtpClient.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_PORT"]);
            smtpClient.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["SMTP_ENABLE"]);
            smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SMTP_EMAIL"], ConfigurationManager.AppSettings["SMTP_PASSWORD"]);
        }
        public void SendEmailRegister(Usuario user) {
            sendEmailRegisterToStudent(user);
            sendEmailRegisterToAdministrator(user);
        }
        public void sendEmailRegisterToStudent(Usuario user) {
            mailMessage = new MailMessage {
                From = new MailAddress(ConfigurationManager.AppSettings["SMTP_EMAIL"]),
                Subject = SUBJECT_STUDENT_ACCOUNT_REGISTRATION,
                Body = CreateEmailForStudent(user.Nombre),
                IsBodyHtml = true
            };
            mailMessage.To.Add(user.Email);
            smtpClient.Send(mailMessage);
        }
        public void sendEmailRegisterToAdministrator(Usuario user) {
            mailMessage = new MailMessage {
                From = new MailAddress(ConfigurationManager.AppSettings["SMTP_EMAIL"]),
                Subject = SUBJECT_ADMINISTRATOR_ACCOUNT_REGISTRATION,
                Body = CreateEmailForAdministrator(user.Nombre, user.Apellido, user.Email),
                IsBodyHtml = true
            };
            mailMessage.To.Add(ConfigurationManager.AppSettings["SMTP_EMAIL"]);
            smtpClient.Send(mailMessage);
        }
        public void SendEmailEnrollmentToStudent(Usuario user, Curso course, int action) {
            mailMessage = new MailMessage {
                From = new MailAddress(ConfigurationManager.AppSettings["SMTP_EMAIL"]),
                Subject = SUBJECT_STUDENT_ENROLLMENT_COURSE_CONFIRMATION,
                Body = CreateEmailEnrollmentForStudent(user.Nombre, course.Nombre, action),
                IsBodyHtml = true
            };
            mailMessage.To.Add(user.Email);
            smtpClient.Send(mailMessage);
        }
        public void SendEmailEnrollmentToAdministrator(Usuario user, Curso course) {
            mailMessage = new MailMessage {
                From = new MailAddress(ConfigurationManager.AppSettings["SMTP_EMAIL"]),
                Subject = SUBJECT_STUDENT_ENROLLMENT_COURSE_CONFIRMATION,
                Body = CreateEmailEnrollmentForAdministrator(user.Nombre, user.Apellido, course.Nombre),
                IsBodyHtml = true
            };
            mailMessage.To.Add(ConfigurationManager.AppSettings["SMTP_EMAIL"]);
            smtpClient.Send(mailMessage);
        }
        public string CreateEmailForStudent(string firstname) {
            return $@"
                <p>Estimado/a {firstname},</p>
                <p>¡Felicidades! Tu registro en nuestra plataforma ha sido exitoso.</p>
                <p>Estamos encantados de darte la bienvenida a nuestros cursos. Ahora puedes acceder a todos nuestros recursos y comenzar tu aprendizaje.</p>
                <p>Si tenés alguna pregunta o necesitas más detalles sobre nuestros cursos, no dudes en comunicarte con nosotros a través de este correo electrónico o a través de los medios de contacto proporcionados en nuestra <a href='https://maxiprograma.com/'>página web</a>.</p>
                <p>¡Esperamos que disfrutes de tu experiencia de aprendizaje con nosotros!</p>
                <br>
                <p>Te saluda, MaxiPrograma.</p>
                <br>
                <hr>
                <br>
                <div> <a href='https://maxiprograma.com/'> <img src='https://maxiprograma.com/assets/images/maxi-programa-banner-solo.png' width='25%' height='100px'/> </a> </div>";
        }
        public string CreateEmailForAdministrator(string firstname, string lastname, string email) {
            return $@"
                <p>Estimado/a MaxiPrograma,</p>
                <p>Queremos informarte que un nuevo usuario se ha registrado en tu plataforma de cursos.</p>
                <p>Aquí están los detalles del usuario:</p>
                <ul>
                    <li><b>Nombre:</b> {firstname}</li>
                    <li><b>Apellido:</b> {lastname}</li>
                    <li><b>Email:</b> {email}</li>
                </ul>
                <p>Por favor, da la bienvenida al nuevo usuario y asegúrate de que tenga acceso a todos los recursos necesarios.</p>
                <br>
                <p>Te saluda, Equipo Administrativo.</p>
                <br>
                <hr>
                <br>
                <div> <a href='https://maxiprograma.com/'> <img src='https://maxiprograma.com/assets/images/maxi-programa-banner-solo.png' width='25%' height='100px'/> </a> </div>";
        }
        public string CreateEmailEnrollmentForAdministrator(string firstname, string lastname, string course) {
            return $@"
                <p>Estimado/a MaxiPrograma,</p>
                <p>Queremos informarte que un usuario solicitó una inscripción para un curso de la plataforma.</p>
                <p>Estos son los detalles de la misma:</p>
                <ul>
                    <li><b>Usuario:</b> {firstname} {lastname}</li>
                    <li><b>Curso:</b> {course}</li>
                </ul>
                <p>Por favor, verificá el estado de la solicitud.</p>
                <br>
                <p>Te saluda, Equipo Administrativo.</p>
                <br>
                <hr>
                <br>
                <div> <a href='https://maxiprograma.com/'> <img src='https://maxiprograma.com/assets/images/maxi-programa-banner-solo.png' width='25%' height='100px'/> </a> </div>";
        }
        public string CreateEmailEnrollmentForStudent(string firstname, string course, int action) {
            string approvedMessage = $@"<p>¡Felicidades! Tu inscripción al curso de <b>{course}</b> fue aprobada.</p> <p>Ya podés acceder a la plataforma y disfrutar del mismo.</p>";
            string refusedMessage = $@"<p>Lamentamos informarte que tu inscripción al curso de <b>{course}</b> fue rechazada.</p> <p>Te pedimos verificar los detalles de tu medio de pago y volver a intentarlo.</p>";
            string selectedMessage = action == 1 ? approvedMessage : refusedMessage;
            return $@"
                <p>Estimado/a {firstname},</p>
                {selectedMessage}
                <p>Si tenés alguna pregunta o necesitas más detalles sobre nuestros cursos, no dudes en comunicarte con nosotros a través de este correo electrónico o a través de los medios de contacto proporcionados en nuestra <a href='https://maxiprograma.com/'>página web</a>.</p>
                <br>
                <p>Te saluda, MaxiPrograma.</p>
                <br>
                <hr>
                <br>
                <div> <a href='https://maxiprograma.com/'> <img src='https://maxiprograma.com/assets/images/maxi-programa-banner-solo.png' width='25%' height='100px'/> </a> </div>";
        }
    }
}
