using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial.Entities
{
    public class Pagos
    {
        public Guid Id { get; set; }
        public int Boleta { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public Guid PacienteId { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal MontoPago { get; set; }        
        public string Estado { get; set; }
    }    
}
