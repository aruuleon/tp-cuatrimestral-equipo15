using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tp_cuatrimestral_equipo15 {
    public partial class Register : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {


            try {

                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }

                Usuario usuario = new Usuario(txtNombre.Text, txtApellido.Text, txtEmail.Text, txtContrasenia.Text);
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                EmailService emailService = new EmailService();



                if (!(Validacion.ValidarEmailRepetido(usuario)))
                {
                    if (usuarioNegocio.Register(usuario))
                    {
                        //emailService.SendEmail(usuario);
                        Response.Redirect("Login.aspx", true);
                    }
                    else
                    {
                        Response.Redirect("Register.aspx", false);
                    }
                }
                else
                {
                    
                    lblMensajeError.Text = "El email ya está registrado.";
                    lblMensajeError.Visible = true;
                }


            } catch(Exception exception) {
                Session.Add("error", exception.ToString());
            }

       
        }
    }
}