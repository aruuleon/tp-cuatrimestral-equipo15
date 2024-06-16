using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
        public string ImagenPortada { get; set; }
        public string Resumen { get; set; }
        public string Descripcion { get; set; }
        public string ConocimientosRequeridos { get; set; }
        public string Programa { get; set; }
        public decimal Precio { get; set; }
        public bool Visible { get; set; }
    }
}
