using Microsoft.EntityFrameworkCore;
using IznajmljivanjeAutomobila.Models;
using System.Text.Json;

namespace IznajmljivanjeAutomobila.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet za entitete
        public DbSet<Automobil> Automobili { get; set; }
        public DbSet<Upit> Upiti { get; set; }
        public DbSet<User> Users { get; set; }


        // Konfiguracija za entitete
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Upit>()
                 .HasOne(a => a.Automobil)
                 .WithMany()
                 .HasForeignKey(a => a.AutomobilId);

            // Dodavanje inicijalnog korisnika ako ne postoji
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "mia.vekic",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("123") // Hashirana lozinka
            });
        }
    }
}
