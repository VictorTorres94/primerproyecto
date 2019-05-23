using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ProyectoDreamsBed.Models
{
    public class Usuario
    {
        #region Atributos
        private string codigoUsuario;
        private string emailUsuario;
        private string passwordUsuario;
        private string nombreUsuario;
        private string apellidosUsuario;
        private DateTime? fxNacimientoUsuario;
        private string dniUsuario;
        private string codFacturacion;
        private string codDireccion;
        private string fotoUsuario;
        private string codTarjeta;
        private int? telefonoUsuario;
        #endregion

        public Usuario(string email, string pass, string nombre, string apellidos, DateTime? fecha, string dni = null, string facturacion = null, string direccion = null, string foto = null, string tarjeta = null, int? telefono = null)
        {
            this.emailUsuario = email;
            this.passwordUsuario = pass;
            this.nombreUsuario = nombre;
            this.apellidosUsuario = apellidos;
            this.fxNacimientoUsuario = fecha;
            this.dniUsuario = dni;
            this.codFacturacion = facturacion;
            this.codDireccion = direccion;
            this.fotoUsuario = foto;
            this.codTarjeta = tarjeta;
            this.telefonoUsuario = telefono;
        }

        public bool registrarUsuario()
        {
            ConexionBBDD conexion = new ConexionBBDD();
            conexion.abrirConexion();
            string sentencia = "INSERT INTO USUARIO (CORREOUSUARIO, PASSWORDUSUARIO, NOMBREUSUARIO, APELLIDOSUSUARIO, FXNACIMIENTO, DNIUSUARIO, CODIGOFACTURACION, CODIGODIRECCION, FOTOUSUARIO, CODIGOTARJETA, TELEFONOUSUARIO)" +
                " VALUES ('" + this.emailUsuario + "', '" + this.passwordUsuario + "', '" + this.nombreUsuario + "', '" + this.apellidosUsuario + 
                "', null, null, null, null, null, null, null)";
            bool registrado = conexion.ejecutarInsercion(sentencia);
            conexion.cerrarConexion();
            return registrado;
        }

        public bool comprobarCorreo(string correo)
        {
            ConexionBBDD conexion = new ConexionBBDD();
            conexion.abrirConexion();
            string consulta = "SELECT * FROM USUARIO WHERE CORREOUSUARIO = '" + correo + "'";
            DataTable tabla = conexion.ejecutarConsulta(consulta);
            var filas = tabla.Rows.Count;
            conexion.cerrarConexion();
            if (filas == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}