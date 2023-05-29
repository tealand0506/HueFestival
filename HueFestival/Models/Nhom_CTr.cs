using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HueFestival.Models
{
    [Table("Nhom_CTr")]
    public class Nhom_CTr
    {
        [Key]
        public int IdNhomCTr { get; set; }
        public string TenNhom_CTr { get; set; }

        public ICollection<ChiTiet_CTr> ChiTiet_CTrs { get; set; }
    }

}
