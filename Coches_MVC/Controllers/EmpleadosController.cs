using Coches_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coches_MVC.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Index()
        {
            AdministracionDatos ad = new AdministracionDatos();
            return View(ad.RecuperarEmpleados());
        }

        public ActionResult AltaEmpleado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AltaEmpleado(FormCollection collection)
        {
            AdministracionDatos ad = new AdministracionDatos();
            Persona emp = new Persona
            {
                NIF = collection["NIF"],
                Nombre = collection["nombre"],
                Apellidos = collection["apellidos"],
                Telefono = collection["telefono"],
                Direccion = collection["direccion"],
                Email = collection["email"]
            };
            ad.AltaEmpleados(emp);
            return RedirectToAction("Index");
        }

        public ActionResult ModificacionEmpleado(int cod)
        {
            AdministracionDatos ad = new AdministracionDatos();
            Persona emp = ad.SelectEmpleado(cod);
            return View(emp);
        }

        [HttpPost]
        public ActionResult ModificacionEmpleado(FormCollection collection)
        {
            AdministracionDatos ad = new AdministracionDatos();
            Persona emp = new Persona
            {
                ID_Persona = int.Parse(collection["ID_Empleado"].ToString()),
                NIF = collection["NIF"].ToString(),
                Nombre = collection["nombre"].ToString(),
                Apellidos = collection["apellidos"].ToString(),
                Telefono = collection["telefono"].ToString(),
                Email = collection["email"].ToString()
            };
            ad.ModificarEmpleados(emp);
            return RedirectToAction("Index");
        }
    }
}