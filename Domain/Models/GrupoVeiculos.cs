using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class GrupoVeiculos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }
    }
}