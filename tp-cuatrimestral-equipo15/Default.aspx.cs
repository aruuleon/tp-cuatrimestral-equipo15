using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using MoodleConection;
using Negocio;

namespace tp_cuatrimestral_equipo15 {
    public partial class Default : System.Web.UI.Page {

        public string ImageUrl;
        protected void Page_Load(object sender, EventArgs e) {

            CursoNegocio cursoNegocio = new CursoNegocio();
            ActualizarCursos();

            Session.Add("listaCursos", FiltrarActivos());
            listaCursos.DataSource = Session["listaCursos"];
            listaCursos.DataBind();
        }
        protected async void ActualizarCursos()
        {
            List<Curso> cursoSimples = await CursosMoodle.GetCourses();
            List<Curso> cursos = new List<Curso>();
            foreach (var item in cursoSimples)
            {
                if (item.IdMoodle != 1)
                {
                    Curso curso = new Curso();
                    curso = await CursosMoodle.GetCourseByID(item.IdMoodle);
                    CursoNegocio cursoNegocio = new CursoNegocio();
                    if (cursoNegocio.Cargado(curso.IdMoodle))
                    {
                        cursoNegocio.Actualizar(curso);
                    }
                }
            }
        }

        protected List<Curso> FiltrarActivos()
        {
            CursoNegocio cursoNegocio = new CursoNegocio();
            List<Curso> cursoSimples = cursoNegocio.GetList();
            List<Curso> cursos = new List<Curso>();
            foreach (var item in cursoSimples)
            {
                if (item.Visible)
                {
                    cursos.Add(item);
                }
            }
            return cursos;
        }

        protected string ImagenUrl(string imageUrl)
        {

            if (imageUrl.StartsWith("curso-img-"))
            {
                imageUrl = "~/Archivos/Imagenes/Curso/" + imageUrl;
            }

            return ResolveUrl(imageUrl);
        }
    }
}