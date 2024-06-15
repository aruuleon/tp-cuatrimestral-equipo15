using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario {
        STUDENT = 0,
        ADMIN = 1,
    }
    public class Usuario
    {
        public int ID { get; set; }
        public int IdMoodle { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public string Avatar { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public Usuario() {
        }
        public Usuario(string nombre, string apellido, string email, string contrasenia) {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Contrasenia = contrasenia;
            TipoUsuario = TipoUsuario.STUDENT;
        }
        public Usuario(string email, string contrasenia, bool admin) {
            Email = email;
            Contrasenia = contrasenia;
            TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.STUDENT;
        }
    }
  
}
