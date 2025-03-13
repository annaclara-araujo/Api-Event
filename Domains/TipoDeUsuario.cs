using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Event.Domains
{

    [Table("TipoDeUsuario")]
    public class TipoDeUsuario
    {
        [Key]

        public Guid TipoDeUsuarioId { get; set; }
        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O tipo de usuario e obrigatorio")]
        public string? TituloTipoUsuario { get; set; }

    }
}
