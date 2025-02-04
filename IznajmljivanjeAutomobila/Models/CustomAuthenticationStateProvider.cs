using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using IznajmljivanjeAutomobila.Data;
using BCrypt.Net;
using IznajmljivanjeAutomobila.Models;
using System.Collections.Generic;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ProtectedSessionStorage _sessionStorage;
    private bool _initialized = false;

    public CustomAuthenticationStateProvider(ApplicationDbContext dbContext, ProtectedSessionStorage sessionStorage)
    {
        _dbContext = dbContext;
        _sessionStorage = sessionStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        if (!_initialized)
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        var storedUser = await _sessionStorage.GetAsync<string>("authUser");

        if (!storedUser.Success || string.IsNullOrEmpty(storedUser.Value))
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, storedUser.Value)
        };

        var identity = new ClaimsIdentity(claims, "apiauth");
        var user = new ClaimsPrincipal(identity);

        return new AuthenticationState(user);
    }

    public async Task InitializeAsync()
    {
        _initialized = true;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        await AddDefaultUser(); // Pozivamo metodu koja dodaje korisnika
        await Task.Delay(100); // Simulacija čekanja
    }

    public async Task<bool> LoginUserAsync(string email, string password)
    {
        // Provjera korisnika u bazi
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

        if (user == null)
        {
            return false; // Krivi email
        }

        // Provjera lozinke
        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        if (!isPasswordValid)
        {
            return false; // Kriva lozinka
        }

        // Ako su podaci ispravni, pohranjujemo korisnika u sesiju
        await _sessionStorage.SetAsync("authUser", email);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, email)
        };

        var identity = new ClaimsIdentity(claims, "apiauth");
        var principal = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
        return true; // Prijava je uspješna
    }

    public async Task LogoutUserAsync()
    {
        await _sessionStorage.DeleteAsync("authUser"); // Brisanje korisnika iz sesije
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
    }

    // Metoda za dohvat trenutnog korisnika (email) iz sesije
    public async Task<string?> GetCurrentUserAsync()
    {
        var storedUser = await _sessionStorage.GetAsync<string>("authUser");
        return storedUser.Success ? storedUser.Value : null;
    }

    // Registracija korisnika (ovdje samo unosimo jednu korisničku lozinku i email)
    public async Task AddDefaultUser()
    {
        // Provjera da li korisnik već postoji u bazi
        var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == "mia.vekic82@gmail.com");
        if (existingUser != null)
        {
            return; // Ako korisnik već postoji, ne radimo ništa
        }

        // Hashiranje lozinke
        string password = "123"; // Lošinka koju želiš pohraniti
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        // Kreiranje novog korisnika
        var user = new User
        {
            Email = "mia.vekic82@gmail.com",
            PasswordHash = hashedPassword
        };

        // Spremanje korisnika u bazu
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
    }
}
