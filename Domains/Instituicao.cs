using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_Event.Domains
{
    [Table("Instituicao")]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
    {
        [Key]

        public Guid InstitucaoId { get; set; }
        
        [Column(TypeName = "VARCHAR(14)" )]
        [Required(ErrorMessage = "o CNPJ é obrigatório")]
        [StringLength(14)]
        public string? CNPJ { get;set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "o endereço é obrigatório")]
        public string? Endereco {  get;set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "o nome é obrigatório")]
        public string? NomeFantasia { get; set; }

    }
}
