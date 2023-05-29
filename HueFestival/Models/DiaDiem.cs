using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("DiaDiem")]
    public class DiaDiem
    {
        [Key]
        public int IdDiaDiem { get; set; }
        [Required]
        [MaxLength(50)]
        public string TenDiaDiem { get; set; }
        public string? DiaChi { get; set; }
        [Required]
        public int IdLoaiDD { get; set; }
        [Required, MaxLength(100)]
        public string MoTa { get; set; }
        [Required]
        public string PathImage { get; set; }

        public double? ToaDoX { get; set; }

        public double? ToaDoY { get; set; }

        public ICollection<ChiTiet_CTr> ChiTiet_CTrs { get; set; }

        //Thuộc tính tham chiếu đến bảng LoaiDiaDiem
        public Loai_DiaDiem LoaiDiaDiems { get; set; }
    }
}
