﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo15 {
    public partial class Master : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {

        }
        public void MostrarMenu() {
            PanelMenu.Visible = true;
            PanelMenuLogin.Visible = false;
        }
        public void MostrarMenuLogin() {
            PanelMenu.Visible = false;
            PanelMenuLogin.Visible = true;
        }
    }
}