using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo15 {
    public partial class AdministratorHome : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Dictionary<string, string> SectionList = new Dictionary<string, string> {
                { "Estudiantes", "fas fa-user-graduate" },
                { "Cursos", "fas fa-book" },
                { "Administradores", "fas fa-user-shield" },
            };
            sectionList.DataSource = SectionList;
            sectionList.DataBind();
        }
    }
}