using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
    public class NguoiDungDTO
    {
        [Required, MaxLength(20)]
        public string HoTen { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string SDT { get; set; }

        public int IdChucVu { get; set; }
    }
}
