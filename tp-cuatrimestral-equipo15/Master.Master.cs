using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tp_cuatrimestral_equipo15 {
    public partial class Master : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {

            Usuario usuario = (Usuario)Session["usuario"];

           

            if (!(Page is Login) && !(Page is Register))
            {
                if (!Validacion.SesionActiva(usuario))
                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    if (Validacion.EsAdmin(usuario))
                    {
                        if (!(Page is AdministratorControlPanel || Page is AdministratorHome || Page is StudenOnCoursePanel || Page is UserControlPanel || Page is CourseControlPanel || Page is EnrollmentControlPanel || Page is AltaCurso))
                        {
                            Session.Add("error", "No tenes Permisos para acceder a esta pagina");
                            Response.Redirect("AdministratorHome.aspx");
                        }
                    }
                    else
                    {
                        if (Page is AdministratorControlPanel || Page is AdministratorHome || Page is StudenOnCoursePanel || Page is UserControlPanel || Page is CourseControlPanel || Page is EnrollmentControlPanel || Page is AltaCurso)
                        {
                            Session.Add("error", "No tenes Permisos para acceder a esta pagina");
                            Response.Redirect("Default.aspx");
                        }


                    }

                }
            }
            if (!Validacion.SesionActiva(usuario))
            {
                panelPerfilAlumno.Visible = false;
                panelPerfilAdmin.Visible = false;
                btnIngresarAlumno.Visible = true;
                btnIngresarAdmin.Visible = true;
            }else
            {
                panelPerfilAlumno.Visible = true;
                panelPerfilAdmin.Visible = true;
                btnIngresarAlumno.Visible = false;
                btnIngresarAdmin.Visible = false;

                UsuarioNegocio UsuarioNegocio = new UsuarioNegocio();
                usuario = UsuarioNegocio.ListarById(usuario.ID);

                if (usuario.Avatar.StartsWith("perfil-img-"))
                {
                    imgAvatarAlumno.ImageUrl = "~/Archivos/Imagenes/Perfil/" + usuario.Avatar;
                    imgAvatarAdmin.ImageUrl = "~/Archivos/Imagenes/Perfil/" + usuario.Avatar;
                }
                else
                {
                    imgAvatarAlumno.ImageUrl = usuario.Avatar;
                    imgAvatarAdmin.ImageUrl = usuario.Avatar;
                }
            }

            if (!IsPostBack)
            {

                if (isLoginOrRegister())
                {
                    ShowOnlyPanel(LoginOrRegisterHeaderPanel);
                }
                else if (usuario != null && usuario.TipoUsuario == TipoUsuario.ADMIN)
                {
                    ShowOnlyPanel(AdministratorHeaderPanel);
                }
                else
                {
                    ShowOnlyPanel(UserHeaderPanel);
                }
            }
        }
        public bool isLoginOrRegister() {
            string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            return (currentPage == "Login.aspx" || currentPage == "Register.aspx");
        }
        public void ShowOnlyPanel(Panel panelToShow) {
            Panel[] allPanels = { LoginOrRegisterHeaderPanel, AdministratorHeaderPanel, UserHeaderPanel };
            foreach (Panel panel in allPanels)
            {
                panel.Visible = false;
            }
            panelToShow.Visible = true;
        }
        protected void btnCerrarSesion_Click(object sender, EventArgs e) {
            Session["usuario"] = null;
            Response.Redirect("Login.aspx", false);
        }
    }
}