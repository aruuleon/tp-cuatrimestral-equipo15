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
        Usuario usuario=new Usuario();
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
            
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
             

                if (usuarioNegocio.Login(usuario)) {
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
    }
}