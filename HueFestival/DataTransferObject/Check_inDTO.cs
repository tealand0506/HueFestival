using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
    public class Check_inDTO
    {
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
    }
}
