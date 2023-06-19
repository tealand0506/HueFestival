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
        public DateTime NgayDat { get; set; } = DateTime.Now;
        [Required]
        public int SLgVe { get; set; }
        [Required]
        public string? QRcode { get; set; }
        [Required]
        public int? ThanhTien { get; set; }

        [ForeignKey("IdVe")]
        public ThongTin_Ve ThongTin_Ves { get; set; }
        [ForeignKey("IdKhachHang")]
        public KhachHang KhachHangs { get; set; }

    }
}
