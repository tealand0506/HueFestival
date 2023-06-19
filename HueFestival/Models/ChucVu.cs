using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("ChucVu")]
    public class ChucVu
    {
        [Key]
        public int IdChucVu { get; set; }
        [Required, MaxLength(20)]
        public string TenChucVu { get; set; }

        //public ICollection<Account> Accounts { get; set; }
    }
}
