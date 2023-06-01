using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
        public class AccountDTO
        {
            [Required, MaxLength(20)]
            public string TenDN { get; set; }
            public string HoTen { get; set; }

            [Required]
            public string Email { get; set; }
            [Required, MaxLength(20)]
            public string Password { get; set; }
            [Required]
            public string SDT { get; set; }

            public int IdChucVu { get; set; }
        }
}
