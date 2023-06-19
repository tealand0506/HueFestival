using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("Loai_Ve")]
    public class Loai_Ve
    {
        [Key]
        public int IdLoai_Ve { get; set; }
        [Required]
        public string LoaiVe { get; set; }

        //public ICollection<ThongTin_Ve> ThongTin_Ves { get; set; }
    }
}
