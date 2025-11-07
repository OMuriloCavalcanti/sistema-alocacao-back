using Application.Interfaces;
using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class AppVeiculoAssistencia : InterfaceVeiculoAssistenciaApp
    {
        private readonly IVeiculoAssistencia _IVeiculoAssistencia;
        private readonly IVeiculoAssistenciaService _VeiculoAssistenciaService;
        public AppVeiculoAssistencia(IVeiculoAssistencia IVeiculoAssistencia, IVeiculoAssistenciaService IVeiculoAssistenciaService)
        {
            _IVeiculoAssistencia = IVeiculoAssistencia;
            _VeiculoAssistenciaService = IVeiculoAssistenciaService;
        }

        public async Task<List<VeiculosPlanosDTO>> ListarVeiculosComPlanosAsync()
        {
            return await _VeiculoAssistenciaService.ListarVeiculosComPlanosAsync();
        }
        public async Task AddVeiculosAssistencia(int veiculoId, int planoId)
        {
            await _VeiculoAssistenciaService.AddVeiculosAssistencia(veiculoId, planoId);
        }

        public async Task<VeiculosPlanosDTO> GetById(int id)
        {
            return await _VeiculoAssistenciaService.GetById(id);
        }

        public async Task AddAsync(VeiculoAssistencia entity)
        {
            await _IVeiculoAssistencia.AddAsync(entity);
        }

        public async Task DeleteAsync(VeiculoAssistencia entity)
        {
            await _IVeiculoAssistencia.DeleteAsync(entity);
        }

        public async Task<IEnumerable<VeiculoAssistencia>> GetAllAsync()
        {
            return await _IVeiculoAssistencia.GetAllAsync();
        }

        public async Task<VeiculoAssistencia> GetByIdAsync(int id)
        {
            return await _IVeiculoAssistencia.GetByIdAsync(id);
        }


        public async Task UpdateAsync(VeiculoAssistencia entity)
        {
            await _IVeiculoAssistencia.UpdateAsync(entity);  
        }

     
    }
}
