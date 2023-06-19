using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("HinhAnh_CTr")]
    public class HinhAnh_CTr
    {
        [Key]
        public int IdHinhAnh { get; set; }
        [Required]
        public int IdCTr { get; set; }
        [Required]
        public string Path { get; set; }

        [ForeignKey("IdCTr")]
        public ChuongTrinh ChuongTrinhs { get; set; }
    }
}
