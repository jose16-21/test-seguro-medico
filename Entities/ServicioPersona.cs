using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial.Entities
{
    public class ServicioPaciente
    {
        public Guid Id { get; set; }
        public Guid PacienteId { get; set; }
        public Guid ProveedorId { get; set; }
        public Guid ServicioId { get; set; }


    }
}
