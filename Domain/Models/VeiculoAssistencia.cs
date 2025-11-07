using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class VeiculoAssistencia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("PlanoAssistencia")]
        public int PlanoId { get; set; }

        public PlanoAssistencia? Plano { get; set; }

        [Required]
        [ForeignKey("Veiculo")]
        public int VeiculoId { get; set; }

        public Veiculo? Veiculo { get; set; }
    }
}