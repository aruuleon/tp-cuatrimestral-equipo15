using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
        private BusinessEnrollment businessEnrollment = new BusinessEnrollment();
        private UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        private EmailService emailService = new EmailService();
        public Curso course;
        public string ImagenPortada;
        protected void Page_Load(object sender, EventArgs e) {

            List<string> listaInformacionDocente = new List<string> {
                "Maximiliano Sar Fernández.Licenciado en Tecnología Educativa, Universidad Tecnológica Nacional Facultad Regional Buenos Aires, UTN FRBA. Técnico Superior en Programación y Técnico Superior en Sistemas Informáticos, Tecnológica Nacional Facultad Regional General Pacheco, UTN FRGP.",
                "Cuenta con más de diez años de experiencia en docencia universitaria, donde dicta materias relacionadas a la programación tanto para iniciantes con el paradigma estructurado como para avanzados bajo el paradigma orientado a objetos y diferentes frameworks, tecnologías y arquitecturas.",
                "Posee más de doce años de experiencia tanto en corporaciones como de manera freelance trabajando para empresas de gran envergadura cumpliendo distintos roles tales como desarrollador, analista funcional, líder de equipo, capacitador, consultor.",
                "Maximiliano es creador de contenido y divulgador de temas relacionados con la programación y la tecnología por medio de sus canales en YouTube e Instagram donde lo encuentran como “Maxi Programa”."
            };
            CursoNegocio cursoNegocio = new CursoNegocio();
            int id = !string.IsNullOrEmpty(Request.QueryString["id"]) ? int.Parse(Request.QueryString["id"]) : 1;
            course = cursoNegocio.BuscarPorId(id);
            ImagenPortada = course.ImagenPortada.StartsWith("curso-img-") ? "~/Archivos/Imagenes/Curso/" + course.ImagenPortada : ImagenPortada = course.ImagenPortada;

            Usuario user = (Usuario)Session["usuario"];
            HyperLinkProgram.NavigateUrl = course.Programa.ToString();
            informacionDocente.DataSource = listaInformacionDocente;
            informacionDocente.DataBind();
            LabelPrice.Text = course.Precio.ToString("C0", new System.Globalization.CultureInfo("es-AR"));
            UploadRequiredKnowledge(course);
            UploadPaymentForm(usuarioNegocio.ListarById(user.ID), course);
            CheckEnrollmentStatus(user.ID, course.ID);
        }
        protected void LinkButtonGetOrView_Click(object sender, EventArgs e) {
            LinkButton linkButton = sender as LinkButton;
            if(linkButton != null && linkButton.Text == "Obtener Curso") {
                string script = "var myModal = new bootstrap.Modal(document.getElementById('ModalFormBuy')); myModal.show();";
                ScriptManager.RegisterStartupScript(this, GetType(), "OpenModalScript", script, true);
            }
        }
        protected void LinkButtonBuy_Click(object sender, EventArgs e) {
            Usuario userLogged = (Usuario)Session["usuario"];
            Usuario user = usuarioNegocio.ListarById(userLogged.ID);
            emailService.SendEmailEnrollmentToAdministrator(user, course);
            businessEnrollment.Generate(new Enrollment(user.ID, course.ID, course.Precio));
            CheckEnrollmentStatus(user.ID, course.ID);
            string script = "var myModal = new bootstrap.Modal(document.getElementById('ModalFormBuy')); myModal.hide();";
            ScriptManager.RegisterStartupScript(this, GetType(), "CloseModalScript", script, true);
        }
        protected void UploadRequiredKnowledge(Curso curso) {
            string[] conocimientosRequeridos = curso.ConocimientosRequeridos.Replace(".NET", "DOTNET").Split('.');
            StringBuilder stringBuilder = new StringBuilder();

            foreach (string conocimientoRequerido in conocimientosRequeridos) {
                if (!string.IsNullOrWhiteSpace(conocimientoRequerido)) {
                    stringBuilder.Append("<span style='font-size: 15px;'>" + conocimientoRequerido.Trim().Replace("DOTNET", ".NET") + ".</span><br />");
                }
            }
            LiteralConocimientosRequeridos.Text = stringBuilder.ToString();
        }
        protected void UploadPaymentForm(Usuario user, Curso course) {
            txtNombreFormBuy.Text = user.Nombre;
            txtApellidoFormBuy.Text = user.Apellido;
            txtEmailFormBuy.Text = user.Email;
            LabelPriceFormBuy.Text = course.Precio.ToString("C0", new System.Globalization.CultureInfo("es-AR"));
        }
        protected bool CheckIfUserHasCourse(int courseId, int userId) {
            UsuariosXCursosNegocio usuariosXCursosNegocio = new UsuariosXCursosNegocio();
            return usuariosXCursosNegocio.CheckIfUserHasCourse(courseId, userId);
        }
        protected void CheckEnrollmentStatus(int userId, int courseId) {
            switch (businessEnrollment.GetStatus(userId, courseId)) {
                case StateType.PENDING:
                    LinkButtonGetOrView.Text = "Solicitud en Proceso";
                    LinkButtonGetOrView.CssClass += " btn btn-warning";
                    break;
                case StateType.APPROVED:
                    LinkButtonGetOrView.Text = "Ver Curso";
                    LinkButtonGetOrView.CssClass += " btn btn-success";
                    LabelPrice.Visible = false;
                    break;
                default:
                    LinkButtonGetOrView.Text = "Obtener Curso";
                    LinkButtonGetOrView.CssClass += " btn btn-primary";
                    break;
            }
        }
    }
}