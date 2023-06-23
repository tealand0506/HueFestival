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

        [Required, MaxLength(20)]
        public string Password { get; set; }
    }
}
