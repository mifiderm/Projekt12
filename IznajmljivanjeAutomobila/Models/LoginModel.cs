using System.ComponentModel.DataAnnotations;

namespace IznajmljivanjeAutomobila.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email je obavezno.")]
        [EmailAddress(ErrorMessage = "Neispravan email.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lozinka je obavezna.")]
        [MinLength(3, ErrorMessage = "Lozinka mora biti barem 3 znaka.")]
        public string Password { get; set; } = string.Empty;

    }



}
