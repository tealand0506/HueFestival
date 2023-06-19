using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("Loai_DiaDiem")]
    public class Loai_DiaDiem
    {
        [Key]
        public int IdLoai_DD { get; set; }
        [Required, MaxLength(50)]
        public string TuaDe { get; set; }
        [Required]
        public string PathImage { get; set; }

       // public ICollection<DiaDiem> DiaDiems { get; set; }

    }
}
