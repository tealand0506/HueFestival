using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
    public class KhachHangDTO
    {
        public string HoTen { get; set; }
        [Required]
        public DateTime NgaySinh { get; set; }
        [Required]
        //[StringLength(12, MinimumLength = 12)] // rang buoc kiem tra so luong ky tu CCCD batbuoc = 12
        public string CCCD { get; set; }
        [Required]
        //[StringLength(10, MinimumLength = 10)]
        public string SDT { get; set; }
        //public string Email { get; set; }
    }
}
