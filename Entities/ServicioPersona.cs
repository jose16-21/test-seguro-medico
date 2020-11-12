using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial.Entities
{
    public class ServicioPersona
    {
        public Guid Id { get; set; }
        public Guid PersonaId { get; set; }
        public Guid ProveedorId { get; set; }
        public Guid ServicioId { get; set; }


    }
}
