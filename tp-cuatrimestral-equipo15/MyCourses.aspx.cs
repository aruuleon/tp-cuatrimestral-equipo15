using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tp_cuatrimestral_equipo15 {
    public partial class MyCourses : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
           
            if (!IsPostBack) {
                Usuario usuario = (Usuario)Session["usuario"];
                if(usuario != null) {
                    BusinessEnrollment businessEnrollment = new BusinessEnrollment();
                    List<int> listOfCourseIndentifiers = businessEnrollment.GetCoursesByUser(usuario.ID);
                    List<Curso> ListOfCourses = (List <Curso>)Session["listaCursos"];
                    listaCursos.DataSource = ListOfCourses.Where(course => listOfCourseIndentifiers.Contains(course.ID)).ToList();
                    listaCursos.DataBind();
                }
            }
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