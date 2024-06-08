using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CursoNegocio
    {
        private AccesoDatos accesoDatos = new AccesoDatos();
        public List<Curso> listar()
        {
            List<Curso> listaCursos = new List<Curso>();
            try
            {
                accesoDatos.setearConsulta(
                    "SELECT ID, IdMoodle, Nombre, ImagenPortada, Descripcion, Programa, Precio, Visible FROM Cursos"
                );
                accesoDatos.ejecutarLectura();
                while (accesoDatos.Lector.Read())
                {
                    Curso curso = new Curso();

                    curso.ID = (int)accesoDatos.Lector["ID"];
                    curso.IdMoodle = (int)accesoDatos.Lector["IdMoodle"]; ;
                    curso.Nombre = (string)accesoDatos.Lector["Nombre"];
                    curso.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    curso.Precio = (decimal)accesoDatos.Lector["Precio"];
                    curso.Visible = (bool)accesoDatos.Lector["Visible"];
                    curso.UrlPrograma = (string)accesoDatos.Lector["ImagenPortada"];
                    curso.UrlPortada = (string)accesoDatos.Lector["Programa"];

                    listaCursos.Add(curso);
                }
                return listaCursos;
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
        public int agregar(Curso curso)
        {
            int idCurso;
            try
            {
                accesoDatos.setearConsulta(
                   "INSERT INTO Cursos(IdMoodle, Nombre, ImagenPortada, Descripcion, Programa, Precio, Visible)" +
                    " OUTPUT INSERTED.ID" +
                    " VALUES(@IdMoodle, @Nombre, @Descripcion, @ImagenPortada, @Programa, @Precio, @Visible)"
                );
                accesoDatos.setearParametros("@IdMoodle", curso.IdMoodle);
                accesoDatos.setearParametros("@Nombre", curso.Nombre);
                accesoDatos.setearParametros("@Descripcion", curso.Descripcion);
                accesoDatos.setearParametros("@ImagenPortada", curso.UrlPortada);
                accesoDatos.setearParametros("@Programa", curso.UrlPrograma);
                accesoDatos.setearParametros("@Precio", curso.Precio);
                accesoDatos.setearParametros("@Visible", curso.Visible);

                idCurso = accesoDatos.ejecutarScalar();
                return idCurso;
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
        public void Modificar(Curso curso)
        {
            try
            {
                accesoDatos.setearConsulta("UPDATE Cursos SET IdMoodle = @IdMoodle , Nombre = @Nombre, ImagenPortada = @ImagenPortada, Descripcion = @Descripcion, Programa = @Programa, Precio = @Precio, Visible = @Visible WHERE Id = " + curso.ID);
                accesoDatos.setearParametros("@IdMoodle", curso.IdMoodle);
                accesoDatos.setearParametros("@Nombre", curso.Nombre);
                accesoDatos.setearParametros("@Descripcion", curso.Descripcion);
                accesoDatos.setearParametros("@ImagenPortada", curso.UrlPortada);
                accesoDatos.setearParametros("@Programa", curso.UrlPrograma);
                accesoDatos.setearParametros("@Precio", curso.Precio);
                accesoDatos.setearParametros("@Visible", curso.Visible);
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
        public void eliminar(Curso curso)
        {
            try
            {
                accesoDatos.setearConsulta("DELETE FROM Cursos WHERE ID = @Codigo");
                accesoDatos.setearParametros("@ID", curso.ID);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
