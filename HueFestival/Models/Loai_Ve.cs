using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("Loai_Ve")]
    public class Loai_Ve
    {
        [Key]
        public int IdLoai_ve { get; set; }
        [Required]
        public string LoaiVe { get; set; }
        public string? MoTa { get; set; }

        public ICollection<Loai_Ve> Loai_Ves { get; set; }
    }
}
