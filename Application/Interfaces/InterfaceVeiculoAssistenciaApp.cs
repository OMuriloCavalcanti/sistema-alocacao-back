using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface InterfaceVeiculoAssistenciaApp : InterfaceGenericApp<VeiculoAssistencia>
    {
        Task AddVeiculosAssistencia(int veiculoId, int planoId);
        Task<List<VeiculosPlanosDTO>> ListarVeiculosComPlanosAsync();

        Task<VeiculosPlanosDTO> GetById(int id);
    }
}
