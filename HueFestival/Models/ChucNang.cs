using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("ChucNang")]
    public class ChucNang
    {
        [Key]
        public int IdchucNang { get; set; }
        [Required, MaxLength(20)]
        public string TenChucNang { get; set; }
        public ICollection<QuyenHanh> QuyenHanhs { get; set; }
    }
}
