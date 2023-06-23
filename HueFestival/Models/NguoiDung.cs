using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("NguoiDung")]
    public class NguoiDung
    {
        [Key]
        public int IdNguoiDung { get; set; }
        [Required, MaxLength(20)]
        public string HoTen { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string SDT { get; set; }

        public int IdChucVu { get; set; }
        [ForeignKey("IdChucVu")]
        public ChucVu ChucVus { get; set; }

        public int IdAccount {get; set;}
        [ForeignKey("IdAccount")]
        public Account Accounts { get;set;}
    }
}
