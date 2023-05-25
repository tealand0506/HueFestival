using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject.DiaDiem
{
    public class AddHoTro
    {

        [Required]
        public string HoTroName { get; set; }
        public string NoiDung { get; set; }
    }
}
