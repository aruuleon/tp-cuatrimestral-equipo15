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
            List<string> ColumnList = new List<string> { "Identificador", "Nombre", "Precio", "ImagenPortada", "Programa", "Editar", "Eliminar" };
            List<Curso> CourseList = cursoNegocio.GetList();
            courseList.DataSource = CourseList;
            courseList.DataBind();
            columnList.DataSource = ColumnList;
            columnList.DataBind();
        }
    }
}