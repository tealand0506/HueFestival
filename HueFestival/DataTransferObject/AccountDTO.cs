using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
    public class AccountDTO
    {
        [Required, MaxLength(20)]
        public string TenDN { get; set; }
        public string HoTen { get; set; }
    }
}
