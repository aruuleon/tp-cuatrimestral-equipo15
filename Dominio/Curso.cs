using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Curso
    {
        public int ID { get; set; }

        public int IdMoodle { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string UrlPortada { get; set; }

        public string UrlPrograma { get; set; }

        public decimal Precio { get; set; }

        public bool Visible { get; set; }

        public string ConocimientosRequeridos { get; set; }
    }
}
