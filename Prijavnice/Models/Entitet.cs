using System.ComponentModel.DataAnnotations;

namespace Prijavnice.Models
{
    public abstract class Entitet
    {
        [Key] 
        public int? Sifra { get; set; }
    }
}
