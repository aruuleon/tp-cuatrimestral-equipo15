using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

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
    }
}