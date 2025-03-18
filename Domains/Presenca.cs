using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_Event.Domains
{

    [Table("Presenca")]
    [Index(nameof(Situacao), IsUnique = true)]

    public class Presenca
    {
        [Key]

        public Guid PresencaId { get; set; }

        
        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "Campo obrigatorio!")]
        public bool? Situacao { get; set; }

        
        
        [Required(ErrorMessage = "Usuario obrigatorio")]
        public Guid UsuarioId { get; set; } 

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }




        [Required(ErrorMessage = "Evento obrigatorio")]
        public Guid EventoId { get; set; }

        [ForeignKey("EventoId")]
        public Evento? Evento { get; set; }






    }
}
