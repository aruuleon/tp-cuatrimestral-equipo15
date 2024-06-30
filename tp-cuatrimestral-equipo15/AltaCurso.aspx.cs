using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tp_cuatrimestral_equipo15
{
    public partial class AltaCurso : System.Web.UI.Page
    {
        bool modificar;
        public Curso curso = new Curso();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack) Session["Mod"] = true;


                modificar = (bool)Session["Mod"];
                int id = !string.IsNullOrEmpty(Request.QueryString["id"]) ? int.Parse(Request.QueryString["id"]) : 1;
                CursoNegocio cursoNegocio = new CursoNegocio();
                curso = cursoNegocio.ListarById(id); //Busca el curso a modificar

                if(modificar == true)
                {

                    txtPrograma.Text = curso.Programa;
                    txtConocimientos.Text = curso.ConocimientosRequeridos;
                    txtDescripcion.Text =curso.Descripcion;
                    txtResumen.Text = curso.Resumen;
                    txtPrecio.Text = ((float)curso.Precio).ToString();
                    imgCurso.ImageUrl = curso.ImagenPortada;

                    Session["Mod"] = false;
                } 
            }
            catch (Exception)
            {

                throw;
            }
           
   
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CourseControlPanel.aspx?", false);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
    
                Page.Validate();
                if (!Page.IsValid)
                {
                     return;
                    
                }
                curso.Precio = decimal.Parse(txtPrecio.Text);
                curso.Descripcion = txtDescripcion.Text;
                curso.ConocimientosRequeridos = txtConocimientos.Text;
                curso.Resumen=txtResumen.Text;
                curso.Programa=txtPrograma.Text;
                //curso.Visible = true;


                
                CursoNegocio cursoNegocio = new CursoNegocio();

                cursoNegocio.Modificar(curso);


                Response.Redirect("CourseControlPanel.aspx", false);//CAmbiar(Enviar parametros)

            }
            catch (Exception)
            {

                Response.Redirect("Error.aspx?", false);
            }
            
        }
    }
}