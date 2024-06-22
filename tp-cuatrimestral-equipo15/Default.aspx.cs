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

        public string ImageUrl;
        protected void Page_Load(object sender, EventArgs e) {
          
            CursoNegocio cursoNegocio = new CursoNegocio();
            Session.Add("listaCursos", cursoNegocio.GetList());
            listaCursos.DataSource = Session["listaCursos"];
            listaCursos.DataBind();
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