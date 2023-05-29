using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("TinTuc")]
    public class TinTuc
    {
        [Key]
        public int IdTinTuc { get; set; }
        [Required,MaxLength(50)]
        public string TuaDe { get; set; }
        [Required,MaxLength(100)]
        public string TomTat { get; set; }
        public string NoiDung { get; set; }
        [Required,MaxLength(50)]
        public string TacGia { get; set; }
        [Required]
        public string PathImage { get; set; }
        [Required]
        public DateTime NgayCapNhat { get; set; }
    }
}
