using Coches_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coches_MVC.Controllers
{
    public class VehiculosController : Controller
    {
        // GET: Vehiculos
        public ActionResult Index()
        {
            AdministracionDatos ad = new AdministracionDatos();
            return View(ad.RecuperarVehiculos());
        }

        public ActionResult ModificacionVehiculo(int cod)
        {
            AdministracionDatos ad = new AdministracionDatos();
            Vehiculo veh = ad.SelectVehiculo(cod);
            return View(veh);
        }

        [HttpPost]
        public ActionResult ModificacionVehiculo(FormCollection collection)
        {
            AdministracionDatos ad = new AdministracionDatos();
            Vehiculo veh = new Vehiculo
            {
                ID_Vehiculo = int.Parse(collection["ID_Vehiculo"].ToString()),
                Marca = collection["marca"].ToString(),
                Modelo = collection["modelo"].ToString(),
                NumeroPuertas = int.Parse(collection["numeroPuertas"].ToString()),
                Color = collection["color"].ToString(),
                Kilometros = long.Parse(collection["kilometros"].ToString()),
                TipoVehiculo = collection["tipoVehiculo"].ToString(),
                Garantia = int.Parse(collection["garantia"].ToString()),
                EnStock = bool.Parse(collection["enStock"].ToString()),
                Fotografia = bool.Parse(collection["fotografia"].ToString())
            };
            ad.ModificarVehiculos(veh);
            return RedirectToAction("Index");
        }
    }
}