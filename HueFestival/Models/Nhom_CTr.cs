using System.Text.Json.Serialization;

namespace HueFestival.Models
{
    public class Nhom_CTr
    {
        public int IdNhomCTr { get; set; }
        public string TenNhom_CTr { get; set; }

        public ICollection<ChiTiet_CTr> ChiTiet_CTrs { get; set; }
    }

}
