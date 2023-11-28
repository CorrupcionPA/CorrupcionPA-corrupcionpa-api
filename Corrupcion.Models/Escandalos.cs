using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Escandalos
    {
        [Key]
        public Guid Id { get; set; }
        public Guid IdPolitico { get; set; }
        public string Titulo { get; set; } = string.Empty;

        public string Fuente { get; set; } = string.Empty;
    }
}
