using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Negocio {
    public class BusinessEnrollment {
        private AccesoDatos dataAccess = new AccesoDatos();
        private Enrollment FindById(int enrollmentId) {
            try {
                Enrollment enrollment = new Enrollment();
                dataAccess.setearConsulta("SELECT IDInscripcion, IDUsuario, IDCurso, FechaSolicitud, Costo, Estado FROM Inscripciones" +
                                          "WHERE IDInscripcion = " + enrollmentId);
                dataAccess.ejecutarLectura();
                if(dataAccess.Lector.Read()) {
                    enrollment.ID = (int)dataAccess.Lector["IDInscripcion"];
                    enrollment.UserID = (int)dataAccess.Lector["IDUsuario"];
                    enrollment.CourseID = (int)dataAccess.Lector["IDCurso"];
                    enrollment.EnrollmentDate = (DateTime)dataAccess.Lector["FechaSolicitud"];
                    enrollment.Price = (decimal)dataAccess.Lector["Costo"];
                    enrollment.State = (string)dataAccess.Lector["Estado"];
                }
                return enrollment;
            } catch (Exception exception) {
                throw exception;
            } finally {
                dataAccess.cerrarConexion();
            }
        }
        private List<Enrollment> List() {
            List<Enrollment> enrollmentList = new List<Enrollment>();
            try {
                dataAccess.setearConsulta("SELECT IDInscripcion, IDUsuario, IDCurso, FechaSolicitud, Costo, Estado FROM Inscripciones");
                dataAccess.ejecutarLectura();
                while (dataAccess.Lector.Read()) {
                    Enrollment enrollment = new Enrollment();
                    enrollment.ID = (int)dataAccess.Lector["IDInscripcion"];
                    enrollment.UserID = (int)dataAccess.Lector["IDUsuario"];
                    enrollment.CourseID = (int)dataAccess.Lector["IDCurso"];
                    enrollment.EnrollmentDate = (DateTime)dataAccess.Lector["FechaSolicitud"];
                    enrollment.Price = (decimal)dataAccess.Lector["Costo"];
                    enrollment.State = (string)dataAccess.Lector["Estado"];
                    enrollmentList.Add(enrollment);
                }
                return enrollmentList;
            } catch (Exception exception) {
                throw exception;
            } finally {
                dataAccess.cerrarConexion();
            }
        }
        public bool Generate(Enrollment enrollment) {
            try {
                dataAccess.setearConsulta("INSERT INTO Inscripciones(IDUsuario, IDCurso, FechaSolicitud, Costo, Estado) " +
                                          "VALUES(@IDUsuario, @IDCurso, @FechaSolicitud, @Costo, @Estado)");
                dataAccess.setearParametros("@IDUsuario", enrollment.UserID);
                dataAccess.setearParametros("@IDCurso", enrollment.CourseID);
                dataAccess.setearParametros("@FechaSolicitud", enrollment.EnrollmentDate);
                dataAccess.setearParametros("@Costo", enrollment.Price);
                dataAccess.setearParametros("@Estado", StateType.PENDING);
                return dataAccess.ejecutarAccion();
            } catch (Exception exception) {
                throw exception;
            } finally {
                dataAccess.cerrarConexion();
            }
        }
        public string GetStatus(int userId, int courseId) {
            try {
                dataAccess.setearConsulta("SELECT TOP 1 Estado FROM Inscripciones WHERE IDUsuario = " + userId + " AND IDCurso = " + courseId + " ORDER BY FechaSolicitud DESC");
                dataAccess.ejecutarLectura();
                if (dataAccess.Lector.Read()) {
                    return dataAccess.Lector.GetString(0);
                }
                return "";
            } catch (Exception exception) {
                throw exception;
            } finally {
                dataAccess.cerrarConexion();
            }
        }
        private bool ApproveOrReject(int action, int enrollmentId) {
            string state = action == 1 ? StateType.APPROVED : StateType.REFUSED; 
            try {
                dataAccess.setearConsulta("UPDATE Inscripciones SET Estado = " + state + " WHERE IDInscripcion = " + enrollmentId);
                return dataAccess.ejecutarAccion();
            } catch (Exception exception) {
                throw exception;
            } finally {
                dataAccess.cerrarConexion();
            }
        }
        public List<int> GetCoursesByUser(int userId) {
            List<int> listOfCourseIndentifiers = new List<int>();
            try {
                dataAccess.setearConsulta("SELECT IDCurso FROM Inscripciones WHERE IDUsuario = " + userId + " AND Estado = '" + StateType.APPROVED.ToString() + "'");
                dataAccess.ejecutarLectura();
                while (dataAccess.Lector.Read()) {
                    listOfCourseIndentifiers.Add(dataAccess.Lector.GetInt32(0));
                }
                return listOfCourseIndentifiers;
            } catch (Exception exception) {
                throw exception;
            } finally {
                dataAccess.cerrarConexion();
            }
        }
    }
}
