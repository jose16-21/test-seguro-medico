using Microsoft.EntityFrameworkCore;
using SegundoParcial.Entities;

namespace SegundoParcial
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Final");
        }
        public DbSet<Persona> Persona { get; set; }        
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<ServicioPaciente> ServicioPaciente { get; set; }
        public DbSet<SegundoParcial.Entities.Factura> Factura { get; set; }


    }
}