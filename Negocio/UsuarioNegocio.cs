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
        public List<Usuario> listar()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            try
            {
                accesoDatos.setearConsulta("SELECT Id,NombreUsuario,Contrasenia,Email,Tipo from Usuarios "
                );
                accesoDatos.ejecutarLectura();
                while (accesoDatos.Lector.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.ID = (int)accesoDatos.Lector[" Id "];
                    usuario.Nombre = (string)accesoDatos.Lector[" NombreUsuario "];
                    usuario.Contraseña = (string)accesoDatos.Lector[" Contrasenia "];
                    usuario.Email = (string)accesoDatos.Lector[" Email "];
                    usuario.TipoUsuario = (bool)accesoDatos.Lector[" Tipo "];

                    listaUsuarios.Add(usuario);
                }
                return listaUsuarios;
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

        public void Agregar(Usuario usuario)
        {

            try
            {
                accesoDatos.setearConsulta(" INSERT into Usuarios(NombreUsuario,Email,Contrasenia, Tipo) VALUES( @NombreUsuario , @Email,@Contrasenia,@Tipo)");

                accesoDatos.setearParametros(" @NombreUsuario ", usuario.Nombre);
                accesoDatos.setearParametros(" @Email ", usuario.Email);
                accesoDatos.setearParametros(" @ Contrasenia ", usuario.Contraseña);​
                accesoDatos.setearParametros(" @ Tipo ", usuario.TipoUsuario);​              
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
        public void Modificar(Usuario usuario)
        {
            try
            {
                accesoDatos.setearConsulta(" Update Usuarios SET NombreUsuario=@NombreUsuario,Email=@Email,Contrasenia=@Contrasenia,Tipo=@Tipo WHERE  ID = " + usuario.ID);

                accesoDatos.setearParametros(" @NombreUsuario ", usuario.Nombre);
                accesoDatos.setearParametros(" @Email ", usuario.Email);
                accesoDatos.setearParametros(" @ Contrasenia ", usuario.Contraseña);​
                accesoDatos.setearParametros(" @ Tipo ", usuario.TipoUsuario);​
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

    }
}
