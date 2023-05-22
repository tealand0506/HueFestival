using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HueFestival.Models
{
    public class DoanNT
    {
        [Key]
        public int IdDoan { get; set; }
        [Required, MaxLength(50)]
        public string TuaDe { get; set; }
        [Required, MaxLength(100)]
        public string TomTat { get; set;}
        [Required]
        public string NoiDung { get; set; }
        [Required]
        public string TacGia { get; set; }
        [Required]
        public string PathImage { get; set; }
        public DateTime NgayCapNhat { get; set;}

        
        
        public ICollection<ChiTiet_CTr> ChiTiet_Ctrs { get; set; }
    }
}
