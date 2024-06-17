using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tp_cuatrimestral_equipo15 {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            
        }
        protected void LoginButton_Click(object sender, EventArgs e) {
            Usuario usuario;
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
                usuario = new Usuario();
                usuario.Contrasenia = txtPassword.Text;
                usuario.Email = txtEmail.Text;

                if (usuarioNegocio.Login(usuario))
                {

                    Session.Add("usuario", usuario);
                    Response.Redirect("Default.aspx", false);
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
    }
}