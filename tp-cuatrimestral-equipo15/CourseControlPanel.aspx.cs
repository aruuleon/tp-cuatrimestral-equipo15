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
using Bogus.DataSets;

namespace tp_cuatrimestral_equipo15 {
    public partial class CourseControlPanel : System.Web.UI.Page {
        CursoNegocio businessCourse = new CursoNegocio();
        public Curso course;
        protected async void Page_Load(object sender, EventArgs e) {

            ActualizarCursos();
            ActualizarCursosEliminados();
            Session["Validacion"] = "";
            if (!IsPostBack) {
                
                PanelPlatformCourse.Visible = true;
                PanelMoodleCourse.Visible = false;
                LinkButtonPlatformCourse_Click(sender, e);
            }
        }
        protected void LinkButtonPlatformCourse_Click(object sender, EventArgs e) { //boton lista plataforma
            List<string> ColumnList = new List<string> { "Identificador", "Nombre", "Precio", "ImagenPortada", "Programa", "Editar", "Activo", "Estudiantes" };
            AdjustSettings(ColumnList, businessCourse.GetList(), columnListPlatform, courseListPlatform, "Platform");
        }
        protected async void LinkButtonMoodleCourse_Click(object sender, EventArgs e) { //boton lista moodle
            List<string> ColumnList = new List<string> { "Identificador", "Nombre", "ImagenPortada", "Habilitar" };
            AdjustSettings(ColumnList, await CursosMoodleList(), columnListMoodle, courseListMoodle, "Moodle");
        }
        protected async void LinkButtonEnable_Command(object sender, CommandEventArgs e) { //Boton abrir modal
            Session["Argument"] = e;
            course = await CursosMoodle.GetCourseByID(Convert.ToInt32(e.CommandArgument));
            lblIdMoodle.Text = course.IdMoodle.ToString();
            lblNameFormCourse.Text = course.Nombre;
            imagenPortadaFormCourse.ImageUrl = course.ImagenPortada;
            lblValidacion.Text = (string)Session["Validacion"];
     
            string script = "var myModal = new bootstrap.Modal(document.getElementById('ModalFormCourse')); myModal.show();";
            ScriptManager.RegisterStartupScript(this, GetType(), "OpenModalScript", script, true);
        }
        protected async void LinkButtonConfirm_Click(object sender, EventArgs e) {  //Habilitar de Modal
            lblValidacion.Text = "";
            if (ValidateModal())
            {
                Curso courseToRegister = new Curso();
                courseToRegister.IdMoodle = int.Parse(lblIdMoodle.Text);
                courseToRegister.Nombre = lblNameFormCourse.Text;
                courseToRegister.ImagenPortada = imagenPortadaFormCourse.ImageUrl;
                courseToRegister.Resumen = txtResumeFormCourse.Text;
                courseToRegister.Descripcion = txtDescriptionFormCourse.Text;
                courseToRegister.ConocimientosRequeridos = txtRequiredKnowledgeFormCourse.Text;
                courseToRegister.Programa = txtProgramFormCourse.Text;
                courseToRegister.Precio = decimal.Parse(txtPriceFormCourse.Text);
                courseToRegister.Visible = true;
                await CursosMoodle.VisibleCourse(courseToRegister.IdMoodle, 1);
                businessCourse.Agregar(courseToRegister);

                string script = "var myModal = new bootstrap.Modal(document.getElementById('ModalFormCourse')); myModal.hide();";
                ScriptManager.RegisterStartupScript(this, GetType(), "CloseModalScript", script, true);
                Response.Redirect("CourseControlPanel.aspx", false);
            }


            string closeModalScript = @"
            var myModal = new bootstrap.Modal(document.getElementById('ModalFormCourse'));
            myModal.hide();
            document.body.classList.remove('modal-open');
            var modals = document.getElementsByClassName('modal-backdrop');
            while(modals.length > 0) {
                modals[0].parentNode.removeChild(modals[0]);
            }";
            ScriptManager.RegisterStartupScript(this, GetType(), "CloseModalOnErrorScript", closeModalScript, true);


            LinkButtonEnable_Command(sender, (CommandEventArgs)Session["Argument"]);

        }

        

        protected bool ValidateModal()
        {
            
            if (string.IsNullOrEmpty(txtResumeFormCourse.Text))
            {
                Session["Validacion"] = "Debe completar el Resumen";
                return false;
            }
            if (string.IsNullOrEmpty(txtDescriptionFormCourse.Text))
            {
                Session["Validacion"] = "Debe completar la Descripcion";
                return false;
            }
            if (string.IsNullOrEmpty(txtRequiredKnowledgeFormCourse.Text))
            {
                Session["Validacion"] = "Debe completar los Conocimientos requeridos";
                return false;
            }
            if (string.IsNullOrEmpty(txtPriceFormCourse.Text))
            {
                Session["Validacion"] = "Debe completar el Precio";
                return false;
            }
            if (decimal.Parse(txtPriceFormCourse.Text) < 0)
            {
                Session["Validacion"] = "El precio debe ser igual o mayor a 0";
                return false;
            }

            return true;
   
        }



        protected void AdjustSettings(List<string> ColumnList, List<Curso> CourseList, Repeater repeaterColumnList, Repeater repeaterCourseList, string table) {
            if(table == "Platform") {
                LinkButtonPlatformCourse.Style.Value = " background-color: #7b1fa2; color:#fff";
                LinkButtonMoodleCourse.Style.Value = " background-color: #fff; color:#7b1fa2; border: 1px solid #7b1fa2";
                ShowOnlyPanel(PanelPlatformCourse);
            } else if(table == "Moodle") {
                LinkButtonMoodleCourse.Style.Value = " background-color: #7b1fa2; color:#fff";
                LinkButtonPlatformCourse.Style.Value = " background-color: #fff; color:#7b1fa2; border: 1px solid #7b1fa2";
                ShowOnlyPanel(PanelMoodleCourse);
            }
            repeaterColumnList.DataSource = ColumnList;
            repeaterColumnList.DataBind();
            repeaterCourseList.DataSource = CourseList;
            repeaterCourseList.DataBind();
        }
        public void ShowOnlyPanel(Panel panelToShow) {
            Panel[] allPanels = { PanelPlatformCourse, PanelMoodleCourse };
            foreach (Panel panel in allPanels) {
                panel.Visible = false;
            }
            panelToShow.Visible = true;
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

        protected async void ActualizarCursosEliminados()
        {
            CursoNegocio cursoNegocio = new CursoNegocio();
            BusinessEnrollment businessEnrollment = new BusinessEnrollment();
            List<Curso> cursoModdle = await CursosMoodle.GetCourses();
            List<Curso> cursosDB = cursoNegocio.GetList();
            foreach (var db in cursosDB)
            {
                if (cursoModdle.Where(x => x.IdMoodle == db.IdMoodle).Count() <= 0)
                {
                    businessEnrollment.DeleteByCourse(db);
                    cursoNegocio.Eliminar(db);
                }

            }
        }


        protected async Task<List<Curso>> CursosMoodleList() {
            List<Curso> cursoSimples = await CursosMoodle.GetCourses();
            List<Curso> cursos = new List<Curso>();
            foreach (var item in cursoSimples) {
                if (item.IdMoodle != 1) {
                    CursoNegocio cursoNegocio = new CursoNegocio();
                    if (!cursoNegocio.Cargado(item.IdMoodle)) {
                        Curso curso = new Curso();
                        curso = await CursosMoodle.GetCourseByID(item.IdMoodle);
                        cursos.Add(curso);
                    }
                }
            }
            return cursos;
        }

        protected async void LinkButtonActivate_Command(object sender, CommandEventArgs e)
        {
            CommandEventArgs commandEventArgs = e as CommandEventArgs;
            int id = int.Parse(commandEventArgs.CommandArgument.ToString());
            int activar;

            CursoNegocio cursoNegocio = new CursoNegocio();
            Curso curso = cursoNegocio.BuscarPorId(id);
            if (curso.Visible)
            {
                curso.Visible = false;
                activar = 0;
            }
            else
            {
                curso.Visible = true;
                activar = 1;
            }
            cursoNegocio.Actualizar(curso);
            await CursosMoodle.VisibleCourse(curso.IdMoodle, activar);
            Response.Redirect("CourseControlPanel.aspx?", false);

        }
        protected string activeBotton(bool active)
        {
            if (active)
            {
                return "bi bi bi-check-square text-success";
            }

            return "bi bi-x-square text-danger";
        }
        protected void LinkButtonStudents_Command(object sender, CommandEventArgs e)
        {

            CommandEventArgs commandEventArgs = e as CommandEventArgs;
            int id = int.Parse(commandEventArgs.CommandArgument.ToString());
            Response.Redirect("StudentOnCoursePanel.aspx?CourseId=" + id, false);
        }

        
    }
}