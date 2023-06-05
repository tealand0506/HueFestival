using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("HinhAnh_CTr")]
    public class HinhAnh_CTr
    {
        [Key]
        public int IdHinhAnh { get; set; }
        public int IdCtr { get; set; }
        [Required]
        public string Path { get; set; }

        public ChuongTrinh ChuongTrinhs { get; set; }
    }
}
