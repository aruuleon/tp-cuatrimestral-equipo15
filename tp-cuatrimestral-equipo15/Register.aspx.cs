using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using MoodleConection;
using System.Runtime.InteropServices.WindowsRuntime;

namespace tp_cuatrimestral_equipo15 {
    public partial class Register : System.Web.UI.Page {
        //private UsuariosMoodle usersMoodle = new UsuariosMoodle();
        protected void Page_Load(object sender, EventArgs e) {
            
        }
        protected async void RegisterButton_Click(object sender, EventArgs e) {
            try {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Usuario usuario = new Usuario(txtNombre.Text, txtApellido.Text, txtEmail.Text, txtContrasenia.Text);
                if(usuarioNegocio.UserInDb(usuario.Email)) {
                    lblUserInDb.Visible = true;
                    return;
                } else {
                    int idMoodle = await UsuariosMoodle.CreateUser(usuario);
                    if(idMoodle == -1) Response.Redirect("Login.aspx", false);
                    if (usuarioNegocio.Register(usuario, idMoodle)) {
                        //EmailService emailService = new EmailService();
                        //emailService.SendEmailRegister(usuario);
                        Response.Redirect("Login.aspx", false);
                    } else {
                        Response.Redirect("Register.aspx", false);
                    }
                }
            } catch(Exception exception) {
                Session.Add("error", exception.ToString());
            }
        }
    }
}