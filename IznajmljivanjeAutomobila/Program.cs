using IznajmljivanjeAutomobila.Data;
using IznajmljivanjeAutomobila.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Konfiguracija za DBContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dodavanje servisa za Blazor i autorizaciju
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Postavljanje AuthenticationStateProvider-a
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();

// Postavljanje sesije
builder.Services.AddScoped<ProtectedSessionStorage>();

var app = builder.Build();

// Automatska migracija baze
using (var scope = app.Services.CreateScope())
{
    var authProvider = scope.ServiceProvider.GetRequiredService<CustomAuthenticationStateProvider>();
    await authProvider.InitializeAsync(); // Pozivanje inicijalizacije odmah pri pokretanju aplikacije
}


// Inicijalizacija CustomAuthenticationStateProvider
using (var scope = app.Services.CreateScope())
{
    var authProvider = scope.ServiceProvider.GetRequiredService<CustomAuthenticationStateProvider>();
    await authProvider.InitializeAsync(); // Pozivanje inicijalizacije
}

// Middleware konfiguracija
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
