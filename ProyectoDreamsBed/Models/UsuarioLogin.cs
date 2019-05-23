using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoDreamsBed.Models
{
    public class UsuarioLogin
    {
        [DataType(DataType.EmailAddress)]
        private string emailUsuarioLogin;
        [DataType(DataType.Password)]
        private string passwordUsuarioLogin;

        public UsuarioLogin(string email, string pass)
        {
            this.emailUsuarioLogin = email;
            this.passwordUsuarioLogin = pass;
        }

        public bool comprobarUsuario()
        {
            ConexionBBDD conexionBD = new ConexionBBDD();
            conexionBD.abrirConexion();
            DataTable tabla = conexionBD.ejecutarConsulta("SELECT * FROM USUARIO WHERE CORREOUSUARIO = '" + this.emailUsuarioLogin + "' AND PASSWORDUSUARIO = '" + this.passwordUsuarioLogin + "'" + ";");
            var filas = tabla.Rows.Count;
            conexionBD.cerrarConexion();
            if (filas == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string MensajeError { get; set;}
    }
}