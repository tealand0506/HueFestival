using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
    public class ChucVuDTO
    {
        [Key]
        public int IdChucVu { get; set; }
        [Required, MaxLength(20)]
        public string TenChucVu { get; set; }
    }
}
