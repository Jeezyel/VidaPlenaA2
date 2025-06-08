using HOSPISIM.Entities;
using Microsoft.EntityFrameworkCore;

namespace HOSPISIM.Persistence
{
    public class VidaPlenaDbContext : DbContext
    {
        public VidaPlenaDbContext(DbContextOptions<VidaPlenaDbContext> options)
        : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }

        // Adicione outros DbSet<> aqui se tiver mais entidades
    }
}
