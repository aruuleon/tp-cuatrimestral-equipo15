﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo15 {
    public partial class AdministratorControlPanel : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!(Validacion.EsAdmin(Session["usuario"])))
            {
                Session.Add("error", "No tenes Permisos para acceder a esta pagina");
                Response.Redirect("Default.aspx");
            }

        }
    }
}