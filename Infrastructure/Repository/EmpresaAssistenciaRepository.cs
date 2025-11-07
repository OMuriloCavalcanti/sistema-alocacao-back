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
    public class EmpresaAssistenciaRepository : RepositoryGeneric<EmpresaAssistencia>, IEmpresaAssistencia
    {
        public EmpresaAssistenciaRepository(AppDbContext OptionsBuilder) : base(OptionsBuilder)
        {

        }
    }
}
