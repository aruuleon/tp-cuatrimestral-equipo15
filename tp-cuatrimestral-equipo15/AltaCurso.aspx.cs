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
        int IdCursoMoodle = 1;//Temporal Cambiar
        bool modificar;
        public Curso curso = new Curso();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (!IsPostBack)
                {
                    Session["Mod"] = false; //Temporal Cambiar
                    Session["todVal"] = true;
                }
                modificar = (bool)Session["Mod"];


                CursoNegocio cursoNegocio = new CursoNegocio();
                curso = cursoNegocio.ListarByIdMoodle(2);

                if(modificar == true)
                {
                    Session["todVal"] = false;

                    txtConocimientos.Text = curso.ConocimientosRequeridos;
                    txtDescripcion.Text =curso.Descripcion;
                    txtPrecio.Text = ((float)curso.Precio).ToString();
                    imgPortada.ImageUrl = "~/Archivos/Imagenes/Curso/" + curso.ImagenPortada;
                    


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
            Response.Redirect("DetallesCurso.aspx?", false);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
    
                Page.Validate();
                if ((bool)Session["todVal"] == false)
                {
                    validatorTxtImagen.IsValid = true;
                    validatorTxtPrograma.IsValid = true;
                }
                if (!Page.IsValid)
                {
                     return;
                    
                }

                curso.Precio = decimal.Parse(txtPrecio.Text);
                curso.Descripcion = txtDescripcion.Text;
                curso.ConocimientosRequeridos = txtConocimientos.Text;
                curso.Visible = true;


                if (txtImagen.PostedFile.FileName != "")
                {
                    string rutaImagen = Server.MapPath("./Archivos/Imagenes/Curso/");
                    txtImagen.PostedFile.SaveAs(rutaImagen + "curso-img-" + curso.IdMoodle + ".jpg");
                    curso.ImagenPortada = "curso-img-" + curso.IdMoodle + ".jpg";
                }
                if (txtPrograma.PostedFile.FileName != "")
                {
                    string rutaPrograma = Server.MapPath("./Archivos/ProgramasPDF/");
                    txtPrograma.PostedFile.SaveAs(rutaPrograma + "curso-prog-" + curso.IdMoodle + ".pdf");
                    curso.Programa = "curso-prog-" + curso.ID + ".pdf";
                }
                CursoNegocio cursoNegocio = new CursoNegocio();
                cursoNegocio.Modificar(curso);


                Response.Redirect("DetallesCurso.aspx?", false);

            }
            catch (Exception)
            {

                //Response.Redirect("Error.aspx?", false);
            }
            
        }
    }
}