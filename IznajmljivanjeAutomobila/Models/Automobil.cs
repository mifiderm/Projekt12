namespace IznajmljivanjeAutomobila.Models
{
    public class Automobil
    {
        public int Id { get; set; }
        public string? Naziv { get; set; }
        public string? Opis { get; set; }
        public string? GlavnaSlika { get; set; }
        public string? DodatneSlike { get; set; }  // Pohranjeno kao JSON string
    }

}
