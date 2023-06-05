using System.ComponentModel.DataAnnotations;

namespace HueFestival.DataTransferObject
{
    public class ChuongTrinhDTO
    {
        public string TenCtr { get; set; }

        public string MoTa { get; set; }
      
        public string PathImage { get; set; }

        public int TypeInOff { get; set; }

        public int Arrange { get; set; }


        public string Time { get; set; }

        public string fDate { get; set; }

        public string tDate { get; set; }

        public int IdDiaDiem { get; set; }

        public int? IdDoan { get; set; }
     
        public int IdNhomCTr { get; set; }
   
    }
}
