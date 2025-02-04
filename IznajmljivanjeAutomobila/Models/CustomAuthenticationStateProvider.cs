using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using IznajmljivanjeAutomobila.Data;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ProtectedSessionStorage _sessionStorage;

    public CustomAuthenticationStateProvider(ApplicationDbContext dbContext, ProtectedSessionStorage sessionStorage)
    {
        _dbContext = dbContext;
        _sessionStorage = sessionStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
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

    public async Task<bool> LoginUserAsync(string username, string password)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            return false; // Neispravna prijava
        }

        await _sessionStorage.SetAsync("authUser", username);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username)
        };

        var identity = new ClaimsIdentity(claims, "apiauth");
        var principal = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
        return true;
    }

    public async Task LogoutUserAsync()
    {
        await _sessionStorage.DeleteAsync("authUser");

        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
    }
}
