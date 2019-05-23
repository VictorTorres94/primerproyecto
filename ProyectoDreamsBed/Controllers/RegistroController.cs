
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoDreamsBed.Models;

namespace ProyectoDreamsBed.Controllers
{
    public class RegistroController : Controller
    {

        // GET: Registro
        public ActionResult Registro()
        {
            // Cada vez que entro en la Vista de Registro compruebo si la session Usuario está abierta o no
            // Si no existe Usuario se devuelve la vista del Registro. Si ya hay usuario se devuelve la vista Principal
            if(Session["Usuario"] == null)
            {
                Session["Frame"] = false;
                ViewBag.Title = "Registro";
                if (TempData["Error"] != null)
                {
                    ViewData["Error"] = TempData["Error"];
                }
                else
                {
                    ViewData["Error"] = null;
                }
                if(TempData["ErrorRegistro"] != null)
                {
                    ViewData["ErrorRegistro"] = TempData["ErrorRegistro"];
                }
                else
                {
                    ViewData["ErrorRegistro"] = null;
                }

                return View();
            }
            else
            {
                return RedirectToAction("Principal", "Home");
            }
            
        }

        public ActionResult RegistroFrame()
        {
            Session["Frame"] = true;  
            return View();
        }

        public ActionResult ConfirmaRegistro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Entrar(string email, string password)
        {
            UsuarioLogin usuario = new UsuarioLogin(email, password);
            if (usuario.comprobarUsuario() == true)
            {
                Session["Usuario"] = email;
                return RedirectToAction("Principal", "Home");
            }
            else
            {;
                TempData["Error"] = "Email o contraseña inválidos";
                TempData["ErrorRegistro"] = null;
                return RedirectToAction("Registro", "Registro");
            }   
        }

        public ActionResult Salir()
        {
            Session["Usuario"] = null;
            Session.Abandon();
            return RedirectToAction("Principal", "Home");
        }

        public ActionResult Registrarse(string nombre, string apellidos, string emailRegistro, string passwordRegistro1, string passwordRegistro2)
        {
            if(passwordRegistro1 == passwordRegistro2 && passwordRegistro1 != "" && passwordRegistro2 != "")
            {
                Usuario usuario = new Usuario(emailRegistro, passwordRegistro1, nombre, apellidos, null);
                if(usuario.comprobarCorreo(emailRegistro) == false)
                {
                    if (usuario.registrarUsuario() == true)
                    {
                        Session["Usuario"] = emailRegistro;
                        return RedirectToAction("ConfirmaRegistro", "Registro");
                    }
                    else
                    {
                        return RedirectToAction("Registro", "Registro");
                    }
                }
                else
                {
                    TempData["ErrorRegistro"] = "El email ya está registrado como usuario";
                    TempData["Error"] = null;
                    return RedirectToAction("Registro", "Registro");
                }
            }
            else
            {
                return RedirectToAction("Registro", "Registro");
            }
        }
    }
}