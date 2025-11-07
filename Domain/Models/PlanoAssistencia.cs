using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class PlanoAssistencia
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("EmpresaAssistencia")]
        public int EmpresaId { get; set; }

        [JsonIgnore]
        public EmpresaAssistencia? Empresa { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Cobertura { get; set; }
    }
}