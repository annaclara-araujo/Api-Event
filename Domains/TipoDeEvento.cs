using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Event.Domains
{
    [Table("TipoDeEvento")]
    public class TipoDeEvento
    {
        [Key]

        public Guid TipoDeEventoId { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O tipo de evento e obrigatorio")]

        public string? TituloTipoEvento { get; set; }
    }
}
