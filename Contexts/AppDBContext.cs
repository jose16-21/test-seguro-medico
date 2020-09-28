using Microsoft.EntityFrameworkCore;
using SegundoParcial.Entities;

namespace SegundoParcial
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Persona> Persona { get; set; }

        public DbSet<SegundoParcial.Entities.Proveedor> Proveedor { get; set; }

        public DbSet<SegundoParcial.Entities.Servicio> Servicio { get; set; }

        public DbSet<SegundoParcial.Entities.ServicioPersona> ServicioPersona { get; set; }

    }
}