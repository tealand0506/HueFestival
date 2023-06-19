using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
    public class ChiTiet_DatVeDTO
    {
        [Required]
        public int IdVe { get; set; }
        [Required]
        public int IdKhachHang { get; set; }
        [Required]
        public int Slg { get; set; }
    }
}
