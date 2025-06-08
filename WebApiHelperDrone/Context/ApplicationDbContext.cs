using WebApiHelperDrone.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiHelperDrone.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Alerta> Alerta { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Drone> Drones { get; set; }
        public DbSet<AreaRisco> AreasRisco { get; set; }
    }
}
