using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
    public class Loai_DiaDiemDTO
    {
        [Required, MaxLength(50)]
        public string TuaDe { get; set; }
        [Required]
        public string PathImage { get; set; }
    }
}
