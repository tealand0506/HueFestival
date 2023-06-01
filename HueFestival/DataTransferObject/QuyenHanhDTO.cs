using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
        public class QuyenHanhDTO
        {
            [Required]
            public int IdChucVu { get; set; }
            [Required]
            public int IdChucNang { get; set; }
        }
}
