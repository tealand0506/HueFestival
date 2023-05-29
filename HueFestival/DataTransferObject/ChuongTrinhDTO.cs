using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
    public class ChuongTrinhDTO
    {
        public string TenCtr { get; set; }
        [Required]
        [MaxLength(100)]
        public string MoTa { get; set; }
        [Required]
        public double GiaTien { get; set; }
        [Required]
        public string PathImage { get; set; }
        [Required]
        public int TypeInOff { get; set; }
        public int Arrange { get; set; }
    }
}
