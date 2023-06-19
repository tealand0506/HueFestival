using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HueFestival.Models
{
    [Table("DoanNT")]
    public class DoanNT
    {
        [Key]
        public int IdDoan { get; set; }
        [Required, MaxLength(50)]
        public string TenDoan { get; set; }
        
        //public ICollection<ChiTiet_CTr> ChiTiet_Ctrs { get; set; }
    }
}
