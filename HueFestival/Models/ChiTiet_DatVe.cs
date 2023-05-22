using System.ComponentModel.DataAnnotations;

namespace HueFestival.Models
{
    public class ChiTiet_DatVe
    {
        [Key]
        public int IdDatVe { get; set; }
        [Required]
        public int IdVe { get; set; }
        [Required]
        public DateTime NgayDat { get; set; }
    }
}
