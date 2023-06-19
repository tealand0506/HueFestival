using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("Check_in")]
    public class Check_in
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdDatVe { get; set; }
        [ForeignKey("IdDatVe")]
        public ChiTiet_DatVe ChiTiet_DatVes { get; set; }
        [Required]
        public int IdNhanVien { get; set; }
        
        public DateTime NgayCheckIn { get; set; } = DateTime.Now;

    }
}
