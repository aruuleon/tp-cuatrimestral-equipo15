using Dominio;
using Negocio;
using MoodleConection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo15 {
    public partial class CourseControlPanel : System.Web.UI.Page {
        protected async void Page_Load(object sender, EventArgs e) {

            if(!Page.IsPostBack) Session["Moodle"] = false;

            List<Curso> CourseList = new List<Curso>();
            List<string> ColumnList = new List<string>();

            if ((bool)Session["Moodle"] == true)
            {
                CourseList = await CursosMoodleList();
                ColumnList = new List<string> { "Identificador", "Nombre", "ImagenPortada", "Habilitar" };
                courseList.DataSource = CourseList;
                courseList.DataBind();
                columnList.DataSource = ColumnList;
                columnList.DataBind();
            } 
            else
            {
                CursoNegocio cursoNegocio = new CursoNegocio();
                ColumnList = new List<string> { "Identificador", "Nombre", "Precio", "ImagenPortada", "Programa", "Editar", "Eliminar", "Estudiantes" };
                CourseList = cursoNegocio.GetList();
                courseList.DataSource = CourseList;
                courseList.DataBind();
                columnList.DataSource = ColumnList;
                columnList.DataBind();
            }

            
        }

        protected string ImagenUrl(string imageUrl)
        {

            if (imageUrl.StartsWith("curso-img-"))
            {
                imageUrl = "~/Archivos/Imagenes/Curso/" + imageUrl;
            }

            return ResolveUrl(imageUrl);
        }
        protected void LinkButtonEnable_Click(object sender, EventArgs e) {
            string script = "var myModal = new bootstrap.Modal(document.getElementById('ModalFormCourse')); myModal.show();";
            ScriptManager.RegisterStartupScript(this, GetType(), "OpenModalScript", script, true);
        }

        protected async Task<List<Curso>> CursosMoodleList()
        {
            List<Curso> cursoSimples = await CursosMoodle.GetCourses();
            List<Curso> cursos = new List<Curso>();
            foreach (var item in cursoSimples)
            {
                if (item.IdMoodle != 1)
                {   
                    Curso curso = new Curso();
                    curso = await CursosMoodle.GetCourseByID(item.IdMoodle);
                    cursos.Add(curso);
                }
            }

            return cursos;
        }

        protected void btnCursosDB_Click(object sender, EventArgs e)
        {
            Session["Moodle"] = false;
        }

        protected void btnCursosMoodle_Click(object sender, EventArgs e)
        {
            Session["Moodle"] = true;
        }
    }
}