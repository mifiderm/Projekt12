using IznajmljivanjeAutomobila.Models;
using Microsoft.EntityFrameworkCore;

namespace IznajmljivanjeAutomobila.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Automobil> Automobili { get; set; }  // Dodajemo Automobil tablicu

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }

}
