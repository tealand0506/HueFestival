using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
    public class Nhom_CTrDTO
    {
        [Key]
        public int IdNhomCTr { get; set; }
        public string TenNhom_CTr { get; set; }
    }
}
