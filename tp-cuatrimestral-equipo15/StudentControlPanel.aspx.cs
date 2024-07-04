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

namespace tp_cuatrimestral_equipo15
{
    public partial class UserControlPanel : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {

            await ActualizarEstado();
            if (!IsPostBack)
            {
                PanelPlatformUsers.Visible = true;
                PanelMoodleUsers.Visible = false;
                LinkButtonPlatformUsers_Click(sender, e);
            }

        }


        protected async void LinkButtonPlatformUsers_Click(object sender, EventArgs e)
        {
            List<string> ColumnList = new List<string> { "Identificador", "Nombre", "Apellido", "Email", "Avatar", "Activo", "Estado" };
            AdjustSettings(ColumnList, await UsersFilterPlatForm(), columnListPlatform, userListPlatform, "Platform");
        }

        protected async void LinkButtonMoodleUsers_Click(object sender, EventArgs e)
        {
            List<string> ColumnList = new List<string> { "Identificador", "Nombre", "Apellido", "Email", "Habilitar", "Estado" };
            AdjustSettings(ColumnList, await UsersFilterMoodle(), columnListMoodle, userListMoodle, "Moodle");
        }


        protected void AdjustSettings(List<string> ColumnList, List<Usuario> UsersList, Repeater repeaterColumnList, Repeater repeaterCourseList, string table)
        {
            if (table == "Platform")
            {
                LinkButtonPlatformUsers.Style.Value = " background-color: #7b1fa2; color:#fff";
                LinkButtonMoodleUsers.Style.Value = " background-color: #fff; color:#7b1fa2; border: 1px solid #7b1fa2";
                ShowOnlyPanel(PanelPlatformUsers);
            }
            else if (table == "Moodle")
            {
                LinkButtonMoodleUsers.Style.Value = " background-color: #7b1fa2; color:#fff";
                LinkButtonPlatformUsers.Style.Value = " background-color: #fff; color:#7b1fa2; border: 1px solid #7b1fa2";
                ShowOnlyPanel(PanelMoodleUsers);
            }
            repeaterColumnList.DataSource = ColumnList;
            repeaterColumnList.DataBind();
            repeaterCourseList.DataSource = UsersList;
            repeaterCourseList.DataBind();
        }

        public void ShowOnlyPanel(Panel panelToShow)
        {
            Panel[] allPanels = { PanelPlatformUsers, PanelMoodleUsers };
            foreach (Panel panel in allPanels)
            {
                panel.Visible = false;
            }
            panelToShow.Visible = true;
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

        private async Task<List<Usuario>> UsersFilterMoodle()
        {
            List<Usuario> usersMoodle = await UsuariosMoodle.GetUsers();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<Usuario> usersPlatform = usuarioNegocio.GetList();
            List<Usuario> filtrada = await UsuariosMoodle.GetUsers();

            foreach (var moodle in usersMoodle)
            {
                foreach (var plataform in usersPlatform)
                {
                    if (moodle.IdMoodle == plataform.IdMoodle)
                    {
                        Usuario user = filtrada.Where(x => x.IdMoodle == moodle.IdMoodle).First();
                        filtrada.Remove(user);
                    }

                }

            }
            return filtrada;

        }

        private async Task<List<Usuario>> UsersFilterPlatForm()
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

        protected string CheckStatusMoodle(int estado)
        {
            string status = "error";

            if (estado == 0) status = "Activo";
            else if (estado == 1) status = "Suspendido";

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

        protected async void LinkButtonActivateMoodle_Command(object sender, CommandEventArgs e)
        {
            CommandEventArgs commandEventArgs = e as CommandEventArgs;
            int userIdMoodle = int.Parse(commandEventArgs.CommandArgument.ToString());

            Usuario moodle = await UsuariosMoodle.GetUsersbyID(userIdMoodle);
            moodle.Contrasenia = "Usuario123!";

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            usuarioNegocio.Register(moodle, userIdMoodle);

            Usuario user = usuarioNegocio.ListarByIdMoodle(moodle.IdMoodle);
            Response.Redirect("StudentControlPanel.aspx", false);
        }

        
    }
}