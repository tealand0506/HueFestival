using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
    public class ChucNangDTO
    {
        [Key]
        public int IdChucNang { get; set; }
        [Required, MaxLength(20)]
        public string TenChucNang { get; set; }
    }
}
