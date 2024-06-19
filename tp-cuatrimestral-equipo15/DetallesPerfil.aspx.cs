using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo15
{
    public partial class DetallesPerfil : System.Web.UI.Page
    { 
        public Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (Usuario)Session["usuario"];
            UsuarioNegocio UsuarioNegocio = new UsuarioNegocio();
            usuario = UsuarioNegocio.ListarById(usuario.ID);
            if (!IsPostBack)
            {
                lblApellido.Text = usuario.Apellido;
                lblNombre.Text = usuario.Nombre;
                lblEmail.Text = usuario.Email;
               
            }

            if (usuario.Avatar.StartsWith("perfil-img-"))
            {
                imgPerfil.ImageUrl = "~/Archivos/Imagenes/Perfil/" + usuario.Avatar;
            }
            else
            {
                imgPerfil.ImageUrl = usuario.Avatar;
            }
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModPerfil.aspx?", false);

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Usuario userLoggedIn = (Usuario)Session["usuario"];
            string redirectUrl = userLoggedIn.TipoUsuario == TipoUsuario.ADMIN ? "AdministratorHome.aspx" : "Default.aspx";
            Response.Redirect(redirectUrl, false);
        }
    }
}