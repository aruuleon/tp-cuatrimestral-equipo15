using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo15 {
    public partial class UserControlPanel : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<string> ColumnList = new List<string> { "Identificador", "Nombre", "Apellido", "Email", "Avatar", "Editar", "Eliminar" };
            List<Usuario> UserList = usuarioNegocio.GetList();
            userList.DataSource = UserList;
            userList.DataBind();
            columnList.DataSource = ColumnList;
            columnList.DataBind();
            
        }
        protected void DeleteUserButton_Click(object sender, EventArgs e) {
            CommandEventArgs commandEventArgs = e as CommandEventArgs;
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            usuarioNegocio.Remove(int.Parse(commandEventArgs.CommandArgument.ToString()));
            Response.Redirect(Request.RawUrl);
        }
        protected string ImagenUrl(string imageUrl)
        {

            if (imageUrl.StartsWith("perfil-img-"))
            {
                imageUrl = "~/Archivos/Imagenes/Perfil/" + imageUrl;
            }

            return ResolveUrl(imageUrl);
        }
    }
}