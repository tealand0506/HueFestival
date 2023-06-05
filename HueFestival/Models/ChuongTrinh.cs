using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HueFestival.Models
{
    [Table("ChuongTrinh")]
    public class ChuongTrinh
    {
        [Key]
        public int IdCTr { get; set; }
        [Required]
        public string TenCtr { get; set; }
        [Required]
        [MaxLength(100)]
        public string MoTa { get; set; }
        //[Required]
        //public double GiaTien { get; set; }
        [Required]
        public string PathImage { get; set; }
        [Required]
        public int TypeInOff { get; set; }
        public int Arrange { get; set; } 

        public ICollection<ThongTin_Ve> ThongTin_Ve { get; set; }

        [JsonIgnore]
        public ICollection<ChiTiet_CTr> ChiTiet_CTrs { get; set; }
        [JsonIgnore]
        public ICollection<HinhAnh_CTr> HinhAnh_CTrs { get; set; }
    }
}
