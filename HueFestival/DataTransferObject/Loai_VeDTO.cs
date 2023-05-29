using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
    public class Loai_VeDTO
    {
        [Key]
        public int IdLoai_ve { get; set; }
        [Required]
        public string LoaiVe { get; set; }
        public string? MoTa { get; set; }
    }
}
