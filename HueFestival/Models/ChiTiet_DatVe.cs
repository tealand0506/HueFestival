using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("ChiTiet_DatVe")]
    public class ChiTiet_DatVe
    {
        [Key]
        public int IdDatVe { get; set; }
        [Required]
        public int IdVe { get; set; }
        [Required]
        public int IdKhachHang { get; set; }
        [Required]
        public DateTime NgayDat { get; set; }
        [Required]
        public int SLgVe { get; set; }

        public ThongTin_Ve ThongTin_Ves { get; set; }
        public KhachHang KhachHangs { get; set; }

    }
}
