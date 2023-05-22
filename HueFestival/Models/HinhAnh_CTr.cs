namespace HueFestival.Models
{
    public class HinhAnh_CTr
    {
        public int IdHinhAnh;
        public int IdCtr;
        public string Path;

        public ChuongTrinh ChuongTrinhs { get; set; }
    }
}
