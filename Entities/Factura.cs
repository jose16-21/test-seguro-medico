using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial.Entities
{
    public class Factura
    {
        public Guid Id { get; set; }
        public Guid TCPacienteId { get; set; }
        public DateTime FechaFactura { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public decimal Monto { get; set; }        
        public int CantidadMedicamentos { get; set; }
    }    
}
