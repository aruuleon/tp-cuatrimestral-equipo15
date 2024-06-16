using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tp_cuatrimestral_equipo15 {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            var master = this.Master as Master;
            if (master != null) {
                master.MostrarMenu();
            }
            CursoNegocio cursoNegocio = new CursoNegocio();
            Session.Add("listaCursos", cursoNegocio.Listar());
            listaCursos.DataSource = Session["listaCursos"];
            listaCursos.DataBind();
        }
    }
}