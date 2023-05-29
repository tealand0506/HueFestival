using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
    public class ChucVuDTO
    {
        [Required, MaxLength(20)]
        public string TenChucVu { get; set; }
    }
}
