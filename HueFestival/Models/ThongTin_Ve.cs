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
        public bool Status { get; set; }
        [Required]
        public int SLg { get; set; }
        [Required]
        public int GiaVe { get; set; }
        [Required]
        public DateTime NgayPhatHanh { get; set; } = DateTime.Now;

        [Required]
        public int IdLoai_Ve { get; set; }
        [ForeignKey("IdLoai_Ve")]
        public Loai_Ve Loai_Ves { get; set; }

        [Required]
        public int IdCTr { get; set; }
        [ForeignKey("IdCTr")]
        public ChuongTrinh ChuongTrinhs { get; set; }    
        
        public ChiTiet_DatVe ChiTiet_DatVes { get; set; }
    }
}
