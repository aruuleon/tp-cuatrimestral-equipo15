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
            var master = this.Master as Master;
            if (master != null) {
                master.MostrarMenuLogin();
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            try {
                Usuario usuario = new Usuario(txtNombre.Text, txtApellido.Text, txtEmail.Text, txtContrasenia.Text);
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                EmailService emailService = new EmailService();
                if(usuarioNegocio.Register(usuario)) {
                    emailService.SendEmail(usuario);
                    Response.Redirect("Login.aspx", false);
                } else {
                    Response.Redirect("Register.aspx", false);
                }
            } catch(Exception exception) {
                Session.Add("error", exception.ToString());
            }

            //Page.Validate();
            //if (!Page.IsValid)
            //    return;

            //if (Validacion.ValidacionCampoVacio(txtNombre) /*|| Validacion.ValidacionCampoVacio(textApellido.Text) 
            //   || Validacion.ValidacionCampoVacio(textContraseña.Text) || Validacion.ValidacionCampoVacio(textEmail.Text)*/)
            //    {
            //        Session.Add("error", "Campos de texto vacios");
            //        Response.Redirect("Error.aspx");
            //    }
            //    else if (Validacion.ValidacionCampoNumero(txtNombre) /*|| Validacion.ValidacionCampoNumero(textApellido.Text)*/)
            //    {
            //        Session.Add("error", "Campos de texto vacios");
            //        Response.Redirect("Error.aspx");
            //    }
        }
    }
}