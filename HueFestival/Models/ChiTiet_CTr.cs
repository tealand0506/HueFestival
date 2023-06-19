using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("ChiTiet_CTr")]
    public class ChiTiet_CTr
    {
        [Key]
        public int IdChiTiet_Ctr { get; set; }
        [Required]
        public int IdCTr { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        [Required]
        public DateTime fDate { get; set; }
        [Required]
        public DateTime tDate { get; set; }
        [Required]
        public int IdDiaDiem { get; set; }
        [Required]
        public int? IdDoan { get; set; }
        [Required]
        public int IdNhomCTr { get; set; }

        //Thuộc tính tham chiếu đến bảng ChuongTrinh
        [ForeignKey("IdCTr")]
        public ChuongTrinh ChuongTrinhs { get; set; }

        // Thuộc tính tham chiếu đến bảng DiaDiem
        [ForeignKey("IdDiaDiem")]
        public DiaDiem DiaDiems { get; set; }

        // Thuộc tính tham chiếu đến bảng Nhom
        [ForeignKey("IdNhomCTr")]
        public Nhom_CTr Nhom_CTrs { get; set; }

        // Thuộc tính tham chiếu đến bảng Doan
        [ForeignKey("IdDoan")]
        public DoanNT DoanNTs { get; set; }

    }
}
