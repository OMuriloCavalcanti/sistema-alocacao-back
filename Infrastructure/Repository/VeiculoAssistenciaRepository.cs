using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class VeiculoAssistenciaRepository : RepositoryGeneric<VeiculoAssistencia>, IVeiculoAssistencia
    {
        public VeiculoAssistenciaRepository(AppDbContext OptionsBuilder) : base(OptionsBuilder)
        {
            
        }
    }
}
