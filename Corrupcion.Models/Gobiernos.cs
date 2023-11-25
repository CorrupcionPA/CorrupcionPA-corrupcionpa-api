using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Gobiernos
    {
        [Key]
        public int IdGobierno { get; set; }
        public int IdPartido { get; set; }
        public int IdPresidente { get; set; }
        public Presidentes Presidente { get; set; }
    }
}
