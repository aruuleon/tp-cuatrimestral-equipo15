using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Dominio;
using Negocio;

namespace tp_cuatrimestral_equipo15
{
    public partial class DetallesCurso : System.Web.UI.Page {
        public Curso curso;
        protected void Page_Load(object sender, EventArgs e) {
            List<string> listaInformacionDocente = new List<string> {
                "Maximiliano Sar Fernández.Licenciado en Tecnología Educativa, Universidad Tecnológica Nacional Facultad Regional Buenos Aires, UTN FRBA. Técnico Superior en Programación y Técnico Superior en Sistemas Informáticos, Tecnológica Nacional Facultad Regional General Pacheco, UTN FRGP.",
                "Cuenta con más de diez años de experiencia en docencia universitaria, donde dicta materias relacionadas a la programación tanto para iniciantes con el paradigma estructurado como para avanzados bajo el paradigma orientado a objetos y diferentes frameworks, tecnologías y arquitecturas.",
                "Posee más de doce años de experiencia tanto en corporaciones como de manera freelance trabajando para empresas de gran envergadura cumpliendo distintos roles tales como desarrollador, analista funcional, líder de equipo, capacitador, consultor.",
                "Maximiliano es creador de contenido y divulgador de temas relacionados con la programación y la tecnología por medio de sus canales en YouTube e Instagram donde lo encuentran como “Maxi Programa”."
            };
            CursoNegocio cursoNegocio = new CursoNegocio();
            int id = !string.IsNullOrEmpty(Request.QueryString["id"]) ? int.Parse(Request.QueryString["id"]) : 1;
            curso = cursoNegocio.BuscarPorId(id);
            Usuario usuario = (Usuario)Session["usuario"];
            HyperLinkProgram.NavigateUrl = curso.Programa.ToString();
            informacionDocente.DataSource = listaInformacionDocente;
            informacionDocente.DataBind();
            CargarConocimientosRequeridos(curso);
            LabelPrice.Text = curso.Precio.ToString("C0", new System.Globalization.CultureInfo("es-AR"));
            if(CheckIfUserHasCourse(curso.ID, usuario.ID)) {
                HyperLinkGetOrView.Text = "Ver Curso";
                LabelPrice.Visible = false;
            } else {
                HyperLinkGetOrView.Text = "Obtener Curso";
            }
        }
        protected void CargarConocimientosRequeridos(Curso curso) {
            string[] conocimientosRequeridos = curso.ConocimientosRequeridos.Replace(".NET", "DOTNET").Split('.');
            StringBuilder stringBuilder = new StringBuilder();

            foreach (string conocimientoRequerido in conocimientosRequeridos) {
                if (!string.IsNullOrWhiteSpace(conocimientoRequerido)) {
                    stringBuilder.Append("<span style='font-size: 15px;'>" + conocimientoRequerido.Trim().Replace("DOTNET", ".NET") + ".</span><br />");
                }
            }
            LiteralConocimientosRequeridos.Text = stringBuilder.ToString();
        }
        protected bool CheckIfUserHasCourse(int courseId, int userId) {
            CursoNegocio cursoNegocio = new CursoNegocio();
            return cursoNegocio.CheckIfUserHasCourse(courseId, userId);
        }
    }
}