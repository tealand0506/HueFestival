using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
    public class DoanNTDTO
    {
        [Required, MaxLength(50)]
        public string TenDoan { get; set; }
    }
}
