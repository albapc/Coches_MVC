using Coches_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coches_MVC.Controllers
{
    public class OperacionesController : Controller
    {
        // GET: Operaciones
        public ActionResult Index()
        {
            AdministracionDatos ad = new AdministracionDatos();
            return View(ad.RecuperarOperaciones());
        }

        public ActionResult AltaOperacion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AltaOperacion(FormCollection collection)
        {
            AdministracionDatos ad = new AdministracionDatos();
            Operacion ope = new Operacion
            {
                Fecha = DateTime.Parse(collection["fecha"].ToString()),
                Tipo = collection["nombre"],
                Empleado = int.Parse(collection["ID_empleado"].ToString()),
                Cliente = int.Parse(collection["ID_cliente"].ToString()),
                Precio = float.Parse(collection["precio"].ToString()),
                Vehiculo = int.Parse(collection["ID_vehiculo"].ToString())
            };
            ad.AltaOperaciones(ope);
            return RedirectToAction("Index");
        }
    }
}