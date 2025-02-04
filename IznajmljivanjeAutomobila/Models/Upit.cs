using System;
using System.ComponentModel.DataAnnotations;

namespace IznajmljivanjeAutomobila.Models
{
    public class Upit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ime je obavezno")]
        [StringLength(100, ErrorMessage = "Ime ne može biti duže od 100 znakova")]
        public string? Ime { get; set; }
        public string? Email { get; set; }
        public string? Poruka { get; set; }
        public DateTime Datum { get; set; } = DateTime.Now;
    }
}
