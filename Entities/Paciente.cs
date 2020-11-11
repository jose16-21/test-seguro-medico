using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial.Entities
{
    public class Paciente
    {
        public Guid Id { get; set; }
        public Guid TCPersonaId { get; set; }
        public int Codigo { get; set; }
        public int Telefono { get; set; }
        public DateTime FechaCobertura { get; set; }
        public decimal MontoCobertura { get; set; }
        public decimal MontoDeducible { get; set; }
        public string Estado { get; set; }
    }    
}
