using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Presidentes
    {
        [Key]
        public int IdPresidente { get; set; }
        public string Key { get; set; } = string.Empty;
        public string NombrePresidente { get; set; } = string.Empty;
        public string NombreVicePresidente { get; set; } = string.Empty;

        public int IdPartido { get; set; }
    }
}
