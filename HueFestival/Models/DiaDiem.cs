using System.ComponentModel.DataAnnotations;

namespace HueFestival.Models
{
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
        public string TomTat { get; set; }
        public string NoiDung { get; set; }
        [Required]
        public string PathImage { get; set; }
        [Required]
        public double ToaDoX { get; set; }
        [Required]
        public double ToaDoY { get; set; }

        public ICollection<ChiTiet_CTr> ChiTiet_CTrs { get; set; }

        //Thuộc tính tham chiếu đến bảng LoaiDiaDiem
        public LoaiDiaDiem LoaiDiaDiems { get; set; }
    }
}
