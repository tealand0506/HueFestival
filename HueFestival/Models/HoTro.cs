using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("HoTro")]
    public class HoTro
    {
        [Key]
        public int IdHoTro { get; set; }
        [Required]
        public string HoTroName { get; set; }

        public string NoiDung { get; set; }
    }
}
