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
                

                if (!IsPostBack)
                {
                    Session["Mod"] = false; //Temporal Cambiar(Cambia modo modificar o dar alta) // ESTO NO VA 
                    Session["todVal"] = true;
                }
                modificar = (bool)Session["Mod"]; //LE LLEGA TRUE O FALSE DEPENDE SI SE QUIERE MODIFICAR O NO
                int id = !string.IsNullOrEmpty(Request.QueryString["id"]) ? int.Parse(Request.QueryString["id"]) : 1;
                CursoNegocio cursoNegocio = new CursoNegocio();
                curso = cursoNegocio.ListarById(id); //Busca el curso a modificar

                if(modificar == true)
                {
                    Session["todVal"] = false;
                    txtPrograma.Text = curso.Programa;
                    txtConocimientos.Text = curso.ConocimientosRequeridos;
                    txtDescripcion.Text =curso.Descripcion;
                    txtResumen.Text = curso.Resumen;
                    txtPrecio.Text = ((float)curso.Precio).ToString();
                    //if (curso.ImagenPortada.StartsWith("curso-img-"))
                    //{
                    //    imgPortada.ImageUrl = "~/Archivos/Imagenes/Curso/" + curso.ImagenPortada;
                    //}
                    //else
                    //{
                    //    imgPortada.ImageUrl = curso.ImagenPortada;
                    //}

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
                if ((bool)Session["todVal"] == false)
                {
                    validatorTxtPrograma.IsValid = true;
                }
                if (!Page.IsValid)
                {
                     return;
                    
                }
                curso.Precio = decimal.Parse(txtPrecio.Text);
                curso.Descripcion = txtDescripcion.Text;
                curso.ConocimientosRequeridos = txtConocimientos.Text;
                curso.Resumen=txtResumen.Text;
                curso.Programa=txtPrograma.Text;
                curso.Visible = true;


                //if (txtImagen.PostedFile.FileName != "" && (!string.IsNullOrEmpty(txtImagenUrl.Text)))
                //{
                //    lblMensajeError.Text = "Eliga solo una manera de subir la imagen de portada..";
                //    lblMensajeError.Visible = true;
                //    return;
                //}
                //else if (txtImagen.PostedFile.FileName != "")
                //{
                //    string rutaImagen = Server.MapPath("./Archivos/Imagenes/Curso/");
                //    txtImagen.PostedFile.SaveAs(rutaImagen + "curso-img-" + curso.ID + ".jpg");
                //    curso.ImagenPortada = "curso-img-" + curso.ID + ".jpg";
                //}
                //else if(!string.IsNullOrEmpty(txtImagenUrl.Text))
                //{
                //    curso.ImagenPortada = txtImagenUrl.Text;
                //}
                //else if ((bool)Session["todVal"] == true)
                //{

                //    lblMensajeError.Text = "Alguno de los dos campos de imagen debe ser cargado... ";
                //    lblMensajeError.Visible = true;
                //    return;
                //}

                //if (txtPrograma.PostedFile.FileName != "")
                //{
                //    string rutaPrograma = Server.MapPath("./Archivos/ProgramasPDF/");
                //    txtPrograma.PostedFile.SaveAs(rutaPrograma + "curso-prog-" + curso.IdMoodle + ".pdf");
                //    curso.Programa = "curso-prog-" + curso.ID + ".pdf";
                //}
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