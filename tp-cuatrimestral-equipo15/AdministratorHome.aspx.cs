using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace tp_cuatrimestral_equipo15 {
    public partial class AdministratorHome : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
         
            SectionControlPanel studentControlPanel = new SectionControlPanel("Estudiantes", "StudentControlPanel.aspx", "fas fa-user-graduate");
            SectionControlPanel courseControlPanel = new SectionControlPanel("Cursos", "CourseControlPanel.aspx", "fas fa-book");
            SectionControlPanel administratorControlPanel = new SectionControlPanel("Administradores", "AdministratorControlPanel.aspx", "fas fa-user-shield");
            SectionControlPanel enrollmentControlPanel = new SectionControlPanel("Inscripciones", "EnrollmentControlPanel.aspx", "fas fa-file-alt");
            List<SectionControlPanel> SectionControlPanelList = new List<SectionControlPanel> { studentControlPanel, courseControlPanel, administratorControlPanel, enrollmentControlPanel };
            sectionControlPanelList.DataSource = SectionControlPanelList;
            sectionControlPanelList.DataBind();
        }
    }
}