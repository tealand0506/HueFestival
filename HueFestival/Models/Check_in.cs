using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("Check_in")]
    public class Check_in
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdKhachHang { get; set; }
        public int IdNhanVien { get; set; }
        public DateTime NgayCheckIn { get; set; } = DateTime.Now;
        
        public ChucVu ChucVus { get; set; }
    }
}
