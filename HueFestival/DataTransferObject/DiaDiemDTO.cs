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
        public int IdLoai_DD { get; set; }
        [Required, MaxLength(100)]
        public string MoTa { get; set; }
        [Required]
        public IFormFile PathImage { get; set; }
 
    }
}
