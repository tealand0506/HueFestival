using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HueFestival.Models
{
    public class Ve
    {
        [Key]
        public int IdVe { get; set; }
        [Required]
        public string MaVe { get; set; }
        [Required]
        public int IdLoai_ve { get; set; }
        [Required]
        public int IdChiTiet_Ctr { get; set; }
        [Required]
        public int SLg { get; set; }
        [Required]
        public int GiaVe { get; set; }
        [Required]
        public DateTime NgayPhatHanh { get; set; }

        public Loai_Ve loai_Ve { get; set; }
       
         public ChiTiet_CTr ChiTiet_CTr { get; set; }    
        
    }
}
