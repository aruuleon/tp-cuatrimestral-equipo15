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
            if(!IsPostBack) {
                Usuario usuario = (Usuario)Session["usuario"];
                if(isLoginOrRegister()) {
                    ShowOnlyPanel(LoginOrRegisterMenuPanel);
                } else if(usuario != null && usuario.TipoUsuario == TipoUsuario.ADMIN) {
                    ShowOnlyPanel(AdministratorMenuPanel);
                } else {
                    ShowOnlyPanel(UserMenuPanel);
                }
            }
        }
        public bool isLoginOrRegister() {
            string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            return (currentPage == "Login.aspx" || currentPage == "Register.aspx");
        }
        public void ShowOnlyPanel(Panel panelToShow) {
            Panel[] allPanels = { LoginOrRegisterMenuPanel, AdministratorMenuPanel, UserMenuPanel };
            foreach (Panel panel in allPanels) {
                panel.Visible = false;
            }
            panelToShow.Visible = true;
        }
    }
}