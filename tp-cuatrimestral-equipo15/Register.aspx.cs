using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tp_cuatrimestral_equipo15 {
    public partial class Register : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            
        }

        protected void RegisterButton_Click(object sender, EventArgs e) {
            try {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Usuario usuario = new Usuario(txtNombre.Text, txtApellido.Text, txtEmail.Text, txtContrasenia.Text);
                if(usuarioNegocio.UserInDb(usuario.Email)) {
                    lblUserInDb.Visible = true;
                    Response.Redirect("Register.aspx", false);
                } else {
                    if (usuarioNegocio.Register(usuario)) {
                        EmailService emailService = new EmailService();
                        //emailService.SendEmail(usuario);
                        Response.Redirect("Login.aspx", false);
                    } else {
                        Response.Redirect("Register.aspx", false);
                    }
                }
            } catch(Exception exception) {
                Session.Add("error", exception.ToString());
            }
        }
    }
}