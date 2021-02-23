using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coches_MVC.Models
{
    public class Vehiculo
    {

        public int ID_Vehiculo { get; set; } 
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int NumeroPuertas { get; set; }
        public string Color { get; set; }
        public long Kilometros { get; set; }
        public string TipoVehiculo { get; set; }
        public int Garantia { get; set; }
        public bool EnStock { get; set; }
        public bool Fotografia { get; set; }
    }
}