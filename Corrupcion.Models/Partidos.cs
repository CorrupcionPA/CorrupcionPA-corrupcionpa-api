using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Partidos
    {
        [Key]
        public int IdPartido { get; set; }
        public string NombrePartido { get; set; } = string.Empty;
        public string NombreAbreviado { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
    }
}
