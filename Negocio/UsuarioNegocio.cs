using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        private AccesoDatos accesoDatos = new AccesoDatos();

        public bool Register(Usuario usuario) {
            try {
                accesoDatos.setearConsulta(
                    "INSERT into Usuarios(IdMoodle, Nombre, Apellido, Email, Contrasenia, Tipo) " +
                    "VALUES(@IdMoodle, @Nombre, @Apellido, @Email, @Contrasenia, @Tipo)"
                );
                accesoDatos.setearParametros("@IdMoodle", 104);
                accesoDatos.setearParametros("@Nombre", usuario.Nombre);
                accesoDatos.setearParametros("@Apellido", usuario.Apellido);
                accesoDatos.setearParametros("@Email", usuario.Email);
                accesoDatos.setearParametros("@Contrasenia", usuario.Contrasenia);
                accesoDatos.setearParametros("@Tipo", TipoUsuario.STUDENT);
                accesoDatos.ejecutarLectura();
                return true;
            } catch (Exception exception) {
                return false;
                throw exception;
            } finally {
                accesoDatos.cerrarConexion();
            }
        }
        public bool Login(Usuario usuario) {
            try {
                accesoDatos.setearConsulta("SELECT ID, Tipo FROM Usuarios " +
                                           "WHERE Email = @Email AND Contrasenia = @Contrasenia");
                accesoDatos.setearParametros("@Email", usuario.Email);
                accesoDatos.setearParametros("@Contrasenia", usuario.Contrasenia);
                accesoDatos.ejecutarAccion();

                while(accesoDatos.Lector.Read()) {
                    usuario.ID = (int)accesoDatos.Lector["ID"];
                    usuario.TipoUsuario = (bool)(accesoDatos.Lector["Tipo"]) ? TipoUsuario.ADMIN : TipoUsuario.STUDENT;
                    return true;
                }
                return false;
            } catch(Exception exception) {
                throw exception;
            } finally {
                accesoDatos.cerrarConexion();
            }
        }
        //public List<Usuario> listar()
        //{
        //    List<Usuario> listaUsuarios = new List<Usuario>();
        //    try
        //    {
        //        accesoDatos.setearConsulta("SELECT Id,NombreUsuario, Nombre, Apellido, Email, Contrasenia, Tipo from Usuarios "
        //        );
        //        accesoDatos.ejecutarLectura();
        //        while (accesoDatos.Lector.Read())
        //        {
        //            Usuario usuario = new Usuario();

        //            usuario.ID = (int)accesoDatos.Lector["Id"];
        //            usuario.Nombre = (string)accesoDatos.Lector["Nombre"];
        //            usuario.Contrasenia = (string)accesoDatos.Lector["Contrasenia"];
        //            usuario.Email = (string)accesoDatos.Lector["Email"];
        //            usuario.TipoUsuario = (bool)accesoDatos.Lector["Tipo"];
        //            usuario.Apellido = (string)accesoDatos.Lector["Apellido"];
        //            usuario.Email = (string)accesoDatos.Lector["NombreUsuario"];

        //            listaUsuarios.Add(usuario);
        //        }
        //        return listaUsuarios;
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
        //public void Modificar(Usuario usuario)
        //{
        //    try
        //    {
        //        accesoDatos.setearConsulta("Update Usuarios SET NombreUsuario=@NombreUsuario, Nombre=@Nombre, Apellido=@Apellido, Email=@Email, Contrasenia=@Contrasenia, Tipo=@Tipo WHERE ID = @ID");


        //        accesoDatos.setearParametros("@NombreUsuario", usuario.NombreUsuario);
        //        accesoDatos.setearParametros("@Nombre", usuario.Nombre);
        //        accesoDatos.setearParametros("@Apellido", usuario.Apellido);
        //        accesoDatos.setearParametros("@Email", usuario.Email);
        //        accesoDatos.setearParametros("@Contrasenia", usuario.Contraseña);
        //        accesoDatos.setearParametros("@Tipo", usuario.TipoUsuario);
        //        accesoDatos.setearParametros("@ID", usuario.ID);

        
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

        //public void Eliminar(Usuario usuario)
        //{
        //    try
        //    {
        //        accesoDatos.setearConsulta("DELETE FROM Usuarios WHERE ID = @ID");
        //        accesoDatos.setearParametros("@ID", usuario.ID);
        //        accesoDatos.ejecutarAccion();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //}

    }
}
