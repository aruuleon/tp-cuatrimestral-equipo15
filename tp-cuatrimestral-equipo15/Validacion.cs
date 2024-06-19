using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
namespace tp_cuatrimestral_equipo15
{
    public class Validacion
    {
        public static bool ValidacionCampoVacio(object control)
        {


            if (control is TextBox texto)
            {
                if (string.IsNullOrEmpty(texto.Text))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public static bool ValidacionCampoNumero(object control)
        {
            int Numero;
            if (control is TextBox texto)
            {
                if (int.TryParse(texto.Text, out Numero))
                {
                    // Es un número
                    return true;
                }
                else
                {
                    // No es un número
                    return false;
                }


            }

            return false;
        }
        public static bool ValidarEmailRepetido(Usuario usuario)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
         
            try
            {
                accesoDatos.setearConsulta("select ID from Usuarios where Email = @Email");
                accesoDatos.setearParametros("@Email", usuario.Email);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    return true; // Si encuentra un registro, el email está repetido.
                }
                return false; // Si no encuentra registros, el email no está repetido.
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SesionActiva(Object usuario)
        {
            Usuario usuarioAux = usuario != null ? (Usuario)usuario : null;
            if (usuarioAux != null && usuarioAux.ID != 0)
            {
                return true;
            }
            else return false;
        }

        public static bool EsAdmin(object usuario)
        {
            Usuario usuarioAux = usuario != null ? (Usuario)usuario : null;
            if (usuarioAux != null)
            {
                return usuarioAux.TipoUsuario == TipoUsuario.ADMIN ? true : false;
            }
            return false;


        }
    }
}