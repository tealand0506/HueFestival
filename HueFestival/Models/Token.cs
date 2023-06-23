using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival.Models
{
    [Table("Token")]
    public class Token
    {
        [Key]
        public int IdToke{get; set; }
        public int IdAccount{get; set;}
        [ForeignKey("IdAccount")]
        public Account Accounts { get;set ;}

        public string MaToken{get; set;}
        public string IdJwt{get; set;}
    }
}