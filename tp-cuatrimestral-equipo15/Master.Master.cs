using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace tp_cuatrimestral_equipo15 {
    public partial class Master : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {

            Usuario usuario = (Usuario)Session["usuario"];
            if (!(Page is Login) && !(Page is Register) && !(Page is Default))
            {
                if (!Validacion.SesionActiva(usuario))
                {
                    Response.Redirect("Login.aspx", false);
                }
            }


            if (!IsPostBack) {
               
                if(isLoginOrRegister()) {
                    ShowOnlyPanel(LoginOrRegisterHeaderPanel);
                } else if(usuario != null && usuario.TipoUsuario == TipoUsuario.ADMIN) {
                    ShowOnlyPanel(AdministratorHeaderPanel);
                } else {
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
            foreach (Panel panel in allPanels) {
                panel.Visible = false;
            }
            panelToShow.Visible = true;
        }
    }
}