﻿using Dominio;
using MoodleConection;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_cuatrimestral_equipo15
{
    public partial class StudenOnCoursePanel : System.Web.UI.Page
    {
        public int courseId;
        protected async void Page_Load(object sender, EventArgs e)
        {
            courseId = !string.IsNullOrEmpty(Request.QueryString["CourseId"]) ? int.Parse(Request.QueryString["CourseId"]) : -1;
            if (courseId != -1)
            {
                await ActualizarEstado();
            }

            List<string> ColumnList = new List<string> { "Identificador", "Nombre", "Apellido", "Email", "Avatar", "Activo", "Estado" };
            List<Usuario> UserList = usuariosFiltrada();

            userList.DataSource = UserList;
            userList.DataBind();
            columnList.DataSource = ColumnList;
            columnList.DataBind();
        }

        protected async Task ActualizarEstado()
        {
            BusinessEnrollment businessEnrollment = new BusinessEnrollment();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<Usuario> usuarios = usuarioNegocio.GetList();
            CursoNegocio cursoNegocio = new CursoNegocio();
            Curso curso = cursoNegocio.BuscarPorId(courseId);
            BusinessEnrollment businessEnrol = new BusinessEnrollment();

            List<Task> tasks = new List<Task>();

            foreach (var user in usuarios)
            {
                tasks.Add(UpdateUserStatusAsync(user, curso.IdMoodle, courseId, businessEnrol));
            }

            await Task.WhenAll(tasks);
        }

        private async Task UpdateUserStatusAsync(Usuario user, int cursoIdMoodle, int courseId, BusinessEnrollment businessEnrol)
        {
            string status = await UsuariosMoodle.GetUserStatusInCourse(cursoIdMoodle, user.IdMoodle);
            CursoNegocio cursoNegocio = new CursoNegocio();
            Curso curso = cursoNegocio.ListarById(courseId);

            if (status == "Activo")
            {
                if (businessEnrol.GetStatusActive(user.ID, courseId) != "")
                {
                    businessEnrol.ModificarEnrollmentByIdUsuario(user, StateType.APPROVED, courseId);
                }
                else
                {
                    businessEnrol.Habilitar(new Enrollment(user.ID, curso.ID, curso.Precio), 1);
                }
            }
            else if (status == "Suspendido")
            {
                if (businessEnrol.GetStatusActive(user.ID, courseId) != "")
                {
                    businessEnrol.ModificarEnrollmentByIdUsuario(user, StateType.SUSPENDING, courseId);
                }
                else
                {
                    businessEnrol.Habilitar(new Enrollment(user.ID, curso.ID, curso.Precio), 0);
                }
            }
            else if (status == "No inscripto")
            {
                businessEnrol.ModificarEnrollmentByIdUsuario(user, StateType.REFUSED, courseId);
            }

        }



        protected string ImagenUrl(string imageUrl)
        {

            if (imageUrl.StartsWith("perfil-img-"))
            {
                imageUrl = "~/Archivos/Imagenes/Perfil/" + imageUrl;
            }

            return ResolveUrl(imageUrl);
        }


        protected List<Usuario> usuariosFiltrada()
        {
            BusinessEnrollment businessEnrollment = new BusinessEnrollment();
            List<Usuario> usuarios = businessEnrollment.GetUsersByCourse(courseId);
            List<Usuario> usuariosNuevos = new List<Usuario>();

            foreach (var item in usuarios)
            {
                if(CheckEnrollmentStatus(item.ID) != "Rechazado")
                {
                   usuariosNuevos.Add(item);
                }
            }
            return usuariosNuevos;
            
        }


        protected string CheckEnrollmentStatus(int userId)
        {
            BusinessEnrollment businessEnrollment = new BusinessEnrollment();
            string status = "";
            

            switch (businessEnrollment.GetStatus(userId, courseId))
            {
                case StateType.PENDING:
                    status = "Pendiente";
                    break;
                case StateType.APPROVED:
                    status = "Activo";
                    break;
                case StateType.REFUSED:
                    status = "Rechazado";
                    break;
                case StateType.SUSPENDING:
                    status = "Suspendido";
                    break;
            }

            return status;
        }
        protected string activeBotton2(int userId)
        {
            BusinessEnrollment businessEnrollment = new BusinessEnrollment();
            int active = 1;

            switch (businessEnrollment.GetStatus(userId, courseId))
            {
                
                case StateType.APPROVED:
                    active = 1;
                    break; 
                case StateType.SUSPENDING:
                    active = 0;
                    break;
                case StateType.PENDING:
                    active = 2;
                    break;
            }


            if (active == 1)
            {
                return "bi bi-check-square text-success";
            }
            else if (active ==0)
            {
                return "bi bi-x-square text-danger";
            }

            return "bi bi-circle-fill text-warning";
        }

        protected async void LinkButtonActivate2_Command(object sender, CommandEventArgs e)
        {
            CommandEventArgs commandEventArgs = e as CommandEventArgs;
            int id = int.Parse(commandEventArgs.CommandArgument.ToString());
            int activar;
            BusinessEnrollment businessEnrol = new BusinessEnrollment();
            Enrollment enrollment = new Enrollment();

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuario = usuarioNegocio.ListarById(id);
            string status = CheckEnrollmentStatus(usuario.ID);

            CursoNegocio cursoNegocio = new CursoNegocio();
            Curso curso = cursoNegocio.BuscarPorId(courseId);



            if (status == "Activo")
            {
                businessEnrol.ModificarEnrollmentByIdUsuario(usuario, StateType.SUSPENDING, courseId);
                activar = 1;
            }
            else if (status == "Suspendido")
            {
                businessEnrol.ModificarEnrollmentByIdUsuario(usuario, StateType.APPROVED, courseId);

                activar = 0;
            }
            else return;

            await UsuariosMoodle.SuspendOrActivateUser(curso.IdMoodle,usuario.IdMoodle,activar);
            Response.Redirect("StudentOnCoursePanel.aspx?CourseId=" + courseId, false);
        }
    }
}
