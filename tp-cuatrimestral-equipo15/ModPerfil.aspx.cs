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
    public partial class Perfil : System.Web.UI.Page
    {
        public Usuario usuario; 

        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                usuario = (Usuario)Session["usuario"];
                UsuarioNegocio UsuarioNegocio = new UsuarioNegocio();
                usuario = UsuarioNegocio.ListarById(usuario.ID);
                if (!IsPostBack)
                {
                    txtApellido.Text = usuario.Apellido;
                    txtNombre.Text = usuario.Nombre;
                    txtEmail.Text = usuario.Email;


                    if (usuario.Avatar.StartsWith("perfil-img-"))
                    {
                        imgPerfil.ImageUrl = "~/Archivos/Imagenes/Perfil/" + usuario.Avatar;
                    }
                    else
                    {
                        imgPerfil.ImageUrl = usuario.Avatar;
                    }
                }

               

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if(!Page.IsValid) return;


            usuario.Apellido= txtApellido.Text;
            usuario.Nombre = txtNombre.Text;

            if (txtImagen.PostedFile.FileName != "")
            {
                string rutaImagen = Server.MapPath("./Archivos/Imagenes/Perfil/");
                txtImagen.PostedFile.SaveAs(rutaImagen + "perfil-img-" + usuario.ID + ".jpg");
                usuario.Avatar = "perfil-img-" + usuario.ID + ".jpg";
            }
            UsuarioNegocio UsuarioNegocio = new UsuarioNegocio();

            UsuarioNegocio.ModificarById(usuario);

            Response.Redirect("DetallesPerfil.aspx?", false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetallesPerfil.aspx?", false);
        }
    }
}