using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
        public class AccountDTO
        {
            [Required, MaxLength(20)]
            public string TenDN { get; set; }
            [Required, MaxLength(20)]
            public string Password { get; set; }
        }
}
