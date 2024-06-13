using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo15 {
    public partial class Register : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            var master = this.Master as Master;
            if (master != null) {
                master.MostrarMenuLogin();
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {

            Page.Validate();
            if (!Page.IsValid)
                return;

            if (Validacion.ValidacionCampoVacio(textNombre) /*|| Validacion.ValidacionCampoVacio(textApellido.Text) 
               || Validacion.ValidacionCampoVacio(textContraseña.Text) || Validacion.ValidacionCampoVacio(textEmail.Text)*/)
                {
                    Session.Add("error", "Campos de texto vacios");
                    Response.Redirect("Error.aspx");
                }
                else if (Validacion.ValidacionCampoNumero(textNombre) /*|| Validacion.ValidacionCampoNumero(textApellido.Text)*/)
                {
                    Session.Add("error", "Campos de texto vacios");
                    Response.Redirect("Error.aspx");
                }

            
        }
    }
}