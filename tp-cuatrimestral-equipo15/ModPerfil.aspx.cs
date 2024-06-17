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
        int IdUsuarioMoodle = 101;//Id de Moodle del curso a trabajar
        public Usuario usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio UsuarioNegocio = new UsuarioNegocio();
                usuario = UsuarioNegocio.ListarByIdMoodle(IdUsuarioMoodle); //Busca el curso a modificar

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
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            usuario.Apellido= txtApellido.Text;
            usuario.Nombre = txtNombre.Text;

            if (txtImagen.PostedFile.FileName != "")
            {
                string rutaImagen = Server.MapPath("./Archivos/Imagenes/Perfil/");
                txtImagen.PostedFile.SaveAs(rutaImagen + "curso-img-" + usuario.IdMoodle + ".jpg");
                usuario.Avatar = "perfil-img-" + usuario.IdMoodle + ".jpg";
            }
            UsuarioNegocio UsuarioNegocio = new UsuarioNegocio();

            UsuarioNegocio.ModificarByIdMoodle(usuario);

            Response.Redirect("Detalles.aspx", false);//CAmbiar
        }
    }
}