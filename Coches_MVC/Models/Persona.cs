using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coches_MVC.Models
{
    public class Persona
    {
        public int ID_Persona { get; set; }
        public string NIF { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
    }
}