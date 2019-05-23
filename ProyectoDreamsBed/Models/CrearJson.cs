using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProyectoDreamsBed.Models
{
    public class CrearJson
    {


        public CrearJson() { }

        public DataTable exportTableaJson(string nombreProducto)
        {
            ConexionBBDD conexion = new ConexionBBDD();
            conexion.abrirConexion();
            DataTable tabla = conexion.ejecutarConsulta("SELECT * FROM PRODUCTO WHERE NOMBREPRODUCTO = '" + nombreProducto + "'");
            conexion.cerrarConexion();
            return tabla;
        }
    }
}