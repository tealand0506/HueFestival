using System.ComponentModel.DataAnnotations;

namespace HueFestival.Models
{
    public class LoaiDiaDiem
    {
        [Key]
        public int IdLoaiDD { get; set; }
        [Required, MaxLength(50)]
        public string TuaDe { get; set; }
        [Required]
        public string PathImage { get; set; }

       public ChiTiet_CTr ChuongTrinhs { get; set; }


       public ICollection<DiaDiem> DiaDiems { get; set; }
    }
}
