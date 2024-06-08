using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class SeccionNegocio
    {
        private AccesoDatos accesoDatos = new AccesoDatos();
        public List<Seccion> listar()
        {
            List<Seccion> listaSeccions = new List<Seccion>();
            try
            {
                accesoDatos.setearConsulta(
                 "SELECT ID, NumSeccion, Titulo, Cuerpo FROM Secciones"
                );
                accesoDatos.ejecutarLectura();
                while (accesoDatos.Lector.Read())
                {
                    Seccion seccion = new Seccion();

                    seccion.ID = (int)accesoDatos.Lector["ID"];
                    seccion.NumSeccion = (int)accesoDatos.Lector["NumSeccion"];
                    seccion.Titulo = (string)accesoDatos.Lector["Titulo"];
                    seccion.Cuerpo = (string)accesoDatos.Lector["Cuerpo"];

                    listaSeccions.Add(seccion);
                }
                return listaSeccions;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void Agregar(Seccion seccion)
        {

            try
            {
                accesoDatos.setearConsulta(
                    "INSERT INTO Secciones (NumSeccion,Titulo,Cuerpo) " +
                    "VALUES(@NumSeccion, @Titulo, @Cuerpo)"
                );

                accesoDatos.setearParametros("@NumSeccion", seccion.NumSeccion);
                accesoDatos.setearParametros("@Titulo", seccion.Titulo);
                accesoDatos.setearParametros("@Cuerpo", seccion.Cuerpo);
                accesoDatos.ejecutarAccion();

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
        public void Modificar(Seccion seccion)
        {
            try
            {
                accesoDatos.setearConsulta("UPDATE Secciones SET NumSeccion = @NumSeccion, Titulo = @Titulo, Cuerpo = @Cuerpo WHERE ID = " + seccion.ID);

                accesoDatos.setearParametros("@NumSeccion", seccion.NumSeccion);
                accesoDatos.setearParametros("@Titulo", seccion.Titulo);
                accesoDatos.setearParametros("@Cuerpo", seccion.Cuerpo);
                accesoDatos.ejecutarAccion();

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
        public void eliminar(Seccion seccion)
        {
            try
            {
                accesoDatos.setearConsulta("DELETE FROM Seccions WHERE ID = @ID");
                accesoDatos.setearParametros("@ID", seccion.ID);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


    }
}
