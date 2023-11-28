using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Partidos
    {
        [Key]
        public Guid Id { get; set; }
        public string Siglas { get; set; } = string.Empty;
        public string NombrePartido { get; set; } = string.Empty;
        public string NombreFundador { get; set; } = string.Empty;
        public int CantidadMiembros { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
