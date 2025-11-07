using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class EmpresaAssistencia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Endereco { get; set; }
    }
}