using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector { get; set; }

        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=Plataforma_Cursos_TPC; integrated security=true");
            comando = new SqlCommand();
        }
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
                Lector = lector;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                int rowsAffected = comando.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ejecutarScalar()
        {

            int ID;
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                ID = (int)comando.ExecuteScalar();
                cerrarConexion();
                return ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void setearParametros(string name, object value)
        {
            comando.Parameters.AddWithValue(name, value);
        }
        public void cerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }
    }
}