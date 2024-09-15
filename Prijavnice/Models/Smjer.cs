using System.ComponentModel.DataAnnotations.Schema;

namespace Prijavnice.Models
{
    public class vozilo : Entitet
    {
        public string? Marka { get; set; }
        
        public string? Model { get; set; }

        public int? Snaga { get; set; }

        public string? Pogon { get; set; }

        public int? Vozaci_sifra { get; set; }
    }
}
