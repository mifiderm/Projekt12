using IznajmljivanjeAutomobila.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace IznajmljivanjeAutomobila.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>(); // Promijenio AppDbContext u ApplicationDbContext

            // Provjera postoji li korisnik sa specifičnim e-mailom
            var userEmail = "mia.vekic82@gmail.com";
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            if (user == null)
            {
                // Ako korisnik ne postoji, kreiraj ga
                user = new User
                {
                    Email = userEmail,     // Postavljanje Emaila
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("123") // Hashiranje lozinke
                };

                // Dodavanje korisnika u bazu
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
        }
    }
}
