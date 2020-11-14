using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial.Entities
{
    public class ReponseJava
    {
        [Key]
        public int Autorizacion { get; set; }
        public string Mensage { get; set; } 
        public string Alertas { get; set; }
        public string Estado { get; set; }
        public decimal Deducible { get; set; }
        public decimal TotalAcumulado { get; set; }
        public decimal Pendiente { get; set; }

    }
}
