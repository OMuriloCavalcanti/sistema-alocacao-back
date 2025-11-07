using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public string Placa { get; set; }
        
        [Required]
        [ForeignKey("GrupoVeiculos")]
        public int GrupoId { get; set; }

        [JsonIgnore]
        public GrupoVeiculos? Grupo { get; set; }
    }
}