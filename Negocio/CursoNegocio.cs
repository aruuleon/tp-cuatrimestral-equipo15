﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                accesoDatos.setearConsulta("SELECT ID, IdMoodle, Nombre, ImagenPortada, Descripcion, ConocimientosRequeridos, Programa, Precio, Visible, Resumen FROM Cursos");
                accesoDatos.ejecutarLectura();
                while (accesoDatos.Lector.Read())
                {
                    Curso curso = new Curso();

                    curso.ID = (int)accesoDatos.Lector["ID"];
                    curso.IdMoodle = (int)accesoDatos.Lector["IdMoodle"]; ;
                    curso.Nombre = (string)accesoDatos.Lector["Nombre"];

                    if (!(accesoDatos.Lector["ImagenPortada"] is DBNull))
                        curso.ImagenPortada = (string)accesoDatos.Lector["ImagenPortada"];
                    if (!(accesoDatos.Lector["Descripcion"] is DBNull))
                        curso.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    if (!(accesoDatos.Lector["ConocimientosRequeridos"] is DBNull))
                        curso.ConocimientosRequeridos = (string)accesoDatos.Lector["ConocimientosRequeridos"];
                    if (!(accesoDatos.Lector["Programa"] is DBNull))
                        curso.Programa = (string)accesoDatos.Lector["Programa"];
                    if (!(accesoDatos.Lector["Precio"] is DBNull))
                        curso.Precio = (decimal)accesoDatos.Lector["Precio"];
                    if (!(accesoDatos.Lector["Visible"] is DBNull))
                        curso.Visible = (bool)accesoDatos.Lector["Visible"];
                    else curso.Visible = false;
                    if (!(accesoDatos.Lector["Resumen"] is DBNull))
                        curso.Resumen = (string)accesoDatos.Lector["Resumen"];

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
        public Curso BuscarPorId(int id) {
            Curso curso = new Curso();
            try {
                accesoDatos.setearConsulta("SELECT ID, IdMoodle, Nombre, ImagenPortada, Descripcion, ConocimientosRequeridos, Programa, Precio, Visible, Resumen FROM Cursos " +
                                           "WHERE Id = " + id);
                accesoDatos.ejecutarLectura();
                while (accesoDatos.Lector.Read()) {
                    curso.ID = (int)accesoDatos.Lector["ID"];
                    curso.IdMoodle = (int)accesoDatos.Lector["IdMoodle"];
                    curso.Nombre = (string)accesoDatos.Lector["Nombre"];
                    curso.ImagenPortada = (string)accesoDatos.Lector["ImagenPortada"];
                    curso.Resumen = (string)accesoDatos.Lector["Resumen"];
                    curso.Descripcion = (string)accesoDatos.Lector["Descripcion"];
                    curso.ConocimientosRequeridos = (string)accesoDatos.Lector["ConocimientosRequeridos"];
                    curso.Programa = (string)accesoDatos.Lector["Programa"];
                    curso.Precio = accesoDatos.Lector.GetDecimal(accesoDatos.Lector.GetOrdinal("Precio"));
                    curso.Visible = (bool)accesoDatos.Lector["Visible"];
                }
                return curso;
            } catch (Exception exception) {
                throw exception;
            } finally {
                accesoDatos.cerrarConexion();
            }
        }
        public Curso ListarByIdMoodle(int IdMoodle)
        {
            Curso curso = new Curso();
            try
            {
                accesoDatos.setearConsulta(
                    "SELECT C.ID, C.IdMoodle, C.Nombre, C.ImagenPortada, C.Descripcion, C.Programa, C.Precio, C.Visible, C.ConocimientosRequeridos,C.Resumen FROM Cursos C WHERE IdMoodle = " + IdMoodle
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
                        curso.ImagenPortada = (string)accesoDatos.Lector["ImagenPortada"];
                    if (!(accesoDatos.Lector["Programa"] is DBNull))
                        curso.Programa = (string)accesoDatos.Lector["Programa"];
                    if (!(accesoDatos.Lector["Resumen"] is DBNull))
                        curso.Resumen= (string)accesoDatos.Lector["Resumen"];


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
                   "INSERT INTO Cursos(IdMoodle, Nombre, ImagenPortada, Descripcion, Programa, Precio, Visible, ConocimientosRequeridos,Resumen)" +
                    " VALUES(@IdMoodle, @Nombre, @Descripcion, @ImagenPortada, @Programa, @Precio, @Visible, @ConocimientosRequeridos,@Resumen)"
                );
                accesoDatos.setearParametros("@IdMoodle", curso.IdMoodle);
                accesoDatos.setearParametros("@Nombre", curso.Nombre);
                accesoDatos.setearParametros("@Descripcion", curso.Descripcion);
                accesoDatos.setearParametros("@ConocimientosRequeridos", curso.ConocimientosRequeridos);
                accesoDatos.setearParametros("@ImagenPortada", curso.ImagenPortada);
                accesoDatos.setearParametros("@Programa", curso.Programa);
                accesoDatos.setearParametros("@Precio", curso.Precio);
                accesoDatos.setearParametros("@Visible", curso.Visible);
                accesoDatos.setearParametros("@Resumen", curso.Resumen);

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
                accesoDatos.setearConsulta("UPDATE Cursos SET IdMoodle = @IdMoodle, Nombre = @Nombre, ImagenPortada = @ImagenPortada, Descripcion = @Descripcion, Programa = @Programa, Precio = @Precio, Visible =@Visible , ConocimientosRequeridos =@ConocimientosRequeridos, Resumen=@Resumen WHERE Id =" + 3);
                accesoDatos.setearParametros("@IdMoodle", curso.IdMoodle);
                accesoDatos.setearParametros("@Nombre", curso.Nombre);
                accesoDatos.setearParametros("@Descripcion", curso.Descripcion);
                accesoDatos.setearParametros("@ConocimientosRequeridos", curso.ConocimientosRequeridos);
                accesoDatos.setearParametros("@ImagenPortada", curso.ImagenPortada);
                accesoDatos.setearParametros("@Programa", curso.Programa);
                accesoDatos.setearParametros("@Precio", curso.Precio);
                accesoDatos.setearParametros("@Visible", curso.Visible);
                accesoDatos.setearParametros("@Resumen", curso.Resumen);
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
        public List<int> GetCoursesByUser(int userId) {
            List<int> listOfCourseIndentifiers = new List<int>();
            try {
                accesoDatos.setearConsulta("SELECT IdCurso FROM Usuarios_X_Cursos WHERE IdUsuario = " + userId);
                accesoDatos.ejecutarLectura();
                while(accesoDatos.Lector.Read()) {
                    listOfCourseIndentifiers.Add(accesoDatos.Lector.GetInt32(0));
                }
                return listOfCourseIndentifiers;
            } catch(Exception exception) {
                throw exception;
            } finally {
                accesoDatos.cerrarConexion();
            }
        }
        public bool CheckIfUserHasCourse(int courseId, int userId) {
            try {
                accesoDatos.setearConsulta("SELECT COUNT(*) FROM Usuarios_X_Cursos WHERE IdCurso = " + courseId + " AND  IdUsuario = " + userId);
                accesoDatos.ejecutarLectura();
                while (accesoDatos.Lector.Read()) {
                    return accesoDatos.Lector.GetInt32(0) > 0;
                }
                return false;
            } catch(Exception exception) {
                throw exception;
            } finally {
                accesoDatos.cerrarConexion();
            }
        }
        public bool RegisterUserInTheCourse(int courseId, int userId) {
            try {
                accesoDatos.setearConsulta("INSERT INTO Usuarios_X_Cursos(IdCurso, IdUsuario) VALUES(@IdCurso, @IdUsuario)");
                accesoDatos.setearParametros("@IdCurso", courseId);
                accesoDatos.setearParametros("@IdUsuario", userId);
                return accesoDatos.ejecutarAccion();
            } catch (Exception exception) {
                throw exception;
            } finally {
                accesoDatos.cerrarConexion();
            }
        }
    }
}
