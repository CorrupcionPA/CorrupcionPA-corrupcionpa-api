using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;

namespace Corrupcion.Helpers
{
    public class CorrupcionContext: DbContext
    {
        protected readonly IConfiguration _configuration;

        public CorrupcionContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Corrupcion"), m => m.MigrationsAssembly("Corrupcion.API"));
        }

        public DbSet<Partidos> Partidos { get; set; }
        public DbSet<Politicos> Politicos { get; set; }
        public DbSet<Escandalos> Escandalos { get; set; }

    }
}
