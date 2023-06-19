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

        //Thuộc tính tham chiếu đến bảng LoaiDiaDiem
        [Required]
        public int IdLoai_DD { get; set; }
        [ForeignKey("IdLoai_DD")]
        public Loai_DiaDiem Loai_DiaDiems { get; set; }

        [Required, MaxLength(500)]
        public string MoTa { get; set; }
        [Required]
        public string PathImage { get; set; }

        public double? ToaDoX { get; set; }

        public double? ToaDoY { get; set; }

        //public ICollection<ChiTiet_CTr> ChiTiet_CTrs { get; set; }

    }
}
