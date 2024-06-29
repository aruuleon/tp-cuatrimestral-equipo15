using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo15 {
    public partial class CourseControlPanel : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
          

            CursoNegocio cursoNegocio = new CursoNegocio();
            //List<string> ColumnList = new List<string> { "Identificador", "Nombre", "Precio", "ImagenPortada", "Programa", "Editar", "Eliminar", "Estudiantes" };
            List<string> ColumnList = new List<string> { "Identificador", "Nombre", "ImagenPortada", "Habilitar" };
            List<Curso> CourseList = cursoNegocio.GetList();
            courseList.DataSource = CourseList;
            courseList.DataBind();
            columnList.DataSource = ColumnList;
            columnList.DataBind();
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
    }
}