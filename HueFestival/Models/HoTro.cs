using System.ComponentModel.DataAnnotations;

namespace HueFestival.Models
{
    public class HoTro
    {
        [Key]
        public int IdHoTro { get; set; }
        [Required]
        public string HoTroName { get; set; }
        public string NoiDung { get; set; }
    }
}
