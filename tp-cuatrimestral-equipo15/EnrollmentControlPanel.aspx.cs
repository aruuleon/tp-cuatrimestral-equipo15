using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo15 {
    public partial class EnrollmentControlPanel : System.Web.UI.Page {
        private BusinessEnrollment businessEnrollment = new BusinessEnrollment();
        private UsuarioNegocio businessUser = new UsuarioNegocio();
        private CursoNegocio businessCourse = new CursoNegocio();
        private EmailService emailService = new EmailService();
        protected void Page_Load(object sender, EventArgs e) {
            List<string> ColumnList = new List<string> { "Identificador", "Curso", "Usuario", "Fecha Solicitud", "Precio", "Comprobante", "Autorización" };
            List<object> EnrollmentList = businessEnrollment.ListPending();
            enrollmentList.DataSource = EnrollmentList;
            enrollmentList.DataBind();
            columnList.DataSource = ColumnList;
            columnList.DataBind();
        }
        protected void LinkButton_Command(object sender, CommandEventArgs e) {
            string[] args = e.CommandArgument.ToString().Split('|');
            int enrollmentId = Convert.ToInt32(args[0]);
            Usuario user = businessUser.ListarById(Convert.ToInt32(args[1]));
            Curso course = businessCourse.BuscarPorId(Convert.ToInt32(args[2]));
            int action = e.CommandName == StateType.APPROVED ? 1 : 2;
            if(businessEnrollment.ApproveOrReject(action, enrollmentId)) {
                //emailService.SendEmailEnrollmentToStudent(user, course, action);
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}