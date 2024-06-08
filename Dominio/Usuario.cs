using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public bool TipoUsuario { get; set; }

    }
  
}
