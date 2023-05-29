using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
    public class ChucNangDTO
    {
        [Required, MaxLength(20)]
        public string TenChucNang { get; set; }
    }
}
