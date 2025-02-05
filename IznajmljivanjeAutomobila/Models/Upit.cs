using System;
using System.ComponentModel.DataAnnotations;

namespace IznajmljivanjeAutomobila.Models
{
    public class Upit
    {
        public int? Id { get; set; }

        public int? AutomobilId { get; set; }  // Strani ključ prema Automobilu
        public Automobil? Automobil { get; set; }  // Navigacija prema Automobilu

       
        public string? Ime { get; set; }
        public string? Username { get; set; }
        public string? Poruka { get; set; }
        public DateTime? Datum { get; set; } = DateTime.Now;

    }
}
