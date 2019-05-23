using Newtonsoft.Json;
using ProyectoDreamsBed.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoDreamsBed.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Principal()
        {
            Session["Frame"] = false;
            return View();
        }

        public ActionResult Buscador()
        {
            Session["Frame"] = false;
            return View();
        }

        public ActionResult Acerca()
        {
            Session["Frame"] = false;
            return View();
        }

        public ActionResult Contacto()
        {
            Session["Frame"] = false;
            return View();
        }

        public ActionResult MiCuenta()
        {
            Session["Frame"] = false;
            return View();
        }

        public ActionResult Producto(string name, string id)
        {
            ViewBag.Name = name;
            ViewBag.Titulo = id;
            Session["Frame"] = false;

            CrearJson json = new CrearJson();
            DataTable tabla = json.exportTableaJson(id);
            Response.Write(JsonConvert.SerializeObject(tabla, Formatting.Indented));
            ViewData["DatosProducto"] = JsonConvert.SerializeObject(tabla, Formatting.Indented);
            return View();
            
        }
    }
}