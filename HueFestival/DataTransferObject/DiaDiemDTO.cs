using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
    public class DiaDiemDTO
    {
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
    }
}
