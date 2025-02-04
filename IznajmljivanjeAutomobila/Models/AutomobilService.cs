using Newtonsoft.Json;
using IznajmljivanjeAutomobila.Models;
using System.Collections.Generic;

namespace IznajmljivanjeAutomobila.Services
{
    public class AutomobilService
    {
        public List<Automobil> GetAutomobili()
        {
            return new List<Automobil>
            {
                new Automobil
                {
                    Id = 1,
                    Naziv = "Audi A6",
                    Opis = "Auto je top",
                    GlavnaSlika = "/auti/naslovna.jpg",
                    DodatneSlike = JsonConvert.SerializeObject(new List<string>
                    {
                        "/auti/Audi1.jpg",
                        "/auti/Audi2.jpg"
                    })
                },
                new Automobil
                {
                    Id = 2,
                    Naziv = "Škoda Octavia",
                    Opis = "Škoda je odlična za duge vožnje.",
                    GlavnaSlika = "/auti/SkodaOctavia.jpg",
                    DodatneSlike = JsonConvert.SerializeObject(new List<string>
                    {
                        "/auti/Skoda1.jpg",
                        "/auti/Skoda2.jpg"
                    })
                },
                new Automobil
                {
                    Id = 3,
                    Naziv = "VW Golf 7",
                    Opis = "Vrlo udoban i ekonomičan automobil.",
                    GlavnaSlika = "/auti/Golf7.jpg",
                    DodatneSlike = JsonConvert.SerializeObject(new List<string>
                    {
                        "/auti/Golf1.jpg",
                        "/auti/Golf2.jpg",
                        "/auti/Golf4.jpg"
                    })
                }
            };
        }

        public async Task<Automobil> GetAutomobilByNazivAsync(string naziv)
        {
            var automobili = GetAutomobili();  // Dobijemo listu automobila
            var automobil = automobili.FirstOrDefault(a => a.Naziv == naziv);
            return await Task.FromResult(automobil ?? new Automobil());  // Vratimo podrazumijevani automobil ako nije pronađen
        }
    }
}
