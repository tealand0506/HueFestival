using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int IdAcc { get; set; }
        [Required, MaxLength(20)]
        public string TenDN { get; set; }
        public string HoTen { get; set; }
        [Required]
        public string Email { get; set; }
        [Required, MaxLength(20)]
        public string Password { get; set; }
        [Required]
        public string SDT { get; set; }

        public int IdChucVu { get; set; }
        [ForeignKey("IdChucVu")]
        public ChucVu ChucVus { get; set; }
    }
}
