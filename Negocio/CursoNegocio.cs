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
        public List<Curso> Listar()
        {
            List<Curso> listaCursos = new List<Curso>();
            try
            {
                accesoDatos.setearConsulta(
                    "SELECT ID, IdMoodle, Nombre, ImagenPortada, Descripcion, Programa, Precio, Visible, ConocimientosRequeridos FROM Cursos"
                );
                accesoDatos.ejecutarLectura();
                while (accesoDatos.Lector.Read())
                {
                    Curso curso = new Curso();

                    curso.ID = (int)accesoDatos.Lector["ID"];
                    curso.IdMoodle = (int)accesoDatos.Lector["IdMoodle"]; ;
                    curso.Nombre = (string)accesoDatos.Lector["Nombre"];

                    if (!(accesoDatos.Lector["Descripcion"] is DBNull))
                        curso.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    if (!(accesoDatos.Lector["ConocimientosRequeridos"] is DBNull))
                        curso.ConocimientosRequeridos = (string)accesoDatos.Lector["ConocimientosRequeridos"];
                    if (!(accesoDatos.Lector["Precio"] is DBNull))
                        curso.Precio = (decimal)accesoDatos.Lector["Precio"];
                    if (!(accesoDatos.Lector["Visible"] is DBNull))
                        curso.Visible = (bool)accesoDatos.Lector["Visible"];
                    else curso.Visible = false;
                    if (!(accesoDatos.Lector["ImagenPortada"] is DBNull))
                        curso.UrlPortada = (string)accesoDatos.Lector["ImagenPortada"];
                    if (!(accesoDatos.Lector["Programa"] is DBNull))
                        curso.UrlPrograma = (string)accesoDatos.Lector["Programa"];

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

        public Curso ListarByIdMoodle(int IdMoodle)
        {
            Curso curso = new Curso();
            try
            {
                accesoDatos.setearConsulta(
                    "SELECT C.ID, C.IdMoodle, C.Nombre, C.ImagenPortada, C.Descripcion, C.Programa, C.Precio, C.Visible, C.ConocimientosRequeridos FROM Cursos C WHERE IdMoodle = " + IdMoodle
                );
                accesoDatos.ejecutarLectura();
                

                while (accesoDatos.Lector.Read())
                {
                    

                    curso.ID = (int)accesoDatos.Lector["ID"];
                    curso.IdMoodle = (int)accesoDatos.Lector["IdMoodle"]; 
                    curso.Nombre = (string)accesoDatos.Lector["Nombre"];

                    if(!(accesoDatos.Lector["Descripcion"] is DBNull))
                        curso.Descripcion = (string)accesoDatos.Lector["Descripcion"]; 
                    if (!(accesoDatos.Lector["ConocimientosRequeridos"] is DBNull))
                        curso.ConocimientosRequeridos = (string)accesoDatos.Lector["ConocimientosRequeridos"];
                    if (!(accesoDatos.Lector["Precio"] is DBNull))
                        curso.Precio = (decimal)accesoDatos.Lector["Precio"];
                    if (!(accesoDatos.Lector["Visible"] is DBNull))
                        curso.Visible = (bool)accesoDatos.Lector["Visible"];
                    if (!(accesoDatos.Lector["ImagenPortada"] is DBNull))
                        curso.UrlPortada = (string)accesoDatos.Lector["ImagenPortada"];
                    if (!(accesoDatos.Lector["Programa"] is DBNull))
                        curso.UrlPrograma = (string)accesoDatos.Lector["Programa"];

                    
                }
                return curso;
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

        public int Agregar(Curso curso)
        {
            int idCurso;
            try
            {
                accesoDatos.setearConsulta(
                   "INSERT INTO Cursos(IdMoodle, Nombre, ImagenPortada, Descripcion, Programa, Precio, Visible, ConocimientosRequeridos)" +
                    " VALUES(@IdMoodle, @Nombre, @Descripcion, @ImagenPortada, @Programa, @Precio, @Visible, @ConocimientosRequeridos)"
                );
                accesoDatos.setearParametros("@IdMoodle", curso.IdMoodle);
                accesoDatos.setearParametros("@Nombre", curso.Nombre);
                accesoDatos.setearParametros("@Descripcion", curso.Descripcion);
                accesoDatos.setearParametros("@ConocimientosRequeridos", curso.ConocimientosRequeridos);
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
                accesoDatos.setearConsulta("UPDATE Cursos SET IdMoodle = @IdMoodle , Nombre = @Nombre, ImagenPortada = @ImagenPortada, Descripcion = @Descripcion, Programa = @Programa, Precio = @Precio, Visible = @Visible, ConocimientosRequeridos = @ConocimientosRequeridos WHERE Id = " + curso.ID);
                accesoDatos.setearParametros("@IdMoodle", curso.IdMoodle);
                accesoDatos.setearParametros("@Nombre", curso.Nombre);
                accesoDatos.setearParametros("@Descripcion", curso.Descripcion);
                accesoDatos.setearParametros("@ConocimientosRequeridos", curso.ConocimientosRequeridos);
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
        public void Eliminar(Curso curso)
        {
            try
            {
                accesoDatos.setearConsulta("DELETE FROM Cursos WHERE ID = @ID");
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
