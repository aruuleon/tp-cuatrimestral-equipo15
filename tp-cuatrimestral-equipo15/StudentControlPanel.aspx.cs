using Dominio;
using MoodleConection;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoodleConection;
using System.Threading.Tasks;

namespace tp_cuatrimestral_equipo15 {
    public partial class UserControlPanel : System.Web.UI.Page 
    {
        protected async void Page_Load(object sender, EventArgs e)
        {

            await ActualizarEstado();

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();


            List<string> ColumnList = new List<string> { "Identificador", "Nombre", "Apellido", "Email", "Avatar", "Activo", "Estado" };
            List<Usuario> UserList = await UsersFilter();

            userList.DataSource = UserList;
            userList.DataBind();
            columnList.DataSource = ColumnList;
            columnList.DataBind();
        }

        protected async Task ActualizarEstado()
        {

            List<Task> tasks = new List<Task>();


            tasks.Add(UpdateUserStatusAsync());


            await Task.WhenAll(tasks);
        }

        private async Task UpdateUserStatusAsync()
        {
            List<Usuario> usersMoodle = await UsuariosMoodle.GetUsers();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<Usuario> usersPlatform = usuarioNegocio.GetList();

            foreach (var moodle in usersMoodle)
            {
                foreach (var plataform in usersPlatform)
                {
                    if (moodle.IdMoodle == plataform.IdMoodle)
                    {
                        usuarioNegocio.Suspender(moodle);
                    }
                }
            }

        }

        private async Task<List<Usuario>> UsersFilter()
        {
            List<Usuario> usersMoodle = await UsuariosMoodle.GetUsers();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<Usuario> usersPlatform = usuarioNegocio.GetList();
            List<Usuario> filtrada = new List<Usuario>();

            foreach (var moodle in usersMoodle)
            {
                foreach (var plataform in usersPlatform)
                {
                    if (moodle.IdMoodle == plataform.IdMoodle)
                    {
                        filtrada.Add(plataform);
                    }
                }
            }
            return filtrada;    

        }



        protected string ImagenUrl(string imageUrl)
        {

            if (imageUrl.StartsWith("perfil-img-"))
            {
                imageUrl = "~/Archivos/Imagenes/Perfil/" + imageUrl;
            }

            return ResolveUrl(imageUrl);
        }


        protected string CheckStatus(int userId)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            Usuario user = usuarioNegocio.ListarById(userId);

            string status = "error";

            if (user.Suspendido == 0) status = "Activo";
            else if (user.Suspendido == 1) status = "Suspendido";

            return status;
        }

        protected string activeBotton2(int userId)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            Usuario user = usuarioNegocio.ListarById(userId);

            if (user.Suspendido == 0)
            {
                return "bi bi-check-square text-success";
            }
            else if (user.Suspendido == 1)
            {
                return "bi bi-x-square text-danger";
            }

            return "bi bi-circle-fill text-warning";
        }


        protected async void LinkButtonActivate2_Command(object sender, CommandEventArgs e)
        {
            CommandEventArgs commandEventArgs = e as CommandEventArgs;
            int userId = int.Parse(commandEventArgs.CommandArgument.ToString());
            int activar;

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario user = usuarioNegocio.ListarById(userId);

            if (user.Suspendido == 0)
            {
                user.Suspendido = 1;
            }
            else if (user.Suspendido == 1)
            {
                user.Suspendido = 0;
            }
            else return;

            usuarioNegocio.Suspender(user);
            await UsuariosMoodle.UpdateUser(user);
            Response.Redirect("StudentControlPanel.aspx", false);

        }
    }
}