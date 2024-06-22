using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo15
{
    public partial class StudenOnCoursePanel : System.Web.UI.Page
    {
        public int courseId; 
        protected void Page_Load(object sender, EventArgs e)
        {

            courseId = !string.IsNullOrEmpty(Request.QueryString["CourseId"]) ? int.Parse(Request.QueryString["CourseId"]) : -1;

            


                List<string> ColumnList = new List<string> { "Identificador", "Nombre", "Apellido", "Email", "Avatar", "Editar", "Suspender", "Estado" };
                List<Usuario> UserList;

                

                BusinessEnrollment businessEnrollment = new BusinessEnrollment();
                UserList = businessEnrollment.GetUsersByCourse(courseId);


                userList.DataSource = UserList;
                userList.DataBind();
                columnList.DataSource = ColumnList;
                columnList.DataBind();
            
        }
        protected void DeleteUserButton_Click(object sender, EventArgs e)
        {
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

        protected string CheckEnrollmentStatus(int userId)
        {
            BusinessEnrollment businessEnrollment = new BusinessEnrollment();
            string status = "";
            

            switch (businessEnrollment.GetStatus(userId, courseId))
            {
                case StateType.PENDING:
                    status = "Pendiente";
                    break;
                case StateType.APPROVED:
                    status = "Activo";
                    break;
            }
            return status;
        }
    }
}
