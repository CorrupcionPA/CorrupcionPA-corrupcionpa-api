using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Politicos
    {
        [Key]
        public Guid Id { get; set; }
        public string IdPartido { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public DateTime InicioPeriodo { get; set; }
        public DateTime FinPeriodo { get; set; }
    }
}
