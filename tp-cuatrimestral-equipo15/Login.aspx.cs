using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using MoodleConection;
using Negocio;
using Bogus;

namespace tp_cuatrimestral_equipo15 {
    public enum RequestStatus {
        REQUEST_SENT = 1,
        SUSPENDED_ACCOUNT = 2,
        UNREGISTERED_ACCOUNT = 3,
    }
    public partial class Login : System.Web.UI.Page {
        private EmailService emailService = new EmailService();
        private UsuarioNegocio businessUser = new UsuarioNegocio();
        Usuario usuario =new Usuario();
        protected void Page_Load(object sender, EventArgs e) {

            lblSuspendido.Visible = false;
            lblIncorrecto.Visible = false;

            if (Session["usuario"] != null)
            {
                if (Validacion.EsAdmin(Session["usuario"]))
                {
                    Response.Redirect("AdministratorHome.aspx");
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                usuario.Contrasenia = txtPassword.Text;
                usuario.Email = txtEmail.Text;
            }
        }
        protected void LoginButton_Click(object sender, EventArgs e) {
            
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
             

                if (businessUser.Login(usuario)) {

                    Usuario user = businessUser.ListarById(usuario.ID);
                    if (user.Suspendido == 1)
                    {
                        lblSuspendido.Visible = true;
                        return;
                    }

                    Session.Add("usuario", usuario);
                    if(usuario.TipoUsuario == TipoUsuario.ADMIN) {
                        Response.Redirect("AdministratorHome.aspx", false);
                    } else {
                        Response.Redirect("Default.aspx", false);
                    }
                }
                else
                {
                    lblIncorrecto.Visible = true;
                    return;
                }
            }


            catch (Exception exception)
            {
                Session.Add("error", exception.ToString());
            }
        }
        protected void LinkButtonRecoverPassword_Click(object sender, EventArgs e) {
            txtEmailFormRecoverPassword.Text = "";
            lblMessageRecoverPassword.Text = "";
            ClientScriptManager cs = Page.ClientScript;
            string script = "var myModal = new bootstrap.Modal(document.getElementById('ModalFormRecoverPassword')); myModal.show();";
            cs.RegisterStartupScript(this.GetType(), "OpenModalScript", script, true);
        }
        protected async void LinkButtonSendEmail_Click(object sender, EventArgs e) {
            int status;
            if(businessUser.UserInDb(txtEmailFormRecoverPassword.Text)) {
                Usuario user = (Usuario)businessUser.GetByEmail(txtEmailFormRecoverPassword.Text);
                if(user.Suspendido != 1) {
                    user.Contrasenia = GenerateRandomPassword();
                    businessUser.Update(user);
                    await UsuariosMoodle.UpdateUser(user);
                    //emailService.SendEmailRecoverPassword(user);
                    status = 1;
                } else {
                    status = 2;
                }
            } else {
                status = 3;
            }
            generateResponseMessage(status);
        }
        protected string GenerateRandomPassword() {
            var faker = new Faker();
            var password = new {
                LowerCase = faker.Random.Char('a', 'z').ToString(),
                UpperCase = faker.Random.Char('A', 'Z').ToString(),
                Digit = faker.Random.Number(0, 9).ToString(),
                SpecialChar = faker.Random.ListItem(new[] { "!", "@", "#", "$", "%" }),
                Rest = faker.Random.String2(4)
            };
            return $"{password.LowerCase}{password.LowerCase}{password.UpperCase}{password.Digit}{password.SpecialChar}{password.Rest}";
        }
        protected void generateResponseMessage(int status) {
            switch(status) {
                case (int)RequestStatus.REQUEST_SENT:
                    lblMessageRecoverPassword.Text = "Tu solicitud fue enviada exitosamente";
                    lblMessageRecoverPassword.CssClass = "text-success";
                    break;
                case (int)RequestStatus.SUSPENDED_ACCOUNT:
                    lblMessageRecoverPassword.Text = "Tu cuenta se encuentra suspendida. Contactate con el soporte";
                    lblMessageRecoverPassword.CssClass = "text-danger";
                    break;
                case (int)RequestStatus.UNREGISTERED_ACCOUNT:
                    lblMessageRecoverPassword.Text = "El correo electrónico ingresado no se encuentra registrado";
                    lblMessageRecoverPassword.CssClass = "text-primary";
                    break;
            }
        }
    }
}