using Coches_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coches_MVC.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            AdministracionDatos ad = new AdministracionDatos();
            return View(ad.RecuperarClientes());
        }

        public ActionResult AltaCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AltaCliente(FormCollection collection)
        {
            AdministracionDatos ad = new AdministracionDatos();
            Persona cli = new Persona
            {
                NIF = collection["NIF"],
                Nombre = collection["nombre"],
                Apellidos = collection["apellidos"],
                Telefono = collection["telefono"],
                Direccion = collection["direccion"],
                Email = collection["email"]
            };
            ad.AltaClientes(cli);
            return RedirectToAction("Index");
        }

        public ActionResult ModificacionCliente(int cod)
        {
            AdministracionDatos ad = new AdministracionDatos();
            Persona cli = ad.SelectCliente(cod);
            return View(cli);
        }

        [HttpPost]
        public ActionResult ModificacionCliente(FormCollection collection)
        {
            AdministracionDatos ad = new AdministracionDatos();
            Persona cli = new Persona
            {
                //variables objeto = variables formulario
                ID_Persona = int.Parse(collection["ID_Cliente"].ToString()),
                NIF = collection["NIF"].ToString(),
                Nombre = collection["nombre"].ToString(),
                Apellidos = collection["apellidos"].ToString(),
                Telefono = collection["telefono"].ToString(),
                Direccion = collection["direccion"].ToString(),
                Email = collection["email"].ToString()
            };
            ad.ModificarClientes(cli);
            return RedirectToAction("Index");
        }
    }
}