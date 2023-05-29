using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HueFestival.Models
{
    [Table("ThongTin_Ve")]
    public class ThongTin_Ve
    {
        [Key]
        public int IdVe { get; set; }
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

        public Loai_Ve Loai_Ves { get; set; }
       
         public ChuongTrinh ChuongTrinhs { get; set; }    
        
    }
}
