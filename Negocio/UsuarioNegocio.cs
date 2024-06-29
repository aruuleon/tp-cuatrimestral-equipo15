using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        private AccesoDatos accesoDatos = new AccesoDatos();
        public bool Register(Usuario usuario, int idMoodle) {
            try {
                accesoDatos.setearConsulta(
                    "INSERT into Usuarios(IdMoodle, Nombre, Apellido, Email, Contrasenia, Tipo, Avatar) " +
                    "VALUES(@IdMoodle, @Nombre, @Apellido, @Emal, @Contrasena, @Tipo, @Avatar)"
                );
                accesoDatos.setearParametros("@IdMoodle", idMoodle);
                accesoDatos.setearParametros("@Nombre", usuario.Nombre);
                accesoDatos.setearParametros("@Apellido", usuario.Apellido);
                accesoDatos.setearParametros("@Emal", usuario.Email);
                accesoDatos.setearParametros("@Contrasena", usuario.Contrasenia);
                accesoDatos.setearParametros("@Tipo", TipoUsuario.STUDENT);
                accesoDatos.setearParametros("@Avatar", "https://www.filepicker.io/api/file/Km01a73PSDr2Q74TCYoe");
                return accesoDatos.ejecutarAccion();
            } catch (Exception exception) {
                throw exception;
            } finally {
                accesoDatos.cerrarConexion();
            }
        }
        public bool Login(Usuario usuario) {
            try
            {

                accesoDatos.setearConsulta(
                   "SELECT ID, Tipo FROM Usuarios WHERE Email = '" + usuario.Email + "' AND Contrasenia = '" + usuario.Contrasenia + "'"
                );
                accesoDatos.ejecutarLectura();


                while (accesoDatos.Lector.Read())
                {
                    usuario.ID = (int)accesoDatos.Lector["ID"];
                    usuario.TipoUsuario = (bool)(accesoDatos.Lector["Tipo"]) ? TipoUsuario.ADMIN : TipoUsuario.STUDENT;
                    return true;
                }
                return false;
            }
            catch (NullReferenceException)
            {
                return false;
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
        public bool UserInDb(string email) {
            try {
                accesoDatos.setearConsulta("SELECT COUNT(*) FROM Usuarios WHERE Email = @Email");
                accesoDatos.setearParametros("@Email", email);
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
        public List<Usuario> GetList() {
            List<Usuario> userList = new List<Usuario>();
            try
            {
                accesoDatos.setearConsulta("SELECT Id, Nombre, Apellido, Email, Avatar from Usuarios WHERE Tipo = 0");
                accesoDatos.ejecutarLectura();
                while (accesoDatos.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.ID = (int)accesoDatos.Lector["Id"];
                    usuario.Nombre = (string)accesoDatos.Lector["Nombre"];
                    usuario.Apellido = (string)accesoDatos.Lector["Apellido"];
                    usuario.Email = (string)accesoDatos.Lector["Email"];
                    usuario.Avatar = (string)accesoDatos.Lector["Avatar"];
                    //usuario.IdMoodle= (int)accesoDatos.Lector["IdMoodle"];
                    userList.Add(usuario);
                }
                return userList;
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
        public bool Remove(int id) {
            try {
                accesoDatos.setearConsulta("DELETE FROM Usuarios WHERE ID = @ID");
                accesoDatos.setearParametros("@ID", id);
                return accesoDatos.ejecutarAccion();
            } catch (Exception exception) {
                throw exception;
            } finally {
                accesoDatos.cerrarConexion();
            }
        }
        public Usuario ListarById(int Id)
        {
            try
            {
                Usuario usuario = new Usuario();
                accesoDatos.setearConsulta("SELECT Id, IdMoodle, Nombre, Apellido, Email, Contrasenia, Tipo, Avatar from Usuarios WHERE ID = " + Id
                );
                accesoDatos.ejecutarLectura();
                while (accesoDatos.Lector.Read())
                {
                    usuario.ID = (int)accesoDatos.Lector["Id"];
                    usuario.IdMoodle = (int)accesoDatos.Lector["IdMoodle"];
                    usuario.Nombre = (string)accesoDatos.Lector["Nombre"];
                    usuario.Contrasenia = (string)accesoDatos.Lector["Contrasenia"];
                    usuario.Email = (string)accesoDatos.Lector["Email"];
                    if (!(bool)accesoDatos.Lector["Tipo"]) usuario.TipoUsuario = TipoUsuario.STUDENT;
                    else { usuario.TipoUsuario = TipoUsuario.ADMIN; }

                    usuario.Apellido = (string)accesoDatos.Lector["Apellido"];
                    usuario.Avatar = (string)accesoDatos.Lector["Avatar"];
                }
                return usuario;
            }
            catch (Exception excepción)
            {
                throw excepción;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        //public void Agregar(Usuario usuario)
        //{

        //    try
        //    {
        //        accesoDatos.setearConsulta(
        //            "INSERT into Usuarios(NombreUsuario, Nombre, Apellido, Email, Contrasenia, Tipo) " +
        //            "VALUES(@NombreUsuario, @Nombre, @Apellido, @Email, @Contrasenia, @Tipo)"
        //        );


        //        accesoDatos.setearParametros("@NombreUsuario", usuario.NombreUsuario);
        //        accesoDatos.setearParametros("@Nombre", usuario.Nombre);
        //        accesoDatos.setearParametros("@Apellido", usuario.Apellido);
        //        accesoDatos.setearParametros("@Email", usuario.Email);
        //        accesoDatos.setearParametros("@Contrasenia", usuario.Contraseña);
        //        accesoDatos.setearParametros("@Tipo", usuario.TipoUsuario);


        //        accesoDatos.ejecutarAccion();
        //    }
        //    catch (Exception excepción)
        //    {
        //        throw excepción;
        //    }
        //    finally
        //    {
        //        accesoDatos.cerrarConexion();
        //    }
        //}
        public void ModificarById(Usuario usuario)
        {
            try
            {
                accesoDatos.setearConsulta("Update Usuarios SET Nombre=@Nombre, Apellido=@Apellido, Email=@Email, Contrasenia=@Contrasenia, Tipo=@Tipo, Avatar=@Avatar WHERE ID = "  + usuario.ID);

                accesoDatos.setearParametros("@Nombre", usuario.Nombre);
                accesoDatos.setearParametros("@Apellido", usuario.Apellido);
                accesoDatos.setearParametros("@Email", usuario.Email);
                accesoDatos.setearParametros("@Contrasenia", usuario.Contrasenia);
                accesoDatos.setearParametros("@Tipo", usuario.TipoUsuario);
                accesoDatos.setearParametros("@Avatar", usuario.Avatar);



                accesoDatos.ejecutarAccion();

            }
            catch (Exception excepción)
            {
                throw excepción;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
        public void EliminarByIdMoodle(Usuario usuario)
        {
            try
            {
                accesoDatos.setearConsulta("DELETE FROM Usuarios WHERE IdMoodle = @IdMoodle");
                accesoDatos.setearParametros("@IdMoodle", usuario.IdMoodle);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

    }
}
