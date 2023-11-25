using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Escandalos
    {
        [Key]
        public int IdEscandalo { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public int IdGobierno { get; set; }
    }
}
