using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coches_MVC.Models
{
    public class Operacion
    {
        public int ID_Operacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public int Empleado { get; set; }
        public int Cliente { get; set; }
        public double Precio { get; set; }
        public int Vehiculo { get; set; }
    }
}