using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio {
    public class UsuariosXCursosNegocio {
        private AccesoDatos accesoDatos = new AccesoDatos();
        public List<int> GetCoursesByUser(int userId) {
            List<int> listOfCourseIndentifiers = new List<int>();
            try {
                accesoDatos.setearConsulta("SELECT IdCurso FROM Usuarios_X_Cursos WHERE IdUsuario = " + userId);
                accesoDatos.ejecutarLectura();
                while (accesoDatos.Lector.Read()) {
                    listOfCourseIndentifiers.Add(accesoDatos.Lector.GetInt32(0));
                }
                return listOfCourseIndentifiers;
            } catch (Exception exception) {
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
            } catch (Exception exception) {
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
