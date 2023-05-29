using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public int IdKhachHang { get; set; }
        [Required]
        public string HoTen { get; set; }
        [Required]
        public DateTime NgaySinh { get; set; }
        [Required]
        //[StringLength(12, MinimumLength = 12)] // rang buoc kiem tra so luong ky tu CCCD batbuoc = 12
        public string CCCD { get; set; }
        [Required]
        //[StringLength(10, MinimumLength = 10)]
        public string SDT { get; set; }

        public ICollection<ChiTiet_DatVe> ChiTiet_DatVes { get; set; }
    }
}
