using System.ComponentModel.DataAnnotations.Schema;

namespace EdunovaAPP.Models
{
    public class Vozila : Entitet
    {
        public string? Marka { get; set; }
        
        public string? Model { get; set; }
        public int? Snaga { get; set; }
        public string? Pogon { get; set; }
        
    }
}
