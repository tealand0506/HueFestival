using System.ComponentModel.DataAnnotations;

namespace HueFestival.Models
{
    public class ChiTiet_CTr
    {
        [Key]
        public int IdChiTiet_Ctr { get; set; }
        [Required]
        public int IdCtr { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        [Required]
        public DateTime fDate { get; set; }
        [Required]
        public DateTime tDate { get; set; }
        [Required]
        public int IdDiaDiem { get; set; }
        [Required]
        public string TenDiaDiem { get; set; }
        [Required]
        public int? IdDoan { get; set; }
        public string? TenDoan { get; set; }
        public int IdNhomCTr { get; set; }
        [Required]
        public string TenNhom { get; set; }

        //Thuộc tính tham chiếu đến bảng ChuongTrinh
        public ChuongTrinh ChuongTrinhs { get; set; }

        // Thuộc tính tham chiếu đến bảng DiaDiem
        public DiaDiem DiaDiems { get; set; }

        // Thuộc tính tham chiếu đến bảng Nhom
        public Nhom_CTr Nhom_CTrs { get; set; }

        // Thuộc tính tham chiếu đến bảng Doan
        public DoanNT DoanNTs { get; set; }

        public ICollection<Ve> Ves { get; set; }
    }
}
