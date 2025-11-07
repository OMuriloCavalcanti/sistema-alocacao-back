using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class VeiculosPlanosDTO
    {
        public int VeiculoAssistenciaId { get; set; }

        [Required]
        public int VeiculoId { get; set; }

        public string? ModeloVeiculo { get; set; }
        
        [Required]
        public int PlanoId { get; set; }
       
        public string? PlanoDesc { get; set; }
    }
}
