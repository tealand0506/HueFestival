using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("QuyenHanh")]
    public class QuyenHanh
    {
        [Key]
        public int IdQuyenHanh { get; set; }
        [Required]
        public int IdChucVu { get; set; }
        [Required]
        public int IdChucNang { get; set; }

        public ChucVu ChucVus { get; set; }
        public ChucNang ChucNangs { get; set; }
    }
}
