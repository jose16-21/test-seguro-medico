using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial.Entities
{
    public class ReponseJava
    {
        public string Mensage { get; set; }
        public int Autorizacion { get; set; }
        public string Estado { get; set; }
        public decimal Deducible { get; set; }
        public decimal TotalAcumulado { get; set; }
        public decimal Pendiente { get; set; }

    }
}
