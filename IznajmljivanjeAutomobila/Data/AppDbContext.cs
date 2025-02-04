using IznajmljivanjeAutomobila.Models;
using Microsoft.EntityFrameworkCore;

namespace IznajmljivanjeAutomobila.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Automobil> Automobili { get; set; }  // Dodajemo Automobil tablicu
        public DbSet<User> Users { get; set; }  // Dodajemo User tablicu
        public DbSet<Upit> Upiti { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
