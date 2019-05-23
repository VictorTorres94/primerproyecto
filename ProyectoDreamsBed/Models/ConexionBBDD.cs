using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoDreamsBed.Models
{
    public class ConexionBBDD
    {
        private string cadenaConexion;
        private SqlConnection conexion;

        public ConexionBBDD()
        {
            this.cadenaConexion = ConfigurationManager.ConnectionStrings["DreamsBed"].ConnectionString;
        }

        public void abrirConexion()
        {
            this.conexion = new SqlConnection(cadenaConexion);
            this.conexion.Open();
        }

        public void cerrarConexion()
        {
            this.conexion.Close();
        }

        public DataTable ejecutarConsulta(string consulta)
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand(consulta, this.conexion);
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            adapter.Fill(tabla);
            return tabla;
        }

        public bool ejecutarInsercion(string insercion)
        {
            try
            {
                SqlCommand comando = new SqlCommand(insercion, this.conexion);
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                return true;
            }
            catch(SqlException ex)
            {
                string mensaje = ex.Message;
                return false;
            }

        }
    }
}