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
    public partial class Login : System.Web.UI.Page {
        private EmailService emailService = new EmailService();
        private UsuarioNegocio businessUser = new UsuarioNegocio();
        Usuario usuario =new Usuario();
        protected void Page_Load(object sender, EventArgs e) {


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
            string script = "var myModal = new bootstrap.Modal(document.getElementById('ModalFormRecoverPassword')); myModal.show();";
            ScriptManager.RegisterStartupScript(this, GetType(), "OpenModalScript", script, true);
        }
        protected async void LinkButtonSendEmail_Click(object sender, EventArgs e) {
            if(businessUser.UserInDb(txtEmailFormRecoverPassword.Text)) {
                Usuario user = (Usuario)businessUser.GetByEmail(txtEmailFormRecoverPassword.Text);
                if(user.Suspendido != 1) {
                    user.Contrasenia = GenerateRandomPassword();
                    businessUser.Update(user);
                    await UsuariosMoodle.UpdateUser(user);
                    emailService.SendEmailRecoverPassword(user);
                } else {
                    // esta suspendido de la plataforma
                }
            } else {
                // no esta en db
            }
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
    }
}