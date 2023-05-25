using System.ComponentModel.DataAnnotations;

namespace HueFestival.Models
{
    public class HinhAnh_CTr
    {
        [Key]
        public int IdHinhAnh { get; set; }
        public int IdCtr { get; set; }
        public string Path { get; set; }

        public ChuongTrinh ChuongTrinhs { get; set; }
    }
}
