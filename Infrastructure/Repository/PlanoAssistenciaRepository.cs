using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PlanoAssistenciaRepository : RepositoryGeneric<PlanoAssistencia>, IPlanoAssistencia
    {
        public PlanoAssistenciaRepository(AppDbContext OptionsBuilder) : base(OptionsBuilder)
        {

        }
    }
}
