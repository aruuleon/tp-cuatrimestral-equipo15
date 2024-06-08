using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Seccion
    {
        public int ID { get; set; }
        public int NumSeccion { get; set; }

        public int IdCurso { get; set; }

        public string Titulo { get; set; }

        public string Cuerpo { get; set; }
    }
}
