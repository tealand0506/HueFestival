using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
    public class HoTroDTO
    {
        [Required]
        public string HoTroName { get; set; }
        
        public string NoiDung { get; set; }
    }
}
