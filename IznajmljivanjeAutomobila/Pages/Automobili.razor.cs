using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Authorization;

namespace IznajmljivanjeAutomobila.Pages
{
    public partial class Automobili : ComponentBase
    {
        // Zadržana jedina metoda za navigaciju
        private void NavigirajNaDetalje(string nazivAuta)
        {
            NavigationManager.NavigateTo($"/AutoDetalji/{nazivAuta}");
        }
    }
}

