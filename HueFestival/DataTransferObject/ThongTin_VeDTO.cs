using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
    public class ThongTin_VeDTO
    {
        [Required]
        public string MaVe { get; set; }
        [Required]
        public int IdLoai_ve { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public int IdChuongTrinh { get; set; }
        [Required]
        public int SLg { get; set; }
        [Required]
        public int GiaVe { get; set; }
        [Required]
        public DateTime NgayPhatHanh { get; set; }

    }
}
