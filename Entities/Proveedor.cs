using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial.Entities
{
    public class Proveedor
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Nit { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Estado { get; set; }
    }
}
